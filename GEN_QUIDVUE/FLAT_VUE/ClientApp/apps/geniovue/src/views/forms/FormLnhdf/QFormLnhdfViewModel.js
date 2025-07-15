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
			name: 'LNHDF',
			area: 'LNHDF',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Lnhdf',
				updateFilesTickets: 'UpdateFilesTicketsLnhdf',
				setFile: 'SetFileLnhdf'
			}
		})

		/** The primary key. */
		this.ValCodlnhdf = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodlnhdf',
			originId: 'ValCodlnhdf',
			area: 'LNHDF',
			field: 'CODLNHDF',
			description: '',
		}).cloneFrom(values?.ValCodlnhdf))
		this.stopWatchers.push(watch(() => this.ValCodlnhdf.value, (newValue, oldValue) => this.onUpdate('lnhdf.codlnhdf', this.ValCodlnhdf, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValCodlnhde = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodlnhde',
			originId: 'ValCodlnhde',
			area: 'LNHDF',
			field: 'CODLNHDE',
			relatedArea: 'LNHDE',
			isFixed: true,
			description: '',
		}).cloneFrom(values?.ValCodlnhde))
		this.stopWatchers.push(watch(() => this.ValCodlnhde.value, (newValue, oldValue) => this.onUpdate('lnhdf.codlnhde', this.ValCodlnhde, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'LNHDF',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('lnhdf.name', this.ValName, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormLnhdfViewModel instance.
	 * @returns {QFormLnhdfViewModel} A new instance of QFormLnhdfViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodlnhdf'

	get QPrimaryKey() { return this.ValCodlnhdf.value }
	set QPrimaryKey(value) { this.ValCodlnhdf.updateValue(value) }
}
