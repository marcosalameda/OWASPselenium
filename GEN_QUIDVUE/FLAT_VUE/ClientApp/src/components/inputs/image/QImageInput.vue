<template>
	<div
		:id="controlId"
		class="i-image__field"
		ref="imgContainer"
		@dragenter.prevent="handleDragEnter"
		@dragleave.stop="handleDragLeave"
		@dragover.prevent="() => {}"
		@drop.prevent="handleDrop">
		<div class="i-image__container">
			<a
				class="thumbnail"
				href="javascript:void(0)">
				<img
					ref="mainImg"
					data-testid="main-img"
					:class="[{ 'img-thumbnail': !disabled }, 'i-image-frame']"
					:style="imageStyle"
					:src="imageURL"
					@click.stop.prevent="openPreview" />
			</a>

			<input
				type="file"
				data-testid="file-input"
				ref="fileInput"
				class="i-image__field-input"
				:accept="extensions"
				@change="handleFileChange" />
		</div>

		<div class="qq-uploader">
			<q-line-loader v-if="!loaded" />

			<div
				v-if="!readonly && !disabled && !modalImage"
				ref="dragArea"
				class="qq-upload-drop-area">
				<span>{{ texts.dropToUpload }}</span>
			</div>

			<div
				v-if="!readonly"
				class="i-image__field-uploader mt-2">
				<q-button-group :disabled="disabled">
					<q-button
						b-style="primary"
						data-testid="submit-btn"
						:label="isEmptyImage || !image ? texts.submitLabel : ''"
						:title="texts.submitLabel"
						@click="handleImageUpload">
						<q-icon icon="upload-img" />
					</q-button>

					<q-button
						v-if="!isEmptyImage && image"
						b-style="secondary"
						data-testid="edit-btn"
						:title="texts.editLabel"
						@click="handleOpenEdit">
						<q-icon icon="edit-img" />
					</q-button>

					<q-button
						v-if="!isEmptyImage && image"
						b-style="secondary"
						data-testid="delete-btn"
						:title="texts.deleteLabel"
						@click="handleImageDelete">
						<q-icon icon="delete" />
					</q-button>
				</q-button-group>
			</div>
		</div>

		<template v-if="modalImage">
			<q-image-editor
				v-if="popupIsVisible && showEditModal"
				:control-id="controlId"
				:texts="texts"
				:image-to-edit="getImageURL(modalImage)"
				@image-edited="imageEdited"
				@close-editor="handleCloseEdit" />
			<div
				v-else
				class="i-image__modal-main-container">
				<div class="i-image__modal-container">
					<img
						:src="getImageURL(modalImage)"
						class="i-image__modal-image" />

					<q-button
						b-style="plain"
						borderless
						class="i-image__modal-button"
						@click="closePreview">
						<q-icon icon="close" />
					</q-button>
				</div>
			</div>
		</template>
	</div>
</template>

