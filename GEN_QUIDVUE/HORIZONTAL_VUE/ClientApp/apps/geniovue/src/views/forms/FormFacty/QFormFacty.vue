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
			data-key="FACTY"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.FACTY___FACTYTYPE____.isVisible || controls.FACTY___FACTYLAYRNAME.isVisible || controls.FACTY___FACTYICONURL_.isVisible || controls.FACTY___FACTYSHADOWUR.isVisible || controls.FACTY___FACTYICONANCX.isVisible || controls.FACTY___FACTYICONANCY.isVisible || controls.FACTY___FACTYICONHEIG.isVisible || controls.FACTY___FACTYICONWID_.isVisible || controls.FACTY___FACTYPOPUPANX.isVisible || controls.FACTY___FACTYPOPUPANY.isVisible || controls.FACTY___FACTYSHADOWAX.isVisible || controls.FACTY___FACTYSHADOWAY.isVisible || controls.FACTY___FACTYSHADOWHE.isVisible || controls.FACTY___FACTYSHADOWWI.isVisible">
					<q-control-wrapper
						v-show="controls.FACTY___FACTYTYPE____.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACTY___FACTYTYPE____"
							v-on="controls.FACTY___FACTYTYPE____.handlers"
							:loading="controls.FACTY___FACTYTYPE____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.FACTY___FACTYTYPE____.props"
								@blur="onBlur(controls.FACTY___FACTYTYPE____, model.ValType.value)"
								@change="model.ValType.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FACTY___FACTYLAYRNAME.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACTY___FACTYLAYRNAME"
							v-on="controls.FACTY___FACTYLAYRNAME.handlers"
							:loading="controls.FACTY___FACTYLAYRNAME.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.FACTY___FACTYLAYRNAME.props"
								@blur="onBlur(controls.FACTY___FACTYLAYRNAME, model.ValLayrname.value)"
								@change="model.ValLayrname.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FACTY___FACTYICONURL_.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACTY___FACTYICONURL_"
							v-on="controls.FACTY___FACTYICONURL_.handlers"
							:loading="controls.FACTY___FACTYICONURL_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.FACTY___FACTYICONURL_.props"
								@blur="onBlur(controls.FACTY___FACTYICONURL_, model.ValIconurl.value)"
								@change="model.ValIconurl.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FACTY___FACTYSHADOWUR.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACTY___FACTYSHADOWUR"
							v-on="controls.FACTY___FACTYSHADOWUR.handlers"
							:loading="controls.FACTY___FACTYSHADOWUR.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.FACTY___FACTYSHADOWUR.props"
								@blur="onBlur(controls.FACTY___FACTYSHADOWUR, model.ValShadowur.value)"
								@change="model.ValShadowur.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FACTY___FACTYICONANCX.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACTY___FACTYICONANCX"
							v-on="controls.FACTY___FACTYICONANCX.handlers"
							:loading="controls.FACTY___FACTYICONANCX.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.FACTY___FACTYICONANCX.isVisible"
								v-bind="controls.FACTY___FACTYICONANCX.props"
								@update:model-value="model.ValIconancx.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FACTY___FACTYICONANCY.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACTY___FACTYICONANCY"
							v-on="controls.FACTY___FACTYICONANCY.handlers"
							:loading="controls.FACTY___FACTYICONANCY.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.FACTY___FACTYICONANCY.isVisible"
								v-bind="controls.FACTY___FACTYICONANCY.props"
								@update:model-value="model.ValIconancy.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FACTY___FACTYICONHEIG.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACTY___FACTYICONHEIG"
							v-on="controls.FACTY___FACTYICONHEIG.handlers"
							:loading="controls.FACTY___FACTYICONHEIG.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.FACTY___FACTYICONHEIG.isVisible"
								v-bind="controls.FACTY___FACTYICONHEIG.props"
								@update:model-value="model.ValIconheig.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FACTY___FACTYICONWID_.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACTY___FACTYICONWID_"
							v-on="controls.FACTY___FACTYICONWID_.handlers"
							:loading="controls.FACTY___FACTYICONWID_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.FACTY___FACTYICONWID_.isVisible"
								v-bind="controls.FACTY___FACTYICONWID_.props"
								@update:model-value="model.ValIconwid.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FACTY___FACTYPOPUPANX.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACTY___FACTYPOPUPANX"
							v-on="controls.FACTY___FACTYPOPUPANX.handlers"
							:loading="controls.FACTY___FACTYPOPUPANX.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.FACTY___FACTYPOPUPANX.isVisible"
								v-bind="controls.FACTY___FACTYPOPUPANX.props"
								@update:model-value="model.ValPopupanx.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FACTY___FACTYPOPUPANY.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACTY___FACTYPOPUPANY"
							v-on="controls.FACTY___FACTYPOPUPANY.handlers"
							:loading="controls.FACTY___FACTYPOPUPANY.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.FACTY___FACTYPOPUPANY.isVisible"
								v-bind="controls.FACTY___FACTYPOPUPANY.props"
								@update:model-value="model.ValPopupany.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FACTY___FACTYSHADOWAX.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACTY___FACTYSHADOWAX"
							v-on="controls.FACTY___FACTYSHADOWAX.handlers"
							:loading="controls.FACTY___FACTYSHADOWAX.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.FACTY___FACTYSHADOWAX.isVisible"
								v-bind="controls.FACTY___FACTYSHADOWAX.props"
								@update:model-value="model.ValShadowax.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FACTY___FACTYSHADOWAY.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACTY___FACTYSHADOWAY"
							v-on="controls.FACTY___FACTYSHADOWAY.handlers"
							:loading="controls.FACTY___FACTYSHADOWAY.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.FACTY___FACTYSHADOWAY.isVisible"
								v-bind="controls.FACTY___FACTYSHADOWAY.props"
								@update:model-value="model.ValShadoway.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FACTY___FACTYSHADOWHE.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACTY___FACTYSHADOWHE"
							v-on="controls.FACTY___FACTYSHADOWHE.handlers"
							:loading="controls.FACTY___FACTYSHADOWHE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.FACTY___FACTYSHADOWHE.isVisible"
								v-bind="controls.FACTY___FACTYSHADOWHE.props"
								@update:model-value="model.ValShadowhe.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FACTY___FACTYSHADOWWI.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACTY___FACTYSHADOWWI"
							v-on="controls.FACTY___FACTYSHADOWWI.handlers"
							:loading="controls.FACTY___FACTYSHADOWWI.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.FACTY___FACTYSHADOWWI.isVisible"
								v-bind="controls.FACTY___FACTYSHADOWWI.props"
								@update:model-value="model.ValShadowwi.fnUpdateValue" />
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

	import FormViewModel from './QFormFactyViewModel.js'

	const requiredTextResources = ['QFormFacty', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS FACTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormFacty',

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
					name: 'FACTY',
					location: 'form-FACTY',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormFacty', false),

				interfaceMetadata: {
					id: 'QFormFacty', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'FACTY',
					route: 'form-FACTY',
					area: 'FACTY',
					primaryKey: 'ValCodfacty',
					designation: computed(() => this.Resources.FACILITY_TYPE44577),
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
					FACTY___FACTYTYPE____: new fieldControlClass.StringControl({
						modelField: 'ValType',
						valueChangeEvent: 'fieldChange:facty.type',
						id: 'FACTY___FACTYTYPE____',
						name: 'TYPE',
						size: 'medium',
						label: computed(() => this.Resources.FACILITY_TYPE44577),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 25,
						labelId: 'label_FACTY___FACTYTYPE____',
						controlLimits: [
						],
					}, this),
					FACTY___FACTYLAYRNAME: new fieldControlClass.StringControl({
						modelField: 'ValLayrname',
						valueChangeEvent: 'fieldChange:facty.layrname',
						id: 'FACTY___FACTYLAYRNAME',
						name: 'LAYRNAME',
						size: 'xlarge',
						label: computed(() => this.Resources.LAYER_NAME49545),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_FACTY___FACTYLAYRNAME',
						controlLimits: [
						],
					}, this),
					FACTY___FACTYICONURL_: new fieldControlClass.StringControl({
						modelField: 'ValIconurl',
						valueChangeEvent: 'fieldChange:facty.iconurl',
						id: 'FACTY___FACTYICONURL_',
						name: 'ICONURL',
						size: 'xlarge',
						label: computed(() => this.Resources.ICON_URL07016),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_FACTY___FACTYICONURL_',
						controlLimits: [
						],
					}, this),
					FACTY___FACTYSHADOWUR: new fieldControlClass.StringControl({
						modelField: 'ValShadowur',
						valueChangeEvent: 'fieldChange:facty.shadowur',
						id: 'FACTY___FACTYSHADOWUR',
						name: 'SHADOWUR',
						size: 'xlarge',
						label: computed(() => this.Resources.SHADOW_URL57805),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_FACTY___FACTYSHADOWUR',
						controlLimits: [
						],
					}, this),
					FACTY___FACTYICONANCX: new fieldControlClass.NumberControl({
						modelField: 'ValIconancx',
						valueChangeEvent: 'fieldChange:facty.iconancx',
						id: 'FACTY___FACTYICONANCX',
						name: 'ICONANCX',
						size: 'medium',
						label: computed(() => this.Resources.ICON_ANCHOR__X_AXIS_18664),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					FACTY___FACTYICONANCY: new fieldControlClass.NumberControl({
						modelField: 'ValIconancy',
						valueChangeEvent: 'fieldChange:facty.iconancy',
						id: 'FACTY___FACTYICONANCY',
						name: 'ICONANCY',
						size: 'medium',
						label: computed(() => this.Resources.ICON_ANCHOR__Y_AXIS_63725),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					FACTY___FACTYICONHEIG: new fieldControlClass.NumberControl({
						modelField: 'ValIconheig',
						valueChangeEvent: 'fieldChange:facty.iconheig',
						id: 'FACTY___FACTYICONHEIG',
						name: 'ICONHEIG',
						size: 'mini',
						label: computed(() => this.Resources.ICON_HEIGHT61896),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					FACTY___FACTYICONWID_: new fieldControlClass.NumberControl({
						modelField: 'ValIconwid',
						valueChangeEvent: 'fieldChange:facty.iconwid',
						id: 'FACTY___FACTYICONWID_',
						name: 'ICONWID',
						size: 'mini',
						label: computed(() => this.Resources.ICON_WIDTH02295),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					FACTY___FACTYPOPUPANX: new fieldControlClass.NumberControl({
						modelField: 'ValPopupanx',
						valueChangeEvent: 'fieldChange:facty.popupanx',
						id: 'FACTY___FACTYPOPUPANX',
						name: 'POPUPANX',
						size: 'medium',
						label: computed(() => this.Resources.POPUP_ANCHOR__X_AXIS15060),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					FACTY___FACTYPOPUPANY: new fieldControlClass.NumberControl({
						modelField: 'ValPopupany',
						valueChangeEvent: 'fieldChange:facty.popupany',
						id: 'FACTY___FACTYPOPUPANY',
						name: 'POPUPANY',
						size: 'medium',
						label: computed(() => this.Resources.POPUP_ANCHOR__Y_AXIS64670),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					FACTY___FACTYSHADOWAX: new fieldControlClass.NumberControl({
						modelField: 'ValShadowax',
						valueChangeEvent: 'fieldChange:facty.shadowax',
						id: 'FACTY___FACTYSHADOWAX',
						name: 'SHADOWAX',
						size: 'medium',
						label: computed(() => this.Resources.SHADOW_ANCHOR__X_AXI31230),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					FACTY___FACTYSHADOWAY: new fieldControlClass.NumberControl({
						modelField: 'ValShadoway',
						valueChangeEvent: 'fieldChange:facty.shadoway',
						id: 'FACTY___FACTYSHADOWAY',
						name: 'SHADOWAY',
						size: 'medium',
						label: computed(() => this.Resources.SHADOW_ANCHOR__Y_AXI51495),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					FACTY___FACTYSHADOWHE: new fieldControlClass.NumberControl({
						modelField: 'ValShadowhe',
						valueChangeEvent: 'fieldChange:facty.shadowhe',
						id: 'FACTY___FACTYSHADOWHE',
						name: 'SHADOWHE',
						size: 'small',
						label: computed(() => this.Resources.SHADOW_HEIGHT64343),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					FACTY___FACTYSHADOWWI: new fieldControlClass.NumberControl({
						modelField: 'ValShadowwi',
						valueChangeEvent: 'fieldChange:facty.shadowwi',
						id: 'FACTY___FACTYSHADOWWI',
						name: 'SHADOWWI',
						size: 'small',
						label: computed(() => this.Resources.SHADOW_WIDTH01769),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 3,
						maxDecimals: 0,
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
					Facty: {
						get ValIconancx() { return vm.model.ValIconancx.value },
						set ValIconancx(value) { vm.model.ValIconancx.updateValue(value) },
						get ValIconancy() { return vm.model.ValIconancy.value },
						set ValIconancy(value) { vm.model.ValIconancy.updateValue(value) },
						get ValIconheig() { return vm.model.ValIconheig.value },
						set ValIconheig(value) { vm.model.ValIconheig.updateValue(value) },
						get ValIconurl() { return vm.model.ValIconurl.value },
						set ValIconurl(value) { vm.model.ValIconurl.updateValue(value) },
						get ValIconwid() { return vm.model.ValIconwid.value },
						set ValIconwid(value) { vm.model.ValIconwid.updateValue(value) },
						get ValLayrname() { return vm.model.ValLayrname.value },
						set ValLayrname(value) { vm.model.ValLayrname.updateValue(value) },
						get ValPopupanx() { return vm.model.ValPopupanx.value },
						set ValPopupanx(value) { vm.model.ValPopupanx.updateValue(value) },
						get ValPopupany() { return vm.model.ValPopupany.value },
						set ValPopupany(value) { vm.model.ValPopupany.updateValue(value) },
						get ValShadowax() { return vm.model.ValShadowax.value },
						set ValShadowax(value) { vm.model.ValShadowax.updateValue(value) },
						get ValShadoway() { return vm.model.ValShadoway.value },
						set ValShadoway(value) { vm.model.ValShadoway.updateValue(value) },
						get ValShadowhe() { return vm.model.ValShadowhe.value },
						set ValShadowhe(value) { vm.model.ValShadowhe.updateValue(value) },
						get ValShadowur() { return vm.model.ValShadowur.value },
						set ValShadowur(value) { vm.model.ValShadowur.updateValue(value) },
						get ValShadowwi() { return vm.model.ValShadowwi.value },
						set ValShadowwi(value) { vm.model.ValShadowwi.updateValue(value) },
						get ValType() { return vm.model.ValType.value },
						set ValType(value) { vm.model.ValType.updateValue(value) },
					},
					keys: {
						/** The primary key of the FACTY table */
						get facty() { return vm.model.ValCodfacty },
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
// USE /[MANUAL GQT FORM_CODEJS FACTY]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS FACTY]/
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
// USE /[MANUAL GQT FORM_LOADED_JS FACTY]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS FACTY]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS FACTY]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS FACTY]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS FACTY]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS FACTY]/
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
// USE /[MANUAL GQT AFTER_DEL_JS FACTY]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS FACTY]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS FACTY]/
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
// USE /[MANUAL GQT DLGUPDT FACTY]/
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
// USE /[MANUAL GQT CTRLBLR FACTY]/
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
// USE /[MANUAL GQT CTRLUPD FACTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS FACTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
