import { computed, isRef, ref, watch, watchEffect, nextTick } from 'vue'
import { v4 as uuidv4 } from 'uuid'
import _assignIn from 'lodash-es/assignIn'
import _assignInWith from 'lodash-es/assignInWith'
import _capitalize from 'lodash-es/capitalize'
import _debounce from 'lodash-es/debounce'
import _forEach from 'lodash-es/forEach'
import _get from 'lodash-es/get'
import _has from 'lodash-es/has'
import _isEmpty from 'lodash-es/isEmpty'
import _isEqual from 'lodash-es/isEqual'
import _isUndefined from 'lodash-es/isUndefined'
import _merge from 'lodash-es/merge'
import _mergeWith from 'lodash-es/mergeWith'
import _some from 'lodash-es/some'
import _toLower from 'lodash-es/toLower'
import _unionWith from 'lodash-es/unionWith'

import netAPI from '@/api/network'
import searchFilterData from '@/api/genio/searchFilterData.js'
import asyncProcM from '@/api/global/asyncProcMonitoring.js'
import eventBus from '@/api/global/eventBus.js'
import hardcodedTexts from '@/hardcodedTexts.js'

import getSpecialRenderingControls from './customControl.js'
import controlsResources from './controlsResources.js'
import formFunctions from './formFunctions.js'
import genericFunctions from './genericFunctions.js'
import listFunctions from './listFunctions.js'
import qEnums from './quidgest.mainEnums.js'

/**
 * Base form control
 */
export class BaseControl
{
	/**
	 * Base constructor
	 * @param {object} options
	 * @param {Proxy} vueContext
	 */
	constructor(options, vueContext)
	{
		this.vueContext = vueContext
		Object.defineProperty(this, 'vueContext', { enumerable: false })

		// Init default values of control properties
		/** The id of the control */
		this.id = ''
		/** The type of the control class */
		this.type = 'Base'
		/** The model field Id */
		this.modelField = ''
		/** «Reference» to Proxy object of model field */
		this.modelFieldRef = null
		/** The field table - copied from modelFieldRef */
		this.dbArea = ''
		/** The field name - copied from modelFieldRef */
		this.dbField = ''
		/** String or function that return Label text for this control */
		this.label = ''
		/** The <label> div Id. Used for accessibility */
		this.labelId = ''
		/** Indicates if the field has a label */
		this.hasLabel = true
		/** Indicates the parent Zone Id */
		this.container = ''
		/** Indicates the parent Tab Id */
		this.tab = ''
		/** List of sources that hide the control */
		this.showWhenConditions = []
		/** List of sources that block the control */
		this.blockWhenConditions = []
		/** List of sources that make the control required */
		this.fieldRequiredConditions = []
		/** Whether or not the field is marked as mandatory */
		this.mustBeFilled = false
		/** Computed field that returns the result of the evaluation of the showWhenConditions to indicate if the control is visible */
		this.isVisible = false
		/** Indicates if the field is blocked (cannot be modified) */
		this.isBlocked = true
		/** Indicates if the field is readonly (cannot be modified) */
		this.readonly = true
		/** Indicates if the field is disabled (cannot be modified nor receive focus) */
		this.disabled = false
		/** Computed field that returns the result of the evaluation of the blockWhenConditions to indicate if the control has a formula that needs to be blocked */
		this.isFormulaBlocked = false
		/** Computed field that returns the result of the evaluation of the fieldRequiredConditions to indicate if the control is required */
		this.isRequired = false
		/** Hidden when it is not editable form */
		this.hiddenInNonEditableMode = false
		/** List of limits that condition the presented value */
		this.tableLimits = []
		/** Indicates if the field is permanently readonly, regardless of form mode */
		this.isFixed = false
		/** Whether or not some popup triggered by this control is visible */
		this.popupIsVisible = false
		/** Event handlers */
		this.handlers = {}
		/** The control label attributes */
		this.labelAttrs = { class: 'i-text__label' }
		this.dFlexInline = false
		/** The field allows adding suggestion */
		this.hasSuggestions = true
		/** The model field info (for Base input structure) */
		this.modelInfo = null
		/** The control size class */
		this.size = undefined
		/** Init async monitor for loading animation */
		this.componentOnLoadProc = asyncProcM.getProcListMonitor(`${options.id || uuidv4()}`, true)
		/** Whether the control is already loaded */
		this.loaded = computed(() => this.componentOnLoadProc.loaded)

		_merge(this, options || {})
	}

	get props()
	{
		return {
			id: this.id,
			size: this.size,
			readonly: this.readonly,
			loading: !this.loaded,
			required: this.isRequired
		}
	}

	/**
	 * Runs the specified field formula.
	 * @param {object} formula The formula
	 * @param {function} callback The callback formula
	 */
	validateFieldFormula(formula, callback, params)
	{
		if (_isEmpty(formula))
			return

		if (formula.isServerFormula)
		{
			formula.fnFormula.call(this.vueContext.model, params).then((data) => {
				if (data?.Success)
					callback(data.Result, params)
			})
		}
		else
		{
			let formulaValue = formula.fnFormula.call(this.vueContext.model, params)
			Promise.resolve(formulaValue).then((value) => callback(value, params))
		}
	}

	/**
	 * Adds a value to the field's specified stack of sources
	 * @param {string} sourceId The id of the source
	 * @param {array} sourceList The list of sources
	 * @param {function} checkFunction The function to check if the success event should be emitted
	 * @param {string} successEvent The event to emit in case there are now sources on the list
	 */
	addSource(sourceId, sourceList, checkFunction, successEvent)
	{
		if (_isEmpty(sourceId) || !Array.isArray(sourceList) || typeof checkFunction !== 'function')
			return

		const previousLength = sourceList.length
		const index = sourceList.indexOf(sourceId)

		if (index === -1)
			sourceList.push(sourceId)

		// Emit a success event in case the source list is no longer empty.
		if (!_isEmpty(successEvent) && this.vueContext.internalEvents && previousLength === 0 && !checkFunction())
			this.vueContext.internalEvents.emit(successEvent, this.id)
	}

	/**
	 * Removes a value from the field's specified stack of sources
	 * @param {string} sourceId The id of the source
	 * @param {array} sourceList The list of sources
	 * @param {function} checkFunction The function to check if the success event should be emitted
	 * @param {string} successEvent The event to emit in case there are no more sources on the list
	 */
	removeSource(sourceId, sourceList, checkFunction, successEvent)
	{
		if (_isEmpty(sourceId) || !Array.isArray(sourceList) || typeof checkFunction !== 'function')
			return

		const previousLength = sourceList.length
		const index = sourceList.indexOf(sourceId)

		if (index > -1)
			sourceList.splice(index, 1)

		// Emit a success event in case the source list is empty.
		if (!_isEmpty(successEvent) && this.vueContext.internalEvents && previousLength > 0 && checkFunction())
			this.vueContext.internalEvents.emit(successEvent, this.id)
	}

	/**
	 * Adds a value to the stack of the specified field's hiding sources.
	 * @param {string} sourceId The id of the hiding source
	 */
	addHideSource(sourceId)
	{
		this.addSource(sourceId, this.showWhenConditions, () => this.checkFieldIsVisible(), 'field-hidden')
	}

	/**
	 * Removes a value from the stack of the specified field's hiding sources.
	 * @param {string} sourceId The id of the hiding source
	 */
	removeHideSource(sourceId)
	{
		this.removeSource(sourceId, this.showWhenConditions, () => this.checkFieldIsVisible(), 'field-shown')
	}

	/**
	 * Runs the Show When formula.
	 * @param {object} showWhenProps The properties of the "show when" formula
	 * @param {string} source The source of the formula (could be "FORM" or "TABLE")
	 */
	validateFieldShowWhen(showWhenProps, source = '')
	{
		if (_isEmpty(showWhenProps))
			return

		const callback = (result) => {
			if (result)
				this.removeHideSource('FORMULA_SHOW_WHEN' + source)
			else
				this.addHideSource('FORMULA_SHOW_WHEN' + source)
		}

		this.validateFieldFormula(showWhenProps, callback)
	}

	/**
	 * Checks if the specified field is currently visible.
	 * @returns True if the field is visible, false otherwise
	 */
	checkFieldIsVisible()
	{
		return this.showWhenConditions.length === 0
	}

	/**
	 * Adds a value to the stack of the specified field's blocking sources.
	 * @param {string} sourceId The id of the blocking source
	 */
	addBlockSource(sourceId)
	{
		this.addSource(sourceId, this.blockWhenConditions, () => this.checkFieldIsBlocked(), 'field-blocked')
	}

	/**
	 * Removes a value from the stack of the specified field's blocking sources.
	 * @param {string} sourceId The id of the blocking source
	 */
	removeBlockSource(sourceId)
	{
		this.removeSource(sourceId, this.blockWhenConditions, () => this.checkFieldIsBlocked(), 'field-unblocked')
	}

	/**
	 * Runs the Block When formula.
	 * @param {object} blockWhenProps The properties of the "block when" formula
	 * @param {string} source The source of the formula (could be "FORM" or "TABLE")
	 */
	validateFieldBlockWhen(blockWhenProps, source = '')
	{
		if (_isEmpty(blockWhenProps))
			return

		const callback = (result) => {
			if (result)
				this.addBlockSource('FORMULA_BLOCK_WHEN' + source)
			else
				this.removeBlockSource('FORMULA_BLOCK_WHEN' + source)
		}

		this.validateFieldFormula(blockWhenProps, callback)
	}

	/**
	 * Checks if the specified field is currently blocked.
	 * @returns True if the field is blocked, false otherwise
	 */
	checkFieldIsBlocked()
	{
		return this.blockWhenConditions.length > 0 || this.isFixed || this.isFormulaBlocked
	}

	/**
	 * Adds a value to the stack of the specified field's required sources.
	 * @param {string} sourceId The id of the required source
	 */
	addRequiredSource(sourceId)
	{
		this.addSource(sourceId, this.fieldRequiredConditions, () => this.checkFieldIsRequired(), 'field-required')
	}

	/**
	 * Removes a value from the stack of the specified field's required sources.
	 * @param {string} sourceId The id of the required source
	 */
	removeRequiredSource(sourceId)
	{
		this.removeSource(sourceId, this.fieldRequiredConditions, () => this.checkFieldIsRequired(), 'field-not-required')
	}

	/**
	 * Runs the Required conditions formula.
	 */
	validateFieldRequiredConditions()
	{
		if (_isEmpty(this.requiredConditions))
			return

		const callback = (result) => {
			if (result)
				this.addRequiredSource('FORMULA_REQUIRED')
			else
				this.removeRequiredSource('FORMULA_REQUIRED')
		}

		this.validateFieldFormula(this.requiredConditions, callback)
	}

	/**
	 * Checks if the specified field is currently a required field.
	 * @returns True if the field is required, false otherwise
	 */
	checkFieldIsRequired()
	{
		return this.fieldRequiredConditions.length > 0 || this.mustBeFilled
	}

	/**
	 * Runs the Fill When formula.
	 */
	validateFieldFillWhen()
	{
		if (_isEmpty(this.modelFieldRef))
			return

		const callback = (result) => {
			if (result)
				this.removeBlockSource('FORMULA_FILL_WHEN')
			else
				this.addBlockSource('FORMULA_FILL_WHEN')
		}

		this.validateFieldFormula(this.modelFieldRef.fillWhen, callback)
	}

	/**
	 * Initialization of formulas that belong only to the control (interface part).
	 */
	initControlFormulas()
	{
		this.initFormulas(this.modelFieldRef)
	}

