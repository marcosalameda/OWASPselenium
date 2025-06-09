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
						:label="resources.pathAppLabel" />
					<q-text-field
						v-model="Model.pathDocuments"
						size="xlarge"
						:label="resources.pathDocumentsLabel" />
				</q-row-container>
			</q-card>
		</row>

		<row class="footer-btn">
			<q-button
				variant="bold"
				:label="hardcodedTexts.saveConfiguration"
				@click="SavePathCfg" />
		</row>

		<row>
			<q-card
				class="q-card--admin-border-top q-card--admin-compact"
				:title="resources.downloadConfigFile"
				variant="minor"
				width="block">
				<q-button
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
	import { texts } from '@/resources/hardcodedTexts.ts';

	export default {
		name: 'paths',

		props: {
			model: {
				required: true
			},
			resources: {
				type: Object,
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

				//Check if paths are all the same
				QUtils.log("Verify Config - Config - Backup");
				QUtils.postData('Config', 'VerifyDocPathConfig', vm.Model, null, function (data) {
					QUtils.log("VerifyDocPathConfig - Response", data);
					if (data.Success) {
						QUtils.log("SavePathCfg - Request", QUtils.apiActionURL('Config', 'SavePathCfg'));
						QUtils.postData('Config', 'SavePathCfg', vm.Model, null, function (data) {
							QUtils.log("SavePathCfg - Response", data);
							if (data.Success) {
								bootbox.alert(vm.Resources.ALTERACOES_EFETUADAS10166);
							}
							else {
								bootbox.alert(data.Message)
							}
						})
					}
					else {
						bootbox.confirm({
							title: vm.Resources.WARNING47821,
							message: vm.Resources.THERE_ARE_DIFFERENT_09399 +
							'<br />' + vm.Resources.DO_YOU_WITH_TO_SAVE_09416,
							backdrop: true,
							buttons: {
								confirm:
								{
									label: vm.Resources.GRAVAR45301
								},
								cancel:
								{
									label: vm.Resources.CANCELAR49513
								}
							},
							callback: function(result) {
								if(result) {
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
							}
						});
					}
				});
 			}
		},

		computed: {
			DownloadRedirect() {
				return QUtils.apiActionURL('Config', 'DownloadRedirect');
			},

			GetTitle() {
				return this.Resources.CAMINHOS41141 + ' ' + '(' + this.currentApp +')';
			},
			hardcodedTexts() {
				return {
					saveConfiguration: this.Resources[texts.saveConfiguration]
				};
			}
		}
	};
</script>
