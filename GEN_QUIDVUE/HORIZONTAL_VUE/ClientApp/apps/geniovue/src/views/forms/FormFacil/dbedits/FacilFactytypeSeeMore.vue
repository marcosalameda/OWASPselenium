<template>
	<teleport
		v-if="isReady"
		to="#q-modal-see-more-facil-factytype-body">
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
	import _merge from 'lodash-es/merge'

	import { useGenericDataStore } from '@quidgest/clientapp/stores'
	import { useNavDataStore } from '@quidgest/clientapp/stores'
	import VueNavigation from '@/mixins/vueNavigation.js'
	import ListHandlers from '@/mixins/listHandlers.js'
	import { navigationProperties } from '@/mixins/navHandlers.js'
	import { TableListControl } from '@/mixins/fieldControl.js'
	import listFunctions from '@/mixins/listFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'

	import { loadResources } from '@/plugins/i18n.js'
	import asyncProcM from '@quidgest/clientapp/composables/async'

	import netAPI from '@quidgest/clientapp/network'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import qEnums from '@quidgest/clientapp/constants/enums'
	import { removeModal } from '@/utils/layout'
	/* eslint-enable no-unused-vars */

	import ViewModelBase from '@/mixins/viewModelBase.js'

	const requiredTextResources = ['FACIL___FACTYTYPE_____SeeMore', 'hardcoded', 'messages']

	export default {
		name: 'FacilFactytypeSeeMore',

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

				componentOnLoadProc: asyncProcM.getProcListMonitor('FACIL___FACTYTYPE_____SeeMore', false),

				interfaceMetadata: {
					id: 'FACIL___FACTYTYPE_____SeeMore', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					acronym: 'FACIL___FACTYTYPE_____SeeMore',
					name: 'FACIL___FACTYTYPE_____SeeMore',
					controller: 'FACIL',
					action: 'FACIL_FactyValType'
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
				id: 'see-more-facil-factytype',
				headerTitle: computed(() => this.Resources.FACILITY_TYPES57319),
				closeButtonEnable: true,
				hideFooter: true,
				dismissWithEsc: true,
				dismissAction: this.close,
				isActive: true,
				returnElement: 'FACIL___FACTYTYPE_____see-more_button'
			}
			this.setModal(modalProps)
		},

		beforeUnmount()
		{
			// Removes the listeners.
			this.$eventHub.offMany(this.listCtrl.globalEvents, this.onTableDBDataChanged)
			this.listCtrl.destroy()
			this.componentOnLoadProc.destroy()

			removeModal('see-more-facil-factytype')
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
					limits: this.limits,
					tableConfiguration: listFunctions.getTableConfiguration(this.listCtrl)
				}

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
					this.onTableListExecuteAction(this.listCtrl, eventData)
			},

			getListConfig()
			{
				const vm = this
				const listProps = {
					configuration: {
						controller: 'FACIL',
						action: 'Facil_FactyValType',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValType',
								area: 'FACTY',
								field: 'TYPE',
								label: computed(() => this.Resources.FACILITY_TYPE44577),
								dataLength: 25,
								scrollData: 25,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValLayrname',
								area: 'FACTY',
								field: 'LAYRNAME',
								label: computed(() => this.Resources.LAYER_NAME49545),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValIconurl',
								area: 'FACTY',
								field: 'ICONURL',
								label: computed(() => this.Resources.ICON41974),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValShadowur',
								area: 'FACTY',
								field: 'SHADOWUR',
								label: computed(() => this.Resources.SHADOW_URL57805),
								dataLength: 50,
								scrollData: 30,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 5,
								name: 'ValIconancx',
								area: 'FACTY',
								field: 'ICONANCX',
								label: computed(() => this.Resources.ICON_ANCHOR__X_AXIS_18664),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 6,
								name: 'ValIconancy',
								area: 'FACTY',
								field: 'ICONANCY',
								label: computed(() => this.Resources.ICON_ANCHOR__Y_AXIS_63725),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 7,
								name: 'ValIconheig',
								area: 'FACTY',
								field: 'ICONHEIG',
								label: computed(() => this.Resources.ICON_HEIGHT61896),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 8,
								name: 'ValIconwid',
								area: 'FACTY',
								field: 'ICONWID',
								label: computed(() => this.Resources.ICON_WIDTH02295),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 9,
								name: 'ValPopupanx',
								area: 'FACTY',
								field: 'POPUPANX',
								label: computed(() => this.Resources.POPUP_ANCHOR__X_AXIS15060),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 10,
								name: 'ValPopupany',
								area: 'FACTY',
								field: 'POPUPANY',
								label: computed(() => this.Resources.POPUP_ANCHOR__Y_AXIS64670),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 11,
								name: 'ValShadowax',
								area: 'FACTY',
								field: 'SHADOWAX',
								label: computed(() => this.Resources.SHADOW_ANCHOR__X_AXI31230),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 12,
								name: 'ValShadoway',
								area: 'FACTY',
								field: 'SHADOWAY',
								label: computed(() => this.Resources.SHADOW_ANCHOR__Y_AXI51495),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 13,
								name: 'ValShadowhe',
								area: 'FACTY',
								field: 'SHADOWHE',
								label: computed(() => this.Resources.SHADOW_HEIGHT64343),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 14,
								name: 'ValShadowwi',
								area: 'FACTY',
								field: 'SHADOWWI',
								label: computed(() => this.Resources.SHADOW_WIDTH01769),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
								isVisible: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'Facil_FactyValType',
							serverMode: true,
							pkColumn: 'ValCodfacty',
							tableAlias: 'FACTY',
							tableNamePlural: computed(() => this.Resources.FACILITY_TYPES57319),
							viewManagement: 'N',
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
								columnName: 'ValType',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-FACTY'],
						uuid: 'Facil_Facil_FactyValType',
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
