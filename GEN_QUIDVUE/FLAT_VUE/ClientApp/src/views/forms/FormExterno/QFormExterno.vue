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
			data-key="EXTERNO"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container
					v-show="controls.EXTERNO_PSEUDNOVOGR01.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.EXTERNO_PSEUDNOVOGR01.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="EXTERNO_PSEUDNOVOGR01"
							v-bind="controls.EXTERNO_PSEUDNOVOGR01"
							:is-visible="controls.EXTERNO_PSEUDNOVOGR01.isVisible">
							<!-- Start EXTERNO_PSEUDNOVOGR01 -->
							<q-row-container v-show="controls.EXTERNO_CMPNYDESIGNAT.isVisible">
								<q-control-wrapper
									v-show="controls.EXTERNO_CMPNYDESIGNAT.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EXTERNO_CMPNYDESIGNAT"
										v-on="controls.EXTERNO_CMPNYDESIGNAT.handlers"
										:loading="controls.EXTERNO_CMPNYDESIGNAT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-lookup
											v-if="controls.EXTERNO_CMPNYDESIGNAT.isVisible"
											v-bind="controls.EXTERNO_CMPNYDESIGNAT.props"
											:model-value="model.ValCodempre.value"
											v-on="controls.EXTERNO_CMPNYDESIGNAT.handlers"
											@update:model-value="model.ValCodempre.fnUpdateValue" />
										<q-see-more-externo-cmpnydesignat
											v-if="controls.EXTERNO_CMPNYDESIGNAT.seeMoreIsVisible"
											v-bind="controls.EXTERNO_CMPNYDESIGNAT.seeMoreParams"
											v-on="controls.EXTERNO_CMPNYDESIGNAT.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End EXTERNO_PSEUDNOVOGR01 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.EXTERNO_PSEUDNOVOGR02.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.EXTERNO_PSEUDNOVOGR02.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="EXTERNO_PSEUDNOVOGR02"
							v-bind="controls.EXTERNO_PSEUDNOVOGR02"
							:is-visible="controls.EXTERNO_PSEUDNOVOGR02.isVisible">
							<!-- Start EXTERNO_PSEUDNOVOGR02 -->
							<q-row-container v-show="controls.EXTERNO_PESSONAME____.isVisible">
								<q-control-wrapper
									v-show="controls.EXTERNO_PESSONAME____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EXTERNO_PESSONAME____"
										v-on="controls.EXTERNO_PESSONAME____.handlers"
										:loading="controls.EXTERNO_PESSONAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-text-field
											v-bind="controls.EXTERNO_PESSONAME____.props"
											:model-value="model.ValName.value"
											@update:model-value="model.ValName.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.EXTERNO_PESSOGENDER__.isVisible">
								<q-control-wrapper
									v-show="controls.EXTERNO_PESSOGENDER__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EXTERNO_PESSOGENDER__"
										v-on="controls.EXTERNO_PESSOGENDER__.handlers"
										:loading="controls.EXTERNO_PESSOGENDER__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-select
											v-if="controls.EXTERNO_PESSOGENDER__.isVisible"
											v-bind="controls.EXTERNO_PESSOGENDER__.props"
											:model-value="model.ValGender.value"
											@update:model-value="model.ValGender.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End EXTERNO_PSEUDNOVOGR02 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.EXTERNO_PSEUDNOVOGR06.isVisible || controls.EXTERNO_PSEUDOBRIGATO.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.EXTERNO_PSEUDNOVOGR06.isVisible"
						class="row-line-group">
						<q-accordion-container
							id="EXTERNO_PSEUDNOVOGR06"
							v-bind="controls.EXTERNO_PSEUDNOVOGR06"
							v-on="controls.EXTERNO_PSEUDNOVOGR06.handlers"
							v-slot="{ onStateChanged }">
							<!-- Start EXTERNO_PSEUDNOVOGR06 -->
							<q-group-collapsible
								v-bind="controls.EXTERNO_PSEUDNOVOGR03"
								v-on="controls.EXTERNO_PSEUDNOVOGR03.handlers"
								@state-changed="(state, groupId) => onStateChanged(state, groupId)">
								<!-- Start EXTERNO_PSEUDNOVOGR03 -->
								<q-row-container v-show="controls.EXTERNO_PESSOTELEPHON.isVisible || controls.EXTERNO_PESSOEMAIL___.isVisible">
									<q-control-wrapper
										v-show="controls.EXTERNO_PESSOTELEPHON.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.EXTERNO_PESSOTELEPHON"
											v-on="controls.EXTERNO_PESSOTELEPHON.handlers"
											:loading="controls.EXTERNO_PESSOTELEPHON.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-text-field
												v-bind="controls.EXTERNO_PESSOTELEPHON.props"
												:model-value="model.ValTelephon.value"
												@update:model-value="model.ValTelephon.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
									<q-control-wrapper
										v-show="controls.EXTERNO_PESSOEMAIL___.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.EXTERNO_PESSOEMAIL___"
											v-on="controls.EXTERNO_PESSOEMAIL___.handlers"
											:loading="controls.EXTERNO_PESSOEMAIL___.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-text-field
												v-bind="controls.EXTERNO_PESSOEMAIL___.props"
												:model-value="model.ValEmail.value"
												@update:model-value="model.ValEmail.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<!-- End EXTERNO_PSEUDNOVOGR03 -->
							</q-group-collapsible>
							<q-group-collapsible
								v-bind="controls.EXTERNO_PSEUDNOVOGR04"
								v-on="controls.EXTERNO_PSEUDNOVOGR04.handlers"
								@state-changed="(state, groupId) => onStateChanged(state, groupId)">
								<!-- Start EXTERNO_PSEUDNOVOGR04 -->
								<q-row-container v-show="controls.EXTERNO_PESSOPHOTOGRA.isVisible">
									<q-control-wrapper
										v-show="controls.EXTERNO_PESSOPHOTOGRA.isVisible"
										class="control-join-group">
										<base-input-structure
											class="q-image"
											v-bind="controls.EXTERNO_PESSOPHOTOGRA"
											v-on="controls.EXTERNO_PESSOPHOTOGRA.handlers"
											:loading="controls.EXTERNO_PESSOPHOTOGRA.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-image
												v-if="controls.EXTERNO_PESSOPHOTOGRA.isVisible"
												v-bind="controls.EXTERNO_PESSOPHOTOGRA.props"
												v-on="controls.EXTERNO_PESSOPHOTOGRA.handlers" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<!-- End EXTERNO_PSEUDNOVOGR04 -->
							</q-group-collapsible>
							<!-- End EXTERNO_PSEUDNOVOGR06 -->
						</q-accordion-container>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.EXTERNO_PSEUDOBRIGATO.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-static-text"
							v-bind="controls.EXTERNO_PSEUDOBRIGATO"
							v-on="controls.EXTERNO_PSEUDOBRIGATO.handlers"
							:loading="controls.EXTERNO_PSEUDOBRIGATO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-static-text
								v-if="controls.EXTERNO_PSEUDOBRIGATO.isVisible"
								id="EXTERNO_PSEUDOBRIGATO"
								size="xxlarge"
								:text="controls.EXTERNO_PSEUDOBRIGATO.label"
								supports-html />
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

	import FormViewModel from './QFormExternoViewModel.js'

	const requiredTextResources = ['QFormExterno', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS EXTERNO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormExterno',

		components: {
			QSeeMoreExternoCmpnydesignat: defineAsyncComponent(() => import('@/views/forms/FormExterno/dbedits/ExternoCmpnydesignatSeeMore.vue')),
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
						name: 'EXTERNO',
						location: 'form-EXTERNO',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormExterno', false),

				interfaceMetadata: {
					id: 'QFormExterno', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'EXTERNO',
					route: 'form-EXTERNO',
					area: 'PESSO',
					primaryKey: 'ValCodpesso',
					designation: computed(() => this.Resources.PERSON10446),
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
					EXTERNO_PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'EXTERNO_PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.COMPANY20759),
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
					EXTERNO_CMPNYDESIGNAT: new fieldControlClass.LookupControl({
						modelField: 'TableCmpnyDesignat',
						valueChangeEvent: 'fieldChange:cmpny.designat',
						id: 'EXTERNO_CMPNYDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.COMPANY_22615),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXTERNO_PSEUDNOVOGR01',
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodempre',
							dependencyEvent: 'fieldChange:pesso.codempre'
						},
						dependentFields: () => {
							return {
								set 'cmpny.codempre'(value) { vm.model.ValCodempre.updateValue(value) },
								set 'cmpny.designat'(value) { vm.model.TableCmpnyDesignat.updateValue(value) },
							}
						},
						insertEnabled: true,
						supportForm: 'EMPRE',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
					}, this),
					EXTERNO_PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'EXTERNO_PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.IDENTIFICATION40793),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					EXTERNO_PESSONAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:pesso.name',
						id: 'EXTERNO_PESSONAME____',
						name: 'NAME',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.NAME_23841),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXTERNO_PSEUDNOVOGR02',
						maxLength: 85,
						labelId: 'label_EXTERNO_PESSONAME____',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					EXTERNO_PESSOGENDER__: new fieldControlClass.ArrayStringControl({
						modelField: 'ValGender',
						valueChangeEvent: 'fieldChange:pesso.gender',
						id: 'EXTERNO_PESSOGENDER__',
						name: 'GENDER',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.GENDER44172),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXTERNO_PSEUDNOVOGR02',
						maxLength: 1,
						labelId: 'label_EXTERNO_PESSOGENDER__',
						arrayName: 'Genero',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					EXTERNO_PSEUDNOVOGR06: new fieldControlClass.AccordionControl({
						id: 'EXTERNO_PSEUDNOVOGR06',
						name: 'NOVOGR06',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.ACCORDION01950),
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
					EXTERNO_PSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'EXTERNO_PSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.CONTACT05134),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'EXTERNO_PSEUDNOVOGR06',
						isCollapsible: true,
						anchored: false,
						openingEvent: 'opened-EXTERNO_PSEUDNOVOGR03',
						isInAccordion: true,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					EXTERNO_PESSOTELEPHON: new fieldControlClass.StringControl({
						modelField: 'ValTelephon',
						valueChangeEvent: 'fieldChange:pesso.telephon',
						id: 'EXTERNO_PESSOTELEPHON',
						name: 'TELEPHON',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.TELEPHONE28697),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-EXTERNO_PSEUDNOVOGR03',
						container: 'EXTERNO_PSEUDNOVOGR03',
						maxLength: 20,
						labelId: 'label_EXTERNO_PESSOTELEPHON',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					EXTERNO_PESSOEMAIL___: new fieldControlClass.StringControl({
						modelField: 'ValEmail',
						valueChangeEvent: 'fieldChange:pesso.email',
						id: 'EXTERNO_PESSOEMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.EMAIL_44228),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-EXTERNO_PSEUDNOVOGR03',
						container: 'EXTERNO_PSEUDNOVOGR03',
						maxLength: 254,
						labelId: 'label_EXTERNO_PESSOEMAIL___',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					EXTERNO_PSEUDNOVOGR04: new fieldControlClass.GroupControl({
						id: 'EXTERNO_PSEUDNOVOGR04',
						name: 'NOVOGR04',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.PHOTO32097),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'EXTERNO_PSEUDNOVOGR06',
						isCollapsible: true,
						anchored: false,
						openingEvent: 'opened-EXTERNO_PSEUDNOVOGR04',
						isInAccordion: true,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					EXTERNO_PESSOPHOTOGRA: new fieldControlClass.ImageControl({
						modelField: 'ValPhotogra',
						valueChangeEvent: 'fieldChange:pesso.photogra',
						id: 'EXTERNO_PESSOPHOTOGRA',
						name: 'PHOTOGRA',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.PHOTO51874),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-EXTERNO_PSEUDNOVOGR04',
						container: 'EXTERNO_PSEUDNOVOGR04',
						height: 50,
						width: 100,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					EXTERNO_PSEUDOBRIGATO: new fieldControlClass.BaseControl({
						id: 'EXTERNO_PSEUDOBRIGATO',
						name: 'OBRIGATO',
						size: 'xxlarge',
						hasLabel: false,
						label: computed(() => this.Resources.AT_REQUIRED65277),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						mustBeFilled: false,
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
					'EXTERNO_PSEUDNOVOGR01',
					'EXTERNO_PSEUDNOVOGR02',
					'EXTERNO_PSEUDNOVOGR06',
					'EXTERNO_PSEUDNOVOGR03',
					'EXTERNO_PSEUDNOVOGR04',
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
						get ValDesignat() { return vm.model.TableCmpnyDesignat.value },
						set ValDesignat(value) { vm.model.TableCmpnyDesignat.updateValue(value) },
					},
					Pesso: {
						get ValCodcateg() { return vm.model.ValCodcateg.value },
						set ValCodcateg(value) { vm.model.ValCodcateg.updateValue(value) },
						get ValCodcntry() { return vm.model.ValCodcntry.value },
						set ValCodcntry(value) { vm.model.ValCodcntry.updateValue(value) },
						get ValCodempre() { return vm.model.ValCodempre.value },
						set ValCodempre(value) { vm.model.ValCodempre.updateValue(value) },
						get ValCodpaise() { return vm.model.ValCodpaise.value },
						set ValCodpaise(value) { vm.model.ValCodpaise.updateValue(value) },
						get ValCodregia() { return vm.model.ValCodregia.value },
						set ValCodregia(value) { vm.model.ValCodregia.updateValue(value) },
						get ValEmail() { return vm.model.ValEmail.value },
						set ValEmail(value) { vm.model.ValEmail.updateValue(value) },
						get ValGender() { return vm.model.ValGender.value },
						set ValGender(value) { vm.model.ValGender.updateValue(value) },
						get ValName() { return vm.model.ValName.value },
						set ValName(value) { vm.model.ValName.updateValue(value) },
						get ValPhotogra() { return vm.model.ValPhotogra.value },
						set ValPhotogra(value) { vm.model.ValPhotogra.updateValue(value) },
						get ValTelephon() { return vm.model.ValTelephon.value },
						set ValTelephon(value) { vm.model.ValTelephon.updateValue(value) },
					},
					keys: {
						/** The primary key of the PESSO table */
						get pesso() { return vm.model.ValCodpesso },
						/** The foreign key to the CMPNY table */
						get cmpny() { return vm.model.ValCodempre },
						/** The foreign key to the CATEG table */
						get categ() { return vm.model.ValCodcateg },
						/** The foreign key to the CNTRY table */
						get cntry() { return vm.model.ValCodpaise },
						/** The foreign key to the PAIS1 table */
						get pais1() { return vm.model.ValCodcntry },
						/** The foreign key to the REGI1 table */
						get regi1() { return vm.model.ValCodregia },
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
// USE /[MANUAL GQT FORM_CODEJS EXTERNO]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS EXTERNO]/
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
// USE /[MANUAL GQT FORM_LOADED_JS EXTERNO]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS EXTERNO]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS EXTERNO]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS EXTERNO]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS EXTERNO]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS EXTERNO]/
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
// USE /[MANUAL GQT AFTER_DEL_JS EXTERNO]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS EXTERNO]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS EXTERNO]/
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
// USE /[MANUAL GQT DLGUPDT EXTERNO]/
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
// USE /[MANUAL GQT CTRLUPD EXTERNO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
		},

		watch: {
			// Watchers for changes in the state of tabs and collapsible groups.
			'controls.EXTERNO_PSEUDNOVOGR03.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'EXTERNO_PSEUDNOVOGR03',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
			'controls.EXTERNO_PSEUDNOVOGR04.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'EXTERNO_PSEUDNOVOGR04',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
		}
	}
</script>
