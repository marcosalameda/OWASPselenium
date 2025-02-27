<template>
	<div v-if="!showErrorDialog">
		<q-card
			class="q-card--admin-default"
			:title="texts.EXIBICAO16445"
			width="block">
			<div class="data-systems__inputs">
				<q-select
					v-model="model.DefaultYear"
					size="small"
					:items="defaultDsItems"
					:label="texts.SISTEMA_DE_DADOS_PAD13413">
					<template #extras>
						<q-icon icon="information-outline" />
						{{ texts.O_SISTEMA_DE_DADOS_U47595 }}
					</template>					
				</q-select>
				<q-checkbox
					v-model="model.HideYears" 
					:label="texts.OCULTAR_SISTEMAS_DE_60940">
					<template #extras>
						<q-icon icon="information-outline" />
						{{ texts.QUANDO_SELECIONADO__16895 }}
					</template>
				</q-checkbox>
			</div>
		</q-card>

		<div
			v-if="notConfiguredDataSystems"
			class="q-table__alert">
			<q-alert
				type="warning"
				:dismissTime="1.5"
				:title="texts.SISTEMAS_DE_DADOS_IN53544"
				:text="texts.DEVE_CONCLUIR_A_CONF15894" />
		</div>

		<qtable :rows="dataSystems"
			:columns="tableConfig.columns"
			:config="tableConfig.config"
			:classes="dsTableRowClasses"
			class="q-table--borderless">

			<template #actions="props">
				<div class="data-systems__table--btns">
					<q-button
						:title="texts.CONFIGURAR09280"
						bStyle="tertiary"
						@click="configureDataSystem(props.row)">
						<q-icon icon="pencil" />
					</q-button>
					<q-button
						:title="texts.DUPLICAR09748"
						bStyle="tertiary"
						@click="duplicateDataSystem(props.row)">
						<q-icon icon="duplicate" />
					</q-button>
				</div>
			</template>
			<template #table-footer>
				<tr>
					<td colspan="5">
						<q-button :label="texts.CRIAR_UM_NOVO_SISTEM49777"
							@click="showDataSystemDialog" />
					</td>
				</tr>
			</template>
		</qtable>

		<hr>

		<row>
			<q-button 
				b-style="primary"
				:label="texts.GRAVAR_CONFIGURACAO36308"
				@click="SaveConfigDataSystems" />
		</row>
	</div>

	<q-dialog 
		v-model="showErrorDialog"
		:title="texts.ERRO38355"
		:text="errorDialogText"
		:buttons="errorDialogButtons" />

	<q-dialog 
		v-model="showNewSystemDialog"
		:title="texts.CRIAR_UM_NOVO_SISTEM49777"
		:buttons="newSystemDialogButtons">
		<template #body.content>
			<div 
				class="data-systems__dialog--container" >
				<q-text-field 
					v-model="newDsName"
					:class="{ 'data-systems__inputs--with-errors': invalidNewDataSystemName }"
					size="block"
					:label="texts.NOME_DO_SISTEMA_DE_D18974">
					<template #extras v-if="invalidNewDataSystemName">
						<q-icon icon="information-outline" />
						{{ texts.OS_NOMES_DOS_SISTEMA01515 }}
					</template>
				</q-text-field>
				<q-text-field 
					v-model="newDsSchema"
					:class="{ 'data-systems__inputs--with-errors': invalidNewDbName }"
					size="block"
					:label="texts.NOME_DA_BASE_DE_DADO25105">
					<template #extras v-if="invalidNewDbName">
						<q-icon icon="information-outline" />
						{{ texts.OS_NOMES_DAS_BASES_D40646 }}
					</template>
				</q-text-field>
			</div>
		</template>
	</q-dialog>

