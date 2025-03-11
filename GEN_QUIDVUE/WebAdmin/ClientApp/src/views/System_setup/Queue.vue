<template>
    <row>
		<row>
			<div class="control-join-group">
				<q-text-field
					v-model="model.MQueues.Journaltimeout"
					:label="Resources.JOURNAL_TIMEOUT__MIN38634"
					:size="'xlarge'" />
				<q-text-field
					v-model="model.MQueues.Maxsendnumber"
					:label="Resources.NUMERO_MAXIMO_DE_TEN51201"
					:size="'xlarge'" />
			</div>
		</row>
		<row class="footer-btn">
			<q-button
				b-style="primary"
				:label="Resources.GRAVAR45301"
				@click="SaveConfigMessageQueue" />
		</row>
		<hr />

		<row>
			<qtable :rows="queuesProps"
					:columns="tQueues.columns"
					:config="tQueues.config"
					:totalRows="tQueues.total_rows"
					class="q-table--borderless">
				<template #actions="props">
					<q-button-group borderless>
					<q-button
						:title="Resources.EDITAR11616"
						@click="changeQueue(props.row)">
						<q-icon icon="pencil" />
					</q-button>
					<q-button
						:title="Resources.ELIMINAR21155"
						@click="deleteQueue(props.row)">
						<q-icon icon="bin" />
					</q-button>
					</q-button-group>
				</template>
				<template #table-footer>
					<tr>
						<td colspan="8">
							<q-button
								:label="Resources.INSERIR43365"
								@click="createQueue">
								<q-icon icon="add" />
							</q-button>
						</td>
					</tr>
				</template>
			</qtable>
		</row>

		<row>
			<qtable :rows="acksProps"
					:columns="tAcks.columns"
					:config="tAcks.config"
					:totalRows="tAcks.total_rows"
					class="q-table--borderless">
				<template #actions="props">
					<q-button-group borderless>
					<q-button
						:title="Resources.EDITAR11616"
						@click="changeAck(props.row)">
						<q-icon icon="pencil" />
					</q-button>
					<q-button
						:title="Resources.ELIMINAR21155"
						@click="deleteAck(props.row)">
						<q-icon icon="bin" />
					</q-button>
					</q-button-group>
				</template>
				<template #table-footer>
					<tr>
						<td colspan="3">
							<q-button
								:label="Resources.INSERIR43365"
								@click="createAck">
								<q-icon icon="add" />
							</q-button>
						</td>
					</tr>
				</template>
			</qtable>
		</row>

		<q-dialog
			v-model="showDialog"
			:title="Resources.QUEUE45251"
			:buttons="buttons">
			<template #body.content>
				<div class="q-dialog-container">
					<div>
						<q-text-field
							v-model="queueData.queue"
							:label="Resources.NOME_DA_QUEUE56594"
							:readonly="blockFormQueue"
							size="large" />
					</div>
					<div>
						<q-text-field
							v-model="queueData.queueChannel"
							:label="Resources.CANAL_DA_QUEUE34934"
							:readonly="blockFormQueue"
							size="large" />
					</div>
					<div>
						<q-text-field
							v-model="queueData.path"
							:label="Resources.TRAJETO_DA_QUEUE07185"
							:readonly="blockFormQueue"
							size="large" />
					</div>
					<div>
						<q-text-field
							v-model="queueData.Qyear"
							:label="Resources.ANO33022"
							:readonly="blockFormQueue"
							size="large" />
					</div>
					<div>
						<numeric-input
							v-model="queueData.Blocksize"
							:label="Resources.TAMANHO_DO_BLOCO42316"
							:isReadOnly="blockFormQueue"
							size="large" />
					</div>
					<div>
                        <q-checkbox
                            v-model="queueData.Unicode"
                            :label="Resources.UNICODE63246"
                            :readonly="blockFormQueue" />
                    </div>
                    <div>
                        <q-checkbox
                            v-model="queueData.UsesMsmq"
                            :label="Resources.USA_MSMQ18528"
                            :readonly="blockFormQueue" />
                    </div>
                    <div>
                        <q-checkbox
                            v-model="queueData.Journal"
                            :label="Resources.JOURNAL20931"
                            :readonly="blockFormQueue" />
                    </div>
				</div>
			</template>
		</q-dialog>

		<q-dialog
			v-model="showConfigDialog"
			title="Ack"
			:buttons="buttonsConfig">
			<template #body.content>
				<div class="q-dialog-container">
					<div>
						<q-text-field
							v-model="ackData.source"
							:label="Resources.QUEUE_ORIGEM31278"
							:readonly="blockFormQueueACK"
							size="large" />
					</div>
					<div>
                        <q-text-field
							v-model="ackData.ackQueue"
							:label="Resources.QUEUE_ACK30680"
							:readonly="blockFormQueueACK"
							size="large" />
                    </div>
                    <div>
                        <numeric-input
							v-model="ackData.Blocksize"
							:label="Resources.TAMANHO_DO_BLOCO42316"
							:isReadOnly="blockFormQueueACK"
							size="large" />
                    </div>
				</div>
			</template>
		</q-dialog>
	</row>
