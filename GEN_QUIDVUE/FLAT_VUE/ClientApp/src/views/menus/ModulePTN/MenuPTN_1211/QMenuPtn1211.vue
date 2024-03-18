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
					v-if="componentOnLoadProc.loaded"
					v-bind="model.menu"
					v-on="model.menu.handlers">
				</q-table>

				<q-table-extra-extension
					:list-ctrl="model.menu"
					v-on="model.menu.handlers" />
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

	const requiredTextResources = ['QMenuPTN_1211', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PTN_MENU_1211]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuPtn1211',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuPTN_1211', false),

				interfaceMetadata: {
					id: 'QMenuPTN_1211', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '1211',
					isMenuList: true,
					acronym: 'PTN_1211',
					name: 'COMOD',
					route: 'menu-PTN_1211',
					order: '1211',
					controller: 'LENDI',
					action: 'PTN_Menu_1211',
					isPopup: false
				},

				model: {
					menu: new controlClass.TableListControl({
						controller: 'LENDI',
						action: 'PTN_Menu_1211',
						hasDependencies: false,
						isInCollapsible: false,
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
								dateTimeType: 'DateTime',
							}),
							new listColumnTypes.DateColumn({
								order: 6,
								name: 'ValWarndt',
								area: 'LENDI',
								field: 'WARNDT',
								label: computed(() => this.Resources.WARNING52043),
								scrollData: 16,
								dateTimeType: 'DateTime',
							}),
							new listColumnTypes.DateColumn({
								order: 7,
								name: 'ValEnd',
								area: 'LENDI',
								field: 'END',
								label: computed(() => this.Resources.END47577),
								scrollData: 16,
								dateTimeType: 'DateTime',
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
								dateTimeType: 'Date',
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
							name: 'PTN_Menu_1211',
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
							showColumnTotalsSelected: true,
							permissions: {
								canView: false,
								canEdit: false,
								canDuplicate: false,
								canDelete: false,
								canInsert: false
							},
							globalSearch: {
								visibility: true,
								searchOnPressEnter: true
							},
							filtersVisible: true,
							allowColumnFilters: true,
							allowColumnSort: true,
							generalCustomActions: [
								{
									id: 'MB_12113',
									name: 'PTN_MenuR_MESSAGEOK',
									title: computed(() => this.Resources.OPTIONAL_RECORDS50081),
									params: {
										action: vm.openRoutineAction, type: 'routine', actionRoutine: this.PTN_MenuR_MESSAGEOK,
									}
								},
							],
							groupActions: [
								{
									id: 'MB_12112',
									name: 'PTN_MenuR_MESSAGEOK',
									title: computed(() => this.Resources.MULTIPLE_RECORDS42019),
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCodlendi
											},
										],
										action: vm.openRoutineAction, type: 'routine', actionRoutine: this.PTN_MenuR_MESSAGEOK,
									}
								},
							],
							customActions: [
								{
									id: 'MB_12111',
									name: 'PTN_MenuR_MESSAGEOK',
									title: computed(() => this.Resources.SINGLE_RECORD62788),
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCodlendi
											},
										],
										action: vm.openRoutineAction, type: 'routine', actionRoutine: this.PTN_MenuR_MESSAGEOK,
									}
								},
							],
							MCActions: [
							],
							rowClickAction: {
							},
							formsDefinition: {
							},
							rowValidation: {
								fnValidate: (row) => row.Fields.ValZzstate === 0,
								message: computed(() => this.Resources.ATENCAO__ESTA_FICHA_24725),
								class: 'c-table__row--pending'
							},
							crudConditions: {
							},
							defaultSearchColumnName: 'ValLendinnr',
							defaultSearchColumnNameOriginal: 'ValLendinnr',
							initialSortColumnName: '',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-LENDI', 'changed-EQUIP', 'changed-PESS2', 'changed-PESS1'],
						uuid: '5e4e7e69-c5b2-478b-bb88-e077baaaf55b',
						allSelectedRows: 'false',
						headerLevel: 1
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
			this.$eventHub.on('EXEC-MENU-ROUTINE-PTN_1211', this.onExecRoutineEvent)

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_CODEJS PTN_MENU_1211]/
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
			PTN_MenuR_MESSAGEOK(jsonRouteValues, fnAfterConfirm)
			{
				// The fnAfterConfirm (e.g., the Apply function of the form) - will only be executed if the user confirms that he wants to execute the routine.
				// This method needs to internally execute the PTN_MenuR_MESSAGEOK_Success method.
				let buttons = {
					confirm: {
						label: this.Resources.CONTINUAR44831,
						action: () => {
							this.$eventTracker.addTrace({
								origin: 'Routine MESSAGEOK',
								message: 'Execution confirmed'
							})

							typeof fnAfterConfirm === 'function' ? fnAfterConfirm(jsonRouteValues) : this.PTN_MenuR_MESSAGEOK_Success(jsonRouteValues)
						}
					},
					cancel: {
						label: this.Resources.CANCELAR49513
					}
				}
				genericFunctions.displayMessage(this.Resources.DO_YOU_WANT_TO_EXECU40462, 'warning', null, buttons)
			},

			// eslint-disable-next-line
			PTN_MenuR_MESSAGEOK_Success(jsonRouteValues)
			{
				this.$eventTracker.addTrace({
					origin: 'Routine MESSAGEOK',
					message: 'Start of execution of the manual routine'
				})

				genericFunctions.setProgressBar({ title: computed(() => this.Resources.PROCESSING44327) })

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT VIEW_MANUAL_ROUTINE MESSAGEOK]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.PTN_MenuR_MESSAGEOK_BeforeSend(jsonRouteValues).then((result) => {
					return this.PTN_MenuR_MESSAGEOK_AjaxCall(result)
				})
			},

			PTN_MenuR_MESSAGEOK_AjaxCall(jsonRouteValues)
			{
				var params = {}
				if (typeof jsonRouteValues === 'object')
					params = jsonRouteValues
				else if (typeof jsonRouteValues !== 'undefined')
					params = { jsonRouteValues }

				this.$eventTracker.addTrace({
					origin: 'Routine MESSAGEOK',
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
					const allSelected = this.navigation.currentLevel.params.allSelected || []
					const tblId = 'PTN_Menu_1211'
					params.allSelected = allSelected.findIndex((e) => e === tblId) !== -1
				}

				const criteriaSetId = 'ML1211'
				params.criteriaSetId = criteriaSetId

				netAPI.postData(
					'Lendi',
					'PTN_MenuR_MESSAGEOK',
					params,
					(data) => {
						genericFunctions.resetProgressBar()

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT DONE_ROUTINE MESSAGEOK]/
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
									origin: 'Routine MESSAGEOK',
									message: 'Manual routine "MESSAGEOK" finished execution with result: ' + qEnums.messageTypes[data.success]
								})

								let message = data.message

								if (!genericFunctions.isEmpty(message))
								{
									const buttons = {
										confirm: {
											label: this.Resources.OK15819,
											action: () => this.PTN_MenuR_MESSAGEOK_AfterDone(data)
										}
									}

									genericFunctions.displayMessage(message, result, null, buttons)
								}
								else
									this.PTN_MenuR_MESSAGEOK_AfterDone(data)
							}
							else
								this.$eventTracker.addError({ origin: 'Routine MESSAGEOK', message: 'Routine "MESSAGEOK" finished execution with an unknown result type: ' + data.success })
						}
						catch (e)
						{
							genericFunctions.displayMessage(this.Resources.NAO_FOI_POSSIVEL_CON65121, 'error')
							this.$eventTracker.addError({ origin: 'Routine MESSAGEOK (catch)', message: e.toString() })
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
			async PTN_MenuR_MESSAGEOK_AfterDone(data)
			{
				this.$eventTracker.addTrace({
					origin: 'Routine MESSAGEOK',
					message: 'After done method',
					contextData: { data }
				})

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT AFTER_DONE_ROUTINE MESSAGEOK]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			PTN_MenuR_MESSAGEOK_BeforeSend(data)
			{
				this.$eventTracker.addTrace({
					origin: 'Routine MESSAGEOK',
					message: 'Before send method',
					contextData: { data }
				})

				return new Promise((resolve, reject) => {
					try
					{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT BEFORESEND_ROUTINE MESSAGEOK]/
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


/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS PTN_MENU_1211]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
