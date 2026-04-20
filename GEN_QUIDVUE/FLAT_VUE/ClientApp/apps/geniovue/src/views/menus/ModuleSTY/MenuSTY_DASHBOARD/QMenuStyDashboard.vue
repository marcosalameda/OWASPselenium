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

	const requiredTextResources = ['QMenuSTY_DASHBOARD', 'hardcoded', 'messages']

	export default {
		name: 'QMenuStyDashboard',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuSTY_DASHBOARD', false),

				interfaceMetadata: {
					id: 'QMenuSTY_DASHBOARD', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					acronym: 'STY_DASHBOARD',
					name: '*',
					route: 'menu-STY_DASHBOARD',
					order: '431'
				},

				controls: {
					dashboard: new DashboardControl({
						action: 'STY_Menu_DASHBOARD',
						title: computed(() => this.Resources.MY_DASHBOARD19348),
						groups: [
							{
								id: 'BOOKMARKS',
								order: 1,
								hideGroup: false,
								title: computed(() => vm.Resources.FAVORITOS12992),
							},
							{
								id: '_ALERTS',
								hideGroup: false,
								order: 2,
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
