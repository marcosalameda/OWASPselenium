<template>
  <div>
    <div class="q-stack--column">
			<h1 class="f-header__title">
			{{ Resources.GESTAO_DE_UTILIZADOR20428 }}
			</h1>
		</div>
    <hr>
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
</template>

<script>
  // @ is an alias to /src
  import { reusableMixin } from '@/mixins/mainMixin';
  import { QUtils } from '@/utils/mainUtils';
  import bootbox from 'bootbox';
  import roles from './RoleList.vue';
  import Nroles from './UserRoles.vue';
  import allUsers from './AllUsers.vue';

  export default {
    name: 'users',
    mixins: [reusableMixin],
    components: { roles, Nroles, allUsers},
    data: function () {
      var vm = this;
      return {
        Model: {},
        tabGroup: {
					selectedTab: 'all-users-tab',
					alignTabs: 'left',
					iconAlignment: 'left',
					isVisible: true,
					tabsList: [
						{
							id: 'all-users-tab',
							componentId: 'allUsers',
							name: 'all-users',
							label: vm.$t('UTILIZADORES39761'),
							disabled: false,
							isVisible: true
						},
						{
							id: 'roles-tab',
							componentId: 'roles',
							name: 'roles',
							label: vm.$t('ROLES61449'), 
							disabled: false,
							isVisible: true
						},
						{
							id: 'Nroles-tab',
							componentId: 'Nroles',
							name: 'Nroles',
							label: vm.$t('GESTAO_DE_ACESSOS25265'),
							disabled: false,
							isVisible: true
						}
					]
				}
      };
    },
    methods: {
      fetchData: function () {
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
      getTab(tab, selectedTab) {
				return _find(this[tab]['tabsList'], (x) => x.id === selectedTab)
			},

			changeTab(tab, tabProp, selectedTab) {
				this[tab][tabProp] = selectedTab
			}
    },
    watch: {
      // call again the method if the route changes
      '$route': 'fetchData',
    }
  };
</script>
