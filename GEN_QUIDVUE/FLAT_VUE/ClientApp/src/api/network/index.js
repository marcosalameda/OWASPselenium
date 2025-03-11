import { v4 as uuidv4 } from 'uuid'
import _forEach from 'lodash-es/forEach'
import _isEmpty from 'lodash-es/isEmpty'
import _merge from 'lodash-es/merge'

import { useNavDataStore } from '@/stores/navData.js'
import { useSystemDataStore } from '@/stores/systemData.js'
import { useTracingDataStore } from '@/stores/tracingData.js'
import { displayMessage } from '@/mixins/genericFunctions.js'
import { documentViewTypeMode } from '@/mixins/quidgest.mainEnums.js'
import { useUserDataStore } from '@/stores/userData.js'
import asyncProcM from '@/api/global/asyncProcMonitoring.js'
import eventBus from '@/api/global/eventBus.js'
import axios from './axiosInstance'

const MAIN_HISTORY_BRANCH_ID = 'main'

/**
 * Returns a History structure in the format expected by the server
 * @param navigationId The Navigation context Id
 * @param {string} currentArea The area of the current history level
 * @returns Object with current history
 */
function getHistoryToSend(navigationId, currentArea = '')
{
	const navDataStore = useNavDataStore()

	navDataStore.beforeRequestContext(navigationId)
	return navDataStore.navigation.getHistory(navigationId).historyToSend(currentArea)
}

/**
 * Handles an error in the request.
 * @param {AxiosResponse} response Axios response object (data, status, statusText, headers, config, request?)
 * @param {Function} fnResolve The «promise resolve» function that will be resolved just after completely executing the request
 * @param {Callback} _fnCallback The request callback to be executed to process the data received from the server
 * @param {Error} error The request error object
 */
async function handleNonOkResponse(response, fnResolve, _fnCallback, error)
{
	if (response)
	{
		let responseData = response.data ?? {},
			data = responseData.Data ?? null,
			statusCode = responseData.statusCode ?? response.status,
			srvEventTracking = responseData.eTracker

		// Tracing event
		const tracing = useTracingDataStore()
		tracing.addWarning({
			origin: 'handleNonOkResponse',
			message: error?.message,
			contextData: {
				response,
				statusCode,
				error
			}
		})

		// Server errors
		if (srvEventTracking)
		{
			tracing.addServerErrors({
				errors: srvEventTracking,
				contextData: {
					requestType: response.config.method,
					requestUrl: response.config.url,
					requestParams: response.config.params,
					requestData: response.config.data
				}
			})
		}

		// Skip if only one, in addition to redirecting to the next one, may still need to load the list data.
		// This is necessary in case when the next hop is a form in PopUp or is a manual routine that doesn't leave the page.
		if (typeof _fnCallback === 'function' && data)
			await _fnCallback(data, response)

		switch (statusCode)
		{
			case 302:
				eventBus.emit('response-redirect-to', responseData)
				break
			case 403:
				eventBus.emit('response-redirect-to', { type: 'route', routeName: 'permissionError', routeValues: { errorMessage: responseData.message || 'Permission error (403)' } })
				break
			case 404:
				eventBus.emit('response-redirect-to', { type: 'route', routeName: 'notFound', routeValues: { errorMessage: responseData.message || 'Not found (404)' } })
				break
			case 500:
				eventBus.emit('response-redirect-to', { type: 'route', routeName: 'serverError', routeValues: {} })
				break
			default:
				tracing.addError({
					origin: 'handleNonOkResponse',
					message: 'REQUEST ERROR - No handler',
					contextData: {
						responseData,
						statusCode
					}
				})
		}

		fnResolve?.(data)
	}
	else
	{
		const tracing = useTracingDataStore()
		tracing.addError({
			origin: 'handleNonOkResponse',
			message: 'REQUEST ERROR',
			contextData: {
				response,
				error
			}
		})

		fnResolve?.(null)
	}

	// FIXME: Temporary workaround just to avoid infinitely calling "GetIfUserLogged" when itself fails.
	if (!response?.config.url.includes('GetIfUserLogged'))
		eventBus.emit('check-user-is-logged-in')
}

