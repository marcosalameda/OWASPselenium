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
			data-key="TBLB"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.TBLB____TBLB_TEXT____.isVisible">
					<q-control-wrapper
						v-show="controls.TBLB____TBLB_TEXT____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.TBLB____TBLB_TEXT____"
							v-on="controls.TBLB____TBLB_TEXT____.handlers"
							:loading="controls.TBLB____TBLB_TEXT____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.TBLB____TBLB_TEXT____.props"
								@blur="onBlur(controls.TBLB____TBLB_TEXT____, model.ValText.value)"
								@change="model.ValText.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.TBLB____TBLB_TEXTML__.isVisible">
					<q-control-wrapper
						v-show="controls.TBLB____TBLB_TEXTML__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-textarea"
							v-bind="controls.TBLB____TBLB_TEXTML__"
							v-on="controls.TBLB____TBLB_TEXTML__.handlers"
							:loading="controls.TBLB____TBLB_TEXTML__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-area
								v-if="controls.TBLB____TBLB_TEXTML__.isVisible"
								v-bind="controls.TBLB____TBLB_TEXTML__.props"
								v-on="controls.TBLB____TBLB_TEXTML__.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.TBLB____TBLB_NUMINT__.isVisible">
					<q-control-wrapper
						v-show="controls.TBLB____TBLB_NUMINT__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.TBLB____TBLB_NUMINT__"
							v-on="controls.TBLB____TBLB_NUMINT__.handlers"
							:loading="controls.TBLB____TBLB_NUMINT__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.TBLB____TBLB_NUMINT__.isVisible"
								v-bind="controls.TBLB____TBLB_NUMINT__.props"
								@update:model-value="model.ValNumint.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.TBLB____TBLB_NUMDEC__.isVisible">
					<q-control-wrapper
						v-show="controls.TBLB____TBLB_NUMDEC__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.TBLB____TBLB_NUMDEC__"
							v-on="controls.TBLB____TBLB_NUMDEC__.handlers"
							:loading="controls.TBLB____TBLB_NUMDEC__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.TBLB____TBLB_NUMDEC__.isVisible"
								v-bind="controls.TBLB____TBLB_NUMDEC__.props"
								@update:model-value="model.ValNumdec.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.TBLB____TBLB_CURINT__.isVisible">
					<q-control-wrapper
						v-show="controls.TBLB____TBLB_CURINT__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.TBLB____TBLB_CURINT__"
							v-on="controls.TBLB____TBLB_CURINT__.handlers"
							:loading="controls.TBLB____TBLB_CURINT__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.TBLB____TBLB_CURINT__.isVisible"
								v-bind="controls.TBLB____TBLB_CURINT__.props"
								@update:model-value="model.ValCurint.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.TBLB____TBLB_CURDEC__.isVisible">
					<q-control-wrapper
						v-show="controls.TBLB____TBLB_CURDEC__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.TBLB____TBLB_CURDEC__"
							v-on="controls.TBLB____TBLB_CURDEC__.handlers"
							:loading="controls.TBLB____TBLB_CURDEC__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.TBLB____TBLB_CURDEC__.isVisible"
								v-bind="controls.TBLB____TBLB_CURDEC__.props"
								@update:model-value="model.ValCurdec.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.TBLB____TBLB_BOOL____.isVisible">
					<q-control-wrapper
						v-show="controls.TBLB____TBLB_BOOL____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.TBLB____TBLB_BOOL____"
							v-on="controls.TBLB____TBLB_BOOL____.handlers"
							:loading="controls.TBLB____TBLB_BOOL____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox-input
									v-if="controls.TBLB____TBLB_BOOL____.isVisible"
									v-bind="controls.TBLB____TBLB_BOOL____.props"
									v-on="controls.TBLB____TBLB_BOOL____.handlers" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.TBLB____TBLB_DATE____.isVisible">
					<q-control-wrapper
						v-show="controls.TBLB____TBLB_DATE____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.TBLB____TBLB_DATE____"
							v-on="controls.TBLB____TBLB_DATE____.handlers"
							:loading="controls.TBLB____TBLB_DATE____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.TBLB____TBLB_DATE____.isVisible"
								v-bind="controls.TBLB____TBLB_DATE____.props"
								:model-value="model.ValDate.value"
								@reset-icon-click="model.ValDate.fnUpdateValue(model.ValDate.originalValue ?? new Date())"
								@update:model-value="model.ValDate.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.TBLB____TBLB_DATETM__.isVisible">
					<q-control-wrapper
						v-show="controls.TBLB____TBLB_DATETM__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.TBLB____TBLB_DATETM__"
							v-on="controls.TBLB____TBLB_DATETM__.handlers"
							:loading="controls.TBLB____TBLB_DATETM__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.TBLB____TBLB_DATETM__.isVisible"
								v-bind="controls.TBLB____TBLB_DATETM__.props"
								:model-value="model.ValDatetm.value"
								@reset-icon-click="model.ValDatetm.fnUpdateValue(model.ValDatetm.originalValue ?? new Date())"
								@update:model-value="model.ValDatetm.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.TBLB____TBLB_DATETS__.isVisible">
					<q-control-wrapper
						v-show="controls.TBLB____TBLB_DATETS__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.TBLB____TBLB_DATETS__"
							v-on="controls.TBLB____TBLB_DATETS__.handlers"
							:loading="controls.TBLB____TBLB_DATETS__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.TBLB____TBLB_DATETS__.isVisible"
								v-bind="controls.TBLB____TBLB_DATETS__.props"
								:model-value="model.ValDatets.value"
								@reset-icon-click="model.ValDatets.fnUpdateValue(model.ValDatets.originalValue ?? new Date())"
								@update:model-value="model.ValDatets.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.TBLB____TBLB_TIMEHM__.isVisible">
					<q-control-wrapper
						v-show="controls.TBLB____TBLB_TIMEHM__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.TBLB____TBLB_TIMEHM__"
							v-on="controls.TBLB____TBLB_TIMEHM__.handlers"
							:loading="controls.TBLB____TBLB_TIMEHM__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.TBLB____TBLB_TIMEHM__.isVisible"
								v-bind="controls.TBLB____TBLB_TIMEHM__.props"
								:model-value="model.ValTimehm.value"
								@reset-icon-click="model.ValTimehm.fnUpdateValue(model.ValTimehm.originalValue ?? new Date())"
								@update:model-value="model.ValTimehm.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.TBLB____TBLB_ENUMT___.isVisible">
					<q-control-wrapper
						v-show="controls.TBLB____TBLB_ENUMT___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.TBLB____TBLB_ENUMT___"
							v-on="controls.TBLB____TBLB_ENUMT___.handlers"
							:loading="controls.TBLB____TBLB_ENUMT___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-select
								v-if="controls.TBLB____TBLB_ENUMT___.isVisible"
								v-bind="controls.TBLB____TBLB_ENUMT___.props"
								@update:model-value="model.ValEnumt.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.TBLB____TBLB_ENUMN___.isVisible">
					<q-control-wrapper
						v-show="controls.TBLB____TBLB_ENUMN___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.TBLB____TBLB_ENUMN___"
							v-on="controls.TBLB____TBLB_ENUMN___.handlers"
							:loading="controls.TBLB____TBLB_ENUMN___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-select
								v-if="controls.TBLB____TBLB_ENUMN___.isVisible"
								v-bind="controls.TBLB____TBLB_ENUMN___.props"
								@update:model-value="model.ValEnumn.fnUpdateValue" />
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

	import FormViewModel from './QFormTblbViewModel.js'

	const requiredTextResources = ['QFormTblb', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS TBLB]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormTblb',

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
					name: 'TBLB',
					location: 'form-TBLB',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormTblb', false),

				interfaceMetadata: {
					id: 'QFormTblb', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'TBLB',
					route: 'form-TBLB',
					area: 'TBLB',
					primaryKey: 'ValCodtblb',
					designation: computed(() => this.Resources.TABLE__BASIC_TYPES_42027),
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
					TBLB____TBLB_TEXT____: new fieldControlClass.StringControl({
						modelField: 'ValText',
						valueChangeEvent: 'fieldChange:tblb.text',
						id: 'TBLB____TBLB_TEXT____',
						name: 'TEXT',
						size: 'xlarge',
						label: computed(() => this.Resources.TEXT04938),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_TBLB____TBLB_TEXT____',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					TBLB____TBLB_TEXTML__: new fieldControlClass.MultilineStringControl({
						modelField: 'ValTextml',
						valueChangeEvent: 'fieldChange:tblb.textml',
						id: 'TBLB____TBLB_TEXTML__',
						name: 'TEXTML',
						size: 'xlarge',
						label: computed(() => this.Resources.MULTILINE_TEXT38013),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						rows: 1,
						cols: 50,
						controlLimits: [
						],
					}, this),
					TBLB____TBLB_NUMINT__: new fieldControlClass.NumberControl({
						modelField: 'ValNumint',
						valueChangeEvent: 'fieldChange:tblb.numint',
						id: 'TBLB____TBLB_NUMINT__',
						name: 'NUMINT',
						size: 'small',
						label: computed(() => this.Resources.NUMERIC__INTEGER_50289),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 10,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					TBLB____TBLB_NUMDEC__: new fieldControlClass.NumberControl({
						modelField: 'ValNumdec',
						valueChangeEvent: 'fieldChange:tblb.numdec',
						id: 'TBLB____TBLB_NUMDEC__',
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
					TBLB____TBLB_CURINT__: new fieldControlClass.CurrencyControl({
						modelField: 'ValCurint',
						valueChangeEvent: 'fieldChange:tblb.curint',
						id: 'TBLB____TBLB_CURINT__',
						name: 'CURINT',
						size: 'medium',
						label: computed(() => this.Resources.CURRENCY__INTERGER_21437),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 7,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					TBLB____TBLB_CURDEC__: new fieldControlClass.CurrencyControl({
						modelField: 'ValCurdec',
						valueChangeEvent: 'fieldChange:tblb.curdec',
						id: 'TBLB____TBLB_CURDEC__',
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
					TBLB____TBLB_BOOL____: new fieldControlClass.BooleanControl({
						modelField: 'ValBool',
						valueChangeEvent: 'fieldChange:tblb.bool',
						id: 'TBLB____TBLB_BOOL____',
						name: 'BOOL',
						size: 'small',
						label: computed(() => this.Resources.BOOLEAN45002),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						controlLimits: [
						],
					}, this),
					TBLB____TBLB_DATE____: new fieldControlClass.DateControl({
						modelField: 'ValDate',
						valueChangeEvent: 'fieldChange:tblb.date',
						id: 'TBLB____TBLB_DATE____',
						name: 'DATE',
						size: 'small',
						label: computed(() => this.Resources.DATE18475),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					TBLB____TBLB_DATETM__: new fieldControlClass.DateControl({
						modelField: 'ValDatetm',
						valueChangeEvent: 'fieldChange:tblb.datetm',
						id: 'TBLB____TBLB_DATETM__',
						name: 'DATETM',
						size: 'medium',
						label: computed(() => this.Resources.DATETIME__MINUTES_59352),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'dateTime',
						controlLimits: [
						],
					}, this),
					TBLB____TBLB_DATETS__: new fieldControlClass.DateControl({
						modelField: 'ValDatets',
						valueChangeEvent: 'fieldChange:tblb.datets',
						id: 'TBLB____TBLB_DATETS__',
						name: 'DATETS',
						size: 'medium',
						label: computed(() => this.Resources.DATETIME__SECONDS_49861),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'dateTimeSeconds',
						controlLimits: [
						],
					}, this),
					TBLB____TBLB_TIMEHM__: new fieldControlClass.TimeControl({
						modelField: 'ValTimehm',
						valueChangeEvent: 'fieldChange:tblb.timehm',
						id: 'TBLB____TBLB_TIMEHM__',
						name: 'TIMEHM',
						size: 'mini',
						label: computed(() => this.Resources.TIME__HOURS_MINUTES_01660),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'time',
						controlLimits: [
						],
					}, this),
					TBLB____TBLB_ENUMT___: new fieldControlClass.ArrayStringControl({
						modelField: 'ValEnumt',
						valueChangeEvent: 'fieldChange:tblb.enumt',
						id: 'TBLB____TBLB_ENUMT___',
						name: 'ENUMT',
						size: 'medium',
						label: computed(() => this.Resources.ENUMERATION__TEXT_15855),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 1,
						labelId: 'label_TBLB____TBLB_ENUMT___',
						arrayName: 'typet',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					TBLB____TBLB_ENUMN___: new fieldControlClass.ArrayNumberControl({
						modelField: 'ValEnumn',
						valueChangeEvent: 'fieldChange:tblb.enumn',
						id: 'TBLB____TBLB_ENUMN___',
						name: 'ENUMN',
						size: 'medium',
						label: computed(() => this.Resources.ENUMERATION__NUMERIC44708),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 1,
						maxDecimals: 0,
						arrayName: 'typen',
						helpShortItem: '',
						helpDetailedItem: '',
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
// USE /[MANUAL GQT FORM_CODEJS TBLB]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT TBLB]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS TBLB]/
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
// USE /[MANUAL GQT FORM_LOADED_JS TBLB]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS TBLB]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS TBLB]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS TBLB]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS TBLB]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS TBLB]/
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
// USE /[MANUAL GQT AFTER_DEL_JS TBLB]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS TBLB]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS TBLB]/
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
// USE /[MANUAL GQT DLGUPDT TBLB]/
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
// USE /[MANUAL GQT CTRLBLR TBLB]/
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
// USE /[MANUAL GQT CTRLUPD TBLB]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS TBLB]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