	/**
	 * Internal implementation of the initialization of formulas
	 * that belong only to the control (interface part).
	 * @param {object} modelFieldRef «Reference» to Proxy object of model field
	 */
	initFormulas(modelFieldRef)
	{
		// Show when formula of the form
		if (!_isEmpty(this.showWhen))
		{
			if (typeof this.showWhen.runFormula !== 'function')
			{
				this.showWhen.runFormula = () => this.validateFieldShowWhen(this.showWhen, 'FORM')
				this.showWhen.runFormula()
			}

			const events = _unionWith(this.showWhen.dependencyEvents, ['CALC_SHOW_WHEN_FORMULAS'])
			this.vueContext.internalEvents.offMany(events, this.showWhen.runFormula)
			this.vueContext.internalEvents.onMany(events, this.showWhen.runFormula)
		}

		// Block when formula of the form
		if (!_isEmpty(this.blockWhen))
		{
			if (typeof this.blockWhen.runFormula !== 'function')
			{
				this.blockWhen.runFormula = () => this.validateFieldBlockWhen(this.blockWhen, 'FORM')
				this.blockWhen.runFormula()
			}

			const events = _unionWith(this.blockWhen.dependencyEvents, ['CALC_BLOCK_WHEN_FORMULAS'])
			this.vueContext.internalEvents.offMany(events, this.blockWhen.runFormula)
			this.vueContext.internalEvents.onMany(events, this.blockWhen.runFormula)
		}

		// Required conditions
		if (!_isEmpty(this.requiredConditions))
		{
			if (typeof this.requiredConditions.runFormula !== 'function')
			{
				this.requiredConditions.runFormula = () => this.validateFieldRequiredConditions()
				this.requiredConditions.runFormula()
			}

			const events = _unionWith(this.requiredConditions.dependencyEvents, ['CALC_REQUIRED_FORMULAS'])
			this.vueContext.internalEvents.offMany(events, this.requiredConditions.runFormula)
			this.vueContext.internalEvents.onMany(events, this.requiredConditions.runFormula)
		}

		if (!_isEmpty(modelFieldRef))
		{
			// Fill when formula to block the control
			if (!_isEmpty(modelFieldRef.fillWhen))
			{
				if (typeof modelFieldRef.fillWhen.runFormula !== 'function')
				{
					modelFieldRef.fillWhen.runFormula = () => this.validateFieldFillWhen()
					modelFieldRef.fillWhen.runFormula()
				}

				const events = _unionWith(modelFieldRef.fillWhen.dependencyEvents, ['CALC_FILL_WHEN_FORMULAS'])
				this.vueContext.internalEvents.offMany(events, modelFieldRef.fillWhen.runFormula)
				this.vueContext.internalEvents.onMany(events, modelFieldRef.fillWhen.runFormula)
			}

			// Show when formula of the table
			if (!_isEmpty(modelFieldRef.showWhen))
			{
				if (typeof modelFieldRef.showWhen.runFormula !== 'function')
				{
					modelFieldRef.showWhen.runFormula = () => this.validateFieldShowWhen(modelFieldRef.showWhen, 'TABLE')
					modelFieldRef.showWhen.runFormula()
				}

				const events = _unionWith(modelFieldRef.showWhen.dependencyEvents, ['CALC_SHOW_WHEN_FORMULAS'])
				this.vueContext.internalEvents.offMany(events, modelFieldRef.showWhen.runFormula)
				this.vueContext.internalEvents.onMany(events, modelFieldRef.showWhen.runFormula)
			}

			// Block when formula of the table
			if (!_isEmpty(modelFieldRef.blockWhen))
			{
				if (typeof modelFieldRef.blockWhen.runFormula !== 'function')
				{
					modelFieldRef.blockWhen.runFormula = () => this.validateFieldBlockWhen(modelFieldRef.blockWhen, 'TABLE')
					modelFieldRef.blockWhen.runFormula()
				}

				const events = _unionWith(modelFieldRef.blockWhen.dependencyEvents, ['CALC_BLOCK_WHEN_FORMULAS'])
				this.vueContext.internalEvents.offMany(events, modelFieldRef.blockWhen.runFormula)
				this.vueContext.internalEvents.onMany(events, modelFieldRef.blockWhen.runFormula)
			}
		}
	}

	/**
	 * Defines if the form is in editable mode.
	 * In addition to being locked/unlocked, some controls may be invisible in non-editable modes.
	 * @param {Boolean} isEditableForm
	 */
	setFormModeBlockAndVisibility(isEditableForm)
	{
		if (typeof isEditableForm === 'boolean' && !isEditableForm)
		{
			this.addBlockSource('NOT_EDITABLE_FORM')
			if (this.hiddenInNonEditableMode === true)
				this.addHideSource('NOT_EDITABLE_FORM')
		}
		else
		{
			this.removeBlockSource('NOT_EDITABLE_FORM')
			this.removeHideSource('NOT_EDITABLE_FORM')
		}
	}

	/**
	 * Initializes the event handlers.
	 */
	initHandlers()
	{
		const handlers = {
			showSuggestionPopup: (...args) => eventBus.emit('show-suggestion-popup', ...args)
		}

		_assignInWith(this.handlers, handlers, (objValue, srcValue) =>
			_isUndefined(objValue) ? srcValue : objValue
		)
	}

	/**
	 * Initializes the necessary properties.
	 * @param {boolean} isEditableForm Whether or not the control is editable
	 */
	Init(isEditableForm)
	{
		this.setFormModeBlockAndVisibility(isEditableForm)

		// Set reference to the model field
		if (!_isEmpty(this.modelField) && this.vueContext.model)
		{
			if (_has(this.vueContext.model, this.modelField))
			{
				this.modelFieldRef = _get(this.vueContext.model, this.modelField)

				this.dbArea = _toLower(this.modelFieldRef.area)
				this.dbField = _toLower(this.modelFieldRef.field)
				this.modelInfo = {
					tableId: this.modelFieldRef.area,
					fieldId: this.modelFieldRef.field
				}
			}
		}

		this.initControlFormulas()
		this.initHandlers()

		// Computed variables should only be initialized after the component's data initialization (when the object becomes reactive)
		this.isVisible = computed(() => this.checkFieldIsVisible())
		this.isBlocked = computed(() => this.checkFieldIsBlocked())
		this.isRequired = computed(() => this.checkFieldIsRequired())

		// Initial step towards separating these concepts
		this.readonly = computed(() => this.isBlocked)
	}

	/**
	 * Gets the values of the control limits (with identifiers that are used in lists and lookups).
	 * @returns Returns the values of the control limits (if any)
	 */
	getLimitsValues()
	{
		var limitsValues = {},
			model = this.vueContext.model

		/** Dynamic limits (value getter + identifier). Used in requests for the new rows list */
		if (!_isEmpty(model) && !_isEmpty(this.controlLimits))
		{
			_forEach(this.controlLimits, (limitInfo) => {
				let limitValue = limitInfo.fnValueSelector(model)
				if (Array.isArray(limitInfo.identifier))
				{
					_forEach(limitInfo.identifier, (limitIdentifier) => {
						Reflect.set(limitsValues, limitIdentifier, limitValue)
					})
				}
				else
					Reflect.set(limitsValues, limitInfo.identifier, limitValue)
			})
		}

		/**
		 * Limits with fixed value (value + identifier).
		 * Used, for example, in See More lists, to apply dynamic values received from the form (for example, 'Field' type limit).
		 */
		if (!_isEmpty(this.fixedControlLimits))
		{
			_forEach(this.fixedControlLimits, (limitValue, limitIdentifier) => {
				Reflect.set(limitsValues, limitIdentifier, limitValue)
			})
		}

		return limitsValues
	}

	/**
	 * Sets a modal with the specified data.
	 * @param {string|object} modalData The data of the modal (structure: { id: String, props: Object })
	 */
	SetModal(modalData)
	{
		if (_isEmpty(modalData))
			return

		var properties = {}

		if (typeof modalData === 'object')
		{
			if (_isEmpty(modalData.id))
				return
			if (!_isEmpty(modalData.props))
				properties = modalData.props

			properties.id = modalData.id
		}
		else if (typeof modalData === 'string')
			properties.id = modalData
		else
			return

		const modalProps = {
			isActive: true,
			closeButtonEnable: true,
			...properties,
			dismissAction: () => {
				if (typeof properties.dismissAction === 'function')
					properties.dismissAction()
				this.popupIsVisible = false
			}
		}

		this.vueContext.setModal(modalProps)
		nextTick().then(() => this.popupIsVisible = true)
	}

	/**
	 * Removes from the DOM the modal with the specified id.
	 * @param {string} modalId The id of the modal
	 */
	RemoveModal(modalId)
	{
		genericFunctions.removeModal(modalId)
		this.popupIsVisible = false
	}

	/**
	 * Reloads the data of the control
	 */
	async Reload()
	{
		return this.vueContext.fetchFormField(this.modelField)
	}

	/**
	 * Adds the async process to the watch list of that control's parent context.
	 * Controls in the certain conditions will cause the «Loading ...» effect to appear
	 * @param {Promise} cbPromise The «Promise» object of the proces
	 * @param {String} busyStateMessage The page busy state message
	 * @returns Promise or nothing
	 */
	addLoadingProcToParent(cbPromise, busyStateMessage)
	{
		if (this.vueContext && this.vueContext.componentOnLoadProc)
			return this.vueContext.componentOnLoadProc.AddBusy(cbPromise, busyStateMessage)
	}

	/**
	 * Adds a new handler for the specified event.
	 * @param {string} id The id of the event
	 * @param {function} behavior The behavior of the handler
	 * @param {boolean} rewrite Whether or not the previous behavior should be rewritten (defaults to false)
	 */
	addHandler(id, behavior, rewrite = false)
	{
		if (typeof id !== 'string' || typeof behavior !== 'function')
			return
		if (typeof this.handlers !== 'object')
			this.handlers = {}

		const prevHandler = this.handlers[id]
		var behaviorFunc = behavior

		if (!rewrite && typeof prevHandler === 'function')
		{
			behaviorFunc = (...args) => {
				prevHandler(...args)
				behavior(...args)
			}
		}

		this.handlers[id] = behaviorFunc
	}

	/**
	 * The control destroy to be invoked on the unmount.
	 */
	destroy()
	{
		this.componentOnLoadProc.destroy()
	}
}

/**
 * Represents a control type that shouldn't be blocked just because the form is in "SHOW" mode.
 */
class NonBlockableControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		super({}, _vueContext)

		_merge(this, options || {})
	}

	/**
	 * Defines if the form is in editable mode
	 */
	setFormModeBlockAndVisibility()
	{
		super.setFormModeBlockAndVisibility(true)
	}
}

/**
 * Form string control
 */
export class StringControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'String',
		}, _vueContext)

		_merge(this, options || {})
	}

	get props()
	{
		return {
			...super.props,
			placeholder: this.placeholder,
			maxLength: this.maxLength
		}
	}
}

/**
 * Form text editor control
 */
export class TextEditorControl extends StringControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'TextEditor'
		}, _vueContext)

		_merge(this, options || {})
	}

	/**
	 * Initializes the necessary properties.
	 * @param {boolean} isEditableForm Whether or not the control is editable
	 */
	Init(isEditableForm)
	{
		super.Init(isEditableForm)
		this.initHandlers()
	}

	initHandlers()
	{
		const handlers = {
			ctrlInitialized: () => this.onCtrlInitializedEvent()
		}

		// Apply handlers without overriding. The handler can come from outside at initialization.
		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	destroy()
	{
		super.destroy()

		/**
		 * For some reason before unmount is not executed on the component.
		 * It will be the control's JS that will destroy the initialized plugin.
		 */
		if (window.tinymce)
		{
			let editorCtrl = window.tinymce.get(this.id)
			if (editorCtrl)
			{
				editorCtrl.remove()
				editorCtrl.destroy(true)
				window.tinymce.remove(this.id)
			}
		}
	}

	onCtrlInitializedEvent() { if (this.vueContext.internalEvents) this.vueContext.internalEvents.emit('ctrl-initialized', { id: this.id }) }
}

/**
 * Password control
 */
export class PasswordControl extends StringControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Password',
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * Form boolean control
 */
export class BooleanControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Boolean',
			labelAttrs: { class: 'i-checkbox i-checkbox__label' }
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * Form numeric control
 */
export class NumberControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Number',
			thousandsSep: ' ',
			decimalSep: ',',
			maxDigits: 0,
			decimalDigits: 0,
			isDecimal: true, /* <= decimalDigits > 0 */
			isSequencial: false,
			showEmptyMessage: false,
			texts: new controlsResources.NumberInputResources(_vueContext.$getResource)
		}, _vueContext)

		_merge(this, options || {})
	}

	Init(isEditableForm)
	{
		super.Init(isEditableForm)

		if (this.modelFieldRef)
		{
			this.maxDigits = computed(() => this.modelFieldRef.maxDigits)
			this.decimalDigits = computed(() => this.modelFieldRef.decimalDigits)
			this.showEmptyMessage = computed(() => this.isSequencial && (_isEmpty(this.modelFieldRef) || this.modelFieldRef.value < 0))
		}
	}
}

/**
 * Form currency control
 */
