<template>
    <row>
		<row>
			<q-row-container>
				<numeric-input
					v-model="model.MQueues.Journaltimeout"
					:label="resources.journalTimeoutLabel"
					size="xlarge"
					integer-only />
				<numeric-input
					v-model="model.MQueues.Maxsendnumber"
					:label="resources.maxSendNumberLabel"
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
			:title="resources.queueTitle"
			:buttons="buttons">
			<template #body.content>
				<div class="q-dialog-container">
					<div>
						<q-text-field
							v-model="queueData.queue"
							:label="resources.queueNameLabel"
							:readonly="blockFormQueue"
							size="large" />
					</div>
					<div>
						<q-text-field
							v-model="queueData.queueChannel"
							:label="resources.queueChannelLabel"
							:readonly="blockFormQueue"
							size="large" />
					</div>
					<div>
						<q-text-field
							v-model="queueData.path"
							:label="resources.queuePathLabel"
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
							:label="resources.blockSizeLabel"
							:isReadOnly="blockFormQueue"
							size="large" />
					</div>
					<div>
                        <q-checkbox
                            v-model="queueData.Unicode"
                            :label="resources.unicodeLabel"
                            :readonly="blockFormQueue" />
                    </div>
                    <div>
                        <q-checkbox
                            v-model="queueData.UsesMsmq"
                            :label="resources.usesMsmqLabel"
                            :readonly="blockFormQueue" />
                    </div>
                    <div>
                        <q-checkbox
                            v-model="queueData.Journal"
                            :label="resources.journalLabel"
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
							:label="resources.sourceQueueLabel"
							:readonly="blockFormQueueACK"
							size="large" />
					</div>
					<div>
                        <q-text-field
							v-model="ackData.ackQueue"
							:label="resources.sourceQueueLabel"
							:readonly="blockFormQueueACK"
							size="large" />
                    </div>
                    <div>
                        <numeric-input
							v-model="ackData.Blocksize"
							:label="resources.blockSizeLabel"
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
	import { computed } from 'vue';

	export default {
		name: 'integration',

		mixins: [reusableMixin],

		emits: ['alert-class', 'update-model'],

		props: {
			model: {
				required: true
			},
			resources: {
				type: Object,
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
						label: this.resources.actions,
						name: "actions",
						slot_name: "actions",
						sort: false,
						column_classes: "thead-actions",
						row_text_alignment: 'text-center',
						column_text_alignment: 'text-center'
					},
					{
						label: this.resources.queueNameLabel,
						name: "queue",
						sort: true,
						initial_sort: true,
						initial_sort_order: "asc"
					},
					{
						label: this.resources.queueChannelLabel,
						name: "queueChannel",
						sort: true
					},
					{
						label: this.resources.queuePathLabel,
						name: "path",
						sort: true
					},
					{
						label: computed(() => this.Resources[texts.yearLabel]),
						name: "Qyear",
						sort: true
					},
					{
						label: this.resources.unicodeLabel,
						name: "Unicode",
						sort: true
					},
					{
						label: this.resources.usesMsmqLabel,
						name: "UsesMsmq",
						sort: true
					},
					{
						label: this.resources.journalLabel,
						name: "Journal",
						sort: true
					},
					{
						label: this.resources.blockSizeLabel,
						name: "Blocksize",
						sort: true
					}],
					config: {
						table_title: this.resources.messageListTitle,
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
						label: this.resources.actions,
						name: "actions",
						slot_name: "actions",
						sort: false,
						column_classes: "thead-actions",
						row_text_alignment: 'text-center',
						column_text_alignment: 'text-center'
					},
					{
						label: this.resources.sourceQueueLabel,
						name: "source",
						sort: true,
						initial_sort: true,
						initial_sort_order: "asc"
					},
					{
						label: this.resources.ackQueueLabel,
						name: "ackQueue",
						sort: true
					},
					{
						label: this.resources.blockSizeLabel,
						name: "Blocksize",
						sort: true
					}],
					config: {
						table_title: this.resources.acksConfigTitle,
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
							label: this.resources.reportLabel,
							name: "Rep",
							sort: true,
							initial_sort: true,
							initial_sort_order: "asc"
						},
						{
							label: computed(() => this.Resources[texts.languageLabel]),
							name: "Lang",
							sort: true
						}
					],
					config: {
						table_title: this.resources.reportsByLanguageTitle,
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
					languageLabel: this.Resources[texts.languageLabel],
				}
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
