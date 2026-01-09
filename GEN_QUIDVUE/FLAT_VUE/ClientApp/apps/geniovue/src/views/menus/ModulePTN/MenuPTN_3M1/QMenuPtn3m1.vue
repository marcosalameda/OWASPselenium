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
					<!-- USE /[MANUAL GQT CUSTOM_TABLE PTN_Menu_3M1]/ -->
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

	import MenuViewModel from './QMenuPTN_3M1ViewModel.js'

	const requiredTextResources = ['QMenuPTN_3M1', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PTN_MENU_3M1]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuPtn3m1',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuPTN_3M1', false),

				interfaceMetadata: {
					id: 'QMenuPTN_3M1', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '3M1',
					isMenuList: true,
					designation: computed(() => this.Resources.LIST_WITH_COLUMNS_FR36713),
					acronym: 'PTN_3M1',
					name: 'GRPB',
					route: 'menu-PTN_3M1',
					order: '3M1',
					controller: 'GRPB',
					action: 'PTN_Menu_3M1',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'PTN_Menu_3M1',
						controller: 'GRPB',
						action: 'PTN_Menu_3M1',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValName',
								area: 'GRPB',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 2,
								multipleValues: true,
								name: 'TblbValBool',
								area: 'TBLB',
								field: 'BOOL',
								label: computed(() => this.Resources.BOOLEAN45002),
								scrollData: 1,
								sortable: false,
								pkColumn: 'ValCodtblb',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 3,
								multipleValues: true,
								name: 'TblbValCurdec',
								area: 'TBLB',
								field: 'CURDEC',
								label: computed(() => this.Resources.CURRENCY__DECIMAL_11718),
								scrollData: 10,
								maxDigits: 5,
								decimalPlaces: 4,
								sortable: false,
								pkColumn: 'ValCodtblb',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 4,
								multipleValues: true,
								name: 'TblbValCurint',
								area: 'TBLB',
								field: 'CURINT',
								label: computed(() => this.Resources.CURRENCY__INTERGER_21437),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 2,
								sortable: false,
								pkColumn: 'ValCodtblb',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 5,
								multipleValues: true,
								name: 'TblbValDate',
								area: 'TBLB',
								field: 'DATE',
								label: computed(() => this.Resources.DATE18475),
								scrollData: 8,
								dateTimeType: 'date',
								sortable: false,
								pkColumn: 'ValCodtblb',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 6,
								multipleValues: true,
								name: 'TblbValDatetm',
								area: 'TBLB',
								field: 'DATETM',
								label: computed(() => this.Resources.DATETIME__MINUTES_59352),
								scrollData: 16,
								dateTimeType: 'dateTime',
								sortable: false,
								pkColumn: 'ValCodtblb',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 7,
								multipleValues: true,
								name: 'TblbValDatets',
								area: 'TBLB',
								field: 'DATETS',
								label: computed(() => this.Resources.DATETIME__SECONDS_49861),
								scrollData: 19,
								dateTimeType: 'dateTimeSeconds',
								sortable: false,
								pkColumn: 'ValCodtblb',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 8,
								multipleValues: true,
								name: 'TblbValEnumn',
								area: 'TBLB',
								field: 'ENUMN',
								label: computed(() => this.Resources.ENUMERATION__NUMERIC44708),
								scrollData: 1,
								maxDigits: 1,
								decimalPlaces: 0,
								sortable: false,
								array: computed(() => new qProjArrays.QArrayTypen(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayTypen.type,
								pkColumn: 'ValCodtblb',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 9,
								multipleValues: true,
								name: 'TblbValEnumt',
								area: 'TBLB',
								field: 'ENUMT',
								label: computed(() => this.Resources.ENUMERATION__TEXT_15855),
								dataLength: 1,
								scrollData: 1,
								sortable: false,
								array: computed(() => new qProjArrays.QArrayTypet(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayTypet.type,
								pkColumn: 'ValCodtblb',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 10,
								multipleValues: true,
								name: 'TblbValNumdec',
								area: 'TBLB',
								field: 'NUMDEC',
								label: computed(() => this.Resources.NUMERIC__DECIMAL_36157),
								scrollData: 10,
								maxDigits: 6,
								decimalPlaces: 3,
								sortable: false,
								pkColumn: 'ValCodtblb',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 11,
								multipleValues: true,
								name: 'TblbValNumint',
								area: 'TBLB',
								field: 'NUMINT',
								label: computed(() => this.Resources.NUMERIC__INTEGER_50289),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
								sortable: false,
								pkColumn: 'ValCodtblb',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 12,
								multipleValues: true,
								name: 'TblbValText',
								area: 'TBLB',
								field: 'TEXT',
								label: computed(() => this.Resources.TEXT04938),
								dataLength: 50,
								scrollData: 30,
								sortable: false,
								pkColumn: 'ValCodtblb',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 13,
								multipleValues: true,
								name: 'TblbValTextml',
								area: 'TBLB',
								field: 'TEXTML',
								label: computed(() => this.Resources.MULTILINE_TEXT38013),
								scrollData: 30,
								sortable: false,
								pkColumn: 'ValCodtblb',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 14,
								multipleValues: true,
								name: 'TblbValTimehm',
								area: 'TBLB',
								field: 'TIMEHM',
								label: computed(() => this.Resources.TIME__HOURS_MINUTES_01660),
								dataLength: 5,
								scrollData: 5,
								dateTimeType: 'time',
								sortable: false,
								pkColumn: 'ValCodtblb',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'PTN_Menu_3M1',
							serverMode: true,
							pkColumn: 'ValCodgrpb',
							tableAlias: 'GRPB',
							tableNamePlural: computed(() => this.Resources.GROUPS__BASIC_25795),
							viewManagement: '',
							hasTextWrap: true,
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.LIST_WITH_COLUMNS_FR36713),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: true
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
										formName: 'GRPB',
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
										formName: 'GRPB',
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
										formName: 'GRPB',
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
										formName: 'GRPB',
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
										formName: 'GRPB',
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
							],
							rowClickAction: {
							},
							formsDefinition: {
								'GRPB': {
									fnKeySelector: (row) => row.Fields.ValCodgrpb,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValName',
							defaultSearchColumnNameOriginal: 'ValName',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-GRPB'],
						uuid: 'fa354599-4a30-4174-adb2-39d65e17489c',
						allSelectedRows: 'false',
						headerLevel: 1,
						isActiveControl: computed(() => this.isActiveMenu)
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
// USE /[MANUAL GQT FORM_CODEJS PTN_MENU_3M1]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT PTN_MENU_3M1]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS PTN_3M1]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS PTN_MENU_3M1]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
