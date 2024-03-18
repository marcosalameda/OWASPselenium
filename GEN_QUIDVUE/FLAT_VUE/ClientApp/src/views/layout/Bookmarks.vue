<template>
	<div
		v-if="layoutConfig.BookmarkEnable && userIsLoggedIn"
		class="n-sidebar__section bookmarks__container">
		<ul
			id="bookmarks-tree-view"
			class="nav nav-pills nav-sidebar n-sidebar__nav d-block">
			<li :class="[{ 'menu-open': bookmarkMenuIsOpen }, 'nav-item', 'n-sidebar__nav-item', 'has-treeview']">
				<a
					class="nav-link n-sidebar__nav-link d-flex bookmarks__menu-text"
					href="javascript:void(0)"
					@click.stop.prevent="toggleBookmarksMenu">
					<q-icon icon="favourites" />

					<p>
						{{ texts.favorites }}
						<q-icon
							icon="expand"
							class="right" />
					</p>
				</a>

				<transition name="sidebar-dropdown">
					<bookmarks-content
						v-if="bookmarkMenuIsOpen"
						:classes="['d-block', 'nav', 'nav-treeview']"
						:show-titles="!sidebarIsCollapsed" />
				</transition>
			</li>
		</ul>
	</div>
</template>

<script>
	import { computed } from 'vue'

	import hardcodedTexts from '@/hardcodedTexts.js'
	import LayoutHandlers from '@/mixins/layoutHandlers.js'
	import BookmarksContent from '@/views/shared/BookmarksContent.vue'

	export default {
		name: 'QBookmarks',

		components: {
			BookmarksContent
		},

		mixins: [
			LayoutHandlers
		],

		expose: [],

		data()
		{
			return {
				texts: {
					favorites: computed(() => this.Resources[hardcodedTexts.favorites])
				}
			}
		}
	}
</script>
