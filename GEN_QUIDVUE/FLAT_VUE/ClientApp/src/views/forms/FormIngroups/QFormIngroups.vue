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
				v-if="layoutConfig.FormAnchorsPosition === 'form-header' && groupFields.length > 0"
				:is-visible="anchorContainerVisibility"
				:anchors="groupFields"
				:controls="controls"
				:header-height="visibleHeaderHeight"
				@focus-control="(...args) => focusControl(...args)" />
		</div>
	</teleport>

	<teleport
		v-if="formModalIsReady && showFormBody"
		:to="`#${uiContainersId.body}`"
		:disabled="!isPopup || isNested">
		<q-validation-summary
			:error-data="validationErrors"
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
			data-key="INGROUPS"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container
					v-show="controls.INGROUPSPSEUDGROUP1__.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.INGROUPSPSEUDGROUP1__.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="INGROUPSPSEUDGROUP1__"
							v-bind="controls.INGROUPSPSEUDGROUP1__"
							:is-visible="controls.INGROUPSPSEUDGROUP1__.isVisible">
							<!-- Start INGROUPSPSEUDGROUP1__ -->
							<q-row-container v-show="controls.INGROUPSPSEUDINPUTGR1.isVisible">
								<q-control-wrapper
									v-show="controls.INGROUPSPSEUDINPUTGR1.isVisible"
									class="control-join-group">
									<base-input-structure
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
														size="mini"
														:text="controls.INGROUPSPSEUDTEXTSPAN.label" />
												</span>
											</template>
											<q-text-field
												v-bind="controls.INGROUPSINPGRTEXTGRO_.props"
												:model-value="model.ValTextgro.value"
												@update:model-value="model.ValTextgro.fnUpdateValue" />
											<!-- End INGROUPSPSEUDINPUTGR1 -->
										</q-input-group>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End INGROUPSPSEUDGROUP1__ -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.INGROUPSPSEUDGROUP2__.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.INGROUPSPSEUDGROUP2__.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="INGROUPSPSEUDGROUP2__"
							v-bind="controls.INGROUPSPSEUDGROUP2__"
							:is-visible="controls.INGROUPSPSEUDGROUP2__.isVisible">
							<!-- Start INGROUPSPSEUDGROUP2__ -->
							<q-row-container v-show="controls.INGROUPSPSEUDINPUTGR2.isVisible">
								<q-control-wrapper
									v-show="controls.INGROUPSPSEUDINPUTGR2.isVisible"
									class="control-join-group">
									<base-input-structure
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
														size="mini"
														:text="controls.INGROUPSPSEUDSPANGRO_.label" />
												</span>
											</template>
											<q-text-field
												v-bind="controls.INGROUPSINPGRNAME____.props"
												:model-value="model.ValName.value"
												@update:model-value="model.ValName.fnUpdateValue" />
											<q-text-field
												v-bind="controls.INGROUPSINPGRLASTNAME.props"
												:model-value="model.ValLastname.value"
												@update:model-value="model.ValLastname.fnUpdateValue" />
											<!-- End INGROUPSPSEUDINPUTGR2 -->
										</q-input-group>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.INGROUPSPSEUDINPUTGR5.isVisible">
								<q-control-wrapper
									v-show="controls.INGROUPSPSEUDINPUTGR5.isVisible"
									class="control-join-group">
									<base-input-structure
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
												@update:model-value="model.ValEmail.fnUpdateValue" />
											<q-text-field
												v-bind="controls.INGROUPSINPGRWEB_____.props"
												:model-value="model.ValWeb.value"
												@update:model-value="model.ValWeb.fnUpdateValue" />
											<!-- End INGROUPSPSEUDINPUTGR5 -->
										</q-input-group>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End INGROUPSPSEUDGROUP2__ -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.INGROUPSPSEUDGROUP3__.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.INGROUPSPSEUDGROUP3__.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="INGROUPSPSEUDGROUP3__"
							v-bind="controls.INGROUPSPSEUDGROUP3__"
							:is-visible="controls.INGROUPSPSEUDGROUP3__.isVisible">
							<!-- Start INGROUPSPSEUDGROUP3__ -->
							<q-row-container v-show="controls.INGROUPSPSEUDINPUTGR3.isVisible">
								<q-control-wrapper
									v-show="controls.INGROUPSPSEUDINPUTGR3.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INGROUPSPSEUDINPUTGR3"
										v-on="controls.INGROUPSPSEUDINPUTGR3.handlers">
										<q-input-group
											v-bind="controls.INGROUPSPSEUDINPUTGR3.props"
											v-on="controls.INGROUPSPSEUDINPUTGR3.handlers">
											<!-- Start INGROUPSPSEUDINPUTGR3 -->
											<q-numeric-input
												v-if="controls.INGROUPSINPGRNUMBGRO_.isVisible"
												v-bind="controls.INGROUPSINPGRNUMBGRO_"
												:model-value="model.ValNumbgro.value"
												@update:model-value="model.ValNumbgro.fnUpdateValue" />
											<template #append>
												<q-button
													v-if="controls.INGROUPSPSEUDBUTTNGRO.isVisible"
													id="INGROUPSPSEUDBUTTNGRO"
													:label="controls.INGROUPSPSEUDBUTTNGRO.label"
													:disabled="controls.INGROUPSPSEUDBUTTNGRO.isBlocked"
													@click="controls.INGROUPSPSEUDBUTTNGRO.action($event)">
													<q-icon v-bind="controls.INGROUPSPSEUDBUTTNGRO.icon" />
												</q-button>
											</template>
											<!-- End INGROUPSPSEUDINPUTGR3 -->
										</q-input-group>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End INGROUPSPSEUDGROUP3__ -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.INGROUPSPSEUDGROUP4__.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.INGROUPSPSEUDGROUP4__.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="INGROUPSPSEUDGROUP4__"
							v-bind="controls.INGROUPSPSEUDGROUP4__"
							:is-visible="controls.INGROUPSPSEUDGROUP4__.isVisible">
							<!-- Start INGROUPSPSEUDGROUP4__ -->
							<q-row-container v-show="controls.INGROUPSPSEUDINPUTGR4.isVisible">
								<q-control-wrapper
									v-show="controls.INGROUPSPSEUDINPUTGR4.isVisible"
									class="control-join-group">
									<base-input-structure
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
												:model-value="model.ValPrefix.value"
												@update:model-value="model.ValPrefix.fnUpdateValue" />
											<q-numeric-input
												v-if="controls.INGROUPSINPGRPHONE___.isVisible"
												v-bind="controls.INGROUPSINPGRPHONE___"
												:model-value="model.ValPhone.value"
												@update:model-value="model.ValPhone.fnUpdateValue" />
											<q-select
												v-if="controls.INGROUPSINPGRADRESS__.isVisible"
												v-bind="controls.INGROUPSINPGRADRESS__.props"
												:model-value="model.ValAdress.value"
												@update:model-value="model.ValAdress.fnUpdateValue" />
											<q-text-field
												v-bind="controls.INGROUPSINPGRDIRECTIO.props"
												:model-value="model.ValDirectio.value"
												@update:model-value="model.ValDirectio.fnUpdateValue" />
											<!-- End INGROUPSPSEUDINPUTGR4 -->
										</q-input-group>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End INGROUPSPSEUDGROUP4__ -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.INGROUPSPSEUDGROUP6__.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.INGROUPSPSEUDGROUP6__.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="INGROUPSPSEUDGROUP6__"
							v-bind="controls.INGROUPSPSEUDGROUP6__"
							:is-visible="controls.INGROUPSPSEUDGROUP6__.isVisible">
							<!-- Start INGROUPSPSEUDGROUP6__ -->
							<q-row-container v-show="controls.INGROUPSPSEUDINPUTGR6.isVisible">
								<q-control-wrapper
									v-show="controls.INGROUPSPSEUDINPUTGR6.isVisible"
									class="control-join-group">
									<base-input-structure
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
												:model-value="model.ValBankcomp.value"
												@update:model-value="model.ValBankcomp.fnUpdateValue" />
											<q-mask
												v-if="controls.INGROUPSINPGRIBAN____.isVisible"
												v-bind="controls.INGROUPSINPGRIBAN____"
												:model-value="model.ValIban.value"
												@update:model-value="model.ValIban.fnUpdateValue" />
											<q-mask
												v-if="controls.INGROUPSINPGRBANKACCO.isVisible"
												v-bind="controls.INGROUPSINPGRBANKACCO"
												:model-value="model.ValBankacco.value"
												@update:model-value="model.ValBankacco.fnUpdateValue" />
											<template #append>
												<q-button
													v-if="controls.INGROUPSPSEUDSAVEBTT_.isVisible"
													id="INGROUPSPSEUDSAVEBTT_"
													:label="controls.INGROUPSPSEUDSAVEBTT_.label"
													:disabled="controls.INGROUPSPSEUDSAVEBTT_.isBlocked"
													@click="controls.INGROUPSPSEUDSAVEBTT_.action($event)">
												</q-button>
												<q-button
													v-if="controls.INGROUPSPSEUDSENDBTT_.isVisible"
													id="INGROUPSPSEUDSENDBTT_"
													:label="controls.INGROUPSPSEUDSENDBTT_.label"
													:disabled="controls.INGROUPSPSEUDSENDBTT_.isBlocked"
													@click="controls.INGROUPSPSEUDSENDBTT_.action($event)">
												</q-button>
											</template>
											<!-- End INGROUPSPSEUDINPUTGR6 -->
										</q-input-group>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End INGROUPSPSEUDGROUP6__ -->
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
				default: () => {
					return {
						name: 'INGROUPS',
						location: 'form-INGROUPS',
						params: {
							isNested: true
						}
					}
				}
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
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.insert]),
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
						action: vm.resetFormFields,
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
					},
					showAnchors: {
						id: 'toggle-form-anchors',
						icon: {
							icon: 'list-bordered',
							type: 'svg'
						},
						text: computed(() => vm.anchorContainerVisibility ? vm.Resources[hardcodedTexts.hideAnchors] : vm.Resources[hardcodedTexts.showAnchors]),
						type: 'form-action',
						style: 'primary',
						showInHeader: true,
						showInFooter: false,
						isActive: true,
						isVisible: computed(() => vm.isAnchorsButtonVisible),
						action: vm.toggleAnchorVisibility
					}
				},

				controls: {
					INGROUPSPSEUDTEXTSPAN: new fieldControlClass.BaseControl({
						id: 'INGROUPSPSEUDTEXTSPAN',
						name: 'TEXTSPAN',
						size: 'mini',
						hasLabel: false,
						label: computed(() => this.Resources.TEXT04938),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'INGROUPSPSEUDINPUTGR1',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRNUMBGRO_: new fieldControlClass.MaskControl({
						modelField: 'ValNumbgro',
						valueChangeEvent: 'fieldChange:inpgr.numbgro',
						maxIntegers: 9,
						maxDecimals: 0,
						id: 'INGROUPSINPGRNUMBGRO_',
						name: 'NUMBGRO',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.VAT_NUMBER24236),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR3',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDSPANGRO_: new fieldControlClass.BaseControl({
						id: 'INGROUPSPSEUDSPANGRO_',
						name: 'SPANGRO',
						size: 'mini',
						hasLabel: false,
						label: computed(() => this.Resources.PROFILE65433),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'INGROUPSPSEUDINPUTGR2',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDBUTTNGRO: new fieldControlClass.ButtonControl({
						id: 'INGROUPSPSEUDBUTTNGRO',
						name: 'BUTTNGRO',
						size: 'xxlarge',
						hasLabel: false,
						label: computed(() => this.Resources.VIEW62547),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'INGROUPSPSEUDINPUTGR3',
						icon: {
							icon: 'low',
							type: 'svg',
						},
						// eslint-disable-next-line
						action: (event) => {
							let btnAction = () => {
								// Button to open the form "INGROUPS" in "VIS" mode.
								const formId = vm.model.ValCodinpgr.value
								if (vm.isEmpty(formId))
									return

								const params = {
									id: formId,
									mode: vm.formModes.show,
									modes: vm.navigation.currentLevel.params.modes,
									isControlled: false,
									extraData: JSON.stringify(event)
								}

								vm.navigateToForm('INGROUPS', vm.formModes.show, null, params)
							}
							btnAction()
						},
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRNAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:inpgr.name',
						id: 'INGROUPSINPGRNAME____',
						name: 'NAME',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.FIRST_NAME51967),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR2',
						maxLength: 50,
						labelId: 'label_INGROUPSINPGRNAME____',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRLASTNAME: new fieldControlClass.StringControl({
						modelField: 'ValLastname',
						valueChangeEvent: 'fieldChange:inpgr.lastname',
						id: 'INGROUPSINPGRLASTNAME',
						name: 'LASTNAME',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.LAST_NAME63426),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR2',
						maxLength: 50,
						labelId: 'label_INGROUPSINPGRLASTNAME',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRPREFIX__: new fieldControlClass.ArrayStringControl({
						modelField: 'ValPrefix',
						valueChangeEvent: 'fieldChange:inpgr.prefix',
						id: 'INGROUPSINPGRPREFIX__',
						name: 'PREFIX',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.PREFIX02493),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR4',
						maxLength: 3,
						labelId: 'label_INGROUPSINPGRPREFIX__',
						arrayName: 'phonepre',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDINPUTGR1: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDINPUTGR1',
						name: 'INPUTGR1',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.TEXT_WITH_INPUT39903),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'INGROUPSPSEUDGROUP1__',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDGROUP1__: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDGROUP1__',
						name: 'GROUP1',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.SINGLE_INPUTS14159),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDGROUP2__: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDGROUP2__',
						name: 'GROUP2',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.MULTIPLE_INPUTS39000),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDINPUTGR2: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDINPUTGR2',
						name: 'INPUTGR2',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.USER57012),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'INGROUPSPSEUDGROUP2__',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDGROUP3__: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDGROUP3__',
						name: 'GROUP3',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.BUTON_ADDON17405),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDINPUTGR3: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDINPUTGR3',
						name: 'INPUTGR3',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.TAX_DATA61628),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'INGROUPSPSEUDGROUP3__',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRPHONE___: new fieldControlClass.NumberControl({
						modelField: 'ValPhone',
						valueChangeEvent: 'fieldChange:inpgr.phone',
						maxIntegers: 15,
						maxDecimals: 0,
						id: 'INGROUPSINPGRPHONE___',
						name: 'PHONE',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.PHONE_NUMBER20774),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR4',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDGROUP4__: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDGROUP4__',
						name: 'GROUP4',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.CONTACT_DATA02225),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDINPUTGR4: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDINPUTGR4',
						name: 'INPUTGR4',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.PHONE_NUMBER20774),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'INGROUPSPSEUDGROUP4__',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRADRESS__: new fieldControlClass.ArrayStringControl({
						modelField: 'ValAdress',
						valueChangeEvent: 'fieldChange:inpgr.adress',
						id: 'INGROUPSINPGRADRESS__',
						name: 'ADRESS',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.ADDRESS_TYPE64627),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR4',
						maxLength: 8,
						labelId: 'label_INGROUPSINPGRADRESS__',
						arrayName: 'AddressT',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSINPGREMAIL___: new fieldControlClass.MaskControl({
						modelField: 'ValEmail',
						valueChangeEvent: 'fieldChange:inpgr.email',
						id: 'INGROUPSINPGREMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.E_MAIL42251),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR5',
						maxLength: 50,
						labelId: 'label_INGROUPSINPGREMAIL___',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRWEB_____: new fieldControlClass.StringControl({
						modelField: 'ValWeb',
						valueChangeEvent: 'fieldChange:inpgr.web',
						id: 'INGROUPSINPGRWEB_____',
						name: 'WEB',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.WEB09813),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR5',
						maxLength: 50,
						labelId: 'label_INGROUPSINPGRWEB_____',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRBANKCOMP: new fieldControlClass.ArrayStringControl({
						modelField: 'ValBankcomp',
						valueChangeEvent: 'fieldChange:inpgr.bankcomp',
						id: 'INGROUPSINPGRBANKCOMP',
						name: 'BANKCOMP',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.ENTITY62049),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR6',
						maxLength: 2,
						labelId: 'label_INGROUPSINPGRBANKCOMP',
						arrayName: 'bankComp',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRIBAN____: new fieldControlClass.MaskControl({
						modelField: 'ValIban',
						valueChangeEvent: 'fieldChange:inpgr.iban',
						id: 'INGROUPSINPGRIBAN____',
						name: 'IBAN',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.IBAN28506),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR6',
						maxLength: 34,
						labelId: 'label_INGROUPSINPGRIBAN____',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRTEXTGRO_: new fieldControlClass.StringControl({
						modelField: 'ValTextgro',
						valueChangeEvent: 'fieldChange:inpgr.textgro',
						id: 'INGROUPSINPGRTEXTGRO_',
						name: 'TEXTGRO',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.TEXT_FIELD41810),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR1',
						maxLength: 50,
						labelId: 'label_INGROUPSINPGRTEXTGRO_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRBANKACCO: new fieldControlClass.MaskControl({
						modelField: 'ValBankacco',
						valueChangeEvent: 'fieldChange:inpgr.bankacco',
						id: 'INGROUPSINPGRBANKACCO',
						name: 'BANKACCO',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.BANKING_ACCOUNT_NUMB62548),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR6',
						maxLength: 24,
						labelId: 'label_INGROUPSINPGRBANKACCO',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSINPGRDIRECTIO: new fieldControlClass.StringControl({
						modelField: 'ValDirectio',
						valueChangeEvent: 'fieldChange:inpgr.directio',
						id: 'INGROUPSINPGRDIRECTIO',
						name: 'DIRECTIO',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.ADRESS39816),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INGROUPSPSEUDINPUTGR4',
						maxLength: 50,
						labelId: 'label_INGROUPSINPGRDIRECTIO',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDSAVEBTT_: new fieldControlClass.ButtonControl({
						id: 'INGROUPSPSEUDSAVEBTT_',
						name: 'SAVEBTT',
						size: 'mini',
						hasLabel: false,
						label: computed(() => this.Resources.VIEW62547),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'INGROUPSPSEUDINPUTGR6',
						// eslint-disable-next-line
						action: (event) => {
							let btnAction = () => {
								// Button to open the form "INGROUPS" in "VIS" mode.
								const formId = vm.model.ValCodinpgr.value
								if (vm.isEmpty(formId))
									return

								const params = {
									id: formId,
									mode: vm.formModes.show,
									modes: vm.navigation.currentLevel.params.modes,
									isControlled: true,
									extraData: JSON.stringify(event)
								}

								vm.navigateToForm('INGROUPS', vm.formModes.show, null, params)
							}
							let options = {
								form: 'INGROUPS',
								callback: btnAction
							}
							vm.$eventHub.emit('form-apply', options)
						},
						mustBeFilled: false,
						controlLimits: [
						],
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: emptyC([INPGR->IBAN])==0
								// eslint-disable-next-line eqeqeq
								return qApi.emptyC(this.ValIban.value)==0
							},
							dependencyEvents: ['fieldChange:inpgr.iban'],
							isServerRecalc: false,
							isServerFormula: false,
						},
					}, this),
					INGROUPSPSEUDSENDBTT_: new fieldControlClass.ButtonControl({
						id: 'INGROUPSPSEUDSENDBTT_',
						name: 'SENDBTT',
						size: 'mini',
						hasLabel: false,
						label: computed(() => this.Resources.VIEW62547),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'INGROUPSPSEUDINPUTGR6',
						// eslint-disable-next-line
						action: (event) => {
							let btnAction = () => {
								// Button to open the form "INGROUPS" in "INS" mode.
								const params = {
									mode: vm.formModes.new,
									modes: vm.navigation.currentLevel.params.modes,
									isControlled: true,
									extraData: JSON.stringify(event)
								}

								vm.navigateToForm('INGROUPS', vm.formModes.new, null, params)
							}
							let options = {
								form: 'INGROUPS',
								callback: btnAction
							}
							vm.$eventHub.emit('form-apply', options)
						},
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDINPUTGR6: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDINPUTGR6',
						name: 'INPUTGR6',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.BANK_ACCOUNT11383),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'INGROUPSPSEUDGROUP6__',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDGROUP6__: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDGROUP6__',
						name: 'GROUP6',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.BANK_DATA61943),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					INGROUPSPSEUDINPUTGR5: new fieldControlClass.GroupControl({
						id: 'INGROUPSPSEUDINPUTGR5',
						name: 'INPUTGR5',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.EMAIL_AND_WEB32577),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'INGROUPSPSEUDGROUP2__',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
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
					extraProperties: {}
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
// USE /[MANUAL GQT BEFORE_LOAD_JS INGROUPS]/
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
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

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
				for (let trigger of triggers)
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
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

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
				let redirectPage = true // Set to 'false' to cancel page redirect.

				// Execute the "After save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterSave)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT AFTER_SAVE_JS INGROUPS]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS INGROUPS]/
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
// USE /[MANUAL GQT AFTER_DEL_JS INGROUPS]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS INGROUPS]/
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
		},

		watch: {
		}
	}
</script>
