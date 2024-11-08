<template>
	<div id="system_setup_paths_container">
		<QGroupBoxContainer :label="GetTitle">
			<q-row-container>
				<q-control-wrapper class="control-row-group">
					<base-input-structure
						class="i-text">
						<text-input v-model="Model.pathApp" :label="Resources.CAMINHO_PARA_A_APLIC44450"></text-input>
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="control-row-group">
					<base-input-structure
						class="i-text">
						<text-input v-model="Model.pathDocuments" :label="Resources.CAMINHO_PARA_DOCUMEN18456"></text-input>
					</base-input-structure>
				</q-control-wrapper>
			</q-row-container>
		</QGroupBoxContainer>
		<row class="footer-btn">
			<q-button
				b-style="primary"
				:label="Resources.GRAVAR45301"
				@click="SavePathCfg" />
		</row>
		<QGroupBoxContainer :label="Resources.DESCARREGAR_FICHEIRO61580" class="c-groupbox--minor-border-top">
			<row>
				<q-button
					b-style="secondary"
					label="Configurations.redirect.xml"
					@click="goToDownloadRedirect" />
			</row>
		</QGroupBoxContainer>
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
