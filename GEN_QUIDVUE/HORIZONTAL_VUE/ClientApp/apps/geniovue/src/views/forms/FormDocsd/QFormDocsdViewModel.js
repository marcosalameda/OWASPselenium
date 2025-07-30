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
			name: 'DOCSD',
			area: 'OUDOC',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Docsd',
				updateFilesTickets: 'UpdateFilesTicketsDocsd',
				setFile: 'SetFileDocsd'
			}
		})

		/** The primary key. */
		this.ValCoddocsd = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCoddocsd',
			originId: 'ValCoddocsd',
			area: 'OUDOC',
			field: 'CODDOCSD',
			description: '',
		}).cloneFrom(values?.ValCoddocsd))
		this.stopWatchers.push(watch(() => this.ValCoddocsd.value, (newValue, oldValue) => this.onUpdate('oudoc.coddocsd', this.ValCoddocsd, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValNrdocsda = reactive(new modelFieldType.Number({
			id: 'ValNrdocsda',
			originId: 'ValNrdocsda',
			area: 'OUDOC',
			field: 'NRDOCSDA',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.NO_14817),
		}).cloneFrom(values?.ValNrdocsda))
		this.stopWatchers.push(watch(() => this.ValNrdocsda.value, (newValue, oldValue) => this.onUpdate('oudoc.nrdocsda', this.ValNrdocsda, newValue, oldValue)))

		this.ValDtdocsda = reactive(new modelFieldType.DateTime({
			id: 'ValDtdocsda',
			originId: 'ValDtdocsda',
			area: 'OUDOC',
			field: 'DTDOCSDA',
			description: computed(() => this.Resources.DATE18475),
		}).cloneFrom(values?.ValDtdocsda))
		this.stopWatchers.push(watch(() => this.ValDtdocsda.value, (newValue, oldValue) => this.onUpdate('oudoc.dtdocsda', this.ValDtdocsda, newValue, oldValue)))

		this.ValTitle = reactive(new modelFieldType.String({
			id: 'ValTitle',
			originId: 'ValTitle',
			area: 'OUDOC',
			field: 'TITLE',
			maxLength: 50,
			description: computed(() => this.Resources.TITLE21885),
		}).cloneFrom(values?.ValTitle))
		this.stopWatchers.push(watch(() => this.ValTitle.value, (newValue, oldValue) => this.onUpdate('oudoc.title', this.ValTitle, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormDocsdViewModel instance.
	 * @returns {QFormDocsdViewModel} A new instance of QFormDocsdViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCoddocsd'

	get QPrimaryKey() { return this.ValCoddocsd.value }
	set QPrimaryKey(value) { this.ValCoddocsd.updateValue(value) }
}
