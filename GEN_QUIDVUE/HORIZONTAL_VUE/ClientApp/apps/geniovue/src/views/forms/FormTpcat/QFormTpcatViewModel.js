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
			name: 'TPCAT',
			area: 'CATTP',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_TPCAT',
				updateFilesTickets: 'UpdateFilesTicketsTPCAT'
			}
		})

		/** The primary key. */
		this.ValCodtpcat = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodtpcat',
			originId: 'ValCodtpcat',
			area: 'CATTP',
			field: 'CODTPCAT',
			description: '',
		}).cloneFrom(values?.ValCodtpcat))
		watch(() => this.ValCodtpcat.value, (newValue, oldValue) => this.onUpdate('cattp.codtpcat', this.ValCodtpcat, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodsbcat = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodsbcat',
			originId: 'ValCodsbcat',
			area: 'CATTP',
			field: 'CODSBCAT',
			relatedArea: 'SBCAT',
			description: '',
		}).cloneFrom(values?.ValCodsbcat))
		watch(() => this.ValCodsbcat.value, (newValue, oldValue) => this.onUpdate('cattp.codsbcat', this.ValCodsbcat, newValue, oldValue))

		/** The remaining form fields. */
		this.ValTpcatego = reactive(new modelFieldType.String({
			id: 'ValTpcatego',
			originId: 'ValTpcatego',
			area: 'CATTP',
			field: 'TPCATEGO',
			maxLength: 85,
			description: computed(() => this.Resources.CATEGORY_TYPE23058),
		}).cloneFrom(values?.ValTpcatego))
		watch(() => this.ValTpcatego.value, (newValue, oldValue) => this.onUpdate('cattp.tpcatego', this.ValTpcatego, newValue, oldValue))

		this.TableSbcatSubcateg = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableSbcatSubcateg',
			originId: 'ValSubcateg',
			area: 'SBCAT',
			field: 'SUBCATEG',
			maxLength: 50,
			description: computed(() => this.Resources.SUB_CATEGORIA15612),
		}).cloneFrom(values?.TableSbcatSubcateg))
		watch(() => this.TableSbcatSubcateg.value, (newValue, oldValue) => this.onUpdate('sbcat.subcateg', this.TableSbcatSubcateg, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormTpcatViewModel instance.
	 * @returns {QFormTpcatViewModel} A new instance of QFormTpcatViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodtpcat'

	get QPrimaryKey() { return this.ValCodtpcat.value }
	set QPrimaryKey(value) { this.ValCodtpcat.updateValue(value) }
}
