<template>
	<div
		:id="containerId"
		class="container-fluid">
		<q-accordion :multiple="!props.isAccordion">
			<q-accordion-item
				v-for="item in props.items"
				:key="item.id"
				:value="item.id"
				:title="item.label">
				<q-row-container>
					<q-control-wrapper class="control-join-group">
						<q-static-text
							:text="item.text"
							:supports-html="props.supportsHtml" />
					</q-control-wrapper>
				</q-row-container>
			</q-accordion-item>
		</q-accordion>
	</div>
</template>

<script setup>
	import QStaticText from '@/components/QStaticText.vue'

	const props = defineProps({
		/**
		 * The unique identifier for the container.
		 */
		containerId: String,

		/**
		 * Items to be displayed.
		 */
		items: {
			type: Array,
			default: () => []
		},

		/**
		 * If it is accordion or collapsible.
		 */
		isAccordion: {
			type: Boolean,
			default: false
		},

		/**
		 * If it supports html or not.
		 */
		supportsHtml: {
			type: Boolean,
			default: true
		}
	})
</script>
