/* eslint-disable no-unused-vars */
import { computed, reactive, watch } from 'vue'
import _merge from 'lodash-es/merge'

import FormViewModelBase from '@/mixins/formViewModelBase.js'
import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
import modelFieldType from '@quidgest/clientapp/models/fields'

import hardcodedTexts from '@/hardcodedTexts.js'
import netAPI from '@quidgest/clientapp/network'
import qApi from '@/api/genio/quidgestFunctions.js'
import qFunctions from '@/api/genio/projectFunctions.js'
import qProjArrays from '@/api/genio/projectArrays.js'
/* eslint-enable no-unused-vars */

/**
 * Represents a ViewModel class.
 * @extends FormViewModelBase
 */
export default class ViewModel extends FormViewModelBase
{
	/**
	 * Creates a new instance of the ViewModel.
	 * @param {object} vueContext - The Vue context
	 * @param {object} options - The options for the ViewModel
	 * @param {object} values - A ViewModel instance to copy values from
	 */
	// eslint-disable-next-line no-unused-vars
	constructor(vueContext, options, values)
	{
		super(vueContext, options)
		// eslint-disable-next-line no-unused-vars
		const vm = this.vueContext

		// The view model metadata
		_merge(this.modelInfo, {
			name: 'PROPE11',
			area: 'PROPE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Prope11',
				updateFilesTickets: 'UpdateFilesTicketsPrope11',
				setFile: 'SetFilePrope11'
			}
		})

