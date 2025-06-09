<template>
	<div class="i-radio__control">
		<div
			v-if="label"
			class="d-flex">
			<label class="i-text__label i-text">{{ label }}</label>
		</div>
		<div class="form-check-inline">
			<label
				v-for="option in options"
				:key="ctrlID + '_' + option.Value"
				class="i-radio i-radio__label i-radio--inline">
				{{ option.Text }}
				<input
					v-model="curValue"
					type="radio"
					:disabled="isReadOnly"
					:name="'radio_btn_' + ctrlID"
					:value="option.Value" />
				<span class="i-radio__field"></span>
			</label>
		</div>
	</div>
</template>

<script>
	import { getCurrentInstance } from 'vue'

	export default {
		name: 'RadioInput',

		props: {
			/**
			 * Radio button value.
			 */
			modelValue: {
				type: Boolean,
				default: false
			},

			/**
			 * Radio buttons that compose the radio group.
			 */
			options: {
				type: Array,
				default: () => []
			},

			/**
			 * Radio group label.
			 */
			label: {
				type: String,
				default: ''
			},

			/**
			 * True if the input should be in a read-only state, false otherwise.
			 */
			isReadOnly: {
				type: Boolean,
				default: false
			}
		},

		emits: ['update:modelValue'],

		expose: [],

		data() {
			return {
				ctrlID: ''
			}
		},

		computed: {
			curValue: {
				get() {
					return this.modelValue
				},
				set(newValue) {
					this.$emit('update:modelValue', newValue)
				}
			}
		},

		mounted() {
			this.ctrlID = 'i-radio' + getCurrentInstance().uid
		}
	}
</script>
