<template>
	<div id="system_setup_messaging_container">

		<row v-if="!isEmptyObject(resultMsg)">
		<div :class="['alert', statusError?'alert-danger':'alert-success']">
			<span>
				<b class="status-message">{{ resultMsg }}</b>
			</span>
		</div>
		<br />
		</row>

		<QGroupBoxContainer :label="Resources.CORRETOR_DE_MENSAGEN22044">
			<q-row-container>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<checkbox-input v-model="model.Enabled" :label="Resources.ATIVO_00196"></checkbox-input>
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<text-input v-model="model.Host.Provider" label="Provider" :isReadOnly="true"></text-input>
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<text-input v-model="model.Host.Endpoint" label="Endpoint" placeholder="amqp://localhost"></text-input>
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<text-input v-model="model.Host.Username" :label="Resources.NOME_DE_UTILIZADOR58858"></text-input>
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<password-input v-model="model.Host.Password" :label="Resources.PALAVRA_PASSE44126" :showFiller="true"></password-input>
					</base-input-structure>
				</q-control-wrapper>
			</q-row-container>
		</QGroupBoxContainer>
		<br />
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
		emits: ['updateModal'],
		data: function () {
		return {
			resultMsg: "",
			statusError: false
		};
		},
		computed: {
		EnabledPublications: function() {
			let vm = this;
			return this.Metadata.Publishers.map(p => { 
			return {
				id: p.Id,
				description: p.Description,
				enabled: vm.model.EnabledPublications.indexOf(p.Id) != -1
			}
			});
		},
		EnabledSubscriptions: function() {
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
			if (data.Success) {
				vm.resultMsg = vm.Resources.ALTERACOES_EFETUADAS10166;
				vm.statusError = false;
			} else {
				vm.resultMsg = data.Message;
				vm.statusError = true;
			}

			});
		}
		}
	};
</script>
