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
			data-key="PRODU"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container
					v-show="controls.PRODU___PSEUDNOVOGR01.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.PRODU___PSEUDNOVOGR01.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="PRODU___PSEUDNOVOGR01"
							v-bind="controls.PRODU___PSEUDNOVOGR01"
							:is-visible="controls.PRODU___PSEUDNOVOGR01.isVisible">
							<!-- Start PRODU___PSEUDNOVOGR01 -->
							<q-row-container v-show="controls.PRODU___PRODUPRODUCT_.isVisible">
								<q-control-wrapper
									v-show="controls.PRODU___PRODUPRODUCT_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PRODU___PRODUPRODUCT_"
										v-on="controls.PRODU___PRODUPRODUCT_.handlers"
										:loading="controls.PRODU___PRODUPRODUCT_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.PRODU___PRODUPRODUCT_.props"
											@blur="onBlur(controls.PRODU___PRODUPRODUCT_, model.ValProduct.value)"
											@change="model.ValProduct.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PRODU___PRODUIN_USE__.isVisible">
								<q-control-wrapper
									v-show="controls.PRODU___PRODUIN_USE__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PRODU___PRODUIN_USE__"
										v-on="controls.PRODU___PRODUIN_USE__.handlers"
										:loading="controls.PRODU___PRODUIN_USE__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-toggle-input
											v-if="controls.PRODU___PRODUIN_USE__.isVisible"
											v-bind="controls.PRODU___PRODUIN_USE__.props"
											v-on="controls.PRODU___PRODUIN_USE__.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PRODU___PRODUDESCRIPT.isVisible">
								<q-control-wrapper
									v-show="controls.PRODU___PRODUDESCRIPT.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-textarea"
										v-bind="controls.PRODU___PRODUDESCRIPT"
										v-on="controls.PRODU___PRODUDESCRIPT.handlers"
										:loading="controls.PRODU___PRODUDESCRIPT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-area
											v-if="controls.PRODU___PRODUDESCRIPT.isVisible"
											v-bind="controls.PRODU___PRODUDESCRIPT.props"
											v-on="controls.PRODU___PRODUDESCRIPT.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PRODU___PRODUSKU_____.isVisible || controls.PRODU___PRODUGTIN____.isVisible">
								<q-control-wrapper
									v-show="controls.PRODU___PRODUSKU_____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PRODU___PRODUSKU_____"
										v-on="controls.PRODU___PRODUSKU_____.handlers"
										:loading="controls.PRODU___PRODUSKU_____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.PRODU___PRODUSKU_____.props"
											@blur="onBlur(controls.PRODU___PRODUSKU_____, model.ValSku.value)"
											@change="model.ValSku.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PRODU___PRODUGTIN____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PRODU___PRODUGTIN____"
										v-on="controls.PRODU___PRODUGTIN____.handlers"
										:loading="controls.PRODU___PRODUGTIN____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.PRODU___PRODUGTIN____.props"
											@blur="onBlur(controls.PRODU___PRODUGTIN____, model.ValGtin.value)"
											@change="model.ValGtin.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PRODU___PRODUSIZE____.isVisible || controls.PRODU___PRODUWEIGHT__.isVisible">
								<q-control-wrapper
									v-show="controls.PRODU___PRODUSIZE____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PRODU___PRODUSIZE____"
										v-on="controls.PRODU___PRODUSIZE____.handlers"
										:loading="controls.PRODU___PRODUSIZE____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.PRODU___PRODUSIZE____.props"
											@blur="onBlur(controls.PRODU___PRODUSIZE____, model.ValSize.value)"
											@change="model.ValSize.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PRODU___PRODUWEIGHT__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PRODU___PRODUWEIGHT__"
										v-on="controls.PRODU___PRODUWEIGHT__.handlers"
										:loading="controls.PRODU___PRODUWEIGHT__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.PRODU___PRODUWEIGHT__.isVisible"
											v-bind="controls.PRODU___PRODUWEIGHT__.props"
											@update:model-value="model.ValWeight.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PRODU___PRODUPRICE___.isVisible || controls.PRODU___PRODUINPUTS__.isVisible || controls.PRODU___PRODUOUTPUTS_.isVisible || controls.PRODU___PRODUSTOCK___.isVisible">
								<q-control-wrapper
									v-show="controls.PRODU___PRODUPRICE___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PRODU___PRODUPRICE___"
										v-on="controls.PRODU___PRODUPRICE___.handlers"
										:loading="controls.PRODU___PRODUPRICE___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.PRODU___PRODUPRICE___.isVisible"
											v-bind="controls.PRODU___PRODUPRICE___.props"
											@update:model-value="model.ValPrice.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PRODU___PRODUINPUTS__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PRODU___PRODUINPUTS__"
										v-on="controls.PRODU___PRODUINPUTS__.handlers"
										:loading="controls.PRODU___PRODUINPUTS__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.PRODU___PRODUINPUTS__.isVisible"
											v-bind="controls.PRODU___PRODUINPUTS__.props"
											@update:model-value="model.ValInputs.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PRODU___PRODUOUTPUTS_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PRODU___PRODUOUTPUTS_"
										v-on="controls.PRODU___PRODUOUTPUTS_.handlers"
										:loading="controls.PRODU___PRODUOUTPUTS_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.PRODU___PRODUOUTPUTS_.isVisible"
											v-bind="controls.PRODU___PRODUOUTPUTS_.props"
											@update:model-value="model.ValOutputs.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PRODU___PRODUSTOCK___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PRODU___PRODUSTOCK___"
										v-on="controls.PRODU___PRODUSTOCK___.handlers"
										:loading="controls.PRODU___PRODUSTOCK___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.PRODU___PRODUSTOCK___.isVisible"
											v-bind="controls.PRODU___PRODUSTOCK___.props"
											@update:model-value="model.ValStock.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End PRODU___PSEUDNOVOGR01 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.PRODU___PSEUDNOVOGR02.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.PRODU___PSEUDNOVOGR02.isVisible"
						class="row-line-group">
						<q-group-collapsible
							id="PRODU___PSEUDNOVOGR02"
							v-bind="controls.PRODU___PSEUDNOVOGR02"
							v-on="controls.PRODU___PSEUDNOVOGR02.handlers">
							<!-- Start PRODU___PSEUDNOVOGR02 -->
							<q-row-container v-show="controls.PRODU___PRODUIMAGE___.isVisible">
								<q-control-wrapper
									v-show="controls.PRODU___PRODUIMAGE___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="q-image"
										v-bind="controls.PRODU___PRODUIMAGE___"
										v-on="controls.PRODU___PRODUIMAGE___.handlers"
										:loading="controls.PRODU___PRODUIMAGE___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-image
											v-if="controls.PRODU___PRODUIMAGE___.isVisible"
											v-bind="controls.PRODU___PRODUIMAGE___.props"
											v-on="controls.PRODU___PRODUIMAGE___.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End PRODU___PSEUDNOVOGR02 -->
						</q-group-collapsible>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.PRODU___PSEUDNOVOGR06.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.PRODU___PSEUDNOVOGR06.isVisible"
						class="row-line-group">
						<q-accordion
							v-if="controls.PRODU___PSEUDNOVOGR06.isVisible"
							id="PRODU___PSEUDNOVOGR06"
							v-bind="controls.PRODU___PSEUDNOVOGR06">
							<!-- Start PRODU___PSEUDNOVOGR06 -->
							<q-group-collapsible
								id="PRODU___PSEUDNOVOGR04"
								v-bind="controls.PRODU___PSEUDNOVOGR04"
								v-on="controls.PRODU___PSEUDNOVOGR04.handlers">
								<!-- Start PRODU___PSEUDNOVOGR04 -->
								<q-row-container
									v-show="controls.PRODU___PSEUDNOVOGR03.isVisible || controls.PRODU___PSEUDSTOCKEVO.isVisible"
									is-large>
									<q-control-wrapper
										v-show="controls.PRODU___PSEUDNOVOGR03.isVisible"
										class="row-line-group">
										<q-group-box-container
											id="PRODU___PSEUDNOVOGR03"
											v-bind="controls.PRODU___PSEUDNOVOGR03"
											:is-visible="controls.PRODU___PSEUDNOVOGR03.isVisible">
											<!-- Start PRODU___PSEUDNOVOGR03 -->
											<q-row-container v-show="controls.PRODU___LOCATGLN_____.isVisible">
												<q-control-wrapper
													v-show="controls.PRODU___LOCATGLN_____.isVisible"
													class="control-join-group">
													<base-input-structure
														class="i-text"
														v-bind="controls.PRODU___LOCATGLN_____"
														v-on="controls.PRODU___LOCATGLN_____.handlers"
														:loading="controls.PRODU___LOCATGLN_____.props.loading"
														:reporting-mode-on="reportingModeCAV"
														:suggestion-mode-on="suggestionModeOn">
														<q-lookup
															v-if="controls.PRODU___LOCATGLN_____.isVisible"
															v-bind="controls.PRODU___LOCATGLN_____.props"
															v-on="controls.PRODU___LOCATGLN_____.handlers" />
														<q-see-more-produ-locatgln
															v-if="controls.PRODU___LOCATGLN_____.seeMoreIsVisible"
															v-bind="controls.PRODU___LOCATGLN_____.seeMoreParams"
															v-on="controls.PRODU___LOCATGLN_____.handlers" />
													</base-input-structure>
												</q-control-wrapper>
											</q-row-container>
											<q-row-container v-show="controls.PRODU___LCEXTGLNEXT__.isVisible">
												<q-control-wrapper
													v-show="controls.PRODU___LCEXTGLNEXT__.isVisible"
													class="control-join-group">
													<base-input-structure
														class="i-text"
														v-bind="controls.PRODU___LCEXTGLNEXT__"
														v-on="controls.PRODU___LCEXTGLNEXT__.handlers"
														:loading="controls.PRODU___LCEXTGLNEXT__.props.loading"
														:reporting-mode-on="reportingModeCAV"
														:suggestion-mode-on="suggestionModeOn">
														<q-lookup
															v-if="controls.PRODU___LCEXTGLNEXT__.isVisible"
															v-bind="controls.PRODU___LCEXTGLNEXT__.props"
															v-on="controls.PRODU___LCEXTGLNEXT__.handlers" />
														<q-see-more-produ-lcextglnext
															v-if="controls.PRODU___LCEXTGLNEXT__.seeMoreIsVisible"
															v-bind="controls.PRODU___LCEXTGLNEXT__.seeMoreParams"
															v-on="controls.PRODU___LCEXTGLNEXT__.handlers" />
													</base-input-structure>
												</q-control-wrapper>
											</q-row-container>
											<!-- End PRODU___PSEUDNOVOGR03 -->
										</q-group-box-container>
									</q-control-wrapper>
									<q-control-wrapper
										v-show="controls.PRODU___PSEUDSTOCKEVO.isVisible"
										class="control-join-group">
										<q-table
											v-show="controls.PRODU___PSEUDSTOCKEVO.isVisible"
											v-bind="controls.PRODU___PSEUDSTOCKEVO"
											v-on="controls.PRODU___PSEUDSTOCKEVO.handlers" />
										<q-table-extra-extension
											:list-ctrl="controls.PRODU___PSEUDSTOCKEVO"
											v-on="controls.PRODU___PSEUDSTOCKEVO.handlers" />
									</q-control-wrapper>
								</q-row-container>
								<!-- End PRODU___PSEUDNOVOGR04 -->
							</q-group-collapsible>
							<q-group-collapsible
								id="PRODU___PSEUDNOVOGR05"
								v-bind="controls.PRODU___PSEUDNOVOGR05"
								v-on="controls.PRODU___PSEUDNOVOGR05.handlers">
								<!-- Start PRODU___PSEUDNOVOGR05 -->
								<q-row-container v-show="controls.PRODU___PSEUDINPUTSRE.isVisible || controls.PRODU___PSEUDOUTPUTSD.isVisible">
									<q-control-wrapper
										v-show="controls.PRODU___PSEUDINPUTSRE.isVisible"
										class="control-join-group">
										<q-table
											v-show="controls.PRODU___PSEUDINPUTSRE.isVisible"
											v-bind="controls.PRODU___PSEUDINPUTSRE"
											v-on="controls.PRODU___PSEUDINPUTSRE.handlers" />
										<q-table-extra-extension
											:list-ctrl="controls.PRODU___PSEUDINPUTSRE"
											v-on="controls.PRODU___PSEUDINPUTSRE.handlers" />
									</q-control-wrapper>
									<q-control-wrapper
										v-show="controls.PRODU___PSEUDOUTPUTSD.isVisible"
										class="control-join-group">
										<q-table
											v-show="controls.PRODU___PSEUDOUTPUTSD.isVisible"
											v-bind="controls.PRODU___PSEUDOUTPUTSD"
											v-on="controls.PRODU___PSEUDOUTPUTSD.handlers" />
										<q-table-extra-extension
											:list-ctrl="controls.PRODU___PSEUDOUTPUTSD"
											v-on="controls.PRODU___PSEUDOUTPUTSD.handlers" />
									</q-control-wrapper>
								</q-row-container>
								<!-- End PRODU___PSEUDNOVOGR05 -->
							</q-group-collapsible>
							<!-- End PRODU___PSEUDNOVOGR06 -->
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

	import FormViewModel from './QFormProduViewModel.js'

	const requiredTextResources = ['QFormProdu', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PRODU]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormProdu',

		components: {
			QSeeMoreProduLocatgln: defineAsyncComponent(() => import('@/views/forms/FormProdu/dbedits/ProduLocatglnSeeMore.vue')),
			QSeeMoreProduLcextglnext: defineAsyncComponent(() => import('@/views/forms/FormProdu/dbedits/ProduLcextglnextSeeMore.vue')),
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
					name: 'PRODU',
					location: 'form-PRODU',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormProdu', false),

				interfaceMetadata: {
					id: 'QFormProdu', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'PRODU',
					route: 'form-PRODU',
					area: 'PRODU',
					primaryKey: 'ValCodprodu',
					designation: computed(() => this.Resources.PRODUCT12880),
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
						text: computed(() => vm.Resources.GRAVAR45301),
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
					PRODU___PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'PRODU___PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						label: computed(() => this.Resources.PRODUCT_IDENTIFICATI25169),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['PRODU___PRODUPRODUCT_', 'PRODU___PRODUIN_USE__', 'PRODU___PRODUDESCRIPT', 'PRODU___PRODUSKU_____', 'PRODU___PRODUGTIN____', 'PRODU___PRODUSIZE____', 'PRODU___PRODUWEIGHT__', 'PRODU___PRODUPRICE___', 'PRODU___PRODUINPUTS__', 'PRODU___PRODUOUTPUTS_', 'PRODU___PRODUSTOCK___'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					PRODU___PRODUPRODUCT_: new fieldControlClass.StringControl({
						modelField: 'ValProduct',
						valueChangeEvent: 'fieldChange:produ.product',
						id: 'PRODU___PRODUPRODUCT_',
						name: 'PRODUCT',
						size: 'xxlarge',
						label: computed(() => this.Resources.PRODUCT12880),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PRODU___PSEUDNOVOGR01',
						maxLength: 85,
						labelId: 'label_PRODU___PRODUPRODUCT_',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					PRODU___PRODUIN_USE__: new fieldControlClass.ArrayBooleanControl({
						modelField: 'ValIn_use',
						valueChangeEvent: 'fieldChange:produ.in_use',
						id: 'PRODU___PRODUIN_USE__',
						name: 'IN_USE',
						size: 'mini',
						label: computed(() => this.Resources.IN_USE42606),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PRODU___PSEUDNOVOGR01',
						maxIntegers: 1,
						maxDecimals: 0,
						arrayName: 'YesNo',
						falseLabel: computed(() => this.Resources.NOT_IN_USE41845),
						trueLabel: computed(() => this.Resources.IN_USE42606),
						controlLimits: [
						],
					}, this),
					PRODU___PRODUDESCRIPT: new fieldControlClass.MultilineStringControl({
						modelField: 'ValDescript',
						valueChangeEvent: 'fieldChange:produ.descript',
						id: 'PRODU___PRODUDESCRIPT',
						name: 'DESCRIPT',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESCRIPTION07383),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PRODU___PSEUDNOVOGR01',
						rows: 3,
						cols: 85,
						controlLimits: [
						],
					}, this),
					PRODU___PRODUSKU_____: new fieldControlClass.StringControl({
						modelField: 'ValSku',
						valueChangeEvent: 'fieldChange:produ.sku',
						id: 'PRODU___PRODUSKU_____',
						name: 'SKU',
						size: 'medium',
						label: computed(() => this.Resources.SKU42303),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PRODU___PSEUDNOVOGR01',
						maxLength: 20,
						labelId: 'label_PRODU___PRODUSKU_____',
						controlLimits: [
						],
					}, this),
					PRODU___PRODUGTIN____: new fieldControlClass.StringControl({
						modelField: 'ValGtin',
						valueChangeEvent: 'fieldChange:produ.gtin',
						id: 'PRODU___PRODUGTIN____',
						name: 'GTIN',
						size: 'small',
						label: computed(() => this.Resources.GTIN45487),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PRODU___PSEUDNOVOGR01',
						maxLength: 14,
						labelId: 'label_PRODU___PRODUGTIN____',
						controlLimits: [
						],
					}, this),
					PRODU___PRODUSIZE____: new fieldControlClass.StringControl({
						modelField: 'ValSize',
						valueChangeEvent: 'fieldChange:produ.size',
						id: 'PRODU___PRODUSIZE____',
						name: 'SIZE',
						size: 'medium',
						label: computed(() => this.Resources.SIZE10299),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PRODU___PSEUDNOVOGR01',
						maxLength: 50,
						labelId: 'label_PRODU___PRODUSIZE____',
						controlLimits: [
						],
					}, this),
					PRODU___PRODUWEIGHT__: new fieldControlClass.NumberControl({
						modelField: 'ValWeight',
						valueChangeEvent: 'fieldChange:produ.weight',
						id: 'PRODU___PRODUWEIGHT__',
						name: 'WEIGHT',
						size: 'small',
						label: computed(() => this.Resources.WEIGHT36329),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PRODU___PSEUDNOVOGR01',
						maxIntegers: 7,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					PRODU___PRODUPRICE___: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrice',
						valueChangeEvent: 'fieldChange:produ.price',
						id: 'PRODU___PRODUPRICE___',
						name: 'PRICE',
						size: 'medium',
						label: computed(() => this.Resources.PRICE06900),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PRODU___PSEUDNOVOGR01',
						maxIntegers: 7,
						maxDecimals: 4,
						controlLimits: [
						],
					}, this),
					PRODU___PRODUINPUTS__: new fieldControlClass.NumberControl({
						modelField: 'ValInputs',
						valueChangeEvent: 'fieldChange:produ.inputs',
						id: 'PRODU___PRODUINPUTS__',
						name: 'INPUTS',
						size: 'small',
						label: computed(() => this.Resources.INPUTS19315),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PRODU___PSEUDNOVOGR01',
						isFormulaBlocked: true,
						maxIntegers: 10,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					PRODU___PRODUOUTPUTS_: new fieldControlClass.NumberControl({
						modelField: 'ValOutputs',
						valueChangeEvent: 'fieldChange:produ.outputs',
						id: 'PRODU___PRODUOUTPUTS_',
						name: 'OUTPUTS',
						size: 'small',
						label: computed(() => this.Resources.OUTPUTS47833),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PRODU___PSEUDNOVOGR01',
						isFormulaBlocked: true,
						maxIntegers: 10,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					PRODU___PRODUSTOCK___: new fieldControlClass.NumberControl({
						modelField: 'ValStock',
						valueChangeEvent: 'fieldChange:produ.stock',
						id: 'PRODU___PRODUSTOCK___',
						name: 'STOCK',
						size: 'small',
						label: computed(() => this.Resources.STOCK37618),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PRODU___PSEUDNOVOGR01',
						isFormulaBlocked: true,
						maxIntegers: 10,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					PRODU___PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'PRODU___PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'block',
						label: computed(() => this.Resources.IMAGE65174),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: true,
						anchored: false,
						directChildren: ['PRODU___PRODUIMAGE___'],
						controlLimits: [
						],
					}, this),
					PRODU___PRODUIMAGE___: new fieldControlClass.ImageControl({
						modelField: 'ValImage',
						valueChangeEvent: 'fieldChange:produ.image',
						id: 'PRODU___PRODUIMAGE___',
						name: 'IMAGE',
						size: 'xxlarge',
						label: computed(() => this.Resources.IMAGE65174),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PRODU___PSEUDNOVOGR02',
						height: 300,
						width: 400,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.IMAGE65174)),
						controlLimits: [
						],
					}, this),
					PRODU___PSEUDNOVOGR06: new fieldControlClass.AccordionControl({
						id: 'PRODU___PSEUDNOVOGR06',
						name: 'NOVOGR06',
						size: 'block',
						label: computed(() => this.Resources.ACCORDEON43547),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['PRODU___PSEUDNOVOGR04', 'PRODU___PSEUDNOVOGR05'],
						controlLimits: [
						],
					}, this),
					PRODU___PSEUDNOVOGR04: new fieldControlClass.GroupControl({
						id: 'PRODU___PSEUDNOVOGR04',
						name: 'NOVOGR04',
						size: 'block',
						label: computed(() => this.Resources.STOCK37618),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PRODU___PSEUDNOVOGR06',
						isCollapsible: true,
						anchored: false,
						directChildren: ['PRODU___PSEUDNOVOGR03', 'PRODU___PSEUDSTOCKEVO'],
						controlLimits: [
						],
					}, this),
					PRODU___PSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'PRODU___PSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'block',
						label: computed(() => this.Resources.LOCATION54790),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PRODU___PSEUDNOVOGR04',
						isCollapsible: false,
						anchored: false,
						directChildren: ['PRODU___LOCATGLN_____', 'PRODU___LCEXTGLNEXT__'],
						controlLimits: [
						],
					}, this),
					PRODU___LOCATGLN_____: new fieldControlClass.LookupControl({
						modelField: 'TableLocatGln',
						valueChangeEvent: 'fieldChange:locat.gln',
						id: 'PRODU___LOCATGLN_____',
						name: 'GLN',
						size: 'xlarge',
						label: computed(() => this.Resources.GLOBAL_LOCATION_NUMB24637),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PRODU___PSEUDNOVOGR03',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodlocat',
							dependencyEvent: 'fieldChange:produ.codlocat'
						},
						dependentFields: () => ({
							set 'locat.codlocat'(value) { vm.model.ValCodlocat.updateValue(value) },
							set 'locat.gln'(value) { vm.model.TableLocatGln.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					PRODU___LCEXTGLNEXT__: new fieldControlClass.LookupControl({
						modelField: 'TableLcextGlnext',
						valueChangeEvent: 'fieldChange:lcext.glnext',
						id: 'PRODU___LCEXTGLNEXT__',
						name: 'GLNEXT',
						size: 'xlarge',
						label: computed(() => this.Resources.GLN_EXTENSION_COMPON55869),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PRODU___PSEUDNOVOGR03',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodlcext',
							dependencyEvent: 'fieldChange:produ.codlcext'
						},
						dependentFields: () => ({
							set 'lcext.codlcext'(value) { vm.model.ValCodlcext.updateValue(value) },
							set 'lcext.glnext'(value) { vm.model.TableLcextGlnext.updateValue(value) },
						}),
						controlLimits: [
							{
								identifier: ['locat', 'produ.codlocat'],
								dependencyEvents: ['fieldChange:produ.codlocat'],
								dependencyField: 'PRODU.CODLOCAT',
								fnValueSelector: (model) => model.ValCodlocat.value
							},
						],
					}, this),
					PRODU___PSEUDSTOCKEVO: new fieldControlClass.TableListControl({
						id: 'PRODU___PSEUDSTOCKEVO',
						name: 'STOCKEVO',
						size: '',
						label: computed(() => this.Resources.STOCK_EVOLUTION61800),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PRODU___PSEUDNOVOGR04',
						controller: 'PRODU',
						action: 'Produ_ValStockevo',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.NumericColumn({
								order: 1,
								name: 'ValSequence',
								area: 'STOCK',
								field: 'SEQUENCE',
								label: computed(() => this.Resources.SEQUENCE42310),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 2,
								name: 'ValDate',
								area: 'STOCK',
								field: 'DATE',
								label: computed(() => this.Resources.DATE18475),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValType',
								area: 'STOCK',
								field: 'TYPE',
								label: computed(() => this.Resources.TYPE00312),
								dataLength: 8,
								scrollData: 8,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValReferenc',
								area: 'STOCK',
								field: 'REFERENC',
								label: computed(() => this.Resources.REFERENCE28402),
								dataLength: 10,
								scrollData: 10,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 5,
								name: 'ValQuantity',
								area: 'STOCK',
								field: 'QUANTITY',
								label: computed(() => this.Resources.QUANTITY06415),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 6,
								name: 'ValBalance',
								area: 'STOCK',
								field: 'BALANCE',
								label: computed(() => this.Resources.BALANCE13297),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValStockevo',
							serverMode: true,
							pkColumn: 'ValCodstock',
							tableAlias: 'STOCK',
							tableNamePlural: computed(() => this.Resources.STOCK_EVOLUTION61800),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.STOCK_EVOLUTION61800),
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
							defaultSearchColumnName: 'ValType',
							defaultSearchColumnNameOriginal: 'ValType',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-RECEI', 'changed-STOCK', 'changed-DISPA', 'changed-PRODU'],
						uuid: 'Produ_ValStockevo',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'produ'],
								dependencyEvents: ['fieldChange:produ.codprodu'],
								dependencyField: 'PRODU.CODPRODU',
								fnValueSelector: (model) => model.ValCodprodu.value
							},
						],
					}, this),
					PRODU___PSEUDNOVOGR05: new fieldControlClass.GroupControl({
						id: 'PRODU___PSEUDNOVOGR05',
						name: 'NOVOGR05',
						size: 'block',
						label: computed(() => this.Resources.DETAILS19591),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PRODU___PSEUDNOVOGR06',
						isCollapsible: true,
						anchored: false,
						directChildren: ['PRODU___PSEUDINPUTSRE', 'PRODU___PSEUDOUTPUTSD'],
						controlLimits: [
						],
					}, this),
					PRODU___PSEUDINPUTSRE: new fieldControlClass.TableListControl({
						id: 'PRODU___PSEUDINPUTSRE',
						name: 'INPUTSRE',
						size: '',
						label: computed(() => this.Resources.INPUTS19315),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PRODU___PSEUDNOVOGR05',
						controller: 'PRODU',
						action: 'Produ_ValInputsre',
						hasDependencies: true,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValInstant',
								area: 'RELIN',
								field: 'INSTANT',
								label: computed(() => this.Resources.INSTANT35907),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 2,
								name: 'Recei.ValNumber',
								area: 'RECEI',
								field: 'NUMBER',
								label: computed(() => this.Resources.RECEIPT_NUMBER31380),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
								pkColumn: 'ValCodrecei',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'Entit.ValName',
								area: 'ENTIT',
								field: 'NAME',
								label: computed(() => this.Resources.ENTITY62049),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodentit',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 4,
								name: 'ValLinenumb',
								area: 'RELIN',
								field: 'LINENUMB',
								label: computed(() => this.Resources.LINE27983),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 5,
								name: 'ValOrdered',
								area: 'RELIN',
								field: 'ORDERED',
								label: computed(() => this.Resources.ORDERED04034),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 6,
								name: 'ValReceived',
								area: 'RELIN',
								field: 'RECEIVED',
								label: computed(() => this.Resources.RECEIVED19242),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 7,
								name: 'ValOutstand',
								area: 'RELIN',
								field: 'OUTSTAND',
								label: computed(() => this.Resources.OUTSTANDING36400),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValInputsre',
							serverMode: true,
							pkColumn: 'ValCoddilin',
							tableAlias: 'RELIN',
							tableNamePlural: computed(() => this.Resources.RECEIPT_LINES14292),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.INPUTS19315),
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
										formName: 'RELIN',
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
										formName: 'RELIN',
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
										formName: 'RELIN',
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
										formName: 'RELIN',
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
										formName: 'RELIN',
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
								id: 'RCA__RELIN',
								name: '_RELIN',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'RELIN',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'RELIN': {
									fnKeySelector: (row) => row.Fields.ValCoddilin,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValLinenumb',
							defaultSearchColumnNameOriginal: 'ValLinenumb',
							defaultColumnSorting: {
								columnName: 'ValInstant',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-PRODU', 'changed-RELIN', 'changed-ENTIT', 'changed-RECEI'],
						uuid: 'Produ_ValInputsre',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'produ'],
								dependencyEvents: ['fieldChange:produ.codprodu'],
								dependencyField: 'PRODU.CODPRODU',
								fnValueSelector: (model) => model.ValCodprodu.value
							},
						],
					}, this),
					PRODU___PSEUDOUTPUTSD: new fieldControlClass.TableListControl({
						id: 'PRODU___PSEUDOUTPUTSD',
						name: 'OUTPUTSD',
						size: '',
						label: computed(() => this.Resources.OUTPUTS47833),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PRODU___PSEUDNOVOGR05',
						controller: 'PRODU',
						action: 'Produ_ValOutputsd',
						hasDependencies: true,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValInstant',
								area: 'DILIN',
								field: 'INSTANT',
								label: computed(() => this.Resources.INSTANT35907),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 2,
								name: 'Dispa.ValDispanr',
								area: 'DISPA',
								field: 'DISPANR',
								label: computed(() => this.Resources.DISPATCH_NUMBER23616),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
								pkColumn: 'ValCoddispa',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'Dispa.Entit.ValName',
								area: 'ENTIT',
								field: 'NAME',
								label: computed(() => this.Resources.ENTITY62049),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodentit',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 4,
								name: 'ValLinenumb',
								area: 'DILIN',
								field: 'LINENUMB',
								label: computed(() => this.Resources.LINE27983),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 5,
								name: 'ValOrdered',
								area: 'DILIN',
								field: 'ORDERED',
								label: computed(() => this.Resources.ORDERED04034),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 6,
								name: 'ValDelivere',
								area: 'DILIN',
								field: 'DELIVERE',
								label: computed(() => this.Resources.DELIVERED26597),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 7,
								name: 'ValOutstand',
								area: 'DILIN',
								field: 'OUTSTAND',
								label: computed(() => this.Resources.OUTSTANDING36400),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValOutputsd',
							serverMode: true,
							pkColumn: 'ValCoddilin',
							tableAlias: 'DILIN',
							tableNamePlural: computed(() => this.Resources.DISPATCH_LINES01224),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.OUTPUTS47833),
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
										formName: 'DILIN',
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
										formName: 'DILIN',
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
										formName: 'DILIN',
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
										formName: 'DILIN',
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
										formName: 'DILIN',
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
								id: 'RCA__DILIN',
								name: '_DILIN',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'DILIN',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'DILIN': {
									fnKeySelector: (row) => row.Fields.ValCoddilin,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValLinenumb',
							defaultSearchColumnNameOriginal: 'ValLinenumb',
							defaultColumnSorting: {
								columnName: 'ValInstant',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-PRODU', 'changed-DILIN', 'changed-DISPA'],
						uuid: 'Produ_ValOutputsd',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'produ'],
								dependencyEvents: ['fieldChange:produ.codprodu'],
								dependencyField: 'PRODU.CODPRODU',
								fnValueSelector: (model) => model.ValCodprodu.value
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
					'PRODU___PSEUDNOVOGR01',
					'PRODU___PSEUDNOVOGR02',
					'PRODU___PSEUDNOVOGR06',
					'PRODU___PSEUDNOVOGR04',
					'PRODU___PSEUDNOVOGR03',
					'PRODU___PSEUDNOVOGR05',
				]),

				tableFields: readonly([
					'PRODU___PSEUDSTOCKEVO',
					'PRODU___PSEUDINPUTSRE',
					'PRODU___PSEUDOUTPUTSD',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Lcext: {
						get ValGlnext() { return vm.model.TableLcextGlnext.value },
						set ValGlnext(value) { vm.model.TableLcextGlnext.updateValue(value) },
					},
					Locat: {
						get ValGln() { return vm.model.TableLocatGln.value },
						set ValGln(value) { vm.model.TableLocatGln.updateValue(value) },
					},
					Produ: {
						get ValCodlcext() { return vm.model.ValCodlcext.value },
						set ValCodlcext(value) { vm.model.ValCodlcext.updateValue(value) },
						get ValCodlocat() { return vm.model.ValCodlocat.value },
						set ValCodlocat(value) { vm.model.ValCodlocat.updateValue(value) },
						get ValDescript() { return vm.model.ValDescript.value },
						set ValDescript(value) { vm.model.ValDescript.updateValue(value) },
						get ValGtin() { return vm.model.ValGtin.value },
						set ValGtin(value) { vm.model.ValGtin.updateValue(value) },
						get ValImage() { return vm.model.ValImage.value },
						set ValImage(value) { vm.model.ValImage.updateValue(value) },
						get ValIn_use() { return vm.model.ValIn_use.value },
						set ValIn_use(value) { vm.model.ValIn_use.updateValue(value) },
						get ValInputs() { return vm.model.ValInputs.value },
						set ValInputs(value) { vm.model.ValInputs.updateValue(value) },
						get ValOutputs() { return vm.model.ValOutputs.value },
						set ValOutputs(value) { vm.model.ValOutputs.updateValue(value) },
						get ValPrice() { return vm.model.ValPrice.value },
						set ValPrice(value) { vm.model.ValPrice.updateValue(value) },
						get ValProduct() { return vm.model.ValProduct.value },
						set ValProduct(value) { vm.model.ValProduct.updateValue(value) },
						get ValSize() { return vm.model.ValSize.value },
						set ValSize(value) { vm.model.ValSize.updateValue(value) },
						get ValSku() { return vm.model.ValSku.value },
						set ValSku(value) { vm.model.ValSku.updateValue(value) },
						get ValStock() { return vm.model.ValStock.value },
						set ValStock(value) { vm.model.ValStock.updateValue(value) },
						get ValWeight() { return vm.model.ValWeight.value },
						set ValWeight(value) { vm.model.ValWeight.updateValue(value) },
					},
					keys: {
						/** The primary key of the PRODU table */
						get produ() { return vm.model.ValCodprodu },
						/** The foreign key to the LOCAT table */
						get locat() { return vm.model.ValCodlocat },
						/** The foreign key to the LCEXT table */
						get lcext() { return vm.model.ValCodlcext },
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
// USE /[MANUAL GQT FORM_CODEJS PRODU]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS PRODU]/
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
// USE /[MANUAL GQT FORM_LOADED_JS PRODU]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS PRODU]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS PRODU]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS PRODU]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS PRODU]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS PRODU]/
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
// USE /[MANUAL GQT AFTER_DEL_JS PRODU]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS PRODU]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS PRODU]/
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
// USE /[MANUAL GQT DLGUPDT PRODU]/
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
// USE /[MANUAL GQT CTRLBLR PRODU]/
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
// USE /[MANUAL GQT CTRLUPD PRODU]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS PRODU]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
