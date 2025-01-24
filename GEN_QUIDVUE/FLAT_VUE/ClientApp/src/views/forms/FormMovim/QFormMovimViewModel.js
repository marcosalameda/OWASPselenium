/* eslint-disable no-unused-vars */
import { computed, reactive, watch } from 'vue'
import _merge from 'lodash-es/merge'

import ViewModelBase from '@/mixins/formViewModelBase.js'
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

		/** The view model metadata */
		_merge(this.modelInfo, {
			name: 'MOVIM',
			area: 'MOVIM',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_MOVIM'
			}
		})

		/** The primary key. */
		this.ValCodmovim = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodmovim',
			originId: 'ValCodmovim',
			area: 'MOVIM',
			field: 'CODMOVIM',
			description: '',
		}).cloneFrom(values?.ValCodmovim))
		watch(() => this.ValCodmovim.value, (newValue, oldValue) => this.onUpdate('movim.codmovim', this.ValCodmovim, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodequip = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodequip',
			originId: 'ValCodequip',
			area: 'MOVIM',
			field: 'CODEQUIP',
			relatedArea: 'EQUIP',
			description: computed(() => this.Resources._EQUIPMENT12605),
		}).cloneFrom(values?.ValCodequip))
		watch(() => this.ValCodequip.value, (newValue, oldValue) => this.onUpdate('movim.codequip', this.ValCodequip, newValue, oldValue))

		this.ValCodrooms = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodrooms',
			originId: 'ValCodrooms',
			area: 'MOVIM',
			field: 'CODROOMS',
			relatedArea: 'ROOMS',
			description: computed(() => this.Resources._ROOM54790),
		}).cloneFrom(values?.ValCodrooms))
		watch(() => this.ValCodrooms.value, (newValue, oldValue) => this.onUpdate('movim.codrooms', this.ValCodrooms, newValue, oldValue))

		/** The remaining form fields. */
		this.ValDhmudanc = reactive(new modelFieldType.DateTime({
			id: 'ValDhmudanc',
			originId: 'ValDhmudanc',
			area: 'MOVIM',
			field: 'DHMUDANC',
			description: computed(() => this.Resources.CHANGE36355),
		}).cloneFrom(values?.ValDhmudanc))
		watch(() => this.ValDhmudanc.value, (newValue, oldValue) => this.onUpdate('movim.dhmudanc', this.ValDhmudanc, newValue, oldValue))

		this.TableEquipRegistnr = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableEquipRegistnr',
			originId: 'ValRegistnr',
			area: 'EQUIP',
			field: 'REGISTNR',
			maxLength: 6,
			description: computed(() => this.Resources.NO__REGISTER04207),
		}).cloneFrom(values?.TableEquipRegistnr))
		watch(() => this.TableEquipRegistnr.value, (newValue, oldValue) => this.onUpdate('equip.registnr', this.TableEquipRegistnr, newValue, oldValue))

		this.TableRoomsRoomnr = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableRoomsRoomnr',
			originId: 'ValRoomnr',
			area: 'ROOMS',
			field: 'ROOMNR',
			maxLength: 10,
			description: computed(() => this.Resources.N_R__ROOM43805),
		}).cloneFrom(values?.TableRoomsRoomnr))
		watch(() => this.TableRoomsRoomnr.value, (newValue, oldValue) => this.onUpdate('rooms.roomnr', this.TableRoomsRoomnr, newValue, oldValue))

		this.ValObservat = reactive(new modelFieldType.MultiLineString({
			id: 'ValObservat',
			originId: 'ValObservat',
			area: 'MOVIM',
			field: 'OBSERVAT',
			description: computed(() => this.Resources.OBSERVATION37880),
		}).cloneFrom(values?.ValObservat))
		watch(() => this.ValObservat.value, (newValue, oldValue) => this.onUpdate('movim.observat', this.ValObservat, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormMovimViewModel instance.
	 * @returns {QFormMovimViewModel} A new instance of QFormMovimViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodmovim'

	get QPrimaryKey() { return this.ValCodmovim.value }
	set QPrimaryKey(value) { this.ValCodmovim.updateValue(value) }
}
