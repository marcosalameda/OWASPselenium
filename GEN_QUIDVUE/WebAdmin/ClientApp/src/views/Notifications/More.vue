<template>
	<div>
		<row>
			<select-input  v-model="Model.userRegistration" :options="Model.emailPropertiesList" :label="Resources.REGISTO_DE_UTILIZADO37378"></select-input>
		</row>
		<row>
			<select-input  v-model="Model.passwordRecovery" :options="Model.emailPropertiesList" :label="Resources.PASSWORD_RECOVERY53114"></select-input>
		</row>
		<row>
			<q-button
			b-style="primary"
			:label="Resources.GRAVAR45301"
			@click="SaveEmail" />
		</row>
    </div>
</template>

<script>
	import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';

	export default {
		name: "more",
		mixins: [reusableMixin],
		data() {
			return {
				Model: {},
			}
		},
		methods: {
			SaveEmail() {
				var vm = this;
				QUtils.log("ManageProperties - Request", QUtils.apiActionURL('Email', 'SaveEmail'));
				var params = { userRegistration: vm.Model.userRegistration, passwordRecovery : vm.Model.passwordRecovery};
				QUtils.postData('Email', 'SaveEmail', null, params, function (data) {
					vm.Model.ResultMsg = data.ResultMsg;
				});
			},
		}
	}
</script>
