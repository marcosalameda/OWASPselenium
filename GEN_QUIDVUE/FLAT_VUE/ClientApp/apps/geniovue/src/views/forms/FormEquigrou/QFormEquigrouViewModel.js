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
			name: 'EQUIGROU',
			area: 'EQUIP',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_EQUIGROU'
			}
		})

		/** The primary key. */
		this.ValCodequip = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodequip',
			originId: 'ValCodequip',
			area: 'EQUIP',
			field: 'CODEQUIP',
			description: '',
		}).cloneFrom(values?.ValCodequip))
		watch(() => this.ValCodequip.value, (newValue, oldValue) => this.onUpdate('equip.codequip', this.ValCodequip, newValue, oldValue))

		/** The hidden foreign keys. */
		this.ValCodrooms = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodrooms',
			originId: 'ValCodrooms',
			area: 'EQUIP',
			field: 'CODROOMS',
			relatedArea: 'ROOM1',
			isFixed: true,
			description: '',
		}).cloneFrom(values?.ValCodrooms))
		watch(() => this.ValCodrooms.value, (newValue, oldValue) => this.onUpdate('equip.codrooms', this.ValCodrooms, newValue, oldValue))

		this.ValCoddeco = reactive(new modelFieldType.ForeignKey({
			id: 'ValCoddeco',
			originId: 'ValCoddeco',
			area: 'EQUIP',
			field: 'CODDECO',
			relatedArea: 'DECOM',
			isFixed: true,
			description: '',
		}).cloneFrom(values?.ValCoddeco))
		watch(() => this.ValCoddeco.value, (newValue, oldValue) => this.onUpdate('equip.coddeco', this.ValCoddeco, newValue, oldValue))

		this.ValCodempre = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodempre',
			originId: 'ValCodempre',
			area: 'EQUIP',
			field: 'CODEMPRE',
			relatedArea: 'CMPNY',
			isFixed: true,
			description: computed(() => this.Resources._COMPANY02087),
		}).cloneFrom(values?.ValCodempre))
		watch(() => this.ValCodempre.value, (newValue, oldValue) => this.onUpdate('equip.codempre', this.ValCodempre, newValue, oldValue))

		this.ValCodwareh = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodwareh',
			originId: 'ValCodwareh',
			area: 'EQUIP',
			field: 'CODWAREH',
			relatedArea: 'WAREH',
			isFixed: true,
			description: '',
		}).cloneFrom(values?.ValCodwareh))
		watch(() => this.ValCodwareh.value, (newValue, oldValue) => this.onUpdate('equip.codwareh', this.ValCodwareh, newValue, oldValue))

		this.ValCoditem = reactive(new modelFieldType.ForeignKey({
			id: 'ValCoditem',
			originId: 'ValCoditem',
			area: 'EQUIP',
			field: 'CODITEM',
			relatedArea: 'ITEM',
			isFixed: true,
			description: '',
		}).cloneFrom(values?.ValCoditem))
		watch(() => this.ValCoditem.value, (newValue, oldValue) => this.onUpdate('equip.coditem', this.ValCoditem, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodpess1 = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpess1',
			originId: 'ValCodpess1',
			area: 'EQUIP',
			field: 'CODPESS1',
			relatedArea: 'PESS1',
			description: computed(() => this.Resources._COMOMODOR01469),
		}).cloneFrom(values?.ValCodpess1))
		watch(() => this.ValCodpess1.value, (newValue, oldValue) => this.onUpdate('equip.codpess1', this.ValCodpess1, newValue, oldValue))

		this.ValCodtpequ = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodtpequ',
			originId: 'ValCodtpequ',
			area: 'EQUIP',
			field: 'CODTPEQU',
			relatedArea: 'TPEQU',
			description: computed(() => this.Resources._TYPE_OF_EQUIPMENT35057),
		}).cloneFrom(values?.ValCodtpequ))
		watch(() => this.ValCodtpequ.value, (newValue, oldValue) => this.onUpdate('equip.codtpequ', this.ValCodtpequ, newValue, oldValue))

		/** The remaining form fields. */
		this.Pess1ValPhotogra = reactive(new modelFieldType.Image({
			id: 'Pess1ValPhotogra',
			originId: 'ValPhotogra',
			area: 'PESS1',
			field: 'PHOTOGRA',
			isFixed: true,
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.Pess1ValPhotogra))
		watch(() => this.Pess1ValPhotogra.value, (newValue, oldValue) => this.onUpdate('pess1.photogra', this.Pess1ValPhotogra, newValue, oldValue))

		this.TablePess1Name = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePess1Name',
			originId: 'ValName',
			area: 'PESS1',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TablePess1Name))
		watch(() => this.TablePess1Name.value, (newValue, oldValue) => this.onUpdate('pess1.name', this.TablePess1Name, newValue, oldValue))

		this.Pess1ValGender = reactive(new modelFieldType.String({
			id: 'Pess1ValGender',
			originId: 'ValGender',
			area: 'PESS1',
			field: 'GENDER',
			maxLength: 1,
			isFixed: true,
			arrayOptions: computed(() => qProjArrays.QArrayGenero.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.GENRE63303),
		}).cloneFrom(values?.Pess1ValGender))
		watch(() => this.Pess1ValGender.value, (newValue, oldValue) => this.onUpdate('pess1.gender', this.Pess1ValGender, newValue, oldValue))

		this.Pess1ValDtnascim = reactive(new modelFieldType.Date({
			id: 'Pess1ValDtnascim',
			originId: 'ValDtnascim',
			area: 'PESS1',
			field: 'DTNASCIM',
			isFixed: true,
			description: computed(() => this.Resources.BIRTH21799),
		}).cloneFrom(values?.Pess1ValDtnascim))
		watch(() => this.Pess1ValDtnascim.value, (newValue, oldValue) => this.onUpdate('pess1.dtnascim', this.Pess1ValDtnascim, newValue, oldValue))

		this.Pess1ValIdade = reactive(new modelFieldType.Number({
			id: 'Pess1ValIdade',
			originId: 'ValIdade',
			area: 'PESS1',
			field: 'IDADE',
			maxDigits: 5,
			decimalDigits: 0,
			isFixed: true,
			description: computed(() => this.Resources.AGE28663),
		}).cloneFrom(values?.Pess1ValIdade))
		watch(() => this.Pess1ValIdade.value, (newValue, oldValue) => this.onUpdate('pess1.idade', this.Pess1ValIdade, newValue, oldValue))

		this.Pess1ValIdfuncio = reactive(new modelFieldType.Number({
			id: 'Pess1ValIdfuncio',
			originId: 'ValIdfuncio',
			area: 'PESS1',
			field: 'IDFUNCIO',
			maxDigits: 6,
			decimalDigits: 0,
			isFixed: true,
			description: computed(() => this.Resources.OFFICIAL_NO_34819),
		}).cloneFrom(values?.Pess1ValIdfuncio))
		watch(() => this.Pess1ValIdfuncio.value, (newValue, oldValue) => this.onUpdate('pess1.idfuncio', this.Pess1ValIdfuncio, newValue, oldValue))

		this.Pess1ValTelephon = reactive(new modelFieldType.String({
			id: 'Pess1ValTelephon',
			originId: 'ValTelephon',
			area: 'PESS1',
			field: 'TELEPHON',
			maxLength: 20,
			isFixed: true,
			description: computed(() => this.Resources.PHONE56703),
		}).cloneFrom(values?.Pess1ValTelephon))
		watch(() => this.Pess1ValTelephon.value, (newValue, oldValue) => this.onUpdate('pess1.telephon', this.Pess1ValTelephon, newValue, oldValue))

		this.Pess1ValEmail = reactive(new modelFieldType.String({
			id: 'Pess1ValEmail',
			originId: 'ValEmail',
			area: 'PESS1',
			field: 'EMAIL',
			maxLength: 254,
			isFixed: true,
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.Pess1ValEmail))
		watch(() => this.Pess1ValEmail.value, (newValue, oldValue) => this.onUpdate('pess1.email', this.Pess1ValEmail, newValue, oldValue))

		this.Pess1ValEmail2 = reactive(new modelFieldType.String({
			id: 'Pess1ValEmail2',
			originId: 'ValEmail2',
			area: 'PESS1',
			field: 'EMAIL2',
			maxLength: 254,
			isFixed: true,
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.Pess1ValEmail2))
		watch(() => this.Pess1ValEmail2.value, (newValue, oldValue) => this.onUpdate('pess1.email2', this.Pess1ValEmail2, newValue, oldValue))

		this.CmpnyValLogo = reactive(new modelFieldType.Image({
			id: 'CmpnyValLogo',
			originId: 'ValLogo',
			area: 'CMPNY',
			field: 'LOGO',
			isFixed: true,
			description: computed(() => this.Resources.LOGO62483),
		}).cloneFrom(values?.CmpnyValLogo))
		watch(() => this.CmpnyValLogo.value, (newValue, oldValue) => this.onUpdate('cmpny.logo', this.CmpnyValLogo, newValue, oldValue))

		this.CmpnyValDesignat = reactive(new modelFieldType.String({
			id: 'CmpnyValDesignat',
			originId: 'ValDesignat',
			area: 'CMPNY',
			field: 'DESIGNAT',
			maxLength: 85,
			isFixed: true,
			description: computed(() => this.Resources.DESIGNATION35876),
		}).cloneFrom(values?.CmpnyValDesignat))
		watch(() => this.CmpnyValDesignat.value, (newValue, oldValue) => this.onUpdate('cmpny.designat', this.CmpnyValDesignat, newValue, oldValue))

		this.CmpnyValAcronym = reactive(new modelFieldType.String({
			id: 'CmpnyValAcronym',
			originId: 'ValAcronym',
			area: 'CMPNY',
			field: 'ACRONYM',
			maxLength: 15,
			isFixed: true,
			description: computed(() => this.Resources.ACRONYM00872),
		}).cloneFrom(values?.CmpnyValAcronym))
		watch(() => this.CmpnyValAcronym.value, (newValue, oldValue) => this.onUpdate('cmpny.acronym', this.CmpnyValAcronym, newValue, oldValue))

		this.CmpnyValNif = reactive(new modelFieldType.String({
			id: 'CmpnyValNif',
			originId: 'ValNif',
			area: 'CMPNY',
			field: 'NIF',
			maxLength: 15,
			isFixed: true,
			description: computed(() => this.Resources.TAX_IDENTIFICATION51190),
		}).cloneFrom(values?.CmpnyValNif))
		watch(() => this.CmpnyValNif.value, (newValue, oldValue) => this.onUpdate('cmpny.nif', this.CmpnyValNif, newValue, oldValue))

		this.CmpnyValTelephon = reactive(new modelFieldType.String({
			id: 'CmpnyValTelephon',
			originId: 'ValTelephon',
			area: 'CMPNY',
			field: 'TELEPHON',
			maxLength: 20,
			isFixed: true,
			description: computed(() => this.Resources.PHONE56703),
		}).cloneFrom(values?.CmpnyValTelephon))
		watch(() => this.CmpnyValTelephon.value, (newValue, oldValue) => this.onUpdate('cmpny.telephon', this.CmpnyValTelephon, newValue, oldValue))

		this.CmpnyValEmail = reactive(new modelFieldType.String({
			id: 'CmpnyValEmail',
			originId: 'ValEmail',
			area: 'CMPNY',
			field: 'EMAIL',
			maxLength: 254,
			isFixed: true,
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.CmpnyValEmail))
		watch(() => this.CmpnyValEmail.value, (newValue, oldValue) => this.onUpdate('cmpny.email', this.CmpnyValEmail, newValue, oldValue))

		this.ValQtdmovim = reactive(new modelFieldType.Number({
			id: 'ValQtdmovim',
			originId: 'ValQtdmovim',
			area: 'EQUIP',
			field: 'QTDMOVIM',
			maxDigits: 10,
			decimalDigits: 0,
			isFixed: true,
			description: computed(() => this.Resources.QTD__MOVIMENTACOES28400),
		}).cloneFrom(values?.ValQtdmovim))
		watch(() => this.ValQtdmovim.value, (newValue, oldValue) => this.onUpdate('equip.qtdmovim', this.ValQtdmovim, newValue, oldValue))

		this.ValDtaquisi = reactive(new modelFieldType.Date({
			id: 'ValDtaquisi',
			originId: 'ValDtaquisi',
			area: 'EQUIP',
			field: 'DTAQUISI',
			description: computed(() => this.Resources.ACQUISITION44180),
		}).cloneFrom(values?.ValDtaquisi))
		watch(() => this.ValDtaquisi.value, (newValue, oldValue) => this.onUpdate('equip.dtaquisi', this.ValDtaquisi, newValue, oldValue))

		this.TableTpequTipoequi = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableTpequTipoequi',
			originId: 'ValTipoequi',
			area: 'TPEQU',
			field: 'TIPOEQUI',
			maxLength: 50,
			description: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
		}).cloneFrom(values?.TableTpequTipoequi))
		watch(() => this.TableTpequTipoequi.value, (newValue, oldValue) => this.onUpdate('tpequ.tipoequi', this.TableTpequTipoequi, newValue, oldValue))

		this.TpequValTpequcod = reactive(new modelFieldType.String({
			id: 'TpequValTpequcod',
			originId: 'ValTpequcod',
			area: 'TPEQU',
			field: 'TPEQUCOD',
			maxLength: 20,
			isFixed: true,
			description: computed(() => this.Resources.CODE49225),
		}).cloneFrom(values?.TpequValTpequcod))
		watch(() => this.TpequValTpequcod.value, (newValue, oldValue) => this.onUpdate('tpequ.tpequcod', this.TpequValTpequcod, newValue, oldValue))

		this.TpequValPrecomax = reactive(new modelFieldType.Number({
			id: 'TpequValPrecomax',
			originId: 'ValPrecomax',
			area: 'TPEQU',
			field: 'PRECOMAX',
			maxDigits: 9,
			decimalDigits: 2,
			isFixed: true,
			description: computed(() => this.Resources.MAXIMUM_PRICE55489),
		}).cloneFrom(values?.TpequValPrecomax))
		watch(() => this.TpequValPrecomax.value, (newValue, oldValue) => this.onUpdate('tpequ.precomax', this.TpequValPrecomax, newValue, oldValue))

		this.TpequValTpequpai = reactive(new modelFieldType.String({
			id: 'TpequValTpequpai',
			originId: 'ValTpequpai',
			area: 'TPEQU',
			field: 'TPEQUPAI',
			maxLength: 20,
			isFixed: true,
			description: computed(() => this.Resources.DEPENDENT_ON28321),
		}).cloneFrom(values?.TpequValTpequpai))
		watch(() => this.TpequValTpequpai.value, (newValue, oldValue) => this.onUpdate('tpequ.tpequpai', this.TpequValTpequpai, newValue, oldValue))

		this.TpequValNivel = reactive(new modelFieldType.Number({
			id: 'TpequValNivel',
			originId: 'ValNivel',
			area: 'TPEQU',
			field: 'NIVEL',
			maxDigits: 3,
			decimalDigits: 0,
			isFixed: true,
			description: computed(() => this.Resources.LEVEL06184),
		}).cloneFrom(values?.TpequValNivel))
		watch(() => this.TpequValNivel.value, (newValue, oldValue) => this.onUpdate('tpequ.nivel', this.TpequValNivel, newValue, oldValue))

		this.TpequValBackcolo = reactive(new modelFieldType.String({
			id: 'TpequValBackcolo',
			originId: 'ValBackcolo',
			area: 'TPEQU',
			field: 'BACKCOLO',
			maxLength: 50,
			isFixed: true,
			description: computed(() => this.Resources.BACKGROUND_COLOR47883),
		}).cloneFrom(values?.TpequValBackcolo))
		watch(() => this.TpequValBackcolo.value, (newValue, oldValue) => this.onUpdate('tpequ.backcolo', this.TpequValBackcolo, newValue, oldValue))

		this.TpequValCorletra = reactive(new modelFieldType.String({
			id: 'TpequValCorletra',
			originId: 'ValCorletra',
			area: 'TPEQU',
			field: 'CORLETRA',
			maxLength: 50,
			isFixed: true,
			description: computed(() => this.Resources.LETTER_COLOR15736),
		}).cloneFrom(values?.TpequValCorletra))
		watch(() => this.TpequValCorletra.value, (newValue, oldValue) => this.onUpdate('tpequ.corletra', this.TpequValCorletra, newValue, oldValue))

		this.ValSequennr = reactive(new modelFieldType.Number({
			id: 'ValSequennr',
			originId: 'ValSequennr',
			area: 'EQUIP',
			field: 'SEQUENNR',
			maxDigits: 6,
			decimalDigits: 0,
			description: computed(() => this.Resources.SEQUENTIAL_NO_38590),
		}).cloneFrom(values?.ValSequennr))
		watch(() => this.ValSequennr.value, (newValue, oldValue) => this.onUpdate('equip.sequennr', this.ValSequennr, newValue, oldValue))

		this.ValRegistnr = reactive(new modelFieldType.String({
			id: 'ValRegistnr',
			originId: 'ValRegistnr',
			area: 'EQUIP',
			field: 'REGISTNR',
			maxLength: 6,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: RIGHT("000000"+NumericToString([EQUIP->SEQUENNR],0),6)
					return qApi.RIGHT("000000"+qApi.NumericToString(this.ValSequennr.value,0),6)
				},
				dependencyEvents: ['fieldChange:equip.sequennr'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			description: computed(() => this.Resources.NO__REGISTER04207),
		}).cloneFrom(values?.ValRegistnr))
		watch(() => this.ValRegistnr.value, (newValue, oldValue) => this.onUpdate('equip.registnr', this.ValRegistnr, newValue, oldValue))

		this.ValValortot = reactive(new modelFieldType.Number({
			id: 'ValValortot',
			originId: 'ValValortot',
			area: 'EQUIP',
			field: 'VALORTOT',
			maxDigits: 9,
			decimalDigits: 2,
			isFixed: true,
			description: computed(() => this.Resources.TOTAL_VALUE30570),
		}).cloneFrom(values?.ValValortot))
		watch(() => this.ValValortot.value, (newValue, oldValue) => this.onUpdate('equip.valortot', this.ValValortot, newValue, oldValue))

		this.ValFrequenc = reactive(new modelFieldType.Number({
			id: 'ValFrequenc',
			originId: 'ValFrequenc',
			area: 'EQUIP',
			field: 'FREQUENC',
			maxDigits: 2,
			decimalDigits: 0,
			arrayOptions: computed(() => qProjArrays.QArrayFreqempr.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.LOAN_FREQUENCY00701),
		}).cloneFrom(values?.ValFrequenc))
		watch(() => this.ValFrequenc.value, (newValue, oldValue) => this.onUpdate('equip.frequenc', this.ValFrequenc, newValue, oldValue))

		this.ValBought = reactive(new modelFieldType.Boolean({
			id: 'ValBought',
			originId: 'ValBought',
			area: 'EQUIP',
			field: 'BOUGHT',
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: iif(emptyD([EQUIP->DTAQUISI])==1,0,1)
					return qApi.iif(qApi.emptyD(this.ValDtaquisi.value)===1,0,1)
				},
				dependencyEvents: ['fieldChange:equip.dtaquisi'],
				isServerRecalc: false,
				isEmpty: qApi.emptyL,
			},
			description: computed(() => this.Resources.BOUGHT32044),
		}).cloneFrom(values?.ValBought))
		watch(() => this.ValBought.value, (newValue, oldValue) => this.onUpdate('equip.bought', this.ValBought, newValue, oldValue))

		this.ValDtrefere = reactive(new modelFieldType.DateTime({
			id: 'ValDtrefere',
			originId: 'ValDtrefere',
			area: 'EQUIP',
			field: 'DTREFERE',
			description: computed(() => this.Resources.REFERENCE28402),
		}).cloneFrom(values?.ValDtrefere))
		watch(() => this.ValDtrefere.value, (newValue, oldValue) => this.onUpdate('equip.dtrefere', this.ValDtrefere, newValue, oldValue))

		this.ValFirst = reactive(new modelFieldType.String({
			id: 'ValFirst',
			originId: 'ValFirst',
			area: 'EQUIP',
			field: 'FIRST',
			maxLength: 10,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					const fieldId = params?.originField?.id
					const data = typeof fieldId === 'string' ? { [fieldId]: params.originField.value } : {}
					return this.recalculateFormulas(data)
				},
				dependencyEvents: ['fieldChange:equip.dtrefere', 'fieldChange:equip.codequip'],
				isServerRecalc: true,
				isEmpty: qApi.emptyC,
			},
			description: computed(() => this.Resources.FIRST42972),
		}).cloneFrom(values?.ValFirst))
		watch(() => this.ValFirst.value, (newValue, oldValue) => this.onUpdate('equip.first', this.ValFirst, newValue, oldValue))

		this.ValPhotogra = reactive(new modelFieldType.Image({
			id: 'ValPhotogra',
			originId: 'ValPhotogra',
			area: 'EQUIP',
			field: 'PHOTOGRA',
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.ValPhotogra))
		watch(() => this.ValPhotogra.value, (newValue, oldValue) => this.onUpdate('equip.photogra', this.ValPhotogra, newValue, oldValue))

		this.ValDesignat = reactive(new modelFieldType.String({
			id: 'ValDesignat',
			originId: 'ValDesignat',
			area: 'EQUIP',
			field: 'DESIGNAT',
			maxLength: 85,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: [ITEM->ITEMDES]
					return this.ItemValItemdes.value
				},
				dependencyEvents: ['fieldChange:item.itemdes', 'fieldChange:equip.coditem'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			description: computed(() => this.Resources.DESIGNATION35876),
		}).cloneFrom(values?.ValDesignat))
		watch(() => this.ValDesignat.value, (newValue, oldValue) => this.onUpdate('equip.designat', this.ValDesignat, newValue, oldValue))

		/** The form fields used only in formulas. */
		this.ItemValItemdes = reactive(new modelFieldType.String({
			id: 'ItemValItemdes',
			originId: 'ValItemdes',
			area: 'ITEM',
			field: 'ITEMDES',
			maxLength: 85,
			isFixed: true,
			description: computed(() => this.Resources.ARTICLE60065),
		}).cloneFrom(values?.ItemValItemdes))
		watch(() => this.ItemValItemdes.value, (newValue, oldValue) => this.onUpdate('item.itemdes', this.ItemValItemdes, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormEquigrouViewModel instance.
	 * @returns {QFormEquigrouViewModel} A new instance of QFormEquigrouViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodequip'

	get QPrimaryKey() { return this.ValCodequip.value }
	set QPrimaryKey(value) { this.ValCodequip.updateValue(value) }
}
