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
			name: 'EMPRE',
			area: 'CMPNY',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Empre',
				updateFilesTickets: 'UpdateFilesTicketsEmpre',
				setFile: 'SetFileEmpre'
			}
		})

		/** The primary key. */
		this.ValCodempre = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodempre',
			originId: 'ValCodempre',
			area: 'CMPNY',
			field: 'CODEMPRE',
			description: computed(() => this.Resources.COMPANIES04875),
		}).cloneFrom(values?.ValCodempre))
		this.stopWatchers.push(watch(() => this.ValCodempre.value, (newValue, oldValue) => this.onUpdate('cmpny.codempre', this.ValCodempre, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodcntry = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcntry',
			originId: 'ValCodcntry',
			area: 'CMPNY',
			field: 'CODCNTRY',
			relatedArea: 'CNTRY',
			description: '',
		}).cloneFrom(values?.ValCodcntry))
		this.stopWatchers.push(watch(() => this.ValCodcntry.value, (newValue, oldValue) => this.onUpdate('cmpny.codcntry', this.ValCodcntry, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValLogo = reactive(new modelFieldType.Image({
			id: 'ValLogo',
			originId: 'ValLogo',
			area: 'CMPNY',
			field: 'LOGO',
			description: computed(() => this.Resources.LOGO62483),
		}).cloneFrom(values?.ValLogo))
		this.stopWatchers.push(watch(() => this.ValLogo.value, (newValue, oldValue) => this.onUpdate('cmpny.logo', this.ValLogo, newValue, oldValue)))

		this.ValDesignat = reactive(new modelFieldType.String({
			id: 'ValDesignat',
			originId: 'ValDesignat',
			area: 'CMPNY',
			field: 'DESIGNAT',
			maxLength: 85,
			description: computed(() => this.Resources.DESIGNATION35876),
		}).cloneFrom(values?.ValDesignat))
		this.stopWatchers.push(watch(() => this.ValDesignat.value, (newValue, oldValue) => this.onUpdate('cmpny.designat', this.ValDesignat, newValue, oldValue)))

		this.ValAcronym = reactive(new modelFieldType.String({
			id: 'ValAcronym',
			originId: 'ValAcronym',
			area: 'CMPNY',
			field: 'ACRONYM',
			maxLength: 15,
			description: computed(() => this.Resources.ACRONYM00872),
		}).cloneFrom(values?.ValAcronym))
		this.stopWatchers.push(watch(() => this.ValAcronym.value, (newValue, oldValue) => this.onUpdate('cmpny.acronym', this.ValAcronym, newValue, oldValue)))

		this.ValNif = reactive(new modelFieldType.String({
			id: 'ValNif',
			originId: 'ValNif',
			area: 'CMPNY',
			field: 'NIF',
			maxLength: 15,
			description: computed(() => this.Resources.TAX_IDENTIFICATION51190),
		}).cloneFrom(values?.ValNif))
		this.stopWatchers.push(watch(() => this.ValNif.value, (newValue, oldValue) => this.onUpdate('cmpny.nif', this.ValNif, newValue, oldValue)))

		this.ValTelephon = reactive(new modelFieldType.String({
			id: 'ValTelephon',
			originId: 'ValTelephon',
			area: 'CMPNY',
			field: 'TELEPHON',
			maxLength: 20,
			description: computed(() => this.Resources.PHONE56703),
		}).cloneFrom(values?.ValTelephon))
		this.stopWatchers.push(watch(() => this.ValTelephon.value, (newValue, oldValue) => this.onUpdate('cmpny.telephon', this.ValTelephon, newValue, oldValue)))

		this.ValEmail = reactive(new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'CMPNY',
			field: 'EMAIL',
			maxLength: 254,
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.ValEmail))
		this.stopWatchers.push(watch(() => this.ValEmail.value, (newValue, oldValue) => this.onUpdate('cmpny.email', this.ValEmail, newValue, oldValue)))

		this.TableCntryCountry = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCntryCountry',
			originId: 'ValCountry',
			area: 'CNTRY',
			field: 'COUNTRY',
			maxLength: 90,
			description: computed(() => this.Resources.COUNTRY64133),
		}).cloneFrom(values?.TableCntryCountry))
		this.stopWatchers.push(watch(() => this.TableCntryCountry.value, (newValue, oldValue) => this.onUpdate('cntry.country', this.TableCntryCountry, newValue, oldValue)))

		this.ValQtdpesso = reactive(new modelFieldType.Number({
			id: 'ValQtdpesso',
			originId: 'ValQtdpesso',
			area: 'CMPNY',
			field: 'QTDPESSO',
			maxDigits: 10,
			decimalDigits: 0,
			isFixed: true,
			description: computed(() => this.Resources.NUMBER_OF_PEOPLE08859),
		}).cloneFrom(values?.ValQtdpesso))
		this.stopWatchers.push(watch(() => this.ValQtdpesso.value, (newValue, oldValue) => this.onUpdate('cmpny.qtdpesso', this.ValQtdpesso, newValue, oldValue)))

		this.ValHeadloc = reactive(new modelFieldType.Coordinate({
			id: 'ValHeadloc',
			originId: 'ValHeadloc',
			area: 'CMPNY',
			field: 'HEADLOC',
			description: computed(() => this.Resources.HEADQUARTER_LOCATION30734),
		}).cloneFrom(values?.ValHeadloc))
		this.stopWatchers.push(watch(() => this.ValHeadloc.value, (newValue, oldValue) => this.onUpdate('cmpny.headloc', this.ValHeadloc, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormEmpreViewModel instance.
	 * @returns {QFormEmpreViewModel} A new instance of QFormEmpreViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodempre'

	get QPrimaryKey() { return this.ValCodempre.value }
	set QPrimaryKey(value) { this.ValCodempre.updateValue(value) }
}
