<template>
	<div id="system_setup_others_container">
		<row>
			<qtable :rows="cfgCores.rows"
					:columns="cfgCores.columns"
					:config="cfgCores.config"
					:totalRows="cfgCores.total_rows"
					class="q-table--borderless">
				<template #actions="props">
				<q-button-group borderless>
					<q-button
					:title="Resources.EDITAR11616"
					@click="editCore(props.row)">
					<q-icon icon="pencil" />
					</q-button>
					<q-button
					:title="Resources.ELIMINAR21155"
					@click="deleteCore(props.row)">
					<q-icon icon="bin" />
					</q-button>
				</q-button-group>
				</template>
				<template #table-footer>
					<tr>
						<td colspan="2">
						<q-button
							:label="Resources.INSERIR43365"
							@click="createCore">
							<q-icon icon="plus-sign" />
						</q-button>
						</td>
					</tr>
				</template>
			</qtable>
		</row>

		<modal_core
			v-if="showCoreModal"
			:Model="modalForms.core.data"
			:SelectLists="SelectLists"
			@updateModal="callbackCore"
			@close="closeCoreModal" />
	</div>
</template>

<script>
// @ is an alias to /src
import { reusableMixin } from '@/mixins/mainMixin';
import { QUtils } from '@/utils/mainUtils';
import bootbox from 'bootbox';
import modal_core from './Core.vue';

export default {
	name: 'others',
	components: { modal_core },
	props: {
		model: {
			required: true
		},
		Cores: {
			required: true
		},
		SelectLists: {
			required: true
		}
	},
	mixins: [reusableMixin],
	emits: ['updateModal'],
	data() {
		var vm = this;
		return {
			modalForms: {
				core: {
					show: true,
					data: { }
				}
			},
			cfgCores: {
				rows: [],
				total_rows: 0,
				columns: [{
					label: vm.$t('ACOES22599'),
					name: "actions",
					slot_name: "actions",
					sort: false,
					column_classes: "thead-actions",
					row_text_alignment: 'text-center',
					column_text_alignment: 'text-center'
				},
				{
					label: vm.$t('INDEX00140'),
					name: "Index",
					sort: true,
					initial_sort: true,
					initial_sort_order: "asc"
				},
				{
					label: vm.$t('ID36840'),
					name: "Id",
					sort: true,
					initial_sort: true,
					initial_sort_order: "asc"
				},
				{
					label: vm.$t('AREA19058'),
					name: "Area",
					sort: true
				},
				{
					label: vm.$t('FSCRAWLER01982'),
					name: "Urlfscrawler",
					sort: true
				},
				{
					label: vm.$t('URL05719'),
					name: "Url",
					sort: true
				},
				{
					label: vm.$t('UTILIZADOR52387'),
					name: "ElasticUser",
					sort: true
				}],
				config: {
					table_title: vm.$t("MOTOR_DE_PESQUISA__E50766"),
					global_search: {
					classes: "qtable-global-search",
					// searchOnPressEnter: true,
					showRefreshButton: true,
					searchDebounceRate: 1000
					},
					server_mode: false,
					preservePageOnDataChange: true
				},
				queryParams: {
					sort: [],
					filters: [],
					global_search: "",
					per_page: 10,
					page: 1,
				}
			},
		};
	},
	methods: {
		closeCoreModal() {
			$('#system_setup_core').modal('hide')
		},
		showCoreModal(mode, core) {
			var vm = this;
			vm.modalForms.core.data = $.extend(true, {}, core);
			vm.modalForms.core.data.FormMode = mode;
			//vm.modalForms.core.show = true;

			$('#system_setup_core').modal('show');
		},
		createCore() {
			var vm = this,
				url = QUtils.apiActionURL('Config', 'GetNewCoreCfg');
			QUtils.FetchData(url).done(function (data) {
				vm.showCoreModal('new', data);
			});
		},
		editCore(core) {
			var vm = this;
			vm.showCoreModal('edit', core);
		},
		deleteCore(core) {
			var vm = this;
			vm.showCoreModal('delete', core);
		},
		callbackCore() {
			this.$emit('updateModal');
		}
	},
	mounted() {
		this.cfgCores.rows = this.model.Cores || [];
		this.cfgCores.total_rows = (this.model.Cores || []).length;
	},
	watch: {
		'model.Cores': {
				handler() {
					this.cfgCores.rows = this.model.Cores || [];
					this.cfgCores.total_rows = (this.model.Cores || []).length;
				},
				deep: true
		}
	}
};
</script>
