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
			name: 'OPTTABLE',
			area: 'COMPV',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_OPTTABLE',
				updateFilesTickets: 'UpdateFilesTicketsOPTTABLE'
			}
		})

		/** The primary key. */
		this.ValCodcompv = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcompv',
			originId: 'ValCodcompv',
			area: 'COMPV',
			field: 'CODCOMPV',
			description: '',
		}).cloneFrom(values?.ValCodcompv))
		watch(() => this.ValCodcompv.value, (newValue, oldValue) => this.onUpdate('compv.codcompv', this.ValCodcompv, newValue, oldValue))

		/** The hidden foreign keys. */
		this.ValCodcompo = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcompo',
			originId: 'ValCodcompo',
			area: 'COMPV',
			field: 'CODCOMPO',
			relatedArea: 'COMPO',
			isFixed: true,
			description: '',
		}).cloneFrom(values?.ValCodcompo))
		watch(() => this.ValCodcompo.value, (newValue, oldValue) => this.onUpdate('compv.codcompo', this.ValCodcompo, newValue, oldValue))

		/** The remaining form fields. */
		this.ValCompvar = reactive(new modelFieldType.String({
			id: 'ValCompvar',
			originId: 'ValCompvar',
			area: 'COMPV',
			field: 'COMPVAR',
			maxLength: 50,
			description: computed(() => this.Resources.VARIANT06375),
		}).cloneFrom(values?.ValCompvar))
		watch(() => this.ValCompvar.value, (newValue, oldValue) => this.onUpdate('compv.compvar', this.ValCompvar, newValue, oldValue))

		this.ValVaridesc = reactive(new modelFieldType.MultiLineString({
			id: 'ValVaridesc',
			originId: 'ValVaridesc',
			area: 'COMPV',
			field: 'VARIDESC',
			description: computed(() => this.Resources.VARIANT_DESCRIPTION11900),
		}).cloneFrom(values?.ValVaridesc))
		watch(() => this.ValVaridesc.value, (newValue, oldValue) => this.onUpdate('compv.varidesc', this.ValVaridesc, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormOpttableViewModel instance.
	 * @returns {QFormOpttableViewModel} A new instance of QFormOpttableViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcompv'

	get QPrimaryKey() { return this.ValCodcompv.value }
	set QPrimaryKey(value) { this.ValCodcompv.updateValue(value) }
}
