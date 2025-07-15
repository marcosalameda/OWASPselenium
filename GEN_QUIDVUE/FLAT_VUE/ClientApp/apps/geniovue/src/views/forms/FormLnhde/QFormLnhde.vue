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
			data-key="LNHDE"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.LNHDE___PEDIDNRPEDIDO.isVisible || controls.LNHDE___LNHPDLINE____.isVisible || controls.LNHDE___LNHDEORDEM___.isVisible || controls.LNHDE___TPEQ1TIPOEQUI.isVisible || controls.LNHDE___LNHDEQUANTIDA.isVisible || controls.LNHDE___LNHDEQUANTDEC.isVisible">
					<q-control-wrapper
						v-show="controls.LNHDE___PEDIDNRPEDIDO.isVisible || controls.LNHDE___LNHPDLINE____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LNHDE___PEDIDNRPEDIDO"
							v-on="controls.LNHDE___PEDIDNRPEDIDO.handlers"
							:loading="controls.LNHDE___PEDIDNRPEDIDO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.LNHDE___PEDIDNRPEDIDO.isVisible"
								v-bind="controls.LNHDE___PEDIDNRPEDIDO.props"
								v-on="controls.LNHDE___PEDIDNRPEDIDO.handlers" />
							<q-see-more-lnhde-pedidnrpedido
								v-if="controls.LNHDE___PEDIDNRPEDIDO.seeMoreIsVisible"
								v-bind="controls.LNHDE___PEDIDNRPEDIDO.seeMoreParams"
								v-on="controls.LNHDE___PEDIDNRPEDIDO.handlers" />
						</base-input-structure>
						<base-input-structure
							class="i-text"
							v-bind="controls.LNHDE___LNHPDLINE____"
							v-on="controls.LNHDE___LNHPDLINE____.handlers"
							:loading="controls.LNHDE___LNHPDLINE____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.LNHDE___LNHPDLINE____.isVisible"
								v-bind="controls.LNHDE___LNHPDLINE____.props"
								v-on="controls.LNHDE___LNHPDLINE____.handlers" />
							<q-see-more-lnhde-lnhpdline
								v-if="controls.LNHDE___LNHPDLINE____.seeMoreIsVisible"
								v-bind="controls.LNHDE___LNHPDLINE____.seeMoreParams"
								v-on="controls.LNHDE___LNHPDLINE____.handlers" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.LNHDE___LNHDEORDEM___.isVisible || controls.LNHDE___TPEQ1TIPOEQUI.isVisible || controls.LNHDE___LNHDEQUANTIDA.isVisible || controls.LNHDE___LNHDEQUANTDEC.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LNHDE___LNHDEORDEM___"
							v-on="controls.LNHDE___LNHDEORDEM___.handlers"
							:loading="controls.LNHDE___LNHDEORDEM___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.LNHDE___LNHDEORDEM___.isVisible"
								v-bind="controls.LNHDE___LNHDEORDEM___.props"
								@update:model-value="model.ValOrdem.fnUpdateValue" />
						</base-input-structure>
						<base-input-structure
							class="i-text"
							v-bind="controls.LNHDE___TPEQ1TIPOEQUI"
							v-on="controls.LNHDE___TPEQ1TIPOEQUI.handlers"
							:loading="controls.LNHDE___TPEQ1TIPOEQUI.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.LNHDE___TPEQ1TIPOEQUI.isVisible"
								v-bind="controls.LNHDE___TPEQ1TIPOEQUI.props"
								v-on="controls.LNHDE___TPEQ1TIPOEQUI.handlers" />
							<q-see-more-lnhde-tpeq1tipoequi
								v-if="controls.LNHDE___TPEQ1TIPOEQUI.seeMoreIsVisible"
								v-bind="controls.LNHDE___TPEQ1TIPOEQUI.seeMoreParams"
								v-on="controls.LNHDE___TPEQ1TIPOEQUI.handlers" />
						</base-input-structure>
						<base-input-structure
							class="i-text"
							v-bind="controls.LNHDE___LNHDEQUANTIDA"
							v-on="controls.LNHDE___LNHDEQUANTIDA.handlers"
							:loading="controls.LNHDE___LNHDEQUANTIDA.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.LNHDE___LNHDEQUANTIDA.isVisible"
								v-bind="controls.LNHDE___LNHDEQUANTIDA.props"
								@update:model-value="model.ValQuantida.fnUpdateValue" />
						</base-input-structure>
						<base-input-structure
							class="i-text"
							v-bind="controls.LNHDE___LNHDEQUANTDEC"
							v-on="controls.LNHDE___LNHDEQUANTDEC.handlers"
							:loading="controls.LNHDE___LNHDEQUANTDEC.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.LNHDE___LNHDEQUANTDEC.isVisible"
								v-bind="controls.LNHDE___LNHDEQUANTDEC.props"
								@update:model-value="model.ValQuantdec.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.LNHDE___LNHDECODE____.isVisible">
					<q-control-wrapper
						v-show="controls.LNHDE___LNHDECODE____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LNHDE___LNHDECODE____"
							v-on="controls.LNHDE___LNHDECODE____.handlers"
							:loading="controls.LNHDE___LNHDECODE____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.LNHDE___LNHDECODE____.props"
								@blur="onBlur(controls.LNHDE___LNHDECODE____, model.ValCode.value)"
								@change="model.ValCode.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.LNHDE___LNHDEDESCRIPT.isVisible">
					<q-control-wrapper
						v-show="controls.LNHDE___LNHDEDESCRIPT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-textarea"
							v-bind="controls.LNHDE___LNHDEDESCRIPT"
							v-on="controls.LNHDE___LNHDEDESCRIPT.handlers"
							:loading="controls.LNHDE___LNHDEDESCRIPT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-area
								v-if="controls.LNHDE___LNHDEDESCRIPT.isVisible"
								v-bind="controls.LNHDE___LNHDEDESCRIPT.props"
								v-on="controls.LNHDE___LNHDEDESCRIPT.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.LNHDE___LNHDEURL_____.isVisible">
					<q-control-wrapper
						v-show="controls.LNHDE___LNHDEURL_____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LNHDE___LNHDEURL_____"
							v-on="controls.LNHDE___LNHDEURL_____.handlers"
							:loading="controls.LNHDE___LNHDEURL_____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.LNHDE___LNHDEURL_____.props"
								@blur="onBlur(controls.LNHDE___LNHDEURL_____, model.ValUrl.value)"
								@change="model.ValUrl.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.LNHDE___PSEUDLNPROPS_.isVisible">
					<q-control-wrapper
						v-show="controls.LNHDE___PSEUDLNPROPS_.isVisible"
						class="control-join-group">
						<q-table
							v-show="controls.LNHDE___PSEUDLNPROPS_.isVisible"
							v-bind="controls.LNHDE___PSEUDLNPROPS_"
							v-on="controls.LNHDE___PSEUDLNPROPS_.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.LNHDE___PSEUDLNPROPS_"
							:filter-operators="controls.LNHDE___PSEUDLNPROPS_.filterOperators"
							v-on="controls.LNHDE___PSEUDLNPROPS_.handlers" />
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
	/* eslint-enable no-unused-vars */

	import FormViewModel from './QFormLnhdeViewModel.js'

	const requiredTextResources = ['QFormLnhde', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS LNHDE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormLnhde',

		components: {
			QSeeMoreLnhdePedidnrpedido: defineAsyncComponent(() => import('@/views/forms/FormLnhde/dbedits/LnhdePedidnrpedidoSeeMore.vue')),
			QSeeMoreLnhdeLnhpdline: defineAsyncComponent(() => import('@/views/forms/FormLnhde/dbedits/LnhdeLnhpdlineSeeMore.vue')),
			QSeeMoreLnhdeTpeq1tipoequi: defineAsyncComponent(() => import('@/views/forms/FormLnhde/dbedits/LnhdeTpeq1tipoequiSeeMore.vue')),
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
					name: 'LNHDE',
					location: 'form-LNHDE',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormLnhde', false),

				interfaceMetadata: {
					id: 'QFormLnhde', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'LNHDE',
					route: 'form-LNHDE',
					area: 'LNHDE',
					primaryKey: 'ValCodlnhde',
					designation: computed(() => this.Resources.DISAGGREGATION_LINE06730),
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
					LNHDE___PEDIDNRPEDIDO: new fieldControlClass.LookupControl({
						modelField: 'TablePedidNrpedido',
						valueChangeEvent: 'fieldChange:pedid.nrpedido',
						id: 'LNHDE___PEDIDNRPEDIDO',
						name: 'NRPEDIDO',
						size: 'mini',
						label: computed(() => this.Resources.ORDER_NO_15510),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodpedid',
							dependencyEvent: 'fieldChange:lnhde.codpedid'
						},
						dependentFields: () => ({
							set 'pedid.codpedid'(value) { vm.model.ValCodpedid.updateValue(value) },
							set 'pedid.nrpedido'(value) { vm.model.TablePedidNrpedido.updateValue(value) },
						}),
						insertEnabled: true,
						supportForm: 'PEDID',
						controlLimits: [
						],
					}, this),
					LNHDE___LNHPDLINE____: new fieldControlClass.LookupControl({
						modelField: 'TableLnhpdLine',
						valueChangeEvent: 'fieldChange:lnhpd.line',
						id: 'LNHDE___LNHPDLINE____',
						name: 'LINE',
						size: 'small',
						label: computed(() => this.Resources.ORDER_LINE_13692),
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
							name: 'ValCodlnhpd',
							dependencyEvent: 'fieldChange:lnhde.codlnhpd'
						},
						dependentFields: () => ({
							set 'lnhpd.codlnhpd'(value) { vm.model.ValCodlnhpd.updateValue(value) },
							set 'lnhpd.line'(value) { vm.model.TableLnhpdLine.updateValue(value) },
							set 'lnhpd.quantdec'(value) { vm.model.LnhpdValQuantdec.updateValue(value) },
						}),
						insertEnabled: true,
						supportForm: 'LNHPD',
						controlLimits: [
							{
								identifier: ['pedid', 'lnhde.codpedid'],
								dependencyEvents: ['fieldChange:lnhde.codpedid'],
								dependencyField: 'LNHDE.CODPEDID',
								fnValueSelector: (model) => model.ValCodpedid.value
							},
						],
					}, this),
					LNHDE___LNHDEORDEM___: new fieldControlClass.NumberControl({
						modelField: 'ValOrdem',
						valueChangeEvent: 'fieldChange:lnhde.ordem',
						id: 'LNHDE___LNHDEORDEM___',
						name: 'ORDEM',
						size: 'small',
						label: computed(() => this.Resources.ORDER39632),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 3,
						maxDecimals: 0,
						isSequencial: true,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					LNHDE___TPEQ1TIPOEQUI: new fieldControlClass.LookupControl({
						modelField: 'TableTpeq1Tipoequi',
						valueChangeEvent: 'fieldChange:tpeq1.tipoequi',
						id: 'LNHDE___TPEQ1TIPOEQUI',
						name: 'TIPOEQUI',
						size: 'xlarge',
						label: computed(() => this.Resources.TYPE_OF_EQUIPMENT64921),
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
							name: 'ValCodtpequ',
							dependencyEvent: 'fieldChange:lnhde.codtpequ'
						},
						dependentFields: () => ({
							set 'tpeq1.codtpequ'(value) { vm.model.ValCodtpequ.updateValue(value) },
							set 'tpeq1.tipoequi'(value) { vm.model.TableTpeq1Tipoequi.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					LNHDE___LNHDEQUANTIDA: new fieldControlClass.NumberControl({
						modelField: 'ValQuantida',
						valueChangeEvent: 'fieldChange:lnhde.quantida',
						id: 'LNHDE___LNHDEQUANTIDA',
						name: 'QUANTIDA',
						size: 'small',
						label: computed(() => this.Resources.QUANTITY_08002),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					LNHDE___LNHDEQUANTDEC: new fieldControlClass.NumberControl({
						modelField: 'ValQuantdec',
						valueChangeEvent: 'fieldChange:lnhde.quantdec',
						id: 'LNHDE___LNHDEQUANTDEC',
						name: 'QUANTDEC',
						size: 'small',
						label: computed(() => this.Resources.AMOUNT46885),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 7,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					LNHDE___LNHDECODE____: new fieldControlClass.StringControl({
						modelField: 'ValCode',
						valueChangeEvent: 'fieldChange:lnhde.code',
						id: 'LNHDE___LNHDECODE____',
						name: 'CODE',
						size: 'small',
						label: computed(() => this.Resources.CODIGO20695),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 10,
						labelId: 'label_LNHDE___LNHDECODE____',
						controlLimits: [
						],
					}, this),
					LNHDE___LNHDEDESCRIPT: new fieldControlClass.MultilineStringControl({
						modelField: 'ValDescript',
						valueChangeEvent: 'fieldChange:lnhde.descript',
						id: 'LNHDE___LNHDEDESCRIPT',
						name: 'DESCRIPT',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESCRIPTION07383),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						rows: 2,
						cols: 85,
						controlLimits: [
						],
					}, this),
					LNHDE___LNHDEURL_____: new fieldControlClass.StringControl({
						modelField: 'ValUrl',
						valueChangeEvent: 'fieldChange:lnhde.url',
						id: 'LNHDE___LNHDEURL_____',
						name: 'URL',
						size: 'xxlarge',
						label: computed(() => this.Resources.SITE06486),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 250,
						labelId: 'label_LNHDE___LNHDEURL_____',
						controlLimits: [
						],
					}, this),
					LNHDE___PSEUDLNPROPS_: new fieldControlClass.TableListControl({
						id: 'LNHDE___PSEUDLNPROPS_',
						name: 'LNPROPS',
						size: '',
						label: computed(() => this.Resources.EQUIPMENT_GROUPINGS20350),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'LNHDE',
						action: 'Lnhde_ValLnprops',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValName',
								area: 'LNHDF',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValLnprops',
							serverMode: true,
							pkColumn: 'ValCodlnhdf',
							tableAlias: 'LNHDF',
							tableNamePlural: computed(() => this.Resources.DISAGGREGATION_LINES45819),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.EQUIPMENT_GROUPINGS20350),
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
										formName: 'LNHDF',
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
										formName: 'LNHDF',
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
										formName: 'LNHDF',
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
										formName: 'LNHDF',
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
										formName: 'LNHDF',
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
								id: 'RCA__LNHDF',
								name: '_LNHDF',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'LNHDF',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'LNHDF': {
									fnKeySelector: (row) => row.Fields.ValCodlnhdf,
									isPopup: true
								},
							},
							defaultSearchColumnName: 'ValName',
							defaultSearchColumnNameOriginal: 'ValName',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-LNHDE', 'changed-LNHDF'],
						uuid: 'Lnhde_ValLnprops',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'lnhde'],
								dependencyEvents: ['fieldChange:lnhde.codlnhde'],
								dependencyField: 'LNHDE.CODLNHDE',
								fnValueSelector: (model) => model.ValCodlnhde.value
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
					'LNHDE___PSEUDLNPROPS_',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Lnhde: {
						get ValCode() { return vm.model.ValCode.value },
						set ValCode(value) { vm.model.ValCode.updateValue(value) },
						get ValCodlnhag() { return vm.model.ValCodlnhag.value },
						set ValCodlnhag(value) { vm.model.ValCodlnhag.updateValue(value) },
						get ValCodlnhpd() { return vm.model.ValCodlnhpd.value },
						set ValCodlnhpd(value) { vm.model.ValCodlnhpd.updateValue(value) },
						get ValCodpedid() { return vm.model.ValCodpedid.value },
						set ValCodpedid(value) { vm.model.ValCodpedid.updateValue(value) },
						get ValCodtpequ() { return vm.model.ValCodtpequ.value },
						set ValCodtpequ(value) { vm.model.ValCodtpequ.updateValue(value) },
						get ValDescript() { return vm.model.ValDescript.value },
						set ValDescript(value) { vm.model.ValDescript.updateValue(value) },
						get ValOrdem() { return vm.model.ValOrdem.value },
						set ValOrdem(value) { vm.model.ValOrdem.updateValue(value) },
						get ValQuantdec() { return vm.model.ValQuantdec.value },
						set ValQuantdec(value) { vm.model.ValQuantdec.updateValue(value) },
						get ValQuantida() { return vm.model.ValQuantida.value },
						set ValQuantida(value) { vm.model.ValQuantida.updateValue(value) },
						get ValUrl() { return vm.model.ValUrl.value },
						set ValUrl(value) { vm.model.ValUrl.updateValue(value) },
					},
					Lnhpd: {
						get ValLine() { return vm.model.TableLnhpdLine.value },
						set ValLine(value) { vm.model.TableLnhpdLine.updateValue(value) },
						get ValQuantdec() { return vm.model.LnhpdValQuantdec.value },
						set ValQuantdec(value) { vm.model.LnhpdValQuantdec.updateValue(value) },
					},
					Pedid: {
						get ValNrpedido() { return vm.model.TablePedidNrpedido.value },
						set ValNrpedido(value) { vm.model.TablePedidNrpedido.updateValue(value) },
					},
					Tpeq1: {
						get ValTipoequi() { return vm.model.TableTpeq1Tipoequi.value },
						set ValTipoequi(value) { vm.model.TableTpeq1Tipoequi.updateValue(value) },
					},
					keys: {
						/** The primary key of the LNHDE table */
						get lnhde() { return vm.model.ValCodlnhde },
						/** The foreign key to the LNHPD table */
						get lnhpd() { return vm.model.ValCodlnhpd },
						/** The foreign key to the PEDID table */
						get pedid() { return vm.model.ValCodpedid },
						/** The foreign key to the TPEQ1 table */
						get tpeq1() { return vm.model.ValCodtpequ },
						/** The foreign key to the LNHAG table */
						get lnhag() { return vm.model.ValCodlnhag },
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
// USE /[MANUAL GQT FORM_CODEJS LNHDE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT LNHDE]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS LNHDE]/
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
// USE /[MANUAL GQT FORM_LOADED_JS LNHDE]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS LNHDE]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS LNHDE]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS LNHDE]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS LNHDE]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS LNHDE]/
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
// USE /[MANUAL GQT AFTER_DEL_JS LNHDE]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS LNHDE]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS LNHDE]/
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
// USE /[MANUAL GQT DLGUPDT LNHDE]/
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
// USE /[MANUAL GQT CTRLBLR LNHDE]/
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
// USE /[MANUAL GQT CTRLUPD LNHDE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS LNHDE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
