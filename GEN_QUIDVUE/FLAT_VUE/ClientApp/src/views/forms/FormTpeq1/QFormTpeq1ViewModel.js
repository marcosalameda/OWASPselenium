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
			name: 'TPEQ1',
			area: 'TPEQ1',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_TPEQ1'
			}
		})

		/** The primary key. */
		this.ValCodtpequ = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodtpequ',
			originId: 'ValCodtpequ',
			area: 'TPEQ1',
			field: 'CODTPEQU',
			description: '',
		}).cloneFrom(values?.ValCodtpequ))
		watch(() => this.ValCodtpequ.value, (newValue, oldValue) => this.onUpdate('tpeq1.codtpequ', this.ValCodtpequ, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodfamil = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodfamil',
			originId: 'ValCodfamil',
			area: 'TPEQ1',
			field: 'CODFAMIL',
			relatedArea: 'FAMI1',
			description: '',
		}).cloneFrom(values?.ValCodfamil))
		watch(() => this.ValCodfamil.value, (newValue, oldValue) => this.onUpdate('tpeq1.codfamil', this.ValCodfamil, newValue, oldValue))

		/** The remaining form fields. */
		this.TableFami1Family = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableFami1Family',
			originId: 'ValFamily',
			area: 'FAMI1',
			field: 'FAMILY',
			maxLength: 50,
			description: computed(() => this.Resources.EQUIPMENT_FAMILY41883),
		}).cloneFrom(values?.TableFami1Family))
		watch(() => this.TableFami1Family.value, (newValue, oldValue) => this.onUpdate('fami1.family', this.TableFami1Family, newValue, oldValue))

		this.ValTpequcod = reactive(new modelFieldType.String({
			id: 'ValTpequcod',
			originId: 'ValTpequcod',
			area: 'TPEQ1',
			field: 'TPEQUCOD',
			maxLength: 20,
			description: computed(() => this.Resources.CODE49225),
		}).cloneFrom(values?.ValTpequcod))
		watch(() => this.ValTpequcod.value, (newValue, oldValue) => this.onUpdate('tpeq1.tpequcod', this.ValTpequcod, newValue, oldValue))

		this.ValNivel = reactive(new modelFieldType.Number({
			id: 'ValNivel',
			originId: 'ValNivel',
			area: 'TPEQ1',
			field: 'NIVEL',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.LEVEL06184),
		}).cloneFrom(values?.ValNivel))
		watch(() => this.ValNivel.value, (newValue, oldValue) => this.onUpdate('tpeq1.nivel', this.ValNivel, newValue, oldValue))

		this.ValTipoequi = reactive(new modelFieldType.String({
			id: 'ValTipoequi',
			originId: 'ValTipoequi',
			area: 'TPEQ1',
			field: 'TIPOEQUI',
			maxLength: 50,
			description: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
		}).cloneFrom(values?.ValTipoequi))
		watch(() => this.ValTipoequi.value, (newValue, oldValue) => this.onUpdate('tpeq1.tipoequi', this.ValTipoequi, newValue, oldValue))

		this.ValTpequpai = reactive(new modelFieldType.String({
			id: 'ValTpequpai',
			originId: 'ValTpequpai',
			area: 'TPEQ1',
			field: 'TPEQUPAI',
			maxLength: 20,
			description: computed(() => this.Resources.DEPENDENT_ON28321),
		}).cloneFrom(values?.ValTpequpai))
		watch(() => this.ValTpequpai.value, (newValue, oldValue) => this.onUpdate('tpeq1.tpequpai', this.ValTpequpai, newValue, oldValue))

		this.ValBackcolo = reactive(new modelFieldType.String({
			id: 'ValBackcolo',
			originId: 'ValBackcolo',
			area: 'TPEQ1',
			field: 'BACKCOLO',
			maxLength: 50,
			description: computed(() => this.Resources.BACKGROUND_COLOR47883),
		}).cloneFrom(values?.ValBackcolo))
		watch(() => this.ValBackcolo.value, (newValue, oldValue) => this.onUpdate('tpeq1.backcolo', this.ValBackcolo, newValue, oldValue))

		this.ValCorletra = reactive(new modelFieldType.String({
			id: 'ValCorletra',
			originId: 'ValCorletra',
			area: 'TPEQ1',
			field: 'CORLETRA',
			maxLength: 50,
			description: computed(() => this.Resources.LETTER_COLOR15736),
		}).cloneFrom(values?.ValCorletra))
		watch(() => this.ValCorletra.value, (newValue, oldValue) => this.onUpdate('tpeq1.corletra', this.ValCorletra, newValue, oldValue))

		this.ValPrecomax = reactive(new modelFieldType.Number({
			id: 'ValPrecomax',
			originId: 'ValPrecomax',
			area: 'TPEQ1',
			field: 'PRECOMAX',
			maxDigits: 9,
			decimalDigits: 2,
			description: computed(() => this.Resources.MAXIMUM_PRICE55489),
		}).cloneFrom(values?.ValPrecomax))
		watch(() => this.ValPrecomax.value, (newValue, oldValue) => this.onUpdate('tpeq1.precomax', this.ValPrecomax, newValue, oldValue))

		this.ValPrecoult = reactive(new modelFieldType.Number({
			id: 'ValPrecoult',
			originId: 'ValPrecoult',
			area: 'TPEQ1',
			field: 'PRECOULT',
			maxDigits: 9,
			decimalDigits: 2,
			description: computed(() => this.Resources.LAST_PRICE25852),
		}).cloneFrom(values?.ValPrecoult))
		watch(() => this.ValPrecoult.value, (newValue, oldValue) => this.onUpdate('tpeq1.precoult', this.ValPrecoult, newValue, oldValue))

		this.ValSince = reactive(new modelFieldType.DateTime({
			id: 'ValSince',
			originId: 'ValSince',
			area: 'TPEQ1',
			field: 'SINCE',
			description: computed(() => this.Resources.IN34902),
		}).cloneFrom(values?.ValSince))
		watch(() => this.ValSince.value, (newValue, oldValue) => this.onUpdate('tpeq1.since', this.ValSince, newValue, oldValue))

		this.ValQtdequip = reactive(new modelFieldType.Number({
			id: 'ValQtdequip',
			originId: 'ValQtdequip',
			area: 'TPEQ1',
			field: 'QTDEQUIP',
			maxDigits: 6,
			decimalDigits: 0,
			description: computed(() => this.Resources.AMOUNT46885),
		}).cloneFrom(values?.ValQtdequip))
		watch(() => this.ValQtdequip.value, (newValue, oldValue) => this.onUpdate('tpeq1.qtdequip', this.ValQtdequip, newValue, oldValue))

		this.ValKit = reactive(new modelFieldType.Boolean({
			id: 'ValKit',
			originId: 'ValKit',
			area: 'TPEQ1',
			field: 'KIT',
			description: computed(() => this.Resources.KIT27179),
		}).cloneFrom(values?.ValKit))
		watch(() => this.ValKit.value, (newValue, oldValue) => this.onUpdate('tpeq1.kit', this.ValKit, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormTpeq1ViewModel instance.
	 * @returns {QFormTpeq1ViewModel} A new instance of QFormTpeq1ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodtpequ'

	get QPrimaryKey() { return this.ValCodtpequ.value }
	set QPrimaryKey(value) { this.ValCodtpequ.value = value }
}
