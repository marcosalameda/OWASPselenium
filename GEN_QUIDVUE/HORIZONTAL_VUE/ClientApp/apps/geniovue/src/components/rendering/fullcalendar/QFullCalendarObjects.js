import _get from 'lodash-es/get'
import _has from 'lodash-es/has'
import _isEmpty from 'lodash-es/isEmpty'
import _isPlainObject from 'lodash-es/isPlainObject'
import _isUndefined from 'lodash-es/isUndefined'
import _omitBy from 'lodash-es/omitBy'
import _unionBy from 'lodash-es/unionBy'

import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'

/**
 * Event class for FullCalendar v5.
 */
export class EventObject
{
	/**
	 * Create a new EventObject.
	 *
	 * @param {Object} options - EventObject options.
	 * @param {string} options.id - A unique identifier of an event. Useful for getEventById.
	 * @param {string} [options.groupId] - Events that share a groupId will be dragged and resized together automatically.
	 * @param {boolean} [options.allDay] - Determines if the event is shown in the "all-day" section of relevant views. If true, the time text is not displayed with the event.
	 * @param {Date} [options.start] - Date object that obeys the current timeZone. When an event begins.
	 * @param {Date} [options.end] - Date object that obeys the current timeZone. When an event ends. It could be null if an end wasn't specified.
	 * @param {string} [options.startStr] - An ISO8601 string representation of the start date. If the event is all-day, there will not be a time part.
	 * @param {string} [options.endStr] - An ISO8601 string representation of the end date. If the event is all-day, there will not be a time part.
	 * @param {string} [options.title] - The text that will appear on an event.
	 * @param {Array} [options.classNames=[]] - An array of strings determining which HTML classNames will be attached to the rendered event.
	 * @param {boolean|null} [options.editable=false] - The value overriding the editable setting for this specific event.
	 * @param {string} [options.isBackground=false] - Logical field that represents if the event is a background event.
	 * @param {string} [options.color] - An alias for specifying the backgroundColor and borderColor at the same time.
	 * @param {Object} [options.extendedProps={}] - A plain object holding miscellaneous other properties specified during parsing.
	 * @param {Object} [options.resourceId] - Uniquely identifies of the resource. Event Objects with a corresponding resourceId field will be linked to this event.
	 */
	constructor({
		id,
		groupId,
		allDay,
		start,
		end,
		startStr,
		endStr,
		title,
		classNames = [],
		editable = false,
		isBackground = false,
		color,
		extendedProps = {},
		resourceId
	} = {})
	{
		this.id = id
		this.groupId = groupId
		this.allDay = allDay
		this.start = start
		this.end = end
		this.startStr = startStr
		this.endStr = endStr
		this.title = title
		this.classNames = Array.isArray(classNames) ? classNames : []
		this.editable = editable
		this.resizable = true
		this.isBackground = isBackground
		this.display = isBackground ? 'background' : null
		this.color = color
		this.extendedProps = extendedProps
		this.resourceId = resourceId

		this.textColor = genericFunctions.getReadableTextColor(this.color)
	}

	/**
	 *
	 * @param {Object} mappedValue The Special rendering mapped row values
	 */
	mapValues(mappedValue)
	{
		this.id = _get(mappedValue, 'rowKey', undefined)
		this.title = _get(mappedValue, 'eventTitle.rawData', '')
		this.description = _get(mappedValue, 'eventDescription.rawData', this.title)
		this.start = _get(mappedValue, 'eventStart.rawData', undefined)
		this.end = _get(mappedValue, 'eventEnd.rawData', undefined)
		this.allDay = _get(mappedValue, 'eventAllDay.rawData', false)
		this.color = _get(mappedValue, 'eventColor.rawData')

		this.textColor = genericFunctions.getReadableTextColor(this.color)

		this.isBackground = _get(mappedValue, 'eventIsBackground.rawData', false)
		this.display = this.isBackground ? 'background' : null

		//if the resource has a 3-Level Grouping, the id of the event must be linked to the children instead of the resource
		this.resourceId = _get(mappedValue, 'eventGroup3Id.rawData', _get(mappedValue, 'eventResourceId.rawData'))
	}

	getOnlyDefinedOptions()
	{
		return _omitBy(this, _isUndefined)
	}
}

/**
 * Resource class for FullCalendar v5.
 */
export class ResourceObject
{
	/**
	 * Create a new Resource.
	 *
	 * @param {Object} options - Resource options.
	 * @param {string} options.id - Uniquely identifies this resource. Events with a corresponding resourceId field will be linked to this resource.
	 * @param {string} [options.title=''] - Text that will be displayed on the resource when it is rendered.
	 * @param {string} [options.groupId] - .
	 * @param {string} [options.groupLabel] - .
	 * @param {Array} [options.children=[]] - Child resources.
	 * @param {Object} [options.extendedProps={}] - A hash of non-standard props that were specified during parsing.
	 */
	constructor({ id, title = '', groupId, groupLabel, children = [], extendedProps = {} } = {})
	{
		this.id = id
		this.title = title
		this.groupId = groupId
		this.groupLabel = groupLabel
		this.children = Array.isArray(children) ? children : []

		this.extendedProps = _isPlainObject(extendedProps) ? extendedProps : {}
	}

	get hasChildren()
	{
		return _isEmpty(this.children) === false
	}

	/**
	 *
	 * @param {Object} mappedValue The Special rendering mapped row values
	 */
	mapValues(mappedValue)
	{
		this.id = _get(mappedValue, 'eventResourceId.rawData', undefined)
		this.title = _get(mappedValue, 'eventResourceTitle.rawData', '')

		if (_has(mappedValue, 'eventGroup2Id'))
		{
			this.groupId = _get(mappedValue, 'eventGroup2Id.rawData')
			this.groupLabel = _get(mappedValue, 'eventGroup2Title.rawData', '')
		}

		if (_has(mappedValue, 'eventGroup3Id'))
		{
			let childGr3 = new ResourceObject({
				id: _get(mappedValue, 'eventGroup3Id.rawData'),
				title: _get(mappedValue, 'eventGroup3Title.rawData', '')
			})
			this.children.push(childGr3.getOnlyDefinedOptions())
		}
	}

	unionChilds(otherResource)
	{
		this.children = _unionBy(this.children, otherResource.children, 'id')
	}

	getOnlyDefinedOptions()
	{
		return _omitBy(this, _isUndefined)
	}
}

export default {
	ResourceObject,
	EventObject
}
