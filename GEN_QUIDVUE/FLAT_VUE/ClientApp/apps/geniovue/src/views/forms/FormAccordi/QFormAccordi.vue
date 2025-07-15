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
			data-key="ACCORDI"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.ACCORDI_PSEUDNOVOGR02.isVisible">
					<q-control-wrapper
						v-show="controls.ACCORDI_PSEUDNOVOGR02.isVisible"
						class="control-join-group">
						<q-group-collapsible
							id="ACCORDI_PSEUDNOVOGR02"
							v-bind="controls.ACCORDI_PSEUDNOVOGR02"
							v-on="controls.ACCORDI_PSEUDNOVOGR02.handlers">
							<!-- Start ACCORDI_PSEUDNOVOGR02 -->
							<q-row-container v-show="controls.ACCORDI_CMPNYDESIGNAT.isVisible">
								<q-control-wrapper
									v-show="controls.ACCORDI_CMPNYDESIGNAT.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.ACCORDI_CMPNYDESIGNAT"
										v-on="controls.ACCORDI_CMPNYDESIGNAT.handlers"
										:loading="controls.ACCORDI_CMPNYDESIGNAT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.ACCORDI_CMPNYDESIGNAT.isVisible"
											v-bind="controls.ACCORDI_CMPNYDESIGNAT.props"
											v-on="controls.ACCORDI_CMPNYDESIGNAT.handlers" />
										<q-see-more-accordi-cmpnydesignat
											v-if="controls.ACCORDI_CMPNYDESIGNAT.seeMoreIsVisible"
											v-bind="controls.ACCORDI_CMPNYDESIGNAT.seeMoreParams"
											v-on="controls.ACCORDI_CMPNYDESIGNAT.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.ACCORDI_PESS1NAME____.isVisible || controls.ACCORDI_EQUIPSEQUENNR.isVisible">
								<q-control-wrapper
									v-show="controls.ACCORDI_PESS1NAME____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.ACCORDI_PESS1NAME____"
										v-on="controls.ACCORDI_PESS1NAME____.handlers"
										:loading="controls.ACCORDI_PESS1NAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.ACCORDI_PESS1NAME____.isVisible"
											v-bind="controls.ACCORDI_PESS1NAME____.props"
											v-on="controls.ACCORDI_PESS1NAME____.handlers" />
										<q-see-more-accordi-pess1name
											v-if="controls.ACCORDI_PESS1NAME____.seeMoreIsVisible"
											v-bind="controls.ACCORDI_PESS1NAME____.seeMoreParams"
											v-on="controls.ACCORDI_PESS1NAME____.handlers" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.ACCORDI_EQUIPSEQUENNR.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.ACCORDI_EQUIPSEQUENNR"
										v-on="controls.ACCORDI_EQUIPSEQUENNR.handlers"
										:loading="controls.ACCORDI_EQUIPSEQUENNR.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.ACCORDI_EQUIPSEQUENNR.isVisible"
											v-bind="controls.ACCORDI_EQUIPSEQUENNR.props"
											@update:model-value="model.ValSequennr.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End ACCORDI_PSEUDNOVOGR02 -->
						</q-group-collapsible>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.ACCORDI_PSEUDNOVOGR06.isVisible">
					<q-control-wrapper
						v-show="controls.ACCORDI_PSEUDNOVOGR06.isVisible"
						class="control-join-group">
						<q-group-collapsible
							id="ACCORDI_PSEUDNOVOGR06"
							v-bind="controls.ACCORDI_PSEUDNOVOGR06"
							v-on="controls.ACCORDI_PSEUDNOVOGR06.handlers">
							<!-- Start ACCORDI_PSEUDNOVOGR06 -->
							<q-row-container v-show="controls.ACCORDI_EQUIPPHOTOGRA.isVisible">
								<q-control-wrapper
									v-show="controls.ACCORDI_EQUIPPHOTOGRA.isVisible"
									class="control-join-group">
									<base-input-structure
										class="q-image"
										v-bind="controls.ACCORDI_EQUIPPHOTOGRA"
										v-on="controls.ACCORDI_EQUIPPHOTOGRA.handlers"
										:loading="controls.ACCORDI_EQUIPPHOTOGRA.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-image
											v-if="controls.ACCORDI_EQUIPPHOTOGRA.isVisible"
											v-bind="controls.ACCORDI_EQUIPPHOTOGRA.props"
											v-on="controls.ACCORDI_EQUIPPHOTOGRA.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End ACCORDI_PSEUDNOVOGR06 -->
						</q-group-collapsible>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.ACCORDI_PSEUDNOVOGR05.isVisible">
					<q-control-wrapper
						v-show="controls.ACCORDI_PSEUDNOVOGR05.isVisible"
						class="control-join-group">
						<q-accordion
							v-if="controls.ACCORDI_PSEUDNOVOGR05.isVisible"
							id="ACCORDI_PSEUDNOVOGR05"
							v-model="controls.ACCORDI_PSEUDNOVOGR05.openChild"
							v-bind="controls.ACCORDI_PSEUDNOVOGR05">
							<!-- Start ACCORDI_PSEUDNOVOGR05 -->
							<q-accordion-item
								id="ACCORDI_PSEUDNOVOGR03-container"
								value="ACCORDI_PSEUDNOVOGR03"
								:title="controls.ACCORDI_PSEUDNOVOGR03.label">
								<!-- Start ACCORDI_PSEUDNOVOGR03 -->
								<q-row-container v-show="controls.ACCORDI_PSEUDINSTALAG.isVisible">
									<q-control-wrapper
										v-show="controls.ACCORDI_PSEUDINSTALAG.isVisible"
										class="control-join-group">
										<q-table
											v-show="controls.ACCORDI_PSEUDINSTALAG.isVisible"
											v-bind="controls.ACCORDI_PSEUDINSTALAG"
											v-on="controls.ACCORDI_PSEUDINSTALAG.handlers" />
										<q-table-extra-extension
											:list-ctrl="controls.ACCORDI_PSEUDINSTALAG"
											:filter-operators="controls.ACCORDI_PSEUDINSTALAG.filterOperators"
											v-on="controls.ACCORDI_PSEUDINSTALAG.handlers" />
									</q-control-wrapper>
								</q-row-container>
								<!-- End ACCORDI_PSEUDNOVOGR03 -->
							</q-accordion-item>
							<q-accordion-item
								id="ACCORDI_PSEUDNOVOGR04-container"
								value="ACCORDI_PSEUDNOVOGR04"
								:title="controls.ACCORDI_PSEUDNOVOGR04.label">
								<!-- Start ACCORDI_PSEUDNOVOGR04 -->
								<q-row-container v-show="controls.ACCORDI_PSEUDINSTALAC.isVisible">
									<q-control-wrapper
										v-show="controls.ACCORDI_PSEUDINSTALAC.isVisible"
										class="control-join-group">
										<q-table
											v-show="controls.ACCORDI_PSEUDINSTALAC.isVisible"
											v-bind="controls.ACCORDI_PSEUDINSTALAC"
											v-on="controls.ACCORDI_PSEUDINSTALAC.handlers" />
										<q-table-extra-extension
											:list-ctrl="controls.ACCORDI_PSEUDINSTALAC"
											:filter-operators="controls.ACCORDI_PSEUDINSTALAC.filterOperators"
											v-on="controls.ACCORDI_PSEUDINSTALAC.handlers" />
									</q-control-wrapper>
								</q-row-container>
								<!-- End ACCORDI_PSEUDNOVOGR04 -->
							</q-accordion-item>
							<q-accordion-item
								id="ACCORDI_PSEUDNOVOGR11-container"
								value="ACCORDI_PSEUDNOVOGR11"
								:title="controls.ACCORDI_PSEUDNOVOGR11.label">
								<!-- Start ACCORDI_PSEUDNOVOGR11 -->
								<q-row-container v-show="controls.ACCORDI_PSEUDREPARACO.isVisible">
									<q-control-wrapper
										v-show="controls.ACCORDI_PSEUDREPARACO.isVisible"
										class="control-join-group">
										<q-table
											v-show="controls.ACCORDI_PSEUDREPARACO.isVisible"
											v-bind="controls.ACCORDI_PSEUDREPARACO"
											v-on="controls.ACCORDI_PSEUDREPARACO.handlers" />
										<q-table-extra-extension
											:list-ctrl="controls.ACCORDI_PSEUDREPARACO"
											:filter-operators="controls.ACCORDI_PSEUDREPARACO.filterOperators"
											v-on="controls.ACCORDI_PSEUDREPARACO.handlers" />
									</q-control-wrapper>
								</q-row-container>
								<!-- End ACCORDI_PSEUDNOVOGR11 -->
							</q-accordion-item>
							<!-- End ACCORDI_PSEUDNOVOGR05 -->
						</q-accordion>
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

	import FormViewModel from './QFormAccordiViewModel.js'

	const requiredTextResources = ['QFormAccordi', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS ACCORDI]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormAccordi',

		components: {
			QSeeMoreAccordiCmpnydesignat: defineAsyncComponent(() => import('@/views/forms/FormAccordi/dbedits/AccordiCmpnydesignatSeeMore.vue')),
			QSeeMoreAccordiPess1name: defineAsyncComponent(() => import('@/views/forms/FormAccordi/dbedits/AccordiPess1nameSeeMore.vue')),
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
					name: 'ACCORDI',
					location: 'form-ACCORDI',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormAccordi', false),

				interfaceMetadata: {
					id: 'QFormAccordi', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'ACCORDI',
					route: 'form-ACCORDI',
					area: 'EQUIP',
					primaryKey: 'ValCodequip',
					designation: computed(() => this.Resources.ACCORDIONS05516),
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
					ACCORDI_PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'ACCORDI_PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'xxlarge',
						label: computed(() => this.Resources.COMPANY20759),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: true,
						anchored: false,
						directChildren: ['ACCORDI_CMPNYDESIGNAT', 'ACCORDI_PESS1NAME____', 'ACCORDI_EQUIPSEQUENNR'],
						controlLimits: [
						],
					}, this),
					ACCORDI_CMPNYDESIGNAT: new fieldControlClass.LookupControl({
						modelField: 'TableCmpnyDesignat',
						valueChangeEvent: 'fieldChange:cmpny.designat',
						id: 'ACCORDI_CMPNYDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.COMPANY_22615),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ACCORDI_PSEUDNOVOGR02',
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
							dependencyEvent: 'fieldChange:equip.codempre'
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
					ACCORDI_PESS1NAME____: new fieldControlClass.LookupControl({
						modelField: 'TablePess1Name',
						valueChangeEvent: 'fieldChange:pess1.name',
						id: 'ACCORDI_PESS1NAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.PERSON10446),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ACCORDI_PSEUDNOVOGR02',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodpess1',
							dependencyEvent: 'fieldChange:equip.codpess1'
						},
						dependentFields: () => ({
							set 'pess1.codpesso'(value) { vm.model.ValCodpess1.updateValue(value) },
							set 'pess1.name'(value) { vm.model.TablePess1Name.updateValue(value) },
						}),
						insertEnabled: true,
						supportForm: 'PESS1',
						controlLimits: [
							{
								identifier: ['cmpny', 'equip.codempre'],
								dependencyEvents: ['fieldChange:equip.codempre'],
								dependencyField: 'EQUIP.CODEMPRE',
								fnValueSelector: (model) => model.ValCodempre.value
							},
						],
					}, this),
					ACCORDI_EQUIPSEQUENNR: new fieldControlClass.NumberControl({
						modelField: 'ValSequennr',
						valueChangeEvent: 'fieldChange:equip.sequennr',
						id: 'ACCORDI_EQUIPSEQUENNR',
						name: 'SEQUENNR',
						size: 'small',
						label: computed(() => this.Resources.SEQUENTIAL_NO_38590),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ACCORDI_PSEUDNOVOGR02',
						maxIntegers: 6,
						maxDecimals: 0,
						isSequencial: true,
						controlLimits: [
						],
					}, this),
					ACCORDI_PSEUDNOVOGR06: new fieldControlClass.GroupControl({
						id: 'ACCORDI_PSEUDNOVOGR06',
						name: 'NOVOGR06',
						size: 'medium',
						label: computed(() => this.Resources.PHOTO32097),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: true,
						anchored: false,
						directChildren: ['ACCORDI_EQUIPPHOTOGRA'],
						controlLimits: [
						],
					}, this),
					ACCORDI_EQUIPPHOTOGRA: new fieldControlClass.ImageControl({
						modelField: 'ValPhotogra',
						valueChangeEvent: 'fieldChange:equip.photogra',
						id: 'ACCORDI_EQUIPPHOTOGRA',
						name: 'PHOTOGRA',
						size: 'medium',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ACCORDI_PSEUDNOVOGR06',
						height: 50,
						width: 100,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO51874)),
						controlLimits: [
						],
					}, this),
					ACCORDI_PSEUDNOVOGR05: new fieldControlClass.AccordionControl({
						id: 'ACCORDI_PSEUDNOVOGR05',
						name: 'NOVOGR05',
						size: 'xxlarge',
						label: computed(() => this.Resources.ACCORDION32434),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['ACCORDI_PSEUDNOVOGR03', 'ACCORDI_PSEUDNOVOGR04', 'ACCORDI_PSEUDNOVOGR11'],
						controlLimits: [
						],
					}, this),
					ACCORDI_PSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'ACCORDI_PSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'xxlarge',
						label: computed(() => this.Resources.FACILITIES08876),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ACCORDI_PSEUDNOVOGR05',
						isInAccordion: true,
						isCollapsible: true,
						anchored: false,
						directChildren: ['ACCORDI_PSEUDINSTALAG'],
						controlLimits: [
						],
					}, this),
					ACCORDI_PSEUDINSTALAG: new fieldControlClass.TableListControl({
						id: 'ACCORDI_PSEUDINSTALAG',
						name: 'INSTALAG',
						size: '',
						label: computed(() => this.Resources.FACILITIES_23844),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ACCORDI_PSEUDNOVOGR03',
						controller: 'EQUIP',
						action: 'Accordi_ValInstalag',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValSince',
								area: 'INSTA',
								field: 'SINCE',
								label: computed(() => this.Resources.SINCE47259),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 2,
								name: 'ValUntil',
								area: 'INSTA',
								field: 'UNTIL',
								label: computed(() => this.Resources.UNTIL39173),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 3,
								name: 'ValHours',
								area: 'INSTA',
								field: 'HOURS',
								label: computed(() => this.Resources.QNTY_HOURS51266),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 4,
								name: 'ValPrecohor',
								area: 'INSTA',
								field: 'PRECOHOR',
								label: computed(() => this.Resources.HOURLY_PRICE48005),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 5,
								name: 'ValValue',
								area: 'INSTA',
								field: 'VALUE',
								label: computed(() => this.Resources.VALUE10285),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValInstalag',
							serverMode: true,
							pkColumn: 'ValCodinsta',
							tableAlias: 'INSTA',
							tableNamePlural: computed(() => this.Resources.FACILITIES08876),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.FACILITIES_23844),
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
										formName: 'INSTA',
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
										formName: 'INSTA',
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
										formName: 'INSTA',
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
										formName: 'INSTA',
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
										formName: 'INSTA',
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
								id: 'RCA__INSTA',
								name: '_INSTA',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'INSTA',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'INSTA': {
									fnKeySelector: (row) => row.Fields.ValCodinsta,
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
						globalEvents: ['changed-INSTA', 'changed-EQUIP', 'changed-TPEQU'],
						uuid: 'Accordi_ValInstalag',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'equip'],
								dependencyEvents: ['fieldChange:equip.codequip'],
								dependencyField: 'EQUIP.CODEQUIP',
								fnValueSelector: (model) => model.ValCodequip.value
							},
						],
					}, this),
					ACCORDI_PSEUDNOVOGR04: new fieldControlClass.GroupControl({
						id: 'ACCORDI_PSEUDNOVOGR04',
						name: 'NOVOGR04',
						size: 'xxlarge',
						label: computed(() => this.Resources.PLACES43389),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ACCORDI_PSEUDNOVOGR05',
						isInAccordion: true,
						isCollapsible: true,
						anchored: false,
						directChildren: ['ACCORDI_PSEUDINSTALAC'],
						controlLimits: [
						],
					}, this),
					ACCORDI_PSEUDINSTALAC: new fieldControlClass.TableListControl({
						id: 'ACCORDI_PSEUDINSTALAC',
						name: 'INSTALAC',
						size: '',
						label: computed(() => this.Resources.FACILITIES08876),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ACCORDI_PSEUDNOVOGR04',
						controller: 'EQUIP',
						action: 'Accordi_ValInstalac',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValSince',
								area: 'INSTA',
								field: 'SINCE',
								label: computed(() => this.Resources.SINCE47259),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 2,
								name: 'ValUntil',
								area: 'INSTA',
								field: 'UNTIL',
								label: computed(() => this.Resources.UNTIL39173),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 3,
								name: 'ValHours',
								area: 'INSTA',
								field: 'HOURS',
								label: computed(() => this.Resources.QNTY_HOURS39084),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 4,
								name: 'ValPrecohor',
								area: 'INSTA',
								field: 'PRECOHOR',
								label: computed(() => this.Resources.HOURLY_PRICE48005),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 5,
								name: 'ValValue',
								area: 'INSTA',
								field: 'VALUE',
								label: computed(() => this.Resources.VALUE10285),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.GeographicColumn({
								order: 6,
								name: 'ValCoordgeo',
								area: 'INSTA',
								field: 'COORDGEO',
								label: computed(() => this.Resources.GEOGRAPHIC_COORDINAT21394),
								dataLength: 50,
								scrollData: 30,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValInstalac',
							serverMode: true,
							pkColumn: 'ValCodinsta',
							tableAlias: 'INSTA',
							tableNamePlural: computed(() => this.Resources.FACILITIES08876),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.FACILITIES08876),
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
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
							],
							rowClickAction: {
							},
							formsDefinition: {
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-INSTA', 'changed-EQUIP', 'changed-TPEQU'],
						uuid: 'Accordi_ValInstalac',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'equip'],
								dependencyEvents: ['fieldChange:equip.codequip'],
								dependencyField: 'EQUIP.CODEQUIP',
								fnValueSelector: (model) => model.ValCodequip.value
							},
						],
					}, this),
					ACCORDI_PSEUDNOVOGR11: new fieldControlClass.GroupControl({
						id: 'ACCORDI_PSEUDNOVOGR11',
						name: 'NOVOGR11',
						size: 'xxlarge',
						label: computed(() => this.Resources.REPAIRS18165),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ACCORDI_PSEUDNOVOGR05',
						isInAccordion: true,
						isCollapsible: true,
						anchored: false,
						directChildren: ['ACCORDI_PSEUDREPARACO'],
						controlLimits: [
						],
					}, this),
					ACCORDI_PSEUDREPARACO: new fieldControlClass.TableListControl({
						id: 'ACCORDI_PSEUDREPARACO',
						name: 'REPARACO',
						size: '',
						label: computed(() => this.Resources.EQUIPMENT_REPAIRS_35392),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ACCORDI_PSEUDNOVOGR11',
						controller: 'EQUIP',
						action: 'Accordi_ValReparaco',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.NumericColumn({
								order: 1,
								name: 'ValNrrepara',
								area: 'REPAR',
								field: 'NRREPARA',
								label: computed(() => this.Resources.NO_RUMOUR_IN_THE_COM15248),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 2,
								name: 'ValDtrepara',
								area: 'REPAR',
								field: 'DTREPARA',
								label: computed(() => this.Resources.FIXED_IN00179),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'Cate1.ValCategoria',
								area: 'CATE1',
								field: 'CATEGORIA',
								label: computed(() => this.Resources.SPECIALTY09304),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodcateg',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'Pesso.ValName',
								area: 'PESSO',
								field: 'NAME',
								label: computed(() => this.Resources.EXPERT27393),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodpesso',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValDescript',
								area: 'REPAR',
								field: 'DESCRIPT',
								label: computed(() => this.Resources.DESCRIPTION_OF_THE_R26085),
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 6,
								name: 'ValHours',
								area: 'REPAR',
								field: 'HOURS',
								label: computed(() => this.Resources.SPENT_ON_HOURS19285),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValReparaco',
							serverMode: true,
							pkColumn: 'ValCodrepar',
							tableAlias: 'REPAR',
							tableNamePlural: computed(() => this.Resources.REPAIRS18165),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.EQUIPMENT_REPAIRS_35392),
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
										formName: 'REPAR',
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
										formName: 'REPAR',
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
										formName: 'REPAR',
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
										formName: 'REPAR',
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
										formName: 'REPAR',
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
								id: 'RCA__REPAR',
								name: '_REPAR',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'REPAR',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'REPAR': {
									fnKeySelector: (row) => row.Fields.ValCodrepar,
									isPopup: false
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'ValNrrepara',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-EQUIP', 'changed-PESSO', 'changed-REPAR', 'changed-CATE1', 'changed-SPECI', 'changed-CMPNY'],
						uuid: 'Accordi_ValReparaco',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'equip'],
								dependencyEvents: ['fieldChange:equip.codequip'],
								dependencyField: 'EQUIP.CODEQUIP',
								fnValueSelector: (model) => model.ValCodequip.value
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
					'ACCORDI_PSEUDNOVOGR02',
					'ACCORDI_PSEUDNOVOGR06',
					'ACCORDI_PSEUDNOVOGR05',
					'ACCORDI_PSEUDNOVOGR03',
					'ACCORDI_PSEUDNOVOGR04',
					'ACCORDI_PSEUDNOVOGR11',
				]),

				tableFields: readonly([
					'ACCORDI_PSEUDINSTALAG',
					'ACCORDI_PSEUDINSTALAC',
					'ACCORDI_PSEUDREPARACO',
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
					Equip: {
						get ValCoddeco() { return vm.model.ValCoddeco.value },
						set ValCoddeco(value) { vm.model.ValCoddeco.updateValue(value) },
						get ValCodempre() { return vm.model.ValCodempre.value },
						set ValCodempre(value) { vm.model.ValCodempre.updateValue(value) },
						get ValCoditem() { return vm.model.ValCoditem.value },
						set ValCoditem(value) { vm.model.ValCoditem.updateValue(value) },
						get ValCodpess1() { return vm.model.ValCodpess1.value },
						set ValCodpess1(value) { vm.model.ValCodpess1.updateValue(value) },
						get ValCodrooms() { return vm.model.ValCodrooms.value },
						set ValCodrooms(value) { vm.model.ValCodrooms.updateValue(value) },
						get ValCodtpequ() { return vm.model.ValCodtpequ.value },
						set ValCodtpequ(value) { vm.model.ValCodtpequ.updateValue(value) },
						get ValCodwareh() { return vm.model.ValCodwareh.value },
						set ValCodwareh(value) { vm.model.ValCodwareh.updateValue(value) },
						get ValPhotogra() { return vm.model.ValPhotogra.value },
						set ValPhotogra(value) { vm.model.ValPhotogra.updateValue(value) },
						get ValRegistnr() { return vm.model.ValRegistnr.value },
						set ValRegistnr(value) { vm.model.ValRegistnr.updateValue(value) },
						get ValSequennr() { return vm.model.ValSequennr.value },
						set ValSequennr(value) { vm.model.ValSequennr.updateValue(value) },
					},
					Pess1: {
						get ValName() { return vm.model.TablePess1Name.value },
						set ValName(value) { vm.model.TablePess1Name.updateValue(value) },
					},
					keys: {
						/** The primary key of the EQUIP table */
						get equip() { return vm.model.ValCodequip },
						/** The foreign key to the CMPNY table */
						get cmpny() { return vm.model.ValCodempre },
						/** The foreign key to the PESS1 table */
						get pess1() { return vm.model.ValCodpess1 },
						/** The foreign key to the TPEQU table */
						get tpequ() { return vm.model.ValCodtpequ },
						/** The foreign key to the WAREH table */
						get wareh() { return vm.model.ValCodwareh },
						/** The foreign key to the ITEM table */
						get item() { return vm.model.ValCoditem },
						/** The foreign key to the DECOM table */
						get decom() { return vm.model.ValCoddeco },
						/** The foreign key to the ROOM1 table */
						get room1() { return vm.model.ValCodrooms },
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
// USE /[MANUAL GQT FORM_CODEJS ACCORDI]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT ACCORDI]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS ACCORDI]/
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
// USE /[MANUAL GQT FORM_LOADED_JS ACCORDI]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS ACCORDI]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS ACCORDI]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS ACCORDI]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS ACCORDI]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS ACCORDI]/
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
// USE /[MANUAL GQT AFTER_DEL_JS ACCORDI]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS ACCORDI]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS ACCORDI]/
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
// USE /[MANUAL GQT DLGUPDT ACCORDI]/
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
// USE /[MANUAL GQT CTRLBLR ACCORDI]/
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
// USE /[MANUAL GQT CTRLUPD ACCORDI]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS ACCORDI]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
