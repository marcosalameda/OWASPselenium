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
			name: 'PLIST',
			area: 'ITEM',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_PLIST'
			}
		})

		/** The primary key. */
		this.ValCoditem = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCoditem',
			originId: 'ValCoditem',
			area: 'ITEM',
			field: 'CODITEM',
			description: '',
		}).cloneFrom(values?.ValCoditem))
		watch(() => this.ValCoditem.value, (newValue, oldValue) => this.onUpdate('item.coditem', this.ValCoditem, newValue, oldValue))

		/** The hidden foreign keys. */
		this.ValCodgitem = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodgitem',
			originId: 'ValCodgitem',
			area: 'ITEM',
			field: 'CODGITEM',
			relatedArea: 'GITEM',
			isFixed: true,
			description: computed(() => this.Resources._GLOBAL_ARTICLE51116),
		}).cloneFrom(values?.ValCodgitem))
		watch(() => this.ValCodgitem.value, (newValue, oldValue) => this.onUpdate('item.codgitem', this.ValCodgitem, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodwareh = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodwareh',
			originId: 'ValCodwareh',
			area: 'ITEM',
			field: 'CODWAREH',
			relatedArea: 'WAREH',
			description: computed(() => this.Resources._WAREHOUSE19861),
		}).cloneFrom(values?.ValCodwareh))
		watch(() => this.ValCodwareh.value, (newValue, oldValue) => this.onUpdate('item.codwareh', this.ValCodwareh, newValue, oldValue))

		/** The remaining form fields. */
		this.TableWarehWarehdes = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableWarehWarehdes',
			originId: 'ValWarehdes',
			area: 'WAREH',
			field: 'WAREHDES',
			maxLength: 85,
			description: computed(() => this.Resources.WAREHOUSE51864),
		}).cloneFrom(values?.TableWarehWarehdes))
		watch(() => this.TableWarehWarehdes.value, (newValue, oldValue) => this.onUpdate('wareh.warehdes', this.TableWarehWarehdes, newValue, oldValue))

		this.ValItemdes = reactive(new modelFieldType.String({
			id: 'ValItemdes',
			originId: 'ValItemdes',
			area: 'ITEM',
			field: 'ITEMDES',
			maxLength: 85,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: [GITEM->ITEMDES]
					return this.GitemValItemdes.value
				},
				dependencyEvents: ['fieldChange:gitem.itemdes', 'fieldChange:item.codgitem'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			description: computed(() => this.Resources.ARTICLE60065),
		}).cloneFrom(values?.ValItemdes))
		watch(() => this.ValItemdes.value, (newValue, oldValue) => this.onUpdate('item.itemdes', this.ValItemdes, newValue, oldValue))
		/** Property List Value. */
		this.ValPlist = reactive(new modelFieldType.PropertyList({
			id: 'ValPlist',
			area: 'ITEMP',
			field: 'PLIST',
			pkField: 'ValCoditemp',
			propCol: 'ValPropid',
			valueCol: 'ValPropval',
			typeCol: 'ValProptype',
		}, this.vueContext).cloneFrom(values?.ValPlist))
		watch(() => this.ValPlist.value, (newValue, oldValue) => this.onUpdate('pseud.plist', this.ValPlist, newValue, oldValue), { deep: true })

		/** The form fields used only in formulas. */
		this.GitemValItemdes = reactive(new modelFieldType.String({
			id: 'GitemValItemdes',
			originId: 'ValItemdes',
			area: 'GITEM',
			field: 'ITEMDES',
			maxLength: 85,
			isFixed: true,
			description: computed(() => this.Resources.GLOBAL_ARTICLE63861),
		}).cloneFrom(values?.GitemValItemdes))
		watch(() => this.GitemValItemdes.value, (newValue, oldValue) => this.onUpdate('gitem.itemdes', this.GitemValItemdes, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormPlistViewModel instance.
	 * @returns {QFormPlistViewModel} A new instance of QFormPlistViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCoditem'

	get QPrimaryKey() { return this.ValCoditem.value }
	set QPrimaryKey(value) { this.ValCoditem.updateValue(value) }
}
