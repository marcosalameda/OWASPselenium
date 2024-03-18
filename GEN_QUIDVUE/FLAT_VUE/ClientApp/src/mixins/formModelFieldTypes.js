import { computed, reactive } from 'vue'
import _assignIn from 'lodash-es/assignIn'
import _cloneDeep from 'lodash-es/cloneDeep'
import _findIndex from 'lodash-es/findIndex'
import _flatMap from 'lodash-es/flatMap'
import _forEach from 'lodash-es/forEach'
import _get from 'lodash-es/get'
import _has from 'lodash-es/has'
import _isEmpty from 'lodash-es/isEmpty'
import _isEqual from 'lodash-es/isEqual'
import _size from 'lodash-es/size'
import _some from 'lodash-es/some'

import { validate as uuidValidate, v4 as uuidv4 } from 'uuid'

import { useSystemDataStore } from '@/stores/systemData.js'
import genericFunctions from '@/mixins/genericFunctions.js'
import modelFieldType from '@/mixins/formModelFieldTypes.js'

export class Base
{
	static EMPTY_VALUE = null

	constructor(options)
	{
		this.type = null
		this.id = null
		this.originId = null
		this.area = null
		this.field = null
		this.relatedArea = null
		this.valueFormula = null
		// Ignore the field when the model is submitted to the server.
		this.ignoreFldSubmit = false
		this.isRequired = false
		this.value = this.constructor.EMPTY_VALUE
		this.originalValue = this.constructor.EMPTY_VALUE
		this.arrayOptions = []
		// this._value = null
		// Object.defineProperty(this, '_value', { enumerable: false })

		this.serverErrorMessages = []

		_assignIn(this, options)
	}

	/*
	 * In the future, use to control that the value assigned matches the data type of the field.
	 * For now, it will be used to facilitate debugging when something changes value and that shouldn't happen.
	 */
	/*
	get value()
	{
		return this._value
	}

	set value(newValue)
	{
		this._value = newValue
	}
	*/

	/**
	 * Checks if the field's value is different from its original value (dirty).
	 * @type {boolean} True if the field's value is dirty, false otherwise.
	 */
	get isDirty()
	{
		return !this.hasSameValue(this.originalValue)
	}

	/**
	 * Retrieves the display value of the field.
	 * @type {string} The display value of the field.
	 */
	get displayValue()
	{
		return this.parseValue(this.value)
	}

	/**
	 * The value in the format expected by the server-side.
	 */
	get serverValue()
	{
		return this.value
	}

	/**
	 * Parses the given value based on the specified rules and options.
	 *
	 * If this is an array field, the display value corresponds to the corresponding
	 * value from the arrayOptions based on the current value (array key).
	 *
	 * Otherwise, it returns the string representation of the current value,
	 * or an empty string if the value is undefined or null.
	 *
	 * @param {any} value - The value to be parsed.
	 * @returns {string} The parsed value as a string.
	 */
	parseValue(value)
	{
		// If this is an array field, the value will correspond to the array key, not the actual value.
		if (!_isEmpty(this.arrayOptions))
		{
			const option = this.arrayOptions.find((e) => e.key === value)

			if (!_isEmpty(option))
				return option.value?.toString() ?? ''
		}

		return value?.toString() ?? ''
	}

	/**
	 * Updates the value of the field.
	 *
	 * This method accepts a new value and updates the field's value accordingly.
	 * If the provided value is an object with a 'Value' property, it is treated as a special case
	 * for handling dropdown options where 'Value' represents the new value, and 'List' contains the options.
	 * If 'List' is an array, it sets the options list and tries to add the selected option to the list if not already present.
	 * Otherwise, it directly sets the provided value as the field's value.
	 *
	 * Note: To keep the context «this» and for it to work on «@update:model-value="model.ValField.updateValue"»,
	 * it needs to be declared this way and not as a function of the class.
	 *
	 * @param {any} newValue - The new value to set for the field
	 */
	updateValue(newValue)
	{
		// Prototype. So that it is possible to use the dropdowns that send the object with Text and Value of the option.
		if (!_isEmpty(newValue) && typeof newValue === 'object' && _has(newValue, 'Value'))
		{
			// The initial options list of the dropdown (lazy load - may have one option previously selected).
			if (Array.isArray(newValue.List))
			{
				let items = newValue.List

				items = items.map((item) => {
					// FIXME: review need for computed once i18n is refactored
					return { key: item.key, value: computed(() => this.parseValue(item.value)) }
				})

				reactive(this).options = items

				// If for some reason the selected option is not in the list of options, add it.
				if (
					!_isEmpty(newValue.Selected) &&
					!_some(newValue.List, (option) => option.key === newValue.Selected)
				) {
					const selectedItem = {
						key: newValue.Selected,
						// FIXME: review need for computed once i18n is refactored
						value: computed(() => this.parseValue(newValue.Value))
					}

					reactive(this).options.unshift(selectedItem)
				}

				// Total rows is unknown if query returned results and response.TotalRows is "0"
				const isTotalRowsUnknown = newValue.List.length > 0 && newValue.TotalRows === 0

				reactive(this).totalRows = isTotalRowsUnknown
					? undefined
					: Math.max(newValue.TotalRows, items.length)
			}

			reactive(this).value = newValue.Value
		}
		else
			reactive(this).value = newValue
	}

