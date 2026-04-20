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
			name: 'TABPR',
			area: 'TABPR',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Tabpr',
				updateFilesTickets: 'UpdateFilesTicketsTabpr',
				setFile: 'SetFileTabpr'
			}
		})

		/** The primary key. */
		this.ValCodtabpr = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodtabpr',
			originId: 'ValCodtabpr',
			area: 'TABPR',
			field: 'CODTABPR',
			description: '',
		}).cloneFrom(values?.ValCodtabpr))
		this.stopWatchers.push(watch(() => this.ValCodtabpr.value, (newValue, oldValue) => this.onUpdate('tabpr.codtabpr', this.ValCodtabpr, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodtpeq1 = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodtpeq1',
			originId: 'ValCodtpeq1',
			area: 'TABPR',
			field: 'CODTPEQ1',
			relatedArea: 'TPEQU',
			description: computed(() => this.Resources._TYPE_OF_EQUIPMENT35057),
		}).cloneFrom(values?.ValCodtpeq1))
		this.stopWatchers.push(watch(() => this.ValCodtpeq1.value, (newValue, oldValue) => this.onUpdate('tabpr.codtpeq1', this.ValCodtpeq1, newValue, oldValue)))

		/** The remaining form fields. */
		this.TableTpequTipoequi = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableTpequTipoequi',
			originId: 'ValTipoequi',
			area: 'TPEQU',
			field: 'TIPOEQUI',
			maxLength: 50,
			description: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableTpequTipoequi))
		this.stopWatchers.push(watch(() => this.TableTpequTipoequi.value, (newValue, oldValue) => this.onUpdate('tpequ.tipoequi', this.TableTpequTipoequi, newValue, oldValue)))

		this.ValSince = reactive(new modelFieldType.DateTime({
			id: 'ValSince',
			originId: 'ValSince',
			area: 'TABPR',
			field: 'SINCE',
			description: computed(() => this.Resources.SINCE47259),
		}).cloneFrom(values?.ValSince))
		this.stopWatchers.push(watch(() => this.ValSince.value, (newValue, oldValue) => this.onUpdate('tabpr.since', this.ValSince, newValue, oldValue)))

		this.ValPrecohor = reactive(new modelFieldType.Number({
			id: 'ValPrecohor',
			originId: 'ValPrecohor',
			area: 'TABPR',
			field: 'PRECOHOR',
			maxDigits: 9,
			decimalDigits: 2,
			description: computed(() => this.Resources.PRICE_BY_HOUR01060),
		}).cloneFrom(values?.ValPrecohor))
		this.stopWatchers.push(watch(() => this.ValPrecohor.value, (newValue, oldValue) => this.onUpdate('tabpr.precohor', this.ValPrecohor, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormTabprViewModel instance.
	 * @returns {QFormTabprViewModel} A new instance of QFormTabprViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodtabpr'

	get QPrimaryKey() { return this.ValCodtabpr.value }
	set QPrimaryKey(value) { this.ValCodtabpr.updateValue(value) }
}
