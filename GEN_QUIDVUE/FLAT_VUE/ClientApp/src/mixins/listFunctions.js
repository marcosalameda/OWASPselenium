import { computed, reactive, shallowReactive, markRaw, ref } from 'vue'
import cloneDeep from 'lodash-es/cloneDeep'
import _find from 'lodash-es/find'
import _findIndex from 'lodash-es/findIndex'
import _forEach from 'lodash-es/forEach'
import _get from 'lodash-es/get'
import has from 'lodash-es/has'
import _isDate from 'lodash-es/isDate'
import _isEmpty from 'lodash-es/isEmpty'
import _map from 'lodash-es/map'
import _set from 'lodash-es/set'
import _toLower from 'lodash-es/toLower'
import _unionWith from 'lodash-es/unionWith'

import { tableViewManagementModes, documentViewTypeMode } from '@/mixins/quidgest.mainEnums.js'
import genericFunctions from '@/mixins/genericFunctions.js'
import searchFilterData from '@/api/genio/searchFilterData.js'

import { useSystemDataStore } from '@/stores/systemData.js'

/**
 * Hydrates the table data.
 * @param {object} listControl The list control object
 * @param {object} viewModel The list view model (C#)
 */
export function hydrateTableData(listControl, viewModel)
{
	if (typeof viewModel !== 'object' || viewModel === null)
		return

	// Glob info
	if (Reflect.has(viewModel, 'TGlob'))
		listControl.vueContext.setGlobData(viewModel.TGlob)

	let newListRows = []

	// Default search column
	let defaultSearchColumn = getDefaultSearchColumn(listControl.columns, listControl.config.defaultSearchColumnName)
	if (defaultSearchColumn)
		listControl.config.defaultSearchColumnNameOriginal = defaultSearchColumn.name

	if (listControl.config.viewManagement === tableViewManagementModes.persistOne ||
		listControl.config.viewManagement === tableViewManagementModes.persistMany ||
		!_isEmpty(viewModel.CurrentTableConfig))
	{
		// Set default table view configuration name
		if (!_isEmpty(viewModel.UserTableConfigNameDefault))
			listControl.config.UserTableConfigNameDefault = viewModel.UserTableConfigNameDefault

		// Load table's current (unsaved) configuration
		if (!_isEmpty(viewModel.CurrentTableConfig))
		{
			// If a table view was open, load it's name. This means there might be unsaved changes to that view.
			if(!_isEmpty(viewModel.UserTableConfigName))
				listControl.config.UserTableConfigName = viewModel.UserTableConfigName

			listControl.config.CurrentTableConfig = JSON.parse(viewModel.CurrentTableConfig)
			// Deserialize each sub-configuration
			for (let configType in listControl.config.CurrentTableConfig)
				listControl.config.CurrentTableConfig[configType] = JSON.parse(listControl.config.CurrentTableConfig[configType])

			// Apply current configuration to table
			applyTableView(listControl, listControl.config.CurrentTableConfig)
		}
		// Load table view configuration
		else if (listControl.loadView)
		{
			if (!_isEmpty(listControl.config.UserTableConfigString) && !_isEmpty(listControl.config.UserTableConfigName))
			{
				listControl.config.UserTableConfig = JSON.parse(listControl.config.UserTableConfigString)
				// Deserialize each sub-configuration
				for (let configType in listControl.config.UserTableConfig)
					listControl.config.UserTableConfig[configType] = JSON.parse(listControl.config.UserTableConfig[configType])

				// Apply view configuration to table
				applyTableView(listControl, listControl.config.UserTableConfig)
			}

			listControl.loadView = false
		}
		else if (listControl.loadDefaultView)
		{
			// FOR: USER_TABLE_CONFIG
			// BEGIN: User table configuration
			if (!_isEmpty(viewModel.UserTableConfigName) && !_isEmpty(viewModel.UserTableConfig))
			{
				listControl.config.UserTableConfigName = viewModel.UserTableConfigName
				listControl.config.UserTableConfig = JSON.parse(viewModel.UserTableConfig)
				// Deserialize each sub-configuration
				for (let configType in listControl.config.UserTableConfig)
					listControl.config.UserTableConfig[configType] = JSON.parse(listControl.config.UserTableConfig[configType])

				// Apply view configuration to table
				if (!_isEmpty(listControl.config.UserTableConfig))
					applyTableView(listControl, listControl.config.UserTableConfig)
			}
			// END: User table configuration

			listControl.loadDefaultView = false
		}

		updateConfigOptions(listControl)

		// List of users views (configurations)
		if (!_isEmpty(viewModel.UserTableConfigNames))
			listControl.config.UserTableConfigNames = viewModel.UserTableConfigNames
		else
			listControl.config.UserTableConfigNames = []
	}

	// Convert Advanced filters
	if (!_isEmpty(listControl.advancedFilters))
	{
		let advancedFilters = listControl.advancedFilters
		filtersToClientFormat(advancedFilters, listControl.columns)
		listControl.advancedFilters = advancedFilters
	}
	else
		listControl.advancedFilters = []

	// Convert Column filters
	if (!_isEmpty(listControl.columnFilters))
	{
		let columnFilters = listControl.columnFilters
		filtersToClientFormat(columnFilters, listControl.columns)
		listControl.columnFilters = columnFilters
	}
	else
		listControl.columnFilters = {}

	if (typeof viewModel.Table !== 'undefined')
	{
		// Row component properties
		if (listControl.rowComponent === 'q-form-container' && listControl.formName !== '')
		{
			listControl.rowFormProps = []
			listControl.type = 'Multiform'
		}

		// Rows data
		_forEach(viewModel.Table.Elements, (rowData, idx) => {
			newListRows.push(reactive(hydrateTableRow(listControl, rowData, idx)))

			// Multiform properties
			if (listControl.rowComponent === 'q-form-container' && listControl.formName !== '')
			{
				listControl.rowFormProps.push({
					historyBranchId: listControl.vueContext.navigationId,
					id: newListRows[idx].rowKey,
					component: listControl.component,
					mode: 'SHOW'
				})
			}
		})

		listControl.rows = shallowReactive(newListRows)

		// Get distinct values
		if (viewModel.Table.Distincts !== undefined)
		{
			let distinctValues = {}

			for (let column of listControl.columns ?? [])
			{
				if (viewModel.Table.Distincts[column.name])
				{
					column.distinctValues = {}
					distinctValues = viewModel.Table.Distincts[column.name]

					for (let dvIdx in distinctValues)
						column.distinctValues[distinctValues[dvIdx].value] = distinctValues[dvIdx].value
				}
			}
		}

		// Pagination
		let p = viewModel.Table.Pagination
		if (p.HasTotal)
			listControl.totalRows = p.TotalRows
		else
			listControl.totalRows = listControl.rows.length

		listControl.hasMorePages = p.HasMore
		listControl.page = p.PageNumber
		listControl.config.page = p.PageNumber
	}

	// If table is a checklist
	if (listControl.type === 'MultipleValuesList')
	{
		if (listControl.rows !== undefined && listControl.rows !== null)
		{
			listControl.modelFieldRef.hydrate(viewModel[listControl.modelField])

			// Only keep selected records
			listControl.rows = listControl.rows.filter((rowKey) => listControl.rowsSelected[rowKey.rowKey])
		}

		// New values
		if (listControl.modelFieldOptionsRef)
		{
			listControl.modelFieldOptionsRef.hydrate(viewModel[listControl.modelFieldOptions])

			_forEach(listControl.modelFieldOptionsRef.value, (rowData, rowIndex) => {
				const value = hydrateTableRow(listControl, rowData, rowIndex)

				// Check if the value is not in the list already
				if (!listControl.rows.some((obj) => obj.rowKey === value.rowKey))
					listControl.rows.push(value)
			})
		}

		// Selected rows
		if (listControl.modelFieldRef)
		{
			listControl.modelFieldRef.hydrate(viewModel[listControl.modelField])
			_forEach(listControl.modelFieldRef.value, (rowKey) => {
				listControl.rowsSelected[rowKey] = true
			})
		}
	}

	// Table limits display data
	if (typeof viewModel.tableLimitsDisplayData !== 'undefined')
		listControl.tableLimits = viewModel.tableLimitsDisplayData
}

