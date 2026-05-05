import { computed } from 'vue'

import CustomControl from './baseControl.js'

/**
 * Cards control
 */
export default class ColorPickerControl extends CustomControl
{
	constructor(controlContext, controlOrder)
	{
		super(controlContext, controlOrder)
	}

	/**
	 * Get the properties for configuring the color picker component.
	 * @param {object} viewMode - The current view mode of the color picker.
	 * @returns {object} - An object containing color picker properties.
	 */
	getProps(viewMode)
	{
		return {
			id: this.controlContext.id,
			readonly: computed(() => viewMode.readonly),
			disabled: computed(() => viewMode.readonly),
			modelValue: computed(() => viewMode.mappedValues[0].color[0].value),
			placeholder: viewMode.placeholder
		}
	}
}
