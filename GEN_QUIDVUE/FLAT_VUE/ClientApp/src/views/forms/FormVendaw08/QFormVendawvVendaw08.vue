<template>
	<teleport
		v-if="formModalIsReady && showFormHeader"
		:to="`#${uiContainersId.header}`"
		:disabled="!isPopup || isNested">
		<div
			ref="formHeader"
			:class="{ 'c-sticky-header': isStickyHeader, 'sticky-top': isStickyTop }">
			<div
				v-if="showFormHeader"
				class="c-action-bar">
				<h1
					v-if="formControl.uiComponents.header && formInfo.designation"
					class="form-header"
					:id="formTitleId">
					{{ formInfo.designation }}
				</h1>

				<div class="c-action-bar__menu">
					<template
						v-for="(section, sectionId) in formButtonSections"
						:key="sectionId">
						<span
							v-if="showHeadingSep(sectionId)"
							class="main-title-sep" />

						<q-button-group
							v-if="formControl.uiComponents.headerButtons"
							borderless>
							<template
								v-for="btn in section"
								:key="btn.id">
								<q-button
									v-if="showFormHeaderButton(btn)"
									:id="`top-${btn.id}`"
									:title="btn.text"
									:label="btn.label"
									:disabled="btn.disabled"
									:active="btn.isSelected"
									@click="btn.action">
									<q-icon
										v-if="btn.icon"
										v-bind="btn.icon" />
								</q-button>
							</template>
						</q-button-group>
					</template>
				</div>
			</div>

			<q-anchor-container-horizontal
				v-if="layoutConfig.FormAnchorsPosition === 'form-header' && visibleGroups.length > 0"
				:anchors="anchorGroups"
				:controls="visibleControls"
				@focus-control="(...args) => focusControl(...args)" />
		</div>
	</teleport>

	<teleport
		v-if="formModalIsReady && showFormBody"
		:to="`#${uiContainersId.body}`"
		:disabled="!isPopup || isNested">
		<q-validation-summary
			:messages="validationErrors"
			@error-clicked="focusField" />

		<div class="heading-button-group-clear"></div>

		<div :class="[`float-${actionsPlacement}`, 'c-action-bar']">
			<q-button-group borderless>
				<template
					v-for="btn in formButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isActive && btn.isVisible && btn.showInHeading"
						:id="`heading-${btn.id}`"
						:label="btn.text"
						:b-style="btn.style"
						:disabled="btn.disabled"
						:icon-on-right="btn.iconOnRight"
						:class="btn.classes"
						@click="btn.action(); btn.emitAction ? $emit(btn.emitAction.name, btn.emitAction.params) : null">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</q-button-group>
		</div>

		<div class="heading-button-group-clear"></div>

		<div
			class="form-flow"
			data-key="VENDAW08"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.VENDAWV_PSEUDFASES___.isVisible">
					<q-control-wrapper
						v-show="controls.VENDAWV_PSEUDFASES___.isVisible"
						class="control-join-group">
						<q-wizard
							id="VENDAWV_PSEUDFASES___"
							:is-required="controls.VENDAWV_PSEUDFASES___.isRequired"
							v-bind="controls.VENDAWV_PSEUDFASES___.wizardData"
							v-on="controls.VENDAWV_PSEUDFASES___.handlers">
							<!-- Start VENDAWV_PSEUDFASES___ -->
							<q-row-container
								v-show="controls.VENDAW08PSEUDNOVOGR08.isVisible"
								is-large>
								<q-control-wrapper
									v-show="controls.VENDAW08PSEUDNOVOGR08.isVisible"
									class="row-line-group">
									<q-group-box-container
										id="VENDAW08PSEUDNOVOGR08"
										v-bind="controls.VENDAW08PSEUDNOVOGR08"
										:is-visible="controls.VENDAW08PSEUDNOVOGR08.isVisible">
										<!-- Start VENDAW08PSEUDNOVOGR08 -->
										<q-row-container v-show="controls.VENDAW08SALE_DTACOMPA.isVisible">
											<q-control-wrapper
												v-show="controls.VENDAW08SALE_DTACOMPA.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.VENDAW08SALE_DTACOMPA"
													v-on="controls.VENDAW08SALE_DTACOMPA.handlers"
													:loading="controls.VENDAW08SALE_DTACOMPA.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-date-time-picker
														v-if="controls.VENDAW08SALE_DTACOMPA.isVisible"
														v-bind="controls.VENDAW08SALE_DTACOMPA.props"
														:model-value="model.ValDtacompa.value"
														@reset-icon-click="model.ValDtacompa.fnUpdateValue(model.ValDtacompa.originalValue ?? new Date())"
														@update:model-value="model.ValDtacompa.fnUpdateValue($event ?? '')" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<!-- End VENDAW08PSEUDNOVOGR08 -->
									</q-group-box-container>
								</q-control-wrapper>
							</q-row-container>
							<!-- End VENDAWV_PSEUDFASES___ -->
						</q-wizard>
					</q-control-wrapper>
				</q-row-container>
			</template>
		</div>
	</teleport>

	<hr v-if="!isPopup && showFormFooter" />

	<teleport
		v-if="formModalIsReady && showFormFooter"
		:to="`#${uiContainersId.footer}`"
		:disabled="!isPopup || isNested">
		<q-row-container v-if="showFormFooter">
			<div id="footer-action-btns">
				<template
					v-for="btn in formButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isActive && btn.isVisible && btn.showInFooter"
						:id="`bottom-${btn.id}`"
						:label="btn.text"
						:b-style="btn.style"
						:disabled="btn.disabled"
						:icon-on-right="btn.iconOnRight"
						:class="btn.classes"
						@click="btn.action(); btn.emitAction ? $emit(btn.emitAction.name, btn.emitAction.params) : null">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</div>
		</q-row-container>
	</teleport>
