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
			name: 'RECORDINFOR',
			area: 'RECORDINFO',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_RECORDINFOR',
				updateFilesTickets: 'UpdateFilesTicketsRECORDINFOR'
			}
		})

		/** The primary key. */
		this.ValCodrecordinfo = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodrecordinfo',
			originId: 'ValCodrecordinfo',
			area: 'RECORDINFO',
			field: 'CODRECORDINFO',
			description: '',
		}).cloneFrom(values?.ValCodrecordinfo))
		watch(() => this.ValCodrecordinfo.value, (newValue, oldValue) => this.onUpdate('recordinfo.codrecordinfo', this.ValCodrecordinfo, newValue, oldValue))

		/** The remaining form fields. */
		this.ValReccreationdate = reactive(new modelFieldType.Date({
			id: 'ValReccreationdate',
			originId: 'ValReccreationdate',
			area: 'RECORDINFO',
			field: 'RECCREATIONDATE',
			isFixed: true,
			description: computed(() => this.Resources.CREATION_DATE51875),
		}).cloneFrom(values?.ValReccreationdate))
		watch(() => this.ValReccreationdate.value, (newValue, oldValue) => this.onUpdate('recordinfo.reccreationdate', this.ValReccreationdate, newValue, oldValue))

		this.ValReccreator = reactive(new modelFieldType.String({
			id: 'ValReccreator',
			originId: 'ValReccreator',
			area: 'RECORDINFO',
			field: 'RECCREATOR',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.CREATED_BY12292),
		}).cloneFrom(values?.ValReccreator))
		watch(() => this.ValReccreator.value, (newValue, oldValue) => this.onUpdate('recordinfo.reccreator', this.ValReccreator, newValue, oldValue))

		this.ValRecchangedate = reactive(new modelFieldType.Date({
			id: 'ValRecchangedate',
			originId: 'ValRecchangedate',
			area: 'RECORDINFO',
			field: 'RECCHANGEDATE',
			isFixed: true,
			description: computed(() => this.Resources.CHANGE_DATE04899),
		}).cloneFrom(values?.ValRecchangedate))
		watch(() => this.ValRecchangedate.value, (newValue, oldValue) => this.onUpdate('recordinfo.recchangedate', this.ValRecchangedate, newValue, oldValue))

		this.ValRecchange = reactive(new modelFieldType.String({
			id: 'ValRecchange',
			originId: 'ValRecchange',
			area: 'RECORDINFO',
			field: 'RECCHANGE',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.CHANGED_BY08967),
		}).cloneFrom(values?.ValRecchange))
		watch(() => this.ValRecchange.value, (newValue, oldValue) => this.onUpdate('recordinfo.recchange', this.ValRecchange, newValue, oldValue))

		this.ValRecdescript = reactive(new modelFieldType.MultiLineString({
			id: 'ValRecdescript',
			originId: 'ValRecdescript',
			area: 'RECORDINFO',
			field: 'RECDESCRIPT',
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValRecdescript))
		watch(() => this.ValRecdescript.value, (newValue, oldValue) => this.onUpdate('recordinfo.recdescript', this.ValRecdescript, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormRecordinforViewModel instance.
	 * @returns {QFormRecordinforViewModel} A new instance of QFormRecordinforViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodrecordinfo'

	get QPrimaryKey() { return this.ValCodrecordinfo.value }
	set QPrimaryKey(value) { this.ValCodrecordinfo.updateValue(value) }
}
