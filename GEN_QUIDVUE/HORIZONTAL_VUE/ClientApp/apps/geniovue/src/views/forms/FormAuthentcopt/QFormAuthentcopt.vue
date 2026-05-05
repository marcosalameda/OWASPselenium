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
			data-key="AUTHENTCOPT"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVARIABLET.isVisible || controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVARNAME.isVisible">
					<q-control-wrapper
						v-show="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVARIABLET.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-text"
							v-bind="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVARIABLET"
							v-on="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVARIABLET.handlers"
							:loading="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVARIABLET.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVARIABLET.props"
								@blur="onBlur(controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVARIABLET, model.ValAuthvariablet.value)"
								@change="model.ValAuthvariablet.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVARNAME.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-text"
							v-bind="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVARNAME"
							v-on="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVARNAME.handlers"
							:loading="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVARNAME.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVARNAME.props"
								@blur="onBlur(controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVARNAME, model.ValAuthvarname.value)"
								@change="model.ValAuthvarname.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHOPTIONS.isVisible || controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHMVC.isVisible || controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVUE.isVisible">
					<q-control-wrapper
						v-show="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHOPTIONS.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-text"
							v-bind="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHOPTIONS"
							v-on="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHOPTIONS.handlers"
							:loading="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHOPTIONS.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-select
								v-if="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHOPTIONS.isVisible"
								v-bind="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHOPTIONS.props"
								@update:model-value="model.ValAuthoptions.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHMVC.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHMVC"
							v-on="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHMVC.handlers"
							:loading="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHMVC.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox-input
									v-if="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHMVC.isVisible"
									v-bind="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHMVC.props"
									v-on="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHMVC.handlers" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVUE.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVUE"
							v-on="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVUE.handlers"
							:loading="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVUE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox-input
									v-if="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVUE.isVisible"
									v-bind="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVUE.props"
									v-on="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHVUE.handlers" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHNOTES.isVisible">
					<q-control-wrapper
						v-show="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHNOTES.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-textarea"
							v-bind="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHNOTES"
							v-on="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHNOTES.handlers"
							:loading="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHNOTES.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-area
								v-if="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHNOTES.isVisible"
								v-bind="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHNOTES.props"
								v-on="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHNOTES.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHPREVIEW.isVisible">
					<q-control-wrapper
						v-show="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHPREVIEW.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="q-image"
							v-bind="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHPREVIEW"
							v-on="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHPREVIEW.handlers"
							:loading="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHPREVIEW.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-image
								v-if="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHPREVIEW.isVisible"
								v-bind="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHPREVIEW.props"
								v-on="controls.AUTHENTCOPT__AUTHENTICATOPT__AUTHPREVIEW.handlers" />
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

	import FormViewModel from './QFormAuthentcoptViewModel.js'

	const requiredTextResources = ['QFormAuthentcopt', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS AUTHENTCOPT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormAuthentcopt',

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
					name: 'AUTHENTCOPT',
					location: 'form-AUTHENTCOPT',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormAuthentcopt', false),

				interfaceMetadata: {
					id: 'QFormAuthentcopt', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'AUTHENTCOPT',
					route: 'form-AUTHENTCOPT',
					area: 'AUTHENTICATOPT',
					primaryKey: 'ValCodauthenticatopt',
					designation: computed(() => genericFunctions.formatString(this.Resources.AUTHENTICATION__AUTH56640, vm.model.ValAuthoptions.displayValue)),
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
					AUTHENTCOPT__AUTHENTICATOPT__AUTHVARIABLET: new fieldControlClass.StringControl({
						modelField: 'ValAuthvariablet',
						valueChangeEvent: 'fieldChange:authenticatopt.authvariablet',
						id: 'AUTHENTCOPT__AUTHENTICATOPT__AUTHVARIABLET',
						name: 'AUTHVARIABLET',
						size: 'large',
						label: computed(() => this.Resources.VARIABLE_TYPE39289),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_AUTHENTCOPT__AUTHENTICATOPT__AUTHVARIABLET',
						controlLimits: [
						],
					}, this),
					AUTHENTCOPT__AUTHENTICATOPT__AUTHVARNAME: new fieldControlClass.StringControl({
						modelField: 'ValAuthvarname',
						valueChangeEvent: 'fieldChange:authenticatopt.authvarname',
						id: 'AUTHENTCOPT__AUTHENTICATOPT__AUTHVARNAME',
						name: 'AUTHVARNAME',
						size: 'large',
						label: computed(() => this.Resources.VARIABLE_NAME27631),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_AUTHENTCOPT__AUTHENTICATOPT__AUTHVARNAME',
						controlLimits: [
						],
					}, this),
					AUTHENTCOPT__AUTHENTICATOPT__AUTHOPTIONS: new fieldControlClass.ArrayStringControl({
						modelField: 'ValAuthoptions',
						valueChangeEvent: 'fieldChange:authenticatopt.authoptions',
						id: 'AUTHENTCOPT__AUTHENTICATOPT__AUTHOPTIONS',
						name: 'AUTHOPTIONS',
						size: 'large',
						label: computed(() => this.Resources.OPTION19344),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 1,
						labelId: 'label_AUTHENTCOPT__AUTHENTICATOPT__AUTHOPTIONS',
						arrayName: 'authentication_options',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					AUTHENTCOPT__AUTHENTICATOPT__AUTHMVC: new fieldControlClass.BooleanControl({
						modelField: 'ValAuthmvc',
						valueChangeEvent: 'fieldChange:authenticatopt.authmvc',
						id: 'AUTHENTCOPT__AUTHENTICATOPT__AUTHMVC',
						name: 'AUTHMVC',
						size: 'mini',
						label: computed(() => this.Resources.MVC48022),
						placeholder: '',
						labelPosition: computed(() => this.$app.layout.CheckboxLabelAlignment),
						controlLimits: [
						],
					}, this),
					AUTHENTCOPT__AUTHENTICATOPT__AUTHVUE: new fieldControlClass.BooleanControl({
						modelField: 'ValAuthvue',
						valueChangeEvent: 'fieldChange:authenticatopt.authvue',
						id: 'AUTHENTCOPT__AUTHENTICATOPT__AUTHVUE',
						name: 'AUTHVUE',
						size: 'mini',
						label: computed(() => this.Resources.VUE05393),
						placeholder: '',
						labelPosition: computed(() => this.$app.layout.CheckboxLabelAlignment),
						controlLimits: [
						],
					}, this),
					AUTHENTCOPT__AUTHENTICATOPT__AUTHNOTES: new fieldControlClass.MultilineStringControl({
						modelField: 'ValAuthnotes',
						valueChangeEvent: 'fieldChange:authenticatopt.authnotes',
						id: 'AUTHENTCOPT__AUTHENTICATOPT__AUTHNOTES',
						name: 'AUTHNOTES',
						size: 'xxlarge',
						label: computed(() => this.Resources.NOTES05274),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						rows: 3,
						cols: 100,
						controlLimits: [
						],
					}, this),
					AUTHENTCOPT__AUTHENTICATOPT__AUTHPREVIEW: new fieldControlClass.ImageControl({
						modelField: 'ValAuthpreview',
						valueChangeEvent: 'fieldChange:authenticatopt.authpreview',
						id: 'AUTHENTCOPT__AUTHENTICATOPT__AUTHPREVIEW',
						name: 'AUTHPREVIEW',
						size: 'mini',
						label: computed(() => this.Resources.PREVIEW45357),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						height: 400,
						width: 300,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PREVIEW45357)),
						maxFileSize: 10485760, // In bytes.
						maxFileSizeLabel: '10 MB',
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
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Authenticatopt: {
						get ValAuthmvc() { return vm.model.ValAuthmvc.value },
						set ValAuthmvc(value) { vm.model.ValAuthmvc.updateValue(value) },
						get ValAuthnotes() { return vm.model.ValAuthnotes.value },
						set ValAuthnotes(value) { vm.model.ValAuthnotes.updateValue(value) },
						get ValAuthoptions() { return vm.model.ValAuthoptions.value },
						set ValAuthoptions(value) { vm.model.ValAuthoptions.updateValue(value) },
						get ValAuthpreview() { return vm.model.ValAuthpreview.value },
						set ValAuthpreview(value) { vm.model.ValAuthpreview.updateValue(value) },
						get ValAuthvariablet() { return vm.model.ValAuthvariablet.value },
						set ValAuthvariablet(value) { vm.model.ValAuthvariablet.updateValue(value) },
						get ValAuthvarname() { return vm.model.ValAuthvarname.value },
						set ValAuthvarname(value) { vm.model.ValAuthvarname.updateValue(value) },
						get ValAuthvue() { return vm.model.ValAuthvue.value },
						set ValAuthvue(value) { vm.model.ValAuthvue.updateValue(value) },
					},
					keys: {
						/** The primary key of the AUTHENTICATOPT table */
						get authenticatopt() { return vm.model.ValCodauthenticatopt },
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
// USE /[MANUAL GQT FORM_CODEJS AUTHENTCOPT]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS AUTHENTCOPT]/
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
// USE /[MANUAL GQT FORM_LOADED_JS AUTHENTCOPT]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS AUTHENTCOPT]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS AUTHENTCOPT]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS AUTHENTCOPT]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS AUTHENTCOPT]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS AUTHENTCOPT]/
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
// USE /[MANUAL GQT AFTER_DEL_JS AUTHENTCOPT]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS AUTHENTCOPT]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS AUTHENTCOPT]/
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
// USE /[MANUAL GQT DLGUPDT AUTHENTCOPT]/
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
// USE /[MANUAL GQT CTRLBLR AUTHENTCOPT]/
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
// USE /[MANUAL GQT CTRLUPD AUTHENTCOPT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS AUTHENTCOPT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
