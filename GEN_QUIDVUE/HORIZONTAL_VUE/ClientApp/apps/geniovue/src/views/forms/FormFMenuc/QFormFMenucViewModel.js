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
			name: 'F_MENUC',
			area: 'MENUC',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_MENUC',
				updateFilesTickets: 'UpdateFilesTicketsF_MENUC'
			}
		})

		/** The primary key. */
		this.ValCodmenuc = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodmenuc',
			originId: 'ValCodmenuc',
			area: 'MENUC',
			field: 'CODMENUC',
			description: '',
		}).cloneFrom(values?.ValCodmenuc))
		watch(() => this.ValCodmenuc.value, (newValue, oldValue) => this.onUpdate('menuc.codmenuc', this.ValCodmenuc, newValue, oldValue))

		/** The remaining form fields. */
		this.ValMenucl = reactive(new modelFieldType.String({
			id: 'ValMenucl',
			originId: 'ValMenucl',
			area: 'MENUC',
			field: 'MENUCL',
			maxLength: 50,
			description: computed(() => this.Resources.MENU_ITEM_CLASS00317),
		}).cloneFrom(values?.ValMenucl))
		watch(() => this.ValMenucl.value, (newValue, oldValue) => this.onUpdate('menuc.menucl', this.ValMenucl, newValue, oldValue))

		this.ValOrder = reactive(new modelFieldType.Number({
			id: 'ValOrder',
			originId: 'ValOrder',
			area: 'MENUC',
			field: 'ORDER',
			maxDigits: 2,
			decimalDigits: 0,
			description: computed(() => this.Resources.ORDER39632),
		}).cloneFrom(values?.ValOrder))
		watch(() => this.ValOrder.value, (newValue, oldValue) => this.onUpdate('menuc.order', this.ValOrder, newValue, oldValue))

		this.ValCldesc = reactive(new modelFieldType.MultiLineString({
			id: 'ValCldesc',
			originId: 'ValCldesc',
			area: 'MENUC',
			field: 'CLDESC',
			description: computed(() => this.Resources.CLASS_DESCRIPTION30131),
		}).cloneFrom(values?.ValCldesc))
		watch(() => this.ValCldesc.value, (newValue, oldValue) => this.onUpdate('menuc.cldesc', this.ValCldesc, newValue, oldValue))

		this.ValIcon = reactive(new modelFieldType.Image({
			id: 'ValIcon',
			originId: 'ValIcon',
			area: 'MENUC',
			field: 'ICON',
			description: computed(() => this.Resources.CLASS_ICON65216),
		}).cloneFrom(values?.ValIcon))
		watch(() => this.ValIcon.value, (newValue, oldValue) => this.onUpdate('menuc.icon', this.ValIcon, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormFMenucViewModel instance.
	 * @returns {QFormFMenucViewModel} A new instance of QFormFMenucViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodmenuc'

	get QPrimaryKey() { return this.ValCodmenuc.value }
	set QPrimaryKey(value) { this.ValCodmenuc.updateValue(value) }
}
