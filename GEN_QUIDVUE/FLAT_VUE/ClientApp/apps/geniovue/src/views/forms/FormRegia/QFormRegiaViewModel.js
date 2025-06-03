/* eslint-disable no-unused-vars */
import { computed, reactive, watch } from 'vue'
import _merge from 'lodash-es/merge'

import ViewModelBase from '@/mixins/formViewModelBase.js'
import genericFunctions from '@/mixins/genericFunctions.js'
import modelFieldType from '@/mixins/formModelFieldTypes.js'

import hardcodedTexts from '@/hardcodedTexts.js'
import netAPI from '@/api/network'
import qApi from '@/api/genio/quidgestFunctions.js'
import qFunctions from '@/api/genio/projectFunctions.js'
import qProjArrays from '@/api/genio/projectArrays.js'
/* eslint-enable no-unused-vars */

/**
 * Represents a ViewModel class.
 * @extends ViewModelBase
 */
export default class ViewModel extends ViewModelBase
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

		/** The view model metadata */
		_merge(this.modelInfo, {
			name: 'REGIA',
			area: 'REGIO',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_REGIA'
			}
		})

		/** The primary key. */
		this.ValCodregia = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodregia',
			originId: 'ValCodregia',
			area: 'REGIO',
			field: 'CODREGIA',
			description: '',
		}).cloneFrom(values?.ValCodregia))
		watch(() => this.ValCodregia.value, (newValue, oldValue) => this.onUpdate('regio.codregia', this.ValCodregia, newValue, oldValue))

		/** The hidden foreign keys. */
		this.ValCodpais1 = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpais1',
			originId: 'ValCodpais1',
			area: 'REGIO',
			field: 'CODPAIS1',
			relatedArea: 'PAIS1',
			isFixed: true,
			description: '',
		}).cloneFrom(values?.ValCodpais1))
		watch(() => this.ValCodpais1.value, (newValue, oldValue) => this.onUpdate('regio.codpais1', this.ValCodpais1, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodcntry = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcntry',
			originId: 'ValCodcntry',
			area: 'REGIO',
			field: 'CODCNTRY',
			relatedArea: 'CNTRY',
			description: '',
		}).cloneFrom(values?.ValCodcntry))
		watch(() => this.ValCodcntry.value, (newValue, oldValue) => this.onUpdate('regio.codcntry', this.ValCodcntry, newValue, oldValue))

		/** The remaining form fields. */
		this.TableCntryCountry = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCntryCountry',
			originId: 'ValCountry',
			area: 'CNTRY',
			field: 'COUNTRY',
			maxLength: 90,
			description: computed(() => this.Resources.COUNTRY64133),
		}).cloneFrom(values?.TableCntryCountry))
		watch(() => this.TableCntryCountry.value, (newValue, oldValue) => this.onUpdate('cntry.country', this.TableCntryCountry, newValue, oldValue))

		this.ValRegiao = reactive(new modelFieldType.String({
			id: 'ValRegiao',
			originId: 'ValRegiao',
			area: 'REGIO',
			field: 'REGIAO',
			maxLength: 50,
			description: computed(() => this.Resources.REGION12723),
		}).cloneFrom(values?.ValRegiao))
		watch(() => this.ValRegiao.value, (newValue, oldValue) => this.onUpdate('regio.regiao', this.ValRegiao, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormRegiaViewModel instance.
	 * @returns {QFormRegiaViewModel} A new instance of QFormRegiaViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodregia'

	get QPrimaryKey() { return this.ValCodregia.value }
	set QPrimaryKey(value) { this.ValCodregia.updateValue(value) }
}
