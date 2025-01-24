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

	import MenuViewModel from './QMenuGQT_2D21ViewModel.js'

	const requiredTextResources = ['QMenuGQT_2D21', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS GQT_MENU_2D21]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuGqt2d21',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuGQT_2D21', false),

				interfaceMetadata: {
					id: 'QMenuGQT_2D21', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '2D21',
					isMenuList: true,
					designation: computed(() => this.Resources.TYPES_OF_EQUIPMENT61264),
					acronym: 'GQT_2D21',
					name: 'TPEQU',
					route: 'menu-GQT_2D21',
					order: '2D21',
					controller: 'TPEQU',
					action: 'GQT_Menu_2D21',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'GQT_Menu_2D21',
						controller: 'TPEQU',
						action: 'GQT_Menu_2D21',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Famil.ValFamily',
								area: 'FAMIL',
								field: 'FAMILY',
								label: computed(() => this.Resources.FAMILIA_DE_EQUIPAMEN12158),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodfamil',
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValTipoequi',
								area: 'TPEQU',
								field: 'TIPOEQUI',
								label: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValTpequcod',
								area: 'TPEQU',
								field: 'TPEQUCOD',
								label: computed(() => this.Resources.CODE49225),
								dataLength: 20,
								scrollData: 20,
							}),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValTpequpai',
								area: 'TPEQU',
								field: 'TPEQUPAI',
								label: computed(() => this.Resources.DEPENDENT_ON28321),
								dataLength: 20,
								scrollData: 20,
							}),
							new listColumnTypes.NumericColumn({
								order: 5,
								name: 'ValNivel',
								area: 'TPEQU',
								field: 'NIVEL',
								label: computed(() => this.Resources.LEVEL06184),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'ValBackcolo',
								area: 'TPEQU',
								field: 'BACKCOLO',
								label: computed(() => this.Resources.BACKGROUND_COLOR47883),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'ValCorletra',
								area: 'TPEQU',
								field: 'CORLETRA',
								label: computed(() => this.Resources.LETTER_COLOR15736),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 8,
								name: 'ValPrecomax',
								area: 'TPEQU',
								field: 'PRECOMAX',
								label: computed(() => this.Resources.MAXIMUM_PRICE55489),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 0,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 9,
								name: 'ValPrecoult',
								area: 'TPEQU',
								field: 'PRECOULT',
								label: computed(() => this.Resources.LAST_PRICE25852),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 0,
							}),
							new listColumnTypes.DateColumn({
								order: 10,
								name: 'ValSince',
								area: 'TPEQU',
								field: 'SINCE',
								label: computed(() => this.Resources.SINCE47259),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.NumericColumn({
								order: 11,
								name: 'ValQtdequip',
								area: 'TPEQU',
								field: 'QTDEQUIP',
								label: computed(() => this.Resources.AMOUNT46885),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}),
							new listColumnTypes.BooleanColumn({
								order: 12,
								name: 'ValKit',
								area: 'TPEQU',
								field: 'KIT',
								label: computed(() => this.Resources.KIT27179),
								scrollData: 1,
							}),
						],
						config: {
							name: 'GQT_Menu_2D21',
							serverMode: true,
							pkColumn: 'ValCodtpequ',
							tableAlias: 'TPEQU',
							tableNamePlural: computed(() => this.Resources.TYPES_OF_EQUIPMENT61264),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.TYPES_OF_EQUIPMENT61264),
							showAlternatePagination: true,
							rowClickActionInternal: 'selectMultiple',
							showRowsSelectedCount: true,
							showRowsSelectedTotalizer: true,
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
										formName: 'TPEQU',
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
										formName: 'TPEQU',
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
										formName: 'TPEQU',
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
										formName: 'TPEQU',
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
										formName: 'TPEQU',
										mode: 'NEW',
										repeatInsertion: false,
										isControlled: true
									}
								},
							],
							generalCustomActions: [
							],
							groupActions: [
								{
									id: 'MB_2D211',
									name: 'menu-GQT_2D2111',
									title: computed(() => this.Resources.LISTA13474),
									params: {
										limits: [
											{
												identifier: 'tpequ',
												fnValueSelector: (row) => row.ValCodtpequ
											},
										],
										action: vm.openMenuAction, type: 'menu', menuName: 'GQT_2D2111',
									}
								},
								{
									id: 'MB_2D213',
									name: 'GQT_Menu_2D21_MenuR_TEST',
									title: computed(() => this.Resources.ROUTINE58306),
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCodtpequ
											},
										],
										action: vm.openRoutineAction, type: 'routine', actionRoutine: this.GQT_Menu_2D21_MenuR_TEST,
									}
								},
							],
							customActions: [
								{
									id: 'MB_2D212',
									name: 'form-TPEQU',
									title: computed(() => this.Resources.FORMULARIO39926),
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCodtpequ
											},
										],
										action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'TPEQU',
									}
								},
								{
									id: 'MB_2D214',
									name: 'GQT_Report_2D2141',
									title: computed(() => this.Resources.REPORT48266),
									params: {
										limits: [
											{
												identifier: 'tpequ',
												fnValueSelector: (row) => row.ValCodtpequ
											},
										],
										action: vm.openReportAction, name: 'Teste equip', preview: false, type: 'report', baseArea: 'Tpequ'
									}
								},
							],
							MCActions: [
							],
							rowClickAction: {
							},
							formsDefinition: {
								'TPEQU': {
									fnKeySelector: (row) => row.Fields.ValCodtpequ,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValTipoequi',
							defaultSearchColumnNameOriginal: 'ValTipoequi',
							defaultColumnSorting: {
								columnName: 'ValTipoequi',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-FAMIL', 'changed-TPEQU'],
						uuid: '17bc4906-db78-4a9c-845c-30c7e64fb3d6',
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
			this.$eventHub.on('EXEC-MENU-ROUTINE-GQT_2D21', this.onExecRoutineEvent)

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_CODEJS GQT_MENU_2D21]/
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
			GQT_MenuR_TEST(jsonRouteValues)
			{
				this.$eventTracker.addTrace({
					origin: 'Routine Test',
					message: 'Start of execution of the manual routine'
				})

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT VIEW_MANUAL_ROUTINE Test]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			GQT_Menu_2D21_MenuR_TEST(jsonRouteValues, fnAfterConfirm)
			{
				jsonRouteValues.action = 'GQT_Menu_2D21_MenuR_TEST'
				this.GQT_MenuR_TEST(jsonRouteValues, fnAfterConfirm)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS GQT_2D21]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS GQT_MENU_2D21]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
