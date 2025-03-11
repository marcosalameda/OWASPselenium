<template>
	<div id="system_setup_database_container">
		<row>
			<q-card
				class="q-card--admin-default"
				:title="Resources.SISTEMA_DE_DADOS_ATU09110"
				width=block>
				<q-row-container>
					<q-text-field
						v-model="model.Server"
						:label="Resources.NOME_DO_SERVIDOR13641"
						required
						size="xlarge"
						:isReadOnly="isTestingConnection">
						<template #extras>
							<q-icon icon="information-outline" />
							{{ Resources.O_NOME_DO_SERVIDOR_E58624 }}
						</template>
					</q-text-field>
					<numeric-input
						v-model="model.Port"
						size="xlarge"
						:label="Resources.PORTA55707"
						:isReadOnly="isTestingConnection">
					</numeric-input>
					<q-select
						v-model="model.ServerType"
						v-if="model.SelectLists"
						:items="model.SelectLists.DBMS"
						:label="Resources.TIPO_DE_SERVIDOR_DE_25581"
						required
						size="xlarge"
						item-value="Value"
						item-label="Text"
						:readonly="isTestingConnection" />
					<div v-if="model.ServerType == 2">
						<q-text-field
							v-model="model.Service"
							:label="Resources.IDENTIFICADOR_DO_SER22713"
							size="xlarge"
							:readonly="isTestingConnection" />
						<q-text-field
							v-model="model.ServiceName"
							:label="Resources.NOME_DO_SERVICO32188"
							size="xlarge"
							:readonly="isTestingConnection" />
					</div>
					<q-text-field
						v-model="model.Schema"
						:label="Resources.NOME_DA_BASE_DE_DADO25105"
						required
						size="xlarge"
						:readonly="isTestingConnection">
						<template #extras>
							<q-icon icon="information-outline" />
							{{ Resources._SISTEMA__ANO__E_G__40394 }}
						</template>
					</q-text-field>
				</q-row-container>
			</q-card>
		</row>

		<row>
			<q-card 
				:title="Resources.AUTENTICACAO_DE__BAS42362" 
				class="q-card--admin-default"
				width="block">
				<q-row-container>
					<q-text-field
						v-model="model.DbUser"
						:label="Resources.LOGIN_DE_ACESSO_A_BA52816"
						required
						size="xlarge"
						:readonly="isTestingConnection" />
					<password-input
						v-model="model.DbPsw"
						:label="Resources.PALAVRA_PASSE44126"
						is-required
						:showFiller="model.HasDbPsw"
						size="xlarge"
						:isReadOnly="isTestingConnection">
					</password-input>
					<password-input
						v-model="model.DbCheckPsw"
						:label="Resources.CONFIRMAR_PALAVRA_PA30977"
						is-required
						size="xlarge"
						:isReadOnly="isTestingConnection">
					</password-input>
					<q-checkbox
						v-model="model.ConnEncrypt"
						:label="Resources.ENCRIPTAR_LIGACAO12834"
						:readonly="isTestingConnection" />
					<q-checkbox
						v-model="model.ConnWithDomainUser"
						:label="Resources.UTILIZADOR_DE_DOMINI41043"
						:readonly="isTestingConnection" />
					<q-button
						id="testServer"
						b-style="secondary"
						:label="Resources.TESTAR_CONEXAO_COM_O06434"
						:disabled="isTestingConnection"
						size="xlarge"
						@click="TestServerConection"
						:loading="showLoader" />
					<hr />
					<h5>
						{{ 'GQP ' + Resources.TABELAS_PARTILHADAS29704 }}
					</h5>
					<q-text-field
						v-model="model.GQP_Schema"
						:label="Resources.NOME_DA_BASE_DE_DADO25105"
						required
						size="xlarge"
						:readonly="isTestingConnection">
						<template #extras>
							<q-icon icon="information-outline" />
							{{ Resources._SISTEMA__ANO__E_G__40394 }}
						</template>
					</q-text-field>
					<q-checkbox
						v-model="model.GQP_ConnEncrypt"
						:label="Resources.ENCRIPTAR_LIGACAO12834" />
					<q-checkbox
						v-model="model.GQP_ConnWithDomainUser"
						:label="Resources.UTILIZADOR_DE_DOMINI41043" />
				</q-row-container>
			</q-card>
		</row>

		<row>
			<q-collapsible
				class="q-collapsible--admin-default"
				:title="Resources.SISTEMA_DE_DADOS_DE_45948"
				width="block">
				<q-text-field
					v-model="model.Log_Server"
					:label="Resources.NOME_DO_SERVIDOR13641"
					size="xlarge"
					:readonly="isTestingConnection">
					<template #extras>
						<q-icon icon="information-outline" />
						{{ Resources.O_NOME_DO_SERVIDOR_E58624 }}
					</template>
				</q-text-field>
				<numeric-input
					v-model="model.Log_Port"
					:label="Resources.PORTA55707"
					:isReadOnly="isTestingConnection"
					size="xlarge">
				</numeric-input>
				<q-select
					v-model="model.Log_ServerType"
					v-if="model.SelectLists"
					:items="model.SelectLists.DBMS"
					:label="Resources.TIPO_DE_SERVIDOR_DE_25581"
					size="xlarge"
					item-value="Value"
					item-label="Text"
					:readonly="isTestingConnection" />
				<div v-if="model.Log_ServerType == 2">
						<q-text-field
							v-model="model.Log_Service"
							:label="Resources.IDENTIFICADOR_DO_SER22713"
							size="xlarge"
							:readonly="isTestingConnection" />
						<q-text-field
							v-model="model.Log_ServiceName"
							:label="Resources.NOME_DO_SERVICO32188"
							size="xlarge"
							:readonly="isTestingConnection" />
				</div>
				<q-text-field
					v-model="model.Log_Schema"
					:label="Resources.NOME_DA_BASE_DE_DADO25105"
					required
					size="xlarge"
					:readonly="isTestingConnection">
					<template #extras>
						<q-icon icon="information-outline" />
						{{ Resources._SISTEMA__ANO__E_G__40394 }}
					</template>
				</q-text-field>
				<hr />
				<q-text-field
					v-model="model.Log_DbUser" 
					:label="Resources.LOGIN_DE_ACESSO_A_BA52816"
					size="xlarge"
					:readonly="isTestingConnection" />
				<password-input
					v-model="model.Log_DbPsw"
					:label="Resources.PALAVRA_PASSE44126"
					:showFiller="model.Log_HasDbPsw"
					size="xlarge"
					:isReadOnly="isTestingConnection">
				</password-input>
				<password-input
					v-model="model.Log_DbCheckPsw" 
					:label="Resources.CONFIRMAR_PALAVRA_PA30977"
					size="xlarge"
					:isReadOnly="isTestingConnection">
				</password-input>
				<q-checkbox
					v-model="model.Log_ConnEncrypt"
					:label="Resources.ENCRIPTAR_LIGACAO12834"
					:readonly="isTestingConnection" />
				<q-checkbox
					v-model="model.Log_ConnWithDomainUser"
					:label="Resources.UTILIZADOR_DE_DOMINI41043"
					:readonly="isTestingConnection" />
			</q-collapsible>
		</row>

		<row class="footer-btn">
			<q-button b-style="primary"
				:label="Resources.GRAVAR_CONFIGURACAO36308"
				:disabled="isTestingConnection"
				@click="SaveConfigDatabase" />

			<data-system-badge
				:title="Resources.SISTEMA_DE_DADOS_ATU09110" />
		</row>
	</div>
