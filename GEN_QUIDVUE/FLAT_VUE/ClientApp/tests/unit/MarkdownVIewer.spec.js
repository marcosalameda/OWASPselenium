import '@testing-library/jest-dom'
import { render } from '@testing-library/vue'

import fakeData from '../cases/MarkdownViewer.mock.js'
import QMarkdownViewer from '@/components/QMarkdownViewer.vue'

describe('QMarkdownViewer.vue', () => {
	it('Checks if it renders Markdown with HTML', async () => {
		const data = fakeData.simpleUsage()
		const wrapper = await render(QMarkdownViewer, {
			props: {
				id: 'Test',
				modelValue: data.simpleMarkdown
			}
		})

		expect(wrapper.html()).toBe(data.simpleMarkdownHtmlResult)
	})
})