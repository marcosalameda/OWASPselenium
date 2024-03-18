import { reactive } from 'vue'
import _isEmpty from 'lodash-es/isEmpty'
import domToImage from 'dom-to-image'

import { forceDownload } from '@/api/network'
import { geographicDisplay } from '@/mixins/genericFunctions.js'
import { GeographicShapeColumn } from '@/mixins/listColumnTypes.js'
import CustomControl from './baseControl.js'
import MapResources from './resources/mapResources.js'

import { useSystemDataStore } from '@/stores/systemData.js'

/**
 * Map control
 */
export default class MapControl extends CustomControl
{
	constructor(controlContext, controlOrder)
	{
		super(controlContext, controlOrder)

		this.map = null
		this.texts = new MapResources(controlContext.vueContext.$getResource)

		this.handlers = {
			isReady: (...args) => this.isReady(...args),
			setMarker: (...args) => this.setMarker(...args),
			removeMarker: (...args) => this.removeMarker(...args),
			findAddress: (...args) => this.findAddress(...args),
			setShapes: (...args) => this.setShapes(...args),
			changedCenter: (...args) => this.changedCenter(...args),
			changedZoom: (...args) => this.changedZoom(...args),
			exportMap: (...args) => this.exportMap(...args)
		}
	}

	/**
	 * Checks whether or not the view mode should be blocked
	 * @param {boolean} isMultiple True if it's over a list, false otherwise
	 * @returns True if it's blocked, false otherwise
	 */
	checkIsReadonly(isMultiple)
	{
		return isMultiple
	}

	/**
	 * Sets up any additional necessary listeners
	 */
	setListeners()
	{
		if (typeof this.controlContext.parentOpeningEvent === 'string' &&
			typeof this.controlContext.onParentOpen !== 'function')
		{
			this.controlContext.onParentOpen = () => {
				const viewMode = this.controlContext.viewModes[this.controlOrder - 1]
				viewMode.mapVersionKey = Math.random()
			}

			this.controlContext.vueContext.internalEvents.off(this.controlContext.parentOpeningEvent, this.controlContext.onParentOpen)
			this.controlContext.vueContext.internalEvents.on(this.controlContext.parentOpeningEvent, this.controlContext.onParentOpen)
		}
	}

	/**
	 * Called when the map is initialized, to set the map's node object
	 * @param {object} map The map's node object
	 */
	isReady(map)
	{
		if (typeof map === 'object' && !_isEmpty(map))
			this.map = map
	}

	/**
	 * Sets the specified marker
	 * @param {object} marker The marker
	 */
	setMarker(marker)
	{
		// The marker having a row key means it's not in a form
		if (_isEmpty(marker) || typeof marker.rowKey !== 'undefined')
			return

		const newValue = this.convertCoordsToString(marker.coords)
		this.controlContext.modelFieldRef.updateValue(newValue)
	}

	/**
	 * Removes the specified marker from the map
	 * @param {object} marker The marker
	 */
	removeMarker(marker)
	{
		// The marker having a row key means it's not in a form
		if (_isEmpty(marker) || typeof marker.rowKey !== 'undefined')
			return

		this.controlContext.modelFieldRef.updateValue('')
	}

	/**
	 * Finds the address of the specified marker
	 * @param {object} marker The marker
	 */
	findAddress(marker)
	{
		const lat = marker.coords.lat
		const long = marker.coords.lng
		const markerAddress = ''

		/*
		const url = `https://api.geoapify.com/v1/geocode/reverse?lat=${lat}&lon=${long}&apiKey=${this.apiKey}`
		const res = axios.get(url).then(() => {
			return res.data.features[0].properties.formatted
		})
		*/

		const viewMode = this.controlContext.viewModes[this.controlOrder - 1]

		if (!_isEmpty(viewMode))
		{
			const mappedValues = viewMode.mappedValues

			if (!Array.isArray(mappedValues))
				return

			for (let mappedValue of mappedValues)
			{
				if (!Array.isArray(mappedValue.geographicData))
					continue

				for (let geographicVal of mappedValue.geographicData)
				{
					if (_isEmpty(geographicVal.value) || geographicVal.type !== 'Geographic')
						continue

					geographicVal = reactive(geographicVal)
					if (geographicVal.value.lat === lat && geographicVal.value.lng === long)
						geographicVal.address = markerAddress
				}
			}
		}
	}

