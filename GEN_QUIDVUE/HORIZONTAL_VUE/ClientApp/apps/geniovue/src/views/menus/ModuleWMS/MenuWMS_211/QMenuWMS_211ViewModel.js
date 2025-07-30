/* eslint-disable @typescript-eslint/no-unused-vars */
import { computed, reactive, watch } from 'vue'

import MenuViewModelBase from '@/mixins/menuViewModelBase.js'
import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
import modelFieldType from '@quidgest/clientapp/models/fields'

import hardcodedTexts from '@/hardcodedTexts.js'
import netAPI from '@quidgest/clientapp/network'
import qApi from '@/api/genio/quidgestFunctions.js'
import qFunctions from '@/api/genio/projectFunctions.js'
import qProjArrays from '@/api/genio/projectArrays.js'

import _groupBy from 'lodash-es/groupBy'
import _forEach from 'lodash-es/forEach'
import _get from 'lodash-es/get'
import _orderBy from 'lodash-es/orderBy'

/* eslint-enable @typescript-eslint/no-unused-vars */

/**
 * Represents a card ViewModel class for QMenuWMS_211 Kanban.
 * @extends MenuViewModelBase
 */
export class KanbanCardViewModel extends MenuViewModelBase
{
	/**
	 * Creates a new instance of the KanbanCardViewModel.
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

		this.DispaValCoddispa = reactive(new modelFieldType.PrimaryKey({
			id: 'DispaValCoddispa',
			originId: 'ValCoddispa',
			area: 'DISPA',
			field: 'CODDISPA',
			description: '',
		}).cloneFrom(values?.DispaValCoddispa))
		this.stopWatchers.push(watch(() => this.DispaValCoddispa.value, (newValue, oldValue) => this.onUpdate('dispa.coddispa', this.DispaValCoddispa, newValue, oldValue)))

		this.DispaValCoddisst = reactive(new modelFieldType.ForeignKey({
			id: 'DispaValCoddisst',
			originId: 'ValCoddisst',
			area: 'DISPA',
			field: 'CODDISST',
			relatedArea: 'DISST',
			description: computed(() => this.Resources.___STATUS46938),
		}).cloneFrom(values?.DispaValCoddisst))
		this.stopWatchers.push(watch(() => this.DispaValCoddisst.value, (newValue, oldValue) => this.onUpdate('dispa.coddisst', this.DispaValCoddisst, newValue, oldValue)))

		this.DisstValCoddisst = reactive(new modelFieldType.PrimaryKey({
			id: 'DisstValCoddisst',
			originId: 'ValCoddisst',
			area: 'DISST',
			field: 'CODDISST',
			description: '',
		}).cloneFrom(values?.DisstValCoddisst))
		this.stopWatchers.push(watch(() => this.DisstValCoddisst.value, (newValue, oldValue) => this.onUpdate('disst.coddisst', this.DisstValCoddisst, newValue, oldValue)))

		this.DispaValDispanr = reactive(new modelFieldType.Number({
			id: 'DispaValDispanr',
			originId: 'ValDispanr',
			area: 'DISPA',
			field: 'DISPANR',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.DISPATCH_NUMBER23616),
		}).cloneFrom(values?.DispaValDispanr))
		this.stopWatchers.push(watch(() => this.DispaValDispanr.value, (newValue, oldValue) => this.onUpdate('dispa.dispanr', this.DispaValDispanr, newValue, oldValue)))

		this.DispaValDispadt = reactive(new modelFieldType.DateTime({
			id: 'DispaValDispadt',
			originId: 'ValDispadt',
			area: 'DISPA',
			field: 'DISPADT',
			description: computed(() => this.Resources.DISPATCH_DATE54413),
		}).cloneFrom(values?.DispaValDispadt))
		this.stopWatchers.push(watch(() => this.DispaValDispadt.value, (newValue, oldValue) => this.onUpdate('dispa.dispadt', this.DispaValDispadt, newValue, oldValue)))

		this.PersoValName = reactive(new modelFieldType.String({
			id: 'PersoValName',
			originId: 'ValName',
			area: 'PERSO',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.PERSON_NAME40980),
		}).cloneFrom(values?.PersoValName))
		this.stopWatchers.push(watch(() => this.PersoValName.value, (newValue, oldValue) => this.onUpdate('perso.name', this.PersoValName, newValue, oldValue)))

		this.DispaValCodperso = reactive(new modelFieldType.ForeignKey({
			id: 'DispaValCodperso',
			originId: 'ValCodperso',
			area: 'DISPA',
			field: 'CODPERSO',
			relatedArea: 'PERSO',
			description: computed(() => this.Resources.__PERSON_RESPONSIBLE00553),
		}).cloneFrom(values?.DispaValCodperso))
		this.stopWatchers.push(watch(() => this.DispaValCodperso.value, (newValue, oldValue) => this.onUpdate('dispa.codperso', this.DispaValCodperso, newValue, oldValue)))

		this.PersoValCodperso = reactive(new modelFieldType.PrimaryKey({
			id: 'PersoValCodperso',
			originId: 'ValCodperso',
			area: 'PERSO',
			field: 'CODPERSO',
			description: '',
		}).cloneFrom(values?.PersoValCodperso))
		this.stopWatchers.push(watch(() => this.PersoValCodperso.value, (newValue, oldValue) => this.onUpdate('perso.codperso', this.PersoValCodperso, newValue, oldValue)))

		this.DisstValStatus = reactive(new modelFieldType.String({
			id: 'DisstValStatus',
			originId: 'ValStatus',
			area: 'DISST',
			field: 'STATUS',
			maxLength: 50,
			description: computed(() => this.Resources.STATUS62033),
		}).cloneFrom(values?.DisstValStatus))
		this.stopWatchers.push(watch(() => this.DisstValStatus.value, (newValue, oldValue) => this.onUpdate('disst.status', this.DisstValStatus, newValue, oldValue)))

		this.EntitValName = reactive(new modelFieldType.String({
			id: 'EntitValName',
			originId: 'ValName',
			area: 'ENTIT',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.LEGAL_NAME42902),
		}).cloneFrom(values?.EntitValName))
		this.stopWatchers.push(watch(() => this.EntitValName.value, (newValue, oldValue) => this.onUpdate('entit.name', this.EntitValName, newValue, oldValue)))

		this.DispaValCodentit = reactive(new modelFieldType.ForeignKey({
			id: 'DispaValCodentit',
			originId: 'ValCodentit',
			area: 'DISPA',
			field: 'CODENTIT',
			relatedArea: 'ENTIT',
			description: computed(() => this.Resources.__CUSTOMER57515),
		}).cloneFrom(values?.DispaValCodentit))
		this.stopWatchers.push(watch(() => this.DispaValCodentit.value, (newValue, oldValue) => this.onUpdate('dispa.codentit', this.DispaValCodentit, newValue, oldValue)))

		this.EntitValCodentit = reactive(new modelFieldType.PrimaryKey({
			id: 'EntitValCodentit',
			originId: 'ValCodentit',
			area: 'ENTIT',
			field: 'CODENTIT',
			description: '',
		}).cloneFrom(values?.EntitValCodentit))
		this.stopWatchers.push(watch(() => this.EntitValCodentit.value, (newValue, oldValue) => this.onUpdate('entit.codentit', this.EntitValCodentit, newValue, oldValue)))

		const _tempid = computed(() => this.DispaValCoddispa.displayValue)
		Object.defineProperty(this, 'id', {
			enumerable: false,
			get() { return _tempid }
		})
		const _tempcolumn = computed(() => this.DispaValCoddisst.displayValue)
		Object.defineProperty(this, 'column', {
			enumerable: false,
			get() { return _tempcolumn }
		})
		const _temporder = computed(() => this.DispaValDispanr.displayValue)
		Object.defineProperty(this, 'order', {
			enumerable: false,
			get() { return _temporder }
		})
		const _temptitle = computed(() => this.DispaValDispanr.displayValue)
		Object.defineProperty(this, 'title', {
			enumerable: false,
			get() { return _temptitle }
		})
		const _tempdescription = computed(() => this.EntitValName.displayValue)
		Object.defineProperty(this, 'description', {
			enumerable: false,
			get() { return _tempdescription }
		})
		const _tempdate = computed(() => this.DispaValDispadt.displayValue)
		Object.defineProperty(this, 'date', {
			enumerable: false,
			get() { return _tempdate }
		})
		const _tempauthor = computed(() => this.PersoValName.displayValue)
		Object.defineProperty(this, 'author', {
			enumerable: false,
			get() { return _tempauthor }
		})
		const _tempadditionalInformation = [
			computed(() => this.DisstValStatus.displayValue),
		]
		Object.defineProperty(this, 'additionalInformation', {
			enumerable: false,
			get() { return _tempadditionalInformation }
		})
	}

	/**
	 * Creates a clone of the current KanbanCardViewModel instance.
	 * @returns KanbanCardViewModel A new instance of KanbanCardViewModel
	 */
	clone()
	{
		return new KanbanCardViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}
}

