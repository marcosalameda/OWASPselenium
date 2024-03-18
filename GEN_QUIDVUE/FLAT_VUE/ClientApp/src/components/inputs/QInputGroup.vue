<template>
	<div class="q-input-group">
		<div
			v-if="$slots.prepend || $props.prependIcon"
			class="q-input-group__prepend">
			<span v-if="$props.prependIcon">
				<q-icon :icon="$props.prependIcon" />
			</span>
			<slot name="prepend"></slot>
		</div>
		<slot></slot>
		<div
			v-if="$slots.append || $props.appendIcon"
			class="q-input-group__append">
			<span v-if="$props.appendIcon">
				<q-icon :icon="$props.appendIcon" />
			</span>
			<slot name="append"></slot>
		</div>
	</div>
</template>

<script>
	export default {
		name: 'QInputGroup',

		props: {
			prependIcon: {
				type: String,
				default: ''
			},

			appendIcon: {
				type: String,
				default: ''
			}
		}
	}
</script>
