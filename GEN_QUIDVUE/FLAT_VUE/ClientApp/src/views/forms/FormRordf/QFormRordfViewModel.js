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
			name: 'RORDF',
			area: 'RORDF',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_RORDF'
			}
		})

		/** The primary key. */
		this.ValCodrordf = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodrordf',
			originId: 'ValCodrordf',
			area: 'RORDF',
			field: 'CODRORDF',
			description: '',
		}).cloneFrom(values?.ValCodrordf))
		watch(() => this.ValCodrordf.value, (newValue, oldValue) => this.onUpdate('rordf.codrordf', this.ValCodrordf, newValue, oldValue))

		/** The remaining form fields. */
		this.ValOrder = reactive(new modelFieldType.Number({
			id: 'ValOrder',
			originId: 'ValOrder',
			area: 'RORDF',
			field: 'ORDER',
			maxDigits: 8,
			decimalDigits: 1,
			description: computed(() => this.Resources.ORDER39632),
		}).cloneFrom(values?.ValOrder))
		watch(() => this.ValOrder.value, (newValue, oldValue) => this.onUpdate('rordf.order', this.ValOrder, newValue, oldValue))

		this.ValTitle = reactive(new modelFieldType.String({
			id: 'ValTitle',
			originId: 'ValTitle',
			area: 'RORDF',
			field: 'TITLE',
			maxLength: 50,
			description: computed(() => this.Resources.TITLE21885),
		}).cloneFrom(values?.ValTitle))
		watch(() => this.ValTitle.value, (newValue, oldValue) => this.onUpdate('rordf.title', this.ValTitle, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormRordfViewModel instance.
	 * @returns {QFormRordfViewModel} A new instance of QFormRordfViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodrordf'

	get QPrimaryKey() { return this.ValCodrordf.value }
	set QPrimaryKey(value) { this.ValCodrordf.value = value }
}
