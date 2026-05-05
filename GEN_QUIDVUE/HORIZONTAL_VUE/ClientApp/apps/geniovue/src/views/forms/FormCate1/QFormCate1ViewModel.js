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
			name: 'CATE1',
			area: 'CATE1',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_CATE1',
				updateFilesTickets: 'UpdateFilesTicketsCATE1'
			}
		})

		/** The primary key. */
		this.ValCodcateg = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcateg',
			originId: 'ValCodcateg',
			area: 'CATE1',
			field: 'CODCATEG',
			description: '',
		}).cloneFrom(values?.ValCodcateg))
		watch(() => this.ValCodcateg.value, (newValue, oldValue) => this.onUpdate('cate1.codcateg', this.ValCodcateg, newValue, oldValue))

		/** The remaining form fields. */
		this.ValAbbreviation = reactive(new modelFieldType.String({
			id: 'ValAbbreviation',
			originId: 'ValAbbreviation',
			area: 'CATE1',
			field: 'ABBREVIA',
			maxLength: 10,
			description: computed(() => this.Resources.ABBREVIATION31267),
		}).cloneFrom(values?.ValAbbreviation))
		watch(() => this.ValAbbreviation.value, (newValue, oldValue) => this.onUpdate('cate1.abbreviation', this.ValAbbreviation, newValue, oldValue))

		this.ValCategoria = reactive(new modelFieldType.String({
			id: 'ValCategoria',
			originId: 'ValCategoria',
			area: 'CATE1',
			field: 'CATEGORY',
			maxLength: 50,
			description: computed(() => this.Resources.CATEGORY18978),
		}).cloneFrom(values?.ValCategoria))
		watch(() => this.ValCategoria.value, (newValue, oldValue) => this.onUpdate('cate1.categoria', this.ValCategoria, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormCate1ViewModel instance.
	 * @returns {QFormCate1ViewModel} A new instance of QFormCate1ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcateg'

	get QPrimaryKey() { return this.ValCodcateg.value }
	set QPrimaryKey(value) { this.ValCodcateg.updateValue(value) }
}
