<template>
    <row>
		<row>
			<q-row-container>
				<numeric-input
					v-model="model.MQueues.Journaltimeout"
					:label="systemConfigTexts.journalTimeoutLabel"
					size="xlarge"
					integer-only />
				<numeric-input
					v-model="model.MQueues.Maxsendnumber"
					:label="systemConfigTexts.maxSendNumberLabel"
					size="xlarge"
					integer-only />
			</q-row-container>
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
							variant="text"
							:title="hardcodedTexts.edit"
							@click="changeQueue(props.row)">
							<q-icon icon="pencil" />
						</q-button>
						<q-button
							variant="text"
							:title="hardcodedTexts.delete"
							@click="deleteQueue(props.row)">
							<q-icon icon="bin" />
						</q-button>
					</q-button-group>
				</template>
				<template #table-footer>
					<tr>
						<td colspan="8">
							<q-button
								:label="hardcodedTexts.insert"
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
						variant="text"
						:title="hardcodedTexts.edit"
						@click="changeAck(props.row)">
						<q-icon icon="pencil" />
					</q-button>
					<q-button
						variant="text"
						:title="hardcodedTexts.delete"
						@click="deleteAck(props.row)">
						<q-icon icon="bin" />
					</q-button>
					</q-button-group>
				</template>
				<template #table-footer>
					<tr>
						<td colspan="3">
							<q-button
								:label="hardcodedTexts.insert"
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
			:title="systemConfigTexts.queueTitle"
			:buttons="buttons">
			<template #body.content>
				<div class="q-dialog-container">
					<div>
						<q-text-field
							v-model="queueData.queue"
							:label="systemConfigTexts.queueNameLabel"
							:readonly="blockFormQueue"
							size="large" />
					</div>
					<div>
						<q-text-field
							v-model="queueData.queueChannel"
							:label="systemConfigTexts.queueChannelLabel"
							:readonly="blockFormQueue"
							size="large" />
					</div>
					<div>
						<q-text-field
							v-model="queueData.path"
							:label="systemConfigTexts.queuePathLabel"
							:readonly="blockFormQueue"
							size="large" />
					</div>
					<div>
						<q-text-field
							v-model="queueData.Qyear"
							:label="hardcodedTexts.yearLabel"
							:readonly="blockFormQueue"
							size="large" />
					</div>
					<div>
						<numeric-input
							v-model="queueData.Blocksize"
							:label="systemConfigTexts.blockSizeLabel"
							:isReadOnly="blockFormQueue"
							size="large" />
					</div>
					<div>
                        <q-checkbox
                            v-model="queueData.Unicode"
                            :label="systemConfigTexts.unicodeLabel"
                            :readonly="blockFormQueue" />
                    </div>
                    <div>
                        <q-checkbox
                            v-model="queueData.UsesMsmq"
                            :label="systemConfigTexts.usesMsmqLabel"
                            :readonly="blockFormQueue" />
                    </div>
                    <div>
                        <q-checkbox
                            v-model="queueData.Journal"
                            :label="systemConfigTexts.journalLabel"
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
							:label="systemConfigTexts.sourceQueueLabel"
							:readonly="blockFormQueueACK"
							size="large" />
					</div>
					<div>
                        <q-text-field
							v-model="ackData.ackQueue"
							:label="systemConfigTexts.sourceQueueLabel"
							:readonly="blockFormQueueACK"
							size="large" />
                    </div>
                    <div>
                        <numeric-input
							v-model="ackData.Blocksize"
							:label="systemConfigTexts.blockSizeLabel"
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
	import { texts } from '@/resources/hardcodedTexts.ts';
	import { SystemConfigTexts } from '@/resources/viewResources.ts';

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
				dialogModeAck: '',
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
						label: () => '',
						name: "actions",
						slot_name: "actions",
						sort: false,
						column_classes: "thead-actions",
						row_text_alignment: 'text-center',
						column_text_alignment: 'text-center'
					},
					{
						label: () => '',
						name: "queue",
						sort: true,
						initial_sort: true,
						initial_sort_order: "asc"
					},
					{
						label: '',
						name: "queueChannel",
						sort: true
					},
					{
						label: () => '',
						name: "path",
						sort: true
					},
					{
						label: () => '',
						name: "Qyear",
						sort: true
					},
					{
						label: () => '',
						name: "Unicode",
						sort: true
					},
					{
						label: () => '',
						name: "UsesMsmq",
						sort: true
					},
					{
						label: () => '',
						name: "Journal",
						sort: true
					},
					{
						label: () => '',
						name: "Blocksize",
						sort: true
					}],
					config: {
						table_title: () => '',
						global_search: {
							classes: "qtable-global-search",
							searchOnPressEnter: true,
							showRefreshButton: true
						},
						preservePageOnDataChange: true
					}
				},
				tAcks: {
					rows: [],
					total_rows: 0,
					columns: [{
						label: () => '',
						name: "actions",
						slot_name: "actions",
						sort: false,
						column_classes: "thead-actions",
						row_text_alignment: 'text-center',
						column_text_alignment: 'text-center'
					},
					{
						label: () => '',
						name: "source",
						sort: true,
						initial_sort: true,
						initial_sort_order: "asc"
					},
					{
						label: () => '',
						name: "ackQueue",
						sort: true
					},
					{
						label: () => '',
						name: "Blocksize",
						sort: true
					}],
					config: {
						table_title: () => '',
						global_search: {
							classes: "qtable-global-search",
							searchOnPressEnter: true,
							showRefreshButton: true
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
							label: '',
							name: "Rep",
							sort: true,
							initial_sort: true,
							initial_sort_order: "asc"
						},
						{
							label: '',
							name: "Lang",
							sort: true
						}
					],
					config: {
						table_title: '',
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
                return this.dialogModeAck === 'delete';
            },
			hardcodedTexts() {
				return {
					edit: this.Resources[texts.edit],
					delete: this.Resources[texts.delete],
					insert: this.Resources[texts.insert],
					erase: this.Resources[texts.erase],
					save: this.Resources[texts.save],
					cancel: this.Resources[texts.cancel],
					yearLabel: this.Resources[texts.yearLabel],
					actions: this.Resources[texts.actions],
					languageLabel: this.Resources[texts.languageLabel],
				}
			},
			systemConfigTexts() {
				return new SystemConfigTexts(this)
			}
        },
		methods: {
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
								label: this.hardcodedTexts.erase,
								variant: 'bold',
								color: 'danger'
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
								label: this.hardcodedTexts.save,
								variant: 'bold'
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
						label: this.hardcodedTexts.cancel
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
				this.dialogModeAck = ''
				this.buttonsConfig = []
			},
			showAckModal(mode) {
				this.dialogModeAck = mode;
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
				switch(this.dialogModeAck) {
					case 'delete':
						this.buttonsConfig.push({
							id: 'delete-btn',
							props: {
								label: this.hardcodedTexts.erase,
								variant: 'bold',
								color: 'danger'
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
								label: this.hardcodedTexts.save,
								variant: 'bold'
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
						label: this.hardcodedTexts.cancel
					},
					action: () => this.clearAckValues()
				})
			},
			SaveQueueACK() {
				const propsQueueACKValues = {
					...this.ackData,
					FormMode: this.dialogModeAck
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

			this.tQueues.columns[0].label = this.hardcodedTexts.actions;
			this.tQueues.columns[1].label = this.systemConfigTexts.queueNameLabel;
			this.tQueues.columns[2].label = this.systemConfigTexts.queueChannelLabel;
			this.tQueues.columns[3].label = this.systemConfigTexts.queuePathLabel;
			this.tQueues.columns[4].label = this.hardcodedTexts.yearLabel;
			this.tQueues.columns[5].label = this.systemConfigTexts.unicodeLabel;
			this.tQueues.columns[6].label = this.systemConfigTexts.usesMsmqLabel;
			this.tQueues.columns[7].label = this.systemConfigTexts.journalLabel;
			this.tQueues.columns[8].label = this.systemConfigTexts.blockSizeLabel;
			this.tQueues.config.table_title = this.systemConfigTexts.messageListTitle;

			this.tAcks.columns[0].label = this.hardcodedTexts.actions;
			this.tAcks.columns[1].label = this.systemConfigTexts.sourceQueueLabel;
			this.tAcks.columns[2].label = this.systemConfigTexts.ackQueueLabel;
			this.tAcks.columns[3].label = this.systemConfigTexts.blockSizeLabel;
			this.tAcks.config.table_title = this.systemConfigTexts.acksConfigTitle;

			this.tRepor.columns[0].label = this.systemConfigTexts.reportLabel;
			this.tRepor.columns[1].label = this.hardcodedTexts.languageLabel;
			this.tRepor.config.table_title = this.systemConfigTexts.reportsByLanguageTitle;
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
