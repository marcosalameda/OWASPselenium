<template>
	<div
		:id="controlId"
		:class="containerClasses"
		tabindex="0">
		<div
			:class="progressClasses"
			:style="{ width: `${progress}%` }">
			<span class="q-progress-bar-text">{{ text }}</span>
		</div>
	</div>
</template>

<script>
	export default {
		name: 'QProgressBar',

		inheritAttrs: false,

		props: {
			/**
			 * Unique identifier for the progress bar.
			 */
			id: String,

			/**
			 * Progress value represented in percentage, from 0 to 100.
			 */
			progress: {
				type: Number,
				default: 100,
				validator: (value) => value >= 0 && value <= 100
			},

			/**
			 * Text to display in the progress bar.
			 */
			text: {
				type: String,
				default: ''
			},

			/**
			 * Whether the progress bar should be striped.
			 */
			striped: {
				type: Boolean,
				default: false
			},

			/**
			 * Whether the progress bar should be animated.
			 */
			animated: {
				type: Boolean,
				default: true
			},

			/**
			 * Whether to use a minimal version of the progress bar.
			 */
			mini: {
				type: Boolean,
				default: false
			}
		},

		expose: [],

		data()
		{
			return {
				controlId: this.id || `q-progress-bar-${this._.uid}`
			}
		},

		computed: {
			/**
			 * The list of classes to apply to the progress bar container.
			 */
			containerClasses()
			{
				return ['q-progress', { 'q-progress--mini': this.mini }]
			},

			/**
			 * The list of classes to apply to the progress bar.
			 */
			progressClasses()
			{
				return [
					'q-progress-bar',
					{
						'q-progress-bar--striped': this.striped,
						'q-progress-bar--animated': this.animated && this.progress < 100
					}
				]
			}
		}
	}
</script>
