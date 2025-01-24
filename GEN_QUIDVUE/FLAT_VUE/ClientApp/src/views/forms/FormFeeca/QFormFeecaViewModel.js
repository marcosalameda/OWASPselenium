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
			name: 'FEECA',
			area: 'FEECA',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_FEECA'
			}
		})

		/** The primary key. */
		this.ValCodfeeca = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodfeeca',
			originId: 'ValCodfeeca',
			area: 'FEECA',
			field: 'CODFEECA',
			description: '',
		}).cloneFrom(values?.ValCodfeeca))
		watch(() => this.ValCodfeeca.value, (newValue, oldValue) => this.onUpdate('feeca.codfeeca', this.ValCodfeeca, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodflds = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodflds',
			originId: 'ValCodflds',
			area: 'FEECA',
			field: 'CODFLDS',
			relatedArea: 'FLDS',
			description: '',
		}).cloneFrom(values?.ValCodflds))
		watch(() => this.ValCodflds.value, (newValue, oldValue) => this.onUpdate('feeca.codflds', this.ValCodflds, newValue, oldValue))

		/** The remaining form fields. */
		this.TableFldsDescrip = reactive(new modelFieldType.MultiLineString({
			type: 'Lookup',
			id: 'TableFldsDescrip',
			originId: 'ValDescrip',
			area: 'FLDS',
			field: 'DESCRIP',
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.TableFldsDescrip))
		watch(() => this.TableFldsDescrip.value, (newValue, oldValue) => this.onUpdate('flds.descrip', this.TableFldsDescrip, newValue, oldValue))

		this.ValFeedback = reactive(new modelFieldType.String({
			id: 'ValFeedback',
			originId: 'ValFeedback',
			area: 'FEECA',
			field: 'FEEDBACK',
			maxLength: 50,
			description: computed(() => this.Resources.FEEDBACK52855),
		}).cloneFrom(values?.ValFeedback))
		watch(() => this.ValFeedback.value, (newValue, oldValue) => this.onUpdate('feeca.feedback', this.ValFeedback, newValue, oldValue))

		this.FldsValAttach = reactive(new modelFieldType.Document({
			id: 'FldsValAttach',
			originId: 'ValAttach',
			area: 'FLDS',
			field: 'ATTACH',
			properties: computed(() => this.FldsValAttachPropertiesVM),
			documentFK: computed(() => this.FldsValAttachfk),
			currentDocument: computed(() => this.FldsValAttachData),
			description: computed(() => this.Resources.DOCUMENT00695),
			isFixed: true,
		}).cloneFrom(values?.FldsValAttach))
		watch(() => this.FldsValAttach.value, (newValue, oldValue) => this.onUpdate('flds.attach', this.FldsValAttach, newValue, oldValue))

		this.FldsValAttachPropertiesVM = reactive(new modelFieldType.Base({
			id: 'FldsValAttachPropertiesVM',
			isFixed: true,
			area: 'FLDS',
			field: 'ATTACHDOCUM',
			ignoreFldSubmit: true
		}).cloneFrom(values?.FldsValAttachPropertiesVM))
		this.FldsValAttachfk = reactive(new modelFieldType.Base({
			id: 'FldsValAttachfk',
			isFixed: true,
			area: 'FLDS',
			field: 'ATTACHFK'
		}).cloneFrom(values?.FldsValAttachfk))
		watch(() => this.FldsValAttachfk.value, (newValue, oldValue) => this.onUpdate('flds.attachfk', this.FldsValAttachfk, newValue, oldValue))
		this.FldsValAttachData = reactive(new modelFieldType.DocumentData({
			id: 'FldsValAttachData',
			isFixed: true,
			area: 'FLDS',
			field: 'ATTACHDATA',
			ignoreFldSubmit: true
		}).cloneFrom(values?.FldsValAttachData))
		watch(() => this.FldsValAttachData.value, (newValue, oldValue) => this.onUpdate('flds.attachdata', this.FldsValAttachData, newValue, oldValue), { deep: true })

		this.FldsValNpassage = reactive(new modelFieldType.Number({
			id: 'FldsValNpassage',
			originId: 'ValNpassage',
			area: 'FLDS',
			field: 'NPASSAGE',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.NUMERIC19292),
			isFixed: true,
		}).cloneFrom(values?.FldsValNpassage))
		watch(() => this.FldsValNpassage.value, (newValue, oldValue) => this.onUpdate('flds.npassage', this.FldsValNpassage, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormFeecaViewModel instance.
	 * @returns {QFormFeecaViewModel} A new instance of QFormFeecaViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodfeeca'

	get QPrimaryKey() { return this.ValCodfeeca.value }
	set QPrimaryKey(value) { this.ValCodfeeca.updateValue(value) }
}
