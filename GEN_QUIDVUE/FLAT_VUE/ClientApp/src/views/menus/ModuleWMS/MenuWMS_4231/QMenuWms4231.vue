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
					v-if="componentOnLoadProc.loaded"
					v-bind="model.menu"
					v-on="model.menu.handlers">
				</q-table>

				<q-table-extra-extension
					:list-ctrl="model.menu"
					v-on="model.menu.handlers" />
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

	const requiredTextResources = ['QMenuWMS_4231', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS WMS_MENU_4231]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuWms4231',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuWMS_4231', false),

				interfaceMetadata: {
					id: 'QMenuWMS_4231', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '4231',
					isMenuList: true,
					acronym: 'WMS_4231',
					name: 'FACTY',
					route: 'menu-WMS_4231',
					order: '4231',
					controller: 'FACTY',
					action: 'WMS_Menu_4231',
					isPopup: false
				},

				model: {
					menu: new controlClass.TableListControl({
						controller: 'FACTY',
						action: 'WMS_Menu_4231',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValType',
								area: 'FACTY',
								field: 'TYPE',
								label: computed(() => this.Resources.FACILITY_TYPE44577),
								dataLength: 25,
								scrollData: 25,
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValLayrname',
								area: 'FACTY',
								field: 'LAYRNAME',
								label: computed(() => this.Resources.LAYER_NAME49545),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValIconurl',
								area: 'FACTY',
								field: 'ICONURL',
								label: computed(() => this.Resources.ICON_URL07016),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValShadowur',
								area: 'FACTY',
								field: 'SHADOWUR',
								label: computed(() => this.Resources.SHADOW_URL57805),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.NumericColumn({
								order: 5,
								name: 'ValIconancx',
								area: 'FACTY',
								field: 'ICONANCX',
								label: computed(() => this.Resources.ICON_ANCHOR__X_AXIS_18664),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 6,
								name: 'ValIconancy',
								area: 'FACTY',
								field: 'ICONANCY',
								label: computed(() => this.Resources.ICON_ANCHOR__Y_AXIS_63725),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 7,
								name: 'ValIconheig',
								area: 'FACTY',
								field: 'ICONHEIG',
								label: computed(() => this.Resources.ICON_HEIGHT61896),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 8,
								name: 'ValIconwid',
								area: 'FACTY',
								field: 'ICONWID',
								label: computed(() => this.Resources.ICON_WIDTH02295),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 9,
								name: 'ValPopupanx',
								area: 'FACTY',
								field: 'POPUPANX',
								label: computed(() => this.Resources.POPUP_ANCHOR__X_AXIS15060),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 10,
								name: 'ValPopupany',
								area: 'FACTY',
								field: 'POPUPANY',
								label: computed(() => this.Resources.POPUP_ANCHOR__Y_AXIS64670),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 11,
								name: 'ValShadowax',
								area: 'FACTY',
								field: 'SHADOWAX',
								label: computed(() => this.Resources.SHADOW_ANCHOR__X_AXI31230),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 12,
								name: 'ValShadoway',
								area: 'FACTY',
								field: 'SHADOWAY',
								label: computed(() => this.Resources.SHADOW_ANCHOR__Y_AXI51495),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 13,
								name: 'ValShadowhe',
								area: 'FACTY',
								field: 'SHADOWHE',
								label: computed(() => this.Resources.SHADOW_HEIGHT64343),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 14,
								name: 'ValShadowwi',
								area: 'FACTY',
								field: 'SHADOWWI',
								label: computed(() => this.Resources.SHADOW_WIDTH01769),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}),
						],
						config: {
							name: 'WMS_Menu_4231',
							serverMode: true,
							pkColumn: 'ValCodfacty',
							tableAlias: 'FACTY',
							tableNamePlural: computed(() => this.Resources.FACILITY_TYPES57319),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.FACILITY_TYPES57319),
							showAlternatePagination: true,
							permissions: {
							},
							globalSearch: {
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
										formName: 'FACTY',
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
										formName: 'FACTY',
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
										formName: 'FACTY',
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
										formName: 'FACTY',
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
										formName: 'FACTY',
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
								id: 'RCA_WMS_42311',
								name: 'form-FACTY',
								params: {
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodfacty
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'FACTY',
								}
							},
							formsDefinition: {
								'FACTY': {
									fnKeySelector: (row) => row.Fields.ValCodfacty,
									isPopup: false
								},
							},
							rowValidation: {
								fnValidate: (row) => row.Fields.ValZzstate === 0,
								message: computed(() => this.Resources.ATENCAO__ESTA_FICHA_24725),
								class: 'c-table__row--pending'
							},
							// The list support form: FACTY
							crudConditions: {
							},
							defaultSearchColumnName: 'ValType',
							defaultSearchColumnNameOriginal: 'ValType',
							initialSortColumnName: '',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-FACTY'],
						uuid: '7e4470ed-09c8-442d-91d2-b76a9ecd0d88',
						allSelectedRows: 'false',
						headerLevel: 1
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
// USE /[MANUAL GQT FORM_CODEJS WMS_MENU_4231]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS WMS_MENU_4231]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
