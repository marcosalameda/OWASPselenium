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
				<component
					v-if="formControl.uiComponents.header && formInfo.designation"
					:is="topHeadingTag"
					:id="formTitleId"
					class="form-header">
					{{ formInfo.designation }}
				</component>

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
									<template v-if="btn.icon">
										<q-badge-indicator
											:enabled="btn.badge?.isVisible ?? false"
											:color="btn.badge?.color">
											<q-icon v-bind="btn.icon" />
										</q-badge-indicator>
									</template>
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
						:color="btn.color"
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

		<q-container
			fluid
			data-key="RELIN"
			:data-identifier="primaryKeyValue"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.RELIN___PSEUDNOVOGR01.isVisible">
					<q-col v-if="controls.RELIN___PSEUDNOVOGR01.isVisible">
						<q-group-box-container
							v-if="controls.RELIN___PSEUDNOVOGR01.isVisible"
							v-bind="controls.RELIN___PSEUDNOVOGR01"
							:id="getControlId(controls.RELIN___PSEUDNOVOGR01)"
							:no-border="controls.RELIN___PSEUDNOVOGR01.borderless">
							<!-- Start RELIN___PSEUDNOVOGR01 -->
							<q-row v-if="controls.RELIN___RECEINUMBER__.isVisible || controls.RELIN___ENTITNAME____.isVisible">
								<q-col
									v-if="controls.RELIN___RECEINUMBER__.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.RELIN___RECEINUMBER__.isVisible"
										class="i-text"
										v-bind="controls.RELIN___RECEINUMBER__.wrapperProps"
										:id="getControlId(controls.RELIN___RECEINUMBER__)"
										v-on="controls.RELIN___RECEINUMBER__.handlers"
										:loading="controls.RELIN___RECEINUMBER__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.RELIN___RECEINUMBER__.isVisible"
											v-bind="controls.RELIN___RECEINUMBER__.props"
											:id="getControlId(controls.RELIN___RECEINUMBER__)"
											v-on="controls.RELIN___RECEINUMBER__.handlers" />
										<q-see-more-relin-receinumber
											v-if="controls.RELIN___RECEINUMBER__.seeMoreIsVisible"
											v-bind="controls.RELIN___RECEINUMBER__.seeMoreParams"
											v-on="controls.RELIN___RECEINUMBER__.handlers" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.RELIN___ENTITNAME____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.RELIN___ENTITNAME____.isVisible"
										class="i-text"
										v-bind="controls.RELIN___ENTITNAME____.wrapperProps"
										:id="getControlId(controls.RELIN___ENTITNAME____)"
										v-on="controls.RELIN___ENTITNAME____.handlers"
										:loading="controls.RELIN___ENTITNAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.RELIN___ENTITNAME____.props"
											:id="getControlId(controls.RELIN___ENTITNAME____)"
											@blur="onBlur(controls.RELIN___ENTITNAME____, model.EntitValName.value)"
											@change="model.EntitValName.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End RELIN___PSEUDNOVOGR01 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.RELIN___PSEUDNOVOGR02.isVisible">
					<q-col v-if="controls.RELIN___PSEUDNOVOGR02.isVisible">
						<q-group-box-container
							v-if="controls.RELIN___PSEUDNOVOGR02.isVisible"
							v-bind="controls.RELIN___PSEUDNOVOGR02"
							:id="getControlId(controls.RELIN___PSEUDNOVOGR02)"
							:no-border="controls.RELIN___PSEUDNOVOGR02.borderless">
							<!-- Start RELIN___PSEUDNOVOGR02 -->
							<q-row v-if="controls.RELIN___RELINLINENUMB.isVisible">
								<q-col
									v-if="controls.RELIN___RELINLINENUMB.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.RELIN___RELINLINENUMB.isVisible"
										class="i-text"
										v-bind="controls.RELIN___RELINLINENUMB.wrapperProps"
										:id="getControlId(controls.RELIN___RELINLINENUMB)"
										v-on="controls.RELIN___RELINLINENUMB.handlers"
										:loading="controls.RELIN___RELINLINENUMB.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.RELIN___RELINLINENUMB.isVisible"
											v-bind="controls.RELIN___RELINLINENUMB.props"
											:id="getControlId(controls.RELIN___RELINLINENUMB)"
											@update:model-value="model.ValLinenumb.fnUpdateValue" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.RELIN___PRODUPRODUCT_.isVisible">
								<q-col
									v-if="controls.RELIN___PRODUPRODUCT_.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.RELIN___PRODUPRODUCT_.isVisible"
										class="i-text"
										v-bind="controls.RELIN___PRODUPRODUCT_.wrapperProps"
										:id="getControlId(controls.RELIN___PRODUPRODUCT_)"
										v-on="controls.RELIN___PRODUPRODUCT_.handlers"
										:loading="controls.RELIN___PRODUPRODUCT_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.RELIN___PRODUPRODUCT_.isVisible"
											v-bind="controls.RELIN___PRODUPRODUCT_.props"
											:id="getControlId(controls.RELIN___PRODUPRODUCT_)"
											v-on="controls.RELIN___PRODUPRODUCT_.handlers" />
										<q-see-more-relin-produproduct
											v-if="controls.RELIN___PRODUPRODUCT_.seeMoreIsVisible"
											v-bind="controls.RELIN___PRODUPRODUCT_.seeMoreParams"
											v-on="controls.RELIN___PRODUPRODUCT_.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.RELIN___RELINORDERED_.isVisible || controls.RELIN___RELINRECEIVED.isVisible || controls.RELIN___RELINOUTSTAND.isVisible">
								<q-col
									v-if="controls.RELIN___RELINORDERED_.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.RELIN___RELINORDERED_.isVisible"
										class="i-text"
										v-bind="controls.RELIN___RELINORDERED_.wrapperProps"
										:id="getControlId(controls.RELIN___RELINORDERED_)"
										v-on="controls.RELIN___RELINORDERED_.handlers"
										:loading="controls.RELIN___RELINORDERED_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.RELIN___RELINORDERED_.isVisible"
											v-bind="controls.RELIN___RELINORDERED_.props"
											:id="getControlId(controls.RELIN___RELINORDERED_)"
											@update:model-value="model.ValOrdered.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.RELIN___RELINRECEIVED.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.RELIN___RELINRECEIVED.isVisible"
										class="i-text"
										v-bind="controls.RELIN___RELINRECEIVED.wrapperProps"
										:id="getControlId(controls.RELIN___RELINRECEIVED)"
										v-on="controls.RELIN___RELINRECEIVED.handlers"
										:loading="controls.RELIN___RELINRECEIVED.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.RELIN___RELINRECEIVED.isVisible"
											v-bind="controls.RELIN___RELINRECEIVED.props"
											:id="getControlId(controls.RELIN___RELINRECEIVED)"
											@update:model-value="model.ValReceived.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.RELIN___RELINOUTSTAND.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.RELIN___RELINOUTSTAND.isVisible"
										class="i-text"
										v-bind="controls.RELIN___RELINOUTSTAND.wrapperProps"
										:id="getControlId(controls.RELIN___RELINOUTSTAND)"
										v-on="controls.RELIN___RELINOUTSTAND.handlers"
										:loading="controls.RELIN___RELINOUTSTAND.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.RELIN___RELINOUTSTAND.isVisible"
											v-bind="controls.RELIN___RELINOUTSTAND.props"
											:id="getControlId(controls.RELIN___RELINOUTSTAND)"
											@update:model-value="model.ValOutstand.fnUpdateValue" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End RELIN___PSEUDNOVOGR02 -->
						</q-group-box-container>
					</q-col>
				</q-row>
			</template>
		</q-container>
	</teleport>

	<q-divider v-if="!isPopup && showFormFooter" />

	<teleport
		v-if="formModalIsReady && showFormFooter"
		:to="`#${uiContainersId.footer}`"
		:disabled="!isPopup || isNested">
		<q-row v-if="showFormFooter">
			<div id="footer-action-btns">
				<template
					v-for="btn in formButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isActive && btn.isVisible && btn.showInFooter"
						:id="`bottom-${btn.id}`"
						:label="btn.text"
						:color="btn.color"
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
		</q-row>
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

	import FormViewModel from './QFormRelinViewModel.js'

	const requiredTextResources = ['QFormRelin', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS RELIN]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormRelin',

		components: {
			QSeeMoreRelinReceinumber: defineAsyncComponent(() => import('@/views/forms/FormRelin/dbedits/RelinReceinumberSeeMore.vue')),
			QSeeMoreRelinProduproduct: defineAsyncComponent(() => import('@/views/forms/FormRelin/dbedits/RelinProduproductSeeMore.vue')),
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
					name: 'RELIN',
					location: 'form-RELIN',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormRelin', false),

				interfaceMetadata: {
					id: 'QFormRelin', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'RELIN',
					route: 'form-RELIN',
					area: 'RELIN',
					primaryKey: 'ValCoddilin',
					designation: computed(() => this.Resources.RECEIPT_LINE60287),
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
						text: computed(() => vm.Resources.GRAVAR45301),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: vm.saveForm,
						badge: {
							isVisible: computed(() => vm.model?.isDirty === true),
							color: 'highlight'
						}
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
					RELIN___PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'RELIN___PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						label: computed(() => this.Resources.RECEIPT15218),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						borderless: false,
						isCollapsible: false,
						anchored: false,
						directChildren: ['RELIN___RECEINUMBER__', 'RELIN___ENTITNAME____'],
						controlLimits: [
						],
					}, this),
					RELIN___RECEINUMBER__: new fieldControlClass.LookupControl({
						modelField: 'TableReceiNumber',
						valueChangeEvent: 'fieldChange:recei.number',
						id: 'RELIN___RECEINUMBER__',
						name: 'NUMBER',
						size: 'small',
						label: computed(() => this.Resources.RECEIPT_NUMBER31380),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'RELIN___PSEUDNOVOGR01',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodrecei',
							dependencyEvent: 'fieldChange:relin.codrecei'
						},
						dependentFields: () => ({
							set 'recei.codrecei'(value) { vm.model.ValCodrecei.updateValue(value) },
							set 'recei.number'(value) { vm.model.TableReceiNumber.updateValue(value) },
							set 'relin.codentit'(value) { vm.model.ValCodentit.updateValue(value) },
							set 'entit.codentit'(value) { vm.model.ValCodentit.updateValue(value) },
							set 'entit.name'(value) { vm.model.EntitValName.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					RELIN___ENTITNAME____: new fieldControlClass.StringControl({
						modelField: 'EntitValName',
						valueChangeEvent: 'fieldChange:entit.name',
						dependentModelField: 'ValCodentit',
						dependentChangeEvent: 'fieldChange:relin.codentit',
						id: 'RELIN___ENTITNAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.LEGAL_NAME42902),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'RELIN___PSEUDNOVOGR01',
						maxLength: 85,
						controlLimits: [
						],
					}, this),
					RELIN___PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'RELIN___PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'block',
						label: computed(() => this.Resources.RECEIPT_LINE60287),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						borderless: false,
						isCollapsible: false,
						anchored: false,
						directChildren: ['RELIN___RELINLINENUMB', 'RELIN___PRODUPRODUCT_', 'RELIN___RELINORDERED_', 'RELIN___RELINRECEIVED', 'RELIN___RELINOUTSTAND'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					RELIN___RELINLINENUMB: new fieldControlClass.NumberControl({
						modelField: 'ValLinenumb',
						valueChangeEvent: 'fieldChange:relin.linenumb',
						id: 'RELIN___RELINLINENUMB',
						name: 'LINENUMB',
						size: 'mini',
						label: computed(() => this.Resources.LINE27983),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'RELIN___PSEUDNOVOGR02',
						maxIntegers: 6,
						maxDecimals: 0,
						isSequencial: true,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					RELIN___PRODUPRODUCT_: new fieldControlClass.LookupControl({
						modelField: 'TableProduProduct',
						valueChangeEvent: 'fieldChange:produ.product',
						id: 'RELIN___PRODUPRODUCT_',
						name: 'PRODUCT',
						size: 'xxlarge',
						label: computed(() => this.Resources.PRODUCT12880),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'RELIN___PSEUDNOVOGR02',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodprodu',
							dependencyEvent: 'fieldChange:relin.codprodu'
						},
						dependentFields: () => ({
							set 'produ.codprodu'(value) { vm.model.ValCodprodu.updateValue(value) },
							set 'produ.product'(value) { vm.model.TableProduProduct.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					RELIN___RELINORDERED_: new fieldControlClass.NumberControl({
						modelField: 'ValOrdered',
						valueChangeEvent: 'fieldChange:relin.ordered',
						id: 'RELIN___RELINORDERED_',
						name: 'ORDERED',
						size: 'small',
						label: computed(() => this.Resources.ORDERED04034),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'RELIN___PSEUDNOVOGR02',
						maxIntegers: 10,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					RELIN___RELINRECEIVED: new fieldControlClass.NumberControl({
						modelField: 'ValReceived',
						valueChangeEvent: 'fieldChange:relin.received',
						id: 'RELIN___RELINRECEIVED',
						name: 'RECEIVED',
						size: 'small',
						label: computed(() => this.Resources.RECEIVED19242),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'RELIN___PSEUDNOVOGR02',
						maxIntegers: 10,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					RELIN___RELINOUTSTAND: new fieldControlClass.NumberControl({
						modelField: 'ValOutstand',
						valueChangeEvent: 'fieldChange:relin.outstand',
						id: 'RELIN___RELINOUTSTAND',
						name: 'OUTSTAND',
						size: 'small',
						label: computed(() => this.Resources.OUTSTANDING36400),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'RELIN___PSEUDNOVOGR02',
						isFormulaBlocked: true,
						maxIntegers: 10,
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
					'RELIN___PSEUDNOVOGR01',
					'RELIN___PSEUDNOVOGR02',
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
						get ValName() { return vm.model.EntitValName.value },
						set ValName(value) { vm.model.EntitValName.updateValue(value) },
					},
					Produ: {
						get ValProduct() { return vm.model.TableProduProduct.value },
						set ValProduct(value) { vm.model.TableProduProduct.updateValue(value) },
					},
					Recei: {
						get ValNumber() { return vm.model.TableReceiNumber.value },
						set ValNumber(value) { vm.model.TableReceiNumber.updateValue(value) },
					},
					Relin: {
						get ValCodentit() { return vm.model.ValCodentit.value },
						set ValCodentit(value) { vm.model.ValCodentit.updateValue(value) },
						get ValCodprodu() { return vm.model.ValCodprodu.value },
						set ValCodprodu(value) { vm.model.ValCodprodu.updateValue(value) },
						get ValCodrecei() { return vm.model.ValCodrecei.value },
						set ValCodrecei(value) { vm.model.ValCodrecei.updateValue(value) },
						get ValLinenumb() { return vm.model.ValLinenumb.value },
						set ValLinenumb(value) { vm.model.ValLinenumb.updateValue(value) },
						get ValOrdered() { return vm.model.ValOrdered.value },
						set ValOrdered(value) { vm.model.ValOrdered.updateValue(value) },
						get ValOutstand() { return vm.model.ValOutstand.value },
						set ValOutstand(value) { vm.model.ValOutstand.updateValue(value) },
						get ValReceived() { return vm.model.ValReceived.value },
						set ValReceived(value) { vm.model.ValReceived.updateValue(value) },
					},
					keys: {
						/** The primary key of the RELIN table */
						get relin() { return vm.model.ValCoddilin },
						/** The foreign key to the RECEI table */
						get recei() { return vm.model.ValCodrecei },
						/** The foreign key to the PRODU table */
						get produ() { return vm.model.ValCodprodu },
						/** The foreign key to the ENTIT table */
						get entit() { return vm.model.ValCodentit },
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
// USE /[MANUAL GQT FORM_CODEJS RELIN]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT RELIN]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS RELIN]/
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
// USE /[MANUAL GQT FORM_LOADED_JS RELIN]/
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

				const ticketsPromise = this.model.updateFilesTickets(true)
				this.addBusy(ticketsPromise, this.Resources[hardcodedTexts.processing])
				const canSetDocums = await ticketsPromise

				if (canSetDocums)
				{
					let results
					const changesPromise = this.model.setDocumentChanges()
					this.addBusy(changesPromise, this.Resources[hardcodedTexts.processing])
					applyForm = await changesPromise

					if (applyForm)
					{
						const insertsPromise = this.model.saveDocuments()
						this.addBusy(insertsPromise, this.Resources[hardcodedTexts.processing])
						results = await insertsPromise
						applyForm = results.every((e) => e === true)
					}

					if (!changesPromise || (results && !results.every((e) => e === true)))
					{
						this.validationErrors = {
							Erro: this.Resources.OCORREU_UM_ERRO_AO_T51884
						}
					}
				}

				this.emitEvent('before-apply-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT BEFORE_APPLY_JS RELIN]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS RELIN]/
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

				const ticketsPromise = this.model.updateFilesTickets()
				this.addBusy(ticketsPromise, this.Resources[hardcodedTexts.processing])
				const canSetDocums = await ticketsPromise

				if (canSetDocums)
				{
					let results
					const changesPromise = this.model.setDocumentChanges()
					this.addBusy(changesPromise, this.Resources[hardcodedTexts.processing])
					saveForm = await changesPromise

					if (saveForm)
					{
						const insertsPromise = this.model.saveDocuments()
						this.addBusy(insertsPromise, this.Resources[hardcodedTexts.processing])
						results = await insertsPromise
						saveForm = results.every((e) => e === true)
					}

					if (!changesPromise || (results && !results.every((e) => e === true)))
					{
						this.validationErrors = {
							Erro: this.Resources.OCORREU_UM_ERRO_AO_T51884
						}
					}
				}

				this.emitEvent('before-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT BEFORE_SAVE_JS RELIN]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS RELIN]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS RELIN]/
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
// USE /[MANUAL GQT AFTER_DEL_JS RELIN]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS RELIN]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS RELIN]/
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
// USE /[MANUAL GQT DLGUPDT RELIN]/
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
// USE /[MANUAL GQT CTRLBLR RELIN]/
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
// USE /[MANUAL GQT CTRLUPD RELIN]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS RELIN]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
