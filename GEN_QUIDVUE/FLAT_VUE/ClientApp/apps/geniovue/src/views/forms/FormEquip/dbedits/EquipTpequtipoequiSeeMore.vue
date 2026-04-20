<template>
	<teleport
		v-if="isReady"
		to="#q-modal-see-more-equip-tpequtipoequi-body">
		<q-row>
			<q-table
				v-if="!isTreeMode"
				v-bind="listCtrl"
				v-on="listCtrl.handlers">
				<template #title>
					<q-toggle-group
						v-model="currentMode"
						required
						borderless>
						<q-toggle-group-item value="to-normal-mode">
							<q-icon icon="list" />
						</q-toggle-group-item>
						<q-toggle-group-item value="to-tree-mode">
							<q-icon icon="view-options" />
						</q-toggle-group-item>
					</q-toggle-group>
				</template>
				<template #header>
					<q-table-config
						:table-ctrl="listCtrl"
						v-on="listCtrl.handlers" />
				</template>
			</q-table>
			<q-table
				v-else
				v-bind="treeListCtrl"
				v-on="treeListCtrl.handlers">
				<template #title>
					<q-toggle-group
						v-model="currentMode"
						required
						borderless>
						<q-toggle-group-item value="to-normal-mode">
							<q-icon icon="list" />
						</q-toggle-group-item>
						<q-toggle-group-item value="to-tree-mode">
							<q-icon icon="view-options" />
						</q-toggle-group-item>
					</q-toggle-group>
				</template>
				<template #header>
					<q-table-config
						:table-ctrl="treeListCtrl"
						v-on="treeListCtrl.handlers" />
				</template>
			</q-table>
		</q-row>
	</teleport>
</template>

