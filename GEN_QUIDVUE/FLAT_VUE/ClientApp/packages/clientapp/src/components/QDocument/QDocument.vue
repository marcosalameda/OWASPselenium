<template>
	<div
		:id="`${props.id}-container`"
		class="q-document"
		:class="{ 'q-document--readonly': readonly }">
		<q-input-group
			:size="props.size"
			class="q-document__input">
			<!-- Input - only to show the file name -->
			<q-text-field
				:id="props.id"
				:model-value="model"
				data-testid="document-input"
				readonly
				@click="handleInputClick" />

			<!-- Dropdown actions -->
			<q-action-list
				:groups="groups"
				:items="items"
				@click="handleDropdownClick" />
		</q-input-group>

		<!-- Invisible input used to attach files -->
		<input
			:id="`q-document-file-${props.id}`"
			ref="fileAttach"
			class="q-document__attach"
			type="file"
			data-testid="file-input"
			:accept="extensions.join(' ')"
			@on-change="handleUpdateFileEvent" />
		<!--  -->

		<div
			v-if="!props.disabled && !props.readonly && props.versioning && props.editing"
			class="q-document__editing">
			<q-icon icon="information" /> {{ props.texts.editingDocument }}
		</div>

		<!-- Dialog with the list of properties -->
		<q-document-properties
			v-model="showProperties"
			:texts="props.texts"
			:file-properties="fileProperties" />

		<!-- Dialog to submit new versions of the document -->
		<q-document-submit
			v-model="showFileSubmit"
			:id="props.id"
			:current-version="currentVersion"
			:texts="props.texts"
			@submit-file="submitFileVersion" />

		<!-- Dialog with the list of current versions -->
		<q-document-versions
			v-model="showVersions"
			:versions-info="props.versionsInfo"
			:texts="props.texts"
			:resources-path="props.resourcesPath"
			@get-file="getFile"
			@delete-last="handleDropdownClick('delete-last')"
			@delete-history="handleDropdownClick('delete-history')" />
	</div>
</template>

