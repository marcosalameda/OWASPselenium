<template>
	<component
		:is="options?.component ? options.component : 'base-input-structure'"
		:id="`${tableName}_${rowIndex}_${columnName}`"
		:class="containerClasses"
		:d-flex-inline="true"
		:label-attrs="{ class: 'i-text__label' }"
		:model-field-ref="modelField"
		:error-display-type="options?.errorDisplayType">
		<q-select-list-input
			:id="`${tableName}_${rowIndex}_${columnName}`"
			:size="size"
			:classes="[...classes, 'i-select__input']"
			:options="options.distinctValues ? options.distinctValues : options.array"
			:is-blocked="options.isReadOnly"
			:model-value="value"
			@update:model-value="$emit('update', $event)" />
	</component>
</template>

<script>
	import _isEmpty from 'lodash-es/isEmpty'

	import { inputSize } from '@/mixins/quidgest.mainEnums.js'
	import modelFieldType from '@/mixins/formModelFieldTypes.js'

	import BaseInputStructure from '@/components/inputs/BaseInputStructure.vue'
	import GridBaseInputStructure from '@/components/inputs/GridBaseInputStructure.vue'
	import QSelectListInput from '@/components/inputs/SelectListInput.vue'

	export default {
		name: 'QEditEnumeration',

		emits: ['update', 'loaded'],

		components: {
			BaseInputStructure,
			GridBaseInputStructure,
			QSelectListInput
		},

		props: {
			value: {
				type: [Number, String],
				default: ''
			},

			tableName: {
				type: String,
				required: true
			},

			rowIndex: {
				type: [Number, String],
				required: true
			},

			columnName: {
				type: String,
				required: true
			},

			options: {
				type: Object,
				default: () => ({})
			},

			/**
			 * Sizing class for the control
			 */
			size: {
				type: String,
				validator: (value) => _isEmpty(value) || Reflect.has(inputSize, value)
			},

			classes: {
				type: Array,
				default: () => []
			},

			containerClasses: {
				type: Array,
				default: () => []
			},

			errorMessages: {
				type: Array,
				default: () => []
			}
		},

		data()
		{
			return {
				modelField: new modelFieldType.String()
			}
		},

		mounted()
		{
			this.$emit('loaded')
		},

		watch: {
			errorMessages: {
				handler(newValue)
				{
					this.modelField.serverErrorMessages = newValue
				},
				deep: true
			}
		}
	}
</script>
