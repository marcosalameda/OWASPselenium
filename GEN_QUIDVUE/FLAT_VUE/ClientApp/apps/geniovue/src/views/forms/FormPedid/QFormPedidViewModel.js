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
			name: 'PEDID',
			area: 'PEDID',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Pedid',
				updateFilesTickets: 'UpdateFilesTicketsPedid',
				setFile: 'SetFilePedid'
			}
		})

		/** The primary key. */
		this.ValCodpedid = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodpedid',
			originId: 'ValCodpedid',
			area: 'PEDID',
			field: 'CODPEDID',
			description: '',
		}).cloneFrom(values?.ValCodpedid))
		this.stopWatchers.push(watch(() => this.ValCodpedid.value, (newValue, oldValue) => this.onUpdate('pedid.codpedid', this.ValCodpedid, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValDtpedido = reactive(new modelFieldType.Date({
			id: 'ValDtpedido',
			originId: 'ValDtpedido',
			area: 'PEDID',
			field: 'DTPEDIDO',
			description: computed(() => this.Resources.DATE18475),
		}).cloneFrom(values?.ValDtpedido))
		this.stopWatchers.push(watch(() => this.ValDtpedido.value, (newValue, oldValue) => this.onUpdate('pedid.dtpedido', this.ValDtpedido, newValue, oldValue)))

		this.ValNrpedido = reactive(new modelFieldType.Number({
			id: 'ValNrpedido',
			originId: 'ValNrpedido',
			area: 'PEDID',
			field: 'NRPEDIDO',
			maxDigits: 6,
			decimalDigits: 0,
			description: computed(() => this.Resources.NO_14817),
		}).cloneFrom(values?.ValNrpedido))
		this.stopWatchers.push(watch(() => this.ValNrpedido.value, (newValue, oldValue) => this.onUpdate('pedid.nrpedido', this.ValNrpedido, newValue, oldValue)))

		this.ValMotivo = reactive(new modelFieldType.MultiLineString({
			id: 'ValMotivo',
			originId: 'ValMotivo',
			area: 'PEDID',
			field: 'MOTIVO',
			description: computed(() => this.Resources.REASON00008),
		}).cloneFrom(values?.ValMotivo))
		this.stopWatchers.push(watch(() => this.ValMotivo.value, (newValue, oldValue) => this.onUpdate('pedid.motivo', this.ValMotivo, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormPedidViewModel instance.
	 * @returns {QFormPedidViewModel} A new instance of QFormPedidViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodpedid'

	get QPrimaryKey() { return this.ValCodpedid.value }
	set QPrimaryKey(value) { this.ValCodpedid.updateValue(value) }
}
