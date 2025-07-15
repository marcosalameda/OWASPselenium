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
				recalculateFormulas: 'RecalculateFormulas_Addre',
				updateFilesTickets: 'UpdateFilesTicketsAddre',
				setFile: 'SetFileAddre'
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
		this.stopWatchers.push(watch(() => this.ValCodaddre.value, (newValue, oldValue) => this.onUpdate('addre.codaddre', this.ValCodaddre, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValAddressuse = reactive(new modelFieldType.String({
			id: 'ValAddressuse',
			originId: 'ValAddressuse',
			area: 'ADDRE',
			field: 'ADDRUSE',
			maxLength: 7,
			arrayOptions: computed(() => new qProjArrays.QArrayAddressu(vm.$getResource).elements),
			description: computed(() => this.Resources.ADDRESS_USE16014),
		}).cloneFrom(values?.ValAddressuse))
		this.stopWatchers.push(watch(() => this.ValAddressuse.value, (newValue, oldValue) => this.onUpdate('addre.addressuse', this.ValAddressuse, newValue, oldValue)))

		this.ValAddresstype = reactive(new modelFieldType.String({
			id: 'ValAddresstype',
			originId: 'ValAddresstype',
			area: 'ADDRE',
			field: 'ADDRTYPE',
			maxLength: 8,
			arrayOptions: computed(() => new qProjArrays.QArrayAddresst(vm.$getResource).elements),
			description: computed(() => this.Resources.ADDRESS_TYPE12455),
		}).cloneFrom(values?.ValAddresstype))
		this.stopWatchers.push(watch(() => this.ValAddresstype.value, (newValue, oldValue) => this.onUpdate('addre.addresstype', this.ValAddresstype, newValue, oldValue)))

		this.ValAddresstext = reactive(new modelFieldType.MultiLineString({
			id: 'ValAddresstext',
			originId: 'ValAddresstext',
			area: 'ADDRE',
			field: 'ADDRTEXT',
			description: computed(() => this.Resources.ENTIRE_ADDRESS64248),
		}).cloneFrom(values?.ValAddresstext))
		this.stopWatchers.push(watch(() => this.ValAddresstext.value, (newValue, oldValue) => this.onUpdate('addre.addresstext', this.ValAddresstext, newValue, oldValue)))

		this.ValAddresscity = reactive(new modelFieldType.String({
			id: 'ValAddresscity',
			originId: 'ValAddresscity',
			area: 'ADDRE',
			field: 'ADDRCITY',
			maxLength: 50,
			description: computed(() => this.Resources.ADDRESS_CITY41109),
		}).cloneFrom(values?.ValAddresscity))
		this.stopWatchers.push(watch(() => this.ValAddresscity.value, (newValue, oldValue) => this.onUpdate('addre.addresscity', this.ValAddresscity, newValue, oldValue)))

		/** The form fields used only in formulas. */
		this.ValPeriodstart = reactive(new modelFieldType.DateTime({
			id: 'ValPeriodstart',
			originId: 'ValPeriodstart',
			area: 'ADDRE',
			field: 'PERISTAR',
			isFixed: true,
			description: computed(() => this.Resources.PERIOD_START07901),
		}).cloneFrom(values?.ValPeriodstart))
		this.stopWatchers.push(watch(() => this.ValPeriodstart.value, (newValue, oldValue) => this.onUpdate('addre.periodstart', this.ValPeriodstart, newValue, oldValue)))

		this.ValPeriodend = reactive(new modelFieldType.DateTime({
			id: 'ValPeriodend',
			originId: 'ValPeriodend',
			area: 'ADDRE',
			field: 'PERIEND',
			isFixed: true,
			description: computed(() => this.Resources.PERIOD_END31576),
		}).cloneFrom(values?.ValPeriodend))
		this.stopWatchers.push(watch(() => this.ValPeriodend.value, (newValue, oldValue) => this.onUpdate('addre.periodend', this.ValPeriodend, newValue, oldValue)))
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
