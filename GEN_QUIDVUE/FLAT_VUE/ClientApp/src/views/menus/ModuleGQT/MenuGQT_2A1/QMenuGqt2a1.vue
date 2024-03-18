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

	const requiredTextResources = ['QMenuGQT_2A1', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS GQT_MENU_2A1]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuGqt2a1',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuGQT_2A1', false),

				interfaceMetadata: {
					id: 'QMenuGQT_2A1', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '2A1',
					isMenuList: true,
					acronym: 'GQT_2A1',
					name: 'TPEQU',
					route: 'menu-GQT_2A1',
					order: '2A1',
					controller: 'TPEQU',
					action: 'GQT_Menu_2A1',
					isPopup: false
				},

				model: {
					menu: new controlClass.TableListControl({
						controller: 'TPEQU',
						action: 'GQT_Menu_2A1',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValTpequcod',
								area: 'TPEQU',
								field: 'TPEQUCOD',
								label: computed(() => this.Resources.CODE49225),
								dataLength: 20,
								scrollData: 20,
								// eslint-disable-next-line no-unused-vars, eqeqeq
								textColor: (row) => qApi.iif(qApi.emptyC(row.Fields.ValCorletra)==1,qApi.RGB(0,0,0),row.Fields.ValCorletra),
								// eslint-disable-next-line no-unused-vars, eqeqeq
								bgColor: (row) => qApi.iif(qApi.emptyC(row.Fields.ValBackcolo)==1,qApi.RGB(255,255,255),row.Fields.ValBackcolo),
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValTipoequi',
								area: 'TPEQU',
								field: 'TIPOEQUI',
								label: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValTpequpai',
								area: 'TPEQU',
								field: 'TPEQUPAI',
								label: computed(() => this.Resources.DEPENDENT_ON28321),
								dataLength: 20,
								scrollData: 20,
								visibility: false,
							}),
							new listColumnTypes.NumericColumn({
								order: 4,
								name: 'ValNivel',
								area: 'TPEQU',
								field: 'NIVEL',
								label: computed(() => this.Resources.LEVEL06184),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
								visibility: false,
							}),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValBackcolo',
								area: 'TPEQU',
								field: 'BACKCOLO',
								label: computed(() => this.Resources.BACKGROUND_COLOR47883),
								dataLength: 50,
								scrollData: 30,
								visibility: false,
							}),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'ValCorletra',
								area: 'TPEQU',
								field: 'CORLETRA',
								label: computed(() => this.Resources.LETTER_COLOR15736),
								dataLength: 50,
								scrollData: 30,
								visibility: false,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 7,
								name: 'ValPrecomax',
								area: 'TPEQU',
								field: 'PRECOMAX',
								label: computed(() => this.Resources.MAXIMUM_PRICE55489),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 0,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 8,
								name: 'ValPrecoult',
								area: 'TPEQU',
								field: 'PRECOULT',
								label: computed(() => this.Resources.LAST_PRICE25852),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 0,
							}),
						],
						config: {
							name: 'GQT_Menu_2A1',
							serverMode: true,
							pkColumn: 'ValCodtpequ',
							tableAlias: 'TPEQU',
							tableNamePlural: computed(() => this.Resources.TYPES_OF_EQUIPMENT61264),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.TYPES_OF_EQUIPMENT61264),
							showRecordCount: true,
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
										formName: 'TPEQU',
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
										formName: 'TPEQU',
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
										formName: 'TPEQU',
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
										formName: 'TPEQU',
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
										formName: 'TPEQU',
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
								id: 'RCA_GQT_2A11',
								name: 'menu-GQT_2A11',
								params: {
									limits: [
										{
											identifier: 'tpequ',
											fnValueSelector: (row) => row.ValCodtpequ
										},
									],
									action: vm.openMenuAction, type: 'menu', menuName: 'GQT_2A11',
								}
							},
							formsDefinition: {
								'TPEQU': {
									fnKeySelector: (row) => row.Fields.ValCodtpequ,
									isPopup: false
								},
							},
							rowValidation: {
								fnValidate: (row) => row.Fields.ValZzstate === 0,
								message: computed(() => this.Resources.ATENCAO__ESTA_FICHA_24725),
								class: 'c-table__row--pending'
							},
							// The list support form: TPEQU
							crudConditions: {
							},
							defaultSearchColumnName: 'ValTipoequi',
							defaultSearchColumnNameOriginal: 'ValTipoequi',
							initialSortColumnName: '',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-FAMIL', 'changed-TPEQU'],
						uuid: 'b0d536d8-bb60-4309-a860-eff17d0e5d21',
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
// USE /[MANUAL GQT FORM_CODEJS GQT_MENU_2A1]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS GQT_MENU_2A1]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
