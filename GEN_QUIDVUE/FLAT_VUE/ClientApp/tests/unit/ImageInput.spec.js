/**
 * @jest-environment jsdom
 */
import { fireEvent } from '@testing-library/vue'
import { render } from './utils'
import { nextTick } from 'vue'

import QImageInput from '@/components/inputs/image/QImageInput.vue'
import fakeData from '../cases/ImageInput.mock.js'

describe('QImageInput.vue', () => {
	it('Checks that, when no image is passed, delete and edit buttons are hidden.', () => {
		const { queryByTestId } = render(QImageInput, {
			props: {
				height: 400,
				width: 300
			}
		})

		const editButton = queryByTestId('edit-btn')
		const deleteButton = queryByTestId('delete-btn')
		expect(editButton).toBeNull()
		expect(deleteButton).toBeNull()
	})

	it('Checks that, when "disabled" is true, buttons are disabled.', () => {
		const { getByTestId } = render(QImageInput, {
			props: {
				height: 400,
				width: 300,
				image: fakeData.image,
				disabled: true
			}
		})

		const submitButton = getByTestId('submit-btn')
		const deleteButton = getByTestId('delete-btn')
		expect(submitButton).toHaveProperty('disabled')
		expect(deleteButton).toHaveProperty('disabled')
	})

	it('Checks that, when "readonly" is true, buttons are hidden.', () => {
		const { queryByTestId } = render(QImageInput, {
			props: {
				height: 400,
				width: 300,
				image: fakeData.image,
				readonly: true
			}
		})

		const submitButton = queryByTestId('submit-btn')
		const deleteButton = queryByTestId('delete-btn')
		expect(submitButton).toBeNull()
		expect(deleteButton).toBeNull()
	})
})

describe('QImageInput.vue', () => {
	let wrapper

	beforeEach(() => {
		wrapper = render(QImageInput, {
			props: {
				height: 400,
				width: 300,
				image: fakeData.image
			}
		})
	})

	it('Checks that, when an image is selected, the "submit-image" event is emitted.', async () => {
		const submitButton = wrapper.getByTestId('submit-btn')
		await fireEvent.click(submitButton)
		
		//Simulate image upload
		const input = wrapper.getByTestId('file-input')
		const file = new File([new ArrayBuffer(1)], 'file.jpg');
		// Supposedly you could replace the lines below with upload(), but it does not work
		//await userEvent.upload(input, file)
		Object.defineProperty(input, 'files', {value: [file] })
		await fireEvent.update(input);
		
		expect(wrapper.emitted('submit-image')).toBeTruthy()
	})

	it('Checks that, when the image is clicked, the "open-image-preview" event is emitted.', async () => {
		const previewImage = wrapper.getByTestId('main-img')
		await fireEvent.click(previewImage)
		await nextTick()
		expect(wrapper.emitted('open-image-preview')).toBeTruthy()
	})
})
