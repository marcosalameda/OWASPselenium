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

		this.WarehValWarehdes = reactive(new modelFieldType.String({
			id: 'WarehValWarehdes',
			originId: 'ValWarehdes',
			area: 'WAREH',
			field: 'WAREHDES',
			maxLength: 85,
			description: computed(() => this.Resources.WAREHOUSE51864),
		}).cloneFrom(values?.WarehValWarehdes))
		watch(() => this.WarehValWarehdes.value, (newValue, oldValue) => this.onUpdate('wareh.warehdes', this.WarehValWarehdes, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QMenuGQT_4611ViewModel instance.
	 * @returns {QMenuGQT_4611ViewModel} A new instance of QMenuGQT_4611ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}
}
