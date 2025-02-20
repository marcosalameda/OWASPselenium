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
			data-key="PROPPAIS"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.PROPPAISPSEUDNOVOGR02.isVisible">
					<q-control-wrapper
						v-show="controls.PROPPAISPSEUDNOVOGR02.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="PROPPAISPSEUDNOVOGR02"
							v-bind="controls.PROPPAISPSEUDNOVOGR02"
							:is-visible="controls.PROPPAISPSEUDNOVOGR02.isVisible">
							<!-- Start PROPPAISPSEUDNOVOGR02 -->
							<q-row-container v-show="controls.PROPPAISCNTRYCOUNTRY_.isVisible || controls.PROPPAISCNTRYACTIVE__.isVisible || controls.PROPPAISPSEUDNOVOGR01.isVisible">
								<q-control-wrapper
									v-show="controls.PROPPAISCNTRYCOUNTRY_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PROPPAISCNTRYCOUNTRY_"
										v-on="controls.PROPPAISCNTRYCOUNTRY_.handlers"
										:loading="controls.PROPPAISCNTRYCOUNTRY_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.PROPPAISCNTRYCOUNTRY_.props"
											:model-value="model.ValCountry.value"
											@blur="onBlur(controls.PROPPAISCNTRYCOUNTRY_, model.ValCountry.value)"
											@change="model.ValCountry.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PROPPAISCNTRYACTIVE__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.PROPPAISCNTRYACTIVE__"
										v-on="controls.PROPPAISCNTRYACTIVE__.handlers"
										:loading="controls.PROPPAISCNTRYACTIVE__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.PROPPAISCNTRYACTIVE__.isVisible"
												v-bind="controls.PROPPAISCNTRYACTIVE__.props"
												@update:model-value="model.ValActive.fnUpdateValue" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PROPPAISPSEUDNOVOGR01.isVisible"
									class="control-join-group">
									<q-group-collapsible
										id="PROPPAISPSEUDNOVOGR01"
										v-bind="controls.PROPPAISPSEUDNOVOGR01"
										v-on="controls.PROPPAISPSEUDNOVOGR01.handlers">
										<!-- Start PROPPAISPSEUDNOVOGR01 -->
										<q-row-container v-show="controls.PROPPAISCNTRYCODIGONR.isVisible || controls.PROPPAISCNTRYALFA2___.isVisible || controls.PROPPAISCNTRYALFA3___.isVisible">
											<q-control-wrapper
												v-show="controls.PROPPAISCNTRYCODIGONR.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PROPPAISCNTRYCODIGONR"
													v-on="controls.PROPPAISCNTRYCODIGONR.handlers"
													:loading="controls.PROPPAISCNTRYCODIGONR.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-field
														v-bind="controls.PROPPAISCNTRYCODIGONR.props"
														:model-value="model.ValCodigonr.value"
														@blur="onBlur(controls.PROPPAISCNTRYCODIGONR, model.ValCodigonr.value)"
														@change="model.ValCodigonr.fnUpdateValueOnChange" />
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.PROPPAISCNTRYALFA2___.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PROPPAISCNTRYALFA2___"
													v-on="controls.PROPPAISCNTRYALFA2___.handlers"
													:loading="controls.PROPPAISCNTRYALFA2___.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-field
														v-bind="controls.PROPPAISCNTRYALFA2___.props"
														:model-value="model.ValAlfa2.value"
														@blur="onBlur(controls.PROPPAISCNTRYALFA2___, model.ValAlfa2.value)"
														@change="model.ValAlfa2.fnUpdateValueOnChange" />
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.PROPPAISCNTRYALFA3___.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PROPPAISCNTRYALFA3___"
													v-on="controls.PROPPAISCNTRYALFA3___.handlers"
													:loading="controls.PROPPAISCNTRYALFA3___.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-field
														v-bind="controls.PROPPAISCNTRYALFA3___.props"
														:model-value="model.ValAlfa3.value"
														@blur="onBlur(controls.PROPPAISCNTRYALFA3___, model.ValAlfa3.value)"
														@change="model.ValAlfa3.fnUpdateValueOnChange" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<!-- End PROPPAISPSEUDNOVOGR01 -->
									</q-group-collapsible>
								</q-control-wrapper>
							</q-row-container>
							<!-- End PROPPAISPSEUDNOVOGR02 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PROPPAISPSEUDPROPRIED.isVisible">
					<q-control-wrapper
						v-show="controls.PROPPAISPSEUDPROPRIED.isVisible"
						class="control-join-group">
						<q-table
							v-show="controls.PROPPAISPSEUDPROPRIED.isVisible"
							v-bind="controls.PROPPAISPSEUDPROPRIED"
							v-on="controls.PROPPAISPSEUDPROPRIED.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.PROPPAISPSEUDPROPRIED"
							v-on="controls.PROPPAISPSEUDPROPRIED.handlers" />
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

	import FormViewModel from './QFormProppaisViewModel.js'

	const requiredTextResources = ['QFormProppais', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PROPPAIS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormProppais',

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
					name: 'PROPPAIS',
					location: 'form-PROPPAIS',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormProppais', false),

				interfaceMetadata: {
					id: 'QFormProppais', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'PROPPAIS',
					route: 'form-PROPPAIS',
					area: 'CNTRY',
					primaryKey: 'ValCodcntry',
					designation: computed(() => this.Resources.COUNTRY64133),
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
					PROPPAISPSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'PROPPAISPSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'xxlarge',
						label: computed(() => this.Resources.COUNTRY64133),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['PROPPAISCNTRYCOUNTRY_', 'PROPPAISCNTRYACTIVE__', 'PROPPAISPSEUDNOVOGR01'],
						controlLimits: [
						],
					}, this),
					PROPPAISCNTRYCOUNTRY_: new fieldControlClass.StringControl({
						modelField: 'ValCountry',
						valueChangeEvent: 'fieldChange:cntry.country',
						id: 'PROPPAISCNTRYCOUNTRY_',
						name: 'COUNTRY',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESIGNATION_35800),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPPAISPSEUDNOVOGR02',
						maxLength: 90,
						labelId: 'label_PROPPAISCNTRYCOUNTRY_',
						controlLimits: [
						],
					}, this),
					PROPPAISCNTRYACTIVE__: new fieldControlClass.BooleanControl({
						modelField: 'ValActive',
						valueChangeEvent: 'fieldChange:cntry.active',
						id: 'PROPPAISCNTRYACTIVE__',
						name: 'ACTIVE',
						size: 'mini',
						label: computed(() => this.Resources.ACTIVE03270),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'PROPPAISPSEUDNOVOGR02',
						controlLimits: [
						],
					}, this),
					PROPPAISPSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'PROPPAISPSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'xxlarge',
						label: computed(() => this.Resources.COUNTRY_CODE16360),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPPAISPSEUDNOVOGR02',
						isCollapsible: true,
						anchored: false,
						directChildren: ['PROPPAISCNTRYCODIGONR', 'PROPPAISCNTRYALFA2___', 'PROPPAISCNTRYALFA3___'],
						controlLimits: [
						],
					}, this),
					PROPPAISCNTRYCODIGONR: new fieldControlClass.StringControl({
						modelField: 'ValCodigonr',
						valueChangeEvent: 'fieldChange:cntry.codigonr',
						id: 'PROPPAISCNTRYCODIGONR',
						name: 'CODIGONR',
						size: 'mini',
						label: computed(() => this.Resources.NUMERIC19292),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPPAISPSEUDNOVOGR01',
						maxLength: 3,
						labelId: 'label_PROPPAISCNTRYCODIGONR',
						controlLimits: [
						],
					}, this),
					PROPPAISCNTRYALFA2___: new fieldControlClass.StringControl({
						modelField: 'ValAlfa2',
						valueChangeEvent: 'fieldChange:cntry.alfa2',
						id: 'PROPPAISCNTRYALFA2___',
						name: 'ALFA2',
						size: 'small',
						label: computed(() => this.Resources.ALPHABETIC_2_16300),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPPAISPSEUDNOVOGR01',
						maxLength: 2,
						labelId: 'label_PROPPAISCNTRYALFA2___',
						controlLimits: [
						],
					}, this),
					PROPPAISCNTRYALFA3___: new fieldControlClass.StringControl({
						modelField: 'ValAlfa3',
						valueChangeEvent: 'fieldChange:cntry.alfa3',
						id: 'PROPPAISCNTRYALFA3___',
						name: 'ALFA3',
						size: 'small',
						label: computed(() => this.Resources.ALPHABETIC_3_29295),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPPAISPSEUDNOVOGR01',
						maxLength: 3,
						labelId: 'label_PROPPAISCNTRYALFA3___',
						controlLimits: [
						],
					}, this),
					PROPPAISPSEUDPROPRIED: new fieldControlClass.TableListControl({
						id: 'PROPPAISPSEUDPROPRIED',
						name: 'PROPRIED',
						size: 'xxlarge',
						label: computed(() => this.Resources.PROPERTIES34868),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'CNTRY',
						action: 'Proppais_ValPropried',
						hasDependencies: false,
						isInCollapsible: false,
						classes: [
							'c-multiform'
						],
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValName',
								area: 'PROPR',
								field: 'NAME',
								label: computed(() => this.Resources.PROPERTY_NAME18934),
								dataLength: 85,
								scrollData: 30,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 2,
								name: 'ValPrecoest',
								area: 'PROPR',
								field: 'PRECOEST',
								label: computed(() => this.Resources.ESTIMATED_PRICE02986),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 0,
							}),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'Tppro.ValTppropri',
								area: 'TPPRO',
								field: 'TPPROPRI',
								label: computed(() => this.Resources.PROPERTY_TYPE51419),
								dataLength: 20,
								scrollData: 20,
								pkColumn: 'ValCodtppro',
							}),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'Regio.ValRegiao',
								area: 'REGIO',
								field: 'REGIAO',
								label: computed(() => this.Resources.REGION12723),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodregia',
							}),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValLocalida',
								area: 'PROPR',
								field: 'LOCALIDA',
								label: computed(() => this.Resources.LOCALE34521),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'ValEndereco',
								area: 'PROPR',
								field: 'ENDERECO',
								label: computed(() => this.Resources.ADDRESS04342),
								scrollData: 30,
								visibility: false,
							}),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'ValPostalco',
								area: 'PROPR',
								field: 'POSTALCO',
								label: computed(() => this.Resources.ZIP_CODE56964),
								dataLength: 20,
								scrollData: 20,
								visibility: false,
							}),
							new listColumnTypes.TextColumn({
								order: 8,
								name: 'ValPostallo',
								area: 'PROPR',
								field: 'POSTALLO',
								label: computed(() => this.Resources.POSTAL_LOCATION08708),
								dataLength: 50,
								scrollData: 30,
								visibility: false,
							}),
							new listColumnTypes.BooleanColumn({
								order: 9,
								name: 'ValMobilada',
								area: 'PROPR',
								field: 'MOBILADA',
								label: computed(() => this.Resources.FURNISHED37431),
								scrollData: 1,
							}),
							new listColumnTypes.NumericColumn({
								order: 10,
								name: 'ValQtd_wc',
								area: 'PROPR',
								field: 'QTD_WC',
								label: computed(() => this.Resources.BATHROOMS54249),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 11,
								name: 'ValQtdquart',
								area: 'PROPR',
								field: 'QTDQUART',
								label: computed(() => this.Resources.ROOMS06809),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 12,
								name: 'ValM2',
								area: 'PROPR',
								field: 'M2',
								label: computed(() => this.Resources.SQUARE_METERS28913),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}),
							new listColumnTypes.DateColumn({
								order: 13,
								name: 'ValDtdispon',
								area: 'PROPR',
								field: 'DTDISPON',
								label: computed(() => this.Resources.AVAILABILITY56489),
								scrollData: 8,
								dateTimeType: 'date',
							}),
							new listColumnTypes.ImageColumn({
								order: 14,
								name: 'ValPhotogra',
								area: 'PROPR',
								field: 'PHOTOGRA',
								label: computed(() => this.Resources.PHOTO51874),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.PHOTO51874)),
								scrollData: 3,
								sortable: false,
								searchable: false,
							}),
							new listColumnTypes.TextColumn({
								order: 15,
								name: 'ValDescript',
								area: 'PROPR',
								field: 'DESCRIPT',
								label: computed(() => this.Resources.DESCRIPTION07383),
								scrollData: 30,
							}),
						],
						config: {
							name: 'ValPropried',
							serverMode: true,
							pkColumn: 'ValCodpropr',
							tableAlias: 'PROPR',
							tableNamePlural: computed(() => this.Resources.PROPERTIES34868),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.PROPERTIES34868),
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
										canExecuteAction: vm.applyChanges,
										action: vm.openFormAction,
										type: 'form',
										formName: 'PROPRALL',
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
										canExecuteAction: vm.applyChanges,
										action: vm.openFormAction,
										type: 'form',
										formName: 'PROPRALL',
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
										canExecuteAction: vm.applyChanges,
										action: vm.openFormAction,
										type: 'form',
										formName: 'PROPRALL',
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
										canExecuteAction: vm.applyChanges,
										action: vm.openFormAction,
										type: 'form',
										formName: 'PROPRALL',
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
										canExecuteAction: vm.applyChanges,
										action: vm.openFormAction,
										type: 'form',
										formName: 'PROPRALL',
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
								id: 'RCA__PROPRALL',
								name: '_PROPRALL',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									canExecuteAction: vm.applyChanges,
									action: vm.openFormAction,
									type: 'form',
									formName: 'PROPRALL',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'PROPRALL': {
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
						changeEvents: ['changed-REGIO', 'changed-PAIS1', 'changed-CNTRY', 'changed-PESSO', 'changed-PROPR', 'changed-TPPRO'],
						uuid: 'Proppais_ValPropried',
						allSelectedRows: 'false',
						component: 'QFormProprall',
						rowComponent: 'q-form-container',
						formName: 'PROPRALL',
						rowComponentProps: {
							formButtonsOverride: {
								saveBtn: {
									text: computed(() => vm.Resources[hardcodedTexts.save]),
									showInHeader: false,
									emitAction: {
										name: 'deselect',
										params: {}
									}
								},
								resetCancelBtn: {
									isActive: true,
									showInHeader: false,
								},
								editBtn: {
									isActive: true,
									showInHeader: false,
									showInHeading: true,
									text: '',
									style: 'secondary',
									classes: ['q-btn']
								},
								deleteQuickBtn: {
									isActive: true,
									showInHeader: false,
									showInHeading: true,
									text: '',
									style: 'secondary',
									classes: ['q-btn']
								},
								cancelBtn: {
									isActive: false
								},
								backBtn: {
									isActive: false
								},
								confirmBtn: {
									isActive: false
								}
							},
							parentFormMode: computed(() => vm.formInfo.mode)
						},
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
					'PROPPAISPSEUDNOVOGR02',
					'PROPPAISPSEUDNOVOGR01',
				]),

				tableFields: readonly([
					'PROPPAISPSEUDPROPRIED',
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
// USE /[MANUAL GQT FORM_CODEJS PROPPAIS]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS PROPPAIS]/
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
// USE /[MANUAL GQT FORM_LOADED_JS PROPPAIS]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS PROPPAIS]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS PROPPAIS]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS PROPPAIS]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS PROPPAIS]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS PROPPAIS]/
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
// USE /[MANUAL GQT AFTER_DEL_JS PROPPAIS]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS PROPPAIS]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS PROPPAIS]/
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
// USE /[MANUAL GQT DLGUPDT PROPPAIS]/
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
// USE /[MANUAL GQT CTRLBLR PROPPAIS]/
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
// USE /[MANUAL GQT CTRLUPD PROPPAIS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS PROPPAIS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
			// Watchers for changes in the state of tabs and collapsible groups.
			'controls.PROPPAISPSEUDNOVOGR01.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'PROPPAISPSEUDNOVOGR01',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
			// Watcher for changes in the form mode.
			'formInfo.mode'()
			{
				// When changing form mode, set the sub-forms to SHOW mode.
				for (let key in this.controls.PROPPAISPSEUDPROPRIED.rowFormProps)
					this.controls.PROPPAISPSEUDPROPRIED.rowFormProps[key].mode = this.formModes.show
			}
		}
	}
</script>
