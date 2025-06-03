import CustomControl from './baseControl.js'

/**
 * Collapsible Rows List control
 */
export default class QCollapsiblerowslist extends CustomControl
{
	constructor(controlContext, controlOrder)
	{
		super(controlContext, controlOrder)
	}

	/**
	 * Get the properties for configuring the collapsible rows list component.
	 * @param {object} viewMode - The current view mode of the collapsible rows list.
	 * @returns {object} - An object containing collapsible rows list properties.
	 */
	getProps(viewMode)
	{
		return {
			containerId: viewMode.containerId,
			items: this.getItems(viewMode),
			isAccordion: this.isAccordion(viewMode),
			supportsHtml: this.supportsHtml(viewMode)
		}
	}

	getItems(viewMode)
	{
		if (viewMode.mappedValues === null || viewMode.mappedValues === undefined)
			return []

		return viewMode.mappedValues.map((val) => ({
			id: val.rowKey,
			text: val.content.value,
			label: val.title.value
		}))
	}

	isAccordion(viewMode)
	{
		return viewMode.styleVariables.accordion?.value ?? false
	}

	supportsHtml(viewMode)
	{
		return viewMode.styleVariables.htmlContent?.value ?? true
	}
}
