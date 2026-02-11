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
			name: 'EQUIPM__PSEUDA_TAGS__',
			area: 'ATAGS',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Equipm__pseuda_tags__',
				updateFilesTickets: 'UpdateFilesTicketsEquipm__pseuda_tags__',
				setFile: 'SetFileEquipm__pseuda_tags__'
			}
		})

		/** The primary key. */
		this.ValCodtags = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodtags',
			originId: 'ValCodtags',
			area: 'ATAGS',
			field: 'CODTAGS',
			description: '',
		}).cloneFrom(values?.ValCodtags))
		this.stopWatchers.push(watch(() => this.ValCodtags.value, (newValue, oldValue) => this.onUpdate('atags.codtags', this.ValCodtags, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValCodasset = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodasset',
			originId: 'ValCodasset',
			area: 'ATAGS',
			field: 'CODASSET',
			relatedArea: 'ASSET',
			isFixed: true,
			description: '',
		}).cloneFrom(values?.ValCodasset))
		this.stopWatchers.push(watch(() => this.ValCodasset.value, (newValue, oldValue) => this.onUpdate('atags.codasset', this.ValCodasset, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'ATAGS',
			field: 'NAME',
			maxLength: 75,
			description: computed(() => this.Resources.TAG_NAME52385),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('atags.name', this.ValName, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QGridFormEquipmPseudaTagsViewModel instance.
	 * @returns {QGridFormEquipmPseudaTagsViewModel} A new instance of QGridFormEquipmPseudaTagsViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodtags'

	get QPrimaryKey() { return this.ValCodtags.value }
	set QPrimaryKey(value) { this.ValCodtags.updateValue(value) }
}
