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
			name: 'PHOTO03',
			area: 'PROPH',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_PHOTO03',
				updateFilesTickets: 'UpdateFilesTicketsPHOTO03'
			}
		})

		/** The primary key. */
		this.ValCodproph = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodproph',
			originId: 'ValCodproph',
			area: 'PROPH',
			field: 'CODPROPH',
			description: '',
		}).cloneFrom(values?.ValCodproph))
		watch(() => this.ValCodproph.value, (newValue, oldValue) => this.onUpdate('proph.codproph', this.ValCodproph, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodprope = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodprope',
			originId: 'ValCodprope',
			area: 'PROPH',
			field: 'CODPROPE',
			relatedArea: 'PROPE',
			description: computed(() => this.Resources.PROPERTY43977),
		}).cloneFrom(values?.ValCodprope))
		watch(() => this.ValCodprope.value, (newValue, oldValue) => this.onUpdate('proph.codprope', this.ValCodprope, newValue, oldValue))

		/** The remaining form fields. */
		this.ValPhoto = reactive(new modelFieldType.Image({
			id: 'ValPhoto',
			originId: 'ValPhoto',
			area: 'PROPH',
			field: 'PHOTO',
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.ValPhoto))
		watch(() => this.ValPhoto.value, (newValue, oldValue) => this.onUpdate('proph.photo', this.ValPhoto, newValue, oldValue))

		this.ValTitle = reactive(new modelFieldType.String({
			id: 'ValTitle',
			originId: 'ValTitle',
			area: 'PROPH',
			field: 'TITLE',
			maxLength: 50,
			description: computed(() => this.Resources.TITLE21885),
		}).cloneFrom(values?.ValTitle))
		watch(() => this.ValTitle.value, (newValue, oldValue) => this.onUpdate('proph.title', this.ValTitle, newValue, oldValue))

		this.TablePropeTitle = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePropeTitle',
			originId: 'ValTitle',
			area: 'PROPE',
			field: 'TITLE',
			maxLength: 50,
			description: computed(() => this.Resources.TITLE21885),
		}).cloneFrom(values?.TablePropeTitle))
		watch(() => this.TablePropeTitle.value, (newValue, oldValue) => this.onUpdate('prope.title', this.TablePropeTitle, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormPhoto03ViewModel instance.
	 * @returns {QFormPhoto03ViewModel} A new instance of QFormPhoto03ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodproph'

	get QPrimaryKey() { return this.ValCodproph.value }
	set QPrimaryKey(value) { this.ValCodproph.updateValue(value) }
}
