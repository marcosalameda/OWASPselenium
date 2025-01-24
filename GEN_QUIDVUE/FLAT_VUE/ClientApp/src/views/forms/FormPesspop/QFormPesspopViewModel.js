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
			name: 'PESSPOP',
			area: 'WPESS',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_PESSPOP'
			}
		})

		/** The primary key. */
		this.ValCodpess = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodpess',
			originId: 'ValCodpess',
			area: 'WPESS',
			field: 'CODPESS',
			description: '',
		}).cloneFrom(values?.ValCodpess))
		watch(() => this.ValCodpess.value, (newValue, oldValue) => this.onUpdate('wpess.codpess', this.ValCodpess, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodwareh = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodwareh',
			originId: 'ValCodwareh',
			area: 'WPESS',
			field: 'CODWAREH',
			relatedArea: 'WAREH',
			description: '',
		}).cloneFrom(values?.ValCodwareh))
		watch(() => this.ValCodwareh.value, (newValue, oldValue) => this.onUpdate('wpess.codwareh', this.ValCodwareh, newValue, oldValue))

		/** The remaining form fields. */
		this.ValNfunc = reactive(new modelFieldType.Number({
			id: 'ValNfunc',
			originId: 'ValNfunc',
			area: 'WPESS',
			field: 'NFUNC',
			maxDigits: 6,
			decimalDigits: 0,
			description: computed(() => this.Resources.NOFUNCIONARIO21429),
		}).cloneFrom(values?.ValNfunc))
		watch(() => this.ValNfunc.value, (newValue, oldValue) => this.onUpdate('wpess.nfunc', this.ValNfunc, newValue, oldValue))

		this.ValPfoto = reactive(new modelFieldType.Image({
			id: 'ValPfoto',
			originId: 'ValPfoto',
			area: 'WPESS',
			field: 'PFOTO',
			description: computed(() => this.Resources.PROFILE_PICTURE26817),
		}).cloneFrom(values?.ValPfoto))
		watch(() => this.ValPfoto.value, (newValue, oldValue) => this.onUpdate('wpess.pfoto', this.ValPfoto, newValue, oldValue))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'WPESS',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('wpess.name', this.ValName, newValue, oldValue))

		this.ValDate = reactive(new modelFieldType.Date({
			id: 'ValDate',
			originId: 'ValDate',
			area: 'WPESS',
			field: 'DATE',
			description: computed(() => this.Resources.BIRTH_DATE54504),
		}).cloneFrom(values?.ValDate))
		watch(() => this.ValDate.value, (newValue, oldValue) => this.onUpdate('wpess.date', this.ValDate, newValue, oldValue))

		this.ValSex = reactive(new modelFieldType.String({
			id: 'ValSex',
			originId: 'ValSex',
			area: 'WPESS',
			field: 'SEX',
			arrayOptions: qProjArrays.QArraySexo.setResources(vm.$getResource).elements,
			maxLength: 9,
			description: computed(() => this.Resources.GENRE63303),
		}).cloneFrom(values?.ValSex))
		watch(() => this.ValSex.value, (newValue, oldValue) => this.onUpdate('wpess.sex', this.ValSex, newValue, oldValue))

		this.ValNaturali = reactive(new modelFieldType.String({
			id: 'ValNaturali',
			originId: 'ValNaturali',
			area: 'WPESS',
			field: 'NATURALI',
			maxLength: 50,
			description: computed(() => this.Resources.NATURALNESS33189),
		}).cloneFrom(values?.ValNaturali))
		watch(() => this.ValNaturali.value, (newValue, oldValue) => this.onUpdate('wpess.naturali', this.ValNaturali, newValue, oldValue))

		this.ValNacional = reactive(new modelFieldType.String({
			id: 'ValNacional',
			originId: 'ValNacional',
			area: 'WPESS',
			field: 'NACIONAL',
			maxLength: 50,
			description: computed(() => this.Resources.NACIONALIDADE23735),
		}).cloneFrom(values?.ValNacional))
		watch(() => this.ValNacional.value, (newValue, oldValue) => this.onUpdate('wpess.nacional', this.ValNacional, newValue, oldValue))

		this.ValAdress = reactive(new modelFieldType.String({
			id: 'ValAdress',
			originId: 'ValAdress',
			area: 'WPESS',
			field: 'ADRESS',
			maxLength: 100,
			description: computed(() => this.Resources.ADDRESS04342),
		}).cloneFrom(values?.ValAdress))
		watch(() => this.ValAdress.value, (newValue, oldValue) => this.onUpdate('wpess.adress', this.ValAdress, newValue, oldValue))

		this.ValZipcode = reactive(new modelFieldType.String({
			id: 'ValZipcode',
			originId: 'ValZipcode',
			area: 'WPESS',
			field: 'ZIPCODE',
			maxLength: 8,
			description: computed(() => this.Resources.ZIP_CODE56964),
			maskType: 'CP',
		}).cloneFrom(values?.ValZipcode))
		watch(() => this.ValZipcode.value, (newValue, oldValue) => this.onUpdate('wpess.zipcode', this.ValZipcode, newValue, oldValue))

		this.ValCountry = reactive(new modelFieldType.String({
			id: 'ValCountry',
			originId: 'ValCountry',
			area: 'WPESS',
			field: 'COUNTRY',
			maxLength: 50,
			description: computed(() => this.Resources.PAIS04637),
		}).cloneFrom(values?.ValCountry))
		watch(() => this.ValCountry.value, (newValue, oldValue) => this.onUpdate('wpess.country', this.ValCountry, newValue, oldValue))

		this.ValEmail = reactive(new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'WPESS',
			field: 'EMAIL',
			maxLength: 150,
			description: computed(() => this.Resources.EMAIL25170),
			maskType: 'EM',
		}).cloneFrom(values?.ValEmail))
		watch(() => this.ValEmail.value, (newValue, oldValue) => this.onUpdate('wpess.email', this.ValEmail, newValue, oldValue))

		this.ValCellphon = reactive(new modelFieldType.Number({
			id: 'ValCellphon',
			originId: 'ValCellphon',
			area: 'WPESS',
			field: 'CELLPHON',
			maxDigits: 9,
			decimalDigits: 0,
			description: computed(() => this.Resources.NOTELEFONE56747),
		}).cloneFrom(values?.ValCellphon))
		watch(() => this.ValCellphon.value, (newValue, oldValue) => this.onUpdate('wpess.cellphon', this.ValCellphon, newValue, oldValue))

		this.TableWarehWarehdes = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableWarehWarehdes',
			originId: 'ValWarehdes',
			area: 'WAREH',
			field: 'WAREHDES',
			maxLength: 85,
			description: computed(() => this.Resources.WAREHOUSE51864),
		}).cloneFrom(values?.TableWarehWarehdes))
		watch(() => this.TableWarehWarehdes.value, (newValue, oldValue) => this.onUpdate('wareh.warehdes', this.TableWarehWarehdes, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormPesspopViewModel instance.
	 * @returns {QFormPesspopViewModel} A new instance of QFormPesspopViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodpess'

	get QPrimaryKey() { return this.ValCodpess.value }
	set QPrimaryKey(value) { this.ValCodpess.updateValue(value) }
}
