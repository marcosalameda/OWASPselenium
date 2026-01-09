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
			name: 'LCEXT',
			area: 'LCEXT',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Lcext',
				updateFilesTickets: 'UpdateFilesTicketsLcext',
				setFile: 'SetFileLcext'
			}
		})

		/** The primary key. */
		this.ValCodlcext = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodlcext',
			originId: 'ValCodlcext',
			area: 'LCEXT',
			field: 'CODLCEXT',
			description: '',
		}).cloneFrom(values?.ValCodlcext))
		this.stopWatchers.push(watch(() => this.ValCodlcext.value, (newValue, oldValue) => this.onUpdate('lcext.codlcext', this.ValCodlcext, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodlocat = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodlocat',
			originId: 'ValCodlocat',
			area: 'LCEXT',
			field: 'CODLOCAT',
			relatedArea: 'LOCAT',
			description: '',
		}).cloneFrom(values?.ValCodlocat))
		this.stopWatchers.push(watch(() => this.ValCodlocat.value, (newValue, oldValue) => this.onUpdate('lcext.codlocat', this.ValCodlocat, newValue, oldValue)))

		/** The remaining form fields. */
		this.TableLocatGln = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableLocatGln',
			originId: 'ValGln',
			area: 'LOCAT',
			field: 'GLN',
			maxLength: 50,
			description: computed(() => this.Resources.GLOBAL_LOCATION_NUMB24637),
		}).cloneFrom(values?.TableLocatGln))
		this.stopWatchers.push(watch(() => this.TableLocatGln.value, (newValue, oldValue) => this.onUpdate('locat.gln', this.TableLocatGln, newValue, oldValue)))

		this.ValGlnext = reactive(new modelFieldType.String({
			id: 'ValGlnext',
			originId: 'ValGlnext',
			area: 'LCEXT',
			field: 'GLNEXT',
			maxLength: 50,
			description: computed(() => this.Resources.GLN_EXTENSION_COMPON55869),
		}).cloneFrom(values?.ValGlnext))
		this.stopWatchers.push(watch(() => this.ValGlnext.value, (newValue, oldValue) => this.onUpdate('lcext.glnext', this.ValGlnext, newValue, oldValue)))

		this.ValSpacetyp = reactive(new modelFieldType.String({
			id: 'ValSpacetyp',
			originId: 'ValSpacetyp',
			area: 'LCEXT',
			field: 'SPACETYP',
			maxLength: 1,
			arrayOptions: computed(() => new qProjArrays.QArraySpacetyp(vm.$getResource).elements),
			description: computed(() => this.Resources.SPACE_TYPE42493),
		}).cloneFrom(values?.ValSpacetyp))
		this.stopWatchers.push(watch(() => this.ValSpacetyp.value, (newValue, oldValue) => this.onUpdate('lcext.spacetyp', this.ValSpacetyp, newValue, oldValue)))

		this.ValSpaceobs = reactive(new modelFieldType.String({
			id: 'ValSpaceobs',
			originId: 'ValSpaceobs',
			area: 'LCEXT',
			field: 'SPACEOBS',
			maxLength: 50,
			fillWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: [LCEXT->SPACETYP]=="O"
					return this.ValSpacetyp.value==="O"
				},
				dependencyEvents: ['fieldChange:lcext.spacetyp'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			showWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: [LCEXT->SPACETYP]=="O"
					return this.ValSpacetyp.value==="O"
				},
				dependencyEvents: ['fieldChange:lcext.spacetyp'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			description: computed(() => this.Resources.SPACE62433),
		}).cloneFrom(values?.ValSpaceobs))
		this.stopWatchers.push(watch(() => this.ValSpaceobs.value, (newValue, oldValue) => this.onUpdate('lcext.spaceobs', this.ValSpaceobs, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormLcextViewModel instance.
	 * @returns {QFormLcextViewModel} A new instance of QFormLcextViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodlcext'

	get QPrimaryKey() { return this.ValCodlcext.value }
	set QPrimaryKey(value) { this.ValCodlcext.updateValue(value) }
}