/**
 * Processing the Axios response.
 * @param {AxiosResponse} response Axios response object (data, status, statusText, headers, config, request?)
 * @param {Callback} _fnCallback The request callback to be executed to process the data received from the server
 * @param {Function} fnResolve The «promise resolve» function that will be resolved just after completely executed request
 * @param {boolean} skipTracing Wether to capture telemetry or not
 */
async function processRequest(response, _fnCallback, fnResolve, skipTracing)
{
	const tracing = useTracingDataStore()
	const userDataStore = useUserDataStore()

	if (response)
	{
		// If the initial PHE is empty but the key is still persistent, clean it and redirect to home page.
		if (response.data?.Data?.InitialPHEEmpty === true && typeof userDataStore.valuesOfPHEs[response.data.Data.Module] === 'object')
		{
			userDataStore.valuesOfPHEs[response.data.Data.Module] = undefined
			eventBus.emit('response-redirect-to', { type: 'route', routeName: `home-${response.data.Data.Module}`, routeValues: {} })
		}

		// Tracing event
		let traceId = response.config.meta?.traceId

		// The skip tracing is used here so the action that sends the
		// telemetry doesn't call itself over and over again infinitely
		if (!skipTracing)
		{
			traceId = tracing.addResponseTrace({
				traceId,
				origin: 'processRequest',
				requestType: response.config.method,
				requestUrl: response.config.url,
				requestParams: response.config.params,
				requestData: response.config.data,
				responseStatus: response.status,
				responseData: response.data,
				meta: response.config.meta
			})
		}

		if (response.status === 200)
		{
			const navDataStore = useNavDataStore()
			const systemDataStore = useSystemDataStore()

			let responseData = response.data ?? {},
				data = responseData.Data ?? null,
				statusCode = responseData.statusCode ?? 200,
				srvHistory = responseData.NavigationData ?? {},
				maintenance = responseData.Maintenance ?? {},
				navigationId = srvHistory.navigationId,
				history = srvHistory.historyDiff ?? null,
				srvEventTracking = responseData.eTracker

			// Server errors
			if (srvEventTracking)
			{
				tracing.addServerErrors({
					traceId,
					errors: srvEventTracking,
					contextData: {
						requestType: response.config.method,
						requestUrl: response.config.url,
						requestParams: response.config.params,
						requestData: response.config.data
					}
				})
			}

			systemDataStore.setMaintenanceStatus(maintenance)
			navDataStore.updateHistoryByServer({ navigationId, srvHistory: history })

			if (statusCode !== 200)
				handleNonOkResponse(response, fnResolve, _fnCallback)
			else if (_fnCallback)
			{
				Promise.resolve(_fnCallback(data, response))
					.then(() => fnResolve?.(data), () => fnResolve?.(data))
			}
			else
				fnResolve?.(data)
		}
	}
	else
	{
		// Tracing event
		tracing.addWarning({
			origin: 'processRequest',
			message: 'The response object is not defined.'
		})
	}
}

/**
 * Generate the relative URL for a Web API action
 * @param {string} controller The controller name
 * @param {string} action The action name
 * @returns Relative URL for a Web API action
 */
export function apiActionURL(controller, action)
{
	const systemDataStore = useSystemDataStore()
	const year = systemDataStore.system.currentSystem,
		lang = systemDataStore.system.currentLang,
		module = systemDataStore.system.currentModule

	return `api/${lang}/${year}/${module}/${controller}/${action}`
}

/**
 * Execution of a simple GET request to the server (doesn't affect the navigation)
 * @param {String} controller The controller name
 * @param {String} action The action name
 * @param {String} parameter The action parameter (normally it will be the system/year)
 * @returns The «Promise» object that is resolved just after completely executed request
 */
export function simpleFetch(controller, action, parameter = '')
{
	const url = `api/${controller}/${action}/${parameter}`

	const promise = new Promise((fnResolve, fnReject) => {
		axios.axiosInstance.get(url)
			.then((response) => fnResolve(response))
			.catch((error) => fnReject(error))
	})

	asyncProcM.addProcess(promise)
	return promise
}

/**
 * Execution of the GET request to the server
 * @param {String} controller The controller name
 * @param {String} action The action name
 * @param {Object} params Object with additional parameters (Query String)
 * @param {Callback} _fnCallback The request callback to be executed to process the data received from the server. Receive «data» argument if the request is successfully completed
 * @param {Callback} _fnErrorCallback The request callback to be executed in the case of failure / error
 * @param {Object} options The Axios additional options (e.g: headers, Query String -> params: {...})
 * @param {string} navigationId The Navigation context Id
 * @returns The «Promise» object that is resolved just after completely executed request
 */
