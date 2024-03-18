<template>
	<teleport
		v-if="isReady"
		to="#q-modal-see-more-lnhde-tpeq1tipoequi-body">
		<q-row-container>
			<q-table
				v-if="!isTreeMode"
				v-bind="listCtrl"
				v-on="listCtrl.handlers">
				<template #tableTitle>
					<q-button-toggle
						v-model="currentMode"
						borderless
						:options="[
							{ key: 'to-normal-mode' },
							{ key: 'to-tree-mode' }
						]">
						<template #to-normal-mode>
							<q-icon icon="list" />
						</template>
						<template #to-tree-mode>
							<q-icon icon="view-options" />
						</template>
					</q-button-toggle>
				</template>
			</q-table>
			<q-table
				v-else
				v-bind="treeListCtrl"
				v-on="treeListCtrl.handlers">
				<template #tableTitle>
					<q-button-toggle
						v-model="currentMode"
						borderless
						:options="[
							{ key: 'to-normal-mode' },
							{ key: 'to-tree-mode' }
						]">
						<template #to-normal-mode>
							<q-icon icon="list" />
						</template>
						<template #to-tree-mode>
							<q-icon icon="view-options" />
						</template>
					</q-button-toggle>
				</template>
			</q-table>
		</q-row-container>
	</teleport>
</template>

<script>
	/* eslint-disable no-unused-vars */
	import { computed } from 'vue'
	import { mapActions } from 'pinia'
	import _assignIn from 'lodash-es/assignIn'
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
	/* eslint-enable no-unused-vars */

	const requiredTextResources = ['LNHDE___TPEQ1TIPOEQUI_SeeMore', 'hardcoded', 'messages']

	export default {
		name: 'LnhdeTpeq1tipoequiSeeMore',

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

				componentOnLoadProc: asyncProcM.getProcListMonitor('LNHDE___TPEQ1TIPOEQUI_SeeMore', false),

				interfaceMetadata: {
					id: 'LNHDE___TPEQ1TIPOEQUI_SeeMore', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					acronym: 'LNHDE___TPEQ1TIPOEQUI_SeeMore',
					name: 'LNHDE___TPEQ1TIPOEQUI_SeeMore',
					controller: 'LNHDE',
					action: 'LNHDE_Tpeq1ValTipoequi'
				},

				listCtrl: new TableListControl(this.getListConfig(), this),

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
			let params = {
				id: this.id || null,
				Limits: this.limits || []
			}

			_merge(params, this.limits)

			this.componentOnLoadProc.AddImmediateBusy(loadResources(this, requiredTextResources))
			this.componentOnLoadProc.AddImmediateBusy(this.fetchListData(this.listCtrl, params))
			this.componentOnLoadProc.Once(() => {
				this.isReady = true
				this.listCtrl.Init()
			}, this)
		},

		mounted()
		{
			// Listens for changes to the DB and updates the list accordingly.
			this.$eventHub.onMany(this.listCtrl.changeEvents, this.onTableDBDataChanged)
			this.$eventHub.onMany(this.treeListCtrl.changeEvents, this.onTableDBDataChanged)

			const modalProps = {
				id: 'see-more-lnhde-tpeq1tipoequi',
				headerTitle: computed(() => this.Resources.TYPES_OF_EQUIPMENT61264),
				closeButtonEnable: true,
				hideFooter: true,
				dismissWithEsc: true,
				dismissAction: this.close,
				isActive: true,
				returnElement: 'LNHDE___TPEQ1TIPOEQUI'
			}
			this.setModal(modalProps)
		},

		beforeUnmount()
		{
			// Removes the listeners.
			this.$eventHub.offMany(this.listCtrl.changeEvents, this.onTableDBDataChanged)
			this.$eventHub.offMany(this.treeListCtrl.changeEvents, this.onTableDBDataChanged)
			this.treeListCtrl.destroy()
			this.listCtrl.destroy()
			this.componentOnLoadProc.destroy()

			genericFunctions.removeModal('see-more-lnhde-tpeq1tipoequi')
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
			}
		},

		methods: {
			...mapActions(useGenericDataStore, [
				'setModal',
				'setDropdown'
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
				let params = {
					id: this.id || null,
					Identifier: 'LNHDE___TPEQ1TIPOEQUI',
					Limits: this.limits
				}

				_merge(params, this.limits)

				if (this.isTreeMode)
				{
					this.componentOnLoadProc.AddBusy(this.fetchListData(this.treeListCtrl, params))
					this.componentOnLoadProc.Once(() => {
						if (!this.treeIsInitialized)
						{
							this.treeIsInitialized = true
							this.treeListCtrl.Init()
						}
					}, this)
				}
				else
					this.componentOnLoadProc.AddBusy(this.fetchListData(this.listCtrl, params))
			},

			handleRowAction(eventData)
			{
				if (eventData.id === 'see-more-choice')
				{
					let rowKey = eventData?.rowKeyPath
					if(Array.isArray(eventData?.rowKeyPath) && eventData?.rowKeyPath.length > 0)
						rowKey = eventData?.rowKeyPath[eventData?.rowKeyPath.length - 1]

					this.$emit('see-more-choice', rowKey)
				}
				else
					this.onTableListExecuteAction(this.listCtrl, eventData)
			},

			getListConfig()
			{
				const vm = this
				const listProps = {
					configuration: {
						controller: 'LNHDE',
						action: 'Lnhde_Tpeq1ValTipoequi',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValTpequcod',
								area: 'TPEQ1',
								field: 'TPEQUCOD',
								label: computed(() => this.Resources.CODE49225),
								dataLength: 20,
								scrollData: 20,
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValTipoequi',
								area: 'TPEQ1',
								field: 'TIPOEQUI',
								label: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
								dataLength: 50,
								scrollData: 50,
							}),
						],
						config: {
							name: 'Lnhde_Tpeq1ValTipoequi',
							serverMode: true,
							pkColumn: 'ValCodtpequ',
							tableAlias: 'TPEQ1',
							tableNamePlural: computed(() => this.Resources.TYPES_OF_EQUIPMENT61264),
							viewManagement: '',
							showLimitsInfo: true,
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
							},
							rowValidation: {
								fnValidate: (row) => row.Fields.ValZzstate === 0,
								message: computed(() => this.Resources.ATENCAO__ESTA_FICHA_24725),
								class: 'c-table__row--pending'
							},
							crudConditions: {
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							initialSortColumnName: '',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-TPEQ1', 'changed-FAMI1'],
						uuid: 'Lnhde_Lnhde_Tpeq1ValTipoequi',
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
