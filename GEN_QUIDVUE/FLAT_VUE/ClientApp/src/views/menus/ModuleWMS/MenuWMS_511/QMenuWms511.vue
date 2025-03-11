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

	import MenuViewModel from './QMenuWMS_511ViewModel.js'

	const requiredTextResources = ['QMenuWMS_511', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS WMS_MENU_511]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuWms511',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuWMS_511', false),

				interfaceMetadata: {
					id: 'QMenuWMS_511', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '511',
					isMenuList: true,
					designation: computed(() => this.Resources.ENTITIES22578),
					acronym: 'WMS_511',
					name: 'ENTIT',
					route: 'menu-WMS_511',
					order: '511',
					controller: 'ENTIT',
					action: 'WMS_Menu_511',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'WMS_Menu_511',
						controller: 'ENTIT',
						action: 'WMS_Menu_511',
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
								area: 'ENTIT',
								field: 'NAME',
								label: computed(() => this.Resources.LEGAL_NAME42902),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValInitials',
								area: 'ENTIT',
								field: 'INITIALS',
								label: computed(() => this.Resources.COMPANY_INITIALS56204),
								dataLength: 10,
								scrollData: 10,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValRegistra',
								area: 'ENTIT',
								field: 'REGISTRA',
								label: computed(() => this.Resources.LEGAL_REGISTRATION04413),
								dataLength: 30,
								scrollData: 20,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValTaxnumbe',
								area: 'ENTIT',
								field: 'TAXNUMBE',
								label: computed(() => this.Resources.VAT_NUMBER24236),
								dataLength: 30,
								scrollData: 20,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValEmail',
								area: 'ENTIT',
								field: 'EMAIL',
								label: computed(() => this.Resources.EMAIL25170),
								dataLength: 254,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'ValPhonenum',
								area: 'ENTIT',
								field: 'PHONENUM',
								label: computed(() => this.Resources.PHONE_NUMBER20774),
								dataLength: 20,
								scrollData: 20,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.HyperLinkColumn({
								order: 7,
								name: 'ValWebsite',
								area: 'ENTIT',
								field: 'WEBSITE',
								label: computed(() => this.Resources.WEB_SITE06263),
								dataLength: 254,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 8,
								name: 'ValPerson',
								area: 'ENTIT',
								field: 'PERSON',
								label: computed(() => this.Resources.PERSON_DEPARTMENT_TO28777),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 9,
								name: 'ValIban',
								area: 'ENTIT',
								field: 'IBAN',
								label: computed(() => this.Resources.IBAN__INTERNATIONAL_45066),
								dataLength: 33,
								scrollData: 25,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 10,
								name: 'ValBuilding',
								area: 'ENTIT',
								field: 'BUILDING',
								label: computed(() => this.Resources.BUILDING_HOUSE_NUMBE20738),
								dataLength: 25,
								scrollData: 10,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 11,
								name: 'ValStreet',
								area: 'ENTIT',
								field: 'STREET',
								label: computed(() => this.Resources.STREET44324),
								dataLength: 50,
								scrollData: 30,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 12,
								name: 'ValTown',
								area: 'ENTIT',
								field: 'TOWN',
								label: computed(() => this.Resources.TOWN_CITY16259),
								dataLength: 50,
								scrollData: 30,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 13,
								name: 'ValCounty',
								area: 'ENTIT',
								field: 'COUNTY',
								label: computed(() => this.Resources.COUNTY_PROVINCE34285),
								dataLength: 50,
								scrollData: 30,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 14,
								name: 'ValState',
								area: 'ENTIT',
								field: 'STATE',
								label: computed(() => this.Resources.STATE_PROVINCE28516),
								dataLength: 50,
								scrollData: 30,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 15,
								name: 'ValPobox',
								area: 'ENTIT',
								field: 'POBOX',
								label: computed(() => this.Resources.POST_OFFICE_BOX06223),
								dataLength: 5,
								scrollData: 5,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 16,
								name: 'ValPostalco',
								area: 'ENTIT',
								field: 'POSTALCO',
								label: computed(() => this.Resources.ZIP_POSTAL_CODE55613),
								dataLength: 10,
								scrollData: 30,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 17,
								name: 'ValTelephon',
								area: 'ENTIT',
								field: 'TELEPHON',
								label: computed(() => this.Resources.TELEPHONE28697),
								dataLength: 20,
								scrollData: 20,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 18,
								name: 'ValFax',
								area: 'ENTIT',
								field: 'FAX',
								label: computed(() => this.Resources.FAX08532),
								dataLength: 20,
								scrollData: 20,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 19,
								name: 'ValContact',
								area: 'ENTIT',
								field: 'CONTACT',
								label: computed(() => this.Resources.CONTACT_TELEPHONE_NU12694),
								dataLength: 30,
								scrollData: 20,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 20,
								name: 'ValManufact',
								area: 'ENTIT',
								field: 'MANUFACT',
								label: computed(() => this.Resources.MANUFACTURER50759),
								scrollData: 1,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 21,
								name: 'ValFounded',
								area: 'ENTIT',
								field: 'FOUNDED',
								label: computed(() => this.Resources.FOUNDED_IN54120),
								scrollData: 8,
								dateTimeType: 'date',
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 22,
								name: 'Faci1.ValName',
								area: 'FACI1',
								field: 'NAME',
								label: computed(() => this.Resources.FACILITY_NAME19514),
								dataLength: 85,
								scrollData: 30,
								isVisible: false,
								pkColumn: 'ValCodfacil',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 23,
								name: 'Faci2.ValName',
								area: 'FACI2',
								field: 'NAME',
								label: computed(() => this.Resources.FACILITY_NAME19514),
								dataLength: 85,
								scrollData: 30,
								isVisible: false,
								pkColumn: 'ValCodfacil',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 24,
								name: 'ValLanguage',
								area: 'ENTIT',
								field: 'LANGUAGE',
								label: computed(() => this.Resources.LANGUAGE16872),
								dataLength: 2,
								scrollData: 2,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 25,
								name: 'ValCurrency',
								area: 'ENTIT',
								field: 'CURRENCY',
								label: computed(() => this.Resources.CURRENCY13881),
								dataLength: 3,
								scrollData: 3,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 26,
								name: 'ValOwner',
								area: 'ENTIT',
								field: 'OWNER',
								label: computed(() => this.Resources.OWNER09558),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 27,
								name: 'ValCarrier',
								area: 'ENTIT',
								field: 'CARRIER',
								label: computed(() => this.Resources.CARRIER64855),
								scrollData: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 28,
								name: 'ValSupplier',
								area: 'ENTIT',
								field: 'SUPPLIER',
								label: computed(() => this.Resources.SUPPLIER17230),
								scrollData: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'WMS_Menu_511',
							serverMode: true,
							pkColumn: 'ValCodentit',
							tableAlias: 'ENTIT',
							tableNamePlural: computed(() => this.Resources.ENTITIES22578),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.ENTITIES22578),
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
										formName: 'ENTIX',
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
										formName: 'ENTIX',
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
										formName: 'ENTIX',
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
										formName: 'ENTIX',
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
										formName: 'ENTIX',
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
								id: 'RCA_WMS_5111',
								name: 'form-ENTIX',
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodentit
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'EDIT', formName: 'ENTIX',
								}
							},
							formsDefinition: {
								'ENTIX': {
									fnKeySelector: (row) => row.Fields.ValCodentit,
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
						globalEvents: ['changed-FACI1', 'changed-ENTIT', 'changed-FACI2'],
						uuid: '07a4ae81-9ea2-4709-901d-950c72bb072b',
						allSelectedRows: 'false',
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
// USE /[MANUAL GQT FORM_CODEJS WMS_MENU_511]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS WMS_511]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS WMS_MENU_511]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
