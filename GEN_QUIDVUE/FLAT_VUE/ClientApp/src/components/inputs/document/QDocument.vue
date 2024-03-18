<template>
	<div :id="controlId">
		<q-input-group :size="size">
			<!-- Input form where attached file name shows -->
			<q-text-field
				:model-value="modelValue"
				readonly
				:placeholder="texts.attachDocumentPlaceHolder"
				:style="{ color: `${activeColor} !important`, cursor: modelValue ? 'pointer' : 'normal' }"
				:aria-labelledby="labelId"
				@click.stop.prevent="getFile" />

			<template #append>
				<q-button
					ref="optionsButton"
					b-style="secondary"
					data-toggle="dropdown"
					aria-haspopup="true"
					:title="texts.actionLabel"
					:disabled="isOptionsButtonDisabled"
					@click="setDropdownState(null, false)">
					<q-icon icon="more-items" />
				</q-button>
			</template>
		</q-input-group>

		<!-- Dropdown menu items -->
		<ul
			v-if="!disabled"
			ref="optionsMenu"
			:class="['dropdown-menu', { show: showOptions }]">
			<!-- Download menu item -->
			<li
				:class="['dropdown-item', { disabled: !modelValue }]"
				:title="texts.downloadLabel"
				@click.stop.prevent="downloadFile">
				<q-icon icon="download" /> {{ texts.downloadLabel }}
			</li>

			<!-- Attach menu item -->
			<li
				v-if="!readonly && (!versioningIsOn || !modelValue)"
				class="dropdown-item"
				:title="texts.attachLabel">
				<q-icon icon="attachment" /> {{ texts.attachLabel }}

				<input
					:id="`docum-file-${controlId}`"
					class="q-document-input__attach"
					type="file"
					data-testid="input-file"
					:name="`docum-file-${controlId}`"
					:accept="extensions"
					@change="attachFile" />
			</li>

			<!-- Submit menu item -->
			<li
				v-if="!readonly && versioningIsOn && isInCheckout"
				class="dropdown-item"
				:title="texts.submitLabel"
				@click.stop.prevent="setFileSubmitModalState(true)">
				<q-icon icon="upload" /> {{ texts.submitLabel }}
			</li>

			<!-- Edit menu item -->
			<li
				v-if="!readonly && versioningIsOn && !isInCheckout && modelValue"
				class="dropdown-item"
				:title="texts.editLabel"
				@click.stop.prevent="editFile">
				<q-icon icon="pencil" /> {{ texts.editLabel }}
			</li>

			<!-- Delete menu item -->
			<li
				v-if="!readonly && !disallowRemoval"
				:class="['dropdown-item', { disabled: isInCheckout || !modelValue }]"
				:title="texts.deleteLabel"
				@click.stop.prevent="confirmFileDelete">
				<q-icon icon="delete" /> {{ texts.deleteLabel }}
			</li>

			<!-- Version dropdown menu item starts here -->
			<li
				v-if="versioningIsOn && !isInCheckout && versionCount > 1"
				class="dropdown-submenu">
				<a
					class="dropdown-item"
					data-toggle="dropdown"
					aria-haspopup="true"
					href="javascript:void(0)"
					:title="texts.versionsLabel"
					@click="setDropdownState($event, !showVersionsSubMenu, false)">
					<q-icon icon="list" /> {{ texts.versionsLabel }}
				</a>

				<!-- Versions sub menu item -->
				<ul :class="['dropdown-menu', { show: showVersionsSubMenu }]">
					<!-- View versions history menu item -->
					<li
						class="dropdown-item"
						:title="texts.viewAll"
						@click.stop.prevent="viewAllVersions">
						<q-icon icon="properties" /> {{ texts.viewAllLabel }}
					</li>

					<li class="dropdown-divider"></li>

					<!-- Available versions -->
					<li
						v-for="version in visibleVersionNumbers"
						:key="version"
						class="dropdown-item"
						:title="`${texts.downloadLabel} ${version}`"
						@click.stop.prevent="downloadVersion(version)">
						<q-icon icon="download" /> {{ version }}
					</li>

					<li
						v-if="!readonly"
						class="dropdown-divider"></li>

					<!-- Delete last item menu -->
					<li
						v-if="!readonly"
						class="dropdown-item"
						:title="texts.deleteLastLabel"
						@click.stop.prevent="confirmDeleteLast">
						<q-icon icon="delete" /> {{ texts.deleteLastLabel }}
					</li>

					<!-- Delete history menu item -->
					<li
						v-if="!readonly"
						class="dropdown-item"
						:title="texts.deleteHistoryLabel"
						@click.stop.prevent="confirmDeleteHistory">
						<q-icon icon="delete" /> {{ texts.deleteHistoryLabel }}
					</li>
				</ul>
			</li>

			<!-- Create document menu item -->
			<li
				v-if="!readonly && usesTemplates"
				class="dropdown-item"
				:title="texts.createDocument"
				@click.stop.prevent="createDocument">
				<q-icon icon="plus" /> {{ texts.createDocument }}
			</li>

			<li class="dropdown-divider"></li>

			<!-- Properties menu item -->
			<li
				:class="['dropdown-item', { disabled: !modelValue }]"
				:title="texts.propertyLabel"
				@click.stop.prevent="getProperties">
				<q-icon icon="properties" /> {{ texts.propertyLabel }}
			</li>
		</ul>

		<q-document-properties
			v-if="popupIsVisible && showProperties"
			:control-id="controlId"
			:texts="texts"
			:file-properties="fileProperties"
			@hide-popup="setPropertiesModalState(false)" />

		<q-document-submit
			v-if="popupIsVisible && showFileSubmit"
			:control-id="controlId"
			:texts="texts"
			:label-id="labelId"
			:extensions="extensions"
			:current-version="currentVersion"
			:max-file-size="maxFileSize"
			:minor-version-value="minorVersionValue"
			:major-version-value="majorVersionValue"
			@set-minor-version="setMinorVersion"
			@set-major-version="setMajorVersion"
			@submit-file="submitFileVersion"
			@hide-popup="setFileSubmitModalState(false)" />

		<q-document-versions
			v-if="popupIsVisible && showVersions"
			:control-id="controlId"
			:texts="texts"
			:readonly="readonly"
			:versions="versions"
			:versions-info="versionsInfo"
			:resources-path="resourcesPath"
			@get-file-version="downloadVersion"
			@delete-last="confirmDeleteLast"
			@delete-history="confirmDeleteHistory" />
	</div>
