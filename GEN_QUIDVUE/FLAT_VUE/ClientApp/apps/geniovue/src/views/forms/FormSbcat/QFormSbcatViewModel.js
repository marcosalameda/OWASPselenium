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
			name: 'SBCAT',
			area: 'SBCAT',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Sbcat',
				updateFilesTickets: 'UpdateFilesTicketsSbcat',
				setFile: 'SetFileSbcat'
			}
		})

		/** The primary key. */
		this.ValCodsbcat = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodsbcat',
			originId: 'ValCodsbcat',
			area: 'SBCAT',
			field: 'CODSBCAT',
			description: '',
		}).cloneFrom(values?.ValCodsbcat))
		this.stopWatchers.push(watch(() => this.ValCodsbcat.value, (newValue, oldValue) => this.onUpdate('sbcat.codsbcat', this.ValCodsbcat, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValSubcateg = reactive(new modelFieldType.String({
			id: 'ValSubcateg',
			originId: 'ValSubcateg',
			area: 'SBCAT',
			field: 'SUBCATEG',
			maxLength: 50,
			description: computed(() => this.Resources.SUB_CATEGORIA15612),
		}).cloneFrom(values?.ValSubcateg))
		this.stopWatchers.push(watch(() => this.ValSubcateg.value, (newValue, oldValue) => this.onUpdate('sbcat.subcateg', this.ValSubcateg, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormSbcatViewModel instance.
	 * @returns {QFormSbcatViewModel} A new instance of QFormSbcatViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodsbcat'

	get QPrimaryKey() { return this.ValCodsbcat.value }
	set QPrimaryKey(value) { this.ValCodsbcat.updateValue(value) }
}
