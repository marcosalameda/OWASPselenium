<template>
	<div id="system_setup_container">
		<div class="q-stack--column">
			<h1 class="f-header__title">
				{{ Resources.CONFIGURACAO_DO_SIST39343 }}
			</h1>
		</div>
		<hr />

		<QAlert
			v-if="alert.isVisible"
            :type="alert.alertType"
            :text="alert.message"
            :icon="alert.icon"
			:title="Resources.ESTADO_DA_OPERACAO38065"
            :dismissTime="5"
            @message-dismissed="handleAlertDismissed" />

		<div>
			<QTabContainer
				v-bind="tabGroup"
				@tab-changed="changeTab('tabGroup', 'selectedTab', $event)">
				<template #tab-panel>
					<template
						v-for="tab in tabGroup.tabsList"
						:key="tab.id">
							<div v-if="tabGroup.selectedTab === tab.id" class="tab-pane c-tab__item-content" :id="tab.componentId">
								<component :is="tab.componentId" v-if="tab.props.model"  v-bind="tab.props" v-on="tab.events || {}"></component>
							</div>
					</template>
				</template>
			</QTabContainer>
		</div>
	</div>
</template>

<script>
  // @ is an alias to /src
	import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';
	import { reactive, computed } from 'vue';
	import database from './System_setup/Database.vue';
	import audit from './System_setup/Audit.vue';
	import advanced from './System_setup/Advanced.vue';
	import display from './System_setup/Display.vue';
	import reporting from './System_setup/Reporting.vue';
	import messaging from './System_setup/Messaging.vue';
	import elasticsearch from './System_setup/ElasticSearch.vue';
	import scheduler from './System_setup/Scheduler.vue';
	import QAlert from '@/components/QAlert.vue';

	export default {
		name: 'system_setup',
		mixins: [reusableMixin],
		components: { QAlert, database, audit, display, reporting, advanced, elasticsearch, messaging, scheduler 		},

		props: {
			/**
			 * An object containing current Tabs that can trigger different actions within the configuration modal.
			 * These could include showing or hiding the modal, or navigating between different sections of the configuration.
			 */
			currentTab: {
				type: Object,
				default: () => ({})
			},
		},
		data() {
			var vm = this
			return {
				Model: {},
				alert: {
					isVisible: false,
					alertType: 'info',
					message: ''
				},

				tabGroup: {
					selectedTab: 'database-tab',
					alignTabs: 'left',
					iconAlignment: 'left',
					isVisible: true,
					tabsList: [
						{
							id: 'database-tab',
							componentId: 'database',
							name: 'database',
							label: vm.$t('BASE_DE_DADOS58234'),
							disabled: false,
							isVisible: true,
							props: { model: computed(() => vm.Model) },
							events: { 'connection-tested': vm.handleConnectionTested, 'updateModal': vm.setModel, 'alertClass': vm.updateAlert }
						},
						{
							id: 'display-tab',
							componentId: 'display',
							name: 'display',
							label: vm.$t('DEFINICOES_DO_ECRA09420'), 
							disabled: false,
							isVisible: true,
							props: { model: computed(() => vm.Model), SelectLists: computed(() => vm.Model?.SelectLists) },
							events: { 'updateModal': vm.fetchData, 'alertClass': vm.updateAlert }
						},
						{
							id: 'advanced-tab',
							componentId: 'advanced',
							name: 'advanced',
							label: vm.$t('PROPRIEDADES_AVANCAD23972'),
							disabled: false,
							isVisible: true,
							props: { model: computed(() => vm.Model), SelectLists: computed(() => vm.Model?.SelectLists) },
							events: { 'updateModal': vm.fetchData, 'alertClass': vm.updateAlert }
						},
						{
							id: 'elasticsearch-tab',
							componentId: 'elasticsearch',
							name: 'elasticsearch',
							label: vm.$t('ELASTICSEARCH49143'),
							disabled: false,
							isVisible: true,
							props: { model: computed(() => vm.Model), Cores: computed(() => vm.Cores), SelectLists: computed(() => vm.Model?.SelectLists) },
							events: { 'updateModal': vm.fetchData }
						},
						{
							id: 'reporting-tab',
							componentId: 'reporting',
							name: 'reporting',
							label: vm.$t('RELATORIOS37339'),
							disabled: false,
							isVisible: true,
							props: { model: computed(() => vm.Model) },
							events: { 'updateModal': vm.fetchData }
						},
						{
							id: 'scheduler-tab',
							componentId: 'scheduler',
							name: 'scheduler',
							label: vm.$t('AGENDADOR40611'),
							disabled: false,
							isVisible: true,
							props: { model: computed(() => vm.Model?.Scheduler),  TaskList: computed(() => vm.Model?.SelectLists.SchedulerTaskList) },
							events: { 'updateModal': vm.fetchData }
						},
						{
							id: 'messaging-tab',
							componentId: 'messaging',
							name: 'messaging',
							label: vm.$t('MENSAGENS53948'),
							disabled: false,
							isVisible: true,
							props: { model: computed(() => vm.Model?.Messaging),  Metadata: computed(() => vm.Model?.MessagingMetadata) },
							events: { 'updateModal': vm.fetchData }
						},
						{
							id: 'audit-tab',
							componentId: 'audit',
							name: 'audit',
							label: vm.$t('AUDITORIA29703'),
							disabled: false,
							isVisible: true,
							props: { model: computed(() => vm.Model) },
							events: { 'updateModal': vm.setModel }
						},
					]
				}
			};
		},
		computed: {
			Paths() {
				var vm = this;
				if ($.isEmptyObject(vm.currentApp) || $.isEmptyObject(vm.Model.Paths))
				return null;
				vm.Model.Paths[vm.currentApp].app = vm.currentApp;
				return vm.Model.Paths[vm.currentApp] || null;
			},
			Cores() {
				var vm = this;
				return !$.isEmptyObject(vm.currentApp) && !$.isEmptyObject(vm.Model.Cores) ? (vm.Model.Cores[vm.currentApp] || null) : null;
			}
		},
		methods: {
			fetchData() {
				var vm = this;
				QUtils.log("Fetch data - Config", QUtils.apiActionURL('Config', 'Index'));
				QUtils.FetchData(QUtils.apiActionURL('Config', 'Index')).done(function (data) {
					QUtils.log("Fetch data - OK (Config)", data);
					if(data.redirect) {
						vm.$router.replace({ name: data.redirect, params: { culture: vm.currentLang, system: vm.currentYear } });
					}
					else if (data.reload) {
						vm.currentYear = data.system;
						vm.fetchData();
					}
					else {
						vm.setModel(data);
					}
				});
			},
			setModel(data) {
				var vm = this;
				$.extend(vm.Model, data);
				// Select the first exists application
				if ($.isEmptyObject(vm.currentApp) && !$.isEmptyObject(vm.Model.Applications)) {
					vm.currentApp = vm.Model.Applications[0].Id;
				}
				// Focus on errors div
				if (!$.isEmptyObject(vm.Model.ResultMsg)) {
					window.scrollTo(0,0);
					this.updateAlert(data);
				}
			},
			reloadMQueues() {
				var vm = this;
				QUtils.FetchData(QUtils.apiActionURL('Config', 'ReloadMQueues')).done(function (data) {
					if (data.Success) {
						$.each(data.MQueues, function (propName, value) {
							if ($.isArray(vm.Model.MQueues[propName])) { vm.Model.MQueues[propName].splice(0); }
							$.extend(vm.Model.MQueues[propName], value);
						});
					}
				});
			},
			updateUsers(eventData) {
				if ($.isEmptyObject(this.Model.Security[eventData.currentApp].Users))
					$.extend(this.Model.Security[eventData.currentApp], reactive({ Users: [] }));
				else
					this.Model.Security[eventData.currentApp].Users.splice(0);

				$.extend(this.Model.Security[eventData.currentApp].Users, eventData.users);
			},

			getTab(tab, selectedTab) {
				return _find(this[tab]['tabsList'], (x) => x.id === selectedTab)
			},

			changeTab(tab, tabProp, selectedTab) {
				this[tab][tabProp] = selectedTab
			},
			updateAlert(data) {
				this.Model.ResultMsg = data.ResultMsg;
				if (data.AlertType) {
				this.setAlert(data.AlertType, data.ResultMsg);
				} else {
					this.setAlert('info', data.ResultMsg);
				}
			},
			handleConnectionTested(result) {
				if (result.Success) {
					this.setAlert('success', 'Connection success');
				} else {
					this.setAlert('danger', result.message || 'Connection failed');
				}
			},
			setAlert(type, message) {
				this.alert.isVisible = true;
				this.alert.alertType = type;
				this.alert.message = message;
			},
			handleAlertDismissed() {
				this.alert.isVisible = false;
			}
		},
		mounted() {
			var vm = this;
			vm.observer = new MutationObserver(mutations => {
				for (const m of mutations) {
				const newValue = m.target.getAttribute(m.attributeName);
				vm.$nextTick(() => {
					if (newValue.indexOf('active')) {
					vm.selectedTab = m.target.id;
					}
				});
				}
			});
		},
		created() {
			// Ler dados
			this.fetchData();
			this.$eventHub.on('alertClass', this.updateAlert);
		},
		watch: {
			// call again the method if the route changes
			'$route': 'fetchData',
			'currentApp': 'fetchData',
			currentTab: {
				handler(newValue) {
					if (newValue.selectedTab) {
						this.changeTab('tabGroup', 'selectedTab', newValue.selectedTab)
					}
				},
				deep: true
			}
			
		}
	};
</script>
