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
			name: 'VENDAW05',
			area: 'SALE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_VENDAW05'
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
			description: '',
		}).cloneFrom(values?.ValCodorgan))
		watch(() => this.ValCodorgan.value, (newValue, oldValue) => this.onUpdate('sale.codorgan', this.ValCodorgan, newValue, oldValue))

		/** The remaining form fields. */
		this.ValDtaprese = reactive(new modelFieldType.DateTime({
			id: 'ValDtaprese',
			originId: 'ValDtaprese',
			area: 'SALE',
			field: 'DTAPRESE',
			description: computed(() => this.Resources.PRESENTATION_MADE15117),
		}).cloneFrom(values?.ValDtaprese))
		watch(() => this.ValDtaprese.value, (newValue, oldValue) => this.onUpdate('sale.dtaprese', this.ValDtaprese, newValue, oldValue))

		this.ValApresent = reactive(new modelFieldType.Boolean({
			id: 'ValApresent',
			originId: 'ValApresent',
			area: 'SALE',
			field: 'APRESENT',
			description: computed(() => this.Resources.PRESENTATION64246),
		}).cloneFrom(values?.ValApresent))
		watch(() => this.ValApresent.value, (newValue, oldValue) => this.onUpdate('sale.apresent', this.ValApresent, newValue, oldValue))

		/** The form fields used only in formulas. */
		this.ValIdentifi = reactive(new modelFieldType.String({
			id: 'ValIdentifi',
			originId: 'ValIdentifi',
			area: 'SALE',
			field: 'IDENTIFI',
			maxLength: 85,
			description: computed(() => this.Resources.IDENTIFICATION_OF_BU58085),
		}).cloneFrom(values?.ValIdentifi))
		watch(() => this.ValIdentifi.value, (newValue, oldValue) => this.onUpdate('sale.identifi', this.ValIdentifi, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormVendawvVendaw05ViewModel instance.
	 * @returns {QFormVendawvVendaw05ViewModel} A new instance of QFormVendawvVendaw05ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodvenda'

	get QPrimaryKey() { return this.ValCodvenda.value }
	set QPrimaryKey(value) { this.ValCodvenda.value = value }
}
