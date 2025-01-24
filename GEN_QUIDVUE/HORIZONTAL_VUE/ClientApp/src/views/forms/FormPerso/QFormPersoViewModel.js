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
			name: 'PERSO',
			area: 'PERSO',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_PERSO'
			}
		})

		/** The primary key. */
		this.ValCodperso = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodperso',
			originId: 'ValCodperso',
			area: 'PERSO',
			field: 'CODPERSO',
			description: '',
		}).cloneFrom(values?.ValCodperso))
		watch(() => this.ValCodperso.value, (newValue, oldValue) => this.onUpdate('perso.codperso', this.ValCodperso, newValue, oldValue))

		/** The remaining form fields. */
		this.ValPhoto = reactive(new modelFieldType.Image({
			id: 'ValPhoto',
			originId: 'ValPhoto',
			area: 'PERSO',
			field: 'PHOTO',
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.ValPhoto))
		watch(() => this.ValPhoto.value, (newValue, oldValue) => this.onUpdate('perso.photo', this.ValPhoto, newValue, oldValue))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'PERSO',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.PERSON_NAME40980),
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('perso.name', this.ValName, newValue, oldValue))

		this.ValIdentifi = reactive(new modelFieldType.String({
			id: 'ValIdentifi',
			originId: 'ValIdentifi',
			area: 'PERSO',
			field: 'IDENTIFI',
			maxLength: 10,
			description: computed(() => this.Resources.IDENTIFICATION_NUMBE11999),
		}).cloneFrom(values?.ValIdentifi))
		watch(() => this.ValIdentifi.value, (newValue, oldValue) => this.onUpdate('perso.identifi', this.ValIdentifi, newValue, oldValue))

		this.ValGender = reactive(new modelFieldType.String({
			id: 'ValGender',
			originId: 'ValGender',
			area: 'PERSO',
			field: 'GENDER',
			arrayOptions: qProjArrays.QArrayGender.setResources(vm.$getResource).elements,
			maxLength: 1,
			description: computed(() => this.Resources.GENDER44172),
		}).cloneFrom(values?.ValGender))
		watch(() => this.ValGender.value, (newValue, oldValue) => this.onUpdate('perso.gender', this.ValGender, newValue, oldValue))

		this.ValEmail = reactive(new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'PERSO',
			field: 'EMAIL',
			maxLength: 254,
			description: computed(() => this.Resources.E_MAIL42251),
		}).cloneFrom(values?.ValEmail))
		watch(() => this.ValEmail.value, (newValue, oldValue) => this.onUpdate('perso.email', this.ValEmail, newValue, oldValue))

		this.ValDob = reactive(new modelFieldType.Date({
			id: 'ValDob',
			originId: 'ValDob',
			area: 'PERSO',
			field: 'DOB',
			description: computed(() => this.Resources.DATE_OF_BIRTH63058),
		}).cloneFrom(values?.ValDob))
		watch(() => this.ValDob.value, (newValue, oldValue) => this.onUpdate('perso.dob', this.ValDob, newValue, oldValue))

		this.ValTob = reactive(new modelFieldType.Time({
			id: 'ValTob',
			originId: 'ValTob',
			area: 'PERSO',
			field: 'TOB',
			description: computed(() => this.Resources.TIME_OF_BIRTH04797),
		}).cloneFrom(values?.ValTob))
		watch(() => this.ValTob.value, (newValue, oldValue) => this.onUpdate('perso.tob', this.ValTob, newValue, oldValue))

		this.ValYear = reactive(new modelFieldType.Number({
			id: 'ValYear',
			originId: 'ValYear',
			area: 'PERSO',
			field: 'YEAR',
			maxDigits: 4,
			decimalDigits: 0,
			description: computed(() => this.Resources.YEAR61794),
		}).cloneFrom(values?.ValYear))
		watch(() => this.ValYear.value, (newValue, oldValue) => this.onUpdate('perso.year', this.ValYear, newValue, oldValue))

		this.ValMonth = reactive(new modelFieldType.Number({
			id: 'ValMonth',
			originId: 'ValMonth',
			area: 'PERSO',
			field: 'MONTH',
			arrayOptions: qProjArrays.QArrayMonths.setResources(vm.$getResource).elements,
			maxDigits: 2,
			decimalDigits: 0,
			description: computed(() => this.Resources.MONTH46035),
		}).cloneFrom(values?.ValMonth))
		watch(() => this.ValMonth.value, (newValue, oldValue) => this.onUpdate('perso.month', this.ValMonth, newValue, oldValue))

		this.ValCreatusr = reactive(new modelFieldType.String({
			id: 'ValCreatusr',
			originId: 'ValCreatusr',
			area: 'PERSO',
			field: 'CREATUSR',
			maxLength: 20,
			description: computed(() => this.Resources.CREATED_BY12292),
			isFixed: true,
		}).cloneFrom(values?.ValCreatusr))
		watch(() => this.ValCreatusr.value, (newValue, oldValue) => this.onUpdate('perso.creatusr', this.ValCreatusr, newValue, oldValue))

		this.ValCreatdat = reactive(new modelFieldType.Date({
			id: 'ValCreatdat',
			originId: 'ValCreatdat',
			area: 'PERSO',
			field: 'CREATDAT',
			description: computed(() => this.Resources.CREATED_ON00051),
			isFixed: true,
		}).cloneFrom(values?.ValCreatdat))
		watch(() => this.ValCreatdat.value, (newValue, oldValue) => this.onUpdate('perso.creatdat', this.ValCreatdat, newValue, oldValue))

		this.ValModifusr = reactive(new modelFieldType.String({
			id: 'ValModifusr',
			originId: 'ValModifusr',
			area: 'PERSO',
			field: 'MODIFUSR',
			maxLength: 20,
			description: computed(() => this.Resources.MODIFIED_BY02094),
			isFixed: true,
		}).cloneFrom(values?.ValModifusr))
		watch(() => this.ValModifusr.value, (newValue, oldValue) => this.onUpdate('perso.modifusr', this.ValModifusr, newValue, oldValue))

		this.ValModifdat = reactive(new modelFieldType.Date({
			id: 'ValModifdat',
			originId: 'ValModifdat',
			area: 'PERSO',
			field: 'MODIFDAT',
			description: computed(() => this.Resources.MODIFIED_ON31953),
			isFixed: true,
		}).cloneFrom(values?.ValModifdat))
		watch(() => this.ValModifdat.value, (newValue, oldValue) => this.onUpdate('perso.modifdat', this.ValModifdat, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormPersoViewModel instance.
	 * @returns {QFormPersoViewModel} A new instance of QFormPersoViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodperso'

	get QPrimaryKey() { return this.ValCodperso.value }
	set QPrimaryKey(value) { this.ValCodperso.updateValue(value) }
}
