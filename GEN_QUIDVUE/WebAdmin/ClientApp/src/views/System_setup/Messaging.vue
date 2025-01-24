<template>
	<div id="system_setup_messaging_container">
		<row>
			<q-card
				class="q-card--admin-default"
				:title="Resources.CORRETOR_DE_MENSAGEN22044"
				width="block">
				<q-row-container>
					<q-checkbox
						v-model="model.Enabled"
						:label="Resources.ATIVO_00196" />
					<q-text-field
						v-model="model.Host.Provider"
						label="Provider"
						readonly
						size="xlarge" />
					<q-text-field
						v-model="model.Host.Endpoint"
						label="Endpoint"
						placeholder="amqp://localhost"
						size="xlarge" />
					<q-text-field
						v-model="model.Host.Username"
						:label="Resources.NOME_DE_UTILIZADOR58858"
						size="xlarge" />
					<password-input
						v-model="model.Host.Password"
						:label="Resources.PALAVRA_PASSE44126"
						show-filler
						size="xlarge" />
				</q-row-container>
			</q-card>
		</row>

		<row>
			<q-card
				class="q-card--admin-default"
				:title="Resources.PUBLICAR52698"
				width="block">
				<q-row-container>
					<div v-for="pub in EnabledPublications">
						<q-checkbox
							v-model="pub.enabled"
							:label="pub.id" />
						<span> - {{ pub.description }}</span>
					</div>
				</q-row-container>
			</q-card>
		</row>

		<row>
			<q-card
				class="q-card--admin-default"
				:title="Resources.INSCREVER_SE07499"
				width="block">
				<q-row-container>
					<template v-for="sub in EnabledSubscriptions">
						<q-checkbox
							:v-model="sub.enabled"
							:label="sub.id" />
						<span>
							- {{ sub.description }}
						</span>
					</template>
				</q-row-container>
			</q-card>
		</row>

		<row class="footer-btn">
			<q-button
				b-style="primary"
				:label="Resources.GRAVAR_CONFIGURACAO36308"
				@click="SaveConfigMessaging" />
		</row>
	</div>
</template>

	<script>
	// @ is an alias to /src
	import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';

	export default {
		name: 'messaging',

		mixins: [reusableMixin],

		props: {
			model: {
				required: true
			},
			Metadata: {
				required: true
			}
		},

		emits: ['updateModal', 'alertClass'],

		data () {
			return {
				resultMsg: "",
				statusError: false
			};
		},

		computed: {
		EnabledPublications() {
				let vm = this;
				return this.Metadata.Publishers.map(p => { 
					return {
						id: p.Id,
						description: p.Description,
						enabled: vm.model.EnabledPublications.indexOf(p.Id) != -1
					}
				});
			},
			EnabledSubscriptions() {
				let vm = this;
				return this.Metadata.Subscribers.map(p => { 
					return {
						id: p.Id,
						description: p.Description,
						enabled: vm.model.EnabledSubscriptions.indexOf(p.Id) != -1
					}
				});
			}
		},

		methods: {

			togglePub(pub, checked) {
				this.makeSetHave(this.model.EnabledPublications, pub.id, checked);
			},
			toggleSub(sub, checked) {
				this.makeSetHave(this.model.EnabledSubscriptions, sub.id, checked);
			},

			makeSetHave(set, value, have) {
				let ix = set.indexOf(value);
				if(!have) { //set should not have the item
					if(ix != -1) {
						set.splice(ix, 1) //remove the item
					}
				}
				else { //set should have the item
					if(ix == -1) {
						set.push(value); //add the item
					}
				}
			},
			SaveConfigMessaging() {
				var vm = this;
				QUtils.log("SaveConfigMessaging - Request", QUtils.apiActionURL('Config', 'SaveConfigMessaging'));
				QUtils.postData('Config', 'SaveConfigMessaging', vm.model, null, function (data) {
					QUtils.log("SaveConfigMessaging - Response", data);          
					vm.$emit('updateModal', data);
					vm.statusError = !data.Success;
					if (data.Success) {
						vm.$emit('alertClass', { ResultMsg: vm.Resources.ALTERACOES_EFETUADAS10166, AlertType: 'success' });
					} else {
						vm.$emit('alertClass', { ResultMsg: data.Message, AlertType: 'danger' });
					}
				});
			}
		}
	};
</script>
