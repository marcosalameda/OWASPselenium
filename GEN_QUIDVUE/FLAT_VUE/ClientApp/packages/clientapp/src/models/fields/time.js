import _assignIn from 'lodash-es/assignIn'
import _isEmpty from 'lodash-es/isEmpty'

import { timeToString } from '../../utils/genericFunctions'
import { Base } from './base'

export class Time extends Base {
	static EMPTY_VALUE = '__:__'

	constructor(options) {
		super(
			_assignIn(
				{
					type: 'Time',
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
			if (_isEmpty(this.value)) return ''

			const [start, end] = this.value
			return `${timeToString(start)} - ${timeToString(end)}`
		}

		if (_isEmpty(super.displayValue) || super.displayValue === Time.EMPTY_VALUE) return ''

		return timeToString(this.value)
	}

	/**
	 * @override
	 */
	get serverValue() {
		if (this.isRange) {
			if (_isEmpty(this.value) || this.value[0] === Time.EMPTY_VALUE || this.value[1] === Time.EMPTY_VALUE) return []

			return this.value
		}

		return this.value !== Time.EMPTY_VALUE ? this.value : null
	}

	/**
	 * @override
	 */
	hydrate(rawDataFieldValue) {
		// Ensure instance-specific empty value representation
		// (convert '' to '__:__')
		if (_isEmpty(rawDataFieldValue)) rawDataFieldValue = this.isRange ? [] : Time.EMPTY_VALUE

		super.hydrate(rawDataFieldValue)
	}

	/**
	 * @override
	 */
	isValidType(value) {
		if (this.isRange) {
			// Validate as a time range
			if (Array.isArray(value) && value.length === 2) {
				const [start, end] = value
				return (typeof start === 'object' || typeof start === 'string' || start === null) &&
					(typeof end === 'object' || typeof end === 'string' || end === null)
			}
			return _isEmpty(value)
		} else {
			// Validate as a single time
			return typeof value === 'object' || typeof value === 'string' || value === null
		}
	}

	/**
	 * @override
	 */
	sanitizeValue(value) {
		const sanitizedVal = super.sanitizeValue(value)
		const sanitizeTime = (time) => typeof time === 'object' ? (time ? timeToString(time) : '') : time

		if (this.isRange) {
			if (_isEmpty(sanitizedVal)) return []

			const [start, end] = sanitizedVal
			return [sanitizeTime(start), sanitizeTime(end)]
		}

		return sanitizeTime(sanitizedVal)
	}
}
