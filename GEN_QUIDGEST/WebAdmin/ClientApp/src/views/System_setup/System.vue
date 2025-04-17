<template>
	<div id="system_setup_system_container">
		<scheduler
			:model="model"
			:TaskList="TaskList"
			@alert-class="forwardAlert"
			@update-model="forwardUpdate" />
		<audit
			:model="model"
			@alert-class="forwardAlert" />
		<row class="footer-btn">
			<q-button
				variant="bold"
				:label="Resources.GRAVAR_CONFIGURACAO36308"
				@click="SaveConfig" />
		</row>
	</div>
</template>

<script>
	import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';
	import scheduler from './Scheduler';
	import audit from './Audit';

	export default {
		name: 'system',

		components: {
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
			forwardUpdate(alertData) {
				this.$emit('update-model')
			},
			SaveConfig() {
				QUtils.log("SaveSystemConfig - Request", QUtils.apiActionURL('Config', 'SaveSystemConfig'));
				QUtils.postData('Config', 'SaveSystemConfig', this.model, null, (data) => {
					QUtils.log("SaveSystemConfig - Response", data);          
					this.$emit('update-model');
					if (data.Success) {
						this.$emit('alert-class', { ResultMsg: this.Resources.ALTERACOES_EFETUADAS10166, AlertType: 'success' });
						this.statusError = false;
					} else {
						this.$emit('alert-class', { ResultMsg: data.Message, AlertType: 'danger' });
					}
				});
			}
		}
	}
</script>
