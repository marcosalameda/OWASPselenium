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
			name: 'ESPPE',
			area: 'ESPPE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_ESPPE',
				updateFilesTickets: 'UpdateFilesTicketsESPPE'
			}
		})

		/** The primary key. */
		this.ValCodesppe = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodesppe',
			originId: 'ValCodesppe',
			area: 'ESPPE',
			field: 'CODESPPE',
			description: '',
		}).cloneFrom(values?.ValCodesppe))
		watch(() => this.ValCodesppe.value, (newValue, oldValue) => this.onUpdate('esppe.codesppe', this.ValCodesppe, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodpesso = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpesso',
			originId: 'ValCodpesso',
			area: 'ESPPE',
			field: 'CODPESSO',
			relatedArea: 'PESSO',
			description: '',
		}).cloneFrom(values?.ValCodpesso))
		watch(() => this.ValCodpesso.value, (newValue, oldValue) => this.onUpdate('esppe.codpesso', this.ValCodpesso, newValue, oldValue))

		this.ValCodespec = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodespec',
			originId: 'ValCodespec',
			area: 'ESPPE',
			field: 'CODESPEC',
			relatedArea: 'SPECI',
			description: '',
		}).cloneFrom(values?.ValCodespec))
		watch(() => this.ValCodespec.value, (newValue, oldValue) => this.onUpdate('esppe.codespec', this.ValCodespec, newValue, oldValue))

		/** The remaining form fields. */
		this.TablePessoName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePessoName',
			originId: 'ValName',
			area: 'PESSO',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TablePessoName))
		watch(() => this.TablePessoName.value, (newValue, oldValue) => this.onUpdate('pesso.name', this.TablePessoName, newValue, oldValue))

		this.TableSpeciEspecial = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableSpeciEspecial',
			originId: 'ValEspecial',
			area: 'SPECI',
			field: 'ESPECIAL',
			maxLength: 50,
			description: computed(() => this.Resources.SPECIALTY09304),
		}).cloneFrom(values?.TableSpeciEspecial))
		watch(() => this.TableSpeciEspecial.value, (newValue, oldValue) => this.onUpdate('speci.especial', this.TableSpeciEspecial, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormEsppeViewModel instance.
	 * @returns {QFormEsppeViewModel} A new instance of QFormEsppeViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodesppe'

	get QPrimaryKey() { return this.ValCodesppe.value }
	set QPrimaryKey(value) { this.ValCodesppe.updateValue(value) }
}