export function fetchData(controller, action, params, _fnCallback, _fnErrorCallback, options, navigationId)
{
	if (_isEmpty(navigationId))
		navigationId = MAIN_HISTORY_BRANCH_ID

	const systemDataStore = useSystemDataStore()

	if (!systemDataStore.system.currentSystem)
	{
		if (typeof _fnErrorCallback === 'function')
			_fnErrorCallback()
		return
	}

	// The "Promise" that is returned will only be executed after the callback of the processing of data received from the server has been completely executed.
	// The processing of AxiosResponte will be done centrally and the callback (which comes from the interface) will only have to worry about the processing of the received data.
	let url = apiActionURL(controller, action),
		tokenElements = document.getElementsByName('__RequestVerificationToken'),
		antiForgeryToken = tokenElements.length > 0 ? tokenElements[0].value : null,
		axiosOptions = {
			withCredentials: true,
			headers: {
				'__RequestVerificationToken': antiForgeryToken,
				// For Asp.NET Request.IsAjaxRequest()
				'X-Requested-With': 'XMLHttpRequest'
			},
			meta: {
				traceId: uuidv4()
			}
		}

	_merge(axiosOptions, options, { params: { ...params, nav: navigationId } })

	// Tracing event
	if (!options?.skipTracing)
	{
		const tracing = useTracingDataStore()
		tracing.addRequestTrace({
			origin: 'fetchData',
			requestType: 'get',
			requestUrl: url,
			requestParams: axiosOptions.params,
			contextData: {
				controller,
				action,
				options
			},
			traceId: axiosOptions.meta?.traceId
		})
	}

	const promise = new Promise((fnResolve) => {
		axios.axiosInstance.get(url, axiosOptions)
			.then((response) => processRequest(response, _fnCallback, fnResolve, options?.skipTracing))
			.catch((error) => handleNonOkResponse(error.response, fnResolve, _fnErrorCallback, error))
	})

	asyncProcM.addProcess(promise)
	return promise
}

/**
 * Execution of the POST request to the server
 * @param {String} controller The controller name
 * @param {String} action The action name
 * @param {Object} data Object with data to be sent to the server
 * @param {Callback} _fnCallback The request callback to be executed to process the data received from the server. Receive «data» argument if the request is successfully completed
 * @param {Callback} _fnErrorCallback The request callback to be executed in the case of failure / error
 * @param {Object} options The Axios additional options (e.g: headers, Query String -> params: {...})
 * @param {string} navigationId The Navigation context Id
 * @returns The «Promise» object that is resolved just after completely executed request
 */
export function postData(controller, action, data, _fnCallback, _fnErrorCallback, options, navigationId)
{
	if (_isEmpty(navigationId))
		navigationId = MAIN_HISTORY_BRANCH_ID

	const systemDataStore = useSystemDataStore()

	if (!systemDataStore.system.currentSystem)
	{
		if (typeof _fnErrorCallback === 'function')
			_fnErrorCallback()
		return
	}

	// The "Promise" that is returned will only be executed after the callback of the processing of data received from the server has been completely executed.
	// The processing of AxiosResponte will be done centrally and the callback (which comes from the interface) will only have to worry about the processing of the received data.
	let url = apiActionURL(controller, action),
		tokenElements = document.getElementsByName('__RequestVerificationToken'),
		antiForgeryToken = tokenElements.length > 0 ? tokenElements[0].value : null,
		axiosOptions = {
			withCredentials: true,
			headers: {
				'__RequestVerificationToken': antiForgeryToken,
				// For Asp.NET Request.IsAjaxRequest()
				'X-Requested-With': 'XMLHttpRequest'
			},
			meta: {
				traceId: uuidv4()
			}
		},
		navigationData = getHistoryToSend(navigationId, controller.toLowerCase()),
		jsonNavigationData = JSON.stringify(navigationData)

	// Set the Navigation/History to the request
	let requestData = data || {}
	if (requestData instanceof FormData)
		requestData.append('jsonNavigationData', new Blob([jsonNavigationData]))
	else
		// merge => to remove "reference" to the original object. in some cases, data and options use the same object.
		requestData = _merge({}, data, { jsonNavigationData })

	_merge(axiosOptions, options, { params: { nav: navigationId } })

	// Tracing event
	if (!options?.skipTracing)
	{
		const tracing = useTracingDataStore()
		tracing.addRequestTrace({
			origin: 'postData',
			requestType: 'post',
			requestUrl: url,
			requestParams: axiosOptions.params,
			requestData: requestData,
			contextData: {
				controller,
				action,
				options
			},
			traceId: axiosOptions.meta?.traceId
		})
	}

	const promise = new Promise((fnResolve) => {
		axios.axiosInstance.post(url, requestData, axiosOptions)
			.then((response) => processRequest(response, _fnCallback, fnResolve, options?.skipTracing))
			.catch((error) => handleNonOkResponse(error.response, fnResolve, _fnErrorCallback, error))
	})

	asyncProcM.addProcess(promise)
	return promise
}

