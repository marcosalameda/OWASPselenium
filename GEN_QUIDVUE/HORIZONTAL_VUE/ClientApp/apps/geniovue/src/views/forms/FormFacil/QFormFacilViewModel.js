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
			name: 'FACIL',
			area: 'FACIL',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Facil',
				updateFilesTickets: 'UpdateFilesTicketsFacil',
				setFile: 'SetFileFacil'
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
		this.stopWatchers.push(watch(() => this.ValCodfacil.value, (newValue, oldValue) => this.onUpdate('facil.codfacil', this.ValCodfacil, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValCodcntry = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcntry',
			originId: 'ValCodcntry',
			area: 'FACIL',
			field: 'CODCNTRY',
			relatedArea: 'CNTRY',
			isFixed: true,
			description: computed(() => this.Resources.___COUNTRY10061),
		}).cloneFrom(values?.ValCodcntry))
		this.stopWatchers.push(watch(() => this.ValCodcntry.value, (newValue, oldValue) => this.onUpdate('facil.codcntry', this.ValCodcntry, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodentit = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodentit',
			originId: 'ValCodentit',
			area: 'FACIL',
			field: 'CODENTIT',
			relatedArea: 'ENTIT',
			description: '',
		}).cloneFrom(values?.ValCodentit))
		this.stopWatchers.push(watch(() => this.ValCodentit.value, (newValue, oldValue) => this.onUpdate('facil.codentit', this.ValCodentit, newValue, oldValue)))

		this.ValCodfacty = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodfacty',
			originId: 'ValCodfacty',
			area: 'FACIL',
			field: 'CODFACTY',
			relatedArea: 'FACTY',
			valueFormula: {
				stopRecalcCondition() { return false },
				execCondition() { return qApi.emptyG(this.ValCodfacty.value) },
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: [GLOB->CODFACTY]
					return vm.model?.tGlob.ValCodfacty?.value
				},
				dependencyEvents: ['fieldChange:glob.codfacty'],
				isServerRecalc: false,
				isEmpty: qApi.emptyG,
			},
			description: computed(() => this.Resources.__FACILITY_TYPE27254),
		}).cloneFrom(values?.ValCodfacty))
		this.stopWatchers.push(watch(() => this.ValCodfacty.value, (newValue, oldValue) => this.onUpdate('facil.codfacty', this.ValCodfacty, newValue, oldValue)))

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
		this.stopWatchers.push(watch(() => this.TableEntitName.value, (newValue, oldValue) => this.onUpdate('entit.name', this.TableEntitName, newValue, oldValue)))

		this.ValIncorpor = reactive(new modelFieldType.Date({
			id: 'ValIncorpor',
			originId: 'ValIncorpor',
			area: 'FACIL',
			field: 'INCORPOR',
			description: computed(() => this.Resources.INCORPORATION10135),
		}).cloneFrom(values?.ValIncorpor))
		this.stopWatchers.push(watch(() => this.ValIncorpor.value, (newValue, oldValue) => this.onUpdate('facil.incorpor', this.ValIncorpor, newValue, oldValue)))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'FACIL',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.FACILITY_NAME19514),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('facil.name', this.ValName, newValue, oldValue)))

		this.ValFaciltyp = reactive(new modelFieldType.String({
			id: 'ValFaciltyp',
			originId: 'ValFaciltyp',
			area: 'FACIL',
			field: 'FACILTYP',
			maxLength: 1,
			arrayOptions: computed(() => new qProjArrays.QArrayFaciltyp(vm.$getResource).elements),
			description: computed(() => this.Resources.FACILITY_TYPE44577),
		}).cloneFrom(values?.ValFaciltyp))
		this.stopWatchers.push(watch(() => this.ValFaciltyp.value, (newValue, oldValue) => this.onUpdate('facil.faciltyp', this.ValFaciltyp, newValue, oldValue)))

		this.TableFactyType = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableFactyType',
			originId: 'ValType',
			area: 'FACTY',
			field: 'TYPE',
			maxLength: 25,
			description: computed(() => this.Resources.FACILITY_TYPE44577),
		}).cloneFrom(values?.TableFactyType))
		this.stopWatchers.push(watch(() => this.TableFactyType.value, (newValue, oldValue) => this.onUpdate('facty.type', this.TableFactyType, newValue, oldValue)))

		this.ValAddress = reactive(new modelFieldType.MultiLineString({
			id: 'ValAddress',
			originId: 'ValAddress',
			area: 'FACIL',
			field: 'ADDRESS',
			description: computed(() => this.Resources.ADDRESS04342),
		}).cloneFrom(values?.ValAddress))
		this.stopWatchers.push(watch(() => this.ValAddress.value, (newValue, oldValue) => this.onUpdate('facil.address', this.ValAddress, newValue, oldValue)))

		this.ValImage = reactive(new modelFieldType.Image({
			id: 'ValImage',
			originId: 'ValImage',
			area: 'FACIL',
			field: 'IMAGE',
			description: computed(() => this.Resources.IMAGE65174),
		}).cloneFrom(values?.ValImage))
		this.stopWatchers.push(watch(() => this.ValImage.value, (newValue, oldValue) => this.onUpdate('facil.image', this.ValImage, newValue, oldValue)))

		this.ValGpsinput = reactive(new modelFieldType.String({
			id: 'ValGpsinput',
			originId: 'ValGpsinput',
			area: 'FACIL',
			field: 'GPSINPUT',
			maxLength: 1,
			arrayOptions: computed(() => new qProjArrays.QArrayGpsinput(vm.$getResource).elements),
			description: computed(() => this.Resources.GPS_INPUT13625),
		}).cloneFrom(values?.ValGpsinput))
		this.stopWatchers.push(watch(() => this.ValGpsinput.value, (newValue, oldValue) => this.onUpdate('facil.gpsinput', this.ValGpsinput, newValue, oldValue)))

		this.ValLatitude = reactive(new modelFieldType.Number({
			id: 'ValLatitude',
			originId: 'ValLatitude',
			area: 'FACIL',
			field: 'LATITUDE',
			maxDigits: 3,
			decimalDigits: 6,
			description: computed(() => this.Resources.LATITUDE11291),
		}).cloneFrom(values?.ValLatitude))
		this.stopWatchers.push(watch(() => this.ValLatitude.value, (newValue, oldValue) => this.onUpdate('facil.latitude', this.ValLatitude, newValue, oldValue)))

		this.ValLongitud = reactive(new modelFieldType.Number({
			id: 'ValLongitud',
			originId: 'ValLongitud',
			area: 'FACIL',
			field: 'LONGITUD',
			maxDigits: 3,
			decimalDigits: 6,
			description: computed(() => this.Resources.LONGITUDE01015),
		}).cloneFrom(values?.ValLongitud))
		this.stopWatchers.push(watch(() => this.ValLongitud.value, (newValue, oldValue) => this.onUpdate('facil.longitud', this.ValLongitud, newValue, oldValue)))

		this.ValGeocoori = reactive(new modelFieldType.Coordinate({
			id: 'ValGeocoori',
			originId: 'ValGeocoori',
			area: 'FACIL',
			field: 'GEOCOORI',
			description: computed(() => this.Resources.GEOGRAPHICAL_COORDIN45869),
		}).cloneFrom(values?.ValGeocoori))
		this.stopWatchers.push(watch(() => this.ValGeocoori.value, (newValue, oldValue) => this.onUpdate('facil.geocoori', this.ValGeocoori, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFacilViewModel instance.
	 * @returns {QFormFacilViewModel} A new instance of QFormFacilViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodfacil'

	get QPrimaryKey() { return this.ValCodfacil.value }
	set QPrimaryKey(value) { this.ValCodfacil.updateValue(value) }
}
