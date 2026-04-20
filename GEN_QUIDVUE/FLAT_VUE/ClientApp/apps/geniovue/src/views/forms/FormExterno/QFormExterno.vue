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
			data-key="EXTERNO"
			:data-identifier="primaryKeyValue"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.EXTERNO_PSEUDNOVOGR01.isVisible">
					<q-col v-if="controls.EXTERNO_PSEUDNOVOGR01.isVisible">
						<q-group-box-container
							v-if="controls.EXTERNO_PSEUDNOVOGR01.isVisible"
							v-bind="controls.EXTERNO_PSEUDNOVOGR01"
							:id="getControlId(controls.EXTERNO_PSEUDNOVOGR01)"
							:no-border="controls.EXTERNO_PSEUDNOVOGR01.borderless">
							<!-- Start EXTERNO_PSEUDNOVOGR01 -->
							<q-row v-if="controls.EXTERNO_CMPNYDESIGNAT.isVisible">
								<q-col
									v-if="controls.EXTERNO_CMPNYDESIGNAT.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EXTERNO_CMPNYDESIGNAT.isVisible"
										class="i-text"
										v-bind="controls.EXTERNO_CMPNYDESIGNAT.wrapperProps"
										:id="getControlId(controls.EXTERNO_CMPNYDESIGNAT)"
										v-on="controls.EXTERNO_CMPNYDESIGNAT.handlers"
										:loading="controls.EXTERNO_CMPNYDESIGNAT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.EXTERNO_CMPNYDESIGNAT.isVisible"
											v-bind="controls.EXTERNO_CMPNYDESIGNAT.props"
											:id="getControlId(controls.EXTERNO_CMPNYDESIGNAT)"
											v-on="controls.EXTERNO_CMPNYDESIGNAT.handlers" />
										<q-see-more-externo-cmpnydesignat
											v-if="controls.EXTERNO_CMPNYDESIGNAT.seeMoreIsVisible"
											v-bind="controls.EXTERNO_CMPNYDESIGNAT.seeMoreParams"
											v-on="controls.EXTERNO_CMPNYDESIGNAT.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End EXTERNO_PSEUDNOVOGR01 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.EXTERNO_PSEUDNOVOGR02.isVisible">
					<q-col v-if="controls.EXTERNO_PSEUDNOVOGR02.isVisible">
						<q-group-box-container
							v-if="controls.EXTERNO_PSEUDNOVOGR02.isVisible"
							v-bind="controls.EXTERNO_PSEUDNOVOGR02"
							:id="getControlId(controls.EXTERNO_PSEUDNOVOGR02)"
							:no-border="controls.EXTERNO_PSEUDNOVOGR02.borderless">
							<!-- Start EXTERNO_PSEUDNOVOGR02 -->
							<q-row v-if="controls.EXTERNO_PESSONAME____.isVisible">
								<q-col
									v-if="controls.EXTERNO_PESSONAME____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EXTERNO_PESSONAME____.isVisible"
										class="i-text"
										v-bind="controls.EXTERNO_PESSONAME____.wrapperProps"
										:id="getControlId(controls.EXTERNO_PESSONAME____)"
										v-on="controls.EXTERNO_PESSONAME____.handlers"
										:loading="controls.EXTERNO_PESSONAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EXTERNO_PESSONAME____.props"
											:id="getControlId(controls.EXTERNO_PESSONAME____)"
											@blur="onBlur(controls.EXTERNO_PESSONAME____, model.ValName.value)"
											@change="model.ValName.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.EXTERNO_PESSOGENDER__.isVisible">
								<q-col
									v-if="controls.EXTERNO_PESSOGENDER__.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EXTERNO_PESSOGENDER__.isVisible"
										class="i-text"
										v-bind="controls.EXTERNO_PESSOGENDER__.wrapperProps"
										:id="getControlId(controls.EXTERNO_PESSOGENDER__)"
										v-on="controls.EXTERNO_PESSOGENDER__.handlers"
										:loading="controls.EXTERNO_PESSOGENDER__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.EXTERNO_PESSOGENDER__.isVisible"
											v-bind="controls.EXTERNO_PESSOGENDER__.props"
											:id="getControlId(controls.EXTERNO_PESSOGENDER__)"
											@update:model-value="model.ValGender.fnUpdateValue" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End EXTERNO_PSEUDNOVOGR02 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.EXTERNO_PSEUDNOVOGR06.isVisible">
					<q-col v-if="controls.EXTERNO_PSEUDNOVOGR06.isVisible">
						<q-accordion
							v-if="controls.EXTERNO_PSEUDNOVOGR06.isVisible"
							:id="getControlId(controls.EXTERNO_PSEUDNOVOGR06)"
							v-model="controls.EXTERNO_PSEUDNOVOGR06.openChild">
							<!-- Start EXTERNO_PSEUDNOVOGR06 -->
							<q-accordion-item
								v-if="controls.EXTERNO_PSEUDNOVOGR03.isVisible"
								:id="getControlId(controls.EXTERNO_PSEUDNOVOGR03) + '-container'"
								value="EXTERNO_PSEUDNOVOGR03"
								:title="controls.EXTERNO_PSEUDNOVOGR03.label">
								<!-- Start EXTERNO_PSEUDNOVOGR03 -->
								<q-row v-if="controls.EXTERNO_PESSOTELEPHON.isVisible || controls.EXTERNO_PESSOEMAIL___.isVisible">
									<q-col
										v-if="controls.EXTERNO_PESSOTELEPHON.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.EXTERNO_PESSOTELEPHON.isVisible"
											class="i-text"
											v-bind="controls.EXTERNO_PESSOTELEPHON.wrapperProps"
											:id="getControlId(controls.EXTERNO_PESSOTELEPHON)"
											v-on="controls.EXTERNO_PESSOTELEPHON.handlers"
											:loading="controls.EXTERNO_PESSOTELEPHON.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.EXTERNO_PESSOTELEPHON.props"
												:id="getControlId(controls.EXTERNO_PESSOTELEPHON)"
												@blur="onBlur(controls.EXTERNO_PESSOTELEPHON, model.ValTelephon.value)"
												@change="model.ValTelephon.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-col>
									<q-col
										v-if="controls.EXTERNO_PESSOEMAIL___.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.EXTERNO_PESSOEMAIL___.isVisible"
											class="i-text"
											v-bind="controls.EXTERNO_PESSOEMAIL___.wrapperProps"
											:id="getControlId(controls.EXTERNO_PESSOEMAIL___)"
											v-on="controls.EXTERNO_PESSOEMAIL___.handlers"
											:loading="controls.EXTERNO_PESSOEMAIL___.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.EXTERNO_PESSOEMAIL___.props"
												:id="getControlId(controls.EXTERNO_PESSOEMAIL___)"
												@blur="onBlur(controls.EXTERNO_PESSOEMAIL___, model.ValEmail.value)"
												@change="model.ValEmail.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-col>
								</q-row>
								<!-- End EXTERNO_PSEUDNOVOGR03 -->
							</q-accordion-item>
							<q-accordion-item
								v-if="controls.EXTERNO_PSEUDNOVOGR04.isVisible"
								:id="getControlId(controls.EXTERNO_PSEUDNOVOGR04) + '-container'"
								value="EXTERNO_PSEUDNOVOGR04"
								:title="controls.EXTERNO_PSEUDNOVOGR04.label">
								<!-- Start EXTERNO_PSEUDNOVOGR04 -->
								<q-row v-if="controls.EXTERNO_PESSOPHOTOGRA.isVisible">
									<q-col
										v-if="controls.EXTERNO_PESSOPHOTOGRA.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.EXTERNO_PESSOPHOTOGRA.isVisible"
											class="q-image"
											v-bind="controls.EXTERNO_PESSOPHOTOGRA.wrapperProps"
											:id="getControlId(controls.EXTERNO_PESSOPHOTOGRA)"
											v-on="controls.EXTERNO_PESSOPHOTOGRA.handlers"
											:loading="controls.EXTERNO_PESSOPHOTOGRA.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-image
												v-if="controls.EXTERNO_PESSOPHOTOGRA.isVisible"
												v-bind="controls.EXTERNO_PESSOPHOTOGRA.props"
												:id="getControlId(controls.EXTERNO_PESSOPHOTOGRA)"
												v-on="controls.EXTERNO_PESSOPHOTOGRA.handlers" />
										</base-input-structure>
									</q-col>
								</q-row>
								<!-- End EXTERNO_PSEUDNOVOGR04 -->
							</q-accordion-item>
							<!-- End EXTERNO_PSEUDNOVOGR06 -->
						</q-accordion>
					</q-col>
				</q-row>
				<q-row v-if="controls.EXTERNO_PSEUDOBRIGATO.isVisible">
					<q-col
						v-if="controls.EXTERNO_PSEUDOBRIGATO.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.EXTERNO_PSEUDOBRIGATO.isVisible"
							class="i-static-text"
							v-bind="controls.EXTERNO_PSEUDOBRIGATO.wrapperProps"
							:id="getControlId(controls.EXTERNO_PSEUDOBRIGATO)"
							v-on="controls.EXTERNO_PSEUDOBRIGATO.handlers"
							:loading="controls.EXTERNO_PSEUDOBRIGATO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-static-text
								v-if="controls.EXTERNO_PSEUDOBRIGATO.isVisible"
								:id="getControlId(controls.EXTERNO_PSEUDOBRIGATO)"
								:size="controls.EXTERNO_PSEUDOBRIGATO.size"
								:text="controls.EXTERNO_PSEUDOBRIGATO.label"
								supports-html />
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
				default: () => ({
					name: 'EXTERNO',
					location: 'form-EXTERNO',
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
					EXTERNO_PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'EXTERNO_PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						label: computed(() => this.Resources.COMPANY20759),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						borderless: false,
						isCollapsible: false,
						anchored: false,
						directChildren: ['EXTERNO_CMPNYDESIGNAT'],
						controlLimits: [
						],
					}, this),
					EXTERNO_CMPNYDESIGNAT: new fieldControlClass.LookupControl({
						modelField: 'TableCmpnyDesignat',
						valueChangeEvent: 'fieldChange:cmpny.designat',
						id: 'EXTERNO_CMPNYDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.COMPANY_22615),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXTERNO_PSEUDNOVOGR01',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodempre',
							dependencyEvent: 'fieldChange:pesso.codempre'
						},
						dependentFields: () => ({
							set 'cmpny.codempre'(value) { vm.model.ValCodempre.updateValue(value) },
							set 'cmpny.designat'(value) { vm.model.TableCmpnyDesignat.updateValue(value) },
						}),
						insertEnabled: true,
						supportForm: 'EMPRE',
						controlLimits: [
						],
					}, this),
					EXTERNO_PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'EXTERNO_PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'block',
						label: computed(() => this.Resources.IDENTIFICATION40793),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						borderless: false,
						isCollapsible: false,
						anchored: false,
						directChildren: ['EXTERNO_PESSONAME____', 'EXTERNO_PESSOGENDER__'],
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
						label: computed(() => this.Resources.NAME_23841),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXTERNO_PSEUDNOVOGR02',
						maxLength: 85,
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
						label: computed(() => this.Resources.GENDER44172),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXTERNO_PSEUDNOVOGR02',
						maxLength: 1,
						arrayName: 'Genero',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					EXTERNO_PSEUDNOVOGR06: new fieldControlClass.AccordionControl({
						id: 'EXTERNO_PSEUDNOVOGR06',
						name: 'NOVOGR06',
						size: 'block',
						label: computed(() => this.Resources.ACCORDION01950),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['EXTERNO_PSEUDNOVOGR03', 'EXTERNO_PSEUDNOVOGR04'],
						controlLimits: [
						],
					}, this),
					EXTERNO_PSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'EXTERNO_PSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'block',
						label: computed(() => this.Resources.CONTACT05134),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXTERNO_PSEUDNOVOGR06',
						isInAccordion: true,
						borderless: false,
						isCollapsible: true,
						anchored: false,
						directChildren: ['EXTERNO_PESSOTELEPHON', 'EXTERNO_PESSOEMAIL___'],
						controlLimits: [
						],
					}, this),
					EXTERNO_PESSOTELEPHON: new fieldControlClass.StringControl({
						modelField: 'ValTelephon',
						valueChangeEvent: 'fieldChange:pesso.telephon',
						id: 'EXTERNO_PESSOTELEPHON',
						name: 'TELEPHON',
						size: 'medium',
						label: computed(() => this.Resources.TELEPHONE28697),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXTERNO_PSEUDNOVOGR03',
						maxLength: 20,
						controlLimits: [
						],
					}, this),
					EXTERNO_PESSOEMAIL___: new fieldControlClass.StringControl({
						modelField: 'ValEmail',
						valueChangeEvent: 'fieldChange:pesso.email',
						id: 'EXTERNO_PESSOEMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						label: computed(() => this.Resources.EMAIL_44228),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXTERNO_PSEUDNOVOGR03',
						maxLength: 254,
						controlLimits: [
						],
					}, this),
					EXTERNO_PSEUDNOVOGR04: new fieldControlClass.GroupControl({
						id: 'EXTERNO_PSEUDNOVOGR04',
						name: 'NOVOGR04',
						size: 'block',
						label: computed(() => this.Resources.PHOTO32097),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXTERNO_PSEUDNOVOGR06',
						isInAccordion: true,
						borderless: false,
						isCollapsible: true,
						anchored: false,
						directChildren: ['EXTERNO_PESSOPHOTOGRA'],
						controlLimits: [
						],
					}, this),
					EXTERNO_PESSOPHOTOGRA: new fieldControlClass.ImageControl({
						modelField: 'ValPhotogra',
						valueChangeEvent: 'fieldChange:pesso.photogra',
						id: 'EXTERNO_PESSOPHOTOGRA',
						name: 'PHOTOGRA',
						size: 'medium',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXTERNO_PSEUDNOVOGR04',
						height: 50,
						width: 100,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO51874)),
						controlLimits: [
						],
					}, this),
					EXTERNO_PSEUDOBRIGATO: new fieldControlClass.BaseControl({
						id: 'EXTERNO_PSEUDOBRIGATO',
						name: 'OBRIGATO',
						size: 'xxlarge',
						hasLabel: false,
						label: computed(() => this.Resources.AT_REQUIRED65277),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						supportsHtml: true,
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
						get ValEmail2() { return vm.model.ValEmail2.value },
						set ValEmail2(value) { vm.model.ValEmail2.updateValue(value) },
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
// USE /[MANUAL GQT FORM_CODEJS EXTERNO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT EXTERNO]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS EXTERNO]/
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
				for (const trigger of triggers)
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
				// Execute the "After save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterSave)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT AFTER_SAVE_JS EXTERNO]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS EXTERNO]/
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
// USE /[MANUAL GQT AFTER_DEL_JS EXTERNO]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS EXTERNO]/
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
			 * Called whenever a field is unfocused.
			 * @param {*} fieldObject The object representing the field in the model
			 * @param {*} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onBlur(fieldObject, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT CTRLBLR EXTERNO]/
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
// USE /[MANUAL GQT CTRLUPD EXTERNO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS EXTERNO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
