import QMarkdownViewer from '@/components/QMarkdownViewer.vue'
import fakeData from './MarkdownViewer.mock.js'

export default {
	title: 'Views/MarkdownViewer',
	component: QMarkdownViewer,
	tags: []
}

export const Simple = {
	argTypes: {
		id: {
			control: 'text',
			description: 'Unique identifier',
		},
		modelValue: {
			control: 'text',
			description: 'Markdown',
		},
	},
	args: {
		id: 'Test',
		modelValue: fakeData.simpleUsage().simpleMarkdownWithoutLinks
	}
}
