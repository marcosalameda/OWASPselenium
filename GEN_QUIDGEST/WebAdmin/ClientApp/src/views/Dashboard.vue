<template>
  <div id="dashboard_container">
      <h1 class="f-header__title">
          <q-icon icon="dashboard" />{{ Resources.DASHBOARD51597 }} | <b>GQT</b>
          <q-button v-if="Model.HasConfig"
            b-style="primary"
            class="ml-auto"
            :label="maintenanceBtnText"
            @click="ScheduleMaintenance" />
      </h1>
      <br />
      <hr />
    <div v-if="!Model.HasConfig" class="card feature-box">
      <div class="card-body" @click.stop="createNewConfig">
          <span class="feature-icon glyphicons glyphicons-file-plus"></span>
          <h4>{{ Resources.CREATE_NEW_CONFIGURA21344 }}</h4>
          <p>{{ Resources.NO_CONFIGURATION_FIL40493 }}</p>                
      </div>
    </div>
    <div v-if="Model.HasConfig">
      <div class="row">
        <div class="col-sm-3">
          <div class="card feature-box">
            <div class="card-body" @click.stop="navigateTo('system_setup')">
              <span class="feature-icon glyphicons glyphicons-wrench"></span>
              <h4>{{ Resources.CONFIGURACAO_DO_SIST39343 }}</h4>
            </div>
          </div>
        </div>
        <div class="col-sm-3">
          <div class="card feature-box">
            <div class="card-body" @click.stop="navigateTo('maintenance')">
              <span class="feature-icon glyphicons glyphicons-database"></span>
              <h4>{{ Resources.MANUTENCAO_DA_BASE_D10092 }}</h4>
            </div>
          </div>
        </div>
        <div class="col-sm-3">
          <div class="card feature-box">
            <div class="card-body" @click.stop="navigateTo('users')">
              <span class="feature-icon glyphicons glyphicons-group"></span>
              <h4>{{ Resources.GESTAO_DE_UTILIZADOR20428 }}</h4>
            </div>
          </div>
        </div>
        <div class="col-sm-3">
            <div class="card feature-box">
                <div class="card-body" @click.stop="navigateTo('email')">
                    <span class="feature-icon glyphicons glyphicons-envelope"></span>
                    <h4>{{ Resources.SERVIDOR_DE_EMAIL19063 }}</h4>
                </div>
            </div>
        </div>
      </div>
      <div class="row">
        <div class="col-sm-3">
          <div class="card feature-box">
            <div class="card-body" @click.stop="navigateTo('system_reports')">
              <span class="feature-icon glyphicons glyphicons-warning-sign"></span>
              <h4>{{ Resources.RELATORIO_DO_SISTEMA49744 }}</h4>
            </div>
          </div>
        </div>
        <div class="col-sm-3">
          <div class="card feature-box">
            <div class="card-body" @click.stop="navigateTo('report_management')">
              <span class="feature-icon glyphicons glyphicons-file"></span>
              <h4>{{ Resources.GESTAO_DE_RELATORIOS37970 }}</h4>
            </div>
          </div>
        </div>
        <div class="col-sm-3">
          <div class="card feature-box">
            <div class="card-body" @click.stop="navigateTo('notifications')">
              <span class="feature-icon glyphicons glyphicons-pending-notifications"></span>
              <h4>{{ Resources.GESTAO_DE_NOTIFICACO14803 }}</h4>
            </div>
          </div>
        </div>
      </div>
    </div>
    <!-- INFORMATION -->
    <div v-if="Model.ResultErrors" class="alert alert-danger">
      <p><b>{{ Resources.ERROS_DETECTADOS17821 }}</b></p>
      <p><span v-html="Model.ResultErrors"></span></p>
    </div>
	<div v-if="Model.IsBetaTestig" class="alert alert-warning">
	  <p></p>
	  <p><b>{{ Resources.AMBIENTE_DE_QUALIDAD42119 }}</b></p>
    </div>

    <row>
      <div class="card border-primary">
        <div class="card-header bg-primary"><div class="c-card__title">{{ Resources.SOBRE44896 }}</div></div>
        <div class="card-body">
          <div class="container-fluid">
            <dl class="row">
              <dt v-bind:class="style.dtClass">{{ Resources.SISTEMA05814 }}</dt>
              <dd v-bind:class="style.ddClass">GQT</dd>
              <dt v-bind:class="style.dtClass">{{ Resources.VERSAO_DE_SISTEMA07287 }}</dt>
              <dd v-bind:class="style.ddClass">2697</dd>
              <dt v-bind:class="style.dtClass">{{ Resources.VERSAO_DE_BASE_DE_DA46937 }}</dt>
              <dd v-bind:class="style.ddClass">{{ Model.VersionDbGen }}</dd>
              <dt v-bind:class="style.dtClass">{{ Resources.APP_MIGRATION_VERSIO41495 }}</dt>
              <dd v-bind:class="style.ddClass">0</dd>
              <dt v-bind:class="style.dtClass">{{ Resources.VERSAO_DOS_INDICES49454 }}</dt>
              <dd v-bind:class="style.ddClass">{{ Model.VersionIdxDbGen }}</dd>
              <dt v-bind:class="style.dtClass">{{ Resources.VERSAO_DE_GENIO44840 }}</dt>
              <dd v-bind:class="style.ddClass">345.35</dd>
              <dt v-bind:class="style.dtClass">{{ Resources.GERADO_EM27272 }}</dt>
              <dd v-bind:class="style.ddClass">05/31/2024</dd>
            </dl>
          </div>
        </div>
      </div>
    </row>

    <row>
      <div class="card border-success">
        <div class="card-header bg-success"><div class="c-card__title">{{ Resources.AMBIENTE12083 }}</div></div>
        <div class="card-body">
          <div class="container-fluid">
            <dl class="row">
              <dt v-bind:class="style.dtClass">{{ Resources.SERVIDOR_DE_SGBD19838 }}</dt>
              <dd v-bind:class="style.ddClass">{{ Model.SGBDServer }}</dd>
              <dt v-bind:class="style.dtClass">{{ Resources.SGBD26061 }}</dt>
              <dd v-bind:class="style.ddClass">{{ Model.TpSGBD }}</dd>
              <dt v-bind:class="style.dtClass">{{ Resources.VERSAO_DO_SGBD43730 }}</dt>
              <dd v-bind:class="style.ddClass">{{ Model.SGBDVersion }}<span v-if="Model.HasSGBDVersion" style="color:red;">&nbsp;<i class="glyphicons glyphicons-exclamation-sign" aria-hidden="true"></i></span></dd>
              <dt v-bind:class="style.dtClass">{{ Resources.BASE_DE_DADOS58234 }}</dt>
              <dd v-bind:class="style.ddClass">{{ Model.DBSchema }}</dd>
              <dt v-bind:class="style.dtClass">{{ Resources.TAMANHO_DA_BD56664 }}</dt>
              <dd v-bind:class="style.ddClass">{{ Model.DBSize }} MB</dd>
              <dt v-bind:class="style.dtClass">{{ Resources.VERSAO_DA_BD12683 }}</dt>
              <dd v-bind:class="style.ddClass">{{ Model.VersionDb }}<span v-if="Model.HasDiffIdxVersion" style="color:red;">&nbsp;<i class="glyphicons glyphicons-exclamation-sign" aria-hidden="true"></i></span></dd>
              <hr />
              <dt v-bind:class="style.dtClass">{{ Resources.COMPUTADOR39938 }}</dt>
              <dd v-bind:class="style.ddClass">{{ Model.PCDesc }}</dd>
              <dt v-bind:class="style.dtClass">{{ Resources.SISTEMA_OPERATIVO30480 }}</dt>
              <dd v-bind:class="style.ddClass">{{ Model.SODesc }}</dd>
              <dt v-bind:class="style.dtClass">{{ Resources.PROCESSADOR36325 }}</dt>
              <dd v-bind:class="style.ddClass">{{ Model.HardwProcDesc }}</dd>
              <dt v-bind:class="style.dtClass">{{ Resources.MEMORIA09056 }}</dt>
              <dd v-bind:class="style.ddClass">{{ Model.HardwMemDesc }}</dd>
              <dt v-bind:class="style.dtClass">{{ Resources.DRIVES34119 }}</dt>
              <dd v-bind:class="style.ddClass"><span v-html="Model.HardwDrivDesc"></span></dd>
            </dl>
          </div>
        </div>
      </div>
    </row>

    <row>
      <div class="card border-warning">
        <div class="card-header bg-warning"><div class="c-card__title">{{ Resources.LICENCIAMENTO00852 }}</div></div>
        <div class="card-body">
          <div class="container-fluid">
            <dl class="row">
              <dt v-bind:class="style.dtClass">{{ Resources.SIGLA14738 }}</dt>
              <dd v-bind:class="style.ddClass">QUIDGEST</dd>
              <dt v-bind:class="style.dtClass">{{ Resources.CLIENTE40500 }}</dt>
              <dd v-bind:class="style.ddClass">Quidgest - Management Consultants, S.A.</dd>
            </dl>
            <qtable :rows="tModules.rows"
                    :columns="tModules.columns"
                    :config="tModules.config"
                    :totalRows="tModules.total_rows"></qtable>
          </div>
        </div>
      </div>
    </row>

    <row>
      <div class="card border-info">
        <div class="card-header bg-info"><span class="glyphicons glyphicons-bank" aria-hidden="true"></span>{{ Resources.CONTACTOS35567 }}</div>
        <div class="card-body">
          <address>
            <strong>Quidgest, S.A.</strong>
            <br />Rua Viriato, 7 &#8211; 4&ordm;
            <br />1050-233 Lisboa
            <br /><abbr title="Phone">P:</abbr>(+351) 213 870 563
            <br /><a href="mailto:quidgest@quidgest.com">quidgest@quidgest.com</a>
          </address>
        </div>
      </div>
    </row>

      <div class="d-none">
          <datetime-picker v-model="scheduleDT" ref="scheduleDT" v-if="showScheduleDT"></datetime-picker>
      </div>
  </div>
