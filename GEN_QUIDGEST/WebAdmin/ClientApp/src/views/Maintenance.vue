<template>
	<div id="maintenance_container">
		<div class="q-stack--column">
			<h1 class="f-header__title">
				{{ Resources.MANUTENCAO_DA_BASE_D10092 }}
			</h1>
			</div>
		<hr>
		<div>
			<q-button
				b-style="primary"
				class="ml-auto"
				:label="maintenanceBtnText"
				@click="ScheduleMaintenance" />
		</div>
		<div>
			<QTabContainer
				v-bind="tabGroup"
				@tab-changed="changeTab('tabGroup', 'selectedTab', $event)">
				<template #tab-panel>
					<template
						v-for="tab in tabGroup.tabsList"
						:key="tab.id">
							<div v-if="tabGroup.selectedTab === tab.id" class="tab-pane c-tab__item-content" :id="tab.componentId">
								<component :is="tab.componentId"></component>
							</div>
					</template>
				</template>
			</QTabContainer>
		</div>
		<div class="d-none">
			<datetime-picker v-model="scheduleDT" ref="scheduleDT" v-if="showScheduleDT"></datetime-picker>
		</div>
		<br />
	</div>
</template>

<script>
	// @ is an alias to /src
	import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';
	import moment from 'moment';
	import bootbox from 'bootbox';
	import maintenance_index from './Maintenance/Index.vue';
	import maintenance_backup from './Maintenance/Backup.vue';
	import maintenance_security from './Maintenance/Security.vue';
	import maintenance_indexes from './Maintenance/Indexes.vue';
	import maintenance_data_quality from './Maintenance/DataQuality.vue';
	import maintenance_change_year from './Maintenance/ChangeYear.vue';
	//import schedule_maintenance from './Maintenance/ScheduleMaintenance.vue';

	export default {
		name: 'maintenance',
		components: {
			maintenance_index,
			maintenance_backup,
			maintenance_security,
			maintenance_indexes,
			maintenance_data_quality,
			maintenance_change_year,
			//schedule_maintenance,
		},
		mixins: [reusableMixin],
		data() {
			var vm = this
			return {
				Model: {},
				showScheduleDT: true,
				scheduleDT: moment(),
				CurentMaintenance: {},
				tabGroup: {
					selectedTab: 'index-tab',
					alignTabs: 'left',
					iconAlignment: 'left',
					isVisible: true,
					tabsList: [
						{
							id: 'index-tab',
							componentId: 'maintenance_index',
							name: 'index',
							label: vm.$t('MANUTENCAO49776'),
							disabled: false,
							isVisible: true
						},
						{
							id: 'backup-tab',
							componentId: 'maintenance_backup',
							name: 'backup',
							label: vm.$t('BACKUP51008'), 
							disabled: false,
							isVisible: true
						},
						{
							id: 'security-tab',
							componentId: 'maintenance_security',
							name: 'security',
							label: vm.$t('SEGURANCA53664'),
							disabled: false,
							isVisible: true
						},
						{
							id: 'indexes-tab',
							componentId: 'maintenance_indexes',
							name: 'indexes',
							label: vm.$t('INDICES58021'),
							disabled: false,
							isVisible: true
						},
						{
							id: 'data_quality-tab',
							componentId: 'maintenance_data_quality',
							name: 'data_quality',
							label: vm.$t('QUALIDADE_DE_DADOS10588'),
							disabled: false,
							isVisible: true
						},
						{
							id: 'change_year-tab',
							componentId: 'maintenance_change_year',
							name: 'change_year',
							label: vm.$t('MUDANCA_DE_ANO09709'),
							disabled: false,
							isVisible: true
						},
																																																					]
				}
			};
		},
		computed: {
			maintenanceBtnText() {
				var vm = this;
				return vm.CurentMaintenance.IsActive ? vm.Resources.DESACTIVAR_MANUTENCA45568 :
					(vm.CurentMaintenance.IsScheduled ? vm.Resources.MUDAR_AGENDAMENTO_DE08195 : vm.Resources.AGENDAR_MANUTENCAO19112);
			}
		},
		methods: {
			getTab(tab, selectedTab) {
				return _find(this[tab]['tabsList'], (x) => x.id === selectedTab)
			},

			changeTab(tab, tabProp, selectedTab) {
				this[tab][tabProp] = selectedTab
			},

			fetchData() {
				var vm = this;
				QUtils.log("Fetch data - DbAdmin", QUtils.apiActionURL('DbAdmin', 'Index'));
				QUtils.FetchData(QUtils.apiActionURL('DbAdmin', 'Index')).done(function (data) {
					QUtils.log("Fetch data - OK (DbAdmin)", data);
					$.each(data.CurentMaintenance, function (propName, value) { vm.CurentMaintenance[propName] = value; });
					if(data.redirect) {
						vm.$router.replace({ name: data.redirect, params: { culture: vm.currentLang, system: vm.currentYear } });
					}
				});
			},
			ScheduleMaintenance() {
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
		created() {
			// Ler dados
			this.fetchData();
		},
		mounted() {
			var vm = this;
			vm.observer = new MutationObserver(mutations => {
				for (const m of mutations) {
					const newValue = m.target.getAttribute(m.attributeName);
					vm.$nextTick(() => {
						if (newValue && newValue.indexOf('active') > -1) {
							vm.activeTab = m.target.id;
						}
					});
				}
			});

			// Asegurarse de que las refs están disponibles después de la renderización
			vm.$nextTick(() => {
				Object.keys(vm.$refs).forEach(ref => {
					// Evitar refs que no corresponden a elementos del DOM reales
					if (ref === "scheduleDT") {
						return;  // Omitir "scheduleDT" ya que no es un Nodo DOM válido
					}

					let element = vm.$refs[ref];

					// Si la ref es un componente Vue, usa su elemento raíz
					if (element && element.$el) {
						element = element.$el;
					}

					// Comprobar si el elemento es un Nodo DOM
					if (element && element.nodeType === 1) {
						vm.observer.observe(element, {
							attributes: true,
							attributeFilter: ['class'],
						})
					}
				});
			});
		},
		beforeUnmount() {
			this.observer.disconnect();
		}
	};
</script>
