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

	import MenuViewModel from './QMenuWMS_2311ViewModel.js'

	const requiredTextResources = ['QMenuWMS_2311', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS WMS_MENU_2311]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuWms2311',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuWMS_2311', false),

				interfaceMetadata: {
					id: 'QMenuWMS_2311', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '2311',
					isMenuList: true,
					designation: computed(() => this.Resources.DISPATCHES13773),
					acronym: 'WMS_2311',
					name: 'DISPA',
					route: 'menu-WMS_2311',
					order: '2311',
					controller: 'DISPA',
					action: 'WMS_Menu_2311',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'WMS_Menu_2311',
						controller: 'DISPA',
						action: 'WMS_Menu_2311',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValDispadt',
								area: 'DISPA',
								field: 'DISPADT',
								label: computed(() => this.Resources.DISPATCH_DATE54413),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.NumericColumn({
								order: 2,
								name: 'ValDispanr',
								area: 'DISPA',
								field: 'DISPANR',
								label: computed(() => this.Resources.DISPATCH_NUMBER23616),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'Entit.ValName',
								area: 'ENTIT',
								field: 'NAME',
								label: computed(() => this.Resources.CUSTOMER51658),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodentit',
							}),
						],
						config: {
							name: 'WMS_Menu_2311',
							serverMode: true,
							pkColumn: 'ValCoddispa',
							tableAlias: 'DISPA',
							tableNamePlural: computed(() => this.Resources.DISPATCHES13773),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.DISPATCHES13773),
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
										formName: 'DISPA',
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
										formName: 'DISPA',
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
										formName: 'DISPA',
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
										formName: 'DISPA',
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
										formName: 'DISPA',
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
								id: 'RCA_WMS_23111',
								name: 'form-DISPA',
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCoddispa
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'DISPA',
								}
							},
							formsDefinition: {
								'DISPA': {
									fnKeySelector: (row) => row.Fields.ValCoddispa,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValDispanr',
							defaultSearchColumnNameOriginal: 'ValDispanr',
							defaultColumnSorting: {
								columnName: 'ValDispadt',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-DISPA', 'changed-PERSO', 'changed-ENTIT', 'changed-DISST'],
						uuid: '26adf4c3-c69b-49c3-9b58-2dd6e756779a',
						allSelectedRows: 'false',
						headerLevel: 1,
						/** Menu limits */
						controlLimits: [
							/** SC */
						]
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
// USE /[MANUAL GQT FORM_CODEJS WMS_MENU_2311]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS WMS_2311]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS WMS_MENU_2311]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