export class CurrencyControl extends NumberControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Number',
			dFlexInline: true,
			isCurrency: true,
			currencySymbol: computed(() => _vueContext.system?.baseCurrency?.symbol || '€')
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * Form date control
 */
export class DateControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Date',
			dFlexInline: true,
			locale: 'en-US',
			dateFormat: {
				Date: 'dd/MM/yyyy',
				DateTime: 'dd/MM/yyyy HH:mm',
				DateTimeSeconds: 'dd/MM/yyyy HH:mm:ss',
				Time: 'HH:mm'
			}
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * Form time control
 */
export class TimeControl extends DateControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Time'
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * The base class for the Array controls
 */
class BaseArrayControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		super({
			items: [],
			groups: [],
			arrayOptions: [],
			arrayElShowWhen: null
		}, _vueContext)

		_merge(this, options || {})
	}

	get props()
	{
		return {
			...super.props,
			items: this.items,
			groups: this.groups,
			clearable: this.clearable,
			emptyValue: this.emptyValue,
			texts: this.texts
		}
	}

	/**
	 * Initializes the necessary properties.
	 * @param {boolean} isEditableForm Whether or not the control is editable
	 */
	Init(isEditableForm)
	{
		super.Init(isEditableForm)

		this.arrayOptions = computed(() => this.unwrapArrayOptions(this.modelFieldRef?.arrayOptions))
		// TODO: This is a workaround to hide groups without elements. This code is needed until the component has this part working for itself.
		this.arrayGroups = this.modelFieldRef?.arrayGroups
		this.groups = this.modelFieldRef?.arrayGroups
		watchEffect(() => this.items = this.filterArrayElements(this.arrayOptions, this.arrayGroups) || [])

		this.emptyValue = this.modelFieldRef?.constructor.EMPTY_VALUE
		// The array is clearable if its not required, and if the empty value is not an option of the array.
		this.clearable = computed(() => !this.isRequired && !this.items.some(item => item.key === this.emptyValue))

		this.filterArrayElements()
	}

	/**
	 * Initialization of formulas that belong only to the control (interface part).
	 * @override
	 */
	initControlFormulas()
	{
		super.initControlFormulas()

		// Array element show when formula
		if (this.arrayElShowWhen)
			this.vueContext.internalEvents.onMany(this.arrayElShowWhen.dependencyEvents, () => this.reloadArray())
	}

	/**
	 * Reloads the array's data
	 */
	reloadArray()
	{
		this.filterArrayElements(this.arrayOptions, this.arrayGroups)
	}

	/**
	 * Filters the array elements according to the specified condition.
	 * @param {Array} allOptions
	 * @param {Array} allGroups
	 */
	filterArrayElements(allOptions, allGroups)
	{
		if (!this.arrayElShowWhen || !allOptions || allOptions.length === 0)
			return allOptions

		// Filter array
		Promise.all(this.validateArrayElShowWhen(allOptions)).then(
			(options) => {
				const filteredOptions = options
					.filter((o) => o.show)
					.map((o) => o.el)

				// Update visible options
				if (allGroups !== undefined) {
					// Update visible options for groups
					watchEffect(() => {
						this.groups = allGroups.filter(item => filteredOptions.some(option => option.group === item.id));
					});
				}
				watchEffect(() => (this.items = filteredOptions))

				// Clean display value
				if (filteredOptions.filter((o) => o.key === this.modelFieldRef.value).length === 0)
					this.modelFieldRef.updateValue(null)
			}
		)
	}

	/**
	 * Runs the array element show when formula.
	 * @param {Array} allOptions
	 */
	validateArrayElShowWhen(allOptions)
	{
		const res = []

		_forEach(allOptions, (arrayEl) => {
			res.push(
				new Promise((resolve) => {
					this.validateFieldFormula(
						this.arrayElShowWhen,
						(result) => resolve({ el: arrayEl, show: result }),
						{ arrayEl }
					)
				})
			)
		})

		return res
	}

	/**
	 * Unwraps the options of the array,
	 * taking into consideration whether or not the array is dynamic.
	 * @param {Array} arrayOptions
	 */
	unwrapArrayOptions(arrayOptions)
	{
		return (isRef(arrayOptions) ? arrayOptions.value : arrayOptions) || []
	}
}

/**
 * Form array (String) control
 */
export class ArrayStringControl extends BaseArrayControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'String',
			texts: new controlsResources.LookupResources(_vueContext.$getResource)
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * Form array (Number) control
 */
export class ArrayNumberControl extends BaseArrayControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Number',
			texts: {
				...new controlsResources.LookupResources(_vueContext.$getResource),
				...new controlsResources.NumberInputResources(_vueContext.$getResource)
			}
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * Form array (Boolean) control
 */
export class ArrayBooleanControl extends BaseArrayControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Boolean'
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * Form Coordinates control
 */
export class CoordinatesControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Coordinates'
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * Form mask control
 */
export class MaskControl extends StringControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Mask',
			maskType: '',
			maskFormat: null
		}, _vueContext)

		_merge(this, options || {})
	}

	/**
	 * Initializes the necessary properties.
	 * @param {boolean} isEditableForm Whether or not the control is editable
	 */
	Init(isEditableForm)
	{
		super.Init(isEditableForm)

		if (this.modelFieldRef)
		{
			this.maskType = this.modelFieldRef.maskType || ''
			this.maskFormat = this.modelFieldRef.maskFormat || null
		}
	}
}

/**
 * Form List control (DB)
 */
export class LookupControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			/** The type of the control class */
			type: 'Lookup',
			/** List of limits (value getter + identifier). Used in requests for the new options list */
			controlLimits: [],
			/** It's used to indicate if there are more records in addition to the ones it contains in items list */
			hasMore: true,
			selected: null,
			/** Used for reduce unnecessary requests when limit values have not changed */
			prevLimitValues: {},
			/** The identifier of the search field that the server is waiting to receive */
			searchId: 'UNKNOWN',
			seeMoreIsVisible: false,
			seeMoreParams: {},
			/** Information about the Key field on the model */
			lookupKeyModelField: {
				/** The Key model field name */
				name: null,
				/** The Key field change event name */
				dependencyEvent: null
			},
			/** «Reference» for the Key model field (Proxy) */
			lookupKeyModelFieldRef: null,
			// Number of last request
			// The list can make more than one 'simultaneous' request to the server and only the response of the last request is of interest
			_requestNumberReload: 0,
			_requestNumberGetDependants: 0,
			/** The interface texts */
			texts: new controlsResources.LookupResources(_vueContext.$getResource),
			insertEnabled: false,
			supportForm: undefined,
			externalCallbacks: {},
			externalProperties: {}
		}, _vueContext)

		_merge(this, options || {})
	}

	get props()
	{
		return {
			...super.props,
			items: this.modelFieldRef?.options ?? [],
			itemValue: 'key',
			itemLabel: 'value',
			totalRows: this.modelFieldRef.totalRows,
			emptyValue: this.lookupKeyModelFieldRef.constructor.EMPTY_VALUE,
			filterMode: 'manual',
			showSeeMore: this.hasMore,
			showViewDetails: !_isEmpty(this.supportForm),
			clearable: !this.isRequired,
			texts: this.texts
		}
	}

	Init(isEditableForm)
	{
		// Set reference to the model key field
		if (!_isEmpty(this.lookupKeyModelField.name) && typeof this.externalCallbacks.getModelField === 'function')
			this.lookupKeyModelFieldRef = this.externalCallbacks.getModelField(this.lookupKeyModelField.name)

		super.Init(isEditableForm)

		this.applyHistoryLimit()

		this.initHandlers()

		// The search input Id that is sent to the server
		this.searchId = `qTable${_capitalize(this.dbArea)}${_capitalize(this.dbField)}`

		this.hasMore = computed(() => !this.readonly && this.modelFieldRef?.hasMore !== false)

		this.initEvents()
	}

	/**
	 * Initialization of formulas that belong only to the control (interface part).
	 * @override
	 */
	initControlFormulas()
	{
		this.initFormulas(this.lookupKeyModelFieldRef)
	}

	/**
	 * Apply history to block the field
	 */
	applyHistoryLimit()
	{
		if (this.modelFieldRef && !_isEmpty(this.modelFieldRef.area))
		{
			let lookupArea = this.modelFieldRef.area.toLowerCase()
			if (this.vueContext.navigation.currentLevel.hasEntry(lookupArea, false, true))
				this.addBlockSource('HISTORY')
		}
	}

	/**
	 * Initialize the default handlers for List component events
	 */
	initHandlers()
	{
		this.debouncedSearch = _debounce(this.handleSearch, 500);

		const handlers = {
			beforeShow: (eventData) => this.handleBeforeShow(eventData),
			onSearch: (eventData) => this.debouncedSearch(eventData),
			seeMore: (eventData) => this.handleSeeMore(eventData),
			seeMoreChoice: (eventData) => this.handleSeeMoreChoice(eventData),
			close: (eventData) => this.handleSeeMoreClose(eventData),
			insert: () => this.handleOnInsert(),
			viewDetails: (eventData) => this.handleViewDetails(eventData),
		}

		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	/**
	 * Initiating of listeners for events on which functions such as content reloading depend
	 */
	initEvents()
	{
		// Reload control opttions when any limit is changed
		var dependencyEvents = ['RELOAD_ALL_LOOKUP_CONTROLS']

		// Add event to detect change of non-duplication prefix.
		if (this.modelFieldRef && !_isEmpty(this.modelFieldRef.area) && this.modelFieldRef.isUnique && !_isEmpty(this.modelFieldRef.uniquePrefixField))
		{
			const lookupArea = this.modelFieldRef.area,
				prefixFieldName = this.modelFieldRef.uniquePrefixField,
				prefixField = `${lookupArea}.${prefixFieldName}`.toLowerCase()

			dependencyEvents.push('fieldChange:' + prefixField)
		}

		// Events to detect changes in the value of limits
		if (!_isEmpty(this.controlLimits))
		{
			_forEach(this.controlLimits, (controlLimit) => {
				dependencyEvents = _unionWith(dependencyEvents, controlLimit.dependencyEvents)
			})
		}

		if (!_isEmpty(dependencyEvents) && this.vueContext.internalEvents)
			this.vueContext.internalEvents.onMany(dependencyEvents, () => this.reloadLookupContent(null, false))

		// Get dependent fields values that correspond to the selected value
		if (!_isEmpty(this.lookupKeyModelField.dependencyEvent) && this.vueContext.internalEvents)
			this.vueContext.internalEvents.on(this.lookupKeyModelField.dependencyEvent, () => this.getDependants())
	}

	/**
	 * Lookup search mechanism
	 * @param {String} searchQuery
	 */
	handleSearch(searchQuery)
	{
		// Server-side search
		this.reloadLookupContent(searchQuery, false, true)
	}

	/**
	 * Lookup content reloading
	 * @param {String} searchQuery
	 * @param {Boolean} lazyLoad
	 * @param {Boolean} isSearching
	 */
	reloadLookupContent(searchQuery, lazyLoad = false, isSearching = false)
	{
		if (!this.vueContext.formInfo || !this.vueContext.authData.isAllowed) // TODO: Change it!
			return

		const limitValues = {
				limits: {},
				queryParams: {},
				searchQuery
			},
			baseApiController = _capitalize(this.vueContext.formInfo.area)

		// Limits
		_assignIn(limitValues.limits, this.getLimitsValues())

		// In the case of indirect limitations it was necessary to have all keys (it is necessary to validate)
		const keys = this.externalProperties.modelKeys

		_forEach(keys, (keyField, keyAreaName) => {
			Reflect.set(limitValues.limits, keyAreaName, keyField.value)
		})

		// Apply search query
		if (searchQuery !== undefined && searchQuery !== null)
			Reflect.set(limitValues.queryParams, this.searchId, searchQuery)
		else if (!lazyLoad)
		{
			// If it was a reload, we need to remove the option currently selected
			// so that it is not added to the list when it does not belong
			Reflect.set(limitValues.limits, this.dbArea, null)
		}

		// Reduce unnecessary requests when limits have not changed
		if (_isEqual(limitValues, this.prevLimitValues))
			return

		this.prevLimitValues = limitValues

		// Put the limit values in Navigation (history) before making the request to the server.
		if (typeof this.vueContext.setEntryValue !== 'function')
		{
			this.vueContext.$eventTracker.addError({
				origin: 'reloadLookupContent (fieldControl)',
				message: 'The control does not have access to history to set the limits - «setEntryValue».'
			})
			return
		}

		_forEach(limitValues.limits, (value, key) => {
			const entry = {
				navigationId: this.vueContext.navigationId,
				key,
				value
			}
			this.vueContext.setEntryValue(entry)
		})

		// Make request
		const params = {
			Identifier: this.id,
			Values: limitValues.queryParams
		}

		this.addLoadingProc(netAPI.postData(baseApiController, 'ReloadDBEdit', params, (data, response) => {
			const requestNumber = response.headers['reloaddbeditrequestnumber']
			// The list can make more than one 'simultaneous' request to the server and only the response of the last request is interest
			if (Number(requestNumber) !== this._requestNumberReload)
				return

			// Process the received data
			if (response.data.Success)
			{
				// Update model data
				this.modelFieldRef?.updateValue(data)
				// If the user is still searching for the desired record, we don't update the key
				if (!isSearching)
					this.lookupKeyModelFieldRef?.updateValue(data.Selected)
			}
		}, undefined, {
			headers: {
				ReloadDBEditRequestNumber: this._requestNumberReload += 1
			}
		}, this.vueContext.navigationId))
	}

	/**
	 * Makes a request to the server to obtain the value of the fields dependent on it (and currently selected value), including the fields of the field itself.
	 */
	getDependants()
	{
		if (!this.vueContext.formInfo || !this.vueContext.authData.isAllowed) // TODO: Change it!
			return

		if (!this.lookupKeyModelFieldRef)
			return

		var values = {},
			baseApiController = _capitalize(this.vueContext.formInfo.area)

		// Limits
		_assignIn(values, this.getLimitsValues())

		// In the case of indirect limitations it was necessary to have all keys (it is necessary to validate)
		const keys = this.externalProperties.modelKeys

		_forEach(keys, (keyField, keyAreaName) => Reflect.set(values, keyAreaName, keyField.value))

		// Put the limit values in Navigation (history) before making the request to the server.
		if (typeof this.vueContext.setEntryValue !== 'function')
		{
			this.vueContext.$eventTracker.addError({
				origin: 'getDependants (fieldControl)',
				message: 'The control does not have access to history to set the limits - «setEntryValue».'
			})
			return
		}

		_forEach(values, (value, key) => {
			const entry = {
				navigationId: this.vueContext.navigationId,
				key,
				value
			}
			this.vueContext.setEntryValue(entry)
		})

		// Make request
		const params = {
			Identifier: this.id,
			Selected: this.lookupKeyModelFieldRef.value
		}

		this.addLoadingProc(netAPI.postData(baseApiController, 'GetDependants', params, (data, response) => {
			const requestNumber = response.headers['getdependantsrequestnumber']
			// The list can make more than one 'simultaneous' request to the server and only the response of the last request is interest
			if (Number(requestNumber) !== this._requestNumberGetDependants)
				return

			// Process the received data
			if (response.data.Success)
			{
				// Update model data (including the Key/Value of the field itself)
				if (this.dependentFields)
				{
					let _depFieldsRef = this.dependentFields.call(this.vueContext)
					_forEach(data, (depFieldValue, depFieldId) => _depFieldsRef[depFieldId] = depFieldValue)
				}

				// Ensure that the chosen option exists
				if (this.modelFieldRef && this.lookupKeyModelFieldRef)
				{
					const selectedOption = {
						key: this.lookupKeyModelFieldRef.value,
						value: this.modelFieldRef.value
					}

					if (!_isEmpty(selectedOption.key) && !_isEmpty(selectedOption.value) && !_some(this.modelFieldRef.options, selectedOption))
						this.modelFieldRef.options.push(selectedOption)
				}
			}
		}, undefined, {
			headers: {
				GetDependantsRequestNumber: this._requestNumberGetDependants += 1
			}
		}, this.vueContext.navigationId), true)
	}

	/**
	 * Handle the modal closing event
	 */
	handleSeeMoreClose()
	{
		this.seeMoreIsVisible = false
		this.seeMoreParams = {}
	}

	/**
	 * Handle the Key selection event
	 */
	handleSeeMoreChoice(selectedItem)
	{
		this.handleSeeMoreClose()
		if (this.lookupKeyModelFieldRef)
			this.lookupKeyModelFieldRef.updateValue(selectedItem)
	}

	/**
	 * Handle the opening «See more..» event
	 */
	handleSeeMore()
	{
		this.seeMoreParams = {
			id: this.vueContext.primaryKeyValue,
			limits: this.getLimitsValues(),
			navigationId: this.vueContext.navigationId
		}
		this.seeMoreIsVisible = true
	}

	/**
	 * Handler for the "View details" event.
	 */
	handleViewDetails(rowId)
	{
		if (!_isEmpty(this.supportForm) && !_isEmpty(rowId))
			this.vueContext.navigateToForm(this.supportForm, 'SHOW', rowId, { isControlled: true })
	}

	/**
	 * Handler for the new record insertion event
	 */
	handleOnInsert()
	{
		if (!_isEmpty(this.supportForm))
			this.vueContext.navigateToForm(this.supportForm, 'NEW', undefined, { isControlled: true })
	}

	/**
	 * Handler to fetch the content of the lookup.
	 */
	handleBeforeShow()
	{
		this.reloadLookupContent(null, true, true)
	}

	/**
	 * Adds the async process to the watch list of loading requests.
	 * @param {Promise} cbPromise he «Promise» object of the process
	 * @param {Boolean} affectsParent If affects the parent context
	 */
	addLoadingProc(cbPromise, affectsParent)
	{
		if (affectsParent)
			this.addLoadingProcToParent(this.componentOnLoadProc.AddWL(cbPromise))
		else
			this.componentOnLoadProc.AddWL(cbPromise)
	}
}

