<template>
	<div>
		<div class="title-container--with-badge">
			<h5>{{ Resources.TODOS_OS_UTILIZADORE41512 }}</h5>
			<data-system-badge
				:title="Resources.SISTEMA_DE_DADOS_ATU09110" />
		</div>

		<hr>

		<span>
			{{ Resources.FILTRAR_POR_MODULOS26042 }} 
		</span>

		<div class="all-users-checkboxes">
			<q-checkbox
				v-model="selectModules"
				:label="Resources.TODOS59977" />

			<div class="all-users-checkboxes__divider" />

			<q-checkbox
				v-for="module in Modules" 
				:key="module.Cod"
				v-model="module.active"
				:label="Resources[module.Description]" />
		</div>
	</div>

	<qtable 
		:rows="Users.rows"
		:columns="Users.columns"
		:config="Users.config"
		:totalRows="Users.total_rows"
		:exportLabel="Resources.EXPORT_TO_EXCEL22478"
		:enableExport="true"
		@on-change-query="onChangeQuery"
		class="q-table--borderless">
		<!--Action column-->
		<template #actions="props">
		<q-button-group borderless>
			<q-button
				:title="Resources.EDITAR11616"
				@click="editUser(props.row)">
				<q-icon icon="pencil" />
			</q-button>
			<q-button
				:title="Resources.ELIMINAR21155"
				@click="deleteUser(props.row)">
				<q-icon icon="bin" />
			</q-button>
		</q-button-group>
		</template>

		<template #user-roles="props">
			<q-badge
				v-for="userRole in props.row.UserRoles.filter(role => Modules[role.Module].active)"
				:key="userRole.Role"
				variant="bold" >
				{{ Resources[userRole.Designation] }}
			</q-badge>
		</template>
		<template #GQT="props">
			<q-badge
				v-for="userRole in props.row.UserRoles.filter(role => role.Module === 'GQT' && Modules[role.Module].active)"
				:key="userRole.Role"
				variant="bold" >
				{{ Resources[userRole.Designation] }}
			</q-badge>
		</template>
		<template #PTN="props">
			<q-badge
				v-for="userRole in props.row.UserRoles.filter(role => role.Module === 'PTN' && Modules[role.Module].active)"
				:key="userRole.Role"
				variant="bold" >
				{{ Resources[userRole.Designation] }}
			</q-badge>
		</template>
		<template #STY="props">
			<q-badge
				v-for="userRole in props.row.UserRoles.filter(role => role.Module === 'STY' && Modules[role.Module].active)"
				:key="userRole.Role"
				variant="bold" >
				{{ Resources[userRole.Designation] }}
			</q-badge>
		</template>
		<template #TBS="props">
			<q-badge
				v-for="userRole in props.row.UserRoles.filter(role => role.Module === 'TBS' && Modules[role.Module].active)"
				:key="userRole.Role"
				variant="bold" >
				{{ Resources[userRole.Designation] }}
			</q-badge>
		</template>
		<template #REG="props">
			<q-badge
				v-for="userRole in props.row.UserRoles.filter(role => role.Module === 'REG' && Modules[role.Module].active)"
				:key="userRole.Role"
				variant="bold" >
				{{ Resources[userRole.Designation] }}
			</q-badge>
		</template>
		<template #IMO="props">
			<q-badge
				v-for="userRole in props.row.UserRoles.filter(role => role.Module === 'IMO' && Modules[role.Module].active)"
				:key="userRole.Role"
				variant="bold" >
				{{ Resources[userRole.Designation] }}
			</q-badge>
		</template>
		<template #WMS="props">
			<q-badge
				v-for="userRole in props.row.UserRoles.filter(role => role.Module === 'WMS' && Modules[role.Module].active)"
				:key="userRole.Role"
				variant="bold" >
				{{ Resources[userRole.Designation] }}
			</q-badge>
		</template>
		<template #table-footer>
			<tr>
				<td colspan="2">
				<q-button
					:label="Resources.INSERIR43365"
					@click="createUser">
				</q-button>
				</td>
			</tr>
		</template>
	</qtable>

	<row v-if="hasAdIdentityProviders">
		<q-select
			v-model="domainprovider"
			item-value="Value"
			item-label="Text"
			:items="identityProviders"
			:label="'Select the domain'" />
		<q-button
			b-style="primary"
			:label="Resources.IMPORTAR_UTILIZADORE27134"
			@click="ImportarUsersAD" />
	</row>
	<q-dialog
		v-model="showConfirmDialog"
		:text="Resources.DESEJA_ELIMINAR_ESTA24564"
		:buttons="confirmBtns" />
	<q-dialog
		v-model="showDialog"
		:text="Resources.UTILIZADOR_EXCLUIDO_17794"
		:icon='{"icon":"check-circle-outline"}'
		:buttons="dialogBtns" />
