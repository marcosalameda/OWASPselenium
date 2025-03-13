<template>
<div
	:tabindex="searchable ? -1 : tabindex"
	:class="{ 'multiselect': true, 'multiselect--active': isOpen, 'multiselect--disabled': disabled, 'multiselect--above': isAbove }"
	@focus="activate()"
	@blur="deactivate()"
	@keydown.self.down.prevent="pointerForward()"
	@keydown.self.up.prevent="pointerBackward()"
	@keyup.esc="deactivate()">
	<div class="multiselect__tags-wrapper">
		<div ref="tags" class="multiselect__tags">
			<template
				v-if="visibleValues.length > 0">
				<q-badge
					v-for="(option, idx) of visibleValues"
					:key="name + '_' + idx.toString()"
					variant="bold"
					removable
					@click:remove="removeElement(option)">
					{{ getOptionLabel(option) }}
				</q-badge>
			</template>
			<span
				v-if="isPlaceholderVisible"
				class="multiselect__placeholder">
					<slot name="placeholder">
							{{ placeholder }}
					</slot>
			</span>
		</div>
		<q-button
			class="multiselect__select"
			b-style="plain"
			borderless
			size="small"
			:disabled="disabled"
			@mousedown.prevent.stop="toggle()">
			<q-icon
				icon="chevron-down" />
		</q-button>
	</div>
	<transition name="multiselect">
		<div
		class="multiselect__content-wrapper"
		v-show="isOpen"
		tabindex="-1"
		@focus="activate()"
		@mousedown.prevent
		:style="{ maxHeight: optimizedHeight + 'px' }"
		ref="list">
		<ul class="multiselect__content" :style="contentStyle">
			<slot name="beforeList"></slot>
			<li v-if="multiple && max === internalValue.length">
			<span class="multiselect__option">
				<slot name="maxElements">Maximum of {{ max }} options selected. First remove a selected option to select another.</slot>
			</span>
			</li>
			<template v-if="!max || internalValue.length < max">
				<li v-for="(option, index) of filteredOptions" :key="index">
					<span
						v-if="!(option && (option.$isLabel || option.$isDisabled))"
						:class="optionHighlight(index, option)"
						@click.stop="select(option)"
						@mouseenter.self="pointerSet(index)"
						:data-select="option && option.isTag ? tagPlaceholder : selectLabelText"
						:data-selected="selectedLabelText"
						:data-deselect="deselectLabelText"
						class="multiselect__option">
						<slot 
							name="option" 
							:option="option">
							<span>
								{{ getOptionLabel(option) }}
							</span>
						</slot>
					</span>
				</li>
			</template>
			<li v-show="showNoOptions && (options.length === 0 && !search)">
			<span class="multiselect__option">
				<slot name="noOptions">List is empty.</slot>
			</span>
			</li>
		</ul>
		</div>
	</transition>
</div>
</template>

<script>
import multiselectMixin from './multiselectMixin'
import pointerMixin from './pointerMixin'

export default {
name: 'vue-multiselect',

mixins: [multiselectMixin, pointerMixin],

props: {
	/**
	 * name attribute to match optional label element
	 * @default ''
	 * @type {String}
	 */
	name: {
		type: String,
		default: ''
	},

	/**
	 * String to show when pointing to an option
	 * @default 'Press enter to select'
	 * @type {String}
	 */
	selectLabel: {
		type: String,
		default: 'Press enter to select'
	},

	/**
	 * String to show next to selected option
	 * @default 'Selected'
	 * @type {String}
	 */
	selectedLabel: {
		type: String,
		default: 'Selected'
	},

	/**
	 * String to show when pointing to an already selected option
	 * @default 'Press enter to remove'
	 * @type {String}
	 */
	deselectLabel: {
		type: String,
		default: 'Press enter to remove'
	},

	/**
	 * Decide whether to show pointer labels
	 * @default true
	 * @type {Boolean}
	 */
	showLabels: {
		type: Boolean,
		default: true
	},

	/**
	 * Limit the display of selected options. The rest will be hidden within the limitText string.
	 * @default 99999
	 * @type {Integer}
	 */
	limit: {
		type: Number,
		default: 99999
	},

	/**
	 * Sets maxHeight style value of the dropdown
	 * @default 300
	 * @type {Integer}
	 */
	maxHeight: {
		type: Number,
		default: 300
	},

	/**
	 * Function that process the message shown when selected
	 * elements pass the defined limit.
	 * @default 'and * more'
	 * @param {Int} count Number of elements more than limit
	 * @type {Function}
	 */
	limitText: {
		type: Function,
		default: count => `and ${count} more`
	},

	/**
	 * Disables the multiselect if true.
	 * @default false
	 * @type {Boolean}
	 */
	disabled: {
		type: Boolean,
		default: false
	},

	/**
	 * Fixed opening direction
	 * @default ''
	 * @type {String}
	 */
	openDirection: {
		type: String,
		default: ''
	},

	/**
	 * Shows slot with message about empty options
	 * @default true
	 * @type {Boolean}
	 */
	showNoOptions: {
		type: Boolean,
		default: true
	},

	tabindex: {
		type: Number,
		default: 0
	}
},
computed: {
	isPlaceholderVisible () {
		return !this.internalValue.length
	},

	visibleValues () {
		return this.multiple ? this.internalValue.slice(0, this.limit) : []
	},

	deselectLabelText () {
		return this.showLabels ? this.deselectLabel : ''
	},

	selectLabelText () {
		return this.showLabels ? this.selectLabel : ''
	},

	selectedLabelText () {
		return this.showLabels ? this.selectedLabel : ''
	},

	contentStyle () {
		return this.options.length
			? { display: 'inline-block' }
			: { display: 'block' }
	},

	isAbove () {
		if (this.openDirection === 'above' || this.openDirection === 'top') {
			return true
		} else if (
			this.openDirection === 'below' ||
			this.openDirection === 'bottom'
		) {
			return false
		} else {
			return this.preferredOpenDirection === 'above'
		}
	}
}
}
</script>
