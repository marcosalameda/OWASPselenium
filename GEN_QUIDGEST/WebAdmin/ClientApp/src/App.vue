<template>
    <div id="wrapper" style="height:100%;display: flex; flex-direction: column;">
        <div id="header-container" v-bind:class="{ 'd-none': hideSideBar }">
            <nav class="main-header navbar navbar-expand c-header--sidebar">
                <ul class="navbar-nav c-header__content--sidebar">
                    <li class="nav-item c-header__item--sidebar">
                        <span class="nav-link c-header__link--sidebar" data-widget="pushmenu"><i class="glyphicons glyphicons-menu-hamburger n-sidebar__toggler-icon"></i></span>
                    </li>
                </ul>
                <ul class="navbar-nav ml-auto n-menu__aside">
                    <li class="nav-item dropdown n-menu__aside-item">
                        <select v-if="0" class="form-control" style="float:right; width: 200px;" v-model="currentApp">
                            <option v-for="app in $root.Applications" v-bind:value="app.Id" :key="app.Id">{{ app.Name }}</option>
                        </select>
                    </li>
                    <li class="nav-item dropdown n-menu__aside-item">
                        <template v-if="Years && Years.length > 1">
                            <select-simple v-model="currentYear" :options="Years" :icon="'calendar'" :side="'left'"></select-simple>
                        </template>
                    </li>
                </ul>
            </nav>
            <aside class="main-sidebar sidebar-dark-primary n-menu--sidebar">
                <div class="n-sidebar__brand">
                    <a href="#">
                        <img src="./assets/img/Q_icon.png" alt="Quidgest" class="n-sidebar__img">
                    </a>
                    <span class="brand-text n-sidebar__brand-text">WebAdmin</span>
                </div>
                <div class="sidebar n-sidebar" style="min-height: 607px;">
                    <nav class="mt-2">
                        <div class="n-sidebar__section">
                            <ul class="nav nav-pills nav-sidebar flex-column n-sidebar__nav" data-widget="treeview" role="menu" data-accordion="true">

                                <li class="nav-item n-sidebar__nav-item">
                                    <a class="nav-link n-sidebar__nav-link" @click.stop="navigateTo('dashboard')">
                                        <i class="glyphicons glyphicons-dashboard" aria-hidden="true"></i>
                                        <p>&nbsp;{{ Resources.DASHBOARD51597 }}</p>
                                    </a>
                                </li>

                                <li class="nav-item n-sidebar__nav-item">
                                    <a class="nav-link n-sidebar__nav-link" @click.stop="navigateTo('system_setup')">
                                        <i class="glyphicons glyphicons-wrench" aria-hidden="true"></i>
                                        <p>&nbsp;{{ Resources.CONFIGURACAO_DO_SIST39343 }}</p>
                                    </a>
                                </li>

                                <li class="nav-item n-sidebar__nav-item">
                                    <a class="nav-link n-sidebar__nav-link" @click.stop="navigateTo('maintenance')" style="white-space: nowrap !important;">
                                        <i class="glyphicons glyphicons-database" aria-hidden="true"></i>
                                        <p>&nbsp;{{ Resources.MANUTENCAO_DA_BASE_D10092 }}</p>
                                    </a>
                                </li>

                                <li class="nav-item n-sidebar__nav-item">
                                    <a class="nav-link n-sidebar__nav-link" @click.stop="navigateTo('users')">
                                        <i class="glyphicons glyphicons-group" aria-hidden="true"></i>
                                        <p>&nbsp;{{ Resources.GESTAO_DE_UTILIZADOR20428 }}</p>
                                    </a>
                                </li>
                                <li class="nav-item n-sidebar__nav-item">
                                    <a class="nav-link n-sidebar__nav-link" @click.stop="navigateTo('email')">
                                        <i class="glyphicons glyphicons-envelope" aria-hidden="true"></i>
                                        <p>&nbsp;{{ Resources.SERVIDOR_DE_EMAIL19063 }}</p>
                                    </a>
                                </li>
                                <li class="nav-item n-sidebar__nav-item">
                                    <a class="nav-link n-sidebar__nav-link" @click.stop="navigateTo('system_reports')">
                                        <i class="glyphicons glyphicons-warning-sign" aria-hidden="true"></i>
                                        <p>&nbsp;{{ Resources.RELATORIO_DO_SISTEMA49744 }}</p>
                                    </a>
                                </li>
                                <li class="nav-item n-sidebar__nav-item">
                                    <a class="nav-link n-sidebar__nav-link" @click.stop="navigateTo('report_management')">
                                        <i class="glyphicons glyphicons-file" aria-hidden="true"></i>
                                        <p>&nbsp;{{ Resources.GESTAO_DE_RELATORIOS37970 }}</p>
                                    </a>
                                </li>
                                <li class="nav-item n-sidebar__nav-item">
                                    <a class="nav-link n-sidebar__nav-link" @click.stop="navigateTo('notifications')">
                                        <i class="glyphicons glyphicons-pending-notifications" aria-hidden="true"></i>
                                        <p>&nbsp;{{ Resources.GESTAO_DE_NOTIFICACO14803 }}</p>
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </nav>
                </div>
            </aside>

        </div>

        <div id="content-wrapper" :class="['content-wrapper', hideSideBar ? 'content-wrapper-dashboard' : '']" style="flex-basis: 100%; display: flex; flex-direction: column;">
            <div class="container-fluid" style="flex: 1 1 auto;">
                <router-view></router-view>
            </div>
        </div>
    </div>
