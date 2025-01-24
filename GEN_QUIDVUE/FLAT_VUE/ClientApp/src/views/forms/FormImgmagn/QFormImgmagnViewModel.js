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
			name: 'IMGMAGN',
			area: 'WPESS',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_IMGMAGN'
			}
		})

		/** The primary key. */
		this.ValCodpess = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodpess',
			originId: 'ValCodpess',
			area: 'WPESS',
			field: 'CODPESS',
			description: '',
		}).cloneFrom(values?.ValCodpess))
		watch(() => this.ValCodpess.value, (newValue, oldValue) => this.onUpdate('wpess.codpess', this.ValCodpess, newValue, oldValue))

		/** The hidden foreign keys. */
		this.ValCodwareh = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodwareh',
			originId: 'ValCodwareh',
			area: 'WPESS',
			field: 'CODWAREH',
			relatedArea: 'WAREH',
			description: '',
			isFixed: true,
		}).cloneFrom(values?.ValCodwareh))
		watch(() => this.ValCodwareh.value, (newValue, oldValue) => this.onUpdate('wpess.codwareh', this.ValCodwareh, newValue, oldValue))

		/** The remaining form fields. */
		this.ValFtbackgr = reactive(new modelFieldType.Image({
			id: 'ValFtbackgr',
			originId: 'ValFtbackgr',
			area: 'WPESS',
			field: 'FTBACKGR',
			description: computed(() => this.Resources.IMAGE_BACKGROUND07216),
		}).cloneFrom(values?.ValFtbackgr))
		watch(() => this.ValFtbackgr.value, (newValue, oldValue) => this.onUpdate('wpess.ftbackgr', this.ValFtbackgr, newValue, oldValue))

		/** The form fields used only in formulas. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'WPESS',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
			isFixed: true,
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('wpess.name', this.ValName, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormImgmagnViewModel instance.
	 * @returns {QFormImgmagnViewModel} A new instance of QFormImgmagnViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodpess'

	get QPrimaryKey() { return this.ValCodpess.value }
	set QPrimaryKey(value) { this.ValCodpess.updateValue(value) }
}