/**
 * Form Table list control
 */
export class TableListControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		let importExportResources = new controlsResources.ImportExportResources(_vueContext.$getResource)
		// Init default values of control properties
		super({
			/** The type of the control class */
			type: 'List',
			columns: [],
			columnsOriginal: [],
			columnsCustom: [],
			rows: [],
			rowFormProps: [],
			totalRows: 0,
			hasMorePages: false,
			headerLevel: 2,
			/** List of limits (value getter + identifier). Used in requests for the new rows list */
			controlLimits: [],
			/**
			 * List of limits with fixed value (value + identifier).
			 * Used, for example, in See More lists, to apply dynamic values received from the form (for example, 'Field' type limit).
			 */
			fixedControlLimits: undefined,
			isLoaded: false,
			loadDefaultView: true,
			loadView: false,
			/** Data already requested from the server at least once */
			dataAlreadyRequested: false,
			hydrate: listFunctions.hydrateTableData,
			rowsSelected: {},
			rowsChecked: {},
			rowsDirty: {},
			searchOnNextChange: { value: false },
			advancedFilters: [],
			columnFilters: {},
			groupFilters: [],
			activeFilters: {},
			dataImportResponse: {},
			rowComponent: 'q-table-row',
			formName: '',
			newRowID: '',
			signal: {},
			subSignals: {
				config: {},
				columnConfig: {},
				advancedFilters: {},
				advancedFiltersNew: {},
				viewSave: {},
				views: {}
			},
			confirmChanges: false,
			config: {
				serverMode: computed(() => !!options?.config?.serverMode),
				perPage: computed(() => _vueContext.system ? _vueContext.system.defaultListRows : options.config !== undefined ? options.config.perPage !== undefined ? options.config.perPage : 10 : 10),
				perPageOptions: [],
				actionsPlacement: computed(() => _vueContext.layoutConfig ? _vueContext.layoutConfig.DbEditActionPlacement : 'left'),
				paginationPlacement: computed(() => _vueContext.layoutConfig ? _vueContext.layoutConfig.DbEditPagerPlacement : 'left'),
				rowActionDisplay: computed(() => _vueContext.layoutConfig ? _vueContext.layoutConfig.RowActionDisplay : 'dropdown'),
				showRowActionText: computed(() => _vueContext.layoutConfig ? _vueContext.layoutConfig.RowActionDisplay !== 'inline' : true),
				hasTextWrap: false,
				allowFileExport: false,
				allowFileImport: false,
				exportOptions: importExportResources.exportOptions,
				importOptions: importExportResources.importOptions,
				importTemplateOptions: importExportResources.importTemplateOptions,
				hasRowDragAndDrop: false,
				tableTitle: '',
				tableNamePlural: '',
				configOptions: [],
				viewManagement: qEnums.tableViewManagementModes.none,
				hasCustomColumns: false,
				globalSearch: {
					visibility: false
				},
				filtersVisible: false,
				allowColumnFilters: false,
				allowColumnSort: false,
				showRecordCount: false,
				showRowsSelectedCount: false,
				linkRowsSelectedAndChecked: false,
				menuForJump: '',
				sortByField: false,
				showRowDragAndDropOption: false,
				showLimitsInfo: false,
				showAfterFilter: false,
				columnResizeOptions: {},
				permissions: {
					canView: true,
					canEdit: true,
					canDuplicate: true,
					canDelete: true,
					canInsert: true
				},
				crudConditions: {
					view: () => true,
					update: () => true,
					delete: () => true,
					insert: () => true
				},
				canInsert: true,
				rowActionClasses: {
					'dropdown-item': true
				},
				enableRowActionButtonBaseClasses: false,
				rowKeyToScroll: '',
				resourcesPath: computed(() => _vueContext.system?.resourcesPath ?? ''),
				emptyRowImg: 'empty_card_container.png',
				onLoadSelectFirst: false
			},
			texts: new controlsResources.TableListMainResources(_vueContext.$getResource),
			// The translation mechanism for the filter operators arrays
			filterOperators: searchFilterData.getWithTranslation(_vueContext.$getResource).operators.elements,
			allSelectedRows: 'false'
		}, _vueContext)

		_merge(this, options || {})

		this.columnsCustom = ref(this.columnsCustom)
		this.columnsOriginal = ref(this.columnsOriginal)
		this.columns = computed(() => !_isEmpty(this.columnsCustom.value) ? this.columnsCustom.value : this.columnsOriginal.value)
	}

	/**
	 * Initializes the necessary properties.
	 * @param {boolean} isEditableForm Whether or not the control is editable
	 */
	Init(isEditableForm)
	{
		super.Init(isEditableForm)

		this.config.canInsert = computed(() => this.config.permissions.canInsert && this.config.crudConditions.insert())

		this.initHandlers()

		this.isLoaded = false

		this.initEvents()
		this.initUserConfig()
		this.clearUnsavedConfig()
	}

	/**
	 * Initialize the default handlers for List component events
	 */
	initHandlers()
	{
		const handlers = {
			onChangeQuery: (eventData) => this.onTableListChangeQuery(eventData),
			setSearchOnNextChange: (eventData) => this.setSearchOnNextChange(eventData),
			saveView: (eventData) => this.onTableListSaveView(eventData),
			copyView: (eventData) => this.onTableListCopyView(eventData),
			selectView: (eventData) => this.onTableListSelectView(eventData),
			closeView: (eventData) => this.onTableListCloseView(eventData),
			viewAction: (eventData) => this.onTableListViewAction(eventData),
			onExportData: (eventData) => this.onTableListExportData(eventData, false),
			onImportData: (eventData) => this.onTableListImportData(eventData),
			onExportTemplate: (eventData) => this.onTableListExportData(eventData, true),
			'update:active-view-mode': (eventData) => this.updateActiveViewMode(eventData),
			removeRow: (eventData) => this.onRemoveRow(eventData),
			rowAdd: (eventData) => this.onTableListRowAdd(eventData),
			rowEdit: (eventData) => this.onTableListRowEdit(eventData),
			rowsDelete: (eventData) => this.onTableListRowsDelete(eventData),
			rowReorder: (eventData) => this.onTableListRowReorder(eventData),
			toggleRowsDragDrop: () => this.onToggleRowsDragDrop(),
			rowGroupAction: (eventData) => this.onTableListRowGroupAction(eventData),
			goToRow: (eventData) => this.onGoToRow(eventData),
			selectRow: (eventData) => this.onSelectRow(eventData),
			unselectRow: (eventData) => this.onUnselectRow(eventData),
			selectRows: (eventData) => this.onSelectRows(eventData),
			unselectAllRows: (eventData) => this.onUnselectAllRows(eventData),
			executeAction: (eventData) => this.onTableListExecuteAction(eventData),
			rowAction: (eventData) => this.onTableListExecuteAction(eventData),
			cellAction: (eventData) => this.onTableListCellAction(eventData),
			updateCell: (eventData) => this.onTableListUpdateCell(eventData),
			applyColumnConfig: (eventData) => this.onTableListApplyColumnConfig(eventData),
			resetColumnConfig: (eventData) => this.onTableListResetColumnConfig(eventData),
			resetColumnSizes: (eventData) => this.onTableListResetColumnSizes(eventData),
			showPopup: (eventData) => this.SetModal(eventData),
			hidePopup: (eventData) => this.RemoveModal(eventData),
			setDropdown: (eventData) => this.setDropdown(eventData),
			setInfoMessage: (eventData) => this.setInfoMessage(eventData),
			showAdvancedFilters: (eventData) => this.setAdvancedFiltersPopup(eventData),
			addAdvancedFilter: (eventData) => this.addAdvancedFilter(eventData),
			editAdvancedFilter: (eventData) => this.editAdvancedFilter(eventData),
			removeAdvancedFilter: (eventData) => this.removeAdvancedFilter(eventData),
			setAdvancedFilterState: (eventData) => this.setAdvancedFilterState(eventData),
			setAdvancedFilterStates: (eventData) => this.setAdvancedFilterStates(eventData),
			removeAllAdvancedFilters: () => this.removeAllAdvancedFilters(),
			deactivateAllAdvancedFilters: () => this.deactivateAllAdvancedFilters(),
			updateConfig: () => this.updateConfig(),
			setProperty: (...args) => this.setProperty(...args),
			setArraySubPropWhere: (...args) => this.setArraySubPropWhere(...args),
			insertForm: (...args) => this.onTableListInsertForm(...args),
			cancelInsert: (...args) => this.onTableListCancelInsertRow(...args),
			signalComponent: (...args) => this.signalComponent(...args),
			toggleTextWrap: () => { this.config.hasTextWrap = !this.config.hasTextWrap },
			setQtableAllSelected: (eventData) => this.onSetQtableAllSelected(eventData),
			fetchQtableAllSelected: (eventData) => this.onFetchQtableAllSelected(eventData)
		}

		// Apply handlers without overriding. The handler can come from outside at initialization.
		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	/**
	 * Initialization of listeners for events on which functions such as content reloading depend
	 */
	initEvents()
	{
		listFunctions.initTableEvents(this)
	}

	/**
	 * Set available user configuration options.
	 */
	initUserConfig()
	{
		const configOptions = []

		const allowBasicConfiguration = [
			qEnums.tableViewManagementModes.nonPersistent,
			qEnums.tableViewManagementModes.persistOne,
			qEnums.tableViewManagementModes.persistMany
		].includes(this.config.viewManagement)

		this.config.allowAdvancedFilters = this.config.allowColumnConfiguration =
			allowBasicConfiguration
		this.config.allowManageViews =
			this.config.viewManagement === qEnums.tableViewManagementModes.persistMany

		if (this.config.allowManageViews)
		{
			configOptions.push({
				id: 'viewSaveChanges',
				icon: {
					icon: 'save'
				},
				text: this.texts.saveChanges,
				active: false,
				visible: true
			})
			configOptions.push({
				id: 'viewRename',
				elementId: 'view-save',
				componentId: 'viewSave',
				icon: {
					icon: 'add'
				},
				text: this.texts.saveWithOtherName,
				active: false,
				visible: true
			})
		}

		if (this.config.allowColumnConfiguration)
			configOptions.push({
				id: 'columnConfig',
				elementId: 'column-config',
				componentId: 'columnConfig',
				icon: {
					icon: 'list'
				},
				text: this.texts.configureColumns,
				separatorBefore: true,
				active: true,
				visible: true
			})

		if (this.config.allowAdvancedFilters)
			configOptions.push({
				id: 'advancedFilters',
				elementId: 'advanced-filters',
				componentId: 'advancedFilters',
				icon: {
					icon: 'filter'
				},
				text: this.texts.configureFilters,
				active: true,
				visible: computed(() => this.advancedFilters?.length > 0)
			})

		if (this.config.allowManageViews)
		{
			configOptions.push({
				id: 'views',
				elementId: 'views',
				componentId: 'views',
				icon: {
					icon: 'view-manager'
				},
				text: this.texts.manageViews,
				active: true,
				visible: true
			})
			configOptions.push({
				id: 'viewSave',
				elementId: 'view-save',
				componentId: 'viewSave',
				icon: {
					icon: 'add'
				},
				text: this.texts.createView,
				separatorBefore: true,
				active: true,
				visible: true
			})
		}

		this.config.configOptions = configOptions
	}

	clearUnsavedConfig() { this.componentOnLoadProc.AddWL(this.vueContext.clearUnsavedConfig(this)) }
	onTableListChangeQuery(eventData) { this.componentOnLoadProc.AddWL(this.vueContext.onTableListChangeQuery(this, eventData)) }
	setSearchOnNextChange(eventData) { this.vueContext.setSearchOnNextChange(this, eventData) }
	onTableListSaveView(eventData) { this.vueContext.onTableListSaveView(this, eventData) }
	onTableListCopyView(eventData) { this.vueContext.onTableListCopyView(this, eventData) }
	onTableListCloseView(eventData) { this.vueContext.onTableListCloseView(this, eventData) }
	onTableListSelectView(eventData) { this.vueContext.onTableListSelectView(this, eventData) }
	onTableListViewAction(eventData) { this.vueContext.onTableListViewAction(this, eventData) }
	onTableListExportData(eventData, template) { asyncProcM.AddBusy(this.vueContext.onTableListExportData(this, eventData, template), 'Export...') }
	onTableListImportData(eventData) { asyncProcM.AddBusy(this.vueContext.onTableListImportData(this, eventData), 'Import...') }
	updateActiveViewMode(eventData) { this.vueContext.updateActiveViewMode(this, eventData) }
	onRemoveRow(eventData) { this.vueContext.onRemoveRow(this, eventData) }
	onTableListRowAdd(eventData) { this.vueContext.onTableListRowAdd(this, eventData) }
	onTableListRowEdit(eventData) { this.vueContext.onTableListRowEdit(this, eventData) }
	onTableListRowsDelete(eventData) { this.vueContext.onTableListRowsDelete(this, eventData) }
	onTableListRowReorder(eventData) { this.vueContext.onTableListRowReorder(this, eventData) }
	onToggleRowsDragDrop() { this.vueContext.onToggleRowsDragDrop(this) }
	onTableListRowGroupAction(eventData) { this.vueContext.onTableListRowGroupAction(this, eventData) }
	onGoToRow(eventData) { this.vueContext.onGoToRow(this, eventData) }
	onSelectRow(eventData) { this.vueContext.onSelectRow(this, eventData) }
	onUnselectRow(eventData) { this.vueContext.onUnselectRow(this, eventData) }
	onSelectRows(eventData) { this.vueContext.onSelectRows(this, eventData) }
	onUnselectAllRows(eventData) { this.vueContext.onUnselectAllRows(this, eventData) }
	onTableListExecuteAction(eventData) { this.vueContext.onTableListExecuteAction(this, eventData) }
	onTableListCellAction(eventData) { this.vueContext.onTableListCellAction(this, eventData) }
	onTableListUpdateCell(eventData) { this.vueContext.onTableListUpdateCell(this, eventData) }
	onTableListApplyColumnConfig(eventData) { this.vueContext.onTableListApplyColumnConfig(this, eventData) }
	onTableListResetColumnConfig(eventData) { this.vueContext.onTableListResetColumnConfig(this, eventData) }
	onTableListResetColumnSizes(eventData) { this.vueContext.onTableListResetColumnSizes(this, eventData) }
	setDropdown(eventData) { this.vueContext.setDropdown(eventData) }
	setInfoMessage(eventData) { this.vueContext.setInfoMessage(eventData) }
	setAdvancedFiltersPopup(eventData) { this.vueContext.setAdvancedFiltersPopup(this, eventData[0], eventData[1]) }
	addAdvancedFilter(eventData) { this.vueContext.addAdvancedFilter(this, eventData) }
	editAdvancedFilter(eventData) { this.vueContext.editAdvancedFilter(this, eventData[0], eventData[1]) }
	removeAdvancedFilter(eventData) { this.vueContext.removeAdvancedFilter(this, eventData) }
	setAdvancedFilterState(eventData) { this.vueContext.setAdvancedFilterState(this, eventData[0], eventData[1]) }
	setAdvancedFilterStates(eventData) { this.vueContext.setAdvancedFilterStates(this, eventData[0], eventData[1]) }
	removeAllAdvancedFilters() { this.vueContext.removeAllAdvancedFilters(this) }
	deactivateAllAdvancedFilters() { this.vueContext.deactivateAllAdvancedFilters(this) }
	updateConfig(...args) { this.vueContext.updateConfig(this, ...args) }
	setProperty(...args) { this.vueContext.setProperty(this, ...args) }
	setArraySubPropWhere(...args) { this.vueContext.setArraySubPropWhere(this, ...args) }
	onTableListInsertForm(...args) { this.vueContext.onTableListInsertForm(this, ...args) }
	onTableListCancelInsertRow(...args) { this.vueContext.onTableListCancelInsertRow(this, ...args) }
	signalComponent(...args) { this.vueContext.signalComponent(this, ...args) }
	onSetQtableAllSelected(eventData) { this.vueContext.onSetQtableAllSelected(this, eventData) }
	onFetchQtableAllSelected(eventData) { this.vueContext.onFetchQtableAllSelected(this, eventData) }

	/**
	 * Searches for a row with the specified id
	 * @param {string || array} id The id to search
	 * @param {boolean} selectFirst Whether or not to select the first row
	 * @returns The row with specified id, or, depending on the "selectFirst" option, null or the first row
	 */
	getRow(id, selectFirst = false)
	{
		const rows = this.rows
		const rownNum = rows.length

		return listFunctions.getRowByKeyPath(rows, id) ?? (selectFirst && rownNum > 0 ? rows[0] : null)
	}

	/**
	 * Selects the desired row (if none is found selects the first)
	 * @param {string || array} id The desired id
	 */
	selectRow(id)
	{
		const row = this.getRow(id, true)

		// If row with this ID exists or first row exists
		if (row !== null)
			this.onSelectRow({ rowKeyPath: listFunctions.getRowKeyPath(this.rows, row) })
	}

	/**
	 * Runs after each time the table finishes loading
	 */
	afterLoaded()
	{
		// Use to select all the previously selected rows before navigating
		if (this.config.rowClickActionInternal !== 'selectSingle')
			return

		// Gets the base navigation level for the form
		let nav = this.vueContext.navigation.currentLevel
		while (nav.isNested)
			nav = nav.previousLevel

		// Selects the previously selected rows that weren't opened in a support form
		let rowId = this.vueContext.navigation.currentLevel.entries ? this.vueContext.navigation.currentLevel.entries[`TableListControl_${this.id}`] : null
		// Convert rowId to row key path array if it has multiple keys or a string if it is a single key
		if (rowId !== undefined && rowId !== null)
		{
			rowId = rowId.split(',')
			if (Array.isArray(rowId) && rowId.length === 1)
				rowId = rowId[0]
		}

		if (nav.params.returnControl === this.id) // If the opened record in a support form belongs to this table
			this.selectRow(nav.params.previouslyRemovedRowKey)
		else if (rowId) // If this row was selected to show an extended support form
			this.selectRow(rowId)
		else if (this.config.onLoadSelectFirst)
			this.selectRow()
	}

	/**
	 * Reloads the data of the list
	 */
	Reload()
	{
		return this.componentOnLoadProc.AddWL(this.vueContext.fetchListData(this))
	}
}

