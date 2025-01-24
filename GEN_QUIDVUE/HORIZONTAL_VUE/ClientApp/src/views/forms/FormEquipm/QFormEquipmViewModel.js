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
			name: 'EQUIPM',
			area: 'ASSET',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_EQUIPM'
			}
		})

		/** The primary key. */
		this.ValCodasset = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodasset',
			originId: 'ValCodasset',
			area: 'ASSET',
			field: 'CODASSET',
			description: '',
		}).cloneFrom(values?.ValCodasset))
		watch(() => this.ValCodasset.value, (newValue, oldValue) => this.onUpdate('asset.codasset', this.ValCodasset, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodmanuf = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodmanuf',
			originId: 'ValCodmanuf',
			area: 'ASSET',
			field: 'CODMANUF',
			relatedArea: 'MANUF',
			description: '',
		}).cloneFrom(values?.ValCodmanuf))
		watch(() => this.ValCodmanuf.value, (newValue, oldValue) => this.onUpdate('asset.codmanuf', this.ValCodmanuf, newValue, oldValue))

		this.ValCodkinde = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodkinde',
			originId: 'ValCodkinde',
			area: 'ASSET',
			field: 'CODKINDE',
			relatedArea: 'KINDE',
			description: computed(() => this.Resources.__KIND_OF_EQUIPMENT01899),
		}).cloneFrom(values?.ValCodkinde))
		watch(() => this.ValCodkinde.value, (newValue, oldValue) => this.onUpdate('asset.codkinde', this.ValCodkinde, newValue, oldValue))

		/** The remaining form fields. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'ASSET',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.IDENTIFICATION_NAME16317),
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('asset.name', this.ValName, newValue, oldValue))

		this.ValAssettyp = reactive(new modelFieldType.String({
			id: 'ValAssettyp',
			originId: 'ValAssettyp',
			area: 'ASSET',
			field: 'ASSETTYP',
			arrayOptions: qProjArrays.QArrayAssettyp.setResources(vm.$getResource).elements,
			maxLength: 1,
			description: computed(() => this.Resources.ASSET_TYPE02033),
		}).cloneFrom(values?.ValAssettyp))
		watch(() => this.ValAssettyp.value, (newValue, oldValue) => this.onUpdate('asset.assettyp', this.ValAssettyp, newValue, oldValue))

		this.ValAssetnum = reactive(new modelFieldType.Number({
			id: 'ValAssetnum',
			originId: 'ValAssetnum',
			area: 'ASSET',
			field: 'ASSETNUM',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.ASSET_NUMBER52372),
		}).cloneFrom(values?.ValAssetnum))
		watch(() => this.ValAssetnum.value, (newValue, oldValue) => this.onUpdate('asset.assetnum', this.ValAssetnum, newValue, oldValue))

		this.ValIdenttyp = reactive(new modelFieldType.String({
			id: 'ValIdenttyp',
			originId: 'ValIdenttyp',
			area: 'ASSET',
			field: 'IDENTTYP',
			arrayOptions: qProjArrays.QArrayIdenttyp.setResources(vm.$getResource).elements,
			maxLength: 1,
			description: computed(() => this.Resources.IDENTIFIER_TYPE60623),
		}).cloneFrom(values?.ValIdenttyp))
		watch(() => this.ValIdenttyp.value, (newValue, oldValue) => this.onUpdate('asset.identtyp', this.ValIdenttyp, newValue, oldValue))

		this.ValGrai = reactive(new modelFieldType.String({
			id: 'ValGrai',
			originId: 'ValGrai',
			area: 'ASSET',
			field: 'GRAI',
			maxLength: 50,
			description: computed(() => this.Resources.GRAI___GLOBAL_RETURN06821),
			fillWhen: {
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: [ASSET->IDENTTYP]=="R"
					return this.ValIdenttyp.value==="R"
				},
				dependencyEvents: ['fieldChange:asset.identtyp'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			showWhen: {
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: [ASSET->IDENTTYP]=="R"
					return this.ValIdenttyp.value==="R"
				},
				dependencyEvents: ['fieldChange:asset.identtyp'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
		}).cloneFrom(values?.ValGrai))
		watch(() => this.ValGrai.value, (newValue, oldValue) => this.onUpdate('asset.grai', this.ValGrai, newValue, oldValue))

		this.ValGiai = reactive(new modelFieldType.String({
			id: 'ValGiai',
			originId: 'ValGiai',
			area: 'ASSET',
			field: 'GIAI',
			maxLength: 50,
			description: computed(() => this.Resources.GIAI___GLOBAL_INDIVI63214),
			fillWhen: {
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: [ASSET->IDENTTYP]=="I"
					return this.ValIdenttyp.value==="I"
				},
				dependencyEvents: ['fieldChange:asset.identtyp'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			showWhen: {
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: [ASSET->IDENTTYP]=="I"
					return this.ValIdenttyp.value==="I"
				},
				dependencyEvents: ['fieldChange:asset.identtyp'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
		}).cloneFrom(values?.ValGiai))
		watch(() => this.ValGiai.value, (newValue, oldValue) => this.onUpdate('asset.giai', this.ValGiai, newValue, oldValue))

		this.TableManufName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableManufName',
			originId: 'ValName',
			area: 'MANUF',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.LEGAL_NAME42902),
		}).cloneFrom(values?.TableManufName))
		watch(() => this.TableManufName.value, (newValue, oldValue) => this.onUpdate('manuf.name', this.TableManufName, newValue, oldValue))

		this.TableKindeDesignat = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableKindeDesignat',
			originId: 'ValDesignat',
			area: 'KINDE',
			field: 'DESIGNAT',
			maxLength: 85,
			description: computed(() => this.Resources.KIND_OF_EQUIPMENT22928),
		}).cloneFrom(values?.TableKindeDesignat))
		watch(() => this.TableKindeDesignat.value, (newValue, oldValue) => this.onUpdate('kinde.designat', this.TableKindeDesignat, newValue, oldValue))

		this.ValPhoto = reactive(new modelFieldType.Image({
			id: 'ValPhoto',
			originId: 'ValPhoto',
			area: 'ASSET',
			field: 'PHOTO',
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.ValPhoto))
		watch(() => this.ValPhoto.value, (newValue, oldValue) => this.onUpdate('asset.photo', this.ValPhoto, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormEquipmViewModel instance.
	 * @returns {QFormEquipmViewModel} A new instance of QFormEquipmViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodasset'

	get QPrimaryKey() { return this.ValCodasset.value }
	set QPrimaryKey(value) { this.ValCodasset.updateValue(value) }
}
