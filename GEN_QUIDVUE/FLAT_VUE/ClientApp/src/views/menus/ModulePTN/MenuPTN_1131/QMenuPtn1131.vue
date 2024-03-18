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

	const requiredTextResources = ['QMenuPTN_1131', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PTN_MENU_1131]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuPtn1131',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuPTN_1131', false),

				interfaceMetadata: {
					id: 'QMenuPTN_1131', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '1131',
					isMenuList: true,
					acronym: 'PTN_1131',
					name: 'TBLB',
					route: 'menu-PTN_1131',
					order: '1131',
					controller: 'TBLB',
					action: 'PTN_Menu_1131',
					isPopup: false
				},

				model: {
					menu: new controlClass.TableListControl({
						controller: 'TBLB',
						action: 'PTN_Menu_1131',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValText',
								area: 'TBLB',
								field: 'TEXT',
								label: computed(() => this.Resources.TEXT04938),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValTextml',
								area: 'TBLB',
								field: 'TEXTML',
								label: computed(() => this.Resources.MULTILINE_TEXT38013),
								scrollData: 30,
							}),
							new listColumnTypes.NumericColumn({
								order: 3,
								name: 'ValNumint',
								area: 'TBLB',
								field: 'NUMINT',
								label: computed(() => this.Resources.NUMERIC__INTEGER_50289),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 4,
								name: 'ValNumdec',
								area: 'TBLB',
								field: 'NUMDEC',
								label: computed(() => this.Resources.NUMERIC__DECIMAL_36157),
								scrollData: 10,
								maxDigits: 6,
								decimalPlaces: 3,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 5,
								name: 'ValCurint',
								area: 'TBLB',
								field: 'CURINT',
								label: computed(() => this.Resources.CURRENCY__INTERGER_21437),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 0,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 6,
								name: 'ValCurdec',
								area: 'TBLB',
								field: 'CURDEC',
								label: computed(() => this.Resources.CURRENCY__DECIMAL_11718),
								scrollData: 10,
								maxDigits: 5,
								decimalPlaces: 2,
							}),
							new listColumnTypes.BooleanColumn({
								order: 7,
								name: 'ValBool',
								area: 'TBLB',
								field: 'BOOL',
								label: computed(() => this.Resources.BOOLEAN45002),
								scrollData: 1,
							}),
							new listColumnTypes.DateColumn({
								order: 8,
								name: 'ValDate',
								area: 'TBLB',
								field: 'DATE',
								label: computed(() => this.Resources.DATE18475),
								scrollData: 8,
								dateTimeType: 'Date',
							}),
							new listColumnTypes.DateColumn({
								order: 9,
								name: 'ValDatetm',
								area: 'TBLB',
								field: 'DATETM',
								label: computed(() => this.Resources.DATETIME__MINUTES_59352),
								scrollData: 16,
								dateTimeType: 'DateTime',
							}),
							new listColumnTypes.DateColumn({
								order: 10,
								name: 'ValDatets',
								area: 'TBLB',
								field: 'DATETS',
								label: computed(() => this.Resources.DATETIME__SECONDS_49861),
								scrollData: 19,
								dateTimeType: 'DateTimeSeconds',
							}),
							new listColumnTypes.TextColumn({
								order: 11,
								name: 'ValTimehm',
								area: 'TBLB',
								field: 'TIMEHM',
								label: computed(() => this.Resources.TIME__HOURS_MINUTES_01660),
								dataLength: 5,
								scrollData: 5,
								dateTimeType: 'Time',
							}),
							new listColumnTypes.ArrayColumn({
								order: 12,
								name: 'ValEnumt',
								area: 'TBLB',
								field: 'ENUMT',
								label: computed(() => this.Resources.ENUMERATION__TEXT_15855),
								dataLength: 1,
								scrollData: 1,
								array: qProjArrays.QArrayTypet.setResources(vm.$getResource).elements,
								arrayType: qProjArrays.QArrayTypet.type,
							}),
							new listColumnTypes.ArrayColumn({
								order: 13,
								name: 'ValEnumn',
								area: 'TBLB',
								field: 'ENUMN',
								label: computed(() => this.Resources.ENUMERATION__NUMERIC44708),
								scrollData: 1,
								maxDigits: 1,
								decimalPlaces: 0,
								array: qProjArrays.QArrayTypen.setResources(vm.$getResource).elements,
								arrayType: qProjArrays.QArrayTypen.type,
							}),
						],
						config: {
							name: 'PTN_Menu_1131',
							serverMode: true,
							pkColumn: 'ValCodtblb',
							tableAlias: 'TBLB',
							tableNamePlural: computed(() => this.Resources.TABLES__BASIC_TYPES_29665),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.TABLES__BASIC_TYPES_29665),
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
										formName: 'TBLB',
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
										formName: 'TBLB',
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
										formName: 'TBLB',
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
										formName: 'TBLB',
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
										formName: 'TBLB',
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
								id: 'RCA_PTN_11311',
								name: 'form-TBLB',
								params: {
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodtblb
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'TBLB',
								}
							},
							formsDefinition: {
								'TBLB': {
									fnKeySelector: (row) => row.Fields.ValCodtblb,
									isPopup: false
								},
							},
							rowValidation: {
								fnValidate: (row) => row.Fields.ValZzstate === 0,
								message: computed(() => this.Resources.ATENCAO__ESTA_FICHA_24725),
								class: 'c-table__row--pending'
							},
							// The list support form: TBLB
							crudConditions: {
							},
							defaultSearchColumnName: 'ValText',
							defaultSearchColumnNameOriginal: 'ValText',
							initialSortColumnName: '',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-TBLB', 'changed-GRPB'],
						uuid: 'e8713245-4ac3-4289-8b05-d880d9155511',
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
// USE /[MANUAL GQT FORM_CODEJS PTN_MENU_1131]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS PTN_MENU_1131]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
