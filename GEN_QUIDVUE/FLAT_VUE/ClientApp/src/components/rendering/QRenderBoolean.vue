<template>
	<q-icon
		:icon="icon"
		class="render-boolean" />
</template>

<script>
	export default {
		name: 'QRenderBoolean',

		props: {
			/**
			 * The boolean value to determine the icon state.
			 */
			value: {
				type: Boolean,
				default: false
			}
		},

		expose: [],

		computed: {
			/**
			 * The icon to be rendered depending on the boolean value.
			 * 'ok' for true values, 'close' for false.
			 */
			icon()
			{
				return this.value ? 'ok' : 'close'
			}
		}
	}
</script>
