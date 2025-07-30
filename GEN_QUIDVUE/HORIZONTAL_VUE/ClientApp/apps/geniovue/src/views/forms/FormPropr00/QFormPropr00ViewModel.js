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
			name: 'PROPR00',
			area: 'PROPR',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Propr00',
				updateFilesTickets: 'UpdateFilesTicketsPropr00',
				setFile: 'SetFilePropr00'
			}
		})

		/** The primary key. */
		this.ValCodpropr = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodpropr',
			originId: 'ValCodpropr',
			area: 'PROPR',
			field: 'CODPROPR',
			description: '',
		}).cloneFrom(values?.ValCodpropr))
		this.stopWatchers.push(watch(() => this.ValCodpropr.value, (newValue, oldValue) => this.onUpdate('propr.codpropr', this.ValCodpropr, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValCodpais1 = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpais1',
			originId: 'ValCodpais1',
			area: 'PROPR',
			field: 'CODPAIS1',
			relatedArea: 'PAIS1',
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
				dependencyEvents: ['fieldChange:propr.codpesso'],
				isServerRecalc: true,
				isEmpty: qApi.emptyG,
			},
			description: computed(() => this.Resources._PERSON_COUNTRY09884),
		}).cloneFrom(values?.ValCodpais1))
		this.stopWatchers.push(watch(() => this.ValCodpais1.value, (newValue, oldValue) => this.onUpdate('propr.codpais1', this.ValCodpais1, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodtppro = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodtppro',
			originId: 'ValCodtppro',
			area: 'PROPR',
			field: 'CODTPPRO',
			relatedArea: 'TPPRO',
			description: '',
		}).cloneFrom(values?.ValCodtppro))
		this.stopWatchers.push(watch(() => this.ValCodtppro.value, (newValue, oldValue) => this.onUpdate('propr.codtppro', this.ValCodtppro, newValue, oldValue)))

		this.ValCodpesso = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpesso',
			originId: 'ValCodpesso',
			area: 'PROPR',
			field: 'CODPESSO',
			relatedArea: 'PESSO',
			description: computed(() => this.Resources._SELLER11360),
		}).cloneFrom(values?.ValCodpesso))
		this.stopWatchers.push(watch(() => this.ValCodpesso.value, (newValue, oldValue) => this.onUpdate('propr.codpesso', this.ValCodpesso, newValue, oldValue)))

		this.ValCodcntry = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcntry',
			originId: 'ValCodcntry',
			area: 'PROPR',
			field: 'CODCNTRY',
			relatedArea: 'CNTRY',
			description: '',
		}).cloneFrom(values?.ValCodcntry))
		this.stopWatchers.push(watch(() => this.ValCodcntry.value, (newValue, oldValue) => this.onUpdate('propr.codcntry', this.ValCodcntry, newValue, oldValue)))

		this.ValCodregia = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodregia',
			originId: 'ValCodregia',
			area: 'PROPR',
			field: 'CODREGIA',
			relatedArea: 'REGIO',
			description: '',
		}).cloneFrom(values?.ValCodregia))
		this.stopWatchers.push(watch(() => this.ValCodregia.value, (newValue, oldValue) => this.onUpdate('propr.codregia', this.ValCodregia, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'PROPR',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.PROPERTY_NAME18934),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('propr.name', this.ValName, newValue, oldValue)))

		this.ValPrecoest = reactive(new modelFieldType.Number({
			id: 'ValPrecoest',
			originId: 'ValPrecoest',
			area: 'PROPR',
			field: 'PRECOEST',
			maxDigits: 9,
			decimalDigits: 2,
			description: computed(() => this.Resources.ESTIMATED_PRICE02986),
		}).cloneFrom(values?.ValPrecoest))
		this.stopWatchers.push(watch(() => this.ValPrecoest.value, (newValue, oldValue) => this.onUpdate('propr.precoest', this.ValPrecoest, newValue, oldValue)))

		this.TableTpproTppropri = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableTpproTppropri',
			originId: 'ValTppropri',
			area: 'TPPRO',
			field: 'TPPROPRI',
			maxLength: 20,
			description: computed(() => this.Resources.PROPERTY_TYPE51419),
		}).cloneFrom(values?.TableTpproTppropri))
		this.stopWatchers.push(watch(() => this.TableTpproTppropri.value, (newValue, oldValue) => this.onUpdate('tppro.tppropri', this.TableTpproTppropri, newValue, oldValue)))

		this.ValMobilada = reactive(new modelFieldType.Boolean({
			id: 'ValMobilada',
			originId: 'ValMobilada',
			area: 'PROPR',
			field: 'MOBILADA',
			description: computed(() => this.Resources.FURNISHED37431),
		}).cloneFrom(values?.ValMobilada))
		this.stopWatchers.push(watch(() => this.ValMobilada.value, (newValue, oldValue) => this.onUpdate('propr.mobilada', this.ValMobilada, newValue, oldValue)))

		this.TablePessoName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePessoName',
			originId: 'ValName',
			area: 'PESSO',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TablePessoName))
		this.stopWatchers.push(watch(() => this.TablePessoName.value, (newValue, oldValue) => this.onUpdate('pesso.name', this.TablePessoName, newValue, oldValue)))

		this.ValPhotogra = reactive(new modelFieldType.Image({
			id: 'ValPhotogra',
			originId: 'ValPhotogra',
			area: 'PROPR',
			field: 'PHOTOGRA',
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.ValPhotogra))
		this.stopWatchers.push(watch(() => this.ValPhotogra.value, (newValue, oldValue) => this.onUpdate('propr.photogra', this.ValPhotogra, newValue, oldValue)))

		this.ValQtd_wc = reactive(new modelFieldType.Number({
			id: 'ValQtd_wc',
			originId: 'ValQtd_wc',
			area: 'PROPR',
			field: 'QTD_WC',
			maxDigits: 6,
			decimalDigits: 0,
			description: computed(() => this.Resources.BATHROOMS54249),
		}).cloneFrom(values?.ValQtd_wc))
		this.stopWatchers.push(watch(() => this.ValQtd_wc.value, (newValue, oldValue) => this.onUpdate('propr.qtd_wc', this.ValQtd_wc, newValue, oldValue)))

		this.ValQtdquart = reactive(new modelFieldType.Number({
			id: 'ValQtdquart',
			originId: 'ValQtdquart',
			area: 'PROPR',
			field: 'QTDQUART',
			maxDigits: 6,
			decimalDigits: 0,
			description: computed(() => this.Resources.ROOMS06809),
		}).cloneFrom(values?.ValQtdquart))
		this.stopWatchers.push(watch(() => this.ValQtdquart.value, (newValue, oldValue) => this.onUpdate('propr.qtdquart', this.ValQtdquart, newValue, oldValue)))

		this.ValM2 = reactive(new modelFieldType.Number({
			id: 'ValM2',
			originId: 'ValM2',
			area: 'PROPR',
			field: 'M2',
			maxDigits: 6,
			decimalDigits: 0,
			description: computed(() => this.Resources.SQUARE_METERS28913),
		}).cloneFrom(values?.ValM2))
		this.stopWatchers.push(watch(() => this.ValM2.value, (newValue, oldValue) => this.onUpdate('propr.m2', this.ValM2, newValue, oldValue)))

		this.ValDtdispon = reactive(new modelFieldType.Date({
			id: 'ValDtdispon',
			originId: 'ValDtdispon',
			area: 'PROPR',
			field: 'DTDISPON',
			description: computed(() => this.Resources.AVAILABLE_FROM53703),
		}).cloneFrom(values?.ValDtdispon))
		this.stopWatchers.push(watch(() => this.ValDtdispon.value, (newValue, oldValue) => this.onUpdate('propr.dtdispon', this.ValDtdispon, newValue, oldValue)))

		this.ValEndereco = reactive(new modelFieldType.MultiLineString({
			id: 'ValEndereco',
			originId: 'ValEndereco',
			area: 'PROPR',
			field: 'ENDERECO',
			description: computed(() => this.Resources.ADDRESS04342),
		}).cloneFrom(values?.ValEndereco))
		this.stopWatchers.push(watch(() => this.ValEndereco.value, (newValue, oldValue) => this.onUpdate('propr.endereco', this.ValEndereco, newValue, oldValue)))

		this.ValLocalida = reactive(new modelFieldType.String({
			id: 'ValLocalida',
			originId: 'ValLocalida',
			area: 'PROPR',
			field: 'LOCALIDA',
			maxLength: 50,
			description: computed(() => this.Resources.LOCALE34521),
		}).cloneFrom(values?.ValLocalida))
		this.stopWatchers.push(watch(() => this.ValLocalida.value, (newValue, oldValue) => this.onUpdate('propr.localida', this.ValLocalida, newValue, oldValue)))

		this.ValPostalco = reactive(new modelFieldType.String({
			id: 'ValPostalco',
			originId: 'ValPostalco',
			area: 'PROPR',
			field: 'POSTALCO',
			maxLength: 20,
			description: computed(() => this.Resources.ZIP_CODE56964),
		}).cloneFrom(values?.ValPostalco))
		this.stopWatchers.push(watch(() => this.ValPostalco.value, (newValue, oldValue) => this.onUpdate('propr.postalco', this.ValPostalco, newValue, oldValue)))

		this.ValPostallo = reactive(new modelFieldType.String({
			id: 'ValPostallo',
			originId: 'ValPostallo',
			area: 'PROPR',
			field: 'POSTALLO',
			maxLength: 50,
			description: computed(() => this.Resources.POSTAL_LOCATION08708),
		}).cloneFrom(values?.ValPostallo))
		this.stopWatchers.push(watch(() => this.ValPostallo.value, (newValue, oldValue) => this.onUpdate('propr.postallo', this.ValPostallo, newValue, oldValue)))

		this.TableCntryCountry = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCntryCountry',
			originId: 'ValCountry',
			area: 'CNTRY',
			field: 'COUNTRY',
			maxLength: 90,
			description: computed(() => this.Resources.COUNTRY64133),
		}).cloneFrom(values?.TableCntryCountry))
		this.stopWatchers.push(watch(() => this.TableCntryCountry.value, (newValue, oldValue) => this.onUpdate('cntry.country', this.TableCntryCountry, newValue, oldValue)))

		this.TableRegioRegiao = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableRegioRegiao',
			originId: 'ValRegiao',
			area: 'REGIO',
			field: 'REGIAO',
			maxLength: 50,
			description: computed(() => this.Resources.REGION12723),
		}).cloneFrom(values?.TableRegioRegiao))
		this.stopWatchers.push(watch(() => this.TableRegioRegiao.value, (newValue, oldValue) => this.onUpdate('regio.regiao', this.TableRegioRegiao, newValue, oldValue)))

		this.ValCoordgeo = reactive(new modelFieldType.Coordinate({
			id: 'ValCoordgeo',
			originId: 'ValCoordgeo',
			area: 'PROPR',
			field: 'COORDGEO',
			description: computed(() => this.Resources.GEOGRAPHIC_COORDINAT21394),
		}).cloneFrom(values?.ValCoordgeo))
		this.stopWatchers.push(watch(() => this.ValCoordgeo.value, (newValue, oldValue) => this.onUpdate('propr.coordgeo', this.ValCoordgeo, newValue, oldValue)))

		this.ValDescript = reactive(new modelFieldType.MultiLineString({
			type: 'TextEditor',
			id: 'ValDescript',
			originId: 'ValDescript',
			area: 'PROPR',
			field: 'DESCRIPT',
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescript))
		this.stopWatchers.push(watch(() => this.ValDescript.value, (newValue, oldValue) => this.onUpdate('propr.descript', this.ValDescript, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormPropr00ViewModel instance.
	 * @returns {QFormPropr00ViewModel} A new instance of QFormPropr00ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodpropr'

	get QPrimaryKey() { return this.ValCodpropr.value }
	set QPrimaryKey(value) { this.ValCodpropr.updateValue(value) }
}
