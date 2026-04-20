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
			data-key="EMPRE"
			:data-identifier="primaryKeyValue"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.EMPRE___PSEUDNOVOGR02.isVisible">
					<q-col
						v-if="controls.EMPRE___PSEUDNOVOGR02.isVisible"
						cols="auto">
						<q-group-box-container
							v-if="controls.EMPRE___PSEUDNOVOGR02.isVisible"
							v-bind="controls.EMPRE___PSEUDNOVOGR02"
							:id="getControlId(controls.EMPRE___PSEUDNOVOGR02)"
							:no-border="controls.EMPRE___PSEUDNOVOGR02.borderless">
							<!-- Start EMPRE___PSEUDNOVOGR02 -->
							<q-row v-if="controls.EMPRE___CMPNYLOGO____.isVisible">
								<q-col
									v-if="controls.EMPRE___CMPNYLOGO____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EMPRE___CMPNYLOGO____.isVisible"
										class="q-image"
										v-bind="controls.EMPRE___CMPNYLOGO____.wrapperProps"
										:id="getControlId(controls.EMPRE___CMPNYLOGO____)"
										v-on="controls.EMPRE___CMPNYLOGO____.handlers"
										:loading="controls.EMPRE___CMPNYLOGO____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-image
											v-if="controls.EMPRE___CMPNYLOGO____.isVisible"
											v-bind="controls.EMPRE___CMPNYLOGO____.props"
											:id="getControlId(controls.EMPRE___CMPNYLOGO____)"
											v-on="controls.EMPRE___CMPNYLOGO____.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End EMPRE___PSEUDNOVOGR02 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.EMPRE___PSEUDNOVOGR01.isVisible">
					<q-col
						v-if="controls.EMPRE___PSEUDNOVOGR01.isVisible"
						cols="auto">
						<q-group-box-container
							v-if="controls.EMPRE___PSEUDNOVOGR01.isVisible"
							v-bind="controls.EMPRE___PSEUDNOVOGR01"
							:id="getControlId(controls.EMPRE___PSEUDNOVOGR01)"
							:no-border="controls.EMPRE___PSEUDNOVOGR01.borderless">
							<!-- Start EMPRE___PSEUDNOVOGR01 -->
							<q-row v-if="controls.EMPRE___CMPNYACRONYM_.isVisible">
								<q-col
									v-if="controls.EMPRE___CMPNYACRONYM_.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EMPRE___CMPNYACRONYM_.isVisible"
										class="i-text"
										v-bind="controls.EMPRE___CMPNYACRONYM_.wrapperProps"
										:id="getControlId(controls.EMPRE___CMPNYACRONYM_)"
										v-on="controls.EMPRE___CMPNYACRONYM_.handlers"
										:loading="controls.EMPRE___CMPNYACRONYM_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EMPRE___CMPNYACRONYM_.props"
											:id="getControlId(controls.EMPRE___CMPNYACRONYM_)"
											@blur="onBlur(controls.EMPRE___CMPNYACRONYM_, model.ValAcronym.value)"
											@change="model.ValAcronym.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.EMPRE___CMPNYNIF_____.isVisible">
								<q-col
									v-if="controls.EMPRE___CMPNYNIF_____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EMPRE___CMPNYNIF_____.isVisible"
										class="i-text"
										v-bind="controls.EMPRE___CMPNYNIF_____.wrapperProps"
										:id="getControlId(controls.EMPRE___CMPNYNIF_____)"
										v-on="controls.EMPRE___CMPNYNIF_____.handlers"
										:loading="controls.EMPRE___CMPNYNIF_____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EMPRE___CMPNYNIF_____.props"
											:id="getControlId(controls.EMPRE___CMPNYNIF_____)"
											@blur="onBlur(controls.EMPRE___CMPNYNIF_____, model.ValNif.value)"
											@change="model.ValNif.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.EMPRE___CMPNYTELEPHON.isVisible">
								<q-col
									v-if="controls.EMPRE___CMPNYTELEPHON.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EMPRE___CMPNYTELEPHON.isVisible"
										class="i-text"
										v-bind="controls.EMPRE___CMPNYTELEPHON.wrapperProps"
										:id="getControlId(controls.EMPRE___CMPNYTELEPHON)"
										v-on="controls.EMPRE___CMPNYTELEPHON.handlers"
										:loading="controls.EMPRE___CMPNYTELEPHON.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EMPRE___CMPNYTELEPHON.props"
											:id="getControlId(controls.EMPRE___CMPNYTELEPHON)"
											@blur="onBlur(controls.EMPRE___CMPNYTELEPHON, model.ValTelephon.value)"
											@change="model.ValTelephon.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.EMPRE___CMPNYEMAIL___.isVisible">
								<q-col
									v-if="controls.EMPRE___CMPNYEMAIL___.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EMPRE___CMPNYEMAIL___.isVisible"
										class="i-text"
										v-bind="controls.EMPRE___CMPNYEMAIL___.wrapperProps"
										:id="getControlId(controls.EMPRE___CMPNYEMAIL___)"
										v-on="controls.EMPRE___CMPNYEMAIL___.handlers"
										:loading="controls.EMPRE___CMPNYEMAIL___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EMPRE___CMPNYEMAIL___.props"
											:id="getControlId(controls.EMPRE___CMPNYEMAIL___)"
											@blur="onBlur(controls.EMPRE___CMPNYEMAIL___, model.ValEmail.value)"
											@change="model.ValEmail.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End EMPRE___PSEUDNOVOGR01 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.EMPRE___CMPNYDESIGNAT.isVisible">
					<q-col
						v-if="controls.EMPRE___CMPNYDESIGNAT.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.EMPRE___CMPNYDESIGNAT.isVisible"
							class="i-text"
							v-bind="controls.EMPRE___CMPNYDESIGNAT.wrapperProps"
							:id="getControlId(controls.EMPRE___CMPNYDESIGNAT)"
							v-on="controls.EMPRE___CMPNYDESIGNAT.handlers"
							:loading="controls.EMPRE___CMPNYDESIGNAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.EMPRE___CMPNYDESIGNAT.props"
								:id="getControlId(controls.EMPRE___CMPNYDESIGNAT)"
								@blur="onBlur(controls.EMPRE___CMPNYDESIGNAT, model.ValDesignat.value)"
								@change="model.ValDesignat.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.EMPRE___PSEUDNOVOGR03.isVisible">
					<q-col v-if="controls.EMPRE___PSEUDNOVOGR03.isVisible">
						<q-group-box-container
							v-if="controls.EMPRE___PSEUDNOVOGR03.isVisible"
							v-bind="controls.EMPRE___PSEUDNOVOGR03"
							:id="getControlId(controls.EMPRE___PSEUDNOVOGR03)"
							:no-border="controls.EMPRE___PSEUDNOVOGR03.borderless">
							<!-- Start EMPRE___PSEUDNOVOGR03 -->
							<q-row v-if="controls.EMPRE___CNTRYCOUNTRY_.isVisible">
								<q-col
									v-if="controls.EMPRE___CNTRYCOUNTRY_.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EMPRE___CNTRYCOUNTRY_.isVisible"
										class="i-text"
										v-bind="controls.EMPRE___CNTRYCOUNTRY_.wrapperProps"
										:id="getControlId(controls.EMPRE___CNTRYCOUNTRY_)"
										v-on="controls.EMPRE___CNTRYCOUNTRY_.handlers"
										:loading="controls.EMPRE___CNTRYCOUNTRY_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.EMPRE___CNTRYCOUNTRY_.isVisible"
											v-bind="controls.EMPRE___CNTRYCOUNTRY_.props"
											:id="getControlId(controls.EMPRE___CNTRYCOUNTRY_)"
											v-on="controls.EMPRE___CNTRYCOUNTRY_.handlers" />
										<q-see-more-empre-cntrycountry
											v-if="controls.EMPRE___CNTRYCOUNTRY_.seeMoreIsVisible"
											v-bind="controls.EMPRE___CNTRYCOUNTRY_.seeMoreParams"
											v-on="controls.EMPRE___CNTRYCOUNTRY_.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End EMPRE___PSEUDNOVOGR03 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.EMPRE___CMPNYQTDPESSO.isVisible">
					<q-col
						v-if="controls.EMPRE___CMPNYQTDPESSO.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.EMPRE___CMPNYQTDPESSO.isVisible"
							class="i-text"
							v-bind="controls.EMPRE___CMPNYQTDPESSO.wrapperProps"
							:id="getControlId(controls.EMPRE___CMPNYQTDPESSO)"
							v-on="controls.EMPRE___CMPNYQTDPESSO.handlers"
							:loading="controls.EMPRE___CMPNYQTDPESSO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.EMPRE___CMPNYQTDPESSO.isVisible"
								v-bind="controls.EMPRE___CMPNYQTDPESSO.props"
								:id="getControlId(controls.EMPRE___CMPNYQTDPESSO)"
								@update:model-value="model.ValQtdpesso.fnUpdateValue" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.EMPRE___CMPNYHEADLOC_.isVisible">
					<q-col v-if="controls.EMPRE___CMPNYHEADLOC_.isVisible">
						<base-input-structure
							v-if="controls.EMPRE___CMPNYHEADLOC_.isVisible"
							class="i-text"
							v-bind="controls.EMPRE___CMPNYHEADLOC_.wrapperProps"
							:id="getControlId(controls.EMPRE___CMPNYHEADLOC_)"
							v-on="controls.EMPRE___CMPNYHEADLOC_.handlers"
							:loading="controls.EMPRE___CMPNYHEADLOC_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.EMPRE___CMPNYHEADLOC_.props"
								:id="getControlId(controls.EMPRE___CMPNYHEADLOC_)"
								@blur="onBlur(controls.EMPRE___CMPNYHEADLOC_, model.ValHeadloc.value)"
								@change="model.ValHeadloc.fnUpdateValueOnChange" />
						</base-input-structure>
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

	import FormViewModel from './QFormEmpreViewModel.js'

	const requiredTextResources = ['QFormEmpre', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS EMPRE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormEmpre',

		components: {
			QSeeMoreEmpreCntrycountry: defineAsyncComponent(() => import('@/views/forms/FormEmpre/dbedits/EmpreCntrycountrySeeMore.vue')),
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
					name: 'EMPRE',
					location: 'form-EMPRE',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormEmpre', false),

				interfaceMetadata: {
					id: 'QFormEmpre', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'popup',
					name: 'EMPRE',
					route: 'form-EMPRE',
					area: 'CMPNY',
					primaryKey: 'ValCodempre',
					designation: computed(() => this.Resources.COMPANY52963),
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
					EMPRE___PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'EMPRE___PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'xxlarge',
						label: computed(() => this.Resources.LOGO62483),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						borderless: false,
						isCollapsible: false,
						anchored: false,
						directChildren: ['EMPRE___CMPNYLOGO____'],
						controlLimits: [
						],
					}, this),
					EMPRE___CMPNYLOGO____: new fieldControlClass.ImageControl({
						modelField: 'ValLogo',
						valueChangeEvent: 'fieldChange:cmpny.logo',
						id: 'EMPRE___CMPNYLOGO____',
						name: 'LOGO',
						size: 'medium',
						label: computed(() => this.Resources.LOGO62483),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EMPRE___PSEUDNOVOGR02',
						height: 50,
						width: 100,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.LOGO62483)),
						controlLimits: [
						],
					}, this),
					EMPRE___PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'EMPRE___PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'xxlarge',
						label: computed(() => this.Resources.COMPANY52963),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						borderless: false,
						isCollapsible: false,
						anchored: false,
						directChildren: ['EMPRE___CMPNYACRONYM_', 'EMPRE___CMPNYNIF_____', 'EMPRE___CMPNYTELEPHON', 'EMPRE___CMPNYEMAIL___'],
						controlLimits: [
						],
					}, this),
					EMPRE___CMPNYDESIGNAT: new fieldControlClass.StringControl({
						modelField: 'ValDesignat',
						valueChangeEvent: 'fieldChange:cmpny.designat',
						id: 'EMPRE___CMPNYDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESIGNATION35876),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					EMPRE___CMPNYACRONYM_: new fieldControlClass.StringControl({
						modelField: 'ValAcronym',
						valueChangeEvent: 'fieldChange:cmpny.acronym',
						id: 'EMPRE___CMPNYACRONYM_',
						name: 'ACRONYM',
						size: 'medium',
						label: computed(() => this.Resources.ACRONYM00872),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EMPRE___PSEUDNOVOGR01',
						maxLength: 15,
						controlLimits: [
						],
					}, this),
					EMPRE___CMPNYNIF_____: new fieldControlClass.StringControl({
						modelField: 'ValNif',
						valueChangeEvent: 'fieldChange:cmpny.nif',
						id: 'EMPRE___CMPNYNIF_____',
						name: 'NIF',
						size: 'medium',
						label: computed(() => this.Resources.TAX_IDENTIFICATION_55044),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EMPRE___PSEUDNOVOGR01',
						maxLength: 15,
						controlLimits: [
						],
					}, this),
					EMPRE___CMPNYTELEPHON: new fieldControlClass.StringControl({
						modelField: 'ValTelephon',
						valueChangeEvent: 'fieldChange:cmpny.telephon',
						id: 'EMPRE___CMPNYTELEPHON',
						name: 'TELEPHON',
						size: 'medium',
						label: computed(() => this.Resources.TELEPHONE28697),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EMPRE___PSEUDNOVOGR01',
						maxLength: 20,
						controlLimits: [
						],
					}, this),
					EMPRE___CMPNYEMAIL___: new fieldControlClass.StringControl({
						modelField: 'ValEmail',
						valueChangeEvent: 'fieldChange:cmpny.email',
						id: 'EMPRE___CMPNYEMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						label: computed(() => this.Resources.EMAIL_44228),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EMPRE___PSEUDNOVOGR01',
						maxLength: 254,
						controlLimits: [
						],
					}, this),
					EMPRE___PSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'EMPRE___PSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'block',
						label: computed(() => this.Resources.ORIGIN03068),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						borderless: false,
						isCollapsible: false,
						anchored: false,
						directChildren: ['EMPRE___CNTRYCOUNTRY_'],
						controlLimits: [
						],
					}, this),
					EMPRE___CNTRYCOUNTRY_: new fieldControlClass.LookupControl({
						modelField: 'TableCntryCountry',
						valueChangeEvent: 'fieldChange:cntry.country',
						id: 'EMPRE___CNTRYCOUNTRY_',
						name: 'COUNTRY',
						size: 'xxlarge',
						label: computed(() => this.Resources.COUNTRY64133),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EMPRE___PSEUDNOVOGR03',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodcntry',
							dependencyEvent: 'fieldChange:cmpny.codcntry'
						},
						dependentFields: () => ({
							set 'cntry.codcntry'(value) { vm.model.ValCodcntry.updateValue(value) },
							set 'cntry.country'(value) { vm.model.TableCntryCountry.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					EMPRE___CMPNYQTDPESSO: new fieldControlClass.NumberControl({
						modelField: 'ValQtdpesso',
						valueChangeEvent: 'fieldChange:cmpny.qtdpesso',
						id: 'EMPRE___CMPNYQTDPESSO',
						name: 'QTDPESSO',
						size: 'medium',
						label: computed(() => this.Resources.QUANTITY_OF_PEOPLE64893),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						maxIntegers: 10,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					EMPRE___CMPNYHEADLOC_: new fieldControlClass.FieldSpecialRenderingControl({
						modelField: 'ValHeadloc',
						valueChangeEvent: 'fieldChange:cmpny.headloc',
						isGeographicShape: false,
						isEuclideanCoord: false,
						id: 'EMPRE___CMPNYHEADLOC_',
						name: 'HEADLOC',
						size: 'block',
						label: computed(() => this.Resources.HEADQUARTER_LOCATION30734),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						viewModes: [
							{
								id: 'MAP',
								type: 'map',
								subtype: 'leaflet-map',
								label: computed(() => this.Resources.MAPA24527),
								order: 1,
								implicitVariable: 'geographicData',
								implicitIsMultiple: true,
								mappingVariables: readonly({
								}),
								styleVariables: {
									allowLegend: {
										rawValue: false,
										isMapped: false
									},
									zoomLevel: {
										rawValue: -1,
										isMapped: false
									},
									minZoom: {
										rawValue: 0,
										isMapped: false
									},
									maxZoom: {
										rawValue: 18,
										isMapped: false
									},
									zoomWithCtrl: {
										rawValue: true,
										isMapped: false
									},
									fitZoom: {
										rawValue: true,
										isMapped: false
									},
									zoomDelta: {
										rawValue: 1,
										isMapped: false
									},
									boundSouthWest: {
										rawValue: undefined,
										isMapped: false
									},
									boundNorthEast: {
										rawValue: undefined,
										isMapped: false
									},
									disableSearch: {
										rawValue: false,
										isMapped: false
									},
									disableControls: {
										rawValue: false,
										isMapped: false
									},
									centerCoord: {
										rawValue: undefined,
										isMapped: false
									},
									showSourcesInDescription: {
										rawValue: true,
										isMapped: false
									},
									collapseLayerOptions: {
										rawValue: false,
										isMapped: false
									},
									crs: {
										rawValue: 'EPSG:4326',
										isMapped: false
									},
									mapHeight: {
										rawValue: '75vh',
										isMapped: false
									},
									allowMarkers: {
										rawValue: true,
										isMapped: false
									},
									allowPolylines: {
										rawValue: true,
										isMapped: false
									},
									allowPolygons: {
										rawValue: true,
										isMapped: false
									},
									allowEdit: {
										rawValue: true,
										isMapped: false
									},
									allowDrag: {
										rawValue: true,
										isMapped: false
									},
									allowCutting: {
										rawValue: true,
										isMapped: false
									},
									allowRemoval: {
										rawValue: true,
										isMapped: false
									},
									allowRotate: {
										rawValue: true,
										isMapped: false
									},
									shapeOutlineWeight: {
										rawValue: 7,
										isMapped: false
									},
									polylineColor: {
										rawValue: '#079ede',
										isMapped: false
									},
									polygonColor: {
										rawValue: '#118f13',
										isMapped: false
									},
									circleColor: {
										rawValue: '#f53505',
										isMapped: false
									},
									groupMarkersInCluster: {
										rawValue: true,
										isMapped: false
									},
									allowExporting: {
										rawValue: true,
										isMapped: false
									},
									allowCenterControl: {
										rawValue: true,
										isMapped: false
									},
									backgroundOverlay: {
										rawValue: 'OpenStreetMap',
										isMapped: false
									},
									openPopupOnHover: {
										rawValue: false,
										isMapped: false
									},
								},
								groups: {
									externalLayer: [
									],
								}
							},
						],
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
					'EMPRE___PSEUDNOVOGR02',
					'EMPRE___PSEUDNOVOGR01',
					'EMPRE___PSEUDNOVOGR03',
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Cmpny: {
						get ValAcronym() { return vm.model.ValAcronym.value },
						set ValAcronym(value) { vm.model.ValAcronym.updateValue(value) },
						get ValCodcntry() { return vm.model.ValCodcntry.value },
						set ValCodcntry(value) { vm.model.ValCodcntry.updateValue(value) },
						get ValDesignat() { return vm.model.ValDesignat.value },
						set ValDesignat(value) { vm.model.ValDesignat.updateValue(value) },
						get ValEmail() { return vm.model.ValEmail.value },
						set ValEmail(value) { vm.model.ValEmail.updateValue(value) },
						get ValHeadloc() { return vm.model.ValHeadloc.value },
						set ValHeadloc(value) { vm.model.ValHeadloc.updateValue(value) },
						get ValLogo() { return vm.model.ValLogo.value },
						set ValLogo(value) { vm.model.ValLogo.updateValue(value) },
						get ValNif() { return vm.model.ValNif.value },
						set ValNif(value) { vm.model.ValNif.updateValue(value) },
						get ValQtdpesso() { return vm.model.ValQtdpesso.value },
						set ValQtdpesso(value) { vm.model.ValQtdpesso.updateValue(value) },
						get ValTelephon() { return vm.model.ValTelephon.value },
						set ValTelephon(value) { vm.model.ValTelephon.updateValue(value) },
					},
					Cntry: {
						get ValCountry() { return vm.model.TableCntryCountry.value },
						set ValCountry(value) { vm.model.TableCntryCountry.updateValue(value) },
					},
					keys: {
						/** The primary key of the CMPNY table */
						get cmpny() { return vm.model.ValCodempre },
						/** The foreign key to the CNTRY table */
						get cntry() { return vm.model.ValCodcntry },
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
// USE /[MANUAL GQT FORM_CODEJS EMPRE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT EMPRE]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS EMPRE]/
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
// USE /[MANUAL GQT FORM_LOADED_JS EMPRE]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS EMPRE]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS EMPRE]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS EMPRE]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS EMPRE]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS EMPRE]/
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
// USE /[MANUAL GQT AFTER_DEL_JS EMPRE]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS EMPRE]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS EMPRE]/
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
// USE /[MANUAL GQT DLGUPDT EMPRE]/
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
// USE /[MANUAL GQT CTRLBLR EMPRE]/
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
// USE /[MANUAL GQT CTRLUPD EMPRE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS EMPRE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
