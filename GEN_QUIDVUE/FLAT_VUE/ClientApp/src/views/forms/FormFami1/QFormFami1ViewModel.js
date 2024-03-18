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
			name: 'FAMI1',
			area: 'FAMI1',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_FAMI1'
			}
		})

		/** The primary key. */
		this.ValCodfamil = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodfamil',
			originId: 'ValCodfamil',
			area: 'FAMI1',
			field: 'CODFAMIL',
			description: '',
		}).cloneFrom(values?.ValCodfamil))
		watch(() => this.ValCodfamil.value, (newValue, oldValue) => this.onUpdate('fami1.codfamil', this.ValCodfamil, newValue, oldValue))

		/** The remaining form fields. */
		this.ValFamily = reactive(new modelFieldType.String({
			id: 'ValFamily',
			originId: 'ValFamily',
			area: 'FAMI1',
			field: 'FAMILY',
			maxLength: 50,
			description: computed(() => this.Resources.EQUIPMENT_FAMILY41883),
		}).cloneFrom(values?.ValFamily))
		watch(() => this.ValFamily.value, (newValue, oldValue) => this.onUpdate('fami1.family', this.ValFamily, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormFami1ViewModel instance.
	 * @returns {QFormFami1ViewModel} A new instance of QFormFami1ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodfamil'

	get QPrimaryKey() { return this.ValCodfamil.value }
	set QPrimaryKey(value) { this.ValCodfamil.value = value }
}
