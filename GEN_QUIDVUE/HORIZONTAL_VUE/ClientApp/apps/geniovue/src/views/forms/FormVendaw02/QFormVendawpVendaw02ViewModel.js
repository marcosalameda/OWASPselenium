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
			name: 'VENDAW02',
			area: 'SALE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_VENDAW02'
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
		this.ValInteress = reactive(new modelFieldType.Boolean({
			id: 'ValInteress',
			originId: 'ValInteress',
			area: 'SALE',
			field: 'INTERESS',
			description: computed(() => this.Resources.INTERESTED34576),
		}).cloneFrom(values?.ValInteress))
		watch(() => this.ValInteress.value, (newValue, oldValue) => this.onUpdate('sale.interess', this.ValInteress, newValue, oldValue))

		this.ValSemrfina = reactive(new modelFieldType.Boolean({
			id: 'ValSemrfina',
			originId: 'ValSemrfina',
			area: 'SALE',
			field: 'SEMRFINA',
			description: computed(() => this.Resources.WITHOUT_FINANCIAL_RE07914),
		}).cloneFrom(values?.ValSemrfina))
		watch(() => this.ValSemrfina.value, (newValue, oldValue) => this.onUpdate('sale.semrfina', this.ValSemrfina, newValue, oldValue))

		this.ValSemcapac = reactive(new modelFieldType.Boolean({
			id: 'ValSemcapac',
			originId: 'ValSemcapac',
			area: 'SALE',
			field: 'SEMCAPAC',
			description: computed(() => this.Resources.NO_DECISION_MAKING_P36615),
		}).cloneFrom(values?.ValSemcapac))
		watch(() => this.ValSemcapac.value, (newValue, oldValue) => this.onUpdate('sale.semcapac', this.ValSemcapac, newValue, oldValue))

		this.ValDtqualif = reactive(new modelFieldType.DateTime({
			id: 'ValDtqualif',
			originId: 'ValDtqualif',
			area: 'SALE',
			field: 'DTQUALIF',
			description: computed(() => this.Resources.QUALIFICATION64257),
		}).cloneFrom(values?.ValDtqualif))
		watch(() => this.ValDtqualif.value, (newValue, oldValue) => this.onUpdate('sale.dtqualif', this.ValDtqualif, newValue, oldValue))

		this.ValQualific = reactive(new modelFieldType.Boolean({
			id: 'ValQualific',
			originId: 'ValQualific',
			area: 'SALE',
			field: 'QUALIFIC',
			description: computed(() => this.Resources.QUALIFICATION_CARRIE05255),
		}).cloneFrom(values?.ValQualific))
		watch(() => this.ValQualific.value, (newValue, oldValue) => this.onUpdate('sale.qualific', this.ValQualific, newValue, oldValue))

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
	}

	/**
	 * Creates a clone of the current QFormVendawpVendaw02ViewModel instance.
	 * @returns {QFormVendawpVendaw02ViewModel} A new instance of QFormVendawpVendaw02ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodvenda'

	get QPrimaryKey() { return this.ValCodvenda.value }
	set QPrimaryKey(value) { this.ValCodvenda.updateValue(value) }
}
