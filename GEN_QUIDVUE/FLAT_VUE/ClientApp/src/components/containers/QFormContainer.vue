<template>
	<div
		:id="id"
		:class="['container-fluid', 'nested-form-container', $attrs.class]"
		role="dialog"
		aria-hidden="true">
		<template v-if="activeComponent">
			<component
				:is="activeComponent"
				:key="formProps.id"
				:buttons-override="rowComponentProps.formButtonsOverride"
				:parent-form-mode="rowComponentProps.parentFormMode"
				:parent-table-permissions="rowComponentProps.permissions"
				:actions-placement="rowComponentProps.actionsPlacement"
				v-bind="formProps"
				@close="(...args) => $emit('close', ...args)"
				@update:nested-model="handleModelUpdateEvent"
				@edit="(...args) => $emit('edit', ...args)"
				@deselect="(...args) => $emit('deselect', ...args)"
				@insert-form="(...args) => $emit('insert-form', ...args)"
				@after-save-form="(...args) => $emit('after-save-form', ...args)"
				@cancel-insert="(...args) => $emit('cancel-insert', ...args)"
				@is-form-dirty="handleIsFormDirty"
				@update-form-mode="handleUpdateFormMode"
				@custom-event="handleCustomEvent" />
		</template>
		<div
			v-else
			class="nested-form-no-record">
			<img :src="`${resourcesPath}empty_card_container.png`" />

			<span>
				{{ texts.chooseElement }}
			</span>
		</div>
	</div>
</template>

<script>
	import _isEmpty from 'lodash-es/isEmpty'

	import { formModes } from '@/mixins/quidgest.mainEnums.js'
	import { validateTexts } from '@/mixins/genericFunctions.js'
	import { NestedFormConfig } from '@/mixins/fieldControl.js'

	// The texts needed by the component.
	const DEFAULT_TEXTS = {
		chooseElement: 'Choose an element from the list.'
	}

	export default {
		name: 'QFormContainer',

		emits: [
			'after-save-form',
			'cancel-insert',
			'change-form-mode',
			'close',
			'closed-form',
			'custom-event',
			'deselect',
			'edit',
			'insert-form',
			'is-form-dirty',
			'update:nestedModel'
		],

		inheritAttrs: false,

		props: {
			/**
			 * Unique identifier for the control.
			 */
			id: {
				type: String,
				required: true
			},

			/**
			 * Whether or not the form is currently visible.
			 */
			isVisible: {
				type: Boolean,
				default: true
			},

			/**
			 * The nested form data required to load form.
			 * {
			 *     id,
			 *     historyBranchId,
			 *     component,
			 *     mode,
			 *     nestedModel (optional)
			 * }
			 */
			formData: {
				type: Object,
				default: () => ({}),
				validator: (val) =>
					!_isEmpty(val) &&
					val.id &&
					val.historyBranchId &&
					typeof val.component === 'string' &&
					Object.values(formModes).includes(val.mode)
			},

			/**
			 * Props for form component.
			 */
			rowComponentProps: {
				type: Object,
				default: () => ({})
			},

			/**
			 * Configuration of the nested form.
			 */
			nestedFormConfig: {
				type: Object,
				default: () => new NestedFormConfig()
			},

			/**
			 * The resources path.
			 */
			resourcesPath: {
				type: String,
				required: true
			},

			/**
			 * The necessary strings to be used inside the component.
			 */
			texts: {
				type: Object,
				validator: (value) => validateTexts(DEFAULT_TEXTS, value),
				default: () => DEFAULT_TEXTS
			}
		},

		expose: [],

		data()
		{
			return {
				activeComponent: null,
				formProps: {
					isNested: true
				}
			}
		},

		mounted()
		{
			this.updateFormData(this.formData)
		},

		methods: {
			updateFormData(newFormData)
			{
				let result = {
					component: null,
					props: {}
				}

				if (!_isEmpty(newFormData))
				{
					result.component = newFormData.component
					result.props = {
						id: newFormData.id,
						mode: newFormData.mode,
						isNested: true,
						modes: '',
						historyBranchId: newFormData.historyBranchId,
						nestedModel: newFormData.nestedModel,
						nestedFormConfig: this.nestedFormConfig
					}
				}

				this.formClose()
				this.formProps = result.props
				this.activeComponent = result.component
			},

			formClose()
			{
				this.activeComponent = null
				this.formProps = {
					isNested: true
				}
			},

			handleModelUpdateEvent(newModelValue)
			{
				this.$emit('update:nestedModel', newModelValue)
			},

			handleCustomEvent(args)
			{
				this.$emit('custom-event', args)
			},

			/**
			 * Emits the dirty state of the form container to the parent forms. 
			 * afterFormSave refers to what situation the event was emitted in: after a form modification (false) or after saving the form (true)
			 */
			handleIsFormDirty(eventData)
			{
				this.$emit('is-form-dirty', { id: this.formData.id, isDirty: eventData.isDirty, afterFormSave: eventData.afterFormSave })
			},

			handleUpdateFormMode(mode)
			{
				this.$emit('change-form-mode', mode)
			}
		},

		watch: {
			formData: {
				handler(newValue)
				{
					this.updateFormData(newValue)
				},
				deep: true
			}
		}
	}
</script>
