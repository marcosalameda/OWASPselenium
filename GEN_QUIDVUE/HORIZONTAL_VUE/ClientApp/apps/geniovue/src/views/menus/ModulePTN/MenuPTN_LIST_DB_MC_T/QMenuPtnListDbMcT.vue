<template>
	<teleport
		v-if="menuModalIsReady"
		:to="`#${uiContainersId.body}`"
		:disabled="!menuInfo.isPopup">
		<form
			class="form-horizontal"
			@submit.prevent>
			<q-row-container>
				<q-table
					v-bind="controls.menu"
					v-on="controls.menu.handlers">
				</q-table>

				<q-table-extra-extension
					:list-ctrl="controls.menu"
					v-on="controls.menu.handlers" />
			</q-row-container>
		</form>
	</teleport>

	<teleport
		v-if="menuModalIsReady && hasButtons"
		:to="`#${uiContainersId.footer}`"
		:disabled="!menuInfo.isPopup">
		<q-row-container>
			<div id="footer-action-btns">
				<template
					v-for="btn in menuButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isVisible"
						:id="btn.id"
						:label="btn.text"
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
						:class="btn.classes"
						@click="btn.action">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</div>
		</q-row-container>
	</teleport>
</template>

<script>
	/* eslint-disable no-unused-vars */
	import asyncProcM from '@quidgest/clientapp/composables/async'
	import qEnums from '@quidgest/clientapp/constants/enums'
	import netAPI from '@quidgest/clientapp/network'
	import openQSign from '@quidgest/clientapp/plugins/qSign'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import { computed, readonly } from 'vue'

	import MenuHandlers from '@/mixins/menuHandlers.js'
	import controlClass from '@/mixins/fieldControl.js'
	import listFunctions from '@/mixins/listFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'
	import { resetProgressBar, setProgressBar } from '@/utils/layout.js'

	import { loadResources } from '@/plugins/i18n.js'

	import hardcodedTexts from '@/hardcodedTexts'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	/* eslint-enable no-unused-vars */

	import MenuViewModel from './QMenuPTN_LIST_DB_MC_TViewModel.js'

	const requiredTextResources = ['QMenuPTN_LIST_DB_MC_T', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PTN_MENU_LIST_DB_MC_T]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuPtnListDbMcT',

		mixins: [
			MenuHandlers
		],

		inheritAttrs: false,

		props: {
			/**
			 * Whether or not the menu is used as a homepage.
			 */
			isHomePage: {
				type: Boolean,
				default: false
			}
		},

		expose: [
			'navigationId',
			'onBeforeRouteLeave',
			'updateMenuNavigation'
		],

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuPTN_LIST_DB_MC_T', false),

				interfaceMetadata: {
					id: 'QMenuPTN_LIST_DB_MC_T', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: 'LIST_DB_MC_T',
					isMenuList: true,
					designation: computed(() => this.Resources.DESPESAS23133),
					acronym: 'PTN_LIST_DB_MC_T',
					name: 'EXPEN',
					route: 'menu-PTN_LIST_DB_MC_T',
					order: '3B1',
					controller: 'EXPEN',
					action: 'PTN_Menu_LIST_DB_MC_T',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'PTN_Menu_LIST_DB_MC_T',
						controller: 'EXPEN',
						action: 'PTN_Menu_LIST_DB_MC_T',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Year.ValYear',
								area: 'YEAR',
								field: 'YEAR',
								label: computed(() => this.Resources.ANO33022),
								dataLength: 4,
								scrollData: 4,
								pkColumn: 'ValCodyear',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 2,
								name: 'ValYearnumb',
								area: 'EXPEN',
								field: 'YEARNUMB',
								label: computed(() => this.Resources.ANO_NUMERICO_51058),
								scrollData: 4,
								maxDigits: 4,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 3,
								name: 'Agreg.ValValue',
								area: 'AGREG',
								field: 'VALUE',
								label: computed(() => this.Resources.VALUE10285),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 2,
								pkColumn: 'ValCodaggre',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValDescript',
								area: 'EXPEN',
								field: 'DESCRIPT',
								label: computed(() => this.Resources.DESCRIPTION07383),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 5,
								name: 'ValValue',
								area: 'EXPEN',
								field: 'VALUE',
								label: computed(() => this.Resources.VALUE10285),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 6,
								name: 'ValPrevval',
								area: 'EXPEN',
								field: 'PREVVAL',
								label: computed(() => this.Resources.VALOR_ANTERIOR54849),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'Proje.ValProjecto',
								area: 'PROJE',
								field: 'PROJECTO',
								label: computed(() => this.Resources.PROJECTO50142),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodproje',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'PTN_Menu_LIST_DB_MC_T',
							serverMode: true,
							pkColumn: 'ValCoddespe',
							tableAlias: 'EXPEN',
							tableNamePlural: computed(() => this.Resources.EXPENSES11381),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.DESPESAS23133),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: true,
								searchOnPressEnter: true
							},
							filtersVisible: true,
							allowColumnFilters: true,
							allowColumnSort: true,
							crudActions: [
								{
									id: 'show',
									name: 'show',
									title: computed(() => this.Resources.CONSULTAR57388),
									icon: {
										icon: 'view'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'DESPE',
										mode: 'SHOW',
										isControlled: true
									}
								},
								{
									id: 'edit',
									name: 'edit',
									title: computed(() => this.Resources.EDITAR11616),
									icon: {
										icon: 'pencil'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'DESPE',
										mode: 'EDIT',
										isControlled: true
									}
								},
								{
									id: 'duplicate',
									name: 'duplicate',
									title: computed(() => this.Resources.DUPLICAR09748),
									icon: {
										icon: 'duplicate'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'DESPE',
										mode: 'DUPLICATE',
										isControlled: true
									}
								},
								{
									id: 'delete',
									name: 'delete',
									title: computed(() => this.Resources.ELIMINAR21155),
									icon: {
										icon: 'delete'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'DESPE',
										mode: 'DELETE',
										isControlled: true
									}
								}
							],
							generalActions: [
								{
									id: 'insert',
									name: 'insert',
									title: computed(() => this.Resources.INSERIR43365),
									icon: {
										icon: 'add'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'DESPE',
										mode: 'NEW',
										repeatInsertion: false,
										isControlled: true
									}
								},
							],
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
								{
									id: 'MC_3B11',
									name: 'MC_3B11',
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCoddespe
											},
										],
										action: vm.PTN_MenuTR_3B111, type: 'trigger',
									}
								},
								{
									id: 'MC_3B12',
									name: 'MC_3B12',
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCoddespe
											},
										],
										action: vm.PTN_MenuTR_3B121, type: 'trigger',
									}
								},
							],
							rowClickAction: {
								id: 'RCA_PTN_3B11',
								name: 'PTN_MenuMC_LIST_DB_MC_T',
								params: {
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCoddespe
										},
									],
									action: vm.openRoutineAction, type: 'routine', actionRoutine: this.PTN_MenuMC_LIST_DB_MC_T,
								}
							},
							formsDefinition: {
								'DESPE': {
									fnKeySelector: (row) => row.Fields.ValCoddespe,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValDescript',
							defaultSearchColumnNameOriginal: 'ValDescript',
							defaultColumnSorting: {
								columnName: 'ValDescript',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-PROJE', 'changed-AGREG', 'changed-EXPEN', 'changed-YEAR'],
						uuid: 'd271f8e2-a487-40b9-b6aa-1c69abb862d1',
						allSelectedRows: 'false',
						headerLevel: 1,
					}, this),
				}
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// called before the route that renders this component is confirmed.
			// does NOT have access to `this` component instance,
			// because it has not been created yet when this guard is called!

			next((vm) => vm.updateMenuNavigation(to))
		},

		beforeRouteLeave(to, _, next)
		{
			this.onBeforeRouteLeave(next)
		},

		mounted()
		{
			// Listener for MC action in case of redirect by Jump if just one.
			this.$eventHub.on('EXEC-PTN_MenuMC_LIST_DB_MC_T', this.PTN_MenuMC_LIST_DB_MC_T)
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_CODEJS PTN_MENU_LIST_DB_MC_T]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
			// Listener for MC action in case of redirect by Jump if just one.
			this.$eventHub.off('EXEC-PTN_MenuMC_LIST_DB_MC_T', this.PTN_MenuMC_LIST_DB_MC_T)
		},

		methods: {
			/**
			 * Executes the specific paths with condition action.
			 * @param {string} params The request params
			 * @returns A promise to be resolved after the request completes
			 */
			PTN_MenuMC_LIST_DB_MC_T(params)
			{
				return netAPI.postData(
					this.controls.menu.controller,
					'PTN_MenuMC_LIST_DB_MC_T',
					params,
					(data) => {
						if (data.actionName)
							this.tableListMCAction(this.controls.menu, data.actionName, data.id)
					},
					undefined,
					undefined,
					this.navigationId)
			},

			/**
			 * Execute the triggers of the trigger button 3B111.
			 * Event triggered by a click on the trigger button 3B111.
			 * @param {string} id The primary key of the record
			 */
			// eslint-disable-next-line
			async PTN_MenuTR_3B111(listConf, actionCfg, row)
			{
				const id = row.rowKey

				// Parallel trigger execution.
				await Promise.all([
					Promise.resolve((async () => {
						await this.PTN_MenuTR_3B111_EMPTYDESCRIPTIO2_1(id)
					})()),
				])
			},

			/**
			 * Client-side component of action #1 (FLDUPDT) of trigger EMPTYDESCRIPTIO2.
			 * @param {string} id The primary key of the record
			 */
			// eslint-disable-next-line
			async PTN_MenuTR_3B111_EMPTYDESCRIPTIO2_1(id)
			{
				try
				{
					const data = await netAPI.postData(
						'Expen',
						'PTN_MenuTR_3B111_EMPTYDESCRIPTIO2_1',
						{ key: id },
						undefined,
						undefined,
						undefined,
						this.navigationId)

					if (typeof data.success !== 'string' || typeof data.message !== 'string')
						throw new Error('Invalid data structure.')

					const result = qEnums.messageTypes[data.success]

					if (!this.isEmpty(result))
					{
						if (result !== 'error')
						{
							// Return the promise of followup method.
							return this.PTN_MenuTR_3B111_EMPTYDESCRIPTIO2_2(id)
						}
						else
							genericFunctions.displayMessage(data.message, 'error')
					}
					else
					{
						this.$eventTracker.addError({
							origin: 'Trigger EMPTYDESCRIPTIO2',
							message: 'Routine "PTN_MenuTR_3B111" finished execution with an unknown result type: ' + data.success
						})
					}
				}
				catch (e)
				{
					genericFunctions.displayMessage(this.Resources.NAO_FOI_POSSIVEL_CON65121, 'error')
					this.$eventTracker.addError({
						origin: 'Trigger EMPTYDESCRIPTIO2 (catch)',
						message: e.toString()
					})
				}
			},

			/**
			 * Client-side component of action #2 (PREFRESH) of trigger EMPTYDESCRIPTIO2.
			 * @param {string} id The primary key of the record
			 */
			// eslint-disable-next-line
			async PTN_MenuTR_3B111_EMPTYDESCRIPTIO2_2(id)
			{
				await this.loadList()
			},

			/**
			 * Execute the triggers of the trigger button 3B121.
			 * Event triggered by a click on the trigger button 3B121.
			 * @param {string} id The primary key of the record
			 */
			// eslint-disable-next-line
			async PTN_MenuTR_3B121(listConf, actionCfg, row)
			{
				const id = row.rowKey

				// Parallel trigger execution.
				await Promise.all([
					Promise.resolve((async () => {
						await this.PTN_MenuTR_3B121_FILLDESCRIPTION2_1(id)
					})()),
				])
			},

			/**
			 * Client-side component of action #1 (FLDUPDT) of trigger FILLDESCRIPTION2.
			 * @param {string} id The primary key of the record
			 */
			// eslint-disable-next-line
			async PTN_MenuTR_3B121_FILLDESCRIPTION2_1(id)
			{
				try
				{
					const data = await netAPI.postData(
						'Expen',
						'PTN_MenuTR_3B121_FILLDESCRIPTION2_1',
						{ key: id },
						undefined,
						undefined,
						undefined,
						this.navigationId)

					if (typeof data.success !== 'string' || typeof data.message !== 'string')
						throw new Error('Invalid data structure.')

					const result = qEnums.messageTypes[data.success]

					if (!this.isEmpty(result))
					{
						if (result !== 'error')
						{
							// Return the promise of followup method.
							return this.PTN_MenuTR_3B121_FILLDESCRIPTION2_2(id)
						}
						else
							genericFunctions.displayMessage(data.message, 'error')
					}
					else
					{
						this.$eventTracker.addError({
							origin: 'Trigger FILLDESCRIPTION2',
							message: 'Routine "PTN_MenuTR_3B121" finished execution with an unknown result type: ' + data.success
						})
					}
				}
				catch (e)
				{
					genericFunctions.displayMessage(this.Resources.NAO_FOI_POSSIVEL_CON65121, 'error')
					this.$eventTracker.addError({
						origin: 'Trigger FILLDESCRIPTION2 (catch)',
						message: e.toString()
					})
				}
			},

			/**
			 * Client-side component of action #2 (PREFRESH) of trigger FILLDESCRIPTION2.
			 * @param {string} id The primary key of the record
			 */
			// eslint-disable-next-line
			async PTN_MenuTR_3B121_FILLDESCRIPTION2_2(id)
			{
				await this.loadList()
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS PTN_LIST_DB_MC_T]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS PTN_MENU_LIST_DB_MC_T]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
