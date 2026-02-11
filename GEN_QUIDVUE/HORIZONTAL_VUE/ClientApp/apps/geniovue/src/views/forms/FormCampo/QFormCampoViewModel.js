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
			name: 'CAMPO',
			area: 'FLDS',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Campo',
				updateFilesTickets: 'UpdateFilesTicketsCampo',
				setFile: 'SetFileCampo'
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

		/** The used foreign keys. */
		this.ValCodaero = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodaero',
			originId: 'ValCodaero',
			area: 'FLDS',
			field: 'CODAERO',
			relatedArea: 'AERO',
			description: computed(() => this.Resources.COMPANY_NAME10342),
		}).cloneFrom(values?.ValCodaero))
		this.stopWatchers.push(watch(() => this.ValCodaero.value, (newValue, oldValue) => this.onUpdate('flds.codaero', this.ValCodaero, newValue, oldValue)))

		/** The remaining form fields. */
		this.TableAeroName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableAeroName',
			originId: 'ValName',
			area: 'AERO',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.AIRLINE_NAME55130),
		}).cloneFrom(values?.TableAeroName))
		this.stopWatchers.push(watch(() => this.TableAeroName.value, (newValue, oldValue) => this.onUpdate('aero.name', this.TableAeroName, newValue, oldValue)))

		this.ValDescrip = reactive(new modelFieldType.MultiLineString({
			id: 'ValDescrip',
			originId: 'ValDescrip',
			area: 'FLDS',
			field: 'DESCRIP',
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescrip))
		this.stopWatchers.push(watch(() => this.ValDescrip.value, (newValue, oldValue) => this.onUpdate('flds.descrip', this.ValDescrip, newValue, oldValue)))

		this.ValNpassage = reactive(new modelFieldType.Number({
			id: 'ValNpassage',
			originId: 'ValNpassage',
			area: 'FLDS',
			field: 'NPASSAGE',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.NUMERIC19292),
		}).cloneFrom(values?.ValNpassage))
		this.stopWatchers.push(watch(() => this.ValNpassage.value, (newValue, oldValue) => this.onUpdate('flds.npassage', this.ValNpassage, newValue, oldValue)))

		this.ValDuration = reactive(new modelFieldType.Number({
			id: 'ValDuration',
			originId: 'ValDuration',
			area: 'FLDS',
			field: 'DURATION',
			maxDigits: 2,
			decimalDigits: 2,
			description: computed(() => this.Resources.NUMERIC_DECIMAL37352),
		}).cloneFrom(values?.ValDuration))
		this.stopWatchers.push(watch(() => this.ValDuration.value, (newValue, oldValue) => this.onUpdate('flds.duration', this.ValDuration, newValue, oldValue)))

		this.ValPrice = reactive(new modelFieldType.Number({
			id: 'ValPrice',
			originId: 'ValPrice',
			area: 'FLDS',
			field: 'PRICE',
			maxDigits: 3,
			decimalDigits: 2,
			description: computed(() => this.Resources.CURRENCY13881),
		}).cloneFrom(values?.ValPrice))
		this.stopWatchers.push(watch(() => this.ValPrice.value, (newValue, oldValue) => this.onUpdate('flds.price', this.ValPrice, newValue, oldValue)))

		this.ValPrecobil = reactive(new modelFieldType.Number({
			id: 'ValPrecobil',
			originId: 'ValPrecobil',
			area: 'FLDS',
			field: 'PRECOBIL',
			maxDigits: 3,
			decimalDigits: 2,
			description: computed(() => this.Resources.CURRENCY_DECIMAL48296),
		}).cloneFrom(values?.ValPrecobil))
		this.stopWatchers.push(watch(() => this.ValPrecobil.value, (newValue, oldValue) => this.onUpdate('flds.precobil', this.ValPrecobil, newValue, oldValue)))

		this.ValDate = reactive(new modelFieldType.Date({
			id: 'ValDate',
			originId: 'ValDate',
			area: 'FLDS',
			field: 'DATE',
			description: computed(() => this.Resources.DATE__DD_MM_YY_57869),
		}).cloneFrom(values?.ValDate))
		this.stopWatchers.push(watch(() => this.ValDate.value, (newValue, oldValue) => this.onUpdate('flds.date', this.ValDate, newValue, oldValue)))

		this.ValDatetime = reactive(new modelFieldType.DateTime({
			id: 'ValDatetime',
			originId: 'ValDatetime',
			area: 'FLDS',
			field: 'DATETIME',
			description: computed(() => this.Resources.DATETIME61308),
		}).cloneFrom(values?.ValDatetime))
		this.stopWatchers.push(watch(() => this.ValDatetime.value, (newValue, oldValue) => this.onUpdate('flds.datetime', this.ValDatetime, newValue, oldValue)))

		this.ValDateseco = reactive(new modelFieldType.DateTimeSeconds({
			id: 'ValDateseco',
			originId: 'ValDateseco',
			area: 'FLDS',
			field: 'DATESECO',
			description: computed(() => this.Resources.DATESECOND44557),
		}).cloneFrom(values?.ValDateseco))
		this.stopWatchers.push(watch(() => this.ValDateseco.value, (newValue, oldValue) => this.onUpdate('flds.dateseco', this.ValDateseco, newValue, oldValue)))

		this.ValTime = reactive(new modelFieldType.Time({
			id: 'ValTime',
			originId: 'ValTime',
			area: 'FLDS',
			field: 'TIME',
			description: computed(() => this.Resources.TIME15328),
		}).cloneFrom(values?.ValTime))
		this.stopWatchers.push(watch(() => this.ValTime.value, (newValue, oldValue) => this.onUpdate('flds.time', this.ValTime, newValue, oldValue)))

		this.ValYear = reactive(new modelFieldType.Number({
			id: 'ValYear',
			originId: 'ValYear',
			area: 'FLDS',
			field: 'YEAR',
			maxDigits: 4,
			decimalDigits: 0,
			description: computed(() => this.Resources.YEAR61794),
		}).cloneFrom(values?.ValYear))
		this.stopWatchers.push(watch(() => this.ValYear.value, (newValue, oldValue) => this.onUpdate('flds.year', this.ValYear, newValue, oldValue)))

		this.ValPrimviag = reactive(new modelFieldType.Boolean({
			id: 'ValPrimviag',
			originId: 'ValPrimviag',
			area: 'FLDS',
			field: 'PRIMVIAG',
			description: computed(() => this.Resources.LOGICAL47485),
		}).cloneFrom(values?.ValPrimviag))
		this.stopWatchers.push(watch(() => this.ValPrimviag.value, (newValue, oldValue) => this.onUpdate('flds.primviag', this.ValPrimviag, newValue, oldValue)))

		this.ValConditio = reactive(new modelFieldType.Number({
			id: 'ValConditio',
			originId: 'ValConditio',
			area: 'FLDS',
			field: 'CONDITIO',
			maxDigits: 1,
			decimalDigits: 0,
			description: computed(() => this.Resources.CONDITIONAL01431),
		}).cloneFrom(values?.ValConditio))
		this.stopWatchers.push(watch(() => this.ValConditio.value, (newValue, oldValue) => this.onUpdate('flds.conditio', this.ValConditio, newValue, oldValue)))

		this.ValClass = reactive(new modelFieldType.String({
			id: 'ValClass',
			originId: 'ValClass',
			area: 'FLDS',
			field: 'CLASS',
			maxLength: 2,
			arrayOptions: computed(() => new qProjArrays.QArrayClass(vm.$getResource).elements),
			description: computed(() => this.Resources.TEXT_ENUMERATION45668),
		}).cloneFrom(values?.ValClass))
		this.stopWatchers.push(watch(() => this.ValClass.value, (newValue, oldValue) => this.onUpdate('flds.class', this.ValClass, newValue, oldValue)))

		this.ValClassnum = reactive(new modelFieldType.Number({
			id: 'ValClassnum',
			originId: 'ValClassnum',
			area: 'FLDS',
			field: 'CLASSNUM',
			maxDigits: 1,
			decimalDigits: 0,
			arrayOptions: computed(() => new qProjArrays.QArrayClassnum(vm.$getResource).elements),
			description: computed(() => this.Resources.NUMERIC_ENUMERATION19068),
		}).cloneFrom(values?.ValClassnum))
		this.stopWatchers.push(watch(() => this.ValClassnum.value, (newValue, oldValue) => this.onUpdate('flds.classnum', this.ValClassnum, newValue, oldValue)))

		this.ValLogicenu = reactive(new modelFieldType.Number({
			id: 'ValLogicenu',
			originId: 'ValLogicenu',
			area: 'FLDS',
			field: 'LOGICENU',
			maxDigits: 1,
			decimalDigits: 0,
			description: computed(() => this.Resources.LOGICAL_ENUMERATION30276),
		}).cloneFrom(values?.ValLogicenu))
		this.stopWatchers.push(watch(() => this.ValLogicenu.value, (newValue, oldValue) => this.onUpdate('flds.logicenu', this.ValLogicenu, newValue, oldValue)))

		this.ValLogo = reactive(new modelFieldType.Image({
			id: 'ValLogo',
			originId: 'ValLogo',
			area: 'FLDS',
			field: 'LOGO',
			description: computed(() => this.Resources.LOGO62483),
		}).cloneFrom(values?.ValLogo))
		this.stopWatchers.push(watch(() => this.ValLogo.value, (newValue, oldValue) => this.onUpdate('flds.logo', this.ValLogo, newValue, oldValue)))

		this.ValAttach = reactive(new modelFieldType.Document({
			id: 'ValAttach',
			originId: 'ValAttach',
			area: 'FLDS',
			field: 'ATTACH',
			properties: computed(() => this.ValAttachPropertiesVM),
			documentFK: computed(() => this.ValAttachfk),
			currentDocument: computed(() => this.ValAttachData),
			description: computed(() => this.Resources.DOCUMENT00695),
		}).cloneFrom(values?.ValAttach))
		this.stopWatchers.push(watch(() => this.ValAttach.value, (newValue, oldValue) => this.onUpdate('flds.attach', this.ValAttach, newValue, oldValue)))

		this.ValAttachPropertiesVM = reactive(new modelFieldType.Base({
			id: 'ValAttachPropertiesVM',
			area: 'FLDS',
			field: 'ATTACHDOCUM',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValAttachPropertiesVM))
		this.ValAttachfk = reactive(new modelFieldType.String({
			id: 'ValAttachfk',
			area: 'FLDS',
			field: 'ATTACHFK'
		}).cloneFrom(values?.ValAttachfk))
		this.stopWatchers.push(watch(() => this.ValAttachfk.value, (newValue, oldValue) => this.onUpdate('flds.attachfk', this.ValAttachfk, newValue, oldValue)))

		this.ValAttachData = reactive(new modelFieldType.DocumentData({
			id: 'ValAttachData',
			area: 'FLDS',
			field: 'ATTACHDATA',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValAttachData))
		this.stopWatchers.push(watch(() => this.ValAttachData.value, (newValue, oldValue) => this.onUpdate('flds.attachdata', this.ValAttachData, newValue, oldValue), { deep: true }))

		this.ValCreatuse = reactive(new modelFieldType.String({
			id: 'ValCreatuse',
			originId: 'ValCreatuse',
			area: 'FLDS',
			field: 'CREATUSE',
			maxLength: 20,
			isFixed: true,
			description: computed(() => this.Resources.CREATED_BY12292),
		}).cloneFrom(values?.ValCreatuse))
		this.stopWatchers.push(watch(() => this.ValCreatuse.value, (newValue, oldValue) => this.onUpdate('flds.creatuse', this.ValCreatuse, newValue, oldValue)))

		this.ValCreatdat = reactive(new modelFieldType.Date({
			id: 'ValCreatdat',
			originId: 'ValCreatdat',
			area: 'FLDS',
			field: 'CREATDAT',
			isFixed: true,
			description: computed(() => this.Resources.DATE_OF_CREATION__DD02208),
		}).cloneFrom(values?.ValCreatdat))
		this.stopWatchers.push(watch(() => this.ValCreatdat.value, (newValue, oldValue) => this.onUpdate('flds.creatdat', this.ValCreatdat, newValue, oldValue)))

		this.ValCreathou = reactive(new modelFieldType.Time({
			id: 'ValCreathou',
			originId: 'ValCreathou',
			area: 'FLDS',
			field: 'CREATHOU',
			isFixed: true,
			description: computed(() => this.Resources.HOUR_OF_CREATION33629),
		}).cloneFrom(values?.ValCreathou))
		this.stopWatchers.push(watch(() => this.ValCreathou.value, (newValue, oldValue) => this.onUpdate('flds.creathou', this.ValCreathou, newValue, oldValue)))

		this.ValCreatins = reactive(new modelFieldType.DateTimeSeconds({
			id: 'ValCreatins',
			originId: 'ValCreatins',
			area: 'FLDS',
			field: 'CREATINS',
			isFixed: true,
			description: computed(() => this.Resources.COMPLETE_DATE_OF_CRE57046),
		}).cloneFrom(values?.ValCreatins))
		this.stopWatchers.push(watch(() => this.ValCreatins.value, (newValue, oldValue) => this.onUpdate('flds.creatins', this.ValCreatins, newValue, oldValue)))

		/** The form fields used only in formulas. */
		this.ValTblcond = reactive(new modelFieldType.Boolean({
			id: 'ValTblcond',
			originId: 'ValTblcond',
			area: 'FLDS',
			field: 'TBLCOND',
			isFixed: true,
			description: computed(() => this.Resources.ENFORCE_TABLE_CONDIT17491),
		}).cloneFrom(values?.ValTblcond))
		this.stopWatchers.push(watch(() => this.ValTblcond.value, (newValue, oldValue) => this.onUpdate('flds.tblcond', this.ValTblcond, newValue, oldValue)))

		this.ValCond = reactive(new modelFieldType.String({
			id: 'ValCond',
			originId: 'ValCond',
			area: 'FLDS',
			field: 'COND',
			maxLength: 8,
			isFixed: true,
			arrayOptions: computed(() => new qProjArrays.QArrayAcondtst(vm.$getResource).elements),
			description: computed(() => this.Resources.FIELD_STATE03599),
		}).cloneFrom(values?.ValCond))
		this.stopWatchers.push(watch(() => this.ValCond.value, (newValue, oldValue) => this.onUpdate('flds.cond', this.ValCond, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormCampoViewModel instance.
	 * @returns {QFormCampoViewModel} A new instance of QFormCampoViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodflds'

	get QPrimaryKey() { return this.ValCodflds.value }
	set QPrimaryKey(value) { this.ValCodflds.updateValue(value) }
}
