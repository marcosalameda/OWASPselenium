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
			data-key="DISPA"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.DISPA___DISPADISPADT_.isVisible || controls.DISPA___DISPADISPANR_.isVisible || controls.DISPA___DISSTSTATUS__.isVisible || controls.DISPA___DISPASTATUS__.isVisible">
					<q-control-wrapper
						v-show="controls.DISPA___DISPADISPADT_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.DISPA___DISPADISPADT_"
							v-on="controls.DISPA___DISPADISPADT_.handlers"
							:loading="controls.DISPA___DISPADISPADT_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.DISPA___DISPADISPADT_.isVisible"
								v-bind="controls.DISPA___DISPADISPADT_.props"
								:model-value="model.ValDispadt.value"
								@reset-icon-click="model.ValDispadt.fnUpdateValue(model.ValDispadt.originalValue ?? new Date())"
								@update:model-value="model.ValDispadt.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.DISPA___DISPADISPANR_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.DISPA___DISPADISPANR_"
							v-on="controls.DISPA___DISPADISPANR_.handlers"
							:loading="controls.DISPA___DISPADISPANR_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.DISPA___DISPADISPANR_.isVisible"
								v-bind="controls.DISPA___DISPADISPANR_.props"
								@update:model-value="model.ValDispanr.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.DISPA___DISSTSTATUS__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.DISPA___DISSTSTATUS__"
							v-on="controls.DISPA___DISSTSTATUS__.handlers"
							:loading="controls.DISPA___DISSTSTATUS__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.DISPA___DISSTSTATUS__.isVisible"
								v-bind="controls.DISPA___DISSTSTATUS__.props"
								v-on="controls.DISPA___DISSTSTATUS__.handlers" />
							<q-see-more-dispa-disststatus
								v-if="controls.DISPA___DISSTSTATUS__.seeMoreIsVisible"
								v-bind="controls.DISPA___DISSTSTATUS__.seeMoreParams"
								v-on="controls.DISPA___DISSTSTATUS__.handlers" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.DISPA___DISPASTATUS__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.DISPA___DISPASTATUS__"
							v-on="controls.DISPA___DISPASTATUS__.handlers"
							:loading="controls.DISPA___DISPASTATUS__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-select
								v-if="controls.DISPA___DISPASTATUS__.isVisible"
								v-bind="controls.DISPA___DISPASTATUS__.props" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.DISPA___ENTITNAME____.isVisible">
					<q-control-wrapper
						v-show="controls.DISPA___ENTITNAME____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.DISPA___ENTITNAME____"
							v-on="controls.DISPA___ENTITNAME____.handlers"
							:loading="controls.DISPA___ENTITNAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.DISPA___ENTITNAME____.isVisible"
								v-bind="controls.DISPA___ENTITNAME____.props"
								v-on="controls.DISPA___ENTITNAME____.handlers" />
							<q-see-more-dispa-entitname
								v-if="controls.DISPA___ENTITNAME____.seeMoreIsVisible"
								v-bind="controls.DISPA___ENTITNAME____.seeMoreParams"
								v-on="controls.DISPA___ENTITNAME____.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.DISPA___DISPAISPREPAR.isVisible">
					<q-control-wrapper
						v-show="controls.DISPA___DISPAISPREPAR.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.DISPA___DISPAISPREPAR"
							v-on="controls.DISPA___DISPAISPREPAR.handlers"
							:loading="controls.DISPA___DISPAISPREPAR.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox-input
									v-if="controls.DISPA___DISPAISPREPAR.isVisible"
									v-bind="controls.DISPA___DISPAISPREPAR.props"
									v-on="controls.DISPA___DISPAISPREPAR.handlers" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.DISPA___DISPAPREPARED.isVisible || controls.DISPA___PERSONAME____.isVisible">
					<q-control-wrapper
						v-show="controls.DISPA___DISPAPREPARED.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.DISPA___DISPAPREPARED"
							v-on="controls.DISPA___DISPAPREPARED.handlers"
							:loading="controls.DISPA___DISPAPREPARED.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.DISPA___DISPAPREPARED.isVisible"
								v-bind="controls.DISPA___DISPAPREPARED.props"
								:model-value="model.ValPrepared.value"
								@reset-icon-click="model.ValPrepared.fnUpdateValue(model.ValPrepared.originalValue ?? new Date())"
								@update:model-value="model.ValPrepared.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.DISPA___PERSONAME____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.DISPA___PERSONAME____"
							v-on="controls.DISPA___PERSONAME____.handlers"
							:loading="controls.DISPA___PERSONAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.DISPA___PERSONAME____.isVisible"
								v-bind="controls.DISPA___PERSONAME____.props"
								v-on="controls.DISPA___PERSONAME____.handlers" />
							<q-see-more-dispa-personame
								v-if="controls.DISPA___PERSONAME____.seeMoreIsVisible"
								v-bind="controls.DISPA___PERSONAME____.seeMoreParams"
								v-on="controls.DISPA___PERSONAME____.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.DISPA___PSEUDDISPATCH.isVisible">
					<q-control-wrapper
						v-show="controls.DISPA___PSEUDDISPATCH.isVisible"
						class="control-join-group">
						<q-table
							v-show="controls.DISPA___PSEUDDISPATCH.isVisible"
							v-bind="controls.DISPA___PSEUDDISPATCH"
							v-on="controls.DISPA___PSEUDDISPATCH.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.DISPA___PSEUDDISPATCH"
							v-on="controls.DISPA___PSEUDDISPATCH.handlers" />
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

	import FormViewModel from './QFormDispaViewModel.js'

	const requiredTextResources = ['QFormDispa', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS DISPA]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormDispa',

		components: {
			QSeeMoreDispaDisststatus: defineAsyncComponent(() => import('@/views/forms/FormDispa/dbedits/DispaDisststatusSeeMore.vue')),
			QSeeMoreDispaEntitname: defineAsyncComponent(() => import('@/views/forms/FormDispa/dbedits/DispaEntitnameSeeMore.vue')),
			QSeeMoreDispaPersoname: defineAsyncComponent(() => import('@/views/forms/FormDispa/dbedits/DispaPersonameSeeMore.vue')),
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
					name: 'DISPA',
					location: 'form-DISPA',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormDispa', false),

				interfaceMetadata: {
					id: 'QFormDispa', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'DISPA',
					route: 'form-DISPA',
					area: 'DISPA',
					primaryKey: 'ValCoddispa',
					designation: computed(() => this.Resources.DISPATCH46310),
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
					DISPA___DISPADISPADT_: new fieldControlClass.DateControl({
						modelField: 'ValDispadt',
						valueChangeEvent: 'fieldChange:dispa.dispadt',
						id: 'DISPA___DISPADISPADT_',
						name: 'DISPADT',
						size: 'medium',
						label: computed(() => this.Resources.DISPATCH_DATE54413),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						format: 'dateTime',
						controlLimits: [
						],
					}, this),
					DISPA___DISPADISPANR_: new fieldControlClass.NumberControl({
						modelField: 'ValDispanr',
						valueChangeEvent: 'fieldChange:dispa.dispanr',
						id: 'DISPA___DISPADISPANR_',
						name: 'DISPANR',
						size: 'small',
						label: computed(() => this.Resources.DISPATCH_NUMBER23616),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 10,
						maxDecimals: 0,
						isSequencial: true,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					DISPA___DISSTSTATUS__: new fieldControlClass.LookupControl({
						modelField: 'TableDisstStatus',
						valueChangeEvent: 'fieldChange:disst.status',
						id: 'DISPA___DISSTSTATUS__',
						name: 'STATUS',
						size: 'xxlarge',
						label: computed(() => this.Resources.STATUS62033),
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
							name: 'ValCoddisst',
							dependencyEvent: 'fieldChange:dispa.coddisst'
						},
						dependentFields: () => ({
							set 'disst.coddisst'(value) { vm.model.ValCoddisst.updateValue(value) },
							set 'disst.status'(value) { vm.model.TableDisstStatus.updateValue(value) },
						}),
						insertEnabled: true,
						supportForm: 'DISST',
						controlLimits: [
						],
					}, this),
					DISPA___DISPASTATUS__: new fieldControlClass.ArrayStringControl({
						modelField: 'ValStatus',
						valueChangeEvent: 'fieldChange:dispa.status',
						id: 'DISPA___DISPASTATUS__',
						name: 'STATUS',
						size: 'small',
						label: computed(() => this.Resources.STATUS62033),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						maxLength: 1,
						labelId: 'label_DISPA___DISPASTATUS__',
						arrayName: 'DispStat',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					DISPA___ENTITNAME____: new fieldControlClass.LookupControl({
						modelField: 'TableEntitName',
						valueChangeEvent: 'fieldChange:entit.name',
						id: 'DISPA___ENTITNAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.CLIENTE40500),
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
							name: 'ValCodentit',
							dependencyEvent: 'fieldChange:dispa.codentit'
						},
						dependentFields: () => ({
							set 'entit.codentit'(value) { vm.model.ValCodentit.updateValue(value) },
							set 'entit.name'(value) { vm.model.TableEntitName.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					DISPA___DISPAISPREPAR: new fieldControlClass.BooleanControl({
						modelField: 'ValIsprepar',
						valueChangeEvent: 'fieldChange:dispa.isprepar',
						id: 'DISPA___DISPAISPREPAR',
						name: 'ISPREPAR',
						size: 'small',
						label: computed(() => this.Resources.IS_PREPARED16113),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						controlLimits: [
						],
					}, this),
					DISPA___DISPAPREPARED: new fieldControlClass.DateControl({
						modelField: 'ValPrepared',
						valueChangeEvent: 'fieldChange:dispa.prepared',
						id: 'DISPA___DISPAPREPARED',
						name: 'PREPARED',
						size: 'medium',
						label: computed(() => this.Resources.PREPARED38522),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						format: 'dateTime',
						controlLimits: [
						],
					}, this),
					DISPA___PERSONAME____: new fieldControlClass.LookupControl({
						modelField: 'TablePersoName',
						valueChangeEvent: 'fieldChange:perso.name',
						id: 'DISPA___PERSONAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.PREPARED_BY36821),
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
							name: 'ValCodperso',
							dependencyEvent: 'fieldChange:dispa.codperso'
						},
						dependentFields: () => ({
							set 'perso.codperso'(value) { vm.model.ValCodperso.updateValue(value) },
							set 'perso.name'(value) { vm.model.TablePersoName.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					DISPA___PSEUDDISPATCH: new fieldControlClass.TableListControl({
						id: 'DISPA___PSEUDDISPATCH',
						name: 'DISPATCH',
						size: '',
						label: computed(() => this.Resources.ITEMS55321),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'DISPA',
						action: 'Dispa_ValDispatch',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.NumericColumn({
								order: 1,
								name: 'ValLinenumb',
								area: 'DILIN',
								field: 'LINENUMB',
								label: computed(() => this.Resources.LINE27983),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'Produ.ValSku',
								area: 'PRODU',
								field: 'SKU',
								label: computed(() => this.Resources.SKU42303),
								dataLength: 20,
								scrollData: 20,
								pkColumn: 'ValCodprodu',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'Produ.ValGtin',
								area: 'PRODU',
								field: 'GTIN',
								label: computed(() => this.Resources.GTIN45487),
								dataLength: 14,
								scrollData: 14,
								isVisible: false,
								pkColumn: 'ValCodprodu',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'Produ.ValProduct',
								area: 'PRODU',
								field: 'PRODUCT',
								label: computed(() => this.Resources.PRODUCT12880),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodprodu',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 5,
								name: 'ValOrdered',
								area: 'DILIN',
								field: 'ORDERED',
								label: computed(() => this.Resources.ORDERED04034),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 6,
								name: 'ValDelivere',
								area: 'DILIN',
								field: 'DELIVERE',
								label: computed(() => this.Resources.DELIVERED26597),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 7,
								name: 'ValOutstand',
								area: 'DILIN',
								field: 'OUTSTAND',
								label: computed(() => this.Resources.OUTSTANDING36400),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValDispatch',
							serverMode: true,
							pkColumn: 'ValCoddilin',
							tableAlias: 'DILIN',
							tableNamePlural: computed(() => this.Resources.DISPATCH_LINES01224),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.ITEMS55321),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: false,
								searchOnPressEnter: true
							},
							filtersVisible: false,
							allowColumnFilters: false,
							allowColumnSort: true,
							crudActions: [
								{
									id: 'show',
									name: 'show',
									title: computed(() => this.Resources.CONSULTAR57388),
									icon: {
										icon: 'view'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'DILIN',
										mode: 'SHOW',
										isControlled: true
									}
								},
								{
									id: 'edit',
									name: 'edit',
									title: computed(() => this.Resources.EDITAR11616),
									icon: {
										icon: 'pencil'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'DILIN',
										mode: 'EDIT',
										isControlled: true
									}
								},
								{
									id: 'duplicate',
									name: 'duplicate',
									title: computed(() => this.Resources.DUPLICAR09748),
									icon: {
										icon: 'duplicate'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'DILIN',
										mode: 'DUPLICATE',
										isControlled: true
									}
								},
								{
									id: 'delete',
									name: 'delete',
									title: computed(() => this.Resources.ELIMINAR21155),
									icon: {
										icon: 'delete'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'DILIN',
										mode: 'DELETE',
										isControlled: true
									}
								}
							],
							generalActions: [
								{
									id: 'insert',
									name: 'insert',
									title: computed(() => this.Resources.INSERIR43365),
									icon: {
										icon: 'add'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'DILIN',
										mode: 'NEW',
										repeatInsertion: true,
										isControlled: true
									}
								},
							],
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
							],
							rowClickAction: {
								id: 'RCA__DILIN',
								name: '_DILIN',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'DILIN',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'DILIN': {
									fnKeySelector: (row) => row.Fields.ValCoddilin,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValLinenumb',
							defaultSearchColumnNameOriginal: 'ValLinenumb',
							defaultColumnSorting: {
								columnName: 'ValLinenumb',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-DISPA', 'changed-PRODU', 'changed-DILIN'],
						uuid: 'Dispa_ValDispatch',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'dispa'],
								dependencyEvents: ['fieldChange:dispa.coddispa'],
								dependencyField: 'DISPA.CODDISPA',
								fnValueSelector: (model) => model.ValCoddispa.value
							},
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
					'DISPA___PSEUDDISPATCH',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Dispa: {
						get ValCoddisst() { return vm.model.ValCoddisst.value },
						set ValCoddisst(value) { vm.model.ValCoddisst.updateValue(value) },
						get ValCodentit() { return vm.model.ValCodentit.value },
						set ValCodentit(value) { vm.model.ValCodentit.updateValue(value) },
						get ValCodperso() { return vm.model.ValCodperso.value },
						set ValCodperso(value) { vm.model.ValCodperso.updateValue(value) },
						get ValDispadt() { return vm.model.ValDispadt.value },
						set ValDispadt(value) { vm.model.ValDispadt.updateValue(value) },
						get ValDispanr() { return vm.model.ValDispanr.value },
						set ValDispanr(value) { vm.model.ValDispanr.updateValue(value) },
						get ValIsprepar() { return vm.model.ValIsprepar.value },
						set ValIsprepar(value) { vm.model.ValIsprepar.updateValue(value) },
						get ValPrepared() { return vm.model.ValPrepared.value },
						set ValPrepared(value) { vm.model.ValPrepared.updateValue(value) },
						get ValStatus() { return vm.model.ValStatus.value },
						set ValStatus(value) { vm.model.ValStatus.updateValue(value) },
					},
					Disst: {
						get ValStatus() { return vm.model.TableDisstStatus.value },
						set ValStatus(value) { vm.model.TableDisstStatus.updateValue(value) },
					},
					Entit: {
						get ValName() { return vm.model.TableEntitName.value },
						set ValName(value) { vm.model.TableEntitName.updateValue(value) },
					},
					Perso: {
						get ValName() { return vm.model.TablePersoName.value },
						set ValName(value) { vm.model.TablePersoName.updateValue(value) },
					},
					keys: {
						/** The primary key of the DISPA table */
						get dispa() { return vm.model.ValCoddispa },
						/** The foreign key to the ENTIT table */
						get entit() { return vm.model.ValCodentit },
						/** The foreign key to the DISST table */
						get disst() { return vm.model.ValCoddisst },
						/** The foreign key to the PERSO table */
						get perso() { return vm.model.ValCodperso },
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
// USE /[MANUAL GQT FORM_CODEJS DISPA]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS DISPA]/
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
// USE /[MANUAL GQT FORM_LOADED_JS DISPA]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS DISPA]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS DISPA]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS DISPA]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS DISPA]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS DISPA]/
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
// USE /[MANUAL GQT AFTER_DEL_JS DISPA]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS DISPA]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS DISPA]/
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
// USE /[MANUAL GQT DLGUPDT DISPA]/
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
// USE /[MANUAL GQT CTRLBLR DISPA]/
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
// USE /[MANUAL GQT CTRLUPD DISPA]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS DISPA]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
