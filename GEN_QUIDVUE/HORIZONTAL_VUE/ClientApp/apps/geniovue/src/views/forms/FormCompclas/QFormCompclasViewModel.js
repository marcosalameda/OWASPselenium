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
			name: 'COMPCLAS',
			area: 'COMPC',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_COMPCLAS',
				updateFilesTickets: 'UpdateFilesTicketsCOMPCLAS'
			}
		})

		/** The primary key. */
		this.ValCodcompc = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcompc',
			originId: 'ValCodcompc',
			area: 'COMPC',
			field: 'CODCOMPC',
			description: '',
		}).cloneFrom(values?.ValCodcompc))
		watch(() => this.ValCodcompc.value, (newValue, oldValue) => this.onUpdate('compc.codcompc', this.ValCodcompc, newValue, oldValue))

		/** The remaining form fields. */
		this.ValCompclas = reactive(new modelFieldType.String({
			id: 'ValCompclas',
			originId: 'ValCompclas',
			area: 'COMPC',
			field: 'COMPCLAS',
			maxLength: 50,
			description: computed(() => this.Resources.COMPONENTS_CLASS59339),
		}).cloneFrom(values?.ValCompclas))
		watch(() => this.ValCompclas.value, (newValue, oldValue) => this.onUpdate('compc.compclas', this.ValCompclas, newValue, oldValue))

		this.ValClassico = reactive(new modelFieldType.Image({
			id: 'ValClassico',
			originId: 'ValClassico',
			area: 'COMPC',
			field: 'CLASSICO',
			description: computed(() => this.Resources.CLASS_ICON19969),
		}).cloneFrom(values?.ValClassico))
		watch(() => this.ValClassico.value, (newValue, oldValue) => this.onUpdate('compc.classico', this.ValClassico, newValue, oldValue))

		this.ValClassdes = reactive(new modelFieldType.MultiLineString({
			id: 'ValClassdes',
			originId: 'ValClassdes',
			area: 'COMPC',
			field: 'CLASSDES',
			description: computed(() => this.Resources.CLASS_DESCRIPTION30131),
		}).cloneFrom(values?.ValClassdes))
		watch(() => this.ValClassdes.value, (newValue, oldValue) => this.onUpdate('compc.classdes', this.ValClassdes, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormCompclasViewModel instance.
	 * @returns {QFormCompclasViewModel} A new instance of QFormCompclasViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcompc'

	get QPrimaryKey() { return this.ValCodcompc.value }
	set QPrimaryKey(value) { this.ValCodcompc.updateValue(value) }
}