</template>

<script>
	/* eslint-disable no-unused-vars */
	import { computed, readonly, defineAsyncComponent } from 'vue'
	import { useRoute } from 'vue-router'

	import WizardHandlers from '@/mixins/wizardHandlers.js'
	import FormHandlers from '@/mixins/formHandlers.js'
	import formFunctions from '@/mixins/formFunctions.js'
	import genericFunctions from '@/mixins/genericFunctions.js'
	import listFunctions from '@/mixins/listFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'
	import modelFieldType from '@/mixins/formModelFieldTypes.js'
	import fieldControlClass from '@/mixins/fieldControl.js'
	import qEnums from '@/mixins/quidgest.mainEnums.js'

	import hardcodedTexts from '@/hardcodedTexts.js'
	import netAPI from '@/api/network'
	import asyncProcM from '@/api/global/asyncProcMonitoring.js'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	/* eslint-enable no-unused-vars */

	import FormViewModel from './QFormVendawvVendaw08ViewModel.js'

	const requiredTextResources = ['QFormVendawvVendaw08', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS VENDAW08]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormVendawvVendaw08',

		components: {
		},

		mixins: [
			WizardHandlers,
			FormHandlers
		],

		props: {
			/**
			 * Parameters passed in case the form is nested.
			 */
			nestedRouteParams: {
				type: Object,
				default: () => ({
					name: 'VENDAW08',
					location: 'form-VENDAWV-VENDAW08',
					params: {
						isNested: true
					}
				})
			}
		},

		expose: [
			'wizardMode',
			'wizardPath',
			'cancel',
			'initFormProperties',
			'navigationId'
		],

		setup(props)
		{
			const route = useRoute()

			return {
				/*
				 * As properties are reactive, when using $route.params, then when we exit it updates cached components.
				 * Properties have no value and this creates an error in new versions of vue-router.
				 * That's why the value has to be copied to a local property to be used in the router-link tag.
				 */
				currentRouteParams: props.isNested ? {} : route.params
			}
		},

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormVendawvVendaw08', false),

				interfaceMetadata: {
					id: 'QFormVendawvVendaw08', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'wizard',
					name: 'VENDAW08',
					route: 'form-VENDAWV-VENDAW08',
					area: 'SALE',
					primaryKey: 'ValCodvenda',
					designation: computed(() => this.Resources.ACOMPANHAMENTO53507),
					identifier: '', // Unique identifier received by route (when it's nested).
					mode: ''
				},

				formTitleId: computed(() => this.formInfo.identifier + "_title"),

				wizardData: readonly({
					type: qEnums.wizardTypes.vertical,
					wizardId: 'Vendawv_Fases',
					title: computed(() => this.Resources.PHASE_AREA51284),
					showTitle: false,
					disallowEdit: false,
					isDynamic: false,
					blockedSteps: true,
					visibleSteps: 5,
					stepList: [
						{
							order: 1,
							title: computed(() => this.Resources.PROPESCCAO51483),
							caption: computed(() => this.Resources.PHASE_CAPTION_PLACEH06557),
							route: 'form-VENDAWV-VENDAW01',
							isRequired: false,
						},
						{
							order: 2,
							title: computed(() => this.Resources.QUALIFICACAO07026),
							caption: computed(() => this.Resources.PHASE_CAPTION_PLACEH06557),
							route: 'form-VENDAWV-VENDAW02',
							isRequired: false,
						},
						{
							order: 3,
							title: computed(() => this.Resources.PRE_ABORDAGEM30870),
							caption: computed(() => this.Resources.PHASE_CAPTION_PLACEH06557),
							route: 'form-VENDAWV-VENDAW03',
							isRequired: false,
						},
						{
							order: 4,
							title: computed(() => this.Resources.ABORDAGEM05839),
							caption: computed(() => this.Resources.PHASE_CAPTION_PLACEH06557),
							route: 'form-VENDAWV-VENDAW04',
							isRequired: false,
						},
						{
							order: 5,
							title: computed(() => this.Resources.APRESENTACAO15975),
							caption: computed(() => this.Resources.PHASE_CAPTION_PLACEH06557),
							route: 'form-VENDAWV-VENDAW05',
							isRequired: false,
						},
						{
							order: 6,
							title: computed(() => this.Resources.SUPERAR_OBJECOES40220),
							caption: computed(() => this.Resources.PHASE_CAPTION_PLACEH06557),
							route: 'form-VENDAWV-VENDAW06',
							isRequired: false,
						},
						{
							order: 7,
							title: computed(() => this.Resources.FECHO_DE_VENDA55198),
							caption: computed(() => this.Resources.PHASE_CAPTION_PLACEH06557),
							route: 'form-VENDAWV-VENDAW07',
							isRequired: false,
						},
						{
							order: 8,
							title: computed(() => this.Resources.ACOMPANHAMENTO53507),
							caption: computed(() => this.Resources.PHASE_CAPTION_PLACEH06557),
							route: 'form-VENDAWV-VENDAW08',
							isRequired: false,
						}
					],
					stepData: {
						order: 8,
						id: 'wizard-step-FASES-8',
						saveIsOff: false,
						applyIsOff: false,
						isFinal: true,
						backwardIsOff: false,
						applyOnBackward: true,
						clearOnBackward: false
					},
					stepFieldIds: [
						'VENDAW08PSEUDNOVOGR08',
						'VENDAW08SALE_DTACOMPA',
					]
				}),

				formButtons: {
					changeToShow: {
						id: 'change-to-show-btn',
						icon: {
							icon: 'view',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.view]),
						style: 'secondary',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.show === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToShowMode
					},
					changeToEdit: {
						id: 'change-to-edit-btn',
						icon: {
							icon: 'pencil',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.edit]),
						style: 'secondary',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.edit === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToEditMode
					},
					changeToDuplicate: {
						id: 'change-to-dup-btn',
						icon: {
							icon: 'duplicate',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.duplicate]),
						style: 'secondary',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.duplicate === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && vm.formModes.new !== vm.formInfo.mode),
						action: vm.changeToDupMode
					},
					changeToDelete: {
						id: 'change-to-delete-btn',
						icon: {
							icon: 'delete',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.delete]),
						style: 'secondary',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.delete === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToDeleteMode
					},
					changeToInsert: {
						id: 'change-to-insert-btn',
						icon: {
							icon: 'add',
							type: 'svg'
						},
						type: 'form-insert',
						text: computed(() => vm.Resources[hardcodedTexts.insert]),
						label: computed(() => vm.Resources[hardcodedTexts.insert]),
						style: 'secondary',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.new === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && vm.formModes.duplicate !== vm.formInfo.mode),
						action: vm.changeToInsertMode
					},
					applyBtn: {
						id: 'apply-btn',
						icon: {
							icon: 'apply',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.apply]),
						style: 'secondary',
						classes: ['wiz-action', 'save'],
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						disabled: computed(() => vm.wizardData.stepData.applyIsOff),
						action: () => vm.applyChanges(true)
					},
					backwardBtn: {
						id: 'backward-btn',
						icon: {
							icon: 'step-back',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.previous]),
						style: 'secondary',
						classes: ['wiz-action', 'backward'],
						showInHeader: false,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed),
						disabled: computed(() => vm.wizardData.stepData.backwardIsOff || vm.formInfo.route === vm.wizardPath[0]),
						action: vm.goToPreviousStep
					},
					forwardBtn: {
						id: 'forward-btn',
						icon: {
							icon: 'step-forward',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.next]),
						style: 'primary',
						classes: ['wiz-action', 'forward'],
						iconOnRight: true,
						showInHeader: false,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed),
						disabled: computed(() => vm.wizardData.stepData.isFinal || !vm.isEditable && vm.isCurrentStep && (vm.wizardData.isDynamic || vm.wizardData.blockedSteps)),
						action: vm.goToNextStep
					},
					repeatInsertBtn: {
						id: 'repeat-insert-btn',
						icon: {
							icon: 'save-new',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.repeatInsert]),
						style: 'primary',
						showInHeader: true,
						showInFooter: true,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.formInfo.mode === vm.formModes.new && !vm.wizardData.stepData.saveIsOff),
						action: () => vm.saveForm(true)
					},
					saveBtn: {
						id: 'save-btn',
						icon: {
							icon: 'save',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources.SAVE04165),
						style: 'primary',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable && !vm.wizardData.stepData.saveIsOff),
						action: vm.saveForm
					},
					confirmBtn: {
						id: 'confirm-btn',
						icon: {
							icon: 'check',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[vm.isNested ? hardcodedTexts.delete : hardcodedTexts.confirm]),
						style: 'primary',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && (vm.formInfo.mode === vm.formModes.delete || vm.isNested)),
						action: vm.deleteRecord
					},
					cancelBtn: {
						id: 'cancel-btn',
						icon: {
							icon: 'cancel',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources.CANCEL65428),
						style: 'secondary',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: vm.leaveForm
					},
					resetCancelBtn: {
						id: 'reset-cancel-btn',
						icon: {
							icon: 'cancel',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.cancel]),
						style: 'secondary',
						showInHeader: true,
						showInFooter: true,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: () => vm.model.resetValues(),
						emitAction: {
							name: 'deselect',
							params: {}
						}
					},
					editBtn: {
						id: 'edit-btn',
						icon: {
							icon: 'pencil',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.edit]),
						style: 'primary',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.parentFormMode !== vm.formModes.show && vm.parentFormMode !== vm.formModes.delete),
						action: () => {},
						emitAction: {
							name: 'edit',
							params: {}
						}
					},
					deleteQuickBtn: {
						id: 'delete-btn',
						icon: {
							icon: 'bin',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.delete]),
						style: 'primary',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.parentFormMode !== vm.formModes.show && (typeof vm.permissions.canDelete === 'boolean' ? vm.permissions.canDelete : true)),
						action: vm.deleteRecord
					},
					backBtn: {
						id: 'back-btn',
						icon: {
							icon: 'back',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.isPopup ? vm.Resources[hardcodedTexts.close] : vm.Resources[hardcodedTexts.goBack]),
						style: 'secondary',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => !vm.authData.isAllowed || !vm.isEditable),
						action: vm.leaveForm
					}
				},

				controls: {
					VENDAW08PSEUDNOVOGR08: new fieldControlClass.GroupControl({
						id: 'VENDAW08PSEUDNOVOGR08',
						name: 'NOVOGR08',
						size: 'block',
						label: computed(() => this.Resources.ASSISTANCE20070),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['VENDAW08SALE_DTACOMPA'],
						controlLimits: [
						],
					}, this),
					VENDAW08SALE_DTACOMPA: new fieldControlClass.DateControl({
						modelField: 'ValDtacompa',
						valueChangeEvent: 'fieldChange:sale.dtacompa',
						id: 'VENDAW08SALE_DTACOMPA',
						name: 'DTACOMPA',
						size: 'medium',
						label: computed(() => this.Resources.ASSISTANCE20070),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'VENDAW08PSEUDNOVOGR08',
						format: 'dateTime',
						controlLimits: [
						],
					}, this),
					VENDAWV_PSEUDFASES___: new fieldControlClass.WizardControl({
						id: 'VENDAWV_PSEUDFASES___',
						name: 'FASES',
						size: 'small',
						label: computed(() => this.Resources.PHASE_AREA51284),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controlLimits: [
						],
					}, this),
				},

				model: new FormViewModel(this, {
					callbacks: {
						onUpdate: this.onUpdate,
						setFormKey: this.setFormKey
					}
				}),

				groupFields: readonly([
					'VENDAW08PSEUDNOVOGR08',
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Sale: {
						get ValCodorgan() { return vm.model.ValCodorgan.value },
						set ValCodorgan(value) { vm.model.ValCodorgan.updateValue(value) },
						get ValDtacompa() { return vm.model.ValDtacompa.value },
						set ValDtacompa(value) { vm.model.ValDtacompa.updateValue(value) },
						get ValIdentifi() { return vm.model.ValIdentifi.value },
						set ValIdentifi(value) { vm.model.ValIdentifi.updateValue(value) },
					},
					keys: {
						/** The primary key of the SALE table */
						get sale() { return vm.model.ValCodvenda },
						/** The foreign key to the ORGAN table */
						get organ() { return vm.model.ValCodorgan },
					},
					get extraProperties() { return vm.model.extraProperties },
				},
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// Called before the route that renders this component is confirmed.
			// Does NOT have access to `this` component instance, because
			// it has not been created yet when this guard is called!

			next((vm) => {
				vm.wizardPath = to.params.wizardPath
				if (to.params.wizardMode)
					vm.wizardMode = to.params.wizardMode

				vm.initFormProperties(to)
			})
		},

		beforeRouteLeave(to, _, next)
		{
			if (to.params.isControlled === 'true')
			{
				genericFunctions.setNavigationState(false)
				next()
			}
			else
				this.cancel(next)
		},

		beforeRouteUpdate(to, _, next)
		{
			if (to.params.isControlled === 'true')
				next()
			else
				this.cancel(next)
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_CODEJS VENDAW08]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS VENDAW08]/
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
// USE /[MANUAL GQT FORM_LOADED_JS VENDAW08]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS VENDAW08]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS VENDAW08]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS VENDAW08]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS VENDAW08]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS VENDAW08]/
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
// USE /[MANUAL GQT AFTER_DEL_JS VENDAW08]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS VENDAW08]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS VENDAW08]/
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
// USE /[MANUAL GQT DLGUPDT VENDAW08]/
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
// USE /[MANUAL GQT CTRLBLR VENDAW08]/
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
// USE /[MANUAL GQT CTRLUPD VENDAW08]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS VENDAW08]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