/**
 * Represents a column ViewModel class for QMenuWMS_211 Kanban.
 * @extends MenuViewModelBase
 */
export class KanbanColumnViewModel extends MenuViewModelBase
{
	/**
	 * Creates a new instance of the KanbanColumnViewModel.
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

		this.DisstValCoddisst = reactive(new modelFieldType.PrimaryKey({
			id: 'DisstValCoddisst',
			originId: 'ValCoddisst',
			area: 'DISST',
			field: 'CODDISST',
			description: '',
		}).cloneFrom(values?.DisstValCoddisst))
		this.stopWatchers.push(watch(() => this.DisstValCoddisst.value, (newValue, oldValue) => this.onUpdate('disst.coddisst', this.DisstValCoddisst, newValue, oldValue)))

		this.DisstValOrder = reactive(new modelFieldType.Number({
			id: 'DisstValOrder',
			originId: 'ValOrder',
			area: 'DISST',
			field: 'ORDER',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.ORDER39632),
		}).cloneFrom(values?.DisstValOrder))
		this.stopWatchers.push(watch(() => this.DisstValOrder.value, (newValue, oldValue) => this.onUpdate('disst.order', this.DisstValOrder, newValue, oldValue)))

		this.DisstValStatus = reactive(new modelFieldType.String({
			id: 'DisstValStatus',
			originId: 'ValStatus',
			area: 'DISST',
			field: 'STATUS',
			maxLength: 50,
			description: computed(() => this.Resources.STATUS62033),
		}).cloneFrom(values?.DisstValStatus))
		this.stopWatchers.push(watch(() => this.DisstValStatus.value, (newValue, oldValue) => this.onUpdate('disst.status', this.DisstValStatus, newValue, oldValue)))

		this.DisstValDescript = reactive(new modelFieldType.String({
			id: 'DisstValDescript',
			originId: 'ValDescript',
			area: 'DISST',
			field: 'DESCRIPT',
			maxLength: 50,
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.DisstValDescript))
		this.stopWatchers.push(watch(() => this.DisstValDescript.value, (newValue, oldValue) => this.onUpdate('disst.descript', this.DisstValDescript, newValue, oldValue)))

		const _tempid = computed(() => this.DisstValCoddisst.displayValue)
		Object.defineProperty(this, 'id', {
			enumerable: false,
			get() { return _tempid }
		})
		const _temporder = computed(() => this.DisstValOrder.displayValue)
		Object.defineProperty(this, 'order', {
			enumerable: false,
			get() { return _temporder }
		})
		const _temptitle = computed(() => this.DisstValStatus.displayValue)
		Object.defineProperty(this, 'title', {
			enumerable: false,
			get() { return _temptitle }
		})
		const _tempadditionalInformation = [
			computed(() => this.DisstValDescript.displayValue),
		]
		Object.defineProperty(this, 'additionalInformation', {
			enumerable: false,
			get() { return _tempadditionalInformation }
		})
	}

	/**
	 * Creates a clone of the current KanbanColumnViewModel instance.
	 * @returns KanbanColumnViewModel A new instance of KanbanColumnViewModel
	 */
	clone()
	{
		return new KanbanColumnViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}
}

/**
 * Represents a ViewModel class for QMenuWMS_211 Kanban.
 * @extends MenuViewModelBase
 */
export default class ViewModel extends MenuViewModelBase
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

		this.columnIdField = "DisstValCoddisst"
		this.cardIdField = "DispaValCoddispa"

		this.columns = values?.columns?.clone() ?? []
		this.cards = values?.cards?.clone() ?? []
	}

	hydrate(data)
	{
		_forEach(data.Columns, column => {
			var viewModel = new KanbanColumnViewModel(this.vueContext)
			viewModel.hydrate(column)
			this.columns.push(viewModel)
		})

		_forEach(data.Cards, card => {
			var viewModel = new KanbanCardViewModel(this.vueContext)
			viewModel.hydrate(card)
			this.cards.push(viewModel)
		})
	}

	/**
	 * Creates a clone of the current QMenuWMS_211ViewModel instance.
	 * @returns ViewModel A new instance of QMenuWMS_211ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}
}
