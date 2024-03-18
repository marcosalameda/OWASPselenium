import isEmpty from 'lodash-es/isEmpty'

import { useSystemDataStore } from '@/stores/systemData.js'

/**
 * Retrieves app alert information based on the provided ID.
 *
 * @param {string} id - The ID of the app alert to retrieve.
 * @returns {Object|undefined} - The app alert information or undefined if not found.
 */
export function getAppAlert(id)
{
	const systemDataStore = useSystemDataStore()

	const appAlert = systemDataStore.appAlerts.find((alert) => alert.id === id)

	if (isEmpty(appAlert.module) || appAlert.module === systemDataStore.system.currentModule)
		return appAlert

	return undefined
}

/**
 * Hydrates alert data based on provided information.
 *
 * @param {Object} data - The data object containing information about the alert.
 * @returns {Object|undefined} - The hydrated alert object or undefined if the alert is not valid.
 */
export function hydrateAlert(data)
{
	const appAlert = getAppAlert(data.Idalert)

	if (appAlert && data.Count > appAlert.disableIfLowerThan)
	{
		const alert = { ...appAlert }

		// TODO: generate to systemData store if static
		alert.type = data.Type
		// TODO: generate to systemData store
		alert.target = data.Target

		if (!appAlert.isResource)
		{
			alert.title = data.Title
			alert.description = data.Content
		}
		else
		{
			alert.count = data.Count
		}

		return alert
	}

	return undefined
}
