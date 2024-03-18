<template>
	<div class="flex-align-center">
		<nav aria-label="Page navigation">
			<ul class="e-pagination">
				<!-- BEGIN: Page navigation buttons -->
				<!-- BEGIN: First page button -->
				<li
					v-if="beginButtonVisible"
					:class="['e-pagination__item', { disabled: disabled }]"
					@click.stop.prevent="pageHandler(1)">
					<a
						class="e-pagination__link"
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
					v-if="prevButtonVisible"
					:class="['e-pagination__item', { disabled: disabled }]"
					@click.stop.prevent="pageHandler(page - 1)">
					<a
						class="e-pagination__link"
						href=""
						aria-label="Previous">
						<span aria-hidden="true">
							<slot name="vbt-pagination-previous-button"> &lt; </slot>
						</span>
					</a>
				</li>
				<!-- END: Previous page button -->
				<!-- BEGIN: Visible page number buttons -->
				<template v-if="totalPages > 1">
					<li
						v-for="index in range"
						:key="index"
						:class="['e-pagination__item', { active: index === page, disabled: disabled }]"
						@click.stop.prevent="pageHandler(index)">
						<a
							class="e-pagination__link"
							href="">
							{{ index }}
						</a>
					</li>
				</template>
				<!-- END: Visible page number buttons -->
				<!-- BEGIN: Next page button -->
				<li
					v-if="nextButtonVisible"
					:class="['e-pagination__item', { disabled: disabled }]"
					@click.stop.prevent="pageHandler(page + 1)">
					<a
						class="e-pagination__link"
						href=""
						aria-label="Next">
						<span aria-hidden="true">
							<slot name="vbt-pagination-next-button"> &gt; </slot>
						</span>
					</a>
				</li>
				<!-- END: Next page button -->
				<!-- BEGIN: Last page button -->
				<li
					v-if="endButtonVisible"
					:class="['e-pagination__item', { disabled: disabled }]"
					@click.stop.prevent="pageHandler(totalPages)">
					<a
						class="e-pagination__link"
						href=""
						aria-label="Last">
						<span aria-hidden="true">
							<slot name="vbt-pagination-end-button"> &gt;&gt; </slot>
						</span>
					</a>
				</li>
				<!-- END: Last page button -->
				<!-- END: Page navigation buttons -->
			</ul>
		</nav>
		<!-- BEGIN: Number of rows per page -->
		<template v-if="showPerPageMenu">
			<span class="i-text__label">{{ texts.rowsPerPage + ':' }}</span>
			<q-dropdown-menu
				:texts="{ title: perPageLabel, label: perPageLabel }"
				:options="perPageOptionsObj"
				class="pagination-dropdown"
				:button-classes="['dropdown-toggle']"
				:button-options="{ borderless: true }"
				:single-option-button="false"
				:disabled="disabled"
				@selected="perPageHandler($event)">
			</q-dropdown-menu>
			<!-- END: Number of rows per page -->
			<!-- BEGIN: Go-to-page box (unused) -->
			<div
				v-if="showGoToPage"
				class="input-group col-sm-2">
				<input
					type="number"
					class="form-control"
					min="1"
					step="1"
					:max="totalPages"
					:placeholder="texts.gotToPage"
					@keyup.enter="onGotoPage"
					v-model.number="goToPage" />
			</div>
			<!-- END: Go-to-page box (unused) -->
		</template>
	</div>
</template>

