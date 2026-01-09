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
			name: 'SEARCH',
			area: 'SEARCH',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Search',
				updateFilesTickets: 'UpdateFilesTicketsSearch',
				setFile: 'SetFileSearch'
			}
		})

		/** The primary key. */
		this.ValCodsearch = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodsearch',
			originId: 'ValCodsearch',
			area: 'SEARCH',
			field: 'CODSEARCH',
			description: '',
		}).cloneFrom(values?.ValCodsearch))
		this.stopWatchers.push(watch(() => this.ValCodsearch.value, (newValue, oldValue) => this.onUpdate('search.codsearch', this.ValCodsearch, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodpais = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpais',
			originId: 'ValCodpais',
			area: 'SEARCH',
			field: 'CODPAIS',
			relatedArea: 'CNTRY',
			description: '',
		}).cloneFrom(values?.ValCodpais))
		this.stopWatchers.push(watch(() => this.ValCodpais.value, (newValue, oldValue) => this.onUpdate('search.codpais', this.ValCodpais, newValue, oldValue)))

		this.ValCodregia = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodregia',
			originId: 'ValCodregia',
			area: 'SEARCH',
			field: 'CODREGIA',
			relatedArea: 'REGIO',
			description: '',
		}).cloneFrom(values?.ValCodregia))
		this.stopWatchers.push(watch(() => this.ValCodregia.value, (newValue, oldValue) => this.onUpdate('search.codregia', this.ValCodregia, newValue, oldValue)))

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
		this.stopWatchers.push(watch(() => this.TableCntryCountry.value, (newValue, oldValue) => this.onUpdate('cntry.country', this.TableCntryCountry, newValue, oldValue)))

		this.TableRegioRegiao = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableRegioRegiao',
			originId: 'ValRegiao',
			area: 'REGIO',
			field: 'REGIAO',
			maxLength: 50,
			description: computed(() => this.Resources.REGION12723),
		}).cloneFrom(values?.TableRegioRegiao))
		this.stopWatchers.push(watch(() => this.TableRegioRegiao.value, (newValue, oldValue) => this.onUpdate('regio.regiao', this.TableRegioRegiao, newValue, oldValue)))

		/** The form fields used only in formulas. */
		this.ValHkey = reactive(new modelFieldType.String({
			id: 'ValHkey',
			originId: 'ValHkey',
			area: 'SEARCH',
			field: 'HKEY',
			maxLength: 50,
			isFixed: true,
			description: '',
		}).cloneFrom(values?.ValHkey))
		this.stopWatchers.push(watch(() => this.ValHkey.value, (newValue, oldValue) => this.onUpdate('search.hkey', this.ValHkey, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormSearchViewModel instance.
	 * @returns {QFormSearchViewModel} A new instance of QFormSearchViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodsearch'

	get QPrimaryKey() { return this.ValCodsearch.value }
	set QPrimaryKey(value) { this.ValCodsearch.updateValue(value) }
}
