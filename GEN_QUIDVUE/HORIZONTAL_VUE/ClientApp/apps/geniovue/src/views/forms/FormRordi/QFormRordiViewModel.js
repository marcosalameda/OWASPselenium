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
			name: 'RORDI',
			area: 'RORDI',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_RORDI',
				updateFilesTickets: 'UpdateFilesTicketsRORDI'
			}
		})

		/** The primary key. */
		this.ValCodrordi = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodrordi',
			originId: 'ValCodrordi',
			area: 'RORDI',
			field: 'CODRORDI',
			description: '',
		}).cloneFrom(values?.ValCodrordi))
		watch(() => this.ValCodrordi.value, (newValue, oldValue) => this.onUpdate('rordi.codrordi', this.ValCodrordi, newValue, oldValue))

		/** The remaining form fields. */
		this.ValOrder = reactive(new modelFieldType.Number({
			id: 'ValOrder',
			originId: 'ValOrder',
			area: 'RORDI',
			field: 'ORDER',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.ORDER39632),
		}).cloneFrom(values?.ValOrder))
		watch(() => this.ValOrder.value, (newValue, oldValue) => this.onUpdate('rordi.order', this.ValOrder, newValue, oldValue))

		this.ValTitle = reactive(new modelFieldType.String({
			id: 'ValTitle',
			originId: 'ValTitle',
			area: 'RORDI',
			field: 'TITLE',
			maxLength: 50,
			description: computed(() => this.Resources.TITLE21885),
		}).cloneFrom(values?.ValTitle))
		watch(() => this.ValTitle.value, (newValue, oldValue) => this.onUpdate('rordi.title', this.ValTitle, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormRordiViewModel instance.
	 * @returns {QFormRordiViewModel} A new instance of QFormRordiViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodrordi'

	get QPrimaryKey() { return this.ValCodrordi.value }
	set QPrimaryKey(value) { this.ValCodrordi.updateValue(value) }
}
