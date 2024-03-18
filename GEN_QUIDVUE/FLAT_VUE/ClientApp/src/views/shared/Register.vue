<template>
	<div id="c-sticky-header">
		<div class="c-action-bar">
			<h1 class="form-header">
				{{ texts.createNewAccount }}
			</h1>
		</div>
	</div>

	<q-validation-summary :error-data="validationErrors" />

	<div class="form-flow">
		<template v-if="componentOnLoadProc.loaded">
			<template v-if="model.FormDataOrdem >= model.FormPswOrdem">
				<q-form-account-info
					v-if="model.FormPswData"
					:nested-model="model.FormPswData"
					@update:nested-model="handlePswModelUpdate" />
			</template>
			<template v-else>
				<q-row-container
					v-show="controls.secondForm.isVisible"
					is-large>
					<q-control-wrapper class="control-join-group">
						<q-form-container
							v-bind="controls.secondForm"
							@update:nested-model="handleModelUpdate" />
					</q-control-wrapper>
				</q-row-container>
			</template>

			<template v-if="model.FormDataOrdem >= model.FormPswOrdem">
				<q-row-container
					v-show="controls.secondForm.isVisible"
					is-large>
					<q-control-wrapper class="control-join-group">
						<q-form-container
							v-bind="controls.secondForm"
							@update:nested-model="handleModelUpdate" />
					</q-control-wrapper>
				</q-row-container>
			</template>
			<template v-else>
				<q-form-account-info
					v-if="model.FormPswData"
					:nested-model="model.FormPswData"
					@update:nested-model="handlePswModelUpdate" />
			</template>

			<div
				id="captcha-field"
				class="container-fluid i-captcha">
				<img
					class="i-captcha__img"
					:src="captchaImageUrl" />

				<q-button
					b-style="secondary"
					:class="['i-captcha__reset']"
					:title="texts.refresh"
					@click="resetCaptcha">
					<q-icon icon="reset" />
				</q-button>

				<q-row-container>
					<q-control-wrapper class="control-join-group">
						<q-text-field
							v-bind="controls.captchaInput"
							v-model="userEnteredCaptchaCode" />
					</q-control-wrapper>
				</q-row-container>
			</div>

			<div class="form-actions">
				<q-button
					b-style="primary"
					:label="texts.register"
					:title="texts.register"
					@click="register">
					<q-icon icon="save" />
				</q-button>

				<q-button
					b-style="secondary"
					:label="texts.leave"
					:title="texts.leave"
					@click="cancel">
					<q-icon icon="cancel" />
				</q-button>
			</div>
		</template>
	</div>
</template>

