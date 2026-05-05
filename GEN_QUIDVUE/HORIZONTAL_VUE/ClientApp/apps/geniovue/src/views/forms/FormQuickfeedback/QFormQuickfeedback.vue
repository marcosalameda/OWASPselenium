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
			data-key="QUICKFEEDBACK"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container
					v-show="controls.QUICKFEEDBACK__PSEUD__NEWGRP01.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.QUICKFEEDBACK__PSEUD__NEWGRP01.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<q-group-box-container
							id="QUICKFEEDBACK__PSEUD__NEWGRP01"
							v-bind="controls.QUICKFEEDBACK__PSEUD__NEWGRP01"
							:is-visible="controls.QUICKFEEDBACK__PSEUD__NEWGRP01.isVisible">
							<!-- Start QUICKFEEDBACK__PSEUD__NEWGRP01 -->
							<q-row-container v-show="controls.QUICKFEEDBACK__PSEUD__FIELD004.isVisible">
								<q-control-wrapper
									v-show="controls.QUICKFEEDBACK__PSEUD__FIELD004.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-static-text"
										v-bind="controls.QUICKFEEDBACK__PSEUD__FIELD004"
										v-on="controls.QUICKFEEDBACK__PSEUD__FIELD004.handlers"
										:loading="controls.QUICKFEEDBACK__PSEUD__FIELD004.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-static-text
											v-if="controls.QUICKFEEDBACK__PSEUD__FIELD004.isVisible"
											id="QUICKFEEDBACK__PSEUD__FIELD004"
											:size="controls.QUICKFEEDBACK__PSEUD__FIELD004.size"
											:text="controls.QUICKFEEDBACK__PSEUD__FIELD004.label"
											supports-html />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.QUICKFEEDBACK__PSEUD__FIELD005.isVisible">
								<q-control-wrapper
									v-show="controls.QUICKFEEDBACK__PSEUD__FIELD005.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-static-text"
										v-bind="controls.QUICKFEEDBACK__PSEUD__FIELD005"
										v-on="controls.QUICKFEEDBACK__PSEUD__FIELD005.handlers"
										:loading="controls.QUICKFEEDBACK__PSEUD__FIELD005.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-static-text
											v-if="controls.QUICKFEEDBACK__PSEUD__FIELD005.isVisible"
											id="QUICKFEEDBACK__PSEUD__FIELD005"
											:size="controls.QUICKFEEDBACK__PSEUD__FIELD005.size"
											:text="controls.QUICKFEEDBACK__PSEUD__FIELD005.label" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End QUICKFEEDBACK__PSEUD__NEWGRP01 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.QUICKFEEDBACK__PSEUD__FIELD001.isVisible">
					<q-control-wrapper
						v-show="controls.QUICKFEEDBACK__PSEUD__FIELD001.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-static-text"
							v-bind="controls.QUICKFEEDBACK__PSEUD__FIELD001"
							v-on="controls.QUICKFEEDBACK__PSEUD__FIELD001.handlers"
							:loading="controls.QUICKFEEDBACK__PSEUD__FIELD001.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-static-text
								v-if="controls.QUICKFEEDBACK__PSEUD__FIELD001.isVisible"
								id="QUICKFEEDBACK__PSEUD__FIELD001"
								:size="controls.QUICKFEEDBACK__PSEUD__FIELD001.size"
								:text="controls.QUICKFEEDBACK__PSEUD__FIELD001.label"
								supports-html />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.QUICKFEEDBACK__PSEUD__FIELD002.isVisible">
					<q-control-wrapper
						v-show="controls.QUICKFEEDBACK__PSEUD__FIELD002.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-static-text"
							v-bind="controls.QUICKFEEDBACK__PSEUD__FIELD002"
							v-on="controls.QUICKFEEDBACK__PSEUD__FIELD002.handlers"
							:loading="controls.QUICKFEEDBACK__PSEUD__FIELD002.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-static-text
								v-if="controls.QUICKFEEDBACK__PSEUD__FIELD002.isVisible"
								id="QUICKFEEDBACK__PSEUD__FIELD002"
								:size="controls.QUICKFEEDBACK__PSEUD__FIELD002.size"
								:text="controls.QUICKFEEDBACK__PSEUD__FIELD002.label" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.QUICKFEEDBACK__UFEEDBACK__LOGICALFEEDB.isVisible">
					<q-control-wrapper
						v-show="controls.QUICKFEEDBACK__UFEEDBACK__LOGICALFEEDB.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.QUICKFEEDBACK__UFEEDBACK__LOGICALFEEDB"
							v-on="controls.QUICKFEEDBACK__UFEEDBACK__LOGICALFEEDB.handlers"
							:loading="controls.QUICKFEEDBACK__UFEEDBACK__LOGICALFEEDB.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox-input
									v-if="controls.QUICKFEEDBACK__UFEEDBACK__LOGICALFEEDB.isVisible"
									v-bind="controls.QUICKFEEDBACK__UFEEDBACK__LOGICALFEEDB.props"
									v-on="controls.QUICKFEEDBACK__UFEEDBACK__LOGICALFEEDB.handlers" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.QUICKFEEDBACK__UFEEDBACK__LANGUAGELOGIC.isVisible">
					<q-control-wrapper
						v-show="controls.QUICKFEEDBACK__UFEEDBACK__LANGUAGELOGIC.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.QUICKFEEDBACK__UFEEDBACK__LANGUAGELOGIC"
							v-on="controls.QUICKFEEDBACK__UFEEDBACK__LANGUAGELOGIC.handlers"
							:loading="controls.QUICKFEEDBACK__UFEEDBACK__LANGUAGELOGIC.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox-input
									v-if="controls.QUICKFEEDBACK__UFEEDBACK__LANGUAGELOGIC.isVisible"
									v-bind="controls.QUICKFEEDBACK__UFEEDBACK__LANGUAGELOGIC.props"
									v-on="controls.QUICKFEEDBACK__UFEEDBACK__LANGUAGELOGIC.handlers" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.QUICKFEEDBACK__UFEEDBACK__LOGICFEED.isVisible">
					<q-control-wrapper
						v-show="controls.QUICKFEEDBACK__UFEEDBACK__LOGICFEED.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.QUICKFEEDBACK__UFEEDBACK__LOGICFEED"
							v-on="controls.QUICKFEEDBACK__UFEEDBACK__LOGICFEED.handlers"
							:loading="controls.QUICKFEEDBACK__UFEEDBACK__LOGICFEED.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox-input
									v-if="controls.QUICKFEEDBACK__UFEEDBACK__LOGICFEED.isVisible"
									v-bind="controls.QUICKFEEDBACK__UFEEDBACK__LOGICFEED.props"
									v-on="controls.QUICKFEEDBACK__UFEEDBACK__LOGICFEED.handlers" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.QUICKFEEDBACK__UFEEDBACK__MOREDETLOGIC.isVisible">
					<q-control-wrapper
						v-show="controls.QUICKFEEDBACK__UFEEDBACK__MOREDETLOGIC.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.QUICKFEEDBACK__UFEEDBACK__MOREDETLOGIC"
							v-on="controls.QUICKFEEDBACK__UFEEDBACK__MOREDETLOGIC.handlers"
							:loading="controls.QUICKFEEDBACK__UFEEDBACK__MOREDETLOGIC.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox-input
									v-if="controls.QUICKFEEDBACK__UFEEDBACK__MOREDETLOGIC.isVisible"
									v-bind="controls.QUICKFEEDBACK__UFEEDBACK__MOREDETLOGIC.props"
									v-on="controls.QUICKFEEDBACK__UFEEDBACK__MOREDETLOGIC.handlers" />
							</template>
						</base-input-structure>
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

	import FormViewModel from './QFormQuickfeedbackViewModel.js'

	const requiredTextResources = ['QFormQuickfeedback', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS QUICKFEEDBACK]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormQuickfeedback',

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
					name: 'QUICKFEEDBACK',
					location: 'form-QUICKFEEDBACK',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormQuickfeedback', false),

				interfaceMetadata: {
					id: 'QFormQuickfeedback', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'popup',
					name: 'QUICKFEEDBACK',
					route: 'form-QUICKFEEDBACK',
					area: 'UFEEDBACK',
					primaryKey: 'ValCodufeedback',
					designation: '',
					identifier: '', // Unique identifier received by route (when it's nested).
					mode: ''
				},

				formButtons: {
					field003: {
						id: 'field003-btn',
						text: computed(() => this.Resources.SEND_FEEDBACK27710),
						icon: {
							icon: 'save',
							type: 'svg',
						},
						type: 'custom',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.controls.QUICKFEEDBACK__PSEUD__FIELD003.isVisible),
						disabled: computed(() => vm.controls.QUICKFEEDBACK__PSEUD__FIELD003.isBlocked),
						action: (e) => vm.controls.QUICKFEEDBACK__PSEUD__FIELD003.action(e)
					},
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
					QUICKFEEDBACK__PSEUD__NEWGRP01: new fieldControlClass.GroupControl({
						id: 'QUICKFEEDBACK__PSEUD__NEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['QUICKFEEDBACK__PSEUD__FIELD004', 'QUICKFEEDBACK__PSEUD__FIELD005'],
						controlLimits: [
						],
					}, this),
					QUICKFEEDBACK__PSEUD__FIELD004: new fieldControlClass.BaseControl({
						id: 'QUICKFEEDBACK__PSEUD__FIELD004',
						name: 'FIELD004',
						size: 'xxlarge',
						hasLabel: false,
						label: computed(() => this.Resources._H2__STRONG_THANK_YO41891),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'QUICKFEEDBACK__PSEUD__NEWGRP01',
						supportsHtml: true,
						controlLimits: [
						],
					}, this),
					QUICKFEEDBACK__PSEUD__FIELD005: new fieldControlClass.BaseControl({
						id: 'QUICKFEEDBACK__PSEUD__FIELD005',
						name: 'FIELD005',
						size: 'xxlarge',
						hasLabel: false,
						label: computed(() => this.Resources.YOUR_FEEDBACK_HELPS_35803),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'QUICKFEEDBACK__PSEUD__NEWGRP01',
						controlLimits: [
						],
					}, this),
					QUICKFEEDBACK__PSEUD__FIELD001: new fieldControlClass.BaseControl({
						id: 'QUICKFEEDBACK__PSEUD__FIELD001',
						name: 'FIELD001',
						size: 'xxlarge',
						hasLabel: false,
						label: computed(() => this.Resources._STRONG_PLEASE_TELL_05707),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						supportsHtml: true,
						controlLimits: [
						],
					}, this),
					QUICKFEEDBACK__PSEUD__FIELD002: new fieldControlClass.BaseControl({
						id: 'QUICKFEEDBACK__PSEUD__FIELD002',
						name: 'FIELD002',
						size: 'large',
						hasLabel: false,
						label: computed(() => this.Resources.CHECK_ALL_THAT_APPLY34717),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controlLimits: [
						],
					}, this),
					QUICKFEEDBACK__UFEEDBACK__LOGICALFEEDB: new fieldControlClass.BooleanControl({
						modelField: 'ValLogicalfeedb',
						valueChangeEvent: 'fieldChange:ufeedback.logicalfeedb',
						id: 'QUICKFEEDBACK__UFEEDBACK__LOGICALFEEDB',
						name: 'LOGICALFEEDB',
						size: 'xxlarge',
						label: computed(() => this.Resources.THE_INFORMATION_IS_H08002),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						controlLimits: [
						],
					}, this),
					QUICKFEEDBACK__UFEEDBACK__LANGUAGELOGIC: new fieldControlClass.BooleanControl({
						modelField: 'ValLanguagelogic',
						valueChangeEvent: 'fieldChange:ufeedback.languagelogic',
						id: 'QUICKFEEDBACK__UFEEDBACK__LANGUAGELOGIC',
						name: 'LANGUAGELOGIC',
						size: 'xxlarge',
						label: computed(() => this.Resources.I_D_LIKE_TO_HAVE_MOR23763),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						controlLimits: [
						],
					}, this),
					QUICKFEEDBACK__UFEEDBACK__LOGICFEED: new fieldControlClass.BooleanControl({
						modelField: 'ValLogicfeed',
						valueChangeEvent: 'fieldChange:ufeedback.logicfeed',
						id: 'QUICKFEEDBACK__UFEEDBACK__LOGICFEED',
						name: 'LOGICFEED',
						size: 'xlarge',
						label: computed(() => this.Resources.I_CAN_T_FIND_WHAT_I_33456),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						controlLimits: [
						],
					}, this),
					QUICKFEEDBACK__UFEEDBACK__MOREDETLOGIC: new fieldControlClass.BooleanControl({
						modelField: 'ValMoredetlogic',
						valueChangeEvent: 'fieldChange:ufeedback.moredetlogic',
						id: 'QUICKFEEDBACK__UFEEDBACK__MOREDETLOGIC',
						name: 'MOREDETLOGIC',
						size: 'medium',
						label: computed(() => this.Resources.NEED_MORE_DETAILS27800),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						controlLimits: [
						],
					}, this),
					QUICKFEEDBACK__PSEUD__FIELD003: new fieldControlClass.ButtonControl({
						id: 'QUICKFEEDBACK__PSEUD__FIELD003',
						name: 'FIELD003',
						size: 'medium',
						hasLabel: false,
						label: computed(() => this.Resources.SEND_FEEDBACK27710),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						icon: {
							icon: 'save',
							type: 'svg',
							role: 'presentation',
						},
						// eslint-disable-next-line
						action: (event) => {
							let btnAction = () => {
								vm.Quickfeedback_BT_FIELD003(vm.primaryKeyValue)
							}
							btnAction()
						},
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
					'QUICKFEEDBACK__PSEUD__NEWGRP01',
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
						get ValLanguagelogic() { return vm.model.ValLanguagelogic.value },
						set ValLanguagelogic(value) { vm.model.ValLanguagelogic.updateValue(value) },
						get ValLogicalfeedb() { return vm.model.ValLogicalfeedb.value },
						set ValLogicalfeedb(value) { vm.model.ValLogicalfeedb.updateValue(value) },
						get ValLogicfeed() { return vm.model.ValLogicfeed.value },
						set ValLogicfeed(value) { vm.model.ValLogicfeed.updateValue(value) },
						get ValMoredetlogic() { return vm.model.ValMoredetlogic.value },
						set ValMoredetlogic(value) { vm.model.ValMoredetlogic.updateValue(value) },
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
// USE /[MANUAL GQT FORM_CODEJS QUICKFEEDBACK]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS QUICKFEEDBACK]/
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
// USE /[MANUAL GQT FORM_LOADED_JS QUICKFEEDBACK]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS QUICKFEEDBACK]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS QUICKFEEDBACK]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS QUICKFEEDBACK]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS QUICKFEEDBACK]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS QUICKFEEDBACK]/
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
// USE /[MANUAL GQT AFTER_DEL_JS QUICKFEEDBACK]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS QUICKFEEDBACK]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS QUICKFEEDBACK]/
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
// USE /[MANUAL GQT DLGUPDT QUICKFEEDBACK]/
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
// USE /[MANUAL GQT CTRLBLR QUICKFEEDBACK]/
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
// USE /[MANUAL GQT CTRLUPD QUICKFEEDBACK]/
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
			async Quickfeedback_BT_FIELD003(id)
			{
				// Parallel trigger execution.
				await Promise.all([
					Promise.resolve((async () => {
						await this.Quickfeedback_BT_FIELD003_SENDFEEDBACKBTN_1(id)
					})()),
				])
			},

			/**
			 * Client-side component of action #1 (SAVE) of trigger SENDFEEDBACKBTN.
			 * @param {string} id The primary key of the record
			 */
			// eslint-disable-next-line
			async Quickfeedback_BT_FIELD003_SENDFEEDBACKBTN_1(id)
			{
				await this.saveForm(false)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS QUICKFEEDBACK]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
