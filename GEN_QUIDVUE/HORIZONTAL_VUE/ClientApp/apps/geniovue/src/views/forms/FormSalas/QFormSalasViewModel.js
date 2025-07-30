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
			name: 'SALAS',
			area: 'ROOMS',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Salas',
				updateFilesTickets: 'UpdateFilesTicketsSalas',
				setFile: 'SetFileSalas'
			}
		})

		/** The primary key. */
		this.ValCodrooms = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodrooms',
			originId: 'ValCodrooms',
			area: 'ROOMS',
			field: 'CODROOMS',
			description: '',
		}).cloneFrom(values?.ValCodrooms))
		this.stopWatchers.push(watch(() => this.ValCodrooms.value, (newValue, oldValue) => this.onUpdate('rooms.codrooms', this.ValCodrooms, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValRoomnr = reactive(new modelFieldType.String({
			id: 'ValRoomnr',
			originId: 'ValRoomnr',
			area: 'ROOMS',
			field: 'ROOMNR',
			maxLength: 10,
			description: computed(() => this.Resources.N_R__ROOM43805),
		}).cloneFrom(values?.ValRoomnr))
		this.stopWatchers.push(watch(() => this.ValRoomnr.value, (newValue, oldValue) => this.onUpdate('rooms.roomnr', this.ValRoomnr, newValue, oldValue)))

		this.ValDesignat = reactive(new modelFieldType.String({
			id: 'ValDesignat',
			originId: 'ValDesignat',
			area: 'ROOMS',
			field: 'DESIGNAT',
			maxLength: 50,
			description: computed(() => this.Resources.ROOM_DESIGNATION37895),
		}).cloneFrom(values?.ValDesignat))
		this.stopWatchers.push(watch(() => this.ValDesignat.value, (newValue, oldValue) => this.onUpdate('rooms.designat', this.ValDesignat, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormSalasViewModel instance.
	 * @returns {QFormSalasViewModel} A new instance of QFormSalasViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodrooms'

	get QPrimaryKey() { return this.ValCodrooms.value }
	set QPrimaryKey(value) { this.ValCodrooms.updateValue(value) }
}
