<template>
	<div
		:id="id"
		:class="['q-table-list', 'q-grid-table-list', { 'q-grid-table-list--readonly': $props.readonly }]">
		<div class="page-header row no-gutters justify-content-between">
			<div class="col">
				<div class="c-action-bar">
					<div class="table-title c-table__title">
						<h1>{{ config.tableTitle }}</h1>
					</div>
				</div>
			</div>
		</div>

		<div class="table-responsive-wrapper text-nowrap">
			<div class="table-responsive">
				<table :class="tableClasses">
					<thead class="c-table__head">
						<tr>
							<th class="text-center thead-actions">
								<div class="column-header-content">
									<q-icon icon="tag" />
								</div>
							</th>

							<th class="text-center thead-actions">
								<div class="column-header-content">
									<q-icon icon="actions" />
								</div>
							</th>

							<template
								v-for="column in visibleColumns"
								:key="column.name">
								<th>
									<div class="column-header-content">
										{{ column.label }}
									</div>
								</th>
							</template>
						</tr>
					</thead>

					<tbody :class="['c-table__body', { 'c-table__body--loading': !loaded }]">
						<tr
							v-if="!loaded"
							class="c-table__row-loader">
							<td :colspan="numVisibleColumns">
								<span class="c-table__row--loading-text">
									{{ texts.loading }}
								</span>
								<q-line-loader />
							</td>
						</tr>

						<template
							v-for="model in viewModels"
							:key="model.uniqueIdentifier">
							<component
								:is="component"
								history-branch-id="main"
								is-nested
								:nested-model="model"
								:id="model.uniqueIdentifier"
								:mode="rowMode(model)"
								:initial-state="getRowInitialState(model)"
								:permissions="permissions"
								@update:nested-model="rowUpdated(model)"
								@mark-for-deletion="markForDeletion(model)"
								@undo-deletion="undoDeletion(model)" />
						</template>

						<transition name="c-table-transition">
							<tr
								v-if="readonly && loaded && viewModels.length === 0"
								class="c-table__row--empty">
								<td :colspan="numVisibleColumns">
									<slot name="empty-results">
										<img
											v-if="config.resourcesPath"
											:src="`${config.resourcesPath}empty_card_container.png`"
											:alt="texts.noRecordsText" />
										{{ texts.emptyText }}
									</slot>
								</td>
							</tr>
						</transition>
					</tbody>
				</table>
			</div>
		</div>
	</div>
</template>

<script>
	export default {
		name: 'QGridTableList',

		emits: ['row-updated', 'mark-for-deletion', 'undo-deletion'],

		inheritAttrs: false,

		props: {
			/**
			 * Unique identifier for the control.
			 */
			id: String,

			/**
			 * Component name used as a slot to render each row of data within the table.
			 */
			component: {
				type: String,
				required: true
			},

			/**
			 * Name of the control or feature being used.
			 */
			name: {
				type: String,
				default: ''
			},

			/**
			 * Data object containing elements related to the table rows, which includes existing elements, new elements, and removed ones.
			 */
			data: {
				type: Object,
				default: () => ({
					Elements: [],
					NewElements: [],
					RemovedElements: []
				})
			},

			/**
			 * Array containing column definitions.
			 */
			columns: {
				type: Array,
				required: true
			},

			/**
			 * Config object with settings such as table title and form name.
			 */
			config: {
				type: Object,
				default: () => ({
					tableTitle: undefined,
					formName: undefined
				})
			},

			/**
			 * Permissions object determining what actions a user can perform on rows within the table.
			 */
			permissions: {
				type: Object,
				default: () => ({})
			},

			/**
			 * Flag indicating whether all content related to the control has been loaded.
			 */
			loaded: {
				type: Boolean,
				default: true
			},

			/**
			 * Localized texts used in the component for labels, alt texts, and other strings.
			 */
			texts: {
				type: Object,
				default: () => ({})
			},

			/**
			 * Whether the table is readonly.
			 */
			readonly: {
				type: Boolean,
				default: false
			}
		},

		expose: [],

		computed: {
			/**
			 * Array of classes to be applied to the table element.
			 */
			tableClasses()
			{
				const classes = ['c-table', 'c-table--alternate']

				if (this.readonly)
					classes.push('c-table--view')

				return classes
			},

			/**
			 * Array containing all the viewable models for the rows in the table.
			 */
			viewModels()
			{
				const rows = []

				rows.push(...(this.data?.Elements ?? []))
				rows.push(...(this.data?.NewElements ?? []))

				return rows
			},

			/**
			 * Array containing only the columns that should be visible according to their visibility property.
			 */
			visibleColumns()
			{
				return this.columns.filter(
					(column) => column.visibility === undefined || column.visibility
				)
			},

			/**
			 * The total number of visible columns within the table, including extra columns for actions.
			 */
			numVisibleColumns()
			{
				return this.visibleColumns.length + 2
			}
		},

		methods: {
			/**
			 * Emits an event to signal that a row has been updated.
			 * @param {Object} row - The row object that has been updated.
			 */
			rowUpdated(row)
			{
				this.$emit('row-updated', row)
			},

			/**
			 * Emits an event to signal that a row should be marked for deletion.
			 * @param {Object} row - The row object that should be marked for deletion.
			 */
			markForDeletion(row)
			{
				this.$emit('mark-for-deletion', row)
			},

			/**
			 * Emits an event to signal that the deletion of a row should be undone.
			 * @param {Object} row - The row object for which deletion should be undone.
			 */
			undoDeletion(row)
			{
				this.$emit('undo-deletion', row)
			},

			/**
			 * Retrieves the initial state of a given row.
			 * @param {Object} row - The row object for which the initial state is to be determined.
			 * @returns {String} The initial state of the row, or an empty string if it's not new.
			 */
			getRowInitialState(row)
			{
				return this.data.NewElements.some((r) => r === row) ? 'NEW' : ''
			},

			/**
			 * Returns the display mode for a row based on whether it is blocked or contained in the RemovedElements.
			 * @param {Object} row - The row object.
			 * @returns {String} The mode of the row, either 'SHOW' or 'EDIT'.
			 */
			rowMode(row)
			{
				return this.readonly || this.data.RemovedElements.includes(row.QPrimaryKey)
					? 'SHOW'
					: 'EDIT'
			}
		}
	}
</script>
