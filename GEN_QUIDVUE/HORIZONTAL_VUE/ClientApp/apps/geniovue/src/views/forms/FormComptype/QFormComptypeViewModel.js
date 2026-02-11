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
			name: 'COMPTYPE',
			area: 'COMPO',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Comptype',
				updateFilesTickets: 'UpdateFilesTicketsComptype',
				setFile: 'SetFileComptype'
			}
		})

		/** The primary key. */
		this.ValCodcompo = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcompo',
			originId: 'ValCodcompo',
			area: 'COMPO',
			field: 'CODCOMPO',
			description: '',
		}).cloneFrom(values?.ValCodcompo))
		this.stopWatchers.push(watch(() => this.ValCodcompo.value, (newValue, oldValue) => this.onUpdate('compo.codcompo', this.ValCodcompo, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodcompc = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcompc',
			originId: 'ValCodcompc',
			area: 'COMPO',
			field: 'CODCOMPC',
			relatedArea: 'COMPC',
			description: computed(() => this.Resources.COMPONENTS_CLASS59339),
		}).cloneFrom(values?.ValCodcompc))
		this.stopWatchers.push(watch(() => this.ValCodcompc.value, (newValue, oldValue) => this.onUpdate('compo.codcompc', this.ValCodcompc, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValComptype = reactive(new modelFieldType.String({
			id: 'ValComptype',
			originId: 'ValComptype',
			area: 'COMPO',
			field: 'COMPTYPE',
			maxLength: 50,
			description: computed(() => this.Resources.COMPONENT_TYPE41163),
		}).cloneFrom(values?.ValComptype))
		this.stopWatchers.push(watch(() => this.ValComptype.value, (newValue, oldValue) => this.onUpdate('compo.comptype', this.ValComptype, newValue, oldValue)))

		this.ValCompicon = reactive(new modelFieldType.Number({
			id: 'ValCompicon',
			originId: 'ValCompicon',
			area: 'COMPO',
			field: 'COMPICON',
			maxDigits: 1,
			decimalDigits: 0,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: iif ([COMPC->COMPCLAS] == "Media", 1, iif ([COMPC->COMPCLAS] == "Data Input", 2, iif ([COMPC->COMPCLAS] == "Data Grid", 3, iif ([COMPC->COMPCLAS] == "Action", 4, iif ([COMPC->COMPCLAS] == "Container", 5, iif ([COMPC->COMPCLAS] == "Data Display", 6, iif ([COMPC->COMPCLAS] == "Interactive", 7, 8)))))))
					return qApi.iif(this.TableCompcCompclas.value==="Media",1,qApi.iif(this.TableCompcCompclas.value==="Data Input",2,qApi.iif(this.TableCompcCompclas.value==="Data Grid",3,qApi.iif(this.TableCompcCompclas.value==="Action",4,qApi.iif(this.TableCompcCompclas.value==="Container",5,qApi.iif(this.TableCompcCompclas.value==="Data Display",6,qApi.iif(this.TableCompcCompclas.value==="Interactive",7,8)))))))
				},
				dependencyEvents: ['fieldChange:compc.compclas'],
				isServerRecalc: false,
				isEmpty: qApi.emptyN,
			},
			arrayOptions: computed(() => new qProjArrays.QArrayComponenticons(vm.$getResource).elements),
			description: computed(() => this.Resources.COMPONENT_CLASS57908),
		}).cloneFrom(values?.ValCompicon))
		this.stopWatchers.push(watch(() => this.ValCompicon.value, (newValue, oldValue) => this.onUpdate('compo.compicon', this.ValCompicon, newValue, oldValue)))

		this.ValCompdesc = reactive(new modelFieldType.MultiLineString({
			id: 'ValCompdesc',
			originId: 'ValCompdesc',
			area: 'COMPO',
			field: 'COMPDESC',
			description: computed(() => this.Resources.COMPONENT_DESCRIPTIO08871),
		}).cloneFrom(values?.ValCompdesc))
		this.stopWatchers.push(watch(() => this.ValCompdesc.value, (newValue, oldValue) => this.onUpdate('compo.compdesc', this.ValCompdesc, newValue, oldValue)))

		this.TableCompcCompclas = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCompcCompclas',
			originId: 'ValCompclas',
			area: 'COMPC',
			field: 'COMPCLAS',
			maxLength: 50,
			description: computed(() => this.Resources.COMPONENTS_CLASS59339),
		}).cloneFrom(values?.TableCompcCompclas))
		this.stopWatchers.push(watch(() => this.TableCompcCompclas.value, (newValue, oldValue) => this.onUpdate('compc.compclas', this.TableCompcCompclas, newValue, oldValue)))

		this.ValCdatatyp = reactive(new modelFieldType.String({
			id: 'ValCdatatyp',
			originId: 'ValCdatatyp',
			area: 'COMPO',
			field: 'CDATATYP',
			maxLength: 50,
			description: computed(() => this.Resources.DATA_TYPE47159),
		}).cloneFrom(values?.ValCdatatyp))
		this.stopWatchers.push(watch(() => this.ValCdatatyp.value, (newValue, oldValue) => this.onUpdate('compo.cdatatyp', this.ValCdatatyp, newValue, oldValue)))

		this.ValRelease = reactive(new modelFieldType.String({
			id: 'ValRelease',
			originId: 'ValRelease',
			area: 'COMPO',
			field: 'RELEASE',
			maxLength: 6,
			maskType: 'MP',
			maskFormat: '000.00',
			maskRequired: '000.00',
			description: computed(() => this.Resources.RELEASE_VERSION03981),
		}).cloneFrom(values?.ValRelease))
		this.stopWatchers.push(watch(() => this.ValRelease.value, (newValue, oldValue) => this.onUpdate('compo.release', this.ValRelease, newValue, oldValue)))

		this.ValMvc = reactive(new modelFieldType.Boolean({
			id: 'ValMvc',
			originId: 'ValMvc',
			area: 'COMPO',
			field: 'MVC',
			description: computed(() => this.Resources.MVC48022),
		}).cloneFrom(values?.ValMvc))
		this.stopWatchers.push(watch(() => this.ValMvc.value, (newValue, oldValue) => this.onUpdate('compo.mvc', this.ValMvc, newValue, oldValue)))

		this.ValVuemvc = reactive(new modelFieldType.Boolean({
			id: 'ValVuemvc',
			originId: 'ValVuemvc',
			area: 'COMPO',
			field: 'VUEMVC',
			description: computed(() => this.Resources.VUE05393),
		}).cloneFrom(values?.ValVuemvc))
		this.stopWatchers.push(watch(() => this.ValVuemvc.value, (newValue, oldValue) => this.onUpdate('compo.vuemvc', this.ValVuemvc, newValue, oldValue)))

		this.ValPreview = reactive(new modelFieldType.Image({
			id: 'ValPreview',
			originId: 'ValPreview',
			area: 'COMPO',
			field: 'PREVIEW',
			description: computed(() => this.Resources.PREVIEW45357),
		}).cloneFrom(values?.ValPreview))
		this.stopWatchers.push(watch(() => this.ValPreview.value, (newValue, oldValue) => this.onUpdate('compo.preview', this.ValPreview, newValue, oldValue)))

		this.ValWuse = reactive(new modelFieldType.MultiLineString({
			id: 'ValWuse',
			originId: 'ValWuse',
			area: 'COMPO',
			field: 'WUSE',
			description: computed(() => this.Resources.WHEN_TO_USE63699),
		}).cloneFrom(values?.ValWuse))
		this.stopWatchers.push(watch(() => this.ValWuse.value, (newValue, oldValue) => this.onUpdate('compo.wuse', this.ValWuse, newValue, oldValue)))

		this.ValWnuse = reactive(new modelFieldType.MultiLineString({
			id: 'ValWnuse',
			originId: 'ValWnuse',
			area: 'COMPO',
			field: 'WNUSE',
			description: computed(() => this.Resources.WHEN_NOT_TO_USE63828),
		}).cloneFrom(values?.ValWnuse))
		this.stopWatchers.push(watch(() => this.ValWnuse.value, (newValue, oldValue) => this.onUpdate('compo.wnuse', this.ValWnuse, newValue, oldValue)))

		this.ValAccessib = reactive(new modelFieldType.MultiLineString({
			id: 'ValAccessib',
			originId: 'ValAccessib',
			area: 'COMPO',
			field: 'ACCESSIB',
			description: computed(() => this.Resources.ACCESIBILTY_COMPLIAN11604),
		}).cloneFrom(values?.ValAccessib))
		this.stopWatchers.push(watch(() => this.ValAccessib.value, (newValue, oldValue) => this.onUpdate('compo.accessib', this.ValAccessib, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormComptypeViewModel instance.
	 * @returns {QFormComptypeViewModel} A new instance of QFormComptypeViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcompo'

	get QPrimaryKey() { return this.ValCodcompo.value }
	set QPrimaryKey(value) { this.ValCodcompo.updateValue(value) }
}
