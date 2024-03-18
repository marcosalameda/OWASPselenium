/**
 * @jest-environment jsdom
 */
import '@testing-library/jest-dom'
import { render } from '@testing-library/vue'
import userEvent from '@testing-library/user-event'

import CheckBoxInput from '@/components/inputs/CheckBoxInput'

describe('CheckBoxInput.vue', () => {
	it('Changes the model value when clicking', async () => {
		const wrapper = render(CheckBoxInput, {
			props: {
				modelValue: true,
				dataTestid: 'checkbox'
			}
		})

		const checkbox = await wrapper.getByTestId('checkbox')
		await userEvent.click(checkbox)
		expect(wrapper).toEmitModelValue(false)
		expect(checkbox).not.toBeChecked()

		await wrapper.rerender({ modelValue: false })
		await userEvent.click(checkbox)
		expect(wrapper).toEmitModelValue(true)
		expect(checkbox).toBeChecked()
	})

	it('Ignores clicks in disabled mode', async () => {
		const wrapper = render(CheckBoxInput, {
			props: {
				modelValue: true,
				disabled: true,
				dataTestid: 'checkbox'
			}
		})

		const checkbox = await wrapper.getByTestId('checkbox')
		await userEvent.click(checkbox)
		expect(checkbox).toBeChecked()
	})

	it('Ignores clicks in readonly mode', async () => {
		const wrapper = render(CheckBoxInput, {
			props: {
				modelValue: true,
				readonly: true,
				dataTestid: 'checkbox'
			}
		})

		const checkbox = await wrapper.getByTestId('checkbox')
		await userEvent.click(checkbox)
		expect(checkbox).toBeChecked()
	})
})
