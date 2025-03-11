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

	import MenuViewModel from './QMenuGQT_211ViewModel.js'

	const requiredTextResources = ['QMenuGQT_211', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS GQT_MENU_211]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuGqt211',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuGQT_211', false),

				interfaceMetadata: {
					id: 'QMenuGQT_211', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '211',
					isMenuList: true,
					designation: computed(() => this.Resources.EQUIPMENT03632),
					acronym: 'GQT_211',
					name: 'EQUIP',
					route: 'menu-GQT_211',
					order: '211',
					controller: 'EQUIP',
					action: 'GQT_Menu_211',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableSpecialRenderingControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'GQT_Menu_211',
						controller: 'EQUIP',
						action: 'GQT_Menu_211',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Cmpny.ValDesignat',
								area: 'CMPNY',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.DESIGNATION35876),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodempre',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 2,
								name: 'ValSequennr',
								area: 'EQUIP',
								field: 'SEQUENNR',
								label: computed(() => this.Resources.SEQUENTIAL_NO_38590),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValRegistnr',
								area: 'EQUIP',
								field: 'REGISTNR',
								label: computed(() => this.Resources.NO__REGISTER04207),
								dataLength: 6,
								scrollData: 6,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'Tpequ.ValTipoequi',
								area: 'TPEQU',
								field: 'TIPOEQUI',
								label: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodtpequ',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValDesignat',
								area: 'EQUIP',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.DESIGNATION35876),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 6,
								name: 'ValDtaquisi',
								area: 'EQUIP',
								field: 'DTAQUISI',
								label: computed(() => this.Resources.ACQUISITION44180),
								scrollData: 8,
								dateTimeType: 'date',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 7,
								name: 'ValDtdeco',
								area: 'EQUIP',
								field: 'DTDECO',
								label: computed(() => this.Resources.DECOMISSION14486),
								scrollData: 8,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.HyperLinkColumn({
								order: 8,
								name: 'ValSitefabr',
								area: 'EQUIP',
								field: 'SITEFABR',
								label: computed(() => this.Resources.SITIO_FABRICANTE26458),
								dataLength: 256,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'GQT_Menu_211',
							serverMode: true,
							pkColumn: 'ValCodequip',
							tableAlias: 'EQUIP',
							tableNamePlural: computed(() => this.Resources.EQUIPMENT03632),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.EQUIPMENT03632),
							showRecordCount: true,
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
										formName: 'EQUIP',
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
										formName: 'EQUIP',
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
										formName: 'EQUIP',
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
										formName: 'EQUIP',
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
										formName: 'EQUIP',
										mode: 'NEW',
										repeatInsertion: true,
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
							],
							rowClickAction: {
								id: 'RCA_GQT_2111',
								name: 'form-EQUIP',
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodequip
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'EDIT', formName: 'EQUIP',
								}
							},
							formsDefinition: {
								'EQUIP': {
									fnKeySelector: (row) => row.Fields.ValCodequip,
									isPopup: false
								},
							},
							allowFileExport: true,
							defaultSearchColumnName: 'ValRegistnr',
							defaultSearchColumnNameOriginal: 'ValRegistnr',
							defaultColumnSorting: {
								columnName: 'ValRegistnr',
								sortOrder: 'asc'
							}
						},
						activeFilters: {
							options: {
								active: {
									id: 'filter_GQT_Menu_211_ActiveFilter_A',
									value: computed(() => this.Resources.ATIVOS54304),
									selected: true
								},
								inactive: {
									id: 'filter_GQT_Menu_211_ActiveFilter_I',
									value: computed(() => this.Resources.INATIVOS00149),
									selected: false
								},
								future: {
									id: 'filter_GQT_Menu_211_ActiveFilter_F',
									value: computed(() => this.Resources.FUTUROS10545),
									selected: false
								}
							},
							dateValue: {
								id: 'GQT_Menu_211_dataRef',
								type: 'date',
								value: new Date(),
								title: computed(() => this.Resources.DATA18071),
							}
						},
						globalEvents: ['changed-TPEQU', 'changed-ROOM1', 'changed-DECOM', 'changed-PESS1', 'changed-EQUIP', 'changed-WAREH', 'changed-ITEM', 'changed-CMPNY'],
						uuid: '9c20afa8-9950-45e5-9447-fccf9853de7d',
						allSelectedRows: 'false',
						viewModes: [
							{
								id: 'LIST',
								type: 'list',
								subtype: '',
								label: computed(() => this.Resources.LISTA13474),
								order: 1,
								mappingVariables: readonly({
								}),
								styleVariables: {
								},
								groups: {
								}
							},
							{
								id: 'CHART',
								type: 'chart',
								subtype: 'genericgraph',
								label: computed(() => this.Resources.GRAFICO38823),
								order: 2,
								mappingVariables: readonly({
									xaxis: {
										allowsMultiple: false,
										sources: [
											'EQUIP.DESIGNAT',
										]
									},
									yaxis: {
										allowsMultiple: true,
										sources: [
											'EQUIP.SEQUENNR',
										]
									},
								}),
								styleVariables: {
									chartType: {
										rawValue: 'line',
										isMapped: false
									},
									firstColor: {
										rawValue: 'undefined',
										isMapped: false
									},
									chartColorArray: {
										rawValue: 'Highcharts Default',
										isMapped: false
									},
									invertColorArray: {
										rawValue: false,
										isMapped: false
									},
									xaxisType: {
										rawValue: 'linear',
										isMapped: false
									},
									yaxisType: {
										rawValue: 'linear',
										isMapped: false
									},
									graphTitle: {
										rawValue: undefined,
										isMapped: false
									},
									description: {
										rawValue: undefined,
										isMapped: false
									},
									alignDescription: {
										rawValue: 'left',
										isMapped: false
									},
									yaxisName: {
										rawValue: 'Y axis',
										isMapped: false
									},
									xaxisName: {
										rawValue: 'X axis',
										isMapped: false
									},
									groupType: {
										rawValue: 'join',
										isMapped: false
									},
									inverted: {
										rawValue: false,
										isMapped: false
									},
									showLabels: {
										rawValue: true,
										isMapped: false
									},
									showLegend: {
										rawValue: true,
										isMapped: false
									},
									widthPercentage: {
										rawValue: 100,
										isMapped: false
									},
									showPieLabel: {
										rawValue: 'outside',
										isMapped: false
									},
									lineMarker: {
										rawValue: 'enabled',
										isMapped: false
									},
									heightPx: {
										rawValue: 400,
										isMapped: false
									},
									pieInnerSizePercentage: {
										rawValue: 0,
										isMapped: false
									},
									showBreaks: {
										rawValue: false,
										isMapped: false
									},
									enableHover: {
										rawValue: true,
										isMapped: false
									},
									zoomType: {
										rawValue: 'x',
										isMapped: false
									},
									legendLayout: {
										rawValue: 'horizontal',
										isMapped: false
									},
									legendXPosition: {
										rawValue: 0,
										isMapped: false
									},
									showLastN: {
										rawValue: -1,
										isMapped: false
									},
									legendYPosition: {
										rawValue: 0,
										isMapped: false
									},
									legendFloating: {
										rawValue: false,
										isMapped: false
									},
									legendAlign: {
										rawValue: 'center',
										isMapped: false
									},
									legendVerticalAlign: {
										rawValue: 'bottom',
										isMapped: false
									},
									stackingType: {
										rawValue: 'undefined',
										isMapped: false
									},
									valuesDecimals: {
										rawValue: 0,
										isMapped: false
									},
								},
								groups: {
								}
							},
						],
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
			this.onBeforeRouteLeave(to, next)
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_CODEJS GQT_MENU_211]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS GQT_211]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS GQT_MENU_211]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
