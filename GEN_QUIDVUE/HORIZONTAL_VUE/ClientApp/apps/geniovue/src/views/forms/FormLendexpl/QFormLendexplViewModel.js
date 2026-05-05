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
			name: 'LENDEXPL',
			area: 'Home',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_LENDEXPL',
				updateFilesTickets: 'UpdateFilesTicketsLENDEXPL'
			}
		})


		/** The remaining form fields. */
		this.Pess1ValGender = reactive(new modelFieldType.String({
			type: 'FormFilter',
			id: 'Pess1ValGender',
			originId: 'ValGender',
			area: 'PESS1',
			field: 'GENDER',
			maxLength: 1,
			arrayOptions: computed(() => qProjArrays.QArrayGenero.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.GENRE63303),
		}).cloneFrom(values?.Pess1ValGender))
		watch(() => this.Pess1ValGender.value, (newValue, oldValue) => this.onUpdate('pess1.gender', this.Pess1ValGender, newValue, oldValue))

		this.EquipValFrequenc = reactive(new modelFieldType.Number({
			type: 'FormFilter',
			id: 'EquipValFrequenc',
			originId: 'ValFrequenc',
			area: 'EQUIP',
			field: 'FREQUENC',
			maxDigits: 2,
			decimalDigits: 0,
			arrayOptions: computed(() => qProjArrays.QArrayFreqempr.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.LOAN_FREQUENCY00701),
		}).cloneFrom(values?.EquipValFrequenc))
		watch(() => this.EquipValFrequenc.value, (newValue, oldValue) => this.onUpdate('equip.frequenc', this.EquipValFrequenc, newValue, oldValue))

		this.EquipValBought = reactive(new modelFieldType.Boolean({
			type: 'FormFilter',
			id: 'EquipValBought',
			originId: 'ValBought',
			area: 'EQUIP',
			field: 'BOUGHT',
			description: computed(() => this.Resources.BOUGHT32044),
		}).cloneFrom(values?.EquipValBought))
		watch(() => this.EquipValBought.value, (newValue, oldValue) => this.onUpdate('equip.bought', this.EquipValBought, newValue, oldValue))

		this.LendiValReturned = reactive(new modelFieldType.Boolean({
			type: 'FormFilter',
			id: 'LendiValReturned',
			originId: 'ValReturned',
			area: 'LENDI',
			field: 'RETURNED',
			description: computed(() => this.Resources.RETURNED01606),
		}).cloneFrom(values?.LendiValReturned))
		watch(() => this.LendiValReturned.value, (newValue, oldValue) => this.onUpdate('lendi.returned', this.LendiValReturned, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormLendexplViewModel instance.
	 * @returns {QFormLendexplViewModel} A new instance of QFormLendexplViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}
}
