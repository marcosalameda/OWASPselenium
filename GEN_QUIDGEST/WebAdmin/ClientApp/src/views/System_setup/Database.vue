<template>
	<div id="system_setup_database_container">
		<row>
			<QGroupBoxContainer :label="Resources.SISTEMA_DE_DADOS_ATU09110">
					<q-row-container>
						<q-control-wrapper class="control-row-group">
							<base-input-structure
								class="i-text">
								<text-input v-model="model.Server" :label="Resources.NOME_DO_SERVIDOR13641" :isRequired="true" :isReadOnly="isTestingConnection"></text-input>
								<span class="q-help__subtext">
									<span class="mdi mdi-information-outline"></span>
									{{ Resources.O_NOME_DO_SERVIDOR_E58624 }}
								</span>
							</base-input-structure>
						</q-control-wrapper>
						<q-control-wrapper class="control-row-group">
							<base-input-structure
								class="i-text">
								<numeric-input v-model="model.Port" :label="Resources.PORTA55707" :isReadOnly="isTestingConnection"></numeric-input>
							</base-input-structure>
						</q-control-wrapper>
						<q-control-wrapper class="control-row-group">
							<base-input-structure
								class="i-text">
								<select-input v-model="model.ServerType" v-if="model.SelectLists" :options="model.SelectLists.DBMS" :label="Resources.TIPO_DE_SERVIDOR_DE_25581" :isRequired="true" :isReadOnly="isTestingConnection"></select-input>
							</base-input-structure>
						</q-control-wrapper>
						<q-control-wrapper class="control-row-group">
							<base-input-structure
								class="i-text">
								<div v-if="model.ServerType == 2">
									<text-input v-model="model.Service" :label="Resources.IDENTIFICADOR_DO_SER22713" :isReadOnly="isTestingConnection"></text-input>
									<text-input v-model="model.ServiceName" :label="Resources.NOME_DO_SERVICO32188" :isReadOnly="isTestingConnection"></text-input>
								</div>
							</base-input-structure>
						</q-control-wrapper>
						<q-control-wrapper class="row-line-group">
							<base-input-structure
								class="i-text">
								<text-input v-model="model.Schema" :label="Resources.NOME_DA_BASE_DE_DADO25105" :isRequired="true" :isReadOnly="isTestingConnection"></text-input>
								<span class="q-help__subtext">
									<span class="mdi mdi-information-outline"></span>
									{{ Resources._SISTEMA__ANO__E_G__40394 }}
								</span>
							</base-input-structure>
						</q-control-wrapper>
						<QGroupBoxContainer :label="Resources.AUTENTICACAO_DE__BAS42362" class="c-groupbox--minor-border-top">
								<q-row-container>
									<q-control-wrapper class="control-row-group">
										<base-input-structure
											class="i-text">
											<text-input v-model="model.DbUser" :label="Resources.LOGIN_DE_ACESSO_A_BA52816" :isRequired="true"></text-input :isReadOnly="isTestingConnection">
										</base-input-structure>
									</q-control-wrapper>
									<q-control-wrapper class="control-row-group">
										<base-input-structure
											class="i-text">
											<password-input v-model="model.DbPsw" :label="Resources.PALAVRA_PASSE44126" :isRequired="true" :showFiller="model.HasDbPsw" :isReadOnly="isTestingConnection"></password-input>
										</base-input-structure>
									</q-control-wrapper>
									<q-control-wrapper class="control-row-group">
										<base-input-structure
											class="i-text">
											<password-input v-model="model.DbCheckPsw" :label="Resources.CONFIRMAR_PALAVRA_PA30977" :isRequired="true" :isReadOnly="isTestingConnection"></password-input>
										</base-input-structure>
									</q-control-wrapper>
									<q-control-wrapper class="control-row-group">
										<base-input-structure
											class="i-text">
											<checkbox-input v-model="model.ConnEncrypt" :label="Resources.ENCRIPTAR_LIGACAO12834" :isReadOnly="isTestingConnection"></checkbox-input>
										</base-input-structure>
									</q-control-wrapper>
									<q-control-wrapper class="control-row-group">
										<base-input-structure
											class="i-text">
											<checkbox-input v-model="model.ConnWithDomainUser" :label="Resources.UTILIZADOR_DE_DOMINI41043" :isReadOnly="isTestingConnection"></checkbox-input>
										</base-input-structure>
									</q-control-wrapper>
									<q-button
										id="testServer"
										b-style="secondary"
										:label="Resources.TESTAR_CONEXAO_COM_O06434"
										:disabled="isTestingConnection"
										@click="TestServerConection"
										:loading="showLoader" />
								</q-row-container>
						</QGroupBoxContainer>
					</q-row-container>
			</QGroupBoxContainer>
		</row>
		<row>
			<q-group-collapsible
				:label="Resources.SISTEMA_DE_DADOS_DE_45948"
				:is-open="openGroups['collapsible-system-container']"
				id="collapsible-system"
				@state-changed="toggleGroup('collapsible-system-container')">
				<row>
					<text-input v-model="model.Log_Server" :label="Resources.NOME_DO_SERVIDOR13641" :isReadOnly="isTestingConnection"></text-input>
					<span class="q-help__subtext">
						<span class="mdi mdi-information-outline"></span>
						{{ Resources.O_NOME_DO_SERVIDOR_E58624 }}
					</span>
				</row>
				<row>
					<numeric-input v-model="model.Log_Port" :label="Resources.PORTA55707" :isReadOnly="isTestingConnection"></numeric-input>
				</row>
				<row>
					<select-input v-model="model.Log_ServerType" v-if="model.SelectLists" :options="model.SelectLists.DBMS" :label="Resources.TIPO_DE_SERVIDOR_DE_25581" :isReadOnly="isTestingConnection"></select-input>
				</row>
				<div v-if="model.Log_ServerType == 2">
					<row>
						<text-input v-model="model.Log_Service" :label="Resources.IDENTIFICADOR_DO_SER22713" :isReadOnly="isTestingConnection"></text-input>
					</row>
					<row>
						<text-input v-model="model.Log_ServiceName" :label="Resources.NOME_DO_SERVICO32188" :isReadOnly="isTestingConnection"></text-input>
					</row>
				</div>
				<row>
					<text-input v-model="model.Log_Schema" :label="Resources.NOME_DA_BASE_DE_DADO25105" :isRequired="true" :isReadOnly="isTestingConnection"></text-input>
					<span class="q-help__subtext">
						<span class="mdi mdi-information-outline"></span>
						{{ Resources._SISTEMA__ANO__E_G__40394 }}
					</span>
				</row>
				<hr />
				<row>
					<text-input v-model="model.Log_DbUser" :label="Resources.LOGIN_DE_ACESSO_A_BA52816" :isReadOnly="isTestingConnection"></text-input>
				</row>
				<row>
					<password-input v-model="model.Log_DbPsw" :label="Resources.PALAVRA_PASSE44126" :showFiller="model.Log_HasDbPsw" :isReadOnly="isTestingConnection"></password-input>
				</row>
				<row>
					<password-input v-model="model.Log_DbCheckPsw" :label="Resources.CONFIRMAR_PALAVRA_PA30977" :isReadOnly="isTestingConnection"></password-input>
				</row>
				<row>
					<checkbox-input v-model="model.Log_ConnEncrypt" :label="Resources.ENCRIPTAR_LIGACAO12834" :isReadOnly="isTestingConnection"></checkbox-input>
				</row>
				<row>
					<checkbox-input v-model="model.Log_ConnWithDomainUser" :label="Resources.UTILIZADOR_DE_DOMINI41043" :isReadOnly="isTestingConnection"></checkbox-input>
				</row>
			</q-group-collapsible>
		</row>
		<row>
			<q-group-collapsible
				:label="Resources.CONFIGURACOES_GERAIS11276"
				:is-open="openGroups['collapsible-config']"
				id="collapsible-config"
				@state-changed="toggleGroup('collapsible-config')">
				<row>
					<text-input v-model="model.DefaultYear" :label="Resources.ESPECIFICAR_ANO_OU_042147" :isReadOnly="isTestingConnection"></text-input>
				</row>
				<row>
					<checkbox-input v-model="model.HideYears" :label="Resources.OCULTAR_ANOS03755" :isReadOnly="isTestingConnection"></checkbox-input>
				</row>
				<br />
				<row>
					<q-button
						:label="Resources.CRIAR_UM_NOVO_SISTEM49777"
						@click="CreateDataSystem">
					</q-button>
					<span class="q-help__subtext">
						<span class="mdi mdi-information-outline"></span>
						{{ Resources.CRIA_UM_NOVO_SISTEMA29796 }}
					</span>
				</row>
			</q-group-collapsible>
		</row>
		<row class="footer-btn">
			<q-button
				b-style="primary"
				:label="Resources.GRAVAR_CONFIGURACAO36308"
				:disabled="isTestingConnection"
				@click="SaveConfigDatabase" />
		</row>

		<div class="d-none">
			<div ref="templateFormNewDataSystem">
				<row>
					<text-input v-model="newDSForm.Name" :label="Resources.ANO33022" :size="'xlarge'"></text-input>
					<text-input v-model="newDSForm.Schema" :label="'DB Schema'" :size="'xlarge'"></text-input>
				</row>
			</div>
		</div>
	</div>
