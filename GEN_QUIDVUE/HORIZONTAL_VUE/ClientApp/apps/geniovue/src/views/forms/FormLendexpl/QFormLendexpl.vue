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
			data-key="LENDEXPL"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container
					v-show="controls.LENDEXPLPSEUDNEWGRP01.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.LENDEXPLPSEUDNEWGRP01.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<q-group-collapsible
							id="LENDEXPLPSEUDNEWGRP01"
							v-bind="controls.LENDEXPLPSEUDNEWGRP01"
							v-on="controls.LENDEXPLPSEUDNEWGRP01.handlers">
							<!-- Start LENDEXPLPSEUDNEWGRP01 -->
							<q-row-container v-show="controls.LENDEXPLPESS1GENDER___FG.isVisible">
								<q-control-wrapper
									v-show="controls.LENDEXPLPESS1GENDER___FG.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-text"
										v-bind="controls.LENDEXPLPESS1GENDER___FG"
										v-on="controls.LENDEXPLPESS1GENDER___FG.handlers"
										:loading="controls.LENDEXPLPESS1GENDER___FG.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.LENDEXPLEQUIPFREQUENC_FG.isVisible">
								<q-control-wrapper
									v-show="controls.LENDEXPLEQUIPFREQUENC_FG.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-text"
										v-bind="controls.LENDEXPLEQUIPFREQUENC_FG"
										v-on="controls.LENDEXPLEQUIPFREQUENC_FG.handlers"
										:loading="controls.LENDEXPLEQUIPFREQUENC_FG.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.LENDEXPLEQUIPBOUGHT___FG.isVisible">
								<q-control-wrapper
									v-show="controls.LENDEXPLEQUIPBOUGHT___FG.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-text"
										v-bind="controls.LENDEXPLEQUIPBOUGHT___FG"
										v-on="controls.LENDEXPLEQUIPBOUGHT___FG.handlers"
										:loading="controls.LENDEXPLEQUIPBOUGHT___FG.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.LENDEXPLLENDIRETURNED_FG.isVisible">
								<q-control-wrapper
									v-show="controls.LENDEXPLLENDIRETURNED_FG.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-text"
										v-bind="controls.LENDEXPLLENDIRETURNED_FG"
										v-on="controls.LENDEXPLLENDIRETURNED_FG.handlers"
										:loading="controls.LENDEXPLLENDIRETURNED_FG.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End LENDEXPLPSEUDNEWGRP01 -->
						</q-group-collapsible>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.LENDEXPLPSEUDLENDERS_.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.LENDEXPLPSEUDLENDERS_.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<q-table
							v-show="controls.LENDEXPLPSEUDLENDERS_.isVisible"
							v-bind="controls.LENDEXPLPSEUDLENDERS_"
							v-on="controls.LENDEXPLPSEUDLENDERS_.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.LENDEXPLPSEUDLENDERS_"
							v-on="controls.LENDEXPLPSEUDLENDERS_.handlers" />
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.LENDEXPLPSEUDEQUIPS__.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.LENDEXPLPSEUDEQUIPS__.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<q-table
							v-show="controls.LENDEXPLPSEUDEQUIPS__.isVisible"
							v-bind="controls.LENDEXPLPSEUDEQUIPS__"
							v-on="controls.LENDEXPLPSEUDEQUIPS__.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.LENDEXPLPSEUDEQUIPS__"
							v-on="controls.LENDEXPLPSEUDEQUIPS__.handlers" />
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.LENDEXPLPSEUDLENDINGS.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.LENDEXPLPSEUDLENDINGS.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<q-table
							v-show="controls.LENDEXPLPSEUDLENDINGS.isVisible"
							v-bind="controls.LENDEXPLPSEUDLENDINGS"
							v-on="controls.LENDEXPLPSEUDLENDINGS.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.LENDEXPLPSEUDLENDINGS"
							v-on="controls.LENDEXPLPSEUDLENDINGS.handlers" />
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

	import FormViewModel from './QFormLendexplViewModel.js'

	const requiredTextResources = ['QFormLendexpl', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS LENDEXPL]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormLendexpl',

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
					name: 'LENDEXPL',
					location: 'form-LENDEXPL',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormLendexpl', false),

				interfaceMetadata: {
					id: 'QFormLendexpl', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'LENDEXPL',
					route: 'form-LENDEXPL',
					area: 'Home',
					designation: computed(() => this.Resources.EXPLORE_LENDINGS62734),
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
					LENDEXPLPSEUDNEWGRP01: new fieldControlClass.GroupControl({
						id: 'LENDEXPLPSEUDNEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: computed(() => this.Resources.FILTERING18019),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: true,
						anchored: false,
						directChildren: ['LENDEXPLPESS1GENDER___FG', 'LENDEXPLEQUIPFREQUENC_FG', 'LENDEXPLEQUIPBOUGHT___FG', 'LENDEXPLLENDIRETURNED_FG'],
						controlLimits: [
						],
					}, this),
					LENDEXPLPESS1GENDER___FG: new fieldControlClass.Control({
						modelField: 'Pess1ValGender',
						valueChangeEvent: 'fieldChange:pess1.gender',
						id: 'LENDEXPLPESS1GENDER___FG',
						name: 'GENDER',
						size: 'medium',
						label: computed(() => this.Resources.LENDER__GENDER58296),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'LENDEXPLPSEUDNEWGRP01',
						arrayName: 'Genero',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					LENDEXPLEQUIPFREQUENC_FG: new fieldControlClass.Control({
						modelField: 'EquipValFrequenc',
						valueChangeEvent: 'fieldChange:equip.frequenc',
						id: 'LENDEXPLEQUIPFREQUENC_FG',
						name: 'FREQUENC',
						size: 'large',
						helpControl: {
							shortHelp: {
								type: '',
								text: '',
							},
						},
						label: computed(() => this.Resources.EQUIPMENT__LOAN_FREQ19079),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'LENDEXPLPSEUDNEWGRP01',
						arrayName: 'FreqEmpr',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					LENDEXPLEQUIPBOUGHT___FG: new fieldControlClass.Control({
						modelField: 'EquipValBought',
						valueChangeEvent: 'fieldChange:equip.bought',
						id: 'LENDEXPLEQUIPBOUGHT___FG',
						name: 'BOUGHT',
						size: 'medium',
						label: computed(() => this.Resources.EQUIPMENT__BOUGHT19410),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'LENDEXPLPSEUDNEWGRP01',
						isFormulaBlocked: true,
						controlLimits: [
						],
					}, this),
					LENDEXPLLENDIRETURNED_FG: new fieldControlClass.Control({
						modelField: 'LendiValReturned',
						valueChangeEvent: 'fieldChange:lendi.returned',
						id: 'LENDEXPLLENDIRETURNED_FG',
						name: 'RETURNED',
						size: 'medium',
						label: computed(() => this.Resources.LENDING__RETURNED20063),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'LENDEXPLPSEUDNEWGRP01',
						isFormulaBlocked: true,
						controlLimits: [
						],
					}, this),
					LENDEXPLPSEUDLENDERS_: new fieldControlClass.TableListControl({
						id: 'LENDEXPLPSEUDLENDERS_',
						name: 'LENDERS',
						size: 'block',
						label: computed(() => this.Resources.LENDERS26611),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'Home',
						action: 'Lendexpl_ValLenders',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.ImageColumn({
								order: 1,
								name: 'ValPhotogra',
								area: 'PESS1',
								field: 'PHOTOGRA',
								label: computed(() => this.Resources.PHOTO51874),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.PHOTO51874)),
								scrollData: 3,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValName',
								area: 'PESS1',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 3,
								name: 'ValGender',
								area: 'PESS1',
								field: 'GENDER',
								label: computed(() => this.Resources.GENRE63303),
								dataLength: 1,
								scrollData: 1,
								array: computed(() => qProjArrays.QArrayGenero.setResources(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayGenero.type,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValLenders',
							serverMode: true,
							pkColumn: 'ValCodpesso',
							tableAlias: 'PESS1',
							tableNamePlural: computed(() => this.Resources.COMFORTERS51045),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.LENDERS26611),
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
							defaultSearchColumnName: 'ValName',
							defaultSearchColumnNameOriginal: 'ValName',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-PESS1', 'changed-CATE2', 'changed-STAKE', 'changed-CMPNY'],
						internalEvents: ['fieldChange:pess1.gender'],
						uuid: 'Lendexpl_ValLenders',
						allSelectedRows: 'false',
						controlLimits: [
						],
					}, this),
					LENDEXPLPSEUDEQUIPS__: new fieldControlClass.TableListControl({
						id: 'LENDEXPLPSEUDEQUIPS__',
						name: 'EQUIPS',
						size: 'block',
						label: computed(() => this.Resources.EQUIPMENT03632),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'Home',
						action: 'Lendexpl_ValEquips',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValDesignat',
								area: 'EQUIP',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.DESIGNATION35876),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 2,
								name: 'ValFrequenc',
								area: 'EQUIP',
								field: 'FREQUENC',
								label: computed(() => this.Resources.LOAN_FREQUENCY00701),
								scrollData: 2,
								maxDigits: 2,
								decimalPlaces: 0,
								array: computed(() => qProjArrays.QArrayFreqempr.setResources(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayFreqempr.type,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 3,
								name: 'ValBought',
								area: 'EQUIP',
								field: 'BOUGHT',
								label: computed(() => this.Resources.BOUGHT32044),
								scrollData: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 4,
								name: 'Pess1.ValGender',
								area: 'PESS1',
								field: 'GENDER',
								label: computed(() => this.Resources.LENDER__GENDER58296),
								dataLength: 1,
								scrollData: 1,
								array: computed(() => qProjArrays.QArrayGenero.setResources(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayGenero.type,
								arrayDisplayMode: 'D',
								pkColumn: 'ValCodpesso',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValEquips',
							serverMode: true,
							pkColumn: 'ValCodequip',
							tableAlias: 'EQUIP',
							tableNamePlural: computed(() => this.Resources.EQUIPMENT03632),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.EQUIPMENT03632),
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
						globalEvents: ['changed-TPEQU', 'changed-ROOM1', 'changed-CMPNY', 'changed-EQUIP', 'changed-WAREH', 'changed-ITEM', 'changed-DECOM', 'changed-PESS1'],
						internalEvents: ['fieldChange:pess1.gender', 'fieldChange:equip.frequenc', 'fieldChange:equip.bought'],
						uuid: 'Lendexpl_ValEquips',
						allSelectedRows: 'false',
						controlLimits: [
						],
					}, this),
					LENDEXPLPSEUDLENDINGS: new fieldControlClass.TableListControl({
						id: 'LENDEXPLPSEUDLENDINGS',
						name: 'LENDINGS',
						size: 'block',
						label: computed(() => this.Resources.LENDINGS30501),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'Home',
						action: 'Lendexpl_ValLendings',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.NumericColumn({
								order: 1,
								name: 'ValLendinnr',
								area: 'LENDI',
								field: 'LENDINNR',
								label: computed(() => this.Resources.NUMBER_OF_LENDING63925),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 2,
								name: 'ValReturned',
								area: 'LENDI',
								field: 'RETURNED',
								label: computed(() => this.Resources.RETURNED01606),
								scrollData: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 3,
								name: 'Equip.ValFrequenc',
								area: 'EQUIP',
								field: 'FREQUENC',
								label: computed(() => this.Resources.EQUIP__LOAN_FREQUENC34059),
								scrollData: 2,
								maxDigits: 2,
								decimalPlaces: 0,
								array: computed(() => qProjArrays.QArrayFreqempr.setResources(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayFreqempr.type,
								arrayDisplayMode: 'D',
								pkColumn: 'ValCodequip',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 4,
								name: 'Equip.ValBought',
								area: 'EQUIP',
								field: 'BOUGHT',
								label: computed(() => this.Resources.EQUIP__BOUGHT47638),
								scrollData: 1,
								pkColumn: 'ValCodequip',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 5,
								name: 'Pess1.ValGender',
								area: 'PESS1',
								field: 'GENDER',
								label: computed(() => this.Resources.LENDER__GENDER58296),
								dataLength: 1,
								scrollData: 1,
								array: computed(() => qProjArrays.QArrayGenero.setResources(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayGenero.type,
								arrayDisplayMode: 'D',
								pkColumn: 'ValCodpesso',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValLendings',
							serverMode: true,
							pkColumn: 'ValCodlendi',
							tableAlias: 'LENDI',
							tableNamePlural: computed(() => this.Resources.LENDING18782),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.LENDINGS30501),
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
							defaultSearchColumnName: 'ValLendinnr',
							defaultSearchColumnNameOriginal: 'ValLendinnr',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-LENDI', 'changed-PESS1', 'changed-EQUIP', 'changed-PESS2'],
						internalEvents: ['fieldChange:pess1.gender', 'fieldChange:equip.frequenc', 'fieldChange:equip.bought', 'fieldChange:lendi.returned'],
						uuid: 'Lendexpl_ValLendings',
						allSelectedRows: 'false',
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
					'LENDEXPLPSEUDNEWGRP01',
				]),

				tableFields: readonly([
					'LENDEXPLPSEUDLENDERS_',
					'LENDEXPLPSEUDEQUIPS__',
					'LENDEXPLPSEUDLENDINGS',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Equip: {
						get ValBought() { return vm.model.EquipValBought.value },
						set ValBought(value) { vm.model.EquipValBought.updateValue(value) },
						get ValFrequenc() { return vm.model.EquipValFrequenc.value },
						set ValFrequenc(value) { vm.model.EquipValFrequenc.updateValue(value) },
					},
					Lendi: {
						get ValReturned() { return vm.model.LendiValReturned.value },
						set ValReturned(value) { vm.model.LendiValReturned.updateValue(value) },
					},
					Pess1: {
						get ValGender() { return vm.model.Pess1ValGender.value },
						set ValGender(value) { vm.model.Pess1ValGender.updateValue(value) },
					},
					keys: {
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
// USE /[MANUAL GQT FORM_CODEJS LENDEXPL]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS LENDEXPL]/
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
// USE /[MANUAL GQT FORM_LOADED_JS LENDEXPL]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS LENDEXPL]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS LENDEXPL]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS LENDEXPL]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS LENDEXPL]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS LENDEXPL]/
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
// USE /[MANUAL GQT AFTER_DEL_JS LENDEXPL]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS LENDEXPL]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS LENDEXPL]/
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
// USE /[MANUAL GQT DLGUPDT LENDEXPL]/
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
// USE /[MANUAL GQT CTRLBLR LENDEXPL]/
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
// USE /[MANUAL GQT CTRLUPD LENDEXPL]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS LENDEXPL]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
