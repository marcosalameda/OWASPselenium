<template>
	<q-radio-group
		v-if="value"
		:class="containerClasses"
		:model-value="options.checkedValue"
		:name="options.optionGroupName"
		:readonly="options.readonly"
		@update:model-value="updateExternal($event)">
		<q-radio-button
			:value="row.Value"
			:label="options.optionLabel" />
	</q-radio-group>
</template>

<script>
	export default {
		name: 'QEditRadio',

		emits: ['update', 'update-external', 'loaded'],

		props: {
			/**
			 * The value to be used for the radio input (typically a boolean or number).
			 */
			value: {
				type: [Boolean, Number],
				default: false
			},

			/**
			 * Configuration options for the radio input, such as read-only status and label text.
			 */
			options: {
				type: Object,
				default: () => ({})
			},

			/**
			 * The current row data object containing details necessary for the radio input.
			 */
			row: {
				type: Object,
				default: () => ({})
			},

			/**
			 * Classes to be applied to the radio input element.
			 */
			classes: {
				type: Array,
				default: () => []
			},

			/**
			 * Container classes to be applied to the radio input wrapper.
			 */
			containerClasses: {
				type: Array,
				default: () => []
			}
		},

		expose: [],

		mounted()
		{
			this.$emit('loaded')
		},

		methods: {
			/**
			 * Emits an 'update' event when the radio input's selected value has been changed.
			 * @param {Event} event - The native event object from the radio input's change event.
			 */
			update(event)
			{
				this.$emit('update', event.target.value)
			},

			/**
			 * Emits an 'update-external' event for any external updates of the radio input's selected value.
			 * @param {Event} event - The native event object from the radio input's change event.
			 */
			updateExternal(event)
			{
				this.$emit('update-external', event.target.value)
			}
		}
	}
</script>
