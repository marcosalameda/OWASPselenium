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
			name: 'PESSO',
			area: 'PESSO',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_PESSO'
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
			description: computed(() => this.Resources.COMPANY_PARENTS01581),
			isFixed: true,
		}).cloneFrom(values?.ValCodpaise))
		watch(() => this.ValCodpaise.value, (newValue, oldValue) => this.onUpdate('pesso.codpaise', this.ValCodpaise, newValue, oldValue))

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

		this.ValCodcntry = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcntry',
			originId: 'ValCodcntry',
			area: 'PESSO',
			field: 'CODCNTRY',
			relatedArea: 'PAIS1',
			description: computed(() => this.Resources.PERSON_S_PARENTS05687),
		}).cloneFrom(values?.ValCodcntry))
		watch(() => this.ValCodcntry.value, (newValue, oldValue) => this.onUpdate('pesso.codcntry', this.ValCodcntry, newValue, oldValue))

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

		this.ValGender = reactive(new modelFieldType.String({
			id: 'ValGender',
			originId: 'ValGender',
			area: 'PESSO',
			field: 'GENDER',
			arrayOptions: qProjArrays.QArrayGenero.setResources(vm.$getResource).elements,
			maxLength: 1,
			description: computed(() => this.Resources.GENUS37471),
		}).cloneFrom(values?.ValGender))
		watch(() => this.ValGender.value, (newValue, oldValue) => this.onUpdate('pesso.gender', this.ValGender, newValue, oldValue))

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
			description: computed(() => this.Resources.AGE28663),
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
		}).cloneFrom(values?.ValIdade))
		watch(() => this.ValIdade.value, (newValue, oldValue) => this.onUpdate('pesso.idade', this.ValIdade, newValue, oldValue))

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
			description: computed(() => this.Resources.SINCE47259),
			isFixed: true,
		}).cloneFrom(values?.ValDtultcat))
		watch(() => this.ValDtultcat.value, (newValue, oldValue) => this.onUpdate('pesso.dtultcat', this.ValDtultcat, newValue, oldValue))

		this.TablePais1Country = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePais1Country',
			originId: 'ValCountry',
			area: 'PAIS1',
			field: 'COUNTRY',
			maxLength: 90,
			description: computed(() => this.Resources.COUNTRY64133),
		}).cloneFrom(values?.TablePais1Country))
		watch(() => this.TablePais1Country.value, (newValue, oldValue) => this.onUpdate('pais1.country', this.TablePais1Country, newValue, oldValue))

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
			description: computed(() => this.Resources.COUNTRY64133),
			isFixed: true,
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

		this.ValEmail2 = reactive(new modelFieldType.String({
			id: 'ValEmail2',
			originId: 'ValEmail2',
			area: 'PESSO',
			field: 'EMAIL2',
			maxLength: 254,
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.ValEmail2))
		watch(() => this.ValEmail2.value, (newValue, oldValue) => this.onUpdate('pesso.email2', this.ValEmail2, newValue, oldValue))

		this.ValExtquery = reactive(new modelFieldType.String({
			id: 'ValExtquery',
			originId: 'ValExtquery',
			area: 'PESSO',
			field: 'EXTQUERY',
			maxLength: 250,
			description: computed(() => this.Resources.QUERY_FOR_EXTERNAL_A51761),
		}).cloneFrom(values?.ValExtquery))
		watch(() => this.ValExtquery.value, (newValue, oldValue) => this.onUpdate('pesso.extquery', this.ValExtquery, newValue, oldValue))

		this.ValZoomlvl = reactive(new modelFieldType.Number({
			id: 'ValZoomlvl',
			originId: 'ValZoomlvl',
			area: 'PESSO',
			field: 'ZOOMLVL',
			maxDigits: 2,
			decimalDigits: 0,
			description: computed(() => this.Resources.ZOOM_LEVEL17268),
		}).cloneFrom(values?.ValZoomlvl))
		watch(() => this.ValZoomlvl.value, (newValue, oldValue) => this.onUpdate('pesso.zoomlvl', this.ValZoomlvl, newValue, oldValue))

		this.ValExtminzm = reactive(new modelFieldType.Number({
			id: 'ValExtminzm',
			originId: 'ValExtminzm',
			area: 'PESSO',
			field: 'EXTMINZM',
			maxDigits: 2,
			decimalDigits: 0,
			description: computed(() => this.Resources.MINIMUM_ZOOM_TO_LOAD08509),
		}).cloneFrom(values?.ValExtminzm))
		watch(() => this.ValExtminzm.value, (newValue, oldValue) => this.onUpdate('pesso.extminzm', this.ValExtminzm, newValue, oldValue))

		this.ValMapheigh = reactive(new modelFieldType.String({
			id: 'ValMapheigh',
			originId: 'ValMapheigh',
			area: 'PESSO',
			field: 'MAPHEIGH',
			maxLength: 50,
			description: computed(() => this.Resources.MAP_HEIGHT06476),
		}).cloneFrom(values?.ValMapheigh))
		watch(() => this.ValMapheigh.value, (newValue, oldValue) => this.onUpdate('pesso.mapheigh', this.ValMapheigh, newValue, oldValue))

		this.ValOutweigh = reactive(new modelFieldType.Number({
			id: 'ValOutweigh',
			originId: 'ValOutweigh',
			area: 'PESSO',
			field: 'OUTWEIGH',
			maxDigits: 2,
			decimalDigits: 0,
			description: computed(() => this.Resources.OUTLINE_WEIGHT25236),
		}).cloneFrom(values?.ValOutweigh))
		watch(() => this.ValOutweigh.value, (newValue, oldValue) => this.onUpdate('pesso.outweigh', this.ValOutweigh, newValue, oldValue))

		this.ValLineclr = reactive(new modelFieldType.String({
			id: 'ValLineclr',
			originId: 'ValLineclr',
			area: 'PESSO',
			field: 'LINECLR',
			maxLength: 50,
			description: computed(() => this.Resources.POLYLINE_COLOR11664),
		}).cloneFrom(values?.ValLineclr))
		watch(() => this.ValLineclr.value, (newValue, oldValue) => this.onUpdate('pesso.lineclr', this.ValLineclr, newValue, oldValue))

		this.ValPolyclr = reactive(new modelFieldType.String({
			id: 'ValPolyclr',
			originId: 'ValPolyclr',
			area: 'PESSO',
			field: 'POLYCLR',
			maxLength: 50,
			description: computed(() => this.Resources.POLYGON_COLOR32161),
		}).cloneFrom(values?.ValPolyclr))
		watch(() => this.ValPolyclr.value, (newValue, oldValue) => this.onUpdate('pesso.polyclr', this.ValPolyclr, newValue, oldValue))

		this.ValDrawmrk = reactive(new modelFieldType.Boolean({
			id: 'ValDrawmrk',
			originId: 'ValDrawmrk',
			area: 'PESSO',
			field: 'DRAWMRK',
			description: computed(() => this.Resources.ALLOW_DRAWING_MARKER56732),
		}).cloneFrom(values?.ValDrawmrk))
		watch(() => this.ValDrawmrk.value, (newValue, oldValue) => this.onUpdate('pesso.drawmrk', this.ValDrawmrk, newValue, oldValue))

		this.ValAllowlin = reactive(new modelFieldType.Boolean({
			id: 'ValAllowlin',
			originId: 'ValAllowlin',
			area: 'PESSO',
			field: 'ALLOWLIN',
			description: computed(() => this.Resources.ALLOW_DRAWING_POLYLI25703),
		}).cloneFrom(values?.ValAllowlin))
		watch(() => this.ValAllowlin.value, (newValue, oldValue) => this.onUpdate('pesso.allowlin', this.ValAllowlin, newValue, oldValue))

		this.ValAllowpol = reactive(new modelFieldType.Boolean({
			id: 'ValAllowpol',
			originId: 'ValAllowpol',
			area: 'PESSO',
			field: 'ALLOWPOL',
			description: computed(() => this.Resources.ALLOW_DRAWING_POLYGO46480),
		}).cloneFrom(values?.ValAllowpol))
		watch(() => this.ValAllowpol.value, (newValue, oldValue) => this.onUpdate('pesso.allowpol', this.ValAllowpol, newValue, oldValue))

		this.ValCanexpor = reactive(new modelFieldType.Boolean({
			id: 'ValCanexpor',
			originId: 'ValCanexpor',
			area: 'PESSO',
			field: 'CANEXPOR',
			description: computed(() => this.Resources.ALLOW_EXPORTING_MAP27916),
		}).cloneFrom(values?.ValCanexpor))
		watch(() => this.ValCanexpor.value, (newValue, oldValue) => this.onUpdate('pesso.canexpor', this.ValCanexpor, newValue, oldValue))

		this.ValGroupmrk = reactive(new modelFieldType.Boolean({
			id: 'ValGroupmrk',
			originId: 'ValGroupmrk',
			area: 'PESSO',
			field: 'GROUPMRK',
			description: computed(() => this.Resources.GROUP_MARKERS_IN_CLU31341),
		}).cloneFrom(values?.ValGroupmrk))
		watch(() => this.ValGroupmrk.value, (newValue, oldValue) => this.onUpdate('pesso.groupmrk', this.ValGroupmrk, newValue, oldValue))

		this.ValCanedit = reactive(new modelFieldType.Boolean({
			id: 'ValCanedit',
			originId: 'ValCanedit',
			area: 'PESSO',
			field: 'CANEDIT',
			description: computed(() => this.Resources.ALLOW_FEATURE_EDITIN16439),
		}).cloneFrom(values?.ValCanedit))
		watch(() => this.ValCanedit.value, (newValue, oldValue) => this.onUpdate('pesso.canedit', this.ValCanedit, newValue, oldValue))

		this.ValCancut = reactive(new modelFieldType.Boolean({
			id: 'ValCancut',
			originId: 'ValCancut',
			area: 'PESSO',
			field: 'CANCUT',
			description: computed(() => this.Resources.ALLOW_FEATURE_CUTTIN10746),
		}).cloneFrom(values?.ValCancut))
		watch(() => this.ValCancut.value, (newValue, oldValue) => this.onUpdate('pesso.cancut', this.ValCancut, newValue, oldValue))

		this.ValCandrag = reactive(new modelFieldType.Boolean({
			id: 'ValCandrag',
			originId: 'ValCandrag',
			area: 'PESSO',
			field: 'CANDRAG',
			description: computed(() => this.Resources.ALLOW_FEATURE_DRAGGI09054),
		}).cloneFrom(values?.ValCandrag))
		watch(() => this.ValCandrag.value, (newValue, oldValue) => this.onUpdate('pesso.candrag', this.ValCandrag, newValue, oldValue))

		this.ValCanrot = reactive(new modelFieldType.Boolean({
			id: 'ValCanrot',
			originId: 'ValCanrot',
			area: 'PESSO',
			field: 'CANROT',
			description: computed(() => this.Resources.ALLOW_FEATURE_ROTATI56653),
		}).cloneFrom(values?.ValCanrot))
		watch(() => this.ValCanrot.value, (newValue, oldValue) => this.onUpdate('pesso.canrot', this.ValCanrot, newValue, oldValue))

		this.ValCanremov = reactive(new modelFieldType.Boolean({
			id: 'ValCanremov',
			originId: 'ValCanremov',
			area: 'PESSO',
			field: 'CANREMOV',
			description: computed(() => this.Resources.ALLOW_FEATURE_REMOVA13844),
		}).cloneFrom(values?.ValCanremov))
		watch(() => this.ValCanremov.value, (newValue, oldValue) => this.onUpdate('pesso.canremov', this.ValCanremov, newValue, oldValue))

		this.ValTerrain = reactive(new modelFieldType.Geographic({
			id: 'ValTerrain',
			originId: 'ValTerrain',
			area: 'PESSO',
			field: 'TERRAIN',
			description: computed(() => this.Resources.TERRAIN43857),
		}).cloneFrom(values?.ValTerrain))
		watch(() => this.ValTerrain.value, (newValue, oldValue) => this.onUpdate('pesso.terrain', this.ValTerrain, newValue, oldValue), { deep: true })
		/** The Multiple Values value. */
		this.List_Especial_SelectedIds = reactive(new modelFieldType.MultipleValues({
			id: 'List_Especial_SelectedIds',
			originId: 'ValEspecial',
			area: 'SPECI',
			field: 'ESPECIAL'
		}).cloneFrom(values?.List_Especial_SelectedIds))
		watch(() => this.List_Especial_SelectedIds.value, (newValue, oldValue) => this.onUpdate('pseud.especial', this.List_Especial_SelectedIds, newValue, oldValue))
		/** The Multiple Values options. */
		this.List_Especial = new modelFieldType.MultipleValues({
			id: 'List_Especial',
			ignoreFldSubmit: true
		}).cloneFrom(values?.List_Especial)

		/** The form fields used only in formulas. */
		this.CmpnyValHeadloc = reactive(new modelFieldType.Coordinate({
			id: 'CmpnyValHeadloc',
			originId: 'ValHeadloc',
			area: 'CMPNY',
			field: 'HEADLOC',
			description: computed(() => this.Resources.HEADQUARTER_LOCATION30734),
			isFixed: true,
		}).cloneFrom(values?.CmpnyValHeadloc))
		watch(() => this.CmpnyValHeadloc.value, (newValue, oldValue) => this.onUpdate('cmpny.headloc', this.CmpnyValHeadloc, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormPessoViewModel instance.
	 * @returns {QFormPessoViewModel} A new instance of QFormPessoViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodpesso'

	get QPrimaryKey() { return this.ValCodpesso.value }
	set QPrimaryKey(value) { this.ValCodpesso.updateValue(value) }
}
