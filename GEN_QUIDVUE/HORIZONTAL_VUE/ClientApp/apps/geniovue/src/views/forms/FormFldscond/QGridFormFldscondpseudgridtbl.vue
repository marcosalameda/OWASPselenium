<template>
	<tr
		:data-key="id"
		:class="rowClass">
		<td class="grid-table-row__state">
			<div class="grid-table-row__state-icon">
				<q-icon
					v-if="rowStateIcon"
					:icon="rowStateIcon" />

				<q-button
					v-if="hasMessages"
					variant="text"
					@click="toggleErrors">
					<q-icon :icon="expandIcon" />
				</q-button>
			</div>

			<div v-if="hasMessages">
				<q-badge :color="badgeColor">
					{{ numMessages }}
				</q-badge>
				<span class="grid-table-row__messages">
					{{ texts.messages }}
				</span>
			</div>
		</td>

		<td class="grid-table-row__action">
			<div class="grid-table-row__action-btn">
				<q-button
					v-if="showDeleteBtn"
					variant="text"
					:title="texts.delete"
					data-testid="delete"
					@click="markForDeletion">
					<q-icon icon="delete" />
				</q-button>

				<q-button
					v-if="showRemoveBtn"
					variant="text"
					:title="texts.remove"
					data-testid="delete"
					@click="markForDeletion">
					<q-icon icon="remove-sign" />
				</q-button>

				<q-button
					v-if="showUndoBtn"
					variant="text"
					:title="texts.restore"
					data-testid="undo"
					@click="undoMarkForDeletion">
					<q-icon icon="undo" />
				</q-button>
			</div>
		</td>

		<td v-if="canShowColumn('FEECA', 'FEEDBACK')">
			<grid-base-input-structure
				class=""
				v-bind="controls.FLDSCONDPSEUDGRIDTBL___FEECA__FEEDBACK.wrapperProps">
				<q-text-field
					v-bind="controls.FLDSCONDPSEUDGRIDTBL___FEECA__FEEDBACK.props"
					@blur="onBlur(controls.FLDSCONDPSEUDGRIDTBL___FEECA__FEEDBACK, model.ValFeedback.value)"
					@change="model.ValFeedback.fnUpdateValueOnChange" />
			</grid-base-input-structure>
		</td>
	</tr>
</template>

