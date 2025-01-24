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

	import MenuViewModel from './QMenuWMS_7111ViewModel.js'

	const requiredTextResources = ['QMenuWMS_7111', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS WMS_MENU_7111]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuWms7111',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuWMS_7111', false),

				interfaceMetadata: {
					id: 'QMenuWMS_7111', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '7111',
					isMenuList: true,
					designation: computed(() => this.Resources.DATA_TYPES15706),
					acronym: 'WMS_7111',
					name: 'DTTYP',
					route: 'menu-WMS_7111',
					order: '7111',
					controller: 'DTTYP',
					action: 'WMS_Menu_7111',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'WMS_Menu_7111',
						controller: 'DTTYP',
						action: 'WMS_Menu_7111',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValString',
								area: 'DTTYP',
								field: 'STRING',
								label: computed(() => this.Resources.STRING29433),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValUppercas',
								area: 'DTTYP',
								field: 'UPPERCAS',
								label: computed(() => this.Resources.UPPER_CASE31324),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValQrcode',
								area: 'DTTYP',
								field: 'QRCODE',
								label: computed(() => this.Resources.QR_CODE12259),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValMultilin',
								area: 'DTTYP',
								field: 'MULTILIN',
								label: computed(() => this.Resources.SIMPLE_MULTILINE_TEX04460),
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValMultili3',
								area: 'DTTYP',
								field: 'MULTILI3',
								label: computed(() => this.Resources.EDITOR_MULTILINE_TEX05556),
								scrollData: 30,
							}),
							new listColumnTypes.BooleanColumn({
								order: 6,
								name: 'ValBoolean',
								area: 'DTTYP',
								field: 'BOOLEAN',
								label: computed(() => this.Resources.BOOLEAN__TINYINT___S57956),
								scrollData: 1,
							}),
							new listColumnTypes.BooleanColumn({
								order: 7,
								name: 'ValBoolean2',
								area: 'DTTYP',
								field: 'BOOLEAN2',
								label: computed(() => this.Resources.CONDITIONAL__BOOLEAN08919),
								scrollData: 1,
								maxDigits: 1,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 8,
								name: 'ValSmallint',
								area: 'DTTYP',
								field: 'SMALLINT',
								label: computed(() => this.Resources.SMALL_INTEGER__STORA54196),
								scrollData: 4,
								maxDigits: 4,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 9,
								name: 'ValInteger',
								area: 'DTTYP',
								field: 'INTEGER',
								label: computed(() => this.Resources.INTEGER__STORAGE__4_49578),
								scrollData: 9,
								maxDigits: 9,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 10,
								name: 'ValBigint',
								area: 'DTTYP',
								field: 'BIGINT',
								label: computed(() => this.Resources.BIG_INTEGER__STORAGE28249),
								scrollData: 15,
								maxDigits: 15,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 11,
								name: 'ValReal',
								area: 'DTTYP',
								field: 'REAL',
								label: computed(() => this.Resources.REAL_FLOAT_24___PREC46659),
								scrollData: 8,
								maxDigits: 5,
								decimalPlaces: 2,
							}),
							new listColumnTypes.NumericColumn({
								order: 12,
								name: 'ValFloat',
								area: 'DTTYP',
								field: 'FLOAT',
								label: computed(() => this.Resources.DOUBLE___FLOAT_53___07951),
								scrollData: 15,
								maxDigits: 12,
								decimalPlaces: 2,
							}),
							new listColumnTypes.NumericColumn({
								order: 13,
								name: 'ValDecimal',
								area: 'DTTYP',
								field: 'DECIMAL',
								label: computed(() => this.Resources.DECIMAL__1_10___STOR26677),
								scrollData: 10,
								maxDigits: 5,
								decimalPlaces: 4,
							}),
							new listColumnTypes.NumericColumn({
								order: 14,
								name: 'ValDecimal9',
								area: 'DTTYP',
								field: 'DECIMAL9',
								label: computed(() => this.Resources.DECIMAL__11_15___STO49382),
								scrollData: 15,
								maxDigits: 10,
								decimalPlaces: 4,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 15,
								name: 'ValMoney',
								area: 'DTTYP',
								field: 'MONEY',
								label: computed(() => this.Resources.MONEY___DECIMAL__1_124403),
								scrollData: 10,
								maxDigits: 5,
								decimalPlaces: 2,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 16,
								name: 'ValMoney9',
								area: 'DTTYP',
								field: 'MONEY9',
								label: computed(() => this.Resources.MONEY___DECIMAL__11_02101),
								scrollData: 15,
								maxDigits: 10,
								decimalPlaces: 2,
							}),
							new listColumnTypes.DateColumn({
								order: 17,
								name: 'ValDate',
								area: 'DTTYP',
								field: 'DATE',
								label: computed(() => this.Resources.DATE02091),
								scrollData: 8,
								dateTimeType: 'date',
							}),
							new listColumnTypes.DateColumn({
								order: 18,
								name: 'ValDatetime',
								area: 'DTTYP',
								field: 'DATETIME',
								label: computed(() => this.Resources.DATETIME62630),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.DateColumn({
								order: 19,
								name: 'ValDtsesond',
								area: 'DTTYP',
								field: 'DTSESOND',
								label: computed(() => this.Resources.DATE_TIME_SECOND__IN55990),
								scrollData: 19,
								dateTimeType: 'dateTimeSeconds',
							}),
							new listColumnTypes.TextColumn({
								order: 20,
								name: 'ValTime',
								area: 'DTTYP',
								field: 'TIME',
								label: computed(() => this.Resources.TIME50904),
								dataLength: 5,
								scrollData: 5,
								dateTimeType: 'time',
							}),
							new listColumnTypes.TextColumn({
								order: 21,
								name: 'ValUuid',
								area: 'DTTYP',
								field: 'UUID',
								label: computed(() => this.Resources.UUID__AKA_GUID_13998),
								dataLength: 36,
								scrollData: 30,
							}),
							new listColumnTypes.ImageColumn({
								order: 22,
								name: 'ValImage',
								area: 'DTTYP',
								field: 'IMAGE',
								label: computed(() => this.Resources.IMAGE__BINARY_46903),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.IMAGE__BINARY_46903)),
								scrollData: 3,
								sortable: false,
								searchable: false,
							}),
							new listColumnTypes.DateColumn({
								order: 23,
								name: 'ValStart',
								area: 'DTTYP',
								field: 'START',
								label: computed(() => this.Resources.STARTING_TIME_WITH_I44217),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.DateColumn({
								order: 24,
								name: 'ValEnd',
								area: 'DTTYP',
								field: 'END',
								label: computed(() => this.Resources.END_TIME_WITH_INCLUS19241),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
						],
						config: {
							name: 'WMS_Menu_7111',
							serverMode: true,
							pkColumn: 'ValCoddttyp',
							tableAlias: 'DTTYP',
							tableNamePlural: computed(() => this.Resources.DATA_TYPES15706),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.DATA_TYPES15706),
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
										formName: 'DTTYP',
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
										formName: 'DTTYP',
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
										formName: 'DTTYP',
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
										formName: 'DTTYP',
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
										formName: 'DTTYP',
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
								id: 'RCA_WMS_71111',
								name: 'form-DTTYP',
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCoddttyp
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'EDIT', formName: 'DTTYP',
								}
							},
							formsDefinition: {
								'DTTYP': {
									fnKeySelector: (row) => row.Fields.ValCoddttyp,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValString',
							defaultSearchColumnNameOriginal: 'ValString',
							defaultColumnSorting: {
								columnName: 'ValString',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-DTTYP'],
						uuid: 'c2b15f2a-27e8-459e-91be-79fcbdf502e1',
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
// USE /[MANUAL GQT FORM_CODEJS WMS_MENU_7111]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS WMS_7111]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS WMS_MENU_7111]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