<script>
	import { defineAsyncComponent } from 'vue'

	import { displayMessage, validateFileExtAndSize, validateTexts } from '@/mixins/genericFunctions.js'

	// The texts needed by the component.
	const DEFAULT_TEXTS = {
		submitLabel: 'Submit',
		deleteLabel: 'Delete',
		editLabel: 'Edit',
		fileSizeError: 'The selected file exceeds the allowed size of {0}.',
		extensionError: 'Invalid extension! Allowed extensions:',
		editImage: 'Edit image',
		cropWarning: 'Attention: Saving this form will replace the original image',
		dropToUpload: 'Drop files here to upload',
		save: 'Save',
		cancel: 'Cancel',
		zoomIn: 'Zoom in',
		zoomOut: 'Zoom out',
		moveImageLeft: 'Move image left',
		moveImageRight: 'Move image right',
		moveImageUp: 'Move image up',
		moveImageDown: 'Move image down',
		rotateLeft: 'Rotate left',
		rotateRight: 'Rotate right',
		flipHorizontal: 'Horizontal flip',
		flipVertical: 'Vertical flip',
		deleteHeaderLabel: 'Are you sure you want to delete?',
		yesLabel: 'Yes',
		noLabel: 'No'
	}

	function validateImageFormat(value)
	{
		return typeof value === 'object'
			? value === null || 'data' in value && 'dataFormat' in value && 'encoding' in value
			: typeof value === 'string'
	}

	export default {
		name: 'QImage',

		emits: {
			'close-image-preview': () => true,
			'delete-image': () => true,
			'file-error': (payload) => typeof payload === 'number',
			'hide-popup': (payload) => typeof payload === 'string',
			'open-image-preview': () => true,
			'show-popup': (payload) => typeof payload === 'object',
			'submit-image': (payload) => typeof payload === 'object'
		},

		components: {
			QImageEditor: defineAsyncComponent(() => import('./popups/QImageEditor.vue'))
		},

		inheritAttrs: false,

		props: {
			/**
			 * Unique identifier for the control.
			 */
			id: String,

			/**
			 * The image to be displayed (can be minimized to improve performance).
			 */
			image: {
				type: [String, Object],
				validator: (value) => validateImageFormat(value)
			},

			/**
			 * The full sized image to be displayed in a modal.
			 */
			modalImage: {
				type: [String, Object],
				validator: (value) => validateImageFormat(value)
			},

			/**
			 * Whether or not the current image is a default empty image.
			 */
			isEmptyImage: {
				type: Boolean,
				default: false
			},

			/**
			 * Necessary strings to be used in labels and buttons.
			 */
			texts: {
				type: Object,
				validator: (value) => validateTexts(DEFAULT_TEXTS, value),
				default: () => DEFAULT_TEXTS
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
			 * Extensions allowed for file select, some extension examples: .png, .jpg, .svg.
			 */
			extensions: {
				type: Array,
				default: () => ['.jpg', '.jpeg', '.png', '.gif', '.svg', '.webp', '.bmp']
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
			 * The maximum height of the image (must be a positive number).
			 */
			height: {
				type: Number,
				validator: (value) => value > 0
			},

			/**
			 * The maximum width of the image (must be a positive number).
			 */
			width: {
				type: Number,
				validator: (value) => value > 0
			},

			/**
			 * Whether or not the popup is currently open.
			 */
			popupIsVisible: {
				type: Boolean,
				default: false
			},

			/**
			 * Whether or not the image data is already loaded.
			 */
			loaded: {
				type: Boolean,
				default: true
			}
		},

		expose: [],

		data()
		{
			return {
				controlId: this.id || `q-image-input-${this._.uid}`,

				dragCount: 0,

				showEditModal: false
			}
		},

		computed: {
			imageStyle()
			{
				return {
					'max-height': this.height ? `${this.height}px` : 'auto',
					'max-width': this.width ? `${this.width}px` : 'auto'
				}
			},

			imageURL()
			{
				return this.getImageURL(this.image)
			}
		},

		methods: {
			getImageURL(image)
			{
				// Here we are dealing with various cases:
				// 1: if image is not provided returns an empty path
				// 2: if image is string use it directly
				// 3: if image is dataURL object, create image url using data, encoding and data format
				return image
					? typeof image === 'object'
						? `data:image/${image.dataFormat};${image.encoding},${image.data}`
						: image
					: ''
			},

			openPreview()
			{
				this.$emit('open-image-preview')
			},

			closePreview()
			{
				this.$emit('close-image-preview')
			},

			handleFileChange(event)
			{
				// This method will be called when the file gets uploaded.
				const files = event.target.files ?? event.dataTransfer.files

				if (files && files[0])
				{
					const fileData = files[0]
					const validationResult = validateFileExtAndSize(fileData, this.extensions, this.maxFileSize)

					if (validationResult === 0)
						this.$emit('submit-image', fileData)
					else
						this.$emit('file-error', validationResult)

					// Clears the value, so that the next "change" event will trigger even if the file name is the same.
					event.target.value = ''
				}
			},

			handleImageDelete()
			{
				const buttons = {
					confirm: {
						label: this.texts.yesLabel,
						action: () => this.$emit('delete-image')
					},
					cancel: {
						label: this.texts.noLabel
					}
				}
				displayMessage(this.texts.deleteHeaderLabel, 'question', null, buttons)
			},

			handleImageUpload()
			{
				// This function will trigger the click event on the file input.
				this.$refs.fileInput.click()
			},

			handleDragEnter()
			{
				if (this.disabled || this.readonly || this.modalImage)
					return

				this.dragCount++
				this.$refs.dragArea.classList.add('qq-upload-drop-area-active')
			},

			handleDragLeave()
			{
				if (this.readonly || this.disabled || this.modalImage)
					return

				this.dragCount--
				if (this.dragCount === 0)
					this.$refs.dragArea.classList.remove('qq-upload-drop-area-active')
			},

			handleDrop(event)
			{
				if (this.readonly || this.disabled || this.modalImage)
					return

				this.dragCount = 0
				this.$refs.dragArea.classList.remove('qq-upload-drop-area-active')
				this.handleFileChange(event)
			},

			handleOpenEdit()
			{
				const modalId = `image-edit-${this.controlId}`
				const modalProps = {
					id: modalId,
					props: {
						headerTitle: this.texts.editImage,
						dismissAction: this.closeEdit
					}
				}
				this.$emit('show-popup', modalProps)

				this.openPreview()
				this.showEditModal = true
			},

			closeEdit()
			{
				this.showEditModal = false
				this.closePreview()
			},

			handleCloseEdit()
			{
				const modalId = `image-edit-${this.controlId}`
				this.$emit('hide-popup', modalId)

				this.closeEdit()
			},

			imageEdited(newImage)
			{
				this.$emit('submit-image', newImage)
				this.handleCloseEdit()
			}
		},

		watch: {
			modalImage(val)
			{
				if (!this.showEditModal)
				{
					// We are manipulating the style of the body to prevent overflow when the preview mode is on.
					if (val)
						document.body.style.setProperty('overflow', 'hidden')
					else
						document.body.style.removeProperty('overflow')
				}
			}
		}
	}
</script>
