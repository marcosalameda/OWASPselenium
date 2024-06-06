<template>
    <div id="password_blacklist_container" class="container-fluid">
        <h1 class="pb-2 mt-4 mb-2 border-bottom">{{ Resources.MANAGE_PASSWORD_BLAC01612 }}</h1>

        <div>{{ Resources.BLACKLISTED_PASSWORD46582 }}: {{ numPasswords }}</div>
        <row>
            <div class="q-button-container">
                <input type="file" id="blacklistFile" @change="importB" accept=".txt" style="position:absolute;height: 0;width: 0;" />
                <button class="q-btn q-btn--primary" @click="clickImport">{{ Resources.IMPORTAR64751 }}</button>
                <button class="q-btn q-btn--secondary" @click="exportB">{{ Resources.EXPORTAR35632 }}</button>
            </div>
        </row>
        <div>{{ Resources.DELETE_ALL_BLACKLIST01597 }}</div>
        <row>
            <button class="q-btn b-icon-text--danger" @click="deleteAll">
                <span class="q-btn__content">
                    <i class="glyphicons glyphicons-delete"></i>
                    {{ Resources.APAGAR04097 }}
                </span>
            </button>
        </row>
        <row>
            <password-input v-model="password" class="control-row-group" :label="Resources.PASSWORD09467" />
            <div class="control-row-group q-button-container">
                <button class="q-btn q-btn--primary" @click="passCheck">{{ Resources.VALIDACAO46021 }}</button>
                <button class="q-btn q-btn--secondary" @click="passAdd">{{ Resources.ADICIONAR14072 }}</button>
            </div>
        </row>
    </div>
</template>

<script>
  // @ is an alias to /src
  import { reusableMixin } from '@/mixins/mainMixin';
  import { QUtils } from '@/utils/mainUtils';
  import bootbox from 'bootbox';

  export default {
    name: 'manage-blacklist',
    components: {  },
    props: {
    },
    mixins: [reusableMixin],
    data: function () {
        return {
            numPasswords: 0,
            password: ''
        }
    },
    methods: {
        clickImport() {
            const elem = document.getElementById('blacklistFile');
            elem.click();
        },

        async importB(e) {
            
            let selection = e.target.files || e.dataTransfer.files;
            if (!selection.length)
                return;

            const formData = new FormData();
            const file = selection[0];
            formData.append("file", file);

            const uri = QUtils.apiActionURL('Config', 'BlacklistUpload');
            const response = await fetch(uri, {
                method: "POST",
                body: formData,
            });

            if(response.ok)
            {
                const data = await response.json();
                if (data.Success) {
                    bootbox.alert(this.Resources.ALTERACOES_EFETUADAS10166);
                    this.numPasswords = data.numPasswords;
                } else {
                    bootbox.alert(data.Message);
                }                
            }
        },
        exportB() {
            var downloadUrl = QUtils.apiActionURL('Config', 'BlacklistDownload');
            window.open(downloadUrl, "_self")
        },
        passCheck() {
            const params = {
                password: this.password
            };
            const vm = this;
            QUtils.postData('Config', 'BlacklistPasswordCheck', params, null, function (data) {
                if (data.Success) {
                    if(data.found) {
                        bootbox.alert(vm.Resources.PASSWORD_VULNERAVEL_00083);
                    } else {
                        bootbox.alert('ok');
                    }
                } else {
                    bootbox.alert(data.Message);
                }
            });
        },
        passAdd() {
            const vm = this;
            const params = {
                password: this.password
            };
            QUtils.postData('Config', 'BlacklistPasswordAdd', params, null, function (data) {
                if (data.Success) {
                    bootbox.alert(vm.Resources.ALTERACOES_EFETUADAS10166);
                    vm.numPasswords = data.numPasswords;
                } else {
                    bootbox.alert(data.Message);
                }
            });
        },
        deleteAll() {
            const vm = this;
            QUtils.postData('Config', 'BlacklistPasswordClear', {}, null, function (data) {
                if (data.Success) {
                    bootbox.alert(vm.Resources.ALTERACOES_EFETUADAS10166);
                    vm.numPasswords = data.numPasswords;
                } else {
                    bootbox.alert(data.Message);
                }
            });
        }
    },
    created() {
        const vm = this;
        const url = QUtils.apiActionURL('Config', 'ManagePasswordBlacklist');
        QUtils.FetchData(url).done(function (data) {
            vm.numPasswords = data.numPasswords;
        });
    }
  };
</script>
