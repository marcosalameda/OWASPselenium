<template>
	<!-- BEGIN: Config Popup -->
	<teleport
		v-if="showPopup"
		:to="`#q-modal-${modalId}-body`"
		:key="domKey">
		<q-tab-container
			v-bind="tabGroup"
			@mounted="setAllTabsShowContent('tabGroup', true, true)"
			@before-unmount="setAllTabsShowContent('tabGroup', false, true)"
			@tab-changed="changeTab('tabGroup', 'selectedTab', $event)">
			<template #tab-panel>
				<template
					v-for="tab in tabGroup.tabsList"
					:key="tab.id">
					<section v-show="tabGroup.selectedTab === tab.id">
						<div :id="`q-modal-${tab.id}-header`"></div>
						<div :id="`q-modal-${tab.id}-body`"></div>
					</section>
				</template>
			</template>
		</q-tab-container>
	</teleport>

	<teleport
		v-if="showPopup"
		:to="`#q-modal-${modalId}-footer`"
		:key="domKey">
		<template
			v-for="tab in tabGroup.tabsList"
			:key="tab.id">
			<div
				v-show="tabGroup.selectedTab === tab.id"
				:id="`q-modal-${tab.id}-footer`" />
		</template>
	</teleport>
	<!-- END: Config Popup -->
</template>

<script>
	import { computed } from 'vue'
	import _find from 'lodash-es/find'

	import QTabContainer from '@/components/containers/TabContainer.vue'

	export default {
		name: 'QTableConfig',

		emits: [
			'apply-config',
			'hide-popup',
			'reset-config',
			'show-popup',
			'signal-component'
		],

		components: {
			QTabContainer
		},

		inheritAttrs: false,

		props: {
			/**
			 * The control object containing configuration details and state for the table.
			 * Used for managing properties such as column configuration and filters.
			 */
			tableCtrl: {
				type: Object,
				required: true
			},

			/**
			 * An object containing signals that can trigger different actions within the configuration modal.
			 * These could include showing or hiding the modal, or navigating between different sections of the configuration.
			 */
			signal: {
				type: Object,
				default: () => ({})
			},

			/**
			 * The identifier for the modal container where the configuration component is rendered.
			 */
			modalId: {
				type: String,
				required: true
			},

			/**
			 * Object containing localized strings for various UI components and labels within the configuration modal.
			 */
			texts: {
				type: Object,
				required: true
			}
		},

		expose: [],

		data() {
			return {
				showPopup: false,
				domKey: 0,

				tabGroup: {
					selectedTab: 'column-config',
					alignTabs: 'left',
					iconAlignment: 'left',
					isVisible: true,
					tabsList: [
						{
							id: 'column-config',
							componentId: 'columnConfig',
							name: 'columns',
							label: computed(() => this.texts.columns),
							isBlocked: computed(() => _find(this.tableCtrl.config.configOptionsUse, ['id', 'columnConfig'])?.active === false),
							isVisible: computed(() => {
								return (
									this.tableCtrl.config.allowColumnConfiguration &&
									_find(this.tableCtrl.config.configOptionsUse, ['id', 'columnConfig'])?.visible
								)
							})
						},
						{
							id: 'advanced-filters',
							componentId: 'advancedFilters',
							name: 'filters',
							label: computed(() => this.texts.filtersText),
							isBlocked: computed(() => _find(this.tableCtrl.config.configOptionsUse, ['id', 'advancedFilters'])?.active === false),
							isVisible: computed(() => {
								return (
									this.tableCtrl.config.allowColumnFilters &&
									_find(this.tableCtrl.config.configOptionsUse, ['id', 'advancedFilters'])?.visible
								)
							})
						},
						{
							id: 'view-save',
							componentId: 'viewSave',
							name: 'newView',
							label: computed(() => this.texts.saveViewText),
							isBlocked: computed(() => _find(this.tableCtrl.config.configOptionsUse, ['id', 'viewSave'])?.active === false),
							isVisible: computed(() => {
								return (
									this.tableCtrl.config.allowManageViews && _find(this.tableCtrl.config.configOptionsUse, ['id', 'viewSave'])?.visible
								)
							})
						},
						{
							id: 'views',
							componentId: 'views',
							name: 'views',
							label: computed(() => this.texts.viewManagerText),
							isBlocked: computed(() => _find(this.tableCtrl.config.configOptionsUse, ['id', 'views'])?.active === false),
							isVisible: computed(() => {
								return this.tableCtrl.config.allowManageViews && _find(this.tableCtrl.config.configOptionsUse, ['id', 'views'])?.visible
							})
						}
					]
				}
			}
		},

		methods: {
			//Show popup
			fnShowPopup() {
				this.$emit('show-popup', {
					props: {
						title: this.texts.tableConfig
					},
					modalProps: {
						id: this.modalId,
						returnElement: this.signal.returnElement
					}
				})
				this.$nextTick().then(() => {
					this.showPopup = true
					this.domKey++
				})
			},

			//Hide popup
			fnHidePopup() {
				this.$emit('hide-popup', this.modalId)
			},

			setAllTabsShowContent(tabGroupId, show, mergeProps) {
				for (const tabId in this[tabGroupId]['tabsList']) {
					const tabObj = this[tabGroupId]['tabsList'][tabId]
					this.$emit('signal-component', tabObj.componentId, { showInline: show }, mergeProps)
				}
			},

			changeTab(tab, tabProp, selectedTab) {
				this[tab][tabProp] = selectedTab
			}
		},

		watch: {
			signal: {
				handler(newValue) {
					if (newValue.show) {
						this.fnShowPopup()
					} else if (newValue.show === false) {
						this.fnHidePopup()
					}
					if (newValue.selectedTab) {
						this.changeTab('tabGroup', 'selectedTab', newValue.selectedTab)
					}
				},
				deep: true
			}
		}
	}
</script>