</template>

<script>
  import '@/assets/styles/style.scss';

  import '@/utils/globalUtils.js';
  import { reusableMixin } from '@/mixins/mainMixin';
  import { QUtils } from '@/utils/mainUtils';

  export default {
    name: 'app',
    mixins: [reusableMixin],
    data() {
      return {
        Applications: [],
        langs: [
          { Value: 'en-US', Text: 'English' },
        ],
        Years: [],
        DefaultYear: ''
      }
    },
    computed: {
      hideSideBar: function () {
        return this.$route.name == "dashboard" || $.isEmptyObject(this.$route.name);
      }
    },
    methods: {
        setYears: function (years, defaultYear) {
            var vm = this,
                _years = years || [];
            vm.Years = [];
            $.each(_years, function (i, y) {
                vm.Years.push({ Text: y, Value: y});
            });
            vm.DefaultYear = defaultYear;
            if ($.isEmptyObject(vm.currentYear) || !$.isArray(vm.currentYear, _years)) { vm.currentYear = vm.DefaultYear; }
        },
      getYears: function() {
        var vm = this;
        QUtils.FetchData(QUtils.apiActionURL('Main', 'GetYears')).done(function (data) {
            vm.setYears(data.Years, data.DefaultYear);
        });
      },
      setApplications: function(applications) {
        this.$root.Applications = applications;
        if ($.isEmptyObject(this.currentApp) && !$.isEmptyObject(applications)) { this.currentApp = applications[0].Id; }
      },
      getApplications: function() {
        var vm = this;
        QUtils.FetchData(QUtils.apiActionURL('Main', 'GetApplications')).done(function (data) {
          vm.setApplications(data.Applications);
        });
      }
    },
    beforeUnmount() {
        this.$eventHub.off('app_updateYear');
        this.$eventHub.off('SET_SYSTEM');
        this.$eventHub.off('SET_CULTURE');
        this.$eventHub.off('SET_APPLICATIONS');
    },
    created: function () {
      var vm = this;
	  QUtils.FetchData(QUtils.apiActionURL('Main', 'GetGlobalSettingsJson')).done(function (data) {
		  window.QGlobal = data;
          vm.setApplications(data.Applications);
		  vm.setYears(data.Years, data.defaultSystem);
      });
      this.$eventHub.on('app_updateYear', this.getYears);
      this.$eventHub.on('SET_SYSTEM', function (value) { if (vm.currentYear != value) vm.currentYear = value; });
      this.$eventHub.on('SET_CULTURE', function (value) { if (vm.currentLang != value) vm.currentLang = value; });
      this.$eventHub.on('SET_APPLICATIONS', function (value) { vm.setApplications(value); });
    }
  };
</script>

<style scoped>
    .sidebar .glyphicons {
        font-size: 14pt;
        padding-right: 5px;
    }

    .sidebar .nav-item {
        cursor: pointer;
    }
</style>