	/**
	 * To keep the context «this» and for it to work on «@update:model-value="model.ValField.updateValue"»,
	 * it needs to be bound in a function.
	 */
	fnUpdateValue = (newValue) => this.updateValue(newValue)

	/**
	 * Hydrates the raw data for this field coming from the server
	 * with the necessary metadata.
	 * @param {object} rawDataFieldValue - The data to be hydrated
	 */
	hydrate(rawDataFieldValue)
	{
		let rawDataFieldOriginalValue = undefined

		if (rawDataFieldValue instanceof modelFieldType.Base)
		{
			rawDataFieldOriginalValue = rawDataFieldValue.originalValue
			rawDataFieldValue = rawDataFieldValue.value
		}

		this.updateValue(rawDataFieldValue)

		// Deep clone is used to ensure the object is not reactive
		this.originalValue = rawDataFieldOriginalValue === undefined
			? this.cloneValue()
			: _cloneDeep(rawDataFieldOriginalValue)

		this.isReady = true
	}

	/**
	 * Initializes this field with a clone of the value of the provided field.
	 * @param {object} other - The field to clone the value from
	 * @returns {this} The current instance with the cloned value
	 */
	cloneFrom(other)
	{
		if (other instanceof Base)
		{
			const _value = other.cloneValue()
			/*
				The lookup fields, in addition to the value, also have a list of options.
				If we don't clone this list, when we change the form's mode,
					the GridTableList will lose the Lookups data during the recovery of the Grid's original value (resetFormFields).
				TODO: However, it is necessary to change the logic of changing the mode.
						It should make a request to the server to load the new form data
						OR
						Requires revision for the manwin «BEFORE_LOAD_...» and IF's based on the mode in the Load of the ViewModel.
			*/
			if (this.type === 'Lookup' && other.type === 'Lookup' && Array.isArray(other.options))
				this.hydrate({ Value: _value, List: _cloneDeep(other.options) })
			else
				this.hydrate(_value)
		}

		return this
	}

	/**
	 * Deep clones the field's value.
	 * @returns {any} A deep cloned value of the field.
	 */
	cloneValue()
	{
		return _cloneDeep(this.value)
	}

	/**
	 * Checks if the field's value is equal to the provided value.
	 * @param {any} otherValue - The value to compare with the field's value
	 * @returns {boolean} True if the field's value is equal to the provided value, false otherwise.
	 */
	hasSameValue(otherValue)
	{
		return _isEqual(this.value, otherValue)
	}

	/**
	 * Clears the field's value by setting it to the field's standard empty value.
	 */
	clearValue()
	{
		this.value = this.constructor.EMPTY_VALUE
	}

	/**
	 * Validates the size of the field.
	 * @returns {boolean} True if the field's size is valid, false otherwise.
	 */
	validateSize()
	{
		return true
	}

	/**
	 * Validates the value of the field.
	 * @returns {boolean} True if the field's value is valid, false otherwise.
	 */
	validateValue()
	{
		return this.isRequired
			? (this.value !== undefined && this.value !== null && this.value !== this.constructor.EMPTY_VALUE)
			: true
	}

	/**
	 * Checks if there are any server error messages associated with the field.
	 * @returns {boolean} True if there are server error messages, false otherwise.
	 */
	hasServerErrorMessages()
	{
		return this.serverErrorMessages.length > 0
	}

