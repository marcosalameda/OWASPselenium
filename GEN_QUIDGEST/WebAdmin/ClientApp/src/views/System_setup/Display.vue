<template>
	<div id="system_setup_settings_container">
		<row>
			<q-card
				class="q-card--admin-default"
				:title="Resources.GARANTIA_DE_QUALIDAD19784"
				width="block">
				<q-checkbox 
					v-model="model.QAEnvironment" 
					:label="Resources.AMBIENTE_DE_QA_09940">
					<template #extras>
						<q-icon icon="information-outline" />
						{{ Resources.SELECIONE_PARA_MOSTR59643 }}
					</template>
				</q-checkbox>
			</q-card>
		</row>

		<row>
			<q-card
				class="q-card--admin-default"
				:title="Resources.FORMATO_DAS_DATAS11781"
				width="block">
				<q-row-container v-if="model.DateFormat">
					<q-text-field 
						v-model="model.DateFormat.date"
						:label="Resources.DATA18071"
						size="medium" />
					<q-text-field
						v-model="model.DateFormat.dateTime"
						:label="Resources.DATA_E_HORA33196"
						size="medium" />
					<q-text-field
						v-model="model.DateFormat.dateTimeSeconds"
						:label="Resources.DATA__HORAS_E_SEGUND03637"
						size="large" />
					<q-text-field
						v-model="model.DateFormat.time"
						:label="Resources.HORAS01448"
						size="small" />
				</q-row-container>
			</q-card>
		</row>

		<row>
			<q-card
				class="q-card--admin-default"
				:title="Resources.FORMATO_DE_NUMERO58330"
				width="block">
				<q-row-container v-if="SelectLists">
					<q-select
						v-model="model.DecimalSeparator"
						:items="SelectLists.DecimalSeparator"
						item-value="Value"
						item-label="Text"
						:label="Resources.SEPARADOR_DECIMAL14173" />
					<q-select
						v-model="model.GroupSeparator"
						:items="SelectLists.GroupSeparator"
						item-value="Value"
						item-label="Text"
						:label="Resources.SEPARADOR_DE_GRUPO26735" />
				</q-row-container>
			</q-card>
		</row>

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

	emits: ['update-model', 'alert-class'],
	
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
		saveConfigOthers() {
			QUtils.log("SaveConfigOthers - Request", QUtils.apiActionURL('Config', 'SaveConfigOthers'));
			QUtils.postData('Config', 'SaveConfigOthers', this.model, null, (data) => {
				QUtils.log("SaveConfigOthers - Response", data);
				if (data.Success) {
					this.$emit('alert-class', { ResultMsg: this.Resources.ALTERACOES_EFETUADAS10166, AlertType: 'success' });
				}
				else {
					this.$emit('alert-class', { ResultMsg: data.Message, AlertType: 'danger' });
				}
			});
		},
	}
};
</script>
