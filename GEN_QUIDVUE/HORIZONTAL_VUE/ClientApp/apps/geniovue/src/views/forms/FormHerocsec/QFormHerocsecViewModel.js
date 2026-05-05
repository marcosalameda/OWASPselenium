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
			name: 'HEROCSEC',
			area: 'HERODESCRIP',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_HEROCSEC',
				updateFilesTickets: 'UpdateFilesTicketsHEROCSEC'
			}
		})

		/** The primary key. */
		this.ValCodherodescrip = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodherodescrip',
			originId: 'ValCodherodescrip',
			area: 'HERODESCRIP',
			field: 'CODHERODESCRIP',
			description: '',
		}).cloneFrom(values?.ValCodherodescrip))
		watch(() => this.ValCodherodescrip.value, (newValue, oldValue) => this.onUpdate('herodescrip.codherodescrip', this.ValCodherodescrip, newValue, oldValue))

		/** The remaining form fields. */
		this.ValHrdescrip = reactive(new modelFieldType.MultiLineString({
			id: 'ValHrdescrip',
			originId: 'ValHrdescrip',
			area: 'HERODESCRIP',
			field: 'HRDESCRIP',
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValHrdescrip))
		watch(() => this.ValHrdescrip.value, (newValue, oldValue) => this.onUpdate('herodescrip.hrdescrip', this.ValHrdescrip, newValue, oldValue))

		this.ValHrdescripicon = reactive(new modelFieldType.MultiLineString({
			id: 'ValHrdescripicon',
			originId: 'ValHrdescripicon',
			area: 'HERODESCRIP',
			field: 'HRDESCRIPICON',
			description: computed(() => this.Resources.DESCRIPTION_ICON05047),
		}).cloneFrom(values?.ValHrdescripicon))
		watch(() => this.ValHrdescripicon.value, (newValue, oldValue) => this.onUpdate('herodescrip.hrdescripicon', this.ValHrdescripicon, newValue, oldValue))

		this.ValHrdescripmod = reactive(new modelFieldType.MultiLineString({
			id: 'ValHrdescripmod',
			originId: 'ValHrdescripmod',
			area: 'HERODESCRIP',
			field: 'HRDESCRIPMOD',
			description: computed(() => this.Resources.DESCRIPTION_MOD40565),
		}).cloneFrom(values?.ValHrdescripmod))
		watch(() => this.ValHrdescripmod.value, (newValue, oldValue) => this.onUpdate('herodescrip.hrdescripmod', this.ValHrdescripmod, newValue, oldValue))

		this.ValHrdescripimage = reactive(new modelFieldType.MultiLineString({
			id: 'ValHrdescripimage',
			originId: 'ValHrdescripimage',
			area: 'HERODESCRIP',
			field: 'HRDESCRIPIMAGE',
			description: computed(() => this.Resources.DESCRIPTION_IMAGE56657),
		}).cloneFrom(values?.ValHrdescripimage))
		watch(() => this.ValHrdescripimage.value, (newValue, oldValue) => this.onUpdate('herodescrip.hrdescripimage', this.ValHrdescripimage, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormHerocsecViewModel instance.
	 * @returns {QFormHerocsecViewModel} A new instance of QFormHerocsecViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodherodescrip'

	get QPrimaryKey() { return this.ValCodherodescrip.value }
	set QPrimaryKey(value) { this.ValCodherodescrip.updateValue(value) }
}
