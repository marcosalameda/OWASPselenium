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
			name: 'ACCORDI',
			area: 'EQUIP',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_ACCORDI'
			}
		})

		/** The primary key. */
		this.ValCodequip = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodequip',
			originId: 'ValCodequip',
			area: 'EQUIP',
			field: 'CODEQUIP',
			description: '',
		}).cloneFrom(values?.ValCodequip))
		watch(() => this.ValCodequip.value, (newValue, oldValue) => this.onUpdate('equip.codequip', this.ValCodequip, newValue, oldValue))

		/** The hidden foreign keys. */
		this.ValCodtpequ = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodtpequ',
			originId: 'ValCodtpequ',
			area: 'EQUIP',
			field: 'CODTPEQU',
			relatedArea: 'TPEQU',
			description: computed(() => this.Resources._TYPE_OF_EQUIPMENT35057),
		}).cloneFrom(values?.ValCodtpequ))
		watch(() => this.ValCodtpequ.value, (newValue, oldValue) => this.onUpdate('equip.codtpequ', this.ValCodtpequ, newValue, oldValue))

		this.ValCodrooms = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodrooms',
			originId: 'ValCodrooms',
			area: 'EQUIP',
			field: 'CODROOMS',
			relatedArea: 'ROOM1',
			description: '',
		}).cloneFrom(values?.ValCodrooms))
		watch(() => this.ValCodrooms.value, (newValue, oldValue) => this.onUpdate('equip.codrooms', this.ValCodrooms, newValue, oldValue))

		this.ValCoddeco = reactive(new modelFieldType.ForeignKey({
			id: 'ValCoddeco',
			originId: 'ValCoddeco',
			area: 'EQUIP',
			field: 'CODDECO',
			relatedArea: 'DECOM',
			description: '',
		}).cloneFrom(values?.ValCoddeco))
		watch(() => this.ValCoddeco.value, (newValue, oldValue) => this.onUpdate('equip.coddeco', this.ValCoddeco, newValue, oldValue))

		this.ValCodwareh = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodwareh',
			originId: 'ValCodwareh',
			area: 'EQUIP',
			field: 'CODWAREH',
			relatedArea: 'WAREH',
			description: '',
		}).cloneFrom(values?.ValCodwareh))
		watch(() => this.ValCodwareh.value, (newValue, oldValue) => this.onUpdate('equip.codwareh', this.ValCodwareh, newValue, oldValue))

		this.ValCoditem = reactive(new modelFieldType.ForeignKey({
			id: 'ValCoditem',
			originId: 'ValCoditem',
			area: 'EQUIP',
			field: 'CODITEM',
			relatedArea: 'ITEM',
			description: '',
		}).cloneFrom(values?.ValCoditem))
		watch(() => this.ValCoditem.value, (newValue, oldValue) => this.onUpdate('equip.coditem', this.ValCoditem, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodempre = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodempre',
			originId: 'ValCodempre',
			area: 'EQUIP',
			field: 'CODEMPRE',
			relatedArea: 'CMPNY',
			description: computed(() => this.Resources._COMPANY02087),
		}).cloneFrom(values?.ValCodempre))
		watch(() => this.ValCodempre.value, (newValue, oldValue) => this.onUpdate('equip.codempre', this.ValCodempre, newValue, oldValue))

		this.ValCodpess1 = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpess1',
			originId: 'ValCodpess1',
			area: 'EQUIP',
			field: 'CODPESS1',
			relatedArea: 'PESS1',
			description: computed(() => this.Resources._COMOMODOR01469),
		}).cloneFrom(values?.ValCodpess1))
		watch(() => this.ValCodpess1.value, (newValue, oldValue) => this.onUpdate('equip.codpess1', this.ValCodpess1, newValue, oldValue))

		/** The remaining form fields. */
		this.TableCmpnyDesignat = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCmpnyDesignat',
			originId: 'ValDesignat',
			area: 'CMPNY',
			field: 'DESIGNAT',
			maxLength: 85,
			description: computed(() => this.Resources.DESIGNATION35876),
		}).cloneFrom(values?.TableCmpnyDesignat))
		watch(() => this.TableCmpnyDesignat.value, (newValue, oldValue) => this.onUpdate('cmpny.designat', this.TableCmpnyDesignat, newValue, oldValue))

		this.TablePess1Name = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePess1Name',
			originId: 'ValName',
			area: 'PESS1',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TablePess1Name))
		watch(() => this.TablePess1Name.value, (newValue, oldValue) => this.onUpdate('pess1.name', this.TablePess1Name, newValue, oldValue))

		this.ValSequennr = reactive(new modelFieldType.Number({
			id: 'ValSequennr',
			originId: 'ValSequennr',
			area: 'EQUIP',
			field: 'SEQUENNR',
			maxDigits: 6,
			decimalDigits: 0,
			description: computed(() => this.Resources.SEQUENTIAL_NO_38590),
		}).cloneFrom(values?.ValSequennr))
		watch(() => this.ValSequennr.value, (newValue, oldValue) => this.onUpdate('equip.sequennr', this.ValSequennr, newValue, oldValue))

		this.ValPhotogra = reactive(new modelFieldType.Image({
			id: 'ValPhotogra',
			originId: 'ValPhotogra',
			area: 'EQUIP',
			field: 'PHOTOGRA',
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.ValPhotogra))
		watch(() => this.ValPhotogra.value, (newValue, oldValue) => this.onUpdate('equip.photogra', this.ValPhotogra, newValue, oldValue))

		/** The form fields used only in formulas. */
		this.ValRegistnr = reactive(new modelFieldType.String({
			id: 'ValRegistnr',
			originId: 'ValRegistnr',
			area: 'EQUIP',
			field: 'REGISTNR',
			maxLength: 6,
			description: computed(() => this.Resources.NO__REGISTER04207),
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: RIGHT("000000"+NumericToString([EQUIP->SEQUENNR],0),6)
					// eslint-disable-next-line eqeqeq
					return qApi.RIGHT("000000"+qApi.NumericToString(this.ValSequennr.value,0),6)
				},
				dependencyEvents: ['fieldChange:equip.sequennr'],
				isServerRecalc: false,
				isServerFormula: false,
				isEmpty: qApi.emptyC,
			},
		}).cloneFrom(values?.ValRegistnr))
		watch(() => this.ValRegistnr.value, (newValue, oldValue) => this.onUpdate('equip.registnr', this.ValRegistnr, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormAccordiViewModel instance.
	 * @returns {QFormAccordiViewModel} A new instance of QFormAccordiViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodequip'

	get QPrimaryKey() { return this.ValCodequip.value }
	set QPrimaryKey(value) { this.ValCodequip.value = value }
}
