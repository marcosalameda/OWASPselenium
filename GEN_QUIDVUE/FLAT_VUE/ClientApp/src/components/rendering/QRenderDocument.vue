<template>
	<a
		v-if="value?.fileName && value?.ticket"
		rel="tooltip"
		title="Descarregar"
		@click.stop.prevent="onClick">
		{{ value.fileName }}
	</a>
</template>

<script>
	import { documentViewTypeMode } from '@/mixins/quidgest.mainEnums.js'

	export default {
		name: 'QRenderDocument',

		emits: ['execute-action'],

		props: {
			/**
			 * The object containing properties necessary to represent a document.
			 * It usually has a ticket for authentication, a fileName for display and download,
			 * title for tooltip, and viewType to determine how the document is to be processed.
			 */
			value: {
				type: Object,
				default: () => ({
					ticket: '',
					fileName: '',
					title: '',
					viewType: documentViewTypeMode.print
				})
			}
		},

		expose: [],

		methods: {
			/**
			 * Method to execute when the anchor link is clicked.
			 * It emits the 'execute-action' event with details for the document download.
			 */
			onClick()
			{
				const viewType = this.value?.viewType ?? documentViewTypeMode.print

				this.$emit('execute-action', {
					action: 'download',
					ticket: this.value.ticket,
					fileName: this.value.fileName,
					viewType: viewType
				})
			}
		}
	}
</script>
