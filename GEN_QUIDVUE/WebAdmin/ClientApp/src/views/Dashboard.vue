<template>
	<div id="dashboard_container">
		<div class="q-stack--column">
			<h1 class="f-header__title">
				{{ Resources.DASHBOARD51597 }}
			</h1>
		</div>
		<hr />
		<div
			v-if="!loaded"
			class="card text-center">
			<div class="card-body">
				<q-spinner-loader id="tab-loader" />
			</div>
			<h4>
				{{ Resources.A_CARREGAR___34906 }}
			</h4>
		</div>
		<div v-else>
			<!-- Errors banner -->
			<div v-if="Model.ResultErrors" class="alert alert--danger">
				<h4>{{ Resources.ERRO_35877 }}</h4>
				<p><span v-html="Model.ResultErrors"></span></p>
				<q-button
					v-if="showDBButton()"
					:label="Resources.MANUTENCAO_DA_BASE_D10092"
					@click.stop="navigateTo($event, 'maintenance')" />
			</div>
			<br v-if="Model.ResultErrors">
			<!-- Maintenance banner -->
			<div v-if="CurentMaintenance.IsActive || CurentMaintenance.IsScheduled" class="alert alert--info">
				<h4>{{ Resources.INFORMACAO46082 }}</h4>
				<div>
					<span class="mdi mdi-alert" />
					<span>
						{{ maintenanceText }}
					</span>
				</div>
				<q-button
					:label="maintenanceBtnText"
					@click.stop="navigateTo($event, 'maintenance', false, 'schedule_maintenance-tab')" />
			</div>
			<br v-if="CurentMaintenance.IsActive || CurentMaintenance.IsScheduled" >
			<!-- Is Beta Test -->
			<div v-if="Model.IsBetaTestig" class="alert alert--warning">
				<p />
				<p><b>
					{{ Resources.AMBIENTE_DE_QUALIDAD42119 }}
				</b></p>
			</div>

			<!-- INFORMATION -->
			<q-card
				class="q-card--admin-default"
				:title="Resources.SOBRE44896"
				width="block">
				<div class="container-fluid">
					<dl class="row">
						<dt>{{ Resources.SISTEMA05814 }}</dt>
						<dd>GQT</dd>
						<dt>{{ Resources.ACRONIMO12609 }}</dt>
						<dd>QUIDVUE</dd>
						<dt>{{ Resources.CLIENTE40500 }}</dt>
						<dd>Quidgest - Vue.js</dd>
					</dl>
					<dl class="row">
						<dt>{{ Resources.VERSAO_DE_SISTEMA07287 }}</dt>
						<dd>2890</dd>
						<dt>{{ Resources.VERSAO_DE_BASE_DE_DA46937 }}</dt>
						<dd>{{ Model.VersionDbGen }}</dd>
						<dt>{{ Resources.APP_MIGRATION_VERSIO41495 }}</dt>
						<dd>2</dd>
						<dt>{{ Resources.VERSAO_DOS_INDICES49454 }}</dt>
						<dd>{{ Model.VersionIdxDbGen }}</dd>
						<dt>{{ Resources.VERSAO_DE_GENIO44840 }}</dt>
						<dd>361.29</dd>
						<dt>{{ Resources.GERADO_EM27272 }}</dt>
						<dd>01/24/2025</dd>
					</dl>
					<dl class="row">
						<span class="app-brand">
							<img src="@/assets/img/f-login__brand.png">
						</span>
					</dl> 
				</div>
			</q-card>
			<br />
			<q-card
				class="q-card--admin-default"
				:title="Resources.AMBIENTE12083"
				width="block">
				<dl class="wa-environment">
					<dt>{{ Resources.SERVIDOR_DE_SGBD19838 }}</dt>
					<dd>{{ Model.SGBDServer }}</dd>
					<dt>{{ Resources.SGBD26061 }}</dt>
					<dd>{{ Model.TpSGBD }}</dd>
					<dt>{{ Resources.VERSAO_DO_SGBD43730 }}</dt>
					<dd>{{ Model.SGBDVersion }}
						<span
							v-if="Model.HasSGBDVersion"
							style="color:red;">&nbsp;
							<i class="glyphicons glyphicons-exclamation-sign" aria-hidden="true"></i>
						</span>
					</dd>
					<dt>{{ Resources.BASE_DE_DADOS58234 }}</dt>
					<dd>{{ Model.DBSchema }}</dd>
					<dt>{{ Resources.TAMANHO_DA_BD56664 }}</dt>
					<dd>{{ Model.DBSize }} MB</dd>
					<dt class="version">{{ Resources.VERSAO_DA_BD12683 }}</dt>
					<dd class="version">{{ Model.VersionDb }}
						<span class="icon" v-if="Model.HasDiffIdxVersion">
							&nbsp;
							<span class="mdi mdi-alert-circle"></span>
						</span>
					</dd>
					<dt>{{ Resources.COMPUTADOR39938 }}</dt>
					<dd>{{ Model.PCDesc }}</dd>
					<dt>{{ Resources.SISTEMA_OPERATIVO30480 }}</dt>
					<dd>{{ Model.SODesc }}</dd>
					<dt>{{ Resources.PROCESSADOR36325 }}</dt>
					<dd>{{ Model.HardwProcDesc }}</dd>
					<dt>{{ Resources.MEMORIA09056 }}</dt>
					<dd>{{ Model.HardwMemDesc }}</dd>
					<dt>{{ Resources.DRIVES34119 }}</dt>
					<dd>
						<span v-html="Model.HardwDrivDesc"></span>
					</dd>
				</dl>
			</q-card>
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

	data() {
		var vm = this;
		return {
			loaded: false,
			Model: {},
			modules: [],
			CurentMaintenance: {},
			style: {
				dtClass: 'col-sm-2 textRight',
				ddClass: 'col-sm-10'
			},
			UsersCount: 0,
			queryParams: {
				sort: [],
				filters: [],
				global_search: "",
				per_page: 10,
				page: 1,
				component: "user",
			},
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
		maintenanceBtnText() {
			var vm = this;
			return vm.CurentMaintenance.IsActive 
				? vm.Resources.DESACTIVAR_MANUTENCA45568 
				: vm.Resources.MUDAR_AGENDAMENTO_DE08195;
		},

		maintenanceText() {
			var vm = this;
			return vm.CurentMaintenance.IsActive 
				? vm.Resources.O_SISTEMA_ENCONTRA_S37912 
				: vm.Resources.O_SISTEMA_IRA_ENTRAR46754.replace('{0}', vm.formatDate(vm.CurentMaintenance.Schedule));
		},
	},

	methods: {
		fetchData() {
			var vm = this;
			QUtils.log("Fetch data - Dashboard");
			QUtils.FetchData(QUtils.apiActionURL('Dashboard', 'Index')).done(function (data) {
				QUtils.log("Fetch data - OK (Dashboard)", data);
				$.each(data.model, function (propName, value) { vm.Model[propName] = value; });
				if (!vm.Model.HasConfig) {
					vm.navigateTo(event, 'no_configuration', vm.hasSubmenu);
				}
				$.each(data.CurentMaintenance, function (propName, value) { vm.CurentMaintenance[propName] = value; });
				QUtils.FetchData(QUtils.apiActionURL('Users', 'GetUserList', vm.queryParams)).done(function (data) {
					vm.UsersCount = data.recordsTotal;
					vm.loaded = true;
				});
			});
		},
		showDBButton() {
			return (this.Model.HasDiffVersion || this.Model.VersionDb != -1) && this.Model.HasValidConfig
		}
	},

	created() {
		this.modules = [];
		this.modules.push({
			Codiprog: 'TBS',
			Prog: 'Base tables',
			Platafor: 'VUE',
			Vate: '01/01/0001'
		});
		this.modules.push({
			Codiprog: 'WMS',
			Prog: 'Warehouse Management System',
			Platafor: 'VUE',
			Vate: '01/01/0001'
		});
		this.modules.push({
			Codiprog: 'IMO',
			Prog: 'Real estate',
			Platafor: 'VUE',
			Vate: '01/01/0001'
		});
		this.modules.push({
			Codiprog: 'TRN',
			Prog: 'Training Exercises',
			Platafor: 'VUE',
			Vate: '01/01/0001'
		});
		this.modules.push({
			Codiprog: 'STY',
			Prog: 'Style',
			Platafor: 'VUE',
			Vate: '01/01/0001'
		});
		this.modules.push({
			Codiprog: 'PTN',
			Prog: 'Patterns',
			Platafor: 'VUE',
			Vate: '01/01/0001'
		});
		this.modules.push({
			Codiprog: 'REG',
			Prog: 'Registration',
			Platafor: 'VUE',
			Vate: '01/01/0001'
		});
		this.modules.push({
			Codiprog: 'GQT',
			Prog: 'Genio Quality Tests',
			Platafor: 'VUE',
			Vate: '01/01/0001'
		});
		this.modules.push({
			Codiprog: 'IMO',
			Prog: 'Real estate',
			Platafor: 'VUE',
			Vate: '01/01/0001'
		});
		this.modules.push({
			Codiprog: 'WMS',
			Prog: 'Warehouse Management System',
			Platafor: 'VUE',
			Vate: '01/01/0001'
		});
		this.modules.push({
			Codiprog: 'TBS',
			Prog: 'Base tables',
			Platafor: 'VUE',
			Vate: '01/01/0001'
		});
		this.modules.push({
			Codiprog: 'REG',
			Prog: 'Registration',
			Platafor: 'VUE',
			Vate: '01/01/0001'
		});
		this.modules.push({
			Codiprog: 'STY',
			Prog: 'Style',
			Platafor: 'VUE',
			Vate: '01/01/0001'
		});
		this.modules.push({
			Codiprog: 'TRN',
			Prog: 'Training Exercises',
			Platafor: 'VUE',
			Vate: '01/01/0001'
		});
		this.modules.push({
			Codiprog: 'GQT',
			Prog: 'Genio Quality Tests',
			Platafor: 'VUE',
			Vate: '01/01/0001'
		});
		this.modules.push({
			Codiprog: 'PTN',
			Prog: 'Patterns',
			Platafor: 'VUE',
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
