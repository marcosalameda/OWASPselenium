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
			name: 'PROJE',
			area: 'PROJE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_PROJE'
			}
		})

		/** The primary key. */
		this.ValCodproje = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodproje',
			originId: 'ValCodproje',
			area: 'PROJE',
			field: 'CODPROJE',
			description: '',
		}).cloneFrom(values?.ValCodproje))
		watch(() => this.ValCodproje.value, (newValue, oldValue) => this.onUpdate('proje.codproje', this.ValCodproje, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodyear = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodyear',
			originId: 'ValCodyear',
			area: 'PROJE',
			field: 'CODYEAR',
			relatedArea: 'YEAR1',
			description: computed(() => this.Resources._REFERENCE_YEAR44132),
		}).cloneFrom(values?.ValCodyear))
		watch(() => this.ValCodyear.value, (newValue, oldValue) => this.onUpdate('proje.codyear', this.ValCodyear, newValue, oldValue))

		/** The remaining form fields. */
		this.ValProjecto = reactive(new modelFieldType.String({
			id: 'ValProjecto',
			originId: 'ValProjecto',
			area: 'PROJE',
			field: 'PROJECTO',
			maxLength: 50,
			description: computed(() => this.Resources.PROJECT37121),
		}).cloneFrom(values?.ValProjecto))
		watch(() => this.ValProjecto.value, (newValue, oldValue) => this.onUpdate('proje.projecto', this.ValProjecto, newValue, oldValue))

		this.TableYear1Year = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableYear1Year',
			originId: 'ValYear',
			area: 'YEAR1',
			field: 'YEAR',
			maxLength: 4,
			description: computed(() => this.Resources.YEAR61794),
		}).cloneFrom(values?.TableYear1Year))
		watch(() => this.TableYear1Year.value, (newValue, oldValue) => this.onUpdate('year1.year', this.TableYear1Year, newValue, oldValue))

		this.ValPrimeiro = reactive(new modelFieldType.Number({
			id: 'ValPrimeiro',
			originId: 'ValPrimeiro',
			area: 'PROJE',
			field: 'PRIMEIRO',
			maxDigits: 7,
			decimalDigits: 2,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					const fieldId = params?.originField?.id
					const data = typeof fieldId === 'string' ? { [fieldId]: params.originField.value } : {}
					return this.recalculateFormulas(data)
				},
				dependencyEvents: ['fieldChange:proje.year', 'fieldChange:proje.codproje'],
				isServerRecalc: true,
				isEmpty: qApi.emptyN,
			},
			description: computed(() => this.Resources.FIRST42972),
		}).cloneFrom(values?.ValPrimeiro))
		watch(() => this.ValPrimeiro.value, (newValue, oldValue) => this.onUpdate('proje.primeiro', this.ValPrimeiro, newValue, oldValue))

		this.ValBefore = reactive(new modelFieldType.Number({
			id: 'ValBefore',
			originId: 'ValBefore',
			area: 'PROJE',
			field: 'BEFORE',
			maxDigits: 7,
			decimalDigits: 2,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					const fieldId = params?.originField?.id
					const data = typeof fieldId === 'string' ? { [fieldId]: params.originField.value } : {}
					return this.recalculateFormulas(data)
				},
				dependencyEvents: ['fieldChange:proje.year', 'fieldChange:proje.codproje'],
				isServerRecalc: true,
				isEmpty: qApi.emptyN,
			},
			description: computed(() => this.Resources.BEFORE60156),
		}).cloneFrom(values?.ValBefore))
		watch(() => this.ValBefore.value, (newValue, oldValue) => this.onUpdate('proje.before', this.ValBefore, newValue, oldValue))

		this.ValFollowin = reactive(new modelFieldType.Number({
			id: 'ValFollowin',
			originId: 'ValFollowin',
			area: 'PROJE',
			field: 'FOLLOWIN',
			maxDigits: 7,
			decimalDigits: 2,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					const fieldId = params?.originField?.id
					const data = typeof fieldId === 'string' ? { [fieldId]: params.originField.value } : {}
					return this.recalculateFormulas(data)
				},
				dependencyEvents: ['fieldChange:proje.year', 'fieldChange:proje.codproje'],
				isServerRecalc: true,
				isEmpty: qApi.emptyN,
			},
			description: computed(() => this.Resources.FOLLOWING22170),
		}).cloneFrom(values?.ValFollowin))
		watch(() => this.ValFollowin.value, (newValue, oldValue) => this.onUpdate('proje.followin', this.ValFollowin, newValue, oldValue))

		this.ValUltimo = reactive(new modelFieldType.Number({
			id: 'ValUltimo',
			originId: 'ValUltimo',
			area: 'PROJE',
			field: 'ULTIMO',
			maxDigits: 7,
			decimalDigits: 2,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					const fieldId = params?.originField?.id
					const data = typeof fieldId === 'string' ? { [fieldId]: params.originField.value } : {}
					return this.recalculateFormulas(data)
				},
				dependencyEvents: ['fieldChange:proje.year', 'fieldChange:proje.codproje'],
				isServerRecalc: true,
				isEmpty: qApi.emptyN,
			},
			description: computed(() => this.Resources.LAST49207),
		}).cloneFrom(values?.ValUltimo))
		watch(() => this.ValUltimo.value, (newValue, oldValue) => this.onUpdate('proje.ultimo', this.ValUltimo, newValue, oldValue))

		this.ValSaldo1 = reactive(new modelFieldType.Number({
			id: 'ValSaldo1',
			originId: 'ValSaldo1',
			area: 'PROJE',
			field: 'SALDO1',
			maxDigits: 7,
			decimalDigits: 2,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: [PROJE->FOLLOWIN]-[PROJE->BEFORE]
					return this.ValFollowin.value-this.ValBefore.value
				},
				dependencyEvents: ['fieldChange:proje.followin', 'fieldChange:proje.before'],
				isServerRecalc: false,
				isEmpty: qApi.emptyN,
			},
			description: computed(() => this.Resources.NEXT___PREVIOUS__58212),
		}).cloneFrom(values?.ValSaldo1))
		watch(() => this.ValSaldo1.value, (newValue, oldValue) => this.onUpdate('proje.saldo1', this.ValSaldo1, newValue, oldValue))

		this.ValSaldo2 = reactive(new modelFieldType.Number({
			id: 'ValSaldo2',
			originId: 'ValSaldo2',
			area: 'PROJE',
			field: 'SALDO2',
			maxDigits: 7,
			decimalDigits: 2,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: [PROJE->ULTIMO]-[PROJE->PRIMEIRO]
					return this.ValUltimo.value-this.ValPrimeiro.value
				},
				dependencyEvents: ['fieldChange:proje.ultimo', 'fieldChange:proje.primeiro'],
				isServerRecalc: false,
				isEmpty: qApi.emptyN,
			},
			description: computed(() => this.Resources.LAST___FIRST__42481),
		}).cloneFrom(values?.ValSaldo2))
		watch(() => this.ValSaldo2.value, (newValue, oldValue) => this.onUpdate('proje.saldo2', this.ValSaldo2, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormProjeViewModel instance.
	 * @returns {QFormProjeViewModel} A new instance of QFormProjeViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodproje'

	get QPrimaryKey() { return this.ValCodproje.value }
	set QPrimaryKey(value) { this.ValCodproje.updateValue(value) }
}
