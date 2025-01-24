<template>
	<div id="maintenance_schedule_container">
		<q-card
			class="q-card--admin-default"
			:title="Resources.AGENDAR_A_MANUTENCAO08879"
			width="block">
			<q-row-container>
				<datetime-picker v-model="scheduleDT" ref="scheduleDT" v-if="showScheduleDT"></datetime-picker>
				<span class="q-help__subtext">
					<span class="mdi mdi-information-outline"></span>
					{{ Resources.DEIXAR_VAZIO_PARA_LI30681 }}
				</span>

				<row class="footer-btn">
					<q-button
						b-style="primary"
						:label="Resources.CONFIRMAR09808"
						@click="ScheduleMaintenance" />
				</row>
			</q-row-container>

		</q-card>
	</div>
</template>

<script>
	import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';
	import moment from 'moment';

	export default {
		name: 'schedule_maintenance',

		mixins: [reusableMixin],

		data() {
			return {
				showScheduleDT: true,
				scheduleDT: moment(),
				CurentMaintenance: {},
			}
		},

		computed: {
			maintenanceTitleText() {
				var vm = this;
				return vm.CurentMaintenance.IsActive ? vm.Resources.DESACTIVAR_MANUTENCA45568 :
					(vm.CurentMaintenance.IsScheduled ? vm.Resources.MUDAR_AGENDAMENTO_DE08195 : vm.Resources.AGENDAR_MANUTENCAO19112);
			}
		},

		methods: {
			ScheduleMaintenance() {
				var vm = this;
				if (!vm.scheduleDT || vm.scheduleDT === '' || vm.scheduleDT === null || vm.scheduleDT === undefined) {
					QUtils.postData('Dashboard', 'DisableMaintenance', null, null, function (data) {
						QUtils.log("DisableMaintenance - Response", data);
						$.each(data.CurentMaintenance, function (propName, value) { vm.CurentMaintenance[propName] = value; });
						vm.$emit('alertClass', { ResultMsg: vm.Resources.MANUNTENCAO_DESATIVA30520, AlertType: 'success' });
					});
				}
				else {
					QUtils.postData('Dashboard', 'ScheduleMaintenance', { date: vm.scheduleDT }, null, function (data) {
						QUtils.log("ScheduleMaintenance - Response", data);
						$.each(data.CurentMaintenance, function (propName, value) { vm.CurentMaintenance[propName] = value; });
						vm.$emit('alertClass', { ResultMsg: vm.Resources.MANUNENTANCAO_CONFIG28505, AlertType: 'success' });
					});
				}
			}
		}
	}
</script>
