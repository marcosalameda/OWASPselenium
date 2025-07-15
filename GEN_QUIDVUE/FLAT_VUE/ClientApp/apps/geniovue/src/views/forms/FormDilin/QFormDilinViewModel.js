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
			name: 'DILIN',
			area: 'DILIN',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Dilin',
				updateFilesTickets: 'UpdateFilesTicketsDilin',
				setFile: 'SetFileDilin'
			}
		})

		/** The primary key. */
		this.ValCoddilin = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCoddilin',
			originId: 'ValCoddilin',
			area: 'DILIN',
			field: 'CODDILIN',
			description: '',
		}).cloneFrom(values?.ValCoddilin))
		this.stopWatchers.push(watch(() => this.ValCoddilin.value, (newValue, oldValue) => this.onUpdate('dilin.coddilin', this.ValCoddilin, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCoddispa = reactive(new modelFieldType.ForeignKey({
			id: 'ValCoddispa',
			originId: 'ValCoddispa',
			area: 'DILIN',
			field: 'CODDISPA',
			relatedArea: 'DISPA',
			description: computed(() => this.Resources.__DISPATCH53890),
		}).cloneFrom(values?.ValCoddispa))
		this.stopWatchers.push(watch(() => this.ValCoddispa.value, (newValue, oldValue) => this.onUpdate('dilin.coddispa', this.ValCoddispa, newValue, oldValue)))

		this.ValCodprodu = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodprodu',
			originId: 'ValCodprodu',
			area: 'DILIN',
			field: 'CODPRODU',
			relatedArea: 'PRODU',
			description: computed(() => this.Resources.__PRODUCT04710),
		}).cloneFrom(values?.ValCodprodu))
		this.stopWatchers.push(watch(() => this.ValCodprodu.value, (newValue, oldValue) => this.onUpdate('dilin.codprodu', this.ValCodprodu, newValue, oldValue)))

		/** The remaining form fields. */
		this.TableDispaDispanr = reactive(new modelFieldType.Number({
			type: 'Lookup',
			id: 'TableDispaDispanr',
			originId: 'ValDispanr',
			area: 'DISPA',
			field: 'DISPANR',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.DISPATCH_NUMBER23616),
		}).cloneFrom(values?.TableDispaDispanr))
		this.stopWatchers.push(watch(() => this.TableDispaDispanr.value, (newValue, oldValue) => this.onUpdate('dispa.dispanr', this.TableDispaDispanr, newValue, oldValue)))

		this.ValLinenumb = reactive(new modelFieldType.Number({
			id: 'ValLinenumb',
			originId: 'ValLinenumb',
			area: 'DILIN',
			field: 'LINENUMB',
			maxDigits: 6,
			decimalDigits: 0,
			description: computed(() => this.Resources.LINE27983),
		}).cloneFrom(values?.ValLinenumb))
		this.stopWatchers.push(watch(() => this.ValLinenumb.value, (newValue, oldValue) => this.onUpdate('dilin.linenumb', this.ValLinenumb, newValue, oldValue)))

		this.TableProduProduct = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableProduProduct',
			originId: 'ValProduct',
			area: 'PRODU',
			field: 'PRODUCT',
			maxLength: 85,
			description: computed(() => this.Resources.PRODUCT12880),
		}).cloneFrom(values?.TableProduProduct))
		this.stopWatchers.push(watch(() => this.TableProduProduct.value, (newValue, oldValue) => this.onUpdate('produ.product', this.TableProduProduct, newValue, oldValue)))

		this.ValOrdered = reactive(new modelFieldType.Number({
			id: 'ValOrdered',
			originId: 'ValOrdered',
			area: 'DILIN',
			field: 'ORDERED',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.ORDERED04034),
		}).cloneFrom(values?.ValOrdered))
		this.stopWatchers.push(watch(() => this.ValOrdered.value, (newValue, oldValue) => this.onUpdate('dilin.ordered', this.ValOrdered, newValue, oldValue)))

		this.ValDelivere = reactive(new modelFieldType.Number({
			id: 'ValDelivere',
			originId: 'ValDelivere',
			area: 'DILIN',
			field: 'DELIVERE',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.DELIVERED26597),
		}).cloneFrom(values?.ValDelivere))
		this.stopWatchers.push(watch(() => this.ValDelivere.value, (newValue, oldValue) => this.onUpdate('dilin.delivere', this.ValDelivere, newValue, oldValue)))

		this.ValOutstand = reactive(new modelFieldType.Number({
			id: 'ValOutstand',
			originId: 'ValOutstand',
			area: 'DILIN',
			field: 'OUTSTAND',
			maxDigits: 10,
			decimalDigits: 0,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: [DILIN->ORDERED]-[DILIN->DELIVERE]
					return this.ValOrdered.value-this.ValDelivere.value
				},
				dependencyEvents: ['fieldChange:dilin.ordered', 'fieldChange:dilin.delivere'],
				isServerRecalc: false,
				isEmpty: qApi.emptyN,
			},
			description: computed(() => this.Resources.OUTSTANDING36400),
		}).cloneFrom(values?.ValOutstand))
		this.stopWatchers.push(watch(() => this.ValOutstand.value, (newValue, oldValue) => this.onUpdate('dilin.outstand', this.ValOutstand, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormDilinViewModel instance.
	 * @returns {QFormDilinViewModel} A new instance of QFormDilinViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCoddilin'

	get QPrimaryKey() { return this.ValCoddilin.value }
	set QPrimaryKey(value) { this.ValCoddilin.updateValue(value) }
}