</template>

<script>
// @ is an alias to /src
import { reusableMixin } from '@/mixins/mainMixin';
import { QUtils } from '@/utils/mainUtils';
import { computed } from 'vue';

export default {
	name: 'database',

	props: {
		model: {
			required: true
		}
	},

	mixins: [reusableMixin],

	emits: ['update-model', 'connection-tested'],

	data() {
		return {
			showDialog: false,
			showLoader: false,
			isTestingConnection: false
		}
	},

	methods: {
		SaveConfigDatabase() {
			var vm = this;
			//let hasConfig = vm.model.HasConfig;
			QUtils.log("SaveConfigDatabase - Request", QUtils.apiActionURL('Config', 'SaveConfigDatabase'));
			QUtils.postData('Config', 'SaveConfigDatabase', vm.model, null, function (data) {
				QUtils.log("SaveConfigDatabase - Response", data);
				if (data.ResultMsg === vm.Resources.FICHEIRO_DE_CONFIGUR18806 + " " + vm.Resources.SERA_REDIRECIONADO_E06592) {
					vm.$emit('update-model', data);
					setTimeout(function () {
						vm.$router.push({ name: 'dashboard', params: { culture: vm.currentLang, system: vm.currentYear } });
					}, 3000);
				} else {
					vm.$emit('update-model', data);
				};
			});
		},

		TestServerConection() {
			var vm = this;
			// Verify that essential data is present
			if (!vm.model.Server || !vm.model.Schema || !vm.model.DbUser || !vm.model.DbPsw) {
				vm.$emit('alert-class', { ResultMsg: vm.Resources.POR_FAVOR__PREENCHA_05829, AlertType: 'danger' });
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
		}
	}
};
</script>
