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
			name: 'ROGL1',
			area: 'ROGL1',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_ROGL1',
				updateFilesTickets: 'UpdateFilesTicketsROGL1'
			}
		})

		/** The primary key. */
		this.ValCodrogl1 = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodrogl1',
			originId: 'ValCodrogl1',
			area: 'ROGL1',
			field: 'CODROGL1',
			description: '',
		}).cloneFrom(values?.ValCodrogl1))
		watch(() => this.ValCodrogl1.value, (newValue, oldValue) => this.onUpdate('rogl1.codrogl1', this.ValCodrogl1, newValue, oldValue))

		/** The remaining form fields. */
		this.ValTitle = reactive(new modelFieldType.String({
			id: 'ValTitle',
			originId: 'ValTitle',
			area: 'ROGL1',
			field: 'TITLE',
			maxLength: 50,
			description: computed(() => this.Resources.TITLE21885),
		}).cloneFrom(values?.ValTitle))
		watch(() => this.ValTitle.value, (newValue, oldValue) => this.onUpdate('rogl1.title', this.ValTitle, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormRogl1ViewModel instance.
	 * @returns {QFormRogl1ViewModel} A new instance of QFormRogl1ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodrogl1'

	get QPrimaryKey() { return this.ValCodrogl1.value }
	set QPrimaryKey(value) { this.ValCodrogl1.updateValue(value) }
}
