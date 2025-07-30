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
			data-key="DESPE"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.DESPE___PROJEPROJECTO.isVisible || controls.DESPE___YEAR_YEAR____.isVisible">
					<q-control-wrapper
						v-show="controls.DESPE___PROJEPROJECTO.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.DESPE___PROJEPROJECTO"
							v-on="controls.DESPE___PROJEPROJECTO.handlers"
							:loading="controls.DESPE___PROJEPROJECTO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.DESPE___PROJEPROJECTO.isVisible"
								v-bind="controls.DESPE___PROJEPROJECTO.props"
								v-on="controls.DESPE___PROJEPROJECTO.handlers" />
							<q-see-more-despe-projeprojecto
								v-if="controls.DESPE___PROJEPROJECTO.seeMoreIsVisible"
								v-bind="controls.DESPE___PROJEPROJECTO.seeMoreParams"
								v-on="controls.DESPE___PROJEPROJECTO.handlers" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.DESPE___YEAR_YEAR____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.DESPE___YEAR_YEAR____"
							v-on="controls.DESPE___YEAR_YEAR____.handlers"
							:loading="controls.DESPE___YEAR_YEAR____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.DESPE___YEAR_YEAR____.isVisible"
								v-bind="controls.DESPE___YEAR_YEAR____.props"
								v-on="controls.DESPE___YEAR_YEAR____.handlers" />
							<q-see-more-despe-year-year
								v-if="controls.DESPE___YEAR_YEAR____.seeMoreIsVisible"
								v-bind="controls.DESPE___YEAR_YEAR____.seeMoreParams"
								v-on="controls.DESPE___YEAR_YEAR____.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.DESPE___AGREGVALUE___.isVisible">
					<q-control-wrapper
						v-show="controls.DESPE___AGREGVALUE___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.DESPE___AGREGVALUE___"
							v-on="controls.DESPE___AGREGVALUE___.handlers"
							:loading="controls.DESPE___AGREGVALUE___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.DESPE___AGREGVALUE___.isVisible"
								v-bind="controls.DESPE___AGREGVALUE___.props"
								v-on="controls.DESPE___AGREGVALUE___.handlers" />
							<q-see-more-despe-agregvalue
								v-if="controls.DESPE___AGREGVALUE___.seeMoreIsVisible"
								v-bind="controls.DESPE___AGREGVALUE___.seeMoreParams"
								v-on="controls.DESPE___AGREGVALUE___.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.DESPE___EXPENDESCRIPT.isVisible">
					<q-control-wrapper
						v-show="controls.DESPE___EXPENDESCRIPT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.DESPE___EXPENDESCRIPT"
							v-on="controls.DESPE___EXPENDESCRIPT.handlers"
							:loading="controls.DESPE___EXPENDESCRIPT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.DESPE___EXPENDESCRIPT.props"
								@blur="onBlur(controls.DESPE___EXPENDESCRIPT, model.ValDescript.value)"
								@change="model.ValDescript.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.DESPE___EXPENVALUE___.isVisible || controls.DESPE___EXPENPREVVAL_.isVisible || controls.DESPE___EXPENYEARPREV.isVisible">
					<q-control-wrapper
						v-show="controls.DESPE___EXPENVALUE___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.DESPE___EXPENVALUE___"
							v-on="controls.DESPE___EXPENVALUE___.handlers"
							:loading="controls.DESPE___EXPENVALUE___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.DESPE___EXPENVALUE___.isVisible"
								v-bind="controls.DESPE___EXPENVALUE___.props"
								@update:model-value="model.ValValue.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.DESPE___EXPENPREVVAL_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.DESPE___EXPENPREVVAL_"
							v-on="controls.DESPE___EXPENPREVVAL_.handlers"
							:loading="controls.DESPE___EXPENPREVVAL_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.DESPE___EXPENPREVVAL_.isVisible"
								v-bind="controls.DESPE___EXPENPREVVAL_.props"
								@update:model-value="model.ValPrevval.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.DESPE___EXPENYEARPREV.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.DESPE___EXPENYEARPREV"
							v-on="controls.DESPE___EXPENYEARPREV.handlers"
							:loading="controls.DESPE___EXPENYEARPREV.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.DESPE___EXPENYEARPREV.isVisible"
								v-bind="controls.DESPE___EXPENYEARPREV.props"
								@update:model-value="model.ValYearprev.fnUpdateValue" />
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

	import FormViewModel from './QFormDespeViewModel.js'

	const requiredTextResources = ['QFormDespe', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS DESPE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormDespe',

		components: {
			QSeeMoreDespeProjeprojecto: defineAsyncComponent(() => import('@/views/forms/FormDespe/dbedits/DespeProjeprojectoSeeMore.vue')),
			QSeeMoreDespeYearYear: defineAsyncComponent(() => import('@/views/forms/FormDespe/dbedits/DespeYearYearSeeMore.vue')),
			QSeeMoreDespeAgregvalue: defineAsyncComponent(() => import('@/views/forms/FormDespe/dbedits/DespeAgregvalueSeeMore.vue')),
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
					name: 'DESPE',
					location: 'form-DESPE',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormDespe', false),

				interfaceMetadata: {
					id: 'QFormDespe', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'DESPE',
					route: 'form-DESPE',
					area: 'EXPEN',
					primaryKey: 'ValCoddespe',
					designation: computed(() => this.Resources.DESPESA07561),
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
					DESPE___PROJEPROJECTO: new fieldControlClass.LookupControl({
						modelField: 'TableProjeProjecto',
						valueChangeEvent: 'fieldChange:proje.projecto',
						id: 'DESPE___PROJEPROJECTO',
						name: 'PROJECTO',
						size: 'large',
						label: computed(() => this.Resources.PROJECT37121),
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
							name: 'ValCodproje',
							dependencyEvent: 'fieldChange:expen.codproje'
						},
						dependentFields: () => ({
							set 'proje.codproje'(value) { vm.model.ValCodproje.updateValue(value) },
							set 'proje.projecto'(value) { vm.model.TableProjeProjecto.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					DESPE___YEAR_YEAR____: new fieldControlClass.LookupControl({
						modelField: 'TableYearYear',
						valueChangeEvent: 'fieldChange:year.year',
						id: 'DESPE___YEAR_YEAR____',
						name: 'YEAR',
						size: 'mini',
						label: computed(() => this.Resources.YEAR61794),
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
							name: 'ValCodyear',
							dependencyEvent: 'fieldChange:expen.codyear'
						},
						dependentFields: () => ({
							set 'year.codyear'(value) { vm.model.ValCodyear.updateValue(value) },
							set 'year.year'(value) { vm.model.TableYearYear.updateValue(value) },
							set 'year.yearnum'(value) { vm.model.YearValYearnum.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					DESPE___AGREGVALUE___: new fieldControlClass.LookupControl({
						modelField: 'TableAgregValue',
						valueChangeEvent: 'fieldChange:agreg.value',
						id: 'DESPE___AGREGVALUE___',
						name: 'VALUE',
						size: 'small',
						label: computed(() => this.Resources.VALUE10285),
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
							name: 'ValCodaggre',
							dependencyEvent: 'fieldChange:expen.codaggre'
						},
						dependentFields: () => ({
							set 'agreg.codaggre'(value) { vm.model.ValCodaggre.updateValue(value) },
							set 'agreg.value'(value) { vm.model.TableAgregValue.updateValue(value) },
						}),
						controlLimits: [
							{
								identifier: ['year', 'expen.codyear'],
								dependencyEvents: ['fieldChange:expen.codyear'],
								dependencyField: 'EXPEN.CODYEAR',
								fnValueSelector: (model) => model.ValCodyear.value
							},
							{
								identifier: ['proje', 'expen.codproje'],
								dependencyEvents: ['fieldChange:expen.codproje'],
								dependencyField: 'EXPEN.CODPROJE',
								fnValueSelector: (model) => model.ValCodproje.value
							},
						],
					}, this),
					DESPE___EXPENDESCRIPT: new fieldControlClass.StringControl({
						modelField: 'ValDescript',
						valueChangeEvent: 'fieldChange:expen.descript',
						id: 'DESPE___EXPENDESCRIPT',
						name: 'DESCRIPT',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESCRIPTION07383),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						labelId: 'label_DESPE___EXPENDESCRIPT',
						controlLimits: [
						],
					}, this),
					DESPE___EXPENVALUE___: new fieldControlClass.CurrencyControl({
						modelField: 'ValValue',
						valueChangeEvent: 'fieldChange:expen.value',
						id: 'DESPE___EXPENVALUE___',
						name: 'VALUE',
						size: 'small',
						label: computed(() => this.Resources.VALUE10285),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 7,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					DESPE___EXPENPREVVAL_: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrevval',
						valueChangeEvent: 'fieldChange:expen.prevval',
						id: 'DESPE___EXPENPREVVAL_',
						name: 'PREVVAL',
						size: 'small',
						label: computed(() => this.Resources.PREVIOUS_VALUE30042),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						maxIntegers: 7,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					DESPE___EXPENYEARPREV: new fieldControlClass.NumberControl({
						modelField: 'ValYearprev',
						valueChangeEvent: 'fieldChange:expen.yearprev',
						id: 'DESPE___EXPENYEARPREV',
						name: 'YEARPREV',
						size: 'small',
						label: computed(() => this.Resources.PREVIOUS_YEAR22440),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						maxIntegers: 4,
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
					Agreg: {
						get ValValue() { return vm.model.TableAgregValue.value },
						set ValValue(value) { vm.model.TableAgregValue.updateValue(value) },
					},
					Expen: {
						get ValCodaggre() { return vm.model.ValCodaggre.value },
						set ValCodaggre(value) { vm.model.ValCodaggre.updateValue(value) },
						get ValCodproje() { return vm.model.ValCodproje.value },
						set ValCodproje(value) { vm.model.ValCodproje.updateValue(value) },
						get ValCodyear() { return vm.model.ValCodyear.value },
						set ValCodyear(value) { vm.model.ValCodyear.updateValue(value) },
						get ValDescript() { return vm.model.ValDescript.value },
						set ValDescript(value) { vm.model.ValDescript.updateValue(value) },
						get ValPrevval() { return vm.model.ValPrevval.value },
						set ValPrevval(value) { vm.model.ValPrevval.updateValue(value) },
						get ValValue() { return vm.model.ValValue.value },
						set ValValue(value) { vm.model.ValValue.updateValue(value) },
						get ValYearprev() { return vm.model.ValYearprev.value },
						set ValYearprev(value) { vm.model.ValYearprev.updateValue(value) },
					},
					Proje: {
						get ValProjecto() { return vm.model.TableProjeProjecto.value },
						set ValProjecto(value) { vm.model.TableProjeProjecto.updateValue(value) },
					},
					Year: {
						get ValYear() { return vm.model.TableYearYear.value },
						set ValYear(value) { vm.model.TableYearYear.updateValue(value) },
						get ValYearnum() { return vm.model.YearValYearnum.value },
						set ValYearnum(value) { vm.model.YearValYearnum.updateValue(value) },
					},
					keys: {
						/** The primary key of the EXPEN table */
						get expen() { return vm.model.ValCoddespe },
						/** The foreign key to the PROJE table */
						get proje() { return vm.model.ValCodproje },
						/** The foreign key to the YEAR table */
						get year() { return vm.model.ValCodyear },
						/** The foreign key to the AGREG table */
						get agreg() { return vm.model.ValCodaggre },
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
// USE /[MANUAL GQT FORM_CODEJS DESPE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT DESPE]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS DESPE]/
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
// USE /[MANUAL GQT FORM_LOADED_JS DESPE]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS DESPE]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS DESPE]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS DESPE]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS DESPE]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS DESPE]/
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
// USE /[MANUAL GQT AFTER_DEL_JS DESPE]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS DESPE]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS DESPE]/
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
// USE /[MANUAL GQT DLGUPDT DESPE]/
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
// USE /[MANUAL GQT CTRLBLR DESPE]/
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
// USE /[MANUAL GQT CTRLUPD DESPE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS DESPE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