/**
 * Apply view configuration to table
 * @param {object} listControl The list control object
 * @param {object} viewCfg The view configuration object
 */
export function applyTableView(listControl, viewCfg)
{
	// Column order and visibility
	if (!_isEmpty(viewCfg.columnOrder))
	{
		let columnsOrdered = []

		_forEach(viewCfg.columnOrder, (userColumn) => {
			let idx = _findIndex(listControl.columnsOriginal, ['name', userColumn.name])

			if (idx !== -1)
			{
				let currentColumn = cloneDeep(listControl.columnsOriginal[idx])
				currentColumn.formField = userColumn.name
				currentColumn.position = userColumn.order
				currentColumn.visibility = userColumn.visibility

				columnsOrdered.push(currentColumn)
			}
		})

		// Set columns to columns configured by user
		listControl.columnsCustom = columnsOrdered
		listControl.config.hasCustomColumns = true
	}
	else
		listControl.columnsCustom = []

	// Advanced filters
	if (!_isEmpty(viewCfg.advancedFilters))
		listControl.advancedFilters = viewCfg.advancedFilters
	else
		listControl.advancedFilters = []

	// Column filters
	if (!_isEmpty(viewCfg.columnFilters))
		listControl.columnFilters = viewCfg.columnFilters
	else
		listControl.columnFilters = {}

	// Static filters
	if (!_isEmpty(viewCfg.groupFilterValues))
	{
		for(let idx in listControl.groupFilters)
		{
			// Get reference to filter
			let groupFilter = listControl.groupFilters[idx]
			// Get filter value in saved configuration
			let groupFilterValue = viewCfg.groupFilterValues[groupFilter.id]
			if(groupFilterValue === undefined || groupFilterValue === null)
				continue
			// Set filter value if it exists in the saved configuration
			listControl.groupFilters[idx].value = groupFilterValue
			// Set selected property for each filter option
			for(let idx in groupFilter.filters)
			{
				let filter = groupFilter.filters[idx]
				if(groupFilter.value.indexOf(filter.key) > -1)
					filter.selected = true
				else
					filter.selected = false
			}
		}
	}

	// Default search column
	if (!_isEmpty(viewCfg.defaultSearchColumn))
		listControl.config.defaultSearchColumnName = viewCfg.defaultSearchColumn
	else
		listControl.config.defaultSearchColumnName = listControl.config.defaultSearchColumnNameOriginal

	// Initial sort
	if (!_isEmpty(viewCfg.initialSortColumn))
	{
		listControl.config.initialSortColumnName = viewCfg.initialSortColumn.columnName
		listControl.config.initialSortColumnOrder = viewCfg.initialSortColumn.sortOrder
	}
	else
	{
		listControl.config.initialSortColumnName = ''
		listControl.config.initialSortColumnOrder = ''
	}

	// Column sizes
	if (!_isEmpty(viewCfg.columnSizes))
		listControl.config.columnSizes = viewCfg.columnSizes
	else
		listControl.config.columnSizes = null

	// Line break
	if (viewCfg.hasTextWrap !== undefined && viewCfg.hasTextWrap !== null)
		listControl.config.hasTextWrap = viewCfg.hasTextWrap
	else
		listControl.config.hasTextWrap = false

	// Rows per page
	if (viewCfg.perPage !== undefined && viewCfg.perPage !== null)
		listControl.config.perPage = computed(() => viewCfg.perPage)
}

/**
 * Update table configuration options.
 * @param {object} listControl The timeline control object
 */
export function updateConfigOptions(listControl)
{
	let viewSaveChanges = _find(listControl.config.configOptions, ['id', 'viewSaveChanges'])
	let viewRename = _find(listControl.config.configOptions, ['id', 'viewRename'])

	if (listControl.config.UserTableConfig && !_isEmpty(listControl.config.UserTableConfig))
	{
		if (viewSaveChanges)
		{
			if (listControl.confirmChanges)
				viewSaveChanges.active = true
			else
				viewSaveChanges.active = false
		}

		if (viewRename)
			viewRename.active = true
	}
	else
	{
		if (viewSaveChanges)
			viewSaveChanges.active = false
		if (viewRename)
			viewRename.active = false
	}
}

/**
 * Hydrates the table rows.
 * @param {object} listControl The list control object
 * @param {object} rowData The row data (C#)
 * @param {int} rowIndex The row index
 * @returns The hydrated row.
 */
export function hydrateTableRow(listControl, rowData, rowIndex)
{
	// Deserialize serialized fields
	for (let idx in listControl.columns)
	{
		let column = listControl.columns[idx]
		if (column.isSerialized)
		{
			let columnData = _get(rowData, column.name, null)
			if (_isEmpty(columnData))
				rowData[column.name] = undefined
			else
				rowData[column.name] = JSON.parse(columnData)
		}
	}

	let row = {
		Rownum: rowIndex,
		Fields: rowData, // TODO: Change to use the list of used fields. GetCamposForListing / GetRequestedFieldsForDBedit
		pkField: listControl.config.pkColumn,
		get rowKey() { return !_isEmpty(listControl.config.pkColumn) ? this.Fields[this.pkField] : this.Rownum }
	}

	// Form conditions (disable buttons when the conditions are false)
	Reflect.set(row, 'btnPermission', {
		editBtnDisabled: !listControl.config.crudConditions.update(row),
		viewBtnDisabled: !listControl.config.crudConditions.view(row),
		deleteBtnDisabled: !listControl.config.crudConditions.delete(row),
		insertBtnDisabled: !listControl.config.canInsert
	})

	// The fields of the other tables have a different field identifier. TODO: Use the _get on the Table component
	_forEach(listControl.columns, (column) => Reflect.set(row.Fields, column.name, _get(rowData, column.name)))

	return row
}

/**
 * Hydrates the timeline data.
 * @param {object} timelineControl The timeline control object
 * @param {object} viewModel The list view model (C#)
 */
export function hydrateTimelineData(timelineControl, viewModel)
{
	const rows = viewModel?.Menu?.Elements
	if (!rows)
		return

	timelineControl.timeLineData.rows = rows.filter((row) => _isDate(row.Data))
	if (rows.length > 0)
		timelineControl.config.scale = rows[0].Escala
}

/**
 * Create column hierarchy
 * @param {array} columns
 */
export function getColumnHierarchy(columns)
{
	let columnHierarchy = []
	let columnGroups = {}
	let extraColumns = []
	let columnLevel = 0

	// Group columns by table
	for (let key in columns)
	{
		let column = columns[key]

		// Add columns that are not data columns to separate object instead
		if (_isEmpty(column.name) || _isEmpty(column.area) || _isEmpty(column.field))
		{
			extraColumns.push(column)
			continue
		}

		// Add column level
		if (_isEmpty(columnGroups[column.area]))
		{
			columnGroups[column.area] = {
				level: columnLevel,
				columns: []
			}
			columnLevel++
		}

		// Add column
		columnGroups[column.area].columns.push(column)
	}

	// Add column groups by level to hierarchy
	for (let key in columnGroups)
	{
		let columnGroup = columnGroups[key]

		// Add column group with extra columns at the beginning
		columnHierarchy[columnGroup.level] = extraColumns.concat(columnGroup.columns)
	}

	// Add tree action property to first data column of each group
	for (let key in columnHierarchy)
	{
		let columnGroup = columnHierarchy[key]

		// Add tree action property to first data column
		for (let key in columnGroup)
		{
			let column = columnGroup[key]
			let columnIsVivible = column.visibility === undefined || column.visibility

			if (columnIsVivible && !_isEmpty(column.name) && !_isEmpty(column.area) && !_isEmpty(column.field))
			{
				column.hasTreeShowHide = true
				break
			}
		}
	}

	return columnHierarchy
}

/**
 * Get records per page options formatted for menu
 * @param perPageOptionsArray {number}
 */
export function getPerPageOptions(perPageOptionsArray)
{
	let perPageOptions = []

	for (let idx in perPageOptionsArray)
	{
		const perPageOption = perPageOptionsArray[idx]
		perPageOptions.push({ id: perPageOption, text: perPageOption.toString() })
	}

	return perPageOptions
}