<script>
	/* eslint-disable @typescript-eslint/no-unused-vars */
	import { computed } from 'vue'
	import { mapActions } from 'pinia'
	import _merge from 'lodash-es/merge'

	import { useGenericDataStore } from '@quidgest/clientapp/stores'
	import { useNavDataStore } from '@quidgest/clientapp/stores'
	import VueNavigation from '@/mixins/vueNavigation.js'
	import ListHandlers from '@/mixins/listHandlers.js'
	import { navigationProperties } from '@/mixins/navHandlers.js'
	import { TableListControl, TreeTableListControl } from '@/mixins/fieldControl.js'
	import listFunctions from '@/mixins/listFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'
	import hardcodedTexts from '@/hardcodedTexts.js'

	import { loadResources } from '@/plugins/i18n.js'
	import asyncProcM from '@quidgest/clientapp/composables/async'

	import netAPI from '@quidgest/clientapp/network'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import qEnums from '@quidgest/clientapp/constants/enums'
	import { removeModal } from '@/utils/layout'
	/* eslint-enable @typescript-eslint/no-unused-vars */

	import ViewModelBase from '@/mixins/viewModelBase.js'

	const requiredTextResources = ['EQUIP___TPEQUTIPOEQUI_SeeMore', 'hardcoded', 'messages']

	export default {
		name: 'EquipTpequtipoequiSeeMore',

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

				componentOnLoadProc: asyncProcM.getProcListMonitor('EQUIP___TPEQUTIPOEQUI_SeeMore', false),

				interfaceMetadata: {
					id: 'EQUIP___TPEQUTIPOEQUI_SeeMore', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					acronym: 'EQUIP___TPEQUTIPOEQUI_SeeMore',
					name: 'EQUIP___TPEQUTIPOEQUI_SeeMore',
					controller: 'EQUIP',
					action: 'EQUIP_TpequValTipoequi'
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
						showFooter: true,
						allowColumnSort: false,
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
				id: 'see-more-equip-tpequtipoequi',
				dismissAction: this.close,
				returnElement: 'EQUIP___TPEQUTIPOEQUI_see-more_button'
			}
			const props = {
				class: 'q-dialog-see-more',
				title: computed(() => this.Resources.TYPES_OF_EQUIPMENT61264),
				buttons: [
					{
						id: 'dialog-button-close',
						action: this.close,
						icon: { icon: 'cancel', type: 'svg' },
						props: {
							label: computed(() => this.Resources[hardcodedTexts.cancel]),
							variant: 'bold'
						}
					}
				]
			}
			this.setModal(props, modalProps)
		},

		beforeUnmount()
		{
			// Removes the listeners.
			this.$eventHub.offMany(this.listCtrl.globalEvents, this.onTableDBDataChanged)
			this.$eventHub.offMany(this.treeListCtrl.globalEvents, this.onTableDBDataChanged)
			this.treeListCtrl.destroy()
			this.listCtrl.destroy()
			this.componentOnLoadProc.destroy()

			removeModal('see-more-equip-tpequtipoequi')
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
				// Wait for the computed properties of columns to finish resolving (e.g. "isVisible").
				setTimeout(() => {
					const params = {
						id: this.id || null,
						identifier: 'EQUIP___TPEQUTIPOEQUI',
						limits: this.limits,
						tableConfiguration: listFunctions.getTableConfiguration(this.listCtrl)
					}

					if (this.isTreeMode)
					{
						this.treeListCtrl.init()
						this.componentOnLoadProc.addBusy(this.treeListCtrl.fetchListData(params))
						this.componentOnLoadProc.once(() => {
							if (!this.treeIsInitialized)
							{
								this.treeIsInitialized = true
								this.treeListCtrl.initData()
							}
						}, this)
					}
					else
						this.listCtrl.fetchListData(params)
				}, 0)
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
						action: 'Equip_TpequValTipoequi',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValTpequcod',
								area: 'TPEQU',
								field: 'TPEQUCOD',
								label: computed(() => this.Resources.CODE49225),
								dataLength: 20,
								scrollData: 20,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValTipoequi',
								area: 'TPEQU',
								field: 'TIPOEQUI',
								label: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
								dataLength: 50,
								scrollData: 50,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValTpequpai',
								area: 'TPEQU',
								field: 'TPEQUPAI',
								label: computed(() => this.Resources.DEPENDENT_ON28321),
								dataLength: 20,
								scrollData: 20,
								isVisible: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 4,
								name: 'ValNivel',
								area: 'TPEQU',
								field: 'NIVEL',
								label: computed(() => this.Resources.LEVEL06184),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
								isVisible: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValBackcolo',
								area: 'TPEQU',
								field: 'BACKCOLO',
								label: computed(() => this.Resources.BACKGROUND_COLOR47883),
								dataLength: 50,
								scrollData: 30,
								isVisible: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'ValCorletra',
								area: 'TPEQU',
								field: 'CORLETRA',
								label: computed(() => this.Resources.LETTER_COLOR15736),
								dataLength: 50,
								scrollData: 30,
								isVisible: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'Equip_TpequValTipoequi',
							serverMode: true,
							pkColumn: 'ValCodtpequ',
							tableAlias: 'TPEQU',
							tableNamePlural: computed(() => this.Resources.TYPES_OF_EQUIPMENT61264),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: '',
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
										formName: 'TPEQU',
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
										formName: 'TPEQU',
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
										formName: 'TPEQU',
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
										formName: 'TPEQU',
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
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'TPEQU',
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
								'TPEQU': {
									fnKeySelector: (row) => row.Fields.ValCodtpequ,
									isPopup: false
								},
							},
							treeListDefinitions: {
								branchAreas: {
									TPEQU: {
										tpequ: (row) => row.rowKey,
									},
								},
								rowModel: (row) => {
									return genericFunctions.getModelStructureObj(row, {
										'ValCodtpequ': (rowFields) => rowFields['tpequ.codtpequ'],
										'ValTpequcod': (rowFields) => rowFields['tpequ.tpequcod'],
										'ValTipoequi': (rowFields) => rowFields['tpequ.tipoequi'],
										'ValTpequpai': (rowFields) => rowFields['tpequ.tpequpai'],
										'ValNivel': (rowFields) => rowFields['tpequ.nivel'],
										'ValBackcolo': (rowFields) => rowFields['tpequ.backcolo'],
										'ValCorletra': (rowFields) => rowFields['tpequ.corletra'],
									})
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'ValTpequcod',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-FAMIL', 'changed-TPEQU'],
						uuid: 'Equip_Equip_TpequValTipoequi',
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
