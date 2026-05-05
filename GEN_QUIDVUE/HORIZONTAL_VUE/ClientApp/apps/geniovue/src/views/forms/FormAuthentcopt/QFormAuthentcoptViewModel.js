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
			name: 'AUTHENTCOPT',
			area: 'AUTHENTICATOPT',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_AUTHENTCOPT',
				updateFilesTickets: 'UpdateFilesTicketsAUTHENTCOPT'
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
		this.ValAuthvariablet = reactive(new modelFieldType.String({
			id: 'ValAuthvariablet',
			originId: 'ValAuthvariablet',
			area: 'AUTHENTICATOPT',
			field: 'AUTHVARIABLET',
			maxLength: 50,
			description: computed(() => this.Resources.VARIABLE_TYPE39289),
		}).cloneFrom(values?.ValAuthvariablet))
		watch(() => this.ValAuthvariablet.value, (newValue, oldValue) => this.onUpdate('authenticatopt.authvariablet', this.ValAuthvariablet, newValue, oldValue))

		this.ValAuthvarname = reactive(new modelFieldType.String({
			id: 'ValAuthvarname',
			originId: 'ValAuthvarname',
			area: 'AUTHENTICATOPT',
			field: 'AUTHVARNAME',
			maxLength: 50,
			description: computed(() => this.Resources.VARIABLE_NAME27631),
		}).cloneFrom(values?.ValAuthvarname))
		watch(() => this.ValAuthvarname.value, (newValue, oldValue) => this.onUpdate('authenticatopt.authvarname', this.ValAuthvarname, newValue, oldValue))

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

		this.ValAuthmvc = reactive(new modelFieldType.Boolean({
			id: 'ValAuthmvc',
			originId: 'ValAuthmvc',
			area: 'AUTHENTICATOPT',
			field: 'AUTHMVC',
			description: computed(() => this.Resources.MVC48022),
		}).cloneFrom(values?.ValAuthmvc))
		watch(() => this.ValAuthmvc.value, (newValue, oldValue) => this.onUpdate('authenticatopt.authmvc', this.ValAuthmvc, newValue, oldValue))

		this.ValAuthvue = reactive(new modelFieldType.Boolean({
			id: 'ValAuthvue',
			originId: 'ValAuthvue',
			area: 'AUTHENTICATOPT',
			field: 'AUTHVUE',
			description: computed(() => this.Resources.VUE05393),
		}).cloneFrom(values?.ValAuthvue))
		watch(() => this.ValAuthvue.value, (newValue, oldValue) => this.onUpdate('authenticatopt.authvue', this.ValAuthvue, newValue, oldValue))

		this.ValAuthnotes = reactive(new modelFieldType.MultiLineString({
			id: 'ValAuthnotes',
			originId: 'ValAuthnotes',
			area: 'AUTHENTICATOPT',
			field: 'AUTHNOTES',
			description: computed(() => this.Resources.NOTES05274),
		}).cloneFrom(values?.ValAuthnotes))
		watch(() => this.ValAuthnotes.value, (newValue, oldValue) => this.onUpdate('authenticatopt.authnotes', this.ValAuthnotes, newValue, oldValue))

		this.ValAuthpreview = reactive(new modelFieldType.Image({
			id: 'ValAuthpreview',
			originId: 'ValAuthpreview',
			area: 'AUTHENTICATOPT',
			field: 'AUTHPREVIEW',
			description: '',
		}).cloneFrom(values?.ValAuthpreview))
		watch(() => this.ValAuthpreview.value, (newValue, oldValue) => this.onUpdate('authenticatopt.authpreview', this.ValAuthpreview, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormAuthentcoptViewModel instance.
	 * @returns {QFormAuthentcoptViewModel} A new instance of QFormAuthentcoptViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodauthenticatopt'

	get QPrimaryKey() { return this.ValCodauthenticatopt.value }
	set QPrimaryKey(value) { this.ValCodauthenticatopt.updateValue(value) }
}
