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
			name: 'FACTY',
			area: 'FACTY',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Facty',
				updateFilesTickets: 'UpdateFilesTicketsFacty',
				setFile: 'SetFileFacty'
			}
		})

		/** The primary key. */
		this.ValCodfacty = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodfacty',
			originId: 'ValCodfacty',
			area: 'FACTY',
			field: 'CODFACTY',
			description: '',
		}).cloneFrom(values?.ValCodfacty))
		this.stopWatchers.push(watch(() => this.ValCodfacty.value, (newValue, oldValue) => this.onUpdate('facty.codfacty', this.ValCodfacty, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValType = reactive(new modelFieldType.String({
			id: 'ValType',
			originId: 'ValType',
			area: 'FACTY',
			field: 'TYPE',
			maxLength: 25,
			description: computed(() => this.Resources.FACILITY_TYPE44577),
		}).cloneFrom(values?.ValType))
		this.stopWatchers.push(watch(() => this.ValType.value, (newValue, oldValue) => this.onUpdate('facty.type', this.ValType, newValue, oldValue)))

		this.ValLayrname = reactive(new modelFieldType.String({
			id: 'ValLayrname',
			originId: 'ValLayrname',
			area: 'FACTY',
			field: 'LAYRNAME',
			maxLength: 50,
			description: computed(() => this.Resources.LAYER_NAME49545),
		}).cloneFrom(values?.ValLayrname))
		this.stopWatchers.push(watch(() => this.ValLayrname.value, (newValue, oldValue) => this.onUpdate('facty.layrname', this.ValLayrname, newValue, oldValue)))

		this.ValIconurl = reactive(new modelFieldType.String({
			id: 'ValIconurl',
			originId: 'ValIconurl',
			area: 'FACTY',
			field: 'ICONURL',
			maxLength: 50,
			description: computed(() => this.Resources.ICON_URL07016),
		}).cloneFrom(values?.ValIconurl))
		this.stopWatchers.push(watch(() => this.ValIconurl.value, (newValue, oldValue) => this.onUpdate('facty.iconurl', this.ValIconurl, newValue, oldValue)))

		this.ValShadowur = reactive(new modelFieldType.String({
			id: 'ValShadowur',
			originId: 'ValShadowur',
			area: 'FACTY',
			field: 'SHADOWUR',
			maxLength: 50,
			description: computed(() => this.Resources.SHADOW_URL57805),
		}).cloneFrom(values?.ValShadowur))
		this.stopWatchers.push(watch(() => this.ValShadowur.value, (newValue, oldValue) => this.onUpdate('facty.shadowur', this.ValShadowur, newValue, oldValue)))

		this.ValIconancx = reactive(new modelFieldType.Number({
			id: 'ValIconancx',
			originId: 'ValIconancx',
			area: 'FACTY',
			field: 'ICONANCX',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.ICON_ANCHOR__X_AXIS_18664),
		}).cloneFrom(values?.ValIconancx))
		this.stopWatchers.push(watch(() => this.ValIconancx.value, (newValue, oldValue) => this.onUpdate('facty.iconancx', this.ValIconancx, newValue, oldValue)))

		this.ValIconancy = reactive(new modelFieldType.Number({
			id: 'ValIconancy',
			originId: 'ValIconancy',
			area: 'FACTY',
			field: 'ICONANCY',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.ICON_ANCHOR__Y_AXIS_63725),
		}).cloneFrom(values?.ValIconancy))
		this.stopWatchers.push(watch(() => this.ValIconancy.value, (newValue, oldValue) => this.onUpdate('facty.iconancy', this.ValIconancy, newValue, oldValue)))

		this.ValIconheig = reactive(new modelFieldType.Number({
			id: 'ValIconheig',
			originId: 'ValIconheig',
			area: 'FACTY',
			field: 'ICONHEIG',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.ICON_HEIGHT61896),
		}).cloneFrom(values?.ValIconheig))
		this.stopWatchers.push(watch(() => this.ValIconheig.value, (newValue, oldValue) => this.onUpdate('facty.iconheig', this.ValIconheig, newValue, oldValue)))

		this.ValIconwid = reactive(new modelFieldType.Number({
			id: 'ValIconwid',
			originId: 'ValIconwid',
			area: 'FACTY',
			field: 'ICONWID',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.ICON_WIDTH02295),
		}).cloneFrom(values?.ValIconwid))
		this.stopWatchers.push(watch(() => this.ValIconwid.value, (newValue, oldValue) => this.onUpdate('facty.iconwid', this.ValIconwid, newValue, oldValue)))

		this.ValPopupanx = reactive(new modelFieldType.Number({
			id: 'ValPopupanx',
			originId: 'ValPopupanx',
			area: 'FACTY',
			field: 'POPUPANX',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.POPUP_ANCHOR__X_AXIS15060),
		}).cloneFrom(values?.ValPopupanx))
		this.stopWatchers.push(watch(() => this.ValPopupanx.value, (newValue, oldValue) => this.onUpdate('facty.popupanx', this.ValPopupanx, newValue, oldValue)))

		this.ValPopupany = reactive(new modelFieldType.Number({
			id: 'ValPopupany',
			originId: 'ValPopupany',
			area: 'FACTY',
			field: 'POPUPANY',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.POPUP_ANCHOR__Y_AXIS64670),
		}).cloneFrom(values?.ValPopupany))
		this.stopWatchers.push(watch(() => this.ValPopupany.value, (newValue, oldValue) => this.onUpdate('facty.popupany', this.ValPopupany, newValue, oldValue)))

		this.ValShadowax = reactive(new modelFieldType.Number({
			id: 'ValShadowax',
			originId: 'ValShadowax',
			area: 'FACTY',
			field: 'SHADOWAX',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.SHADOW_ANCHOR__X_AXI31230),
		}).cloneFrom(values?.ValShadowax))
		this.stopWatchers.push(watch(() => this.ValShadowax.value, (newValue, oldValue) => this.onUpdate('facty.shadowax', this.ValShadowax, newValue, oldValue)))

		this.ValShadoway = reactive(new modelFieldType.Number({
			id: 'ValShadoway',
			originId: 'ValShadoway',
			area: 'FACTY',
			field: 'SHADOWAY',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.SHADOW_ANCHOR__Y_AXI51495),
		}).cloneFrom(values?.ValShadoway))
		this.stopWatchers.push(watch(() => this.ValShadoway.value, (newValue, oldValue) => this.onUpdate('facty.shadoway', this.ValShadoway, newValue, oldValue)))

		this.ValShadowhe = reactive(new modelFieldType.Number({
			id: 'ValShadowhe',
			originId: 'ValShadowhe',
			area: 'FACTY',
			field: 'SHADOWHE',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.SHADOW_HEIGHT64343),
		}).cloneFrom(values?.ValShadowhe))
		this.stopWatchers.push(watch(() => this.ValShadowhe.value, (newValue, oldValue) => this.onUpdate('facty.shadowhe', this.ValShadowhe, newValue, oldValue)))

		this.ValShadowwi = reactive(new modelFieldType.Number({
			id: 'ValShadowwi',
			originId: 'ValShadowwi',
			area: 'FACTY',
			field: 'SHADOWWI',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.SHADOW_WIDTH01769),
		}).cloneFrom(values?.ValShadowwi))
		this.stopWatchers.push(watch(() => this.ValShadowwi.value, (newValue, oldValue) => this.onUpdate('facty.shadowwi', this.ValShadowwi, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFactyViewModel instance.
	 * @returns {QFormFactyViewModel} A new instance of QFormFactyViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodfacty'

	get QPrimaryKey() { return this.ValCodfacty.value }
	set QPrimaryKey(value) { this.ValCodfacty.updateValue(value) }
}
