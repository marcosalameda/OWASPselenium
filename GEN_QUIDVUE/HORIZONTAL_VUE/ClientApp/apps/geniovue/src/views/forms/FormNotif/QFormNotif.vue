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
			data-key="NOTIF"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.NOTIF___NOTIFNRCOMODA.isVisible || controls.NOTIF___NOTIFBEGIN___.isVisible || controls.NOTIF___NOTIFEND_____.isVisible">
					<q-col
						v-if="controls.NOTIF___NOTIFNRCOMODA.isVisible || controls.NOTIF___NOTIFBEGIN___.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.NOTIF___NOTIFNRCOMODA.isVisible"
							class="i-text"
							v-bind="controls.NOTIF___NOTIFNRCOMODA"
							v-on="controls.NOTIF___NOTIFNRCOMODA.handlers"
							:loading="controls.NOTIF___NOTIFNRCOMODA.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.NOTIF___NOTIFNRCOMODA.isVisible"
								v-bind="controls.NOTIF___NOTIFNRCOMODA.props"
								@update:model-value="model.ValNrcomoda.fnUpdateValue" />
						</base-input-structure>
						<base-input-structure
							v-if="controls.NOTIF___NOTIFBEGIN___.isVisible"
							class="i-text"
							v-bind="controls.NOTIF___NOTIFBEGIN___"
							v-on="controls.NOTIF___NOTIFBEGIN___.handlers"
							:loading="controls.NOTIF___NOTIFBEGIN___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.NOTIF___NOTIFBEGIN___.isVisible"
								v-bind="controls.NOTIF___NOTIFBEGIN___.props"
								:model-value="model.ValBegin.value"
								@reset-icon-click="model.ValBegin.fnUpdateValue(model.ValBegin.originalValue ?? new Date())"
								@update:model-value="model.ValBegin.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.NOTIF___NOTIFEND_____.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.NOTIF___NOTIFEND_____.isVisible"
							class="i-text"
							v-bind="controls.NOTIF___NOTIFEND_____"
							v-on="controls.NOTIF___NOTIFEND_____.handlers"
							:loading="controls.NOTIF___NOTIFEND_____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.NOTIF___NOTIFEND_____.isVisible"
								v-bind="controls.NOTIF___NOTIFEND_____.props"
								:model-value="model.ValEnd.value"
								@reset-icon-click="model.ValEnd.fnUpdateValue(model.ValEnd.originalValue ?? new Date())"
								@update:model-value="model.ValEnd.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.NOTIF___NOTIFEMAIL___.isVisible">
					<q-col
						v-if="controls.NOTIF___NOTIFEMAIL___.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.NOTIF___NOTIFEMAIL___.isVisible"
							class="i-text"
							v-bind="controls.NOTIF___NOTIFEMAIL___"
							v-on="controls.NOTIF___NOTIFEMAIL___.handlers"
							:loading="controls.NOTIF___NOTIFEMAIL___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.NOTIF___NOTIFEMAIL___.props"
								@blur="onBlur(controls.NOTIF___NOTIFEMAIL___, model.ValEmail.value)"
								@change="model.ValEmail.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.NOTIF___NOTIFIDNOTIF_.isVisible">
					<q-col
						v-if="controls.NOTIF___NOTIFIDNOTIF_.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.NOTIF___NOTIFIDNOTIF_.isVisible"
							class="i-text"
							v-bind="controls.NOTIF___NOTIFIDNOTIF_"
							v-on="controls.NOTIF___NOTIFIDNOTIF_.handlers"
							:loading="controls.NOTIF___NOTIFIDNOTIF_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.NOTIF___NOTIFIDNOTIF_.props"
								@blur="onBlur(controls.NOTIF___NOTIFIDNOTIF_, model.ValIdnotif.value)"
								@change="model.ValIdnotif.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.NOTIF___NOTIFIDMSG___.isVisible">
					<q-col
						v-if="controls.NOTIF___NOTIFIDMSG___.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.NOTIF___NOTIFIDMSG___.isVisible"
							class="i-text"
							v-bind="controls.NOTIF___NOTIFIDMSG___"
							v-on="controls.NOTIF___NOTIFIDMSG___.handlers"
							:loading="controls.NOTIF___NOTIFIDMSG___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.NOTIF___NOTIFIDMSG___.props"
								@blur="onBlur(controls.NOTIF___NOTIFIDMSG___, model.ValIdmsg.value)"
								@change="model.ValIdmsg.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.NOTIF___NOTIFMESSAGE_.isVisible">
					<q-col
						v-if="controls.NOTIF___NOTIFMESSAGE_.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.NOTIF___NOTIFMESSAGE_.isVisible"
							class="i-textarea"
							v-bind="controls.NOTIF___NOTIFMESSAGE_"
							v-on="controls.NOTIF___NOTIFMESSAGE_.handlers"
							:loading="controls.NOTIF___NOTIFMESSAGE_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-area
								v-if="controls.NOTIF___NOTIFMESSAGE_.isVisible"
								v-bind="controls.NOTIF___NOTIFMESSAGE_.props"
								v-on="controls.NOTIF___NOTIFMESSAGE_.handlers" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.NOTIF___NOTIFMAILERR_.isVisible">
					<q-col
						v-if="controls.NOTIF___NOTIFMAILERR_.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.NOTIF___NOTIFMAILERR_.isVisible"
							class="i-text"
							v-bind="controls.NOTIF___NOTIFMAILERR_"
							v-on="controls.NOTIF___NOTIFMAILERR_.handlers"
							:loading="controls.NOTIF___NOTIFMAILERR_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.NOTIF___NOTIFMAILERR_.props"
								@blur="onBlur(controls.NOTIF___NOTIFMAILERR_, model.ValMailerr.value)"
								@change="model.ValMailerr.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.NOTIF___NOTIFDESIGNAT.isVisible">
					<q-col
						v-if="controls.NOTIF___NOTIFDESIGNAT.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.NOTIF___NOTIFDESIGNAT.isVisible"
							class="i-text"
							v-bind="controls.NOTIF___NOTIFDESIGNAT"
							v-on="controls.NOTIF___NOTIFDESIGNAT.handlers"
							:loading="controls.NOTIF___NOTIFDESIGNAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.NOTIF___NOTIFDESIGNAT.props"
								@blur="onBlur(controls.NOTIF___NOTIFDESIGNAT, model.ValDesignat.value)"
								@change="model.ValDesignat.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.NOTIF___NOTIFRETURNED.isVisible || controls.NOTIF___NOTIFDTDEVOLU.isVisible">
					<q-col
						v-if="controls.NOTIF___NOTIFRETURNED.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.NOTIF___NOTIFRETURNED.isVisible"
							class="i-checkbox"
							v-bind="controls.NOTIF___NOTIFRETURNED"
							v-on="controls.NOTIF___NOTIFRETURNED.handlers"
							:loading="controls.NOTIF___NOTIFRETURNED.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox
									v-if="controls.NOTIF___NOTIFRETURNED.isVisible"
									v-bind="controls.NOTIF___NOTIFRETURNED.props"
									v-on="controls.NOTIF___NOTIFRETURNED.handlers" />
							</template>
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.NOTIF___NOTIFDTDEVOLU.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.NOTIF___NOTIFDTDEVOLU.isVisible"
							class="i-text"
							v-bind="controls.NOTIF___NOTIFDTDEVOLU"
							v-on="controls.NOTIF___NOTIFDTDEVOLU.handlers"
							:loading="controls.NOTIF___NOTIFDTDEVOLU.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.NOTIF___NOTIFDTDEVOLU.isVisible"
								v-bind="controls.NOTIF___NOTIFDTDEVOLU.props"
								:model-value="model.ValDtdevolu.value"
								@reset-icon-click="model.ValDtdevolu.fnUpdateValue(model.ValDtdevolu.originalValue ?? new Date())"
								@update:model-value="model.ValDtdevolu.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.NOTIF___PESS2NAME____.isVisible">
					<q-col
						v-if="controls.NOTIF___PESS2NAME____.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.NOTIF___PESS2NAME____.isVisible"
							class="i-text"
							v-bind="controls.NOTIF___PESS2NAME____"
							v-on="controls.NOTIF___PESS2NAME____.handlers"
							:loading="controls.NOTIF___PESS2NAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.NOTIF___PESS2NAME____.isVisible"
								v-bind="controls.NOTIF___PESS2NAME____.props"
								v-on="controls.NOTIF___PESS2NAME____.handlers" />
							<q-see-more-notif-pess2name
								v-if="controls.NOTIF___PESS2NAME____.seeMoreIsVisible"
								v-bind="controls.NOTIF___PESS2NAME____.seeMoreParams"
								v-on="controls.NOTIF___PESS2NAME____.handlers" />
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

	import FormViewModel from './QFormNotifViewModel.js'

	const requiredTextResources = ['QFormNotif', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS NOTIF]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormNotif',

		components: {
			QSeeMoreNotifPess2name: defineAsyncComponent(() => import('@/views/forms/FormNotif/dbedits/NotifPess2nameSeeMore.vue')),
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
					name: 'NOTIF',
					location: 'form-NOTIF',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormNotif', false),

				interfaceMetadata: {
					id: 'QFormNotif', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'NOTIF',
					route: 'form-NOTIF',
					area: 'NOTIF',
					primaryKey: 'ValCodnotif',
					designation: computed(() => this.Resources.NOTIFICATION15372),
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
					NOTIF___NOTIFNRCOMODA: new fieldControlClass.NumberControl({
						modelField: 'ValNrcomoda',
						valueChangeEvent: 'fieldChange:notif.nrcomoda',
						id: 'NOTIF___NOTIFNRCOMODA',
						name: 'NRCOMODA',
						size: 'small',
						label: computed(() => this.Resources.LENDING_NO14727),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 6,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					NOTIF___NOTIFBEGIN___: new fieldControlClass.DateControl({
						modelField: 'ValBegin',
						valueChangeEvent: 'fieldChange:notif.begin',
						id: 'NOTIF___NOTIFBEGIN___',
						name: 'BEGIN',
						size: 'medium',
						label: computed(() => this.Resources.START00919),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'dateTime',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					NOTIF___NOTIFEND_____: new fieldControlClass.DateControl({
						modelField: 'ValEnd',
						valueChangeEvent: 'fieldChange:notif.end',
						id: 'NOTIF___NOTIFEND_____',
						name: 'END',
						size: 'medium',
						label: computed(() => this.Resources.END47577),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'dateTime',
						controlLimits: [
						],
					}, this),
					NOTIF___NOTIFEMAIL___: new fieldControlClass.StringControl({
						modelField: 'ValEmail',
						valueChangeEvent: 'fieldChange:notif.email',
						id: 'NOTIF___NOTIFEMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						label: computed(() => this.Resources.RECEIVER_S_EMAIL60306),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 100,
						controlLimits: [
						],
					}, this),
					NOTIF___NOTIFIDNOTIF_: new fieldControlClass.StringControl({
						modelField: 'ValIdnotif',
						valueChangeEvent: 'fieldChange:notif.idnotif',
						id: 'NOTIF___NOTIFIDNOTIF_',
						name: 'IDNOTIF',
						size: 'xlarge',
						label: computed(() => this.Resources.ID_OF_THE_NOTIFICATI28920),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					NOTIF___NOTIFIDMSG___: new fieldControlClass.StringControl({
						modelField: 'ValIdmsg',
						valueChangeEvent: 'fieldChange:notif.idmsg',
						id: 'NOTIF___NOTIFIDMSG___',
						name: 'IDMSG',
						size: 'xxlarge',
						label: computed(() => this.Resources.MENSAGE_ID32109),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						controlLimits: [
						],
					}, this),
					NOTIF___NOTIFMESSAGE_: new fieldControlClass.MultilineStringControl({
						modelField: 'ValMessage',
						valueChangeEvent: 'fieldChange:notif.message',
						id: 'NOTIF___NOTIFMESSAGE_',
						name: 'MESSAGE',
						size: 'xxlarge',
						label: computed(() => this.Resources.TEXT_OF_SENT_MESSAGE03008),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						rows: 15,
						cols: 99,
						controlLimits: [
						],
					}, this),
					NOTIF___NOTIFMAILERR_: new fieldControlClass.StringControl({
						modelField: 'ValMailerr',
						valueChangeEvent: 'fieldChange:notif.mailerr',
						id: 'NOTIF___NOTIFMAILERR_',
						name: 'MAILERR',
						size: 'xxlarge',
						label: computed(() => this.Resources.ERRO_ON_SENDING_THE_05516),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 300,
						controlLimits: [
						],
					}, this),
					NOTIF___NOTIFDESIGNAT: new fieldControlClass.StringControl({
						modelField: 'ValDesignat',
						valueChangeEvent: 'fieldChange:notif.designat',
						id: 'NOTIF___NOTIFDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.RECEIVER16744),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						controlLimits: [
						],
					}, this),
					NOTIF___NOTIFRETURNED: new fieldControlClass.BooleanControl({
						modelField: 'ValReturned',
						valueChangeEvent: 'fieldChange:notif.returned',
						id: 'NOTIF___NOTIFRETURNED',
						name: 'RETURNED',
						size: 'small',
						label: computed(() => this.Resources.RETURNED01606),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						controlLimits: [
						],
					}, this),
					NOTIF___NOTIFDTDEVOLU: new fieldControlClass.DateControl({
						modelField: 'ValDtdevolu',
						valueChangeEvent: 'fieldChange:notif.dtdevolu',
						id: 'NOTIF___NOTIFDTDEVOLU',
						name: 'DTDEVOLU',
						size: 'small',
						label: computed(() => this.Resources.RETURNED01606),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					NOTIF___PESS2NAME____: new fieldControlClass.LookupControl({
						modelField: 'TablePess2Name',
						valueChangeEvent: 'fieldChange:pess2.name',
						id: 'NOTIF___PESS2NAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.NAME31974),
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
							dependencyEvent: 'fieldChange:notif.codpesso'
						},
						dependentFields: () => ({
							set 'pess2.codpesso'(value) { vm.model.ValCodpesso.updateValue(value) },
							set 'pess2.name'(value) { vm.model.TablePess2Name.updateValue(value) },
						}),
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
					Notif: {
						get ValBegin() { return vm.model.ValBegin.value },
						set ValBegin(value) { vm.model.ValBegin.updateValue(value) },
						get ValCodpesso() { return vm.model.ValCodpesso.value },
						set ValCodpesso(value) { vm.model.ValCodpesso.updateValue(value) },
						get ValCreatdat() { return vm.model.ValCreatdat.value },
						set ValCreatdat(value) { vm.model.ValCreatdat.updateValue(value) },
						get ValCreatope() { return vm.model.ValCreatope.value },
						set ValCreatope(value) { vm.model.ValCreatope.updateValue(value) },
						get ValDesignat() { return vm.model.ValDesignat.value },
						set ValDesignat(value) { vm.model.ValDesignat.updateValue(value) },
						get ValDtdevolu() { return vm.model.ValDtdevolu.value },
						set ValDtdevolu(value) { vm.model.ValDtdevolu.updateValue(value) },
						get ValEmail() { return vm.model.ValEmail.value },
						set ValEmail(value) { vm.model.ValEmail.updateValue(value) },
						get ValEnd() { return vm.model.ValEnd.value },
						set ValEnd(value) { vm.model.ValEnd.updateValue(value) },
						get ValIdmsg() { return vm.model.ValIdmsg.value },
						set ValIdmsg(value) { vm.model.ValIdmsg.updateValue(value) },
						get ValIdnotif() { return vm.model.ValIdnotif.value },
						set ValIdnotif(value) { vm.model.ValIdnotif.updateValue(value) },
						get ValMailerr() { return vm.model.ValMailerr.value },
						set ValMailerr(value) { vm.model.ValMailerr.updateValue(value) },
						get ValMessage() { return vm.model.ValMessage.value },
						set ValMessage(value) { vm.model.ValMessage.updateValue(value) },
						get ValNrcomoda() { return vm.model.ValNrcomoda.value },
						set ValNrcomoda(value) { vm.model.ValNrcomoda.updateValue(value) },
						get ValReturned() { return vm.model.ValReturned.value },
						set ValReturned(value) { vm.model.ValReturned.updateValue(value) },
					},
					Pess2: {
						get ValName() { return vm.model.TablePess2Name.value },
						set ValName(value) { vm.model.TablePess2Name.updateValue(value) },
					},
					keys: {
						/** The primary key of the NOTIF table */
						get notif() { return vm.model.ValCodnotif },
						/** The foreign key to the PESS2 table */
						get pess2() { return vm.model.ValCodpesso },
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
// USE /[MANUAL GQT FORM_CODEJS NOTIF]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT NOTIF]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS NOTIF]/
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
// USE /[MANUAL GQT FORM_LOADED_JS NOTIF]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS NOTIF]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS NOTIF]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS NOTIF]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS NOTIF]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS NOTIF]/
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
// USE /[MANUAL GQT AFTER_DEL_JS NOTIF]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS NOTIF]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS NOTIF]/
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
// USE /[MANUAL GQT DLGUPDT NOTIF]/
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
// USE /[MANUAL GQT CTRLBLR NOTIF]/
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
// USE /[MANUAL GQT CTRLUPD NOTIF]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS NOTIF]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
