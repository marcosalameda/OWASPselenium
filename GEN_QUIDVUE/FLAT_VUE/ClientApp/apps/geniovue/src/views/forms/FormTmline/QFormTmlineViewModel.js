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
			name: 'TMLINE',
			area: 'WAREH',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_TMLINE'
			}
		})

		/** The primary key. */
		this.ValCodwareh = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodwareh',
			originId: 'ValCodwareh',
			area: 'WAREH',
			field: 'CODWAREH',
			description: '',
		}).cloneFrom(values?.ValCodwareh))
		watch(() => this.ValCodwareh.value, (newValue, oldValue) => this.onUpdate('wareh.codwareh', this.ValCodwareh, newValue, oldValue))

		/** The form fields used only in formulas. */
		this.ValWarehdes = reactive(new modelFieldType.String({
			id: 'ValWarehdes',
			originId: 'ValWarehdes',
			area: 'WAREH',
			field: 'WAREHDES',
			maxLength: 85,
			isFixed: true,
			description: computed(() => this.Resources.WAREHOUSE51864),
		}).cloneFrom(values?.ValWarehdes))
		watch(() => this.ValWarehdes.value, (newValue, oldValue) => this.onUpdate('wareh.warehdes', this.ValWarehdes, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormTmlineViewModel instance.
	 * @returns {QFormTmlineViewModel} A new instance of QFormTmlineViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodwareh'

	get QPrimaryKey() { return this.ValCodwareh.value }
	set QPrimaryKey(value) { this.ValCodwareh.updateValue(value) }
}
