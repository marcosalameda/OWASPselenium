<template>
    <row>
		<q-card
			class="q-card--admin-default"
			:title="Resources.AGENDADOR40611"
			width="block">
			<q-row-container>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<q-checkbox 
							v-model="model.Enabled"
							:label="Resources.ATIVO_00196" />
					</base-input-structure>
				</q-control-wrapper>
				<qtable
					:rows="job"
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
									<q-icon icon="add" />
								</q-button>
							</td>
						</tr>
					</template>
				</qtable>
				<row class="footer-btn">
					<q-button
						b-style="primary"
						:label="Resources.GRAVAR_CONFIGURACAO36308"
						@click="SaveSchedulerConfig" />
				</row>
			</q-row-container>
		</q-card>
	</row>

	<q-dialog
		id="system_setup_scheduledjob"
		v-model="showDialog"
		:title="Resources.TAREFA_AGENDADA03399"
		:buttons="buttons">
		<template #body.content>
			<div class="q-dialog-container">
				<div>
					<q-checkbox
						v-model="rowEnabled"
						:readonly="inDeleteMode"
						:label="Resources.ATIVO_00196" />
				</div>
				<div>
					<q-text-field 
						v-model="rowId"
						:label="Resources.NOME47814"
						:readonly="inEditMode || inDeleteMode"
						size="xlarge"
						required />
				</div>
				<div>
					<q-select 
						v-model="rowTaskType"
						:items="ScheduledJobSelect"
						:label="Resources.TIPO55111"
						:readonly="inDeleteMode"
						item-value="Value"
						item-label="Text"
						size="xlarge" />
				</div>
				<div>
					<base-input-structure
						:label="'Cron'"
						:id="'CronField'"
						:isVisible="true"
						:showPopoverButton="true"
						:popoverTitle="'Cron Information'"
						:popoverText="Resources._SEGUNDO_MINUTO_HORA37214">
						<q-text-field
							v-model="rowCron"
							ref="Cron"
							:readonly="inDeleteMode"
							:size="'xlarge'"
							required
							placeholder="cron schedule" />
					</base-input-structure>
				</div>					
				<div v-for="c in TaskList[rowTaskType]" :key="c.PropertyName">
					<q-text-field
						v-model="rowOptions[c.PropertyName]"
						:label="c.DisplayName"
						:readonly="inDeleteMode"
						:required="!c.Optional"
						size="xlarge"
						:helpText="c.Description"/>
				</div>
			</div>
		</template>
	</q-dialog>
</template>

