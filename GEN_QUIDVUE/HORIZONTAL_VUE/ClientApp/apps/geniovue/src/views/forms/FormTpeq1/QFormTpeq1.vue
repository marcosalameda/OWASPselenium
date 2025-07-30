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
			data-key="TPEQ1"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.TPEQ1___FAMI1FAMILY__.isVisible || controls.TPEQ1___TPEQ1TPEQUCOD.isVisible || controls.TPEQ1___TPEQ1NIVEL___.isVisible">
					<q-control-wrapper
						v-show="controls.TPEQ1___FAMI1FAMILY__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.TPEQ1___FAMI1FAMILY__"
							v-on="controls.TPEQ1___FAMI1FAMILY__.handlers"
							:loading="controls.TPEQ1___FAMI1FAMILY__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.TPEQ1___FAMI1FAMILY__.isVisible"
								v-bind="controls.TPEQ1___FAMI1FAMILY__.props"
								v-on="controls.TPEQ1___FAMI1FAMILY__.handlers" />
							<q-see-more-tpeq1-fami1family
								v-if="controls.TPEQ1___FAMI1FAMILY__.seeMoreIsVisible"
								v-bind="controls.TPEQ1___FAMI1FAMILY__.seeMoreParams"
								v-on="controls.TPEQ1___FAMI1FAMILY__.handlers" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.TPEQ1___TPEQ1TPEQUCOD.isVisible || controls.TPEQ1___TPEQ1NIVEL___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.TPEQ1___TPEQ1TPEQUCOD"
							v-on="controls.TPEQ1___TPEQ1TPEQUCOD.handlers"
							:loading="controls.TPEQ1___TPEQ1TPEQUCOD.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.TPEQ1___TPEQ1TPEQUCOD.props"
								@blur="onBlur(controls.TPEQ1___TPEQ1TPEQUCOD, model.ValTpequcod.value)"
								@change="model.ValTpequcod.fnUpdateValueOnChange" />
						</base-input-structure>
						<base-input-structure
							class="i-text"
							v-bind="controls.TPEQ1___TPEQ1NIVEL___"
							v-on="controls.TPEQ1___TPEQ1NIVEL___.handlers"
							:loading="controls.TPEQ1___TPEQ1NIVEL___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.TPEQ1___TPEQ1NIVEL___.isVisible"
								v-bind="controls.TPEQ1___TPEQ1NIVEL___.props"
								@update:model-value="model.ValNivel.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.TPEQ1___TPEQ1TIPOEQUI.isVisible">
					<q-control-wrapper
						v-show="controls.TPEQ1___TPEQ1TIPOEQUI.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.TPEQ1___TPEQ1TIPOEQUI"
							v-on="controls.TPEQ1___TPEQ1TIPOEQUI.handlers"
							:loading="controls.TPEQ1___TPEQ1TIPOEQUI.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.TPEQ1___TPEQ1TIPOEQUI.props"
								@blur="onBlur(controls.TPEQ1___TPEQ1TIPOEQUI, model.ValTipoequi.value)"
								@change="model.ValTipoequi.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.TPEQ1___TPEQ1TPEQUPAI.isVisible">
					<q-control-wrapper
						v-show="controls.TPEQ1___TPEQ1TPEQUPAI.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.TPEQ1___TPEQ1TPEQUPAI"
							v-on="controls.TPEQ1___TPEQ1TPEQUPAI.handlers"
							:loading="controls.TPEQ1___TPEQ1TPEQUPAI.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.TPEQ1___TPEQ1TPEQUPAI.props"
								@blur="onBlur(controls.TPEQ1___TPEQ1TPEQUPAI, model.ValTpequpai.value)"
								@change="model.ValTpequpai.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.TPEQ1___TPEQ1BACKCOLO.isVisible || controls.TPEQ1___TPEQ1CORLETRA.isVisible">
					<q-control-wrapper
						v-show="controls.TPEQ1___TPEQ1BACKCOLO.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.TPEQ1___TPEQ1BACKCOLO"
							v-on="controls.TPEQ1___TPEQ1BACKCOLO.handlers"
							:loading="controls.TPEQ1___TPEQ1BACKCOLO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.TPEQ1___TPEQ1BACKCOLO.props"
								@blur="onBlur(controls.TPEQ1___TPEQ1BACKCOLO, model.ValBackcolo.value)"
								@change="model.ValBackcolo.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.TPEQ1___TPEQ1CORLETRA.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.TPEQ1___TPEQ1CORLETRA"
							v-on="controls.TPEQ1___TPEQ1CORLETRA.handlers"
							:loading="controls.TPEQ1___TPEQ1CORLETRA.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.TPEQ1___TPEQ1CORLETRA.props"
								@blur="onBlur(controls.TPEQ1___TPEQ1CORLETRA, model.ValCorletra.value)"
								@change="model.ValCorletra.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.TPEQ1___TPEQ1PRECOMAX.isVisible || controls.TPEQ1___TPEQ1PRECOULT.isVisible">
					<q-control-wrapper
						v-show="controls.TPEQ1___TPEQ1PRECOMAX.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.TPEQ1___TPEQ1PRECOMAX"
							v-on="controls.TPEQ1___TPEQ1PRECOMAX.handlers"
							:loading="controls.TPEQ1___TPEQ1PRECOMAX.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.TPEQ1___TPEQ1PRECOMAX.isVisible"
								v-bind="controls.TPEQ1___TPEQ1PRECOMAX.props"
								@update:model-value="model.ValPrecomax.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.TPEQ1___TPEQ1PRECOULT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.TPEQ1___TPEQ1PRECOULT"
							v-on="controls.TPEQ1___TPEQ1PRECOULT.handlers"
							:loading="controls.TPEQ1___TPEQ1PRECOULT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.TPEQ1___TPEQ1PRECOULT.isVisible"
								v-bind="controls.TPEQ1___TPEQ1PRECOULT.props"
								@update:model-value="model.ValPrecoult.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.TPEQ1___TPEQ1SINCE___.isVisible || controls.TPEQ1___TPEQ1QTDEQUIP.isVisible || controls.TPEQ1___TPEQ1KIT_____.isVisible">
					<q-control-wrapper
						v-show="controls.TPEQ1___TPEQ1SINCE___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.TPEQ1___TPEQ1SINCE___"
							v-on="controls.TPEQ1___TPEQ1SINCE___.handlers"
							:loading="controls.TPEQ1___TPEQ1SINCE___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.TPEQ1___TPEQ1SINCE___.isVisible"
								v-bind="controls.TPEQ1___TPEQ1SINCE___.props"
								:model-value="model.ValSince.value"
								@reset-icon-click="model.ValSince.fnUpdateValue(model.ValSince.originalValue ?? new Date())"
								@update:model-value="model.ValSince.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.TPEQ1___TPEQ1QTDEQUIP.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.TPEQ1___TPEQ1QTDEQUIP"
							v-on="controls.TPEQ1___TPEQ1QTDEQUIP.handlers"
							:loading="controls.TPEQ1___TPEQ1QTDEQUIP.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.TPEQ1___TPEQ1QTDEQUIP.isVisible"
								v-bind="controls.TPEQ1___TPEQ1QTDEQUIP.props"
								@update:model-value="model.ValQtdequip.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.TPEQ1___TPEQ1KIT_____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.TPEQ1___TPEQ1KIT_____"
							v-on="controls.TPEQ1___TPEQ1KIT_____.handlers"
							:loading="controls.TPEQ1___TPEQ1KIT_____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox-input
									v-if="controls.TPEQ1___TPEQ1KIT_____.isVisible"
									v-bind="controls.TPEQ1___TPEQ1KIT_____.props"
									v-on="controls.TPEQ1___TPEQ1KIT_____.handlers" />
							</template>
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

	import FormViewModel from './QFormTpeq1ViewModel.js'

	const requiredTextResources = ['QFormTpeq1', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS TPEQ1]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormTpeq1',

		components: {
			QSeeMoreTpeq1Fami1family: defineAsyncComponent(() => import('@/views/forms/FormTpeq1/dbedits/Tpeq1Fami1familySeeMore.vue')),
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
					name: 'TPEQ1',
					location: 'form-TPEQ1',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormTpeq1', false),

				interfaceMetadata: {
					id: 'QFormTpeq1', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'TPEQ1',
					route: 'form-TPEQ1',
					area: 'TPEQ1',
					primaryKey: 'ValCodtpequ',
					designation: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
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
					TPEQ1___FAMI1FAMILY__: new fieldControlClass.LookupControl({
						modelField: 'TableFami1Family',
						valueChangeEvent: 'fieldChange:fami1.family',
						id: 'TPEQ1___FAMI1FAMILY__',
						name: 'FAMILY',
						size: 'xlarge',
						label: computed(() => this.Resources.EQUIPMENT_FAMILY41883),
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
							name: 'ValCodfamil',
							dependencyEvent: 'fieldChange:tpeq1.codfamil'
						},
						dependentFields: () => ({
							set 'fami1.codfamil'(value) { vm.model.ValCodfamil.updateValue(value) },
							set 'fami1.family'(value) { vm.model.TableFami1Family.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					TPEQ1___TPEQ1TPEQUCOD: new fieldControlClass.StringControl({
						modelField: 'ValTpequcod',
						valueChangeEvent: 'fieldChange:tpeq1.tpequcod',
						id: 'TPEQ1___TPEQ1TPEQUCOD',
						name: 'TPEQUCOD',
						size: 'medium',
						label: computed(() => this.Resources.CODE49225),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 20,
						labelId: 'label_TPEQ1___TPEQ1TPEQUCOD',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					TPEQ1___TPEQ1NIVEL___: new fieldControlClass.NumberControl({
						modelField: 'ValNivel',
						valueChangeEvent: 'fieldChange:tpeq1.nivel',
						id: 'TPEQ1___TPEQ1NIVEL___',
						name: 'NIVEL',
						size: 'small',
						label: computed(() => this.Resources.LEVEL_43678),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					TPEQ1___TPEQ1TIPOEQUI: new fieldControlClass.StringControl({
						modelField: 'ValTipoequi',
						valueChangeEvent: 'fieldChange:tpeq1.tipoequi',
						id: 'TPEQ1___TPEQ1TIPOEQUI',
						name: 'TIPOEQUI',
						size: 'xlarge',
						label: computed(() => this.Resources.TYPE_OF_EQUIPMENT64921),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_TPEQ1___TPEQ1TIPOEQUI',
						controlLimits: [
						],
					}, this),
					TPEQ1___TPEQ1TPEQUPAI: new fieldControlClass.StringControl({
						modelField: 'ValTpequpai',
						valueChangeEvent: 'fieldChange:tpeq1.tpequpai',
						id: 'TPEQ1___TPEQ1TPEQUPAI',
						name: 'TPEQUPAI',
						size: 'medium',
						label: computed(() => this.Resources.DEPENDENCE_ON13941),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 20,
						labelId: 'label_TPEQ1___TPEQ1TPEQUPAI',
						controlLimits: [
						],
					}, this),
					TPEQ1___TPEQ1BACKCOLO: new fieldControlClass.StringControl({
						modelField: 'ValBackcolo',
						valueChangeEvent: 'fieldChange:tpeq1.backcolo',
						id: 'TPEQ1___TPEQ1BACKCOLO',
						name: 'BACKCOLO',
						size: 'xlarge',
						label: computed(() => this.Resources.BACKGROUND_COLOR07511),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_TPEQ1___TPEQ1BACKCOLO',
						controlLimits: [
						],
					}, this),
					TPEQ1___TPEQ1CORLETRA: new fieldControlClass.StringControl({
						modelField: 'ValCorletra',
						valueChangeEvent: 'fieldChange:tpeq1.corletra',
						id: 'TPEQ1___TPEQ1CORLETRA',
						name: 'CORLETRA',
						size: 'xlarge',
						label: computed(() => this.Resources.LETTER_COLOR_03195),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_TPEQ1___TPEQ1CORLETRA',
						controlLimits: [
						],
					}, this),
					TPEQ1___TPEQ1PRECOMAX: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrecomax',
						valueChangeEvent: 'fieldChange:tpeq1.precomax',
						id: 'TPEQ1___TPEQ1PRECOMAX',
						name: 'PRECOMAX',
						size: 'medium',
						label: computed(() => this.Resources.MAXIMUM_PRICE26470),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 9,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					TPEQ1___TPEQ1PRECOULT: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrecoult',
						valueChangeEvent: 'fieldChange:tpeq1.precoult',
						id: 'TPEQ1___TPEQ1PRECOULT',
						name: 'PRECOULT',
						size: 'medium',
						label: computed(() => this.Resources.LAST_PRICE25852),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 9,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					TPEQ1___TPEQ1SINCE___: new fieldControlClass.DateControl({
						modelField: 'ValSince',
						valueChangeEvent: 'fieldChange:tpeq1.since',
						id: 'TPEQ1___TPEQ1SINCE___',
						name: 'SINCE',
						size: 'medium',
						label: computed(() => this.Resources.IN34902),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'dateTime',
						controlLimits: [
						],
					}, this),
					TPEQ1___TPEQ1QTDEQUIP: new fieldControlClass.NumberControl({
						modelField: 'ValQtdequip',
						valueChangeEvent: 'fieldChange:tpeq1.qtdequip',
						id: 'TPEQ1___TPEQ1QTDEQUIP',
						name: 'QTDEQUIP',
						size: 'small',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources.____615950),
							},
						},
						label: computed(() => this.Resources.QUANTITY06415),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 6,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					TPEQ1___TPEQ1KIT_____: new fieldControlClass.BooleanControl({
						modelField: 'ValKit',
						valueChangeEvent: 'fieldChange:tpeq1.kit',
						id: 'TPEQ1___TPEQ1KIT_____',
						name: 'KIT',
						size: 'mini',
						label: computed(() => this.Resources.KIT27179),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
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
					Fami1: {
						get ValFamily() { return vm.model.TableFami1Family.value },
						set ValFamily(value) { vm.model.TableFami1Family.updateValue(value) },
					},
					Tpeq1: {
						get ValBackcolo() { return vm.model.ValBackcolo.value },
						set ValBackcolo(value) { vm.model.ValBackcolo.updateValue(value) },
						get ValCodfamil() { return vm.model.ValCodfamil.value },
						set ValCodfamil(value) { vm.model.ValCodfamil.updateValue(value) },
						get ValCorletra() { return vm.model.ValCorletra.value },
						set ValCorletra(value) { vm.model.ValCorletra.updateValue(value) },
						get ValKit() { return vm.model.ValKit.value },
						set ValKit(value) { vm.model.ValKit.updateValue(value) },
						get ValNivel() { return vm.model.ValNivel.value },
						set ValNivel(value) { vm.model.ValNivel.updateValue(value) },
						get ValPrecomax() { return vm.model.ValPrecomax.value },
						set ValPrecomax(value) { vm.model.ValPrecomax.updateValue(value) },
						get ValPrecoult() { return vm.model.ValPrecoult.value },
						set ValPrecoult(value) { vm.model.ValPrecoult.updateValue(value) },
						get ValQtdequip() { return vm.model.ValQtdequip.value },
						set ValQtdequip(value) { vm.model.ValQtdequip.updateValue(value) },
						get ValSince() { return vm.model.ValSince.value },
						set ValSince(value) { vm.model.ValSince.updateValue(value) },
						get ValTipoequi() { return vm.model.ValTipoequi.value },
						set ValTipoequi(value) { vm.model.ValTipoequi.updateValue(value) },
						get ValTpequcod() { return vm.model.ValTpequcod.value },
						set ValTpequcod(value) { vm.model.ValTpequcod.updateValue(value) },
						get ValTpequpai() { return vm.model.ValTpequpai.value },
						set ValTpequpai(value) { vm.model.ValTpequpai.updateValue(value) },
					},
					keys: {
						/** The primary key of the TPEQ1 table */
						get tpeq1() { return vm.model.ValCodtpequ },
						/** The foreign key to the FAMI1 table */
						get fami1() { return vm.model.ValCodfamil },
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
// USE /[MANUAL GQT FORM_CODEJS TPEQ1]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT TPEQ1]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS TPEQ1]/
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
// USE /[MANUAL GQT FORM_LOADED_JS TPEQ1]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS TPEQ1]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS TPEQ1]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS TPEQ1]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS TPEQ1]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS TPEQ1]/
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
// USE /[MANUAL GQT AFTER_DEL_JS TPEQ1]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS TPEQ1]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS TPEQ1]/
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
// USE /[MANUAL GQT DLGUPDT TPEQ1]/
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
// USE /[MANUAL GQT CTRLBLR TPEQ1]/
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
// USE /[MANUAL GQT CTRLUPD TPEQ1]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS TPEQ1]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
