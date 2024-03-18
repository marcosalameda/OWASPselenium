<template>
	<teleport
		v-if="isReady"
		to="#q-modal-form-message-tracker-body">
		<div
			class="progress"
			style="margin-bottom: 0">
			<div
				:class="progressClasses"
				style="width: 100%" />
		</div>

		<q-table
			:rows="tableRows"
			:columns="tableColumns"
			:config="tableConfig" />
	</teleport>

	<teleport
		v-if="isReady"
		to="#q-modal-form-message-tracker-footer">
		<q-button
			v-if="completed"
			b-style="secondary"
			:label="texts.close"
			:title="texts.close"
			@click="goBack">
			<q-icon icon="close" />
		</q-button>
	</teleport>
</template>

<script>
	import { computed } from 'vue'
	import { mapActions } from 'pinia'

	import { useGenericDataStore } from '@/stores/genericData.js'
	import { displayMessage } from '@/mixins/genericFunctions.js'
	import hardcodedTexts from '@/hardcodedTexts.js'

	import NavHandlers from '@/mixins/navHandlers.js'

	export default {
		name: 'MessageTracker',

		mixins: [
			NavHandlers
		],

		expose: [
			'isReady',
			'navigationId'
		],

		data()
		{
			return {
				model: {
					rows: []
				},

				tableConfig: {
					showFooter: false,
					perPage: 10000,
					globalSearch: {
						visibility: false
					}
				},

				tableColumns: [
					{
						order: 1,
						dataType: 'Text',
						label: computed(() => this.Resources[hardcodedTexts.message]),
						name: 'Message',
						sortable: false
					}
				],

				texts: {
					dataGeneration: computed(() => this.Resources[hardcodedTexts.dataGeneration]),
					close: computed(() => this.Resources[hardcodedTexts.close])
				},

				isReady: false,

				completed: false
			}
		},

		beforeRouteEnter(to, from, next)
		{
			to.params.isPopup = 'true'

			next((vm) => {
				if (from.name)
					vm.isReady = true
			})
		},

		created()
		{
			this.$eventHub.on('TraceMessages', this.traceMessages)
			this.$eventHub.on('TraceCompleted', this.traceCompletedCallback)
		},

		mounted()
		{
			const modalProps = {
				id: 'form-message-tracker',
				headerTitle: this.texts.dataGeneration,
				isActive: true
			}

			this.setModal(modalProps)
		},

		beforeUnmount()
		{
			this.$eventHub.off('TraceMessages', this.traceMessages)
			this.$eventHub.off('TraceCompleted', this.traceCompletedCallback)
		},

		computed: {
			tableRows()
			{
				var rows = []

				if (this.model.rows && this.model.rows.length > 0)
				{
					for (let i = 0; i < this.model.rows.length; i++)
					{
						let row = {
							Rownum: i,
							Fields: {
								Message: this.model.rows[i]
							}
						}

						rows.push(row)
					}
				}

				return rows
			},

			progressClasses()
			{
				const classes = [
					'progress-bar',
					'progress-bar-striped'
				]

				if (!this.completed)
					classes.push('progress-bar-animated')

				return classes
			}
		},

		methods: {
			...mapActions(useGenericDataStore, [
				'setModal'
			]),

			traceMessages(messages)
			{
				if (messages && messages.length > 0)
				{
					messages.forEach((elem) => {
						this.model.rows.push(elem)
					})
				}
			},

			traceCompletedCallback(data)
			{
				this.completed = true

				if (data.message)
					displayMessage(data.message)
			}
		}
	}
</script>
