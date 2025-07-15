/* eslint-disable no-unused-vars */
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
/* eslint-enable no-unused-vars */

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
	// eslint-disable-next-line no-unused-vars
	constructor(vueContext, options, values)
	{
		super(vueContext, options)
		// eslint-disable-next-line no-unused-vars
		const vm = this.vueContext

		// The view model metadata
		_merge(this.modelInfo, {
			name: 'DISPA',
			area: 'DISPA',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Dispa',
				updateFilesTickets: 'UpdateFilesTicketsDispa',
				setFile: 'SetFileDispa'
			}
		})

		/** The primary key. */
		this.ValCoddispa = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCoddispa',
			originId: 'ValCoddispa',
			area: 'DISPA',
			field: 'CODDISPA',
			description: '',
		}).cloneFrom(values?.ValCoddispa))
		this.stopWatchers.push(watch(() => this.ValCoddispa.value, (newValue, oldValue) => this.onUpdate('dispa.coddispa', this.ValCoddispa, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCoddisst = reactive(new modelFieldType.ForeignKey({
			id: 'ValCoddisst',
			originId: 'ValCoddisst',
			area: 'DISPA',
			field: 'CODDISST',
			relatedArea: 'DISST',
			description: computed(() => this.Resources.___STATUS46938),
		}).cloneFrom(values?.ValCoddisst))
		this.stopWatchers.push(watch(() => this.ValCoddisst.value, (newValue, oldValue) => this.onUpdate('dispa.coddisst', this.ValCoddisst, newValue, oldValue)))

		this.ValCodentit = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodentit',
			originId: 'ValCodentit',
			area: 'DISPA',
			field: 'CODENTIT',
			relatedArea: 'ENTIT',
			description: computed(() => this.Resources.__CUSTOMER57515),
		}).cloneFrom(values?.ValCodentit))
		this.stopWatchers.push(watch(() => this.ValCodentit.value, (newValue, oldValue) => this.onUpdate('dispa.codentit', this.ValCodentit, newValue, oldValue)))

		this.ValCodperso = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodperso',
			originId: 'ValCodperso',
			area: 'DISPA',
			field: 'CODPERSO',
			relatedArea: 'PERSO',
			description: computed(() => this.Resources.__PERSON_RESPONSIBLE00553),
		}).cloneFrom(values?.ValCodperso))
		this.stopWatchers.push(watch(() => this.ValCodperso.value, (newValue, oldValue) => this.onUpdate('dispa.codperso', this.ValCodperso, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValDispadt = reactive(new modelFieldType.DateTime({
			id: 'ValDispadt',
			originId: 'ValDispadt',
			area: 'DISPA',
			field: 'DISPADT',
			description: computed(() => this.Resources.DISPATCH_DATE54413),
		}).cloneFrom(values?.ValDispadt))
		this.stopWatchers.push(watch(() => this.ValDispadt.value, (newValue, oldValue) => this.onUpdate('dispa.dispadt', this.ValDispadt, newValue, oldValue)))

		this.ValDispanr = reactive(new modelFieldType.Number({
			id: 'ValDispanr',
			originId: 'ValDispanr',
			area: 'DISPA',
			field: 'DISPANR',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.DISPATCH_NUMBER23616),
		}).cloneFrom(values?.ValDispanr))
		this.stopWatchers.push(watch(() => this.ValDispanr.value, (newValue, oldValue) => this.onUpdate('dispa.dispanr', this.ValDispanr, newValue, oldValue)))

		this.TableDisstStatus = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableDisstStatus',
			originId: 'ValStatus',
			area: 'DISST',
			field: 'STATUS',
			maxLength: 50,
			description: computed(() => this.Resources.STATUS62033),
		}).cloneFrom(values?.TableDisstStatus))
		this.stopWatchers.push(watch(() => this.TableDisstStatus.value, (newValue, oldValue) => this.onUpdate('disst.status', this.TableDisstStatus, newValue, oldValue)))

		this.ValStatus = reactive(new modelFieldType.String({
			id: 'ValStatus',
			originId: 'ValStatus',
			area: 'DISPA',
			field: 'STATUS',
			maxLength: 1,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: iif(emptyD([DISPA->DISPADT])==0,"D",iif(emptyD([DISPA->PREPARED])==0,"P","I"))
					return qApi.iif(qApi.emptyD(this.ValDispadt.value)===0,"D",qApi.iif(qApi.emptyD(this.ValPrepared.value)===0,"P","I"))
				},
				dependencyEvents: ['fieldChange:dispa.dispadt', 'fieldChange:dispa.prepared'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			arrayOptions: computed(() => new qProjArrays.QArrayDispstat(vm.$getResource).elements),
			description: computed(() => this.Resources.STATUS62033),
		}).cloneFrom(values?.ValStatus))
		this.stopWatchers.push(watch(() => this.ValStatus.value, (newValue, oldValue) => this.onUpdate('dispa.status', this.ValStatus, newValue, oldValue)))

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

		this.ValIsprepar = reactive(new modelFieldType.Boolean({
			id: 'ValIsprepar',
			originId: 'ValIsprepar',
			area: 'DISPA',
			field: 'ISPREPAR',
			description: computed(() => this.Resources.IS_PREPARED16113),
		}).cloneFrom(values?.ValIsprepar))
		this.stopWatchers.push(watch(() => this.ValIsprepar.value, (newValue, oldValue) => this.onUpdate('dispa.isprepar', this.ValIsprepar, newValue, oldValue)))

		this.ValPrepared = reactive(new modelFieldType.DateTime({
			id: 'ValPrepared',
			originId: 'ValPrepared',
			area: 'DISPA',
			field: 'PREPARED',
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: iif(emptyL([DISPA->ISPREPAR])==1,[ZEROD],[Today])
					return qApi.iif(qApi.emptyL((this.ValIsprepar.value ? 1 : 0))===1,'',qApi.Hoje())
				},
				dependencyEvents: ['fieldChange:dispa.isprepar'],
				isServerRecalc: false,
				isEmpty: qApi.emptyD,
			},
			description: computed(() => this.Resources.PREPARED38522),
		}).cloneFrom(values?.ValPrepared))
		this.stopWatchers.push(watch(() => this.ValPrepared.value, (newValue, oldValue) => this.onUpdate('dispa.prepared', this.ValPrepared, newValue, oldValue)))

		this.TablePersoName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePersoName',
			originId: 'ValName',
			area: 'PERSO',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.PERSON_NAME40980),
		}).cloneFrom(values?.TablePersoName))
		this.stopWatchers.push(watch(() => this.TablePersoName.value, (newValue, oldValue) => this.onUpdate('perso.name', this.TablePersoName, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormDispaViewModel instance.
	 * @returns {QFormDispaViewModel} A new instance of QFormDispaViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCoddispa'

	get QPrimaryKey() { return this.ValCoddispa.value }
	set QPrimaryKey(value) { this.ValCoddispa.updateValue(value) }
}
