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
			name: 'TPEQU',
			area: 'TPEQU',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_TPEQU',
				updateFilesTickets: 'UpdateFilesTicketsTPEQU'
			}
		})

		/** The primary key. */
		this.ValCodtpequ = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodtpequ',
			originId: 'ValCodtpequ',
			area: 'TPEQU',
			field: 'CODTPEQU',
			description: '',
		}).cloneFrom(values?.ValCodtpequ))
		watch(() => this.ValCodtpequ.value, (newValue, oldValue) => this.onUpdate('tpequ.codtpequ', this.ValCodtpequ, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodfamil = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodfamil',
			originId: 'ValCodfamil',
			area: 'TPEQU',
			field: 'CODFAMIL',
			relatedArea: 'FAMIL',
			description: '',
		}).cloneFrom(values?.ValCodfamil))
		watch(() => this.ValCodfamil.value, (newValue, oldValue) => this.onUpdate('tpequ.codfamil', this.ValCodfamil, newValue, oldValue))

		/** The remaining form fields. */
		this.TableFamilFamily = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableFamilFamily',
			originId: 'ValFamily',
			area: 'FAMIL',
			field: 'FAMILY',
			maxLength: 50,
			description: computed(() => this.Resources.EQUIPMENT_FAMILY41883),
		}).cloneFrom(values?.TableFamilFamily))
		watch(() => this.TableFamilFamily.value, (newValue, oldValue) => this.onUpdate('famil.family', this.TableFamilFamily, newValue, oldValue))

		this.ValTipoequi = reactive(new modelFieldType.String({
			id: 'ValTipoequi',
			originId: 'ValTipoequi',
			area: 'TPEQU',
			field: 'TIPOEQUI',
			maxLength: 50,
			description: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
		}).cloneFrom(values?.ValTipoequi))
		watch(() => this.ValTipoequi.value, (newValue, oldValue) => this.onUpdate('tpequ.tipoequi', this.ValTipoequi, newValue, oldValue))

		this.ValTpequcod = reactive(new modelFieldType.String({
			id: 'ValTpequcod',
			originId: 'ValTpequcod',
			area: 'TPEQU',
			field: 'TPEQUCOD',
			maxLength: 20,
			description: computed(() => this.Resources.CODE49225),
		}).cloneFrom(values?.ValTpequcod))
		watch(() => this.ValTpequcod.value, (newValue, oldValue) => this.onUpdate('tpequ.tpequcod', this.ValTpequcod, newValue, oldValue))

		this.ValNivel = reactive(new modelFieldType.Number({
			id: 'ValNivel',
			originId: 'ValNivel',
			area: 'TPEQU',
			field: 'NIVEL',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.LEVEL06184),
		}).cloneFrom(values?.ValNivel))
		watch(() => this.ValNivel.value, (newValue, oldValue) => this.onUpdate('tpequ.nivel', this.ValNivel, newValue, oldValue))

		this.ValKit = reactive(new modelFieldType.Boolean({
			id: 'ValKit',
			originId: 'ValKit',
			area: 'TPEQU',
			field: 'KIT',
			description: computed(() => this.Resources.KIT27179),
		}).cloneFrom(values?.ValKit))
		watch(() => this.ValKit.value, (newValue, oldValue) => this.onUpdate('tpequ.kit', this.ValKit, newValue, oldValue))

		this.ValPrecomax = reactive(new modelFieldType.Number({
			id: 'ValPrecomax',
			originId: 'ValPrecomax',
			area: 'TPEQU',
			field: 'PRECOMAX',
			maxDigits: 9,
			decimalDigits: 2,
			isFixed: true,
			description: computed(() => this.Resources.MAXIMUM_PRICE55489),
		}).cloneFrom(values?.ValPrecomax))
		watch(() => this.ValPrecomax.value, (newValue, oldValue) => this.onUpdate('tpequ.precomax', this.ValPrecomax, newValue, oldValue))

		this.ValBackcolo = reactive(new modelFieldType.String({
			id: 'ValBackcolo',
			originId: 'ValBackcolo',
			area: 'TPEQU',
			field: 'BACKCOLO',
			maxLength: 50,
			description: computed(() => this.Resources.BACKGROUND_COLOR47883),
		}).cloneFrom(values?.ValBackcolo))
		watch(() => this.ValBackcolo.value, (newValue, oldValue) => this.onUpdate('tpequ.backcolo', this.ValBackcolo, newValue, oldValue))

		this.ValCorletra = reactive(new modelFieldType.String({
			id: 'ValCorletra',
			originId: 'ValCorletra',
			area: 'TPEQU',
			field: 'CORLETRA',
			maxLength: 50,
			description: computed(() => this.Resources.LETTER_COLOR15736),
		}).cloneFrom(values?.ValCorletra))
		watch(() => this.ValCorletra.value, (newValue, oldValue) => this.onUpdate('tpequ.corletra', this.ValCorletra, newValue, oldValue))

		this.ValTpequpai = reactive(new modelFieldType.String({
			id: 'ValTpequpai',
			originId: 'ValTpequpai',
			area: 'TPEQU',
			field: 'TPEQUPAI',
			maxLength: 20,
			description: computed(() => this.Resources.DEPENDENT_ON28321),
		}).cloneFrom(values?.ValTpequpai))
		watch(() => this.ValTpequpai.value, (newValue, oldValue) => this.onUpdate('tpequ.tpequpai', this.ValTpequpai, newValue, oldValue))

		this.ValPrecoult = reactive(new modelFieldType.Number({
			id: 'ValPrecoult',
			originId: 'ValPrecoult',
			area: 'TPEQU',
			field: 'PRECOULT',
			maxDigits: 9,
			decimalDigits: 2,
			isFixed: true,
			description: computed(() => this.Resources.LAST_PRICE25852),
		}).cloneFrom(values?.ValPrecoult))
		watch(() => this.ValPrecoult.value, (newValue, oldValue) => this.onUpdate('tpequ.precoult', this.ValPrecoult, newValue, oldValue))

		this.ValSince = reactive(new modelFieldType.DateTime({
			id: 'ValSince',
			originId: 'ValSince',
			area: 'TPEQU',
			field: 'SINCE',
			isFixed: true,
			description: computed(() => this.Resources.SINCE47259),
		}).cloneFrom(values?.ValSince))
		watch(() => this.ValSince.value, (newValue, oldValue) => this.onUpdate('tpequ.since', this.ValSince, newValue, oldValue))

		this.ValQtdequip = reactive(new modelFieldType.Number({
			id: 'ValQtdequip',
			originId: 'ValQtdequip',
			area: 'TPEQU',
			field: 'QTDEQUIP',
			maxDigits: 6,
			decimalDigits: 0,
			isFixed: true,
			description: computed(() => this.Resources.AMOUNT46885),
		}).cloneFrom(values?.ValQtdequip))
		watch(() => this.ValQtdequip.value, (newValue, oldValue) => this.onUpdate('tpequ.qtdequip', this.ValQtdequip, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormTpequViewModel instance.
	 * @returns {QFormTpequViewModel} A new instance of QFormTpequViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodtpequ'

	get QPrimaryKey() { return this.ValCodtpequ.value }
	set QPrimaryKey(value) { this.ValCodtpequ.updateValue(value) }
}
