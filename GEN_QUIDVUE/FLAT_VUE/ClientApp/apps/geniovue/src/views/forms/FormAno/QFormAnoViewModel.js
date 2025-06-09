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
			name: 'ANO',
			area: 'YEAR',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_ANO',
				updateFilesTickets: 'UpdateFilesTicketsANO'
			}
		})

		/** The primary key. */
		this.ValCodyear = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodyear',
			originId: 'ValCodyear',
			area: 'YEAR',
			field: 'CODYEAR',
			description: '',
		}).cloneFrom(values?.ValCodyear))
		watch(() => this.ValCodyear.value, (newValue, oldValue) => this.onUpdate('year.codyear', this.ValCodyear, newValue, oldValue))

		/** The remaining form fields. */
		this.ValYear = reactive(new modelFieldType.String({
			id: 'ValYear',
			originId: 'ValYear',
			area: 'YEAR',
			field: 'YEAR',
			maxLength: 4,
			description: computed(() => this.Resources.YEAR61794),
		}).cloneFrom(values?.ValYear))
		watch(() => this.ValYear.value, (newValue, oldValue) => this.onUpdate('year.year', this.ValYear, newValue, oldValue))

		this.ValYearnum = reactive(new modelFieldType.Number({
			id: 'ValYearnum',
			originId: 'ValYearnum',
			area: 'YEAR',
			field: 'YEARNUM',
			maxDigits: 4,
			decimalDigits: 0,
			description: computed(() => this.Resources.YEAR__NUMBERS_29394),
		}).cloneFrom(values?.ValYearnum))
		watch(() => this.ValYearnum.value, (newValue, oldValue) => this.onUpdate('year.yearnum', this.ValYearnum, newValue, oldValue))

		this.ValValue = reactive(new modelFieldType.Number({
			id: 'ValValue',
			originId: 'ValValue',
			area: 'YEAR',
			field: 'VALUE',
			maxDigits: 7,
			decimalDigits: 2,
			isFixed: true,
			description: computed(() => this.Resources.VALUE10285),
		}).cloneFrom(values?.ValValue))
		watch(() => this.ValValue.value, (newValue, oldValue) => this.onUpdate('year.value', this.ValValue, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormAnoViewModel instance.
	 * @returns {QFormAnoViewModel} A new instance of QFormAnoViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodyear'

	get QPrimaryKey() { return this.ValCodyear.value }
	set QPrimaryKey(value) { this.ValCodyear.updateValue(value) }
}
