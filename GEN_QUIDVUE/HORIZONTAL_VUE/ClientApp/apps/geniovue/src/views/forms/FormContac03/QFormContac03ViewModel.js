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
			name: 'CONTAC03',
			area: 'PROCN',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_CONTAC03',
				updateFilesTickets: 'UpdateFilesTicketsCONTAC03'
			}
		})

		/** The primary key. */
		this.ValCodprocn = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodprocn',
			originId: 'ValCodprocn',
			area: 'PROCN',
			field: 'CODPROCN',
			description: '',
		}).cloneFrom(values?.ValCodprocn))
		watch(() => this.ValCodprocn.value, (newValue, oldValue) => this.onUpdate('procn.codprocn', this.ValCodprocn, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodprope = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodprope',
			originId: 'ValCodprope',
			area: 'PROCN',
			field: 'CODPROPE',
			relatedArea: 'PROPE',
			description: computed(() => this.Resources.PROPERTY43977),
		}).cloneFrom(values?.ValCodprope))
		watch(() => this.ValCodprope.value, (newValue, oldValue) => this.onUpdate('procn.codprope', this.ValCodprope, newValue, oldValue))

		/** The remaining form fields. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'PROCN',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('procn.name', this.ValName, newValue, oldValue))

		this.ValEmail = reactive(new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'PROCN',
			field: 'EMAIL',
			maxLength: 50,
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.ValEmail))
		watch(() => this.ValEmail.value, (newValue, oldValue) => this.onUpdate('procn.email', this.ValEmail, newValue, oldValue))

		this.ValTelephon = reactive(new modelFieldType.String({
			id: 'ValTelephon',
			originId: 'ValTelephon',
			area: 'PROCN',
			field: 'TELEPHON',
			maxLength: 50,
			description: computed(() => this.Resources.TELEPHONE28697),
		}).cloneFrom(values?.ValTelephon))
		watch(() => this.ValTelephon.value, (newValue, oldValue) => this.onUpdate('procn.telephon', this.ValTelephon, newValue, oldValue))

		this.ValDescript = reactive(new modelFieldType.MultiLineString({
			id: 'ValDescript',
			originId: 'ValDescript',
			area: 'PROCN',
			field: 'DESCRIPT',
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescript))
		watch(() => this.ValDescript.value, (newValue, oldValue) => this.onUpdate('procn.descript', this.ValDescript, newValue, oldValue))

		this.ValDate = reactive(new modelFieldType.Date({
			id: 'ValDate',
			originId: 'ValDate',
			area: 'PROCN',
			field: 'DATE',
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: [Today]
					return qApi.Hoje()
				},
				dependencyEvents: [],
				isServerRecalc: false,
				isEmpty: qApi.emptyD,
			},
			description: computed(() => this.Resources.DATE18475),
		}).cloneFrom(values?.ValDate))
		watch(() => this.ValDate.value, (newValue, oldValue) => this.onUpdate('procn.date', this.ValDate, newValue, oldValue))

		this.TablePropeTitle = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePropeTitle',
			originId: 'ValTitle',
			area: 'PROPE',
			field: 'TITLE',
			maxLength: 50,
			description: computed(() => this.Resources.TITLE21885),
		}).cloneFrom(values?.TablePropeTitle))
		watch(() => this.TablePropeTitle.value, (newValue, oldValue) => this.onUpdate('prope.title', this.TablePropeTitle, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormContac03ViewModel instance.
	 * @returns {QFormContac03ViewModel} A new instance of QFormContac03ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodprocn'

	get QPrimaryKey() { return this.ValCodprocn.value }
	set QPrimaryKey(value) { this.ValCodprocn.updateValue(value) }
}
