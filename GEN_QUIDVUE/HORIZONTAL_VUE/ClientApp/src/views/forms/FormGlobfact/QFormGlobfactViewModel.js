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
			name: 'GLOBFACT',
			area: 'GLOB',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_GLOBFACT'
			}
		})

		/** The primary key. */
		this.ValCodglob = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodglob',
			originId: 'ValCodglob',
			area: 'GLOB',
			field: 'CODGLOB',
			description: '',
		}).cloneFrom(values?.ValCodglob))
		watch(() => this.ValCodglob.value, (newValue, oldValue) => this.onUpdate('glob.codglob', this.ValCodglob, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodfacty = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodfacty',
			originId: 'ValCodfacty',
			area: 'GLOB',
			field: 'CODFACTY',
			relatedArea: 'FACTY',
			description: '',
		}).cloneFrom(values?.ValCodfacty))
		watch(() => this.ValCodfacty.value, (newValue, oldValue) => this.onUpdate('glob.codfacty', this.ValCodfacty, newValue, oldValue))

		/** The remaining form fields. */
		this.TableFactyType = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableFactyType',
			originId: 'ValType',
			area: 'FACTY',
			field: 'TYPE',
			maxLength: 25,
			description: computed(() => this.Resources.FACILITY_TYPE44577),
		}).cloneFrom(values?.TableFactyType))
		watch(() => this.TableFactyType.value, (newValue, oldValue) => this.onUpdate('facty.type', this.TableFactyType, newValue, oldValue))

		/** The form fields used only in formulas. */
		this.ValHome = reactive(new modelFieldType.MultiLineString({
			id: 'ValHome',
			originId: 'ValHome',
			area: 'GLOB',
			field: 'HOME',
			description: computed(() => this.Resources.HOME_TEXT11153),
			isFixed: true,
		}).cloneFrom(values?.ValHome))
		watch(() => this.ValHome.value, (newValue, oldValue) => this.onUpdate('glob.home', this.ValHome, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormGlobfactViewModel instance.
	 * @returns {QFormGlobfactViewModel} A new instance of QFormGlobfactViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodglob'

	get QPrimaryKey() { return this.ValCodglob.value }
	set QPrimaryKey(value) { this.ValCodglob.updateValue(value) }
}