<script>
	import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';
	import BaseInputStructure from '@/components/BaseInputStructure.vue'

	export default {
		name: 'scheduler',

		components: { 
			BaseInputStructure
		},

		mixins: [reusableMixin],

		emits: ['alert-class', 'update-model'],

		props: {
			model: {
				required: true
			},
			TaskList: {
				required: false
			}
		},

		data () {
			return {
				showDialog: false,
				job: [],
				buttons: [],
				dialogMode: '',
				rowOptions: {},
				rowCron: '',
				rowEnabled: false,
				rowTaskType: '',
				rowId: '',
				temp: {},
				alert: {
					isVisible: false,
					alertType: 'info',
					message: ''
				},
				tJobs: {
					total_rows: 0,
					columns: [
					{
						label: () => this.$t('ACOES22599'),
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
						label: () => this.$t('NOME47814'),
						name: "Id",
						sort: true,
						initial_sort: true,
						initial_sort_order: "asc"
					},
					{
						label: () => this.$t('TIPO55111'),
						name: "TaskType",
						sort: true
					},
					{
						label: () => "Cron",
						name: "Cron",
						sort: false
					}],
					config: {
						table_title: () => this.$t('TAREFAS_AGENDADAS24414'),
						pagination: false,
						pagination_info: false,
						global_search: {
							visibility: false
						}
					}
				},
			}
		},

		computed: {
			inDeleteMode() {
				return this.dialogMode === 'delete';
			},
			inEditMode() {
				return this.dialogMode === 'edit';
			},
			ScheduledJobSelect() {
				return Object.keys(this.TaskList).map(x => ({
					Text: x,
					Value: x
				}));
			},
		},

		methods: {
			SaveSchedulerConfig() {
				QUtils.log("SaveSchedulerConfig - Request", QUtils.apiActionURL('Config', 'SaveSchedulerConfig'));
				QUtils.postData('Config', 'SaveSchedulerConfig', this.model, null, function (data) {
					QUtils.log("SaveSchedulerConfig - Response", data);          
					this.$emit('update-model', data);
					if (data.Success) {
						this.$emit('alert-class', { ResultMsg: this.Resources.ALTERACOES_EFETUADAS10166, AlertType: 'success' });
						this.statusError = false;
					} else {
						this.$emit('alert-class', { ResultMsg: data.Message, AlertType: 'danger' });
					}
				});
			},

			SaveScheduledJob() {
				const schedulerValues = {
					Data: {
						Id: this.rowId,
						Cron: this.rowCron,
						Enabled: this.rowEnabled,
						TaskType: this.rowTaskType,
						Options: this.rowOptions || {}
					},
					FormMode: this.dialogMode,
				}

				QUtils.postData('Config', 'SaveScheduledJob', schedulerValues, null, (data) => {
					if (data.Success) {
						switch (schedulerValues.FormMode) {
							case 'new':
								this.job.push(schedulerValues.Data);
							break;
							case 'edit':
								const newjobIndex = this.job.findIndex(value => value.Id == this.rowId)
								Object.assign(this.job[newjobIndex], schedulerValues.Data)
								break;
							case 'delete':
								this.job = this.job.filter(prop => prop.Id != this.rowId);
								break;
							default:
							break;
						}
					}
					else {
						this.$emit('alert-class', { ResultMsg: data.Message, AlertType: 'danger' });
					}

					this.clearSchedulerValues()
					// Update model data
					this.$emit('update-model')
				});
			},

			clearSchedulerValues() {
				this.dialogMode = ''
				this.rowOptions = {}
				this.rowCron = ''
				this.rowEnabled = false
				this.rowTaskType = ''
				this.rowId = ''
				this.buttons = []
			},

			showScheduledJobModal(mode, job) {
				this.dialogMode = mode
				this.getButtonsDialog()
				this.showDialog = true
			},
			getButtonsDialog() {
				switch(this.dialogMode) {
					case 'delete':
						this.buttons.push({
							id: 'delete-btn',
							props: {
								label: this.Resources.APAGAR04097,
								bStyle: "danger"
							},
							action: () => {
								this.SaveScheduledJob()
							}
						});
						break;
					case 'edit':
					case 'new':
						this.buttons.push({
							id: 'save-btn',
							props: {
								label: this.Resources.GRAVAR45301,
								bStyle: "primary",
								disabled: this.invalidProps
							},
							action: () => {
								this.SaveScheduledJob()
							}
						});
						break;
					default:
						break;
					}

				this.buttons.push({
					id: 'cancel-btn',
					props: {
						label: this.Resources.CANCELAR49513
					},
					action: () => this.clearSchedulerValues()
				})
			},
			changeJob(job) {
				this.rowId = job.Id
				this.rowOptions = job.Options || {}
				this.rowCron = job.Cron
				this.rowEnabled = job.Enabled
				this.rowTaskType = job.TaskType
				this.showScheduledJobModal('edit', job);
			},
			deleteJob(job) {
				this.rowId = job.Id
				this.rowOptions = job.Options
				this.rowCron = job.Cron
				this.rowEnabled = job.Enabled
				this.rowTaskType = job.TaskType
				this.showScheduledJobModal('delete', job);
			},
			createJob() {
				let job = {
					rowId: '',
					TaskType: '',
					rowCron: '',
					rowEnabled: true,
					rowOptions: {}
				};
				this.showScheduledJobModal('new', job);
			}
		},

		mounted() {
			this.job = this.model.Jobs || [];
		},

		watch: {
			rowTaskType(newTaskType) {
				if (!this.rowOptions) {
					this.rowOptions = {};
				}
				this.TaskList[newTaskType]?.forEach(task => {
					if (!this.rowOptions.hasOwnProperty(task.PropertyName)) {
						this.rowOptions[task.PropertyName] = '';
					}
				});
			},
		}
	}
</script>
