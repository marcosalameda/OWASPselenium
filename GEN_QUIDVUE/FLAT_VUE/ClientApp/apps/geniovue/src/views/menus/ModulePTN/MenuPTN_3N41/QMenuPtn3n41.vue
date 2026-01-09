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
<!--Platform: VUE | Type: CUSTOM_TABLE | Module: GQT | Parameter: PTN_Menu_3N41 | File:  | Order: 0-->
<!--BEGIN_MANUALCODE_CODMANUA:0f967097-a8f0-41aa-b799-811b51a8acf5-->
					<template #column_Entidade_Concelho_ValNome="{ column }">
						<span v-html="column.label"></span>
					</template>
					<template #Entidade_Concelho_ValNome="{ row, column, cellValue, emitEvent }">
						<template v-if="cellValue !== ' '">
							<a class="column-data-link"
							   :title="column.dataTitle"
							   data-table-action-selected="false"
							   tabindex="-1"
							   @click.stop.prevent="openFreguesias(row)"
							   @keydown.enter="openFreguesias(row)">
								{{cellValue}}
							</a>
							<br />
							<span style="color: var(--q-theme-neutral); font-size: 8pt;" class="only-top-border">
								{{ row?.Fields["Entidade.Concelho.ValPop_residente"] }}
							</span>
						</template>
						<span v-else class="join-top-border"></span>
					</template>
					<template #column_Entidade_ValEntidade="{ column }">
						<span v-html="column.label"></span>
					</template>
					<template #Entidade_ValEntidade="{ row, column, cellValue, emitEvent }">
						<template v-if="cellValue !== ' '">
							<a class="column-data-link"
							   :title="column.dataTitle"
							   data-table-action-selected="false"
							   tabindex="-1"
							   @click.stop.prevent="emitEvent('cell-action', [row, column])"
							   @keydown.enter="emitEvent('cell-action', [row, column])">
								{{cellValue}}
							</a>
							<br />
							<span style="color: var(--q-theme-neutral); font-size: 8pt;" class="only-top-border">
								{{ row?.Fields["Entidade.ValSub_modelo_gestao"] }}
							</span>
						</template>
						<span v-else class="join-top-border"></span>
					</template>
					<template #column_ValOperacao_aa="{ column }">
						<span v-html="column.label"></span>
					</template>
					<template #ValOperacao_aa="{ row, column, cellValue, emitEvent }">
						<template v-if="row?.Fields['ValPop_aa'] > 0">
							{{cellValue}}
							<br />
							<span style="color: var(--q-theme-neutral); font-size: 8pt;">
								{{ row?.Fields["ValPop_aa"] }} ({{ obterPercentagem(row?.Fields["ValPop_aa"], row?.Fields["Entidade.Concelho.ValPop_residente"]) }})
							</span>
						</template>
					</template>
					<template #column_ValOperacao_ar="{ column }">
						<span v-html="column.label"></span>
					</template>
					<template #ValOperacao_ar="{ row, column, cellValue, emitEvent }">
						<template v-if="row?.Fields['ValPop_ar'] > 0">
							{{cellValue}}
							<br />
							<span style="color: var(--q-theme-neutral); font-size: 8pt;">
								{{ row?.Fields["ValPop_ar"] }} ({{ obterPercentagem(row?.Fields["ValPop_ar"], row?.Fields["Entidade.Concelho.ValPop_residente"]) }})
							</span>
						</template>
					</template>
					<template #column_ValOperacao_ru="{ column }">
						<span v-html="column.label"></span>
					</template>
					<template #ValOperacao_ru="{ row, column, cellValue, emitEvent }">
						<template v-if="row?.Fields['ValPop_ru'] > 0">
							{{cellValue}}
							<br />
							<span style="color: var(--q-theme-neutral); font-size: 8pt;">
								{{ row?.Fields["ValPop_ru"] }} ({{ obterPercentagem(row?.Fields["ValPop_ru"], row?.Fields["Entidade.Concelho.ValPop_residente"]) }})
							</span>
						</template>
					</template>
