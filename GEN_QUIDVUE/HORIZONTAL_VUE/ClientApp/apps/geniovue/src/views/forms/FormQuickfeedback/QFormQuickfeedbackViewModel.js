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
			name: 'QUICKFEEDBACK',
			area: 'UFEEDBACK',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_QUICKFEEDBACK',
				updateFilesTickets: 'UpdateFilesTicketsQUICKFEEDBACK'
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
		this.ValLogicalfeedb = reactive(new modelFieldType.Boolean({
			id: 'ValLogicalfeedb',
			originId: 'ValLogicalfeedb',
			area: 'UFEEDBACK',
			field: 'LOGICALFEEDB',
			description: computed(() => this.Resources.THE_INFORMATION_IS_H08002),
		}).cloneFrom(values?.ValLogicalfeedb))
		watch(() => this.ValLogicalfeedb.value, (newValue, oldValue) => this.onUpdate('ufeedback.logicalfeedb', this.ValLogicalfeedb, newValue, oldValue))

		this.ValLanguagelogic = reactive(new modelFieldType.Boolean({
			id: 'ValLanguagelogic',
			originId: 'ValLanguagelogic',
			area: 'UFEEDBACK',
			field: 'LANGUAGELOGIC',
			description: computed(() => this.Resources.I_D_LIKE_TO_HAVE_MOR23763),
		}).cloneFrom(values?.ValLanguagelogic))
		watch(() => this.ValLanguagelogic.value, (newValue, oldValue) => this.onUpdate('ufeedback.languagelogic', this.ValLanguagelogic, newValue, oldValue))

		this.ValLogicfeed = reactive(new modelFieldType.Boolean({
			id: 'ValLogicfeed',
			originId: 'ValLogicfeed',
			area: 'UFEEDBACK',
			field: 'LOGICFEED',
			description: computed(() => this.Resources.I_CAN_T_FIND_WHAT_I_33456),
		}).cloneFrom(values?.ValLogicfeed))
		watch(() => this.ValLogicfeed.value, (newValue, oldValue) => this.onUpdate('ufeedback.logicfeed', this.ValLogicfeed, newValue, oldValue))

		this.ValMoredetlogic = reactive(new modelFieldType.Boolean({
			id: 'ValMoredetlogic',
			originId: 'ValMoredetlogic',
			area: 'UFEEDBACK',
			field: 'MOREDETLOGIC',
			description: computed(() => this.Resources.NEED_MORE_DETAILS27800),
		}).cloneFrom(values?.ValMoredetlogic))
		watch(() => this.ValMoredetlogic.value, (newValue, oldValue) => this.onUpdate('ufeedback.moredetlogic', this.ValMoredetlogic, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormQuickfeedbackViewModel instance.
	 * @returns {QFormQuickfeedbackViewModel} A new instance of QFormQuickfeedbackViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodufeedback'

	get QPrimaryKey() { return this.ValCodufeedback.value }
	set QPrimaryKey(value) { this.ValCodufeedback.updateValue(value) }
}
