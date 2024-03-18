<template>
	<teleport :to="`#q-modal-file-properties-${controlId}-body`">
		<div class="content">
			<div class="list-flow properties">
				<div class="row no-gutters">
					<div class="col-12">
						<div class="flow-label">
							{{ texts.nameLabel }}
						</div>

						<div class="display-as-input input-xlarge">
							{{ fileProperties.name }}
						</div>

						<div class="flow-label">
							{{ texts.sizeLabel }}
						</div>

						<div class="display-as-input input-xlarge">
							{{ fileProperties.size }}
						</div>

						<div class="flow-label">
							{{ texts.extensionLabel }}
						</div>

						<div class="display-as-input input-xlarge">
							{{ fileProperties.extension }}
						</div>

						<div class="flow-label">
							{{ texts.authorLabel }}
						</div>

						<div class="display-as-input input-xlarge">
							{{ fileProperties.author }}
						</div>

						<div class="flow-label">
							{{ texts.createdDateLabel }}
						</div>

						<div class="display-as-input input-xlarge">
							{{ fileProperties.createdDate }}
						</div>

						<div class="flow-label">
							{{ texts.currentVersionLabel }}
						</div>

						<div class="display-as-input input-xlarge">
							{{ fileProperties.currentVersion }}
						</div>

						<div class="flow-label">
							{{ texts.editedByLabel }}
						</div>

						<div class="display-as-input input-xlarge">
							{{ fileProperties.editor }}
						</div>
					</div>
				</div>
			</div>
		</div>
	</teleport>

	<teleport :to="`#q-modal-file-properties-${controlId}-footer`">
		<div class="actions">
			<q-button
				b-style="primary"
				:label="texts.okLabel"
				:title="texts.okLabel"
				@click="$emit('hide-popup')">
				<q-icon icon="ok" />
			</q-button>
		</div>
	</teleport>
</template>

<script>
	export default {
		name: 'QDocumentProperties',

		emits: ['hide-popup'],

		inheritAttrs: false,

		props: {
			/**
			 * Unique ID for the control.
			 */
			controlId: String,

			/**
			 * Necessary strings to be used in labels and buttons.
			 */
			texts: {
				type: Object,
				required: true
			},

			/**
			 * The properties of the document.
			 */
			fileProperties: {
				type: Object,
				default: () => ({})
			}
		},

		expose: []
	}
</script>
