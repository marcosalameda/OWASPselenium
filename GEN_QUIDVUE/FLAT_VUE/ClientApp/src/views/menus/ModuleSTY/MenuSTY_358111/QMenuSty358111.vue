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

	import MenuViewModel from './QMenuSTY_358111ViewModel.js'

	const requiredTextResources = ['QMenuSTY_358111', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS STY_MENU_358111]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuSty358111',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuSTY_358111', false),

				interfaceMetadata: {
					id: 'QMenuSTY_358111', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '358111',
					isMenuList: true,
					designation: computed(() => this.Resources.LISTA_DE_CAMPOS37609),
					acronym: 'STY_358111',
					name: 'CAMPO',
					route: 'menu-STY_358111',
					order: '358111',
					controller: 'FLDS',
					action: 'STY_Menu_358111',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'STY_Menu_358111',
						controller: 'FLDS',
						action: 'STY_Menu_358111',
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
								label: computed(() => this.Resources.NOME_DA_COMPANHIA48638),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodaero',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValDescrip',
								area: 'FLDS',
								field: 'DESCRIP',
								label: computed(() => this.Resources.DESCRICAO51618),
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 3,
								name: 'ValNpassage',
								area: 'FLDS',
								field: 'NPASSAGE',
								label: computed(() => this.Resources.CAPACIDADE_DE_PASSEI42438),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 4,
								name: 'ValDuration',
								area: 'FLDS',
								field: 'DURATION',
								label: computed(() => this.Resources.DURACAO_VIAGEM00021),
								scrollData: 5,
								maxDigits: 2,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 5,
								name: 'ValPrice',
								area: 'FLDS',
								field: 'PRICE',
								label: computed(() => this.Resources.PRECO_DO_BILHETE_ARR20993),
								scrollData: 6,
								maxDigits: 3,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 6,
								name: 'ValPrecobil',
								area: 'FLDS',
								field: 'PRECOBIL',
								label: computed(() => this.Resources.PRECO_DO_BILHETE_AS_59630),
								scrollData: 6,
								maxDigits: 3,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 7,
								name: 'ValDate',
								area: 'FLDS',
								field: 'DATE',
								label: computed(() => this.Resources.DATA_DE_PARTIDA__DD_26044),
								scrollData: 8,
								dateTimeType: 'date',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 8,
								name: 'ValDatetime',
								area: 'FLDS',
								field: 'DATETIME',
								label: computed(() => this.Resources.DATA_DE_PARTIDA__HOR47484),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 9,
								name: 'ValDateseco',
								area: 'FLDS',
								field: 'DATESECO',
								label: computed(() => this.Resources.DATA_DE_PARTIDA__SEG38575),
								scrollData: 19,
								dateTimeType: 'dateTimeSeconds',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 10,
								name: 'ValTime',
								area: 'FLDS',
								field: 'TIME',
								label: computed(() => this.Resources.HORA_DE_PARTIDA00929),
								dataLength: 5,
								scrollData: 5,
								dateTimeType: 'time',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 11,
								name: 'ValYear',
								area: 'FLDS',
								field: 'YEAR',
								label: computed(() => this.Resources.ANO_DE_CRIACAO_DO_AE38604),
								scrollData: 4,
								maxDigits: 4,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 12,
								name: 'ValPrimviag',
								area: 'FLDS',
								field: 'PRIMVIAG',
								label: computed(() => this.Resources._1AVIAGEM10982),
								scrollData: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 13,
								name: 'ValConditio',
								area: 'FLDS',
								field: 'CONDITIO',
								label: computed(() => this.Resources.JA_VIAJOU_ANTES_22497),
								scrollData: 1,
								maxDigits: 1,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 14,
								name: 'ValClass',
								area: 'FLDS',
								field: 'CLASS',
								label: computed(() => this.Resources.CLASS__ENUMERACAO_DE17340),
								dataLength: 2,
								scrollData: 2,
								array: qProjArrays.QArrayClass.setResources(vm.$getResource).elements,
								arrayType: qProjArrays.QArrayClass.type,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 15,
								name: 'ValClassnum',
								area: 'FLDS',
								field: 'CLASSNUM',
								label: computed(() => this.Resources.CLASSE__ENUMERACAO_N29443),
								scrollData: 1,
								maxDigits: 1,
								decimalPlaces: 0,
								array: qProjArrays.QArrayClassnum.setResources(vm.$getResource).elements,
								arrayType: qProjArrays.QArrayClassnum.type,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 16,
								name: 'ValLogicenu',
								area: 'FLDS',
								field: 'LOGICENU',
								label: computed(() => this.Resources._1A_VIAGEM__ENUMERAC07656),
								scrollData: 1,
								array: qProjArrays.QArrayPrimviag.setResources(vm.$getResource).elements,
								arrayType: qProjArrays.QArrayPrimviag.type,
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
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DocumentColumn({
								order: 18,
								name: 'ValAttach',
								area: 'FLDS',
								field: 'ATTACH',
								label: computed(() => this.Resources.ANEXOS65235),
								dataLength: 50,
								scrollData: 30,
								sortable: false,
								viewType: qEnums.documentViewTypeMode.print,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 19,
								name: 'ValCreatuse',
								area: 'FLDS',
								field: 'CREATUSE',
								label: computed(() => this.Resources.CRIADO_POR17895),
								dataLength: 20,
								scrollData: 20,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 20,
								name: 'ValCreatdat',
								area: 'FLDS',
								field: 'CREATDAT',
								label: computed(() => this.Resources.DATA_DE_CRIACAO__DD_33541),
								scrollData: 8,
								dateTimeType: 'date',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 21,
								name: 'ValCreathou',
								area: 'FLDS',
								field: 'CREATHOU',
								label: computed(() => this.Resources.HORA_DE_CRIACAO40754),
								dataLength: 5,
								scrollData: 5,
								dateTimeType: 'time',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 22,
								name: 'ValCreatins',
								area: 'FLDS',
								field: 'CREATINS',
								label: computed(() => this.Resources.DATA_DE_CRIACAO_COMP31582),
								scrollData: 15,
								dateTimeType: 'dateTimeSeconds',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'STY_Menu_358111',
							serverMode: true,
							pkColumn: 'ValCodflds',
							tableAlias: 'FLDS',
							tableNamePlural: computed(() => this.Resources.FIELD_TYPES49172),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.LISTA_DE_CAMPOS37609),
							perPage: 6,
							showAlternatePagination: true,
							permissions: {
								canEdit: false,
								canDuplicate: false,
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
										formName: 'INFIELDS',
										mode: 'SHOW',
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
										formName: 'INFIELDS',
										mode: 'DELETE',
										isControlled: true
									}
								}
							],
							generalActions: [
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
								id: 'RCA_STY_3581111',
								name: 'form-INFIELDS',
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodflds
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'INFIELDS',
								}
							},
							formsDefinition: {
								'INFIELDS': {
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
						uuid: 'b4876464-045a-4467-8a78-71f8b25b3bcd',
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
			this.onBeforeRouteLeave(to, next)
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_CODEJS STY_MENU_358111]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS STY_358111]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS STY_MENU_358111]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
