<template>
	<div id="system_setup_settings_container">
		<QGroupBoxContainer :label="Resources.GARANTIA_DA_QUALIDAD48670">
				<q-row-container>
					<q-control-wrapper class="row-line-group">
						<base-input-structure
							class="i-text">
							<checkbox-input v-model="model.QAEnvironment" :label="Resources.AMBIENTE_DE_QA_09940"></checkbox-input>
							<span class="q-help__subtext">
								<span class="mdi mdi-information-outline"></span>
								{{ Resources.SELECIONE_PARA_MOSTR41230 }}
							</span>
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
		</QGroupBoxContainer>
		<QGroupBoxContainer :label="Resources.FORMATO_DAS_DATAS11781">
				<q-row-container>
					<q-control-wrapper class="row-line-group">
						<base-input-structure
							class="i-text">
							<text-input v-if="model.DateFormat" v-model="model.DateFormat.date" :label="Resources.DATA18071" size="medium"></text-input>
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper class="row-line-group">
						<base-input-structure
							class="i-text">
							<text-input v-if="model.DateFormat" v-model="model.DateFormat.dateTime" :label="Resources.DATA_E_HORA33196" size="medium"></text-input>
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper class="row-line-group">
						<base-input-structure
							class="i-text">
							<text-input v-if="model.DateFormat" v-model="model.DateFormat.dateTimeSeconds" :label="Resources.DATA__HORAS_E_SEGUND03637" size="large"></text-input>
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper class="row-line-group">
						<base-input-structure
							class="i-text">
							<text-input v-if="model.DateFormat" v-model="model.DateFormat.time" :label="Resources.HORAS01448" size="small"></text-input>
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
		</QGroupBoxContainer>
		<QGroupBoxContainer :label="Resources.FORMATO_DE_NUMERO58330">
				<q-row-container>
					<q-control-wrapper class="row-line-group">
						<base-input-structure
							class="i-text">
							<select-input v-model="model.DecimalSeparator" v-if="SelectLists" :options="SelectLists.DecimalSeparator" :label="Resources.SEPARADOR_DECIMAL14173"></select-input>
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper class="row-line-group">
						<base-input-structure
							class="i-text">
							<select-input v-model="model.GroupSeparator" v-if="SelectLists" :options="SelectLists.GroupSeparator" :label="Resources.SEPARADOR_DE_GRUPO26735"></select-input>
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
	name: 'settings',
	props: {
		model: {
			required: true
		},
		SelectLists: {
			required: true
		}
	},
	mixins: [reusableMixin],
	emits: ['updateModal'],
	data() {
		var vm = this;
		return {
			modalForms: {
				core: {
					show: true,
					data: { }
				},
			advancedProperties: {
					show: false,
					data: { }
				},
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
