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
			name: 'ARTGL',
			area: 'GITEM',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_ARTGL'
			}
		})

		/** The primary key. */
		this.ValCodgitem = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodgitem',
			originId: 'ValCodgitem',
			area: 'GITEM',
			field: 'CODGITEM',
			description: '',
		}).cloneFrom(values?.ValCodgitem))
		watch(() => this.ValCodgitem.value, (newValue, oldValue) => this.onUpdate('gitem.codgitem', this.ValCodgitem, newValue, oldValue))

		/** The remaining form fields. */
		this.ValItemdes = reactive(new modelFieldType.String({
			id: 'ValItemdes',
			originId: 'ValItemdes',
			area: 'GITEM',
			field: 'ITEMDES',
			maxLength: 85,
			description: computed(() => this.Resources.GLOBAL_ARTICLE63861),
		}).cloneFrom(values?.ValItemdes))
		watch(() => this.ValItemdes.value, (newValue, oldValue) => this.onUpdate('gitem.itemdes', this.ValItemdes, newValue, oldValue))

		this.ValItemgcod = reactive(new modelFieldType.String({
			id: 'ValItemgcod',
			originId: 'ValItemgcod',
			area: 'GITEM',
			field: 'ITEMGCOD',
			maxLength: 15,
			description: computed(() => this.Resources.CODE49225),
		}).cloneFrom(values?.ValItemgcod))
		watch(() => this.ValItemgcod.value, (newValue, oldValue) => this.onUpdate('gitem.itemgcod', this.ValItemgcod, newValue, oldValue))

		this.ValDocument = reactive(new modelFieldType.Document({
			id: 'ValDocument',
			originId: 'ValDocument',
			area: 'GITEM',
			field: 'DOCUMENT',
			properties: computed(() => this.ValDocumentPropertiesVM),
			documentFK: computed(() => this.ValDocumentfk),
			currentDocument: computed(() => this.ValDocumentData),
			description: computed(() => this.Resources.DOCUMENT00695),
		}).cloneFrom(values?.ValDocument))
		watch(() => this.ValDocument.value, (newValue, oldValue) => this.onUpdate('gitem.document', this.ValDocument, newValue, oldValue))

		this.ValDocumentPropertiesVM = reactive(new modelFieldType.Base({
			id: 'ValDocumentPropertiesVM',
			area: 'GITEM',
			field: 'DOCUMENTDOCUM',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValDocumentPropertiesVM))
		this.ValDocumentfk = reactive(new modelFieldType.Base({
			id: 'ValDocumentfk',
			area: 'GITEM',
			field: 'DOCUMENTFK'
		}).cloneFrom(values?.ValDocumentfk))
		watch(() => this.ValDocumentfk.value, (newValue, oldValue) => this.onUpdate('gitem.documentfk', this.ValDocumentfk, newValue, oldValue))
		this.ValDocumentData = reactive(new modelFieldType.DocumentData({
			id: 'ValDocumentData',
			area: 'GITEM',
			field: 'DOCUMENTDATA',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValDocumentData))
		watch(() => this.ValDocumentData.value, (newValue, oldValue) => this.onUpdate('gitem.documentdata', this.ValDocumentData, newValue, oldValue), { deep: true })
	}

	/**
	 * Creates a clone of the current QFormArtglViewModel instance.
	 * @returns {QFormArtglViewModel} A new instance of QFormArtglViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodgitem'

	get QPrimaryKey() { return this.ValCodgitem.value }
	set QPrimaryKey(value) { this.ValCodgitem.updateValue(value) }
}
