<template>
	<teleport to="#q-modal-menu-GQT_141-body">
		<div>
			<q-row-container>
				<q-control-wrapper class="control-join-group">
					<base-input-structure
						id="start-limit"
						:class="['i-text']"
						:label="Resources.INICIO15853"
						:label-attrs="{ class: 'i-text__label' }">
						<q-datetime-input
							id="start-limit-field"
							format="DateTime"
							:model-value="model.ValMinvalue.value"
							:date-format="{ Date: 'DD-MM-YYYY HH:mm' }"
							@update:model-value="model.ValMinvalue.fnUpdateValue" />
					</base-input-structure>
				</q-control-wrapper>

				<q-control-wrapper class="control-join-group">
					<base-input-structure
						id="end-limit"
						:class="['i-text']"
						:label="Resources.FIM04424"
						:label-attrs="{ class: 'i-text__label' }">
						<q-datetime-input
							id="end-limit-field"
							format="DateTime"
							:model-value="model.ValMaxvalue.value"
							:date-format="{ Date: 'DD-MM-YYYY HH:mm' }"
							@update:model-value="model.ValMaxvalue.fnUpdateValue" />
					</base-input-structure>
				</q-control-wrapper>
			</q-row-container>
		</div>
	</teleport>

	<teleport to="#q-modal-menu-GQT_141-footer">
		<div class="actions float-right">
			<q-button
				b-style="primary"
				:label="Resources.OK15819"
				:title="Resources.OK15819"
				@click="followUp">
				<q-icon icon="ok" />
			</q-button>

			<q-button
				data-dismiss="modal"
				aria-hidden="true"
				b-style="secondary"
				:label="Resources.FECHAR32496"
				:title="Resources.FECHAR32496"
				@click="goBack">
				<q-icon icon="remove" />
			</q-button>
		</div>
	</teleport>
</template>

<script>
	/* eslint-disable no-unused-vars */
	import _foreach from 'lodash-es/forEach'
	import { computed } from 'vue'

	import { loadResources } from '@/plugins/i18n.js'
	import { QEventEmitter } from '@/api/global/eventBus.js'
	import asyncProcM from '@/api/global/asyncProcMonitoring.js'
	import GenericMenuHandlers from '@/mixins/genericMenuHandlers.js'
	import formControlClass from '@/mixins/formControl.js'
	import genericFunctions from '@/mixins/genericFunctions.js'
	import formFunctions from '@/mixins/formFunctions.js'
	import modelFieldType from '@/mixins/formModelFieldTypes.js'
	import hardcodedTexts from '@/hardcodedTexts.js'

	import netAPI from '@/api/network'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	import qEnums from '@/mixins/quidgest.mainEnums.js'
	/* eslint-enable no-unused-vars */

	const requiredTextResources = ['QMenuGQT_141', 'hardcoded', 'messages']

	export default {
		name: 'QMenuGqt141',

		mixins: [
			GenericMenuHandlers
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
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuGQT_141', false),

				internalEvents: new QEventEmitter(),

				formControl: new formControlClass.FormControl(this),

				interfaceMetadata: {
					id: 'QMenuGQT_141', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					acronym: 'GQT_141',
					name: 'SE1A HJ',
					route: 'menu-GQT_141',
					order: '141',
					isPopup: true
				},

				model: {
					ValMinvalue: new modelFieldType.Date({
						id: 'ValMinvalue',
						area: 'LENDI'
					}),
					ValMaxvalue: new modelFieldType.Date({
						id: 'ValMaxvalue',
						area: 'LENDI'
					})
				}
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
			this.componentOnLoadProc.AddBusy(loadResources(this, requiredTextResources), this.Resources[hardcodedTexts.genericLoad], 300)
			// Only after the data is loaded from the server, init all controls
			this.componentOnLoadProc.Once(() => {
				// Init form
				this.formControl.Init()
			}, this)
		},

		mounted()
		{
			const modalProps = {
				isActive: true,
				hideHeader: false,
				hideFooter: false,
				dismissWithEsc: true,
				modalWidth: 'sm',
				closeButtonEnable: true,
				dismissAction: this.goBack,
				headerTitle: computed(() => this.Resources.LENDING_IN_THE_PERIO23741)
			}

			// Show modal after necessary resources are loaded (e.g., header title)
			this.componentOnLoadProc.Once(() => {
				this.setModalProperties(modalProps)
			}, this)
		},

		beforeUnmount()
		{
			// Removes the listener
			this.internalEvents.removeAllListeners()
		},

		methods: {
			followUp()
			{
				const limits = { minLimit: this.model.ValMinvalue.value, maxLimit: this.model.ValMaxvalue.value, ValMinvalue: this.model.ValMinvalue.value, ValMaxvalue: this.model.ValMaxvalue.value }
				_foreach(limits, (limitValue, limitIdentifier) => {
					this.setEntryValue({ navigationId: this.navigationId, key: limitIdentifier, value: limitValue })
				})
				this.navigateToRouteName('menu-GQT_1411', genericFunctions.normalizeDataInNavigationParams(limits))
			}
		}
	}
</script>