<script>
	import { computed } from 'vue'
	import { mapActions } from 'pinia'
	import _assignIn from 'lodash-es/assignIn'
	import _forEach from 'lodash-es/forEach'
	import _isEmpty from 'lodash-es/isEmpty'

	import { v4 as uuidv4 } from 'uuid'

	import { useGenericDataStore } from '@/stores/genericData.js'
	import { messageTypes } from '@/mixins/quidgest.mainEnums.js'
	import NavHandlers from '@/mixins/navHandlers.js'
	import VueNavigation from '@/mixins/vueNavigation.js'
	import fieldControlClass from '@/mixins/fieldControl.js'
	import genericFunctions from '@/mixins/genericFunctions.js'
	import asyncProcM from '@/api/global/asyncProcMonitoring.js'
	import ViewModelBase from '@/mixins/formViewModelBase.js'
	import hardcodedTexts from '@/hardcodedTexts.js'

	export default {
		name: 'QRegister',

		mixins: [
			NavHandlers,
			VueNavigation
		],

		props: {
			/**
			 * Nested route parameters used to configure the form fields.
			 */
			nestedRouteParams: {
				type: Object,
				default: () => ({
					name: 'UserRegistration',
					location: 'UserRegistration',
					params: {
						isNested: true
					}
				})
			}
		},

		expose: [
			'navigationId'
		],

		data()
		{
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('UserRegister', false),

				validationErrors: {},

				captchaImageUrl: '',
				userEnteredCaptchaCode: '',

				model: {
					Component: '',
					partialView: '',
					partialViewJS: '',
					PswpartialView: '',

					FormPswOrdem: 0,
					FormDataOrdem: 0,

					FormPswData: null,
					FormData: null
				},

				// It is not possible to use the model initially received because it has some fields that cannot be mapped on the server side.
				modelToSend: {
					FormPswData: new ViewModelBase(this),
					FormData: new ViewModelBase(this)
				},

				controls: {
					secondForm: new fieldControlClass.FormContainerControl({
						id: 'formData',
						name: 'formData',
						size: 'xxlarge',
						hasLabel: false,
						supportForm: {
							name: null,
							component: null,
							mode: 'NEW',
							fnKeySelector: () => null
						}
					}, this),

					captchaInput: new fieldControlClass.StringControl({
						id: 'registerCaptchaUserInput',
						size: 'large',
						maxLength: 6
					}, this)
				},

				texts: {
					createNewAccount: computed(() => this.Resources[hardcodedTexts.createNewAccount]),
					register: computed(() => this.Resources[hardcodedTexts.register]),
					leave: computed(() => this.Resources[hardcodedTexts.leave]),
					refresh: computed(() => this.Resources[hardcodedTexts.refresh])
				}
			}
		},

		created()
		{
			// Load data.
			this.componentOnLoadProc.AddBusy(this.fetchData(), this.Resources[hardcodedTexts.genericLoad], 300)
			this.resetCaptcha()
		},

		beforeUnmount()
		{
			this.controls.secondForm.destroy()
			this.componentOnLoadProc.destroy()
		},

		methods: {
			...mapActions(useGenericDataStore, [
				'setInfoMessage',
				'clearInfoMessages'
			]),

			/**
			 * Retrieves the CAPTCHA data for user validation during registration.
			 * @returns {Object} The user-entered CAPTCHA code and its associated CAPTCHA ID.
			 */
			getCaptchaData()
			{
				// The user-entered captcha code value to be validated at the backend side
				const userEnteredCaptchaCode = this.userEnteredCaptchaCode
				// The id of a captcha instance that the user tried to solve
				const captchaId = 'registerCaptcha'

				return {
					userEnteredCaptchaCode,
					captchaId
				}
			},

			/**
			 * Resets the CAPTCHA by fetching a new image URL and clearing the user's input field.
			 */
			resetCaptcha()
			{
				let apiURL = this.netAPI.apiActionURL('Account', 'GetCaptcha'),
					uId = uuidv4()
				this.captchaImageUrl = `${apiURL}?captchaId=registerCaptcha&t=${uId}`
				this.userEnteredCaptchaCode = ''
			},

			/**
			 * Registers the user by calling the Account registration endpoint with updated form data.
			 */
			register()
			{
				if (_isEmpty(this.model.redirect))
					return

				return this.netAPI.postData('Account', this.model.redirect, {
					FormPswData: this.modelToSend.FormPswData.serverObjModel,
					FormData: this.modelToSend.FormData.serverObjModel,
					CaptchaData: this.getCaptchaData()
				}, async (data, response) => {
					if (response.data.Success)
					{
						this.validationErrors = {}
						this.clearInfoMessages()

						// If there are any warning messages, they will be displayed.
						if (typeof data.Warnings === 'object' && Array.isArray(data.Warnings))
						{
							data.Warnings.forEach((w) => {
								const warningProps = {
									type: messageTypes.W,
									message: w,
									icon: 'error',
									pinned: true
								}
								this.setInfoMessage(warningProps)
							})
						}

						// Sets up the success message that the user will see after leaving the form.
						const successProps = {
							type: messageTypes.OK,
							message: data.Message,
							pinned: true
						}
						this.setInfoMessage(successProps)

						this.clearHistory()

						this.navigateToRouteName('creation-success')
					}
					else
					{
						this.resetCaptcha()

						if (!_isEmpty(response.data.Errors))
							this.validationErrors = response.data.Errors
						else if (typeof response.data.Message === 'string')
							genericFunctions.displayMessage(response.data.Message, 'error')
					}
				})
			},

			/**
			 * Navigates back to the main page without performing any registration.
			 */
			cancel()
			{
				this.$router.push({ name: 'main' })
			},

			/**
			 * Updates the model data for password-related information.
			 * @param {Object} nestedModel - The nested model data to be merged into the form state.
			 */
			handlePswModelUpdate(nestedModel)
			{
				_forEach(nestedModel, (fldData, fldName) => Reflect.set(this.modelToSend.FormPswData, fldName, fldData))
			},

			/**
			 * Updates the model data for general account information.
			 * @param {Object} nestedModel - The nested model data to be merged into the form state.
			 */
			handleModelUpdate(nestedModel)
			{
				_forEach(nestedModel, (fldData, fldName) => Reflect.set(this.modelToSend.FormData, fldName, fldData))
			},

			/**
			 * Sets state data based on the model received from the backend.
			 * @param {Object} modelValue - The model data to be integrated into the component's state.
			 */
			setData(modelValue)
			{
				_assignIn(this.model, modelValue)

				this.controls.secondForm.supportForm = {
					name: this.model.partialViewJS,
					component: this.$route.params.component,
					mode: 'NEW',
					fnKeySelector: () => this.model.FormData.QPrimaryKey
				}

				this.controls.secondForm.formData = {
					id: this.model.FormData.QPrimaryKey,
					historyBranchId: this.navigationId,
					isNested: true,
					form: this.model.partialViewJS,
					component: this.$route.params.component,
					mode: 'NEW',
					modes: '',
					nestedModel: this.model.FormData
				}

				this.controls.secondForm.nestedFormConfig.uiComponents.header = false
				this.controls.secondForm.nestedFormConfig.uiComponents.headerButtons = false
				this.controls.secondForm.nestedFormConfig.uiComponents.footer = false
				this.controls.secondForm.Init(true)
			},

			/**
			 * Fetches initial registration data needed to set up the registration form.
			 * It calls the backend API and sets up form data based on the response.
			 */
			fetchData()
			{
				const params = {
					Form: this.$route.params.form,
					Pswform: this.$route.params.pswform,
					Id: this.$route.params.id
				}

				return this.netAPI.fetchData('Account', 'Register', params, (data) => this.setData(data))
			}
		}
	}
</script>