/**
 * Form Tree table list control
 */
export class TreeTableListControl extends TableListControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			type: 'TreeList',
			hydrate: listFunctions.hydrateTreeTableData,
			clipboard: {},
			rowComponent: 'q-tree-table-row',
			rawRows: [],
			config: {
				showRowActionText: false,
				allowColumnResize: false,
				filtersVisible: false,
				allowColumnFilters: false,
				allowColumnSort: false,
				globalSearch: {
					visibility: false
				},
				searchList: {
					empty: true,
					values: [],
					numRows: 0,
					currentIdx: 0
				},
				treeListDefinitions: {
					branchAreas: {},
					rowModel: (row) => row
				}
			}
		}, _vueContext)

		_mergeWith(this, options || {}, genericFunctions.mergeOptions)

		// Set the first column as tree Show/Hide (if none exist)
		if (this.columnsOriginal.length > 0 && !_some(this.columnsOriginal, { hasTreeShowHide: true }))
			Reflect.set(this.columnsOriginal[0], 'hasTreeShowHide', true)
	}

	initHandlers()
	{
		// Apply the rest of the inherited handlers (which also don't override)
		super.initHandlers()

		const handlers = {
			getInsertFormName: (eventData) => this.getInsertFormName(eventData),
			treeLoadBranchData: (eventData) => this.treeLoadBranchData(eventData)
		}

		// Apply handlers without overriding. The handler can come from outside at initialization.
		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	/**
	 * Runs after each time the table finishes loading
	 */
	afterLoaded()
	{
		// Override function to prevent selecting rows incorrectly
	}

	/**
	 * Return the name of the form to open depending on the selected row
	 * @param {object} row The selected row
	 */
	getInsertFormName(row)
	{
		const formsList = Object.entries(this.config.formsDefinition)

		// Default level if no row is selected
		let formLevel = 0

		// Checks for current level and finds the next one
		if (row)
			formLevel = this.config.formsDefinition[row.Form].level + 1

		// If the level is out of bounds, use the last level
		if (formLevel > formsList.length - 1)
			formLevel = formsList.length - 1

		// Get form name based on level
		const formToOpen = formsList.find((entry) => entry[1]?.level === formLevel)
		if (formToOpen)
			return formToOpen[0]
		return null
	}

	/**
	 * The method responsible for making the server request and loading the children of the branch (if any)
	 * @param {object} eventData Event object that contains the current parent row
	 */
	treeLoadBranchData(eventData)
	{
		if (eventData.row?.alreadyLoaded === false)
		{
			// Prevent double request
			eventData.row.alreadyLoaded = true

			this.componentOnLoadProc.AddWL(this.vueContext.fetchListData(this, {
				queryParams: {
					currentBranch: eventData.row?.BranchId + 1,
					currentSelectedKey: eventData.row?.rowKey
				}
			}, (data) => {
				const rowKeyToScroll = this.vueContext.currentControl?.data?.rowKey ?? null
				eventData.row?.hydrateChildrenData(data.Tree, rowKeyToScroll)
			}), 300)
		}
	}
}

