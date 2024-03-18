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

	const requiredTextResources = ['QMenuSTY_LEAFTLETDRAW', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS STY_MENU_LEAFTLETDRAW]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuStyLeaftletdraw',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuSTY_LEAFTLETDRAW', false),

				interfaceMetadata: {
					id: 'QMenuSTY_LEAFTLETDRAW', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: 'LEAFTLETDRAW',
					isMenuList: true,
					acronym: 'STY_LEAFTLETDRAW',
					name: 'INSTA',
					route: 'menu-STY_LEAFTLETDRAW',
					order: '3551',
					controller: 'INSTA',
					action: 'STY_Menu_LEAFTLETDRAW',
					isPopup: false
				},

				model: {
					menu: new controlClass.TableListControl({
						controller: 'INSTA',
						action: 'STY_Menu_LEAFTLETDRAW',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Tpequ.ValTipoequi',
								area: 'TPEQU',
								field: 'TIPOEQUI',
								label: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodtpequ',
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'Equip.ValRegistnr',
								area: 'EQUIP',
								field: 'REGISTNR',
								label: computed(() => this.Resources.NO__REGISTER04207),
								dataLength: 6,
								scrollData: 6,
								pkColumn: 'ValCodequip',
							}),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValDesignat',
								area: 'INSTA',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.SCHEDULING24801),
								dataLength: 85,
								scrollData: 30,
							}),
							new listColumnTypes.DateColumn({
								order: 4,
								name: 'ValDtiniage',
								area: 'INSTA',
								field: 'DTINIAGE',
								label: computed(() => this.Resources.BEGINNING18124),
								scrollData: 16,
								dateTimeType: 'DateTime',
							}),
							new listColumnTypes.DateColumn({
								order: 5,
								name: 'ValDtfimage',
								area: 'INSTA',
								field: 'DTFIMAGE',
								label: computed(() => this.Resources.END47577),
								scrollData: 16,
								dateTimeType: 'DateTime',
							}),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'ValDescript',
								area: 'INSTA',
								field: 'DESCRIPT',
								label: computed(() => this.Resources.DESCRIPTION07383),
								scrollData: 30,
							}),
							new listColumnTypes.BooleanColumn({
								order: 7,
								name: 'ValAllday',
								area: 'INSTA',
								field: 'ALLDAY',
								label: computed(() => this.Resources.ALL_DAY18496),
								scrollData: 1,
							}),
							new listColumnTypes.DateColumn({
								order: 8,
								name: 'ValSince',
								area: 'INSTA',
								field: 'SINCE',
								label: computed(() => this.Resources.SINCE47259),
								scrollData: 16,
								dateTimeType: 'DateTime',
							}),
							new listColumnTypes.DateColumn({
								order: 9,
								name: 'ValUntil',
								area: 'INSTA',
								field: 'UNTIL',
								label: computed(() => this.Resources.UNTIL39173),
								scrollData: 16,
								dateTimeType: 'DateTime',
							}),
							new listColumnTypes.NumericColumn({
								order: 10,
								name: 'ValHours',
								area: 'INSTA',
								field: 'HOURS',
								label: computed(() => this.Resources.QTD_HOURS28684),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 2,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 11,
								name: 'ValPrecohor',
								area: 'INSTA',
								field: 'PRECOHOR',
								label: computed(() => this.Resources.HOURLY_PRICE48005),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 0,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 12,
								name: 'ValValue',
								area: 'INSTA',
								field: 'VALUE',
								label: computed(() => this.Resources.VALUE10285),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 0,
							}),
							new listColumnTypes.GeographicColumn({
								order: 13,
								name: 'ValCoordgeo',
								area: 'INSTA',
								field: 'COORDGEO',
								label: computed(() => this.Resources.GEOGRAPHIC_COORDINAT21394),
								dataLength: 50,
								scrollData: 30,
								sortable: false,
							}),
						],
						config: {
							name: 'STY_Menu_LEAFTLETDRAW',
							serverMode: true,
							pkColumn: 'ValCodinsta',
							tableAlias: 'INSTA',
							tableNamePlural: computed(() => this.Resources.FACILITIES08876),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.LEAFLETDRAW29465),
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
										formName: 'LEAFLETD',
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
										formName: 'LEAFLETD',
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
										formName: 'LEAFLETD',
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
										formName: 'LEAFLETD',
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
										formName: 'LEAFLETD',
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
								id: 'RCA_STY_35511',
								name: 'form-LEAFLETD',
								params: {
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodinsta
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'LEAFLETD',
								}
							},
							formsDefinition: {
								'LEAFLETD': {
									fnKeySelector: (row) => row.Fields.ValCodinsta,
									isPopup: false
								},
							},
							rowValidation: {
								fnValidate: (row) => row.Fields.ValZzstate === 0,
								message: computed(() => this.Resources.ATENCAO__ESTA_FICHA_24725),
								class: 'c-table__row--pending'
							},
							// The list support form: LEAFLETD
							crudConditions: {
							},
							defaultSearchColumnName: 'ValSince',
							defaultSearchColumnNameOriginal: 'ValSince',
							initialSortColumnName: '',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-INSTA', 'changed-EQUIP', 'changed-TPEQU'],
						uuid: '5b5648c2-338b-4f0a-8b4e-33bb84218448',
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
// USE /[MANUAL GQT FORM_CODEJS STY_MENU_LEAFTLETDRAW]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS STY_MENU_LEAFTLETDRAW]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
