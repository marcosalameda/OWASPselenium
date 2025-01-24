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

	import MenuViewModel from './QMenuGQT_521ViewModel.js'

	const requiredTextResources = ['QMenuGQT_521', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS GQT_MENU_521]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuGqt521',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuGQT_521', false),

				interfaceMetadata: {
					id: 'QMenuGQT_521', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '521',
					isMenuList: true,
					designation: computed(() => this.Resources.VENDAS00012),
					acronym: 'GQT_521',
					name: 'VENDA',
					route: 'menu-GQT_521',
					order: '521',
					controller: 'SALE',
					action: 'GQT_Menu_521',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'GQT_Menu_521',
						controller: 'SALE',
						action: 'GQT_Menu_521',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.NumericColumn({
								order: 1,
								name: 'ValNrlide',
								area: 'SALE',
								field: 'NRLIDE',
								label: computed(() => this.Resources.N_O_DA_LIDE50722),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
							new listColumnTypes.DateColumn({
								order: 2,
								name: 'ValStartdt',
								area: 'SALE',
								field: 'STARTDT',
								label: computed(() => this.Resources.BEGINNING18124),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValIdentifi',
								area: 'SALE',
								field: 'IDENTIFI',
								label: computed(() => this.Resources.IDENTIFICACAO_DA_OPO05341),
								dataLength: 85,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValPotcompr',
								area: 'SALE',
								field: 'POTCOMPR',
								label: computed(() => this.Resources.POTENCIAIS_COMPRADOR25099),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.BooleanColumn({
								order: 5,
								name: 'ValProspecc',
								area: 'SALE',
								field: 'PROSPECC',
								label: computed(() => this.Resources.PROSPECCAO_EFECTUADA42558),
								scrollData: 1,
							}),
							new listColumnTypes.BooleanColumn({
								order: 6,
								name: 'ValInteress',
								area: 'SALE',
								field: 'INTERESS',
								label: computed(() => this.Resources.INTERESSADO26080),
								scrollData: 1,
							}),
							new listColumnTypes.BooleanColumn({
								order: 7,
								name: 'ValSemrfina',
								area: 'SALE',
								field: 'SEMRFINA',
								label: computed(() => this.Resources.SEM_RECURSOS_FINANCE28439),
								scrollData: 1,
							}),
							new listColumnTypes.BooleanColumn({
								order: 8,
								name: 'ValSemcapac',
								area: 'SALE',
								field: 'SEMCAPAC',
								label: computed(() => this.Resources.SEM_CAPACIDADE_DE_DE07701),
								scrollData: 1,
							}),
							new listColumnTypes.DateColumn({
								order: 9,
								name: 'ValDtqualif',
								area: 'SALE',
								field: 'DTQUALIF',
								label: computed(() => this.Resources.QUALIFICACAO07026),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.BooleanColumn({
								order: 10,
								name: 'ValQualific',
								area: 'SALE',
								field: 'QUALIFIC',
								label: computed(() => this.Resources.QUALIFICACAO_EFECTUA30983),
								scrollData: 1,
							}),
							new listColumnTypes.DateColumn({
								order: 11,
								name: 'ValPreabord',
								area: 'SALE',
								field: 'PREABORD',
								label: computed(() => this.Resources.PRE_ABORDAGEM30870),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.BooleanColumn({
								order: 12,
								name: 'ValHomework',
								area: 'SALE',
								field: 'HOMEWORK',
								label: computed(() => this.Resources.TRABALHO_DE_CASA_EFE54337),
								scrollData: 1,
							}),
							new listColumnTypes.DateColumn({
								order: 13,
								name: 'ValDtaborda',
								area: 'SALE',
								field: 'DTABORDA',
								label: computed(() => this.Resources.ABORDAGEM05839),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.BooleanColumn({
								order: 14,
								name: 'ValApproach',
								area: 'SALE',
								field: 'APPROACH',
								label: computed(() => this.Resources.ABORDAGEM_EFECTUADA60152),
								scrollData: 1,
							}),
							new listColumnTypes.BooleanColumn({
								order: 15,
								name: 'ValApresent',
								area: 'SALE',
								field: 'APRESENT',
								label: computed(() => this.Resources.APRESENTACAO15975),
								scrollData: 1,
							}),
							new listColumnTypes.DateColumn({
								order: 16,
								name: 'ValDtaprese',
								area: 'SALE',
								field: 'DTAPRESE',
								label: computed(() => this.Resources.APRESENTACAO_EFECTUA37455),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.DateColumn({
								order: 17,
								name: 'ValDtsupera',
								area: 'SALE',
								field: 'DTSUPERA',
								label: computed(() => this.Resources.SUPERAR_OBJECOES02243),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.DateColumn({
								order: 18,
								name: 'ValTentfech',
								area: 'SALE',
								field: 'TENTFECH',
								label: computed(() => this.Resources.TENTATIVAS_DE_FECHO20342),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.DateColumn({
								order: 19,
								name: 'ValDtvenda',
								area: 'SALE',
								field: 'DTVENDA',
								label: computed(() => this.Resources.FECHO_DA_VENDA48081),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.DateColumn({
								order: 20,
								name: 'ValDtacompa',
								area: 'SALE',
								field: 'DTACOMPA',
								label: computed(() => this.Resources.ACOMPANHAMENTO53507),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
						],
						config: {
							name: 'GQT_Menu_521',
							serverMode: true,
							pkColumn: 'ValCodvenda',
							tableAlias: 'SALE',
							tableNamePlural: computed(() => this.Resources.SALES57222),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.VENDAS00012),
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
										formName: 'VENDA',
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
										formName: 'VENDA',
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
										formName: 'VENDA',
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
										formName: 'VENDA',
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
										formName: 'VENDA',
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
								id: 'RCA_GQT_5211',
								name: 'form-VENDA',
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodvenda
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'EDIT', formName: 'VENDA',
								}
							},
							formsDefinition: {
								'VENDA': {
									fnKeySelector: (row) => row.Fields.ValCodvenda,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValIdentifi',
							defaultSearchColumnNameOriginal: 'ValIdentifi',
							defaultColumnSorting: {
								columnName: 'ValStartdt',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-ORGAN', 'changed-SALE'],
						uuid: '21dca682-c791-4fe9-9d44-5aacca3310e1',
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
// USE /[MANUAL GQT FORM_CODEJS GQT_MENU_521]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS GQT_521]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS GQT_MENU_521]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
