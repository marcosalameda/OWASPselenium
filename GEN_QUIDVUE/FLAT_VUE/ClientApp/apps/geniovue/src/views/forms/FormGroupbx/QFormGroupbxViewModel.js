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
			name: 'GROUPBX',
			area: 'EQUIP',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Groupbx',
				updateFilesTickets: 'UpdateFilesTicketsGroupbx',
				setFile: 'SetFileGroupbx'
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

		/** The hidden foreign keys. */
		this.ValCoddeco = reactive(new modelFieldType.ForeignKey({
			id: 'ValCoddeco',
			originId: 'ValCoddeco',
			area: 'EQUIP',
			field: 'CODDECO',
			relatedArea: 'DECOM',
			isFixed: true,
			description: '',
		}).cloneFrom(values?.ValCoddeco))
		this.stopWatchers.push(watch(() => this.ValCoddeco.value, (newValue, oldValue) => this.onUpdate('equip.coddeco', this.ValCoddeco, newValue, oldValue)))

		this.ValCodpess1 = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpess1',
			originId: 'ValCodpess1',
			area: 'EQUIP',
			field: 'CODPESS1',
			relatedArea: 'PESS1',
			isFixed: true,
			description: computed(() => this.Resources._COMOMODOR01469),
		}).cloneFrom(values?.ValCodpess1))
		this.stopWatchers.push(watch(() => this.ValCodpess1.value, (newValue, oldValue) => this.onUpdate('equip.codpess1', this.ValCodpess1, newValue, oldValue)))

		this.ValCodempre = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodempre',
			originId: 'ValCodempre',
			area: 'EQUIP',
			field: 'CODEMPRE',
			relatedArea: 'CMPNY',
			isFixed: true,
			description: computed(() => this.Resources._COMPANY02087),
		}).cloneFrom(values?.ValCodempre))
		this.stopWatchers.push(watch(() => this.ValCodempre.value, (newValue, oldValue) => this.onUpdate('equip.codempre', this.ValCodempre, newValue, oldValue)))

		/** The used foreign keys. */
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

		/** The remaining form fields. */
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
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
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
			ignoreFldSubmit: true,
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
			ignoreFldSubmit: true,
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
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableItemItemdes))
		this.stopWatchers.push(watch(() => this.TableItemItemdes.value, (newValue, oldValue) => this.onUpdate('item.itemdes', this.TableItemItemdes, newValue, oldValue)))

		this.ValDtdeco = reactive(new modelFieldType.Date({
			id: 'ValDtdeco',
			originId: 'ValDtdeco',
			area: 'EQUIP',
			field: 'DTDECO',
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
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

		this.TableRoom1Roomnr = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableRoom1Roomnr',
			originId: 'ValRoomnr',
			area: 'ROOM1',
			field: 'ROOMNR',
			maxLength: 10,
			isFixed: true,
			description: computed(() => this.Resources.N_R__ROOM43805),
			ignoreFldSubmit: true,
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

		this.ValDesignat = reactive(new modelFieldType.String({
			id: 'ValDesignat',
			originId: 'ValDesignat',
			area: 'EQUIP',
			field: 'DESIGNAT',
			maxLength: 85,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
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

		this.ValDtaquisi = reactive(new modelFieldType.Date({
			id: 'ValDtaquisi',
			originId: 'ValDtaquisi',
			area: 'EQUIP',
			field: 'DTAQUISI',
			description: computed(() => this.Resources.ACQUISITION44180),
		}).cloneFrom(values?.ValDtaquisi))
		this.stopWatchers.push(watch(() => this.ValDtaquisi.value, (newValue, oldValue) => this.onUpdate('equip.dtaquisi', this.ValDtaquisi, newValue, oldValue)))

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

		this.ValFrequenc = reactive(new modelFieldType.Number({
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
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
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
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
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

		this.ValBought = reactive(new modelFieldType.Boolean({
			id: 'ValBought',
			originId: 'ValBought',
			area: 'EQUIP',
			field: 'BOUGHT',
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
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
		this.stopWatchers.push(watch(() => this.ItemValItemdes.value, (newValue, oldValue) => this.onUpdate('item.itemdes', this.ItemValItemdes, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormGroupbxViewModel instance.
	 * @returns {QFormGroupbxViewModel} A new instance of QFormGroupbxViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodequip'

	get QPrimaryKey() { return this.ValCodequip.value }
	set QPrimaryKey(value) { this.ValCodequip.updateValue(value) }
}
