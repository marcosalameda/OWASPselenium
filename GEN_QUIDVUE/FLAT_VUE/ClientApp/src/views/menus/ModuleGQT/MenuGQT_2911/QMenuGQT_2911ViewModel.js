/* eslint-disable no-unused-vars */
import { computed, reactive, watch } from 'vue'

import ViewModelBase from '@/mixins/menuViewModelBase.js'
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

		this.ValCorletra = reactive(new modelFieldType.String({
			id: 'ValCorletra',
			originId: 'ValCorletra',
			area: 'TPEQU',
			field: 'CORLETRA',
			maxLength: 50,
			description: computed(() => this.Resources.LETTER_COLOR15736),
		}).cloneFrom(values?.ValCorletra))
		watch(() => this.ValCorletra.value, (newValue, oldValue) => this.onUpdate('tpequ.corletra', this.ValCorletra, newValue, oldValue))

		this.ValBackcolo = reactive(new modelFieldType.String({
			id: 'ValBackcolo',
			originId: 'ValBackcolo',
			area: 'TPEQU',
			field: 'BACKCOLO',
			maxLength: 50,
			description: computed(() => this.Resources.BACKGROUND_COLOR47883),
		}).cloneFrom(values?.ValBackcolo))
		watch(() => this.ValBackcolo.value, (newValue, oldValue) => this.onUpdate('tpequ.backcolo', this.ValBackcolo, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QMenuGQT_2911ViewModel instance.
	 * @returns {QMenuGQT_2911ViewModel} A new instance of QMenuGQT_2911ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}
}
