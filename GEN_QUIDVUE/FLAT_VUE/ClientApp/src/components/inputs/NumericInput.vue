<template>
	<component
		:is="wrapperComponent"
		:size="wrapperSize">
		<template
			v-if="currencySymbol"
			#prepend>
			<span>{{ currencySymbol }}</span>
		</template>

		<q-text-field
			:model-value="displayValue"
			:id="controlId"
			ref="input"
			role="textbox"
			:class="styleClass"
			:readonly="readonly"
			:disabled="disabled"
			:required="isRequired"
			:aria-labelledby="labelId"
			:size="inputSize"
			:placeholder="inputPlaceholder"
			@keydown="onKeydownFormat"
			@keyup="onKeyup"
			@paste="onPasteFormat"
			@drop="onDropFormat"
			@focus="onFocus"
			@focusout="onFocusout"
			@update:model-value="setCtrlValue" />
	</component>
</template>

<script>
	import _isEmpty from 'lodash-es/isEmpty'

	import { validateTexts } from '@/mixins/genericFunctions.js'
	import { inputSize } from '@/mixins/quidgest.mainEnums.js'

	// The texts needed by the component.
	const DEFAULT_TEXTS = {
		emptyText: 'empty'
	}

	export default {
		name: 'QNumeric',

		emits: [
			'update:modelValue',
			'focus',
			'focusout'
		],

		inheritAttrs: false,

		props: {
			/**
			 * Unique identifier for the control.
			 */
			id: String,

			/**
			 * The testing identifier
			 */
			dataTestid: String,

			/**
			 * For accessibility (aria-labelledby)
			 * ID, which refers to element that have the text needed for labeling
			 */
			labelId: String,

			/**
			 * Holds the selection result
			 */
			modelValue: {
				type: Number,
				default: 0
			},

			/**
			 * Size of the input
			 */
			size: {
				type: String,
				validator: (value) => _isEmpty(value) || Reflect.has(inputSize, value)
			},

			/**
			 * Whether the field is readonly.
			 */
			readonly: {
				type: Boolean,
				default: false
			},

			/**
			 * Whether the field is disabled.
			 */
			disabled: {
				type: Boolean,
				default: false
			},

			/**
			 * For mandatory input
			 */
			isRequired: {
				type: Boolean,
				default: false
			},

			/**
			 * Currency required
			 */
			isCurrency: {
				type: Boolean,
				default: false
			},

			/**
			 * Select currency symbol
			 */
			currencySymbol: {
				type: String,
				default: ''
			},

			/**
			 * Thousand seperator symbol
			 */
			thousandsSeparator: {
				type: String,
				default: ''
			},

			/**
			 * Decimal point symbol
			 */
			decimalPoint: {
				type: String,
				default: '.'
			},

			/**
			 * Maximum integers digits count
			 */
			maxIntegers: {
				type: Number,
				default: 10
			},

			/**
			 * Maximum decimals digits count
			 */
			maxDecimals: {
				type: Number,
				default: 0
			},

			/**
			 * Custom classes to be added to the field
			 */
			classes: {
				type: Array,
				default: () => []
			},

			/**
			 * Whether or not to show a placeholder when the field is empty
			 */
			showEmptyMessage: {
				type: Boolean,
				default: false
			},

			/**
			 * Necessary strings.
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
			// Work out the unicode character for the integer and decimal placeholder.
			// Decimals
			let u_dec =
					'\\u' +
					('0000' + this.decimalPoint.charCodeAt(0).toString(16)).slice(-4),
				regex_dec_num = new RegExp('[^' + u_dec + '0-9]', 'g'),
				regex_dec = new RegExp(u_dec, 'g'),
				// Integer
				u_int =
					'\\u' +
					('0000' + this.thousandsSeparator.charCodeAt(0).toString(16)).slice(-4),
				regex_int_num = new RegExp('[^' + u_int + '0-9]', 'g'),
				regex_int = new RegExp(u_int, 'g');

			return {
				controlId: this.id || `q-numeric-${this._.uid}`,
				styleClass: [
					'q-numeric-input',
					...this.classes
				],

				displayValue: '',

				cursorPosition: -(this.maxDecimals + 1),

				regex_dec_num: regex_dec_num,
				regex_dec: regex_dec,
				regex_int_num: regex_int_num,
				regex_int: regex_int,

				init: ('' + this.modelValue).indexOf('.') ? true : false,

				onFocusInputValue: undefined,

				/**
				 * Substitutions for keydown keycodes.
				 * Allows conversion from e.which to ascii characters.
				 */
				keydown: {
					codes: {
						46: 127,
						188: 44,
						109: 45,
						190: 46,
						191: 47,
						192: 96,
						220: 92,
						222: 39,
						221: 93,
						219: 91,
						173: 45,
						187: 61, //IE Key codes
						186: 59, //IE Key codes
						189: 45, //IE Key codes
						110: 46, //IE Key codes
					},
					shifts: {
						96: '~',
						49: '!',
						50: '@',
						51: '#',
						52: '$',
						53: '%',
						54: '^',
						55: '&',
						56: '*',
						57: '(',
						48: ')',
						45: '_',
						61: '+',
						91: '{',
						93: '}',
						92: '|',
						59: ':',
						39: '\'',
						44: '<',
						46: '>',
						47: '?',
					}
				}
			}
		},

		computed: {
			inputPlaceholder()
			{
				return this.showEmptyMessage ? this.texts.emptyText : undefined
			},

			wrapperComponent()
			{
				return this.currencySymbol ? 'q-input-group' : 'v-fragment'
			},

			/**
			 * Determines the size of the wrapper component,
			 * depending on whether the currency symbol is shown or not.
			 */
			wrapperSize()
			{
				return this.currencySymbol ? this.size : undefined
			},

			/**
			 * Determines the size of the main input,
			 * depending on whether the currency symbol is shown or not.
			 */
			inputSize()
			{
				return this.currencySymbol ? 'block' : this.size
			}
		},

		mounted()
		{
			this.setCtrlValue(this.modelValue)

			if (this.showEmptyMessage)
				this.setInputValue('')
		},

		methods: {
			setInputValue(newValue)
			{
				this.displayValue = newValue
			},

			/**
			 * Define the valHook to return normalised field data against an input which has been tagged by the number formatte
			 * @return mixed : Returns the value that was written to the element as a javascript number, or undefined
			 */
			getCtrlValue()
			{
				// Remove formatting, and return as number.
				if (this.displayValue === '')
					return '0';

				// Convert to a number.
				let num = +this.displayValue
					.replace(this.regex_dec_num, '')
					.replace(this.regex_dec, '.');

				// If we've got a finite number, return it.
				// Otherwise, simply return 0.
				// Return as a string... thats what we're
				// used to with .val()
				return (
					(this.displayValue.indexOf('-') === 0 ? '-' : '') +
					(isFinite(num) ? num : 0)
				);
			},

			/**
			 * A valhook which formats a number when run against an input which has been tagged by the number formatter
			 */
			setCtrlValue(newValue)
			{
				let num = this.formatNumber(
					newValue,
					this.maxIntegers,
					this.maxDecimals,
					this.decimalPoint,
					this.thousandsSeparator
				);
				this.setInputValue(num);
			},

			/**
			 * Method for selecting a range of characters in an input/textarea.
			 *
			 * @param int rangeStart			: Where we want the selection to start.
			 * @param int rangeEnd				: Where we want the selection to end.
			 *
			 * @return void;
			 */
			setSelectionRange(rangeStart, rangeEnd)
			{
				// Check which way we need to define the text range.
				if (this.$refs.input.inputRef.createTextRange)
				{
					let range = this.$refs.input.inputRef.createTextRange();
					range.collapse(true);
					range.moveStart('character', rangeStart);
					range.moveEnd('character', rangeEnd - rangeStart);
					range.select();
				}

				// Alternate setSelectionRange method for supporting browsers.
				else if (this.$refs.input.inputRef.setSelectionRange) {
					this.$refs.input.inputRef.focus();
					this.$refs.input.inputRef.setSelectionRange(rangeStart, rangeEnd);
				}
			},

			/**
			 * Get the selection position for the given part.
			 *
			 * @param string part			: Options, 'Start' or 'End'. The selection position to get.
			 *
			 * @return int : The index position of the selection part.
			 */
			getSelection(part)
			{
				var pos = this.displayValue.length;

				// Work out the selection part.
				part = part.toLowerCase() === 'start' ? 'Start' : 'End';

				if (document.selection)
				{
					// The current selection
					let range = document.selection.createRange(),
						stored_range,
						selectionStart,
						selectionEnd;
					// We'll use this as a 'dummy'
					stored_range = range.duplicate();
					// Select all text
					//stored_range.moveToElementText( this );
					stored_range.expand('textedit');
					// Now move 'dummy' end point to end point of original range
					stored_range.setEndPoint('EndToEnd', range);
					// Now we can calculate start and end points
					selectionStart = stored_range.text.length - range.text.length;
					selectionEnd = selectionStart + range.text.length;
					return part === 'Start' ? selectionStart : selectionEnd;
				} else if (typeof this.$refs.input.inputRef['selection' + part] !== 'undefined') {
					pos = this.$refs.input.inputRef['selection' + part];
				}
				return pos;
			},

			onFocus()
			{
				this.$refs.input.inputRef.select()
				this.$emit('focus', this.$refs.input.inputRef)
				this.onFocusInputValue = this.displayValue
			},

			onFocusout()
			{
				// In cases when we don't show the negative value (in sequential fields) we won't react to focusout
				var currentInputValue = this.displayValue,
					hasChangesBetweenInOut = this.onFocusInputValue !== currentInputValue
				if (currentInputValue === '' && !hasChangesBetweenInOut && this.showEmptyMessage)
					return

				/**
				 * Model value update
				 * @property {string} newValue new value set
				 */
				this.$emit('update:modelValue', Number(this.getCtrlValue()))
				this.$emit('focusout')
			},

			/**
			 * Handles keyup events, re-formatting numbers.
			 *
			 * cursorPosition
			 * This variable keeps track of where the caret *should* be. It works out the position as
			 * the number of characters from the end of the string. E.g., '1^,234.56' where ^ denotes the caret,
			 * would be index -7 (e.g., 7 characters from the end of the string). At the end of both the key down
			 * and key up events, we'll re-position the caret to wherever cursorPosition tells us the cursor should be.
			 * This gives us a mechanism for incrementing the cursor position when we come across decimals, commas
			 * etc. This figure typically doesn't increment for each keypress when to the left of the decimal,
			 * but does when to the right of the decimal.
			 *
			 * @param object e			: The keyup event object.s
			 *
			 * @return void;
			 */
			onKeydownFormat(e)
			{
				// Disable editing on readonly fields
				if (this.readonly || this.disabled)
					return;

				const vm = this;

				// Define variables used in the code below.
				var code = e.keyCode ? e.keyCode : e.which,
					chara = '', //unescape(e.originalEvent.keyIdentifier.replace('U+','%u')),
					start = vm.getSelection('start'),
					end = vm.getSelection('end'),
					val = '',
					setPos = false;

				if (Reflect.has(vm.keydown.codes, code)) {
					code = vm.keydown.codes[code];
				}
				if (!e.shiftKey && code >= 65 && code <= 90) {
					code += 32;
				} else if (!e.shiftKey && code >= 69 && code <= 105) {
					code -= 48;
				} else if (e.shiftKey && Reflect.has(vm.keydown.shifts, code)) {
					//get shifted keyCode value
					chara = vm.keydown.shifts[code];
				}

				if (chara === '') chara = String.fromCharCode(code);

				// Stop executing if the user didn't type a number key, a decimal character, backspace, or delete.
				if (
					code !== 8 &&
					code !== 45 &&
					code !== 127 &&
					chara !== vm.decimalPoint &&
					chara !== ',' &&
					chara !== '.' &&
					!chara.match(/[0-9]/)
				) {
					// We need the original keycode now...
					var key = e.keyCode ? e.keyCode : e.which;
					if (
						// Allow control keys to go through... (delete, backspace, tab, enter, escape etc)
						key === 46 ||
						key === 8 ||
						key === 127 ||
						key === 9 ||
						key === 27 ||
						key === 13 ||
						// Allow: Ctrl+A, Ctrl+R, Ctrl+P, Ctrl+S, Ctrl+F, Ctrl+H, Ctrl+B, Ctrl+J, Ctrl+T, Ctrl+Z, Ctrl++, Ctrl+-, Ctrl+0
						((key === 65 ||
							key === 82 ||
							key === 80 ||
							key === 83 ||
							key === 70 ||
							key === 72 ||
							key === 66 ||
							key === 74 ||
							key === 84 ||
							key === 90 ||
							key === 61 ||
							key === 173 ||
							key === 48) &&
							(e.ctrlKey || e.metaKey) === true) ||
						// Allow: Ctrl+V, Ctrl+C, Ctrl+X
						((key === 86 || key === 67 || key === 88) &&
							(e.ctrlKey || e.metaKey) === true) ||
						// Allow: home, end, left, right
						(key >= 35 && key <= 39) ||
						// Allow: F1-F12
						(key >= 112 && key <= 123)
					) {
						return;
					}
					// But prevent all other keys.
					e.preventDefault();
					return false;
				}

				// The whole lot has been selected, or if the field is empty...
				if (start === 0 && end === vm.displayValue.length) {
					if (code === 8) {
						// Backspace
						// Blank out the field, but only if the data object has already been instantiated.
						start = end = 1;
						vm.setInputValue('0');

						// Reset the cursor position.
						vm.init = vm.maxDecimals > 0 ? -1 : 0;
						vm.cursorPosition = vm.maxDecimals > 0 ? -(vm.maxDecimals + 1) : 0;
						vm.setSelectionRange(0, 0);
					} else if (chara === vm.decimalPoint || chara === ',' || chara === '.') {
						start = end = 1;
						vm.setInputValue(
							'0' + vm.decimalPoint + new Array(vm.maxDecimals + 1).join('0')
						);

						// Reset the cursor position.
						vm.init = vm.maxDecimals > 0 ? 1 : 0;
						vm.cursorPosition = vm.maxDecimals > 0 ? -(vm.maxDecimals + 1) : 0;
					} else if (code === 45) {
						// Negative sign
						start = end = 2;
						vm.setInputValue(
							'-0' +
								(vm.maxDecimals > 0
									? vm.decimalPoint + new Array(vm.maxDecimals + 1).join('0')
									: '')
						);

						// Reset the cursor position.
						vm.init = vm.maxDecimals > 0 ? 1 : 0;
						vm.cursorPosition = vm.maxDecimals > 0 ? -(vm.maxDecimals + 1) : 0;

						vm.setSelectionRange(2, 2);
					} else {
						// Reset the cursor position.
						vm.init = vm.maxDecimals > 0 ? -1 : 0;
						vm.cursorPosition = vm.maxDecimals > 0 ? -vm.maxDecimals : 0;
					}
				}

				// Otherwise, we need to reset the caret position
				// based on the users selection.
				else {
					vm.cursorPosition = end - vm.displayValue.length;
				}

				// Track if partial selection was used
				vm.isPartialSelection = start === end ? false : true;
				// Track if over integer limit
				// Convert to a number.
				var decimalPointIndex = vm.displayValue.indexOf(vm.decimalPoint),
					hasDecimalSeparator = decimalPointIndex !== -1,
					integerNum = hasDecimalSeparator
						? vm.displayValue.substring(0, decimalPointIndex)
						: vm.displayValue,
					realIntegerNum = integerNum.replace(vm.regex_int, ''),
					integerPartLength =
						realIntegerNum.length - (realIntegerNum.indexOf('-') === 0 ? 1 : 0);

				vm.isOverIntegerLimit =
					integerPartLength >= vm.maxIntegers ? true : false;

				// If the start position is before the decimal point,
				// and the user has typed a decimal point, we need to move the caret
				// past the decimal place.
				if (
					vm.maxDecimals > 0 &&
					(chara === vm.decimalPoint || chara === ',' || chara === '.') &&
					start === vm.displayValue.length - vm.maxDecimals - 1
				) {
					vm.cursorPosition++;
					vm.init = Math.max(0, vm.init);
					e.preventDefault();

					// Set the selection position.
					setPos = vm.displayValue.length + vm.cursorPosition;
				}

				// If the caret is to the right of the decimal place, and the user is entering a
				// number, remove the following character before putting in the new one.
				if (
					vm.maxDecimals > 0 &&
					start === end &&
					vm.displayValue.length > vm.maxDecimals + 1 &&
					start > vm.displayValue.length - vm.maxDecimals - 1 &&
					isFinite(+chara) &&
					!e.metaKey &&
					!e.ctrlKey &&
					!e.altKey &&
					chara.length === 1
				) {
					// Replace the next character with the one typed
					if (end < vm.displayValue.length) {
						val =
							vm.displayValue.slice(0, start) +
							chara +
							vm.displayValue.slice(start + 1);
						vm.setInputValue(val);
					}
					e.preventDefault();

					// Reset the position.
					setPos = start;
				}
				// If the user has typed number and is over the integer limit
				else if (
					vm.isOverIntegerLimit &&
					isFinite(+chara) &&
					!e.metaKey &&
					!e.ctrlKey &&
					!e.altKey &&
					chara.length === 1 &&
					realIntegerNum !== '0'
				) {
					if (
						!vm.isPartialSelection &&
						(vm.maxDecimals === 0 ||
							(vm.maxDecimals > 0 && start < decimalPointIndex))
					) {
						e.preventDefault();
					}

					// If the start position is before the decimal point,we need to move the caret past the decimal place.
					if (
						vm.maxDecimals > 0 &&
						start === vm.displayValue.length - vm.maxDecimals - 1
					) {
						vm.cursorPosition++;
						vm.init = Math.max(0, vm.init);

						// Set the selection position.
						setPos = vm.displayValue.length + vm.cursorPosition;

						// Set the digit as the first digit after the decimal point
						val = vm.displayValue.slice(0, start + 1) + chara
						// If there are more than 2 decimal digits, add the rest after the replaced character
						if (vm.maxDecimals > 1)
							val += vm.displayValue.slice(start + 2)
						e.preventDefault()
						vm.setCtrlValue(val)
					}
				} else if (
					/**
					 * If has selected few numbers with the decimal separator
					 * put it's back
					 */
					vm.maxDecimals > 0 &&
					vm.isPartialSelection &&
					(code === 8 || code === 127) &&
					decimalPointIndex >= start &&
					decimalPointIndex < end
				) {
					e.preventDefault();
					let _tVal =
						(start === 0 ? '0' : vm.displayValue.slice(0, start)) +
						vm.decimalPoint +
						(end === vm.displayValue.length
							? '0'
							: vm.displayValue.slice(end));

					vm.setCtrlValue(_tVal);

					vm.cursorPosition =
						start > 0 ? start - vm.displayValue.length - 1 : 0;
					setPos = start > 0 ? start - 1 : 0;
				}

				// Ignore negative sign unless at beginning of number (and it's not already present)
				else if (
					code === 45 &&
					(start !== 0 || vm.displayValue.indexOf('-') === 0)
				) {
					e.preventDefault();
				}

				// If the user is just typing the decimal place,
				// we simply ignore it.
				else if (chara === vm.decimalPoint || chara === ',' || chara === '.') {
					vm.init = Math.max(0, vm.init);
					e.preventDefault();
				}

				// If hitting the delete key, and the cursor is before a decimal place,
				// we simply move the cursor to the other side of the decimal place.
				else if (
					vm.maxDecimals > 0 &&
					code === 127 &&
					start === vm.displayValue.length - vm.maxDecimals - 1
				) {
					// Just prevent default but don't actually move the caret here because it's done in the keyup event
					e.preventDefault();
				}

				// If hitting the backspace key, and the cursor is behind a decimal place,
				// we simply move the cursor to the other side of the decimal place.
				else if (
					vm.maxDecimals > 0 &&
					code === 8 &&
					start === vm.displayValue.length - vm.maxDecimals
				) {
					e.preventDefault();
					vm.cursorPosition--;

					// Set the selection position.
					setPos = vm.displayValue.length + vm.cursorPosition;
				}

				// If hitting the delete key, and the cursor is to the right of the decimal
				else if (
					vm.maxDecimals > 0 &&
					code === 127 &&
					start > vm.displayValue.length - vm.maxDecimals - 1
				) {
					if (vm.displayValue === '') return;

					val =
						vm.displayValue.slice(0, start) +
						vm.displayValue.slice(start + 1);
					vm.setCtrlValue(val);
					e.preventDefault();

					// Set the selection position.
					setPos = vm.displayValue.length + vm.cursorPosition;
				}

				// If hitting the backspace key, and the cursor is to the right of the decimal
				// (but not directly to the right)
				else if (
					vm.maxDecimals > 0 &&
					code === 8 &&
					start > vm.displayValue.length - vm.maxDecimals
				) {
					if (vm.displayValue === '') return;

					val =
						vm.displayValue.slice(0, start - 1) +
						vm.displayValue.slice(start);
					vm.setCtrlValue(val);
					e.preventDefault();
					vm.cursorPosition--;

					// Set the selection position.
					setPos = vm.displayValue.length + vm.cursorPosition;
				}

				// If the delete key was pressed, and the character immediately
				// after the caret is a thousands_separator character, simply
				// step over it.
				else if (
					code === 127 &&
					vm.displayValue.slice(start, start + 1) === vm.thousandsSeparator
				) {
					// Just prevent default but don't actually move the caret here because it's done in the keyup event
					e.preventDefault();
				}

				// If the backspace key was pressed, and the character immediately
				// before the caret is a thousands_separator character, simply
				// step over it.
				else if (
					code === 8 &&
					vm.displayValue.slice(start - 1, start) === vm.thousandsSeparator
				) {
					e.preventDefault();
					vm.cursorPosition--;

					// Set the selection position.
					setPos = vm.displayValue.length + vm.cursorPosition;
				}

				// If we need to re-position the characters.
				if (setPos !== false) {
					vm.setSelectionRange(setPos, setPos);
				}
			},

			/**
			 * Handles keyup events, re-formatting numbers.
			 * @param object e: The keyup event object.s
			 * @returns void;
			 */
			onKeyupFormat(e)
			{
				// Disable editing on readonly fields
				if (this.readonly || this.disabled) return;

				const vm = this;

				// Store these variables for use below.
				var code = e.keyCode ? e.keyCode : e.which,
					start = vm.getSelection('start'),
					end = vm.getSelection('end'),
					setPos;

				// Check for negative characters being entered at the start of the string.
				// If there's any kind of selection, just ignore the input.
				if (start === 0 && end === 0 && (code === 189 || code === 109)) {
					vm.setCtrlValue(+('-' + vm.getCtrlValue()));

					start = 1;
					vm.cursorPosition = 1 - vm.displayValue.length;
					vm.init = 1;

					setPos = vm.displayValue.length + vm.cursorPosition;
					vm.setSelectionRange(setPos, setPos);
				}

				// Stop executing if the user didn't type a number key, a decimal, or a comma.
				if (
					vm.displayValue === '' ||
					((code < 48 || code > 57) &&
						(code < 96 || code > 105) &&
						code !== 8 &&
						code !== 46 &&
						code !== 110)
				)
					return;

				// Re-format the textarea.
				vm.setCtrlValue(Number(vm.getCtrlValue()));

				if (vm.maxDecimals > 0)
				{
					// If we haven't marked this item as 'initialized'
					// then do so now. It means we should place the caret just
					// before the decimal. This will never be un-initialized before
					// the decimal character itself is entered.
					if (vm.init < 1) {
						start =
							vm.displayValue.length - vm.maxDecimals - (vm.init < 0 ? 1 : 0);
						vm.cursorPosition = start - vm.displayValue.length;
						vm.init = 1;
					}

					// Increase the cursor position if the caret is to the right
					// of the decimal place, and the character pressed isn't the backspace key.
					else if (
						start >= vm.displayValue.length - vm.maxDecimals &&
						!vm.isPartialSelection &&
						code !== 8 &&
						code !== 46
					) {
						vm.cursorPosition++;
					}
				}

				// Move caret to the right after delete key pressed
				if (
					code === 46 &&
					!vm.isPartialSelection &&
					start < vm.displayValue.length - vm.maxDecimals
				) {
					vm.cursorPosition++;
				}

				// Set the selection position.
				setPos = vm.displayValue.length + vm.cursorPosition;
				vm.setSelectionRange(setPos, setPos);
			},

			/**
			 * Trigger update value when pressing enter key
			 * @param object e: Event object.
			 * @returns false: prevent default action.
			 */
			onKeyup(e)
			{
				this.onKeyupFormat(e);

				if (e.keyCode === 13)
					this.onFocusout();
			},

			/**
			 * Reformat when pasting into the field.
			 *
			 * @param object e: Event object.
			 *
			 * @return false: prevent default action.
			 */
			onPasteFormat(e)
			{
				// Stop the actual content from being pasted.
				e.preventDefault();
				//e.stopPropagation();

				// Disable editing on readonly fields
				if (this.readonly || this.disabled) return false;

				let val = null;

				// Get the text content stream.
				if (e.clipboardData && e.clipboardData.getData) {
					val = e.clipboardData.getData('text/plain');
				}

				// Do the reformat operation.
				this.setCtrlValue(val);

				// Stop the actual content from being pasted.
				return false;
			},

			/**
			 * Reformat when drag&drop into the field.
			 *
			 * @param object e: Event object.
			 *
			 * @return false: prevent default action.
			 */
			onDropFormat(e)
			{
				// Stop the actual content from being pasted.
				e.preventDefault();

				// Disable editing on readonly fields
				if (this.readonly || this.disabled) return false;

				let val = null;

				// Get the text content stream.
				if (e.dataTransfer && e.dataTransfer.getData) {
					val = e.dataTransfer.getData('text/plain');
				}

				// Do the reformat operation.
				this.setCtrlValue(val);

				// Stop the actual content from being pasted.
				return false;
			},

			/**
			 * @param float number			: The number you wish to format, or TRUE to use the text contents
			 *								  of the element as the number. Please note that this won't work for
			 *								  elements which have child nodes with text content.
			 * @param int integers			: The number of integers places that should be displayed. Defaults to 0 (unlimited).
			 * @param int decimals			: The number of decimal places that should be displayed. Defaults to 0.
			 * @param string dec_point		: The character to use as a decimal point. Defaults to '.'.
			 * @param string thousands_sep	: The character to use as a thousands separator. Defaults to ','.
			 *
			 * @return string : The formatted number as a string.
			 */
			formatNumber(number, integers, decimals, dec_point, thousands_sep)
			{
				// Set the default values here, instead so we can use them in the replace below.
				thousands_sep =
					typeof thousands_sep === 'undefined'
						? new Number(1000).toLocaleString() !== '1000'
							? new Number(1000).toLocaleString().charAt(1)
							: ''
						: thousands_sep;
				dec_point =
					typeof dec_point === 'undefined'
						? new Number(0.1).toLocaleString().charAt(1)
						: dec_point;
				decimals = !isFinite(+decimals) ? 0 : Math.abs(decimals);
				integers = !isFinite(+integers) ? 0 : Math.abs(integers);

				// Work out the unicode representation for the decimal place and thousand sep.
				var u_dec =
					'\\u' + ('0000' + dec_point.charCodeAt(0).toString(16)).slice(-4);
				var u_sep =
					'\\u' + ('0000' + thousands_sep.charCodeAt(0).toString(16)).slice(-4);

				if (number === undefined || number === null)
					number = '0';
				else if (typeof number === 'object') {
					if (number.value) number = number.value + '';
					else number = '0';
				}
				else if (typeof number === 'number') number = number + '';
				else
					number = number
						.replace(new RegExp(u_sep, 'g'), '')
						.replace(new RegExp(u_dec, 'g'), '.');

				number = number.replace(new RegExp('[^0-9+-Ee.]', 'g'), '');

				// If the integer part of the number is greater than the defined one then does not accept the value
				let decimalPointIndex = number.indexOf('.'),
					integerPartLength =
						(decimalPointIndex !== -1 ? decimalPointIndex : number.length) -
						(number.indexOf('-') === 0 ? 1 : 0);

				if (integers > 0 && integerPartLength > integers)
					number = number.slice(
						0,
						integers + (number.indexOf('-') === 0 ? 1 : 0)
					);

				var n = !isFinite(+number) ? 0 : +number,
					s = '',
					toFixedFix = function (n, decimals) {
						return (
							'' +
							+(
								Math.round(('' + n).indexOf('e') > 0 ? n : n + 'e+' + decimals) +
								'e-' +
								decimals
							)
						);
					};

				// Fix for IE parseFloat(0.55).toFixed(0) = 0;
				s = (decimals ? toFixedFix(n, decimals) : '' + Math.round(n)).split('.');
				if (s[0].length > 3) {
					s[0] = s[0].replace(/\B(?=(?:\d{3})+(?!\d))/g, thousands_sep);
				}
				if ((s[1] || '').length < decimals) {
					s[1] = s[1] || '';
					s[1] += new Array(decimals - s[1].length + 1).join('0');
				}
				return s.join(dec_point);
			}
		},

		watch: {
			modelValue(newValue)
			{
				this.setCtrlValue(newValue)
			}
		}
	}
</script>
