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

	import MenuViewModel from './QMenuWMS_611ViewModel.js'

	const requiredTextResources = ['QMenuWMS_611', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS WMS_MENU_611]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuWms611',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuWMS_611', false),

				interfaceMetadata: {
					id: 'QMenuWMS_611', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '611',
					isMenuList: true,
					designation: computed(() => this.Resources.MESSAGES59316),
					acronym: 'WMS_611',
					name: 'MESSA',
					route: 'menu-WMS_611',
					order: '611',
					controller: 'MESSA',
					action: 'WMS_Menu_611',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'WMS_Menu_611',
						controller: 'MESSA',
						action: 'WMS_Menu_611',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValIdnotif',
								area: 'MESSA',
								field: 'IDNOTIF',
								label: computed(() => this.Resources.NOTIFICATION_ID25507),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValIdmsg',
								area: 'MESSA',
								field: 'IDMSG',
								label: computed(() => this.Resources.MESSAGE_ID37133),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValDesignat',
								area: 'MESSA',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.TO_WHOM_THE_MESSAGE_02337),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValEmail',
								area: 'MESSA',
								field: 'EMAIL',
								label: computed(() => this.Resources.E_MAIL_TO_WHOM_THE_M37668),
								dataLength: 254,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValMessage',
								area: 'MESSA',
								field: 'MESSAGE',
								label: computed(() => this.Resources.MESSAGE30602),
								scrollData: 30,
							}),
							new listColumnTypes.BooleanColumn({
								order: 6,
								name: 'ValMailsent',
								area: 'MESSA',
								field: 'MAILSENT',
								label: computed(() => this.Resources.E_MAIL_SENT_60490),
								scrollData: 1,
							}),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'ValMailerr',
								area: 'MESSA',
								field: 'MAILERR',
								label: computed(() => this.Resources.ERROR_SENDING_MAIL44674),
								dataLength: 300,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 8,
								name: 'ValCreatope',
								area: 'MESSA',
								field: 'CREATOPE',
								label: computed(() => this.Resources.CREATED_BY12292),
								dataLength: 128,
								scrollData: 30,
							}),
							new listColumnTypes.DateColumn({
								order: 9,
								name: 'ValCreatdat',
								area: 'MESSA',
								field: 'CREATDAT',
								label: computed(() => this.Resources.CREATED_ON00051),
								scrollData: 8,
								dateTimeType: 'date',
							}),
							new listColumnTypes.TextColumn({
								order: 10,
								name: 'Entit.ValName',
								area: 'ENTIT',
								field: 'NAME',
								label: computed(() => this.Resources.LEGAL_NAME42902),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodentit',
							}),
							new listColumnTypes.TextColumn({
								order: 11,
								name: 'Perso.ValName',
								area: 'PERSO',
								field: 'NAME',
								label: computed(() => this.Resources.PERSON_NAME40980),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodperso',
							}),
							new listColumnTypes.NumericColumn({
								order: 12,
								name: 'ValDocum_nr',
								area: 'MESSA',
								field: 'DOCUM_NR',
								label: computed(() => this.Resources.DOCUMENT_NUMBER28451),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
						],
						config: {
							name: 'WMS_Menu_611',
							serverMode: true,
							pkColumn: 'ValCodmessa',
							tableAlias: 'MESSA',
							tableNamePlural: computed(() => this.Resources.MESSAGES59316),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.MESSAGES59316),
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
										formName: 'MESSA',
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
										formName: 'MESSA',
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
										formName: 'MESSA',
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
										formName: 'MESSA',
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
										formName: 'MESSA',
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
								id: 'RCA_WMS_6111',
								name: 'form-MESSA',
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodmessa
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'MESSA',
								}
							},
							formsDefinition: {
								'MESSA': {
									fnKeySelector: (row) => row.Fields.ValCodmessa,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValIdnotif',
							defaultSearchColumnNameOriginal: 'ValIdnotif',
							defaultColumnSorting: {
								columnName: 'ValIdnotif',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-ENTIT', 'changed-MESSA', 'changed-PERSO'],
						uuid: 'c907abb5-c7f3-4623-8cf5-4701f233e6cb',
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
// USE /[MANUAL GQT FORM_CODEJS WMS_MENU_611]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS WMS_611]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS WMS_MENU_611]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
