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
			name: 'VENDAW08',
			area: 'SALE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Vendaw08',
				updateFilesTickets: 'UpdateFilesTicketsVendaw08',
				setFile: 'SetFileVendaw08'
			}
		})

		/** The primary key. */
		this.ValCodvenda = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodvenda',
			originId: 'ValCodvenda',
			area: 'SALE',
			field: 'CODVENDA',
			description: '',
		}).cloneFrom(values?.ValCodvenda))
		this.stopWatchers.push(watch(() => this.ValCodvenda.value, (newValue, oldValue) => this.onUpdate('sale.codvenda', this.ValCodvenda, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValCodorgan = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodorgan',
			originId: 'ValCodorgan',
			area: 'SALE',
			field: 'CODORGAN',
			relatedArea: 'ORGAN',
			isFixed: true,
			description: '',
		}).cloneFrom(values?.ValCodorgan))
		this.stopWatchers.push(watch(() => this.ValCodorgan.value, (newValue, oldValue) => this.onUpdate('sale.codorgan', this.ValCodorgan, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValDtacompa = reactive(new modelFieldType.DateTime({
			id: 'ValDtacompa',
			originId: 'ValDtacompa',
			area: 'SALE',
			field: 'DTACOMPA',
			description: computed(() => this.Resources.FOLLOW_UP22119),
		}).cloneFrom(values?.ValDtacompa))
		this.stopWatchers.push(watch(() => this.ValDtacompa.value, (newValue, oldValue) => this.onUpdate('sale.dtacompa', this.ValDtacompa, newValue, oldValue)))

		/** The form fields used only in formulas. */
		this.ValIdentifi = reactive(new modelFieldType.String({
			id: 'ValIdentifi',
			originId: 'ValIdentifi',
			area: 'SALE',
			field: 'IDENTIFI',
			maxLength: 85,
			isFixed: true,
			description: computed(() => this.Resources.IDENTIFICATION_OF_BU58085),
		}).cloneFrom(values?.ValIdentifi))
		this.stopWatchers.push(watch(() => this.ValIdentifi.value, (newValue, oldValue) => this.onUpdate('sale.identifi', this.ValIdentifi, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormVendawvVendaw08ViewModel instance.
	 * @returns {QFormVendawvVendaw08ViewModel} A new instance of QFormVendawvVendaw08ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodvenda'

	get QPrimaryKey() { return this.ValCodvenda.value }
	set QPrimaryKey(value) { this.ValCodvenda.updateValue(value) }
}
