<template>
	<div
		v-if="userIsLoggedIn"
		v-show="!isSidebarEmpty"
		class="wrapper">
		<div class="c-right-sidebar__control">
			<q-button
				v-if="rightSidebarIsCollapsed"
				id="open-sidebar-btn"
				b-style="secondary"
				class="right-sidebar-control"
				:title="texts.open"
				@click="openSidebar">
				<q-icon icon="step-back" />
			</q-button>
		</div>

		<div
			id="right-sidenav"
			class="c-right-sidebar"
			:style="{ top: `${visibleHeaderHeight}px` }">			
			<div class="c-right-sidebar__container">
				<nav class="c-right-sidebar__header">
					<div
						class="nav flex-column nav-pills"
						aria-orientation="vertical">
						<q-button
							id="close-sidebar-btn"
							:title="texts.close"
							:disabled="disableButtons"
							@click="closeSidebar">
							<q-icon icon="close" />
						</q-button>

						<q-button
							v-if="isCavAvailable && !suggestionModeOn"
							id="advanced-report-mode-toggle"
							:active="reportingModeCAV"
							:title="texts.enterInReport"
							:disabled="disableButtons"
							@click="toggleReportingMode">
							<q-icon icon="stats" />
						</q-button>

						<q-button
							v-if="showFormAnchors && !suggestionModeOn && layoutConfig.FormAnchorsPosition === 'sidebar'"
							id="form-tree-toggle"
							:active="isActive('form-anchors-tab')"
							:title="texts.formAreas"
							:disabled="disableButtons"
							@click="toggleSidebarTab('form-anchors-tab')">
							<q-icon icon="list-bordered" />
						</q-button>

						<q-button
							v-show="showFormActions && !suggestionModeOn"
							id="form-actions-toggle"
							:active="isActive('form-actions-tab')"
							:title="texts.formActions"
							:disabled="disableButtons"
							@click="toggleSidebarTab('form-actions-tab')">
							<q-icon icon="more-items" />
						</q-button>

						<q-button
							v-if="appAlerts.length > 0 && !suggestionModeOn"
							id="alerts-toggle"
							:active="isActive('alerts-tab')"
							:title="texts.alerts"
							:disabled="disableButtons"
							@click="toggleSidebarTab('alerts-tab')">
							<q-icon icon="notifications" />

							<span
								v-if="notifications.length > 0"
								class="e-badge e-badge--highlight">
								<span aria-hidden="true" />
							</span>
						</q-button>

						<q-button
							v-if="isSuggestionsAvailable"
							id="suggestion-mode-toggle"
							:active="suggestionModeOn"
							:title="suggestionModeOn ? texts.closeSuggestions : texts.enterInSuggestion"
							:disabled="disableButtons"
							@click="toggleSuggestionModeOn">
							<q-icon :icon="suggestionModeOn ? 'suggestion-mode-close' : 'suggestion-mode'" />
						</q-button>

						<q-button
							v-if="suggestionModeOn"
							id="suggestion-view"
							:title="texts.suggestions"
							:disabled="disableButtons"
							@click="openSuggestionList">
							<q-icon icon="suggestion-mode-view" />
						</q-button>

						<q-button
							v-if="suggestionModeOn"
							id="suggestion-open"
							:title="texts.suggest"
							:disabled="disableButtons"
							@click="openSuggestionMode">
							<q-icon icon="new-suggestion" />
						</q-button>

						<q-button
							v-if="isChatBotAvailable"
							id="chatbot-toggle"
							b-style="secondary"
							title="ChatBot"
							class="nav-link"
							:disabled="disableButtons"
							@click="toggleSidebarTab('chatbot-tab')">
							<q-icon-img :icon="`${system.resourcesPath}chatbot.png`" />
						</q-button>
					</div>
				</nav>

				<div class="c-right-sidebar__content">
					<div
						v-show="extendedTab === 'form-actions-tab' && showFormActions"
						id="form-actions-tab"
						class="c-tab__item--sidebar">
						<form-action-buttons :buttons-list="formModeData" />
					</div>

					<div
						v-if="appAlerts.length > 0"
						v-show="extendedTab === 'alerts-tab'"
						id="alerts-tab">
						<alerts
							:alerts="notifications"
							@fetch-alerts="fetchAlerts"
							@clear-alerts="clearNotifications"
							@dismiss-alert="removeNotification"
							@navigate-to="onAlertClick" />
					</div>

					<div
						v-show="extendedTab === 'form-anchors-tab' && showFormAnchors"
						id="form-anchors-tab">
						<q-anchor-container-vertical
							:title="texts.formAreas"
							:tree="formAnchorsTree"
							:header-height="visibleHeaderHeight"
							@focus-control="(...args) => $emit('focus-control', ...args)" />
					</div>

					<div
						v-if="isChatBotAvailable"
						v-show="extendedTab === 'chatbot-tab'"
						id="chatbot-tab">
						<q-chat-bot
							:application-name="applicationName"
							:resources-path="system.resourcesPath"
							:socket-server-endpoint="chatbotSocketUrl"
							:api-server-message-endpoint="chatbotApiUrl" />
					</div>

					<div v-show="extendedTab === 'widgets-panel'">
						<div id="widgets-panel"></div>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
	import { computed, defineAsyncComponent } from 'vue'
	import { mapState, mapActions } from 'pinia'

	import { useSystemDataStore } from '@/stores/systemData.js'
	import { useGenericDataStore } from '@/stores/genericData.js'
	import netAPI from '@/api/network'
	import hardcodedTexts from '@/hardcodedTexts.js'
	import LayoutHandlers from '@/mixins/layoutHandlers.js'
	import AlertHandlers from '@/mixins/alertHandlers.js'

	export default {
		name: 'QSidebar',

		emits: [
			'changed-sidebar-width',
			'focus-control'
		],

		components: {
			QAnchorContainerVertical: defineAsyncComponent(() => import('@/components/containers/QAnchorContainerVertical.vue')),
			FormActionButtons: defineAsyncComponent(() => import('./FormActionButtons.vue')),
			Alerts: defineAsyncComponent(() => import('./Alerts.vue')),
			QChatBot: defineAsyncComponent(() => import('./QChatBot.vue'))
		},

		mixins: [
			AlertHandlers,
			LayoutHandlers
		],

		expose: [],

		data()
		{
			return {
				formModeData: {},

				formAnchorsTree: [],

				extendedTab: '',

				texts: {
					open: computed(() => this.Resources[hardcodedTexts.open]),
					alerts: computed(() => this.Resources[hardcodedTexts.alerts]),
					close: computed(() => this.Resources[hardcodedTexts.close]),
					formActions: computed(() => this.Resources[hardcodedTexts.formActions]),
					enterInReport: computed(() => this.Resources[hardcodedTexts.enterInReport]),
					enterInSuggestion: computed(() => this.Resources[hardcodedTexts.enterInSuggestion]),
					suggest: computed(() => this.Resources[hardcodedTexts.suggest]),
					suggestions: computed(() => this.Resources[hardcodedTexts.suggestions]),
					closeSuggestions: computed(() => this.Resources[hardcodedTexts.closeSuggestions]),
					formAreas: computed(() => this.Resources[hardcodedTexts.formAreas])
				},

				chatbotApiUrl: '',

				chatbotSocketUrl: ''
			}
		},

		mounted()
		{
			if (this.options?.autoCollapseSize)
			{
				this.autoCloseSidebar(false)
				window.addEventListener('resize', this.autoCloseSidebar)
			}

			this.$eventHub.on('changed-form-buttons', (sections) => {
				this.formModeData = sections
			})

			this.$eventHub.on('changed-form-anchors', (tree) => {
				this.formAnchorsTree = tree
			})

			this.$eventHub.on('open-sidebar-on-tab', (tabId) => {
				this.openSidebar()
				this.toggleSidebarTab(tabId)
			})

			if (this.isChatBotAvailable)
			{
				netAPI.fetchData('Home', 'LoadChatbotEndpoints', {}, (data) => {
					this.chatbotApiUrl = data.apiUrl
					this.chatbotSocketUrl = data.socketUrl
				})
			}

			// Sets the default state for the sidebar (closed or opened).
			if (this.layoutConfig.DefaultSidebarState !== 'opened')
				this.closeSidebar()

			// Emits the initial width of the sidebar.
			this.onSidebarWidthChange()
		},

		beforeUnmount()
		{
			if (this.options?.autoCollapseSize)
				window.removeEventListener('resize', this.autoCloseSidebar)

			this.$eventHub.off('changed-form-buttons')
			this.$eventHub.off('changed-form-tree')

			this.onSidebarWidthChange()
		},

		computed: {
			...mapState(useSystemDataStore, [
				'isCavAvailable',
				'isSuggestionsAvailable',
				'isChatBotAvailable',
				'applicationName'
			]),

			...mapState(useGenericDataStore, [
				'reportingModeCAV',
				'suggestionModeOn',
				'notifications'
			]),

			/**
			 * True if the button to toggle the form actions should be visible, false otherwise.
			 */
			showFormActions()
			{
				return Object.keys(this.formModeData).length > 0
			},

			/**
			 * The width of the right sidebar (in rem).
			 */
			sidebarWidth()
			{
				let width = 0

				if (this.userIsLoggedIn && !this.rightSidebarIsCollapsed)
				{
					if (this.extendedTab)
					{
						if (this.extendedTab === 'chatbot-tab')
							width = 35
						else
							width = 18.75
					}
					else if (!this.isSidebarEmpty)
						width = 3.125
				}

				return width
			},

			/**
			 * True if the form anchors should be visible, false otherwise.
			 */
			showFormAnchors()
			{
				return Array.isArray(this.formAnchorsTree) && this.formAnchorsTree.length > 0
			},

			/**
			 * True if the buttons of the sidebar should be disabled, false otherwise.
			 */
			disableButtons()
			{
				return this.extendedTab === 'widgets-panel'
			},

			/**
			 * True if the alerts tab should be visible, false otherwise.
			 */
			showAlerts()
			{
				return this.appAlerts.length > 0 && this.extendedTab === 'alerts-tab'
			},

			/**
			 * True if the sidebar is empty, false otherwise.
			 */
			isSidebarEmpty()
			{
				return !this.showFormActions &&
					!this.isCavAvailable &&
					!this.isSuggestionsAvailable &&
					!this.isChatBotAvailable &&
					!this.showFormAnchors &&
					!this.disableButtons &&
					!this.showAlerts
			}
		},

		methods: {
			...mapActions(useGenericDataStore, [
				'setSuggestionMode',
				'toggleSuggestionMode',
				'clearNotifications',
				'removeNotification'
			]),

			onSidebarWidthChange()
			{
				if (this.userIsLoggedIn && !this.isSidebarEmpty)
					this.$emit('changed-sidebar-width', this.sidebarWidth)
				else
					this.$emit('changed-sidebar-width', 0)
			},

			openSidebar()
			{
				this.setRightSidebarCollapseState(false)
			},

			closeSidebar()
			{
				this.setRightSidebarCollapseState(true)
				this.extendedTab = ''
			},

			toggleSidebarTab(tabId)
			{
				if (this.extendedTab === tabId)
					this.extendedTab = ''
				else
					this.extendedTab = tabId
			},

			toggleReportingMode()
			{
				this.$eventHub.emit('toggle-reporting-mode')
			},

			toggleSuggestionModeOn()
			{
				this.toggleSuggestionMode()

				if (this.suggestionModeOn)
					this.extendedTab = ''
			},

			openSuggestionMode()
			{
				const params = {
					id: '',
					label: '',
					help: '',
					arrayName: '',
				}

				this.$eventHub.emit('show-suggestion-popup', 'SuggestionIndex', params)
			},

			openSuggestionList()
			{
				this.$eventHub.emit('show-suggestion-popup', 'SuggestionList', {})
			},

			/**
			 * Collapses the right sidebar when a certain screen size is reached.
			 * @param {boolean} resize Whether or not the window is being resized
			 */
			autoCloseSidebar(resize = true)
			{
				if (resize && !this.options?.autoCollapseSize || this.extendedTab === 'widgets-panel')
					return

				if (this.options?.autoCollapseSize && window.innerWidth <= this.options.autoCollapseSize)
					this.closeSidebar()
				else
					this.openSidebar()
			},

			isActive(buttonId)
			{
				return this.extendedTab === buttonId
			}
		},

		watch: {
			isSidebarEmpty()
			{
				this.onSidebarWidthChange()
			},

			sidebarWidth()
			{
				this.onSidebarWidthChange()
			},

			$route(to)
			{
				if (typeof to.name !== 'string' || !to.name.startsWith('form'))
				{
					this.formModeData = {}
					this.formAnchorsTree = []

					if (this.extendedTab === 'form-actions-tab' || this.extendedTab === 'form-anchors-tab')
						this.extendedTab = ''
				}
			}
		}
	}
</script>