</template>

<script>
	// @ is an alias to /src
	import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';

	export default {
		name: 'allUsers',
		mixins: [reusableMixin],
		emits: ['alert-class'],
		data() {
			var vm = this;
			return {
				Model: {},
				showConfirmDialog: false,
				showDialog: false,
				dialogBtns: [],
				confirmBtns: [],
				userId: '',
				Modules: {
					GQT : { active: true, Cod: "GQT", Description: 'GENIO_QUALITY_TESTS30896'},
					PTN : { active: true, Cod: "PTN", Description: 'PATTERNS16056'},
					STY : { active: true, Cod: "STY", Description: 'STYLE47121'},
					TBS : { active: true, Cod: "TBS", Description: 'BASE_TABLES04823'},
					REG : { active: true, Cod: "REG", Description: 'REGISTRATION03584'},
					IMO : { active: true, Cod: "IMO", Description: 'REAL_ESTATE24996'},
					WMS : { active: true, Cod: "WMS", Description: 'WAREHOUSE_MANAGEMENT10443'},
				},
				Users: {
					rows: [],
					total_rows: 0,
					columns: [],
					config: {
						global_search: {
							classes: "qtable-global-search",
							placeholder : vm.$t('PESQUISAR_NOME07780'),
							searchOnPressEnter: true,
							showRefreshButton: true,
							searchDebounceRate: 1000
						},
						server_mode: true,
						preservePageOnDataChange: true
					},
					queryParams: {
						sort: [],
						filters: [],
						global_search: "",
						per_page: 10,
						page: 1,
						component: "user",
					}
				},
				Roles: {
					rows: [],
					total_rows: 1,
					columns: [
						{
							label: () => vm.$t('MODULO43834'),
							name: "module",
							sort: true,
							initial_sort: true,
							initial_sort_order: "asc"
						},
						{
							label: () => vm.$t('ROLE60946'),
							name: "role",
							sort: true,
							initial_sort: true,
							initial_sort_order: "asc"
						}
					]
				},
				domainprovider: '',
				identityProviders: [],
				columnModules : true,
				hasAdIdentityProviders: false
			};
		},
		computed: {
			selectModules: {
                get() {
                	//If we explicitly declare the variables, vue will bind them
					return                     this.Modules.GQT.active &&
                    this.Modules.PTN.active &&
                    this.Modules.STY.active &&
                    this.Modules.TBS.active &&
                    this.Modules.REG.active &&
                    this.Modules.IMO.active &&
                    this.Modules.WMS.active ;
                },
                set(value) {
                    //If we explicitly declare the variables, vue will bind them
                    this.Modules.GQT.active = value;
                    this.Modules.PTN.active = value;
                    this.Modules.STY.active = value;
                    this.Modules.TBS.active = value;
                    this.Modules.REG.active = value;
                    this.Modules.IMO.active = value;
                    this.Modules.WMS.active = value;
                    return value;
                }
            }
        },
		methods: {
			createUser() {
				this.$router.push({ name: 'manage_users', params: { mod: 1, culture: this.currentLang, system: this.currentYear } });
			},
			editUser(row) {
				this.$router.push({ name: 'manage_users', params: { mod: 2, cod: row.Codpsw, culture: this.currentLang, system: this.currentYear } });
			},
			deleteUser(row) {
				this.userId = row.Codpsw;
				this.getConfirmBtns()
				this.showConfirmDialog = true;

			},
			GetUserList() {
				var vm = this;
				QUtils.log("GetUserList - Users");
				QUtils.FetchData(QUtils.apiActionURL('Users', 'GetUserList', vm.Users.queryParams)).done(function (data) {
					QUtils.log("GetUserList - OK (Users)", data);
					vm.Users.total_rows = data.recordsTotal;
					var newRows = [];
					//iterate between users
					for (let j = 0; j < data.data.length; j++) {
						var row = {};
						let user = data.data[j];
						row.Codpsw = user.Codpsw;
						row.Nome = user.Nome;
						row.UserRoles = user.privileges;
						newRows.push(row);
					}
					vm.Users.rows = newRows;
				});
			},
			fetchData() {
				var vm = this;
				QUtils.log("Fetch data - Users");
				QUtils.FetchData(QUtils.apiActionURL('Users', 'Index')).done(function (data) {
					if (data.Success) {
						// Update IdentityProviders list
						vm.identityProviders = [];
						$.each(data.model.IdentityProviders, function (idx, identityProvider) {
							vm.identityProviders.push({ Value: identityProvider, Text: identityProvider });
						});
						vm.hasAdIdentityProviders = data.model.HasAdIdentityProviders;
					}
				});
				this.GetUserList();
			},
			onChangeQuery(queryParams) {
				this.Users.queryParams = queryParams;
				this.fetchData();
			},
			getShowDialog() {
				this.dialogBtns = [
					{
						id: 'confirm-btn',
						props: {
							label: this.Resources.OK57387,
							bStyle: "primary"
						},
						action: () => {
							if (!this.Model.Username) {
								this.$router.replace({ name: 'users', params: { culture: this.currentLang, system: this.currentYear } });
								return;
							}
							this.$router.replace({ name: 'users', params: { culture: this.currentLang, system: this.currentYear } });
						}
					}
				]
				this.showDialog = true
			},
			getConfirmBtns() {
				this.confirmBtns = [
					{
						id: 'confirm-btn',
						props: {
							label: this.Resources.SIM28552,
							bStyle: "primary"
						},
						action: () => {
							this.submit()
							
						}
					},
					{
						id: 'cancel-btn',
						props: {
							label: this.Resources.NAO06521,
							bStyle: "secondary"
						}
					}
				]
			},
			submit() {
				const cod = this.userId;
				QUtils.postData('ManageUsers', 'UserDeleteFromTable', null, { cod }, (data) => {
					if (data.Success) {
						this.fetchData()
						this.getShowDialog();
					}
					else {
						this.$emit('alert-class', { ResultMsg: data.Message, AlertType: 'danger' });
					}
				});
			},
			userColumns() {
				var vm = this;
				return [{
					label: () => vm.$t('ACOES22599'),
					name: "actions",
					slot_name: "actions",
					sort: false,
					column_classes: "thead-actions",
					row_text_alignment: 'text-center',
					column_text_alignment: 'text-center'
				},
				{
					label: () => vm.$t('NOME47814'),
					name: "Nome",
					sort: true,
					initial_sort: true,
					initial_sort_order: "asc"
				},
				{
					label: () => vm.$t('ROLES61449'),
					name: "user-roles",
					slot_name: "user-roles",
					sort: false,
					visibility: !vm.columnModules
				},
				{
					label: () => vm.$t(vm.Modules.GQT.Description),
					name: "GQT",
					slot_name: "GQT",
					sort: false,
					visibility: vm.Modules.GQT.active && vm.columnModules
				},
				{
					label: () => vm.$t(vm.Modules.PTN.Description),
					name: "PTN",
					slot_name: "PTN",
					sort: false,
					visibility: vm.Modules.PTN.active && vm.columnModules
				},
				{
					label: () => vm.$t(vm.Modules.STY.Description),
					name: "STY",
					slot_name: "STY",
					sort: false,
					visibility: vm.Modules.STY.active && vm.columnModules
				},
				{
					label: () => vm.$t(vm.Modules.TBS.Description),
					name: "TBS",
					slot_name: "TBS",
					sort: false,
					visibility: vm.Modules.TBS.active && vm.columnModules
				},
				{
					label: () => vm.$t(vm.Modules.REG.Description),
					name: "REG",
					slot_name: "REG",
					sort: false,
					visibility: vm.Modules.REG.active && vm.columnModules
				},
				{
					label: () => vm.$t(vm.Modules.IMO.Description),
					name: "IMO",
					slot_name: "IMO",
					sort: false,
					visibility: vm.Modules.IMO.active && vm.columnModules
				},
				{
					label: () => vm.$t(vm.Modules.WMS.Description),
					name: "WMS",
					slot_name: "WMS",
					sort: false,
					visibility: vm.Modules.WMS.active && vm.columnModules
				},
			];
		},
		ImportarUsersAD() {
			if (this.hasAdIdentityProviders === false) return

			var vm = this,
				domain = this.domainprovider;

			if ($.isEmptyObject(domain)) {
				bootbox.alert(vm.Resources.E_NECESSARIO_ESCOLHE33714);
				return;
			}

			var domainSplited = new Array();
			domainSplited = domain.split('=');

			if (domainSplited.length < 2 || $.isEmptyObject(domainSplited[1])) {
				bootbox.alert(vm.Resources.DOMINIO_IVALIDO_36204);
				return;
			}
			else {
				domain = domainSplited[1];
			}

			bootbox.confirm({
				message: vm.Resources.DESEJA_MESMO_MESMO_I42044,
				buttons: {
					confirm: {
						label: vm.Resources.SIM28552,
						className: 'btn-success'
					},
					cancel: {
						label: vm.Resources.NAO06521,
						className: 'btn-danger'
					}
				},
				callback(result) {
					if (result) {
						QUtils.postData('Users', 'ImportUsersFromAD', null, { dominio: domain }, function (data) {
							vm.fetchData();
						});
					}
				}
			});
		}
	},
    watch: {
		//Watcher to change the columns when the filters are checked
		Modules: {
			deep: true,
			immediate: true,
			handler() {
				this.Users.columns = this.userColumns();
			}
		}
	}
}
</script>
