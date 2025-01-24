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

	import MenuViewModel from './QMenuSTY_441ViewModel.js'

	const requiredTextResources = ['QMenuSTY_441', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS STY_MENU_441]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuSty441',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuSTY_441', false),

				interfaceMetadata: {
					id: 'QMenuSTY_441', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '441',
					isMenuList: true,
					designation: computed(() => this.Resources.PROPERTY_LIST14171),
					acronym: 'STY_441',
					name: 'ITEM',
					route: 'menu-STY_441',
					order: '441',
					controller: 'ITEM',
					action: 'STY_Menu_441',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'STY_Menu_441',
						controller: 'ITEM',
						action: 'STY_Menu_441',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Gitem.ValItemdes',
								area: 'GITEM',
								field: 'ITEMDES',
								label: computed(() => this.Resources.GLOBAL_ARTICLE17761),
								dataLength: 85,
								scrollData: 85,
								pkColumn: 'ValCodgitem',
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'Wareh.ValWarehdes',
								area: 'WAREH',
								field: 'WAREHDES',
								label: computed(() => this.Resources.WAREHOUSE51864),
								dataLength: 85,
								scrollData: 85,
								pkColumn: 'ValCodwareh',
							}),
							new listColumnTypes.ArrayColumn({
								order: 3,
								name: 'ValItemtype',
								area: 'ITEM',
								field: 'ITEMTYPE',
								label: computed(() => this.Resources.TYPE00312),
								dataLength: 1,
								scrollData: 1,
								array: qProjArrays.QArrayTipoarti.setResources(vm.$getResource).elements,
								arrayType: qProjArrays.QArrayTipoarti.type,
							}),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValItemdes',
								area: 'ITEM',
								field: 'ITEMDES',
								label: computed(() => this.Resources.ITEM40802),
								dataLength: 85,
								scrollData: 85,
							}),
							new listColumnTypes.NumericColumn({
								order: 5,
								name: 'ValEntries',
								area: 'ITEM',
								field: 'ENTRIES',
								label: computed(() => this.Resources.ENTRIES32319),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 6,
								name: 'ValExits',
								area: 'ITEM',
								field: 'EXITS',
								label: computed(() => this.Resources.OUTPUTS47833),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 7,
								name: 'ValExistenc',
								area: 'ITEM',
								field: 'EXISTENC',
								label: computed(() => this.Resources.STOCKS47349),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
							new listColumnTypes.ImageColumn({
								order: 8,
								name: 'ValImage',
								area: 'ITEM',
								field: 'IMAGE',
								label: computed(() => this.Resources.IMAGE65174),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.IMAGE65174)),
								scrollData: 3,
								sortable: false,
								searchable: false,
							}),
							new listColumnTypes.TextColumn({
								order: 9,
								name: 'ValCategory',
								area: 'ITEM',
								field: 'CATEGORY',
								label: computed(() => this.Resources.CATEGORY18978),
								scrollData: 85,
							}),
						],
						config: {
							name: 'STY_Menu_441',
							serverMode: true,
							pkColumn: 'ValCoditem',
							tableAlias: 'ITEM',
							tableNamePlural: computed(() => this.Resources.ARTICLES59822),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.PROPERTY_LIST14171),
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
										formName: 'PLIST',
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
										formName: 'PLIST',
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
										formName: 'PLIST',
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
										formName: 'PLIST',
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
										formName: 'PLIST',
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
								id: 'RCA_STY_4411',
								name: 'form-PLIST',
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCoditem
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'PLIST',
								}
							},
							formsDefinition: {
								'PLIST': {
									fnKeySelector: (row) => row.Fields.ValCoditem,
									isPopup: false
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'ValItemdes',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-WAREH', 'changed-GITEM', 'changed-ITEM'],
						uuid: '1a23820b-f641-4064-b042-83810cb95223',
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
// USE /[MANUAL GQT FORM_CODEJS STY_MENU_441]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS STY_441]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS STY_MENU_441]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