		/** The primary key. */
		this.ValCodprope = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodprope',
			originId: 'ValCodprope',
			area: 'PROPE',
			field: 'CODPROPE',
			description: '',
		}).cloneFrom(values?.ValCodprope))
		this.stopWatchers.push(watch(() => this.ValCodprope.value, (newValue, oldValue) => this.onUpdate('prope.codprope', this.ValCodprope, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodcity = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcity',
			originId: 'ValCodcity',
			area: 'PROPE',
			field: 'CODCITY',
			relatedArea: 'CITY',
			description: computed(() => this.Resources.CITY42505),
		}).cloneFrom(values?.ValCodcity))
		this.stopWatchers.push(watch(() => this.ValCodcity.value, (newValue, oldValue) => this.onUpdate('prope.codcity', this.ValCodcity, newValue, oldValue)))

		this.ValCodagent = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodagent',
			originId: 'ValCodagent',
			area: 'PROPE',
			field: 'CODAGENT',
			relatedArea: 'AGENT',
			description: '',
		}).cloneFrom(values?.ValCodagent))
		this.stopWatchers.push(watch(() => this.ValCodagent.value, (newValue, oldValue) => this.onUpdate('prope.codagent', this.ValCodagent, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValPhoto = reactive(new modelFieldType.Image({
			id: 'ValPhoto',
			originId: 'ValPhoto',
			area: 'PROPE',
			field: 'PHOTO',
			description: computed(() => this.Resources.MAIN_PHOTO18723),
		}).cloneFrom(values?.ValPhoto))
		this.stopWatchers.push(watch(() => this.ValPhoto.value, (newValue, oldValue) => this.onUpdate('prope.photo', this.ValPhoto, newValue, oldValue)))

		this.ValTitle = reactive(new modelFieldType.String({
			id: 'ValTitle',
			originId: 'ValTitle',
			area: 'PROPE',
			field: 'TITLE',
			maxLength: 50,
			description: computed(() => this.Resources.TITLE21885),
		}).cloneFrom(values?.ValTitle))
		this.stopWatchers.push(watch(() => this.ValTitle.value, (newValue, oldValue) => this.onUpdate('prope.title', this.ValTitle, newValue, oldValue)))

		this.ValPrice = reactive(new modelFieldType.Number({
			id: 'ValPrice',
			originId: 'ValPrice',
			area: 'PROPE',
			field: 'PRICE',
			maxDigits: 9,
			decimalDigits: 2,
			description: computed(() => this.Resources.PRICE06900),
		}).cloneFrom(values?.ValPrice))
		this.stopWatchers.push(watch(() => this.ValPrice.value, (newValue, oldValue) => this.onUpdate('prope.price', this.ValPrice, newValue, oldValue)))

		this.ValDescript = reactive(new modelFieldType.MultiLineString({
			id: 'ValDescript',
			originId: 'ValDescript',
			area: 'PROPE',
			field: 'DESCRIPT',
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescript))
		this.stopWatchers.push(watch(() => this.ValDescript.value, (newValue, oldValue) => this.onUpdate('prope.descript', this.ValDescript, newValue, oldValue)))

		this.TableCityCity = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCityCity',
			originId: 'ValCity',
			area: 'CITY',
			field: 'CITY',
			maxLength: 50,
			description: computed(() => this.Resources.CITY42505),
		}).cloneFrom(values?.TableCityCity))
		this.stopWatchers.push(watch(() => this.TableCityCity.value, (newValue, oldValue) => this.onUpdate('city.city', this.TableCityCity, newValue, oldValue)))

		this.CityCtryValCountry = reactive(new modelFieldType.String({
			id: 'CityCtryValCountry',
			originId: 'ValCountry',
			area: 'CTRY',
			field: 'COUNTRY',
			maxLength: 50,
			isFixed: true,
			description: computed(() => this.Resources.COUNTRY64133),
		}).cloneFrom(values?.CityCtryValCountry))
		this.stopWatchers.push(watch(() => this.CityCtryValCountry.value, (newValue, oldValue) => this.onUpdate('ctry.country', this.CityCtryValCountry, newValue, oldValue)))

		this.ValBuildtyp = reactive(new modelFieldType.String({
			id: 'ValBuildtyp',
			originId: 'ValBuildtyp',
			area: 'PROPE',
			field: 'BUILDTYP',
			maxLength: 1,
			arrayOptions: computed(() => new qProjArrays.QArrayBuildtyp(vm.$getResource).elements),
			description: computed(() => this.Resources.BUILDING_TYPE57152),
		}).cloneFrom(values?.ValBuildtyp))
		this.stopWatchers.push(watch(() => this.ValBuildtyp.value, (newValue, oldValue) => this.onUpdate('prope.buildtyp', this.ValBuildtyp, newValue, oldValue)))

		this.ValTypology = reactive(new modelFieldType.Number({
			id: 'ValTypology',
			originId: 'ValTypology',
			area: 'PROPE',
			field: 'TYPOLOGY',
			maxDigits: 1,
			decimalDigits: 0,
			arrayOptions: computed(() => new qProjArrays.QArrayAparttyp(vm.$getResource).elements),
			description: computed(() => this.Resources.TYPOLOGY11991),
		}).cloneFrom(values?.ValTypology))
		this.stopWatchers.push(watch(() => this.ValTypology.value, (newValue, oldValue) => this.onUpdate('prope.typology', this.ValTypology, newValue, oldValue)))

		this.ValSize = reactive(new modelFieldType.Number({
			id: 'ValSize',
			originId: 'ValSize',
			area: 'PROPE',
			field: 'SIZE',
			maxDigits: 15,
			decimalDigits: 0,
			description: computed(() => this.Resources.SIZE__M2_57059),
		}).cloneFrom(values?.ValSize))
		this.stopWatchers.push(watch(() => this.ValSize.value, (newValue, oldValue) => this.onUpdate('prope.size', this.ValSize, newValue, oldValue)))

		this.ValBathrms = reactive(new modelFieldType.Number({
			id: 'ValBathrms',
			originId: 'ValBathrms',
			area: 'PROPE',
			field: 'BATHRMS',
			maxDigits: 2,
			decimalDigits: 0,
			description: computed(() => this.Resources.NUMBER_OF_BATHROOMS64857),
		}).cloneFrom(values?.ValBathrms))
		this.stopWatchers.push(watch(() => this.ValBathrms.value, (newValue, oldValue) => this.onUpdate('prope.bathrms', this.ValBathrms, newValue, oldValue)))

		this.ValYear = reactive(new modelFieldType.String({
			id: 'ValYear',
			originId: 'ValYear',
			area: 'PROPE',
			field: 'YEAR',
			maxLength: 50,
			description: computed(() => this.Resources.YEAR_BUILT55277),
		}).cloneFrom(values?.ValYear))
		this.stopWatchers.push(watch(() => this.ValYear.value, (newValue, oldValue) => this.onUpdate('prope.year', this.ValYear, newValue, oldValue)))

		this.TableAgentName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableAgentName',
			originId: 'ValName',
			area: 'AGENT',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TableAgentName))
		this.stopWatchers.push(watch(() => this.TableAgentName.value, (newValue, oldValue) => this.onUpdate('agent.name', this.TableAgentName, newValue, oldValue)))

		this.AgentValEmail = reactive(new modelFieldType.String({
			id: 'AgentValEmail',
			originId: 'ValEmail',
			area: 'AGENT',
			field: 'EMAIL',
			maxLength: 50,
			maskType: 'EM',
			isFixed: true,
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.AgentValEmail))
		this.stopWatchers.push(watch(() => this.AgentValEmail.value, (newValue, oldValue) => this.onUpdate('agent.email', this.AgentValEmail, newValue, oldValue)))

		this.AgentValPhoto = reactive(new modelFieldType.Image({
			id: 'AgentValPhoto',
			originId: 'ValPhoto',
			area: 'AGENT',
			field: 'PHOTO',
			isFixed: true,
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.AgentValPhoto))
		this.stopWatchers.push(watch(() => this.AgentValPhoto.value, (newValue, oldValue) => this.onUpdate('agent.photo', this.AgentValPhoto, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormPrope11ViewModel instance.
	 * @returns {QFormPrope11ViewModel} A new instance of QFormPrope11ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodprope'

	get QPrimaryKey() { return this.ValCodprope.value }
	set QPrimaryKey(value) { this.ValCodprope.updateValue(value) }
}
