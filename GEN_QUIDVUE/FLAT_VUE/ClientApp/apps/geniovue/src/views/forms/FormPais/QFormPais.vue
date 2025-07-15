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
			data-key="PAIS"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.PAIS____PSEUDNOVOGR02.isVisible">
					<q-control-wrapper
						v-show="controls.PAIS____PSEUDNOVOGR02.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="PAIS____PSEUDNOVOGR02"
							v-bind="controls.PAIS____PSEUDNOVOGR02"
							:is-visible="controls.PAIS____PSEUDNOVOGR02.isVisible">
							<!-- Start PAIS____PSEUDNOVOGR02 -->
							<q-row-container v-show="controls.PAIS____CNTRYCOUNTRY_.isVisible || controls.PAIS____CNTRYACTIVE__.isVisible">
								<q-control-wrapper
									v-show="controls.PAIS____CNTRYCOUNTRY_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PAIS____CNTRYCOUNTRY_"
										v-on="controls.PAIS____CNTRYCOUNTRY_.handlers"
										:loading="controls.PAIS____CNTRYCOUNTRY_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.PAIS____CNTRYCOUNTRY_.props"
											@blur="onBlur(controls.PAIS____CNTRYCOUNTRY_, model.ValCountry.value)"
											@change="model.ValCountry.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PAIS____CNTRYACTIVE__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.PAIS____CNTRYACTIVE__"
										v-on="controls.PAIS____CNTRYACTIVE__.handlers"
										:loading="controls.PAIS____CNTRYACTIVE__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.PAIS____CNTRYACTIVE__.isVisible"
												v-bind="controls.PAIS____CNTRYACTIVE__.props"
												v-on="controls.PAIS____CNTRYACTIVE__.handlers" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container
								v-show="controls.PAIS____PSEUDNOVOGR01.isVisible"
								is-large>
								<q-control-wrapper
									v-show="controls.PAIS____PSEUDNOVOGR01.isVisible"
									class="row-line-group">
									<q-group-box-container
										id="PAIS____PSEUDNOVOGR01"
										v-bind="controls.PAIS____PSEUDNOVOGR01"
										:is-visible="controls.PAIS____PSEUDNOVOGR01.isVisible">
										<!-- Start PAIS____PSEUDNOVOGR01 -->
										<q-row-container v-show="controls.PAIS____CNTRYCODIGONR.isVisible || controls.PAIS____CNTRYALFA2___.isVisible || controls.PAIS____CNTRYALFA3___.isVisible">
											<q-control-wrapper
												v-show="controls.PAIS____CNTRYCODIGONR.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PAIS____CNTRYCODIGONR"
													v-on="controls.PAIS____CNTRYCODIGONR.handlers"
													:loading="controls.PAIS____CNTRYCODIGONR.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-field
														v-bind="controls.PAIS____CNTRYCODIGONR.props"
														@blur="onBlur(controls.PAIS____CNTRYCODIGONR, model.ValCodigonr.value)"
														@change="model.ValCodigonr.fnUpdateValueOnChange" />
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.PAIS____CNTRYALFA2___.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PAIS____CNTRYALFA2___"
													v-on="controls.PAIS____CNTRYALFA2___.handlers"
													:loading="controls.PAIS____CNTRYALFA2___.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-field
														v-bind="controls.PAIS____CNTRYALFA2___.props"
														@blur="onBlur(controls.PAIS____CNTRYALFA2___, model.ValAlfa2.value)"
														@change="model.ValAlfa2.fnUpdateValueOnChange" />
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.PAIS____CNTRYALFA3___.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PAIS____CNTRYALFA3___"
													v-on="controls.PAIS____CNTRYALFA3___.handlers"
													:loading="controls.PAIS____CNTRYALFA3___.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-field
														v-bind="controls.PAIS____CNTRYALFA3___.props"
														@blur="onBlur(controls.PAIS____CNTRYALFA3___, model.ValAlfa3.value)"
														@change="model.ValAlfa3.fnUpdateValueOnChange" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<!-- End PAIS____PSEUDNOVOGR01 -->
									</q-group-box-container>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PAIS____CNTRYFLAG____.isVisible">
								<q-control-wrapper
									v-show="controls.PAIS____CNTRYFLAG____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="q-image"
										v-bind="controls.PAIS____CNTRYFLAG____"
										v-on="controls.PAIS____CNTRYFLAG____.handlers"
										:loading="controls.PAIS____CNTRYFLAG____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-image
											v-if="controls.PAIS____CNTRYFLAG____.isVisible"
											v-bind="controls.PAIS____CNTRYFLAG____.props"
											v-on="controls.PAIS____CNTRYFLAG____.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End PAIS____PSEUDNOVOGR02 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PAIS____PSEUDIMOVEL__.isVisible">
					<q-control-wrapper
						v-show="controls.PAIS____PSEUDIMOVEL__.isVisible"
						class="control-join-group">
						<q-form-container
							:ref="controls.PAIS____PSEUDIMOVEL__.id"
							v-bind="controls.PAIS____PSEUDIMOVEL__"
							v-on="controls.PAIS____PSEUDIMOVEL__.handlers" />
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PAIS____PSEUDNOVOGR04.isVisible">
					<q-control-wrapper
						v-show="controls.PAIS____PSEUDNOVOGR04.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="PAIS____PSEUDNOVOGR04"
							v-bind="controls.PAIS____PSEUDNOVOGR04"
							no-border
							:is-visible="controls.PAIS____PSEUDNOVOGR04.isVisible">
							<!-- Start PAIS____PSEUDNOVOGR04 -->
							<q-row-container v-show="controls.PAIS____PSEUDNOVOGR03.isVisible">
								<q-control-wrapper
									v-show="controls.PAIS____PSEUDNOVOGR03.isVisible"
									class="control-join-group">
									<q-group-box-container
										id="PAIS____PSEUDNOVOGR03"
										v-bind="controls.PAIS____PSEUDNOVOGR03"
										no-border
										:is-visible="controls.PAIS____PSEUDNOVOGR03.isVisible">
										<!-- Start PAIS____PSEUDNOVOGR03 -->
										<q-row-container v-show="controls.PAIS____PSEUDPROPRIE1.isVisible">
											<q-control-wrapper
												v-show="controls.PAIS____PSEUDPROPRIE1.isVisible"
												class="control-join-group">
												<q-table
													v-show="controls.PAIS____PSEUDPROPRIE1.isVisible"
													v-bind="controls.PAIS____PSEUDPROPRIE1"
													v-on="controls.PAIS____PSEUDPROPRIE1.handlers" />
												<q-table-extra-extension
													:list-ctrl="controls.PAIS____PSEUDPROPRIE1"
													:filter-operators="controls.PAIS____PSEUDPROPRIE1.filterOperators"
													v-on="controls.PAIS____PSEUDPROPRIE1.handlers" />
											</q-control-wrapper>
										</q-row-container>
										<!-- End PAIS____PSEUDNOVOGR03 -->
									</q-group-box-container>
								</q-control-wrapper>
							</q-row-container>
							<!-- End PAIS____PSEUDNOVOGR04 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PAIS____PSEUDPROPRIED.isVisible">
					<q-control-wrapper
						v-show="controls.PAIS____PSEUDPROPRIED.isVisible"
						class="control-join-group">
						<q-table
							v-show="controls.PAIS____PSEUDPROPRIED.isVisible"
							v-bind="controls.PAIS____PSEUDPROPRIED"
							v-on="controls.PAIS____PSEUDPROPRIED.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.PAIS____PSEUDPROPRIED"
							:filter-operators="controls.PAIS____PSEUDPROPRIED.filterOperators"
							v-on="controls.PAIS____PSEUDPROPRIED.handlers" />
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

	import FormViewModel from './QFormPaisViewModel.js'

	const requiredTextResources = ['QFormPais', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PAIS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormPais',

		components: {
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
					name: 'PAIS',
					location: 'form-PAIS',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormPais', false),

				interfaceMetadata: {
					id: 'QFormPais', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'PAIS',
					route: 'form-PAIS',
					area: 'CNTRY',
					primaryKey: 'ValCodcntry',
					designation: computed(() => this.Resources.COUNTRY64133),
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
						text: computed(() => vm.Resources.INSERT30329),
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
					PAIS____PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'PAIS____PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'xxlarge',
						label: computed(() => this.Resources.COUNTRY64133),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['PAIS____CNTRYCOUNTRY_', 'PAIS____CNTRYACTIVE__', 'PAIS____PSEUDNOVOGR01', 'PAIS____CNTRYFLAG____'],
						controlLimits: [
						],
					}, this),
					PAIS____CNTRYCOUNTRY_: new fieldControlClass.StringControl({
						modelField: 'ValCountry',
						valueChangeEvent: 'fieldChange:cntry.country',
						id: 'PAIS____CNTRYCOUNTRY_',
						name: 'COUNTRY',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESIGNATION_35800),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PAIS____PSEUDNOVOGR02',
						maxLength: 90,
						labelId: 'label_PAIS____CNTRYCOUNTRY_',
						controlLimits: [
						],
					}, this),
					PAIS____CNTRYACTIVE__: new fieldControlClass.BooleanControl({
						modelField: 'ValActive',
						valueChangeEvent: 'fieldChange:cntry.active',
						id: 'PAIS____CNTRYACTIVE__',
						name: 'ACTIVE',
						size: 'mini',
						label: computed(() => this.Resources.ACTIVE03270),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'PAIS____PSEUDNOVOGR02',
						controlLimits: [
						],
					}, this),
					PAIS____PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'PAIS____PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						label: computed(() => this.Resources.COUNTRY_CODE16360),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PAIS____PSEUDNOVOGR02',
						isCollapsible: false,
						anchored: false,
						directChildren: ['PAIS____CNTRYCODIGONR', 'PAIS____CNTRYALFA2___', 'PAIS____CNTRYALFA3___'],
						controlLimits: [
						],
					}, this),
					PAIS____CNTRYCODIGONR: new fieldControlClass.StringControl({
						modelField: 'ValCodigonr',
						valueChangeEvent: 'fieldChange:cntry.codigonr',
						id: 'PAIS____CNTRYCODIGONR',
						name: 'CODIGONR',
						size: 'mini',
						label: computed(() => this.Resources.NUMERIC19292),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PAIS____PSEUDNOVOGR01',
						maxLength: 3,
						labelId: 'label_PAIS____CNTRYCODIGONR',
						controlLimits: [
						],
					}, this),
					PAIS____CNTRYALFA2___: new fieldControlClass.StringControl({
						modelField: 'ValAlfa2',
						valueChangeEvent: 'fieldChange:cntry.alfa2',
						id: 'PAIS____CNTRYALFA2___',
						name: 'ALFA2',
						size: 'small',
						label: computed(() => this.Resources.ALPHABETIC_2_16300),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PAIS____PSEUDNOVOGR01',
						maxLength: 2,
						labelId: 'label_PAIS____CNTRYALFA2___',
						controlLimits: [
						],
					}, this),
					PAIS____CNTRYALFA3___: new fieldControlClass.StringControl({
						modelField: 'ValAlfa3',
						valueChangeEvent: 'fieldChange:cntry.alfa3',
						id: 'PAIS____CNTRYALFA3___',
						name: 'ALFA3',
						size: 'small',
						label: computed(() => this.Resources.ALPHABETIC_3_29295),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PAIS____PSEUDNOVOGR01',
						maxLength: 3,
						labelId: 'label_PAIS____CNTRYALFA3___',
						controlLimits: [
						],
					}, this),
					PAIS____CNTRYFLAG____: new fieldControlClass.ImageControl({
						modelField: 'ValFlag',
						valueChangeEvent: 'fieldChange:cntry.flag',
						id: 'PAIS____CNTRYFLAG____',
						name: 'FLAG',
						size: 'medium',
						label: computed(() => this.Resources.BANDEIRA32255),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PAIS____PSEUDNOVOGR02',
						height: 50,
						width: 100,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.BANDEIRA32255)),
						controlLimits: [
						],
					}, this),
					PAIS____PSEUDIMOVEL__: new fieldControlClass.FormContainerControl({
						id: 'PAIS____PSEUDIMOVEL__',
						name: 'IMOVEL',
						size: 'xxlarge',
						label: computed(() => this.Resources.REAL_ESTATE15399),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						targetTableListId: 'PAIS____PSEUDPROPRIE1',
						supportForm: {
							name: 'PROPR00',
							component: 'QFormPropr00',
							mode: computed(() => vm.formInfo.mode),
							fnKeySelector: (row) => row.Fields.ValCodpropr
						},
						allowFormActions: {
						},
						controlLimits: [
						],
					}, this),
					PAIS____PSEUDNOVOGR04: new fieldControlClass.GroupControl({
						id: 'PAIS____PSEUDNOVOGR04',
						name: 'NOVOGR04',
						size: 'xxlarge',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['PAIS____PSEUDNOVOGR03'],
						controlLimits: [
						],
					}, this),
					PAIS____PSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'PAIS____PSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'xxlarge',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PAIS____PSEUDNOVOGR04',
						isCollapsible: false,
						anchored: false,
						directChildren: ['PAIS____PSEUDPROPRIE1'],
						controlLimits: [
						],
					}, this),
					PAIS____PSEUDPROPRIE1: new fieldControlClass.TableListControl({
						id: 'PAIS____PSEUDPROPRIE1',
						name: 'PROPRIE1',
						size: '',
						label: computed(() => this.Resources.REAL_ESTATE_LIST36497),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PAIS____PSEUDNOVOGR03',
						controller: 'CNTRY',
						action: 'Pais_ValProprie1',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValName',
								area: 'PROPR',
								field: 'NAME',
								label: computed(() => this.Resources.PROPERTY_NAME18934),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 2,
								name: 'ValPrecoest',
								area: 'PROPR',
								field: 'PRECOEST',
								label: computed(() => this.Resources.ESTIMATED_PRICE02986),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValProprie1',
							serverMode: true,
							pkColumn: 'ValCodpropr',
							tableAlias: 'PROPR',
							tableNamePlural: computed(() => this.Resources.PROPERTIES34868),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.REAL_ESTATE_LIST36497),
							showAlternatePagination: true,
							rowClickActionInternal: 'selectSingle',
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
										formName: 'PROPR00',
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
										formName: 'PROPR00',
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
										formName: 'PROPR00',
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
										formName: 'PROPR00',
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
										formName: 'PROPR00',
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
								id: 'RCA__PROPR00',
								name: '_PROPR00',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'PROPR00',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'PROPR00': {
									fnKeySelector: (row) => row.Fields.ValCodpropr,
									isPopup: false
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'ValName',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-REGIO', 'changed-PAIS1', 'changed-CNTRY', 'changed-PESSO', 'changed-PROPR', 'changed-TPPRO'],
						uuid: 'Pais_ValProprie1',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'cntry'],
								dependencyEvents: ['fieldChange:cntry.codcntry'],
								dependencyField: 'CNTRY.CODCNTRY',
								fnValueSelector: (model) => model.ValCodcntry.value
							},
						],
					}, this),
					PAIS____PSEUDPROPRIED: new fieldControlClass.TableListControl({
						id: 'PAIS____PSEUDPROPRIED',
						name: 'PROPRIED',
						size: '',
						label: computed(() => this.Resources.REAL_STATE_MAP58776),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'CNTRY',
						action: 'Pais_ValPropried',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValName',
								area: 'PROPR',
								field: 'NAME',
								label: computed(() => this.Resources.PROPERTY_NAME18934),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 2,
								name: 'ValPrecoest',
								area: 'PROPR',
								field: 'PRECOEST',
								label: computed(() => this.Resources.ESTIMATED_PRICE02986),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValEndereco',
								area: 'PROPR',
								field: 'ENDERECO',
								label: computed(() => this.Resources.ADDRESS04342),
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValLocalida',
								area: 'PROPR',
								field: 'LOCALIDA',
								label: computed(() => this.Resources.LOCALE34521),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValPostalco',
								area: 'PROPR',
								field: 'POSTALCO',
								label: computed(() => this.Resources.ZIP_CODE56964),
								dataLength: 20,
								scrollData: 20,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'ValPostallo',
								area: 'PROPR',
								field: 'POSTALLO',
								label: computed(() => this.Resources.POSTAL_LOCATION08708),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 7,
								name: 'ValMobilada',
								area: 'PROPR',
								field: 'MOBILADA',
								label: computed(() => this.Resources.FURNISHED37431),
								scrollData: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 8,
								name: 'ValQtd_wc',
								area: 'PROPR',
								field: 'QTD_WC',
								label: computed(() => this.Resources.BATHROOMS54249),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 9,
								name: 'ValQtdquart',
								area: 'PROPR',
								field: 'QTDQUART',
								label: computed(() => this.Resources.ROOMS06809),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 10,
								name: 'ValM2',
								area: 'PROPR',
								field: 'M2',
								label: computed(() => this.Resources.SQUARE_METERS28913),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 11,
								name: 'ValDtdispon',
								area: 'PROPR',
								field: 'DTDISPON',
								label: computed(() => this.Resources.AVAILABLE_FROM53703),
								scrollData: 8,
								dateTimeType: 'date',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 12,
								name: 'ValPhotogra',
								area: 'PROPR',
								field: 'PHOTOGRA',
								label: computed(() => this.Resources.PHOTO51874),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.PHOTO51874)),
								scrollData: 3,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 13,
								name: 'ValDescript',
								area: 'PROPR',
								field: 'DESCRIPT',
								label: computed(() => this.Resources.DESCRIPTION07383),
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.GeographicColumn({
								order: 14,
								name: 'ValCoordgeo',
								area: 'PROPR',
								field: 'COORDGEO',
								label: computed(() => this.Resources.GEOGRAPHIC_COORDINAT21394),
								dataLength: 50,
								scrollData: 30,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValPropried',
							serverMode: true,
							pkColumn: 'ValCodpropr',
							tableAlias: 'PROPR',
							tableNamePlural: computed(() => this.Resources.PROPERTIES34868),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.REAL_STATE_MAP58776),
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
										formName: 'PROPR00',
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
										formName: 'PROPR00',
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
										formName: 'PROPR00',
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
										formName: 'PROPR00',
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
										formName: 'PROPR00',
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
								id: 'RCA__PROPR00',
								name: '_PROPR00',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'PROPR00',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'PROPR00': {
									fnKeySelector: (row) => row.Fields.ValCodpropr,
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
						globalEvents: ['changed-REGIO', 'changed-PAIS1', 'changed-CNTRY', 'changed-PESSO', 'changed-PROPR', 'changed-TPPRO'],
						uuid: 'Pais_ValPropried',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'cntry'],
								dependencyEvents: ['fieldChange:cntry.codcntry'],
								dependencyField: 'CNTRY.CODCNTRY',
								fnValueSelector: (model) => model.ValCodcntry.value
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
					'PAIS____PSEUDNOVOGR02',
					'PAIS____PSEUDNOVOGR01',
					'PAIS____PSEUDNOVOGR04',
					'PAIS____PSEUDNOVOGR03',
				]),

				tableFields: readonly([
					'PAIS____PSEUDPROPRIE1',
					'PAIS____PSEUDPROPRIED',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Cntry: {
						get ValActive() { return vm.model.ValActive.value },
						set ValActive(value) { vm.model.ValActive.updateValue(value) },
						get ValAlfa2() { return vm.model.ValAlfa2.value },
						set ValAlfa2(value) { vm.model.ValAlfa2.updateValue(value) },
						get ValAlfa3() { return vm.model.ValAlfa3.value },
						set ValAlfa3(value) { vm.model.ValAlfa3.updateValue(value) },
						get ValCodigonr() { return vm.model.ValCodigonr.value },
						set ValCodigonr(value) { vm.model.ValCodigonr.updateValue(value) },
						get ValCountry() { return vm.model.ValCountry.value },
						set ValCountry(value) { vm.model.ValCountry.updateValue(value) },
						get ValFlag() { return vm.model.ValFlag.value },
						set ValFlag(value) { vm.model.ValFlag.updateValue(value) },
					},
					keys: {
						/** The primary key of the CNTRY table */
						get cntry() { return vm.model.ValCodcntry },
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
// USE /[MANUAL GQT FORM_CODEJS PAIS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT PAIS]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS PAIS]/
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
// USE /[MANUAL GQT FORM_LOADED_JS PAIS]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS PAIS]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS PAIS]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS PAIS]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS PAIS]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS PAIS]/
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
// USE /[MANUAL GQT AFTER_DEL_JS PAIS]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS PAIS]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS PAIS]/
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
// USE /[MANUAL GQT DLGUPDT PAIS]/
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
// USE /[MANUAL GQT CTRLBLR PAIS]/
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
// USE /[MANUAL GQT CTRLUPD PAIS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS PAIS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
