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
				<component
					v-if="formControl.uiComponents.header && formInfo.designation"
					:is="topHeadingTag"
					:id="formTitleId"
					class="form-header">
					{{ formInfo.designation }}
				</component>

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
											:enabled="btn.badge?.isVisible ?? false"
											:color="btn.badge?.color">
											<q-icon v-bind="btn.icon" />
										</q-badge-indicator>
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
			data-key="ARMAPESS"
			:data-identifier="primaryKeyValue"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.ARMAPESSWPESSNFUNC___.isVisible">
					<q-col
						v-if="controls.ARMAPESSWPESSNFUNC___.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ARMAPESSWPESSNFUNC___.isVisible"
							class="i-text"
							v-bind="controls.ARMAPESSWPESSNFUNC___.wrapperProps"
							:id="getControlId(controls.ARMAPESSWPESSNFUNC___)"
							v-on="controls.ARMAPESSWPESSNFUNC___.handlers"
							:loading="controls.ARMAPESSWPESSNFUNC___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.ARMAPESSWPESSNFUNC___.isVisible"
								v-bind="controls.ARMAPESSWPESSNFUNC___.props"
								:id="getControlId(controls.ARMAPESSWPESSNFUNC___)"
								@update:model-value="model.ValNfunc.fnUpdateValue" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.ARMAPESSWPESSPFOTO___.isVisible">
					<q-col
						v-if="controls.ARMAPESSWPESSPFOTO___.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ARMAPESSWPESSPFOTO___.isVisible"
							class="q-image"
							v-bind="controls.ARMAPESSWPESSPFOTO___.wrapperProps"
							:id="getControlId(controls.ARMAPESSWPESSPFOTO___)"
							v-on="controls.ARMAPESSWPESSPFOTO___.handlers"
							:loading="controls.ARMAPESSWPESSPFOTO___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-image
								v-if="controls.ARMAPESSWPESSPFOTO___.isVisible"
								v-bind="controls.ARMAPESSWPESSPFOTO___.props"
								:id="getControlId(controls.ARMAPESSWPESSPFOTO___)"
								v-on="controls.ARMAPESSWPESSPFOTO___.handlers" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.ARMAPESSWPESSNAME____.isVisible || controls.ARMAPESSWPESSDATE____.isVisible || controls.ARMAPESSWPESSSEX_____.isVisible">
					<q-col
						v-if="controls.ARMAPESSWPESSNAME____.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ARMAPESSWPESSNAME____.isVisible"
							class="i-text"
							v-bind="controls.ARMAPESSWPESSNAME____.wrapperProps"
							:id="getControlId(controls.ARMAPESSWPESSNAME____)"
							v-on="controls.ARMAPESSWPESSNAME____.handlers"
							:loading="controls.ARMAPESSWPESSNAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.ARMAPESSWPESSNAME____.props"
								:id="getControlId(controls.ARMAPESSWPESSNAME____)"
								@blur="onBlur(controls.ARMAPESSWPESSNAME____, model.ValName.value)"
								@change="model.ValName.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.ARMAPESSWPESSDATE____.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ARMAPESSWPESSDATE____.isVisible"
							class="i-text"
							v-bind="controls.ARMAPESSWPESSDATE____.wrapperProps"
							:id="getControlId(controls.ARMAPESSWPESSDATE____)"
							v-on="controls.ARMAPESSWPESSDATE____.handlers"
							:loading="controls.ARMAPESSWPESSDATE____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.ARMAPESSWPESSDATE____.isVisible"
								v-bind="controls.ARMAPESSWPESSDATE____.props"
								:id="getControlId(controls.ARMAPESSWPESSDATE____)"
								:model-value="model.ValDate.value"
								@reset-icon-click="model.ValDate.fnUpdateValue(model.ValDate.originalValue ?? new Date())"
								@update:model-value="model.ValDate.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.ARMAPESSWPESSSEX_____.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ARMAPESSWPESSSEX_____.isVisible"
							class="i-text"
							v-bind="controls.ARMAPESSWPESSSEX_____.wrapperProps"
							:id="getControlId(controls.ARMAPESSWPESSSEX_____)"
							v-on="controls.ARMAPESSWPESSSEX_____.handlers"
							:loading="controls.ARMAPESSWPESSSEX_____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-select
								v-if="controls.ARMAPESSWPESSSEX_____.isVisible"
								v-bind="controls.ARMAPESSWPESSSEX_____.props"
								:id="getControlId(controls.ARMAPESSWPESSSEX_____)"
								@update:model-value="model.ValSex.fnUpdateValue" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.ARMAPESSWPESSNATURALI.isVisible">
					<q-col
						v-if="controls.ARMAPESSWPESSNATURALI.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ARMAPESSWPESSNATURALI.isVisible"
							class="i-text"
							v-bind="controls.ARMAPESSWPESSNATURALI.wrapperProps"
							:id="getControlId(controls.ARMAPESSWPESSNATURALI)"
							v-on="controls.ARMAPESSWPESSNATURALI.handlers"
							:loading="controls.ARMAPESSWPESSNATURALI.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.ARMAPESSWPESSNATURALI.props"
								:id="getControlId(controls.ARMAPESSWPESSNATURALI)"
								@blur="onBlur(controls.ARMAPESSWPESSNATURALI, model.ValNaturali.value)"
								@change="model.ValNaturali.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.ARMAPESSWPESSNACIONAL.isVisible">
					<q-col
						v-if="controls.ARMAPESSWPESSNACIONAL.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ARMAPESSWPESSNACIONAL.isVisible"
							class="i-text"
							v-bind="controls.ARMAPESSWPESSNACIONAL.wrapperProps"
							:id="getControlId(controls.ARMAPESSWPESSNACIONAL)"
							v-on="controls.ARMAPESSWPESSNACIONAL.handlers"
							:loading="controls.ARMAPESSWPESSNACIONAL.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.ARMAPESSWPESSNACIONAL.props"
								:id="getControlId(controls.ARMAPESSWPESSNACIONAL)"
								@blur="onBlur(controls.ARMAPESSWPESSNACIONAL, model.ValNacional.value)"
								@change="model.ValNacional.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.ARMAPESSWPESSADRESS__.isVisible || controls.ARMAPESSWPESSZIPCODE_.isVisible">
					<q-col
						v-if="controls.ARMAPESSWPESSADRESS__.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ARMAPESSWPESSADRESS__.isVisible"
							class="i-text"
							v-bind="controls.ARMAPESSWPESSADRESS__.wrapperProps"
							:id="getControlId(controls.ARMAPESSWPESSADRESS__)"
							v-on="controls.ARMAPESSWPESSADRESS__.handlers"
							:loading="controls.ARMAPESSWPESSADRESS__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.ARMAPESSWPESSADRESS__.props"
								:id="getControlId(controls.ARMAPESSWPESSADRESS__)"
								@blur="onBlur(controls.ARMAPESSWPESSADRESS__, model.ValAdress.value)"
								@change="model.ValAdress.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.ARMAPESSWPESSZIPCODE_.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ARMAPESSWPESSZIPCODE_.isVisible"
							class="i-text"
							v-bind="controls.ARMAPESSWPESSZIPCODE_.wrapperProps"
							:id="getControlId(controls.ARMAPESSWPESSZIPCODE_)"
							v-on="controls.ARMAPESSWPESSZIPCODE_.handlers"
							:loading="controls.ARMAPESSWPESSZIPCODE_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-mask
								v-if="controls.ARMAPESSWPESSZIPCODE_.isVisible"
								v-bind="controls.ARMAPESSWPESSZIPCODE_.props"
								:id="getControlId(controls.ARMAPESSWPESSZIPCODE_)"
								:model-value="model.ValZipcode.value"
								@change="model.ValZipcode.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.ARMAPESSWPESSCOUNTRY_.isVisible">
					<q-col
						v-if="controls.ARMAPESSWPESSCOUNTRY_.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ARMAPESSWPESSCOUNTRY_.isVisible"
							class="i-text"
							v-bind="controls.ARMAPESSWPESSCOUNTRY_.wrapperProps"
							:id="getControlId(controls.ARMAPESSWPESSCOUNTRY_)"
							v-on="controls.ARMAPESSWPESSCOUNTRY_.handlers"
							:loading="controls.ARMAPESSWPESSCOUNTRY_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.ARMAPESSWPESSCOUNTRY_.props"
								:id="getControlId(controls.ARMAPESSWPESSCOUNTRY_)"
								@blur="onBlur(controls.ARMAPESSWPESSCOUNTRY_, model.ValCountry.value)"
								@change="model.ValCountry.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.ARMAPESSWPESSEMAIL___.isVisible">
					<q-col
						v-if="controls.ARMAPESSWPESSEMAIL___.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ARMAPESSWPESSEMAIL___.isVisible"
							class="i-text"
							v-bind="controls.ARMAPESSWPESSEMAIL___.wrapperProps"
							:id="getControlId(controls.ARMAPESSWPESSEMAIL___)"
							v-on="controls.ARMAPESSWPESSEMAIL___.handlers"
							:loading="controls.ARMAPESSWPESSEMAIL___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-mask
								v-if="controls.ARMAPESSWPESSEMAIL___.isVisible"
								v-bind="controls.ARMAPESSWPESSEMAIL___.props"
								:id="getControlId(controls.ARMAPESSWPESSEMAIL___)"
								:model-value="model.ValEmail.value"
								@change="model.ValEmail.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.ARMAPESSWPESSCELLPHON.isVisible">
					<q-col
						v-if="controls.ARMAPESSWPESSCELLPHON.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ARMAPESSWPESSCELLPHON.isVisible"
							class="i-text"
							v-bind="controls.ARMAPESSWPESSCELLPHON.wrapperProps"
							:id="getControlId(controls.ARMAPESSWPESSCELLPHON)"
							v-on="controls.ARMAPESSWPESSCELLPHON.handlers"
							:loading="controls.ARMAPESSWPESSCELLPHON.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.ARMAPESSWPESSCELLPHON.isVisible"
								v-bind="controls.ARMAPESSWPESSCELLPHON.props"
								:id="getControlId(controls.ARMAPESSWPESSCELLPHON)"
								@update:model-value="model.ValCellphon.fnUpdateValue" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.ARMAPESSWAREHWAREHDES.isVisible">
					<q-col
						v-if="controls.ARMAPESSWAREHWAREHDES.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ARMAPESSWAREHWAREHDES.isVisible"
							class="i-text"
							v-bind="controls.ARMAPESSWAREHWAREHDES.wrapperProps"
							:id="getControlId(controls.ARMAPESSWAREHWAREHDES)"
							v-on="controls.ARMAPESSWAREHWAREHDES.handlers"
							:loading="controls.ARMAPESSWAREHWAREHDES.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.ARMAPESSWAREHWAREHDES.isVisible"
								v-bind="controls.ARMAPESSWAREHWAREHDES.props"
								:id="getControlId(controls.ARMAPESSWAREHWAREHDES)"
								v-on="controls.ARMAPESSWAREHWAREHDES.handlers" />
							<q-see-more-armapesswarehwarehdes
								v-if="controls.ARMAPESSWAREHWAREHDES.seeMoreIsVisible"
								v-bind="controls.ARMAPESSWAREHWAREHDES.seeMoreParams"
								v-on="controls.ARMAPESSWAREHWAREHDES.handlers" />
						</base-input-structure>
					</q-col>
				</q-row>
			</template>
		</q-container>
	</teleport>

	<q-divider v-if="!isPopup && showFormFooter" />

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

	import FormViewModel from './QFormArmapessViewModel.js'

	const requiredTextResources = ['QFormArmapess', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS ARMAPESS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormArmapess',

		components: {
			QSeeMoreArmapesswarehwarehdes: defineAsyncComponent(() => import('@/views/forms/FormArmapess/dbedits/ArmapesswarehwarehdesSeeMore.vue')),
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
					name: 'ARMAPESS',
					location: 'form-ARMAPESS',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormArmapess', false),

				interfaceMetadata: {
					id: 'QFormArmapess', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'ARMAPESS',
					route: 'form-ARMAPESS',
					area: 'WPESS',
					primaryKey: 'ValCodpess',
					designation: computed(() => this.Resources.PERSON10446),
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
						text: computed(() => vm.Resources.INSERIR43365),
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
					ARMAPESSWPESSNFUNC___: new fieldControlClass.NumberControl({
						modelField: 'ValNfunc',
						valueChangeEvent: 'fieldChange:wpess.nfunc',
						id: 'ARMAPESSWPESSNFUNC___',
						name: 'NFUNC',
						size: 'medium',
						label: computed(() => this.Resources.EMPLOYEE_NUMBER05861),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 6,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					ARMAPESSWPESSPFOTO___: new fieldControlClass.ImageControl({
						modelField: 'ValPfoto',
						valueChangeEvent: 'fieldChange:wpess.pfoto',
						id: 'ARMAPESSWPESSPFOTO___',
						name: 'PFOTO',
						size: 'medium',
						label: computed(() => this.Resources.PROFILLE_PICTURE38233),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						height: 50,
						width: 100,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PROFILLE_PICTURE38233)),
						controlLimits: [
						],
					}, this),
					ARMAPESSWPESSNAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:wpess.name',
						id: 'ARMAPESSWPESSNAME____',
						name: 'NAME',
						size: 'xlarge',
						label: computed(() => this.Resources.NAME31974),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					ARMAPESSWPESSDATE____: new fieldControlClass.DateControl({
						modelField: 'ValDate',
						valueChangeEvent: 'fieldChange:wpess.date',
						id: 'ARMAPESSWPESSDATE____',
						name: 'DATE',
						size: 'small',
						label: computed(() => this.Resources.BIRTH_DATE54504),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					ARMAPESSWPESSSEX_____: new fieldControlClass.ArrayStringControl({
						modelField: 'ValSex',
						valueChangeEvent: 'fieldChange:wpess.sex',
						id: 'ARMAPESSWPESSSEX_____',
						name: 'SEX',
						size: 'small',
						label: computed(() => this.Resources.SEX34102),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 9,
						arrayName: 'SEXO',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					ARMAPESSWPESSNATURALI: new fieldControlClass.StringControl({
						modelField: 'ValNaturali',
						valueChangeEvent: 'fieldChange:wpess.naturali',
						id: 'ARMAPESSWPESSNATURALI',
						name: 'NATURALI',
						size: 'xlarge',
						label: computed(() => this.Resources.COUNTRY_OF_BIRTH53244),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					ARMAPESSWPESSNACIONAL: new fieldControlClass.StringControl({
						modelField: 'ValNacional',
						valueChangeEvent: 'fieldChange:wpess.nacional',
						id: 'ARMAPESSWPESSNACIONAL',
						name: 'NACIONAL',
						size: 'xlarge',
						label: computed(() => this.Resources.NATIONALITY34787),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					ARMAPESSWPESSADRESS__: new fieldControlClass.StringControl({
						modelField: 'ValAdress',
						valueChangeEvent: 'fieldChange:wpess.adress',
						id: 'ARMAPESSWPESSADRESS__',
						name: 'ADRESS',
						size: 'xxlarge',
						label: computed(() => this.Resources.ADRESS39816),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 100,
						controlLimits: [
						],
					}, this),
					ARMAPESSWPESSZIPCODE_: new fieldControlClass.MaskControl({
						modelField: 'ValZipcode',
						valueChangeEvent: 'fieldChange:wpess.zipcode',
						id: 'ARMAPESSWPESSZIPCODE_',
						name: 'ZIPCODE',
						size: 'small',
						label: computed(() => this.Resources.ZIPCODE21021),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 8,
						controlLimits: [
						],
					}, this),
					ARMAPESSWPESSCOUNTRY_: new fieldControlClass.StringControl({
						modelField: 'ValCountry',
						valueChangeEvent: 'fieldChange:wpess.country',
						id: 'ARMAPESSWPESSCOUNTRY_',
						name: 'COUNTRY',
						size: 'xlarge',
						label: computed(() => this.Resources.COUNTRY64133),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					ARMAPESSWPESSEMAIL___: new fieldControlClass.MaskControl({
						modelField: 'ValEmail',
						valueChangeEvent: 'fieldChange:wpess.email',
						id: 'ARMAPESSWPESSEMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						label: computed(() => this.Resources.EMAIL25170),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 150,
						controlLimits: [
						],
					}, this),
					ARMAPESSWPESSCELLPHON: new fieldControlClass.NumberControl({
						modelField: 'ValCellphon',
						valueChangeEvent: 'fieldChange:wpess.cellphon',
						id: 'ARMAPESSWPESSCELLPHON',
						name: 'CELLPHON',
						size: 'small',
						label: computed(() => this.Resources.CELLPHONE19585),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 9,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					ARMAPESSWAREHWAREHDES: new fieldControlClass.LookupControl({
						modelField: 'TableWarehWarehdes',
						valueChangeEvent: 'fieldChange:wareh.warehdes',
						id: 'ARMAPESSWAREHWAREHDES',
						name: 'WAREHDES',
						size: 'xxlarge',
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
							dependencyEvent: 'fieldChange:wpess.codwareh'
						},
						dependentFields: () => ({
							set 'wareh.codwareh'(value) { vm.model.ValCodwareh.updateValue(value) },
							set 'wareh.warehdes'(value) { vm.model.TableWarehWarehdes.updateValue(value) },
						}),
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
					Wareh: {
						get ValWarehdes() { return vm.model.TableWarehWarehdes.value },
						set ValWarehdes(value) { vm.model.TableWarehWarehdes.updateValue(value) },
					},
					Wpess: {
						get ValAdress() { return vm.model.ValAdress.value },
						set ValAdress(value) { vm.model.ValAdress.updateValue(value) },
						get ValCellphon() { return vm.model.ValCellphon.value },
						set ValCellphon(value) { vm.model.ValCellphon.updateValue(value) },
						get ValCodwareh() { return vm.model.ValCodwareh.value },
						set ValCodwareh(value) { vm.model.ValCodwareh.updateValue(value) },
						get ValCountry() { return vm.model.ValCountry.value },
						set ValCountry(value) { vm.model.ValCountry.updateValue(value) },
						get ValDate() { return vm.model.ValDate.value },
						set ValDate(value) { vm.model.ValDate.updateValue(value) },
						get ValEmail() { return vm.model.ValEmail.value },
						set ValEmail(value) { vm.model.ValEmail.updateValue(value) },
						get ValNacional() { return vm.model.ValNacional.value },
						set ValNacional(value) { vm.model.ValNacional.updateValue(value) },
						get ValName() { return vm.model.ValName.value },
						set ValName(value) { vm.model.ValName.updateValue(value) },
						get ValNaturali() { return vm.model.ValNaturali.value },
						set ValNaturali(value) { vm.model.ValNaturali.updateValue(value) },
						get ValNfunc() { return vm.model.ValNfunc.value },
						set ValNfunc(value) { vm.model.ValNfunc.updateValue(value) },
						get ValPfoto() { return vm.model.ValPfoto.value },
						set ValPfoto(value) { vm.model.ValPfoto.updateValue(value) },
						get ValSex() { return vm.model.ValSex.value },
						set ValSex(value) { vm.model.ValSex.updateValue(value) },
						get ValZipcode() { return vm.model.ValZipcode.value },
						set ValZipcode(value) { vm.model.ValZipcode.updateValue(value) },
					},
					keys: {
						/** The primary key of the WPESS table */
						get wpess() { return vm.model.ValCodpess },
						/** The foreign key to the WAREH table */
						get wareh() { return vm.model.ValCodwareh },
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
// USE /[MANUAL GQT FORM_CODEJS ARMAPESS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT ARMAPESS]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS ARMAPESS]/
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
// USE /[MANUAL GQT FORM_LOADED_JS ARMAPESS]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS ARMAPESS]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS ARMAPESS]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS ARMAPESS]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS ARMAPESS]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS ARMAPESS]/
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
// USE /[MANUAL GQT AFTER_DEL_JS ARMAPESS]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS ARMAPESS]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS ARMAPESS]/
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
// USE /[MANUAL GQT DLGUPDT ARMAPESS]/
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
// USE /[MANUAL GQT CTRLBLR ARMAPESS]/
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
// USE /[MANUAL GQT CTRLUPD ARMAPESS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS ARMAPESS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
