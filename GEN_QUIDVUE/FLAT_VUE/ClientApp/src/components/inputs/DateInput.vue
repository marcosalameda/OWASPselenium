<template>
	<q-input-group :size="size">
		<q-field
			:readonly="readonly"
			:disabled="disabled">
			<datepicker
				v-model="curValue"
				ref="dateTimeInput"
				:id="controlId"
				:uid="controlId"
				:disabled="disabled"
				:readonly="readonly"
				:inline-with-input="!(disabled || readonly)"
				:locale="locale"
				:format="curFormat"
				:is24="is24"
				:enable-time-picker="format !== 'Date'"
				:enable-seconds="format === 'DateTimeSeconds'"
				:time-picker="format === 'Time'"
				:text-input-options="{ format: curFormat }"
				:placeholder="placeholder"
				hide-input-icon
				text-input
				auto-apply
				:close-on-auto-apply="false"
				:clearable="false"
				@open="onOpen"
				@closed="onClose" />
		</q-field>

		<template #append>
			<q-button
				ref="dateTimeButton"
				b-style="secondary"
				:disabled="readonly || disabled"
				@click="onButtonToggleDateInput"
				@focus="onButtonFocus">
				<q-icon :icon="iconName" />
			</q-button>
		</template>
	</q-input-group>
</template>

