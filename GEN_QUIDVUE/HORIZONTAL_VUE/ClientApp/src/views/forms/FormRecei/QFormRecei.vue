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
			data-key="RECEI"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.RECEI___RECEIDTRECEIP.isVisible || controls.RECEI___RECEINUMBER__.isVisible || controls.RECEI___ENTITNAME____.isVisible">
					<q-control-wrapper
						v-show="controls.RECEI___RECEIDTRECEIP.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.RECEI___RECEIDTRECEIP"
							v-on="controls.RECEI___RECEIDTRECEIP.handlers"
							:loading="controls.RECEI___RECEIDTRECEIP.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.RECEI___RECEIDTRECEIP.isVisible"
								v-bind="controls.RECEI___RECEIDTRECEIP.props"
								:model-value="model.ValDtreceip.value"
								@reset-icon-click="model.ValDtreceip.fnUpdateValue(model.ValDtreceip.originalValue ?? new Date())"
								@update:model-value="model.ValDtreceip.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.RECEI___RECEINUMBER__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.RECEI___RECEINUMBER__"
							v-on="controls.RECEI___RECEINUMBER__.handlers"
							:loading="controls.RECEI___RECEINUMBER__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.RECEI___RECEINUMBER__.isVisible"
								v-bind="controls.RECEI___RECEINUMBER__.props"
								@update:model-value="model.ValNumber.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.RECEI___ENTITNAME____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.RECEI___ENTITNAME____"
							v-on="controls.RECEI___ENTITNAME____.handlers"
							:loading="controls.RECEI___ENTITNAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.RECEI___ENTITNAME____.isVisible"
								v-bind="controls.RECEI___ENTITNAME____.props"
								v-on="controls.RECEI___ENTITNAME____.handlers" />
							<q-see-more-recei-entitname
								v-if="controls.RECEI___ENTITNAME____.seeMoreIsVisible"
								v-bind="controls.RECEI___ENTITNAME____.seeMoreParams"
								v-on="controls.RECEI___ENTITNAME____.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.RECEI___PSEUDRECEIPTL.isVisible || controls.RECEI___RECEIDTCHECK_.isVisible">
					<q-control-wrapper
						v-show="controls.RECEI___PSEUDRECEIPTL.isVisible"
						class="control-join-group">
						<q-table
							v-show="controls.RECEI___PSEUDRECEIPTL.isVisible"
							v-bind="controls.RECEI___PSEUDRECEIPTL"
							v-on="controls.RECEI___PSEUDRECEIPTL.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.RECEI___PSEUDRECEIPTL"
							v-on="controls.RECEI___PSEUDRECEIPTL.handlers" />
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.RECEI___RECEIDTCHECK_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.RECEI___RECEIDTCHECK_"
							v-on="controls.RECEI___RECEIDTCHECK_.handlers"
							:loading="controls.RECEI___RECEIDTCHECK_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.RECEI___RECEIDTCHECK_.isVisible"
								v-bind="controls.RECEI___RECEIDTCHECK_.props"
								:model-value="model.ValDtcheck.value"
								@reset-icon-click="model.ValDtcheck.fnUpdateValue(model.ValDtcheck.originalValue ?? new Date())"
								@update:model-value="model.ValDtcheck.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.RECEI___RECEITOCHECK_.isVisible">
					<q-control-wrapper
						v-show="controls.RECEI___RECEITOCHECK_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.RECEI___RECEITOCHECK_"
							v-on="controls.RECEI___RECEITOCHECK_.handlers"
							:loading="controls.RECEI___RECEITOCHECK_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox-input
									v-if="controls.RECEI___RECEITOCHECK_.isVisible"
									v-bind="controls.RECEI___RECEITOCHECK_.props"
									@update:model-value="model.ValTocheck.fnUpdateValue" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.RECEI___RECEICHECKED_.isVisible">
					<q-control-wrapper
						v-show="controls.RECEI___RECEICHECKED_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.RECEI___RECEICHECKED_"
							v-on="controls.RECEI___RECEICHECKED_.handlers"
							:loading="controls.RECEI___RECEICHECKED_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox-input
									v-if="controls.RECEI___RECEICHECKED_.isVisible"
									v-bind="controls.RECEI___RECEICHECKED_.props"
									@update:model-value="model.ValChecked.fnUpdateValue" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.RECEI___RECEISTORED__.isVisible || controls.RECEI___RECEIDTSTORAG.isVisible">
					<q-control-wrapper
						v-show="controls.RECEI___RECEISTORED__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.RECEI___RECEISTORED__"
							v-on="controls.RECEI___RECEISTORED__.handlers"
							:loading="controls.RECEI___RECEISTORED__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox-input
									v-if="controls.RECEI___RECEISTORED__.isVisible"
									v-bind="controls.RECEI___RECEISTORED__.props"
									@update:model-value="model.ValStored.fnUpdateValue" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.RECEI___RECEIDTSTORAG.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.RECEI___RECEIDTSTORAG"
							v-on="controls.RECEI___RECEIDTSTORAG.handlers"
							:loading="controls.RECEI___RECEIDTSTORAG.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.RECEI___RECEIDTSTORAG.isVisible"
								v-bind="controls.RECEI___RECEIDTSTORAG.props"
								:model-value="model.ValDtstorag.value"
								@reset-icon-click="model.ValDtstorag.fnUpdateValue(model.ValDtstorag.originalValue ?? new Date())"
								@update:model-value="model.ValDtstorag.fnUpdateValue($event ?? '')" />
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

	import FormViewModel from './QFormReceiViewModel.js'

	const requiredTextResources = ['QFormRecei', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS RECEI]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormRecei',

		components: {
			QSeeMoreReceiEntitname: defineAsyncComponent(() => import('@/views/forms/FormRecei/dbedits/ReceiEntitnameSeeMore.vue')),
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
					name: 'RECEI',
					location: 'form-RECEI',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormRecei', false),

				interfaceMetadata: {
					id: 'QFormRecei', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'RECEI',
					route: 'form-RECEI',
					area: 'RECEI',
					primaryKey: 'ValCodrecei',
					designation: computed(() => this.Resources.RECEIPT_OF_GOOD16561),
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
						text: computed(() => vm.Resources.SAVE_AND_RETURN63386),
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
					RECEI___RECEIDTRECEIP: new fieldControlClass.DateControl({
						modelField: 'ValDtreceip',
						valueChangeEvent: 'fieldChange:recei.dtreceip',
						id: 'RECEI___RECEIDTRECEIP',
						name: 'DTRECEIP',
						size: 'medium',
						label: computed(() => this.Resources.RECEIPT_DATE00996),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						format: 'dateTime',
						controlLimits: [
						],
					}, this),
					RECEI___RECEINUMBER__: new fieldControlClass.NumberControl({
						modelField: 'ValNumber',
						valueChangeEvent: 'fieldChange:recei.number',
						id: 'RECEI___RECEINUMBER__',
						name: 'NUMBER',
						size: 'small',
						label: computed(() => this.Resources.RECEIPT_NUMBER31380),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 10,
						maxDecimals: 0,
						isSequencial: true,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					RECEI___ENTITNAME____: new fieldControlClass.LookupControl({
						modelField: 'TableEntitName',
						valueChangeEvent: 'fieldChange:entit.name',
						id: 'RECEI___ENTITNAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.SUPLIER38140),
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
							name: 'ValCodentit',
							dependencyEvent: 'fieldChange:recei.codentit'
						},
						dependentFields: () => ({
							set 'entit.codentit'(value) { vm.model.ValCodentit.updateValue(value) },
							set 'entit.name'(value) { vm.model.TableEntitName.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					RECEI___PSEUDRECEIPTL: new fieldControlClass.TableListControl({
						id: 'RECEI___PSEUDRECEIPTL',
						name: 'RECEIPTL',
						size: '',
						label: computed(() => this.Resources.RECEIPT_LINES14292),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'RECEI',
						action: 'Recei_ValReceiptl',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.NumericColumn({
								order: 1,
								name: 'ValLinenumb',
								area: 'RELIN',
								field: 'LINENUMB',
								label: computed(() => this.Resources.LINE27983),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'Produ.ValSku',
								area: 'PRODU',
								field: 'SKU',
								label: computed(() => this.Resources.SKU42303),
								dataLength: 20,
								scrollData: 20,
								pkColumn: 'ValCodprodu',
							}),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'Produ.ValGtin',
								area: 'PRODU',
								field: 'GTIN',
								label: computed(() => this.Resources.GTIN45487),
								dataLength: 14,
								scrollData: 14,
								visibility: false,
								pkColumn: 'ValCodprodu',
							}),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'Produ.ValProduct',
								area: 'PRODU',
								field: 'PRODUCT',
								label: computed(() => this.Resources.PRODUCT12880),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodprodu',
							}),
							new listColumnTypes.NumericColumn({
								order: 5,
								name: 'ValOrdered',
								area: 'RELIN',
								field: 'ORDERED',
								label: computed(() => this.Resources.ORDERED04034),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 6,
								name: 'ValReceived',
								area: 'RELIN',
								field: 'RECEIVED',
								label: computed(() => this.Resources.RECEIVED19242),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 7,
								name: 'ValOutstand',
								area: 'RELIN',
								field: 'OUTSTAND',
								label: computed(() => this.Resources.OUTSTANDING36400),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
						],
						config: {
							name: 'ValReceiptl',
							serverMode: true,
							pkColumn: 'ValCoddilin',
							tableAlias: 'RELIN',
							tableNamePlural: computed(() => this.Resources.RECEIPT_LINES14292),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.RECEIPT_LINES14292),
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
										formName: 'RELIN',
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
										formName: 'RELIN',
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
										formName: 'RELIN',
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
										formName: 'RELIN',
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
										formName: 'RELIN',
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
							],
							MCActions: [
							],
							rowClickAction: {
								id: 'RCA__RELIN',
								name: '_RELIN',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'RELIN',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'RELIN': {
									fnKeySelector: (row) => row.Fields.ValCoddilin,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValLinenumb',
							defaultSearchColumnNameOriginal: 'ValLinenumb',
							defaultColumnSorting: {
								columnName: 'ValLinenumb',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-PRODU', 'changed-RELIN', 'changed-ENTIT', 'changed-RECEI'],
						uuid: 'Recei_ValReceiptl',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'recei'],
								dependencyEvents: ['fieldChange:recei.codrecei'],
								dependencyField: 'RECEI.CODRECEI',
								fnValueSelector: (model) => model.ValCodrecei.value
							},
						],
					}, this),
					RECEI___RECEIDTCHECK_: new fieldControlClass.DateControl({
						modelField: 'ValDtcheck',
						valueChangeEvent: 'fieldChange:recei.dtcheck',
						id: 'RECEI___RECEIDTCHECK_',
						name: 'DTCHECK',
						size: 'medium',
						label: computed(() => this.Resources.RECEIPT_VERIFICATION62328),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						format: 'dateTime',
						controlLimits: [
						],
					}, this),
					RECEI___RECEITOCHECK_: new fieldControlClass.BooleanControl({
						modelField: 'ValTocheck',
						valueChangeEvent: 'fieldChange:recei.tocheck',
						id: 'RECEI___RECEITOCHECK_',
						name: 'TOCHECK',
						size: 'small',
						label: computed(() => this.Resources.TO_CHECK57511),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						isFormulaBlocked: true,
						controlLimits: [
						],
					}, this),
					RECEI___RECEICHECKED_: new fieldControlClass.BooleanControl({
						modelField: 'ValChecked',
						valueChangeEvent: 'fieldChange:recei.checked',
						id: 'RECEI___RECEICHECKED_',
						name: 'CHECKED',
						size: 'small',
						label: computed(() => this.Resources.CHECKED31708),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						isFormulaBlocked: true,
						controlLimits: [
						],
					}, this),
					RECEI___RECEISTORED__: new fieldControlClass.BooleanControl({
						modelField: 'ValStored',
						valueChangeEvent: 'fieldChange:recei.stored',
						id: 'RECEI___RECEISTORED__',
						name: 'STORED',
						size: 'mini',
						label: computed(() => this.Resources.STORED41854),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						controlLimits: [
						],
					}, this),
					RECEI___RECEIDTSTORAG: new fieldControlClass.DateControl({
						modelField: 'ValDtstorag',
						valueChangeEvent: 'fieldChange:recei.dtstorag',
						id: 'RECEI___RECEIDTSTORAG',
						name: 'DTSTORAG',
						size: 'medium',
						label: computed(() => this.Resources.STORAGE_DATE59954),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						format: 'dateTime',
						controlLimits: [
						],
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: emptyL( [RECEI->STORED] )==0
								return qApi.emptyL((this.ValStored.value ? 1 : 0))===0
							},
							dependencyEvents: ['fieldChange:recei.stored'],
							isServerRecalc: false,
						},
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
					'RECEI___PSEUDRECEIPTL',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Entit: {
						get ValName() { return vm.model.TableEntitName.value },
						set ValName(value) { vm.model.TableEntitName.updateValue(value) },
					},
					Recei: {
						get ValChecked() { return vm.model.ValChecked.value },
						set ValChecked(value) { vm.model.ValChecked.updateValue(value) },
						get ValCodentit() { return vm.model.ValCodentit.value },
						set ValCodentit(value) { vm.model.ValCodentit.updateValue(value) },
						get ValDtcheck() { return vm.model.ValDtcheck.value },
						set ValDtcheck(value) { vm.model.ValDtcheck.updateValue(value) },
						get ValDtreceip() { return vm.model.ValDtreceip.value },
						set ValDtreceip(value) { vm.model.ValDtreceip.updateValue(value) },
						get ValDtstorag() { return vm.model.ValDtstorag.value },
						set ValDtstorag(value) { vm.model.ValDtstorag.updateValue(value) },
						get ValNumber() { return vm.model.ValNumber.value },
						set ValNumber(value) { vm.model.ValNumber.updateValue(value) },
						get ValStored() { return vm.model.ValStored.value },
						set ValStored(value) { vm.model.ValStored.updateValue(value) },
						get ValTocheck() { return vm.model.ValTocheck.value },
						set ValTocheck(value) { vm.model.ValTocheck.updateValue(value) },
					},
					keys: {
						/** The primary key of the RECEI table */
						get recei() { return vm.model.ValCodrecei },
						/** The foreign key to the ENTIT table */
						get entit() { return vm.model.ValCodentit },
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
// USE /[MANUAL GQT FORM_CODEJS RECEI]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS RECEI]/
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
// USE /[MANUAL GQT FORM_LOADED_JS RECEI]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS RECEI]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS RECEI]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS RECEI]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS RECEI]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS RECEI]/
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
// USE /[MANUAL GQT AFTER_DEL_JS RECEI]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS RECEI]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS RECEI]/
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
// USE /[MANUAL GQT DLGUPDT RECEI]/
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
// USE /[MANUAL GQT CTRLBLR RECEI]/
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
// USE /[MANUAL GQT CTRLUPD RECEI]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS RECEI]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
