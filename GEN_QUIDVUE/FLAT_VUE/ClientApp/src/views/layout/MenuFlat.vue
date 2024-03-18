<template>
	<aside
		v-if="moduleCount > 0"
		:class="['main-sidebar', 'n-menu--sidebar', menuColor]">
		<div class="n-sidebar__brand">
			<q-router-link link="/">
				<img
					:src="`${system.resourcesPath}Q_icon.png`"
					:alt="texts.initialPage"
					class="n-sidebar__img" />

				<template v-if="layoutConfig.MenuBrand === 'Text'">
					<span class="brand-text n-sidebar__brand-text">{{ texts.appName }}</span>
				</template>
				<template v-else>
					<img
						:src="`${system.resourcesPath}logotipo_header.png`"
						:alt="texts.initialPage"
						class="n-sidebar__img brand-image" />
				</template>
			</q-router-link>
		</div>

		<div class="sidebar n-sidebar">
			<nav>
				<menu-search-box />
			</nav>

			<bookmarks />

			<div
				v-if="moduleCount > 1"
				class="n-sidebar__section">
				<module-header v-if="layoutConfig.ModulesStyle === 'list'" />

				<modules />
			</div>

			<div class="n-sidebar__section">
				<template v-if="moduleCount > 1">
					<div
						v-if="layoutConfig.ModulesStyle === 'list'"
						id="module-items-title"
						class="n-sidebar__title">
						<q-icon icon="menu-hamburger" />

						<p>
							{{ texts.moduleItems }}
						</p>
					</div>
					<div
						v-else
						class="nav-sidebar">
						<div class="n-sidebar__nav-link--active nav-item active-module">
							<a
								href="javascript:void(0)"
								class="d-flex nav-link"
								:data-key="system.currentModule">
								<q-icon v-bind="currentModuleIcon" />

								<p>
									<span>
										{{ currentModuleTitle }}
									</span>
								</p>
							</a>
						</div>
					</div>
				</template>

				<div
					v-if="loading"
					class="n-sidebar__section--loading">
					<div
						v-for="id in skeletonLoaders"
						:key="id"
						class="n-sidebar__section-menu--loading">
						<q-skeleton-loader
							type="icon"
							:style="{ opacity: getSkeletonLoaderOpacity(id) }" />
						<q-skeleton-loader
							type="text"
							:style="getSkeletonLoaderStyle(id)" />
					</div>
				</div>
				<ul
					v-else-if="!isEmpty(menus) && !isEmpty(menus.MenuList)"
					id="menu-tree-view"
					:key="system.currentModule"
					class="nav nav-pills nav-sidebar n-sidebar__nav d-block">
					<menu-sub-items
						v-for="menu in menus.MenuList"
						:key="menu.Id"
						:menu="menu"
						:module="system.currentModule"
						:level="0" />
				</ul>
			</div>
		</div>
	</aside>
</template>

<script>
	import { computed } from 'vue'

	import hardcodedTexts from '@/hardcodedTexts.js'
	import LayoutHandlers from '@/mixins/layoutHandlers.js'

	import Bookmarks from './Bookmarks.vue'
	import MenuSearchBox from './MenuSearchBox.vue'
	import MenuSubItems from './MenuSubItems.vue'
	import ModuleHeader from './ModuleHeader.vue'
	import Modules from './Modules.vue'
	import QRouterLink from '@/views/shared/QRouterLink.vue'

	const DEFAULT_SKELETON_LOADERS = 10

	export default {
		name: 'QMenu',

		components: {
			QRouterLink,
			ModuleHeader,
			MenuSearchBox,
			Bookmarks,
			Modules,
			MenuSubItems
		},

		mixins: [LayoutHandlers],

		props: {
			/**
			 * Whether or not the menu structure is loading.
			 */
			loading: {
				type: Boolean,
				default: false
			}
		},

		expose: [],

		data()
		{
			return {
				skeletonLoaders: DEFAULT_SKELETON_LOADERS,

				texts: {
					appName: computed(() => this.Resources[hardcodedTexts.appName]),
					initialPage: computed(() => this.Resources[hardcodedTexts.initialPage]),
					moduleItems: computed(() => this.Resources[hardcodedTexts.moduleItems])
				}
			}
		},

		computed: {
			menuColor()
			{
				return this.layoutConfig.MenuBackgroundColor === 'light' ? 'sidebar-light' : ''
			},

			moduleCount()
			{
				return Object.keys(this.system.availableModules).length
			},
		},

		methods: {
			getSkeletonLoaderStyle(order)
			{
				// The width is randomized to produce the effect
				// of menus with titles of different sizes being loaded
				const minWidth = 33
				const maxWidth = 80
				const widthPercentage = Math.floor(Math.random() * (maxWidth - minWidth + 1) + minWidth) + '%'

				return {
					width: widthPercentage,
					opacity: this.getSkeletonLoaderOpacity(order)
				}
			},

			getSkeletonLoaderOpacity(order)
			{
				return (this.skeletonLoaders - order + 1) / this.skeletonLoaders
			}
		}
	}
</script>
