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
			data-key="EMPRE"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.EMPRE___PSEUDNOVOGR02.isVisible">
					<q-control-wrapper
						v-show="controls.EMPRE___PSEUDNOVOGR02.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="EMPRE___PSEUDNOVOGR02"
							v-bind="controls.EMPRE___PSEUDNOVOGR02"
							:is-visible="controls.EMPRE___PSEUDNOVOGR02.isVisible">
							<!-- Start EMPRE___PSEUDNOVOGR02 -->
							<q-row-container v-show="controls.EMPRE___CMPNYLOGO____.isVisible">
								<q-control-wrapper
									v-show="controls.EMPRE___CMPNYLOGO____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="q-image"
										v-bind="controls.EMPRE___CMPNYLOGO____"
										v-on="controls.EMPRE___CMPNYLOGO____.handlers"
										:loading="controls.EMPRE___CMPNYLOGO____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-image
											v-if="controls.EMPRE___CMPNYLOGO____.isVisible"
											v-bind="controls.EMPRE___CMPNYLOGO____.props"
											v-on="controls.EMPRE___CMPNYLOGO____.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End EMPRE___PSEUDNOVOGR02 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.EMPRE___PSEUDNOVOGR01.isVisible">
					<q-control-wrapper
						v-show="controls.EMPRE___PSEUDNOVOGR01.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="EMPRE___PSEUDNOVOGR01"
							v-bind="controls.EMPRE___PSEUDNOVOGR01"
							:is-visible="controls.EMPRE___PSEUDNOVOGR01.isVisible">
							<!-- Start EMPRE___PSEUDNOVOGR01 -->
							<q-row-container v-show="controls.EMPRE___CMPNYACRONYM_.isVisible">
								<q-control-wrapper
									v-show="controls.EMPRE___CMPNYACRONYM_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EMPRE___CMPNYACRONYM_"
										v-on="controls.EMPRE___CMPNYACRONYM_.handlers"
										:loading="controls.EMPRE___CMPNYACRONYM_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-text-field
											v-bind="controls.EMPRE___CMPNYACRONYM_.props"
											:model-value="model.ValAcronym.value"
											@update:model-value="model.ValAcronym.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.EMPRE___CMPNYNIF_____.isVisible">
								<q-control-wrapper
									v-show="controls.EMPRE___CMPNYNIF_____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EMPRE___CMPNYNIF_____"
										v-on="controls.EMPRE___CMPNYNIF_____.handlers"
										:loading="controls.EMPRE___CMPNYNIF_____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-text-field
											v-bind="controls.EMPRE___CMPNYNIF_____.props"
											:model-value="model.ValNif.value"
											@update:model-value="model.ValNif.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.EMPRE___CMPNYTELEPHON.isVisible">
								<q-control-wrapper
									v-show="controls.EMPRE___CMPNYTELEPHON.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EMPRE___CMPNYTELEPHON"
										v-on="controls.EMPRE___CMPNYTELEPHON.handlers"
										:loading="controls.EMPRE___CMPNYTELEPHON.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-text-field
											v-bind="controls.EMPRE___CMPNYTELEPHON.props"
											:model-value="model.ValTelephon.value"
											@update:model-value="model.ValTelephon.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.EMPRE___CMPNYEMAIL___.isVisible">
								<q-control-wrapper
									v-show="controls.EMPRE___CMPNYEMAIL___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EMPRE___CMPNYEMAIL___"
										v-on="controls.EMPRE___CMPNYEMAIL___.handlers"
										:loading="controls.EMPRE___CMPNYEMAIL___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-text-field
											v-bind="controls.EMPRE___CMPNYEMAIL___.props"
											:model-value="model.ValEmail.value"
											@update:model-value="model.ValEmail.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End EMPRE___PSEUDNOVOGR01 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.EMPRE___CMPNYDESIGNAT.isVisible">
					<q-control-wrapper
						v-show="controls.EMPRE___CMPNYDESIGNAT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.EMPRE___CMPNYDESIGNAT"
							v-on="controls.EMPRE___CMPNYDESIGNAT.handlers"
							:loading="controls.EMPRE___CMPNYDESIGNAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.EMPRE___CMPNYDESIGNAT.props"
								:model-value="model.ValDesignat.value"
								@update:model-value="model.ValDesignat.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.EMPRE___PSEUDNOVOGR03.isVisible || controls.EMPRE___CMPNYQTDPESSO.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.EMPRE___PSEUDNOVOGR03.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="EMPRE___PSEUDNOVOGR03"
							v-bind="controls.EMPRE___PSEUDNOVOGR03"
							:is-visible="controls.EMPRE___PSEUDNOVOGR03.isVisible">
							<!-- Start EMPRE___PSEUDNOVOGR03 -->
							<q-row-container v-show="controls.EMPRE___CNTRYCOUNTRY_.isVisible">
								<q-control-wrapper
									v-show="controls.EMPRE___CNTRYCOUNTRY_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EMPRE___CNTRYCOUNTRY_"
										v-on="controls.EMPRE___CNTRYCOUNTRY_.handlers"
										:loading="controls.EMPRE___CNTRYCOUNTRY_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-lookup
											v-if="controls.EMPRE___CNTRYCOUNTRY_.isVisible"
											v-bind="controls.EMPRE___CNTRYCOUNTRY_.props"
											:model-value="model.ValCodcntry.value"
											v-on="controls.EMPRE___CNTRYCOUNTRY_.handlers"
											@update:model-value="model.ValCodcntry.fnUpdateValue" />
										<q-see-more-empre-cntrycountry
											v-if="controls.EMPRE___CNTRYCOUNTRY_.seeMoreIsVisible"
											v-bind="controls.EMPRE___CNTRYCOUNTRY_.seeMoreParams"
											v-on="controls.EMPRE___CNTRYCOUNTRY_.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End EMPRE___PSEUDNOVOGR03 -->
						</q-group-box-container>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.EMPRE___CMPNYQTDPESSO.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.EMPRE___CMPNYQTDPESSO"
							v-on="controls.EMPRE___CMPNYQTDPESSO.handlers"
							:loading="controls.EMPRE___CMPNYQTDPESSO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-numeric-input
								v-if="controls.EMPRE___CMPNYQTDPESSO.isVisible"
								v-bind="controls.EMPRE___CMPNYQTDPESSO"
								:model-value="model.ValQtdpesso.value"
								@update:model-value="model.ValQtdpesso.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.EMPRE___CMPNYHEADLOC_.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.EMPRE___CMPNYHEADLOC_.isVisible"
						class="row-line-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.EMPRE___CMPNYHEADLOC_"
							v-on="controls.EMPRE___CMPNYHEADLOC_.handlers"
							:loading="controls.EMPRE___CMPNYHEADLOC_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.EMPRE___CMPNYHEADLOC_.props"
								:model-value="model.ValHeadloc.value"
								@update:model-value="model.ValHeadloc.fnUpdateValue" />
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
				default: () => {
					return {
						name: 'EMPRE',
						location: 'form-EMPRE',
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
					EMPRE___PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'EMPRE___PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.LOGO62483),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					EMPRE___CMPNYLOGO____: new fieldControlClass.ImageControl({
						modelField: 'ValLogo',
						valueChangeEvent: 'fieldChange:cmpny.logo',
						id: 'EMPRE___CMPNYLOGO____',
						name: 'LOGO',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.LOGO62483),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EMPRE___PSEUDNOVOGR02',
						height: 50,
						width: 100,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					EMPRE___PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'EMPRE___PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.COMPANY52963),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					EMPRE___CMPNYDESIGNAT: new fieldControlClass.StringControl({
						modelField: 'ValDesignat',
						valueChangeEvent: 'fieldChange:cmpny.designat',
						id: 'EMPRE___CMPNYDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.DESIGNATION35876),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						labelId: 'label_EMPRE___CMPNYDESIGNAT',
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
						hasLabel: true,
						label: computed(() => this.Resources.ACRONYM00872),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EMPRE___PSEUDNOVOGR01',
						maxLength: 15,
						labelId: 'label_EMPRE___CMPNYACRONYM_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					EMPRE___CMPNYNIF_____: new fieldControlClass.StringControl({
						modelField: 'ValNif',
						valueChangeEvent: 'fieldChange:cmpny.nif',
						id: 'EMPRE___CMPNYNIF_____',
						name: 'NIF',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.TAX_IDENTIFICATION_55044),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EMPRE___PSEUDNOVOGR01',
						maxLength: 15,
						labelId: 'label_EMPRE___CMPNYNIF_____',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					EMPRE___CMPNYTELEPHON: new fieldControlClass.StringControl({
						modelField: 'ValTelephon',
						valueChangeEvent: 'fieldChange:cmpny.telephon',
						id: 'EMPRE___CMPNYTELEPHON',
						name: 'TELEPHON',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.TELEPHONE28697),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EMPRE___PSEUDNOVOGR01',
						maxLength: 20,
						labelId: 'label_EMPRE___CMPNYTELEPHON',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					EMPRE___CMPNYEMAIL___: new fieldControlClass.StringControl({
						modelField: 'ValEmail',
						valueChangeEvent: 'fieldChange:cmpny.email',
						id: 'EMPRE___CMPNYEMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.EMAIL_44228),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EMPRE___PSEUDNOVOGR01',
						maxLength: 254,
						labelId: 'label_EMPRE___CMPNYEMAIL___',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					EMPRE___PSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'EMPRE___PSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.ORIGIN03068),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					EMPRE___CNTRYCOUNTRY_: new fieldControlClass.LookupControl({
						modelField: 'TableCntryCountry',
						valueChangeEvent: 'fieldChange:cntry.country',
						id: 'EMPRE___CNTRYCOUNTRY_',
						name: 'COUNTRY',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.COUNTRY64133),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EMPRE___PSEUDNOVOGR03',
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodcntry',
							dependencyEvent: 'fieldChange:cmpny.codcntry'
						},
						dependentFields: () => {
							return {
								set 'cntry.codcntry'(value) { vm.model.ValCodcntry.updateValue(value) },
								set 'cntry.country'(value) { vm.model.TableCntryCountry.updateValue(value) },
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
					EMPRE___CMPNYQTDPESSO: new fieldControlClass.NumberControl({
						modelField: 'ValQtdpesso',
						valueChangeEvent: 'fieldChange:cmpny.qtdpesso',
						maxIntegers: 10,
						maxDecimals: 0,
						id: 'EMPRE___CMPNYQTDPESSO',
						name: 'QTDPESSO',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.QUANTITY_OF_PEOPLE64893),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					EMPRE___CMPNYHEADLOC_: new fieldControlClass.FieldSpecialRenderingControl({
						modelField: 'ValHeadloc',
						valueChangeEvent: 'fieldChange:cmpny.headloc',
						isGeographicShape: false,
						isEuclideanCoord: false,
						id: 'EMPRE___CMPNYHEADLOC_',
						name: 'HEADLOC',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.HEADQUARTER_LOCATION30734),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_EMPRE___CMPNYHEADLOC_',
						mustBeFilled: false,
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
									enableAddressSearch: {
										rawValue: false,
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
					extraProperties: {}
				},
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// Called before the route that renders this component is confirmed.
			// Does NOT have access to `this` component instance, because
			// it has not been created yet when this guard is called!

			to.params.isPopup = 'true'

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
// USE /[MANUAL GQT BEFORE_LOAD_JS EMPRE]/
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
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

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
				for (let trigger of triggers)
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
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

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
				let redirectPage = true // Set to 'false' to cancel page redirect.

				// Execute the "After save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterSave)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT AFTER_SAVE_JS EMPRE]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS EMPRE]/
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
// USE /[MANUAL GQT AFTER_DEL_JS EMPRE]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS EMPRE]/
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
		},

		watch: {
		}
	}
</script>
