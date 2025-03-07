<template>
	<div id="system_setup_integration_container">
		<row>
			<q-card
				:title="Resources.SISTEMA_DE_MENSAGENS07077"
				width="block"
				class="q-card--admin-default">
				<q-row-container>
					<message
						:Messaging="Messaging"
						:Metadata="Metadata"
						:model="model"
						@alert-class="forwardAlert"
					/>
				</q-row-container>
			</q-card>
		</row>

	</div>
</template>

<script>
	// @ is an alias to /src
	import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';
	import QAlert from '@/components/QAlert.vue';
	import message from './Message';
	export default {
		name: 'integration',

		components: {
			QAlert,
			message,
		},

		mixins: [reusableMixin],

		emits: ['update-model', 'alert-class'],

		props: {
			model: {
				required: true
			},
			Metadata: {
				required: true
			},
			Messaging: {
				required: true
			}
		},

		data() {
			return {
				resultMsg: "",
				statusError: false,
				alert: {
					isVisible: false,
					alertType: 'info',
					message: ''
				}
			};
		},
		
		methods: {
			forwardAlert(alertData) {
				this.$emit('alert-class', alertData);
			}
		}
	};
</script>
