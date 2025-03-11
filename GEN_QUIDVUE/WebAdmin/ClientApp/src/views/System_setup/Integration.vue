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

		<row>
			<q-card
				width="block"
				class="q-card--admin-default"
				:title="Resources.MENSAGENS_QUEUE_SERV62690">
				<q-row-container>
					<queue
						:model="model"
						@update-model="$emit('update-model')"
						@alert-class="forwardAlert" />
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
	import queue from './Queue';
	export default {
		name: 'integration',

		components: {
			QAlert,
			message,
			queue
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
