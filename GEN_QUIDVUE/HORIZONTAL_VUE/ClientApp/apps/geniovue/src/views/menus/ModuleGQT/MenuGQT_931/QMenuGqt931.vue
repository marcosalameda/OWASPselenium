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
	/* eslint-enable no-unused-vars */

	import MenuViewModel from './QMenuGQT_931ViewModel.js'

	const requiredTextResources = ['QMenuGQT_931', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS GQT_MENU_931]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuGqt931',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuGQT_931', false),

				interfaceMetadata: {
					id: 'QMenuGQT_931', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '931',
					isMenuList: true,
					designation: computed(() => this.Resources.ANEXOS_DIGITAIS01954),
					acronym: 'GQT_931',
					name: 'ANEXD',
					route: 'menu-GQT_931',
					order: '931',
					controller: 'ANEXD',
					action: 'GQT_Menu_931',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'GQT_Menu_931',
						controller: 'ANEXD',
						action: 'GQT_Menu_931',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Equip.ValRegistnr',
								area: 'EQUIP',
								field: 'REGISTNR',
								label: computed(() => this.Resources.NO__REGISTER04207),
								dataLength: 6,
								scrollData: 6,
								pkColumn: 'ValCodequip',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 2,
								name: 'ValDthranex',
								area: 'ANEXD',
								field: 'DTHRANEX',
								label: computed(() => this.Resources.ATTACHED26247),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValTitle',
								area: 'ANEXD',
								field: 'TITLE',
								label: computed(() => this.Resources.TITLE21885),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DocumentColumn({
								order: 4,
								name: 'ValDocument',
								area: 'ANEXD',
								field: 'DOCUMENT',
								label: computed(() => this.Resources.DOCUMENT00695),
								dataLength: 260,
								scrollData: 30,
								sortable: false,
								viewType: qEnums.documentViewTypeMode.preview,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'Langu.ValLangua',
								area: 'LANGU',
								field: 'LANGUA',
								label: computed(() => this.Resources.IDIOMA44057),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodlang',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'ValTittradu',
								area: 'ANEXD',
								field: 'TITTRADU',
								label: computed(() => this.Resources.TITULO_TRADUZIDO52244),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'GQT_Menu_931',
							serverMode: true,
							pkColumn: 'ValCodanexd',
							tableAlias: 'ANEXD',
							tableNamePlural: computed(() => this.Resources.DIGITAL_ATTACHEMENTS44886),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.ANEXOS_DIGITAIS01954),
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
										formName: 'ANEXD',
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
										formName: 'ANEXD',
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
										formName: 'ANEXD',
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
										formName: 'ANEXD',
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
										formName: 'ANEXD',
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
								id: 'RCA_GQT_9311',
								name: 'form-ANEXD',
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodanexd
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'ANEXD',
								}
							},
							formsDefinition: {
								'ANEXD': {
									fnKeySelector: (row) => row.Fields.ValCodanexd,
									isPopup: false
								},
							},
							insertCondition: {
								// eslint-disable-next-line no-unused-vars
								fnFormula(params)
								{
									return netAPI.postData(
										'Anexd',
										'ANEXD_InsertCondition',
										this.serverObjModel,
										undefined,
										undefined,
										undefined,
										this.navigationId)
								},
								dependencyEvents: ['fieldChange:equip.codequip'],
								isServerRecalc: false,
							},
							defaultSearchColumnName: 'ValTitle',
							defaultSearchColumnNameOriginal: 'ValTitle',
							defaultColumnSorting: {
								columnName: 'ValDthranex',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-EQUIP', 'changed-ANEXD', 'changed-LANGU'],
						uuid: 'd0edbebe-a828-4bc2-8c79-fd97739f9c49',
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
			this.onBeforeRouteLeave(next)
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_CODEJS GQT_MENU_931]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS GQT_931]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS GQT_MENU_931]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