	/**
	 * Clears the server error messages associated with the field.
	 */
	clearServerErrorMessages()
	{
		this.serverErrorMessages.length = 0
	}
}

export class Geographic extends Base
{
	constructor(options)
	{
		super({
			type: 'Geographic'
		})

		_assignIn(this, options)
	}
}

export class String extends Base
{
	static EMPTY_VALUE = ''

	constructor(options)
	{
		super({
			type: 'String',
			maxLength: -1
		})

		_assignIn(this, options)
	}

	validateSize()
	{
		if (this.maxLength > 0)
			return _size(this.value) <= this.maxLength
		return true
	}
}

export class MultiLineString extends String
{
	constructor(options)
	{
		super({
			maxLength: -1
		})

		_assignIn(this, options)

		// No limit (varchar max)
		this.maxLength = -1
	}
}

export class Password extends String
{
	constructor(options)
	{
		super({
			type: 'Password',
			maxLength: -1
		})

		_assignIn(this, options)
	}
}

export class PrimaryKey extends String
{
	constructor(options)
	{
		super({
			maxLength: 16
		})

		_assignIn(this, options)
	}

	validateSize()
	{
		// GUIDs
		if (this.maxLength === 16)
			return _isEmpty(this.value) || uuidValidate(this.value)
		// Other key types
		else if (this.maxLength > 0)
			return _size(this.value) <= this.maxLength
		return true
	}
}

export class ForeignKey extends PrimaryKey
{
	static EMPTY_VALUE = null

	constructor(options)
	{
		super({
			relatedArea: null
		})

		_assignIn(this, options)
	}
}

export class Date extends Base
{
	constructor(options)
	{
		super({
			type: 'Date'
		})

		_assignIn(this, options)
	}

	get displayValue()
	{
		const systemDataStore = useSystemDataStore()
		return genericFunctions.dateDisplay(this.value, systemDataStore.system.dateFormat[this.type])
	}

	get serverValue()
	{
		return genericFunctions.dateToISOString(this.value)
	}
}

export class DateTime extends Date
{
	constructor(options)
	{
		super({
			type: 'DateTime'
		})

		_assignIn(this, options)
	}
}

export class DateTimeSeconds extends DateTime
{
	constructor(options)
	{
		super({
			type: 'DateTimeSeconds'
		})

		_assignIn(this, options)
	}
}

export class Time extends Base
{
	static EMPTY_VALUE = '__:__'

	constructor(options)
	{
		super({
			type: 'Time'
		})

		_assignIn(this, options)
	}

	get displayValue()
	{
		if (_isEmpty(super.displayValue) || super.displayValue === Time.EMPTY_VALUE)
			return ''

		return genericFunctions.timeToString(this.value)
	}

	get serverValue()
	{
		return this.value !== Time.EMPTY_VALUE ? this.value : null
	}

	hydrate(rawDataFieldValue)
	{
		// Ensure instance-specific empty value representation
		// (convert '' to '__:__')
		if (_isEmpty(rawDataFieldValue))
			rawDataFieldValue = Time.EMPTY_VALUE

		super.hydrate(rawDataFieldValue)
	}
}

export class Boolean extends Base
{
	constructor(options)
	{
		super({
			type: 'Boolean'
		})

		_assignIn(this, options)
	}

	get serverValue()
	{
		return this.value ?? false
	}

	clearValue()
	{
		this.value = false
	}
}

export class Number extends Base
{
	static EMPTY_VALUE = 0

	constructor(options)
	{
		super({
			type: 'Number',
			maxDigits: -1,
			decimalDigits: 0,
			maxIntegers: -1,
			maxDecimals: -1
		})

		_assignIn(this, options)
	}

	get displayValue()
	{
		const value = new Number(this.value)
		if (isNaN(value))
			return ''
		return value.toFixed(this.decimalDigits)
	}

	validateValue()
	{
		return super.validateValue() && (this.isRequired ? !isNaN(new Number(this.value)) : true)
	}
}

export class Image extends Base
{
	constructor(options)
	{
		super({
			type: 'Image'
		})

		_assignIn(this, options)
	}
}

export class Document extends Base
{
	constructor(options)
	{
		super({
			type: 'Document'
		})

		_assignIn(this, options)
	}
}

export class MultipleValues extends Base
{
	constructor(options)
	{
		super({
			type: 'MultipleValues',
			value: []
		})

		_assignIn(this, options)
	}

	clearValue()
	{
		this.value = []
	}
}

