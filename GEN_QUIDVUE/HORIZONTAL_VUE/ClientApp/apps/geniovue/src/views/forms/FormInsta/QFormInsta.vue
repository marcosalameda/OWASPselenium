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
			data-key="INSTA"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container
					v-show="controls.INSTA___PSEUDNOVOGR01.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.INSTA___PSEUDNOVOGR01.isVisible"
						class="row-line-group">
						<q-group-collapsible
							id="INSTA___PSEUDNOVOGR01"
							v-bind="controls.INSTA___PSEUDNOVOGR01"
							v-on="controls.INSTA___PSEUDNOVOGR01.handlers">
							<!-- Start INSTA___PSEUDNOVOGR01 -->
							<q-row-container v-show="controls.INSTA___TPEQUTIPOEQUI.isVisible">
								<q-control-wrapper
									v-show="controls.INSTA___TPEQUTIPOEQUI.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INSTA___TPEQUTIPOEQUI"
										v-on="controls.INSTA___TPEQUTIPOEQUI.handlers"
										:loading="controls.INSTA___TPEQUTIPOEQUI.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.INSTA___TPEQUTIPOEQUI.isVisible"
											v-bind="controls.INSTA___TPEQUTIPOEQUI.props"
											v-on="controls.INSTA___TPEQUTIPOEQUI.handlers" />
										<q-see-more-insta-tpequtipoequi
											v-if="controls.INSTA___TPEQUTIPOEQUI.seeMoreIsVisible"
											v-bind="controls.INSTA___TPEQUTIPOEQUI.seeMoreParams"
											v-on="controls.INSTA___TPEQUTIPOEQUI.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.INSTA___EQUIPREGISTNR.isVisible || controls.INSTA___EQUIPDESIGNAT.isVisible">
								<q-control-wrapper
									v-show="controls.INSTA___EQUIPREGISTNR.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INSTA___EQUIPREGISTNR"
										v-on="controls.INSTA___EQUIPREGISTNR.handlers"
										:loading="controls.INSTA___EQUIPREGISTNR.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.INSTA___EQUIPREGISTNR.isVisible"
											v-bind="controls.INSTA___EQUIPREGISTNR.props"
											v-on="controls.INSTA___EQUIPREGISTNR.handlers" />
										<q-see-more-insta-equipregistnr
											v-if="controls.INSTA___EQUIPREGISTNR.seeMoreIsVisible"
											v-bind="controls.INSTA___EQUIPREGISTNR.seeMoreParams"
											v-on="controls.INSTA___EQUIPREGISTNR.handlers" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.INSTA___EQUIPDESIGNAT.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INSTA___EQUIPDESIGNAT"
										v-on="controls.INSTA___EQUIPDESIGNAT.handlers"
										:loading="controls.INSTA___EQUIPDESIGNAT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.INSTA___EQUIPDESIGNAT.props"
											@blur="onBlur(controls.INSTA___EQUIPDESIGNAT, model.EquipValDesignat.value)"
											@change="model.EquipValDesignat.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.INSTA___EQUIPPHOTOGRA.isVisible">
								<q-control-wrapper
									v-show="controls.INSTA___EQUIPPHOTOGRA.isVisible"
									class="control-join-group">
									<base-input-structure
										class="q-image"
										v-bind="controls.INSTA___EQUIPPHOTOGRA"
										v-on="controls.INSTA___EQUIPPHOTOGRA.handlers"
										:loading="controls.INSTA___EQUIPPHOTOGRA.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-image
											v-if="controls.INSTA___EQUIPPHOTOGRA.isVisible"
											v-bind="controls.INSTA___EQUIPPHOTOGRA.props"
											v-on="controls.INSTA___EQUIPPHOTOGRA.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End INSTA___PSEUDNOVOGR01 -->
						</q-group-collapsible>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.INSTA___PSEUDNOVOGR02.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.INSTA___PSEUDNOVOGR02.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="INSTA___PSEUDNOVOGR02"
							v-bind="controls.INSTA___PSEUDNOVOGR02"
							:is-visible="controls.INSTA___PSEUDNOVOGR02.isVisible">
							<!-- Start INSTA___PSEUDNOVOGR02 -->
							<q-row-container v-show="controls.INSTA___INSTASINCE___.isVisible || controls.INSTA___INSTAUNTIL___.isVisible || controls.INSTA___INSTAHOURS___.isVisible || controls.INSTA___INSTAPRECOHOR.isVisible || controls.INSTA___INSTAVALUE___.isVisible">
								<q-control-wrapper
									v-show="controls.INSTA___INSTASINCE___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INSTA___INSTASINCE___"
										v-on="controls.INSTA___INSTASINCE___.handlers"
										:loading="controls.INSTA___INSTASINCE___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.INSTA___INSTASINCE___.isVisible"
											v-bind="controls.INSTA___INSTASINCE___.props"
											:model-value="model.ValSince.value"
											@reset-icon-click="model.ValSince.fnUpdateValue(model.ValSince.originalValue ?? new Date())"
											@update:model-value="model.ValSince.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.INSTA___INSTAUNTIL___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INSTA___INSTAUNTIL___"
										v-on="controls.INSTA___INSTAUNTIL___.handlers"
										:loading="controls.INSTA___INSTAUNTIL___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.INSTA___INSTAUNTIL___.isVisible"
											v-bind="controls.INSTA___INSTAUNTIL___.props"
											:model-value="model.ValUntil.value"
											@reset-icon-click="model.ValUntil.fnUpdateValue(model.ValUntil.originalValue ?? new Date())"
											@update:model-value="model.ValUntil.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.INSTA___INSTAHOURS___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INSTA___INSTAHOURS___"
										v-on="controls.INSTA___INSTAHOURS___.handlers"
										:loading="controls.INSTA___INSTAHOURS___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.INSTA___INSTAHOURS___.isVisible"
											v-bind="controls.INSTA___INSTAHOURS___.props"
											@update:model-value="model.ValHours.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.INSTA___INSTAPRECOHOR.isVisible || controls.INSTA___INSTAVALUE___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INSTA___INSTAPRECOHOR"
										v-on="controls.INSTA___INSTAPRECOHOR.handlers"
										:loading="controls.INSTA___INSTAPRECOHOR.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.INSTA___INSTAPRECOHOR.isVisible"
											v-bind="controls.INSTA___INSTAPRECOHOR.props"
											@update:model-value="model.ValPrecohor.fnUpdateValue" />
									</base-input-structure>
									<base-input-structure
										class="i-text"
										v-bind="controls.INSTA___INSTAVALUE___"
										v-on="controls.INSTA___INSTAVALUE___.handlers"
										:loading="controls.INSTA___INSTAVALUE___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.INSTA___INSTAVALUE___.isVisible"
											v-bind="controls.INSTA___INSTAVALUE___.props"
											@update:model-value="model.ValValue.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End INSTA___PSEUDNOVOGR02 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.INSTA___PSEUDNOVOGR03.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.INSTA___PSEUDNOVOGR03.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="INSTA___PSEUDNOVOGR03"
							v-bind="controls.INSTA___PSEUDNOVOGR03"
							:is-visible="controls.INSTA___PSEUDNOVOGR03.isVisible">
							<!-- Start INSTA___PSEUDNOVOGR03 -->
							<q-row-container
								v-show="controls.INSTA___INSTACOORDGEO.isVisible"
								is-large>
								<q-control-wrapper
									v-show="controls.INSTA___INSTACOORDGEO.isVisible"
									class="row-line-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INSTA___INSTACOORDGEO"
										v-on="controls.INSTA___INSTACOORDGEO.handlers"
										:loading="controls.INSTA___INSTACOORDGEO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.INSTA___INSTACOORDGEO.props"
											@blur="onBlur(controls.INSTA___INSTACOORDGEO, model.ValCoordgeo.value)"
											@change="model.ValCoordgeo.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End INSTA___PSEUDNOVOGR03 -->
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

	import FormViewModel from './QFormInstaViewModel.js'

	const requiredTextResources = ['QFormInsta', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS INSTA]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormInsta',

		components: {
			QSeeMoreInstaTpequtipoequi: defineAsyncComponent(() => import('@/views/forms/FormInsta/dbedits/InstaTpequtipoequiSeeMore.vue')),
			QSeeMoreInstaEquipregistnr: defineAsyncComponent(() => import('@/views/forms/FormInsta/dbedits/InstaEquipregistnrSeeMore.vue')),
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
					name: 'INSTA',
					location: 'form-INSTA',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormInsta', false),

				interfaceMetadata: {
					id: 'QFormInsta', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'INSTA',
					route: 'form-INSTA',
					area: 'INSTA',
					primaryKey: 'ValCodinsta',
					designation: computed(() => this.Resources.INSTALLATION12952),
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
					INSTA___PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'INSTA___PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						label: computed(() => this.Resources.EQUIPMENT03632),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: true,
						anchored: false,
						directChildren: ['INSTA___TPEQUTIPOEQUI', 'INSTA___EQUIPREGISTNR', 'INSTA___EQUIPDESIGNAT', 'INSTA___EQUIPPHOTOGRA'],
						controlLimits: [
						],
					}, this),
					INSTA___TPEQUTIPOEQUI: new fieldControlClass.LookupControl({
						modelField: 'TableTpequTipoequi',
						valueChangeEvent: 'fieldChange:tpequ.tipoequi',
						id: 'INSTA___TPEQUTIPOEQUI',
						name: 'TIPOEQUI',
						size: 'xlarge',
						label: computed(() => this.Resources.TYPE_OF_EQUIPMENT64921),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INSTA___PSEUDNOVOGR01',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodtpequ',
							dependencyEvent: 'fieldChange:insta.codtpequ'
						},
						dependentFields: () => ({
							set 'tpequ.codtpequ'(value) { vm.model.ValCodtpequ.updateValue(value) },
							set 'tpequ.tipoequi'(value) { vm.model.TableTpequTipoequi.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					INSTA___EQUIPREGISTNR: new fieldControlClass.LookupControl({
						modelField: 'TableEquipRegistnr',
						valueChangeEvent: 'fieldChange:equip.registnr',
						id: 'INSTA___EQUIPREGISTNR',
						name: 'REGISTNR',
						size: 'mini',
						label: computed(() => this.Resources.REGISTRATION_NO_06209),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INSTA___PSEUDNOVOGR01',
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
							dependencyEvent: 'fieldChange:insta.codequip'
						},
						dependentFields: () => ({
							set 'equip.codequip'(value) { vm.model.ValCodequip.updateValue(value) },
							set 'equip.registnr'(value) { vm.model.TableEquipRegistnr.updateValue(value) },
							set 'equip.designat'(value) { vm.model.EquipValDesignat.updateValue(value) },
							set 'equip.photogra'(value) { vm.model.EquipValPhotogra.updateValue(value) },
						}),
						controlLimits: [
							{
								identifier: ['tpequ', 'insta.codtpequ'],
								dependencyEvents: ['fieldChange:insta.codtpequ'],
								dependencyField: 'INSTA.CODTPEQU',
								fnValueSelector: (model) => model.ValCodtpequ.value
							},
						],
					}, this),
					INSTA___EQUIPDESIGNAT: new fieldControlClass.StringControl({
						modelField: 'EquipValDesignat',
						valueChangeEvent: 'fieldChange:equip.designat',
						dependentModelField: 'ValCodequip',
						dependentChangeEvent: 'fieldChange:insta.codequip',
						id: 'INSTA___EQUIPDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESIGNATION_35800),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INSTA___PSEUDNOVOGR01',
						maxLength: 85,
						labelId: 'label_INSTA___EQUIPDESIGNAT',
						controlLimits: [
						],
					}, this),
					INSTA___EQUIPPHOTOGRA: new fieldControlClass.ImageControl({
						modelField: 'EquipValPhotogra',
						valueChangeEvent: 'fieldChange:equip.photogra',
						dependentModelField: 'ValCodequip',
						dependentChangeEvent: 'fieldChange:insta.codequip',
						id: 'INSTA___EQUIPPHOTOGRA',
						name: 'PHOTOGRA',
						size: 'medium',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INSTA___PSEUDNOVOGR01',
						height: 50,
						width: 100,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO51874)),
						controlLimits: [
						],
					}, this),
					INSTA___PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'INSTA___PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'block',
						label: computed(() => this.Resources.COST06096),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['INSTA___INSTASINCE___', 'INSTA___INSTAUNTIL___', 'INSTA___INSTAHOURS___', 'INSTA___INSTAPRECOHOR', 'INSTA___INSTAVALUE___'],
						controlLimits: [
						],
					}, this),
					INSTA___INSTASINCE___: new fieldControlClass.DateControl({
						modelField: 'ValSince',
						valueChangeEvent: 'fieldChange:insta.since',
						id: 'INSTA___INSTASINCE___',
						name: 'SINCE',
						size: 'medium',
						label: computed(() => this.Resources.SINCE_26335),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INSTA___PSEUDNOVOGR02',
						dateTimeType: 'dateTime',
						controlLimits: [
						],
					}, this),
					INSTA___INSTAUNTIL___: new fieldControlClass.DateControl({
						modelField: 'ValUntil',
						valueChangeEvent: 'fieldChange:insta.until',
						id: 'INSTA___INSTAUNTIL___',
						name: 'UNTIL',
						size: 'medium',
						label: computed(() => this.Resources.UNTIL39173),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INSTA___PSEUDNOVOGR02',
						dateTimeType: 'dateTime',
						controlLimits: [
						],
					}, this),
					INSTA___INSTAHOURS___: new fieldControlClass.NumberControl({
						modelField: 'ValHours',
						valueChangeEvent: 'fieldChange:insta.hours',
						id: 'INSTA___INSTAHOURS___',
						name: 'HOURS',
						size: 'small',
						label: computed(() => this.Resources.QUANTITY_OF_HOURS_61426),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INSTA___PSEUDNOVOGR02',
						isFormulaBlocked: true,
						maxIntegers: 7,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					INSTA___INSTAPRECOHOR: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrecohor',
						valueChangeEvent: 'fieldChange:insta.precohor',
						id: 'INSTA___INSTAPRECOHOR',
						name: 'PRECOHOR',
						size: 'medium',
						label: computed(() => this.Resources.PRICE_PER_HOUR_37472),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INSTA___PSEUDNOVOGR02',
						isFormulaBlocked: true,
						maxIntegers: 9,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					INSTA___INSTAVALUE___: new fieldControlClass.CurrencyControl({
						modelField: 'ValValue',
						valueChangeEvent: 'fieldChange:insta.value',
						id: 'INSTA___INSTAVALUE___',
						name: 'VALUE',
						size: 'medium',
						label: computed(() => this.Resources.VALUE_48317),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INSTA___PSEUDNOVOGR02',
						isFormulaBlocked: true,
						maxIntegers: 9,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					INSTA___PSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'INSTA___PSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'block',
						label: computed(() => this.Resources.LOCAL41011),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['INSTA___INSTACOORDGEO'],
						controlLimits: [
						],
					}, this),
					INSTA___INSTACOORDGEO: new fieldControlClass.FieldSpecialRenderingControl({
						modelField: 'ValCoordgeo',
						valueChangeEvent: 'fieldChange:insta.coordgeo',
						isGeographicShape: false,
						isEuclideanCoord: false,
						id: 'INSTA___INSTACOORDGEO',
						name: 'COORDGEO',
						size: 'block',
						label: computed(() => this.Resources.GEOGRAPHIC_COORDINAT42880),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INSTA___PSEUDNOVOGR03',
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
									markerDescription: {
										allowsMultiple: true,
										sources: [
											'TPEQU.TIPOEQUI',
											'INSTA.PRECOHOR',
											'EQUIP.DESIGNAT',
										]
									},
								}),
								styleVariables: {
									allowLegend: {
										rawValue: false,
										isMapped: false
									},
									zoomLevel: {
										rawValue: 8,
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
					'INSTA___PSEUDNOVOGR01',
					'INSTA___PSEUDNOVOGR02',
					'INSTA___PSEUDNOVOGR03',
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
					Insta: {
						get ValCodequip() { return vm.model.ValCodequip.value },
						set ValCodequip(value) { vm.model.ValCodequip.updateValue(value) },
						get ValCodtpequ() { return vm.model.ValCodtpequ.value },
						set ValCodtpequ(value) { vm.model.ValCodtpequ.updateValue(value) },
						get ValCoordgeo() { return vm.model.ValCoordgeo.value },
						set ValCoordgeo(value) { vm.model.ValCoordgeo.updateValue(value) },
						get ValHours() { return vm.model.ValHours.value },
						set ValHours(value) { vm.model.ValHours.updateValue(value) },
						get ValPrecohor() { return vm.model.ValPrecohor.value },
						set ValPrecohor(value) { vm.model.ValPrecohor.updateValue(value) },
						get ValSince() { return vm.model.ValSince.value },
						set ValSince(value) { vm.model.ValSince.updateValue(value) },
						get ValUntil() { return vm.model.ValUntil.value },
						set ValUntil(value) { vm.model.ValUntil.updateValue(value) },
						get ValValue() { return vm.model.ValValue.value },
						set ValValue(value) { vm.model.ValValue.updateValue(value) },
					},
					Tpequ: {
						get ValTipoequi() { return vm.model.TableTpequTipoequi.value },
						set ValTipoequi(value) { vm.model.TableTpequTipoequi.updateValue(value) },
					},
					keys: {
						/** The primary key of the INSTA table */
						get insta() { return vm.model.ValCodinsta },
						/** The foreign key to the TPEQU table */
						get tpequ() { return vm.model.ValCodtpequ },
						/** The foreign key to the EQUIP table */
						get equip() { return vm.model.ValCodequip },
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
// USE /[MANUAL GQT FORM_CODEJS INSTA]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT INSTA]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS INSTA]/
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
// USE /[MANUAL GQT FORM_LOADED_JS INSTA]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS INSTA]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS INSTA]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS INSTA]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS INSTA]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS INSTA]/
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
// USE /[MANUAL GQT AFTER_DEL_JS INSTA]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS INSTA]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS INSTA]/
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
// USE /[MANUAL GQT DLGUPDT INSTA]/
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
// USE /[MANUAL GQT CTRLBLR INSTA]/
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
// USE /[MANUAL GQT CTRLUPD INSTA]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS INSTA]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
