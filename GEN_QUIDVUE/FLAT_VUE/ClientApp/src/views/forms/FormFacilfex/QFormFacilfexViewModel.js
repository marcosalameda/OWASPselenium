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
			name: 'FACILFEX',
			area: 'FACIL',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_FACILFEX'
			}
		})

		/** The primary key. */
		this.ValCodfacil = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodfacil',
			originId: 'ValCodfacil',
			area: 'FACIL',
			field: 'CODFACIL',
			description: '',
		}).cloneFrom(values?.ValCodfacil))
		watch(() => this.ValCodfacil.value, (newValue, oldValue) => this.onUpdate('facil.codfacil', this.ValCodfacil, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodentit = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodentit',
			originId: 'ValCodentit',
			area: 'FACIL',
			field: 'CODENTIT',
			relatedArea: 'ENTIT',
			description: '',
		}).cloneFrom(values?.ValCodentit))
		watch(() => this.ValCodentit.value, (newValue, oldValue) => this.onUpdate('facil.codentit', this.ValCodentit, newValue, oldValue))

		this.ValCodfacty = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodfacty',
			originId: 'ValCodfacty',
			area: 'FACIL',
			field: 'CODFACTY',
			relatedArea: 'FACTY',
			description: computed(() => this.Resources.__FACILITY_TYPE27254),
			valueFormula: {
				stopRecalcCondition() { return false },
				execCondition() { return qApi.emptyG(this.ValCodfacty.value) },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: [GLOB->CODFACTY]
					// eslint-disable-next-line eqeqeq
					return this.tGlob.ValCodfacty.value
				},
				dependencyEvents: ['fieldChange:glob.codfacty'],
				isServerRecalc: false,
				isServerFormula: false,
				isEmpty: qApi.emptyG,
			},
		}).cloneFrom(values?.ValCodfacty))
		watch(() => this.ValCodfacty.value, (newValue, oldValue) => this.onUpdate('facil.codfacty', this.ValCodfacty, newValue, oldValue))

		/** The remaining form fields. */
		this.TableEntitName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableEntitName',
			originId: 'ValName',
			area: 'ENTIT',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.LEGAL_NAME42902),
		}).cloneFrom(values?.TableEntitName))
		watch(() => this.TableEntitName.value, (newValue, oldValue) => this.onUpdate('entit.name', this.TableEntitName, newValue, oldValue))

		this.ValIncorpor = reactive(new modelFieldType.Date({
			id: 'ValIncorpor',
			originId: 'ValIncorpor',
			area: 'FACIL',
			field: 'INCORPOR',
			description: computed(() => this.Resources.INCORPORATION10135),
		}).cloneFrom(values?.ValIncorpor))
		watch(() => this.ValIncorpor.value, (newValue, oldValue) => this.onUpdate('facil.incorpor', this.ValIncorpor, newValue, oldValue))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'FACIL',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.FACILITY_NAME19514),
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('facil.name', this.ValName, newValue, oldValue))

		this.ValFaciltyp = reactive(new modelFieldType.String({
			id: 'ValFaciltyp',
			originId: 'ValFaciltyp',
			area: 'FACIL',
			field: 'FACILTYP',
			arrayOptions: qProjArrays.QArrayFaciltyp.setResources(vm.$getResource).elements,
			maxLength: 1,
			description: computed(() => this.Resources.FACILITY_TYPE44577),
		}).cloneFrom(values?.ValFaciltyp))
		watch(() => this.ValFaciltyp.value, (newValue, oldValue) => this.onUpdate('facil.faciltyp', this.ValFaciltyp, newValue, oldValue))

		this.TableFactyType = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableFactyType',
			originId: 'ValType',
			area: 'FACTY',
			field: 'TYPE',
			maxLength: 25,
			description: computed(() => this.Resources.FACILITY_TYPE44577),
		}).cloneFrom(values?.TableFactyType))
		watch(() => this.TableFactyType.value, (newValue, oldValue) => this.onUpdate('facty.type', this.TableFactyType, newValue, oldValue))

		this.ValLatitude = reactive(new modelFieldType.Number({
			id: 'ValLatitude',
			originId: 'ValLatitude',
			area: 'FACIL',
			field: 'LATITUDE',
			maxDigits: 3,
			decimalDigits: 6,
			description: computed(() => this.Resources.LATITUDE11291),
		}).cloneFrom(values?.ValLatitude))
		watch(() => this.ValLatitude.value, (newValue, oldValue) => this.onUpdate('facil.latitude', this.ValLatitude, newValue, oldValue))

		this.ValLongitud = reactive(new modelFieldType.Number({
			id: 'ValLongitud',
			originId: 'ValLongitud',
			area: 'FACIL',
			field: 'LONGITUD',
			maxDigits: 3,
			decimalDigits: 6,
			description: computed(() => this.Resources.LONGITUDE01015),
		}).cloneFrom(values?.ValLongitud))
		watch(() => this.ValLongitud.value, (newValue, oldValue) => this.onUpdate('facil.longitud', this.ValLongitud, newValue, oldValue))

		this.ValAddress = reactive(new modelFieldType.String({
			id: 'ValAddress',
			originId: 'ValAddress',
			area: 'FACIL',
			field: 'ADDRESS',
			description: computed(() => this.Resources.ADDRESS04342),
		}).cloneFrom(values?.ValAddress))
		watch(() => this.ValAddress.value, (newValue, oldValue) => this.onUpdate('facil.address', this.ValAddress, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormFacilfexViewModel instance.
	 * @returns {QFormFacilfexViewModel} A new instance of QFormFacilfexViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodfacil'

	get QPrimaryKey() { return this.ValCodfacil.value }
	set QPrimaryKey(value) { this.ValCodfacil.value = value }
}
