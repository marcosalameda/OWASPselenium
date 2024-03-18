export default class DomHandler
{
	static addClass(element, className)
	{
		if (element.classList)
			element.classList.add(className)
		else
			element.className += ' ' + className
	}

	static removeClass(element, className)
	{
		if (element.classList)
			element.classList.remove(className)
		else
			element.className = element.className.replace(new RegExp('(^|\\b)' + className.split(' ').join('|') + '(\\b|$)', 'gi'), ' ')
	}

	static hasClass(element, className)
	{
		if (element)
		{
			if (element.classList)
				return element.classList.contains(className)
			else
				return new RegExp('(^| )' + className + '( |$)', 'gi').test(element.className)
		}

		return false
	}

	static find(element, selector)
	{
		return element.querySelectorAll(selector)
	}

	static findSingle(element, selector)
	{
		return element.querySelector(selector)
	}

	static getParents(element, parents = [])
	{
		return element['parentNode'] === null ? parents : this.getParents(element.parentNode, parents.concat([element.parentNode]))
	}

	static getScrollableParents(element)
	{
		let scrollableParents = []

		if (element)
		{
			const parents = this.getParents(element)
			const overflowRegex = /(auto|scroll)/
			const overflowCheck = node => {
				let styleDeclaration = window['getComputedStyle'](node, null)
				return overflowRegex.test(styleDeclaration.getPropertyValue('overflow')) || overflowRegex.test(styleDeclaration.getPropertyValue('overflowX')) || overflowRegex.test(styleDeclaration.getPropertyValue('overflowY'))
			}

			for (let parent of parents)
			{
				let scrollSelectors = parent.nodeType === 1 && parent.dataset['scrollselectors']
				if (scrollSelectors)
				{
					let selectors = scrollSelectors.split(',')
					for (let selector of selectors)
					{
						let el = this.findSingle(parent, selector)
						if (el && overflowCheck(el))
							scrollableParents.push(el)
					}
				}
			}
		}

		return scrollableParents
	}
}