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
				v-if="$app.layout.FormAnchorsPosition === 'form-header' && visibleGroups.length > 0"
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
			data-key="USEFULFEEDBACK"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.USEFULFEEDBACK__PSEUD__USEFULTEXT.isVisible || controls.USEFULFEEDBACK__PSEUD__FIELD003.isVisible || controls.USEFULFEEDBACK__PSEUD__FIELD002.isVisible">
					<q-control-wrapper
						v-show="controls.USEFULFEEDBACK__PSEUD__USEFULTEXT.isVisible || controls.USEFULFEEDBACK__PSEUD__FIELD003.isVisible || controls.USEFULFEEDBACK__PSEUD__FIELD002.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-static-text"
							v-bind="controls.USEFULFEEDBACK__PSEUD__USEFULTEXT"
							v-on="controls.USEFULFEEDBACK__PSEUD__USEFULTEXT.handlers"
							:loading="controls.USEFULFEEDBACK__PSEUD__USEFULTEXT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-static-text
								v-if="controls.USEFULFEEDBACK__PSEUD__USEFULTEXT.isVisible"
								id="USEFULFEEDBACK__PSEUD__USEFULTEXT"
								:size="controls.USEFULFEEDBACK__PSEUD__USEFULTEXT.size"
								:text="controls.USEFULFEEDBACK__PSEUD__USEFULTEXT.label"
								supports-html />
						</base-input-structure>
						<base-input-structure
							class="i-button"
							v-bind="controls.USEFULFEEDBACK__PSEUD__FIELD003"
							v-on="controls.USEFULFEEDBACK__PSEUD__FIELD003.handlers"
							:loading="controls.USEFULFEEDBACK__PSEUD__FIELD003.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-button
								v-if="controls.USEFULFEEDBACK__PSEUD__FIELD003.isVisible"
								id="USEFULFEEDBACK__PSEUD__FIELD003"
								:label="controls.USEFULFEEDBACK__PSEUD__FIELD003.label"
								:disabled="controls.USEFULFEEDBACK__PSEUD__FIELD003.isBlocked"
								@click="controls.USEFULFEEDBACK__PSEUD__FIELD003.action($event)">
								<q-icon v-bind="controls.USEFULFEEDBACK__PSEUD__FIELD003.icon" />
							</q-button>
						</base-input-structure>
						<base-input-structure
							class="i-button"
							v-bind="controls.USEFULFEEDBACK__PSEUD__FIELD002"
							v-on="controls.USEFULFEEDBACK__PSEUD__FIELD002.handlers"
							:loading="controls.USEFULFEEDBACK__PSEUD__FIELD002.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-button
								v-if="controls.USEFULFEEDBACK__PSEUD__FIELD002.isVisible"
								id="USEFULFEEDBACK__PSEUD__FIELD002"
								:label="controls.USEFULFEEDBACK__PSEUD__FIELD002.label"
								:disabled="controls.USEFULFEEDBACK__PSEUD__FIELD002.isBlocked"
								@click="controls.USEFULFEEDBACK__PSEUD__FIELD002.action($event)">
								<q-icon v-bind="controls.USEFULFEEDBACK__PSEUD__FIELD002.icon" />
							</q-button>
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.USEFULFEEDBACK__PSEUD__FIELD001.isVisible">
					<q-control-wrapper
						v-show="controls.USEFULFEEDBACK__PSEUD__FIELD001.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-static-text"
							v-bind="controls.USEFULFEEDBACK__PSEUD__FIELD001"
							v-on="controls.USEFULFEEDBACK__PSEUD__FIELD001.handlers"
							:loading="controls.USEFULFEEDBACK__PSEUD__FIELD001.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-static-text
								v-if="controls.USEFULFEEDBACK__PSEUD__FIELD001.isVisible"
								id="USEFULFEEDBACK__PSEUD__FIELD001"
								:size="controls.USEFULFEEDBACK__PSEUD__FIELD001.size"
								:text="controls.USEFULFEEDBACK__PSEUD__FIELD001.label" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.USEFULFEEDBACK__PSEUD__NEWGRP01.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.USEFULFEEDBACK__PSEUD__NEWGRP01.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<q-group-box-container
							id="USEFULFEEDBACK__PSEUD__NEWGRP01"
							v-bind="controls.USEFULFEEDBACK__PSEUD__NEWGRP01"
							:is-visible="controls.USEFULFEEDBACK__PSEUD__NEWGRP01.isVisible">
							<!-- Start USEFULFEEDBACK__PSEUD__NEWGRP01 -->
							<q-row-container v-show="controls.USEFULFEEDBACK__UFEEDBACK__USEFULFEEDB.isVisible">
								<q-control-wrapper
									v-show="controls.USEFULFEEDBACK__UFEEDBACK__USEFULFEEDB.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-radio-container"
										v-bind="controls.USEFULFEEDBACK__UFEEDBACK__USEFULFEEDB"
										v-on="controls.USEFULFEEDBACK__UFEEDBACK__USEFULFEEDB.handlers"
										:label-position="labelAlignment.topleft"
										:loading="controls.USEFULFEEDBACK__UFEEDBACK__USEFULFEEDB.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-radio-group
											v-if="controls.USEFULFEEDBACK__UFEEDBACK__USEFULFEEDB.isVisible"
											id="USEFULFEEDBACK__UFEEDBACK__USEFULFEEDB"
											:model-value="model.ValUsefulfeedb.value"
											deselect-radio
											:label-left-side="controls.USEFULFEEDBACK__UFEEDBACK__USEFULFEEDB.labelPosition === labelAlignment.left"
											:number-of-columns="controls.USEFULFEEDBACK__UFEEDBACK__USEFULFEEDB.columnNumber"
											:is-required="controls.USEFULFEEDBACK__UFEEDBACK__USEFULFEEDB.isRequired"
											:readonly="controls.USEFULFEEDBACK__UFEEDBACK__USEFULFEEDB.readonly"
											:options-list="controls.USEFULFEEDBACK__UFEEDBACK__USEFULFEEDB.items"
											@update:model-value="model.ValUsefulfeedb.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.USEFULFEEDBACK__UFEEDBACK__SFEEDBACK.isVisible">
								<q-control-wrapper
									v-show="controls.USEFULFEEDBACK__UFEEDBACK__SFEEDBACK.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-text"
										v-bind="controls.USEFULFEEDBACK__UFEEDBACK__SFEEDBACK"
										v-on="controls.USEFULFEEDBACK__UFEEDBACK__SFEEDBACK.handlers"
										:loading="controls.USEFULFEEDBACK__UFEEDBACK__SFEEDBACK.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.USEFULFEEDBACK__UFEEDBACK__SFEEDBACK.isVisible"
											v-bind="controls.USEFULFEEDBACK__UFEEDBACK__SFEEDBACK.props"
											@update:model-value="model.ValSfeedback.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.USEFULFEEDBACK__UFEEDBACK__FEEDBCOMENT.isVisible">
								<q-control-wrapper
									v-show="controls.USEFULFEEDBACK__UFEEDBACK__FEEDBCOMENT.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-textarea"
										v-bind="controls.USEFULFEEDBACK__UFEEDBACK__FEEDBCOMENT"
										v-on="controls.USEFULFEEDBACK__UFEEDBACK__FEEDBCOMENT.handlers"
										:loading="controls.USEFULFEEDBACK__UFEEDBACK__FEEDBCOMENT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-area
											v-if="controls.USEFULFEEDBACK__UFEEDBACK__FEEDBCOMENT.isVisible"
											v-bind="controls.USEFULFEEDBACK__UFEEDBACK__FEEDBCOMENT.props"
											v-on="controls.USEFULFEEDBACK__UFEEDBACK__FEEDBCOMENT.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End USEFULFEEDBACK__PSEUD__NEWGRP01 -->
						</q-group-box-container>
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

	import FormHandlers from '@/mixins/formHandlers.js'
	import formFunctions from '@/mixins/formFunctions.js'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import listFunctions from '@/mixins/listFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'
	import modelFieldType from '@quidgest/clientapp/models/fields'
	import fieldControlClass from '@/mixins/fieldControl.js'
	import qEnums from '@quidgest/clientapp/constants/enums'
	import { resetProgressBar, setProgressBar } from '@/utils/layout.js'

	import hardcodedTexts from '@/hardcodedTexts.js'
	import netAPI from '@quidgest/clientapp/network'
	import asyncProcM from '@quidgest/clientapp/composables/async'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	/* eslint-enable no-unused-vars */

	import FormViewModel from './QFormUsefulfeedbackViewModel.js'

	const requiredTextResources = ['QFormUsefulfeedback', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS USEFULFEEDBACK]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormUsefulfeedback',

		components: {
		},

		mixins: [
			FormHandlers
		],

		props: {
			/**
			 * Parameters passed in case the form is nested.
			 */
			nestedRouteParams: {
				type: Object,
				default: () => ({
					name: 'USEFULFEEDBACK',
					location: 'form-USEFULFEEDBACK',
					params: {
						isNested: true
					}
				})
			}
		},

		expose: [
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormUsefulfeedback', false),

				interfaceMetadata: {
					id: 'QFormUsefulfeedback', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'popup',
					name: 'USEFULFEEDBACK',
					route: 'form-USEFULFEEDBACK',
					area: 'UFEEDBACK',
					primaryKey: 'ValCodufeedback',
					designation: '',
					identifier: '', // Unique identifier received by route (when it's nested).
					mode: ''
				},

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
						isVisible: computed(() => vm.authData.isAllowed && vm.formInfo.mode === vm.formModes.new),
						action: () => vm.saveForm(true)
					},
					saveBtn: {
						id: 'save-btn',
						icon: {
							icon: 'save',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources.GRAVAR45301),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
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
						text: computed(() => vm.Resources.CANCELAR49513),
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
					USEFULFEEDBACK__PSEUD__USEFULTEXT: new fieldControlClass.BaseControl({
						id: 'USEFULFEEDBACK__PSEUD__USEFULTEXT',
						name: 'USEFULTEXT',
						size: 'xxlarge',
						hasLabel: false,
						label: computed(() => this.Resources._H2__STRONG_WAS_THE_36938),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						supportsHtml: true,
						controlLimits: [
						],
					}, this),
					USEFULFEEDBACK__PSEUD__FIELD003: new fieldControlClass.ButtonControl({
						id: 'USEFULFEEDBACK__PSEUD__FIELD003',
						name: 'FIELD003',
						size: 'mini',
						hasLabel: false,
						label: computed(() => this.Resources.YES34196),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						icon: {
							icon: computed(() => `${this.$app.resourcesPath}thumbs-up-svgrepo-com (1).svg?v=3637`),
							type: 'img',
							role: 'presentation',
						},
						// eslint-disable-next-line
						action: (event) => {
							let btnAction = () => {
								vm.Usefulfeedback_BT_FIELD003(vm.primaryKeyValue)
							}
							btnAction()
						},
						controlLimits: [
						],
					}, this),
					USEFULFEEDBACK__PSEUD__FIELD002: new fieldControlClass.ButtonControl({
						id: 'USEFULFEEDBACK__PSEUD__FIELD002',
						name: 'FIELD002',
						size: 'mini',
						hasLabel: false,
						label: computed(() => this.Resources.NO57340),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						icon: {
							icon: computed(() => `${this.$app.resourcesPath}thumbs-down.png?v=3637`),
							type: 'img',
							role: 'presentation',
						},
						// eslint-disable-next-line
						action: (event) => {
							let btnAction = () => {
								vm.Usefulfeedback_BT_FIELD002(vm.primaryKeyValue)
							}
							btnAction()
						},
						controlLimits: [
						],
					}, this),
					USEFULFEEDBACK__PSEUD__FIELD001: new fieldControlClass.BaseControl({
						id: 'USEFULFEEDBACK__PSEUD__FIELD001',
						name: 'FIELD001',
						size: 'xxlarge',
						hasLabel: false,
						label: computed(() => this.Resources.EVALUATE_YOUR_EXPERI04632),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controlLimits: [
						],
					}, this),
					USEFULFEEDBACK__PSEUD__NEWGRP01: new fieldControlClass.GroupControl({
						id: 'USEFULFEEDBACK__PSEUD__NEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['USEFULFEEDBACK__UFEEDBACK__USEFULFEEDB', 'USEFULFEEDBACK__UFEEDBACK__SFEEDBACK', 'USEFULFEEDBACK__UFEEDBACK__FEEDBCOMENT'],
						controlLimits: [
						],
					}, this),
					USEFULFEEDBACK__UFEEDBACK__USEFULFEEDB: new fieldControlClass.ArrayNumberControl({
						modelField: 'ValUsefulfeedb',
						valueChangeEvent: 'fieldChange:ufeedback.usefulfeedb',
						id: 'USEFULFEEDBACK__UFEEDBACK__USEFULFEEDB',
						name: 'USEFULFEEDB',
						size: 'xxlarge',
						label: computed(() => this.Resources.DID_YOU_FIND_WHAT_YO32710),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'USEFULFEEDBACK__PSEUD__NEWGRP01',
						maxIntegers: 1,
						maxDecimals: 0,
						arrayName: 'usefulfeedb',
						columnNumber: 1,
						controlLimits: [
						],
					}, this),
					USEFULFEEDBACK__UFEEDBACK__SFEEDBACK: new fieldControlClass.FieldSpecialRenderingControl({
						modelField: 'ValSfeedback',
						valueChangeEvent: 'fieldChange:ufeedback.sfeedback',
						id: 'USEFULFEEDBACK__UFEEDBACK__SFEEDBACK',
						name: 'SFEEDBACK',
						size: 'mini',
						label: computed(() => this.Resources.CLASSIFY_YOUR_EXPERI03701),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'USEFULFEEDBACK__PSEUD__NEWGRP01',
						maxIntegers: 1,
						maxDecimals: 0,
						viewModes: [
							{
								id: 'RATING',
								type: 'rating',
								subtype: '',
								label: computed(() => this.Resources.AVALIACAO18442),
								order: 1,
								implicitVariable: 'rating',
								implicitIsMultiple: true,
								mappingVariables: readonly({
								}),
								styleVariables: {
									maxRating: {
										rawValue: 5,
										isMapped: false
									},
									increment: {
										rawValue: 1,
										isMapped: false
									},
									shapeSize: {
										rawValue: 40,
										isMapped: false
									},
									activeColor: {
										rawValue: '$primary',
										isMapped: false
									},
									inactiveColor: {
										rawValue: '$gray-light',
										isMapped: false
									},
									showRating: {
										rawValue: true,
										isMapped: false
									},
									padding: {
										rawValue: 0,
										isMapped: false
									},
								},
								groups: {
								}
							},
						],
						arrayName: 'feedback',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					USEFULFEEDBACK__UFEEDBACK__FEEDBCOMENT: new fieldControlClass.MultilineStringControl({
						modelField: 'ValFeedbcoment',
						valueChangeEvent: 'fieldChange:ufeedback.feedbcoment',
						id: 'USEFULFEEDBACK__UFEEDBACK__FEEDBCOMENT',
						name: 'FEEDBCOMENT',
						size: 'xxlarge',
						label: computed(() => this.Resources.COMMENTS30895),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'USEFULFEEDBACK__PSEUD__NEWGRP01',
						rows: 3,
						cols: 80,
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
					'USEFULFEEDBACK__PSEUD__NEWGRP01',
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Ufeedback: {
						get ValCodfeedbacktype() { return vm.model.ValCodfeedbacktype.value },
						set ValCodfeedbacktype(value) { vm.model.ValCodfeedbacktype.updateValue(value) },
						get ValFeedbcoment() { return vm.model.ValFeedbcoment.value },
						set ValFeedbcoment(value) { vm.model.ValFeedbcoment.updateValue(value) },
						get ValSfeedback() { return vm.model.ValSfeedback.value },
						set ValSfeedback(value) { vm.model.ValSfeedback.updateValue(value) },
						get ValUsefulfeedb() { return vm.model.ValUsefulfeedb.value },
						set ValUsefulfeedb(value) { vm.model.ValUsefulfeedb.updateValue(value) },
					},
					keys: {
						/** The primary key of the UFEEDBACK table */
						get ufeedback() { return vm.model.ValCodufeedback },
						/** The foreign key to the FEEDBACKTYPE table */
						get feedbacktype() { return vm.model.ValCodfeedbacktype },
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

			to.params.isPopup = 'true'

			next((vm) => {
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
// USE /[MANUAL GQT FORM_CODEJS USEFULFEEDBACK]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS USEFULFEEDBACK]/
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
// USE /[MANUAL GQT FORM_LOADED_JS USEFULFEEDBACK]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS USEFULFEEDBACK]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS USEFULFEEDBACK]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS USEFULFEEDBACK]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS USEFULFEEDBACK]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS USEFULFEEDBACK]/
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
// USE /[MANUAL GQT AFTER_DEL_JS USEFULFEEDBACK]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS USEFULFEEDBACK]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS USEFULFEEDBACK]/
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
// USE /[MANUAL GQT DLGUPDT USEFULFEEDBACK]/
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
// USE /[MANUAL GQT CTRLBLR USEFULFEEDBACK]/
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
// USE /[MANUAL GQT CTRLUPD USEFULFEEDBACK]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},

			/**
			 * Execute the triggers of the trigger button FIELD003.
			 * Event triggered by a click on the trigger button FIELD003.
			 * @param {string} id The primary key of the record
			 */
			// eslint-disable-next-line
			async Usefulfeedback_BT_FIELD003(id)
			{
				// Parallel trigger execution.
				await Promise.all([
				])
			},

			/**
			 * Execute the triggers of the trigger button FIELD002.
			 * Event triggered by a click on the trigger button FIELD002.
			 * @param {string} id The primary key of the record
			 */
			// eslint-disable-next-line
			async Usefulfeedback_BT_FIELD002(id)
			{
				// Parallel trigger execution.
				await Promise.all([
				])
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS USEFULFEEDBACK]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
