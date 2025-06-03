<template>
	<teleport
		v-if="isReady"
		to="#q-modal-see-more-accordi-pess1name-body">
		<q-row-container>
			<q-table
				v-if="!isTreeMode"
				v-bind="listCtrl"
				v-on="listCtrl.handlers">
				<template #tableTitle>
					<q-toggle-group
						v-model="currentMode"
						borderless>
						<q-toggle-group-item value="to-normal-mode">
							<q-icon icon="list" />
						</q-toggle-group-item>
						<q-toggle-group-item value="to-tree-mode">
							<q-icon icon="view-options" />
						</q-toggle-group-item>
					</q-toggle-group>
				</template>
			</q-table>
			<q-table
				v-else
				v-bind="treeListCtrl"
				v-on="treeListCtrl.handlers">
				<template #tableTitle>
					<q-toggle-group
						v-model="currentMode"
						borderless>
						<q-toggle-group-item value="to-normal-mode">
							<q-icon icon="list" />
						</q-toggle-group-item>
						<q-toggle-group-item value="to-tree-mode">
							<q-icon icon="view-options" />
						</q-toggle-group-item>
					</q-toggle-group>
				</template>
			</q-table>
		</q-row-container>
	</teleport>
</template>

<script>
	/* eslint-disable no-unused-vars */
	import { computed } from 'vue'
	import { mapActions } from 'pinia'
	import _merge from 'lodash-es/merge'

	import { useGenericDataStore } from '@/stores/genericData.js'
	import { useNavDataStore } from '@/stores/navData.js'
	import VueNavigation from '@/mixins/vueNavigation.js'
	import ListHandlers from '@/mixins/listHandlers.js'
	import { navigationProperties } from '@/mixins/navHandlers.js'
	import { TableListControl, TreeTableListControl } from '@/mixins/fieldControl.js'
	import listFunctions from '@/mixins/listFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'

	import { loadResources } from '@/plugins/i18n.js'
	import asyncProcM from '@/api/global/asyncProcMonitoring.js'

	import netAPI from '@/api/network'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	import genericFunctions from '@/mixins/genericFunctions.js'
	import qEnums from '@/mixins/quidgest.mainEnums.js'
	/* eslint-enable no-unused-vars */

	import ViewModelBase from '@/mixins/viewModelBase.js'

	const requiredTextResources = ['ACCORDI_PESS1NAME_____SeeMore', 'hardcoded', 'messages']

	export default {
		name: 'AccordiPess1nameSeeMore',

		inheritAttrs: false,

		emits: [
			'close',
			'see-more-choice'
		],

		mixins: [
			navigationProperties,
			VueNavigation,
			ListHandlers
		],

		props: {
			/**
			 * Unique identifier for the control.
			 */
			id: String,

			/**
			 * The limits to which this "See more" control is subjected.
			 */
			limits: {
				type: Object,
				default: () => ({})
			},

			/**
			 * The id of the current navigation.
			 */
			navigationId: {
				type: String,
				default: ''
			}
		},

		expose: [],

		data()
		{
			return {
				isReady: false,

				componentOnLoadProc: asyncProcM.getProcListMonitor('ACCORDI_PESS1NAME_____SeeMore', false),

				interfaceMetadata: {
					id: 'ACCORDI_PESS1NAME_____SeeMore', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					acronym: 'ACCORDI_PESS1NAME_____SeeMore',
					name: 'ACCORDI_PESS1NAME_____SeeMore',
					controller: 'EQUIP',
					action: 'ACCORDI_Pess1ValName'
				},

				listCtrl: new TableListControl(this.getListConfig(), this),

				// Basic view model to handle access to GLOB, if necessary.
				model: new ViewModelBase(this),

				isTreeMode: false,

				treeIsInitialized: false,

				treeListCtrl: new TreeTableListControl(_merge(this.getListConfig(), {
					action: 'GetTreeSeeMore',
					config: {
						actionsPlacement: 'left',
						generalActionsPlacement: 'below',
						showFooter: true,
						filtersVisible: false,
						allowColumnFilters: false,
						allowColumnSort: false,
						globalSearch: {
							visibility: false
						},
						rowClickActionInternal: null
					}
				}), this)
			}
		},

		created()
		{
			this.componentOnLoadProc.addImmediateBusy(loadResources(this, requiredTextResources))

			this.listCtrl.init()
			this.onTableDBDataChanged()

			this.componentOnLoadProc.once(() => {
				this.isReady = true
				this.listCtrl.initData()
			}, this)
		},

		mounted()
		{
			// Listens for changes to the DB and updates the list accordingly.
			this.$eventHub.onMany(this.listCtrl.globalEvents, this.onTableDBDataChanged)
			this.$eventHub.onMany(this.treeListCtrl.globalEvents, this.onTableDBDataChanged)

			const modalProps = {
				id: 'see-more-accordi-pess1name',
				headerTitle: computed(() => this.Resources.COMFORTERS51045),
				closeButtonEnable: true,
				hideFooter: true,
				dismissWithEsc: true,
				dismissAction: this.close,
				isActive: true,
				returnElement: 'ACCORDI_PESS1NAME_____see-more_button'
			}
			this.setModal(modalProps)
		},

		beforeUnmount()
		{
			// Removes the listeners.
			this.$eventHub.offMany(this.listCtrl.globalEvents, this.onTableDBDataChanged)
			this.$eventHub.offMany(this.treeListCtrl.globalEvents, this.onTableDBDataChanged)
			this.treeListCtrl.destroy()
			this.listCtrl.destroy()
			this.componentOnLoadProc.destroy()

			genericFunctions.removeModal('see-more-accordi-pess1name')
		},

		computed: {
			currentMode: {
				get()
				{
					return this.isTreeMode ? 'to-tree-mode' : 'to-normal-mode'
				},

				set(newVal)
				{
					const prevMode = this.isTreeMode
					this.isTreeMode = newVal === 'to-tree-mode'

					if (prevMode !== this.isTreeMode)
						this.onTableDBDataChanged()
				}
			},

			activeList()
			{
				return this.isTreeMode ? this.treeListCtrl : this.listCtrl
			}
		},

		methods: {
			...mapActions(useGenericDataStore, [
				'setModal'
			]),

			...mapActions(useNavDataStore, [
				'setParamValue',
				'setEntryValue'
			]),

			close()
			{
				this.$emit('close')
			},

			onTableDBDataChanged()
			{
				const params = {
					id: this.id || null,
					identifier: 'ACCORDI_PESS1NAME____',
					limits: this.limits,
					tableConfiguration: listFunctions.getTableConfiguration(this.listCtrl)
				}

				if (this.isTreeMode)
				{
					this.treeListCtrl.init()
					this.componentOnLoadProc.addBusy(this.fetchListData(this.treeListCtrl, params))
					this.componentOnLoadProc.once(() => {
						if (!this.treeIsInitialized)
						{
							this.treeIsInitialized = true
							this.treeListCtrl.initData()
						}
					}, this)
				}
				else
					this.listCtrl.componentOnLoadProc.addWL(this.fetchListData(this.listCtrl, params))
			},

			handleRowAction(eventData)
			{
				if (eventData.id === 'see-more-choice')
				{
					let rowKey = eventData?.rowKeyPath
					if (Array.isArray(eventData?.rowKeyPath) && eventData?.rowKeyPath.length > 0)
						rowKey = eventData?.rowKeyPath[eventData?.rowKeyPath.length - 1]

					this.$emit('see-more-choice', rowKey)
				}
				else
					this.onTableListExecuteAction(this.activeList, eventData)
			},

			getListConfig()
			{
				const vm = this
				const listProps = {
					configuration: {
						controller: 'EQUIP',
						action: 'Accordi_Pess1ValName',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValName',
								area: 'PESS1',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 85,
								scrollData: 85,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'Accordi_Pess1ValName',
							serverMode: true,
							pkColumn: 'ValCodpesso',
							tableAlias: 'PESS1',
							tableNamePlural: computed(() => this.Resources.COMFORTERS51045),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: '',
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
										formName: 'PESS1',
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
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'PESS1',
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
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'PESS1',
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
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'PESS1',
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
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'PESS1',
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
								id: 'see-more-choice',
								name: 'see-more-choice',
							},
							formsDefinition: {
								'PESS1': {
									fnKeySelector: (row) => row.Fields.ValCodpesso,
									isPopup: false
								},
							},
							treeListDefinitions: {
								branchAreas: {
									PESS1: {
										pess1: (row) => row.rowKey,
									},
								},
								rowModel: (row) => {
									return genericFunctions.getModelStructureObj(row, {
										'ValCodpesso': (rowFields) => rowFields['pess1.codpesso'],
										'ValName': (rowFields) => rowFields['pess1.name'],
									})
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'ValName',
								sortOrder: 'asc'
							}
						},
						groupFilters: [
							{
								id: 'filter_Accordi_Pess1ValName_FILTER1',
								isMultiple: true,
								filters: [
									{
										id: 'filter_Accordi_Pess1ValName_FILTER1_1',
										key: '1',
										value: computed(() => this.Resources.FEMALE46107),
										selected: false
									},
								],
								value: '',
								defaultValue: ''
							},
							{
								id: 'filter_Accordi_Pess1ValName_FILTER2',
								isMultiple: true,
								filters: [
									{
										id: 'filter_Accordi_Pess1ValName_FILTER2_1',
										key: '1',
										value: computed(() => this.Resources.MALE32397),
										selected: false
									},
								],
								value: '',
								defaultValue: ''
							},
						],
						globalEvents: ['changed-PESS1', 'changed-CATE2', 'changed-STAKE', 'changed-CMPNY'],
						uuid: 'Accordi_Accordi_Pess1ValName',
						allSelectedRows: 'false',
						handlers: {
							rowAction: vm.handleRowAction
						},
						fixedControlLimits: vm.limits
					}
				}

				return listProps.configuration
			}
		}
	}
</script>
