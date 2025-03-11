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
									:label="btn.label"
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
			data-key="MESSA"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.MESSA___MESSAIDNOTIF_.isVisible">
					<q-control-wrapper
						v-show="controls.MESSA___MESSAIDNOTIF_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.MESSA___MESSAIDNOTIF_"
							v-on="controls.MESSA___MESSAIDNOTIF_.handlers"
							:loading="controls.MESSA___MESSAIDNOTIF_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.MESSA___MESSAIDNOTIF_.props"
								:model-value="model.ValIdnotif.value"
								@blur="onBlur(controls.MESSA___MESSAIDNOTIF_, model.ValIdnotif.value)"
								@change="model.ValIdnotif.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.MESSA___MESSAIDMSG___.isVisible">
					<q-control-wrapper
						v-show="controls.MESSA___MESSAIDMSG___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.MESSA___MESSAIDMSG___"
							v-on="controls.MESSA___MESSAIDMSG___.handlers"
							:loading="controls.MESSA___MESSAIDMSG___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.MESSA___MESSAIDMSG___.props"
								:model-value="model.ValIdmsg.value"
								@blur="onBlur(controls.MESSA___MESSAIDMSG___, model.ValIdmsg.value)"
								@change="model.ValIdmsg.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.MESSA___MESSAMAILSENT.isVisible">
					<q-control-wrapper
						v-show="controls.MESSA___MESSAMAILSENT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.MESSA___MESSAMAILSENT"
							v-on="controls.MESSA___MESSAMAILSENT.handlers"
							:loading="controls.MESSA___MESSAMAILSENT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox-input
									v-if="controls.MESSA___MESSAMAILSENT.isVisible"
									v-bind="controls.MESSA___MESSAMAILSENT.props"
									v-on="controls.MESSA___MESSAMAILSENT.handlers" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.MESSA___MESSAMAILERR_.isVisible">
					<q-control-wrapper
						v-show="controls.MESSA___MESSAMAILERR_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.MESSA___MESSAMAILERR_"
							v-on="controls.MESSA___MESSAMAILERR_.handlers"
							:loading="controls.MESSA___MESSAMAILERR_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.MESSA___MESSAMAILERR_.props"
								:model-value="model.ValMailerr.value"
								@blur="onBlur(controls.MESSA___MESSAMAILERR_, model.ValMailerr.value)"
								@change="model.ValMailerr.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.MESSA___ENTITNAME____.isVisible">
					<q-control-wrapper
						v-show="controls.MESSA___ENTITNAME____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.MESSA___ENTITNAME____"
							v-on="controls.MESSA___ENTITNAME____.handlers"
							:loading="controls.MESSA___ENTITNAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.MESSA___ENTITNAME____.isVisible"
								v-bind="controls.MESSA___ENTITNAME____.props"
								v-on="controls.MESSA___ENTITNAME____.handlers" />
							<q-see-more-messa-entitname
								v-if="controls.MESSA___ENTITNAME____.seeMoreIsVisible"
								v-bind="controls.MESSA___ENTITNAME____.seeMoreParams"
								v-on="controls.MESSA___ENTITNAME____.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.MESSA___PERSONAME____.isVisible">
					<q-control-wrapper
						v-show="controls.MESSA___PERSONAME____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.MESSA___PERSONAME____"
							v-on="controls.MESSA___PERSONAME____.handlers"
							:loading="controls.MESSA___PERSONAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.MESSA___PERSONAME____.isVisible"
								v-bind="controls.MESSA___PERSONAME____.props"
								v-on="controls.MESSA___PERSONAME____.handlers" />
							<q-see-more-messa-personame
								v-if="controls.MESSA___PERSONAME____.seeMoreIsVisible"
								v-bind="controls.MESSA___PERSONAME____.seeMoreParams"
								v-on="controls.MESSA___PERSONAME____.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.MESSA___MESSADOCUM_NR.isVisible || controls.MESSA___MESSADESIGNAT.isVisible || controls.MESSA___MESSAEMAIL___.isVisible">
					<q-control-wrapper
						v-show="controls.MESSA___MESSADOCUM_NR.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.MESSA___MESSADOCUM_NR"
							v-on="controls.MESSA___MESSADOCUM_NR.handlers"
							:loading="controls.MESSA___MESSADOCUM_NR.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.MESSA___MESSADOCUM_NR.isVisible"
								v-bind="controls.MESSA___MESSADOCUM_NR.props"
								@update:model-value="model.ValDocum_nr.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.MESSA___MESSADESIGNAT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.MESSA___MESSADESIGNAT"
							v-on="controls.MESSA___MESSADESIGNAT.handlers"
							:loading="controls.MESSA___MESSADESIGNAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.MESSA___MESSADESIGNAT.props"
								:model-value="model.ValDesignat.value"
								@blur="onBlur(controls.MESSA___MESSADESIGNAT, model.ValDesignat.value)"
								@change="model.ValDesignat.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.MESSA___MESSAEMAIL___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.MESSA___MESSAEMAIL___"
							v-on="controls.MESSA___MESSAEMAIL___.handlers"
							:loading="controls.MESSA___MESSAEMAIL___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.MESSA___MESSAEMAIL___.props"
								:model-value="model.ValEmail.value"
								@blur="onBlur(controls.MESSA___MESSAEMAIL___, model.ValEmail.value)"
								@change="model.ValEmail.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.MESSA___MESSAMESSAGE_.isVisible">
					<q-control-wrapper
						v-show="controls.MESSA___MESSAMESSAGE_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-textarea"
							v-bind="controls.MESSA___MESSAMESSAGE_"
							v-on="controls.MESSA___MESSAMESSAGE_.handlers"
							:loading="controls.MESSA___MESSAMESSAGE_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-textarea-input
								v-if="controls.MESSA___MESSAMESSAGE_.isVisible"
								v-bind="controls.MESSA___MESSAMESSAGE_.props"
								id="MESSA___MESSAMESSAGE_"
								:model-value="model.ValMessage.value"
								:rows="10"
								:cols="99"
								@update:model-value="model.ValMessage.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.MESSA___MESSACREATOPE.isVisible || controls.MESSA___MESSACREATDAT.isVisible">
					<q-control-wrapper
						v-show="controls.MESSA___MESSACREATOPE.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.MESSA___MESSACREATOPE"
							v-on="controls.MESSA___MESSACREATOPE.handlers"
							:loading="controls.MESSA___MESSACREATOPE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.MESSA___MESSACREATOPE.props"
								:model-value="model.ValCreatope.value" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.MESSA___MESSACREATDAT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.MESSA___MESSACREATDAT"
							v-on="controls.MESSA___MESSACREATDAT.handlers"
							:loading="controls.MESSA___MESSACREATDAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.MESSA___MESSACREATDAT.isVisible"
								v-bind="controls.MESSA___MESSACREATDAT.props"
								:model-value="model.ValCreatdat.value"
								@reset-icon-click="model.ValCreatdat.fnUpdateValue(model.ValCreatdat.originalValue ?? new Date())"
								@update:model-value="model.ValCreatdat.fnUpdateValue($event ?? '')" />
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

	import FormViewModel from './QFormMessaViewModel.js'

	const requiredTextResources = ['QFormMessa', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS MESSA]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormMessa',

		components: {
			QSeeMoreMessaEntitname: defineAsyncComponent(() => import('@/views/forms/FormMessa/dbedits/MessaEntitnameSeeMore.vue')),
			QSeeMoreMessaPersoname: defineAsyncComponent(() => import('@/views/forms/FormMessa/dbedits/MessaPersonameSeeMore.vue')),
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
					name: 'MESSA',
					location: 'form-MESSA',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormMessa', false),

				interfaceMetadata: {
					id: 'QFormMessa', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'MESSA',
					route: 'form-MESSA',
					area: 'MESSA',
					primaryKey: 'ValCodmessa',
					designation: computed(() => this.Resources.MESSAGE30602),
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
						type: 'form-insert',
						text: computed(() => vm.Resources[hardcodedTexts.insert]),
						label: computed(() => vm.Resources[hardcodedTexts.insert]),
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
						text: computed(() => vm.Resources.GRAVAR45301),
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
					}
				},

				controls: {
					MESSA___MESSAIDNOTIF_: new fieldControlClass.StringControl({
						modelField: 'ValIdnotif',
						valueChangeEvent: 'fieldChange:messa.idnotif',
						id: 'MESSA___MESSAIDNOTIF_',
						name: 'IDNOTIF',
						size: 'xlarge',
						label: computed(() => this.Resources.NOTIFICATION_ID25507),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_MESSA___MESSAIDNOTIF_',
						controlLimits: [
						],
					}, this),
					MESSA___MESSAIDMSG___: new fieldControlClass.StringControl({
						modelField: 'ValIdmsg',
						valueChangeEvent: 'fieldChange:messa.idmsg',
						id: 'MESSA___MESSAIDMSG___',
						name: 'IDMSG',
						size: 'xlarge',
						label: computed(() => this.Resources.MESSAGE_ID37133),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_MESSA___MESSAIDMSG___',
						controlLimits: [
						],
					}, this),
					MESSA___MESSAMAILSENT: new fieldControlClass.BooleanControl({
						modelField: 'ValMailsent',
						valueChangeEvent: 'fieldChange:messa.mailsent',
						id: 'MESSA___MESSAMAILSENT',
						name: 'MAILSENT',
						size: 'small',
						label: computed(() => this.Resources.E_MAIL_SENT51699),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						controlLimits: [
						],
					}, this),
					MESSA___MESSAMAILERR_: new fieldControlClass.StringControl({
						modelField: 'ValMailerr',
						valueChangeEvent: 'fieldChange:messa.mailerr',
						id: 'MESSA___MESSAMAILERR_',
						name: 'MAILERR',
						size: 'xxlarge',
						label: computed(() => this.Resources.ERROR_SENDING_MAIL44674),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 300,
						labelId: 'label_MESSA___MESSAMAILERR_',
						controlLimits: [
						],
					}, this),
					MESSA___ENTITNAME____: new fieldControlClass.LookupControl({
						modelField: 'TableEntitName',
						valueChangeEvent: 'fieldChange:entit.name',
						id: 'MESSA___ENTITNAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.ENTITY_NAME37999),
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
							dependencyEvent: 'fieldChange:messa.codentit'
						},
						dependentFields: () => ({
							set 'entit.codentit'(value) { vm.model.ValCodentit.updateValue(value) },
							set 'entit.name'(value) { vm.model.TableEntitName.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					MESSA___PERSONAME____: new fieldControlClass.LookupControl({
						modelField: 'TablePersoName',
						valueChangeEvent: 'fieldChange:perso.name',
						id: 'MESSA___PERSONAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.PERSON_NAME40980),
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
							dependencyEvent: 'fieldChange:messa.codperso'
						},
						dependentFields: () => ({
							set 'perso.codperso'(value) { vm.model.ValCodperso.updateValue(value) },
							set 'perso.name'(value) { vm.model.TablePersoName.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					MESSA___MESSADOCUM_NR: new fieldControlClass.NumberControl({
						modelField: 'ValDocum_nr',
						valueChangeEvent: 'fieldChange:messa.docum_nr',
						id: 'MESSA___MESSADOCUM_NR',
						name: 'DOCUM_NR',
						size: 'medium',
						label: computed(() => this.Resources.DOCUMENT_NUMBER28451),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 10,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					MESSA___MESSADESIGNAT: new fieldControlClass.StringControl({
						modelField: 'ValDesignat',
						valueChangeEvent: 'fieldChange:messa.designat',
						id: 'MESSA___MESSADESIGNAT',
						name: 'DESIGNAT',
						size: 'xlarge',
						label: computed(() => this.Resources.TO_WHOM_THE_MESSAGE_02337),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_MESSA___MESSADESIGNAT',
						controlLimits: [
						],
					}, this),
					MESSA___MESSAEMAIL___: new fieldControlClass.StringControl({
						modelField: 'ValEmail',
						valueChangeEvent: 'fieldChange:messa.email',
						id: 'MESSA___MESSAEMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						label: computed(() => this.Resources.E_MAIL_TO_WHOM_THE_M37668),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 254,
						labelId: 'label_MESSA___MESSAEMAIL___',
						controlLimits: [
						],
					}, this),
					MESSA___MESSAMESSAGE_: new fieldControlClass.StringControl({
						modelField: 'ValMessage',
						valueChangeEvent: 'fieldChange:messa.message',
						id: 'MESSA___MESSAMESSAGE_',
						name: 'MESSAGE',
						size: 'xxlarge',
						label: computed(() => this.Resources.MESSAGE30602),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controlLimits: [
						],
					}, this),
					MESSA___MESSACREATOPE: new fieldControlClass.StringControl({
						modelField: 'ValCreatope',
						valueChangeEvent: 'fieldChange:messa.creatope',
						id: 'MESSA___MESSACREATOPE',
						name: 'CREATOPE',
						size: 'large',
						label: computed(() => this.Resources.CREATED_BY12292),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 128,
						labelId: 'label_MESSA___MESSACREATOPE',
						controlLimits: [
						],
					}, this),
					MESSA___MESSACREATDAT: new fieldControlClass.DateControl({
						modelField: 'ValCreatdat',
						valueChangeEvent: 'fieldChange:messa.creatdat',
						id: 'MESSA___MESSACREATDAT',
						name: 'CREATDAT',
						size: 'small',
						label: computed(() => this.Resources.CREATED_ON00051),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						format: 'date',
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
					Entit: {
						get ValName() { return vm.model.TableEntitName.value },
						set ValName(value) { vm.model.TableEntitName.updateValue(value) },
					},
					Messa: {
						get ValCodentit() { return vm.model.ValCodentit.value },
						set ValCodentit(value) { vm.model.ValCodentit.updateValue(value) },
						get ValCodperso() { return vm.model.ValCodperso.value },
						set ValCodperso(value) { vm.model.ValCodperso.updateValue(value) },
						get ValCreatdat() { return vm.model.ValCreatdat.value },
						set ValCreatdat(value) { vm.model.ValCreatdat.updateValue(value) },
						get ValCreatope() { return vm.model.ValCreatope.value },
						set ValCreatope(value) { vm.model.ValCreatope.updateValue(value) },
						get ValDesignat() { return vm.model.ValDesignat.value },
						set ValDesignat(value) { vm.model.ValDesignat.updateValue(value) },
						get ValDocum_nr() { return vm.model.ValDocum_nr.value },
						set ValDocum_nr(value) { vm.model.ValDocum_nr.updateValue(value) },
						get ValEmail() { return vm.model.ValEmail.value },
						set ValEmail(value) { vm.model.ValEmail.updateValue(value) },
						get ValIdmsg() { return vm.model.ValIdmsg.value },
						set ValIdmsg(value) { vm.model.ValIdmsg.updateValue(value) },
						get ValIdnotif() { return vm.model.ValIdnotif.value },
						set ValIdnotif(value) { vm.model.ValIdnotif.updateValue(value) },
						get ValMailerr() { return vm.model.ValMailerr.value },
						set ValMailerr(value) { vm.model.ValMailerr.updateValue(value) },
						get ValMailsent() { return vm.model.ValMailsent.value },
						set ValMailsent(value) { vm.model.ValMailsent.updateValue(value) },
						get ValMessage() { return vm.model.ValMessage.value },
						set ValMessage(value) { vm.model.ValMessage.updateValue(value) },
					},
					Perso: {
						get ValName() { return vm.model.TablePersoName.value },
						set ValName(value) { vm.model.TablePersoName.updateValue(value) },
					},
					keys: {
						/** The primary key of the MESSA table */
						get messa() { return vm.model.ValCodmessa },
						/** The foreign key to the ENTIT table */
						get entit() { return vm.model.ValCodentit },
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
// USE /[MANUAL GQT FORM_CODEJS MESSA]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS MESSA]/
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
// USE /[MANUAL GQT FORM_LOADED_JS MESSA]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS MESSA]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS MESSA]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS MESSA]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS MESSA]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS MESSA]/
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
// USE /[MANUAL GQT AFTER_DEL_JS MESSA]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS MESSA]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS MESSA]/
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
// USE /[MANUAL GQT DLGUPDT MESSA]/
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
// USE /[MANUAL GQT CTRLBLR MESSA]/
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
// USE /[MANUAL GQT CTRLUPD MESSA]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS MESSA]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