	/**
	 * Sets the shapes currently on the map.
	 * @param {object} shapesLayer The layer with the shapes
	 */
	setShapes(shapesLayer)
	{
		// The layer having a row key means it's not in a form
		if (_isEmpty(shapesLayer) || typeof shapesLayer.rowKey !== 'undefined' || !Array.isArray(shapesLayer.shapes))
			return

		this.controlContext.modelFieldRef.updateValue(shapesLayer)
	}

	/**
	 * Sets the current coordinates for the center of the map.
	 * @param {object} center The coordinates of the center
	 */
	changedCenter(center)
	{
		const viewMode = this.controlContext.viewModes[this.controlOrder - 1]
		viewMode.mapCenter = center
	}

	/**
	 * Sets the current zoom of the map.
	 * @param {number} zoom The zoom level
	 */
	changedZoom(zoom)
	{
		const viewMode = this.controlContext.viewModes[this.controlOrder - 1]
		viewMode.mapZoom = zoom
	}

	/**
	 * Sets any additional properties that might be needed for the maps to work
	 * @param {object} viewMode The current view mode
	 */
	setCustomProperties(viewMode)
	{
		const systemDataStore = useSystemDataStore()
		const isTable = this.controlContext.type === 'TableSpecialRendering'
		const mappedValues = viewMode.mappedValues

		viewMode.resourcesPath = systemDataStore.system.resourcesPath
		viewMode.isDrawableMap = this.controlContext.isGeographicShape ?? false
		viewMode.isEuclideanCoord = (
			isTable && mappedValues?.length > 0 && mappedValues[0].geographicData?.length > 0
				? mappedValues[0].geographicData[0].source instanceof GeographicShapeColumn
				: this.controlContext.isEuclideanCoord
		) ?? false
		viewMode.isSinglePoint = !isTable
		viewMode.hideMapControls = false

		// Add a way of changing the visibility of the map controls
		this.setControlsVisibility = (visible) => viewMode.hideMapControls = !visible

		// Tokens might be necessary to access some layers from external services
		const tokens = {}

		for (let externalLayer of viewMode.groups.externalLayer)
		{
			const externalLayerId = externalLayer.externalLayerConfig?.value

			if (externalLayerId)
				tokens[externalLayerId] = this.controlContext.vueContext.dataApi.extraProperties[externalLayerId]
		}

		viewMode.tokens = tokens
	}

	/**
	 * Hydrates all values whose mapping variable's format is different from the one used in the component
	 * @param {object} viewMode The current view mode
	 */
	hydrateValues(viewMode)
	{
		for (let mappedValue of viewMode.mappedValues)
		{
			if (!Array.isArray(mappedValue.geographicData))
				continue

			for (let geographicVal of mappedValue.geographicData)
			{
				if (_isEmpty(geographicVal))
					geographicVal = {}

				const isShape = viewMode.isDrawableMap || geographicVal.source instanceof GeographicShapeColumn
				geographicVal.type = isShape ? 'GeographicShape' : 'Geographic'

				if (!_isEmpty(geographicVal.rawData))
				{
					const rawData = geographicVal.rawData

					if (isShape)
					{
						const layerName = mappedValue.layerName?.value ?? ''
						const layer = {
							layerName: rawData.layerName || layerName || this.texts.shapesLayer,
							shapes: rawData.shapes
						}

						geographicVal.value = layer
					}
					else
						geographicVal.value = this.convertCoordsToObj(rawData)
				}
				else
					geographicVal.value = null
			}
		}
	}

	/**
	 * Hydrates all style variables whose format is different from the one used in the component
	 * @param {object} viewMode The current view mode
	 * @param {object} fieldId The id of the field that triggered this function call (optional)
	 */
	hydrateStyleVariables(viewMode, fieldId)
	{
		const setVarValue = (variable) => {
			if (!_isEmpty(variable) &&
				(variable.dataType === 'Geographic' || typeof variable.value === 'string' && variable.value.startsWith('POINT')) &&
				(_isEmpty(fieldId) || fieldId === variable.source))
				variable.value = this.convertCoordsToObj(variable.value)
		}

		setVarValue(viewMode.styleVariables.centerCoord)
		setVarValue(viewMode.styleVariables.boundSouthWest)
		setVarValue(viewMode.styleVariables.boundNorthEast)
	}

