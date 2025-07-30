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
			name: 'ESPEC',
			area: 'SPECI',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Espec',
				updateFilesTickets: 'UpdateFilesTicketsEspec',
				setFile: 'SetFileEspec'
			}
		})

		/** The primary key. */
		this.ValCodespec = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodespec',
			originId: 'ValCodespec',
			area: 'SPECI',
			field: 'CODESPEC',
			description: '',
		}).cloneFrom(values?.ValCodespec))
		this.stopWatchers.push(watch(() => this.ValCodespec.value, (newValue, oldValue) => this.onUpdate('speci.codespec', this.ValCodespec, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValEspecial = reactive(new modelFieldType.String({
			id: 'ValEspecial',
			originId: 'ValEspecial',
			area: 'SPECI',
			field: 'ESPECIAL',
			maxLength: 50,
			description: computed(() => this.Resources.SPECIALTY09304),
		}).cloneFrom(values?.ValEspecial))
		this.stopWatchers.push(watch(() => this.ValEspecial.value, (newValue, oldValue) => this.onUpdate('speci.especial', this.ValEspecial, newValue, oldValue)))

		this.ValAreatecn = reactive(new modelFieldType.String({
			id: 'ValAreatecn',
			originId: 'ValAreatecn',
			area: 'SPECI',
			field: 'AREATECN',
			maxLength: 1,
			arrayOptions: computed(() => new qProjArrays.QArrayAreatecn(vm.$getResource).elements),
			description: computed(() => this.Resources.TECHNICAL_AREA50773),
		}).cloneFrom(values?.ValAreatecn))
		this.stopWatchers.push(watch(() => this.ValAreatecn.value, (newValue, oldValue) => this.onUpdate('speci.areatecn', this.ValAreatecn, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormEspecViewModel instance.
	 * @returns {QFormEspecViewModel} A new instance of QFormEspecViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodespec'

	get QPrimaryKey() { return this.ValCodespec.value }
	set QPrimaryKey(value) { this.ValCodespec.updateValue(value) }
}