/**
 * Fetches, from the server, the data of the specified form.
 * @param {string} controller The name of the controller
 * @param {string} formName The name of the form
 * @param {string} formMode The mode of the form
 * @param {object} params An object with additional parameters
 * @param {function} _fnCallback A callback function (optional)
 * @param {string} navigationId The Navigation context Id
 * @returns A «Promise» to be resolved when the request completes.
 */
export function fetchFormData(controller, formName, formMode, params, _fnCallback, navigationId)
{
	const action = `${formName}_${formMode}_GET`
	return postData(controller, action, params, _fnCallback, undefined, undefined, navigationId)
}

/**
 * Fetches, from the server, the data of the specified form field.
 * @param {string} controller The name of the controller
 * @param {string} formName The name of the form
 * @param {string} fieldName The name of the field
 * @param {object} params An object with additional parameters
 * @param {function} _fnCallback A callback function (optional)
 * @param {string} navigationId The Navigation context Id
 * @returns A «Promise» to be resolved when the request completes.
 */
export function fetchFormFieldData(controller, formName, fieldName, params, _fnCallback, navigationId)
{
	const action = `${formName}_${fieldName}`
	return postData(controller, action, params, _fnCallback, undefined, undefined, navigationId)
}

/**
 * Sends a POST request, to the server, with the data of the specified form.
 * @param {string} controller The name of the controller
 * @param {string} formName The name of the form
 * @param {string} formMode The mode of the form
 * @param {object} params An object with additional parameters
 * @param {function} _fnCallback A callback function to be executed in case of success (optional)
 * @param {function} _fnErrorCallback A callback function to be executed in case of failure (optional)
 * @param {object} headers An object with additional options to be included in the header (optional)
 * @param {string} navigationId The Navigation context Id
 * @returns A «Promise» to be resolved when the request completes.
 */
export function postFormData(controller, formName, formMode, params, _fnCallback, _fnErrorCallback, headers, navigationId)
{
	const action = `${formName}_${formMode}`
	return postData(controller, action, params, _fnCallback, _fnErrorCallback, headers, navigationId)
}

/**
 * Executes a mock request, for testing purposes.
 * @param {string} controller The name of the controller
 * @param {string} action The action name
 * @param {object} params An object with additional parameters
 * @param {object} mockData An object with the data that the server should respond with
 * @param {Callback} _fnCallback The request callback to be executed to process the data received from the server. Receive «data» argument if the request is successfully completed
 * @param {Callback} _fnErrorCallback The request callback to be executed in the case of failure / error
 * @returns A «Promise» to be resolved when the request completes.
 */
export function fetchFakeData(controller, action, params, mockData, _fnCallback, _fnErrorCallback)
{
	return new Promise((fnResolve) => {
		const url = apiActionURL(controller, action),
			axiosMockInstance = axios.getAxiosMockInstance(url, params, mockData)

		axiosMockInstance.get(url, params)
			.then((response) => processRequest(response, _fnCallback, fnResolve))
			.catch((error) => {
				if (_fnErrorCallback)
					_fnErrorCallback(error)
				fnResolve(error)
			})
	})
}

/**
 * Executes a mock request, for testing purposes.
 * @param {string} controller The name of the controller
 * @param {string} action The action name
 * @param {object} params An object with additional parameters
 * @param {object} mockData An object with the data that the server should respond with
 * @param {Callback} _fnCallback The request callback to be executed to process the data received from the server. Receive «data» argument if the request is successfully completed
 * @param {Callback} _fnErrorCallback The request callback to be executed in the case of failure / error
 * @returns A «Promise» to be resolved when the request completes.
 */
