<template>
	<div id="system_setup_others_container">
		<row>
			<qtable
				:rows="core"
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

		<q-dialog
			v-model="showDialog"
			:title="Resources.MOTOR_DE_PESQUISA__E50766"
			dismissible
			:buttons="buttons">
			<template #body.content>
				<div class="q-dialog-container">
					<q-text-field
						v-model="rowIndex"
						:label="Resources.INDEX00140"
						:readonly="inEditMode || inDeleteMode"
						required
						size="large" />
					<q-text-field
						v-model="rowId"
						:label="Resources.ID36840"
						:readonly="inEditMode || inDeleteMode"
						required
						size="large"/>
					<q-text-field
						v-model="rowArea"
						:label="Resources.AREA19058"
						:readonly="inDeleteMode"
						size="large" />
					<q-text-field
						v-model="rowUrlfscrawler"
						:label="Resources.FSCRAWLER01982"
						:readonly="inDeleteMode"
						size="large" />
					<q-text-field
						v-model="rowUrl"
						:label="Resources.URL05719"
						:readonly="inDeleteMode"
						size="large" />
					<q-text-field
						v-model="rowElasticUser"
						:label="Resources.UTILIZADOR52387"
						:readonly="inDeleteMode"
						size="large" />
					<password-input
						v-model="rowElasticPsw"
						:label="Resources.PALAVRA_PASSE44126"
						:readonly="inDeleteMode"
						size="large">
					</password-input>
				</div>
			</template>
		</q-dialog>
	</div>
</template>

<script>
// @ is an alias to /src
import { reusableMixin } from '@/mixins/mainMixin';
import { QUtils } from '@/utils/mainUtils';
import QAlert from '@/components/QAlert.vue';

export default {
	name: 'elasticSearch',
	components: { QAlert },
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
	emits: ['updateModal', 'alertClass'],
	data() {
		return {
			showDialog: false,
			buttons: [],
			core: [],
			dialogMode: '',
			rowIndex: '',
			rowId: '',
			rowArea: '',
			rowUrl: '',
			rowUrlfscrawler: '',
			rowElasticUser: '',
			rowElasticPsw: '',
			rowNum: 0,
			cfgCores: {
				rows: [],
				columns: [{
					label: this.$t('ACOES22599'),
					name: "actions",
					slot_name: "actions",
					sort: false,
					column_classes: "thead-actions",
					row_text_alignment: 'text-center',
					column_text_alignment: 'text-center'
				},
				{
					label: this.$t('INDEX00140'),
					name: "Index",
					sort: false
				},
				{
					label: this.$t('ID36840'),
					name: "Id",
					sort: false
				},
				{
					label: this.$t('AREA19058'),
					name: "Area",
					sort: false
				},
				{
					label: this.$t('FSCRAWLER01982'),
					name: "Urlfscrawler",
					sort: false
				},
				{
					label: this.$t('URL05719'),
					name: "Url",
					sort: false
				},
				{
					label: this.$t('UTILIZADOR52387'),
					name: "ElasticUser",
					sort: false
				}],
				config: {
					table_title: this.$t("MOTOR_DE_PESQUISA__E50766"),
					global_search: {
					classes: "qtable-global-search",
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
			tRepor: {
				rows: [
				{Rep:this.model.pathReports  + '\\' + 'en-US',Lang: 'English'},
				{Rep:this.model.pathReports  + '\\' + 'pt-PT',Lang: 'Português'},
				],
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
		inDeleteMode() {
			return this.dialogMode === 'delete';
		},
		inEditMode() {
			return this.dialogMode === 'edit';
		},
	},
	methods: {
		showCoreModal(mode) {
			this.dialogMode = mode;
			this.getButtonsDialog();
			this.showDialog = true;
		},
		createCore() {
			var url = QUtils.apiActionURL('Config', 'GetNewCoreCfg');
			QUtils.FetchData(url).done((data) => {
				this.showCoreModal('new');
			});
		},
		editCore(core) {
			this.rowId = core.Id
			this.rowIndex = core.Index
			this.rowArea = core.Area
			this.rowElasticPsw = core.ElasticPsw
			this.rowElasticUser = core.ElasticUser
			this.rowUrl = core.Url
			this.rowUrlfscrawler = core.Urlfscrawler
			this.rowNum = core.Rownum,
			this.showCoreModal('edit');
		},
		deleteCore(core) {
			this.rowId = core.Id
			this.rowIndex = core.Index
			this.rowArea = core.Area
			this.rowElasticPsw = core.ElasticPsw
			this.rowElasticUser = core.ElasticUser
			this.rowUrl = core.Url
			this.rowUrlfscrawler = core.Urlfscrawler
			this.rowNum = core.Rownum,
			this.showCoreModal('delete');
		},
		SaveCoreCfg() {
			const coreValues = {
				FormMode: this.dialogMode,
				Id: this.rowId,
				Index: this.rowIndex,
				Area: this.rowArea,
				ElasticPsw: this.rowElasticPsw,
				Url: this.rowUrl,
				Urlfscrawler: this.rowUrlfscrawler,
				ElasticUser: this.rowElasticUser,
				Rownum: this.rowNum
			}
			QUtils.postData('Config', 'SaveCoreCfg', coreValues, null, (data) => {
				if (data.Success) {
					switch (coreValues.FormMode) {
					case 'new':
						this.core.push(
						{
							FormMode: this.dialogMode,
							Id: this.rowId,
							Index: this.rowIndex,
							Area: this.rowArea,
							ElasticPsw: this.rowElasticPsw,
							Url: this.rowUrl,
							Urlfscrawler: this.rowUrlfscrawler,
							ElasticUser: this.rowElasticUser,
							Rownum: this.core.length
						}
					)
					break;
					case 'edit':
						const newCoreIndex = this.core.findIndex(value => value.Id == this.rowId)
						this.core[newCoreIndex].Index = this.rowIndex;
						this.core[newCoreIndex].Area = this.rowArea;
						this.core[newCoreIndex].ElasticPsw = this.rowElasticPsw;
						this.core[newCoreIndex].Url = this.rowUrl;
						this.core[newCoreIndex].Urlfscrawler = this.rowUrlfscrawler;
						this.core[newCoreIndex].ElasticUser = this.rowElasticUser;
						this.core[newCoreIndex].Rownum = this.rowNum;
						break;
					case 'delete':
						this.core = this.core.filter(prop => prop.Id != this.rowId).sort((a, b) => a.rowNum - b.rowNum);
						this.core.forEach((core, idx) => {
							core.Rownum = idx
						})
						break;
					default:
						break;
					}
					// Update model data
					this.$emit('updateModal')
				}

				this.clearCoreValues()
			});
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
							this.SaveCoreCfg()
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
							this.SaveCoreCfg()
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
				action: () => this.clearCoreValues()
			})
		},
		clearCoreValues(){
			this.dialogMode = ''
			this.rowId = ''
			this.rowIndex = '',
			this.rowArea = '',
			this.rowElasticPsw = '',
			this.rowUrl = '',
			this.rowUrlfscrawler = ''
			this.rowElasticUser = ''
			this.buttons = []
		}
	},
	mounted() {
		this.core = this.model.Cores || [];
	}
};
</script>
