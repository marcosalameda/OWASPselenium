import { mapActions, mapState } from 'pinia'

import netAPI from '@/api/network'
import VueNavigation from '@/mixins/vueNavigation.js'
import { useGenericDataStore } from '@/stores/genericData.js'
import { useSystemDataStore } from '@/stores/systemData.js'
import { useUserDataStore } from '@/stores/userData.js'
import { hydrateAlert } from './alertFunctions.js'

export default {
	mixins: [
		VueNavigation
	],

	computed: {
		...mapState(useSystemDataStore, [
			'system',
			'appAlerts'
		]),

		...mapState(useUserDataStore, [
			'valuesOfPHEs'
		])
	},

	methods: {
		...mapActions(useGenericDataStore, [
			'setNotifications'
		]),

		fetchAlerts()
		{
			return netAPI.postData(
				'Alerts',
				'Index',
				null,
				(data) => {
					if (data)
					{
						const alerts = []

						data.forEach((alertData) => {
							const alert = hydrateAlert(alertData)

							if (alert) alerts.push(alert)
						})

						this.setNotifications(alerts)
					}
				},
				undefined,
				undefined,
				this.navigationId
			)
		},

		onAlertClick(target)
		{
			if (target.Type === 'menu')
				this.navigateToRouteName(`menu-${target.Name}`, {})
			else if (target.Type === 'form')
				this.navigateToForm(target.Name, 'SHOW', target.Id, {})
		}
	},

	watch: {
		'system.currentModule'()
		{
			this.fetchAlerts()
		},

		valuesOfPHEs: {
			handler()
			{
				this.fetchAlerts()
			},
			deep: true
		}
	}
}
