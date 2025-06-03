<template>
	<row>
		<q-card
			id="system_setup_reporting_container"
			width="block"
			class="q-card--admin-default"
			:title="Resources.RELATORIOS37339">
			<q-row-container>
				<row>
					<q-card
						class="q-card--admin-border-less q-card--admin-compact"
						width="block">
						<q-row-container class="control-row-group">
							<div class="q-help__info-banner">
								<div class="q-help__info-banner-header">
									<q-icon icon="information-outline" />
									<h5>{{ Resources.CAMINHO_PARA_RELATOR05547 }}</h5>
								</div>
								<div class="q-help__info-banner-body">
									<span style="white-space: pre-line">
										{{ Resources.ESPECIFICA_O_CAMINHO51946 }}<br>
										<b>{{ Resources.CRYSTAL_REPORTS15382 }}</b><br>
										{{ Resources.UTILIZADO_PARA_CARRE49850 }}<br>
										<b>{{ Resources.REPORTING_SERVICES45145 }}</b><br>
										{{ Resources.PERMITE_VERIFICAR_NO39154 }}<br>
									</span>
								</div>
							</div>
							<q-control-wrapper class="control-row-group">
							<q-text-field
								v-model="model.pathReports"
								:label="Resources.CAMINHO_PARA_RELATOR05547"
								size="xlarge" />
							</q-control-wrapper>
						</q-row-container>
					</q-card>
				</row>
				<row>
					<q-card
						class="q-card--admin-border-top q-card--admin-compact"
						:title="Resources.SQL_SERVER_REPORTING62106"
						width="block">
						<q-row-container>
							<q-text-field
								v-model="model.ssrsServer"
								:label="Resources.URL05719"
								size="xlarge" />
							<q-text-field
								v-model="model.ssrsServerPath"
								:label="Resources.CAMINHO18436"
								size="xlarge" />
							<q-checkbox
								v-model="model.isLocalReports"
								:label="Resources.SAO_OS_RELATORIOS_LO04230" />
							<q-text-field
								v-model="model.ssrsServerDomain"
								:label="Resources.DOMINIO33043"
								size="xlarge" />
							<q-text-field
								v-model="model.ssrsServerUsername"
								:label="Resources.NOME_DE_UTILIZADOR58858"
								size="xlarge" />
							<password-input
								v-model="model.ssrsServerPassword"
								:label="Resources.PALAVRA_PASSE44126"
								:showFiller="model.hasSsrsServerPassword"
								size="xlarge">
							</password-input>
						</q-row-container>
					</q-card>
				</row>
			</q-row-container>
		</q-card>
	</row>
</template>

<script>
	// @ is an alias to /src
	import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';

	export default {
		name: 'reports',

		props: {
			model: {
				required: true
			},
		},
		mixins: [reusableMixin]
	};
</script>