/**
 * Form Multiple Values table list control
 */
export class MultipleValuesControl extends TableListControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			type: 'MultipleValuesList',
			modelFieldOptions: null,
			modelFieldOptionsRef: null,
			config: {
				filtersVisible: false,
				allowColumnFilters: false,
				allowColumnSort: false,
				globalSearch: {
					visibility: false
				},
				rowClickActionInternal: 'selectMultiple',
				showFooter: false
			}
		}, _vueContext)

		_mergeWith(this, options || {}, genericFunctions.mergeOptions)
	}

	/**
	 * Initializes the necessary properties.
	 * @param {boolean} isEditableForm Whether or not the control is editable
	 */
	Init(isEditableForm)
	{
		super.Init(isEditableForm)

		// Set reference to the model field that contains the options
		if (!_isEmpty(this.modelFieldOptions) && this.vueContext.model)
			if (_has(this.vueContext.model, this.modelFieldOptions))
				this.modelFieldOptionsRef = _get(this.vueContext.model, this.modelFieldOptions)

		this.initHandlers()
	}

	/**
	 * Initialize the default handlers for List component events
	 */
	initHandlers()
	{
		const handlers = {
			setQtableAllSelected: (eventData) => this.onSetQtableAllSelected(eventData),
			fetchQtableAllSelected: (eventData) => this.onFetchQtableAllSelected(eventData)
		}

		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)

		super.initHandlers()
	}

	onSetQtableAllSelected(eventData)
	{
		super.onSetQtableAllSelected(eventData)
	}

	onFetchQtableAllSelected(eventData)
	{
		super.onFetchQtableAllSelected(eventData)
	}
}

/**
 * Multiple Values extension control
 */
export class MultipleValuesExtensionControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			type: 'MultipleValuesExtension',
			texts: new controlsResources.MultipleValuesExtensionResources(_vueContext.$getResource)
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * Document control
 */
export class DocumentControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			type: 'Document',
			versionsInfo: [],
			fileProperties: {},
			extensions: [],
			texts: new controlsResources.DocumentResources(_vueContext.$getResource),
			resourcesPath: computed(() => _vueContext.system?.resourcesPath ?? ''),
			usesTemplates: false,
			documentTemplateAction: undefined,
			documentTemplatesIsVisible: false,
			documentTemplatesParams: undefined
		}, _vueContext)

		_merge(this, options || {})
	}

	/**
	 * Initialize the default handlers for Document component events
	 */
	initHandlers()
	{
		const handlers = {
			showTemplatesPopup: (eventData) => this.handleDocumentTemplates(eventData),
			documentTemplatesChoice: (eventData) => this.handleDocumentTemplatesChoice(eventData),
			documentTemplatesClose: (eventData) => this.handleDocumentTemplatesClose(eventData)
		}

		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	Init(isEditableForm)
	{
		super.Init(isEditableForm)

		this.SetTickets()
		this.initHandlers()

		if (!_isEmpty(this.valueChangeEvent) && this.vueContext.internalEvents)
			this.vueContext.internalEvents.on(this.valueChangeEvent, () => this.SetTickets())
	}

	SetTickets()
	{
		const baseArea = this.modelFieldRef.area
		const areaKeyField = this.vueContext.dataApi.keys[baseArea.toLowerCase()]

		const params = {
			TableName: baseArea,
			FieldName: this.modelFieldRef.originId,
			KeyValue: areaKeyField.value
		}

		netAPI.postData(baseArea, 'GetDocumsTickets', params, (data, request) => {
			if (request.data?.Success)
			{
				this.tickets = {}
				for (let i in data.tickets)
				{
					let t = data.tickets[i]
					this.tickets[t.id] = t.ticket
				}

				this.documentProperties.updateValue(data.properties)
				this.documentFK.updateValue(data.properties?.DocumId ?? '')
			}
			else
			{
				this.vueContext.$eventTracker.addError({
					origin: 'SetTickets (fieldControl)',
					message: `Error found while trying to retrieve the document tickets for field ${this.modelField}.`
				})
			}
		}, undefined, undefined, this.vueContext.navigationId)
	}

	GetVersionsInfo()
	{
		if (typeof this.tickets !== 'object')
			return

		const baseArea = this.modelFieldRef.area
		const params = {
			ticket: this.tickets.main
		}

		netAPI.postData(baseArea, 'GetDocumsVersionsDBEdit', params, (data) => {
			if (typeof data.Table !== 'object' || data.Table === null)
				return

			let elements = data.Table.Elements
			let rows = []

			for (let el of elements)
			{
				let createdOn = el.ValDatacria
				if (createdOn instanceof Date)
					createdOn = genericFunctions.dateToString(createdOn, this.vueContext.system.currentLang)

				const row = {
					id: el.ValCoddocums,
					fileName: el.ValNome,
					bytes: el.ValTamanho,
					author: el.ValOpercria,
					createdOn: createdOn,
					version: el.ValVersao
				}
				rows.push(row)
			}

			this.versionsInfo = rows
		}, undefined, undefined, this.vueContext.navigationId)
	}

	GetFileProperties()
	{
		if (typeof this.tickets !== 'object')
			return

		const baseArea = this.modelFieldRef.area
		const params = {
			ticket: this.tickets.main
		}

		netAPI.postData(baseArea, 'GetFileProperties', params, (data) => {
			this.fileProperties = {
				versionId: data.Coddocums,
				originalId: data.DocumId,
				author: data.Author,
				editor: data.CheckoutEditor,
				name: data.Name,
				size: data.Size,
				extension: data.FileType,
				createdDate: data.CreatedAt,
				currentVersion: data.Version
			}
		}, undefined, undefined, this.vueContext.navigationId)
	}

	SetFile(fileData)
	{
		if (typeof this.tickets !== 'object' || typeof fileData !== 'object')
			return

		const versionSubmitAction = {
			insert: 0,
			submit: 1,
			unlockFile: 2
		}

		var submitMode = versionSubmitAction.insert
		if (typeof fileData.isNewVersion === 'boolean')
		{
			if (fileData.isNewVersion)
				submitMode = versionSubmitAction.submit
			else
				submitMode = versionSubmitAction.unlockFile
		}

		const baseArea = this.modelFieldRef.area
		var params = {
			ticket: this.tickets.main,
			mode: submitMode,
			version: fileData.version || '1'
		}

		// Adds the binary of the attached document to the request.
		const fData = new FormData()
		const fileId = `${this.modelField}_file`
		fData.append(fileId, fileData.file)

		for (let i in params)
			fData.append(i, params[i])

		params = fData

		asyncProcM.AddBusy(netAPI.postData(baseArea, 'SetFile', params, (data) => {
			if (data.success)
			{
				this.documentProperties.updateValue(data.properties)
				this.documentFK.updateValue(data.properties.DocumId)
				this.modelFieldRef.updateValue(data.properties.Name)
			}
			else
				genericFunctions.displayMessage(data.message, 'error')
		},
		() => {},
		{ contentType: 'application/octet-stream' },
		this.vueContext.navigationId))
	}

	DeleteFile(deleteType)
	{
		if (typeof this.tickets !== 'object' || typeof deleteType !== 'number')
			return

		/*
			Delete types:
				0: Deletes the last version
				1: Deletes all versions except the last one
				2: Deletes the document and all it's versions
		*/
		if (![0, 1, 2].includes(deleteType))
			return

		const baseArea = this.modelFieldRef.area
		const params = {
			ticket: this.tickets.main,
			action: deleteType
		}

		netAPI.postData(baseArea, 'DeleteFile', params, (data) => {
			if (data.success)
			{
				this.documentProperties.updateValue(data.properties)
				this.documentFK.updateValue(data.properties.DocumId)
				this.modelFieldRef.updateValue(data.properties.Name)
				genericFunctions.displayMessage(this.vueContext.Resources[hardcodedTexts.fileDeleteSuccess], 'info')
			}
			else
				genericFunctions.displayMessage(data.message, 'error')
		}, undefined, undefined, this.vueContext.navigationId)
	}

	SetCheckoutState()
	{
		if (typeof this.tickets !== 'object')
			return

		const baseArea = this.modelFieldRef.area
		const params = {
			ticket: this.tickets.main
		}

		netAPI.postData(baseArea, 'CheckoutDocum', params, (data) => {
			if (data.success)
			{
				this.documentProperties.value = { ...this.documentProperties.value }
				this.documentProperties.value.IsCheckout = true
				this.DownloadFile()
			}
			else
				genericFunctions.displayMessage(data.message, 'error')
		}, undefined, undefined, this.vueContext.navigationId)
	}

	/**
	 * This function is responsible for downloading a file.
	 */
	DownloadFile()
	{
		// Here we use the GetFile function and specify that we want to download the file (hence viewType: print).
		this.GetFile({ viewType: qEnums.documentViewTypeMode.print })
	}

	/**
	 * Get the file from the server and display the file according to file view mode.
	 * @param {object} customArgs custom arg to override field mode, for example download button instead of clicking in the field
	 */
	GetFile(customArgs)
	{
		if (typeof this.tickets !== 'object')
			return

		var viewType = this.viewType

		// If the customArgs is defined, overrides the current model.
		if (customArgs?.viewType !== undefined && customArgs?.viewType !== null)
			viewType = customArgs.viewType

		const baseArea = this.modelFieldRef.area

		const newTab = viewType === qEnums.documentViewTypeMode.preview
		const params = {
			ticket: this.tickets.main,
			viewType
		}

		asyncProcM.AddBusy(netAPI.postData(baseArea, 'GetFile', params, (_, request) => {
			const fileName = request.headers.filename
			const fileType = request.headers.get('Content-Type')
			if (!fileName)
				return

			asyncProcM.AddBusy(netAPI.forceDownload(request.data, fileName, fileType, newTab))
		},
		() => {},
		{ responseType: 'arraybuffer' },
		this.vueContext.navigationId))
	}

	GetFileVersion(version)
	{
		if (typeof this.tickets !== 'object' || typeof version !== 'string')
			return

		if (!this.documentVersions[version])
			return

		const versionTicket = this.tickets[version]
		if (typeof versionTicket !== 'string')
			return

		const baseArea = this.modelFieldRef.area
		const params = {
			ticket: versionTicket
		}

		asyncProcM.AddBusy(netAPI.postData(baseArea, 'GetSpecificFile', params, (_, request) => {
			const fileName = request.headers.filename
			if (!fileName)
				return

			asyncProcM.AddBusy(netAPI.forceDownload(request.data, fileName))
		},
		() => {},
		{ responseType: 'arraybuffer' },
		this.vueContext.navigationId))
	}

	/**
	 * Handles the error and presents the user with useful information.
	 * @param {number} errorCode The error code
	 */
	HandleFileError(errorCode)
	{
		const extraInfo = {
			extensions: this.extensions,
			maxSize: this.maxFileSizeLabel
		}
		genericFunctions.handleFileError(errorCode, this.texts, extraInfo)
	}

	/**
	 * Handle the modal closing event
	 */
	handleDocumentTemplatesClose()
	{
		this.documentTemplatesIsVisible = false
		this.documentTemplatesParams = undefined
	}

	/**
	 * Handle the Key selection event.
	 * Download the file at the end if generated successfully.
	 */
	handleDocumentTemplatesChoice(selectedItem)
	{
		this.handleDocumentTemplatesClose()
		const baseArea = this.modelFieldRef.area

		if (_isEmpty(this.documentTemplateAction) || _isEmpty(selectedItem))
			return

		asyncProcM.AddBusy(netAPI.postData(baseArea, this.documentTemplateAction, { id: selectedItem }, (_, response) => {
			const fileName = response.headers.filename

			if (!fileName)
			{
				const contentType = response.headers['content-type']
				const erroMsg = this.vueContext.Resources[hardcodedTexts.errorProcessingRequest]

				if (contentType === 'application/json')
				{
					try
					{
						// Convert ArrayBuffer to a string
						const dataString = new TextDecoder().decode(response.data)
						// Convert string to a JSON
						const jsonData = JSON.parse(dataString)
						genericFunctions.displayMessage(jsonData?.Data?.message || erroMsg, 'error')
					}
					catch
					{
						genericFunctions.displayMessage(erroMsg, 'error')
					}
				}
				else
					genericFunctions.displayMessage(erroMsg, 'error')

				return
			}

			asyncProcM.AddBusy(netAPI.forceDownload(response.data, fileName))
		},
		() => {},
		{ responseType: 'arraybuffer' },
		this.vueContext.navigationId))
	}

	/**
	 * Handle the opening «Document Templates..» event
	 */
	handleDocumentTemplates()
	{
		this.documentTemplatesParams = {
			id: this.vueContext.primaryKeyValue,
			limits: this.getLimitsValues(),
			navigationId: this.vueContext.navigationId
		}
		this.documentTemplatesIsVisible = true
	}
}

