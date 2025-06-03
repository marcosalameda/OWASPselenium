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
			name: 'LDSAI',
			area: 'OUTPU',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_LDSAI'
			}
		})

		/** The primary key. */
		this.ValCodoutpu = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodoutpu',
			originId: 'ValCodoutpu',
			area: 'OUTPU',
			field: 'CODOUTPU',
			description: '',
		}).cloneFrom(values?.ValCodoutpu))
		watch(() => this.ValCodoutpu.value, (newValue, oldValue) => this.onUpdate('outpu.codoutpu', this.ValCodoutpu, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodoutpt = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodoutpt',
			originId: 'ValCodoutpt',
			area: 'OUTPU',
			field: 'CODOUTPT',
			relatedArea: 'OUTPT',
			description: '',
		}).cloneFrom(values?.ValCodoutpt))
		watch(() => this.ValCodoutpt.value, (newValue, oldValue) => this.onUpdate('outpu.codoutpt', this.ValCodoutpt, newValue, oldValue))

		this.ValCodwareh = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodwareh',
			originId: 'ValCodwareh',
			area: 'OUTPU',
			field: 'CODWAREH',
			relatedArea: 'WAREH',
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: [OUTPT->CODWAREH]
					return this.OutptValCodwareh.value
				},
				dependencyEvents: ['fieldChange:outpt.codwareh', 'fieldChange:outpu.codoutpt'],
				isServerRecalc: false,
				isEmpty: qApi.emptyG,
			},
			description: computed(() => this.Resources._WAREHOUSE19861),
		}).cloneFrom(values?.ValCodwareh))
		watch(() => this.ValCodwareh.value, (newValue, oldValue) => this.onUpdate('outpu.codwareh', this.ValCodwareh, newValue, oldValue))

		this.ValCoditem = reactive(new modelFieldType.ForeignKey({
			id: 'ValCoditem',
			originId: 'ValCoditem',
			area: 'OUTPU',
			field: 'CODITEM',
			relatedArea: 'ITEM',
			description: computed(() => this.Resources._ARTICLE38266),
		}).cloneFrom(values?.ValCoditem))
		watch(() => this.ValCoditem.value, (newValue, oldValue) => this.onUpdate('outpu.coditem', this.ValCoditem, newValue, oldValue))

		this.ValCoddocsd = reactive(new modelFieldType.ForeignKey({
			id: 'ValCoddocsd',
			originId: 'ValCoddocsd',
			area: 'OUTPU',
			field: 'CODDOCSD',
			relatedArea: 'OUDOC',
			description: computed(() => this.Resources._EXIT_DOCUMENT48701),
		}).cloneFrom(values?.ValCoddocsd))
		watch(() => this.ValCoddocsd.value, (newValue, oldValue) => this.onUpdate('outpu.coddocsd', this.ValCoddocsd, newValue, oldValue))

		/** The remaining form fields. */
		this.TableOutptDocumenr = reactive(new modelFieldType.Number({
			type: 'Lookup',
			id: 'TableOutptDocumenr',
			originId: 'ValDocumenr',
			area: 'OUTPT',
			field: 'DOCUMENR',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.NO_14817),
		}).cloneFrom(values?.TableOutptDocumenr))
		watch(() => this.TableOutptDocumenr.value, (newValue, oldValue) => this.onUpdate('outpt.documenr', this.TableOutptDocumenr, newValue, oldValue))

		this.OutptValCodwareh = reactive(new modelFieldType.ForeignKey({
			id: 'OutptValCodwareh',
			originId: 'ValCodwareh',
			area: 'OUTPT',
			field: 'CODWAREH',
			relatedArea: 'WARE1',
			isFixed: true,
			description: computed(() => this.Resources.BY_OMISSION13050),
		}).cloneFrom(values?.OutptValCodwareh))
		watch(() => this.OutptValCodwareh.value, (newValue, oldValue) => this.onUpdate('outpt.codwareh', this.OutptValCodwareh, newValue, oldValue))

		this.ValLine = reactive(new modelFieldType.Number({
			id: 'ValLine',
			originId: 'ValLine',
			area: 'OUTPU',
			field: 'LINE',
			maxDigits: 3,
			decimalDigits: 1,
			description: computed(() => this.Resources.LINE27983),
		}).cloneFrom(values?.ValLine))
		watch(() => this.ValLine.value, (newValue, oldValue) => this.onUpdate('outpu.line', this.ValLine, newValue, oldValue))

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

		this.ValExitqnty = reactive(new modelFieldType.Number({
			id: 'ValExitqnty',
			originId: 'ValExitqnty',
			area: 'OUTPU',
			field: 'EXITQNTY',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.QTD_OUTPUT12876),
		}).cloneFrom(values?.ValExitqnty))
		watch(() => this.ValExitqnty.value, (newValue, oldValue) => this.onUpdate('outpu.exitqnty', this.ValExitqnty, newValue, oldValue))

		this.TableOudocNrdocsda = reactive(new modelFieldType.Number({
			type: 'Lookup',
			id: 'TableOudocNrdocsda',
			originId: 'ValNrdocsda',
			area: 'OUDOC',
			field: 'NRDOCSDA',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.NO_14817),
		}).cloneFrom(values?.TableOudocNrdocsda))
		watch(() => this.TableOudocNrdocsda.value, (newValue, oldValue) => this.onUpdate('oudoc.nrdocsda', this.TableOudocNrdocsda, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormLdsaiViewModel instance.
	 * @returns {QFormLdsaiViewModel} A new instance of QFormLdsaiViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodoutpu'

	get QPrimaryKey() { return this.ValCodoutpu.value }
	set QPrimaryKey(value) { this.ValCodoutpu.updateValue(value) }
}
