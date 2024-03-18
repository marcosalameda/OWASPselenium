import { isValid } from 'date-fns'

const isoDateTimeFormat = /^(\d{4}-\d{2}-\d{2})[T](\d{2}:\d{2}:\d{2})(\.\d+)?([+-]\d{2}:?\d{2}|Z)?$/

function isIsoDateTimeString(value)
{
	return value && typeof value === 'string' && isoDateTimeFormat.test(value)
}

function parseISODateTime(value)
{
	if (value === '0001-01-01T00:00:00' || !isValid(new Date(value)))
		return ''

	const date = new Date(value)
	return new Date(Date.UTC(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate(), date.getUTCHours(), date.getUTCMinutes(), date.getUTCSeconds()))
}

export function handleDates(body)
{
	if (body === null || body === undefined || typeof body !== 'object')
		return body

	for (const key of Object.keys(body))
	{
		const value = body[key]
		if (isIsoDateTimeString(value))
			body[key] = parseISODateTime(value)
		else if (typeof value === 'object')
			handleDates(value)
	}
}
