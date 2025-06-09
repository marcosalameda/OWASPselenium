import _assignIn from 'lodash-es/assignIn'

import genericFunctions from '@/mixins/genericFunctions'
import { Base } from './base'

export class String extends Base {
	static EMPTY_VALUE = ''

	constructor(options) {
		super(
			_assignIn(
				{
					type: 'String',
					maxLength: -1
				},
				options
			)
		)
	}

	/**
	 * @override
	 */
	sanitizeValue(value) {
		const sanitizedVal = super.sanitizeValue(value)

		if (genericFunctions.isEmpty(sanitizedVal)) return this.constructor.EMPTY_VALUE

		return sanitizedVal
	}

	/**
	 * @override
	 */
	validateSize() {
		if (this.maxLength > 0) {
			const length = this.value?.length ?? 0
			return length <= this.maxLength
		}
		return true
	}

	/**
	 * @override
	 */
	isValidType(value) {
		return typeof value === 'string' || genericFunctions.isEmpty(value)
	}
}
