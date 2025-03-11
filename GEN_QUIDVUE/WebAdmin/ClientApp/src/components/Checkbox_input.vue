<template>
  <div class="checkbox-container">
    <q-checkbox 
		v-model="curValue" 
		:id="id" 
		:label="label" 
		:readonly="readonly" />
    <slot name="extras"></slot>
  </div>
</template>
 
<script>
export default {
	emits: ['update:modelValue'],

	props: {
		modelValue: Boolean,
		label: String,
		id: String,
		readonly: Boolean
	},

	computed: {
		curValue: {
			get() { return this.modelValue },
			set(newValue) { this.$emit('update:modelValue', newValue) }
		}
	}
}
</script>
