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
			name: 'FIELDHLP',
			area: 'FLDS',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_FIELDHLP',
				updateFilesTickets: 'UpdateFilesTicketsFIELDHLP'
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
		watch(() => this.ValCodflds.value, (newValue, oldValue) => this.onUpdate('flds.codflds', this.ValCodflds, newValue, oldValue))

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
		watch(() => this.ValCodequip.value, (newValue, oldValue) => this.onUpdate('flds.codequip', this.ValCodequip, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodaero = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodaero',
			originId: 'ValCodaero',
			area: 'FLDS',
			field: 'CODAERO',
			relatedArea: 'AERO',
			description: computed(() => this.Resources.COMPANY_NAME10342),
		}).cloneFrom(values?.ValCodaero))
		watch(() => this.ValCodaero.value, (newValue, oldValue) => this.onUpdate('flds.codaero', this.ValCodaero, newValue, oldValue))

		/** The manually filled form fields. */
		this.PseudValField001 = reactive(new modelFieldType.String({
			id: 'PseudValField001',
			originId: 'PseudValField001',
			area: 'PSEUD',
			field: 'FIELD001'
		}).cloneFrom(values?.PseudValField001))
		watch(() => this.PseudValField001.value, (newValue, oldValue) => this.onUpdate('pseud.field001', this.PseudValField001, newValue, oldValue))

		/** The remaining form fields. */
		this.ValShwrc = reactive(new modelFieldType.Boolean({
			id: 'ValShwrc',
			originId: 'ValShwrc',
			area: 'FLDS',
			field: 'SHWRC',
			description: computed(() => this.Resources.SHOW_RECORD53851),
		}).cloneFrom(values?.ValShwrc))
		watch(() => this.ValShwrc.value, (newValue, oldValue) => this.onUpdate('flds.shwrc', this.ValShwrc, newValue, oldValue))

		this.ValTxtfield = reactive(new modelFieldType.String({
			id: 'ValTxtfield',
			originId: 'ValTxtfield',
			area: 'FLDS',
			field: 'TXTFIELD',
			maxLength: 50,
			description: computed(() => this.Resources.TEXT_FIELD41810),
		}).cloneFrom(values?.ValTxtfield))
		watch(() => this.ValTxtfield.value, (newValue, oldValue) => this.onUpdate('flds.txtfield', this.ValTxtfield, newValue, oldValue))

		this.ValDescrip = reactive(new modelFieldType.MultiLineString({
			id: 'ValDescrip',
			originId: 'ValDescrip',
			area: 'FLDS',
			field: 'DESCRIP',
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescrip))
		watch(() => this.ValDescrip.value, (newValue, oldValue) => this.onUpdate('flds.descrip', this.ValDescrip, newValue, oldValue))

		this.ValPrimviag = reactive(new modelFieldType.Boolean({
			id: 'ValPrimviag',
			originId: 'ValPrimviag',
			area: 'FLDS',
			field: 'PRIMVIAG',
			description: computed(() => this.Resources.LOGICAL47485),
		}).cloneFrom(values?.ValPrimviag))
		watch(() => this.ValPrimviag.value, (newValue, oldValue) => this.onUpdate('flds.primviag', this.ValPrimviag, newValue, oldValue))

		this.ValLogicenu = reactive(new modelFieldType.Number({
			id: 'ValLogicenu',
			originId: 'ValLogicenu',
			area: 'FLDS',
			field: 'LOGICENU',
			maxDigits: 1,
			decimalDigits: 0,
			description: computed(() => this.Resources.LOGICAL_ENUMERATION30276),
		}).cloneFrom(values?.ValLogicenu))
		watch(() => this.ValLogicenu.value, (newValue, oldValue) => this.onUpdate('flds.logicenu', this.ValLogicenu, newValue, oldValue))

		this.ValClassnum = reactive(new modelFieldType.Number({
			id: 'ValClassnum',
			originId: 'ValClassnum',
			area: 'FLDS',
			field: 'CLASSNUM',
			maxDigits: 1,
			decimalDigits: 0,
			arrayOptions: computed(() => qProjArrays.QArrayClassnum.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.NUMERIC_ENUMERATION19068),
		}).cloneFrom(values?.ValClassnum))
		watch(() => this.ValClassnum.value, (newValue, oldValue) => this.onUpdate('flds.classnum', this.ValClassnum, newValue, oldValue))

		this.ValRadiob = reactive(new modelFieldType.String({
			id: 'ValRadiob',
			originId: 'ValRadiob',
			area: 'FLDS',
			field: 'RADIOB',
			maxLength: 5,
			arrayOptions: computed(() => qProjArrays.QArrayRadiobtn.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.RADIO_BTN20980),
		}).cloneFrom(values?.ValRadiob))
		watch(() => this.ValRadiob.value, (newValue, oldValue) => this.onUpdate('flds.radiob', this.ValRadiob, newValue, oldValue))

		this.ValYear = reactive(new modelFieldType.Number({
			id: 'ValYear',
			originId: 'ValYear',
			area: 'FLDS',
			field: 'YEAR',
			maxDigits: 4,
			decimalDigits: 0,
			description: computed(() => this.Resources.YEAR61794),
		}).cloneFrom(values?.ValYear))
		watch(() => this.ValYear.value, (newValue, oldValue) => this.onUpdate('flds.year', this.ValYear, newValue, oldValue))

		this.ValTime = reactive(new modelFieldType.Time({
			id: 'ValTime',
			originId: 'ValTime',
			area: 'FLDS',
			field: 'TIME',
			description: computed(() => this.Resources.TIME15328),
		}).cloneFrom(values?.ValTime))
		watch(() => this.ValTime.value, (newValue, oldValue) => this.onUpdate('flds.time', this.ValTime, newValue, oldValue))

		this.ValDate = reactive(new modelFieldType.Date({
			id: 'ValDate',
			originId: 'ValDate',
			area: 'FLDS',
			field: 'DATE',
			description: computed(() => this.Resources.DATE__DD_MM_YY_57869),
		}).cloneFrom(values?.ValDate))
		watch(() => this.ValDate.value, (newValue, oldValue) => this.onUpdate('flds.date', this.ValDate, newValue, oldValue))

		this.ValDatetime = reactive(new modelFieldType.DateTime({
			id: 'ValDatetime',
			originId: 'ValDatetime',
			area: 'FLDS',
			field: 'DATETIME',
			description: computed(() => this.Resources.DATETIME61308),
		}).cloneFrom(values?.ValDatetime))
		watch(() => this.ValDatetime.value, (newValue, oldValue) => this.onUpdate('flds.datetime', this.ValDatetime, newValue, oldValue))

		this.ValDateseco = reactive(new modelFieldType.DateTimeSeconds({
			id: 'ValDateseco',
			originId: 'ValDateseco',
			area: 'FLDS',
			field: 'DATESECO',
			description: computed(() => this.Resources.DATESECOND44557),
		}).cloneFrom(values?.ValDateseco))
		watch(() => this.ValDateseco.value, (newValue, oldValue) => this.onUpdate('flds.dateseco', this.ValDateseco, newValue, oldValue))

		this.ValDuration = reactive(new modelFieldType.Number({
			id: 'ValDuration',
			originId: 'ValDuration',
			area: 'FLDS',
			field: 'DURATION',
			maxDigits: 2,
			decimalDigits: 2,
			description: computed(() => this.Resources.NUMERIC_DECIMAL37352),
		}).cloneFrom(values?.ValDuration))
		watch(() => this.ValDuration.value, (newValue, oldValue) => this.onUpdate('flds.duration', this.ValDuration, newValue, oldValue))

		this.ValNpassage = reactive(new modelFieldType.Number({
			id: 'ValNpassage',
			originId: 'ValNpassage',
			area: 'FLDS',
			field: 'NPASSAGE',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.NUMERIC19292),
		}).cloneFrom(values?.ValNpassage))
		watch(() => this.ValNpassage.value, (newValue, oldValue) => this.onUpdate('flds.npassage', this.ValNpassage, newValue, oldValue))

		this.ValPrecobil = reactive(new modelFieldType.Number({
			id: 'ValPrecobil',
			originId: 'ValPrecobil',
			area: 'FLDS',
			field: 'PRECOBIL',
			maxDigits: 3,
			decimalDigits: 2,
			description: computed(() => this.Resources.CURRENCY_DECIMAL48296),
		}).cloneFrom(values?.ValPrecobil))
		watch(() => this.ValPrecobil.value, (newValue, oldValue) => this.onUpdate('flds.precobil', this.ValPrecobil, newValue, oldValue))

		this.ValPrice = reactive(new modelFieldType.Number({
			id: 'ValPrice',
			originId: 'ValPrice',
			area: 'FLDS',
			field: 'PRICE',
			maxDigits: 3,
			decimalDigits: 2,
			description: computed(() => this.Resources.CURRENCY13881),
		}).cloneFrom(values?.ValPrice))
		watch(() => this.ValPrice.value, (newValue, oldValue) => this.onUpdate('flds.price', this.ValPrice, newValue, oldValue))

		this.ValSsnumber = reactive(new modelFieldType.String({
			id: 'ValSsnumber',
			originId: 'ValSsnumber',
			area: 'FLDS',
			field: 'SSNUMBER',
			maxLength: 11,
			maskType: 'SS',
			description: computed(() => this.Resources.SOCIAL_SECURITY_NO48150),
		}).cloneFrom(values?.ValSsnumber))
		watch(() => this.ValSsnumber.value, (newValue, oldValue) => this.onUpdate('flds.ssnumber', this.ValSsnumber, newValue, oldValue))

		this.ValZipfield = reactive(new modelFieldType.String({
			id: 'ValZipfield',
			originId: 'ValZipfield',
			area: 'FLDS',
			field: 'ZIPFIELD',
			maxLength: 8,
			maskType: 'CP',
			description: computed(() => this.Resources.ZIPCODE21021),
		}).cloneFrom(values?.ValZipfield))
		watch(() => this.ValZipfield.value, (newValue, oldValue) => this.onUpdate('flds.zipfield', this.ValZipfield, newValue, oldValue))

		this.ValVatnumbr = reactive(new modelFieldType.String({
			id: 'ValVatnumbr',
			originId: 'ValVatnumbr',
			area: 'FLDS',
			field: 'VATNUMBR',
			maxLength: 9,
			maskType: 'NC',
			description: computed(() => this.Resources.VAT_NUMBER24236),
		}).cloneFrom(values?.ValVatnumbr))
		watch(() => this.ValVatnumbr.value, (newValue, oldValue) => this.onUpdate('flds.vatnumbr', this.ValVatnumbr, newValue, oldValue))

		this.ValLicplate = reactive(new modelFieldType.String({
			id: 'ValLicplate',
			originId: 'ValLicplate',
			area: 'FLDS',
			field: 'LICPLATE',
			maxLength: 8,
			maskType: 'MA',
			description: computed(() => this.Resources.LICENCE_PLATE07627),
		}).cloneFrom(values?.ValLicplate))
		watch(() => this.ValLicplate.value, (newValue, oldValue) => this.onUpdate('flds.licplate', this.ValLicplate, newValue, oldValue))

		this.ValBanknmbr = reactive(new modelFieldType.String({
			id: 'ValBanknmbr',
			originId: 'ValBanknmbr',
			area: 'FLDS',
			field: 'BANKNMBR',
			maxLength: 24,
			maskType: 'IB',
			description: computed(() => this.Resources.BANKING_ACCOUNT_NUMB62548),
		}).cloneFrom(values?.ValBanknmbr))
		watch(() => this.ValBanknmbr.value, (newValue, oldValue) => this.onUpdate('flds.banknmbr', this.ValBanknmbr, newValue, oldValue))

		this.ValEmailfld = reactive(new modelFieldType.String({
			id: 'ValEmailfld',
			originId: 'ValEmailfld',
			area: 'FLDS',
			field: 'EMAILFLD',
			maxLength: 50,
			maskType: 'EM',
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.ValEmailfld))
		watch(() => this.ValEmailfld.value, (newValue, oldValue) => this.onUpdate('flds.emailfld', this.ValEmailfld, newValue, oldValue))

		this.ValIbanfiel = reactive(new modelFieldType.String({
			id: 'ValIbanfiel',
			originId: 'ValIbanfiel',
			area: 'FLDS',
			field: 'IBANFIEL',
			maxLength: 34,
			maskType: 'IN',
			description: computed(() => this.Resources.IBAN28506),
		}).cloneFrom(values?.ValIbanfiel))
		watch(() => this.ValIbanfiel.value, (newValue, oldValue) => this.onUpdate('flds.ibanfiel', this.ValIbanfiel, newValue, oldValue))

		this.ValUpprtext = reactive(new modelFieldType.String({
			id: 'ValUpprtext',
			originId: 'ValUpprtext',
			area: 'FLDS',
			field: 'UPPRTEXT',
			maxLength: 50,
			maskType: 'UP',
			description: computed(() => this.Resources.UPPERCASE48238),
		}).cloneFrom(values?.ValUpprtext))
		watch(() => this.ValUpprtext.value, (newValue, oldValue) => this.onUpdate('flds.upprtext', this.ValUpprtext, newValue, oldValue))

		this.ValPassfld = reactive(new modelFieldType.String({
			id: 'ValPassfld',
			originId: 'ValPassfld',
			area: 'FLDS',
			field: 'PASSFLD',
			maxLength: 50,
			description: computed(() => this.Resources.PASSWORD09467),
		}).cloneFrom(values?.ValPassfld))
		watch(() => this.ValPassfld.value, (newValue, oldValue) => this.onUpdate('flds.passfld', this.ValPassfld, newValue, oldValue))

		this.ValClrpicke = reactive(new modelFieldType.String({
			id: 'ValClrpicke',
			originId: 'ValClrpicke',
			area: 'FLDS',
			field: 'CLRPICKE',
			maxLength: 50,
			description: computed(() => this.Resources.COLORPICKER39653),
		}).cloneFrom(values?.ValClrpicke))
		watch(() => this.ValClrpicke.value, (newValue, oldValue) => this.onUpdate('flds.clrpicke', this.ValClrpicke, newValue, oldValue))

		this.ValLogoexte = reactive(new modelFieldType.Image({
			id: 'ValLogoexte',
			originId: 'ValLogoexte',
			area: 'FLDS',
			field: 'LOGOEXTE',
			description: computed(() => this.Resources.LOGO__EXTERNAL_FILE_58162),
		}).cloneFrom(values?.ValLogoexte))
		watch(() => this.ValLogoexte.value, (newValue, oldValue) => this.onUpdate('flds.logoexte', this.ValLogoexte, newValue, oldValue))

		this.ValLogo = reactive(new modelFieldType.Image({
			id: 'ValLogo',
			originId: 'ValLogo',
			area: 'FLDS',
			field: 'LOGO',
			description: computed(() => this.Resources.LOGO62483),
		}).cloneFrom(values?.ValLogo))
		watch(() => this.ValLogo.value, (newValue, oldValue) => this.onUpdate('flds.logo', this.ValLogo, newValue, oldValue))

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
		watch(() => this.ValAttach.value, (newValue, oldValue) => this.onUpdate('flds.attach', this.ValAttach, newValue, oldValue))

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
		watch(() => this.ValAttachfk.value, (newValue, oldValue) => this.onUpdate('flds.attachfk', this.ValAttachfk, newValue, oldValue))
		this.ValAttachData = reactive(new modelFieldType.DocumentData({
			id: 'ValAttachData',
			area: 'FLDS',
			field: 'ATTACHDATA',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValAttachData))
		watch(() => this.ValAttachData.value, (newValue, oldValue) => this.onUpdate('flds.attachdata', this.ValAttachData, newValue, oldValue), { deep: true })

		this.ValCreatdat = reactive(new modelFieldType.Date({
			id: 'ValCreatdat',
			originId: 'ValCreatdat',
			area: 'FLDS',
			field: 'CREATDAT',
			isFixed: true,
			description: computed(() => this.Resources.DATE_OF_CREATION__DD02208),
		}).cloneFrom(values?.ValCreatdat))
		watch(() => this.ValCreatdat.value, (newValue, oldValue) => this.onUpdate('flds.creatdat', this.ValCreatdat, newValue, oldValue))

		this.ValCreatuse = reactive(new modelFieldType.String({
			id: 'ValCreatuse',
			originId: 'ValCreatuse',
			area: 'FLDS',
			field: 'CREATUSE',
			maxLength: 20,
			isFixed: true,
			description: computed(() => this.Resources.CREATED_BY12292),
		}).cloneFrom(values?.ValCreatuse))
		watch(() => this.ValCreatuse.value, (newValue, oldValue) => this.onUpdate('flds.creatuse', this.ValCreatuse, newValue, oldValue))

		this.ValCreatins = reactive(new modelFieldType.DateTimeSeconds({
			id: 'ValCreatins',
			originId: 'ValCreatins',
			area: 'FLDS',
			field: 'CREATINS',
			isFixed: true,
			description: computed(() => this.Resources.COMPLETE_DATE_OF_CRE57046),
		}).cloneFrom(values?.ValCreatins))
		watch(() => this.ValCreatins.value, (newValue, oldValue) => this.onUpdate('flds.creatins', this.ValCreatins, newValue, oldValue))

		this.ValCreathou = reactive(new modelFieldType.Time({
			id: 'ValCreathou',
			originId: 'ValCreathou',
			area: 'FLDS',
			field: 'CREATHOU',
			isFixed: true,
			description: computed(() => this.Resources.HOUR_OF_CREATION33629),
		}).cloneFrom(values?.ValCreathou))
		watch(() => this.ValCreathou.value, (newValue, oldValue) => this.onUpdate('flds.creathou', this.ValCreathou, newValue, oldValue))

		this.TableAeroName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableAeroName',
			originId: 'ValName',
			area: 'AERO',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.AIRLINE_NAME55130),
		}).cloneFrom(values?.TableAeroName))
		watch(() => this.TableAeroName.value, (newValue, oldValue) => this.onUpdate('aero.name', this.TableAeroName, newValue, oldValue))

		this.ValConditio = reactive(new modelFieldType.Number({
			id: 'ValConditio',
			originId: 'ValConditio',
			area: 'FLDS',
			field: 'CONDITIO',
			maxDigits: 1,
			decimalDigits: 0,
			description: computed(() => this.Resources.CONDITIONAL01431),
		}).cloneFrom(values?.ValConditio))
		watch(() => this.ValConditio.value, (newValue, oldValue) => this.onUpdate('flds.conditio', this.ValConditio, newValue, oldValue))

		this.ValClass = reactive(new modelFieldType.String({
			id: 'ValClass',
			originId: 'ValClass',
			area: 'FLDS',
			field: 'CLASS',
			maxLength: 2,
			arrayOptions: computed(() => qProjArrays.QArrayClass.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.TEXT_ENUMERATION45668),
		}).cloneFrom(values?.ValClass))
		watch(() => this.ValClass.value, (newValue, oldValue) => this.onUpdate('flds.class', this.ValClass, newValue, oldValue))

		/** The form fields used only in formulas. */
		this.ValTblcond = reactive(new modelFieldType.Boolean({
			id: 'ValTblcond',
			originId: 'ValTblcond',
			area: 'FLDS',
			field: 'TBLCOND',
			isFixed: true,
			description: computed(() => this.Resources.ENFORCE_TABLE_CONDIT17491),
		}).cloneFrom(values?.ValTblcond))
		watch(() => this.ValTblcond.value, (newValue, oldValue) => this.onUpdate('flds.tblcond', this.ValTblcond, newValue, oldValue))

		this.ValCond = reactive(new modelFieldType.String({
			id: 'ValCond',
			originId: 'ValCond',
			area: 'FLDS',
			field: 'COND',
			maxLength: 8,
			isFixed: true,
			arrayOptions: computed(() => qProjArrays.QArrayAcondtst.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.FIELD_STATE03599),
		}).cloneFrom(values?.ValCond))
		watch(() => this.ValCond.value, (newValue, oldValue) => this.onUpdate('flds.cond', this.ValCond, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormFieldhlpViewModel instance.
	 * @returns {QFormFieldhlpViewModel} A new instance of QFormFieldhlpViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodflds'

	get QPrimaryKey() { return this.ValCodflds.value }
	set QPrimaryKey(value) { this.ValCodflds.updateValue(value) }
}
