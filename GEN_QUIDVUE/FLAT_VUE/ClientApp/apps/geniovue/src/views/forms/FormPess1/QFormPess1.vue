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
			data-key="PESS1"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.PESS1___CMPNYDESIGNAT.isVisible">
					<q-control-wrapper
						v-show="controls.PESS1___CMPNYDESIGNAT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PESS1___CMPNYDESIGNAT"
							v-on="controls.PESS1___CMPNYDESIGNAT.handlers"
							:loading="controls.PESS1___CMPNYDESIGNAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.PESS1___CMPNYDESIGNAT.isVisible"
								v-bind="controls.PESS1___CMPNYDESIGNAT.props"
								v-on="controls.PESS1___CMPNYDESIGNAT.handlers" />
							<q-see-more-pess1-cmpnydesignat
								v-if="controls.PESS1___CMPNYDESIGNAT.seeMoreIsVisible"
								v-bind="controls.PESS1___CMPNYDESIGNAT.seeMoreParams"
								v-on="controls.PESS1___CMPNYDESIGNAT.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PESS1___STAKEDESIGNAT.isVisible">
					<q-control-wrapper
						v-show="controls.PESS1___STAKEDESIGNAT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PESS1___STAKEDESIGNAT"
							v-on="controls.PESS1___STAKEDESIGNAT.handlers"
							:loading="controls.PESS1___STAKEDESIGNAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.PESS1___STAKEDESIGNAT.isVisible"
								v-bind="controls.PESS1___STAKEDESIGNAT.props"
								v-on="controls.PESS1___STAKEDESIGNAT.handlers" />
							<q-see-more-pess1-stakedesignat
								v-if="controls.PESS1___STAKEDESIGNAT.seeMoreIsVisible"
								v-bind="controls.PESS1___STAKEDESIGNAT.seeMoreParams"
								v-on="controls.PESS1___STAKEDESIGNAT.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PESS1___PESS1NAME____.isVisible">
					<q-control-wrapper
						v-show="controls.PESS1___PESS1NAME____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PESS1___PESS1NAME____"
							v-on="controls.PESS1___PESS1NAME____.handlers"
							:loading="controls.PESS1___PESS1NAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.PESS1___PESS1NAME____.props"
								@blur="onBlur(controls.PESS1___PESS1NAME____, model.ValName.value)"
								@change="model.ValName.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PESS1___PESS1GENDER__.isVisible">
					<q-control-wrapper
						v-show="controls.PESS1___PESS1GENDER__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PESS1___PESS1GENDER__"
							v-on="controls.PESS1___PESS1GENDER__.handlers"
							:loading="controls.PESS1___PESS1GENDER__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-select
								v-if="controls.PESS1___PESS1GENDER__.isVisible"
								v-bind="controls.PESS1___PESS1GENDER__.props"
								@update:model-value="model.ValGender.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PESS1___PESS1DTNASCIM.isVisible || controls.PESS1___PESS1IDFUNCIO.isVisible || controls.PESS1___PESS1TELEPHON.isVisible">
					<q-control-wrapper
						v-show="controls.PESS1___PESS1DTNASCIM.isVisible || controls.PESS1___PESS1IDFUNCIO.isVisible || controls.PESS1___PESS1TELEPHON.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PESS1___PESS1DTNASCIM"
							v-on="controls.PESS1___PESS1DTNASCIM.handlers"
							:loading="controls.PESS1___PESS1DTNASCIM.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.PESS1___PESS1DTNASCIM.isVisible"
								v-bind="controls.PESS1___PESS1DTNASCIM.props"
								:model-value="model.ValDtnascim.value"
								@reset-icon-click="model.ValDtnascim.fnUpdateValue(model.ValDtnascim.originalValue ?? new Date())"
								@update:model-value="model.ValDtnascim.fnUpdateValue($event ?? '')" />
						</base-input-structure>
						<base-input-structure
							class="i-text"
							v-bind="controls.PESS1___PESS1IDFUNCIO"
							v-on="controls.PESS1___PESS1IDFUNCIO.handlers"
							:loading="controls.PESS1___PESS1IDFUNCIO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.PESS1___PESS1IDFUNCIO.isVisible"
								v-bind="controls.PESS1___PESS1IDFUNCIO.props"
								@update:model-value="model.ValIdfuncio.fnUpdateValue" />
						</base-input-structure>
						<base-input-structure
							class="i-text"
							v-bind="controls.PESS1___PESS1TELEPHON"
							v-on="controls.PESS1___PESS1TELEPHON.handlers"
							:loading="controls.PESS1___PESS1TELEPHON.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.PESS1___PESS1TELEPHON.props"
								@blur="onBlur(controls.PESS1___PESS1TELEPHON, model.ValTelephon.value)"
								@change="model.ValTelephon.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PESS1___PESS1EMAIL___.isVisible">
					<q-control-wrapper
						v-show="controls.PESS1___PESS1EMAIL___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PESS1___PESS1EMAIL___"
							v-on="controls.PESS1___PESS1EMAIL___.handlers"
							:loading="controls.PESS1___PESS1EMAIL___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.PESS1___PESS1EMAIL___.props"
								@blur="onBlur(controls.PESS1___PESS1EMAIL___, model.ValEmail.value)"
								@change="model.ValEmail.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PESS1___PESS1EMAIL2__.isVisible">
					<q-control-wrapper
						v-show="controls.PESS1___PESS1EMAIL2__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PESS1___PESS1EMAIL2__"
							v-on="controls.PESS1___PESS1EMAIL2__.handlers"
							:loading="controls.PESS1___PESS1EMAIL2__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.PESS1___PESS1EMAIL2__.props"
								@blur="onBlur(controls.PESS1___PESS1EMAIL2__, model.ValEmail2.value)"
								@change="model.ValEmail2.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PESS1___PESS1PHOTOGRA.isVisible">
					<q-control-wrapper
						v-show="controls.PESS1___PESS1PHOTOGRA.isVisible"
						class="control-join-group">
						<base-input-structure
							class="q-image"
							v-bind="controls.PESS1___PESS1PHOTOGRA"
							v-on="controls.PESS1___PESS1PHOTOGRA.handlers"
							:loading="controls.PESS1___PESS1PHOTOGRA.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-image
								v-if="controls.PESS1___PESS1PHOTOGRA.isVisible"
								v-bind="controls.PESS1___PESS1PHOTOGRA.props"
								v-on="controls.PESS1___PESS1PHOTOGRA.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PESS1___PESS1DTULTCAT.isVisible || controls.PESS1___PESS1EXTERNA_.isVisible || controls.PESS1___PESS1INTERNA_.isVisible || controls.PESS1___PESS1IDADE___.isVisible">
					<q-control-wrapper
						v-show="controls.PESS1___PESS1DTULTCAT.isVisible || controls.PESS1___PESS1EXTERNA_.isVisible || controls.PESS1___PESS1INTERNA_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PESS1___PESS1DTULTCAT"
							v-on="controls.PESS1___PESS1DTULTCAT.handlers"
							:loading="controls.PESS1___PESS1DTULTCAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.PESS1___PESS1DTULTCAT.isVisible"
								v-bind="controls.PESS1___PESS1DTULTCAT.props"
								:model-value="model.ValDtultcat.value"
								@reset-icon-click="model.ValDtultcat.fnUpdateValue(model.ValDtultcat.originalValue ?? new Date())"
								@update:model-value="model.ValDtultcat.fnUpdateValue($event ?? '')" />
						</base-input-structure>
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.PESS1___PESS1EXTERNA_"
							v-on="controls.PESS1___PESS1EXTERNA_.handlers"
							:loading="controls.PESS1___PESS1EXTERNA_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox-input
									v-if="controls.PESS1___PESS1EXTERNA_.isVisible"
									v-bind="controls.PESS1___PESS1EXTERNA_.props"
									v-on="controls.PESS1___PESS1EXTERNA_.handlers" />
							</template>
						</base-input-structure>
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.PESS1___PESS1INTERNA_"
							v-on="controls.PESS1___PESS1INTERNA_.handlers"
							:loading="controls.PESS1___PESS1INTERNA_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox-input
									v-if="controls.PESS1___PESS1INTERNA_.isVisible"
									v-bind="controls.PESS1___PESS1INTERNA_.props"
									v-on="controls.PESS1___PESS1INTERNA_.handlers" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.PESS1___PESS1IDADE___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PESS1___PESS1IDADE___"
							v-on="controls.PESS1___PESS1IDADE___.handlers"
							:loading="controls.PESS1___PESS1IDADE___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.PESS1___PESS1IDADE___.isVisible"
								v-bind="controls.PESS1___PESS1IDADE___.props"
								@update:model-value="model.ValIdade.fnUpdateValue" />
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
	/* eslint-disable no-unused-vars */
	import { computed, defineAsyncComponent, readonly } from 'vue'
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

	import FormViewModel from './QFormPess1ViewModel.js'

	const requiredTextResources = ['QFormPess1', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PESS1]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormPess1',

		components: {
			QSeeMorePess1Cmpnydesignat: defineAsyncComponent(() => import('@/views/forms/FormPess1/dbedits/Pess1CmpnydesignatSeeMore.vue')),
			QSeeMorePess1Stakedesignat: defineAsyncComponent(() => import('@/views/forms/FormPess1/dbedits/Pess1StakedesignatSeeMore.vue')),
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
					name: 'PESS1',
					location: 'form-PESS1',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormPess1', false),

				interfaceMetadata: {
					id: 'QFormPess1', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'PESS1',
					route: 'form-PESS1',
					area: 'PESS1',
					primaryKey: 'ValCodpesso',
					designation: computed(() => this.Resources.COMODANTE63029),
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
					PESS1___CMPNYDESIGNAT: new fieldControlClass.LookupControl({
						modelField: 'TableCmpnyDesignat',
						valueChangeEvent: 'fieldChange:cmpny.designat',
						id: 'PESS1___CMPNYDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.COMPANY_22615),
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
							dependencyEvent: 'fieldChange:pess1.codempre'
						},
						dependentFields: () => ({
							set 'cmpny.codempre'(value) { vm.model.ValCodempre.updateValue(value) },
							set 'cmpny.designat'(value) { vm.model.TableCmpnyDesignat.updateValue(value) },
						}),
						insertEnabled: true,
						supportForm: 'EMPRE',
						controlLimits: [
						],
					}, this),
					PESS1___STAKEDESIGNAT: new fieldControlClass.LookupControl({
						modelField: 'TableStakeDesignat',
						valueChangeEvent: 'fieldChange:stake.designat',
						id: 'PESS1___STAKEDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.INTERESTED34576),
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
							name: 'ValCodparte',
							dependencyEvent: 'fieldChange:pess1.codparte'
						},
						dependentFields: () => ({
							set 'stake.codparte'(value) { vm.model.ValCodparte.updateValue(value) },
							set 'stake.designat'(value) { vm.model.TableStakeDesignat.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					PESS1___PESS1NAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:pess1.name',
						id: 'PESS1___PESS1NAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.NAME31974),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						labelId: 'label_PESS1___PESS1NAME____',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					PESS1___PESS1GENDER__: new fieldControlClass.ArrayStringControl({
						modelField: 'ValGender',
						valueChangeEvent: 'fieldChange:pess1.gender',
						id: 'PESS1___PESS1GENDER__',
						name: 'GENDER',
						size: 'medium',
						label: computed(() => this.Resources.GENDER44172),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 1,
						labelId: 'label_PESS1___PESS1GENDER__',
						arrayName: 'Genero',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					PESS1___PESS1DTNASCIM: new fieldControlClass.DateControl({
						modelField: 'ValDtnascim',
						valueChangeEvent: 'fieldChange:pess1.dtnascim',
						id: 'PESS1___PESS1DTNASCIM',
						name: 'DTNASCIM',
						size: 'small',
						label: computed(() => this.Resources.BIRTH21799),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						format: 'date',
						controlLimits: [
						],
					}, this),
					PESS1___PESS1IDFUNCIO: new fieldControlClass.NumberControl({
						modelField: 'ValIdfuncio',
						valueChangeEvent: 'fieldChange:pess1.idfuncio',
						id: 'PESS1___PESS1IDFUNCIO',
						name: 'IDFUNCIO',
						size: 'small',
						label: computed(() => this.Resources.EMPLOYEE_NO_01176),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 6,
						maxDecimals: 0,
						isSequencial: true,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					PESS1___PESS1TELEPHON: new fieldControlClass.StringControl({
						modelField: 'ValTelephon',
						valueChangeEvent: 'fieldChange:pess1.telephon',
						id: 'PESS1___PESS1TELEPHON',
						name: 'TELEPHON',
						size: 'medium',
						label: computed(() => this.Resources.TELEPHONE28697),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 20,
						labelId: 'label_PESS1___PESS1TELEPHON',
						controlLimits: [
						],
					}, this),
					PESS1___PESS1EMAIL___: new fieldControlClass.StringControl({
						modelField: 'ValEmail',
						valueChangeEvent: 'fieldChange:pess1.email',
						id: 'PESS1___PESS1EMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						label: computed(() => this.Resources.EMAIL25170),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 254,
						labelId: 'label_PESS1___PESS1EMAIL___',
						controlLimits: [
						],
					}, this),
					PESS1___PESS1EMAIL2__: new fieldControlClass.StringControl({
						modelField: 'ValEmail2',
						valueChangeEvent: 'fieldChange:pess1.email2',
						id: 'PESS1___PESS1EMAIL2__',
						name: 'EMAIL2',
						size: 'xxlarge',
						label: computed(() => this.Resources.EMAIL__CONFIRM_56391),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 254,
						labelId: 'label_PESS1___PESS1EMAIL2__',
						controlLimits: [
						],
					}, this),
					PESS1___PESS1PHOTOGRA: new fieldControlClass.ImageControl({
						modelField: 'ValPhotogra',
						valueChangeEvent: 'fieldChange:pess1.photogra',
						id: 'PESS1___PESS1PHOTOGRA',
						name: 'PHOTOGRA',
						size: 'medium',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						height: 50,
						width: 100,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO51874)),
						controlLimits: [
						],
					}, this),
					PESS1___PESS1DTULTCAT: new fieldControlClass.DateControl({
						modelField: 'ValDtultcat',
						valueChangeEvent: 'fieldChange:pess1.dtultcat',
						id: 'PESS1___PESS1DTULTCAT',
						name: 'DTULTCAT',
						size: 'small',
						label: computed(() => this.Resources.SINCE47259),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						format: 'date',
						controlLimits: [
						],
					}, this),
					PESS1___PESS1EXTERNA_: new fieldControlClass.BooleanControl({
						modelField: 'ValExterna',
						valueChangeEvent: 'fieldChange:pess1.externa',
						id: 'PESS1___PESS1EXTERNA_',
						name: 'EXTERNA',
						size: 'small',
						label: computed(() => this.Resources.EXTERNAL13375),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						controlLimits: [
						],
					}, this),
					PESS1___PESS1INTERNA_: new fieldControlClass.BooleanControl({
						modelField: 'ValInterna',
						valueChangeEvent: 'fieldChange:pess1.interna',
						id: 'PESS1___PESS1INTERNA_',
						name: 'INTERNA',
						size: 'mini',
						label: computed(() => this.Resources.INTERN65375),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						controlLimits: [
						],
					}, this),
					PESS1___PESS1IDADE___: new fieldControlClass.NumberControl({
						modelField: 'ValIdade',
						valueChangeEvent: 'fieldChange:pess1.idade',
						id: 'PESS1___PESS1IDADE___',
						name: 'IDADE',
						size: 'mini',
						label: computed(() => this.Resources.AGE28663),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 5,
						maxDecimals: 0,
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
					Cmpny: {
						get ValDesignat() { return vm.model.TableCmpnyDesignat.value },
						set ValDesignat(value) { vm.model.TableCmpnyDesignat.updateValue(value) },
					},
					Pess1: {
						get ValCodcateg() { return vm.model.ValCodcateg.value },
						set ValCodcateg(value) { vm.model.ValCodcateg.updateValue(value) },
						get ValCodempre() { return vm.model.ValCodempre.value },
						set ValCodempre(value) { vm.model.ValCodempre.updateValue(value) },
						get ValCodparte() { return vm.model.ValCodparte.value },
						set ValCodparte(value) { vm.model.ValCodparte.updateValue(value) },
						get ValDtnascim() { return vm.model.ValDtnascim.value },
						set ValDtnascim(value) { vm.model.ValDtnascim.updateValue(value) },
						get ValDtultcat() { return vm.model.ValDtultcat.value },
						set ValDtultcat(value) { vm.model.ValDtultcat.updateValue(value) },
						get ValEmail() { return vm.model.ValEmail.value },
						set ValEmail(value) { vm.model.ValEmail.updateValue(value) },
						get ValEmail2() { return vm.model.ValEmail2.value },
						set ValEmail2(value) { vm.model.ValEmail2.updateValue(value) },
						get ValExterna() { return vm.model.ValExterna.value },
						set ValExterna(value) { vm.model.ValExterna.updateValue(value) },
						get ValGender() { return vm.model.ValGender.value },
						set ValGender(value) { vm.model.ValGender.updateValue(value) },
						get ValIdade() { return vm.model.ValIdade.value },
						set ValIdade(value) { vm.model.ValIdade.updateValue(value) },
						get ValIdfuncio() { return vm.model.ValIdfuncio.value },
						set ValIdfuncio(value) { vm.model.ValIdfuncio.updateValue(value) },
						get ValInterna() { return vm.model.ValInterna.value },
						set ValInterna(value) { vm.model.ValInterna.updateValue(value) },
						get ValName() { return vm.model.ValName.value },
						set ValName(value) { vm.model.ValName.updateValue(value) },
						get ValPhotogra() { return vm.model.ValPhotogra.value },
						set ValPhotogra(value) { vm.model.ValPhotogra.updateValue(value) },
						get ValTelephon() { return vm.model.ValTelephon.value },
						set ValTelephon(value) { vm.model.ValTelephon.updateValue(value) },
					},
					Stake: {
						get ValDesignat() { return vm.model.TableStakeDesignat.value },
						set ValDesignat(value) { vm.model.TableStakeDesignat.updateValue(value) },
					},
					keys: {
						/** The primary key of the PESS1 table */
						get pess1() { return vm.model.ValCodpesso },
						/** The foreign key to the CMPNY table */
						get cmpny() { return vm.model.ValCodempre },
						/** The foreign key to the STAKE table */
						get stake() { return vm.model.ValCodparte },
						/** The foreign key to the CATE2 table */
						get cate2() { return vm.model.ValCodcateg },
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
// USE /[MANUAL GQT FORM_CODEJS PESS1]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS PESS1]/
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
// USE /[MANUAL GQT FORM_LOADED_JS PESS1]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS PESS1]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS PESS1]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS PESS1]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS PESS1]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS PESS1]/
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
// USE /[MANUAL GQT AFTER_DEL_JS PESS1]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS PESS1]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS PESS1]/
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
// USE /[MANUAL GQT DLGUPDT PESS1]/
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
// USE /[MANUAL GQT CTRLBLR PESS1]/
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
// USE /[MANUAL GQT CTRLUPD PESS1]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS PESS1]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
