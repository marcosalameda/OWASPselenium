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
			name: 'LNHDE',
			area: 'LNHDE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_LNHDE'
			}
		})

		/** The primary key. */
		this.ValCodlnhde = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodlnhde',
			originId: 'ValCodlnhde',
			area: 'LNHDE',
			field: 'CODLNHDE',
			description: '',
		}).cloneFrom(values?.ValCodlnhde))
		watch(() => this.ValCodlnhde.value, (newValue, oldValue) => this.onUpdate('lnhde.codlnhde', this.ValCodlnhde, newValue, oldValue))

		/** The hidden foreign keys. */
		this.ValCodlnhag = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodlnhag',
			originId: 'ValCodlnhag',
			area: 'LNHDE',
			field: 'CODLNHAG',
			relatedArea: 'LNHAG',
			description: '',
		}).cloneFrom(values?.ValCodlnhag))
		watch(() => this.ValCodlnhag.value, (newValue, oldValue) => this.onUpdate('lnhde.codlnhag', this.ValCodlnhag, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodpedid = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpedid',
			originId: 'ValCodpedid',
			area: 'LNHDE',
			field: 'CODPEDID',
			relatedArea: 'PEDID',
			description: '',
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					const fieldId = params?.originField?.id
					const data = typeof fieldId === 'string' ? { [fieldId]: params.originField.value } : {}
					return this.recalculateFormulas(data)
				},
				dependencyEvents: ['fieldChange:lnhde.codlnhpd'],
				isServerRecalc: true,
				isServerFormula: false,
				isEmpty: qApi.emptyG,
			},
		}).cloneFrom(values?.ValCodpedid))
		watch(() => this.ValCodpedid.value, (newValue, oldValue) => this.onUpdate('lnhde.codpedid', this.ValCodpedid, newValue, oldValue))

		this.ValCodlnhpd = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodlnhpd',
			originId: 'ValCodlnhpd',
			area: 'LNHDE',
			field: 'CODLNHPD',
			relatedArea: 'LNHPD',
			description: '',
		}).cloneFrom(values?.ValCodlnhpd))
		watch(() => this.ValCodlnhpd.value, (newValue, oldValue) => this.onUpdate('lnhde.codlnhpd', this.ValCodlnhpd, newValue, oldValue))

		this.ValCodtpequ = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodtpequ',
			originId: 'ValCodtpequ',
			area: 'LNHDE',
			field: 'CODTPEQU',
			relatedArea: 'TPEQ1',
			description: '',
		}).cloneFrom(values?.ValCodtpequ))
		watch(() => this.ValCodtpequ.value, (newValue, oldValue) => this.onUpdate('lnhde.codtpequ', this.ValCodtpequ, newValue, oldValue))

		/** The remaining form fields. */
		this.TablePedidNrpedido = reactive(new modelFieldType.Number({
			type: 'Lookup',
			id: 'TablePedidNrpedido',
			originId: 'ValNrpedido',
			area: 'PEDID',
			field: 'NRPEDIDO',
			maxDigits: 6,
			decimalDigits: 0,
			description: computed(() => this.Resources.NO_14817),
		}).cloneFrom(values?.TablePedidNrpedido))
		watch(() => this.TablePedidNrpedido.value, (newValue, oldValue) => this.onUpdate('pedid.nrpedido', this.TablePedidNrpedido, newValue, oldValue))

		this.TableLnhpdLine = reactive(new modelFieldType.Number({
			type: 'Lookup',
			id: 'TableLnhpdLine',
			originId: 'ValLine',
			area: 'LNHPD',
			field: 'LINE',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.LINE27983),
		}).cloneFrom(values?.TableLnhpdLine))
		watch(() => this.TableLnhpdLine.value, (newValue, oldValue) => this.onUpdate('lnhpd.line', this.TableLnhpdLine, newValue, oldValue))

		this.ValOrdem = reactive(new modelFieldType.Number({
			id: 'ValOrdem',
			originId: 'ValOrdem',
			area: 'LNHDE',
			field: 'ORDEM',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.ORDER39632),
		}).cloneFrom(values?.ValOrdem))
		watch(() => this.ValOrdem.value, (newValue, oldValue) => this.onUpdate('lnhde.ordem', this.ValOrdem, newValue, oldValue))

		this.TableTpeq1Tipoequi = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableTpeq1Tipoequi',
			originId: 'ValTipoequi',
			area: 'TPEQ1',
			field: 'TIPOEQUI',
			maxLength: 50,
			description: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
		}).cloneFrom(values?.TableTpeq1Tipoequi))
		watch(() => this.TableTpeq1Tipoequi.value, (newValue, oldValue) => this.onUpdate('tpeq1.tipoequi', this.TableTpeq1Tipoequi, newValue, oldValue))

		this.ValQuantida = reactive(new modelFieldType.Number({
			id: 'ValQuantida',
			originId: 'ValQuantida',
			area: 'LNHDE',
			field: 'QUANTIDA',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.AMOUNT46885),
		}).cloneFrom(values?.ValQuantida))
		watch(() => this.ValQuantida.value, (newValue, oldValue) => this.onUpdate('lnhde.quantida', this.ValQuantida, newValue, oldValue))

		this.ValCode = reactive(new modelFieldType.String({
			id: 'ValCode',
			originId: 'ValCode',
			area: 'LNHDE',
			field: 'CODE',
			maxLength: 10,
			description: computed(() => this.Resources.CODE49225),
		}).cloneFrom(values?.ValCode))
		watch(() => this.ValCode.value, (newValue, oldValue) => this.onUpdate('lnhde.code', this.ValCode, newValue, oldValue))

		this.ValDescript = reactive(new modelFieldType.String({
			id: 'ValDescript',
			originId: 'ValDescript',
			area: 'LNHDE',
			field: 'DESCRIPT',
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescript))
		watch(() => this.ValDescript.value, (newValue, oldValue) => this.onUpdate('lnhde.descript', this.ValDescript, newValue, oldValue))

		this.ValUrl = reactive(new modelFieldType.String({
			id: 'ValUrl',
			originId: 'ValUrl',
			area: 'LNHDE',
			field: 'URL',
			maxLength: 250,
			description: computed(() => this.Resources.SITE06486),
		}).cloneFrom(values?.ValUrl))
		watch(() => this.ValUrl.value, (newValue, oldValue) => this.onUpdate('lnhde.url', this.ValUrl, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormLnhdeViewModel instance.
	 * @returns {QFormLnhdeViewModel} A new instance of QFormLnhdeViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodlnhde'

	get QPrimaryKey() { return this.ValCodlnhde.value }
	set QPrimaryKey(value) { this.ValCodlnhde.value = value }
}
