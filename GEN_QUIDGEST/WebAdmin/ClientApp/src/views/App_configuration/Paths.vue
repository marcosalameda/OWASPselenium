<template>
	<div id="system_setup_paths_container">
		<row>
			<q-card
				class="q-card--admin-default"
				:title="GetTitle"
				width="block">
				<q-row-container>
					<q-text-field
						v-model="Model.pathApp"
						size="xlarge"
						:label="Resources.CAMINHO_PARA_A_APLIC44450" />
					<q-text-field
						v-model="Model.pathDocuments"
						size="xlarge"
						:label="Resources.CAMINHO_PARA_DOCUMEN18456" />
				</q-row-container>
			</q-card>
		</row>

		<row class="footer-btn">
			<q-button
				b-style="primary"
				:label="Resources.GRAVAR_CONFIGURACAO36308"
				@click="SavePathCfg" />
		</row>

		<row>
			<q-card
				class="q-card--admin-border-top q-card--admin-compact"
				:title="Resources.DESCARREGAR_FICHEIRO61580"
				variant="minor"
				width="block">
				<q-button
					b-style="secondary"
					label="Configurations.redirect.xml"
					@click="goToDownloadRedirect" />
			</q-card>
		</row>
	</div>
</template>

<script>
	// @ is an alias to /src
	import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';
	import bootbox from 'bootbox';

	export default {
		name: 'paths',

		props: {
			model: {
				required: true
			}
		},

		mixins: [reusableMixin],

		data() {
			return {
				Model: this.model,
			};
		},

		methods: {
			goToDownloadRedirect() {
				window.location.href = this.DownloadRedirect;
			},
			SavePathCfg() {
				var vm = this;
				QUtils.log("SavePathCfg - Request", QUtils.apiActionURL('Config', 'SavePathCfg'))
				QUtils.postData('Config', 'SavePathCfg', vm.Model, null, function (data) {
					QUtils.log("SavePathCfg - Response", data)
					if (data.Success) {
						bootbox.alert(vm.Resources.ALTERACOES_EFETUADAS10166);
					}
					else {
						bootbox.alert(data.Message)
					}
				})
 			}
		},

		computed: {
			DownloadRedirect() {
				return QUtils.apiActionURL('Config', 'DownloadRedirect');
			},
			
			GetTitle() {
				return this.Resources.CAMINHOS41141 + ' ' + '(' + this.currentApp +')';
			}
		}
	};
</script>
