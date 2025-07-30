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
				@focus-control="focusControl" />
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
			data-key="LEAFLETD"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.LEAFLETDEQUIPREGISTNR.isVisible || controls.LEAFLETDTPEQUTIPOEQUI.isVisible">
					<q-control-wrapper
						v-show="controls.LEAFLETDEQUIPREGISTNR.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETDEQUIPREGISTNR"
							v-on="controls.LEAFLETDEQUIPREGISTNR.handlers"
							:loading="controls.LEAFLETDEQUIPREGISTNR.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.LEAFLETDEQUIPREGISTNR.isVisible"
								v-bind="controls.LEAFLETDEQUIPREGISTNR.props"
								v-on="controls.LEAFLETDEQUIPREGISTNR.handlers" />
							<q-see-more-leafletdequipregistnr
								v-if="controls.LEAFLETDEQUIPREGISTNR.seeMoreIsVisible"
								v-bind="controls.LEAFLETDEQUIPREGISTNR.seeMoreParams"
								v-on="controls.LEAFLETDEQUIPREGISTNR.handlers" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.LEAFLETDTPEQUTIPOEQUI.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETDTPEQUTIPOEQUI"
							v-on="controls.LEAFLETDTPEQUTIPOEQUI.handlers"
							:loading="controls.LEAFLETDTPEQUTIPOEQUI.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.LEAFLETDTPEQUTIPOEQUI.props"
								@blur="onBlur(controls.LEAFLETDTPEQUTIPOEQUI, model.TpequValTipoequi.value)"
								@change="model.TpequValTipoequi.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.LEAFLETDINSTADESIGNAT.isVisible || controls.LEAFLETDINSTADTINIAGE.isVisible || controls.LEAFLETDINSTADTFIMAGE.isVisible">
					<q-control-wrapper
						v-show="controls.LEAFLETDINSTADESIGNAT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETDINSTADESIGNAT"
							v-on="controls.LEAFLETDINSTADESIGNAT.handlers"
							:loading="controls.LEAFLETDINSTADESIGNAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.LEAFLETDINSTADESIGNAT.props"
								@blur="onBlur(controls.LEAFLETDINSTADESIGNAT, model.ValDesignat.value)"
								@change="model.ValDesignat.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.LEAFLETDINSTADTINIAGE.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETDINSTADTINIAGE"
							v-on="controls.LEAFLETDINSTADTINIAGE.handlers"
							:loading="controls.LEAFLETDINSTADTINIAGE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.LEAFLETDINSTADTINIAGE.isVisible"
								v-bind="controls.LEAFLETDINSTADTINIAGE.props"
								:model-value="model.ValDtiniage.value"
								@reset-icon-click="model.ValDtiniage.fnUpdateValue(model.ValDtiniage.originalValue ?? new Date())"
								@update:model-value="model.ValDtiniage.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.LEAFLETDINSTADTFIMAGE.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETDINSTADTFIMAGE"
							v-on="controls.LEAFLETDINSTADTFIMAGE.handlers"
							:loading="controls.LEAFLETDINSTADTFIMAGE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.LEAFLETDINSTADTFIMAGE.isVisible"
								v-bind="controls.LEAFLETDINSTADTFIMAGE.props"
								:model-value="model.ValDtfimage.value"
								@reset-icon-click="model.ValDtfimage.fnUpdateValue(model.ValDtfimage.originalValue ?? new Date())"
								@update:model-value="model.ValDtfimage.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.LEAFLETDINSTADESCRIPT.isVisible">
					<q-control-wrapper
						v-show="controls.LEAFLETDINSTADESCRIPT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-textarea"
							v-bind="controls.LEAFLETDINSTADESCRIPT"
							v-on="controls.LEAFLETDINSTADESCRIPT.handlers"
							:loading="controls.LEAFLETDINSTADESCRIPT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-area
								v-if="controls.LEAFLETDINSTADESCRIPT.isVisible"
								v-bind="controls.LEAFLETDINSTADESCRIPT.props"
								v-on="controls.LEAFLETDINSTADESCRIPT.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.LEAFLETDINSTAALLDAY__.isVisible || controls.LEAFLETDINSTASINCE___.isVisible || controls.LEAFLETDINSTAUNTIL___.isVisible || controls.LEAFLETDINSTAHOURS___.isVisible">
					<q-control-wrapper
						v-show="controls.LEAFLETDINSTAALLDAY__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.LEAFLETDINSTAALLDAY__"
							v-on="controls.LEAFLETDINSTAALLDAY__.handlers"
							:loading="controls.LEAFLETDINSTAALLDAY__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox-input
									v-if="controls.LEAFLETDINSTAALLDAY__.isVisible"
									v-bind="controls.LEAFLETDINSTAALLDAY__.props"
									v-on="controls.LEAFLETDINSTAALLDAY__.handlers" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.LEAFLETDINSTASINCE___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETDINSTASINCE___"
							v-on="controls.LEAFLETDINSTASINCE___.handlers"
							:loading="controls.LEAFLETDINSTASINCE___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.LEAFLETDINSTASINCE___.isVisible"
								v-bind="controls.LEAFLETDINSTASINCE___.props"
								:model-value="model.ValSince.value"
								@reset-icon-click="model.ValSince.fnUpdateValue(model.ValSince.originalValue ?? new Date())"
								@update:model-value="model.ValSince.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.LEAFLETDINSTAUNTIL___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETDINSTAUNTIL___"
							v-on="controls.LEAFLETDINSTAUNTIL___.handlers"
							:loading="controls.LEAFLETDINSTAUNTIL___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.LEAFLETDINSTAUNTIL___.isVisible"
								v-bind="controls.LEAFLETDINSTAUNTIL___.props"
								:model-value="model.ValUntil.value"
								@reset-icon-click="model.ValUntil.fnUpdateValue(model.ValUntil.originalValue ?? new Date())"
								@update:model-value="model.ValUntil.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.LEAFLETDINSTAHOURS___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETDINSTAHOURS___"
							v-on="controls.LEAFLETDINSTAHOURS___.handlers"
							:loading="controls.LEAFLETDINSTAHOURS___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.LEAFLETDINSTAHOURS___.isVisible"
								v-bind="controls.LEAFLETDINSTAHOURS___.props"
								@update:model-value="model.ValHours.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.LEAFLETDINSTAPRECOHOR.isVisible || controls.LEAFLETDINSTAVALUE___.isVisible || controls.LEAFLETDINSTACOORDGEO.isVisible">
					<q-control-wrapper
						v-show="controls.LEAFLETDINSTAPRECOHOR.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETDINSTAPRECOHOR"
							v-on="controls.LEAFLETDINSTAPRECOHOR.handlers"
							:loading="controls.LEAFLETDINSTAPRECOHOR.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.LEAFLETDINSTAPRECOHOR.isVisible"
								v-bind="controls.LEAFLETDINSTAPRECOHOR.props"
								@update:model-value="model.ValPrecohor.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.LEAFLETDINSTAVALUE___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETDINSTAVALUE___"
							v-on="controls.LEAFLETDINSTAVALUE___.handlers"
							:loading="controls.LEAFLETDINSTAVALUE___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.LEAFLETDINSTAVALUE___.isVisible"
								v-bind="controls.LEAFLETDINSTAVALUE___.props"
								@update:model-value="model.ValValue.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.LEAFLETDINSTACOORDGEO.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETDINSTACOORDGEO"
							v-on="controls.LEAFLETDINSTACOORDGEO.handlers"
							:loading="controls.LEAFLETDINSTACOORDGEO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.LEAFLETDINSTACOORDGEO.props"
								@blur="onBlur(controls.LEAFLETDINSTACOORDGEO, model.ValCoordgeo.value)"
								@change="model.ValCoordgeo.fnUpdateValueOnChange" />
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
	/* eslint-disable @typescript-eslint/no-unused-vars */
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
	/* eslint-enable @typescript-eslint/no-unused-vars */

	import FormViewModel from './QFormLeafletdViewModel.js'

	const requiredTextResources = ['QFormLeafletd', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS LEAFLETD]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormLeafletd',

		components: {
			QSeeMoreLeafletdequipregistnr: defineAsyncComponent(() => import('@/views/forms/FormLeafletd/dbedits/LeafletdequipregistnrSeeMore.vue')),
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
					name: 'LEAFLETD',
					location: 'form-LEAFLETD',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormLeafletd', false),

				interfaceMetadata: {
					id: 'QFormLeafletd', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'LEAFLETD',
					route: 'form-LEAFLETD',
					area: 'INSTA',
					primaryKey: 'ValCodinsta',
					designation: '',
					identifier: '', // Unique identifier received by route (when it's nested).
					mode: '',
					availableAgents: [],
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
						text: computed(() => vm.Resources.SAVE04165),
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
					LEAFLETDEQUIPREGISTNR: new fieldControlClass.LookupControl({
						modelField: 'TableEquipRegistnr',
						valueChangeEvent: 'fieldChange:equip.registnr',
						id: 'LEAFLETDEQUIPREGISTNR',
						name: 'REGISTNR',
						size: 'mini',
						label: computed(() => this.Resources.REGISTRATION_NO_06209),
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
							name: 'ValCodequip',
							dependencyEvent: 'fieldChange:insta.codequip'
						},
						dependentFields: () => ({
							set 'equip.codequip'(value) { vm.model.ValCodequip.updateValue(value) },
							set 'equip.registnr'(value) { vm.model.TableEquipRegistnr.updateValue(value) },
							set 'insta.codtpequ'(value) { vm.model.ValCodtpequ.updateValue(value) },
							set 'tpequ.codtpequ'(value) { vm.model.ValCodtpequ.updateValue(value) },
							set 'tpequ.tipoequi'(value) { vm.model.TpequValTipoequi.updateValue(value) },
						}),
						controlLimits: [
							{
								identifier: ['tpequ', 'insta.codtpequ'],
								dependencyEvents: ['fieldChange:insta.codtpequ'],
								dependencyField: 'INSTA.CODTPEQU',
								fnValueSelector: (model) => model.ValCodtpequ.value
							},
						],
					}, this),
					LEAFLETDTPEQUTIPOEQUI: new fieldControlClass.StringControl({
						modelField: 'TpequValTipoequi',
						valueChangeEvent: 'fieldChange:tpequ.tipoequi',
						dependentModelField: 'ValCodtpequ',
						dependentChangeEvent: 'fieldChange:insta.codtpequ',
						id: 'LEAFLETDTPEQUTIPOEQUI',
						name: 'TIPOEQUI',
						size: 'xlarge',
						label: computed(() => this.Resources.TYPE_OF_EQUIPMENT64921),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_LEAFLETDTPEQUTIPOEQUI',
						controlLimits: [
						],
					}, this),
					LEAFLETDINSTADESIGNAT: new fieldControlClass.StringControl({
						modelField: 'ValDesignat',
						valueChangeEvent: 'fieldChange:insta.designat',
						id: 'LEAFLETDINSTADESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.SCHEDULING24801),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						labelId: 'label_LEAFLETDINSTADESIGNAT',
						controlLimits: [
						],
					}, this),
					LEAFLETDINSTADTINIAGE: new fieldControlClass.DateControl({
						modelField: 'ValDtiniage',
						valueChangeEvent: 'fieldChange:insta.dtiniage',
						id: 'LEAFLETDINSTADTINIAGE',
						name: 'DTINIAGE',
						size: 'medium',
						label: computed(() => this.Resources.START00919),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'dateTime',
						controlLimits: [
						],
					}, this),
					LEAFLETDINSTADTFIMAGE: new fieldControlClass.DateControl({
						modelField: 'ValDtfimage',
						valueChangeEvent: 'fieldChange:insta.dtfimage',
						id: 'LEAFLETDINSTADTFIMAGE',
						name: 'DTFIMAGE',
						size: 'medium',
						label: computed(() => this.Resources.END47577),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'dateTime',
						controlLimits: [
						],
					}, this),
					LEAFLETDINSTADESCRIPT: new fieldControlClass.MultilineStringControl({
						modelField: 'ValDescript',
						valueChangeEvent: 'fieldChange:insta.descript',
						id: 'LEAFLETDINSTADESCRIPT',
						name: 'DESCRIPT',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESCRIPTION07383),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						rows: 3,
						cols: 85,
						controlLimits: [
						],
					}, this),
					LEAFLETDINSTAALLDAY__: new fieldControlClass.BooleanControl({
						modelField: 'ValAllday',
						valueChangeEvent: 'fieldChange:insta.allday',
						id: 'LEAFLETDINSTAALLDAY__',
						name: 'ALLDAY',
						size: 'small',
						label: computed(() => this.Resources.ALL_DAY18496),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						controlLimits: [
						],
					}, this),
					LEAFLETDINSTASINCE___: new fieldControlClass.DateControl({
						modelField: 'ValSince',
						valueChangeEvent: 'fieldChange:insta.since',
						id: 'LEAFLETDINSTASINCE___',
						name: 'SINCE',
						size: 'medium',
						label: computed(() => this.Resources.SINCE47259),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'dateTime',
						controlLimits: [
						],
					}, this),
					LEAFLETDINSTAUNTIL___: new fieldControlClass.DateControl({
						modelField: 'ValUntil',
						valueChangeEvent: 'fieldChange:insta.until',
						id: 'LEAFLETDINSTAUNTIL___',
						name: 'UNTIL',
						size: 'medium',
						label: computed(() => this.Resources.UNTIL39173),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'dateTime',
						controlLimits: [
						],
					}, this),
					LEAFLETDINSTAHOURS___: new fieldControlClass.NumberControl({
						modelField: 'ValHours',
						valueChangeEvent: 'fieldChange:insta.hours',
						id: 'LEAFLETDINSTAHOURS___',
						name: 'HOURS',
						size: 'small',
						label: computed(() => this.Resources.QUANTITY_OF_HOURS_61426),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						maxIntegers: 7,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					LEAFLETDINSTAPRECOHOR: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrecohor',
						valueChangeEvent: 'fieldChange:insta.precohor',
						id: 'LEAFLETDINSTAPRECOHOR',
						name: 'PRECOHOR',
						size: 'medium',
						label: computed(() => this.Resources.PRICE_PER_HOUR_37472),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						maxIntegers: 9,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					LEAFLETDINSTAVALUE___: new fieldControlClass.CurrencyControl({
						modelField: 'ValValue',
						valueChangeEvent: 'fieldChange:insta.value',
						id: 'LEAFLETDINSTAVALUE___',
						name: 'VALUE',
						size: 'medium',
						label: computed(() => this.Resources.VALUE10285),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						maxIntegers: 9,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					LEAFLETDINSTACOORDGEO: new fieldControlClass.BaseControl({
						modelField: 'ValCoordgeo',
						valueChangeEvent: 'fieldChange:insta.coordgeo',
						isGeographicShape: false,
						isEuclideanCoord: false,
						id: 'LEAFLETDINSTACOORDGEO',
						name: 'COORDGEO',
						size: 'medium',
						label: computed(() => this.Resources.GEOGRAPHIC_COORDINAT42880),
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
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Equip: {
						get ValRegistnr() { return vm.model.TableEquipRegistnr.value },
						set ValRegistnr(value) { vm.model.TableEquipRegistnr.updateValue(value) },
					},
					Insta: {
						get ValAllday() { return vm.model.ValAllday.value },
						set ValAllday(value) { vm.model.ValAllday.updateValue(value) },
						get ValCodequip() { return vm.model.ValCodequip.value },
						set ValCodequip(value) { vm.model.ValCodequip.updateValue(value) },
						get ValCodtpequ() { return vm.model.ValCodtpequ.value },
						set ValCodtpequ(value) { vm.model.ValCodtpequ.updateValue(value) },
						get ValCoordgeo() { return vm.model.ValCoordgeo.value },
						set ValCoordgeo(value) { vm.model.ValCoordgeo.updateValue(value) },
						get ValDescript() { return vm.model.ValDescript.value },
						set ValDescript(value) { vm.model.ValDescript.updateValue(value) },
						get ValDesignat() { return vm.model.ValDesignat.value },
						set ValDesignat(value) { vm.model.ValDesignat.updateValue(value) },
						get ValDtfimage() { return vm.model.ValDtfimage.value },
						set ValDtfimage(value) { vm.model.ValDtfimage.updateValue(value) },
						get ValDtiniage() { return vm.model.ValDtiniage.value },
						set ValDtiniage(value) { vm.model.ValDtiniage.updateValue(value) },
						get ValHours() { return vm.model.ValHours.value },
						set ValHours(value) { vm.model.ValHours.updateValue(value) },
						get ValPrecohor() { return vm.model.ValPrecohor.value },
						set ValPrecohor(value) { vm.model.ValPrecohor.updateValue(value) },
						get ValSince() { return vm.model.ValSince.value },
						set ValSince(value) { vm.model.ValSince.updateValue(value) },
						get ValUntil() { return vm.model.ValUntil.value },
						set ValUntil(value) { vm.model.ValUntil.updateValue(value) },
						get ValValue() { return vm.model.ValValue.value },
						set ValValue(value) { vm.model.ValValue.updateValue(value) },
					},
					Tpequ: {
						get ValTipoequi() { return vm.model.TpequValTipoequi.value },
						set ValTipoequi(value) { vm.model.TpequValTipoequi.updateValue(value) },
					},
					keys: {
						/** The primary key of the INSTA table */
						get insta() { return vm.model.ValCodinsta },
						/** The foreign key to the TPEQU table */
						get tpequ() { return vm.model.ValCodtpequ },
						/** The foreign key to the EQUIP table */
						get equip() { return vm.model.ValCodequip },
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
// USE /[MANUAL GQT FORM_CODEJS LEAFLETD]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT LEAFLETD]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS LEAFLETD]/
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
// USE /[MANUAL GQT FORM_LOADED_JS LEAFLETD]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS LEAFLETD]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS LEAFLETD]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS LEAFLETD]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS LEAFLETD]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS LEAFLETD]/
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
// USE /[MANUAL GQT AFTER_DEL_JS LEAFLETD]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS LEAFLETD]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS LEAFLETD]/
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
// USE /[MANUAL GQT DLGUPDT LEAFLETD]/
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
// USE /[MANUAL GQT CTRLBLR LEAFLETD]/
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
// USE /[MANUAL GQT CTRLUPD LEAFLETD]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS LEAFLETD]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
