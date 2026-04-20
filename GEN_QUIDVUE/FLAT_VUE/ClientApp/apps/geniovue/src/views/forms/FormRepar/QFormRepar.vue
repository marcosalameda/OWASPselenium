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
			data-key="REPAR"
			:data-identifier="primaryKeyValue"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.REPAR___EQUIPREGISTNR.isVisible || controls.REPAR___EQUIPDESIGNAT.isVisible || controls.REPAR___EQUIPPHOTOGRA.isVisible || controls.REPAR___REPARDTREPARA.isVisible || controls.REPAR___REPARNRREPARA.isVisible">
					<q-col
						v-if="controls.REPAR___EQUIPREGISTNR.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.REPAR___EQUIPREGISTNR.isVisible"
							class="i-text"
							v-bind="controls.REPAR___EQUIPREGISTNR.wrapperProps"
							:id="getControlId(controls.REPAR___EQUIPREGISTNR)"
							v-on="controls.REPAR___EQUIPREGISTNR.handlers"
							:loading="controls.REPAR___EQUIPREGISTNR.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.REPAR___EQUIPREGISTNR.isVisible"
								v-bind="controls.REPAR___EQUIPREGISTNR.props"
								:id="getControlId(controls.REPAR___EQUIPREGISTNR)"
								v-on="controls.REPAR___EQUIPREGISTNR.handlers" />
							<q-see-more-repar-equipregistnr
								v-if="controls.REPAR___EQUIPREGISTNR.seeMoreIsVisible"
								v-bind="controls.REPAR___EQUIPREGISTNR.seeMoreParams"
								v-on="controls.REPAR___EQUIPREGISTNR.handlers" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.REPAR___EQUIPDESIGNAT.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.REPAR___EQUIPDESIGNAT.isVisible"
							class="i-text"
							v-bind="controls.REPAR___EQUIPDESIGNAT.wrapperProps"
							:id="getControlId(controls.REPAR___EQUIPDESIGNAT)"
							v-on="controls.REPAR___EQUIPDESIGNAT.handlers"
							:loading="controls.REPAR___EQUIPDESIGNAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.REPAR___EQUIPDESIGNAT.props"
								:id="getControlId(controls.REPAR___EQUIPDESIGNAT)"
								@blur="onBlur(controls.REPAR___EQUIPDESIGNAT, model.EquipValDesignat.value)"
								@change="model.EquipValDesignat.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.REPAR___EQUIPPHOTOGRA.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.REPAR___EQUIPPHOTOGRA.isVisible"
							class="q-image"
							v-bind="controls.REPAR___EQUIPPHOTOGRA.wrapperProps"
							:id="getControlId(controls.REPAR___EQUIPPHOTOGRA)"
							v-on="controls.REPAR___EQUIPPHOTOGRA.handlers"
							:loading="controls.REPAR___EQUIPPHOTOGRA.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-image
								v-if="controls.REPAR___EQUIPPHOTOGRA.isVisible"
								v-bind="controls.REPAR___EQUIPPHOTOGRA.props"
								:id="getControlId(controls.REPAR___EQUIPPHOTOGRA)"
								v-on="controls.REPAR___EQUIPPHOTOGRA.handlers" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.REPAR___REPARDTREPARA.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.REPAR___REPARDTREPARA.isVisible"
							class="i-text"
							v-bind="controls.REPAR___REPARDTREPARA.wrapperProps"
							:id="getControlId(controls.REPAR___REPARDTREPARA)"
							v-on="controls.REPAR___REPARDTREPARA.handlers"
							:loading="controls.REPAR___REPARDTREPARA.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.REPAR___REPARDTREPARA.isVisible"
								v-bind="controls.REPAR___REPARDTREPARA.props"
								:id="getControlId(controls.REPAR___REPARDTREPARA)"
								:model-value="model.ValDtrepara.value"
								@reset-icon-click="model.ValDtrepara.fnUpdateValue(model.ValDtrepara.originalValue ?? new Date())"
								@update:model-value="model.ValDtrepara.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.REPAR___REPARNRREPARA.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.REPAR___REPARNRREPARA.isVisible"
							class="i-text"
							v-bind="controls.REPAR___REPARNRREPARA.wrapperProps"
							:id="getControlId(controls.REPAR___REPARNRREPARA)"
							v-on="controls.REPAR___REPARNRREPARA.handlers"
							:loading="controls.REPAR___REPARNRREPARA.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.REPAR___REPARNRREPARA.isVisible"
								v-bind="controls.REPAR___REPARNRREPARA.props"
								:id="getControlId(controls.REPAR___REPARNRREPARA)"
								@update:model-value="model.ValNrrepara.fnUpdateValue" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.REPAR___REPARTIPOAREA.isVisible">
					<q-col
						v-if="controls.REPAR___REPARTIPOAREA.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.REPAR___REPARTIPOAREA.isVisible"
							class="i-radio-container"
							v-bind="controls.REPAR___REPARTIPOAREA.wrapperProps"
							:id="getControlId(controls.REPAR___REPARTIPOAREA)"
							v-on="controls.REPAR___REPARTIPOAREA.handlers"
							:label-position="labelAlignment.topleft"
							:loading="controls.REPAR___REPARTIPOAREA.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-radio-group
								v-if="controls.REPAR___REPARTIPOAREA.isVisible"
								v-bind="controls.REPAR___REPARTIPOAREA.props"
								:id="getControlId(controls.REPAR___REPARTIPOAREA)"
								v-on="controls.REPAR___REPARTIPOAREA.handlers">
								<q-radio-button
									v-for="radio in controls.REPAR___REPARTIPOAREA.items"
									:key="radio.key"
									:label="radio.value"
									:value="radio.key" />
							</q-radio-group>
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.REPAR___SPECIESPECIAL.isVisible || controls.REPAR___PESSONAME____.isVisible">
					<q-col
						v-if="controls.REPAR___SPECIESPECIAL.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.REPAR___SPECIESPECIAL.isVisible"
							class="i-text"
							v-bind="controls.REPAR___SPECIESPECIAL.wrapperProps"
							:id="getControlId(controls.REPAR___SPECIESPECIAL)"
							v-on="controls.REPAR___SPECIESPECIAL.handlers"
							:loading="controls.REPAR___SPECIESPECIAL.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.REPAR___SPECIESPECIAL.isVisible"
								v-bind="controls.REPAR___SPECIESPECIAL.props"
								:id="getControlId(controls.REPAR___SPECIESPECIAL)"
								v-on="controls.REPAR___SPECIESPECIAL.handlers" />
							<q-see-more-repar-speciespecial
								v-if="controls.REPAR___SPECIESPECIAL.seeMoreIsVisible"
								v-bind="controls.REPAR___SPECIESPECIAL.seeMoreParams"
								v-on="controls.REPAR___SPECIESPECIAL.handlers" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.REPAR___PESSONAME____.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.REPAR___PESSONAME____.isVisible"
							class="i-text"
							v-bind="controls.REPAR___PESSONAME____.wrapperProps"
							:id="getControlId(controls.REPAR___PESSONAME____)"
							v-on="controls.REPAR___PESSONAME____.handlers"
							:loading="controls.REPAR___PESSONAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.REPAR___PESSONAME____.isVisible"
								v-bind="controls.REPAR___PESSONAME____.props"
								:id="getControlId(controls.REPAR___PESSONAME____)"
								v-on="controls.REPAR___PESSONAME____.handlers" />
							<q-see-more-repar-pessoname
								v-if="controls.REPAR___PESSONAME____.seeMoreIsVisible"
								v-bind="controls.REPAR___PESSONAME____.seeMoreParams"
								v-on="controls.REPAR___PESSONAME____.handlers" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.REPAR___REPARDESCRIPT.isVisible || controls.REPAR___REPARHOURS___.isVisible">
					<q-col
						v-if="controls.REPAR___REPARDESCRIPT.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.REPAR___REPARDESCRIPT.isVisible"
							class="i-textarea"
							v-bind="controls.REPAR___REPARDESCRIPT.wrapperProps"
							:id="getControlId(controls.REPAR___REPARDESCRIPT)"
							v-on="controls.REPAR___REPARDESCRIPT.handlers"
							:loading="controls.REPAR___REPARDESCRIPT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-area
								v-if="controls.REPAR___REPARDESCRIPT.isVisible"
								v-bind="controls.REPAR___REPARDESCRIPT.props"
								:id="getControlId(controls.REPAR___REPARDESCRIPT)"
								v-on="controls.REPAR___REPARDESCRIPT.handlers" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.REPAR___REPARHOURS___.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.REPAR___REPARHOURS___.isVisible"
							class="i-text"
							v-bind="controls.REPAR___REPARHOURS___.wrapperProps"
							:id="getControlId(controls.REPAR___REPARHOURS___)"
							v-on="controls.REPAR___REPARHOURS___.handlers"
							:loading="controls.REPAR___REPARHOURS___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.REPAR___REPARHOURS___.isVisible"
								v-bind="controls.REPAR___REPARHOURS___.props"
								:id="getControlId(controls.REPAR___REPARHOURS___)"
								@update:model-value="model.ValHours.fnUpdateValue" />
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

	import FormViewModel from './QFormReparViewModel.js'

	const requiredTextResources = ['QFormRepar', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS REPAR]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormRepar',

		components: {
			QSeeMoreReparEquipregistnr: defineAsyncComponent(() => import('@/views/forms/FormRepar/dbedits/ReparEquipregistnrSeeMore.vue')),
			QSeeMoreReparSpeciespecial: defineAsyncComponent(() => import('@/views/forms/FormRepar/dbedits/ReparSpeciespecialSeeMore.vue')),
			QSeeMoreReparPessoname: defineAsyncComponent(() => import('@/views/forms/FormRepar/dbedits/ReparPessonameSeeMore.vue')),
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
					name: 'REPAR',
					location: 'form-REPAR',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormRepar', false),

				interfaceMetadata: {
					id: 'QFormRepar', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'REPAR',
					route: 'form-REPAR',
					area: 'REPAR',
					primaryKey: 'ValCodrepar',
					designation: computed(() => this.Resources.REPAIR34508),
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
					REPAR___EQUIPREGISTNR: new fieldControlClass.LookupControl({
						modelField: 'TableEquipRegistnr',
						valueChangeEvent: 'fieldChange:equip.registnr',
						id: 'REPAR___EQUIPREGISTNR',
						name: 'REGISTNR',
						size: 'mini',
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
							dependencyEvent: 'fieldChange:repar.codequip'
						},
						dependentFields: () => ({
							set 'equip.codequip'(value) { vm.model.ValCodequip.updateValue(value) },
							set 'equip.registnr'(value) { vm.model.TableEquipRegistnr.updateValue(value) },
							set 'equip.designat'(value) { vm.model.EquipValDesignat.updateValue(value) },
							set 'equip.photogra'(value) { vm.model.EquipValPhotogra.updateValue(value) },
						}),
						insertEnabled: true,
						supportForm: 'EQUIP',
						controlLimits: [
						],
					}, this),
					REPAR___EQUIPDESIGNAT: new fieldControlClass.StringControl({
						modelField: 'EquipValDesignat',
						valueChangeEvent: 'fieldChange:equip.designat',
						dependentModelField: 'ValCodequip',
						dependentChangeEvent: 'fieldChange:repar.codequip',
						id: 'REPAR___EQUIPDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESIGNATION35876),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						controlLimits: [
						],
					}, this),
					REPAR___EQUIPPHOTOGRA: new fieldControlClass.ImageControl({
						modelField: 'EquipValPhotogra',
						valueChangeEvent: 'fieldChange:equip.photogra',
						dependentModelField: 'ValCodequip',
						dependentChangeEvent: 'fieldChange:repar.codequip',
						id: 'REPAR___EQUIPPHOTOGRA',
						name: 'PHOTOGRA',
						size: 'medium',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						height: 50,
						width: 100,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO51874)),
						controlLimits: [
						],
					}, this),
					REPAR___REPARDTREPARA: new fieldControlClass.DateControl({
						modelField: 'ValDtrepara',
						valueChangeEvent: 'fieldChange:repar.dtrepara',
						id: 'REPAR___REPARDTREPARA',
						name: 'DTREPARA',
						size: 'medium',
						label: computed(() => this.Resources.REPAIRED_ON23617),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'dateTime',
						controlLimits: [
						],
					}, this),
					REPAR___REPARNRREPARA: new fieldControlClass.NumberControl({
						modelField: 'ValNrrepara',
						valueChangeEvent: 'fieldChange:repar.nrrepara',
						id: 'REPAR___REPARNRREPARA',
						name: 'NRREPARA',
						size: 'medium',
						label: computed(() => this.Resources.COMPANY_REPAIR_NUMBE12157),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 10,
						maxDecimals: 0,
						isSequencial: true,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					REPAR___REPARTIPOAREA: new fieldControlClass.RadioGroupControl({
						modelField: 'ValTipoarea',
						valueChangeEvent: 'fieldChange:repar.tipoarea',
						id: 'REPAR___REPARTIPOAREA',
						name: 'TIPOAREA',
						label: computed(() => this.Resources.TECHNICAL_AREA50773),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 1,
						arrayName: 'AreaTecn',
						columns: 1,
						controlLimits: [
						],
					}, this),
					REPAR___SPECIESPECIAL: new fieldControlClass.LookupControl({
						modelField: 'TableSpeciEspecial',
						valueChangeEvent: 'fieldChange:speci.especial',
						id: 'REPAR___SPECIESPECIAL',
						name: 'ESPECIAL',
						size: 'xlarge',
						label: computed(() => this.Resources.SPECIALTY09304),
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
							name: 'ValCodespec',
							dependencyEvent: 'fieldChange:repar.codespec'
						},
						dependentFields: () => ({
							set 'speci.codespec'(value) { vm.model.ValCodespec.updateValue(value) },
							set 'speci.especial'(value) { vm.model.TableSpeciEspecial.updateValue(value) },
							set 'speci.areatecn'(value) { vm.model.SpeciValAreatecn.updateValue(value) },
						}),
						controlLimits: [
							{
								identifier: 'repar.tipoarea',
								dependencyEvents: ['fieldChange:repar.tipoarea'],
								dependencyField: 'REPAR.TIPOAREA',
								fnValueSelector: (model) => model.ValTipoarea.value,
							},
						],
					}, this),
					REPAR___PESSONAME____: new fieldControlClass.LookupControl({
						modelField: 'TablePessoName',
						valueChangeEvent: 'fieldChange:pesso.name',
						id: 'REPAR___PESSONAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.TECHNICIAN44001),
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
							name: 'ValCodpesso',
							dependencyEvent: 'fieldChange:repar.codpesso'
						},
						dependentFields: () => ({
							set 'pesso.codpesso'(value) { vm.model.ValCodpesso.updateValue(value) },
							set 'pesso.name'(value) { vm.model.TablePessoName.updateValue(value) },
						}),
						controlLimits: [
							{
								identifier: ['speci', 'repar.codespec'],
								dependencyEvents: ['fieldChange:repar.codespec'],
								dependencyField: 'REPAR.CODESPEC',
								fnValueSelector: (model) => model.ValCodespec.value
							},
						],
					}, this),
					REPAR___REPARDESCRIPT: new fieldControlClass.MultilineStringControl({
						modelField: 'ValDescript',
						valueChangeEvent: 'fieldChange:repar.descript',
						id: 'REPAR___REPARDESCRIPT',
						name: 'DESCRIPT',
						size: 'xxlarge',
						label: computed(() => this.Resources.REPAIR_DESCRIPTION35914),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						rows: 3,
						cols: 85,
						controlLimits: [
						],
					}, this),
					REPAR___REPARHOURS___: new fieldControlClass.NumberControl({
						modelField: 'ValHours',
						valueChangeEvent: 'fieldChange:repar.hours',
						id: 'REPAR___REPARHOURS___',
						name: 'HOURS',
						size: 'small',
						label: computed(() => this.Resources.SPENT_IN_HOURS19366),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
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
						get ValPhotogra() { return vm.model.EquipValPhotogra.value },
						set ValPhotogra(value) { vm.model.EquipValPhotogra.updateValue(value) },
						get ValRegistnr() { return vm.model.TableEquipRegistnr.value },
						set ValRegistnr(value) { vm.model.TableEquipRegistnr.updateValue(value) },
					},
					Pesso: {
						get ValName() { return vm.model.TablePessoName.value },
						set ValName(value) { vm.model.TablePessoName.updateValue(value) },
					},
					Repar: {
						get ValCodcateg() { return vm.model.ValCodcateg.value },
						set ValCodcateg(value) { vm.model.ValCodcateg.updateValue(value) },
						get ValCodempre() { return vm.model.ValCodempre.value },
						set ValCodempre(value) { vm.model.ValCodempre.updateValue(value) },
						get ValCodequip() { return vm.model.ValCodequip.value },
						set ValCodequip(value) { vm.model.ValCodequip.updateValue(value) },
						get ValCodespec() { return vm.model.ValCodespec.value },
						set ValCodespec(value) { vm.model.ValCodespec.updateValue(value) },
						get ValCodpesso() { return vm.model.ValCodpesso.value },
						set ValCodpesso(value) { vm.model.ValCodpesso.updateValue(value) },
						get ValDescript() { return vm.model.ValDescript.value },
						set ValDescript(value) { vm.model.ValDescript.updateValue(value) },
						get ValDtrepara() { return vm.model.ValDtrepara.value },
						set ValDtrepara(value) { vm.model.ValDtrepara.updateValue(value) },
						get ValHours() { return vm.model.ValHours.value },
						set ValHours(value) { vm.model.ValHours.updateValue(value) },
						get ValNrrepara() { return vm.model.ValNrrepara.value },
						set ValNrrepara(value) { vm.model.ValNrrepara.updateValue(value) },
						get ValTipoarea() { return vm.model.ValTipoarea.value },
						set ValTipoarea(value) { vm.model.ValTipoarea.updateValue(value) },
					},
					Speci: {
						get ValAreatecn() { return vm.model.SpeciValAreatecn.value },
						set ValAreatecn(value) { vm.model.SpeciValAreatecn.updateValue(value) },
						get ValEspecial() { return vm.model.TableSpeciEspecial.value },
						set ValEspecial(value) { vm.model.TableSpeciEspecial.updateValue(value) },
					},
					keys: {
						/** The primary key of the REPAR table */
						get repar() { return vm.model.ValCodrepar },
						/** The foreign key to the EQUIP table */
						get equip() { return vm.model.ValCodequip },
						/** The foreign key to the CMPNY table */
						get cmpny() { return vm.model.ValCodempre },
						/** The foreign key to the SPECI table */
						get speci() { return vm.model.ValCodespec },
						/** The foreign key to the CATE1 table */
						get cate1() { return vm.model.ValCodcateg },
						/** The foreign key to the PESSO table */
						get pesso() { return vm.model.ValCodpesso },
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
// USE /[MANUAL GQT FORM_CODEJS REPAR]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT REPAR]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS REPAR]/
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
// USE /[MANUAL GQT FORM_LOADED_JS REPAR]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS REPAR]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS REPAR]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS REPAR]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS REPAR]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS REPAR]/
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
// USE /[MANUAL GQT AFTER_DEL_JS REPAR]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS REPAR]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS REPAR]/
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
// USE /[MANUAL GQT DLGUPDT REPAR]/
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
// USE /[MANUAL GQT CTRLBLR REPAR]/
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
// USE /[MANUAL GQT CTRLUPD REPAR]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS REPAR]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
