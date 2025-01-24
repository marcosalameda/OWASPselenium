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
			name: 'GENCO',
			area: 'GENRE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_GENCO'
			}
		})

		/** The primary key. */
		this.ValCodgenre = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodgenre',
			originId: 'ValCodgenre',
			area: 'GENRE',
			field: 'CODGENRE',
			description: '',
		}).cloneFrom(values?.ValCodgenre))
		watch(() => this.ValCodgenre.value, (newValue, oldValue) => this.onUpdate('genre.codgenre', this.ValCodgenre, newValue, oldValue))

		/** The remaining form fields. */
		this.ValAgencont = reactive(new modelFieldType.String({
			id: 'ValAgencont',
			originId: 'ValAgencont',
			area: 'GENRE',
			field: 'AGENCONT',
			arrayOptions: qProjArrays.QArrayGenconta.setResources(vm.$getResource).elements,
			maxLength: 1,
			description: computed(() => this.Resources.GENDER_CONTACT17830),
		}).cloneFrom(values?.ValAgencont))
		watch(() => this.ValAgencont.value, (newValue, oldValue) => this.onUpdate('genre.agencont', this.ValAgencont, newValue, oldValue))

		this.ValGender = reactive(new modelFieldType.String({
			id: 'ValGender',
			originId: 'ValGender',
			area: 'GENRE',
			field: 'GENDER',
			maxLength: 20,
			description: computed(() => this.Resources.GENRE63303),
		}).cloneFrom(values?.ValGender))
		watch(() => this.ValGender.value, (newValue, oldValue) => this.onUpdate('genre.gender', this.ValGender, newValue, oldValue))

		this.ValBackcolo = reactive(new modelFieldType.String({
			id: 'ValBackcolo',
			originId: 'ValBackcolo',
			area: 'GENRE',
			field: 'BACKCOLO',
			maxLength: 50,
			description: computed(() => this.Resources.BACKGROUND_COLOR47883),
		}).cloneFrom(values?.ValBackcolo))
		watch(() => this.ValBackcolo.value, (newValue, oldValue) => this.onUpdate('genre.backcolo', this.ValBackcolo, newValue, oldValue))

		this.ValTextcolo = reactive(new modelFieldType.String({
			id: 'ValTextcolo',
			originId: 'ValTextcolo',
			area: 'GENRE',
			field: 'TEXTCOLO',
			maxLength: 50,
			description: computed(() => this.Resources.TEXT_COLOR24820),
		}).cloneFrom(values?.ValTextcolo))
		watch(() => this.ValTextcolo.value, (newValue, oldValue) => this.onUpdate('genre.textcolo', this.ValTextcolo, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormGencoViewModel instance.
	 * @returns {QFormGencoViewModel} A new instance of QFormGencoViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodgenre'

	get QPrimaryKey() { return this.ValCodgenre.value }
	set QPrimaryKey(value) { this.ValCodgenre.updateValue(value) }
}
