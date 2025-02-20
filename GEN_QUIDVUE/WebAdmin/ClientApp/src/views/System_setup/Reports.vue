<template>
	<row>
		<q-card
			id="system_setup_reporting_container"
			width="block"
			class="q-card--admin-default"
			:title="Resources.RELATORIOS37339">
			<q-row-container>
				<row>
					<q-card
						class="q-card--admin-border-top q-card--admin-compact"
						:title="Resources.CRYSTAL_REPORTS15382"
						width="block">
						<q-text-field
							v-model="model.pathReports"
							:label="Resources.CAMINHO_PARA_RELATOR05547"
							size="xlarge" />
					</q-card>
				</row>
				<row>
					<q-card
						class="q-card--admin-border-top q-card--admin-compact"
						:title="Resources.SQL_SERVER_REPORTING62106"
						width="block">
						<q-row-container>
							<q-text-field
								v-model="model.ssrsServer"
								:label="Resources.URL05719"
								size="xlarge" />
							<q-text-field
								v-model="model.ssrsServerPath"
								:label="Resources.CAMINHO18436"
								size="xlarge" />
							<q-checkbox
								v-model="model.isLocalReports"
								:label="Resources.SAO_OS_RELATORIOS_LO04230" />
							<q-text-field
								v-model="model.ssrsServerDomain"
								:label="Resources.DOMINIO33043"
								size="xlarge" />
							<q-text-field
								v-model="model.ssrsServerUsername"
								:label="Resources.NOME_DE_UTILIZADOR58858"
								size="xlarge" />
							<password-input
								v-model="model.ssrsServerPassword"
								:label="Resources.PALAVRA_PASSE44126"
								:showFiller="model.hasSsrsServerPassword"
								size="xlarge">
							</password-input>
						</q-row-container>
					</q-card>
				</row>
				<row class="footer-btn">
					<q-button
						b-style="primary"
						:label="Resources.GRAVAR_CONFIGURACAO36308"
						@click="SaveConfigOthers" />
				</row>
			</q-row-container>
		</q-card>
	</row>
</template>

<script>
	// @ is an alias to /src
	import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';

	export default {
		name: 'reports',

		props: {
			model: {
				required: true
			},
		},

		mixins: [reusableMixin],

		emits: ['alertClass'],

		methods: {
			SaveConfigOthers() {
				var vm = this;
				QUtils.log("SaveConfigOthers - Request", QUtils.apiActionURL('Config', 'SaveConfigOthers'));
				QUtils.postData('Config', 'SaveConfigOthers', vm.model, null, function (data) {
					QUtils.log("SaveConfigOthers - Response", data);
						this.$emit('alertClass', {
						ResultMsg: data.Success ? this.Resources.ALTERACOES_EFETUADAS10166 : data.Message,
						AlertType: data.Success ? 'success' : 'danger'
					});
				});
			},
		}
	};
</script>
