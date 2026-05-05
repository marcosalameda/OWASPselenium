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
			name: 'AUTHENTCLASS',
			area: 'AUTHENTICATOPT',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_AUTHENTCLASS',
				updateFilesTickets: 'UpdateFilesTicketsAUTHENTCLASS'
			}
		})

		/** The primary key. */
		this.ValCodauthenticatopt = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodauthenticatopt',
			originId: 'ValCodauthenticatopt',
			area: 'AUTHENTICATOPT',
			field: 'CODAUTHENTICATOPT',
			description: '',
		}).cloneFrom(values?.ValCodauthenticatopt))
		watch(() => this.ValCodauthenticatopt.value, (newValue, oldValue) => this.onUpdate('authenticatopt.codauthenticatopt', this.ValCodauthenticatopt, newValue, oldValue))

		/** The remaining form fields. */
		this.ValAuthpreview = reactive(new modelFieldType.Image({
			id: 'ValAuthpreview',
			originId: 'ValAuthpreview',
			area: 'AUTHENTICATOPT',
			field: 'AUTHPREVIEW',
			description: '',
		}).cloneFrom(values?.ValAuthpreview))
		watch(() => this.ValAuthpreview.value, (newValue, oldValue) => this.onUpdate('authenticatopt.authpreview', this.ValAuthpreview, newValue, oldValue))

		this.ValAuthoptions = reactive(new modelFieldType.String({
			id: 'ValAuthoptions',
			originId: 'ValAuthoptions',
			area: 'AUTHENTICATOPT',
			field: 'AUTHOPTIONS',
			maxLength: 1,
			arrayOptions: computed(() => qProjArrays.QArrayAuthentication_options.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.OPTION19344),
		}).cloneFrom(values?.ValAuthoptions))
		watch(() => this.ValAuthoptions.value, (newValue, oldValue) => this.onUpdate('authenticatopt.authoptions', this.ValAuthoptions, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormAuthentclassViewModel instance.
	 * @returns {QFormAuthentclassViewModel} A new instance of QFormAuthentclassViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodauthenticatopt'

	get QPrimaryKey() { return this.ValCodauthenticatopt.value }
	set QPrimaryKey(value) { this.ValCodauthenticatopt.updateValue(value) }
}
