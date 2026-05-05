import { computed, unref } from 'vue'
import _find from 'lodash-es/find'
import _forEach from 'lodash-es/forEach'
import _some from 'lodash-es/some'

import CustomControl from './baseControl.js'
import CalendarResources from './resources/calendarResources.js'

import { useSystemDataStore } from '@quidgest/clientapp/stores'

import { dateToISOString } from '@quidgest/clientapp/utils/genericFunctions'

/**
 * Calendar control
 */
export default class CalendarControl extends CustomControl
{
	constructor(controlContext, controlOrder)
	{
		super(controlContext, controlOrder)

		// Initialize the default handlers for Calendar component events
		this.handlers = {
			eventClick: (eventData) => this.onEventClick(eventData),
			eventDrop: (eventData) => this.onDrop(eventData),
			eventResize: (eventData) => this.onResize(eventData),
			eventDropped: (eventData) => this.onDropped(eventData),
			eventDateSelect: (eventData) => this.onDateSelect(eventData),
			eventDateClick: (eventData) => this.onDateClick(eventData),
			eventAction: (eventData) => this.onEventAction(eventData)
		}

		this.texts = new CalendarResources(controlContext.vueContext.$getResource)

		const systemDataStore = useSystemDataStore()
		/**
		 * Sets the height of the view area of the calendar[https://fullcalendar.io/docs/schedulerLicenseKey]
		 * GPL-My-Project-Is-Open-Source
		 */
		this.controlContext.config.schedulerLicenseKey = computed(() => systemDataStore.system.schedulerLicense)

		// Calendar language
		this.controlContext.config.locale = computed(() => systemDataStore.system.currentLang)
	}

	/**
	 * Get the properties for configuring the calendar component.
	 * @param {object} viewMode - The current view mode of the calendar.
	 * @returns {object} - An object containing calendar properties.
	 */
	getProps(viewMode)
	{
		return {
			id: viewMode.containerId,
			readonly: computed(() => viewMode.readonly),
			/*
			 * The FullCalendar control are poorly represented if the initial rendering was when that control was invisible.
			 * The 'isVisible' flag is needed to know that the control needs to be re-rendered.
			 */
			isVisible: computed(() => this.controlContext.isVisible),
			mappedValues: viewMode.mappedValues,
			styleVariables: viewMode.styleVariables,
			mappingVariables: viewMode.mappingVariables,
			listConfig: this.controlContext.config
		}
	}

	/**
	 * Hydrates all values whose mapping variable's format is different from the one used in the component
	 * @param {object} viewMode The current view mode
	 */
	hydrateValues(viewMode)
	{
		if (typeof viewMode.customMappedValues === 'function')
		{
			let customMappedValues = viewMode.customMappedValues(viewMode)
			_forEach(customMappedValues, (customMappedValue) => viewMode.mappedValues.push(customMappedValue))
		}
	}

	onEventAction(eventData)
	{
		if (typeof this.controlContext.onTableListExecuteAction === 'function')
			this.controlContext.onTableListExecuteAction(eventData)
	}

	onEventClick(eventData)
	{
		// Check if the click was on a background event. If it was then does nothing.
		if (eventData.display === 'background')
			return

		if (this.controlContext.vueContext.internalEvents)
		{
			this.controlContext.vueContext.internalEvents.emit(`controlEvent:${this.controlContext.id}`, {
				type: 'event-click',
				data: eventData
			})
		}
	}

	onDateClick(eventData)
	{
		if (this.controlContext.vueContext.internalEvents)
		{
			this.controlContext.vueContext.internalEvents.emit(`controlEvent:${this.controlContext.id}`, {
				type: 'date-click',
				data: eventData
			})
		}

		const calendarOptions = {
			...eventData.parameters,
			selectedDate: dateToISOString(eventData.parameters.selectedDate)
		}

		// Set Navigaiton data
		if (typeof this.controlContext.vueContext.setEntryValue === 'function')
		{
			this.controlContext.vueContext.setEntryValue({
				navigationId: this.controlContext.vueContext?.navigationId,
				key: 'CalendarOptions',
				value: calendarOptions
			})
		}

		// Insert action
		if (unref(this.controlContext.readonly) === false
			&& typeof this.controlContext.onTableListExecuteAction === 'function'
			&& _some(this.controlContext.config.generalActions, { name: 'insert' }))
		{
			let insertAction = _find(this.controlContext.config.generalActions, { name: 'insert' })
			this.controlContext.onTableListExecuteAction({ action: insertAction })
		}
	}

