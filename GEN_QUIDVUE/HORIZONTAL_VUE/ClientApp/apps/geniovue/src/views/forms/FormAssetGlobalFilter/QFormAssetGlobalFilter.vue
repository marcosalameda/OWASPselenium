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
			data-key="ASSET_GLOBAL_FILTER"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.ASSET_GLOBAL_FILTER__KINDE__DESIGNAT.isVisible || controls.ASSET_GLOBAL_FILTER__ASSET__ASSETNUM.isVisible || controls.ASSET_GLOBAL_FILTER__ASSET__ASSETTYP.isVisible">
					<q-col
						v-if="controls.ASSET_GLOBAL_FILTER__KINDE__DESIGNAT.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ASSET_GLOBAL_FILTER__KINDE__DESIGNAT.isVisible"
							class="i-text"
							v-bind="controls.ASSET_GLOBAL_FILTER__KINDE__DESIGNAT"
							v-on="controls.ASSET_GLOBAL_FILTER__KINDE__DESIGNAT.handlers"
							:loading="controls.ASSET_GLOBAL_FILTER__KINDE__DESIGNAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.ASSET_GLOBAL_FILTER__KINDE__DESIGNAT.isVisible"
								v-bind="controls.ASSET_GLOBAL_FILTER__KINDE__DESIGNAT.props"
								v-on="controls.ASSET_GLOBAL_FILTER__KINDE__DESIGNAT.handlers" />
							<q-see-more-asset-global-filter-kinde-designat
								v-if="controls.ASSET_GLOBAL_FILTER__KINDE__DESIGNAT.seeMoreIsVisible"
								v-bind="controls.ASSET_GLOBAL_FILTER__KINDE__DESIGNAT.seeMoreParams"
								v-on="controls.ASSET_GLOBAL_FILTER__KINDE__DESIGNAT.handlers" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.ASSET_GLOBAL_FILTER__ASSET__ASSETNUM.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ASSET_GLOBAL_FILTER__ASSET__ASSETNUM.isVisible"
							class="i-text"
							v-bind="controls.ASSET_GLOBAL_FILTER__ASSET__ASSETNUM"
							v-on="controls.ASSET_GLOBAL_FILTER__ASSET__ASSETNUM.handlers"
							:loading="controls.ASSET_GLOBAL_FILTER__ASSET__ASSETNUM.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.ASSET_GLOBAL_FILTER__ASSET__ASSETNUM.isVisible"
								v-bind="controls.ASSET_GLOBAL_FILTER__ASSET__ASSETNUM.props"
								@update:model-value="model.ValAssetnum.fnUpdateValue" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.ASSET_GLOBAL_FILTER__ASSET__ASSETTYP.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ASSET_GLOBAL_FILTER__ASSET__ASSETTYP.isVisible"
							class="i-text"
							v-bind="controls.ASSET_GLOBAL_FILTER__ASSET__ASSETTYP"
							v-on="controls.ASSET_GLOBAL_FILTER__ASSET__ASSETTYP.handlers"
							:loading="controls.ASSET_GLOBAL_FILTER__ASSET__ASSETTYP.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-select
								v-if="controls.ASSET_GLOBAL_FILTER__ASSET__ASSETTYP.isVisible"
								v-bind="controls.ASSET_GLOBAL_FILTER__ASSET__ASSETTYP.props"
								@update:model-value="model.ValAssettyp.fnUpdateValue" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.ASSET_GLOBAL_FILTER__PARAM__PARAMETE_FG.isVisible">
					<q-col
						v-if="controls.ASSET_GLOBAL_FILTER__PARAM__PARAMETE_FG.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ASSET_GLOBAL_FILTER__PARAM__PARAMETE_FG.isVisible"
							class="i-text"
							v-bind="controls.ASSET_GLOBAL_FILTER__PARAM__PARAMETE_FG"
							v-on="controls.ASSET_GLOBAL_FILTER__PARAM__PARAMETE_FG.handlers"
							:loading="controls.ASSET_GLOBAL_FILTER__PARAM__PARAMETE_FG.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.ASSET_GLOBAL_FILTER__PARAM__PARAMETE_FG.isVisible"
								v-bind="controls.ASSET_GLOBAL_FILTER__PARAM__PARAMETE_FG.props"
								v-on="controls.ASSET_GLOBAL_FILTER__PARAM__PARAMETE_FG.handlers" />
							<q-see-more-asset-global-filter-param-paramete-fg
								v-if="controls.ASSET_GLOBAL_FILTER__PARAM__PARAMETE_FG.seeMoreIsVisible"
								v-bind="controls.ASSET_GLOBAL_FILTER__PARAM__PARAMETE_FG.seeMoreParams"
								v-on="controls.ASSET_GLOBAL_FILTER__PARAM__PARAMETE_FG.handlers" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.ASSET_GLOBAL_FILTER__PSEUD__ASSPA_FILTRED_BY_PARAM.isVisible">
					<q-col v-if="controls.ASSET_GLOBAL_FILTER__PSEUD__ASSPA_FILTRED_BY_PARAM.isVisible">
						<q-table
							v-if="controls.ASSET_GLOBAL_FILTER__PSEUD__ASSPA_FILTRED_BY_PARAM.isVisible"
							v-bind="controls.ASSET_GLOBAL_FILTER__PSEUD__ASSPA_FILTRED_BY_PARAM"
							v-on="controls.ASSET_GLOBAL_FILTER__PSEUD__ASSPA_FILTRED_BY_PARAM.handlers">
							<!-- USE /[MANUAL GQT CUSTOM_TABLE ASSET_GLOBAL_FILTER__PSEUD__ASSPA_FILTRED_BY_PARAM]/ -->
						</q-table>
						<q-table-extra-extension
							v-if="controls.ASSET_GLOBAL_FILTER__PSEUD__ASSPA_FILTRED_BY_PARAM.isVisible"
							:list-ctrl="controls.ASSET_GLOBAL_FILTER__PSEUD__ASSPA_FILTRED_BY_PARAM"
							:filter-operators="controls.ASSET_GLOBAL_FILTER__PSEUD__ASSPA_FILTRED_BY_PARAM.filterOperators"
							v-on="controls.ASSET_GLOBAL_FILTER__PSEUD__ASSPA_FILTRED_BY_PARAM.handlers" />
					</q-col>
				</q-row>
				<q-row v-if="controls.ASSET_GLOBAL_FILTER__PSEUD__RELATION.isVisible">
					<q-col v-if="controls.ASSET_GLOBAL_FILTER__PSEUD__RELATION.isVisible">
						<base-input-structure
							v-if="controls.ASSET_GLOBAL_FILTER__PSEUD__RELATION.isVisible"
							class="q-image"
							v-bind="controls.ASSET_GLOBAL_FILTER__PSEUD__RELATION"
							v-on="controls.ASSET_GLOBAL_FILTER__PSEUD__RELATION.handlers"
							:loading="controls.ASSET_GLOBAL_FILTER__PSEUD__RELATION.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-image
								v-if="controls.ASSET_GLOBAL_FILTER__PSEUD__RELATION.isVisible"
								v-bind="controls.ASSET_GLOBAL_FILTER__PSEUD__RELATION.props"
								v-on="controls.ASSET_GLOBAL_FILTER__PSEUD__RELATION.handlers" />
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

	import FormViewModel from './QFormAssetGlobalFilterViewModel.js'

	const requiredTextResources = ['QFormAssetGlobalFilter', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS ASSET_GLOBAL_FILTER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormAssetGlobalFilter',

		components: {
			QSeeMoreAssetGlobalFilterKindeDesignat: defineAsyncComponent(() => import('@/views/forms/FormAssetGlobalFilter/dbedits/AssetGlobalFilterKindeDesignatSeeMore.vue')),
			QSeeMoreAssetGlobalFilterParamParameteFg: defineAsyncComponent(() => import('@/views/forms/FormAssetGlobalFilter/dbedits/AssetGlobalFilterParamParameteFgSeeMore.vue')),
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
					name: 'ASSET_GLOBAL_FILTER',
					location: 'form-ASSET_GLOBAL_FILTER',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormAssetGlobalFilter', false),

				interfaceMetadata: {
					id: 'QFormAssetGlobalFilter', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'ASSET_GLOBAL_FILTER',
					route: 'form-ASSET_GLOBAL_FILTER',
					area: 'ASSET',
					primaryKey: 'ValCodasset',
					designation: computed(() => this.Resources.ASSET37028),
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
					ASSET_GLOBAL_FILTER__KINDE__DESIGNAT: new fieldControlClass.LookupControl({
						modelField: 'TableKindeDesignat',
						valueChangeEvent: 'fieldChange:kinde.designat',
						id: 'ASSET_GLOBAL_FILTER__KINDE__DESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.KIND_OF_EQUIPMENT22928),
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
							name: 'ValCodkinde',
							dependencyEvent: 'fieldChange:asset.codkinde'
						},
						dependentFields: () => ({
							set 'kinde.codkinde'(value) { vm.model.ValCodkinde.updateValue(value) },
							set 'kinde.designat'(value) { vm.model.TableKindeDesignat.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					ASSET_GLOBAL_FILTER__ASSET__ASSETNUM: new fieldControlClass.NumberControl({
						modelField: 'ValAssetnum',
						valueChangeEvent: 'fieldChange:asset.assetnum',
						id: 'ASSET_GLOBAL_FILTER__ASSET__ASSETNUM',
						name: 'ASSETNUM',
						size: 'medium',
						label: computed(() => this.Resources.ASSET_NUMBER52372),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 10,
						maxDecimals: 0,
						isSequencial: true,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					ASSET_GLOBAL_FILTER__ASSET__ASSETTYP: new fieldControlClass.ArrayStringControl({
						modelField: 'ValAssettyp',
						valueChangeEvent: 'fieldChange:asset.assettyp',
						id: 'ASSET_GLOBAL_FILTER__ASSET__ASSETTYP',
						name: 'ASSETTYP',
						size: 'mini',
						label: computed(() => this.Resources.ASSET_TYPE02033),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 1,
						mustBeFilled: true,
						arrayName: 'AssetTyp',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					ASSET_GLOBAL_FILTER__PARAM__PARAMETE_FG: new fieldControlClass.LookupControl({
						modelField: 'TableParamParamete',
						id: 'ASSET_GLOBAL_FILTER__PARAM__PARAMETE_FG',
						name: 'PARAMETE',
						size: 'xlarge',
						label: computed(() => this.Resources.PARAMETER41976),
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
							name: 'ParamValCodparamFilterKey',
							dependencyEvent: 'filterChange:param.codparam'
						},
						dependentFields: () => ({
							set 'param.codparam'(value) { vm.model?.ParamValCodparamFilterKey?.updateValue(value) },
							set 'param.parameter'(value) { vm.model?.TableParamParamete?.updateValue(value) }
						}),
						controlLimits: [
						],
					}, this),
					ASSET_GLOBAL_FILTER__PSEUD__ASSPA_FILTRED_BY_PARAM: new fieldControlClass.TableListControl({
						id: 'ASSET_GLOBAL_FILTER__PSEUD__ASSPA_FILTRED_BY_PARAM',
						name: 'ASSPA_FILTRED_BY_PARAM',
						size: 'block',
						helpControl: {
							shortHelp: {
								type: 'Subtitle',
								text: computed(() => this.Resources._114828953),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1148_VERBOSE59791),
							}
						},
						label: computed(() => this.Resources.ASSET_PARAMETERS20615),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'ASSET',
						action: 'Asset_global_filter_ValAsspa_filtred_by_param',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValToshow',
								area: 'ASSPA',
								field: 'TOSHOW',
								label: computed(() => this.Resources.TO_SHOW13268),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'Asset.ValName',
								area: 'ASSET',
								field: 'NAME',
								label: computed(() => this.Resources.IDENTIFICATION_NAME16317),
								dataLength: 85,
								scrollData: 30,
								export: 1,
								pkColumn: 'ValCodasset',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'Param.ValParameter',
								area: 'PARAM',
								field: 'PARAMETER',
								label: computed(() => this.Resources.PARAMETER41976),
								dataLength: 50,
								scrollData: 30,
								export: 1,
								pkColumn: 'ValCodparam',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 4,
								name: 'ValDatatype',
								area: 'ASSPA',
								field: 'DATATYPE',
								label: computed(() => this.Resources.DATA_TYPE47159),
								dataLength: 1,
								scrollData: 1,
								export: 1,
								array: computed(() => new qProjArrays.QArrayDatatype(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayDatatype.type,
								arrayDisplayMode: 'D',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValText',
								area: 'ASSPA',
								field: 'TEXT',
								label: computed(() => this.Resources.TEXT04938),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 6,
								name: 'ValQuantity',
								area: 'ASSPA',
								field: 'QUANTITY',
								label: computed(() => this.Resources.QUANTITY06415),
								scrollData: 12,
								maxDigits: 7,
								decimalPlaces: 4,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 7,
								name: 'ValDate',
								area: 'ASSPA',
								field: 'DATE',
								label: computed(() => this.Resources.DATE18475),
								scrollData: 8,
								dateTimeType: 'date',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 8,
								name: 'ValDecimalplaces',
								area: 'ASSPA',
								field: 'DECIMALPLACES',
								label: computed(() => this.Resources.DECIMAL_PLACES62575),
								scrollData: 1,
								maxDigits: 1,
								decimalPlaces: 0,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValAsspa_filtred_by_param',
							serverMode: true,
							pkColumn: 'ValCodasspa',
							tableAlias: 'ASSPA',
							tableNamePlural: computed(() => this.Resources.ASSET_PARAMETERS20615),
							viewManagement: 'M',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.ASSET_PARAMETERS20615),
							showRecordCount: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: true
							},
							filtersVisible: true,
							allowColumnFilters: true,
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
										formName: 'ASSPA',
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
										formName: 'ASSPA',
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
										formName: 'ASSPA',
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
										formName: 'ASSPA',
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
										formName: 'ASSPA',
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
								id: 'RCA__ASSPA',
								name: '_ASSPA',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'ASSPA',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'ASSPA': {
									fnKeySelector: (row) => row.Fields.ValCodasspa,
									isPopup: false
								},
							},
							allowFileExport: true,
							defaultSearchColumnName: 'ValText',
							defaultSearchColumnNameOriginal: 'ValText',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						groupFilters: [
							{
								id: 'filter_ValAsspa_filtred_by_param_PARAM_TYPE',
								isMultiple: true,
								items: [
									{
										id: 'filter_ValAsspa_filtred_by_param_PARAM_TYPE_1',
										value: computed(() => this.Resources.ALL38603),
										key: '1'
									},
									{
										id: 'filter_ValAsspa_filtred_by_param_PARAM_TYPE_2',
										value: computed(() => this.Resources.TEXT04938),
										key: '2'
									},
									{
										id: 'filter_ValAsspa_filtred_by_param_PARAM_TYPE_3',
										value: computed(() => this.Resources.NUMERIC19292),
										key: '3'
									},
									{
										id: 'filter_ValAsspa_filtred_by_param_PARAM_TYPE_4',
										value: computed(() => this.Resources.DATE18475),
										key: '4'
									},
								],
								selected: ['1'],
								default: ['1']
							},
						],
						globalEvents: ['changed-PARAM', 'changed-ASSPA', 'changed-ASSET'],
						internalEvents: ['filterChange:param.codparam'],
						globalFilters: [
							{
								identifier: 'param.codparam',
								getValue: () => this.model?.ParamValCodparamFilterKey?.value
							},
						],
						uuid: 'Asset_global_filter_ValAsspa_filtred_by_param',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'asset'],
								dependencyEvents: ['fieldChange:asset.codasset'],
								dependencyField: 'ASSET.CODASSET',
								fnValueSelector: (model) => model.ValCodasset.value
							},
						],
					}, this),
					ASSET_GLOBAL_FILTER__PSEUD__RELATION: new fieldControlClass.ImageControl({
						id: 'ASSET_GLOBAL_FILTER__PSEUD__RELATION',
						name: 'RELATION',
						size: 'block',
						hasLabel: false,
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						icon: {
							icon: computed(() => `${this.$app.resourcesPath}GQT_Asset_FSM.png?v=3095`),
							type: 'img',
						},
						height: 226,
						width: 485,
						isStatic: true,
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
					'ASSET_GLOBAL_FILTER__PSEUD__ASSPA_FILTRED_BY_PARAM',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Asset: {
						get ValAssetnum() { return vm.model.ValAssetnum.value },
						set ValAssetnum(value) { vm.model.ValAssetnum.updateValue(value) },
						get ValAssettyp() { return vm.model.ValAssettyp.value },
						set ValAssettyp(value) { vm.model.ValAssettyp.updateValue(value) },
						get ValCodkinde() { return vm.model.ValCodkinde.value },
						set ValCodkinde(value) { vm.model.ValCodkinde.updateValue(value) },
						get ValCodmanuf() { return vm.model.ValCodmanuf.value },
						set ValCodmanuf(value) { vm.model.ValCodmanuf.updateValue(value) },
						get ValName() { return vm.model.ValName.value },
						set ValName(value) { vm.model.ValName.updateValue(value) },
					},
					Kinde: {
						get ValDesignat() { return vm.model.TableKindeDesignat.value },
						set ValDesignat(value) { vm.model.TableKindeDesignat.updateValue(value) },
					},
					Param: {
						get ValParameter() { return vm.model.TableParamParamete.value },
						set ValParameter(value) { vm.model.TableParamParamete.updateValue(value) },
					},
					keys: {
						/** The primary key of the ASSET table */
						get asset() { return vm.model.ValCodasset },
						/** The foreign key to the KINDE table */
						get kinde() { return vm.model.ValCodkinde },
						/** The foreign key to the MANUF table */
						get manuf() { return vm.model.ValCodmanuf },
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
// USE /[MANUAL GQT FORM_CODEJS ASSET_GLOBAL_FILTER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT ASSET_GLOBAL_FILTER]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS ASSET_GLOBAL_FILTER]/
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
// USE /[MANUAL GQT FORM_LOADED_JS ASSET_GLOBAL_FILTER]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS ASSET_GLOBAL_FILTER]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS ASSET_GLOBAL_FILTER]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS ASSET_GLOBAL_FILTER]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS ASSET_GLOBAL_FILTER]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS ASSET_GLOBAL_FILTER]/
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
// USE /[MANUAL GQT AFTER_DEL_JS ASSET_GLOBAL_FILTER]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS ASSET_GLOBAL_FILTER]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS ASSET_GLOBAL_FILTER]/
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
// USE /[MANUAL GQT DLGUPDT ASSET_GLOBAL_FILTER]/
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
// USE /[MANUAL GQT CTRLBLR ASSET_GLOBAL_FILTER]/
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
// USE /[MANUAL GQT CTRLUPD ASSET_GLOBAL_FILTER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS ASSET_GLOBAL_FILTER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
