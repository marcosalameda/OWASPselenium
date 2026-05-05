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
			name: 'USEFULFEEDBACK',
			area: 'UFEEDBACK',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_USEFULFEEDBACK',
				updateFilesTickets: 'UpdateFilesTicketsUSEFULFEEDBACK'
			}
		})

		/** The primary key. */
		this.ValCodufeedback = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodufeedback',
			originId: 'ValCodufeedback',
			area: 'UFEEDBACK',
			field: 'CODUFEEDBACK',
			description: computed(() => this.Resources.CODUFEEDBACK21220),
		}).cloneFrom(values?.ValCodufeedback))
		watch(() => this.ValCodufeedback.value, (newValue, oldValue) => this.onUpdate('ufeedback.codufeedback', this.ValCodufeedback, newValue, oldValue))

		/** The hidden foreign keys. */
		this.ValCodfeedbacktype = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodfeedbacktype',
			originId: 'ValCodfeedbacktype',
			area: 'UFEEDBACK',
			field: 'CODFEEDBACKTYPE',
			relatedArea: 'FEEDBACKTYPE',
			isFixed: true,
			description: '',
		}).cloneFrom(values?.ValCodfeedbacktype))
		watch(() => this.ValCodfeedbacktype.value, (newValue, oldValue) => this.onUpdate('ufeedback.codfeedbacktype', this.ValCodfeedbacktype, newValue, oldValue))

		/** The remaining form fields. */
		this.ValUsefulfeedb = reactive(new modelFieldType.Number({
			id: 'ValUsefulfeedb',
			originId: 'ValUsefulfeedb',
			area: 'UFEEDBACK',
			field: 'USEFULFEEDB',
			maxDigits: 1,
			decimalDigits: 0,
			arrayOptions: computed(() => qProjArrays.QArrayUsefulfeedb.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.USEFULFEEDB16828),
		}).cloneFrom(values?.ValUsefulfeedb))
		watch(() => this.ValUsefulfeedb.value, (newValue, oldValue) => this.onUpdate('ufeedback.usefulfeedb', this.ValUsefulfeedb, newValue, oldValue))

		this.ValSfeedback = reactive(new modelFieldType.Number({
			id: 'ValSfeedback',
			originId: 'ValSfeedback',
			area: 'UFEEDBACK',
			field: 'SFEEDBACK',
			maxDigits: 1,
			decimalDigits: 0,
			arrayOptions: computed(() => qProjArrays.QArrayFeedback.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.FEEDBACK36998),
		}).cloneFrom(values?.ValSfeedback))
		watch(() => this.ValSfeedback.value, (newValue, oldValue) => this.onUpdate('ufeedback.sfeedback', this.ValSfeedback, newValue, oldValue))

		this.ValFeedbcoment = reactive(new modelFieldType.MultiLineString({
			id: 'ValFeedbcoment',
			originId: 'ValFeedbcoment',
			area: 'UFEEDBACK',
			field: 'FEEDBCOMENT',
			description: computed(() => this.Resources.COMMENTS30895),
		}).cloneFrom(values?.ValFeedbcoment))
		watch(() => this.ValFeedbcoment.value, (newValue, oldValue) => this.onUpdate('ufeedback.feedbcoment', this.ValFeedbcoment, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormUsefulfeedbackViewModel instance.
	 * @returns {QFormUsefulfeedbackViewModel} A new instance of QFormUsefulfeedbackViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodufeedback'

	get QPrimaryKey() { return this.ValCodufeedback.value }
	set QPrimaryKey(value) { this.ValCodufeedback.updateValue(value) }
}
