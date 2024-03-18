<template>
	<div
		v-if="isVisible"
		ref="logonMenu"
		style="flex-grow: 1"
		:class="logonClasses">
		<div class="f-login">
			<div class="f-login__container">
				<div class="f-login__background">
					<div class="f-login__brand">
						<img
							:src="`${system.resourcesPath}f-login__brand.png`"
							:alt="texts.enter" />
						<p>{{ texts.appName }}</p>
					</div>

					<div id="login-container">
						<fieldset>
							<div class="form-flow">
								<div>
									<div
										v-for="value in model.OpenIdConnAuthMethods"
										:key="value">
										<q-button
											b-style="primary"
											block
											:class="['q-btn--login']"
											:title="value ? value : 'OpenId Connect Auth'"
											:label="value ? value : 'OpenId Connect Auth'"
											:loading="loading"
											@click="OpenIdConnAuthButtonClick(value)" />
									</div>

									<div
										v-for="value in model.CASAuthMethods"
										:key="value">
										<q-button
											b-style="primary"
											block
											:class="['q-btn--login']"
											:title="value ? value : 'CAS Protocol'"
											:label="value ? value : 'CAS Protocol'"
											:loading="loading"
											@click="CASAuthButtonClick(value)" />
									</div>

									<div
										v-for="value in model.CMDAuthMethods"
										:key="value">
										<q-button
											b-style="primary"
											block
											:class="['q-btn--login']"
											:title="value ? value : 'CMD Protocol'"
											:label="value ? value : 'CMD Protocol'"
											:loading="loading"
											@click="CMDAuthButtonClick(value)" />
									</div>
								</div>

								<template v-if="hasUsernameAuth">
									<hr
										v-if="
											!isEmpty(model.OpenIdConnAuthMethods) || !isEmpty(model.CASAuthMethods) || !isEmpty(model.CMDAuthMethods)
										" />

									<q-input-group
										size="block"
										:prepend-icon="{ icon: 'user' }"
										:class="{ error: userError }">
										<q-text-field
											v-model="currentUser"
											name="username"
											:placeholder="texts.user"
											@keyup.enter="executeLogon"
											@input="hideErrorMsg" />
									</q-input-group>

									<div
										v-if="returnMessage && showReturnMessage && returnMessage['UserName']"
										class="i-text__error">
										<q-icon icon="exclamation-sign" />
										{{ returnMessage['UserName'] }}
									</div>

									<q-input-group
										size="block"
										:prepend-icon="{ icon: 'password' }"
										:class="{ error: passError }">
										<q-text-field
											v-model="password"
											name="password"
											autocomplete="off"
											:placeholder="texts.password"
											:type="passwordFieldType"
											@keyup.enter="executeLogon"
											@focus="clearReturnMessage" />
										<template
											v-if="layoutConfig.ShowPasswordToggle"
											#append>
											<q-button
												b-style="secondary"
												@mousedown="showPassword"
												@mouseup="hidePassword"
												@mouseleave="hidePassword">
												<q-icon :icon="eyeIcon" />
											</q-button>
										</template>
									</q-input-group>

									<div
										v-if="returnMessage && showReturnMessage && returnMessage['Password']"
										class="i-text__error">
										<q-icon icon="exclamation-sign" />
										{{ returnMessage['Password'] }}
									</div>

									<!-- Returns the empty key when the message is not specific to one or another entry and is therefore displayed only once for all entries. -->
									<div
										v-if="genericError && showReturnMessage"
										class="i-text__error">
										<q-icon icon="exclamation-sign" />
										{{ genericError }}
									</div>

									<q-button
										id="login-btn"
										b-style="secondary"
										block
										borderless
										class="q-btn--login"
										:title="texts.enter"
										:label="texts.enter"
										:loading="loading"
										@click="executeLogon"
										@focus="clearReturnMessage" />
								</template>

								<div
									v-if="userRegistration.allowRegistration && userRegistration.registrationTypes.length > 0"
									id="register-btn">
									<q-router-link 
										v-if="userRegistration.registrationTypes.length === 1"
										id="link-register"
										:class="userRegisterClass"
										:link="{
											name: 'user-register',
											params: {
												id: userRegistration.registrationTypes[0].id,
												component: userRegistration.registrationTypes[0].component,
												form: userRegistration.registrationTypes[0].form,
												pswform: userRegistration.registrationTypes[0].pswForm
											}
										}">
										{{ texts.register }}
									</q-router-link>
									<div
										v-else
										class="dropleft">
										<a
											id="link-register"
											:class="userRegisterClass"
											data-toggle="dropdown"
											aria-haspopup="true"
											aria-expanded="false">
											{{ texts.register }}
										</a>

										<div
											class="dropdown-menu"
											aria-labelledby="link-register">
											<q-router-link
												v-for="regType in userRegistration.registrationTypes"
												:key="regType.designation"
												class="dropdown-item"
												:link="{
													name: 'user-register',
													params: {
														id: regType.id,
														component: regType.component,
														form: regType.form,
														pswform: regType.pswForm
													}
												}">
												{{ Resources[regType.designation] }}
											</q-router-link>
										</div>
									</div>
								</div>
							</div>

							<div
								v-if="hasPasswordRecovery"
								class="col-auto">
								<q-router-link
									class="f-login__link"
									:link="{
										name: 'password-recovery',
										params: { culture: system.currentLang }
									}">
									{{ texts.forgotPassword }}
								</q-router-link>
							</div>
						</fieldset>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
	import { computed } from 'vue'
	import { mapState } from 'pinia'

	import { useSystemDataStore } from '@/stores/systemData.js'
	import { postData, fetchData } from '@/api/network'
	import mainConfigUtils from '@/api/global/mainConfigUtils.js'
	import { resetStoreState } from '@/mixins/genericFunctions.js'
	import LayoutHandlers from '@/mixins/layoutHandlers.js'
	import AuthHandlers from '@/mixins/authHandlers.js'
	import hardcodedTexts from '@/hardcodedTexts.js'

	import QRouterLink from '@/views/shared/QRouterLink.vue'

	export default {
		name: 'LogOn',

		emits: ['set-visibility'],

		components: {
			QRouterLink
		},

		mixins: [LayoutHandlers, AuthHandlers],

		props: {
			/**
			 * Whether or not the control is currently visible.
			 */
			isVisible: {
				type: Boolean,
				default: true
			}
		},

		expose: [],

		data()
		{
			return {
				currentUser: '',

				password: '',

				returnMessage: '',

				generalMessage: '',

				isPasswordVisible: false,

				showReturnMessage: false,

				loading: false,

				model: {
					CASAuthMethods: [],
					CMDAuthMethods: [],
					OpenIdConnAuthMethods: [],
				},

				texts: {
					appName: computed(() => this.Resources[hardcodedTexts.appName]),
					user: computed(() => this.Resources[hardcodedTexts.user]),
					enter: computed(() => this.Resources[hardcodedTexts.enter]),
					register: computed(() => this.Resources[hardcodedTexts.register]),
					password: computed(() => this.Resources[hardcodedTexts.password]),
					forgotPassword: computed(() => this.Resources[hardcodedTexts.forgotPassword])
				}
			}
		},

		created()
		{
			fetchData('Account', 'LogOn', {}, this.loadedContent)
		},

		mounted()
		{
			if (
				this.layoutConfig.LoginStyle === 'embeded_page' ||
				(this.isPublicRoute && !this.isFullScreenPage)
			)
				window.addEventListener('mousedown', this.hideLogon)
		},

		beforeUnmount()
		{
			if (
				this.layoutConfig.LoginStyle === 'embeded_page' ||
				(this.isPublicRoute && !this.isFullScreenPage)
			)
				window.removeEventListener('mousedown', this.hideLogon)
		},

		computed: {
			...mapState(useSystemDataStore, ['userRegistration']),

			passwordFieldType()
			{
				return this.isPasswordVisible ? 'text' : 'password'
			},

			eyeIcon()
			{
				return this.isPasswordVisible ? 'password-hidden' : 'view'
			},

			userError()
			{
				return this.returnMessage && (this.returnMessage['UserName'] || this.returnMessage[''])
			},

			passError()
			{
				return this.returnMessage && (this.returnMessage['Password'] || this.returnMessage[''])
			},

			genericError()
			{
				if (this.returnMessage && this.returnMessage[''])
					return this.returnMessage['']
				return this.generalMessage
			},

			userRegisterClass()
			{
				return this.layoutConfig.UserRegisterStyle === 'button'
					? ['q-btn', 'q-btn--block']
					: ['f-login__link']
			},

			logonClasses()
			{
				var classes = ['d-block']

				if (
					this.layoutConfig.LoginStyle === 'embeded_page' ||
					(this.isPublicRoute && !this.isFullScreenPage)
				)
				{
					classes.push('log-on-container')
					classes.push('dropdown-menu')
					classes.push('dropdown-menu-right')
					classes.push('c-user__dropdown')
				}

				if (this.layoutConfig.AuthenticationStyle === 'light')
					classes.push('layout-light')
				else if (this.layoutConfig.AuthenticationStyle === 'secondary')
					classes.push('layout-secondary')

				return classes
			}
		},

		methods: {
			async executeLogon()
			{
				if(this.loading) return
				this.loading = true

				const params = {
					ReturnUrl: '',
					UserName: this.currentUser,
					Password: this.password
				}


				await postData('Account', 'LogOn', params, this.loginSuccess)
				this.loading = false
			},

			loginSuccess(data)
			{
				this.generalMessage = data.Message
				this.showReturnMessage = true
				this.returnMessage = data.Errors

				if (data.Success) { 
					if (data.Auth2FA && !data.Val2FA) {
						if (data.User.Auth2FATp === 'TOTP')
							this.confirmBox2FA(data)
						else if (data.User.Auth2FATp === 'WebAuth')
							this.handleSignInWebAuth(data)
					}
					else
						this.finalizeLogin(data)
				}
				else if (this.password.length > 0)
					this.password = ''

			},
			finalizeLogin(data)
			{
				this.returnMessage = data.Errors
				this.generalMessage = data.Message
				this.showReturnMessage = true

				if (data.Success) {
					resetStoreState()

					Promise.all([
						mainConfigUtils.updateAFToken(),
						mainConfigUtils.updateMainConfig()
					]).then(() => {
						const userData = {
							Name: this.currentUser
						}
						this.setUserData(userData)

						const routeParams = {
							name: 'home',
							params: {
								culture: this.system.defaultLang,
								system: this.system.defaultSystem,
								module: this.system.defaultModule
							}
						}
						this.$router.push(routeParams)
					})
				}
				else if (this.password.length > 0)
					this.password = ''
			},

			clearReturnMessage()
			{
				this.showReturnMessage = false
			},

			confirmBox2FA()
			{
				let code = prompt("Input 6 digit code");
				if (code !== null) {
					const params = {
						ReturnUrl: '',
						UserName: this.currentUser,
						Password: code,
					}

					postData('Account', 'Authentication2FA', params, this.finalizeLogin);
				}
			},

			handleSignInWebAuth()
			{
				// TODO
			},

			showPassword()
			{
				this.isPasswordVisible = true
			},

			hidePassword()
			{
				this.isPasswordVisible = false
			},

			setLogonVisibility(isVisible)
			{
				this.$emit('set-visibility', isVisible)
			},

			hideErrorMsg()
			{
				if (this.returnMessage.length > 0)
					this.returnMessage = ''
			},

			hideLogon(event)
			{
				if (!this.isVisible)
					return

				let el = this.$refs.logonMenu
				let target = event.target

				if (el && el !== target && !el.contains(target))
					this.setLogonVisibility(false)
			},

			loadedContent(data)
			{
				if (this.isEmpty(data))
					return

				// Update the store data
				this.setPasswordRecovery(data.HasPasswordRecovery)
				this.setUsernameAuth(data.HasUsernameAuth)
				this.setOpenIdAuth(data.OpenIdConnAuthMethods?.length > 0)

				this.model.OpenIdConnAuthMethods = data.OpenIdConnAuthMethods
				this.model.CMDAuthMethods = data.CMDAuthMethods
				this.model.CASAuthMethods = data.CASAuthMethods
			}
		}
	}
</script>
