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
					:filter-operators="controls.menu.filterOperators"
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
	/* eslint-disable @typescript-eslint/no-unused-vars */
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
	/* eslint-enable @typescript-eslint/no-unused-vars */

	import MenuViewModel from './QMenuSTY_GOOGLEMAPSViewModel.js'

	const requiredTextResources = ['QMenuSTY_GOOGLEMAPS', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS STY_MENU_GOOGLEMAPS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuStyGooglemaps',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuSTY_GOOGLEMAPS', false),

				interfaceMetadata: {
					id: 'QMenuSTY_GOOGLEMAPS', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: 'GOOGLEMAPS',
					isMenuList: true,
					designation: '',
					acronym: 'STY_GOOGLEMAPS',
					name: 'EQUIP',
					route: 'menu-STY_GOOGLEMAPS',
					order: '35211',
					controller: 'EQUIP',
					action: 'STY_Menu_GOOGLEMAPS',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'STY_Menu_GOOGLEMAPS',
						controller: 'EQUIP',
						action: 'STY_Menu_GOOGLEMAPS',
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
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'Pess1.ValName',
								area: 'PESS1',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodpesso',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 3,
								name: 'ValSequennr',
								area: 'EQUIP',
								field: 'SEQUENNR',
								label: computed(() => this.Resources.SEQUENTIAL_NO_38590),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValRegistnr',
								area: 'EQUIP',
								field: 'REGISTNR',
								label: computed(() => this.Resources.NO__REGISTER04207),
								dataLength: 6,
								scrollData: 6,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'Tpequ.ValTipoequi',
								area: 'TPEQU',
								field: 'TIPOEQUI',
								label: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodtpequ',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'Wareh.ValWarehdes',
								area: 'WAREH',
								field: 'WAREHDES',
								label: computed(() => this.Resources.WAREHOUSE51864),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodwareh',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'Item.ValItemdes',
								area: 'ITEM',
								field: 'ITEMDES',
								label: computed(() => this.Resources.ARTICLE60065),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCoditem',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 8,
								name: 'ValDesignat',
								area: 'EQUIP',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.DESIGNATION35876),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 9,
								name: 'ValDtaquisi',
								area: 'EQUIP',
								field: 'DTAQUISI',
								label: computed(() => this.Resources.ACQUISITION44180),
								scrollData: 8,
								dateTimeType: 'date',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 10,
								name: 'Decom.ValDecomnr',
								area: 'DECOM',
								field: 'DECOMNR',
								label: computed(() => this.Resources.NO_BATE21045),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
								pkColumn: 'ValCoddeco',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 11,
								name: 'ValDtdeco',
								area: 'EQUIP',
								field: 'DTDECO',
								label: computed(() => this.Resources.DECOMISSION14486),
								scrollData: 8,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 12,
								name: 'ValIfabatif',
								area: 'EQUIP',
								field: 'IFABATIF',
								label: computed(() => this.Resources.DOWNED_EQUIPMENT43331),
								scrollData: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 13,
								name: 'ValPhotogra',
								area: 'EQUIP',
								field: 'PHOTOGRA',
								label: computed(() => this.Resources.PHOTO51874),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.PHOTO51874)),
								scrollData: 3,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 14,
								name: 'ValValortot',
								area: 'EQUIP',
								field: 'VALORTOT',
								label: computed(() => this.Resources.TOTAL_VALUE30570),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 15,
								name: 'ValFrequenc',
								area: 'EQUIP',
								field: 'FREQUENC',
								label: computed(() => this.Resources.LOAN_FREQUENCY00701),
								scrollData: 1,
								maxDigits: 2,
								decimalPlaces: 0,
								array: computed(() => new qProjArrays.QArrayFreqempr(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayFreqempr.type,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 16,
								name: 'ValBought',
								area: 'EQUIP',
								field: 'BOUGHT',
								label: computed(() => this.Resources.BOUGHT32044),
								scrollData: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 17,
								name: 'Room1.ValRoomnr',
								area: 'ROOM1',
								field: 'ROOMNR',
								label: computed(() => this.Resources.N_R__ROOM43805),
								dataLength: 10,
								scrollData: 10,
								pkColumn: 'ValCodrooms',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 18,
								name: 'ValDtrefere',
								area: 'EQUIP',
								field: 'DTREFERE',
								label: computed(() => this.Resources.REFERENCE28402),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 19,
								name: 'ValFirst',
								area: 'EQUIP',
								field: 'FIRST',
								label: computed(() => this.Resources.FIRST42972),
								dataLength: 10,
								scrollData: 10,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 20,
								name: 'ValBefore',
								area: 'EQUIP',
								field: 'BEFORE',
								label: computed(() => this.Resources.BEFORE60156),
								dataLength: 10,
								scrollData: 10,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 21,
								name: 'ValFollowin',
								area: 'EQUIP',
								field: 'FOLLOWIN',
								label: computed(() => this.Resources.FOLLOWING22170),
								dataLength: 10,
								scrollData: 10,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 22,
								name: 'ValLast',
								area: 'EQUIP',
								field: 'LAST',
								label: computed(() => this.Resources.LAST49207),
								dataLength: 10,
								scrollData: 10,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.HyperLinkColumn({
								order: 23,
								name: 'ValSitefabr',
								area: 'EQUIP',
								field: 'SITEFABR',
								label: computed(() => this.Resources.MANUFACTURER_S_WEBSI11084),
								dataLength: 256,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 24,
								name: 'ValLastpho',
								area: 'EQUIP',
								field: 'LASTPHO',
								label: computed(() => this.Resources.LAST_PHOTO_ATTACHED43884),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.LAST_PHOTO_ATTACHED43884)),
								scrollData: 3,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 25,
								name: 'ValMoviment',
								area: 'EQUIP',
								field: 'MOVIMENT',
								label: computed(() => this.Resources.DRIVES34119),
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 26,
								name: 'ValQtdmovim',
								area: 'EQUIP',
								field: 'QTDMOVIM',
								label: computed(() => this.Resources.QTD__MOVIMENTACOES28400),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'STY_Menu_GOOGLEMAPS',
							serverMode: true,
							pkColumn: 'ValCodequip',
							tableAlias: 'EQUIP',
							tableNamePlural: computed(() => this.Resources.EQUIPMENT03632),
							viewManagement: 'U',
							showLimitsInfo: true,
							perPage: 10,
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
										formName: 'GMAPS',
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
										formName: 'GMAPS',
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
										formName: 'GMAPS',
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
										formName: 'GMAPS',
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
										formName: 'GMAPS',
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
								id: 'RCA_STY_352111',
								name: 'form-GMAPS',
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodequip
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'GMAPS'
								}
							},
							formsDefinition: {
								'GMAPS': {
									fnKeySelector: (row) => row.Fields.ValCodequip,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValRegistnr',
							defaultSearchColumnNameOriginal: 'ValRegistnr',
							defaultColumnSorting: {
								columnName: 'ValRegistnr',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-ITEM', 'changed-WAREH', 'changed-EQUIP', 'changed-TPEQU', 'changed-ROOM1', 'changed-CMPNY', 'changed-DECOM', 'changed-PESS1'],
						uuid: 'c99ce9d2-bf87-4df2-8748-699f892fb38b',
						allSelectedRows: 'false',
						headerLevel: 1,
						/** Menu limits */
						controlLimits: [
							/** SC */
						]
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
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_CODEJS STY_MENU_GOOGLEMAPS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT STY_MENU_GOOGLEMAPS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS STY_GOOGLEMAPS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS STY_MENU_GOOGLEMAPS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
