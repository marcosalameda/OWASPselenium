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
			name: 'AGREG',
			area: 'AGREG',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Agreg',
				updateFilesTickets: 'UpdateFilesTicketsAgreg',
				setFile: 'SetFileAgreg'
			}
		})

		/** The primary key. */
		this.ValCodaggre = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodaggre',
			originId: 'ValCodaggre',
			area: 'AGREG',
			field: 'CODAGGRE',
			description: '',
		}).cloneFrom(values?.ValCodaggre))
		this.stopWatchers.push(watch(() => this.ValCodaggre.value, (newValue, oldValue) => this.onUpdate('agreg.codaggre', this.ValCodaggre, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodproje = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodproje',
			originId: 'ValCodproje',
			area: 'AGREG',
			field: 'CODPROJE',
			relatedArea: 'PROJE',
			description: computed(() => this.Resources._PROJECT36907),
		}).cloneFrom(values?.ValCodproje))
		this.stopWatchers.push(watch(() => this.ValCodproje.value, (newValue, oldValue) => this.onUpdate('agreg.codproje', this.ValCodproje, newValue, oldValue)))

		this.ValCodyear = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodyear',
			originId: 'ValCodyear',
			area: 'AGREG',
			field: 'CODYEAR',
			relatedArea: 'YEAR',
			description: '',
		}).cloneFrom(values?.ValCodyear))
		this.stopWatchers.push(watch(() => this.ValCodyear.value, (newValue, oldValue) => this.onUpdate('agreg.codyear', this.ValCodyear, newValue, oldValue)))

		/** The remaining form fields. */
		this.TableProjeProjecto = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableProjeProjecto',
			originId: 'ValProjecto',
			area: 'PROJE',
			field: 'PROJECTO',
			maxLength: 50,
			description: computed(() => this.Resources.PROJECT37121),
		}).cloneFrom(values?.TableProjeProjecto))
		this.stopWatchers.push(watch(() => this.TableProjeProjecto.value, (newValue, oldValue) => this.onUpdate('proje.projecto', this.TableProjeProjecto, newValue, oldValue)))

		this.TableYearYear = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableYearYear',
			originId: 'ValYear',
			area: 'YEAR',
			field: 'YEAR',
			maxLength: 4,
			description: computed(() => this.Resources.YEAR61794),
		}).cloneFrom(values?.TableYearYear))
		this.stopWatchers.push(watch(() => this.TableYearYear.value, (newValue, oldValue) => this.onUpdate('year.year', this.TableYearYear, newValue, oldValue)))

		this.ValValue = reactive(new modelFieldType.Number({
			id: 'ValValue',
			originId: 'ValValue',
			area: 'AGREG',
			field: 'VALUE',
			maxDigits: 7,
			decimalDigits: 2,
			isFixed: true,
			description: computed(() => this.Resources.VALUE10285),
		}).cloneFrom(values?.ValValue))
		this.stopWatchers.push(watch(() => this.ValValue.value, (newValue, oldValue) => this.onUpdate('agreg.value', this.ValValue, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormAgregViewModel instance.
	 * @returns {QFormAgregViewModel} A new instance of QFormAgregViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodaggre'

	get QPrimaryKey() { return this.ValCodaggre.value }
	set QPrimaryKey(value) { this.ValCodaggre.updateValue(value) }
}
