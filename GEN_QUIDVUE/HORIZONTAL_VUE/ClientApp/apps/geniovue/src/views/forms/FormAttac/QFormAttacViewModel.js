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
			name: 'ATTAC',
			area: 'ATTAC',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Attac',
				updateFilesTickets: 'UpdateFilesTicketsAttac',
				setFile: 'SetFileAttac'
			}
		})

		/** The primary key. */
		this.ValCodattac = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodattac',
			originId: 'ValCodattac',
			area: 'ATTAC',
			field: 'CODATTAC',
			description: '',
		}).cloneFrom(values?.ValCodattac))
		this.stopWatchers.push(watch(() => this.ValCodattac.value, (newValue, oldValue) => this.onUpdate('attac.codattac', this.ValCodattac, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodasset = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodasset',
			originId: 'ValCodasset',
			area: 'ATTAC',
			field: 'CODASSET',
			relatedArea: 'ASSET',
			description: computed(() => this.Resources.__ASSET57857),
		}).cloneFrom(values?.ValCodasset))
		this.stopWatchers.push(watch(() => this.ValCodasset.value, (newValue, oldValue) => this.onUpdate('attac.codasset', this.ValCodasset, newValue, oldValue)))

		/** The remaining form fields. */
		this.TableAssetName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableAssetName',
			originId: 'ValName',
			area: 'ASSET',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.IDENTIFICATION_NAME16317),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableAssetName))
		this.stopWatchers.push(watch(() => this.TableAssetName.value, (newValue, oldValue) => this.onUpdate('asset.name', this.TableAssetName, newValue, oldValue)))

		this.ValAttached = reactive(new modelFieldType.DateTime({
			id: 'ValAttached',
			originId: 'ValAttached',
			area: 'ATTAC',
			field: 'ATTACHED',
			description: computed(() => this.Resources.ATTACHED26247),
		}).cloneFrom(values?.ValAttached))
		this.stopWatchers.push(watch(() => this.ValAttached.value, (newValue, oldValue) => this.onUpdate('attac.attached', this.ValAttached, newValue, oldValue)))

		this.ValNote = reactive(new modelFieldType.MultiLineString({
			id: 'ValNote',
			originId: 'ValNote',
			area: 'ATTAC',
			field: 'NOTE',
			description: computed(() => this.Resources.NOTE54557),
		}).cloneFrom(values?.ValNote))
		this.stopWatchers.push(watch(() => this.ValNote.value, (newValue, oldValue) => this.onUpdate('attac.note', this.ValNote, newValue, oldValue)))

		this.ValDocument = reactive(new modelFieldType.Document({
			id: 'ValDocument',
			originId: 'ValDocument',
			area: 'ATTAC',
			field: 'DOCUMENT',
			properties: computed(() => this.ValDocumentPropertiesVM),
			documentFK: computed(() => this.ValDocumentfk),
			currentDocument: computed(() => this.ValDocumentData),
			description: computed(() => this.Resources.DOCUMENT00695),
		}).cloneFrom(values?.ValDocument))
		this.stopWatchers.push(watch(() => this.ValDocument.value, (newValue, oldValue) => this.onUpdate('attac.document', this.ValDocument, newValue, oldValue)))

		this.ValDocumentPropertiesVM = reactive(new modelFieldType.Base({
			id: 'ValDocumentPropertiesVM',
			area: 'ATTAC',
			field: 'DOCUMENTDOCUM',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValDocumentPropertiesVM))
		this.ValDocumentfk = reactive(new modelFieldType.String({
			id: 'ValDocumentfk',
			area: 'ATTAC',
			field: 'DOCUMENTFK'
		}).cloneFrom(values?.ValDocumentfk))
		this.stopWatchers.push(watch(() => this.ValDocumentfk.value, (newValue, oldValue) => this.onUpdate('attac.documentfk', this.ValDocumentfk, newValue, oldValue)))

		this.ValDocumentData = reactive(new modelFieldType.DocumentData({
			id: 'ValDocumentData',
			area: 'ATTAC',
			field: 'DOCUMENTDATA',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValDocumentData))
		this.stopWatchers.push(watch(() => this.ValDocumentData.value, (newValue, oldValue) => this.onUpdate('attac.documentdata', this.ValDocumentData, newValue, oldValue), { deep: true }))
	}

	/**
	 * Creates a clone of the current QFormAttacViewModel instance.
	 * @returns {QFormAttacViewModel} A new instance of QFormAttacViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodattac'

	get QPrimaryKey() { return this.ValCodattac.value }
	set QPrimaryKey(value) { this.ValCodattac.updateValue(value) }
}
