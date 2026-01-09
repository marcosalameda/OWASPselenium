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
			name: 'DESPE',
			area: 'EXPEN',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Despe',
				updateFilesTickets: 'UpdateFilesTicketsDespe',
				setFile: 'SetFileDespe'
			}
		})

		/** The primary key. */
		this.ValCoddespe = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCoddespe',
			originId: 'ValCoddespe',
			area: 'EXPEN',
			field: 'CODDESPE',
			description: '',
		}).cloneFrom(values?.ValCoddespe))
		this.stopWatchers.push(watch(() => this.ValCoddespe.value, (newValue, oldValue) => this.onUpdate('expen.coddespe', this.ValCoddespe, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodproje = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodproje',
			originId: 'ValCodproje',
			area: 'EXPEN',
			field: 'CODPROJE',
			relatedArea: 'PROJE',
			description: computed(() => this.Resources._PROJECT36907),
		}).cloneFrom(values?.ValCodproje))
		this.stopWatchers.push(watch(() => this.ValCodproje.value, (newValue, oldValue) => this.onUpdate('expen.codproje', this.ValCodproje, newValue, oldValue)))

		this.ValCodyear = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodyear',
			originId: 'ValCodyear',
			area: 'EXPEN',
			field: 'CODYEAR',
			relatedArea: 'YEAR',
			description: computed(() => this.Resources._ANO30092),
		}).cloneFrom(values?.ValCodyear))
		this.stopWatchers.push(watch(() => this.ValCodyear.value, (newValue, oldValue) => this.onUpdate('expen.codyear', this.ValCodyear, newValue, oldValue)))

		this.ValCodaggre = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodaggre',
			originId: 'ValCodaggre',
			area: 'EXPEN',
			field: 'CODAGGRE',
			relatedArea: 'AGREG',
			description: computed(() => this.Resources._AGREGADOR29397),
		}).cloneFrom(values?.ValCodaggre))
		this.stopWatchers.push(watch(() => this.ValCodaggre.value, (newValue, oldValue) => this.onUpdate('expen.codaggre', this.ValCodaggre, newValue, oldValue)))

		/** The remaining form fields. */
		this.TableProjeProjecto = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableProjeProjecto',
			originId: 'ValProjecto',
			area: 'PROJE',
			field: 'PROJECTO',
			maxLength: 50,
			description: computed(() => this.Resources.PROJECT37121),
		}).cloneFrom(values?.TableProjeProjecto))
		this.stopWatchers.push(watch(() => this.TableProjeProjecto.value, (newValue, oldValue) => this.onUpdate('proje.projecto', this.TableProjeProjecto, newValue, oldValue)))

		this.TableYearYear = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableYearYear',
			originId: 'ValYear',
			area: 'YEAR',
			field: 'YEAR',
			maxLength: 4,
			description: computed(() => this.Resources.YEAR61794),
		}).cloneFrom(values?.TableYearYear))
		this.stopWatchers.push(watch(() => this.TableYearYear.value, (newValue, oldValue) => this.onUpdate('year.year', this.TableYearYear, newValue, oldValue)))

		this.TableAgregValue = reactive(new modelFieldType.Number({
			type: 'Lookup',
			id: 'TableAgregValue',
			originId: 'ValValue',
			area: 'AGREG',
			field: 'VALUE',
			maxDigits: 7,
			decimalDigits: 2,
			description: computed(() => this.Resources.VALUE10285),
		}).cloneFrom(values?.TableAgregValue))
		this.stopWatchers.push(watch(() => this.TableAgregValue.value, (newValue, oldValue) => this.onUpdate('agreg.value', this.TableAgregValue, newValue, oldValue)))

		this.ValDescript = reactive(new modelFieldType.String({
			id: 'ValDescript',
			originId: 'ValDescript',
			area: 'EXPEN',
			field: 'DESCRIPT',
			maxLength: 85,
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescript))
		this.stopWatchers.push(watch(() => this.ValDescript.value, (newValue, oldValue) => this.onUpdate('expen.descript', this.ValDescript, newValue, oldValue)))

		this.ValValue = reactive(new modelFieldType.Number({
			id: 'ValValue',
			originId: 'ValValue',
			area: 'EXPEN',
			field: 'VALUE',
			maxDigits: 7,
			decimalDigits: 2,
			description: computed(() => this.Resources.VALUE10285),
		}).cloneFrom(values?.ValValue))
		this.stopWatchers.push(watch(() => this.ValValue.value, (newValue, oldValue) => this.onUpdate('expen.value', this.ValValue, newValue, oldValue)))

		this.ValPrevval = reactive(new modelFieldType.Number({
			id: 'ValPrevval',
			originId: 'ValPrevval',
			area: 'EXPEN',
			field: 'PREVVAL',
			maxDigits: 7,
			decimalDigits: 2,
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
				dependencyEvents: ['fieldChange:expen.yearprev'],
				isServerRecalc: true,
				isEmpty: qApi.emptyN,
			},
			description: computed(() => this.Resources.PREVIOUS_VALUE30042),
		}).cloneFrom(values?.ValPrevval))
		this.stopWatchers.push(watch(() => this.ValPrevval.value, (newValue, oldValue) => this.onUpdate('expen.prevval', this.ValPrevval, newValue, oldValue)))

		this.ValYearprev = reactive(new modelFieldType.Number({
			id: 'ValYearprev',
			originId: 'ValYearprev',
			area: 'EXPEN',
			field: 'YEARPREV',
			maxDigits: 4,
			decimalDigits: 0,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: [YEAR->YEARNUM]-1
					return this.YearValYearnum.value-1
				},
				dependencyEvents: ['fieldChange:year.yearnum'],
				isServerRecalc: false,
				isEmpty: qApi.emptyN,
			},
			description: computed(() => this.Resources.PREVIOUS_YEAR11345),
		}).cloneFrom(values?.ValYearprev))
		this.stopWatchers.push(watch(() => this.ValYearprev.value, (newValue, oldValue) => this.onUpdate('expen.yearprev', this.ValYearprev, newValue, oldValue)))

		/** The form fields used only in formulas. */
		this.YearValYearnum = reactive(new modelFieldType.Number({
			id: 'YearValYearnum',
			originId: 'ValYearnum',
			area: 'YEAR',
			field: 'YEARNUM',
			maxDigits: 4,
			decimalDigits: 0,
			isFixed: true,
			description: computed(() => this.Resources.YEAR__NUMBERS_29394),
		}).cloneFrom(values?.YearValYearnum))
		this.stopWatchers.push(watch(() => this.YearValYearnum.value, (newValue, oldValue) => this.onUpdate('year.yearnum', this.YearValYearnum, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormDespeViewModel instance.
	 * @returns {QFormDespeViewModel} A new instance of QFormDespeViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCoddespe'

	get QPrimaryKey() { return this.ValCoddespe.value }
	set QPrimaryKey(value) { this.ValCoddespe.updateValue(value) }
}
