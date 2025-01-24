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
			name: 'PARAM',
			area: 'PARAM',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_PARAM'
			}
		})

		/** The primary key. */
		this.ValCodparam = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodparam',
			originId: 'ValCodparam',
			area: 'PARAM',
			field: 'CODPARAM',
			description: '',
		}).cloneFrom(values?.ValCodparam))
		watch(() => this.ValCodparam.value, (newValue, oldValue) => this.onUpdate('param.codparam', this.ValCodparam, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodkinde = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodkinde',
			originId: 'ValCodkinde',
			area: 'PARAM',
			field: 'CODKINDE',
			relatedArea: 'KINDE',
			description: '',
		}).cloneFrom(values?.ValCodkinde))
		watch(() => this.ValCodkinde.value, (newValue, oldValue) => this.onUpdate('param.codkinde', this.ValCodkinde, newValue, oldValue))

		/** The remaining form fields. */
		this.TableKindeDesignat = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableKindeDesignat',
			originId: 'ValDesignat',
			area: 'KINDE',
			field: 'DESIGNAT',
			maxLength: 85,
			description: computed(() => this.Resources.KIND_OF_EQUIPMENT22928),
		}).cloneFrom(values?.TableKindeDesignat))
		watch(() => this.TableKindeDesignat.value, (newValue, oldValue) => this.onUpdate('kinde.designat', this.TableKindeDesignat, newValue, oldValue))

		this.ValParameter = reactive(new modelFieldType.String({
			id: 'ValParameter',
			originId: 'ValParameter',
			area: 'PARAM',
			field: 'PARAMETE',
			maxLength: 50,
			description: computed(() => this.Resources.PARAMETER41976),
		}).cloneFrom(values?.ValParameter))
		watch(() => this.ValParameter.value, (newValue, oldValue) => this.onUpdate('param.parameter', this.ValParameter, newValue, oldValue))

		this.ValDatatype = reactive(new modelFieldType.String({
			id: 'ValDatatype',
			originId: 'ValDatatype',
			area: 'PARAM',
			field: 'DATATYPE',
			arrayOptions: qProjArrays.QArrayDatatype.setResources(vm.$getResource).elements,
			maxLength: 1,
			description: computed(() => this.Resources.DATA_TYPE47159),
		}).cloneFrom(values?.ValDatatype))
		watch(() => this.ValDatatype.value, (newValue, oldValue) => this.onUpdate('param.datatype', this.ValDatatype, newValue, oldValue))

		this.ValDecimalplaces = reactive(new modelFieldType.Number({
			id: 'ValDecimalplaces',
			originId: 'ValDecimalplaces',
			area: 'PARAM',
			field: 'DECPLACE',
			arrayOptions: qProjArrays.QArrayDecplace.setResources(vm.$getResource).elements,
			maxDigits: 1,
			decimalDigits: 0,
			description: computed(() => this.Resources.DECIMAL_PLACES62575),
		}).cloneFrom(values?.ValDecimalplaces))
		watch(() => this.ValDecimalplaces.value, (newValue, oldValue) => this.onUpdate('param.decimalplaces', this.ValDecimalplaces, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormParamViewModel instance.
	 * @returns {QFormParamViewModel} A new instance of QFormParamViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodparam'

	get QPrimaryKey() { return this.ValCodparam.value }
	set QPrimaryKey(value) { this.ValCodparam.updateValue(value) }
}
