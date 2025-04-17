<template>
	<div id="app_config_security_container">
		<row>
			<q-card
				class="q-card--admin-default"
				:title="Resources.AUTENTICACAO37999"
				width="block">
				<q-row-container>
					<q-select
						v-model="Security.AuthenticationMode"
						v-if="SelectLists"
						size="large"
						:items="SelectLists.AuthenticationMode" 
						:label="Resources.MODO_DE_AUTENTICACAO19339"
						item-value="Value"
						item-label="Text" />
					<q-select
						v-model="Security.AllowMultiSessionPerUser"
						v-if="SelectLists"
						size="large"
						:items="SelectLists.MultisessionMode"
						:label="Resources.POLITICA_DE_SESSOES_19368"
						item-value="Value"
						item-label="Text" />
					<q-checkbox
						v-model="Security.AllowAuthenticationRecovery"
						:label="Resources.PERMITE_RECUPERACAO_41959" />
					<q-checkbox
						v-model="Security.Activate2FA"
						:label="Resources.ATIVAR_AUTENTICACAO_40943" />
					<q-checkbox
						v-if="Security.Activate2FA"
						v-model="Security.Mandatory2FA"
						:label="Resources.OBRIGATORIO_A_UTILIZ32451" />
					<numeric-input
						v-model="Security.SessionTimeOut"
						size="large"
						:label="Resources.TIME_OUT_DA_SESSAO36825">
					</numeric-input>
				</q-row-container>
			</q-card>
		</row>

		<row>
			<q-card
				class="q-card--admin-default"
				:title="Resources.POLITICA_DE_PASSWORD17131"
				width="block">
				<q-row-container>
					<numeric-input
						v-model="Security.MinCharacters"
						size="large"
						:label="Resources.MINIMO_DE_CARACTERES10869">
					</numeric-input>
					<q-select
						v-model="Security.PasswordStrength"
						v-if="SelectLists"
						size="large"
						:items="SelectLists.PasswordStrength" 
						:label="Resources.MODO_DE_AUTENTICACAO19339"
						item-value="Value"
						item-label="Text" />
					<numeric-input
						v-model="Security.MaxAttempts"
						size="large"
						:label="Resources.NUMERO_MAXIMO_TENTAT34521">
					</numeric-input>
					<q-checkbox
						v-model="Security.ExpirationDateBool"
						:label="Resources.EXPIRACAO_DA_PASSWOR46052" />
					<q-text-field
						v-model="Security.ExpirationDate"
						size="large"
						:label="Resources.DIAS_PARA_A_EXPIRACA24916" />
					<q-select
						v-model="Security.PasswordAlgorithms"
						v-if="SelectLists"
						size="large"
						:items="SelectLists.PasswordAlgorithms"
						:label="Resources.ALGORITMO_DE_ENCRIPT09649"
						item-value="Value"
						item-label="Text" />
					<q-checkbox
						v-model="Security.UsePasswordBlacklist"
						:label="Resources.USE_PASSWORD_BLACKLI22314" />
					<q-button
						v-if="Security.UsePasswordBlacklist"
						:label="Resources.MANAGE_PASSWORD_BLAC01612"
						@click="showManageBlacklist" />
				</q-row-container>
			</q-card>
		</row>
		
		<row class="footer-btn">
			<q-button
				variant="bold"
				:label="Resources.GRAVAR_CONFIGURACAO36308"
				@click="SaveConfigSecurity" />
		</row>

		<hr />

		<row>
			<qtable
				:rows="identityProvidersRows"
				:columns="tIdentityProviders.columns"
				:config="tIdentityProviders.config"
				:totalRows="tIdentityProviders.total_rows"
				class="q-table--borderless">

				<template #actions="props">
					<q-button-group borderless>
						<q-button
							variant="text"
							:title="Resources.EDITAR11616"
							@click="changeIdentityProvider(props.row)">
							<q-icon icon="pencil" />
						</q-button>
						<q-button
							variant="text"
							:title="Resources.ELIMINAR21155"
							@click="deleteIdentityProvider(props.row)">
							<q-icon icon="bin" />
						</q-button>
					</q-button-group>
				</template>
				<template #table-footer>
					<tr>
						<td colspan="4">
							<q-button
								:label="Resources.INSERIR43365"
								@click="createIdentityProvider">
								<q-icon icon="add" />
							</q-button>
						</td>
					</tr>
				</template>
			</qtable>
		</row>

		<row>
			<qtable
				:rows="roleRows"
				:columns="tRoleProviders.columns"
				:config="tRoleProviders.config"
				:totalRows="tRoleProviders.total_rows"
				class="q-table--borderless">

				<template #actions="props">
					<q-button-group borderless>
						<q-button
							variant="text"
							:title="Resources.EDITAR11616"
							@click="changeRoleProvider(props.row)">
							<q-icon icon="pencil" />
						</q-button>
						<q-button
							variant="text"
							:title="Resources.ELIMINAR21155"
							@click="deleteRoleProvider(props.row)">
							<q-icon icon="bin" />
						</q-button>
					</q-button-group>
				</template>
				<template #table-footer>
					<tr>
						<td colspan="5">
							<q-button
								:label="Resources.INSERIR43365"
								@click="createRoleProvider">
								<q-icon icon="add" />
							</q-button>
						</td>
					</tr>
				</template>
			</qtable>
		</row>

		<hr />

		<row>
			<qtable
				:rows="userRows"
				:columns="tUsers.columns"
				:config="tUsers.config"
				:totalRows="tUsers.total_rows"
				class="q-table--borderless">

				<template #actions="props">
					<q-button-group borderless>
						<q-button
							variant="text"
							:title="Resources.EDITAR11616"
							@click="changeUser(props.row)">
							<q-icon icon="pencil" />
						</q-button>
						<q-button
							variant="text"
							:title="Resources.ELIMINAR21155"
							@click="deleteUser(props.row)">
							<q-icon icon="bin" />
						</q-button>
					</q-button-group>
				</template>
				<template #Type="props">
					<!-- This is a horrible and temporary solution, needs refactor -->
					{{ SelectLists.DisplayUserType.filter((t) => t.Text == props.row.Type)[0] }}
				</template>
				<template #AutoLogin="props">
					<q-icon
						v-if="props.row.AutoLogin" 
						icon="check" />
					<q-icon 
						v-else 
						icon="close" />
				</template>
				<template #table-footer>
					<tr>
						<td colspan="4">
							<q-button
								:label="Resources.INSERIR43365"
								@click="createUser">
								<q-icon icon="add" />
							</q-button>
						</td>
					</tr>
				</template>
			</qtable>
		</row>
		
		<q-dialog
			id="manage_blacklist"
			v-model="showBlacklistDialog"
			:title="Resources.MANAGE_PASSWORD_BLAC01612"
			:buttons="buttonsBlacklist">
			<template #body.content>
				<div class="q-dialog-container">
					<q-alert
						v-if="alert.isVisible"
						ref="alertBox"
						:type="alert.alertType"
						:text="alert.message"
						:icon="alert.icon"
						:title="Resources.ESTADO_DA_OPERACAO38065"
						:dismissTime="5"
						@message-dismissed="handleAlertDismissed" />
					<div>{{ Resources.BLACKLISTED_PASSWORD46582 }}: {{ numPasswords }}</div>
					<row>
						<div class="q-button-container">
							<input
								type="file"
								id="blacklistFile"
								@change="importB"
								accept=".txt"
								style="position:absolute;height: 0;width: 0;" />
							<q-button
								variant="bold"
								:label="Resources.IMPORTAR64751"
								@click="clickImport" />
							<q-button
								variant="bold"
								:label="Resources.EXPORTAR35632"
								@click="exportB" />
						</div>
					</row>
					<div>{{ Resources.DELETE_ALL_BLACKLIST01597 }}</div>
					<row>
						<q-button
							variant="bold"
							color="danger"
							:label="Resources.APAGAR04097"
							@click="deleteAll">
							<q-icon icon="bin" />
						</q-button>
					</row>
					<row>
						<password-input
							v-model="password"
							class="control-row-group"
							:label="Resources.PASSWORD09467" />
						<div class="control-row-group q-button-container">
							<q-button
								variant="bold"
								:label="Resources.VALIDACAO46021"
								@click="passCheck" />
							<q-button
								:label="Resources.ADICIONAR14072"
								@click="passAdd" />
						</div>
					</row>

					<row>
						<div>Validate service passwords</div>
						<div class="control-row-group q-button-container">
							<q-button
								variant="bold"
								:label="Resources.VALIDACAO46021"
								@click="servicePassCheck" />
						</div>
						<div>
							<div v-for="item in servicePassResults" class="alert alert-warning">
								<span>
									<b class="status-message">{{ item }}</b>
								</span>
							</div>
						</div>
					</row>
				</div>
			</template>
		</q-dialog>

		<q-dialog
			id="identity_provider"
			v-model="showIdentityDialog"
			:title="Resources.FORNECEDOR_DE_IDENTI58587"
			:buttons="buttons">
			<template #body.content>
				<div class="q-dialog-container">
					<q-text-field
						v-model="rowName"
						:label="Resources.NOME47814"
						required
						:readonly="inDeleteMode"
						size="large" />
					<q-text-field
						v-model="rowDescription"
						:label="Resources.DESCRICAO07528"
						:readonly="inDeleteMode"
						size="large" />
					<base-input-structure
						:label="Resources.TIPO55111"
						:isVisible="true"
						:showPopoverButton="true"
						:popoverTitle="Resources.TIPO55111"
						:popoverText="providerHelp">
						<q-select
							v-model="rowType"
							v-if="SelectLists"
							:items="identityProviderSelect"
							size="large"
							:readonly="inDeleteMode"
							item-value="Value"
							item-label="Text" />
					</base-input-structure>
					<div v-for="c in tempConfig" :key="c.PropertyName">
						<base-input-structure
							:label="c.DisplayName"
							:id="c.DisplayName"
							:isVisible="true"
							:showPopoverButton="true"
							:popoverTitle="c.DisplayName"
							:popoverText="c.Description">
							<q-text-field
								v-model="c.Value"
								size="large"
								:readonly="inDeleteMode"
								:required="!c.Optional" />
						</base-input-structure>
					</div>
				</div>
			</template>
		</q-dialog>

		<q-dialog
			v-model="showRoleDialog"
			:title="Resources.FORNECEDOR_DE_AUTORI36867"
			:buttons="buttons">
			<template #body.content>
				<div class="q-dialog-container">
					<q-text-field
						v-model="roleName"
						:label="Resources.NOME47814"
						required
						:readonly="inDeleteMode"
						size="large" />
					<base-input-structure
						:label="Resources.TIPO55111"
						:isVisible="true"
						:showPopoverButton="true"
						:popoverTitle="Resources.TIPO55111"
						:popoverText="providerRoleHelp">
						<q-select
							v-model="roleType"
							:items="roleProviderSelect"
							item-value="Value"
							item-label="Text"
							:readonly="inDeleteMode"
							size="large" />
					</base-input-structure>
					<q-text-field
						v-model="rolePrecond"
						:label="Resources.PRECONDICAO44917"
						:readonly="inDeleteMode"
						size="large" />
					<div v-for="c in tempConfig" :key="c.PropertyName">
					<base-input-structure
						:label="c.DisplayName"
						:isVisible="true"
						:showPopoverButton="true"
						:popoverTitle="c.DisplayName"
						:popoverText="c.Description">
						<q-text-field
							v-model="c.Value"
							:required="!c.Optional"
							:readonly="inDeleteMode"
							size="large" />
					</base-input-structure>
					</div>
				</div>
			</template>
		</q-dialog>
		
		<q-dialog
			v-model="showUserDialog"
			:title="Resources.UTILIZADOR_FIXO32336"
			:buttons="buttons">
			<template #body.content>
				<div class="q-dialog-container">
					<q-text-field
						v-model="userName"
						:class="{ 'input-error' : isSameName }"
						required
						:label="Resources.NOME47814"
						:readonly="dialogMode != 'new'"
						size="large">
						<template #extras v-if="isSameName">
							<q-icon icon="information-outline" />
							{{ Resources.ESTE_NOME_JA_EXISTE_51368 }}
						</template>
					</q-text-field>
					<q-select
						v-model="userType"
						required
						v-if="SelectLists"
						:label="Resources.TIPO55111"
						:items="SelectLists.DisplayUserType"
						item-value="Value"
						item-label="Text"
						:readonly="inDeleteMode"
						size="large" />
					<q-checkbox
						v-model="userAutoLogin"
						:label="Resources.LOGIN_AUTOMATICO22707"
						:readonly="inDeleteMode" />
					<password-input
						v-model="userPassword"
						:label="Resources.PASSWORD09467"
						:isReadOnly="inDeleteMode"
						:size="'large'">
					</password-input>
				</div>
			</template>
		</q-dialog>
	</div>
