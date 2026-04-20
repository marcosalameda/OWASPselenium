// @ts-expect-error -- types still WIP
import { getLayoutVariables } from '@quidgest/clientapp/utils/genericFunctions'
import { useSystemDataStore } from '@quidgest/clientapp/stores'

import layoutConfigJson from './assets/config/Layoutconfig.json'

export const systemInfo = {
	applicationName: 'Horizontal Layout - Vue',

	get genio() {
		// Access the store inside the getter to ensure Pinia is initialized
		const systemDataStore = useSystemDataStore()
		return systemDataStore.versionInfo
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

	isChatBotAvailable: false,

	isSuggestionsAvailable: true,

	isNotesAvailable: false,

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
		]
	},

	resourcesPath: 'Content/img/'
}
