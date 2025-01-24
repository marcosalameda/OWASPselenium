<template>
	<div id="notifications_pmail_container">
		<div class="q-stack--column">
			<h1 class="f-header__title">
				{{ Resources.SERVIDOR_DE_EMAIL19063 }}
			</h1>
		</div>
		<hr>
		<template v-if="!isEmptyObject(Model.ResultMsg)">
			<div class="alert alert-info">
				<p>
					<b class="status-message">
						{{ Model.ResultMsg }}
					</b>
				</p>
			</div>
			<br />
		</template>
		<template v-if="Model.FormMode==3">
			<div class="alert alert-block">
				<strong>Warning!</strong>
				{{ Resources.DESEJA_ELIMINAR_ESTA24564 }}
			</div>
		</template>

		<q-card
			class="q-card--admin-default"
			:title="Resources.DADOS_DO_REGISTO10198"
			width="block">
			<q-row-container>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<text-input
							v-model="Model.ValId"
							:label="Resources.ID36840"
							:isReadOnly="blockForm" />
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<text-input
							v-model="Model.ValDispname"
							:label="Resources.NOME_DO_REMETENTE60175"
							:isReadOnly="blockForm" />
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<text-input
							v-model="Model.ValFrom"
							:label="Resources.REMETENTE47685"
							:isReadOnly="blockForm" />
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<text-input
							v-model="Model.ValSmtpserver"
							:label="Resources.SERVIDOR_DE_SMTP00309"
							:isReadOnly="blockForm" />
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<numeric-input
							v-model="Model.ValPort"
							:label="Resources.PORTA55707"
							:isReadOnly="blockForm" />
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<q-checkbox
							v-model="Model.ValSsl"
							:label="Resources.USE_STARTTLS07856"
							:readonly="blockForm" />
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<select-input
							v-model="Model.ValAuthType"
							v-if="Model.SelectLists"
							size="xlarge"
							:options="Model.SelectLists.AuthType" 
							:label="Resources.REQUER_AUTENTICACAO_31938"
							:isReadOnly="blockForm" />
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper
					v-if="Model.ValAuthType && Model.ValAuthType != 'None'"
					class="row-line-group">
					<base-input-structure
						class="i-text">
						<text-input
							v-model="Model.ValUsername"
							:label="Resources.UTILIZADOR52387"
							:isReadOnly="blockForm" />
					</base-input-structure>
				</q-control-wrapper>

				<template v-if="Model.ValAuthType == 'OAuth2'">
					<q-control-wrapper class="row-line-group">
						<base-input-structure
							class="i-text">
							<text-input
								v-model="Model.ValOAuth2Options.ClientId"
								label="Client Id"
								:isReadOnly="blockForm" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper class="row-line-group">
						<base-input-structure
							class="i-text">
							<password-input
								v-model="Model.OAuth2ClientSecret"
								label="Client Secret"
								:isReadOnly="blockForm"
								:showFiller="Model.HasOAuth2ClientSecret" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper class="row-line-group">
						<base-input-structure
							class="i-text">
							<password-input
								v-model="Model.OAuth2CertificateThumbprint"
								label="Certificate Thumbprint"
								:isReadOnly="blockForm"
								:showFiller="Model.HasOAuth2Certificate" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper class="row-line-group">
						<span>
							{{ Resources.IF_THE_CERTIFICATE_I34537 }}
						</span>
					</q-control-wrapper>
					<q-control-wrapper class="row-line-group">
						<base-input-structure
							class="i-text">
							<text-input
								v-model="Model.ValOAuth2Options.TokenEndpoint"
								label="Token Endpoint"
								:isReadOnly="blockForm" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper class="row-line-group">
						<base-input-structure
							class="i-text">
							<q-list-editor 
								v-model="Model.ValOAuth2Options.Scope" 
								label="Scope" 
								addText="Add new scope"
								removeText="Remove scope"
								editText="Edit scope"
								:isReadOnly="blockForm" />
						</base-input-structure>
					</q-control-wrapper>
				</template>

				<template v-else-if="Model.ValAuthType == 'BasicAuth'">
					<q-control-wrapper class="row-line-group">
						<base-input-structure
							class="i-text">
							<password-input
								v-model="Model.ValPassword"
								:label="Resources.PASSWORD09467"
								:isReadOnly="blockForm"
								:showFiller="Model.HasPassword" />
						</base-input-structure>
					</q-control-wrapper>
					<row v-show="!blockForm && Model.ValPassword">
						<div
							id="passMeter"
							ref="PassMeter">
							<meter
								ref="pswStrengthMeter"
								max="4"
								id="password-strength-meter"
								value="0" />
							<br />
							<span
								ref="pswStrengthText"
								id="password-strength-text" />
						</div>
					</row>
				</template>

				<row class="footer-btn">
					<q-button
						v-if="Model.FormMode !== 3"
						b-style="primary"
						:label="Resources.GRAVAR_CONFIGURACAO36308"
						@click="SaveProperties" />
					<q-button
						v-else
						b-style="danger"
						:label="Resources.APAGAR04097"
						@click="SaveProperties" />
					<q-button
						:label="Resources.CANCELAR49513"
						@click="cancel" />
				</row>
			</q-row-container>

		</q-card>
	</div>
