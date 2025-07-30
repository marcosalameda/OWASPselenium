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
			name: 'PARAM',
			area: 'PARAM',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Param',
				updateFilesTickets: 'UpdateFilesTicketsParam',
				setFile: 'SetFileParam'
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
		this.stopWatchers.push(watch(() => this.ValCodparam.value, (newValue, oldValue) => this.onUpdate('param.codparam', this.ValCodparam, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodkinde = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodkinde',
			originId: 'ValCodkinde',
			area: 'PARAM',
			field: 'CODKINDE',
			relatedArea: 'KINDE',
			description: '',
		}).cloneFrom(values?.ValCodkinde))
		this.stopWatchers.push(watch(() => this.ValCodkinde.value, (newValue, oldValue) => this.onUpdate('param.codkinde', this.ValCodkinde, newValue, oldValue)))

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
		this.stopWatchers.push(watch(() => this.TableKindeDesignat.value, (newValue, oldValue) => this.onUpdate('kinde.designat', this.TableKindeDesignat, newValue, oldValue)))

		this.ValParameter = reactive(new modelFieldType.String({
			id: 'ValParameter',
			originId: 'ValParameter',
			area: 'PARAM',
			field: 'PARAMETE',
			maxLength: 50,
			description: computed(() => this.Resources.PARAMETER41976),
		}).cloneFrom(values?.ValParameter))
		this.stopWatchers.push(watch(() => this.ValParameter.value, (newValue, oldValue) => this.onUpdate('param.parameter', this.ValParameter, newValue, oldValue)))

		this.ValDatatype = reactive(new modelFieldType.String({
			id: 'ValDatatype',
			originId: 'ValDatatype',
			area: 'PARAM',
			field: 'DATATYPE',
			maxLength: 1,
			arrayOptions: computed(() => new qProjArrays.QArrayDatatype(vm.$getResource).elements),
			description: computed(() => this.Resources.DATA_TYPE47159),
		}).cloneFrom(values?.ValDatatype))
		this.stopWatchers.push(watch(() => this.ValDatatype.value, (newValue, oldValue) => this.onUpdate('param.datatype', this.ValDatatype, newValue, oldValue)))

		this.ValDecimalplaces = reactive(new modelFieldType.Number({
			id: 'ValDecimalplaces',
			originId: 'ValDecimalplaces',
			area: 'PARAM',
			field: 'DECPLACE',
			maxDigits: 1,
			decimalDigits: 0,
			arrayOptions: computed(() => new qProjArrays.QArrayDecplace(vm.$getResource).elements),
			description: computed(() => this.Resources.DECIMAL_PLACES62575),
		}).cloneFrom(values?.ValDecimalplaces))
		this.stopWatchers.push(watch(() => this.ValDecimalplaces.value, (newValue, oldValue) => this.onUpdate('param.decimalplaces', this.ValDecimalplaces, newValue, oldValue)))
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
