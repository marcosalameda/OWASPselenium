/**
 * @jest-environment jsdom
 */
import { render } from './utils'
import { shallowMount } from './utils/shallowMount'

import QDocument from '@/components/inputs/document/QDocument.vue'
import fakeData from '../cases/Document.mock.js'

describe('QDocument.vue', () => {
	it('Links disabled and hidden on load of component', async () => {
		const wrapper = render(QDocument, {
			props: {
				fileProperties: fakeData.simpleUsage().fileProperties,
				versions: fakeData.simpleUsage().versionsObj,
				versionsInfo: fakeData.simpleUsage().versionsInfoArray,
				resourcesPath: fakeData.simpleUsage().resourcesPath
			}
		})

		const deleteLink = wrapper.getAllByTitle('Delete')
		const downloadLink = wrapper.getAllByTitle('Download')
		const attachLink = wrapper.getAllByTitle('Attach')

		expect(deleteLink[0].getAttribute('class')).toBe('dropdown-item disabled')
		expect(downloadLink[0].getAttribute('class')).toBe('dropdown-item disabled')
		expect(wrapper.queryByText('Edit')).toBeNull()
		expect(attachLink[0]).not.toBeNull()
	})

	it('Checks valid file size', async () => {
		const wrapper = shallowMount(QDocument, {
			props: {
				maxFileSize: 20,
				fileProperties: fakeData.simpleUsage().fileProperties,
				versions: fakeData.simpleUsage().versionsObj,
				versionsInfo: fakeData.simpleUsage().versionsInfoArray,
				resourcesPath: fakeData.simpleUsage().resourcesPath
			}
		})

		const file = new File(['This is a test file!'], 'Test.txt', { type: 'text/plain' })
		expect(wrapper.vm.maxFileSize).toBe(file.size)
	})

	it('Checks invalid file size', async () => {
		const wrapper = shallowMount(QDocument, {
			props: {
				maxFileSize: 1000,
				fileProperties: fakeData.simpleUsage().fileProperties,
				versions: fakeData.simpleUsage().versionsObj,
				versionsInfo: fakeData.simpleUsage().versionsInfoArray,
				resourcesPath: fakeData.simpleUsage().resourcesPath
			}
		})

		const file = new File(['This is a test file!'], 'Test.txt', { type: 'text/plain' })
		expect(wrapper.vm.maxFileSize).not.toBe(file.size)
	})
})
