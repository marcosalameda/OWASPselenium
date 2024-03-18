<template>
	<div
		:id="controlId"
		ref="container"
		role="combobox"
		tabindex="0"
		data-testid="dropdownContainer"
		:readonly="disabled || readonly"
		:aria-readonly="disabled || readonly"
		:class="['i-select', styleClass, customClasses]"
		@click.stop.prevent="onClick"
		@keydown.stop="onFilterKeyDown"
		@keydown.space.prevent="() => {}"
		@keyup.space="
			onClick($event);
			focusOnControl()
		">
		<select style="display: none" />
		<div
			ref="mainInput"
			class="i-select__input"
			aria-haspopup="listbox"
			:aria-expanded="overlayVisible">
			<template v-if="selectedOption">
				<div
					v-if="selectedOption.icon"
					class="i-select__input-value-icon">
					<q-icon v-bind="selectedOption.icon" />
				</div>
				<span
					class="i-select__input-value"
					data-testid="selectedValue">
					{{ getOptionLabel(selectedOption) }}
				</span>
			</template>
			<span
				v-else
				class="i-select__input-placeholder">
				<template v-if="!modelValue && !(disabled || readonly)">
					{{ texts.placeholder }}
				</template>
			</span>

			<div class="i-select__input-actions">
				<abbr
					v-if="showClear"
					class="i-select__input-clear-action"
					@keyup.enter="onClearClick"
					@click.stop.prevent="onClearClick">
					<q-icon icon="close" />
					<span class="hidden-elem">{{ texts.hiddenElem }}</span>
				</abbr>
				<q-icon
					v-if="!(disabled || readonly)"
					:icon="dropdownIcon" />
			</div>
		</div>
	</div>

	<transition
		name="transition__overlay"
		@enter="onOverlayEnter"
		@leave="onOverlayLeave">
		<div
			v-show="overlayVisible"
			:class="['i-select__dropdown-container', styleClass]"
			ref="overlayRef">
			<div
				class="i-select__dropdown"
				:title="texts.placeholder">
				<ul
					v-if="hasMore || insertEnabled"
					class="i-select__options">
					<li
						v-if="hasMore"
						ref="seeMoreAction"
						tabindex="0"
						class="i-select__element"
						:title="texts.moreOptionLabel"
						@click.stop.prevent="seeMoreAction"
						@keydown.enter.stop.prevent="seeMoreAction"
						@keydown.stop="onFilterKeyDown">
						<q-icon icon="go-to" />
						{{ texts.moreOptionLabel }}
					</li>

					<li
						v-if="insertEnabled"
						ref="insertAction"
						tabindex="0"
						class="i-select__element"
						:title="texts.insertLabel"
						@click.stop.prevent="insertAction"
						@keydown.enter.stop.prevent="insertAction"
						@keydown.stop="onFilterKeyDown">
						<q-icon icon="add" />
						{{ texts.insertLabel }}
					</li>
				</ul>

				<!-- filter input -->
				<div
					v-if="filter"
					class="i-select__search">
					<input
						type="text"
						class="i-text__field"
						data-testid="fInput"
						ref="filterInput"
						v-model="filterValue"
						autofocus
						auto-complete="off"
						:title="texts.filterPlaceholder"
						:placeholder="texts.filterPlaceholder"
						@input="searchInputChange"
						@keydown.enter.stop="focusOnControl"
						@keydown.stop="onFilterKeyDown"
						@keyup.stop="() => {}" />
					<div class="i-select__search-icon">
						<q-icon icon="search" />
					</div>
				</div>

				<div :style="{ 'max-height': scrollHeight }">
					<div
						v-if="!loaded"
						class="i-select__elements">
						<q-line-loader />
					</div>

					<ul
						v-show="loaded"
						class="i-select__elements"
						role="listbox">
						<li
							v-for="(option, i) of options"
							:key="i"
							ref="options"
							tabindex="0"
							role="option"
							:class="['i-select__element', { highlighted: activeOptionIndex === i }]"
							:title="getOptionLabel(option)"
							:aria-label="getOptionLabel(option)"
							:aria-selected="isSelected(option)"
							@click.stop.prevent="onOptionSelect($event, option, i)"
							@keydown.stop="onFilterKeyDown">
							<q-icon
								v-if="option.icon"
								v-bind="option.icon" />
							{{ getOptionLabel(option) }}
						</li>
					</ul>

					<ul
						v-if="filterValue && (!options || (options && options.length === 0)) && loaded"
						class="i-select__elements">
						<li class="i-select__element">
							{{ `${texts.emptyFilterMessage} "${filterValue}"` }}
						</li>
					</ul>
				</div>
			</div>
		</div>
	</transition>
