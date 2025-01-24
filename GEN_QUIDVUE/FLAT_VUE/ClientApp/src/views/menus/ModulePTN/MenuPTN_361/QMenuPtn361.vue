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

	import MenuViewModel from './QMenuPTN_361ViewModel.js'

	const requiredTextResources = ['QMenuPTN_361', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PTN_MENU_361]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuPtn361',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuPTN_361', false),

				interfaceMetadata: {
					id: 'QMenuPTN_361', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '361',
					isMenuList: true,
					designation: computed(() => this.Resources.DESPESAS23133),
					acronym: 'PTN_361',
					name: 'DESPE',
					route: 'menu-PTN_361',
					order: '361',
					controller: 'EXPEN',
					action: 'PTN_Menu_361',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'PTN_Menu_361',
						controller: 'EXPEN',
						action: 'PTN_Menu_361',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Year.ValYear',
								area: 'YEAR',
								field: 'YEAR',
								label: computed(() => this.Resources.ANO33022),
								dataLength: 4,
								scrollData: 4,
								pkColumn: 'ValCodyear',
							}),
							new listColumnTypes.NumericColumn({
								order: 2,
								name: 'ValYearnumb',
								area: 'EXPEN',
								field: 'YEARNUMB',
								label: computed(() => this.Resources.ANO_NUMERICO_51058),
								scrollData: 4,
								maxDigits: 4,
								decimalPlaces: 0,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 3,
								name: 'Agreg.ValValue',
								area: 'AGREG',
								field: 'VALUE',
								label: computed(() => this.Resources.VALUE10285),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 0,
								pkColumn: 'ValCodaggre',
							}),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValDescript',
								area: 'EXPEN',
								field: 'DESCRIPT',
								label: computed(() => this.Resources.DESCRIPTION07383),
								dataLength: 85,
								scrollData: 30,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 5,
								name: 'ValValue',
								area: 'EXPEN',
								field: 'VALUE',
								label: computed(() => this.Resources.VALUE10285),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 0,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 6,
								name: 'ValPrevval',
								area: 'EXPEN',
								field: 'PREVVAL',
								label: computed(() => this.Resources.VALOR_ANTERIOR54849),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 0,
							}),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'Proje.ValProjecto',
								area: 'PROJE',
								field: 'PROJECTO',
								label: computed(() => this.Resources.PROJECTO50142),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodproje',
							}),
						],
						config: {
							name: 'PTN_Menu_361',
							serverMode: true,
							pkColumn: 'ValCoddespe',
							tableAlias: 'EXPEN',
							tableNamePlural: computed(() => this.Resources.EXPENSES11381),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.DESPESAS23133),
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
										formName: 'DESPE',
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
										formName: 'DESPE',
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
										formName: 'DESPE',
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
										formName: 'DESPE',
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
										formName: 'DESPE',
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
								{
									id: 'MB_3611',
									name: 'form-DESPE',
									title: computed(() => this.Resources.CUSTOM_ACTION_BUTTON06691),
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCoddespe
											},
										],
										action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'DESPE',
									}
								},
							],
							MCActions: [
							],
							rowClickAction: {
								id: 'RCA_PTN_36111',
								name: 'form-DESPE',
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCoddespe
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'DESPE',
								}
							},
							formsDefinition: {
								'DESPE': {
									fnKeySelector: (row) => row.Fields.ValCoddespe,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValDescript',
							defaultSearchColumnNameOriginal: 'ValDescript',
							defaultColumnSorting: {
								columnName: 'ValDescript',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-YEAR', 'changed-PROJE', 'changed-AGREG', 'changed-EXPEN'],
						uuid: '3612ebc8-c028-4cd6-b6af-3c0409fb81ba',
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
// USE /[MANUAL GQT FORM_CODEJS PTN_MENU_361]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS PTN_361]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS PTN_MENU_361]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
