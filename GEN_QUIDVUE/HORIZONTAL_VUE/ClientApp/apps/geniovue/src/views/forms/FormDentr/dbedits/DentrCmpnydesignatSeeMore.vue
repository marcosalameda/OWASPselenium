<template>
	<teleport
		v-if="isReady"
		to="#q-modal-see-more-dentr-cmpnydesignat-body">
		<q-row>
			<q-table
				v-bind="listCtrl"
				v-on="listCtrl.handlers" />
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
	import { TableListControl } from '@/mixins/fieldControl.js'
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

	const requiredTextResources = ['DENTR___CMPNYDESIGNAT_SeeMore', 'hardcoded', 'messages']

	export default {
		name: 'DentrCmpnydesignatSeeMore',

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

				componentOnLoadProc: asyncProcM.getProcListMonitor('DENTR___CMPNYDESIGNAT_SeeMore', false),

				interfaceMetadata: {
					id: 'DENTR___CMPNYDESIGNAT_SeeMore', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					acronym: 'DENTR___CMPNYDESIGNAT_SeeMore',
					name: 'DENTR___CMPNYDESIGNAT_SeeMore',
					controller: 'INDOC',
					action: 'DENTR_CmpnyValDesignat'
				},

				listCtrl: new TableListControl(this.getListConfig(), this),

				// Basic view model to handle access to GLOB, if necessary.
				model: new ViewModelBase(this),
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

			const modalProps = {
				id: 'see-more-dentr-cmpnydesignat',
				dismissAction: this.close,
				returnElement: 'DENTR___CMPNYDESIGNAT_see-more_button'
			}
			const props = {
				class: 'q-dialog-see-more',
				title: computed(() => this.Resources.COMPANIES04875),
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
			this.listCtrl.destroy()
			this.componentOnLoadProc.destroy()

			removeModal('see-more-dentr-cmpnydesignat')
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
						limits: this.limits,
						tableConfiguration: listFunctions.getTableConfiguration(this.listCtrl)
					}

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
					this.onTableListExecuteAction(this.listCtrl, eventData)
			},

			getListConfig()
			{
				const vm = this
				const listProps = {
					configuration: {
						controller: 'INDOC',
						action: 'Dentr_CmpnyValDesignat',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValDesignat',
								area: 'CMPNY',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.DESIGNATION35876),
								dataLength: 85,
								scrollData: 85,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'Dentr_CmpnyValDesignat',
							serverMode: true,
							pkColumn: 'ValCodempre',
							tableAlias: 'CMPNY',
							tableNamePlural: computed(() => this.Resources.COMPANIES04875),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: '',
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: true
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
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'ValDesignat',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-CMPNY', 'changed-CNTRY'],
						uuid: 'Dentr_Dentr_CmpnyValDesignat',
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
