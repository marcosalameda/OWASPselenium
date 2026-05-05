/* eslint-disable no-unused-vars */
import { computed, reactive, watch } from 'vue'

import MenuViewModelBase from '@/mixins/menuViewModelBase.js'
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
 * @extends MenuViewModelBase
 */
export default class ViewModel extends MenuViewModelBase
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

		this.EquipValRegistnr = reactive(new modelFieldType.String({
			id: 'EquipValRegistnr',
			originId: 'ValRegistnr',
			area: 'EQUIP',
			field: 'REGISTNR',
			maxLength: 6,
			description: computed(() => this.Resources.NO__REGISTER04207),
		}).cloneFrom(values?.EquipValRegistnr))
		watch(() => this.EquipValRegistnr.value, (newValue, oldValue) => this.onUpdate('equip.registnr', this.EquipValRegistnr, newValue, oldValue))

		this.EquipTpequValTipoequi = reactive(new modelFieldType.String({
			id: 'EquipTpequValTipoequi',
			originId: 'ValTipoequi',
			area: 'TPEQU',
			field: 'TIPOEQUI',
			maxLength: 50,
			description: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
		}).cloneFrom(values?.EquipTpequValTipoequi))
		watch(() => this.EquipTpequValTipoequi.value, (newValue, oldValue) => this.onUpdate('tpequ.tipoequi', this.EquipTpequValTipoequi, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QMenuGQT_1711ViewModel instance.
	 * @returns {QMenuGQT_1711ViewModel} A new instance of QMenuGQT_1711ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}
}
