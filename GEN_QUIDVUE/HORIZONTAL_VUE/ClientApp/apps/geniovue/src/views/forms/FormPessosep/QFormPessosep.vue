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
			data-key="PESSOSEP"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container
					v-show="controls.PESSOSEPPSEUDNOVOGR02.isVisible || controls.PESSOSEPPSEUDOBRIGATO.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.PESSOSEPPSEUDNOVOGR02.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="PESSOSEPPSEUDNOVOGR02"
							v-bind="controls.PESSOSEPPSEUDNOVOGR02"
							:is-visible="controls.PESSOSEPPSEUDNOVOGR02.isVisible">
							<!-- Start PESSOSEPPSEUDNOVOGR02 -->
							<q-row-container v-show="controls.PESSOSEPPESSOIDFUNCIO.isVisible || controls.PESSOSEPPESSONAME____.isVisible || controls.PESSOSEPPESSODTNASCIM.isVisible || controls.PESSOSEPPESSOGENDER__.isVisible">
								<q-control-wrapper
									v-show="controls.PESSOSEPPESSOIDFUNCIO.isVisible || controls.PESSOSEPPESSONAME____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PESSOSEPPESSOIDFUNCIO"
										v-on="controls.PESSOSEPPESSOIDFUNCIO.handlers"
										:loading="controls.PESSOSEPPESSOIDFUNCIO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.PESSOSEPPESSOIDFUNCIO.isVisible"
											v-bind="controls.PESSOSEPPESSOIDFUNCIO.props"
											@update:model-value="model.ValIdfuncio.fnUpdateValue" />
									</base-input-structure>
									<base-input-structure
										class="i-text"
										v-bind="controls.PESSOSEPPESSONAME____"
										v-on="controls.PESSOSEPPESSONAME____.handlers"
										:loading="controls.PESSOSEPPESSONAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.PESSOSEPPESSONAME____.props"
											@blur="onBlur(controls.PESSOSEPPESSONAME____, model.ValName.value)"
											@change="model.ValName.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PESSOSEPPESSODTNASCIM.isVisible || controls.PESSOSEPPESSOGENDER__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PESSOSEPPESSODTNASCIM"
										v-on="controls.PESSOSEPPESSODTNASCIM.handlers"
										:loading="controls.PESSOSEPPESSODTNASCIM.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.PESSOSEPPESSODTNASCIM.isVisible"
											v-bind="controls.PESSOSEPPESSODTNASCIM.props"
											:model-value="model.ValDtnascim.value"
											@reset-icon-click="model.ValDtnascim.fnUpdateValue(model.ValDtnascim.originalValue ?? new Date())"
											@update:model-value="model.ValDtnascim.fnUpdateValue($event ?? '')" />
									</base-input-structure>
									<base-input-structure
										class="i-radio-container"
										v-bind="controls.PESSOSEPPESSOGENDER__"
										v-on="controls.PESSOSEPPESSOGENDER__.handlers"
										:label-position="labelAlignment.topleft"
										:loading="controls.PESSOSEPPESSOGENDER__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-radio-group
											v-if="controls.PESSOSEPPESSOGENDER__.isVisible"
											id="PESSOSEPPESSOGENDER__"
											:model-value="model.ValGender.value"
											deselect-radio
											:label-left-side="controls.PESSOSEPPESSOGENDER__.labelPosition === labelAlignment.left"
											:number-of-columns="controls.PESSOSEPPESSOGENDER__.columnNumber"
											:is-required="controls.PESSOSEPPESSOGENDER__.isRequired"
											:readonly="controls.PESSOSEPPESSOGENDER__.readonly"
											:options-list="controls.PESSOSEPPESSOGENDER__.items"
											@update:model-value="model.ValGender.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PESSOSEPPESSOINTERNA_.isVisible || controls.PESSOSEPPESSOEXTERNA_.isVisible">
								<q-control-wrapper
									v-show="controls.PESSOSEPPESSOINTERNA_.isVisible || controls.PESSOSEPPESSOEXTERNA_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.PESSOSEPPESSOINTERNA_"
										v-on="controls.PESSOSEPPESSOINTERNA_.handlers"
										:loading="controls.PESSOSEPPESSOINTERNA_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.PESSOSEPPESSOINTERNA_.isVisible"
												v-bind="controls.PESSOSEPPESSOINTERNA_.props"
												v-on="controls.PESSOSEPPESSOINTERNA_.handlers" />
										</template>
									</base-input-structure>
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.PESSOSEPPESSOEXTERNA_"
										v-on="controls.PESSOSEPPESSOEXTERNA_.handlers"
										:loading="controls.PESSOSEPPESSOEXTERNA_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.PESSOSEPPESSOEXTERNA_.isVisible"
												v-bind="controls.PESSOSEPPESSOEXTERNA_.props"
												v-on="controls.PESSOSEPPESSOEXTERNA_.handlers" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PESSOSEPCATEGCATEGORY.isVisible || controls.PESSOSEPPESSODTULTCAT.isVisible">
								<q-control-wrapper
									v-show="controls.PESSOSEPCATEGCATEGORY.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PESSOSEPCATEGCATEGORY"
										v-on="controls.PESSOSEPCATEGCATEGORY.handlers"
										:loading="controls.PESSOSEPCATEGCATEGORY.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.PESSOSEPCATEGCATEGORY.isVisible"
											v-bind="controls.PESSOSEPCATEGCATEGORY.props"
											v-on="controls.PESSOSEPCATEGCATEGORY.handlers" />
										<q-see-more-pessosepcategcategory
											v-if="controls.PESSOSEPCATEGCATEGORY.seeMoreIsVisible"
											v-bind="controls.PESSOSEPCATEGCATEGORY.seeMoreParams"
											v-on="controls.PESSOSEPCATEGCATEGORY.handlers" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PESSOSEPPESSODTULTCAT.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PESSOSEPPESSODTULTCAT"
										v-on="controls.PESSOSEPPESSODTULTCAT.handlers"
										:loading="controls.PESSOSEPPESSODTULTCAT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.PESSOSEPPESSODTULTCAT.isVisible"
											v-bind="controls.PESSOSEPPESSODTULTCAT.props"
											:model-value="model.ValDtultcat.value"
											@reset-icon-click="model.ValDtultcat.fnUpdateValue(model.ValDtultcat.originalValue ?? new Date())"
											@update:model-value="model.ValDtultcat.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End PESSOSEPPSEUDNOVOGR02 -->
						</q-group-box-container>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.PESSOSEPPSEUDOBRIGATO.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-static-text"
							v-bind="controls.PESSOSEPPSEUDOBRIGATO"
							v-on="controls.PESSOSEPPSEUDOBRIGATO.handlers"
							:loading="controls.PESSOSEPPSEUDOBRIGATO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-static-text
								v-if="controls.PESSOSEPPSEUDOBRIGATO.isVisible"
								id="PESSOSEPPSEUDOBRIGATO"
								:size="controls.PESSOSEPPSEUDOBRIGATO.size"
								:text="controls.PESSOSEPPSEUDOBRIGATO.label"
								supports-html />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PESSOSEPPSEUDPESSOS00.isVisible || controls.PESSOSEPPSEUDPESSOS01.isVisible">
					<q-control-wrapper
						v-show="controls.PESSOSEPPSEUDPESSOS00.isVisible || controls.PESSOSEPPSEUDPESSOS01.isVisible"
						class="control-join-group">
						<q-tab-container
							id="q-tabs-PESSOSEP"
							v-bind="controls.formTabs.props"
							@tab-changed="controls.formTabs.selectTab($event)">
							<template #tab-panel>
								<section
									v-if="controls.PESSOSEPPSEUDPESSOS00.isVisible"
									v-show="controls.formTabs.selectedTab === 'PESSOSEPPSEUDPESSOS00'">
									<div
										id="PESSOSEPPSEUDPESSOS00"
										role="tabpanel"
										aria-labelledby="tab-container-PESSOSEPPSEUDPESSOS00">
										<q-row-container v-show="controls.PESSOS00CMPNYDESIGNAT.isVisible">
											<q-control-wrapper
												v-show="controls.PESSOS00CMPNYDESIGNAT.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PESSOS00CMPNYDESIGNAT"
													v-on="controls.PESSOS00CMPNYDESIGNAT.handlers"
													:loading="controls.PESSOS00CMPNYDESIGNAT.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-lookup
														v-if="controls.PESSOS00CMPNYDESIGNAT.isVisible"
														v-bind="controls.PESSOS00CMPNYDESIGNAT.props"
														v-on="controls.PESSOS00CMPNYDESIGNAT.handlers" />
													<q-see-more-pessos00cmpnydesignat
														v-if="controls.PESSOS00CMPNYDESIGNAT.seeMoreIsVisible"
														v-bind="controls.PESSOS00CMPNYDESIGNAT.seeMoreParams"
														v-on="controls.PESSOS00CMPNYDESIGNAT.handlers" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
									</div>
								</section>
								<section
									v-if="controls.PESSOSEPPSEUDPESSOS01.isVisible"
									v-show="controls.formTabs.selectedTab === 'PESSOSEPPSEUDPESSOS01'">
									<div
										id="PESSOSEPPSEUDPESSOS01"
										role="tabpanel"
										aria-labelledby="tab-container-PESSOSEPPSEUDPESSOS01">
										<q-row-container
											v-show="controls.PESSOS01PSEUDNOVOGR06.isVisible"
											is-large>
											<q-control-wrapper
												v-show="controls.PESSOS01PSEUDNOVOGR06.isVisible"
												class="row-line-group">
												<q-accordion
													v-if="controls.PESSOS01PSEUDNOVOGR06.isVisible"
													id="PESSOS01PSEUDNOVOGR06"
													v-bind="controls.PESSOS01PSEUDNOVOGR06">
													<!-- Start PESSOS01PSEUDNOVOGR06 -->
													<q-group-collapsible
														id="PESSOS01PSEUDNOVOGR03"
														v-bind="controls.PESSOS01PSEUDNOVOGR03"
														v-on="controls.PESSOS01PSEUDNOVOGR03.handlers">
														<!-- Start PESSOS01PSEUDNOVOGR03 -->
														<q-row-container v-show="controls.PESSOS01PESSOTELEPHON.isVisible || controls.PESSOS01PESSOEMAIL___.isVisible">
															<q-control-wrapper
																v-show="controls.PESSOS01PESSOTELEPHON.isVisible"
																class="control-join-group">
																<base-input-structure
																	class="i-text"
																	v-bind="controls.PESSOS01PESSOTELEPHON"
																	v-on="controls.PESSOS01PESSOTELEPHON.handlers"
																	:loading="controls.PESSOS01PESSOTELEPHON.props.loading"
																	:reporting-mode-on="reportingModeCAV"
																	:suggestion-mode-on="suggestionModeOn">
																	<q-text-field
																		v-bind="controls.PESSOS01PESSOTELEPHON.props"
																		@blur="onBlur(controls.PESSOS01PESSOTELEPHON, model.ValTelephon.value)"
																		@change="model.ValTelephon.fnUpdateValueOnChange" />
																</base-input-structure>
															</q-control-wrapper>
															<q-control-wrapper
																v-show="controls.PESSOS01PESSOEMAIL___.isVisible"
																class="control-join-group">
																<base-input-structure
																	class="i-text"
																	v-bind="controls.PESSOS01PESSOEMAIL___"
																	v-on="controls.PESSOS01PESSOEMAIL___.handlers"
																	:loading="controls.PESSOS01PESSOEMAIL___.props.loading"
																	:reporting-mode-on="reportingModeCAV"
																	:suggestion-mode-on="suggestionModeOn">
																	<q-text-field
																		v-bind="controls.PESSOS01PESSOEMAIL___.props"
																		@blur="onBlur(controls.PESSOS01PESSOEMAIL___, model.ValEmail.value)"
																		@change="model.ValEmail.fnUpdateValueOnChange" />
																</base-input-structure>
															</q-control-wrapper>
														</q-row-container>
														<!-- End PESSOS01PSEUDNOVOGR03 -->
													</q-group-collapsible>
													<q-group-collapsible
														id="PESSOS01PSEUDNOVOGR04"
														v-bind="controls.PESSOS01PSEUDNOVOGR04"
														v-on="controls.PESSOS01PSEUDNOVOGR04.handlers">
														<!-- Start PESSOS01PSEUDNOVOGR04 -->
														<q-row-container v-show="controls.PESSOS01PESSOPHOTOGRA.isVisible">
															<q-control-wrapper
																v-show="controls.PESSOS01PESSOPHOTOGRA.isVisible"
																class="control-join-group">
																<base-input-structure
																	class="q-image"
																	v-bind="controls.PESSOS01PESSOPHOTOGRA"
																	v-on="controls.PESSOS01PESSOPHOTOGRA.handlers"
																	:loading="controls.PESSOS01PESSOPHOTOGRA.props.loading"
																	:reporting-mode-on="reportingModeCAV"
																	:suggestion-mode-on="suggestionModeOn">
																	<q-image
																		v-if="controls.PESSOS01PESSOPHOTOGRA.isVisible"
																		v-bind="controls.PESSOS01PESSOPHOTOGRA.props"
																		v-on="controls.PESSOS01PESSOPHOTOGRA.handlers" />
																</base-input-structure>
															</q-control-wrapper>
														</q-row-container>
														<!-- End PESSOS01PSEUDNOVOGR04 -->
													</q-group-collapsible>
													<q-group-collapsible
														id="PESSOS01PSEUDNOVOGR05"
														v-bind="controls.PESSOS01PSEUDNOVOGR05"
														v-on="controls.PESSOS01PSEUDNOVOGR05.handlers">
														<!-- Start PESSOS01PSEUDNOVOGR05 -->
														<q-row-container v-show="controls.PESSOS01PSEUDEVOLUCAO.isVisible">
															<q-control-wrapper
																v-show="controls.PESSOS01PSEUDEVOLUCAO.isVisible"
																class="control-join-group">
																<q-table
																	v-show="controls.PESSOS01PSEUDEVOLUCAO.isVisible"
																	v-bind="controls.PESSOS01PSEUDEVOLUCAO"
																	v-on="controls.PESSOS01PSEUDEVOLUCAO.handlers" />
																<q-table-extra-extension
																	:list-ctrl="controls.PESSOS01PSEUDEVOLUCAO"
																	v-on="controls.PESSOS01PSEUDEVOLUCAO.handlers" />
															</q-control-wrapper>
														</q-row-container>
														<q-row-container v-show="controls.PESSOS01PSEUDFICHACAR.isVisible">
															<q-control-wrapper
																v-show="controls.PESSOS01PSEUDFICHACAR.isVisible"
																class="control-join-group">
																<q-form-container
																	:ref="controls.PESSOS01PSEUDFICHACAR.id"
																	v-bind="controls.PESSOS01PSEUDFICHACAR"
																	v-on="controls.PESSOS01PSEUDFICHACAR.handlers" />
															</q-control-wrapper>
														</q-row-container>
														<!-- End PESSOS01PSEUDNOVOGR05 -->
													</q-group-collapsible>
													<q-group-collapsible
														id="PESSOS01PSEUDNOVOGR07"
														v-bind="controls.PESSOS01PSEUDNOVOGR07"
														v-on="controls.PESSOS01PSEUDNOVOGR07.handlers">
														<!-- Start PESSOS01PSEUDNOVOGR07 -->
														<q-row-container v-show="controls.PESSOS01PSEUDCONTACTO.isVisible">
															<q-control-wrapper
																v-show="controls.PESSOS01PSEUDCONTACTO.isVisible"
																class="control-join-group">
																<q-table
																	v-show="controls.PESSOS01PSEUDCONTACTO.isVisible"
																	v-bind="controls.PESSOS01PSEUDCONTACTO"
																	v-on="controls.PESSOS01PSEUDCONTACTO.handlers" />
																<q-table-extra-extension
																	:list-ctrl="controls.PESSOS01PSEUDCONTACTO"
																	v-on="controls.PESSOS01PSEUDCONTACTO.handlers" />
															</q-control-wrapper>
														</q-row-container>
														<!-- End PESSOS01PSEUDNOVOGR07 -->
													</q-group-collapsible>
													<!-- End PESSOS01PSEUDNOVOGR06 -->
												</q-accordion>
											</q-control-wrapper>
										</q-row-container>
									</div>
								</section>
							</template>
						</q-tab-container>
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

	import FormViewModel from './QFormPessosepViewModel.js'

	const requiredTextResources = ['QFormPessosep', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PESSOSEP]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormPessosep',

		components: {
			QSeeMorePessosepcategcategory: defineAsyncComponent(() => import('@/views/forms/FormPessosep/dbedits/PessosepcategcategorySeeMore.vue')),
			QSeeMorePessos00cmpnydesignat: defineAsyncComponent(() => import('@/views/forms/FormPessosep/dbedits/Pessos00cmpnydesignatSeeMore.vue')),
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
					name: 'PESSOSEP',
					location: 'form-PESSOSEP',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormPessosep', false),

				interfaceMetadata: {
					id: 'QFormPessosep', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'PESSOSEP',
					route: 'form-PESSOSEP',
					area: 'PESSO',
					primaryKey: 'ValCodpesso',
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
					PESSOSEPPSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'PESSOSEPPSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'block',
						label: computed(() => this.Resources.IDENTIFICATION40793),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['PESSOSEPPESSOIDFUNCIO', 'PESSOSEPPESSONAME____', 'PESSOSEPPESSODTNASCIM', 'PESSOSEPPESSOGENDER__', 'PESSOSEPPESSOINTERNA_', 'PESSOSEPPESSOEXTERNA_', 'PESSOSEPCATEGCATEGORY', 'PESSOSEPPESSODTULTCAT'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					PESSOSEPPESSOIDFUNCIO: new fieldControlClass.NumberControl({
						modelField: 'ValIdfuncio',
						valueChangeEvent: 'fieldChange:pesso.idfuncio',
						id: 'PESSOSEPPESSOIDFUNCIO',
						name: 'IDFUNCIO',
						size: 'small',
						label: computed(() => this.Resources.EMPLOYEE_NO_01176),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSOSEPPSEUDNOVOGR02',
						maxIntegers: 6,
						maxDecimals: 0,
						isSequencial: true,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					PESSOSEPPESSONAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:pesso.name',
						id: 'PESSOSEPPESSONAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.NAME_23841),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSOSEPPSEUDNOVOGR02',
						maxLength: 85,
						labelId: 'label_PESSOSEPPESSONAME____',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					PESSOSEPPESSODTNASCIM: new fieldControlClass.DateControl({
						modelField: 'ValDtnascim',
						valueChangeEvent: 'fieldChange:pesso.dtnascim',
						id: 'PESSOSEPPESSODTNASCIM',
						name: 'DTNASCIM',
						size: 'small',
						label: computed(() => this.Resources.BIRTH21799),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSOSEPPSEUDNOVOGR02',
						format: 'date',
						controlLimits: [
						],
					}, this),
					PESSOSEPPESSOGENDER__: new fieldControlClass.ArrayStringControl({
						modelField: 'ValGender',
						valueChangeEvent: 'fieldChange:pesso.gender',
						id: 'PESSOSEPPESSOGENDER__',
						name: 'GENDER',
						size: 'mini',
						label: computed(() => this.Resources.GENDER44172),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'PESSOSEPPSEUDNOVOGR02',
						maxLength: 1,
						labelId: 'label_PESSOSEPPESSOGENDER__',
						arrayName: 'Genero',
						columnNumber: 3,
						controlLimits: [
						],
					}, this),
					PESSOSEPPESSOINTERNA_: new fieldControlClass.BooleanControl({
						modelField: 'ValInterna',
						valueChangeEvent: 'fieldChange:pesso.interna',
						id: 'PESSOSEPPESSOINTERNA_',
						name: 'INTERNA',
						size: 'mini',
						label: computed(() => this.Resources.INTERN65375),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'PESSOSEPPSEUDNOVOGR02',
						controlLimits: [
						],
					}, this),
					PESSOSEPPESSOEXTERNA_: new fieldControlClass.BooleanControl({
						modelField: 'ValExterna',
						valueChangeEvent: 'fieldChange:pesso.externa',
						id: 'PESSOSEPPESSOEXTERNA_',
						name: 'EXTERNA',
						size: 'small',
						label: computed(() => this.Resources.EXTERNAL13375),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'PESSOSEPPSEUDNOVOGR02',
						controlLimits: [
						],
					}, this),
					PESSOSEPCATEGCATEGORY: new fieldControlClass.LookupControl({
						modelField: 'TableCategCategory',
						valueChangeEvent: 'fieldChange:categ.categoria',
						id: 'PESSOSEPCATEGCATEGORY',
						name: 'CATEGORY',
						size: 'xlarge',
						label: computed(() => this.Resources.CATEGORY18978),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSOSEPPSEUDNOVOGR02',
						isFormulaBlocked: true,
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodcateg',
							dependencyEvent: 'fieldChange:pesso.codcateg'
						},
						dependentFields: () => ({
							set 'categ.codcateg'(value) { vm.model.ValCodcateg.updateValue(value) },
							set 'categ.categoria'(value) { vm.model.TableCategCategory.updateValue(value) },
						}),
						insertEnabled: true,
						supportForm: 'CATEG',
						controlLimits: [
						],
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: [PESSO->INTERNA]==1
								return (this.ValInterna.value ? 1 : 0)===1
							},
							dependencyEvents: ['fieldChange:pesso.interna'],
							isServerRecalc: false,
						},
					}, this),
					PESSOSEPPESSODTULTCAT: new fieldControlClass.DateControl({
						modelField: 'ValDtultcat',
						valueChangeEvent: 'fieldChange:pesso.dtultcat',
						id: 'PESSOSEPPESSODTULTCAT',
						name: 'DTULTCAT',
						size: 'small',
						label: computed(() => this.Resources.SINCE47259),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSOSEPPSEUDNOVOGR02',
						isFormulaBlocked: true,
						format: 'date',
						controlLimits: [
						],
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: [PESSO->INTERNA]==1
								return (this.ValInterna.value ? 1 : 0)===1
							},
							dependencyEvents: ['fieldChange:pesso.interna'],
							isServerRecalc: false,
						},
					}, this),
					PESSOSEPPSEUDOBRIGATO: new fieldControlClass.BaseControl({
						id: 'PESSOSEPPSEUDOBRIGATO',
						name: 'OBRIGATO',
						size: 'xxlarge',
						hasLabel: false,
						label: computed(() => this.Resources.AT_REQUIRED65277),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						supportsHtml: true,
						controlLimits: [
						],
					}, this),
					PESSOSEPPSEUDPESSOS00: new fieldControlClass.TabControl({
						id: 'PESSOSEPPSEUDPESSOS00',
						name: 'PESSOS00',
						size: 'xxlarge',
						label: computed(() => this.Resources.COMPANY20759),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['PESSOS00CMPNYDESIGNAT'],
						controlLimits: [
						],
					}, this),
					PESSOSEPPSEUDPESSOS01: new fieldControlClass.TabControl({
						id: 'PESSOSEPPSEUDPESSOS01',
						name: 'PESSOS01',
						size: 'xxlarge',
						label: computed(() => this.Resources.EVERYTHING62829),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['PESSOS01PSEUDNOVOGR06'],
						controlLimits: [
						],
					}, this),
					PESSOS00CMPNYDESIGNAT: new fieldControlClass.LookupControl({
						modelField: 'TableCmpnyDesignat',
						valueChangeEvent: 'fieldChange:cmpny.designat',
						id: 'PESSOS00CMPNYDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESIGNATION35876),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'PESSOSEPPSEUDPESSOS00',
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
							dependencyEvent: 'fieldChange:pesso.codempre'
						},
						dependentFields: () => ({
							set 'cmpny.codempre'(value) { vm.model.ValCodempre.updateValue(value) },
							set 'cmpny.designat'(value) { vm.model.TableCmpnyDesignat.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					PESSOS01PSEUDNOVOGR06: new fieldControlClass.AccordionControl({
						id: 'PESSOS01PSEUDNOVOGR06',
						name: 'NOVOGR06',
						size: 'block',
						label: computed(() => this.Resources.ACCORDION01950),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'PESSOSEPPSEUDPESSOS01',
						isCollapsible: false,
						anchored: false,
						directChildren: ['PESSOS01PSEUDNOVOGR03', 'PESSOS01PSEUDNOVOGR04', 'PESSOS01PSEUDNOVOGR05', 'PESSOS01PSEUDNOVOGR07'],
						controlLimits: [
						],
					}, this),
					PESSOS01PSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'PESSOS01PSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'block',
						label: computed(() => this.Resources.CONTACT05134),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSOS01PSEUDNOVOGR06',
						tab: 'PESSOSEPPSEUDPESSOS01',
						isCollapsible: true,
						anchored: false,
						directChildren: ['PESSOS01PESSOTELEPHON', 'PESSOS01PESSOEMAIL___'],
						controlLimits: [
						],
					}, this),
					PESSOS01PESSOTELEPHON: new fieldControlClass.StringControl({
						modelField: 'ValTelephon',
						valueChangeEvent: 'fieldChange:pesso.telephon',
						id: 'PESSOS01PESSOTELEPHON',
						name: 'TELEPHON',
						size: 'medium',
						label: computed(() => this.Resources.TELEPHONE28697),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSOS01PSEUDNOVOGR03',
						tab: 'PESSOSEPPSEUDPESSOS01',
						maxLength: 20,
						labelId: 'label_PESSOS01PESSOTELEPHON',
						controlLimits: [
						],
					}, this),
					PESSOS01PESSOEMAIL___: new fieldControlClass.StringControl({
						modelField: 'ValEmail',
						valueChangeEvent: 'fieldChange:pesso.email',
						id: 'PESSOS01PESSOEMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						label: computed(() => this.Resources.EMAIL_44228),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSOS01PSEUDNOVOGR03',
						tab: 'PESSOSEPPSEUDPESSOS01',
						maxLength: 254,
						labelId: 'label_PESSOS01PESSOEMAIL___',
						controlLimits: [
						],
					}, this),
					PESSOS01PSEUDNOVOGR04: new fieldControlClass.GroupControl({
						id: 'PESSOS01PSEUDNOVOGR04',
						name: 'NOVOGR04',
						size: 'block',
						label: computed(() => this.Resources.PHOTO32097),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSOS01PSEUDNOVOGR06',
						tab: 'PESSOSEPPSEUDPESSOS01',
						isCollapsible: true,
						anchored: false,
						directChildren: ['PESSOS01PESSOPHOTOGRA'],
						controlLimits: [
						],
					}, this),
					PESSOS01PESSOPHOTOGRA: new fieldControlClass.ImageControl({
						modelField: 'ValPhotogra',
						valueChangeEvent: 'fieldChange:pesso.photogra',
						id: 'PESSOS01PESSOPHOTOGRA',
						name: 'PHOTOGRA',
						size: 'medium',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSOS01PSEUDNOVOGR04',
						tab: 'PESSOSEPPSEUDPESSOS01',
						height: 50,
						width: 100,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO51874)),
						controlLimits: [
						],
					}, this),
					PESSOS01PSEUDNOVOGR05: new fieldControlClass.GroupControl({
						id: 'PESSOS01PSEUDNOVOGR05',
						name: 'NOVOGR05',
						size: 'block',
						label: computed(() => this.Resources.CAREER41490),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSOS01PSEUDNOVOGR06',
						tab: 'PESSOSEPPSEUDPESSOS01',
						isCollapsible: true,
						anchored: false,
						directChildren: ['PESSOS01PSEUDEVOLUCAO', 'PESSOS01PSEUDFICHACAR'],
						controlLimits: [
						],
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: [PESSO->INTERNA]==1
								return (this.ValInterna.value ? 1 : 0)===1
							},
							dependencyEvents: ['fieldChange:pesso.interna'],
							isServerRecalc: false,
						},
					}, this),
					PESSOS01PSEUDEVOLUCAO: new fieldControlClass.TableListControl({
						id: 'PESSOS01PSEUDEVOLUCAO',
						name: 'EVOLUCAO',
						size: '',
						label: computed(() => this.Resources.PROFESSIONAL_CATEGOR43519),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSOS01PSEUDNOVOGR05',
						tab: 'PESSOSEPPSEUDPESSOS01',
						controller: 'PESSO',
						action: 'Pessos01_ValEvolucao',
						hasDependencies: true,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValSince',
								area: 'EVCAT',
								field: 'SINCE',
								label: computed(() => this.Resources.SINCE47259),
								scrollData: 8,
								dateTimeType: 'date',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'Cate1.ValCategoria',
								area: 'CATE1',
								field: 'CATEGORIA',
								label: computed(() => this.Resources.CATEGORY18978),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodcateg',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 3,
								name: 'ValFimperio',
								area: 'EVCAT',
								field: 'FIMPERIO',
								label: computed(() => this.Resources.END_OF_PERIOD44616),
								scrollData: 8,
								dateTimeType: 'date',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValObservat',
								area: 'EVCAT',
								field: 'OBSERVAT',
								label: computed(() => this.Resources.OBSERVATION37880),
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValEvolucao',
							serverMode: true,
							pkColumn: 'ValCodprogr',
							tableAlias: 'EVCAT',
							tableNamePlural: computed(() => this.Resources.EVOLUTION_IN_CATEGOR19803),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.PROFESSIONAL_CATEGOR43519),
							showAlternatePagination: true,
							rowClickActionInternal: 'selectSingle',
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
										formName: 'EVCAT',
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
										formName: 'EVCAT',
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
										formName: 'EVCAT',
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
										formName: 'EVCAT',
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
										formName: 'EVCAT',
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
								id: 'RCA__EVCAT',
								name: '_EVCAT',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'EVCAT',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'EVCAT': {
									fnKeySelector: (row) => row.Fields.ValCodprogr,
									isPopup: false
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'ValSince',
								sortOrder: 'desc'
							}
						},
						globalEvents: ['changed-PESSO', 'changed-EVCAT', 'changed-CATE1'],
						uuid: 'Pessos01_ValEvolucao',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'pesso'],
								dependencyEvents: ['fieldChange:pesso.codpesso'],
								dependencyField: 'PESSO.CODPESSO',
								fnValueSelector: (model) => model.ValCodpesso.value
							},
						],
					}, this),
					PESSOS01PSEUDFICHACAR: new fieldControlClass.FormContainerControl({
						id: 'PESSOS01PSEUDFICHACAR',
						name: 'FICHACAR',
						size: 'xxlarge',
						label: computed(() => this.Resources.CAREER_RECORD36379),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSOS01PSEUDNOVOGR05',
						tab: 'PESSOSEPPSEUDPESSOS01',
						targetTableListId: 'PESSOS01PSEUDEVOLUCAO',
						supportForm: {
							name: 'EVCAT',
							component: 'QFormEvcat',
							mode: computed(() => vm.formInfo.mode),
							fnKeySelector: (row) => row.Fields.ValCodprogr
						},
						allowFormActions: {
						},
						controlLimits: [
						],
					}, this),
					PESSOS01PSEUDNOVOGR07: new fieldControlClass.GroupControl({
						id: 'PESSOS01PSEUDNOVOGR07',
						name: 'NOVOGR07',
						size: 'block',
						label: computed(() => this.Resources.CONTACT05134),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSOS01PSEUDNOVOGR06',
						tab: 'PESSOSEPPSEUDPESSOS01',
						isCollapsible: true,
						anchored: false,
						directChildren: ['PESSOS01PSEUDCONTACTO'],
						controlLimits: [
						],
					}, this),
					PESSOS01PSEUDCONTACTO: new fieldControlClass.TableListControl({
						id: 'PESSOS01PSEUDCONTACTO',
						name: 'CONTACTO',
						size: '',
						label: computed(() => this.Resources.CONTACTS55742),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSOS01PSEUDNOVOGR07',
						tab: 'PESSOSEPPSEUDPESSOS01',
						controller: 'PESSO',
						action: 'Pessos01_ValContacto',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Tpcon.ValTipocont',
								area: 'TPCON',
								field: 'TIPOCONT',
								label: computed(() => this.Resources.GENUS37471),
								dataLength: 50,
								scrollData: 20,
								pkColumn: 'ValCodtpcon',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValContacto',
								area: 'CONTA',
								field: 'CONTACTO',
								label: computed(() => this.Resources.CONTACT59247),
								dataLength: 254,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValContacto',
							serverMode: true,
							pkColumn: 'ValCodconta',
							tableAlias: 'CONTA',
							tableNamePlural: computed(() => this.Resources.CONTACTS55742),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.CONTACTS55742),
							showAlternatePagination: true,
							permissions: {
								canView: false,
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
										formName: 'CONTA',
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
										formName: 'CONTA',
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
										formName: 'CONTA',
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
										formName: 'CONTA',
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
								'CONTA': {
									fnKeySelector: (row) => row.Fields.ValCodconta,
									isPopup: true
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'Tpcon.ValTipocont',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-TPCON', 'changed-CONTA', 'changed-PESSO', 'changed-GENRE'],
						uuid: 'Pessos01_ValContacto',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'pesso'],
								dependencyEvents: ['fieldChange:pesso.codpesso'],
								dependencyField: 'PESSO.CODPESSO',
								fnValueSelector: (model) => model.ValCodpesso.value
							},
						],
					}, this),
					formTabs: new fieldControlClass.TabsControl({
						tabControlsIds: readonly([
							'PESSOSEPPSEUDPESSOS00',
							'PESSOSEPPSEUDPESSOS01',
						])
					}, this),
				},

				model: new FormViewModel(this, {
					callbacks: {
						onUpdate: this.onUpdate,
						setFormKey: this.setFormKey
					}
				}),

				groupFields: readonly([
					'PESSOSEPPSEUDNOVOGR02',
					'PESSOSEPPSEUDPESSOS00',
					'PESSOSEPPSEUDPESSOS01',
					'PESSOS01PSEUDNOVOGR06',
					'PESSOS01PSEUDNOVOGR03',
					'PESSOS01PSEUDNOVOGR04',
					'PESSOS01PSEUDNOVOGR05',
					'PESSOS01PSEUDNOVOGR07',
				]),

				tableFields: readonly([
					'PESSOS01PSEUDEVOLUCAO',
					'PESSOS01PSEUDCONTACTO',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Categ: {
						get ValCategoria() { return vm.model.TableCategCategory.value },
						set ValCategoria(value) { vm.model.TableCategCategory.updateValue(value) },
					},
					Cmpny: {
						get ValDesignat() { return vm.model.TableCmpnyDesignat.value },
						set ValDesignat(value) { vm.model.TableCmpnyDesignat.updateValue(value) },
					},
					Pesso: {
						get ValCodcateg() { return vm.model.ValCodcateg.value },
						set ValCodcateg(value) { vm.model.ValCodcateg.updateValue(value) },
						get ValCodcntry() { return vm.model.ValCodcntry.value },
						set ValCodcntry(value) { vm.model.ValCodcntry.updateValue(value) },
						get ValCodempre() { return vm.model.ValCodempre.value },
						set ValCodempre(value) { vm.model.ValCodempre.updateValue(value) },
						get ValCodpaise() { return vm.model.ValCodpaise.value },
						set ValCodpaise(value) { vm.model.ValCodpaise.updateValue(value) },
						get ValCodregia() { return vm.model.ValCodregia.value },
						set ValCodregia(value) { vm.model.ValCodregia.updateValue(value) },
						get ValDtnascim() { return vm.model.ValDtnascim.value },
						set ValDtnascim(value) { vm.model.ValDtnascim.updateValue(value) },
						get ValDtultcat() { return vm.model.ValDtultcat.value },
						set ValDtultcat(value) { vm.model.ValDtultcat.updateValue(value) },
						get ValEmail() { return vm.model.ValEmail.value },
						set ValEmail(value) { vm.model.ValEmail.updateValue(value) },
						get ValEmail2() { return vm.model.ValEmail2.value },
						set ValEmail2(value) { vm.model.ValEmail2.updateValue(value) },
						get ValExterna() { return vm.model.ValExterna.value },
						set ValExterna(value) { vm.model.ValExterna.updateValue(value) },
						get ValGender() { return vm.model.ValGender.value },
						set ValGender(value) { vm.model.ValGender.updateValue(value) },
						get ValIdfuncio() { return vm.model.ValIdfuncio.value },
						set ValIdfuncio(value) { vm.model.ValIdfuncio.updateValue(value) },
						get ValInterna() { return vm.model.ValInterna.value },
						set ValInterna(value) { vm.model.ValInterna.updateValue(value) },
						get ValName() { return vm.model.ValName.value },
						set ValName(value) { vm.model.ValName.updateValue(value) },
						get ValPhotogra() { return vm.model.ValPhotogra.value },
						set ValPhotogra(value) { vm.model.ValPhotogra.updateValue(value) },
						get ValTelephon() { return vm.model.ValTelephon.value },
						set ValTelephon(value) { vm.model.ValTelephon.updateValue(value) },
					},
					keys: {
						/** The primary key of the PESSO table */
						get pesso() { return vm.model.ValCodpesso },
						/** The foreign key to the CMPNY table */
						get cmpny() { return vm.model.ValCodempre },
						/** The foreign key to the CATEG table */
						get categ() { return vm.model.ValCodcateg },
						/** The foreign key to the CNTRY table */
						get cntry() { return vm.model.ValCodpaise },
						/** The foreign key to the PAIS1 table */
						get pais1() { return vm.model.ValCodcntry },
						/** The foreign key to the REGI1 table */
						get regi1() { return vm.model.ValCodregia },
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
// USE /[MANUAL GQT FORM_CODEJS PESSOSEP]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS PESSOSEP]/
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
// USE /[MANUAL GQT FORM_LOADED_JS PESSOSEP]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS PESSOSEP]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS PESSOSEP]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS PESSOSEP]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS PESSOSEP]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS PESSOSEP]/
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
// USE /[MANUAL GQT AFTER_DEL_JS PESSOSEP]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS PESSOSEP]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS PESSOSEP]/
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
// USE /[MANUAL GQT DLGUPDT PESSOSEP]/
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
// USE /[MANUAL GQT CTRLBLR PESSOSEP]/
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
// USE /[MANUAL GQT CTRLUPD PESSOSEP]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS PESSOSEP]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
			// Watchers for changes in the state of tabs.
			'controls.formTabs.selectedTab'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'formTabs',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
		}
	}
</script>
