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
			name: 'CMPKI',
			area: 'CMPKI',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Cmpki',
				updateFilesTickets: 'UpdateFilesTicketsCmpki',
				setFile: 'SetFileCmpki'
			}
		})

		/** The primary key. */
		this.ValCodcmpki = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcmpki',
			originId: 'ValCodcmpki',
			area: 'CMPKI',
			field: 'CODCMPKI',
			description: '',
		}).cloneFrom(values?.ValCodcmpki))
		this.stopWatchers.push(watch(() => this.ValCodcmpki.value, (newValue, oldValue) => this.onUpdate('cmpki.codcmpki', this.ValCodcmpki, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodtpequ = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodtpequ',
			originId: 'ValCodtpequ',
			area: 'CMPKI',
			field: 'CODTPEQU',
			relatedArea: 'TPEQU',
			description: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
		}).cloneFrom(values?.ValCodtpequ))
		this.stopWatchers.push(watch(() => this.ValCodtpequ.value, (newValue, oldValue) => this.onUpdate('cmpki.codtpequ', this.ValCodtpequ, newValue, oldValue)))

		this.ValCodtpeq1 = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodtpeq1',
			originId: 'ValCodtpeq1',
			area: 'CMPKI',
			field: 'CODTPEQ1',
			relatedArea: 'TPEQ1',
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: [CMPKI->CODTPEQU]
					return this.ValCodtpequ.value
				},
				dependencyEvents: ['fieldChange:cmpki.codtpequ'],
				isServerRecalc: false,
				isEmpty: qApi.emptyG,
			},
			description: computed(() => this.Resources.TYPE_OF_COMPONENT_EQ16631),
		}).cloneFrom(values?.ValCodtpeq1))
		this.stopWatchers.push(watch(() => this.ValCodtpeq1.value, (newValue, oldValue) => this.onUpdate('cmpki.codtpeq1', this.ValCodtpeq1, newValue, oldValue)))

		/** The remaining form fields. */
		this.TableTpequTipoequi = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableTpequTipoequi',
			originId: 'ValTipoequi',
			area: 'TPEQU',
			field: 'TIPOEQUI',
			maxLength: 50,
			description: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
		}).cloneFrom(values?.TableTpequTipoequi))
		this.stopWatchers.push(watch(() => this.TableTpequTipoequi.value, (newValue, oldValue) => this.onUpdate('tpequ.tipoequi', this.TableTpequTipoequi, newValue, oldValue)))

		this.ValOrder = reactive(new modelFieldType.Number({
			id: 'ValOrder',
			originId: 'ValOrder',
			area: 'CMPKI',
			field: 'ORDER',
			maxDigits: 3,
			decimalDigits: 1,
			description: computed(() => this.Resources.ORDER39632),
		}).cloneFrom(values?.ValOrder))
		this.stopWatchers.push(watch(() => this.ValOrder.value, (newValue, oldValue) => this.onUpdate('cmpki.order', this.ValOrder, newValue, oldValue)))

		this.TableTpeq1Tipoequi = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableTpeq1Tipoequi',
			originId: 'ValTipoequi',
			area: 'TPEQ1',
			field: 'TIPOEQUI',
			maxLength: 50,
			description: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
		}).cloneFrom(values?.TableTpeq1Tipoequi))
		this.stopWatchers.push(watch(() => this.TableTpeq1Tipoequi.value, (newValue, oldValue) => this.onUpdate('tpeq1.tipoequi', this.TableTpeq1Tipoequi, newValue, oldValue)))

		this.ValQuantida = reactive(new modelFieldType.Number({
			id: 'ValQuantida',
			originId: 'ValQuantida',
			area: 'CMPKI',
			field: 'QUANTIDA',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.AMOUNT46885),
		}).cloneFrom(values?.ValQuantida))
		this.stopWatchers.push(watch(() => this.ValQuantida.value, (newValue, oldValue) => this.onUpdate('cmpki.quantida', this.ValQuantida, newValue, oldValue)))

		this.ValCode = reactive(new modelFieldType.String({
			id: 'ValCode',
			originId: 'ValCode',
			area: 'CMPKI',
			field: 'CODE',
			maxLength: 10,
			description: computed(() => this.Resources.CODE49225),
		}).cloneFrom(values?.ValCode))
		this.stopWatchers.push(watch(() => this.ValCode.value, (newValue, oldValue) => this.onUpdate('cmpki.code', this.ValCode, newValue, oldValue)))

		this.ValDescript = reactive(new modelFieldType.MultiLineString({
			id: 'ValDescript',
			originId: 'ValDescript',
			area: 'CMPKI',
			field: 'DESCRIPT',
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescript))
		this.stopWatchers.push(watch(() => this.ValDescript.value, (newValue, oldValue) => this.onUpdate('cmpki.descript', this.ValDescript, newValue, oldValue)))

		this.ValUrl = reactive(new modelFieldType.String({
			id: 'ValUrl',
			originId: 'ValUrl',
			area: 'CMPKI',
			field: 'URL',
			maxLength: 250,
			description: computed(() => this.Resources.SITE06486),
		}).cloneFrom(values?.ValUrl))
		this.stopWatchers.push(watch(() => this.ValUrl.value, (newValue, oldValue) => this.onUpdate('cmpki.url', this.ValUrl, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormCmpkiViewModel instance.
	 * @returns {QFormCmpkiViewModel} A new instance of QFormCmpkiViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcmpki'

	get QPrimaryKey() { return this.ValCodcmpki.value }
	set QPrimaryKey(value) { this.ValCodcmpki.updateValue(value) }
}
