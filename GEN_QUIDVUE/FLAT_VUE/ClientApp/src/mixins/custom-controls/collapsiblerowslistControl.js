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

	setCustomProperties(viewMode)
	{
		viewMode.items = this.getItems(viewMode)
		viewMode.isAccordion = this.isAccordion(viewMode)
		viewMode.supportsHtml = this.supportsHtml(viewMode)
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
