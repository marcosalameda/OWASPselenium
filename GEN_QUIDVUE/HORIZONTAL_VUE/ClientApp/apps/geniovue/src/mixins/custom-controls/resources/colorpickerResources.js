export default class ColorPickerResources
{
	constructor(fnGetResource)
	{
		this._fnGetResource = typeof fnGetResource !== 'function' ? resId => resId : fnGetResource
		Object.defineProperty(this, '_fnGetResource', { enumerable: false })

		Object.defineProperty(this, 'selectColor', {
			get: () => this._fnGetResource('SELECIONE_UMA_COR20431'),
			enumerable: true
		})
	}
}
