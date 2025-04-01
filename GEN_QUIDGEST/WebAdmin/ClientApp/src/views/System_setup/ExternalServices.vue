<template>
	<div id="system_setup_external_services_container">
		<row>
			<q-card
				class="q-card--admin-default"
				:title="Resources.CONFIGURACOES_DE_INT56161"
				width="block">
				<q-row-container>
					<q-text-field
						v-model="model.UrlAPIBackend"
						:label="Resources.URL_DO_BACKEND_DA_AP53038">
						<template #extras>
							<div class="q-field__extras">
								<q-icon icon="information-outline" />
								{{ Resources.DEVERA_COLOCAR_O_END10058 }}
							</div>
						</template>
					</q-text-field>						
				</q-row-container>
			</q-card>
		</row>
		<elasticsearch
            :model="model"
			:Cores="Cores"
			:SelectLists="SelectLists"
            @alert-class="forwardAlert" />
        <reports
            :model="model"
            @alert-class="forwardAlert" />
		<row class="footer-btn">
			<q-button
				b-style="primary"
				:label="Resources.GRAVAR_CONFIGURACAO36308"
				@click="saveConfigOthers" />
		</row>
	</div>
</template>

<script>
	// @ is an alias to /src
	import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';
	import elasticsearch from './Elasticsearch';
	import reports from './Reports';

	export default {
		name: 'externalservices',
		components: { elasticsearch, reports },
		props: {
			model: {
				required: true
			},
			Cores: {
				required: true
			},
			SelectLists: {
				required: true
			}
		},

		mixins: [reusableMixin],

		emits: ['update-model', 'alert-class'],

		methods: {
			saveConfigOthers() {
				QUtils.log("SaveConfigOthers - Request", QUtils.apiActionURL('Config', 'SaveConfigOthers'));
				QUtils.postData('Config', 'SaveConfigOthers', this.model, null, (data) => {
					QUtils.log("SaveConfigOthers - Response", data);
						this.$emit('alert-class', {
						ResultMsg: data.Success ? this.Resources.ALTERACOES_EFETUADAS10166 : data.Message,
						AlertType: data.Success ? 'success' : 'danger'
					});
				});
			},
		}
	};
</script>
