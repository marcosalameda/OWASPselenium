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
			data-key="ITEM"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.ITEM____GITEMITEMDES_.isVisible || controls.ITEM____WAREHWAREHDES.isVisible || controls.ITEM____ITEM_ITEMTYPE.isVisible || controls.ITEM____ITEM_ITEMDES_.isVisible || controls.ITEM____ITEM_ITEMCOD_.isVisible || controls.ITEM____ITEM_ENTRIES_.isVisible || controls.ITEM____ITEM_EXITS___.isVisible || controls.ITEM____ITEM_EXISTENC.isVisible || controls.ITEM____ITEM_IMAGE___.isVisible || controls.ITEM____ITEM_CATEGORY.isVisible || controls.ITEM____ITEM_VALID___.isVisible || controls.ITEM____ITEM_DISPONIB.isVisible || controls.ITEM____ITEM_DATE____.isVisible || controls.ITEM____ITEM_TECHSPEC.isVisible">
					<q-control-wrapper
						v-show="controls.ITEM____GITEMITEMDES_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ITEM____GITEMITEMDES_"
							v-on="controls.ITEM____GITEMITEMDES_.handlers"
							:loading="controls.ITEM____GITEMITEMDES_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.ITEM____GITEMITEMDES_.isVisible"
								v-bind="controls.ITEM____GITEMITEMDES_.props"
								v-on="controls.ITEM____GITEMITEMDES_.handlers" />
							<q-see-more-item-gitemitemdes
								v-if="controls.ITEM____GITEMITEMDES_.seeMoreIsVisible"
								v-bind="controls.ITEM____GITEMITEMDES_.seeMoreParams"
								v-on="controls.ITEM____GITEMITEMDES_.handlers" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ITEM____WAREHWAREHDES.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ITEM____WAREHWAREHDES"
							v-on="controls.ITEM____WAREHWAREHDES.handlers"
							:loading="controls.ITEM____WAREHWAREHDES.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.ITEM____WAREHWAREHDES.isVisible"
								v-bind="controls.ITEM____WAREHWAREHDES.props"
								v-on="controls.ITEM____WAREHWAREHDES.handlers" />
							<q-see-more-item-warehwarehdes
								v-if="controls.ITEM____WAREHWAREHDES.seeMoreIsVisible"
								v-bind="controls.ITEM____WAREHWAREHDES.seeMoreParams"
								v-on="controls.ITEM____WAREHWAREHDES.handlers" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ITEM____ITEM_ITEMTYPE.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ITEM____ITEM_ITEMTYPE"
							v-on="controls.ITEM____ITEM_ITEMTYPE.handlers"
							:loading="controls.ITEM____ITEM_ITEMTYPE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-select
								v-if="controls.ITEM____ITEM_ITEMTYPE.isVisible"
								v-bind="controls.ITEM____ITEM_ITEMTYPE.props"
								@update:model-value="model.ValItemtype.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ITEM____ITEM_ITEMDES_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ITEM____ITEM_ITEMDES_"
							v-on="controls.ITEM____ITEM_ITEMDES_.handlers"
							:loading="controls.ITEM____ITEM_ITEMDES_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.ITEM____ITEM_ITEMDES_.props"
								@blur="onBlur(controls.ITEM____ITEM_ITEMDES_, model.ValItemdes.value)"
								@change="model.ValItemdes.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ITEM____ITEM_ITEMCOD_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ITEM____ITEM_ITEMCOD_"
							v-on="controls.ITEM____ITEM_ITEMCOD_.handlers"
							:loading="controls.ITEM____ITEM_ITEMCOD_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.ITEM____ITEM_ITEMCOD_.props"
								@blur="onBlur(controls.ITEM____ITEM_ITEMCOD_, model.ValItemcod.value)"
								@change="model.ValItemcod.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ITEM____ITEM_ENTRIES_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ITEM____ITEM_ENTRIES_"
							v-on="controls.ITEM____ITEM_ENTRIES_.handlers"
							:loading="controls.ITEM____ITEM_ENTRIES_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.ITEM____ITEM_ENTRIES_.isVisible"
								v-bind="controls.ITEM____ITEM_ENTRIES_.props"
								@update:model-value="model.ValEntries.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ITEM____ITEM_EXITS___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ITEM____ITEM_EXITS___"
							v-on="controls.ITEM____ITEM_EXITS___.handlers"
							:loading="controls.ITEM____ITEM_EXITS___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.ITEM____ITEM_EXITS___.isVisible"
								v-bind="controls.ITEM____ITEM_EXITS___.props"
								@update:model-value="model.ValExits.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ITEM____ITEM_EXISTENC.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ITEM____ITEM_EXISTENC"
							v-on="controls.ITEM____ITEM_EXISTENC.handlers"
							:loading="controls.ITEM____ITEM_EXISTENC.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.ITEM____ITEM_EXISTENC.isVisible"
								v-bind="controls.ITEM____ITEM_EXISTENC.props"
								@update:model-value="model.ValExistenc.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ITEM____ITEM_IMAGE___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="q-image"
							v-bind="controls.ITEM____ITEM_IMAGE___"
							v-on="controls.ITEM____ITEM_IMAGE___.handlers"
							:loading="controls.ITEM____ITEM_IMAGE___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-image
								v-if="controls.ITEM____ITEM_IMAGE___.isVisible"
								v-bind="controls.ITEM____ITEM_IMAGE___.props"
								v-on="controls.ITEM____ITEM_IMAGE___.handlers" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ITEM____ITEM_CATEGORY.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-textarea"
							v-bind="controls.ITEM____ITEM_CATEGORY"
							v-on="controls.ITEM____ITEM_CATEGORY.handlers"
							:loading="controls.ITEM____ITEM_CATEGORY.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-area
								v-if="controls.ITEM____ITEM_CATEGORY.isVisible"
								v-bind="controls.ITEM____ITEM_CATEGORY.props"
								v-on="controls.ITEM____ITEM_CATEGORY.handlers" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ITEM____ITEM_VALID___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.ITEM____ITEM_VALID___"
							v-on="controls.ITEM____ITEM_VALID___.handlers"
							:loading="controls.ITEM____ITEM_VALID___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox-input
									v-if="controls.ITEM____ITEM_VALID___.isVisible"
									v-bind="controls.ITEM____ITEM_VALID___.props"
									v-on="controls.ITEM____ITEM_VALID___.handlers" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ITEM____ITEM_DISPONIB.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ITEM____ITEM_DISPONIB"
							v-on="controls.ITEM____ITEM_DISPONIB.handlers"
							:loading="controls.ITEM____ITEM_DISPONIB.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-select
								v-if="controls.ITEM____ITEM_DISPONIB.isVisible"
								v-bind="controls.ITEM____ITEM_DISPONIB.props" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ITEM____ITEM_DATE____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ITEM____ITEM_DATE____"
							v-on="controls.ITEM____ITEM_DATE____.handlers"
							:loading="controls.ITEM____ITEM_DATE____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.ITEM____ITEM_DATE____.isVisible"
								v-bind="controls.ITEM____ITEM_DATE____.props"
								:model-value="model.ValDate.value"
								@reset-icon-click="model.ValDate.fnUpdateValue(model.ValDate.originalValue ?? new Date())"
								@update:model-value="model.ValDate.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ITEM____ITEM_TECHSPEC.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ITEM____ITEM_TECHSPEC"
							v-on="controls.ITEM____ITEM_TECHSPEC.handlers"
							:loading="controls.ITEM____ITEM_TECHSPEC.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-document
								v-if="controls.ITEM____ITEM_TECHSPEC.isVisible"
								v-bind="controls.ITEM____ITEM_TECHSPEC.props"
								v-on="controls.ITEM____ITEM_TECHSPEC.handlers" />
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

	import FormViewModel from './QFormItemViewModel.js'

	const requiredTextResources = ['QFormItem', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS ITEM]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormItem',

		components: {
			QSeeMoreItemGitemitemdes: defineAsyncComponent(() => import('@/views/forms/FormItem/dbedits/ItemGitemitemdesSeeMore.vue')),
			QSeeMoreItemWarehwarehdes: defineAsyncComponent(() => import('@/views/forms/FormItem/dbedits/ItemWarehwarehdesSeeMore.vue')),
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
					name: 'ITEM',
					location: 'form-ITEM',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormItem', false),

				interfaceMetadata: {
					id: 'QFormItem', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'ITEM',
					route: 'form-ITEM',
					area: 'ITEM',
					primaryKey: 'ValCoditem',
					designation: computed(() => this.Resources.ARTICLES59822),
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
					ITEM____GITEMITEMDES_: new fieldControlClass.LookupControl({
						modelField: 'TableGitemItemdes',
						valueChangeEvent: 'fieldChange:gitem.itemdes',
						id: 'ITEM____GITEMITEMDES_',
						name: 'ITEMDES',
						size: 'xxlarge',
						label: computed(() => this.Resources.GLOBAL_ARTICLE63861),
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
							name: 'ValCodgitem',
							dependencyEvent: 'fieldChange:item.codgitem'
						},
						dependentFields: () => ({
							set 'gitem.codgitem'(value) { vm.model.ValCodgitem.updateValue(value) },
							set 'gitem.itemdes'(value) { vm.model.TableGitemItemdes.updateValue(value) },
							set 'gitem.itemgcod'(value) { vm.model.GitemValItemgcod.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					ITEM____WAREHWAREHDES: new fieldControlClass.LookupControl({
						modelField: 'TableWarehWarehdes',
						valueChangeEvent: 'fieldChange:wareh.warehdes',
						id: 'ITEM____WAREHWAREHDES',
						name: 'WAREHDES',
						size: 'xxlarge',
						label: computed(() => this.Resources.WAREHOUSE51864),
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
							name: 'ValCodwareh',
							dependencyEvent: 'fieldChange:item.codwareh'
						},
						dependentFields: () => ({
							set 'wareh.codwareh'(value) { vm.model.ValCodwareh.updateValue(value) },
							set 'wareh.warehdes'(value) { vm.model.TableWarehWarehdes.updateValue(value) },
						}),
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					ITEM____ITEM_ITEMTYPE: new fieldControlClass.ArrayStringControl({
						modelField: 'ValItemtype',
						valueChangeEvent: 'fieldChange:item.itemtype',
						id: 'ITEM____ITEM_ITEMTYPE',
						name: 'ITEMTYPE',
						size: 'mini',
						label: computed(() => this.Resources.TYPE00312),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 1,
						labelId: 'label_ITEM____ITEM_ITEMTYPE',
						arrayName: 'TipoArti',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					ITEM____ITEM_ITEMDES_: new fieldControlClass.StringControl({
						modelField: 'ValItemdes',
						valueChangeEvent: 'fieldChange:item.itemdes',
						id: 'ITEM____ITEM_ITEMDES_',
						name: 'ITEMDES',
						size: 'xxlarge',
						label: computed(() => this.Resources.ARTICLE60065),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						labelId: 'label_ITEM____ITEM_ITEMDES_',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					ITEM____ITEM_ITEMCOD_: new fieldControlClass.StringControl({
						modelField: 'ValItemcod',
						valueChangeEvent: 'fieldChange:item.itemcod',
						id: 'ITEM____ITEM_ITEMCOD_',
						name: 'ITEMCOD',
						size: 'medium',
						label: computed(() => this.Resources.CODE49225),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 15,
						labelId: 'label_ITEM____ITEM_ITEMCOD_',
						controlLimits: [
						],
					}, this),
					ITEM____ITEM_ENTRIES_: new fieldControlClass.NumberControl({
						modelField: 'ValEntries',
						valueChangeEvent: 'fieldChange:item.entries',
						id: 'ITEM____ITEM_ENTRIES_',
						name: 'ENTRIES',
						size: 'small',
						label: computed(() => this.Resources.ENTRIES32319),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						maxIntegers: 10,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					ITEM____ITEM_EXITS___: new fieldControlClass.NumberControl({
						modelField: 'ValExits',
						valueChangeEvent: 'fieldChange:item.exits',
						id: 'ITEM____ITEM_EXITS___',
						name: 'EXITS',
						size: 'small',
						label: computed(() => this.Resources.OUTPUTS47833),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						maxIntegers: 10,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					ITEM____ITEM_EXISTENC: new fieldControlClass.NumberControl({
						modelField: 'ValExistenc',
						valueChangeEvent: 'fieldChange:item.existenc',
						id: 'ITEM____ITEM_EXISTENC',
						name: 'EXISTENC',
						size: 'small',
						label: computed(() => this.Resources.STOCKS47349),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						maxIntegers: 10,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					ITEM____ITEM_IMAGE___: new fieldControlClass.ImageControl({
						modelField: 'ValImage',
						valueChangeEvent: 'fieldChange:item.image',
						id: 'ITEM____ITEM_IMAGE___',
						name: 'IMAGE',
						size: 'mini',
						label: computed(() => this.Resources.IMAGE65174),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						height: 10,
						width: 480,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.IMAGE65174)),
						controlLimits: [
						],
					}, this),
					ITEM____ITEM_CATEGORY: new fieldControlClass.MultilineStringControl({
						modelField: 'ValCategory',
						valueChangeEvent: 'fieldChange:item.category',
						id: 'ITEM____ITEM_CATEGORY',
						name: 'CATEGORY',
						size: 'xxlarge',
						label: computed(() => this.Resources.CATEGORIZATION17554),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						rows: 2,
						cols: 85,
						controlLimits: [
						],
					}, this),
					ITEM____ITEM_VALID___: new fieldControlClass.BooleanControl({
						modelField: 'ValValid',
						valueChangeEvent: 'fieldChange:item.valid',
						id: 'ITEM____ITEM_VALID___',
						name: 'VALID',
						size: 'mini',
						label: computed(() => this.Resources.IN_USE42606),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						controlLimits: [
						],
					}, this),
					ITEM____ITEM_DISPONIB: new fieldControlClass.ArrayStringControl({
						modelField: 'ValDisponib',
						valueChangeEvent: 'fieldChange:item.disponib',
						id: 'ITEM____ITEM_DISPONIB',
						name: 'DISPONIB',
						size: 'medium',
						label: computed(() => this.Resources.AVAILABILITY56489),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						maxLength: 1,
						labelId: 'label_ITEM____ITEM_DISPONIB',
						arrayName: 'dsiponib',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					ITEM____ITEM_DATE____: new fieldControlClass.DateControl({
						modelField: 'ValDate',
						valueChangeEvent: 'fieldChange:item.date',
						id: 'ITEM____ITEM_DATE____',
						name: 'DATE',
						size: 'small',
						label: computed(() => this.Resources.DATE18475),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						format: 'date',
						controlLimits: [
						],
					}, this),
					ITEM____ITEM_TECHSPEC: new fieldControlClass.DocumentControl({
						modelField: 'ValTechspec',
						valueChangeEvent: 'fieldChange:item.techspec',
						id: 'ITEM____ITEM_TECHSPEC',
						name: 'TECHSPEC',
						size: 'xxlarge',
						label: computed(() => this.Resources.SPECIFICATIONS59226),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						versioningIsOn: true,
						viewType: qEnums.documentViewTypeMode.print,
						extensions: [],
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
					Gitem: {
						get ValItemdes() { return vm.model.TableGitemItemdes.value },
						set ValItemdes(value) { vm.model.TableGitemItemdes.updateValue(value) },
						get ValItemgcod() { return vm.model.GitemValItemgcod.value },
						set ValItemgcod(value) { vm.model.GitemValItemgcod.updateValue(value) },
					},
					Item: {
						get ValCategory() { return vm.model.ValCategory.value },
						set ValCategory(value) { vm.model.ValCategory.updateValue(value) },
						get ValCodgitem() { return vm.model.ValCodgitem.value },
						set ValCodgitem(value) { vm.model.ValCodgitem.updateValue(value) },
						get ValCodwareh() { return vm.model.ValCodwareh.value },
						set ValCodwareh(value) { vm.model.ValCodwareh.updateValue(value) },
						get ValDate() { return vm.model.ValDate.value },
						set ValDate(value) { vm.model.ValDate.updateValue(value) },
						get ValDisponib() { return vm.model.ValDisponib.value },
						set ValDisponib(value) { vm.model.ValDisponib.updateValue(value) },
						get ValEntries() { return vm.model.ValEntries.value },
						set ValEntries(value) { vm.model.ValEntries.updateValue(value) },
						get ValExistenc() { return vm.model.ValExistenc.value },
						set ValExistenc(value) { vm.model.ValExistenc.updateValue(value) },
						get ValExits() { return vm.model.ValExits.value },
						set ValExits(value) { vm.model.ValExits.updateValue(value) },
						get ValImage() { return vm.model.ValImage.value },
						set ValImage(value) { vm.model.ValImage.updateValue(value) },
						get ValItemcod() { return vm.model.ValItemcod.value },
						set ValItemcod(value) { vm.model.ValItemcod.updateValue(value) },
						get ValItemdes() { return vm.model.ValItemdes.value },
						set ValItemdes(value) { vm.model.ValItemdes.updateValue(value) },
						get ValItemtype() { return vm.model.ValItemtype.value },
						set ValItemtype(value) { vm.model.ValItemtype.updateValue(value) },
						get ValTechspec() { return vm.model.ValTechspec.value },
						set ValTechspec(value) { vm.model.ValTechspec.updateValue(value) },
						get ValValid() { return vm.model.ValValid.value },
						set ValValid(value) { vm.model.ValValid.updateValue(value) },
					},
					Wareh: {
						get ValWarehdes() { return vm.model.TableWarehWarehdes.value },
						set ValWarehdes(value) { vm.model.TableWarehWarehdes.updateValue(value) },
					},
					keys: {
						/** The primary key of the ITEM table */
						get item() { return vm.model.ValCoditem },
						/** The foreign key to the GITEM table */
						get gitem() { return vm.model.ValCodgitem },
						/** The foreign key to the WAREH table */
						get wareh() { return vm.model.ValCodwareh },
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
// USE /[MANUAL GQT FORM_CODEJS ITEM]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS ITEM]/
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
// USE /[MANUAL GQT FORM_LOADED_JS ITEM]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS ITEM]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS ITEM]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS ITEM]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS ITEM]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS ITEM]/
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
// USE /[MANUAL GQT AFTER_DEL_JS ITEM]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS ITEM]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS ITEM]/
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
// USE /[MANUAL GQT DLGUPDT ITEM]/
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
// USE /[MANUAL GQT CTRLBLR ITEM]/
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
// USE /[MANUAL GQT CTRLUPD ITEM]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS ITEM]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
