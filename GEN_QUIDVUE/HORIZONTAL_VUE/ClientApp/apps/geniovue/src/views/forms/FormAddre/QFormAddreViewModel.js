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
			name: 'ADDRE',
			area: 'ADDRE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_ADDRE',
				updateFilesTickets: 'UpdateFilesTicketsADDRE'
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
			maxLength: 7,
			arrayOptions: computed(() => qProjArrays.QArrayAddressu.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.ADDRESS_USE16014),
		}).cloneFrom(values?.ValAddressuse))
		watch(() => this.ValAddressuse.value, (newValue, oldValue) => this.onUpdate('addre.addressuse', this.ValAddressuse, newValue, oldValue))

		this.ValAddresstype = reactive(new modelFieldType.String({
			id: 'ValAddresstype',
			originId: 'ValAddresstype',
			area: 'ADDRE',
			field: 'ADDRTYPE',
			maxLength: 8,
			arrayOptions: computed(() => qProjArrays.QArrayAddresst.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.ADDRESS_TYPE12455),
		}).cloneFrom(values?.ValAddresstype))
		watch(() => this.ValAddresstype.value, (newValue, oldValue) => this.onUpdate('addre.addresstype', this.ValAddresstype, newValue, oldValue))

		this.ValAddresstext = reactive(new modelFieldType.MultiLineString({
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

		this.ValAddressdistrict = reactive(new modelFieldType.String({
			id: 'ValAddressdistrict',
			originId: 'ValAddressdistrict',
			area: 'ADDRE',
			field: 'ADDRDIST',
			maxLength: 50,
			description: computed(() => this.Resources.ADDRESS_DISTRICT48524),
		}).cloneFrom(values?.ValAddressdistrict))
		watch(() => this.ValAddressdistrict.value, (newValue, oldValue) => this.onUpdate('addre.addressdistrict', this.ValAddressdistrict, newValue, oldValue))

		this.ValAddressstate = reactive(new modelFieldType.String({
			id: 'ValAddressstate',
			originId: 'ValAddressstate',
			area: 'ADDRE',
			field: 'ADDRSTAT',
			maxLength: 50,
			description: computed(() => this.Resources.ADDRESS_STATE16863),
		}).cloneFrom(values?.ValAddressstate))
		watch(() => this.ValAddressstate.value, (newValue, oldValue) => this.onUpdate('addre.addressstate', this.ValAddressstate, newValue, oldValue))

		this.ValAddresspostalcode = reactive(new modelFieldType.String({
			id: 'ValAddresspostalcode',
			originId: 'ValAddresspostalcode',
			area: 'ADDRE',
			field: 'ADDRPCOD',
			maxLength: 50,
			description: computed(() => this.Resources.ADDRESS_POSTAL_CODE41631),
		}).cloneFrom(values?.ValAddresspostalcode))
		watch(() => this.ValAddresspostalcode.value, (newValue, oldValue) => this.onUpdate('addre.addresspostalcode', this.ValAddresspostalcode, newValue, oldValue))

		this.ValAddresscountry = reactive(new modelFieldType.String({
			id: 'ValAddresscountry',
			originId: 'ValAddresscountry',
			area: 'ADDRE',
			field: 'ADDRCOUN',
			maxLength: 50,
			description: computed(() => this.Resources.ADDRESS_COUNTRY56159),
		}).cloneFrom(values?.ValAddresscountry))
		watch(() => this.ValAddresscountry.value, (newValue, oldValue) => this.onUpdate('addre.addresscountry', this.ValAddresscountry, newValue, oldValue))

		this.ValPeriodstart = reactive(new modelFieldType.DateTime({
			id: 'ValPeriodstart',
			originId: 'ValPeriodstart',
			area: 'ADDRE',
			field: 'PERISTAR',
			description: computed(() => this.Resources.PERIOD_START07901),
		}).cloneFrom(values?.ValPeriodstart))
		watch(() => this.ValPeriodstart.value, (newValue, oldValue) => this.onUpdate('addre.periodstart', this.ValPeriodstart, newValue, oldValue))

		this.ValPeriodend = reactive(new modelFieldType.DateTime({
			id: 'ValPeriodend',
			originId: 'ValPeriodend',
			area: 'ADDRE',
			field: 'PERIEND',
			description: computed(() => this.Resources.PERIOD_END31576),
		}).cloneFrom(values?.ValPeriodend))
		watch(() => this.ValPeriodend.value, (newValue, oldValue) => this.onUpdate('addre.periodend', this.ValPeriodend, newValue, oldValue))
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
	set QPrimaryKey(value) { this.ValCodaddre.updateValue(value) }
}
