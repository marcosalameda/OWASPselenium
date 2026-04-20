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
					<!-- USE /[MANUAL GQT CUSTOM_TABLE GQT_Menu_81]/ -->
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

	import MenuViewModel from './QMenuGQT_81ViewModel.js'

	const requiredTextResources = ['QMenuGQT_81', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS GQT_MENU_81]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuGqt81',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuGQT_81', false),

				interfaceMetadata: {
					id: 'QMenuGQT_81', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '81',
					isMenuList: true,
					designation: computed(() => this.Resources.NOTIFICATIONS08466),
					acronym: 'GQT_81',
					name: 'NOTIF',
					route: 'menu-GQT_81',
					order: '81',
					controller: 'NOTIF',
					action: 'GQT_Menu_81',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'GQT_Menu_81',
						controller: 'NOTIF',
						action: 'GQT_Menu_81',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.NumericColumn({
								order: 1,
								name: 'ValNrcomoda',
								area: 'NOTIF',
								field: 'NRCOMODA',
								label: computed(() => this.Resources.NO__OF_THE_DADATO35934),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 2,
								name: 'ValBegin',
								area: 'NOTIF',
								field: 'BEGIN',
								label: computed(() => this.Resources.BEGINNING18124),
								scrollData: 16,
								dateTimeType: 'dateTime',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 3,
								name: 'ValEnd',
								area: 'NOTIF',
								field: 'END',
								label: computed(() => this.Resources.END47577),
								scrollData: 16,
								dateTimeType: 'dateTime',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValEmail',
								area: 'NOTIF',
								field: 'EMAIL',
								label: computed(() => this.Resources.RECIPIENT_S_EMAIL43894),
								dataLength: 100,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValIdnotif',
								area: 'NOTIF',
								field: 'IDNOTIF',
								label: computed(() => this.Resources.NOTIFICATION_ID_THAT61751),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'ValIdmsg',
								area: 'NOTIF',
								field: 'IDMSG',
								label: computed(() => this.Resources.MESSAGE_ID37133),
								dataLength: 85,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'ValMessage',
								area: 'NOTIF',
								field: 'MESSAGE',
								label: computed(() => this.Resources.TEXT_OF_THE_SENT_MES52307),
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 8,
								name: 'ValMailerr',
								area: 'NOTIF',
								field: 'MAILERR',
								label: computed(() => this.Resources.ERROR_SENDING_EMAIL53846),
								dataLength: 300,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 9,
								name: 'ValDesignat',
								area: 'NOTIF',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.RECIPIENT65165),
								dataLength: 85,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 10,
								name: 'ValCreatdat',
								area: 'NOTIF',
								field: 'CREATDAT',
								label: computed(() => this.Resources.CREATION__DATE13180),
								scrollData: 8,
								dateTimeType: 'date',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 11,
								name: 'ValCreatope',
								area: 'NOTIF',
								field: 'CREATOPE',
								label: computed(() => this.Resources.CREATION__OPERATOR50535),
								dataLength: 20,
								scrollData: 20,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 12,
								name: 'ValReturned',
								area: 'NOTIF',
								field: 'RETURNED',
								label: computed(() => this.Resources.RETURNED01606),
								scrollData: 1,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 13,
								name: 'ValDtdevolu',
								area: 'NOTIF',
								field: 'DTDEVOLU',
								label: computed(() => this.Resources.RETURN32222),
								scrollData: 8,
								dateTimeType: 'date',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 14,
								name: 'Pess2.ValName',
								area: 'PESS2',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 85,
								scrollData: 30,
								export: 1,
								pkColumn: 'ValCodpesso',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'GQT_Menu_81',
							serverMode: true,
							pkColumn: 'ValCodnotif',
							tableAlias: 'NOTIF',
							tableNamePlural: computed(() => this.Resources.NOTIFICATIONS08466),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.NOTIFICATIONS08466),
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
										formName: 'NOTIF',
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
										formName: 'NOTIF',
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
										formName: 'NOTIF',
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
										formName: 'NOTIF',
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
										formName: 'NOTIF',
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
								id: 'RCA_GQT_811',
								name: 'form-NOTIF',
								isVisible: true,
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodnotif
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'NOTIF'
								}
							},
							formsDefinition: {
								'NOTIF': {
									fnKeySelector: (row) => row.Fields.ValCodnotif,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValNrcomoda',
							defaultSearchColumnNameOriginal: 'ValNrcomoda',
							defaultColumnSorting: {
								columnName: 'ValBegin',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-NOTIF', 'changed-PESS2'],
						uuid: '8a24817a-f3db-4158-821e-86bf9df25ea0',
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
// USE /[MANUAL GQT FORM_CODEJS GQT_MENU_81]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT GQT_MENU_81]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS GQT_81]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS GQT_MENU_81]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
