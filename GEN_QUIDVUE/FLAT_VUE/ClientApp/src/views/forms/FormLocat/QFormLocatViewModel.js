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
			name: 'LOCAT',
			area: 'LOCAT',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_LOCAT'
			}
		})

		/** The primary key. */
		this.ValCodlocat = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodlocat',
			originId: 'ValCodlocat',
			area: 'LOCAT',
			field: 'CODLOCAT',
			description: '',
		}).cloneFrom(values?.ValCodlocat))
		watch(() => this.ValCodlocat.value, (newValue, oldValue) => this.onUpdate('locat.codlocat', this.ValCodlocat, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodentit = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodentit',
			originId: 'ValCodentit',
			area: 'LOCAT',
			field: 'CODENTIT',
			relatedArea: 'ENTIT',
			description: '',
		}).cloneFrom(values?.ValCodentit))
		watch(() => this.ValCodentit.value, (newValue, oldValue) => this.onUpdate('locat.codentit', this.ValCodentit, newValue, oldValue))

		this.ValCodfacil = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodfacil',
			originId: 'ValCodfacil',
			area: 'LOCAT',
			field: 'CODFACIL',
			relatedArea: 'FACIL',
			description: '',
		}).cloneFrom(values?.ValCodfacil))
		watch(() => this.ValCodfacil.value, (newValue, oldValue) => this.onUpdate('locat.codfacil', this.ValCodfacil, newValue, oldValue))

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

		this.TableFacilName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableFacilName',
			originId: 'ValName',
			area: 'FACIL',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.FACILITY_NAME19514),
		}).cloneFrom(values?.TableFacilName))
		watch(() => this.TableFacilName.value, (newValue, oldValue) => this.onUpdate('facil.name', this.TableFacilName, newValue, oldValue))

		this.ValGln = reactive(new modelFieldType.String({
			id: 'ValGln',
			originId: 'ValGln',
			area: 'LOCAT',
			field: 'GLN',
			maxLength: 50,
			description: computed(() => this.Resources.GLOBAL_LOCATION_NUMB24637),
		}).cloneFrom(values?.ValGln))
		watch(() => this.ValGln.value, (newValue, oldValue) => this.onUpdate('locat.gln', this.ValGln, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormLocatViewModel instance.
	 * @returns {QFormLocatViewModel} A new instance of QFormLocatViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodlocat'

	get QPrimaryKey() { return this.ValCodlocat.value }
	set QPrimaryKey(value) { this.ValCodlocat.updateValue(value) }
}
