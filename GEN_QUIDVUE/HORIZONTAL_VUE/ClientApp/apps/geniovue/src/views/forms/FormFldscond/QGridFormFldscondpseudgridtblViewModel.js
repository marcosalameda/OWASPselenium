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
			name: 'FLDSCONDPSEUDGRIDTBL_',
			area: 'FEECA',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_FLDSCONDPSEUDGRIDTBL_'
			}
		})

		/** The primary key. */
		this.ValCodfeeca = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodfeeca',
			originId: 'ValCodfeeca',
			area: 'FEECA',
			field: 'CODFEECA',
			description: '',
		}).cloneFrom(values?.ValCodfeeca))
		watch(() => this.ValCodfeeca.value, (newValue, oldValue) => this.onUpdate('feeca.codfeeca', this.ValCodfeeca, newValue, oldValue))

		/** The hidden foreign keys. */
		this.ValCodflds = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodflds',
			originId: 'ValCodflds',
			area: 'FEECA',
			field: 'CODFLDS',
			relatedArea: 'FLDS',
			isFixed: true,
			description: '',
		}).cloneFrom(values?.ValCodflds))
		watch(() => this.ValCodflds.value, (newValue, oldValue) => this.onUpdate('feeca.codflds', this.ValCodflds, newValue, oldValue))

		/** The remaining form fields. */
		this.ValFeedback = reactive(new modelFieldType.String({
			id: 'ValFeedback',
			originId: 'ValFeedback',
			area: 'FEECA',
			field: 'FEEDBACK',
			maxLength: 50,
			description: computed(() => this.Resources.FEEDBACK52855),
		}).cloneFrom(values?.ValFeedback))
		watch(() => this.ValFeedback.value, (newValue, oldValue) => this.onUpdate('feeca.feedback', this.ValFeedback, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QGridFormFldscondpseudgridtblViewModel instance.
	 * @returns {QGridFormFldscondpseudgridtblViewModel} A new instance of QGridFormFldscondpseudgridtblViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodfeeca'

	get QPrimaryKey() { return this.ValCodfeeca.value }
	set QPrimaryKey(value) { this.ValCodfeeca.updateValue(value) }
}
