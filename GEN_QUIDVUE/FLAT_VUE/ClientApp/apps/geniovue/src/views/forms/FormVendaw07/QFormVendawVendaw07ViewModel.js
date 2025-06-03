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
			name: 'VENDAW07',
			area: 'SALE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_VENDAW07'
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
		watch(() => this.ValCodvenda.value, (newValue, oldValue) => this.onUpdate('sale.codvenda', this.ValCodvenda, newValue, oldValue))

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
		watch(() => this.ValCodorgan.value, (newValue, oldValue) => this.onUpdate('sale.codorgan', this.ValCodorgan, newValue, oldValue))

		/** The remaining form fields. */
		this.ValTentfech = reactive(new modelFieldType.DateTime({
			id: 'ValTentfech',
			originId: 'ValTentfech',
			area: 'SALE',
			field: 'TENTFECH',
			description: computed(() => this.Resources.CLOSING_ATTEMPTS40059),
		}).cloneFrom(values?.ValTentfech))
		watch(() => this.ValTentfech.value, (newValue, oldValue) => this.onUpdate('sale.tentfech', this.ValTentfech, newValue, oldValue))

		this.ValDtvenda = reactive(new modelFieldType.DateTime({
			id: 'ValDtvenda',
			originId: 'ValDtvenda',
			area: 'SALE',
			field: 'DTVENDA',
			description: computed(() => this.Resources.CLOSING_OF_THE_SALE05493),
		}).cloneFrom(values?.ValDtvenda))
		watch(() => this.ValDtvenda.value, (newValue, oldValue) => this.onUpdate('sale.dtvenda', this.ValDtvenda, newValue, oldValue))

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
		watch(() => this.ValIdentifi.value, (newValue, oldValue) => this.onUpdate('sale.identifi', this.ValIdentifi, newValue, oldValue))

		this.ValDtsupera = reactive(new modelFieldType.DateTime({
			id: 'ValDtsupera',
			originId: 'ValDtsupera',
			area: 'SALE',
			field: 'DTSUPERA',
			isFixed: true,
			description: computed(() => this.Resources.OVERCOME_OBJECTIONS61930),
		}).cloneFrom(values?.ValDtsupera))
		watch(() => this.ValDtsupera.value, (newValue, oldValue) => this.onUpdate('sale.dtsupera', this.ValDtsupera, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormVendawVendaw07ViewModel instance.
	 * @returns {QFormVendawVendaw07ViewModel} A new instance of QFormVendawVendaw07ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodvenda'

	get QPrimaryKey() { return this.ValCodvenda.value }
	set QPrimaryKey(value) { this.ValCodvenda.updateValue(value) }
}
