import _assignIn from 'lodash-es/assignIn'

import { useSystemDataStore } from '@/stores/systemData.js'
import genericFunctions from '@/mixins/genericFunctions'
import { Base } from './base'

export class Date extends Base {
	static EMPTY_VALUE = ''

	constructor(options) {
		const systemDataStore = useSystemDataStore()

		super(
			_assignIn(
				{
					type: 'Date',
					dateFormat: systemDataStore.system.dateFormat.date
				},
				options
			)
		)
	}

	/**
	 * @override
	 */
	get displayValue() {
		return genericFunctions.dateDisplay(this.value, this.dateFormat)
	}

	/**
	 * @override
	 */
	get serverValue() {
		return genericFunctions.dateToISOString(this.value)
	}

	/**
	 * @override
	 */
	isValidType(value) {
		return (genericFunctions.isDate(value) && !isNaN(value)) || genericFunctions.isEmpty(value)
	}

	/**
	 * @override
	 */
	sanitizeValue(value) {
		const sanitizedVal = super.sanitizeValue(value)

		if (genericFunctions.isEmpty(sanitizedVal)) return this.constructor.EMPTY_VALUE

		return new window.Date(window.Date.parse(sanitizedVal))
	}
}
