<template>
	<div id="system_setup_reporting_container">
		<QGroupBoxContainer :label="Resources.CRYSTAL_REPORTS15382">
			<q-row-container>
				<q-control-wrapper class="control-row-group">
					<base-input-structure
						class="i-text">
						<text-input v-model="model.pathReports" :label="Resources.CAMINHO_PARA_RELATOR05547"></text-input>
					</base-input-structure>
				</q-control-wrapper>
			</q-row-container>
		</QGroupBoxContainer>
		<QGroupBoxContainer :label="Resources.SQL_SERVER_REPORTING62106">
			<q-row-container>
				<q-control-wrapper class="control-row-group">
					<base-input-structure
						class="i-text">
						<text-input v-model="model.ssrsServer" :label="Resources.URL05719"></text-input>
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="control-row-group">
					<base-input-structure
						class="i-text">
						<text-input v-model="model.ssrsServerPath" :label="Resources.CAMINHO18436"></text-input>
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="control-row-group">
					<base-input-structure
						class="i-text">
						<checkbox-input v-model="model.isLocalReports" :label="Resources.SAO_OS_RELATORIOS_LO04230"></checkbox-input>
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="control-row-group">
					<base-input-structure
						class="i-text">
						<text-input v-model="model.ssrsServerDomain" :label="Resources.DOMINIO33043"></text-input>
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="control-row-group">
					<base-input-structure
						class="i-text">
						<text-input v-model="model.ssrsServerUsername" :label="Resources.NOME_DE_UTILIZADOR58858"></text-input>
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="control-row-group">
					<base-input-structure
						class="i-text">
						<password-input v-model="model.ssrsServerPassword" :label="Resources.PALAVRA_PASSE44126" :showFiller="model.hasSsrsServerPassword" size="xlarge"></password-input>
					</base-input-structure>
				</q-control-wrapper>
			</q-row-container>
		</QGroupBoxContainer>
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
import bootbox from 'bootbox';

export default {
	name: 'reporting',
	props: {
		model: {
			required: true
		}
	},
	mixins: [reusableMixin],
	emits: ['updateModal'],
	data() {
		var vm = this;
		return {			
		};
	},
	methods: {
		SaveConfigOthers() {
			var vm = this;
			QUtils.log("SaveConfigOthers - Request", QUtils.apiActionURL('Config', 'SaveConfigOthers'));
			QUtils.postData('Config', 'SaveConfigOthers', vm.model, null, function (data) {
				QUtils.log("SaveConfigOthers - Response", data);
				if (data.Success) {
					bootbox.alert(vm.Resources.ALTERACOES_EFECTUADA64514);
				}
				else {
					bootbox.alert(data.Message);
				}
			});
		},
	}
};
</script>
