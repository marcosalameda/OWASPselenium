<template>
	<q-badge
		v-if="isMultiYearApp"
		color="rgb(64,71,79)"
		:title="title">
		<q-icon icon="data-systems" />
		<span>
			{{ currentYear }}
		</span>
	</q-badge>
</template>

<script>
	export default {
		props: {
			title: {
				type: String,
				default: ''
			}
		}
	};
</script>