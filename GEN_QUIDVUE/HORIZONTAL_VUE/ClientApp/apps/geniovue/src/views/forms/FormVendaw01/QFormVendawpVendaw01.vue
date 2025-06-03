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
					:id="formTitleId"
					class="form-header">
					{{ formInfo.designation }}
				</h1>

				<div class="c-action-bar__menu">
					<template
						v-for="(section, sectionId) in formButtonSections"
						:key="sectionId">
						<span
							v-if="showHeadingSep(sectionId)"
							class="main-title-sep" />

						<q-toggle-group
							v-if="formControl.uiComponents.headerButtons"
							borderless>
							<template
								v-for="btn in section"
								:key="btn.id">
								<q-toggle-group-item
									v-if="showFormHeaderButton(btn)"
									:model-value="btn.isSelected"
									:id="`top-${btn.id}`"
									:title="btn.text"
									:label="btn.label"
									:disabled="btn.disabled"
									@click="btn.action">
									<q-icon
										v-if="btn.icon"
										v-bind="btn.icon" />
								</q-toggle-group-item>
							</template>
						</q-toggle-group>
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

		<div :class="[`float-${actionsPlacement}`, 'c-action-bar']">
			<q-button-group borderless>
				<template
					v-for="btn in formButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isActive && btn.isVisible && btn.showInHeading"
						:id="`heading-${btn.id}`"
						:label="btn.text"
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
						:class="btn.classes"
						@click="btn.action(); btn.emitAction ? $emit(btn.emitAction.name, btn.emitAction.params) : null">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</q-button-group>
		</div>

		<div
			class="form-flow"
			data-key="VENDAW01"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.VENDAWP_PSEUDFASES___.isVisible">
					<q-control-wrapper
						v-show="controls.VENDAWP_PSEUDFASES___.isVisible"
						class="control-join-group">
						<q-wizard
							id="VENDAWP_PSEUDFASES___"
							:is-required="controls.VENDAWP_PSEUDFASES___.isRequired"
							v-bind="controls.VENDAWP_PSEUDFASES___.wizardData"
							v-on="controls.VENDAWP_PSEUDFASES___.handlers">
							<!-- Start VENDAWP_PSEUDFASES___ -->
							<q-row-container v-show="controls.VENDAW01ORGANORGANIZA.isVisible">
								<q-control-wrapper
									v-show="controls.VENDAW01ORGANORGANIZA.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.VENDAW01ORGANORGANIZA"
										v-on="controls.VENDAW01ORGANORGANIZA.handlers"
										:loading="controls.VENDAW01ORGANORGANIZA.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.VENDAW01ORGANORGANIZA.isVisible"
											v-bind="controls.VENDAW01ORGANORGANIZA.props"
											v-on="controls.VENDAW01ORGANORGANIZA.handlers" />
										<q-see-more-vendaw01organorganiza
											v-if="controls.VENDAW01ORGANORGANIZA.seeMoreIsVisible"
											v-bind="controls.VENDAW01ORGANORGANIZA.seeMoreParams"
											v-on="controls.VENDAW01ORGANORGANIZA.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container
								v-show="controls.VENDAW01PSEUDNOVOGR01.isVisible"
								is-large>
								<q-control-wrapper
									v-show="controls.VENDAW01PSEUDNOVOGR01.isVisible"
									class="row-line-group">
									<q-group-box-container
										id="VENDAW01PSEUDNOVOGR01"
										v-bind="controls.VENDAW01PSEUDNOVOGR01"
										:is-visible="controls.VENDAW01PSEUDNOVOGR01.isVisible">
										<!-- Start VENDAW01PSEUDNOVOGR01 -->
										<q-row-container v-show="controls.VENDAW01SALE_IDENTIFI.isVisible">
											<q-control-wrapper
												v-show="controls.VENDAW01SALE_IDENTIFI.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.VENDAW01SALE_IDENTIFI"
													v-on="controls.VENDAW01SALE_IDENTIFI.handlers"
													:loading="controls.VENDAW01SALE_IDENTIFI.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-field
														v-bind="controls.VENDAW01SALE_IDENTIFI.props"
														@blur="onBlur(controls.VENDAW01SALE_IDENTIFI, model.ValIdentifi.value)"
														@change="model.ValIdentifi.fnUpdateValueOnChange" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.VENDAW01SALE_POTCOMPR.isVisible || controls.VENDAW01SALE_PROSPECC.isVisible">
											<q-control-wrapper
												v-show="controls.VENDAW01SALE_POTCOMPR.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.VENDAW01SALE_POTCOMPR"
													v-on="controls.VENDAW01SALE_POTCOMPR.handlers"
													:loading="controls.VENDAW01SALE_POTCOMPR.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-field
														v-bind="controls.VENDAW01SALE_POTCOMPR.props"
														@blur="onBlur(controls.VENDAW01SALE_POTCOMPR, model.ValPotcompr.value)"
														@change="model.ValPotcompr.fnUpdateValueOnChange" />
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.VENDAW01SALE_PROSPECC.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-checkbox"
													v-bind="controls.VENDAW01SALE_PROSPECC"
													v-on="controls.VENDAW01SALE_PROSPECC.handlers"
													:loading="controls.VENDAW01SALE_PROSPECC.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<template #label>
														<q-checkbox-input
															v-if="controls.VENDAW01SALE_PROSPECC.isVisible"
															v-bind="controls.VENDAW01SALE_PROSPECC.props"
															v-on="controls.VENDAW01SALE_PROSPECC.handlers" />
													</template>
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<!-- End VENDAW01PSEUDNOVOGR01 -->
									</q-group-box-container>
								</q-control-wrapper>
							</q-row-container>
							<!-- End VENDAWP_PSEUDFASES___ -->
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
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
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
	import { computed, defineAsyncComponent, readonly } from 'vue'
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

	import FormViewModel from './QFormVendawpVendaw01ViewModel.js'

	const requiredTextResources = ['QFormVendawpVendaw01', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS VENDAW01]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormVendawpVendaw01',

		components: {
			QSeeMoreVendaw01organorganiza: defineAsyncComponent(() => import('@/views/forms/FormVendaw01/dbedits/Vendaw01organorganizaSeeMore.vue')),
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
					name: 'VENDAW01',
					location: 'form-VENDAWP-VENDAW01',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormVendawpVendaw01', false),

				interfaceMetadata: {
					id: 'QFormVendawpVendaw01', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'wizard',
					name: 'VENDAW01',
					route: 'form-VENDAWP-VENDAW01',
					area: 'SALE',
					primaryKey: 'ValCodvenda',
					designation: computed(() => this.Resources.PROSPECCAO46919),
					identifier: '', // Unique identifier received by route (when it's nested).
					mode: ''
				},

				wizardData: readonly({
					type: qEnums.wizardTypes.progress,
					wizardId: 'Vendawp_Fases',
					title: computed(() => this.Resources.PHASE_AREA51284),
					showTitle: false,
					disallowEdit: false,
					stepList: [
						{
							order: 1,
							title: computed(() => this.Resources.PROSPERACAO26522),
							caption: computed(() => this.Resources.PHASE_CAPTION_PLACEH06557),
							route: 'form-VENDAWP-VENDAW01',
							isRequired: false,
						},
						{
							order: 2,
							title: computed(() => this.Resources.QUALIFICACAO07026),
							caption: computed(() => this.Resources.PHASE_CAPTION_PLACEH06557),
							route: 'form-VENDAWP-VENDAW02',
							isRequired: false,
						},
						{
							order: 3,
							title: computed(() => this.Resources.PRE_ABORDAGEM30870),
							caption: computed(() => this.Resources.PHASE_CAPTION_PLACEH06557),
							route: 'form-VENDAWP-VENDAW03',
							isRequired: false,
						},
						{
							order: 4,
							title: computed(() => this.Resources.ABORDAGEM05839),
							caption: computed(() => this.Resources.PHASE_CAPTION_PLACEH06557),
							route: 'form-VENDAWP-VENDAW04',
							isRequired: false,
						},
						{
							order: 5,
							title: computed(() => this.Resources.APRESENTACAO15975),
							caption: computed(() => this.Resources.PHASE_CAPTION_PLACEH06557),
							route: 'form-VENDAWP-VENDAW05',
							isRequired: false,
						},
						{
							order: 6,
							title: computed(() => this.Resources.SUPERAR_OBJECOES40220),
							caption: computed(() => this.Resources.PHASE_CAPTION_PLACEH06557),
							route: 'form-VENDAWP-VENDAW06',
							isRequired: false,
						},
						{
							order: 7,
							title: computed(() => this.Resources.FECHO_DE_VENDA55198),
							caption: computed(() => this.Resources.PHASE_CAPTION_PLACEH06557),
							route: 'form-VENDAWP-VENDAW07',
							isRequired: false,
						},
						{
							order: 8,
							title: computed(() => this.Resources.ACOMPANHAMENTO53507),
							caption: computed(() => this.Resources.PHASE_CAPTION_PLACEH06557),
							route: 'form-VENDAWP-VENDAW08',
							isRequired: false,
						}
					],
					stepData: {
						order: 1,
						id: 'wizard-step-FASES-1',
						saveIsOff: false,
						applyIsOff: false,
						isFinal: false,
						backwardIsOff: false,
						applyOnBackward: true,
						clearOnBackward: false
					},
					stepFieldIds: [
						'VENDAW01ORGANORGANIZA',
						'VENDAW01PSEUDNOVOGR01',
						'VENDAW01SALE_IDENTIFI',
						'VENDAW01SALE_POTCOMPR',
						'VENDAW01SALE_PROSPECC',
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
						variant: 'bold',
						classes: ['wiz-action', 'forward'],
						iconPos: 'end',
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
						variant: 'bold',
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
						variant: 'bold',
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
						variant: 'bold',
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
						variant: 'bold',
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
						variant: 'bold',
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
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => !vm.authData.isAllowed || !vm.isEditable),
						action: vm.leaveForm
					}
				},

				controls: {
					VENDAW01ORGANORGANIZA: new fieldControlClass.LookupControl({
						modelField: 'TableOrganOrganiza',
						valueChangeEvent: 'fieldChange:organ.organiza',
						id: 'VENDAW01ORGANORGANIZA',
						name: 'ORGANIZA',
						size: 'large',
						label: computed(() => this.Resources.ORGANIZATION64123),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodorgan',
							dependencyEvent: 'fieldChange:sale.codorgan'
						},
						dependentFields: () => ({
							set 'organ.codorgan'(value) { vm.model.ValCodorgan.updateValue(value) },
							set 'organ.organiza'(value) { vm.model.TableOrganOrganiza.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					VENDAW01PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'VENDAW01PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						label: computed(() => this.Resources.PROSPECTING26583),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['VENDAW01SALE_IDENTIFI', 'VENDAW01SALE_POTCOMPR', 'VENDAW01SALE_PROSPECC'],
						controlLimits: [
						],
					}, this),
					VENDAW01SALE_IDENTIFI: new fieldControlClass.StringControl({
						modelField: 'ValIdentifi',
						valueChangeEvent: 'fieldChange:sale.identifi',
						id: 'VENDAW01SALE_IDENTIFI',
						name: 'IDENTIFI',
						size: 'xxlarge',
						label: computed(() => this.Resources.IDENTIFICATION_OF_BU58085),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'VENDAW01PSEUDNOVOGR01',
						maxLength: 85,
						labelId: 'label_VENDAW01SALE_IDENTIFI',
						controlLimits: [
						],
					}, this),
					VENDAW01SALE_POTCOMPR: new fieldControlClass.StringControl({
						modelField: 'ValPotcompr',
						valueChangeEvent: 'fieldChange:sale.potcompr',
						id: 'VENDAW01SALE_POTCOMPR',
						name: 'POTCOMPR',
						size: 'xlarge',
						label: computed(() => this.Resources.POTENTIAL_BUYERS44829),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'VENDAW01PSEUDNOVOGR01',
						maxLength: 50,
						labelId: 'label_VENDAW01SALE_POTCOMPR',
						controlLimits: [
						],
					}, this),
					VENDAW01SALE_PROSPECC: new fieldControlClass.BooleanControl({
						modelField: 'ValProspecc',
						valueChangeEvent: 'fieldChange:sale.prospecc',
						id: 'VENDAW01SALE_PROSPECC',
						name: 'PROSPECC',
						size: 'medium',
						label: computed(() => this.Resources.PROSPECTING_CARRIED_08979),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'VENDAW01PSEUDNOVOGR01',
						controlLimits: [
						],
					}, this),
					VENDAWP_PSEUDFASES___: new fieldControlClass.WizardControl({
						id: 'VENDAWP_PSEUDFASES___',
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
					'VENDAW01PSEUDNOVOGR01',
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Organ: {
						get ValOrganiza() { return vm.model.TableOrganOrganiza.value },
						set ValOrganiza(value) { vm.model.TableOrganOrganiza.updateValue(value) },
					},
					Sale: {
						get ValCodorgan() { return vm.model.ValCodorgan.value },
						set ValCodorgan(value) { vm.model.ValCodorgan.updateValue(value) },
						get ValIdentifi() { return vm.model.ValIdentifi.value },
						set ValIdentifi(value) { vm.model.ValIdentifi.updateValue(value) },
						get ValPotcompr() { return vm.model.ValPotcompr.value },
						set ValPotcompr(value) { vm.model.ValPotcompr.updateValue(value) },
						get ValProspecc() { return vm.model.ValProspecc.value },
						set ValProspecc(value) { vm.model.ValProspecc.updateValue(value) },
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
// USE /[MANUAL GQT FORM_CODEJS VENDAW01]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS VENDAW01]/
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
// USE /[MANUAL GQT FORM_LOADED_JS VENDAW01]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS VENDAW01]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS VENDAW01]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS VENDAW01]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS VENDAW01]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS VENDAW01]/
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
// USE /[MANUAL GQT AFTER_DEL_JS VENDAW01]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS VENDAW01]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS VENDAW01]/
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
// USE /[MANUAL GQT DLGUPDT VENDAW01]/
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
// USE /[MANUAL GQT CTRLBLR VENDAW01]/
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
// USE /[MANUAL GQT CTRLUPD VENDAW01]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS VENDAW01]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
