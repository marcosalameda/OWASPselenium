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
			name: 'REGIS',
			area: 'REGIS',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_REGIS',
				updateFilesTickets: 'UpdateFilesTicketsREGIS'
			}
		})

		/** The primary key. */
		this.ValCodregis = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodregis',
			originId: 'ValCodregis',
			area: 'REGIS',
			field: 'CODREGIS',
			description: '',
		}).cloneFrom(values?.ValCodregis))
		watch(() => this.ValCodregis.value, (newValue, oldValue) => this.onUpdate('regis.codregis', this.ValCodregis, newValue, oldValue))

		/** The remaining form fields. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'REGIS',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('regis.name', this.ValName, newValue, oldValue))

		this.ValNif = reactive(new modelFieldType.String({
			id: 'ValNif',
			originId: 'ValNif',
			area: 'REGIS',
			field: 'NIF',
			maxLength: 20,
			description: computed(() => this.Resources.TAX_IDENTIFICATION_N63094),
		}).cloneFrom(values?.ValNif))
		watch(() => this.ValNif.value, (newValue, oldValue) => this.onUpdate('regis.nif', this.ValNif, newValue, oldValue))

		this.ValTelephon = reactive(new modelFieldType.String({
			id: 'ValTelephon',
			originId: 'ValTelephon',
			area: 'REGIS',
			field: 'TELEPHON',
			maxLength: 15,
			description: computed(() => this.Resources.PHONE56703),
		}).cloneFrom(values?.ValTelephon))
		watch(() => this.ValTelephon.value, (newValue, oldValue) => this.onUpdate('regis.telephon', this.ValTelephon, newValue, oldValue))

		this.ValEmail1 = reactive(new modelFieldType.String({
			id: 'ValEmail1',
			originId: 'ValEmail1',
			area: 'REGIS',
			field: 'EMAIL1',
			maxLength: 254,
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.ValEmail1))
		watch(() => this.ValEmail1.value, (newValue, oldValue) => this.onUpdate('regis.email1', this.ValEmail1, newValue, oldValue))

		this.ValEmail2 = reactive(new modelFieldType.String({
			id: 'ValEmail2',
			originId: 'ValEmail2',
			area: 'REGIS',
			field: 'EMAIL2',
			maxLength: 254,
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.ValEmail2))
		watch(() => this.ValEmail2.value, (newValue, oldValue) => this.onUpdate('regis.email2', this.ValEmail2, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormRegisViewModel instance.
	 * @returns {QFormRegisViewModel} A new instance of QFormRegisViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodregis'

	get QPrimaryKey() { return this.ValCodregis.value }
	set QPrimaryKey(value) { this.ValCodregis.updateValue(value) }
}
