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
			name: 'CARDS',
			area: 'CARDS',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_CARDS',
				updateFilesTickets: 'UpdateFilesTicketsCARDS'
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
		this.ValActionsplace = reactive(new modelFieldType.Number({
			id: 'ValActionsplace',
			originId: 'ValActionsplace',
			area: 'CARDS',
			field: 'ACTIONSPLACE',
			maxDigits: 1,
			decimalDigits: 0,
			arrayOptions: computed(() => qProjArrays.QArrayHeader.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.ACTIONS_PLACEMENT53802),
		}).cloneFrom(values?.ValActionsplace))
		watch(() => this.ValActionsplace.value, (newValue, oldValue) => this.onUpdate('cards.actionsplace', this.ValActionsplace, newValue, oldValue))

		this.ValActonsalign = reactive(new modelFieldType.Number({
			id: 'ValActonsalign',
			originId: 'ValActonsalign',
			area: 'CARDS',
			field: 'ACTONSALIGN',
			maxDigits: 1,
			decimalDigits: 0,
			arrayOptions: computed(() => qProjArrays.QArraySide.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.ACTIONS_ALIGNMENT40760),
		}).cloneFrom(values?.ValActonsalign))
		watch(() => this.ValActonsalign.value, (newValue, oldValue) => this.onUpdate('cards.actonsalign', this.ValActonsalign, newValue, oldValue))

		this.ValActionsstyle = reactive(new modelFieldType.Number({
			id: 'ValActionsstyle',
			originId: 'ValActionsstyle',
			area: 'CARDS',
			field: 'ACTIONSSTYLE',
			maxDigits: 1,
			decimalDigits: 0,
			arrayOptions: computed(() => qProjArrays.QArrayDropdown.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.ACTIONS_STYLE36765),
		}).cloneFrom(values?.ValActionsstyle))
		watch(() => this.ValActionsstyle.value, (newValue, oldValue) => this.onUpdate('cards.actionsstyle', this.ValActionsstyle, newValue, oldValue))

		/** The form fields used only in formulas. */
		this.ValTitle = reactive(new modelFieldType.String({
			id: 'ValTitle',
			originId: 'ValTitle',
			area: 'CARDS',
			field: 'TITLE',
			maxLength: 50,
			isFixed: true,
			description: computed(() => this.Resources.TITLE21885),
		}).cloneFrom(values?.ValTitle))
		watch(() => this.ValTitle.value, (newValue, oldValue) => this.onUpdate('cards.title', this.ValTitle, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormCardsViewModel instance.
	 * @returns {QFormCardsViewModel} A new instance of QFormCardsViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcards'

	get QPrimaryKey() { return this.ValCodcards.value }
	set QPrimaryKey(value) { this.ValCodcards.updateValue(value) }
}
