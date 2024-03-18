<template>
	<teleport :to="`#q-modal-submit-file-${controlId}-body`">
		<div class="content">
			<div class="form-flow">
				<div class="row no-gutters">
					<div class="col-12">
						<q-row-container>
							<label
								class="flow-label"
								:for="`file-submit-${controlId}`">
								{{ texts.submitHeaderLabel }}
							</label>
						</q-row-container>

						<q-row-container>
							<div class="control-join-group">
								<q-input-group>
									<q-text-field
										:model-value="submittedFileName"
										readonly
										:placeholder="texts.attachDocumentPlaceHolder"
										@click.stop.prevent="handleFileUpload" />
									<template #append>
										<q-button
											b-style="secondary"
											:label="texts.chooseFileLabel"
											:title="texts.chooseFileLabel"
											@click="handleFileUpload">
											<q-icon icon="choose-file" />
										</q-button>
									</template>
								</q-input-group>
								<input
									:id="`doc-file-${controlId}`"
									class="d-none"
									ref="fileInput"
									name="doc-file"
									type="file"
									:aria-labelledby="labelId"
									:accept="extensions"
									@change="attachFileVersion" />
							</div>
						</q-row-container>
					</div>
				</div>

				<hr />

				<!-- Unlock radio option -->
				<div class="row no-gutters">
					<div class="col-12">
						<div class="row-large-control">
							<div class="row-line-group">
								<label
									class="i-radio version-option"
									:for="`unlock-${controlId}`">
									{{ texts.unlockHeaderLabel }}

									<input
										:id="`unlock-${controlId}`"
										class="i-radio"
										type="radio"
										v-model="versionSubmitMode"
										:value="versionSubmitModes.unlock"
										:name="`unlock-${controlId}`" />

									<span class="i-radio__field"></span>
								</label>
							</div>
						</div>
					</div>
				</div>

				<!-- Submit radio option -->
				<div class="row no-gutters">
					<div class="col-12">
						<div class="row-large-control">
							<div class="row-line-group">
								<label
									class="i-radio version-option"
									:for="`submit-${controlId}`">
									{{ texts.submitFilesHeaderLabel }}

									<input
										:id="`submit-${controlId}`"
										class="i-radio"
										type="radio"
										v-model="versionSubmitMode"
										:value="versionSubmitModes.submit"
										:name="`submit-${controlId}`" />

									<span class="i-radio__field"></span>
								</label>
							</div>
						</div>
					</div>
				</div>

				<div class="row no-gutters">
					<div class="col-11 offset-1">
						<div class="version-type-options">
							<!-- Major version input -->
							<div class="version-option">
								<div class="version-option-content">
									<label
										:class="[
											{ 'i-radio--disabled': versionSubmitMode === versionSubmitModes.unlock },
											'i-radio',
											'i-radio__label',
											'i-radio--inline'
										]"
										:for="`major-version-check-${controlId}`">
										{{ texts.majorVersionLabel }}

										<input
											:id="`major-version-check-${controlId}`"
											class="i-radio"
											type="radio"
											v-model="versionType"
											:value="versionTypes.major"
											:disabled="versionSubmitMode === versionSubmitModes.unlock"
											:name="`major-version-check-${controlId}`" />

										<span class="i-radio__field"></span>
									</label>

									<q-text-field 
										:model-value="majorVersionValue"
										size="small"
										:readonly="versionSubmitMode === versionSubmitModes.unlock"
										@update:model-value="setMajorVersion" />
								</div>
							</div>

							<!-- Minor version input -->
							<div class="version-option">
								<div class="version-option-content">
									<label
										:class="[
											{ 'i-radio--disabled': versionSubmitMode === versionSubmitModes.unlock },
											'i-radio',
											'i-radio__label',
											'i-radio--inline'
										]"
										:for="`minor-version-check-${controlId}`">
										{{ texts.minorVersionLabel }}

										<input
											:id="`minor-version-check-${controlId}`"
											class="i-radio"
											type="radio"
											v-model="versionType"
											:value="versionTypes.minor"
											:disabled="versionSubmitMode === versionSubmitModes.unlock"
											:name="`minor-version-check-${controlId}`" />

										<span class="i-radio__field"></span>
									</label>

									<q-text-field
										:model-value="minorVersionValue"
										size="small"
										:readonly="versionSubmitMode === versionSubmitModes.unlock"
										@update:model-value="setMinorVersion" />
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</teleport>

	<teleport :to="`#q-modal-submit-file-${controlId}-footer`">
		<div class="actions float-right">
			<q-button
				b-style="primary"
				:label="texts.submitLabel"
				:title="texts.submitLabel"
				@click="submitFileVersion">
				<q-icon icon="submit" />
			</q-button>

			<q-button
				b-style="secondary"
				:label="texts.cancelLabelValue"
				:title="texts.cancelLabelValue"
				@click="$emit('hide-popup')">
				<q-icon icon="cancel" />
			</q-button>
		</div>
	</teleport>
