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
			name: 'REGRA',
			area: 'RULES',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Regra',
				updateFilesTickets: 'UpdateFilesTicketsRegra',
				setFile: 'SetFileRegra'
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
		this.stopWatchers.push(watch(() => this.ValCodregra.value, (newValue, oldValue) => this.onUpdate('rules.codregra', this.ValCodregra, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValTipocond = reactive(new modelFieldType.String({
			id: 'ValTipocond',
			originId: 'ValTipocond',
			area: 'RULES',
			field: 'TIPOCOND',
			maxLength: 1,
			arrayOptions: computed(() => new qProjArrays.QArrayTipocond(vm.$getResource).elements),
			description: computed(() => this.Resources.CONDITION_TYPE57524),
		}).cloneFrom(values?.ValTipocond))
		this.stopWatchers.push(watch(() => this.ValTipocond.value, (newValue, oldValue) => this.onUpdate('rules.tipocond', this.ValTipocond, newValue, oldValue)))

		this.ValDescript = reactive(new modelFieldType.String({
			id: 'ValDescript',
			originId: 'ValDescript',
			area: 'RULES',
			field: 'DESCRIPT',
			maxLength: 100,
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescript))
		this.stopWatchers.push(watch(() => this.ValDescript.value, (newValue, oldValue) => this.onUpdate('rules.descript', this.ValDescript, newValue, oldValue)))

		this.ValLocal = reactive(new modelFieldType.String({
			id: 'ValLocal',
			originId: 'ValLocal',
			area: 'RULES',
			field: 'LOCAL',
			maxLength: 1,
			arrayOptions: computed(() => new qProjArrays.QArrayAlocregr(vm.$getResource).elements),
			description: computed(() => this.Resources.PLACE_WHERE_YOU_RUN27490),
		}).cloneFrom(values?.ValLocal))
		this.stopWatchers.push(watch(() => this.ValLocal.value, (newValue, oldValue) => this.onUpdate('rules.local', this.ValLocal, newValue, oldValue)))
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
