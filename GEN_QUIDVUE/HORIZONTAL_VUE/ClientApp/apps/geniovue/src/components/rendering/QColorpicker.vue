<template>
	<q-color-picker
		:id="id"
		:model-value="modelValue"
		:readonly="readonly"
		:disabled="disabled"
		:placeholder="placeholder"
		:texts="resolvedTexts"
		@update:model-value="(value) => emit('update:model-value', value)" />
</template>

<script setup lang="ts">
	import { computed } from 'vue'
	/**
	 * This wrapper is needed because custom controls do not support multi-word names.
	 */
	const DEFAULT_TEXTS = {
		selectColor: 'Select a color',
	}

	/** Customizable texts used in color pickers. */
	type Texts = typeof DEFAULT_TEXTS

	/** Props for the main QCards component. */
	type QColorPickerProps =  {
		/**
		 * Unique identifier for the field.
		 */
		id?: string | undefined

		/**
		 * The HEX color value bound to the color picker.
		 */
		modelValue?: string

		/**
		 * Specifies whether the text field is read-only.
		 */
		readonly?: boolean

		/**
		 * Specifies whether the color picker is disabled.
		 */
		disabled?: boolean

		/**
		 * Placeholder text for the text field.
		 */
		placeholder?: string

		/**
		 * Texts needed by the component.
		 */
		texts?: Texts
	}

	const props = withDefaults(defineProps<QColorPickerProps>(),{
		id: undefined,
		modelValue: '',
		readonly: false,
		disabled: false,
		placeholder: '#000000',
	})

	const emit = defineEmits<{
		/** Emits when the color value changes. */
		(e: 'update:model-value', value: string): void
	}>()

	/**
	 * Texts have to be appended outside prop definition because withDefaults can't use locally-defined variables.
	 */
	const resolvedTexts = computed(() => ({
		...DEFAULT_TEXTS,
		...(props.texts),
	}))
</script>
