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
			name: 'CONCELHO',
			area: 'CONCELHO',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Concelho',
				updateFilesTickets: 'UpdateFilesTicketsConcelho',
				setFile: 'SetFileConcelho'
			}
		})

		/** The primary key. */
		this.ValCodconcelho = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodconcelho',
			originId: 'ValCodconcelho',
			area: 'CONCELHO',
			field: 'CODCONCELHO',
			description: '',
		}).cloneFrom(values?.ValCodconcelho))
		this.stopWatchers.push(watch(() => this.ValCodconcelho.value, (newValue, oldValue) => this.onUpdate('concelho.codconcelho', this.ValCodconcelho, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValNome = reactive(new modelFieldType.String({
			id: 'ValNome',
			originId: 'ValNome',
			area: 'CONCELHO',
			field: 'NOME',
			maxLength: 100,
			description: computed(() => this.Resources.NOME47814),
		}).cloneFrom(values?.ValNome))
		this.stopWatchers.push(watch(() => this.ValNome.value, (newValue, oldValue) => this.onUpdate('concelho.nome', this.ValNome, newValue, oldValue)))

		this.ValPop_residente = reactive(new modelFieldType.Number({
			id: 'ValPop_residente',
			originId: 'ValPop_residente',
			area: 'CONCELHO',
			field: 'POP_RESIDENTE',
			maxDigits: 6,
			decimalDigits: 0,
			description: computed(() => this.Resources.POP_RESIDENTE46287),
		}).cloneFrom(values?.ValPop_residente))
		this.stopWatchers.push(watch(() => this.ValPop_residente.value, (newValue, oldValue) => this.onUpdate('concelho.pop_residente', this.ValPop_residente, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormConcelhoViewModel instance.
	 * @returns {QFormConcelhoViewModel} A new instance of QFormConcelhoViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodconcelho'

	get QPrimaryKey() { return this.ValCodconcelho.value }
	set QPrimaryKey(value) { this.ValCodconcelho.updateValue(value) }
}
