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

	import MenuViewModel from './QMenuIMO_1311ViewModel.js'

	const requiredTextResources = ['QMenuIMO_1311', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS IMO_MENU_1311]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuImo1311',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuIMO_1311', false),

				interfaceMetadata: {
					id: 'QMenuIMO_1311', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '1311',
					isMenuList: true,
					designation: computed(() => this.Resources.REAL_ESTATE24996),
					acronym: 'IMO_1311',
					name: 'PROPR',
					route: 'menu-IMO_1311',
					order: '1311',
					controller: 'PROPR',
					action: 'IMO_Menu_1311',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'IMO_Menu_1311',
						controller: 'PROPR',
						action: 'IMO_Menu_1311',
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
								area: 'PROPR',
								field: 'NAME',
								label: computed(() => this.Resources.PROPERTY43977),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 2,
								name: 'ValPrecoest',
								area: 'PROPR',
								field: 'PRECOEST',
								label: computed(() => this.Resources.ESTIMATED_PRICE02986),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'Tppro.ValTppropri',
								area: 'TPPRO',
								field: 'TPPROPRI',
								label: computed(() => this.Resources.TYPE00312),
								dataLength: 20,
								scrollData: 20,
								pkColumn: 'ValCodtppro',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValEndereco',
								area: 'PROPR',
								field: 'ENDERECO',
								label: computed(() => this.Resources.ADDRESS04342),
								scrollData: 30,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValLocalida',
								area: 'PROPR',
								field: 'LOCALIDA',
								label: computed(() => this.Resources.LOCALE34521),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'Regio.ValRegiao',
								area: 'REGIO',
								field: 'REGIAO',
								label: computed(() => this.Resources.REGION12723),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodregia',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'ValPostalco',
								area: 'PROPR',
								field: 'POSTALCO',
								label: computed(() => this.Resources.ZIP_CODE56964),
								dataLength: 20,
								scrollData: 20,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 8,
								name: 'ValPostallo',
								area: 'PROPR',
								field: 'POSTALLO',
								label: computed(() => this.Resources.POSTAL_LOCATION08708),
								dataLength: 50,
								scrollData: 30,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 9,
								name: 'Cntry.ValCountry',
								area: 'CNTRY',
								field: 'COUNTRY',
								label: computed(() => this.Resources.COUNTRY64133),
								dataLength: 90,
								scrollData: 30,
								isVisible: false,
								pkColumn: 'ValCodcntry',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 10,
								name: 'ValMobilada',
								area: 'PROPR',
								field: 'MOBILADA',
								label: computed(() => this.Resources.FURNISHED37431),
								scrollData: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 11,
								name: 'ValQtd_wc',
								area: 'PROPR',
								field: 'QTD_WC',
								label: computed(() => this.Resources.TOILET13557),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 12,
								name: 'ValQtdquart',
								area: 'PROPR',
								field: 'QTDQUART',
								label: computed(() => this.Resources.ROOMS06809),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 13,
								name: 'ValM2',
								area: 'PROPR',
								field: 'M2',
								label: computed(() => this.Resources.M212241),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 14,
								name: 'ValDtdispon',
								area: 'PROPR',
								field: 'DTDISPON',
								label: computed(() => this.Resources.AVAILABILITY56489),
								scrollData: 8,
								dateTimeType: 'date',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 15,
								name: 'ValPhotogra',
								area: 'PROPR',
								field: 'PHOTOGRA',
								label: computed(() => this.Resources.PHOTO51874),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.PHOTO51874)),
								scrollData: 3,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 16,
								name: 'ValDescript',
								area: 'PROPR',
								field: 'DESCRIPT',
								label: computed(() => this.Resources.DESCRIPTION07383),
								scrollData: 30,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'IMO_Menu_1311',
							serverMode: true,
							pkColumn: 'ValCodpropr',
							tableAlias: 'PROPR',
							tableNamePlural: computed(() => this.Resources.PROPERTIES34868),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.REAL_ESTATE24996),
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
										formName: 'PROPR00',
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
										formName: 'PROPR00',
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
										formName: 'PROPR00',
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
										formName: 'PROPR00',
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
										formName: 'PROPR00',
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
								id: 'RCA_IMO_13111',
								name: 'form-PROPR00',
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodpropr
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'PROPR00',
								}
							},
							formsDefinition: {
								'PROPR00': {
									fnKeySelector: (row) => row.Fields.ValCodpropr,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValName',
							defaultSearchColumnNameOriginal: 'ValName',
							defaultColumnSorting: {
								columnName: 'ValName',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-REGIO', 'changed-PAIS1', 'changed-CNTRY', 'changed-PESSO', 'changed-PROPR', 'changed-TPPRO'],
						uuid: 'b6a2ec7f-338e-44c1-acf0-952b71cb46b6',
						allSelectedRows: 'false',
						headerLevel: 1,
						/** Menu limits */
						controlLimits: [
							/** DB */
							{
								identifier: 'cntry',
								dependencyEvents: [],
								dependencyField: '',
								fnValueSelector: () => vm.$route.params['cntry'],
							},
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
// USE /[MANUAL GQT FORM_CODEJS IMO_MENU_1311]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS IMO_1311]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS IMO_MENU_1311]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
