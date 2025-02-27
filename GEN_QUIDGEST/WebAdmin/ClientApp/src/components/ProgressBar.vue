<template>
	<q-overlay
		:model-value="show"
		backdropBlur
		scroll-lock
		persistent>
		<div class="progress-bar__container">
			<div
				v-if="withTitle"
				class="c-modal__header">
				<h3 class="c-modal__header-title">
					{{ text }}
				</h3>
			</div>
			<div class="c-modal__body">
				<div
					class="progress">
					<div
						class="progress-bar progress-bar-striped progress-bar-animated"
						:style="{ width: progress + '%' }">
						<template v-if="!withTitle">{{ text }}</template>
					</div>
				</div>
			</div>

		<!-- Button -->
			<div
				v-if="withButton"
				class="progress-bar__footer">
				<q-button
					b-style="primary"
					:label="buttonText"
					@click="$emit('onButtonClick')" />
			</div>
		</div>
	</q-overlay>
</template>

<script>
export default {
	emits: ['onButtonClick'],

	props: {
		show: {
			type: Boolean,
			default: false
		},

		progress: {
			type: Number,
			default: 0
		},

		text: {
			type: String,
			default: ''
		},

		withTitle: {
			type: Boolean,
			default: true
		},

		withButton: {
			type: Boolean,
			default: false
		},

		buttonText: {
			type: String,
			default: ''
		}
	}
}
</script>
