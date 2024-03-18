import hardcodedTexts from '@/hardcodedTexts.js'
import { loadResources } from '@/plugins/i18n.js'

import { messageTypes } from './quidgest.mainEnums.js'
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
		this.componentOnLoadProc.AddBusy(loadResources(this, this.interfaceMetadata.requiredTextResources), this.Resources[hardcodedTexts.genericLoad], 300)
		this.loadList()
		this.componentOnLoadProc.Once(() => {
			this.setMenuNavProperties()
			this.model.menu.Init()
		}, this)
	},

	mounted()
	{
		this.$eventTracker.addTrace({ origin: 'mounted (menuHandler)', message: 'Menu is mounted', contextData: { menuInfo: this.menuInfo } })

		// Listens for changes to the DB and updates the list accordingly.
		this.$eventHub.onMany(this.model.menu.changeEvents, this.loadList)
	},

	beforeUnmount()
	{
		this.$eventTracker.addTrace({ origin: 'beforeUnmount (menuHandler)', message: 'Menu will be unmounted', contextData: { menuInfo: this.menuInfo } })
		// Removes the listeners.
		this.$eventHub.offMany(this.model.menu.changeEvents, this.loadList)
	},

	computed: {
		/**
		 * True if there are invalid rows, false otherwise.
		 */
		hasInvalidRows()
		{
			if (!Array.isArray(this.model?.menu?.rows))
				return false
			return this.model.menu.rows.filter((row) => !this.model.menu.config.rowValidation.fnValidate(row)).length !== 0
		}
	},

	methods: {
		onBeforeRouteLeave(to, next)
		{
			const buttons = {
				confirm: {
					label: this.Resources[hardcodedTexts.save],
					action: () => {
						if (this.isEmpty(this.model.menu.config.UserTableConfigName))
						{
							this.model.menu.subSignals.viewSave = { show: true, routeTo: to }
							this.model.menu.confirmChanges = false
							next(false)
						}
						else
						{
							this.model.menu.signal = { saveCurrentView: true }
							this.model.menu.confirmChanges = false
							genericFunctions.setNavigationState(false)
							next()
						}
					}
				},
				cancel: {
					label: this.Resources[hardcodedTexts.discard],
					action: () => {
						this.model.menu.confirmChanges = false
						genericFunctions.setNavigationState(false)
						next()
					}
				}
			}

			if (this.model.menu.config.allowManageViews && this.model.menu.confirmChanges)
				genericFunctions.displayMessage(this.Resources[hardcodedTexts.tableViewConfirmSaveChanges], 'warning', null, buttons)
			else
			{
				genericFunctions.setNavigationState(false)
				next()
			}
		},

		/**
		 * Fetches the data of the menu list from the server.
		 * @returns A promise to be resolved after the request completes.
		 */
		async loadList()
		{
			return this.model.menu.Reload()
		},

		/**
		 * Sets the menu's table name in the nav properties.
		 */
		setMenuNavProperties()
		{
			const tableName = this.model.menu.config.tableTitle
			const navProps = {
				navigationId: this.navigationId,
				properties: {
					tableName: tableName
				}
			}
			this.setNavProperties(navProps)
		}
	},

	watch: {
		'model.menu.config.tableTitle'()
		{
			this.setMenuNavProperties()
		},

		hasInvalidRows(val)
		{
			// If there are invalid rows, shows a warning message.
			if (val)
			{
				const warningProps = {
					type: messageTypes.W,
					message: hardcodedTexts.invalidRowsMsg,
					icon: 'error',
					dismissTime: 0,
					isResource: true
				}
				this.setInfoMessage(warningProps)
			}
		}
	}
}
