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
			name: 'REGIA_ML',
			area: 'REGIO',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Regia_ml',
				updateFilesTickets: 'UpdateFilesTicketsRegia_ml',
				setFile: 'SetFileRegia_ml'
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
		this.stopWatchers.push(watch(() => this.ValCodregia.value, (newValue, oldValue) => this.onUpdate('regio.codregia', this.ValCodregia, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodcntry = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcntry',
			originId: 'ValCodcntry',
			area: 'REGIO',
			field: 'CODCNTRY',
			relatedArea: 'CNTRY',
			description: '',
		}).cloneFrom(values?.ValCodcntry))
		this.stopWatchers.push(watch(() => this.ValCodcntry.value, (newValue, oldValue) => this.onUpdate('regio.codcntry', this.ValCodcntry, newValue, oldValue)))

		this.ValCodpais1 = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpais1',
			originId: 'ValCodpais1',
			area: 'REGIO',
			field: 'CODPAIS1',
			relatedArea: 'PAIS1',
			description: '',
		}).cloneFrom(values?.ValCodpais1))
		this.stopWatchers.push(watch(() => this.ValCodpais1.value, (newValue, oldValue) => this.onUpdate('regio.codpais1', this.ValCodpais1, newValue, oldValue)))

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

		this.ValRegiao = reactive(new modelFieldType.String({
			id: 'ValRegiao',
			originId: 'ValRegiao',
			area: 'REGIO',
			field: 'REGIAO',
			maxLength: 50,
			description: computed(() => this.Resources.REGION12723),
		}).cloneFrom(values?.ValRegiao))
		this.stopWatchers.push(watch(() => this.ValRegiao.value, (newValue, oldValue) => this.onUpdate('regio.regiao', this.ValRegiao, newValue, oldValue)))

		this.TablePais1Country = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePais1Country',
			originId: 'ValCountry',
			area: 'PAIS1',
			field: 'COUNTRY',
			maxLength: 90,
			description: computed(() => this.Resources.COUNTRY64133),
		}).cloneFrom(values?.TablePais1Country))
		this.stopWatchers.push(watch(() => this.TablePais1Country.value, (newValue, oldValue) => this.onUpdate('pais1.country', this.TablePais1Country, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormRegiaMlViewModel instance.
	 * @returns {QFormRegiaMlViewModel} A new instance of QFormRegiaMlViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodregia'

	get QPrimaryKey() { return this.ValCodregia.value }
	set QPrimaryKey(value) { this.ValCodregia.updateValue(value) }
}