	/**
	 * This is called when an external draggable element has been dropped onto the calendar IT'S CALLED BEFORE EVENTRECEIVE
	 * @param {Object} eventData
	 */
	onDropped(eventData)
	{
		this.resDropped = eventData.resource.id
	}

	/**
	 * Not yet supported
	 */
	onDateSelect(/*eventData*/)
	{
	}

	/*
	_fnDragDrop(eventData, parameters, isResize)
	{
		if (_some(this.controlContext.config.crudActions, { name: 'edit' }))
		{
			let formName = _find(this.controlContext.config.crudActions, { name: 'edit' }).params.formName
			netAPI.postData(this.controlContext.controller, `${formName}_Calendario`, parameters, null, data => {
				if (data.success)
					genericFunctions.displayMessage(isResize ? this.texts.successfulEventEdit : this.texts.successfulEventMove)
				else
				{
					genericFunctions.displayMessage(this.texts.errorProcessingRequest)
					eventData.revert()
				}
			}, () => {
				genericFunctions.displayMessage(this.texts.errorProcessingRequest)
				eventData.revert()
			}, undefined, this.controlContext.vueContext.navigationId)
		}
		else
			eventData.revert()
	}

	_fnMoveOrDuplicate(eventData, parameters)
	{
		let buttons = []

		// Edit => Move
		// Actions reorganized in order to other follow all actions displacement throughout the application
		if (_some(this.controlContext.config.crudActions, { name: 'edit' }))
		{
			let formName = _find(this.controlContext.config.crudActions, { name: 'edit' }).params.formName
			buttons.push({
				label: this.texts.move,
				callback: () => {
					netAPI.postData(this.controlContext.controller, `${formName}_Calendario`, parameters, null, data => {
						if (data.success)
							genericFunctions.displayMessage(this.texts.successfulEventMove)
						else {
							genericFunctions.displayMessage(this.texts.errorProcessingRequest)
							eventData.revert()
						}
					}, () => {
						genericFunctions.displayMessage(this.texts.errorProcessingRequest)
						eventData.revert()
					}, undefined, this.controlContext.vueContext.navigationId)
				}
			})
		}

		// Duplicate
		if (_some(this.controlContext.config.crudActions, { name: 'duplicate' }))
		{
			let formName = _find(this.controlContext.config.crudActions, { name: 'duplicate' }).params.formName
			buttons.push({
				label: this.texts.duplicate,
				callback: () => {
					netAPI.postData(this.controller, `${formName}_Calendario_Duplicate`, parameters, null, data => {
						if (data.success)
						{
							genericFunctions.displayMessage(this.texts.successfulDuplication)
							this.Reload()
						}
						else
						{
							genericFunctions.displayMessage(this.texts.errorProcessingRequest)
							eventData.revert()
						}
					}, () => {
						genericFunctions.displayMessage(this.texts.errorProcessingRequest)
						eventData.revert()
					}, undefined, this.controlContext.vueContext.navigationId)
				}
			})
		}

		// Cancel
		buttons.push({
			label: this.texts.cancel,
			callback: () => eventData.revert()
		})

		// TODO: Show popup
	}
	*/

