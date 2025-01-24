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

	import MenuViewModel from './QMenuGQT_311ViewModel.js'

	const requiredTextResources = ['QMenuGQT_311', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS GQT_MENU_311]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuGqt311',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuGQT_311', false),

				interfaceMetadata: {
					id: 'QMenuGQT_311', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '311',
					isMenuList: true,
					designation: computed(() => this.Resources.REPAIRS18165),
					acronym: 'GQT_311',
					name: 'REPAR',
					route: 'menu-GQT_311',
					order: '311',
					controller: 'REPAR',
					action: 'GQT_Menu_311',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'GQT_Menu_311',
						controller: 'REPAR',
						action: 'GQT_Menu_311',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.NumericColumn({
								order: 1,
								name: 'ValNrrepara',
								area: 'REPAR',
								field: 'NRREPARA',
								label: computed(() => this.Resources.REPAIR_NO_45492),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
							new listColumnTypes.DateColumn({
								order: 2,
								name: 'ValDtrepara',
								area: 'REPAR',
								field: 'DTREPARA',
								label: computed(() => this.Resources.FIXED_IN00179),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'Equip.ValRegistnr',
								area: 'EQUIP',
								field: 'REGISTNR',
								label: computed(() => this.Resources.NO__REGISTER04207),
								dataLength: 6,
								scrollData: 6,
								pkColumn: 'ValCodequip',
							}),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'Equip.ValDesignat',
								area: 'EQUIP',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.EQUIPMENT03632),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodequip',
							}),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'Pesso.ValName',
								area: 'PESSO',
								field: 'NAME',
								label: computed(() => this.Resources.TECHNICAL18245),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodpesso',
							}),
							new listColumnTypes.ArrayColumn({
								order: 6,
								name: 'ValTipoarea',
								area: 'REPAR',
								field: 'TIPOAREA',
								label: computed(() => this.Resources.TECHNICAL_AREA50773),
								dataLength: 1,
								scrollData: 1,
								array: qProjArrays.QArrayAreatecn.setResources(vm.$getResource).elements,
								arrayType: qProjArrays.QArrayAreatecn.type,
							}),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'Speci.ValEspecial',
								area: 'SPECI',
								field: 'ESPECIAL',
								label: computed(() => this.Resources.SPECIALTY09304),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodespec',
							}),
							new listColumnTypes.TextColumn({
								order: 8,
								name: 'ValDescript',
								area: 'REPAR',
								field: 'DESCRIPT',
								label: computed(() => this.Resources.DESCRIPTION_OF_THE_R26085),
								scrollData: 30,
							}),
							new listColumnTypes.NumericColumn({
								order: 9,
								name: 'ValHours',
								area: 'REPAR',
								field: 'HOURS',
								label: computed(() => this.Resources.SPENT_ON_HOURS19285),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
							new listColumnTypes.TextColumn({
								order: 10,
								name: 'Cmpny.ValDesignat',
								area: 'CMPNY',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.COMPANY52963),
								dataLength: 85,
								scrollData: 30,
								visibility: false,
								pkColumn: 'ValCodempre',
							}),
						],
						config: {
							name: 'GQT_Menu_311',
							serverMode: true,
							pkColumn: 'ValCodrepar',
							tableAlias: 'REPAR',
							tableNamePlural: computed(() => this.Resources.REPAIRS18165),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.REPAIRS18165),
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
										formName: 'REPAR',
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
										formName: 'REPAR',
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
										formName: 'REPAR',
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
										formName: 'REPAR',
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
										formName: 'REPAR',
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
								id: 'RCA_GQT_3111',
								name: 'form-REPAR',
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodrepar
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'REPAR',
								}
							},
							formsDefinition: {
								'REPAR': {
									fnKeySelector: (row) => row.Fields.ValCodrepar,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValDtrepara',
							defaultSearchColumnNameOriginal: 'ValDtrepara',
							defaultColumnSorting: {
								columnName: 'ValDtrepara',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-EQUIP', 'changed-PESSO', 'changed-REPAR', 'changed-CATE1', 'changed-SPECI', 'changed-CMPNY'],
						uuid: 'eb5c42d7-9401-4743-a232-b08f9c554f17',
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
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_CODEJS GQT_MENU_311]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS GQT_311]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS GQT_MENU_311]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
