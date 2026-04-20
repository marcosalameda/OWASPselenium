<template>
	<div class="q-filter">
		<component
			v-if="!props.loading"
			:is="filterComponent"
			v-bind="props"
			v-model="model" />
	</div>
</template>

<script setup lang="ts">
	// Types
	import type { FilterValue, QFilterGenericProps } from './types'

	// Utils
	import { computed } from 'vue'

	const props = withDefaults(defineProps<QFilterGenericProps>(), {
		texts: () => ({})
	})

	const model = defineModel<FilterValue>()

	/** Defines the rendered filter component, based on the selected viewmode. */
	const filterComponent = computed(() => `q-filter-${props.viewMode}`)
</script>
