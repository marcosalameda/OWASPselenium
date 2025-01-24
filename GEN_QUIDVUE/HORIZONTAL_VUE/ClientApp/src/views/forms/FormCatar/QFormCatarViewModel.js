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
			name: 'CATAR',
			area: 'ITEMC',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_CATAR'
			}
		})

		/** The primary key. */
		this.ValCodcatar = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcatar',
			originId: 'ValCodcatar',
			area: 'ITEMC',
			field: 'CODCATAR',
			description: '',
		}).cloneFrom(values?.ValCodcatar))
		watch(() => this.ValCodcatar.value, (newValue, oldValue) => this.onUpdate('itemc.codcatar', this.ValCodcatar, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCoditem = reactive(new modelFieldType.ForeignKey({
			id: 'ValCoditem',
			originId: 'ValCoditem',
			area: 'ITEMC',
			field: 'CODITEM',
			relatedArea: 'ITEM',
			description: '',
		}).cloneFrom(values?.ValCoditem))
		watch(() => this.ValCoditem.value, (newValue, oldValue) => this.onUpdate('itemc.coditem', this.ValCoditem, newValue, oldValue))

		this.ValCodtpcat = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodtpcat',
			originId: 'ValCodtpcat',
			area: 'ITEMC',
			field: 'CODTPCAT',
			relatedArea: 'CATTP',
			description: '',
		}).cloneFrom(values?.ValCodtpcat))
		watch(() => this.ValCodtpcat.value, (newValue, oldValue) => this.onUpdate('itemc.codtpcat', this.ValCodtpcat, newValue, oldValue))

		/** The remaining form fields. */
		this.TableItemItemdes = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableItemItemdes',
			originId: 'ValItemdes',
			area: 'ITEM',
			field: 'ITEMDES',
			maxLength: 85,
			description: computed(() => this.Resources.ARTICLE60065),
		}).cloneFrom(values?.TableItemItemdes))
		watch(() => this.TableItemItemdes.value, (newValue, oldValue) => this.onUpdate('item.itemdes', this.TableItemItemdes, newValue, oldValue))

		this.TableCattpTpcatego = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCattpTpcatego',
			originId: 'ValTpcatego',
			area: 'CATTP',
			field: 'TPCATEGO',
			maxLength: 85,
			description: computed(() => this.Resources.CATEGORY_TYPE23058),
		}).cloneFrom(values?.TableCattpTpcatego))
		watch(() => this.TableCattpTpcatego.value, (newValue, oldValue) => this.onUpdate('cattp.tpcatego', this.TableCattpTpcatego, newValue, oldValue))

		/** The form fields used only in formulas. */
		this.ValTpcateg = reactive(new modelFieldType.String({
			id: 'ValTpcateg',
			originId: 'ValTpcateg',
			area: 'ITEMC',
			field: 'TPCATEG',
			maxLength: 85,
			description: computed(() => this.Resources.CATEGORY_TYPE23058),
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					const fieldId = params?.originField?.id
					const data = typeof fieldId === 'string' ? { [fieldId]: params.originField.value } : {}
					return this.recalculateFormulas(data)
				},
				dependencyEvents: ['fieldChange:itemc.codtpcat'],
				isServerRecalc: true,
				isEmpty: qApi.emptyC,
			},
		}).cloneFrom(values?.ValTpcateg))
		watch(() => this.ValTpcateg.value, (newValue, oldValue) => this.onUpdate('itemc.tpcateg', this.ValTpcateg, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormCatarViewModel instance.
	 * @returns {QFormCatarViewModel} A new instance of QFormCatarViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcatar'

	get QPrimaryKey() { return this.ValCodcatar.value }
	set QPrimaryKey(value) { this.ValCodcatar.updateValue(value) }
}
