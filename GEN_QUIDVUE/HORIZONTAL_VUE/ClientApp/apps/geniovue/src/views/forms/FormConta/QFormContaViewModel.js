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
			name: 'CONTA',
			area: 'CONTA',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Conta',
				updateFilesTickets: 'UpdateFilesTicketsConta',
				setFile: 'SetFileConta'
			}
		})

		/** The primary key. */
		this.ValCodconta = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodconta',
			originId: 'ValCodconta',
			area: 'CONTA',
			field: 'CODCONTA',
			description: '',
		}).cloneFrom(values?.ValCodconta))
		this.stopWatchers.push(watch(() => this.ValCodconta.value, (newValue, oldValue) => this.onUpdate('conta.codconta', this.ValCodconta, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodpesso = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpesso',
			originId: 'ValCodpesso',
			area: 'CONTA',
			field: 'CODPESSO',
			relatedArea: 'PESSO',
			description: '',
		}).cloneFrom(values?.ValCodpesso))
		this.stopWatchers.push(watch(() => this.ValCodpesso.value, (newValue, oldValue) => this.onUpdate('conta.codpesso', this.ValCodpesso, newValue, oldValue)))

		this.ValCodgenre = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodgenre',
			originId: 'ValCodgenre',
			area: 'CONTA',
			field: 'CODGENRE',
			relatedArea: 'GENRE',
			description: '',
		}).cloneFrom(values?.ValCodgenre))
		this.stopWatchers.push(watch(() => this.ValCodgenre.value, (newValue, oldValue) => this.onUpdate('conta.codgenre', this.ValCodgenre, newValue, oldValue)))

		this.ValCodtpcon = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodtpcon',
			originId: 'ValCodtpcon',
			area: 'CONTA',
			field: 'CODTPCON',
			relatedArea: 'TPCON',
			description: computed(() => this.Resources.CONTACT_TYPE65233),
		}).cloneFrom(values?.ValCodtpcon))
		this.stopWatchers.push(watch(() => this.ValCodtpcon.value, (newValue, oldValue) => this.onUpdate('conta.codtpcon', this.ValCodtpcon, newValue, oldValue)))

		/** The remaining form fields. */
		this.TablePessoName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePessoName',
			originId: 'ValName',
			area: 'PESSO',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.NAME31974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TablePessoName))
		this.stopWatchers.push(watch(() => this.TablePessoName.value, (newValue, oldValue) => this.onUpdate('pesso.name', this.TablePessoName, newValue, oldValue)))

		this.TableGenreGender = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableGenreGender',
			originId: 'ValGender',
			area: 'GENRE',
			field: 'GENDER',
			maxLength: 20,
			description: computed(() => this.Resources.GENRE63303),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableGenreGender))
		this.stopWatchers.push(watch(() => this.TableGenreGender.value, (newValue, oldValue) => this.onUpdate('genre.gender', this.TableGenreGender, newValue, oldValue)))

		this.TableTpconTipocont = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableTpconTipocont',
			originId: 'ValTipocont',
			area: 'TPCON',
			field: 'TIPOCONT',
			maxLength: 50,
			description: computed(() => this.Resources.DESIGNATION35876),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableTpconTipocont))
		this.stopWatchers.push(watch(() => this.TableTpconTipocont.value, (newValue, oldValue) => this.onUpdate('tpcon.tipocont', this.TableTpconTipocont, newValue, oldValue)))

		this.ValContacto = reactive(new modelFieldType.String({
			id: 'ValContacto',
			originId: 'ValContacto',
			area: 'CONTA',
			field: 'CONTACTO',
			maxLength: 254,
			description: computed(() => this.Resources.CONTACT59247),
		}).cloneFrom(values?.ValContacto))
		this.stopWatchers.push(watch(() => this.ValContacto.value, (newValue, oldValue) => this.onUpdate('conta.contacto', this.ValContacto, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormContaViewModel instance.
	 * @returns {QFormContaViewModel} A new instance of QFormContaViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodconta'

	get QPrimaryKey() { return this.ValCodconta.value }
	set QPrimaryKey(value) { this.ValCodconta.updateValue(value) }
}
