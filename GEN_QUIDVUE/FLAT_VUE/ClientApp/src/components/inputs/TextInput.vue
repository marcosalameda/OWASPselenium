<template>
	<input
		:id="controlId"
		type="text"
		role="textbox"
		v-model.lazy="curValue"
		:name="controlId"
		:data-testid="dataTestid"
		:maxlength="maxCharacters"
		:readonly="isBlocked"
		:required="isRequired"
		:class="['i-text__field', 'i-text', size ? `input-${size}` : '', ...classes]"
		:aria-required="isRequired"
		:aria-readonly="isBlocked"
		:aria-label="label"
		:aria-labelledby="labelId"
		:placeholder="placeholder"
		:autocomplete="autocomplete"
		@click.stop.prevent="onClick"
		@focus="onFocus">
</template>

<script>
	import _isEmpty from 'lodash-es/isEmpty'

	import { inputSize } from '@/mixins/quidgest.mainEnums'

	/**
	 * Single line text box.
	 */
	export default {
		name: 'QTextInput',

		emits: [
			'click',
			'focus',
			'update:modelValue'
		],

		inheritAttrs: false,

		props: {
			/**
			 * The unique control identifier
			 */
			id: String,

			/**
			 * The testing identifier
			 */
			dataTestid: String,

			/**
			 * For accessibility (aria-labelledby)
			 * ID, which refers to element that have the text needed for labeling
			 */
			labelId: String,

			/**
			 * The autocomplete property
			 */
			autocomplete: String,

			/**
			 * The possible value options
			 */
			arrayOptions: Array,

			/**
			 * The string value to be edited by the input
			 */
			modelValue: {
				type: [String, Number],
				default: ''
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
			 * Maximum number of character for the string
			 */
			maxCharacters: {
				type: Number,
				default: -1
			},

			/**
			 * The control label/description for accessibility (aria-label) when the control is unlabeled
			 */
			label: {
				type: String,
				default: ''
			},

			/**
			 * The placeholder of the control
			 */
			placeholder: {
				type: String,
				default: ''
			},

			/**
			 * An array of custom classes
			 */
			classes: {
				type: Array,
				default: () => []
			}
		},

		data()
		{
			return {
				controlId: this.id || `i-text-${this._.uid}`
			}
		},

		computed: {
			curValue: {
				get()
				{
					if (this.arrayOptions)
					{
						const arrayOption = this.arrayOptions.find(e => e.key === this.modelValue)
						return arrayOption ? arrayOption.value : ''
					}

					return this.modelValue
				},
				set(newValue)
				{
					var value = newValue

					// If "arrayOptions" is set, we only allow the field to have values that exist in the options.
					if (this.arrayOptions)
					{
						const arrayOption = this.arrayOptions.find(e => e.value === newValue)
						value = arrayOption ? arrayOption.key : ''
					}

					this.$emit('update:modelValue', value)
				}
			}
		},

		methods: {
			onClick()
			{
				this.$emit('click')
			},

			onFocus()
			{
				this.$emit('focus')
			}
		}
	}
</script>
