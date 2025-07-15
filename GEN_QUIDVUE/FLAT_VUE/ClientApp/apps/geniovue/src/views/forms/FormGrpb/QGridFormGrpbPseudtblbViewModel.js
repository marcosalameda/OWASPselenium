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
			name: 'GRPB____PSEUDTBLB____',
			area: 'TBLB',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Grpb____pseudtblb____',
				updateFilesTickets: 'UpdateFilesTicketsGrpb____pseudtblb____',
				setFile: 'SetFileGrpb____pseudtblb____'
			}
		})

		/** The primary key. */
		this.ValCodtblb = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodtblb',
			originId: 'ValCodtblb',
			area: 'TBLB',
			field: 'CODTBLB',
			description: '',
		}).cloneFrom(values?.ValCodtblb))
		this.stopWatchers.push(watch(() => this.ValCodtblb.value, (newValue, oldValue) => this.onUpdate('tblb.codtblb', this.ValCodtblb, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValFkey1 = reactive(new modelFieldType.ForeignKey({
			id: 'ValFkey1',
			originId: 'ValFkey1',
			area: 'TBLB',
			field: 'FKEY1',
			relatedArea: 'GRPB',
			isFixed: true,
			description: computed(() => this.Resources.FOREIGN_KEY39588),
		}).cloneFrom(values?.ValFkey1))
		this.stopWatchers.push(watch(() => this.ValFkey1.value, (newValue, oldValue) => this.onUpdate('tblb.fkey1', this.ValFkey1, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValText = reactive(new modelFieldType.String({
			id: 'ValText',
			originId: 'ValText',
			area: 'TBLB',
			field: 'TEXT',
			maxLength: 50,
			description: computed(() => this.Resources.TEXT04938),
		}).cloneFrom(values?.ValText))
		this.stopWatchers.push(watch(() => this.ValText.value, (newValue, oldValue) => this.onUpdate('tblb.text', this.ValText, newValue, oldValue)))

		this.ValTextml = reactive(new modelFieldType.MultiLineString({
			id: 'ValTextml',
			originId: 'ValTextml',
			area: 'TBLB',
			field: 'TEXTML',
			description: computed(() => this.Resources.MULTILINE_TEXT38013),
		}).cloneFrom(values?.ValTextml))
		this.stopWatchers.push(watch(() => this.ValTextml.value, (newValue, oldValue) => this.onUpdate('tblb.textml', this.ValTextml, newValue, oldValue)))

		this.ValNumint = reactive(new modelFieldType.Number({
			id: 'ValNumint',
			originId: 'ValNumint',
			area: 'TBLB',
			field: 'NUMINT',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.NUMERIC__INTEGER_50289),
		}).cloneFrom(values?.ValNumint))
		this.stopWatchers.push(watch(() => this.ValNumint.value, (newValue, oldValue) => this.onUpdate('tblb.numint', this.ValNumint, newValue, oldValue)))

		this.ValNumdec = reactive(new modelFieldType.Number({
			id: 'ValNumdec',
			originId: 'ValNumdec',
			area: 'TBLB',
			field: 'NUMDEC',
			maxDigits: 6,
			decimalDigits: 3,
			description: computed(() => this.Resources.NUMERIC__DECIMAL_36157),
		}).cloneFrom(values?.ValNumdec))
		this.stopWatchers.push(watch(() => this.ValNumdec.value, (newValue, oldValue) => this.onUpdate('tblb.numdec', this.ValNumdec, newValue, oldValue)))

		this.ValCurint = reactive(new modelFieldType.Number({
			id: 'ValCurint',
			originId: 'ValCurint',
			area: 'TBLB',
			field: 'CURINT',
			maxDigits: 7,
			decimalDigits: 2,
			description: computed(() => this.Resources.CURRENCY__INTERGER_21437),
		}).cloneFrom(values?.ValCurint))
		this.stopWatchers.push(watch(() => this.ValCurint.value, (newValue, oldValue) => this.onUpdate('tblb.curint', this.ValCurint, newValue, oldValue)))

		this.ValCurdec = reactive(new modelFieldType.Number({
			id: 'ValCurdec',
			originId: 'ValCurdec',
			area: 'TBLB',
			field: 'CURDEC',
			maxDigits: 5,
			decimalDigits: 4,
			description: computed(() => this.Resources.CURRENCY__DECIMAL_11718),
		}).cloneFrom(values?.ValCurdec))
		this.stopWatchers.push(watch(() => this.ValCurdec.value, (newValue, oldValue) => this.onUpdate('tblb.curdec', this.ValCurdec, newValue, oldValue)))

		this.ValBool = reactive(new modelFieldType.Boolean({
			id: 'ValBool',
			originId: 'ValBool',
			area: 'TBLB',
			field: 'BOOL',
			description: computed(() => this.Resources.BOOLEAN45002),
		}).cloneFrom(values?.ValBool))
		this.stopWatchers.push(watch(() => this.ValBool.value, (newValue, oldValue) => this.onUpdate('tblb.bool', this.ValBool, newValue, oldValue)))

		this.ValDate = reactive(new modelFieldType.Date({
			id: 'ValDate',
			originId: 'ValDate',
			area: 'TBLB',
			field: 'DATE',
			description: computed(() => this.Resources.DATE18475),
		}).cloneFrom(values?.ValDate))
		this.stopWatchers.push(watch(() => this.ValDate.value, (newValue, oldValue) => this.onUpdate('tblb.date', this.ValDate, newValue, oldValue)))

		this.ValDatetm = reactive(new modelFieldType.DateTime({
			id: 'ValDatetm',
			originId: 'ValDatetm',
			area: 'TBLB',
			field: 'DATETM',
			description: computed(() => this.Resources.DATETIME__MINUTES_59352),
		}).cloneFrom(values?.ValDatetm))
		this.stopWatchers.push(watch(() => this.ValDatetm.value, (newValue, oldValue) => this.onUpdate('tblb.datetm', this.ValDatetm, newValue, oldValue)))

		this.ValDatets = reactive(new modelFieldType.DateTimeSeconds({
			id: 'ValDatets',
			originId: 'ValDatets',
			area: 'TBLB',
			field: 'DATETS',
			description: computed(() => this.Resources.DATETIME__SECONDS_49861),
		}).cloneFrom(values?.ValDatets))
		this.stopWatchers.push(watch(() => this.ValDatets.value, (newValue, oldValue) => this.onUpdate('tblb.datets', this.ValDatets, newValue, oldValue)))

		this.ValTimehm = reactive(new modelFieldType.Time({
			id: 'ValTimehm',
			originId: 'ValTimehm',
			area: 'TBLB',
			field: 'TIMEHM',
			description: computed(() => this.Resources.TIME__HOURS_MINUTES_01660),
		}).cloneFrom(values?.ValTimehm))
		this.stopWatchers.push(watch(() => this.ValTimehm.value, (newValue, oldValue) => this.onUpdate('tblb.timehm', this.ValTimehm, newValue, oldValue)))

		this.ValEnumt = reactive(new modelFieldType.String({
			id: 'ValEnumt',
			originId: 'ValEnumt',
			area: 'TBLB',
			field: 'ENUMT',
			maxLength: 1,
			arrayOptions: computed(() => new qProjArrays.QArrayTypet(vm.$getResource).elements),
			description: computed(() => this.Resources.ENUMERATION__TEXT_15855),
		}).cloneFrom(values?.ValEnumt))
		this.stopWatchers.push(watch(() => this.ValEnumt.value, (newValue, oldValue) => this.onUpdate('tblb.enumt', this.ValEnumt, newValue, oldValue)))

		this.ValEnumn = reactive(new modelFieldType.Number({
			id: 'ValEnumn',
			originId: 'ValEnumn',
			area: 'TBLB',
			field: 'ENUMN',
			maxDigits: 1,
			decimalDigits: 0,
			arrayOptions: computed(() => new qProjArrays.QArrayTypen(vm.$getResource).elements),
			description: computed(() => this.Resources.ENUMERATION__NUMERIC44708),
		}).cloneFrom(values?.ValEnumn))
		this.stopWatchers.push(watch(() => this.ValEnumn.value, (newValue, oldValue) => this.onUpdate('tblb.enumn', this.ValEnumn, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QGridFormGrpbPseudtblbViewModel instance.
	 * @returns {QGridFormGrpbPseudtblbViewModel} A new instance of QGridFormGrpbPseudtblbViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodtblb'

	get QPrimaryKey() { return this.ValCodtblb.value }
	set QPrimaryKey(value) { this.ValCodtblb.updateValue(value) }
}
