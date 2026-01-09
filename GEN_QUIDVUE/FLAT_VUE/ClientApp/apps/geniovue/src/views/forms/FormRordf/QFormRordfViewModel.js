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
			name: 'RORDF',
			area: 'RORDF',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Rordf',
				updateFilesTickets: 'UpdateFilesTicketsRordf',
				setFile: 'SetFileRordf'
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
		this.stopWatchers.push(watch(() => this.ValCodrordf.value, (newValue, oldValue) => this.onUpdate('rordf.codrordf', this.ValCodrordf, newValue, oldValue)))

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
		this.stopWatchers.push(watch(() => this.ValOrder.value, (newValue, oldValue) => this.onUpdate('rordf.order', this.ValOrder, newValue, oldValue)))

		this.ValTitle = reactive(new modelFieldType.String({
			id: 'ValTitle',
			originId: 'ValTitle',
			area: 'RORDF',
			field: 'TITLE',
			maxLength: 50,
			description: computed(() => this.Resources.TITLE21885),
		}).cloneFrom(values?.ValTitle))
		this.stopWatchers.push(watch(() => this.ValTitle.value, (newValue, oldValue) => this.onUpdate('rordf.title', this.ValTitle, newValue, oldValue)))
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
	set QPrimaryKey(value) { this.ValCodrordf.updateValue(value) }
}
