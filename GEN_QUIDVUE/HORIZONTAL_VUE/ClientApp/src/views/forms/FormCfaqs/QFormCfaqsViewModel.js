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
			name: 'CFAQS',
			area: 'CFAQS',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_CFAQS'
			}
		})

		/** The primary key. */
		this.ValCodcfaqs = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcfaqs',
			originId: 'ValCodcfaqs',
			area: 'CFAQS',
			field: 'CODCFAQS',
			description: '',
		}).cloneFrom(values?.ValCodcfaqs))
		watch(() => this.ValCodcfaqs.value, (newValue, oldValue) => this.onUpdate('cfaqs.codcfaqs', this.ValCodcfaqs, newValue, oldValue))

		/** The remaining form fields. */
		this.ValIcon = reactive(new modelFieldType.Image({
			id: 'ValIcon',
			originId: 'ValIcon',
			area: 'CFAQS',
			field: 'ICON',
			description: '',
		}).cloneFrom(values?.ValIcon))
		watch(() => this.ValIcon.value, (newValue, oldValue) => this.onUpdate('cfaqs.icon', this.ValIcon, newValue, oldValue))

		this.ValCategory = reactive(new modelFieldType.MultiLineString({
			id: 'ValCategory',
			originId: 'ValCategory',
			area: 'CFAQS',
			field: 'CATEGORY',
			description: computed(() => this.Resources.CATEGORY18978),
		}).cloneFrom(values?.ValCategory))
		watch(() => this.ValCategory.value, (newValue, oldValue) => this.onUpdate('cfaqs.category', this.ValCategory, newValue, oldValue))

		this.ValDescript = reactive(new modelFieldType.MultiLineString({
			id: 'ValDescript',
			originId: 'ValDescript',
			area: 'CFAQS',
			field: 'DESCRIPT',
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescript))
		watch(() => this.ValDescript.value, (newValue, oldValue) => this.onUpdate('cfaqs.descript', this.ValDescript, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormCfaqsViewModel instance.
	 * @returns {QFormCfaqsViewModel} A new instance of QFormCfaqsViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcfaqs'

	get QPrimaryKey() { return this.ValCodcfaqs.value }
	set QPrimaryKey(value) { this.ValCodcfaqs.updateValue(value) }
}
