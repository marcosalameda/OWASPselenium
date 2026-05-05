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
			name: 'ABATEREQ',
			area: 'DECOM',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_ABATEREQ',
				updateFilesTickets: 'UpdateFilesTicketsABATEREQ'
			}
		})

		/** The primary key. */
		this.ValCoddeco = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCoddeco',
			originId: 'ValCoddeco',
			area: 'DECOM',
			field: 'CODDECO',
			description: '',
		}).cloneFrom(values?.ValCoddeco))
		watch(() => this.ValCoddeco.value, (newValue, oldValue) => this.onUpdate('decom.coddeco', this.ValCoddeco, newValue, oldValue))

		/** The remaining form fields. */
		this.ValDecomnr = reactive(new modelFieldType.Number({
			id: 'ValDecomnr',
			originId: 'ValDecomnr',
			area: 'DECOM',
			field: 'DECOMNR',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.NO_BATE21045),
		}).cloneFrom(values?.ValDecomnr))
		watch(() => this.ValDecomnr.value, (newValue, oldValue) => this.onUpdate('decom.decomnr', this.ValDecomnr, newValue, oldValue))

		this.ValNote = reactive(new modelFieldType.MultiLineString({
			id: 'ValNote',
			originId: 'ValNote',
			area: 'DECOM',
			field: 'NOTE',
			description: computed(() => this.Resources.NOTES05274),
		}).cloneFrom(values?.ValNote))
		watch(() => this.ValNote.value, (newValue, oldValue) => this.onUpdate('decom.note', this.ValNote, newValue, oldValue))

		this.ValDtdeco = reactive(new modelFieldType.DateTime({
			id: 'ValDtdeco',
			originId: 'ValDtdeco',
			area: 'DECOM',
			field: 'DTDECO',
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: [Now]
					return qApi.Agora()
				},
				dependencyEvents: [],
				isServerRecalc: false,
				isEmpty: qApi.emptyD,
			},
			description: computed(() => this.Resources.DECOMISSION14486),
		}).cloneFrom(values?.ValDtdeco))
		watch(() => this.ValDtdeco.value, (newValue, oldValue) => this.onUpdate('decom.dtdeco', this.ValDtdeco, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormAbatereqViewModel instance.
	 * @returns {QFormAbatereqViewModel} A new instance of QFormAbatereqViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCoddeco'

	get QPrimaryKey() { return this.ValCoddeco.value }
	set QPrimaryKey(value) { this.ValCoddeco.updateValue(value) }
}
