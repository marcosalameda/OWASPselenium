import _assignIn from 'lodash-es/assignIn'

import { useSystemDataStore } from '@/stores/systemData.js'
import { Date } from './date'

export class DateTime extends Date {
	constructor(options) {
		const systemDataStore = useSystemDataStore()

		super(
			_assignIn(
				{
					type: 'DateTime',
					dateFormat: systemDataStore.system.dateFormat.dateTime
				},
				options
			)
		)
	}
}
