import CustomControl from './baseControl.js'

/**
 * Chart control
 */
export default class ChartControl extends CustomControl
{
	constructor(controlContext, controlOrder)
	{
		super(controlContext, controlOrder)
	}

	/**
	 * Sets any additional properties that might be needed for the chart
	 * @param {object} viewMode The current view mode
	 */
	setCustomProperties(viewMode)
	{
		viewMode.config = {}
	}
}
