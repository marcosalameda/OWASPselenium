import { toRaw, unref } from 'vue'
import { mapState } from 'pinia'
import cloneDeep from 'lodash-es/cloneDeep'
import _assignIn from 'lodash-es/assignIn'
import _find from 'lodash-es/find'
import _foreach from 'lodash-es/forEach'
import _get from 'lodash-es/get'
import _isEmpty from 'lodash-es/isEmpty'

import { useSystemDataStore } from '@/stores/systemData.js'
import { useLayoutDataStore } from '@/stores/layoutData.js'

import netAPI from '@/api/network'
import { btnHasPermission } from '@/mixins/genericFunctions.js'
import listFunctions from '@/mixins/listFunctions.js'
import genericFunctions from '@/mixins/genericFunctions.js'
import hardcodedTexts from '@/hardcodedTexts.js'
import qEnums from '@/mixins/quidgest.mainEnums.js'

/*****************************************************************
 * This mixin aggregates operations over lists, which can be     *
 * reused in menus and form components.                          *
 *****************************************************************/
export default {
	computed: {
		...mapState(useSystemDataStore, [
			'system'
		]),

		...mapState(useLayoutDataStore, [
			'layoutConfig'
		])
	},

	methods: {
		/**
		 * Fetches the data from the server and loads the list.
		 * @param {object} listControl The list control object
		 * @param {object} params The necessary parameters
		 * @param {Function} fnUpdateData The custom callback method for update the data
		 * @returns A promise with the response from the server.
		 */
		fetchListData(listControl, params, fnUpdateData)
		{
			// Table list limits
			const limits = listControl.getLimitsValues()

			// Object with required parameters
			let actionParams = {
				id: limits.id ?? this.$route.params.id,
				queryParams: {},
				...params
			}

			// Mark if it's a first load, needs to «Jump if just one»
			if (!listControl.dataAlreadyRequested)
				Reflect.set(actionParams.queryParams, 'isFirstLoad', true)
			listControl.dataAlreadyRequested = true

			const currentControl = this.currentControl
			if (!_isEmpty(currentControl) && currentControl.id === listControl.id)
			{
				if (listControl.type !== 'TreeList')
				{
					// Set the page where the user previously was
					const listName = listControl.config.name
					Reflect.set(actionParams.queryParams, 'SearchFilters', JSON.stringify(currentControl.data?.searchFilters))
					Reflect.set(actionParams.queryParams, 'perPage', currentControl.data?.recordNumber)
					Reflect.set(actionParams.queryParams, `p${listName}`, currentControl.data?.page)
					Reflect.set(actionParams.queryParams, `q${listName}`, currentControl.data?.globalSearch)
				}

				this.removeCurrentControl({
					navigationId: this.navigationId,
					controlId: listControl.id
				})
			}

			// Put the limit values in Navigation (history) before making the request to the server.
			_foreach(limits, (value, key) => {
				const entry = {
					navigationId: this.navigationId,
					key,
					value
				}
				this.setEntryValue(entry)
			})

			return netAPI.postData(listControl.controller, listControl.action, actionParams, (data) => {
				// When loading additional data for the branch of the tree,
				// we use a customized callback to assign data to the branch's children.
				if (typeof fnUpdateData === 'function')
					fnUpdateData(data, listControl)
				else
				{
					let rowKeyToScroll = ''

					// FOR: table go to row on return
					// If returning to the table from a form, set key of row to go to
					if (!_isEmpty(currentControl) && currentControl.id === listControl.id)
					{
						rowKeyToScroll = currentControl?.data?.rowKey
						listControl.config.rowKeyToScroll = rowKeyToScroll
					}

					if (listControl.type === 'TreeList')
						listControl.hydrate(listControl, data, rowKeyToScroll)
					else
						listControl.hydrate(listControl, data)
					listControl.isLoaded = true

					if (typeof this.removeEntryValue === 'function')
						this.removeEntryValue({ navigationId: this.navigationId, key: 'LoadBaseTable' })

					listControl.afterLoaded()
				}
			}, undefined, undefined, this.navigationId)
		},

		/**
		 * Fetches the data from the server and loads the list.
		 * @param {object} timelineControl The Timeline control object
		 * @param {object} params The necessary parameters
		 * @returns A promise with the response from the server.
		 */
		fetchTimelineData(timelineControl, params)
		{
			if (_isEmpty(params))
				params = {}

			_assignIn(params, this.$route.params)

			return netAPI.postData(timelineControl.controller, timelineControl.action, params, (data) => {
				timelineControl.hydrate(timelineControl, data)
				timelineControl.isLoaded = true
			}, undefined, undefined, this.navigationId)
		},

		/**
		 * Open support form of timeline item.
		 * @param {object} emittedAction The TimelineItem data
		 */
		timelineOpenForm(emittedAction)
		{
			if (emittedAction?.SupportForm)
			{
				let options = { isPopup: emittedAction.IsPopupForm }
				this.navigateToForm(emittedAction.SupportForm, 'SHOW', emittedAction.Identifier, options)
			}
		},

		/**
		 * Clear unsaved configurations for this table
		 * @param {object} listConf The list configuration
		 */
		clearUnsavedConfig(listConf)
		{
			if (typeof this.removeParamValue !== 'function')
				return

			this.removeParamValue({
				navigationId: this.navigationId,
				key: `CurrentTableConfig_${listConf.config.name}`
			})
		},

		/**
		 * Compiles a list with the search filters over the specified list control.
		 * @param {object} listControl The list control object
		 * @param {object} eObj The row object
		 * @returns A list with the current search filters.
		 */
		getSearchFilters(listControl, eObj)
		{
			if (typeof eObj !== 'object')
				return []

			const searchFilters = []

			// BEGIN: Advanced filters (from menu)
			listFunctions.filtersToServerFormat(eObj.advancedFilters, listControl.columns)
			if (eObj.advancedFilters !== undefined)
			{
				for (let filterIdx in eObj.advancedFilters)
					searchFilters.push(eObj.advancedFilters[filterIdx])
			}
			// END: Advanced filters (from menu)

			// BEGIN: Column filters (from column dropdown)
			listFunctions.filtersToServerFormat(eObj.columnFilters, listControl.columns)
			if (eObj.columnFilters !== undefined)
			{
				for (let columnKey in eObj.columnFilters)
					searchFilters.push(eObj.columnFilters[columnKey])
			}
			// END: Column filters (from column dropdown)

			// BEGIN: Search bar filters
			listFunctions.filtersToServerFormat(eObj.searchBarFilters, listControl.columns)
			if (eObj.searchBarFilters !== undefined)
			{
				for (let columnKey in eObj.searchBarFilters)
					searchFilters.push(eObj.searchBarFilters[columnKey])
			}
			// END: Search bar filters

			return searchFilters
		},

		/**
		 *
		 * @param {object} listConf The list configuration
		 * @param {object} eObj
		 * @returns An object with the required formatted parameters.
		 */
		formatListParameters(listConf, eObj)
		{
			var listName = listConf.config.name,
				params = {}

			// Search
			Reflect.set(params, `q${listName}`, eObj.globalSearch || '')
			// Page
			Reflect.set(params, `p${listName}`, eObj.page)
			// Sort
			if (eObj.sort && eObj.sort.length !== 0)
			{
				Reflect.set(params, `s${listName}`, eObj.sort[0].name || '')
				Reflect.set(params, `d${listName}`, (eObj.sort[0].order || '').toUpperCase())
			}

			// BEGIN: Filters
			// BEGIN: Group Filters
			if (eObj.groupFilters !== undefined)
			{
				for (let groupKey in eObj.groupFilters)
				{
					let entry = eObj.groupFilters[groupKey]
					if (!params[entry.id] || !entry.isMultiple)
						params[entry.id] = ''
					params[entry.id] += entry.value
				}
			}
			// END: Group Filters
			// BEGIN: Active Filters
			if (eObj.activeFilters !== undefined && eObj.activeFilters.options !== undefined)
			{
				for (let activeKey in eObj.activeFilters.options)
				{
					let filter = eObj.activeFilters.options[activeKey]
					Reflect.set(params, filter.id, filter.selected)
				}
				if (eObj.activeFilters.dateValue !== undefined && eObj.activeFilters.dateValue.value !== undefined)
					Reflect.set(params, eObj.activeFilters.dateValue.id, eObj.activeFilters.dateValue.value)
			}
			// END: Active Filters

			const searchFilters = this.getSearchFilters(listConf, eObj)
			Reflect.set(params, 'SearchFilters', JSON.stringify(searchFilters))
			// END: Filters

			// Rows per page
			delete listConf.config.perPage
			listConf.config.perPage = eObj.perPage
			Reflect.set(params, 'perPage', eObj.perPage)

			this.removeCurrentControl({
				navigationId: this.navigationId,
				controlId: listConf.id
			})

			return {
				queryParams: params
			}
		},

		/**
		 *
		 * @param {object} listConf The list configuration
		 * @param {object} eObj
		 * @returns A promise with the response from the server.
		 */
		onTableListChangeQuery(listConf, eObj)
		{
			return this.fetchListData(listConf, this.formatListParameters(listConf, eObj))
		},

		/**
		 * Set whether search will be triggered next time search data changes
		 * @param {object} listConf The list configuration
		 * @param {boolean} value
		 */
		setSearchOnNextChange(listConf, value)
		{
			listConf.searchOnNextChange.value = value
		},

		/**
		 * Add advanced filter
		 * @param {object} listConf The list configuration
		 * @param filter {Object}
		 */
		addAdvancedFilter(listConf, filter)
		{
			this.setSearchOnNextChange(listConf, true)
			listConf.advancedFilters.push(filter)
		},

		/**
		 * Edit advanced filter
		 * @param {object} listConf The list configuration
		 * @param filter {Object}
		 * @param index {number}
		 */
		editAdvancedFilter(listConf, filter, index)
		{
			this.setSearchOnNextChange(listConf, true)
			listConf.advancedFilters[index] = filter
		},

		/**
		 * Set advanced filter state
		 * @param {object} listConf The list configuration
		 * @param {number} index : index
		 * @param {boolean} active : active state
		 */
		setAdvancedFilterState(listConf, index, active)
		{
			this.setSearchOnNextChange(listConf, true)
			listConf.advancedFilters[index].Active = active
		},

		/**
		 * Set multiple advanced filter states
		 * @param {object} listConf The list configuration
		 * @param {Array} selectedFilterIdxs : index
		 * @param {boolean} active : active state
		 */
		setAdvancedFilterStates(listConf, selectedFilterIdxs, active)
		{
			this.setSearchOnNextChange(listConf, true)
			var selectedFilterIdx = -1
			for (let idx in selectedFilterIdxs)
			{
				selectedFilterIdx = selectedFilterIdxs[idx]
				listConf.advancedFilters[selectedFilterIdx].Active = active
			}
		},

		/**
		 * Remove all advanced filters
		 * @param {object} listConf The list configuration
		 */
		removeAllAdvancedFilters(listConf)
		{
			this.setSearchOnNextChange(listConf, true)
			listConf.advancedFilters.splice(0)
		},

		/**
		 * Set all advanced filter states to inactive
		 * @param {object} listConf The list configuration
		 */
		deactivateAllAdvancedFilters(listConf)
		{
			this.setSearchOnNextChange(listConf, true)
			for (let idx in listConf.advancedFilters)
				listConf.advancedFilters[idx].Active = false
		},

		/**
		 * Set advanced filter state
		 * @param {object} listConf The list configuration
		 * @param {number} index : index
		 */
		removeAdvancedFilter(listConf, index)
		{
			this.setSearchOnNextChange(listConf, true)
			listConf.advancedFilters.splice(index, 1)
		},

		/**
		 * Clear all advanced filters
		 * @param {object} listConf The list configuration
		 */
		clearAdvancedFilters(listConf)
		{
			this.setSearchOnNextChange(listConf, true)
			listConf.advancedFilters = []
		},

		/**
		 * Open advanced filters
		 * @param {object} listConf The list configuration
		 * @param {boolean} visible
		 * @param {number} selectedFilterIdx
		 */
		setAdvancedFiltersPopup(listConf, visible, selectedFilterIdx)
		{
			var useVisible = false
			if (visible !== undefined)
				useVisible = !!visible

			var useSelectedFilterIdx = null
			if (selectedFilterIdx !== undefined)
				useSelectedFilterIdx = selectedFilterIdx

			// Set advanced filters open config to show and select corresponding filter by index
			listConf.subSignals.advancedFilters = { 'show': useVisible, 'selectedFilterIdx': useSelectedFilterIdx }
		},

		/**
		 * Set property in table object
		 * @param {object} listConf The list configuration
		 * @param {string} name...
		 * @param {object} value
		 */
		setProperty()
		{
			switch (arguments.length)
			{
				case 3:
					arguments[0][arguments[1]] = arguments[2]
					break
				case 4:
					arguments[0][arguments[1]][arguments[2]] = arguments[3]
					break
				case 5:
					arguments[0][arguments[1]][arguments[2]][arguments[3]] = arguments[4]
					break
				default:
					return
			}
		},

		/**
		 * Set sub-property in array in table object where property has value
		 * @param {object} listConf The list configuration
		 * @param {string} arrayName
		 * @param {string} propertyName
		 * @param {string} propertyValue
		 * @param {string} key
		 * @param {object} value
		 * @param {object} otherValue
		 */
		setArraySubPropWhere(listConf, arrayName, propertyName, propertyValue, key, value, otherValue)
		{
			for (let idx in listConf[arrayName])
			{
				let elem = listConf[arrayName][idx]
				if (elem[propertyName] === propertyValue)
					listConf[arrayName][idx][key] = value
				else if (otherValue !== undefined && otherValue !== null)
					listConf[arrayName][idx][key] = otherValue
			}
		},

		/**
		 * Set property in table object that is used to send a signal to a component
		 * @param {object} listConf The list configuration
		 * @param {string} id
		 * @param {object} signal
		 */
		signalComponent(listConf, id, signal, mergeProps)
		{
			if (mergeProps)
			{
				listConf.subSignals[id] = {
					...listConf.subSignals[id],
					...signal
				}
			}
			else
				listConf.subSignals[id] = signal
		},

		/**
		 * Update table configuration object (based on changes it's properties)
		 * @param {object} listConf The list configuration
		 */
		updateConfig(listConf)
		{
			if (listConf.config.viewManagement === qEnums.tableViewManagementModes.persistOne)
				this.onTableListSaveView(listConf, { name: '_', isSelected: true })
			else if (listConf.config.viewManagement === qEnums.tableViewManagementModes.persistMany
				|| listConf.config.viewManagement === qEnums.tableViewManagementModes.nonPersistent)
				listConf.confirmChanges = true

			listFunctions.updateConfigOptions(listConf)
		},

		/**
		 * Get view (user table configuration) from table data
		 * @param {object} listConf The list configuration
		 */
		getTableListView(listConf)
		{
			const config = {}

			// BEGIN: Create config object
			// BEGIN: Column order and visibility
			if (!_isEmpty(listConf.columnsCustom))
			{
				let columnOrder = []
				let column = {}

				for (let idx in listConf.columnsCustom)
				{
					column = listConf.columnsCustom[idx]
					columnOrder.push({
						name: column.formField,
						order: column.position,
						visibility: column.visibility
					})
				}

				config.columnOrder = JSON.stringify(columnOrder)
			}
			// END: Column order and visibility

			// BEGIN: Advanced filters
			if (!_isEmpty(listConf.advancedFilters))
			{
				let advancedFilters = cloneDeep(listConf.advancedFilters)
				listFunctions.filtersToServerFormat(advancedFilters, listConf.columns)
				config.advancedFilters = JSON.stringify(advancedFilters)
			}
			// END: Advanced filters

			// BEGIN: Column filters
			if (!_isEmpty(listConf.columnFilters))
			{
				let columnFilters = cloneDeep(listConf.columnFilters)
				listFunctions.filtersToServerFormat(columnFilters, listConf.columns)
				config.columnFilters = JSON.stringify(columnFilters)
			}
			// END: Column filters

			// BEGIN: Static filters
			if (!_isEmpty(listConf.groupFilters))
			{
				// Create hashtable of filters by id and value
				let groupFilterValues = {}
				for(let idx in listConf.groupFilters)
				{
					let groupFilter = listConf.groupFilters[idx]
					groupFilterValues[groupFilter.id] = groupFilter.value
				}
				// Store in configuration
				config.groupFilterValues = JSON.stringify(groupFilterValues)
			}
			// END: Static filters

			// BEGIN: Default search column
			if (listConf.config.defaultSearchColumnName)
				config.defaultSearchColumn = JSON.stringify(listConf.config.defaultSearchColumnName)
			// END: Default search column

			// BEGIN: Initial sort
			if (listConf.config.initialSortColumnName && listConf.config.initialSortColumnOrder)
			{
				config.initialSortColumn = JSON.stringify({
					columnName: listConf.config.initialSortColumnName,
					sortOrder: listConf.config.initialSortColumnOrder
				})
			}
			// END: Initial sort

			// BEGIN: Column sizes
			if (!_isEmpty(listConf.config.columnSizes))
				config.columnSizes = JSON.stringify(listConf.config.columnSizes)
			// END: Column sizes

			// BEGIN: Line break
			if (listConf.config.hasTextWrap !== undefined && listConf.config.hasTextWrap !== null)
				config.hasTextWrap = JSON.stringify(listConf.config.hasTextWrap)
			// END: Line break

			// BEGIN: Rows per page
			if (listConf.config.perPage !== undefined && listConf.config.perPage !== null)
				config.perPage = JSON.stringify(unref(toRaw(listConf.config.perPage)))
			// END: Rows per page

			// END: Create config object

			return config
		},

		/**
		 * Save view (user table configuration)
		 * @param {object} listConf The list configuration
		 * @param {object} eObj
		 */
		onTableListSaveView(listConf, eObj)
		{
			if (_isEmpty(eObj.name))
				return

			if (typeof eObj.isSelected !== 'boolean')
				eObj.isSelected = false

			const config = this.getTableListView(listConf)

			const params = {
				uuid: listConf.uuid,
				configName: eObj.name,
				isSelected: eObj.isSelected,
				data: JSON.stringify(config)
			}

			// Send request to save configuration
			netAPI.postData('Tblcfg', 'SaveConfig', params, () => {
				// Clear view name array if there are no views
				if (_isEmpty(listConf.config.UserTableConfigNames))
					listConf.config.UserTableConfigNames = []

				// Add view name to list of available views
				if (!listConf.config.UserTableConfigNames.includes(eObj.name))
					listConf.config.UserTableConfigNames.push(eObj.name)

				// Set default view
				if (eObj.isSelected)
					listConf.config.UserTableConfigNameDefault = eObj.name

				// Set opened view name to this view
				listConf.config.UserTableConfigName = eObj.name

				// Reset property for whether there are changes
				listConf.confirmChanges = false
			}, undefined, undefined, this.navigationId)
		},

		/**
		 * Select view (user table configuration)
		 * @param {object} listConf The list configuration
		 * @param {object} eObj
		 */
		onTableListSelectView(listConf, eObj)
		{
			const params = {
				uuid: listConf.uuid,
				configName: eObj.name
			}

			// BEGIN: Send request to save configuration
			netAPI.postData('Tblcfg', 'SelectConfig', params, () => {
				if (eObj.name && eObj.name !== '')
				{
					listConf.loadDefaultView = true
					// Reload table
					this.fetchListData(listConf)
				}
				else
					this.onTableListCloseView(listConf, eObj)
			}, undefined, undefined, this.navigationId)
		},

		/**
		 * Table view action (user table configuration)
		 * @param {object} listConf The list configuration
		 * @param {object} eObj
		 */
		onTableListViewAction(listConf, eObj)
		{
			const tableViewFun = {
				'SHOW': this.onTableListOpenView,
				'DUPLICATE': this.onTableListCopyView,
				'DELETE': this.onTableListDeleteView
			}

			if (tableViewFun[eObj.name] === undefined || tableViewFun[eObj.name] === null)
				return

			tableViewFun[eObj.name](listConf, eObj)
		},

		/**
		 * Open a table view (user table configuration)
		 * @param {object} listConf The list configuration
		 * @param {object} eObj
		 */
		onTableListOpenView(listConf, eObj)
		{
			const params = {
				uuid: listConf.uuid,
				configName: eObj.rowValue
			}

			// Send request to save configuration
			netAPI.postData('Tblcfg', 'GetConfig', params, (data) => {
				// Clear unsaved configuration changes
				this.removeParamValue({ navigationId: this.navigationId, key: `CurrentTableConfig_${listConf?.config?.name}` })
				// Set properties for loading view
				listConf.config.UserTableConfigString = data.Config
				listConf.config.UserTableConfigName = data.ConfigName
				listConf.loadView = true
				// Reset property for whether there are changes
				listConf.confirmChanges = false
				// Reload table
				this.fetchListData(listConf, { queryParams: { UserTableConfigName: data.ConfigName } })
			}, undefined, undefined, this.navigationId)
		},

		/**
		 * Open a table view (user table configuration)
		 * @param {object} listConf The list configuration
		 * @param {object} eObj
		 */
		onTableListCopyView(listConf, eObj)
		{
			const params = {
				uuid: listConf.uuid,
				configName: eObj.name,
				isSelected: eObj.isSelected,
				copyFromName: eObj.copyFromName
			}

			// Send request to save configuration
			netAPI.postData('Tblcfg', 'CopyConfig', params, (data) => {
				if (data.LoadDefaultView)
					listConf.loadDefaultView = true

				// Reload table
				this.fetchListData(listConf)
			}, undefined, undefined, this.navigationId)
		},

		/**
		 * Open a table view (user table configuration)
		 * @param {object} listConf The list configuration
		 * @param {object} eObj
		 */
		onTableListDeleteView(listConf, eObj)
		{
			const params = {
				uuid: listConf.uuid,
				configName: eObj.rowValue
			}

			// Send request to save configuration
			netAPI.postData('Tblcfg', 'DeleteConfig', params, (data) => {
				// If view was default view
				if (data.DeletedDefaultView)
				{
					// Clear view configuration
					listFunctions.applyTableView(listConf, {})
					listConf.config.UserTableConfigName = null
					// Reload table
					this.fetchListData(listConf)
				}
				// If view was opened but not the default view
				else if (eObj.rowValue === listConf.config.UserTableConfigName)
				{
					listConf.loadDefaultView = true
					// Reload table
					this.fetchListData(listConf)
				}
				// If view was not opened
				else
				{
					const idx = listConf.config.UserTableConfigNames.findIndex((x) => x === eObj.rowValue)
					listConf.config.UserTableConfigNames.splice(idx, 1)
				}
			}, undefined, undefined, this.navigationId)
		},

		/**
		 * Close a table view (user table configuration)
		 * @param {object} listConf The list configuration
		 */
		onTableListCloseView(listConf)
		{
			// Clear view configuration
			listFunctions.applyTableView(listConf, {})
			listConf.config.UserTableConfigName = null
			this.setEntryValue({ navigationId: this.navigationId, key: 'LoadBaseTable', value: true })
			// Reset property for whether there are changes
			listConf.confirmChanges = false
			// Reload table
			this.fetchListData(listConf)
		},

		/**
		 * Export table data to file
		 * @param {object} listConf The list configuration
		 * @param {object} eObj
		 * @param {boolean} template (false: download data file, true: download template file)
		 * @returns A promise with the response from the server.
		 */
		onTableListExportData(listConf, eObj, template)
		{
			var params = {},
				paramNameList = 'ExportList',
				paramNameType = 'ExportType'

			// Change parameter names when downloading template file
			if (template !== false)
			{
				paramNameList = 'ImportList',
				paramNameType = 'ImportType'
			}

			Reflect.set(params, paramNameList, 'true')
			Reflect.set(params, paramNameType, eObj.format)

			return netAPI.postData(listConf.controller, listConf.action, { queryParams: params }, (data) => {
				// Make call to download file using the response URL
				netAPI.postData(data.controller, data.action, {
					id: data.id,
					type: eObj.format
				}, (_, request) => {
					netAPI.forceDownload(request.data, data.id)
				},
				() => {},
				{ responseType: 'arraybuffer' },
				this.navigationId)
			},
			() => {},
			{ params },
			this.navigationId)
		},

		/**
		 * Import table data from file
		 * @param {object} listConf The list configuration
		 * @param {object} eObj
		 * @returns A promise with the response from the server.
		 */
		onTableListImportData(listConf, eObj)
		{
			var params = {}

			Reflect.set(params, 'importType', eObj.format)
			Reflect.set(params, 'qqfile', eObj.fileName)

			let formData = new FormData()
			formData.append('file', eObj.file)

			return netAPI.postData(listConf.controller, `${listConf.action}_UploadFile`, formData, (data) => {
				listConf.dataImportResponse = data
			},
			() => {},
			{ params, headers: { 'Content-Type': 'multipart/form-data' } },
			this.navigationId)
		},

		/**
		 *
		 * @param {object} listConf The list configuration
		 * @param {object} eObj
		 */
		onTableListApplyColumnConfig(listConf, eObj)
		{
			var columnsOrdered = []
			var columnCfg = {}

			// Column order and visibility
			if (eObj.columnOrder !== undefined && eObj.columnOrder !== null)
			{
				// Iterate column configuration data
				for (let idxCfg in eObj.columnOrder)
				{
					columnCfg = eObj.columnOrder[idxCfg]

					// Find column, set properties and add to ordered columns array
					let idx = listConf.columns.findIndex((x) => x.name === columnCfg.Fields.formField)
					if (idx > -1)
					{
						let currentColumn = cloneDeep(listConf.columns[idx])
						currentColumn.formField = columnCfg.Fields.formField
						currentColumn.position = columnCfg.Fields.order
						currentColumn.visibility = columnCfg.Fields.visibility

						columnsOrdered.push(currentColumn)
					}
				}

				// Set columns to columns configured by user
				listConf.columnsCustom = columnsOrdered
				listConf.config.hasCustomColumns = true
			}

			// Default search column
			if (eObj.defaultSearchColumn !== undefined && eObj.defaultSearchColumn !== null)
				listConf.config.defaultSearchColumnName = eObj.defaultSearchColumn
		},

		/**
		 * Reset column configuration
		 * @param {object} listConf The list configuration
		 */
		onTableListResetColumnConfig(listConf)
		{
			listConf.columnsCustom = []
			listConf.config.defaultSearchColumnName = listConf.config.defaultSearchColumnNameOriginal
		},

		/**
		 * Reset column sizes
		 * @param {object} listConf The list configuration
		 */
		onTableListResetColumnSizes(listConf)
		{
			listConf.signal = { resetColumnSizes: true }
		},

		/**
		 * Update the value of the id of the active view mode.
		 * @param {object} listConf The list configuration
		 * @param {object} id The id of the active view mode
		 */
		updateActiveViewMode(listConf, id)
		{
			listConf.activeViewModeId = id
		},

		/**
		 * Add row to array of dirty rows
		 * @param {object} listConf The list configuration
		 * @param {object} eObj
		 * @param {boolean} isDirty
		 * @returns Boolean
		 */
		onRowDirty(listConf, eObj, isDirty)
		{
			if (isDirty)
				listConf.rowsDirty[eObj] = true
			else
				delete listConf.rowsDirty[eObj]
		},

		/**
		 * Remove row from array of rows
		 * @param rows {Object}
		 * @param rowKey {Object}
		 * @returns
		 */
		onRemoveRow(rows, rowKey)
		{
			var rowIdx = rows.findIndex((elem) => elem.rowKey === rowKey)
			rows.splice(rowIdx, 1)
		},

		/**
		 * Signal that something just happened to a row.
		 * Depends on table configuration.
		 * @param {object} listConf The list configuration
		 * @param {object} eObj
		 * @returns Boolean
		 */
		onGoToRow(listConf, eObj)
		{
			// If single row selection is enabled, select the row
			if (listConf.config.rowClickActionInternal === 'selectSingle')
				this.onSelectRow(listConf, { rowKeyPath: eObj })
			else
			{
				let row = listFunctions.getRowByKeyPath(listConf.rows, eObj)

				if(row)
				{
					row.isHighlighted = true
					setTimeout(() => delete row.isHighlighted, 1500)
				}
			}
		},

		/**
		 * Selects a row in a list - including a dirtiness check for extended support forms.
		 * @param {object} listConf - The list configuration
		 * @param {object} eventData - Information for the selection - the row ID (rowKeyPath) and the selection type (single or multiple)
		 */
		onSelectRow(listConf, eventData) 
		{
			let rowIdStr = eventData.rowKeyPath.toString()

			// extended support forms - row selection
			if (listConf.vueContext.internalEvents) {
				let row = listFunctions.getRowByKeyPath(listConf.rows, eventData.rowKeyPath)

				if (row) {
					this.checkDirtyRows(listConf, (confirmation) => {
						if (confirmation) {
							// if we select a different record, the changes made to the previous will be lost - clean dirty rows array
							Object.keys(listConf.rowsDirty).forEach(key => { delete listConf.rowsDirty[key] })

							if(!_isEmpty(listConf.rowsSelected))
								this.onUnselectAllRows(listConf)

							// perform row selection
							this.setListReturnControl(listConf, row)
							this.executeRowSelection(listConf, rowIdStr)

							// update form
							listConf.vueContext.internalEvents.emit('on-table-row-selected', { tableId: listConf.id, row })
						}
					})
				}
			}
			else {
				if (!eventData.multipleSelection && !_isEmpty(listConf.rowsSelected))
					this.onUnselectAllRows(listConf)

				// perform row selection
				this.executeRowSelection(listConf, rowIdStr)
			}
		},

		/**
		 * Performs the row selection (auxiliar function to onSelectRow handler)
		 * @param {object} listConf The list configuration
		 * @param {object} rowID The ID of the row to select
		 */
		executeRowSelection(listConf, rowID)
		{
			// Set row ID in hashtable of selected rows
			listConf.rowsSelected[rowID] = true

			this.setEntryValue({
				navigationId: this.navigationId,
				key: `TableListControl_${listConf.id}`,
				value: rowID
			})

			// Remove properties for selecting the row that was previously selected because of doing an action on it
			listConf.config.rowKeyToScroll = ''
		},

		/**
		 * Checks if the list has dirty rows, if so asks the user if it should to proceed with the record change.
		 * @param {object} listConf The list configuration
		 * @param {function} next - the callback function
		 */
		checkDirtyRows(listConf, next) {
			if (typeof next !== 'function')
				return

			if (!_isEmpty(listConf.rowsDirty)) {
				const buttons = {
					confirm: {
						label: this.Resources[hardcodedTexts.confirm],
						action: () => {
							genericFunctions.setNavigationState(false)
							next(true)
						}
					},
					cancel: {
						label: this.Resources[hardcodedTexts.cancel],
						action: () => next(false)
					}
				}

				genericFunctions.displayMessage(this.Resources[hardcodedTexts.isDirtyMessage], 'warning', null, buttons)
			}
			else {
				genericFunctions.setNavigationState(false)
				next(true)
			}
		},
		
		/**
		 * Remove row from array of selected rows
		 * @param {object} listConf The list configuration
		 * @param {object} eObj
		 * @returns Boolean
		 */
		onUnselectRow(listConf, eObj)
		{
			delete listConf.rowsSelected[eObj]
		},

		/**
		 * Add row to array of selected rows
		 * @param {object} listConf The list configuration
		 * @param {object} eObj
		 * @returns Boolean
		 */
		onSelectRows(listConf, eObj)
		{
			for (let rowKey in eObj)
				listConf.rowsSelected[rowKey] = true
		},

		/**
		 * Remove rows from array of selected rows
		 * @param {object} listConf The list configuration
		 * @param {object} eObj
		 * @returns Boolean
		 */
		onUnselectRows(listConf, eObj)
		{
			for (let rowKey in eObj)
				delete listConf.rowsSelected[rowKey]
		},

		/**
		 * Remove all rows from array of selected rows
		 * @param {object} listConf The list configuration
		 * @returns Boolean
		 */
		onUnselectAllRows(listConf)
		{
			for (let rowKey in listConf.rowsSelected)
				delete listConf.rowsSelected[rowKey]
		},

		/**
		 * Convert hashtable of row IDs to array of row IDs
		 * @param {object} rowKeyHashTable
		 * @returns Boolean
		 */
		rowKeyHashTableToArray(rowKeyHashTable)
		{
			return Object.keys(rowKeyHashTable)
		},

		/**
		 * Convert hashtable of row IDs to array of row IDs
		 * @param {object} rowKeyArray
		 * @returns Boolean
		 */
		rowKeyArrayToHashTable(rowKeyArray)
		{
			var rowKeyHashTable = {}

			for (let idx = 0; idx < rowKeyArray.length; idx++)
				rowKeyHashTable[rowKeyArray[idx]] = true

			return rowKeyHashTable
		},

		/**
		 * Row add
		 * @param {object} listConf The list configuration
		 * @param {object} eObj Row object
		 */
		onTableListRowAdd(listConf, eObj)
		{
			var params = {}

			Reflect.set(params, 'partialView', '')
			Reflect.set(params, 'InsertMode', 'true')
			Reflect.set(params, 'Expose', listConf.config.name)

			for (let key in eObj.Fields)
				Reflect.set(params, key, eObj.Fields[key])

			return netAPI.postData(listConf.config.tableAlias, listConf.action + 'Form_New', params, () => {
				// Reload table
				this.fetchListData(listConf)
			},
			() => {},
			{ params },
			this.navigationId)
		},

		/**
		 * Row edit
		 * @param {object} listConf The list configuration
		 * @param {object} eObj Row object
		 */
		onTableListRowEdit(listConf, eObj)
		{
			var params = {}

			Reflect.set(params, 'partialView', '')
			Reflect.set(params, 'InsertMode', 'false')
			Reflect.set(params, 'Expose', listConf.config.name)

			for (let key in eObj.Fields)
				Reflect.set(params, key, eObj.Fields[key])

			return netAPI.postData(listConf.config.tableAlias, listConf.action + 'Form_Edit', params, () => {

			},
			() => {},
			{ params },
			this.navigationId)
		},

		/**
		 * Rows delete
		 * @param {object} listConf The list configuration
		 * @param {object} eObj Hashtable of row primary keys
		 */
		onTableListRowsDelete(listConf, eObj)
		{
			var params = {}

			Reflect.set(params, 'partialView', '')
			Reflect.set(params, 'InsertMode', 'false')
			Reflect.set(params, 'Expose', listConf.config.name)

			var rowKeys = Object.keys(eObj)

			Reflect.set(params, 'rowKeys', rowKeys)

			return netAPI.postData(listConf.config.tableAlias, listConf.action + 'Form_Delete_Rows', params, () => {
				// Reload table
				this.fetchListData(listConf)
			},
			() => {},
			{ params },
			this.navigationId)
		},

		/**
		 * Get ordering column of table
		 * @param {object} listConf The list configuration
		 */
		getOrderingColumn(listConf)
		{
			for (let idx in listConf.columns)
			{
				let column = listConf.columns[idx]
				if (column.isOrderingColumn !== undefined && column.isOrderingColumn !== false)
					return column
			}

			return null
		},

		/**
		 * Toggle drag and drop mode
		 * @param {object} listConf The list configuration
		 */
		onToggleRowsDragDrop(listConf)
		{
			listConf.config.hasRowDragAndDrop = !listConf.config.hasRowDragAndDrop

			var sortOrderColumn = this.getOrderingColumn(listConf)
			if (listConf.config.hasRowDragAndDrop && sortOrderColumn)
			{
				sortOrderColumn.component = 'q-edit-numeric'
				sortOrderColumn.componentOptions = {}
			}
			else
				sortOrderColumn.component = undefined
		},

		/**
		 * Row reorder
		 * @param {object} listConf The list configuration
		 * @param {object} eObj
		 */
		onTableListRowReorder(listConf, eObj)
		{
			const params = {
				id: eObj.rowKey,
				position: eObj.index
			}

			return netAPI.postData(listConf.controller, `Reorder${listConf.action}`, params, (data) => {
				listConf.hydrate(listConf, data)
				listConf.isLoaded = true
			},
			() => {},
			{ params },
			this.navigationId)
		},

		/**
		 * Run group action on selected rows
		 * @param {object} listConf The list configuration
		 * @param {object} eObj
		 */
		onTableListRowGroupAction(listConf, eObj)
		{
			let params = {}

			//Set selected ids
			Reflect.set(params, 'ids', Object.keys(eObj.rowsSelected))

			//Set all selected param
			params.allSelected = eObj.allSelected === 'true' || eObj.allSelected === true

			//Add list filters
			params.queryParams = this.formatListParameters(listConf, eObj.queryParams).queryParams;

			switch (eObj.action.params.type)
			{
				case 'menu':
					return netAPI.postData(listConf.controller, `${listConf.action}_Selections`, params, () => {
						// Go to follow-up menu list
						this.$router.push({ name: eObj.action.name })
					},
					() => {},
					{ params },
					this.navigationId)
				case 'form':
					return netAPI.postData(listConf.controller, `${listConf.action}_Selections`, params, () => {
						// Go to follow-up form
						if (params.ids.length > 0)
						{
							let routeOptions = {}
							if (Number.isInteger(eObj.action.params.goBack))
								Reflect.set(routeOptions, 'goBack', eObj.action.params.goBack)
							this.navigateToForm(eObj.action.params.formName, eObj.action.params.mode, params.ids[0], routeOptions)
						}
					},
					() => {},
					{ params },
					this.navigationId)
				case 'routine':
					// Call routine
					eObj.action.params.actionRoutine(params)
					break
				case 'qsign':
					eObj.action.params.actionRoutine(params)
					break
				case 'report':
					return netAPI.postData(listConf.controller, `${listConf.action}_Selections`, params, () => {
						// Go to follow-up report
						this.navigateToReport(eObj.action.params.baseArea, eObj.action.name, { allSelected: params.allSelected })
					},
					() => {},
					{ params },
					this.navigationId)
				default:
					if (typeof eObj.action.params.action === 'function')
						eObj.action.params.action(params)
					break
			}
		},

		/**
		 * Get new record data
		 * @param {object} listConf The list configuration
		 * @param {object} eObj Row object
		 */
		onTableListInsertRow(listConf, eObj)
		{
			var controller = listConf.config.tableAlias
			var action = listConf.action + '_New'

			if (eObj.controller)
				controller = eObj.controller
			if (eObj.action)
				action = eObj.action

			return netAPI.postData(controller, action, null, (data) => {
				if (data.QPrimaryKey !== undefined && data.QPrimaryKey !== null)
					listConf.newRowID = data.QPrimaryKey
			},
			() => {},
			{},
			this.navigationId)
		},

		/**
		 * Called when saving a new record
		 * @param {object} listConf The list configuration
		 */
		onTableListInsertForm(listConf)
		{
			listConf.newRowID = ''
		},

		/**
		 * Get new record data
		 * @param {object} listConf The list configuration
		 * @param {object} eObj Row object
		 */
		onTableListCancelInsertRow(listConf, eObj)
		{
			var controller = listConf.config.tableAlias
			var action = null
			var addAction = _find(listConf.config.generalActions, (act) => act.id === 'insert')
			action = `MF${addAction.params.formName}_Cancel`

			if (eObj.controller)
				controller = eObj.controller
			if (eObj.action)
				action = eObj.action

			return netAPI.postData(controller, action, { id: listConf.newRowID }, (data) => {
				if (data.Success)
					listConf.newRowID = ''
			},
			() => {},
			{},
			this.navigationId)
		},

		/**
		 * Sets the row to highlight when the user returns to the list
		 * @param {object} listConf The list configuration
		 * @param {object} row The row
		 */
		setListReturnControl(listConf, row)
		{
			if (listConf.type === 'TreeList')
			{
				this.setCurrentControl({
					navigationId: this.navigationId,
					controlData: {
						id: listConf.id,
						data: {
							rowKey: listConf.config.rowKeyToScroll
						}
					}
				})
			}
			else
			{
				this.setCurrentControl({
					navigationId: this.navigationId,
					controlData: {
						id: listConf.id,
						data: {
							rowKey: row?.rowKey,
							page: listConf.config.page,
							recordNumber: listConf.config.perPage,
							searchFilters: this.getSearchFilters(listConf, row),
							globalSearch: listConf.globalSearch || ''
						}
					}
				})
			}
		},

		/**
		 *
		 * @param {object} listConf The list configuration
		 * @param {object} eObj
		 */
		async onTableListExecuteAction(listConf, eObj)
		{
			// Download file
			if (!_isEmpty(eObj) && eObj.action === 'download' && eObj.ticket && eObj.fileName)
			{
				const params = {
					ticket: eObj.ticket,
					viewType: eObj.viewType
				}

				const newTab = eObj.viewType === qEnums.documentViewTypeMode.preview

				return netAPI.postData(listConf.config.tableAlias, 'GetFile', params, (_, request) => {
					const fileType = request.headers.get('Content-Type')
					const fielName = request.headers.get('filename')
					netAPI.forceDownload(request.data, fielName, fileType, newTab)
				},
				() => {},
				{ responseType: 'arraybuffer' },
				this.navigationId)
			}

			// Insert in multiforms
			if (listConf.type === 'Multiform' && eObj.name === 'insert')
			{
				const addAction = _find(listConf.config.generalActions, (act) => act.id === 'insert')
				eObj.controller = listConf.config.tableAlias
				eObj.action = `${addAction.params.formName}_NEW_GET`
				this.onTableListInsertRow(listConf, eObj)
				return
			}

			let actionCfg = null
			let actionId = null

			// If custom action is already given
			if (eObj.action)
			{
				actionCfg = eObj.action
				actionId = eObj.action.id
			}
			else
				actionId = eObj.id

			// If the action is not defined, do nothing
			if (!actionId)
				return

			// Find the action by it's id
			// CRUD
			if (!actionCfg)
				actionCfg = _find(listConf.config.crudActions, (act) => act.id === actionId)
			if (!actionCfg)
				actionCfg = _find(listConf.config.generalActions, (act) => act.id === actionId)
			// Custom action
			if (!actionCfg)
				actionCfg = _find(listConf.config.customActions, (act) => act.id === actionId)
			// Row click action
			if (!actionCfg && listConf.config.rowClickAction && listConf.config.rowClickAction.id === actionId)
				actionCfg = listConf.config.rowClickAction
			// General custom action
			if (!actionCfg)
				actionCfg = _find(listConf.config.generalCustomActions, (act) => act.id === actionId)

			if (!actionCfg || !actionCfg.params || typeof actionCfg.params.action !== 'function')
				return

			// Get row key and row key path
			let rowKey
			let rowKeyPath
			if(eObj.rowKeyPath && Array.isArray(eObj.rowKeyPath))
			{
				rowKey = eObj.rowKeyPath[eObj.rowKeyPath.length - 1]
				rowKeyPath = eObj.rowKeyPath
			}
			else if(eObj.rowKey)
			{
				rowKey = eObj.rowKey
				rowKeyPath = [eObj.rowKey]
			}

			// Find row by row key path
			let row = listFunctions.getRowByKeyPath(listConf.rows, rowKeyPath),
				historyEntries = []

			if (listConf.type !== 'TreeList')
			{
				historyEntries.push({
					key: (listConf.config.tableAlias || '').toLowerCase(),
					value: rowKey
				})
			}

			let crudAction = _find(listConf.config.crudActions, (act) => act.id === actionId)
			let insertAction = _find(listConf.config.generalActions, (act) => act.id === actionId && act.id === 'insert')
			if (crudAction || insertAction)
			{
				this.setParamValue({
					navigationId: this.navigationId,
					key: `CurrentTableConfig_${listConf.config.name}`,
					value: JSON.stringify(this.getTableListView(listConf))
				})
			}

			if (listConf.type === 'TreeList')
			{
				// Set the right tableAlias in the navigation entry
				if (!_isEmpty(row?.Area))
				{
					_foreach(_get(listConf.config.treeListDefinitions, row.Area, []), (branchAreaKey, branchArea) => {
						historyEntries.push({
							key: branchArea,
							value: branchAreaKey(row)
						})
					})
				}

				// It's needed to know if it's a CRUD action, because the action form name must be filled with the value from the "row"
				if (crudAction)
					actionCfg.params.formName = row.Form

				// Shows correct form to open when inserting a record
				if (insertAction)
					actionCfg.params.formName = listConf.getInsertFormName(row)

				// FOR: tree table select row on return
				// Tree tables: store path of row keys
				if (row === undefined || row === null)
					listConf.config.rowKeyToScroll = []
				else
					listConf.config.rowKeyToScroll = rowKeyPath
			}

			this.setListReturnControl(listConf, row)
			this.setParamValue({
				navigationId: this.navigationId,
				key: 'anchor',
				value: listConf.id
			})

			// Set the name of the configuration to use when returning from a form
			this.setParamValue({ navigationId: this.navigationId, key: 'UserTableConfigName', value: listConf?.config?.UserTableConfigName })

			// If the before execute function is defined, execute it and check if we can perform the action on the list.
			if(typeof actionCfg.params.canExecuteAction === 'function')
			{
				const canContinueExecution = await actionCfg.params.canExecuteAction()
				if(!canContinueExecution) return
			}

			actionCfg.params.action(listConf, actionCfg, row, historyEntries)
		},

		/**
		 *
		 * @param {object} listConf The list configuration
		 * @param {object} eObj
		 */
		onTableListCellAction(listConf, eObj)
		{
			if (!_isEmpty(eObj) && !_isEmpty(eObj.column) && !_isEmpty(eObj.column.params) && eObj.column.params.type === 'form')
				this.openFormAction(listConf, eObj.column, eObj.row)
		},

		/**
		 *
		 * @param {object} listConf The list configuration
		 * @param {object} eObj
		 */
		onTableListUpdateCell(listConf, eObj)
		{
			if (listConf.config.hasRowDragAndDrop)
			{
				let pObj = {
					rowKey: eObj.row.rowKey,
					index: parseInt(eObj.value || 0) - 1
				}
				this.onTableListRowReorder(listConf, pObj)
			}
		},

		/**
		 * Execute action from 'MC' menu
		 * @param {object} listConf The list configuration
		 * @param {object} actionName
		 * @param {object}
		 */
		tableListMCAction(listConf, actionName, id)
		{
			const actionMC = _find(listConf.config.MCActions, (act) => act.name === actionName)
			const row = _find(listConf.rows, (rw) => rw.rowKey === id)

			if (actionMC && row)
				actionMC.params.action(listConf, actionMC, row)
		},

		/**
		 * Navigates to a form.
		 * @param {object} listConf The list configuration
		 * @param {object} actionCfg Action configuration
		 * @param {object} row The row data object
		 * @param {array} historyEntries The History entries to be applied at the next level
		 */
		openFormAction(listConf, actionCfg, row, historyEntries)
		{
			if (actionCfg.params.type !== 'form')
				return

			// Whether or not the current context is a form.
			let isForm = typeof this.formInfo === 'object' && typeof this.isEditable === 'boolean'

			let formModes = ''
			if (listConf.config.permissions.canView && btnHasPermission(row?.btnPermission, qEnums.formModes.show))
				formModes += 'v'
			if (!isForm || this.isEditable)
			{
				if (listConf.config.permissions.canEdit && btnHasPermission(row?.btnPermission, qEnums.formModes.edit))
					formModes += 'e'
				if (listConf.config.permissions.canDuplicate && btnHasPermission(row?.btnPermission, qEnums.formModes.duplicate))
					formModes += 'd'
				if (listConf.config.permissions.canDelete && btnHasPermission(row?.btnPermission, qEnums.formModes.delete))
					formModes += 'a'
				if (listConf.config.permissions.canInsert && btnHasPermission(row?.btnPermission, qEnums.formModes.new))
					formModes += 'i'
			}

			let formName = actionCfg.params.formName,
				mode = actionCfg.params.mode,
				id = null,
				formDef = listConf.config.formsDefinition[formName],
				options = {
					isPopup: formDef.isPopup,
					repeatInsert: actionCfg.params.repeatInsertion,
					isDuplicate: false,
					modes: formModes
				},
				query = {},
				prefillValues = actionCfg.params.prefillValues || {}

			// Apply history limits that cannot be applied at the form level.
			// (See description in the formHandlers prop)
			if (Array.isArray(historyEntries))
				Reflect.set(options, 'historyEntries', JSON.stringify(historyEntries))

			// GoBack pattern (menus)
			if (Number.isInteger(actionCfg.params.goBack))
				Reflect.set(options, 'goBack', actionCfg.params.goBack)

			// Controlled change for other route. e.g: Support form
			if (actionCfg.params.isControlled)
				Reflect.set(options, 'isControlled', true)

			// Other options
			if (actionCfg.params.otherOptions)
			{
				for (let prop in actionCfg.params.otherOptions)
					if (Object.prototype.hasOwnProperty.call(actionCfg.params.otherOptions, prop))
						Reflect.set(options, prop, actionCfg.params.otherOptions[prop])
			}

			let tableName = listConf.controller[0] + listConf.controller.substring(1).toLowerCase()
			let tableViewModelName = listConf.action + '_ViewModel'
			this.setEntryValue({ navigationId: this.navigationId, key: 'TableName', value: tableName })
			this.setEntryValue({ navigationId: this.navigationId, key: 'TableViewModelName', value: tableViewModelName })

			if (mode === 'DUPLICATE')
				options.isDuplicate = true

			if (mode !== 'NEW')
			{
				id = formDef.fnKeySelector(row)
				if (!_isEmpty(actionCfg.params.limits))
				{
					_foreach(actionCfg.params.limits, (limit) => {
						if (limit.identifier === 'id')
							id = limit.fnValueSelector(row.Fields)
						else
							Reflect.set(options, limit.identifier, limit.fnValueSelector(row.Fields))
					})
				}
			}
			else
				options.isControlled = true

			this.navigateToForm(formName, mode, id, options, query, prefillValues)
		},

		/**
		 * Navigates to a menu.
		 * @param {object} _ The list configuration
		 * @param {object} actionCfg Action configuration
		 * @param {object} row The row data object
		 */
		openMenuAction(_, actionCfg, row)
		{
			if (actionCfg.params.type !== 'menu')
				return

			var params = {}

			if (!_isEmpty(actionCfg.params.limits))
			{
				_foreach(actionCfg.params.limits, (limit) => {
					let limitValue = limit.fnValueSelector(row.Fields)
					Reflect.set(params, limit.identifier, limitValue)
					this.setEntryValue({ navigationId: this.navigationId, key: limit.identifier, value: limitValue })
				})
			}

			this.navigateToRouteName(`menu-${actionCfg.params.menuName}`, params)
		},

		/**
		 *
		 * @param {*} _
		 * @param {*} actionCfg
		 * @param {*} row
		 */
		openReportAction(_, actionCfg, row)
		{
			if (actionCfg.params.type !== 'report' && actionCfg.params.type !== 'ssrsViewer')
				return

			if (!_isEmpty(actionCfg.params.limits))
			{
				_foreach(actionCfg.params.limits, (limit) => {
					let limitValue = limit.fnValueSelector(row.Fields)
					Reflect.set(actionCfg.params, limit.identifier, limitValue)
					this.setEntryValue({ navigationId: this.navigationId, key: limit.identifier, value: limitValue })
				})
			}

			if (actionCfg.params.type === 'report')
				this.navigateToReport(actionCfg.params.baseArea, actionCfg.name, actionCfg.params)
			else if (actionCfg.params.type === 'ssrsViewer')
				this.navigateToReportingServicesViewer(actionCfg.params.baseArea, actionCfg.name, actionCfg.params)
		},

		/**
		 *
		 * @param {*} _
		 * @param {*} actionCfg
		 * @param {*} row
		 */
		openRoutineAction(_, actionCfg, row)
		{
			if (actionCfg.params.type !== 'routine')
				return

			let params = {}

			if (!_isEmpty(actionCfg.params.limits))
			{
				_foreach(actionCfg.params.limits, (limit) => {
					params[limit.identifier] = limit.fnValueSelector(row.Fields)
				})
			}

			if (actionCfg.params.actionRoutine)
				actionCfg.params.actionRoutine(params)
		},

		/**
		 *
		 * @param {*} _
		 * @param {*} actionCfg
		 * @param {*} row
		 */
		openQSignAction(_, actionCfg, row)
		{
			if (actionCfg.params.type !== 'qsign')
				return

			let params = {
				id: _get(row, 'rowKey', null)
			}

			if (!_isEmpty(actionCfg.params.limits))
			{
				_foreach(actionCfg.params.limits, (limit) => {
					params[limit.identifier] = limit.fnValueSelector(row.Fields)
				})
			}

			if (actionCfg.params.actionRoutine)
				actionCfg.params.actionRoutine(params)
		},

		/**
		 * Adds a route that indicates if all table rows are selected or not
		 * @param {*} value The value to put in the parameter value
		 */
		onSetQtableAllSelected(listConfig, value)
		{
			let allSelected = this.navigation.currentLevel.params.allSelected || []
			let queryParams = this.navigation.currentLevel.params.qTableQueryParams || {}

			if (value.isSelected) {
				if(!allSelected.includes(value.id))
					allSelected.push(value.id)

				queryParams[value.id] = this.formatListParameters(listConfig, value.queryParams);
			}
			else
			{
				/* Remove all Selected */
				const idx = allSelected.findIndex((e) => e === value.id)
				if (idx === -1)
					return // No need to continue!

				allSelected.splice(idx, 1)

				/* Remove table params */
				queryParams[value.id] = {}
			}

			this.navigation.currentLevel.params.allSelected = allSelected
			this.navigation.currentLevel.params.qTableQueryParams = queryParams
		},

		/**
		 * Adds a route that indicates if all table rows are selected or not
		 * @param {*} value The value to put in the parameter value
		 */
		onFetchQtableAllSelected(listConfig, tableId)
		{
			let allSelected = this.navigation.currentLevel.params.allSelected || []

			if (allSelected.findIndex((e) => e === tableId) !== -1)
				listConfig.allSelectedRows = 'true'
		}
	}
}
