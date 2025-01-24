import { computed, reactive, readonly } from 'vue'
import { validate as uuidValidate, v4 as uuidv4 } from 'uuid'
import _assignIn from 'lodash-es/assignIn'
import _cloneDeep from 'lodash-es/cloneDeep'
import _findIndex from 'lodash-es/findIndex'
import _flatMap from 'lodash-es/flatMap'
import _forEach from 'lodash-es/forEach'
import _get from 'lodash-es/get'
import _has from 'lodash-es/has'
import _isEmpty from 'lodash-es/isEmpty'
import _isEqual from 'lodash-es/isEqual'
import _some from 'lodash-es/some'
import _toNumber from 'lodash-es/toNumber'

import { useSystemDataStore } from '@/stores/systemData.js'
import { useTracingDataStore } from '@/stores/tracingData.js'
import { useUserDataStore } from '@/stores/userData.js'

import { postData } from '@/api/network'
import { validateCoordinate } from '@/utils/geography.js'
import genericFunctions from '@/mixins/genericFunctions.js'
import { BlockConditionStack, FillConditionStack, HideConditionStack } from '@/models/fields/conditionStack.js'

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
		this.showWhenConditions = new HideConditionStack()
		this.blockWhenConditions = new BlockConditionStack()
		this.fillWhenConditions = new FillConditionStack()
		// Ignore the field when the model is submitted to the server.
		this.ignoreFldSubmit = false
		this.isRequired = false
		this.originalValue = this.constructor.EMPTY_VALUE
		this.arrayOptions = []
		this.serverErrorMessages = []
		this.serverWarningMessages = []
		// Indicates if the field is permanently readonly, regardless of form mode.
		this.isFixed = false

		// This should be a private field, but unfortunately they don't work with proxies:
		// https://github.com/tc39/proposal-class-fields/issues/106
		Object.defineProperty(this, '_value', {
			value: this.constructor.EMPTY_VALUE,
			configurable: true,
			writable: true,
			enumerable: false
		})

		_assignIn(this, options)
	}

	/**
	 * The current value of the field.
	 */
	get value()
	{
		return this._value
	}

	/**
	 * Setter for the field value.
	 */
	set value(newValue)
	{
		this.updateValue(newValue)
	}

	/**
	 * Checks if the field's value is different from its original value (dirty).
	 * @type {boolean} True if the field's value is dirty, false otherwise.
	 */
	get isDirty()
	{
		return !this.isFixed && !this.hasSameValue(this.originalValue)
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
	 * Checks if there are any server warning messages associated with the field.
	 * @returns {boolean} True if there are server warning messages, false otherwise.
	 */
	get hasServerWarningMessages()
	{
		return this.serverWarningMessages.length > 0
	}

	/**
	 * Checks if there are any server error messages associated with the field.
	 * @returns {boolean} True if there are server error messages, false otherwise.
	 */
	get hasServerErrorMessages()
	{
		return this.serverErrorMessages.length > 0
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
		let value

		// Prototype. So that it is possible to use the dropdowns that send the object with Text and Value of the option.
		if (!_isEmpty(newValue) && this.type === 'Lookup')
		{
			// The initial options list of the dropdown (lazy load - may have one option previously selected).
			if (Array.isArray(newValue.List))
			{
				let items = newValue.List

				items = items.map((item) => ({
					key: item.key,
					// FIXME: review need for computed once i18n is refactored.
					value: computed(() => this.parseValue(item.value))
				}))

				reactive(this).options = items

				// If for some reason the selected option is not in the list of options, add it.
				if (!_isEmpty(newValue.Selected) &&
					!_some(newValue.List, (option) => option.key === newValue.Selected))
				{
					const selectedItem = {
						key: newValue.Selected,
						// FIXME: review need for computed once i18n is refactored.
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

			// If value is an object
			if (_has(newValue, 'Value'))
				value = newValue.Value
			else
				value = newValue
		}
		else
			value = newValue

		if (this.isValidType(value))
			reactive(this)._value = this.sanitizeValue(value)
		else
		{
			const tracing = useTracingDataStore()
			tracing.addError({
				origin: 'updateValue',
				message: `Tried to assign an unsupported value type to "${this.id}".`,
				contextData: value
			})
		}
	}

	/**
	 * To keep the context «this» and for it to work on «@update:model-value="model.ValField.updateValue"»,
	 * it needs to be bound in a function.
	 * @param {any} newValue - The new value to set for the field
	 */
	fnUpdateValue = (newValue) => this.updateValue(newValue)

	/**
	 * Updates the value of the field from the change event.
	 * @param {object} event - The change event
	 */
	fnUpdateValueOnChange = (event) => this.updateValue(event.target?.value)

	/**
	 * Sanitizes the specified value, can be useful so the field won't be marked as dirty
	 * when assigned a different value, but still equivalent.
	 * @param {any} value - The value to sanitize
	 * @returns The sanitized value
	 */
	sanitizeValue(value)
	{
		if (!this.isValidType(value))
			throw new Error('Unsupported value type.')
		return value
	}

	/**
	 * Resets the current value back to it's original one.
	 */
	resetValue()
	{
		if (!this.isDirty)
			return

		this.hydrate(this.originalValue)
	}

	/**
	 * Hydrates the raw data for this field coming from the server
	 * with the necessary metadata.
	 * @param {any} rawDataFieldValue - The data to be hydrated
	 */
	hydrate(rawDataFieldValue)
	{
		let rawDataFieldOriginalValue = undefined

		// We are also supporting here the clone from an already existing field.
		if (rawDataFieldValue instanceof Base)
		{
			rawDataFieldOriginalValue = rawDataFieldValue.originalValue
			rawDataFieldValue = rawDataFieldValue.cloneValue()
		}

		this.updateValue(rawDataFieldValue)

		// Deep clone is used to ensure the object is not reactive.
		this.originalValue = rawDataFieldOriginalValue === undefined
			? this.cloneValue()
			: _cloneDeep(rawDataFieldOriginalValue)

		this.isReady = true
	}

	/**
	 * Initializes this field with a clone of the value of the provided field.
	 * @param {object} other - The field to clone the value from
	 * @returns {this} The current instance with the cloned value.
	 */
	cloneFrom(other)
	{
		if (other instanceof Base)
		{
			/*
				The lookup fields, in addition to the value, also have a list of options.
				If we don't clone this list, when we change the form's mode,
					the GridTableList will lose the Lookups data during the recovery of the Grid's original value (resetValue).
				TODO: However, it is necessary to change the logic of changing the mode.
						It should make a request to the server to load the new form data
						OR
						Requires revision for the manwin «BEFORE_LOAD_...» and IF's based on the mode in the Load of the ViewModel.
			*/
			if (this.type === 'Lookup' && other.type === 'Lookup' && Array.isArray(other.options))
				this.hydrate({ Value: other.cloneValue(), List: _cloneDeep(other.options) })
			else
				this.hydrate(other)
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
	 * @param {any} value - A value to overwrite the standard empty value
	 */
	clearValue(value)
	{
		const val = typeof value === 'undefined' ? this.constructor.EMPTY_VALUE : value
		this.updateValue(val)
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
			? this.value !== this.constructor.EMPTY_VALUE
			: true
	}

	/**
	 * Checks if the specified value has a valid type.
	 * @param {any} value - The value to check
	 * @returns True if the specified value is of a valid type, false otherwise
	 */
	isValidType()
	{
		return true
	}

	/**
	 * Set server error messages associated with the field.
	 * @param {array} errors The server errors
	 */
	setServerErrorMessages(errors)
	{
		this.serverErrorMessages = errors
	}

	/**
	 * Clears the server error messages associated with the field.
	 */
	clearServerErrorMessages()
	{
		this.serverErrorMessages.length = 0
	}

	/**
	 * Set server warning messages associated with the field.
	 * @param {array} warnings The server warnings
	 */
	setServerWarningMessages()
	{
		this.serverWarningMessages = []
	}

	/**
	 * Clears the server warning messages associated with the field.
	 */
	clearServerWarningMessages()
	{
		this.serverWarningMessages.length = 0
	}
}

export class String extends Base
{
	static EMPTY_VALUE = ''

	constructor(options)
	{
		super(_assignIn({
			type: 'String',
			maxLength: -1
		}, options))
	}

	/**
	 * @override
	 */
	sanitizeValue(value)
	{
		const sanitizedVal = super.sanitizeValue(value)

		if (genericFunctions.isEmpty(sanitizedVal))
			return this.constructor.EMPTY_VALUE

		return sanitizedVal
	}

	/**
	 * @override
	 */
	validateSize()
	{
		if (this.maxLength > 0)
		{
			const length = this.value?.length ?? 0
			return length <= this.maxLength
		}
		return true
	}

	/**
	 * @override
	 */
	isValidType(value)
	{
		return typeof value === 'string' || genericFunctions.isEmpty(value)
	}
}

export class MultiLineString extends String
{
	constructor(options)
	{
		super(_assignIn({
			// No limit (varchar max)
			maxLength: -1
		}, options))
	}

	/**
	 * @override
	 */
	get serverValue()
	{
		// The server expects \r\n, but text edited through web textarea only has \n. So we convert
		// it first from server format to web format, in case the text came from the server and wasn't edited.
		let value = this.value?.replaceAll('\r\n', '\n')
		// Convert to server format.
		return value?.replaceAll('\n', '\r\n')
	}
}

export class Password extends String
{
	constructor(options)
	{
		super(_assignIn({
			type: 'Password',
			maxLength: -1
		}, options))
	}
}

export class PrimaryKey extends String
{
	constructor(options)
	{
		super(_assignIn({
			maxLength: 16
		}, options))
	}

	/**
	 * @override
	 */
	get serverValue()
	{
		return this.value === this.constructor.EMPTY_VALUE ? null : this.value
	}

	/**
	 * @override
	 */
	validateSize()
	{
		// GUIDs
		if (this.maxLength === 16)
			return _isEmpty(this.value) || uuidValidate(this.value)
		// Other key types
		return super.validateSize()
	}
}

export class ForeignKey extends PrimaryKey
{
	constructor(options)
	{
		super(_assignIn({
			relatedArea: null
		}, options))
	}
}

export class Coordinate extends String
{
	constructor(options)
	{
		super(_assignIn({
			type: 'Coordinate'
		}, options))
	}

	/**
	 * @override
	 */
	isValidType(value)
	{
		return super.isValidType(value) && validateCoordinate(value)
	}
}

export class Geographic extends Base
{
	constructor(options)
	{
		super(_assignIn({
			type: 'Geographic'
		}, options))
	}

	/**
	 * @override
	 */
	isValidType(value)
	{
		return typeof value === 'object'
	}
}

export class Date extends Base
{
	static EMPTY_VALUE = ''

	constructor(options)
	{
		const systemDataStore = useSystemDataStore()

		super(_assignIn({
			type: 'Date',
			dateFormat: systemDataStore.system.dateFormat.date
		}, options))
	}

	/**
	 * @override
	 */
	get displayValue()
	{
		return genericFunctions.dateDisplay(this.value, this.dateFormat)
	}

	/**
	 * @override
	 */
	get serverValue()
	{
		return genericFunctions.dateToISOString(this.value)
	}

	/**
	 * @override
	 */
	isValidType(value)
	{
		return genericFunctions.isDate(value) && !isNaN(value) || genericFunctions.isEmpty(value)
	}

	/**
	 * @override
	 */
	sanitizeValue(value)
	{
		const sanitizedVal = super.sanitizeValue(value)

		if (genericFunctions.isEmpty(sanitizedVal))
			return this.constructor.EMPTY_VALUE

		return new window.Date(window.Date.parse(sanitizedVal))
	}
}

export class DateTime extends Date
{
	constructor(options)
	{
		const systemDataStore = useSystemDataStore()

		super(_assignIn({
			type: 'DateTime',
			dateFormat: systemDataStore.system.dateFormat.dateTime
		}, options))
	}
}

export class DateTimeSeconds extends DateTime
{
	constructor(options)
	{
		const systemDataStore = useSystemDataStore()

		super(_assignIn({
			type: 'DateTimeSeconds',
			dateFormat: systemDataStore.system.dateFormat.dateTimeSeconds
		}, options))
	}
}

export class Time extends Base
{
	static EMPTY_VALUE = '__:__'

	constructor(options)
	{
		super(_assignIn({
			type: 'Time'
		}, options))
	}

	/**
	 * @override
	 */
	get displayValue()
	{
		if (_isEmpty(super.displayValue) || super.displayValue === Time.EMPTY_VALUE)
			return ''

		return genericFunctions.timeToString(this.value)
	}

	/**
	 * @override
	 */
	get serverValue()
	{
		return this.value !== Time.EMPTY_VALUE ? this.value : null
	}

	/**
	 * @override
	 */
	hydrate(rawDataFieldValue)
	{
		// Ensure instance-specific empty value representation
		// (convert '' to '__:__')
		if (_isEmpty(rawDataFieldValue))
			rawDataFieldValue = Time.EMPTY_VALUE

		super.hydrate(rawDataFieldValue)
	}

	/**
	 * @override
	 */
	isValidType(value)
	{
		return typeof value === 'object' || typeof value === 'string' || value === null
	}

	/**
	 * @override
	 */
	sanitizeValue(value)
	{
		const sanitizedVal = super.sanitizeValue(value)

		if (typeof sanitizedVal === 'object')
			return sanitizedVal ? genericFunctions.timeToString(sanitizedVal) : ''

		return sanitizedVal
	}
}

export class Boolean extends Base
{
	constructor(options)
	{
		super(_assignIn({
			type: 'Boolean'
		}, options))
	}

	/**
	 * @override
	 */
	get serverValue()
	{
		return this.value ?? false
	}

	/**
	 * @override
	 */
	sanitizeValue(value)
	{
		const sanitizedVal = super.sanitizeValue(value)

		if (typeof sanitizedVal === 'number')
			return sanitizedVal === 1

		return sanitizedVal
	}

	/**
	 * @override
	 */
	clearValue()
	{
		super.clearValue(false)
	}

	/**
	 * @override
	 */
	isValidType(value)
	{
		return typeof value === 'boolean' || value === this.constructor.EMPTY_VALUE || [0, 1].includes(value)
	}
}

export class Number extends Base
{
	static EMPTY_VALUE = 0

	constructor(options)
	{
		super(_assignIn({
			type: 'Number',
			maxDigits: -1,
			decimalDigits: 0,
			maxIntegers: -1,
			maxDecimals: -1
		}, options))
	}

	/**
	 * @override
	 */
	get displayValue()
	{
		const value = _toNumber(this.value)
		if (isNaN(value))
			return ''
		return value.toFixed(this.decimalDigits)
	}

	/**
	 * @override
	 */
	sanitizeValue(value)
	{
		const sanitizedVal = super.sanitizeValue(value)
		return _toNumber(sanitizedVal)
	}

	/**
	 * @override
	 */
	validateValue()
	{
		return super.validateValue() && (this.isRequired ? !isNaN(_toNumber(this.value)) : true)
	}

	/**
	 * @override
	 */
	isValidType(value)
	{
		return !isNaN(value)
	}
}

export class Image extends Base
{
	constructor(options)
	{
		super(_assignIn({
			type: 'Image'
		}, options))
	}

	/**
	 * @override
	 */
	isValidType(value)
	{
		return genericFunctions.validateImageFormat(value)
	}
}

export class DocumentData extends Base
{
	constructor(options)
	{
		super(_assignIn({
			versionSubmitAction: readonly({
				insert: 0, // The initial version of the file was submitted.
				submit: 1, // A new version of an already existing file was submitted.
				unlock: 2  // No new version was submitted, the editing state was simply changed.
			}),
			deleteTypes: readonly({
				current: 0,  // Deletes the lastest version.
				versions: 1, // Deletes all versions except the last one.
				all: 2       // Deletes the document and all it's versions.
			}),
			value: {
				documentId: null,
				ticket: null,
				fileData: null,
				deleteType: -1,
				submitMode: -1,
				version: '1'
			}
		}, options))
	}

	/**
	 * @override
	 */
	get isDirty()
	{
		return this.value.fileData !== null || this.value.deleteType !== -1
	}

	/**
	 * @override
	 */
	hasSameValue()
	{
		// FIXME: If the document is changed server-side while the user navigates to the support form,
		//        when they return, the value saved in the client-side store will be restored
		//        in favor of the newer version from the server-side.
		return true
	}

	/**
	 * @override
	 */
	updateValue(newValue)
	{
		super.updateValue(_cloneDeep(newValue))
	}

	/**
	 * The document properties.
	 */
	get properties()
	{
		let createdDate = null,
			currentUser = '',
			fileName = '',
			extension = '',
			fileSize = ''

		if (this.value.fileData !== null)
		{
			const userDataStore = useUserDataStore()
			currentUser = userDataStore.username

			createdDate = new Date()
			createdDate.updateValue(this.value.fileData.lastModifiedDate)

			fileName = this.value.fileData.name
			extension = fileName.split('.').pop().toLowerCase()
			fileSize = `${this.value.fileData.size} bytes`
		}

		return {
			author: currentUser,
			createdDate: createdDate?.displayValue ?? '',
			editor: currentUser,
			fileType: extension,
			name: fileName,
			size: fileSize,
			version: this.value.version
		}
	}

	/**
	 * The document data to be submitted to the server.
	 */
	get dataToSubmit()
	{
		if (this.value.fileData === null)
			return null

		const submitData = new FormData()

		submitData.append(`${this.value.documentId}_file`, this.value.fileData)
		submitData.append('ticket', this.value.ticket)
		submitData.append('mode', this.value.submitMode)
		submitData.append('version', this.value.version)

		return submitData
	}

	/**
	 * Sets up the necessary document properties.
	 * @param {string} id The field id
	 * @param {string} ticket The file ticket
	 */
	setup(id, ticket)
	{
		this.value.documentId = id
		this.value.ticket = ticket
	}

	/**
	 * Resets the document properties.
	 */
	reset()
	{
		this.value.fileData = null
		this.value.deleteType = -1
	}

	/**
	 * Sets a new unsaved file.
	 * @param {object} file The file
	 * @param {number} submitMode The type of submit
	 * @param {string} version The document version
	 */
	setNewFile(file, submitMode, version = '1')
	{
		if (!(file instanceof File) ||
			!Object.values(this.versionSubmitAction).includes(submitMode) ||
			typeof version !== 'string')
			return

		this.value.fileData = file
		this.value.submitMode = submitMode
		this.value.version = version
	}

	/**
	 * Deletes the file and possibly it's versions, depending on the specified delete type.
	 * @param {number} deleteType The type of delete action to perform
	 */
	delete(deleteType)
	{
		if (!Object.values(this.deleteTypes).includes(deleteType))
			return

		this.value.deleteType = -1

		if (deleteType === this.deleteTypes.current)
		{
			if (this.value.fileData !== null)
				this.value.fileData = null
			else
				this.value.deleteType = this.deleteTypes.current
		}
		else if (deleteType === this.deleteTypes.versions)
			this.value.deleteType = this.deleteTypes.versions
		else
		{
			this.value.fileData = null
			this.value.deleteType = this.deleteTypes.all
		}
	}
}

export class Document extends Base
{
	constructor(options)
	{
		super(_assignIn({
			type: 'Document',
			currentDocument: null,
			tickets: {},
			properties: null,
			documentFK: null
		}, options))
	}

	/**
	 * @override
	 */
	get isDirty()
	{
		return super.isDirty || this.properties.isDirty || this.currentDocument.isDirty
	}

	/**
	 * @override
	 */
	isValidType(value)
	{
		return typeof value === 'string' || value === this.constructor.EMPTY_VALUE
	}

	/**
	 * Sets the tickets to retrieve every document version from the server.
	 * @param {string} primaryKey The primary key of the current record
	 * @param {string} navigationId The current navigation id
	 * @returns A promise with the response from the server.
	 */
	setTickets(primaryKey, navigationId)
	{
		const params = {
			tableName: this.area,
			fieldName: this.originId,
			keyValue: primaryKey
		}

		return new Promise((resolve) => {
			postData(
				this.area,
				'GetDocumsTickets',
				params,
				(data, request) => {
					if (request.data?.Success)
					{
						this.tickets = {}
						for (let i in data.tickets)
						{
							const t = data.tickets[i]
							this.tickets[t.id] = t.ticket
						}

						this.properties.updateValue(data.properties)
						this.documentFK.updateValue(data.properties?.documentId ?? '')

						// Sets up the current document properties.
						this.currentDocument.setup(this.id, this.tickets.main)

						resolve(true)
					}
					else
					{
						const tracingDataStore = useTracingDataStore()
						tracingDataStore.addError({
							origin: 'setTickets',
							message: `Error found while trying to retrieve the document tickets for field "${this.id}".`
						})

						resolve(false)
					}
				},
				undefined,
				undefined,
				navigationId)
		})
	}
}

export class MultipleValues extends Base
{
	constructor(options)
	{
		super(_assignIn({
			type: 'MultipleValues',
			_value: []
		}, options))
	}

	/**
	 * @override
	 */
	clearValue()
	{
		super.clearValue([])
	}

	/**
	 * @override
	 */
	isValidType(value)
	{
		return typeof value === 'object'
	}
}

class GridTableListValue
{
	constructor(fieldValue)
	{
		this.elements = []
		this.newElements = _get(fieldValue, 'newElements', [])
		this.newRecordTemplate = _get(fieldValue, 'newRecordTemplate')
		this.removedElements = _get(fieldValue, 'removedElements', [])
	}

	/**
	 * A list of the elements that have been changed.
	 */
	get editedElements()
	{
		return this.elements.filter((row) => row.isDirty && !this.removedElements.includes(row.QPrimaryKey))
	}

	/**
	 * A list of the rows that aren't dirty.
	 */
	get emptyRows()
	{
		return this.newElements.filter((row) => !row.isDirty)
	}

	/**
	 * Whether the row is dirty.
	 */
	get isDirty()
	{
		return _some([
			_some(this.newElements, (el) => el.isDirty),
			_some(this.editedElements),
			_some(this.removedElements)
		])
	}

	/**
	 * The value in the format expected by the server-side.
	 */
	get serverValue()
	{
		// For existing rows, we only send those that are edited (dirty)
		// and are not marked to be deleted.
		const svrEditedElements = _flatMap(this.editedElements, (row) => row.serverObjModel)

		// For new rows, we must clear the client-side key.
		// Only those that are not empty (dirty) are sent.
		const svrNewElements = _flatMap(this.newElements.filter((row) => row.isDirty), (row) => {
			row.QPrimaryKey = null
			return row.serverObjModel
		})

		return {
			editedElements: svrEditedElements,
			newElements: svrNewElements,
			removedElements: this.removedElements
		}
	}

	/**
	 * Hydrates and returns a new view model.
	 * @param {object} viewModelData The view model data
	 * @param {object} viewModelClass The class for the grid view model
	 * @param {object} vueContext The Vue context in which this value will be used
	 * @returns A new view model of type viewModelClass.
	 */
	getViewModel(viewModelData, viewModelClass, vueContext)
	{
		if (viewModelData === undefined || viewModelClass === undefined || vueContext === undefined)
			return undefined

		const viewModel = new viewModelClass(vueContext)
		viewModel.hydrate(viewModelData)
		return viewModel
	}

	/**
	 * Adds a view model object to the list of new elements.
	 * @param {object} viewModelData The view model data
	 * @param {object} viewModelClass The class for the grid view model
	 * @param {object} vueContext The Vue context in which this value will be used
	 */
	addNewModel(viewModelData, viewModelClass, vueContext)
	{
		const viewModel = this.getViewModel(viewModelData, viewModelClass, vueContext)
		if (viewModel !== undefined)
			this.newElements.push(viewModel)
	}

	/**
	 * Removes empty rows from the list of new elements. Optionally retains one last empty row.
	 * @param {boolean} full A flag indicating whether to remove all empty rows or leave one remaining
	 */
	trimEmptyRows(full)
	{
		let pop = this.emptyRows.length
		if (!full)
			pop--

		while (pop--)
			this.newElements.pop()

		// Ensure the row left by the trim operation has no
		// server error messages from previous attempts to save the form
		_forEach(this.emptyRows, (row) => row.clearServerErrorMessages())
	}

	/**
	 * Marks the given view model as deleted or removes it from the list of new elements.
	 * @param {object} viewModelData The view model to be marked for deletion
	 */
	markForDeletion(viewModelData)
	{
		// Check if this is a new row
		// New rows are removed immediately
		// instead of being marked to be deleted
		const index = this.newElements.indexOf(viewModelData)

		if (index > -1)
			this.newElements.splice(index, 1)
		else
			this.removedElements.push(viewModelData.QPrimaryKey)
	}

	/**
	 * Reverts the deletion mark from the given view model, if it was previously marked.
	 * @param {object} viewModelData The view model to undo deletion
	 */
	undoDeletion(viewModelData)
	{
		const index = this.removedElements.indexOf(viewModelData.QPrimaryKey)

		if (index > -1)
			this.removedElements.splice(index, 1)
	}

	/**
	 * Sets the whole value of the grid table list including its elements, new elements, and removed elements.
	 * @param {object} newValue The new value object representing the grid state
	 * @param {object} viewModelClass The class for the grid view model
	 * @param {object} vueContext The Vue context in which this value will be used
	 */
	setValue(newValue, viewModelClass, vueContext)
	{
		if (viewModelClass === undefined || vueContext === undefined)
			return

		const elements = [],
			newElements = []

		_forEach(_get(newValue, 'elements', []), (viewModelData) => {
			const viewModel = this.getViewModel(viewModelData, viewModelClass, vueContext)
			if (viewModel !== undefined)
				elements.push(viewModel)
		})

		_forEach(_get(newValue, 'newElements', []), (viewModelData) => {
			const viewModel = this.getViewModel(viewModelData, viewModelClass, vueContext)
			if (viewModel !== undefined)
				newElements.push(viewModel)
		})

		// For cases where more than one process updates the value, we need to update all at the same time and not push to the central property.
		// Bug case: Initial load of form and restore of the last tab (SelectTab).
		this.elements.splice(0, Infinity, ...elements)
		this.newElements.splice(0, Infinity, ...newElements)
		this.removedElements.splice(0, Infinity, ..._get(newValue, 'removedElements', []))
		this.newRecordTemplate = _get(newValue, 'newRecordTemplate', this.newRecordTemplate)
	}

	/**
	 * Returns an object representing the current state of the grid, with elements, new elements, and removed elements.
	 * @returns {object} An object containing the current state of the grid.
	 */
	getCurrentState()
	{
		return {
			elements: this.elements.filter((row) => !this.removedElements.includes(row.QPrimaryKey)),
			removedElements: this.elements.filter((row) => this.removedElements.includes(row.QPrimaryKey)),
			newElements: this.newElements.filter((row) => row.isDirty)
		}
	}

	/**
	 * Returns an object representing the current state of the grid suitable for server communication.
	 * @param {boolean} removedElementsOnlyKey True to return only the key of removed elements (defaults to false)
	 * @param {boolean} elementsOnlyDirty True to return only the elements that are dirty (have been modified)
	 * @returns {object} An object containing the current state of the grid in a server-compatible format.
	 */
	getCurrentStateSrvObject(removedElementsOnlyKey = false, elementsOnlyDirty = false)
	{
		const currentState = this.getCurrentState()

		return {
			elements: _flatMap(elementsOnlyDirty ? currentState.elements.filter((row) => row.isDirty) : currentState.elements, (row) => row.serverObjModel),
			removedElements: _flatMap(currentState.removedElements, (row) => removedElementsOnlyKey ? row.QPrimaryKey : row.serverObjModel),
			newElements: _flatMap(currentState.newElements, (row) => row.serverObjModel)
		}
	}

	/**
	 * Set server error messages associated with the field.
	 * @param {object} errors The server errors
	 * @param {array} key The model field path
	 */
	setServerErrorMessages(errors, key)
	{
		const rowsListName = key.shift()
		const rowId = key.shift()

		if (rowsListName === 'editedElements' || rowsListName === 'removedElements')
		{
			const modelIndex = _findIndex(this.elements, (row) => row.QPrimaryKey === rowId)
			const rowModel = _get(this.elements, modelIndex)
			rowModel?.setServerErrorMessages(key, errors)
		}
		else if (rowsListName === 'newElements')
		{
			const rowModel = _get(this.newElements, rowId)
			rowModel?.setServerErrorMessages(key, errors)
		}
	}

	/**
	 * Clears server error messages for all elements and new elements.
	 */
	clearServerErrorMessages()
	{
		_forEach(this.elements, (el) => el.clearServerErrorMessages())
		_forEach(this.newElements, (el) => el.clearServerErrorMessages())
	}

	/**
	 * Set server warning messages associated with the field.
	 * @param {object} errors The server errors
	 * @param {array} key The model field path
	 */
	setServerWarningMessages(errors, key)
	{
		const rowsListName = key.shift()
		const rowId = key.shift()

		if (rowsListName === 'editedElements' || rowsListName === 'removedElements')
		{
			const modelIndex = _findIndex(this.elements, (row) => row.QPrimaryKey === rowId)
			const rowModel = _get(this.elements, modelIndex)
			rowModel?.setServerWarningMessages(key, errors)
		}
		else if (rowsListName === 'newElements')
		{
			const rowModel = _get(this.newElements, rowId)
			rowModel?.setServerWarningMessages(key, errors)
		}
	}

	/**
	 * Clears server warning messages for all elements and new elements.
	 */
	clearServerWarningMessages()
	{
		_forEach(this.elements, (el) => el.clearServerWarningMessages())
		_forEach(this.newElements, (el) => el.clearServerWarningMessages())
	}

	/**
	 * Deep clones the field's value.
	 */
	clone()
	{
		const clone = new GridTableListValue()

		this.elements.forEach((model) => clone.elements.push(model.clone()))
		this.newElements.forEach((model) => clone.newElements.push(model.clone()))

		clone.removedElements = _cloneDeep(this.removedElements)
		clone.newRecordTemplate = _cloneDeep(this.newRecordTemplate)

		return clone
	}
}

export class GridTableList extends Base
{
	constructor(options, vueContext)
	{
		super(_assignIn({
			type: 'GridTableList',
			_value: new GridTableListValue(),
			viewModelClass: undefined
		}, options))

		// Just to initialize the View Model of Row's (Resources + NavigationId for requests)
		this.vueContext = vueContext
	}

	/**
	 * @override
	 */
	get isDirty()
	{
		return this.value.isDirty
	}

	/**
	 * @override
	 */
	get serverValue()
	{
		return this.value.serverValue
	}

	/**
	 * The current elements in the grid.
	 */
	get elements()
	{
		return this.value.elements
	}

	/**
	 * The elements that have been added to the grid.
	 */
	get newElements()
	{
		return this.value.newElements
	}

	/**
	 * The elements that have been edited in the grid.
	 */
	get editedElements()
	{
		return this.value.editedElements
	}

	/**
	 * The elements that have been marked for removal.
	 */
	get removedElements()
	{
		return this.value.removedElements
	}

	/**
	 * The rows in the grid that are not dirty.
	 */
	get emptyRows()
	{
		return this.value.emptyRows
	}

	/**
	 * @override
	 */
	updateValue(newValue)
	{
		this.value.setValue(newValue, this.viewModelClass, this.vueContext)
	}

	/**
	 * @override
	 */
	clearServerErrorMessages()
	{
		this.value.clearServerErrorMessages()
	}

	/**
	 * @override
	 */
	clearServerWarningMessages()
	{
		this.value.clearServerWarningMessages()
	}

	/**
	 * @override
	 */
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

	/**
	 * @override
	 */
	isValidType(value)
	{
		return value instanceof GridTableListValue || value === null
	}

	/**
	 * Set server error messages associated with the model field.
	 * @param {object} errors The server errors
	 * @param {array} key The model field
	 */
	setServerErrorMessages(errors, key)
	{
		this.value.setServerErrorMessages(errors, key)
	}

	/**
	 * Set server warning messages associated with the model field.
	 * @param {object} warnings The server warnings
	 * @param {array} key The model field
	 */
	setServerWarningMessages(warnings, key)
	{
		this.value.setServerWarningMessages(warnings, key)
	}

	/**
	 * Update a single field's value for a specific model in the grid.
	 * @param {object} eventData Data describing the event that initiated the update
	 */
	setModelFieldValue(eventData)
	{
		const modelUId = _get(eventData, 'key'),
			fieldData = _get(eventData, 'value'),
			fieldName = _get(fieldData, 'modelField'),
			fieldValue = _get(fieldData, 'value')

		if (_isEmpty(modelUId) || _isEmpty(fieldName) || !_has(this, 'value.elements'))
			return

		let modelIndex = _findIndex(this.value.elements, (row) => row.uniqueIdentifier === modelUId)

		if (modelIndex !== -1)
			this.value.elements[modelIndex][fieldName].updateValue(fieldValue)
		else
		{
			modelIndex = _findIndex(this.value.newElements, (row) => row.uniqueIdentifier === modelUId)
			if (modelIndex !== -1)
				this.value.newElements[modelIndex][fieldName].updateValue(fieldValue)
		}
	}

	/**
	 * Adds a new model to the grid using the new record template.
	 */
	addNewModel()
	{
		const newModelData = _cloneDeep(this.value.newRecordTemplate)

		if (newModelData)
		{
			newModelData[this.viewModelClass.QPrimaryKeyName] = uuidv4()
			this.value.addNewModel(newModelData, this.viewModelClass, this.vueContext)
		}
	}

	/**
	 * Removes empty rows from the grid, optionally leaving one empty row if not full.
	 * @param {boolean} full A flag indicating whether to remove all empty rows or leave one remaining
	 */
	trimEmptyRows(full)
	{
		this.value.trimEmptyRows(full)
	}

	/**
	 * Marks the specified row for deletion in the grid.
	 * @param {object} row The row to be marked for deletion
	 */
	markForDeletion(row)
	{
		this.value.markForDeletion(row)
	}

	/**
	 * Undoes the deletion mark on the specified row, if it was previously marked.
	 * @param {object} row The row to remove from deletion
	 */
	undoDeletion(row)
	{
		this.value.undoDeletion(row)
	}
}

export class PropertyList extends Base
{
	static EMPTY_VALUE = {}

	constructor(options)
	{
		super(_assignIn({
			type: 'PropertyList',
			_value: {},
			pkField: '',
			propCol: '',
			valueCol: '',
			typeCol: ''
		}, options))
	}

	/**
	 * @override
	 */
	get serverValue()
	{
		return {
			fields: Object.values(this.value)
		}
	}

	/**
	 * @override
	 */
	get isDirty()
	{
		return Object.values(this.value).some((item) => item.isDirty)
	}

	/**
	 * @override
	 */
	updateValue(field)
	{
		if (field === null)
			return

		const fieldExists = this._value[field.id]
		// If the field is in the list, update it. Otherwise, add it.
		if (fieldExists)
			_assignIn(fieldExists, field)
		else
			this._value[field.id] = field
	}

	/**
	 * Function to parse and format input value into a suitable display format based on the provided field type
	 * @param {string} value Input value to be transformed
	 * @param {string} fieldType Field type that determines the type of transformation to be applied to the input value
	 * @returns {string|number} A transformed value that is suitable for display. This can be a string, number or any other type based on the field type
	 *
	 * @example
	 * parseToDisplayValue('2021-09-25', 'date') returns '2021-09-25T00:00:00.000Z'
	 * parseToDisplayValue('Hello World!', 'string') returns 'Hello World!'
	 */
	parseToDisplayValue(value, fieldType)
	{
		const fieldTypeHandler = {
			date: (value) => genericFunctions.dateToISOString(value),
			boolean: (value) => genericFunctions.booleanDisplay(value),
			string: (value) => genericFunctions.textDisplay(value),
			number: (value) => parseFloat(value),
			default: (value) => value.toString()
		}

		return (fieldTypeHandler[fieldType] || fieldTypeHandler['default'])(value)
	}

	/**
	 * @override
	 */
	hydrate(listControl, viewModel)
	{
		const properties = viewModel?.Elements

		if (!properties)
			return

		_forEach(properties, (property) => {
			const field = listControl.config.fields.find((f) => f.name === property[this.propCol])
			if (!field)
				return

			// Update the client-side data.
			const value = this.parseToDisplayValue(property[this.valueCol], property[this.typeCol])
			field.rowId = property[this.pkField]
			field.props.modelValue = value
			field.defaultValue = value
			field.isDirty = false

			const fieldData = {
				rowId: field.rowId ?? '',
				id: field.id,
				name: field.name,
				value: property[this.valueCol],
				type: field.type,
				isDirty: field.isDirty
			}

			this.updateValue(fieldData)
		})
	}
}

export default {
	Base,
	String,
	MultiLineString,
	Password,
	PrimaryKey,
	ForeignKey,
	Coordinate,
	Geographic,
	Date,
	DateTime,
	DateTimeSeconds,
	Time,
	Boolean,
	Number,
	Image,
	DocumentData, //FIXME: this should not be exported; Document should suffice
	Document,
	MultipleValues,
	GridTableList,
	PropertyList
}
