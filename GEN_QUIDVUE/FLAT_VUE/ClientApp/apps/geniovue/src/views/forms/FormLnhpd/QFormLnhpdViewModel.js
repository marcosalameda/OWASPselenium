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
			name: 'LNHPD',
			area: 'LNHPD',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Lnhpd',
				updateFilesTickets: 'UpdateFilesTicketsLnhpd',
				setFile: 'SetFileLnhpd'
			}
		})

		/** The primary key. */
		this.ValCodlnhpd = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodlnhpd',
			originId: 'ValCodlnhpd',
			area: 'LNHPD',
			field: 'CODLNHPD',
			description: '',
		}).cloneFrom(values?.ValCodlnhpd))
		this.stopWatchers.push(watch(() => this.ValCodlnhpd.value, (newValue, oldValue) => this.onUpdate('lnhpd.codlnhpd', this.ValCodlnhpd, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodpedid = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpedid',
			originId: 'ValCodpedid',
			area: 'LNHPD',
			field: 'CODPEDID',
			relatedArea: 'PEDID',
			description: '',
		}).cloneFrom(values?.ValCodpedid))
		this.stopWatchers.push(watch(() => this.ValCodpedid.value, (newValue, oldValue) => this.onUpdate('lnhpd.codpedid', this.ValCodpedid, newValue, oldValue)))

		this.ValCodtpequ = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodtpequ',
			originId: 'ValCodtpequ',
			area: 'LNHPD',
			field: 'CODTPEQU',
			relatedArea: 'TPEQU',
			description: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
		}).cloneFrom(values?.ValCodtpequ))
		this.stopWatchers.push(watch(() => this.ValCodtpequ.value, (newValue, oldValue) => this.onUpdate('lnhpd.codtpequ', this.ValCodtpequ, newValue, oldValue)))

		/** The remaining form fields. */
		this.TablePedidNrpedido = reactive(new modelFieldType.Number({
			type: 'Lookup',
			id: 'TablePedidNrpedido',
			originId: 'ValNrpedido',
			area: 'PEDID',
			field: 'NRPEDIDO',
			maxDigits: 6,
			decimalDigits: 0,
			description: computed(() => this.Resources.NO_14817),
		}).cloneFrom(values?.TablePedidNrpedido))
		this.stopWatchers.push(watch(() => this.TablePedidNrpedido.value, (newValue, oldValue) => this.onUpdate('pedid.nrpedido', this.TablePedidNrpedido, newValue, oldValue)))

		this.ValLine = reactive(new modelFieldType.Number({
			id: 'ValLine',
			originId: 'ValLine',
			area: 'LNHPD',
			field: 'LINE',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.LINE27983),
		}).cloneFrom(values?.ValLine))
		this.stopWatchers.push(watch(() => this.ValLine.value, (newValue, oldValue) => this.onUpdate('lnhpd.line', this.ValLine, newValue, oldValue)))

		this.TableTpequTipoequi = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableTpequTipoequi',
			originId: 'ValTipoequi',
			area: 'TPEQU',
			field: 'TIPOEQUI',
			maxLength: 50,
			description: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
		}).cloneFrom(values?.TableTpequTipoequi))
		this.stopWatchers.push(watch(() => this.TableTpequTipoequi.value, (newValue, oldValue) => this.onUpdate('tpequ.tipoequi', this.TableTpequTipoequi, newValue, oldValue)))

		this.ValQuantida = reactive(new modelFieldType.Number({
			id: 'ValQuantida',
			originId: 'ValQuantida',
			area: 'LNHPD',
			field: 'QUANTIDA',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.AMOUNT46885),
		}).cloneFrom(values?.ValQuantida))
		this.stopWatchers.push(watch(() => this.ValQuantida.value, (newValue, oldValue) => this.onUpdate('lnhpd.quantida', this.ValQuantida, newValue, oldValue)))

		this.ValQuantdec = reactive(new modelFieldType.Number({
			id: 'ValQuantdec',
			originId: 'ValQuantdec',
			area: 'LNHPD',
			field: 'QUANTDEC',
			maxDigits: 7,
			decimalDigits: 2,
			description: computed(() => this.Resources.AMOUNT46885),
		}).cloneFrom(values?.ValQuantdec))
		this.stopWatchers.push(watch(() => this.ValQuantdec.value, (newValue, oldValue) => this.onUpdate('lnhpd.quantdec', this.ValQuantdec, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormLnhpdViewModel instance.
	 * @returns {QFormLnhpdViewModel} A new instance of QFormLnhpdViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodlnhpd'

	get QPrimaryKey() { return this.ValCodlnhpd.value }
	set QPrimaryKey(value) { this.ValCodlnhpd.updateValue(value) }
}
