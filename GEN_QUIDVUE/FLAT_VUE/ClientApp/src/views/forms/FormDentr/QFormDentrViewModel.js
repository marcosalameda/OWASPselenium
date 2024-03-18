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
			name: 'DENTR',
			area: 'INDOC',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_DENTR'
			}
		})

		/** The primary key. */
		this.ValCoddentr = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCoddentr',
			originId: 'ValCoddentr',
			area: 'INDOC',
			field: 'CODDENTR',
			description: '',
		}).cloneFrom(values?.ValCoddentr))
		watch(() => this.ValCoddentr.value, (newValue, oldValue) => this.onUpdate('indoc.coddentr', this.ValCoddentr, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodcntry = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcntry',
			originId: 'ValCodcntry',
			area: 'INDOC',
			field: 'CODCNTRY',
			relatedArea: 'CNTRY',
			description: '',
		}).cloneFrom(values?.ValCodcntry))
		watch(() => this.ValCodcntry.value, (newValue, oldValue) => this.onUpdate('indoc.codcntry', this.ValCodcntry, newValue, oldValue))

		this.ValCodempre = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodempre',
			originId: 'ValCodempre',
			area: 'INDOC',
			field: 'CODEMPRE',
			relatedArea: 'CMPNY',
			description: '',
		}).cloneFrom(values?.ValCodempre))
		watch(() => this.ValCodempre.value, (newValue, oldValue) => this.onUpdate('indoc.codempre', this.ValCodempre, newValue, oldValue))

		this.ValCodpesso = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpesso',
			originId: 'ValCodpesso',
			area: 'INDOC',
			field: 'CODPESSO',
			relatedArea: 'PESSO',
			description: '',
		}).cloneFrom(values?.ValCodpesso))
		watch(() => this.ValCodpesso.value, (newValue, oldValue) => this.onUpdate('indoc.codpesso', this.ValCodpesso, newValue, oldValue))

		this.ValCodwareh = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodwareh',
			originId: 'ValCodwareh',
			area: 'INDOC',
			field: 'CODWAREH',
			relatedArea: 'WARE1',
			description: computed(() => this.Resources.BY_OMISSION13050),
		}).cloneFrom(values?.ValCodwareh))
		watch(() => this.ValCodwareh.value, (newValue, oldValue) => this.onUpdate('indoc.codwareh', this.ValCodwareh, newValue, oldValue))

		/** The remaining form fields. */
		this.TableCntryCountry = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCntryCountry',
			originId: 'ValCountry',
			area: 'CNTRY',
			field: 'COUNTRY',
			maxLength: 90,
			description: computed(() => this.Resources.COUNTRY64133),
		}).cloneFrom(values?.TableCntryCountry))
		watch(() => this.TableCntryCountry.value, (newValue, oldValue) => this.onUpdate('cntry.country', this.TableCntryCountry, newValue, oldValue))

		this.TableCmpnyDesignat = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCmpnyDesignat',
			originId: 'ValDesignat',
			area: 'CMPNY',
			field: 'DESIGNAT',
			maxLength: 85,
			description: computed(() => this.Resources.DESIGNATION35876),
		}).cloneFrom(values?.TableCmpnyDesignat))
		watch(() => this.TableCmpnyDesignat.value, (newValue, oldValue) => this.onUpdate('cmpny.designat', this.TableCmpnyDesignat, newValue, oldValue))

		this.TablePessoName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePessoName',
			originId: 'ValName',
			area: 'PESSO',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TablePessoName))
		watch(() => this.TablePessoName.value, (newValue, oldValue) => this.onUpdate('pesso.name', this.TablePessoName, newValue, oldValue))

		this.TableWare1Warehdes = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableWare1Warehdes',
			originId: 'ValWarehdes',
			area: 'WARE1',
			field: 'WAREHDES',
			maxLength: 85,
			description: computed(() => this.Resources.WAREHOUSE51864),
		}).cloneFrom(values?.TableWare1Warehdes))
		watch(() => this.TableWare1Warehdes.value, (newValue, oldValue) => this.onUpdate('ware1.warehdes', this.TableWare1Warehdes, newValue, oldValue))

		this.ValDate = reactive(new modelFieldType.DateTime({
			id: 'ValDate',
			originId: 'ValDate',
			area: 'INDOC',
			field: 'DATE',
			description: computed(() => this.Resources.DATE18475),
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: iif(emptyG([INDOC->CODWAREH])==1,[ZEROD],[INDOC->DHDOCUME])
					// eslint-disable-next-line eqeqeq
					return qApi.iif(qApi.emptyG(this.ValCodwareh.value)==1,'',this.ValDhdocume.value)
				},
				dependencyEvents: ['fieldChange:indoc.codwareh', 'fieldChange:indoc.dhdocume'],
				isServerRecalc: false,
				isServerFormula: false,
				isEmpty: qApi.emptyD,
			},
		}).cloneFrom(values?.ValDate))
		watch(() => this.ValDate.value, (newValue, oldValue) => this.onUpdate('indoc.date', this.ValDate, newValue, oldValue))

		this.ValDocumenr = reactive(new modelFieldType.Number({
			id: 'ValDocumenr',
			originId: 'ValDocumenr',
			area: 'INDOC',
			field: 'DOCUMENR',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.NO_14817),
		}).cloneFrom(values?.ValDocumenr))
		watch(() => this.ValDocumenr.value, (newValue, oldValue) => this.onUpdate('indoc.documenr', this.ValDocumenr, newValue, oldValue))

		this.ValDhdocume = reactive(new modelFieldType.DateTime({
			id: 'ValDhdocume',
			originId: 'ValDhdocume',
			area: 'INDOC',
			field: 'DHDOCUME',
			description: computed(() => this.Resources.DATE18475),
		}).cloneFrom(values?.ValDhdocume))
		watch(() => this.ValDhdocume.value, (newValue, oldValue) => this.onUpdate('indoc.dhdocume', this.ValDhdocume, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormDentrViewModel instance.
	 * @returns {QFormDentrViewModel} A new instance of QFormDentrViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCoddentr'

	get QPrimaryKey() { return this.ValCoddentr.value }
	set QPrimaryKey(value) { this.ValCoddentr.value = value }
}
