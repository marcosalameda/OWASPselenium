import { createFramework } from '@quidgest/ui/framework'

const framework = createFramework({
	defaults: {
		QIcon: {
			type: 'svg'
		},
		
		QIconSvg: {
			bundle: 'Content/svgbundle.svg'
		}
	}
})

export default framework
