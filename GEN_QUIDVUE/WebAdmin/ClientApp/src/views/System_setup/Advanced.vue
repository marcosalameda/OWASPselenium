<template>
	<div id="system_setup_others_container">
		<row>
			<qtable :rows="advancedProps"
					:columns="tAdvP.columns"
					:config="tAdvP.config"
					:totalRows="tAdvP.total_rows"
					class="q-table--borderless">
				<template #actions="props">
					<q-button-group borderless>
						<q-button
						:title="Resources.EDITAR11616"
						@click="changeAdvancedProperty(props.row)">
						<q-icon icon="pencil" />
						</q-button>
						<q-button
						:title="Resources.ELIMINAR21155"
						@click="deleteAdvancedProperty(props.row)">
						<q-icon icon="bin" />
						</q-button>
					</q-button-group>
				</template>
				<template #table-footer>
					<tr>
						<td colspan="3">
						<q-button
							:label="Resources.INSERIR43365"
							@click="createAdvancedProperty">
							<q-icon icon="plus-sign" />
						</q-button>
						</td>
					</tr>
				</template>
			</qtable>
		</row>

		<q-dialog
			v-model="showDialog"
			:title="Resources.PROPERTY43977"
			dismissible
			:buttons="buttons">
			<template #body.content>
				<div class="q-dialog-container">
					<div v-if="hasInitProperties && !showNewKeyInput && !(inEditMode || inDeleteMode)">
						<q-select
							v-model="rowKey"
							v-if="SelectLists"
							:label="Resources.KEY01046"
							:items="SelectLists.PropertyList"
							size="medium"
							:readonly="inEditMode || inDeleteMode"
							item-value="Value"
							item-label="Text" />
						<q-button
							b-style="secondary"
							@click="showNewKeyInput=true"
							:label="Resources.INSERT_NEW_KEY15186">
								<q-icon icon="pencil" />
						</q-button>
					</div>
					<div v-else>
						<q-text-field
							v-model="rowKey"
							:class="{ 'input-error' : isSameKey }"
							:label="Resources.KEY01046"
							:readonly="inEditMode || inDeleteMode"
							required
							size="large">
							<template #extras v-if="isSameKey">
								<span class="mdi mdi-information-outline"></span>
								{{ Resources.THIS_KEY_ALREADY_EXI09944 }}
							</template>
						</q-text-field>
						<q-button
							b-style="secondary"
							@click="showNewKeyInput=false"
							:label="Resources.LIST_DEFAULT_KEYS58194"
							v-show="hasInitProperties && !(inEditMode || inDeleteMode)">
								<q-icon icon="list" />
						</q-button>
					</div>
					<div>
						<q-text-field
							v-model="rowValue"
							:label="Resources.VALUE10285"
							:readonly="inDeleteMode"
							required
							size="large" />
					</div>
				</div>
			</template>
		</q-dialog>
	</div>
</template>

<script>
// @ is an alias to /src
import { reusableMixin } from '@/mixins/mainMixin';
import { QUtils } from '@/utils/mainUtils';

export default {
	name: 'advanced',
	props: {
		model: {
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
			advancedProps: [],
			rowKey: '',
			rowValue: '',
			dialogMode: '',
			tAdvP: {
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
					label: this.$t('KEY01046'),
					name: "Key",
					sort: true,
					initial_sort: true,
					initial_sort_order: "asc"
				},
				{
					label: this.$t('VALUE10285'),
					name: "Val",
					sort: true
				}],
				config: {
					table_title: this.$t('PROPRIEDADES_AVANCAD23972')
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
		inEditMode() {
			return this.dialogMode === 'edit';
		},
		inDeleteMode() {
			return this.dialogMode === 'delete';
		},
		hasInitProperties() {
			return this.SelectLists.PropertyList.length > 0;
		},
		isSameKey() {
			return this.advancedProps.some(prop => prop.Key.toLowerCase() === this.rowKey.toLowerCase()) && this.dialogMode === 'new'
		},
		invalidProps() {
			return this.rowKey === '' || this.rowValue === '' || (this.dialogMode === 'new' && this.isSameKey)
		}
	},
	methods: {
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
							this.SaveMoreProperty()
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
							this.SaveMoreProperty()
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
				action: () => this.clearMorePropertyValues()
			})
		},
		SaveMoreProperty() {
			const propsValues = {
				Key: this.rowKey,
				Val: this.rowValue,
				FormMode: this.dialogMode,
			}
			QUtils.postData('Config', 'SaveMoreProperty', propsValues, { appId: this.$store.state.currentApp }, (data) => {
				if (data.emptyVal) { this.$emit('alertClass', { ResultMsg: this.Resources.VALUE_CANNOT_BE_EMPT24668, AlertType: 'danger' }); }
				else if (!data.success) { this.$emit('alertClass', { ResultMsg: this.Resources.THIS_KEY_ALREADY_EXI09944, AlertType: 'danger' }); }
				else {
					switch (propsValues.FormMode) {
					case 'new':
						this.advancedProps.push(
						{
							Key: this.rowKey,
							Val: this.rowValue,
							FormMode: this.dialogMode
						}
					)
					break;
					case 'edit':
						const newPropIndex = this.advancedProps.findIndex(value => value.Key == this.rowKey)
						this.advancedProps[newPropIndex].Val = this.rowValue;
						break;
					case 'delete':
						if (data.initProp) {
							eventData.moreProperty = data.moreProperty;
							this.$emit('alertClass', { ResultMsg: this.Resources.CANNOT_DELETE_THIS_P45050, AlertType: 'danger' });
						} else {
							this.advancedProps = this.advancedProps.filter(prop => prop.Key != this.rowKey);
						}
						break;
					default:
						break;
					}
					this.clearMorePropertyValues()
					// Update model data
					this.$emit('updateModal')
				}
			});
		},
		clearMorePropertyValues(){
			this.rowKey = ''
			this.rowValue = ''
			this.dialogMode = ''
			this.buttons = []
		},
		showAdvancedPropertyModal(mode) {
			this.dialogMode = mode;
			this.getButtonsDialog();
			this.showDialog = true;
		},
		changeAdvancedProperty(moreProperty) {
			this.rowKey = moreProperty.Key
			this.rowValue = moreProperty.Val
			this.showAdvancedPropertyModal('edit');
		},
		deleteAdvancedProperty(moreProperty) {
			this.rowKey = moreProperty.Key
			this.rowValue = moreProperty.Val
			this.showAdvancedPropertyModal('delete');
		},
		createAdvancedProperty() {
			var vm = this;
			var url = QUtils.apiActionURL('Config', 'GetNewMorePropertyCfg');
			QUtils.FetchData(url).done((data) => {
				vm.showAdvancedPropertyModal('new');
			});
		},
	},
	mounted() {
		this.advancedProps = this.model.AdvancedProperties || [];
	},
	watch: {
		invalidProps(newValue) {
			if (this.buttons.length > 0)
				this.buttons[0].props.disabled = newValue
		}
	}
};
</script>
