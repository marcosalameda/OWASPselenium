<template>
	<li
		v-if="menu.Separates"
		class="dropdown-divider" />

	<li
		:id="module + menu.Order"
		:class="menuClasses">
		<template v-if="!isEmpty(menu.Children)">
			<make-link
				:menu="menu"
				:first-level="level === 0"
				@click.stop.prevent="toggleDropdownMenu(menu)" />

			<transition name="sidebar-dropdown">
				<ul
					v-if="menuIsOpen(menu)"
					:class="['d-block', 'nav', 'nav-treeview', levelClass]">
					<template
						v-for="child in menu.Children"
						:key="child.Id">
						<menu-sub-items
							v-if="child.Type === 'ITEM'"
							:menu="child"
							:level="level + 1"
							:root="false"
							:module="module" />
						<li v-else-if="child.Type === 'REPORT'">
							<make-link :menu="child" />
						</li>
						<component
							v-else-if="child.Type === 'LIST'"
							:is="getMenuList(child.Id)"
							:menu="child" />
					</template>
				</ul>
			</transition>
		</template>
		<template v-else>
			<make-link
				:menu="menu"
				:first-level="level === 0" />
		</template>
	</li>
</template>

<script>
	import LayoutHandlers from '@/mixins/layoutHandlers.js'

	import MakeLink from './MakeLink.vue'

	export default {
		name: 'QMenuSubItems',

		components: {
			MakeLink
		},

		mixins: [
			LayoutHandlers
		],

		props: {
			/**
			* The menu object containing data for the individual menu item, its children, and other configuration details.
			*/
			menu: {
				type: Object,
				required: true
			},

			/**
			* The module name to be used for dynamic component resolution and part of the ID for the menu item.
			*/
			module: {
				type: String,
				required: true
			},

			/**
			* The nesting level of the menu item, determines styles and treeview behaviors.
			*/
			level: {
				type: Number,
				default: 0
			},

			/**
			* Flag to indicate if the menu item is at the root of the menu structure.
			*/
			root: {
				type: Boolean,
				default: true
			}
		},

		expose: [],

		computed: {
			/**
			* Array of class names to apply to the menu item LI element, based on the menu properties and state.
			*/
			menuClasses()
			{
				const classes = ['nav-item', 'n-sidebar__nav-item']

				if (!this.isEmpty(this.menu.Children))
				{
					classes.push('has-treeview')
					classes.push(`level-${this.level}`)
				}

				if (this.menuIsOpen(this.menu))
					classes.push('menu-open')

				return classes
			},

			/**
			* Class name to apply to sub-menu UL elements, based on the nesting level of the menu.
			*/
			levelClass()
			{
				return `level-${this.level}`
			}
		},

		methods: {
			getMenuList(id)
			{
				return `QMenu${this.module}_${id}`
			}
		}
	}
</script>
