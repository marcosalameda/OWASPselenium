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
			data-key="EQUIP_EMPTY"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.EQUIP_EMPTY__CNTRY__COUNTRY_FG.isVisible || controls.EQUIP_EMPTY__CMPNY__DESIGNAT_FG.isVisible || controls.EQUIP_EMPTY__PESS1__NAME_FG.isVisible">
					<q-col
						v-if="controls.EQUIP_EMPTY__CNTRY__COUNTRY_FG.isVisible || controls.EQUIP_EMPTY__CMPNY__DESIGNAT_FG.isVisible || controls.EQUIP_EMPTY__PESS1__NAME_FG.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.EQUIP_EMPTY__CNTRY__COUNTRY_FG.isVisible"
							class="i-text"
							v-bind="controls.EQUIP_EMPTY__CNTRY__COUNTRY_FG"
							v-on="controls.EQUIP_EMPTY__CNTRY__COUNTRY_FG.handlers"
							:loading="controls.EQUIP_EMPTY__CNTRY__COUNTRY_FG.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.EQUIP_EMPTY__CNTRY__COUNTRY_FG.isVisible"
								v-bind="controls.EQUIP_EMPTY__CNTRY__COUNTRY_FG.props"
								v-on="controls.EQUIP_EMPTY__CNTRY__COUNTRY_FG.handlers" />
							<q-see-more-equip-empty-cntry-country-fg
								v-if="controls.EQUIP_EMPTY__CNTRY__COUNTRY_FG.seeMoreIsVisible"
								v-bind="controls.EQUIP_EMPTY__CNTRY__COUNTRY_FG.seeMoreParams"
								v-on="controls.EQUIP_EMPTY__CNTRY__COUNTRY_FG.handlers" />
						</base-input-structure>
						<base-input-structure
							v-if="controls.EQUIP_EMPTY__CMPNY__DESIGNAT_FG.isVisible"
							class="i-text"
							v-bind="controls.EQUIP_EMPTY__CMPNY__DESIGNAT_FG"
							v-on="controls.EQUIP_EMPTY__CMPNY__DESIGNAT_FG.handlers"
							:loading="controls.EQUIP_EMPTY__CMPNY__DESIGNAT_FG.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.EQUIP_EMPTY__CMPNY__DESIGNAT_FG.isVisible"
								v-bind="controls.EQUIP_EMPTY__CMPNY__DESIGNAT_FG.props"
								v-on="controls.EQUIP_EMPTY__CMPNY__DESIGNAT_FG.handlers" />
							<q-see-more-equip-empty-cmpny-designat-fg
								v-if="controls.EQUIP_EMPTY__CMPNY__DESIGNAT_FG.seeMoreIsVisible"
								v-bind="controls.EQUIP_EMPTY__CMPNY__DESIGNAT_FG.seeMoreParams"
								v-on="controls.EQUIP_EMPTY__CMPNY__DESIGNAT_FG.handlers" />
						</base-input-structure>
						<base-input-structure
							v-if="controls.EQUIP_EMPTY__PESS1__NAME_FG.isVisible"
							class="i-text"
							v-bind="controls.EQUIP_EMPTY__PESS1__NAME_FG"
							v-on="controls.EQUIP_EMPTY__PESS1__NAME_FG.handlers"
							:loading="controls.EQUIP_EMPTY__PESS1__NAME_FG.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.EQUIP_EMPTY__PESS1__NAME_FG.isVisible"
								v-bind="controls.EQUIP_EMPTY__PESS1__NAME_FG.props"
								v-on="controls.EQUIP_EMPTY__PESS1__NAME_FG.handlers" />
							<q-see-more-equip-empty-pess1-name-fg
								v-if="controls.EQUIP_EMPTY__PESS1__NAME_FG.seeMoreIsVisible"
								v-bind="controls.EQUIP_EMPTY__PESS1__NAME_FG.seeMoreParams"
								v-on="controls.EQUIP_EMPTY__PESS1__NAME_FG.handlers" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.EQUIP_EMPTY__EQUIP__SHOWRC_FG.isVisible || controls.EQUIP_EMPTY__EQUIP__FREQUENC_FG.isVisible || controls.EQUIP_EMPTY__ITEM__ITEMDES_FG.isVisible || controls.EQUIP_EMPTY__TPEQU__TIPOEQUI_FG.isVisible">
					<q-col
						v-if="controls.EQUIP_EMPTY__EQUIP__SHOWRC_FG.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.EQUIP_EMPTY__EQUIP__SHOWRC_FG.isVisible"
							class="i-text"
							v-bind="controls.EQUIP_EMPTY__EQUIP__SHOWRC_FG"
							v-on="controls.EQUIP_EMPTY__EQUIP__SHOWRC_FG.handlers"
							:loading="controls.EQUIP_EMPTY__EQUIP__SHOWRC_FG.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-filter
								v-if="controls.EQUIP_EMPTY__EQUIP__SHOWRC_FG.isVisible"
								v-bind="controls.EQUIP_EMPTY__EQUIP__SHOWRC_FG.props"
								v-on="controls.EQUIP_EMPTY__EQUIP__SHOWRC_FG.handlers" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.EQUIP_EMPTY__EQUIP__FREQUENC_FG.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.EQUIP_EMPTY__EQUIP__FREQUENC_FG.isVisible"
							class="i-text"
							v-bind="controls.EQUIP_EMPTY__EQUIP__FREQUENC_FG"
							v-on="controls.EQUIP_EMPTY__EQUIP__FREQUENC_FG.handlers"
							:loading="controls.EQUIP_EMPTY__EQUIP__FREQUENC_FG.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-filter
								v-if="controls.EQUIP_EMPTY__EQUIP__FREQUENC_FG.isVisible"
								v-bind="controls.EQUIP_EMPTY__EQUIP__FREQUENC_FG.props"
								v-on="controls.EQUIP_EMPTY__EQUIP__FREQUENC_FG.handlers" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.EQUIP_EMPTY__ITEM__ITEMDES_FG.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.EQUIP_EMPTY__ITEM__ITEMDES_FG.isVisible"
							class="i-text"
							v-bind="controls.EQUIP_EMPTY__ITEM__ITEMDES_FG"
							v-on="controls.EQUIP_EMPTY__ITEM__ITEMDES_FG.handlers"
							:loading="controls.EQUIP_EMPTY__ITEM__ITEMDES_FG.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-filter
								v-if="controls.EQUIP_EMPTY__ITEM__ITEMDES_FG.isVisible"
								v-bind="controls.EQUIP_EMPTY__ITEM__ITEMDES_FG.props"
								v-on="controls.EQUIP_EMPTY__ITEM__ITEMDES_FG.handlers" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.EQUIP_EMPTY__TPEQU__TIPOEQUI_FG.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.EQUIP_EMPTY__TPEQU__TIPOEQUI_FG.isVisible"
							class="i-text"
							v-bind="controls.EQUIP_EMPTY__TPEQU__TIPOEQUI_FG"
							v-on="controls.EQUIP_EMPTY__TPEQU__TIPOEQUI_FG.handlers"
							:loading="controls.EQUIP_EMPTY__TPEQU__TIPOEQUI_FG.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-filter
								v-if="controls.EQUIP_EMPTY__TPEQU__TIPOEQUI_FG.isVisible"
								v-bind="controls.EQUIP_EMPTY__TPEQU__TIPOEQUI_FG.props"
								v-on="controls.EQUIP_EMPTY__TPEQU__TIPOEQUI_FG.handlers" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.EQUIP_EMPTY__PSEUD__EQUIP_FILTRADO.isVisible">
					<q-col v-if="controls.EQUIP_EMPTY__PSEUD__EQUIP_FILTRADO.isVisible">
						<q-table
							v-if="controls.EQUIP_EMPTY__PSEUD__EQUIP_FILTRADO.isVisible"
							v-bind="controls.EQUIP_EMPTY__PSEUD__EQUIP_FILTRADO"
							v-on="controls.EQUIP_EMPTY__PSEUD__EQUIP_FILTRADO.handlers">
							<!-- USE /[MANUAL GQT CUSTOM_TABLE EQUIP_EMPTY__PSEUD__EQUIP_FILTRADO]/ -->
						</q-table>
						<q-table-extra-extension
							v-if="controls.EQUIP_EMPTY__PSEUD__EQUIP_FILTRADO.isVisible"
							:list-ctrl="controls.EQUIP_EMPTY__PSEUD__EQUIP_FILTRADO"
							:filter-operators="controls.EQUIP_EMPTY__PSEUD__EQUIP_FILTRADO.filterOperators"
							v-on="controls.EQUIP_EMPTY__PSEUD__EQUIP_FILTRADO.handlers" />
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

	import FormViewModel from './QFormEquipEmptyViewModel.js'

	const requiredTextResources = ['QFormEquipEmpty', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS EQUIP_EMPTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormEquipEmpty',

		components: {
			QSeeMoreEquipEmptyCntryCountryFg: defineAsyncComponent(() => import('@/views/forms/FormEquipEmpty/dbedits/EquipEmptyCntryCountryFgSeeMore.vue')),
			QSeeMoreEquipEmptyCmpnyDesignatFg: defineAsyncComponent(() => import('@/views/forms/FormEquipEmpty/dbedits/EquipEmptyCmpnyDesignatFgSeeMore.vue')),
			QSeeMoreEquipEmptyPess1NameFg: defineAsyncComponent(() => import('@/views/forms/FormEquipEmpty/dbedits/EquipEmptyPess1NameFgSeeMore.vue')),
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
					name: 'EQUIP_EMPTY',
					location: 'form-EQUIP_EMPTY',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormEquipEmpty', false),

				interfaceMetadata: {
					id: 'QFormEquipEmpty', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'EQUIP_EMPTY',
					route: 'form-EQUIP_EMPTY',
					isEmptyForm: true,
					area: 'Home',
					designation: computed(() => this.Resources.EQUIPMENT03632),
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
					EQUIP_EMPTY__CNTRY__COUNTRY_FG: new fieldControlClass.LookupControl({
						modelField: 'TableCntryCountry',
						id: 'EQUIP_EMPTY__CNTRY__COUNTRY_FG',
						name: 'COUNTRY',
						size: 'xlarge',
						label: computed(() => this.Resources.COUNTRY64133),
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
							name: 'CntryValCodcntryFilterKey',
							dependencyEvent: 'filterChange:cntry.codcntry'
						},
						dependentFields: () => ({
							set 'cntry.codcntry'(value) { vm.model?.CntryValCodcntryFilterKey?.updateValue(value) },
							set 'cntry.country'(value) { vm.model?.TableCntryCountry?.updateValue(value) }
						}),
						controlLimits: [
						],
					}, this),
					EQUIP_EMPTY__CMPNY__DESIGNAT_FG: new fieldControlClass.LookupControl({
						modelField: 'TableCmpnyDesignat',
						id: 'EQUIP_EMPTY__CMPNY__DESIGNAT_FG',
						name: 'DESIGNAT',
						size: 'xlarge',
						label: computed(() => this.Resources.DESIGNATION35876),
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
							name: 'CmpnyValCodempreFilterKey',
							dependencyEvent: 'filterChange:cmpny.codempre'
						},
						dependentFields: () => ({
							set 'cmpny.codempre'(value) { vm.model?.CmpnyValCodempreFilterKey?.updateValue(value) },
							set 'cmpny.designat'(value) { vm.model?.TableCmpnyDesignat?.updateValue(value) }
						}),
						controlLimits: [
						],
					}, this),
					EQUIP_EMPTY__PESS1__NAME_FG: new fieldControlClass.LookupControl({
						modelField: 'TablePess1Name',
						id: 'EQUIP_EMPTY__PESS1__NAME_FG',
						name: 'NAME',
						size: 'xlarge',
						label: computed(() => this.Resources.NAME31974),
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
							name: 'Pess1ValCodpessoFilterKey',
							dependencyEvent: 'filterChange:pess1.codpesso'
						},
						dependentFields: () => ({
							set 'pess1.codpesso'(value) { vm.model?.Pess1ValCodpessoFilterKey?.updateValue(value) },
							set 'pess1.name'(value) { vm.model?.TablePess1Name?.updateValue(value) }
						}),
						controlLimits: [
						],
					}, this),
					EQUIP_EMPTY__EQUIP__SHOWRC_FG: new fieldControlClass.FormFilterControl({
						modelField: 'ValShowrc',
						id: 'EQUIP_EMPTY__EQUIP__SHOWRC_FG',
						name: 'SHOWRC',
						size: 'small',
						label: computed(() => this.Resources.SHOW_RECORD53851),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						filterViewMode: 'checkbox',
						controlLimits: [
						],
					}, this),
					EQUIP_EMPTY__EQUIP__IFABATIF: new fieldControlClass.BooleanControl({
						modelField: 'ValIfabatif',
						valueChangeEvent: 'fieldChange:equip.ifabatif',
						id: 'EQUIP_EMPTY__EQUIP__IFABATIF',
						name: 'IFABATIF',
						size: 'medium',
						label: computed(() => this.Resources.DOWNED_EQUIPMENT43331),
						placeholder: '',
						labelPosition: computed(() => this.$app.layout.CheckboxLabelAlignment),
						isFormulaBlocked: true,
						controlLimits: [
						],
					}, this),
					EQUIP_EMPTY__EQUIP__FREQUENC_FG: new fieldControlClass.FormFilterControl({
						modelField: 'ValFrequenc',
						id: 'EQUIP_EMPTY__EQUIP__FREQUENC_FG',
						name: 'FREQUENC',
						size: 'medium',
						helpControl: {
							shortHelp: {
								type: '',
								text: '',
							},
						},
						label: computed(() => this.Resources.LOAN_FREQUENCY00701),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						filterViewMode: 'checkbox',
						columns: 0,
						arrayName: 'FreqEmpr',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					EQUIP_EMPTY__ITEM__ITEMDES_FG: new fieldControlClass.FormFilterControl({
						modelField: 'ValItemdes',
						id: 'EQUIP_EMPTY__ITEM__ITEMDES_FG',
						name: 'ITEMDES',
						size: 'xlarge',
						label: computed(() => this.Resources.ARTICLE60065),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						filterViewMode: 'text',
						controlLimits: [
						],
					}, this),
					EQUIP_EMPTY__TPEQU__TIPOEQUI_FG: new fieldControlClass.FormFilterControl({
						modelField: 'ValTipoequi',
						id: 'EQUIP_EMPTY__TPEQU__TIPOEQUI_FG',
						name: 'TIPOEQUI',
						size: 'xlarge',
						label: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						filterViewMode: 'text',
						controlLimits: [
						],
					}, this),
					EQUIP_EMPTY__PSEUD__EQUIP_FILTRADO: new fieldControlClass.TableListControl({
						id: 'EQUIP_EMPTY__PSEUD__EQUIP_FILTRADO',
						name: 'EQUIP_FILTRADO',
						size: 'block',
						label: computed(() => this.Resources.EQUIPMENT03632),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'Home',
						action: 'Equip_empty_ValEquip_filtrado',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValDtrefere',
								area: 'EQUIP',
								field: 'DTREFERE',
								label: computed(() => this.Resources.REFERENCE28402),
								scrollData: 16,
								dateTimeType: 'dateTime',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 2,
								name: 'ValLastpho',
								area: 'EQUIP',
								field: 'LASTPHO',
								label: computed(() => this.Resources.LAST_PHOTO_ATTACHED43884),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.LAST_PHOTO_ATTACHED43884)),
								scrollData: 3,
								sortable: false,
								searchable: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 3,
								name: 'ValIfabatif',
								area: 'EQUIP',
								field: 'IFABATIF',
								label: computed(() => this.Resources.DOWNED_EQUIPMENT43331),
								scrollData: 1,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'Tpequ.ValTipoequi',
								area: 'TPEQU',
								field: 'TIPOEQUI',
								label: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
								dataLength: 50,
								scrollData: 30,
								export: 1,
								pkColumn: 'ValCodtpequ',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValLast',
								area: 'EQUIP',
								field: 'LAST',
								label: computed(() => this.Resources.LAST49207),
								dataLength: 10,
								scrollData: 10,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'Room1.ValRoomnr',
								area: 'ROOM1',
								field: 'ROOMNR',
								label: computed(() => this.Resources.N_R__ROOM43805),
								dataLength: 10,
								scrollData: 10,
								export: 1,
								pkColumn: 'ValCodrooms',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'ValMoviment',
								area: 'EQUIP',
								field: 'MOVIMENT',
								label: computed(() => this.Resources.DRIVES34119),
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 8,
								name: 'Decom.ValDecomnr',
								area: 'DECOM',
								field: 'DECOMNR',
								label: computed(() => this.Resources.NO_BATE21045),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
								export: 1,
								pkColumn: 'ValCoddeco',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 9,
								name: 'ValBefore',
								area: 'EQUIP',
								field: 'BEFORE',
								label: computed(() => this.Resources.BEFORE60156),
								dataLength: 10,
								scrollData: 10,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 10,
								name: 'ValShowrc',
								area: 'EQUIP',
								field: 'SHOWRC',
								label: computed(() => this.Resources.SHOW_RECORD53851),
								scrollData: 1,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 11,
								name: 'Pess1.ValName',
								area: 'PESS1',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 85,
								scrollData: 30,
								export: 1,
								pkColumn: 'ValCodpesso',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 12,
								name: 'ValFollowin',
								area: 'EQUIP',
								field: 'FOLLOWIN',
								label: computed(() => this.Resources.FOLLOWING22170),
								dataLength: 10,
								scrollData: 10,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 13,
								name: 'Cmpny.ValDesignat',
								area: 'CMPNY',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.DESIGNATION35876),
								dataLength: 85,
								scrollData: 30,
								export: 1,
								pkColumn: 'ValCodempre',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 14,
								name: 'ValFirst',
								area: 'EQUIP',
								field: 'FIRST',
								label: computed(() => this.Resources.FIRST42972),
								dataLength: 10,
								scrollData: 10,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 15,
								name: 'ValQtdmovim',
								area: 'EQUIP',
								field: 'QTDMOVIM',
								label: computed(() => this.Resources.QTD__MOVIMENTACOES28400),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 16,
								name: 'ValValortot',
								area: 'EQUIP',
								field: 'VALORTOT',
								label: computed(() => this.Resources.TOTAL_VALUE30570),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 2,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 17,
								name: 'ValDtdeco',
								area: 'EQUIP',
								field: 'DTDECO',
								label: computed(() => this.Resources.DECOMISSION14486),
								scrollData: 16,
								dateTimeType: 'dateTime',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 18,
								name: 'ValPhotogra',
								area: 'EQUIP',
								field: 'PHOTOGRA',
								label: computed(() => this.Resources.PHOTO51874),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.PHOTO51874)),
								scrollData: 3,
								sortable: false,
								searchable: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 19,
								name: 'Wareh.ValWarehdes',
								area: 'WAREH',
								field: 'WAREHDES',
								label: computed(() => this.Resources.WAREHOUSE51864),
								dataLength: 85,
								scrollData: 30,
								export: 1,
								pkColumn: 'ValCodwareh',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 20,
								name: 'ValDesignat',
								area: 'EQUIP',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.DESIGNATION35876),
								dataLength: 85,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 21,
								name: 'ValDtaquisi',
								area: 'EQUIP',
								field: 'DTAQUISI',
								label: computed(() => this.Resources.ACQUISITION44180),
								scrollData: 8,
								dateTimeType: 'date',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 22,
								name: 'Item.ValItemdes',
								area: 'ITEM',
								field: 'ITEMDES',
								label: computed(() => this.Resources.ARTICLE60065),
								dataLength: 85,
								scrollData: 30,
								export: 1,
								pkColumn: 'ValCoditem',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 23,
								name: 'ValRegistnr',
								area: 'EQUIP',
								field: 'REGISTNR',
								label: computed(() => this.Resources.NO__REGISTER04207),
								dataLength: 6,
								scrollData: 6,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 24,
								name: 'ValBought',
								area: 'EQUIP',
								field: 'BOUGHT',
								label: computed(() => this.Resources.BOUGHT32044),
								scrollData: 1,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 25,
								name: 'ValFrequenc',
								area: 'EQUIP',
								field: 'FREQUENC',
								label: computed(() => this.Resources.LOAN_FREQUENCY00701),
								scrollData: 2,
								maxDigits: 2,
								decimalPlaces: 0,
								export: 1,
								array: computed(() => new qProjArrays.QArrayFreqempr(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayFreqempr.type,
								arrayDisplayMode: 'D',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.HyperLinkColumn({
								order: 26,
								name: 'ValSitefabr',
								area: 'EQUIP',
								field: 'SITEFABR',
								label: computed(() => this.Resources.MANUFACTURER_S_WEBSI11084),
								dataLength: 256,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 27,
								name: 'ValSequennr',
								area: 'EQUIP',
								field: 'SEQUENNR',
								label: computed(() => this.Resources.SEQUENTIAL_NO_38590),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValEquip_filtrado',
							serverMode: true,
							pkColumn: 'ValCodequip',
							tableAlias: 'EQUIP',
							tableNamePlural: computed(() => this.Resources.EQUIPMENT03632),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.EQUIPMENT03632),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: false
							},
							filtersVisible: false,
							allowColumnFilters: false,
							allowColumnSort: true,
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
							],
							rowClickAction: {
							},
							formsDefinition: {
							},
							defaultSearchColumnName: 'ValRegistnr',
							defaultSearchColumnNameOriginal: 'ValRegistnr',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-PESS1', 'changed-TPEQU', 'changed-ROOM1', 'changed-WAREH', 'changed-EQUIP', 'changed-CMPNY', 'changed-ITEM', 'changed-DECOM'],
						internalEvents: ['filterChange:cntry.codcntry', 'filterChange:cmpny.codempre', 'filterChange:pess1.codpesso', 'filterChange:equip.showrc', 'filterChange:equip.frequenc', 'filterChange:item.itemdes', 'filterChange:tpequ.tipoequi'],
						globalFilters: [
							{
								identifier: 'cntry.codcntry',
								getValue: () => this.model?.CntryValCodcntryFilterKey?.value
							},
							{
								identifier: 'cmpny.codempre',
								getValue: () => this.model?.CmpnyValCodempreFilterKey?.value
							},
							{
								identifier: 'pess1.codpesso',
								getValue: () => this.model?.Pess1ValCodpessoFilterKey?.value
							},
							{
								identifier: 'equip.showrc',
								getValue: () => this.model?.ValShowrc?.value
							},
							{
								identifier: 'equip.frequenc',
								getValue: () => this.model?.ValFrequenc?.value
							},
							{
								identifier: 'item.itemdes',
								getValue: () => this.model?.ValItemdes?.value
							},
							{
								identifier: 'tpequ.tipoequi',
								getValue: () => this.model?.ValTipoequi?.value
							},
						],
						uuid: 'Equip_empty_ValEquip_filtrado',
						allSelectedRows: 'false',
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
					'EQUIP_EMPTY__PSEUD__EQUIP_FILTRADO',
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
					Cntry: {
						get ValCountry() { return vm.model.TableCntryCountry.value },
						set ValCountry(value) { vm.model.TableCntryCountry.updateValue(value) },
					},
					Equip: {
						get ValFrequenc() { return vm.model.ValFrequenc.value },
						set ValFrequenc(value) { vm.model.ValFrequenc.updateValue(value) },
						get ValIfabatif() { return vm.model.ValIfabatif.value },
						set ValIfabatif(value) { vm.model.ValIfabatif.updateValue(value) },
						get ValShowrc() { return vm.model.ValShowrc.value },
						set ValShowrc(value) { vm.model.ValShowrc.updateValue(value) },
					},
					Item: {
						get ValItemdes() { return vm.model.ValItemdes.value },
						set ValItemdes(value) { vm.model.ValItemdes.updateValue(value) },
					},
					Pess1: {
						get ValName() { return vm.model.TablePess1Name.value },
						set ValName(value) { vm.model.TablePess1Name.updateValue(value) },
					},
					Tpequ: {
						get ValTipoequi() { return vm.model.ValTipoequi.value },
						set ValTipoequi(value) { vm.model.ValTipoequi.updateValue(value) },
					},
					keys: {
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
// USE /[MANUAL GQT FORM_CODEJS EQUIP_EMPTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT EQUIP_EMPTY]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS EQUIP_EMPTY]/
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
// USE /[MANUAL GQT FORM_LOADED_JS EQUIP_EMPTY]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS EQUIP_EMPTY]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS EQUIP_EMPTY]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS EQUIP_EMPTY]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS EQUIP_EMPTY]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS EQUIP_EMPTY]/
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
// USE /[MANUAL GQT AFTER_DEL_JS EQUIP_EMPTY]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS EQUIP_EMPTY]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS EQUIP_EMPTY]/
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
// USE /[MANUAL GQT DLGUPDT EQUIP_EMPTY]/
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
// USE /[MANUAL GQT CTRLBLR EQUIP_EMPTY]/
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
// USE /[MANUAL GQT CTRLUPD EQUIP_EMPTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS EQUIP_EMPTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
