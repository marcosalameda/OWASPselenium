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
import DNFormViewModelEquipmPseudaTags from '@/views/forms/FormEquipm/QGridFormEquipmPseudaTagsViewModel.js'
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
			name: 'EQUIPM',
			area: 'ASSET',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Equipm',
				updateFilesTickets: 'UpdateFilesTicketsEquipm',
				setFile: 'SetFileEquipm'
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

		/** The used foreign keys. */
		this.ValCodmanuf = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodmanuf',
			originId: 'ValCodmanuf',
			area: 'ASSET',
			field: 'CODMANUF',
			relatedArea: 'MANUF',
			description: '',
		}).cloneFrom(values?.ValCodmanuf))
		this.stopWatchers.push(watch(() => this.ValCodmanuf.value, (newValue, oldValue) => this.onUpdate('asset.codmanuf', this.ValCodmanuf, newValue, oldValue)))

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
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'ASSET',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.IDENTIFICATION_NAME16317),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('asset.name', this.ValName, newValue, oldValue)))

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

		this.ValIdenttyp = reactive(new modelFieldType.String({
			id: 'ValIdenttyp',
			originId: 'ValIdenttyp',
			area: 'ASSET',
			field: 'IDENTTYP',
			maxLength: 1,
			arrayOptions: computed(() => new qProjArrays.QArrayIdenttyp(vm.$getResource).elements),
			description: computed(() => this.Resources.IDENTIFIER_TYPE60623),
		}).cloneFrom(values?.ValIdenttyp))
		this.stopWatchers.push(watch(() => this.ValIdenttyp.value, (newValue, oldValue) => this.onUpdate('asset.identtyp', this.ValIdenttyp, newValue, oldValue)))

		this.ValGrai = reactive(new modelFieldType.String({
			id: 'ValGrai',
			originId: 'ValGrai',
			area: 'ASSET',
			field: 'GRAI',
			maxLength: 50,
			fillWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
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
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: [ASSET->IDENTTYP]=="R"
					return this.ValIdenttyp.value==="R"
				},
				dependencyEvents: ['fieldChange:asset.identtyp'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			description: computed(() => this.Resources.GRAI___GLOBAL_RETURN06821),
		}).cloneFrom(values?.ValGrai))
		this.stopWatchers.push(watch(() => this.ValGrai.value, (newValue, oldValue) => this.onUpdate('asset.grai', this.ValGrai, newValue, oldValue)))

		this.ValGiai = reactive(new modelFieldType.String({
			id: 'ValGiai',
			originId: 'ValGiai',
			area: 'ASSET',
			field: 'GIAI',
			maxLength: 50,
			fillWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
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
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: [ASSET->IDENTTYP]=="I"
					return this.ValIdenttyp.value==="I"
				},
				dependencyEvents: ['fieldChange:asset.identtyp'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			description: computed(() => this.Resources.GIAI___GLOBAL_INDIVI63214),
		}).cloneFrom(values?.ValGiai))
		this.stopWatchers.push(watch(() => this.ValGiai.value, (newValue, oldValue) => this.onUpdate('asset.giai', this.ValGiai, newValue, oldValue)))

		this.TableManufName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableManufName',
			originId: 'ValName',
			area: 'MANUF',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.LEGAL_NAME42902),
		}).cloneFrom(values?.TableManufName))
		this.stopWatchers.push(watch(() => this.TableManufName.value, (newValue, oldValue) => this.onUpdate('manuf.name', this.TableManufName, newValue, oldValue)))

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

		this.ValDescription = reactive(new modelFieldType.MultiLineString({
			id: 'ValDescription',
			originId: 'ValDescription',
			area: 'ASSET',
			field: 'DESCRIPT',
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescription))
		this.stopWatchers.push(watch(() => this.ValDescription.value, (newValue, oldValue) => this.onUpdate('asset.description', this.ValDescription, newValue, oldValue)))

		this.ValLongdesc = reactive(new modelFieldType.MultiLineString({
			type: 'MarkdownEditor',
			id: 'ValLongdesc',
			originId: 'ValLongdesc',
			area: 'ASSET',
			field: 'LONGDESC',
			description: computed(() => this.Resources.DETAILED_DESCRIPTION36560),
		}).cloneFrom(values?.ValLongdesc))
		this.stopWatchers.push(watch(() => this.ValLongdesc.value, (newValue, oldValue) => this.onUpdate('asset.longdesc', this.ValLongdesc, newValue, oldValue)))

		this.ValCategory = reactive(new modelFieldType.String({
			id: 'ValCategory',
			originId: 'ValCategory',
			area: 'ASSET',
			field: 'CATEGORY',
			maxLength: 5,
			arrayOptions: computed(() => new qProjArrays.QArrayAssetcategory(vm.$getResource).elements),
			description: computed(() => this.Resources.CATEGORY18978),
		}).cloneFrom(values?.ValCategory))
		this.stopWatchers.push(watch(() => this.ValCategory.value, (newValue, oldValue) => this.onUpdate('asset.category', this.ValCategory, newValue, oldValue)))

		this.ValBg_color = reactive(new modelFieldType.String({
			id: 'ValBg_color',
			originId: 'ValBg_color',
			area: 'ASSET',
			field: 'BG_COLOR',
			maxLength: 50,
			description: computed(() => this.Resources.BACKGROUND_COLOR_FOR59228),
		}).cloneFrom(values?.ValBg_color))
		this.stopWatchers.push(watch(() => this.ValBg_color.value, (newValue, oldValue) => this.onUpdate('asset.bg_color', this.ValBg_color, newValue, oldValue)))

		this.ValPhoto = reactive(new modelFieldType.Image({
			id: 'ValPhoto',
			originId: 'ValPhoto',
			area: 'ASSET',
			field: 'PHOTO',
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.ValPhoto))
		this.stopWatchers.push(watch(() => this.ValPhoto.value, (newValue, oldValue) => this.onUpdate('asset.photo', this.ValPhoto, newValue, oldValue)))
		/** The Grid Table List value. */
		this.ValA_tags = reactive(new modelFieldType.GridTableList({
			id: 'ValA_tags',
			area: 'ATAGS',
			field: 'A_TAGS',
			viewModelClass: DNFormViewModelEquipmPseudaTags,
		}, this.vueContext).cloneFrom(values?.ValA_tags))
		this.stopWatchers.push(watch(() => this.ValA_tags.value?.newElements, () => this.onUpdate('pseud.a_tags', this.ValA_tags, this.ValA_tags.value), { deep: true }))
		this.stopWatchers.push(watch(() => this.ValA_tags.value?.editedElements, () => this.onUpdate('pseud.a_tags', this.ValA_tags, this.ValA_tags.value), { deep: true }))
		this.stopWatchers.push(watch(() => this.ValA_tags.value?.removedElements, () => this.onUpdate('pseud.a_tags', this.ValA_tags, this.ValA_tags.value), { deep: true }))
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
