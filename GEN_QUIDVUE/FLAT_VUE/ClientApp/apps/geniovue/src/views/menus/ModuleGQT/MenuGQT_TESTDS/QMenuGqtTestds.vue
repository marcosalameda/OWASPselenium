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

	const requiredTextResources = ['QMenuGQT_TESTDS', 'hardcoded', 'messages']

	export default {
		name: 'QMenuGqtTestds',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuGQT_TESTDS', false),

				interfaceMetadata: {
					id: 'QMenuGQT_TESTDS', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					acronym: 'GQT_TESTDS',
					name: 'Dashboard',
					route: 'menu-GQT_TESTDS',
					order: 'C1'
				},

				controls: {
					dashboard: new DashboardControl({
						action: 'GQT_Menu_TESTDS',
						title: computed(() => this.Resources.DASHBOARD51597),
						groups: [
							{
								id: 'BOOKMARKS',
								order: 5,
								hideGroup: false,
								title: computed(() => vm.Resources.FAVORITOS12992),
							},
							{
								id: '_LENDINGS',
								hideGroup: false,
								order: 1,
								title: computed(() => vm.Resources.LENDINGS30501),
							},
							{
								id: '_ITEMS',
								hideGroup: false,
								order: 6,
								title: computed(() => vm.Resources.ITEMS55321),
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
