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

	const requiredTextResources = ['QMenuGQT_DEVOL', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS GQT_MENU_DEVOL]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuGqtDevol',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuGQT_DEVOL', false),

				interfaceMetadata: {
					id: 'QMenuGQT_DEVOL', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: 'DEVOL',
					isMenuList: true,
					acronym: 'GQT_DEVOL',
					name: 'LENDI',
					route: 'menu-GQT_DEVOL',
					order: '16111',
					controller: 'LENDI',
					action: 'GQT_Menu_DEVOL',
					isPopup: false
				},

				model: {
					menu: new controlClass.TableListControl({
						controller: 'LENDI',
						action: 'GQT_Menu_DEVOL',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Pess1.ValName',
								area: 'PESS1',
								field: 'NAME',
								label: computed(() => this.Resources.COMODANTE63029),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodpesso',
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'Equip.ValDesignat',
								area: 'EQUIP',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.EQUIPMENT03632),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodequip',
							}),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'Equip.ValRegistnr',
								area: 'EQUIP',
								field: 'REGISTNR',
								label: computed(() => this.Resources.NO__REGISTER04207),
								dataLength: 6,
								scrollData: 6,
								pkColumn: 'ValCodequip',
							}),
							new listColumnTypes.ArrayColumn({
								order: 4,
								name: 'Equip.ValFrequenc',
								area: 'EQUIP',
								field: 'FREQUENC',
								label: computed(() => this.Resources.LOAN_FREQUENCY00701),
								scrollData: 2,
								maxDigits: 1,
								decimalPlaces: 0,
								array: qProjArrays.QArrayFreqempr.setResources(vm.$getResource).elements,
								arrayType: qProjArrays.QArrayFreqempr.type,
								pkColumn: 'ValCodequip',
							}),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'Pess2.ValName',
								area: 'PESS2',
								field: 'NAME',
								label: computed(() => this.Resources.DADATARIAN04192),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodpesso',
							}),
							new listColumnTypes.NumericColumn({
								order: 6,
								name: 'ValLendinnr',
								area: 'LENDI',
								field: 'LENDINNR',
								label: computed(() => this.Resources.NO__OF_THE_DADATO35934),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}),
							new listColumnTypes.DateColumn({
								order: 7,
								name: 'ValStart',
								area: 'LENDI',
								field: 'START',
								label: computed(() => this.Resources.BEGINNING18124),
								scrollData: 16,
								dateTimeType: 'DateTime',
							}),
							new listColumnTypes.DateColumn({
								order: 8,
								name: 'ValWarndt',
								area: 'LENDI',
								field: 'WARNDT',
								label: computed(() => this.Resources.WARNING52043),
								scrollData: 16,
								dateTimeType: 'DateTime',
							}),
							new listColumnTypes.DateColumn({
								order: 9,
								name: 'ValEnd',
								area: 'LENDI',
								field: 'END',
								label: computed(() => this.Resources.END47577),
								scrollData: 16,
								dateTimeType: 'DateTime',
							}),
							new listColumnTypes.TextColumn({
								order: 10,
								name: 'ValObservat',
								area: 'LENDI',
								field: 'OBSERVAT',
								label: computed(() => this.Resources.OBSERVATIONS03729),
								scrollData: 30,
							}),
							new listColumnTypes.DateColumn({
								order: 11,
								name: 'ValReturndt',
								area: 'LENDI',
								field: 'RETURNDT',
								label: computed(() => this.Resources.RETURN32222),
								scrollData: 8,
								dateTimeType: 'Date',
							}),
							new listColumnTypes.NumericColumn({
								order: 12,
								name: 'ValDayslimi',
								area: 'LENDI',
								field: 'DAYSLIMI',
								label: computed(() => this.Resources.DAYS_FOR_RETURN14598),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
							new listColumnTypes.BooleanColumn({
								order: 13,
								name: 'ValReturned',
								area: 'LENDI',
								field: 'RETURNED',
								label: computed(() => this.Resources.RETURNED01606),
								scrollData: 1,
								visibility: false,
							}),
							new listColumnTypes.BooleanColumn({
								order: 14,
								name: 'ValIfoutdt',
								area: 'LENDI',
								field: 'IFOUTDT',
								label: computed(() => this.Resources.IF_OUT_OF_DATE49042),
								scrollData: 1,
								visibility: false,
							}),
						],
						config: {
							name: 'GQT_Menu_DEVOL',
							serverMode: true,
							pkColumn: 'ValCodlendi',
							tableAlias: 'LENDI',
							tableNamePlural: computed(() => this.Resources.LENDING18782),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.OUT_OF_DATE_LENDINGS05506),
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
										formName: 'COMOD',
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
										formName: 'COMOD',
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
										formName: 'COMOD',
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
										formName: 'COMOD',
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
										formName: 'COMOD',
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
								id: 'RCA_GQT_161111',
								name: 'form-COMOD',
								params: {
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodlendi
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'EDIT', formName: 'COMOD',
								}
							},
							formsDefinition: {
								'COMOD': {
									fnKeySelector: (row) => row.Fields.ValCodlendi,
									isPopup: false
								},
							},
							rowValidation: {
								fnValidate: (row) => row.Fields.ValZzstate === 0,
								message: computed(() => this.Resources.ATENCAO__ESTA_FICHA_24725),
								class: 'c-table__row--pending'
							},
							allowFileExport: true,
							// The list support form: COMOD
							crudConditions: {
							},
							defaultSearchColumnName: 'ValLendinnr',
							defaultSearchColumnNameOriginal: 'ValLendinnr',
							initialSortColumnName: '',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-LENDI', 'changed-EQUIP', 'changed-PESS2', 'changed-PESS1'],
						uuid: '6bdff51f-3728-4138-843b-5ddca0da1346',
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
// USE /[MANUAL GQT FORM_CODEJS GQT_MENU_DEVOL]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS GQT_MENU_DEVOL]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
