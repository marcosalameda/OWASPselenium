<template>
	<div id="system_setup_system_container">
		<scheduler
			:model="model"
			:TaskList="TaskList"
			@alert-class="forwardAlert" />
		<audit
			:model="model"
			@alert-class="forwardAlert" />
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

		emits: ['update-model', 'alert-class'],

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
				this.$emit('alert-class', alertData);
			},
		}
	}
</script>
