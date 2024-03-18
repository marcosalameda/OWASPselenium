<template>
	<fieldset
		role="radiogroup"
		:aria-labelledby="labelId"
		:class="[{ labelleft: labelLeftSide }, 'i-radio__control']">
		<div class="form-check-columns">
			<div
				v-for="column in columnList"
				:key="column"
				class="column">
				<label
					v-for="option in column"
					:key="option.key"
					:class="[
						{
							'checkfocus': activeEl === option.key,
							'i-radio--disabled': disabled || readonly
						},
						'i-radio',
						'i-radio__label'
					]"
					:for="`input_${controlId}_${option.key}`">
					{{ String(option.value) }}

					<input
						type="radio"
						:id="`input_${controlId}_${option.key}`"
						:ref="`option${option.key}`"
						:disabled="disabled || readonly"
						:data-testid="`radio_label_${option.key}`"
						:name="`radio_btn_${controlId}`"
						:value="option.key"
						:title="String(option.value)"
						:aria-label="String(option.value)"
						:checked="modelValue === option.key"
						@click="selectElement(option.key, $event)"
						@keyup="selectElement(option.key, $event)"
						@focus="focusElement(option.key)"
						@focusout="removeFocus(option.key)" />

					<span class="i-radio__field"></span>
				</label>
			</div>
		</div>
	</fieldset>
</template>

<script>
	import _isEmpty from 'lodash-es/isEmpty'

	export default {
		name: 'QRadioGroup',

		emits: ['update:modelValue'],

		inheritAttrs: false,

		props: {
			/**
			 * Unique identifier for the control.
			 */
			id: String,

			/**
			 * Holds value of radio input
			 */
			modelValue: [Number, String],

			/**
			 * Options for radio input
			 */
			optionsList: {
				type: Array,
				required: true,
				validator: (prop) => prop.every(e => Reflect.has(e, 'key') && Reflect.has(e, 'value'))
			},

			/**
			 * Radio input value positions
			 */
			labelLeftSide: {
				type: Boolean,
				default: false
			},

			/**
			 * Number of columns for options
			 */
			numberOfColumns: {
				type: Number,
				default: 1
			},

			/**
			 * To deselect radio list options
			 */
			deselectRadio: {
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
			 * Whether the field is readonly.
			 */
			readonly: {
				type: Boolean,
				default: false
			}
		},

		// TODO: Remove these properties from the "expose" (only necessary for unit tests).
		expose: [
			'optionsList'
		],

		data()
		{
			return {
				controlId: this.id || `radio_select_${this._.uid}`,

				activeEl: ''
			}
		},

		computed: {
			labelId()
			{
				return `label_${this.controlId}`
			},

			columnList()
			{
				let columns = []
				let midCount = Math.ceil(this.optionsList.length / this.numberOfColumns)

				for (let col = 0; col < this.numberOfColumns; col++)
					columns.push(this.optionsList.slice(col * midCount, col * midCount + midCount))

				return columns
			}
		},

		methods: {
			/**
			 * Emits the new value of the input.
			 * @param {string|number} newValue The new value of the radio input
			 */
			updateValue(newValue)
			{
				if (newValue === this.modelValue)
					return

				this.$emit('update:modelValue', newValue)
				this.focusElement(newValue)
			},

			/**
			 * To select radio input option.
			 * @param {string} el The key of the selected element
			 * @param {object} event The event
			 */
			selectElement(el, event)
			{
				this.focusElement(el)

				if (this.deselectRadio && !_isEmpty(this.modelValue) && el === this.modelValue)
				{
					if (event.type === 'click' || event.key === 'Backspace' || event.key === 'Delete')
						this.updateValue(undefined)
				}
				else if (event.type === 'click' || event.key === 'Enter')
					this.updateValue(el)
			},

			/**
			 * To focus radio input option.
			 * @param {string} el The key of the element that should gain focus
			 */
			focusElement(el)
			{
				this.activeEl = el
			},

			/**
			 * To remove focus from radio input option.
			 */
			removeFocus()
			{
				this.activeEl = ''
			}
		}
	}
</script>
