<template>
	<div
		v-if="isVisible"
		ref="mainWrapper"
		:class="wrapperClasses">
		<slot name="label" />

		<slot />

		<template v-if="hasErrorMessages">
			<button
				v-if="hasPopover"
				type="button"
				ref="popover"
				class="btn-popover"
				@click.stop.prevent="togglePopover">
				<q-icon icon="exclamation-sign" />
			</button>
			<div
				v-else
				class="btn-popover">
				<q-icon icon="exclamation-sign" />
				{{ popoverDescription }}
			</div>
		</template>
	</div>
</template>

<script>
	import $ from 'jquery'

	export default {
		name: 'QGridBaseInputStructure',

		inheritAttrs: false,

		props: {
			/**
			 * Reference to the model field object which may contain error messages and other context.
			 */
			modelFieldRef: Object,

			/**
			 * Whether or not the control is currently visible.
			 */
			isVisible: {
				type: Boolean,
				default: true
			},

			/**
			 * Defines the error message display type, with valid options being 'text', 'popover', or 'both'.
			 */
			errorDisplayType: {
				type: String,
				default: 'text'
			}
		},

		expose: [],

		beforeUnmount()
		{
			$(this.$refs.popover).popover('dispose')
		},

		computed: {
			/**
			 * Dynamic classes for the main wrapper element based on current state.
			 */
			wrapperClasses()
			{
				const classes = ['grid-base-input-structure', this.$attrs.class]

				if (this.modelFieldRef?.hasServerErrorMessages())
					classes.push('error')

				return classes
			},

			/**
			 * Indicates if there are any server error messages.
			 */
			hasErrorMessages()
			{
				return this.modelFieldRef?.hasServerErrorMessages()
			},

			/**
			 * Concatenated string of error messages.
			 */
			popoverDescription()
			{
				return this.modelFieldRef?.serverErrorMessages.join('\n')
			},

			/**
			 * Determines if a popover should be used to display errors.
			 */
			hasPopover()
			{
				return this.errorDisplayType === 'popover' || this.errorDisplayType === 'both'
			}
		},

		methods: {
			/**
			 * Toggles the display of the popover showing error messages.
			 */
			togglePopover()
			{
				$(this.$refs.popover).popover('toggle')
			}
		},

		watch: {
			'modelFieldRef.serverErrorMessages'()
			{
				$(this.$refs.popover).popover('dispose')

				if (this.popoverDescription !== '')
				{
					$(this.$refs.popover).popover({
						html: true,
						trigger: 'focus',
						content: this.popoverDescription
					})
				}
			}
		}
	}
</script>
