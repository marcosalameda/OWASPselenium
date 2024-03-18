<template>
	<label :class="['i-checkbox__container', { 'disabled': disabled || readonly }]">
		<input
			:id="controlId"
			v-model="curValue"
			type="checkbox"
			:data-testid="dataTestid"
			:class="styleClasses"
			:disabled="disabled || readonly"
			@click="inputClicked">

		<span class="i-checkbox__field"></span>
	</label>
</template>

<script>
	export default {
		name: 'QCheckbox',

		emits: [
			'click',
			'update:modelValue'
		],

		inheritAttrs: false,

		props: {
			/**
			 * Unique identifier for the control.
			 */
			id: String,

			/**
			 * The testing identifier
			 */
			dataTestid: String,

			/**
			 * The string vaue to be edited by the input
			 */
			modelValue: [Boolean, Number],

			/**
			 * Whether the field is readonly.
			 */
			readonly: {
				type: Boolean,
				default: false
			},

			/**
			 * Whether the field is disabled.
			 */
			disabled: {
				type: Boolean,
				default: false
			},

			/**
			 * Whether the field is required.
			 */
			isRequired: {
				type: Boolean,
				default: false
			},

			/**
			 * An array of custom classes
			 */
			classes: {
				type: Array,
				default: () => []
			}
		},

		expose: [],

		data()
		{
			return {
				/**
				 * Classes for the html element.
				 */
				styleClasses: ['i-checkbox__field', ...this.classes]
			}
		},

		computed: {
			/**
			 * The current value of the checkbox.
			 */
			curValue: {
				get()
				{
					return !!this.modelValue
				},
				set(newValue)
				{
					var val
					if (typeof this.modelValue === 'number')
						val = newValue ^ 0
					else
						val = !!newValue

					this.$emit('update:modelValue', val)
				}
			},

			// Must be a computed property so it can change when used in tables with row reordering.
			/**
			 * The unique control identifier.
			 */
			controlId()
			{
				return this.id || this._.uid
			}
		},

		methods: {
			inputClicked(eventData)
			{
				this.$emit('click', eventData || {})
			}
		}
	}
</script>
