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
			name: 'INGROUPS',
			area: 'INPGR',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Ingroups',
				updateFilesTickets: 'UpdateFilesTicketsIngroups',
				setFile: 'SetFileIngroups'
			}
		})

		/** The primary key. */
		this.ValCodinpgr = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodinpgr',
			originId: 'ValCodinpgr',
			area: 'INPGR',
			field: 'CODINPGR',
			description: '',
		}).cloneFrom(values?.ValCodinpgr))
		this.stopWatchers.push(watch(() => this.ValCodinpgr.value, (newValue, oldValue) => this.onUpdate('inpgr.codinpgr', this.ValCodinpgr, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValNumbgro = reactive(new modelFieldType.Number({
			id: 'ValNumbgro',
			originId: 'ValNumbgro',
			area: 'INPGR',
			field: 'NUMBGRO',
			maxDigits: 9,
			decimalDigits: 0,
			description: computed(() => this.Resources.VAT_NUMBER24236),
		}).cloneFrom(values?.ValNumbgro))
		this.stopWatchers.push(watch(() => this.ValNumbgro.value, (newValue, oldValue) => this.onUpdate('inpgr.numbgro', this.ValNumbgro, newValue, oldValue)))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'INPGR',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('inpgr.name', this.ValName, newValue, oldValue)))

		this.ValLastname = reactive(new modelFieldType.String({
			id: 'ValLastname',
			originId: 'ValLastname',
			area: 'INPGR',
			field: 'LASTNAME',
			maxLength: 50,
			description: computed(() => this.Resources.LAST_NAME63426),
		}).cloneFrom(values?.ValLastname))
		this.stopWatchers.push(watch(() => this.ValLastname.value, (newValue, oldValue) => this.onUpdate('inpgr.lastname', this.ValLastname, newValue, oldValue)))

		this.ValPrefix = reactive(new modelFieldType.String({
			id: 'ValPrefix',
			originId: 'ValPrefix',
			area: 'INPGR',
			field: 'PREFIX',
			maxLength: 3,
			arrayOptions: computed(() => new qProjArrays.QArrayPhonepre(vm.$getResource).elements),
			description: computed(() => this.Resources.PREFIX02493),
		}).cloneFrom(values?.ValPrefix))
		this.stopWatchers.push(watch(() => this.ValPrefix.value, (newValue, oldValue) => this.onUpdate('inpgr.prefix', this.ValPrefix, newValue, oldValue)))

		this.ValPhone = reactive(new modelFieldType.Number({
			id: 'ValPhone',
			originId: 'ValPhone',
			area: 'INPGR',
			field: 'PHONE',
			maxDigits: 15,
			decimalDigits: 0,
			description: computed(() => this.Resources.PHONE_NUMBER20774),
		}).cloneFrom(values?.ValPhone))
		this.stopWatchers.push(watch(() => this.ValPhone.value, (newValue, oldValue) => this.onUpdate('inpgr.phone', this.ValPhone, newValue, oldValue)))

		this.ValAdress = reactive(new modelFieldType.String({
			id: 'ValAdress',
			originId: 'ValAdress',
			area: 'INPGR',
			field: 'ADRESS',
			maxLength: 8,
			arrayOptions: computed(() => new qProjArrays.QArrayAddresst(vm.$getResource).elements),
			description: computed(() => this.Resources.ADDRESS_TYPE64627),
		}).cloneFrom(values?.ValAdress))
		this.stopWatchers.push(watch(() => this.ValAdress.value, (newValue, oldValue) => this.onUpdate('inpgr.adress', this.ValAdress, newValue, oldValue)))

		this.ValEmail = reactive(new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'INPGR',
			field: 'EMAIL',
			maxLength: 50,
			maskType: 'EM',
			description: computed(() => this.Resources.E_MAIL42251),
		}).cloneFrom(values?.ValEmail))
		this.stopWatchers.push(watch(() => this.ValEmail.value, (newValue, oldValue) => this.onUpdate('inpgr.email', this.ValEmail, newValue, oldValue)))

		this.ValWeb = reactive(new modelFieldType.String({
			id: 'ValWeb',
			originId: 'ValWeb',
			area: 'INPGR',
			field: 'WEB',
			maxLength: 50,
			description: computed(() => this.Resources.WEB09813),
		}).cloneFrom(values?.ValWeb))
		this.stopWatchers.push(watch(() => this.ValWeb.value, (newValue, oldValue) => this.onUpdate('inpgr.web', this.ValWeb, newValue, oldValue)))

		this.ValBankcomp = reactive(new modelFieldType.String({
			id: 'ValBankcomp',
			originId: 'ValBankcomp',
			area: 'INPGR',
			field: 'BANKCOMP',
			maxLength: 2,
			arrayOptions: computed(() => new qProjArrays.QArrayBankcomp(vm.$getResource).elements),
			description: computed(() => this.Resources.ENTITY62049),
		}).cloneFrom(values?.ValBankcomp))
		this.stopWatchers.push(watch(() => this.ValBankcomp.value, (newValue, oldValue) => this.onUpdate('inpgr.bankcomp', this.ValBankcomp, newValue, oldValue)))

		this.ValIban = reactive(new modelFieldType.String({
			id: 'ValIban',
			originId: 'ValIban',
			area: 'INPGR',
			field: 'IBAN',
			maxLength: 34,
			maskType: 'IN',
			description: computed(() => this.Resources.IBAN28506),
		}).cloneFrom(values?.ValIban))
		this.stopWatchers.push(watch(() => this.ValIban.value, (newValue, oldValue) => this.onUpdate('inpgr.iban', this.ValIban, newValue, oldValue)))

		this.ValTextgro = reactive(new modelFieldType.String({
			id: 'ValTextgro',
			originId: 'ValTextgro',
			area: 'INPGR',
			field: 'TEXTGRO',
			maxLength: 50,
			description: computed(() => this.Resources.TEXT_FIELD41810),
		}).cloneFrom(values?.ValTextgro))
		this.stopWatchers.push(watch(() => this.ValTextgro.value, (newValue, oldValue) => this.onUpdate('inpgr.textgro', this.ValTextgro, newValue, oldValue)))

		this.ValBankacco = reactive(new modelFieldType.String({
			id: 'ValBankacco',
			originId: 'ValBankacco',
			area: 'INPGR',
			field: 'BANKACCO',
			maxLength: 24,
			maskType: 'IB',
			description: computed(() => this.Resources.BANKING_ACCOUNT_NUMB62548),
		}).cloneFrom(values?.ValBankacco))
		this.stopWatchers.push(watch(() => this.ValBankacco.value, (newValue, oldValue) => this.onUpdate('inpgr.bankacco', this.ValBankacco, newValue, oldValue)))

		this.ValDirectio = reactive(new modelFieldType.String({
			id: 'ValDirectio',
			originId: 'ValDirectio',
			area: 'INPGR',
			field: 'DIRECTIO',
			maxLength: 50,
			description: computed(() => this.Resources.ADRESS39816),
		}).cloneFrom(values?.ValDirectio))
		this.stopWatchers.push(watch(() => this.ValDirectio.value, (newValue, oldValue) => this.onUpdate('inpgr.directio', this.ValDirectio, newValue, oldValue)))

		/** The form fields used only in formulas. */
		this.ValIcongro = reactive(new modelFieldType.String({
			id: 'ValIcongro',
			originId: 'ValIcongro',
			area: 'INPGR',
			field: 'ICONGRO',
			maxLength: 50,
			isFixed: true,
			description: computed(() => this.Resources.ICON41974),
		}).cloneFrom(values?.ValIcongro))
		this.stopWatchers.push(watch(() => this.ValIcongro.value, (newValue, oldValue) => this.onUpdate('inpgr.icongro', this.ValIcongro, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormIngroupsViewModel instance.
	 * @returns {QFormIngroupsViewModel} A new instance of QFormIngroupsViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodinpgr'

	get QPrimaryKey() { return this.ValCodinpgr.value }
	set QPrimaryKey(value) { this.ValCodinpgr.updateValue(value) }
}
