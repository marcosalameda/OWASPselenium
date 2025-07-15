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
			name: 'CATEG',
			area: 'CATEG',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Categ',
				updateFilesTickets: 'UpdateFilesTicketsCateg',
				setFile: 'SetFileCateg'
			}
		})

		/** The primary key. */
		this.ValCodcateg = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcateg',
			originId: 'ValCodcateg',
			area: 'CATEG',
			field: 'CODCATEG',
			description: '',
		}).cloneFrom(values?.ValCodcateg))
		this.stopWatchers.push(watch(() => this.ValCodcateg.value, (newValue, oldValue) => this.onUpdate('categ.codcateg', this.ValCodcateg, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValCategoria = reactive(new modelFieldType.String({
			id: 'ValCategoria',
			originId: 'ValCategoria',
			area: 'CATEG',
			field: 'CATEGORY',
			maxLength: 50,
			description: computed(() => this.Resources.CATEGORY18978),
		}).cloneFrom(values?.ValCategoria))
		this.stopWatchers.push(watch(() => this.ValCategoria.value, (newValue, oldValue) => this.onUpdate('categ.categoria', this.ValCategoria, newValue, oldValue)))

		this.ValAbbreviation = reactive(new modelFieldType.String({
			id: 'ValAbbreviation',
			originId: 'ValAbbreviation',
			area: 'CATEG',
			field: 'ABBREVIA',
			maxLength: 10,
			description: computed(() => this.Resources.ABBREVIATION31267),
		}).cloneFrom(values?.ValAbbreviation))
		this.stopWatchers.push(watch(() => this.ValAbbreviation.value, (newValue, oldValue) => this.onUpdate('categ.abbreviation', this.ValAbbreviation, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormCategViewModel instance.
	 * @returns {QFormCategViewModel} A new instance of QFormCategViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcateg'

	get QPrimaryKey() { return this.ValCodcateg.value }
	set QPrimaryKey(value) { this.ValCodcateg.updateValue(value) }
}
