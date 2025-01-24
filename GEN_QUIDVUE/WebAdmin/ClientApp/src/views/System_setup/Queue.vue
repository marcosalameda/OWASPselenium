<template>
<div id="system_setup_queue_container">
	<row>
		<br />
		<row>
			<div class="control-join-group">
				<text-input v-model="model.MQueues.Journaltimeout" :label="Resources.JOURNAL_TIMEOUT__MIN38634" :size="'xlarge'"></text-input>
				<text-input v-model="model.MQueues.Maxsendnumber" :label="Resources.NUMERO_MAXIMO_DE_TEN51201" :size="'xlarge'"></text-input>
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
			<qtable :rows="tQueues.rows"
					:columns="tQueues.columns"
					:config="tQueues.config"
					:totalRows="tQueues.total_rows"
					class="q-table--borderless">
				<template #actions="props">
					<q-button-group borderless>
					<q-button
						:title="Resources.EDITAR11616"
						@click="editQueue(props.row)">
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
								<q-icon icon="plus-sign" />
							</q-button>
						</td>
					</tr>
				</template>
			</qtable>
		</row>

		<row>
			<qtable :rows="tAcks.rows"
					:columns="tAcks.columns"
					:config="tAcks.config"
					:totalRows="tAcks.total_rows"
					class="q-table--borderless">
				<template #actions="props">
					<q-button-group borderless>
					<q-button
						:title="Resources.EDITAR11616"
						@click="editAck(props.row)">
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
								<q-icon icon="plus-sign" />
							</q-button>
						</td>
					</tr>
				</template>
			</qtable>
		</row>

		<queue_modal :show="queueModal.show" :Model="queueModal.data" @close="reloadMQueues"></queue_modal>
		<ack_modal :show="ackModal.show" :Model="ackModal.data" @close="reloadMQueues"></ack_modal>
	</row>
</div>
</template>

<script>
	// @ is an alias to /src
	import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';
	import bootbox from 'bootbox';
	import queue_modal from './Queue_modal';
	import ack_modal from './Ack_modal';

	export default {
		name: 'queue',
		mixins: [reusableMixin],
		emits: ['reloadMQueues'],
		components: { queue_modal, ack_modal },
		props: {
			model: {
				required: true
			}
		},
		data() {
			var vm = this;
			return {
				queueModal: {
					show: false,
					data: { }
				},
				ackModal: {
					show: false,
					data: { }
				},
				tQueues: {
					rows: [],
					total_rows: 0,
					columns: [{
						label: () => vm.$t('ACOES22599'),
						name: "actions",
						slot_name: "actions",
						sort: false,
						column_classes: "thead-actions",
						row_text_alignment: 'text-center',
						column_text_alignment: 'text-center'
					},
					{
						label: () => vm.$t('NOME_DA_QUEUE56594'),
						name: "queue",
						sort: true,
						initial_sort: true,
						initial_sort_order: "asc"
					},
					{
						label: () => vm.$t('CANAL_DA_QUEUE34934'),
						name: "queueChannel",
						sort: true
					},
					{
						label: () => vm.$t('TRAJETO_DA_QUEUE07185'),
						name: "path",
						sort: true
					},
					{
						label: () => vm.$t('ANO33022'),
						name: "Qyear",
						sort: true
					},
					{
						label: () => vm.$t('UNICODE63246'),
						name: "Unicode",
						sort: true
					},
					{
						label: () => vm.$t('USA_MSMQ18528'),
						name: "UsesMsmq",
						sort: true
					},
					{
						label: () => vm.$t('JOURNAL20931'),
						name: "Journal",
						sort: true
					},
					{
						label: () => vm.$t('TAMANHO_DO_BLOCO42316'),
						name: "Blocksize",
						sort: true
					}],
					config: {
						table_title: () => vm.$t('LISTA_DE_MENSAGENS31887'),
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
						label: () => vm.$t('ACOES22599'),
						name: "actions",
						slot_name: "actions",
						sort: false,
						column_classes: "thead-actions",
						row_text_alignment: 'text-center',
						column_text_alignment: 'text-center'
					},
					{
						label: () => vm.$t('QUEUE_ORIGEM31278'),
						name: "source",
						sort: true,
						initial_sort: true,
						initial_sort_order: "asc"
					},
					{
						label: () => vm.$t('QUEUE_ACK30680'),
						name: "ackQueue",
						sort: true
					},
					{
						label: () => vm.$t('TAMANHO_DO_BLOCO42316'),
						name: "Blocksize",
						sort: true
					}],
					config: {
						table_title: () => vm.$t('CONFIGURACAO_DE_ACKS49550'),
						global_search: {
							classes: "qtable-global-search",
							searchOnPressEnter: true,
							showRefreshButton: true,
							//searchDebounceRate: 1000
						},
						preservePageOnDataChange: true
					}
				}
			};
		},
		methods: {
			SaveConfigMessageQueue() {
				QUtils.postData('Config', 'SaveConfigMessageQueue', this.model, null, function (data) {
					bootbox.alert(data.Message);
				});
			},
			initTables() {
				var vm = this;
				vm.tQueues.rows = vm.model.MQueues.Queues || [];
				vm.tQueues.total_rows = vm.tQueues.rows.length;

				vm.tAcks.rows = vm.model.MQueues.Acks || [];
				vm.tAcks.total_rows = vm.tAcks.rows.length;
			},
			createQueue() {
				var vm = this;
				QUtils.FetchData(QUtils.apiActionURL('Config', 'GetNewQueue')).done(function (data) {
					vm.queueModal.data = data;
					vm.queueModal.data.FormMode = 'new';
					vm.queueModal.show = true;
				});
			},
			editQueue(row) {
				this.queueModal.data = $.extend({}, row);
				this.queueModal.data.FormMode = 'edit';
				this.queueModal.show = true;
			},
			deleteQueue(row) {
				this.queueModal.data = $.extend({}, row);
				this.queueModal.data.FormMode = 'delete';
				this.queueModal.show = true;
			},
			createAck() {
				var vm = this;
				QUtils.FetchData(QUtils.apiActionURL('Config', 'GetNewAck')).done(function (data) {
					vm.ackModal.data = data;
					vm.ackModal.data.FormMode = 'new';
					vm.ackModal.show = true;
				});
			},
			editAck(row) {
				this.ackModal.data = $.extend({}, row);
				this.ackModal.data.FormMode = 'edit';
				this.ackModal.show = true;
			},
			deleteAck(row) {
				this.ackModal.data = $.extend({}, row);
				this.ackModal.data.FormMode = 'delete';
				this.ackModal.show = true;
			},
			reloadMQueues: function (reload) {
				this.queueModal.show = this.ackModal.show = false;
				this.queueModal.data = this.ackModal.data = {};
				if (reload) {
					this.$emit('reloadMQueues');
				}
			}
		},
		created() {
			this.initTables();
		},
		updated(){
			this.initTables();
		}
	};
</script>
