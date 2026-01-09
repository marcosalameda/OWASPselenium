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
			name: 'LNHAG',
			area: 'LNHAG',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Lnhag',
				updateFilesTickets: 'UpdateFilesTicketsLnhag',
				setFile: 'SetFileLnhag'
			}
		})

		/** The primary key. */
		this.ValCodlnhag = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodlnhag',
			originId: 'ValCodlnhag',
			area: 'LNHAG',
			field: 'CODLNHAG',
			description: '',
		}).cloneFrom(values?.ValCodlnhag))
		this.stopWatchers.push(watch(() => this.ValCodlnhag.value, (newValue, oldValue) => this.onUpdate('lnhag.codlnhag', this.ValCodlnhag, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodpedid = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpedid',
			originId: 'ValCodpedid',
			area: 'LNHAG',
			field: 'CODPEDID',
			relatedArea: 'PEDID',
			description: '',
		}).cloneFrom(values?.ValCodpedid))
		this.stopWatchers.push(watch(() => this.ValCodpedid.value, (newValue, oldValue) => this.onUpdate('lnhag.codpedid', this.ValCodpedid, newValue, oldValue)))

		this.ValCodtpequ = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodtpequ',
			originId: 'ValCodtpequ',
			area: 'LNHAG',
			field: 'CODTPEQU',
			relatedArea: 'TPEQ1',
			description: '',
		}).cloneFrom(values?.ValCodtpequ))
		this.stopWatchers.push(watch(() => this.ValCodtpequ.value, (newValue, oldValue) => this.onUpdate('lnhag.codtpequ', this.ValCodtpequ, newValue, oldValue)))

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

		this.TableTpeq1Tipoequi = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableTpeq1Tipoequi',
			originId: 'ValTipoequi',
			area: 'TPEQ1',
			field: 'TIPOEQUI',
			maxLength: 50,
			description: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
		}).cloneFrom(values?.TableTpeq1Tipoequi))
		this.stopWatchers.push(watch(() => this.TableTpeq1Tipoequi.value, (newValue, oldValue) => this.onUpdate('tpeq1.tipoequi', this.TableTpeq1Tipoequi, newValue, oldValue)))

		this.ValQtdtpequ = reactive(new modelFieldType.Number({
			id: 'ValQtdtpequ',
			originId: 'ValQtdtpequ',
			area: 'LNHAG',
			field: 'QTDTPEQU',
			maxDigits: 6,
			decimalDigits: 0,
			isFixed: true,
			description: computed(() => this.Resources.AMOUNT46885),
		}).cloneFrom(values?.ValQtdtpequ))
		this.stopWatchers.push(watch(() => this.ValQtdtpequ.value, (newValue, oldValue) => this.onUpdate('lnhag.qtdtpequ', this.ValQtdtpequ, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormLnhagViewModel instance.
	 * @returns {QFormLnhagViewModel} A new instance of QFormLnhagViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodlnhag'

	get QPrimaryKey() { return this.ValCodlnhag.value }
	set QPrimaryKey(value) { this.ValCodlnhag.updateValue(value) }
}
