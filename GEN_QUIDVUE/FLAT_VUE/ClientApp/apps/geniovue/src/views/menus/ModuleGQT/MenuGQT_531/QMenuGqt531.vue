<template>
	<teleport
		v-if="menuModalIsReady"
		:to="`#${uiContainersId.body}`"
		:disabled="!menuInfo.isPopup">
		<div
			class="form-horizontal"
			@submit.prevent>
			<q-row-container>
				<q-table
					v-bind="controls.menu"
					v-on="controls.menu.handlers">
					<template #header>
						<q-table-config
							:table-ctrl="controls.menu"
							v-on="controls.menu.handlers">
						</q-table-config>
					</template>
					<!-- USE /[MANUAL GQT CUSTOM_TABLE GQT_Menu_531]/ -->
				</q-table>
			</q-row-container>
		</div>
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

	import MenuViewModel from './QMenuGQT_531ViewModel.js'

	const requiredTextResources = ['QMenuGQT_531', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS GQT_MENU_531]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuGqt531',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuGQT_531', false),

				interfaceMetadata: {
					id: 'QMenuGQT_531', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '531',
					isMenuList: true,
					designation: computed(() => this.Resources.VENDAS00012),
					acronym: 'GQT_531',
					name: 'VENDA',
					route: 'menu-GQT_531',
					order: '531',
					controller: 'SALE',
					action: 'GQT_Menu_531',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'GQT_Menu_531',
						controller: 'SALE',
						action: 'GQT_Menu_531',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Organ.ValOrganiza',
								area: 'ORGAN',
								field: 'ORGANIZA',
								label: computed(() => this.Resources.ORGANIZACAO47877),
								dataLength: 85,
								scrollData: 30,
								export: 1,
								pkColumn: 'ValCodorgan',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 2,
								name: 'ValNrlide',
								area: 'SALE',
								field: 'NRLIDE',
								label: computed(() => this.Resources.N_O_DA_LIDE50722),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 3,
								name: 'ValStartdt',
								area: 'SALE',
								field: 'STARTDT',
								label: computed(() => this.Resources.BEGINNING18124),
								scrollData: 16,
								dateTimeType: 'dateTime',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValIdentifi',
								area: 'SALE',
								field: 'IDENTIFI',
								label: computed(() => this.Resources.IDENTIFICACAO_DA_OPO05341),
								dataLength: 85,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValPotcompr',
								area: 'SALE',
								field: 'POTCOMPR',
								label: computed(() => this.Resources.POTENCIAIS_COMPRADOR25099),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 6,
								name: 'ValProspecc',
								area: 'SALE',
								field: 'PROSPECC',
								label: computed(() => this.Resources.PROSPECCAO_EFECTUADA42558),
								scrollData: 1,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 7,
								name: 'ValInteress',
								area: 'SALE',
								field: 'INTERESS',
								label: computed(() => this.Resources.INTERESSADO26080),
								scrollData: 1,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 8,
								name: 'ValSemrfina',
								area: 'SALE',
								field: 'SEMRFINA',
								label: computed(() => this.Resources.SEM_RECURSOS_FINANCE28439),
								scrollData: 1,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 9,
								name: 'ValSemcapac',
								area: 'SALE',
								field: 'SEMCAPAC',
								label: computed(() => this.Resources.SEM_CAPACIDADE_DE_DE07701),
								scrollData: 1,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 10,
								name: 'ValDtqualif',
								area: 'SALE',
								field: 'DTQUALIF',
								label: computed(() => this.Resources.QUALIFICACAO07026),
								scrollData: 16,
								dateTimeType: 'dateTime',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 11,
								name: 'ValQualific',
								area: 'SALE',
								field: 'QUALIFIC',
								label: computed(() => this.Resources.QUALIFICACAO_EFECTUA30983),
								scrollData: 1,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 12,
								name: 'ValPreabord',
								area: 'SALE',
								field: 'PREABORD',
								label: computed(() => this.Resources.PRE_ABORDAGEM30870),
								scrollData: 16,
								dateTimeType: 'dateTime',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 13,
								name: 'ValHomework',
								area: 'SALE',
								field: 'HOMEWORK',
								label: computed(() => this.Resources.TRABALHO_DE_CASA_EFE54337),
								scrollData: 1,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 14,
								name: 'ValDtaborda',
								area: 'SALE',
								field: 'DTABORDA',
								label: computed(() => this.Resources.ABORDAGEM05839),
								scrollData: 16,
								dateTimeType: 'dateTime',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 15,
								name: 'ValApproach',
								area: 'SALE',
								field: 'APPROACH',
								label: computed(() => this.Resources.ABORDAGEM_EFECTUADA60152),
								scrollData: 1,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 16,
								name: 'ValApresent',
								area: 'SALE',
								field: 'APRESENT',
								label: computed(() => this.Resources.APRESENTACAO15975),
								scrollData: 1,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 17,
								name: 'ValDtaprese',
								area: 'SALE',
								field: 'DTAPRESE',
								label: computed(() => this.Resources.APRESENTACAO_EFECTUA37455),
								scrollData: 16,
								dateTimeType: 'dateTime',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 18,
								name: 'ValDtsupera',
								area: 'SALE',
								field: 'DTSUPERA',
								label: computed(() => this.Resources.SUPERAR_OBJECOES02243),
								scrollData: 16,
								dateTimeType: 'dateTime',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 19,
								name: 'ValTentfech',
								area: 'SALE',
								field: 'TENTFECH',
								label: computed(() => this.Resources.TENTATIVAS_DE_FECHO20342),
								scrollData: 16,
								dateTimeType: 'dateTime',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 20,
								name: 'ValDtvenda',
								area: 'SALE',
								field: 'DTVENDA',
								label: computed(() => this.Resources.FECHO_DA_VENDA48081),
								scrollData: 16,
								dateTimeType: 'dateTime',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 21,
								name: 'ValDtacompa',
								area: 'SALE',
								field: 'DTACOMPA',
								label: computed(() => this.Resources.ACOMPANHAMENTO53507),
								scrollData: 16,
								dateTimeType: 'dateTime',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'GQT_Menu_531',
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
								visibility: true
							},
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
									icon: { icon: 'add' },
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
								id: 'RCA_GQT_5311',
								name: 'form-VENDA',
								isVisible: true,
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodvenda
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'EDIT', formName: 'VENDA'
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
						globalEvents: ['changed-ORGAN', 'changed-SALE'],
						uuid: 'a300146c-6059-4337-93c5-37ca4f6a9191',
						allSelectedRows: 'false',
						headerLevel: 1,
						isActiveControl: computed(() => this.isActiveMenu)
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
// USE /[MANUAL GQT FORM_CODEJS GQT_MENU_531]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT GQT_MENU_531]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS GQT_531]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS GQT_MENU_531]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
