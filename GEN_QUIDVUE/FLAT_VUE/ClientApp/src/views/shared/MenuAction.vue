<template>
	<a
		href="javascript:void(0)"
		@click.prevent="menuNavigation">
		<slot></slot>
	</a>
</template>

<script>
	import VueNavigation from '@/mixins/vueNavigation.js'
	import LayoutHandlers from '@/mixins/layoutHandlers.js'
	import menuAction from '@/mixins/menuAction.js'

	export default {
		name: 'QMenuAction',

		mixins: [
			VueNavigation,
			LayoutHandlers,
			menuAction
		],

		props: {
			/**
			 * Menu object containing action information and child menu items.
			 */
			menu: {
				type: Object,
				required: true
			},

			/**
			 * Description text for the menu action, to be used for accessibility or display purposes.
			 */
			description: {
				type: String,
				default: ''
			},

			/**
			 * Determines whether to check for the presence of child menu items before executing the action.
			 */
			checkChildren: {
				type: Boolean,
				default: false
			}
		},

		expose: [],

		methods: {
			/**
			 * Handles navigation when the menu item is clicked.
			 * Executes menu action only if there are no child menu items to display, or if the checkChildren flag is false.
			 */
			menuNavigation()
			{
				if (!this.checkChildren && this.menu.Children?.length > 0)
					return

				this.executeMenuAction(this.menu)
			}
		}
	}
</script>
