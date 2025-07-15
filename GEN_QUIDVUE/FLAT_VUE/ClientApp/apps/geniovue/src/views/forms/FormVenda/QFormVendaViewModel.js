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
			name: 'VENDA',
			area: 'SALE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Venda',
				updateFilesTickets: 'UpdateFilesTicketsVenda',
				setFile: 'SetFileVenda'
			}
		})

		/** The primary key. */
		this.ValCodvenda = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodvenda',
			originId: 'ValCodvenda',
			area: 'SALE',
			field: 'CODVENDA',
			description: '',
		}).cloneFrom(values?.ValCodvenda))
		this.stopWatchers.push(watch(() => this.ValCodvenda.value, (newValue, oldValue) => this.onUpdate('sale.codvenda', this.ValCodvenda, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodorgan = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodorgan',
			originId: 'ValCodorgan',
			area: 'SALE',
			field: 'CODORGAN',
			relatedArea: 'ORGAN',
			description: '',
		}).cloneFrom(values?.ValCodorgan))
		this.stopWatchers.push(watch(() => this.ValCodorgan.value, (newValue, oldValue) => this.onUpdate('sale.codorgan', this.ValCodorgan, newValue, oldValue)))

		/** The remaining form fields. */
		this.TableOrganOrganiza = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableOrganOrganiza',
			originId: 'ValOrganiza',
			area: 'ORGAN',
			field: 'ORGANIZA',
			maxLength: 85,
			description: computed(() => this.Resources.ORGANIZATION64123),
		}).cloneFrom(values?.TableOrganOrganiza))
		this.stopWatchers.push(watch(() => this.TableOrganOrganiza.value, (newValue, oldValue) => this.onUpdate('organ.organiza', this.TableOrganOrganiza, newValue, oldValue)))

		this.ValNrlide = reactive(new modelFieldType.Number({
			id: 'ValNrlide',
			originId: 'ValNrlide',
			area: 'SALE',
			field: 'NRLIDE',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.LEADERSHIP_NUMB16426),
		}).cloneFrom(values?.ValNrlide))
		this.stopWatchers.push(watch(() => this.ValNrlide.value, (newValue, oldValue) => this.onUpdate('sale.nrlide', this.ValNrlide, newValue, oldValue)))

		this.ValStartdt = reactive(new modelFieldType.DateTime({
			id: 'ValStartdt',
			originId: 'ValStartdt',
			area: 'SALE',
			field: 'STARTDT',
			description: computed(() => this.Resources.BEGINNING18124),
		}).cloneFrom(values?.ValStartdt))
		this.stopWatchers.push(watch(() => this.ValStartdt.value, (newValue, oldValue) => this.onUpdate('sale.startdt', this.ValStartdt, newValue, oldValue)))

		this.ValIdentifi = reactive(new modelFieldType.String({
			id: 'ValIdentifi',
			originId: 'ValIdentifi',
			area: 'SALE',
			field: 'IDENTIFI',
			maxLength: 85,
			description: computed(() => this.Resources.IDENTIFICATION_OF_BU58085),
		}).cloneFrom(values?.ValIdentifi))
		this.stopWatchers.push(watch(() => this.ValIdentifi.value, (newValue, oldValue) => this.onUpdate('sale.identifi', this.ValIdentifi, newValue, oldValue)))

		this.ValPotcompr = reactive(new modelFieldType.String({
			id: 'ValPotcompr',
			originId: 'ValPotcompr',
			area: 'SALE',
			field: 'POTCOMPR',
			maxLength: 50,
			description: computed(() => this.Resources.POTENTIAL_BUYERS56564),
		}).cloneFrom(values?.ValPotcompr))
		this.stopWatchers.push(watch(() => this.ValPotcompr.value, (newValue, oldValue) => this.onUpdate('sale.potcompr', this.ValPotcompr, newValue, oldValue)))

		this.ValProspecc = reactive(new modelFieldType.Boolean({
			id: 'ValProspecc',
			originId: 'ValProspecc',
			area: 'SALE',
			field: 'PROSPECC',
			description: computed(() => this.Resources.PROSPECTING_CARRIED_08979),
		}).cloneFrom(values?.ValProspecc))
		this.stopWatchers.push(watch(() => this.ValProspecc.value, (newValue, oldValue) => this.onUpdate('sale.prospecc', this.ValProspecc, newValue, oldValue)))

		this.ValInteress = reactive(new modelFieldType.Boolean({
			id: 'ValInteress',
			originId: 'ValInteress',
			area: 'SALE',
			field: 'INTERESS',
			description: computed(() => this.Resources.INTERESTED34576),
		}).cloneFrom(values?.ValInteress))
		this.stopWatchers.push(watch(() => this.ValInteress.value, (newValue, oldValue) => this.onUpdate('sale.interess', this.ValInteress, newValue, oldValue)))

		this.ValSemrfina = reactive(new modelFieldType.Boolean({
			id: 'ValSemrfina',
			originId: 'ValSemrfina',
			area: 'SALE',
			field: 'SEMRFINA',
			description: computed(() => this.Resources.WITHOUT_FINANCIAL_RE07914),
		}).cloneFrom(values?.ValSemrfina))
		this.stopWatchers.push(watch(() => this.ValSemrfina.value, (newValue, oldValue) => this.onUpdate('sale.semrfina', this.ValSemrfina, newValue, oldValue)))

		this.ValSemcapac = reactive(new modelFieldType.Boolean({
			id: 'ValSemcapac',
			originId: 'ValSemcapac',
			area: 'SALE',
			field: 'SEMCAPAC',
			description: computed(() => this.Resources.NO_DECISION_MAKING_P36615),
		}).cloneFrom(values?.ValSemcapac))
		this.stopWatchers.push(watch(() => this.ValSemcapac.value, (newValue, oldValue) => this.onUpdate('sale.semcapac', this.ValSemcapac, newValue, oldValue)))

		this.ValDtqualif = reactive(new modelFieldType.DateTime({
			id: 'ValDtqualif',
			originId: 'ValDtqualif',
			area: 'SALE',
			field: 'DTQUALIF',
			description: computed(() => this.Resources.QUALIFICATION64257),
		}).cloneFrom(values?.ValDtqualif))
		this.stopWatchers.push(watch(() => this.ValDtqualif.value, (newValue, oldValue) => this.onUpdate('sale.dtqualif', this.ValDtqualif, newValue, oldValue)))

		this.ValQualific = reactive(new modelFieldType.Boolean({
			id: 'ValQualific',
			originId: 'ValQualific',
			area: 'SALE',
			field: 'QUALIFIC',
			description: computed(() => this.Resources.QUALIFICATION_CARRIE05255),
		}).cloneFrom(values?.ValQualific))
		this.stopWatchers.push(watch(() => this.ValQualific.value, (newValue, oldValue) => this.onUpdate('sale.qualific', this.ValQualific, newValue, oldValue)))

		this.ValPreabord = reactive(new modelFieldType.DateTime({
			id: 'ValPreabord',
			originId: 'ValPreabord',
			area: 'SALE',
			field: 'PREABORD',
			description: computed(() => this.Resources.PRE_APPROACH58979),
		}).cloneFrom(values?.ValPreabord))
		this.stopWatchers.push(watch(() => this.ValPreabord.value, (newValue, oldValue) => this.onUpdate('sale.preabord', this.ValPreabord, newValue, oldValue)))

		this.ValHomework = reactive(new modelFieldType.Boolean({
			id: 'ValHomework',
			originId: 'ValHomework',
			area: 'SALE',
			field: 'HOMEWORK',
			description: computed(() => this.Resources.HOMEWORK_DONE45166),
		}).cloneFrom(values?.ValHomework))
		this.stopWatchers.push(watch(() => this.ValHomework.value, (newValue, oldValue) => this.onUpdate('sale.homework', this.ValHomework, newValue, oldValue)))

		this.ValDtaborda = reactive(new modelFieldType.DateTime({
			id: 'ValDtaborda',
			originId: 'ValDtaborda',
			area: 'SALE',
			field: 'DTABORDA',
			description: computed(() => this.Resources.APPROACH06577),
		}).cloneFrom(values?.ValDtaborda))
		this.stopWatchers.push(watch(() => this.ValDtaborda.value, (newValue, oldValue) => this.onUpdate('sale.dtaborda', this.ValDtaborda, newValue, oldValue)))

		this.ValApproach = reactive(new modelFieldType.Boolean({
			id: 'ValApproach',
			originId: 'ValApproach',
			area: 'SALE',
			field: 'APPROACH',
			description: computed(() => this.Resources.ABORDAGEM_EFECTUADA60152),
		}).cloneFrom(values?.ValApproach))
		this.stopWatchers.push(watch(() => this.ValApproach.value, (newValue, oldValue) => this.onUpdate('sale.approach', this.ValApproach, newValue, oldValue)))

		this.ValDtaprese = reactive(new modelFieldType.DateTime({
			id: 'ValDtaprese',
			originId: 'ValDtaprese',
			area: 'SALE',
			field: 'DTAPRESE',
			description: computed(() => this.Resources.PRESENTATION_MADE15117),
		}).cloneFrom(values?.ValDtaprese))
		this.stopWatchers.push(watch(() => this.ValDtaprese.value, (newValue, oldValue) => this.onUpdate('sale.dtaprese', this.ValDtaprese, newValue, oldValue)))

		this.ValApresent = reactive(new modelFieldType.Boolean({
			id: 'ValApresent',
			originId: 'ValApresent',
			area: 'SALE',
			field: 'APRESENT',
			description: computed(() => this.Resources.PRESENTATION64246),
		}).cloneFrom(values?.ValApresent))
		this.stopWatchers.push(watch(() => this.ValApresent.value, (newValue, oldValue) => this.onUpdate('sale.apresent', this.ValApresent, newValue, oldValue)))

		this.ValDtsupera = reactive(new modelFieldType.DateTime({
			id: 'ValDtsupera',
			originId: 'ValDtsupera',
			area: 'SALE',
			field: 'DTSUPERA',
			description: computed(() => this.Resources.OVERCOME_OBJECTIONS61930),
		}).cloneFrom(values?.ValDtsupera))
		this.stopWatchers.push(watch(() => this.ValDtsupera.value, (newValue, oldValue) => this.onUpdate('sale.dtsupera', this.ValDtsupera, newValue, oldValue)))

		this.ValTentfech = reactive(new modelFieldType.DateTime({
			id: 'ValTentfech',
			originId: 'ValTentfech',
			area: 'SALE',
			field: 'TENTFECH',
			description: computed(() => this.Resources.CLOSING_ATTEMPTS40059),
		}).cloneFrom(values?.ValTentfech))
		this.stopWatchers.push(watch(() => this.ValTentfech.value, (newValue, oldValue) => this.onUpdate('sale.tentfech', this.ValTentfech, newValue, oldValue)))

		this.ValDtvenda = reactive(new modelFieldType.DateTime({
			id: 'ValDtvenda',
			originId: 'ValDtvenda',
			area: 'SALE',
			field: 'DTVENDA',
			description: computed(() => this.Resources.CLOSING_OF_THE_SALE05493),
		}).cloneFrom(values?.ValDtvenda))
		this.stopWatchers.push(watch(() => this.ValDtvenda.value, (newValue, oldValue) => this.onUpdate('sale.dtvenda', this.ValDtvenda, newValue, oldValue)))

		this.ValDtacompa = reactive(new modelFieldType.DateTime({
			id: 'ValDtacompa',
			originId: 'ValDtacompa',
			area: 'SALE',
			field: 'DTACOMPA',
			description: computed(() => this.Resources.FOLLOW_UP22119),
		}).cloneFrom(values?.ValDtacompa))
		this.stopWatchers.push(watch(() => this.ValDtacompa.value, (newValue, oldValue) => this.onUpdate('sale.dtacompa', this.ValDtacompa, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormVendaViewModel instance.
	 * @returns {QFormVendaViewModel} A new instance of QFormVendaViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodvenda'

	get QPrimaryKey() { return this.ValCodvenda.value }
	set QPrimaryKey(value) { this.ValCodvenda.updateValue(value) }
}
