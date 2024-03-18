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

	const requiredTextResources = ['QMenuPTN_141', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PTN_MENU_141]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuPtn141',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuPTN_141', false),

				interfaceMetadata: {
					id: 'QMenuPTN_141', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '141',
					isMenuList: true,
					acronym: 'PTN_141',
					name: 'ARTIG',
					route: 'menu-PTN_141',
					order: '141',
					controller: 'ITEM',
					action: 'PTN_Menu_141',
					isPopup: false
				},

				model: {
					menu: new controlClass.TableListControl({
						controller: 'ITEM',
						action: 'PTN_Menu_141',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.ImageColumn({
								order: 1,
								name: 'ValImage',
								area: 'ITEM',
								field: 'IMAGE',
								label: computed(() => this.Resources.IMAGE65174),
								scrollData: 3,
								sortable: false,
							}),
							new listColumnTypes.DateColumn({
								order: 2,
								name: 'ValDate',
								area: 'ITEM',
								field: 'DATE',
								label: computed(() => this.Resources.DATE18475),
								scrollData: 8,
								dateTimeType: 'Date',
							}),
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
							}),
							new listColumnTypes.BooleanColumn({
								order: 4,
								name: 'ValValid',
								area: 'ITEM',
								field: 'VALID',
								label: computed(() => this.Resources.IN_USE42606),
								scrollData: 1,
							}),
						],
						config: {
							name: 'PTN_Menu_141',
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
							globalSearch: {
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
								{
									id: 'MB_1411',
									name: 'PTN_MenuMC_1411',
									title: computed(() => this.Resources.EDITAR11616),
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCoditem
											},
										],
										action: vm.openRoutineAction, type: 'routine', actionRoutine: this.PTN_MenuMC_1411,
									}
								},
							],
							MCActions: [
								{
									id: 'MC_14111',
									name: 'MC_14111',
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCoditem
											},
										],
										isControlled: true,
										action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'ARTIGVAL',
									}
								},
								{
									id: 'MC_14112',
									name: 'MC_14112',
									params: {
										limits: [
											{
												identifier: 'id',
												fnValueSelector: (row) => row.ValCoditem
											},
										],
										isControlled: true,
										action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'ARTIGINV',
									}
								},
							],
							rowClickAction: {
								id: 'RCA_PTN_14111',
								name: 'PTN_MenuMC_1411',
								params: {
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCoditem
										},
									],
									action: vm.openRoutineAction, type: 'routine', actionRoutine: this.PTN_MenuMC_1411,
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
							rowValidation: {
								fnValidate: (row) => row.Fields.ValZzstate === 0,
								message: computed(() => this.Resources.ATENCAO__ESTA_FICHA_24725),
								class: 'c-table__row--pending'
							},
							crudConditions: {
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							initialSortColumnName: '',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-WAREH', 'changed-GITEM', 'changed-ITEM'],
						uuid: 'eb2c0e6f-2e0c-46f4-b7e3-9e1ea73e4037',
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
			// Listener for MC action in case of redirect by Jump if just one.
			this.$eventHub.on('EXEC-PTN_MenuMC_1411', this.PTN_MenuMC_1411)
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_CODEJS PTN_MENU_141]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
			// Listener for MC action in case of redirect by Jump if just one.
			this.$eventHub.off('EXEC-PTN_MenuMC_1411', this.PTN_MenuMC_1411)
		},

		methods: {
			/**
			 * Executes the specific paths with condition action.
			 * @param {string} params The request params
			 * @returns A promise to be resolved after the request completes
			 */
			PTN_MenuMC_1411(params)
			{
				return netAPI.postData(this.model.menu.controller, 'PTN_MenuMC_1411', params, (data) => {
					if (data.actionName)
						this.tableListMCAction(this.model.menu, data.actionName, data.id)
				}, undefined, undefined, this.navigationId)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS PTN_MENU_141]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
