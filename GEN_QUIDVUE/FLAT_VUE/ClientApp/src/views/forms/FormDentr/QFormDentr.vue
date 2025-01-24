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
			data-key="DENTR"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.DENTR___CNTRYCOUNTRY_.isVisible">
					<q-control-wrapper
						v-show="controls.DENTR___CNTRYCOUNTRY_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.DENTR___CNTRYCOUNTRY_"
							v-on="controls.DENTR___CNTRYCOUNTRY_.handlers"
							:loading="controls.DENTR___CNTRYCOUNTRY_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.DENTR___CNTRYCOUNTRY_.isVisible"
								v-bind="controls.DENTR___CNTRYCOUNTRY_.props"
								v-on="controls.DENTR___CNTRYCOUNTRY_.handlers" />
							<q-see-more-dentr-cntrycountry
								v-if="controls.DENTR___CNTRYCOUNTRY_.seeMoreIsVisible"
								v-bind="controls.DENTR___CNTRYCOUNTRY_.seeMoreParams"
								v-on="controls.DENTR___CNTRYCOUNTRY_.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.DENTR___CMPNYDESIGNAT.isVisible">
					<q-control-wrapper
						v-show="controls.DENTR___CMPNYDESIGNAT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.DENTR___CMPNYDESIGNAT"
							v-on="controls.DENTR___CMPNYDESIGNAT.handlers"
							:loading="controls.DENTR___CMPNYDESIGNAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.DENTR___CMPNYDESIGNAT.isVisible"
								v-bind="controls.DENTR___CMPNYDESIGNAT.props"
								v-on="controls.DENTR___CMPNYDESIGNAT.handlers" />
							<q-see-more-dentr-cmpnydesignat
								v-if="controls.DENTR___CMPNYDESIGNAT.seeMoreIsVisible"
								v-bind="controls.DENTR___CMPNYDESIGNAT.seeMoreParams"
								v-on="controls.DENTR___CMPNYDESIGNAT.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.DENTR___PESSONAME____.isVisible">
					<q-control-wrapper
						v-show="controls.DENTR___PESSONAME____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.DENTR___PESSONAME____"
							v-on="controls.DENTR___PESSONAME____.handlers"
							:loading="controls.DENTR___PESSONAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.DENTR___PESSONAME____.isVisible"
								v-bind="controls.DENTR___PESSONAME____.props"
								v-on="controls.DENTR___PESSONAME____.handlers" />
							<q-see-more-dentr-pessoname
								v-if="controls.DENTR___PESSONAME____.seeMoreIsVisible"
								v-bind="controls.DENTR___PESSONAME____.seeMoreParams"
								v-on="controls.DENTR___PESSONAME____.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.DENTR___WARE1WAREHDES.isVisible">
					<q-control-wrapper
						v-show="controls.DENTR___WARE1WAREHDES.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.DENTR___WARE1WAREHDES"
							v-on="controls.DENTR___WARE1WAREHDES.handlers"
							:loading="controls.DENTR___WARE1WAREHDES.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.DENTR___WARE1WAREHDES.isVisible"
								v-bind="controls.DENTR___WARE1WAREHDES.props"
								v-on="controls.DENTR___WARE1WAREHDES.handlers" />
							<q-see-more-dentr-ware1warehdes
								v-if="controls.DENTR___WARE1WAREHDES.seeMoreIsVisible"
								v-bind="controls.DENTR___WARE1WAREHDES.seeMoreParams"
								v-on="controls.DENTR___WARE1WAREHDES.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.DENTR___INDOCDATE____.isVisible">
					<q-control-wrapper
						v-show="controls.DENTR___INDOCDATE____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.DENTR___INDOCDATE____"
							v-on="controls.DENTR___INDOCDATE____.handlers"
							:loading="controls.DENTR___INDOCDATE____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.DENTR___INDOCDATE____.isVisible"
								v-bind="controls.DENTR___INDOCDATE____.props"
								:model-value="model.ValDate.value"
								@reset-icon-click="model.ValDate.fnUpdateValue(model.ValDate.originalValue ?? new Date())"
								@update:model-value="model.ValDate.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.DENTR___INDOCDOCUMENR.isVisible">
					<q-control-wrapper
						v-show="controls.DENTR___INDOCDOCUMENR.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.DENTR___INDOCDOCUMENR"
							v-on="controls.DENTR___INDOCDOCUMENR.handlers"
							:loading="controls.DENTR___INDOCDOCUMENR.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.DENTR___INDOCDOCUMENR.isVisible"
								v-bind="controls.DENTR___INDOCDOCUMENR.props"
								@update:model-value="model.ValDocumenr.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.DENTR___INDOCDHDOCUME.isVisible">
					<q-control-wrapper
						v-show="controls.DENTR___INDOCDHDOCUME.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.DENTR___INDOCDHDOCUME"
							v-on="controls.DENTR___INDOCDHDOCUME.handlers"
							:loading="controls.DENTR___INDOCDHDOCUME.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.DENTR___INDOCDHDOCUME.isVisible"
								v-bind="controls.DENTR___INDOCDHDOCUME.props"
								:model-value="model.ValDhdocume.value"
								@reset-icon-click="model.ValDhdocume.fnUpdateValue(model.ValDhdocume.originalValue ?? new Date())"
								@update:model-value="model.ValDhdocume.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.DENTR___PSEUDENTRADAS.isVisible">
					<q-control-wrapper
						v-show="controls.DENTR___PSEUDENTRADAS.isVisible"
						class="control-join-group">
						<q-table
							v-show="controls.DENTR___PSEUDENTRADAS.isVisible"
							v-bind="controls.DENTR___PSEUDENTRADAS"
							v-on="controls.DENTR___PSEUDENTRADAS.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.DENTR___PSEUDENTRADAS"
							v-on="controls.DENTR___PSEUDENTRADAS.handlers" />
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

	import FormViewModel from './QFormDentrViewModel.js'

	const requiredTextResources = ['QFormDentr', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS DENTR]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormDentr',

		components: {
			QSeeMoreDentrCntrycountry: defineAsyncComponent(() => import('@/views/forms/FormDentr/dbedits/DentrCntrycountrySeeMore.vue')),
			QSeeMoreDentrCmpnydesignat: defineAsyncComponent(() => import('@/views/forms/FormDentr/dbedits/DentrCmpnydesignatSeeMore.vue')),
			QSeeMoreDentrPessoname: defineAsyncComponent(() => import('@/views/forms/FormDentr/dbedits/DentrPessonameSeeMore.vue')),
			QSeeMoreDentrWare1warehdes: defineAsyncComponent(() => import('@/views/forms/FormDentr/dbedits/DentrWare1warehdesSeeMore.vue')),
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
					name: 'DENTR',
					location: 'form-DENTR',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormDentr', false),

				interfaceMetadata: {
					id: 'QFormDentr', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'DENTR',
					route: 'form-DENTR',
					area: 'INDOC',
					primaryKey: 'ValCoddentr',
					designation: computed(() => this.Resources.INPUT_DOCUMENT28194),
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
					DENTR___CNTRYCOUNTRY_: new fieldControlClass.LookupControl({
						modelField: 'TableCntryCountry',
						valueChangeEvent: 'fieldChange:cntry.country',
						id: 'DENTR___CNTRYCOUNTRY_',
						name: 'COUNTRY',
						size: 'large',
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
							name: 'ValCodcntry',
							dependencyEvent: 'fieldChange:indoc.codcntry'
						},
						dependentFields: () => ({
							set 'cntry.codcntry'(value) { vm.model.ValCodcntry.updateValue(value) },
							set 'cntry.country'(value) { vm.model.TableCntryCountry.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					DENTR___CMPNYDESIGNAT: new fieldControlClass.LookupControl({
						modelField: 'TableCmpnyDesignat',
						valueChangeEvent: 'fieldChange:cmpny.designat',
						id: 'DENTR___CMPNYDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.COMPANY52963),
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
							name: 'ValCodempre',
							dependencyEvent: 'fieldChange:indoc.codempre'
						},
						dependentFields: () => ({
							set 'cmpny.codempre'(value) { vm.model.ValCodempre.updateValue(value) },
							set 'cmpny.designat'(value) { vm.model.TableCmpnyDesignat.updateValue(value) },
						}),
						controlLimits: [
							{
								identifier: ['cntry', 'indoc.codcntry'],
								dependencyEvents: ['fieldChange:indoc.codcntry'],
								dependencyField: 'INDOC.CODCNTRY',
								fnValueSelector: (model) => model.ValCodcntry.value
							},
						],
					}, this),
					DENTR___PESSONAME____: new fieldControlClass.LookupControl({
						modelField: 'TablePessoName',
						valueChangeEvent: 'fieldChange:pesso.name',
						id: 'DENTR___PESSONAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.PERSON10446),
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
							name: 'ValCodpesso',
							dependencyEvent: 'fieldChange:indoc.codpesso'
						},
						dependentFields: () => ({
							set 'pesso.codpesso'(value) { vm.model.ValCodpesso.updateValue(value) },
							set 'pesso.name'(value) { vm.model.TablePessoName.updateValue(value) },
						}),
						controlLimits: [
							{
								identifier: ['cntry', 'indoc.codcntry'],
								dependencyEvents: ['fieldChange:indoc.codcntry'],
								dependencyField: 'INDOC.CODCNTRY',
								fnValueSelector: (model) => model.ValCodcntry.value
							},
							{
								identifier: ['cmpny', 'indoc.codempre'],
								dependencyEvents: ['fieldChange:indoc.codempre'],
								dependencyField: 'INDOC.CODEMPRE',
								fnValueSelector: (model) => model.ValCodempre.value
							},
						],
					}, this),
					DENTR___WARE1WAREHDES: new fieldControlClass.LookupControl({
						modelField: 'TableWare1Warehdes',
						valueChangeEvent: 'fieldChange:ware1.warehdes',
						id: 'DENTR___WARE1WAREHDES',
						name: 'WAREHDES',
						size: 'xlarge',
						label: computed(() => this.Resources.WAREHOUSE51864),
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
							name: 'ValCodwareh',
							dependencyEvent: 'fieldChange:indoc.codwareh'
						},
						dependentFields: () => ({
							set 'ware1.codwareh'(value) { vm.model.ValCodwareh.updateValue(value) },
							set 'ware1.warehdes'(value) { vm.model.TableWare1Warehdes.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					DENTR___INDOCDATE____: new fieldControlClass.DateControl({
						modelField: 'ValDate',
						valueChangeEvent: 'fieldChange:indoc.date',
						id: 'DENTR___INDOCDATE____',
						name: 'DATE',
						size: 'medium',
						label: computed(() => this.Resources.DATE18475),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						format: 'dateTime',
						controlLimits: [
						],
					}, this),
					DENTR___INDOCDOCUMENR: new fieldControlClass.NumberControl({
						modelField: 'ValDocumenr',
						valueChangeEvent: 'fieldChange:indoc.documenr',
						id: 'DENTR___INDOCDOCUMENR',
						name: 'DOCUMENR',
						size: 'small',
						label: computed(() => this.Resources.NO_14817),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 10,
						maxDecimals: 0,
						isSequencial: true,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					DENTR___INDOCDHDOCUME: new fieldControlClass.DateControl({
						modelField: 'ValDhdocume',
						valueChangeEvent: 'fieldChange:indoc.dhdocume',
						id: 'DENTR___INDOCDHDOCUME',
						name: 'DHDOCUME',
						size: 'medium',
						label: computed(() => this.Resources.DATE18475),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						format: 'dateTime',
						controlLimits: [
						],
					}, this),
					DENTR___PSEUDENTRADAS: new fieldControlClass.TableListControl({
						id: 'DENTR___PSEUDENTRADAS',
						name: 'ENTRADAS',
						size: '',
						label: computed(() => this.Resources.ENTRIES32319),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'INDOC',
						action: 'Dentr_ValEntradas',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.NumericColumn({
								order: 1,
								name: 'ValLine',
								area: 'LDENT',
								field: 'LINE',
								label: computed(() => this.Resources.LINE27983),
								scrollData: 5,
								maxDigits: 3,
								decimalPlaces: 1,
								isOrderingColumn: true,
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'Wareh.ValWarehdes',
								area: 'WAREH',
								field: 'WAREHDES',
								label: computed(() => this.Resources.WAREHOUSE51864),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodwareh',
							}),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'Item.ValItemdes',
								area: 'ITEM',
								field: 'ITEMDES',
								label: computed(() => this.Resources.ARTICLE60065),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCoditem',
							}),
							new listColumnTypes.NumericColumn({
								order: 4,
								name: 'ValQtdentra',
								area: 'LDENT',
								field: 'QTDENTRA',
								label: computed(() => this.Resources.QTD_ENTRY35144),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
							new listColumnTypes.DateColumn({
								order: 5,
								name: 'ValDhentra',
								area: 'LDENT',
								field: 'DHENTRA',
								label: computed(() => this.Resources.INSTANT_ENTRANCE27379),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
						],
						config: {
							name: 'ValEntradas',
							serverMode: true,
							pkColumn: 'ValCodldent',
							tableAlias: 'LDENT',
							tableNamePlural: computed(() => this.Resources.ENTRIES32319),
							viewManagement: '',
							sortByField: true,
							showRowDragAndDropOption: true,
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.ENTRIES32319),
							perPage: -1,
							pagination: false,
							showAlternatePagination: true,
							rowClickActionInternal: 'selectMultiple',
							showRowsSelectedCount: true,
							showRowsSelectedTotalizer: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: true,
								searchOnPressEnter: true
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
										formName: 'LDENT',
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
										formName: 'LDENT',
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
										formName: 'LDENT',
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
										formName: 'LDENT',
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
										formName: 'LDENT',
										mode: 'NEW',
										repeatInsertion: true,
										isControlled: true
									}
								},
							],
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
								{
									id: 'BE_NORMAL',
									name: 'NORMAL',
									title: computed(() => this.Resources.NORMAL_FORM03650),
									isInReadOnly: true,
									isVisible: computed(() => vm.controls.DENTR___PSEUDNORMAL__.isVisible),
									disabled: computed(() => vm.controls.DENTR___PSEUDNORMAL__.isBlocked),
									params: {
										action: (c, o, d) => vm.controls.DENTR___PSEUDNORMAL__.action(d || c),
										isControlled: true,
										isRoute: true
									}
								},
							],
							MCActions: [
							],
							rowClickAction: {
								id: 'RCA__LDENT',
								name: '_LDENT',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'LDENT',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'LDENT': {
									fnKeySelector: (row) => row.Fields.ValCodldent,
									isPopup: true
								},
								'LDENTNOR': {
									fnKeySelector: (row) => row.Fields.ValCodldent,
									isPopup: false
								},
							},
							allowFileExport: true,
							defaultSearchColumnName: 'ValLine',
							defaultSearchColumnNameOriginal: 'ValLine',
							defaultColumnSorting: {
								columnName: 'ValLine',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-WAREH', 'changed-LDENT', 'changed-ITEM', 'changed-INDOC'],
						uuid: 'Dentr_ValEntradas',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'indoc'],
								dependencyEvents: ['fieldChange:indoc.coddentr'],
								dependencyField: 'INDOC.CODDENTR',
								fnValueSelector: (model) => model.ValCoddentr.value
							},
						],
					}, this),
					DENTR___PSEUDNORMAL__: new fieldControlClass.ButtonControl({
						id: 'DENTR___PSEUDNORMAL__',
						name: 'NORMAL',
						size: 'small',
						hasLabel: false,
						label: computed(() => this.Resources.NORMAL_FORM03650),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						// eslint-disable-next-line
						action: (event) => {
							let btnAction = () => {
								const params = {
									id: event?.rowKey,
									mode: vm.formInfo.mode,
									modes: 'vedai',
									isControlled: true,
									extraData: JSON.stringify(event)
								}

								vm.navigateToForm('LDENTNOR', params.mode, event?.rowKey, params)
							}
							let options = {
								form: 'DENTR',
								callback: btnAction
							}
							vm.$eventHub.emit('form-apply', options)
						},
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
					'DENTR___PSEUDENTRADAS',
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
					Indoc: {
						get ValCodcntry() { return vm.model.ValCodcntry.value },
						set ValCodcntry(value) { vm.model.ValCodcntry.updateValue(value) },
						get ValCodempre() { return vm.model.ValCodempre.value },
						set ValCodempre(value) { vm.model.ValCodempre.updateValue(value) },
						get ValCodpesso() { return vm.model.ValCodpesso.value },
						set ValCodpesso(value) { vm.model.ValCodpesso.updateValue(value) },
						get ValCodwareh() { return vm.model.ValCodwareh.value },
						set ValCodwareh(value) { vm.model.ValCodwareh.updateValue(value) },
						get ValDate() { return vm.model.ValDate.value },
						set ValDate(value) { vm.model.ValDate.updateValue(value) },
						get ValDhdocume() { return vm.model.ValDhdocume.value },
						set ValDhdocume(value) { vm.model.ValDhdocume.updateValue(value) },
						get ValDocumenr() { return vm.model.ValDocumenr.value },
						set ValDocumenr(value) { vm.model.ValDocumenr.updateValue(value) },
					},
					Pesso: {
						get ValName() { return vm.model.TablePessoName.value },
						set ValName(value) { vm.model.TablePessoName.updateValue(value) },
					},
					Ware1: {
						get ValWarehdes() { return vm.model.TableWare1Warehdes.value },
						set ValWarehdes(value) { vm.model.TableWare1Warehdes.updateValue(value) },
					},
					keys: {
						/** The primary key of the INDOC table */
						get indoc() { return vm.model.ValCoddentr },
						/** The foreign key to the CNTRY table */
						get cntry() { return vm.model.ValCodcntry },
						/** The foreign key to the CMPNY table */
						get cmpny() { return vm.model.ValCodempre },
						/** The foreign key to the PESSO table */
						get pesso() { return vm.model.ValCodpesso },
						/** The foreign key to the WARE1 table */
						get ware1() { return vm.model.ValCodwareh },
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
// USE /[MANUAL GQT FORM_CODEJS DENTR]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS DENTR]/
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
// USE /[MANUAL GQT FORM_LOADED_JS DENTR]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS DENTR]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS DENTR]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS DENTR]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS DENTR]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS DENTR]/
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
// USE /[MANUAL GQT AFTER_DEL_JS DENTR]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS DENTR]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS DENTR]/
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
// USE /[MANUAL GQT DLGUPDT DENTR]/
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
// USE /[MANUAL GQT CTRLBLR DENTR]/
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
// USE /[MANUAL GQT CTRLUPD DENTR]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS DENTR]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
