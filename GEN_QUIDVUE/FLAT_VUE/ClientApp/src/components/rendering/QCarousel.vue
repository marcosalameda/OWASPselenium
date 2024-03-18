<template>
	<div
		:id="controlId"
		:class="['carousel-container', $attrs.class]">
		<div
			:id="`${controlId}-content`"
			class="carousel slide"
			:data-interval="autoCycleInterval"
			:data-keyboard="keyboardControllable"
			:data-pause="autoCyclePause"
			:data-ride="ride"
			:data-wrap="wrap">
			<ol
				v-if="showIndicators"
				class="carousel-indicators">
				<li
					v-for="(row, index) in mappedValues"
					:key="row.rowKey"
					:class="{ active: index === 0 }"
					:data-target="target"
					:data-slide-to="index" />
			</ol>

			<div class="carousel-inner">
				<div
					v-for="(row, index) in mappedValues"
					:key="row.rowKey"
					:class="itemClasses(index)"
					:style="itemStyle(row.slideImage?.previewData)"
					@click="onSlideClick(row)">
					<div class="carousel-content">
						<div class="carousel-caption d-none d-md-block">
							<h2 v-if="row.slideTitle">
								{{ row.slideTitle?.value }}
							</h2>

							<p v-if="row.slideSubtitle">
								{{ row.slideSubtitle?.value }}
							</p>
						</div>
					</div>
				</div>
			</div>

			<template v-if="showControls">
				<a
					class="carousel-control-prev"
					role="button"
					data-slide="prev"
					:data-target="target">
					<span
						class="carousel-control-prev-icon"
						aria-hidden="true" />
					<span class="sr-only">{{ texts.previousText }}</span>
				</a>

				<a
					class="carousel-control-next"
					:data-target="target"
					role="button"
					data-slide="next">
					<span
						class="carousel-control-next-icon"
						aria-hidden="true" />
					<span class="sr-only">{{ texts.nextText }}</span>
				</a>
			</template>
		</div>
	</div>
</template>

<script>
	import { validateTexts } from '@/mixins/genericFunctions.js'

	// The texts needed by the component.
	const DEFAULT_TEXTS = {
		previousText: 'Previous',
		nextText: 'Next'
	}

	export default {
		name: 'QCarousel',

		emits: ['row-action'],

		inheritAttrs: false,

		props: {
			/**
			 * The unique identifier for the container.
			 */
			containerId: String,

			/**
			 * The data from which we will build the carousel.
			 */
			mappedValues: {
				type: Array,
				default: () => []
			},

			/**
			 * The defined style variables.
			 */
			styleVariables: {
				type: Object,
				default: () => ({})
			},

			/**
			 * The configuration of the list.
			 */
			listConfig: {
				type: Object,
				default: () => ({})
			},

			/**
			 * The necessary strings to be used inside the component.
			 */
			texts: {
				type: Object,
				validator: (value) => validateTexts(DEFAULT_TEXTS, value),
				default: () => DEFAULT_TEXTS
			}
		},

		expose: [],

		data()
		{
			return {
				controlId: this.containerId ?? `q-carousel-${this._.uid}`
			}
		},

		computed: {
			target()
			{
				return `#${this.controlId}-content`
			},

			showIndicators()
			{
				return (this.styleVariables.showIndicators?.value || true) && this.mappedValues.length > 1
			},

			showControls()
			{
				return (this.styleVariables.showControls?.value || true) && this.mappedValues.length > 1
			},

			keyboardControllable()
			{
				return this.styleVariables.keyboardControllable?.value || true
			},

			autoCycleInterval()
			{
				return this.styleVariables.autoCycleInterval?.value ?? 5000
			},

			autoCyclePause()
			{
				return this.styleVariables.autoCyclePause?.value ?? 'hover'
			},

			ride()
			{
				return this.styleVariables.ride?.value ?? 'carousel'
			},

			wrap()
			{
				return this.styleVariables.wrap?.value || true
			}
		},

		methods: {
			/* Set the click event of each slide */
			onSlideClick(row)
			{
				var selection = window.getSelection()

				// To allow text selection without triggering the click action
				if (selection.toString().length !== 0)
					return

				// Execute default row action
				if (Object.keys(this.listConfig.rowClickAction).length > 0)
				{
					this.$emit('row-action', {
						id: this.listConfig.rowClickAction.id,
						rowKey: row.rowKey
					})
				}
			},

			itemClasses(idx)
			{
				const classes = ['carousel-item']

				if (idx === 0)
					classes.push('active')

				return classes
			},

			itemStyle(image)
			{
				return image ? `background-image: url('${image}')` : ''
			}
		}
	}
</script>
