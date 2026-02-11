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
			name: 'OPERACOES',
			area: 'OPERACOES',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Operacoes',
				updateFilesTickets: 'UpdateFilesTicketsOperacoes',
				setFile: 'SetFileOperacoes'
			}
		})

		/** The primary key. */
		this.ValCodoperacoes = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodoperacoes',
			originId: 'ValCodoperacoes',
			area: 'OPERACOES',
			field: 'CODOPERACOES',
			description: '',
		}).cloneFrom(values?.ValCodoperacoes))
		this.stopWatchers.push(watch(() => this.ValCodoperacoes.value, (newValue, oldValue) => this.onUpdate('operacoes.codoperacoes', this.ValCodoperacoes, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodentidade = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodentidade',
			originId: 'ValCodentidade',
			area: 'OPERACOES',
			field: 'CODENTIDADE',
			relatedArea: 'ENTIDADE',
			description: computed(() => this.Resources.ENTIDADE36471),
		}).cloneFrom(values?.ValCodentidade))
		this.stopWatchers.push(watch(() => this.ValCodentidade.value, (newValue, oldValue) => this.onUpdate('operacoes.codentidade', this.ValCodentidade, newValue, oldValue)))

		/** The remaining form fields. */
		this.TableEntidadeEntidade = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableEntidadeEntidade',
			originId: 'ValEntidade',
			area: 'ENTIDADE',
			field: 'ENTIDADE',
			maxLength: 250,
			description: computed(() => this.Resources.ENTIDADE36471),
		}).cloneFrom(values?.TableEntidadeEntidade))
		this.stopWatchers.push(watch(() => this.TableEntidadeEntidade.value, (newValue, oldValue) => this.onUpdate('entidade.entidade', this.TableEntidadeEntidade, newValue, oldValue)))

		this.ValOperacao_aa = reactive(new modelFieldType.String({
			id: 'ValOperacao_aa',
			originId: 'ValOperacao_aa',
			area: 'OPERACOES',
			field: 'OPERACAO_AA',
			maxLength: 50,
			description: computed(() => this.Resources.OPERACAO_AA07938),
		}).cloneFrom(values?.ValOperacao_aa))
		this.stopWatchers.push(watch(() => this.ValOperacao_aa.value, (newValue, oldValue) => this.onUpdate('operacoes.operacao_aa', this.ValOperacao_aa, newValue, oldValue)))

		this.ValPop_aa = reactive(new modelFieldType.Number({
			id: 'ValPop_aa',
			originId: 'ValPop_aa',
			area: 'OPERACOES',
			field: 'POP_AA',
			maxDigits: 6,
			decimalDigits: 0,
			description: computed(() => this.Resources.POP_ABRANGIDA36477),
		}).cloneFrom(values?.ValPop_aa))
		this.stopWatchers.push(watch(() => this.ValPop_aa.value, (newValue, oldValue) => this.onUpdate('operacoes.pop_aa', this.ValPop_aa, newValue, oldValue)))

		this.ValSobreposicao_aa = reactive(new modelFieldType.Boolean({
			id: 'ValSobreposicao_aa',
			originId: 'ValSobreposicao_aa',
			area: 'OPERACOES',
			field: 'SOBREPOSICAO_AA',
			description: computed(() => this.Resources.SOBREPOSICAO_AA55921),
		}).cloneFrom(values?.ValSobreposicao_aa))
		this.stopWatchers.push(watch(() => this.ValSobreposicao_aa.value, (newValue, oldValue) => this.onUpdate('operacoes.sobreposicao_aa', this.ValSobreposicao_aa, newValue, oldValue)))

		this.ValOperacao_ar = reactive(new modelFieldType.String({
			id: 'ValOperacao_ar',
			originId: 'ValOperacao_ar',
			area: 'OPERACOES',
			field: 'OPERACAO_AR',
			maxLength: 50,
			description: computed(() => this.Resources.OPERACAO_AR11207),
		}).cloneFrom(values?.ValOperacao_ar))
		this.stopWatchers.push(watch(() => this.ValOperacao_ar.value, (newValue, oldValue) => this.onUpdate('operacoes.operacao_ar', this.ValOperacao_ar, newValue, oldValue)))

		this.ValPop_ar = reactive(new modelFieldType.Number({
			id: 'ValPop_ar',
			originId: 'ValPop_ar',
			area: 'OPERACOES',
			field: 'POP_AR',
			maxDigits: 6,
			decimalDigits: 0,
			description: computed(() => this.Resources.POP_ABRANGIDA36477),
		}).cloneFrom(values?.ValPop_ar))
		this.stopWatchers.push(watch(() => this.ValPop_ar.value, (newValue, oldValue) => this.onUpdate('operacoes.pop_ar', this.ValPop_ar, newValue, oldValue)))

		this.ValSobreposicao_ar = reactive(new modelFieldType.Boolean({
			id: 'ValSobreposicao_ar',
			originId: 'ValSobreposicao_ar',
			area: 'OPERACOES',
			field: 'SOBREPOSICAO_AR',
			description: computed(() => this.Resources.SOBREPOSICAO_AR58360),
		}).cloneFrom(values?.ValSobreposicao_ar))
		this.stopWatchers.push(watch(() => this.ValSobreposicao_ar.value, (newValue, oldValue) => this.onUpdate('operacoes.sobreposicao_ar', this.ValSobreposicao_ar, newValue, oldValue)))

		this.ValOperacao_ru = reactive(new modelFieldType.String({
			id: 'ValOperacao_ru',
			originId: 'ValOperacao_ru',
			area: 'OPERACOES',
			field: 'OPERACAO_RU',
			maxLength: 50,
			description: computed(() => this.Resources.OPERACAO_RU18117),
		}).cloneFrom(values?.ValOperacao_ru))
		this.stopWatchers.push(watch(() => this.ValOperacao_ru.value, (newValue, oldValue) => this.onUpdate('operacoes.operacao_ru', this.ValOperacao_ru, newValue, oldValue)))

		this.ValPop_ru = reactive(new modelFieldType.Number({
			id: 'ValPop_ru',
			originId: 'ValPop_ru',
			area: 'OPERACOES',
			field: 'POP_RU',
			maxDigits: 6,
			decimalDigits: 0,
			description: computed(() => this.Resources.POP_ABRANGIDA36477),
		}).cloneFrom(values?.ValPop_ru))
		this.stopWatchers.push(watch(() => this.ValPop_ru.value, (newValue, oldValue) => this.onUpdate('operacoes.pop_ru', this.ValPop_ru, newValue, oldValue)))

		this.ValSobreposicao_ru = reactive(new modelFieldType.Boolean({
			id: 'ValSobreposicao_ru',
			originId: 'ValSobreposicao_ru',
			area: 'OPERACOES',
			field: 'SOBREPOSICAO_RU',
			description: computed(() => this.Resources.SOBREPOSICAO_RU06294),
		}).cloneFrom(values?.ValSobreposicao_ru))
		this.stopWatchers.push(watch(() => this.ValSobreposicao_ru.value, (newValue, oldValue) => this.onUpdate('operacoes.sobreposicao_ru', this.ValSobreposicao_ru, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormOperacoesViewModel instance.
	 * @returns {QFormOperacoesViewModel} A new instance of QFormOperacoesViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodoperacoes'

	get QPrimaryKey() { return this.ValCodoperacoes.value }
	set QPrimaryKey(value) { this.ValCodoperacoes.updateValue(value) }
}
