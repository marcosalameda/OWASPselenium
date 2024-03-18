/**
 * @jest-environment jsdom
 */
import { render } from './utils'
import { shallowMount } from './utils/shallowMount'

import QDocumentInput from '@/components/inputs/document/QDocumentInput.vue'
import fakeData from '../cases/DocumentInput.mock.js'

describe('QDocumentInput.vue', () => {
	it('Links disabled and hidden on load of component', async () => {
		const wrapper = render(QDocumentInput, {
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
		const wrapper = shallowMount(QDocumentInput, {
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
		const wrapper = shallowMount(QDocumentInput, {
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
