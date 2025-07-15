<template>
	<q-row-container
		v-if="componentOnLoadProc.loaded"
		is-large>
		<q-control-wrapper class="row-line-group">
			<q-tab-container
				id="tabs-QMenuGQT_241"
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

	import MenuViewModel from './QMenuGQT_241ViewModel.js'

	const requiredTextResources = ['QMenuGQT_241', 'hardcoded', 'messages']

	export default {
		name: 'QMenuGqt241',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('GQT_Menu_241', false),

				interfaceMetadata: {
					id: 'QMenuGQT_241', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					name: 'GQT_241',
					area: 'ROOMS_EQUIP',
					route: 'menu-GQT_241',
					order: '241'
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
						label: computed(() => this.Resources.EQUIPMENT03632),
						icon: {
							icon: 'list'
						}
					}, this),
					tabGroup: new controlClass.TabsControl({
						tabControlsIds: ['firstTab', 'secondTab'],
						selectedTab: 'firstTab'
					}, this),
					firstTable: new controlClass.TableListControl({
						id: 'GQT_Menu_241',
						controller: 'ROOMS',
						action: 'GQT_Menu_241',
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
							name: 'GQT_Menu_241',
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
						uuid: '167867cf-0d7a-48c7-9af3-f275027ceeed',
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
						id: 'GQT_Menu_2411',
						controller: 'EQUIP',
						action: 'GQT_Menu_2411',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValRegistnr',
								area: 'EQUIP',
								field: 'REGISTNR',
								label: computed(() => this.Resources.NO__REGISTER04207),
								dataLength: 6,
								scrollData: 6,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValDesignat',
								area: 'EQUIP',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.EQUIPMENT03632),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 3,
								name: 'ValPhotogra',
								area: 'EQUIP',
								field: 'PHOTOGRA',
								label: computed(() => this.Resources.PHOTO51874),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.PHOTO51874)),
								scrollData: 3,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'Room1.ValRoomnr',
								area: 'ROOM1',
								field: 'ROOMNR',
								label: computed(() => this.Resources.N_R__ROOM43805),
								dataLength: 10,
								scrollData: 10,
								pkColumn: 'ValCodrooms',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'Tpequ.ValTipoequi',
								area: 'TPEQU',
								field: 'TIPOEQUI',
								label: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
								dataLength: 50,
								scrollData: 30,
								isVisible: false,
								pkColumn: 'ValCodtpequ',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'Wareh.ValWarehdes',
								area: 'WAREH',
								field: 'WAREHDES',
								label: computed(() => this.Resources.WAREHOUSE51864),
								dataLength: 85,
								scrollData: 30,
								isVisible: false,
								pkColumn: 'ValCodwareh',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'Item.ValItemdes',
								area: 'ITEM',
								field: 'ITEMDES',
								label: computed(() => this.Resources.ARTICLE60065),
								dataLength: 85,
								scrollData: 30,
								isVisible: false,
								pkColumn: 'ValCoditem',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'GQT_Menu_2411',
							serverMode: true,
							pkColumn: 'ValCodequip',
							tableAlias: 'EQUIP',
							tableNamePlural: computed(() => this.Resources.EQUIPMENT03632),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.EQUIPMENT03632),
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
										formName: 'EQUIP',
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
										formName: 'EQUIP',
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
										formName: 'EQUIP',
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
										formName: 'EQUIP',
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
										formName: 'EQUIP',
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
								'EQUIP': {
									fnKeySelector: (row) => row.Fields.ValCodequip,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValRegistnr',
							defaultSearchColumnNameOriginal: 'ValRegistnr',
							defaultColumnSorting: {
								columnName: 'ValRegistnr',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-TPEQU', 'changed-ROOM1', 'changed-DECOM', 'changed-PESS1', 'changed-EQUIP', 'changed-CMPNY', 'changed-WAREH', 'changed-ITEM'],
						uuid: 'd8fdd263-473c-451a-be4b-bf79d74ec21f',
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
				const action = 'GQT_Menu_241_Execute'
				const reloadTable = true
				const baseArea = 'rooms'

				this.apply(action, reloadTable, baseArea)
			}
		}
	}
</script>
