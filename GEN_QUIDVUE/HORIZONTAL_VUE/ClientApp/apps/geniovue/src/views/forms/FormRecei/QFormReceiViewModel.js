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
			name: 'RECEI',
			area: 'RECEI',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Recei',
				updateFilesTickets: 'UpdateFilesTicketsRecei',
				setFile: 'SetFileRecei'
			}
		})

		/** The primary key. */
		this.ValCodrecei = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodrecei',
			originId: 'ValCodrecei',
			area: 'RECEI',
			field: 'CODRECEI',
			description: '',
		}).cloneFrom(values?.ValCodrecei))
		this.stopWatchers.push(watch(() => this.ValCodrecei.value, (newValue, oldValue) => this.onUpdate('recei.codrecei', this.ValCodrecei, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodentit = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodentit',
			originId: 'ValCodentit',
			area: 'RECEI',
			field: 'CODENTIT',
			relatedArea: 'ENTIT',
			description: computed(() => this.Resources.__SUPPLIER62145),
		}).cloneFrom(values?.ValCodentit))
		this.stopWatchers.push(watch(() => this.ValCodentit.value, (newValue, oldValue) => this.onUpdate('recei.codentit', this.ValCodentit, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValDtreceip = reactive(new modelFieldType.DateTime({
			id: 'ValDtreceip',
			originId: 'ValDtreceip',
			area: 'RECEI',
			field: 'DTRECEIP',
			description: computed(() => this.Resources.RECEIPT_DATE00996),
		}).cloneFrom(values?.ValDtreceip))
		this.stopWatchers.push(watch(() => this.ValDtreceip.value, (newValue, oldValue) => this.onUpdate('recei.dtreceip', this.ValDtreceip, newValue, oldValue)))

		this.ValNumber = reactive(new modelFieldType.Number({
			id: 'ValNumber',
			originId: 'ValNumber',
			area: 'RECEI',
			field: 'NUMBER',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.RECEIPT_NUMBER31380),
		}).cloneFrom(values?.ValNumber))
		this.stopWatchers.push(watch(() => this.ValNumber.value, (newValue, oldValue) => this.onUpdate('recei.number', this.ValNumber, newValue, oldValue)))

		this.TableEntitName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableEntitName',
			originId: 'ValName',
			area: 'ENTIT',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.LEGAL_NAME42902),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableEntitName))
		this.stopWatchers.push(watch(() => this.TableEntitName.value, (newValue, oldValue) => this.onUpdate('entit.name', this.TableEntitName, newValue, oldValue)))

		this.ValDtcheck = reactive(new modelFieldType.DateTime({
			id: 'ValDtcheck',
			originId: 'ValDtcheck',
			area: 'RECEI',
			field: 'DTCHECK',
			description: computed(() => this.Resources.RECEIPT_VERIFICATION62328),
		}).cloneFrom(values?.ValDtcheck))
		this.stopWatchers.push(watch(() => this.ValDtcheck.value, (newValue, oldValue) => this.onUpdate('recei.dtcheck', this.ValDtcheck, newValue, oldValue)))

		this.ValTocheck = reactive(new modelFieldType.Boolean({
			id: 'ValTocheck',
			originId: 'ValTocheck',
			area: 'RECEI',
			field: 'TOCHECK',
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: iif(!isEmptyD([RECEI->DTRECEIP]) && isEmptyD([RECEI->DTCHECK]),1,0)
					return qApi.iif(!(this.ValDtreceip.value === '')&&(this.ValDtcheck.value === ''),1,0)
				},
				dependencyEvents: ['fieldChange:recei.dtreceip', 'fieldChange:recei.dtcheck'],
				isServerRecalc: false,
				isEmpty: qApi.emptyL,
			},
			description: computed(() => this.Resources.TO_CHECK57511),
		}).cloneFrom(values?.ValTocheck))
		this.stopWatchers.push(watch(() => this.ValTocheck.value, (newValue, oldValue) => this.onUpdate('recei.tocheck', this.ValTocheck, newValue, oldValue)))

		this.ValChecked = reactive(new modelFieldType.Boolean({
			id: 'ValChecked',
			originId: 'ValChecked',
			area: 'RECEI',
			field: 'CHECKED',
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: iif(isEmptyD([RECEI->DTCHECK]),0,1)
					return qApi.iif((this.ValDtcheck.value === ''),0,1)
				},
				dependencyEvents: ['fieldChange:recei.dtcheck'],
				isServerRecalc: false,
				isEmpty: qApi.emptyL,
			},
			description: computed(() => this.Resources.CHECKED31708),
		}).cloneFrom(values?.ValChecked))
		this.stopWatchers.push(watch(() => this.ValChecked.value, (newValue, oldValue) => this.onUpdate('recei.checked', this.ValChecked, newValue, oldValue)))

		this.ValStored = reactive(new modelFieldType.Boolean({
			id: 'ValStored',
			originId: 'ValStored',
			area: 'RECEI',
			field: 'STORED',
			description: computed(() => this.Resources.STORED41854),
		}).cloneFrom(values?.ValStored))
		this.stopWatchers.push(watch(() => this.ValStored.value, (newValue, oldValue) => this.onUpdate('recei.stored', this.ValStored, newValue, oldValue)))

		this.ValDtstorag = reactive(new modelFieldType.DateTime({
			id: 'ValDtstorag',
			originId: 'ValDtstorag',
			area: 'RECEI',
			field: 'DTSTORAG',
			description: computed(() => this.Resources.STORAGE_DATE59954),
		}).cloneFrom(values?.ValDtstorag))
		this.stopWatchers.push(watch(() => this.ValDtstorag.value, (newValue, oldValue) => this.onUpdate('recei.dtstorag', this.ValDtstorag, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormReceiViewModel instance.
	 * @returns {QFormReceiViewModel} A new instance of QFormReceiViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodrecei'

	get QPrimaryKey() { return this.ValCodrecei.value }
	set QPrimaryKey(value) { this.ValCodrecei.updateValue(value) }
}
