<template>
	<tr
		v-bind="$attrs"
		:index="rowIndex">
		<slot
			name="columns"
			:columns="columns">
			<th
				v-for="column in columns"
				:key="column.name"
				:class="columnClasses(column)"
				:aria-sort="getTableColumnSort(column, columnSorting, true)"
				:data-column-name="column.name"
				@mousedown="onColumnMouseDown()"
				@mousemove="onColumnMouseMove()"
				@mouseup="onColumnMouseUp()">
				<!-- BEGIN: TABLE LIST TOTALIZER TITLE COLUMN -->
				<div
					v-if="isTotalizerColumn(column)"
					class="column-header-content">
					<q-icon icon="sigma" />
				</div>
				<!-- BEGIN: FOR: TABLE LIST ROW ACTIONS -->
				<div
					v-else-if="isActionsColumn(column) || isDragAndDropColumn(column)"
					class="column-header-content">
					<q-icon icon="actions" />
					<span class="hidden-elem">{{ column.label }}</span>
				</div>
				<!-- END: FOR: TABLE LIST ROW ACTIONS -->
				<!-- BEGIN: Checklist header cell content -->
				<div
					v-else-if="isChecklistColumn(column)"
					class="column-header-content">
					<slot
						:name="'column_' + getCellSlotName(column)"
						:column="column">
						<q-action-list 
							:disabled="rowCount < 1"
							:dropdown-options="dropdownOptions"
							:texts="texts"
							:actions="checklistActions"
							data-table-action-selected="false"
							tabindex="-1"
							@click:action="checklistAction">
							<template #customDropdownButton>
								<q-table-checklist-checkbox
									:value="false"
									:table-name="tableName"
									style="display: flex"
									readonly />
							</template>
						</q-action-list>
					</slot>
				</div>
				<!-- END: Checklist header cell content -->
				<!-- BEGIN: Extended row action column -->
				<div
					v-else-if="isExtendedActionsColumn(column)"
					class="extended-row-header">
					<slot
						:name="getCellSlotName(column)"
						:column="column">
						<span
							v-if="hasExtendedAction('remove-reset')"
							:key="column.name">
							<q-button
								b-style="secondary"
								:title="texts.resetText"
								data-table-action-selected="false"
								tabindex="-1"
								@click="$emit('unselect-all-rows')">
								<q-icon icon="reset" />
							</q-button>
						</span>
					</slot>
				</div>
				<!-- END: Extended row action column -->
				<!-- BEGIN: Header cell content -->
				<div
					v-else
					class="column-header-content">
					<!-- BEGIN: Header cell title -->
					<div class="column-header-text">
						<slot
							:name="'column_' + getCellSlotName(column)"
							:column="column">
							{{ column.label }}
						</slot>
						<q-table-column-filters
							v-if="(allowColumnFilters && isSearchableColumn(column)) || (allowColumnSort && isSortableColumn(column))"
							:allow-column-filters="allowColumnFilters"
							:allow-column-sort="allowColumnSort"
							:allow-advanced-filters="allowAdvancedFilters"
							:column="column"
							:disabled="disabled"
							:filter="filters[columnFullName(column)]"
							:filter-operators="filterOperators"
							:searchable-columns="searchableColumns"
							:sort-direction="getTableColumnSort(column, columnSorting)"
							:table-name="tableName"
							:texts="texts"
							:locale="locale"
							@update-sort="(...args) => $emit('update-sort', ...args)"
							@edit-column-filter="(...args) => $emit('edit-column-filter', ...args)"
							@remove-column-filter="(...args) => $emit('remove-column-filter', ...args)"
							@add-advanced-filter="(...args) => $emit('add-advanced-filter', ...args)"
							@show-advanced-filters="(...args) => $emit('show-advanced-filters', ...args)" />
					</div>
					<!-- END: Header cell title -->
				</div>
				<!-- END: Header cell content -->
			</th>
		</slot>
	</tr>
</template>