class GridTableListValue
{
	constructor(fieldValue)
	{
		this.Elements = []
		this.NewElements = _get(fieldValue, 'NewElements', [])
		this.NewRecordTemplate = _get(fieldValue, 'NewRecordTemplate')
		this.EditedElements = _get(fieldValue, 'EditedElements', [])
		this.RemovedElements = _get(fieldValue, 'RemovedElements', [])
	}

	get EmptyRows()
	{
		return this.NewElements.filter((row) => !row.isDirty)
	}

	get isDirty()
	{
		return _some([
			_some(this.Elements, (el) => el.isDirty),
			_some(this.NewElements, (el) => el.isDirty),
		])
	}

	getViewModel(viewModelData, viewModelClass, vueContext)
	{
		if (viewModelData === undefined || viewModelClass === undefined || vueContext === undefined)
			return

		let viewModel = new viewModelClass(vueContext)
		viewModel.hydrate(viewModelData)
		return viewModel
	}

	addNewModel(viewModelData, viewModelClass, vueContext)
	{
		let viewModel = this.getViewModel(viewModelData, viewModelClass, vueContext)
		if (viewModel !== undefined)
			this.NewElements.push(viewModel)
	}

	trimEmptyRows(full)
	{
		let pop = this.EmptyRows.length
		if (!full)
			pop = pop - 1

		while (pop--)
			this.NewElements.pop()

		// Ensure the row left by the trim operation has no
		// server error messages from previous attempts to save the form
		_forEach(this.EmptyRows, (row) => row.clearServerErrorMessages())
	}

	markForDeletion(viewModelData)
	{
		// Check if this is a new row
		// New rows are removed immediately
		// instead of being marked to be deleted
		const index = this.NewElements.indexOf(viewModelData)

		if (index > -1)
			this.NewElements.splice(index, 1)
		else
			this.RemovedElements.push(viewModelData.QPrimaryKey)
	}

	undoDeletion(viewModelData)
	{
		const index = this.RemovedElements.indexOf(viewModelData.QPrimaryKey)

		if (index > -1)
			this.RemovedElements.splice(index, 1)
	}

	setValue(newValue, viewModelClass, vueContext)
	{
		if (viewModelClass === undefined || vueContext === undefined)
			return

		let elements = [],
			newElements = []

		_forEach(_get(newValue, 'Elements', []), (viewModelData) => {
			let viewModel = this.getViewModel(viewModelData, viewModelClass, vueContext)
			if (viewModel !== undefined)
				elements.push(viewModel)
		})

		_forEach(_get(newValue, 'NewElements', []), (viewModelData) => {
			let viewModel = this.getViewModel(viewModelData, viewModelClass, vueContext)
			if (viewModel !== undefined)
				newElements.push(viewModel)
		})

		// For cases when more then one processe update value, we need update all at some time and do not use push to the central property.
		// bug case: Initial load of form and restore os the last tab (SelectTab)
		this.Elements.splice(0, Infinity, ...elements)
		this.NewElements.splice(0, Infinity, ...newElements)
		this.RemovedElements.splice(0, Infinity, ..._get(newValue, 'RemovedElements', []))
		this.NewRecordTemplate = _get(newValue, 'NewRecordTemplate')
	}

	getCurrentState()
	{
		return {
			Elements: this.Elements.filter((row) => !this.RemovedElements.includes(row.QPrimaryKey)),
			RemovedElements: this.Elements.filter((row) => this.RemovedElements.includes(row.QPrimaryKey)),
			NewElements: this.NewElements.filter((row) => row.isDirty)
		}
	}

	getCurrentStateSrvObject(removedElementsOnlyKey = false, elementsOnlyDirty = false)
	{
		let currentState = this.getCurrentState()

		return {
			Elements: _flatMap(elementsOnlyDirty ? currentState.Elements.filter((row) => row.isDirty) : currentState.Elements, (row) => row.serverObjModel),
			RemovedElements: _flatMap(currentState.RemovedElements, (row) => removedElementsOnlyKey ? row.QPrimaryKey : row.serverObjModel),
			NewElements: _flatMap(currentState.NewElements, (row) => row.serverObjModel)
		}
	}

