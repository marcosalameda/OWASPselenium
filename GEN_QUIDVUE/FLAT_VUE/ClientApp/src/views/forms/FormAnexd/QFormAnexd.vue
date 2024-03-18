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
			data-key="ANEXD"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.ANEXD___EQUIPREGISTNR.isVisible">
					<q-control-wrapper
						v-show="controls.ANEXD___EQUIPREGISTNR.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ANEXD___EQUIPREGISTNR"
							v-on="controls.ANEXD___EQUIPREGISTNR.handlers"
							:loading="controls.ANEXD___EQUIPREGISTNR.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-lookup
								v-if="controls.ANEXD___EQUIPREGISTNR.isVisible"
								v-bind="controls.ANEXD___EQUIPREGISTNR.props"
								:model-value="model.ValCodequip.value"
								v-on="controls.ANEXD___EQUIPREGISTNR.handlers"
								@update:model-value="model.ValCodequip.fnUpdateValue" />
							<q-see-more-anexd-equipregistnr
								v-if="controls.ANEXD___EQUIPREGISTNR.seeMoreIsVisible"
								v-bind="controls.ANEXD___EQUIPREGISTNR.seeMoreParams"
								v-on="controls.ANEXD___EQUIPREGISTNR.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.ANEXD___ANEXDDTHRANEX.isVisible || controls.ANEXD___ANEXDREFERENC.isVisible">
					<q-control-wrapper
						v-show="controls.ANEXD___ANEXDDTHRANEX.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ANEXD___ANEXDDTHRANEX"
							v-on="controls.ANEXD___ANEXDDTHRANEX.handlers"
							:loading="controls.ANEXD___ANEXDDTHRANEX.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-datetime-input
								v-if="controls.ANEXD___ANEXDDTHRANEX.isVisible"
								v-bind="controls.ANEXD___ANEXDDTHRANEX"
								format="DateTime"
								:model-value="model.ValDthranex.value"
								@update:model-value="model.ValDthranex.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ANEXD___ANEXDREFERENC.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ANEXD___ANEXDREFERENC"
							v-on="controls.ANEXD___ANEXDREFERENC.handlers"
							:loading="controls.ANEXD___ANEXDREFERENC.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ANEXD___ANEXDREFERENC.props"
								:model-value="model.ValReferenc.value"
								@update:model-value="model.ValReferenc.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.ANEXD___ANEXDTITLE___.isVisible">
					<q-control-wrapper
						v-show="controls.ANEXD___ANEXDTITLE___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ANEXD___ANEXDTITLE___"
							v-on="controls.ANEXD___ANEXDTITLE___.handlers"
							:loading="controls.ANEXD___ANEXDTITLE___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ANEXD___ANEXDTITLE___.props"
								:model-value="model.ValTitle.value"
								@update:model-value="model.ValTitle.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.ANEXD___LANGULANGUA__.isVisible">
					<q-control-wrapper
						v-show="controls.ANEXD___LANGULANGUA__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ANEXD___LANGULANGUA__"
							v-on="controls.ANEXD___LANGULANGUA__.handlers"
							:loading="controls.ANEXD___LANGULANGUA__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-lookup
								v-if="controls.ANEXD___LANGULANGUA__.isVisible"
								v-bind="controls.ANEXD___LANGULANGUA__.props"
								:model-value="model.ValCodlang.value"
								v-on="controls.ANEXD___LANGULANGUA__.handlers"
								@update:model-value="model.ValCodlang.fnUpdateValue" />
							<q-see-more-anexd-langulangua
								v-if="controls.ANEXD___LANGULANGUA__.seeMoreIsVisible"
								v-bind="controls.ANEXD___LANGULANGUA__.seeMoreParams"
								v-on="controls.ANEXD___LANGULANGUA__.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.ANEXD___ANEXDTITTRADU.isVisible">
					<q-control-wrapper
						v-show="controls.ANEXD___ANEXDTITTRADU.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ANEXD___ANEXDTITTRADU"
							v-on="controls.ANEXD___ANEXDTITTRADU.handlers"
							:loading="controls.ANEXD___ANEXDTITTRADU.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ANEXD___ANEXDTITTRADU.props"
								:model-value="model.ValTittradu.value" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.ANEXD___ANEXDDOCUMENT.isVisible">
					<q-control-wrapper
						v-show="controls.ANEXD___ANEXDDOCUMENT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ANEXD___ANEXDDOCUMENT"
							v-on="controls.ANEXD___ANEXDDOCUMENT.handlers"
							:loading="controls.ANEXD___ANEXDDOCUMENT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-document
								v-if="controls.ANEXD___ANEXDDOCUMENT.isVisible"
								id="ANEXD___ANEXDDOCUMENT"
								size="xxlarge"
								:model-value="model.ValDocument.value"
								versioning-is-on
								:readonly="controls.ANEXD___ANEXDDOCUMENT.readonly"
								:is-in-checkout="controls.ANEXD___ANEXDDOCUMENT.isInCheckout"
								:current-version="controls.ANEXD___ANEXDDOCUMENT.currentVersion"
								:extensions="controls.ANEXD___ANEXDDOCUMENT.extensions"
								:max-file-size="controls.ANEXD___ANEXDDOCUMENT.maxFileSize"
								:versions="controls.ANEXD___ANEXDDOCUMENT.documentVersions"
								:versions-info="controls.ANEXD___ANEXDDOCUMENT.versionsInfo"
								:file-properties="controls.ANEXD___ANEXDDOCUMENT.fileProperties"
								:texts="controls.ANEXD___ANEXDDOCUMENT.texts"
								:popup-is-visible="controls.ANEXD___ANEXDDOCUMENT.popupIsVisible"
								:disallow-removal="controls.ANEXD___ANEXDDOCUMENT.isRequired"
								:resources-path="controls.ANEXD___ANEXDDOCUMENT.resourcesPath"
								:uses-templates="controls.ANEXD___ANEXDDOCUMENT.usesTemplates"
								@file-error="controls.ANEXD___ANEXDDOCUMENT.HandleFileError($event)"
								@submit-file="controls.ANEXD___ANEXDDOCUMENT.SetFile($event)"
								@edit-file="controls.ANEXD___ANEXDDOCUMENT.SetCheckoutState()"
								@get-properties="controls.ANEXD___ANEXDDOCUMENT.GetFileProperties()"
								@get-version-history="controls.ANEXD___ANEXDDOCUMENT.GetVersionsInfo()"
								@get-file="controls.ANEXD___ANEXDDOCUMENT.GetFile()"
								@download-file="controls.ANEXD___ANEXDDOCUMENT.DownloadFile()"
								@get-file-version="controls.ANEXD___ANEXDDOCUMENT.GetFileVersion($event)"
								@delete-last="controls.ANEXD___ANEXDDOCUMENT.DeleteFile(0)"
								@delete-history="controls.ANEXD___ANEXDDOCUMENT.DeleteFile(1)"
								@delete-file="controls.ANEXD___ANEXDDOCUMENT.DeleteFile(2)"
								@show-popup="controls.ANEXD___ANEXDDOCUMENT.SetModal($event)"
								@hide-popup="controls.ANEXD___ANEXDDOCUMENT.RemoveModal($event)"
								@show-templates-popup="controls.ANEXD___ANEXDDOCUMENT.handleDocumentTemplates($event)" />
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

	import FormViewModel from './QFormAnexdViewModel.js'

	const requiredTextResources = ['QFormAnexd', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS ANEXD]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormAnexd',

		components: {
			QSeeMoreAnexdEquipregistnr: defineAsyncComponent(() => import('@/views/forms/FormAnexd/dbedits/AnexdEquipregistnrSeeMore.vue')),
			QSeeMoreAnexdLangulangua: defineAsyncComponent(() => import('@/views/forms/FormAnexd/dbedits/AnexdLangulanguaSeeMore.vue')),
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
						name: 'ANEXD',
						location: 'form-ANEXD',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormAnexd', false),

				interfaceMetadata: {
					id: 'QFormAnexd', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'ANEXD',
					route: 'form-ANEXD',
					area: 'ANEXD',
					primaryKey: 'ValCodanexd',
					designation: computed(() => this.Resources.ANEXO_DIGITAL09547),
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
					ANEXD___EQUIPREGISTNR: new fieldControlClass.LookupControl({
						modelField: 'TableEquipRegistnr',
						valueChangeEvent: 'fieldChange:equip.registnr',
						id: 'ANEXD___EQUIPREGISTNR',
						name: 'REGISTNR',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.NO__REGISTER04207),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodequip',
							dependencyEvent: 'fieldChange:anexd.codequip'
						},
						dependentFields: () => {
							return {
								set 'equip.codequip'(value) { vm.model.ValCodequip.updateValue(value) },
								set 'equip.registnr'(value) { vm.model.TableEquipRegistnr.updateValue(value) },
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
					ANEXD___ANEXDDTHRANEX: new fieldControlClass.DateControl({
						modelField: 'ValDthranex',
						valueChangeEvent: 'fieldChange:anexd.dthranex',
						id: 'ANEXD___ANEXDDTHRANEX',
						name: 'DTHRANEX',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.ATTACHED26247),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ANEXD___ANEXDREFERENC: new fieldControlClass.StringControl({
						modelField: 'ValReferenc',
						valueChangeEvent: 'fieldChange:anexd.referenc',
						id: 'ANEXD___ANEXDREFERENC',
						name: 'REFERENC',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.REFERENCE28402),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_ANEXD___ANEXDREFERENC',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ANEXD___ANEXDTITLE___: new fieldControlClass.StringControl({
						modelField: 'ValTitle',
						valueChangeEvent: 'fieldChange:anexd.title',
						id: 'ANEXD___ANEXDTITLE___',
						name: 'TITLE',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.TITLE21885),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						labelId: 'label_ANEXD___ANEXDTITLE___',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ANEXD___LANGULANGUA__: new fieldControlClass.LookupControl({
						modelField: 'TableLanguLangua',
						valueChangeEvent: 'fieldChange:langu.langua',
						id: 'ANEXD___LANGULANGUA__',
						name: 'LANGUA',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.LANGUAGE16872),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodlang',
							dependencyEvent: 'fieldChange:anexd.codlang'
						},
						dependentFields: () => {
							return {
								set 'langu.codlang'(value) { vm.model.ValCodlang.updateValue(value) },
								set 'langu.langua'(value) { vm.model.TableLanguLangua.updateValue(value) },
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
					ANEXD___ANEXDTITTRADU: new fieldControlClass.StringControl({
						modelField: 'ValTittradu',
						valueChangeEvent: 'fieldChange:anexd.tittradu',
						id: 'ANEXD___ANEXDTITTRADU',
						name: 'TITTRADU',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.TRANSLATED_TITLE04469),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						maxLength: 85,
						labelId: 'label_ANEXD___ANEXDTITTRADU',
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					ANEXD___ANEXDDOCUMENT: new fieldControlClass.DocumentControl({
						modelField: 'ValDocument',
						valueChangeEvent: 'fieldChange:anexd.document',
						id: 'ANEXD___ANEXDDOCUMENT',
						name: 'DOCUMENT',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.DOCUMENT00695),
						userHelp: computed(() => this.Resources.___1637441),
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						documentProperties: computed(() => vm.model.ValDocumentPropertiesVM),
						documentFK: computed(() => vm.model.ValDocumentfk),
						documentVersions: computed(() => vm.model.ValDocumentPropertiesVM.value ? vm.model.ValDocumentPropertiesVM.value.Versions : {}),
						isInCheckout: computed(() => vm.model.ValDocumentPropertiesVM.value ? vm.model.ValDocumentPropertiesVM.value.IsCheckout : false),
						currentVersion: computed(() => vm.model.ValDocumentPropertiesVM.value ? vm.model.ValDocumentPropertiesVM.value.Version : '1'),
						usesTemplates: false,
						extensions: [],
						viewType: qEnums.documentViewTypeMode.Preview,
						mustBeFilled: true,
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
					Anexd: {
						get ValCodequip() { return vm.model.ValCodequip.value },
						set ValCodequip(value) { vm.model.ValCodequip.updateValue(value) },
						get ValCodlang() { return vm.model.ValCodlang.value },
						set ValCodlang(value) { vm.model.ValCodlang.updateValue(value) },
						get ValDocument() { return vm.model.ValDocument.value },
						set ValDocument(value) { vm.model.ValDocument.updateValue(value) },
						get ValDthranex() { return vm.model.ValDthranex.value },
						set ValDthranex(value) { vm.model.ValDthranex.updateValue(value) },
						get ValReferenc() { return vm.model.ValReferenc.value },
						set ValReferenc(value) { vm.model.ValReferenc.updateValue(value) },
						get ValTitle() { return vm.model.ValTitle.value },
						set ValTitle(value) { vm.model.ValTitle.updateValue(value) },
						get ValTittradu() { return vm.model.ValTittradu.value },
						set ValTittradu(value) { vm.model.ValTittradu.updateValue(value) },
					},
					Equip: {
						get ValRegistnr() { return vm.model.TableEquipRegistnr.value },
						set ValRegistnr(value) { vm.model.TableEquipRegistnr.updateValue(value) },
					},
					Langu: {
						get ValLangua() { return vm.model.TableLanguLangua.value },
						set ValLangua(value) { vm.model.TableLanguLangua.updateValue(value) },
					},
					keys: {
						/** The primary key of the ANEXD table */
						get anexd() { return vm.model.ValCodanexd },
						/** The foreign key to the EQUIP table */
						get equip() { return vm.model.ValCodequip },
						/** The foreign key to the LANGU table */
						get langu() { return vm.model.ValCodlang },
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
// USE /[MANUAL GQT FORM_CODEJS ANEXD]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS ANEXD]/
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
// USE /[MANUAL GQT FORM_LOADED_JS ANEXD]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS ANEXD]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS ANEXD]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS ANEXD]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS ANEXD]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS ANEXD]/
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
// USE /[MANUAL GQT AFTER_DEL_JS ANEXD]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS ANEXD]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS ANEXD]/
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
// USE /[MANUAL GQT DLGUPDT ANEXD]/
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
// USE /[MANUAL GQT CTRLUPD ANEXD]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
		},

		watch: {
		}
	}
</script>
