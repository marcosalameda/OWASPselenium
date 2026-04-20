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
			name: 'ASSMA',
			area: 'ASSMA',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Assma',
				updateFilesTickets: 'UpdateFilesTicketsAssma',
				setFile: 'SetFileAssma'
			}
		})

		/** The primary key. */
		this.ValCodassma = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodassma',
			originId: 'ValCodassma',
			area: 'ASSMA',
			field: 'CODASSMA',
			description: '',
		}).cloneFrom(values?.ValCodassma))
		this.stopWatchers.push(watch(() => this.ValCodassma.value, (newValue, oldValue) => this.onUpdate('assma.codassma', this.ValCodassma, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodasset = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodasset',
			originId: 'ValCodasset',
			area: 'ASSMA',
			field: 'CODASSET',
			relatedArea: 'ASSET',
			description: computed(() => this.Resources.__ASSET23159),
		}).cloneFrom(values?.ValCodasset))
		this.stopWatchers.push(watch(() => this.ValCodasset.value, (newValue, oldValue) => this.onUpdate('assma.codasset', this.ValCodasset, newValue, oldValue)))

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

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'ASSMA',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.MANUAL_NAME60077),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('assma.name', this.ValName, newValue, oldValue)))

		this.ValDigdocum = reactive(new modelFieldType.Document({
			id: 'ValDigdocum',
			originId: 'ValDigdocum',
			area: 'ASSMA',
			field: 'DIGDOCUM',
			properties: computed(() => this.ValDigdocumPropertiesVM),
			documentFK: computed(() => this.ValDigdocumfk),
			currentDocument: computed(() => this.ValDigdocumData),
			description: computed(() => this.Resources.DIGITAL_DOCUMENT59580),
		}).cloneFrom(values?.ValDigdocum))
		this.stopWatchers.push(watch(() => this.ValDigdocum.value, (newValue, oldValue) => this.onUpdate('assma.digdocum', this.ValDigdocum, newValue, oldValue)))

		this.ValDigdocumPropertiesVM = reactive(new modelFieldType.Base({
			id: 'ValDigdocumPropertiesVM',
			area: 'ASSMA',
			field: 'DIGDOCUMDOCUM',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValDigdocumPropertiesVM))
		this.ValDigdocumfk = reactive(new modelFieldType.String({
			id: 'ValDigdocumfk',
			area: 'ASSMA',
			field: 'DIGDOCUMFK'
		}).cloneFrom(values?.ValDigdocumfk))
		this.stopWatchers.push(watch(() => this.ValDigdocumfk.value, (newValue, oldValue) => this.onUpdate('assma.digdocumfk', this.ValDigdocumfk, newValue, oldValue)))

		this.ValDigdocumData = reactive(new modelFieldType.DocumentData({
			id: 'ValDigdocumData',
			area: 'ASSMA',
			field: 'DIGDOCUMDATA',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValDigdocumData))
		this.stopWatchers.push(watch(() => this.ValDigdocumData.value, (newValue, oldValue) => this.onUpdate('assma.digdocumdata', this.ValDigdocumData, newValue, oldValue), { deep: true }))

		this.ValNotes = reactive(new modelFieldType.MultiLineString({
			id: 'ValNotes',
			originId: 'ValNotes',
			area: 'ASSMA',
			field: 'NOTES',
			description: computed(() => this.Resources.NOTES05274),
		}).cloneFrom(values?.ValNotes))
		this.stopWatchers.push(watch(() => this.ValNotes.value, (newValue, oldValue) => this.onUpdate('assma.notes', this.ValNotes, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormAssmaViewModel instance.
	 * @returns {QFormAssmaViewModel} A new instance of QFormAssmaViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodassma'

	get QPrimaryKey() { return this.ValCodassma.value }
	set QPrimaryKey(value) { this.ValCodassma.updateValue(value) }
}