</template>

<script>
	import { defineAsyncComponent } from 'vue'
	import Popper from 'popper.js'
	import _isEmpty from 'lodash-es/isEmpty'

	import { displayMessage, validateFileExtAndSize, validateTexts } from '@/mixins/genericFunctions.js'
	import { inputSize } from '@/mixins/quidgest.mainEnums.js'

	// The texts needed by the component.
	const DEFAULT_TEXTS = {
		downloadLabel: 'Download',
		attachLabel: 'Attach',
		submitLabel: 'Submit',
		chooseFileLabel: 'Choose file',
		editLabel: 'Edit',
		deleteLabel: 'Delete',
		propertyLabel: 'Properties',
		versionsLabel: 'Versions',
		viewAllLabel: 'View all...',
		deleteLastLabel: 'Delete last',
		deleteHistoryLabel: 'Delete history',
		nameLabel: 'Name: ',
		sizeLabel: 'Size: ',
		extensionLabel: 'Extension: ',
		authorLabel: 'Author: ',
		createdDateLabel: 'Create date: ',
		createdOnLabel: 'Created on',
		currentVersionLabel: 'Current version: ',
		editedByLabel: 'Edition by: ',
		okLabel: 'OK',
		yesLabel: 'Yes',
		noLabel: 'No',
		filesSubmission: 'Submission of files',
		noFileSelected: 'No file selected for submission.',
		fileSizeError: 'The selected file exceeds the allowed size of {0}.',
		extensionError: 'Invalid extension! Allowed extensions:',
		submitHeaderLabel: 'Select the file to be submitted: ',
		unlockHeaderLabel: 'Unlock: discards the current changes and the document will be free for editing.',
		submitFilesHeaderLabel: 'Submit: the document will be free for editing and a new version will be created.',
		majorVersionLabel: 'Major version',
		minorVersionLabel: 'Minor version',
		cancelLabelValue: 'Cancel',
		version: 'Version',
		documentLabel: 'Document',
		bytesLabel: 'Bytes',
		author: 'Author',
		deleteHeaderLabel: 'Are you sure you want to delete?',
		attachDocumentPlaceHolder: 'Attach document',
		actionLabel: 'Actions',
		viewAll: 'View all',
		closeLabel: 'Close',
		theLastVersionWillEliminate: 'The last version will be eliminated.\\r\\nAre you sure you want to delete?',
		allTheVersionsExceptLastWillEliminate: 'All the versions except the last will be deleted.\\r\\nAre you sure you want to delete?',
		uploadDocVersionHeader: 'Document versions',
		createDocument: 'Create document'
	}

	export default {
		name: 'QDocument',

		emits: {
			'delete-file': () => true,
			'delete-history': () => true,
			'delete-last': () => true,
			'download-file': () => true,
			'edit-file': () => true,
			'file-error': (payload) => typeof payload === 'number',
			'get-file': () => true,
			'get-file-version': (payload) => typeof payload === 'string',
			'get-properties': () => true,
			'get-version-history': () => true,
			'hide-popup': (payload) => typeof payload === 'string',
			'show-popup': (payload) => typeof payload === 'object',
			'show-templates-popup': () => true,
			'submit-file': (payload) => typeof payload === 'object'
		},

		components: {
			QDocumentSubmit: defineAsyncComponent(() => import('./popups/QDocumentSubmit.vue')),
			QDocumentVersions: defineAsyncComponent(() => import('./popups/QDocumentVersions.vue')),
			QDocumentProperties: defineAsyncComponent(() => import('./popups/QDocumentProperties.vue'))
		},

		inheritAttrs: false,

		props: {
			/**
			 * Unique identifier for the control.
			 */
			id: String,

			/**
			 * The name of the current version of the file.
			 */
			modelValue: String,

			/**
			 * Necessary strings to be used in labels and buttons.
			 */
			texts: {
				type: Object,
				validator: (value) => validateTexts(DEFAULT_TEXTS, value),
				default: () => DEFAULT_TEXTS
			},

			/**
			 * Extensions allowed for file select, some extension examples: .png, .jpg, .jpeg, .csv, .xls, .xlsx, .pdf.
			 */
			extensions: {
				type: Array,
				default: () => []
			},

			/**
			 * Maximum file size allowed, in bytes (must be a positive number).
			 */
			maxFileSize: {
				type: Number,
				validator: (value) => value >= 0,
				default: 0
			},

			/**
			 * Whether or not versioning is active for the document.
			 */
			versioningIsOn: {
				type: Boolean,
				default: false
			},

			/**
			 * Property to define the size of the component.
			 */
			size: {
				type: String,
				validator: (value) => _isEmpty(value) || Reflect.has(inputSize, value)
			},

			/**
			 * Whether the field is disabled.
			 */
			disabled: {
				type: Boolean,
				default: false
			},

			/**
			 * Whether the field is readonly.
			 */
			readonly: {
				type: Boolean,
				default: false
			},

			/**
			 * The properties of the document.
			 */
			fileProperties: {
				type: Object,
				default: () => ({})
			},

			/**
			 * Whether or not the document is currently being edited by someone.
			 */
			isInCheckout: {
				type: Boolean,
				default: false
			},

			/**
			 * The current version of the document.
			 */
			currentVersion: {
				type: String,
				default: '1'
			},

			/**
			 * The current version numbers of the document.
			 */
			versions: {
				type: Object,
				default: () => ({})
			},

			/**
			 * The details about the version history of the document.
			 */
			versionsInfo: {
				type: Array,
				default: () => []
			},

			/**
			 * Whether or not one of the popups is currently open.
			 */
			popupIsVisible: {
				type: Boolean,
				default: false
			},

			/**
			 * Whether or not the current version of the document can be deleted.
			 */
			disallowRemoval: {
				type: Boolean,
				default: false
			},

			/**
			 * The resources path.
			 */
			resourcesPath: {
				type: String,
				required: true
			},

			/**
			 * Indicates whether the control uses document templates.
			 */
			usesTemplates: {
				type: Boolean,
				default: false
			}
		},

		provide()
		{
			return {
				validateFile: this.validateFile,
				downloadVersion: this.downloadVersion
			}
		},

		// TODO: Remove these properties from the "expose" (only necessary for unit tests).
		expose: [
			'maxFileSize'
		],

		data()
		{
			return {
				// The id of the component.
				controlId: this.id || `q-file-input-${this._.uid}`,

				// The max number of visible versions in the submenu dropdown.
				maxVisibleVersions: 5,

				// The properties of the current file.
				properties: {},

				// Whether or not the properties popup is visible.
				showProperties: false,

				// Whether or not the file submit popup is visible.
				showFileSubmit: false,

				// Whether or not the version history popup is visible.
				showVersions: false,

				// Whether or not the versions dropdown menu is visible.
				showOptions: false,

				// Whether or not the versions dropdown sub-menu is visible.
				showVersionsSubMenu: false,

				// The default minor version value.
				minorVersionValue: '',

				// The default major version value.
				majorVersionValue: '',

				// The options menu popper object.
				popper: null
			}
		},

		mounted()
		{
			this.bindOutsideClickListener()
		},

		beforeUnmount()
		{
			this.unbindOutsideClickListener()
		},

		computed: {
			/**
			 * The identifier of the component's label.
			 */
			labelId()
			{
				return `label_${this.controlId}`
			},

			/**
			 * The color of the displayed document name.
			 */
			activeColor()
			{
				return this.isInCheckout ? '#4CAF50' : '#747C91'
			},

			/**
			 * The number of document versions.
			 */
			versionCount()
			{
				return this.versions ? Object.keys(this.versions).length : 0
			},

			/**
			 * An array with all the version numbers, ordered in ascendent order.
			 */
			versionNumbers()
			{
				var versionsArray = []

				for (let i in this.versions)
					versionsArray.push(i)

				return versionsArray.sort()
			},

			/**
			 * An array with only the N most recent version numbers (N = maxVisibleVersions).
			 */
			visibleVersionNumbers()
			{
				var array = this.versionNumbers
				return array.slice(Math.max(array.length - this.maxVisibleVersions, 0))
			},

			/**
			 * Whether the options button is disabled.
			 */
			isOptionsButtonDisabled()
			{
				return this.disabled || (this.readonly && !this.modelValue)
			}
		},

		methods: {
			/**
			 * Sets the value of the major version.
			 * @param {string} value The value
			 */
			setMinorVersion(value)
			{
				this.minorVersionValue = value
			},

			/**
			 * Sets the value of the minor version.
			 * @param {string} value The value
			 */
			setMajorVersion(value)
			{
				this.majorVersionValue = value
			},

			/**
			 * Validates the attached file, if everything's ok calls the callback function, if one is provided.
			 * @param {object} event The file attach event
			 * @param {function} callback The callback function
			 */
			validateFile(event, callback)
			{
				const file = event.target.files[0]
				const validationResult = validateFileExtAndSize(file, this.extensions, this.maxFileSize)

				if (validationResult === 0 && typeof callback === 'function')
					callback(file)
				else
					this.$emit('file-error', validationResult)

				// Clears the value, so that the next "change" event will trigger even if the file name is the same.
				event.target.value = ''
			},

			/**
			 * Retrieves the attached file object and emits an event with it.
			 * @param {object} event The file attach event
			 */
			attachFile(event)
			{
				const callback = (file) => {
					this.$emit('submit-file', { file, version: this.currentVersion })
				}

				this.validateFile(event, callback)
			},

			/**
			 * Emits the event with the newly submitted version of the document.
			 * @param {object} file The attached file
			 */
			submitFileVersion(file)
			{
				this.$emit('submit-file', file)
				this.setFileSubmitModalState(false)
			},

			/**
			 * Emits the event to fetch the properties of the document from the server.
			 */
			getProperties()
			{
				this.$emit('get-properties')
			},

			/**
			 * Emits the event to display the current version of the document in a new tab.
			 */
			getFile()
			{
				if (this.modelValue)
					this.$emit('get-file')
			},

			/**
			 * Emits the event to download the current version of the document from the server.
			 */
			downloadFile()
			{
				if (this.modelValue)
					this.$emit('download-file')
			},

			/**
			 * Emits the event to download the specified version of the document from the server.
			 * @param {string} version The id of the version to be downloaded
			 */
			downloadVersion(version)
			{
				this.$emit('get-file-version', version)
			},

			/**
			 * Emits the event to fetch the details of all versions of the document from the server.
			 */
			viewAllVersions()
			{
				this.$emit('get-version-history')
			},

			/**
			 * Emits the event to put the document in "Edit" mode.
			 */
			editFile()
			{
				this.$emit('edit-file')
			},

			/**
			 * Emits the event to delete the document and all it's versions.
			 */
			deleteFile()
			{
				this.$emit('delete-file')
			},

			/**
			 * Emits the event to delete the last version of the document.
			 */
			deleteLastVersion()
			{
				this.$emit('delete-last')
				this.setVersionsModalState(false)
			},

			/**
			 * Emits the event to delete the document history.
			 */
			deleteFileHistory()
			{
				this.$emit('delete-history')
				this.setVersionsModalState(false)
			},

			/**
			 * Confirmation window for the deletion of the document.
			 */
			confirmFileDelete()
			{
				const buttons = {
					confirm: {
						label: this.texts.yesLabel,
						action: this.deleteFile
					},
					cancel: {
						label: this.texts.noLabel
					}
				}

				displayMessage(this.texts.deleteHeaderLabel, 'question', null, buttons)
			},

			/**
			 * Confirmation window for the deletion of the last version of the document.
			 */
			confirmDeleteLast()
			{
				const buttons = {
					confirm: {
						label: this.texts.yesLabel,
						action: this.deleteLastVersion
					},
					cancel: {
						label: this.texts.noLabel
					}
				}

				displayMessage(this.texts.theLastVersionWillEliminate, 'question', null, buttons)
			},

			/**
			 * Confirmation window for the deletion of the document history.
			 */
			confirmDeleteHistory()
			{
				const buttons = {
					confirm: {
						label: this.texts.yesLabel,
						action: this.deleteFileHistory
					},
					cancel: {
						label: this.texts.noLabel
					}
				}

				displayMessage(this.texts.allTheVersionsExceptLastWillEliminate, 'question', null, buttons)
			},

			/**
			 * Sets the visibility of the properties popup.
			 * @param {boolean} isVisible The state of the popup
			 */
			setPropertiesModalState(isVisible)
			{
				const modalId = `file-properties-${this.controlId}`

				if (isVisible)
				{
					const modalProps = {
						id: modalId,
						props: {
							modalWidth: 'md',
							headerTitle: this.texts.propertyLabel,
							dismissAction: () => this.setPropertiesModalState(false)
						}
					}
					this.$emit('show-popup', modalProps)
				}
				else
					this.$emit('hide-popup', modalId)

				this.showProperties = isVisible
			},

			/**
			 * Sets the visibility of the file submit popup.
			 * @param {boolean} isVisible The state of the popup
			 */
			setFileSubmitModalState(isVisible)
			{
				const modalId = `submit-file-${this.controlId}`

				if (isVisible)
				{
					const version = Number(this.currentVersion)

					// If the popup is being opened, the default values of the versions need to be updated.
					if (!isNaN(version))
					{
						this.setMinorVersion((version + 0.1).toFixed(1))
						this.setMajorVersion((Math.floor(version) + 1).toString())
					}
					else
					{
						this.setMinorVersion('')
						this.setMajorVersion('')
					}

					const modalProps = {
						id: modalId,
						props: {
							headerTitle: this.texts.filesSubmission,
							dismissAction: () => this.setFileSubmitModalState(false)
						}
					}
					this.$emit('show-popup', modalProps)
				}
				else
					this.$emit('hide-popup', modalId)

				this.showFileSubmit = isVisible
			},

			/**
			 * Sets the visibility of the versions popup.
			 * @param {boolean} isVisible The state of the popup
			 */
			setVersionsModalState(isVisible)
			{
				const modalId = `file-versions-${this.controlId}`

				if (isVisible)
				{
					const modalProps = {
						id: modalId,
						props: {
							headerTitle: this.texts.uploadDocVersionHeader,
							hideFooter: this.disabled || this.readonly,
							dismissAction: () => this.setVersionsModalState(false)
						}
					}
					this.$emit('show-popup', modalProps)
				}
				else
					this.$emit('hide-popup', modalId)

				this.showVersions = isVisible
			},

			/**
			 * Sets the visibility of the options dropdown, either open or closed.
			 * @param {object} event The mouse click event
			 * @param {boolean} isVisible The state of the dropdown
			 * @param {boolean} affectDropdown Whether or not to affect the entire dropdown
			 */
			setDropdownState(event, isVisible, affectDropdown = true)
			{
				if (affectDropdown)
				{
					if (this.popper === null)
					{
						this.popper = new Popper(this.$refs.optionsButton?.$el, this.$refs.optionsMenu, {
							placement: 'bottom-start',
							onCreate: () => { this.showOptions = !this.showOptions },
							modifiers: {
								preventOverflow: {
									enabled: true,
									boundariesElement: 'window'
								}
							}
						})
					}
					else
						this.showOptions = !this.showOptions
				}

				this.showVersionsSubMenu = isVisible

				if (event === null)
					return

				event.stopPropagation()
				event.preventDefault()
			},

			/**
			 * Triggered when the user clicks on the page.
			 * @param event The click event
			 */
			outsideClickListener(event)
			{
				if (
					!(
						this.$refs.optionsButton?.$el?.contains(event.target) ||
						this.$refs.optionsMenu?.contains(event.target)
					)
				)
					this.showOptions = false
			},

			/**
			 * Binds a listener to check for a click event.
			 */
			bindOutsideClickListener()
			{
				window.addEventListener('mousedown', this.outsideClickListener)
				this.hasClickListener = true
			},

			/**
			 * Unbinds the click listener.
			 */
			unbindOutsideClickListener()
			{
				window.removeEventListener('mousedown', this.outsideClickListener)
				this.hasClickListener = false
			},

			/**
			 * Emit event to open popup with document templates.
			 */
			createDocument()
			{
				this.$emit('show-templates-popup')
			}
		},

		watch: {
			fileProperties()
			{
				if (Object.keys(this.fileProperties).length > 0)
					this.setPropertiesModalState(true)
			},

			versionsInfo()
			{
				if (this.versionsInfo.length > 0)
					this.setVersionsModalState(true)
			}
		}
	}
</script>
