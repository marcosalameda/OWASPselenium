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
			name: 'PROPE01',
			area: 'PROPE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Prope01',
				updateFilesTickets: 'UpdateFilesTicketsPrope01',
				setFile: 'SetFilePrope01'
			}
		})

		/** The primary key. */
		this.ValCodprope = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodprope',
			originId: 'ValCodprope',
			area: 'PROPE',
			field: 'CODPROPE',
			description: '',
		}).cloneFrom(values?.ValCodprope))
		this.stopWatchers.push(watch(() => this.ValCodprope.value, (newValue, oldValue) => this.onUpdate('prope.codprope', this.ValCodprope, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValCodcity = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcity',
			originId: 'ValCodcity',
			area: 'PROPE',
			field: 'CODCITY',
			relatedArea: 'CITY',
			isFixed: true,
			description: computed(() => this.Resources.CITY42505),
		}).cloneFrom(values?.ValCodcity))
		this.stopWatchers.push(watch(() => this.ValCodcity.value, (newValue, oldValue) => this.onUpdate('prope.codcity', this.ValCodcity, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodagent = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodagent',
			originId: 'ValCodagent',
			area: 'PROPE',
			field: 'CODAGENT',
			relatedArea: 'AGENT',
			description: '',
		}).cloneFrom(values?.ValCodagent))
		this.stopWatchers.push(watch(() => this.ValCodagent.value, (newValue, oldValue) => this.onUpdate('prope.codagent', this.ValCodagent, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValPhoto = reactive(new modelFieldType.Image({
			id: 'ValPhoto',
			originId: 'ValPhoto',
			area: 'PROPE',
			field: 'PHOTO',
			description: computed(() => this.Resources.MAIN_PHOTO18723),
		}).cloneFrom(values?.ValPhoto))
		this.stopWatchers.push(watch(() => this.ValPhoto.value, (newValue, oldValue) => this.onUpdate('prope.photo', this.ValPhoto, newValue, oldValue)))

		this.ValTitle = reactive(new modelFieldType.String({
			id: 'ValTitle',
			originId: 'ValTitle',
			area: 'PROPE',
			field: 'TITLE',
			maxLength: 50,
			description: computed(() => this.Resources.TITLE21885),
		}).cloneFrom(values?.ValTitle))
		this.stopWatchers.push(watch(() => this.ValTitle.value, (newValue, oldValue) => this.onUpdate('prope.title', this.ValTitle, newValue, oldValue)))

		this.ValPrice = reactive(new modelFieldType.Number({
			id: 'ValPrice',
			originId: 'ValPrice',
			area: 'PROPE',
			field: 'PRICE',
			maxDigits: 9,
			decimalDigits: 2,
			description: computed(() => this.Resources.PRICE06900),
		}).cloneFrom(values?.ValPrice))
		this.stopWatchers.push(watch(() => this.ValPrice.value, (newValue, oldValue) => this.onUpdate('prope.price', this.ValPrice, newValue, oldValue)))

		this.TableAgentName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableAgentName',
			originId: 'ValName',
			area: 'AGENT',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableAgentName))
		this.stopWatchers.push(watch(() => this.TableAgentName.value, (newValue, oldValue) => this.onUpdate('agent.name', this.TableAgentName, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormPrope01ViewModel instance.
	 * @returns {QFormPrope01ViewModel} A new instance of QFormPrope01ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodprope'

	get QPrimaryKey() { return this.ValCodprope.value }
	set QPrimaryKey(value) { this.ValCodprope.updateValue(value) }
}
