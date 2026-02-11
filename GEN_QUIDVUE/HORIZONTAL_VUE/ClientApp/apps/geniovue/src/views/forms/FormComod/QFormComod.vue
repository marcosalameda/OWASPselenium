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
									<template v-if="btn.icon">
										<q-badge-indicator
											v-if="btn.badge && btn.badge.isVisible"
											:color="btn.badge.color">
											<q-icon v-bind="btn.icon" />
										</q-badge-indicator>
										<q-icon
											v-else
											v-bind="btn.icon" />
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
			data-key="COMOD"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.COMOD___PESS1NAME____.isVisible">
					<q-col
						v-if="controls.COMOD___PESS1NAME____.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.COMOD___PESS1NAME____.isVisible"
							class="i-text"
							v-bind="controls.COMOD___PESS1NAME____"
							v-on="controls.COMOD___PESS1NAME____.handlers"
							:loading="controls.COMOD___PESS1NAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.COMOD___PESS1NAME____.isVisible"
								v-bind="controls.COMOD___PESS1NAME____.props"
								v-on="controls.COMOD___PESS1NAME____.handlers" />
							<q-see-more-comod-pess1name
								v-if="controls.COMOD___PESS1NAME____.seeMoreIsVisible"
								v-bind="controls.COMOD___PESS1NAME____.seeMoreParams"
								v-on="controls.COMOD___PESS1NAME____.handlers" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.COMOD___PESS2NAME____.isVisible || controls.COMOD___EQUIPREGISTNR.isVisible">
					<q-col
						v-if="controls.COMOD___PESS2NAME____.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.COMOD___PESS2NAME____.isVisible"
							class="i-text"
							v-bind="controls.COMOD___PESS2NAME____"
							v-on="controls.COMOD___PESS2NAME____.handlers"
							:loading="controls.COMOD___PESS2NAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.COMOD___PESS2NAME____.isVisible"
								v-bind="controls.COMOD___PESS2NAME____.props"
								v-on="controls.COMOD___PESS2NAME____.handlers" />
							<q-see-more-comod-pess2name
								v-if="controls.COMOD___PESS2NAME____.seeMoreIsVisible"
								v-bind="controls.COMOD___PESS2NAME____.seeMoreParams"
								v-on="controls.COMOD___PESS2NAME____.handlers" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.COMOD___EQUIPREGISTNR.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.COMOD___EQUIPREGISTNR.isVisible"
							class="i-text"
							v-bind="controls.COMOD___EQUIPREGISTNR"
							v-on="controls.COMOD___EQUIPREGISTNR.handlers"
							:loading="controls.COMOD___EQUIPREGISTNR.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.COMOD___EQUIPREGISTNR.isVisible"
								v-bind="controls.COMOD___EQUIPREGISTNR.props"
								v-on="controls.COMOD___EQUIPREGISTNR.handlers" />
							<q-see-more-comod-equipregistnr
								v-if="controls.COMOD___EQUIPREGISTNR.seeMoreIsVisible"
								v-bind="controls.COMOD___EQUIPREGISTNR.seeMoreParams"
								v-on="controls.COMOD___EQUIPREGISTNR.handlers" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.COMOD___EQUIPDESIGNAT.isVisible || controls.COMOD___EQUIPFREQUENC.isVisible">
					<q-col
						v-if="controls.COMOD___EQUIPDESIGNAT.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.COMOD___EQUIPDESIGNAT.isVisible"
							class="i-text"
							v-bind="controls.COMOD___EQUIPDESIGNAT"
							v-on="controls.COMOD___EQUIPDESIGNAT.handlers"
							:loading="controls.COMOD___EQUIPDESIGNAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.COMOD___EQUIPDESIGNAT.props"
								@blur="onBlur(controls.COMOD___EQUIPDESIGNAT, model.EquipValDesignat.value)"
								@change="model.EquipValDesignat.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.COMOD___EQUIPFREQUENC.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.COMOD___EQUIPFREQUENC.isVisible"
							class="i-text"
							v-bind="controls.COMOD___EQUIPFREQUENC"
							v-on="controls.COMOD___EQUIPFREQUENC.handlers"
							:loading="controls.COMOD___EQUIPFREQUENC.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-select
								v-if="controls.COMOD___EQUIPFREQUENC.isVisible"
								v-bind="controls.COMOD___EQUIPFREQUENC.props" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.COMOD___LENDILENDINNR.isVisible || controls.COMOD___LENDISTART___.isVisible || controls.COMOD___LENDIWARNDT__.isVisible || controls.COMOD___LENDIEND_____.isVisible">
					<q-col
						v-if="controls.COMOD___LENDILENDINNR.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.COMOD___LENDILENDINNR.isVisible"
							class="i-text"
							v-bind="controls.COMOD___LENDILENDINNR"
							v-on="controls.COMOD___LENDILENDINNR.handlers"
							:loading="controls.COMOD___LENDILENDINNR.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.COMOD___LENDILENDINNR.isVisible"
								v-bind="controls.COMOD___LENDILENDINNR.props"
								@update:model-value="model.ValLendinnr.fnUpdateValue" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.COMOD___LENDISTART___.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.COMOD___LENDISTART___.isVisible"
							class="i-text"
							v-bind="controls.COMOD___LENDISTART___"
							v-on="controls.COMOD___LENDISTART___.handlers"
							:loading="controls.COMOD___LENDISTART___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.COMOD___LENDISTART___.isVisible"
								v-bind="controls.COMOD___LENDISTART___.props"
								:model-value="model.ValStart.value"
								@reset-icon-click="model.ValStart.fnUpdateValue(model.ValStart.originalValue ?? new Date())"
								@update:model-value="model.ValStart.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.COMOD___LENDIWARNDT__.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.COMOD___LENDIWARNDT__.isVisible"
							class="i-text"
							v-bind="controls.COMOD___LENDIWARNDT__"
							v-on="controls.COMOD___LENDIWARNDT__.handlers"
							:loading="controls.COMOD___LENDIWARNDT__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.COMOD___LENDIWARNDT__.isVisible"
								v-bind="controls.COMOD___LENDIWARNDT__.props"
								:model-value="model.ValWarndt.value"
								@reset-icon-click="model.ValWarndt.fnUpdateValue(model.ValWarndt.originalValue ?? new Date())"
								@update:model-value="model.ValWarndt.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.COMOD___LENDIEND_____.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.COMOD___LENDIEND_____.isVisible"
							class="i-text"
							v-bind="controls.COMOD___LENDIEND_____"
							v-on="controls.COMOD___LENDIEND_____.handlers"
							:loading="controls.COMOD___LENDIEND_____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.COMOD___LENDIEND_____.isVisible"
								v-bind="controls.COMOD___LENDIEND_____.props"
								:model-value="model.ValEnd.value"
								@reset-icon-click="model.ValEnd.fnUpdateValue(model.ValEnd.originalValue ?? new Date())"
								@update:model-value="model.ValEnd.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.COMOD___LENDIOBSERVAT.isVisible">
					<q-col
						v-if="controls.COMOD___LENDIOBSERVAT.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.COMOD___LENDIOBSERVAT.isVisible"
							class="i-textarea"
							v-bind="controls.COMOD___LENDIOBSERVAT"
							v-on="controls.COMOD___LENDIOBSERVAT.handlers"
							:loading="controls.COMOD___LENDIOBSERVAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-area
								v-if="controls.COMOD___LENDIOBSERVAT.isVisible"
								v-bind="controls.COMOD___LENDIOBSERVAT.props"
								v-on="controls.COMOD___LENDIOBSERVAT.handlers" />
						</base-input-structure>
					</q-col>
				</q-row>
			</template>
		</q-container>
	</teleport>

	<hr v-if="!isPopup && showFormFooter" />

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

	import FormViewModel from './QFormComodViewModel.js'

	const requiredTextResources = ['QFormComod', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS COMOD]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormComod',

		components: {
			QSeeMoreComodPess1name: defineAsyncComponent(() => import('@/views/forms/FormComod/dbedits/ComodPess1nameSeeMore.vue')),
			QSeeMoreComodPess2name: defineAsyncComponent(() => import('@/views/forms/FormComod/dbedits/ComodPess2nameSeeMore.vue')),
			QSeeMoreComodEquipregistnr: defineAsyncComponent(() => import('@/views/forms/FormComod/dbedits/ComodEquipregistnrSeeMore.vue')),
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
					name: 'COMOD',
					location: 'form-COMOD',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormComod', false),

				interfaceMetadata: {
					id: 'QFormComod', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'COMOD',
					route: 'form-COMOD',
					area: 'LENDI',
					primaryKey: 'ValCodlendi',
					designation: '',
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
					COMOD___PESS1NAME____: new fieldControlClass.LookupControl({
						modelField: 'TablePess1Name',
						valueChangeEvent: 'fieldChange:pess1.name',
						id: 'COMOD___PESS1NAME____',
						name: 'NAME',
						size: 'xxlarge',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources._114828953),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1148_VERBOSE59791),
							}
						},
						label: computed(() => this.Resources.LENDING18782),
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
							name: 'ValCodpess1',
							dependencyEvent: 'fieldChange:lendi.codpess1'
						},
						dependentFields: () => ({
							set 'pess1.codpesso'(value) { vm.model.ValCodpess1.updateValue(value) },
							set 'pess1.name'(value) { vm.model.TablePess1Name.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					COMOD___PESS2NAME____: new fieldControlClass.LookupControl({
						modelField: 'TablePess2Name',
						valueChangeEvent: 'fieldChange:pess2.name',
						id: 'COMOD___PESS2NAME____',
						name: 'NAME',
						size: 'xxlarge',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources.____210674),
							},
						},
						label: computed(() => this.Resources.BORROWER_22692),
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
							name: 'ValCodpess2',
							dependencyEvent: 'fieldChange:lendi.codpess2'
						},
						dependentFields: () => ({
							set 'pess2.codpesso'(value) { vm.model.ValCodpess2.updateValue(value) },
							set 'pess2.name'(value) { vm.model.TablePess2Name.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					COMOD___EQUIPREGISTNR: new fieldControlClass.LookupControl({
						modelField: 'TableEquipRegistnr',
						valueChangeEvent: 'fieldChange:equip.registnr',
						id: 'COMOD___EQUIPREGISTNR',
						name: 'REGISTNR',
						size: 'medium',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources.____409508),
							},
						},
						label: computed(() => this.Resources.REGISTRATION_NO_06209),
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
							name: 'ValCodequip',
							dependencyEvent: 'fieldChange:lendi.codequip'
						},
						dependentFields: () => ({
							set 'equip.codequip'(value) { vm.model.ValCodequip.updateValue(value) },
							set 'equip.registnr'(value) { vm.model.TableEquipRegistnr.updateValue(value) },
							set 'equip.designat'(value) { vm.model.EquipValDesignat.updateValue(value) },
							set 'equip.frequenc'(value) { vm.model.EquipValFrequenc.updateValue(value) },
						}),
						insertEnabled: true,
						supportForm: 'EQUIP',
						mustBeFilled: true,
						controlLimits: [
							{
								identifier: ['pess1', 'lendi.codpess1'],
								dependencyEvents: ['fieldChange:lendi.codpess1'],
								dependencyField: 'LENDI.CODPESS1',
								fnValueSelector: (model) => model.ValCodpess1.value
							},
						],
					}, this),
					COMOD___EQUIPDESIGNAT: new fieldControlClass.StringControl({
						modelField: 'EquipValDesignat',
						valueChangeEvent: 'fieldChange:equip.designat',
						dependentModelField: 'ValCodequip',
						dependentChangeEvent: 'fieldChange:lendi.codequip',
						id: 'COMOD___EQUIPDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.EQUIPMENT03632),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						controlLimits: [
						],
					}, this),
					COMOD___EQUIPFREQUENC: new fieldControlClass.ArrayNumberControl({
						modelField: 'EquipValFrequenc',
						valueChangeEvent: 'fieldChange:equip.frequenc',
						dependentModelField: 'ValCodequip',
						dependentChangeEvent: 'fieldChange:lendi.codequip',
						id: 'COMOD___EQUIPFREQUENC',
						name: 'FREQUENC',
						size: 'medium',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources.___1438719),
							},
						},
						label: computed(() => this.Resources.LOAN_FREQUENCY00930),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 2,
						maxDecimals: 0,
						arrayName: 'FreqEmpr',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					COMOD___LENDILENDINNR: new fieldControlClass.NumberControl({
						modelField: 'ValLendinnr',
						valueChangeEvent: 'fieldChange:lendi.lendinnr',
						id: 'COMOD___LENDILENDINNR',
						name: 'LENDINNR',
						size: 'small',
						label: computed(() => this.Resources.LENDING_NO14727),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 6,
						maxDecimals: 0,
						isSequencial: true,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					COMOD___LENDISTART___: new fieldControlClass.DateControl({
						modelField: 'ValStart',
						valueChangeEvent: 'fieldChange:lendi.start',
						id: 'COMOD___LENDISTART___',
						name: 'START',
						size: 'medium',
						label: computed(() => this.Resources.START_59353),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'dateTime',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					COMOD___LENDIWARNDT__: new fieldControlClass.DateControl({
						modelField: 'ValWarndt',
						valueChangeEvent: 'fieldChange:lendi.warndt',
						id: 'COMOD___LENDIWARNDT__',
						name: 'WARNDT',
						size: 'medium',
						label: computed(() => this.Resources.WARNING52043),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						dateTimeType: 'dateTime',
						controlLimits: [
						],
					}, this),
					COMOD___LENDIEND_____: new fieldControlClass.DateControl({
						modelField: 'ValEnd',
						valueChangeEvent: 'fieldChange:lendi.end',
						id: 'COMOD___LENDIEND_____',
						name: 'END',
						size: 'medium',
						label: computed(() => this.Resources.END47577),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						dateTimeType: 'dateTime',
						controlLimits: [
						],
					}, this),
					COMOD___LENDIOBSERVAT: new fieldControlClass.MultilineStringControl({
						modelField: 'ValObservat',
						valueChangeEvent: 'fieldChange:lendi.observat',
						id: 'COMOD___LENDIOBSERVAT',
						name: 'OBSERVAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.OBSERVATION37880),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						rows: 3,
						cols: 85,
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
						get ValDesignat() { return vm.model.EquipValDesignat.value },
						set ValDesignat(value) { vm.model.EquipValDesignat.updateValue(value) },
						get ValFrequenc() { return vm.model.EquipValFrequenc.value },
						set ValFrequenc(value) { vm.model.EquipValFrequenc.updateValue(value) },
						get ValRegistnr() { return vm.model.TableEquipRegistnr.value },
						set ValRegistnr(value) { vm.model.TableEquipRegistnr.updateValue(value) },
					},
					Lendi: {
						get ValCodequip() { return vm.model.ValCodequip.value },
						set ValCodequip(value) { vm.model.ValCodequip.updateValue(value) },
						get ValCodpess1() { return vm.model.ValCodpess1.value },
						set ValCodpess1(value) { vm.model.ValCodpess1.updateValue(value) },
						get ValCodpess2() { return vm.model.ValCodpess2.value },
						set ValCodpess2(value) { vm.model.ValCodpess2.updateValue(value) },
						get ValEnd() { return vm.model.ValEnd.value },
						set ValEnd(value) { vm.model.ValEnd.updateValue(value) },
						get ValLendinnr() { return vm.model.ValLendinnr.value },
						set ValLendinnr(value) { vm.model.ValLendinnr.updateValue(value) },
						get ValObservat() { return vm.model.ValObservat.value },
						set ValObservat(value) { vm.model.ValObservat.updateValue(value) },
						get ValReturndt() { return vm.model.ValReturndt.value },
						set ValReturndt(value) { vm.model.ValReturndt.updateValue(value) },
						get ValReturned() { return vm.model.ValReturned.value },
						set ValReturned(value) { vm.model.ValReturned.updateValue(value) },
						get ValStart() { return vm.model.ValStart.value },
						set ValStart(value) { vm.model.ValStart.updateValue(value) },
						get ValWarndt() { return vm.model.ValWarndt.value },
						set ValWarndt(value) { vm.model.ValWarndt.updateValue(value) },
					},
					Pess1: {
						get ValName() { return vm.model.TablePess1Name.value },
						set ValName(value) { vm.model.TablePess1Name.updateValue(value) },
					},
					Pess2: {
						get ValName() { return vm.model.TablePess2Name.value },
						set ValName(value) { vm.model.TablePess2Name.updateValue(value) },
					},
					keys: {
						/** The primary key of the LENDI table */
						get lendi() { return vm.model.ValCodlendi },
						/** The foreign key to the PESS1 table */
						get pess1() { return vm.model.ValCodpess1 },
						/** The foreign key to the EQUIP table */
						get equip() { return vm.model.ValCodequip },
						/** The foreign key to the PESS2 table */
						get pess2() { return vm.model.ValCodpess2 },
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
// USE /[MANUAL GQT FORM_CODEJS COMOD]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT COMOD]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS COMOD]/
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
// USE /[MANUAL GQT FORM_LOADED_JS COMOD]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS COMOD]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS COMOD]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS COMOD]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS COMOD]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS COMOD]/
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
// USE /[MANUAL GQT AFTER_DEL_JS COMOD]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS COMOD]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS COMOD]/
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
// USE /[MANUAL GQT DLGUPDT COMOD]/
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
// USE /[MANUAL GQT CTRLBLR COMOD]/
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
// USE /[MANUAL GQT CTRLUPD COMOD]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS COMOD]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
