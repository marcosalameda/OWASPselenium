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
			data-key="PERSO"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.PERSO___PSEUDNOVOGR01.isVisible">
					<q-control-wrapper
						v-show="controls.PERSO___PSEUDNOVOGR01.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="PERSO___PSEUDNOVOGR01"
							v-bind="controls.PERSO___PSEUDNOVOGR01"
							:is-visible="controls.PERSO___PSEUDNOVOGR01.isVisible">
							<!-- Start PERSO___PSEUDNOVOGR01 -->
							<q-row-container v-show="controls.PERSO___PSEUDNOVOGR04.isVisible || controls.PERSO___PSEUDNOVOGR05.isVisible">
								<q-control-wrapper
									v-show="controls.PERSO___PSEUDNOVOGR04.isVisible"
									class="control-join-group">
									<q-group-box-container
										id="PERSO___PSEUDNOVOGR04"
										v-bind="controls.PERSO___PSEUDNOVOGR04"
										no-border
										:is-visible="controls.PERSO___PSEUDNOVOGR04.isVisible">
										<!-- Start PERSO___PSEUDNOVOGR04 -->
										<q-row-container v-show="controls.PERSO___PERSOPHOTO___.isVisible">
											<q-control-wrapper
												v-show="controls.PERSO___PERSOPHOTO___.isVisible"
												class="control-join-group">
												<base-input-structure
													class="q-image"
													v-bind="controls.PERSO___PERSOPHOTO___"
													v-on="controls.PERSO___PERSOPHOTO___.handlers"
													:loading="controls.PERSO___PERSOPHOTO___.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-image
														v-if="controls.PERSO___PERSOPHOTO___.isVisible"
														v-bind="controls.PERSO___PERSOPHOTO___.props"
														v-on="controls.PERSO___PERSOPHOTO___.handlers" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<!-- End PERSO___PSEUDNOVOGR04 -->
									</q-group-box-container>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PERSO___PSEUDNOVOGR05.isVisible"
									class="control-join-group">
									<q-group-box-container
										id="PERSO___PSEUDNOVOGR05"
										v-bind="controls.PERSO___PSEUDNOVOGR05"
										no-border
										:is-visible="controls.PERSO___PSEUDNOVOGR05.isVisible">
										<!-- Start PERSO___PSEUDNOVOGR05 -->
										<q-row-container v-show="controls.PERSO___PERSONAME____.isVisible">
											<q-control-wrapper
												v-show="controls.PERSO___PERSONAME____.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PERSO___PERSONAME____"
													v-on="controls.PERSO___PERSONAME____.handlers"
													:loading="controls.PERSO___PERSONAME____.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-field
														v-bind="controls.PERSO___PERSONAME____.props"
														:model-value="model.ValName.value"
														@blur="onBlur(controls.PERSO___PERSONAME____, model.ValName.value)"
														@change="model.ValName.fnUpdateValueOnChange" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.PERSO___PERSOIDENTIFI.isVisible">
											<q-control-wrapper
												v-show="controls.PERSO___PERSOIDENTIFI.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PERSO___PERSOIDENTIFI"
													v-on="controls.PERSO___PERSOIDENTIFI.handlers"
													:loading="controls.PERSO___PERSOIDENTIFI.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-field
														v-bind="controls.PERSO___PERSOIDENTIFI.props"
														:model-value="model.ValIdentifi.value"
														@blur="onBlur(controls.PERSO___PERSOIDENTIFI, model.ValIdentifi.value)"
														@change="model.ValIdentifi.fnUpdateValueOnChange" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.PERSO___PERSOGENDER__.isVisible">
											<q-control-wrapper
												v-show="controls.PERSO___PERSOGENDER__.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PERSO___PERSOGENDER__"
													v-on="controls.PERSO___PERSOGENDER__.handlers"
													:loading="controls.PERSO___PERSOGENDER__.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-select
														v-if="controls.PERSO___PERSOGENDER__.isVisible"
														v-bind="controls.PERSO___PERSOGENDER__.props"
														:model-value="model.ValGender.value"
														@update:model-value="model.ValGender.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.PERSO___PERSOEMAIL___.isVisible">
											<q-control-wrapper
												v-show="controls.PERSO___PERSOEMAIL___.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PERSO___PERSOEMAIL___"
													v-on="controls.PERSO___PERSOEMAIL___.handlers"
													:loading="controls.PERSO___PERSOEMAIL___.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-field
														v-bind="controls.PERSO___PERSOEMAIL___.props"
														:model-value="model.ValEmail.value"
														@blur="onBlur(controls.PERSO___PERSOEMAIL___, model.ValEmail.value)"
														@change="model.ValEmail.fnUpdateValueOnChange" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<!-- End PERSO___PSEUDNOVOGR05 -->
									</q-group-box-container>
								</q-control-wrapper>
							</q-row-container>
							<!-- End PERSO___PSEUDNOVOGR01 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PERSO___PSEUDNOVOGR02.isVisible">
					<q-control-wrapper
						v-show="controls.PERSO___PSEUDNOVOGR02.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="PERSO___PSEUDNOVOGR02"
							v-bind="controls.PERSO___PSEUDNOVOGR02"
							:is-visible="controls.PERSO___PSEUDNOVOGR02.isVisible">
							<!-- Start PERSO___PSEUDNOVOGR02 -->
							<q-row-container v-show="controls.PERSO___PERSODOB_____.isVisible || controls.PERSO___PERSOTOB_____.isVisible || controls.PERSO___PERSOYEAR____.isVisible || controls.PERSO___PERSOMONTH___.isVisible">
								<q-control-wrapper
									v-show="controls.PERSO___PERSODOB_____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PERSO___PERSODOB_____"
										v-on="controls.PERSO___PERSODOB_____.handlers"
										:loading="controls.PERSO___PERSODOB_____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.PERSO___PERSODOB_____.isVisible"
											v-bind="controls.PERSO___PERSODOB_____.props"
											:model-value="model.ValDob.value"
											@reset-icon-click="model.ValDob.fnUpdateValue(model.ValDob.originalValue ?? new Date())"
											@update:model-value="model.ValDob.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PERSO___PERSOTOB_____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PERSO___PERSOTOB_____"
										v-on="controls.PERSO___PERSOTOB_____.handlers"
										:loading="controls.PERSO___PERSOTOB_____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.PERSO___PERSOTOB_____.isVisible"
											v-bind="controls.PERSO___PERSOTOB_____.props"
											:model-value="model.ValTob.value"
											@reset-icon-click="model.ValTob.fnUpdateValue(model.ValTob.originalValue ?? new Date())"
											@update:model-value="model.ValTob.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PERSO___PERSOYEAR____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PERSO___PERSOYEAR____"
										v-on="controls.PERSO___PERSOYEAR____.handlers"
										:loading="controls.PERSO___PERSOYEAR____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.PERSO___PERSOYEAR____.isVisible"
											v-bind="controls.PERSO___PERSOYEAR____.props"
											@update:model-value="model.ValYear.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PERSO___PERSOMONTH___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PERSO___PERSOMONTH___"
										v-on="controls.PERSO___PERSOMONTH___.handlers"
										:loading="controls.PERSO___PERSOMONTH___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.PERSO___PERSOMONTH___.isVisible"
											v-bind="controls.PERSO___PERSOMONTH___.props"
											:model-value="model.ValMonth.value"
											@update:model-value="model.ValMonth.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End PERSO___PSEUDNOVOGR02 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PERSO___PERSOCREATUSR.isVisible || controls.PERSO___PERSOCREATDAT.isVisible || controls.PERSO___PERSOMODIFUSR.isVisible || controls.PERSO___PERSOMODIFDAT.isVisible">
					<q-control-wrapper
						v-show="controls.PERSO___PERSOCREATUSR.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PERSO___PERSOCREATUSR"
							v-on="controls.PERSO___PERSOCREATUSR.handlers"
							:loading="controls.PERSO___PERSOCREATUSR.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.PERSO___PERSOCREATUSR.props"
								:model-value="model.ValCreatusr.value" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.PERSO___PERSOCREATDAT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PERSO___PERSOCREATDAT"
							v-on="controls.PERSO___PERSOCREATDAT.handlers"
							:loading="controls.PERSO___PERSOCREATDAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.PERSO___PERSOCREATDAT.isVisible"
								v-bind="controls.PERSO___PERSOCREATDAT.props"
								:model-value="model.ValCreatdat.value"
								@reset-icon-click="model.ValCreatdat.fnUpdateValue(model.ValCreatdat.originalValue ?? new Date())"
								@update:model-value="model.ValCreatdat.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.PERSO___PERSOMODIFUSR.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PERSO___PERSOMODIFUSR"
							v-on="controls.PERSO___PERSOMODIFUSR.handlers"
							:loading="controls.PERSO___PERSOMODIFUSR.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.PERSO___PERSOMODIFUSR.props"
								:model-value="model.ValModifusr.value" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.PERSO___PERSOMODIFDAT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PERSO___PERSOMODIFDAT"
							v-on="controls.PERSO___PERSOMODIFDAT.handlers"
							:loading="controls.PERSO___PERSOMODIFDAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.PERSO___PERSOMODIFDAT.isVisible"
								v-bind="controls.PERSO___PERSOMODIFDAT.props"
								:model-value="model.ValModifdat.value"
								@reset-icon-click="model.ValModifdat.fnUpdateValue(model.ValModifdat.originalValue ?? new Date())"
								@update:model-value="model.ValModifdat.fnUpdateValue($event ?? '')" />
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

	import FormViewModel from './QFormPersoViewModel.js'

	const requiredTextResources = ['QFormPerso', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PERSO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormPerso',

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
					name: 'PERSO',
					location: 'form-PERSO',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormPerso', false),

				interfaceMetadata: {
					id: 'QFormPerso', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'PERSO',
					route: 'form-PERSO',
					area: 'PERSO',
					primaryKey: 'ValCodperso',
					designation: computed(() => this.Resources.PERSON10446),
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
					PERSO___PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'PERSO___PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'xxlarge',
						label: computed(() => this.Resources.IDENTIFICATION37731),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['PERSO___PSEUDNOVOGR04', 'PERSO___PSEUDNOVOGR05'],
						controlLimits: [
						],
					}, this),
					PERSO___PSEUDNOVOGR04: new fieldControlClass.GroupControl({
						id: 'PERSO___PSEUDNOVOGR04',
						name: 'NOVOGR04',
						size: 'medium',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PERSO___PSEUDNOVOGR01',
						isCollapsible: false,
						anchored: false,
						directChildren: ['PERSO___PERSOPHOTO___'],
						controlLimits: [
						],
					}, this),
					PERSO___PERSOPHOTO___: new fieldControlClass.ImageControl({
						modelField: 'ValPhoto',
						valueChangeEvent: 'fieldChange:perso.photo',
						id: 'PERSO___PERSOPHOTO___',
						name: 'PHOTO',
						size: 'medium',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PERSO___PSEUDNOVOGR04',
						height: 115,
						width: 100,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO51874)),
						controlLimits: [
						],
					}, this),
					PERSO___PSEUDNOVOGR05: new fieldControlClass.GroupControl({
						id: 'PERSO___PSEUDNOVOGR05',
						name: 'NOVOGR05',
						size: 'xxlarge',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PERSO___PSEUDNOVOGR01',
						isCollapsible: false,
						anchored: false,
						directChildren: ['PERSO___PERSONAME____', 'PERSO___PERSOIDENTIFI', 'PERSO___PERSOGENDER__', 'PERSO___PERSOEMAIL___'],
						controlLimits: [
						],
					}, this),
					PERSO___PERSONAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:perso.name',
						id: 'PERSO___PERSONAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.PERSON_NAME40980),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PERSO___PSEUDNOVOGR05',
						maxLength: 85,
						labelId: 'label_PERSO___PERSONAME____',
						controlLimits: [
						],
					}, this),
					PERSO___PERSOIDENTIFI: new fieldControlClass.StringControl({
						modelField: 'ValIdentifi',
						valueChangeEvent: 'fieldChange:perso.identifi',
						id: 'PERSO___PERSOIDENTIFI',
						name: 'IDENTIFI',
						size: 'medium',
						label: computed(() => this.Resources.IDENTIFICATION_NUMBE11999),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PERSO___PSEUDNOVOGR05',
						maxLength: 10,
						labelId: 'label_PERSO___PERSOIDENTIFI',
						controlLimits: [
						],
					}, this),
					PERSO___PERSOGENDER__: new fieldControlClass.ArrayStringControl({
						modelField: 'ValGender',
						valueChangeEvent: 'fieldChange:perso.gender',
						id: 'PERSO___PERSOGENDER__',
						name: 'GENDER',
						size: 'small',
						label: computed(() => this.Resources.GENDER44172),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PERSO___PSEUDNOVOGR05',
						maxLength: 1,
						labelId: 'label_PERSO___PERSOGENDER__',
						arrayName: 'Gender',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					PERSO___PERSOEMAIL___: new fieldControlClass.StringControl({
						modelField: 'ValEmail',
						valueChangeEvent: 'fieldChange:perso.email',
						id: 'PERSO___PERSOEMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						label: computed(() => this.Resources.EMAIL25170),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PERSO___PSEUDNOVOGR05',
						maxLength: 254,
						labelId: 'label_PERSO___PERSOEMAIL___',
						controlLimits: [
						],
					}, this),
					PERSO___PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'PERSO___PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'xxlarge',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['PERSO___PERSODOB_____', 'PERSO___PERSOTOB_____', 'PERSO___PERSOYEAR____', 'PERSO___PERSOMONTH___'],
						controlLimits: [
						],
					}, this),
					PERSO___PERSODOB_____: new fieldControlClass.DateControl({
						modelField: 'ValDob',
						valueChangeEvent: 'fieldChange:perso.dob',
						id: 'PERSO___PERSODOB_____',
						name: 'DOB',
						size: 'small',
						label: computed(() => this.Resources.DATE_OF_BIRTH63058),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PERSO___PSEUDNOVOGR02',
						format: 'date',
						controlLimits: [
						],
					}, this),
					PERSO___PERSOTOB_____: new fieldControlClass.TimeControl({
						modelField: 'ValTob',
						valueChangeEvent: 'fieldChange:perso.tob',
						id: 'PERSO___PERSOTOB_____',
						name: 'TOB',
						size: 'mini',
						label: computed(() => this.Resources.TIME_OF_BIRTH04797),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PERSO___PSEUDNOVOGR02',
						format: 'time',
						controlLimits: [
						],
					}, this),
					PERSO___PERSOYEAR____: new fieldControlClass.NumberControl({
						modelField: 'ValYear',
						valueChangeEvent: 'fieldChange:perso.year',
						id: 'PERSO___PERSOYEAR____',
						name: 'YEAR',
						size: 'mini',
						label: computed(() => this.Resources.YEAR61794),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PERSO___PSEUDNOVOGR02',
						maxIntegers: 4,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					PERSO___PERSOMONTH___: new fieldControlClass.ArrayNumberControl({
						modelField: 'ValMonth',
						valueChangeEvent: 'fieldChange:perso.month',
						id: 'PERSO___PERSOMONTH___',
						name: 'MONTH',
						size: 'medium',
						label: computed(() => this.Resources.MONTH46035),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PERSO___PSEUDNOVOGR02',
						maxIntegers: 2,
						maxDecimals: 0,
						arrayName: 'Months',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					PERSO___PERSOCREATUSR: new fieldControlClass.StringControl({
						modelField: 'ValCreatusr',
						valueChangeEvent: 'fieldChange:perso.creatusr',
						id: 'PERSO___PERSOCREATUSR',
						name: 'CREATUSR',
						size: 'medium',
						label: computed(() => this.Resources.CREATED_BY12292),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 20,
						labelId: 'label_PERSO___PERSOCREATUSR',
						controlLimits: [
						],
					}, this),
					PERSO___PERSOCREATDAT: new fieldControlClass.DateControl({
						modelField: 'ValCreatdat',
						valueChangeEvent: 'fieldChange:perso.creatdat',
						id: 'PERSO___PERSOCREATDAT',
						name: 'CREATDAT',
						size: 'small',
						label: computed(() => this.Resources.CREATED_ON00051),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						format: 'date',
						controlLimits: [
						],
					}, this),
					PERSO___PERSOMODIFUSR: new fieldControlClass.StringControl({
						modelField: 'ValModifusr',
						valueChangeEvent: 'fieldChange:perso.modifusr',
						id: 'PERSO___PERSOMODIFUSR',
						name: 'MODIFUSR',
						size: 'medium',
						label: computed(() => this.Resources.MODIFIED_BY02094),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 20,
						labelId: 'label_PERSO___PERSOMODIFUSR',
						controlLimits: [
						],
					}, this),
					PERSO___PERSOMODIFDAT: new fieldControlClass.DateControl({
						modelField: 'ValModifdat',
						valueChangeEvent: 'fieldChange:perso.modifdat',
						id: 'PERSO___PERSOMODIFDAT',
						name: 'MODIFDAT',
						size: 'small',
						label: computed(() => this.Resources.MODIFIED_ON31953),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						format: 'date',
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
					'PERSO___PSEUDNOVOGR01',
					'PERSO___PSEUDNOVOGR04',
					'PERSO___PSEUDNOVOGR05',
					'PERSO___PSEUDNOVOGR02',
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Perso: {
						get ValCreatdat() { return vm.model.ValCreatdat.value },
						set ValCreatdat(value) { vm.model.ValCreatdat.updateValue(value) },
						get ValCreatusr() { return vm.model.ValCreatusr.value },
						set ValCreatusr(value) { vm.model.ValCreatusr.updateValue(value) },
						get ValDob() { return vm.model.ValDob.value },
						set ValDob(value) { vm.model.ValDob.updateValue(value) },
						get ValEmail() { return vm.model.ValEmail.value },
						set ValEmail(value) { vm.model.ValEmail.updateValue(value) },
						get ValGender() { return vm.model.ValGender.value },
						set ValGender(value) { vm.model.ValGender.updateValue(value) },
						get ValIdentifi() { return vm.model.ValIdentifi.value },
						set ValIdentifi(value) { vm.model.ValIdentifi.updateValue(value) },
						get ValModifdat() { return vm.model.ValModifdat.value },
						set ValModifdat(value) { vm.model.ValModifdat.updateValue(value) },
						get ValModifusr() { return vm.model.ValModifusr.value },
						set ValModifusr(value) { vm.model.ValModifusr.updateValue(value) },
						get ValMonth() { return vm.model.ValMonth.value },
						set ValMonth(value) { vm.model.ValMonth.updateValue(value) },
						get ValName() { return vm.model.ValName.value },
						set ValName(value) { vm.model.ValName.updateValue(value) },
						get ValPhoto() { return vm.model.ValPhoto.value },
						set ValPhoto(value) { vm.model.ValPhoto.updateValue(value) },
						get ValTob() { return vm.model.ValTob.value },
						set ValTob(value) { vm.model.ValTob.updateValue(value) },
						get ValYear() { return vm.model.ValYear.value },
						set ValYear(value) { vm.model.ValYear.updateValue(value) },
					},
					keys: {
						/** The primary key of the PERSO table */
						get perso() { return vm.model.ValCodperso },
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
// USE /[MANUAL GQT FORM_CODEJS PERSO]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS PERSO]/
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
// USE /[MANUAL GQT FORM_LOADED_JS PERSO]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS PERSO]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS PERSO]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS PERSO]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS PERSO]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS PERSO]/
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
// USE /[MANUAL GQT AFTER_DEL_JS PERSO]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS PERSO]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS PERSO]/
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
// USE /[MANUAL GQT DLGUPDT PERSO]/
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
// USE /[MANUAL GQT CTRLBLR PERSO]/
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
// USE /[MANUAL GQT CTRLUPD PERSO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS PERSO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
