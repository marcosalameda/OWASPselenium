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

	import MenuViewModel from './QMenuTRN_T16AGENTBYViewModel.js'

	const requiredTextResources = ['QMenuTRN_T16AGENTBY', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS TRN_MENU_T16AGENTBY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuTrnT16agentby',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuTRN_T16AGENTBY', false),

				interfaceMetadata: {
					id: 'QMenuTRN_T16AGENTBY', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: 'T16AGENTBY',
					isMenuList: true,
					designation: computed(() => this.Resources.AGENTS29376),
					acronym: 'TRN_T16AGENTBY',
					name: 'AGENT',
					route: 'menu-TRN_T16AGENTBY',
					order: '1G41',
					controller: 'AGENT',
					action: 'TRN_Menu_T16AGENTBY',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'TRN_Menu_T16AGENTBY',
						controller: 'AGENT',
						action: 'TRN_Menu_T16AGENTBY',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValName',
								area: 'AGENT',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 2,
								name: 'ValBirthdat',
								area: 'AGENT',
								field: 'BIRTHDAT',
								label: computed(() => this.Resources.BIRTHDATE22743),
								scrollData: 8,
								dateTimeType: 'date',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValEmail',
								area: 'AGENT',
								field: 'EMAIL',
								label: computed(() => this.Resources.EMAIL25170),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 4,
								name: 'ValPhoto',
								area: 'AGENT',
								field: 'PHOTO',
								label: computed(() => this.Resources.PHOTO51874),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.PHOTO51874)),
								scrollData: 3,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValTelephon',
								area: 'AGENT',
								field: 'TELEPHON',
								label: computed(() => this.Resources.TELEPHONE28697),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'TRN_Menu_T16AGENTBY',
							serverMode: true,
							pkColumn: 'ValCodagent',
							tableAlias: 'AGENT',
							tableNamePlural: computed(() => this.Resources.AGENTS29376),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.AGENTS29376),
							showRecordCount: true,
							permissions: {
								canView: false,
								canEdit: false,
								canDuplicate: false,
								canDelete: false,
								canInsert: false
							},
							searchBarConfig: {
								visibility: true,
								searchOnPressEnter: true
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
								id: 'RCA_TRN_T16PROPERTYBYAGENT',
								name: 'menu-TRN_T16PROPERTYBYAGENT',
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'agent',
											fnValueSelector: (row) => row.ValCodagent
										},
									],
									action: vm.openMenuAction, type: 'menu', menuName: 'TRN_T16PROPERTYBYAGENT',
								}
							},
							formsDefinition: {
							},
							defaultSearchColumnName: 'ValName',
							defaultSearchColumnNameOriginal: 'ValName',
							defaultColumnSorting: {
								columnName: 'ValName',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-AGENT'],
						uuid: '58e9b1d8-dd6b-4d74-8e18-1d2b6de442c5',
						allSelectedRows: 'false',
						headerLevel: 1,
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
// USE /[MANUAL GQT FORM_CODEJS TRN_MENU_T16AGENTBY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS TRN_T16AGENTBY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS TRN_MENU_T16AGENTBY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
