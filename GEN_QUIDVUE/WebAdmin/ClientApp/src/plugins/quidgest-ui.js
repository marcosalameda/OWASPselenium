import { createFramework } from '@quidgest/ui'

const framework = createFramework({
	defaults: {
		QIcon: {
			type: 'font'
		},
		QIconFont: {
			library: 'glyphicons'
		},
		QListItem: {
			icons: {
				check: {
					icon: 'ok'
				},
			}
		},
		QCheckbox: {
			icons: {
				checked: {
					icon: 'ok'
				},

				indeterminate: {
					icon: 'minus'
				}
			}
		},
	}
})

export default framework