/**
 * Get whether per page menu should be visible
 * @param perPageOptionsArray {number}
 * @param defaultPerPage {number}
 * @param rowCount {number}
 * @param page {number}
 * @param showAlternatePagination {boolean}
 * @param hasMorePages {boolean}
 * @returns {boolean}
 */
export function getPerPageMenuVisible(perPageOptionsArray, defaultPerPage, rowCount, page, showAlternatePagination, hasMorePages)
{
	if (!Array.isArray(perPageOptionsArray) || perPageOptionsArray.length < 1)
		return false

	const sortedPerPageOptions = perPageOptionsArray.concat([defaultPerPage]).sort((a, b) => a - b)

	if (sortedPerPageOptions.length < 2)
		return false

	// If rowCount is only the number of records for the current page
	if (showAlternatePagination)
	{
		// Has multiple pages or has more records than lowest per-page option
		return hasMorePages || page > 1 || rowCount > sortedPerPageOptions[0]
	}

	return rowCount > sortedPerPageOptions[0]
}

/**
 * Determine number of actions that are visible in the array
 * (also accounting for read-only mode).
 * @param actionArray {Array}
 * @param isReadOnly {Boolean}
 */
export function numArrayVisibleActions(actionArray, isReadOnly)
{
	if (!Array.isArray(actionArray))
		return 0
	if (isReadOnly === false)
		return actionArray.length
	return actionArray.filter((a) => a.isInReadOnly !== false).length
}

/**
 * 1st - Reduce redundant data that comes from server (Rownum).
 * 2nd - Reduce overhead when converting Tree into reactive (children).
 */
class TreeRow
{
	constructor(row, fnRowModel, parentRow, options)
	{
		this.rowKey = row.Key
		this.Rownum = row.Key

		this.Area = row.Area
		this.Form = row.Form

		this.BranchId = row.BId
		this._fnRowModel = fnRowModel

		this._fields = row.Fields
		this.Fields = markRaw(typeof this._fnRowModel === 'function' ? this._fnRowModel(row.Fields) : row.Fields)
		this.Fields.ValZzstate = 0

		this.alreadyLoaded = !_isEmpty(row.Children)

		Object.defineProperty(this, '_originalChildren', {
			value: row.Children,
			writable: true,
			enumerable: false
		})

		Object.defineProperty(this, '_parsedChildren', {
			writable: true,
			enumerable: false
		})

		// Hidden (cloneDeep problems)
		Object.defineProperty(this, 'hasChildren', {
			value: ref(!_isEmpty(this._originalChildren)),
			writable: true,
			enumerable: false
		})

		// FOR: tree table select row on return
		// Store row level
		if (parentRow !== undefined && parentRow !== null)
		{
			this.level = parentRow.level + 1
			this.ParentRowKey = parentRow.rowKey
		}
		else
			this.level = 0

		if (options !== undefined && options !== null)
		{
			// FOR: tree table select row on return
			/*
				Adding the 'showChildRows' property is needed so that when this is passed to the tree table row component
				the rows that need to be expanded will be expanded and the one that needs to be selected will be loaded.
			*/
			if (Array.isArray(options.rowKeyToScroll) &&
				this.level < options.rowKeyToScroll.length - 1 &&
				this.rowKey === options.rowKeyToScroll[this.level])
				this.showChildRows = true

			if (options.rownum !== undefined && options.rownum !== null)
				this.Rownum = options.rownum
		}
	}

	get children()
	{
		let rownum = 0
		if (!this._parsedChildren)
			this._parsedChildren = reactive(_map(this._originalChildren, (row) => new TreeRow(row, this._fnRowModel, this, { rownum: rownum++ })))
		return this._parsedChildren
	}

	hydrateChildrenData(rowsData, rowKeyToScroll)
	{
		let rownum = 0
		this.alreadyLoaded = true
		this._originalChildren = rowsData
		this._parsedChildren = reactive(_map(this._originalChildren, (row) => {
			row.Fields = { ...this._fields, ...row.Fields }
			return new TreeRow(row, this._fnRowModel, this, { rowKeyToScroll: rowKeyToScroll, rownum: rownum++ })
		}))
		this.hasChildren = !_isEmpty(this._originalChildren)
	}
}

/**
 * Hydrates the tree table data.
 * @param {object} listControl The list control object
 * @param {object} viewModel The list view model (C#)
 */
export function hydrateTreeTableData(listControl, viewModel, rowKeyToScroll)
{
	if (typeof viewModel === 'undefined')
		return

	// Remove previous data
	listControl.rows = []

	if (typeof viewModel.Tree === 'undefined')
		return

	let rownum = 0

	listControl.rows = reactive(_map(viewModel.Tree, (row) => new TreeRow(row, listControl.config.treeListDefinitions?.rowModel, null, { rowKeyToScroll: rowKeyToScroll, rownum: rownum++ })))
}

class fullCalendarEvent
{
	constructor()
	{
		this.id = null
		this.title = null
		this.description = null
		this.start = null
		this.end = null
		this.color = null
		this.allDay = false
		this.resourceId = null
		this.rendering = ''
	}
}

class fullCalendarResource
{
	constructor()
	{
		this.id = null
		this.title = null
		this.columnLabel = null
		this.group = null
		this.groupLabel = null
		this.children = []
	}
}

class fullCalendarResourceChild
{
	constructor()
	{
		this.id = null
		this.title = null
	}
}

/**
 * Hydrates the Full Calendar data.
 * @param {object} listControl The list control object
 * @param {object} viewModel The list view model (C#)
 */
export function hydrateFullCalendarData(listControl, viewModel)
{
	let events = [], resources = []

	_forEach(viewModel.Table.Elements, (row) => {
		let event = new fullCalendarEvent(),
			resource = new fullCalendarResource(),
			resourceChild = new fullCalendarResourceChild(),
			hasChildren = false,
			dates = 0,
			texts = 0,
			bools = 0

		event.id = !_isEmpty(listControl.config.pkColumn) ? _get(row, listControl.config.pkColumn) : null

		_forEach(listControl.columns, (column) => {
			if (column.visibility)
			{
				let columnValue = _get(row, column.name)
				switch (column.dataType)
				{
					case 'Text':
						{
							switch (texts)
							{
								case 0:
									event.title = columnValue
									break
								case 1:
									event.description = columnValue
									break
								case 2:
									event.color = columnValue
									break
								case 3:
									event.resourceId = columnValue
									resource.id = columnValue
									break
								case 4:
									resource.columnLabel = column.label
									resource.title = columnValue
									break
								case 5:
									resource.group = columnValue
									break
								case 6:
									resource.groupLabel = columnValue
									break
								case 7:
									// If the resource has children, the id of the event must be linked to the children instead of the resource.
									event.resourceId = columnValue
									resourceChild.id = columnValue
									break
								case 8:
									resourceChild.title = columnValue
									break
							}
							texts++
						}
						break
					case 'Date':
						{
							switch (dates)
							{
								case 0:
									event.start = columnValue
									break
								case 1:
									event.end = columnValue
									break
							}
							dates++
						}
						break
					case 'Boolean':
						{
							switch (bools)
							{
								case 0:
									event.allDay = columnValue
									break
								case 1:
									event.rendering = columnValue ? 'background' : ''
									break
							}
							bools++
						}
						break
				}
			}
		})

		events.push(event)

		let resIndex = _findIndex(resources, { id: resource.id })
		if (resIndex === -1)
		{
			if (hasChildren)
				resource.children.push(resourceChild)
			resources.push(resource)
		}
		else if (hasChildren && _findIndex(resources[resIndex].children, resourceChild) === -1)
			resources[resIndex].children.push(resourceChild)
	})

	listControl.events = events
	listControl.resources = resources
}

/**
 * Get flat array of rows from a tree (use with treeList pattern).
 * @param {object} rows The tree list row
 * @param {string} childkey the name of property that contain the child rows
 */
