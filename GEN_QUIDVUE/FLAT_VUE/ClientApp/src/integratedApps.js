
/**
 * All External apps
 */
const allExternalApp = [
]

const allParentRoute = [
]

export function setExternalAppsPlugin(appContext, router)
{
	for (const app of allExternalApp)
	{
		if (app.hasInternalRouter)
		{
			let params = app.parameters
			params['router'] = router
			params['parent'] = allParentRoute
			appContext.use(app.appPackage, params)
		}
		else
			appContext.use(app.appPackage, app.parameters)
	}
}
