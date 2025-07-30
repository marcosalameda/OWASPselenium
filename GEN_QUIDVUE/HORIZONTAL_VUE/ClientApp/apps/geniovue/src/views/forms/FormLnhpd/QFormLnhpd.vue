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
			data-key="LNHPD"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.LNHPD___PEDIDNRPEDIDO.isVisible">
					<q-control-wrapper
						v-show="controls.LNHPD___PEDIDNRPEDIDO.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LNHPD___PEDIDNRPEDIDO"
							v-on="controls.LNHPD___PEDIDNRPEDIDO.handlers"
							:loading="controls.LNHPD___PEDIDNRPEDIDO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.LNHPD___PEDIDNRPEDIDO.isVisible"
								v-bind="controls.LNHPD___PEDIDNRPEDIDO.props"
								v-on="controls.LNHPD___PEDIDNRPEDIDO.handlers" />
							<q-see-more-lnhpd-pedidnrpedido
								v-if="controls.LNHPD___PEDIDNRPEDIDO.seeMoreIsVisible"
								v-bind="controls.LNHPD___PEDIDNRPEDIDO.seeMoreParams"
								v-on="controls.LNHPD___PEDIDNRPEDIDO.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.LNHPD___LNHPDLINE____.isVisible || controls.LNHPD___TPEQUTIPOEQUI.isVisible || controls.LNHPD___PSEUDDESCONJU.isVisible">
					<q-control-wrapper
						v-show="controls.LNHPD___LNHPDLINE____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LNHPD___LNHPDLINE____"
							v-on="controls.LNHPD___LNHPDLINE____.handlers"
							:loading="controls.LNHPD___LNHPDLINE____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.LNHPD___LNHPDLINE____.isVisible"
								v-bind="controls.LNHPD___LNHPDLINE____.props"
								@update:model-value="model.ValLine.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.LNHPD___TPEQUTIPOEQUI.isVisible || controls.LNHPD___PSEUDDESCONJU.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LNHPD___TPEQUTIPOEQUI"
							v-on="controls.LNHPD___TPEQUTIPOEQUI.handlers"
							:loading="controls.LNHPD___TPEQUTIPOEQUI.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.LNHPD___TPEQUTIPOEQUI.isVisible"
								v-bind="controls.LNHPD___TPEQUTIPOEQUI.props"
								v-on="controls.LNHPD___TPEQUTIPOEQUI.handlers" />
							<q-see-more-lnhpd-tpequtipoequi
								v-if="controls.LNHPD___TPEQUTIPOEQUI.seeMoreIsVisible"
								v-bind="controls.LNHPD___TPEQUTIPOEQUI.seeMoreParams"
								v-on="controls.LNHPD___TPEQUTIPOEQUI.handlers" />
						</base-input-structure>
						<base-input-structure
							class="i-button"
							v-bind="controls.LNHPD___PSEUDDESCONJU"
							v-on="controls.LNHPD___PSEUDDESCONJU.handlers"
							:loading="controls.LNHPD___PSEUDDESCONJU.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-button
								v-if="controls.LNHPD___PSEUDDESCONJU.isVisible"
								id="LNHPD___PSEUDDESCONJU"
								:label="controls.LNHPD___PSEUDDESCONJU.label"
								:disabled="controls.LNHPD___PSEUDDESCONJU.isBlocked"
								@click="controls.LNHPD___PSEUDDESCONJU.action($event)">
								<q-icon v-bind="controls.LNHPD___PSEUDDESCONJU.icon" />
							</q-button>
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.LNHPD___LNHPDQUANTIDA.isVisible">
					<q-control-wrapper
						v-show="controls.LNHPD___LNHPDQUANTIDA.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LNHPD___LNHPDQUANTIDA"
							v-on="controls.LNHPD___LNHPDQUANTIDA.handlers"
							:loading="controls.LNHPD___LNHPDQUANTIDA.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.LNHPD___LNHPDQUANTIDA.isVisible"
								v-bind="controls.LNHPD___LNHPDQUANTIDA.props"
								@update:model-value="model.ValQuantida.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.LNHPD___LNHPDQUANTDEC.isVisible">
					<q-control-wrapper
						v-show="controls.LNHPD___LNHPDQUANTDEC.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.LNHPD___LNHPDQUANTDEC"
							v-on="controls.LNHPD___LNHPDQUANTDEC.handlers"
							:loading="controls.LNHPD___LNHPDQUANTDEC.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.LNHPD___LNHPDQUANTDEC.isVisible"
								v-bind="controls.LNHPD___LNHPDQUANTDEC.props"
								@update:model-value="model.ValQuantdec.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.LNHPD___PSEUDDESAGREG.isVisible">
					<q-control-wrapper
						v-show="controls.LNHPD___PSEUDDESAGREG.isVisible"
						class="control-join-group">
						<q-table
							v-show="controls.LNHPD___PSEUDDESAGREG.isVisible"
							v-bind="controls.LNHPD___PSEUDDESAGREG"
							v-on="controls.LNHPD___PSEUDDESAGREG.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.LNHPD___PSEUDDESAGREG"
							:filter-operators="controls.LNHPD___PSEUDDESAGREG.filterOperators"
							v-on="controls.LNHPD___PSEUDDESAGREG.handlers" />
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

	import FormViewModel from './QFormLnhpdViewModel.js'

	const requiredTextResources = ['QFormLnhpd', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS LNHPD]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormLnhpd',

		components: {
			QSeeMoreLnhpdPedidnrpedido: defineAsyncComponent(() => import('@/views/forms/FormLnhpd/dbedits/LnhpdPedidnrpedidoSeeMore.vue')),
			QSeeMoreLnhpdTpequtipoequi: defineAsyncComponent(() => import('@/views/forms/FormLnhpd/dbedits/LnhpdTpequtipoequiSeeMore.vue')),
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
					name: 'LNHPD',
					location: 'form-LNHPD',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormLnhpd', false),

				interfaceMetadata: {
					id: 'QFormLnhpd', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'LNHPD',
					route: 'form-LNHPD',
					area: 'LNHPD',
					primaryKey: 'ValCodlnhpd',
					designation: computed(() => this.Resources.ORDER_LINE50035),
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
					LNHPD___PEDIDNRPEDIDO: new fieldControlClass.LookupControl({
						modelField: 'TablePedidNrpedido',
						valueChangeEvent: 'fieldChange:pedid.nrpedido',
						id: 'LNHPD___PEDIDNRPEDIDO',
						name: 'NRPEDIDO',
						size: 'mini',
						label: computed(() => this.Resources.ORDER_NO_15510),
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
							name: 'ValCodpedid',
							dependencyEvent: 'fieldChange:lnhpd.codpedid'
						},
						dependentFields: () => ({
							set 'pedid.codpedid'(value) { vm.model.ValCodpedid.updateValue(value) },
							set 'pedid.nrpedido'(value) { vm.model.TablePedidNrpedido.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					LNHPD___LNHPDLINE____: new fieldControlClass.NumberControl({
						modelField: 'ValLine',
						valueChangeEvent: 'fieldChange:lnhpd.line',
						id: 'LNHPD___LNHPDLINE____',
						name: 'LINE',
						size: 'mini',
						label: computed(() => this.Resources.LINE27983),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 3,
						maxDecimals: 0,
						isSequencial: true,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					LNHPD___TPEQUTIPOEQUI: new fieldControlClass.LookupControl({
						modelField: 'TableTpequTipoequi',
						valueChangeEvent: 'fieldChange:tpequ.tipoequi',
						id: 'LNHPD___TPEQUTIPOEQUI',
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
							dependencyEvent: 'fieldChange:lnhpd.codtpequ'
						},
						dependentFields: () => ({
							set 'tpequ.codtpequ'(value) { vm.model.ValCodtpequ.updateValue(value) },
							set 'tpequ.tipoequi'(value) { vm.model.TableTpequTipoequi.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					LNHPD___PSEUDDESCONJU: new fieldControlClass.ButtonControl({
						id: 'LNHPD___PSEUDDESCONJU',
						name: 'DESCONJU',
						size: 'small',
						hasLabel: false,
						label: computed(() => this.Resources.BREAKS_DOWN15669),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						icon: {
							icon: computed(() => `${this.$app.resourcesPath}ok.ico?v=2932`),
							type: 'img',
							role: 'presentation',
						},
						// eslint-disable-next-line
						action: (event) => {
							const btnAction = () => {
								if (!vm.isEditable)
									return Promise.resolve(true)

								const action = 'GetCarga_CONJUNTO'
								const params = { idsrc: vm.model.ValCodtpequ.value, iddst: vm.primaryKeyValue }

								return netAPI.postData(
									vm.formInfo.area,
									action,
									params,
									(data) => {
										if (data.Success)
										{
											genericFunctions.displayMessage(data.data, 'success')
											vm.fetchFormFields(true)
										}
										else
											genericFunctions.displayMessage(data.data, 'error')
									},
									undefined,
									undefined,
									vm.navigationId)
							}
							btnAction()
						},
						controlLimits: [
						],
					}, this),
					LNHPD___LNHPDQUANTIDA: new fieldControlClass.NumberControl({
						modelField: 'ValQuantida',
						valueChangeEvent: 'fieldChange:lnhpd.quantida',
						id: 'LNHPD___LNHPDQUANTIDA',
						name: 'QUANTIDA',
						size: 'small',
						label: computed(() => this.Resources.QUANTITY06415),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					LNHPD___LNHPDQUANTDEC: new fieldControlClass.NumberControl({
						modelField: 'ValQuantdec',
						valueChangeEvent: 'fieldChange:lnhpd.quantdec',
						id: 'LNHPD___LNHPDQUANTDEC',
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
					LNHPD___PSEUDDESAGREG: new fieldControlClass.TableListControl({
						id: 'LNHPD___PSEUDDESAGREG',
						name: 'DESAGREG',
						size: '',
						label: computed(() => this.Resources.BREAKDOWN_60448),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'LNHPD',
						action: 'Lnhpd_ValDesagreg',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.NumericColumn({
								order: 1,
								name: 'ValOrdem',
								area: 'LNHDE',
								field: 'ORDEM',
								label: computed(() => this.Resources.ORDER39632),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'Tpeq1.ValTipoequi',
								area: 'TPEQ1',
								field: 'TIPOEQUI',
								label: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
								dataLength: 50,
								scrollData: 50,
								pkColumn: 'ValCodtpequ',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 3,
								name: 'ValQuantida',
								area: 'LNHDE',
								field: 'QUANTIDA',
								label: computed(() => this.Resources.AMOUNT46885),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValDescript',
								area: 'LNHDE',
								field: 'DESCRIPT',
								label: computed(() => this.Resources.DESCRIPTION07383),
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValCode',
								area: 'LNHDE',
								field: 'CODE',
								label: computed(() => this.Resources.CODE49225),
								dataLength: 10,
								scrollData: 10,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.HyperLinkColumn({
								order: 6,
								name: 'ValUrl',
								area: 'LNHDE',
								field: 'URL',
								label: computed(() => this.Resources.SITE06486),
								dataLength: 250,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValDesagreg',
							serverMode: true,
							pkColumn: 'ValCodlnhde',
							tableAlias: 'LNHDE',
							tableNamePlural: computed(() => this.Resources.DISAGGREGATION_LINES31100),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.BREAKDOWN_60448),
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
										formName: 'LNHDE',
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
										formName: 'LNHDE',
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
										formName: 'LNHDE',
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
										formName: 'LNHDE',
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
										formName: 'LNHDE',
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
								id: 'RCA__LNHDE',
								name: '_LNHDE',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'LNHDE',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'LNHDE': {
									fnKeySelector: (row) => row.Fields.ValCodlnhde,
									isPopup: false
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'ValOrdem',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-PEDID', 'changed-LNHAG', 'changed-LNHDE', 'changed-LNHPD', 'changed-TPEQ1'],
						uuid: 'Lnhpd_ValDesagreg',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'lnhpd'],
								dependencyEvents: ['fieldChange:lnhpd.codlnhpd'],
								dependencyField: 'LNHPD.CODLNHPD',
								fnValueSelector: (model) => model.ValCodlnhpd.value
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
					'LNHPD___PSEUDDESAGREG',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Lnhpd: {
						get ValCodpedid() { return vm.model.ValCodpedid.value },
						set ValCodpedid(value) { vm.model.ValCodpedid.updateValue(value) },
						get ValCodtpequ() { return vm.model.ValCodtpequ.value },
						set ValCodtpequ(value) { vm.model.ValCodtpequ.updateValue(value) },
						get ValLine() { return vm.model.ValLine.value },
						set ValLine(value) { vm.model.ValLine.updateValue(value) },
						get ValQuantdec() { return vm.model.ValQuantdec.value },
						set ValQuantdec(value) { vm.model.ValQuantdec.updateValue(value) },
						get ValQuantida() { return vm.model.ValQuantida.value },
						set ValQuantida(value) { vm.model.ValQuantida.updateValue(value) },
					},
					Pedid: {
						get ValNrpedido() { return vm.model.TablePedidNrpedido.value },
						set ValNrpedido(value) { vm.model.TablePedidNrpedido.updateValue(value) },
					},
					Tpequ: {
						get ValTipoequi() { return vm.model.TableTpequTipoequi.value },
						set ValTipoequi(value) { vm.model.TableTpequTipoequi.updateValue(value) },
					},
					keys: {
						/** The primary key of the LNHPD table */
						get lnhpd() { return vm.model.ValCodlnhpd },
						/** The foreign key to the PEDID table */
						get pedid() { return vm.model.ValCodpedid },
						/** The foreign key to the TPEQU table */
						get tpequ() { return vm.model.ValCodtpequ },
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
// USE /[MANUAL GQT FORM_CODEJS LNHPD]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT LNHPD]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS LNHPD]/
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
// USE /[MANUAL GQT FORM_LOADED_JS LNHPD]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS LNHPD]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS LNHPD]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS LNHPD]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS LNHPD]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS LNHPD]/
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
// USE /[MANUAL GQT AFTER_DEL_JS LNHPD]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS LNHPD]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS LNHPD]/
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
// USE /[MANUAL GQT DLGUPDT LNHPD]/
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
// USE /[MANUAL GQT CTRLBLR LNHPD]/
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
// USE /[MANUAL GQT CTRLUPD LNHPD]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS LNHPD]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
