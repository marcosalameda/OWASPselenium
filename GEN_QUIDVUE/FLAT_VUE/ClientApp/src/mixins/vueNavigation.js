import _assignIn from 'lodash-es/assignIn'

import { useSystemDataStore } from '@/stores/systemData.js'
import { postData, forceDownload } from '@/api/network'
import eventBus from '@/api/global/eventBus.js'

export default {
	methods: {
		navigateToRouteName(routeName, options, query, prefillValues)
		{
			navigateToRouteName(this, routeName, options, query, prefillValues)
		},

		navigateToForm(form, mode, id, options, query, prefillValues)
		{
			navigateToForm(this, form, mode, id, options, query, prefillValues)
		},

		navigateToModule(module)
		{
			navigateToModule(this, module)
		},

		navigateToReport(controller, action, options, preview)
		{
			navigateToReport(this, controller, action, options, preview)
		},

		navigateToReportingServicesViewer(controller, action, options)
		{
			navigateToReportingServicesViewer(this, controller, action, options)
		}
	}
}

export function navigateToRouteName(vueInstance, routeName, options, query, prefillValues)
{
	const systemDataStore = useSystemDataStore()
	const culture = systemDataStore.system.currentLang
	const system = systemDataStore.system.currentSystem
	const module = systemDataStore.system.currentModule

	const params = _assignIn({ culture, system, module }, {
		historyBranchId: vueInstance.navigationId
	}, options, { prefillValues: JSON.stringify(prefillValues) })

	vueInstance.$router.push({ name: routeName, params, query })
}

export function navigateToForm(vueInstance, form, mode, id, options, query, prefillValues)
{
	const params = _assignIn({ mode }, id ? { id } : {}, options),
		formRouteName = `form-${form}`

	navigateToRouteName(vueInstance, formRouteName, params, query, prefillValues)
}

export function navigateToModule(vueInstance, module)
{
	navigateToRouteName(vueInstance, `home-${module}`, { module })
}

export function navigateToReport(vueInstance, controller, action, options, preview)
{
	postData(controller, action, options, (_, request) => {
		const fileName = request.headers.filename
		const fileType = request.headers['content-type']
		if (!fileName)
			return

		forceDownload(request.data, fileName, fileType, preview)
	},
	() => {},
	{ responseType: 'arraybuffer' }, vueInstance.navigationId)
}

export function navigateToReportingServicesViewer(vueInstance, controller, action, options)
{
	postData(controller, action, options, (data) => {
		if (data?.id)
			navigateToRouteName(vueInstance, 'reporting-services-viewer', { id: data.id })
	},
	() => {},
	undefined, vueInstance.navigationId)
}

export function processRedirect(vueInstance, data)
{
	switch (data.type)
	{
		case 'menu':
			navigateToRouteName(vueInstance, `menu-${data.menuId}`, data.routeValues)
			break
		case 'menu-mc':
			eventBus.emit(`EXEC-${data.menuId}`, (data.routeValues || {}))
			break
		case 'menu-routine':
			eventBus.emit(`EXEC-MENU-ROUTINE-${data.menuId}`, { routineName: data.routineName, params: data.routeValues })
			break
		case 'form':
			{
				const params = _assignIn({ isControlled: true }, data.routeValues || {})
				navigateToForm(vueInstance, data.formName, data.formMode, null, params)
			}
			break
		case 'route':
			navigateToRouteName(vueInstance, data.routeName, data.routeValues)
			break
		default:
			/* log error */
			vueInstance.$eventTracker.addError({ origin: 'processRedirect', message: 'Error found while redirecting!', contextData: { type: data.type } })
	}
}

export const vueNavigation = {
	navigateToRouteName,
	navigateToForm,
	navigateToModule,
	navigateToReport,
	navigateToReportingServicesViewer,
	processRedirect
}