	get serverValue()
	{
		// For existing rows, we only send those that are edited (dirty)
		// and are not marked to be deleted.
		this.EditedElements = this.Elements.filter((row) => row.isDirty && !this.RemovedElements.includes(row.QPrimaryKey))
		const svrEditedElements = _flatMap(this.EditedElements, (row) => row.serverObjModel)

		// For new rows, we must clear the client-side key.
		// Only those that are not empty (dirty) are sent.
		const svrNewElements = _flatMap(this.NewElements.filter((row) => row.isDirty), (row) => {
			row.QPrimaryKey = null
			return row.serverObjModel
		})

		return {
			EditedElements: svrEditedElements,
			NewElements: svrNewElements,
			RemovedElements: this.RemovedElements
		}
	}

	clearServerErrorMessages()
	{
		_forEach(this.Elements, (el) => el.clearServerErrorMessages())
		_forEach(this.NewElements, (el) => el.clearServerErrorMessages())
	}

	/**
	 * Deep clones the field's value.
	 * @override
	 */
	clone()
	{
		const _clone = new GridTableListValue()

		this.Elements.forEach((model) => _clone.Elements.push(model.clone()))
		this.NewElements.forEach((model) => _clone.Elements.push(model.clone()))

		_clone.RemovedElements = _cloneDeep(this.RemovedElements)
		_clone.NewRecordTemplate = _cloneDeep(this.NewRecordTemplate)

		return _clone
	}
}

export class GridTableList extends Base
{
	constructor(options, vueContext)
	{
		super({
			type: 'GridTableList',
			value: new GridTableListValue(),
			viewModelClass: undefined
		})

		/** Just for initialize the View Model of Row's (Resources + NavigationId for requests) */
		this.vueContext = vueContext

		_assignIn(this, options)
	}

	get isDirty() { return this.value.isDirty }

	get Elements() { return this.value.Elements }

	get NewElements() { return this.value.NewElements }

	get EditedElements() { return this.value.EditedElements }

	get RemovedElements() { return this.value.RemovedElements }

	get EmptyRows() { return this.value.EmptyRows }

	get serverValue() { return this.value.serverValue }

	updateValue(newValue)
	{
		this.value.setValue(newValue, this.viewModelClass, this.vueContext)
	}

	clearValue()
	{
		this.updateValue(null)
	}

	validateValue()
	{
		return super.validateValue()
	}

	validateSize()
	{
		return true
	}

	setModelFieldValue(eventData)
	{
		let modelUId = _get(eventData, 'key'),
			fieldData = _get(eventData, 'value'),
			fieldName = _get(fieldData, 'modelField'),
			fieldValue = _get(fieldData, 'value')

		if (_isEmpty(modelUId) || _isEmpty(fieldName) || !_has(this, 'value.Elements'))
			return

		let modelIndex = _findIndex(this.value.Elements, (row) => row.uniqueIdentifier === modelUId)

		if (modelIndex !== -1)
			this.value.Elements[modelIndex][fieldName].updateValue(fieldValue)
		else
		{
			modelIndex = _findIndex(this.value.NewElements, (row) => row.uniqueIdentifier === modelUId)
			if (modelIndex !== -1)
				this.value.NewElements[modelIndex][fieldName].updateValue(fieldValue)
		}
	}

	addNewModel()
	{
		let newModelData = _cloneDeep(this.value.NewRecordTemplate)

		if (newModelData)
		{
			newModelData[this.viewModelClass.QPrimaryKeyName] = uuidv4()
			this.value.addNewModel(newModelData, this.viewModelClass, this.vueContext)
		}
	}

	trimEmptyRows(full)
	{
		this.value.trimEmptyRows(full)
	}

	markForDeletion(row)
	{
		this.value.markForDeletion(row)
	}

	undoDeletion(row)
	{
		this.value.undoDeletion(row)
	}

	clearServerErrorMessages()
	{
		this.value.clearServerErrorMessages()
	}

	hasSameValue(otherValue)
	{
		if (!(otherValue instanceof GridTableListValue))
			return false

		return _isEqual(this.value.getCurrentStateSrvObject(), otherValue.getCurrentStateSrvObject())
	}

	/**
	 * @override
	 */
	cloneValue()
	{
		return this.value.clone()
	}
}

export default {
	Base,
	Geographic,
	String,
	MultiLineString,
	Password,
	PrimaryKey,
	ForeignKey,
	Date,
	DateTime,
	DateTimeSeconds,
	Time,
	Boolean,
	Number,
	Image,
	Document,
	MultipleValues,
	GridTableList
}
