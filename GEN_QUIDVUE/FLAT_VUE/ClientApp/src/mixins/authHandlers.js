import { mapState, mapActions } from 'pinia'

import { useAuthDataStore } from '@/stores/authData.js'
import { useUserDataStore } from '@/stores/userData.js'

/***************************************************************************
 * This mixin defines methods to be reused in authentication components.   *
 ***************************************************************************/
export default {
	computed: {
		...mapState(useAuthDataStore, [
			'hasPasswordRecovery',
			'hasUsernameAuth',
			'hasUserSettings'
		]),

		userData()
		{
			const userDataStore = useUserDataStore()

			return {
				name: userDataStore.username
			}
		}
	},

	methods: {
		...mapActions(useUserDataStore, [
			'setUserData'
		]),

		...mapActions(useAuthDataStore, [
			'setPasswordRecovery',
			'setUsernameAuth',
			'setOpenIdAuth',
			'set2FAOptions'
		]),

		AuthRedirectButtonClick(data) {
			window.location.href = data.Redirect;
		}

	}
}
