<template>
	<h4>Calendar</h4>
	<div
		class="container-fluid"
		style="flex: 1 1 auto; padding: 44px">
		<base-input-structure
			id="CTRL_1"
			label="Full Calendar"
			label-position="right"
			readonly
			:label-attrs="{ class: 'i-checkbox i-checkbox__label' }">
			<q-calendar
				id="qfc-1"
				:list-config="listConfig"
				:mapped-values="mappedValues"
				:style-variables="styleVariables" />
		</base-input-structure>
	</div>
</template>

<script>
	import QCalendar from '@/components/rendering/QCalendar.vue'

	import mockData from './Calendar.mock.js'

	export default {
		components: {
			QCalendar
		},

		inheritAttrs: false,

		data()
		{
			return mockData
		}
	}
</script>
