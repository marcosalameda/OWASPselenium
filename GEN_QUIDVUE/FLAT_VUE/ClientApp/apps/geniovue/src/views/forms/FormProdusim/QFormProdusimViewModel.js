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
			name: 'PRODUSIM',
			area: 'PRODU',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Produsim',
				updateFilesTickets: 'UpdateFilesTicketsProdusim',
				setFile: 'SetFileProdusim'
			}
		})

		/** The primary key. */
		this.ValCodprodu = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodprodu',
			originId: 'ValCodprodu',
			area: 'PRODU',
			field: 'CODPRODU',
			description: '',
		}).cloneFrom(values?.ValCodprodu))
		this.stopWatchers.push(watch(() => this.ValCodprodu.value, (newValue, oldValue) => this.onUpdate('produ.codprodu', this.ValCodprodu, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodlocat = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodlocat',
			originId: 'ValCodlocat',
			area: 'PRODU',
			field: 'CODLOCAT',
			relatedArea: 'LOCAT',
			description: computed(() => this.Resources.__LOCATION45198),
		}).cloneFrom(values?.ValCodlocat))
		this.stopWatchers.push(watch(() => this.ValCodlocat.value, (newValue, oldValue) => this.onUpdate('produ.codlocat', this.ValCodlocat, newValue, oldValue)))

		this.ValCodlcext = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodlcext',
			originId: 'ValCodlcext',
			area: 'PRODU',
			field: 'CODLCEXT',
			relatedArea: 'LCEXT',
			description: computed(() => this.Resources.__LOCATION_EXTENSION43450),
		}).cloneFrom(values?.ValCodlcext))
		this.stopWatchers.push(watch(() => this.ValCodlcext.value, (newValue, oldValue) => this.onUpdate('produ.codlcext', this.ValCodlcext, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValProduct = reactive(new modelFieldType.String({
			id: 'ValProduct',
			originId: 'ValProduct',
			area: 'PRODU',
			field: 'PRODUCT',
			maxLength: 85,
			description: computed(() => this.Resources.PRODUCT12880),
		}).cloneFrom(values?.ValProduct))
		this.stopWatchers.push(watch(() => this.ValProduct.value, (newValue, oldValue) => this.onUpdate('produ.product', this.ValProduct, newValue, oldValue)))

		this.ValDescript = reactive(new modelFieldType.MultiLineString({
			id: 'ValDescript',
			originId: 'ValDescript',
			area: 'PRODU',
			field: 'DESCRIPT',
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescript))
		this.stopWatchers.push(watch(() => this.ValDescript.value, (newValue, oldValue) => this.onUpdate('produ.descript', this.ValDescript, newValue, oldValue)))

		this.ValSku = reactive(new modelFieldType.String({
			id: 'ValSku',
			originId: 'ValSku',
			area: 'PRODU',
			field: 'SKU',
			maxLength: 20,
			description: computed(() => this.Resources.SKU42303),
		}).cloneFrom(values?.ValSku))
		this.stopWatchers.push(watch(() => this.ValSku.value, (newValue, oldValue) => this.onUpdate('produ.sku', this.ValSku, newValue, oldValue)))

		this.ValGtin = reactive(new modelFieldType.String({
			id: 'ValGtin',
			originId: 'ValGtin',
			area: 'PRODU',
			field: 'GTIN',
			maxLength: 14,
			description: computed(() => this.Resources.GTIN45487),
		}).cloneFrom(values?.ValGtin))
		this.stopWatchers.push(watch(() => this.ValGtin.value, (newValue, oldValue) => this.onUpdate('produ.gtin', this.ValGtin, newValue, oldValue)))

		this.ValSize = reactive(new modelFieldType.String({
			id: 'ValSize',
			originId: 'ValSize',
			area: 'PRODU',
			field: 'SIZE',
			maxLength: 50,
			description: computed(() => this.Resources.SIZE10299),
		}).cloneFrom(values?.ValSize))
		this.stopWatchers.push(watch(() => this.ValSize.value, (newValue, oldValue) => this.onUpdate('produ.size', this.ValSize, newValue, oldValue)))

		this.ValWeight = reactive(new modelFieldType.Number({
			id: 'ValWeight',
			originId: 'ValWeight',
			area: 'PRODU',
			field: 'WEIGHT',
			maxDigits: 7,
			decimalDigits: 2,
			description: computed(() => this.Resources.WEIGHT36329),
		}).cloneFrom(values?.ValWeight))
		this.stopWatchers.push(watch(() => this.ValWeight.value, (newValue, oldValue) => this.onUpdate('produ.weight', this.ValWeight, newValue, oldValue)))

		this.TableLocatGln = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableLocatGln',
			originId: 'ValGln',
			area: 'LOCAT',
			field: 'GLN',
			maxLength: 50,
			description: computed(() => this.Resources.GLOBAL_LOCATION_NUMB24637),
		}).cloneFrom(values?.TableLocatGln))
		this.stopWatchers.push(watch(() => this.TableLocatGln.value, (newValue, oldValue) => this.onUpdate('locat.gln', this.TableLocatGln, newValue, oldValue)))

		this.TableLcextGlnext = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableLcextGlnext',
			originId: 'ValGlnext',
			area: 'LCEXT',
			field: 'GLNEXT',
			maxLength: 50,
			description: computed(() => this.Resources.GLN_EXTENSION_COMPON55869),
		}).cloneFrom(values?.TableLcextGlnext))
		this.stopWatchers.push(watch(() => this.TableLcextGlnext.value, (newValue, oldValue) => this.onUpdate('lcext.glnext', this.TableLcextGlnext, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormProdusimViewModel instance.
	 * @returns {QFormProdusimViewModel} A new instance of QFormProdusimViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodprodu'

	get QPrimaryKey() { return this.ValCodprodu.value }
	set QPrimaryKey(value) { this.ValCodprodu.updateValue(value) }
}
