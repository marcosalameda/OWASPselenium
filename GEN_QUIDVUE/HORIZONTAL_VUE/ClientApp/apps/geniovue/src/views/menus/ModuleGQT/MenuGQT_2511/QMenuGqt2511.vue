<template>
	<q-row-container
		v-if="componentOnLoadProc.loaded"
		is-large>
		<q-control-wrapper class="row-line-group">
			<q-tab-container
				id="tabs-QMenuGQT_2511"
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
	/* eslint-disable @typescript-eslint/no-unused-vars */
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
	/* eslint-enable @typescript-eslint/no-unused-vars */

	import MenuViewModel from './QMenuGQT_2511ViewModel.js'

	const requiredTextResources = ['QMenuGQT_2511', 'hardcoded', 'messages']

	export default {
		name: 'QMenuGqt2511',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('GQT_Menu_2511', false),

				interfaceMetadata: {
					id: 'QMenuGQT_2511', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					name: 'GQT_2511',
					area: 'ROOMS_${descendent.AreaBase}',
					route: 'menu-GQT_2511',
					order: '2511'
				},

				model: new MenuViewModel(this),

				controls: {
					firstTab: new controlClass.BaseControl({
						id: 'firstTab',
						name: 'firstTabForm',
						type: 'Tab',
						label: computed(() => this.Resources.ROOMS06809),
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
						id: 'GQT_Menu_2511',
						controller: 'ROOMS',
						action: 'GQT_Menu_2511',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValRoomnr',
								area: 'ROOMS',
								field: 'ROOMNR',
								label: computed(() => this.Resources.N_R__ROOM43805),
								dataLength: 10,
								scrollData: 10,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValDesignat',
								area: 'ROOMS',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.ROOM_DESIGNATION37895),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'GQT_Menu_2511',
							serverMode: true,
							pkColumn: 'ValCodrooms',
							tableAlias: 'ROOMS',
							tableNamePlural: computed(() => this.Resources.ROOMS06809),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.ROOMS06809),
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
										formName: 'SALAS',
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
										formName: 'SALAS',
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
										formName: 'SALAS',
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
										formName: 'SALAS',
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
										formName: 'SALAS',
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
							},
							formsDefinition: {
								'SALAS': {
									fnKeySelector: (row) => row.Fields.ValCodrooms,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValRoomnr',
							defaultSearchColumnNameOriginal: 'ValRoomnr',
							defaultColumnSorting: {
								columnName: 'ValRoomnr',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-ROOMS'],
						uuid: 'a8ab9db2-018e-4292-9747-eb8c7b11458e',
						allSelectedRows: 'false',
						headerLevel: 1,
						handlers: {
							selectRow: (eventData) => {
								this.controls.firstTable.onSelectRow(eventData)
								this.updateListData('rooms')
							},
							unselectRow: (eventData) => {
								this.controls.firstTable.onUnselectRow(eventData)
								this.updateListData('rooms')
							},
							unselectAllRows: () => {
								this.controls.firstTable.onUnselectAllRows()
							}
						}
					}, this),
					secondTable: new controlClass.TableListControl({
						id: 'GQT_Menu_2511',
						controller: 'ROOMS',
						action: 'GQT_Menu_2511',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValRoomnr',
								area: 'ROOMS',
								field: 'ROOMNR',
								label: computed(() => this.Resources.N_R__ROOM43805),
								dataLength: 10,
								scrollData: 10,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValDesignat',
								area: 'ROOMS',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.ROOM_DESIGNATION37895),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'GQT_Menu_2511',
							serverMode: true,
							pkColumn: 'ValCodrooms',
							tableAlias: 'ROOMS',
							tableNamePlural: computed(() => this.Resources.ROOMS06809),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.ROOMS06809),
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
										formName: 'SALAS',
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
										formName: 'SALAS',
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
										formName: 'SALAS',
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
										formName: 'SALAS',
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
										formName: 'SALAS',
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
							},
							formsDefinition: {
								'SALAS': {
									fnKeySelector: (row) => row.Fields.ValCodrooms,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValRoomnr',
							defaultSearchColumnNameOriginal: 'ValRoomnr',
							defaultColumnSorting: {
								columnName: 'ValRoomnr',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-ROOMS'],
						uuid: 'a8ab9db2-018e-4292-9747-eb8c7b11458e',
						allSelectedRows: 'false',
						headerLevel: 1,
						handlers: {
							selectRow: (eventData) => {
								this.controls.secondTable.onSelectRow(eventData)
								this.selectRowData(eventData)
							},
							unselectRow: (eventData) => {
								this.controls.secondTable.onUnselectRow(eventData)
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
								this.mainTable.onUnselectRow(eventData)
								this.unselectRowData(eventData)
							},
							unselectAllRows: () => {
								this.mainTable.onUnselectAllRows()
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
				const action = 'GQT_Menu_2511_Execute'
				const reloadTable = true
				const baseArea = 'rooms'

				this.apply(action, reloadTable, baseArea)
			}
		}
	}
</script>
