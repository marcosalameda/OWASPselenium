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
			name: 'LDENTNOR',
			area: 'LDENT',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_LDENTNOR'
			}
		})

		/** The primary key. */
		this.ValCodldent = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodldent',
			originId: 'ValCodldent',
			area: 'LDENT',
			field: 'CODLDENT',
			description: '',
		}).cloneFrom(values?.ValCodldent))
		watch(() => this.ValCodldent.value, (newValue, oldValue) => this.onUpdate('ldent.codldent', this.ValCodldent, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCoddentr = reactive(new modelFieldType.ForeignKey({
			id: 'ValCoddentr',
			originId: 'ValCoddentr',
			area: 'LDENT',
			field: 'CODDENTR',
			relatedArea: 'INDOC',
			description: '',
		}).cloneFrom(values?.ValCoddentr))
		watch(() => this.ValCoddentr.value, (newValue, oldValue) => this.onUpdate('ldent.coddentr', this.ValCoddentr, newValue, oldValue))

		this.ValCodwareh = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodwareh',
			originId: 'ValCodwareh',
			area: 'LDENT',
			field: 'CODWAREH',
			relatedArea: 'WAREH',
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: [INDOC->CODWAREH]
					return this.IndocValCodwareh.value
				},
				dependencyEvents: ['fieldChange:indoc.codwareh', 'fieldChange:ldent.coddentr'],
				isServerRecalc: false,
				isEmpty: qApi.emptyG,
			},
			description: computed(() => this.Resources._ARMAZEM43996),
		}).cloneFrom(values?.ValCodwareh))
		watch(() => this.ValCodwareh.value, (newValue, oldValue) => this.onUpdate('ldent.codwareh', this.ValCodwareh, newValue, oldValue))

		this.ValCoditem = reactive(new modelFieldType.ForeignKey({
			id: 'ValCoditem',
			originId: 'ValCoditem',
			area: 'LDENT',
			field: 'CODITEM',
			relatedArea: 'ITEM',
			description: computed(() => this.Resources._ARTICLE38266),
		}).cloneFrom(values?.ValCoditem))
		watch(() => this.ValCoditem.value, (newValue, oldValue) => this.onUpdate('ldent.coditem', this.ValCoditem, newValue, oldValue))

		/** The remaining form fields. */
		this.TableIndocDocumenr = reactive(new modelFieldType.Number({
			type: 'Lookup',
			id: 'TableIndocDocumenr',
			originId: 'ValDocumenr',
			area: 'INDOC',
			field: 'DOCUMENR',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.NO_14817),
		}).cloneFrom(values?.TableIndocDocumenr))
		watch(() => this.TableIndocDocumenr.value, (newValue, oldValue) => this.onUpdate('indoc.documenr', this.TableIndocDocumenr, newValue, oldValue))

		this.TableWarehWarehdes = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableWarehWarehdes',
			originId: 'ValWarehdes',
			area: 'WAREH',
			field: 'WAREHDES',
			maxLength: 85,
			description: computed(() => this.Resources.WAREHOUSE51864),
		}).cloneFrom(values?.TableWarehWarehdes))
		watch(() => this.TableWarehWarehdes.value, (newValue, oldValue) => this.onUpdate('wareh.warehdes', this.TableWarehWarehdes, newValue, oldValue))

		this.ValLine = reactive(new modelFieldType.Number({
			id: 'ValLine',
			originId: 'ValLine',
			area: 'LDENT',
			field: 'LINE',
			maxDigits: 3,
			decimalDigits: 1,
			description: computed(() => this.Resources.LINE27983),
		}).cloneFrom(values?.ValLine))
		watch(() => this.ValLine.value, (newValue, oldValue) => this.onUpdate('ldent.line', this.ValLine, newValue, oldValue))

		this.TableItemItemdes = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableItemItemdes',
			originId: 'ValItemdes',
			area: 'ITEM',
			field: 'ITEMDES',
			maxLength: 85,
			description: computed(() => this.Resources.ARTICLE60065),
		}).cloneFrom(values?.TableItemItemdes))
		watch(() => this.TableItemItemdes.value, (newValue, oldValue) => this.onUpdate('item.itemdes', this.TableItemItemdes, newValue, oldValue))

		this.ValQtdentra = reactive(new modelFieldType.Number({
			id: 'ValQtdentra',
			originId: 'ValQtdentra',
			area: 'LDENT',
			field: 'QTDENTRA',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.QTD_ENTRY35144),
		}).cloneFrom(values?.ValQtdentra))
		watch(() => this.ValQtdentra.value, (newValue, oldValue) => this.onUpdate('ldent.qtdentra', this.ValQtdentra, newValue, oldValue))

		this.IndocValCodwareh = reactive(new modelFieldType.ForeignKey({
			id: 'IndocValCodwareh',
			originId: 'ValCodwareh',
			area: 'INDOC',
			field: 'CODWAREH',
			relatedArea: 'WARE1',
			isFixed: true,
			description: computed(() => this.Resources.BY_OMISSION13050),
		}).cloneFrom(values?.IndocValCodwareh))
		watch(() => this.IndocValCodwareh.value, (newValue, oldValue) => this.onUpdate('indoc.codwareh', this.IndocValCodwareh, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormLdentnorViewModel instance.
	 * @returns {QFormLdentnorViewModel} A new instance of QFormLdentnorViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodldent'

	get QPrimaryKey() { return this.ValCodldent.value }
	set QPrimaryKey(value) { this.ValCodldent.updateValue(value) }
}
