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
					class="form-header"
					:id="formTitleId">
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
			data-key="PROJE"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.PROJE___PROJEPROJECTO.isVisible || controls.PROJE___YEAR1YEAR____.isVisible">
					<q-control-wrapper
						v-show="controls.PROJE___PROJEPROJECTO.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PROJE___PROJEPROJECTO"
							v-on="controls.PROJE___PROJEPROJECTO.handlers"
							:loading="controls.PROJE___PROJEPROJECTO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.PROJE___PROJEPROJECTO.props"
								:model-value="model.ValProjecto.value"
								@blur="onBlur(controls.PROJE___PROJEPROJECTO, model.ValProjecto.value)"
								@change="model.ValProjecto.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.PROJE___YEAR1YEAR____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PROJE___YEAR1YEAR____"
							v-on="controls.PROJE___YEAR1YEAR____.handlers"
							:loading="controls.PROJE___YEAR1YEAR____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.PROJE___YEAR1YEAR____.isVisible"
								v-bind="controls.PROJE___YEAR1YEAR____.props"
								v-on="controls.PROJE___YEAR1YEAR____.handlers" />
							<q-see-more-proje-year1year
								v-if="controls.PROJE___YEAR1YEAR____.seeMoreIsVisible"
								v-bind="controls.PROJE___YEAR1YEAR____.seeMoreParams"
								v-on="controls.PROJE___YEAR1YEAR____.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PROJE___PROJEPRIMEIRO.isVisible || controls.PROJE___PROJEBEFORE__.isVisible || controls.PROJE___PROJEFOLLOWIN.isVisible || controls.PROJE___PROJEULTIMO__.isVisible">
					<q-control-wrapper
						v-show="controls.PROJE___PROJEPRIMEIRO.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PROJE___PROJEPRIMEIRO"
							v-on="controls.PROJE___PROJEPRIMEIRO.handlers"
							:loading="controls.PROJE___PROJEPRIMEIRO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.PROJE___PROJEPRIMEIRO.isVisible"
								v-bind="controls.PROJE___PROJEPRIMEIRO.props"
								@update:model-value="model.ValPrimeiro.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.PROJE___PROJEBEFORE__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PROJE___PROJEBEFORE__"
							v-on="controls.PROJE___PROJEBEFORE__.handlers"
							:loading="controls.PROJE___PROJEBEFORE__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.PROJE___PROJEBEFORE__.isVisible"
								v-bind="controls.PROJE___PROJEBEFORE__.props"
								@update:model-value="model.ValBefore.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.PROJE___PROJEFOLLOWIN.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PROJE___PROJEFOLLOWIN"
							v-on="controls.PROJE___PROJEFOLLOWIN.handlers"
							:loading="controls.PROJE___PROJEFOLLOWIN.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.PROJE___PROJEFOLLOWIN.isVisible"
								v-bind="controls.PROJE___PROJEFOLLOWIN.props"
								@update:model-value="model.ValFollowin.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.PROJE___PROJEULTIMO__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PROJE___PROJEULTIMO__"
							v-on="controls.PROJE___PROJEULTIMO__.handlers"
							:loading="controls.PROJE___PROJEULTIMO__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.PROJE___PROJEULTIMO__.isVisible"
								v-bind="controls.PROJE___PROJEULTIMO__.props"
								@update:model-value="model.ValUltimo.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PROJE___PROJESALDO1__.isVisible || controls.PROJE___PROJESALDO2__.isVisible">
					<q-control-wrapper
						v-show="controls.PROJE___PROJESALDO1__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PROJE___PROJESALDO1__"
							v-on="controls.PROJE___PROJESALDO1__.handlers"
							:loading="controls.PROJE___PROJESALDO1__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.PROJE___PROJESALDO1__.isVisible"
								v-bind="controls.PROJE___PROJESALDO1__.props"
								@update:model-value="model.ValSaldo1.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.PROJE___PROJESALDO2__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PROJE___PROJESALDO2__"
							v-on="controls.PROJE___PROJESALDO2__.handlers"
							:loading="controls.PROJE___PROJESALDO2__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.PROJE___PROJESALDO2__.isVisible"
								v-bind="controls.PROJE___PROJESALDO2__.props"
								@update:model-value="model.ValSaldo2.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PROJE___PSEUDDESPESAS.isVisible">
					<q-control-wrapper
						v-show="controls.PROJE___PSEUDDESPESAS.isVisible"
						class="control-join-group">
						<q-table
							v-show="controls.PROJE___PSEUDDESPESAS.isVisible"
							v-bind="controls.PROJE___PSEUDDESPESAS"
							v-on="controls.PROJE___PSEUDDESPESAS.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.PROJE___PSEUDDESPESAS"
							v-on="controls.PROJE___PSEUDDESPESAS.handlers" />
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PROJE___PSEUDAGREGADO.isVisible">
					<q-control-wrapper
						v-show="controls.PROJE___PSEUDAGREGADO.isVisible"
						class="control-join-group">
						<q-table
							v-show="controls.PROJE___PSEUDAGREGADO.isVisible"
							v-bind="controls.PROJE___PSEUDAGREGADO"
							v-on="controls.PROJE___PSEUDAGREGADO.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.PROJE___PSEUDAGREGADO"
							v-on="controls.PROJE___PSEUDAGREGADO.handlers" />
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

	import FormViewModel from './QFormProjeViewModel.js'

	const requiredTextResources = ['QFormProje', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PROJE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormProje',

		components: {
			QSeeMoreProjeYear1year: defineAsyncComponent(() => import('@/views/forms/FormProje/dbedits/ProjeYear1yearSeeMore.vue')),
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
					name: 'PROJE',
					location: 'form-PROJE',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormProje', false),

				interfaceMetadata: {
					id: 'QFormProje', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'PROJE',
					route: 'form-PROJE',
					area: 'PROJE',
					primaryKey: 'ValCodproje',
					designation: computed(() => this.Resources.PROJECTO50142),
					identifier: '', // Unique identifier received by route (when it's nested).
					mode: ''
				},

				formTitleId: computed(() => this.formInfo.identifier + "_title"),

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
					PROJE___PROJEPROJECTO: new fieldControlClass.StringControl({
						modelField: 'ValProjecto',
						valueChangeEvent: 'fieldChange:proje.projecto',
						id: 'PROJE___PROJEPROJECTO',
						name: 'PROJECTO',
						size: 'xlarge',
						label: computed(() => this.Resources.PROJECT37121),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_PROJE___PROJEPROJECTO',
						controlLimits: [
						],
					}, this),
					PROJE___YEAR1YEAR____: new fieldControlClass.LookupControl({
						modelField: 'TableYear1Year',
						valueChangeEvent: 'fieldChange:year1.year',
						id: 'PROJE___YEAR1YEAR____',
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
							dependencyEvent: 'fieldChange:proje.codyear'
						},
						dependentFields: () => ({
							set 'year1.codyear'(value) { vm.model.ValCodyear.updateValue(value) },
							set 'year1.year'(value) { vm.model.TableYear1Year.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					PROJE___PROJEPRIMEIRO: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrimeiro',
						valueChangeEvent: 'fieldChange:proje.primeiro',
						id: 'PROJE___PROJEPRIMEIRO',
						name: 'PRIMEIRO',
						size: 'small',
						label: computed(() => this.Resources.FIRST42972),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						maxIntegers: 7,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					PROJE___PROJEBEFORE__: new fieldControlClass.CurrencyControl({
						modelField: 'ValBefore',
						valueChangeEvent: 'fieldChange:proje.before',
						id: 'PROJE___PROJEBEFORE__',
						name: 'BEFORE',
						size: 'small',
						label: computed(() => this.Resources.BEFORE60156),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						maxIntegers: 7,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					PROJE___PROJEFOLLOWIN: new fieldControlClass.CurrencyControl({
						modelField: 'ValFollowin',
						valueChangeEvent: 'fieldChange:proje.followin',
						id: 'PROJE___PROJEFOLLOWIN',
						name: 'FOLLOWIN',
						size: 'small',
						label: computed(() => this.Resources.FOLLOWING22170),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						maxIntegers: 7,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					PROJE___PROJEULTIMO__: new fieldControlClass.CurrencyControl({
						modelField: 'ValUltimo',
						valueChangeEvent: 'fieldChange:proje.ultimo',
						id: 'PROJE___PROJEULTIMO__',
						name: 'ULTIMO',
						size: 'small',
						label: computed(() => this.Resources.LAST49207),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						maxIntegers: 7,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					PROJE___PROJESALDO1__: new fieldControlClass.CurrencyControl({
						modelField: 'ValSaldo1',
						valueChangeEvent: 'fieldChange:proje.saldo1',
						id: 'PROJE___PROJESALDO1__',
						name: 'SALDO1',
						size: 'medium',
						label: computed(() => this.Resources.NEXT___PREVIOUS__43778),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						maxIntegers: 7,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					PROJE___PROJESALDO2__: new fieldControlClass.CurrencyControl({
						modelField: 'ValSaldo2',
						valueChangeEvent: 'fieldChange:proje.saldo2',
						id: 'PROJE___PROJESALDO2__',
						name: 'SALDO2',
						size: 'medium',
						label: computed(() => this.Resources.LAST___FIRST__42481),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						maxIntegers: 7,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					PROJE___PSEUDDESPESAS: new fieldControlClass.TableListControl({
						id: 'PROJE___PSEUDDESPESAS',
						name: 'DESPESAS',
						size: '',
						label: computed(() => this.Resources.EXPENSES11381),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'PROJE',
						action: 'Proje_ValDespesas',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValDescript',
								area: 'EXPEN',
								field: 'DESCRIPT',
								label: computed(() => this.Resources.DESCRIPTION07383),
								dataLength: 85,
								scrollData: 30,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 2,
								name: 'ValValue',
								area: 'EXPEN',
								field: 'VALUE',
								label: computed(() => this.Resources.VALUE10285),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 0,
							}),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'Year.ValYear',
								area: 'YEAR',
								field: 'YEAR',
								label: computed(() => this.Resources.ANO33022),
								dataLength: 4,
								scrollData: 4,
								pkColumn: 'ValCodyear',
							}),
						],
						config: {
							name: 'ValDespesas',
							serverMode: true,
							pkColumn: 'ValCoddespe',
							tableAlias: 'EXPEN',
							tableNamePlural: computed(() => this.Resources.EXPENSES11381),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.EXPENSES11381),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: false,
								searchOnPressEnter: true
							},
							filtersVisible: false,
							allowColumnFilters: false,
							allowColumnSort: true,
							crudActions: [
								{
									id: 'show',
									name: 'show',
									title: computed(() => this.Resources.CONSULTAR57388),
									icon: {
										icon: 'view'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'DESPE',
										mode: 'SHOW',
										isControlled: true
									}
								},
								{
									id: 'edit',
									name: 'edit',
									title: computed(() => this.Resources.EDITAR11616),
									icon: {
										icon: 'pencil'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'DESPE',
										mode: 'EDIT',
										isControlled: true
									}
								},
								{
									id: 'duplicate',
									name: 'duplicate',
									title: computed(() => this.Resources.DUPLICAR09748),
									icon: {
										icon: 'duplicate'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'DESPE',
										mode: 'DUPLICATE',
										isControlled: true
									}
								},
								{
									id: 'delete',
									name: 'delete',
									title: computed(() => this.Resources.ELIMINAR21155),
									icon: {
										icon: 'delete'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'DESPE',
										mode: 'DELETE',
										isControlled: true
									}
								}
							],
							generalActions: [
								{
									id: 'insert',
									name: 'insert',
									title: computed(() => this.Resources.INSERIR43365),
									icon: {
										icon: 'add'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'DESPE',
										mode: 'NEW',
										repeatInsertion: false,
										isControlled: true
									}
								},
							],
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
							],
							rowClickAction: {
								id: 'RCA__DESPE',
								name: '_DESPE',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'DESPE',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'DESPE': {
									fnKeySelector: (row) => row.Fields.ValCoddespe,
									isPopup: false
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-YEAR', 'changed-PROJE', 'changed-AGREG', 'changed-EXPEN'],
						uuid: 'Proje_ValDespesas',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'proje'],
								dependencyEvents: ['fieldChange:proje.codproje'],
								dependencyField: 'PROJE.CODPROJE',
								fnValueSelector: (model) => model.ValCodproje.value
							},
						],
					}, this),
					PROJE___PSEUDAGREGADO: new fieldControlClass.TableListControl({
						id: 'PROJE___PSEUDAGREGADO',
						name: 'AGREGADO',
						size: '',
						label: computed(() => this.Resources.DECOMISSION_BY_YEAR07152),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'PROJE',
						action: 'Proje_ValAgregado',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Year.ValYear',
								area: 'YEAR',
								field: 'YEAR',
								label: computed(() => this.Resources.ANO33022),
								dataLength: 4,
								scrollData: 4,
								pkColumn: 'ValCodyear',
							}),
							new listColumnTypes.CurrencyColumn({
								order: 2,
								name: 'ValValue',
								area: 'AGREG',
								field: 'VALUE',
								label: computed(() => this.Resources.VALUE10285),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 0,
							}),
						],
						config: {
							name: 'ValAgregado',
							serverMode: true,
							pkColumn: 'ValCodaggre',
							tableAlias: 'AGREG',
							tableNamePlural: computed(() => this.Resources.AGGREGATED_PER_YEAR01261),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.DECOMISSION_BY_YEAR07152),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: false,
								searchOnPressEnter: true
							},
							filtersVisible: false,
							allowColumnFilters: false,
							allowColumnSort: true,
							crudActions: [
								{
									id: 'show',
									name: 'show',
									title: computed(() => this.Resources.CONSULTAR57388),
									icon: {
										icon: 'view'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'AGREG',
										mode: 'SHOW',
										isControlled: true
									}
								},
								{
									id: 'edit',
									name: 'edit',
									title: computed(() => this.Resources.EDITAR11616),
									icon: {
										icon: 'pencil'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'AGREG',
										mode: 'EDIT',
										isControlled: true
									}
								},
								{
									id: 'duplicate',
									name: 'duplicate',
									title: computed(() => this.Resources.DUPLICAR09748),
									icon: {
										icon: 'duplicate'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'AGREG',
										mode: 'DUPLICATE',
										isControlled: true
									}
								},
								{
									id: 'delete',
									name: 'delete',
									title: computed(() => this.Resources.ELIMINAR21155),
									icon: {
										icon: 'delete'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'AGREG',
										mode: 'DELETE',
										isControlled: true
									}
								}
							],
							generalActions: [
								{
									id: 'insert',
									name: 'insert',
									title: computed(() => this.Resources.INSERIR43365),
									icon: {
										icon: 'add'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'AGREG',
										mode: 'NEW',
										repeatInsertion: false,
										isControlled: true
									}
								},
							],
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
							],
							rowClickAction: {
								id: 'RCA__AGREG',
								name: '_AGREG',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'AGREG',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'AGREG': {
									fnKeySelector: (row) => row.Fields.ValCodaggre,
									isPopup: false
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'Year.ValYear',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-PROJE', 'changed-YEAR', 'changed-AGREG'],
						uuid: 'Proje_ValAgregado',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'proje'],
								dependencyEvents: ['fieldChange:proje.codproje'],
								dependencyField: 'PROJE.CODPROJE',
								fnValueSelector: (model) => model.ValCodproje.value
							},
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
					'PROJE___PSEUDDESPESAS',
					'PROJE___PSEUDAGREGADO',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Proje: {
						get ValBefore() { return vm.model.ValBefore.value },
						set ValBefore(value) { vm.model.ValBefore.updateValue(value) },
						get ValCodyear() { return vm.model.ValCodyear.value },
						set ValCodyear(value) { vm.model.ValCodyear.updateValue(value) },
						get ValFollowin() { return vm.model.ValFollowin.value },
						set ValFollowin(value) { vm.model.ValFollowin.updateValue(value) },
						get ValPrimeiro() { return vm.model.ValPrimeiro.value },
						set ValPrimeiro(value) { vm.model.ValPrimeiro.updateValue(value) },
						get ValProjecto() { return vm.model.ValProjecto.value },
						set ValProjecto(value) { vm.model.ValProjecto.updateValue(value) },
						get ValSaldo1() { return vm.model.ValSaldo1.value },
						set ValSaldo1(value) { vm.model.ValSaldo1.updateValue(value) },
						get ValSaldo2() { return vm.model.ValSaldo2.value },
						set ValSaldo2(value) { vm.model.ValSaldo2.updateValue(value) },
						get ValUltimo() { return vm.model.ValUltimo.value },
						set ValUltimo(value) { vm.model.ValUltimo.updateValue(value) },
					},
					Year1: {
						get ValYear() { return vm.model.TableYear1Year.value },
						set ValYear(value) { vm.model.TableYear1Year.updateValue(value) },
					},
					keys: {
						/** The primary key of the PROJE table */
						get proje() { return vm.model.ValCodproje },
						/** The foreign key to the YEAR1 table */
						get year1() { return vm.model.ValCodyear },
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
// USE /[MANUAL GQT FORM_CODEJS PROJE]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS PROJE]/
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
// USE /[MANUAL GQT FORM_LOADED_JS PROJE]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS PROJE]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS PROJE]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS PROJE]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS PROJE]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS PROJE]/
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
// USE /[MANUAL GQT AFTER_DEL_JS PROJE]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS PROJE]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS PROJE]/
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
// USE /[MANUAL GQT DLGUPDT PROJE]/
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
// USE /[MANUAL GQT CTRLBLR PROJE]/
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
// USE /[MANUAL GQT CTRLUPD PROJE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS PROJE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
