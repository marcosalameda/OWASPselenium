<template>
	<select
		v-model="curValue"
		:id="controlId"
		:name="controlId"
		:class="classes"
		:readonly="isBlocked"
		:required="isRequired"
		:aria-required="isRequired"
		:aria-readonly="isBlocked"
		:aria-label="labelText"
		:aria-labelledby="labelId">
		<option
			v-for="(option, optionIdx) in options"
			:key="optionIdx"
			:value="option">
			{{ option }}
		</option>
	</select>
</template>

<script>
	import _isEmpty from 'lodash-es/isEmpty'

	import { inputSize } from '@/mixins/quidgest.mainEnums.js'

	/**
	 * Basic 'select' dropdown list input
	 */
	export default {
		name: 'QSelectList',

		emits: ['update:modelValue'],

		inheritAttrs: false,

		props: {
			/**
			 * The unique control identifier
			 */
			id: String,

			/**
			 * The string vaue to be edited by the input
			 */
			modelValue: {
				type: String,
				required: true
			},

			/**
			 * Array of values that can be selected
			 */
			options: {
				type: Array,
				default: () => []
			},

			/**
			 * Sizing class for the control
			 */
			size: {
				type: String,
				validator: (value) => _isEmpty(value) || Reflect.has(inputSize, value)
			},

			/**
			 * True if the control is read only
			 */
			isBlocked: {
				type: Boolean,
				default: false
			},

			/**
			 * Whether or not the control should be marked as required
			 */
			isRequired: {
				type: Boolean,
				default: false
			},

			/**
			 * The control label/description for accessibility (aria-label) when the control is unlabeled
			 */
			labelText: {
				type: String,
				// When the value is null, Vue.js does not render the attribute
				default: null
			},

			/**
			 * For accessibility (aria-labelledby)
			 * ID, which refers to element that have the text needed for labeling
			 */
			labelId: {
				type: String,
				// When the value is null, Vue.js does not render the attribute
				default: null
			},

			classes: {
				type: Array,
				default: () => []
			}
		},

		data()
		{
			return {
				controlId: this.id || `i_select_list_${this._.uid}`
			}
		},

		computed: {
			curValue: {
				get()
				{
					return this.modelValue
				},
				set(newValue)
				{
					this.$emit('update:modelValue', newValue)
				}
			}
		}
	}
</script>
