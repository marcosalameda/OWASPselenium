<template>
	<q-date-time-picker
		close-on-select
		:class="props.class"
		:clearable="props.clearable"
		:model-value="internalModel"
		:range="props.range"
		:readonly="props.readonly"
		:size="props.size"
		@update:model-value="updateValue" />
</template>

<script setup lang="ts">
	// Components
	import { QDateTimePicker } from '@quidgest/ui/components'

	// Types
	import type { QFilterDateProps } from './types'

	// Utils
	import { nextTick, onBeforeUnmount, ref, watch } from 'vue'

	const emit = defineEmits<{
		(e: 'update:modelValue', val: string | Date | Date[]): void
	}>()

	const props = withDefaults(defineProps<QFilterDateProps>(), {
		size: 'large'
	})

	const model = defineModel<string | Date | Date[]>({
		default: ''
	})
	const internalModel = ref<string | Date | Date[]>(props.range ? [] : '')

	const watchStopHandle = watch(
		model,
		async (val: string | Date | Date[]): Promise<void> => {
			await nextTick()
			internalModel.value = props.range && !val ? [] : val
		},
		{ immediate: true })

	/**
	 * Handles the update of the input value.
	 * @param value - The input value.
	 */
	function updateValue(value?: string | Date | Date[]): void {
		if (typeof value === 'undefined') {
			emit('update:modelValue', props.range ? [] : '')
			return
		}

		if (props.range && !Array.isArray(value)) {
			return
		}

		// Validate that array values are not null
		if (Array.isArray(value) && value.some((v) => v === null || v === undefined)) {
			return
		}

		emit('update:modelValue', value)
	}

	onBeforeUnmount(watchStopHandle)

	defineOptions({
		inheritAttrs: false
	})
</script>
