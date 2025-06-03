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
			name: 'ESPEC',
			area: 'SPECI',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_ESPEC'
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
		watch(() => this.ValCodespec.value, (newValue, oldValue) => this.onUpdate('speci.codespec', this.ValCodespec, newValue, oldValue))

		/** The remaining form fields. */
		this.ValEspecial = reactive(new modelFieldType.String({
			id: 'ValEspecial',
			originId: 'ValEspecial',
			area: 'SPECI',
			field: 'ESPECIAL',
			maxLength: 50,
			description: computed(() => this.Resources.SPECIALTY09304),
		}).cloneFrom(values?.ValEspecial))
		watch(() => this.ValEspecial.value, (newValue, oldValue) => this.onUpdate('speci.especial', this.ValEspecial, newValue, oldValue))

		this.ValAreatecn = reactive(new modelFieldType.String({
			id: 'ValAreatecn',
			originId: 'ValAreatecn',
			area: 'SPECI',
			field: 'AREATECN',
			maxLength: 1,
			arrayOptions: computed(() => qProjArrays.QArrayAreatecn.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.TECHNICAL_AREA50773),
		}).cloneFrom(values?.ValAreatecn))
		watch(() => this.ValAreatecn.value, (newValue, oldValue) => this.onUpdate('speci.areatecn', this.ValAreatecn, newValue, oldValue))
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
