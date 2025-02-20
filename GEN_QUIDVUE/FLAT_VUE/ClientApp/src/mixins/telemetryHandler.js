import netAPI from '@/api/network'
import { WarningEvent, ErrorEvent } from './tracingEvents'

export class TelemetryHandler
{
	/**
	 * Base constructor
	 */
	constructor(enableTracing = false)
	{
		this.eventQueue = []
		this.batchInterval = 30000
		this.isSending = false
		this.enableTracing = enableTracing

		this.startBatching()
	}

	/**
	 * Register a trace
	 * @param {object} event ResponseEvent or RequestEvent
	 */
	registerTrace(event)
	{
		if (!this.enableTracing)
			return

		const params = {
			telemetryType: 'Trace',
			...event
		}

		this.addToQueue(params)
	}

	/**
	 * Register a log
	 * @param {object} event WarningEvent or ErrorEvent
	 */
	registerLog(event)
	{
		let telemetryType = 'InfoLog'
		if (event instanceof WarningEvent)
			telemetryType = 'WarningLog'
		else if (event instanceof ErrorEvent)
			telemetryType = 'ErrorLog'

		const params = {
			telemetryType,
			...event
		}

		this.addToQueue(params)
	}

	/**
	 * Add an event to the queue
	 * @param {object} event
	 */
	addToQueue(event)
	{
		this.eventQueue.push(event)
	}

	/**
	 * Send batched events to the backend
	 */
	async sendBatch()
	{
		if (this.eventQueue.length === 0 || this.isSending)
			return

		this.isSending = true
		const eventsToSend = [...this.eventQueue]
		this.eventQueue = [] // Clear the queue before sending to avoid duplication

		try
		{
			await netAPI.postData(
				'InternalProcess',
				'RegisterTelemetry',
				{ events: eventsToSend },
				(data) => {
					// eslint-disable-next-line no-console
					console.log('Batch sent successfully:', data)
				},
				undefined,
				{ skipTracing: true })
		}
		catch (error)
		{
			// eslint-disable-next-line no-console
			console.error('Failed to send telemetry batch:', error)

			// Add events back into the queue if sending fails
			this.eventQueue = [...eventsToSend, ...this.eventQueue]
		}
		finally
		{
			this.isSending = false
		}
	}

	/**
	 * Start the batching process
	 */
	startBatching()
	{
		setInterval(() => this.sendBatch(), this.batchInterval)
	}
}

export default {
	TelemetryHandler
}
