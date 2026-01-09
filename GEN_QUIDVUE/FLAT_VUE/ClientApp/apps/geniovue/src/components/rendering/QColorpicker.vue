<template>
	<q-color-picker
		:id="id"
		:model-value="modelValue"
		:readonly="readonly"
		:disabled="disabled"
		:placeholder="placeholder"
		@update:model-value="$emit('update:model-value', $event)" />
</template>

<script>
	export default {
		/**
		 * This wrapper is needed because custom controls do not support multi-word names.
		 */
		name: 'QColorpicker',

		emits: [
			/**
			 * Emits when the color value changes.
			 * @event update:model-value
			 * @type {string} The updated HEX color value.
			 */
			'update:model-value',
		],

		inheritAttrs: false,

		props: {
			/**
			 * Unique identifier for the field.
			 * @type {string}
			 * @default undefined
			 */
			id: {
				type: String,
				default: undefined
			},

			/**
			 * The HEX color value bound to the color picker.
			 * @type {string}
			 * @default ''
			 */
			modelValue: {
				type: String,
				default: ''
			},

			/**
			 * Specifies whether the text field is read-only.
			 * @type {boolean}
			 * @default false
			 */
			readonly: {
				type: Boolean,
				default: false
			},

			/**
			 * Specifies whether the color picker is disabled.
			 * @type {boolean}
			 * @default false
			 */
			disabled: {
				type: Boolean,
				default: false
			},

			/**
			 * Placeholder text for the text field.
			 * @type {string}
			 * @default '#000000'
			 */
			placeholder: {
				type: String,
				default: '#000000'
			}
		},

		expose: []
	}
</script>
