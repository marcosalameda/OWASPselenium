import CustomControl from './baseControl.js'
import CarouselResources from './resources/carouselResources.js'

/**
 * Carousel control
 */
export default class CarouselControl extends CustomControl
{
	constructor(controlContext, controlOrder)
	{
		super(controlContext, controlOrder)

		this.usesFullSizeImages = true
		this.texts = new CarouselResources(controlContext.vueContext.$getResource)
	}
}
