<template>
	<div class="dropdown">
		<q-button
			:id="buttonId"
			ref="dropdownBtn"
			class="dropdown-toggle"
			:disabled="readonly || disableSelector"
			b-style="tertiary"
			:title="texts.columnActionsText"
			data-table-action-selected="false"
			tabindex="-1"
			@click="openOverlay"
			@focusout="onFocusOut"
			:aria-expanded="showOverlay"
			aria-haspopup="true">
			<q-icon icon="unchecked" />
		</q-button>

		<q-overlay
			v-model="showOverlay"
			ref="overlayComponent"
			:anchor="overlayAnchor"
			placement="bottom-start"
			trigger="manual"
			persistent
			arrow
			@keydown="onKeydown"
			@focusout="onFocusOut"
			role="menu">
			<div
				ref="dropdownRef"
				tabindex="-1"
				class="table-selector-menu">
				<q-button
					role="menuitem"
					b-style="tertiary"
					block
					class="table-selector-item"
					:label="texts.allRecordsText"
					:title="texts.allRecordsText"
					@click="$emit('check-all-rows')">
					<q-icon icon="apply" />
				</q-button>

				<q-button
					role="menuitem"
					b-style="tertiary"
					block
					class="table-selector-item"
					:label="texts.currentPageText"
					:title="texts.currentPageText"
					@click="$emit('check-current-page-rows')">
					<q-icon icon="check" />
				</q-button>

				<q-button
					role="menuitem"
					b-style="tertiary"
					block
					class="table-selector-item"
					:label="texts.noneText"
					:title="texts.noneText"
					@click="$emit('check-none-rows')">
					<q-icon icon="remove" />
				</q-button>
			</div>
		</q-overlay>
	</div>
</template>

<script>
	import { dropdownIsFocused } from '@/mixins/genericFunctions'
	import listFunctions from '@/mixins/listFunctions.js'

	export default {
		name: 'QTableSelector',

		emits: [
			'check-all-rows',
			'check-current-page-rows',
			'check-none-rows'
		],

		props: {
			/**
			 * An object containing localized text strings for actions related to selection of table rows.
			 */
			texts: {
				type: Object,
				required: true
			},

			/**
			 * A boolean indicating whether the table is in a read-only state, which can disable the selector functionality.
			 */
			readonly: {
				type: Boolean,
				default: false
			},

			/**
			 * A boolean that indicates if the row selection options should be disabled, irrespective of table read-only state.
			 */
			disableSelector: {
				type: Boolean,
				default: false
			},

			/**
			 * The unique name associated with the table instance.
			 */
			tableName: {
				type: String,
				default: ''
			},
		},

		expose: [],

		data() {
			return {
				showOverlay: false
			}
		},

		computed: {
			buttonId() {
				return this.getTableSelectorDropdownToggleId(this.tableName)
			},

			overlayAnchor() {
				return `#${this.buttonId}`
			}
		},

		methods: {
			getTableSelectorDropdownToggleId: listFunctions.getTableSelectorDropdownToggleId,

			onFocusOut(event) {
				if (!this.$refs.dropdownRef || !this.$refs.dropdownBtn?.$el) return

				if (dropdownIsFocused(this.$refs.dropdownRef, this.$refs.dropdownBtn.$el, event)) {
					event.preventDefault()
					event.stopPropagation()

					return
				}

				this.closeOverlay()
			},

			onKeydown(event) {
				if (!event.key) return
				if ('Escape' === event.key)
					this.closeOverlay()
			},

			openOverlay() {
				this.showOverlay = true

				// Wait for the dropdown to exist before focusing on it
				this.$nextTick().then(() => {
					this.focusOverlay()
				})
			},

			closeOverlay() {
				this.showOverlay = false
				this.focusDropdownBtn()
			},

			focusOverlay() {
				this.$refs.dropdownRef?.focus()
			},

			focusDropdownBtn() {
				this.$refs.dropdownBtn?.$el?.focus()
			}
		}
	}
</script>
