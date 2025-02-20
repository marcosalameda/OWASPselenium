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
			data-key="PEDID"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.PEDID___PEDIDDTPEDIDO.isVisible || controls.PEDID___PEDIDNRPEDIDO.isVisible">
					<q-control-wrapper
						v-show="controls.PEDID___PEDIDDTPEDIDO.isVisible || controls.PEDID___PEDIDNRPEDIDO.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PEDID___PEDIDDTPEDIDO"
							v-on="controls.PEDID___PEDIDDTPEDIDO.handlers"
							:loading="controls.PEDID___PEDIDDTPEDIDO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.PEDID___PEDIDDTPEDIDO.isVisible"
								v-bind="controls.PEDID___PEDIDDTPEDIDO.props"
								:model-value="model.ValDtpedido.value"
								@reset-icon-click="model.ValDtpedido.fnUpdateValue(model.ValDtpedido.originalValue ?? new Date())"
								@update:model-value="model.ValDtpedido.fnUpdateValue($event ?? '')" />
						</base-input-structure>
						<base-input-structure
							class="i-text"
							v-bind="controls.PEDID___PEDIDNRPEDIDO"
							v-on="controls.PEDID___PEDIDNRPEDIDO.handlers"
							:loading="controls.PEDID___PEDIDNRPEDIDO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.PEDID___PEDIDNRPEDIDO.isVisible"
								v-bind="controls.PEDID___PEDIDNRPEDIDO.props"
								@update:model-value="model.ValNrpedido.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PEDID___PEDIDMOTIVO__.isVisible">
					<q-control-wrapper
						v-show="controls.PEDID___PEDIDMOTIVO__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-textarea"
							v-bind="controls.PEDID___PEDIDMOTIVO__"
							v-on="controls.PEDID___PEDIDMOTIVO__.handlers"
							:loading="controls.PEDID___PEDIDMOTIVO__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-textarea-input
								v-if="controls.PEDID___PEDIDMOTIVO__.isVisible"
								v-bind="controls.PEDID___PEDIDMOTIVO__.props"
								id="PEDID___PEDIDMOTIVO__"
								:model-value="model.ValMotivo.value"
								:rows="3"
								:cols="85"
								@update:model-value="model.ValMotivo.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PEDID___PSEUDLINHAS__.isVisible">
					<q-control-wrapper
						v-show="controls.PEDID___PSEUDLINHAS__.isVisible"
						class="control-join-group">
						<q-table
							v-show="controls.PEDID___PSEUDLINHAS__.isVisible"
							v-bind="controls.PEDID___PSEUDLINHAS__"
							v-on="controls.PEDID___PSEUDLINHAS__.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.PEDID___PSEUDLINHAS__"
							v-on="controls.PEDID___PSEUDLINHAS__.handlers" />
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PEDID___PSEUDDESAGREG.isVisible">
					<q-control-wrapper
						v-show="controls.PEDID___PSEUDDESAGREG.isVisible"
						class="control-join-group">
						<q-table
							v-show="controls.PEDID___PSEUDDESAGREG.isVisible"
							v-bind="controls.PEDID___PSEUDDESAGREG"
							v-on="controls.PEDID___PSEUDDESAGREG.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.PEDID___PSEUDDESAGREG"
							v-on="controls.PEDID___PSEUDDESAGREG.handlers" />
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PEDID___PSEUDAGRUPAME.isVisible">
					<q-control-wrapper
						v-show="controls.PEDID___PSEUDAGRUPAME.isVisible"
						class="control-join-group">
						<q-table
							v-show="controls.PEDID___PSEUDAGRUPAME.isVisible"
							v-bind="controls.PEDID___PSEUDAGRUPAME"
							v-on="controls.PEDID___PSEUDAGRUPAME.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.PEDID___PSEUDAGRUPAME"
							v-on="controls.PEDID___PSEUDAGRUPAME.handlers" />
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

	import FormViewModel from './QFormPedidViewModel.js'

	const requiredTextResources = ['QFormPedid', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PEDID]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormPedid',

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
					name: 'PEDID',
					location: 'form-PEDID',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormPedid', false),

				interfaceMetadata: {
					id: 'QFormPedid', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'PEDID',
					route: 'form-PEDID',
					area: 'PEDID',
					primaryKey: 'ValCodpedid',
					designation: computed(() => this.Resources.EQUIPMENT_REQUEST62893),
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
					PEDID___PEDIDDTPEDIDO: new fieldControlClass.DateControl({
						modelField: 'ValDtpedido',
						valueChangeEvent: 'fieldChange:pedid.dtpedido',
						id: 'PEDID___PEDIDDTPEDIDO',
						name: 'DTPEDIDO',
						size: 'small',
						label: computed(() => this.Resources.DATE_55218),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						format: 'date',
						controlLimits: [
						],
					}, this),
					PEDID___PEDIDNRPEDIDO: new fieldControlClass.NumberControl({
						modelField: 'ValNrpedido',
						valueChangeEvent: 'fieldChange:pedid.nrpedido',
						id: 'PEDID___PEDIDNRPEDIDO',
						name: 'NRPEDIDO',
						size: 'mini',
						label: computed(() => this.Resources.NUMBER35625),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 6,
						maxDecimals: 0,
						isSequencial: true,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					PEDID___PEDIDMOTIVO__: new fieldControlClass.StringControl({
						modelField: 'ValMotivo',
						valueChangeEvent: 'fieldChange:pedid.motivo',
						id: 'PEDID___PEDIDMOTIVO__',
						name: 'MOTIVO',
						size: 'xxlarge',
						label: computed(() => this.Resources.MOTIVE_64781),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controlLimits: [
						],
					}, this),
					PEDID___PSEUDLINHAS__: new fieldControlClass.TableListControl({
						id: 'PEDID___PSEUDLINHAS__',
						name: 'LINHAS',
						size: '',
						label: computed(() => this.Resources.LINES35526),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'PEDID',
						action: 'Pedid_ValLinhas',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.NumericColumn({
								order: 1,
								name: 'ValLine',
								area: 'LNHPD',
								field: 'LINE',
								label: computed(() => this.Resources.LINE27983),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 2,
								name: 'ValQuantida',
								area: 'LNHPD',
								field: 'QUANTIDA',
								label: computed(() => this.Resources.AMOUNT46885),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}),
						],
						config: {
							name: 'ValLinhas',
							serverMode: true,
							pkColumn: 'ValCodlnhpd',
							tableAlias: 'LNHPD',
							tableNamePlural: computed(() => this.Resources.ORDER_LINES32071),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.LINES35526),
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
										formName: 'LNHPD',
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
										formName: 'LNHPD',
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
										formName: 'LNHPD',
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
										formName: 'LNHPD',
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
										formName: 'LNHPD',
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
								id: 'RCA__LNHPD',
								name: '_LNHPD',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'LNHPD',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'LNHPD': {
									fnKeySelector: (row) => row.Fields.ValCodlnhpd,
									isPopup: false
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'ValLine',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-LNHPD', 'changed-PEDID', 'changed-TPEQU'],
						uuid: 'Pedid_ValLinhas',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'pedid'],
								dependencyEvents: ['fieldChange:pedid.codpedid'],
								dependencyField: 'PEDID.CODPEDID',
								fnValueSelector: (model) => model.ValCodpedid.value
							},
						],
					}, this),
					PEDID___PSEUDDESAGREG: new fieldControlClass.TableListControl({
						id: 'PEDID___PSEUDDESAGREG',
						name: 'DESAGREG',
						size: '',
						helpControl: {
							shortHelp: {
								type: '',
								text: computed(() => this.Resources._110050187),
							},
							detailedHelp: {
								type: '',
								text: computed(() => this.Resources._1100_VERBOSE38633),
							}
						},
						label: computed(() => this.Resources.BREAKDOWN_60448),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'PEDID',
						action: 'Pedid_ValDesagreg',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.NumericColumn({
								order: 1,
								name: 'ValOrdem',
								area: 'LNHDE',
								field: 'ORDEM',
								label: computed(() => this.Resources.ORDER39632),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'Tpeq1.ValTipoequi',
								area: 'TPEQ1',
								field: 'TIPOEQUI',
								label: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
								dataLength: 50,
								scrollData: 50,
								pkColumn: 'ValCodtpequ',
							}),
							new listColumnTypes.NumericColumn({
								order: 3,
								name: 'ValQuantida',
								area: 'LNHDE',
								field: 'QUANTIDA',
								label: computed(() => this.Resources.AMOUNT46885),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}),
						],
						config: {
							name: 'ValDesagreg',
							serverMode: true,
							pkColumn: 'ValCodlnhde',
							tableAlias: 'LNHDE',
							tableNamePlural: computed(() => this.Resources.DISAGGREGATION_LINES31100),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.BREAKDOWN_60448),
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
										formName: 'LNHDE',
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
										formName: 'LNHDE',
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
										formName: 'LNHDE',
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
										formName: 'LNHDE',
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
										formName: 'LNHDE',
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
								id: 'RCA__LNHDE',
								name: '_LNHDE',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'LNHDE',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'LNHDE': {
									fnKeySelector: (row) => row.Fields.ValCodlnhde,
									isPopup: false
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'ValOrdem',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-LNHDE', 'changed-TPEQ1', 'changed-LNHPD', 'changed-PEDID', 'changed-LNHAG'],
						uuid: 'Pedid_ValDesagreg',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'pedid'],
								dependencyEvents: ['fieldChange:pedid.codpedid'],
								dependencyField: 'PEDID.CODPEDID',
								fnValueSelector: (model) => model.ValCodpedid.value
							},
						],
					}, this),
					PEDID___PSEUDAGRUPAME: new fieldControlClass.TableListControl({
						id: 'PEDID___PSEUDAGRUPAME',
						name: 'AGRUPAME',
						size: '',
						label: computed(() => this.Resources.GROUPING_OF_EQUIPMEN34190),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'PEDID',
						action: 'Pedid_ValAgrupame',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Tpeq1.ValTipoequi',
								area: 'TPEQ1',
								field: 'TIPOEQUI',
								label: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
								dataLength: 50,
								scrollData: 50,
								pkColumn: 'ValCodtpequ',
							}),
							new listColumnTypes.NumericColumn({
								order: 2,
								name: 'ValQtdtpequ',
								area: 'LNHAG',
								field: 'QTDTPEQU',
								label: computed(() => this.Resources.AMOUNT46885),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}),
						],
						config: {
							name: 'ValAgrupame',
							serverMode: true,
							pkColumn: 'ValCodlnhag',
							tableAlias: 'LNHAG',
							tableNamePlural: computed(() => this.Resources.EQUIPMENT_GROUPINGS20350),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.GROUPING_OF_EQUIPMEN34190),
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
										formName: 'LNHAG',
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
										formName: 'LNHAG',
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
										formName: 'LNHAG',
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
										formName: 'LNHAG',
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
										formName: 'LNHAG',
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
								id: 'RCA__LNHAG',
								name: '_LNHAG',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'LNHAG',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'LNHAG': {
									fnKeySelector: (row) => row.Fields.ValCodlnhag,
									isPopup: false
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'Tpeq1.ValTipoequi',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-PEDID', 'changed-TPEQ1', 'changed-LNHAG'],
						uuid: 'Pedid_ValAgrupame',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'pedid'],
								dependencyEvents: ['fieldChange:pedid.codpedid'],
								dependencyField: 'PEDID.CODPEDID',
								fnValueSelector: (model) => model.ValCodpedid.value
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
					'PEDID___PSEUDLINHAS__',
					'PEDID___PSEUDDESAGREG',
					'PEDID___PSEUDAGRUPAME',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Pedid: {
						get ValDtpedido() { return vm.model.ValDtpedido.value },
						set ValDtpedido(value) { vm.model.ValDtpedido.updateValue(value) },
						get ValMotivo() { return vm.model.ValMotivo.value },
						set ValMotivo(value) { vm.model.ValMotivo.updateValue(value) },
						get ValNrpedido() { return vm.model.ValNrpedido.value },
						set ValNrpedido(value) { vm.model.ValNrpedido.updateValue(value) },
					},
					keys: {
						/** The primary key of the PEDID table */
						get pedid() { return vm.model.ValCodpedid },
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
// USE /[MANUAL GQT FORM_CODEJS PEDID]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS PEDID]/
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
// USE /[MANUAL GQT FORM_LOADED_JS PEDID]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS PEDID]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS PEDID]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS PEDID]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS PEDID]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS PEDID]/
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
// USE /[MANUAL GQT AFTER_DEL_JS PEDID]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS PEDID]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS PEDID]/
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
// USE /[MANUAL GQT DLGUPDT PEDID]/
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
// USE /[MANUAL GQT CTRLBLR PEDID]/
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
// USE /[MANUAL GQT CTRLUPD PEDID]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS PEDID]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
