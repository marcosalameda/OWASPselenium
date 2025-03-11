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
			name: 'WID_IEQU',
			area: 'EQUIP',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_WID_IEQU'
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
			description: '',
			isFixed: true,
		}).cloneFrom(values?.ValCodrooms))
		watch(() => this.ValCodrooms.value, (newValue, oldValue) => this.onUpdate('equip.codrooms', this.ValCodrooms, newValue, oldValue))

		this.ValCoddeco = reactive(new modelFieldType.ForeignKey({
			id: 'ValCoddeco',
			originId: 'ValCoddeco',
			area: 'EQUIP',
			field: 'CODDECO',
			relatedArea: 'DECOM',
			description: '',
			isFixed: true,
		}).cloneFrom(values?.ValCoddeco))
		watch(() => this.ValCoddeco.value, (newValue, oldValue) => this.onUpdate('equip.coddeco', this.ValCoddeco, newValue, oldValue))

		this.ValCodpess1 = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpess1',
			originId: 'ValCodpess1',
			area: 'EQUIP',
			field: 'CODPESS1',
			relatedArea: 'PESS1',
			description: computed(() => this.Resources._COMOMODOR01469),
			isFixed: true,
		}).cloneFrom(values?.ValCodpess1))
		watch(() => this.ValCodpess1.value, (newValue, oldValue) => this.onUpdate('equip.codpess1', this.ValCodpess1, newValue, oldValue))

		this.ValCoditem = reactive(new modelFieldType.ForeignKey({
			id: 'ValCoditem',
			originId: 'ValCoditem',
			area: 'EQUIP',
			field: 'CODITEM',
			relatedArea: 'ITEM',
			description: '',
			isFixed: true,
		}).cloneFrom(values?.ValCoditem))
		watch(() => this.ValCoditem.value, (newValue, oldValue) => this.onUpdate('equip.coditem', this.ValCoditem, newValue, oldValue))

		this.ValCodempre = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodempre',
			originId: 'ValCodempre',
			area: 'EQUIP',
			field: 'CODEMPRE',
			relatedArea: 'CMPNY',
			description: computed(() => this.Resources._COMPANY02087),
			isFixed: true,
		}).cloneFrom(values?.ValCodempre))
		watch(() => this.ValCodempre.value, (newValue, oldValue) => this.onUpdate('equip.codempre', this.ValCodempre, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodtpequ = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodtpequ',
			originId: 'ValCodtpequ',
			area: 'EQUIP',
			field: 'CODTPEQU',
			relatedArea: 'TPEQU',
			description: computed(() => this.Resources._TYPE_OF_EQUIPMENT35057),
		}).cloneFrom(values?.ValCodtpequ))
		watch(() => this.ValCodtpequ.value, (newValue, oldValue) => this.onUpdate('equip.codtpequ', this.ValCodtpequ, newValue, oldValue))

		this.ValCodwareh = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodwareh',
			originId: 'ValCodwareh',
			area: 'EQUIP',
			field: 'CODWAREH',
			relatedArea: 'WAREH',
			description: '',
		}).cloneFrom(values?.ValCodwareh))
		watch(() => this.ValCodwareh.value, (newValue, oldValue) => this.onUpdate('equip.codwareh', this.ValCodwareh, newValue, oldValue))

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
		watch(() => this.ValSequennr.value, (newValue, oldValue) => this.onUpdate('equip.sequennr', this.ValSequennr, newValue, oldValue))

		this.ValRegistnr = reactive(new modelFieldType.String({
			id: 'ValRegistnr',
			originId: 'ValRegistnr',
			area: 'EQUIP',
			field: 'REGISTNR',
			maxLength: 6,
			description: computed(() => this.Resources.NO__REGISTER04207),
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
		}).cloneFrom(values?.ValRegistnr))
		watch(() => this.ValRegistnr.value, (newValue, oldValue) => this.onUpdate('equip.registnr', this.ValRegistnr, newValue, oldValue))

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

		this.TableWarehWarehdes = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableWarehWarehdes',
			originId: 'ValWarehdes',
			area: 'WAREH',
			field: 'WAREHDES',
			maxLength: 85,
			description: computed(() => this.Resources.WAREHOUSE51864),
		}).cloneFrom(values?.TableWarehWarehdes))
		watch(() => this.TableWarehWarehdes.value, (newValue, oldValue) => this.onUpdate('wareh.warehdes', this.TableWarehWarehdes, newValue, oldValue))

		this.ValValortot = reactive(new modelFieldType.Number({
			id: 'ValValortot',
			originId: 'ValValortot',
			area: 'EQUIP',
			field: 'VALORTOT',
			maxDigits: 9,
			decimalDigits: 2,
			description: computed(() => this.Resources.TOTAL_VALUE30570),
			isFixed: true,
		}).cloneFrom(values?.ValValortot))
		watch(() => this.ValValortot.value, (newValue, oldValue) => this.onUpdate('equip.valortot', this.ValValortot, newValue, oldValue))

		this.ValDtaquisi = reactive(new modelFieldType.Date({
			id: 'ValDtaquisi',
			originId: 'ValDtaquisi',
			area: 'EQUIP',
			field: 'DTAQUISI',
			description: computed(() => this.Resources.ACQUISITION44180),
		}).cloneFrom(values?.ValDtaquisi))
		watch(() => this.ValDtaquisi.value, (newValue, oldValue) => this.onUpdate('equip.dtaquisi', this.ValDtaquisi, newValue, oldValue))

		this.ValDtdeco = reactive(new modelFieldType.DateTime({
			id: 'ValDtdeco',
			originId: 'ValDtdeco',
			area: 'EQUIP',
			field: 'DTDECO',
			description: computed(() => this.Resources.DECOMISSION14486),
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
		}).cloneFrom(values?.ValDtdeco))
		watch(() => this.ValDtdeco.value, (newValue, oldValue) => this.onUpdate('equip.dtdeco', this.ValDtdeco, newValue, oldValue))

		this.ValBought = reactive(new modelFieldType.Boolean({
			id: 'ValBought',
			originId: 'ValBought',
			area: 'EQUIP',
			field: 'BOUGHT',
			description: computed(() => this.Resources.BOUGHT32044),
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
		}).cloneFrom(values?.ValBought))
		watch(() => this.ValBought.value, (newValue, oldValue) => this.onUpdate('equip.bought', this.ValBought, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormWidIequViewModel instance.
	 * @returns {QFormWidIequViewModel} A new instance of QFormWidIequViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodequip'

	get QPrimaryKey() { return this.ValCodequip.value }
	set QPrimaryKey(value) { this.ValCodequip.updateValue(value) }
}
