<template>
	<tr
		:data-key="id"
		:class="rowClass">
		<td class="grid-table-row__state">
			<div class="grid-table-row__state-icon">
				<q-icon
					v-if="rowStateIcon"
					:icon="rowStateIcon" />
			</div>
		</td>

		<td class="grid-table-row__action">
			<div class="grid-table-row__action-btn">
				<q-button
					v-if="showDeleteBtn"
					b-style="tertiary"
					:title="texts.delete"
					data-testid="delete"
					@click="markForDeletion">
					<q-icon icon="delete" />
				</q-button>

				<q-button
					v-if="showRemoveBtn"
					b-style="tertiary"
					:title="texts.remove"
					data-testid="delete"
					@click="markForDeletion">
					<q-icon icon="remove-sign" />
				</q-button>

				<q-button
					v-if="showUndoBtn"
					b-style="tertiary"
					:title="texts.restore"
					data-testid="undo"
					@click="undoMarkForDeletion">
					<q-icon icon="undo" />
				</q-button>
			</div>
		</td>

		<td>
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_TEXT____">
				<q-text-field
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_TEXT____.props"
					:model-value="model.ValText.value"
					@update:model-value="model.ValText.fnUpdateValue" />
			</grid-base-input-structure>
		</td>
		<td>
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_TEXTML__">
				<q-text-field
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_TEXTML__.props"
					:model-value="model.ValTextml.value"
					@update:model-value="model.ValTextml.fnUpdateValue" />
			</grid-base-input-structure>
		</td>
		<td>
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_NUMINT__">
				<q-numeric-input
					v-if="controls.GRPB____PSEUDTBLB____TBLB_NUMINT__.isVisible"
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_NUMINT__"
					:model-value="model.ValNumint.value"
					@update:model-value="model.ValNumint.fnUpdateValue" />
			</grid-base-input-structure>
		</td>
		<td>
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_NUMDEC__">
				<q-numeric-input
					v-if="controls.GRPB____PSEUDTBLB____TBLB_NUMDEC__.isVisible"
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_NUMDEC__"
					:model-value="model.ValNumdec.value"
					@update:model-value="model.ValNumdec.fnUpdateValue" />
			</grid-base-input-structure>
		</td>
		<td>
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_CURINT__">
				<q-numeric-input
					v-if="controls.GRPB____PSEUDTBLB____TBLB_CURINT__.isVisible"
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_CURINT__"
					:model-value="model.ValCurint.value"
					@update:model-value="model.ValCurint.fnUpdateValue" />
			</grid-base-input-structure>
		</td>
		<td>
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_CURDEC__">
				<q-numeric-input
					v-if="controls.GRPB____PSEUDTBLB____TBLB_CURDEC__.isVisible"
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_CURDEC__"
					:model-value="model.ValCurdec.value"
					@update:model-value="model.ValCurdec.fnUpdateValue" />
			</grid-base-input-structure>
		</td>
		<td>
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_BOOL____">
				<template #label>
					<q-checkbox-input
						v-if="controls.GRPB____PSEUDTBLB____TBLB_BOOL____.isVisible"
						id="GRPB____PSEUDTBLB____TBLB_BOOL____"
						size="mini"
						:model-value="model.ValBool.value"
						:readonly="controls.GRPB____PSEUDTBLB____TBLB_BOOL____.readonly"
						@update:model-value="model.ValBool.fnUpdateValue" />
				</template>
			</grid-base-input-structure>
		</td>
		<td>
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_DATE____">
				<q-datetime-input
					v-if="controls.GRPB____PSEUDTBLB____TBLB_DATE____.isVisible"
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_DATE____"
					format="Date"
					:model-value="model.ValDate.value"
					@update:model-value="model.ValDate.fnUpdateValue" />
			</grid-base-input-structure>
		</td>
		<td>
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_DATETM__">
				<q-datetime-input
					v-if="controls.GRPB____PSEUDTBLB____TBLB_DATETM__.isVisible"
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_DATETM__"
					format="DateTime"
					:model-value="model.ValDatetm.value"
					@update:model-value="model.ValDatetm.fnUpdateValue" />
			</grid-base-input-structure>
		</td>
		<td>
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_DATETS__">
				<q-datetime-input
					v-if="controls.GRPB____PSEUDTBLB____TBLB_DATETS__.isVisible"
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_DATETS__"
					format="DateTimeSeconds"
					:model-value="model.ValDatets.value"
					@update:model-value="model.ValDatets.fnUpdateValue" />
			</grid-base-input-structure>
		</td>
		<td>
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_TIMEHM__">
				<q-datetime-input
					v-if="controls.GRPB____PSEUDTBLB____TBLB_TIMEHM__.isVisible"
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_TIMEHM__"
					format="Time"
					:model-value="model.ValTimehm.value"
					@update:model-value="model.ValTimehm.fnUpdateValue" />
			</grid-base-input-structure>
		</td>
		<td>
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_ENUMT___">
				<q-select
					v-if="controls.GRPB____PSEUDTBLB____TBLB_ENUMT___.isVisible"
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_ENUMT___.props"
					:model-value="model.ValEnumt.value"
					@update:model-value="model.ValEnumt.fnUpdateValue" />
			</grid-base-input-structure>
		</td>
		<td>
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_ENUMN___">
				<q-select
					v-if="controls.GRPB____PSEUDTBLB____TBLB_ENUMN___.isVisible"
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_ENUMN___.props"
					:model-value="model.ValEnumn.value"
					@update:model-value="model.ValEnumn.fnUpdateValue" />
			</grid-base-input-structure>
		</td>
	</tr>
