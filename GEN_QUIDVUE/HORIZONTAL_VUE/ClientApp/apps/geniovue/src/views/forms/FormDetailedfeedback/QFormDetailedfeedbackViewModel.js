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
			name: 'DETAILEDFEEDBACK',
			area: 'UFEEDBACK',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_DETAILEDFEEDBACK',
				updateFilesTickets: 'UpdateFilesTicketsDETAILEDFEEDBACK'
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
		this.ValServicefeedback = reactive(new modelFieldType.String({
			id: 'ValServicefeedback',
			originId: 'ValServicefeedback',
			area: 'UFEEDBACK',
			field: 'SERVICEFEEDBACK',
			maxLength: 1,
			arrayOptions: computed(() => qProjArrays.QArrayAreatecn.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.SERVICE_FEEDBACK32323),
		}).cloneFrom(values?.ValServicefeedback))
		watch(() => this.ValServicefeedback.value, (newValue, oldValue) => this.onUpdate('ufeedback.servicefeedback', this.ValServicefeedback, newValue, oldValue))

		this.ValServicetype = reactive(new modelFieldType.String({
			id: 'ValServicetype',
			originId: 'ValServicetype',
			area: 'UFEEDBACK',
			field: 'SERVICETYPE',
			maxLength: 1,
			arrayOptions: computed(() => qProjArrays.QArrayServicetype.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.SERVICE_TYPE52940),
		}).cloneFrom(values?.ValServicetype))
		watch(() => this.ValServicetype.value, (newValue, oldValue) => this.onUpdate('ufeedback.servicetype', this.ValServicetype, newValue, oldValue))

		this.ValFeedbcoment = reactive(new modelFieldType.MultiLineString({
			id: 'ValFeedbcoment',
			originId: 'ValFeedbcoment',
			area: 'UFEEDBACK',
			field: 'FEEDBCOMENT',
			description: computed(() => this.Resources.COMMENTS30895),
		}).cloneFrom(values?.ValFeedbcoment))
		watch(() => this.ValFeedbcoment.value, (newValue, oldValue) => this.onUpdate('ufeedback.feedbcoment', this.ValFeedbcoment, newValue, oldValue))

		this.ValFeedbackdate = reactive(new modelFieldType.DateTime({
			id: 'ValFeedbackdate',
			originId: 'ValFeedbackdate',
			area: 'UFEEDBACK',
			field: 'FEEDBACKDATE',
			isFixed: true,
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
			description: computed(() => this.Resources.FEEDBACK_DATE28454),
		}).cloneFrom(values?.ValFeedbackdate))
		watch(() => this.ValFeedbackdate.value, (newValue, oldValue) => this.onUpdate('ufeedback.feedbackdate', this.ValFeedbackdate, newValue, oldValue))

		this.ValFeedbfile = reactive(new modelFieldType.Document({
			id: 'ValFeedbfile',
			originId: 'ValFeedbfile',
			area: 'UFEEDBACK',
			field: 'FEEDBFILE',
			properties: computed(() => this.ValFeedbfilePropertiesVM),
			documentFK: computed(() => this.ValFeedbfilefk),
			currentDocument: computed(() => this.ValFeedbfileData),
			description: computed(() => this.Resources.FILES64557),
		}).cloneFrom(values?.ValFeedbfile))
		watch(() => this.ValFeedbfile.value, (newValue, oldValue) => this.onUpdate('ufeedback.feedbfile', this.ValFeedbfile, newValue, oldValue))

		this.ValFeedbfilePropertiesVM = reactive(new modelFieldType.Base({
			id: 'ValFeedbfilePropertiesVM',
			area: 'UFEEDBACK',
			field: 'FEEDBFILEDOCUM',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValFeedbfilePropertiesVM))
		this.ValFeedbfilefk = reactive(new modelFieldType.String({
			id: 'ValFeedbfilefk',
			area: 'UFEEDBACK',
			field: 'FEEDBFILEFK'
		}).cloneFrom(values?.ValFeedbfilefk))
		watch(() => this.ValFeedbfilefk.value, (newValue, oldValue) => this.onUpdate('ufeedback.feedbfilefk', this.ValFeedbfilefk, newValue, oldValue))
		this.ValFeedbfileData = reactive(new modelFieldType.DocumentData({
			id: 'ValFeedbfileData',
			area: 'UFEEDBACK',
			field: 'FEEDBFILEDATA',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValFeedbfileData))
		watch(() => this.ValFeedbfileData.value, (newValue, oldValue) => this.onUpdate('ufeedback.feedbfiledata', this.ValFeedbfileData, newValue, oldValue), { deep: true })
	}

	/**
	 * Creates a clone of the current QFormDetailedfeedbackViewModel instance.
	 * @returns {QFormDetailedfeedbackViewModel} A new instance of QFormDetailedfeedbackViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodufeedback'

	get QPrimaryKey() { return this.ValCodufeedback.value }
	set QPrimaryKey(value) { this.ValCodufeedback.updateValue(value) }
}
