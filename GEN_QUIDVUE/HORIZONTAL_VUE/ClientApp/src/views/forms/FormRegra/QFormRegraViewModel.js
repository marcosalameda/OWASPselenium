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
			name: 'REGRA',
			area: 'RULES',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_REGRA'
			}
		})

		/** The primary key. */
		this.ValCodregra = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodregra',
			originId: 'ValCodregra',
			area: 'RULES',
			field: 'CODREGRA',
			description: '',
		}).cloneFrom(values?.ValCodregra))
		watch(() => this.ValCodregra.value, (newValue, oldValue) => this.onUpdate('rules.codregra', this.ValCodregra, newValue, oldValue))

		/** The remaining form fields. */
		this.ValTipocond = reactive(new modelFieldType.String({
			id: 'ValTipocond',
			originId: 'ValTipocond',
			area: 'RULES',
			field: 'TIPOCOND',
			arrayOptions: qProjArrays.QArrayTipocond.setResources(vm.$getResource).elements,
			maxLength: 1,
			description: computed(() => this.Resources.CONDITION_TYPE57524),
		}).cloneFrom(values?.ValTipocond))
		watch(() => this.ValTipocond.value, (newValue, oldValue) => this.onUpdate('rules.tipocond', this.ValTipocond, newValue, oldValue))

		this.ValDescript = reactive(new modelFieldType.String({
			id: 'ValDescript',
			originId: 'ValDescript',
			area: 'RULES',
			field: 'DESCRIPT',
			maxLength: 100,
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescript))
		watch(() => this.ValDescript.value, (newValue, oldValue) => this.onUpdate('rules.descript', this.ValDescript, newValue, oldValue))

		this.ValLocal = reactive(new modelFieldType.String({
			id: 'ValLocal',
			originId: 'ValLocal',
			area: 'RULES',
			field: 'LOCAL',
			arrayOptions: qProjArrays.QArrayAlocregr.setResources(vm.$getResource).elements,
			maxLength: 1,
			description: computed(() => this.Resources.PLACE_WHERE_YOU_RUN27490),
		}).cloneFrom(values?.ValLocal))
		watch(() => this.ValLocal.value, (newValue, oldValue) => this.onUpdate('rules.local', this.ValLocal, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormRegraViewModel instance.
	 * @returns {QFormRegraViewModel} A new instance of QFormRegraViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodregra'

	get QPrimaryKey() { return this.ValCodregra.value }
	set QPrimaryKey(value) { this.ValCodregra.updateValue(value) }
}
