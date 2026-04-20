<template>
	<div class="q-table-search">
		<q-input-group
			ref="globalSearch"
			size="block">
			<q-text-field
				v-model="searchValue"
				class="q-table-search__field"
				role="searchbox"
				:aria-label="texts.searchText"
				:disabled="disabled || searchableColumns.length === 0"
				:placeholder="placeholder"
				@focusin="showDropdown"
				@keydown.down="focusOptionsList"
				@keydown.enter="searchByColumn(defaultSearchColumn, searchValue)">
				<template
					v-if="isClearBtnVisible"
					#append>
					<q-button
						borderless
						class="q-clear-btn"
						variant="ghost"
						color="neutral"
						tabindex="-1"
						:disabled="disabled"
						@click="resetQuery">
						<q-icon icon="remove" />
					</q-button>
				</template>
			</q-text-field>

			<template #append>
				<template v-if="showRefreshButton">
					<q-button
						:title="texts.searchText"
						:disabled="disabled"
						@click="searchByColumn(defaultSearchColumn, searchValue)">
						<q-icon icon="search" />
					</q-button>
				</template>

				<slot name="extra-buttons" />
			</template>
		</q-input-group>

		<div
			v-if="message.length > 0"
			class="q-table__filter-error">
			<q-icon icon="exclamation-sign" />
			{{ message }}
		</div>
	</div>

	<q-overlay
		v-model="showOptions"
		non-modal
		scroll-lock
		spy
		placement="bottom-start"
		trigger="manual"
		width="anchor"
		:anchor="$refs.globalSearch?.$el"
		:offset="2">
		<q-list
			class="q-table-search__options"
			ref="optionsList"
			selectable
			tabindex="-1"
			:items="options"
			@update:model-value="onSearchOption">
			<template #item="{ item }">
				<span :data-testid="item.id">
					{{ texts.searchText }}
					<component
						:is="item.key < 0 ? 'v-fragment' : 'span'"
						class="q-table-search__column">
						{{ item.label }}
					</component>
					{{ texts.forText }}:
					<strong>{{ searchValue }}</strong>
				</span>
			</template>
		</q-list>
	</q-overlay>
</template>

<script>
	export default {
		name: 'QTableSearch',

		emits: ['search-by-column'],

		props: {
			/**
			 * The default search column.
			 */
			defaultSearchColumn: Object,

			/**
			 * An array of columns that can be individually searched.
			 */
			searchableColumns: {
				type: Array,
				required: true
			},

			/**
			 * Placeholder text for the global search input field.
			 */
			placeholder: {
				type: String,
				default: ''
			},

			/**
			 * Flag indicating whether a refresh button should be shown next to the search input field.
			 */
			showRefreshButton: {
				type: Boolean,
				default: true
			},

			/**
			 * An object containing localized strings for displaying text within the component.
			 */
			texts: {
				type: Object,
				required: true
			},

			/**
			 * Whether the search bar is disabled.
			 */
			disabled: {
				type: Boolean,
				default: false
			}
		},

		expose: [],

		data() {
			return {
				searchValue: '',
				message: '',
				dropdownVisible: false
			}
		},

		computed: {
			/**
			 * Whether to show the options dropdown.
			 */
			showOptions: {
				get()
				{
					return this.searchableColumns.length > 1 && this.dropdownVisible
				},
				set(newVal)
				{
					this.dropdownVisible = newVal
				}
			},

			/**
			 * The items to include in the options dropdown.
			 */
			options()
			{
				const options = []

				this.searchableColumns.forEach((column, index) => {
					options.push({
						id: column.field,
						key: index,
						label: column.label
					})
				})

				// Add the option to search all columns.
				options.push({
					id: 'ALL',
					key: -1,
					label: this.texts.allFieldsText
				})

				return options
			},

			/**
			 * Whether the clear button is visible.
			 */
			isClearBtnVisible()
			{
				return this.searchValue.length > 0
			},

			/**
			 * The empty text error message.
			 */
			emptyTextMessage()
			{
				return this.texts.fieldIsRequired.replace('{0}', '')
			}
		},

		methods: {
			/**
			 * Search by a column for a value
			 * @param column {Object}
			 * @param value {String}
			 */
			searchByColumn(column, value) {
				this.hideDropdown()

				if (this.disabled || column === null || column === undefined)
					return

				// Prevent creation of empty filters
				if (value.trim().length === 0) {
					this.message = this.emptyTextMessage
					return
				}
				this.message = ''

				// Clear search bar value since a filter is being added
				this.searchValue = ''

				this.$emit('search-by-column', column, value)
			},

			/**
			 * Emit event to reset search query
			 */
			resetQuery() {
				if (this.disabled) return

				this.searchValue = ''
				this.hideDropdown()
			},

			/**
			 * Hide dropdown with suggestion methods
			 */
			hideDropdown() {
				this.dropdownVisible = false
			},

			/**
			 * Show dropdown with suggestion methods
			 */
			showDropdown() {
				this.dropdownVisible = true
			},

			/**
			 * Called when a search option is chosen.
			 * @param index The index of the searchable column
			 */
			onSearchOption(index) {
				const column = index === -1
					? null
					: this.searchableColumns[index]

				this.searchByColumn(column, this.searchValue)
				this.hideDropdown()
			},

			/**
			 * Sets the focus on the options list.
			 */
			focusOptionsList() {
				const el = this.$refs.optionsList?.$el
				if (!el)
					return

				el.focus()
				requestAnimationFrame(() => el.scrollTo({ top: 0 }))
			}
		}
	}
</script>
