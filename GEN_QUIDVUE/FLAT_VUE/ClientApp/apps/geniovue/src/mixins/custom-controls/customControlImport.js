import CalendarControl from './calendarControl.js'
import CardsControl from './cardsControl.js'
import CarouselControl from './carouselControl.js'
import ChartControl from './chartControl.js'
import CollapsiblerowslistControl from './collapsiblerowslistControl.js'
import MapControl from './mapControl.js'

/**
 * Gets the class that implements the custom control with the desired control type.
 * @param {string} controlType The type of the custom control
 * @param {object} context The view mode context
 * @param {number} viewModeOrder The order of the view mode
 * @returns The class corresponding to the specified custom control, or null.
 */
export default function getCustomControl(controlType, context, viewModeOrder)
{
	switch (controlType)
	{
		case 'calendar':
			return new CalendarControl(context, viewModeOrder)
		case 'cards':
			return new CardsControl(context, viewModeOrder)
		case 'carousel':
			return new CarouselControl(context, viewModeOrder)
		case 'chart':
			return new ChartControl(context, viewModeOrder)
		case 'collapsiblerowslist':
			return new CollapsiblerowslistControl(context, viewModeOrder)
		case 'map':
			return new MapControl(context, viewModeOrder)
	}

	return null
}