	/**
	 * Converts the specified coordinates to the format expected by the component
	 * @param {string} coords The coordinates in a Well Known Text (WKT) standard format (ex: "POINT(0 0)")
	 * @returns An object with the coordinates in the correct format
	 */
	convertCoordsToObj(coords)
	{
		var markerCoords = [0, 0]

		if (typeof coords === 'string' && coords.startsWith('POINT'))
			markerCoords = coords.split('(')[1].split(')')[0].split(' ')

		return {
			lat: Number(markerCoords[1]),
			lng: Number(markerCoords[0])
		}
	}

	/**
	 * Converts the specified coordinates to a string in Well Known Text (WKT) standard format (ex: "POINT(0 0)")
	 * @param {object} coords The coordinates in object format (ex: { lat: 0, lng: 0 })
	 * @returns The coordinates in a string format
	 */
	convertCoordsToString(coords)
	{
		var markerCoords = [0, 0]

		if (typeof coords === 'object')
		{
			markerCoords = [
				coords.lat || 0,
				coords.lng || 0
			]
		}

		const marker = {
			Lat: Number(markerCoords[0]),
			Long: Number(markerCoords[1])
		}

		return geographicDisplay(marker)
	}

	/**
	 * Exports the map as a base 64 image (the map must be visible on the screen, not in a closed tab or collapsible)
	 * @param {boolean} isPortrait Whether or not to get the image as a portrait, as oposed to landscape
	 * @returns An image representation of the map in base 64
	 */
	async getMapAsImage(isPortrait)
	{
		// The map needs to be initialized for this to work
		if (this.map === null)
			return null

		const mapContainer = this.map.getContainer()

		const getAndRotateMapImg = (mapImg) => {
			return new Promise((resolve, reject) => {
				// Create an off-screen canvas
				const canvas = document.createElement('canvas'),
					canvasCtx = canvas.getContext('2d')

				// Create a new image
				const img = new Image()
				img.onload = () => {
					// Set it's dimension to the rotated size
					canvas.height = img.width
					canvas.width = img.height

					// Rotate and draw source image into the off-screen canvas
					canvasCtx.rotate(90 * Math.PI / 180)
					canvasCtx.translate(0, -canvas.width)
					canvasCtx.drawImage(img, 0, 0)

					// Convert the image to base 64
					const base64Img = canvas.toDataURL('image/png', 100)
					resolve(base64Img)
				}
				img.onerror = reject
				img.src = mapImg
			})
		}

		const mapSize = this.map.getSize()
		let mapBase64Img = null

		// We don't want the map controls to appear in the exported image
		this.setControlsVisibility(false)

		await domToImage.toPng(mapContainer, {
			width: mapSize.x,
			height: mapSize.y
		}).then(async (mapImg) => {
			this.setControlsVisibility(true)

			// If it's a portrait and the width is greater than the height, then we need to rotate it
			if (isPortrait && mapSize.x > mapSize.y || !isPortrait && mapSize.x < mapSize.y)
				mapBase64Img = await getAndRotateMapImg(mapImg)
			else
				mapBase64Img = mapImg
		})

		return mapBase64Img
	}

	/**
	 * Exports and downloads the map as a PNG image (the map must be visible on the screen, not in a closed tab or collapsible)
	 * @param {boolean} isPortrait Whether or not to get the image as a portrait, as oposed to landscape
	 * @param {string} mapName The name to give to the image file
	 */
	exportMap(isPortrait, mapName)
	{
		this.getMapAsImage(isPortrait).then((mapImg) => {
			if (typeof mapImg !== 'string')
				return

			let imgName = 'Map'
			if (typeof mapName === 'string' && mapName.length > 0)
				imgName = mapName

			forceDownload(mapImg, imgName, 'png', false, false)
		})
	}
}
