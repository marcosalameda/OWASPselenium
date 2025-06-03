/* eslint-disable no-unused-vars */
import { computed, reactive, watch } from 'vue'
import _merge from 'lodash-es/merge'

import ViewModelBase from '@/mixins/formViewModelBase.js'
import genericFunctions from '@/mixins/genericFunctions.js'
import modelFieldType from '@/mixins/formModelFieldTypes.js'

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
	 * @param {object} values - A ViewModel instance to copy values from
	 */
	// eslint-disable-next-line no-unused-vars
	constructor(values)
	{
		super()

		this.ValCodglob = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodglob',
			originId: 'ValCodglob',
			area: 'GLOB',
			field: 'CODGLOB',
		}).cloneFrom(values?.ValCodglob))
		watch(() => this.ValCodglob.value, (newValue, oldValue) => this.onUpdate('glob.codglob', this.ValCodglob, newValue, oldValue))

		this.ValHome = reactive(new modelFieldType.MultiLineString({
			id: 'ValHome',
			originId: 'ValHome',
			area: 'GLOB',
			field: 'HOME',
		}).cloneFrom(values?.ValHome))
		watch(() => this.ValHome.value, (newValue, oldValue) => this.onUpdate('glob.home', this.ValHome, newValue, oldValue))

		this.ValPzero = reactive(new modelFieldType.Number({
			id: 'ValPzero',
			originId: 'ValPzero',
			area: 'GLOB',
			field: 'PZERO',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPzero))
		watch(() => this.ValPzero.value, (newValue, oldValue) => this.onUpdate('glob.pzero', this.ValPzero, newValue, oldValue))

		this.ValRemetent = reactive(new modelFieldType.String({
			id: 'ValRemetent',
			originId: 'ValRemetent',
			area: 'GLOB',
			field: 'REMETENT',
			maxLength: 50,
		}).cloneFrom(values?.ValRemetent))
		watch(() => this.ValRemetent.value, (newValue, oldValue) => this.onUpdate('glob.remetent', this.ValRemetent, newValue, oldValue))

		this.ValSemrspdd = reactive(new modelFieldType.Boolean({
			id: 'ValSemrspdd',
			originId: 'ValSemrspdd',
			area: 'GLOB',
			field: 'SEMRSPDD',
		}).cloneFrom(values?.ValSemrspdd))
		watch(() => this.ValSemrspdd.value, (newValue, oldValue) => this.onUpdate('glob.semrspdd', this.ValSemrspdd, newValue, oldValue))

		this.ValSemrspin = reactive(new modelFieldType.Boolean({
			id: 'ValSemrspin',
			originId: 'ValSemrspin',
			area: 'GLOB',
			field: 'SEMRSPIN',
		}).cloneFrom(values?.ValSemrspin))
		watch(() => this.ValSemrspin.value, (newValue, oldValue) => this.onUpdate('glob.semrspin', this.ValSemrspin, newValue, oldValue))

		this.ValSemrpbsc = reactive(new modelFieldType.Boolean({
			id: 'ValSemrpbsc',
			originId: 'ValSemrpbsc',
			area: 'GLOB',
			field: 'SEMRPBSC',
		}).cloneFrom(values?.ValSemrpbsc))
		watch(() => this.ValSemrpbsc.value, (newValue, oldValue) => this.onUpdate('glob.semrpbsc', this.ValSemrpbsc, newValue, oldValue))

		this.ValSemrpini = reactive(new modelFieldType.Boolean({
			id: 'ValSemrpini',
			originId: 'ValSemrpini',
			area: 'GLOB',
			field: 'SEMRPINI',
		}).cloneFrom(values?.ValSemrpini))
		watch(() => this.ValSemrpini.value, (newValue, oldValue) => this.onUpdate('glob.semrpini', this.ValSemrpini, newValue, oldValue))

		this.ValSemrpact = reactive(new modelFieldType.Boolean({
			id: 'ValSemrpact',
			originId: 'ValSemrpact',
			area: 'GLOB',
			field: 'SEMRPACT',
		}).cloneFrom(values?.ValSemrpact))
		watch(() => this.ValSemrpact.value, (newValue, oldValue) => this.onUpdate('glob.semrpact', this.ValSemrpact, newValue, oldValue))

		this.ValPvalmin = reactive(new modelFieldType.Number({
			id: 'ValPvalmin',
			originId: 'ValPvalmin',
			area: 'GLOB',
			field: 'PVALMIN',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPvalmin))
		watch(() => this.ValPvalmin.value, (newValue, oldValue) => this.onUpdate('glob.pvalmin', this.ValPvalmin, newValue, oldValue))

		this.ValPlimmau = reactive(new modelFieldType.Number({
			id: 'ValPlimmau',
			originId: 'ValPlimmau',
			area: 'GLOB',
			field: 'PLIMMAU',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPlimmau))
		watch(() => this.ValPlimmau.value, (newValue, oldValue) => this.onUpdate('glob.plimmau', this.ValPlimmau, newValue, oldValue))

		this.ValPalert = reactive(new modelFieldType.Number({
			id: 'ValPalert',
			originId: 'ValPalert',
			area: 'GLOB',
			field: 'PALERT',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPalert))
		watch(() => this.ValPalert.value, (newValue, oldValue) => this.onUpdate('glob.palert', this.ValPalert, newValue, oldValue))

		this.ValPlimbom = reactive(new modelFieldType.Number({
			id: 'ValPlimbom',
			originId: 'ValPlimbom',
			area: 'GLOB',
			field: 'PLIMBOM',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPlimbom))
		watch(() => this.ValPlimbom.value, (newValue, oldValue) => this.onUpdate('glob.plimbom', this.ValPlimbom, newValue, oldValue))

		this.ValPlimsup = reactive(new modelFieldType.Number({
			id: 'ValPlimsup',
			originId: 'ValPlimsup',
			area: 'GLOB',
			field: 'PLIMSUP',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPlimsup))
		watch(() => this.ValPlimsup.value, (newValue, oldValue) => this.onUpdate('glob.plimsup', this.ValPlimsup, newValue, oldValue))

		this.ValPvalmax = reactive(new modelFieldType.Number({
			id: 'ValPvalmax',
			originId: 'ValPvalmax',
			area: 'GLOB',
			field: 'PVALMAX',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPvalmax))
		watch(() => this.ValPvalmax.value, (newValue, oldValue) => this.onUpdate('glob.pvalmax', this.ValPvalmax, newValue, oldValue))

		this.ValPzerod = reactive(new modelFieldType.Number({
			id: 'ValPzerod',
			originId: 'ValPzerod',
			area: 'GLOB',
			field: 'PZEROD',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPzerod))
		watch(() => this.ValPzerod.value, (newValue, oldValue) => this.onUpdate('glob.pzerod', this.ValPzerod, newValue, oldValue))

		this.ValPvalmind = reactive(new modelFieldType.Number({
			id: 'ValPvalmind',
			originId: 'ValPvalmind',
			area: 'GLOB',
			field: 'PVALMIND',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPvalmind))
		watch(() => this.ValPvalmind.value, (newValue, oldValue) => this.onUpdate('glob.pvalmind', this.ValPvalmind, newValue, oldValue))

		this.ValPalertd = reactive(new modelFieldType.Number({
			id: 'ValPalertd',
			originId: 'ValPalertd',
			area: 'GLOB',
			field: 'PALERTD',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPalertd))
		watch(() => this.ValPalertd.value, (newValue, oldValue) => this.onUpdate('glob.palertd', this.ValPalertd, newValue, oldValue))

		this.ValPlimbomd = reactive(new modelFieldType.Number({
			id: 'ValPlimbomd',
			originId: 'ValPlimbomd',
			area: 'GLOB',
			field: 'PLIMBOMD',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPlimbomd))
		watch(() => this.ValPlimbomd.value, (newValue, oldValue) => this.onUpdate('glob.plimbomd', this.ValPlimbomd, newValue, oldValue))

		this.ValPlimsupd = reactive(new modelFieldType.Number({
			id: 'ValPlimsupd',
			originId: 'ValPlimsupd',
			area: 'GLOB',
			field: 'PLIMSUPD',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPlimsupd))
		watch(() => this.ValPlimsupd.value, (newValue, oldValue) => this.onUpdate('glob.plimsupd', this.ValPlimsupd, newValue, oldValue))

		this.ValPvalmaxd = reactive(new modelFieldType.Number({
			id: 'ValPvalmaxd',
			originId: 'ValPvalmaxd',
			area: 'GLOB',
			field: 'PVALMAXD',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPvalmaxd))
		watch(() => this.ValPvalmaxd.value, (newValue, oldValue) => this.onUpdate('glob.pvalmaxd', this.ValPvalmaxd, newValue, oldValue))

		this.ValIniciano = reactive(new modelFieldType.String({
			id: 'ValIniciano',
			originId: 'ValIniciano',
			area: 'GLOB',
			field: 'INICIANO',
			maxLength: 2,
		}).cloneFrom(values?.ValIniciano))
		watch(() => this.ValIniciano.value, (newValue, oldValue) => this.onUpdate('glob.iniciano', this.ValIniciano, newValue, oldValue))

		this.ValPzeroc = reactive(new modelFieldType.Number({
			id: 'ValPzeroc',
			originId: 'ValPzeroc',
			area: 'GLOB',
			field: 'PZEROC',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPzeroc))
		watch(() => this.ValPzeroc.value, (newValue, oldValue) => this.onUpdate('glob.pzeroc', this.ValPzeroc, newValue, oldValue))

		this.ValPminc = reactive(new modelFieldType.Number({
			id: 'ValPminc',
			originId: 'ValPminc',
			area: 'GLOB',
			field: 'PMINC',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPminc))
		watch(() => this.ValPminc.value, (newValue, oldValue) => this.onUpdate('glob.pminc', this.ValPminc, newValue, oldValue))

		this.ValPmauc = reactive(new modelFieldType.Number({
			id: 'ValPmauc',
			originId: 'ValPmauc',
			area: 'GLOB',
			field: 'PMAUC',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPmauc))
		watch(() => this.ValPmauc.value, (newValue, oldValue) => this.onUpdate('glob.pmauc', this.ValPmauc, newValue, oldValue))

		this.ValPalertc = reactive(new modelFieldType.Number({
			id: 'ValPalertc',
			originId: 'ValPalertc',
			area: 'GLOB',
			field: 'PALERTC',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPalertc))
		watch(() => this.ValPalertc.value, (newValue, oldValue) => this.onUpdate('glob.palertc', this.ValPalertc, newValue, oldValue))

		this.ValPlimmaud = reactive(new modelFieldType.Number({
			id: 'ValPlimmaud',
			originId: 'ValPlimmaud',
			area: 'GLOB',
			field: 'PLIMMAUD',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPlimmaud))
		watch(() => this.ValPlimmaud.value, (newValue, oldValue) => this.onUpdate('glob.plimmaud', this.ValPlimmaud, newValue, oldValue))

		this.ValPbomc = reactive(new modelFieldType.Number({
			id: 'ValPbomc',
			originId: 'ValPbomc',
			area: 'GLOB',
			field: 'PBOMC',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPbomc))
		watch(() => this.ValPbomc.value, (newValue, oldValue) => this.onUpdate('glob.pbomc', this.ValPbomc, newValue, oldValue))

		this.ValPbomsc = reactive(new modelFieldType.Number({
			id: 'ValPbomsc',
			originId: 'ValPbomsc',
			area: 'GLOB',
			field: 'PBOMSC',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPbomsc))
		watch(() => this.ValPbomsc.value, (newValue, oldValue) => this.onUpdate('glob.pbomsc', this.ValPbomsc, newValue, oldValue))

		this.ValPalertsc = reactive(new modelFieldType.Number({
			id: 'ValPalertsc',
			originId: 'ValPalertsc',
			area: 'GLOB',
			field: 'PALERTSC',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPalertsc))
		watch(() => this.ValPalertsc.value, (newValue, oldValue) => this.onUpdate('glob.palertsc', this.ValPalertsc, newValue, oldValue))

		this.ValPmausc = reactive(new modelFieldType.Number({
			id: 'ValPmausc',
			originId: 'ValPmausc',
			area: 'GLOB',
			field: 'PMAUSC',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPmausc))
		watch(() => this.ValPmausc.value, (newValue, oldValue) => this.onUpdate('glob.pmausc', this.ValPmausc, newValue, oldValue))

		this.ValPmaxsc = reactive(new modelFieldType.Number({
			id: 'ValPmaxsc',
			originId: 'ValPmaxsc',
			area: 'GLOB',
			field: 'PMAXSC',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPmaxsc))
		watch(() => this.ValPmaxsc.value, (newValue, oldValue) => this.onUpdate('glob.pmaxsc', this.ValPmaxsc, newValue, oldValue))

		this.ValPzerosc = reactive(new modelFieldType.Number({
			id: 'ValPzerosc',
			originId: 'ValPzerosc',
			area: 'GLOB',
			field: 'PZEROSC',
			maxDigits: 3,
			decimalDigits: 2,
		}).cloneFrom(values?.ValPzerosc))
		watch(() => this.ValPzerosc.value, (newValue, oldValue) => this.onUpdate('glob.pzerosc', this.ValPzerosc, newValue, oldValue))

		this.ValTipscard = reactive(new modelFieldType.String({
			id: 'ValTipscard',
			originId: 'ValTipscard',
			area: 'GLOB',
			field: 'TIPSCARD',
			maxLength: 25,
		}).cloneFrom(values?.ValTipscard))
		watch(() => this.ValTipscard.value, (newValue, oldValue) => this.onUpdate('glob.tipscard', this.ValTipscard, newValue, oldValue))

		this.ValOrganism = reactive(new modelFieldType.String({
			id: 'ValOrganism',
			originId: 'ValOrganism',
			area: 'GLOB',
			field: 'ORGANISM',
			maxLength: 80,
		}).cloneFrom(values?.ValOrganism))
		watch(() => this.ValOrganism.value, (newValue, oldValue) => this.onUpdate('glob.organism', this.ValOrganism, newValue, oldValue))

		this.ValCode = reactive(new modelFieldType.String({
			id: 'ValCode',
			originId: 'ValCode',
			area: 'GLOB',
			field: 'CODE',
			maxLength: 8,
		}).cloneFrom(values?.ValCode))
		watch(() => this.ValCode.value, (newValue, oldValue) => this.onUpdate('glob.code', this.ValCode, newValue, oldValue))

		this.ValMorada = reactive(new modelFieldType.String({
			id: 'ValMorada',
			originId: 'ValMorada',
			area: 'GLOB',
			field: 'MORADA',
			maxLength: 60,
		}).cloneFrom(values?.ValMorada))
		watch(() => this.ValMorada.value, (newValue, oldValue) => this.onUpdate('glob.morada', this.ValMorada, newValue, oldValue))

		this.ValCpostal = reactive(new modelFieldType.String({
			id: 'ValCpostal',
			originId: 'ValCpostal',
			area: 'GLOB',
			field: 'CPOSTAL',
			maxLength: 8,
			maskType: 'CP',
		}).cloneFrom(values?.ValCpostal))
		watch(() => this.ValCpostal.value, (newValue, oldValue) => this.onUpdate('glob.cpostal', this.ValCpostal, newValue, oldValue))

		this.ValLpostal = reactive(new modelFieldType.String({
			id: 'ValLpostal',
			originId: 'ValLpostal',
			area: 'GLOB',
			field: 'LPOSTAL',
			maxLength: 25,
		}).cloneFrom(values?.ValLpostal))
		watch(() => this.ValLpostal.value, (newValue, oldValue) => this.onUpdate('glob.lpostal', this.ValLpostal, newValue, oldValue))

		this.ValTelephon = reactive(new modelFieldType.String({
			id: 'ValTelephon',
			originId: 'ValTelephon',
			area: 'GLOB',
			field: 'TELEPHON',
			maxLength: 23,
		}).cloneFrom(values?.ValTelephon))
		watch(() => this.ValTelephon.value, (newValue, oldValue) => this.onUpdate('glob.telephon', this.ValTelephon, newValue, oldValue))

		this.ValFax = reactive(new modelFieldType.String({
			id: 'ValFax',
			originId: 'ValFax',
			area: 'GLOB',
			field: 'FAX',
			maxLength: 23,
		}).cloneFrom(values?.ValFax))
		watch(() => this.ValFax.value, (newValue, oldValue) => this.onUpdate('glob.fax', this.ValFax, newValue, oldValue))

		this.ValEmail = reactive(new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'GLOB',
			field: 'EMAIL',
			maxLength: 40,
		}).cloneFrom(values?.ValEmail))
		watch(() => this.ValEmail.value, (newValue, oldValue) => this.onUpdate('glob.email', this.ValEmail, newValue, oldValue))

		this.ValSite = reactive(new modelFieldType.String({
			id: 'ValSite',
			originId: 'ValSite',
			area: 'GLOB',
			field: 'SITE',
			maxLength: 50,
		}).cloneFrom(values?.ValSite))
		watch(() => this.ValSite.value, (newValue, oldValue) => this.onUpdate('glob.site', this.ValSite, newValue, oldValue))

		this.ValSimbolo = reactive(new modelFieldType.Image({
			id: 'ValSimbolo',
			originId: 'ValSimbolo',
			area: 'GLOB',
			field: 'SIMBOLO',
		}).cloneFrom(values?.ValSimbolo))
		watch(() => this.ValSimbolo.value, (newValue, oldValue) => this.onUpdate('glob.simbolo', this.ValSimbolo, newValue, oldValue))

		this.ValSimbolol = reactive(new modelFieldType.Image({
			id: 'ValSimbolol',
			originId: 'ValSimbolol',
			area: 'GLOB',
			field: 'SIMBOLOL',
		}).cloneFrom(values?.ValSimbolol))
		watch(() => this.ValSimbolol.value, (newValue, oldValue) => this.onUpdate('glob.simbolol', this.ValSimbolol, newValue, oldValue))

		this.ValFooterp = reactive(new modelFieldType.Image({
			id: 'ValFooterp',
			originId: 'ValFooterp',
			area: 'GLOB',
			field: 'FOOTERP',
		}).cloneFrom(values?.ValFooterp))
		watch(() => this.ValFooterp.value, (newValue, oldValue) => this.onUpdate('glob.footerp', this.ValFooterp, newValue, oldValue))

		this.ValFooterl = reactive(new modelFieldType.Image({
			id: 'ValFooterl',
			originId: 'ValFooterl',
			area: 'GLOB',
			field: 'FOOTERL',
		}).cloneFrom(values?.ValFooterl))
		watch(() => this.ValFooterl.value, (newValue, oldValue) => this.onUpdate('glob.footerl', this.ValFooterl, newValue, oldValue))

		this.ValMarcagua = reactive(new modelFieldType.Image({
			id: 'ValMarcagua',
			originId: 'ValMarcagua',
			area: 'GLOB',
			field: 'MARCAGUA',
		}).cloneFrom(values?.ValMarcagua))
		watch(() => this.ValMarcagua.value, (newValue, oldValue) => this.onUpdate('glob.marcagua', this.ValMarcagua, newValue, oldValue))

		this.ValLogomint = reactive(new modelFieldType.Image({
			id: 'ValLogomint',
			originId: 'ValLogomint',
			area: 'GLOB',
			field: 'LOGOMINT',
		}).cloneFrom(values?.ValLogomint))
		watch(() => this.ValLogomint.value, (newValue, oldValue) => this.onUpdate('glob.logomint', this.ValLogomint, newValue, oldValue))

		this.ValPathdocu = reactive(new modelFieldType.String({
			id: 'ValPathdocu',
			originId: 'ValPathdocu',
			area: 'GLOB',
			field: 'PATHDOCU',
			maxLength: 120,
		}).cloneFrom(values?.ValPathdocu))
		watch(() => this.ValPathdocu.value, (newValue, oldValue) => this.onUpdate('glob.pathdocu', this.ValPathdocu, newValue, oldValue))

		this.ValSmtpmail = reactive(new modelFieldType.String({
			id: 'ValSmtpmail',
			originId: 'ValSmtpmail',
			area: 'GLOB',
			field: 'SMTPMAIL',
			maxLength: 100,
		}).cloneFrom(values?.ValSmtpmail))
		watch(() => this.ValSmtpmail.value, (newValue, oldValue) => this.onUpdate('glob.smtpmail', this.ValSmtpmail, newValue, oldValue))

		this.ValServsmtp = reactive(new modelFieldType.String({
			id: 'ValServsmtp',
			originId: 'ValServsmtp',
			area: 'GLOB',
			field: 'SERVSMTP',
			maxLength: 80,
		}).cloneFrom(values?.ValServsmtp))
		watch(() => this.ValServsmtp.value, (newValue, oldValue) => this.onUpdate('glob.servsmtp', this.ValServsmtp, newValue, oldValue))

		this.ValSmtpport = reactive(new modelFieldType.Number({
			id: 'ValSmtpport',
			originId: 'ValSmtpport',
			area: 'GLOB',
			field: 'SMTPPORT',
			maxDigits: 5,
			decimalDigits: 0,
		}).cloneFrom(values?.ValSmtpport))
		watch(() => this.ValSmtpport.value, (newValue, oldValue) => this.onUpdate('glob.smtpport', this.ValSmtpport, newValue, oldValue))

		this.ValSmtpssl = reactive(new modelFieldType.Boolean({
			id: 'ValSmtpssl',
			originId: 'ValSmtpssl',
			area: 'GLOB',
			field: 'SMTPSSL',
		}).cloneFrom(values?.ValSmtpssl))
		watch(() => this.ValSmtpssl.value, (newValue, oldValue) => this.onUpdate('glob.smtpssl', this.ValSmtpssl, newValue, oldValue))

		this.ValSmtpuser = reactive(new modelFieldType.String({
			id: 'ValSmtpuser',
			originId: 'ValSmtpuser',
			area: 'GLOB',
			field: 'SMTPUSER',
			maxLength: 80,
		}).cloneFrom(values?.ValSmtpuser))
		watch(() => this.ValSmtpuser.value, (newValue, oldValue) => this.onUpdate('glob.smtpuser', this.ValSmtpuser, newValue, oldValue))

		this.ValSmtppass = reactive(new modelFieldType.String({
			id: 'ValSmtppass',
			originId: 'ValSmtppass',
			area: 'GLOB',
			field: 'SMTPPASS',
			maxLength: 80,
		}).cloneFrom(values?.ValSmtppass))
		watch(() => this.ValSmtppass.value, (newValue, oldValue) => this.onUpdate('glob.smtppass', this.ValSmtppass, newValue, oldValue))

		this.ValTpbonifi = reactive(new modelFieldType.String({
			id: 'ValTpbonifi',
			originId: 'ValTpbonifi',
			area: 'GLOB',
			field: 'TPBONIFI',
			maxLength: 1,
		}).cloneFrom(values?.ValTpbonifi))
		watch(() => this.ValTpbonifi.value, (newValue, oldValue) => this.onUpdate('glob.tpbonifi', this.ValTpbonifi, newValue, oldValue))

		this.ValMostrano = reactive(new modelFieldType.Boolean({
			id: 'ValMostrano',
			originId: 'ValMostrano',
			area: 'GLOB',
			field: 'MOSTRANO',
		}).cloneFrom(values?.ValMostrano))
		watch(() => this.ValMostrano.value, (newValue, oldValue) => this.onUpdate('glob.mostrano', this.ValMostrano, newValue, oldValue))

		this.ValSodiasut = reactive(new modelFieldType.Boolean({
			id: 'ValSodiasut',
			originId: 'ValSodiasut',
			area: 'GLOB',
			field: 'SODIASUT',
		}).cloneFrom(values?.ValSodiasut))
		watch(() => this.ValSodiasut.value, (newValue, oldValue) => this.onUpdate('glob.sodiasut', this.ValSodiasut, newValue, oldValue))

		this.ValExecutou = reactive(new modelFieldType.Boolean({
			id: 'ValExecutou',
			originId: 'ValExecutou',
			area: 'GLOB',
			field: 'EXECUTOU',
		}).cloneFrom(values?.ValExecutou))
		watch(() => this.ValExecutou.value, (newValue, oldValue) => this.onUpdate('glob.executou', this.ValExecutou, newValue, oldValue))

		this.ValXmlgraph = reactive(new modelFieldType.MultiLineString({
			id: 'ValXmlgraph',
			originId: 'ValXmlgraph',
			area: 'GLOB',
			field: 'XMLGRAPH',
		}).cloneFrom(values?.ValXmlgraph))
		watch(() => this.ValXmlgraph.value, (newValue, oldValue) => this.onUpdate('glob.xmlgraph', this.ValXmlgraph, newValue, oldValue))

		this.ValFiltrorg = reactive(new modelFieldType.Boolean({
			id: 'ValFiltrorg',
			originId: 'ValFiltrorg',
			area: 'GLOB',
			field: 'FILTRORG',
		}).cloneFrom(values?.ValFiltrorg))
		watch(() => this.ValFiltrorg.value, (newValue, oldValue) => this.onUpdate('glob.filtrorg', this.ValFiltrorg, newValue, oldValue))

		this.ValScoreout = reactive(new modelFieldType.String({
			id: 'ValScoreout',
			originId: 'ValScoreout',
			area: 'GLOB',
			field: 'SCOREOUT',
			maxLength: 4,
		}).cloneFrom(values?.ValScoreout))
		watch(() => this.ValScoreout.value, (newValue, oldValue) => this.onUpdate('glob.scoreout', this.ValScoreout, newValue, oldValue))

		this.ValMinister = reactive(new modelFieldType.String({
			id: 'ValMinister',
			originId: 'ValMinister',
			area: 'GLOB',
			field: 'MINISTER',
			maxLength: 120,
		}).cloneFrom(values?.ValMinister))
		watch(() => this.ValMinister.value, (newValue, oldValue) => this.onUpdate('glob.minister', this.ValMinister, newValue, oldValue))

		this.ValDtultnot = reactive(new modelFieldType.Date({
			id: 'ValDtultnot',
			originId: 'ValDtultnot',
			area: 'GLOB',
			field: 'DTULTNOT',
		}).cloneFrom(values?.ValDtultnot))
		watch(() => this.ValDtultnot.value, (newValue, oldValue) => this.onUpdate('glob.dtultnot', this.ValDtultnot, newValue, oldValue))

		this.ValIntegdoc = reactive(new modelFieldType.Boolean({
			id: 'ValIntegdoc',
			originId: 'ValIntegdoc',
			area: 'GLOB',
			field: 'INTEGDOC',
		}).cloneFrom(values?.ValIntegdoc))
		watch(() => this.ValIntegdoc.value, (newValue, oldValue) => this.onUpdate('glob.integdoc', this.ValIntegdoc, newValue, oldValue))

		this.ValPrefobje = reactive(new modelFieldType.String({
			id: 'ValPrefobje',
			originId: 'ValPrefobje',
			area: 'GLOB',
			field: 'PREFOBJE',
			maxLength: 6,
		}).cloneFrom(values?.ValPrefobje))
		watch(() => this.ValPrefobje.value, (newValue, oldValue) => this.onUpdate('glob.prefobje', this.ValPrefobje, newValue, oldValue))

		this.ValPrefindi = reactive(new modelFieldType.String({
			id: 'ValPrefindi',
			originId: 'ValPrefindi',
			area: 'GLOB',
			field: 'PREFINDI',
			maxLength: 6,
		}).cloneFrom(values?.ValPrefindi))
		watch(() => this.ValPrefindi.value, (newValue, oldValue) => this.onUpdate('glob.prefindi', this.ValPrefindi, newValue, oldValue))

		this.ValGantunit = reactive(new modelFieldType.String({
			id: 'ValGantunit',
			originId: 'ValGantunit',
			area: 'GLOB',
			field: 'GANTUNIT',
			maxLength: 5,
		}).cloneFrom(values?.ValGantunit))
		watch(() => this.ValGantunit.value, (newValue, oldValue) => this.onUpdate('glob.gantunit', this.ValGantunit, newValue, oldValue))

		this.ValGantstep = reactive(new modelFieldType.Number({
			id: 'ValGantstep',
			originId: 'ValGantstep',
			area: 'GLOB',
			field: 'GANTSTEP',
			maxDigits: 2,
			decimalDigits: 0,
		}).cloneFrom(values?.ValGantstep))
		watch(() => this.ValGantstep.value, (newValue, oldValue) => this.onUpdate('glob.gantstep', this.ValGantstep, newValue, oldValue))

		this.ValMigrarlt = reactive(new modelFieldType.Boolean({
			id: 'ValMigrarlt',
			originId: 'ValMigrarlt',
			area: 'GLOB',
			field: 'MIGRARLT',
		}).cloneFrom(values?.ValMigrarlt))
		watch(() => this.ValMigrarlt.value, (newValue, oldValue) => this.onUpdate('glob.migrarlt', this.ValMigrarlt, newValue, oldValue))

		this.ValFiltrrsp = reactive(new modelFieldType.Boolean({
			id: 'ValFiltrrsp',
			originId: 'ValFiltrrsp',
			area: 'GLOB',
			field: 'FILTRRSP',
		}).cloneFrom(values?.ValFiltrrsp))
		watch(() => this.ValFiltrrsp.value, (newValue, oldValue) => this.onUpdate('glob.filtrrsp', this.ValFiltrrsp, newValue, oldValue))

		this.ValDocbd = reactive(new modelFieldType.Document({
			id: 'ValDocbd',
			originId: 'ValDocbd',
			area: 'GLOB',
			field: 'DOCBD',
			properties: computed(() => this.ValDocbdPropertiesVM),
			documentFK: computed(() => this.ValDocbdfk),
			currentDocument: computed(() => this.ValDocbdData),
		}).cloneFrom(values?.ValDocbd))
		watch(() => this.ValDocbd.value, (newValue, oldValue) => this.onUpdate('glob.docbd', this.ValDocbd, newValue, oldValue))

		this.ValDocbdPropertiesVM = reactive(new modelFieldType.Base({
			id: 'ValDocbdPropertiesVM',
			area: 'GLOB',
			field: 'DOCBDDOCUM',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValDocbdPropertiesVM))
		this.ValDocbdfk = reactive(new modelFieldType.String({
			id: 'ValDocbdfk',
			area: 'GLOB',
			field: 'DOCBDFK'
		}).cloneFrom(values?.ValDocbdfk))
		watch(() => this.ValDocbdfk.value, (newValue, oldValue) => this.onUpdate('glob.docbdfk', this.ValDocbdfk, newValue, oldValue))
		this.ValDocbdData = reactive(new modelFieldType.DocumentData({
			id: 'ValDocbdData',
			area: 'GLOB',
			field: 'DOCBDDATA',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValDocbdData))
		watch(() => this.ValDocbdData.value, (newValue, oldValue) => this.onUpdate('glob.docbddata', this.ValDocbdData, newValue, oldValue), { deep: true })

		this.ValHorassem = reactive(new modelFieldType.Number({
			id: 'ValHorassem',
			originId: 'ValHorassem',
			area: 'GLOB',
			field: 'HORASSEM',
			maxDigits: 2,
			decimalDigits: 0,
		}).cloneFrom(values?.ValHorassem))
		watch(() => this.ValHorassem.value, (newValue, oldValue) => this.onUpdate('glob.horassem', this.ValHorassem, newValue, oldValue))

		this.ValAfetacao = reactive(new modelFieldType.String({
			id: 'ValAfetacao',
			originId: 'ValAfetacao',
			area: 'GLOB',
			field: 'AFETACAO',
			maxLength: 1,
		}).cloneFrom(values?.ValAfetacao))
		watch(() => this.ValAfetacao.value, (newValue, oldValue) => this.onUpdate('glob.afetacao', this.ValAfetacao, newValue, oldValue))

		this.ValCreatdat = reactive(new modelFieldType.Date({
			id: 'ValCreatdat',
			originId: 'ValCreatdat',
			area: 'GLOB',
			field: 'CREATDAT',
		}).cloneFrom(values?.ValCreatdat))
		watch(() => this.ValCreatdat.value, (newValue, oldValue) => this.onUpdate('glob.creatdat', this.ValCreatdat, newValue, oldValue))

		this.ValCreatope = reactive(new modelFieldType.String({
			id: 'ValCreatope',
			originId: 'ValCreatope',
			area: 'GLOB',
			field: 'CREATOPE',
			maxLength: 20,
		}).cloneFrom(values?.ValCreatope))
		watch(() => this.ValCreatope.value, (newValue, oldValue) => this.onUpdate('glob.creatope', this.ValCreatope, newValue, oldValue))

		this.ValChngdate = reactive(new modelFieldType.Date({
			id: 'ValChngdate',
			originId: 'ValChngdate',
			area: 'GLOB',
			field: 'CHNGDATE',
		}).cloneFrom(values?.ValChngdate))
		watch(() => this.ValChngdate.value, (newValue, oldValue) => this.onUpdate('glob.chngdate', this.ValChngdate, newValue, oldValue))

		this.ValOperchng = reactive(new modelFieldType.String({
			id: 'ValOperchng',
			originId: 'ValOperchng',
			area: 'GLOB',
			field: 'OPERCHNG',
			maxLength: 20,
		}).cloneFrom(values?.ValOperchng))
		watch(() => this.ValOperchng.value, (newValue, oldValue) => this.onUpdate('glob.operchng', this.ValOperchng, newValue, oldValue))

		this.ValPricolor = reactive(new modelFieldType.String({
			id: 'ValPricolor',
			originId: 'ValPricolor',
			area: 'GLOB',
			field: 'PRICOLOR',
			maxLength: 50,
		}).cloneFrom(values?.ValPricolor))
		watch(() => this.ValPricolor.value, (newValue, oldValue) => this.onUpdate('glob.pricolor', this.ValPricolor, newValue, oldValue))

		this.ValCodfacty = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodfacty',
			originId: 'ValCodfacty',
			area: 'GLOB',
			field: 'CODFACTY',
			relatedArea: 'FACTY',
		}).cloneFrom(values?.ValCodfacty))
		watch(() => this.ValCodfacty.value, (newValue, oldValue) => this.onUpdate('glob.codfacty', this.ValCodfacty, newValue, oldValue))

		this.ValLegend = reactive(new modelFieldType.Image({
			id: 'ValLegend',
			originId: 'ValLegend',
			area: 'GLOB',
			field: 'LEGEND',
		}).cloneFrom(values?.ValLegend))
		watch(() => this.ValLegend.value, (newValue, oldValue) => this.onUpdate('glob.legend', this.ValLegend, newValue, oldValue))

		this.ValApiurl = reactive(new modelFieldType.String({
			id: 'ValApiurl',
			originId: 'ValApiurl',
			area: 'GLOB',
			field: 'APIURL',
			maxLength: 350,
		}).cloneFrom(values?.ValApiurl))
		watch(() => this.ValApiurl.value, (newValue, oldValue) => this.onUpdate('glob.apiurl', this.ValApiurl, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current tGLOBViewModel instance.
	 * @returns {tGLOBViewModel} A new instance of tGLOBViewModel
	 */
	clone()
	{
		return new ViewModel(this)
	}

	static QPrimaryKeyName = 'ValCodglob'

	get QPrimaryKey() { return this.ValCodglob.value }
	set QPrimaryKey(value) { this.ValCodglob.updateValue(value) }
}
