/* eslint-disable @typescript-eslint/no-unused-vars */
import _has from 'lodash-es/has'
import { computed } from 'vue'

import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
import modelFieldType from '@quidgest/clientapp/models/fields'

import netAPI from '@quidgest/clientapp/network'
import qApi from '@/api/genio/quidgestFunctions.js'
import qFunctions from '@/api/genio/projectFunctions.js'
import qProjArrays from '@/api/genio/projectArrays.js'
/* eslint-enable @typescript-eslint/no-unused-vars */

/**
 * Represents a ViewModel class.
 */
export default class ViewModel
{
	/**
	 * Creates a new instance of the ViewModel.
	 */
	constructor()
	{

		this.ValCodglob = new modelFieldType.PrimaryKey({
			id: 'ValCodglob',
			originId: 'ValCodglob',
			area: 'GLOB',
			field: 'CODGLOB',
		})

		this.ValHome = new modelFieldType.MultiLineString({
			id: 'ValHome',
			originId: 'ValHome',
			area: 'GLOB',
			field: 'HOME',
		})

		this.ValPzero = new modelFieldType.Number({
			id: 'ValPzero',
			originId: 'ValPzero',
			area: 'GLOB',
			field: 'PZERO',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValRemetent = new modelFieldType.String({
			id: 'ValRemetent',
			originId: 'ValRemetent',
			area: 'GLOB',
			field: 'REMETENT',
			maxLength: 50,
		})

		this.ValSemrspdd = new modelFieldType.Boolean({
			id: 'ValSemrspdd',
			originId: 'ValSemrspdd',
			area: 'GLOB',
			field: 'SEMRSPDD',
		})

		this.ValSemrspin = new modelFieldType.Boolean({
			id: 'ValSemrspin',
			originId: 'ValSemrspin',
			area: 'GLOB',
			field: 'SEMRSPIN',
		})

		this.ValSemrpbsc = new modelFieldType.Boolean({
			id: 'ValSemrpbsc',
			originId: 'ValSemrpbsc',
			area: 'GLOB',
			field: 'SEMRPBSC',
		})

		this.ValSemrpini = new modelFieldType.Boolean({
			id: 'ValSemrpini',
			originId: 'ValSemrpini',
			area: 'GLOB',
			field: 'SEMRPINI',
		})

		this.ValSemrpact = new modelFieldType.Boolean({
			id: 'ValSemrpact',
			originId: 'ValSemrpact',
			area: 'GLOB',
			field: 'SEMRPACT',
		})

		this.ValPvalmin = new modelFieldType.Number({
			id: 'ValPvalmin',
			originId: 'ValPvalmin',
			area: 'GLOB',
			field: 'PVALMIN',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValPlimmau = new modelFieldType.Number({
			id: 'ValPlimmau',
			originId: 'ValPlimmau',
			area: 'GLOB',
			field: 'PLIMMAU',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValPalert = new modelFieldType.Number({
			id: 'ValPalert',
			originId: 'ValPalert',
			area: 'GLOB',
			field: 'PALERT',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValPlimbom = new modelFieldType.Number({
			id: 'ValPlimbom',
			originId: 'ValPlimbom',
			area: 'GLOB',
			field: 'PLIMBOM',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValPlimsup = new modelFieldType.Number({
			id: 'ValPlimsup',
			originId: 'ValPlimsup',
			area: 'GLOB',
			field: 'PLIMSUP',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValPvalmax = new modelFieldType.Number({
			id: 'ValPvalmax',
			originId: 'ValPvalmax',
			area: 'GLOB',
			field: 'PVALMAX',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValPzerod = new modelFieldType.Number({
			id: 'ValPzerod',
			originId: 'ValPzerod',
			area: 'GLOB',
			field: 'PZEROD',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValPvalmind = new modelFieldType.Number({
			id: 'ValPvalmind',
			originId: 'ValPvalmind',
			area: 'GLOB',
			field: 'PVALMIND',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValPalertd = new modelFieldType.Number({
			id: 'ValPalertd',
			originId: 'ValPalertd',
			area: 'GLOB',
			field: 'PALERTD',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValPlimbomd = new modelFieldType.Number({
			id: 'ValPlimbomd',
			originId: 'ValPlimbomd',
			area: 'GLOB',
			field: 'PLIMBOMD',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValPlimsupd = new modelFieldType.Number({
			id: 'ValPlimsupd',
			originId: 'ValPlimsupd',
			area: 'GLOB',
			field: 'PLIMSUPD',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValPvalmaxd = new modelFieldType.Number({
			id: 'ValPvalmaxd',
			originId: 'ValPvalmaxd',
			area: 'GLOB',
			field: 'PVALMAXD',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValIniciano = new modelFieldType.String({
			id: 'ValIniciano',
			originId: 'ValIniciano',
			area: 'GLOB',
			field: 'INICIANO',
			maxLength: 2,
		})

		this.ValPzeroc = new modelFieldType.Number({
			id: 'ValPzeroc',
			originId: 'ValPzeroc',
			area: 'GLOB',
			field: 'PZEROC',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValPminc = new modelFieldType.Number({
			id: 'ValPminc',
			originId: 'ValPminc',
			area: 'GLOB',
			field: 'PMINC',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValPmauc = new modelFieldType.Number({
			id: 'ValPmauc',
			originId: 'ValPmauc',
			area: 'GLOB',
			field: 'PMAUC',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValPalertc = new modelFieldType.Number({
			id: 'ValPalertc',
			originId: 'ValPalertc',
			area: 'GLOB',
			field: 'PALERTC',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValPlimmaud = new modelFieldType.Number({
			id: 'ValPlimmaud',
			originId: 'ValPlimmaud',
			area: 'GLOB',
			field: 'PLIMMAUD',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValPbomc = new modelFieldType.Number({
			id: 'ValPbomc',
			originId: 'ValPbomc',
			area: 'GLOB',
			field: 'PBOMC',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValPbomsc = new modelFieldType.Number({
			id: 'ValPbomsc',
			originId: 'ValPbomsc',
			area: 'GLOB',
			field: 'PBOMSC',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValPalertsc = new modelFieldType.Number({
			id: 'ValPalertsc',
			originId: 'ValPalertsc',
			area: 'GLOB',
			field: 'PALERTSC',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValPmausc = new modelFieldType.Number({
			id: 'ValPmausc',
			originId: 'ValPmausc',
			area: 'GLOB',
			field: 'PMAUSC',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValPmaxsc = new modelFieldType.Number({
			id: 'ValPmaxsc',
			originId: 'ValPmaxsc',
			area: 'GLOB',
			field: 'PMAXSC',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValPzerosc = new modelFieldType.Number({
			id: 'ValPzerosc',
			originId: 'ValPzerosc',
			area: 'GLOB',
			field: 'PZEROSC',
			maxDigits: 3,
			decimalDigits: 2,
		})

		this.ValTipscard = new modelFieldType.String({
			id: 'ValTipscard',
			originId: 'ValTipscard',
			area: 'GLOB',
			field: 'TIPSCARD',
			maxLength: 25,
		})

		this.ValOrganism = new modelFieldType.String({
			id: 'ValOrganism',
			originId: 'ValOrganism',
			area: 'GLOB',
			field: 'ORGANISM',
			maxLength: 80,
		})

		this.ValCode = new modelFieldType.String({
			id: 'ValCode',
			originId: 'ValCode',
			area: 'GLOB',
			field: 'CODE',
			maxLength: 8,
		})

		this.ValMorada = new modelFieldType.String({
			id: 'ValMorada',
			originId: 'ValMorada',
			area: 'GLOB',
			field: 'MORADA',
			maxLength: 60,
		})

		this.ValCpostal = new modelFieldType.String({
			id: 'ValCpostal',
			originId: 'ValCpostal',
			area: 'GLOB',
			field: 'CPOSTAL',
			maxLength: 8,
			maskType: 'CP',
		})

		this.ValLpostal = new modelFieldType.String({
			id: 'ValLpostal',
			originId: 'ValLpostal',
			area: 'GLOB',
			field: 'LPOSTAL',
			maxLength: 25,
		})

		this.ValTelephon = new modelFieldType.String({
			id: 'ValTelephon',
			originId: 'ValTelephon',
			area: 'GLOB',
			field: 'TELEPHON',
			maxLength: 23,
		})

		this.ValFax = new modelFieldType.String({
			id: 'ValFax',
			originId: 'ValFax',
			area: 'GLOB',
			field: 'FAX',
			maxLength: 23,
		})

		this.ValEmail = new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'GLOB',
			field: 'EMAIL',
			maxLength: 40,
		})

		this.ValSite = new modelFieldType.String({
			id: 'ValSite',
			originId: 'ValSite',
			area: 'GLOB',
			field: 'SITE',
			maxLength: 50,
		})

		this.ValSimbolo = new modelFieldType.Image({
			id: 'ValSimbolo',
			originId: 'ValSimbolo',
			area: 'GLOB',
			field: 'SIMBOLO',
		})

		this.ValSimbolol = new modelFieldType.Image({
			id: 'ValSimbolol',
			originId: 'ValSimbolol',
			area: 'GLOB',
			field: 'SIMBOLOL',
		})

		this.ValFooterp = new modelFieldType.Image({
			id: 'ValFooterp',
			originId: 'ValFooterp',
			area: 'GLOB',
			field: 'FOOTERP',
		})

		this.ValFooterl = new modelFieldType.Image({
			id: 'ValFooterl',
			originId: 'ValFooterl',
			area: 'GLOB',
			field: 'FOOTERL',
		})

		this.ValMarcagua = new modelFieldType.Image({
			id: 'ValMarcagua',
			originId: 'ValMarcagua',
			area: 'GLOB',
			field: 'MARCAGUA',
		})

		this.ValLogomint = new modelFieldType.Image({
			id: 'ValLogomint',
			originId: 'ValLogomint',
			area: 'GLOB',
			field: 'LOGOMINT',
		})

		this.ValPathdocu = new modelFieldType.String({
			id: 'ValPathdocu',
			originId: 'ValPathdocu',
			area: 'GLOB',
			field: 'PATHDOCU',
			maxLength: 120,
		})

		this.ValSmtpmail = new modelFieldType.String({
			id: 'ValSmtpmail',
			originId: 'ValSmtpmail',
			area: 'GLOB',
			field: 'SMTPMAIL',
			maxLength: 100,
		})

		this.ValServsmtp = new modelFieldType.String({
			id: 'ValServsmtp',
			originId: 'ValServsmtp',
			area: 'GLOB',
			field: 'SERVSMTP',
			maxLength: 80,
		})

		this.ValSmtpport = new modelFieldType.Number({
			id: 'ValSmtpport',
			originId: 'ValSmtpport',
			area: 'GLOB',
			field: 'SMTPPORT',
			maxDigits: 5,
			decimalDigits: 0,
		})

		this.ValSmtpssl = new modelFieldType.Boolean({
			id: 'ValSmtpssl',
			originId: 'ValSmtpssl',
			area: 'GLOB',
			field: 'SMTPSSL',
		})

		this.ValSmtpuser = new modelFieldType.String({
			id: 'ValSmtpuser',
			originId: 'ValSmtpuser',
			area: 'GLOB',
			field: 'SMTPUSER',
			maxLength: 80,
		})

		this.ValSmtppass = new modelFieldType.String({
			id: 'ValSmtppass',
			originId: 'ValSmtppass',
			area: 'GLOB',
			field: 'SMTPPASS',
			maxLength: 80,
		})

		this.ValTpbonifi = new modelFieldType.String({
			id: 'ValTpbonifi',
			originId: 'ValTpbonifi',
			area: 'GLOB',
			field: 'TPBONIFI',
			maxLength: 1,
		})

		this.ValMostrano = new modelFieldType.Boolean({
			id: 'ValMostrano',
			originId: 'ValMostrano',
			area: 'GLOB',
			field: 'MOSTRANO',
		})

		this.ValSodiasut = new modelFieldType.Boolean({
			id: 'ValSodiasut',
			originId: 'ValSodiasut',
			area: 'GLOB',
			field: 'SODIASUT',
		})

		this.ValExecutou = new modelFieldType.Boolean({
			id: 'ValExecutou',
			originId: 'ValExecutou',
			area: 'GLOB',
			field: 'EXECUTOU',
		})

		this.ValXmlgraph = new modelFieldType.MultiLineString({
			id: 'ValXmlgraph',
			originId: 'ValXmlgraph',
			area: 'GLOB',
			field: 'XMLGRAPH',
		})

		this.ValFiltrorg = new modelFieldType.Boolean({
			id: 'ValFiltrorg',
			originId: 'ValFiltrorg',
			area: 'GLOB',
			field: 'FILTRORG',
		})

		this.ValScoreout = new modelFieldType.String({
			id: 'ValScoreout',
			originId: 'ValScoreout',
			area: 'GLOB',
			field: 'SCOREOUT',
			maxLength: 4,
		})

		this.ValMinister = new modelFieldType.String({
			id: 'ValMinister',
			originId: 'ValMinister',
			area: 'GLOB',
			field: 'MINISTER',
			maxLength: 120,
		})

		this.ValDtultnot = new modelFieldType.Date({
			id: 'ValDtultnot',
			originId: 'ValDtultnot',
			area: 'GLOB',
			field: 'DTULTNOT',
		})

		this.ValIntegdoc = new modelFieldType.Boolean({
			id: 'ValIntegdoc',
			originId: 'ValIntegdoc',
			area: 'GLOB',
			field: 'INTEGDOC',
		})

		this.ValPrefobje = new modelFieldType.String({
			id: 'ValPrefobje',
			originId: 'ValPrefobje',
			area: 'GLOB',
			field: 'PREFOBJE',
			maxLength: 6,
		})

		this.ValPrefindi = new modelFieldType.String({
			id: 'ValPrefindi',
			originId: 'ValPrefindi',
			area: 'GLOB',
			field: 'PREFINDI',
			maxLength: 6,
		})

		this.ValGantunit = new modelFieldType.String({
			id: 'ValGantunit',
			originId: 'ValGantunit',
			area: 'GLOB',
			field: 'GANTUNIT',
			maxLength: 5,
		})

		this.ValGantstep = new modelFieldType.Number({
			id: 'ValGantstep',
			originId: 'ValGantstep',
			area: 'GLOB',
			field: 'GANTSTEP',
			maxDigits: 2,
			decimalDigits: 0,
		})

		this.ValMigrarlt = new modelFieldType.Boolean({
			id: 'ValMigrarlt',
			originId: 'ValMigrarlt',
			area: 'GLOB',
			field: 'MIGRARLT',
		})

		this.ValFiltrrsp = new modelFieldType.Boolean({
			id: 'ValFiltrrsp',
			originId: 'ValFiltrrsp',
			area: 'GLOB',
			field: 'FILTRRSP',
		})

		this.ValDocbd = new modelFieldType.Document({
			id: 'ValDocbd',
			originId: 'ValDocbd',
			area: 'GLOB',
			field: 'DOCBD',
			properties: computed(() => this.ValDocbdPropertiesVM),
			documentFK: computed(() => this.ValDocbdfk),
			currentDocument: computed(() => this.ValDocbdData),
		})

		this.ValHorassem = new modelFieldType.Number({
			id: 'ValHorassem',
			originId: 'ValHorassem',
			area: 'GLOB',
			field: 'HORASSEM',
			maxDigits: 2,
			decimalDigits: 0,
		})

		this.ValAfetacao = new modelFieldType.String({
			id: 'ValAfetacao',
			originId: 'ValAfetacao',
			area: 'GLOB',
			field: 'AFETACAO',
			maxLength: 1,
		})

		this.ValCreatdat = new modelFieldType.Date({
			id: 'ValCreatdat',
			originId: 'ValCreatdat',
			area: 'GLOB',
			field: 'CREATDAT',
		})

		this.ValCreatope = new modelFieldType.String({
			id: 'ValCreatope',
			originId: 'ValCreatope',
			area: 'GLOB',
			field: 'CREATOPE',
			maxLength: 20,
		})

		this.ValChngdate = new modelFieldType.Date({
			id: 'ValChngdate',
			originId: 'ValChngdate',
			area: 'GLOB',
			field: 'CHNGDATE',
		})

		this.ValOperchng = new modelFieldType.String({
			id: 'ValOperchng',
			originId: 'ValOperchng',
			area: 'GLOB',
			field: 'OPERCHNG',
			maxLength: 20,
		})

		this.ValPricolor = new modelFieldType.String({
			id: 'ValPricolor',
			originId: 'ValPricolor',
			area: 'GLOB',
			field: 'PRICOLOR',
			maxLength: 50,
		})

		this.ValCodfacty = new modelFieldType.ForeignKey({
			id: 'ValCodfacty',
			originId: 'ValCodfacty',
			area: 'GLOB',
			field: 'CODFACTY',
			relatedArea: 'FACTY',
		})

		this.ValLegend = new modelFieldType.Image({
			id: 'ValLegend',
			originId: 'ValLegend',
			area: 'GLOB',
			field: 'LEGEND',
		})

		this.ValApiurl = new modelFieldType.String({
			id: 'ValApiurl',
			originId: 'ValApiurl',
			area: 'GLOB',
			field: 'APIURL',
			maxLength: 350,
		})
	}

	static QPrimaryKeyName = 'ValCodglob'

	get QPrimaryKey() { return this.ValCodglob.value }
	set QPrimaryKey(value) { this.ValCodglob.updateValue(value) }

	/**
	 * Hydrates the raw data coming from the server with the necessary metadata.
	 * @param {object} rawData The data to be hydrated
	 */
	hydrate(rawData) {
		for (let modelField in this) {
			if (this[modelField] instanceof modelFieldType.Base && _has(rawData, modelField)) {
				const rawDataFieldValue = rawData[modelField]
				this.hydrateField(modelField, rawDataFieldValue)
			}
		}
	}

	/**
	 * Hydrates the raw data for a given field coming from the server
	 * with the necessary metadata.
	 * @param {object} modelField The target field
	 * @param {*} rawDataFieldValue The data value to be hydrated
	 */
	hydrateField(modelField, rawDataFieldValue) {
		const fieldObj = this[modelField]

		if (typeof fieldObj.hydrate === 'function')
			fieldObj.hydrate(rawDataFieldValue)
	}
}
