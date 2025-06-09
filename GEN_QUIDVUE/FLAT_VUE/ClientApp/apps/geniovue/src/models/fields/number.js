import _assignIn from 'lodash-es/assignIn'
import _toNumber from 'lodash-es/toNumber'
import { computed } from 'vue'

import { useSystemDataStore } from '@/stores/systemData.js'
import genericFunctions from '@/mixins/genericFunctions'
import { Base } from './base'

export class Number extends Base {
	static EMPTY_VALUE = 0

	constructor(options) {
		const systemDataStore = useSystemDataStore()

		super(
			_assignIn(
				{
					type: 'Number',
					maxDigits: -1,
					decimalDigits: 0,
					maxIntegers: -1,
					maxDecimals: -1,
					decimalSeparator: computed(
						() => systemDataStore.system.numberFormat.decimalSeparator
					),
					groupSeparator: computed(
						() => systemDataStore.system.numberFormat.thousandsSeparator
					)
				},
				options
			)
		)
	}

	/**
	 * @override
	 */
	get displayValue() {
		const value = _toNumber(this.value)
		if (isNaN(value)) return ''
		return genericFunctions.numericDisplay(
			value.toFixed(this.decimalDigits),
			this.decimalSeparator,
			this.groupSeparator
		)
	}

	/**
	 * @override
	 */
	sanitizeValue(value) {
		const sanitizedVal = super.sanitizeValue(value)
		return _toNumber(sanitizedVal)
	}

	/**
	 * @override
	 */
	validateValue() {
		return super.validateValue() && (this.isRequired ? !isNaN(_toNumber(this.value)) : true)
	}

	/**
	 * @override
	 */
	isValidType(value) {
		return !isNaN(value)
	}
}
