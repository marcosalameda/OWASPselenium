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
			name: 'DTTYP',
			area: 'DTTYP',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_DTTYP'
			}
		})

		/** The primary key. */
		this.ValCoddttyp = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCoddttyp',
			originId: 'ValCoddttyp',
			area: 'DTTYP',
			field: 'CODDTTYP',
			description: '',
		}).cloneFrom(values?.ValCoddttyp))
		watch(() => this.ValCoddttyp.value, (newValue, oldValue) => this.onUpdate('dttyp.coddttyp', this.ValCoddttyp, newValue, oldValue))

		/** The remaining form fields. */
		this.ValString = reactive(new modelFieldType.String({
			id: 'ValString',
			originId: 'ValString',
			area: 'DTTYP',
			field: 'STRING',
			maxLength: 50,
			description: computed(() => this.Resources.STRING29433),
		}).cloneFrom(values?.ValString))
		watch(() => this.ValString.value, (newValue, oldValue) => this.onUpdate('dttyp.string', this.ValString, newValue, oldValue))

		this.ValUppercas = reactive(new modelFieldType.String({
			id: 'ValUppercas',
			originId: 'ValUppercas',
			area: 'DTTYP',
			field: 'UPPERCAS',
			maxLength: 50,
			maskType: 'UP',
			description: computed(() => this.Resources.UPPER_CASE31324),
		}).cloneFrom(values?.ValUppercas))
		watch(() => this.ValUppercas.value, (newValue, oldValue) => this.onUpdate('dttyp.uppercas', this.ValUppercas, newValue, oldValue))

		this.ValUuid = reactive(new modelFieldType.String({
			id: 'ValUuid',
			originId: 'ValUuid',
			area: 'DTTYP',
			field: 'UUID',
			maxLength: 36,
			description: computed(() => this.Resources.UUID__AKA_GUID_13998),
		}).cloneFrom(values?.ValUuid))
		watch(() => this.ValUuid.value, (newValue, oldValue) => this.onUpdate('dttyp.uuid', this.ValUuid, newValue, oldValue))

		this.ValMultilin = reactive(new modelFieldType.MultiLineString({
			id: 'ValMultilin',
			originId: 'ValMultilin',
			area: 'DTTYP',
			field: 'MULTILIN',
			description: computed(() => this.Resources.MULTILINE_TEXT57254),
		}).cloneFrom(values?.ValMultilin))
		watch(() => this.ValMultilin.value, (newValue, oldValue) => this.onUpdate('dttyp.multilin', this.ValMultilin, newValue, oldValue))

		this.ValMultili3 = reactive(new modelFieldType.MultiLineString({
			type: 'TextEditor',
			id: 'ValMultili3',
			originId: 'ValMultili3',
			area: 'DTTYP',
			field: 'MULTILI3',
			description: computed(() => this.Resources.MULTILINE_TEXT__TEXT35132),
		}).cloneFrom(values?.ValMultili3))
		watch(() => this.ValMultili3.value, (newValue, oldValue) => this.onUpdate('dttyp.multili3', this.ValMultili3, newValue, oldValue))

		this.ValBoolean = reactive(new modelFieldType.Boolean({
			id: 'ValBoolean',
			originId: 'ValBoolean',
			area: 'DTTYP',
			field: 'BOOLEAN',
			description: computed(() => this.Resources.LOGICAL__TINYINT___S49012),
		}).cloneFrom(values?.ValBoolean))
		watch(() => this.ValBoolean.value, (newValue, oldValue) => this.onUpdate('dttyp.boolean', this.ValBoolean, newValue, oldValue))

		this.ValBoolean2 = reactive(new modelFieldType.Number({
			id: 'ValBoolean2',
			originId: 'ValBoolean2',
			area: 'DTTYP',
			field: 'BOOLEAN2',
			maxDigits: 1,
			decimalDigits: 0,
			description: computed(() => this.Resources.CONDITIONAL__SMALLIN41010),
		}).cloneFrom(values?.ValBoolean2))
		watch(() => this.ValBoolean2.value, (newValue, oldValue) => this.onUpdate('dttyp.boolean2', this.ValBoolean2, newValue, oldValue))

		this.ValSmallint = reactive(new modelFieldType.Number({
			id: 'ValSmallint',
			originId: 'ValSmallint',
			area: 'DTTYP',
			field: 'SMALLINT',
			maxDigits: 4,
			decimalDigits: 0,
			description: computed(() => this.Resources.NUMERIC__4_0___SMALL21475),
		}).cloneFrom(values?.ValSmallint))
		watch(() => this.ValSmallint.value, (newValue, oldValue) => this.onUpdate('dttyp.smallint', this.ValSmallint, newValue, oldValue))

		this.ValInteger = reactive(new modelFieldType.Number({
			id: 'ValInteger',
			originId: 'ValInteger',
			area: 'DTTYP',
			field: 'INTEGER',
			maxDigits: 9,
			decimalDigits: 0,
			description: computed(() => this.Resources.NUMERIC__9_0___INTEG03994),
		}).cloneFrom(values?.ValInteger))
		watch(() => this.ValInteger.value, (newValue, oldValue) => this.onUpdate('dttyp.integer', this.ValInteger, newValue, oldValue))

		this.ValBigint = reactive(new modelFieldType.Number({
			id: 'ValBigint',
			originId: 'ValBigint',
			area: 'DTTYP',
			field: 'BIGINT',
			maxDigits: 15,
			decimalDigits: 0,
			description: computed(() => this.Resources.NUMERIC_15_0___BIG_I46007),
		}).cloneFrom(values?.ValBigint))
		watch(() => this.ValBigint.value, (newValue, oldValue) => this.onUpdate('dttyp.bigint', this.ValBigint, newValue, oldValue))

		this.ValReal = reactive(new modelFieldType.Number({
			id: 'ValReal',
			originId: 'ValReal',
			area: 'DTTYP',
			field: 'REAL',
			maxDigits: 5,
			decimalDigits: 2,
			description: computed(() => this.Resources.NUMERIC__8_2_REAL_FL21391),
		}).cloneFrom(values?.ValReal))
		watch(() => this.ValReal.value, (newValue, oldValue) => this.onUpdate('dttyp.real', this.ValReal, newValue, oldValue))

		this.ValFloat = reactive(new modelFieldType.Number({
			id: 'ValFloat',
			originId: 'ValFloat',
			area: 'DTTYP',
			field: 'FLOAT',
			maxDigits: 12,
			decimalDigits: 2,
			description: computed(() => this.Resources.NUMERIC_15_2_DOUBLE_11443),
		}).cloneFrom(values?.ValFloat))
		watch(() => this.ValFloat.value, (newValue, oldValue) => this.onUpdate('dttyp.float', this.ValFloat, newValue, oldValue))

		this.ValDecimal = reactive(new modelFieldType.Number({
			id: 'ValDecimal',
			originId: 'ValDecimal',
			area: 'DTTYP',
			field: 'DECIMAL',
			maxDigits: 5,
			decimalDigits: 4,
			description: computed(() => this.Resources.DECIMAL__1_10___STOR64402),
		}).cloneFrom(values?.ValDecimal))
		watch(() => this.ValDecimal.value, (newValue, oldValue) => this.onUpdate('dttyp.decimal', this.ValDecimal, newValue, oldValue))

		this.ValDecimal9 = reactive(new modelFieldType.Number({
			id: 'ValDecimal9',
			originId: 'ValDecimal9',
			area: 'DTTYP',
			field: 'DECIMAL9',
			maxDigits: 10,
			decimalDigits: 4,
			description: computed(() => this.Resources.DECIMAL__11_15___STO64707),
		}).cloneFrom(values?.ValDecimal9))
		watch(() => this.ValDecimal9.value, (newValue, oldValue) => this.onUpdate('dttyp.decimal9', this.ValDecimal9, newValue, oldValue))

		this.ValMoney = reactive(new modelFieldType.Number({
			id: 'ValMoney',
			originId: 'ValMoney',
			area: 'DTTYP',
			field: 'MONEY',
			maxDigits: 5,
			decimalDigits: 4,
			description: computed(() => this.Resources.MONEY___DECIMAL__1_124403),
		}).cloneFrom(values?.ValMoney))
		watch(() => this.ValMoney.value, (newValue, oldValue) => this.onUpdate('dttyp.money', this.ValMoney, newValue, oldValue))

		this.ValMoney9 = reactive(new modelFieldType.Number({
			id: 'ValMoney9',
			originId: 'ValMoney9',
			area: 'DTTYP',
			field: 'MONEY9',
			maxDigits: 10,
			decimalDigits: 4,
			description: computed(() => this.Resources.MONEY___DECIMAL__11_02101),
		}).cloneFrom(values?.ValMoney9))
		watch(() => this.ValMoney9.value, (newValue, oldValue) => this.onUpdate('dttyp.money9', this.ValMoney9, newValue, oldValue))

		this.ValDate = reactive(new modelFieldType.Date({
			id: 'ValDate',
			originId: 'ValDate',
			area: 'DTTYP',
			field: 'DATE',
			description: computed(() => this.Resources.DATE18475),
		}).cloneFrom(values?.ValDate))
		watch(() => this.ValDate.value, (newValue, oldValue) => this.onUpdate('dttyp.date', this.ValDate, newValue, oldValue))

		this.ValDatetime = reactive(new modelFieldType.DateTime({
			id: 'ValDatetime',
			originId: 'ValDatetime',
			area: 'DTTYP',
			field: 'DATETIME',
			description: computed(() => this.Resources.DATE_TIME53960),
		}).cloneFrom(values?.ValDatetime))
		watch(() => this.ValDatetime.value, (newValue, oldValue) => this.onUpdate('dttyp.datetime', this.ValDatetime, newValue, oldValue))

		this.ValDtsesond = reactive(new modelFieldType.DateTimeSeconds({
			id: 'ValDtsesond',
			originId: 'ValDtsesond',
			area: 'DTTYP',
			field: 'DTSESOND',
			description: computed(() => this.Resources.DATE_TIME_SECOND45106),
		}).cloneFrom(values?.ValDtsesond))
		watch(() => this.ValDtsesond.value, (newValue, oldValue) => this.onUpdate('dttyp.dtsesond', this.ValDtsesond, newValue, oldValue))

		this.ValTime = reactive(new modelFieldType.Time({
			id: 'ValTime',
			originId: 'ValTime',
			area: 'DTTYP',
			field: 'TIME',
			description: computed(() => this.Resources.TIME15328),
		}).cloneFrom(values?.ValTime))
		watch(() => this.ValTime.value, (newValue, oldValue) => this.onUpdate('dttyp.time', this.ValTime, newValue, oldValue))

		this.ValImage = reactive(new modelFieldType.Image({
			id: 'ValImage',
			originId: 'ValImage',
			area: 'DTTYP',
			field: 'IMAGE',
			description: computed(() => this.Resources.IMAGE__BINARY_46903),
		}).cloneFrom(values?.ValImage))
		watch(() => this.ValImage.value, (newValue, oldValue) => this.onUpdate('dttyp.image', this.ValImage, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormDttypViewModel instance.
	 * @returns {QFormDttypViewModel} A new instance of QFormDttypViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCoddttyp'

	get QPrimaryKey() { return this.ValCoddttyp.value }
	set QPrimaryKey(value) { this.ValCoddttyp.updateValue(value) }
}