export function getRowsFlatArray(rows, childkey)
{
	const flattenItems = (items, key) => {
		return items.reduce((flattenedItems, item) => {
			flattenedItems.push(item)

			if (Array.isArray(item[key]))
				flattenedItems = flattenedItems.concat(flattenItems(item[key], key))

			return flattenedItems
		}, [])
	}

	return flattenItems(rows, childkey)
}

/**
 * Search a row from a tree (use with treeList pattern).
 * @param {object} rows The tree list row
 * @param {string} childkey the name of property that contain the child rows
 * @param {object} criteria a array object with the select criteria, Ex: ['key', 27]
 */
export function searchTreeRow(rows, childkey, criteria)
{
	return _find(getRowsFlatArray(rows, childkey), criteria)
}

/**
 * Determine column used for default search
 * @param {array} columns columns
 * @param {string} defaultSearchColumnName default search column name
 * @returns Object
 */
export function getDefaultSearchColumn(columns, defaultSearchColumnName)
{
	var column = {}

	if (!columns || columns.length < 1)
		return null

	// Find field with the same name as the default search field property
	for (let idx in columns)
	{
		column = columns[idx]
		if (column.name === defaultSearchColumnName)
			return column
	}

	// No field marked as default search field
	// Find first visible field
	for (let idx in columns)
	{
		column = columns[idx]
		if (column.visibility !== undefined)
		{
			if (column.visibility !== false)
				return column
		}
		else
			return column
	}

	// Use first field
	return columns[0]
}

/**
 * Get primary key of row.
 * @param table {Object}
 * @param row {Object}
 * @returns String
 */
export function getRowPk(table, row)
{
	return row.Fields[table.pkColumn]
}

/**
 * Get a row object from the row key
 * @param rows {Object}
 * @param rowKey {String}
 * @returns Object
 */
export function getRowByKey(rows, rowKey)
{
	return rows.find((row) => row.rowKey === rowKey)
}

/**
 * Get a row object from the row key path
 * @param rows {Object}
 * @param rowKeyPath {String}
 * @returns Object
 */
export function getRowByKeyPath(rows, rowKeyPath)
{
	// If single row key given, convert to array
	if(typeof rowKeyPath === 'string')
		rowKeyPath = [rowKeyPath]

	if(!Array.isArray(rowKeyPath) || rowKeyPath?.length === 0)
		return

	let currentRows = rows
	let levelRow
	let rowKey
	let idx
	for(idx in rowKeyPath)
	{
		// Find row with key at the current path level
		rowKey = rowKeyPath[idx]
		levelRow = currentRows.find((row) => row.rowKey === rowKey)

		// If no rows have the key at this level, no row with this key path exists
		if(!levelRow)
			return null

		// If the row found has sub-rows, search them in the next iteration
		if(Array.isArray(levelRow.children) && levelRow.children.length > 0)
			currentRows = levelRow.children
		else
			break
	}

	// If all levels in the row key path have been searched, the last row found is the result
	if(parseInt(idx) === rowKeyPath.length - 1)
		return levelRow

	// If not all rows were searched, the row was not found
	return null
}

/**
 * Get a row key path from the rows and specific row
 * @param rows {Object}
 * @param row {Object}
 * @returns Array
 */
export function getRowKeyPath(rows, row)
{
	let rowKeyPath = [row?.rowKey]
	let allRows = getRowsFlatArray(rows, 'children')
	let currentRow = row

	while(currentRow?.ParentRowKey && parseInt(currentRow.level) > 0)
	{
		currentRow = allRows.find(
			(row) => parseInt(row.level) === parseInt(currentRow.level) - 1 && row.rowKey === currentRow.ParentRowKey
		)
		if(currentRow === undefined)
			break

		rowKeyPath.unshift(currentRow?.rowKey)
	}

	return rowKeyPath
}

/**
 * Get array of row objects from list of row keys.
 * @param rows {Array}
 * @param rowKeys {Object}
 * @returns Array
 */
export function getRowsFromKeyHash(rows, rowKeys)
{
	var rtnRows = []
	var row = {}

	for (let idx in rows)
	{
		row = rows[idx]
		if (rowKeys[row.rowKey] !== undefined)
			rtnRows.push(row)
	}

	return rtnRows
}

/**
 * Get value of cell data.
 * @param row {Object}
 * @param column {Object}
 * @returns any type
 */
export function getCellValue(row, column)
{
	return _get(row.Fields, column.name, _get(row.Fields, `${_toLower(column.area)}.${_toLower(column.field)}`))
}

/**
 * Get value of cell data.
 * @param table {Object}
 * @param row {Object}
 * @param column {Object}
 * @returns any type
 */
export function getTableCellValue(table, row, column)
{
	return _get(row.Fields, column.name)
}

/**
 * Get value of cell data.
 * @param row {Object}
 * @param columnName {String}
 * @returns any type
 */
export function getCellNameValue(row, columnName)
{
	return _get(row.Fields, columnName)
}

/**
 * Set the value of a cell.
 * @param row {Object}
 * @param column {Object}
 * @param value {Object}
 */
export function setCellValue(row, column, value)
{
	_set(row.Fields, column.name, value)
}

/**
 * Set the value of a cell.
 * @param table {Object}
 * @param row {Object}
 * @param column {Object}
 * @param value {Object}
 */
export function setTableCellValue(table, row, column, value)
{
	// Current index of this row
	var curIdx = table.rows.findIndex(getRownumIndex, row.Rownum)
	// Check bounds
	if (curIdx < 0 || curIdx >= table.rows.length)
		return

	// Get this row in table
	var thisRow = table.rows[curIdx]

	// Set cell value
	_set(thisRow.Fields, column.name, value)
}

/**
 * Full column name
 * @param {object} column
 */
export function columnFullName(column)
{
	return column ? `${column.area}.${column.field}` : ''
}

/**
 * Get column reference from table and column names
 * @param columns {Array}
 * @param tableName {String}
 * @param columnName {String}
 * @returns {Object}
 */
export function getColumnFromTableAndColumnNames(columns, tableName, columnName)
{
	return columns.find((obj) => obj.area === tableName && obj.field === columnName)
}

/**
 * Get column reference from full TABLE.COLUMN name
 * @param columns {Array}
 * @param columnName {String}
 * @returns {Object}
 */
export function getColumnFromTableColumnName(columns, columnName)
{
	if (_isEmpty(columnName))
		return ''

	const columnNameProps = columnName.split('.')
	if (columnNameProps.length < 2)
		return ''

	return getColumnFromTableAndColumnNames(columns, columnNameProps[0], columnNameProps[1])
}

/**
 * Get column reference from name
 * @param table {Object}
 * @param columnName {String}
 * @returns {Object}
 */
export function getTableColumnFromName(table, columnName)
{
	return table.columns.find((obj) => obj.name === columnName)
}

/**
 * Recalculate values for all cell in a column to be in order.
 * @param currentValue {Object}
 * @returns boolean
 */
export function getRownumIndex(currentValue)
{
	return (parseInt(currentValue.Rownum) === parseInt(this))
}

/**
 * Recalculate values for all cell in a column to be in order.
 * @param table {Object}
 * @param row {Object}
 * @param column {Object}
 */
export function reCalcCellOrder(table, row, column)
{
	// Current index of this row
	var curIdx = table.rows.findIndex((r) => r.rowKey === row.rowKey)
	// Check bounds
	if (curIdx < 0 || curIdx >= table.rows.length)
		return

	// New index of this row
	var newIdx = getCellValue(row, column) - 1
	// Check bounds
	if (newIdx < 0)
		newIdx = 0
	else if (newIdx >= table.rows.length)
		newIdx = table.rows.length - 1

	// Remove row from current location
	table.rows.splice(curIdx, 1)
	// Add row at new location
	table.rows.splice(newIdx, 0, row)

	// Iterate rows and assign new values to the "order" column
	var thisIdx = 1
	for (let idx in table.rows)
		setCellValue(table.rows[idx], column, thisIdx++)

	// Update key properties to update component keys to reload controls so they display the new values
	for (let idx in table.rows)
		table.rows[idx].key++
}

/**
 * Call function defined to run when cell value changes.
 * @param table {Object}
 * @param row {Object}
 * @param column {Object}
 * @param options {Object}
 */