</template>

<script>
  // @ is an alias to /src
  import { reusableMixin } from '@/mixins/mainMixin';
  import { QUtils } from '@/utils/mainUtils';
  import bootbox from 'bootbox';
  import moment from 'moment';

  export default {
    name: 'dashboard',
    mixins: [reusableMixin],
    data: function () {
      var vm = this;
      return {
        Model: {},
        modules: [],
        CurentMaintenance: {},
        style: {
          dtClass: 'col-sm-2 textRight',
          ddClass: 'col-sm-10'
        },
        showScheduleDT: true,
        scheduleDT: moment(),
        tModules: {
            rows: [],
            total_rows: 0,
            columns: [
            {
                label: () => vm.$t('SIGLA14738'),
                name: "Codiprog",
                sort: true,
                initial_sort: true,
                initial_sort_order: "asc"
            },
            {
                label: () => vm.$t('NOME47814'),
                name: "Prog",
                sort: true
            },
            {
                label: () => vm.$t('PLATAFORMA28085'),
                name: "Platafor",
                sort: true
            },
            {
                label: () => vm.$t('VALIDADE07300'),
                name: "Vate",
                sort: true
            }],
            config: {
                table_title: () => vm.$t('MODULOS17298'),
                pagination: false,
                pagination_info: false,
                global_search: {
                    visibility: false
                }
            }
        }
      };
    },
    computed: {
        maintenanceBtnText: function () {
            var vm = this;
            return vm.CurentMaintenance.IsActive ? vm.Resources.DESACTIVAR_MANUTENCA45568 :
                (vm.CurentMaintenance.IsScheduled ? vm.Resources.MUDAR_AGENDAMENTO_DE08195 : vm.Resources.AGENDAR_MANUTENCAO19112);
        }
    },
    methods: {
      fetchData: function () {
        var vm = this;
        QUtils.log("Fetch data - Dashboard");
        QUtils.FetchData(QUtils.apiActionURL('Dashboard', 'Index')).done(function (data) {
          QUtils.log("Fetch data - OK (Dashboard)", data);
          $.each(data.model, function (propName, value) { vm.Model[propName] = value; });
          $.each(data.CurentMaintenance, function (propName, value) { vm.CurentMaintenance[propName] = value; });
        });
      },
      createNewConfig: function () {
        var vm = this;
        //Call method that creates a configuration file
        QUtils.postData('Dashboard', 'CreateConfiguration', null, null, function (data) {
                  if (data.Success) {
                      bootbox.alert(vm.Resources.NEW_CONFIGURATION_CR61652);
                  }
                  else {
                      bootbox.alert(vm.Resources.THERE_WAS_AN_ERROR_C44163 + "<br>" + data.Message);
                  }
                  vm.fetchData();
        });               
      },
      ScheduleMaintenance: function () {
          var vm = this;
          if (vm.CurentMaintenance.IsActive) {
                QUtils.postData('Dashboard', 'DisableMaintenance', null, null, function (data) {
                    QUtils.log("DisableMaintenance - Response", data);
                    $.each(data.CurentMaintenance, function (propName, value) { vm.CurentMaintenance[propName] = value; });
                });
          }
          else {
              var dialog = bootbox.dialog({
                  size: "small",
                  title: vm.maintenanceBtnText,
                  message: '<div id="xpto"></div><div><small>*' + vm.Resources.DEIXAR_VAZIO_PARA_LI30681 + '<small></div>',
                  buttons: {
                      confirm: {
                        label: vm.Resources.CONFIRMAR09808,
                        className: 'btn-success',
                        callback: function () {
                          QUtils.postData('Dashboard', 'ScheduleMaintenance', { date: vm.scheduleDT }, null, function (data) {
                                QUtils.log("ScheduleMaintenance - Response", data);
                                $.each(data.CurentMaintenance, function (propName, value) { vm.CurentMaintenance[propName] = value; });
                            });
                        }
                      },
                      cancel: {
                          label: vm.Resources.CANCELAR49513,
                          className: 'btn-danger'
                      }
                  },
              });
              dialog.init(function () {
                  vm.scheduleDT = moment().add(5, 'minutes');
                  $('#xpto').append(vm.$refs.scheduleDT.$el);
              });
              dialog.on('hide.bs.modal', function () {
                  vm.showScheduleDT = false;
                  setTimeout(function () { vm.showScheduleDT = true; }, 200);
              });
          }
      }
    },
    created: function () {
      this.modules = [];
      this.modules.push({
        Codiprog: 'GQT',
        Prog: 'Genio Quality Tests',
        Platafor: 'MVC',
        Vate: '01/01/0001'
      });
      this.modules.push({
        Codiprog: 'PTN',
        Prog: 'Patterns',
        Platafor: 'MVC',
        Vate: '01/01/0001'
      });
      this.modules.push({
        Codiprog: 'STY',
        Prog: 'Style',
        Platafor: 'MVC',
        Vate: '01/01/0001'
      });
      this.modules.push({
        Codiprog: 'TBS',
        Prog: 'Base tables',
        Platafor: 'MVC',
        Vate: '12/31/2020'
      });
      this.modules.push({
        Codiprog: 'PTN',
        Prog: 'Genio Patterns',
        Platafor: 'MVC',
        Vate: '01/01/0001'
      });
      this.modules.push({
        Codiprog: 'GQT',
        Prog: 'Genio Quality Tests',
        Platafor: 'MVC',
        Vate: '12/31/2019'
      });
      this.modules.push({
        Codiprog: 'REG',
        Prog: 'Registration',
        Platafor: 'MVC',
        Vate: '01/01/0001'
      });
      this.modules.push({
        Codiprog: 'STY',
        Prog: 'Style',
        Platafor: 'MVC',
        Vate: '01/01/0001'
      });
      this.modules.push({
        Codiprog: 'IMO',
        Prog: 'Real estate',
        Platafor: 'MVC',
        Vate: '01/01/0001'
      });
      this.modules.push({
        Codiprog: 'WMS',
        Prog: 'Warehouse Management System',
        Platafor: 'MVC',
        Vate: '01/01/0001'
      });
      this.modules.push({
        Codiprog: 'STY',
        Prog: 'Style',
        Platafor: 'MVC',
        Vate: '01/01/0001'
      });
      this.modules.push({
        Codiprog: 'PTN',
        Prog: 'Patterns',
        Platafor: 'MVC',
        Vate: '01/01/0001'
      });
      this.modules.push({
        Codiprog: 'GQT',
        Prog: 'Genio Quality Tests',
        Platafor: 'MVC',
        Vate: '01/01/0001'
      });
      this.tModules.rows = this.modules;
      this.tModules.total_rows = this.modules.length;

      // Ler dados
      this.fetchData();
    },
    watch: {
      // call again the method if the route changes
      '$route': 'fetchData'
    }
  };
</script>
