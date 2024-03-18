/**
 * @jest-environment jsdom
 */
import '@testing-library/jest-dom'
import { render } from './utils'
import userEvent from '@testing-library/user-event'

import NumericInput from '@/components/inputs/NumericInput.vue'

//--------------
// TODO: TEMPORARILY DISABLED UNTIL NUMERIiNPUT CAN BE REFACTORED
// NumericInput is programmed using keyCode and wich properties of KeyboardEvent that are deprecated
// see: https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent/keyCode
// fireEvent sends these as 0 and will fail all the tests below that should otherwise work
// SKIP these tests until NumericInput can be reworked
//--------------

describe('NumericInput.vue', () => {
	it('render the  model value', async () => {
		const wrapper = render(NumericInput, {
			props: {
				modelValue: 123
			}
		})
		const numericInput = await wrapper.findByRole('textbox')
		expect(numericInput).toHaveValue('123')
	})

	it.skip('text characters or symbols are not allowed', async () => {
		const wrapper = render(NumericInput, {
			props: {
				modelValue: 234,
				thousandsSeparator: ' ',
				maxDecimals: 0
			}
		})

		const numericInput = await wrapper.findByRole('textbox')
		await userEvent.type(numericInput, 'abc')

		//TODO: This really should not be 0. I would expect the original 234 value to be preserved
		expect(numericInput).toHaveValue('0')
	})

	it.skip('verify the number of maximum digits', async () => {

		const wrapper = render(NumericInput, {
			props: {
				modelValue: 0,
				maxIntegers: 5,
				maxDecimals: 0
			}
		})
		const numericInput = await wrapper.findByRole('textbox')
		await userEvent.type(numericInput, '1234567890')

		expect(numericInput).toHaveValue('12345')
	})

	it('verify the number having thousand seperator', async () => {
		const wrapper = render(NumericInput, {
			props: {
				modelValue: 12345,
				thousandsSeparator: ','
			}
		})

		const numericInput = await wrapper.findByRole('textbox')
		expect(numericInput).toHaveValue('12,345')
	})

	it('verify the number with paste', async () => {
		const wrapper = render(NumericInput, {
			props: {
				modelValue: 123,
				isCurrency: true,
				currencySymbol: '€',
				maxDecimals: 4
			},
		})

		const numericInput = await wrapper.findByRole('textbox')
		await numericInput.focus()
		await userEvent.paste('1234.5')

		expect(numericInput).toHaveValue('1234.5000')
	})

	it('verify whether numeric for control allow decimal value', async () => {
		const wrapper = render(NumericInput, {
			props: {
				modelValue: 4,
				maxDecimals: 4
			}
		})
		const numericInput = await wrapper.findByRole('textbox')
		expect(numericInput).toHaveValue('4.0000')
	})

	it('verify whether numeric for control allow negative value', async () => {
		const wrapper = render(NumericInput, {
			props: {
				modelValue: -1234,
				thousandsSeparator: ','
			}
		})
		const numericInput = await wrapper.findByRole('textbox')
		expect(numericInput).toHaveValue('-1,234')
	})

	it.skip('verify cursor position after adding input value', async () => {
		const wrapper = render(NumericInput, {
			props: {
				modelValue: 0
			}
		})
		const numericInput = await wrapper.findByRole('textbox')

		await userEvent.type(numericInput, '12345')

		expect(numericInput).toHaveDisplayValue('12345')
		expect(numericInput.selectionStart).toBe(5)
	})
})
