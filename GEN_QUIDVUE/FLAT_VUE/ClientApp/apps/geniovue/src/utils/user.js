import { postData } from '@/api/network'
import eventBus from '@/api/global/eventBus.js'
import mainConfigUtils from '@/api/global/mainConfigUtils.js'
import { resetStoreState } from '@/mixins/genericFunctions.js'

/**
 * Resets the application state and navigates the user to the main route
 * after a successful logout.
 */
function logOffSuccess()
{
	resetStoreState()

	Promise.all([
		mainConfigUtils.updateAFToken(),
		mainConfigUtils.updateMainConfig()
	]).then(() => {
		eventBus.emit('go-to-route', { name: 'main', params: { isControlled: true }})
	})
}

/**
 * Initiates a server request to log out the user and, upon success,
 * calls the logOffSuccess function to handle post-logout actions.
 */
export function logOff()
{
	postData('Account', 'LogOff', {}, logOffSuccess)
}

export default {
	logOff
}