/**
 * Image control
 */
export class ImageControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			type: 'Image',
			image: null,
			fullSizeImage: null,
			defaultImage: computed(() => `${_vueContext.system?.resourcesPath ?? ''}no_img.png`),
			extensions: ['.jpg', '.jpeg', '.png', '.gif', '.svg', '.webp', '.bmp'],
			isStatic: false,
			texts: new controlsResources.ImageResources(_vueContext.$getResource),
			isEmptyImage: false,
			imageWatcher: () => {}
		}, _vueContext)

		_merge(this, options || {})
	}

	get props()
	{
		const props = {
			...super.props,
			texts: this.texts,
			height: this.height,
			width: this.width,
			image: this.image,
			fullSizeImage: this.fullSizeImage,
			isEmptyImage: this.isEmptyImage
		}

		if (this.isStatic)
		{
			return {
				...props,
				readonly: true
			}
		}

		return {
			...props,
			extensions: this.extensions,
			isRequired: this.isRequired,
			maxFileSize: this.maxFileSize,
			popupIsVisible: this.popupIsVisible
		}
	}

	Init(isEditableForm)
	{
		super.Init(isEditableForm)

		if (this.isStatic)
			this.image = this.icon?.icon
		else
		{
			// Remove the previous watcher
			this.imageWatcher()
			this.imageWatcher = watch(() => this.modelFieldRef.value, (value) => (this.image = value || this.defaultImage), { immediate: true })
		}

		this.isEmptyImage = computed(() => {
			const image = this.isStatic ? this.icon?.icon : this.modelFieldRef.value
			return typeof image === 'string' && image.length === 0 || typeof image === 'object' && !image?.data
		})

		// If the field doesn't have an associated image, gets the default image.
		if (_isEmpty(this.image))
			this.image = this.defaultImage

		if (!this.isStatic)
			this.initHandlers()
	}

	/**
	 * Initialize the default handlers for Image component events
	 */
	initHandlers()
	{
		const handlers = {
			fileError: (event) => this.HandleFileError(event),
			openImagePreview: () => this.GetImage(),
			closeImagePreview: () => this.ClearPreview(),
			submitImage: (event) => this.SetImage(event),
			deleteImage: () => this.DeleteImage(),
			showPopup: (event) => this.SetModal(event),
			hidePopup: (event) => this.RemoveModal(event)
		}

		// Apply handlers without overriding. The handler can come from outside at initialization.
		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	/**
	 * Clears the image preview.
	 */
	ClearPreview()
	{
		this.fullSizeImage = null
	}

	/**
	 * Retrieves the ID of the record, according to the type of the image field.
	 * @returns The ID of the record to which the image belongs.
	 */
	GetId()
	{
		if (this.dependentModelField)
			return this.vueContext.model[this.dependentModelField].value
		return this.vueContext.primaryKeyValue
	}

	/**
	 * Gets the image from the server.
	 * @param {string} id The ID of the record
	 * @param {boolean} isPreview If true, it will get full-sized image, otherwise it will be resized to fit the component
	 * @param {boolean} isGetDefault If true, the model won't be updated (used when to get the default image when the model value is empty)
	 */
	GetImage(id, isPreview, isGetDefault)
	{
		// If it's a static image, it will always be in the client-side, the server won't even know of it's existence.
		// If the field is dirty, it means the full-sized image is already client-side, since it was just uploaded by the user.
		if (this.isStatic || this.modelFieldRef.isDirty)
		{
			this.fullSizeImage = this.image
			return
		}

		if (typeof id !== 'string')
			id = this.GetId()

		if (typeof isPreview !== 'boolean')
			isPreview = true

		if (typeof isGetDefault !== 'boolean')
			isGetDefault = false

		const baseArea = this.modelFieldRef.area
		const field = this.modelFieldRef.originId
		const model = _capitalize(this.dbArea)

		const params = {
			id: id,
			modelname: model,
			fldname: field,
			formIdentifier: `F${this.vueContext.formInfo.name}`,
			nocache: Math.floor(Math.random() * 100000)
		}

		// If the image should be reduced, adds the max height and width to the params.
		if (!isPreview)
		{
			params.height = this.height
			params.width = this.width
		}

		this.componentOnLoadProc.AddWL(netAPI.retrieveImage(baseArea, params, (data) => {
			if (isPreview)
				this.fullSizeImage = data
			else
			{
				this.image = data
				if (!isGetDefault)
					this.modelFieldRef.updateValue(data)
			}
		}))
	}

	/**
	 * Sets a new image.
	 * @param {object} imgData The image file data
	 */
	SetImage(imgData)
	{
		if (typeof imgData !== 'object')
			return

		this.modelFieldRef.updateValue(imgData)
		this.image = imgData
		this.fullSizeImage = null
	}

	/**
	 * Deletes the image.
	 */
	DeleteImage()
	{
		this.modelFieldRef.updateValue(null)
		this.image = this.defaultImage
		this.fullSizeImage = null
	}

	/**
	 * Handles the error and presents the user with useful information.
	 * @param {number} errorCode The error code
	 */
	HandleFileError(errorCode)
	{
		const extraInfo = {
			extensions: this.extensions,
			maxSize: this.maxFileSizeLabel
		}
		genericFunctions.handleFileError(errorCode, this.texts, extraInfo)
	}
}

/**
 * Manual Filling Image control
 */
export class ManualFillingImageControl extends ImageControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			type: 'ManualFillingImage',
			image: null,
			fullSizeImage: null,
			defaultImage: computed(() => `${_vueContext.system?.resourcesPath ?? ''}no_img.png`),
			isStatic: true,
			texts: new controlsResources.ImageResources(_vueContext.$getResource)
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * Groupbox control
 */
export class GroupControl extends NonBlockableControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			type: 'Group',
			anchoredChildren: [],
			isInAccordion: false,
			parent: computed(() => this.container || this.tab)
		}, _vueContext)

		_merge(this, options || {})
	}

	Init(isEditableForm)
	{
		super.Init(isEditableForm)

		this.initHandlers()

		this.isRequired = computed(() => {
			if (!this.vueContext.isEditable)
				return false
			if (this.mustBeFilled)
				return true

			for (let i in this.vueContext.controls)
			{
				const control = Reflect.get(this.vueContext.controls, i)
				if (this.id === control.container && control.isRequired)
					return true
			}

			return false
		})

		if (this.isCollapsible)
		{
			this.isOpen = false

			if (typeof this.parentOpeningEvent === 'string')
			{
				// If there's a collapsible group inside another collapsible group or tab, re-emits the event when the parent opens
				this.vueContext.internalEvents.on(this.parentOpeningEvent, () => {
					if (this.isOpen && typeof this.openingEvent === 'string')
						this.vueContext.internalEvents.emit(this.openingEvent)
				})
			}
		}
	}

	/**
	 * Initialize the default handlers for List component events
	 */
	initHandlers()
	{
		const handlers = {
			stateChanged: (eventData) => this.SetState(eventData)
		}

		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	SetState(state)
	{
		if (!this.isCollapsible || this.isInAccordion || typeof state !== 'boolean')
			return

		this.isOpen = state

		if (state && typeof this.openingEvent === 'string')
			this.vueContext.internalEvents.emit(this.openingEvent)
	}
}

/**
 * Accordion control
 */
export class AccordionControl extends NonBlockableControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			type: 'Accordion'
		}, _vueContext)

		_merge(this, options || {})
	}

	Init(isEditableForm)
	{
		super.Init(isEditableForm)

		this.initHandlers()
	}

	/**
	 * Initialize the default handlers for List component events
	 */
	initHandlers()
	{
		const handlers = {
			setOpenGroup: (state, groupId) => this.SetOpenGroup(state, groupId)
		}

		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	SetOpenGroup(state, changedGroupId)
	{
		for (let groupId of this.vueContext.groupFields)
		{
			const collapsibleGroup = this.vueContext.controls[groupId]

			if (collapsibleGroup.container === this.id)
			{
				const current = collapsibleGroup.id === changedGroupId
				collapsibleGroup.isOpen = current && state

				if (collapsibleGroup.isOpen && typeof collapsibleGroup?.openingEvent === 'string')
					this.vueContext.internalEvents.emit(collapsibleGroup.openingEvent)
			}
		}
	}
}

/**
 * Timeline control
 */
export class TimelineControl extends TableListControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			type: 'Timeline',
			hydrate: listFunctions.hydrateTimelineData,
			timeLineData: {
				rows: []
			},
			config: {
				scale: '',
				dateTimeFormat: computed(() => _vueContext.system?.dateFormat?.DateTime)
			},
			texts: new controlsResources.TimelineResources(_vueContext.$getResource)
		}, _vueContext)

		_merge(this, options || {})
	}

	/**
	 * Reloads the data of the timeline
	 */
	Reload()
	{
		return this.componentOnLoadProc.AddWL(this.vueContext.fetchTimelineData(this))
	}
}

/**
 * Button control
 */
export class ButtonControl extends NonBlockableControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Button'
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * Tab control
 */
export class TabControl extends NonBlockableControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Tab'
		}, _vueContext)

		_merge(this, options || {})
	}

	Init(isEditableForm)
	{
		super.Init(isEditableForm)

		this.isRequired = computed(() => {
			if (!this.vueContext.isEditable)
				return false
			if (this.mustBeFilled)
				return true

			for (let i in this.vueContext.controls)
			{
				const control = Reflect.get(this.vueContext.controls, i)
				if (this.id === control.tab && control.isRequired)
					return true
			}

			return false
		})
	}
}

/**
 * Tabs control
 */
