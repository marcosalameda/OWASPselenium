<template>
	<teleport to="#q-modal-menu-GQT_151-body">
		<div v-if="model">
			<q-row-container>
				<q-control-wrapper class="control-join-group">
					<!-- SE1A HJ -->
					<base-input-structure
						id="start-limit"
						:class="['i-text']"
						:label="Resources.INICIO15853"
						:label-attrs="{ class: 'i-text__label' }">
						<q-date-time-picker
							id="start-limit-field"
							:date-time-type="dateTimeType"
							:format="dateTimeFormat"
							:locale="locale"
							:model-value="model.ValMinvalue.value"
							@reset-icon-click="model.ValMinvalue.fnUpdateValue(model.ValMinvalue.originalValue ?? new Date())"
							@update:model-value="model.ValMinvalue.fnUpdateValue" />
					</base-input-structure>
				</q-control-wrapper>

				<q-control-wrapper class="control-join-group">
					<base-input-structure
						id="end-limit"
						:class="['i-text']"
						:label="Resources.FIM04424"
						:label-attrs="{ class: 'i-text__label' }">
						<q-date-time-picker
							id="end-limit-field"
							:date-time-type="dateTimeType"
							:format="dateTimeFormat"
							:locale="locale"
							:model-value="model.ValMaxvalue.value"
							@reset-icon-click="model.ValMaxvalue.fnUpdateValue(model.ValMaxvalue.originalValue ?? new Date())"
							@update:model-value="model.ValMaxvalue.fnUpdateValue" />
					</base-input-structure>
				</q-control-wrapper>
			</q-row-container>
		</div>
	</teleport>

	<teleport to="#q-modal-menu-GQT_151-footer">
		<div class="actions float-right">
			<q-button
				variant="bold"
				:label="Resources.OK15819"
				:title="Resources.OK15819"
				@click="followUp">
				<q-icon icon="ok" />
			</q-button>

			<q-button
				data-dismiss="modal"
				aria-hidden="true"
				:label="Resources.FECHAR32496"
				:title="Resources.FECHAR32496"
				@click="goBack">
				<q-icon icon="remove" />
			</q-button>
		</div>
	</teleport>
</template>

<script>
	/* eslint-disable @typescript-eslint/no-unused-vars */
	import _foreach from 'lodash-es/forEach'
	import { computed } from 'vue'

	import { loadResources } from '@/plugins/i18n.js'
	import { QEventEmitter } from '@quidgest/clientapp/plugins/eventBus'
	import asyncProcM from '@quidgest/clientapp/composables/async'
	import GenericMenuHandlers from '@/mixins/genericMenuHandlers.js'
	import formControlClass from '@/mixins/formControl.js'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import formFunctions from '@/mixins/formFunctions.js'
	import modelFieldType from '@quidgest/clientapp/models/fields'
	import hardcodedTexts from '@/hardcodedTexts.js'
	import { resetProgressBar, setProgressBar } from '@/utils/layout.js'
	import { useSystemDataStore, useGenericDataStore } from '@quidgest/clientapp/stores'

	import netAPI from '@quidgest/clientapp/network'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	import qEnums from '@quidgest/clientapp/constants/enums'
	/* eslint-enable @typescript-eslint/no-unused-vars */

	const requiredTextResources = ['QMenuGQT_151', 'hardcoded', 'messages']

	export default {
		name: 'QMenuGqt151',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuGQT_151', false),

				formControl: new formControlClass.FormControl(this),

				interfaceMetadata: {
					id: 'QMenuGQT_151', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					acronym: 'GQT_151',
					name: 'SE1A HJ',
					route: 'menu-GQT_151',
					order: '151',
					isPopup: true
				},

				model: null,

				locale: useSystemDataStore().system.currentLang,
				dateTimeType: 'dateTime'
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
			// Load default limit values
			const vm = this
			this.componentOnLoadProc.addBusy(netAPI.postData("LENDI", 'GQT_MenuSE_151', null, (data) => {
				vm.model = {
					ValMinvalue: new modelFieldType.DateTime({
						id: 'ValMinvalue',
						area: 'LENDI',
						value: data.ValMinvalue,
						originalValue: data.ValMinvalue
					}),
					ValMaxvalue: new modelFieldType.DateTime({
						id: 'ValMaxvalue',
						area: 'LENDI',
						value: data.ValMaxvalue,
						originalValue: data.ValMaxvalue
					})
				}
			}, undefined, undefined, undefined))
			// Only after the data is loaded from the server, init all controls
			this.componentOnLoadProc.once(() => this.formControl.init(), this)
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
			this.componentOnLoadProc.once(() => this.setModalProperties(modalProps), this)
		},

		beforeUnmount()
		{
			// Removes the listener
			this.internalEvents?.removeAllListeners()
		},

		computed: {
			dateTimeFormat()
			{
				return useGenericDataStore().dateFormat[this.dateTimeType]
			}
		},
		methods: {
			followUp()
			{
				const limits = { minLendiValStart: this.model.ValMinvalue.value, maxLendiValStart: this.model.ValMaxvalue.value }
				_foreach(limits, (limitValue, limitIdentifier) => {
					this.setEntryValue({
						navigationId: this.navigationId,
						key: limitIdentifier,
						value: limitValue
					})
				})

				const preview = true
				this.navigateToReport('Lendi', 'GQT_Report_1511', undefined, preview)
			},
		}
	}
</script>
