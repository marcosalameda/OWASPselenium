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

		emits: ['alert-class'],

        props: {
			model: {
				required: true
			}
		}
    }
</script>
