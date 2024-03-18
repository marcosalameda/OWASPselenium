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
			name: 'ROIGI',
			area: 'ROIGI',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_ROIGI'
			}
		})

		/** The primary key. */
		this.ValCodroigi = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodroigi',
			originId: 'ValCodroigi',
			area: 'ROIGI',
			field: 'CODROIGI',
			description: '',
		}).cloneFrom(values?.ValCodroigi))
		watch(() => this.ValCodroigi.value, (newValue, oldValue) => this.onUpdate('roigi.codroigi', this.ValCodroigi, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodrogl1 = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodrogl1',
			originId: 'ValCodrogl1',
			area: 'ROIGI',
			field: 'CODROGL1',
			relatedArea: 'ROGL1',
			description: '',
		}).cloneFrom(values?.ValCodrogl1))
		watch(() => this.ValCodrogl1.value, (newValue, oldValue) => this.onUpdate('roigi.codrogl1', this.ValCodrogl1, newValue, oldValue))

		/** The remaining form fields. */
		this.TableRogl1Title = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableRogl1Title',
			originId: 'ValTitle',
			area: 'ROGL1',
			field: 'TITLE',
			maxLength: 50,
			description: computed(() => this.Resources.TITLE21885),
		}).cloneFrom(values?.TableRogl1Title))
		watch(() => this.TableRogl1Title.value, (newValue, oldValue) => this.onUpdate('rogl1.title', this.TableRogl1Title, newValue, oldValue))

		this.ValOrder = reactive(new modelFieldType.Number({
			id: 'ValOrder',
			originId: 'ValOrder',
			area: 'ROIGI',
			field: 'ORDER',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.ORDER39632),
		}).cloneFrom(values?.ValOrder))
		watch(() => this.ValOrder.value, (newValue, oldValue) => this.onUpdate('roigi.order', this.ValOrder, newValue, oldValue))

		this.ValTitle = reactive(new modelFieldType.String({
			id: 'ValTitle',
			originId: 'ValTitle',
			area: 'ROIGI',
			field: 'TITLE',
			maxLength: 50,
			description: computed(() => this.Resources.TITLE21885),
		}).cloneFrom(values?.ValTitle))
		watch(() => this.ValTitle.value, (newValue, oldValue) => this.onUpdate('roigi.title', this.ValTitle, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormRoigiViewModel instance.
	 * @returns {QFormRoigiViewModel} A new instance of QFormRoigiViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodroigi'

	get QPrimaryKey() { return this.ValCodroigi.value }
	set QPrimaryKey(value) { this.ValCodroigi.value = value }
}
