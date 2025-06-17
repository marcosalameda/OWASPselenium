// @ts-expect-error genericFunctions does not export type definitions yet
import { getLayoutVariables } from '@quidgest/clientapp/utils/genericFunctions'

import layoutConfigJson from './assets/config/Layoutconfig.json'

export const systemInfo = {
	applicationName: 'Horizontal Layout - Vue',

	genio: {
		buildVersion: 2931,
		dbIdxVersion: 1731,
		dbVersion: '4062',
		genioVersion: '370,19',
		trackChangesVersion: '0',
		assemblyVersion: '370,19.4062.0.2931',
		generationDate: {
			year: 2025,
			month: 6,
			day: 17
		}
	},

	system: {
		acronym: 'QUIDVUE',
		name: 'Quidgest - Vue.js',
		baseCurrency: {
			symbol: '€',
			code: 'EUR',
			precision: 2
		}
	},

	locale: {
		defaultLocale: 'en-US',
		availableLocales: [
			{
				language: 'en-US',
				acronym: 'EN',
				displayName: 'English'
			},
			{
				language: 'pt-PT',
				acronym: 'PT',
				displayName: 'Português'
			},
		]
	},

	// FIXME: This should be the generator's responsibility, not the client app.
	layout: getLayoutVariables(layoutConfigJson),

	authConfig: {
		useCertificate: false,
		maxUsrSize: 100,
		maxPswSize: 150
	},

	cookies: {
		cookieText: '',
		cookieActive: false,
		filePath: ''
	},

	isCavAvailable: true,

	isChatBotAvailable: true,

	isSuggestionsAvailable: true,

	appAlerts: [
		{
			id: 'NCARDSDANGER',
			module: 'STY',
			tag: '{STY_OVERVIEW_Count}',
			title: 'THERE_ARE__STY_OVERV27174',
			description: '_STY_OVERVIEW_COUNT_30342',
			isResource: true,
			isDismissible: true,
			disableIfLowerThan: 0,
		},
		{
			id: 'NCARDSWARNING',
			module: 'STY',
			tag: '{STY_OVERVIEW_Count}',
			title: 'THERE_ARE__STY_OVERV27174',
			description: '_STY_OVERVIEW_COUNT_30342',
			isResource: true,
			isDismissible: true,
			disableIfLowerThan: 0,
		},
		{
			id: 'NCARDSINFO',
			module: 'STY',
			tag: '{STY_OVERVIEW_Count}',
			title: 'THERE_ARE__STY_OVERV27174',
			description: '_STY_OVERVIEW_COUNT_30342',
			isResource: true,
			isDismissible: true,
			disableIfLowerThan: 0,
		},
		{
			id: 'DEVOLUCAO',
			module: 'GQT',
			tag: '{GQT_DEVOL_Count}',
			title: '_GQT_DEVOL_COUNT__TO39432',
			description: '_GQT_DEVOL_COUNT__TO39432',
			isResource: true,
			isDismissible: true,
			disableIfLowerThan: -1,
		},
		{
			id: 'NCARDSSUCESS',
			module: 'STY',
			tag: '{STY_OVERVIEW_Count}',
			title: 'THERE_ARE__STY_OVERV27174',
			description: '_STY_OVERVIEW_COUNT_30342',
			isResource: true,
			isDismissible: true,
			disableIfLowerThan: 0,
		},
	],

	userRegistration: {
		allowRegistration: true,
		registrationTypes: [
			{
				id: '38736086-6c5c-4d7c-868b-99965d00f117',
				designation: 'REGISTO48087',
				component: 'QFormRegis',
				form: 'Regis',
				pswForm: 'Defaultpsw',
				PswComponent: 'QFormAccountInfo'
			},
		]
	},

	resourcesPath: 'Content/img/'
}
