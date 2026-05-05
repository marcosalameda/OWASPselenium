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
			name: 'CARDCONFIG',
			area: 'CARDS',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_CARDCONFIG',
				updateFilesTickets: 'UpdateFilesTicketsCARDCONFIG'
			}
		})

		/** The primary key. */
		this.ValCodcards = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcards',
			originId: 'ValCodcards',
			area: 'CARDS',
			field: 'CODCARDS',
			description: '',
		}).cloneFrom(values?.ValCodcards))
		watch(() => this.ValCodcards.value, (newValue, oldValue) => this.onUpdate('cards.codcards', this.ValCodcards, newValue, oldValue))

		/** The remaining form fields. */
		this.ValImage = reactive(new modelFieldType.Image({
			id: 'ValImage',
			originId: 'ValImage',
			area: 'CARDS',
			field: 'IMAGE',
			description: computed(() => this.Resources.IMAGE65174),
		}).cloneFrom(values?.ValImage))
		watch(() => this.ValImage.value, (newValue, oldValue) => this.onUpdate('cards.image', this.ValImage, newValue, oldValue))

		this.ValTitle = reactive(new modelFieldType.String({
			id: 'ValTitle',
			originId: 'ValTitle',
			area: 'CARDS',
			field: 'TITLE',
			maxLength: 50,
			description: computed(() => this.Resources.TITLE21885),
		}).cloneFrom(values?.ValTitle))
		watch(() => this.ValTitle.value, (newValue, oldValue) => this.onUpdate('cards.title', this.ValTitle, newValue, oldValue))

		this.ValSubtitle = reactive(new modelFieldType.String({
			id: 'ValSubtitle',
			originId: 'ValSubtitle',
			area: 'CARDS',
			field: 'SUBTITLE',
			maxLength: 50,
			description: computed(() => this.Resources.SUBTITLE60663),
		}).cloneFrom(values?.ValSubtitle))
		watch(() => this.ValSubtitle.value, (newValue, oldValue) => this.onUpdate('cards.subtitle', this.ValSubtitle, newValue, oldValue))

		this.ValDescription = reactive(new modelFieldType.MultiLineString({
			id: 'ValDescription',
			originId: 'ValDescription',
			area: 'CARDS',
			field: 'DESCRIPTION',
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescription))
		watch(() => this.ValDescription.value, (newValue, oldValue) => this.onUpdate('cards.description', this.ValDescription, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormCardconfigViewModel instance.
	 * @returns {QFormCardconfigViewModel} A new instance of QFormCardconfigViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcards'

	get QPrimaryKey() { return this.ValCodcards.value }
	set QPrimaryKey(value) { this.ValCodcards.updateValue(value) }
}