export function cellOnChange(table, row, column, options)
{
	if (column.dataOnChange === undefined)
		return
	column.dataOnChange(table, row, column, options)
}

/* BEGIN: Formatting field data to display */

/**
 * Get formatted string representing text in a cell.
 * @param row {Object}
 * @param column {Object}
 * @param options {Object}
 * @returns String
 */
export function textDisplayCell(row, column, options)
{
	const value = getCellValue(row, column)
	return genericFunctions.textDisplay(value, options)
}

/**
 * Get formatted string representing a number in a cell.
 * @param row {Object}
 * @param column {Object}
 * @param options {Object}
 * @returns String
 */
export function numericDisplayCell(row, column, options)
{
	const value = getCellValue(row, column)
	return genericFunctions.numericDisplay(value, options.numberFormat.decimalSeparator, options.numberFormat.groupSeparator, { minimumFractionDigits: column.decimalPlaces, maximumFractionDigits: column.decimalPlaces }, options)
}

/**
 * Get formatted string representing a currency in a cell.
 * @param row {Object}
 * @param column {Object}
 * @param options {Object}
 * @returns String
 */
export function currencyDisplayCell(row, column, options)
{
	const value = getCellValue(row, column)
	if (column.currency === undefined)
		return numericDisplayCell(row, column, options)

	return genericFunctions.currencyDisplay(value, options.numberFormat.decimalSeparator, options.numberFormat.groupSeparator, column.decimalPlaces, column.currency, options.lcid, 'narrowSymbol', options)
}

/**
 * Get formatted string representing a date/time in a cell.
 * @param row {Object}
 * @param column {Object}
 * @param options {Object}
 * @returns String
 */
export function dateDisplayCell(row, column, options)
{
	var dateTimeStr = getCellValue(row, column)
	var dateTimeFormat = options.dateFormats.dateTimeSeconds

	switch (column.dateTimeType)
	{
		case 'Date':
			dateTimeFormat = options.dateFormats.date
			break
		case 'DateTime':
			dateTimeFormat = options.dateFormats.dateTime
			break
		case 'DateTimeSeconds':
			dateTimeFormat = options.dateFormats.dateTimeSeconds
			break
		case 'Time':
			dateTimeFormat = options.dateFormats.hours
			dateTimeStr = '0001-01-01 ' + dateTimeStr
			break
	}

	return genericFunctions.dateDisplay(dateTimeStr, dateTimeFormat, column.dateTimeType, options.dateFormats.use12Hour, options)
}

/**
 * Get formatted string representing a boolean in a cell.
 * @param row {Object}
 * @param column {Object}
 * @returns Boolean
 */
export function booleanDisplayCell(row, column, options)
{
	const value = getCellValue(row, column)
	return genericFunctions.booleanDisplay(value, options)
}

/**
 * Get formatted string representing a hyperlink in a cell.
 * @param row {Object}
 * @param column {Object}
 * @param options {Object}
 * @returns String
 */
export function hyperLinkDisplayCell(row, column)
{
	return getCellValue(row, column)
}

/**
 * Get formatted string representing an image in a cell.
 * @param row {Object}
 * @param column {Object}
 * @param options {Object}
 * @returns String || Object
 */
export function imageDisplayCell(row, column, options)
{
	const value = getCellValue(row, column)
	return genericFunctions.imageDisplay(value, options)
}

/**
 * Get formatted string representing a document in a cell.
 * @param row {Object}
 * @param column {Object}
 * @param options {Object}
 * @returns String || Object
 */
export function documentDisplayCell(row, column, options)
{
	const value = getCellValue(row, column)

	// Map the Preview or Print value
	if (value !== undefined && value !== null)
	{
		if (column.viewType === undefined || column.viewType === null)
			value.viewType = documentViewTypeMode.print
		else
			value.viewType = column.viewType
	}

	return genericFunctions.documentDisplay(value, options)
}

/**
 * Get formatted string representing a geographic coordinate in a cell.
 * @param row {Object}
 * @param column {Object}
 * @param options {Object} [optional]
 * @returns String
 */
export function geographicDisplayCell(row, column, options)
{
	const value = getCellValue(row, column)
	return genericFunctions.geographicDisplay(value, options.numberFormat.decimalSeparator, options.numberFormat.groupSeparator)
}

/**
 * Get formatted string representing a geographic shape in a cell.
 * @param row {Object}
 * @param column {Object}
 * @returns String
 */
export function geographicShapeDisplayCell(row, column)
{
	const value = getCellValue(row, column)
	return genericFunctions.geographicShapeDisplay(value)
}

/**
 * Get formatted string representing a value from an enumeration in a cell.
 * @param row {Object}
 * @param column {Object}
 * @param options {Object} [optional]
 * @returns String
 */
export function enumerationDisplayCell(row, column, options)
{
	const value = getCellValue(row, column)

	if (column.array === undefined)
		return value

	return genericFunctions.enumerationDisplay(column.arrayAsObj, value, options)
}

/**
 * Get formatted string representing a radio button in a cell.
 * @param row {Object}
 * @param column {Object}
 * @param options {Object} [optional]
 * @returns Boolean
 */
export function radioDisplayCell(row, column, options)
{
	const value = getCellValue(row, column)
	return genericFunctions.radioDisplay(value, options)
}

/**
 * Get formatted string representing cell value. Calls formatting function based on column data type.
 * @param table {Object}
 * @param row {Object}
 * @param column {Object}
 * @param options {Object} [optional]
 * @returns String(plain text or HTML)
 */
export function getCellValueDisplay(table, row, column, options)
{
	if (column.dataDisplay === undefined)
		return getCellValue(row, column)

	// Optional options
	// Scroll data (to truncate and add elipses)
	if (options !== undefined && options.useScroll !== undefined && options.useScroll !== false)
		options.scrollData = column.scrollData

	if (!options || options === undefined)
		options = {}

	// Set options based on the table
	if (table)
	{
		if (table.numberFormat && table.numberFormat !== undefined)
			options.numberFormat = table.numberFormat

		if (table.lcid && table.lcid !== undefined)
			options.lcid = table.lcid

		if (table.dateFormats && table.dateFormats !== undefined)
			options.dateFormats = table.dateFormats
	}
	else
	{
		options.numberFormat = {
			decimalSeparator: ',',
			groupSeparator: '.'
		}
		options.dateFormats = {
			date: 'dd/MM/yyyy',
			dateTime: 'dd/MM/yyyy HH:mm',
			dateTimeSeconds: 'dd/MM/yyyy HH:mm:ss',
			hours: 'HH:mm',
			use12Hour: false
		}
		options.lcid = 'pt-PT'
	}

	if (column.isHtmlField)
		options.isHtml = true

	return column.dataDisplay(row, column, options)
}

/**
 * Get string representing the search value of text in a cell.
 * @param row {Object}
 * @param column {Object}
 * @param options {Object}
 * @returns String
 */
export function textSearchCell(row, column, options)
{
	var value = getCellValue(row, column)
	return genericFunctions.textDisplay(value, options)
}

/**
 * Get string representing the search value of a number in a cell.
 * @param row {Object}
 * @param column {Object}
 * @param options {Object}
 * @returns String
 */
export function numericSearchCell(row, column, options)
{
	var value = getCellValue(row, column)
	return genericFunctions.numericDisplay(value, options.numberFormat.decimalSeparator, options.numberFormat.groupSeparator, { minimumFractionDigits: column.decimalPlaces, maximumFractionDigits: column.decimalPlaces }, options)
}

/**
 * Get string representing the search value of a currency in a cell.
 * @param row {Object}
 * @param column {Object}
 * @param options {Object}
 * @returns String
 */
export function currencySearchCell(row, column, options)
{
	var value = getCellValue(row, column)
	return genericFunctions.numericDisplay(value, options.numberFormat.decimalSeparator, options.numberFormat.groupSeparator, { minimumFractionDigits: column.decimalPlaces, maximumFractionDigits: column.decimalPlaces }, options)
}

/**
 * Get string representing the search value of a date/time in a cell.
 * @param row {Object}
 * @param column {Object}
 * @param options {Object}
 * @returns String
 */
