import _assignIn from 'lodash-es/assignIn'

import { useSystemDataStore } from '@/stores/systemData.js'
import { DateTime } from './dateTime'

export class DateTimeSeconds extends DateTime {
	constructor(options) {
		const systemDataStore = useSystemDataStore()

		super(
			_assignIn(
				{
					type: 'DateTimeSeconds',
					dateFormat: systemDataStore.system.dateFormat.dateTimeSeconds
				},
				options
			)
		)
	}
}
