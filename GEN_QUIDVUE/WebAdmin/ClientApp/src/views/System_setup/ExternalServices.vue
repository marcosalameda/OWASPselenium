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
            @alertClass="forwardAlert" />
        <reports
            :model="model"
            @alertClass="forwardAlert" />
	</div>
</template>

<script>
	// @ is an alias to /src
	import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';
	import QAlert from '@/components/QAlert.vue';
	import elasticsearch from './Elasticsearch';
	import reports from './Reports';

	export default {
		name: 'externalservices',
		components: { QAlert, elasticsearch, reports },
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

		emits: ['updateModal', 'alertClass'],

		methods: {
			forwardAlert(alertData) {
				this.$emit('alertClass', alertData);
			},
		}
	};
</script>
