import _assignIn from 'lodash-es/assignIn'

import { useGenericDataStore } from '../../stores/genericData'
import { dateDisplay, dateToISOString, isDate, isEmpty } from '../../utils/genericFunctions'
import { Base } from './base'

export class Date extends Base {
	static EMPTY_VALUE = ''

	constructor(options) {
		const genericDataStore = useGenericDataStore()

		super(
			_assignIn(
				{
					type: 'Date',
					dateFormat: genericDataStore.dateFormat.date,
					isRange: false
				},
				options
			)
		)
	}

	/**
	 * @override
	 */
	get displayValue() {
		if (this.isRange) {
			if (isEmpty(this.value)) return ''

			const [start, end] = this.value
			return `${dateDisplay(start, this.dateFormat)} - ${dateDisplay(end, this.dateFormat)}`
		}
		return dateDisplay(this.value, this.dateFormat)
	}

	/**
	 * @override
	 */
	get serverValue() {
		if (this.isRange) {
			if (isEmpty(this.value)) return []

			const [start, end] = this.value
			return [dateToISOString(start), dateToISOString(end)]
		}
		return dateToISOString(this.value)
	}

	/**
	 * @override
	 */
	isValidType(value) {
		if (this.isRange) {
			// Validate as a date range.
			if (Array.isArray(value) && value.length === 2) {
				const [start, end] = value
				return (isDate(start) && !isNaN(start)) &&
					(isDate(end) && !isNaN(end)) &&
					start.getTime() <= end.getTime()
			}
			return isEmpty(value)
		} else {
			// Validate as a single date.
			return (isDate(value) && !isNaN(value)) || isEmpty(value)
		}
	}

	/**
	 * @override
	 */
	sanitizeValue(value) {
		const sanitizedVal = super.sanitizeValue(value)

		if (isEmpty(sanitizedVal)) return this.constructor.EMPTY_VALUE

		if (this.isRange) {
			const [start, end] = sanitizedVal
			return [new window.Date(window.Date.parse(start)), new window.Date(window.Date.parse(end))]
		}
		return new window.Date(window.Date.parse(sanitizedVal))
	}
}
