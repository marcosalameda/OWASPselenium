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
			name: 'KINDE',
			area: 'KINDE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Kinde',
				updateFilesTickets: 'UpdateFilesTicketsKinde',
				setFile: 'SetFileKinde'
			}
		})

		/** The primary key. */
		this.ValCodkinde = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodkinde',
			originId: 'ValCodkinde',
			area: 'KINDE',
			field: 'CODKINDE',
			description: '',
		}).cloneFrom(values?.ValCodkinde))
		this.stopWatchers.push(watch(() => this.ValCodkinde.value, (newValue, oldValue) => this.onUpdate('kinde.codkinde', this.ValCodkinde, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValDesignat = reactive(new modelFieldType.String({
			id: 'ValDesignat',
			originId: 'ValDesignat',
			area: 'KINDE',
			field: 'DESIGNAT',
			maxLength: 85,
			description: computed(() => this.Resources.KIND_OF_EQUIPMENT22928),
		}).cloneFrom(values?.ValDesignat))
		this.stopWatchers.push(watch(() => this.ValDesignat.value, (newValue, oldValue) => this.onUpdate('kinde.designat', this.ValDesignat, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormKindeViewModel instance.
	 * @returns {QFormKindeViewModel} A new instance of QFormKindeViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodkinde'

	get QPrimaryKey() { return this.ValCodkinde.value }
	set QPrimaryKey(value) { this.ValCodkinde.updateValue(value) }
}
