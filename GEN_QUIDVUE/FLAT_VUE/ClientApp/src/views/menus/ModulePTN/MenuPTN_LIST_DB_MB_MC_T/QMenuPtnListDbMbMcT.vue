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
						:b-style="btn.style"
						:disabled="btn.disabled"
						:icon-on-right="btn.iconOnRight"
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
	import { computed, readonly } from 'vue'

	import MenuHandlers from '@/mixins/menuHandlers.js'
	import controlClass from '@/mixins/fieldControl.js'
	import listFunctions from '@/mixins/listFunctions.js'
	import genericFunctions from '@/mixins/genericFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'

	import { loadResources } from '@/plugins/i18n.js'
	import asyncProcM from '@/api/global/asyncProcMonitoring.js'

	import hardcodedTexts from '@/hardcodedTexts'
	import netAPI from '@/api/network'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	import qEnums from '@/mixins/quidgest.mainEnums.js'
	/* eslint-enable no-unused-vars */

	import MenuViewModel from './QMenuPTN_LIST_DB_MB_MC_TViewModel.js'

	const requiredTextResources = ['QMenuPTN_LIST_DB_MB_MC_T', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PTN_MENU_LIST_DB_MB_MC_T]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuPtnListDbMbMcT',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuPTN_LIST_DB_MB_MC_T', false),

				interfaceMetadata: {
					id: 'QMenuPTN_LIST_DB_MB_MC_T', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: 'LIST_DB_MB_MC_T',
					isMenuList: true,
					designation: computed(() => this.Resources.DESPESAS23133),
					acronym: 'PTN_LIST_DB_MB_MC_T',
					name: 'EXPEN',
					route: 'menu-PTN_LIST_DB_MB_MC_T',
					order: '3C1',
					controller: 'EXPEN',
					action: 'PTN_Menu_LIST_DB_MB_MC_T',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'PTN_Menu_LIST_DB_MB_MC_T',
						controller: 'EXPEN',
						action: 'PTN_Menu_LIST_DB_MB_MC_T',
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
							}),
							new listColumnTypes.NumericColumn({
								order: 2,
								name: 'ValYearnumb',
								area: 'EXPEN',
								field: 'YEARNUMB',
								label: computed(() => this.Resources.ANO_NUMERICO_51058),
								scrollData: 4,
								maxDigits: 4,
								decimalPlaces: 0,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 3,
								name: 'Agreg.ValValue',
								area: 'AGREG',
								field: 'VALUE',
								label: computed(() => this.Resources.VALUE10285),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 0,
								pkColumn: 'ValCodaggre',
							}),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValDescript',
								area: 'EXPEN',
								field: 'DESCRIPT',
								label: computed(() => this.Resources.DESCRIPTION07383),
								dataLength: 85,
								scrollData: 30,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 5,
								name: 'ValValue',
								area: 'EXPEN',
								field: 'VALUE',
								label: computed(() => this.Resources.VALUE10285),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 0,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 6,
								name: 'ValPrevval',
								area: 'EXPEN',
								field: 'PREVVAL',
								label: computed(() => this.Resources.VALOR_ANTERIOR54849),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 0,
							}),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'Proje.ValProjecto',
								area: 'PROJE',
								field: 'PROJECTO',
								label: computed(() => this.Resources.PROJECTO50142),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodproje',
							}),
						],
						config: {
							name: 'PTN_Menu_LIST_DB_MB_MC_T',
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
								{
									id: 'MB_BUTTONTRIGGERTEST2',
									name: 'PTN_MenuMC_BUTTONTRIGGERTEST2',
									title: computed(() => this.Resources.EXECUTE33784),
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCoddespe
											},
										],
										action: vm.openRoutineAction, type: 'routine', actionRoutine: this.PTN_MenuMC_BUTTONTRIGGERTEST2,
									}
								},
							],
							MCActions: [
								{
									id: 'MC_3C111',
									name: 'MC_3C111',
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCoddespe
											},
										],
										action: vm.PTN_MenuTR_3C1111, type: 'trigger',
									}
								},
								{
									id: 'MC_3C112',
									name: 'MC_3C112',
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCoddespe
											},
										],
										action: vm.PTN_MenuTR_3C1121, type: 'trigger',
									}
								},
							],
							rowClickAction: {
								id: 'RCA_PTN_3C111',
								name: 'PTN_MenuMC_BUTTONTRIGGERTEST2',
								params: {
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCoddespe
										},
									],
									action: vm.openRoutineAction, type: 'routine', actionRoutine: this.PTN_MenuMC_BUTTONTRIGGERTEST2,
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
						changeEvents: ['changed-YEAR', 'changed-PROJE', 'changed-AGREG', 'changed-EXPEN'],
						uuid: 'eba2dc82-74d0-42e8-8065-49dba77ea064',
						allSelectedRows: 'false',
						headerLevel: 1,
					}, this)
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
			this.onBeforeRouteLeave(to, next)
		},

		mounted()
		{
			// Listener for MC action in case of redirect by Jump if just one.
			this.$eventHub.on('EXEC-PTN_MenuMC_BUTTONTRIGGERTEST2', this.PTN_MenuMC_BUTTONTRIGGERTEST2)
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_CODEJS PTN_MENU_LIST_DB_MB_MC_T]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
			// Listener for MC action in case of redirect by Jump if just one.
			this.$eventHub.off('EXEC-PTN_MenuMC_BUTTONTRIGGERTEST2', this.PTN_MenuMC_BUTTONTRIGGERTEST2)
		},

		methods: {
			/**
			 * Executes the specific paths with condition action.
			 * @param {string} params The request params
			 * @returns A promise to be resolved after the request completes
			 */
			PTN_MenuMC_BUTTONTRIGGERTEST2(params)
			{
				return netAPI.postData(this.controls.menu.controller, 'PTN_MenuMC_BUTTONTRIGGERTEST2', params, (data) => {
					if (data.actionName)
						this.tableListMCAction(this.controls.menu, data.actionName, data.id)
				}, undefined, undefined, this.navigationId)
			},

			/**
			 * Execute the triggers of the trigger button 3C1111.
			 * Event triggered by a click on the trigger button 3C1111.
			 * @param {string} id The primary key of the record
			 */
			// eslint-disable-next-line
			async PTN_MenuTR_3C1111(listConf, actionCfg, row)
			{
				const id = row.rowKey

				// Parallel trigger execution.
				await Promise.all([
					Promise.resolve((async () => {
						await this.PTN_MenuTR_3C1111_EMPTYDESCRIPTION_1(id)
					})()),
				])
			},

			/**
			 * Client-side component of action #1 (FLDUPDT) of trigger EMPTYDESCRIPTION.
			 * @param {string} id The primary key of the record
			 */
			// eslint-disable-next-line
			async PTN_MenuTR_3C1111_EMPTYDESCRIPTION_1(id)
			{
				netAPI.postData(
					'Expen',
					'PTN_MenuTR_3C1111_EMPTYDESCRIPTION_1',
					{ key: id },
					async (data) => {
						try
						{
							if (typeof data.success !== 'string' || typeof data.message !== 'string')
								throw new Error('Invalid data structure.')

							const result = qEnums.messageTypes[data.success]
							if (!this.isEmpty(result))
							{
								await this.PTN_MenuTR_3C1111_EMPTYDESCRIPTION_2(id)
							}
							else
								this.$eventTracker.addError({ origin: 'Trigger EMPTYDESCRIPTION', message: 'Routine "PTN_MenuTR_3C1111" finished execution with an unknown result type: ' + data.success })
						}
						catch (e)
						{
							genericFunctions.displayMessage(this.Resources.NAO_FOI_POSSIVEL_CON65121, 'error')
							this.$eventTracker.addError({ origin: 'Trigger EMPTYDESCRIPTION (catch)', message: e.toString() })
						}
					}, () => {
						genericFunctions.displayMessage(this.Resources.NAO_FOI_POSSIVEL_CON65121, 'error')
					},
					undefined,
					this.navigationId)
			},

			/**
			 * Client-side component of action #2 (PREFRESH) of trigger EMPTYDESCRIPTION.
			 * @param {string} id The primary key of the record
			 */
			// eslint-disable-next-line
			async PTN_MenuTR_3C1111_EMPTYDESCRIPTION_2(id)
			{
				await this.loadList()
			},

			/**
			 * Execute the triggers of the trigger button 3C1121.
			 * Event triggered by a click on the trigger button 3C1121.
			 * @param {string} id The primary key of the record
			 */
			// eslint-disable-next-line
			async PTN_MenuTR_3C1121(listConf, actionCfg, row)
			{
				const id = row.rowKey

				// Parallel trigger execution.
				await Promise.all([
					Promise.resolve((async () => {
						await this.PTN_MenuTR_3C1121_FILLDESCRIPTION_1(id)
					})()),
				])
			},

			/**
			 * Client-side component of action #1 (FLDUPDT) of trigger FILLDESCRIPTION.
			 * @param {string} id The primary key of the record
			 */
			// eslint-disable-next-line
			async PTN_MenuTR_3C1121_FILLDESCRIPTION_1(id)
			{
				netAPI.postData(
					'Expen',
					'PTN_MenuTR_3C1121_FILLDESCRIPTION_1',
					{ key: id },
					async (data) => {
						try
						{
							if (typeof data.success !== 'string' || typeof data.message !== 'string')
								throw new Error('Invalid data structure.')

							const result = qEnums.messageTypes[data.success]
							if (!this.isEmpty(result))
							{
								await this.PTN_MenuTR_3C1121_FILLDESCRIPTION_2(id)
							}
							else
								this.$eventTracker.addError({ origin: 'Trigger FILLDESCRIPTION', message: 'Routine "PTN_MenuTR_3C1121" finished execution with an unknown result type: ' + data.success })
						}
						catch (e)
						{
							genericFunctions.displayMessage(this.Resources.NAO_FOI_POSSIVEL_CON65121, 'error')
							this.$eventTracker.addError({ origin: 'Trigger FILLDESCRIPTION (catch)', message: e.toString() })
						}
					}, () => {
						genericFunctions.displayMessage(this.Resources.NAO_FOI_POSSIVEL_CON65121, 'error')
					},
					undefined,
					this.navigationId)
			},

			/**
			 * Client-side component of action #2 (PREFRESH) of trigger FILLDESCRIPTION.
			 * @param {string} id The primary key of the record
			 */
			// eslint-disable-next-line
			async PTN_MenuTR_3C1121_FILLDESCRIPTION_2(id)
			{
				await this.loadList()
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS PTN_LIST_DB_MB_MC_T]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS PTN_MENU_LIST_DB_MB_MC_T]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
