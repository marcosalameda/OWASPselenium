<template>
	<div id="system_setup_system_container">
		<scheduler
			:model="model"
			:TaskList="TaskList"
			@alertClass="forwardAlert" />
		<audit
			:model="model"
			@alertClass="forwardAlert" />
	</div>
</template>

<script>
	import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';
	import QAlert from '@/components/QAlert.vue';
	import scheduler from './Scheduler';
	import audit from './Audit';

	export default {
		name: 'system',

		components: {
			QAlert,
			scheduler,
			audit
		},

		mixins: [reusableMixin],

		emits: ['updateModal', 'alertClass'],

		props: {
			model: {
				required: true
			},
			TaskList: {
				required: false
			}
		},

		methods: {
			forwardAlert(alertData) {
				this.$emit('alertClass', alertData);
			},
		}
	}
</script>
