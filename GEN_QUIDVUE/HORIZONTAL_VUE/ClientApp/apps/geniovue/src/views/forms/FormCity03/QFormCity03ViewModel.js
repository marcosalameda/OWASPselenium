/* eslint-disable @typescript-eslint/no-unused-vars */
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
/* eslint-enable @typescript-eslint/no-unused-vars */

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
	// eslint-disable-next-line @typescript-eslint/no-unused-vars
	constructor(vueContext, options, values)
	{
		super(vueContext, options)
		// eslint-disable-next-line @typescript-eslint/no-unused-vars
		const vm = this.vueContext

		// The view model metadata
		_merge(this.modelInfo, {
			name: 'CITY03',
			area: 'CITY',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_City03',
				updateFilesTickets: 'UpdateFilesTicketsCity03',
				setFile: 'SetFileCity03'
			}
		})

		/** The primary key. */
		this.ValCodcity = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcity',
			originId: 'ValCodcity',
			area: 'CITY',
			field: 'CODCITY',
			description: '',
		}).cloneFrom(values?.ValCodcity))
		this.stopWatchers.push(watch(() => this.ValCodcity.value, (newValue, oldValue) => this.onUpdate('city.codcity', this.ValCodcity, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodctry = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodctry',
			originId: 'ValCodctry',
			area: 'CITY',
			field: 'CODCTRY',
			relatedArea: 'CTRY',
			description: computed(() => this.Resources.COUNTRY64133),
		}).cloneFrom(values?.ValCodctry))
		this.stopWatchers.push(watch(() => this.ValCodctry.value, (newValue, oldValue) => this.onUpdate('city.codctry', this.ValCodctry, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValCity = reactive(new modelFieldType.String({
			id: 'ValCity',
			originId: 'ValCity',
			area: 'CITY',
			field: 'CITY',
			maxLength: 50,
			description: computed(() => this.Resources.CITY42505),
		}).cloneFrom(values?.ValCity))
		this.stopWatchers.push(watch(() => this.ValCity.value, (newValue, oldValue) => this.onUpdate('city.city', this.ValCity, newValue, oldValue)))

		this.TableCtryCountry = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCtryCountry',
			originId: 'ValCountry',
			area: 'CTRY',
			field: 'COUNTRY',
			maxLength: 50,
			description: computed(() => this.Resources.COUNTRY64133),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableCtryCountry))
		this.stopWatchers.push(watch(() => this.TableCtryCountry.value, (newValue, oldValue) => this.onUpdate('ctry.country', this.TableCtryCountry, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormCity03ViewModel instance.
	 * @returns {QFormCity03ViewModel} A new instance of QFormCity03ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcity'

	get QPrimaryKey() { return this.ValCodcity.value }
	set QPrimaryKey(value) { this.ValCodcity.updateValue(value) }
}
