/**
 * @jest-environment jsdom
 */
import { mount } from './utils'

import DateInput from '@/components/inputs/DateInput.vue'

describe('DateInput.vue', () => {
	let wrapper

	beforeEach(() => {
		wrapper = mount(DateInput, {
			propsData: {
				id: 'CTRL_1',
				format: 'Date'
			}
		})
	})

	afterEach(() => {
		wrapper.unmount()
	})

	it('Checks the componet is rendering', () => {
		expect(wrapper.exists()).toBe(true)
	})

	it('Checks correct button icon is rendering', () => {
		const button = wrapper.find('button')
		const className = button.attributes().class
		expect(className).toBe('q-btn q-btn--secondary')
	})

	it('Checks component is using "DateTime" as default format', () => {
		const wrapper = mount(DateInput, {
			propsData: {
				id: 'CTRL_2'
			}
		})
		const format = wrapper.vm.format
		expect(format).toBe('DateTime')
	})
})