export function postFakeData(controller, action, params, mockData, _fnCallback, _fnErrorCallback)
{
	return new Promise((fnResolve) => {
		const url = apiActionURL(controller, action),
			axiosMockInstance = axios.getAxiosMockInstance(url, params, mockData)

		axiosMockInstance.post(url, params)
			.then((response) => processRequest(response, _fnCallback, fnResolve))
			.catch((error) => {
				if (_fnErrorCallback)
					_fnErrorCallback(error)
				fnResolve(error)
			})
	})
}

/**
 * Allow execution of the server side function
 * @param {string} func Function name
 * @param {*} args Function arguments
 * @returns Promise
 */
export function executeServerFunction(func, args)
{
	if (typeof func === 'undefined' || typeof args === 'undefined')
		return

	return new Promise((fnResolve) => {
		postData(
			'Home',
			'ExecuteServerFunction',
			{ func, args },
			(data) => data.Success ? fnResolve(data.Data) : fnResolve())
	})
}

/**
 * Force download of file
 * @param {string} data Request data object
 * @param {string} fileName File name
 * @param {string} fileType File MIME type
 * @param {boolean} newTab Whether it should be opened in a new tab (with preview)
 * @param {boolean} createBlob Whether it should create a blob or use the data directly
 */
export function forceDownload(data, fileName, fileType, newTab = false, createBlob = true)
{
	const blobOptions = fileType ? { type: fileType } : undefined
	const url = createBlob ? window.URL.createObjectURL(new Blob([data], blobOptions)) : data
	const link = document.createElement('a')
	link.href = url

	if (newTab)
		link.setAttribute('target', '_blank')
	else
		link.setAttribute('download', fileName)

	link.click()
}

/**
 * Retrieve an image from the server.
 * @param baseArea {String}
 * @param params {Object}
 * @param callback {Function}
 * @returns Promise
 */
export function retrieveImage(baseArea, params, callback)
{
	return fetchData(
		baseArea,
		'GetImage',
		params,
		(data) => {
			if (typeof callback === 'function')
				callback(data)
		})
}

/**
 * Gets the desired file from the server.
 * @param {string} baseArea The area to which the file belongs
 * @param {string} ticket The file ticket
 * @param {number} viewType The file view mode
 * @param {string} navigationId The Navigation context Id
 */
export function getFile(baseArea, ticket, viewType, navigationId = MAIN_HISTORY_BRANCH_ID)
{
	if (!Object.values(documentViewTypeMode).includes(viewType))
		viewType = documentViewTypeMode.preview

	const params = {
		ticket,
		viewType
	}

	asyncProcM.addBusy(
		postData(
			baseArea,
			'GetFile',
			params,
			async (_, response) => {
				const fileName = getFileNameFromRequest(response)
				const fileType = response.headers['content-type']

				// Here we check if there was a server-side error, if so we present an error message and do nothing.
				if (fileType.includes('application/json'))
				{
					// The response content comes as a byte array, so we need to parse it first.
					const data = new Blob([response.data], { type: fileType })
					const content = await data.text()
					const result = JSON.parse(content)

					if (result.Success === false)
					{
						displayMessage(result.Message, 'error')
						return
					}
				}

				// Should open in a new tab only if it's defined with "preview" and the file type allows it.
				const newTab = !fileType.includes('application/octet-stream') && (!fileName || viewType === documentViewTypeMode.preview)
				forceDownload(response.data, fileName, fileType, newTab)
			},
			undefined,
			{ responseType: 'arraybuffer' },
			navigationId))
}

/**
 * Retrieves the file name from an http file request.
 * @param {XMLHttpRequest} request The request that brings the file
 * @returns The name of the file, or null if it couldn't be found.
 */
export function getFileNameFromRequest(request)
{
	const getFileNameExp = /filename="(?<filename>.*)"/
	const contentDisposition = request?.headers['content-disposition']
	return getFileNameExp.exec(contentDisposition)?.groups?.filename ?? null
}

/**
 * Fetches the elements of a dynamic array from the server.
 * @param {String} array The identifier of the array to fetch
 * @param {String} lang The system language
 * @param {Function} callback The callback method to update the array
 */
