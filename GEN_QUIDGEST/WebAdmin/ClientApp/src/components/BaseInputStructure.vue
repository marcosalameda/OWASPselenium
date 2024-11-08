<template>
	<div
		v-if="isVisible"
		:id="controlId"
		ref="mainWrapper"
		v-bind="wrapperAttrs"
		:data-loading="loading">
		<div
			style="align-items: center"
			:class="[classObject.labelContainerFlex, ...classes]">

			<label
				v-if="hasLabel && !isEmpty(label)"
				:id="labelId"
				v-bind="labelAttrs"
				:for="id"
				:data-val-required="isRequired && !(readonly || disabled)"
				:class="[{ disabled: disabled }, ...(classObject.labelClass || [])]">
				{{ label }}
			</label>
		</div>
		<slot />
	</div>
</template>

<script>
	import _isEmpty from 'lodash-es/isEmpty'

	export default {
		name: 'QBaseInputStructure',

		inheritAttrs: false,
		props: {
			/**
			 * Unique identifier for the control.
			 */
			id: {
				type: String
			},

			/**
			 * Text strings which might be used to override default texts within the component.
			 */
			texts: Object,

			/**
			 * The label text for the input field.
			 */
			label: {
				type: String,
				default: ''
			},

			/**
			 * Flag indicating if the label is to be displayed.
			 */
			hasLabel: {
				type: Boolean,
				default: true
			},

			/**
			 * Controls the readonly state of the input field.
			 */
			readonly: {
				type: Boolean,
				default: false
			},

			/**
			 * Disables the input field, preventing user interaction.
			 */
			disabled: {
				type: Boolean,
				default: false
			},

			/**
			 * Determines if the input field is marked as required.
			 */
			isRequired: {
				type: Boolean,
				default: false
			},

			/**
			 * Whether or not the control is currently visible.
			 */
			isVisible: {
				type: Boolean,
				default: true
			},

			/**
			 * The name of the array if this control is part of an array structure.
			 */
			arrayName: {
				type: String,
				default: ''
			},

			/**
			 * Set flexbox to display inline if true.
			 */
			dFlexInline: {
				type: Boolean,
				default: false
			},

			/**
			 * An array of additional CSS classes to apply to the component.
			 */
			classes: {
				type: Array,
				default: () => []
			},

			/**
			 * Information about the model that the input is bound to, such as the table and field IDs.
			 */
			modelInfo: {
				// tableId | fieldId
				type: Object,
				default: null
			},

			/**
			 * Whether the control is currently loading.
			 */
			loading: {
				type: Boolean,
				default: false
			}
		},

		expose: [],

		data()
		{
			return {
				controlId: `container-${this.id || this._.uid}`,

				classObject: {
					labelContainerFlex: this.dFlexInline ? 'label-container--inline' : 'label-container'
				},

				wrapperAttrs: {
					class: this.$attrs.class ?? ''
				},

				labelAttrs: this.$attrs.labelAttrs ?? {},

				sortablePlugin: null
			}
		},

		computed: {
			/**
			 * The identifier for the label element associated with the control.
			 */
			labelId()
			{
				return `label_${this.id}`
			}
		},

		methods: {
			isEmpty: _isEmpty
		}
	}
</script>
