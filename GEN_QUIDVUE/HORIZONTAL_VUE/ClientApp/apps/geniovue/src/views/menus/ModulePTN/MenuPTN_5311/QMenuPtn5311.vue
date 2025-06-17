<template>
	<teleport to="#q-modal-menu-PTN_5311-body">
		<div class="multi-report-menu__container">
			<div>
				<q-card
					title="XLSX"
					:subtitle="Resources.MS_EXCEL22417"
					elevation="low"
					@click="exportReport('XLSX')">
					<template #[`header.prepend`]>
						<img
							:src="getImagePath('XLSX')"
							height="150" />
					</template>
				</q-card>
			</div>
			<div>
				<q-card
					title="PDF"
					:subtitle="Resources.PDF54897"
					elevation="low"
					@click="exportReport('PDF')">
					<template #[`header.prepend`]>
						<img
							:src="getImagePath('PDF')"
							height="150" />
					</template>
				</q-card>
			</div>
		</div>
	</teleport>
</template>

<script>
	/* eslint-disable no-unused-vars */
	import _foreach from 'lodash-es/forEach'
	import { computed } from 'vue'

	import { loadResources } from '@/plugins/i18n.js'
	import { QEventEmitter } from '@quidgest/clientapp/plugins/eventBus'
	import { useSystemDataStore } from '@quidgest/clientapp/stores'
	import asyncProcM from '@quidgest/clientapp/composables/async'
	import GenericMenuHandlers from '@/mixins/genericMenuHandlers.js'
	import formControlClass from '@/mixins/formControl.js'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import formFunctions from '@/mixins/formFunctions.js'
	import hardcodedTexts from '@/hardcodedTexts.js'

	import netAPI from '@quidgest/clientapp/network'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	import qEnums from '@quidgest/clientapp/constants/enums'
	/* eslint-enable no-unused-vars */

	const requiredTextResources = ['QMenuPTN_5311', 'hardcoded', 'messages']

	export default {
		name: 'QMenuPtn5311',

		mixins: [
			GenericMenuHandlers
		],

		inheritAttrs: false,

		expose: [
			'navigationId',
			'updateMenuNavigation'
		],

		data()
		{
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuPTN_5311', false),

				formControl: new formControlClass.FormControl(this),

				interfaceMetadata: {
					id: 'QMenuPTN_5311', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					acronym: 'PTN_5311',
					name: 'comodatos',
					route: 'menu-PTN_5311',
					order: '5311',
					isPopup: true
				},

				/** Limits */
				menuLimits: [
					/** DB */
					{
						identifier: 'pess1',
						dependencyEvents: [],
						dependencyField: '',
						fnValueSelector: () => this.$route.params['pess1']
					},
				]
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// called before the route that renders this component is confirmed.
			// does NOT have access to `this` component instance,
			// because it has not been created yet when this guard is called!

			to.params.isPopup = 'true'

			next((vm) => vm.updateMenuNavigation(to))
		},

		created()
		{
			// Load resources (translations)
			this.componentOnLoadProc.addBusy(loadResources(this, requiredTextResources), this.Resources[hardcodedTexts.genericLoad], 300)

			// Only after the data is loaded from the server, init all controls
			this.componentOnLoadProc.once(() => this.formControl.init(), this)
		},

		mounted()
		{
			const modalProps = {
				isActive: true,
				hideHeader: false,
				hideFooter: true,
				dismissWithEsc: true,
				closeButtonEnable: true,
				dismissAction: this.goBack,
				headerTitle: computed(() => this.Resources.REPORT_FORMAT51516)
			}

			// Show modal after necessary resources are loaded (e.g., header title)
			this.componentOnLoadProc.once(() => this.setModalProperties(modalProps), this)
		},

		methods: {
			/**
			 * Gets the path for the image associated to a given file extension.
			 */
			getImagePath(format) {
				return `${this.$app.resourcesPath}report_${format}.png`
			},

			/**
			 * Server call to render the report in a given format.
			 */
			exportReport(format) {
				// Set previous limits in navigation
				this.menuLimits.forEach((limit) => {
					const limitIdentifier = limit.identifier
					const limitValue = limit.fnValueSelector()

					this.setEntryValue({
						navigationId: this.navigationId,
						key: limitIdentifier,
						value: limitValue
					})
				})

				const preview = false
				this.navigateToReport('Pess1', 'PTN_Report_5311', { format: format }, preview)
					.then((success) => {
						if (success)
							this.goBack()
						else
							genericFunctions.displayMessage(this.Resources.PEDIMOS_DESCULPA__OC63848, 'error')
					})
			}
		}
	}
</script>
