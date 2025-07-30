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
			name: 'PROPPAIS',
			area: 'CNTRY',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Proppais',
				updateFilesTickets: 'UpdateFilesTicketsProppais',
				setFile: 'SetFileProppais'
			}
		})

		/** The primary key. */
		this.ValCodcntry = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcntry',
			originId: 'ValCodcntry',
			area: 'CNTRY',
			field: 'CODCNTRY',
			description: '',
		}).cloneFrom(values?.ValCodcntry))
		this.stopWatchers.push(watch(() => this.ValCodcntry.value, (newValue, oldValue) => this.onUpdate('cntry.codcntry', this.ValCodcntry, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValCountry = reactive(new modelFieldType.String({
			id: 'ValCountry',
			originId: 'ValCountry',
			area: 'CNTRY',
			field: 'COUNTRY',
			maxLength: 90,
			description: computed(() => this.Resources.COUNTRY64133),
		}).cloneFrom(values?.ValCountry))
		this.stopWatchers.push(watch(() => this.ValCountry.value, (newValue, oldValue) => this.onUpdate('cntry.country', this.ValCountry, newValue, oldValue)))

		this.ValActive = reactive(new modelFieldType.Boolean({
			id: 'ValActive',
			originId: 'ValActive',
			area: 'CNTRY',
			field: 'ACTIVE',
			description: computed(() => this.Resources.ACTIVE03270),
		}).cloneFrom(values?.ValActive))
		this.stopWatchers.push(watch(() => this.ValActive.value, (newValue, oldValue) => this.onUpdate('cntry.active', this.ValActive, newValue, oldValue)))

		this.ValCodigonr = reactive(new modelFieldType.String({
			id: 'ValCodigonr',
			originId: 'ValCodigonr',
			area: 'CNTRY',
			field: 'CODIGONR',
			maxLength: 3,
			description: computed(() => this.Resources.NUMERIC_ISO_316620341),
		}).cloneFrom(values?.ValCodigonr))
		this.stopWatchers.push(watch(() => this.ValCodigonr.value, (newValue, oldValue) => this.onUpdate('cntry.codigonr', this.ValCodigonr, newValue, oldValue)))

		this.ValAlfa2 = reactive(new modelFieldType.String({
			id: 'ValAlfa2',
			originId: 'ValAlfa2',
			area: 'CNTRY',
			field: 'ALFA2',
			maxLength: 2,
			description: computed(() => this.Resources.ALPHABETIC_232435),
		}).cloneFrom(values?.ValAlfa2))
		this.stopWatchers.push(watch(() => this.ValAlfa2.value, (newValue, oldValue) => this.onUpdate('cntry.alfa2', this.ValAlfa2, newValue, oldValue)))

		this.ValAlfa3 = reactive(new modelFieldType.String({
			id: 'ValAlfa3',
			originId: 'ValAlfa3',
			area: 'CNTRY',
			field: 'ALFA3',
			maxLength: 3,
			description: computed(() => this.Resources.ALPHABETIC_316640),
		}).cloneFrom(values?.ValAlfa3))
		this.stopWatchers.push(watch(() => this.ValAlfa3.value, (newValue, oldValue) => this.onUpdate('cntry.alfa3', this.ValAlfa3, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormProppaisViewModel instance.
	 * @returns {QFormProppaisViewModel} A new instance of QFormProppaisViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcntry'

	get QPrimaryKey() { return this.ValCodcntry.value }
	set QPrimaryKey(value) { this.ValCodcntry.updateValue(value) }
}