	onDrop(eventData)
	{
		eventData.revert()
		return

		/*
		let hasNewResource = !(eventData.oldResource === null && eventData.newResource === null)

		if (this.hasChildren && hasNewResource && eventData.newResource._resource.parentId === '')
			genericFunctions.displayMessage(this.texts.errorOnlyEventsLastLevel, 'warning')
		else
		{
			if (this.hasChildren && hasNewResource && eventData.newResource._resource.parentId === '')
			{
				genericFunctions.displayMessage(this.texts.errorOnlyEventsLastLevel, 'warning')
				eventData.revert()
			}
			else
			{
				// Checks if new event collides with the original event:
				let collides = false,
					dateTimeINI = eventData.event.start,
					dateTimeFIM = eventData.event.end,
					oldDateTimeINI = eventData.oldEvent.start,
					oldDateTimeFIM = eventData.oldEvent.end,
					parameters = {
						id: eventData.event.id,
						dateTimeINI: eventData.event.start,
						dateTimeFIM: eventData.event.end,
						isScheduler: this.isScheduler,
						hasNewResource: hasNewResource,
						resourceId: this.isScheduler && hasNewResource ? eventData.newResource.id : '',
						hasChildren: this.hasChildren,
						noDates: this.noDates
					}

				// Collides if New INI falls into old period
				if ((dateTimeINI.getTime() < oldDateTimeFIM.getTime() && dateTimeINI.getTime() > oldDateTimeINI.getTime()))
					collides = true

				// Collides if New FIM falls into old period
				if ((dateTimeFIM.getTime() < oldDateTimeFIM.getTime() && dateTimeFIM.getTime() > oldDateTimeINI.getTime()))
					collides = true

				// If it collides with eventsOverlap turned off it cannot be duplicated, thus leaving just one option that is to move (change) the original event
				if (collides && !this.eventsOverlap)
				{
					if (_some(this.controlContext.config.crudActions, { name: 'edit' }))
					{
						let formName = _find(this.controlContext.config.crudActions, { name: 'edit' }).params.formName

						genericFunctions.displayMessage(this.texts.doMoveEvent, 'question', null, {
							confirm: {
								label: this.texts.yes,
								action: () => {
									netAPI.postData(this.controlContext.controller, `${formName}_Calendario`, parameters, null, data => {
										if (data.success)
											genericFunctions.displayMessage(this.texts.successfulEventMove)
										else {
											genericFunctions.displayMessage(this.texts.errorProcessingRequest)
											eventData.revert()
										}
									}, () => {
										genericFunctions.displayMessage(this.texts.errorProcessingRequest)
										eventData.revert()
									}, undefined, this.controlContext.vueContext.navigationId)
								}
							},
							cancel: {
								label: this.texts.cancel,
								action: () => eventData.revert()
							}
						})
					}
				}
				else
					this._fnMoveOrDuplicate(eventData, parameters)
			}
		}
		*/
	}

	onResize(eventData)
	{
		eventData.revert()
		return

		/*
		let hasNewResource = !(eventData.oldResource === null && eventData.newResource === null)

		if (this.hasChildren && hasNewResource && eventData.newResource._resource.parentId === '')
			genericFunctions.displayMessage(this.texts.errorOnlyEventsLastLevel, 'warning')
		else if (this.hasChildren && hasNewResource && eventData.newResource._resource.parentId === '')
		{
			genericFunctions.displayMessage(this.texts.errorOnlyEventsLastLevel, 'warning')
			eventData.revert()
		}
		else if (_some(this.controlContext.config.crudActions, { name: 'edit' }))
		{
			let parameters = {
				id: eventData.event.id,
				dateTimeINI: eventData.event.start,
				dateTimeFIM: eventData.event.end,
				isScheduler: this.isScheduler,
				hasNewResource: hasNewResource,
				resourceId: (this.isScheduler && hasNewResource) ? eventData.newResource.id : '',
				hasChildren: this.hasChildren,
				noDates: this.noDates
			},
			formName = _find(this.controlContext.config.crudActions, { name: 'edit' }).params.formName

			genericFunctions.displayMessage(this.texts.doEditEvent, 'question', null, {
				confirm: {
					label: this.texts.yes,
					action: () => {
						netAPI.postData(this.controlContext.controller, `${formName}_Calendario`, parameters, null, data => {
							if (data.success)
								genericFunctions.displayMessage(this.texts.successfulEventEdit)
							else
							{
								genericFunctions.displayMessage(this.texts.errorProcessingRequest)
								eventData.revert()
							}
						}, () => {
							genericFunctions.displayMessage(this.texts.errorProcessingRequest)
							eventData.revert()
						}, undefined, this.controlContext.vueContext.navigationId)
					}
				},
				cancel: {
					label: this.texts.cancel,
					action: () => eventData.revert()
				}
			})
		}
		*/
	}
}
