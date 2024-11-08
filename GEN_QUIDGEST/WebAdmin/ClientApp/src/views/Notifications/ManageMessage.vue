<template>
	<div id="notifications_manage_message_container">
		<div class="q-stack--column">
			<h1 class="f-header__title">
				{{ Resources.CONFIGURACAO_DA_MENS64174 }}
			</h1>
		</div>
		<hr>
		<template v-if="!isEmptyObject(Model.ResultMsg)">
			<div class="alert alert-info">
				<p><b class="status-message">{{ Model.ResultMsg }}</b></p>
			</div>
			<br />
		</template>
		<template v-if="Model.FormMode==3">
			<div class="alert alert--warning">
				<strong>Warning!</strong>
				{{ Resources.DESEJA_ELIMINAR_ESTA24564 }}
			</div>
		</template>

		<QGroupBoxContainer>
			<q-row-container>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<text-input v-model="Model.ValDesignac" :label="Resources.NOME47814" :isReadOnly="blockForm"></text-input>
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<select-input v-model="Model.ValCodpmail" v-if="Model" :options="Model.TableEmailProperties" :label="Resources.REMETENTE47685" :isReadOnly="blockForm"></select-input>
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<checkbox-input v-model="Model.ValDestnman" :label="Resources.DESTINATARIO_MANUAL30643" :isReadOnly="blockForm"></checkbox-input>
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<select-input v-model="Model.ValCoddestn" v-if="Model" :options="Model.TableAllowedDestinations" :label="Resources.DESTINATARIO22298" :isReadOnly="blockForm"></select-input>
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<text-input v-model="Model.ValTomanual" :label="Resources.DESTINATARIO_MANUAL30643" :isReadOnly="blockForm"></text-input>
					</base-input-structure>
				</q-control-wrapper>
			</q-row-container>
		</QGroupBoxContainer>

		<q-group-collapsible
			label="Cc & Bcc"
			:is-open="openGroups['collapsible-config']"
			id="collapsible-config"
			@state-changed="toggleGroup('collapsible-config')">
			<row>
				<text-input v-model="Model.ValCc" :label="'Cc'" :isReadOnly="blockForm"></text-input>
			</row>
			<row>
				<text-input v-model="Model.ValBcc" :label="'Bcc'" :isReadOnly="blockForm"></text-input>
			</row>
		</q-group-collapsible>

		<QGroupBoxContainer>
			<q-row-container>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<text-input v-model="Model.ValAssunto" :label="Resources.ASSUNTO16830" :isReadOnly="blockForm"></text-input>
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<textarea-input v-model="Model.ValMensagem" :label="Resources.MENSAGEM32641" :isReadOnly="blockForm" :rows="5"></textarea-input>
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<select-input v-model="Model.ValSelectedTag" v-if="Model" :options="Model.TableAllowedTags" :label="Resources.TAGS54909" :isReadOnly="blockForm"></select-input>
						<q-button
							:label="Resources.ADICIONAR17177"
							:disabled="blockForm"
							@click="addText" />
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<select-input v-model="Model.ValCodsigna" v-if="Model" :options="Model.TableEmailSignatures" :label="Resources.ASSINATURA_DE_EMAIL58979" :isReadOnly="blockForm"></select-input>
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<checkbox-input v-model="Model.ValHtml" :label="Resources.FORMATO_HTML_65194" :isReadOnly="blockForm"></checkbox-input>
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<checkbox-input v-model="Model.ValEmail" :label="Resources.ENVIA_EMAIL_46551" :isReadOnly="blockForm"></checkbox-input>
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<checkbox-input v-model="Model.ValGravabd" :label="Resources.GRAVA_NA_BD_43814" :isReadOnly="blockForm"></checkbox-input>
					</base-input-structure>
				</q-control-wrapper>
				<q-control-wrapper class="row-line-group">
					<base-input-structure
						class="i-text">
						<checkbox-input v-model="Model.ValAtivo" :label="Resources.ATIVO_00196" :isReadOnly="blockForm"></checkbox-input>
					</base-input-structure>
				</q-control-wrapper>
			</q-row-container>
		</QGroupBoxContainer>
		<row class="footer-btn">
			<q-button
				v-if="Model.FormMode !== 3"
				b-style="primary"
				:label="Resources.GRAVAR_CONFIGURACAO36308"
				@click="SaveMessage" />
			<q-button
				v-else
				b-style="danger"
				:label="Resources.APAGAR04097"
				@click="SaveMessage" />
			<q-button
				:label="Resources.CANCELAR49513"
				@click="cancel" />
		</row>
	</div>
</template>

<script>
	// @ is an alias to /src
	import { reusableMixin } from '@/mixins/mainMixin';
	import QAlert from '@/components/QAlert.vue';
	import { QUtils } from '@/utils/mainUtils';
	import QGroupCollapsible from '@/components/QGroupCollapsible.vue'
	//import bootbox from 'bootbox';

	import _get from "lodash-es/get";

	export default {
		name: 'notifications_message',
		mixins: [reusableMixin],
		components: {
			QGroupCollapsible,
			QAlert
		},
		data() {
			//var vm = this;
			return {
				Model: {},
				openGroups: {
				'collapsible-system': false,
				'collapsible-config': false
			},
			};
		},
		computed: {
			blockForm() { return this.Model.FormMode == 3; }
		},
		methods: {
			fetchData() {
				var vm = this,
				mod = vm.$route.params.mod,
				codmesgs = _get(vm.$route.params, 'codmesgs', null),
				idnotif = _get(vm.$route.params, 'idnotif', null);
				QUtils.log("Fetch data - ManageMessage");
				QUtils.FetchData(QUtils.apiActionURL('Notifications', 'ManageMessage', { mod, codmesgs, idnotif })).done(function (data) {
					QUtils.log("Fetch data - OK (ManageMessage)", data);
					if (data.Success) {
						$.each(data.model, function (propName, value) { vm.Model[propName] = value; });
					}
				});
			},
			cancel() {
				this.$router.go(-1);
			},
			SaveMessage() {
				var vm = this;
				QUtils.log("ManageMessage - Request", QUtils.apiActionURL('Notifications', 'SaveMessage'));
				QUtils.postData('Notifications', 'SaveMessage', {
					...vm.Model,
					/*
						The client side does not need to send the list options back.
						And if it is send, it will cause an error in deserialization.
					*/
					TableAllowedDestinations: null,
					TableAllowedTags: null,
					TableEmailProperties: null,
					TableEmailSignatures: null
				}, null, function (data) {
					QUtils.log("ManageMessage - Response", data);
					if (data.Success) {
						vm.$router.go(-1);
					}
					else {
						$.each(data.model, function (propName, value) { vm.Model[propName] = value; });
					}
				});
			},
			addText() {
				this.Model.ValMensagem += this.Model.ValSelectedTag;
			},
			toggleGroup(groupId) {
				this.openGroups[groupId] = !this.openGroups[groupId]
			}
		},
		created() {
			// Ler dados
			this.fetchData();
		}
	};
</script>
