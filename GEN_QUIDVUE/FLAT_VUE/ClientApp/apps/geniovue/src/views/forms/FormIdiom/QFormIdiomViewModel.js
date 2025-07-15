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
			name: 'IDIOM',
			area: 'LANGU',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Idiom',
				updateFilesTickets: 'UpdateFilesTicketsIdiom',
				setFile: 'SetFileIdiom'
			}
		})

		/** The primary key. */
		this.ValCodlang = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodlang',
			originId: 'ValCodlang',
			area: 'LANGU',
			field: 'CODLANG',
			description: '',
		}).cloneFrom(values?.ValCodlang))
		this.stopWatchers.push(watch(() => this.ValCodlang.value, (newValue, oldValue) => this.onUpdate('langu.codlang', this.ValCodlang, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValLangua = reactive(new modelFieldType.String({
			id: 'ValLangua',
			originId: 'ValLangua',
			area: 'LANGU',
			field: 'LANGUA',
			maxLength: 50,
			description: computed(() => this.Resources.LANGUAGE16872),
		}).cloneFrom(values?.ValLangua))
		this.stopWatchers.push(watch(() => this.ValLangua.value, (newValue, oldValue) => this.onUpdate('langu.langua', this.ValLangua, newValue, oldValue)))

		this.ValAcron = reactive(new modelFieldType.String({
			id: 'ValAcron',
			originId: 'ValAcron',
			area: 'LANGU',
			field: 'ACRON',
			maxLength: 5,
			description: computed(() => this.Resources.ACRONYM00872),
		}).cloneFrom(values?.ValAcron))
		this.stopWatchers.push(watch(() => this.ValAcron.value, (newValue, oldValue) => this.onUpdate('langu.acron', this.ValAcron, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormIdiomViewModel instance.
	 * @returns {QFormIdiomViewModel} A new instance of QFormIdiomViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodlang'

	get QPrimaryKey() { return this.ValCodlang.value }
	set QPrimaryKey(value) { this.ValCodlang.updateValue(value) }
}
