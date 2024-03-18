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
			data-key="FACIL"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.FACIL___ENTITNAME____.isVisible">
					<q-control-wrapper
						v-show="controls.FACIL___ENTITNAME____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACIL___ENTITNAME____"
							v-on="controls.FACIL___ENTITNAME____.handlers"
							:loading="controls.FACIL___ENTITNAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-lookup
								v-if="controls.FACIL___ENTITNAME____.isVisible"
								v-bind="controls.FACIL___ENTITNAME____.props"
								:model-value="model.ValCodentit.value"
								v-on="controls.FACIL___ENTITNAME____.handlers"
								@update:model-value="model.ValCodentit.fnUpdateValue" />
							<q-see-more-facil-entitname
								v-if="controls.FACIL___ENTITNAME____.seeMoreIsVisible"
								v-bind="controls.FACIL___ENTITNAME____.seeMoreParams"
								v-on="controls.FACIL___ENTITNAME____.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.FACIL___FACILINCORPOR.isVisible">
					<q-control-wrapper
						v-show="controls.FACIL___FACILINCORPOR.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACIL___FACILINCORPOR"
							v-on="controls.FACIL___FACILINCORPOR.handlers"
							:loading="controls.FACIL___FACILINCORPOR.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-datetime-input
								v-if="controls.FACIL___FACILINCORPOR.isVisible"
								v-bind="controls.FACIL___FACILINCORPOR"
								format="Date"
								:model-value="model.ValIncorpor.value"
								@update:model-value="model.ValIncorpor.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.FACIL___FACILNAME____.isVisible">
					<q-control-wrapper
						v-show="controls.FACIL___FACILNAME____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACIL___FACILNAME____"
							v-on="controls.FACIL___FACILNAME____.handlers"
							:loading="controls.FACIL___FACILNAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.FACIL___FACILNAME____.props"
								:model-value="model.ValName.value"
								@update:model-value="model.ValName.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.FACIL___FACILFACILTYP.isVisible || controls.FACIL___FACTYTYPE____.isVisible || controls.FACIL___FACILADDRESS_.isVisible">
					<q-control-wrapper
						v-show="controls.FACIL___FACILFACILTYP.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACIL___FACILFACILTYP"
							v-on="controls.FACIL___FACILFACILTYP.handlers"
							:loading="controls.FACIL___FACILFACILTYP.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-select
								v-if="controls.FACIL___FACILFACILTYP.isVisible"
								v-bind="controls.FACIL___FACILFACILTYP.props"
								:model-value="model.ValFaciltyp.value"
								@update:model-value="model.ValFaciltyp.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FACIL___FACTYTYPE____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACIL___FACTYTYPE____"
							v-on="controls.FACIL___FACTYTYPE____.handlers"
							:loading="controls.FACIL___FACTYTYPE____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-lookup
								v-if="controls.FACIL___FACTYTYPE____.isVisible"
								v-bind="controls.FACIL___FACTYTYPE____.props"
								:model-value="model.ValCodfacty.value"
								v-on="controls.FACIL___FACTYTYPE____.handlers"
								@update:model-value="model.ValCodfacty.fnUpdateValue" />
							<q-see-more-facil-factytype
								v-if="controls.FACIL___FACTYTYPE____.seeMoreIsVisible"
								v-bind="controls.FACIL___FACTYTYPE____.seeMoreParams"
								v-on="controls.FACIL___FACTYTYPE____.handlers" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FACIL___FACILADDRESS_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-textarea"
							v-bind="controls.FACIL___FACILADDRESS_"
							v-on="controls.FACIL___FACILADDRESS_.handlers"
							:loading="controls.FACIL___FACILADDRESS_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-textarea-input
								v-if="controls.FACIL___FACILADDRESS_.isVisible"
								id="FACIL___FACILADDRESS_"
								size="xxlarge"
								:model-value="model.ValAddress.value"
								:rows="5"
								:cols="75"
								:is-required="controls.FACIL___FACILADDRESS_.isRequired"
								:readonly="controls.FACIL___FACILADDRESS_.readonly"
								:placeholder="controls.FACIL___FACILADDRESS_.placeholder"
								@update:model-value="model.ValAddress.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.FACIL___FACILIMAGE___.isVisible">
					<q-control-wrapper
						v-show="controls.FACIL___FACILIMAGE___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="q-image"
							v-bind="controls.FACIL___FACILIMAGE___"
							v-on="controls.FACIL___FACILIMAGE___.handlers"
							:loading="controls.FACIL___FACILIMAGE___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-image
								v-if="controls.FACIL___FACILIMAGE___.isVisible"
								v-bind="controls.FACIL___FACILIMAGE___.props"
								v-on="controls.FACIL___FACILIMAGE___.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.FACIL___FACILGPSINPUT.isVisible">
					<q-control-wrapper
						v-show="controls.FACIL___FACILGPSINPUT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-radio-container"
							v-bind="controls.FACIL___FACILGPSINPUT"
							v-on="controls.FACIL___FACILGPSINPUT.handlers"
							:label-position="labelAlignment.topleft"
							:loading="controls.FACIL___FACILGPSINPUT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-radio-button-input
								v-if="controls.FACIL___FACILGPSINPUT.isVisible"
								id="FACIL___FACILGPSINPUT"
								:model-value="model.ValGpsinput.value"
								deselect-radio
								:label-left-side="controls.FACIL___FACILGPSINPUT.labelPosition === labelAlignment.left"
								:number-of-columns="controls.FACIL___FACILGPSINPUT.columnNumber"
								:is-required="controls.FACIL___FACILGPSINPUT.isRequired"
								:readonly="controls.FACIL___FACILGPSINPUT.readonly"
								:options-list="controls.FACIL___FACILGPSINPUT.items"
								@update:model-value="model.ValGpsinput.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.FACIL___FACILLATITUDE.isVisible || controls.FACIL___FACILLONGITUD.isVisible">
					<q-control-wrapper
						v-show="controls.FACIL___FACILLATITUDE.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACIL___FACILLATITUDE"
							v-on="controls.FACIL___FACILLATITUDE.handlers"
							:loading="controls.FACIL___FACILLATITUDE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-numeric-input
								v-if="controls.FACIL___FACILLATITUDE.isVisible"
								v-bind="controls.FACIL___FACILLATITUDE"
								:model-value="model.ValLatitude.value"
								@update:model-value="model.ValLatitude.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FACIL___FACILLONGITUD.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACIL___FACILLONGITUD"
							v-on="controls.FACIL___FACILLONGITUD.handlers"
							:loading="controls.FACIL___FACILLONGITUD.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-numeric-input
								v-if="controls.FACIL___FACILLONGITUD.isVisible"
								v-bind="controls.FACIL___FACILLONGITUD"
								:model-value="model.ValLongitud.value"
								@update:model-value="model.ValLongitud.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.FACIL___FACILGEOCOORI.isVisible">
					<q-control-wrapper
						v-show="controls.FACIL___FACILGEOCOORI.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.FACIL___FACILGEOCOORI"
							v-on="controls.FACIL___FACILGEOCOORI.handlers"
							:loading="controls.FACIL___FACILGEOCOORI.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.FACIL___FACILGEOCOORI.props"
								:model-value="model.ValGeocoori.value"
								@update:model-value="model.ValGeocoori.fnUpdateValue" />
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

	import FormViewModel from './QFormFacilViewModel.js'

	const requiredTextResources = ['QFormFacil', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS FACIL]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormFacil',

		components: {
			QSeeMoreFacilEntitname: defineAsyncComponent(() => import('@/views/forms/FormFacil/dbedits/FacilEntitnameSeeMore.vue')),
			QSeeMoreFacilFactytype: defineAsyncComponent(() => import('@/views/forms/FormFacil/dbedits/FacilFactytypeSeeMore.vue')),
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
						name: 'FACIL',
						location: 'form-FACIL',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormFacil', false),

				interfaceMetadata: {
					id: 'QFormFacil', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'FACIL',
					route: 'form-FACIL',
					area: 'FACIL',
					primaryKey: 'ValCodfacil',
					designation: computed(() => this.Resources.FACILITY55206),
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
					FACIL___ENTITNAME____: new fieldControlClass.LookupControl({
						modelField: 'TableEntitName',
						valueChangeEvent: 'fieldChange:entit.name',
						id: 'FACIL___ENTITNAME____',
						name: 'NAME',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.LEGAL_NAME42902),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodentit',
							dependencyEvent: 'fieldChange:facil.codentit'
						},
						dependentFields: () => {
							return {
								set 'entit.codentit'(value) { vm.model.ValCodentit.updateValue(value) },
								set 'entit.name'(value) { vm.model.TableEntitName.updateValue(value) },
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
					FACIL___FACILINCORPOR: new fieldControlClass.DateControl({
						modelField: 'ValIncorpor',
						valueChangeEvent: 'fieldChange:facil.incorpor',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'FACIL___FACILINCORPOR',
						name: 'INCORPOR',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.INCORPORATION10135),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FACIL___FACILNAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:facil.name',
						id: 'FACIL___FACILNAME____',
						name: 'NAME',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.FACILITY_NAME19514),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						labelId: 'label_FACIL___FACILNAME____',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FACIL___FACILFACILTYP: new fieldControlClass.ArrayStringControl({
						modelField: 'ValFaciltyp',
						valueChangeEvent: 'fieldChange:facil.faciltyp',
						id: 'FACIL___FACILFACILTYP',
						name: 'FACILTYP',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.FACILITY_TYPE44577),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 1,
						labelId: 'label_FACIL___FACILFACILTYP',
						arrayName: 'FacilTyp',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FACIL___FACTYTYPE____: new fieldControlClass.LookupControl({
						modelField: 'TableFactyType',
						valueChangeEvent: 'fieldChange:facty.type',
						id: 'FACIL___FACTYTYPE____',
						name: 'TYPE',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.FACILITY_TYPE44577),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodfacty',
							dependencyEvent: 'fieldChange:facil.codfacty'
						},
						dependentFields: () => {
							return {
								set 'facty.codfacty'(value) { vm.model.ValCodfacty.updateValue(value) },
								set 'facty.type'(value) { vm.model.TableFactyType.updateValue(value) },
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
					FACIL___FACILADDRESS_: new fieldControlClass.StringControl({
						modelField: 'ValAddress',
						valueChangeEvent: 'fieldChange:facil.address',
						id: 'FACIL___FACILADDRESS_',
						name: 'ADDRESS',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.ADDRESS04342),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						labelId: 'label_FACIL___FACILADDRESS_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FACIL___FACILIMAGE___: new fieldControlClass.ImageControl({
						modelField: 'ValImage',
						valueChangeEvent: 'fieldChange:facil.image',
						id: 'FACIL___FACILIMAGE___',
						name: 'IMAGE',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.IMAGE65174),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						height: 300,
						width: 400,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FACIL___FACILGPSINPUT: new fieldControlClass.ArrayStringControl({
						modelField: 'ValGpsinput',
						valueChangeEvent: 'fieldChange:facil.gpsinput',
						id: 'FACIL___FACILGPSINPUT',
						name: 'GPSINPUT',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.GPS_INPUT13625),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 1,
						labelId: 'label_FACIL___FACILGPSINPUT',
						arrayName: 'GpsInput',
						columnNumber: 1,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FACIL___FACILLATITUDE: new fieldControlClass.NumberControl({
						modelField: 'ValLatitude',
						valueChangeEvent: 'fieldChange:facil.latitude',
						maxIntegers: 3,
						maxDecimals: 6,
						id: 'FACIL___FACILLATITUDE',
						name: 'LATITUDE',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.LATITUDE11291),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: [FACIL->GPSINPUT]=="L"
								// eslint-disable-next-line eqeqeq
								return this.ValGpsinput.value=="L"
							},
							dependencyEvents: ['fieldChange:facil.gpsinput'],
							isServerRecalc: false,
							isServerFormula: false,
						},
					}, this),
					FACIL___FACILLONGITUD: new fieldControlClass.NumberControl({
						modelField: 'ValLongitud',
						valueChangeEvent: 'fieldChange:facil.longitud',
						maxIntegers: 3,
						maxDecimals: 6,
						id: 'FACIL___FACILLONGITUD',
						name: 'LONGITUD',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.LONGITUDE01015),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: [FACIL->GPSINPUT]=="L"
								// eslint-disable-next-line eqeqeq
								return this.ValGpsinput.value=="L"
							},
							dependencyEvents: ['fieldChange:facil.gpsinput'],
							isServerRecalc: false,
							isServerFormula: false,
						},
					}, this),
					FACIL___FACILGEOCOORI: new fieldControlClass.BaseControl({
						modelField: 'ValGeocoori',
						valueChangeEvent: 'fieldChange:facil.geocoori',
						isGeographicShape: false,
						isEuclideanCoord: false,
						id: 'FACIL___FACILGEOCOORI',
						name: 'GEOCOORI',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.GEOGRAPHICAL_COORDIN45869),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_FACIL___FACILGEOCOORI',
						mustBeFilled: false,
						controlLimits: [
						],
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: [FACIL->GPSINPUT]=="P"
								// eslint-disable-next-line eqeqeq
								return this.ValGpsinput.value=="P"
							},
							dependencyEvents: ['fieldChange:facil.gpsinput'],
							isServerRecalc: false,
							isServerFormula: false,
						},
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
					Entit: {
						get ValName() { return vm.model.TableEntitName.value },
						set ValName(value) { vm.model.TableEntitName.updateValue(value) },
					},
					Facil: {
						get ValAddress() { return vm.model.ValAddress.value },
						set ValAddress(value) { vm.model.ValAddress.updateValue(value) },
						get ValCodentit() { return vm.model.ValCodentit.value },
						set ValCodentit(value) { vm.model.ValCodentit.updateValue(value) },
						get ValCodfacty() { return vm.model.ValCodfacty.value },
						set ValCodfacty(value) { vm.model.ValCodfacty.updateValue(value) },
						get ValFaciltyp() { return vm.model.ValFaciltyp.value },
						set ValFaciltyp(value) { vm.model.ValFaciltyp.updateValue(value) },
						get ValGeocoori() { return vm.model.ValGeocoori.value },
						set ValGeocoori(value) { vm.model.ValGeocoori.updateValue(value) },
						get ValGpsinput() { return vm.model.ValGpsinput.value },
						set ValGpsinput(value) { vm.model.ValGpsinput.updateValue(value) },
						get ValImage() { return vm.model.ValImage.value },
						set ValImage(value) { vm.model.ValImage.updateValue(value) },
						get ValIncorpor() { return vm.model.ValIncorpor.value },
						set ValIncorpor(value) { vm.model.ValIncorpor.updateValue(value) },
						get ValLatitude() { return vm.model.ValLatitude.value },
						set ValLatitude(value) { vm.model.ValLatitude.updateValue(value) },
						get ValLongitud() { return vm.model.ValLongitud.value },
						set ValLongitud(value) { vm.model.ValLongitud.updateValue(value) },
						get ValName() { return vm.model.ValName.value },
						set ValName(value) { vm.model.ValName.updateValue(value) },
					},
					Facty: {
						get ValType() { return vm.model.TableFactyType.value },
						set ValType(value) { vm.model.TableFactyType.updateValue(value) },
					},
					keys: {
						/** The primary key of the FACIL table */
						get facil() { return vm.model.ValCodfacil },
						/** The foreign key to the ENTIT table */
						get entit() { return vm.model.ValCodentit },
						/** The foreign key to the FACTY table */
						get facty() { return vm.model.ValCodfacty },
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
// USE /[MANUAL GQT FORM_CODEJS FACIL]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS FACIL]/
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
// USE /[MANUAL GQT FORM_LOADED_JS FACIL]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS FACIL]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS FACIL]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS FACIL]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS FACIL]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS FACIL]/
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
// USE /[MANUAL GQT AFTER_DEL_JS FACIL]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS FACIL]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS FACIL]/
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
// USE /[MANUAL GQT DLGUPDT FACIL]/
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
// USE /[MANUAL GQT CTRLUPD FACIL]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
		},

		watch: {
		}
	}
</script>
