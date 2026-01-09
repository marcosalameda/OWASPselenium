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
									<template v-if="btn.icon">
										<q-badge-indicator
											v-if="btn.badge && btn.badge.isVisible"
											:color="btn.badge.color">
											<q-icon v-bind="btn.icon" />
										</q-badge-indicator>
										<q-icon
											v-else
											v-bind="btn.icon" />
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
			data-key="INGROUPS"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.INGROUPSPSEUDGROUP1__.isVisible">
					<q-col v-if="controls.INGROUPSPSEUDGROUP1__.isVisible">
						<q-group-box-container
							v-if="controls.INGROUPSPSEUDGROUP1__.isVisible"
							id="INGROUPSPSEUDGROUP1__"
							v-bind="controls.INGROUPSPSEUDGROUP1__"
							:is-visible="controls.INGROUPSPSEUDGROUP1__.isVisible">
							<!-- Start INGROUPSPSEUDGROUP1__ -->
							<q-row v-if="controls.INGROUPSPSEUDINPUTGR1.isVisible">
								<q-col
									v-if="controls.INGROUPSPSEUDINPUTGR1.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.INGROUPSPSEUDINPUTGR1.isVisible"
										id="INGROUPSPSEUDINPUTGR1"
										class="i-text"
										v-bind="controls.INGROUPSPSEUDINPUTGR1"
										v-on="controls.INGROUPSPSEUDINPUTGR1.handlers">
										<q-input-group
											v-bind="controls.INGROUPSPSEUDINPUTGR1.props"
											v-on="controls.INGROUPSPSEUDINPUTGR1.handlers">
											<!-- Start INGROUPSPSEUDINPUTGR1 -->
											<template #prepend>
												<span>
													<q-static-text
														v-if="controls.INGROUPSPSEUDTEXTSPAN.isVisible"
														id="INGROUPSPSEUDTEXTSPAN"
														:size="controls.INGROUPSPSEUDTEXTSPAN.size"
														:text="controls.INGROUPSPSEUDTEXTSPAN.label" />
												</span>
											</template>
											<q-text-field
												v-bind="controls.INGROUPSINPGRTEXTGRO_.props"
												@blur="onBlur(controls.INGROUPSINPGRTEXTGRO_, model.ValTextgro.value)"
												@change="model.ValTextgro.fnUpdateValueOnChange" />
											<!-- End INGROUPSINPGRTEXTGRO_ -->
										</q-input-group>
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End INGROUPSPSEUDGROUP1__ -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.INGROUPSPSEUDGROUP2__.isVisible">
					<q-col v-if="controls.INGROUPSPSEUDGROUP2__.isVisible">
						<q-group-box-container
							v-if="controls.INGROUPSPSEUDGROUP2__.isVisible"
							id="INGROUPSPSEUDGROUP2__"
							v-bind="controls.INGROUPSPSEUDGROUP2__"
							:is-visible="controls.INGROUPSPSEUDGROUP2__.isVisible">
							<!-- Start INGROUPSPSEUDGROUP2__ -->
							<q-row v-if="controls.INGROUPSPSEUDINPUTGR2.isVisible">
								<q-col
									v-if="controls.INGROUPSPSEUDINPUTGR2.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.INGROUPSPSEUDINPUTGR2.isVisible"
										id="INGROUPSPSEUDINPUTGR2"
										class="i-text"
										v-bind="controls.INGROUPSPSEUDINPUTGR2"
										v-on="controls.INGROUPSPSEUDINPUTGR2.handlers">
										<q-input-group
											v-bind="controls.INGROUPSPSEUDINPUTGR2.props"
											v-on="controls.INGROUPSPSEUDINPUTGR2.handlers">
											<!-- Start INGROUPSPSEUDINPUTGR2 -->
											<template #prepend>
												<span>
													<q-static-text
														v-if="controls.INGROUPSPSEUDSPANGRO_.isVisible"
														id="INGROUPSPSEUDSPANGRO_"
														:size="controls.INGROUPSPSEUDSPANGRO_.size"
														:text="controls.INGROUPSPSEUDSPANGRO_.label" />
												</span>
											</template>
											<q-text-field
												v-bind="controls.INGROUPSINPGRNAME____.props"
												@blur="onBlur(controls.INGROUPSINPGRNAME____, model.ValName.value)"
												@change="model.ValName.fnUpdateValueOnChange" />
											<q-text-field
												v-bind="controls.INGROUPSINPGRLASTNAME.props"
												@blur="onBlur(controls.INGROUPSINPGRLASTNAME, model.ValLastname.value)"
												@change="model.ValLastname.fnUpdateValueOnChange" />
											<!-- End INGROUPSINPGRLASTNAME -->
										</q-input-group>
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.INGROUPSPSEUDINPUTGR5.isVisible">
								<q-col
									v-if="controls.INGROUPSPSEUDINPUTGR5.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.INGROUPSPSEUDINPUTGR5.isVisible"
										id="INGROUPSPSEUDINPUTGR5"
										class="i-text"
										v-bind="controls.INGROUPSPSEUDINPUTGR5"
										v-on="controls.INGROUPSPSEUDINPUTGR5.handlers">
										<q-input-group
											v-bind="controls.INGROUPSPSEUDINPUTGR5.props"
											v-on="controls.INGROUPSPSEUDINPUTGR5.handlers">
											<!-- Start INGROUPSPSEUDINPUTGR5 -->
											<q-mask
												v-if="controls.INGROUPSINPGREMAIL___.isVisible"
												v-bind="controls.INGROUPSINPGREMAIL___"
												:model-value="model.ValEmail.value"
												@change="model.ValEmail.fnUpdateValueOnChange" />
											<q-text-field
												v-bind="controls.INGROUPSINPGRWEB_____.props"
												@blur="onBlur(controls.INGROUPSINPGRWEB_____, model.ValWeb.value)"
												@change="model.ValWeb.fnUpdateValueOnChange" />
											<!-- End INGROUPSINPGRWEB_____ -->
										</q-input-group>
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End INGROUPSPSEUDGROUP2__ -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.INGROUPSPSEUDGROUP3__.isVisible">
					<q-col v-if="controls.INGROUPSPSEUDGROUP3__.isVisible">
						<q-group-box-container
							v-if="controls.INGROUPSPSEUDGROUP3__.isVisible"
							id="INGROUPSPSEUDGROUP3__"
							v-bind="controls.INGROUPSPSEUDGROUP3__"
							:is-visible="controls.INGROUPSPSEUDGROUP3__.isVisible">
							<!-- Start INGROUPSPSEUDGROUP3__ -->
							<q-row v-if="controls.INGROUPSPSEUDINPUTGR3.isVisible">
								<q-col
									v-if="controls.INGROUPSPSEUDINPUTGR3.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.INGROUPSPSEUDINPUTGR3.isVisible"
										id="INGROUPSPSEUDINPUTGR3"
										class="i-text"
										v-bind="controls.INGROUPSPSEUDINPUTGR3"
										v-on="controls.INGROUPSPSEUDINPUTGR3.handlers">
										<q-input-group
											v-bind="controls.INGROUPSPSEUDINPUTGR3.props"
											v-on="controls.INGROUPSPSEUDINPUTGR3.handlers">
											<!-- Start INGROUPSPSEUDINPUTGR3 -->
											<q-numeric-input
												v-if="controls.INGROUPSINPGRNUMBGRO_.isVisible"
												v-bind="controls.INGROUPSINPGRNUMBGRO_.props"
												@update:model-value="model.ValNumbgro.fnUpdateValue" />
											<template #append>
												<q-button
													v-if="controls.INGROUPSPSEUDBUTTNGRO.isVisible"
													v-bind="controls.INGROUPSPSEUDBUTTNGRO.props"
													@click="controls.INGROUPSPSEUDBUTTNGRO.action($event)">
													<q-icon v-bind="controls.INGROUPSPSEUDBUTTNGRO.icon" />
												</q-button>
											</template>
											<!-- End INGROUPSPSEUDBUTTNGRO -->
										</q-input-group>
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End INGROUPSPSEUDGROUP3__ -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.INGROUPSPSEUDGROUP4__.isVisible">
					<q-col v-if="controls.INGROUPSPSEUDGROUP4__.isVisible">
						<q-group-box-container
							v-if="controls.INGROUPSPSEUDGROUP4__.isVisible"
							id="INGROUPSPSEUDGROUP4__"
							v-bind="controls.INGROUPSPSEUDGROUP4__"
							:is-visible="controls.INGROUPSPSEUDGROUP4__.isVisible">
							<!-- Start INGROUPSPSEUDGROUP4__ -->
							<q-row v-if="controls.INGROUPSPSEUDINPUTGR4.isVisible">
								<q-col
									v-if="controls.INGROUPSPSEUDINPUTGR4.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.INGROUPSPSEUDINPUTGR4.isVisible"
										id="INGROUPSPSEUDINPUTGR4"
										class="i-text"
										v-bind="controls.INGROUPSPSEUDINPUTGR4"
										v-on="controls.INGROUPSPSEUDINPUTGR4.handlers">
										<q-input-group
											v-bind="controls.INGROUPSPSEUDINPUTGR4.props"
											v-on="controls.INGROUPSPSEUDINPUTGR4.handlers">
											<!-- Start INGROUPSPSEUDINPUTGR4 -->
											<q-select
												v-if="controls.INGROUPSINPGRPREFIX__.isVisible"
												v-bind="controls.INGROUPSINPGRPREFIX__.props"
												@update:model-value="model.ValPrefix.fnUpdateValue" />
											<q-numeric-input
												v-if="controls.INGROUPSINPGRPHONE___.isVisible"
												v-bind="controls.INGROUPSINPGRPHONE___.props"
												@update:model-value="model.ValPhone.fnUpdateValue" />
											<q-select
												v-if="controls.INGROUPSINPGRADRESS__.isVisible"
												v-bind="controls.INGROUPSINPGRADRESS__.props"
												@update:model-value="model.ValAdress.fnUpdateValue" />
											<q-text-field
												v-bind="controls.INGROUPSINPGRDIRECTIO.props"
												@blur="onBlur(controls.INGROUPSINPGRDIRECTIO, model.ValDirectio.value)"
												@change="model.ValDirectio.fnUpdateValueOnChange" />
											<!-- End INGROUPSINPGRDIRECTIO -->
										</q-input-group>
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End INGROUPSPSEUDGROUP4__ -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.INGROUPSPSEUDGROUP6__.isVisible">
					<q-col v-if="controls.INGROUPSPSEUDGROUP6__.isVisible">
						<q-group-box-container
							v-if="controls.INGROUPSPSEUDGROUP6__.isVisible"
							id="INGROUPSPSEUDGROUP6__"
							v-bind="controls.INGROUPSPSEUDGROUP6__"
							:is-visible="controls.INGROUPSPSEUDGROUP6__.isVisible">
							<!-- Start INGROUPSPSEUDGROUP6__ -->
							<q-row v-if="controls.INGROUPSPSEUDINPUTGR6.isVisible">
								<q-col
									v-if="controls.INGROUPSPSEUDINPUTGR6.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.INGROUPSPSEUDINPUTGR6.isVisible"
										id="INGROUPSPSEUDINPUTGR6"
										class="i-text"
										v-bind="controls.INGROUPSPSEUDINPUTGR6"
										v-on="controls.INGROUPSPSEUDINPUTGR6.handlers">
										<q-input-group
											v-bind="controls.INGROUPSPSEUDINPUTGR6.props"
											v-on="controls.INGROUPSPSEUDINPUTGR6.handlers">
											<!-- Start INGROUPSPSEUDINPUTGR6 -->
											<q-select
												v-if="controls.INGROUPSINPGRBANKCOMP.isVisible"
												v-bind="controls.INGROUPSINPGRBANKCOMP.props"
												@update:model-value="model.ValBankcomp.fnUpdateValue" />
											<q-mask
												v-if="controls.INGROUPSINPGRIBAN____.isVisible"
												v-bind="controls.INGROUPSINPGRIBAN____"
												:model-value="model.ValIban.value"
												@change="model.ValIban.fnUpdateValueOnChange" />
											<q-mask
												v-if="controls.INGROUPSINPGRBANKACCO.isVisible"
												v-bind="controls.INGROUPSINPGRBANKACCO"
												:model-value="model.ValBankacco.value"
												@change="model.ValBankacco.fnUpdateValueOnChange" />
											<template #append>
												<q-button
													v-if="controls.INGROUPSPSEUDSAVEBTT_.isVisible"
													v-bind="controls.INGROUPSPSEUDSAVEBTT_.props"
													@click="controls.INGROUPSPSEUDSAVEBTT_.action($event)">
												</q-button>
												<q-button
													v-if="controls.INGROUPSPSEUDSENDBTT_.isVisible"
													v-bind="controls.INGROUPSPSEUDSENDBTT_.props"
													@click="controls.INGROUPSPSEUDSENDBTT_.action($event)">
												</q-button>
											</template>
											<!-- End INGROUPSPSEUDSENDBTT_ -->
										</q-input-group>
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End INGROUPSPSEUDGROUP6__ -->
						</q-group-box-container>
					</q-col>
				</q-row>
			</template>
		</q-container>
	</teleport>

	<hr v-if="!isPopup && showFormFooter" />

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

	import FormViewModel from './QFormIngroupsViewModel.js'

	const requiredTextResources = ['QFormIngroups', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS INGROUPS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormIngroups',

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
					name: 'INGROUPS',
					location: 'form-INGROUPS',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormIngroups', false),

				interfaceMetadata: {
					id: 'QFormIngroups', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'INGROUPS',
					route: 'form-INGROUPS',
					area: 'INPGR',
					primaryKey: 'ValCodinpgr',
					designation: computed(() => this.Resources.INPUT_GROUP17182),
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
						text: computed(() => vm.Resources.SAVE04165),
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
					INGROUPSPSEUDTEXTSPAN: new fieldControlClass.BaseControl({
						id: 'INGROUPSPSEUDTEXTSPAN',
						name: 'TEXTSPAN',
						size: 'mini',
						hasLabel: false,
						label: computed(() => this.Resources.TEXT04938),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR1',
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRNUMBGRO_: new fieldControlClass.MaskControl({
						modelField: 'ValNumbgro',
						valueChangeEvent: 'fieldChange:inpgr.numbgro',
						id: 'INGROUPSINPGRNUMBGRO_',
						name: 'NUMBGRO',
						size: 'small',
						label: computed(() => this.Resources.VAT_NUMBER24236),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR3',
						maxIntegers: 9,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDSPANGRO_: new fieldControlClass.BaseControl({
						id: 'INGROUPSPSEUDSPANGRO_',
						name: 'SPANGRO',
						size: 'mini',
						hasLabel: false,
						label: computed(() => this.Resources.PROFILE65433),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR2',
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDBUTTNGRO: new fieldControlClass.ButtonControl({
						id: 'INGROUPSPSEUDBUTTNGRO',
						name: 'BUTTNGRO',
						hasLabel: false,
						label: computed(() => this.Resources.VIEW62547),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR3',
						icon: {
							icon: 'low',
							type: 'svg',
							role: 'presentation',
						},
						// eslint-disable-next-line
						action: (event) => {
							const btnAction = () => {
								// Button to open the form "INGROUPS" in "VIS" mode.
								const formId = vm.model.ValCodinpgr.value
								if (vm.isEmpty(formId))
									return

								const params = {
									id: formId,
									mode: vm.formModes.show,
									modes: 'vedai',
									isControlled: false,
									extraData: JSON.stringify(event)
								}

								vm.navigateToForm('INGROUPS', vm.formModes.show, null, params)
							}
							btnAction()
						},
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRNAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:inpgr.name',
						id: 'INGROUPSINPGRNAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.FIRST_NAME51967),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR2',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRLASTNAME: new fieldControlClass.StringControl({
						modelField: 'ValLastname',
						valueChangeEvent: 'fieldChange:inpgr.lastname',
						id: 'INGROUPSINPGRLASTNAME',
						name: 'LASTNAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.LAST_NAME63426),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR2',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRPREFIX__: new fieldControlClass.ArrayStringControl({
						modelField: 'ValPrefix',
						valueChangeEvent: 'fieldChange:inpgr.prefix',
						id: 'INGROUPSINPGRPREFIX__',
						name: 'PREFIX',
						size: 'small',
						label: computed(() => this.Resources.PREFIX02493),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR4',
						maxLength: 3,
						arrayName: 'phonepre',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDINPUTGR1: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDINPUTGR1',
						name: 'INPUTGR1',
						size: 'large',
						label: computed(() => this.Resources.TEXT_WITH_INPUT39903),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDGROUP1__',
						isCollapsible: false,
						anchored: false,
						directChildren: ['INGROUPSPSEUDTEXTSPAN', 'INGROUPSINPGRTEXTGRO_'],
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDGROUP1__: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDGROUP1__',
						name: 'GROUP1',
						size: 'block',
						label: computed(() => this.Resources.SINGLE_INPUTS14159),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['INGROUPSPSEUDINPUTGR1'],
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDGROUP2__: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDGROUP2__',
						name: 'GROUP2',
						size: 'block',
						label: computed(() => this.Resources.MULTIPLE_INPUTS39000),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['INGROUPSPSEUDINPUTGR2', 'INGROUPSPSEUDINPUTGR5'],
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDINPUTGR2: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDINPUTGR2',
						name: 'INPUTGR2',
						size: 'xxlarge',
						label: computed(() => this.Resources.USER57012),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDGROUP2__',
						isCollapsible: false,
						anchored: false,
						directChildren: ['INGROUPSPSEUDSPANGRO_', 'INGROUPSINPGRNAME____', 'INGROUPSINPGRLASTNAME'],
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDGROUP3__: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDGROUP3__',
						name: 'GROUP3',
						size: 'block',
						label: computed(() => this.Resources.BUTON_ADDON17405),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['INGROUPSPSEUDINPUTGR3'],
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDINPUTGR3: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDINPUTGR3',
						name: 'INPUTGR3',
						size: 'xlarge',
						label: computed(() => this.Resources.TAX_DATA61628),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDGROUP3__',
						isCollapsible: false,
						anchored: false,
						directChildren: ['INGROUPSINPGRNUMBGRO_', 'INGROUPSPSEUDBUTTNGRO'],
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRPHONE___: new fieldControlClass.NumberControl({
						modelField: 'ValPhone',
						valueChangeEvent: 'fieldChange:inpgr.phone',
						id: 'INGROUPSINPGRPHONE___',
						name: 'PHONE',
						size: 'medium',
						label: computed(() => this.Resources.PHONE_NUMBER20774),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR4',
						maxIntegers: 15,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDGROUP4__: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDGROUP4__',
						name: 'GROUP4',
						size: 'block',
						label: computed(() => this.Resources.CONTACT_DATA02225),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['INGROUPSPSEUDINPUTGR4'],
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDINPUTGR4: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDINPUTGR4',
						name: 'INPUTGR4',
						size: 'large',
						label: computed(() => this.Resources.PHONE_NUMBER20774),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDGROUP4__',
						isCollapsible: false,
						anchored: false,
						directChildren: ['INGROUPSINPGRPREFIX__', 'INGROUPSINPGRPHONE___', 'INGROUPSINPGRADRESS__', 'INGROUPSINPGRDIRECTIO'],
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRADRESS__: new fieldControlClass.ArrayStringControl({
						modelField: 'ValAdress',
						valueChangeEvent: 'fieldChange:inpgr.adress',
						id: 'INGROUPSINPGRADRESS__',
						name: 'ADRESS',
						size: 'medium',
						label: computed(() => this.Resources.ADDRESS_TYPE64627),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR4',
						maxLength: 8,
						arrayName: 'AddressT',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					INGROUPSINPGREMAIL___: new fieldControlClass.MaskControl({
						modelField: 'ValEmail',
						valueChangeEvent: 'fieldChange:inpgr.email',
						id: 'INGROUPSINPGREMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						label: computed(() => this.Resources.E_MAIL42251),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR5',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRWEB_____: new fieldControlClass.StringControl({
						modelField: 'ValWeb',
						valueChangeEvent: 'fieldChange:inpgr.web',
						id: 'INGROUPSINPGRWEB_____',
						name: 'WEB',
						size: 'xxlarge',
						label: computed(() => this.Resources.WEB09813),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR5',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRBANKCOMP: new fieldControlClass.ArrayStringControl({
						modelField: 'ValBankcomp',
						valueChangeEvent: 'fieldChange:inpgr.bankcomp',
						id: 'INGROUPSINPGRBANKCOMP',
						name: 'BANKCOMP',
						size: 'mini',
						label: computed(() => this.Resources.ENTITY62049),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR6',
						maxLength: 2,
						arrayName: 'bankComp',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRIBAN____: new fieldControlClass.MaskControl({
						modelField: 'ValIban',
						valueChangeEvent: 'fieldChange:inpgr.iban',
						id: 'INGROUPSINPGRIBAN____',
						name: 'IBAN',
						size: 'xxlarge',
						label: computed(() => this.Resources.IBAN28506),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR6',
						maxLength: 34,
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRTEXTGRO_: new fieldControlClass.StringControl({
						modelField: 'ValTextgro',
						valueChangeEvent: 'fieldChange:inpgr.textgro',
						id: 'INGROUPSINPGRTEXTGRO_',
						name: 'TEXTGRO',
						size: 'xxlarge',
						label: computed(() => this.Resources.TEXT_FIELD41810),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR1',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRBANKACCO: new fieldControlClass.MaskControl({
						modelField: 'ValBankacco',
						valueChangeEvent: 'fieldChange:inpgr.bankacco',
						id: 'INGROUPSINPGRBANKACCO',
						name: 'BANKACCO',
						size: 'large',
						label: computed(() => this.Resources.BANKING_ACCOUNT_NUMB62548),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR6',
						maxLength: 24,
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRDIRECTIO: new fieldControlClass.StringControl({
						modelField: 'ValDirectio',
						valueChangeEvent: 'fieldChange:inpgr.directio',
						id: 'INGROUPSINPGRDIRECTIO',
						name: 'DIRECTIO',
						size: 'xlarge',
						label: computed(() => this.Resources.ADRESS39816),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR4',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDSAVEBTT_: new fieldControlClass.ButtonControl({
						id: 'INGROUPSPSEUDSAVEBTT_',
						name: 'SAVEBTT',
						hasLabel: false,
						label: computed(() => this.Resources.VIEW62547),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR6',
						// eslint-disable-next-line
						action: (event) => {
							const btnAction = () => {
								// Button to open the form "INGROUPS" in "VIS" mode.
								const formId = vm.model.ValCodinpgr.value
								if (vm.isEmpty(formId))
									return

								const params = {
									id: formId,
									mode: vm.formModes.show,
									modes: 'vedai',
									isControlled: true,
									extraData: JSON.stringify(event)
								}

								vm.navigateToForm('INGROUPS', vm.formModes.show, null, params)
							}
							const options = {
								form: 'INGROUPS',
								callback: btnAction
							}
							vm.$eventHub.emit('form-apply', options)
						},
						controlLimits: [
						],
						showWhen: {
							// eslint-disable-next-line @typescript-eslint/no-unused-vars
							fnFormula(params)
							{
								// Formula: emptyC([INPGR->IBAN])==0
								return qApi.emptyC(this.ValIban.value)===0
							},
							dependencyEvents: ['fieldChange:inpgr.iban'],
							isServerRecalc: false,
						},
					}, this),
					INGROUPSPSEUDSENDBTT_: new fieldControlClass.ButtonControl({
						id: 'INGROUPSPSEUDSENDBTT_',
						name: 'SENDBTT',
						hasLabel: false,
						label: computed(() => this.Resources.VIEW62547),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR6',
						// eslint-disable-next-line
						action: (event) => {
							const btnAction = () => {
								// Button to open the form "INGROUPS" in "INS" mode.
								const params = {
									mode: vm.formModes.new,
									modes: 'vedai',
									isControlled: true,
									extraData: JSON.stringify(event)
								}

								vm.navigateToForm('INGROUPS', vm.formModes.new, null, params)
							}
							const options = {
								form: 'INGROUPS',
								callback: btnAction
							}
							vm.$eventHub.emit('form-apply', options)
						},
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDINPUTGR6: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDINPUTGR6',
						name: 'INPUTGR6',
						size: 'medium',
						label: computed(() => this.Resources.BANK_ACCOUNT11383),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDGROUP6__',
						isCollapsible: false,
						anchored: false,
						directChildren: ['INGROUPSINPGRBANKCOMP', 'INGROUPSINPGRIBAN____', 'INGROUPSINPGRBANKACCO', 'INGROUPSPSEUDSAVEBTT_', 'INGROUPSPSEUDSENDBTT_'],
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDGROUP6__: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDGROUP6__',
						name: 'GROUP6',
						size: 'block',
						label: computed(() => this.Resources.BANK_DATA61943),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['INGROUPSPSEUDINPUTGR6'],
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDINPUTGR5: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDINPUTGR5',
						name: 'INPUTGR5',
						size: 'large',
						label: computed(() => this.Resources.EMAIL_AND_WEB32577),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDGROUP2__',
						isCollapsible: false,
						anchored: false,
						directChildren: ['INGROUPSINPGREMAIL___', 'INGROUPSINPGRWEB_____'],
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
					'INGROUPSPSEUDGROUP1__',
					'INGROUPSPSEUDINPUTGR1',
					'INGROUPSPSEUDGROUP2__',
					'INGROUPSPSEUDINPUTGR2',
					'INGROUPSPSEUDINPUTGR5',
					'INGROUPSPSEUDGROUP3__',
					'INGROUPSPSEUDINPUTGR3',
					'INGROUPSPSEUDGROUP4__',
					'INGROUPSPSEUDINPUTGR4',
					'INGROUPSPSEUDGROUP6__',
					'INGROUPSPSEUDINPUTGR6',
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Inpgr: {
						get ValAdress() { return vm.model.ValAdress.value },
						set ValAdress(value) { vm.model.ValAdress.updateValue(value) },
						get ValBankacco() { return vm.model.ValBankacco.value },
						set ValBankacco(value) { vm.model.ValBankacco.updateValue(value) },
						get ValBankcomp() { return vm.model.ValBankcomp.value },
						set ValBankcomp(value) { vm.model.ValBankcomp.updateValue(value) },
						get ValDirectio() { return vm.model.ValDirectio.value },
						set ValDirectio(value) { vm.model.ValDirectio.updateValue(value) },
						get ValEmail() { return vm.model.ValEmail.value },
						set ValEmail(value) { vm.model.ValEmail.updateValue(value) },
						get ValIban() { return vm.model.ValIban.value },
						set ValIban(value) { vm.model.ValIban.updateValue(value) },
						get ValIcongro() { return vm.model.ValIcongro.value },
						set ValIcongro(value) { vm.model.ValIcongro.updateValue(value) },
						get ValLastname() { return vm.model.ValLastname.value },
						set ValLastname(value) { vm.model.ValLastname.updateValue(value) },
						get ValName() { return vm.model.ValName.value },
						set ValName(value) { vm.model.ValName.updateValue(value) },
						get ValNumbgro() { return vm.model.ValNumbgro.value },
						set ValNumbgro(value) { vm.model.ValNumbgro.updateValue(value) },
						get ValPhone() { return vm.model.ValPhone.value },
						set ValPhone(value) { vm.model.ValPhone.updateValue(value) },
						get ValPrefix() { return vm.model.ValPrefix.value },
						set ValPrefix(value) { vm.model.ValPrefix.updateValue(value) },
						get ValTextgro() { return vm.model.ValTextgro.value },
						set ValTextgro(value) { vm.model.ValTextgro.updateValue(value) },
						get ValWeb() { return vm.model.ValWeb.value },
						set ValWeb(value) { vm.model.ValWeb.updateValue(value) },
					},
					keys: {
						/** The primary key of the INPGR table */
						get inpgr() { return vm.model.ValCodinpgr },
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
// USE /[MANUAL GQT FORM_CODEJS INGROUPS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT INGROUPS]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS INGROUPS]/
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
// USE /[MANUAL GQT FORM_LOADED_JS INGROUPS]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS INGROUPS]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS INGROUPS]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS INGROUPS]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS INGROUPS]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS INGROUPS]/
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
// USE /[MANUAL GQT AFTER_DEL_JS INGROUPS]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS INGROUPS]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS INGROUPS]/
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
// USE /[MANUAL GQT DLGUPDT INGROUPS]/
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
// USE /[MANUAL GQT CTRLBLR INGROUPS]/
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
// USE /[MANUAL GQT CTRLUPD INGROUPS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS INGROUPS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
