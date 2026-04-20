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
			name: 'ASSPA',
			area: 'ASSPA',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Asspa',
				updateFilesTickets: 'UpdateFilesTicketsAsspa',
				setFile: 'SetFileAsspa'
			}
		})

		/** The primary key. */
		this.ValCodasspa = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodasspa',
			originId: 'ValCodasspa',
			area: 'ASSPA',
			field: 'CODASSPA',
			description: '',
		}).cloneFrom(values?.ValCodasspa))
		this.stopWatchers.push(watch(() => this.ValCodasspa.value, (newValue, oldValue) => this.onUpdate('asspa.codasspa', this.ValCodasspa, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodasset = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodasset',
			originId: 'ValCodasset',
			area: 'ASSPA',
			field: 'CODASSET',
			relatedArea: 'ASSET',
			description: '',
		}).cloneFrom(values?.ValCodasset))
		this.stopWatchers.push(watch(() => this.ValCodasset.value, (newValue, oldValue) => this.onUpdate('asspa.codasset', this.ValCodasset, newValue, oldValue)))

		this.ValCodparam = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodparam',
			originId: 'ValCodparam',
			area: 'ASSPA',
			field: 'CODPARAM',
			relatedArea: 'PARAM',
			description: '',
		}).cloneFrom(values?.ValCodparam))
		this.stopWatchers.push(watch(() => this.ValCodparam.value, (newValue, oldValue) => this.onUpdate('asspa.codparam', this.ValCodparam, newValue, oldValue)))

		/** The remaining form fields. */
		this.TableAssetName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableAssetName',
			originId: 'ValName',
			area: 'ASSET',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.IDENTIFICATION_NAME16317),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableAssetName))
		this.stopWatchers.push(watch(() => this.TableAssetName.value, (newValue, oldValue) => this.onUpdate('asset.name', this.TableAssetName, newValue, oldValue)))

		this.ValDatatype = reactive(new modelFieldType.String({
			id: 'ValDatatype',
			originId: 'ValDatatype',
			area: 'ASSPA',
			field: 'DATATYPE',
			maxLength: 1,
			arrayOptions: computed(() => new qProjArrays.QArrayDatatype(vm.$getResource).elements),
			description: computed(() => this.Resources.DATA_TYPE47159),
		}).cloneFrom(values?.ValDatatype))
		this.stopWatchers.push(watch(() => this.ValDatatype.value, (newValue, oldValue) => this.onUpdate('asspa.datatype', this.ValDatatype, newValue, oldValue)))

		this.ValDecimalplaces = reactive(new modelFieldType.Number({
			id: 'ValDecimalplaces',
			originId: 'ValDecimalplaces',
			area: 'ASSPA',
			field: 'DECPLACE',
			maxDigits: 1,
			decimalDigits: 0,
			description: computed(() => this.Resources.DECIMAL_PLACES62575),
		}).cloneFrom(values?.ValDecimalplaces))
		this.stopWatchers.push(watch(() => this.ValDecimalplaces.value, (newValue, oldValue) => this.onUpdate('asspa.decimalplaces', this.ValDecimalplaces, newValue, oldValue)))

		this.TableParamParamete = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableParamParamete',
			originId: 'ValParameter',
			area: 'PARAM',
			field: 'PARAMETE',
			maxLength: 50,
			description: computed(() => this.Resources.PARAMETER41976),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableParamParamete))
		this.stopWatchers.push(watch(() => this.TableParamParamete.value, (newValue, oldValue) => this.onUpdate('param.parameter', this.TableParamParamete, newValue, oldValue)))

		this.ValText = reactive(new modelFieldType.String({
			id: 'ValText',
			originId: 'ValText',
			area: 'ASSPA',
			field: 'TEXT',
			maxLength: 50,
			description: computed(() => this.Resources.TEXT04938),
		}).cloneFrom(values?.ValText))
		this.stopWatchers.push(watch(() => this.ValText.value, (newValue, oldValue) => this.onUpdate('asspa.text', this.ValText, newValue, oldValue)))

		this.ValQuantity = reactive(new modelFieldType.Number({
			id: 'ValQuantity',
			originId: 'ValQuantity',
			area: 'ASSPA',
			field: 'QUANTITY',
			maxDigits: 7,
			decimalDigits: 4,
			description: computed(() => this.Resources.QUANTITY06415),
		}).cloneFrom(values?.ValQuantity))
		this.stopWatchers.push(watch(() => this.ValQuantity.value, (newValue, oldValue) => this.onUpdate('asspa.quantity', this.ValQuantity, newValue, oldValue)))

		this.ValDate = reactive(new modelFieldType.Date({
			id: 'ValDate',
			originId: 'ValDate',
			area: 'ASSPA',
			field: 'DATE',
			description: computed(() => this.Resources.DATE18475),
		}).cloneFrom(values?.ValDate))
		this.stopWatchers.push(watch(() => this.ValDate.value, (newValue, oldValue) => this.onUpdate('asspa.date', this.ValDate, newValue, oldValue)))

		this.ValToshow = reactive(new modelFieldType.String({
			id: 'ValToshow',
			originId: 'ValToshow',
			area: 'ASSPA',
			field: 'TOSHOW',
			maxLength: 50,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: iif([ASSPA->DATATYPE]=="T",[ASSPA->TEXT],iif([ASSPA->DATATYPE]=="N",NumericToString([ASSPA->QUANTITY],0),iif([ASSPA->DATATYPE]=="D",NumericToString(Year([ASSPA->DATE]),0)+"-"+RIGHT("00"+NumericToString(Month([ASSPA->DATE]),0),2)+"-"+RIGHT("00"+NumericToString(Day([ASSPA->DATE]),0),2),"") ) )
					return qApi.iif(this.ValDatatype.value==="T",this.ValText.value,qApi.iif(this.ValDatatype.value==="N",qApi.NumericToString(this.ValQuantity.value,0),qApi.iif(this.ValDatatype.value==="D",qApi.NumericToString(qApi.Year(this.ValDate.value),0)+"-"+qApi.RIGHT("00"+qApi.NumericToString(qApi.Month(this.ValDate.value),0),2)+"-"+qApi.RIGHT("00"+qApi.NumericToString(qApi.Day(this.ValDate.value),0),2),"")))
				},
				dependencyEvents: ['fieldChange:asspa.datatype', 'fieldChange:asspa.text', 'fieldChange:asspa.quantity', 'fieldChange:asspa.date'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			description: computed(() => this.Resources.TO_SHOW13268),
		}).cloneFrom(values?.ValToshow))
		this.stopWatchers.push(watch(() => this.ValToshow.value, (newValue, oldValue) => this.onUpdate('asspa.toshow', this.ValToshow, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormAsspaViewModel instance.
	 * @returns {QFormAsspaViewModel} A new instance of QFormAsspaViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodasspa'

	get QPrimaryKey() { return this.ValCodasspa.value }
	set QPrimaryKey(value) { this.ValCodasspa.updateValue(value) }
}
