<template>
	<q-markdown-viewer :model-value="value" />
</template>

<script>
	import QMarkdownViewer from '@/components/QMarkdownViewer.vue'

	export default {
		name: 'QRenderMarkdown',

		components: {
			QMarkdownViewer
		},

		props: {
			/**
			 * The markdown content to render.
			 */
			value: {
				type: String,
				default: ''
			}
		},

		expose: []
	}
</script>
