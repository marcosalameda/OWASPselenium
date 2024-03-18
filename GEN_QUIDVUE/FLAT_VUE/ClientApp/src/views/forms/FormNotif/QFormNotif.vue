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
			data-key="NOTIF"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.NOTIF___NOTIFNRCOMODA.isVisible || controls.NOTIF___NOTIFBEGIN___.isVisible || controls.NOTIF___NOTIFEND_____.isVisible">
					<q-control-wrapper
						v-show="controls.NOTIF___NOTIFNRCOMODA.isVisible || controls.NOTIF___NOTIFBEGIN___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.NOTIF___NOTIFNRCOMODA"
							v-on="controls.NOTIF___NOTIFNRCOMODA.handlers"
							:loading="controls.NOTIF___NOTIFNRCOMODA.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-numeric-input
								v-if="controls.NOTIF___NOTIFNRCOMODA.isVisible"
								v-bind="controls.NOTIF___NOTIFNRCOMODA"
								:model-value="model.ValNrcomoda.value"
								@update:model-value="model.ValNrcomoda.fnUpdateValue" />
						</base-input-structure>
						<base-input-structure
							class="i-text"
							v-bind="controls.NOTIF___NOTIFBEGIN___"
							v-on="controls.NOTIF___NOTIFBEGIN___.handlers"
							:loading="controls.NOTIF___NOTIFBEGIN___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-datetime-input
								v-if="controls.NOTIF___NOTIFBEGIN___.isVisible"
								v-bind="controls.NOTIF___NOTIFBEGIN___"
								format="DateTime"
								:model-value="model.ValBegin.value"
								@update:model-value="model.ValBegin.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.NOTIF___NOTIFEND_____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.NOTIF___NOTIFEND_____"
							v-on="controls.NOTIF___NOTIFEND_____.handlers"
							:loading="controls.NOTIF___NOTIFEND_____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-datetime-input
								v-if="controls.NOTIF___NOTIFEND_____.isVisible"
								v-bind="controls.NOTIF___NOTIFEND_____"
								format="DateTime"
								:model-value="model.ValEnd.value"
								@update:model-value="model.ValEnd.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.NOTIF___NOTIFEMAIL___.isVisible">
					<q-control-wrapper
						v-show="controls.NOTIF___NOTIFEMAIL___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.NOTIF___NOTIFEMAIL___"
							v-on="controls.NOTIF___NOTIFEMAIL___.handlers"
							:loading="controls.NOTIF___NOTIFEMAIL___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.NOTIF___NOTIFEMAIL___.props"
								:model-value="model.ValEmail.value"
								@update:model-value="model.ValEmail.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.NOTIF___NOTIFIDNOTIF_.isVisible">
					<q-control-wrapper
						v-show="controls.NOTIF___NOTIFIDNOTIF_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.NOTIF___NOTIFIDNOTIF_"
							v-on="controls.NOTIF___NOTIFIDNOTIF_.handlers"
							:loading="controls.NOTIF___NOTIFIDNOTIF_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.NOTIF___NOTIFIDNOTIF_.props"
								:model-value="model.ValIdnotif.value"
								@update:model-value="model.ValIdnotif.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.NOTIF___NOTIFIDMSG___.isVisible">
					<q-control-wrapper
						v-show="controls.NOTIF___NOTIFIDMSG___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.NOTIF___NOTIFIDMSG___"
							v-on="controls.NOTIF___NOTIFIDMSG___.handlers"
							:loading="controls.NOTIF___NOTIFIDMSG___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.NOTIF___NOTIFIDMSG___.props"
								:model-value="model.ValIdmsg.value"
								@update:model-value="model.ValIdmsg.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.NOTIF___NOTIFMESSAGE_.isVisible">
					<q-control-wrapper
						v-show="controls.NOTIF___NOTIFMESSAGE_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-textarea"
							v-bind="controls.NOTIF___NOTIFMESSAGE_"
							v-on="controls.NOTIF___NOTIFMESSAGE_.handlers"
							:loading="controls.NOTIF___NOTIFMESSAGE_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-textarea-input
								v-if="controls.NOTIF___NOTIFMESSAGE_.isVisible"
								id="NOTIF___NOTIFMESSAGE_"
								size="xxlarge"
								:model-value="model.ValMessage.value"
								:rows="15"
								:cols="99"
								:is-required="controls.NOTIF___NOTIFMESSAGE_.isRequired"
								:readonly="controls.NOTIF___NOTIFMESSAGE_.readonly"
								:placeholder="controls.NOTIF___NOTIFMESSAGE_.placeholder"
								@update:model-value="model.ValMessage.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.NOTIF___NOTIFMAILERR_.isVisible">
					<q-control-wrapper
						v-show="controls.NOTIF___NOTIFMAILERR_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.NOTIF___NOTIFMAILERR_"
							v-on="controls.NOTIF___NOTIFMAILERR_.handlers"
							:loading="controls.NOTIF___NOTIFMAILERR_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.NOTIF___NOTIFMAILERR_.props"
								:model-value="model.ValMailerr.value"
								@update:model-value="model.ValMailerr.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.NOTIF___NOTIFDESIGNAT.isVisible">
					<q-control-wrapper
						v-show="controls.NOTIF___NOTIFDESIGNAT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.NOTIF___NOTIFDESIGNAT"
							v-on="controls.NOTIF___NOTIFDESIGNAT.handlers"
							:loading="controls.NOTIF___NOTIFDESIGNAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.NOTIF___NOTIFDESIGNAT.props"
								:model-value="model.ValDesignat.value"
								@update:model-value="model.ValDesignat.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.NOTIF___NOTIFRETURNED.isVisible || controls.NOTIF___NOTIFDTDEVOLU.isVisible">
					<q-control-wrapper
						v-show="controls.NOTIF___NOTIFRETURNED.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.NOTIF___NOTIFRETURNED"
							v-on="controls.NOTIF___NOTIFRETURNED.handlers"
							:loading="controls.NOTIF___NOTIFRETURNED.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<template #label>
								<q-checkbox-input
									v-if="controls.NOTIF___NOTIFRETURNED.isVisible"
									id="NOTIF___NOTIFRETURNED"
									size="small"
									:model-value="model.ValReturned.value"
									:readonly="controls.NOTIF___NOTIFRETURNED.readonly"
									@update:model-value="model.ValReturned.fnUpdateValue" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.NOTIF___NOTIFDTDEVOLU.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.NOTIF___NOTIFDTDEVOLU"
							v-on="controls.NOTIF___NOTIFDTDEVOLU.handlers"
							:loading="controls.NOTIF___NOTIFDTDEVOLU.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-datetime-input
								v-if="controls.NOTIF___NOTIFDTDEVOLU.isVisible"
								v-bind="controls.NOTIF___NOTIFDTDEVOLU"
								format="Date"
								:model-value="model.ValDtdevolu.value"
								@update:model-value="model.ValDtdevolu.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.NOTIF___PESS2NAME____.isVisible">
					<q-control-wrapper
						v-show="controls.NOTIF___PESS2NAME____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.NOTIF___PESS2NAME____"
							v-on="controls.NOTIF___PESS2NAME____.handlers"
							:loading="controls.NOTIF___PESS2NAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-lookup
								v-if="controls.NOTIF___PESS2NAME____.isVisible"
								v-bind="controls.NOTIF___PESS2NAME____.props"
								:model-value="model.ValCodpesso.value"
								v-on="controls.NOTIF___PESS2NAME____.handlers"
								@update:model-value="model.ValCodpesso.fnUpdateValue" />
							<q-see-more-notif-pess2name
								v-if="controls.NOTIF___PESS2NAME____.seeMoreIsVisible"
								v-bind="controls.NOTIF___PESS2NAME____.seeMoreParams"
								v-on="controls.NOTIF___PESS2NAME____.handlers" />
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
				default: () => {
					return {
						name: 'NOTIF',
						location: 'form-NOTIF',
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
					NOTIF___NOTIFNRCOMODA: new fieldControlClass.NumberControl({
						modelField: 'ValNrcomoda',
						valueChangeEvent: 'fieldChange:notif.nrcomoda',
						maxIntegers: 6,
						maxDecimals: 0,
						id: 'NOTIF___NOTIFNRCOMODA',
						name: 'NRCOMODA',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.LENDING_NO14727),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					NOTIF___NOTIFBEGIN___: new fieldControlClass.DateControl({
						modelField: 'ValBegin',
						valueChangeEvent: 'fieldChange:notif.begin',
						id: 'NOTIF___NOTIFBEGIN___',
						name: 'BEGIN',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.START00919),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
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
						hasLabel: true,
						label: computed(() => this.Resources.END47577),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					NOTIF___NOTIFEMAIL___: new fieldControlClass.StringControl({
						modelField: 'ValEmail',
						valueChangeEvent: 'fieldChange:notif.email',
						id: 'NOTIF___NOTIFEMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.RECEIVER_S_EMAIL60306),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 100,
						labelId: 'label_NOTIF___NOTIFEMAIL___',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					NOTIF___NOTIFIDNOTIF_: new fieldControlClass.StringControl({
						modelField: 'ValIdnotif',
						valueChangeEvent: 'fieldChange:notif.idnotif',
						id: 'NOTIF___NOTIFIDNOTIF_',
						name: 'IDNOTIF',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.ID_OF_THE_NOTIFICATI28920),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_NOTIF___NOTIFIDNOTIF_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					NOTIF___NOTIFIDMSG___: new fieldControlClass.StringControl({
						modelField: 'ValIdmsg',
						valueChangeEvent: 'fieldChange:notif.idmsg',
						id: 'NOTIF___NOTIFIDMSG___',
						name: 'IDMSG',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.MENSAGE_ID32109),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						labelId: 'label_NOTIF___NOTIFIDMSG___',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					NOTIF___NOTIFMESSAGE_: new fieldControlClass.StringControl({
						modelField: 'ValMessage',
						valueChangeEvent: 'fieldChange:notif.message',
						id: 'NOTIF___NOTIFMESSAGE_',
						name: 'MESSAGE',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.TEXT_OF_SENT_MESSAGE03008),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						labelId: 'label_NOTIF___NOTIFMESSAGE_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					NOTIF___NOTIFMAILERR_: new fieldControlClass.StringControl({
						modelField: 'ValMailerr',
						valueChangeEvent: 'fieldChange:notif.mailerr',
						id: 'NOTIF___NOTIFMAILERR_',
						name: 'MAILERR',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.ERRO_ON_SENDING_THE_05516),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 300,
						labelId: 'label_NOTIF___NOTIFMAILERR_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					NOTIF___NOTIFDESIGNAT: new fieldControlClass.StringControl({
						modelField: 'ValDesignat',
						valueChangeEvent: 'fieldChange:notif.designat',
						id: 'NOTIF___NOTIFDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.RECEIVER16744),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						labelId: 'label_NOTIF___NOTIFDESIGNAT',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					NOTIF___NOTIFRETURNED: new fieldControlClass.BooleanControl({
						modelField: 'ValReturned',
						valueChangeEvent: 'fieldChange:notif.returned',
						id: 'NOTIF___NOTIFRETURNED',
						name: 'RETURNED',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.RETURNED01606),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					NOTIF___NOTIFDTDEVOLU: new fieldControlClass.DateControl({
						modelField: 'ValDtdevolu',
						valueChangeEvent: 'fieldChange:notif.dtdevolu',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'NOTIF___NOTIFDTDEVOLU',
						name: 'DTDEVOLU',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.RETURNED01606),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					NOTIF___PESS2NAME____: new fieldControlClass.LookupControl({
						modelField: 'TablePess2Name',
						valueChangeEvent: 'fieldChange:pess2.name',
						id: 'NOTIF___PESS2NAME____',
						name: 'NAME',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.NAME31974),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodpesso',
							dependencyEvent: 'fieldChange:notif.codpesso'
						},
						dependentFields: () => {
							return {
								set 'pess2.codpesso'(value) { vm.model.ValCodpesso.updateValue(value) },
								set 'pess2.name'(value) { vm.model.TablePess2Name.updateValue(value) },
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
					extraProperties: {}
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
// USE /[MANUAL GQT BEFORE_LOAD_JS NOTIF]/
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
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

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
				for (let trigger of triggers)
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
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

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
				let redirectPage = true // Set to 'false' to cancel page redirect.

				// Execute the "After save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterSave)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT AFTER_SAVE_JS NOTIF]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS NOTIF]/
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
// USE /[MANUAL GQT AFTER_DEL_JS NOTIF]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS NOTIF]/
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
		},

		watch: {
		}
	}
</script>
