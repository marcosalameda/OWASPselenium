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
			name: 'ROIGF',
			area: 'ROIGF',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Roigf',
				updateFilesTickets: 'UpdateFilesTicketsRoigf',
				setFile: 'SetFileRoigf'
			}
		})

		/** The primary key. */
		this.ValCodroigf = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodroigf',
			originId: 'ValCodroigf',
			area: 'ROIGF',
			field: 'CODROIGF',
			description: '',
		}).cloneFrom(values?.ValCodroigf))
		this.stopWatchers.push(watch(() => this.ValCodroigf.value, (newValue, oldValue) => this.onUpdate('roigf.codroigf', this.ValCodroigf, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodrogl1 = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodrogl1',
			originId: 'ValCodrogl1',
			area: 'ROIGF',
			field: 'CODROGL1',
			relatedArea: 'ROGL1',
			description: '',
		}).cloneFrom(values?.ValCodrogl1))
		this.stopWatchers.push(watch(() => this.ValCodrogl1.value, (newValue, oldValue) => this.onUpdate('roigf.codrogl1', this.ValCodrogl1, newValue, oldValue)))

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
		this.stopWatchers.push(watch(() => this.TableRogl1Title.value, (newValue, oldValue) => this.onUpdate('rogl1.title', this.TableRogl1Title, newValue, oldValue)))

		this.ValOrder = reactive(new modelFieldType.Number({
			id: 'ValOrder',
			originId: 'ValOrder',
			area: 'ROIGF',
			field: 'ORDER',
			maxDigits: 8,
			decimalDigits: 1,
			description: computed(() => this.Resources.ORDER39632),
		}).cloneFrom(values?.ValOrder))
		this.stopWatchers.push(watch(() => this.ValOrder.value, (newValue, oldValue) => this.onUpdate('roigf.order', this.ValOrder, newValue, oldValue)))

		this.ValTitle = reactive(new modelFieldType.String({
			id: 'ValTitle',
			originId: 'ValTitle',
			area: 'ROIGF',
			field: 'TITLE',
			maxLength: 50,
			description: computed(() => this.Resources.TITLE21885),
		}).cloneFrom(values?.ValTitle))
		this.stopWatchers.push(watch(() => this.ValTitle.value, (newValue, oldValue) => this.onUpdate('roigf.title', this.ValTitle, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormRoigfViewModel instance.
	 * @returns {QFormRoigfViewModel} A new instance of QFormRoigfViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodroigf'

	get QPrimaryKey() { return this.ValCodroigf.value }
	set QPrimaryKey(value) { this.ValCodroigf.updateValue(value) }
}
