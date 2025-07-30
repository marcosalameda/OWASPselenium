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
			name: 'PESSOHIS',
			area: 'PESSO',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Pessohis',
				updateFilesTickets: 'UpdateFilesTicketsPessohis',
				setFile: 'SetFilePessohis'
			}
		})

		/** The primary key. */
		this.ValCodpesso = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodpesso',
			originId: 'ValCodpesso',
			area: 'PESSO',
			field: 'CODPESSO',
			description: '',
		}).cloneFrom(values?.ValCodpesso))
		this.stopWatchers.push(watch(() => this.ValCodpesso.value, (newValue, oldValue) => this.onUpdate('pesso.codpesso', this.ValCodpesso, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValCodregia = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodregia',
			originId: 'ValCodregia',
			area: 'PESSO',
			field: 'CODREGIA',
			relatedArea: 'REGI1',
			isFixed: true,
			description: '',
		}).cloneFrom(values?.ValCodregia))
		this.stopWatchers.push(watch(() => this.ValCodregia.value, (newValue, oldValue) => this.onUpdate('pesso.codregia', this.ValCodregia, newValue, oldValue)))

		this.ValCodcntry = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcntry',
			originId: 'ValCodcntry',
			area: 'PESSO',
			field: 'CODCNTRY',
			relatedArea: 'PAIS1',
			isFixed: true,
			description: computed(() => this.Resources.PERSON_S_PARENTS05687),
		}).cloneFrom(values?.ValCodcntry))
		this.stopWatchers.push(watch(() => this.ValCodcntry.value, (newValue, oldValue) => this.onUpdate('pesso.codcntry', this.ValCodcntry, newValue, oldValue)))

		this.ValCodpaise = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpaise',
			originId: 'ValCodpaise',
			area: 'PESSO',
			field: 'CODPAISE',
			relatedArea: 'CNTRY',
			isFixed: true,
			description: computed(() => this.Resources.COMPANY_PARENTS01581),
		}).cloneFrom(values?.ValCodpaise))
		this.stopWatchers.push(watch(() => this.ValCodpaise.value, (newValue, oldValue) => this.onUpdate('pesso.codpaise', this.ValCodpaise, newValue, oldValue)))

		this.ValCodempre = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodempre',
			originId: 'ValCodempre',
			area: 'PESSO',
			field: 'CODEMPRE',
			relatedArea: 'CMPNY',
			isFixed: true,
			description: computed(() => this.Resources._COMPANY02087),
		}).cloneFrom(values?.ValCodempre))
		this.stopWatchers.push(watch(() => this.ValCodempre.value, (newValue, oldValue) => this.onUpdate('pesso.codempre', this.ValCodempre, newValue, oldValue)))

		this.ValCodcateg = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcateg',
			originId: 'ValCodcateg',
			area: 'PESSO',
			field: 'CODCATEG',
			relatedArea: 'CATEG',
			isFixed: true,
			description: computed(() => this.Resources._LAST_CATEGORY61019),
		}).cloneFrom(values?.ValCodcateg))
		this.stopWatchers.push(watch(() => this.ValCodcateg.value, (newValue, oldValue) => this.onUpdate('pesso.codcateg', this.ValCodcateg, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValIdfuncio = reactive(new modelFieldType.Number({
			id: 'ValIdfuncio',
			originId: 'ValIdfuncio',
			area: 'PESSO',
			field: 'IDFUNCIO',
			maxDigits: 6,
			decimalDigits: 0,
			description: computed(() => this.Resources.OFFICIAL_NO_34819),
		}).cloneFrom(values?.ValIdfuncio))
		this.stopWatchers.push(watch(() => this.ValIdfuncio.value, (newValue, oldValue) => this.onUpdate('pesso.idfuncio', this.ValIdfuncio, newValue, oldValue)))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'PESSO',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('pesso.name', this.ValName, newValue, oldValue)))

		/** The form fields used only in formulas. */
		this.ValEmail = reactive(new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'PESSO',
			field: 'EMAIL',
			maxLength: 254,
			isFixed: true,
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.ValEmail))
		this.stopWatchers.push(watch(() => this.ValEmail.value, (newValue, oldValue) => this.onUpdate('pesso.email', this.ValEmail, newValue, oldValue)))

		this.ValEmail2 = reactive(new modelFieldType.String({
			id: 'ValEmail2',
			originId: 'ValEmail2',
			area: 'PESSO',
			field: 'EMAIL2',
			maxLength: 254,
			isFixed: true,
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.ValEmail2))
		this.stopWatchers.push(watch(() => this.ValEmail2.value, (newValue, oldValue) => this.onUpdate('pesso.email2', this.ValEmail2, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormPessohisViewModel instance.
	 * @returns {QFormPessohisViewModel} A new instance of QFormPessohisViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodpesso'

	get QPrimaryKey() { return this.ValCodpesso.value }
	set QPrimaryKey(value) { this.ValCodpesso.updateValue(value) }
}
