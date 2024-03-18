/**
 * @jest-environment jsdom
 */
import '@testing-library/jest-dom'
import { fireEvent, render } from '@testing-library/vue'
import userEvent from '@testing-library/user-event'

import TextInput from '@/components/inputs/TextInput'

// DOC: https://testing-library.com/docs/vue-testing-library/intro/

describe('TextInput.vue', () => {
	it('Renders different TextInput sizes when passed', async () => {
		let m = 'Hello World!'
		const wrapper = render(TextInput, {
			props: {
				id: 'small input',
				modelValue: m
			}
		})
		const smallInput = await wrapper.findByRole ('textbox')
		expect(smallInput).toHaveValue(m)
	}),

	it('Truncates text when maximum character length is surpassed', async () => {
		let m = 'Hello World!'
		const wrapper = render(TextInput, {
			props: {
				id: 'small input',
				modelValue: m,
				maxCharacters: 15
			}
		})
		const smallInput = await wrapper.findByRole('textbox')

		await fireEvent.update(smallInput, '')
		await userEvent.type(smallInput, 'The quick brown fox jumps over the lazy dog')
		await fireEvent.change(smallInput)

		expect(smallInput).toHaveValue('The quick brown')
		// Check if the modelValue event is emmited
		expect(wrapper).toEmitModelValue('The quick brown')
	})
})
