<template>
	<div
		:id="containerId"
		class="container-fluid">
		<component
			:is="containerComponent"
			:open-group="openGroup"
			v-slot="scope"
			id="accordion"
			@set-open-group="(state, groupId) => setOpenGroup(state, groupId)">
			<template
				v-for="item in items"
				:key="item.id">
				<q-group-collapsible
					:id="`group-${item.id}`"
					:is-open="isGroupOpen(`group-${item.id}`, openGroup)"
					:label="item.label"
					@state-changed="(state, groupId) => onStateChanged(scope, state, groupId)">
					<q-row-container>
						<q-control-wrapper class="control-join-group">
							<q-static-text
								:text="item.text"
								:supports-html="supportsHtml" />
						</q-control-wrapper>
					</q-row-container>
				</q-group-collapsible>
			</template>
		</component>
	</div>
</template>

<script>
	import { defineAsyncComponent } from 'vue'

	import QGroupCollapsible from '@/components/containers/QGroupCollapsible.vue'
	import QStaticText from '@/components/QStaticText.vue'

	export default {
		name: 'QCollapsibleRowsList',

		components: {
			QAccordionContainer: defineAsyncComponent(() => import('@/components/containers/QAccordionContainer.vue')),
			QGroupCollapsible,
			QStaticText
		},

		props: {
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
		},

		expose: [],

		data()
		{
			return {
				// For accordion mode
				openGroup: null,

				// For independent mode
				openGroups: {}
			}
		},

		computed: {
			/**
			 * Determines whether it is a accordion or a Collapsible component.
			 */
			containerComponent()
			{
				return this.isAccordion ? 'q-accordion-container' : 'div'
			}
		},

		methods: {
			onStateChanged(parentScope, state, groupId)
			{
				this.isAccordion ? parentScope.onStateChanged(state, groupId) : (this.openGroups[groupId] = state)
			},

			isGroupOpen(index, openGroup)
			{
				return this.isAccordion ? openGroup === index : this.openGroups[index]
			},

			setOpenGroup(state, groupId)
			{
				this.openGroup = state ? groupId : null
			}
		}
	}
</script>
