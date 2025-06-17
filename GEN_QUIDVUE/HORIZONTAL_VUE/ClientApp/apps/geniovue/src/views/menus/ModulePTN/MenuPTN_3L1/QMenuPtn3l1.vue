<template>
	<q-dashboard
		v-if="componentOnLoadProc.loaded"
		v-bind="controls.dashboard"
		v-on="controls.dashboard.handlers" />
</template>

<script>
	import { computed } from 'vue'

	import { loadResources } from '@/plugins/i18n.js'
	import asyncProcM from '@quidgest/clientapp/composables/async'
	import GenericMenuHandlers from '@/mixins/genericMenuHandlers.js'
	import DashboardHandlers from '@/mixins/dashboardHandlers.js'
	import { DashboardControl } from '@/mixins/dashboardControl.js'

	const requiredTextResources = ['QMenuPTN_3L1', 'hardcoded', 'messages']

	export default {
		name: 'QMenuPtn3l1',

		mixins: [
			GenericMenuHandlers,
			DashboardHandlers
		],

		inheritAttrs: false,

		props: {
			/**
			 * Whether or not the form is used as a homepage.
			 */
			isHomePage: {
				type: Boolean,
				default: false
			}
		},

		expose: [
			'navigationId',
			'updateMenuNavigation'
		],

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuPTN_3L1', false),

				interfaceMetadata: {
					id: 'QMenuPTN_3L1', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					acronym: 'PTN_3L1',
					name: '*',
					route: 'menu-PTN_3L1',
					order: '3L1'
				},

				controls: {
					dashboard: new DashboardControl({
						action: 'PTN_Menu_3L1',
						title: computed(() => this.Resources.DASHBOARD51597),
						groups: [
							{
								id: 'BOOKMARKS',
								order: 14,
								hideGroup: false,
								title: computed(() => vm.Resources.FAVORITOS12992),
							},
							{
								id: '_GROUP02',
								hideGroup: false,
								order: 2,
								title: computed(() => vm.Resources.LISTS54900),
							},
							{
								id: '_MENUS',
								hideGroup: false,
								order: 13,
								title: computed(() => vm.Resources.MENUS09526),
							},
							{
								id: '_GROUP01',
								hideGroup: false,
								order: 1,
								title: computed(() => vm.Resources.GRAPHS20473),
							},
							{
								id: '_ALERTS',
								hideGroup: false,
								order: 6,
								title: computed(() => vm.Resources.ALERTS30407),
							},
						],
					}, this)
				}
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// called before the route that renders this component is confirmed.
			// does NOT have access to `this` component instance,
			// because it has not been created yet when this guard is called!

			next((vm) => vm.updateMenuNavigation(to))
		},

		created()
		{
			this.componentOnLoadProc.addImmediateBusy(loadResources(this, requiredTextResources))
			this.componentOnLoadProc.addImmediateBusy(this.fetchDashboardData(this.controls.dashboard))
			this.componentOnLoadProc.once(() => this.controls.dashboard.init(), this)
		}
	}
</script>
