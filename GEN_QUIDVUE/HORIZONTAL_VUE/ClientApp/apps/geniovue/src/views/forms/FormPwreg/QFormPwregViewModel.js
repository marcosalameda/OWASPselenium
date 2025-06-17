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
			name: 'PWREG',
			area: 'PWREG',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_PWREG',
				updateFilesTickets: 'UpdateFilesTicketsPWREG'
			}
		})

		/** The primary key. */
		this.ValCodpwreg = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodpwreg',
			originId: 'ValCodpwreg',
			area: 'PWREG',
			field: 'CODPWREG',
			description: '',
		}).cloneFrom(values?.ValCodpwreg))
		watch(() => this.ValCodpwreg.value, (newValue, oldValue) => this.onUpdate('pwreg.codpwreg', this.ValCodpwreg, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodpsw = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpsw',
			originId: 'ValCodpsw',
			area: 'PWREG',
			field: 'CODPSW',
			relatedArea: 'PSW',
			description: '',
		}).cloneFrom(values?.ValCodpsw))
		watch(() => this.ValCodpsw.value, (newValue, oldValue) => this.onUpdate('pwreg.codpsw', this.ValCodpsw, newValue, oldValue))

		this.ValCodregia = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodregia',
			originId: 'ValCodregia',
			area: 'PWREG',
			field: 'CODREGIA',
			relatedArea: 'REGIO',
			description: '',
		}).cloneFrom(values?.ValCodregia))
		watch(() => this.ValCodregia.value, (newValue, oldValue) => this.onUpdate('pwreg.codregia', this.ValCodregia, newValue, oldValue))

		/** The remaining form fields. */
		this.TablePswNome = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePswNome',
			originId: 'ValNome',
			area: 'PSW',
			field: 'NOME',
			maxLength: 100,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TablePswNome))
		watch(() => this.TablePswNome.value, (newValue, oldValue) => this.onUpdate('psw.nome', this.TablePswNome, newValue, oldValue))

		this.TableRegioRegiao = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableRegioRegiao',
			originId: 'ValRegiao',
			area: 'REGIO',
			field: 'REGIAO',
			maxLength: 50,
			description: computed(() => this.Resources.REGION12723),
		}).cloneFrom(values?.TableRegioRegiao))
		watch(() => this.TableRegioRegiao.value, (newValue, oldValue) => this.onUpdate('regio.regiao', this.TableRegioRegiao, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormPwregViewModel instance.
	 * @returns {QFormPwregViewModel} A new instance of QFormPwregViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodpwreg'

	get QPrimaryKey() { return this.ValCodpwreg.value }
	set QPrimaryKey(value) { this.ValCodpwreg.updateValue(value) }
}
