<template>
	<transition name="horizontal-collapse-show">
		<div
			v-if="isVisible"
			class="anchors">
			<template
				v-for="ctrlId in anchors"
				:key="ctrlId">
				<span
					v-if="!isTab(controls[ctrlId]) && showAnchor(controls[ctrlId])"
					:class="getClass(ctrlId)"
					@click.stop.prevent="anchorClicked(ctrlId)">
					<q-icon icon="paired" />
					{{ controls[ctrlId].label }}
				</span>
			</template>
		</div>
	</transition>
</template>

<script>
	import _isEmpty from 'lodash-es/isEmpty'

	export default {
		name: 'QAnchorContainerHorizontal',

		emits: ['focus-control'],

		inheritAttrs: false,

		props: {
			/**
			 * Whether or not the control is currently visible.
			 */
			isVisible: Boolean,

			/**
			 * The form controls.
			 */
			controls: {
				type: Object,
				default: () => ({})
			},

			/**
			 * The anchors list.
			 */
			anchors: {
				type: Array,
				default: () => []
			},

			/**
			 * The height of the header.
			 */
			headerHeight: {
				type: Number,
				default: 0
			}
		},

		expose: [],

		data()
		{
			return {
				isSelected: false,
				selectedAnchor: null,
				scrollAnchor: null
			}
		},

		mounted()
		{
			this.registerScrollSpy()
		},

		beforeUnmount()
		{
			window.removeEventListener('scroll', this.handleScroll)
		},

		methods: {
			showAnchor(ctrl)
			{
				if (ctrl.isCollapsible)
					return false

				const parentId = ctrl.parent

				if (parentId)
					return ctrl.isVisible && !_isEmpty(ctrl.label) && ctrl.anchored === true && this.showAnchor(this.controls[parentId])
				else if (this.isTab(ctrl))
					return ctrl.isVisible
				return ctrl.isVisible && !_isEmpty(ctrl.label) && ctrl.anchored === true
			},

			isTab(ctrl)
			{
				return ctrl.type === 'Tab'
			},

			// For know what anchor is clicked
			selectAnchor(event)
			{
				event.preventDefault()
				this.isSelected = !this.isSelected
			},

			setSelectedAnchor(ctrlId)
			{
				this.selectedAnchor === ctrlId
			},

			setScrollAnchor(ctrlId)
			{
				this.scrollAnchor = ctrlId
			},

			focusControl(ctrlId)
			{
				// Updates the selected anchor
				this.setSelectedAnchor(ctrlId)
				this.setScrollAnchor(ctrlId)
			},

			getClass(ctrlId)
			{
				if (this.scrollAnchor === ctrlId)
					return 'anchor-selected'
				return 'anchor-title'
			},

			anchorClicked(ctrlId)
			{
				this.$emit('focus-control', ctrlId, false, 'start')
				this.selectedAnchor = ctrlId
			},

			// To know in which anchor we are in the page according to scroll
			findActiveAnchor(ctrlId)
			{
				const isThereAnActiveSession = false
				const offset = this.headerHeight

				const target = document.getElementById(ctrlId)

				if (target)
				{
					const pos = target.getBoundingClientRect()

					if (
						!isThereAnActiveSession &&
						((pos.top > offset && pos.top < window.innerHeight / 3) || (pos.top < offset && pos.bottom > window.innerHeight / 3))
					)
					{
						if (this.selectedAnchor)
							this.selectedAnchor = ''
						else
							this.setScrollAnchor(ctrlId)

						this.isThereAnActiveSession = true
					}
				}
			},

			handleScroll()
			{
				// Looking for the first section whose the top is in the viewport.
				for (let ctrl of this.anchors)
					this.findActiveAnchor(ctrl)
			},

			registerScrollSpy()
			{
				window.addEventListener('scroll', this.handleScroll)

				// Call handleScroll on initial mount.
				this.handleScroll()
			}
		}
	}
</script>