export function dateSearchCell(row, column, options)
{
	return dateDisplayCell(row, column, options)
}

/**
 * Get string representing the search value of a boolean in a cell.
 * @param row {Object}
 * @param column {Object}
 * @param options {Object}
 * @returns String
 */
export function booleanSearchCell(row, column, options)
{
	var value = getCellValue(row, column)
	return genericFunctions.booleanDisplay(value, options)
}

/**
 * Get string representing the search value of a hyperLink in a cell.
 * @param row {Object}
 * @param column {Object}
 * @returns String
 */
export function hyperLinkSearchCell(row, column)
{
	return getCellValue(row, column)
}

/**
 * Get string representing the search value of an image.
 * @param value {String}
 * @returns String
 */
export function imageSearch(value)
{
	if (value.altText !== undefined)
		return value.altText

	if (value.titleText !== undefined)
		return value.titleText

	return ''
}

/**
 * Get string representing the search value of an image in a cell.
 * @param row {Object}
 * @param column {Object}
 * @param options {Object}
 * @returns String
 */
export function imageSearchCell(row, column, options)
{
	var value = getCellValue(row, column)
	return imageSearch(value, options)
}

/**
 * Get string representing the search value of a document.
 * @param value {String}
 * @returns String
 */
export function documentSearch(value)
{
	if (value.fileName !== undefined)
		return value.fileName

	if (value.title !== undefined)
		return value.title

	return ''
}

/**
 * Get string representing the search the value of a document in a cell.
 * @param row {Object}
 * @param column {Object}
 * @param options {Object}
 * @returns String
 */
export function documentSearchCell(row, column, options)
{
	var value = getCellValue(row, column)
	return documentSearch(value, options)
}

/**
 * Get formatted string representing the search value of a geographic coordinate.
 * @param value {String}
 * @param decimalSep {String}
 * @param groupSep {String}
 * @returns String
 */
export function geographicSearch(value, decimalSep, groupSep)
{
	if (typeof value.Lat !== 'number' || typeof value.Long !== 'number')
		return ''

	return genericFunctions.numericDisplay(value.Lat, decimalSep, groupSep, { minimumFractionDigits: 0, maximumFractionDigits: 20 }) + ' ' + genericFunctions.numericDisplay(value.Long, decimalSep, groupSep, { minimumFractionDigits: 0, maximumFractionDigits: 20 })
}

/**
 * Get string representing the search value of a geographic coordinate in a cell.
 * @param row {Object}
 * @param column {Object}
 * @param options {Object}
 * @returns String
 */
export function geographicSearchCell(row, column, options)
{
	var value = getCellValue(row, column)
	return geographicSearch(value, options.numberFormat.decimalSeparator, options.numberFormat.groupSeparator, options)
}

/**
 * Get string representing search value of a enumeration in a cell.
 * @param row {Object}
 * @param column {Object}
 * @param options {Object}
 * @returns String
 */
export function enumerationSearchCell(row, column, options)
{
	return enumerationDisplayCell(row, column, options)
}

/**
 * Get string for search value of a cell in a row.
 * @param table {Object}
 * @param row {Object}
 * @param column {Object}
 * @param options {Object} [optional]
 * @returns String
 */
export function getCellValueSearch(table, row, column, options)
{
	if (column.dataSearch === undefined)
		return getCellValue(row, column)

	// Optional options
	if (!options || options === undefined)
		options = {}

	// Set options based on the table
	if (table)
	{
		if (table.numberFormat && table.numberFormat !== undefined)
			options.numberFormat = table.numberFormat

		if (table.lcid && table.lcid !== undefined)
			options.lcid = table.lcid

		if (table.dateFormats && table.dateFormats !== undefined)
			options.dateFormats = table.dateFormats
	}
	else
	{
		options.numberFormat = {
			decimalSeparator: ',',
			groupSeparator: '.'
		}
		options.dateFormats = {
			date: 'dd/MM/yyyy',
			dateTime: 'dd/MM/yyyy HH:mm',
			dateTimeSeconds: 'dd/MM/yyyy HH:mm:ss',
			hours: 'HH:mm',
			use12Hour: false
		}
		options.lcid = 'pt-PT'
	}

	return column.dataSearch(row, column, options)
}

/* END: Formatting field data to display */

/**
 * Determine if column is sortable
 * @param column {Object}
 * @returns Boolean
 */
export function isSortableColumn(column)
{
	return _get(column, 'sortable', false)
}

/**
 * Determine if column is searchable
 * @param column {Object}
 * @returns boolean
 */
export function isSearchableColumn(column)
{
	return !_isEmpty(column.searchFieldType)
}

/**
 * Get searchable columns
 * @param columns {Array}
 * @returns Array
 */
export function getSearchableColumns(columns)
{
	if (!columns)
		return []
	return columns.filter(isSearchableColumn)
}

/**
 * Get sortable columns
 * @param columns {Array}
 * @returns Array
 */
export function getSortableColumns(columns)
{
	if (!columns)
		return []
	return columns.filter(isSortableColumn)
}

/* BEGIN: Filter functions */

/**
 * Create search filter
 * @param {string} name : Name of search filter
 * @param {boolean} active : State of search filter (active or inactive)
 * @param {SearchFilterCondition[]} conditions : Array of conditions
 */
export function searchFilter(name, active, conditions)
{
	if (_isEmpty(conditions))
		conditions = []

	return {
		Name: name,
		Active: active,
		Conditions: conditions
	}
}

/**
 * Create search filter condition
 * @param {string} name : Name of condition
 * @param {bool} active : Active/inactive state
 * @param {string} field : Full name of field (TABLE.COLUMN)
 * @param {string} operator : Operator code (as in operators object)
 * @param {string[]} values : Array of values
 */
export function searchFilterCondition(name, active, field, operator, values)
{
	if (_isEmpty(values))
		values = []

	return {
		Name: name,
		Active: active,
		Field: field,
		Operator: operator,
		Values: values
	}
}

/**
 * Add condition to search filter at end of condition array
 * @param {object} searchFilter : Search filter
 * @param {SearchFilterCondition} condition : Conditions
 */
export function searchFilterAppendCondition(searchFilter, condition)
{
	searchFilter.Conditions.push(condition)
}

/**
 * Add condition to search filter
 * @param {object} searchFilter : Search filter
 * @param {number} index : Index
 * @param {SearchFilterCondition} condition : Conditions
 */
export function searchFilterAddCondition(searchFilter, index, condition)
{
	if (index <= searchFilter.Conditions.length)
		searchFilter.Conditions.splice(index, 0, condition)
}

/**
 * Set condition in search filter
 * @param {object} searchFilter : Search filter
 * @param {number} index : Index
 * @param {SearchFilterCondition} condition : Conditions
 */
export function searchFilterSetCondition(searchFilter, index, condition)
{
	if (index <= searchFilter.Conditions.length)
		searchFilter.Conditions.splice(index, 1, condition)
}

/**
 * Remove condition in search filter
 * @param {object} searchFilter : Search filter
 * @param {number} index : Index
 */
export function searchFilterRemoveCondition(searchFilter, index)
{
	if (index <= searchFilter.Conditions.length)
		searchFilter.Conditions.splice(index, 1)
}

/**
 * Get name of filter, calculating if empty
 * @param {Object} filterOperators
 * @param {Object} filter
 * @param {Array} searchableColumns
 * @param {string resource ID} orText
 * @returns {String}
 */
