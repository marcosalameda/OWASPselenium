import CustomControl from './baseControl.js'
import CardsResources from './resources/cardsResources.js'

/**
 * Cards control
 */
export default class CardsControl extends CustomControl
{
	constructor(controlContext, controlOrder)
	{
		super(controlContext, controlOrder)

		this.usesFullSizeImages = true
		this.texts = new CardsResources(controlContext.vueContext.$getResource)
	}

	/**
	 * Sets any additional properties that might be needed for the cards
	 * @param {object} viewMode The current view mode
	 */
	setCustomProperties(viewMode)
	{
		viewMode.implementsOwnInsert = viewMode.styleVariables.customInsertCard?.value || false
	}
}
