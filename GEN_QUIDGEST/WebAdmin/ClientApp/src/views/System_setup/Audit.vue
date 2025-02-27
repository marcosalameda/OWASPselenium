<template>
    <row>
        <q-card
            width="block"
            class="q-card--admin-default"
            :title="Resources.AUDITORIA29703">
            <q-row-container>
                <q-checkbox
                    v-model="model.RegistLoginOut"
                    :label="Resources.AUDITORIA_DE_LOGIN_D00905" />
                <q-checkbox
                    v-model="model.RegistActions"
                    :label="Resources.AUDITORIA_DE_ACOES_D42106" />
                <q-checkbox
                    v-model="model.AuditInterface"
                    :label="Resources.AUDITORIA_DO_SISTEMA08460" />
                <q-checkbox
                    v-model="model.EventTracking"
                    :label="Resources.REGISTO_DE_EVENTOS65341" />
                <row class="footer-btn">
                    <q-button
                        b-style="primary"
                        :label="Resources.GRAVAR_CONFIGURACAO36308"
                        @click="SaveConfigAudit" />
                </row>
            </q-row-container>
        </q-card>
    </row>
</template>

<script>
    import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';

    export default {
		name: 'audit',

        mixins: [reusableMixin],

		emits: ['alertClass'],

        props: {
			model: {
				required: true
			}
		},

        methods: {
            SaveConfigAudit() {
				var vm = this;
				QUtils.log("SaveConfigAudit - Request", QUtils.apiActionURL('Config', 'SaveConfigAudit'));
				QUtils.postData('Config', 'SaveConfigAudit', vm.model, null, function (data) {
					QUtils.log("SaveConfigAudit - Response", data);
					if (data.Success) {
						vm.$emit('alertClass', { ResultMsg: vm.Resources.ALTERACOES_EFETUADAS10166, AlertType: 'success' });
					}
					else {
						vm.$emit('alertClass', { ResultMsg: data.Message, AlertType: 'danger' });
					}
				});
			},
        }
    }
</script>
