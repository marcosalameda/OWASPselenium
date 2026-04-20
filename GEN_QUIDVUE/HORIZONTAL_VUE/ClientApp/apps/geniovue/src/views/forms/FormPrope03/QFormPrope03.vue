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
			data-key="PROPE03"
			:data-identifier="primaryKeyValue"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.PROPE03_PROPETITLE___.isVisible || controls.PROPE03_PROPEPRICE___.isVisible">
					<q-col
						v-if="controls.PROPE03_PROPETITLE___.isVisible || controls.PROPE03_PROPEPRICE___.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.PROPE03_PROPETITLE___.isVisible"
							class="i-text"
							v-bind="controls.PROPE03_PROPETITLE___.wrapperProps"
							:id="getControlId(controls.PROPE03_PROPETITLE___)"
							v-on="controls.PROPE03_PROPETITLE___.handlers"
							:loading="controls.PROPE03_PROPETITLE___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.PROPE03_PROPETITLE___.props"
								:id="getControlId(controls.PROPE03_PROPETITLE___)"
								@blur="onBlur(controls.PROPE03_PROPETITLE___, model.ValTitle.value)"
								@change="model.ValTitle.fnUpdateValueOnChange" />
						</base-input-structure>
						<base-input-structure
							v-if="controls.PROPE03_PROPEPRICE___.isVisible"
							class="i-text"
							v-bind="controls.PROPE03_PROPEPRICE___.wrapperProps"
							:id="getControlId(controls.PROPE03_PROPEPRICE___)"
							v-on="controls.PROPE03_PROPEPRICE___.handlers"
							:loading="controls.PROPE03_PROPEPRICE___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.PROPE03_PROPEPRICE___.isVisible"
								v-bind="controls.PROPE03_PROPEPRICE___.props"
								:id="getControlId(controls.PROPE03_PROPEPRICE___)"
								@update:model-value="model.ValPrice.fnUpdateValue" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.PROPE03_PROPEPHOTO___.isVisible">
					<q-col
						v-if="controls.PROPE03_PROPEPHOTO___.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.PROPE03_PROPEPHOTO___.isVisible"
							class="q-image"
							v-bind="controls.PROPE03_PROPEPHOTO___.wrapperProps"
							:id="getControlId(controls.PROPE03_PROPEPHOTO___)"
							v-on="controls.PROPE03_PROPEPHOTO___.handlers"
							:loading="controls.PROPE03_PROPEPHOTO___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-image
								v-if="controls.PROPE03_PROPEPHOTO___.isVisible"
								v-bind="controls.PROPE03_PROPEPHOTO___.props"
								:id="getControlId(controls.PROPE03_PROPEPHOTO___)"
								v-on="controls.PROPE03_PROPEPHOTO___.handlers" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.PROPE03_AGENTNAME____.isVisible || controls.PROPE03_PROPESIZE____.isVisible || controls.PROPE03_PROPEBATHRMS_.isVisible || controls.PROPE03_PROPEYEAR____.isVisible || controls.PROPE03_CITY_CITY____.isVisible">
					<q-col
						v-if="controls.PROPE03_AGENTNAME____.isVisible || controls.PROPE03_PROPESIZE____.isVisible || controls.PROPE03_PROPEBATHRMS_.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.PROPE03_AGENTNAME____.isVisible"
							class="i-text"
							v-bind="controls.PROPE03_AGENTNAME____.wrapperProps"
							:id="getControlId(controls.PROPE03_AGENTNAME____)"
							v-on="controls.PROPE03_AGENTNAME____.handlers"
							:loading="controls.PROPE03_AGENTNAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.PROPE03_AGENTNAME____.isVisible"
								v-bind="controls.PROPE03_AGENTNAME____.props"
								:id="getControlId(controls.PROPE03_AGENTNAME____)"
								v-on="controls.PROPE03_AGENTNAME____.handlers" />
							<q-see-more-prope03-agentname
								v-if="controls.PROPE03_AGENTNAME____.seeMoreIsVisible"
								v-bind="controls.PROPE03_AGENTNAME____.seeMoreParams"
								v-on="controls.PROPE03_AGENTNAME____.handlers" />
						</base-input-structure>
						<base-input-structure
							v-if="controls.PROPE03_PROPESIZE____.isVisible"
							class="i-text"
							v-bind="controls.PROPE03_PROPESIZE____.wrapperProps"
							:id="getControlId(controls.PROPE03_PROPESIZE____)"
							v-on="controls.PROPE03_PROPESIZE____.handlers"
							:loading="controls.PROPE03_PROPESIZE____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.PROPE03_PROPESIZE____.isVisible"
								v-bind="controls.PROPE03_PROPESIZE____.props"
								:id="getControlId(controls.PROPE03_PROPESIZE____)"
								@update:model-value="model.ValSize.fnUpdateValue" />
						</base-input-structure>
						<base-input-structure
							v-if="controls.PROPE03_PROPEBATHRMS_.isVisible"
							class="i-text"
							v-bind="controls.PROPE03_PROPEBATHRMS_.wrapperProps"
							:id="getControlId(controls.PROPE03_PROPEBATHRMS_)"
							v-on="controls.PROPE03_PROPEBATHRMS_.handlers"
							:loading="controls.PROPE03_PROPEBATHRMS_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.PROPE03_PROPEBATHRMS_.isVisible"
								v-bind="controls.PROPE03_PROPEBATHRMS_.props"
								:id="getControlId(controls.PROPE03_PROPEBATHRMS_)"
								@update:model-value="model.ValBathrms.fnUpdateValue" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.PROPE03_PROPEYEAR____.isVisible || controls.PROPE03_CITY_CITY____.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.PROPE03_PROPEYEAR____.isVisible"
							class="i-text"
							v-bind="controls.PROPE03_PROPEYEAR____.wrapperProps"
							:id="getControlId(controls.PROPE03_PROPEYEAR____)"
							v-on="controls.PROPE03_PROPEYEAR____.handlers"
							:loading="controls.PROPE03_PROPEYEAR____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.PROPE03_PROPEYEAR____.props"
								:id="getControlId(controls.PROPE03_PROPEYEAR____)"
								@blur="onBlur(controls.PROPE03_PROPEYEAR____, model.ValYear.value)"
								@change="model.ValYear.fnUpdateValueOnChange" />
						</base-input-structure>
						<base-input-structure
							v-if="controls.PROPE03_CITY_CITY____.isVisible"
							class="i-text"
							v-bind="controls.PROPE03_CITY_CITY____.wrapperProps"
							:id="getControlId(controls.PROPE03_CITY_CITY____)"
							v-on="controls.PROPE03_CITY_CITY____.handlers"
							:loading="controls.PROPE03_CITY_CITY____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.PROPE03_CITY_CITY____.isVisible"
								v-bind="controls.PROPE03_CITY_CITY____.props"
								:id="getControlId(controls.PROPE03_CITY_CITY____)"
								v-on="controls.PROPE03_CITY_CITY____.handlers" />
							<q-see-more-prope03-city-city
								v-if="controls.PROPE03_CITY_CITY____.seeMoreIsVisible"
								v-bind="controls.PROPE03_CITY_CITY____.seeMoreParams"
								v-on="controls.PROPE03_CITY_CITY____.handlers" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.PROPE03_PROPEDESCRIPT.isVisible">
					<q-col
						v-if="controls.PROPE03_PROPEDESCRIPT.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.PROPE03_PROPEDESCRIPT.isVisible"
							class="i-textarea"
							v-bind="controls.PROPE03_PROPEDESCRIPT.wrapperProps"
							:id="getControlId(controls.PROPE03_PROPEDESCRIPT)"
							v-on="controls.PROPE03_PROPEDESCRIPT.handlers"
							:loading="controls.PROPE03_PROPEDESCRIPT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-area
								v-if="controls.PROPE03_PROPEDESCRIPT.isVisible"
								v-bind="controls.PROPE03_PROPEDESCRIPT.props"
								:id="getControlId(controls.PROPE03_PROPEDESCRIPT)"
								v-on="controls.PROPE03_PROPEDESCRIPT.handlers" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.PROPE03_PSEUDPROPCONT.isVisible">
					<q-col
						v-if="controls.PROPE03_PSEUDPROPCONT.isVisible"
						cols="auto">
						<q-table
							v-if="controls.PROPE03_PSEUDPROPCONT.isVisible"
							v-bind="controls.PROPE03_PSEUDPROPCONT"
							:id="getControlId(controls.PROPE03_PSEUDPROPCONT)"
							v-on="controls.PROPE03_PSEUDPROPCONT.handlers">
							<template #header>
								<q-table-config
									:table-ctrl="controls.PROPE03_PSEUDPROPCONT"
									v-on="controls.PROPE03_PSEUDPROPCONT.handlers" />
							</template>
							<!-- USE /[MANUAL GQT CUSTOM_TABLE PROPE03_PSEUDPROPCONT]/ -->
						</q-table>
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

	import FormViewModel from './QFormPrope03ViewModel.js'

	const requiredTextResources = ['QFormPrope03', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PROPE03]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormPrope03',

		components: {
			QSeeMorePrope03Agentname: defineAsyncComponent(() => import('@/views/forms/FormPrope03/dbedits/Prope03AgentnameSeeMore.vue')),
			QSeeMorePrope03CityCity: defineAsyncComponent(() => import('@/views/forms/FormPrope03/dbedits/Prope03CityCitySeeMore.vue')),
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
					name: 'PROPE03',
					location: 'form-PROPE03',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormPrope03', false),

				interfaceMetadata: {
					id: 'QFormPrope03', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'PROPE03',
					route: 'form-PROPE03',
					area: 'PROPE',
					primaryKey: 'ValCodprope',
					designation: computed(() => this.Resources.PROPERTY43977),
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
						text: computed(() => vm.Resources.CANCELAR49513),
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
					PROPE03_PROPETITLE___: new fieldControlClass.StringControl({
						modelField: 'ValTitle',
						valueChangeEvent: 'fieldChange:prope.title',
						id: 'PROPE03_PROPETITLE___',
						name: 'TITLE',
						size: 'xxlarge',
						label: computed(() => this.Resources.TITLE21885),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					PROPE03_PROPEPRICE___: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrice',
						valueChangeEvent: 'fieldChange:prope.price',
						id: 'PROPE03_PROPEPRICE___',
						name: 'PRICE',
						size: 'medium',
						label: computed(() => this.Resources.PRICE06900),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 9,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					PROPE03_PROPEPHOTO___: new fieldControlClass.ImageControl({
						modelField: 'ValPhoto',
						valueChangeEvent: 'fieldChange:prope.photo',
						id: 'PROPE03_PROPEPHOTO___',
						name: 'PHOTO',
						size: 'mini',
						label: computed(() => this.Resources.FOTO_PRINCIPAL64363),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						height: 10,
						width: 480,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.FOTO_PRINCIPAL64363)),
						controlLimits: [
						],
					}, this),
					PROPE03_AGENTNAME____: new fieldControlClass.LookupControl({
						modelField: 'TableAgentName',
						valueChangeEvent: 'fieldChange:agent.name',
						id: 'PROPE03_AGENTNAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.NAME31974),
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
							name: 'ValCodagent',
							dependencyEvent: 'fieldChange:prope.codagent'
						},
						dependentFields: () => ({
							set 'agent.codagent'(value) { vm.model.ValCodagent.updateValue(value) },
							set 'agent.name'(value) { vm.model.TableAgentName.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					PROPE03_PROPESIZE____: new fieldControlClass.NumberControl({
						modelField: 'ValSize',
						valueChangeEvent: 'fieldChange:prope.size',
						id: 'PROPE03_PROPESIZE____',
						name: 'SIZE',
						size: 'medium',
						label: computed(() => this.Resources.TAMANHO__M2_40951),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 15,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					PROPE03_PROPEBATHRMS_: new fieldControlClass.NumberControl({
						modelField: 'ValBathrms',
						valueChangeEvent: 'fieldChange:prope.bathrms',
						id: 'PROPE03_PROPEBATHRMS_',
						name: 'BATHRMS',
						size: 'large',
						label: computed(() => this.Resources.NUMERO_DE_CASA_DE_BA10087),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 2,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					PROPE03_PROPEYEAR____: new fieldControlClass.StringControl({
						modelField: 'ValYear',
						valueChangeEvent: 'fieldChange:prope.year',
						id: 'PROPE03_PROPEYEAR____',
						name: 'YEAR',
						size: 'medium',
						label: computed(() => this.Resources.ANO_CONSTRUIDO64369),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					PROPE03_CITY_CITY____: new fieldControlClass.LookupControl({
						modelField: 'TableCityCity',
						valueChangeEvent: 'fieldChange:city.city',
						id: 'PROPE03_CITY_CITY____',
						name: 'CITY',
						size: 'xxlarge',
						label: computed(() => this.Resources.CIDADE42080),
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
							name: 'ValCodcity',
							dependencyEvent: 'fieldChange:prope.codcity'
						},
						dependentFields: () => ({
							set 'city.codcity'(value) { vm.model.ValCodcity.updateValue(value) },
							set 'city.city'(value) { vm.model.TableCityCity.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					PROPE03_PROPEDESCRIPT: new fieldControlClass.MultilineStringControl({
						modelField: 'ValDescript',
						valueChangeEvent: 'fieldChange:prope.descript',
						id: 'PROPE03_PROPEDESCRIPT',
						name: 'DESCRIPT',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESCRIPTION07383),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						rows: 1,
						cols: 99,
						controlLimits: [
						],
					}, this),
					PROPE03_PSEUDPROPCONT: new fieldControlClass.TableListControl({
						id: 'PROPE03_PSEUDPROPCONT',
						name: 'PROPCONT',
						size: '',
						label: computed(() => this.Resources.CONTACTS55742),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						headerLevel: computed(() => this.baseHeadingLevel + 1),
						controller: 'PROPE',
						action: 'Prope03_ValPropcont',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValName',
								area: 'PROCN',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValEmail',
								area: 'PROCN',
								field: 'EMAIL',
								label: computed(() => this.Resources.EMAIL25170),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValTelephon',
								area: 'PROCN',
								field: 'TELEPHON',
								label: computed(() => this.Resources.TELEPHONE28697),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValDescript',
								area: 'PROCN',
								field: 'DESCRIPT',
								label: computed(() => this.Resources.DESCRIPTION07383),
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 5,
								name: 'ValDate',
								area: 'PROCN',
								field: 'DATE',
								label: computed(() => this.Resources.DATE18475),
								scrollData: 8,
								dateTimeType: 'date',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValPropcont',
							serverMode: true,
							pkColumn: 'ValCodprocn',
							tableAlias: 'PROCN',
							tableNamePlural: computed(() => this.Resources.CONTACTS55742),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.CONTACTS55742),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: false
							},
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
										formName: 'CONTAC03',
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
										formName: 'CONTAC03',
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
										formName: 'CONTAC03',
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
										formName: 'CONTAC03',
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
									icon: { icon: 'add' },
									isInReadOnly: false,
									params: {
										canExecuteAction: vm.applyChanges,
										action: vm.openFormAction,
										type: 'form',
										formName: 'CONTAC03',
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
								id: 'RCA__CONTAC03',
								name: '_CONTAC03',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									canExecuteAction: vm.applyChanges,
									action: vm.openFormAction,
									type: 'form',
									formName: 'CONTAC03',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'CONTAC03': {
									fnKeySelector: (row) => row.Fields.ValCodprocn,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValName',
							defaultSearchColumnNameOriginal: 'ValName',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-PROCN', 'changed-PROPE'],
						uuid: 'Prope03_ValPropcont',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'prope'],
								dependencyEvents: ['fieldChange:prope.codprope'],
								dependencyField: 'PROPE.CODPROPE',
								fnValueSelector: (model) => model.ValCodprope.value
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
				]),

				tableFields: readonly([
					'PROPE03_PSEUDPROPCONT',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Agent: {
						get ValName() { return vm.model.TableAgentName.value },
						set ValName(value) { vm.model.TableAgentName.updateValue(value) },
					},
					City: {
						get ValCity() { return vm.model.TableCityCity.value },
						set ValCity(value) { vm.model.TableCityCity.updateValue(value) },
					},
					Prope: {
						get ValBathrms() { return vm.model.ValBathrms.value },
						set ValBathrms(value) { vm.model.ValBathrms.updateValue(value) },
						get ValCodagent() { return vm.model.ValCodagent.value },
						set ValCodagent(value) { vm.model.ValCodagent.updateValue(value) },
						get ValCodcity() { return vm.model.ValCodcity.value },
						set ValCodcity(value) { vm.model.ValCodcity.updateValue(value) },
						get ValDescript() { return vm.model.ValDescript.value },
						set ValDescript(value) { vm.model.ValDescript.updateValue(value) },
						get ValPhoto() { return vm.model.ValPhoto.value },
						set ValPhoto(value) { vm.model.ValPhoto.updateValue(value) },
						get ValPrice() { return vm.model.ValPrice.value },
						set ValPrice(value) { vm.model.ValPrice.updateValue(value) },
						get ValSize() { return vm.model.ValSize.value },
						set ValSize(value) { vm.model.ValSize.updateValue(value) },
						get ValTitle() { return vm.model.ValTitle.value },
						set ValTitle(value) { vm.model.ValTitle.updateValue(value) },
						get ValYear() { return vm.model.ValYear.value },
						set ValYear(value) { vm.model.ValYear.updateValue(value) },
					},
					keys: {
						/** The primary key of the PROPE table */
						get prope() { return vm.model.ValCodprope },
						/** The foreign key to the AGENT table */
						get agent() { return vm.model.ValCodagent },
						/** The foreign key to the CITY table */
						get city() { return vm.model.ValCodcity },
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
// USE /[MANUAL GQT FORM_CODEJS PROPE03]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT PROPE03]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS PROPE03]/
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
// USE /[MANUAL GQT FORM_LOADED_JS PROPE03]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS PROPE03]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS PROPE03]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS PROPE03]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS PROPE03]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS PROPE03]/
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
// USE /[MANUAL GQT AFTER_DEL_JS PROPE03]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS PROPE03]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS PROPE03]/
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
// USE /[MANUAL GQT DLGUPDT PROPE03]/
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
// USE /[MANUAL GQT CTRLBLR PROPE03]/
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
// USE /[MANUAL GQT CTRLUPD PROPE03]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS PROPE03]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
