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
			name: 'LEAFLETD',
			area: 'INSTA',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Leafletd',
				updateFilesTickets: 'UpdateFilesTicketsLeafletd',
				setFile: 'SetFileLeafletd'
			}
		})

		/** The primary key. */
		this.ValCodinsta = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodinsta',
			originId: 'ValCodinsta',
			area: 'INSTA',
			field: 'CODINSTA',
			description: '',
		}).cloneFrom(values?.ValCodinsta))
		this.stopWatchers.push(watch(() => this.ValCodinsta.value, (newValue, oldValue) => this.onUpdate('insta.codinsta', this.ValCodinsta, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValCodtpequ = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodtpequ',
			originId: 'ValCodtpequ',
			area: 'INSTA',
			field: 'CODTPEQU',
			relatedArea: 'TPEQU',
			isFixed: true,
			description: computed(() => this.Resources._TYPE_OF_EQUIPMENT35057),
		}).cloneFrom(values?.ValCodtpequ))
		this.stopWatchers.push(watch(() => this.ValCodtpequ.value, (newValue, oldValue) => this.onUpdate('insta.codtpequ', this.ValCodtpequ, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodequip = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodequip',
			originId: 'ValCodequip',
			area: 'INSTA',
			field: 'CODEQUIP',
			relatedArea: 'EQUIP',
			description: computed(() => this.Resources._EQUIPMENT12605),
		}).cloneFrom(values?.ValCodequip))
		this.stopWatchers.push(watch(() => this.ValCodequip.value, (newValue, oldValue) => this.onUpdate('insta.codequip', this.ValCodequip, newValue, oldValue)))

		/** The remaining form fields. */
		this.TableEquipRegistnr = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableEquipRegistnr',
			originId: 'ValRegistnr',
			area: 'EQUIP',
			field: 'REGISTNR',
			maxLength: 6,
			description: computed(() => this.Resources.NO__REGISTER04207),
		}).cloneFrom(values?.TableEquipRegistnr))
		this.stopWatchers.push(watch(() => this.TableEquipRegistnr.value, (newValue, oldValue) => this.onUpdate('equip.registnr', this.TableEquipRegistnr, newValue, oldValue)))

		this.TpequValTipoequi = reactive(new modelFieldType.String({
			id: 'TpequValTipoequi',
			originId: 'ValTipoequi',
			area: 'TPEQU',
			field: 'TIPOEQUI',
			maxLength: 50,
			isFixed: true,
			description: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
		}).cloneFrom(values?.TpequValTipoequi))
		this.stopWatchers.push(watch(() => this.TpequValTipoequi.value, (newValue, oldValue) => this.onUpdate('tpequ.tipoequi', this.TpequValTipoequi, newValue, oldValue)))

		this.ValDesignat = reactive(new modelFieldType.String({
			id: 'ValDesignat',
			originId: 'ValDesignat',
			area: 'INSTA',
			field: 'DESIGNAT',
			maxLength: 85,
			description: computed(() => this.Resources.SCHEDULING24801),
		}).cloneFrom(values?.ValDesignat))
		this.stopWatchers.push(watch(() => this.ValDesignat.value, (newValue, oldValue) => this.onUpdate('insta.designat', this.ValDesignat, newValue, oldValue)))

		this.ValDtiniage = reactive(new modelFieldType.DateTime({
			id: 'ValDtiniage',
			originId: 'ValDtiniage',
			area: 'INSTA',
			field: 'DTINIAGE',
			description: computed(() => this.Resources.BEGINNING18124),
		}).cloneFrom(values?.ValDtiniage))
		this.stopWatchers.push(watch(() => this.ValDtiniage.value, (newValue, oldValue) => this.onUpdate('insta.dtiniage', this.ValDtiniage, newValue, oldValue)))

		this.ValDtfimage = reactive(new modelFieldType.DateTime({
			id: 'ValDtfimage',
			originId: 'ValDtfimage',
			area: 'INSTA',
			field: 'DTFIMAGE',
			description: computed(() => this.Resources.END47577),
		}).cloneFrom(values?.ValDtfimage))
		this.stopWatchers.push(watch(() => this.ValDtfimage.value, (newValue, oldValue) => this.onUpdate('insta.dtfimage', this.ValDtfimage, newValue, oldValue)))

		this.ValDescript = reactive(new modelFieldType.MultiLineString({
			id: 'ValDescript',
			originId: 'ValDescript',
			area: 'INSTA',
			field: 'DESCRIPT',
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescript))
		this.stopWatchers.push(watch(() => this.ValDescript.value, (newValue, oldValue) => this.onUpdate('insta.descript', this.ValDescript, newValue, oldValue)))

		this.ValAllday = reactive(new modelFieldType.Boolean({
			id: 'ValAllday',
			originId: 'ValAllday',
			area: 'INSTA',
			field: 'ALLDAY',
			description: computed(() => this.Resources.ALL_DAY18496),
		}).cloneFrom(values?.ValAllday))
		this.stopWatchers.push(watch(() => this.ValAllday.value, (newValue, oldValue) => this.onUpdate('insta.allday', this.ValAllday, newValue, oldValue)))

		this.ValSince = reactive(new modelFieldType.DateTime({
			id: 'ValSince',
			originId: 'ValSince',
			area: 'INSTA',
			field: 'SINCE',
			description: computed(() => this.Resources.SINCE47259),
		}).cloneFrom(values?.ValSince))
		this.stopWatchers.push(watch(() => this.ValSince.value, (newValue, oldValue) => this.onUpdate('insta.since', this.ValSince, newValue, oldValue)))

		this.ValUntil = reactive(new modelFieldType.DateTime({
			id: 'ValUntil',
			originId: 'ValUntil',
			area: 'INSTA',
			field: 'UNTIL',
			description: computed(() => this.Resources.UNTIL39173),
		}).cloneFrom(values?.ValUntil))
		this.stopWatchers.push(watch(() => this.ValUntil.value, (newValue, oldValue) => this.onUpdate('insta.until', this.ValUntil, newValue, oldValue)))

		this.ValHours = reactive(new modelFieldType.Number({
			id: 'ValHours',
			originId: 'ValHours',
			area: 'INSTA',
			field: 'HOURS',
			maxDigits: 7,
			decimalDigits: 2,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: iif(emptyD([INSTA->SINCE])==1 || emptyD([INSTA->UNTIL])==1,0,Diferenca_entre_Datas([INSTA->SINCE],[INSTA->UNTIL],"H"))
					return qApi.iif(qApi.emptyD(this.ValSince.value)===1||qApi.emptyD(this.ValUntil.value)===1,0,qApi.Diferenca_entre_Datas(this.ValSince.value,this.ValUntil.value,"H"))
				},
				dependencyEvents: ['fieldChange:insta.since', 'fieldChange:insta.until'],
				isServerRecalc: false,
				isEmpty: qApi.emptyN,
			},
			description: computed(() => this.Resources.QTD_HOURS28684),
		}).cloneFrom(values?.ValHours))
		this.stopWatchers.push(watch(() => this.ValHours.value, (newValue, oldValue) => this.onUpdate('insta.hours', this.ValHours, newValue, oldValue)))

		this.ValPrecohor = reactive(new modelFieldType.Number({
			id: 'ValPrecohor',
			originId: 'ValPrecohor',
			area: 'INSTA',
			field: 'PRECOHOR',
			maxDigits: 9,
			decimalDigits: 2,
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
				dependencyEvents: ['fieldChange:insta.since', 'fieldChange:insta.codtpequ'],
				isServerRecalc: true,
				isEmpty: qApi.emptyN,
			},
			description: computed(() => this.Resources.HOURLY_PRICE48005),
		}).cloneFrom(values?.ValPrecohor))
		this.stopWatchers.push(watch(() => this.ValPrecohor.value, (newValue, oldValue) => this.onUpdate('insta.precohor', this.ValPrecohor, newValue, oldValue)))

		this.ValValue = reactive(new modelFieldType.Number({
			id: 'ValValue',
			originId: 'ValValue',
			area: 'INSTA',
			field: 'VALUE',
			maxDigits: 9,
			decimalDigits: 2,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: [INSTA->HOURS]*[INSTA->PRECOHOR]
					return this.ValHours.value*this.ValPrecohor.value
				},
				dependencyEvents: ['fieldChange:insta.hours', 'fieldChange:insta.precohor'],
				isServerRecalc: false,
				isEmpty: qApi.emptyN,
			},
			description: computed(() => this.Resources.VALUE10285),
		}).cloneFrom(values?.ValValue))
		this.stopWatchers.push(watch(() => this.ValValue.value, (newValue, oldValue) => this.onUpdate('insta.value', this.ValValue, newValue, oldValue)))

		this.ValCoordgeo = reactive(new modelFieldType.Coordinate({
			id: 'ValCoordgeo',
			originId: 'ValCoordgeo',
			area: 'INSTA',
			field: 'COORDGEO',
			description: computed(() => this.Resources.GEOGRAPHIC_COORDINAT21394),
		}).cloneFrom(values?.ValCoordgeo))
		this.stopWatchers.push(watch(() => this.ValCoordgeo.value, (newValue, oldValue) => this.onUpdate('insta.coordgeo', this.ValCoordgeo, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormLeafletdViewModel instance.
	 * @returns {QFormLeafletdViewModel} A new instance of QFormLeafletdViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodinsta'

	get QPrimaryKey() { return this.ValCodinsta.value }
	set QPrimaryKey(value) { this.ValCodinsta.updateValue(value) }
}
