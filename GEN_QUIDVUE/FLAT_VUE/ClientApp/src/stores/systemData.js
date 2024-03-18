/*****************************************************************
 *                                                               *
 * This store holds generated data. Most of that data should     *
 * only be accessed, never mutated.                              *
 *                                                               *
 *****************************************************************/

import { defineStore } from 'pinia'

//----------------------------------------------------------------
// State variables
//----------------------------------------------------------------

const state = () => {
	return {
		applicationName: 'Vertical layout - Vue',

		genio: {
			buildVersion: 2678,
			dbIdxVersion: 1159,
			dbVersion: '3510',
			genioVersion: '341,06',
			trackChangesVersion: '0',
			assemblyVersion: '341,06.3510.0.2678',
			generationDate: {
				year: 2024,
				month: 3,
				day: 18
			}
		},

		system: {
			acronym: 'QUIDVUE',
			name: 'Quidgest - Vue.js',
			defaultSystem: '',
			currentSystem: '',
			availableSystems: [],
			defaultLang: 'en-US',
			currentLang: 'en-US',
			supportedLangs: [
				{
					language: 'en-US',
					acronym: 'EN',
					languageName: 'English'
				},
			],
			defaultModule: 'Public',
			currentModule: 'Public',
			availableModules: {},
			defaultListRows: 0,
			dateFormat: {
				Date: 'dd/MM/yyyy',
				DateTime: 'dd/MM/yyyy HH:mm',
				DateTimeSeconds: 'dd/MM/yyyy HH:mm:ss',
				Time: 'HH:mm'
			},
			baseCurrency: {
				symbol: '€',
				code: 'EUR',
				precision: 2
			},
			resourcesPath: 'Content/img/',
			schedulerLicense: undefined
		},

		authConfig: {
			useCertificate: false,
			maxUsrSize: 100,
			maxPswSize: 150
		},

		isCavAvailable: true,

		isChatBotAvailable: false,

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
			]
		}
	}
}

//----------------------------------------------------------------
// Actions
//----------------------------------------------------------------

const actions = {
	/**
	 * Sets the available systems.
	 * @param {string} availableSystems The available systems
	 */
	setAvailableSystems(availableSystems)
	{
		if (Array.isArray(availableSystems) === false)
			return
		if (this.system.availableSystems === availableSystems)
			return

		this.system.availableSystems = availableSystems
	},

	/**
	 * Sets the default system.
	 * @param {string} defaultSystem The default system
	 */
	setDefaultSystem(defaultSystem)
	{
		if (typeof defaultSystem !== 'string' || defaultSystem.length === 0)
			return
		if (this.system.defaultSystem === defaultSystem)
			return

		this.system.defaultSystem = defaultSystem
	},

	/**
	 * Sets the currently selected system.
	 * @param {string} currentSystem The current system
	 */
	setCurrentSystem(currentSystem)
	{
		if (typeof currentSystem !== 'string' || currentSystem.length === 0)
			return
		if (this.system.currentSystem === currentSystem)
			return
		if (!this.system.availableSystems.includes(currentSystem))
			return

		this.system.currentSystem = currentSystem
	},

	/**
	 * Sets the available modules.
	 * @param {object} availableModules The available modules
	 */
	setAvailableModules(availableModules)
	{
		if (typeof availableModules !== 'object' || availableModules === null)
			return

		this.system.availableModules = availableModules
	},

	/**
	 * Sets the default module.
	 * @param {string} module The default module
	 */
	setDefaultModule(module)
	{
		if (typeof module !== 'string' || module.length === 0)
			return
		if (this.system.defaultModule === module)
			return
		if (!this.system.availableModules[module] && module !== 'Public')
			return

		this.system.defaultModule = module
	},

	/**
	 * Sets the currently selected module.
	 * @param {string} module The current module
	 */
	setCurrentModule(module)
	{
		if (typeof module !== 'string' || module.length === 0)
			return
		if (this.system.currentModule === module)
			return
		if (this.system.availableModules[module] === undefined && module !== 'Public')
			return

		this.system.currentModule = module
	},

	/**
	 * Sets the currently selected language.
	 * @param {string} lang The current language
	 */
	setCurrentLang(lang)
	{
		if (typeof lang !== 'string' || lang.length === 0)
			return
		if (this.system.currentLang === lang)
			return
		if (!this.system.supportedLangs.find(obj => obj.language === lang))
			return

		this.system.currentLang = lang
	},

	/**
	 * Sets the default number of rows for lists.
	 * @param {number} rowsNum The number of rows
	 */
	setDefaultListRows(rowsNum)
	{
		if (typeof rowsNum !== 'number')
			return
		if (this.system.defaultListRows === rowsNum)
			return

		this.system.defaultListRows = rowsNum
	},

	/**
	 * Sets the format used by date inputs in the application.
	 * @param {object} dateFormat The formats of the dates
	 */
	setDateFormat(dateFormat)
	{
		if (typeof dateFormat !== 'object' || dateFormat === null)
			return
		if (!dateFormat.Date && !dateFormat.DateTime && !dateFormat.DateTimeSeconds && !dateFormat.Time)
			return

		for (let i in dateFormat)
			this.system.dateFormat[i] = dateFormat[i]
	},

	/**
	 * Sets the scheduler license key to use premium features of the Full Calendar.
	 * @param {string} schedulerLicenseKey The the license key
	 */
	setSchedulerLicenseKey(schedulerLicenseKey)
	{
		if (typeof schedulerLicenseKey !== 'string')
			return

		this.system.schedulerLicense = schedulerLicenseKey
	},

	/**
	 * Resets the system data.
	 */
	resetStore()
	{
		Object.assign(this, state())
	}
}

//----------------------------------------------------------------
// Store export
//----------------------------------------------------------------

export const useSystemDataStore = defineStore('systemData', {
	state,
	actions
})
