import { markRaw, readonly } from 'vue'
import { v4 as uuidv4 } from 'uuid'
import _forEach from 'lodash-es/forEach'
import _isEmpty from 'lodash-es/isEmpty'
import _isEqual from 'lodash-es/isEqual'
import _some from 'lodash-es/some'
import _has from 'lodash-es/has'
import _set from 'lodash-es/set'

import { QEventEmitter } from '@/api/global/eventBus.js'
import netAPI from '@/api/network'
import modelFieldType from '@/mixins/formModelFieldTypes.js'

import { useGenericDataStore } from '@/stores/genericData.js'

export default class FormViewModelBase
{
	constructor(vueContext, options)
	{
		// The Vue context properties
		Object.defineProperty(this, 'vueContext', {
			value: (vueContext || {}),
			enumerable: false
		})

		Object.defineProperty(this, 'Resources', {
			get() { return this.vueContext.Resources },
			enumerable: false
		})

		Object.defineProperty(this, 'navigationId', {
			get() { return this.vueContext.navigationId },
			enumerable: false,
			configurable: true
		})

		// Unique identifier
		Object.defineProperty(this, 'uniqueIdentifier', {
			value: uuidv4(),
			enumerable: false
		})

		// The view model metadata
		Object.defineProperty(this, 'modelInfo', {
			value: {
				name: undefined,
				area: undefined,
				actions: {
					recalculateFormulas: undefined,
					loadLookupContent: 'ReloadDBEdit',
					getLookupDependents: 'GetDependants'
				}
			},
			enumerable: false,
			configurable: true
		})

		// Internal events for the formulas
		Object.defineProperty(this, 'internalEvents', {
			value: markRaw(new QEventEmitter()),
			enumerable: false
		})

		// External callback for invocation of external methods such as onUpdate of fields
		Object.defineProperty(this, 'externalCallbacks', {
			value: markRaw({
				onUpdate: options?.callbacks?.onUpdate,
				setFormKey: options?.callbacks?.setFormKey
			}),
			enumerable: false
		})

		// The web api request counters - to accept only the last one's response and discard the others
		Object.defineProperty(this, 'recalculateFormulasRequestNumber', {
			value: 0,
			enumerable: false,
			writable: true
		})

		// An object with the IDs and values that triggered the last calls to recalculateFormulas()
		Object.defineProperty(this, 'lastRecalculatedValues', {
			value: markRaw({}),
			enumerable: false,
			writable: true
		})
	}

	/**
	 * Getter for the GLOB table (if it exists).
	 */
	get tGlob()
	{
		const genericData = useGenericDataStore()
		return genericData.tGlob
	}

	/**
	 * A list of the fields with unsaved changes.
	 */
	get dirtyFields()
	{
		let _dirtyFields = []

		for (let modelField in this)
		{
			const fieldObj = this[modelField]

			if (fieldObj instanceof modelFieldType.Base &&
				fieldObj.isDirty)
				_dirtyFields.push(fieldObj)
		}

		return _dirtyFields
	}

	/**
	 * A list with the area and name of unsaved changes ex: AREA.FIELD.
	 */
	get dirtyFieldNames()
	{
		return this.dirtyFields.map((obj) => `${obj.area}.${obj.field}`)
	}

	/**
	 * True if the View Model has fields with unsaved changes, false otherwise.
	 */
	get isDirty()
	{
		return _some(this, (modelField) => modelField instanceof modelFieldType.Base && modelField.isDirty)
	}

	/**
	 * The values of the vue model in the format expected by the view model of the server.
	 */
	get serverObjModel()
	{
		const viewModel = {}

		for (let modelField in this)
		{
			const fieldObj = this[modelField]

			if (fieldObj instanceof modelFieldType.Base &&
				fieldObj.type !== 'Lookup' &&
				fieldObj.ignoreFldSubmit !== true)
			{
				const value = fieldObj.serverValue
				viewModel[modelField] = value
			}
		}

		return readonly(viewModel)
	}

	/**
	 * Checks if this model is equal to the specified one.
	 * @param {object} otherModel The other model
	 * @returns True if the models are equal, false otherwise.
	 */
	equals(otherModel)
	{
		if (!(otherModel instanceof FormViewModelBase))
			return false

		for (let modelField in this)
		{
			const fieldObj = this[modelField]

			if (!(fieldObj instanceof modelFieldType.Base) ||
				!fieldObj.hasSameValue(otherModel[modelField]?.value))
				return false
		}

		return true
	}

