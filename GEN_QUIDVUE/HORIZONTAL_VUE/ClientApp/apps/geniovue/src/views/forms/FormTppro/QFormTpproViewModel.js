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
			name: 'TPPRO',
			area: 'TPPRO',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Tppro',
				updateFilesTickets: 'UpdateFilesTicketsTppro',
				setFile: 'SetFileTppro'
			}
		})

		/** The primary key. */
		this.ValCodtppro = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodtppro',
			originId: 'ValCodtppro',
			area: 'TPPRO',
			field: 'CODTPPRO',
			description: '',
		}).cloneFrom(values?.ValCodtppro))
		this.stopWatchers.push(watch(() => this.ValCodtppro.value, (newValue, oldValue) => this.onUpdate('tppro.codtppro', this.ValCodtppro, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValTppropri = reactive(new modelFieldType.String({
			id: 'ValTppropri',
			originId: 'ValTppropri',
			area: 'TPPRO',
			field: 'TPPROPRI',
			maxLength: 20,
			description: computed(() => this.Resources.PROPERTY_TYPE51419),
		}).cloneFrom(values?.ValTppropri))
		this.stopWatchers.push(watch(() => this.ValTppropri.value, (newValue, oldValue) => this.onUpdate('tppro.tppropri', this.ValTppropri, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormTpproViewModel instance.
	 * @returns {QFormTpproViewModel} A new instance of QFormTpproViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodtppro'

	get QPrimaryKey() { return this.ValCodtppro.value }
	set QPrimaryKey(value) { this.ValCodtppro.updateValue(value) }
}
