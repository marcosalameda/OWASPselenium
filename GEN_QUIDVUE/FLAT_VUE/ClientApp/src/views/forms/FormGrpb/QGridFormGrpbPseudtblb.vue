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
					b-style="tertiary"
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

		<td v-if="canShowColumn('TBLB', 'TEXT')">
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_TEXT____.wrapperProps">
				<q-text-field
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_TEXT____.props"
					:model-value="model.ValText.value"
					@blur="onBlur(controls.GRPB____PSEUDTBLB____TBLB_TEXT____, model.ValText.value)"
					@change="model.ValText.fnUpdateValueOnChange" />
			</grid-base-input-structure>
		</td>
		<td v-if="canShowColumn('TBLB', 'TEXTML')">
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_TEXTML__.wrapperProps">
				<q-textarea-input
					v-if="controls.GRPB____PSEUDTBLB____TBLB_TEXTML__.isVisible"
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_TEXTML__.props"
					id="GRPB____PSEUDTBLB____TBLB_TEXTML__"
					:model-value="model.ValTextml.value"
					:rows="0"
					:cols="30"
					@update:model-value="model.ValTextml.fnUpdateValue" />
			</grid-base-input-structure>
		</td>
		<td v-if="canShowColumn('TBLB', 'NUMINT')">
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_NUMINT__.wrapperProps">
				<q-numeric-input
					v-if="controls.GRPB____PSEUDTBLB____TBLB_NUMINT__.isVisible"
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_NUMINT__.props"
					@update:model-value="model.ValNumint.fnUpdateValue" />
			</grid-base-input-structure>
		</td>
		<td v-if="canShowColumn('TBLB', 'NUMDEC')">
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_NUMDEC__.wrapperProps">
				<q-numeric-input
					v-if="controls.GRPB____PSEUDTBLB____TBLB_NUMDEC__.isVisible"
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_NUMDEC__.props"
					@update:model-value="model.ValNumdec.fnUpdateValue" />
			</grid-base-input-structure>
		</td>
		<td v-if="canShowColumn('TBLB', 'CURINT')">
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_CURINT__.wrapperProps">
				<q-numeric-input
					v-if="controls.GRPB____PSEUDTBLB____TBLB_CURINT__.isVisible"
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_CURINT__.props"
					@update:model-value="model.ValCurint.fnUpdateValue" />
			</grid-base-input-structure>
		</td>
		<td v-if="canShowColumn('TBLB', 'CURDEC')">
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_CURDEC__.wrapperProps">
				<q-numeric-input
					v-if="controls.GRPB____PSEUDTBLB____TBLB_CURDEC__.isVisible"
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_CURDEC__.props"
					@update:model-value="model.ValCurdec.fnUpdateValue" />
			</grid-base-input-structure>
		</td>
		<td v-if="canShowColumn('TBLB', 'BOOL')">
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_BOOL____.wrapperProps">
				<template #label>
					<q-checkbox-input
						v-if="controls.GRPB____PSEUDTBLB____TBLB_BOOL____.isVisible"
						v-bind="controls.GRPB____PSEUDTBLB____TBLB_BOOL____.props"
						v-on="controls.GRPB____PSEUDTBLB____TBLB_BOOL____.handlers" />
				</template>
			</grid-base-input-structure>
		</td>
		<td v-if="canShowColumn('TBLB', 'DATE')">
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_DATE____.wrapperProps">
				<q-date-time-picker
					v-if="controls.GRPB____PSEUDTBLB____TBLB_DATE____.isVisible"
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_DATE____.props"
					:model-value="model.ValDate.value"
					@reset-icon-click="model.ValDate.fnUpdateValue(model.ValDate.originalValue ?? new Date())"
					@update:model-value="model.ValDate.fnUpdateValue($event ?? '')" />
			</grid-base-input-structure>
		</td>
		<td v-if="canShowColumn('TBLB', 'DATETM')">
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_DATETM__.wrapperProps">
				<q-date-time-picker
					v-if="controls.GRPB____PSEUDTBLB____TBLB_DATETM__.isVisible"
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_DATETM__.props"
					:model-value="model.ValDatetm.value"
					@reset-icon-click="model.ValDatetm.fnUpdateValue(model.ValDatetm.originalValue ?? new Date())"
					@update:model-value="model.ValDatetm.fnUpdateValue($event ?? '')" />
			</grid-base-input-structure>
		</td>
		<td v-if="canShowColumn('TBLB', 'DATETS')">
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_DATETS__.wrapperProps">
				<q-date-time-picker
					v-if="controls.GRPB____PSEUDTBLB____TBLB_DATETS__.isVisible"
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_DATETS__.props"
					:model-value="model.ValDatets.value"
					@reset-icon-click="model.ValDatets.fnUpdateValue(model.ValDatets.originalValue ?? new Date())"
					@update:model-value="model.ValDatets.fnUpdateValue($event ?? '')" />
			</grid-base-input-structure>
		</td>
		<td v-if="canShowColumn('TBLB', 'TIMEHM')">
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_TIMEHM__.wrapperProps">
				<q-date-time-picker
					v-if="controls.GRPB____PSEUDTBLB____TBLB_TIMEHM__.isVisible"
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_TIMEHM__.props"
					:model-value="model.ValTimehm.value"
					@reset-icon-click="model.ValTimehm.fnUpdateValue(model.ValTimehm.originalValue ?? new Date())"
					@update:model-value="model.ValTimehm.fnUpdateValue($event ?? '')" />
			</grid-base-input-structure>
		</td>
		<td v-if="canShowColumn('TBLB', 'ENUMT')">
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_ENUMT___.wrapperProps">
				<q-select
					v-if="controls.GRPB____PSEUDTBLB____TBLB_ENUMT___.isVisible"
					v-bind="controls.GRPB____PSEUDTBLB____TBLB_ENUMT___.props"
					:model-value="model.ValEnumt.value"
					@update:model-value="model.ValEnumt.fnUpdateValue" />
			</grid-base-input-structure>
		</td>
		<td v-if="canShowColumn('TBLB', 'ENUMN')">
			<grid-base-input-structure
				class=""
				v-bind="controls.GRPB____PSEUDTBLB____TBLB_ENUMN___.wrapperProps">
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

	const requiredTextResources = ['QGridFormGrpbPseudtblb', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS GRPB____PSEUDTBLB____]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QGridFormGrpbPseudtblb',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QGridFormGrpbPseudtblb', false),

				interfaceMetadata: {
					id: 'QGridFormGrpbPseudtblb', // Used for resources
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
						label: computed(() => this.Resources.TEXT04938),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
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
						label: computed(() => this.Resources.MULTILINE_TEXT38013),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_NUMINT__: new fieldControlClass.NumberControl({
						modelField: 'ValNumint',
						valueChangeEvent: 'fieldChange:tblb.numint',
						id: 'GRPB____PSEUDTBLB____TBLB_NUMINT__',
						name: 'NUMINT',
						size: 'medium',
						label: computed(() => this.Resources.NUMERIC__INTEGER_50289),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 10,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_NUMDEC__: new fieldControlClass.NumberControl({
						modelField: 'ValNumdec',
						valueChangeEvent: 'fieldChange:tblb.numdec',
						id: 'GRPB____PSEUDTBLB____TBLB_NUMDEC__',
						name: 'NUMDEC',
						size: 'medium',
						label: computed(() => this.Resources.NUMERIC__DECIMAL_36157),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 6,
						maxDecimals: 3,
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_CURINT__: new fieldControlClass.CurrencyControl({
						modelField: 'ValCurint',
						valueChangeEvent: 'fieldChange:tblb.curint',
						id: 'GRPB____PSEUDTBLB____TBLB_CURINT__',
						name: 'CURINT',
						size: 'large',
						label: computed(() => this.Resources.CURRENCY__INTERGER_21437),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 7,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_CURDEC__: new fieldControlClass.CurrencyControl({
						modelField: 'ValCurdec',
						valueChangeEvent: 'fieldChange:tblb.curdec',
						id: 'GRPB____PSEUDTBLB____TBLB_CURDEC__',
						name: 'CURDEC',
						size: 'medium',
						label: computed(() => this.Resources.CURRENCY__DECIMAL_11718),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 5,
						maxDecimals: 4,
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_BOOL____: new fieldControlClass.BooleanControl({
						modelField: 'ValBool',
						valueChangeEvent: 'fieldChange:tblb.bool',
						id: 'GRPB____PSEUDTBLB____TBLB_BOOL____',
						name: 'BOOL',
						size: 'mini',
						label: computed(() => this.Resources.BOOLEAN45002),
						placeholder: '',
						labelPosition: computed(() => this.layoutConfig.CheckboxLabelAlignment),
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_DATE____: new fieldControlClass.DateControl({
						modelField: 'ValDate',
						valueChangeEvent: 'fieldChange:tblb.date',
						id: 'GRPB____PSEUDTBLB____TBLB_DATE____',
						name: 'DATE',
						size: 'small',
						label: computed(() => this.Resources.DATE18475),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						format: 'date',
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_DATETM__: new fieldControlClass.DateControl({
						modelField: 'ValDatetm',
						valueChangeEvent: 'fieldChange:tblb.datetm',
						id: 'GRPB____PSEUDTBLB____TBLB_DATETM__',
						name: 'DATETM',
						size: 'medium',
						label: computed(() => this.Resources.DATETIME__MINUTES_59352),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						format: 'dateTime',
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_DATETS__: new fieldControlClass.DateControl({
						modelField: 'ValDatets',
						valueChangeEvent: 'fieldChange:tblb.datets',
						id: 'GRPB____PSEUDTBLB____TBLB_DATETS__',
						name: 'DATETS',
						size: 'large',
						label: computed(() => this.Resources.DATETIME__SECONDS_49861),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						format: 'dateTimeSeconds',
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_TIMEHM__: new fieldControlClass.TimeControl({
						modelField: 'ValTimehm',
						valueChangeEvent: 'fieldChange:tblb.timehm',
						id: 'GRPB____PSEUDTBLB____TBLB_TIMEHM__',
						name: 'TIMEHM',
						size: 'large',
						label: computed(() => this.Resources.TIME__HOURS_MINUTES_01660),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						format: 'time',
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_ENUMT___: new fieldControlClass.ArrayStringControl({
						modelField: 'ValEnumt',
						valueChangeEvent: 'fieldChange:tblb.enumt',
						id: 'GRPB____PSEUDTBLB____TBLB_ENUMT___',
						name: 'ENUMT',
						size: 'medium',
						label: computed(() => this.Resources.ENUMERATION__TEXT_15855),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 1,
						labelId: 'label_GRPB____PSEUDTBLB____TBLB_ENUMT___',
						arrayName: 'typet',
						helpShortItem: '${field.ShortHelpItem}',
						helpDetailedItem: '${field.DetailedHelpItem}',
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB____TBLB_ENUMN___: new fieldControlClass.ArrayNumberControl({
						modelField: 'ValEnumn',
						valueChangeEvent: 'fieldChange:tblb.enumn',
						id: 'GRPB____PSEUDTBLB____TBLB_ENUMN___',
						name: 'ENUMN',
						size: 'medium',
						label: computed(() => this.Resources.ENUMERATION__NUMERIC44708),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 1,
						maxDecimals: 0,
						arrayName: 'typen',
						helpShortItem: '${field.ShortHelpItem}',
						helpDetailedItem: '${field.DetailedHelpItem}',
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
					get extraProperties() { return vm.model.extraProperties },
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

				applyForm = await this.model.setDocumentChanges()

				if (applyForm)
				{
					const results = await this.model.saveDocuments()
					applyForm = results.every((e) => e === true)
				}

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

				saveForm = await this.model.setDocumentChanges()

				if (saveForm)
				{
					const results = await this.model.saveDocuments()
					saveForm = results.every((e) => e === true)
				}

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
			 * Called whenever a field is unfocused.
			 * @param {*} fieldObject The object representing the field in the model
			 * @param {*} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onBlur(fieldObject, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT CTRLBLR GRPB____PSEUDTBLB____]/
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
// USE /[MANUAL GQT CTRLUPD GRPB____PSEUDTBLB____]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
		}
	}
</script>