</template>

<script>
	import Popper from 'popper.js'
	import _isEmpty from 'lodash-es/isEmpty'

	import { validateTexts } from '@/mixins/genericFunctions.js'
	import { inputSize } from '@/mixins/quidgest.mainEnums.js'
	import utils from './utils'

	// The texts needed by the component.
	const DEFAULT_TEXTS = {
		placeholder: 'Choose...',
		insertLabel: 'Insert',
		moreOptionLabel: 'See more',
		hiddenElem: 'Delete',
		filterPlaceholder: 'Search',
		emptyFilterMessage: 'No results match'
	}

	export default {
		name: 'QDropdownInput',

		emits: [
			'update:modelValue',
			'before-show',
			'before-hide',
			'show',
			'hide',
			'on-select',
			'on-search',
			'see-more',
			'insert'
		],

		inheritAttrs: false,

		props: {
			/**
			 * Unique identifier for the control.
			 */
			id: String,

			/**
			 * Searched text.
			 */
			searchedText: String,

			/**
			 * The possible value options.
			 */
			arrayOptions: Array,

			/**
			 * Model value.
			 */
			modelValue: [String, Number, Object],

			/**
			 * Dropdown options array.
			 */
			options: {
				type: Array,
				default: () => []
			},

			/**
			 * String to show in dropdown as label.
			 */
			optionLabel: {
				type: String,
				default: 'value'
			},

			/**
			 * Value in dropdown.
			 */
			optionValue: {
				type: String,
				default: 'key'
			},

			/**
			 * Necessary strings to be used in labels and buttons.
			 */
			texts: {
				type: Object,
				validator: (value) => validateTexts(DEFAULT_TEXTS, value),
				default: () => DEFAULT_TEXTS
			},

			/**
			 * Sizing class for the control
			 */
			size: {
				type: String,
				default: 'xxlarge',
				validator: (value) => _isEmpty(value) || Reflect.has(inputSize, value)
			},

			/**
			 * Height after which scrollbar should come in picture
			 */
			scrollHeight: {
				type: String,
				default: '240px'
			},

			/**
			 * To enable/disable «Has more..» link in the ctrl
			 */
			hasMore: {
				type: Boolean,
				default: false
			},

			/**
			 * To enable/disable insert link in the ctrl
			 */
			insertEnabled: {
				type: Boolean,
				default: false
			},

			/**
			 * Enable/disable search bar
			 */
			filter: {
				type: Boolean,
				default: true
			},

			/**
			 * Set when search content is loaded.
			 */
			loaded: {
				type: Boolean,
				default: true
			},

			/**
			 * Time after which search request should be sent.
			 */
			searchTimeout: {
				type: Number,
				default: 500,
				validator: (propValue) => propValue > 0
			},

			/**
			 * Whether the field is disabled.
			 */
			disabled: {
				type: Boolean,
				default: false
			},

			/**
			 * Whether the field is readonly.
			 */
			readonly: {
				type: Boolean,
				default: false
			},

			/**
			 * Whether or not the value of the control can be cleared.
			 */
			isClearable: {
				type: Boolean,
				default: true
			},

			/**
			 * Custom classes to be added to the component.
			 */
			customClasses: {
				type: [String, Array],
				default: () => []
			}
		},

		expose: [],

		data()
		{
			return {
				controlId: this.id || `dropdown-${this._.uid}`,
				styleClass: this.size ? `input-${this.size}` : '',
				filterValue: null,
				overlayVisible: false,
				hasClickListener: false,
				scrollHandler: null,
				activeOptionIndex: null,
				timer: null,
				preserveState: '',
				controlElementIndex: null,
				seeMoreElementIndex: null,
				insertElementIndex: null,
				searchbarElementIndex: null,
				firstOptionElementIndex: null,
				focusedElementIndex: null,
				optionElements: [],
				focusableElements: [],
				popper: null
			}
		},

		mounted()
		{
			if (
				this.options.length > 0 &&
				this.getSelectedOptionIndex() + 1 > 0
			)
				this.updateInternalState()

			this.focusableElements = this.getFocusableElements()
		},

		beforeUnmount()
		{
			this.unbindOutsideClickListener()

			if (this.scrollHandler)
			{
				this.scrollHandler.destroy()
				this.scrollHandler = null
			}
		},

		computed: {
			selectedOption()
			{
				const option = this.options?.find((option) => this.isSelected(option))

				if (option && this.options)
					return option
				return this.modelValue !== null && this.modelValue !== undefined
					? this.preserveState
					: null
			},

			dropdownIcon()
			{
				return this.overlayVisible ? 'collapse' : 'expand'
			},

			isFocusedOnOptionElement()
			{
				return this.focusedElementIndex >= this.firstOptionElementIndex
			},

			selectedOptionIndex()
			{
				if (this.focusedElementIndex >= this.firstOptionElementIndex)
					return this.focusedElementIndex - this.firstOptionElementIndex
				return 0
			},

			showClear()
			{
				return (
					this.isClearable &&
					((this.modelValue && !(this.disabled || this.readonly)) ||
						(this.selectedOption &&
							this.modelValue === '' &&
							!(this.disabled || this.readonly)))
				)
			},

			currentSelectedIndex()
			{
				return this.getSelectedOptionIndex()
			}
		},

		methods: {
			updateInternalState()
			{
				this.activeOptionIndex = this.getSelectedOptionIndex()
				this.preserveState = this.selectedOption
			},

			show()
			{
				if (this.overlayVisible)
					return

				this.$emit('before-show')
				this.bindOutsideClickListener()

				if (this.popper === null)
				{
					this.popper = new Popper(this.$refs.mainInput, this.$refs.overlayRef, {
						placement: 'bottom-start',
						onCreate: () => { this.overlayVisible = true },
						modifiers: {
							preventOverflow: {
								enabled: true,
								boundariesElement: 'window'
							}
						}
					})
				}
				else
					this.overlayVisible = true

				this.$nextTick().then(() => this.initFocusedElement())
			},

			hide()
			{
				if (!this.overlayVisible) return

				this.$emit('before-hide')
				this.overlayVisible = false
				this.unbindOutsideClickListener()

				this.$nextTick().then(() => this.initFocusedElement())
			},

			seeMoreAction()
			{
				this.$emit('see-more')
				this.hide()
			},

			insertAction()
			{
				this.$emit('insert')
			},

			onFilterKeyDown(event)
			{
				switch (event.which)
				{
					// down
					case 40:
						this.onDownKey(event)
						break
					// up
					case 38:
						this.onUpKey(event)
						break
					// enter and escape
					case 13:
						if (this.isFocusedOnOptionElement)
						{
							this.activeOptionIndex !== null
								? this.updateModel(
									event,
									this.getOptionValue(
										this.options[this.activeOptionIndex]
									)
								)
								: ''
							this.overlayVisible = false
							this.focusOnControl()
						}
						event.preventDefault()
						break
					case 27:
						document.getElementById(this.id).focus()
						this.overlayVisible = false
						event.preventDefault()
						break
					// tab
					case 9:
						this.activeOptionIndex !== null
							? this.updateModel(
								event,
								this.getOptionValue(
									this.options[this.activeOptionIndex]
								)
							)
							: ''
						if (this.overlayVisible)
						{
							this.focusOnControl()
							event.preventDefault()
						}
						this.hide()
						break
					default:
						this.focusOnElementIndex(this.searchbarElementIndex)
						break
				}
			},

			// handle down key press case
			onDownKey(event)
			{
				this.focusOnNextElement()

				if (this.options)
				{
					if (!this.overlayVisible && event.altKey)
					{
						this.show()
						this.activeOptionIndex = 0
					}
					else
						this.activeOptionIndex = this.selectedOptionIndex
				}

				event.preventDefault()
			},

			// handle 'up' key press
			onUpKey(event)
			{
				this.focusOnPreviousElement()
				if (this.options)
					this.activeOptionIndex = this.selectedOptionIndex

				event.preventDefault()
			},

			onClearClick(event)
			{
				this.updateModel(event, null)
				this.preserveState = null
				this.activeOptionIndex = null

				this.searchInputChange()
			},

			onClick(event)
			{
				if (
					(this.disabled || this.readonly) ||
					utils.DomHandler.hasClass(
						event.target,
						'dropdown__clear-icon'
					)
				)
					return

				if (
					!this.$refs.overlayRef ||
					!this.$refs.overlayRef.contains(event.target)
				)
				{
					if (this.overlayVisible)
						this.hide()
					else
						this.show()
				}
			},

			getOptionLabel(option)
			{
				if (this.optionLabel)
				{
					const optionLabel = utils.ObjectUtils.resolveFieldData(
						option,
						this.optionLabel
					)

					if (this.arrayOptions)
					{
						const arrayOption = this.arrayOptions.find(
							(e) => e.key === optionLabel
						)
						return arrayOption
							? arrayOption.value
							: optionLabel
					}

					return optionLabel
				}

				return option
			},

			getOptionValue(option)
			{
				return this.optionValue
					? utils.ObjectUtils.resolveFieldData(
						option,
						this.optionValue
					)
					: option
			},

			isSelected(option)
			{
				return this.modelValue === option?.key
			},

			getSelectedOptionIndex()
			{
				let selectedOptionIndex = -1

				if (this.modelValue !== null && this.options)
				{
					for (let i = 0; i < this.options.length; i++)
					{
						if (this.isSelected(this.options[i]))
						{
							selectedOptionIndex = i
							break
						}
					}
				}

				return selectedOptionIndex
			},

			// Update model value
			// from keyboard select
			updateModel(event, value)
			{
				this.$emit('update:modelValue', value)
				this.$emit('on-select', { originalEvent: event, value: value })
			},

			// on click select
			onOptionSelect(event, option, i)
			{
				let value = this.getOptionValue(option)
				this.activeOptionIndex = i
				this.updateModel(event, value)
				setTimeout(() => this.hide(), 200)

				this.focusOnControl()
			},

			onOverlayEnter()
			{
				this.bindScrollListener()

				if (this.filter)
					this.$refs.filterInput.focus()

				this.$emit('show')
			},

			onOverlayLeave()
			{
				this.unbindScrollListener()
				this.$refs.mainInput.focus()
				this.$emit('hide')
			},

			searchInputChange()
			{
				// if not receiving search text from props then only emit search
				if (this.timer)
				{
					clearTimeout(this.timer)
					this.timer = null
				}

				// emit search only when search has some value
				if (this.filterValue !== null)
				{
					this.timer = setTimeout(() => {
						this.$emit('on-search', this.filterValue)
					}, this.searchTimeout) // receiving searchTimeout as props
				}
			},

			bindScrollListener()
			{
				if (!this.scrollHandler)
				{
					this.scrollHandler =
						new utils.ConnectedOverlayScrollHandler(
							this.$refs.container,
							() => {
								if (this.overlayVisible)
									this.hide()
							}
						)
				}
				this.scrollHandler.bindScrollListener()
			},

			unbindScrollListener()
			{
				if (this.scrollHandler)
					this.scrollHandler.unbindScrollListener()
			},

			outsideClickListener(event)
			{
				if (
					this.overlayVisible &&
					this.$refs.overlayRef &&
					!this.$refs.overlayRef.contains(event.target) &&
					!this.$refs.container.contains(event.target)
				)
					this.hide()
			},

			bindOutsideClickListener()
			{
				if (!this.hasClickListener)
				{
					// Give time for the new SVG icon to be injected, so the event isn't bound while the old one is still in the DOM.
					setTimeout(() => {
						window.addEventListener('mousedown', this.outsideClickListener)
						this.hasClickListener = true
					}, 150)
				}
			},

			unbindOutsideClickListener()
			{
				window.removeEventListener('mousedown', this.outsideClickListener)
				this.hasClickListener = false
			},

			/**
			 * Selected row
			 * @param {number} index
			 * @returns
			 */
			focusOnElementIndex(index)
			{
				if (
					!this.focusableElements ||
					!Array.isArray(this.focusableElements) ||
					index === undefined ||
					index === null ||
					index < 0 ||
					index >= this.focusableElements.length
				)
					return

				let focusedElement = this.focusableElements[index]

				if (!focusedElement)
					return

				// Focus on element
				focusedElement.focus()

				// Set index
				this.focusedElementIndex = index
			},

			/**
			 * Focus on next focusable HTML element
			 */
			focusOnNextElement()
			{
				this.focusOnElementIndex(this.focusedElementIndex + 1)
			},

			/**
			 * Focus on previous focusable HTML element
			 */
			focusOnPreviousElement()
			{
				this.focusOnElementIndex(this.focusedElementIndex - 1)
			},

			/**
			 * Focus on main control HTML element
			 */
			focusOnControl()
			{
				this.focusOnElementIndex(this.controlElementIndex)
			},

			/**
			 * Focus on searchbar HTML element
			 */
			focusOnSearchbar()
			{
				this.focusOnElementIndex(this.searchbarElementIndex)
			},

			/**
			 * Get array of option HTML elements
			 */
			getOptionElements()
			{
				if (!this.$refs.options)
					return []
				return this.$refs.options
			},

			/**
			 * Get array of focusable HTML elements
			 */
			getFocusableElements()
			{
				let focusableElements = []
				let optionElements = []
				let index = 0

				if (this.$refs.container)
				{
					focusableElements.push(this.$refs.container)
					this.controlElementIndex = index
					index++
				}

				if (this.$refs.seeMoreAction)
				{
					focusableElements.push(this.$refs.seeMoreAction)
					this.seeMoreElementIndex = index
					index++
				}

				if (this.$refs.insertAction)
				{
					focusableElements.push(this.$refs.insertAction)
					this.insertElementIndex = index
					index++
				}

				if (this.$refs.filterInput)
				{
					focusableElements.push(this.$refs.filterInput)
					this.searchbarElementIndex = index
					index++
				}

				optionElements = this.getOptionElements()

				focusableElements.push(...optionElements)

				if (!_isEmpty(optionElements))
				{
					this.firstOptionElementIndex = index
					index += optionElements.length
				}

				return focusableElements
			},

			/**
			 * Get index of HTML element to focus on
			 */
			getFocusedElementIndex()
			{
				if (
					this.options &&
					Number.isInteger(this.firstOptionElementIndex) &&
					Number.isInteger(this.activeOptionIndex)
				)
					return this.firstOptionElementIndex + this.activeOptionIndex
				else if (Number.isInteger(this.searchbarElementIndex))
					return this.searchbarElementIndex
				return this.controlElementIndex
			},

			/**
			 * Initialize HTML element focusing
			 */
			initFocusedElement()
			{
				this.optionElements = this.getOptionElements()
				this.focusableElements = this.getFocusableElements()
				this.focusedElementIndex = this.getFocusedElementIndex()
			}
		},

		watch: {
			searchedText()
			{
				// If received searchedText as props
				this.filterValue = this.searchedText
			},

			modelValue()
			{
				if (
					this.options.length > 0 &&
					this.getSelectedOptionIndex() + 1 > 0
				)
					this.updateInternalState()
				else
					this.preserveState = ''
			},

			options()
			{
				if (
					this.options.length > 0 &&
					this.getSelectedOptionIndex() !== -1
				)
					this.activeOptionIndex = this.getSelectedOptionIndex()
				else
					this.activeOptionIndex = null

				this.$nextTick().then(() => this.initFocusedElement())
			},

			currentSelectedIndex(newValue)
			{
				if (newValue === -1)
					this.filterValue = ''
			}
		}
	}
</script>
