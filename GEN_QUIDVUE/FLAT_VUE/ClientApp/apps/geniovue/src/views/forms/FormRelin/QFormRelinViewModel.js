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
			name: 'RELIN',
			area: 'RELIN',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_RELIN'
			}
		})

		/** The primary key. */
		this.ValCoddilin = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCoddilin',
			originId: 'ValCoddilin',
			area: 'RELIN',
			field: 'CODDILIN',
			description: '',
		}).cloneFrom(values?.ValCoddilin))
		watch(() => this.ValCoddilin.value, (newValue, oldValue) => this.onUpdate('relin.coddilin', this.ValCoddilin, newValue, oldValue))

		/** The hidden foreign keys. */
		this.ValCodentit = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodentit',
			originId: 'ValCodentit',
			area: 'RELIN',
			field: 'CODENTIT',
			relatedArea: 'ENTIT',
			isFixed: true,
			description: computed(() => this.Resources.__SUPPLIER62145),
		}).cloneFrom(values?.ValCodentit))
		watch(() => this.ValCodentit.value, (newValue, oldValue) => this.onUpdate('relin.codentit', this.ValCodentit, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodrecei = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodrecei',
			originId: 'ValCodrecei',
			area: 'RELIN',
			field: 'CODRECEI',
			relatedArea: 'RECEI',
			description: computed(() => this.Resources.__RECEIPT04632),
		}).cloneFrom(values?.ValCodrecei))
		watch(() => this.ValCodrecei.value, (newValue, oldValue) => this.onUpdate('relin.codrecei', this.ValCodrecei, newValue, oldValue))

		this.ValCodprodu = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodprodu',
			originId: 'ValCodprodu',
			area: 'RELIN',
			field: 'CODPRODU',
			relatedArea: 'PRODU',
			description: computed(() => this.Resources.__PRODUCT04710),
		}).cloneFrom(values?.ValCodprodu))
		watch(() => this.ValCodprodu.value, (newValue, oldValue) => this.onUpdate('relin.codprodu', this.ValCodprodu, newValue, oldValue))

		/** The remaining form fields. */
		this.TableReceiNumber = reactive(new modelFieldType.Number({
			type: 'Lookup',
			id: 'TableReceiNumber',
			originId: 'ValNumber',
			area: 'RECEI',
			field: 'NUMBER',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.RECEIPT_NUMBER31380),
		}).cloneFrom(values?.TableReceiNumber))
		watch(() => this.TableReceiNumber.value, (newValue, oldValue) => this.onUpdate('recei.number', this.TableReceiNumber, newValue, oldValue))

		this.EntitValName = reactive(new modelFieldType.String({
			id: 'EntitValName',
			originId: 'ValName',
			area: 'ENTIT',
			field: 'NAME',
			maxLength: 85,
			isFixed: true,
			description: computed(() => this.Resources.LEGAL_NAME42902),
		}).cloneFrom(values?.EntitValName))
		watch(() => this.EntitValName.value, (newValue, oldValue) => this.onUpdate('entit.name', this.EntitValName, newValue, oldValue))

		this.ValLinenumb = reactive(new modelFieldType.Number({
			id: 'ValLinenumb',
			originId: 'ValLinenumb',
			area: 'RELIN',
			field: 'LINENUMB',
			maxDigits: 6,
			decimalDigits: 0,
			description: computed(() => this.Resources.LINE27983),
		}).cloneFrom(values?.ValLinenumb))
		watch(() => this.ValLinenumb.value, (newValue, oldValue) => this.onUpdate('relin.linenumb', this.ValLinenumb, newValue, oldValue))

		this.TableProduProduct = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableProduProduct',
			originId: 'ValProduct',
			area: 'PRODU',
			field: 'PRODUCT',
			maxLength: 85,
			description: computed(() => this.Resources.PRODUCT12880),
		}).cloneFrom(values?.TableProduProduct))
		watch(() => this.TableProduProduct.value, (newValue, oldValue) => this.onUpdate('produ.product', this.TableProduProduct, newValue, oldValue))

		this.ValOrdered = reactive(new modelFieldType.Number({
			id: 'ValOrdered',
			originId: 'ValOrdered',
			area: 'RELIN',
			field: 'ORDERED',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.ORDERED04034),
		}).cloneFrom(values?.ValOrdered))
		watch(() => this.ValOrdered.value, (newValue, oldValue) => this.onUpdate('relin.ordered', this.ValOrdered, newValue, oldValue))

		this.ValReceived = reactive(new modelFieldType.Number({
			id: 'ValReceived',
			originId: 'ValReceived',
			area: 'RELIN',
			field: 'RECEIVED',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.RECEIVED19242),
		}).cloneFrom(values?.ValReceived))
		watch(() => this.ValReceived.value, (newValue, oldValue) => this.onUpdate('relin.received', this.ValReceived, newValue, oldValue))

		this.ValOutstand = reactive(new modelFieldType.Number({
			id: 'ValOutstand',
			originId: 'ValOutstand',
			area: 'RELIN',
			field: 'OUTSTAND',
			maxDigits: 10,
			decimalDigits: 0,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: [RELIN->ORDERED]-[RELIN->RECEIVED]
					return this.ValOrdered.value-this.ValReceived.value
				},
				dependencyEvents: ['fieldChange:relin.ordered', 'fieldChange:relin.received'],
				isServerRecalc: false,
				isEmpty: qApi.emptyN,
			},
			description: computed(() => this.Resources.OUTSTANDING36400),
		}).cloneFrom(values?.ValOutstand))
		watch(() => this.ValOutstand.value, (newValue, oldValue) => this.onUpdate('relin.outstand', this.ValOutstand, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormRelinViewModel instance.
	 * @returns {QFormRelinViewModel} A new instance of QFormRelinViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCoddilin'

	get QPrimaryKey() { return this.ValCoddilin.value }
	set QPrimaryKey(value) { this.ValCoddilin.updateValue(value) }
}
