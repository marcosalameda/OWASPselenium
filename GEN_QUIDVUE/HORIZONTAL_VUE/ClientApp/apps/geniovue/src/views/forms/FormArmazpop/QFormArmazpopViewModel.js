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
			name: 'ARMAZPOP',
			area: 'WAREH',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_ARMAZPOP',
				updateFilesTickets: 'UpdateFilesTicketsARMAZPOP'
			}
		})

		/** The primary key. */
		this.ValCodwareh = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodwareh',
			originId: 'ValCodwareh',
			area: 'WAREH',
			field: 'CODWAREH',
			description: '',
		}).cloneFrom(values?.ValCodwareh))
		watch(() => this.ValCodwareh.value, (newValue, oldValue) => this.onUpdate('wareh.codwareh', this.ValCodwareh, newValue, oldValue))

		/** The remaining form fields. */
		this.ValWarehcod = reactive(new modelFieldType.String({
			id: 'ValWarehcod',
			originId: 'ValWarehcod',
			area: 'WAREH',
			field: 'WAREHCOD',
			maxLength: 10,
			description: computed(() => this.Resources.ACRONYM00872),
		}).cloneFrom(values?.ValWarehcod))
		watch(() => this.ValWarehcod.value, (newValue, oldValue) => this.onUpdate('wareh.warehcod', this.ValWarehcod, newValue, oldValue))

		this.ValActivity = reactive(new modelFieldType.Number({
			id: 'ValActivity',
			originId: 'ValActivity',
			area: 'WAREH',
			field: 'ACTIVITY',
			maxDigits: 1,
			decimalDigits: 0,
			description: computed(() => this.Resources.ACTIVITY02681),
		}).cloneFrom(values?.ValActivity))
		watch(() => this.ValActivity.value, (newValue, oldValue) => this.onUpdate('wareh.activity', this.ValActivity, newValue, oldValue))

		this.ValWarehdes = reactive(new modelFieldType.String({
			id: 'ValWarehdes',
			originId: 'ValWarehdes',
			area: 'WAREH',
			field: 'WAREHDES',
			maxLength: 85,
			description: computed(() => this.Resources.WAREHOUSE51864),
		}).cloneFrom(values?.ValWarehdes))
		watch(() => this.ValWarehdes.value, (newValue, oldValue) => this.onUpdate('wareh.warehdes', this.ValWarehdes, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormArmazpopViewModel instance.
	 * @returns {QFormArmazpopViewModel} A new instance of QFormArmazpopViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodwareh'

	get QPrimaryKey() { return this.ValCodwareh.value }
	set QPrimaryKey(value) { this.ValCodwareh.updateValue(value) }
}
