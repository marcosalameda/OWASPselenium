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
			data-key="REGIAPRO"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.REGIAPROCNTRYCOUNTRY_.isVisible || controls.REGIAPROREGIOREGIAO__.isVisible || controls.REGIAPROPAIS1COUNTRY_.isVisible || controls.REGIAPROPSEUDIMOVEISS.isVisible || controls.REGIAPROPSEUDIMOVEISL.isVisible || controls.REGIAPROPSEUDIMOVEISG.isVisible">
					<q-control-wrapper
						v-show="controls.REGIAPROCNTRYCOUNTRY_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.REGIAPROCNTRYCOUNTRY_"
							v-on="controls.REGIAPROCNTRYCOUNTRY_.handlers"
							:loading="controls.REGIAPROCNTRYCOUNTRY_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.REGIAPROCNTRYCOUNTRY_.isVisible"
								v-bind="controls.REGIAPROCNTRYCOUNTRY_.props"
								v-on="controls.REGIAPROCNTRYCOUNTRY_.handlers" />
							<q-see-more-regiaprocntrycountry
								v-if="controls.REGIAPROCNTRYCOUNTRY_.seeMoreIsVisible"
								v-bind="controls.REGIAPROCNTRYCOUNTRY_.seeMoreParams"
								v-on="controls.REGIAPROCNTRYCOUNTRY_.handlers" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.REGIAPROREGIOREGIAO__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.REGIAPROREGIOREGIAO__"
							v-on="controls.REGIAPROREGIOREGIAO__.handlers"
							:loading="controls.REGIAPROREGIOREGIAO__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.REGIAPROREGIOREGIAO__.props"
								@blur="onBlur(controls.REGIAPROREGIOREGIAO__, model.ValRegiao.value)"
								@change="model.ValRegiao.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.REGIAPROPAIS1COUNTRY_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.REGIAPROPAIS1COUNTRY_"
							v-on="controls.REGIAPROPAIS1COUNTRY_.handlers"
							:loading="controls.REGIAPROPAIS1COUNTRY_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.REGIAPROPAIS1COUNTRY_.isVisible"
								v-bind="controls.REGIAPROPAIS1COUNTRY_.props"
								v-on="controls.REGIAPROPAIS1COUNTRY_.handlers" />
							<q-see-more-regiapropais1country
								v-if="controls.REGIAPROPAIS1COUNTRY_.seeMoreIsVisible"
								v-bind="controls.REGIAPROPAIS1COUNTRY_.seeMoreParams"
								v-on="controls.REGIAPROPAIS1COUNTRY_.handlers" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.REGIAPROPSEUDIMOVEISS.isVisible"
						class="control-join-group">
						<q-table
							v-show="controls.REGIAPROPSEUDIMOVEISS.isVisible"
							v-bind="controls.REGIAPROPSEUDIMOVEISS"
							v-on="controls.REGIAPROPSEUDIMOVEISS.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.REGIAPROPSEUDIMOVEISS"
							v-on="controls.REGIAPROPSEUDIMOVEISS.handlers" />
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.REGIAPROPSEUDIMOVEISL.isVisible"
						class="control-join-group">
						<q-table
							v-show="controls.REGIAPROPSEUDIMOVEISL.isVisible"
							v-bind="controls.REGIAPROPSEUDIMOVEISL"
							v-on="controls.REGIAPROPSEUDIMOVEISL.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.REGIAPROPSEUDIMOVEISL"
							v-on="controls.REGIAPROPSEUDIMOVEISL.handlers" />
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.REGIAPROPSEUDIMOVEISG.isVisible"
						class="control-join-group">
						<q-table
							v-show="controls.REGIAPROPSEUDIMOVEISG.isVisible"
							v-bind="controls.REGIAPROPSEUDIMOVEISG"
							v-on="controls.REGIAPROPSEUDIMOVEISG.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.REGIAPROPSEUDIMOVEISG"
							v-on="controls.REGIAPROPSEUDIMOVEISG.handlers" />
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

	import FormViewModel from './QFormRegiaproViewModel.js'

	const requiredTextResources = ['QFormRegiapro', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS REGIAPRO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormRegiapro',

		components: {
			QSeeMoreRegiaprocntrycountry: defineAsyncComponent(() => import('@/views/forms/FormRegiapro/dbedits/RegiaprocntrycountrySeeMore.vue')),
			QSeeMoreRegiapropais1country: defineAsyncComponent(() => import('@/views/forms/FormRegiapro/dbedits/Regiapropais1countrySeeMore.vue')),
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
					name: 'REGIAPRO',
					location: 'form-REGIAPRO',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormRegiapro', false),

				interfaceMetadata: {
					id: 'QFormRegiapro', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'REGIAPRO',
					route: 'form-REGIAPRO',
					area: 'REGIO',
					primaryKey: 'ValCodregia',
					designation: computed(() => this.Resources.IMOVEIS_NA_REGIAO56821),
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
						text: computed(() => vm.Resources.INSERT30329),
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
					REGIAPROCNTRYCOUNTRY_: new fieldControlClass.LookupControl({
						modelField: 'TableCntryCountry',
						valueChangeEvent: 'fieldChange:cntry.country',
						id: 'REGIAPROCNTRYCOUNTRY_',
						name: 'COUNTRY',
						size: 'xlarge',
						label: computed(() => this.Resources.COUNTRY64133),
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
							name: 'ValCodcntry',
							dependencyEvent: 'fieldChange:regio.codcntry'
						},
						dependentFields: () => ({
							set 'cntry.codcntry'(value) { vm.model.ValCodcntry.updateValue(value) },
							set 'cntry.country'(value) { vm.model.TableCntryCountry.updateValue(value) },
						}),
						insertEnabled: true,
						supportForm: 'PAIS',
						controlLimits: [
						],
					}, this),
					REGIAPROREGIOREGIAO__: new fieldControlClass.StringControl({
						modelField: 'ValRegiao',
						valueChangeEvent: 'fieldChange:regio.regiao',
						id: 'REGIAPROREGIOREGIAO__',
						name: 'REGIAO',
						size: 'xlarge',
						label: computed(() => this.Resources.REGION12723),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_REGIAPROREGIOREGIAO__',
						controlLimits: [
						],
					}, this),
					REGIAPROPAIS1COUNTRY_: new fieldControlClass.LookupControl({
						modelField: 'TablePais1Country',
						valueChangeEvent: 'fieldChange:pais1.country',
						id: 'REGIAPROPAIS1COUNTRY_',
						name: 'COUNTRY',
						size: 'xxlarge',
						label: computed(() => this.Resources.COUNTRY64133),
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
							name: 'ValCodpais1',
							dependencyEvent: 'fieldChange:regio.codpais1'
						},
						dependentFields: () => ({
							set 'pais1.codcntry'(value) { vm.model.ValCodpais1.updateValue(value) },
							set 'pais1.country'(value) { vm.model.TablePais1Country.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					REGIAPROPSEUDIMOVEISS: new fieldControlClass.TableListControl({
						id: 'REGIAPROPSEUDIMOVEISS',
						name: 'IMOVEISS',
						size: '',
						label: computed(() => this.Resources.NON_LIMITED_PROPERTI11098),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'REGIO',
						action: 'Regiapro_ValImoveiss',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValName',
								area: 'PROPR',
								field: 'NAME',
								label: computed(() => this.Resources.PROPERTY_NAME18934),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 2,
								name: 'ValPrecoest',
								area: 'PROPR',
								field: 'PRECOEST',
								label: computed(() => this.Resources.ESTIMATED_PRICE02986),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 3,
								name: 'ValPhotogra',
								area: 'PROPR',
								field: 'PHOTOGRA',
								label: computed(() => this.Resources.PHOTO51874),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.PHOTO51874)),
								scrollData: 3,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValDescript',
								area: 'PROPR',
								field: 'DESCRIPT',
								label: computed(() => this.Resources.DESCRIPTION07383),
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.GeographicColumn({
								order: 5,
								name: 'ValCoordgeo',
								area: 'PROPR',
								field: 'COORDGEO',
								label: computed(() => this.Resources.GEOGRAPHIC_COORDINAT21394),
								dataLength: 50,
								scrollData: 30,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'Pais1.ValCountry',
								area: 'PAIS1',
								field: 'COUNTRY',
								label: computed(() => this.Resources.PAIS_PESSOA61621),
								dataLength: 90,
								scrollData: 30,
								pkColumn: 'ValCodcntry',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'Cntry.ValCountry',
								area: 'CNTRY',
								field: 'COUNTRY',
								label: computed(() => this.Resources.COUNTRY64133),
								dataLength: 90,
								scrollData: 30,
								pkColumn: 'ValCodcntry',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValImoveiss',
							serverMode: true,
							pkColumn: 'ValCodpropr',
							tableAlias: 'PROPR',
							tableNamePlural: computed(() => this.Resources.PROPERTIES34868),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.NON_LIMITED_PROPERTI11098),
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
						globalEvents: ['changed-CNTRY', 'changed-REGIO', 'changed-PESSO', 'changed-PROPR', 'changed-TPPRO', 'changed-PAIS1'],
						uuid: 'Regiapro_ValImoveiss',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'regio'],
								dependencyEvents: ['fieldChange:regio.codregia'],
								dependencyField: 'REGIO.CODREGIA',
								fnValueSelector: (model) => model.ValCodregia.value
							},
							{
								identifier: ['pais1', 'regio.codpais1'],
								dependencyEvents: ['fieldChange:regio.codpais1'],
								dependencyField: 'REGIO.CODPAIS1',
								fnValueSelector: (model) => model.ValCodpais1.value
							},
						],
					}, this),
					REGIAPROPSEUDIMOVEISL: new fieldControlClass.TableListControl({
						id: 'REGIAPROPSEUDIMOVEISL',
						name: 'IMOVEISL',
						size: '',
						label: computed(() => this.Resources.PROPERTIES34868),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'REGIO',
						action: 'Regiapro_ValImoveisl',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValName',
								area: 'PROPR',
								field: 'NAME',
								label: computed(() => this.Resources.PROPERTY_NAME18934),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 2,
								name: 'ValPrecoest',
								area: 'PROPR',
								field: 'PRECOEST',
								label: computed(() => this.Resources.ESTIMATED_PRICE02986),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 3,
								name: 'ValPhotogra',
								area: 'PROPR',
								field: 'PHOTOGRA',
								label: computed(() => this.Resources.PHOTO51874),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.PHOTO51874)),
								scrollData: 3,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValDescript',
								area: 'PROPR',
								field: 'DESCRIPT',
								label: computed(() => this.Resources.DESCRIPTION07383),
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.GeographicColumn({
								order: 5,
								name: 'ValCoordgeo',
								area: 'PROPR',
								field: 'COORDGEO',
								label: computed(() => this.Resources.GEOGRAPHIC_COORDINAT21394),
								dataLength: 50,
								scrollData: 30,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'Pais1.ValCountry',
								area: 'PAIS1',
								field: 'COUNTRY',
								label: computed(() => this.Resources.PAIS_PESSOA61621),
								dataLength: 90,
								scrollData: 30,
								pkColumn: 'ValCodcntry',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'Cntry.ValCountry',
								area: 'CNTRY',
								field: 'COUNTRY',
								label: computed(() => this.Resources.COUNTRY64133),
								dataLength: 90,
								scrollData: 30,
								pkColumn: 'ValCodcntry',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValImoveisl',
							serverMode: true,
							pkColumn: 'ValCodpropr',
							tableAlias: 'PROPR',
							tableNamePlural: computed(() => this.Resources.PROPERTIES34868),
							viewManagement: 'N',
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
						globalEvents: ['changed-CNTRY', 'changed-REGIO', 'changed-PESSO', 'changed-PROPR', 'changed-TPPRO', 'changed-PAIS1'],
						uuid: 'Regiapro_ValImoveisl',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'regio'],
								dependencyEvents: ['fieldChange:regio.codregia'],
								dependencyField: 'REGIO.CODREGIA',
								fnValueSelector: (model) => model.ValCodregia.value
							},
						],
					}, this),
					REGIAPROPSEUDIMOVEISG: new fieldControlClass.TableListControl({
						id: 'REGIAPROPSEUDIMOVEISG',
						name: 'IMOVEISG',
						size: '',
						label: computed(() => this.Resources.PROPERTIES34868),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'REGIO',
						action: 'Regiapro_ValImoveisg',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValName',
								area: 'PROPR',
								field: 'NAME',
								label: computed(() => this.Resources.PROPERTY_NAME18934),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 2,
								name: 'ValPrecoest',
								area: 'PROPR',
								field: 'PRECOEST',
								label: computed(() => this.Resources.ESTIMATED_PRICE02986),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 3,
								name: 'ValPhotogra',
								area: 'PROPR',
								field: 'PHOTOGRA',
								label: computed(() => this.Resources.PHOTO51874),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.PHOTO51874)),
								scrollData: 3,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValDescript',
								area: 'PROPR',
								field: 'DESCRIPT',
								label: computed(() => this.Resources.DESCRIPTION07383),
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.GeographicColumn({
								order: 5,
								name: 'ValCoordgeo',
								area: 'PROPR',
								field: 'COORDGEO',
								label: computed(() => this.Resources.GEOGRAPHIC_COORDINAT21394),
								dataLength: 50,
								scrollData: 30,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValImoveisg',
							serverMode: true,
							pkColumn: 'ValCodpropr',
							tableAlias: 'PROPR',
							tableNamePlural: computed(() => this.Resources.PROPERTIES34868),
							viewManagement: 'N',
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
						globalEvents: ['changed-CNTRY', 'changed-REGIO', 'changed-PESSO', 'changed-PROPR', 'changed-TPPRO', 'changed-PAIS1'],
						uuid: 'Regiapro_ValImoveisg',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'regio'],
								dependencyEvents: ['fieldChange:regio.codregia'],
								dependencyField: 'REGIO.CODREGIA',
								fnValueSelector: (model) => model.ValCodregia.value
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
					'REGIAPROPSEUDIMOVEISS',
					'REGIAPROPSEUDIMOVEISL',
					'REGIAPROPSEUDIMOVEISG',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Cntry: {
						get ValCountry() { return vm.model.TableCntryCountry.value },
						set ValCountry(value) { vm.model.TableCntryCountry.updateValue(value) },
					},
					Pais1: {
						get ValCountry() { return vm.model.TablePais1Country.value },
						set ValCountry(value) { vm.model.TablePais1Country.updateValue(value) },
					},
					Regio: {
						get ValCodcntry() { return vm.model.ValCodcntry.value },
						set ValCodcntry(value) { vm.model.ValCodcntry.updateValue(value) },
						get ValCodpais1() { return vm.model.ValCodpais1.value },
						set ValCodpais1(value) { vm.model.ValCodpais1.updateValue(value) },
						get ValRegiao() { return vm.model.ValRegiao.value },
						set ValRegiao(value) { vm.model.ValRegiao.updateValue(value) },
					},
					keys: {
						/** The primary key of the REGIO table */
						get regio() { return vm.model.ValCodregia },
						/** The foreign key to the CNTRY table */
						get cntry() { return vm.model.ValCodcntry },
						/** The foreign key to the PAIS1 table */
						get pais1() { return vm.model.ValCodpais1 },
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
// USE /[MANUAL GQT FORM_CODEJS REGIAPRO]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS REGIAPRO]/
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
// USE /[MANUAL GQT FORM_LOADED_JS REGIAPRO]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS REGIAPRO]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS REGIAPRO]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS REGIAPRO]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS REGIAPRO]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS REGIAPRO]/
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
// USE /[MANUAL GQT AFTER_DEL_JS REGIAPRO]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS REGIAPRO]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS REGIAPRO]/
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
// USE /[MANUAL GQT DLGUPDT REGIAPRO]/
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
// USE /[MANUAL GQT CTRLBLR REGIAPRO]/
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
// USE /[MANUAL GQT CTRLUPD REGIAPRO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS REGIAPRO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
