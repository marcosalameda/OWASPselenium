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
			data-key="ARTIGVAL"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.ARTIGVALITEM_IMAGE___.isVisible">
					<q-control-wrapper
						v-show="controls.ARTIGVALITEM_IMAGE___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="q-image"
							v-bind="controls.ARTIGVALITEM_IMAGE___"
							v-on="controls.ARTIGVALITEM_IMAGE___.handlers"
							:loading="controls.ARTIGVALITEM_IMAGE___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-image
								v-if="controls.ARTIGVALITEM_IMAGE___.isVisible"
								v-bind="controls.ARTIGVALITEM_IMAGE___.props"
								v-on="controls.ARTIGVALITEM_IMAGE___.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.ARTIGVALGITEMITEMDES_.isVisible">
					<q-control-wrapper
						v-show="controls.ARTIGVALGITEMITEMDES_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ARTIGVALGITEMITEMDES_"
							v-on="controls.ARTIGVALGITEMITEMDES_.handlers"
							:loading="controls.ARTIGVALGITEMITEMDES_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-lookup
								v-if="controls.ARTIGVALGITEMITEMDES_.isVisible"
								v-bind="controls.ARTIGVALGITEMITEMDES_.props"
								:model-value="model.ValCodgitem.value"
								v-on="controls.ARTIGVALGITEMITEMDES_.handlers"
								@update:model-value="model.ValCodgitem.fnUpdateValue" />
							<q-see-more-artigvalgitemitemdes
								v-if="controls.ARTIGVALGITEMITEMDES_.seeMoreIsVisible"
								v-bind="controls.ARTIGVALGITEMITEMDES_.seeMoreParams"
								v-on="controls.ARTIGVALGITEMITEMDES_.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.ARTIGVALWAREHWAREHDES.isVisible">
					<q-control-wrapper
						v-show="controls.ARTIGVALWAREHWAREHDES.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ARTIGVALWAREHWAREHDES"
							v-on="controls.ARTIGVALWAREHWAREHDES.handlers"
							:loading="controls.ARTIGVALWAREHWAREHDES.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-lookup
								v-if="controls.ARTIGVALWAREHWAREHDES.isVisible"
								v-bind="controls.ARTIGVALWAREHWAREHDES.props"
								:model-value="model.ValCodwareh.value"
								v-on="controls.ARTIGVALWAREHWAREHDES.handlers"
								@update:model-value="model.ValCodwareh.fnUpdateValue" />
							<q-see-more-artigvalwarehwarehdes
								v-if="controls.ARTIGVALWAREHWAREHDES.seeMoreIsVisible"
								v-bind="controls.ARTIGVALWAREHWAREHDES.seeMoreParams"
								v-on="controls.ARTIGVALWAREHWAREHDES.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.ARTIGVALITEM_ITEMTYPE.isVisible || controls.ARTIGVALITEM_ITEMCOD_.isVisible">
					<q-control-wrapper
						v-show="controls.ARTIGVALITEM_ITEMTYPE.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ARTIGVALITEM_ITEMTYPE"
							v-on="controls.ARTIGVALITEM_ITEMTYPE.handlers"
							:loading="controls.ARTIGVALITEM_ITEMTYPE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-select
								v-if="controls.ARTIGVALITEM_ITEMTYPE.isVisible"
								v-bind="controls.ARTIGVALITEM_ITEMTYPE.props"
								:model-value="model.ValItemtype.value"
								@update:model-value="model.ValItemtype.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ARTIGVALITEM_ITEMCOD_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ARTIGVALITEM_ITEMCOD_"
							v-on="controls.ARTIGVALITEM_ITEMCOD_.handlers"
							:loading="controls.ARTIGVALITEM_ITEMCOD_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ARTIGVALITEM_ITEMCOD_.props"
								:model-value="model.ValItemcod.value"
								@update:model-value="model.ValItemcod.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.ARTIGVALITEM_ITEMDES_.isVisible">
					<q-control-wrapper
						v-show="controls.ARTIGVALITEM_ITEMDES_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ARTIGVALITEM_ITEMDES_"
							v-on="controls.ARTIGVALITEM_ITEMDES_.handlers"
							:loading="controls.ARTIGVALITEM_ITEMDES_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ARTIGVALITEM_ITEMDES_.props"
								:model-value="model.ValItemdes.value"
								@update:model-value="model.ValItemdes.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.ARTIGVALITEM_DATE____.isVisible || controls.ARTIGVALITEM_ENTRIES_.isVisible || controls.ARTIGVALITEM_EXITS___.isVisible || controls.ARTIGVALITEM_EXISTENC.isVisible">
					<q-control-wrapper
						v-show="controls.ARTIGVALITEM_DATE____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ARTIGVALITEM_DATE____"
							v-on="controls.ARTIGVALITEM_DATE____.handlers"
							:loading="controls.ARTIGVALITEM_DATE____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-datetime-input
								v-if="controls.ARTIGVALITEM_DATE____.isVisible"
								v-bind="controls.ARTIGVALITEM_DATE____"
								format="Date"
								:model-value="model.ValDate.value"
								@update:model-value="model.ValDate.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ARTIGVALITEM_ENTRIES_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ARTIGVALITEM_ENTRIES_"
							v-on="controls.ARTIGVALITEM_ENTRIES_.handlers"
							:loading="controls.ARTIGVALITEM_ENTRIES_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-numeric-input
								v-if="controls.ARTIGVALITEM_ENTRIES_.isVisible"
								v-bind="controls.ARTIGVALITEM_ENTRIES_"
								:model-value="model.ValEntries.value"
								@update:model-value="model.ValEntries.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ARTIGVALITEM_EXITS___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ARTIGVALITEM_EXITS___"
							v-on="controls.ARTIGVALITEM_EXITS___.handlers"
							:loading="controls.ARTIGVALITEM_EXITS___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-numeric-input
								v-if="controls.ARTIGVALITEM_EXITS___.isVisible"
								v-bind="controls.ARTIGVALITEM_EXITS___"
								:model-value="model.ValExits.value"
								@update:model-value="model.ValExits.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ARTIGVALITEM_EXISTENC.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ARTIGVALITEM_EXISTENC"
							v-on="controls.ARTIGVALITEM_EXISTENC.handlers"
							:loading="controls.ARTIGVALITEM_EXISTENC.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-numeric-input
								v-if="controls.ARTIGVALITEM_EXISTENC.isVisible"
								v-bind="controls.ARTIGVALITEM_EXISTENC"
								:model-value="model.ValExistenc.value"
								@update:model-value="model.ValExistenc.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.ARTIGVALITEM_CATEGORY.isVisible">
					<q-control-wrapper
						v-show="controls.ARTIGVALITEM_CATEGORY.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-textarea"
							v-bind="controls.ARTIGVALITEM_CATEGORY"
							v-on="controls.ARTIGVALITEM_CATEGORY.handlers"
							:loading="controls.ARTIGVALITEM_CATEGORY.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-textarea-input
								v-if="controls.ARTIGVALITEM_CATEGORY.isVisible"
								id="ARTIGVALITEM_CATEGORY"
								size="xxlarge"
								:model-value="model.ValCategory.value"
								:rows="2"
								:cols="85"
								:is-required="controls.ARTIGVALITEM_CATEGORY.isRequired"
								:readonly="controls.ARTIGVALITEM_CATEGORY.readonly"
								:placeholder="controls.ARTIGVALITEM_CATEGORY.placeholder"
								@update:model-value="model.ValCategory.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.ARTIGVALITEM_DISPONIB.isVisible">
					<q-control-wrapper
						v-show="controls.ARTIGVALITEM_DISPONIB.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ARTIGVALITEM_DISPONIB"
							v-on="controls.ARTIGVALITEM_DISPONIB.handlers"
							:loading="controls.ARTIGVALITEM_DISPONIB.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-select
								v-if="controls.ARTIGVALITEM_DISPONIB.isVisible"
								v-bind="controls.ARTIGVALITEM_DISPONIB.props"
								:model-value="model.ValDisponib.value" />
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

	import FormViewModel from './QFormArtigvalViewModel.js'

	const requiredTextResources = ['QFormArtigval', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS ARTIGVAL]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormArtigval',

		components: {
			QSeeMoreArtigvalgitemitemdes: defineAsyncComponent(() => import('@/views/forms/FormArtigval/dbedits/ArtigvalgitemitemdesSeeMore.vue')),
			QSeeMoreArtigvalwarehwarehdes: defineAsyncComponent(() => import('@/views/forms/FormArtigval/dbedits/ArtigvalwarehwarehdesSeeMore.vue')),
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
						name: 'ARTIGVAL',
						location: 'form-ARTIGVAL',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormArtigval', false),

				interfaceMetadata: {
					id: 'QFormArtigval', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'popup',
					name: 'ARTIGVAL',
					route: 'form-ARTIGVAL',
					area: 'ITEM',
					primaryKey: 'ValCoditem',
					designation: computed(() => this.Resources.ITEM40802),
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
						text: computed(() => vm.Resources.SAVE04165),
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
					ARTIGVALITEM_IMAGE___: new fieldControlClass.ImageControl({
						modelField: 'ValImage',
						valueChangeEvent: 'fieldChange:item.image',
						id: 'ARTIGVALITEM_IMAGE___',
						name: 'IMAGE',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.IMAGE65174),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						height: 50,
						width: 100,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ARTIGVALGITEMITEMDES_: new fieldControlClass.LookupControl({
						modelField: 'TableGitemItemdes',
						valueChangeEvent: 'fieldChange:gitem.itemdes',
						id: 'ARTIGVALGITEMITEMDES_',
						name: 'ITEMDES',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.GLOBAL_ITEM49586),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodgitem',
							dependencyEvent: 'fieldChange:item.codgitem'
						},
						dependentFields: () => {
							return {
								set 'gitem.codgitem'(value) { vm.model.ValCodgitem.updateValue(value) },
								set 'gitem.itemdes'(value) { vm.model.TableGitemItemdes.updateValue(value) },
								set 'gitem.itemgcod'(value) { vm.model.GitemValItemgcod.updateValue(value) },
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
					ARTIGVALWAREHWAREHDES: new fieldControlClass.LookupControl({
						modelField: 'TableWarehWarehdes',
						valueChangeEvent: 'fieldChange:wareh.warehdes',
						id: 'ARTIGVALWAREHWAREHDES',
						name: 'WAREHDES',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.WAREHOUSE51864),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: true,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodwareh',
							dependencyEvent: 'fieldChange:item.codwareh'
						},
						dependentFields: () => {
							return {
								set 'wareh.codwareh'(value) { vm.model.ValCodwareh.updateValue(value) },
								set 'wareh.warehdes'(value) { vm.model.TableWarehWarehdes.updateValue(value) },
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
					ARTIGVALITEM_ITEMTYPE: new fieldControlClass.ArrayStringControl({
						modelField: 'ValItemtype',
						valueChangeEvent: 'fieldChange:item.itemtype',
						id: 'ARTIGVALITEM_ITEMTYPE',
						name: 'ITEMTYPE',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.TIPO55111),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 1,
						labelId: 'label_ARTIGVALITEM_ITEMTYPE',
						arrayName: 'TipoArti',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ARTIGVALITEM_ITEMCOD_: new fieldControlClass.StringControl({
						modelField: 'ValItemcod',
						valueChangeEvent: 'fieldChange:item.itemcod',
						id: 'ARTIGVALITEM_ITEMCOD_',
						name: 'ITEMCOD',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.CODE49225),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 15,
						labelId: 'label_ARTIGVALITEM_ITEMCOD_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ARTIGVALITEM_ITEMDES_: new fieldControlClass.StringControl({
						modelField: 'ValItemdes',
						valueChangeEvent: 'fieldChange:item.itemdes',
						id: 'ARTIGVALITEM_ITEMDES_',
						name: 'ITEMDES',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.ITEM40802),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						labelId: 'label_ARTIGVALITEM_ITEMDES_',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					ARTIGVALITEM_DATE____: new fieldControlClass.DateControl({
						modelField: 'ValDate',
						valueChangeEvent: 'fieldChange:item.date',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'ARTIGVALITEM_DATE____',
						name: 'DATE',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.DATE18475),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ARTIGVALITEM_ENTRIES_: new fieldControlClass.NumberControl({
						modelField: 'ValEntries',
						valueChangeEvent: 'fieldChange:item.entries',
						maxIntegers: 10,
						maxDecimals: 0,
						id: 'ARTIGVALITEM_ENTRIES_',
						name: 'ENTRIES',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.ENTRIES32319),
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
					ARTIGVALITEM_EXITS___: new fieldControlClass.NumberControl({
						modelField: 'ValExits',
						valueChangeEvent: 'fieldChange:item.exits',
						maxIntegers: 10,
						maxDecimals: 0,
						id: 'ARTIGVALITEM_EXITS___',
						name: 'EXITS',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.OUTPUT_10769),
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
					ARTIGVALITEM_EXISTENC: new fieldControlClass.NumberControl({
						modelField: 'ValExistenc',
						valueChangeEvent: 'fieldChange:item.existenc',
						maxIntegers: 10,
						maxDecimals: 0,
						id: 'ARTIGVALITEM_EXISTENC',
						name: 'EXISTENC',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.EXISTENCE30081),
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
					ARTIGVALITEM_CATEGORY: new fieldControlClass.StringControl({
						modelField: 'ValCategory',
						valueChangeEvent: 'fieldChange:item.category',
						id: 'ARTIGVALITEM_CATEGORY',
						name: 'CATEGORY',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.CATEGORIZATION17554),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						maxLength: 85,
						labelId: 'label_ARTIGVALITEM_CATEGORY',
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					ARTIGVALITEM_DISPONIB: new fieldControlClass.ArrayStringControl({
						modelField: 'ValDisponib',
						valueChangeEvent: 'fieldChange:item.disponib',
						id: 'ARTIGVALITEM_DISPONIB',
						name: 'DISPONIB',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.AVAILABILITY56489),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						maxLength: 1,
						labelId: 'label_ARTIGVALITEM_DISPONIB',
						arrayName: 'dsiponib',
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
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
					extraProperties: {}
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
// USE /[MANUAL GQT FORM_CODEJS ARTIGVAL]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS ARTIGVAL]/
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
// USE /[MANUAL GQT FORM_LOADED_JS ARTIGVAL]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS ARTIGVAL]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS ARTIGVAL]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS ARTIGVAL]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS ARTIGVAL]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS ARTIGVAL]/
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
// USE /[MANUAL GQT AFTER_DEL_JS ARTIGVAL]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS ARTIGVAL]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS ARTIGVAL]/
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
// USE /[MANUAL GQT DLGUPDT ARTIGVAL]/
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
// USE /[MANUAL GQT CTRLUPD ARTIGVAL]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
		},

		watch: {
		}
	}
</script>
