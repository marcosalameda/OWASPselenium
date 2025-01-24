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
			name: 'FOTOS',
			area: 'PHOTO',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_FOTOS'
			}
		})

		/** The primary key. */
		this.ValCodphoto = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodphoto',
			originId: 'ValCodphoto',
			area: 'PHOTO',
			field: 'CODPHOTO',
			description: '',
		}).cloneFrom(values?.ValCodphoto))
		watch(() => this.ValCodphoto.value, (newValue, oldValue) => this.onUpdate('photo.codphoto', this.ValCodphoto, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodequip = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodequip',
			originId: 'ValCodequip',
			area: 'PHOTO',
			field: 'CODEQUIP',
			relatedArea: 'EQUIP',
			description: '',
		}).cloneFrom(values?.ValCodequip))
		watch(() => this.ValCodequip.value, (newValue, oldValue) => this.onUpdate('photo.codequip', this.ValCodequip, newValue, oldValue))

		/** The remaining form fields. */
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

		this.ValPhotogra = reactive(new modelFieldType.Image({
			id: 'ValPhotogra',
			originId: 'ValPhotogra',
			area: 'PHOTO',
			field: 'PHOTOGRA',
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.ValPhotogra))
		watch(() => this.ValPhotogra.value, (newValue, oldValue) => this.onUpdate('photo.photogra', this.ValPhotogra, newValue, oldValue))

		this.ValTitle = reactive(new modelFieldType.String({
			id: 'ValTitle',
			originId: 'ValTitle',
			area: 'PHOTO',
			field: 'TITLE',
			maxLength: 85,
			description: computed(() => this.Resources.TITLE21885),
		}).cloneFrom(values?.ValTitle))
		watch(() => this.ValTitle.value, (newValue, oldValue) => this.onUpdate('photo.title', this.ValTitle, newValue, oldValue))

		this.ValAnexed = reactive(new modelFieldType.DateTime({
			id: 'ValAnexed',
			originId: 'ValAnexed',
			area: 'PHOTO',
			field: 'ANEXED',
			description: computed(() => this.Resources.ATTACHED26247),
		}).cloneFrom(values?.ValAnexed))
		watch(() => this.ValAnexed.value, (newValue, oldValue) => this.onUpdate('photo.anexed', this.ValAnexed, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormFotosViewModel instance.
	 * @returns {QFormFotosViewModel} A new instance of QFormFotosViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodphoto'

	get QPrimaryKey() { return this.ValCodphoto.value }
	set QPrimaryKey(value) { this.ValCodphoto.updateValue(value) }
}
