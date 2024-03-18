<template>
	<div
		v-if="isVisible"
		class="d-block"
		style="flex-grow: 1">
		<div class="f-login">
			<div class="f-login__container">
				<div class="f-login__background">
					<div class="f-login__brand">
						<img
							:src="`${system.resourcesPath}f-login__brand.png`"
							alt="" />
						<p>{{ texts.appName }}</p>
					</div>

					<div class="form-flow">
						<template v-if="!model.IsEmailSent">
							<p>{{ texts.enterEmail }}</p>

							<q-text-field
								:classes="['f-login__input-field']"
								v-model="model.Email.value"
								v-bind="controls.Email"
								:placeholder="texts.email"
								@update:model-value="model.Email.fnUpdateValue" />

							<q-button
								b-style="primary"
								block
								:class="['q-btn--login']"
								:label="texts.reset"
								:title="texts.reset"
								@click="resetPassword" />

							<q-validation-summary :error-data="validationErrors" />
						</template>
						<template v-else>
							<p>{{ successMessage }}</p>
						</template>

						<q-router-link
							class="f-login__link"
							:link="{ name: 'main' }">
							{{ texts.backToLogin }}
						</q-router-link>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
	import { computed } from 'vue'
	import { mapState } from 'pinia'
	import _isEmpty from 'lodash-es/isEmpty'

	import { useSystemDataStore } from '@/stores/systemData.js'
	import { useAuthDataStore } from '@/stores/authData.js'
	import NavHandlers from '@/mixins/navHandlers.js'
	import VueNavigation from '@/mixins/vueNavigation.js'
	import modelFieldType from '@/mixins/formModelFieldTypes.js'
	import fieldControlClass from '@/mixins/fieldControl.js'
	import genericFunctions from '@/mixins/genericFunctions.js'
	import hardcodedTexts from '@/hardcodedTexts.js'

	import QRouterLink from '@/views/shared/QRouterLink.vue'

	export default {
		name: 'RecoverPassword',

		components: {
			QRouterLink
		},

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

				model: {
					IsEmailSent: false,

					Email: new modelFieldType.String({
						id: 'Email',
						originId: 'Email',
						area: '',
						field: 'EMAIL',
						required: true
					})
				},

				controls: {
					Email: new fieldControlClass.StringControl({
						id: 'Email',
						modelField: 'Email',
						valueChangeEvent: 'fieldChange:email',
						name: 'Email',
						maxLength: 254,
						hasLable: false,
						isRequired: true
					}, this)
				},

				texts: {
					appName: computed(() => this.Resources[hardcodedTexts.appName]),
					enterEmail: computed(() => this.Resources[hardcodedTexts.enterEmail]),
					email: computed(() => this.Resources[hardcodedTexts.email]),
					reset: computed(() => this.Resources[hardcodedTexts.reset]),
					backToLogin: computed(() => this.Resources[hardcodedTexts.backToLogin])
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
				this.fetchData()
				this.controls.Email.Init(true)
			}
		},

		beforeUnmount()
		{
			this.controls.Email.destroy()
		},

		computed: {
			...mapState(useSystemDataStore, [
				'system'
			]),

			...mapState(useAuthDataStore, [
				'hasPasswordRecovery'
			]),

			successMessage()
			{
				return genericFunctions.formatString(this.Resources[hardcodedTexts.passwordRecoverEmail], this.model.Email.value)
			}
		},

		methods: {
			setData(modelValue)
			{
				this.model.IsEmailSent = modelValue.IsEmailSent
				this.model.Email.updateValue(modelValue.Email)
			},

			fetchData()
			{
				return this.netAPI.fetchData('Account', 'RecoverPassword', null, data => {
					this.setData(data)
				})
			},

			resetPassword()
			{
				return this.netAPI.postData('Account', 'RecoverPassword', {
					Email: this.model.Email.value
				}, async (data, response) => {
					this.setData(data)

					if (response.data.Success)
						this.validationErrors = {}
					else
					{
						if (!_isEmpty(response.data.Errors))
							this.validationErrors = response.data.Errors
						else if (typeof response.data.Message === 'string')
							genericFunctions.displayMessage(response.data.Message, 'error')
					}
				})
			}
		}
	}
</script>
