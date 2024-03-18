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

	const requiredTextResources = ['QMenuPTN_211', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PTN_MENU_211]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuPtn211',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuPTN_211', false),

				interfaceMetadata: {
					id: 'QMenuPTN_211', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '211',
					isMenuList: true,
					acronym: 'PTN_211',
					name: 'ABATE',
					route: 'menu-PTN_211',
					order: '211',
					controller: 'DECOM',
					action: 'PTN_Menu_211',
					isPopup: false
				},

				model: {
					menu: new controlClass.TableListControl({
						controller: 'DECOM',
						action: 'PTN_Menu_211',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValDtdeco',
								area: 'DECOM',
								field: 'DTDECO',
								label: computed(() => this.Resources.DECOMISSION14486),
								scrollData: 16,
								dateTimeType: 'DateTime',
							}),
							new listColumnTypes.NumericColumn({
								order: 2,
								name: 'ValDecomnr',
								area: 'DECOM',
								field: 'DECOMNR',
								label: computed(() => this.Resources.NO_BATE21045),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValNote',
								area: 'DECOM',
								field: 'NOTE',
								label: computed(() => this.Resources.NOTES05274),
								scrollData: 30,
							}),
							new listColumnTypes.DateColumn({
								order: 4,
								name: 'ValCreatdat',
								area: 'DECOM',
								field: 'CREATDAT',
								label: computed(() => this.Resources.CRIADO_EM61283),
								scrollData: 8,
								dateTimeType: 'Date',
							}),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValCreatope',
								area: 'DECOM',
								field: 'CREATOPE',
								label: computed(() => this.Resources.CRIADO_POR17895),
								dataLength: 20,
								scrollData: 20,
							}),
							new listColumnTypes.DateColumn({
								order: 6,
								name: 'ValChngdate',
								area: 'DECOM',
								field: 'CHNGDATE',
								label: computed(() => this.Resources.ALTERADO_EM23573),
								scrollData: 8,
								dateTimeType: 'Date',
							}),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'ValOperchng',
								area: 'DECOM',
								field: 'OPERCHNG',
								label: computed(() => this.Resources.ALTERADO_POR39254),
								dataLength: 20,
								scrollData: 20,
							}),
						],
						config: {
							name: 'PTN_Menu_211',
							serverMode: true,
							pkColumn: 'ValCoddeco',
							tableAlias: 'DECOM',
							tableNamePlural: computed(() => this.Resources.EQUIPMENT_DECOMISSIO62648),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.EQUIPMENT_DECOMISSIO62648),
							showAlternatePagination: true,
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
										formName: 'ABATEREQ',
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
										formName: 'ABATEREQ',
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
										formName: 'ABATEREQ',
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
										formName: 'ABATEREQ',
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
										formName: 'ABATEREQ',
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
								id: 'RCA_PTN_2111',
								name: 'form-ABATEREQ',
								params: {
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCoddeco
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'EDIT', formName: 'ABATEREQ',
								}
							},
							formsDefinition: {
								'ABATEREQ': {
									fnKeySelector: (row) => row.Fields.ValCoddeco,
									isPopup: false
								},
							},
							rowValidation: {
								fnValidate: (row) => row.Fields.ValZzstate === 0,
								message: computed(() => this.Resources.ATENCAO__ESTA_FICHA_24725),
								class: 'c-table__row--pending'
							},
							// The list support form: ABATEREQ
							crudConditions: {
							},
							defaultSearchColumnName: 'ValDecomnr',
							defaultSearchColumnNameOriginal: 'ValDecomnr',
							initialSortColumnName: '',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-DECOM'],
						uuid: '08896786-8e39-461e-b166-e259f92211f7',
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
// USE /[MANUAL GQT FORM_CODEJS PTN_MENU_211]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS PTN_MENU_211]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