<script setup lang="ts">
	// Constants
	import { inputSize } from '../../constants/enums'

	// Utils
	import { ref, nextTick, useTemplateRef } from 'vue'
	import { DEFAULT_TEXTS } from './constants'
	import { useDropdown } from './composables/useDropdown'
	import {
		displayMessage,
		validateFileExtAndSize,
		isEmpty,
		validateTexts
	} from '../../utils/genericFunctions'

	// Components
	import { QActionList } from '../QActionList'
	import QDocumentProperties from './QDocumentProperties.vue'
	import QDocumentSubmit from './QDocumentSubmit.vue'
	import QDocumentVersions from './QDocumentVersions.vue'

	// Types
	import type { QDocumentProps, SubmitFile, GetFile } from './types'

	const props = withDefaults(defineProps<QDocumentProps>(), {
		texts: () => DEFAULT_TEXTS,
		extensions: () => [],
		fileProperties: () => ({}),
		maxFileSize: 0,
		versioning: false,
		disabled: false,
		readonly: false,
		editing: false,
		currentVersion: '1',
		versions: () => ({}),
		versionsInfo: () => [],
		popupIsVisible: false,
		usesTemplates: false
	})

	function validateProps() {
		if (!validateTexts(DEFAULT_TEXTS, props.texts))
			// eslint-disable-next-line no-console
			console.error('Invalid texts prop:', props.texts)
		if (!isEmpty(props.size as string | undefined) && !Reflect.has(inputSize, props.size || ''))
			// eslint-disable-next-line no-console
			console.error('Invalid size prop:', props.size)
	}

	const emit = defineEmits<{
		(e: 'delete-file'): void
		(e: 'delete-history'): void
		(e: 'delete-last'): void
		(e: 'edit-file'): void
		(e: 'file-error', result: number): void
		(e: 'get-file', file: GetFile): void
		(e: 'get-properties'): void
		(e: 'get-version-history'): void
		(e: 'show-templates-popup'): void
		(e: 'submit-file', file: SubmitFile): void
	}>()

	validateProps()

	const model = defineModel<string>()

	// Template Refs
	const fileAttachRef = useTemplateRef('fileAttach')

	// State refs
	const showProperties = ref<boolean>(false)
	const showFileSubmit = ref<boolean>(false)
	const showVersions = ref<boolean>(false)

	/**
	 * Logic to create the actions and groups for the dropdown
	 */
	const { items, groups } = useDropdown(props, model)

	/**
	 * Handles the click event on the dropdown.
	 * @param {string} itemKey The key of the item
	 */
	async function handleDropdownClick(itemKey: string) {
		if (itemKey.includes('version-')) {
			const version = itemKey.replace('version-', '').trim()
			getFile(version)
		}

		switch (itemKey) {
			case 'attach':
				await attachFile()
				break
			case 'download':
				getFile()
				break
			case 'submit':
				setShowFileSubmit(true)
				break
			case 'edit':
				editFile()
				break
			case 'delete':
				deleteFile()
				break
			case 'delete-last':
				deleteFile(true)
				break
			case 'delete-history':
				deleteFile(false, true)
				break
			case 'properties':
				getProperties()
				break
			case 'document-history':
				viewAllVersions()
				break
			case 'create':
				createDocument()
				break
			default:
				break
		}
	}

	/**
	 * Handles the click event on the document input.
	 */
	async function handleInputClick() {
		if (!model.value) await attachFile()
		else getFile(undefined, false)
	}

	/**
	 * Triggers the file attach window.
	 */
	async function attachFile() {
		// Clears the input before updating (doens't work without this if the model is filed already)
		await nextTick(() => fileAttachRef.value?.click())
	}

	/**
	 * Validates the attached file, if everything's ok calls the callback function, if one is provided.
	 * @param {object} event The file attach event
	 * @param {function} callback The callback function
	 */
	function validateFile(file: File, callback: (file: File) => void) {
		const validationResult: number = validateFileExtAndSize(
			file,
			props.extensions,
			props.maxFileSize || 0
		)

		if (validationResult === 0 && typeof callback === 'function') callback(file)
		else emit('file-error', validationResult)
	}

	/**
	 * Handles the input event to update the file
	 * @param {Event} event The file attach event
	 */
	function handleUpdateFileEvent(event: Event & { target: HTMLInputElement }) {
		const input = event.target
		if (!input?.files?.[0]) return
		updateFile(input.files[0])
	}

	/**
	 * Emits an event with the attached file object
	 * @param {File} file The file
	 * @param {string} newVersion The new version to save
	 * @param {boolean} unlock Wether or not to unlock the input
	 */
	function updateFile(file: File, newVersion?: string, unlock?: boolean) {
		function attach(validatedfile: File) {
			emit('submit-file', {
				file: validatedfile,
				version: newVersion || props.currentVersion || '1',
				isNewVersion: unlock ? false : true
			})
		}
		validateFile(file, attach)
	}

	/**
	 * Submits a new file versions
	 * @param {SubmitFile} payload - The payload with the file and new version
	 */
	function submitFileVersion(payload: SubmitFile) {
		if (!payload.file) return
		updateFile(payload.file, payload.version, payload.unlock)
	}

	/**
	 * Emits an event to update the document to "Edit" mode
	 */
	function editFile() {
		emit('edit-file')
	}

	/**
	 * Confirmation window for the deletion of a document.
	 * @param {string} question The question to present to the user
	 * @param {function} action The action to be executed in case the user wants to proceed
	 */
	function deleteValidation(question: string, action: () => void) {
		const buttons = {
			confirm: { label: props.texts.yesLabel, action },
			cancel: { label: props.texts.noLabel }
		}

		displayMessage(question, 'question', undefined, buttons)
	}

	/**
	 * Emits an event to delete the document attached
	 * @param {boolean} last Whether or not to delete the last version of the document
	 * @param {boolean} history Whether or not to delete the document history
	 */
	function deleteFile(last?: boolean, history?: boolean) {
		if (last && !history)
			deleteValidation(props.texts.theLastVersionWillEliminate, () => emit('delete-last'))
		else if (!last && history)
			deleteValidation(props.texts.allTheVersionsExceptLastWillEliminate, () =>
				emit('delete-history')
			)
		else deleteValidation(props.texts.deleteHeaderLabel, () => emit('delete-file'))
	}

	/**
	 * Emits the event to get the specified version of the document.
	 * @param {string} version The id of the version
	 * @param {boolean} download Whether to force the file download
	 */
	function getFile(version: string | undefined = undefined, download: boolean = true) {
		if (!model.value) return

		emit('get-file', { version: version ?? props.currentVersion, download })
	}

	function viewAllVersions() {
		emit('get-version-history')
		setShowVersions(true)
	}

	/**
	 * Emits the event to fetch the properties of the document from the server.
	 */
	function getProperties() {
		if (!model.value) return
		emit('get-properties')
		setShowProperties(true)
	}

	/**
	 * Emits an event to open the Document Templates pop up (generated next to <q-document />)
	 */
	function createDocument() {
		emit('show-templates-popup')
	}

	/**
	 * Sets the overlay to submit a new version
	 * @param {boolean} visible Wether the overlay is visible or not
	 */
	function setShowFileSubmit(visible: boolean) {
		showFileSubmit.value = visible
	}

	/**
	 * Sets the overlay to show the properties of the document
	 * @param {boolean} visible Wether the overlay is visible or not
	 */
	function setShowProperties(visible: boolean) {
		showProperties.value = visible
	}

	/**
	 * Sets the overlay to show the versions of the document
	 * @param {boolean} visible Wether the overlay is visible or not
	 */
	function setShowVersions(visible: boolean) {
		showVersions.value = visible
	}

	defineOptions({
		inheritAttrs: false
	})
</script>
