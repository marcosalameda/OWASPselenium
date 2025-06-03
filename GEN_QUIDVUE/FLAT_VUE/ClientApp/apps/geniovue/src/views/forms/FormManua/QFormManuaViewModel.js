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
			name: 'MANUA',
			area: 'MANUA',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_MANUA'
			}
		})

		/** The primary key. */
		this.ValCodmanua = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodmanua',
			originId: 'ValCodmanua',
			area: 'MANUA',
			field: 'CODMANUA',
			description: '',
		}).cloneFrom(values?.ValCodmanua))
		watch(() => this.ValCodmanua.value, (newValue, oldValue) => this.onUpdate('manua.codmanua', this.ValCodmanua, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodkinde = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodkinde',
			originId: 'ValCodkinde',
			area: 'MANUA',
			field: 'CODKINDE',
			relatedArea: 'KINDE',
			description: '',
		}).cloneFrom(values?.ValCodkinde))
		watch(() => this.ValCodkinde.value, (newValue, oldValue) => this.onUpdate('manua.codkinde', this.ValCodkinde, newValue, oldValue))

		/** The remaining form fields. */
		this.TableKindeDesignat = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableKindeDesignat',
			originId: 'ValDesignat',
			area: 'KINDE',
			field: 'DESIGNAT',
			maxLength: 85,
			description: computed(() => this.Resources.KIND_OF_EQUIPMENT22928),
		}).cloneFrom(values?.TableKindeDesignat))
		watch(() => this.TableKindeDesignat.value, (newValue, oldValue) => this.onUpdate('kinde.designat', this.TableKindeDesignat, newValue, oldValue))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'MANUA',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.MANUAL_NAME60077),
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('manua.name', this.ValName, newValue, oldValue))

		this.ValDigdocum = reactive(new modelFieldType.Document({
			id: 'ValDigdocum',
			originId: 'ValDigdocum',
			area: 'MANUA',
			field: 'DIGDOCUM',
			properties: computed(() => this.ValDigdocumPropertiesVM),
			documentFK: computed(() => this.ValDigdocumfk),
			currentDocument: computed(() => this.ValDigdocumData),
			description: computed(() => this.Resources.DIGITAL_DOCUMENT59580),
		}).cloneFrom(values?.ValDigdocum))
		watch(() => this.ValDigdocum.value, (newValue, oldValue) => this.onUpdate('manua.digdocum', this.ValDigdocum, newValue, oldValue))

		this.ValDigdocumPropertiesVM = reactive(new modelFieldType.Base({
			id: 'ValDigdocumPropertiesVM',
			area: 'MANUA',
			field: 'DIGDOCUMDOCUM',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValDigdocumPropertiesVM))
		this.ValDigdocumfk = reactive(new modelFieldType.String({
			id: 'ValDigdocumfk',
			area: 'MANUA',
			field: 'DIGDOCUMFK'
		}).cloneFrom(values?.ValDigdocumfk))
		watch(() => this.ValDigdocumfk.value, (newValue, oldValue) => this.onUpdate('manua.digdocumfk', this.ValDigdocumfk, newValue, oldValue))
		this.ValDigdocumData = reactive(new modelFieldType.DocumentData({
			id: 'ValDigdocumData',
			area: 'MANUA',
			field: 'DIGDOCUMDATA',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValDigdocumData))
		watch(() => this.ValDigdocumData.value, (newValue, oldValue) => this.onUpdate('manua.digdocumdata', this.ValDigdocumData, newValue, oldValue), { deep: true })

		this.ValNotes = reactive(new modelFieldType.MultiLineString({
			id: 'ValNotes',
			originId: 'ValNotes',
			area: 'MANUA',
			field: 'NOTES',
			description: computed(() => this.Resources.NOTES05274),
		}).cloneFrom(values?.ValNotes))
		watch(() => this.ValNotes.value, (newValue, oldValue) => this.onUpdate('manua.notes', this.ValNotes, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormManuaViewModel instance.
	 * @returns {QFormManuaViewModel} A new instance of QFormManuaViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodmanua'

	get QPrimaryKey() { return this.ValCodmanua.value }
	set QPrimaryKey(value) { this.ValCodmanua.updateValue(value) }
}