<!--END_MANUALCODE-->
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

	import MenuViewModel from './QMenuPTN_3N41ViewModel.js'

	const requiredTextResources = ['QMenuPTN_3N41', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PTN_MENU_3N41]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuPtn3n41',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuPTN_3N41', false),

				interfaceMetadata: {
					id: 'QMenuPTN_3N41', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '3N41',
					isMenuList: true,
					designation: computed(() => this.Resources.FASES_DO_PROCESSO_PR40429),
					acronym: 'PTN_3N41',
					name: 'OPERACOES',
					route: 'menu-PTN_3N41',
					order: '3N41',
					controller: 'OPERACOES',
					action: 'PTN_Menu_3N41',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'PTN_Menu_3N41',
						controller: 'OPERACOES',
						action: 'PTN_Menu_3N41',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Entidade.Concelho.ValNome',
								area: 'CONCELHO',
								field: 'NOME',
								label: computed(() => this.Resources.CONCELHO__BR___SMALL54684),
								dataLength: 100,
								scrollData: 30,
								supportForm: 'CONCELHO',
								supportFormIsPopup: false,
								params: {
									type: 'form',
									isRoute: true,
									formName: 'CONCELHO',
									mode: 'SHOW'
								},
								cellAction: true,
								searchable: false,
								pkColumn: 'ValCodconcelho',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 2,
								name: 'Entidade.Concelho.ValPop_residente',
								area: 'CONCELHO',
								field: 'POP_RESIDENTE',
								label: computed(() => this.Resources.POP_RESIDENTE46287),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
								isVisible: false,
								sortable: false,
								searchable: false,
								pkColumn: 'ValCodconcelho',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'Entidade.ValEntidade',
								area: 'ENTIDADE',
								field: 'ENTIDADE',
								label: computed(() => this.Resources.ENTIDADE__BR____SMAL46237),
								dataLength: 250,
								scrollData: 30,
								supportForm: 'ENTIDADE',
								supportFormIsPopup: false,
								params: {
									type: 'form',
									isRoute: true,
									formName: 'ENTIDADE',
									mode: 'SHOW'
								},
								cellAction: true,
								sortable: false,
								searchable: false,
								pkColumn: 'ValCodentidade',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'Entidade.ValSub_modelo_gestao',
								area: 'ENTIDADE',
								field: 'SUB_MODELO_GESTAO',
								label: computed(() => this.Resources.SUBMODELO_DE_GESTAO34607),
								dataLength: 100,
								scrollData: 30,
								isVisible: false,
								sortable: false,
								searchable: false,
								pkColumn: 'ValCodentidade',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValOperacao_aa',
								area: 'OPERACOES',
								field: 'OPERACAO_AA',
								label: computed(() => this.Resources.AA__BR____SMALL_OPER01734),
								dataLength: 50,
								scrollData: 30,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 6,
								name: 'ValPop_aa',
								area: 'OPERACOES',
								field: 'POP_AA',
								label: computed(() => this.Resources.POP_ABRANGIDA36477),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
								isVisible: false,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'ValOperacao_ar',
								area: 'OPERACOES',
								field: 'OPERACAO_AR',
								label: computed(() => this.Resources.AR__BR___SMALL_OPERA31274),
								dataLength: 50,
								scrollData: 30,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 8,
								name: 'ValPop_ar',
								area: 'OPERACOES',
								field: 'POP_AR',
								label: computed(() => this.Resources.POP_ABRANGIDA36477),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 9,
								name: 'ValOperacao_ru',
								area: 'OPERACOES',
								field: 'OPERACAO_RU',
								label: computed(() => this.Resources.RU__BR____SMALL_OPER49774),
								dataLength: 50,
								scrollData: 30,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 10,
								name: 'ValPop_ru',
								area: 'OPERACOES',
								field: 'POP_RU',
								label: computed(() => this.Resources.POP_ABRANGIDA36477),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
								isVisible: false,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 11,
								name: 'ValSobreposicao_aa',
								area: 'OPERACOES',
								field: 'SOBREPOSICAO_AA',
								label: computed(() => this.Resources.SOBREPOSICAO_AA55921),
								scrollData: 1,
								isVisible: false,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 12,
								name: 'ValSobreposicao_ar',
								area: 'OPERACOES',
								field: 'SOBREPOSICAO_AR',
								label: computed(() => this.Resources.SOBREPOSICAO_AR58360),
								scrollData: 1,
								isVisible: false,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 13,
								name: 'ValSobreposicao_ru',
								area: 'OPERACOES',
								field: 'SOBREPOSICAO_RU',
								label: computed(() => this.Resources.SOBREPOSICAO_RU06294),
								scrollData: 1,
								isVisible: false,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'PTN_Menu_3N41',
							serverMode: true,
							pkColumn: 'ValCodoperacoes',
							tableAlias: 'OPERACOES',
							tableNamePlural: computed(() => this.Resources.OPERACAO29482),
							viewManagement: 'N',
							tableTitle: computed(() => this.Resources.FASES_DO_PROCESSO_PR40429),
							perPage: 50,
							perPageOptions: [50, 100, 250, 500, 1000, 1500],
							showRecordCount: true,
							permissions: {
								canView: false,
								canEdit: false,
								canDuplicate: false,
								canDelete: false,
								canInsert: false
							},
							searchBarConfig: {
								visibility: true
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
							],
							rowClickAction: {
							},
							formsDefinition: {
								'CONCELHO': {
									fnKeySelector: (row) => row.Fields.ValCodoperacoes,
									isPopup: false
								},
								'ENTIDADE': {
									fnKeySelector: (row) => row.Fields.ValCodentidade,
									isPopup: false
								},
							},
							allowFileExport: true,
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'Entidade.Concelho.ValNome',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-OPERACOES', 'changed-ENTIDADE', 'changed-CONCELHO'],
						uuid: 'e905bd35-1b1e-40f5-b984-364bcfc2ee3f',
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
// USE /[MANUAL GQT FORM_CODEJS PTN_MENU_3N41]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT PTN_MENU_3N41]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
//Platform: VUE | Type: FUNCTIONS_JS | Module: GQT | Parameter: PTN_3N41 | File:  | Order: 0
//BEGIN_MANUALCODE_CODMANUA:0372b737-21b3-4fbf-a508-310188e2f5b9
			obterPercentagem(valor, total) {
				if (total === 0) return "0.00%";
				const percentagem = (valor / total) * 100;
				return percentagem.toFixed(2) + "%";
			},

			openFreguesias(row) {
				this.openMenuAction(this.controls.menu, {
					id: 'RCA_PTN_3N4111',
					name: 'menu-PTN_3N4111',
					isVisible: true,
					params: {
						isRoute: true,
						limits: [
							{
								identifier: 'concelho',
								fnValueSelector: (row) => row.Entidade.Concelho.ValCodconcelho
							},
						],
						action: this.openMenuAction, type: 'menu', menuName: 'PTN_3N4111'
					}
				}, row)
			},
//END_MANUALCODE
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS PTN_MENU_3N41]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
