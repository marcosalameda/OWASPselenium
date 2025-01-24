import { QEventEmitter } from '@/api/global/eventBus.js'

class ConditionSource
{
	/**
	 * Creates a new condition source.
	 * @param {string} id The id of the source
	 * @param {function} condition The condition to determine whether the source is active
	 * @param {string|array} eventIds An event to listen for, or a list of events
	 * @param {QEventEmitter} events The event emitter
	 * @param {boolean} isMet The default value to use when no condition is provided
	 */
	constructor(id, condition, eventIds, events, isMet)
	{
		if (!['undefined', 'function'].includes(typeof condition))
			throw new Error('The "condition" must be a function.')
		if (!['undefined', 'string'].includes(typeof eventIds) && !Array.isArray(eventIds))
			throw new Error('The "eventIds" must be either a string or an array of strings.')
		if (typeof eventIds !== 'undefined' && typeof events === 'undefined')
			throw new Error('When defining "eventIds", the "events" must also be defined.')

		const eventList = Array.isArray(eventIds) ? eventIds : eventIds ? [eventIds] : []
		const condFunc = typeof condition === 'function' ? condition : () => isMet

		this.id = id
		this.condition = condFunc
		this.isMet = isMet
		this.observers = []

		if (eventList.length > 0)
			events?.onMany(eventList, () => this.validateCondition())
	}

	/**
	 * Factory function to create new condition sources.
	 * @param {string} sourceId The id of the source
	 * @param {function} condition The condition to determine whether the source is active
	 * @param {string|array} eventIds An event to listen for, or a list of events
	 * @param {QEventEmitter} events The event emitter
	 * @param {boolean} isMet The default value to use when no condition is provided
	 * @returns A new condition source.
	 */
	static async createSource(sourceId, condition, eventIds, events, isMet)
	{
		const source = new ConditionSource(sourceId, condition, eventIds, events, isMet)
		await source.validateCondition()
		return source
	}

	/**
	 * Validates the source condition.
	 */
	async validateCondition()
	{
		// Force a conversion to boolean for cases where the condition is returning 1 or 0.
		this.isMet = await this.condition() ? true : false
		this.notify()
	}

	/**
	 * Adds observer function to observers array.
	 * @param {function} fn The observer function to add
	 */
	addObserver(fn)
	{
		this.observers.push(fn)
	}

	/**
	 * Notifies all observer functions in observers array.
	 */
	notify()
	{
		this.observers.forEach((fn) => fn())
	}
}

/**
 * Base class for a generic condition stack, should be extended by specific classes.
 */
class ConditionStack
{
	/**
	 * Creates a new condition stack.
	 * @param {QEventEmitter} events The event emitter
	 * @param {string} fieldId The identifier of the associated field
	 * @param {boolean} isMet The value to check for whether a condition is met
	 */
	constructor(events, fieldId, isMet = true)
	{
		Object.defineProperties(this, {
			metConditions: {
				value: [],
				configurable: true,
				writable: true,
				enumerable: false
			},
			sources: {
				value: {},
				configurable: true,
				writable: false,
				enumerable: false
			},
			otherStacks: {
				value: [],
				configurable: true,
				writable: false,
				enumerable: false
			},
			internalEvents: {
				value: new QEventEmitter,
				configurable: true,
				writable: false,
				enumerable: false
			},
			globalEvents: {
				value: undefined,
				configurable: true,
				writable: true,
				enumerable: false
			},
			fieldId: {
				value: undefined,
				configurable: true,
				writable: true,
				enumerable: false
			},
			isMet: {
				value: isMet,
				configurable: true,
				writable: false,
				enumerable: false
			},
			sourceAddEvt: {
				value: 'source-added',
				configurable: true,
				writable: false,
				enumerable: false
			},
			sourceRemoveEvt: {
				value: 'source-removed',
				configurable: true,
				writable: false,
				enumerable: false
			}
		})

		if (typeof events !== 'undefined')
			this.setEventEmitter(events)
		if (typeof fieldId !== 'undefined')
			this.setFieldId(fieldId)
	}

	/**
	 * The number os currently active conditions in the stack.
	 */
	get size()
	{
		return this.metConditions.length + this.otherStacks.reduce((res, s) => res + s.size, 0)
	}

	/**
	 * Whether any of the conditions in the stack are met.
	 */
	get anyMet()
	{
		return this.size > 0
	}

	/**
	 * Sets the identifier of the associated field.
	 * @param {string} fieldId The identifier of the associated field
	 */
	setFieldId(fieldId)
	{
		if (typeof fieldId !== 'string')
			throw new Error('The "fieldId" argument should be a string.')
		this.fieldId = fieldId
	}

	/**
	 * Sets the global event emitter.
	 * @param {QEventEmitter} events The event emitter
	 */
	setEventEmitter(events)
	{
		if (!(events instanceof QEventEmitter))
			throw new Error('The "events" argument should be an instance of QEventEmitter.')
		this.globalEvents = events
	}

