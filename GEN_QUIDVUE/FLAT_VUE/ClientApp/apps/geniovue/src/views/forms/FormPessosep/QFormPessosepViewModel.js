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
			name: 'PESSOSEP',
			area: 'PESSO',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_PESSOSEP',
				updateFilesTickets: 'UpdateFilesTicketsPESSOSEP'
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
		watch(() => this.ValCodpesso.value, (newValue, oldValue) => this.onUpdate('pesso.codpesso', this.ValCodpesso, newValue, oldValue))

		/** The hidden foreign keys. */
		this.ValCodpaise = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpaise',
			originId: 'ValCodpaise',
			area: 'PESSO',
			field: 'CODPAISE',
			relatedArea: 'CNTRY',
			isFixed: true,
			description: computed(() => this.Resources.COMPANY_PARENTS01581),
		}).cloneFrom(values?.ValCodpaise))
		watch(() => this.ValCodpaise.value, (newValue, oldValue) => this.onUpdate('pesso.codpaise', this.ValCodpaise, newValue, oldValue))

		this.ValCodcntry = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcntry',
			originId: 'ValCodcntry',
			area: 'PESSO',
			field: 'CODCNTRY',
			relatedArea: 'PAIS1',
			isFixed: true,
			description: computed(() => this.Resources.PERSON_S_PARENTS05687),
		}).cloneFrom(values?.ValCodcntry))
		watch(() => this.ValCodcntry.value, (newValue, oldValue) => this.onUpdate('pesso.codcntry', this.ValCodcntry, newValue, oldValue))

		this.ValCodregia = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodregia',
			originId: 'ValCodregia',
			area: 'PESSO',
			field: 'CODREGIA',
			relatedArea: 'REGI1',
			isFixed: true,
			description: '',
		}).cloneFrom(values?.ValCodregia))
		watch(() => this.ValCodregia.value, (newValue, oldValue) => this.onUpdate('pesso.codregia', this.ValCodregia, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodcateg = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcateg',
			originId: 'ValCodcateg',
			area: 'PESSO',
			field: 'CODCATEG',
			relatedArea: 'CATEG',
			description: computed(() => this.Resources._LAST_CATEGORY61019),
		}).cloneFrom(values?.ValCodcateg))
		watch(() => this.ValCodcateg.value, (newValue, oldValue) => this.onUpdate('pesso.codcateg', this.ValCodcateg, newValue, oldValue))

		this.ValCodempre = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodempre',
			originId: 'ValCodempre',
			area: 'PESSO',
			field: 'CODEMPRE',
			relatedArea: 'CMPNY',
			description: computed(() => this.Resources._COMPANY02087),
		}).cloneFrom(values?.ValCodempre))
		watch(() => this.ValCodempre.value, (newValue, oldValue) => this.onUpdate('pesso.codempre', this.ValCodempre, newValue, oldValue))

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
		watch(() => this.ValIdfuncio.value, (newValue, oldValue) => this.onUpdate('pesso.idfuncio', this.ValIdfuncio, newValue, oldValue))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'PESSO',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('pesso.name', this.ValName, newValue, oldValue))

		this.ValDtnascim = reactive(new modelFieldType.Date({
			id: 'ValDtnascim',
			originId: 'ValDtnascim',
			area: 'PESSO',
			field: 'DTNASCIM',
			description: computed(() => this.Resources.BIRTH21799),
		}).cloneFrom(values?.ValDtnascim))
		watch(() => this.ValDtnascim.value, (newValue, oldValue) => this.onUpdate('pesso.dtnascim', this.ValDtnascim, newValue, oldValue))

		this.ValGender = reactive(new modelFieldType.String({
			id: 'ValGender',
			originId: 'ValGender',
			area: 'PESSO',
			field: 'GENDER',
			maxLength: 1,
			arrayOptions: computed(() => qProjArrays.QArrayGenero.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.GENUS37471),
		}).cloneFrom(values?.ValGender))
		watch(() => this.ValGender.value, (newValue, oldValue) => this.onUpdate('pesso.gender', this.ValGender, newValue, oldValue))

		this.ValInterna = reactive(new modelFieldType.Boolean({
			id: 'ValInterna',
			originId: 'ValInterna',
			area: 'PESSO',
			field: 'INTERNA',
			description: computed(() => this.Resources.INTERNAL04894),
		}).cloneFrom(values?.ValInterna))
		watch(() => this.ValInterna.value, (newValue, oldValue) => this.onUpdate('pesso.interna', this.ValInterna, newValue, oldValue))

		this.ValExterna = reactive(new modelFieldType.Boolean({
			id: 'ValExterna',
			originId: 'ValExterna',
			area: 'PESSO',
			field: 'EXTERNA',
			description: computed(() => this.Resources.EXTERNAL13375),
		}).cloneFrom(values?.ValExterna))
		watch(() => this.ValExterna.value, (newValue, oldValue) => this.onUpdate('pesso.externa', this.ValExterna, newValue, oldValue))

		this.TableCategCategory = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCategCategory',
			originId: 'ValCategoria',
			area: 'CATEG',
			field: 'CATEGORY',
			maxLength: 50,
			description: computed(() => this.Resources.CATEGORY18978),
		}).cloneFrom(values?.TableCategCategory))
		watch(() => this.TableCategCategory.value, (newValue, oldValue) => this.onUpdate('categ.categoria', this.TableCategCategory, newValue, oldValue))

		this.ValDtultcat = reactive(new modelFieldType.Date({
			id: 'ValDtultcat',
			originId: 'ValDtultcat',
			area: 'PESSO',
			field: 'DTULTCAT',
			isFixed: true,
			description: computed(() => this.Resources.SINCE47259),
		}).cloneFrom(values?.ValDtultcat))
		watch(() => this.ValDtultcat.value, (newValue, oldValue) => this.onUpdate('pesso.dtultcat', this.ValDtultcat, newValue, oldValue))

		this.ValCurricul = reactive(new modelFieldType.Document({
			id: 'ValCurricul',
			originId: 'ValCurricul',
			area: 'PESSO',
			field: 'CURRICUL',
			properties: computed(() => this.ValCurriculPropertiesVM),
			documentFK: computed(() => this.ValCurriculfk),
			currentDocument: computed(() => this.ValCurriculData),
			description: computed(() => this.Resources.CURRICULUM51182),
		}).cloneFrom(values?.ValCurricul))
		watch(() => this.ValCurricul.value, (newValue, oldValue) => this.onUpdate('pesso.curricul', this.ValCurricul, newValue, oldValue))

		this.ValCurriculPropertiesVM = reactive(new modelFieldType.Base({
			id: 'ValCurriculPropertiesVM',
			area: 'PESSO',
			field: 'CURRICULDOCUM',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValCurriculPropertiesVM))
		this.ValCurriculfk = reactive(new modelFieldType.String({
			id: 'ValCurriculfk',
			area: 'PESSO',
			field: 'CURRICULFK'
		}).cloneFrom(values?.ValCurriculfk))
		watch(() => this.ValCurriculfk.value, (newValue, oldValue) => this.onUpdate('pesso.curriculfk', this.ValCurriculfk, newValue, oldValue))
		this.ValCurriculData = reactive(new modelFieldType.DocumentData({
			id: 'ValCurriculData',
			area: 'PESSO',
			field: 'CURRICULDATA',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValCurriculData))
		watch(() => this.ValCurriculData.value, (newValue, oldValue) => this.onUpdate('pesso.curriculdata', this.ValCurriculData, newValue, oldValue), { deep: true })

		this.TableCmpnyDesignat = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCmpnyDesignat',
			originId: 'ValDesignat',
			area: 'CMPNY',
			field: 'DESIGNAT',
			maxLength: 85,
			description: computed(() => this.Resources.DESIGNATION35876),
		}).cloneFrom(values?.TableCmpnyDesignat))
		watch(() => this.TableCmpnyDesignat.value, (newValue, oldValue) => this.onUpdate('cmpny.designat', this.TableCmpnyDesignat, newValue, oldValue))

		this.ValTelephon = reactive(new modelFieldType.String({
			id: 'ValTelephon',
			originId: 'ValTelephon',
			area: 'PESSO',
			field: 'TELEPHON',
			maxLength: 20,
			description: computed(() => this.Resources.PHONE56703),
		}).cloneFrom(values?.ValTelephon))
		watch(() => this.ValTelephon.value, (newValue, oldValue) => this.onUpdate('pesso.telephon', this.ValTelephon, newValue, oldValue))

		this.ValEmail = reactive(new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'PESSO',
			field: 'EMAIL',
			maxLength: 254,
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.ValEmail))
		watch(() => this.ValEmail.value, (newValue, oldValue) => this.onUpdate('pesso.email', this.ValEmail, newValue, oldValue))

		this.ValPhotogra = reactive(new modelFieldType.Image({
			id: 'ValPhotogra',
			originId: 'ValPhotogra',
			area: 'PESSO',
			field: 'PHOTOGRA',
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.ValPhotogra))
		watch(() => this.ValPhotogra.value, (newValue, oldValue) => this.onUpdate('pesso.photogra', this.ValPhotogra, newValue, oldValue))

		/** The form fields used only in formulas. */
		this.ValEmail2 = reactive(new modelFieldType.String({
			id: 'ValEmail2',
			originId: 'ValEmail2',
			area: 'PESSO',
			field: 'EMAIL2',
			maxLength: 254,
			isFixed: true,
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.ValEmail2))
		watch(() => this.ValEmail2.value, (newValue, oldValue) => this.onUpdate('pesso.email2', this.ValEmail2, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormPessosepViewModel instance.
	 * @returns {QFormPessosepViewModel} A new instance of QFormPessosepViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodpesso'

	get QPrimaryKey() { return this.ValCodpesso.value }
	set QPrimaryKey(value) { this.ValCodpesso.updateValue(value) }
}
