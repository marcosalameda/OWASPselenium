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
			name: 'FAQS',
			area: 'FAQS',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Faqs',
				updateFilesTickets: 'UpdateFilesTicketsFaqs',
				setFile: 'SetFileFaqs'
			}
		})

		/** The primary key. */
		this.ValCodfaqs = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodfaqs',
			originId: 'ValCodfaqs',
			area: 'FAQS',
			field: 'CODFAQS',
			description: '',
		}).cloneFrom(values?.ValCodfaqs))
		this.stopWatchers.push(watch(() => this.ValCodfaqs.value, (newValue, oldValue) => this.onUpdate('faqs.codfaqs', this.ValCodfaqs, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValCodcfaqs = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcfaqs',
			originId: 'ValCodcfaqs',
			area: 'FAQS',
			field: 'CODCFAQS',
			relatedArea: 'CFAQS',
			isFixed: true,
			description: '',
		}).cloneFrom(values?.ValCodcfaqs))
		this.stopWatchers.push(watch(() => this.ValCodcfaqs.value, (newValue, oldValue) => this.onUpdate('faqs.codcfaqs', this.ValCodcfaqs, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValQuestion = reactive(new modelFieldType.MultiLineString({
			id: 'ValQuestion',
			originId: 'ValQuestion',
			area: 'FAQS',
			field: 'QUESTION',
			description: computed(() => this.Resources.QUESTION00194),
		}).cloneFrom(values?.ValQuestion))
		this.stopWatchers.push(watch(() => this.ValQuestion.value, (newValue, oldValue) => this.onUpdate('faqs.question', this.ValQuestion, newValue, oldValue)))

		this.ValAnswer = reactive(new modelFieldType.MultiLineString({
			type: 'TextEditor',
			id: 'ValAnswer',
			originId: 'ValAnswer',
			area: 'FAQS',
			field: 'ANSWER',
			description: computed(() => this.Resources.ANSWER22961),
		}).cloneFrom(values?.ValAnswer))
		this.stopWatchers.push(watch(() => this.ValAnswer.value, (newValue, oldValue) => this.onUpdate('faqs.answer', this.ValAnswer, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFaqsViewModel instance.
	 * @returns {QFormFaqsViewModel} A new instance of QFormFaqsViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodfaqs'

	get QPrimaryKey() { return this.ValCodfaqs.value }
	set QPrimaryKey(value) { this.ValCodfaqs.updateValue(value) }
}