export function getFilterName(filterOperators, filter, searchableColumns, orText)
{
	// Filter name defined
	if (filter.Name.length > 0)
		return filter.Name

	// Filter name not defined
	var conditionNames = [],
		condition = {},
		column = {},
		operator = {}

	for (let conditionIdx in filter.Conditions)
	{
		condition = filter.Conditions[conditionIdx]
		column = getFilterColumnFromName(filter, conditionIdx, searchableColumns)
		operator = _get(filterOperators, `${column.searchFieldType}.${condition.Operator}`, { Title: 'Unknown', ValueCount: 0 })
		conditionNames[conditionIdx] = `${column.label} ${operator.Title}`

		if (operator.ValueCount > 0)
		{
			// Format values
			let conditionValues = []
			// Format dates
			if (column.searchFieldType === 'date')
			{
				const systemDataStore = useSystemDataStore()
				const dateFormat = systemDataStore.system.dateFormat[column.dateTimeType]

				for (let idx in condition.Values)
					conditionValues[idx] = genericFunctions.dateDisplay(condition.Values[idx], dateFormat, column.dateTimeType, false)
			}
			else if (column.searchFieldType === 'enum')
				conditionValues = condition.Values.map((value) => value?.value)
			// No formatting needed
			else
				conditionValues = condition.Values

			// If using array of values in first value (IN operation)
			if (Array.isArray(condition.Values[0]))
				conditionNames[conditionIdx] += ` "${condition.Values[0].join('", "')}"`
			// Normal case
			else
				conditionNames[conditionIdx] += ` "${conditionValues.join('", "')}"`
		}
	}

	return conditionNames.join(` ${orText} `)
}

/**
 * Get column of condition by index
 * @param {Object} filter
 * @param {number} conditionIdx : index
 * @param {Array} searchableColumns
 * @returns {Object}
 */
export function getFilterColumnFromName(filter, conditionIdx, searchableColumns)
{
	if (filter.Conditions.length < 1)
		return null
	return getColumnFromTableColumnName(searchableColumns, filter.Conditions[conditionIdx].Field)
}

/**
 * Get operators for condition by index
 * @param {Object} filterOperators
 * @param {Object} filter
 * @param {number} conditionIdx : index
 * @returns {Object}
 */
export function getFilterOperators(filterOperators, filter, conditionIdx, searchableColumns)
{
	if (filter.Conditions.length < 1)
		return []
	return filterOperators[getFilterColumnFromName(filter, conditionIdx, searchableColumns).searchFieldType]
}

/**
 * Get number of values for condition by index
 * @param {Object} filterOperators
 * @param {Object} filter
 * @param {number} conditionIdx : index
 * @param {Array} searchableColumns
 * @returns {Object}
 */
export function getFilterValueCount(filterOperators, filter, conditionIdx, searchableColumns)
{
	if (_isEmpty(filter))
		return 0
	if (filter.Conditions === undefined || filter.Conditions === null)
		return 0
	if (filter.Conditions.length < 1)
		return 0
	if (filter.Conditions[conditionIdx].Operator.length < 1)
		return 0
	if (getFilterOperators(filterOperators, filter, conditionIdx, searchableColumns)[filter.Conditions[conditionIdx].Operator] === undefined)
		return 0
	return getFilterOperators(filterOperators, filter, conditionIdx, searchableColumns)[filter.Conditions[conditionIdx].Operator].ValueCount
}

/**
 * Get input component for condition by index
 * @param {Object} filterOperators
 * @param {Object} filter
 * @param {number} conditionIdx : index
 * @returns {string}
 */
export function getFilterInputComponent(filterOperators, filter, conditionIdx, searchableColumns)
{
	var column = getFilterColumnFromName(filter, conditionIdx, searchableColumns)
	var operator = getFilterOperators(filterOperators, filter, conditionIdx, searchableColumns)[filter.Conditions[conditionIdx].Operator]
	if (column.distinctValues !== undefined && column.distinctValues !== null)
	{
		if (Object.keys(column.distinctValues).length > 0)
			return 'q-edit-enumeration'
	}
	else if (operator.inputComponent !== undefined)
		return operator.inputComponent
	return searchFilterData.inputComponents[column.searchFieldType]
}

/**
 * Get placeholder for condition input by index
 * @param {Object} filterOperators
 * @param {Object} filter
 * @param {number} conditionIdx : index
 * @returns {string}
 */
export function getFilterPlaceholder(filterOperators, filter, conditionIdx, searchableColumns)
{
	var operator = getFilterOperators(filterOperators, filter, conditionIdx, searchableColumns)[filter.Conditions[conditionIdx].Operator]
	if (operator === undefined || operator === null)
		return ''
	return operator.Placeholder
}

/**
 * Select default operator for condition by index
 * @param {Object} filterOperators
 * @param {Object} filter
 * @param {number} conditionIdx : index
 */
export function setFilterDefaultOperator(filterOperators, filter, conditionIdx, searchableColumns)
{
	const column = getFilterColumnFromName(filter, conditionIdx, searchableColumns)
	if (_isEmpty(column))
		return

	filter.Conditions[conditionIdx].Operator = searchFilterData.searchBarOperator(column.searchFieldType, '')
	setFilterDefaultValues(filterOperators, filter, conditionIdx, searchableColumns)
}

/**
 * Set default values for condition by index
 * @param {Object} filterOperators
 * @param {Object} filter
 * @param {number} conditionIdx : index
 */
export function setFilterDefaultValues(filterOperators, filter, conditionIdx, searchableColumns)
{
	var operators = getFilterOperators(filterOperators, filter, conditionIdx, searchableColumns)
	if (_isEmpty(operators) || operators.length < 1)
		return

	var operator = operators[filter.Conditions[conditionIdx].Operator]
	var valueCount = getFilterValueCount(filterOperators, filter, conditionIdx, searchableColumns)

	filter.Conditions[conditionIdx].Values = []
	for (let valueIdx = 0; valueIdx < valueCount; valueIdx++)
	{
		if (operator.defaultValue !== undefined)
			filter.Conditions[conditionIdx].Values[valueIdx] = cloneDeep(operator.defaultValue)
		else
		{
			const column = getColumnFromTableColumnName(searchableColumns, filter.Conditions[conditionIdx].Field)
			filter.Conditions[conditionIdx].Values[valueIdx] = searchFilterData.defaultValue(column)
		}
	}
}

/**
 * Set value of condition by index
 * @param {object} filter
 * @param {number} conditionIdx : index
 * @param {number} valueIdx : index
 * @param {object} value : value
 */
export function setFilterConditionValue(filter, conditionIdx, valueIdx, value)
{
	filter.Conditions[conditionIdx].Values[valueIdx] = value
}

/**
 * Transform filters into format for server-side
 * @param {object} filterCollection : Search filter array / hashtable
 * @param {array} searchableColumns : columns
 */
export function filtersToServerFormat(filterCollection, searchableColumns)
{
	// Iterate filter collection
	for (const fcIdx in filterCollection)
	{
		const filter = filterCollection[fcIdx]

		// Iterate filter conditions
		for (let conIdx in filter.Conditions)
		{
			const filterCondition = filter.Conditions[conIdx]
			const column = getFilterColumnFromName(filter, conIdx, searchableColumns)

			// If condition's first value is an array, replace condition's Values array with first value array
			if (column?.searchFieldType === 'enum')
			{
				if (filterCondition.Operator === 'IN' && Array.isArray(filterCondition.Values[0]))
					filterCondition.Values = filterCondition.Values[0]
				else
					filterCondition.Values = filterCondition.Values.map((value) => value?.value)
			}
		}
	}
}

/**
 * Transform filters into format for client-side
 * @param {object} filterCollection : Search filter array / hashtable
 * @param {array} searchableColumns : columns
 */
export function filtersToClientFormat(filterCollection, searchableColumns)
{
	// Iterate filter collection
	for (let fcIdx in filterCollection)
	{
		const filter = filterCollection[fcIdx]

		// Iterate filter conditions
		for (let conIdx in filter.Conditions)
		{
			const filterCondition = filter.Conditions[conIdx]
			const column = getFilterColumnFromName(filter, conIdx, searchableColumns)

			// If condition's operator is IN, replace first value with the condition's Values array
			if (column?.searchFieldType === 'enum')
			{
				if (filterCondition.Operator === 'IN' && !Array.isArray(filterCondition.Values[0]))
					filterCondition.Values = [filterCondition.Values]
				else
				{
					for (let valIdx in filterCondition.Values)
					{
						const value = filterCondition.Values[valIdx]
						const enumValue = _find(column.array, (elem) => elem.value === value)

						if (enumValue !== undefined && enumValue !== null)
							filterCondition.Values[valIdx] = enumValue
					}
				}
			}
		}
	}
}

