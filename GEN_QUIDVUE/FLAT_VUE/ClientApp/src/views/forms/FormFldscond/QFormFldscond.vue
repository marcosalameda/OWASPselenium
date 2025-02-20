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
			data-key="FLDSCOND"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.FLDSCONDFLDS_COND____.isVisible || controls.FLDSCONDPSEUDGROUP4__.isVisible">
					<q-control-wrapper
						v-show="controls.FLDSCONDFLDS_COND____.isVisible || controls.FLDSCONDPSEUDGROUP4__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-radio-container"
							v-bind="controls.FLDSCONDFLDS_COND____"
							v-on="controls.FLDSCONDFLDS_COND____.handlers"
							:label-position="labelAlignment.topleft"
							:loading="controls.FLDSCONDFLDS_COND____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-radio-group
								v-if="controls.FLDSCONDFLDS_COND____.isVisible"
								id="FLDSCONDFLDS_COND____"
								:model-value="model.ValCond.value"
								deselect-radio
								:label-left-side="controls.FLDSCONDFLDS_COND____.labelPosition === labelAlignment.left"
								:number-of-columns="controls.FLDSCONDFLDS_COND____.columnNumber"
								:is-required="controls.FLDSCONDFLDS_COND____.isRequired"
								:readonly="controls.FLDSCONDFLDS_COND____.readonly"
								:options-list="controls.FLDSCONDFLDS_COND____.items"
								@update:model-value="model.ValCond.fnUpdateValue" />
						</base-input-structure>
						<q-group-box-container
							id="FLDSCONDPSEUDGROUP4__"
							v-bind="controls.FLDSCONDPSEUDGROUP4__"
							no-border
							:is-visible="controls.FLDSCONDPSEUDGROUP4__.isVisible">
							<!-- Start FLDSCONDPSEUDGROUP4__ -->
							<q-row-container v-show="controls.FLDSCONDFLDS_TBLCOND_.isVisible">
								<q-control-wrapper
									v-show="controls.FLDSCONDFLDS_TBLCOND_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.FLDSCONDFLDS_TBLCOND_"
										v-on="controls.FLDSCONDFLDS_TBLCOND_.handlers"
										:loading="controls.FLDSCONDFLDS_TBLCOND_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.FLDSCONDFLDS_TBLCOND_.isVisible"
												v-bind="controls.FLDSCONDFLDS_TBLCOND_.props"
												@update:model-value="model.ValTblcond.fnUpdateValue" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.FLDSCONDFLDS_FORMCOND.isVisible">
								<q-control-wrapper
									v-show="controls.FLDSCONDFLDS_FORMCOND.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.FLDSCONDFLDS_FORMCOND"
										v-on="controls.FLDSCONDFLDS_FORMCOND.handlers"
										:loading="controls.FLDSCONDFLDS_FORMCOND.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.FLDSCONDFLDS_FORMCOND.isVisible"
												v-bind="controls.FLDSCONDFLDS_FORMCOND.props"
												@update:model-value="model.ValFormcond.fnUpdateValue" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End FLDSCONDPSEUDGROUP4__ -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.FLDSCONDPSEUDGROUP1__.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.FLDSCONDPSEUDGROUP1__.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="FLDSCONDPSEUDGROUP1__"
							v-bind="controls.FLDSCONDPSEUDGROUP1__"
							:is-visible="controls.FLDSCONDPSEUDGROUP1__.isVisible">
							<!-- Start FLDSCONDPSEUDGROUP1__ -->
							<q-row-container v-show="controls.FLDSCONDFLDS_FCLIENT1.isVisible">
								<q-control-wrapper
									v-show="controls.FLDSCONDFLDS_FCLIENT1.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSCONDFLDS_FCLIENT1"
										v-on="controls.FLDSCONDFLDS_FCLIENT1.handlers"
										:loading="controls.FLDSCONDFLDS_FCLIENT1.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.FLDSCONDFLDS_FCLIENT1.props"
											:model-value="model.ValFclient1.value"
											@blur="onBlur(controls.FLDSCONDFLDS_FCLIENT1, model.ValFclient1.value)"
											@change="model.ValFclient1.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.FLDSCONDFLDS_FFILLWHN.isVisible">
								<q-control-wrapper
									v-show="controls.FLDSCONDFLDS_FFILLWHN.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSCONDFLDS_FFILLWHN"
										v-on="controls.FLDSCONDFLDS_FFILLWHN.handlers"
										:loading="controls.FLDSCONDFLDS_FFILLWHN.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.FLDSCONDFLDS_FFILLWHN.props"
											:model-value="model.ValFfillwhn.value"
											@blur="onBlur(controls.FLDSCONDFLDS_FFILLWHN, model.ValFfillwhn.value)"
											@change="model.ValFfillwhn.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.FLDSCONDFLDS_FSERVER1.isVisible">
								<q-control-wrapper
									v-show="controls.FLDSCONDFLDS_FSERVER1.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSCONDFLDS_FSERVER1"
										v-on="controls.FLDSCONDFLDS_FSERVER1.handlers"
										:loading="controls.FLDSCONDFLDS_FSERVER1.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.FLDSCONDFLDS_FSERVER1.isVisible"
											v-bind="controls.FLDSCONDFLDS_FSERVER1.props"
											:model-value="model.ValFserver1.value"
											@reset-icon-click="model.ValFserver1.fnUpdateValue(model.ValFserver1.originalValue ?? new Date())"
											@update:model-value="model.ValFserver1.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End FLDSCONDPSEUDGROUP1__ -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.FLDSCONDPSEUDGROUP2__.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.FLDSCONDPSEUDGROUP2__.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="FLDSCONDPSEUDGROUP2__"
							v-bind="controls.FLDSCONDPSEUDGROUP2__"
							:is-visible="controls.FLDSCONDPSEUDGROUP2__.isVisible">
							<!-- Start FLDSCONDPSEUDGROUP2__ -->
							<q-row-container v-show="controls.FLDSCONDFLDS_FCLIENT2.isVisible">
								<q-control-wrapper
									v-show="controls.FLDSCONDFLDS_FCLIENT2.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.FLDSCONDFLDS_FCLIENT2"
										v-on="controls.FLDSCONDFLDS_FCLIENT2.handlers"
										:loading="controls.FLDSCONDFLDS_FCLIENT2.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.FLDSCONDFLDS_FCLIENT2.isVisible"
												v-bind="controls.FLDSCONDFLDS_FCLIENT2.props"
												@update:model-value="model.ValFclient2.fnUpdateValue" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.FLDSCONDFLDS_FSERVER2.isVisible">
								<q-control-wrapper
									v-show="controls.FLDSCONDFLDS_FSERVER2.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSCONDFLDS_FSERVER2"
										v-on="controls.FLDSCONDFLDS_FSERVER2.handlers"
										:loading="controls.FLDSCONDFLDS_FSERVER2.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.FLDSCONDFLDS_FSERVER2.isVisible"
											v-bind="controls.FLDSCONDFLDS_FSERVER2.props"
											@update:model-value="model.ValFserver2.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End FLDSCONDPSEUDGROUP2__ -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.FLDSCONDPSEUDGROUP3__.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.FLDSCONDPSEUDGROUP3__.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="FLDSCONDPSEUDGROUP3__"
							v-bind="controls.FLDSCONDPSEUDGROUP3__"
							:is-visible="controls.FLDSCONDPSEUDGROUP3__.isVisible">
							<!-- Start FLDSCONDPSEUDGROUP3__ -->
							<q-row-container v-show="controls.FLDSCONDFLDS_FCLIENT3.isVisible">
								<q-control-wrapper
									v-show="controls.FLDSCONDFLDS_FCLIENT3.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSCONDFLDS_FCLIENT3"
										v-on="controls.FLDSCONDFLDS_FCLIENT3.handlers"
										:loading="controls.FLDSCONDFLDS_FCLIENT3.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-document
											v-if="controls.FLDSCONDFLDS_FCLIENT3.isVisible"
											v-bind="controls.FLDSCONDFLDS_FCLIENT3.props"
											v-on="controls.FLDSCONDFLDS_FCLIENT3.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.FLDSCONDFLDS_FSERVER3.isVisible">
								<q-control-wrapper
									v-show="controls.FLDSCONDFLDS_FSERVER3.isVisible"
									class="control-join-group">
									<base-input-structure
										class="q-image"
										v-bind="controls.FLDSCONDFLDS_FSERVER3"
										v-on="controls.FLDSCONDFLDS_FSERVER3.handlers"
										:loading="controls.FLDSCONDFLDS_FSERVER3.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-image
											v-if="controls.FLDSCONDFLDS_FSERVER3.isVisible"
											v-bind="controls.FLDSCONDFLDS_FSERVER3.props"
											v-on="controls.FLDSCONDFLDS_FSERVER3.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End FLDSCONDPSEUDGROUP3__ -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.FLDSCONDPSEUDGROUP5__.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.FLDSCONDPSEUDGROUP5__.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="FLDSCONDPSEUDGROUP5__"
							v-bind="controls.FLDSCONDPSEUDGROUP5__"
							:is-visible="controls.FLDSCONDPSEUDGROUP5__.isVisible">
							<!-- Start FLDSCONDPSEUDGROUP5__ -->
							<q-row-container v-show="controls.FLDSCONDPSEUDSTATICTX.isVisible">
								<q-control-wrapper
									v-show="controls.FLDSCONDPSEUDSTATICTX.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-static-text"
										v-bind="controls.FLDSCONDPSEUDSTATICTX"
										v-on="controls.FLDSCONDPSEUDSTATICTX.handlers"
										:loading="controls.FLDSCONDPSEUDSTATICTX.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-static-text
											v-if="controls.FLDSCONDPSEUDSTATICTX.isVisible"
											id="FLDSCONDPSEUDSTATICTX"
											:size="controls.FLDSCONDPSEUDSTATICTX.size"
											:text="controls.FLDSCONDPSEUDSTATICTX.label" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.FLDSCONDPSEUDGRIDTBL_.isVisible || controls.FLDSCONDPSEUDLISTTBL_.isVisible">
								<q-control-wrapper
									v-show="controls.FLDSCONDPSEUDGRIDTBL_.isVisible || controls.FLDSCONDPSEUDLISTTBL_.isVisible"
									class="control-join-group">
									<q-grid-table-list
										v-show="controls.FLDSCONDPSEUDGRIDTBL_.isVisible"
										v-bind="controls.FLDSCONDPSEUDGRIDTBL_"
										v-on="controls.FLDSCONDPSEUDGRIDTBL_.handlers" />
									<q-table
										v-show="controls.FLDSCONDPSEUDLISTTBL_.isVisible"
										v-bind="controls.FLDSCONDPSEUDLISTTBL_"
										v-on="controls.FLDSCONDPSEUDLISTTBL_.handlers" />
									<q-table-extra-extension
										:list-ctrl="controls.FLDSCONDPSEUDLISTTBL_"
										v-on="controls.FLDSCONDPSEUDLISTTBL_.handlers" />
								</q-control-wrapper>
							</q-row-container>
							<!-- End FLDSCONDPSEUDGROUP5__ -->
						</q-group-box-container>
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

	import FormViewModel from './QFormFldscondViewModel.js'

	const requiredTextResources = ['QFormFldscond', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS FLDSCOND]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormFldscond',

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
					name: 'FLDSCOND',
					location: 'form-FLDSCOND',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormFldscond', false),

				interfaceMetadata: {
					id: 'QFormFldscond', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'FLDSCOND',
					route: 'form-FLDSCOND',
					area: 'FLDS',
					primaryKey: 'ValCodflds',
					designation: computed(() => this.Resources.CONDICOES_DE_MOSTRA_10663),
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
					applyBtn: {
						id: 'apply-btn',
						icon: {
							icon: 'apply',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.apply]),
						style: 'secondary',
						classes: [],
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						disabled: false,
						action: () => vm.applyChanges(true)
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
						text: computed(() => vm.Resources.GRAVAR45301),
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
						text: computed(() => vm.Resources.CANCELAR49513),
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
					FLDSCONDFLDS_COND____: new fieldControlClass.ArrayStringControl({
						modelField: 'ValCond',
						valueChangeEvent: 'fieldChange:flds.cond',
						id: 'FLDSCONDFLDS_COND____',
						name: 'COND',
						size: 'medium',
						label: computed(() => this.Resources.FIELD_STATE03599),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 8,
						labelId: 'label_FLDSCONDFLDS_COND____',
						arrayName: 'aCondTst',
						columnNumber: 1,
						controlLimits: [
						],
					}, this),
					FLDSCONDPSEUDGROUP4__: new fieldControlClass.GroupControl({
						id: 'FLDSCONDPSEUDGROUP4__',
						name: 'GROUP4',
						size: 'mini',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['FLDSCONDFLDS_TBLCOND_', 'FLDSCONDFLDS_FORMCOND'],
						controlLimits: [
						],
					}, this),
					FLDSCONDFLDS_TBLCOND_: new fieldControlClass.BooleanControl({
						modelField: 'ValTblcond',
						valueChangeEvent: 'fieldChange:flds.tblcond',
						id: 'FLDSCONDFLDS_TBLCOND_',
						name: 'TBLCOND',
						size: 'xlarge',
						label: computed(() => this.Resources.CUMPRIR_CONDICOES_DA06337),
						placeholder: '',
						labelPosition: computed(() => this.layoutConfig.CheckboxLabelAlignment),
						container: 'FLDSCONDPSEUDGROUP4__',
						controlLimits: [
						],
					}, this),
					FLDSCONDFLDS_FORMCOND: new fieldControlClass.BooleanControl({
						modelField: 'ValFormcond',
						valueChangeEvent: 'fieldChange:flds.formcond',
						id: 'FLDSCONDFLDS_FORMCOND',
						name: 'FORMCOND',
						size: 'xlarge',
						label: computed(() => this.Resources.CUMPRIR_CONDICOES_DO41487),
						placeholder: '',
						labelPosition: computed(() => this.layoutConfig.CheckboxLabelAlignment),
						container: 'FLDSCONDPSEUDGROUP4__',
						controlLimits: [
						],
					}, this),
					FLDSCONDPSEUDGROUP1__: new fieldControlClass.GroupControl({
						id: 'FLDSCONDPSEUDGROUP1__',
						name: 'GROUP1',
						size: 'block',
						label: computed(() => this.Resources.CAMPOS_COM_CONDICOES38548),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['FLDSCONDFLDS_FCLIENT1', 'FLDSCONDFLDS_FFILLWHN', 'FLDSCONDFLDS_FSERVER1'],
						controlLimits: [
						],
					}, this),
					FLDSCONDFLDS_FCLIENT1: new fieldControlClass.StringControl({
						modelField: 'ValFclient1',
						valueChangeEvent: 'fieldChange:flds.fclient1',
						id: 'FLDSCONDFLDS_FCLIENT1',
						name: 'FCLIENT1',
						size: 'xlarge',
						label: computed(() => this.Resources.CAMPO_COM_CONDICOES_42569),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSCONDPSEUDGROUP1__',
						maxLength: 50,
						labelId: 'label_FLDSCONDFLDS_FCLIENT1',
						controlLimits: [
						],
						requiredConditions: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: !isEmptyL([FLDS->TBLCOND]) && [FLDS->COND] == "REQUIRE"
								if (!((this.ValTblcond.value ? 1 : 0) === 0)&&this.ValCond.value==="REQUIRE")
									return true
								return false
							},
							dependencyEvents: ['fieldChange:flds.tblcond', 'fieldChange:flds.cond'],
							isServerRecalc: false,
						},
					}, this),
					FLDSCONDFLDS_FFILLWHN: new fieldControlClass.StringControl({
						modelField: 'ValFfillwhn',
						valueChangeEvent: 'fieldChange:flds.ffillwhn',
						id: 'FLDSCONDFLDS_FFILLWHN',
						name: 'FFILLWHN',
						size: 'xxlarge',
						label: computed(() => this.Resources.CAMPO_COM_CONDICAO_D59708),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSCONDPSEUDGROUP1__',
						maxLength: 50,
						labelId: 'label_FLDSCONDFLDS_FFILLWHN',
						controlLimits: [
						],
					}, this),
					FLDSCONDFLDS_FSERVER1: new fieldControlClass.DateControl({
						modelField: 'ValFserver1',
						valueChangeEvent: 'fieldChange:flds.fserver1',
						id: 'FLDSCONDFLDS_FSERVER1',
						name: 'FSERVER1',
						size: 'xlarge',
						label: computed(() => this.Resources.CAMPO_COM_CONDICOES_22485),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSCONDPSEUDGROUP1__',
						format: 'dateTime',
						controlLimits: [
						],
						requiredConditions: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								return netAPI.postData(
									'Flds',
									'FLDSCOND_FLDSCONDFLDS_FSERVER1_RequiredCondition',
									this.serverObjModel,
									undefined,
									undefined,
									undefined,
									this.navigationId)
							},
							dependencyEvents: ['fieldChange:flds.tblcond', 'fieldChange:flds.cond'],
							isServerRecalc: false,
						},
					}, this),
					FLDSCONDPSEUDGROUP2__: new fieldControlClass.GroupControl({
						id: 'FLDSCONDPSEUDGROUP2__',
						name: 'GROUP2',
						size: 'block',
						label: computed(() => this.Resources.CAMPOS_COM_CONDICOES25291),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['FLDSCONDFLDS_FCLIENT2', 'FLDSCONDFLDS_FSERVER2'],
						controlLimits: [
						],
					}, this),
					FLDSCONDFLDS_FCLIENT2: new fieldControlClass.BooleanControl({
						modelField: 'ValFclient2',
						valueChangeEvent: 'fieldChange:flds.fclient2',
						id: 'FLDSCONDFLDS_FCLIENT2',
						name: 'FCLIENT2',
						size: 'xlarge',
						label: computed(() => this.Resources.CAMPO_COM_CONDICOES_42569),
						placeholder: '',
						labelPosition: computed(() => this.layoutConfig.CheckboxLabelAlignment),
						container: 'FLDSCONDPSEUDGROUP2__',
						controlLimits: [
						],
						blockWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: !isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "BLOCK"
								return !((this.ValFormcond.value ? 1 : 0) === 0)&&this.ValCond.value==="BLOCK"
							},
							dependencyEvents: ['fieldChange:flds.formcond', 'fieldChange:flds.cond'],
							isServerRecalc: false,
						},
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: !(!isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "HIDE")
								return !(!((this.ValFormcond.value ? 1 : 0) === 0)&&this.ValCond.value==="HIDE")
							},
							dependencyEvents: ['fieldChange:flds.formcond', 'fieldChange:flds.cond'],
							isServerRecalc: false,
						},
						requiredConditions: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: !isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "REQUIRE"
								if (!((this.ValFormcond.value ? 1 : 0) === 0)&&this.ValCond.value==="REQUIRE")
									return true
								return false
							},
							dependencyEvents: ['fieldChange:flds.formcond', 'fieldChange:flds.cond'],
							isServerRecalc: false,
						},
					}, this),
					FLDSCONDFLDS_FSERVER2: new fieldControlClass.NumberControl({
						modelField: 'ValFserver2',
						valueChangeEvent: 'fieldChange:flds.fserver2',
						id: 'FLDSCONDFLDS_FSERVER2',
						name: 'FSERVER2',
						size: 'xlarge',
						label: computed(() => this.Resources.CAMPO_COM_CONDICOES_22485),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSCONDPSEUDGROUP2__',
						maxIntegers: 5,
						maxDecimals: 2,
						controlLimits: [
						],
						blockWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								return netAPI.postData(
									'Flds',
									'FLDSCOND_FLDSCONDFLDS_FSERVER2_BlockWhen',
									this.serverObjModel,
									undefined,
									undefined,
									undefined,
									this.navigationId)
							},
							dependencyEvents: ['fieldChange:flds.formcond', 'fieldChange:flds.cond'],
							isServerRecalc: false,
						},
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								return netAPI.postData(
									'Flds',
									'FLDSCOND_FLDSCONDFLDS_FSERVER2_ShowWhen',
									this.serverObjModel,
									undefined,
									undefined,
									undefined,
									this.navigationId)
							},
							dependencyEvents: ['fieldChange:flds.formcond', 'fieldChange:flds.cond'],
							isServerRecalc: false,
						},
						requiredConditions: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								return netAPI.postData(
									'Flds',
									'FLDSCOND_FLDSCONDFLDS_FSERVER2_RequiredCondition',
									this.serverObjModel,
									undefined,
									undefined,
									undefined,
									this.navigationId)
							},
							dependencyEvents: ['fieldChange:flds.formcond', 'fieldChange:flds.cond'],
							isServerRecalc: false,
						},
					}, this),
					FLDSCONDPSEUDGROUP3__: new fieldControlClass.GroupControl({
						id: 'FLDSCONDPSEUDGROUP3__',
						name: 'GROUP3',
						size: 'block',
						label: computed(() => this.Resources.CAMPOS_COM_CONDICOES34674),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['FLDSCONDFLDS_FCLIENT3', 'FLDSCONDFLDS_FSERVER3'],
						controlLimits: [
						],
					}, this),
					FLDSCONDFLDS_FCLIENT3: new fieldControlClass.DocumentControl({
						modelField: 'ValFclient3',
						valueChangeEvent: 'fieldChange:flds.fclient3',
						id: 'FLDSCONDFLDS_FCLIENT3',
						name: 'FCLIENT3',
						size: 'xlarge',
						label: computed(() => this.Resources.CAMPO_COM_CONDICOES_42569),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSCONDPSEUDGROUP3__',
						extensions: [],
						maxFileSize: 10485760, // In bytes.
						maxFileSizeLabel: '10 MB',
						controlLimits: [
						],
						blockWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: !isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "BLOCK"
								return !((this.ValFormcond.value ? 1 : 0) === 0)&&this.ValCond.value==="BLOCK"
							},
							dependencyEvents: ['fieldChange:flds.formcond', 'fieldChange:flds.cond'],
							isServerRecalc: false,
						},
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: !(!isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "HIDE")
								return !(!((this.ValFormcond.value ? 1 : 0) === 0)&&this.ValCond.value==="HIDE")
							},
							dependencyEvents: ['fieldChange:flds.formcond', 'fieldChange:flds.cond'],
							isServerRecalc: false,
						},
						requiredConditions: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: !isEmptyL([FLDS->TBLCOND]) && [FLDS->COND] == "REQUIRE"
								if (!((this.ValTblcond.value ? 1 : 0) === 0)&&this.ValCond.value==="REQUIRE")
									return true
								// Formula: !isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "REQUIRE"
								if (!((this.ValFormcond.value ? 1 : 0) === 0)&&this.ValCond.value==="REQUIRE")
									return true
								return false
							},
							dependencyEvents: ['fieldChange:flds.tblcond', 'fieldChange:flds.cond', 'fieldChange:flds.formcond'],
							isServerRecalc: false,
						},
					}, this),
					FLDSCONDFLDS_FSERVER3: new fieldControlClass.ImageControl({
						modelField: 'ValFserver3',
						valueChangeEvent: 'fieldChange:flds.fserver3',
						id: 'FLDSCONDFLDS_FSERVER3',
						name: 'FSERVER3',
						size: 'mini',
						label: computed(() => this.Resources.CAMPO_COM_CONDICOES_22485),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSCONDPSEUDGROUP3__',
						height: 100,
						width: 30,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.CAMPO_COM_CONDICOES_22485)),
						maxFileSize: 10485760, // In bytes.
						maxFileSizeLabel: '10 MB',
						controlLimits: [
						],
						blockWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								return netAPI.postData(
									'Flds',
									'FLDSCOND_FLDSCONDFLDS_FSERVER3_BlockWhen',
									this.serverObjModel,
									undefined,
									undefined,
									undefined,
									this.navigationId)
							},
							dependencyEvents: ['fieldChange:flds.formcond', 'fieldChange:flds.cond'],
							isServerRecalc: false,
						},
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								return netAPI.postData(
									'Flds',
									'FLDSCOND_FLDSCONDFLDS_FSERVER3_ShowWhen',
									this.serverObjModel,
									undefined,
									undefined,
									undefined,
									this.navigationId)
							},
							dependencyEvents: ['fieldChange:flds.formcond', 'fieldChange:flds.cond'],
							isServerRecalc: false,
						},
						requiredConditions: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								return netAPI.postData(
									'Flds',
									'FLDSCOND_FLDSCONDFLDS_FSERVER3_RequiredCondition',
									this.serverObjModel,
									undefined,
									undefined,
									undefined,
									this.navigationId)
							},
							dependencyEvents: ['fieldChange:flds.tblcond', 'fieldChange:flds.cond', 'fieldChange:flds.formcond'],
							isServerRecalc: false,
						},
					}, this),
					FLDSCONDPSEUDGROUP5__: new fieldControlClass.GroupControl({
						id: 'FLDSCONDPSEUDGROUP5__',
						name: 'GROUP5',
						size: 'block',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['FLDSCONDPSEUDSTATICTX', 'FLDSCONDPSEUDGRIDTBL_', 'FLDSCONDPSEUDLISTTBL_', 'FLDSCONDPSEUDLISTBTN_'],
						controlLimits: [
						],
					}, this),
					FLDSCONDPSEUDSTATICTX: new fieldControlClass.BaseControl({
						id: 'FLDSCONDPSEUDSTATICTX',
						name: 'STATICTX',
						size: 'mini',
						hasLabel: false,
						label: computed(() => this.Resources.TEST37369),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSCONDPSEUDGROUP5__',
						controlLimits: [
						],
						blockWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								return netAPI.postData(
									'Flds',
									'FLDSCOND_FLDSCONDPSEUDSTATICTX_BlockWhen',
									this.serverObjModel,
									undefined,
									undefined,
									undefined,
									this.navigationId)
							},
							dependencyEvents: ['fieldChange:flds.formcond', 'fieldChange:flds.cond'],
							isServerRecalc: false,
						},
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								return netAPI.postData(
									'Flds',
									'FLDSCOND_FLDSCONDPSEUDSTATICTX_ShowWhen',
									this.serverObjModel,
									undefined,
									undefined,
									undefined,
									this.navigationId)
							},
							dependencyEvents: ['fieldChange:flds.formcond', 'fieldChange:flds.cond'],
							isServerRecalc: false,
						},
					}, this),
					FLDSCONDPSEUDGRIDTBL_: new fieldControlClass.GridTableListControl({
						id: 'FLDSCONDPSEUDGRIDTBL_',
						name: 'GRIDTBL',
						size: '',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSCONDPSEUDGROUP5__',
						controller: 'FLDS',
						action: 'Fldscond_ValGridtbl',
						modelField: 'ValGridtbl',
						component: 'q-grid-form-fldscondpseudgridtbl',
						permissions: {
						},
						columns: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValFeedback',
								area: 'FEECA',
								field: 'FEEDBACK',
								label: computed(() => this.Resources.FEEDBACK52855),
								dataLength: 50,
								scrollData: 30,
							}),
						],
						controlLimits: [
							{
								identifier: ['id', 'flds'],
								dependencyEvents: ['fieldChange:flds.codflds'],
								dependencyField: 'FLDS.CODFLDS',
								fnValueSelector: (model) => model.ValCodflds.value
							},
						],
						blockWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: !isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "BLOCK"
								return !((this.ValFormcond.value ? 1 : 0) === 0)&&this.ValCond.value==="BLOCK"
							},
							dependencyEvents: ['fieldChange:flds.formcond', 'fieldChange:flds.cond'],
							isServerRecalc: false,
						},
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: !(!isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "HIDE")
								return !(!((this.ValFormcond.value ? 1 : 0) === 0)&&this.ValCond.value==="HIDE")
							},
							dependencyEvents: ['fieldChange:flds.formcond', 'fieldChange:flds.cond'],
							isServerRecalc: false,
						},
					}, this),
					FLDSCONDPSEUDLISTTBL_: new fieldControlClass.TableListControl({
						id: 'FLDSCONDPSEUDLISTTBL_',
						name: 'LISTTBL',
						size: '',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSCONDPSEUDGROUP5__',
						controller: 'FLDS',
						action: 'Fldscond_ValListtbl',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValFeedback',
								area: 'FEECA',
								field: 'FEEDBACK',
								label: computed(() => this.Resources.FEEDBACK52855),
								dataLength: 50,
								scrollData: 30,
							}),
						],
						config: {
							name: 'ValListtbl',
							serverMode: true,
							pkColumn: 'ValCodfeeca',
							tableAlias: 'FEECA',
							tableNamePlural: computed(() => this.Resources.FIELD_FEEDBACK53085),
							viewManagement: '',
							showLimitsInfo: true,
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
										formName: 'FEECA',
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
										formName: 'FEECA',
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
										formName: 'FEECA',
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
										formName: 'FEECA',
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
										formName: 'FEECA',
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
								{
									id: 'BE_LISTBTN',
									name: 'LISTBTN',
									title: computed(() => this.Resources.TEST37369),
									isInReadOnly: true,
									isVisible: computed(() => vm.controls.FLDSCONDPSEUDLISTBTN_.isVisible),
									disabled: computed(() => vm.controls.FLDSCONDPSEUDLISTBTN_.isBlocked),
									params: {
										action: (c, o, d) => vm.controls.FLDSCONDPSEUDLISTBTN_.action(d || c),
										isControlled: true,
										isRoute: true
									}
								},
							],
							MCActions: [
							],
							rowClickAction: {
								id: 'RCA__FEECA',
								name: '_FEECA',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'FEECA',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'FEECA': {
									fnKeySelector: (row) => row.Fields.ValCodfeeca,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValFeedback',
							defaultSearchColumnNameOriginal: 'ValFeedback',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-FLDS', 'changed-FEECA'],
						uuid: 'Fldscond_ValListtbl',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'flds'],
								dependencyEvents: ['fieldChange:flds.codflds'],
								dependencyField: 'FLDS.CODFLDS',
								fnValueSelector: (model) => model.ValCodflds.value
							},
						],
						blockWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: !isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "BLOCK"
								return !((this.ValFormcond.value ? 1 : 0) === 0)&&this.ValCond.value==="BLOCK"
							},
							dependencyEvents: ['fieldChange:flds.formcond', 'fieldChange:flds.cond'],
							isServerRecalc: false,
						},
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: !(!isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "HIDE")
								return !(!((this.ValFormcond.value ? 1 : 0) === 0)&&this.ValCond.value==="HIDE")
							},
							dependencyEvents: ['fieldChange:flds.formcond', 'fieldChange:flds.cond'],
							isServerRecalc: false,
						},
					}, this),
					FLDSCONDPSEUDLISTBTN_: new fieldControlClass.ButtonControl({
						id: 'FLDSCONDPSEUDLISTBTN_',
						name: 'LISTBTN',
						size: 'mini',
						hasLabel: false,
						label: computed(() => this.Resources.TEST37369),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSCONDPSEUDGROUP5__',
						// eslint-disable-next-line
						action: (event) => {
							let btnAction = () => {
								const params = {
									id: event?.rowKey,
									mode: vm.formModes.edit,
									modes: 'vedai',
									isControlled: false,
									extraData: JSON.stringify(event)
								}

								vm.navigateToForm('FEECA', params.mode, event?.rowKey, params)
							}
							btnAction()
						},
						controlLimits: [
						],
						blockWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								return netAPI.postData(
									'Flds',
									'FLDSCOND_FLDSCONDPSEUDLISTBTN__BlockWhen',
									this.serverObjModel,
									undefined,
									undefined,
									undefined,
									this.navigationId)
							},
							dependencyEvents: ['fieldChange:flds.formcond', 'fieldChange:flds.cond'],
							isServerRecalc: false,
						},
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								return netAPI.postData(
									'Flds',
									'FLDSCOND_FLDSCONDPSEUDLISTBTN__ShowWhen',
									this.serverObjModel,
									undefined,
									undefined,
									undefined,
									this.navigationId)
							},
							dependencyEvents: ['fieldChange:flds.formcond', 'fieldChange:flds.cond'],
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
					'FLDSCONDPSEUDGROUP4__',
					'FLDSCONDPSEUDGROUP1__',
					'FLDSCONDPSEUDGROUP2__',
					'FLDSCONDPSEUDGROUP3__',
					'FLDSCONDPSEUDGROUP5__',
				]),

				tableFields: readonly([
					'FLDSCONDPSEUDGRIDTBL_',
					'FLDSCONDPSEUDLISTTBL_',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Flds: {
						get ValCodaero() { return vm.model.ValCodaero.value },
						set ValCodaero(value) { vm.model.ValCodaero.updateValue(value) },
						get ValCodequip() { return vm.model.ValCodequip.value },
						set ValCodequip(value) { vm.model.ValCodequip.updateValue(value) },
						get ValCond() { return vm.model.ValCond.value },
						set ValCond(value) { vm.model.ValCond.updateValue(value) },
						get ValDescrip() { return vm.model.ValDescrip.value },
						set ValDescrip(value) { vm.model.ValDescrip.updateValue(value) },
						get ValFclient1() { return vm.model.ValFclient1.value },
						set ValFclient1(value) { vm.model.ValFclient1.updateValue(value) },
						get ValFclient2() { return vm.model.ValFclient2.value },
						set ValFclient2(value) { vm.model.ValFclient2.updateValue(value) },
						get ValFclient3() { return vm.model.ValFclient3.value },
						set ValFclient3(value) { vm.model.ValFclient3.updateValue(value) },
						get ValFfillwhn() { return vm.model.ValFfillwhn.value },
						set ValFfillwhn(value) { vm.model.ValFfillwhn.updateValue(value) },
						get ValFormcond() { return vm.model.ValFormcond.value },
						set ValFormcond(value) { vm.model.ValFormcond.updateValue(value) },
						get ValFserver1() { return vm.model.ValFserver1.value },
						set ValFserver1(value) { vm.model.ValFserver1.updateValue(value) },
						get ValFserver2() { return vm.model.ValFserver2.value },
						set ValFserver2(value) { vm.model.ValFserver2.updateValue(value) },
						get ValFserver3() { return vm.model.ValFserver3.value },
						set ValFserver3(value) { vm.model.ValFserver3.updateValue(value) },
						get ValTblcond() { return vm.model.ValTblcond.value },
						set ValTblcond(value) { vm.model.ValTblcond.updateValue(value) },
					},
					keys: {
						/** The primary key of the FLDS table */
						get flds() { return vm.model.ValCodflds },
						/** The foreign key to the AERO table */
						get aero() { return vm.model.ValCodaero },
						/** The foreign key to the EQUIP table */
						get equip() { return vm.model.ValCodequip },
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
// USE /[MANUAL GQT FORM_CODEJS FLDSCOND]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS FLDSCOND]/
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
// USE /[MANUAL GQT FORM_LOADED_JS FLDSCOND]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS FLDSCOND]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS FLDSCOND]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS FLDSCOND]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS FLDSCOND]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS FLDSCOND]/
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
// USE /[MANUAL GQT AFTER_DEL_JS FLDSCOND]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS FLDSCOND]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS FLDSCOND]/
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
// USE /[MANUAL GQT DLGUPDT FLDSCOND]/
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
// USE /[MANUAL GQT CTRLBLR FLDSCOND]/
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
// USE /[MANUAL GQT CTRLUPD FLDSCOND]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS FLDSCOND]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
