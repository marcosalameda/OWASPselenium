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
			data-key="ANEXD"
			:data-loading="!formInitialDataLoaded">
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
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.ANEXD___EQUIPREGISTNR.isVisible"
								v-bind="controls.ANEXD___EQUIPREGISTNR.props"
								v-on="controls.ANEXD___EQUIPREGISTNR.handlers" />
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
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.ANEXD___ANEXDDTHRANEX.isVisible"
								v-bind="controls.ANEXD___ANEXDDTHRANEX.props"
								:model-value="model.ValDthranex.value"
								@reset-icon-click="model.ValDthranex.fnUpdateValue(model.ValDthranex.originalValue ?? new Date())"
								@update:model-value="model.ValDthranex.fnUpdateValue($event ?? '')" />
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
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.ANEXD___ANEXDREFERENC.props"
								@blur="onBlur(controls.ANEXD___ANEXDREFERENC, model.ValReferenc.value)"
								@change="model.ValReferenc.fnUpdateValueOnChange" />
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
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.ANEXD___ANEXDTITLE___.props"
								@blur="onBlur(controls.ANEXD___ANEXDTITLE___, model.ValTitle.value)"
								@change="model.ValTitle.fnUpdateValueOnChange" />
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
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.ANEXD___LANGULANGUA__.isVisible"
								v-bind="controls.ANEXD___LANGULANGUA__.props"
								v-on="controls.ANEXD___LANGULANGUA__.handlers" />
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
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.ANEXD___ANEXDTITTRADU.props"
								@blur="onBlur(controls.ANEXD___ANEXDTITTRADU, model.ValTittradu.value)"
								@change="model.ValTittradu.fnUpdateValueOnChange" />
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
							:suggestion-mode-on="suggestionModeOn">
							<q-document
								v-if="controls.ANEXD___ANEXDDOCUMENT.isVisible"
								v-bind="controls.ANEXD___ANEXDDOCUMENT.props"
								v-on="controls.ANEXD___ANEXDDOCUMENT.handlers" />
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
	/* eslint-disable no-unused-vars */
	import { computed, defineAsyncComponent, readonly } from 'vue'
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
				default: () => ({
					name: 'ANEXD',
					location: 'form-ANEXD',
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
					ANEXD___EQUIPREGISTNR: new fieldControlClass.LookupControl({
						modelField: 'TableEquipRegistnr',
						valueChangeEvent: 'fieldChange:equip.registnr',
						id: 'ANEXD___EQUIPREGISTNR',
						name: 'REGISTNR',
						size: 'mini',
						label: computed(() => this.Resources.NO__REGISTER04207),
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
							dependencyEvent: 'fieldChange:anexd.codequip'
						},
						dependentFields: () => ({
							set 'equip.codequip'(value) { vm.model.ValCodequip.updateValue(value) },
							set 'equip.registnr'(value) { vm.model.TableEquipRegistnr.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					ANEXD___ANEXDDTHRANEX: new fieldControlClass.DateControl({
						modelField: 'ValDthranex',
						valueChangeEvent: 'fieldChange:anexd.dthranex',
						id: 'ANEXD___ANEXDDTHRANEX',
						name: 'DTHRANEX',
						size: 'medium',
						label: computed(() => this.Resources.ATTACHED26247),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						format: 'dateTime',
						controlLimits: [
						],
					}, this),
					ANEXD___ANEXDREFERENC: new fieldControlClass.StringControl({
						modelField: 'ValReferenc',
						valueChangeEvent: 'fieldChange:anexd.referenc',
						id: 'ANEXD___ANEXDREFERENC',
						name: 'REFERENC',
						size: 'xlarge',
						label: computed(() => this.Resources.REFERENCE28402),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_ANEXD___ANEXDREFERENC',
						controlLimits: [
						],
					}, this),
					ANEXD___ANEXDTITLE___: new fieldControlClass.StringControl({
						modelField: 'ValTitle',
						valueChangeEvent: 'fieldChange:anexd.title',
						id: 'ANEXD___ANEXDTITLE___',
						name: 'TITLE',
						size: 'xxlarge',
						label: computed(() => this.Resources.TITLE21885),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						labelId: 'label_ANEXD___ANEXDTITLE___',
						controlLimits: [
						],
					}, this),
					ANEXD___LANGULANGUA__: new fieldControlClass.LookupControl({
						modelField: 'TableLanguLangua',
						valueChangeEvent: 'fieldChange:langu.langua',
						id: 'ANEXD___LANGULANGUA__',
						name: 'LANGUA',
						size: 'xlarge',
						label: computed(() => this.Resources.LANGUAGE16872),
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
							name: 'ValCodlang',
							dependencyEvent: 'fieldChange:anexd.codlang'
						},
						dependentFields: () => ({
							set 'langu.codlang'(value) { vm.model.ValCodlang.updateValue(value) },
							set 'langu.langua'(value) { vm.model.TableLanguLangua.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					ANEXD___ANEXDTITTRADU: new fieldControlClass.StringControl({
						modelField: 'ValTittradu',
						valueChangeEvent: 'fieldChange:anexd.tittradu',
						id: 'ANEXD___ANEXDTITTRADU',
						name: 'TITTRADU',
						size: 'xxlarge',
						label: computed(() => this.Resources.TRANSLATED_TITLE04469),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						maxLength: 85,
						labelId: 'label_ANEXD___ANEXDTITTRADU',
						controlLimits: [
						],
					}, this),
					ANEXD___ANEXDDOCUMENT: new fieldControlClass.DocumentControl({
						modelField: 'ValDocument',
						valueChangeEvent: 'fieldChange:anexd.document',
						id: 'ANEXD___ANEXDDOCUMENT',
						name: 'DOCUMENT',
						size: 'xxlarge',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources.___1637441),
							},
						},
						label: computed(() => this.Resources.DOCUMENT00695),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						versioningIsOn: true,
						extensions: [],
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
						get ValCodequip() { return vm.model.ValCodequip.value },
						set ValCodequip(value) { vm.model.ValCodequip.updateValue(value) },
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

				applyForm = await this.model.setDocumentChanges()

				if (applyForm)
				{
					const results = await this.model.saveDocuments()
					applyForm = results.every((e) => e === true)
				}

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

				saveForm = await this.model.setDocumentChanges()

				if (saveForm)
				{
					const results = await this.model.saveDocuments()
					saveForm = results.every((e) => e === true)
				}

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
			 * Called whenever a field is unfocused.
			 * @param {*} fieldObject The object representing the field in the model
			 * @param {*} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onBlur(fieldObject, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT CTRLBLR ANEXD]/
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
// USE /[MANUAL GQT CTRLUPD ANEXD]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS ANEXD]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
