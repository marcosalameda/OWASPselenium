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
			name: 'ENTIDADE',
			area: 'ENTIDADE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Entidade',
				updateFilesTickets: 'UpdateFilesTicketsEntidade',
				setFile: 'SetFileEntidade'
			}
		})

		/** The primary key. */
		this.ValCodentidade = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodentidade',
			originId: 'ValCodentidade',
			area: 'ENTIDADE',
			field: 'CODENTIDADE',
			description: '',
		}).cloneFrom(values?.ValCodentidade))
		this.stopWatchers.push(watch(() => this.ValCodentidade.value, (newValue, oldValue) => this.onUpdate('entidade.codentidade', this.ValCodentidade, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodconcelho = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodconcelho',
			originId: 'ValCodconcelho',
			area: 'ENTIDADE',
			field: 'CODCONCELHO',
			relatedArea: 'CONCELHO',
			description: computed(() => this.Resources.CONCELHO13174),
		}).cloneFrom(values?.ValCodconcelho))
		this.stopWatchers.push(watch(() => this.ValCodconcelho.value, (newValue, oldValue) => this.onUpdate('entidade.codconcelho', this.ValCodconcelho, newValue, oldValue)))

		/** The remaining form fields. */
		this.TableConcelhoNome = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableConcelhoNome',
			originId: 'ValNome',
			area: 'CONCELHO',
			field: 'NOME',
			maxLength: 100,
			description: computed(() => this.Resources.NOME47814),
		}).cloneFrom(values?.TableConcelhoNome))
		this.stopWatchers.push(watch(() => this.TableConcelhoNome.value, (newValue, oldValue) => this.onUpdate('concelho.nome', this.TableConcelhoNome, newValue, oldValue)))

		this.ValId_entidade = reactive(new modelFieldType.Number({
			id: 'ValId_entidade',
			originId: 'ValId_entidade',
			area: 'ENTIDADE',
			field: 'ID_ENTIDADE',
			maxDigits: 4,
			decimalDigits: 0,
			description: computed(() => this.Resources.ID_ENTIDADE52030),
		}).cloneFrom(values?.ValId_entidade))
		this.stopWatchers.push(watch(() => this.ValId_entidade.value, (newValue, oldValue) => this.onUpdate('entidade.id_entidade', this.ValId_entidade, newValue, oldValue)))

		this.ValEntidade = reactive(new modelFieldType.String({
			id: 'ValEntidade',
			originId: 'ValEntidade',
			area: 'ENTIDADE',
			field: 'ENTIDADE',
			maxLength: 250,
			description: computed(() => this.Resources.ENTIDADE36471),
		}).cloneFrom(values?.ValEntidade))
		this.stopWatchers.push(watch(() => this.ValEntidade.value, (newValue, oldValue) => this.onUpdate('entidade.entidade', this.ValEntidade, newValue, oldValue)))

		this.ValSub_modelo_gestao = reactive(new modelFieldType.String({
			id: 'ValSub_modelo_gestao',
			originId: 'ValSub_modelo_gestao',
			area: 'ENTIDADE',
			field: 'SUB_MODELO_GESTAO',
			maxLength: 100,
			description: computed(() => this.Resources.SUBMODELO_DE_GESTAO34607),
		}).cloneFrom(values?.ValSub_modelo_gestao))
		this.stopWatchers.push(watch(() => this.ValSub_modelo_gestao.value, (newValue, oldValue) => this.onUpdate('entidade.sub_modelo_gestao', this.ValSub_modelo_gestao, newValue, oldValue)))

		this.ValSistema_contabilistico = reactive(new modelFieldType.String({
			id: 'ValSistema_contabilistico',
			originId: 'ValSistema_contabilistico',
			area: 'ENTIDADE',
			field: 'SISTEMA_CONTABILISTICO',
			maxLength: 5,
			arrayOptions: computed(() => new qProjArrays.QArraySistema_contabilistico(vm.$getResource).elements),
			description: computed(() => this.Resources.SISTEMA_CONTABILISTI21743),
		}).cloneFrom(values?.ValSistema_contabilistico))
		this.stopWatchers.push(watch(() => this.ValSistema_contabilistico.value, (newValue, oldValue) => this.onUpdate('entidade.sistema_contabilistico', this.ValSistema_contabilistico, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormEntidadeViewModel instance.
	 * @returns {QFormEntidadeViewModel} A new instance of QFormEntidadeViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodentidade'

	get QPrimaryKey() { return this.ValCodentidade.value }
	set QPrimaryKey(value) { this.ValCodentidade.updateValue(value) }
}
