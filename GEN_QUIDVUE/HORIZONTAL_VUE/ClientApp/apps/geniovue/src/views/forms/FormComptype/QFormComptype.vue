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
			data-key="COMPTYPE"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container
					v-show="controls.COMPTYPEPSEUDNEWGRP01.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.COMPTYPEPSEUDNEWGRP01.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<q-group-box-container
							id="COMPTYPEPSEUDNEWGRP01"
							class="c-groupbox--background"
							v-bind="controls.COMPTYPEPSEUDNEWGRP01"
							:is-visible="controls.COMPTYPEPSEUDNEWGRP01.isVisible">
							<!-- Start COMPTYPEPSEUDNEWGRP01 -->
							<q-row-container v-show="controls.COMPTYPECOMPOCOMPTYPE.isVisible">
								<q-control-wrapper
									v-show="controls.COMPTYPECOMPOCOMPTYPE.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-text"
										v-bind="controls.COMPTYPECOMPOCOMPTYPE"
										v-on="controls.COMPTYPECOMPOCOMPTYPE.handlers"
										:loading="controls.COMPTYPECOMPOCOMPTYPE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.COMPTYPECOMPOCOMPTYPE.props"
											@blur="onBlur(controls.COMPTYPECOMPOCOMPTYPE, model.ValComptype.value)"
											@change="model.ValComptype.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.COMPTYPECOMPOCOMPICON.isVisible">
								<q-control-wrapper
									v-show="controls.COMPTYPECOMPOCOMPICON.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-text"
										v-bind="controls.COMPTYPECOMPOCOMPICON"
										v-on="controls.COMPTYPECOMPOCOMPICON.handlers"
										:loading="controls.COMPTYPECOMPOCOMPICON.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.COMPTYPECOMPOCOMPICON.isVisible"
											v-bind="controls.COMPTYPECOMPOCOMPICON.props" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.COMPTYPECOMPOCOMPDESC.isVisible">
								<q-control-wrapper
									v-show="controls.COMPTYPECOMPOCOMPDESC.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-textarea"
										v-bind="controls.COMPTYPECOMPOCOMPDESC"
										v-on="controls.COMPTYPECOMPOCOMPDESC.handlers"
										:loading="controls.COMPTYPECOMPOCOMPDESC.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-area
											v-if="controls.COMPTYPECOMPOCOMPDESC.isVisible"
											v-bind="controls.COMPTYPECOMPOCOMPDESC.props"
											v-on="controls.COMPTYPECOMPOCOMPDESC.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End COMPTYPEPSEUDNEWGRP01 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.COMPTYPEPSEUDCOMPTAB_.isVisible || controls.COMPTYPEPSEUDTAB_____.isVisible || controls.COMPTYPEPSEUDC_USAGE_.isVisible || controls.COMPTYPEPSEUDCACESSI_.isVisible || controls.COMPTYPE__PSEUD__CONFIGCOMP.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.COMPTYPEPSEUDCOMPTAB_.isVisible || controls.COMPTYPEPSEUDTAB_____.isVisible || controls.COMPTYPEPSEUDC_USAGE_.isVisible || controls.COMPTYPEPSEUDCACESSI_.isVisible || controls.COMPTYPE__PSEUD__CONFIGCOMP.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<q-tab-container
							id="q-tabs-COMPTYPE"
							v-bind="controls.formTabs.props"
							@tab-changed="controls.formTabs.selectTab($event)">
							<template #tab-panel>
								<section
									v-if="controls.COMPTYPEPSEUDCOMPTAB_.isVisible"
									v-show="controls.formTabs.selectedTab === 'COMPTYPEPSEUDCOMPTAB_'">
									<div
										id="COMPTYPEPSEUDCOMPTAB_"
										role="tabpanel"
										aria-labelledby="tab-container-COMPTYPEPSEUDCOMPTAB_">
										<q-row-container v-show="controls.COMPTAB_COMPCCOMPCLAS.isVisible">
											<q-control-wrapper
												v-show="controls.COMPTAB_COMPCCOMPCLAS.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<base-input-structure
													class="i-text"
													v-bind="controls.COMPTAB_COMPCCOMPCLAS"
													v-on="controls.COMPTAB_COMPCCOMPCLAS.handlers"
													:loading="controls.COMPTAB_COMPCCOMPCLAS.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-lookup
														v-if="controls.COMPTAB_COMPCCOMPCLAS.isVisible"
														v-bind="controls.COMPTAB_COMPCCOMPCLAS.props"
														v-on="controls.COMPTAB_COMPCCOMPCLAS.handlers" />
													<q-see-more-comptab-compccompclas
														v-if="controls.COMPTAB_COMPCCOMPCLAS.seeMoreIsVisible"
														v-bind="controls.COMPTAB_COMPCCOMPCLAS.seeMoreParams"
														v-on="controls.COMPTAB_COMPCCOMPCLAS.handlers" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.COMPTAB_COMPOCOMPTYPE.isVisible">
											<q-control-wrapper
												v-show="controls.COMPTAB_COMPOCOMPTYPE.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<base-input-structure
													class="i-text"
													v-bind="controls.COMPTAB_COMPOCOMPTYPE"
													v-on="controls.COMPTAB_COMPOCOMPTYPE.handlers"
													:loading="controls.COMPTAB_COMPOCOMPTYPE.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-field
														v-bind="controls.COMPTAB_COMPOCOMPTYPE.props"
														@blur="onBlur(controls.COMPTAB_COMPOCOMPTYPE, model.ValComptype.value)"
														@change="model.ValComptype.fnUpdateValueOnChange" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.COMPTAB_COMPOCDATATYP.isVisible">
											<q-control-wrapper
												v-show="controls.COMPTAB_COMPOCDATATYP.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<base-input-structure
													class="i-text"
													v-bind="controls.COMPTAB_COMPOCDATATYP"
													v-on="controls.COMPTAB_COMPOCDATATYP.handlers"
													:loading="controls.COMPTAB_COMPOCDATATYP.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-field
														v-bind="controls.COMPTAB_COMPOCDATATYP.props"
														@blur="onBlur(controls.COMPTAB_COMPOCDATATYP, model.ValCdatatyp.value)"
														@change="model.ValCdatatyp.fnUpdateValueOnChange" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.COMPTAB_COMPORELEASE_.isVisible || controls.COMPTAB_COMPOMVC_____.isVisible || controls.COMPTAB_COMPOVUEMVC__.isVisible">
											<q-control-wrapper
												v-show="controls.COMPTAB_COMPORELEASE_.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<base-input-structure
													class="i-text"
													v-bind="controls.COMPTAB_COMPORELEASE_"
													v-on="controls.COMPTAB_COMPORELEASE_.handlers"
													:loading="controls.COMPTAB_COMPORELEASE_.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-field
														v-bind="controls.COMPTAB_COMPORELEASE_.props"
														@blur="onBlur(controls.COMPTAB_COMPORELEASE_, model.ValRelease.value)"
														@change="model.ValRelease.fnUpdateValueOnChange" />
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.COMPTAB_COMPOMVC_____.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<base-input-structure
													class="i-checkbox"
													v-bind="controls.COMPTAB_COMPOMVC_____"
													v-on="controls.COMPTAB_COMPOMVC_____.handlers"
													:loading="controls.COMPTAB_COMPOMVC_____.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<template #label>
														<q-checkbox-input
															v-if="controls.COMPTAB_COMPOMVC_____.isVisible"
															v-bind="controls.COMPTAB_COMPOMVC_____.props"
															v-on="controls.COMPTAB_COMPOMVC_____.handlers" />
													</template>
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.COMPTAB_COMPOVUEMVC__.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<base-input-structure
													class="i-checkbox"
													v-bind="controls.COMPTAB_COMPOVUEMVC__"
													v-on="controls.COMPTAB_COMPOVUEMVC__.handlers"
													:loading="controls.COMPTAB_COMPOVUEMVC__.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<template #label>
														<q-checkbox-input
															v-if="controls.COMPTAB_COMPOVUEMVC__.isVisible"
															v-bind="controls.COMPTAB_COMPOVUEMVC__.props"
															v-on="controls.COMPTAB_COMPOVUEMVC__.handlers" />
													</template>
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container
											v-show="controls.COMPTAB_COMPOPREVIEW_.isVisible"
											is-large>
											<q-control-wrapper
												v-show="controls.COMPTAB_COMPOPREVIEW_.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<base-input-structure
													class="q-image"
													v-bind="controls.COMPTAB_COMPOPREVIEW_"
													v-on="controls.COMPTAB_COMPOPREVIEW_.handlers"
													:loading="controls.COMPTAB_COMPOPREVIEW_.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-image
														v-if="controls.COMPTAB_COMPOPREVIEW_.isVisible"
														v-bind="controls.COMPTAB_COMPOPREVIEW_.props"
														v-on="controls.COMPTAB_COMPOPREVIEW_.handlers" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.COMPTAB__PSEUD__STORYBOOK.isVisible">
											<q-control-wrapper
												v-show="controls.COMPTAB__PSEUD__STORYBOOK.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<base-input-structure
													class="i-button"
													v-bind="controls.COMPTAB__PSEUD__STORYBOOK"
													v-on="controls.COMPTAB__PSEUD__STORYBOOK.handlers"
													:loading="controls.COMPTAB__PSEUD__STORYBOOK.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-button
														v-if="controls.COMPTAB__PSEUD__STORYBOOK.isVisible"
														id="COMPTAB__PSEUD__STORYBOOK"
														:label="controls.COMPTAB__PSEUD__STORYBOOK.label"
														:disabled="controls.COMPTAB__PSEUD__STORYBOOK.isBlocked"
														@click="controls.COMPTAB__PSEUD__STORYBOOK.action($event)">
														<q-icon v-bind="controls.COMPTAB__PSEUD__STORYBOOK.icon" />
													</q-button>
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.COMPTAB_PSEUDBEHAVIOR.isVisible">
											<q-control-wrapper
												v-show="controls.COMPTAB_PSEUDBEHAVIOR.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<q-table
													v-show="controls.COMPTAB_PSEUDBEHAVIOR.isVisible"
													v-bind="controls.COMPTAB_PSEUDBEHAVIOR"
													v-on="controls.COMPTAB_PSEUDBEHAVIOR.handlers" />
												<q-table-extra-extension
													:list-ctrl="controls.COMPTAB_PSEUDBEHAVIOR"
													v-on="controls.COMPTAB_PSEUDBEHAVIOR.handlers" />
											</q-control-wrapper>
										</q-row-container>
									</div>
								</section>
								<section
									v-if="controls.COMPTYPEPSEUDTAB_____.isVisible"
									v-show="controls.formTabs.selectedTab === 'COMPTYPEPSEUDTAB_____'">
									<div
										id="COMPTYPEPSEUDTAB_____"
										role="tabpanel"
										aria-labelledby="tab-container-COMPTYPEPSEUDTAB_____">
										<q-row-container v-show="controls.TAB_____PSEUDVARIANTS.isVisible">
											<q-control-wrapper
												v-show="controls.TAB_____PSEUDVARIANTS.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<q-table
													v-show="controls.TAB_____PSEUDVARIANTS.isVisible"
													v-bind="controls.TAB_____PSEUDVARIANTS"
													v-on="controls.TAB_____PSEUDVARIANTS.handlers" />
												<q-table-extra-extension
													:list-ctrl="controls.TAB_____PSEUDVARIANTS"
													v-on="controls.TAB_____PSEUDVARIANTS.handlers" />
											</q-control-wrapper>
										</q-row-container>
									</div>
								</section>
								<section
									v-if="controls.COMPTYPEPSEUDC_USAGE_.isVisible"
									v-show="controls.formTabs.selectedTab === 'COMPTYPEPSEUDC_USAGE_'">
									<div
										id="COMPTYPEPSEUDC_USAGE_"
										role="tabpanel"
										aria-labelledby="tab-container-COMPTYPEPSEUDC_USAGE_">
										<q-row-container v-show="controls.C_USAGE_COMPOWUSE____.isVisible">
											<q-control-wrapper
												v-show="controls.C_USAGE_COMPOWUSE____.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<base-input-structure
													class="i-textarea"
													v-bind="controls.C_USAGE_COMPOWUSE____"
													v-on="controls.C_USAGE_COMPOWUSE____.handlers"
													:loading="controls.C_USAGE_COMPOWUSE____.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-area
														v-if="controls.C_USAGE_COMPOWUSE____.isVisible"
														v-bind="controls.C_USAGE_COMPOWUSE____.props"
														v-on="controls.C_USAGE_COMPOWUSE____.handlers" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.C_USAGE_COMPOWNUSE___.isVisible">
											<q-control-wrapper
												v-show="controls.C_USAGE_COMPOWNUSE___.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<base-input-structure
													class="i-textarea"
													v-bind="controls.C_USAGE_COMPOWNUSE___"
													v-on="controls.C_USAGE_COMPOWNUSE___.handlers"
													:loading="controls.C_USAGE_COMPOWNUSE___.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-area
														v-if="controls.C_USAGE_COMPOWNUSE___.isVisible"
														v-bind="controls.C_USAGE_COMPOWNUSE___.props"
														v-on="controls.C_USAGE_COMPOWNUSE___.handlers" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container
											v-show="controls.C_USAGE_PSEUDNEWGRP01.isVisible"
											is-large>
											<q-control-wrapper
												v-show="controls.C_USAGE_PSEUDNEWGRP01.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<q-group-box-container
													id="C_USAGE_PSEUDNEWGRP01"
													v-bind="controls.C_USAGE_PSEUDNEWGRP01"
													:is-visible="controls.C_USAGE_PSEUDNEWGRP01.isVisible">
													<!-- Start C_USAGE_PSEUDNEWGRP01 -->
													<q-row-container v-show="controls.C_USAGE_PSEUDDEMOCOMP.isVisible">
														<q-control-wrapper
															v-show="controls.C_USAGE_PSEUDDEMOCOMP.isVisible"
															class="${Vue.GetControlWrapperClass($controlsColumn)}">
															<base-input-structure
																class="i-button"
																v-bind="controls.C_USAGE_PSEUDDEMOCOMP"
																v-on="controls.C_USAGE_PSEUDDEMOCOMP.handlers"
																:loading="controls.C_USAGE_PSEUDDEMOCOMP.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-button
																	v-if="controls.C_USAGE_PSEUDDEMOCOMP.isVisible"
																	id="C_USAGE_PSEUDDEMOCOMP"
																	:label="controls.C_USAGE_PSEUDDEMOCOMP.label"
																	:disabled="controls.C_USAGE_PSEUDDEMOCOMP.isBlocked"
																	@click="controls.C_USAGE_PSEUDDEMOCOMP.action($event)">
																	<q-icon v-bind="controls.C_USAGE_PSEUDDEMOCOMP.icon" />
																</q-button>
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<!-- End C_USAGE_PSEUDNEWGRP01 -->
												</q-group-box-container>
											</q-control-wrapper>
										</q-row-container>
									</div>
								</section>
								<section
									v-if="controls.COMPTYPEPSEUDCACESSI_.isVisible"
									v-show="controls.formTabs.selectedTab === 'COMPTYPEPSEUDCACESSI_'">
									<div
										id="COMPTYPEPSEUDCACESSI_"
										role="tabpanel"
										aria-labelledby="tab-container-COMPTYPEPSEUDCACESSI_">
										<q-row-container v-show="controls.CACESSI_COMPOACCESSIB.isVisible">
											<q-control-wrapper
												v-show="controls.CACESSI_COMPOACCESSIB.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<base-input-structure
													class="i-textarea"
													v-bind="controls.CACESSI_COMPOACCESSIB"
													v-on="controls.CACESSI_COMPOACCESSIB.handlers"
													:loading="controls.CACESSI_COMPOACCESSIB.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-area
														v-if="controls.CACESSI_COMPOACCESSIB.isVisible"
														v-bind="controls.CACESSI_COMPOACCESSIB.props"
														v-on="controls.CACESSI_COMPOACCESSIB.handlers" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
									</div>
								</section>
								<section
									v-if="controls.COMPTYPE__PSEUD__CONFIGCOMP.isVisible"
									v-show="controls.formTabs.selectedTab === 'COMPTYPE__PSEUD__CONFIGCOMP'">
									<div
										id="COMPTYPE__PSEUD__CONFIGCOMP"
										role="tabpanel"
										aria-labelledby="tab-container-COMPTYPE__PSEUD__CONFIGCOMP">
										<q-row-container v-show="controls.CONFIGCOMP__COMPO__RELEASELOGIC.isVisible">
											<q-control-wrapper
												v-show="controls.CONFIGCOMP__COMPO__RELEASELOGIC.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<base-input-structure
													class="i-checkbox"
													v-bind="controls.CONFIGCOMP__COMPO__RELEASELOGIC"
													v-on="controls.CONFIGCOMP__COMPO__RELEASELOGIC.handlers"
													:loading="controls.CONFIGCOMP__COMPO__RELEASELOGIC.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<template #label>
														<q-checkbox-input
															v-if="controls.CONFIGCOMP__COMPO__RELEASELOGIC.isVisible"
															v-bind="controls.CONFIGCOMP__COMPO__RELEASELOGIC.props"
															v-on="controls.CONFIGCOMP__COMPO__RELEASELOGIC.handlers" />
													</template>
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CONFIGCOMP__COMPO__WEBLINK.isVisible">
											<q-control-wrapper
												v-show="controls.CONFIGCOMP__COMPO__WEBLINK.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<base-input-structure
													class="i-text"
													v-bind="controls.CONFIGCOMP__COMPO__WEBLINK"
													v-on="controls.CONFIGCOMP__COMPO__WEBLINK.handlers"
													:loading="controls.CONFIGCOMP__COMPO__WEBLINK.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-field
														v-bind="controls.CONFIGCOMP__COMPO__WEBLINK.props"
														@blur="onBlur(controls.CONFIGCOMP__COMPO__WEBLINK, model.ValWeblink.value)"
														@change="model.ValWeblink.fnUpdateValueOnChange" />
												</base-input-structure>
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

	import FormViewModel from './QFormComptypeViewModel.js'

	const requiredTextResources = ['QFormComptype', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS COMPTYPE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormComptype',

		components: {
			QSeeMoreComptabCompccompclas: defineAsyncComponent(() => import('@/views/forms/FormComptype/dbedits/ComptabCompccompclasSeeMore.vue')),
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
					name: 'COMPTYPE',
					location: 'form-COMPTYPE',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormComptype', false),

				interfaceMetadata: {
					id: 'QFormComptype', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'COMPTYPE',
					route: 'form-COMPTYPE',
					area: 'COMPO',
					primaryKey: 'ValCodcompo',
					designation: computed(() => genericFunctions.formatString(this.Resources._COMPO__COMPTYPE_37230, vm.model.ValComptype.displayValue)),
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
					COMPTYPEPSEUDNEWGRP01: new fieldControlClass.GroupControl({
						id: 'COMPTYPEPSEUDNEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['COMPTYPECOMPOCOMPTYPE', 'COMPTYPECOMPOCOMPICON', 'COMPTYPECOMPOCOMPDESC'],
						controlLimits: [
						],
					}, this),
					COMPTYPECOMPOCOMPTYPE: new fieldControlClass.StringControl({
						modelField: 'ValComptype',
						valueChangeEvent: 'fieldChange:compo.comptype',
						id: 'COMPTYPECOMPOCOMPTYPE',
						name: 'COMPTYPE',
						size: 'xxlarge',
						label: computed(() => this.Resources.COMPONENT_TYPE41163),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'COMPTYPEPSEUDNEWGRP01',
						maxLength: 50,
						labelId: 'label_COMPTYPECOMPOCOMPTYPE',
						controlLimits: [
						],
					}, this),
					COMPTYPECOMPOCOMPICON: new fieldControlClass.ArrayNumberControl({
						modelField: 'ValCompicon',
						valueChangeEvent: 'fieldChange:compo.compicon',
						id: 'COMPTYPECOMPOCOMPICON',
						name: 'COMPICON',
						size: 'xxlarge',
						label: computed(() => this.Resources.COMPONENT_CLASS57908),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'COMPTYPEPSEUDNEWGRP01',
						isFormulaBlocked: true,
						maxIntegers: 1,
						maxDecimals: 0,
						arrayName: 'componenticons',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					COMPTYPECOMPOCOMPDESC: new fieldControlClass.MultilineStringControl({
						modelField: 'ValCompdesc',
						valueChangeEvent: 'fieldChange:compo.compdesc',
						id: 'COMPTYPECOMPOCOMPDESC',
						name: 'COMPDESC',
						size: 'xxlarge',
						label: computed(() => this.Resources.COMPONENT_DESCRIPTIO08871),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'COMPTYPEPSEUDNEWGRP01',
						rows: 5,
						cols: 50,
						controlLimits: [
						],
					}, this),
					COMPTYPEPSEUDCOMPTAB_: new fieldControlClass.TabControl({
						id: 'COMPTYPEPSEUDCOMPTAB_',
						name: 'COMPTAB',
						size: 'small',
						label: computed(() => this.Resources.OVERVIEW09715),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['COMPTAB_COMPCCOMPCLAS', 'COMPTAB_COMPOCOMPTYPE', 'COMPTAB_COMPOCDATATYP', 'COMPTAB_COMPORELEASE_', 'COMPTAB_COMPOMVC_____', 'COMPTAB_COMPOVUEMVC__', 'COMPTAB_COMPOPREVIEW_', 'COMPTAB__PSEUD__STORYBOOK', 'COMPTAB_PSEUDBEHAVIOR'],
						controlLimits: [
						],
					}, this),
					COMPTYPEPSEUDTAB_____: new fieldControlClass.TabControl({
						id: 'COMPTYPEPSEUDTAB_____',
						name: 'TAB',
						size: 'block',
						label: computed(() => this.Resources.OPTIONS14459),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['TAB_____PSEUDVARIANTS'],
						controlLimits: [
						],
					}, this),
					COMPTYPEPSEUDC_USAGE_: new fieldControlClass.TabControl({
						id: 'COMPTYPEPSEUDC_USAGE_',
						name: 'C_USAGE',
						size: 'block',
						label: computed(() => this.Resources.USAGE21575),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['C_USAGE_COMPOWUSE____', 'C_USAGE_COMPOWNUSE___', 'C_USAGE_PSEUDNEWGRP01'],
						controlLimits: [
						],
					}, this),
					COMPTYPEPSEUDCACESSI_: new fieldControlClass.TabControl({
						id: 'COMPTYPEPSEUDCACESSI_',
						name: 'CACESSI',
						size: 'block',
						label: computed(() => this.Resources.ACCESSIBILITY21548),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['CACESSI_COMPOACCESSIB'],
						controlLimits: [
						],
					}, this),
					COMPTYPE__PSEUD__CONFIGCOMP: new fieldControlClass.TabControl({
						id: 'COMPTYPE__PSEUD__CONFIGCOMP',
						name: 'CONFIGCOMP',
						size: 'medium',
						label: computed(() => this.Resources.CONFIGURATIONS33663),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['CONFIGCOMP__COMPO__RELEASELOGIC', 'CONFIGCOMP__COMPO__WEBLINK'],
						controlLimits: [
						],
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								return netAPI.postData(
									'Compo',
									'COMPTYPE_COMPTYPE__PSEUD__CONFIGCOMP_ShowWhen',
									this.serverObjModel,
									undefined,
									undefined,
									undefined,
									this.navigationId)
							},
							dependencyEvents: [],
							isServerRecalc: false,
						},
					}, this),
					COMPTAB_COMPCCOMPCLAS: new fieldControlClass.LookupControl({
						modelField: 'TableCompcCompclas',
						valueChangeEvent: 'fieldChange:compc.compclas',
						id: 'COMPTAB_COMPCCOMPCLAS',
						name: 'COMPCLAS',
						size: 'xxlarge',
						label: computed(() => this.Resources.COMPONENTS_CLASS59339),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'COMPTYPEPSEUDCOMPTAB_',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodcompc',
							dependencyEvent: 'fieldChange:compo.codcompc'
						},
						dependentFields: () => ({
							set 'compc.codcompc'(value) { vm.model.ValCodcompc.updateValue(value) },
							set 'compc.compclas'(value) { vm.model.TableCompcCompclas.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					COMPTAB_COMPOCOMPTYPE: new fieldControlClass.StringControl({
						modelField: 'ValComptype',
						valueChangeEvent: 'fieldChange:compo.comptype',
						id: 'COMPTAB_COMPOCOMPTYPE',
						name: 'COMPTYPE',
						size: 'xxlarge',
						label: computed(() => this.Resources.COMPONENT_TYPE41163),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'COMPTYPEPSEUDCOMPTAB_',
						maxLength: 50,
						labelId: 'label_COMPTAB_COMPOCOMPTYPE',
						controlLimits: [
						],
					}, this),
					COMPTAB_COMPOCDATATYP: new fieldControlClass.StringControl({
						modelField: 'ValCdatatyp',
						valueChangeEvent: 'fieldChange:compo.cdatatyp',
						id: 'COMPTAB_COMPOCDATATYP',
						name: 'CDATATYP',
						size: 'xxlarge',
						label: computed(() => this.Resources.DATA_TYPE47159),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'COMPTYPEPSEUDCOMPTAB_',
						maxLength: 50,
						labelId: 'label_COMPTAB_COMPOCDATATYP',
						controlLimits: [
						],
					}, this),
					COMPTAB_COMPORELEASE_: new fieldControlClass.StringControl({
						modelField: 'ValRelease',
						valueChangeEvent: 'fieldChange:compo.release',
						id: 'COMPTAB_COMPORELEASE_',
						name: 'RELEASE',
						size: 'xlarge',
						label: computed(() => this.Resources.RELEASE62976),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'COMPTYPEPSEUDCOMPTAB_',
						maxLength: 50,
						labelId: 'label_COMPTAB_COMPORELEASE_',
						controlLimits: [
						],
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: [COMPO->RELEASELOGIC]== 1
								return (this.ValReleaselogic.value ? 1 : 0)===1
							},
							dependencyEvents: ['fieldChange:compo.releaselogic'],
							isServerRecalc: false,
						},
					}, this),
					COMPTAB_COMPOMVC_____: new fieldControlClass.BooleanControl({
						modelField: 'ValMvc',
						valueChangeEvent: 'fieldChange:compo.mvc',
						id: 'COMPTAB_COMPOMVC_____',
						name: 'MVC',
						size: 'xxlarge',
						label: computed(() => this.Resources.MVC48022),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						tab: 'COMPTYPEPSEUDCOMPTAB_',
						controlLimits: [
						],
					}, this),
					COMPTAB_COMPOVUEMVC__: new fieldControlClass.BooleanControl({
						modelField: 'ValVuemvc',
						valueChangeEvent: 'fieldChange:compo.vuemvc',
						id: 'COMPTAB_COMPOVUEMVC__',
						name: 'VUEMVC',
						size: 'xxlarge',
						label: computed(() => this.Resources.VUE05393),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						tab: 'COMPTYPEPSEUDCOMPTAB_',
						controlLimits: [
						],
					}, this),
					COMPTAB_COMPOPREVIEW_: new fieldControlClass.ImageControl({
						modelField: 'ValPreview',
						valueChangeEvent: 'fieldChange:compo.preview',
						id: 'COMPTAB_COMPOPREVIEW_',
						name: 'PREVIEW',
						size: 'block',
						label: computed(() => this.Resources.PREVIEW45357),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'COMPTYPEPSEUDCOMPTAB_',
						height: 400,
						width: 600,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PREVIEW45357)),
						maxFileSize: 10485760, // In bytes.
						maxFileSizeLabel: '10 MB',
						controlLimits: [
						],
					}, this),
					COMPTAB__PSEUD__STORYBOOK: new fieldControlClass.ButtonControl({
						id: 'COMPTAB__PSEUD__STORYBOOK',
						name: 'STORYBOOK',
						size: 'small',
						hasLabel: false,
						label: computed(() => this.Resources.STORYBOOK40103),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'COMPTYPEPSEUDCOMPTAB_',
						icon: {
							icon: computed(() => `${this.$app.resourcesPath}Storybook-icon.png?v=3637`),
							type: 'img',
							role: 'presentation',
						},
						// eslint-disable-next-line
						action: (event) => {
							let btnAction = () => {
								vm.Comptab_ValOpenurl_BR_OPENURL(vm.primaryKeyValue)
							}
							let options = {
								form: 'COMPTYPE',
								callback: btnAction
							}
							vm.$eventHub.emit('form-apply', options)
						},
						controlLimits: [
						],
					}, this),
					COMPTAB_PSEUDBEHAVIOR: new fieldControlClass.TableListControl({
						id: 'COMPTAB_PSEUDBEHAVIOR',
						name: 'BEHAVIOR',
						size: 'xxlarge',
						label: computed(() => this.Resources.COMPONENT_BEHAVIOUR62822),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'COMPTYPEPSEUDCOMPTAB_',
						controller: 'COMPO',
						action: 'Comptab_ValBehavior',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Compo.ValCodcompc',
								area: 'COMPO',
								field: 'CODCOMPC',
								label: computed(() => this.Resources.COMPONENTS_CLASS59339),
								dataLength: 8,
								scrollData: 8,
								isVisible: false,
								pkColumn: 'ValCodcompo',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValCompint',
								area: 'COMPB',
								field: 'COMPINT',
								label: computed(() => this.Resources.INTERACTION46097),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValCmpbehav',
								area: 'COMPB',
								field: 'CMPBEHAV',
								label: computed(() => this.Resources.BEHAVIOR47966),
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValBehavior',
							serverMode: true,
							pkColumn: 'ValCodcompb',
							tableAlias: 'COMPB',
							tableNamePlural: computed(() => this.Resources.COMPONENT_BEHAVIOR49688),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.COMPONENT_BEHAVIOUR62822),
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
										formName: 'COMPBEH',
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
										formName: 'COMPBEH',
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
										formName: 'COMPBEH',
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
										formName: 'COMPBEH',
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
										formName: 'COMPBEH',
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
								id: 'RCA__COMPBEH',
								name: '_COMPBEH',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'COMPBEH',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'COMPBEH': {
									fnKeySelector: (row) => row.Fields.ValCodcompb,
									isPopup: true
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-COMPO', 'changed-COMPB'],
						uuid: 'Comptab_ValBehavior',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'compo'],
								dependencyEvents: ['fieldChange:compo.codcompo'],
								dependencyField: 'COMPO.CODCOMPO',
								fnValueSelector: (model) => model.ValCodcompo.value
							},
						],
					}, this),
					TAB_____PSEUDVARIANTS: new fieldControlClass.TableListControl({
						id: 'TAB_____PSEUDVARIANTS',
						name: 'VARIANTS',
						size: 'xxlarge',
						label: computed(() => this.Resources.VARIANTS_OPTIONS16637),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'COMPTYPEPSEUDTAB_____',
						controller: 'COMPO',
						action: 'Tab_ValVariants',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValCompvar',
								area: 'COMPV',
								field: 'COMPVAR',
								label: computed(() => this.Resources.VARIANT06375),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValVaridesc',
								area: 'COMPV',
								field: 'VARIDESC',
								label: computed(() => this.Resources.DESCRIPTION07383),
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValVariants',
							serverMode: true,
							pkColumn: 'ValCodcompv',
							tableAlias: 'COMPV',
							tableNamePlural: computed(() => this.Resources.VARIANTS59281),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.VARIANTS_OPTIONS16637),
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
										formName: 'OPTTABLE',
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
										formName: 'OPTTABLE',
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
										formName: 'OPTTABLE',
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
										formName: 'OPTTABLE',
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
										formName: 'OPTTABLE',
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
								id: 'RCA__OPTTABLE',
								name: '_OPTTABLE',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'OPTTABLE',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'OPTTABLE': {
									fnKeySelector: (row) => row.Fields.ValCodcompv,
									isPopup: true
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-COMPO', 'changed-COMPV'],
						uuid: 'Tab_ValVariants',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'compo'],
								dependencyEvents: ['fieldChange:compo.codcompo'],
								dependencyField: 'COMPO.CODCOMPO',
								fnValueSelector: (model) => model.ValCodcompo.value
							},
						],
					}, this),
					C_USAGE_COMPOWUSE____: new fieldControlClass.MultilineStringControl({
						modelField: 'ValWuse',
						valueChangeEvent: 'fieldChange:compo.wuse',
						id: 'C_USAGE_COMPOWUSE____',
						name: 'WUSE',
						size: 'xxlarge',
						label: computed(() => this.Resources.WHEN_TO_USE63699),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'COMPTYPEPSEUDC_USAGE_',
						rows: 10,
						cols: 30,
						controlLimits: [
						],
					}, this),
					C_USAGE_COMPOWNUSE___: new fieldControlClass.MultilineStringControl({
						modelField: 'ValWnuse',
						valueChangeEvent: 'fieldChange:compo.wnuse',
						id: 'C_USAGE_COMPOWNUSE___',
						name: 'WNUSE',
						size: 'xxlarge',
						label: computed(() => this.Resources.WHEN_NOT_TO_USE63828),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'COMPTYPEPSEUDC_USAGE_',
						rows: 10,
						cols: 30,
						controlLimits: [
						],
					}, this),
					C_USAGE_PSEUDNEWGRP01: new fieldControlClass.GroupControl({
						id: 'C_USAGE_PSEUDNEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: computed(() => this.Resources.EXAMPLES50382),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'COMPTYPEPSEUDC_USAGE_',
						isCollapsible: false,
						anchored: false,
						directChildren: ['C_USAGE_PSEUDDEMOCOMP'],
						controlLimits: [
						],
					}, this),
					C_USAGE_PSEUDDEMOCOMP: new fieldControlClass.ButtonControl({
						id: 'C_USAGE_PSEUDDEMOCOMP',
						name: 'DEMOCOMP',
						size: 'mini',
						hasLabel: false,
						label: computed(() => this.Resources.DEMO_107013),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'C_USAGE_PSEUDNEWGRP01',
						tab: 'COMPTYPEPSEUDC_USAGE_',
						icon: {
							icon: 'average',
							type: 'svg',
							role: 'presentation',
						},
						// eslint-disable-next-line
						action: (event) => {
							let btnAction = () => {
								window.open('https://ui.quidgest.pt/?path=/docs/components-accordion--docs', '_blank')
							}
							btnAction()
						},
						controlLimits: [
						],
					}, this),
					CACESSI_COMPOACCESSIB: new fieldControlClass.MultilineStringControl({
						modelField: 'ValAccessib',
						valueChangeEvent: 'fieldChange:compo.accessib',
						id: 'CACESSI_COMPOACCESSIB',
						name: 'ACCESSIB',
						size: 'xxlarge',
						label: computed(() => this.Resources.ACCESSIBILTY_COMPLIA06353),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'COMPTYPEPSEUDCACESSI_',
						rows: 15,
						cols: 30,
						controlLimits: [
						],
					}, this),
					CONFIGCOMP__COMPO__RELEASELOGIC: new fieldControlClass.BooleanControl({
						modelField: 'ValReleaselogic',
						valueChangeEvent: 'fieldChange:compo.releaselogic',
						id: 'CONFIGCOMP__COMPO__RELEASELOGIC',
						name: 'RELEASELOGIC',
						size: 'xxlarge',
						label: computed(() => this.Resources.SHOW_RELEASE_FIELD40778),
						placeholder: '',
						labelPosition: computed(() => this.$app.layout.CheckboxLabelAlignment),
						tab: 'COMPTYPE__PSEUD__CONFIGCOMP',
						controlLimits: [
						],
					}, this),
					CONFIGCOMP__COMPO__WEBLINK: new fieldControlClass.StringControl({
						modelField: 'ValWeblink',
						valueChangeEvent: 'fieldChange:compo.weblink',
						id: 'CONFIGCOMP__COMPO__WEBLINK',
						name: 'WEBLINK',
						size: 'xxlarge',
						label: computed(() => this.Resources.STORYBOOK_LINK23554),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'COMPTYPE__PSEUD__CONFIGCOMP',
						maxLength: 100,
						labelId: 'label_CONFIGCOMP__COMPO__WEBLINK',
						controlLimits: [
						],
					}, this),
					formTabs: new fieldControlClass.TabsControl({
						tabControlsIds: readonly([
							'COMPTYPEPSEUDCOMPTAB_',
							'COMPTYPEPSEUDTAB_____',
							'COMPTYPEPSEUDC_USAGE_',
							'COMPTYPEPSEUDCACESSI_',
							'COMPTYPE__PSEUD__CONFIGCOMP',
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
					'COMPTYPEPSEUDNEWGRP01',
					'COMPTYPEPSEUDCOMPTAB_',
					'COMPTYPEPSEUDTAB_____',
					'COMPTYPEPSEUDC_USAGE_',
					'C_USAGE_PSEUDNEWGRP01',
					'COMPTYPEPSEUDCACESSI_',
					'COMPTYPE__PSEUD__CONFIGCOMP',
				]),

				tableFields: readonly([
					'COMPTAB_PSEUDBEHAVIOR',
					'TAB_____PSEUDVARIANTS',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Compc: {
						get ValCompclas() { return vm.model.TableCompcCompclas.value },
						set ValCompclas(value) { vm.model.TableCompcCompclas.updateValue(value) },
					},
					Compo: {
						get ValAccessib() { return vm.model.ValAccessib.value },
						set ValAccessib(value) { vm.model.ValAccessib.updateValue(value) },
						get ValCdatatyp() { return vm.model.ValCdatatyp.value },
						set ValCdatatyp(value) { vm.model.ValCdatatyp.updateValue(value) },
						get ValCodcompc() { return vm.model.ValCodcompc.value },
						set ValCodcompc(value) { vm.model.ValCodcompc.updateValue(value) },
						get ValCompdesc() { return vm.model.ValCompdesc.value },
						set ValCompdesc(value) { vm.model.ValCompdesc.updateValue(value) },
						get ValCompicon() { return vm.model.ValCompicon.value },
						set ValCompicon(value) { vm.model.ValCompicon.updateValue(value) },
						get ValComptype() { return vm.model.ValComptype.value },
						set ValComptype(value) { vm.model.ValComptype.updateValue(value) },
						get ValMvc() { return vm.model.ValMvc.value },
						set ValMvc(value) { vm.model.ValMvc.updateValue(value) },
						get ValPreview() { return vm.model.ValPreview.value },
						set ValPreview(value) { vm.model.ValPreview.updateValue(value) },
						get ValRelease() { return vm.model.ValRelease.value },
						set ValRelease(value) { vm.model.ValRelease.updateValue(value) },
						get ValReleaselogic() { return vm.model.ValReleaselogic.value },
						set ValReleaselogic(value) { vm.model.ValReleaselogic.updateValue(value) },
						get ValVuemvc() { return vm.model.ValVuemvc.value },
						set ValVuemvc(value) { vm.model.ValVuemvc.updateValue(value) },
						get ValWeblink() { return vm.model.ValWeblink.value },
						set ValWeblink(value) { vm.model.ValWeblink.updateValue(value) },
						get ValWnuse() { return vm.model.ValWnuse.value },
						set ValWnuse(value) { vm.model.ValWnuse.updateValue(value) },
						get ValWuse() { return vm.model.ValWuse.value },
						set ValWuse(value) { vm.model.ValWuse.updateValue(value) },
					},
					keys: {
						/** The primary key of the COMPO table */
						get compo() { return vm.model.ValCodcompo },
						/** The foreign key to the COMPC table */
						get compc() { return vm.model.ValCodcompc },
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
// USE /[MANUAL GQT FORM_CODEJS COMPTYPE]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS COMPTYPE]/
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
// USE /[MANUAL GQT FORM_LOADED_JS COMPTYPE]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS COMPTYPE]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS COMPTYPE]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS COMPTYPE]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS COMPTYPE]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS COMPTYPE]/
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
// USE /[MANUAL GQT AFTER_DEL_JS COMPTYPE]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS COMPTYPE]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS COMPTYPE]/
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
// USE /[MANUAL GQT DLGUPDT COMPTYPE]/
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
// USE /[MANUAL GQT CTRLBLR COMPTYPE]/
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
// USE /[MANUAL GQT CTRLUPD COMPTYPE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},

			// eslint-disable-next-line
			Comptab_BR_OPENURL(jsonRouteValues)
			{
				this.$eventTracker.addTrace({
					origin: 'Routine OPENURL',
					message: 'Start of execution of the manual routine'
				})

/* eslint-disable indent, vue/html-indent, vue/script-indent */
//Platform: VUE | Type: VIEW_MANUAL_ROUTINE | Module: GQT | Parameter: OPENURL | File:  | Order: 0
//BEGIN_MANUALCODE_CODMANUA:4b177ef1-c7c6-4351-bc8d-0eb171177896
                    if (qApi.emptyC(this.model.ValWeblink.value) === 0)
                        window.open(this.model.ValWeblink.value, '_blank')
//END_MANUALCODE
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			Comptab_ValOpenurl_BR_OPENURL(id, fnAfterConfirm)
			{
				const jsonRouteValues = { id }
				jsonRouteValues.action = 'Comptab_ValOpenurl_BR_OPENURL'
				this.Comptab_BR_OPENURL(jsonRouteValues, fnAfterConfirm)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS COMPTYPE]/
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