</template>
<script>
	// Utils
	import { QUtils } from '@/utils/mainUtils'

	export default {
		name: 'datasystems',

		emits: ['change-tab', 'alert-class'],

		data() {
			return {
				/**
				 * The data systems (Years) of the application.
				 */
				dataSystems: [],

				/**
				 * True if the error dialog is to be shown, false otherwise.
				 */
				showErrorDialog: false,

				/**
				 * Text to be displayed in the error dialog.
				 */
				errorDialogText: '',

				/**
				 * Action buttons of the error dialog.
				 */
				errorDialogButtons: [],

				/**
				 * True if the new data system dialog is to be shown, false otherwise.
				 */
				showNewSystemDialog: false,

				/**
				 * Action buttons of the new data system dialog.
				 */
				newSystemDialogButtons: [],

				/**
				 * The name (Year) of the data system to be created. Used in the "Create a data system" dialog.
				 */
				newDsName: '',

				/**
				 * The database name (Schema) of the data system to be created. Used in the "Create a data system" dialog.
				 */
				newDsSchema: '',

				/**
				 * The database type (SQLServer, SQLite, ...) of the data system to be created. Used in the "Create a data system" dialog when duplicating.
				 */
				newDsType: '',

				/**
				 * The server of the data system to be created. Used in the "Create a data system" dialog when duplicating.
				 */
				newDsServer: '',

				/**
				 * Checks the validity of the default data system. True if no data system.Year coincides with the default, false otherwise.
				 */
				invalidDefaultDataSystem: false,

				/**
				 * The configuration of the data systems table.
				 */
				tableConfig: {
					columns: [
						{
							label: this.texts.ACOES22599,
							name: 'actions',
							sort: false,
							column_classes: 'thead-actions',
							row_text_alignment: 'text-center',
							column_text_alignment: 'text-center'
						},
						{
							label: this.texts.NOME_DO_SISTEMA_DE_D18974,
							name: 'Year',
							sort: true,
							initial_sort: true,
							initial_sort_order: "asc"
						},
						{
							label: this.texts.NOME_DA_BASE_DE_DADO25105,
							name: 'DbName',
							sort: true
						},
						{
							label: this.texts.NOME_DO_SERVIDOR13641,
							name: 'DbServer',
							sort: true
						},
						{
							label: this.texts.DATABASE_VERSION15344,
							name: 'DbVersion',
							sort: false
						},
						{
							label: '',
							name: 'DbType',
							sort: false,
							visibility: false
						},
						{
							label: '',
							name: 'Configured',
							sort: false,
							visibility: false
						}
					],
					config: {
						table_title: this.texts.SISTEMAS_DE_DADOS45551,
						pagination: this.showDsTablePagination,
						pagination_info: this.showDsTablePagination,
						per_page: 5,
						highlight_row_hover: false,
						global_search: {
							visibility: false
						}
					}
				}
			}
		},

		props: {
			/**
			 * Application and database metadata.
			 */
			model: {
				type: Object,
				required: true
			},

			/**
			 * Hardcoded WebAdmin texts.
			 */
			texts: {
				type: Object,
				required: true
			}
		},

		mounted() {
			this.initDataSystems()
		},

		computed: {
			/**
			 * Items to display for default data system selection.
			 */
			defaultDsItems() {
				return this.dataSystems.filter(ds => ds.Configured)
					.map(ds => ({ key: ds.Year, label: ds.Year }))
					.sort((a, b) => a.key - b.key)
			},

			/**
			 * Show pagination in the data systems table if there are more than 5 records.
			 */
			showDsTablePagination() {
				return this.dataSystems.length > 5
			},

			/**
			 * Classes to apply to the table rows, based on if the data system is correctly configured.
			 */
			dsTableRowClasses() {
				return {
					row:
					{
						'q-table__row-warning': (row) => !row.Configured
					}
				}
			},

			/**
			 * True if there are data systems in the table that are not yet configured, false otherwise.
			 */
			notConfiguredDataSystems() {
				return this.dataSystems.some(ds => !ds.Configured)
			},

			/**
			 * True if the name of the data system to create is not valid (already exists), false otherwise.
			 */
			invalidNewDataSystemName() {
				return this.dataSystems.map(ds => ds.Year.toLowerCase()).includes(this.newDsName.toLowerCase())
			},

			/**
			 * True if the name of the database of the data system to create is not valid (already exists), false otherwise.
			 */
			invalidNewDbName() {
				return this.dataSystems.map(ds => ds.DbName.toLowerCase()).includes(this.newDsSchema.toLowerCase())
			},


			/**
			 * True if the data system to create is not valid (missing or repeated information), false otherwise.
			 */
			invalidNewDataSystem() {
				return this.invalidNewDataSystemName
					|| this.invalidNewDbName
					|| this.newDsName === ''
					|| this.newDsSchema === ''
			}
		},

		methods: {
			/**
			 * Initializes the tab with the necessary information.
			 */
			initDataSystems() {
				// Retrieve model information
				this.defaultYear = this.model.DefaultYear
				this.hideYears = this.model.HideYears

				// Set "new Data System" dialog buttons
				this.newSystemDialogButtons = [
					{
						id: 'create-ds-btn',
						props: {
							bStyle: 'primary',
							label: this.texts.CRIAR24836,
							disabled: this.invalidNewDataSystem
						},
						action: () => this.createDataSystem()
					},
					{
						id: 'cancel-ds-btn',
						props: {
							bStyle: 'secondary',
							label: this.texts.CANCELAR49513
						},
						action: () => this.clearNewDataSystemInfo()
					}
				]

				// Server request to fetch data systems information
				this.fetchDataSystemsInfo()
			},

			/**
			 * Server request that fetches all necessary information regarding the existing data systems.
			 */
			fetchDataSystemsInfo() {
				var fetchUrl = QUtils.apiActionURL('DataSystems', 'GetDataSystemsInfo');
				QUtils.log('fetchDataSystemsInfo - Request: ', fetchUrl)

				QUtils.FetchData(fetchUrl).done((data) => {
					if (data.Success)
						this.dataSystems = data.data.dataSystemsInfo
					else {
						// Set error dialog information
						this.errorDialogText = data.message
						this.errorDialogButtons = [{
							id: 'close-dialog-btn',
							props: {
								bStyle: 'primary',
								label: this.texts.OK15819
							},
							action: () => {
								this.$router.push({
									name: 'dashboard', params: { culture: this.currentLang, system: this.currentYear }
								})
							}
						}]
						this.showErrorDialog = true
					}
				})
			},

			/**
			 * Save changes to the data systems configuration - Default Year and Hide Years.
			 */
			SaveConfigDataSystems() {
				var postUrl = QUtils.apiActionURL('Config', 'SaveConfigDataSystems')
				QUtils.log("SaveConfigDataSystems - Request", postUrl);

				QUtils.postData('Config', 'SaveConfigDataSystems', this.model, null, (data) => {
					QUtils.log("SaveConfigDataSystems - Response", data);

					if (data.Success)
						this.$emit('alert-class', { ResultMsg: this.texts.ALTERACOES_EFETUADAS10166, AlertType: 'success' });
					else
						this.$emit('alert-class', { ResultMsg: data.Message, AlertType: 'danger' });
				});
			},

			/**
			 * Creates a new data system and appends it to the list of existing ones.
			 */
			createDataSystem() {
				var postUrl = QUtils.apiActionURL('Config', 'CreateDataSystem')
				QUtils.log("CreateDataSystem - Request", postUrl)

				// New data system parameters
				const newDsInfo = {
					year: this.newDsName,
					schema: this.newDsSchema,
					type: this.newDsType,
					server: this.newDsServer
				}

				QUtils.postData('Config', 'CreateDataSystem', newDsInfo, null, (data) => {
					QUtils.log("CreateDataSystem - Response", data);

					// Update database years
					this.$eventHub.emit('app_updateYear')

					// Append new year to existent data systems
					this.dataSystems.push(
						{
							Year: data.system,
							DbName: newDsInfo.schema,
							DbType: newDsInfo.type,
							DbServer: newDsInfo.server,
							DbVersion: 0,
							Configured: false
						}
					)
				});

				// Clear information from previously created data system
				this.clearNewDataSystemInfo()
			},

			/**
			 * Duplicates an existing data system and appends its copy to the list of existing ones.
			 */
			duplicateDataSystem(row) {
				this.newDsType = row.DbType
				this.newDsServer = row.DbServer

				this.showDataSystemDialog()
			},

			/**
			 * Changes the currently selected data system to the one clicked on the table row and navigates to the database configuration tab.
			 */
			configureDataSystem(row) {
				// Change current data system to the one in the clicked row
				this.$router.replace({ name: 'system_setup', params: { culture: this.currentLang, system: row.Year } })

				this.$emit('changeTab', 'tabGroup', 'selectedTab', 'database-tab')
			},

			/**
			 * Shows the dialog to create a new data system.
			 */
			showDataSystemDialog() {
				this.showNewSystemDialog = true
			},

			/**
			 * After creating a new data system, clears the information on the dialog inputs.
			 */
			clearNewDataSystemInfo() {
				this.newDsName = ''
				this.newDsSchema = ''
				this.newDsType = ''
				this.newDsServer = ''
			}
		},

		watch: {
			/**
			 * Adapts the table pagination based on the number of data systems to present
			 */
			showDsTablePagination(newValue) {
				this.tableConfig.config.pagination = newValue
				this.tableConfig.config.pagination_info = newValue
			},

			/**
			 * Disables/enables the dialog button to create a new data system based on the correctness of the new system information
			 */
			invalidNewDataSystem(newValue) {
				this.newSystemDialogButtons[0].props.disabled = newValue
			} 
		}
	}
</script>