<script>
	import has from 'lodash-es/has'
	import includes from 'lodash-es/includes'

	import searchFilterDataModule from '@/api/genio/searchFilterData'
	import listFunctions from '@/mixins/listFunctions.js'

	import QTableColumnFilters from './QTableColumnFilters.vue'

	export default {
		name: 'QTableHeader',

		emits: [
			'column-resize',
			'update-sort',
			'unselect-all-rows',
			'edit-column-filter',
			'remove-column-filter',
			'add-advanced-filter',
			'show-advanced-filters',
			'check-all-rows',
			'check-current-page-rows',
			'check-none-rows'
		],

		components: {
			QTableColumnFilters,
		},

		inheritAttrs: false,

		props: {
			/**
			 * Localized text strings to be used within the table header component.
			 */
			texts: {
				type: Object,
				required: true
			},

			/**
			 * An array containing column configurations, each object defines a column's properties in the table.
			 */
			columns: {
				type: Array,
				default: () => []
			},

			/**
			 * The object representing the current column sorting.
			 */
			columnSorting: {
				type: Object,
				default: () => ({})
			},

			/**
			 * The unique name associated with the table instance.
			 */
			tableName: {
				type: String,
				default: ''
			},

			/**
			 * Flag indicating whether the table is currently in read-only mode.
			 */
			readonly: {
				type: Boolean,
				default: false
			},

			/**
			 * Flag indicating whether checkboxes should be presented in each row.
			 */
			checkboxRows: {
				type: Boolean,
				default: false
			},

			/**
			 * Flag indicating whether filters are allowed on table columns.
			 */
			allowColumnFilters: {
				type: Boolean,
				default: false
			},

			/**
			 * Flag indicating whether sorting is allowed on table columns.
			 */
			allowColumnSort: {
				type: Boolean,
				default: false
			},
			
			/**
			 * Flag indicating whether advanced filters are allowed in the table.
			 */
			allowAdvancedFilters: {
				type: Boolean,
				default: false
			},

			/**
			 * An array of columns that can be used for search filtering.
			 */
			searchableColumns: {
				type: Array,
				default: () => []
			},

			/**
			 * The details of existing filters currently applied on the table columns.
			 */
			filters: {
				type: Object,
				default: () => ({})
			},

			/**
			 * A predefined set of operator definitions used in filter conditions.
			 */
			filterOperators: {
				type: Object,
				default: () => searchFilterDataModule.operators.elements
			},

			/**
			 * Flag indicating whether server-side processing is used for table operations like sorting and filtering.
			 */
			serverMode: {
				type: Boolean,
				default: false
			},

			/**
			 * The DOM element that wraps the table, used for managing the positioning of the table header.
			 */
			tableContainerElem: {
				type: Object,
				default: null
			},

			/**
			 * The total count of rows in the table.
			 */
			rowCount: {
				type: Number,
				default: 0
			},

			/**
			 * Whether the header content is disabled.
			 */
			disabled: {
				type: Boolean,
				default: false
			},

			/**
			 * The row index. Can be a multi-index which has the index for each level (in tree tables) separated by underscores.
			 */
			rowIndex: {
				type: String,
				default: 'h'
			},

			/**
			 * Object with properties for the state:
			 * isNavigated : Indicate whether the header is navigated to (for keyboard and mouse operations).
			 */
			headerRow: {
				type: Object,
				default: () => ({
					isNavigated: false
				})
			},

			/**
			 * Current system locale
			 */
			locale: {
				type: String,
				default: 'en-US'
			}
		},

		expose: [],

		data() {
			return {
				selectAllRows: false,
				mouseDown: false,
				mouseMove: false
			}
		},

		inject: [
			'getCellSlotName',
			'isSortableColumn',
			'isSearchableColumn',
			'isActionsColumn',
			'isChecklistColumn',
			'isDragAndDropColumn',
			'isExtendedActionsColumn',
			'isTotalizerColumn',
			'hasExtendedAction',
			'columnFullName'
		],

		computed: {
			/**
			 * Computes the default options for the dropdown
			 */
			dropdownOptions() {
				return {
					icon: 'unchecked',
					borderless: true,
					bStyle: 'tertiary',
					placement: 'bottom-start',
					class: 'q-dropdown-toggle'
				}
			},

			/**
			 * Computes the actions/options for the dropdown
			 */
			checklistActions() {
				return [
					{ id: 'all', title: this.texts.allRecordsText, icon: { icon: 'apply' } },
					{ id: 'page', title: this.texts.currentPageText, icon: { icon: 'check' } },
					{ id: 'none', title: this.texts.noneText, icon: { icon: 'remove' } },
				]
			},
		},

		methods: {
			getTableColumnSort: listFunctions.getTableColumnSort,

			/**
			 * Get CSS classes for this column
			 * @param column {Object}
			 * @returns String
			 */
			columnClasses(column) {
				let classes = []

				//Decide text alignment class
				let alignments = ['text-justify', 'text-right', 'text-left', 'text-center']
				if (has(column, 'columnTextAlignment') && includes(alignments, column.columnTextAlignment)) {
					classes.push(column.columnTextAlignment)
				}

				//Adding user defined classes to rows
				if (has(column, 'columnHeaderClasses')) {
					classes.push(column.columnHeaderClasses)
				}

				return classes.join(' ')
			},

			/**
			 * Fired on mouse down on header element
			 */
			onColumnMouseDown() {
				this.mouseDown = true
				this.mouseMove = false
			},

			/**
			 * Fired on mouse move on header element
			 */
			onColumnMouseMove() {
				this.mouseMove = true
			},

			/**
			 * Fired on mouse up on header element
			 */
			onColumnMouseUp() {
				if (this.mouseDown && this.mouseMove) {
					this.$emit('column-resize')
				}
				this.mouseDown = false
				this.mouseMove = false
			},

			/**
			 * Executes the action selected in the dropdown
			 * @param $event the click event from the dropdown
			 */
			checklistAction($event) {
				const emit = $event.id === 'all' ? 'check-all-rows' : 
					$event.id === 'page' ? 'check-current-page-rows' : 'check-none-rows'
				this.$emit(emit)	
			}
		}
	}
</script>
