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
			name: 'ARTIGVAL',
			area: 'ITEM',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Artigval',
				updateFilesTickets: 'UpdateFilesTicketsArtigval',
				setFile: 'SetFileArtigval'
			}
		})

		/** The primary key. */
		this.ValCoditem = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCoditem',
			originId: 'ValCoditem',
			area: 'ITEM',
			field: 'CODITEM',
			description: '',
		}).cloneFrom(values?.ValCoditem))
		this.stopWatchers.push(watch(() => this.ValCoditem.value, (newValue, oldValue) => this.onUpdate('item.coditem', this.ValCoditem, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodgitem = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodgitem',
			originId: 'ValCodgitem',
			area: 'ITEM',
			field: 'CODGITEM',
			relatedArea: 'GITEM',
			description: computed(() => this.Resources._GLOBAL_ARTICLE51116),
		}).cloneFrom(values?.ValCodgitem))
		this.stopWatchers.push(watch(() => this.ValCodgitem.value, (newValue, oldValue) => this.onUpdate('item.codgitem', this.ValCodgitem, newValue, oldValue)))

		this.ValCodwareh = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodwareh',
			originId: 'ValCodwareh',
			area: 'ITEM',
			field: 'CODWAREH',
			relatedArea: 'WAREH',
			description: computed(() => this.Resources._WAREHOUSE19861),
		}).cloneFrom(values?.ValCodwareh))
		this.stopWatchers.push(watch(() => this.ValCodwareh.value, (newValue, oldValue) => this.onUpdate('item.codwareh', this.ValCodwareh, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValImage = reactive(new modelFieldType.Image({
			id: 'ValImage',
			originId: 'ValImage',
			area: 'ITEM',
			field: 'IMAGE',
			description: computed(() => this.Resources.IMAGE65174),
		}).cloneFrom(values?.ValImage))
		this.stopWatchers.push(watch(() => this.ValImage.value, (newValue, oldValue) => this.onUpdate('item.image', this.ValImage, newValue, oldValue)))

		this.TableGitemItemdes = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableGitemItemdes',
			originId: 'ValItemdes',
			area: 'GITEM',
			field: 'ITEMDES',
			maxLength: 85,
			description: computed(() => this.Resources.GLOBAL_ARTICLE63861),
		}).cloneFrom(values?.TableGitemItemdes))
		this.stopWatchers.push(watch(() => this.TableGitemItemdes.value, (newValue, oldValue) => this.onUpdate('gitem.itemdes', this.TableGitemItemdes, newValue, oldValue)))

		this.TableWarehWarehdes = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableWarehWarehdes',
			originId: 'ValWarehdes',
			area: 'WAREH',
			field: 'WAREHDES',
			maxLength: 85,
			description: computed(() => this.Resources.WAREHOUSE51864),
		}).cloneFrom(values?.TableWarehWarehdes))
		this.stopWatchers.push(watch(() => this.TableWarehWarehdes.value, (newValue, oldValue) => this.onUpdate('wareh.warehdes', this.TableWarehWarehdes, newValue, oldValue)))

		this.ValItemtype = reactive(new modelFieldType.String({
			id: 'ValItemtype',
			originId: 'ValItemtype',
			area: 'ITEM',
			field: 'ITEMTYPE',
			maxLength: 1,
			arrayOptions: computed(() => new qProjArrays.QArrayTipoarti(vm.$getResource).elements),
			description: computed(() => this.Resources.TYPE00312),
		}).cloneFrom(values?.ValItemtype))
		this.stopWatchers.push(watch(() => this.ValItemtype.value, (newValue, oldValue) => this.onUpdate('item.itemtype', this.ValItemtype, newValue, oldValue)))

		this.ValItemcod = reactive(new modelFieldType.String({
			id: 'ValItemcod',
			originId: 'ValItemcod',
			area: 'ITEM',
			field: 'ITEMCOD',
			maxLength: 15,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: [GITEM->ITEMGCOD]
					return this.GitemValItemgcod.value
				},
				dependencyEvents: ['fieldChange:gitem.itemgcod', 'fieldChange:item.codgitem'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			description: computed(() => this.Resources.CODE49225),
		}).cloneFrom(values?.ValItemcod))
		this.stopWatchers.push(watch(() => this.ValItemcod.value, (newValue, oldValue) => this.onUpdate('item.itemcod', this.ValItemcod, newValue, oldValue)))

		this.ValItemdes = reactive(new modelFieldType.String({
			id: 'ValItemdes',
			originId: 'ValItemdes',
			area: 'ITEM',
			field: 'ITEMDES',
			maxLength: 85,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: [GITEM->ITEMDES]
					return this.TableGitemItemdes.value
				},
				dependencyEvents: ['fieldChange:gitem.itemdes', 'fieldChange:item.codgitem'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			description: computed(() => this.Resources.ARTICLE60065),
		}).cloneFrom(values?.ValItemdes))
		this.stopWatchers.push(watch(() => this.ValItemdes.value, (newValue, oldValue) => this.onUpdate('item.itemdes', this.ValItemdes, newValue, oldValue)))

		this.ValDate = reactive(new modelFieldType.Date({
			id: 'ValDate',
			originId: 'ValDate',
			area: 'ITEM',
			field: 'DATE',
			description: computed(() => this.Resources.DATE18475),
		}).cloneFrom(values?.ValDate))
		this.stopWatchers.push(watch(() => this.ValDate.value, (newValue, oldValue) => this.onUpdate('item.date', this.ValDate, newValue, oldValue)))

		this.ValEntries = reactive(new modelFieldType.Number({
			id: 'ValEntries',
			originId: 'ValEntries',
			area: 'ITEM',
			field: 'ENTRIES',
			maxDigits: 10,
			decimalDigits: 0,
			isFixed: true,
			description: computed(() => this.Resources.ENTRIES32319),
		}).cloneFrom(values?.ValEntries))
		this.stopWatchers.push(watch(() => this.ValEntries.value, (newValue, oldValue) => this.onUpdate('item.entries', this.ValEntries, newValue, oldValue)))

		this.ValExits = reactive(new modelFieldType.Number({
			id: 'ValExits',
			originId: 'ValExits',
			area: 'ITEM',
			field: 'EXITS',
			maxDigits: 10,
			decimalDigits: 0,
			isFixed: true,
			description: computed(() => this.Resources.OUTPUTS47833),
		}).cloneFrom(values?.ValExits))
		this.stopWatchers.push(watch(() => this.ValExits.value, (newValue, oldValue) => this.onUpdate('item.exits', this.ValExits, newValue, oldValue)))

		this.ValExistenc = reactive(new modelFieldType.Number({
			id: 'ValExistenc',
			originId: 'ValExistenc',
			area: 'ITEM',
			field: 'EXISTENC',
			maxDigits: 10,
			decimalDigits: 0,
			isFixed: true,
			description: computed(() => this.Resources.STOCKS47349),
		}).cloneFrom(values?.ValExistenc))
		this.stopWatchers.push(watch(() => this.ValExistenc.value, (newValue, oldValue) => this.onUpdate('item.existenc', this.ValExistenc, newValue, oldValue)))

		this.ValCategory = reactive(new modelFieldType.MultiLineString({
			id: 'ValCategory',
			originId: 'ValCategory',
			area: 'ITEM',
			field: 'CATEGORY',
			isFixed: true,
			description: computed(() => this.Resources.CATEGORIZATION17554),
		}).cloneFrom(values?.ValCategory))
		this.stopWatchers.push(watch(() => this.ValCategory.value, (newValue, oldValue) => this.onUpdate('item.category', this.ValCategory, newValue, oldValue)))

		this.ValDisponib = reactive(new modelFieldType.String({
			id: 'ValDisponib',
			originId: 'ValDisponib',
			area: 'ITEM',
			field: 'DISPONIB',
			maxLength: 1,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: iif([ITEM->EXISTENC]>0,"A",iif([ITEM->EXISTENC]<=0,"O","D"))
					return qApi.iif(this.ValExistenc.value>0,"A",qApi.iif(this.ValExistenc.value<=0,"O","D"))
				},
				dependencyEvents: ['fieldChange:item.existenc'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			arrayOptions: computed(() => new qProjArrays.QArrayDsiponib(vm.$getResource).elements),
			description: computed(() => this.Resources.AVAILABILITY56489),
		}).cloneFrom(values?.ValDisponib))
		this.stopWatchers.push(watch(() => this.ValDisponib.value, (newValue, oldValue) => this.onUpdate('item.disponib', this.ValDisponib, newValue, oldValue)))

		/** The form fields used only in formulas. */
		this.GitemValItemgcod = reactive(new modelFieldType.String({
			id: 'GitemValItemgcod',
			originId: 'ValItemgcod',
			area: 'GITEM',
			field: 'ITEMGCOD',
			maxLength: 15,
			isFixed: true,
			description: computed(() => this.Resources.CODE49225),
		}).cloneFrom(values?.GitemValItemgcod))
		this.stopWatchers.push(watch(() => this.GitemValItemgcod.value, (newValue, oldValue) => this.onUpdate('gitem.itemgcod', this.GitemValItemgcod, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormArtigvalViewModel instance.
	 * @returns {QFormArtigvalViewModel} A new instance of QFormArtigvalViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCoditem'

	get QPrimaryKey() { return this.ValCoditem.value }
	set QPrimaryKey(value) { this.ValCoditem.updateValue(value) }
}
