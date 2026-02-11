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
			name: 'UP_RULES',
			area: 'UP_RULES',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Up_rules',
				updateFilesTickets: 'UpdateFilesTicketsUp_rules',
				setFile: 'SetFileUp_rules'
			}
		})

		/** The primary key. */
		this.ValCodup_rules = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodup_rules',
			originId: 'ValCodup_rules',
			area: 'UP_RULES',
			field: 'CODUP_RULES',
			description: '',
		}).cloneFrom(values?.ValCodup_rules))
		this.stopWatchers.push(watch(() => this.ValCodup_rules.value, (newValue, oldValue) => this.onUpdate('up_rules.codup_rules', this.ValCodup_rules, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValDescript = reactive(new modelFieldType.String({
			id: 'ValDescript',
			originId: 'ValDescript',
			area: 'UP_RULES',
			field: 'DESCRIPT',
			maxLength: 50,
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescript))
		this.stopWatchers.push(watch(() => this.ValDescript.value, (newValue, oldValue) => this.onUpdate('up_rules.descript', this.ValDescript, newValue, oldValue)))

		this.ValLocal = reactive(new modelFieldType.String({
			id: 'ValLocal',
			originId: 'ValLocal',
			area: 'UP_RULES',
			field: 'LOCAL',
			maxLength: 1,
			arrayOptions: computed(() => new qProjArrays.QArrayAlocregr(vm.$getResource).elements),
			description: computed(() => this.Resources.PLACE_WHERE_YOU_RUN27490),
		}).cloneFrom(values?.ValLocal))
		this.stopWatchers.push(watch(() => this.ValLocal.value, (newValue, oldValue) => this.onUpdate('up_rules.local', this.ValLocal, newValue, oldValue)))

		this.ValAllow_all = reactive(new modelFieldType.Boolean({
			id: 'ValAllow_all',
			originId: 'ValAllow_all',
			area: 'UP_RULES',
			field: 'ALLOW_ALL',
			description: computed(() => this.Resources.ALLOW_ALL25379),
		}).cloneFrom(values?.ValAllow_all))
		this.stopWatchers.push(watch(() => this.ValAllow_all.value, (newValue, oldValue) => this.onUpdate('up_rules.allow_all', this.ValAllow_all, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormUpRulesViewModel instance.
	 * @returns {QFormUpRulesViewModel} A new instance of QFormUpRulesViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodup_rules'

	get QPrimaryKey() { return this.ValCodup_rules.value }
	set QPrimaryKey(value) { this.ValCodup_rules.updateValue(value) }
}
