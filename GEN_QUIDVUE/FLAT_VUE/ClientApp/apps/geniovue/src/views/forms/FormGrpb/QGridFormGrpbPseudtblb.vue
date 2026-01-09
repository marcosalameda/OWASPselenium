<template>
	<q-grid-table-row
		:id="id"
		:initial-state="initialState"
		:is-deleted-state="isDeletedState"
		:mode="mode"
		:nested-model="nestedModel"
		:permissions="permissions"
		:texts="texts"
		@mark-for-deletion="emitEvent('mark-for-deletion')"
		@undo-deletion="emitEvent('undo-deletion')"
		@toggle-errors="emitEvent('toggle-errors')">
		<q-grid-table-column
			v-if="canShowColumn('TBLB', 'TEXT')"
			class=""
			v-bind="controls.GRPB____PSEUDTBLB______TBLB__TEXT.wrapperProps">
			<q-text-field
				v-bind="controls.GRPB____PSEUDTBLB______TBLB__TEXT.props"
				@blur="onBlur(controls.GRPB____PSEUDTBLB______TBLB__TEXT, model.ValText.value)"
				@change="model.ValText.fnUpdateValueOnChange" />
		</q-grid-table-column>
		<q-grid-table-column
			v-if="canShowColumn('TBLB', 'TEXTML')"
			class=""
			v-bind="controls.GRPB____PSEUDTBLB______TBLB__TEXTML.wrapperProps">
			<q-text-area
				v-if="controls.GRPB____PSEUDTBLB______TBLB__TEXTML.isVisible"
				v-bind="controls.GRPB____PSEUDTBLB______TBLB__TEXTML.props"
				v-on="controls.GRPB____PSEUDTBLB______TBLB__TEXTML.handlers" />
		</q-grid-table-column>
		<q-grid-table-column
			v-if="canShowColumn('TBLB', 'NUMINT')"
			class=""
			v-bind="controls.GRPB____PSEUDTBLB______TBLB__NUMINT.wrapperProps">
			<q-numeric-input
				v-if="controls.GRPB____PSEUDTBLB______TBLB__NUMINT.isVisible"
				v-bind="controls.GRPB____PSEUDTBLB______TBLB__NUMINT.props"
				@update:model-value="model.ValNumint.fnUpdateValue" />
		</q-grid-table-column>
		<q-grid-table-column
			v-if="canShowColumn('TBLB', 'NUMDEC')"
			class=""
			v-bind="controls.GRPB____PSEUDTBLB______TBLB__NUMDEC.wrapperProps">
			<q-numeric-input
				v-if="controls.GRPB____PSEUDTBLB______TBLB__NUMDEC.isVisible"
				v-bind="controls.GRPB____PSEUDTBLB______TBLB__NUMDEC.props"
				@update:model-value="model.ValNumdec.fnUpdateValue" />
		</q-grid-table-column>
		<q-grid-table-column
			v-if="canShowColumn('TBLB', 'CURINT')"
			class=""
			v-bind="controls.GRPB____PSEUDTBLB______TBLB__CURINT.wrapperProps">
			<q-numeric-input
				v-if="controls.GRPB____PSEUDTBLB______TBLB__CURINT.isVisible"
				v-bind="controls.GRPB____PSEUDTBLB______TBLB__CURINT.props"
				@update:model-value="model.ValCurint.fnUpdateValue" />
		</q-grid-table-column>
		<q-grid-table-column
			v-if="canShowColumn('TBLB', 'CURDEC')"
			class=""
			v-bind="controls.GRPB____PSEUDTBLB______TBLB__CURDEC.wrapperProps">
			<q-numeric-input
				v-if="controls.GRPB____PSEUDTBLB______TBLB__CURDEC.isVisible"
				v-bind="controls.GRPB____PSEUDTBLB______TBLB__CURDEC.props"
				@update:model-value="model.ValCurdec.fnUpdateValue" />
		</q-grid-table-column>
		<q-grid-table-column
			v-if="canShowColumn('TBLB', 'BOOL')"
			class=""
			v-bind="controls.GRPB____PSEUDTBLB______TBLB__BOOL.wrapperProps">
			<template #label>
				<q-checkbox
					v-if="controls.GRPB____PSEUDTBLB______TBLB__BOOL.isVisible"
					v-bind="controls.GRPB____PSEUDTBLB______TBLB__BOOL.props"
					v-on="controls.GRPB____PSEUDTBLB______TBLB__BOOL.handlers" />
			</template>
		</q-grid-table-column>
		<q-grid-table-column
			v-if="canShowColumn('TBLB', 'DATE')"
			class=""
			v-bind="controls.GRPB____PSEUDTBLB______TBLB__DATE.wrapperProps">
			<q-date-time-picker
				v-if="controls.GRPB____PSEUDTBLB______TBLB__DATE.isVisible"
				v-bind="controls.GRPB____PSEUDTBLB______TBLB__DATE.props"
				:model-value="model.ValDate.value"
				@reset-icon-click="model.ValDate.fnUpdateValue(model.ValDate.originalValue ?? new Date())"
				@update:model-value="model.ValDate.fnUpdateValue($event ?? '')" />
		</q-grid-table-column>
		<q-grid-table-column
			v-if="canShowColumn('TBLB', 'DATETM')"
			class=""
			v-bind="controls.GRPB____PSEUDTBLB______TBLB__DATETM.wrapperProps">
			<q-date-time-picker
				v-if="controls.GRPB____PSEUDTBLB______TBLB__DATETM.isVisible"
				v-bind="controls.GRPB____PSEUDTBLB______TBLB__DATETM.props"
				:model-value="model.ValDatetm.value"
				@reset-icon-click="model.ValDatetm.fnUpdateValue(model.ValDatetm.originalValue ?? new Date())"
				@update:model-value="model.ValDatetm.fnUpdateValue($event ?? '')" />
		</q-grid-table-column>
		<q-grid-table-column
			v-if="canShowColumn('TBLB', 'DATETS')"
			class=""
			v-bind="controls.GRPB____PSEUDTBLB______TBLB__DATETS.wrapperProps">
			<q-date-time-picker
				v-if="controls.GRPB____PSEUDTBLB______TBLB__DATETS.isVisible"
				v-bind="controls.GRPB____PSEUDTBLB______TBLB__DATETS.props"
				:model-value="model.ValDatets.value"
				@reset-icon-click="model.ValDatets.fnUpdateValue(model.ValDatets.originalValue ?? new Date())"
				@update:model-value="model.ValDatets.fnUpdateValue($event ?? '')" />
		</q-grid-table-column>
		<q-grid-table-column
			v-if="canShowColumn('TBLB', 'TIMEHM')"
			class=""
			v-bind="controls.GRPB____PSEUDTBLB______TBLB__TIMEHM.wrapperProps">
			<q-date-time-picker
				v-if="controls.GRPB____PSEUDTBLB______TBLB__TIMEHM.isVisible"
				v-bind="controls.GRPB____PSEUDTBLB______TBLB__TIMEHM.props"
				:model-value="model.ValTimehm.value"
				@reset-icon-click="model.ValTimehm.fnUpdateValue(model.ValTimehm.originalValue ?? new Date())"
				@update:model-value="model.ValTimehm.fnUpdateValue($event ?? '')" />
		</q-grid-table-column>
		<q-grid-table-column
			v-if="canShowColumn('TBLB', 'ENUMT')"
			class=""
			v-bind="controls.GRPB____PSEUDTBLB______TBLB__ENUMT.wrapperProps">
			<q-select
				v-if="controls.GRPB____PSEUDTBLB______TBLB__ENUMT.isVisible"
				v-bind="controls.GRPB____PSEUDTBLB______TBLB__ENUMT.props"
				@update:model-value="model.ValEnumt.fnUpdateValue" />
		</q-grid-table-column>
		<q-grid-table-column
			v-if="canShowColumn('TBLB', 'ENUMN')"
			class=""
			v-bind="controls.GRPB____PSEUDTBLB______TBLB__ENUMN.wrapperProps">
			<q-select
				v-if="controls.GRPB____PSEUDTBLB______TBLB__ENUMN.isVisible"
				v-bind="controls.GRPB____PSEUDTBLB______TBLB__ENUMN.props"
				@update:model-value="model.ValEnumn.fnUpdateValue" />
		</q-grid-table-column>
	</q-grid-table-row>