	/**
	 * Creates a clone of the current instance.
	 */
	clone()
	{
		throw new Error('This method should be implemented in a sub-class.')
	}

	/**
	 * Hydrates the raw data coming from the server with the necessary metadata.
	 * @param {object} rawData The data to be hydrated
	 */
	hydrate(rawData)
	{
		for (let modelField in this)
			if (this[modelField] instanceof modelFieldType.Base)
				this.hydrateField(modelField, rawData)

		// GLOB table
		if (Reflect.has(rawData, 'TGlob'))
		{
			const genericData = useGenericDataStore()
			genericData.setGlobData(rawData.TGlob)
		}
	}

	/**
	 * Hydrates the raw data for a given field coming from the server
	 * with the necessary metadata.
	 * @param {object} modelField The target field
	 * @param {object} rawData The data to be hydrated
	 */
	hydrateField(modelField, rawData)
	{
		const fieldObj = this[modelField]

		if (!(fieldObj instanceof modelFieldType.Base) || fieldObj.isReady || !_has(rawData, modelField))
			return

		let rawDataFieldValue = rawData[modelField]

		if (typeof fieldObj.hydrate === 'function')
			fieldObj.hydrate(rawDataFieldValue)
	}

	/**
	 * Recalculates the server side formulas.
	 * @param {object} triggerFields An object with the fields that triggered the call
	 * @returns A promise with the response from the server.
	 */
	recalculateFormulas(triggerFields = {})
	{
		if (_isEmpty(this.modelInfo.area) || _isEmpty(this.modelInfo.actions.recalculateFormulas))
			return

		// Check if there was any change since the last call to recalculateFormulas().
		// If 'triggerFields' is empty, runs the recalculation anyway.
		if (Object.keys(triggerFields).length > 0)
		{
			let hasChanged = false

			for (let i in triggerFields)
			{
				const fieldValue = triggerFields[i]

				if (!_isEqual(this.lastRecalculatedValues[i], fieldValue))
				{
					this.lastRecalculatedValues[i] = fieldValue
					hasChanged = true
				}
			}

			// If no changes were detected, doesn't do anything.
			if (!hasChanged)
				return
		}

		const model = this.serverObjModel

		return netAPI.postData(this.modelInfo.area, this.modelInfo.actions.recalculateFormulas, model, (data, request) => {
			const requestNumber = request.headers.recalculateformulasrequestnumber
			if (Number(requestNumber) !== this.recalculateFormulasRequestNumber)
				return

			if (request.data.Success)
			{
				if (typeof data !== 'object')
					return

				for (let modelField in this)
				{
					const fieldObj = this[modelField]

					if (_isEmpty(fieldObj.area) || _isEmpty(fieldObj.field))
						continue

					if (fieldObj instanceof modelFieldType.Base)
					{
						const fieldArea = fieldObj.area.toLowerCase()
						const fieldName = fieldObj.field.toLowerCase()
						const fieldFullName = `${fieldArea}.${fieldName}`
						const fieldValue = data[fieldFullName]

						if (typeof fieldValue !== 'undefined')
							fieldObj.updateValue(fieldValue)
					}
				}
			}
		}, null, {
			headers: {
				RecalculateFormulasRequestNumber: ++this.recalculateFormulasRequestNumber
			}
		}, this.navigationId)
	}

	emitInternalEvent(eventName, eventData)
	{
		this.internalEvents.emit(eventName, eventData)
	}

