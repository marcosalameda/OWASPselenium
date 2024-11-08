<template>
	<div id="system_setup_others_container">
		<row>
			<qtable :rows="tAdvP.rows"
					:columns="tAdvP.columns"
					:config="tAdvP.config"
					:totalRows="tAdvP.total_rows"
					class="q-table--borderless"
					:table_title="Resources.MOTOR_DE_PESQUISA__E50766">
				<template #actions="props">
				<q-button-group borderless>
					<q-button
					:title="Resources.EDITAR11616"
					@click="changeAdvancedProperty(props.row)">
					<q-icon icon="pencil" />
					</q-button>
					<q-button
					:title="Resources.ELIMINAR21155"
					@click="deleteAdvancedProperty(props.row)">
					<q-icon icon="bin" />
					</q-button>
				</q-button-group>
				</template>
				<template #table-footer>
					<tr>
						<td colspan="3">
						<q-button
							:label="Resources.INSERIR43365"
							@click="createAdvancedProperty">
							<q-icon icon="plus-sign" />
						</q-button>
						</td>
					</tr>
				</template>
			</qtable>
		</row>

		<modal_advanced_property
			v-if="modalForms.advancedProperties.show"
			:Model="modalForms.advancedProperties.data"
			:SelectLists="SelectLists"
			@callback="callbackAdvancedProperty"
			@close="closeAdvancedProperties" />

	</div>
</template>

<script>
// @ is an alias to /src
import { reusableMixin } from '@/mixins/mainMixin';
import { QUtils } from '@/utils/mainUtils';
import bootbox from 'bootbox';
import modal_advanced_property from './AdvancedProperty.vue';

export default {
	name: 'advanced',
	components: { modal_advanced_property },
	props: {
		model: {
			required: true
		},
		SelectLists: {
			required: true
		}
	},
	mixins: [reusableMixin],
	emits: ['updateModal'],
	data() {
		var vm = this;
		return {
			modalForms: {
			advancedProperties: {
					show: false,
					data: { }
				},
			},
			Model: this.model,
			tAdvP: {
				rows: [],
				total_rows: 0,
				columns: [{
				label: vm.$t('ACOES22599'),
				name: "actions",
				slot_name: "actions",
				sort: false,
				column_classes: "thead-actions",
				row_text_alignment: 'text-center',
				column_text_alignment: 'text-center'
				},
				{
				label: vm.$t('KEY01046'),
				name: "Key",
				sort: true,
				initial_sort: true,
				initial_sort_order: "asc"
				},
				{
				label: vm.$t('VALUE10285'),
				name: "Val",
				sort: true
				}],
				config: {
				table_title: vm.$t('PROPRIEDADES_AVANCAD23972')
				}
			},
		};
	},
	methods: {
		showAdvancedPropertyModal(mode, moreProperty) {
			var vm = this;
			vm.modalForms.advancedProperties.data = $.extend(true, {}, moreProperty);
			vm.modalForms.advancedProperties.data.FormMode = mode;
			//
			vm.modalForms.advancedProperties.show = true;

			//$('#system_setup_more_property').modal('show');
			//
		},
		changeAdvancedProperty(moreProperty) {
			var vm = this;
			vm.showAdvancedPropertyModal('edit', moreProperty);
		},
		deleteAdvancedProperty(moreProperty) {
			var vm = this;
			vm.showAdvancedPropertyModal('delete', moreProperty);
		},
		createAdvancedProperty() {
			var vm = this,
			url = QUtils.apiActionURL('Config', 'GetNewMorePropertyCfg');
			QUtils.FetchData(url).done(function (data) {
			vm.showAdvancedPropertyModal('new', data);
			});
		},
		callbackAdvancedProperty(eventData) {
			var vm = this;
			vm.closeAdvancedProperties();
			switch (eventData.mode) {
				case 'new':
					vm.Model.AdvancedProperties.push(eventData.moreProperty);
					break;
				case 'edit':
					vm.$emit('updateModal');
					break;
				case 'delete':
					vm.$emit('updateModal');
					break;
			}
		},
		closeAdvancedProperties() {
			this.modalForms.advancedProperties.show = false;
		}
	},
	mounted() {
		this.tAdvP.rows = this.Model.AdvancedProperties || [];
		this.tAdvP.total_rows = (this.tAdvP.rows || []).length;
	},
	updated() {
		this.tAdvP.rows = this.Model.AdvancedProperties || [];
		this.tAdvP.total_rows = (this.tAdvP.rows || []).length;
	}
};
</script>
