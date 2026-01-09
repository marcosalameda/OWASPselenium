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
			data-key="ENTIDADE"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.ENTIDADE__CONCELHO__NOME.isVisible">
					<q-col
						v-if="controls.ENTIDADE__CONCELHO__NOME.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ENTIDADE__CONCELHO__NOME.isVisible"
							class="i-text"
							v-bind="controls.ENTIDADE__CONCELHO__NOME"
							v-on="controls.ENTIDADE__CONCELHO__NOME.handlers"
							:loading="controls.ENTIDADE__CONCELHO__NOME.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.ENTIDADE__CONCELHO__NOME.isVisible"
								v-bind="controls.ENTIDADE__CONCELHO__NOME.props"
								v-on="controls.ENTIDADE__CONCELHO__NOME.handlers" />
							<q-see-more-entidade-concelho-nome
								v-if="controls.ENTIDADE__CONCELHO__NOME.seeMoreIsVisible"
								v-bind="controls.ENTIDADE__CONCELHO__NOME.seeMoreParams"
								v-on="controls.ENTIDADE__CONCELHO__NOME.handlers" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.ENTIDADE__ENTIDADE__ID_ENTIDADE.isVisible || controls.ENTIDADE__ENTIDADE__ENTIDADE.isVisible">
					<q-col
						v-if="controls.ENTIDADE__ENTIDADE__ID_ENTIDADE.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ENTIDADE__ENTIDADE__ID_ENTIDADE.isVisible"
							class="i-text"
							v-bind="controls.ENTIDADE__ENTIDADE__ID_ENTIDADE"
							v-on="controls.ENTIDADE__ENTIDADE__ID_ENTIDADE.handlers"
							:loading="controls.ENTIDADE__ENTIDADE__ID_ENTIDADE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.ENTIDADE__ENTIDADE__ID_ENTIDADE.isVisible"
								v-bind="controls.ENTIDADE__ENTIDADE__ID_ENTIDADE.props"
								@update:model-value="model.ValId_entidade.fnUpdateValue" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.ENTIDADE__ENTIDADE__ENTIDADE.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ENTIDADE__ENTIDADE__ENTIDADE.isVisible"
							class="i-text"
							v-bind="controls.ENTIDADE__ENTIDADE__ENTIDADE"
							v-on="controls.ENTIDADE__ENTIDADE__ENTIDADE.handlers"
							:loading="controls.ENTIDADE__ENTIDADE__ENTIDADE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.ENTIDADE__ENTIDADE__ENTIDADE.props"
								@blur="onBlur(controls.ENTIDADE__ENTIDADE__ENTIDADE, model.ValEntidade.value)"
								@change="model.ValEntidade.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.ENTIDADE__ENTIDADE__SUB_MODELO_GESTAO.isVisible || controls.ENTIDADE__ENTIDADE__SISTEMA_CONTABILISTICO.isVisible">
					<q-col
						v-if="controls.ENTIDADE__ENTIDADE__SUB_MODELO_GESTAO.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ENTIDADE__ENTIDADE__SUB_MODELO_GESTAO.isVisible"
							class="i-text"
							v-bind="controls.ENTIDADE__ENTIDADE__SUB_MODELO_GESTAO"
							v-on="controls.ENTIDADE__ENTIDADE__SUB_MODELO_GESTAO.handlers"
							:loading="controls.ENTIDADE__ENTIDADE__SUB_MODELO_GESTAO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.ENTIDADE__ENTIDADE__SUB_MODELO_GESTAO.props"
								@blur="onBlur(controls.ENTIDADE__ENTIDADE__SUB_MODELO_GESTAO, model.ValSub_modelo_gestao.value)"
								@change="model.ValSub_modelo_gestao.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.ENTIDADE__ENTIDADE__SISTEMA_CONTABILISTICO.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ENTIDADE__ENTIDADE__SISTEMA_CONTABILISTICO.isVisible"
							class="i-text"
							v-bind="controls.ENTIDADE__ENTIDADE__SISTEMA_CONTABILISTICO"
							v-on="controls.ENTIDADE__ENTIDADE__SISTEMA_CONTABILISTICO.handlers"
							:loading="controls.ENTIDADE__ENTIDADE__SISTEMA_CONTABILISTICO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-select
								v-if="controls.ENTIDADE__ENTIDADE__SISTEMA_CONTABILISTICO.isVisible"
								v-bind="controls.ENTIDADE__ENTIDADE__SISTEMA_CONTABILISTICO.props"
								@update:model-value="model.ValSistema_contabilistico.fnUpdateValue" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.ENTIDADE__PSEUD__OPERACOES.isVisible">
					<q-col
						v-if="controls.ENTIDADE__PSEUD__OPERACOES.isVisible"
						cols="auto">
						<q-table
							v-if="controls.ENTIDADE__PSEUD__OPERACOES.isVisible"
							v-bind="controls.ENTIDADE__PSEUD__OPERACOES"
							v-on="controls.ENTIDADE__PSEUD__OPERACOES.handlers">
						<q-table-extra-extension
							v-if="controls.ENTIDADE__PSEUD__OPERACOES.isVisible"
							:list-ctrl="controls.ENTIDADE__PSEUD__OPERACOES"
							:filter-operators="controls.ENTIDADE__PSEUD__OPERACOES.filterOperators"
							v-on="controls.ENTIDADE__PSEUD__OPERACOES.handlers" />
							<!-- USE /[MANUAL GQT CUSTOM_TABLE ENTIDADE__PSEUD__OPERACOES]/ -->
						</q-table>
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

	import FormViewModel from './QFormEntidadeViewModel.js'

	const requiredTextResources = ['QFormEntidade', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS ENTIDADE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormEntidade',

		components: {
			QSeeMoreEntidadeConcelhoNome: defineAsyncComponent(() => import('@/views/forms/FormEntidade/dbedits/EntidadeConcelhoNomeSeeMore.vue')),
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
					name: 'ENTIDADE',
					location: 'form-ENTIDADE',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormEntidade', false),

				interfaceMetadata: {
					id: 'QFormEntidade', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'ENTIDADE',
					route: 'form-ENTIDADE',
					area: 'ENTIDADE',
					primaryKey: 'ValCodentidade',
					designation: computed(() => this.Resources.ENTIDADE36471),
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
					ENTIDADE__CONCELHO__NOME: new fieldControlClass.LookupControl({
						modelField: 'TableConcelhoNome',
						valueChangeEvent: 'fieldChange:concelho.nome',
						id: 'ENTIDADE__CONCELHO__NOME',
						name: 'NOME',
						size: 'xxlarge',
						label: computed(() => this.Resources.NOME47814),
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
							name: 'ValCodconcelho',
							dependencyEvent: 'fieldChange:entidade.codconcelho'
						},
						dependentFields: () => ({
							set 'concelho.codconcelho'(value) { vm.model.ValCodconcelho.updateValue(value) },
							set 'concelho.nome'(value) { vm.model.TableConcelhoNome.updateValue(value) },
						}),
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					ENTIDADE__ENTIDADE__ID_ENTIDADE: new fieldControlClass.NumberControl({
						modelField: 'ValId_entidade',
						valueChangeEvent: 'fieldChange:entidade.id_entidade',
						id: 'ENTIDADE__ENTIDADE__ID_ENTIDADE',
						name: 'ID_ENTIDADE',
						size: 'small',
						label: computed(() => this.Resources.ID_ENTIDADE52030),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 4,
						maxDecimals: 0,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					ENTIDADE__ENTIDADE__ENTIDADE: new fieldControlClass.StringControl({
						modelField: 'ValEntidade',
						valueChangeEvent: 'fieldChange:entidade.entidade',
						id: 'ENTIDADE__ENTIDADE__ENTIDADE',
						name: 'ENTIDADE',
						size: 'xxlarge',
						label: computed(() => this.Resources.ENTIDADE36471),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 250,
						controlLimits: [
						],
					}, this),
					ENTIDADE__ENTIDADE__SUB_MODELO_GESTAO: new fieldControlClass.StringControl({
						modelField: 'ValSub_modelo_gestao',
						valueChangeEvent: 'fieldChange:entidade.sub_modelo_gestao',
						id: 'ENTIDADE__ENTIDADE__SUB_MODELO_GESTAO',
						name: 'SUB_MODELO_GESTAO',
						size: 'xxlarge',
						label: computed(() => this.Resources.SUBMODELO_DE_GESTAO34607),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 100,
						controlLimits: [
						],
					}, this),
					ENTIDADE__ENTIDADE__SISTEMA_CONTABILISTICO: new fieldControlClass.ArrayStringControl({
						modelField: 'ValSistema_contabilistico',
						valueChangeEvent: 'fieldChange:entidade.sistema_contabilistico',
						id: 'ENTIDADE__ENTIDADE__SISTEMA_CONTABILISTICO',
						name: 'SISTEMA_CONTABILISTICO',
						size: 'small',
						label: computed(() => this.Resources.SISTEMA_CONTABILISTI21743),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 5,
						arrayName: 'Sistema_Contabilistico',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					ENTIDADE__PSEUD__OPERACOES: new fieldControlClass.TableListControl({
						id: 'ENTIDADE__PSEUD__OPERACOES',
						name: 'OPERACOES',
						size: '',
						label: computed(() => this.Resources.OPERACAO29482),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'ENTIDADE',
						action: 'Entidade_ValOperacoes',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValOperacao_aa',
								area: 'OPERACOES',
								field: 'OPERACAO_AA',
								label: computed(() => this.Resources.OPERACAO_AA07938),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 2,
								name: 'ValPop_aa',
								area: 'OPERACOES',
								field: 'POP_AA',
								label: computed(() => this.Resources.POP_ABRANGIDA36477),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 3,
								name: 'ValSobreposicao_aa',
								area: 'OPERACOES',
								field: 'SOBREPOSICAO_AA',
								label: computed(() => this.Resources.SOBREPOSICAO_AA55921),
								scrollData: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValOperacao_ar',
								area: 'OPERACOES',
								field: 'OPERACAO_AR',
								label: computed(() => this.Resources.OPERACAO_AR11207),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 5,
								name: 'ValPop_ar',
								area: 'OPERACOES',
								field: 'POP_AR',
								label: computed(() => this.Resources.POP_ABRANGIDA36477),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 6,
								name: 'ValSobreposicao_ar',
								area: 'OPERACOES',
								field: 'SOBREPOSICAO_AR',
								label: computed(() => this.Resources.SOBREPOSICAO_AR58360),
								scrollData: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'ValOperacao_ru',
								area: 'OPERACOES',
								field: 'OPERACAO_RU',
								label: computed(() => this.Resources.OPERACAO_RU18117),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 8,
								name: 'ValPop_ru',
								area: 'OPERACOES',
								field: 'POP_RU',
								label: computed(() => this.Resources.POP_ABRANGIDA36477),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 9,
								name: 'ValSobreposicao_ru',
								area: 'OPERACOES',
								field: 'SOBREPOSICAO_RU',
								label: computed(() => this.Resources.SOBREPOSICAO_RU06294),
								scrollData: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValOperacoes',
							serverMode: true,
							pkColumn: 'ValCodoperacoes',
							tableAlias: 'OPERACOES',
							tableNamePlural: computed(() => this.Resources.OPERACAO29482),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.OPERACAO29482),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: false
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
										formName: 'OPERACOES',
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
										formName: 'OPERACOES',
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
										formName: 'OPERACOES',
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
										formName: 'OPERACOES',
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
										formName: 'OPERACOES',
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
								id: 'RCA__OPERACOES',
								name: '_OPERACOES',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'OPERACOES',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'OPERACOES': {
									fnKeySelector: (row) => row.Fields.ValCodoperacoes,
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
						globalEvents: ['changed-OPERACOES', 'changed-ENTIDADE'],
						uuid: 'Entidade_ValOperacoes',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'entidade'],
								dependencyEvents: ['fieldChange:entidade.codentidade'],
								dependencyField: 'ENTIDADE.CODENTIDADE',
								fnValueSelector: (model) => model.ValCodentidade.value
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
					'ENTIDADE__PSEUD__OPERACOES',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Concelho: {
						get ValNome() { return vm.model.TableConcelhoNome.value },
						set ValNome(value) { vm.model.TableConcelhoNome.updateValue(value) },
					},
					Entidade: {
						get ValCodconcelho() { return vm.model.ValCodconcelho.value },
						set ValCodconcelho(value) { vm.model.ValCodconcelho.updateValue(value) },
						get ValEntidade() { return vm.model.ValEntidade.value },
						set ValEntidade(value) { vm.model.ValEntidade.updateValue(value) },
						get ValId_entidade() { return vm.model.ValId_entidade.value },
						set ValId_entidade(value) { vm.model.ValId_entidade.updateValue(value) },
						get ValSistema_contabilistico() { return vm.model.ValSistema_contabilistico.value },
						set ValSistema_contabilistico(value) { vm.model.ValSistema_contabilistico.updateValue(value) },
						get ValSub_modelo_gestao() { return vm.model.ValSub_modelo_gestao.value },
						set ValSub_modelo_gestao(value) { vm.model.ValSub_modelo_gestao.updateValue(value) },
					},
					keys: {
						/** The primary key of the ENTIDADE table */
						get entidade() { return vm.model.ValCodentidade },
						/** The foreign key to the CONCELHO table */
						get concelho() { return vm.model.ValCodconcelho },
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
// USE /[MANUAL GQT FORM_CODEJS ENTIDADE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT ENTIDADE]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS ENTIDADE]/
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
// USE /[MANUAL GQT FORM_LOADED_JS ENTIDADE]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS ENTIDADE]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS ENTIDADE]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS ENTIDADE]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS ENTIDADE]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS ENTIDADE]/
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
// USE /[MANUAL GQT AFTER_DEL_JS ENTIDADE]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS ENTIDADE]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS ENTIDADE]/
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
// USE /[MANUAL GQT DLGUPDT ENTIDADE]/
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
// USE /[MANUAL GQT CTRLBLR ENTIDADE]/
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
// USE /[MANUAL GQT CTRLUPD ENTIDADE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS ENTIDADE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
