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
			name: 'TRADU',
			area: 'TRADU',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Tradu',
				updateFilesTickets: 'UpdateFilesTicketsTradu',
				setFile: 'SetFileTradu'
			}
		})

		/** The primary key. */
		this.ValCodtradu = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodtradu',
			originId: 'ValCodtradu',
			area: 'TRADU',
			field: 'CODTRADU',
			description: '',
		}).cloneFrom(values?.ValCodtradu))
		this.stopWatchers.push(watch(() => this.ValCodtradu.value, (newValue, oldValue) => this.onUpdate('tradu.codtradu', this.ValCodtradu, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodidio1 = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodidio1',
			originId: 'ValCodidio1',
			area: 'TRADU',
			field: 'CODIDIO1',
			relatedArea: 'LANG1',
			description: computed(() => this.Resources.LANGUAGE33172),
		}).cloneFrom(values?.ValCodidio1))
		this.stopWatchers.push(watch(() => this.ValCodidio1.value, (newValue, oldValue) => this.onUpdate('tradu.codidio1', this.ValCodidio1, newValue, oldValue)))

		this.ValCodidio2 = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodidio2',
			originId: 'ValCodidio2',
			area: 'TRADU',
			field: 'CODIDIO2',
			relatedArea: 'LANG2',
			description: computed(() => this.Resources.LANGUAGE16872),
		}).cloneFrom(values?.ValCodidio2))
		this.stopWatchers.push(watch(() => this.ValCodidio2.value, (newValue, oldValue) => this.onUpdate('tradu.codidio2', this.ValCodidio2, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValReferenc = reactive(new modelFieldType.String({
			id: 'ValReferenc',
			originId: 'ValReferenc',
			area: 'TRADU',
			field: 'REFERENC',
			maxLength: 50,
			description: computed(() => this.Resources.REFERENCE28402),
		}).cloneFrom(values?.ValReferenc))
		this.stopWatchers.push(watch(() => this.ValReferenc.value, (newValue, oldValue) => this.onUpdate('tradu.referenc', this.ValReferenc, newValue, oldValue)))

		this.TableLang1Langua = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableLang1Langua',
			originId: 'ValLangua',
			area: 'LANG1',
			field: 'LANGUA',
			maxLength: 50,
			description: computed(() => this.Resources.LANGUAGE16872),
		}).cloneFrom(values?.TableLang1Langua))
		this.stopWatchers.push(watch(() => this.TableLang1Langua.value, (newValue, oldValue) => this.onUpdate('lang1.langua', this.TableLang1Langua, newValue, oldValue)))

		this.ValAtraduzi = reactive(new modelFieldType.String({
			id: 'ValAtraduzi',
			originId: 'ValAtraduzi',
			area: 'TRADU',
			field: 'ATRADUZI',
			maxLength: 50,
			description: computed(() => this.Resources.TO_REVIEW46268),
		}).cloneFrom(values?.ValAtraduzi))
		this.stopWatchers.push(watch(() => this.ValAtraduzi.value, (newValue, oldValue) => this.onUpdate('tradu.atraduzi', this.ValAtraduzi, newValue, oldValue)))

		this.TableLang2Langua = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableLang2Langua',
			originId: 'ValLangua',
			area: 'LANG2',
			field: 'LANGUA',
			maxLength: 50,
			description: computed(() => this.Resources.LANGUAGE16872),
		}).cloneFrom(values?.TableLang2Langua))
		this.stopWatchers.push(watch(() => this.TableLang2Langua.value, (newValue, oldValue) => this.onUpdate('lang2.langua', this.TableLang2Langua, newValue, oldValue)))

		this.ValTraduzid = reactive(new modelFieldType.String({
			id: 'ValTraduzid',
			originId: 'ValTraduzid',
			area: 'TRADU',
			field: 'TRADUZID',
			maxLength: 50,
			description: computed(() => this.Resources.TRANSLATED03333),
		}).cloneFrom(values?.ValTraduzid))
		this.stopWatchers.push(watch(() => this.ValTraduzid.value, (newValue, oldValue) => this.onUpdate('tradu.traduzid', this.ValTraduzid, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormTraduViewModel instance.
	 * @returns {QFormTraduViewModel} A new instance of QFormTraduViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodtradu'

	get QPrimaryKey() { return this.ValCodtradu.value }
	set QPrimaryKey(value) { this.ValCodtradu.updateValue(value) }
}