</template>

<script>
	// @ is an alias to /src
	import { reusableMixin, NormalizeValue, ReadProviderConfig } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';
	import { reactive } from 'vue';
	import QAlert from '@/components/QAlert.vue';

	export default {
		name: 'security',
		components: { QAlert },
		emits: ['update-model', 'alert-class'],
		props: {
			model: {
				required: true
			},
			SelectLists: {
				required: true
			}
		},
		mixins: [reusableMixin],
		data() {
			return {
				dialogMode: '',
				numPasswords: 0,
				password: '',
				resultMsg: '',
				statusError: false,
				servicePassResults: [],
				showBlacklistDialog: false,
				buttonsBlacklist: [],
				buttons: [],
				showIdentityDialog: false,
				identityProvidersRows: [],
				rowName: "",
				rowDescription: "",
				rowType: "",
				tempConfig: [],
				showUserDialog: false,
				userRows: [],
				userName: "",
				userType: "",
				userAutoLogin: false,
				userPassword: "",
				userNum: 0,
				tempRoleConfig: [],
				showRoleDialog: false,
				roleRows: [],
				roleNum: 0,
				roleName: "",
				roleType: "",
				rolePrecond: "",
				temp: {},
				alert: {
					isVisible: false,
					alertType: 'info',
					message: ''
				},
				tIdentityProviders: {
					rows: [],
					columns: [
					{
						label: () => this.$t('ACOES22599'),
						name: "actions",
						slot_name: "actions",
						sort: false,
						column_classes: "thead-actions",
						row_text_alignment: 'text-center',
						column_text_alignment: 'text-center'
					},
					{
						label: () => this.$t('NOME47814'),
						name: "Name",
						sort: true,
						initial_sort: true,
						initial_sort_order: "asc"
					},
					{
						label: () => this.$t('TIPO55111'),
						name: "Type",
						sort: true
					},
					{
						label: () => this.$t('CONFIGURACAO10928'),
						name: "Config",
						sort: true
					}],
					config: {
						table_title: () => this.$t('FORNECEDORES_DE_IDEN35608'),
						pagination: false,
						pagination_info: false,
						global_search: {
							visibility: false
						}
					}
				},
				tRoleProviders: {
					rows: [],
					columns: [
					{
						label: () => this.$t('ACOES22599'),
						name: "actions",
						slot_name: "actions",
						sort: false,
						column_classes: "thead-actions",
						row_text_alignment: 'text-center',
						column_text_alignment: 'text-center'
					},
					{
						label: () => this.$t('NOME47814'),
						name: "Name",
						sort: true,
						initial_sort: true,
						initial_sort_order: "asc"
					},
					{
						label: () => this.$t('TIPO55111'),
						name: "Type",
						sort: true
					},
					{
						label: () => this.$t('CONFIGURACAO10928'),
						name: "Config",
						sort: true
					},
					{
						label: () => this.$t('PRECONDICAO44917'),
						name: "Precond",
						sort: true
					}],
					config: {
						table_title: () => this.$t('FORNECEDORES_DE_AUTO29899'),
						pagination: false,
						pagination_info: false,
						global_search: {
							visibility: false
						}
					}
				},
				tUsers: {
					rows: [],
					columns: [
						{
							label: () => this.$t('ACOES22599'),
							name: "actions",
							slot_name: "actions",
							sort: false,
							column_classes: "thead-actions",
							row_text_alignment: 'text-center',
							column_text_alignment: 'text-center'
						},
						{
							label: () => this.$t('NOME47814'),
							name: "Name",
							sort: true,
							initial_sort: true,
							initial_sort_order: "asc"
						},
						{
							label: () => this.$t('TIPO55111'),
							name: "Type",
							slot_name: 'Text',
							sort: true
						},
						{
							label: () => this.$t('LOGIN_AUTOMATICO22707'),
							name: "AutoLogin",
							slot_name: 'AutoLogin',
							sort: true
						}],
					config: {
						table_title: () => this.$t('UTILIZADORES_FIXOS00716'),
						pagination: false,
						pagination_info: false,
						global_search: {
							visibility: false
						}
					}
				}
			};
		},
		computed: {
			isSameName() {
				return this.userRows.some(prop => prop.Name.toLowerCase() === this.userName.toLowerCase()) && this.dialogMode === 'new'
			},
			invalidUserProps() {
				return this.userName === '' || this.userType === '' || (this.dialogMode === 'new' && this.isSameName)
			},
			invalidIdentityProps() {
				const configArray = Array.isArray(this.tempConfig) ? this.tempConfig : [this.tempConfig];
				return this.rowName === '' || this.rowType === '' || configArray.some(c => !c.Value || c.Value.trim() === '')
			},
			invalidRoleProps() {
				return this.roleName === '' || this.roleType === ''
			},
			inDeleteMode() {
				return this.dialogMode === 'delete';
			},
			Security() {
				return reactive(!$.isEmptyObject(this.currentApp) && !$.isEmptyObject(this.model) ? (this.model[this.currentApp] || {}) : {});
			},
			identityProviderSelect() {
				return this.SelectLists.IdentityProviderTypeList.map(x => ({
					Text: x.DisplayName,
					Value: x.TypeFullName
				}));
			},
			providerHelp() {
				return this.SelectLists.IdentityProviderTypeList.find(x => x.TypeFullName == this.rowType)?.Description
			},
			roleProviderSelect() {
				return this.SelectLists.RoleProviderTypeList.map(x => ({
					Text: x.DisplayName,
					Value: x.TypeFullName
				}));
			},
			providerRoleHelp() {
				return this.SelectLists.RoleProviderTypeList.find(x => x.TypeFullName == this.roleType)?.Description
			}
		},
		methods: {
			SaveConfigSecurity() {
				QUtils.log("SaveConfigSecurity - Request", QUtils.apiActionURL('Config', 'SaveConfigSecurity'));
				QUtils.postData('Config', 'SaveConfigSecurity', this.Security, null, (data) => {
					QUtils.log("SaveConfigSecurity - Response", data);
					if (data.Success) {
						this.$emit('alert-class', { ResultMsg: this.Resources.ALTERACOES_EFETUADAS10166, AlertType: 'success' });
						this.statusError = false;
					} else {
						this.$emit('alert-class', { ResultMsg: data.Message, AlertType: 'danger' });
						this.statusError = true;
					}
				});
			},
			clickImport() {
				const elem = document.getElementById('blacklistFile');
				elem.click();
			},
			async importB(e) {
				
				let selection = e.target.files || e.dataTransfer.files;
				if (!selection.length)
					return;

				const formData = new FormData();
				const file = selection[0];
				formData.append("file", file);

				this.resultMsg = "";
				this.statusError = false;

				const uri = QUtils.apiActionURL('Config', 'BlacklistUpload');
				const response = await fetch(uri, {
					method: "POST",
					body: formData,
				});

				if(response.ok)
				{
					const data = await response.json();
					if (data.Success) {
						this.resultMsg = this.Resources.ALTERACOES_EFETUADAS10166;
						this.statusError = false;
						this.numPasswords = data.numPasswords;
					} else {
						this.resultMsg = data.Message;
						this.statusError = true;
					}                
				}
			},
			exportB() {
				var downloadUrl = QUtils.apiActionURL('Config', 'BlacklistDownload');
				window.open(downloadUrl, "_self")
			},
			passCheck() {
				const params = {
					password: this.password
				};
				this.resultMsg = "";
				this.statusError = false;
				
				QUtils.postData('Config', 'BlacklistPasswordCheck', params, null, (data) => {
					if (data.Success) {
						if(data.found) {
							this.setAlert('danger', {ResultMsg: Resources.PASSWORD_VULNERAVEL_00083});
						} else {
							this.setAlert('success', "ok");
						}
					} else {
						this.setAlert('danger', {ResultMsg: data.Message})
					}
				});
			},
			servicePassCheck() {
				this.resultMsg = "";            
				this.statusError = false;
				this.servicePassResults = [];

				QUtils.postData('Config', 'ServicePasswordCheck', {}, null, function (data) {
					if (data.Success) {
						if(data.resultList && data.resultList.length > 0) {
							this.servicePassResults = data.resultList;
						} else {
							this.resultMsg = "ok";
							this.statusError = false;
						}
					} else {
						this.resultMsg = data.Message;
						this.statusError = true;
					}
				});
			},
			passAdd() {
				this.resultMsg = "";
				this.statusError = false;

				const params = {
					password: this.password
				};
				QUtils.postData('Config', 'BlacklistPasswordAdd', params, null, function (data) {
					if (data.Success) {
						this.resultMsg = this.Resources.ALTERACOES_EFETUADAS10166;
						this.statusError = false;
						this.numPasswords = data.numPasswords;
					} else {
						this.resultMsg = data.Message;
						this.statusError = true;
					}
				});
			},
			deleteAll() {
				this.resultMsg = "";
				this.statusError = false;
				QUtils.postData('Config', 'BlacklistPasswordClear', {}, null, function (data) {
					if (data.Success) {
						this.resultMsg = this.Resources.ALTERACOES_EFETUADAS10166;
						this.statusError = false;
						this.numPasswords = data.numPasswords;
					} else {
						this.resultMsg = data.Message;
						this.statusError = true;
					}
				});
			},
			showManageBlacklist() {
				this.getbuttonsBlacklist()
				this.showBlacklistDialog = true;
			},
			getbuttonsBlacklist() {
				this.buttonsBlacklist.push({
					id: 'cancel-btn',
					props: {
						label: this.Resources.CANCELAR49513
					},
					action: () => {
						this.buttonsBlacklist = [],
						this.password = ''
					}
				})
			},
			updateAlert(data) {
				this.Model.ResultMsg = data.ResultMsg;
				if (data.AlertType) {
				this.setAlert(data.AlertType, data.ResultMsg);
				} else {
					this.setAlert('info', data.ResultMsg);
				}
			},
			handleConnectionTested(result) {
				if (result.Success) {
					this.setAlert('success', 'Connection success');
				} else {
					this.setAlert('danger', result.message || 'Connection failed');
				}
			},
			setAlert(type, message) {
				this.alert.isVisible = true;
				this.alert.alertType = type;
				this.alert.message = message;

				this.$nextTick(() => {
					if (this.$refs.alertBox) {
						this.$refs.alertBox.$el.scrollIntoView({ behavior: 'smooth' });
					}
				});
			},
			handleAlertDismissed() {
				this.alert.isVisible = false;
			},
			getButtonsDialog(dialogType) {	
				let isDisabled

				if (dialogType === 'userDialog') {
					isDisabled = this.invalidUserProps;
				} else if (dialogType === 'identityDialog') {
					isDisabled = this.invalidIdentityProps;
				} else if (dialogType === 'roleDialog') {
					isDisabled = this.invalidRoleProps;
				} else {
					isDisabled = false;
				}
				switch(this.dialogMode) {
					case 'delete':
						this.buttons.push({
							id: 'delete-btn',
							props: {
								label: this.Resources.APAGAR04097,
								variant: 'bold',
								color: "danger"
							},
							action: () => {
								if (dialogType === 'userDialog') {
									this.SaveUserCfg()
								} else if (dialogType === 'identityDialog') {
									this.SaveIdentityProvider()
								} else {
									this.SaveRoleProvider()
								}
							}
						});
						break;
					case 'edit':
					case 'new':
						this.buttons.push({
							id: 'save-btn',
							props: {
								label: this.Resources.GRAVAR45301,
								variant: 'bold',
								disabled: isDisabled
							},
							action: () => {
								if (dialogType === 'userDialog') {
									this.SaveUserCfg()
								} else if (dialogType === 'identityDialog') {
									this.SaveIdentityProvider()
								}
								else {
									this.SaveRoleProvider()
								}
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
					action: () => {
						if (dialogType === 'userDialog') {
							this.clearUserCfg()
						} else if (dialogType === 'identityDialog') {
							this.clearIdentityProviderValues()
						}
						else {
							this.clearRoleProvider()
						}
					}
				})
			},
			onTypeChange(context) {
				switch (context) {
					case 'identityProvider':
						if (this.rowType === 'GenioServer.security.LdapQueryIdentityProvider' ||
							this.rowType === 'GenioServer.security.LdapIdentityProvider') {
							this.tempConfig = ReadProviderConfig(this.rowType, this.tempConfig, this.SelectLists.IdentityProviderTypeList);
						} else {
							this.tempConfig = this.getProviderConfig(this.rowType);
						}
						break;
					case 'roleProvider':
						this.tempRoleConfig = this.getRoleProviderConfig(this.roleType);
						break;
					default:
						break;
				}
			},
			getProviderConfig(type) {
				const provider = this.SelectLists.IdentityProviderTypeList.find(
					(p) => p.TypeFullName === type
				);
				if (!provider) return [];
				return provider.Options.map((option) => ({
					Value: NormalizeValue(option, this.tempConfig),
					...option,
				}));
			},
			getRoleProviderConfig(type) {
				const roleProvider = this.SelectLists.RoleProviderTypeList.find(
					(p) => p.TypeFullName === type
				);
				if (!roleProvider) return [];
				return roleProvider.Options.map((option) => ({
					Value: NormalizeValue(option, this.tempRoleConfig),
					...option,
				}));
			},
			buildConfigFromTempConfig(tempConfig) {
				let config = {};

				tempConfig.forEach(option => {
					config[option.PropertyName] = option.Value || "";
				});
				const optionsString = JSON.stringify(config);
				return `Options=${optionsString}`;
			},
			SaveIdentityProvider() {
				let config;
				if (this.tempConfig && Object.keys(this.tempConfig).length > 0) {
					if (this.rowType === 'GenioServer.security.LdapQueryIdentityProvider' ||
					this.rowType === 'GenioServer.security.LdapIdentityProvider') {
						config = Object.entries(this.tempConfig.reduce((acc, curr) => {
							acc[curr.PropertyName] = curr.Value;
							return acc;
						}, {}))
						.map(([key, value]) => `${encodeURIComponent(key)}=${encodeURIComponent(value)}`)
						.join('&');
					} else {
						config = this.buildConfigFromTempConfig(this.tempConfig);
					}
				}
				const idProValues = {
					Name: this.rowName,
					Description: this.rowDescription,
					Type: this.rowType,
					Config: config,
					FormMode: this.dialogMode,
					Rownum: this.rowNum
				}
				QUtils.postData('Config', 'SaveIdentityProvider', idProValues, { appId: this.$store.state.currentApp }, (data) => {
					if (data.success) {
						switch (idProValues.FormMode) {
							case 'new':
								this.identityProvidersRows.push(
									{
										FormMode: this.dialogMode,
										Name: this.rowName,
										Description: this.rowDescription,
										Type: this.rowType,
										Config: config,
										Rownum: this.identityProvidersRows.length
									}
								)
								break;
							case 'edit':
								const newPropIndex = this.identityProvidersRows.findIndex(value => value.Rownum == this.rowNum)
								this.identityProvidersRows[newPropIndex].Type = this.rowType;
								this.identityProvidersRows[newPropIndex].Name = this.rowName;
								this.identityProvidersRows[newPropIndex].Description = this.rowDescription;
								this.identityProvidersRows[newPropIndex].Config = config;
								this.identityProvidersRows[newPropIndex].Rownum = this.rowNum;
								break;
							case 'delete':
								this.identityProvidersRows = this.identityProvidersRows.filter(prop => prop.Name != this.rowName).sort((a, b) => a.rowNum - b.rowNum);
								this.identityProvidersRows.forEach((identityProvidersRows, idx) => {
									identityProvidersRows.Rownum = idx
								})
								break;
							default:
								break;
						}
						this.clearIdentityProviderValues()
						// Update model data
						this.$emit('update-model')
					}
				});
			},
			clearIdentityProviderValues(){
				this.dialogMode = '',
				this.rowType = '',
				this.rowName = '',
				this.rowDescription = '',
				this.tempConfig = []
				this.buttons = []
			},
			showIdentityProviderModal(mode) {
				this.dialogMode = mode;
				this.getButtonsDialog('identityDialog');
				this.showIdentityDialog = true;
			},
			changeIdentityProvider(identityProvidersRows) {
				this.rowName = identityProvidersRows.Name;
				this.rowDescription = identityProvidersRows.Description;
				this.rowType = identityProvidersRows.Type;
				this.rowNum = identityProvidersRows.Rownum;
				let configString = identityProvidersRows.Config;

				this.tempConfig = configString?.startsWith("Options=")
				? configString.substring(8)
				: configString || {};

				this.showIdentityProviderModal('edit');
			},
			deleteIdentityProvider(identityProvidersRows) {
				this.rowName = identityProvidersRows.Name;
				this.rowDescription = identityProvidersRows.Description;
				this.rowType = identityProvidersRows.Type;
				this.rowNum = identityProvidersRows.Rownum;
				let configString = identityProvidersRows.Config;

				this.tempConfig = configString?.startsWith("Options=")
				? configString.substring(8)
				: configString || {};
				
				this.showIdentityProviderModal('delete');
			},
			createIdentityProvider() {
				this.showIdentityProviderModal('new');
			},
			SaveUserCfg() {
				const userValues = {
					Name: this.userName,
					Type: this.userType,
					AutoLogin: this.userAutoLogin,
					Password: this.userPassword,
					FormMode: this.dialogMode,
					Rownum: this.userNum
				}
				QUtils.postData('Config', 'SaveUserCfg', userValues, null, (data) => {
					if (data.success) {
						switch (userValues.FormMode) {
							case 'new':
								this.userRows.push(data.users);
							break;
							case 'edit':
								const newUserRowsIndex = this.userRows.findIndex(value => value.Rownum == this.userNum)
								this.userRows[newUserRowsIndex].Type = this.userType;
								this.userRows[newUserRowsIndex].AutoLogin = this.userAutoLogin;
								this.userRows[newUserRowsIndex].Password = this.userPassword;
								this.userRows[newUserRowsIndex].Name = this.userName;
								break;
							case 'delete':
								this.userRows = this.userRows.filter(prop => prop.Name != this.userName).sort((a, b) => a.userNum - b.userNum);
								this.userRows.forEach((userRows, idx) => {
									userRows.Rownum = idx
								})
								break;
							default:
							break;
						}
					}
					else {
						this.$emit('alert-class', { ResultMsg: data.Message, AlertType: 'danger' });
					}

					this.clearUserCfg()
					// Update model data
					this.$emit('update-model')
				});
			},
			typeMapping(userType) {
				const typeMapping = {
					'Regular': 'Normal',
					'Guest': 'Guest',
					'Admin': 'Administrator'
				}
				return typeMapping[userType]
			},
			clearUserCfg(){
				this.dialogMode = '',
				this.userName = '',
				this.userType = '',
				this.userAutoLogin = false,
				this.userPassword = '',
				this.buttons = []
			},
			showUserModal(mode) {
				this.dialogMode = mode;
				this.getButtonsDialog('userDialog');
				this.showUserDialog = true;
			},
			changeUser(userRows) {
				const mappedType = this.typeMapping(userRows.Type)
				const userTypeObj = this.SelectLists.DisplayUserType.find(item => item.Text === mappedType);
				this.userName = userRows.Name
				this.userType = userTypeObj.Value
				this.userAutoLogin = userRows.AutoLogin
				this.userPassword = userRows.Password
				this.showUserModal('edit');
			},
			deleteUser(userRows) {
				const mappedType = this.typeMapping(userRows.Type)
				const userTypeObj = this.SelectLists.DisplayUserType.find(item => item.Text === mappedType);
				this.userName = userRows.Name
				this.userType = userTypeObj.Value
				this.userAutoLogin = userRows.AutoLogin
				this.userPassword = userRows.Password
				this.showUserModal('delete');
			},
			createUser() {
				this.showUserModal('new');
			},
			SaveRoleProvider() {
				const roleConfig = this.buildConfigFromTempConfig(this.tempRoleConfig);
				const roleValues = {
					Name: this.roleName,
					Type: this.roleType,
					Precond: this.rolePrecond,
					Config: roleConfig.Options,
					FormMode: this.dialogMode,
					Rownum: this.roleNum
				}
				QUtils.postData('Config', 'SaveRoleProvider', roleValues, { appId: this.$store.state.currentApp }, (data) => {
					if (data.success) {
						switch (roleValues.FormMode) {
							case 'new':
								this.roleRows.push(
									{
										Name: this.roleName,
										Type: this.roleType,
										Precond: this.rolePrecond,
										Config: roleConfig.Options,
										FormMode: this.dialogMode,
										Rownum: this.roleRows.length
									}
								)
							break;
							case 'edit':
								const newRoleRowsIndex = this.roleRows.findIndex(value => value.Rownum == this.roleNum)
								this.roleRows[newRoleRowsIndex].Type = this.roleType;
								this.roleRows[newRoleRowsIndex].Precond = this.rolePrecond;
								this.roleRows[newRoleRowsIndex].Config = roleConfig.Options;
								this.roleRows[newRoleRowsIndex].Name = this.roleName;
								break;
							case 'delete':
								this.roleRows = this.roleRows.filter(prop => prop.Name != this.roleName).sort((a, b) => a.roleNum - b.roleNum);
								this.roleRows.forEach((roleRows, idx) => {
									roleRows.Rownum = idx
								})
								break;
							default:
								break;
						}
					}
					else {
						this.$emit('alert-class', { ResultMsg: data.Message, AlertType: 'danger' });
						}

					this.clearRoleProvider()
					// Update model data
					this.$emit('update-model')
				});
			},
			clearRoleProvider() {
				this.dialogMode = '',
				this.roleName = '',
				this.roleType = '',
				this.rolePrecond = '',
				this.tempRoleConfig = [],
				this.buttons = []
			},
			showRoleProviderModal(mode) {
				this.dialogMode = mode;
				this.getButtonsDialog("roleDialog");
				this.showRoleDialog = true;
			},
			changeRoleProvider(roleRows) {
				this.roleName = roleRows.Name
				this.roleType = roleRows.Type
				this.rolePrecond = roleRows.Precond
				this.tempRoleConfig =  JSON.parse(roleRows.Config)
				this.showRoleProviderModal('edit');
			},
			deleteRoleProvider(roleRows) {
				this.roleName = roleRows.Name
				this.roleType = roleRows.Type
				this.rolePrecond = roleRows.Precond
				this.tempRoleConfig =  JSON.parse(roleRows.Config)
				this.showRoleProviderModal('delete');
			},
			createRoleProvider() {
				this.showRoleProviderModal('new');
			},
		},
		created() {
			const url = QUtils.apiActionURL('Config', 'ManagePasswordBlacklist');
			QUtils.FetchData(url).done(function (data) {
				this.numPasswords = data.numPasswords;
			});
		},
		updated() {
			this.userRows = this.Security.Users || [];
			this.identityProvidersRows = this.Security.IdentityProviders || [];
			this.roleRows = this.Security.RoleProviders || [];
		},
		mounted() {
			this.userRows = this.Security.Users || [];
			this.identityProvidersRows = this.Security.IdentityProviders || [];
			this.roleRows = this.Security.RoleProviders || [];
		},
		watch: {
			'Security.Activate2FA': function (val) {
				if (!val) {
					this.Security.Mandatory2FA = false;
				}
			},
			invalidUserProps(newValue) {
				if (this.buttons.length > 0)
					this.buttons[0].props.disabled = newValue
			},
			invalidIdentityProps(newValue) {
				if (this.buttons.length > 0)
					this.buttons[0].props.disabled = newValue
			},
			invalidRoleProps(newValue) {
				if (this.buttons.length > 0)
					this.buttons[0].props.disabled = newValue
			},
			rowType(newValue) {
				if (newValue) {
					this.onTypeChange("identityProvider");
				}
			},
			roleType(newValue) {
				if (newValue) {
					this.onTypeChange("roleProvider");
				}
			}
		}
	};
</script>
