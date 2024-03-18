<template>
	<ul
		v-if="layoutConfig.ModulesStyle === 'collapsible'"
		id="modules-tree-view"
		class="nav nav-pills nav-sidebar n-sidebar__nav d-block collpased-modules">
		<li :class="[{ 'menu-open': moduleMenuIsOpen }, 'nav-item', 'n-sidebar__nav-item', 'has-treeview']">
			<a
				class="nav-link n-sidebar__nav-link d-flex"
				href="javascript:void(0)"
				:data-key="system.currentModule"
				@click.stop.prevent="toggleModulesMenu">
				<q-icon icon="modules" />

				<p>
					{{ texts.modules }}
					<q-icon
						icon="expand"
						class="right" />
				</p>
			</a>

			<transition name="sidebar-dropdown">
				<ul
					v-if="moduleMenuIsOpen"
					id="collapsible-modules"
					class="nav nav-treeview">
					<all-modules @navigate-to-module="toggleModulesMenu" />
				</ul>
			</transition>
		</li>
	</ul>
	<ul
		v-else-if="layoutConfig.ModulesStyle === 'list'"
		id="modules-tree-view"
		class="nav nav-pills nav-sidebar n-sidebar__nav d-block modules-list-view">
		<all-modules />
	</ul>
	<div
		v-else-if="layoutConfig.ModulesStyle === 'dropdown'"
		class="n-sidebar__nav-item--dropdown">
		<ul class="nav">
			<li class="dropdown">
				<a
					href="javascript:void(0)"
					class="brand"
					data-toggle="dropdown">
					<module-header />
				</a>

				<ul class="dropdown-menu">
					<template
						v-for="mod in system.availableModules"
						:key="mod.id">
						<li v-if="mod.id !== system.currentModule">
							<a
								class="dropdown-item"
								href="javascript:void(0)"
								:data-key="mod.id"
								@click.prevent="navigateToModule(mod.id)">
								<q-icon 
									v-if="getModuleIconProps(mod)"
									v-bind="getModuleIconProps(mod)" />
								{{ Resources[mod.title] }}
							</a>
						</li>
					</template>
				</ul>
			</li>
		</ul>
	</div>
</template>

<script>
	import { computed } from 'vue'

	import hardcodedTexts from '@/hardcodedTexts.js'
	import LayoutHandlers from '@/mixins/layoutHandlers.js'
	import VueNavigation from '@/mixins/vueNavigation.js'

	import ModuleHeader from './ModuleHeader.vue'
	import AllModules from './AllModules.vue'

	export default {
		name: 'QModules',

		components: {
			ModuleHeader,
			AllModules
		},

		mixins: [
			LayoutHandlers,
			VueNavigation
		],

		expose: [],

		data()
		{
			return {
				texts: {
					modules: computed(() => this.Resources[hardcodedTexts.modules])
				}
			}
		}
	}
</script>
