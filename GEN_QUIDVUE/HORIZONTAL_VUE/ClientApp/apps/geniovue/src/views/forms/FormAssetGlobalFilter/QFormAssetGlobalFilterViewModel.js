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
			name: 'ASSET_GLOBAL_FILTER',
			area: 'ASSET',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Asset_global_filter',
				updateFilesTickets: 'UpdateFilesTicketsAsset_global_filter',
				setFile: 'SetFileAsset_global_filter'
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
		this.stopWatchers.push(watch(() => this.ValCodasset.value, (newValue, oldValue) => this.onUpdate('asset.codasset', this.ValCodasset, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValCodmanuf = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodmanuf',
			originId: 'ValCodmanuf',
			area: 'ASSET',
			field: 'CODMANUF',
			relatedArea: 'MANUF',
			isFixed: true,
			description: '',
		}).cloneFrom(values?.ValCodmanuf))
		this.stopWatchers.push(watch(() => this.ValCodmanuf.value, (newValue, oldValue) => this.onUpdate('asset.codmanuf', this.ValCodmanuf, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodkinde = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodkinde',
			originId: 'ValCodkinde',
			area: 'ASSET',
			field: 'CODKINDE',
			relatedArea: 'KINDE',
			description: computed(() => this.Resources.__KIND_OF_EQUIPMENT01899),
		}).cloneFrom(values?.ValCodkinde))
		this.stopWatchers.push(watch(() => this.ValCodkinde.value, (newValue, oldValue) => this.onUpdate('asset.codkinde', this.ValCodkinde, newValue, oldValue)))

		/** The remaining form fields. */
		this.TableKindeDesignat = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableKindeDesignat',
			originId: 'ValDesignat',
			area: 'KINDE',
			field: 'DESIGNAT',
			maxLength: 85,
			description: computed(() => this.Resources.KIND_OF_EQUIPMENT22928),
		}).cloneFrom(values?.TableKindeDesignat))
		this.stopWatchers.push(watch(() => this.TableKindeDesignat.value, (newValue, oldValue) => this.onUpdate('kinde.designat', this.TableKindeDesignat, newValue, oldValue)))

		this.ValAssetnum = reactive(new modelFieldType.Number({
			id: 'ValAssetnum',
			originId: 'ValAssetnum',
			area: 'ASSET',
			field: 'ASSETNUM',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.ASSET_NUMBER52372),
		}).cloneFrom(values?.ValAssetnum))
		this.stopWatchers.push(watch(() => this.ValAssetnum.value, (newValue, oldValue) => this.onUpdate('asset.assetnum', this.ValAssetnum, newValue, oldValue)))

		this.ValAssettyp = reactive(new modelFieldType.String({
			id: 'ValAssettyp',
			originId: 'ValAssettyp',
			area: 'ASSET',
			field: 'ASSETTYP',
			maxLength: 1,
			arrayOptions: computed(() => new qProjArrays.QArrayAssettyp(vm.$getResource).elements),
			description: computed(() => this.Resources.ASSET_TYPE02033),
		}).cloneFrom(values?.ValAssettyp))
		this.stopWatchers.push(watch(() => this.ValAssettyp.value, (newValue, oldValue) => this.onUpdate('asset.assettyp', this.ValAssettyp, newValue, oldValue)))

		this.TableParamParamete = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableParamParamete',
			originId: 'ValParameter',
			area: 'PARAM',
			field: 'PARAMETE',
			maxLength: 50,
			description: computed(() => this.Resources.PARAMETER41976),
			isGlobalFilterField: true,
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableParamParamete))
		this.stopWatchers.push(watch(() => this.TableParamParamete.value, (newValue, oldValue) => this.onUpdate('param.parameter', this.TableParamParamete, newValue, oldValue)))

		this.ParamValCodparamFilterKey = reactive(new modelFieldType.ForeignKey({
			id: 'ParamValCodparamFilterKey',
			originId: 'ParamValCodparamFilterKey',
			area: 'PARAM',
			field: 'CODPARAM',
			relatedArea: 'global-filter-PARAM',// History entry key
			isGlobalFilterField: true,
			ignoreFldSubmit: true
		}).cloneFrom(values?.ParamValCodparamFilterKey))
		this.stopWatchers.push(watch(() => this.ParamValCodparamFilterKey.value, (newValue, oldValue) => this.onUpdate('param.codparam', this.ParamValCodparamFilterKey, newValue, oldValue)))

		/** The form fields used only in formulas. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'ASSET',
			field: 'NAME',
			maxLength: 85,
			isFixed: true,
			description: computed(() => this.Resources.IDENTIFICATION_NAME16317),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('asset.name', this.ValName, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormAssetGlobalFilterViewModel instance.
	 * @returns {QFormAssetGlobalFilterViewModel} A new instance of QFormAssetGlobalFilterViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodasset'

	get QPrimaryKey() { return this.ValCodasset.value }
	set QPrimaryKey(value) { this.ValCodasset.updateValue(value) }
}
