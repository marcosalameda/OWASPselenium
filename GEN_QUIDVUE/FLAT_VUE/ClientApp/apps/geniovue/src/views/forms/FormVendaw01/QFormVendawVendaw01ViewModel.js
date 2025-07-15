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
			name: 'VENDAW01',
			area: 'SALE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Vendaw01',
				updateFilesTickets: 'UpdateFilesTicketsVendaw01',
				setFile: 'SetFileVendaw01'
			}
		})

		/** The primary key. */
		this.ValCodvenda = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodvenda',
			originId: 'ValCodvenda',
			area: 'SALE',
			field: 'CODVENDA',
			description: '',
		}).cloneFrom(values?.ValCodvenda))
		this.stopWatchers.push(watch(() => this.ValCodvenda.value, (newValue, oldValue) => this.onUpdate('sale.codvenda', this.ValCodvenda, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodorgan = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodorgan',
			originId: 'ValCodorgan',
			area: 'SALE',
			field: 'CODORGAN',
			relatedArea: 'ORGAN',
			description: '',
		}).cloneFrom(values?.ValCodorgan))
		this.stopWatchers.push(watch(() => this.ValCodorgan.value, (newValue, oldValue) => this.onUpdate('sale.codorgan', this.ValCodorgan, newValue, oldValue)))

		/** The remaining form fields. */
		this.TableOrganOrganiza = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableOrganOrganiza',
			originId: 'ValOrganiza',
			area: 'ORGAN',
			field: 'ORGANIZA',
			maxLength: 85,
			description: computed(() => this.Resources.ORGANIZATION64123),
		}).cloneFrom(values?.TableOrganOrganiza))
		this.stopWatchers.push(watch(() => this.TableOrganOrganiza.value, (newValue, oldValue) => this.onUpdate('organ.organiza', this.TableOrganOrganiza, newValue, oldValue)))

		this.ValIdentifi = reactive(new modelFieldType.String({
			id: 'ValIdentifi',
			originId: 'ValIdentifi',
			area: 'SALE',
			field: 'IDENTIFI',
			maxLength: 85,
			description: computed(() => this.Resources.IDENTIFICATION_OF_BU58085),
		}).cloneFrom(values?.ValIdentifi))
		this.stopWatchers.push(watch(() => this.ValIdentifi.value, (newValue, oldValue) => this.onUpdate('sale.identifi', this.ValIdentifi, newValue, oldValue)))

		this.ValPotcompr = reactive(new modelFieldType.String({
			id: 'ValPotcompr',
			originId: 'ValPotcompr',
			area: 'SALE',
			field: 'POTCOMPR',
			maxLength: 50,
			description: computed(() => this.Resources.POTENTIAL_BUYERS56564),
		}).cloneFrom(values?.ValPotcompr))
		this.stopWatchers.push(watch(() => this.ValPotcompr.value, (newValue, oldValue) => this.onUpdate('sale.potcompr', this.ValPotcompr, newValue, oldValue)))

		this.ValProspecc = reactive(new modelFieldType.Boolean({
			id: 'ValProspecc',
			originId: 'ValProspecc',
			area: 'SALE',
			field: 'PROSPECC',
			description: computed(() => this.Resources.PROSPECTING_CARRIED_08979),
		}).cloneFrom(values?.ValProspecc))
		this.stopWatchers.push(watch(() => this.ValProspecc.value, (newValue, oldValue) => this.onUpdate('sale.prospecc', this.ValProspecc, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormVendawVendaw01ViewModel instance.
	 * @returns {QFormVendawVendaw01ViewModel} A new instance of QFormVendawVendaw01ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodvenda'

	get QPrimaryKey() { return this.ValCodvenda.value }
	set QPrimaryKey(value) { this.ValCodvenda.updateValue(value) }
}
