import _isEmpty from 'lodash-es/isEmpty'

import { loadResources } from '@/plugins/i18n.js'
import netAPI from '@/api/network'
import listFunctions from './listFunctions.js'
import formFunctions from './formFunctions.js'
import genericFunctions from './genericFunctions.js'
import GenericMenuHandlers from './genericMenuHandlers.js'

/***********************************************************************
 * This mixin defines methods to be reused in regular menu components. *
 ***********************************************************************/
export default {
	mixins: [
		GenericMenuHandlers
	],

	created()
	{
		this.componentOnLoadProc.AddImmediateBusy(loadResources(this, this.interfaceMetadata.requiredTextResources))

		this.setSelectedTab()
		for (let i in this.controls)
			this.controls[i].Init()

		this.fetchListData(this.controls.firstTable, {})
		this.fetchListData(this.controls.secondTable, {})

		this.mainTable.config.showRowsSelectedCount = true
		this.mainTable.config.rowClickActionInternal = 'selectMultiple'
		this.secondaryTable.config.rowClickActionInternal = 'selectSingle'

		// Tweak the configuration of the third table.
		const config = this.controls.thirdTable.config
		config.allowManageViews = false
		config.extendedActions = [
			'remove',
			'remove-reset'
		]
		for (let i in config.permissions)
			config.permissions[i] = false
	},

	computed: {
		/**
		 * A list of the selected item values.
		 */
		selectedItems()
		{
			return Object.values(this.model.selectedRows)
		},

		/**
		 * A list of the selected item keys.
		 */
		selectedItemsKeys()
		{
			return Object.keys(this.mainTable.rowsSelected)
		},

		/**
		 * The key of the currently selected item.
		 */
		selectedItemKey()
		{
			const keys = Object.keys(this.secondaryTable.rowsSelected)
			if (keys.length > 0)
				return keys[0]
			return ''
		}
	},

	methods: {
		/**
		 * Unselects all the rows.
		 */
		clearSelectedRows()
		{
			// Unselect all rows.
			this.onUnselectAllRows(this.mainTable)

			// Clears the selected rows hash table.
			this.unselectAllRowsData()
		},

		/**
		 * Handles the event of selection/checking a row.
		 * @param {string} tableConf The table configuration
		 * @param {string} rowKey The id of the row
		 */
		handleSelectedRow(tableConf, rowKey)
		{
			this.onSelectRow(tableConf, { rowKeyPath: rowKey, multipleSelection: true })
			this.selectRowData(rowKey)
		},

		/**
		 * Handles the event of unselection/unchecking a row.
		 * @param {string} tableConf The table configuration
		 * @param {string} rowKey The id of the row
		 */
		handleUnSelectedRow(tableConf, rowKey)
		{
			this.onUnselectRow(tableConf, rowKey)
			this.unselectRowData(rowKey)
		},

		/**
		 * Handles the event of selection/checking rows.
		 * @param {string} tableConf The table configuration
		 * @param {array} rowKeys Array of row IDs
		 */
		handleSelectedRows(tableConf, rowKeys)
		{
			this.onSelectRows(tableConf, rowKeys)
			this.selectRowsData(rowKeys)
		},

		/**
		 * Handles the event of selection/checking rows.
		 * @param {string} tableConf The table configuration
		 */
		handleUnselectAllRows(tableConf)
		{
			this.onUnselectAllRows(tableConf)
			this.unselectAllRowsData()
		},

		/**
		 * Updates the rows of the second table after selecting something in the first.
		 * @param {string} baseArea The name of the table area
		 */
		updateListData(baseArea)
		{
			// Unselect all rows and clear selected rows hash table.
			this.clearSelectedRows()

			// Clears all the table rows.
			this.controls.secondTable.rows = []

			// Reload table with related records.
			if (!_isEmpty(baseArea) && this.selectedItemKey !== '')
			{
				const queryParams = {}
				queryParams[baseArea] = this.selectedItemKey
				this.fetchListData(this.controls.secondTable, { queryParams })
			}
		},

		/**
		 * Saves the changes.
		 * @param {string} action The name of the controller action
		 * @param {boolean} reloadTable Whether or not the related table should be reloaded
		 * @param {string} baseArea The name of the table area
		 */
		apply(action, reloadTable = false, baseArea)
		{
			if (_isEmpty(action))
				return

			const params = {
				selected_ids: this.selectedItemsKeys,
				dest_id: this.selectedItemKey
			}

			//Add all Selected
			let allSelected = this.navigation.currentLevel.params.allSelected || []
			if (allSelected.findIndex(e => e === this.controls.firstTable.id) !== -1)
				params.allSelected = true

			let tableParams = this.navigation.currentLevel.params.qTableQueryParams || {}
			if(tableParams[this.controls.firstTable.id])
				params.queryParams = tableParams[this.controls.firstTable.id].queryParams;
			else
				params.queryParams = null;
	
			netAPI.postData(this.controls.firstTable.controller, action, params, (data) => {
				this.fetchListData(this.controls.firstTable, {})

				// Reload table with related records.
				if (reloadTable && !_isEmpty(baseArea))
				{
					const queryParams = {}
					queryParams[baseArea] = this.selectedItemKey
					this.fetchListData(this.controls.secondTable, { queryParams })
				}

				var msgType = 'error'
				if (data.Success === true)
				{
					this.clearSelectedRows()
					msgType = 'success'
				}

				genericFunctions.displayMessage(data.Message, msgType)
			}, undefined, undefined, this.navigationId)
		},

		/**
		 * Add row to hash table of selected rows.
		 * @param {string} rowKey The id of the row
		 */
		selectRowData(rowKey)
		{
			var rowKeys = {}
			rowKeys[rowKey] = true

			var rows = this.mainTable.rows,
				selectedRows = listFunctions.getRowsFromKeyHash(rows, rowKeys)

			if (selectedRows.length < 1)
				return

			this.model.selectedRows[rowKey] = selectedRows[0]
		},

		/**
		 * Add rows to hash table of selected rows.
		 * @param {object} rowKeys The ID of the rows
		 */
		selectRowsData(rowKeys)
		{
			var rows = this.mainTable.rows,
				selectedRows = listFunctions.getRowsFromKeyHash(rows, rowKeys)

			if (selectedRows.length < 1)
				return

			for (let idx in selectedRows)
				this.model.selectedRows[selectedRows[idx].rowKey] = selectedRows[idx]
		},

		/**
		 * Remove row from hash table of selected rows.
		 * @param {string} rowKey The id of the row
		 */
		unselectRowData(rowKey)
		{
			delete this.model.selectedRows[rowKey]
		},

		/**
		 * Remove all rows from hash table of selected rows.
		 */
		unselectAllRowsData()
		{
			this.model.selectedRows = {}
		},

		/**
		 * Sets the selected tab, according to the value in the store.
		 */
		setSelectedTab()
		{
			const areaName = this.menuInfo.area
			const menuName = this.menuInfo.name

			if (!formFunctions.validateStoredValues(areaName, this.containersState, this.menuInfo))
				return

			const selectedTab = this.containersState[areaName][areaName][menuName].tabGroup
			if (selectedTab && typeof selectedTab === 'string')
				this.controls.tabGroup.SelectTab(selectedTab)
		}
	},

	watch: {
		'controls.tabGroup.selectedTab'(newVal)
		{
			const data = {
				navigationId: this.navigationId,
				key: this.menuInfo.area,
				formInfo: this.menuInfo,
				fieldId: 'tabGroup',
				containerState: newVal
			}

			this.storeContainerState(data)
		}
	}
}
