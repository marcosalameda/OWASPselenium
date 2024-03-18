<template>
	<div
		v-if="isVisible"
		class="f-login">
		<div class="f-login__container">
			<div class="f-login__background">
				<div class="f-login__brand">
					<img
						:src="`${system.resourcesPath}f-login__brand.png`"
						alt="" />
					<p>{{ texts.appName }}</p>
				</div>

				<h2>{{ texts.changePassword }}</h2>

				<q-validation-summary :error-data="validationErrors" />

				<div>
					<fieldset>
						<div class="clearfix">
							<base-input-structure v-bind="controls.UserId">
								<q-text-field
									class="f-login__input-field"
									v-bind="controls.UserId.props"
									:model-value="model.UserId.value"
									@update:model-value="model.UserId.fnUpdateValue" />
							</base-input-structure>
						</div>

						<div class="clearfix">
							<base-input-structure v-bind="controls.NewPassword">
								<q-password-input
									:classes="['f-login__input-field']"
									v-bind="controls.NewPassword"
									:model-value="model.NewPassword.value"
									@update:model-value="model.NewPassword.fnUpdateValue" />
							</base-input-structure>
						</div>

						<div class="clearfix">
							<base-input-structure v-bind="controls.ConfirmPassword">
								<q-password-input
									:classes="['f-login__input-field']"
									v-bind="controls.ConfirmPassword"
									:model-value="model.ConfirmPassword.value"
									@update:model-value="model.ConfirmPassword.fnUpdateValue" />
							</base-input-structure>
						</div>

						<div class="actions">
							<q-button
								b-style="primary"
								block
								:class="['q-btn--login', 'text-uppercase']"
								:label="texts.reset"
								:title="texts.reset"
								@click="resetPassword" />
						</div>
					</fieldset>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
	import { computed } from 'vue'
	import { mapState } from 'pinia'
	import _isEmpty from 'lodash-es/isEmpty'
	import _forEach from 'lodash-es/forEach'

	import { useSystemDataStore } from '@/stores/systemData.js'
	import { useAuthDataStore } from '@/stores/authData.js'
	import { QEventEmitter } from '@/api/global/eventBus.js'
	import NavHandlers from '@/mixins/navHandlers.js'
	import VueNavigation from '@/mixins/vueNavigation.js'
	import modelFieldType from '@/mixins/formModelFieldTypes.js'
	import fieldControlClass from '@/mixins/fieldControl.js'
	import genericFunctions from '@/mixins/genericFunctions.js'
	import ViewModelBase from '@/mixins/formViewModelBase.js'
	import hardcodedTexts from '@/hardcodedTexts.js'

	class ViewModel extends ViewModelBase
	{
		constructor(vueContext)
		{
			super(vueContext)

			this.UserId = new modelFieldType.String({
				id: 'UserId',
				originId: 'UserId',
				field: 'UserId',
				readonly: true,
				required: true
			})

			this.NewPassword = new modelFieldType.String({
				id: 'NewPassword',
				originId: 'NewPassword',
				field: 'NewPassword',
				isRequired: true
			})

			this.ConfirmPassword = new modelFieldType.String({
				id: 'ConfirmPassword',
				originId: 'ConfirmPassword',
				field: 'ConfirmPassword',
				isRequired: true
			})
		}
	}

	export default {
		name: 'RecoverPasswordChange',

		mixins: [
			NavHandlers,
			VueNavigation
		],

		expose: [
			'navigationId'
		],

		data()
		{
			return {
				validationErrors: {},

				isVisible: false,

				internalEvents: new QEventEmitter(),

				model: new ViewModel(this),

				controls: {
					UserId: new fieldControlClass.StringControl({
						id: 'UserId',
						modelField: 'UserId',
						valueChangeEvent: 'fieldChange:email',
						name: 'UserId',
						label: computed(() => this.Resources[hardcodedTexts.user]),
						maxLength: 75,
						labelAttrs: null
					}, this),
					NewPassword: new fieldControlClass.StringControl({
						id: 'NewPassword',
						modelField: 'NewPassword',
						valueChangeEvent: 'fieldChange:NewPassword',
						name: 'NewPassword',
						label: computed(() => this.Resources[hardcodedTexts.newPassword]),
						maxLength: 50,
						labelId: 'label_NewPassword',
						labelAttrs: null
					}, this),
					ConfirmPassword: new fieldControlClass.StringControl({
						id: 'ConfirmPassword',
						modelField: 'ConfirmPassword',
						valueChangeEvent: 'fieldChange:ConfirmPassword',
						name: 'ConfirmPassword',
						label: computed(() => this.Resources[hardcodedTexts.confirmPassword]),
						maxLength: 50,
						labelId: 'label_ConfirmPassword',
						labelAttrs: null
					}, this)
				},

				texts: {
					appName: computed(() => this.Resources[hardcodedTexts.appName]),
					changePassword: computed(() => this.Resources[hardcodedTexts.changePassword]),
					reset: computed(() => this.Resources[hardcodedTexts.reset])
				}
			}
		},

		created()
		{
			if (this.hasPasswordRecovery === false)
				this.navigateToRouteName('main')
			else
			{
				this.isVisible = true
				this.model.UserId.updateValue(this.$route.query.UserId)
				this.initFormControls(true)
			}
		},

		beforeUnmount()
		{
			this.destroyFormControls()
		},

		computed: {
			...mapState(useSystemDataStore, [
				'system'
			]),

			...mapState(useAuthDataStore, [
				'hasPasswordRecovery'
			])
		},

		methods: {
			setData(modelValue)
			{
				if (_isEmpty(modelValue))
					return

				for (let fld in this.model)
					this.model[fld].updateValue(modelValue[fld])
			},

			resetPassword()
			{
				return this.netAPI.postData('Account', 'RecoverPasswordChange', this.model.serverObjModel, async (data, response) => {
					this.setData(data)

					if (response.data.Success)
						this.navigateToRouteName('password-recovery-change-success')
					else
					{
						if (!_isEmpty(response.data.Errors))
							this.validationErrors = response.data.Errors
						else if (typeof response.data.Message === 'string')
							genericFunctions.displayMessage(response.data.Message, 'error')
					}
				})
			},

			initFormControls()
			{
				this.controls.UserId.Init(false)
				this.controls.NewPassword.Init(true)
				this.controls.ConfirmPassword.Init(true)
			},

			destroyFormControls()
			{
				_forEach(this.controls, ctrl => ctrl.destroy())
			}
		}
	}
</script>
