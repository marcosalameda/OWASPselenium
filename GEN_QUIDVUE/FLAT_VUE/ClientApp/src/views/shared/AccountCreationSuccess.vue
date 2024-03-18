<template>
	<div class="f-login">
		<div class="f-login__container">
			<div class="f-login__background">
				<div class="f-login__brand">
					<img
						:src="`${system.resourcesPath}f-login__brand.png`"
						alt="" />
					<p>{{ texts.appName }}</p>
				</div>

				<h2>{{ texts.accountCreated }}</h2>

				<p>{{ texts.thanksForRegister }}</p>

				<q-router-link
					class="f-login__link"
					:link="{ name: 'main' }">
					{{ texts.backToLogin }}
				</q-router-link>
			</div>
		</div>
	</div>
</template>

<script>
	import { computed } from 'vue'
	import { mapState } from 'pinia'

	import { useSystemDataStore } from '@/stores/systemData.js'
	import hardcodedTexts from '@/hardcodedTexts.js'

	import QRouterLink from '@/views/shared/QRouterLink.vue'

	export default {
		name: 'AccountCreationSuccess',

		components: {
			QRouterLink
		},

		expose: [],

		data()
		{
			return {
				texts: {
					appName: computed(() => this.Resources[hardcodedTexts.appName]),
					accountCreated: computed(() => this.Resources[hardcodedTexts.accountCreated]),
					thanksForRegister: computed(() => this.Resources[hardcodedTexts.thanksForRegister]),
					backToLogin: computed(() => this.Resources[hardcodedTexts.backToLogin])
				}
			}
		},

		computed: {
			...mapState(useSystemDataStore, [
				'system'
			])
		}
	}
</script>
