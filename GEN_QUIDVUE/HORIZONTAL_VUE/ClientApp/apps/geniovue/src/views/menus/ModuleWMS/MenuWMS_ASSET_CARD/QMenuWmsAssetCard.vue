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

	import MenuViewModel from './QMenuWMS_ASSET_CARDViewModel.js'

	const requiredTextResources = ['QMenuWMS_ASSET_CARD', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS WMS_MENU_ASSET_CARD]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuWmsAssetCard',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuWMS_ASSET_CARD', false),

				interfaceMetadata: {
					id: 'QMenuWMS_ASSET_CARD', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: 'ASSET_CARD',
					isMenuList: true,
					designation: computed(() => this.Resources.EQUIPMENTS06276),
					acronym: 'WMS_ASSET_CARD',
					name: 'ASSET',
					route: 'menu-WMS_ASSET_CARD',
					order: '41111',
					controller: 'ASSET',
					action: 'WMS_Menu_ASSET_CARD',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableSpecialRenderingControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'WMS_Menu_ASSET_CARD',
						controller: 'ASSET',
						action: 'WMS_Menu_ASSET_CARD',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.NumericColumn({
								order: 1,
								name: 'ValAssetnum',
								area: 'ASSET',
								field: 'ASSETNUM',
								label: computed(() => this.Resources.ASSET_NUMBER52372),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValName',
								area: 'ASSET',
								field: 'NAME',
								label: computed(() => this.Resources.IDENTIFICATION_NAME16317),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'Kinde.ValDesignat',
								area: 'KINDE',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.KIND_OF_EQUIPMENT22928),
								dataLength: 85,
								scrollData: 30,
								isVisible: false,
								pkColumn: 'ValCodkinde',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 4,
								name: 'ValIdenttyp',
								area: 'ASSET',
								field: 'IDENTTYP',
								label: computed(() => this.Resources.IDENTIFIER_TYPE60623),
								dataLength: 1,
								scrollData: 1,
								array: computed(() => new qProjArrays.QArrayIdenttyp(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayIdenttyp.type,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValGrai',
								area: 'ASSET',
								field: 'GRAI',
								label: computed(() => this.Resources.GRAI10374),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'ValGiai',
								area: 'ASSET',
								field: 'GIAI',
								label: computed(() => this.Resources.GIAI50592),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 7,
								name: 'ValPhoto',
								area: 'ASSET',
								field: 'PHOTO',
								label: computed(() => this.Resources.PHOTO51874),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.PHOTO51874)),
								scrollData: 3,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 8,
								name: 'Manuf.ValName',
								area: 'MANUF',
								field: 'NAME',
								label: computed(() => this.Resources.MANUFACTURER50759),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodentit',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.HyperLinkColumn({
								order: 9,
								name: 'Manuf.ValWebsite',
								area: 'MANUF',
								field: 'WEBSITE',
								label: computed(() => this.Resources.WEB_SITE06263),
								dataLength: 254,
								scrollData: 30,
								pkColumn: 'ValCodentit',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'WMS_Menu_ASSET_CARD',
							serverMode: true,
							pkColumn: 'ValCodasset',
							tableAlias: 'ASSET',
							tableNamePlural: computed(() => this.Resources.ASSETS12081),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.EQUIPMENTS06276),
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
										formName: 'EQUIPM',
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
										formName: 'EQUIPM',
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
										formName: 'EQUIPM',
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
										formName: 'EQUIPM',
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
										formName: 'EQUIPM',
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
								id: 'RCA_WMS_411111',
								name: 'form-EQUIPM',
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodasset
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'EDIT', formName: 'EQUIPM'
								}
							},
							formsDefinition: {
								'EQUIPM': {
									fnKeySelector: (row) => row.Fields.ValCodasset,
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
						globalEvents: ['changed-MANUF', 'changed-ASSET', 'changed-KINDE'],
						uuid: 'cbba1257-006c-407c-bff6-cb87a80d6f4e',
						allSelectedRows: 'false',
						viewModes: [
							{
								id: 'LIST',
								type: 'list',
								subtype: '',
								label: computed(() => this.Resources.LISTA13474),
								order: 1,
								mappingVariables: readonly({
								}),
								styleVariables: {
								},
								groups: {
								}
							},
							{
								id: 'CARDS',
								type: 'cards',
								subtype: 'card-img-top',
								label: computed(() => this.Resources.CARTOES27587),
								order: 2,
								mappingVariables: readonly({
									title: {
										allowsMultiple: false,
										sources: [
											'ASSET.NAME',
										]
									},
									subtitle: {
										allowsMultiple: false,
										sources: [
											'ASSET.ASSETNUM',
										]
									},
									text: {
										allowsMultiple: true,
										sources: [
											'ASSET.GRAI',
											'ASSET.GIAI',
										]
									},
									image: {
										allowsMultiple: false,
										sources: [
											'ASSET.PHOTO',
										]
									},
									btnHref: {
										allowsMultiple: false,
										sources: [
											'MANUF.WEBSITE',
										]
									},
								}),
								styleVariables: {
									actionsAlignment: {
										rawValue: 'right',
										isMapped: false
									},
									actionsStyle: {
										rawValue: 'dropdown',
										isMapped: false
									},
									backgroundColor: {
										rawValue: 'auto',
										isMapped: false
									},
									contentAlignment: {
										rawValue: 'left',
										isMapped: false
									},
									customFollowupDefaultTarget: {
										rawValue: 'blank',
										isMapped: false
									},
									customInsertCard: {
										rawValue: false,
										isMapped: false
									},
									customInsertCardStyle: {
										rawValue: 'secondary',
										isMapped: false
									},
									displayMode: {
										rawValue: 'grid',
										isMapped: false
									},
									containerAlignment: {
										rawValue: 'left',
										isMapped: false
									},
									hoverScaleAmount: {
										rawValue: 1.05,
										isMapped: false
									},
									imageShape: {
										rawValue: 'rectangular',
										isMapped: false
									},
									showColumnTitles: {
										rawValue: true,
										isMapped: false
									},
									showEmptyColumnTitles: {
										rawValue: true,
										isMapped: false
									},
									size: {
										rawValue: 'regular',
										isMapped: false
									},
								},
								groups: {
								}
							},
							{
								id: 'CAROUSEL',
								type: 'carousel',
								subtype: '',
								label: computed(() => this.Resources.CARROSSEL41899),
								order: 3,
								mappingVariables: readonly({
									slideTitle: {
										allowsMultiple: false,
										sources: [
											'ASSET.NAME',
										]
									},
									slideSubtitle: {
										allowsMultiple: false,
										sources: [
											'ASSET.ASSETNUM',
										]
									},
									slideImage: {
										allowsMultiple: false,
										sources: [
											'ASSET.PHOTO',
										]
									},
								}),
								styleVariables: {
									showIndicators: {
										rawValue: true,
										isMapped: false
									},
									showControls: {
										rawValue: true,
										isMapped: false
									},
									keyboardControllable: {
										rawValue: true,
										isMapped: false
									},
									autoCycleInterval: {
										rawValue: undefined,
										isMapped: false
									},
									autoCyclePause: {
										rawValue: 'hover',
										isMapped: false
									},
									ride: {
										rawValue: 'carousel',
										isMapped: false
									},
									wrap: {
										rawValue: true,
										isMapped: false
									},
								},
								groups: {
								}
							},
						],
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
			this.onBeforeRouteLeave(next)
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_CODEJS WMS_MENU_ASSET_CARD]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT WMS_MENU_ASSET_CARD]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS WMS_ASSET_CARD]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS WMS_MENU_ASSET_CARD]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