</template>

<script>
	/* eslint-disable no-unused-vars */
	import { computed, defineAsyncComponent } from 'vue'

	import GridFormHandlers from '@/mixins/gridFormHandlers.js'
	import formFunctions from '@/mixins/formFunctions.js'
	import genericFunctions from '@/mixins/genericFunctions.js'
	import modelFieldType from '@/mixins/formModelFieldTypes.js'
	import fieldControlClass from '@/mixins/fieldControl.js'
	import qEnums from '@/mixins/quidgest.mainEnums.js'

	import hardcodedTexts from '@/hardcodedTexts.js'
	import netAPI from '@/api/network'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	import asyncProcM from '@/api/global/asyncProcMonitoring.js'

	import GridBaseInputStructure from '@/components/inputs/GridBaseInputStructure.vue'
	/* eslint-enable no-unused-vars */

	const requiredTextResources = ['QFormGrpbPseudtblb', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS GRPB____PSEUDTBLB____]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormGrpbPseudtblb',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormGrpbPseudtblb', false),

				interfaceMetadata: {
					id: 'QFormGrpbPseudtblb', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'virtual',
					name: 'GrpbPseudtblb',
					area: 'TBLB',
					primaryKey: 'ValCodtblb',
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
					GRPB____PSEUDTBLB____TBLB_TEXT____: new fieldControlClass.StringControl({
						modelField: 'ValText',
						valueChangeEvent: 'fieldChange:tblb.text',
						id: 'GRPB____PSEUDTBLB____TBLB_TEXT____',
						name: 'TEXT',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.TEXT04938),
						userHelp: computed(() => this.Resources.TEXT04938),
						description: '',
						placeholder: '',
						labelPosition: '',
						maxLength: 50,
						labelId: 'label_GRPB____PSEUDTBLB____TBLB_TEXT____',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_TEXTML__: new fieldControlClass.StringControl({
						modelField: 'ValTextml',
						valueChangeEvent: 'fieldChange:tblb.textml',
						id: 'GRPB____PSEUDTBLB____TBLB_TEXTML__',
						name: 'TEXTML',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.MULTILINE_TEXT38013),
						userHelp: computed(() => this.Resources.MULTILINE_TEXT38013),
						description: '',
						placeholder: '',
						labelPosition: '',
						maxLength: 50,
						labelId: 'label_GRPB____PSEUDTBLB____TBLB_TEXTML__',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_NUMINT__: new fieldControlClass.NumberControl({
						modelField: 'ValNumint',
						valueChangeEvent: 'fieldChange:tblb.numint',
						maxIntegers: 10,
						maxDecimals: 0,
						id: 'GRPB____PSEUDTBLB____TBLB_NUMINT__',
						name: 'NUMINT',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.NUMERIC__INTEGER_50289),
						userHelp: computed(() => this.Resources.NUMERIC__INTEGER_50289),
						description: '',
						placeholder: '',
						labelPosition: '',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_NUMDEC__: new fieldControlClass.NumberControl({
						modelField: 'ValNumdec',
						valueChangeEvent: 'fieldChange:tblb.numdec',
						maxIntegers: 6,
						maxDecimals: 3,
						id: 'GRPB____PSEUDTBLB____TBLB_NUMDEC__',
						name: 'NUMDEC',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.NUMERIC__DECIMAL_36157),
						userHelp: computed(() => this.Resources.NUMERIC__DECIMAL_36157),
						description: '',
						placeholder: '',
						labelPosition: '',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_CURINT__: new fieldControlClass.CurrencyControl({
						modelField: 'ValCurint',
						valueChangeEvent: 'fieldChange:tblb.curint',
						maxIntegers: 7,
						maxDecimals: 2,
						id: 'GRPB____PSEUDTBLB____TBLB_CURINT__',
						name: 'CURINT',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.CURRENCY__INTERGER_21437),
						userHelp: computed(() => this.Resources.CURRENCY__INTERGER_21437),
						description: '',
						placeholder: '',
						labelPosition: '',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_CURDEC__: new fieldControlClass.CurrencyControl({
						modelField: 'ValCurdec',
						valueChangeEvent: 'fieldChange:tblb.curdec',
						maxIntegers: 5,
						maxDecimals: 4,
						id: 'GRPB____PSEUDTBLB____TBLB_CURDEC__',
						name: 'CURDEC',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.CURRENCY__DECIMAL_11718),
						userHelp: computed(() => this.Resources.CURRENCY__DECIMAL_11718),
						description: '',
						placeholder: '',
						labelPosition: '',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_BOOL____: new fieldControlClass.BooleanControl({
						modelField: 'ValBool',
						valueChangeEvent: 'fieldChange:tblb.bool',
						id: 'GRPB____PSEUDTBLB____TBLB_BOOL____',
						name: 'BOOL',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.BOOLEAN45002),
						userHelp: computed(() => this.Resources.BOOLEAN45002),
						description: '',
						placeholder: '',
						labelPosition: '',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_DATE____: new fieldControlClass.DateControl({
						modelField: 'ValDate',
						valueChangeEvent: 'fieldChange:tblb.date',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'GRPB____PSEUDTBLB____TBLB_DATE____',
						name: 'DATE',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.DATE18475),
						userHelp: computed(() => this.Resources.DATE18475),
						description: '',
						placeholder: '',
						labelPosition: '',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_DATETM__: new fieldControlClass.DateControl({
						modelField: 'ValDatetm',
						valueChangeEvent: 'fieldChange:tblb.datetm',
						id: 'GRPB____PSEUDTBLB____TBLB_DATETM__',
						name: 'DATETM',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.DATETIME__MINUTES_59352),
						userHelp: computed(() => this.Resources.DATETIME__MINUTES_59352),
						description: '',
						placeholder: '',
						labelPosition: '',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_DATETS__: new fieldControlClass.DateControl({
						modelField: 'ValDatets',
						valueChangeEvent: 'fieldChange:tblb.datets',
						id: 'GRPB____PSEUDTBLB____TBLB_DATETS__',
						name: 'DATETS',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.DATETIME__SECONDS_49861),
						userHelp: computed(() => this.Resources.DATETIME__SECONDS_49861),
						description: '',
						placeholder: '',
						labelPosition: '',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_TIMEHM__: new fieldControlClass.TimeControl({
						modelField: 'ValTimehm',
						valueChangeEvent: 'fieldChange:tblb.timehm',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'GRPB____PSEUDTBLB____TBLB_TIMEHM__',
						name: 'TIMEHM',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.TIME__HOURS_MINUTES_01660),
						userHelp: computed(() => this.Resources.TIME__HOURS_MINUTES_01660),
						description: '',
						placeholder: '',
						labelPosition: '',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_ENUMT___: new fieldControlClass.ArrayStringControl({
						modelField: 'ValEnumt',
						valueChangeEvent: 'fieldChange:tblb.enumt',
						id: 'GRPB____PSEUDTBLB____TBLB_ENUMT___',
						name: 'ENUMT',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.ENUMERATION__TEXT_15855),
						userHelp: computed(() => this.Resources.ENUMERATION__TEXT_15855),
						description: '',
						placeholder: '',
						labelPosition: '',
						maxLength: 1,
						labelId: 'label_GRPB____PSEUDTBLB____TBLB_ENUMT___',
						arrayName: 'typet',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_ENUMN___: new fieldControlClass.ArrayNumberControl({
						modelField: 'ValEnumn',
						valueChangeEvent: 'fieldChange:tblb.enumn',
						maxIntegers: 1,
						maxDecimals: 0,
						id: 'GRPB____PSEUDTBLB____TBLB_ENUMN___',
						name: 'ENUMN',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.ENUMERATION__NUMERIC44708),
						userHelp: computed(() => this.Resources.ENUMERATION__NUMERIC44708),
						description: '',
						placeholder: '',
						labelPosition: '',
						arrayName: 'typen',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
				},

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Tblb: {
						get ValBool() { return vm.model.ValBool.value },
						set ValBool(value) { vm.model.ValBool.updateValue(value) },
						get ValCurdec() { return vm.model.ValCurdec.value },
						set ValCurdec(value) { vm.model.ValCurdec.updateValue(value) },
						get ValCurint() { return vm.model.ValCurint.value },
						set ValCurint(value) { vm.model.ValCurint.updateValue(value) },
						get ValDate() { return vm.model.ValDate.value },
						set ValDate(value) { vm.model.ValDate.updateValue(value) },
						get ValDatetm() { return vm.model.ValDatetm.value },
						set ValDatetm(value) { vm.model.ValDatetm.updateValue(value) },
						get ValDatets() { return vm.model.ValDatets.value },
						set ValDatets(value) { vm.model.ValDatets.updateValue(value) },
						get ValEnumn() { return vm.model.ValEnumn.value },
						set ValEnumn(value) { vm.model.ValEnumn.updateValue(value) },
						get ValEnumt() { return vm.model.ValEnumt.value },
						set ValEnumt(value) { vm.model.ValEnumt.updateValue(value) },
						get ValFkey1() { return vm.model.ValFkey1.value },
						set ValFkey1(value) { vm.model.ValFkey1.updateValue(value) },
						get ValNumdec() { return vm.model.ValNumdec.value },
						set ValNumdec(value) { vm.model.ValNumdec.updateValue(value) },
						get ValNumint() { return vm.model.ValNumint.value },
						set ValNumint(value) { vm.model.ValNumint.updateValue(value) },
						get ValText() { return vm.model.ValText.value },
						set ValText(value) { vm.model.ValText.updateValue(value) },
						get ValTextml() { return vm.model.ValTextml.value },
						set ValTextml(value) { vm.model.ValTextml.updateValue(value) },
						get ValTimehm() { return vm.model.ValTimehm.value },
						set ValTimehm(value) { vm.model.ValTimehm.updateValue(value) },
					},
					keys: {
						/** The primary key of the TBLB table */
						get tblb() { return vm.model.ValCodtblb },
						/** The foreign key to the GRPB table */
						get grpb() { return vm.model.ValFkey1 },
					},
					extraProperties: {}
				},
			}
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_CODEJS GRPB____PSEUDTBLB____]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS GRPB____PSEUDTBLB____]/
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
// USE /[MANUAL GQT FORM_LOADED_JS GRPB____PSEUDTBLB____]/
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

				this.emitEvent('before-apply-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT BEFORE_APPLY_JS GRPB____PSEUDTBLB____]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS GRPB____PSEUDTBLB____]/
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

				this.emitEvent('before-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT BEFORE_SAVE_JS GRPB____PSEUDTBLB____]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS GRPB____PSEUDTBLB____]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS GRPB____PSEUDTBLB____]/
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
// USE /[MANUAL GQT AFTER_DEL_JS GRPB____PSEUDTBLB____]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS GRPB____PSEUDTBLB____]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS GRPB____PSEUDTBLB____]/
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
// USE /[MANUAL GQT DLGUPDT GRPB____PSEUDTBLB____]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterFieldUpdate(fieldName, fieldObject)
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
// USE /[MANUAL GQT CTRLUPD GRPB____PSEUDTBLB____]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
		}
	}
</script>