<script>
	/* eslint-disable no-unused-vars */
	import { computed, defineAsyncComponent } from 'vue'

	import GridFormHandlers from '@/mixins/gridFormHandlers.js'
	import formFunctions from '@/mixins/formFunctions.js'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import modelFieldType from '@quidgest/clientapp/models/fields'
	import fieldControlClass from '@/mixins/fieldControl.js'
	import qEnums from '@quidgest/clientapp/constants/enums'

	import hardcodedTexts from '@/hardcodedTexts.js'
	import netAPI from '@quidgest/clientapp/network'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	import asyncProcM from '@quidgest/clientapp/composables/async'

	import GridBaseInputStructure from '@/components/inputs/GridBaseInputStructure.vue'
	/* eslint-enable no-unused-vars */

	const requiredTextResources = ['QGridFormFldscondpseudgridtbl', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS FLDSCONDPSEUDGRIDTBL_]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QGridFormFldscondpseudgridtbl',

		components: {
			GridBaseInputStructure
		},

		mixins: [
			GridFormHandlers
		],

		expose: [
			'navigationId'
		],

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QGridFormFldscondpseudgridtbl', false),

				interfaceMetadata: {
					id: 'QGridFormFldscondpseudgridtbl', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'virtual',
					name: 'Fldscondpseudgridtbl',
					area: 'FEECA',
					primaryKey: 'ValCodfeeca',
					designation: '',
					identifier: '', // Unique identifier received by route (when it's nested).
					mode: ''
				},

				model: this.nestedModel
					.setExternalCallback({
						onUpdate: this.onUpdate,
						setFormKey: this.setFormKey
					})
					.setNavigationId(this.navigationId),

				controls: {
					FLDSCONDPSEUDGRIDTBL___FEECA__FEEDBACK: new fieldControlClass.StringControl({
						modelField: 'ValFeedback',
						valueChangeEvent: 'fieldChange:feeca.feedback',
						id: 'FLDSCONDPSEUDGRIDTBL___FEECA__FEEDBACK',
						name: 'FEEDBACK',
						size: 'xlarge',
						label: computed(() => this.Resources.FEEDBACK52855),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_FLDSCONDPSEUDGRIDTBL___FEECA__FEEDBACK',
						controlLimits: [
						],
					}, this),
				},

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Feeca: {
						get ValCodflds() { return vm.model.ValCodflds.value },
						set ValCodflds(value) { vm.model.ValCodflds.updateValue(value) },
						get ValFeedback() { return vm.model.ValFeedback.value },
						set ValFeedback(value) { vm.model.ValFeedback.updateValue(value) },
					},
					keys: {
						/** The primary key of the FEECA table */
						get feeca() { return vm.model.ValCodfeeca },
						/** The foreign key to the FLDS table */
						get flds() { return vm.model.ValCodflds },
					},
					get extraProperties() { return vm.model.extraProperties },
				},
			}
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_CODEJS FLDSCONDPSEUDGRIDTBL_]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
			/**
			 * Called before form init.
			 */
			async beforeLoad()
			{
				let loadForm = true

				// Execute the "Before init" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeInit)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('before-load-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT BEFORE_LOAD_JS FLDSCONDPSEUDGRIDTBL_]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return loadForm
			},

			/**
			 * Called after form init.
			 */
			async afterLoad()
			{
				// Execute the "After init" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterInit)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-load-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_LOADED_JS FLDSCONDPSEUDGRIDTBL_]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called before an apply action is performed.
			 */
			async beforeApply()
			{
				let applyForm = true // Set to 'false' to cancel form apply.

				// Execute the "Before apply" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeApply)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				const canSetDocums = await this.model.updateFilesTickets(true)

				if (canSetDocums)
				{
					applyForm = await this.model.setDocumentChanges()

					if (applyForm)
					{
						const results = await this.model.saveDocuments()
						applyForm = results.every((e) => e === true)
					}
				}

				this.emitEvent('before-apply-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT BEFORE_APPLY_JS FLDSCONDPSEUDGRIDTBL_]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return applyForm
			},

			/**
			 * Called after an apply action is performed.
			 */
			async afterApply()
			{
				// Execute the "After apply" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterApply)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-apply-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT AFTER_APPLY_JS FLDSCONDPSEUDGRIDTBL_]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called before the record is saved.
			 */
			async beforeSave()
			{
				let saveForm = true // Set to 'false' to cancel form saving.

				// Execute the "Before save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeSave)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				const canSetDocums = await this.model.updateFilesTickets()

				if (canSetDocums)
				{
					saveForm = await this.model.setDocumentChanges()

					if (saveForm)
					{
						const results = await this.model.saveDocuments()
						saveForm = results.every((e) => e === true)
					}
				}

				this.emitEvent('before-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT BEFORE_SAVE_JS FLDSCONDPSEUDGRIDTBL_]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return saveForm
			},

			/**
			 * Called after the record is saved.
			 */
			async afterSave()
			{
				let redirectPage = true // Set to 'false' to cancel page redirect.

				// Execute the "After save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterSave)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT AFTER_SAVE_JS FLDSCONDPSEUDGRIDTBL_]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return redirectPage
			},

			/**
			 * Called before the record is deleted.
			 */
			async beforeDel()
			{
				let deleteForm = true // Set to 'false' to cancel form delete.

				this.emitEvent('before-delete-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT BEFORE_DEL_JS FLDSCONDPSEUDGRIDTBL_]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return deleteForm
			},

			/**
			 * Called after the record is deleted.
			 */
			async afterDel()
			{
				let redirectPage = true // Set to 'false' to cancel page redirect.

				this.emitEvent('after-delete-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT AFTER_DEL_JS FLDSCONDPSEUDGRIDTBL_]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return redirectPage
			},

			/**
			 * Called before leaving the form.
			 */
			async beforeExit()
			{
				let leaveForm = true // Set to 'false' to cancel page redirect.

				// Execute the "Before exit" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeExit)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('before-exit-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT BEFORE_EXIT_JS FLDSCONDPSEUDGRIDTBL_]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return leaveForm
			},

			/**
			 * Called after leaving the form.
			 */
			async afterExit()
			{
				// Execute the "After exit" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterExit)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-exit-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT AFTER_EXIT_JS FLDSCONDPSEUDGRIDTBL_]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called whenever a field's value is updated.
			 * @param {string} fieldName The name of the field in the format [table].[field] (ex: 'person.name')
			 * @param {object} fieldObject The object representing the field in the model
			 * @param {any} fieldValue The value of the field
			 * @param {any} oldFieldValue The previous value of the field
			 */
			// eslint-disable-next-line
			onUpdate(fieldName, fieldObject, fieldValue, oldFieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT DLGUPDT FLDSCONDPSEUDGRIDTBL_]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterFieldUpdate(fieldName, fieldObject)
			},

			/**
			 * Called whenever a field is unfocused.
			 * @param {*} fieldObject The object representing the field in the model
			 * @param {*} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onBlur(fieldObject, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT CTRLBLR FLDSCONDPSEUDGRIDTBL_]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterFieldUnfocus(fieldObject, fieldValue)
			},

			/**
			 * Called whenever a control's value is updated.
			 * @param {string} controlField The name of the field in the controls that will be updated
			 * @param {object} control The object representing the field in the controls
			 * @param {any} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onControlUpdate(controlField, control, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT CTRLUPD FLDSCONDPSEUDGRIDTBL_]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
		}
	}
</script>
