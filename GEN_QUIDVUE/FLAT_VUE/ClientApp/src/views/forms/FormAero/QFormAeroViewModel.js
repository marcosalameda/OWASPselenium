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
			name: 'AERO',
			area: 'AERO',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_AERO'
			}
		})

		/** The primary key. */
		this.ValCodaero = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodaero',
			originId: 'ValCodaero',
			area: 'AERO',
			field: 'CODAERO',
			description: '',
		}).cloneFrom(values?.ValCodaero))
		watch(() => this.ValCodaero.value, (newValue, oldValue) => this.onUpdate('aero.codaero', this.ValCodaero, newValue, oldValue))

		/** The remaining form fields. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'AERO',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.AIRLINE_NAME55130),
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('aero.name', this.ValName, newValue, oldValue))

		this.ValCodcmaer = reactive(new modelFieldType.Number({
			id: 'ValCodcmaer',
			originId: 'ValCodcmaer',
			area: 'AERO',
			field: 'CODCMAER',
			maxDigits: 2,
			decimalDigits: 0,
			description: computed(() => this.Resources.CODE49225),
		}).cloneFrom(values?.ValCodcmaer))
		watch(() => this.ValCodcmaer.value, (newValue, oldValue) => this.onUpdate('aero.codcmaer', this.ValCodcmaer, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormAeroViewModel instance.
	 * @returns {QFormAeroViewModel} A new instance of QFormAeroViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodaero'

	get QPrimaryKey() { return this.ValCodaero.value }
	set QPrimaryKey(value) { this.ValCodaero.value = value }
}
