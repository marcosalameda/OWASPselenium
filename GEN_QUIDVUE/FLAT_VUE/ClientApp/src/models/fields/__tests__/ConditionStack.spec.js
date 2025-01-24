import { nextTick } from 'vue'

import { QEventEmitter } from '@/api/global/eventBus.js'
import { BlockConditionStack, FillConditionStack, HideConditionStack, RequiredConditionStack } from '@/models/fields/conditionStack.js'

const testId = 'test_id',
	testSource = 'test_source',
	testEvt = 'test_event'

describe('ConditionStack', () => {
	let events

	beforeEach(() => {
		events = new QEventEmitter()
	})

	it.each([
		['block', 'unblocked', new BlockConditionStack()],
		['fill', 'unblocked', new FillConditionStack()],
		['hide', 'visible', new HideConditionStack()],
		['required', 'not required', new RequiredConditionStack()]
	])('Empty %s stack makes the field %s', (_, __, stack) => {
		expect(stack.size).toStrictEqual(0)
		expect(stack.anyMet).toStrictEqual(false)
	})

	it.each([
		['block', 'blocked', new BlockConditionStack()],
		['fill', 'blocked', new FillConditionStack()],
		['hide', 'hidden', new HideConditionStack()],
		['required', 'required', new RequiredConditionStack()]
	])('Non-empty %s stack makes the field %s', async (_, __, stack) => {
		await stack.add(testSource)
		expect(stack.size).toStrictEqual(1)
		expect(stack.anyMet).toStrictEqual(true)
	})

	it.each([
		['block', new BlockConditionStack()],
		['fill', new FillConditionStack()],
		['hide', new HideConditionStack()],
		['required', new RequiredConditionStack()]
	])('Adding the same %s source twice will only work the first time', async (_, stack) => {
		let result = await stack.add(testSource)
		expect(result).toStrictEqual(true)
		result = await stack.add(testSource)
		expect(result).toStrictEqual(false)
		expect(stack.size).toStrictEqual(1)
	})

	it.each([
		['blocked by a block source', BlockConditionStack.ADD_EVENT, new BlockConditionStack()],
		['blocked by a fill source', FillConditionStack.ADD_EVENT, new FillConditionStack()],
		['hidden', HideConditionStack.ADD_EVENT, new HideConditionStack()],
		['required', RequiredConditionStack.ADD_EVENT, new RequiredConditionStack()]
	])('When the field becomes %s, the "%s" event is emitted', async (_, eventId, stack) => {
		stack.setEventEmitter(events)
		stack.setFieldId(testId)

		let eventEmitted = false

		events.on(eventId, (fieldId) => {
			if (fieldId === testId)
				eventEmitted = true
		})

		await stack.add(testSource)
		expect(eventEmitted).toStrictEqual(true)
	})

	it.each([
		['unblocked by a block source', BlockConditionStack.REMOVE_EVENT, new BlockConditionStack()],
		['unblocked by a fill source', FillConditionStack.ADD_EVENT, new FillConditionStack()],
		['visible', HideConditionStack.REMOVE_EVENT, new HideConditionStack()],
		['not required', RequiredConditionStack.REMOVE_EVENT, new RequiredConditionStack()]
	])('When the field becomes %s, the "%s" event is emitted', async (_, eventId, stack) => {
		stack.setEventEmitter(events)
		stack.setFieldId(testId)

		let eventEmitted = false

		events.on(eventId, (fieldId) => {
			if (fieldId === testId)
				eventEmitted = true
		})

		await stack.add(testSource)
		expect(stack.anyMet).toStrictEqual(true)
		stack.remove(testSource)
		expect(stack.anyMet).toStrictEqual(false)
		expect(eventEmitted).toStrictEqual(true)
	})

	it.each([
		['block', BlockConditionStack.ADD_EVENT, new BlockConditionStack()],
		['fill', FillConditionStack.ADD_EVENT, new FillConditionStack()],
		['hide', HideConditionStack.ADD_EVENT, new HideConditionStack()],
		['required', RequiredConditionStack.ADD_EVENT, new RequiredConditionStack()]
	])('Even when adding various sources to a %s stack, the "%s" event is emitted only once', async (_, eventId, stack) => {
		stack.setEventEmitter(events)
		stack.setFieldId(testId)

		let emits = 0

		events.on(eventId, (fieldId) => {
			if (fieldId === testId)
				emits++
		})

		await stack.add(testSource)
		await stack.add(`${testSource}2`)
		await stack.add(`${testSource}3`)
		expect(stack.size).toStrictEqual(3)
		expect(emits).toStrictEqual(1)
	})

	it.each([
		['block', 'blocked', true, new BlockConditionStack()],
		['fill', 'blocked', false, new FillConditionStack()],
		['hide', 'hidden', false, new HideConditionStack()],
		['required', 'required', true, new RequiredConditionStack()]
	])('Adding a conditional source to a %s stack will make the field %s only when it evaluates to %s', async (_, __, isMet, stack) => {
		stack.setEventEmitter(events)

		await stack.add(testSource, () => !isMet, testEvt)

		expect(stack.size).toStrictEqual(0)
		expect(stack.anyMet).toStrictEqual(false)

		isMet = !isMet
		events.emit(testEvt)

		await nextTick()

		expect(stack.size).toStrictEqual(1)
		expect(stack.anyMet).toStrictEqual(true)
	})

	it.each([
		['block', 'blocked', BlockConditionStack.ADD_EVENT, () => new BlockConditionStack()],
		['fill', 'blocked', FillConditionStack.ADD_EVENT, () => new FillConditionStack()],
		['hide', 'hidden', HideConditionStack.ADD_EVENT, () => new HideConditionStack()],
		['required', 'required', RequiredConditionStack.ADD_EVENT, () => new RequiredConditionStack()]
	])('Having a stack associated to a %s stack will make the field %s even if that stack is empty', async (_, __, eventId, stackFactory) => {
		const stack1 = stackFactory()
		const stack2 = stackFactory()
		const stack3 = stackFactory()
		const stack4 = stackFactory()

		stack1.setEventEmitter(events)
		stack1.setFieldId(testId)
		stack2.setEventEmitter(events)
		stack3.setEventEmitter(events)
		stack4.setEventEmitter(events)

		stack1.associateStack(stack2)
		stack2.associateStack(stack3)
		stack2.associateStack(stack4)

		let emits = 0

		events.on(eventId, (fieldId) => {
			if (fieldId === testId)
				emits++
		})

		await stack3.add(testSource)
		await stack3.add(`${testSource}2`)
		await stack4.add(testSource)

		expect(stack4.size).toStrictEqual(1)
		expect(stack3.anyMet).toStrictEqual(true)
		expect(stack3.size).toStrictEqual(2)
		expect(stack3.anyMet).toStrictEqual(true)
		expect(stack2.size).toStrictEqual(3)
		expect(stack2.anyMet).toStrictEqual(true)
		expect(stack1.size).toStrictEqual(3)
		expect(stack1.anyMet).toStrictEqual(true)
		expect(emits).toStrictEqual(1)
	})
})
