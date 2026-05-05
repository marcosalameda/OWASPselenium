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
			name: 'COMPBEH',
			area: 'COMPB',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_COMPBEH',
				updateFilesTickets: 'UpdateFilesTicketsCOMPBEH'
			}
		})

		/** The primary key. */
		this.ValCodcompb = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcompb',
			originId: 'ValCodcompb',
			area: 'COMPB',
			field: 'CODCOMPB',
			description: '',
		}).cloneFrom(values?.ValCodcompb))
		watch(() => this.ValCodcompb.value, (newValue, oldValue) => this.onUpdate('compb.codcompb', this.ValCodcompb, newValue, oldValue))

		/** The hidden foreign keys. */
		this.ValCodcompo = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcompo',
			originId: 'ValCodcompo',
			area: 'COMPB',
			field: 'CODCOMPO',
			relatedArea: 'COMPO',
			isFixed: true,
			description: '',
		}).cloneFrom(values?.ValCodcompo))
		watch(() => this.ValCodcompo.value, (newValue, oldValue) => this.onUpdate('compb.codcompo', this.ValCodcompo, newValue, oldValue))

		/** The remaining form fields. */
		this.ValCompint = reactive(new modelFieldType.String({
			id: 'ValCompint',
			originId: 'ValCompint',
			area: 'COMPB',
			field: 'COMPINT',
			maxLength: 50,
			description: computed(() => this.Resources.INTERACTION46097),
		}).cloneFrom(values?.ValCompint))
		watch(() => this.ValCompint.value, (newValue, oldValue) => this.onUpdate('compb.compint', this.ValCompint, newValue, oldValue))

		this.ValCmpbehav = reactive(new modelFieldType.MultiLineString({
			id: 'ValCmpbehav',
			originId: 'ValCmpbehav',
			area: 'COMPB',
			field: 'CMPBEHAV',
			description: computed(() => this.Resources.BEHAVIOR47966),
		}).cloneFrom(values?.ValCmpbehav))
		watch(() => this.ValCmpbehav.value, (newValue, oldValue) => this.onUpdate('compb.cmpbehav', this.ValCmpbehav, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormCompbehViewModel instance.
	 * @returns {QFormCompbehViewModel} A new instance of QFormCompbehViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcompb'

	get QPrimaryKey() { return this.ValCodcompb.value }
	set QPrimaryKey(value) { this.ValCodcompb.updateValue(value) }
}
