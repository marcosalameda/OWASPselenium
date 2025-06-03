/* eslint-disable no-unused-vars */
import { computed, reactive, watch } from 'vue'
import _merge from 'lodash-es/merge'

import ViewModelBase from '@/mixins/formViewModelBase.js'
import genericFunctions from '@/mixins/genericFunctions.js'
import modelFieldType from '@/mixins/formModelFieldTypes.js'

import hardcodedTexts from '@/hardcodedTexts.js'
import netAPI from '@/api/network'
import qApi from '@/api/genio/quidgestFunctions.js'
import qFunctions from '@/api/genio/projectFunctions.js'
import qProjArrays from '@/api/genio/projectArrays.js'
/* eslint-enable no-unused-vars */

/**
 * Represents a ViewModel class.
 * @extends ViewModelBase
 */
export default class ViewModel extends ViewModelBase
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

		/** The view model metadata */
		_merge(this.modelInfo, {
			name: 'PESSO1',
			area: 'PESSO',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_PESSO1'
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

		this.ValCodregia = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodregia',
			originId: 'ValCodregia',
			area: 'PESSO',
			field: 'CODREGIA',
			relatedArea: 'REGI1',
			description: '',
		}).cloneFrom(values?.ValCodregia))
		watch(() => this.ValCodregia.value, (newValue, oldValue) => this.onUpdate('pesso.codregia', this.ValCodregia, newValue, oldValue))

		/** The remaining form fields. */
		this.ValPhotogra = reactive(new modelFieldType.Image({
			id: 'ValPhotogra',
			originId: 'ValPhotogra',
			area: 'PESSO',
			field: 'PHOTOGRA',
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.ValPhotogra))
		watch(() => this.ValPhotogra.value, (newValue, oldValue) => this.onUpdate('pesso.photogra', this.ValPhotogra, newValue, oldValue))

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

		this.ValIdade = reactive(new modelFieldType.Number({
			id: 'ValIdade',
			originId: 'ValIdade',
			area: 'PESSO',
			field: 'IDADE',
			maxDigits: 5,
			decimalDigits: 0,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: Idade([PESSO->DTNASCIM],[Today])
					return qFunctions.Idade(this.ValDtnascim.value,qApi.Hoje())
				},
				dependencyEvents: ['fieldChange:pesso.dtnascim'],
				isServerRecalc: false,
				isEmpty: qApi.emptyN,
			},
			description: computed(() => this.Resources.AGE28663),
		}).cloneFrom(values?.ValIdade))
		watch(() => this.ValIdade.value, (newValue, oldValue) => this.onUpdate('pesso.idade', this.ValIdade, newValue, oldValue))

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

		this.CntryValCountry = reactive(new modelFieldType.String({
			id: 'CntryValCountry',
			originId: 'ValCountry',
			area: 'CNTRY',
			field: 'COUNTRY',
			maxLength: 90,
			isFixed: true,
			description: computed(() => this.Resources.COUNTRY64133),
		}).cloneFrom(values?.CntryValCountry))
		watch(() => this.CntryValCountry.value, (newValue, oldValue) => this.onUpdate('cntry.country', this.CntryValCountry, newValue, oldValue))

		this.TableRegi1Regiao = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableRegi1Regiao',
			originId: 'ValRegiao',
			area: 'REGI1',
			field: 'REGIAO',
			maxLength: 50,
			description: computed(() => this.Resources.REGION12723),
		}).cloneFrom(values?.TableRegi1Regiao))
		watch(() => this.TableRegi1Regiao.value, (newValue, oldValue) => this.onUpdate('regi1.regiao', this.TableRegi1Regiao, newValue, oldValue))

		this.Pais1ValCountry = reactive(new modelFieldType.String({
			id: 'Pais1ValCountry',
			originId: 'ValCountry',
			area: 'PAIS1',
			field: 'COUNTRY',
			maxLength: 90,
			isFixed: true,
			description: computed(() => this.Resources.COUNTRY64133),
		}).cloneFrom(values?.Pais1ValCountry))
		watch(() => this.Pais1ValCountry.value, (newValue, oldValue) => this.onUpdate('pais1.country', this.Pais1ValCountry, newValue, oldValue))

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
	 * Creates a clone of the current QFormPesso1ViewModel instance.
	 * @returns {QFormPesso1ViewModel} A new instance of QFormPesso1ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodpesso'

	get QPrimaryKey() { return this.ValCodpesso.value }
	set QPrimaryKey(value) { this.ValCodpesso.updateValue(value) }
}