	/**
	 * Initialization of field value formula events
	 */
	initFieldsValueFormula()
	{
		_forEach(this, (modelField) => {
			// Field value formulas
			if (modelField.valueFormula)
			{
				if (typeof modelField.valueFormula.runFormula !== 'function')
				{
					modelField.valueFormula.runFormula = (originFieldData) => {
						if (modelField.valueFormula.stopRecalcCondition())
							return

						let execCondition = modelField.valueFormula.execCondition
						if (typeof execCondition === 'function' && !execCondition.call(this))
							return

						const params = {
							originField: originFieldData?.modelField,
							currentField: modelField
						}

						if (modelField.valueFormula.isServerFormula)
						{
							Promise.resolve(modelField.valueFormula.fnFormula.call(this, params)).then((responseData) => {
								if (responseData && responseData.Success)
									modelField.value = responseData.Result
							})
						}
						else
						{
							let formulaValue = modelField.valueFormula.fnFormula.call(this, params)
							// If it's a server-side recalculation, it's value will be set when the recalculateFormulas() function is called.
							if (!modelField.valueFormula.isServerRecalc)
								Promise.resolve(formulaValue).then((value) => (modelField.value = value))
						}
					}
				}

				this.internalEvents.offMany([...modelField.valueFormula.dependencyEvents, 'CALC_FIELDS_FORMULAS'], modelField.valueFormula.runFormula)
				this.internalEvents.onMany([...modelField.valueFormula.dependencyEvents, 'CALC_FIELDS_FORMULAS'], modelField.valueFormula.runFormula)
			}

			// Fill when formula
			if (modelField.fillWhen)
			{
				if (typeof modelField.fillWhen.runFormula !== 'function')
				{
					modelField.fillWhen.runFormula = () => {
						Promise.resolve(modelField.fillWhen.fnFormula.call(this)).then((value) => {
							if (!value)
								modelField.clearValue()
						})
					}
				}

				this.internalEvents.offMany([...modelField.fillWhen.dependencyEvents, 'CALC_FILL_WHEN_FORMULAS'], modelField.fillWhen.runFormula)
				this.internalEvents.onMany([...modelField.fillWhen.dependencyEvents, 'CALC_FILL_WHEN_FORMULAS'], modelField.fillWhen.runFormula)
			}
		})
	}

	onUpdate(modelFieldName, modelField, newValue, oldValue)
	{
		// Foreign keys will also enter here, since it's a sub-class of primary key.
		if (modelField instanceof modelFieldType.PrimaryKey)
		{
			if (typeof this.externalCallbacks.setFormKey === 'function')
				this.externalCallbacks.setFormKey(modelField)

			// Don't emit event when key value is changed between empty string and null.
			if (!_isEmpty(newValue) || !_isEmpty(oldValue))
				this.emitInternalEvent(`fieldChange:${modelFieldName}`, { modelFieldName, modelField, newValue, oldValue })
		}
		else
			this.emitInternalEvent(`fieldChange:${modelFieldName}`, { modelFieldName, modelField, newValue, oldValue })

		if (typeof this.externalCallbacks.onUpdate === 'function')
			this.externalCallbacks.onUpdate(modelFieldName, modelField, newValue, oldValue)
	}

	setExternalCallback(callbacks)
	{
		_forEach(callbacks, (fn, cbName) => Reflect.set(this.externalCallbacks, cbName, fn))
		return this
	}

	setNavigationId(propertyRef)
	{
		Object.defineProperty(this, 'navigationId', {
			get() { return propertyRef },
			enumerable: false,
			configurable: true
		})

		return this
	}

	calcFieldsFormulas()
	{
		this.emitInternalEvent('CALC_FIELDS_FORMULAS')
	}

	calcShowWhenFormulas()
	{
		this.emitInternalEvent('CALC_SHOW_WHEN_FORMULAS')
	}

	calcBlockWhenFormulas()
	{
		this.emitInternalEvent('CALC_BLOCK_WHEN_FORMULAS')
	}

	calcFillWhenFormulas()
	{
		this.emitInternalEvent('CALC_FILL_WHEN_FORMULAS')
	}

	validateModel()
	{
		let modelValidations = {}

		_forEach(this, (modelField, modelFieldName) => {
			if (modelField instanceof modelFieldType.Base)
			{
				_set(modelValidations, modelFieldName, {
					fieldName: modelFieldName,
					// If the field is required, ensures it's filled.
					value: modelField.validateValue(),
					// If the field has a maximum number of characters, ensures it hasn't been exceeded.
					size: modelField.validateSize()
				})
			}
		})

		return modelValidations
	}

	get isValid()
	{
		return !_some(this.validateModel(), (fldValidation) => !fldValidation.value || !fldValidation.size)
	}

	hasServerErrorMessages()
	{
		for (let modelField in this)
			if (this[modelField].hasServerErrorMessages())
				return true
		return false
	}

	clearServerErrorMessages()
	{
		for (let modelField in this)
			this[modelField].clearServerErrorMessages()
	}

	/**
	 * Unbinding of all related events
	 */
	unbindEvents()
	{
		this.internalEvents.removeAllListeners()
	}

	/**
	 * Destroy current model object
	 */
	destroy()
	{
		this.unbindEvents()
	}
}