export function fetchDynamicArray(array, lang, callback)
{
	const result = []

	fetchData(
		'Arrays',
		array,
		{ lang: lang },
		(data) => {
			let i = 1

			_forEach(data, (el) => {
				result.push({
					num: i++,
					key: el.Key,
					text: el.Text,
					group: el.Group,
					get value() { return this.text }
				})
			})

			if (typeof callback === 'function')
				callback(result)
		})
}

/**
 * Reads a file in chunks asyncronously without loading into memory at once.
 *
 * @param {File} file - The file to be split.
 * @param {number} maxChunkSize - The maximum size of each chunk in bytes.
 * @returns {AsyncGenerator<{chunk: Blob, start: number, end: number}>} An async generator that yields chunks with their range.
 */
async function* splitFile(file, maxChunkSize)
{
	if (!(file instanceof File))
	{
		const tracing = useTracingDataStore()
		tracing.addError({
			origin: 'splitFile',
			message: 'Provided input is not a valid File object.',
			contextData: {
				objectType: typeof file,
				maxChunkSize
			}
		})
		return
	}

	let currentPosition = 0
	while (currentPosition < file.size)
	{
		const chunk = file.slice(currentPosition, currentPosition + maxChunkSize)
		const end = currentPosition + chunk.size - 1 // Use chunk.size for precise end value
		// Process only the current chunk
		yield { chunk, start: currentPosition, end }
		currentPosition += chunk.size
	}
}

/**
 * Uploads a single chunk of a file.
 * @param {Object} options - Configuration options for the upload.
 * @param {string} options.url - The upload endpoint.
 * @param {Blob} options.chunk - The file chunk.
 * @param {string} options.fileId - The file field identifier.
 * @param {string} options.fileName - The name of the file.
 * @param {string} options.ticket - Security ticket for the file upload.
 * @param {string} options.mode - The mode of the upload.
 * @param {string} [options.version='1'] - The file version.
 * @param {number} options.fileSize - The total file size.
 * @param {number} options.start - The start byte of the chunk.
 * @param {number} options.end - The end byte of the chunk.
 * @param {Function} options._fnCallback - Success callback function.
 * @param {Function} options._fnErrorCallback - Error callback function.
 * @returns {Promise<void>} A promise that resolves when the upload completes.
 */
async function uploadChunk({
	url,
	chunk,
	fileId,
	fileName,
	ticket,
	mode,
	version = '1',
	fileSize,
	start,
	end,
	_fnCallback,
	_fnErrorCallback
})
{
	const formData = new FormData()
	formData.append(fileId, chunk, fileName)
	formData.append('ticket', ticket)
	formData.append('mode', mode)
	formData.append('version', version)

	const axiosOptions = {
		withCredentials: true,
		headers: {
			'Content-Type': 'multipart/form-data',
			'Content-Range': `bytes ${start}-${end}/${fileSize}`
		}
	}

	return new Promise((fnResolve) => {
		axios.axiosInstance.post(url, formData, axiosOptions)
			.then((response) => processRequest(response, _fnCallback, fnResolve))
			.catch((error) => handleNonOkResponse(error.response, fnResolve, _fnErrorCallback, error))
	})
}

/**
 * Determines the optimal chunk size based on the total file size.
 * This ensures efficient uploads while balancing memory usage and network performance.
 *
 * @param {number} fileSize - The total size of the file in bytes.
 * @returns {number} The recommended chunk size in bytes.
 */
function getOptimalChunkSize(fileSize)
{
	if (typeof fileSize !== 'number' || fileSize <= 0)
		throw new TypeError('Invalid file size. Expected a positive number.')

	// Define 1MB in bytes for better readability
	const MB = 1024 * 1024

	// Recommended chunk sizes based on file size ranges
	if (fileSize <= 50 * MB)
		return 5 * MB // 5MB for files ≤ 50MB
	else if (fileSize <= 500 * MB)
		return 10 * MB // 10MB for files ≤ 500MB
	return 15 * MB // 15MB for files larger than 500MB
}

