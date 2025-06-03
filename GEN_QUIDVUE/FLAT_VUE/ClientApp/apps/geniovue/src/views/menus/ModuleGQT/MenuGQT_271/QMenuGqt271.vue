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

	import MenuViewModel from './QMenuGQT_271ViewModel.js'

	const requiredTextResources = ['QMenuGQT_271', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS GQT_MENU_271]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuGqt271',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuGQT_271', false),

				interfaceMetadata: {
					id: 'QMenuGQT_271', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '271',
					isMenuList: true,
					designation: computed(() => this.Resources.PEOPLE34206),
					acronym: 'GQT_271',
					name: 'PESSO',
					route: 'menu-GQT_271',
					order: '271',
					controller: 'PESSO',
					action: 'GQT_Menu_271',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableSpecialRenderingControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'GQT_Menu_271',
						controller: 'PESSO',
						action: 'GQT_Menu_271',
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
								area: 'PESSO',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 85,
								scrollData: 50,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 2,
								name: 'ValGender',
								area: 'PESSO',
								field: 'GENDER',
								label: computed(() => this.Resources.GENUS37471),
								dataLength: 1,
								scrollData: 1,
								array: computed(() => qProjArrays.QArrayGenero.setResources(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayGenero.type,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 3,
								name: 'ValDtnascim',
								area: 'PESSO',
								field: 'DTNASCIM',
								label: computed(() => this.Resources.BIRTH21799),
								scrollData: 8,
								dateTimeType: 'date',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValTelephon',
								area: 'PESSO',
								field: 'TELEPHON',
								label: computed(() => this.Resources.PHONE56703),
								dataLength: 20,
								scrollData: 20,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValEmail',
								area: 'PESSO',
								field: 'EMAIL',
								label: computed(() => this.Resources.EMAIL25170),
								dataLength: 254,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 6,
								name: 'ValPhotogra',
								area: 'PESSO',
								field: 'PHOTOGRA',
								label: computed(() => this.Resources.PHOTO51874),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.PHOTO51874)),
								scrollData: 3,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 7,
								name: 'ValIdfuncio',
								area: 'PESSO',
								field: 'IDFUNCIO',
								label: computed(() => this.Resources.OFFICIAL_NO_34819),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 8,
								name: 'ValDtultcat',
								area: 'PESSO',
								field: 'DTULTCAT',
								label: computed(() => this.Resources.SINCE47259),
								scrollData: 8,
								dateTimeType: 'date',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 9,
								name: 'Categ.ValCategoria',
								area: 'CATEG',
								field: 'CATEGORIA',
								label: computed(() => this.Resources.CATEGORY18978),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodcateg',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 10,
								name: 'Cmpny.ValDesignat',
								area: 'CMPNY',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.COMPANY52963),
								dataLength: 85,
								scrollData: 30,
								supportForm: 'EMPRE',
								supportFormIsPopup: true,
								params: {
									type: 'form',
									isRoute: true,
									formName: 'EMPRE',
									mode: 'SHOW'
								},
								cellAction: true,
								pkColumn: 'ValCodempre',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'GQT_Menu_271',
							serverMode: true,
							pkColumn: 'ValCodpesso',
							tableAlias: 'PESSO',
							tableNamePlural: computed(() => this.Resources.PEOPLE34206),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.PEOPLE34206),
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
										formName: 'PESSO',
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
										formName: 'PESSO',
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
										formName: 'PESSO',
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
										formName: 'PESSO',
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
										formName: 'PESSO',
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
								{
									id: 'MC_2711',
									name: 'MC_2711',
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCodpesso
											},
										],
										isControlled: true,
										isRoute: true,
										action: vm.openFormAction, type: 'form', mode: 'EDIT', formName: 'PESSOSEP',
									}
								},
								{
									id: 'MC_2712',
									name: 'MC_2712',
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCodpesso
											},
										],
										isControlled: true,
										isRoute: true,
										action: vm.openFormAction, type: 'form', mode: 'EDIT', formName: 'EXTERNO',
									}
								},
							],
							rowClickAction: {
								id: 'RCA_GQT_2711',
								name: 'GQT_MenuMC_271',
								params: {
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodpesso
										},
									],
									action: vm.openRoutineAction, type: 'routine', actionRoutine: this.GQT_MenuMC_271,
								}
							},
							formsDefinition: {
								'PESSO': {
									fnKeySelector: (row) => row.Fields.ValCodpesso,
									isPopup: false
								},
								'EMPRE': {
									fnKeySelector: (row) => row.Fields.ValCodempre,
									isPopup: true
								},
								'PESSOSEP': {
									fnKeySelector: (row) => row.Fields.ValCodpesso,
									isPopup: false
								},
								'EXTERNO': {
									fnKeySelector: (row) => row.Fields.ValCodpesso,
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
						globalEvents: ['changed-PESSO', 'changed-CATEG', 'changed-REGI1', 'changed-CNTRY', 'changed-CMPNY', 'changed-PAIS1'],
						uuid: 'e6dc0e9f-d5c7-4b9c-87f7-f7ac16dffec8',
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
								id: 'CAROUSEL',
								type: 'carousel',
								subtype: '',
								label: computed(() => this.Resources.CARROSSEL41899),
								order: 2,
								mappingVariables: readonly({
									slideTitle: {
										allowsMultiple: false,
										sources: [
											'PESSO.NAME',
										]
									},
									slideSubtitle: {
										allowsMultiple: false,
										sources: [
											'PESSO.EMAIL',
										]
									},
									slideImage: {
										allowsMultiple: false,
										sources: [
											'PESSO.PHOTOGRA',
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
										rawValue: 5000,
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
			// Listener for MC action in case of redirect by Jump if just one.
			this.$eventHub.on('EXEC-GQT_MenuMC_271', this.GQT_MenuMC_271)
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_CODEJS GQT_MENU_271]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
			// Listener for MC action in case of redirect by Jump if just one.
			this.$eventHub.off('EXEC-GQT_MenuMC_271', this.GQT_MenuMC_271)
		},

		methods: {
			/**
			 * Executes the specific paths with condition action.
			 * @param {string} params The request params
			 * @returns A promise to be resolved after the request completes
			 */
			GQT_MenuMC_271(params)
			{
				return netAPI.postData(
					this.controls.menu.controller,
					'GQT_MenuMC_271',
					params,
					(data) => {
						if (data.actionName)
							this.tableListMCAction(this.controls.menu, data.actionName, data.id)
					},
					undefined,
					undefined,
					this.navigationId)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS GQT_271]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS GQT_MENU_271]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
