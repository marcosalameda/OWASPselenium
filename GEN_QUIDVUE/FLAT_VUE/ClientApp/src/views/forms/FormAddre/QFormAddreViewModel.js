/* eslint-disable no-unused-vars */
import { computed, reactive, watch } from 'vue'
import _merge from 'lodash-es/merge'

import ViewModelBase from '@/mixins/formViewModelBase.js'
import genericFunctions from '@/mixins/genericFunctions.js'
import modelFieldType from '@/mixins/formModelFieldTypes.js'

import hardcodedTexts from '@/hardcodedTexts.js'
import netAPI from '@/api/network'
import qApi from '@/api/genio/quidgestFunctions.js'
import qFunctions from '@/api/genio/projectFunctions.js'
import qProjArrays from '@/api/genio/projectArrays.js'
/* eslint-enable no-unused-vars */

/**
 * Represents a ViewModel class.
 * @extends ViewModelBase
 */
export default class ViewModel extends ViewModelBase
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

		/** The view model metadata */
		_merge(this.modelInfo, {
			name: 'ADDRE',
			area: 'ADDRE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_ADDRE'
			}
		})

		/** The primary key. */
		this.ValCodaddre = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodaddre',
			originId: 'ValCodaddre',
			area: 'ADDRE',
			field: 'CODADDRE',
			description: '',
		}).cloneFrom(values?.ValCodaddre))
		watch(() => this.ValCodaddre.value, (newValue, oldValue) => this.onUpdate('addre.codaddre', this.ValCodaddre, newValue, oldValue))

		/** The remaining form fields. */
		this.ValAddressuse = reactive(new modelFieldType.String({
			id: 'ValAddressuse',
			originId: 'ValAddressuse',
			area: 'ADDRE',
			field: 'ADDRUSE',
			arrayOptions: qProjArrays.QArrayAddressu.setResources(vm.$getResource).elements,
			maxLength: 7,
			description: computed(() => this.Resources.ADDRESS_USE16014),
		}).cloneFrom(values?.ValAddressuse))
		watch(() => this.ValAddressuse.value, (newValue, oldValue) => this.onUpdate('addre.addressuse', this.ValAddressuse, newValue, oldValue))

		this.ValAddresstype = reactive(new modelFieldType.String({
			id: 'ValAddresstype',
			originId: 'ValAddresstype',
			area: 'ADDRE',
			field: 'ADDRTYPE',
			arrayOptions: qProjArrays.QArrayAddresst.setResources(vm.$getResource).elements,
			maxLength: 8,
			description: computed(() => this.Resources.ADDRESS_TYPE12455),
		}).cloneFrom(values?.ValAddresstype))
		watch(() => this.ValAddresstype.value, (newValue, oldValue) => this.onUpdate('addre.addresstype', this.ValAddresstype, newValue, oldValue))

		this.ValAddresstext = reactive(new modelFieldType.String({
			id: 'ValAddresstext',
			originId: 'ValAddresstext',
			area: 'ADDRE',
			field: 'ADDRTEXT',
			description: computed(() => this.Resources.ENTIRE_ADDRESS64248),
		}).cloneFrom(values?.ValAddresstext))
		watch(() => this.ValAddresstext.value, (newValue, oldValue) => this.onUpdate('addre.addresstext', this.ValAddresstext, newValue, oldValue))

		this.ValAddresscity = reactive(new modelFieldType.String({
			id: 'ValAddresscity',
			originId: 'ValAddresscity',
			area: 'ADDRE',
			field: 'ADDRCITY',
			maxLength: 50,
			description: computed(() => this.Resources.ADDRESS_CITY41109),
		}).cloneFrom(values?.ValAddresscity))
		watch(() => this.ValAddresscity.value, (newValue, oldValue) => this.onUpdate('addre.addresscity', this.ValAddresscity, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormAddreViewModel instance.
	 * @returns {QFormAddreViewModel} A new instance of QFormAddreViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodaddre'

	get QPrimaryKey() { return this.ValCodaddre.value }
	set QPrimaryKey(value) { this.ValCodaddre.value = value }
}
