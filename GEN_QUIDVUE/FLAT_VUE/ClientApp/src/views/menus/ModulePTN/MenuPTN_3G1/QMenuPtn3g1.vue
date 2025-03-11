<template>
	<teleport to="#q-modal-menu-PTN_3G1-body">
		<div v-if="model">
			<q-row-container>
				<q-control-wrapper class="control-join-group">
					<!-- SE1M HJ -->
					<base-input-structure
						id="start-limit"
						:class="['i-text']"
						:label="Resources.INICIO15853"
						:label-attrs="{ class: 'i-text__label' }">
						<q-date-time-picker
							id="start-limit-field"
							format="date"
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
							format="date"
							:locale="locale"
							:model-value="model.ValMaxvalue.value"
							@reset-icon-click="model.ValMaxvalue.fnUpdateValue(model.ValMaxvalue.originalValue ?? new Date())"
							@update:model-value="model.ValMaxvalue.fnUpdateValue" />
					</base-input-structure>
				</q-control-wrapper>
			</q-row-container>
		</div>
	</teleport>

	<teleport to="#q-modal-menu-PTN_3G1-footer">
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
	import { useSystemDataStore } from '@/stores/systemData.js'

	import netAPI from '@/api/network'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	import qEnums from '@/mixins/quidgest.mainEnums.js'
	/* eslint-enable no-unused-vars */

	const requiredTextResources = ['QMenuPTN_3G1', 'hardcoded', 'messages']

	export default {
		name: 'QMenuPtn3g1',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuPTN_3G1', false),

				formControl: new formControlClass.FormControl(this),

				interfaceMetadata: {
					id: 'QMenuPTN_3G1', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					acronym: 'PTN_3G1',
					name: 'SE1M HJ',
					route: 'menu-PTN_3G1',
					order: '3G1',
					isPopup: true
				},

				model: null,

				locale: useSystemDataStore().system.currentLang
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
			let vm = this;
			this.componentOnLoadProc.addBusy(netAPI.postData("EQUIP", 'PTN_MenuSE_3G1', null, (data) => {
				vm.model = {
					ValMinvalue: new modelFieldType.Date({
						id: 'ValMinvalue',
						area: 'EQUIP',
						value: data.ValMinvalue,
						originalValue: data.ValMinvalue
					}),
					ValMaxvalue: new modelFieldType.Date({
						id: 'ValMaxvalue',
						area: 'EQUIP',
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
				headerTitle: computed(() => this.Resources.EQUIPMENT___1_MONTH_48623)
			}

			// Show modal after necessary resources are loaded (e.g., header title)
			this.componentOnLoadProc.once(() => this.setModalProperties(modalProps), this)
		},

		beforeUnmount()
		{
			// Removes the listener
			this.internalEvents.removeAllListeners()
		},

		methods: {
			followUp()
			{
				const limits = { minEquipValDtaquisi: this.model.ValMinvalue.value, maxEquipValDtaquisi: this.model.ValMaxvalue.value }
				_foreach(limits, (limitValue, limitIdentifier) => {
					this.setEntryValue({
						navigationId: this.navigationId,
						key: limitIdentifier,
						value: limitValue
					})
				})

				this.navigateToRouteName('menu-PTN_3G11', genericFunctions.normalizeDataInNavigationParams(limits))
			},
		}
	}
</script>