</template>

<script>
	import { displayMessage } from '@/mixins/genericFunctions.js'

	export default {
		name: 'QDocumentSubmit',

		emits: [
			'set-minor-version',
			'set-major-version',
			'submit-file',
			'hide-popup'
		],

		inheritAttrs: false,

		props: {
			/**
			 * Unique ID for the control.
			 */
			controlId: String,

			/**
			 * The ID of the component's label.
			 */
			labelId: String,

			/**
			 * Necessary strings to be used in labels and buttons.
			 */
			texts: {
				type: Object,
				required: true
			},

			/**
			 * Extensions allowed for file select, some extension examples: .png, .jpg, .jpeg, .csv, .xls, .xlsx, .pdf.
			 */
			extensions: {
				type: Array,
				default: () => []
			},

			/**
			 * The current version of the document.
			 */
			currentVersion: {
				type: String,
				default: '1'
			},

			/**
			 * The value of the minor version.
			 */
			minorVersionValue: {
				type: String,
				default: ''
			},

			/**
			 * The value of the major version.
			 */
			majorVersionValue: {
				type: String,
				default: ''
			}
		},

		inject: [
			'validateFile'
		],

		expose: [],

		data()
		{
			return {
				// The data of a newly submitted document version (not yet stored server-side).
				submittedFileData: null,

				// The possible types of versions.
				versionTypes: {
					minor: 'Minor',
					major: 'Major'
				},

				// The selected type of version.
				versionType: 'Major',

				// The possible modes of version submission.
				versionSubmitModes: {
					unlock: 'UnlockFile',
					submit: 'Submit'
				},

				// The selected mode of version submission.
				versionSubmitMode: 'Submit'
			}
		},

		computed: {
			/**
			 * The name of the newly submitted version of the document.
			 */
			submittedFileName()
			{
				return this.submittedFileData ? this.submittedFileData.name : ''
			}
		},

		methods: {
			/**
			 * Emits the event to set the minor version.
			 * @param {object} newVal The new value of the minor version
			 */
			setMinorVersion(newVal)
			{
				this.$emit('set-minor-version', newVal)
			},

			/**
			 * Emits the event to set the major version.
			 * @param {object} newVal The new value of the major version
			 */
			setMajorVersion(newVal)
			{
				this.$emit('set-major-version', newVal)
			},

			/**
			 * Triggers the click event on the file input.
			 */
			handleFileUpload()
			{
				this.$refs.fileInput.click()
			},

			/**
			 * Retrieves the attached file object and keeps it's data.
			 * @param {object} event The file attach event
			 */
			attachFileVersion(event)
			{
				const callback = (fileData) => {
					this.submittedFileData = fileData
				}

				this.validateFile(event, callback)
			},

			/**
			 * Emits the event with the newly submitted version of the document.
			 */
			submitFileVersion()
			{
				var version = this.minorVersionValue
				if (this.versionType === this.versionTypes.major)
					version = this.majorVersionValue

				if (this.versionSubmitMode === this.versionSubmitModes.submit)
				{
					if (this.submittedFileName === '')
					{
						displayMessage(this.texts.noFileSelected)
						return
					}

					this.$emit('submit-file', { file: this.submittedFileData, isNewVersion: true, version })
				}
				else if (this.versionSubmitMode === this.versionSubmitModes.unlock)
					this.$emit('submit-file', { isNewVersion: false, version })

				this.submittedFileData = null
			}
		}
	}
</script>
