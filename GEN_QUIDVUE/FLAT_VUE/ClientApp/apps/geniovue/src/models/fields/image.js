import _assignIn from 'lodash-es/assignIn'

import genericFunctions from '@/mixins/genericFunctions'
import { Base } from './base'

export class Image extends Base {
	constructor(options) {
		super(
			_assignIn(
				{
					type: 'Image'
				},
				options
			)
		)
	}

	/**
	 * @override
	 */
	isValidType(value) {
		return genericFunctions.validateImageFormat(value)
	}
}