</template>

<script>
// @ is an alias to /src
import { reusableMixin } from '@/mixins/mainMixin';
import { QUtils } from '@/utils/mainUtils';
//import bootbox from 'bootbox';

import _get from "lodash-es/get";

	export default {
		name: 'notifications_properties',

		mixins: [reusableMixin],

		data: function () {
			//var vm = this;
			return {
				Model: {}
			};
		},

		computed: {
			blockForm: function () { return this.Model.FormMode == 3; }
		},

		methods: {
			fetchData: function () {
				var vm = this,
					mod = vm.$route.params.mod,
					codpmail = _get(vm.$route.params, 'codpmail', null);
				QUtils.log("Fetch data - ManageProperties");
				QUtils.FetchData(QUtils.apiActionURL('Email', 'ManageProperties', { mod, codpmail })).done(function (data) {
					QUtils.log("Fetch data - OK (ManageProperties)", data);
					if (data.Success) {
						$.each(data.model, function (propName, value) { vm.Model[propName] = value; });
					}
				});
			},

			cancel: function () {
				var vm = this;
				vm.$router.replace({ name: 'email', params: { culture: vm.currentLang, system: vm.currentYear } });
			},

			SaveProperties: function () {
				var vm = this;
				QUtils.log("ManageProperties - Request", QUtils.apiActionURL('Notifications', 'SaveProperties'));
				QUtils.postData('Email', 'SaveProperties', vm.Model, null, function (data) {
					QUtils.log("ManageProperties - Response", data);
					if (data.Success) {
						vm.$router.replace({ name: 'email', params: { culture: vm.currentLang, system: vm.currentYear } });
					}
					else {
						vm.Model.ResultMsg = data.ResultMsg;
					}
				});
			},

			scorePassword: function (pass)
			{
				var score = 0;
				if (!pass)
					return score;

				// award every unique letter until 5 repetitions
				var letters = new Object();
				for (var i = 0; i < pass.length; i++)
				{
					letters[pass[i]] = (letters[pass[i]] || 0) + 1;
					score += 5.0 / letters[pass[i]];
				}

				// bonus points for mixing it up
				var variations = {
					digits: /\d/.test(pass),
					lower: /[a-z]/.test(pass),
					upper: /[A-Z]/.test(pass),
					nonWords: /\W/.test(pass),
				}

				var variationCount = 0;
				for (var check in variations)
					variationCount += (variations[check] == true) ? 1 : 0;
				score += (variationCount - 1) * 10;

				return parseInt(score);
			}
		},

		created: function () {
			// Ler dados
			this.fetchData();
		},

		watch: {
			'Model.ValPassword': {
				handler() {
					var vm = this,
					// calculates the password strength
					score = vm.scorePassword(vm.Model.ValPassword),
					scoreStrength = 0,
					pswStrengthMeter = $(vm.$refs.pswStrengthMeter),
					pswStrengthText = $(vm.$refs.pswStrengthText);

					if ($.isEmptyObject(vm.Model.ValPassword))
					{
						scoreStrength = 0;
						pswStrengthMeter.text('');
					}
					else if (score > 80)
					{
						scoreStrength = 4;
						pswStrengthText.text(vm.Resources.FORTE13835);
					}
					else if (score > 60)
					{
						scoreStrength = 3;
						pswStrengthText.text(vm.Resources.BOM29058);
					}
					else if (score >= 30)
					{
						scoreStrength = 2;
						pswStrengthText.text(vm.Resources.FRACO22195);
					}
					else if (score < 30)
					{
						scoreStrength = 1;
						pswStrengthText.text(vm.Resources.POBRE46544);
					}
					pswStrengthMeter.val(scoreStrength);
				},
				deep: true
			}
		}
	};
</script>

<style scoped>
	meter {
		width: 100%;
		height: 10px;
	}

	/* WebKit */
	meter::-webkit-meter-bar {
		background: #EEE;
		box-shadow: 0 2px 3px rgba(0,0,0,0.2) inset;
		border-radius: 3px;
	}

	/* Webkit based browsers */
	meter::-webkit-meter-optimum-value {
		transition: width .4s linear;
	}

	meter[value="0"]::-webkit-meter-optimum-value {
		background: grey;
	}

	meter[value="1"]::-webkit-meter-optimum-value {
		background: red;
	}

	meter[value="2"]::-webkit-meter-optimum-value {
		background: orange;
	}

	meter[value="3"]::-webkit-meter-optimum-value {
		background: yellow;
	}

	meter[value="4"]::-webkit-meter-optimum-value {
		background: green;
	}

	/* Gecko based browsers */
	meter[value="0"]::-moz-meter-bar {
		background: grey;
	}

	meter[value="1"]::-moz-meter-bar {
		background: red;
	}

	meter[value="2"]::-moz-meter-bar {
		background: orange;
	}

	meter[value="3"]::-moz-meter-bar {
		background: yellow;
	}

	meter[value="4"]::-moz-meter-bar {
		background: green;
	}
</style>
