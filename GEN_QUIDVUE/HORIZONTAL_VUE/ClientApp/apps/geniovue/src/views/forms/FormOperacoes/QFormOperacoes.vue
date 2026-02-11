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
			data-key="OPERACOES"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.OPERACOES__ENTIDADE__ENTIDADE.isVisible">
					<q-col
						v-if="controls.OPERACOES__ENTIDADE__ENTIDADE.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.OPERACOES__ENTIDADE__ENTIDADE.isVisible"
							class="i-text"
							v-bind="controls.OPERACOES__ENTIDADE__ENTIDADE"
							v-on="controls.OPERACOES__ENTIDADE__ENTIDADE.handlers"
							:loading="controls.OPERACOES__ENTIDADE__ENTIDADE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.OPERACOES__ENTIDADE__ENTIDADE.isVisible"
								v-bind="controls.OPERACOES__ENTIDADE__ENTIDADE.props"
								v-on="controls.OPERACOES__ENTIDADE__ENTIDADE.handlers" />
							<q-see-more-operacoes-entidade-entidade
								v-if="controls.OPERACOES__ENTIDADE__ENTIDADE.seeMoreIsVisible"
								v-bind="controls.OPERACOES__ENTIDADE__ENTIDADE.seeMoreParams"
								v-on="controls.OPERACOES__ENTIDADE__ENTIDADE.handlers" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.OPERACOES__OPERACOES__OPERACAO_AA.isVisible || controls.OPERACOES__OPERACOES__POP_AA.isVisible || controls.OPERACOES__OPERACOES__SOBREPOSICAO_AA.isVisible">
					<q-col
						v-if="controls.OPERACOES__OPERACOES__OPERACAO_AA.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.OPERACOES__OPERACOES__OPERACAO_AA.isVisible"
							class="i-text"
							v-bind="controls.OPERACOES__OPERACOES__OPERACAO_AA"
							v-on="controls.OPERACOES__OPERACOES__OPERACAO_AA.handlers"
							:loading="controls.OPERACOES__OPERACOES__OPERACAO_AA.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.OPERACOES__OPERACOES__OPERACAO_AA.props"
								@blur="onBlur(controls.OPERACOES__OPERACOES__OPERACAO_AA, model.ValOperacao_aa.value)"
								@change="model.ValOperacao_aa.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.OPERACOES__OPERACOES__POP_AA.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.OPERACOES__OPERACOES__POP_AA.isVisible"
							class="i-text"
							v-bind="controls.OPERACOES__OPERACOES__POP_AA"
							v-on="controls.OPERACOES__OPERACOES__POP_AA.handlers"
							:loading="controls.OPERACOES__OPERACOES__POP_AA.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.OPERACOES__OPERACOES__POP_AA.isVisible"
								v-bind="controls.OPERACOES__OPERACOES__POP_AA.props"
								@update:model-value="model.ValPop_aa.fnUpdateValue" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.OPERACOES__OPERACOES__SOBREPOSICAO_AA.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.OPERACOES__OPERACOES__SOBREPOSICAO_AA.isVisible"
							class="i-checkbox"
							v-bind="controls.OPERACOES__OPERACOES__SOBREPOSICAO_AA"
							v-on="controls.OPERACOES__OPERACOES__SOBREPOSICAO_AA.handlers"
							:loading="controls.OPERACOES__OPERACOES__SOBREPOSICAO_AA.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox
									v-if="controls.OPERACOES__OPERACOES__SOBREPOSICAO_AA.isVisible"
									v-bind="controls.OPERACOES__OPERACOES__SOBREPOSICAO_AA.props"
									v-on="controls.OPERACOES__OPERACOES__SOBREPOSICAO_AA.handlers" />
							</template>
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.OPERACOES__OPERACOES__OPERACAO_AR.isVisible || controls.OPERACOES__OPERACOES__POP_AR.isVisible || controls.OPERACOES__OPERACOES__SOBREPOSICAO_AR.isVisible">
					<q-col
						v-if="controls.OPERACOES__OPERACOES__OPERACAO_AR.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.OPERACOES__OPERACOES__OPERACAO_AR.isVisible"
							class="i-text"
							v-bind="controls.OPERACOES__OPERACOES__OPERACAO_AR"
							v-on="controls.OPERACOES__OPERACOES__OPERACAO_AR.handlers"
							:loading="controls.OPERACOES__OPERACOES__OPERACAO_AR.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.OPERACOES__OPERACOES__OPERACAO_AR.props"
								@blur="onBlur(controls.OPERACOES__OPERACOES__OPERACAO_AR, model.ValOperacao_ar.value)"
								@change="model.ValOperacao_ar.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.OPERACOES__OPERACOES__POP_AR.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.OPERACOES__OPERACOES__POP_AR.isVisible"
							class="i-text"
							v-bind="controls.OPERACOES__OPERACOES__POP_AR"
							v-on="controls.OPERACOES__OPERACOES__POP_AR.handlers"
							:loading="controls.OPERACOES__OPERACOES__POP_AR.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.OPERACOES__OPERACOES__POP_AR.isVisible"
								v-bind="controls.OPERACOES__OPERACOES__POP_AR.props"
								@update:model-value="model.ValPop_ar.fnUpdateValue" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.OPERACOES__OPERACOES__SOBREPOSICAO_AR.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.OPERACOES__OPERACOES__SOBREPOSICAO_AR.isVisible"
							class="i-checkbox"
							v-bind="controls.OPERACOES__OPERACOES__SOBREPOSICAO_AR"
							v-on="controls.OPERACOES__OPERACOES__SOBREPOSICAO_AR.handlers"
							:loading="controls.OPERACOES__OPERACOES__SOBREPOSICAO_AR.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox
									v-if="controls.OPERACOES__OPERACOES__SOBREPOSICAO_AR.isVisible"
									v-bind="controls.OPERACOES__OPERACOES__SOBREPOSICAO_AR.props"
									v-on="controls.OPERACOES__OPERACOES__SOBREPOSICAO_AR.handlers" />
							</template>
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.OPERACOES__OPERACOES__OPERACAO_RU.isVisible || controls.OPERACOES__OPERACOES__POP_RU.isVisible || controls.OPERACOES__OPERACOES__SOBREPOSICAO_RU.isVisible">
					<q-col
						v-if="controls.OPERACOES__OPERACOES__OPERACAO_RU.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.OPERACOES__OPERACOES__OPERACAO_RU.isVisible"
							class="i-text"
							v-bind="controls.OPERACOES__OPERACOES__OPERACAO_RU"
							v-on="controls.OPERACOES__OPERACOES__OPERACAO_RU.handlers"
							:loading="controls.OPERACOES__OPERACOES__OPERACAO_RU.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.OPERACOES__OPERACOES__OPERACAO_RU.props"
								@blur="onBlur(controls.OPERACOES__OPERACOES__OPERACAO_RU, model.ValOperacao_ru.value)"
								@change="model.ValOperacao_ru.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.OPERACOES__OPERACOES__POP_RU.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.OPERACOES__OPERACOES__POP_RU.isVisible"
							class="i-text"
							v-bind="controls.OPERACOES__OPERACOES__POP_RU"
							v-on="controls.OPERACOES__OPERACOES__POP_RU.handlers"
							:loading="controls.OPERACOES__OPERACOES__POP_RU.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.OPERACOES__OPERACOES__POP_RU.isVisible"
								v-bind="controls.OPERACOES__OPERACOES__POP_RU.props"
								@update:model-value="model.ValPop_ru.fnUpdateValue" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.OPERACOES__OPERACOES__SOBREPOSICAO_RU.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.OPERACOES__OPERACOES__SOBREPOSICAO_RU.isVisible"
							class="i-checkbox"
							v-bind="controls.OPERACOES__OPERACOES__SOBREPOSICAO_RU"
							v-on="controls.OPERACOES__OPERACOES__SOBREPOSICAO_RU.handlers"
							:loading="controls.OPERACOES__OPERACOES__SOBREPOSICAO_RU.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox
									v-if="controls.OPERACOES__OPERACOES__SOBREPOSICAO_RU.isVisible"
									v-bind="controls.OPERACOES__OPERACOES__SOBREPOSICAO_RU.props"
									v-on="controls.OPERACOES__OPERACOES__SOBREPOSICAO_RU.handlers" />
							</template>
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

	import FormViewModel from './QFormOperacoesViewModel.js'

	const requiredTextResources = ['QFormOperacoes', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS OPERACOES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormOperacoes',

		components: {
			QSeeMoreOperacoesEntidadeEntidade: defineAsyncComponent(() => import('@/views/forms/FormOperacoes/dbedits/OperacoesEntidadeEntidadeSeeMore.vue')),
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
					name: 'OPERACOES',
					location: 'form-OPERACOES',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormOperacoes', false),

				interfaceMetadata: {
					id: 'QFormOperacoes', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'OPERACOES',
					route: 'form-OPERACOES',
					area: 'OPERACOES',
					primaryKey: 'ValCodoperacoes',
					designation: computed(() => this.Resources.OPERACOES07850),
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
						text: computed(() => vm.Resources.GRAVAR45301),
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
						text: computed(() => vm.Resources.CANCELAR49513),
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
					OPERACOES__ENTIDADE__ENTIDADE: new fieldControlClass.LookupControl({
						modelField: 'TableEntidadeEntidade',
						valueChangeEvent: 'fieldChange:entidade.entidade',
						id: 'OPERACOES__ENTIDADE__ENTIDADE',
						name: 'ENTIDADE',
						size: 'xxlarge',
						label: computed(() => this.Resources.ENTIDADE36471),
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
							name: 'ValCodentidade',
							dependencyEvent: 'fieldChange:operacoes.codentidade'
						},
						dependentFields: () => ({
							set 'entidade.codentidade'(value) { vm.model.ValCodentidade.updateValue(value) },
							set 'entidade.entidade'(value) { vm.model.TableEntidadeEntidade.updateValue(value) },
						}),
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					OPERACOES__OPERACOES__OPERACAO_AA: new fieldControlClass.StringControl({
						modelField: 'ValOperacao_aa',
						valueChangeEvent: 'fieldChange:operacoes.operacao_aa',
						id: 'OPERACOES__OPERACOES__OPERACAO_AA',
						name: 'OPERACAO_AA',
						size: 'xxlarge',
						label: computed(() => this.Resources.OPERACAO_AA07938),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					OPERACOES__OPERACOES__POP_AA: new fieldControlClass.NumberControl({
						modelField: 'ValPop_aa',
						valueChangeEvent: 'fieldChange:operacoes.pop_aa',
						id: 'OPERACOES__OPERACOES__POP_AA',
						name: 'POP_AA',
						size: 'medium',
						label: computed(() => this.Resources.POP_ABRANGIDA36477),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 6,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					OPERACOES__OPERACOES__SOBREPOSICAO_AA: new fieldControlClass.BooleanControl({
						modelField: 'ValSobreposicao_aa',
						valueChangeEvent: 'fieldChange:operacoes.sobreposicao_aa',
						id: 'OPERACOES__OPERACOES__SOBREPOSICAO_AA',
						name: 'SOBREPOSICAO_AA',
						size: 'medium',
						label: computed(() => this.Resources.SOBREPOSICAO_AA55921),
						placeholder: '',
						labelPosition: computed(() => this.$app.layout.CheckboxLabelAlignment),
						controlLimits: [
						],
					}, this),
					OPERACOES__OPERACOES__OPERACAO_AR: new fieldControlClass.StringControl({
						modelField: 'ValOperacao_ar',
						valueChangeEvent: 'fieldChange:operacoes.operacao_ar',
						id: 'OPERACOES__OPERACOES__OPERACAO_AR',
						name: 'OPERACAO_AR',
						size: 'xxlarge',
						label: computed(() => this.Resources.OPERACAO_AR11207),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					OPERACOES__OPERACOES__POP_AR: new fieldControlClass.NumberControl({
						modelField: 'ValPop_ar',
						valueChangeEvent: 'fieldChange:operacoes.pop_ar',
						id: 'OPERACOES__OPERACOES__POP_AR',
						name: 'POP_AR',
						size: 'medium',
						label: computed(() => this.Resources.POP_ABRANGIDA36477),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 6,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					OPERACOES__OPERACOES__SOBREPOSICAO_AR: new fieldControlClass.BooleanControl({
						modelField: 'ValSobreposicao_ar',
						valueChangeEvent: 'fieldChange:operacoes.sobreposicao_ar',
						id: 'OPERACOES__OPERACOES__SOBREPOSICAO_AR',
						name: 'SOBREPOSICAO_AR',
						size: 'medium',
						label: computed(() => this.Resources.SOBREPOSICAO_AR58360),
						placeholder: '',
						labelPosition: computed(() => this.$app.layout.CheckboxLabelAlignment),
						controlLimits: [
						],
					}, this),
					OPERACOES__OPERACOES__OPERACAO_RU: new fieldControlClass.StringControl({
						modelField: 'ValOperacao_ru',
						valueChangeEvent: 'fieldChange:operacoes.operacao_ru',
						id: 'OPERACOES__OPERACOES__OPERACAO_RU',
						name: 'OPERACAO_RU',
						size: 'xxlarge',
						label: computed(() => this.Resources.OPERACAO_RU18117),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					OPERACOES__OPERACOES__POP_RU: new fieldControlClass.NumberControl({
						modelField: 'ValPop_ru',
						valueChangeEvent: 'fieldChange:operacoes.pop_ru',
						id: 'OPERACOES__OPERACOES__POP_RU',
						name: 'POP_RU',
						size: 'medium',
						label: computed(() => this.Resources.POP_ABRANGIDA36477),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 6,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					OPERACOES__OPERACOES__SOBREPOSICAO_RU: new fieldControlClass.BooleanControl({
						modelField: 'ValSobreposicao_ru',
						valueChangeEvent: 'fieldChange:operacoes.sobreposicao_ru',
						id: 'OPERACOES__OPERACOES__SOBREPOSICAO_RU',
						name: 'SOBREPOSICAO_RU',
						size: 'medium',
						label: computed(() => this.Resources.SOBREPOSICAO_RU06294),
						placeholder: '',
						labelPosition: computed(() => this.$app.layout.CheckboxLabelAlignment),
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
					Entidade: {
						get ValEntidade() { return vm.model.TableEntidadeEntidade.value },
						set ValEntidade(value) { vm.model.TableEntidadeEntidade.updateValue(value) },
					},
					Operacoes: {
						get ValCodentidade() { return vm.model.ValCodentidade.value },
						set ValCodentidade(value) { vm.model.ValCodentidade.updateValue(value) },
						get ValOperacao_aa() { return vm.model.ValOperacao_aa.value },
						set ValOperacao_aa(value) { vm.model.ValOperacao_aa.updateValue(value) },
						get ValOperacao_ar() { return vm.model.ValOperacao_ar.value },
						set ValOperacao_ar(value) { vm.model.ValOperacao_ar.updateValue(value) },
						get ValOperacao_ru() { return vm.model.ValOperacao_ru.value },
						set ValOperacao_ru(value) { vm.model.ValOperacao_ru.updateValue(value) },
						get ValPop_aa() { return vm.model.ValPop_aa.value },
						set ValPop_aa(value) { vm.model.ValPop_aa.updateValue(value) },
						get ValPop_ar() { return vm.model.ValPop_ar.value },
						set ValPop_ar(value) { vm.model.ValPop_ar.updateValue(value) },
						get ValPop_ru() { return vm.model.ValPop_ru.value },
						set ValPop_ru(value) { vm.model.ValPop_ru.updateValue(value) },
						get ValSobreposicao_aa() { return vm.model.ValSobreposicao_aa.value },
						set ValSobreposicao_aa(value) { vm.model.ValSobreposicao_aa.updateValue(value) },
						get ValSobreposicao_ar() { return vm.model.ValSobreposicao_ar.value },
						set ValSobreposicao_ar(value) { vm.model.ValSobreposicao_ar.updateValue(value) },
						get ValSobreposicao_ru() { return vm.model.ValSobreposicao_ru.value },
						set ValSobreposicao_ru(value) { vm.model.ValSobreposicao_ru.updateValue(value) },
					},
					keys: {
						/** The primary key of the OPERACOES table */
						get operacoes() { return vm.model.ValCodoperacoes },
						/** The foreign key to the ENTIDADE table */
						get entidade() { return vm.model.ValCodentidade },
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
// USE /[MANUAL GQT FORM_CODEJS OPERACOES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT OPERACOES]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS OPERACOES]/
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
// USE /[MANUAL GQT FORM_LOADED_JS OPERACOES]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS OPERACOES]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS OPERACOES]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS OPERACOES]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS OPERACOES]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS OPERACOES]/
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
// USE /[MANUAL GQT AFTER_DEL_JS OPERACOES]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS OPERACOES]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS OPERACOES]/
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
// USE /[MANUAL GQT DLGUPDT OPERACOES]/
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
// USE /[MANUAL GQT CTRLBLR OPERACOES]/
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
// USE /[MANUAL GQT CTRLUPD OPERACOES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS OPERACOES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
