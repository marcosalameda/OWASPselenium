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
			data-key="PESSPOP"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.PESSPOP_WPESSNFUNC___.isVisible">
					<q-control-wrapper
						v-show="controls.PESSPOP_WPESSNFUNC___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PESSPOP_WPESSNFUNC___"
							v-on="controls.PESSPOP_WPESSNFUNC___.handlers"
							:loading="controls.PESSPOP_WPESSNFUNC___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-numeric-input
								v-if="controls.PESSPOP_WPESSNFUNC___.isVisible"
								v-bind="controls.PESSPOP_WPESSNFUNC___"
								:model-value="model.ValNfunc.value"
								@update:model-value="model.ValNfunc.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PESSPOP_WPESSPFOTO___.isVisible">
					<q-control-wrapper
						v-show="controls.PESSPOP_WPESSPFOTO___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="q-image"
							v-bind="controls.PESSPOP_WPESSPFOTO___"
							v-on="controls.PESSPOP_WPESSPFOTO___.handlers"
							:loading="controls.PESSPOP_WPESSPFOTO___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-image
								v-if="controls.PESSPOP_WPESSPFOTO___.isVisible"
								v-bind="controls.PESSPOP_WPESSPFOTO___.props"
								v-on="controls.PESSPOP_WPESSPFOTO___.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PESSPOP_WPESSNAME____.isVisible || controls.PESSPOP_WPESSDATE____.isVisible || controls.PESSPOP_WPESSSEX_____.isVisible">
					<q-control-wrapper
						v-show="controls.PESSPOP_WPESSNAME____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PESSPOP_WPESSNAME____"
							v-on="controls.PESSPOP_WPESSNAME____.handlers"
							:loading="controls.PESSPOP_WPESSNAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.PESSPOP_WPESSNAME____.props"
								:model-value="model.ValName.value"
								@update:model-value="model.ValName.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.PESSPOP_WPESSDATE____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PESSPOP_WPESSDATE____"
							v-on="controls.PESSPOP_WPESSDATE____.handlers"
							:loading="controls.PESSPOP_WPESSDATE____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-datetime-input
								v-if="controls.PESSPOP_WPESSDATE____.isVisible"
								v-bind="controls.PESSPOP_WPESSDATE____"
								format="Date"
								:model-value="model.ValDate.value"
								@update:model-value="model.ValDate.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.PESSPOP_WPESSSEX_____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PESSPOP_WPESSSEX_____"
							v-on="controls.PESSPOP_WPESSSEX_____.handlers"
							:loading="controls.PESSPOP_WPESSSEX_____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-select
								v-if="controls.PESSPOP_WPESSSEX_____.isVisible"
								v-bind="controls.PESSPOP_WPESSSEX_____.props"
								:model-value="model.ValSex.value"
								@update:model-value="model.ValSex.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PESSPOP_WPESSNATURALI.isVisible">
					<q-control-wrapper
						v-show="controls.PESSPOP_WPESSNATURALI.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PESSPOP_WPESSNATURALI"
							v-on="controls.PESSPOP_WPESSNATURALI.handlers"
							:loading="controls.PESSPOP_WPESSNATURALI.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.PESSPOP_WPESSNATURALI.props"
								:model-value="model.ValNaturali.value"
								@update:model-value="model.ValNaturali.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PESSPOP_WPESSNACIONAL.isVisible">
					<q-control-wrapper
						v-show="controls.PESSPOP_WPESSNACIONAL.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PESSPOP_WPESSNACIONAL"
							v-on="controls.PESSPOP_WPESSNACIONAL.handlers"
							:loading="controls.PESSPOP_WPESSNACIONAL.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.PESSPOP_WPESSNACIONAL.props"
								:model-value="model.ValNacional.value"
								@update:model-value="model.ValNacional.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PESSPOP_WPESSADRESS__.isVisible || controls.PESSPOP_WPESSZIPCODE_.isVisible">
					<q-control-wrapper
						v-show="controls.PESSPOP_WPESSADRESS__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PESSPOP_WPESSADRESS__"
							v-on="controls.PESSPOP_WPESSADRESS__.handlers"
							:loading="controls.PESSPOP_WPESSADRESS__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.PESSPOP_WPESSADRESS__.props"
								:model-value="model.ValAdress.value"
								@update:model-value="model.ValAdress.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.PESSPOP_WPESSZIPCODE_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PESSPOP_WPESSZIPCODE_"
							v-on="controls.PESSPOP_WPESSZIPCODE_.handlers"
							:loading="controls.PESSPOP_WPESSZIPCODE_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-mask
								v-if="controls.PESSPOP_WPESSZIPCODE_.isVisible"
								v-bind="controls.PESSPOP_WPESSZIPCODE_"
								:model-value="model.ValZipcode.value"
								@update:model-value="model.ValZipcode.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PESSPOP_WPESSCOUNTRY_.isVisible">
					<q-control-wrapper
						v-show="controls.PESSPOP_WPESSCOUNTRY_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PESSPOP_WPESSCOUNTRY_"
							v-on="controls.PESSPOP_WPESSCOUNTRY_.handlers"
							:loading="controls.PESSPOP_WPESSCOUNTRY_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.PESSPOP_WPESSCOUNTRY_.props"
								:model-value="model.ValCountry.value"
								@update:model-value="model.ValCountry.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PESSPOP_WPESSEMAIL___.isVisible">
					<q-control-wrapper
						v-show="controls.PESSPOP_WPESSEMAIL___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PESSPOP_WPESSEMAIL___"
							v-on="controls.PESSPOP_WPESSEMAIL___.handlers"
							:loading="controls.PESSPOP_WPESSEMAIL___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-mask
								v-if="controls.PESSPOP_WPESSEMAIL___.isVisible"
								v-bind="controls.PESSPOP_WPESSEMAIL___"
								:model-value="model.ValEmail.value"
								@update:model-value="model.ValEmail.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PESSPOP_WPESSCELLPHON.isVisible">
					<q-control-wrapper
						v-show="controls.PESSPOP_WPESSCELLPHON.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PESSPOP_WPESSCELLPHON"
							v-on="controls.PESSPOP_WPESSCELLPHON.handlers"
							:loading="controls.PESSPOP_WPESSCELLPHON.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-numeric-input
								v-if="controls.PESSPOP_WPESSCELLPHON.isVisible"
								v-bind="controls.PESSPOP_WPESSCELLPHON"
								:model-value="model.ValCellphon.value"
								@update:model-value="model.ValCellphon.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PESSPOP_WAREHWAREHDES.isVisible">
					<q-control-wrapper
						v-show="controls.PESSPOP_WAREHWAREHDES.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PESSPOP_WAREHWAREHDES"
							v-on="controls.PESSPOP_WAREHWAREHDES.handlers"
							:loading="controls.PESSPOP_WAREHWAREHDES.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-lookup
								v-if="controls.PESSPOP_WAREHWAREHDES.isVisible"
								v-bind="controls.PESSPOP_WAREHWAREHDES.props"
								:model-value="model.ValCodwareh.value"
								v-on="controls.PESSPOP_WAREHWAREHDES.handlers"
								@update:model-value="model.ValCodwareh.fnUpdateValue" />
							<q-see-more-pesspop-warehwarehdes
								v-if="controls.PESSPOP_WAREHWAREHDES.seeMoreIsVisible"
								v-bind="controls.PESSPOP_WAREHWAREHDES.seeMoreParams"
								v-on="controls.PESSPOP_WAREHWAREHDES.handlers" />
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

	import FormViewModel from './QFormPesspopViewModel.js'

	const requiredTextResources = ['QFormPesspop', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PESSPOP]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormPesspop',

		components: {
			QSeeMorePesspopWarehwarehdes: defineAsyncComponent(() => import('@/views/forms/FormPesspop/dbedits/PesspopWarehwarehdesSeeMore.vue')),
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
						name: 'PESSPOP',
						location: 'form-PESSPOP',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormPesspop', false),

				interfaceMetadata: {
					id: 'QFormPesspop', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'popup',
					name: 'PESSPOP',
					route: 'form-PESSPOP',
					area: 'WPESS',
					primaryKey: 'ValCodpess',
					designation: computed(() => this.Resources.FUNCIONARIO_DO_ARMAZ49520),
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
						text: computed(() => vm.Resources.INSERIR43365),
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
					PESSPOP_WPESSNFUNC___: new fieldControlClass.NumberControl({
						modelField: 'ValNfunc',
						valueChangeEvent: 'fieldChange:wpess.nfunc',
						maxIntegers: 6,
						maxDecimals: 0,
						id: 'PESSPOP_WPESSNFUNC___',
						name: 'NFUNC',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.EMPLOYEE_NUMBER05861),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSPOP_WPESSPFOTO___: new fieldControlClass.ImageControl({
						modelField: 'ValPfoto',
						valueChangeEvent: 'fieldChange:wpess.pfoto',
						id: 'PESSPOP_WPESSPFOTO___',
						name: 'PFOTO',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.PROFILLE_PICTURE38233),
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
					PESSPOP_WPESSNAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:wpess.name',
						id: 'PESSPOP_WPESSNAME____',
						name: 'NAME',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.NAME31974),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_PESSPOP_WPESSNAME____',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSPOP_WPESSDATE____: new fieldControlClass.DateControl({
						modelField: 'ValDate',
						valueChangeEvent: 'fieldChange:wpess.date',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'PESSPOP_WPESSDATE____',
						name: 'DATE',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.BIRTH_DATE54504),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSPOP_WPESSSEX_____: new fieldControlClass.ArrayStringControl({
						modelField: 'ValSex',
						valueChangeEvent: 'fieldChange:wpess.sex',
						id: 'PESSPOP_WPESSSEX_____',
						name: 'SEX',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.SEX34102),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 9,
						labelId: 'label_PESSPOP_WPESSSEX_____',
						arrayName: 'SEXO',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSPOP_WPESSNATURALI: new fieldControlClass.StringControl({
						modelField: 'ValNaturali',
						valueChangeEvent: 'fieldChange:wpess.naturali',
						id: 'PESSPOP_WPESSNATURALI',
						name: 'NATURALI',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.COUNTRY_OF_BIRTH53244),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_PESSPOP_WPESSNATURALI',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSPOP_WPESSNACIONAL: new fieldControlClass.StringControl({
						modelField: 'ValNacional',
						valueChangeEvent: 'fieldChange:wpess.nacional',
						id: 'PESSPOP_WPESSNACIONAL',
						name: 'NACIONAL',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.NATIONALITY34787),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_PESSPOP_WPESSNACIONAL',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSPOP_WPESSADRESS__: new fieldControlClass.StringControl({
						modelField: 'ValAdress',
						valueChangeEvent: 'fieldChange:wpess.adress',
						id: 'PESSPOP_WPESSADRESS__',
						name: 'ADRESS',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.ADRESS39816),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 100,
						labelId: 'label_PESSPOP_WPESSADRESS__',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSPOP_WPESSZIPCODE_: new fieldControlClass.MaskControl({
						modelField: 'ValZipcode',
						valueChangeEvent: 'fieldChange:wpess.zipcode',
						id: 'PESSPOP_WPESSZIPCODE_',
						name: 'ZIPCODE',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.ZIPCODE21021),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 8,
						labelId: 'label_PESSPOP_WPESSZIPCODE_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSPOP_WPESSCOUNTRY_: new fieldControlClass.StringControl({
						modelField: 'ValCountry',
						valueChangeEvent: 'fieldChange:wpess.country',
						id: 'PESSPOP_WPESSCOUNTRY_',
						name: 'COUNTRY',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.COUNTRY64133),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_PESSPOP_WPESSCOUNTRY_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSPOP_WPESSEMAIL___: new fieldControlClass.MaskControl({
						modelField: 'ValEmail',
						valueChangeEvent: 'fieldChange:wpess.email',
						id: 'PESSPOP_WPESSEMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.EMAIL25170),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 150,
						labelId: 'label_PESSPOP_WPESSEMAIL___',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSPOP_WPESSCELLPHON: new fieldControlClass.NumberControl({
						modelField: 'ValCellphon',
						valueChangeEvent: 'fieldChange:wpess.cellphon',
						maxIntegers: 9,
						maxDecimals: 0,
						id: 'PESSPOP_WPESSCELLPHON',
						name: 'CELLPHON',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.CELLPHONE19585),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSPOP_WAREHWAREHDES: new fieldControlClass.LookupControl({
						modelField: 'TableWarehWarehdes',
						valueChangeEvent: 'fieldChange:wareh.warehdes',
						id: 'PESSPOP_WAREHWAREHDES',
						name: 'WAREHDES',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.WAREHOUSE51864),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodwareh',
							dependencyEvent: 'fieldChange:wpess.codwareh'
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
					Wareh: {
						get ValWarehdes() { return vm.model.TableWarehWarehdes.value },
						set ValWarehdes(value) { vm.model.TableWarehWarehdes.updateValue(value) },
					},
					Wpess: {
						get ValAdress() { return vm.model.ValAdress.value },
						set ValAdress(value) { vm.model.ValAdress.updateValue(value) },
						get ValCellphon() { return vm.model.ValCellphon.value },
						set ValCellphon(value) { vm.model.ValCellphon.updateValue(value) },
						get ValCodwareh() { return vm.model.ValCodwareh.value },
						set ValCodwareh(value) { vm.model.ValCodwareh.updateValue(value) },
						get ValCountry() { return vm.model.ValCountry.value },
						set ValCountry(value) { vm.model.ValCountry.updateValue(value) },
						get ValDate() { return vm.model.ValDate.value },
						set ValDate(value) { vm.model.ValDate.updateValue(value) },
						get ValEmail() { return vm.model.ValEmail.value },
						set ValEmail(value) { vm.model.ValEmail.updateValue(value) },
						get ValNacional() { return vm.model.ValNacional.value },
						set ValNacional(value) { vm.model.ValNacional.updateValue(value) },
						get ValName() { return vm.model.ValName.value },
						set ValName(value) { vm.model.ValName.updateValue(value) },
						get ValNaturali() { return vm.model.ValNaturali.value },
						set ValNaturali(value) { vm.model.ValNaturali.updateValue(value) },
						get ValNfunc() { return vm.model.ValNfunc.value },
						set ValNfunc(value) { vm.model.ValNfunc.updateValue(value) },
						get ValPfoto() { return vm.model.ValPfoto.value },
						set ValPfoto(value) { vm.model.ValPfoto.updateValue(value) },
						get ValSex() { return vm.model.ValSex.value },
						set ValSex(value) { vm.model.ValSex.updateValue(value) },
						get ValZipcode() { return vm.model.ValZipcode.value },
						set ValZipcode(value) { vm.model.ValZipcode.updateValue(value) },
					},
					keys: {
						/** The primary key of the WPESS table */
						get wpess() { return vm.model.ValCodpess },
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
// USE /[MANUAL GQT FORM_CODEJS PESSPOP]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS PESSPOP]/
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
// USE /[MANUAL GQT FORM_LOADED_JS PESSPOP]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS PESSPOP]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS PESSPOP]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS PESSPOP]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS PESSPOP]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS PESSPOP]/
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
// USE /[MANUAL GQT AFTER_DEL_JS PESSPOP]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS PESSPOP]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS PESSPOP]/
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
// USE /[MANUAL GQT DLGUPDT PESSPOP]/
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
// USE /[MANUAL GQT CTRLUPD PESSPOP]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
		},

		watch: {
		}
	}
</script>
