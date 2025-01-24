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
			name: 'INGROUPS',
			area: 'INPGR',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_INGROUPS'
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
		watch(() => this.ValCodinpgr.value, (newValue, oldValue) => this.onUpdate('inpgr.codinpgr', this.ValCodinpgr, newValue, oldValue))

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
		watch(() => this.ValNumbgro.value, (newValue, oldValue) => this.onUpdate('inpgr.numbgro', this.ValNumbgro, newValue, oldValue))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'INPGR',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('inpgr.name', this.ValName, newValue, oldValue))

		this.ValLastname = reactive(new modelFieldType.String({
			id: 'ValLastname',
			originId: 'ValLastname',
			area: 'INPGR',
			field: 'LASTNAME',
			maxLength: 50,
			description: computed(() => this.Resources.LAST_NAME63426),
		}).cloneFrom(values?.ValLastname))
		watch(() => this.ValLastname.value, (newValue, oldValue) => this.onUpdate('inpgr.lastname', this.ValLastname, newValue, oldValue))

		this.ValPrefix = reactive(new modelFieldType.String({
			id: 'ValPrefix',
			originId: 'ValPrefix',
			area: 'INPGR',
			field: 'PREFIX',
			arrayOptions: qProjArrays.QArrayPhonepre.setResources(vm.$getResource).elements,
			maxLength: 3,
			description: computed(() => this.Resources.PREFIX02493),
		}).cloneFrom(values?.ValPrefix))
		watch(() => this.ValPrefix.value, (newValue, oldValue) => this.onUpdate('inpgr.prefix', this.ValPrefix, newValue, oldValue))

		this.ValPhone = reactive(new modelFieldType.Number({
			id: 'ValPhone',
			originId: 'ValPhone',
			area: 'INPGR',
			field: 'PHONE',
			maxDigits: 15,
			decimalDigits: 0,
			description: computed(() => this.Resources.PHONE_NUMBER20774),
		}).cloneFrom(values?.ValPhone))
		watch(() => this.ValPhone.value, (newValue, oldValue) => this.onUpdate('inpgr.phone', this.ValPhone, newValue, oldValue))

		this.ValAdress = reactive(new modelFieldType.String({
			id: 'ValAdress',
			originId: 'ValAdress',
			area: 'INPGR',
			field: 'ADRESS',
			arrayOptions: qProjArrays.QArrayAddresst.setResources(vm.$getResource).elements,
			maxLength: 8,
			description: computed(() => this.Resources.ADDRESS_TYPE64627),
		}).cloneFrom(values?.ValAdress))
		watch(() => this.ValAdress.value, (newValue, oldValue) => this.onUpdate('inpgr.adress', this.ValAdress, newValue, oldValue))

		this.ValEmail = reactive(new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'INPGR',
			field: 'EMAIL',
			maxLength: 50,
			description: computed(() => this.Resources.E_MAIL42251),
			maskType: 'EM',
		}).cloneFrom(values?.ValEmail))
		watch(() => this.ValEmail.value, (newValue, oldValue) => this.onUpdate('inpgr.email', this.ValEmail, newValue, oldValue))

		this.ValWeb = reactive(new modelFieldType.String({
			id: 'ValWeb',
			originId: 'ValWeb',
			area: 'INPGR',
			field: 'WEB',
			maxLength: 50,
			description: computed(() => this.Resources.WEB09813),
		}).cloneFrom(values?.ValWeb))
		watch(() => this.ValWeb.value, (newValue, oldValue) => this.onUpdate('inpgr.web', this.ValWeb, newValue, oldValue))

		this.ValBankcomp = reactive(new modelFieldType.String({
			id: 'ValBankcomp',
			originId: 'ValBankcomp',
			area: 'INPGR',
			field: 'BANKCOMP',
			arrayOptions: qProjArrays.QArrayBankcomp.setResources(vm.$getResource).elements,
			maxLength: 2,
			description: computed(() => this.Resources.ENTITY62049),
		}).cloneFrom(values?.ValBankcomp))
		watch(() => this.ValBankcomp.value, (newValue, oldValue) => this.onUpdate('inpgr.bankcomp', this.ValBankcomp, newValue, oldValue))

		this.ValIban = reactive(new modelFieldType.String({
			id: 'ValIban',
			originId: 'ValIban',
			area: 'INPGR',
			field: 'IBAN',
			maxLength: 34,
			description: computed(() => this.Resources.IBAN28506),
			maskType: 'IN',
		}).cloneFrom(values?.ValIban))
		watch(() => this.ValIban.value, (newValue, oldValue) => this.onUpdate('inpgr.iban', this.ValIban, newValue, oldValue))

		this.ValTextgro = reactive(new modelFieldType.String({
			id: 'ValTextgro',
			originId: 'ValTextgro',
			area: 'INPGR',
			field: 'TEXTGRO',
			maxLength: 50,
			description: computed(() => this.Resources.TEXT_FIELD41810),
		}).cloneFrom(values?.ValTextgro))
		watch(() => this.ValTextgro.value, (newValue, oldValue) => this.onUpdate('inpgr.textgro', this.ValTextgro, newValue, oldValue))

		this.ValBankacco = reactive(new modelFieldType.String({
			id: 'ValBankacco',
			originId: 'ValBankacco',
			area: 'INPGR',
			field: 'BANKACCO',
			maxLength: 24,
			description: computed(() => this.Resources.BANKING_ACCOUNT_NUMB62548),
			maskType: 'IB',
		}).cloneFrom(values?.ValBankacco))
		watch(() => this.ValBankacco.value, (newValue, oldValue) => this.onUpdate('inpgr.bankacco', this.ValBankacco, newValue, oldValue))

		this.ValDirectio = reactive(new modelFieldType.String({
			id: 'ValDirectio',
			originId: 'ValDirectio',
			area: 'INPGR',
			field: 'DIRECTIO',
			maxLength: 50,
			description: computed(() => this.Resources.ADRESS39816),
		}).cloneFrom(values?.ValDirectio))
		watch(() => this.ValDirectio.value, (newValue, oldValue) => this.onUpdate('inpgr.directio', this.ValDirectio, newValue, oldValue))

		/** The form fields used only in formulas. */
		this.ValIcongro = reactive(new modelFieldType.String({
			id: 'ValIcongro',
			originId: 'ValIcongro',
			area: 'INPGR',
			field: 'ICONGRO',
			maxLength: 50,
			description: computed(() => this.Resources.ICON41974),
			isFixed: true,
		}).cloneFrom(values?.ValIcongro))
		watch(() => this.ValIcongro.value, (newValue, oldValue) => this.onUpdate('inpgr.icongro', this.ValIcongro, newValue, oldValue))
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
