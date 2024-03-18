<template>
	<div
		:class="['layout-container', ...layoutClasses, ...customClasses]"
		:data-loading="loadingMenus">
		<slot name="layout-loading-effect"></slot>

		<div
			v-if="showContent"
			id="header-container">
<!-- eslint-disable indent, vue/html-indent, vue/script-indent -->
<!-- USE /[MANUAL GQT LAYOUT_HEADER]/ -->
<!-- eslint-disable-next-line -->
<!-- eslint-enable indent, vue/html-indent, vue/script-indent -->
			<navigational-bar :loading-menus="loadingMenus" />

			<slot name="layout-header"></slot>
		</div>

<!-- eslint-disable indent, vue/html-indent, vue/script-indent -->
<!-- USE /[MANUAL GQT LAYOUT_CONTENT]/ -->
<!-- eslint-disable-next-line -->
<!-- eslint-enable indent, vue/html-indent, vue/script-indent -->
		<slot name="layout-content"></slot>
	</div>
</template>

<script>
	import LayoutHandlers from '@/mixins/layoutHandlers.js'
	import NavigationalBar from './NavigationalBar.vue'

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LAYOUT_INCLUDEJS LAYOUT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QLayout',

		components: {
			NavigationalBar
		},

		mixins: [
			LayoutHandlers
		],

		inheritAttrs: false,

		props: {
			/**
			 * Custom classes to apply to the layout container.
			 */
			customClasses: {
				type: Array,
				default: () => []
			},

			/**
			 * Whether or not the menu structure is loading.
			 */
			loadingMenus: {
				type: Boolean,
				default: false
			}
		},

		expose: [],

		mounted()
		{
			if (this.hasMenus)
				this.expandSidebar()
			else
			{
				this.setSidebarVisibility(false)
				this.setSidebarCollapseState(true)
			}
		},

		computed: {
			/**
			 * List of classes to control the behavior of the sidebar.
			 */
			layoutClasses()
			{
				const classes = ['sidebar-mini', 'layout-fixed']

				if (!this.showContent)
					classes.push('login-page')

				if (!this.sidebarIsVisible ||
					this.isFullScreenPage ||
					!this.userIsLoggedIn && !this.isPublicRoute && this.layoutConfig.LoginStyle === 'single_page' ||
					Object.keys(this.system.availableModules).length === 0)
					classes.push('sidebar-closed')

				if (this.sidebarIsCollapsed)
					classes.push('sidebar-collapse')

				if (this.rightSidebarIsCollapsed)
					classes.push('right-sidebar-collapse')

				return classes
			},

			/**
			 * True if the layout content should be visible, false otherwise.
			 */
			showContent()
			{
				return this.userIsLoggedIn || !this.isFullScreenPage && (this.isPublicRoute || this.layoutConfig.LoginStyle !== 'single_page')
			}
		},

		watch: {
			hasMenus(val)
			{
				if (val)
					this.expandSidebar()
				else
				{
					this.setSidebarVisibility(false)
					this.setSidebarCollapseState(true)
				}
			}
		}
	}
</script>
