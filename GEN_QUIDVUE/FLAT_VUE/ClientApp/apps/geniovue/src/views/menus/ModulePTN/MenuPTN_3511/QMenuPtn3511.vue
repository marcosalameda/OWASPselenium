<template>
	<q-row-container
		v-if="componentOnLoadProc.loaded"
		is-large>
		<q-control-wrapper class="row-line-group">
			<q-tab-container
				id="tabs-QMenuPTN_3511"
				align-tabs="left"
				:tabs-list="controls.tabGroup.tabsList"
				:selected-tab="controls.tabGroup.selectedTab"
				:is-visible="controls.tabGroup.isVisible"
				@tab-changed="controls.tabGroup.selectTab($event)">
				<template #tab-panel>
					<section v-show="controls.tabGroup.selectedTab === 'firstTab'">
						<q-row-container is-large>
							<q-control-wrapper class="row-line-group">
								<q-table
									v-bind="controls.firstTable"
									v-on="controls.firstTable.handlers" />

								<q-table-extra-extension
									:list-ctrl="controls.firstTable"
									v-on="controls.firstTable.handlers" />
							</q-control-wrapper>
						</q-row-container>
					</section>

					<section v-show="controls.tabGroup.selectedTab === 'secondTab'">
						<q-row-container is-large>
							<q-control-wrapper class="row-line-group">
								<q-table
									v-bind="controls.secondTable"
									v-on="controls.secondTable.handlers" />

								<q-table-extra-extension
									:list-ctrl="controls.secondTable"
									v-on="controls.secondTable.handlers" />
							</q-control-wrapper>
						</q-row-container>

						<q-row-container is-large>
							<q-control-wrapper class="row-line-group">
								<q-button
									:label="Resources.APLICAR33981"
									:title="Resources.APLICAR33981"
									@click="applyChanges">
									<q-icon icon="bring-forward" />
								</q-button>
							</q-control-wrapper>
						</q-row-container>

						<q-row-container is-large>
							<q-control-wrapper class="row-line-group">
								<q-table
									:rows="selectedItems"
									:columns="mainTable.columns"
									:config="controls.thirdTable.config"
									:total-rows="controls.thirdTable.totalRows"
									:has-more-pages="controls.thirdTable.hasMorePages"
									readonly
									v-on="controls.thirdTable.handlers" />
							</q-control-wrapper>
						</q-row-container>
					</section>
				</template>
			</q-tab-container>
		</q-control-wrapper>
	</q-row-container>
</template>

