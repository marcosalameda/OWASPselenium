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

	import MenuViewModel from './QMenuPTN_LIST_DB_MB_MC_RViewModel.js'

	const requiredTextResources = ['QMenuPTN_LIST_DB_MB_MC_R', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PTN_MENU_LIST_DB_MB_MC_R]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuPtnListDbMbMcR',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuPTN_LIST_DB_MB_MC_R', false),

				interfaceMetadata: {
					id: 'QMenuPTN_LIST_DB_MB_MC_R', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: 'LIST_DB_MB_MC_R',
					isMenuList: true,
					designation: computed(() => this.Resources.ARTICLES59822),
					acronym: 'PTN_LIST_DB_MB_MC_R',
					name: 'ITEM',
					route: 'menu-PTN_LIST_DB_MB_MC_R',
					order: '3A1',
					controller: 'ITEM',
					action: 'PTN_Menu_LIST_DB_MB_MC_R',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'PTN_Menu_LIST_DB_MB_MC_R',
						controller: 'ITEM',
						action: 'PTN_Menu_LIST_DB_MB_MC_R',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.ImageColumn({
								order: 1,
								name: 'ValImage',
								area: 'ITEM',
								field: 'IMAGE',
								label: computed(() => this.Resources.IMAGE65174),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.IMAGE65174)),
								scrollData: 3,
								sortable: false,
								searchable: false,
							}),
							new listColumnTypes.DateColumn({
								order: 2,
								name: 'ValDate',
								area: 'ITEM',
								field: 'DATE',
								label: computed(() => this.Resources.DATE18475),
								scrollData: 8,
								dateTimeType: 'date',
							}),
							new listColumnTypes.ArrayColumn({
								order: 3,
								name: 'ValDisponib',
								area: 'ITEM',
								field: 'DISPONIB',
								label: computed(() => this.Resources.AVAILABILITY56489),
								dataLength: 1,
								scrollData: 1,
								array: qProjArrays.QArrayDsiponib.setResources(vm.$getResource).elements,
								arrayType: qProjArrays.QArrayDsiponib.type,
							}),
							new listColumnTypes.BooleanColumn({
								order: 4,
								name: 'ValValid',
								area: 'ITEM',
								field: 'VALID',
								label: computed(() => this.Resources.IN_USE42606),
								scrollData: 1,
							}),
						],
						config: {
							name: 'PTN_Menu_LIST_DB_MB_MC_R',
							serverMode: true,
							pkColumn: 'ValCoditem',
							tableAlias: 'ITEM',
							tableNamePlural: computed(() => this.Resources.ARTICLES59822),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.ARTICLES59822),
							showAlternatePagination: true,
							permissions: {
								canView: false,
								canEdit: false,
								canDuplicate: false,
								canDelete: false,
								canInsert: false
							},
							searchBarConfig: {
								visibility: true,
								searchOnPressEnter: true
							},
							filtersVisible: true,
							allowColumnFilters: true,
							allowColumnSort: true,
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
								{
									id: 'MB_3A11',
									name: 'PTN_MenuMC_3A11',
									title: computed(() => this.Resources.EXECUTE33784),
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCoditem
											},
										],
										action: vm.openRoutineAction, type: 'routine', actionRoutine: this.PTN_MenuMC_3A11,
									}
								},
							],
							MCActions: [
								{
									id: 'MC_3A111',
									name: 'MC_3A111',
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCoditem
											},
										],
										action: vm.openRoutineAction, type: 'routine', actionRoutine: this.PTN_Menu_LIST_DB_MB_MC_R_MenuR_OPENARTIGVAL,
									}
								},
								{
									id: 'MC_3A112',
									name: 'MC_3A112',
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCoditem
											},
										],
										action: vm.openRoutineAction, type: 'routine', actionRoutine: this.PTN_Menu_LIST_DB_MB_MC_R_MenuR_OPENARTIGINV,
									}
								},
							],
							rowClickAction: {
								id: 'RCA_PTN_3A111',
								name: 'PTN_MenuMC_3A11',
								params: {
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCoditem
										},
									],
									action: vm.openRoutineAction, type: 'routine', actionRoutine: this.PTN_MenuMC_3A11, restrictedModes: true,
								}
							},
							formsDefinition: {
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-WAREH', 'changed-GITEM', 'changed-ITEM'],
						uuid: '6ef09042-07c7-4515-a46d-6e9b3833501c',
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
			this.$eventHub.on('EXEC-PTN_MenuMC_3A11', this.PTN_MenuMC_3A11)
			this.$eventHub.on('EXEC-MENU-ROUTINE-PTN_LIST_DB_MB_MC_R', this.onExecRoutineEvent)

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_CODEJS PTN_MENU_LIST_DB_MB_MC_R]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
			// Listener for MC action in case of redirect by Jump if just one.
			this.$eventHub.off('EXEC-PTN_MenuMC_3A11', this.PTN_MenuMC_3A11)
			this.$eventHub.off('EXEC-MENU-ROUTINE-PTN_LIST_DB_MB_MC_R', this.onExecRoutineEvent)
		},

		methods: {
			/**
			 * Executes the specific paths with condition action.
			 * @param {string} params The request params
			 * @returns A promise to be resolved after the request completes
			 */
			PTN_MenuMC_3A11(params)
			{
				return netAPI.postData(this.controls.menu.controller, 'PTN_MenuMC_3A11', params, (data) => {
					if (data.actionName)
						this.tableListMCAction(this.controls.menu, data.actionName, data.id)
				}, undefined, undefined, this.navigationId)
			},
			/**
			 * Callback function for the routines.
			 * @param {object} eventData The event data
			 */
			onExecRoutineEvent(eventData)
			{
				if (typeof this[eventData.routineName] === 'function')
					this[eventData.routineName].call(this, eventData.params)
			},

			// eslint-disable-next-line
			PTN_MenuR_OPENARTIGVAL(jsonRouteValues, fnAfterConfirm)
			{
				// The fnAfterConfirm (e.g., the Apply function of the form) - will only be executed if the user confirms that he wants to execute the routine.
				// This method needs to internally execute the PTN_MenuR_OPENARTIGVAL_Success method.
				const buttons = {
					confirm: {
						label: this.Resources.CONTINUAR44831,
						action: () => {
							this.$eventTracker.addTrace({
								origin: 'Routine OPENARTIGVAL',
								message: 'Execution confirmed'
							})

							typeof fnAfterConfirm === 'function' ? fnAfterConfirm(jsonRouteValues) : this.PTN_MenuR_OPENARTIGVAL_Success(jsonRouteValues)
						}
					},
					cancel: {
						label: this.Resources.CANCELAR49513
					}
				}
				genericFunctions.displayMessage(this.Resources.THIS_ROUTINE_WILL_OP46015, 'warning', null, buttons)
			},

			// eslint-disable-next-line
			PTN_MenuR_OPENARTIGVAL_Success(jsonRouteValues)
			{
				this.$eventTracker.addTrace({
					origin: 'Routine OPENARTIGVAL',
					message: 'Start of execution of the manual routine'
				})

/* eslint-disable indent, vue/html-indent, vue/script-indent */
//Platform: VUE | Type: VIEW_MANUAL_ROUTINE | Module: GQT | Parameter: OPENARTIGVAL | File:  | Order: 0
//BEGIN_MANUALCODE_CODMANUA:0a225218-aa2f-4267-a8bc-24d64a18a8c5
                const params = {
                    id: jsonRouteValues.id,
                    mode: qEnums.formModes.show,
                    modes: this.navigation.currentLevel.params.modes,
                    isControlled: false
                }

                this.navigateToForm("ARTIGVAL", qEnums.formModes.show, null, params)
//END_MANUALCODE
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			PTN_Menu_LIST_DB_MB_MC_R_MenuR_OPENARTIGVAL(jsonRouteValues, fnAfterConfirm)
			{
				jsonRouteValues.action = 'PTN_Menu_LIST_DB_MB_MC_R_MenuR_OPENARTIGVAL'
				this.PTN_MenuR_OPENARTIGVAL(jsonRouteValues, fnAfterConfirm)
			},

			// eslint-disable-next-line
			PTN_MenuR_OPENARTIGINV(jsonRouteValues, fnAfterConfirm)
			{
				// The fnAfterConfirm (e.g., the Apply function of the form) - will only be executed if the user confirms that he wants to execute the routine.
				// This method needs to internally execute the PTN_MenuR_OPENARTIGINV_Success method.
				const buttons = {
					confirm: {
						label: this.Resources.CONTINUAR44831,
						action: () => {
							this.$eventTracker.addTrace({
								origin: 'Routine OPENARTIGINV',
								message: 'Execution confirmed'
							})

							typeof fnAfterConfirm === 'function' ? fnAfterConfirm(jsonRouteValues) : this.PTN_MenuR_OPENARTIGINV_Success(jsonRouteValues)
						}
					},
					cancel: {
						label: this.Resources.CANCELAR49513
					}
				}
				genericFunctions.displayMessage(this.Resources.THIS_ROUTINE_WILL_OP46015, 'warning', null, buttons)
			},

			// eslint-disable-next-line
			PTN_MenuR_OPENARTIGINV_Success(jsonRouteValues)
			{
				this.$eventTracker.addTrace({
					origin: 'Routine OPENARTIGINV',
					message: 'Start of execution of the manual routine'
				})

/* eslint-disable indent, vue/html-indent, vue/script-indent */
//Platform: VUE | Type: VIEW_MANUAL_ROUTINE | Module: GQT | Parameter: OPENARTIGINV | File:  | Order: 0
//BEGIN_MANUALCODE_CODMANUA:31383609-4f2f-4835-96cf-d9ffb74153cc
                const params = {
                    id: jsonRouteValues.id,
                    mode: qEnums.formModes.show,
                    modes: this.navigation.currentLevel.params.modes,
                    isControlled: false
                }

                this.navigateToForm("ARTIGINV", qEnums.formModes.show, null, params)
//END_MANUALCODE
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			PTN_Menu_LIST_DB_MB_MC_R_MenuR_OPENARTIGINV(jsonRouteValues, fnAfterConfirm)
			{
				jsonRouteValues.action = 'PTN_Menu_LIST_DB_MB_MC_R_MenuR_OPENARTIGINV'
				this.PTN_MenuR_OPENARTIGINV(jsonRouteValues, fnAfterConfirm)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS PTN_LIST_DB_MB_MC_R]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS PTN_MENU_LIST_DB_MB_MC_R]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