<script>
	import Datepicker from '@vuepic/vue-datepicker'
	import _isEmpty from 'lodash-es/isEmpty'
	import _isDate from 'lodash-es/isDate'

	import { inputSize } from '@/mixins/quidgest.mainEnums.js'
	import genericFunctions from '@/mixins/genericFunctions.js'
	import modelFieldType from '@/mixins/formModelFieldTypes.js'

	export default {
		name: 'QDateTime',

		emits: ['update:modelValue'],

		components: {
			Datepicker
		},

		inheritAttrs: false,

		props: {
			/**
			 * Unique identifier for the control.
			 */
			id: String,

			/**
			 * The current value of the date input
			 */
			modelValue: {
				type: [String, Date, Object],
				default: null,
				validator: (modelValue) =>
					modelValue === null ||
					modelValue instanceof Date ||
					typeof modelValue === 'string' ||
					genericFunctions.hasTimeProperties(modelValue)
			},

			/**
			 * If control is Read only
			 */
			readonly: {
				type: Boolean,
				default: false
			},

			/**
			 * If control is a Fixed value, not to be changed with input.
			 * Automatic disabled=true
			 */
			disabled: {
				type: Boolean,
				default: false
			},

			/**
			 * format of the control, {D : Date}, {T : Time}, {DT : DateTime}, {DS : DateTimeSeconds}
			 */
			format: {
				type: String,
				default: 'DateTime',
				validator: (propValue) => ['Date', 'DateTime', 'DateTimeSeconds', 'Time'].includes(propValue)
			},

			/**
			 * Set datepicker locale.
			 * Datepicker will use built in javascript locale formatter to extract month and weekday names.
			 * https://vue3datepicker.com/api/props/#locale
			 */
			locale: {
				type: String,
				default: 'en-US'
			},

			/**
			 * The format to be used for date/time portion.
			 * https://vue3datepicker.com/api/props/#format
			 */
			dateFormat: {
				type: Object,
				default: () => {
					return {
						Date: 'dd/MM/yyyy',
						DateTime: 'dd/MM/yyyy HH:mm',
						DateTimeSeconds: 'dd/MM/yyyy HH:mm:ss',
						Time: 'HH:mm'
					}
				}
			},

			/**
			 * Sizing class for the control
			 */
			size: {
				type: String,
				validator: (value) => _isEmpty(value) || Reflect.has(inputSize, value)
			},

			/**
			 * Custom classes
			 */
			classes: {
				type: Array,
				default: () => []
			}
		},

		// TODO: Remove these properties from the "expose" (only necessary for unit tests).
		expose: [
			'format'
		],

		data()
		{
			return {
				controlId: this.id || `i_datetime_${this._.uid}`,
				datePickerIsOpen: false
			}
		},

		computed: {
			/**
			 * Converts between viewmodel-internal (string) representation to
			 * datepicker's object representation ({ hours, minutes, seconds }).
			 */
			curValue: {
				get()
				{
					if (
						this.format === 'Time' &&
						typeof this.modelValue === 'string' &&
						this.modelValue !== modelFieldType.Time.EMPTY_VALUE
					)
					{
						return {
							hours: this.modelValue.split(':')[0],
							minutes: this.modelValue.split(':')[1],
							seconds: 0
						}
					}

					return this.modelValue
				},
				set(newValue)
				{
					if (this.format === 'Time' && genericFunctions.hasTimeProperties(newValue))
						newValue = genericFunctions.timeToString(newValue)
					else if (this.format === 'Time' && _isEmpty(newValue))
						newValue = modelFieldType.Time.EMPTY_VALUE

					this.update(newValue)
				}
			},

			curFormat()
			{
				let formatStr = this.dateFormat[this.format]

				if (_isEmpty(formatStr))
					return ''

				return formatStr.replace(/t/g, 'a')
			},

			placeholder()
			{
				if (this.disabled || this.readonly)
					return ''

				return this.curFormat.toUpperCase()
			},

			is24()
			{
				return !/ aa$/.test(this.curFormat || '')
			},

			iconName()
			{
				return this.format === 'Time' ? 'time' : 'date'
			}
		},

		methods: {
			/**
			 * Model value update
			 * @property {string} newValue new value set
			 */
			update(newValue)
			{
				this.$emit('update:modelValue', newValue)
			},

			onOpen()
			{
				if (this.disabled || this.readonly)
					return

				this.datePickerIsOpen = true
			},

			onClose()
			{
				this.datePickerIsOpen = false
			},

			onButtonFocus(event)
			{
				if (event === undefined || event === null)
					this.datePickerIsOpen = false
				if (event.relatedTarget === undefined || event.relatedTarget === null)
				{
					this.datePickerIsOpen = false
					return
				}

				// Check if the focus is coming from the date picker
				// Actually this means the focus will come from this special element
				// that the focus goes through when focusing away from the date picker
				// This is needed to allow toggling using the button next to the input control
				// because the date picker will close when focusing away from it but even
				// before the blur event and when using focusout on the input control
				// the relatedTarget will not be the element the focus is actually going to
				if (event.relatedTarget.tagName === 'SPAN' && event.relatedTarget.tabIndex === -1)
					this.datePickerIsOpen = !this.datePickerIsOpen
				else
					this.datePickerIsOpen = false
			},

			onButtonToggleDateInput()
			{
				// If date picker is closed, open it and focus on the input control
				if (!this.datePickerIsOpen)
				{
					this.$refs.dateTimeInput.openMenu()

					// If input has no value, set it to the current date
					if (!this.disabled || this.readonly)
					{
						if (this.format === 'Time' && (!this.curValue || this.curValue === modelFieldType.Time.EMPTY_VALUE))
						{
							// Get the current date
							const currentDate = new Date()

							// Get the current hours and pad it with a leading zero if necessary
							const hours = String(currentDate.getHours()).padStart(2, '0')

							// Get the current minutes and pad it with a leading zero if necessary
							const minutes = String(currentDate.getMinutes()).padStart(2, '0')

							this.curValue = `${hours}:${minutes}`
						}
						else if (!_isDate(this.curValue))
						{
							if (this.format === 'Date')
								this.curValue = new Date(new Date().setHours(0, 0, 0, 0))
							else if (this.format === 'DateTime')
								this.curValue = new Date(new Date().setSeconds(0, 0))
							else if (this.format === 'DateTimeSeconds')
								this.curValue = new Date()
						}
					}
				}
				// If date picker is open, close it
				else
					this.$refs.dateTimeInput.closeMenu()
			}
		}
	}
</script>