<script>
	/* eslint-disable no-unused-vars */
	import { computed } from 'vue'

	import { loadResources } from '@/plugins/i18n.js'
	import { QEventEmitter } from '@quidgest/clientapp/plugins/eventBus'
	import asyncProcM from '@quidgest/clientapp/composables/async'

	import MarkItemsMenuHandlers from '@/mixins/markItemsMenuHandlers.js'
	import listFunctions from '@/mixins/listFunctions.js'
	import formFunctions from '@/mixins/formFunctions.js'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import controlClass from '@/mixins/fieldControl.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'

	import netAPI from '@quidgest/clientapp/network'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	import qEnums from '@quidgest/clientapp/constants/enums'
	/* eslint-enable no-unused-vars */

	import MenuViewModel from './QMenuPTN_3511ViewModel.js'

	const requiredTextResources = ['QMenuPTN_3511', 'hardcoded', 'messages']

	export default {
		name: 'QMenuPtn3511',

		mixins: [
			MarkItemsMenuHandlers
		],

		inheritAttrs: false,

		props: {
			/**
			 * Whether or not the form is used as a homepage.
			 */
			isHomePage: {
				type: Boolean,
				default: false
			}
		},

		expose: [
			'navigationId',
			'updateMenuNavigation'
		],

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('PTN_Menu_3511', false),

				interfaceMetadata: {
					id: 'QMenuPTN_3511', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					name: 'PTN_3511',
					area: 'EQUIP_${descendent.AreaBase}',
					route: 'menu-PTN_3511',
					order: '3511'
				},

				model: new MenuViewModel(this),

				controls: {
					firstTab: new controlClass.BaseControl({
						id: 'firstTab',
						name: 'firstTabForm',
						type: 'Tab',
						label: computed(() => this.Resources.EQUIPMENT03632),
						icon: {
							icon: 'remove-circle'
						}
					}, this),
					secondTab: new controlClass.BaseControl({
						id: 'secondTab',
						name: 'secondTabForm',
						type: 'Tab',
						label: '${descendent.Sistema.Modulo}_Menu_${descendent.MenuId}',
						icon: {
							icon: 'list'
						}
					}, this),
					tabGroup: new controlClass.TabsControl({
						tabControlsIds: ['firstTab', 'secondTab'],
						selectedTab: 'firstTab'
					}, this),
					firstTable: new controlClass.TableListControl({
						id: 'PTN_Menu_3511',
						controller: 'EQUIP',
						action: 'PTN_Menu_3511',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValDesignat',
								area: 'EQUIP',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.DESIGNATION35876),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'PTN_Menu_3511',
							serverMode: true,
							pkColumn: 'ValCodequip',
							tableAlias: 'EQUIP',
							tableNamePlural: computed(() => this.Resources.EQUIPMENT03632),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.EQUIPMENT03632),
							showAlternatePagination: true,
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
							},
							formsDefinition: {
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-TPEQU', 'changed-ROOM1', 'changed-DECOM', 'changed-PESS1', 'changed-EQUIP', 'changed-CMPNY', 'changed-WAREH', 'changed-ITEM'],
						uuid: '4a5e2c5a-b9ce-47ad-88fe-7f1fc6e0cd0f',
						allSelectedRows: 'false',
						headerLevel: 1,
						handlers: {
							selectRow: (eventData) => {
								this.onSelectRow(this.controls.firstTable, eventData)
								this.updateListData('equip')
							},
							unselectRow: (eventData) => {
								this.onUnselectRow(this.controls.firstTable, eventData)
								this.updateListData('equip')
							},
							unselectAllRows: () => {
								this.onUnselectAllRows(this.controls.firstTable)
							}
						}
					}, this),
					secondTable: new controlClass.TableListControl({
						id: 'PTN_Menu_3511',
						controller: 'EQUIP',
						action: 'PTN_Menu_3511',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValDesignat',
								area: 'EQUIP',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.DESIGNATION35876),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'PTN_Menu_3511',
							serverMode: true,
							pkColumn: 'ValCodequip',
							tableAlias: 'EQUIP',
							tableNamePlural: computed(() => this.Resources.EQUIPMENT03632),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.EQUIPMENT03632),
							showAlternatePagination: true,
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
							},
							formsDefinition: {
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-TPEQU', 'changed-ROOM1', 'changed-DECOM', 'changed-PESS1', 'changed-EQUIP', 'changed-CMPNY', 'changed-WAREH', 'changed-ITEM'],
						uuid: '4a5e2c5a-b9ce-47ad-88fe-7f1fc6e0cd0f',
						allSelectedRows: 'false',
						headerLevel: 1,
						handlers: {
							selectRow: (eventData) => {
								this.onSelectRow(this.controls.secondTable, eventData)
								this.selectRowData(eventData)
							},
							unselectRow: (eventData) => {
								this.onUnselectRow(this.controls.secondTable, eventData)
								this.unselectRowData(eventData)
							},
							// Handles the checkbox click.
							selectRows: (eventData) => {
								this.handleSelectedRows(this.controls.secondTable, eventData)
							},
							unselectAllRows: () => {
								this.handleUnselectAllRows(this.controls.secondTable)
							}
						}
					}, this),
					thirdTable: new controlClass.TableListControl({
						controller: '',
						action: '',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
						],
						config: {
							name: '',
							serverMode: false,
							viewManagement: 'N',
							tableTitle: computed(() => this.Resources.SELECIONADOS52011),
							showAlternatePagination: true,
							permissions: {
							},
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
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						uuid: '',
						allSelectedRows: 'false',
						headerLevel: 1,
						handlers: {
							removeRow: (eventData) => {
								this.onUnselectRow(this.mainTable, eventData)
								this.unselectRowData(eventData)
							},
							unselectAllRows: (eventData) => {
								this.onUnselectAllRows(this.mainTable, eventData)
								this.unselectAllRowsData()
							}
						}
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

		computed: {
			/**
			 * The main table.
			 */
			mainTable()
			{
				return this.controls.secondTable
			},

			/**
			 * The secondary table.
			 */
			secondaryTable()
			{
				return this.controls.firstTable
			}
		},

		methods: {
			/**
			 * Saves the changes.
			 */
			applyChanges()
			{
				const action = 'PTN_Menu_3511_Execute'
				const reloadTable = true
				const baseArea = 'equip'

				this.apply(action, reloadTable, baseArea)
			}
		}
	}
</script>
