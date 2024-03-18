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

	const requiredTextResources = ['QMenuPTN_451', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PTN_MENU_451]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuPtn451',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuPTN_451', false),

				interfaceMetadata: {
					id: 'QMenuPTN_451', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '451',
					isMenuList: true,
					acronym: 'PTN_451',
					name: 'EQUIP',
					route: 'menu-PTN_451',
					order: '451',
					controller: 'EQUIP',
					action: 'PTN_Menu_451',
					isPopup: false
				},

				model: {
					menu: new controlClass.TableListControl({
						controller: 'EQUIP',
						action: 'PTN_Menu_451',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Cmpny.ValDesignat',
								area: 'CMPNY',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.DESIGNATION35876),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodempre',
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'Pess1.ValName',
								area: 'PESS1',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodpesso',
							}),
							new listColumnTypes.NumericColumn({
								order: 3,
								name: 'ValSequennr',
								area: 'EQUIP',
								field: 'SEQUENNR',
								label: computed(() => this.Resources.SEQUENTIAL_NO_38590),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValRegistnr',
								area: 'EQUIP',
								field: 'REGISTNR',
								label: computed(() => this.Resources.NO__REGISTER04207),
								dataLength: 6,
								scrollData: 6,
							}),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'Tpequ.ValTipoequi',
								area: 'TPEQU',
								field: 'TIPOEQUI',
								label: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodtpequ',
							}),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'Wareh.ValWarehdes',
								area: 'WAREH',
								field: 'WAREHDES',
								label: computed(() => this.Resources.WAREHOUSE51864),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodwareh',
							}),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'Item.ValItemdes',
								area: 'ITEM',
								field: 'ITEMDES',
								label: computed(() => this.Resources.ARTICLE60065),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCoditem',
							}),
							new listColumnTypes.TextColumn({
								order: 8,
								name: 'ValDesignat',
								area: 'EQUIP',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.DESIGNATION35876),
								dataLength: 85,
								scrollData: 30,
							}),
							new listColumnTypes.DateColumn({
								order: 9,
								name: 'ValDtaquisi',
								area: 'EQUIP',
								field: 'DTAQUISI',
								label: computed(() => this.Resources.ACQUISITION44180),
								scrollData: 8,
								dateTimeType: 'Date',
							}),
							new listColumnTypes.NumericColumn({
								order: 10,
								name: 'Decom.ValDecomnr',
								area: 'DECOM',
								field: 'DECOMNR',
								label: computed(() => this.Resources.NO_BATE21045),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
								pkColumn: 'ValCoddeco',
							}),
							new listColumnTypes.DateColumn({
								order: 11,
								name: 'ValDtdeco',
								area: 'EQUIP',
								field: 'DTDECO',
								label: computed(() => this.Resources.DECOMISSION14486),
								scrollData: 8,
								dateTimeType: 'Date',
							}),
							new listColumnTypes.BooleanColumn({
								order: 12,
								name: 'ValIfabatif',
								area: 'EQUIP',
								field: 'IFABATIF',
								label: computed(() => this.Resources.DOWNED_EQUIPMENT43331),
								scrollData: 1,
							}),
							new listColumnTypes.ImageColumn({
								order: 13,
								name: 'ValPhotogra',
								area: 'EQUIP',
								field: 'PHOTOGRA',
								label: computed(() => this.Resources.PHOTO51874),
								scrollData: 3,
								sortable: false,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 14,
								name: 'ValValortot',
								area: 'EQUIP',
								field: 'VALORTOT',
								label: computed(() => this.Resources.TOTAL_VALUE30570),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 0,
							}),
							new listColumnTypes.ArrayColumn({
								order: 15,
								name: 'ValFrequenc',
								area: 'EQUIP',
								field: 'FREQUENC',
								label: computed(() => this.Resources.LOAN_FREQUENCY00701),
								scrollData: 1,
								maxDigits: 1,
								decimalPlaces: 0,
								array: qProjArrays.QArrayFreqempr.setResources(vm.$getResource).elements,
								arrayType: qProjArrays.QArrayFreqempr.type,
								arrayDisplayMode: 'D',
							}),
							new listColumnTypes.BooleanColumn({
								order: 16,
								name: 'ValBought',
								area: 'EQUIP',
								field: 'BOUGHT',
								label: computed(() => this.Resources.BOUGHT32044),
								scrollData: 1,
							}),
							new listColumnTypes.TextColumn({
								order: 17,
								name: 'Room1.ValRoomnr',
								area: 'ROOM1',
								field: 'ROOMNR',
								label: computed(() => this.Resources.N_R__ROOM43805),
								dataLength: 10,
								scrollData: 10,
								pkColumn: 'ValCodrooms',
							}),
							new listColumnTypes.DateColumn({
								order: 18,
								name: 'ValDtrefere',
								area: 'EQUIP',
								field: 'DTREFERE',
								label: computed(() => this.Resources.REFERENCE28402),
								scrollData: 16,
								dateTimeType: 'DateTime',
							}),
							new listColumnTypes.TextColumn({
								order: 19,
								name: 'ValFirst',
								area: 'EQUIP',
								field: 'FIRST',
								label: computed(() => this.Resources.FIRST42972),
								dataLength: 10,
								scrollData: 10,
							}),
							new listColumnTypes.TextColumn({
								order: 20,
								name: 'ValBefore',
								area: 'EQUIP',
								field: 'BEFORE',
								label: computed(() => this.Resources.BEFORE60156),
								dataLength: 10,
								scrollData: 10,
							}),
							new listColumnTypes.TextColumn({
								order: 21,
								name: 'ValFollowin',
								area: 'EQUIP',
								field: 'FOLLOWIN',
								label: computed(() => this.Resources.FOLLOWING22170),
								dataLength: 10,
								scrollData: 10,
							}),
							new listColumnTypes.TextColumn({
								order: 22,
								name: 'ValLast',
								area: 'EQUIP',
								field: 'LAST',
								label: computed(() => this.Resources.LAST49207),
								dataLength: 10,
								scrollData: 10,
							}),
							new listColumnTypes.HyperLinkColumn({
								order: 23,
								name: 'ValSitefabr',
								area: 'EQUIP',
								field: 'SITEFABR',
								label: computed(() => this.Resources.MANUFACTURER_S_WEBSI11084),
								dataLength: 256,
								scrollData: 30,
							}),
							new listColumnTypes.ImageColumn({
								order: 24,
								name: 'ValLastpho',
								area: 'EQUIP',
								field: 'LASTPHO',
								label: computed(() => this.Resources.LAST_PHOTO_ATTACHED43884),
								scrollData: 3,
								sortable: false,
							}),
							new listColumnTypes.TextColumn({
								order: 25,
								name: 'ValMoviment',
								area: 'EQUIP',
								field: 'MOVIMENT',
								label: computed(() => this.Resources.DRIVES34119),
								scrollData: 30,
							}),
							new listColumnTypes.NumericColumn({
								order: 26,
								name: 'ValQtdmovim',
								area: 'EQUIP',
								field: 'QTDMOVIM',
								label: computed(() => this.Resources.QTD__MOVIMENTACOES28400),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
							new listColumnTypes.BooleanColumn({
								order: 27,
								name: 'ValShowrc',
								area: 'EQUIP',
								field: 'SHOWRC',
								label: computed(() => this.Resources.SHOW_RECORD53851),
								scrollData: 1,
							}),
						],
						config: {
							name: 'PTN_Menu_451',
							serverMode: true,
							pkColumn: 'ValCodequip',
							tableAlias: 'EQUIP',
							tableNamePlural: computed(() => this.Resources.EQUIPMENT03632),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.EQUIPMENT03632),
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
										formName: 'TIMEQUIP',
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
										formName: 'TIMEQUIP',
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
										formName: 'TIMEQUIP',
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
										formName: 'TIMEQUIP',
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
										formName: 'TIMEQUIP',
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
								id: 'RCA_PTN_4511',
								name: 'form-TIMEQUIP',
								params: {
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodequip
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'TIMEQUIP',
								}
							},
							formsDefinition: {
								'TIMEQUIP': {
									fnKeySelector: (row) => row.Fields.ValCodequip,
									isPopup: false
								},
							},
							rowValidation: {
								fnValidate: (row) => row.Fields.ValZzstate === 0,
								message: computed(() => this.Resources.ATENCAO__ESTA_FICHA_24725),
								class: 'c-table__row--pending'
							},
							// The list support form: TIMEQUIP
							crudConditions: {
							},
							defaultSearchColumnName: 'ValRegistnr',
							defaultSearchColumnNameOriginal: 'ValRegistnr',
							initialSortColumnName: '',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-TPEQU', 'changed-ROOM1', 'changed-DECOM', 'changed-PESS1', 'changed-EQUIP', 'changed-CMPNY', 'changed-WAREH', 'changed-ITEM'],
						uuid: '78f755ff-cf65-4633-86d1-399c04d9bb97',
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
// USE /[MANUAL GQT FORM_CODEJS PTN_MENU_451]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS PTN_MENU_451]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
