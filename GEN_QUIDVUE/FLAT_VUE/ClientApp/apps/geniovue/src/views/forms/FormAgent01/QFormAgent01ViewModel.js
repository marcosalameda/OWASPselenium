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
			name: 'AGENT01',
			area: 'AGENT',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Agent01',
				updateFilesTickets: 'UpdateFilesTicketsAgent01',
				setFile: 'SetFileAgent01'
			}
		})

		/** The primary key. */
		this.ValCodagent = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodagent',
			originId: 'ValCodagent',
			area: 'AGENT',
			field: 'CODAGENT',
			description: '',
		}).cloneFrom(values?.ValCodagent))
		this.stopWatchers.push(watch(() => this.ValCodagent.value, (newValue, oldValue) => this.onUpdate('agent.codagent', this.ValCodagent, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValPhoto = reactive(new modelFieldType.Image({
			id: 'ValPhoto',
			originId: 'ValPhoto',
			area: 'AGENT',
			field: 'PHOTO',
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.ValPhoto))
		this.stopWatchers.push(watch(() => this.ValPhoto.value, (newValue, oldValue) => this.onUpdate('agent.photo', this.ValPhoto, newValue, oldValue)))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'AGENT',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('agent.name', this.ValName, newValue, oldValue)))

		this.ValBirthdat = reactive(new modelFieldType.Date({
			id: 'ValBirthdat',
			originId: 'ValBirthdat',
			area: 'AGENT',
			field: 'BIRTHDAT',
			description: computed(() => this.Resources.BIRTHDATE22743),
		}).cloneFrom(values?.ValBirthdat))
		this.stopWatchers.push(watch(() => this.ValBirthdat.value, (newValue, oldValue) => this.onUpdate('agent.birthdat', this.ValBirthdat, newValue, oldValue)))

		this.ValEmail = reactive(new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'AGENT',
			field: 'EMAIL',
			maxLength: 50,
			maskType: 'EM',
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: "@agency.com"
					return "@agency.com"
				},
				dependencyEvents: [],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.ValEmail))
		this.stopWatchers.push(watch(() => this.ValEmail.value, (newValue, oldValue) => this.onUpdate('agent.email', this.ValEmail, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormAgent01ViewModel instance.
	 * @returns {QFormAgent01ViewModel} A new instance of QFormAgent01ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodagent'

	get QPrimaryKey() { return this.ValCodagent.value }
	set QPrimaryKey(value) { this.ValCodagent.updateValue(value) }
}