</template>

<script>
// @ is an alias to /src
import { reusableMixin } from '@/mixins/mainMixin';
import { QUtils } from '@/utils/mainUtils';
import bootbox from 'bootbox';
import QGroupCollapsible from '@/components/QGroupCollapsible.vue'

export default {
	name: 'database',
	components: {
		QGroupCollapsible
	},
	props: {
		model: {
			required: true
		}
	},
	mixins: [reusableMixin],
	emits: ['updateModal', 'connection-tested'],
	data() {
		return {
			newDSForm: {
				Name: '',
				Schema: ''
			},
			openGroups: {
				'collapsible-system': false,
				'collapsible-config': false
			},
			showLoader: false,
			isTestingConnection: false
		};
	},
	methods: {
		CreateDataSystem() {
			var vm = this;
			vm.newDSForm.Name = ''; vm.newDSForm.Schema = '';
			bootbox.confirm({
				title: vm.Resources.NOVA_BASE_DE_DADOS33819,
				message: vm.$refs.templateFormNewDataSystem,
				callback: function (result) {
					if (result) {
					QUtils.log("CreateDataSystem - Request", QUtils.apiActionURL('Config', 'CreateDataSystem'));
					QUtils.postData('Config', 'CreateDataSystem', { year: vm.newDSForm.Name, schema: vm.newDSForm.Schema }, null, function (data) {
						QUtils.log("CreateDataSystem - Response", data);
						vm.$router.replace({ name: 'system_setup', params: { culture: vm.currentLang, system: data.system } });
					});
					}
				}
			});
		},
		SaveConfigDatabase() {
			var vm = this;
			//let hasConfig = vm.model.HasConfig;
			QUtils.log("SaveConfigDatabase - Request", QUtils.apiActionURL('Config', 'SaveConfigDatabase'));
			QUtils.postData('Config', 'SaveConfigDatabase', vm.model, null, function (data) {
				QUtils.log("SaveConfigDatabase - Response", data);
				if (data.ResultMsg === vm.Resources.FICHEIRO_DE_CONFIGUR18806 + " " + vm.Resources.SERA_REDIRECIONADO_E06592) {
					vm.$emit('updateModal', data, { message: data.ResultMsg, alertType: data.AlertType });
					setTimeout(function () {
						vm.$router.push({ name: 'dashboard', params: { culture: vm.currentLang, system: vm.currentYear } });
					}, 3000);
				} else {
					vm.$emit('updateModal', data, { message: data.ResultMsg, alertType: data.AlertType });
				};
			});
		},

		TestServerConection() {
			var vm = this;
			// Verify that essential data is present
			if (!vm.model.Server || !vm.model.Schema || !vm.model.DbUser || !vm.model.DbPsw) {
				alert("Please complete all the required fields to test the connection.");
				return;
			}

			// Prepare data to send
			const testData = {
				Server: vm.model.Server,
				DbUser: vm.model.DbUser,
				Schema: vm.model.Schema,
				DbPsw: vm.model.DbPsw
			};

			// Reset the loader and testing state
			vm.showLoader = true;
			vm.isTestingConnection = true;

			// Make API call to test the connection
			QUtils.log("TestServerConection - Request", QUtils.apiActionURL('Config', 'TestDBConnection'));
			QUtils.postData('Config', 'TestDBConnection', testData, null, (response) => {
				QUtils.log("TestServerConection - Response", response);
				vm.$emit('connection-tested', response);

				vm.showLoader = false;
				vm.isTestingConnection = false;
			})
			.catch(error => {
				vm.$emit('connection-tested', { Success: false, Message: 'Error in connection: Test could not be performed', AlertType: 'error' });
				vm.showLoader = false;
				vm.isTestingConnection = false;
			});
		},

		toggleGroup(groupId) {
			this.openGroups[groupId] = !this.openGroups[groupId]
		},
	}
};
</script>
