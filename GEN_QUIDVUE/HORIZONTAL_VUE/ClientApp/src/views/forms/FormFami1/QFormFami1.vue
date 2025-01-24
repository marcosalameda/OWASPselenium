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
			data-key="FAMI1"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.FAMI1___FAMI1FAMILY__.isVisible">
					<q-control-wrapper
						v-show="controls.FAMI1___FAMI1FAMILY__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.FAMI1___FAMI1FAMILY__"
							v-on="controls.FAMI1___FAMI1FAMILY__.handlers"
							:loading="controls.FAMI1___FAMI1FAMILY__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.FAMI1___FAMI1FAMILY__.props"
								:model-value="model.ValFamily.value"
								@blur="onBlur(controls.FAMI1___FAMI1FAMILY__, model.ValFamily.value)"
								@change="model.ValFamily.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.FAMI1___PSEUDTIPOSEQU.isVisible">
					<q-control-wrapper
						v-show="controls.FAMI1___PSEUDTIPOSEQU.isVisible"
						class="control-join-group">
						<q-table
							v-show="controls.FAMI1___PSEUDTIPOSEQU.isVisible"
							v-bind="controls.FAMI1___PSEUDTIPOSEQU"
							v-on="controls.FAMI1___PSEUDTIPOSEQU.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.FAMI1___PSEUDTIPOSEQU"
							v-on="controls.FAMI1___PSEUDTIPOSEQU.handlers" />
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.FAMI1___PSEUDTIPOSEQ1.isVisible">
					<q-control-wrapper
						v-show="controls.FAMI1___PSEUDTIPOSEQ1.isVisible"
						class="control-join-group">
						<q-table
							v-show="controls.FAMI1___PSEUDTIPOSEQ1.isVisible"
							v-bind="controls.FAMI1___PSEUDTIPOSEQ1"
							v-on="controls.FAMI1___PSEUDTIPOSEQ1.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.FAMI1___PSEUDTIPOSEQ1"
							v-on="controls.FAMI1___PSEUDTIPOSEQ1.handlers" />
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

	import FormViewModel from './QFormFami1ViewModel.js'

	const requiredTextResources = ['QFormFami1', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS FAMI1]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormFami1',

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
					name: 'FAMI1',
					location: 'form-FAMI1',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormFami1', false),

				interfaceMetadata: {
					id: 'QFormFami1', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'FAMI1',
					route: 'form-FAMI1',
					area: 'FAMI1',
					primaryKey: 'ValCodfamil',
					designation: computed(() => this.Resources.FAMILIA_DE_EQUIPAMEN28756),
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
					FAMI1___FAMI1FAMILY__: new fieldControlClass.StringControl({
						modelField: 'ValFamily',
						valueChangeEvent: 'fieldChange:fami1.family',
						id: 'FAMI1___FAMI1FAMILY__',
						name: 'FAMILY',
						size: 'xlarge',
						label: computed(() => this.Resources.EQUIPMENT_FAMILY41883),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_FAMI1___FAMI1FAMILY__',
						controlLimits: [
						],
					}, this),
					FAMI1___PSEUDTIPOSEQU: new fieldControlClass.TableListControl({
						id: 'FAMI1___PSEUDTIPOSEQU',
						name: 'TIPOSEQU',
						size: '',
						label: computed(() => this.Resources.TYPE_OF_EQUIPMENT64921),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'FAMI1',
						action: 'Fami1_ValTiposequ',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValTipoequi',
								area: 'TPEQ1',
								field: 'TIPOEQUI',
								label: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValTpequcod',
								area: 'TPEQ1',
								field: 'TPEQUCOD',
								label: computed(() => this.Resources.CODE49225),
								dataLength: 20,
								scrollData: 20,
							}),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValTpequpai',
								area: 'TPEQ1',
								field: 'TPEQUPAI',
								label: computed(() => this.Resources.DEPENDENT_ON28321),
								dataLength: 20,
								scrollData: 20,
							}),
							new listColumnTypes.NumericColumn({
								order: 4,
								name: 'ValNivel',
								area: 'TPEQ1',
								field: 'NIVEL',
								label: computed(() => this.Resources.LEVEL06184),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValBackcolo',
								area: 'TPEQ1',
								field: 'BACKCOLO',
								label: computed(() => this.Resources.BACKGROUND_COLOR47883),
								dataLength: 50,
								scrollData: 30,
								// eslint-disable-next-line no-unused-vars
								textColor: (row) => qApi.iif(qApi.emptyC(row.Fields.ValCorletra)===1,qApi.RGB(0,0,0),row.Fields.ValCorletra),
								// eslint-disable-next-line no-unused-vars
								bgColor: (row) => qApi.iif(qApi.emptyC(row.Fields.ValBackcolo)===1,qApi.RGB(255,255,255),row.Fields.ValBackcolo),
							}),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'ValCorletra',
								area: 'TPEQ1',
								field: 'CORLETRA',
								label: computed(() => this.Resources.LETTER_COLOR15736),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 7,
								name: 'ValPrecomax',
								area: 'TPEQ1',
								field: 'PRECOMAX',
								label: computed(() => this.Resources.MAXIMUM_PRICE55489),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 0,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 8,
								name: 'ValPrecoult',
								area: 'TPEQ1',
								field: 'PRECOULT',
								label: computed(() => this.Resources.LAST_PRICE25852),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 0,
							}),
							new listColumnTypes.DateColumn({
								order: 9,
								name: 'ValSince',
								area: 'TPEQ1',
								field: 'SINCE',
								label: computed(() => this.Resources.IN34902),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.NumericColumn({
								order: 10,
								name: 'ValQtdequip',
								area: 'TPEQ1',
								field: 'QTDEQUIP',
								label: computed(() => this.Resources.AMOUNT46885),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}),
							new listColumnTypes.BooleanColumn({
								order: 11,
								name: 'ValKit',
								area: 'TPEQ1',
								field: 'KIT',
								label: computed(() => this.Resources.KIT27179),
								scrollData: 1,
							}),
						],
						config: {
							name: 'ValTiposequ',
							serverMode: true,
							pkColumn: 'ValCodtpequ',
							tableAlias: 'TPEQ1',
							tableNamePlural: computed(() => this.Resources.TYPES_OF_EQUIPMENT61264),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.TYPE_OF_EQUIPMENT64921),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: true,
								searchOnPressEnter: true
							},
							filtersVisible: true,
							allowColumnFilters: true,
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
										formName: 'TPEQ1',
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
										formName: 'TPEQ1',
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
										formName: 'TPEQ1',
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
										formName: 'TPEQ1',
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
										formName: 'TPEQ1',
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
								id: 'RCA__TPEQ1',
								name: '_TPEQ1',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'TPEQ1',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'TPEQ1': {
									fnKeySelector: (row) => row.Fields.ValCodtpequ,
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
						changeEvents: ['changed-TPEQ1', 'changed-FAMI1'],
						uuid: 'Fami1_ValTiposequ',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'fami1'],
								dependencyEvents: ['fieldChange:fami1.codfamil'],
								dependencyField: 'FAMI1.CODFAMIL',
								fnValueSelector: (model) => model.ValCodfamil.value
							},
						],
					}, this),
					FAMI1___PSEUDTIPOSEQ1: new fieldControlClass.TreeTableListControl({
						id: 'FAMI1___PSEUDTIPOSEQ1',
						name: 'TIPOSEQ1',
						size: '',
						label: computed(() => this.Resources.TYPE_OF_EQUIPMENT64921),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'FAMI1',
						action: 'Fami1_ValTiposeq1',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValTpequcod',
								area: 'TPEQ1',
								field: 'TPEQUCOD',
								label: computed(() => this.Resources.CODE49225),
								dataLength: 20,
								scrollData: 20,
								supportForm: 'TPEQ1',
								supportFormIsPopup: false,
								params: {
									type: 'form',
									isRoute: true,
									formName: 'TPEQ1',
									mode: 'SHOW'
								},
								cellAction: true,
								// eslint-disable-next-line no-unused-vars
								textColor: (row) => qApi.iif(qApi.emptyC(row.Fields.ValCorletra)===1,qApi.RGB(0,0,0),row.Fields.ValCorletra),
								// eslint-disable-next-line no-unused-vars
								bgColor: (row) => qApi.iif(qApi.emptyC(row.Fields.ValBackcolo)===1,qApi.RGB(255,255,255),row.Fields.ValBackcolo),
							}),
							new listColumnTypes.NumericColumn({
								order: 2,
								name: 'ValNivel',
								area: 'TPEQ1',
								field: 'NIVEL',
								label: computed(() => this.Resources.LEVEL06184),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValTipoequi',
								area: 'TPEQ1',
								field: 'TIPOEQUI',
								label: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'ValTpequpai',
								area: 'TPEQ1',
								field: 'TPEQUPAI',
								label: computed(() => this.Resources.DEPENDENT_ON28321),
								dataLength: 20,
								scrollData: 20,
							}),
						],
						config: {
							name: 'ValTiposeq1',
							serverMode: true,
							pkColumn: 'ValCodtpequ',
							tableAlias: 'TPEQ1',
							tableNamePlural: computed(() => this.Resources.TYPES_OF_EQUIPMENT61264),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.TYPE_OF_EQUIPMENT64921),
							showAlternatePagination: true,
							permissions: {
								canDuplicate: false,
								canDelete: false,
							},
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
										formName: '',
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
										formName: '',
										mode: 'EDIT',
										isControlled: true
									}
								},
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
										formName: 'TPEQ1',
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
							},
							formsDefinition: {
								'TPEQ1': {
									level: 0,
									fnKeySelector: (row) => row.rowKey,
									isPopup: false
								},
							},
							treeListDefinitions: {
								branchAreas: {
									TPEQ1: {
										tpeq1: (row) => row.rowKey,
									},
								},
								rowModel: (row) => {
									return genericFunctions.getModelStructureObj(row, {
										'ValCodtpequ': (rowFields) => rowFields['tpeq1.codtpequ'],
										'ValTpequcod': (rowFields) => rowFields['tpeq1.tpequcod'],
										'ValNivel': (rowFields) => rowFields['tpeq1.nivel'],
										'ValTipoequi': (rowFields) => rowFields['tpeq1.tipoequi'],
										'ValTpequpai': (rowFields) => rowFields['tpeq1.tpequpai'],
										'ValBackcolo': (rowFields) => rowFields['tpeq1.backcolo'],
										'ValCorletra': (rowFields) => rowFields['tpeq1.corletra'],
									})
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-TPEQ1', 'changed-FAMI1'],
						uuid: 'Fami1_ValTiposeq1',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'fami1'],
								dependencyEvents: ['fieldChange:fami1.codfamil'],
								dependencyField: 'FAMI1.CODFAMIL',
								fnValueSelector: (model) => model.ValCodfamil.value
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
					'FAMI1___PSEUDTIPOSEQU',
					'FAMI1___PSEUDTIPOSEQ1',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Fami1: {
						get ValFamily() { return vm.model.ValFamily.value },
						set ValFamily(value) { vm.model.ValFamily.updateValue(value) },
					},
					keys: {
						/** The primary key of the FAMI1 table */
						get fami1() { return vm.model.ValCodfamil },
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
// USE /[MANUAL GQT FORM_CODEJS FAMI1]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS FAMI1]/
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
// USE /[MANUAL GQT FORM_LOADED_JS FAMI1]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS FAMI1]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS FAMI1]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS FAMI1]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS FAMI1]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS FAMI1]/
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
// USE /[MANUAL GQT AFTER_DEL_JS FAMI1]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS FAMI1]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS FAMI1]/
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
// USE /[MANUAL GQT DLGUPDT FAMI1]/
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
// USE /[MANUAL GQT CTRLBLR FAMI1]/
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
// USE /[MANUAL GQT CTRLUPD FAMI1]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS FAMI1]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
			'controls.FAMI1___PSEUDTIPOSEQ1.rows'(newVal)
			{
				this.onControlUpdate('pseud.tiposeq1.rows', this.controls.FAMI1___PSEUDTIPOSEQ1, newVal)
			},
		}
	}
</script>