<script>
	import { defineAsyncComponent } from 'vue'
	import range from 'lodash-es/range'

	import listFunctions from '@/mixins/listFunctions.js'

	export default {
		name: 'QTablePagination',

		emits: ['update:page', 'update:perPage'],

		components: {
			QDropdownMenu: defineAsyncComponent(() => import('@/components/QDropdownMenu.vue'))
		},

		props: {
			/**
			 * The current page number displayed and managed by the pagination component.
			 */
			page: {
				type: [String, Number],
				required: true
			},

			/**
			 * The number of items (rows) to display on each page.
			 */
			perPage: {
				type: [String, Number],
				required: true
			},

			/**
			 * The total number of items (rows) available across all pages.
			 */
			total: {
				type: [String, Number],
				required: true
			},

			/**
			 * The number of visible page buttons to be displayed in the pagination component at any given time.
			 */
			numVisibilePaginationButtons: {
				type: [String, Number],
				default: 5
			},

			/**
			 * Options determining the available selections for items per page.
			 */
			perPageOptions: {
				type: Array,
				default: () => []
			},

			/**
			 * Flag indicating whether to show the control for navigating to a specific page number directly.
			 */
			showGoToPage: {
				type: Boolean,
				default: false
			},

			/**
			 * Flag indicating whether to show the dropdown menu for selecting the number of items per page.
			 */
			showPerPageMenu: {
				type: Boolean,
				default: false
			},

			/**
			 * Text label accompanying the per page options dropdown; it typically reflects the currently selected per-page value.
			 */
			perPageLabel: {
				type: String,
				default: ''
			},

			/**
			 * Localized text strings to be used for pagination-related content such as button labels.
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
				end: 0,
				goToPage: ''
			}
		},

		mounted() {
			this.calculatePageRange(true)
		},

		computed: {
			totalPages() {
				return Math.ceil(this.total / this.perPage)
			},

			range() {
				return range(this.start, this.end + 1)
			},

			isEmpty() {
				return this.total === 0
			},

			prevButtonVisible() {
				if (this.totalPages < 2 || this.page === 1) {
					return false
				}
				return true
			},

			nextButtonVisible() {
				if (this.totalPages < 2 || this.page === this.totalPages) {
					return false
				}
				return true
			},

			beginButtonVisible() {
				if (this.totalPages < 2 || this.page < 3) {
					return false
				}
				return true
			},

			endButtonVisible() {
				if (this.totalPages < 2 || this.totalPages - this.page < 2) {
					return false
				}
				return true
			},

			perPageOptionsObj() {
				return listFunctions.getPerPageOptions(this.perPageOptions)
			}
		},

		methods: {
			/**
			 * Go to page set in goToPage property (built-in method)
			 */
			onGotoPage() {
				if (this.disabled || this.goToPage === '' || !this.isPositiveInteger(this.goToPage)) {
					return
				}

				//Handle the new page
				this.pageHandler(this.goToPage)
			},

			/**
			 * Emit event to update page number (built-in method)
			 * @param index {Number}
			 */
			pageHandler(index) {
				if (!this.disabled && index >= 1 && index <= this.totalPages) {
					this.$emit('update:page', index)
				}
			},

			/**
			 * Emit event to update number of rows per page (built-in method)
			 * @param option {Object}
			 */
			perPageHandler(option) {
				if (!this.disabled) this.$emit('update:perPage', option)
			},

			/**
			 * Calculate start od end pages for visible page buttons
			 */
			calculatePageRange() {
				//Skip calculating if all pages can be shown
				if (this.totalPages <= this.numVisibilePaginationButtons) {
					this.start = 1
					this.end = this.totalPages
					return
				}

				//Calculate start of range
				this.start = this.page - Math.floor(this.numVisibilePaginationButtons / 2)
				this.start = Math.max(this.start, 1)

				//Calculate end of range
				this.end = this.start + this.numVisibilePaginationButtons - 1
				if (this.end > this.totalPages) {
					this.end = this.totalPages
					this.start = this.end - this.numVisibilePaginationButtons + 1
				}
			},

			/**
			 * Determine if string represents positive integer?
			 * @param str {String}
			 * @returns Boolean?
			 */
			isPositiveInteger(str) {
				return /^\+?(0|[1-9]\d*)$/.test(str)
			}
		},

		watch: {
			page() {
				this.calculatePageRange()
			},

			rowCount() {
				this.calculatePageRange()
			},

			totalPages() {
				this.calculatePageRange()
			}
		}
	}
</script>
