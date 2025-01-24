<template>
	<div id="system_setup_reporting_container">
		<row>
			<q-card
				class="q-card--admin-default"
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
				class="q-card--admin-default"
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
						size="medium">
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
	</div>
</template>

<script>
// @ is an alias to /src
import { reusableMixin } from '@/mixins/mainMixin';
import { QUtils } from '@/utils/mainUtils';

export default {
	name: 'reporting',

	props: {
		model: {
			required: true
		}
	},

	mixins: [reusableMixin],

	emits: ['updateModal', 'alertClass'],

	data() {
		var vm = this;
		return {			
			tRepor: {
				rows: [
				{Rep:this.model.pathReports  + '\\' + 'en-US',Lang: 'English'},
				{Rep:this.model.pathReports  + '\\' + 'pt-PT',Lang: 'Português'},
				],
				total_rows: 0,
				columns: [
					{
						label: vm.$t('RELATORIO62426'),
						name: "Rep",
						sort: true,
						initial_sort: true,
						initial_sort_order: "asc"
					},
					{
						label: vm.$t('LINGUAGEM43329'),
						name: "Lang",
						sort: true
					}
				],
				config: {
					table_title: vm.$t('RELATORIOS_POR_LINGU35356'),
					pagination : false,
					global_search: {visibility : false},
					highlight_row_hover: false,
					pagination_info: false
				}
			},
		};
	},
	
	methods: {
		SaveConfigOthers() {
			var vm = this;
			QUtils.log("SaveConfigOthers - Request", QUtils.apiActionURL('Config', 'SaveConfigOthers'));
			QUtils.postData('Config', 'SaveConfigOthers', vm.model, null, function (data) {
				QUtils.log("SaveConfigOthers - Response", data);
				if (data.Success) {
					vm.$emit('alertClass', { ResultMsg: vm.Resources.ALTERACOES_EFETUADAS10166, AlertType: 'success' });
				}
				else {
					vm.$emit('alertClass', { ResultMsg: data.Message, AlertType: 'danger' });
				}
			});
		},
	}
};
</script>
