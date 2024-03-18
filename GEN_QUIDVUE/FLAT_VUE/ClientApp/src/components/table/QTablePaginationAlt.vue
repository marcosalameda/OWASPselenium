<template>
	<div class="flex-align-center">
		<nav aria-label="Page navigation">
			<ul class="e-pagination">
				<!-- BEGIN: Page navigation buttons -->
				<!-- BEGIN: First page button -->
				<li
					v-if="hasMultiplePages"
					:class="[{ disabled: !beginButtonActive || disabled }, 'page-item']"
					@click.stop.prevent="beginButtonActive ? pageHandler(1) : null">
					<a
						class="page-link"
						href=""
						aria-label="First">
						<span aria-hidden="true">
							<slot name="vbt-pagination-begin-button"> &lt;&lt; </slot>
						</span>
					</a>
				</li>
				<!-- END: First page button -->
				<!-- BEGIN: Previous page button -->
				<li
					v-if="hasMultiplePages"
					:class="[{ disabled: !prevButtonActive || disabled }, 'page-item']"
					@click.stop.prevent="prevButtonActive ? pageHandler(page - 1) : null">
					<a
						class="page-link"
						href=""
						aria-label="Previous">
						<span aria-hidden="true">
							<slot name="vbt-pagination-previous-button">&lt;</slot>
						</span>
					</a>
				</li>
				<!-- END: Previous page button -->
				<!-- BEGIN: Visible page number buttons -->
				<template v-if="hasMorePages || page > 1">
					<li :class="['e-pagination__item', { disabled: disabled }]">
						<span
							class="e-pagination__info"
							style="white-space: nowrap">
							<span>{{ page }} / </span>
							<span v-if="hasMorePages">...</span>
							<span v-else>{{ page }}</span>
						</span>
					</li>
				</template>
				<!-- END: Visible page number buttons -->
				<!-- BEGIN: Next page button -->
				<li
					v-if="hasMultiplePages"
					:class="[{ disabled: !nextButtonActive || disabled }, 'page-item']"
					@click.stop.prevent="nextButtonActive ? pageHandler(page + 1) : null">
					<a
						class="page-link"
						href=""
						aria-label="Next">
						<span aria-hidden="true">
							<slot name="vbt-pagination-next-button"> &gt; </slot>
						</span>
					</a>
				</li>
				<!-- END: Next page button -->
				<!-- END: Page navigation buttons -->
			</ul>
		</nav>
		<!-- BEGIN: Number of rows per page -->
		<template v-if="showPerPageMenu">
			<span class="i-text__label">{{ texts.rowsPerPage + ':' }}</span>
			<q-dropdown-menu
				v-if="showPerPageMenu"
				:texts="{ title: perPageLabel, label: perPageLabel }"
				:options="perPageOptionsObj"
				class="pagination-dropdown'"
				:button-classes="['dropdown-toggle']"
				:button-options="{ borderless: true }"
				:single-option-button="false"
				:disabled="disabled"
				@selected="perPageHandler($event)">
			</q-dropdown-menu>
			<!-- END: Number of rows per page -->
		</template>
	</div>
</template>

<script>
	import { defineAsyncComponent } from 'vue'

	import listFunctions from '@/mixins/listFunctions.js'

	export default {
		name: 'QTablePaginationAlt',

		emits: ['update:page', 'update:perPage'],

		components: {
			QDropdownMenu: defineAsyncComponent(() => import('@/components/QDropdownMenu.vue'))
		},

		props: {
			/**
			 * The current page number for which items are displayed in the table.
			 */
			page: {
				type: [String, Number],
				required: true
			},

			/**
			 * The number of items to display on each page of the table.
			 */
			perPage: {
				type: [String, Number],
				required: true
			},

			/**
			 * The total number of items across all pages of the table.
			 */
			total: {
				type: [String, Number],
				required: true
			},

			/**
			 * Options for the number of items to display per page, presented as a drop-down menu to the user.
			 */
			perPageOptions: {
				type: Array,
				default: () => []
			},

			/**
			 * A flag indicating whether the drop-down menu for selecting the number of items per page should be visible.
			 */
			showPerPageMenu: {
				type: Boolean,
				default: false
			},

			/**
			 * Indicates whether there are more pages available beyond the current page number.
			 */
			hasMorePages: {
				type: Boolean,
				default: false
			},

			/**
			 * Text for the drop-down option currently selected for number of items per page.
			 */
			perPageLabel: {
				type: String,
				default: ''
			},

			/**
			 * An object containing localized strings for display within the pagination component.
			 */
			texts: {
				type: Object,
				required: true
			},

			/**
			 * Whether the pagination is disabled.
			 */
			disabled: {
				type: Boolean,
				default: false
			}
		},

		expose: [],

		data() {
			return {
				start: this.page + 0,
				end: 0
			}
		},

		computed: {
			isEmpty() {
				return this.total === 0
			},

			hasMultiplePages() {
				return this.hasMorePages || this.page > 1
			},

			prevButtonActive() {
				return this.page > 1
			},

			nextButtonActive() {
				return this.hasMorePages
			},

			beginButtonActive() {
				return this.page > 1
			},

			perPageOptionsObj() {
				return listFunctions.getPerPageOptions(this.perPageOptions)
			}
		},

		methods: {
			/**
			 * Emit event to update page number (built-in method)
			 * @param index {Number}
			 */
			pageHandler(index) {
				if (!this.disabled && index >= 1 /* && index <= this.totalPages*/) {
					this.$emit('update:page', index)
				}
			},

			/**
			 * Emit event to update number of rows per page (built-in method)
			 * @param option {Object}
			 */
			perPageHandler(option) {
				if (!this.disabled)
					this.$emit('update:perPage', option)
			},

			/**
			 * Determine if string represents positive integer?
			 * @param str {String}
			 * @returns Boolean?
			 */
			isPositiveInteger(str) {
				return /^\+?(0|[1-9]\d*)$/.test(str)
			}
		}
	}
</script>
