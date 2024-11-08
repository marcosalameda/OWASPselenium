<template>
<div id="system_setup_scheduler_container">

	<row v-if="!isEmptyObject(resultMsg)">
		<div :class="['alert', statusError?'alert-danger':'alert-success']">
			<span>
				<b class="status-message">{{ resultMsg }}</b>
			</span>
		</div>
		<br />
	</row>

	<QGroupBoxContainer :label="Resources.AGENDADOR40611">
		<q-row-container>
			<q-control-wrapper class="row-line-group">
				<base-input-structure
					class="i-text">
					<checkbox-input v-model="model.Enabled" :label="Resources.ATIVO_00196"></checkbox-input>
				</base-input-structure>
			</q-control-wrapper>
			<qtable
				:rows="model.Jobs"
				:columns="tJobs.columns"
				:config="tJobs.config"
				:totalRows="tJobs.total_rows"
				class="q-table--borderless">

				<template #actions="props">
					<q-button-group borderless>
						<q-button
						:title="Resources.EDITAR11616"
						@click="changeJob(props.row)">
						<q-icon icon="pencil" />
						</q-button>
						<q-button
						:title="Resources.ELIMINAR21155"
						@click="deleteJob(props.row)">
						<q-icon icon="bin" />
						</q-button>
					</q-button-group>
				</template>
				<template #table-footer>
					<tr>
						<td colspan="4">
							<q-button
								:label="Resources.INSERIR43365"
								@click="createJob">
								<q-icon icon="plus-sign" />
							</q-button>
						</td>
					</tr>
				</template>
			</qtable>
		</q-row-container>
	</QGroupBoxContainer>

	<hr />
	<row>
		<q-button
			b-style="primary"
			:label="Resources.GRAVAR_CONFIGURACAO36308"
			@click="SaveSchedulerConfig" />
	</row>

	<modal_scheduled_job
		v-if="modalForms.scheduled_job.show"
		:Model="modalForms.scheduled_job.data"
		:JobTypeList="TaskList"
		@updateModal="callbackScheduledJob"
		@close="closeScheduledJob" />

</div>
</template>

<script>
	// @ is an alias to /src
	import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';
	import modal_scheduled_job from './ScheduledJob.vue';


	export default {
		name: 'scheduler',
		components: { modal_scheduled_job },
		mixins: [reusableMixin],
		props: {
			model: {
				required: true
			},
			TaskList: {
				required: false
			}
		},
		emits: ['updateModal'],
		data() {
			var vm = this;
			return {
				resultMsg: "",
				statusError: false,
				modalForms: {
					scheduled_job: {
						show: false,
						data: { }
					},
				},
				tJobs: {
					total_rows: 0,
					columns: [
					{
						label: () => vm.$t('ACOES22599'),
						name: "actions",
						slot_name: "actions",
						sort: false,
						column_classes: "thead-actions",
						row_text_alignment: 'text-center',
						column_text_alignment: 'text-center'
					},
					{
						label: () => "Enabled",
						name: "Enabled",
						sort: true,
					},
					{
						label: () => vm.$t('NOME47814'),
						name: "Id",
						sort: true,
						initial_sort: true,
						initial_sort_order: "asc"
					},
					{
						label: () => vm.$t('TIPO55111'),
						name: "TaskType",
						sort: true
					},
					{
						label: () => "Cron",
						name: "Cron",
						sort: false
					}],
					config: {
						table_title: () => vm.$t('TAREFAS_AGENDADAS24414'),
						pagination: false,
						pagination_info: false,
						global_search: {
							visibility: false
						}
					}
				},
			};
		},
		methods: {
			SaveSchedulerConfig() {
				var vm = this;
				vm.statusError = false;
				vm.resultMsg = "";
				QUtils.log("SaveSchedulerConfig - Request", QUtils.apiActionURL('Config', 'SaveSchedulerConfig'));
				QUtils.postData('Config', 'SaveSchedulerConfig', vm.model, null, function (data) {
					QUtils.log("SaveSchedulerConfig - Response", data);          
					vm.$emit('updateModal', data);
					if (data.Success) {
						vm.resultMsg = vm.Resources.ALTERACOES_EFETUADAS10166;
						vm.statusError = false;
					} else {
						vm.resultMsg = data.Message;
						vm.statusError = true;
					}
				});
			},

			showScheduledJobModal(mode, job) {
				var vm = this;
				vm.modalForms.scheduled_job.data = $.extend(true, {}, job);
				vm.modalForms.scheduled_job.data.FormMode = mode;
				vm.modalForms.scheduled_job.show = true;
			},
			changeJob(job) {
				//make sure job.options has something to edit
				job.Options ??= {};
				this.showScheduledJobModal('edit', job);
			},
			deleteJob(job) {
				//make sure job.options has something to edit
				job.Options ??= {};
				this.showScheduledJobModal('delete', job);
			},
			createJob() {
				let job = {
				Id: '',
				TaskType: '',
				Cron: '',
				Enabled: true,
				Options: {}
				};
				this.showScheduledJobModal('new', job);
			},
			callbackScheduledJob(eventData) {
				var vm = this;
				vm.closeScheduledJob();
				switch (eventData.FormMode) {
				case 'new':
					vm.model.Jobs.push(eventData.Data);
					break;
				case 'edit':
				case 'delete':
					vm.$emit('updateModal');
					break;
				}
			},
			closeScheduledJob() {
				this.modalForms.scheduled_job.show = false;
			},
		}
	};
</script>
