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
import DNFormViewModelFldscondpseudgridtbl from '@/views/forms/FormFldscond/QGridFormFldscondpseudgridtblViewModel.js'
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
			name: 'FLDSCOND',
			area: 'FLDS',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Fldscond',
				updateFilesTickets: 'UpdateFilesTicketsFldscond',
				setFile: 'SetFileFldscond'
			}
		})

		/** The primary key. */
		this.ValCodflds = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodflds',
			originId: 'ValCodflds',
			area: 'FLDS',
			field: 'CODFLDS',
			description: '',
		}).cloneFrom(values?.ValCodflds))
		this.stopWatchers.push(watch(() => this.ValCodflds.value, (newValue, oldValue) => this.onUpdate('flds.codflds', this.ValCodflds, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValCodequip = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodequip',
			originId: 'ValCodequip',
			area: 'FLDS',
			field: 'CODEQUIP',
			relatedArea: 'EQUIP',
			isFixed: true,
			description: '',
		}).cloneFrom(values?.ValCodequip))
		this.stopWatchers.push(watch(() => this.ValCodequip.value, (newValue, oldValue) => this.onUpdate('flds.codequip', this.ValCodequip, newValue, oldValue)))

		this.ValCodaero = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodaero',
			originId: 'ValCodaero',
			area: 'FLDS',
			field: 'CODAERO',
			relatedArea: 'AERO',
			isFixed: true,
			description: computed(() => this.Resources.COMPANY_NAME10342),
		}).cloneFrom(values?.ValCodaero))
		this.stopWatchers.push(watch(() => this.ValCodaero.value, (newValue, oldValue) => this.onUpdate('flds.codaero', this.ValCodaero, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValCond = reactive(new modelFieldType.String({
			id: 'ValCond',
			originId: 'ValCond',
			area: 'FLDS',
			field: 'COND',
			maxLength: 8,
			arrayOptions: computed(() => new qProjArrays.QArrayAcondtst(vm.$getResource).elements),
			description: computed(() => this.Resources.FIELD_STATE03599),
		}).cloneFrom(values?.ValCond))
		this.stopWatchers.push(watch(() => this.ValCond.value, (newValue, oldValue) => this.onUpdate('flds.cond', this.ValCond, newValue, oldValue)))

		this.ValTblcond = reactive(new modelFieldType.Boolean({
			id: 'ValTblcond',
			originId: 'ValTblcond',
			area: 'FLDS',
			field: 'TBLCOND',
			description: computed(() => this.Resources.ENFORCE_TABLE_CONDIT17491),
		}).cloneFrom(values?.ValTblcond))
		this.stopWatchers.push(watch(() => this.ValTblcond.value, (newValue, oldValue) => this.onUpdate('flds.tblcond', this.ValTblcond, newValue, oldValue)))

		this.ValFormcond = reactive(new modelFieldType.Boolean({
			id: 'ValFormcond',
			originId: 'ValFormcond',
			area: 'FLDS',
			field: 'FORMCOND',
			description: computed(() => this.Resources.ENFORCE_FORM_CONDITI41813),
		}).cloneFrom(values?.ValFormcond))
		this.stopWatchers.push(watch(() => this.ValFormcond.value, (newValue, oldValue) => this.onUpdate('flds.formcond', this.ValFormcond, newValue, oldValue)))

		this.ValFclient1 = reactive(new modelFieldType.String({
			id: 'ValFclient1',
			originId: 'ValFclient1',
			area: 'FLDS',
			field: 'FCLIENT1',
			maxLength: 50,
			blockWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: !isEmptyL([FLDS->TBLCOND]) && [FLDS->COND] == "BLOCK"
					return !((this.ValTblcond.value ? 1 : 0) === 0)&&this.ValCond.value==="BLOCK"
				},
				dependencyEvents: ['fieldChange:flds.tblcond', 'fieldChange:flds.cond'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			showWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: !(!isEmptyL([FLDS->TBLCOND]) && [FLDS->COND] == "HIDE")
					return !(!((this.ValTblcond.value ? 1 : 0) === 0)&&this.ValCond.value==="HIDE")
				},
				dependencyEvents: ['fieldChange:flds.tblcond', 'fieldChange:flds.cond'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			description: computed(() => this.Resources.FIELD_WITH_CLIENT_SI60452),
		}).cloneFrom(values?.ValFclient1))
		this.stopWatchers.push(watch(() => this.ValFclient1.value, (newValue, oldValue) => this.onUpdate('flds.fclient1', this.ValFclient1, newValue, oldValue)))

		this.ValFfillwhn = reactive(new modelFieldType.String({
			id: 'ValFfillwhn',
			originId: 'ValFfillwhn',
			area: 'FLDS',
			field: 'FFILLWHN',
			maxLength: 50,
			fillWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: !(!isEmptyL([FLDS->TBLCOND]) && [FLDS->COND] == "BLOCK")
					return !(!((this.ValTblcond.value ? 1 : 0) === 0)&&this.ValCond.value==="BLOCK")
				},
				dependencyEvents: ['fieldChange:flds.tblcond', 'fieldChange:flds.cond'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			description: computed(() => this.Resources.FIELD_WITH_FILL_WHEN40052),
		}).cloneFrom(values?.ValFfillwhn))
		this.stopWatchers.push(watch(() => this.ValFfillwhn.value, (newValue, oldValue) => this.onUpdate('flds.ffillwhn', this.ValFfillwhn, newValue, oldValue)))

		this.ValFserver1 = reactive(new modelFieldType.DateTime({
			id: 'ValFserver1',
			originId: 'ValFserver1',
			area: 'FLDS',
			field: 'FSERVER1',
			blockWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					return netAPI.postData(
						'Flds',
						'FLDSCOND_FLDS_FSERVER1_BlockWhen',
						this.serverObjModel,
						undefined,
						undefined,
						undefined,
						this.navigationId)
				},
				dependencyEvents: ['fieldChange:flds.tblcond', 'fieldChange:flds.cond'],
				isServerRecalc: false,
				isEmpty: qApi.emptyD,
			},
			showWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					return netAPI.postData(
						'Flds',
						'FLDSCOND_FLDS_FSERVER1_ShowWhen',
						this.serverObjModel,
						undefined,
						undefined,
						undefined,
						this.navigationId)
				},
				dependencyEvents: ['fieldChange:flds.tblcond', 'fieldChange:flds.cond'],
				isServerRecalc: false,
				isEmpty: qApi.emptyD,
			},
			description: computed(() => this.Resources.FIELD_WITH_SERVER_SI13554),
		}).cloneFrom(values?.ValFserver1))
		this.stopWatchers.push(watch(() => this.ValFserver1.value, (newValue, oldValue) => this.onUpdate('flds.fserver1', this.ValFserver1, newValue, oldValue)))

		this.ValFclient2 = reactive(new modelFieldType.Boolean({
			id: 'ValFclient2',
			originId: 'ValFclient2',
			area: 'FLDS',
			field: 'FCLIENT2',
			description: computed(() => this.Resources.FIELD_WITH_CLIENT_SI60452),
		}).cloneFrom(values?.ValFclient2))
		this.stopWatchers.push(watch(() => this.ValFclient2.value, (newValue, oldValue) => this.onUpdate('flds.fclient2', this.ValFclient2, newValue, oldValue)))

		this.ValFserver2 = reactive(new modelFieldType.Number({
			id: 'ValFserver2',
			originId: 'ValFserver2',
			area: 'FLDS',
			field: 'FSERVER2',
			maxDigits: 5,
			decimalDigits: 2,
			description: computed(() => this.Resources.FIELD_WITH_SERVER_SI13554),
		}).cloneFrom(values?.ValFserver2))
		this.stopWatchers.push(watch(() => this.ValFserver2.value, (newValue, oldValue) => this.onUpdate('flds.fserver2', this.ValFserver2, newValue, oldValue)))

		this.ValFclient3 = reactive(new modelFieldType.Document({
			id: 'ValFclient3',
			originId: 'ValFclient3',
			area: 'FLDS',
			field: 'FCLIENT3',
			properties: computed(() => this.ValFclient3PropertiesVM),
			documentFK: computed(() => this.ValFclient3fk),
			currentDocument: computed(() => this.ValFclient3Data),
			blockWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: !isEmptyL([FLDS->TBLCOND]) && [FLDS->COND] == "BLOCK"
					return !((this.ValTblcond.value ? 1 : 0) === 0)&&this.ValCond.value==="BLOCK"
				},
				dependencyEvents: ['fieldChange:flds.tblcond', 'fieldChange:flds.cond'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			showWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: !(!isEmptyL([FLDS->TBLCOND]) && [FLDS->COND] == "HIDE")
					return !(!((this.ValTblcond.value ? 1 : 0) === 0)&&this.ValCond.value==="HIDE")
				},
				dependencyEvents: ['fieldChange:flds.tblcond', 'fieldChange:flds.cond'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			description: computed(() => this.Resources.FIELD_WITH_CLIENT_SI60452),
		}).cloneFrom(values?.ValFclient3))
		this.stopWatchers.push(watch(() => this.ValFclient3.value, (newValue, oldValue) => this.onUpdate('flds.fclient3', this.ValFclient3, newValue, oldValue)))

		this.ValFclient3PropertiesVM = reactive(new modelFieldType.Base({
			id: 'ValFclient3PropertiesVM',
			area: 'FLDS',
			field: 'FCLIENT3DOCUM',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValFclient3PropertiesVM))
		this.ValFclient3fk = reactive(new modelFieldType.String({
			id: 'ValFclient3fk',
			area: 'FLDS',
			field: 'FCLIENT3FK'
		}).cloneFrom(values?.ValFclient3fk))
		this.stopWatchers.push(watch(() => this.ValFclient3fk.value, (newValue, oldValue) => this.onUpdate('flds.fclient3fk', this.ValFclient3fk, newValue, oldValue)))

		this.ValFclient3Data = reactive(new modelFieldType.DocumentData({
			id: 'ValFclient3Data',
			area: 'FLDS',
			field: 'FCLIENT3DATA',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValFclient3Data))
		this.stopWatchers.push(watch(() => this.ValFclient3Data.value, (newValue, oldValue) => this.onUpdate('flds.fclient3data', this.ValFclient3Data, newValue, oldValue), { deep: true }))

		this.ValFserver3 = reactive(new modelFieldType.Image({
			id: 'ValFserver3',
			originId: 'ValFserver3',
			area: 'FLDS',
			field: 'FSERVER3',
			blockWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					return netAPI.postData(
						'Flds',
						'FLDSCOND_FLDS_FSERVER3_BlockWhen',
						this.serverObjModel,
						undefined,
						undefined,
						undefined,
						this.navigationId)
				},
				dependencyEvents: ['fieldChange:flds.tblcond', 'fieldChange:flds.cond'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			showWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					return netAPI.postData(
						'Flds',
						'FLDSCOND_FLDS_FSERVER3_ShowWhen',
						this.serverObjModel,
						undefined,
						undefined,
						undefined,
						this.navigationId)
				},
				dependencyEvents: ['fieldChange:flds.tblcond', 'fieldChange:flds.cond'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			description: computed(() => this.Resources.FIELD_WITH_SERVER_SI13554),
		}).cloneFrom(values?.ValFserver3))
		this.stopWatchers.push(watch(() => this.ValFserver3.value, (newValue, oldValue) => this.onUpdate('flds.fserver3', this.ValFserver3, newValue, oldValue)))
		/** The Grid Table List value. */
		this.ValGridtbl = reactive(new modelFieldType.GridTableList({
			id: 'ValGridtbl',
			area: 'FEECA',
			field: 'GRIDTBL',
			viewModelClass: DNFormViewModelFldscondpseudgridtbl,
		}, this.vueContext).cloneFrom(values?.ValGridtbl))
		this.stopWatchers.push(watch(() => this.ValGridtbl.value?.newElements, () => this.onUpdate('pseud.gridtbl', this.ValGridtbl, this.ValGridtbl.value), { deep: true }))
		this.stopWatchers.push(watch(() => this.ValGridtbl.value?.editedElements, () => this.onUpdate('pseud.gridtbl', this.ValGridtbl, this.ValGridtbl.value), { deep: true }))
		this.stopWatchers.push(watch(() => this.ValGridtbl.value?.removedElements, () => this.onUpdate('pseud.gridtbl', this.ValGridtbl, this.ValGridtbl.value), { deep: true }))

		/** The form fields used only in formulas. */
		this.ValDescrip = reactive(new modelFieldType.MultiLineString({
			id: 'ValDescrip',
			originId: 'ValDescrip',
			area: 'FLDS',
			field: 'DESCRIP',
			isFixed: true,
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescrip))
		this.stopWatchers.push(watch(() => this.ValDescrip.value, (newValue, oldValue) => this.onUpdate('flds.descrip', this.ValDescrip, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFldscondViewModel instance.
	 * @returns {QFormFldscondViewModel} A new instance of QFormFldscondViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodflds'

	get QPrimaryKey() { return this.ValCodflds.value }
	set QPrimaryKey(value) { this.ValCodflds.updateValue(value) }
}
