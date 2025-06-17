/* eslint-disable no-unused-vars */
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
/* eslint-enable no-unused-vars */

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
	// eslint-disable-next-line no-unused-vars
	constructor(vueContext, options, values)
	{
		super(vueContext, options)
		// eslint-disable-next-line no-unused-vars
		const vm = this.vueContext

		// The view model metadata
		_merge(this.modelInfo, {
			name: 'VENDAW03',
			area: 'SALE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_VENDAW03',
				updateFilesTickets: 'UpdateFilesTicketsVENDAW03'
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
		this.ValPreabord = reactive(new modelFieldType.DateTime({
			id: 'ValPreabord',
			originId: 'ValPreabord',
			area: 'SALE',
			field: 'PREABORD',
			description: computed(() => this.Resources.PRE_APPROACH58979),
		}).cloneFrom(values?.ValPreabord))
		watch(() => this.ValPreabord.value, (newValue, oldValue) => this.onUpdate('sale.preabord', this.ValPreabord, newValue, oldValue))

		this.ValHomework = reactive(new modelFieldType.Boolean({
			id: 'ValHomework',
			originId: 'ValHomework',
			area: 'SALE',
			field: 'HOMEWORK',
			description: computed(() => this.Resources.HOMEWORK_DONE45166),
		}).cloneFrom(values?.ValHomework))
		watch(() => this.ValHomework.value, (newValue, oldValue) => this.onUpdate('sale.homework', this.ValHomework, newValue, oldValue))

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

		this.ValQualific = reactive(new modelFieldType.Boolean({
			id: 'ValQualific',
			originId: 'ValQualific',
			area: 'SALE',
			field: 'QUALIFIC',
			isFixed: true,
			description: computed(() => this.Resources.QUALIFICATION_CARRIE05255),
		}).cloneFrom(values?.ValQualific))
		watch(() => this.ValQualific.value, (newValue, oldValue) => this.onUpdate('sale.qualific', this.ValQualific, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormVendawVendaw03ViewModel instance.
	 * @returns {QFormVendawVendaw03ViewModel} A new instance of QFormVendawVendaw03ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodvenda'

	get QPrimaryKey() { return this.ValCodvenda.value }
	set QPrimaryKey(value) { this.ValCodvenda.updateValue(value) }
}
