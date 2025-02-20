<template>
	<div
		v-show="isVisible"
		:id="`${controlId}-container`"
		:class="classes">
		<div
			class="q-group-collapsible__header">
			<q-button
				:id="buttonId"
				b-style="tertiary"
				@click="toggleCollapse">
				<span
					:data-val-required="isRequired">
					<q-icon :icon="accordionIcon" />
					<span
						class="q-group-collapsible__label"
						:id="labelId">
						{{ label }}
					</span>
				</span>
			</q-button>

			<q-popover-help
				v-if="popoverText"
				:help-control="helpControl"
				:id="id"
				:label="label"
				:texts="texts" />

			<q-tooltip-help
				v-if="tooltipText"
				:anchor="anchorId"
				:label="label"
				:help-control="helpControl" />
		</div>
		<div
			class="q-group-collapsible__content"
			:style="contentStyle"
			ref="content"
			@transitionend="afterToggleCollapse">
			<div class="q-group-collapsible__inner">
				<slot></slot>
			</div>
		</div>
	</div>
</template>

<script>
	import HelpControl from '@/mixins/helpControls.js'
	import { defineAsyncComponent } from 'vue'

	export default {
		name: 'QGroupCollapsible',

		emits: ['state-changed'],

		inheritAttrs: false,

		mixins: [HelpControl],

		components: {
			QPopoverHelp: defineAsyncComponent(() => import('@/components/QPopoverHelp.vue')),
			QTooltipHelp: defineAsyncComponent(() => import('@/components/QTooltipHelp.vue'))
		},

		props: {
			/**
			 * Unique identifier for the control.
			 */
			id: String,

			/**
			 * Text strings which might be used to override default texts within the component.
			 */
			texts: Object,

			/**
			 * The title of the group.
			 */
			label: {
				type: String,
				required: true
			},

			/**
			 * Whether or not the collapsible group is visible.
			 */
			isVisible: {
				type: Boolean,
				default: true
			},

			/**
			 * Whether or not the collapsible group is open.
			 */
			isOpen: {
				type: Boolean,
				default: false
			},

			/**
			 * Whether or not the collapsible group contains required fields.
			 */
			isRequired: {
				type: Boolean,
				default: false
			}
		},

		expose: [],

		data()
		{
			return {
				controlId: this.id || `groupbox-${this._.uid}`,
				contentHeight: 0,
				animating: false,
				// This property changes to true right away when opening the container and changes to false after closing the container.
				contentsVisible: this.isOpen,
				resizeObserver: null
			}
		},

		computed: {
			accordionIcon()
			{
				return this.isOpen ? 'collapse' : 'expand'
			},

			classes()
			{
				const baseClass = 'q-group-collapsible'
				const classes = [baseClass, this.$attrs.class]

				// When opened, add class to show overflow which prevents height from changing back and forth.
				if (this.isOpen && !this.animating)
					classes.push(`${baseClass}--open`)
				else if (this.animating)
					classes.push(`${baseClass}--toggling`)

				return classes
			},

			contentStyle()
			{
				return {
					maxHeight: this.isOpen ? `${this.contentHeight}px` : 0,
					// Must use 'visibility' property so the contents are still their full height even when hidden.
					visibility: this.contentsVisible ? null : 'hidden'
				}
			},

			labelId()
			{
				return `label_${this.controlId}`
			},

			buttonId()
			{
				return this.controlId
			}
		},

		mounted()
		{
			if (typeof ResizeObserver !== 'undefined')
			{
				this.resizeObserver = new ResizeObserver(() => {
					this.contentHeight = this.$refs.content?.scrollHeight
				})
			}

			this.$nextTick().then(() => {
				if (this.isOpen)
					this.collapseStateHandler()
			})
		},

		beforeUnmount()
		{
			this.resizeObserver?.disconnect()
		},

		methods: {
			/**
			 * Signal whether or not the collapsible group is open.
			 */
			toggleCollapse()
			{
				this.$emit('state-changed', !this.isOpen, this.id)
			},

			/**
			 * Change content visibility based on whether the container is open or closed.
			 */
			collapseStateHandler()
			{
				this.resizeObserver?.unobserve(this.$refs.content)

				// Get content height
				this.contentHeight = this.$refs.content?.scrollHeight

				this.animating = true

				// If opening the container, set contents visibility to visible right away
				if (this.isOpen)
					this.contentsVisible = true
			},

			/**
			 * After opening or closing, change content visibility based on whether the container is open or closed.
			 */
			afterToggleCollapse()
			{
				this.animating = false

				// If closing the container, set contents visibility to hidden.
				if (!this.isOpen)
					this.contentsVisible = false

				this.resizeObserver?.observe(this.$refs.content)
			}
		},

		watch: {
			isOpen()
			{
				this.collapseStateHandler()
			}
		}
	}
</script>
