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
			name: 'UICOM',
			area: 'UICOM',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Uicom',
				updateFilesTickets: 'UpdateFilesTicketsUicom',
				setFile: 'SetFileUicom'
			}
		})

		/** The primary key. */
		this.ValCoduicom = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCoduicom',
			originId: 'ValCoduicom',
			area: 'UICOM',
			field: 'CODUICOM',
			description: '',
		}).cloneFrom(values?.ValCoduicom))
		this.stopWatchers.push(watch(() => this.ValCoduicom.value, (newValue, oldValue) => this.onUpdate('uicom.coduicom', this.ValCoduicom, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValThumbnai = reactive(new modelFieldType.Image({
			id: 'ValThumbnai',
			originId: 'ValThumbnai',
			area: 'UICOM',
			field: 'THUMBNAI',
			description: computed(() => this.Resources.THUMBNAIL30025),
		}).cloneFrom(values?.ValThumbnai))
		this.stopWatchers.push(watch(() => this.ValThumbnai.value, (newValue, oldValue) => this.onUpdate('uicom.thumbnai', this.ValThumbnai, newValue, oldValue)))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'UICOM',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('uicom.name', this.ValName, newValue, oldValue)))

		this.ValCategory = reactive(new modelFieldType.String({
			id: 'ValCategory',
			originId: 'ValCategory',
			area: 'UICOM',
			field: 'CATEGORY',
			maxLength: 50,
			description: computed(() => this.Resources.CATEGORY18978),
		}).cloneFrom(values?.ValCategory))
		this.stopWatchers.push(watch(() => this.ValCategory.value, (newValue, oldValue) => this.onUpdate('uicom.category', this.ValCategory, newValue, oldValue)))

		this.ValMenuid = reactive(new modelFieldType.String({
			id: 'ValMenuid',
			originId: 'ValMenuid',
			area: 'UICOM',
			field: 'MENUID',
			maxLength: 30,
			description: computed(() => this.Resources.FIXED_MENU_NAME38578),
		}).cloneFrom(values?.ValMenuid))
		this.stopWatchers.push(watch(() => this.ValMenuid.value, (newValue, oldValue) => this.onUpdate('uicom.menuid', this.ValMenuid, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormUicomViewModel instance.
	 * @returns {QFormUicomViewModel} A new instance of QFormUicomViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCoduicom'

	get QPrimaryKey() { return this.ValCoduicom.value }
	set QPrimaryKey(value) { this.ValCoduicom.updateValue(value) }
}