export class TabsControl
{
	constructor(options, _vueContext)
	{
		this.vueContext = _vueContext

		// Init default values of control properties
		this.type = 'Tabs'
		this.tabControlsIds = []
		this.tabsList = []
		this.selectedTab = ''
		this.isVisible = false
		this.tabWatcher = () => {}

		_merge(this, options || {})
	}

	Init()
	{
		this.tabsList.splice(0)

		_forEach(this.tabControlsIds, (tabControlId) => {
			let tabControl = Reflect.get(this.vueContext.controls, tabControlId)
			this.tabsList.push(tabControl)

			if (_isEmpty(this.selectedTab) && tabControl.isVisible && !tabControl.isBlocked)
				this.SelectTab(tabControl.id)

			if (typeof tabControl.parentOpeningEvent === 'string')
			{
				// If there's a tab inside another tab or collapsible group, re-emits the event when the parent opens
				this.vueContext.internalEvents.on(tabControl.parentOpeningEvent, () => {
					if (tabControl.isVisible && typeof tabControl.openingEvent === 'string')
						this.vueContext.internalEvents.emit(tabControl.openingEvent)
				})
			}
		})

		this.isVisible = computed(() => _some(this.tabsList, { isVisible: true }))

		// Remove the previous watcher
		this.tabWatcher()
		// If the current tab becomes hidden, selects the first visible tab, if any.
		this.tabWatcher = watch(() => this.tabsList, () => {
			const currentTab = this.vueContext.controls[this.selectedTab]

			if (!_isEmpty(currentTab) && currentTab.isVisible && !currentTab.isBlocked)
				return

			this.SelectFirstTab()
		},
		{ deep: true, immediate: true })
	}

	SelectFirstTab()
	{
		for (let tab of this.tabsList)
		{
			if (!tab.isVisible || tab.isBlocked)
				continue

			this.SelectTab(tab.id)
			return
		}
	}

	SelectTab(tabId)
	{
		this.selectedTab = tabId ?? ''

		if (typeof tabId === 'string')
		{
			const tab = this.vueContext.controls[tabId]
			if (typeof tab.openingEvent === 'string')
				this.vueContext.internalEvents.emit(tab.openingEvent)
		}
		else
			this.SelectFirstTab()
	}
}

/**
 * Subform control
 */
export class SubformControl extends NonBlockableControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Subform'
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * Container control for nested forms
 */
export class FormContainerControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			targetTableListId: null,
			supportForm: {
				name: null,
				component: null,
				mode: 'SHOW',
				fnKeySelector: () => null
			},
			formData: null,
			isDirty: false,
			fnOnRowChange: undefined,
			nestedFormConfig: new NestedFormConfig({
				uiComponents: {
					header: true
				}
			}),
			allowFormActions: {
				show: true,
				edit: true,
				duplicate: true,
				delete: true,
				insert: true
			},
			rowComponentProps: {
				formButtonsOverride: null
			},
			resourcesPath: computed(() => _vueContext.system?.resourcesPath ?? ''),
			texts: new controlsResources.FormContainerResources(_vueContext.$getResource)
		}, _vueContext)

		_merge(this, options || {})

		this.initHeaderButtons()
	}

	Init(isEditableForm)
	{
		super.Init(isEditableForm)

		this.initHandlers()

		if (this.targetTableListId && this.vueContext.internalEvents)
			this.vueContext.internalEvents.on('on-table-row-selected', (eventData) => (this.targetTableListId === eventData.tableId) ? this.handleRowSelected(eventData.row) : null)
	}

	initHandlers()
	{
		const handlers = {
			afterSaveForm: (eventData) => this.onAfterSaveForm(eventData),
			changeFormMode: (eventData) => this.onChangeFormMode(eventData),
			close: (eventData) => this.onClose(eventData),
			closedForm: (eventData) => this.onClosedForm(eventData),
			customEvent: (eventData) => this.onCustomEvent(eventData),
			isFormDirty: (eventData) => this.onIsFormDirty(eventData)
		}

		// Apply handlers without overriding. The handler can come from outside at initialization.
		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	/**
	 * Init the buttons shown in the header accordingly to the user access rights choice
	 */
	initHeaderButtons()
	{
		this.rowComponentProps.formButtonsOverride = {
			confirmBtn: { isActive: false },
			saveBtn: { isActive: true },
			changeToShow: { isActive: this.allowFormActions.show },
			changeToEdit: { isActive: this.allowFormActions.edit },
			changeToDuplicate: { isActive: this.allowFormActions.duplicate },
			changeToDelete: { isActive: this.allowFormActions.delete },
			changeToInsert: { isActive: this.allowFormActions.insert }
		}
	}

	onAfterSaveForm()
	{
		this.isDirty = false
		if (this.vueContext.internalEvents)
			this.vueContext.internalEvents.emit('reload-list', { controlId: this.targetTableListId })
	}

	onChangeFormMode(mode)
	{
		if (!_isEmpty(this.formData))
			this.formData.mode = mode
	}

	onClose(eventData)
	{
		if (eventData.type === 'cancel' || eventData.type === 'delete')
		{
			this.setFormData(null)
			this.onClosedForm()
		}
	}

	onClosedForm()
	{
		if (this.vueContext.internalEvents)
			this.vueContext.internalEvents.emit('closed-extended-support-form', { controlId: this.targetTableListId })
	}

	onCustomEvent(eventData)
	{
		if (this.vueContext.internalEvents)
			this.vueContext.internalEvents.emit('ctrl-custom-event', { id: this.id, data: eventData })
	}

	onIsFormDirty(eventData)
	{
		this.isDirty = eventData.isDirty
		if (this.vueContext.internalEvents) {
			this.vueContext.internalEvents.emit('is-table-control-dirty', eventData)
		}
		// re-emit through all nested form layers until the main form, except after saving (only the saved nested form is now valid - not the others above)
		if (this.vueContext.isNested && !eventData.afterFormSave) {
			this.vueContext.$emit('is-form-dirty', { isDirty: eventData.isDirty, afterFormSave: eventData.afterFormSave })
		}
	}

	async handleRowSelected(row)
	{
		if (row)
		{
			if (typeof this.fnOnRowChange === 'function')
				await Promise.resolve(this.fnOnRowChange(row))

			let id = this.supportForm.fnKeySelector(row)
			if (_isEmpty(id) && this.supportForm.mode !== 'NEW')
				this.destroy()
			else
			{
				let formData = {
					historyBranchId: this.vueContext.navigationId,
					isNested: true,
					form: this.supportForm.name,
					mode: this.supportForm.mode,
					component: this.supportForm.component,
					modes: '',
					id
				}
				this.setFormData(formData)
			}
		}
	}

	setFormData(formData)
	{
		this.formData = formData
	}

	destroy()
	{
		super.destroy()
		this.setFormData(null)
	}
}

/**
 * Configuration of the nested forms
 */
export class NestedFormConfig
{
	constructor(options)
	{
		this.uiComponents = {
			header: false,
			headerButtons: true,
			footer: true
		}

		_merge(this, options || {})
	}
}

/**
 * The Grid Table List control
 */
export class GridTableListControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			type: 'GridTableList',
			config: {
				name: '',
				tableTitle: undefined,
				formName: undefined,
				resourcesPath: computed(() => _vueContext.system?.resourcesPath ?? '')
			},
			permissions: {
				canDelete: true,
				canInsert: true
			},
			columns: [],
			dataAlreadyRequested: false,
			data: undefined,
			gridWatcher: () => {},
			texts: new controlsResources.TableListMainResources(_vueContext.$getResource)
		}, _vueContext)

		_merge(this, options || {})

		this.config.formName = this.id
		this.config.tableTitle = this.label
	}

	get EmptyRows()
	{
		return this.modelFieldRef.EmptyRows
	}

	/**
	 * Initializes the necessary properties.
	 * @param {boolean} isEditableForm Whether or not the control is editable
	 */
	Init(isEditableForm)
	{
		super.Init(isEditableForm)

		this.data = computed(() => this.modelFieldRef.value)
		const canInsert = this.permissions.canInsert !== false

		// Remove the previous watcher
		this.gridWatcher()
		this.gridWatcher = watch([() => this.loaded, () => this.EmptyRows, () => this.readonly], () => {
			// Create an empty row if there is none,
			// the grid is editable and inserting rows is allowed
			if (canInsert && !this.EmptyRows.length && !this.readonly)
				this.addNewModel()
			// Ensure editable grids only have one empty row,
			// and readonly grids display no empty rows
			else if (this.EmptyRows.length > 0)
				this.trimEmptyRows()
		})

		this.initHandlers()
		this.initEvents()
	}

	/**
	 * Initialize the default handlers for List component events
	 */
	initHandlers()
	{
		const handlers = {
			addNewRow: () => this.addNewModel(),
			markForDeletion: (row) => this.markForDeletion(row),
			undoDeletion: (row) => this.undoDeletion(row)
		}

		// Apply handlers without overriding. The handler can come from outside at initialization.
		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	/**
	 * Initialization of listeners for events on which functions such as content reloading depend
	 */
	initEvents()
	{
		listFunctions.initTableEvents(this)
	}

	addNewModel()
	{
		if (this.modelFieldRef)
			this.modelFieldRef.addNewModel()
	}

	/**
	 * Runs after each time the table finishes loading
	 */
	afterLoaded()
	{
		const field = this.modelFieldRef
		formFunctions.setValuesFromStore(field, this.vueContext)
	}

	trimEmptyRows()
	{
		if (this.modelFieldRef)
			this.modelFieldRef.trimEmptyRows(this.readonly)
	}

	markForDeletion(row)
	{
		if (this.modelFieldRef)
			this.modelFieldRef.markForDeletion(row)
	}

	undoDeletion(row)
	{
		if (this.modelFieldRef)
			this.modelFieldRef.undoDeletion(row)
	}

	hydrate(_, listViewModel)
	{
		this.modelFieldRef.hydrate(listViewModel)
	}

	Reload()
	{
		return this.componentOnLoadProc.AddWL(this.vueContext.fetchListData(this))
	}
}

/**
 * Wizard control
 */
export class WizardControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Wizard',
			wizardData: {
				currentStep: computed(() => _vueContext.currentStepIndex),
				selectedStep: computed(() => _vueContext.selectedStepIndex),
				currentPath: [],
				texts: new controlsResources.WizardResources(_vueContext.$getResource)
			},
			dataWatcher: () => {}
		}, _vueContext)

		_merge(this, options || {})
	}

	/**
	 * Initializes the event handlers.
	 */
	initHandlers()
	{
		const handlers = {
			stepClicked: (...args) => this.vueContext.handleStepChange(...args)
		}

		_assignInWith(this.handlers, handlers, (objValue, srcValue) =>
			_isUndefined(objValue) ? srcValue : objValue
		)
	}

	/**
	 * Initializes the necessary properties.
	 * @param {boolean} isEditableForm Whether or not the control is editable
	 */
	Init(isEditableForm)
	{
		super.Init(isEditableForm)

		this.initHandlers()

		this.isRequired = computed(() => {
			if (!this.vueContext.isEditable)
				return false
			if (this.mustBeFilled)
				return true

			for (let controlId of this.wizardData.stepFieldIds || [])
			{
				const control = Reflect.get(this.vueContext.controls, controlId)
				if (control.isRequired)
					return true
			}

			return false
		})

		this.wizardData.currentPath = this.vueContext.wizardPath

		// Remove the previous watcher
		this.dataWatcher()
		this.dataWatcher = watch(() => this.vueContext.wizardData, () => _merge(this.wizardData, this.vueContext.wizardData || {}), { deep: true, immediate: true })
	}
}

export default {
	BaseControl,
	StringControl,
	TextEditorControl,
	PasswordControl,
	BooleanControl,
	NumberControl,
	CurrencyControl,
	DateControl,
	TimeControl,
	ArrayStringControl,
	ArrayNumberControl,
	ArrayBooleanControl,
	CoordinatesControl,
	MaskControl,
	LookupControl,
	TableListControl,
	TreeTableListControl,
	MultipleValuesControl,
	MultipleValuesExtensionControl,
	DocumentControl,
	ManualFillingImageControl,
	ImageControl,
	TimelineControl,
	GroupControl,
	AccordionControl,
	ButtonControl,
	TabControl,
	TabsControl,
	SubformControl,
	FormContainerControl,
	NestedFormConfig,
	GridTableListControl,
	WizardControl,
	...getSpecialRenderingControls(BaseControl, TableListControl)
}
