import { reactive, watch, ref, computed } from 'vue'
import { v4 as uuidv4 } from 'uuid'
import _remove from 'lodash-es/remove'
import _forEach from 'lodash-es/forEach'

import eventBus from '@/api/global/eventBus.js'

/**
 * Ensure that no process hangs in the "busy states" list after being collapsed by the GC.
 * For example, in the case of redirect with two menus in a row (skip if only one).
 */
// eslint-disable-next-line no-undef
const registry = new FinalizationRegistry(processId => {
	eventBus.emit('remove-process-from-busy-page-stack', processId)
})

export class QAsyncProcess
{
	/**
	 * The asynchronous process to be monitored
	 * @param {Promise} cbPromise The «Promise» object of the process
	 * @param {Boolean} loadingEffect The process cause the effect of «Loading ...»
	 * @param {Number} loadingEffectDelay The delay time for the loading effect to appear (milliseconds)
	 */
	constructor(cbPromise, loadingEffect, loadingEffectDelay, busyState, busyStateMessage)
	{
		this.id = uuidv4()
		this.cbPromise = cbPromise
		this.hasLoadingEffect = loadingEffect || false
		this.loadingEffectDelay = this.hasLoadingEffect ? (loadingEffectDelay || 0) : 0
		this.busyState = busyState || false
		this.busyStateMessage = busyStateMessage
		this.timestamp = Date.now()
		this.concluded = ref(false)

		let fnCallback = (() => {
			this.concluded.value = true
			eventBus.emit('remove-process-from-busy-page-stack', this.id)
		}).bind(this)

		Promise.resolve(this.cbPromise).then(fnCallback, fnCallback)

		/**
		 * Internal property, just to dispatch change event / watch effect
		 */
		this._dispatchChange = ref(0)
		if (this.loadingEffectDelay > 0)
		{
			setTimeout((() => {
				if (this.busyState === true && this.concluded.value === false)
					eventBus.emit('add-process-to-busy-page-stack', { id: this.id, message: this.busyStateMessage })
				this._dispatchChange.value += 1
			}).bind(this), this.loadingEffectDelay)
		}
		else if (this.busyState)
			eventBus.emit('add-process-to-busy-page-stack', { id: this.id, message: this.busyStateMessage })

		registry.register(this, this.id, this)
	}

	get loadingEffect()
	{
		return this.hasLoadingEffect === true && (this.loadingEffectDelay === 0 || Date.now() > (this.timestamp + this.loadingEffectDelay))
	}

	destroy()
	{
		eventBus.emit('remove-process-from-busy-page-stack', this.id)
		registry.unregister(this)
	}
}

function AddBusy(cbPromise, busyStateMessage)
{
	return reactive(new QAsyncProcess(cbPromise, true, 1000, true, busyStateMessage))
}

class QAsyncProcessList
{
	constructor()
	{
		this.processes = []
	}

	get hasAny()
	{
		return this.processes.length !== 0
	}

	get allLoaded()
	{
		return !this.processes.some(proc => {
			return proc.concluded === false && proc.loadingEffect === true
		})
	}

	get allConcluded()
	{
		return !this.processes.some(proc => {
			return proc.concluded === false
		})
	}

	addProcess(proc)
	{
		var reactiveProc = reactive(proc)
		this.processes.push(reactiveProc)
		return reactiveProc
	}

	destroy()
	{
		_forEach(this.processes, proc => proc.destroy())
		this.processes.splice(0, this.processes.length)
	}
}

class QAsyncProcessCallback
{
	constructor(callback, context, args)
	{
		this.callback = callback
		this.context = context || null
		this.args = args || []
		this.fired = false
	}

	run()
	{
		if (!this.fired)
			this.callback.apply(this.context || null, this.args || [])
		this.fired = true
		this.clearMemory()
	}

	clearMemory()
	{
		this.callback = undefined
		this.context = undefined
		this.args = undefined
	}
}

class QAsyncProcessMonitor
{
	constructor(identifier, defaultValueLoaded)
	{
		this.id = identifier
		this.uuid = uuidv4()
		this.eventName = `${this.id}_${this.uuid}_LOADING_PROC_CONCLUDED`
		this.processList = reactive(new QAsyncProcessList())
		/** List of callbakc to be execute */
		this.callbacksOnce = ref([])
		/** Indicates if all the processes are completed */
		this._defaultValueLoaded = typeof defaultValueLoaded === 'boolean' ? defaultValueLoaded : true
		// Tracks changes in the list of processes and re-evaluates whether there are any pending processes
		this.loaded = computed(() => {
			if (!this.processList.hasAny)
				return this._defaultValueLoaded
			else
				return this.processList.allLoaded
		})

		watch(this.processList, () => {
			if (this.processList.allConcluded)
			{
				eventBus.emit(this.eventName, this)
				_remove(this.callbacksOnce.value, cb => {
					cb.run()
					return true
				})
			}
		}, { deep: true })
	}

	/**
	 * Add the process to the list of processes to be monitored
	 * @param {Promise} cbPromise The «Promise» object of the process
	 * @param {Boolean} loadingEffect The process cause the effect of «Loading ...»
	 * @param {Number} loadingEffectDelay The delay time for the loading effect to appear (milliseconds)
	 */
	Add(cbPromise, loadingEffect, loadingEffectDelay, busyState, busyStateMessage)
	{
		return this.processList.addProcess(new QAsyncProcess(cbPromise, loadingEffect, loadingEffectDelay, busyState, busyStateMessage)).cbPromise
	}

	/**
	 * Add the process that cause the effect of «Loading ...» to the list of processes to be monitored
	 * @param {Promise} _cbPromise The «Promise» object of the process
	 * @param {Number} loadingEffectDelay The delay time for the loading effect to appear (milliseconds)
	 */
	AddWL(cbPromise, loadingEffectDelay)
	{
		return this.Add(cbPromise, true, loadingEffectDelay)
	}

	AddBusy(cbPromise, busyStateMessage, loadingEffectDelay)
	{
		return this.Add(cbPromise, true, typeof loadingEffectDelay === 'number' ? loadingEffectDelay : 1000, true, busyStateMessage)
	}

	AddImmediateBusy(cbPromise, busyStateMessage)
	{
		return this.AddBusy(cbPromise, busyStateMessage, 0)
	}

	/**
	 * Perform a callback as soon as it has finished loading.
	 * @param {callback} callback Callback to be executed
	 * @param {any} context The context of the function
	 * @param {Array} args Additional arguments (opcional)
	 */
	Once(callback, context, args)
	{
		let cb = new QAsyncProcessCallback(callback, context, args)
		this.callbacksOnce.push(cb)

		// // To ensure that the event was not triggered while the callback was being registered
		// setTimeout(() => {
		// 	if (this.loaded)
		// 		cb.run()
		// }, 3000)
	}

	destroy()
	{
		this.processList.destroy()
	}
}

/**
 * Creates a Vue.js Reactive object that makes it possible to monitoring the completion of asynchronous methods
 * @param {String} identifier Identifier of the monitoring process
 * @param {Boolean} defaultValueLoaded Default value of loading process
 * @returns Vue.js Reactive object with property that indicates if all the processes are completed
 */
function getProcListMonitor(identifier, defaultValueLoaded)
{
	return reactive(new QAsyncProcessMonitor(identifier, defaultValueLoaded))
}

export default {
	getProcListMonitor,
	AddBusy
}