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
				v-if="layoutConfig.FormAnchorsPosition === 'form-header' && groupFields.length > 0"
				:is-visible="anchorContainerVisibility"
				:anchors="groupFields"
				:controls="controls"
				:header-height="visibleHeaderHeight"
				@focus-control="(...args) => focusControl(...args)" />
		</div>
	</teleport>

	<teleport
		v-if="formModalIsReady && showFormBody"
		:to="`#${uiContainersId.body}`"
		:disabled="!isPopup || isNested">
		<q-validation-summary
			:error-data="validationErrors"
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
			data-key="LEAFLETT"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.LEAFLETTEQUIPREGISTNR.isVisible || controls.LEAFLETTTPEQUTIPOEQUI.isVisible">
					<q-control-wrapper
						v-show="controls.LEAFLETTEQUIPREGISTNR.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETTEQUIPREGISTNR"
							v-on="controls.LEAFLETTEQUIPREGISTNR.handlers"
							:loading="controls.LEAFLETTEQUIPREGISTNR.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-lookup
								v-if="controls.LEAFLETTEQUIPREGISTNR.isVisible"
								v-bind="controls.LEAFLETTEQUIPREGISTNR.props"
								:model-value="model.ValCodequip.value"
								v-on="controls.LEAFLETTEQUIPREGISTNR.handlers"
								@update:model-value="model.ValCodequip.fnUpdateValue" />
							<q-see-more-leaflettequipregistnr
								v-if="controls.LEAFLETTEQUIPREGISTNR.seeMoreIsVisible"
								v-bind="controls.LEAFLETTEQUIPREGISTNR.seeMoreParams"
								v-on="controls.LEAFLETTEQUIPREGISTNR.handlers" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.LEAFLETTTPEQUTIPOEQUI.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETTTPEQUTIPOEQUI"
							v-on="controls.LEAFLETTTPEQUTIPOEQUI.handlers"
							:loading="controls.LEAFLETTTPEQUTIPOEQUI.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.LEAFLETTTPEQUTIPOEQUI.props"
								:model-value="model.TpequValTipoequi.value" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.LEAFLETTINSTADESCRIPT.isVisible || controls.LEAFLETTINSTADESIGNAT.isVisible || controls.LEAFLETTINSTADTINIAGE.isVisible || controls.LEAFLETTINSTADTFIMAGE.isVisible || controls.LEAFLETTINSTAALLDAY__.isVisible || controls.LEAFLETTINSTASINCE___.isVisible || controls.LEAFLETTINSTAUNTIL___.isVisible || controls.LEAFLETTINSTAHOURS___.isVisible || controls.LEAFLETTINSTAPRECOHOR.isVisible || controls.LEAFLETTINSTAVALUE___.isVisible || controls.LEAFLETTINSTACOORDGEO.isVisible">
					<q-control-wrapper
						v-show="controls.LEAFLETTINSTADESCRIPT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-textarea"
							v-bind="controls.LEAFLETTINSTADESCRIPT"
							v-on="controls.LEAFLETTINSTADESCRIPT.handlers"
							:loading="controls.LEAFLETTINSTADESCRIPT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-textarea-input
								v-if="controls.LEAFLETTINSTADESCRIPT.isVisible"
								id="LEAFLETTINSTADESCRIPT"
								size="xxlarge"
								:model-value="model.ValDescript.value"
								:rows="3"
								:cols="85"
								:is-required="controls.LEAFLETTINSTADESCRIPT.isRequired"
								:readonly="controls.LEAFLETTINSTADESCRIPT.readonly"
								:placeholder="controls.LEAFLETTINSTADESCRIPT.placeholder"
								@update:model-value="model.ValDescript.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.LEAFLETTINSTADESIGNAT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETTINSTADESIGNAT"
							v-on="controls.LEAFLETTINSTADESIGNAT.handlers"
							:loading="controls.LEAFLETTINSTADESIGNAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.LEAFLETTINSTADESIGNAT.props"
								:model-value="model.ValDesignat.value"
								@update:model-value="model.ValDesignat.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.LEAFLETTINSTADTINIAGE.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETTINSTADTINIAGE"
							v-on="controls.LEAFLETTINSTADTINIAGE.handlers"
							:loading="controls.LEAFLETTINSTADTINIAGE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-datetime-input
								v-if="controls.LEAFLETTINSTADTINIAGE.isVisible"
								v-bind="controls.LEAFLETTINSTADTINIAGE"
								format="DateTime"
								:model-value="model.ValDtiniage.value"
								@update:model-value="model.ValDtiniage.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.LEAFLETTINSTADTFIMAGE.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETTINSTADTFIMAGE"
							v-on="controls.LEAFLETTINSTADTFIMAGE.handlers"
							:loading="controls.LEAFLETTINSTADTFIMAGE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-datetime-input
								v-if="controls.LEAFLETTINSTADTFIMAGE.isVisible"
								v-bind="controls.LEAFLETTINSTADTFIMAGE"
								format="DateTime"
								:model-value="model.ValDtfimage.value"
								@update:model-value="model.ValDtfimage.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.LEAFLETTINSTAALLDAY__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.LEAFLETTINSTAALLDAY__"
							v-on="controls.LEAFLETTINSTAALLDAY__.handlers"
							:loading="controls.LEAFLETTINSTAALLDAY__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<template #label>
								<q-checkbox-input
									v-if="controls.LEAFLETTINSTAALLDAY__.isVisible"
									id="LEAFLETTINSTAALLDAY__"
									size="small"
									:model-value="model.ValAllday.value"
									:readonly="controls.LEAFLETTINSTAALLDAY__.readonly"
									@update:model-value="model.ValAllday.fnUpdateValue" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.LEAFLETTINSTASINCE___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETTINSTASINCE___"
							v-on="controls.LEAFLETTINSTASINCE___.handlers"
							:loading="controls.LEAFLETTINSTASINCE___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-datetime-input
								v-if="controls.LEAFLETTINSTASINCE___.isVisible"
								v-bind="controls.LEAFLETTINSTASINCE___"
								format="DateTime"
								:model-value="model.ValSince.value"
								@update:model-value="model.ValSince.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.LEAFLETTINSTAUNTIL___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETTINSTAUNTIL___"
							v-on="controls.LEAFLETTINSTAUNTIL___.handlers"
							:loading="controls.LEAFLETTINSTAUNTIL___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-datetime-input
								v-if="controls.LEAFLETTINSTAUNTIL___.isVisible"
								v-bind="controls.LEAFLETTINSTAUNTIL___"
								format="DateTime"
								:model-value="model.ValUntil.value"
								@update:model-value="model.ValUntil.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.LEAFLETTINSTAHOURS___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETTINSTAHOURS___"
							v-on="controls.LEAFLETTINSTAHOURS___.handlers"
							:loading="controls.LEAFLETTINSTAHOURS___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-numeric-input
								v-if="controls.LEAFLETTINSTAHOURS___.isVisible"
								v-bind="controls.LEAFLETTINSTAHOURS___"
								:model-value="model.ValHours.value"
								@update:model-value="model.ValHours.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.LEAFLETTINSTAPRECOHOR.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETTINSTAPRECOHOR"
							v-on="controls.LEAFLETTINSTAPRECOHOR.handlers"
							:loading="controls.LEAFLETTINSTAPRECOHOR.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-numeric-input
								v-if="controls.LEAFLETTINSTAPRECOHOR.isVisible"
								v-bind="controls.LEAFLETTINSTAPRECOHOR"
								:model-value="model.ValPrecohor.value"
								@update:model-value="model.ValPrecohor.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.LEAFLETTINSTAVALUE___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETTINSTAVALUE___"
							v-on="controls.LEAFLETTINSTAVALUE___.handlers"
							:loading="controls.LEAFLETTINSTAVALUE___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-numeric-input
								v-if="controls.LEAFLETTINSTAVALUE___.isVisible"
								v-bind="controls.LEAFLETTINSTAVALUE___"
								:model-value="model.ValValue.value"
								@update:model-value="model.ValValue.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.LEAFLETTINSTACOORDGEO.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LEAFLETTINSTACOORDGEO"
							v-on="controls.LEAFLETTINSTACOORDGEO.handlers"
							:loading="controls.LEAFLETTINSTACOORDGEO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.LEAFLETTINSTACOORDGEO.props"
								:model-value="model.ValCoordgeo.value"
								@update:model-value="model.ValCoordgeo.fnUpdateValue" />
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

	import FormViewModel from './QFormLeaflettViewModel.js'

	const requiredTextResources = ['QFormLeaflett', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS LEAFLETT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormLeaflett',

		components: {
			QSeeMoreLeaflettequipregistnr: defineAsyncComponent(() => import('@/views/forms/FormLeaflett/dbedits/LeaflettequipregistnrSeeMore.vue')),
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
				default: () => {
					return {
						name: 'LEAFLETT',
						location: 'form-LEAFLETT',
						params: {
							isNested: true
						}
					}
				}
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormLeaflett', false),

				interfaceMetadata: {
					id: 'QFormLeaflett', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'LEAFLETT',
					route: 'form-LEAFLETT',
					area: 'INSTA',
					primaryKey: 'ValCodinsta',
					designation: computed(() => this.Resources.INSTALLATION12952),
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
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.insert]),
						style: 'secondary',
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
						style: 'primary',
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
						style: 'primary',
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
						action: vm.resetFormFields,
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
					},
					showAnchors: {
						id: 'toggle-form-anchors',
						icon: {
							icon: 'list-bordered',
							type: 'svg'
						},
						text: computed(() => vm.anchorContainerVisibility ? vm.Resources[hardcodedTexts.hideAnchors] : vm.Resources[hardcodedTexts.showAnchors]),
						type: 'form-action',
						style: 'primary',
						showInHeader: true,
						showInFooter: false,
						isActive: true,
						isVisible: computed(() => vm.isAnchorsButtonVisible),
						action: vm.toggleAnchorVisibility
					}
				},

				controls: {
					LEAFLETTEQUIPREGISTNR: new fieldControlClass.LookupControl({
						modelField: 'TableEquipRegistnr',
						valueChangeEvent: 'fieldChange:equip.registnr',
						id: 'LEAFLETTEQUIPREGISTNR',
						name: 'REGISTNR',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.REGISTRATION_NO_06209),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
							{
								identifier: ['tpequ', 'insta.codtpequ'],
								dependencyEvents: ['fieldChange:insta.codtpequ'],
								dependencyField: 'INSTA.CODTPEQU',
								fnValueSelector: (model) => model.ValCodtpequ.value
							},
						],
						lookupKeyModelField: {
							name: 'ValCodequip',
							dependencyEvent: 'fieldChange:insta.codequip'
						},
						dependentFields: () => {
							return {
								set 'equip.codequip'(value) { vm.model.ValCodequip.updateValue(value) },
								set 'equip.registnr'(value) { vm.model.TableEquipRegistnr.updateValue(value) },
								set 'insta.codtpequ'(value) { vm.model.ValCodtpequ.updateValue(value) },
								set 'tpequ.tipoequi'(value) { vm.model.TpequValTipoequi.updateValue(value) },
							}
						},
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
					}, this),
					LEAFLETTTPEQUTIPOEQUI: new fieldControlClass.StringControl({
						modelField: 'TpequValTipoequi',
						valueChangeEvent: 'fieldChange:tpequ.tipoequi',
						dependentModelField: 'ValCodtpequ',
						dependentChangeEvent: 'fieldChange:insta.codtpequ',
						id: 'LEAFLETTTPEQUTIPOEQUI',
						name: 'TIPOEQUI',
						size: 'xlarge',
						hasLabel: true,
						label: '',
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_LEAFLETTTPEQUTIPOEQUI',
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					LEAFLETTINSTADESCRIPT: new fieldControlClass.StringControl({
						modelField: 'ValDescript',
						valueChangeEvent: 'fieldChange:insta.descript',
						id: 'LEAFLETTINSTADESCRIPT',
						name: 'DESCRIPT',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.DESCRIPTION07383),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						labelId: 'label_LEAFLETTINSTADESCRIPT',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					LEAFLETTINSTADESIGNAT: new fieldControlClass.StringControl({
						modelField: 'ValDesignat',
						valueChangeEvent: 'fieldChange:insta.designat',
						id: 'LEAFLETTINSTADESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.SCHEDULING24801),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						labelId: 'label_LEAFLETTINSTADESIGNAT',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					LEAFLETTINSTADTINIAGE: new fieldControlClass.DateControl({
						modelField: 'ValDtiniage',
						valueChangeEvent: 'fieldChange:insta.dtiniage',
						id: 'LEAFLETTINSTADTINIAGE',
						name: 'DTINIAGE',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.START00919),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					LEAFLETTINSTADTFIMAGE: new fieldControlClass.DateControl({
						modelField: 'ValDtfimage',
						valueChangeEvent: 'fieldChange:insta.dtfimage',
						id: 'LEAFLETTINSTADTFIMAGE',
						name: 'DTFIMAGE',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.END47577),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					LEAFLETTINSTAALLDAY__: new fieldControlClass.BooleanControl({
						modelField: 'ValAllday',
						valueChangeEvent: 'fieldChange:insta.allday',
						id: 'LEAFLETTINSTAALLDAY__',
						name: 'ALLDAY',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.ALL_DAY18496),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					LEAFLETTINSTASINCE___: new fieldControlClass.DateControl({
						modelField: 'ValSince',
						valueChangeEvent: 'fieldChange:insta.since',
						id: 'LEAFLETTINSTASINCE___',
						name: 'SINCE',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.SINCE47259),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					LEAFLETTINSTAUNTIL___: new fieldControlClass.DateControl({
						modelField: 'ValUntil',
						valueChangeEvent: 'fieldChange:insta.until',
						id: 'LEAFLETTINSTAUNTIL___',
						name: 'UNTIL',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.UNTIL39173),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					LEAFLETTINSTAHOURS___: new fieldControlClass.NumberControl({
						modelField: 'ValHours',
						valueChangeEvent: 'fieldChange:insta.hours',
						maxIntegers: 7,
						maxDecimals: 2,
						id: 'LEAFLETTINSTAHOURS___',
						name: 'HOURS',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.QUANTITY_OF_HOURS_61426),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					LEAFLETTINSTAPRECOHOR: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrecohor',
						valueChangeEvent: 'fieldChange:insta.precohor',
						maxIntegers: 9,
						maxDecimals: 2,
						id: 'LEAFLETTINSTAPRECOHOR',
						name: 'PRECOHOR',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.PRICE_PER_HOUR_37472),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					LEAFLETTINSTAVALUE___: new fieldControlClass.CurrencyControl({
						modelField: 'ValValue',
						valueChangeEvent: 'fieldChange:insta.value',
						maxIntegers: 9,
						maxDecimals: 2,
						id: 'LEAFLETTINSTAVALUE___',
						name: 'VALUE',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.VALUE10285),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					LEAFLETTINSTACOORDGEO: new fieldControlClass.BaseControl({
						modelField: 'ValCoordgeo',
						valueChangeEvent: 'fieldChange:insta.coordgeo',
						isGeographicShape: false,
						isEuclideanCoord: false,
						id: 'LEAFLETTINSTACOORDGEO',
						name: 'COORDGEO',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.GEOGRAPHIC_COORDINAT42880),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_LEAFLETTINSTACOORDGEO',
						mustBeFilled: false,
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
					extraProperties: {}
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
// USE /[MANUAL GQT FORM_CODEJS LEAFLETT]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS LEAFLETT]/
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
// USE /[MANUAL GQT FORM_LOADED_JS LEAFLETT]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS LEAFLETT]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS LEAFLETT]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS LEAFLETT]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS LEAFLETT]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS LEAFLETT]/
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
// USE /[MANUAL GQT AFTER_DEL_JS LEAFLETT]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS LEAFLETT]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS LEAFLETT]/
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
// USE /[MANUAL GQT DLGUPDT LEAFLETT]/
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
// USE /[MANUAL GQT CTRLUPD LEAFLETT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
		},

		watch: {
		}
	}
</script>
