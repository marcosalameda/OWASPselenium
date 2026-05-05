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
			name: 'WID_COLA',
			area: 'CMPNY',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_WID_COLA',
				updateFilesTickets: 'UpdateFilesTicketsWID_COLA'
			}
		})

		/** The primary key. */
		this.ValCodempre = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodempre',
			originId: 'ValCodempre',
			area: 'CMPNY',
			field: 'CODEMPRE',
			description: computed(() => this.Resources.COMPANIES04875),
		}).cloneFrom(values?.ValCodempre))
		watch(() => this.ValCodempre.value, (newValue, oldValue) => this.onUpdate('cmpny.codempre', this.ValCodempre, newValue, oldValue))

		/** The hidden foreign keys. */
		this.ValCodcntry = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcntry',
			originId: 'ValCodcntry',
			area: 'CMPNY',
			field: 'CODCNTRY',
			relatedArea: 'CNTRY',
			isFixed: true,
			description: '',
		}).cloneFrom(values?.ValCodcntry))
		watch(() => this.ValCodcntry.value, (newValue, oldValue) => this.onUpdate('cmpny.codcntry', this.ValCodcntry, newValue, oldValue))

		/** The remaining form fields. */
		this.ValLogo = reactive(new modelFieldType.Image({
			id: 'ValLogo',
			originId: 'ValLogo',
			area: 'CMPNY',
			field: 'LOGO',
			description: computed(() => this.Resources.LOGO62483),
		}).cloneFrom(values?.ValLogo))
		watch(() => this.ValLogo.value, (newValue, oldValue) => this.onUpdate('cmpny.logo', this.ValLogo, newValue, oldValue))

		this.ValDesignat = reactive(new modelFieldType.String({
			id: 'ValDesignat',
			originId: 'ValDesignat',
			area: 'CMPNY',
			field: 'DESIGNAT',
			maxLength: 85,
			description: computed(() => this.Resources.DESIGNATION35876),
		}).cloneFrom(values?.ValDesignat))
		watch(() => this.ValDesignat.value, (newValue, oldValue) => this.onUpdate('cmpny.designat', this.ValDesignat, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormWidColaViewModel instance.
	 * @returns {QFormWidColaViewModel} A new instance of QFormWidColaViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodempre'

	get QPrimaryKey() { return this.ValCodempre.value }
	set QPrimaryKey(value) { this.ValCodempre.updateValue(value) }
}
