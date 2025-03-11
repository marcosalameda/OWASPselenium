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

	import MenuViewModel from './QMenuPTN_LIST_DB_MC_FViewModel.js'

	const requiredTextResources = ['QMenuPTN_LIST_DB_MC_F', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PTN_MENU_LIST_DB_MC_F]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuPtnListDbMcF',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuPTN_LIST_DB_MC_F', false),

				interfaceMetadata: {
					id: 'QMenuPTN_LIST_DB_MC_F', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: 'LIST_DB_MC_F',
					isMenuList: true,
					designation: computed(() => this.Resources.ARTICLES59822),
					acronym: 'PTN_LIST_DB_MC_F',
					name: 'ITEM',
					route: 'menu-PTN_LIST_DB_MC_F',
					order: '371',
					controller: 'ITEM',
					action: 'PTN_Menu_LIST_DB_MC_F',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'PTN_Menu_LIST_DB_MC_F',
						controller: 'ITEM',
						action: 'PTN_Menu_LIST_DB_MC_F',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.ImageColumn({
								order: 1,
								name: 'ValImage',
								area: 'ITEM',
								field: 'IMAGE',
								label: computed(() => this.Resources.IMAGE65174),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.IMAGE65174)),
								scrollData: 3,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 2,
								name: 'ValDate',
								area: 'ITEM',
								field: 'DATE',
								label: computed(() => this.Resources.DATE18475),
								scrollData: 8,
								dateTimeType: 'date',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 3,
								name: 'ValDisponib',
								area: 'ITEM',
								field: 'DISPONIB',
								label: computed(() => this.Resources.AVAILABILITY56489),
								dataLength: 1,
								scrollData: 1,
								array: qProjArrays.QArrayDsiponib.setResources(vm.$getResource).elements,
								arrayType: qProjArrays.QArrayDsiponib.type,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 4,
								name: 'ValValid',
								area: 'ITEM',
								field: 'VALID',
								label: computed(() => this.Resources.IN_USE42606),
								scrollData: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'PTN_Menu_LIST_DB_MC_F',
							serverMode: true,
							pkColumn: 'ValCoditem',
							tableAlias: 'ITEM',
							tableNamePlural: computed(() => this.Resources.ARTICLES59822),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.ARTICLES59822),
							showAlternatePagination: true,
							permissions: {
								canView: false,
								canEdit: false,
								canDuplicate: false,
								canDelete: false,
								canInsert: false
							},
							searchBarConfig: {
								visibility: true,
								searchOnPressEnter: true
							},
							filtersVisible: true,
							allowColumnFilters: true,
							allowColumnSort: true,
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
								{
									id: 'MC_3711',
									name: 'MC_3711',
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCoditem
											},
										],
										isControlled: true,
										isRoute: true,
										action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'ARTIGVAL',
									}
								},
								{
									id: 'MC_3712',
									name: 'MC_3712',
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCoditem
											},
										],
										isControlled: true,
										isRoute: true,
										action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'ARTIGINV',
									}
								},
							],
							rowClickAction: {
								id: 'RCA_PTN_3711',
								name: 'PTN_MenuMC_LIST_DB_MC_F',
								params: {
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCoditem
										},
									],
									action: vm.openRoutineAction, type: 'routine', actionRoutine: this.PTN_MenuMC_LIST_DB_MC_F,
								}
							},
							formsDefinition: {
								'ARTIGVAL': {
									fnKeySelector: (row) => row.Fields.ValCoditem,
									isPopup: true
								},
								'ARTIGINV': {
									fnKeySelector: (row) => row.Fields.ValCoditem,
									isPopup: true
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-GITEM', 'changed-WAREH', 'changed-ITEM'],
						uuid: '0095f644-60e2-4281-9381-45308492694e',
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
			// Listener for MC action in case of redirect by Jump if just one.
			this.$eventHub.on('EXEC-PTN_MenuMC_LIST_DB_MC_F', this.PTN_MenuMC_LIST_DB_MC_F)
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_CODEJS PTN_MENU_LIST_DB_MC_F]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
			// Listener for MC action in case of redirect by Jump if just one.
			this.$eventHub.off('EXEC-PTN_MenuMC_LIST_DB_MC_F', this.PTN_MenuMC_LIST_DB_MC_F)
		},

		methods: {
			/**
			 * Executes the specific paths with condition action.
			 * @param {string} params The request params
			 * @returns A promise to be resolved after the request completes
			 */
			PTN_MenuMC_LIST_DB_MC_F(params)
			{
				return netAPI.postData(
					this.controls.menu.controller,
					'PTN_MenuMC_LIST_DB_MC_F',
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
// USE /[MANUAL GQT FUNCTIONS_JS PTN_LIST_DB_MC_F]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS PTN_MENU_LIST_DB_MC_F]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
