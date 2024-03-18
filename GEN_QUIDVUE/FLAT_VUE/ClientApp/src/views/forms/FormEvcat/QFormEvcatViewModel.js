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
			name: 'EVCAT',
			area: 'EVCAT',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_EVCAT'
			}
		})

		/** The primary key. */
		this.ValCodprogr = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodprogr',
			originId: 'ValCodprogr',
			area: 'EVCAT',
			field: 'CODPROGR',
			description: '',
		}).cloneFrom(values?.ValCodprogr))
		watch(() => this.ValCodprogr.value, (newValue, oldValue) => this.onUpdate('evcat.codprogr', this.ValCodprogr, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodpesso = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpesso',
			originId: 'ValCodpesso',
			area: 'EVCAT',
			field: 'CODPESSO',
			relatedArea: 'PESSO',
			description: computed(() => this.Resources._PERSON28337),
		}).cloneFrom(values?.ValCodpesso))
		watch(() => this.ValCodpesso.value, (newValue, oldValue) => this.onUpdate('evcat.codpesso', this.ValCodpesso, newValue, oldValue))

		this.ValCodcateg = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcateg',
			originId: 'ValCodcateg',
			area: 'EVCAT',
			field: 'CODCATEG',
			relatedArea: 'CATE1',
			description: computed(() => this.Resources._CATEGORY37591),
		}).cloneFrom(values?.ValCodcateg))
		watch(() => this.ValCodcateg.value, (newValue, oldValue) => this.onUpdate('evcat.codcateg', this.ValCodcateg, newValue, oldValue))

		/** The remaining form fields. */
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

		this.TableCate1Category = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCate1Category',
			originId: 'ValCategoria',
			area: 'CATE1',
			field: 'CATEGORY',
			maxLength: 50,
			description: computed(() => this.Resources.CATEGORY18978),
		}).cloneFrom(values?.TableCate1Category))
		watch(() => this.TableCate1Category.value, (newValue, oldValue) => this.onUpdate('cate1.categoria', this.TableCate1Category, newValue, oldValue))

		this.ValSince = reactive(new modelFieldType.Date({
			id: 'ValSince',
			originId: 'ValSince',
			area: 'EVCAT',
			field: 'SINCE',
			description: computed(() => this.Resources.SINCE47259),
		}).cloneFrom(values?.ValSince))
		watch(() => this.ValSince.value, (newValue, oldValue) => this.onUpdate('evcat.since', this.ValSince, newValue, oldValue))

		this.ValUntil = reactive(new modelFieldType.Date({
			id: 'ValUntil',
			originId: 'ValUntil',
			area: 'EVCAT',
			field: 'UNTIL',
			description: computed(() => this.Resources.UNTIL39173),
			showWhen: {
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: emptyD([EVCAT->UNTILMAN])==1 && emptyD([EVCAT->UNTIL])==0
					// eslint-disable-next-line eqeqeq
					return qApi.emptyD(this.ValUntilman.value)==1&&qApi.emptyD(this.ValUntil.value)==0
				},
				dependencyEvents: ['fieldChange:evcat.untilman'],
				isServerRecalc: false,
				isServerFormula: false,
				isEmpty: qApi.emptyD,
			},
		}).cloneFrom(values?.ValUntil))
		watch(() => this.ValUntil.value, (newValue, oldValue) => this.onUpdate('evcat.until', this.ValUntil, newValue, oldValue))

		this.ValUntilman = reactive(new modelFieldType.Date({
			id: 'ValUntilman',
			originId: 'ValUntilman',
			area: 'EVCAT',
			field: 'UNTILMAN',
			description: computed(() => this.Resources.UP_MANUAL46500),
			showWhen: {
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: emptyD([EVCAT->UNTIL])==1
					// eslint-disable-next-line eqeqeq
					return qApi.emptyD(this.ValUntil.value)==1
				},
				dependencyEvents: ['fieldChange:evcat.until'],
				isServerRecalc: false,
				isServerFormula: false,
				isEmpty: qApi.emptyD,
			},
		}).cloneFrom(values?.ValUntilman))
		watch(() => this.ValUntilman.value, (newValue, oldValue) => this.onUpdate('evcat.untilman', this.ValUntilman, newValue, oldValue))

		this.ValFimperio = reactive(new modelFieldType.Date({
			id: 'ValFimperio',
			originId: 'ValFimperio',
			area: 'EVCAT',
			field: 'FIMPERIO',
			description: computed(() => this.Resources.END_OF_PERIOD44616),
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: iif(emptyD([EVCAT->UNTILMAN])==0,[EVCAT->UNTILMAN],[EVCAT->UNTIL])
					// eslint-disable-next-line eqeqeq
					return qApi.iif(qApi.emptyD(this.ValUntilman.value)==0,this.ValUntilman.value,this.ValUntil.value)
				},
				dependencyEvents: ['fieldChange:evcat.untilman', 'fieldChange:evcat.until'],
				isServerRecalc: false,
				isServerFormula: false,
				isEmpty: qApi.emptyD,
			},
		}).cloneFrom(values?.ValFimperio))
		watch(() => this.ValFimperio.value, (newValue, oldValue) => this.onUpdate('evcat.fimperio', this.ValFimperio, newValue, oldValue))

		this.ValObservat = reactive(new modelFieldType.String({
			id: 'ValObservat',
			originId: 'ValObservat',
			area: 'EVCAT',
			field: 'OBSERVAT',
			description: computed(() => this.Resources.OBSERVATION37880),
		}).cloneFrom(values?.ValObservat))
		watch(() => this.ValObservat.value, (newValue, oldValue) => this.onUpdate('evcat.observat', this.ValObservat, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormEvcatViewModel instance.
	 * @returns {QFormEvcatViewModel} A new instance of QFormEvcatViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodprogr'

	get QPrimaryKey() { return this.ValCodprogr.value }
	set QPrimaryKey(value) { this.ValCodprogr.value = value }
}
