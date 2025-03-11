<template>
	<span
		:id="id"
		class="q-markdown-viewer"
		v-html="htmlContent" />
</template>

<script>
	import markdownit from 'markdown-it'

	export default {
		name: 'QMarkdownViewer',

		inheritAttrs: false,

		props: {
			/**
			 * Unique identifier for the control.
			 */
			id: String,

			/**
			 * The value bound to the control.
			 */
			modelValue: {
				type: String,
				default: ''
			}
		},

		expose: [],

		computed: {
			htmlContent()
			{
				return this.convertMarkdown(this.modelValue)
			}
		},

		methods: {
			convertMarkdown(markdownString)
			{
				const md = markdownit()
				const source = typeof markdownString === 'string' ? markdownString : ''
				const result = md.render(source)
				return result
			}
		}
	}
</script>