/**
 * Validate filter and return errors
 * @param {object} filter : Search filter
 * @param {object} columns : Table columns
 * @returns {array} states
 */
export function filterValidate(filter, columns)
{
	let conditionStates = [],
		valueStates = [],
		conditionState = '',
		valueState = ''

	for (let idx in filter.Conditions)
	{
		let condition = filter.Conditions[idx]
		let column = columns.find((col) => `${col.area}.${col.field}` === condition.Field)
		conditionState = 'VALID'
		valueStates = []

		for (let valueIdx in condition.Values)
		{
			let value = condition.Values[valueIdx]
			let strValue = value?.toString() ?? ''
			valueState = 'VALID'

			if (_isEmpty(strValue) ||
				/* Enumerated fields with no checkbox selected */
				(condition.Operator === 'IN' && condition.Values[0]?.length === 0))
			{
				valueState = 'EMPTY'
				conditionState = 'INVALID'
			}

			valueStates.push(valueState)
		}

		conditionStates.push({
			Table: column.area,
			Field: column.field,
			Name: column.name,
			Label: column.label,
			Type: column.dataType,
			State: conditionState,
			ValueStates: valueStates
		})
	}

	return conditionStates
}

/* END: Filter functions */

/**
 * Get searchable columns as options for dropdown
 * @param columns {Array}
 * @returns Array
 */
export function getSearchableColumnOptions(columns)
{
	const options = []

	for (const idx in columns)
	{
		const column = columns[idx]
		options.push({key: columnFullName(column), value: column.label})
	}

	return options
}

/**
 * Get filter operators as options for dropdown
 * @param filter {Object}
 * @param conditionIdx {Array}
 * @param operators {Number}
 * @param columns {Array}
 * @returns Array
 */
export function getFilterOperatorOptions(filter, conditionIdx, operators, columns)
{
	const options = []
	const columnOperators = getFilterOperators(operators, filter, conditionIdx, columns)

	for (const idx in columnOperators)
	{
		const operator = columnOperators[idx]
		options.push({key: operator.key, value: operator.Title})
	}

	return options
}

/**
 * Get cell slot name
 * @param column {Object}
 * @returns String
 */
export function getCellSlotName(column)
{
	if (has(column, 'slotName'))
		return column.slotName
	return column.name.replace(/\./g, '_')
}

/**
 * Determine if column is an actions column
 * @param column {Object}
 * @returns Boolean
 */
export function isActionsColumn(column)
{
	if (column.isActions !== undefined)
		return column.isActions
	return false
}

/**
 * Determine if column is an extended actions column
 * @param action {Object}
 * @returns Boolean
 */
export function isExtendedActionsColumn(column)
{
	if (column.isExtendedActions !== undefined)
		return column.isExtendedActions
	return false
}

/**
 * Determine if column is an checklist column
 * @param column {Object}
 * @returns Boolean
 */
export function isChecklistColumn(column)
{
	if (column.isChecklist !== undefined)
		return column.isChecklist
	return false
}

/**
 * Determine if column is a drag and drop column
 * @param column {Object}
 * @returns Boolean
 */
export function isDragAndDropColumn(column)
{
	if (column.isDragAndDrop !== undefined)
		return column.isDragAndDrop
	return false
}

/**
 * Determine if extended actions array has action passed
 * @param action {Object}
 * @returns Boolean
 */
export function hasExtendedAction(action)
{
	return this.extendedActions.includes(action)
}

/**
 * Determine if cell data has associated action
 * @param column {Object}
 * @returns Boolean
 */
export function hasDataAction(column)
{
	return _get(column, 'cellAction', false)
}

/**
 * Creating copy of parent row & removing children array
 * @param row {Object}
 */
export function rowWithoutChildren(row)
{
	var newRow = { ...row }
	delete newRow.children
	return cloneDeep(newRow)
}

/**
 * Initialization of listeners for events on which functions
 * such as content reloading depend.
 * @param listControl {Object} The list control object
 */
export function initTableEvents(listControl)
{
	let dependencyEvents = ['RELOAD_ALL_LIST_CONTROLS']
	if (!_isEmpty(listControl.controlLimits))
	{
		_forEach(listControl.controlLimits, (controlLimit) => {
			dependencyEvents = _unionWith(dependencyEvents, controlLimit.dependencyEvents)
		})
	}

	if (listControl.vueContext.internalEvents)
	{
		// Reload the list when a dependency changes.
		if (!_isEmpty(dependencyEvents))
			listControl.vueContext.internalEvents.onMany(dependencyEvents, () => listControl.Reload())

		// Reload the list when it becomes visible.
		listControl.vueContext.internalEvents.on('field-shown', (controlId) => {
			if (controlId === listControl.id && !listControl.isLoaded)
				listControl.Reload()
		})

		// Updates the array with dirty rows to validate before leaving the form.
		listControl.vueContext.internalEvents.on('is-table-control-dirty', ({ id, isDirty }) => {
			listControl.vueContext.onRowDirty(listControl, id, isDirty)
		})

		// Deselects selected row(s) when closing and extended support form.
		listControl.vueContext.internalEvents.on('closed-extended-support-form', ({ controlId }) => {
			if (controlId === listControl.id)
				listControl.onUnselectAllRows()
		})

		// Force list reload.
		listControl.vueContext.internalEvents.on('reload-list', ({ controlId }) => {
			if (controlId === listControl.id)
				listControl.Reload()
		})

		// Reload the list when the parent opens.
		if (typeof listControl.parentOpeningEvent === 'string')
		{
			listControl.vueContext.internalEvents.on(listControl.parentOpeningEvent, () => {
				if (!listControl.isLoaded)
					listControl.Reload()
			})
		}
	}
}

export default {
	hydrateTableData,
	applyTableView,
	updateConfigOptions,
	hydrateTreeTableData,
	hydrateTimelineData,
	hydrateFullCalendarData,
	getRowsFlatArray,
	searchTreeRow,
	getDefaultSearchColumn,
	getRowPk,
	getRowByKey,
	getRowByKeyPath,
	getRowKeyPath,
	getRowsFromKeyHash,
	getCellValue,
	getTableCellValue,
	getCellNameValue,
	setCellValue,
	setTableCellValue,
	columnFullName,
	getColumnFromTableAndColumnNames,
	getColumnFromTableColumnName,
	getTableColumnFromName,
	reCalcCellOrder,
	cellOnChange,
	textDisplayCell,
	numericDisplayCell,
	currencyDisplayCell,
	dateDisplayCell,
	booleanDisplayCell,
	hyperLinkDisplayCell,
	imageDisplayCell,
	documentDisplayCell,
	geographicDisplayCell,
	geographicShapeDisplayCell,
	enumerationDisplayCell,
	radioDisplayCell,
	getCellValueDisplay,
	textSearchCell,
	numericSearchCell,
	currencySearchCell,
	dateSearchCell,
	booleanSearchCell,
	hyperLinkSearchCell,
	imageSearch,
	imageSearchCell,
	documentSearch,
	documentSearchCell,
	geographicSearch,
	geographicSearchCell,
	enumerationSearchCell,
	getCellValueSearch,
	isSortableColumn,
	isSearchableColumn,
	getSearchableColumns,
	getSortableColumns,
	searchFilter,
	searchFilterCondition,
	searchFilterAppendCondition,
	searchFilterAddCondition,
	searchFilterSetCondition,
	searchFilterRemoveCondition,
	getFilterName,
	getFilterColumnFromName,
	getFilterOperators,
	getFilterValueCount,
	getFilterInputComponent,
	getFilterPlaceholder,
	setFilterDefaultOperator,
	setFilterDefaultValues,
	setFilterConditionValue,
	filtersToServerFormat,
	filtersToClientFormat,
	filterValidate,
	getSearchableColumnOptions,
	getFilterOperatorOptions,
	getCellSlotName,
	isActionsColumn,
	isExtendedActionsColumn,
	isChecklistColumn,
	isDragAndDropColumn,
	hasExtendedAction,
	hasDataAction,
	rowWithoutChildren,
	getColumnHierarchy,
	getPerPageOptions,
	getPerPageMenuVisible,
	numArrayVisibleActions,
	initTableEvents
}