</template>

<script>
	// @ is an alias to /src
	import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';

	export default {
		name: 'integration',

		mixins: [reusableMixin],

		emits: ['alert-class', 'update-model'],

		props: {
			model: {
				required: true
			}
		},

		data() {
			return {
				showDialog: false,
				showConfigDialog: false,
				buttons: [],
				buttonsConfig: [],
				queuesProps: [],
				acksProps: [],
				dialogModeQueue: '',
				dialogModeConfig: '',
				queueData: {
					queue: '',
					queueChannel: '',
					path: '',
					Qyear: '',
					Blocksize: '',
					Unicode: false,
					UsesMsmq: false,
					Journal: false,
					Rownum: 0
				},
				ackData: {
					source: '',
					ackQueue: '',
					Blocksize: '',
					Rownum: 0
				},
				alert: {
					isVisible: false,
					alertType: 'info',
					message: ''
				},
				tQueues: {
					rows: [],
					total_rows: 0,
					columns: [{
						label: () => this.$t('ACOES22599'),
						name: "actions",
						slot_name: "actions",
						sort: false,
						column_classes: "thead-actions",
						row_text_alignment: 'text-center',
						column_text_alignment: 'text-center'
					},
					{
						label: () => this.$t('NOME_DA_QUEUE56594'),
						name: "queue",
						sort: true,
						initial_sort: true,
						initial_sort_order: "asc"
					},
					{
						label: () => this.$t('CANAL_DA_QUEUE34934'),
						name: "queueChannel",
						sort: true
					},
					{
						label: () => this.$t('TRAJETO_DA_QUEUE07185'),
						name: "path",
						sort: true
					},
					{
						label: () => this.$t('ANO33022'),
						name: "Qyear",
						sort: true
					},
					{
						label: () => this.$t('UNICODE63246'),
						name: "Unicode",
						sort: true
					},
					{
						label: () => this.$t('USA_MSMQ18528'),
						name: "UsesMsmq",
						sort: true
					},
					{
						label: () => this.$t('JOURNAL20931'),
						name: "Journal",
						sort: true
					},
					{
						label: () => this.$t('TAMANHO_DO_BLOCO42316'),
						name: "Blocksize",
						sort: true
					}],
					config: {
						table_title: () => this.$t('LISTA_DE_MENSAGENS31887'),
						global_search: {
							classes: "qtable-global-search",
							searchOnPressEnter: true,
							showRefreshButton: true,
							//searchDebounceRate: 1000
						},
						preservePageOnDataChange: true
					}
				},
				tAcks: {
					rows: [],
					total_rows: 0,
					columns: [{
						label: () => this.$t('ACOES22599'),
						name: "actions",
						slot_name: "actions",
						sort: false,
						column_classes: "thead-actions",
						row_text_alignment: 'text-center',
						column_text_alignment: 'text-center'
					},
					{
						label: () => this.$t('QUEUE_ORIGEM31278'),
						name: "source",
						sort: true,
						initial_sort: true,
						initial_sort_order: "asc"
					},
					{
						label: () => this.$t('QUEUE_ACK30680'),
						name: "ackQueue",
						sort: true
					},
					{
						label: () => this.$t('TAMANHO_DO_BLOCO42316'),
						name: "Blocksize",
						sort: true
					}],
					config: {
						table_title: () => this.$t('CONFIGURACAO_DE_ACKS49550'),
						global_search: {
							classes: "qtable-global-search",
							searchOnPressEnter: true,
							showRefreshButton: true,
							//searchDebounceRate: 1000
						},
						preservePageOnDataChange: true
					}
				},
				tRepor: {
					rows: [
						{Rep:this.model.pathReports  + '\\' + 'en-US',Lang: 'English'},
						{Rep:this.model.pathReports  + '\\' + 'pt-PT',Lang: 'Português'},
					],
					total_rows: 0,
					columns: [
						{
							label: this.$t('RELATORIO62426'),
							name: "Rep",
							sort: true,
							initial_sort: true,
							initial_sort_order: "asc"
						},
						{
							label: this.$t('LINGUAGEM43329'),
							name: "Lang",
							sort: true
						}
					],
					config: {
						table_title: this.$t('RELATORIOS_POR_LINGU35356'),
						pagination : false,
						global_search: {visibility : false},
						highlight_row_hover: false,
						pagination_info: false
					}
				},
			};
		},
		computed: {
            blockFormQueue() {
                return this.dialogModeQueue === 'delete';
            },
			blockFormQueueACK() {
                return this.dialogModeConfig === 'delete';
            }
        },
		methods: {
			SaveConfigMessageQueue() {
				QUtils.postData('Config', 'SaveConfigMessageQueue', this.model, null, (data) => {
					if (data.Status == 'OK') {
						this.$emit('update-model');
						this.$emit('alert-class', { ResultMsg: data.Message, AlertType: 'success' });
					}
					else {
						this.$emit('alert-class', { ResultMsg: data.Message, AlertType: 'danger' });
					}
				});
			},
			clearQueueValues(){
				this.queueData = {
					queue: '',
					queueChannel: '',
					path: '',
					Qyear: '',
					Blocksize: '',
					Unicode: false,
					UsesMsmq: false,
					Journal: false,
					Rownum: 0
				};
				this.dialogModeQueue = ''
				this.buttons = []
			},
			showQueueModal(mode) {
				this.dialogModeQueue = mode;
				this.getQueueButtons();
				this.showDialog = true;
			},
			changeQueue(queue) {
				this.queueData = { ...queue };
				this.showQueueModal('edit');
			},
			deleteQueue(queue) {
				this.queueData = { ...queue };
				this.showQueueModal('delete');
			},
			createQueue() {
				var url = QUtils.apiActionURL('Config', 'GetNewQueue');
				QUtils.FetchData(url).done((data) => {
					this.queueData = data
					this.showQueueModal('new');
				});
			},
			getQueueButtons() {	
				switch(this.dialogModeQueue) {
					case 'delete':
						this.buttons.push({
							id: 'delete-btn',
							props: {
								label: this.Resources.APAGAR04097,
								bStyle: "danger"
							},
							action: () => {
								this.SaveQueue()
							}
						});
						break;
					case 'edit':
					case 'new':
						this.buttons.push({
							id: 'save-btn',
							props: {
								label: this.Resources.GRAVAR45301,
								bStyle: "primary"
							},
							action: () => {
								this.SaveQueue()
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
					action: () => this.clearQueueValues()
				})
			},
			SaveQueue() {
				const propsQueueValues = {
					...this.queueData,
					FormMode: this.dialogModeQueue
				}
				QUtils.postData('Config', 'SaveQueue', propsQueueValues, null, (data) => {
					if (data.Success) {
						// Update model data
						this.$emit('update-model')
					}

					this.clearQueueValues()
				});
			},
			clearAckValues(){
				this.ackData = {
					source: '',
					ackQueue: '',
					Blocksize: '',
					Rownum: 0
				};
				this.dialogModeConfig = ''
				this.buttonsConfig = []
			},
			showAckModal(mode) {
				this.dialogModeConfig = mode;
				this.getAckButtons();
				this.showConfigDialog = true;
			},
			changeAck(ack) {
				this.ackData = { ...ack };
				this.showAckModal('edit');
			},
			deleteAck(ack) {
				this.ackData = { ...ack };
				this.showAckModal('delete');
			},
			createAck() {
				var url = QUtils.apiActionURL('Config', 'GetNewAck');
				QUtils.FetchData(url).done((data) => {
					this.ackData = data;
					this.showAckModal('new');
				});
			},
			getAckButtons() {	
				switch(this.dialogModeConfig) {
					case 'delete':
						this.buttonsConfig.push({
							id: 'delete-btn',
							props: {
								label: this.Resources.APAGAR04097,
								bStyle: "danger"
							},
							action: () => {
								this.SaveQueueACK()
							}
						});
						break;
					case 'edit':
					case 'new':
						this.buttonsConfig.push({
							id: 'save-btn',
							props: {
								label: this.Resources.GRAVAR45301,
								bStyle: "primary"
							},
							action: () => {
								this.SaveQueueACK()
							}
						});
						break;
					default:
						break;
				}

				this.buttonsConfig.push({
					id: 'cancel-btn',
					props: {
						label: this.Resources.CANCELAR49513
					},
					action: () => this.clearAckValues()
				})
			},
			SaveQueueACK() {
				const propsQueueACKValues = {
					...this.ackData,
					FormMode: this.dialogModeConfig
				}
				QUtils.postData('Config', 'SaveQueueACK', propsQueueACKValues, null, (data) => {
					if (data.Success) {
						// Update model data
						this.$emit('update-model')
					}

					this.clearAckValues()
				});
			},
			initQueues(newModel) {
				this.queuesProps = newModel.MQueues.Queues || [];
				this.acksProps = newModel.MQueues.Acks || [];
			}
		},
		mounted() {
			this.initQueues(this.model)
		},

		watch: {
			model: {
				handler(newModel) {
					this.initQueues(newModel)
				},
				deep: true
			}
		}
	};
</script>
