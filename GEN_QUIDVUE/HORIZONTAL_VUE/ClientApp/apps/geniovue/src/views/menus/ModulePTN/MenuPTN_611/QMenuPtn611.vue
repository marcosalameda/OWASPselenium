<template>
	<teleport
		v-if="menuModalIsReady"
		:to="`#${uiContainersId.body}`"
		:disabled="!menuInfo.isPopup">
		<div
			class="form-horizontal"
			@submit.prevent>
			<q-row-container>
				<q-table
					v-bind="controls.menu"
					v-on="controls.menu.handlers">
					<template #header>
						<q-table-config
							:table-ctrl="controls.menu"
							v-on="controls.menu.handlers">
						</q-table-config>
					</template>
					<!-- USE /[MANUAL GQT CUSTOM_TABLE PTN_Menu_611]/ -->
				</q-table>
			</q-row-container>
		</div>
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

	import MenuViewModel from './QMenuPTN_611ViewModel.js'

	const requiredTextResources = ['QMenuPTN_611', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PTN_MENU_611]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuPtn611',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuPTN_611', false),

				interfaceMetadata: {
					id: 'QMenuPTN_611', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '611',
					isMenuList: true,
					designation: computed(() => this.Resources.FIELD_TYPES49172),
					acronym: 'PTN_611',
					name: 'FLDS',
					route: 'menu-PTN_611',
					order: '611',
					controller: 'FLDS',
					action: 'PTN_Menu_611',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'PTN_Menu_611',
						controller: 'FLDS',
						action: 'PTN_Menu_611',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Aero.ValName',
								area: 'AERO',
								field: 'NAME',
								label: computed(() => this.Resources.AIRLINE_NAME55130),
								dataLength: 50,
								scrollData: 30,
								export: 1,
								pkColumn: 'ValCodaero',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValDescrip',
								area: 'FLDS',
								field: 'DESCRIP',
								label: computed(() => this.Resources.DESCRIPTION07383),
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 3,
								name: 'ValNpassage',
								area: 'FLDS',
								field: 'NPASSAGE',
								label: computed(() => this.Resources.NUMERIC19292),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 4,
								name: 'ValDuration',
								area: 'FLDS',
								field: 'DURATION',
								label: computed(() => this.Resources.NUMERIC_DECIMAL37352),
								scrollData: 5,
								maxDigits: 2,
								decimalPlaces: 2,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 5,
								name: 'ValPrice',
								area: 'FLDS',
								field: 'PRICE',
								label: computed(() => this.Resources.CURRENCY13881),
								scrollData: 6,
								maxDigits: 3,
								decimalPlaces: 2,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 6,
								name: 'ValPrecobil',
								area: 'FLDS',
								field: 'PRECOBIL',
								label: computed(() => this.Resources.CURRENCY_DECIMAL48296),
								scrollData: 6,
								maxDigits: 3,
								decimalPlaces: 2,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 7,
								name: 'ValDate',
								area: 'FLDS',
								field: 'DATE',
								label: computed(() => this.Resources.DATE__DD_MM_YY_57869),
								scrollData: 8,
								dateTimeType: 'date',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 8,
								name: 'ValDatetime',
								area: 'FLDS',
								field: 'DATETIME',
								label: computed(() => this.Resources.DATETIME61308),
								scrollData: 16,
								dateTimeType: 'dateTime',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 9,
								name: 'ValDateseco',
								area: 'FLDS',
								field: 'DATESECO',
								label: computed(() => this.Resources.DATESECOND44557),
								scrollData: 19,
								dateTimeType: 'dateTimeSeconds',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 10,
								name: 'ValTime',
								area: 'FLDS',
								field: 'TIME',
								label: computed(() => this.Resources.TIME15328),
								dataLength: 5,
								scrollData: 5,
								dateTimeType: 'time',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 11,
								name: 'ValYear',
								area: 'FLDS',
								field: 'YEAR',
								label: computed(() => this.Resources.YEAR61794),
								scrollData: 4,
								maxDigits: 4,
								decimalPlaces: 0,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 12,
								name: 'ValPrimviag',
								area: 'FLDS',
								field: 'PRIMVIAG',
								label: computed(() => this.Resources.LOGICAL47485),
								scrollData: 1,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 13,
								name: 'ValConditio',
								area: 'FLDS',
								field: 'CONDITIO',
								label: computed(() => this.Resources.CONDITIONAL01431),
								scrollData: 1,
								maxDigits: 1,
								decimalPlaces: 0,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 14,
								name: 'ValClass',
								area: 'FLDS',
								field: 'CLASS',
								label: computed(() => this.Resources.TEXT_ENUMERATION45668),
								dataLength: 2,
								scrollData: 2,
								export: 1,
								array: computed(() => new qProjArrays.QArrayClass(vm.$getResource).elements),
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 15,
								name: 'ValClassnum',
								area: 'FLDS',
								field: 'CLASSNUM',
								label: computed(() => this.Resources.NUMERIC_ENUMERATION19068),
								scrollData: 1,
								maxDigits: 1,
								decimalPlaces: 0,
								export: 1,
								array: computed(() => new qProjArrays.QArrayClassnum(vm.$getResource).elements),
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 16,
								name: 'ValLogicenu',
								area: 'FLDS',
								field: 'LOGICENU',
								label: computed(() => this.Resources.LOGICAL_ENUMERATION30276),
								scrollData: 1,
								export: 1,
								array: computed(() => new qProjArrays.QArrayPrimviag(vm.$getResource).elements),
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 17,
								name: 'ValLogo',
								area: 'FLDS',
								field: 'LOGO',
								label: computed(() => this.Resources.LOGO62483),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.LOGO62483)),
								scrollData: 3,
								sortable: false,
								searchable: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DocumentColumn({
								order: 18,
								name: 'ValAttach',
								area: 'FLDS',
								field: 'ATTACH',
								label: computed(() => this.Resources.DOCUMENT00695),
								dataLength: 50,
								scrollData: 30,
								sortable: false,
								export: 1,
								viewType: qEnums.documentViewTypeMode.print,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 19,
								name: 'ValLogoexte',
								area: 'FLDS',
								field: 'LOGOEXTE',
								label: computed(() => this.Resources.LOGO__EXTERNAL_FILE_58162),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.LOGO__EXTERNAL_FILE_58162)),
								dataLength: 3,
								scrollData: 3,
								sortable: false,
								searchable: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 20,
								name: 'ValCreatuse',
								area: 'FLDS',
								field: 'CREATUSE',
								label: computed(() => this.Resources.CREATED_BY12292),
								dataLength: 20,
								scrollData: 20,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 21,
								name: 'ValCreatdat',
								area: 'FLDS',
								field: 'CREATDAT',
								label: computed(() => this.Resources.DATE_OF_CREATION__DD02208),
								scrollData: 8,
								dateTimeType: 'date',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 22,
								name: 'ValCreathou',
								area: 'FLDS',
								field: 'CREATHOU',
								label: computed(() => this.Resources.HOUR_OF_CREATION33629),
								dataLength: 5,
								scrollData: 5,
								dateTimeType: 'time',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 23,
								name: 'ValCreatins',
								area: 'FLDS',
								field: 'CREATINS',
								label: computed(() => this.Resources.COMPLETE_DATE_OF_CRE57046),
								scrollData: 15,
								dateTimeType: 'dateTimeSeconds',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 24,
								name: 'Equip.ValRegistnr',
								area: 'EQUIP',
								field: 'REGISTNR',
								label: computed(() => this.Resources.NO__REGISTER04207),
								dataLength: 6,
								scrollData: 6,
								export: 1,
								pkColumn: 'ValCodequip',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 25,
								name: 'ValTxtfield',
								area: 'FLDS',
								field: 'TXTFIELD',
								label: computed(() => this.Resources.TEXT_FIELD41810),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 26,
								name: 'ValEmailfld',
								area: 'FLDS',
								field: 'EMAILFLD',
								label: computed(() => this.Resources.EMAIL25170),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 27,
								name: 'ValZipfield',
								area: 'FLDS',
								field: 'ZIPFIELD',
								label: computed(() => this.Resources.ZIPCODE21021),
								dataLength: 8,
								scrollData: 8,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 28,
								name: 'ValIbanfiel',
								area: 'FLDS',
								field: 'IBANFIEL',
								label: computed(() => this.Resources.IBAN28506),
								dataLength: 34,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 29,
								name: 'ValSsnumber',
								area: 'FLDS',
								field: 'SSNUMBER',
								label: computed(() => this.Resources.SOCIAL_SECURITY_NO48150),
								dataLength: 11,
								scrollData: 11,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 30,
								name: 'ValLicplate',
								area: 'FLDS',
								field: 'LICPLATE',
								label: computed(() => this.Resources.LICENCE_PLATE07627),
								dataLength: 8,
								scrollData: 8,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 31,
								name: 'ValVatnumbr',
								area: 'FLDS',
								field: 'VATNUMBR',
								label: computed(() => this.Resources.VAT_NUMBER24236),
								dataLength: 9,
								scrollData: 9,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 32,
								name: 'ValBanknmbr',
								area: 'FLDS',
								field: 'BANKNMBR',
								label: computed(() => this.Resources.BANKING_ACCOUNT_NUMB62548),
								dataLength: 24,
								scrollData: 24,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 33,
								name: 'ValUpprtext',
								area: 'FLDS',
								field: 'UPPRTEXT',
								label: computed(() => this.Resources.UPPERCASE48238),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 34,
								name: 'ValPassfld',
								area: 'FLDS',
								field: 'PASSFLD',
								label: computed(() => this.Resources.PASSWORD09467),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 35,
								name: 'ValClrpicke',
								area: 'FLDS',
								field: 'CLRPICKE',
								label: computed(() => this.Resources.COLORPICKER39653),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 36,
								name: 'ValShwrc',
								area: 'FLDS',
								field: 'SHWRC',
								label: computed(() => this.Resources.SHOW_RECORD53851),
								scrollData: 1,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 37,
								name: 'ValRadiob',
								area: 'FLDS',
								field: 'RADIOB',
								label: computed(() => this.Resources.RADIO_BTN20980),
								dataLength: 5,
								scrollData: 5,
								export: 1,
								array: computed(() => new qProjArrays.QArrayRadiobtn(vm.$getResource).elements),
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'PTN_Menu_611',
							serverMode: true,
							pkColumn: 'ValCodflds',
							tableAlias: 'FLDS',
							tableNamePlural: computed(() => this.Resources.FIELD_TYPES49172),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.FIELD_TYPES49172),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: true
							},
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
										formName: 'FIELDHLP',
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
										formName: 'FIELDHLP',
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
										formName: 'FIELDHLP',
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
										formName: 'FIELDHLP',
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
									icon: { icon: 'add' },
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'FIELDHLP',
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
								id: 'RCA_PTN_6111',
								name: 'form-FIELDHLP',
								isVisible: true,
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodflds
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'FIELDHLP'
								}
							},
							formsDefinition: {
								'FIELDHLP': {
									fnKeySelector: (row) => row.Fields.ValCodflds,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValDescrip',
							defaultSearchColumnNameOriginal: 'ValDescrip',
							defaultColumnSorting: {
								columnName: 'ValDuration',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-EQUIP', 'changed-FLDS', 'changed-AERO'],
						uuid: '8c79866f-7459-4fd0-8b1b-b5434e42c174',
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
// USE /[MANUAL GQT FORM_CODEJS PTN_MENU_611]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT PTN_MENU_611]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS PTN_611]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS PTN_MENU_611]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
