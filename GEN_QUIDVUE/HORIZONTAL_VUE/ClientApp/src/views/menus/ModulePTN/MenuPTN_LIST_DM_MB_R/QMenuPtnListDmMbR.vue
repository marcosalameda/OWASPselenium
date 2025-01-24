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

	import MenuViewModel from './QMenuPTN_LIST_DM_MB_RViewModel.js'

	const requiredTextResources = ['QMenuPTN_LIST_DM_MB_R', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PTN_MENU_LIST_DM_MB_R]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuPtnListDmMbR',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuPTN_LIST_DM_MB_R', false),

				interfaceMetadata: {
					id: 'QMenuPTN_LIST_DM_MB_R', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: 'LIST_DM_MB_R',
					isMenuList: true,
					designation: computed(() => this.Resources.LENDING18782),
					acronym: 'PTN_LIST_DM_MB_R',
					name: 'LENDI',
					route: 'menu-PTN_LIST_DM_MB_R',
					order: '3I1',
					controller: 'LENDI',
					action: 'PTN_Menu_LIST_DM_MB_R',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'PTN_Menu_LIST_DM_MB_R',
						controller: 'LENDI',
						action: 'PTN_Menu_LIST_DM_MB_R',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Pess1.ValName',
								area: 'PESS1',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodpesso',
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'Equip.ValRegistnr',
								area: 'EQUIP',
								field: 'REGISTNR',
								label: computed(() => this.Resources.NO__REGISTER04207),
								dataLength: 6,
								scrollData: 6,
								pkColumn: 'ValCodequip',
							}),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'Pess2.ValName',
								area: 'PESS2',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodpesso',
							}),
							new listColumnTypes.NumericColumn({
								order: 4,
								name: 'ValLendinnr',
								area: 'LENDI',
								field: 'LENDINNR',
								label: computed(() => this.Resources.NO__OF_THE_DADATO35934),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}),
							new listColumnTypes.DateColumn({
								order: 5,
								name: 'ValStart',
								area: 'LENDI',
								field: 'START',
								label: computed(() => this.Resources.BEGINNING18124),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.DateColumn({
								order: 6,
								name: 'ValWarndt',
								area: 'LENDI',
								field: 'WARNDT',
								label: computed(() => this.Resources.WARNING52043),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.DateColumn({
								order: 7,
								name: 'ValEnd',
								area: 'LENDI',
								field: 'END',
								label: computed(() => this.Resources.END47577),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.TextColumn({
								order: 8,
								name: 'ValObservat',
								area: 'LENDI',
								field: 'OBSERVAT',
								label: computed(() => this.Resources.OBSERVATIONS03729),
								scrollData: 30,
							}),
							new listColumnTypes.DateColumn({
								order: 9,
								name: 'ValReturndt',
								area: 'LENDI',
								field: 'RETURNDT',
								label: computed(() => this.Resources.RETURN32222),
								scrollData: 8,
								dateTimeType: 'date',
							}),
							new listColumnTypes.BooleanColumn({
								order: 10,
								name: 'ValReturned',
								area: 'LENDI',
								field: 'RETURNED',
								label: computed(() => this.Resources.RETURNED01606),
								scrollData: 1,
							}),
							new listColumnTypes.NumericColumn({
								order: 11,
								name: 'ValDayslimi',
								area: 'LENDI',
								field: 'DAYSLIMI',
								label: computed(() => this.Resources.DAYS_FOR_RETURN_PERI04559),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
							new listColumnTypes.BooleanColumn({
								order: 12,
								name: 'ValIfoutdt',
								area: 'LENDI',
								field: 'IFOUTDT',
								label: computed(() => this.Resources.IF_OUT_OF_DATE49042),
								scrollData: 1,
							}),
						],
						config: {
							name: 'PTN_Menu_LIST_DM_MB_R',
							serverMode: true,
							pkColumn: 'ValCodlendi',
							tableAlias: 'LENDI',
							tableNamePlural: computed(() => this.Resources.LENDING18782),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.LENDING18782),
							showAlternatePagination: true,
							rowClickActionInternal: 'selectMultiple',
							showRowsSelectedCount: true,
							showRowsSelectedTotalizer: true,
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
							crudActions: [
							],
							generalActions: [
							],
							generalCustomActions: [
								{
									id: 'MB_3I13',
									name: 'PTN_Menu_LIST_DM_MB_R_MenuR_DELETEROWS',
									title: computed(() => this.Resources.DELETE_OPTIONAL_RECO37994),
									icon: {
										icon: 'delete',
										type: 'svg',
									},
									params: {
										action: vm.openRoutineAction, type: 'routine', actionRoutine: this.PTN_Menu_LIST_DM_MB_R_MenuR_DELETEROWS,
									}
								},
							],
							groupActions: [
								{
									id: 'MB_D',
									name: 'PTN_Menu_LIST_DM_MB_R_MenuR_DELETEROWS',
									title: computed(() => this.Resources.DELETE_MULTIPLE_RECO17551),
									icon: {
										icon: 'delete',
										type: 'svg',
									},
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCodlendi
											},
										],
										action: vm.openRoutineAction, type: 'routine', actionRoutine: this.PTN_Menu_LIST_DM_MB_R_MenuR_DELETEROWS,
									}
								},
							],
							customActions: [
								{
									id: 'MB_BUTTONDELETEROW',
									name: 'PTN_Menu_LIST_DM_MB_R_MenuR_DELETEONEROW',
									title: computed(() => this.Resources.DELETE_SINGLE_RECORD05929),
									icon: {
										icon: 'delete',
										type: 'svg',
									},
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCodlendi
											},
										],
										action: vm.openRoutineAction, type: 'routine', actionRoutine: this.PTN_Menu_LIST_DM_MB_R_MenuR_DELETEONEROW,
									}
								},
							],
							MCActions: [
							],
							rowClickAction: {
							},
							formsDefinition: {
								'COMOD': {
									fnKeySelector: (row) => row.Fields.ValCodlendi,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValLendinnr',
							defaultSearchColumnNameOriginal: 'ValLendinnr',
							defaultColumnSorting: {
								columnName: 'ValStart',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-LENDI', 'changed-EQUIP', 'changed-PESS2', 'changed-PESS1'],
						uuid: '5e4e7e69-c5b2-478b-bb88-e077baaaf55b',
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
			this.$eventHub.on('EXEC-MENU-ROUTINE-PTN_LIST_DM_MB_R', this.onExecRoutineEvent)

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_CODEJS PTN_MENU_LIST_DM_MB_R]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
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
			PTN_MenuR_DELETEONEROW(jsonRouteValues, fnAfterConfirm)
			{
				// The fnAfterConfirm (e.g., the Apply function of the form) - will only be executed if the user confirms that he wants to execute the routine.
				// This method needs to internally execute the PTN_MenuR_DELETEONEROW_Success method.
				const buttons = {
					confirm: {
						label: this.Resources.CONTINUAR44831,
						action: () => {
							this.$eventTracker.addTrace({
								origin: 'Routine DELETEONEROW',
								message: 'Execution confirmed'
							})

							typeof fnAfterConfirm === 'function' ? fnAfterConfirm(jsonRouteValues) : this.PTN_MenuR_DELETEONEROW_Success(jsonRouteValues)
						}
					},
					cancel: {
						label: this.Resources.CANCELAR49513
					}
				}
				genericFunctions.displayMessage(this.Resources.DO_YOU_WANT_TO_DELET18100, 'warning', null, buttons)
			},

			// eslint-disable-next-line
			PTN_MenuR_DELETEONEROW_Success(jsonRouteValues)
			{
				this.$eventTracker.addTrace({
					origin: 'Routine DELETEONEROW',
					message: 'Start of execution of the manual routine'
				})

				genericFunctions.setProgressBar({ title: computed(() => this.Resources.PROCESSING44327) })

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT VIEW_MANUAL_ROUTINE DELETEONEROW]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.PTN_MenuR_DELETEONEROW_BeforeSend(jsonRouteValues).then((result) => {
					return this.PTN_MenuR_DELETEONEROW_AjaxCall(result)
				})
			},

			PTN_MenuR_DELETEONEROW_AjaxCall(jsonRouteValues)
			{
				if (typeof jsonRouteValues !== 'object' || typeof jsonRouteValues.action !== 'string')
				{
					this.$eventTracker.addError({
						origin: 'Routine DELETEONEROW',
						message: 'Parameter "jsonRouteValues" has a wrong format.'
					})
					return
				}

				const params = jsonRouteValues

				this.$eventTracker.addTrace({
					origin: 'Routine DELETEONEROW',
					message: 'Ajax call method',
					contextData: { params }
				})

				/*
				 * This param can come from the jsonRouteValues that come from the
				 * component in case of forms, for example. We do not want to replace
				 * it with this new one!
				 */
				if (typeof params.allSelected === 'undefined')
				{
					// Check for all selected rows.
					const allSelected = this.navigation.currentLevel.params.allSelected ?? []
					const tblId = 'PTN_Menu_LIST_DM_MB_R'
					params.allSelected = allSelected.findIndex((e) => e === tblId) !== -1
				}

				netAPI.postData(
					'Lendi',
					params.action,
					params,
					// eslint-disable-next-line
					(data) => {
						genericFunctions.resetProgressBar()

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT DONE_ROUTINE DELETEONEROW]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

						// DISCLAIMER: Adding code to "DONE_ROUTINE" will override the code below.
						try
						{
							if (typeof data.success !== 'string' || typeof data.message !== 'string')
								throw new Error('Invalid data structure.')

							const result = qEnums.messageTypes[data.success]
							if (!genericFunctions.isEmpty(result))
							{
								this.$eventTracker.addTrace({
									origin: 'Routine DELETEONEROW',
									message: 'Manual routine "DELETEONEROW" finished execution with result: ' + qEnums.messageTypes[data.success]
								})

								const message = data.message

								if (!genericFunctions.isEmpty(message))
								{
									const buttons = {
										confirm: {
											label: this.Resources.OK15819,
											action: () => this.PTN_MenuR_DELETEONEROW_AfterDone(data)
										}
									}

									genericFunctions.displayMessage(message, result, null, buttons)
								}
								else
									this.PTN_MenuR_DELETEONEROW_AfterDone(data)
							}
							else
							{
								this.$eventTracker.addError({
									origin: 'Routine DELETEONEROW',
									message: 'Routine "DELETEONEROW" finished execution with an unknown result type: ' + data.success
								})
							}
						}
						catch (e)
						{
							genericFunctions.displayMessage(this.Resources.NAO_FOI_POSSIVEL_CON65121, 'error')
							this.$eventTracker.addError({
								origin: 'Routine DELETEONEROW (catch)',
								message: e.toString()
							})
						}
					},
					() => {
						genericFunctions.resetProgressBar()
						genericFunctions.displayMessage(this.Resources.NAO_FOI_POSSIVEL_CON65121, 'error')
					},
					undefined,
					this.navigationId)
			},

			// eslint-disable-next-line
			async PTN_MenuR_DELETEONEROW_AfterDone(data)
			{
				this.$eventTracker.addTrace({
					origin: 'Routine DELETEONEROW',
					message: 'After done method',
					contextData: { data }
				})

/* eslint-disable indent, vue/html-indent, vue/script-indent */
//Platform: VUE | Type: AFTER_DONE_ROUTINE | Module: GQT | Parameter: DELETEONEROW | File:  | Order: 0
//BEGIN_MANUALCODE_CODMANUA:b59496ba-afe7-4a27-90ed-6ba337ba070e
this.loadList();
//END_MANUALCODE
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			PTN_MenuR_DELETEONEROW_BeforeSend(data)
			{
				this.$eventTracker.addTrace({
					origin: 'Routine DELETEONEROW',
					message: 'Before send method',
					contextData: { data }
				})

				return new Promise((resolve, reject) => {
					try
					{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT BEFORESEND_ROUTINE DELETEONEROW]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

						resolve(data)
					}
					catch (e)
					{
						reject(e.toString())
					}
				})
			},

			PTN_Menu_LIST_DM_MB_R_MenuR_DELETEONEROW(jsonRouteValues, fnAfterConfirm)
			{
				jsonRouteValues.action = 'PTN_Menu_LIST_DM_MB_R_MenuR_DELETEONEROW'
				this.PTN_MenuR_DELETEONEROW(jsonRouteValues, fnAfterConfirm)
			},

			// eslint-disable-next-line
			PTN_MenuR_DELETEROWS(jsonRouteValues, fnAfterConfirm)
			{
				// The fnAfterConfirm (e.g., the Apply function of the form) - will only be executed if the user confirms that he wants to execute the routine.
				// This method needs to internally execute the PTN_MenuR_DELETEROWS_Success method.
				const buttons = {
					confirm: {
						label: this.Resources.CONTINUAR44831,
						action: () => {
							this.$eventTracker.addTrace({
								origin: 'Routine DELETEROWS',
								message: 'Execution confirmed'
							})

							typeof fnAfterConfirm === 'function' ? fnAfterConfirm(jsonRouteValues) : this.PTN_MenuR_DELETEROWS_Success(jsonRouteValues)
						}
					},
					cancel: {
						label: this.Resources.CANCELAR49513
					}
				}
				genericFunctions.displayMessage(this.Resources.DO_YOU_WANT_TO_DELET37828, 'warning', null, buttons)
			},

			// eslint-disable-next-line
			PTN_MenuR_DELETEROWS_Success(jsonRouteValues)
			{
				this.$eventTracker.addTrace({
					origin: 'Routine DELETEROWS',
					message: 'Start of execution of the manual routine'
				})

				genericFunctions.setProgressBar({ title: computed(() => this.Resources.PROCESSING44327) })

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT VIEW_MANUAL_ROUTINE DELETEROWS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.PTN_MenuR_DELETEROWS_BeforeSend(jsonRouteValues).then((result) => {
					return this.PTN_MenuR_DELETEROWS_AjaxCall(result)
				})
			},

			PTN_MenuR_DELETEROWS_AjaxCall(jsonRouteValues)
			{
				if (typeof jsonRouteValues !== 'object' || typeof jsonRouteValues.action !== 'string')
				{
					this.$eventTracker.addError({
						origin: 'Routine DELETEROWS',
						message: 'Parameter "jsonRouteValues" has a wrong format.'
					})
					return
				}

				const params = jsonRouteValues

				this.$eventTracker.addTrace({
					origin: 'Routine DELETEROWS',
					message: 'Ajax call method',
					contextData: { params }
				})

				netAPI.postData(
					'Lendi',
					params.action,
					params,
					// eslint-disable-next-line
					(data) => {
						genericFunctions.resetProgressBar()

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT DONE_ROUTINE DELETEROWS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

						// DISCLAIMER: Adding code to "DONE_ROUTINE" will override the code below.
						try
						{
							if (typeof data.success !== 'string' || typeof data.message !== 'string')
								throw new Error('Invalid data structure.')

							const result = qEnums.messageTypes[data.success]
							if (!genericFunctions.isEmpty(result))
							{
								this.$eventTracker.addTrace({
									origin: 'Routine DELETEROWS',
									message: 'Manual routine "DELETEROWS" finished execution with result: ' + qEnums.messageTypes[data.success]
								})

								const message = data.message

								if (!genericFunctions.isEmpty(message))
								{
									const buttons = {
										confirm: {
											label: this.Resources.OK15819,
											action: () => this.PTN_MenuR_DELETEROWS_AfterDone(data)
										}
									}

									genericFunctions.displayMessage(message, result, null, buttons)
								}
								else
									this.PTN_MenuR_DELETEROWS_AfterDone(data)
							}
							else
							{
								this.$eventTracker.addError({
									origin: 'Routine DELETEROWS',
									message: 'Routine "DELETEROWS" finished execution with an unknown result type: ' + data.success
								})
							}
						}
						catch (e)
						{
							genericFunctions.displayMessage(this.Resources.NAO_FOI_POSSIVEL_CON65121, 'error')
							this.$eventTracker.addError({
								origin: 'Routine DELETEROWS (catch)',
								message: e.toString()
							})
						}
					},
					() => {
						genericFunctions.resetProgressBar()
						genericFunctions.displayMessage(this.Resources.NAO_FOI_POSSIVEL_CON65121, 'error')
					},
					undefined,
					this.navigationId)
			},

			// eslint-disable-next-line
			async PTN_MenuR_DELETEROWS_AfterDone(data)
			{
				this.$eventTracker.addTrace({
					origin: 'Routine DELETEROWS',
					message: 'After done method',
					contextData: { data }
				})

/* eslint-disable indent, vue/html-indent, vue/script-indent */
//Platform: VUE | Type: AFTER_DONE_ROUTINE | Module: GQT | Parameter: DELETEROWS | File:  | Order: 0
//BEGIN_MANUALCODE_CODMANUA:82e368bb-aaba-47fa-9d3f-ed845ef7eace
this.loadList();
//END_MANUALCODE
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			PTN_MenuR_DELETEROWS_BeforeSend(data)
			{
				this.$eventTracker.addTrace({
					origin: 'Routine DELETEROWS',
					message: 'Before send method',
					contextData: { data }
				})

				return new Promise((resolve, reject) => {
					try
					{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT BEFORESEND_ROUTINE DELETEROWS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

						resolve(data)
					}
					catch (e)
					{
						reject(e.toString())
					}
				})
			},

			PTN_Menu_LIST_DM_MB_R_MenuR_DELETEROWS(jsonRouteValues, fnAfterConfirm)
			{
				jsonRouteValues.action = 'PTN_Menu_LIST_DM_MB_R_MenuR_DELETEROWS'
				this.PTN_MenuR_DELETEROWS(jsonRouteValues, fnAfterConfirm)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS PTN_LIST_DM_MB_R]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS PTN_MENU_LIST_DM_MB_R]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
