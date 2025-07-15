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
			name: 'EQUIP',
			area: 'EQUIP',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Equip',
				updateFilesTickets: 'UpdateFilesTicketsEquip',
				setFile: 'SetFileEquip'
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
		this.stopWatchers.push(watch(() => this.ValCodequip.value, (newValue, oldValue) => this.onUpdate('equip.codequip', this.ValCodequip, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodempre = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodempre',
			originId: 'ValCodempre',
			area: 'EQUIP',
			field: 'CODEMPRE',
			relatedArea: 'CMPNY',
			description: computed(() => this.Resources._COMPANY02087),
		}).cloneFrom(values?.ValCodempre))
		this.stopWatchers.push(watch(() => this.ValCodempre.value, (newValue, oldValue) => this.onUpdate('equip.codempre', this.ValCodempre, newValue, oldValue)))

		this.ValCodpess1 = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpess1',
			originId: 'ValCodpess1',
			area: 'EQUIP',
			field: 'CODPESS1',
			relatedArea: 'PESS1',
			description: computed(() => this.Resources._COMOMODOR01469),
		}).cloneFrom(values?.ValCodpess1))
		this.stopWatchers.push(watch(() => this.ValCodpess1.value, (newValue, oldValue) => this.onUpdate('equip.codpess1', this.ValCodpess1, newValue, oldValue)))

		this.ValCodtpequ = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodtpequ',
			originId: 'ValCodtpequ',
			area: 'EQUIP',
			field: 'CODTPEQU',
			relatedArea: 'TPEQU',
			description: computed(() => this.Resources._TYPE_OF_EQUIPMENT35057),
		}).cloneFrom(values?.ValCodtpequ))
		this.stopWatchers.push(watch(() => this.ValCodtpequ.value, (newValue, oldValue) => this.onUpdate('equip.codtpequ', this.ValCodtpequ, newValue, oldValue)))

		this.ValCodwareh = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodwareh',
			originId: 'ValCodwareh',
			area: 'EQUIP',
			field: 'CODWAREH',
			relatedArea: 'WAREH',
			description: '',
		}).cloneFrom(values?.ValCodwareh))
		this.stopWatchers.push(watch(() => this.ValCodwareh.value, (newValue, oldValue) => this.onUpdate('equip.codwareh', this.ValCodwareh, newValue, oldValue)))

		this.ValCoditem = reactive(new modelFieldType.ForeignKey({
			id: 'ValCoditem',
			originId: 'ValCoditem',
			area: 'EQUIP',
			field: 'CODITEM',
			relatedArea: 'ITEM',
			description: '',
		}).cloneFrom(values?.ValCoditem))
		this.stopWatchers.push(watch(() => this.ValCoditem.value, (newValue, oldValue) => this.onUpdate('equip.coditem', this.ValCoditem, newValue, oldValue)))

		this.ValCodrooms = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodrooms',
			originId: 'ValCodrooms',
			area: 'EQUIP',
			field: 'CODROOMS',
			relatedArea: 'ROOM1',
			description: '',
		}).cloneFrom(values?.ValCodrooms))
		this.stopWatchers.push(watch(() => this.ValCodrooms.value, (newValue, oldValue) => this.onUpdate('equip.codrooms', this.ValCodrooms, newValue, oldValue)))

		this.ValCoddeco = reactive(new modelFieldType.ForeignKey({
			id: 'ValCoddeco',
			originId: 'ValCoddeco',
			area: 'EQUIP',
			field: 'CODDECO',
			relatedArea: 'DECOM',
			description: '',
		}).cloneFrom(values?.ValCoddeco))
		this.stopWatchers.push(watch(() => this.ValCoddeco.value, (newValue, oldValue) => this.onUpdate('equip.coddeco', this.ValCoddeco, newValue, oldValue)))

		/** The remaining form fields. */
		this.TableCmpnyDesignat = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCmpnyDesignat',
			originId: 'ValDesignat',
			area: 'CMPNY',
			field: 'DESIGNAT',
			maxLength: 85,
			description: computed(() => this.Resources.DESIGNATION35876),
		}).cloneFrom(values?.TableCmpnyDesignat))
		this.stopWatchers.push(watch(() => this.TableCmpnyDesignat.value, (newValue, oldValue) => this.onUpdate('cmpny.designat', this.TableCmpnyDesignat, newValue, oldValue)))

		this.TablePess1Name = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePess1Name',
			originId: 'ValName',
			area: 'PESS1',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TablePess1Name))
		this.stopWatchers.push(watch(() => this.TablePess1Name.value, (newValue, oldValue) => this.onUpdate('pess1.name', this.TablePess1Name, newValue, oldValue)))

		this.ValSequennr = reactive(new modelFieldType.Number({
			id: 'ValSequennr',
			originId: 'ValSequennr',
			area: 'EQUIP',
			field: 'SEQUENNR',
			maxDigits: 6,
			decimalDigits: 0,
			description: computed(() => this.Resources.SEQUENTIAL_NO_38590),
		}).cloneFrom(values?.ValSequennr))
		this.stopWatchers.push(watch(() => this.ValSequennr.value, (newValue, oldValue) => this.onUpdate('equip.sequennr', this.ValSequennr, newValue, oldValue)))

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
		this.stopWatchers.push(watch(() => this.ValRegistnr.value, (newValue, oldValue) => this.onUpdate('equip.registnr', this.ValRegistnr, newValue, oldValue)))

		this.TableTpequTipoequi = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableTpequTipoequi',
			originId: 'ValTipoequi',
			area: 'TPEQU',
			field: 'TIPOEQUI',
			maxLength: 50,
			description: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
		}).cloneFrom(values?.TableTpequTipoequi))
		this.stopWatchers.push(watch(() => this.TableTpequTipoequi.value, (newValue, oldValue) => this.onUpdate('tpequ.tipoequi', this.TableTpequTipoequi, newValue, oldValue)))

		this.ValSitefabr = reactive(new modelFieldType.String({
			id: 'ValSitefabr',
			originId: 'ValSitefabr',
			area: 'EQUIP',
			field: 'SITEFABR',
			maxLength: 256,
			description: computed(() => this.Resources.MANUFACTURER_S_WEBSI11084),
		}).cloneFrom(values?.ValSitefabr))
		this.stopWatchers.push(watch(() => this.ValSitefabr.value, (newValue, oldValue) => this.onUpdate('equip.sitefabr', this.ValSitefabr, newValue, oldValue)))

		this.TableWarehWarehdes = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableWarehWarehdes',
			originId: 'ValWarehdes',
			area: 'WAREH',
			field: 'WAREHDES',
			maxLength: 85,
			description: computed(() => this.Resources.WAREHOUSE51864),
		}).cloneFrom(values?.TableWarehWarehdes))
		this.stopWatchers.push(watch(() => this.TableWarehWarehdes.value, (newValue, oldValue) => this.onUpdate('wareh.warehdes', this.TableWarehWarehdes, newValue, oldValue)))

		this.TableItemItemdes = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableItemItemdes',
			originId: 'ValItemdes',
			area: 'ITEM',
			field: 'ITEMDES',
			maxLength: 85,
			description: computed(() => this.Resources.ARTICLE60065),
		}).cloneFrom(values?.TableItemItemdes))
		this.stopWatchers.push(watch(() => this.TableItemItemdes.value, (newValue, oldValue) => this.onUpdate('item.itemdes', this.TableItemItemdes, newValue, oldValue)))

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
					return this.TableItemItemdes.value
				},
				dependencyEvents: ['fieldChange:item.itemdes', 'fieldChange:equip.coditem'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			description: computed(() => this.Resources.DESIGNATION35876),
		}).cloneFrom(values?.ValDesignat))
		this.stopWatchers.push(watch(() => this.ValDesignat.value, (newValue, oldValue) => this.onUpdate('equip.designat', this.ValDesignat, newValue, oldValue)))

		this.ValFrequenc = reactive(new modelFieldType.Number({
			type: 'Combobox',
			id: 'ValFrequenc',
			originId: 'ValFrequenc',
			area: 'EQUIP',
			field: 'FREQUENC',
			maxDigits: 2,
			decimalDigits: 0,
			arrayOptions: computed(() => new qProjArrays.QArrayFreqempr(vm.$getResource).elements),
			description: computed(() => this.Resources.LOAN_FREQUENCY00701),
		}).cloneFrom(values?.ValFrequenc))
		this.stopWatchers.push(watch(() => this.ValFrequenc.value, (newValue, oldValue) => this.onUpdate('equip.frequenc', this.ValFrequenc, newValue, oldValue)))

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
		this.stopWatchers.push(watch(() => this.ValValortot.value, (newValue, oldValue) => this.onUpdate('equip.valortot', this.ValValortot, newValue, oldValue)))

		this.ValDtaquisi = reactive(new modelFieldType.Date({
			id: 'ValDtaquisi',
			originId: 'ValDtaquisi',
			area: 'EQUIP',
			field: 'DTAQUISI',
			description: computed(() => this.Resources.ACQUISITION44180),
		}).cloneFrom(values?.ValDtaquisi))
		this.stopWatchers.push(watch(() => this.ValDtaquisi.value, (newValue, oldValue) => this.onUpdate('equip.dtaquisi', this.ValDtaquisi, newValue, oldValue)))

		this.ValDtdeco = reactive(new modelFieldType.DateTime({
			id: 'ValDtdeco',
			originId: 'ValDtdeco',
			area: 'EQUIP',
			field: 'DTDECO',
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
				dependencyEvents: ['fieldChange:equip.coddeco'],
				isServerRecalc: true,
				isEmpty: qApi.emptyD,
			},
			description: computed(() => this.Resources.DECOMISSION14486),
		}).cloneFrom(values?.ValDtdeco))
		this.stopWatchers.push(watch(() => this.ValDtdeco.value, (newValue, oldValue) => this.onUpdate('equip.dtdeco', this.ValDtdeco, newValue, oldValue)))

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
		this.stopWatchers.push(watch(() => this.ValBought.value, (newValue, oldValue) => this.onUpdate('equip.bought', this.ValBought, newValue, oldValue)))

		this.TableRoom1Roomnr = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableRoom1Roomnr',
			originId: 'ValRoomnr',
			area: 'ROOM1',
			field: 'ROOMNR',
			maxLength: 10,
			isFixed: true,
			description: computed(() => this.Resources.N_R__ROOM43805),
		}).cloneFrom(values?.TableRoom1Roomnr))
		this.stopWatchers.push(watch(() => this.TableRoom1Roomnr.value, (newValue, oldValue) => this.onUpdate('room1.roomnr', this.TableRoom1Roomnr, newValue, oldValue)))

		this.Room1ValDesignat = reactive(new modelFieldType.String({
			id: 'Room1ValDesignat',
			originId: 'ValDesignat',
			area: 'ROOM1',
			field: 'DESIGNAT',
			maxLength: 50,
			isFixed: true,
			description: computed(() => this.Resources.ROOM_DESIGNATION37895),
		}).cloneFrom(values?.Room1ValDesignat))
		this.stopWatchers.push(watch(() => this.Room1ValDesignat.value, (newValue, oldValue) => this.onUpdate('room1.designat', this.Room1ValDesignat, newValue, oldValue)))

		this.ValDtrefere = reactive(new modelFieldType.DateTime({
			id: 'ValDtrefere',
			originId: 'ValDtrefere',
			area: 'EQUIP',
			field: 'DTREFERE',
			description: computed(() => this.Resources.REFERENCE28402),
		}).cloneFrom(values?.ValDtrefere))
		this.stopWatchers.push(watch(() => this.ValDtrefere.value, (newValue, oldValue) => this.onUpdate('equip.dtrefere', this.ValDtrefere, newValue, oldValue)))

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
		this.stopWatchers.push(watch(() => this.ValFirst.value, (newValue, oldValue) => this.onUpdate('equip.first', this.ValFirst, newValue, oldValue)))

		this.ValBefore = reactive(new modelFieldType.String({
			id: 'ValBefore',
			originId: 'ValBefore',
			area: 'EQUIP',
			field: 'BEFORE',
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
				dependencyEvents: ['fieldChange:equip.dtrefere'],
				isServerRecalc: true,
				isEmpty: qApi.emptyC,
			},
			description: computed(() => this.Resources.BEFORE60156),
		}).cloneFrom(values?.ValBefore))
		this.stopWatchers.push(watch(() => this.ValBefore.value, (newValue, oldValue) => this.onUpdate('equip.before', this.ValBefore, newValue, oldValue)))

		this.ValFollowin = reactive(new modelFieldType.String({
			id: 'ValFollowin',
			originId: 'ValFollowin',
			area: 'EQUIP',
			field: 'FOLLOWIN',
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
			description: computed(() => this.Resources.FOLLOWING22170),
		}).cloneFrom(values?.ValFollowin))
		this.stopWatchers.push(watch(() => this.ValFollowin.value, (newValue, oldValue) => this.onUpdate('equip.followin', this.ValFollowin, newValue, oldValue)))

		this.ValLast = reactive(new modelFieldType.String({
			id: 'ValLast',
			originId: 'ValLast',
			area: 'EQUIP',
			field: 'LAST',
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
			description: computed(() => this.Resources.LAST49207),
		}).cloneFrom(values?.ValLast))
		this.stopWatchers.push(watch(() => this.ValLast.value, (newValue, oldValue) => this.onUpdate('equip.last', this.ValLast, newValue, oldValue)))

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
		this.stopWatchers.push(watch(() => this.ValQtdmovim.value, (newValue, oldValue) => this.onUpdate('equip.qtdmovim', this.ValQtdmovim, newValue, oldValue)))

		this.ValMoviment = reactive(new modelFieldType.MultiLineString({
			type: 'Text',
			id: 'ValMoviment',
			originId: 'ValMoviment',
			area: 'EQUIP',
			field: 'MOVIMENT',
			isFixed: true,
			description: computed(() => this.Resources.DRIVES34119),
		}).cloneFrom(values?.ValMoviment))
		this.stopWatchers.push(watch(() => this.ValMoviment.value, (newValue, oldValue) => this.onUpdate('equip.moviment', this.ValMoviment, newValue, oldValue)))

		this.ValPhotogra = reactive(new modelFieldType.Image({
			id: 'ValPhotogra',
			originId: 'ValPhotogra',
			area: 'EQUIP',
			field: 'PHOTOGRA',
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.ValPhotogra))
		this.stopWatchers.push(watch(() => this.ValPhotogra.value, (newValue, oldValue) => this.onUpdate('equip.photogra', this.ValPhotogra, newValue, oldValue)))

		this.ValLastpho = reactive(new modelFieldType.Image({
			id: 'ValLastpho',
			originId: 'ValLastpho',
			area: 'EQUIP',
			field: 'LASTPHO',
			isFixed: true,
			description: computed(() => this.Resources.LAST_PHOTO_ATTACHED43884),
		}).cloneFrom(values?.ValLastpho))
		this.stopWatchers.push(watch(() => this.ValLastpho.value, (newValue, oldValue) => this.onUpdate('equip.lastpho', this.ValLastpho, newValue, oldValue)))

		this.TableDecomDecomnr = reactive(new modelFieldType.Number({
			type: 'Lookup',
			id: 'TableDecomDecomnr',
			originId: 'ValDecomnr',
			area: 'DECOM',
			field: 'DECOMNR',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.NO_BATE21045),
		}).cloneFrom(values?.TableDecomDecomnr))
		this.stopWatchers.push(watch(() => this.TableDecomDecomnr.value, (newValue, oldValue) => this.onUpdate('decom.decomnr', this.TableDecomDecomnr, newValue, oldValue)))

		this.ValIfabatif = reactive(new modelFieldType.Boolean({
			id: 'ValIfabatif',
			originId: 'ValIfabatif',
			area: 'EQUIP',
			field: 'IFABATIF',
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: iif(emptyD([EQUIP->DTDECO])==1,0,1)
					return qApi.iif(qApi.emptyD(this.ValDtdeco.value)===1,0,1)
				},
				dependencyEvents: ['fieldChange:equip.dtdeco'],
				isServerRecalc: false,
				isEmpty: qApi.emptyL,
			},
			description: computed(() => this.Resources.DOWNED_EQUIPMENT43331),
		}).cloneFrom(values?.ValIfabatif))
		this.stopWatchers.push(watch(() => this.ValIfabatif.value, (newValue, oldValue) => this.onUpdate('equip.ifabatif', this.ValIfabatif, newValue, oldValue)))
		/** The Multiple Values value. */
		this.List_Movimevv_SelectedIds = reactive(new modelFieldType.MultipleValues({
			id: 'List_Movimevv_SelectedIds',
			originId: 'ValMovimevv',
			area: 'ROOMS',
			field: 'MOVIMEVV'
		}).cloneFrom(values?.List_Movimevv_SelectedIds))
		this.stopWatchers.push(watch(() => this.List_Movimevv_SelectedIds.value, (newValue, oldValue) => this.onUpdate('pseud.movimevv', this.List_Movimevv_SelectedIds, newValue, oldValue)))
		/** The Multiple Values options. */
		this.List_Movimevv = new modelFieldType.MultipleValues({
			id: 'List_Movimevv',
			ignoreFldSubmit: true
		}).cloneFrom(values?.List_Movimevv)
	}

	/**
	 * Creates a clone of the current QFormEquipViewModel instance.
	 * @returns {QFormEquipViewModel} A new instance of QFormEquipViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodequip'

	get QPrimaryKey() { return this.ValCodequip.value }
	set QPrimaryKey(value) { this.ValCodequip.updateValue(value) }
}