	/**
	 * Associates another stack to this one, this means the "anyMet" property will
	 * take into account whether that stack also has any met conditions.
	 * @param {ConditionStack} stack The stack to associate
	 */
	associateStack(stack)
	{
		if (!(stack instanceof ConditionStack))
			throw new Error('The "stack" argument should be an instance of ConditionStack.')

		stack.internalEvents.on(this.sourceAddEvt, () => {
			if (!this.fieldId)
				this.internalEvents.emit(this.sourceAddEvt)
			else if (this.size === 1)
				this.globalEvents?.emit(this.constructor.ADD_EVENT, this.fieldId)
		})
		stack.internalEvents.on(this.sourceRemoveEvt, () => {
			if (!this.fieldId)
				this.internalEvents.emit(this.sourceRemoveEvt)
			else if (!this.anyMet)
				this.globalEvents?.emit(this.constructor.REMOVE_EVENT, this.fieldId)
		})

		this.otherStacks.push(stack)
	}

	/**
	 * Checks if the specified source is currently active.
	 * @param {string} sourceId The id of the source
	 * @returns True if the specified source is currently active, false otherwise.
	 */
	contains(sourceId)
	{
		return this.metConditions.includes(sourceId) || this.otherStacks.some((s) => s.contains(sourceId))
	}

	/**
	 * Updates the stack with the condition sources currently active.
	 */
	updateStack()
	{
		const previousLength = this.metConditions.length

		this.metConditions = Object.entries(this.sources)
			.filter(([, value]) => value.isMet === this.isMet)
			.map(([key]) => key)

		// A source was added.
		if (previousLength < this.metConditions.length)
		{
			if (this.size === 1)
			{
				this.internalEvents.emit(this.sourceAddEvt)
				if (this.fieldId)
					this.globalEvents?.emit(this.constructor.ADD_EVENT, this.fieldId)
			}
		}
		// A source was removed.
		else if (previousLength > this.metConditions.length)
		{
			if (!this.anyMet)
			{
				this.internalEvents.emit(this.sourceRemoveEvt)
				if (this.fieldId)
					this.globalEvents?.emit(this.constructor.REMOVE_EVENT, this.fieldId)
			}
		}
	}

	/**
	 * Adds a new condition source to the stack.
	 * @param {string} sourceId The id of the source
	 * @param {function} condition The condition to determine whether the source is active
	 * @param {string|array} eventIds An event to listen for, or a list of events
	 * @returns True if the source was successfully added, or false if it already existed in the stack.
	 */
	async add(sourceId, condition, eventIds)
	{
		if (typeof sourceId !== 'string' || sourceId.length === 0)
			throw new Error('An invalid source was specified, the value should be a string.')

		if (sourceId in this.sources)
			return false

		const source = await ConditionSource.createSource(sourceId, condition, eventIds, this.globalEvents, this.isMet)
		source.addObserver(() => this.updateStack())
		this.sources[sourceId] = source
		this.updateStack()

		return true
	}

	/**
	 * Removes an existing condition source from the stack.
	 * @param {string} sourceId The id of the source
	 * @returns True if the source was successfully removed, or false if it didn't exist in the stack.
	 */
	remove(sourceId)
	{
		if (typeof sourceId !== 'string' || sourceId.length === 0)
			throw new Error('An invalid source was specified, the value should be a string.')

		if (!(sourceId in this.sources))
			return false

		delete this.sources[sourceId]
		this.updateStack()

		return true
	}
}

/**
 * Class for the "Block when" condition stack.
 */
export class BlockConditionStack extends ConditionStack
{
	static ADD_EVENT = 'field-blocked'
	static REMOVE_EVENT = 'field-unblocked'

	constructor(events, fieldId)
	{
		super(events, fieldId)
	}
}

/**
 * Class for the "Fill when" condition stack.
 */
export class FillConditionStack extends ConditionStack
{
	static ADD_EVENT = BlockConditionStack.ADD_EVENT
	static REMOVE_EVENT = BlockConditionStack.REMOVE_EVENT

	constructor(events, fieldId)
	{
		super(events, fieldId, false)
	}
}

/**
 * Class for the "Show when" condition stack.
 */
export class HideConditionStack extends ConditionStack
{
	static ADD_EVENT = 'field-hidden'
	static REMOVE_EVENT = 'field-shown'

	constructor(events, fieldId)
	{
		super(events, fieldId, false)
	}
}

/**
 * Class for the required condition stack.
 */
export class RequiredConditionStack extends ConditionStack
{
	static ADD_EVENT = 'field-required'
	static REMOVE_EVENT = 'field-not-required'

	constructor(events, fieldId)
	{
		super(events, fieldId)
	}
}
