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
			data-key="LDSAI"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.LDSAI___OUTPTDOCUMENR.isVisible">
					<q-control-wrapper
						v-show="controls.LDSAI___OUTPTDOCUMENR.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LDSAI___OUTPTDOCUMENR"
							v-on="controls.LDSAI___OUTPTDOCUMENR.handlers"
							:loading="controls.LDSAI___OUTPTDOCUMENR.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.LDSAI___OUTPTDOCUMENR.isVisible"
								v-bind="controls.LDSAI___OUTPTDOCUMENR.props"
								v-on="controls.LDSAI___OUTPTDOCUMENR.handlers" />
							<q-see-more-ldsai-outptdocumenr
								v-if="controls.LDSAI___OUTPTDOCUMENR.seeMoreIsVisible"
								v-bind="controls.LDSAI___OUTPTDOCUMENR.seeMoreParams"
								v-on="controls.LDSAI___OUTPTDOCUMENR.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.LDSAI___PSEUDNOVOGR01.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.LDSAI___PSEUDNOVOGR01.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="LDSAI___PSEUDNOVOGR01"
							v-bind="controls.LDSAI___PSEUDNOVOGR01"
							:is-visible="controls.LDSAI___PSEUDNOVOGR01.isVisible">
							<!-- Start LDSAI___PSEUDNOVOGR01 -->
							<q-row-container v-show="controls.LDSAI___OUTPULINE____.isVisible || controls.LDSAI___WAREHWAREHDES.isVisible">
								<q-control-wrapper
									v-show="controls.LDSAI___OUTPULINE____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.LDSAI___OUTPULINE____"
										v-on="controls.LDSAI___OUTPULINE____.handlers"
										:loading="controls.LDSAI___OUTPULINE____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.LDSAI___OUTPULINE____.isVisible"
											v-bind="controls.LDSAI___OUTPULINE____.props"
											@update:model-value="model.ValLine.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.LDSAI___WAREHWAREHDES.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.LDSAI___WAREHWAREHDES"
										v-on="controls.LDSAI___WAREHWAREHDES.handlers"
										:loading="controls.LDSAI___WAREHWAREHDES.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.LDSAI___WAREHWAREHDES.isVisible"
											v-bind="controls.LDSAI___WAREHWAREHDES.props"
											v-on="controls.LDSAI___WAREHWAREHDES.handlers" />
										<q-see-more-ldsai-warehwarehdes
											v-if="controls.LDSAI___WAREHWAREHDES.seeMoreIsVisible"
											v-bind="controls.LDSAI___WAREHWAREHDES.seeMoreParams"
											v-on="controls.LDSAI___WAREHWAREHDES.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.LDSAI___ITEM_ITEMDES_.isVisible">
								<q-control-wrapper
									v-show="controls.LDSAI___ITEM_ITEMDES_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.LDSAI___ITEM_ITEMDES_"
										v-on="controls.LDSAI___ITEM_ITEMDES_.handlers"
										:loading="controls.LDSAI___ITEM_ITEMDES_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.LDSAI___ITEM_ITEMDES_.isVisible"
											v-bind="controls.LDSAI___ITEM_ITEMDES_.props"
											v-on="controls.LDSAI___ITEM_ITEMDES_.handlers" />
										<q-see-more-ldsai-item-itemdes
											v-if="controls.LDSAI___ITEM_ITEMDES_.seeMoreIsVisible"
											v-bind="controls.LDSAI___ITEM_ITEMDES_.seeMoreParams"
											v-on="controls.LDSAI___ITEM_ITEMDES_.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.LDSAI___OUTPUEXITQNTY.isVisible || controls.LDSAI___OUDOCNRDOCSDA.isVisible">
								<q-control-wrapper
									v-show="controls.LDSAI___OUTPUEXITQNTY.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.LDSAI___OUTPUEXITQNTY"
										v-on="controls.LDSAI___OUTPUEXITQNTY.handlers"
										:loading="controls.LDSAI___OUTPUEXITQNTY.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.LDSAI___OUTPUEXITQNTY.isVisible"
											v-bind="controls.LDSAI___OUTPUEXITQNTY.props"
											@update:model-value="model.ValExitqnty.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.LDSAI___OUDOCNRDOCSDA.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.LDSAI___OUDOCNRDOCSDA"
										v-on="controls.LDSAI___OUDOCNRDOCSDA.handlers"
										:loading="controls.LDSAI___OUDOCNRDOCSDA.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.LDSAI___OUDOCNRDOCSDA.isVisible"
											v-bind="controls.LDSAI___OUDOCNRDOCSDA.props"
											v-on="controls.LDSAI___OUDOCNRDOCSDA.handlers" />
										<q-see-more-ldsai-oudocnrdocsda
											v-if="controls.LDSAI___OUDOCNRDOCSDA.seeMoreIsVisible"
											v-bind="controls.LDSAI___OUDOCNRDOCSDA.seeMoreParams"
											v-on="controls.LDSAI___OUDOCNRDOCSDA.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End LDSAI___PSEUDNOVOGR01 -->
						</q-group-box-container>
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

	import FormViewModel from './QFormLdsaiViewModel.js'

	const requiredTextResources = ['QFormLdsai', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS LDSAI]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormLdsai',

		components: {
			QSeeMoreLdsaiOutptdocumenr: defineAsyncComponent(() => import('@/views/forms/FormLdsai/dbedits/LdsaiOutptdocumenrSeeMore.vue')),
			QSeeMoreLdsaiWarehwarehdes: defineAsyncComponent(() => import('@/views/forms/FormLdsai/dbedits/LdsaiWarehwarehdesSeeMore.vue')),
			QSeeMoreLdsaiItemItemdes: defineAsyncComponent(() => import('@/views/forms/FormLdsai/dbedits/LdsaiItemItemdesSeeMore.vue')),
			QSeeMoreLdsaiOudocnrdocsda: defineAsyncComponent(() => import('@/views/forms/FormLdsai/dbedits/LdsaiOudocnrdocsdaSeeMore.vue')),
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
					name: 'LDSAI',
					location: 'form-LDSAI',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormLdsai', false),

				interfaceMetadata: {
					id: 'QFormLdsai', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'LDSAI',
					route: 'form-LDSAI',
					area: 'OUTPU',
					primaryKey: 'ValCodoutpu',
					designation: computed(() => this.Resources.OUTPUT44370),
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
					LDSAI___OUTPTDOCUMENR: new fieldControlClass.LookupControl({
						modelField: 'TableOutptDocumenr',
						valueChangeEvent: 'fieldChange:outpt.documenr',
						id: 'LDSAI___OUTPTDOCUMENR',
						name: 'DOCUMENR',
						size: 'small',
						label: computed(() => this.Resources.DOCUMENT_NO_30174),
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
							name: 'ValCodoutpt',
							dependencyEvent: 'fieldChange:outpu.codoutpt'
						},
						dependentFields: () => ({
							set 'outpt.codoutpt'(value) { vm.model.ValCodoutpt.updateValue(value) },
							set 'outpt.documenr'(value) { vm.model.TableOutptDocumenr.updateValue(value) },
							set 'outpt.codwareh'(value) { vm.model.OutptValCodwareh.updateValue(value) },
							set 'ware1.codwareh'(value) { vm.model.OutptValCodwareh.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					LDSAI___PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'LDSAI___PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['LDSAI___OUTPULINE____', 'LDSAI___WAREHWAREHDES', 'LDSAI___ITEM_ITEMDES_', 'LDSAI___OUTPUEXITQNTY', 'LDSAI___OUDOCNRDOCSDA'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					LDSAI___OUTPULINE____: new fieldControlClass.NumberControl({
						modelField: 'ValLine',
						valueChangeEvent: 'fieldChange:outpu.line',
						id: 'LDSAI___OUTPULINE____',
						name: 'LINE',
						size: 'mini',
						label: computed(() => this.Resources.LINE27983),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'LDSAI___PSEUDNOVOGR01',
						maxIntegers: 3,
						maxDecimals: 1,
						isSequencial: true,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					LDSAI___WAREHWAREHDES: new fieldControlClass.LookupControl({
						modelField: 'TableWarehWarehdes',
						valueChangeEvent: 'fieldChange:wareh.warehdes',
						id: 'LDSAI___WAREHWAREHDES',
						name: 'WAREHDES',
						size: 'small',
						label: computed(() => this.Resources.WAREHOUSE51864),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'LDSAI___PSEUDNOVOGR01',
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
							dependencyEvent: 'fieldChange:outpu.codwareh'
						},
						dependentFields: () => ({
							set 'wareh.codwareh'(value) { vm.model.ValCodwareh.updateValue(value) },
							set 'wareh.warehdes'(value) { vm.model.TableWarehWarehdes.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					LDSAI___ITEM_ITEMDES_: new fieldControlClass.LookupControl({
						modelField: 'TableItemItemdes',
						valueChangeEvent: 'fieldChange:item.itemdes',
						id: 'LDSAI___ITEM_ITEMDES_',
						name: 'ITEMDES',
						size: 'xlarge',
						label: computed(() => this.Resources.ITEM40802),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'LDSAI___PSEUDNOVOGR01',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCoditem',
							dependencyEvent: 'fieldChange:outpu.coditem'
						},
						dependentFields: () => ({
							set 'item.coditem'(value) { vm.model.ValCoditem.updateValue(value) },
							set 'item.itemdes'(value) { vm.model.TableItemItemdes.updateValue(value) },
						}),
						controlLimits: [
							{
								identifier: ['wareh', 'outpu.codwareh'],
								dependencyEvents: ['fieldChange:outpu.codwareh'],
								dependencyField: 'OUTPU.CODWAREH',
								fnValueSelector: (model) => model.ValCodwareh.value
							},
						],
					}, this),
					LDSAI___OUTPUEXITQNTY: new fieldControlClass.NumberControl({
						modelField: 'ValExitqnty',
						valueChangeEvent: 'fieldChange:outpu.exitqnty',
						id: 'LDSAI___OUTPUEXITQNTY',
						name: 'EXITQNTY',
						size: 'small',
						label: computed(() => this.Resources.OUTPUT_QUANTITY_59942),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'LDSAI___PSEUDNOVOGR01',
						maxIntegers: 10,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					LDSAI___OUDOCNRDOCSDA: new fieldControlClass.LookupControl({
						modelField: 'TableOudocNrdocsda',
						valueChangeEvent: 'fieldChange:oudoc.nrdocsda',
						id: 'LDSAI___OUDOCNRDOCSDA',
						name: 'NRDOCSDA',
						size: 'small',
						label: computed(() => this.Resources.OUTPUT_NO41865),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'LDSAI___PSEUDNOVOGR01',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCoddocsd',
							dependencyEvent: 'fieldChange:outpu.coddocsd'
						},
						dependentFields: () => ({
							set 'oudoc.coddocsd'(value) { vm.model.ValCoddocsd.updateValue(value) },
							set 'oudoc.nrdocsda'(value) { vm.model.TableOudocNrdocsda.updateValue(value) },
						}),
						insertEnabled: true,
						supportForm: 'DOCSD',
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
					'LDSAI___PSEUDNOVOGR01',
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Item: {
						get ValItemdes() { return vm.model.TableItemItemdes.value },
						set ValItemdes(value) { vm.model.TableItemItemdes.updateValue(value) },
					},
					Oudoc: {
						get ValNrdocsda() { return vm.model.TableOudocNrdocsda.value },
						set ValNrdocsda(value) { vm.model.TableOudocNrdocsda.updateValue(value) },
					},
					Outpt: {
						get ValCodwareh() { return vm.model.OutptValCodwareh.value },
						set ValCodwareh(value) { vm.model.OutptValCodwareh.updateValue(value) },
						get ValDocumenr() { return vm.model.TableOutptDocumenr.value },
						set ValDocumenr(value) { vm.model.TableOutptDocumenr.updateValue(value) },
					},
					Outpu: {
						get ValCoddocsd() { return vm.model.ValCoddocsd.value },
						set ValCoddocsd(value) { vm.model.ValCoddocsd.updateValue(value) },
						get ValCoditem() { return vm.model.ValCoditem.value },
						set ValCoditem(value) { vm.model.ValCoditem.updateValue(value) },
						get ValCodoutpt() { return vm.model.ValCodoutpt.value },
						set ValCodoutpt(value) { vm.model.ValCodoutpt.updateValue(value) },
						get ValCodwareh() { return vm.model.ValCodwareh.value },
						set ValCodwareh(value) { vm.model.ValCodwareh.updateValue(value) },
						get ValExitqnty() { return vm.model.ValExitqnty.value },
						set ValExitqnty(value) { vm.model.ValExitqnty.updateValue(value) },
						get ValLine() { return vm.model.ValLine.value },
						set ValLine(value) { vm.model.ValLine.updateValue(value) },
					},
					Wareh: {
						get ValWarehdes() { return vm.model.TableWarehWarehdes.value },
						set ValWarehdes(value) { vm.model.TableWarehWarehdes.updateValue(value) },
					},
					keys: {
						/** The primary key of the OUTPU table */
						get outpu() { return vm.model.ValCodoutpu },
						/** The foreign key to the OUTPT table */
						get outpt() { return vm.model.ValCodoutpt },
						/** The foreign key to the WAREH table */
						get wareh() { return vm.model.ValCodwareh },
						/** The foreign key to the ITEM table */
						get item() { return vm.model.ValCoditem },
						/** The foreign key to the OUDOC table */
						get oudoc() { return vm.model.ValCoddocsd },
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
// USE /[MANUAL GQT FORM_CODEJS LDSAI]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT LDSAI]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS LDSAI]/
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
// USE /[MANUAL GQT FORM_LOADED_JS LDSAI]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS LDSAI]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS LDSAI]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS LDSAI]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS LDSAI]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS LDSAI]/
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
// USE /[MANUAL GQT AFTER_DEL_JS LDSAI]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS LDSAI]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS LDSAI]/
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
// USE /[MANUAL GQT DLGUPDT LDSAI]/
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
// USE /[MANUAL GQT CTRLBLR LDSAI]/
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
// USE /[MANUAL GQT CTRLUPD LDSAI]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS LDSAI]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
