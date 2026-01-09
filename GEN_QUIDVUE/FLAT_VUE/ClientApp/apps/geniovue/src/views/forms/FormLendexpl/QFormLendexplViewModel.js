/* eslint-disable @typescript-eslint/no-unused-vars */
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
/* eslint-enable @typescript-eslint/no-unused-vars */

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
	// eslint-disable-next-line @typescript-eslint/no-unused-vars
	constructor(vueContext, options, values)
	{
		super(vueContext, options)
		// eslint-disable-next-line @typescript-eslint/no-unused-vars
		const vm = this.vueContext

		// The view model metadata
		_merge(this.modelInfo, {
			name: 'LENDEXPL',
			area: 'Home',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Lendexpl',
				updateFilesTickets: 'UpdateFilesTicketsLendexpl',
				setFile: 'SetFileLendexpl'
			}
		})


		/** The remaining form fields. */
		this.ValGender = reactive(new modelFieldType.String({
			type: 'FormFilter',
			id: 'ValGender',
			originId: 'ValGender',
			area: 'PESS1',
			field: 'GENDER',
			maxLength: 1,
			arrayOptions: computed(() => new qProjArrays.QArrayGenero(vm.$getResource).elements),
			description: computed(() => this.Resources.GENRE63303),
		}).cloneFrom(values?.ValGender))
		this.stopWatchers.push(watch(() => this.ValGender.value, (newValue, oldValue) => this.onUpdate('pess1.gender', this.ValGender, newValue, oldValue)))

		this.ValFrequenc = reactive(new modelFieldType.Number({
			type: 'FormFilter',
			id: 'ValFrequenc',
			originId: 'ValFrequenc',
			area: 'EQUIP',
			field: 'FREQUENC',
			maxDigits: 2,
			decimalDigits: 0,
			arrayOptions: computed(() => new qProjArrays.QArrayFreqempr(vm.$getResource).elements),
			description: computed(() => this.Resources.LOAN_FREQUENCY00701),
		}).cloneFrom(values?.ValFrequenc))
		this.stopWatchers.push(watch(() => this.ValFrequenc.value, (newValue, oldValue) => this.onUpdate('equip.frequenc', this.ValFrequenc, newValue, oldValue)))

		this.ValBought = reactive(new modelFieldType.Boolean({
			id: 'ValBought',
			originId: 'ValBought',
			area: 'EQUIP',
			field: 'BOUGHT',
			isFixed: true,
			description: computed(() => this.Resources.BOUGHT32044),
		}).cloneFrom(values?.ValBought))
		this.stopWatchers.push(watch(() => this.ValBought.value, (newValue, oldValue) => this.onUpdate('equip.bought', this.ValBought, newValue, oldValue)))

		this.ValReturned = reactive(new modelFieldType.Boolean({
			id: 'ValReturned',
			originId: 'ValReturned',
			area: 'LENDI',
			field: 'RETURNED',
			isFixed: true,
			description: computed(() => this.Resources.RETURNED01606),
		}).cloneFrom(values?.ValReturned))
		this.stopWatchers.push(watch(() => this.ValReturned.value, (newValue, oldValue) => this.onUpdate('lendi.returned', this.ValReturned, newValue, oldValue)))
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
