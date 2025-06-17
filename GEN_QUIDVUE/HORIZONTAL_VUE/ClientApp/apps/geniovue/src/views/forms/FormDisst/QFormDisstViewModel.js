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
			name: 'DISST',
			area: 'DISST',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_DISST',
				updateFilesTickets: 'UpdateFilesTicketsDISST'
			}
		})

		/** The primary key. */
		this.ValCoddisst = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCoddisst',
			originId: 'ValCoddisst',
			area: 'DISST',
			field: 'CODDISST',
			description: '',
		}).cloneFrom(values?.ValCoddisst))
		watch(() => this.ValCoddisst.value, (newValue, oldValue) => this.onUpdate('disst.coddisst', this.ValCoddisst, newValue, oldValue))

		/** The remaining form fields. */
		this.ValStatus = reactive(new modelFieldType.String({
			id: 'ValStatus',
			originId: 'ValStatus',
			area: 'DISST',
			field: 'STATUS',
			maxLength: 50,
			description: computed(() => this.Resources.STATUS62033),
		}).cloneFrom(values?.ValStatus))
		watch(() => this.ValStatus.value, (newValue, oldValue) => this.onUpdate('disst.status', this.ValStatus, newValue, oldValue))

		this.ValOrder = reactive(new modelFieldType.Number({
			id: 'ValOrder',
			originId: 'ValOrder',
			area: 'DISST',
			field: 'ORDER',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.ORDER39632),
		}).cloneFrom(values?.ValOrder))
		watch(() => this.ValOrder.value, (newValue, oldValue) => this.onUpdate('disst.order', this.ValOrder, newValue, oldValue))

		this.ValDescript = reactive(new modelFieldType.String({
			id: 'ValDescript',
			originId: 'ValDescript',
			area: 'DISST',
			field: 'DESCRIPT',
			maxLength: 50,
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescript))
		watch(() => this.ValDescript.value, (newValue, oldValue) => this.onUpdate('disst.descript', this.ValDescript, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormDisstViewModel instance.
	 * @returns {QFormDisstViewModel} A new instance of QFormDisstViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCoddisst'

	get QPrimaryKey() { return this.ValCoddisst.value }
	set QPrimaryKey(value) { this.ValCoddisst.updateValue(value) }
}