/**
 * Uploads a file in multiple chunks.
 * @param {string} controller - The API controller handling the upload.
 * @param {string} action - The API action for the upload.
 * @param {File} file - The file to be uploaded.
 * @param {Object} params - Additional parameters for the upload.
 * @param {string} params.fileId - The file field identifier.
 * @param {string} params.ticket - Security ticket for the file upload.
 * @param {string} params.mode - The mode of the upload.
 * @param {string} params.version - The file version.
 * @param {Function} _fnCallback - Success callback function.
 * @param {Function} _fnErrorCallback - Error callback function.
 * @param {number} [maxChunkSize] - The maximum chunk size.
 * @returns {Promise<void>} A promise that resolves when all chunks are uploaded.
 */
export async function uploadFile(controller, action, file, params, _fnCallback, _fnErrorCallback, maxChunkSize)
{
	if (!(file instanceof File))
		throw new TypeError('Invalid file input. Expected a File object.')

	const url = apiActionURL(controller, action)
	// Set optimal chunk size if not provided
	maxChunkSize = maxChunkSize || getOptimalChunkSize(file.size)

	// Tracing event
	const tracing = useTracingDataStore()
	tracing.addRequestTrace({
		origin: 'uploadFile',
		requestType: 'post',
		requestUrl: url,
		requestParams: params,
		requestData: {
			sileSize: file?.size,
			fileName: file?.name,
		},
		contextData: {
			controller,
			action
		}
	})

	for await (const { chunk, start, end } of splitFile(file, maxChunkSize))
	{
		try
		{
			// Process chunks one at a time
			const uploadResult = await uploadChunk({
				url,
				chunk,
				...params,
				fileSize: file.size,
				fileName: file.name,
				start,
				end,
				_fnCallback,
				_fnErrorCallback
			})

			// As long as there is no "success": true/false, it is just a progress response.
			if (uploadResult?.success === false)
			{
				tracing.addTrace({
					origin: 'uploadFile',
					message: `Chunk ${start}-${end}/${file.size} uploaded unsuccessfully`,
					contextData: {
						params
					}
				})
				// Stop uploading further chunks on server error
				return
			}

			tracing.addTrace({
				origin: 'uploadFile',
				message: `Chunk ${start}-${end}/${file.size} uploaded successfully`,
				contextData: {
					params
				}
			})
		}
		catch (error)
		{
			tracing.addError({
				origin: 'uploadFile',
				message: `Error uploading chunk ${start}-${end}/${file.size}`,
				contextData: {
					error,
					params
				}
			})
			return // Stop uploading further chunks on error
		}
	}

	tracing.addTrace({
		origin: 'uploadFile',
		message: 'All chunks uploaded successfully',
		contextData: {
			params
		}
	})
}

/**
 * The proxy class for the network API with applying the navigation identifier.
 */
export class NetworkAPI
{
	constructor(navigationId)
	{
		this.navigationId = navigationId
		this.apiActionURL = apiActionURL
		this.executeServerFunction = executeServerFunction
		this.forceDownload = forceDownload
		this.retrieveImage = retrieveImage
		this.fetchDynamicArray = fetchDynamicArray
		this.uploadFile = uploadFile
	}

	fetchData(controller, action, params, _fnCallback, _fnErrorCallback, options)
	{
		return fetchData(controller, action, params, _fnCallback, _fnErrorCallback, options, this.navigationId)
	}

	postData(controller, action, data, _fnCallback, _fnErrorCallback, options)
	{
		return postData(controller, action, data, _fnCallback, _fnErrorCallback, options, this.navigationId)
	}

	fetchFormData(controller, formName, formMode, params, _fnCallback)
	{
		return fetchFormData(controller, formName, formMode, params, _fnCallback, this.navigationId)
	}

	fetchFormFieldData(controller, formName, field, params, _fnCallback)
	{
		return fetchFormFieldData(controller, formName, field, params, _fnCallback, this.navigationId)
	}

	postFormData(controller, formName, formMode, params, _fnCallback, _fnErrorCallback, headers)
	{
		return postFormData(controller, formName, formMode, params, _fnCallback, _fnErrorCallback, headers, this.navigationId)
	}
}

export default {
	apiActionURL,
	fetchData,
	postData,
	fetchFormData,
	fetchFormFieldData,
	postFormData,
	fetchFakeData,
	postFakeData,
	executeServerFunction,
	forceDownload,
	retrieveImage,
	getFile,
	getFileNameFromRequest,
	fetchDynamicArray,
	uploadFile
}
