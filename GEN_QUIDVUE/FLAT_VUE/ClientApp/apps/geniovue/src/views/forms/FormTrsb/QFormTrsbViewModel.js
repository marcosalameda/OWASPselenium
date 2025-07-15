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
			name: 'TRSB',
			area: 'TRSB',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Trsb',
				updateFilesTickets: 'UpdateFilesTicketsTrsb',
				setFile: 'SetFileTrsb'
			}
		})

		/** The primary key. */
		this.ValCodtrsb = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodtrsb',
			originId: 'ValCodtrsb',
			area: 'TRSB',
			field: 'CODTRSB',
			description: '',
		}).cloneFrom(values?.ValCodtrsb))
		this.stopWatchers.push(watch(() => this.ValCodtrsb.value, (newValue, oldValue) => this.onUpdate('trsb.codtrsb', this.ValCodtrsb, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'TRSB',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('trsb.name', this.ValName, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormTrsbViewModel instance.
	 * @returns {QFormTrsbViewModel} A new instance of QFormTrsbViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodtrsb'

	get QPrimaryKey() { return this.ValCodtrsb.value }
	set QPrimaryKey(value) { this.ValCodtrsb.updateValue(value) }
}
