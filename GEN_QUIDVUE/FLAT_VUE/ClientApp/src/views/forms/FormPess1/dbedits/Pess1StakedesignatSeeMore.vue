<template>
	<teleport
		v-if="isReady"
		to="#q-modal-see-more-pess1-stakedesignat-body">
		<q-row-container>
			<q-table
				v-bind="listCtrl"
				v-on="listCtrl.handlers" />
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
	import { TableListControl } from '@/mixins/fieldControl.js'
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

	const requiredTextResources = ['PESS1___STAKEDESIGNAT_SeeMore', 'hardcoded', 'messages']

	export default {
		name: 'Pess1StakedesignatSeeMore',

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

				componentOnLoadProc: asyncProcM.getProcListMonitor('PESS1___STAKEDESIGNAT_SeeMore', false),

				interfaceMetadata: {
					id: 'PESS1___STAKEDESIGNAT_SeeMore', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					acronym: 'PESS1___STAKEDESIGNAT_SeeMore',
					name: 'PESS1___STAKEDESIGNAT_SeeMore',
					controller: 'PESS1',
					action: 'PESS1_StakeValDesignat'
				},

				listCtrl: new TableListControl(this.getListConfig(), this),
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

			const modalProps = {
				id: 'see-more-pess1-stakedesignat',
				headerTitle: computed(() => this.Resources.STAKEHOLDERS39854),
				closeButtonEnable: true,
				hideFooter: true,
				dismissWithEsc: true,
				dismissAction: this.close,
				isActive: true,
				returnElement: 'PESS1___STAKEDESIGNAT'
			}
			this.setModal(modalProps)
		},

		beforeUnmount()
		{
			// Removes the listeners.
			this.$eventHub.offMany(this.listCtrl.changeEvents, this.onTableDBDataChanged)
			this.listCtrl.destroy()
			this.componentOnLoadProc.destroy()

			genericFunctions.removeModal('see-more-pess1-stakedesignat')
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
					Limits: this.limits
				}

				_merge(params, this.limits)

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
						controller: 'PESS1',
						action: 'Pess1_StakeValDesignat',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValDesignat',
								area: 'STAKE',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.DESIGNATION35876),
								dataLength: 85,
								scrollData: 85,
							}),
						],
						config: {
							name: 'Pess1_StakeValDesignat',
							serverMode: true,
							pkColumn: 'ValCodparte',
							tableAlias: 'STAKE',
							tableNamePlural: computed(() => this.Resources.STAKEHOLDERS39854),
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
						changeEvents: ['changed-STAKE'],
						uuid: 'Pess1_Pess1_StakeValDesignat',
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