</template>

<script>
	/* eslint-disable @typescript-eslint/no-unused-vars */
	import { computed, defineAsyncComponent, readonly } from 'vue'

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
	/* eslint-enable @typescript-eslint/no-unused-vars */

	import QGridTableColumn from '@/components/inputs/GridBaseInputStructure.vue'
	import QGridTableRow from '@/components/table/QGridTableRow.vue'

	const requiredTextResources = ['QGridFormGrpbPseudtblb', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS GRPB____PSEUDTBLB____]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QGridFormGrpbPseudtblb',

		components: {
			QGridTableColumn,
			QGridTableRow
		},

		mixins: [GridFormHandlers],

		expose: ['navigationId'],

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
					GRPB____PSEUDTBLB______TBLB__TEXT: new fieldControlClass.StringControl({
						modelField: 'ValText',
						valueChangeEvent: 'fieldChange:tblb.text',
						id: 'GRPB____PSEUDTBLB______TBLB__TEXT',
						name: 'TEXT',
						size: 'xlarge',
						label: computed(() => this.Resources.TEXT04938),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB______TBLB__TEXTML: new fieldControlClass.MultilineStringControl({
						modelField: 'ValTextml',
						valueChangeEvent: 'fieldChange:tblb.textml',
						id: 'GRPB____PSEUDTBLB______TBLB__TEXTML',
						name: 'TEXTML',
						size: 'xlarge',
						label: computed(() => this.Resources.MULTILINE_TEXT38013),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						rows: 0,
						cols: 30,
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB______TBLB__NUMINT: new fieldControlClass.NumberControl({
						modelField: 'ValNumint',
						valueChangeEvent: 'fieldChange:tblb.numint',
						id: 'GRPB____PSEUDTBLB______TBLB__NUMINT',
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
					GRPB____PSEUDTBLB______TBLB__NUMDEC: new fieldControlClass.NumberControl({
						modelField: 'ValNumdec',
						valueChangeEvent: 'fieldChange:tblb.numdec',
						id: 'GRPB____PSEUDTBLB______TBLB__NUMDEC',
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
					GRPB____PSEUDTBLB______TBLB__CURINT: new fieldControlClass.CurrencyControl({
						modelField: 'ValCurint',
						valueChangeEvent: 'fieldChange:tblb.curint',
						id: 'GRPB____PSEUDTBLB______TBLB__CURINT',
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
					GRPB____PSEUDTBLB______TBLB__CURDEC: new fieldControlClass.CurrencyControl({
						modelField: 'ValCurdec',
						valueChangeEvent: 'fieldChange:tblb.curdec',
						id: 'GRPB____PSEUDTBLB______TBLB__CURDEC',
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
					GRPB____PSEUDTBLB______TBLB__BOOL: new fieldControlClass.BooleanControl({
						modelField: 'ValBool',
						valueChangeEvent: 'fieldChange:tblb.bool',
						id: 'GRPB____PSEUDTBLB______TBLB__BOOL',
						name: 'BOOL',
						size: 'mini',
						label: computed(() => this.Resources.BOOLEAN45002),
						placeholder: '',
						labelPosition: computed(() => this.$app.layout.CheckboxLabelAlignment),
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB______TBLB__DATE: new fieldControlClass.DateControl({
						modelField: 'ValDate',
						valueChangeEvent: 'fieldChange:tblb.date',
						id: 'GRPB____PSEUDTBLB______TBLB__DATE',
						name: 'DATE',
						size: 'small',
						label: computed(() => this.Resources.DATE18475),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB______TBLB__DATETM: new fieldControlClass.DateControl({
						modelField: 'ValDatetm',
						valueChangeEvent: 'fieldChange:tblb.datetm',
						id: 'GRPB____PSEUDTBLB______TBLB__DATETM',
						name: 'DATETM',
						size: 'medium',
						label: computed(() => this.Resources.DATETIME__MINUTES_59352),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'dateTime',
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB______TBLB__DATETS: new fieldControlClass.DateControl({
						modelField: 'ValDatets',
						valueChangeEvent: 'fieldChange:tblb.datets',
						id: 'GRPB____PSEUDTBLB______TBLB__DATETS',
						name: 'DATETS',
						size: 'large',
						label: computed(() => this.Resources.DATETIME__SECONDS_49861),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'dateTimeSeconds',
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB______TBLB__TIMEHM: new fieldControlClass.TimeControl({
						modelField: 'ValTimehm',
						valueChangeEvent: 'fieldChange:tblb.timehm',
						id: 'GRPB____PSEUDTBLB______TBLB__TIMEHM',
						name: 'TIMEHM',
						size: 'large',
						label: computed(() => this.Resources.TIME__HOURS_MINUTES_01660),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'time',
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB______TBLB__ENUMT: new fieldControlClass.ArrayStringControl({
						modelField: 'ValEnumt',
						valueChangeEvent: 'fieldChange:tblb.enumt',
						id: 'GRPB____PSEUDTBLB______TBLB__ENUMT',
						name: 'ENUMT',
						size: 'medium',
						label: computed(() => this.Resources.ENUMERATION__TEXT_15855),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 1,
						arrayName: 'typet',
						helpShortItem: '${field.ShortHelpItem}',
						helpDetailedItem: '${field.DetailedHelpItem}',
						controlLimits: [
						],
					}, this),
					GRPB____PSEUDTBLB______TBLB__ENUMN: new fieldControlClass.ArrayNumberControl({
						modelField: 'ValEnumn',
						valueChangeEvent: 'fieldChange:tblb.enumn',
						id: 'GRPB____PSEUDTBLB______TBLB__ENUMN',
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

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT GRPB____PSEUDTBLB____]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
			/**
			 * Called before form init.
			 */
			async beforeLoad()
			{
				// Execute the "Before init" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeInit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('before-load-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT BEFORE_LOAD_JS GRPB____PSEUDTBLB____]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called after form init.
			 */
			async afterLoad()
			{
				// Execute the "After init" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterInit)
				for (const trigger of triggers)
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
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				const ticketsPromise = this.model.updateFilesTickets(true)
				this.addBusy(ticketsPromise, this.Resources[hardcodedTexts.processing])
				const canSetDocums = await ticketsPromise

				if (canSetDocums)
				{
					let results
					const changesPromise = this.model.setDocumentChanges()
					this.addBusy(changesPromise, this.Resources[hardcodedTexts.processing])
					applyForm = await changesPromise

					if (applyForm)
					{
						const insertsPromise = this.model.saveDocuments()
						this.addBusy(insertsPromise, this.Resources[hardcodedTexts.processing])
						results = await insertsPromise
						applyForm = results.every((e) => e === true)
					}

					if (!changesPromise || (results && !results.every((e) => e === true)))
					{
						this.validationErrors = {
							Erro: this.Resources.OCORREU_UM_ERRO_AO_T51884
						}
					}
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
				for (const trigger of triggers)
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
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				const ticketsPromise = this.model.updateFilesTickets()
				this.addBusy(ticketsPromise, this.Resources[hardcodedTexts.processing])
				const canSetDocums = await ticketsPromise

				if (canSetDocums)
				{
					let results
					const changesPromise = this.model.setDocumentChanges()
					this.addBusy(changesPromise, this.Resources[hardcodedTexts.processing])
					saveForm = await changesPromise

					if (saveForm)
					{
						const insertsPromise = this.model.saveDocuments()
						this.addBusy(insertsPromise, this.Resources[hardcodedTexts.processing])
						results = await insertsPromise
						saveForm = results.every((e) => e === true)
					}

					if (!changesPromise || (results && !results.every((e) => e === true)))
					{
						this.validationErrors = {
							Erro: this.Resources.OCORREU_UM_ERRO_AO_T51884
						}
					}
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
				// Execute the "After save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterSave)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT AFTER_SAVE_JS GRPB____PSEUDTBLB____]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called before the record is deleted.
			 */
			async beforeDel()
			{
				this.emitEvent('before-delete-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT BEFORE_DEL_JS GRPB____PSEUDTBLB____]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called after the record is deleted.
			 */
			async afterDel()
			{
				this.emitEvent('after-delete-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT AFTER_DEL_JS GRPB____PSEUDTBLB____]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called before leaving the form.
			 */
			async beforeExit()
			{
				// Execute the "Before exit" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeExit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('before-exit-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT BEFORE_EXIT_JS GRPB____PSEUDTBLB____]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called after leaving the form.
			 */
			async afterExit()
			{
				// Execute the "After exit" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterExit)
				for (const trigger of triggers)
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
