<template>
    <div class="modal fade" ref="modalForm" id="ack" tabindex="-1" role="dialog" aria-labelledby="ack_Title" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="system_setup_core_Title">Ack</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" @click="close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <row>
                        <text-input v-model="Model.source" :label="Resources.QUEUE_ORIGEM31278" :isReadOnly="blockForm" :size="'xlarge'"></text-input>
                    </row>
                    <row>
                        <text-input v-model="Model.ackQueue" :label="Resources.QUEUE_ACK30680" :isReadOnly="blockForm" :size="'xlarge'"></text-input>
                    </row>
                    <row>
                        <numeric-input v-model="Model.Blocksize" :label="Resources.TAMANHO_DO_BLOCO42316" :isReadOnly="blockForm" :size="'xlarge'"></numeric-input>
                    </row>
                </div>
                <div class="modal-footer">
                    <q-button
                        :label="Resources.CANCELAR49513"
                        @click="close" />
                    <q-button
                        v-if="Model.FormMode == 'delete'"
                        b-style="danger"
                        @click="fnSubmit"
                        :label="Resources.APAGAR04097" />
                    <q-button
                        v-else
                        b-style="primary"
                        :label="Resources.GRAVAR45301"
                        @click="fnSubmit" />
                </div>
            </div>
        </div>
    </div>
</template>

<script>
  // @ is an alias to /src
  import { reusableMixin } from '@/mixins/mainMixin';
  import { QUtils } from '@/utils/mainUtils';

    export default {
        name: 'system_setup_ack',
        mixins: [reusableMixin],
        emits: ['close'],
        props: {
            Model: {
                required: true
            },
            show: {
                required: true
            }
        },
        computed: {
            blockForm: function () {
                return this.Model.FormMode == 'show' || this.Model.FormMode == 'delete';
            }
        },
        methods: {
            fnSubmit: function () {
                var vm = this;
                QUtils.postData('Config', 'SaveQueueACK', vm.Model, null, function () { vm.$emit('close', true); });
            },
            close: function () {
                this.$emit('close', false);
            },
            initForm: function () {
                if (this.show) { $(this.$refs.modalForm).modal('show'); }
                else { $(this.$refs.modalForm).modal('hide'); }
            }
        },
        mounted: function () {
            this.initForm();
        },
        watch: {
            'show': 'initForm'
        }
    };
</script>
