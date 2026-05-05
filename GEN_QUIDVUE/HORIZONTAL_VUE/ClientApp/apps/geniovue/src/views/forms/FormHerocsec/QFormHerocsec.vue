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
			data-key="HEROCSEC"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.HEROCSECPSEUDFIELD001.isVisible || controls.HEROCSECPSEUDFIELD002.isVisible">
					<q-control-wrapper
						v-show="controls.HEROCSECPSEUDFIELD001.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-static-text"
							v-bind="controls.HEROCSECPSEUDFIELD001"
							v-on="controls.HEROCSECPSEUDFIELD001.handlers"
							:loading="controls.HEROCSECPSEUDFIELD001.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-static-text
								v-if="controls.HEROCSECPSEUDFIELD001.isVisible"
								id="HEROCSECPSEUDFIELD001"
								:size="controls.HEROCSECPSEUDFIELD001.size"
								:text="controls.HEROCSECPSEUDFIELD001.label" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.HEROCSECPSEUDFIELD002.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-static-text"
							v-bind="controls.HEROCSECPSEUDFIELD002"
							v-on="controls.HEROCSECPSEUDFIELD002.handlers"
							:loading="controls.HEROCSECPSEUDFIELD002.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-static-text
								v-if="controls.HEROCSECPSEUDFIELD002.isVisible"
								id="HEROCSECPSEUDFIELD002"
								:size="controls.HEROCSECPSEUDFIELD002.size"
								:text="controls.HEROCSECPSEUDFIELD002.label" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.HEROCSECPSEUDHEROTEXT.isVisible || controls.HEROCSECPSEUDHEROIMG_.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.HEROCSECPSEUDHEROTEXT.isVisible || controls.HEROCSECPSEUDHEROIMG_.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<q-tab-container
							id="q-tabs-HEROCSEC"
							v-bind="controls.formTabs.props"
							@tab-changed="controls.formTabs.selectTab($event)">
							<template #tab-panel>
								<section
									v-if="controls.HEROCSECPSEUDHEROTEXT.isVisible"
									v-show="controls.formTabs.selectedTab === 'HEROCSECPSEUDHEROTEXT'">
									<div
										id="HEROCSECPSEUDHEROTEXT"
										role="tabpanel"
										aria-labelledby="tab-container-HEROCSECPSEUDHEROTEXT">
										<q-row-container
											v-show="controls.HEROTEXTPSEUDNEWGRP01.isVisible"
											is-large>
											<q-control-wrapper
												v-show="controls.HEROTEXTPSEUDNEWGRP01.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<q-group-box-container
													id="HEROTEXTPSEUDNEWGRP01"
													class="c-groupbox--background"
													v-bind="controls.HEROTEXTPSEUDNEWGRP01"
													:is-visible="controls.HEROTEXTPSEUDNEWGRP01.isVisible">
													<!-- Start HEROTEXTPSEUDNEWGRP01 -->
													<q-row-container v-show="controls.HEROTEXTPSEUDFIELD002.isVisible">
														<q-control-wrapper
															v-show="controls.HEROTEXTPSEUDFIELD002.isVisible"
															class="${Vue.GetControlWrapperClass($controlsColumn)}">
															<base-input-structure
																class="i-static-text --c-text--color-secondary"
																v-bind="controls.HEROTEXTPSEUDFIELD002"
																v-on="controls.HEROTEXTPSEUDFIELD002.handlers"
																:loading="controls.HEROTEXTPSEUDFIELD002.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-static-text
																	v-if="controls.HEROTEXTPSEUDFIELD002.isVisible"
																	id="HEROTEXTPSEUDFIELD002"
																	:size="controls.HEROTEXTPSEUDFIELD002.size"
																	:text="controls.HEROTEXTPSEUDFIELD002.label"
																	supports-html />
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<q-row-container v-show="controls.HEROTEXTPSEUDFIELD001.isVisible">
														<q-control-wrapper
															v-show="controls.HEROTEXTPSEUDFIELD001.isVisible"
															class="${Vue.GetControlWrapperClass($controlsColumn)}">
															<base-input-structure
																class="i-static-text"
																v-bind="controls.HEROTEXTPSEUDFIELD001"
																v-on="controls.HEROTEXTPSEUDFIELD001.handlers"
																:loading="controls.HEROTEXTPSEUDFIELD001.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-static-text
																	v-if="controls.HEROTEXTPSEUDFIELD001.isVisible"
																	id="HEROTEXTPSEUDFIELD001"
																	:size="controls.HEROTEXTPSEUDFIELD001.size"
																	:text="controls.HEROTEXTPSEUDFIELD001.label"
																	supports-html />
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<q-row-container
														v-show="controls.HEROTEXTPSEUDFIELD003.isVisible"
														is-large>
														<q-control-wrapper
															v-show="controls.HEROTEXTPSEUDFIELD003.isVisible"
															class="${Vue.GetControlWrapperClass($controlsColumn)}">
															<base-input-structure
																class="i-static-text"
																v-bind="controls.HEROTEXTPSEUDFIELD003"
																v-on="controls.HEROTEXTPSEUDFIELD003.handlers"
																:loading="controls.HEROTEXTPSEUDFIELD003.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-static-text
																	v-if="controls.HEROTEXTPSEUDFIELD003.isVisible"
																	id="HEROTEXTPSEUDFIELD003"
																	:size="controls.HEROTEXTPSEUDFIELD003.size"
																	:text="controls.HEROTEXTPSEUDFIELD003.label"
																	supports-html />
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<q-row-container v-show="controls.HEROTEXTPSEUDHEROBUT_.isVisible">
														<q-control-wrapper
															v-show="controls.HEROTEXTPSEUDHEROBUT_.isVisible"
															class="${Vue.GetControlWrapperClass($controlsColumn)}">
															<base-input-structure
																class="i-button"
																v-bind="controls.HEROTEXTPSEUDHEROBUT_"
																v-on="controls.HEROTEXTPSEUDHEROBUT_.handlers"
																:loading="controls.HEROTEXTPSEUDHEROBUT_.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-button
																	v-if="controls.HEROTEXTPSEUDHEROBUT_.isVisible"
																	id="HEROTEXTPSEUDHEROBUT_"
																	:label="controls.HEROTEXTPSEUDHEROBUT_.label"
																	:disabled="controls.HEROTEXTPSEUDHEROBUT_.isBlocked"
																	@click="controls.HEROTEXTPSEUDHEROBUT_.action($event)">
																	<q-icon v-bind="controls.HEROTEXTPSEUDHEROBUT_.icon" />
																</q-button>
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<q-row-container v-show="controls.HEROTEXTPSEUDFIELD007.isVisible">
														<q-control-wrapper
															v-show="controls.HEROTEXTPSEUDFIELD007.isVisible"
															class="${Vue.GetControlWrapperClass($controlsColumn)}">
															<base-input-structure
																class="i-static-text"
																v-bind="controls.HEROTEXTPSEUDFIELD007"
																v-on="controls.HEROTEXTPSEUDFIELD007.handlers"
																:loading="controls.HEROTEXTPSEUDFIELD007.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-static-text
																	v-if="controls.HEROTEXTPSEUDFIELD007.isVisible"
																	id="HEROTEXTPSEUDFIELD007"
																	:size="controls.HEROTEXTPSEUDFIELD007.size"
																	:text="controls.HEROTEXTPSEUDFIELD007.label" />
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<!-- End HEROTEXTPSEUDNEWGRP01 -->
												</q-group-box-container>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.HEROTEXT__HERODESCRIP__HRDESCRIP.isVisible">
											<q-control-wrapper
												v-show="controls.HEROTEXT__HERODESCRIP__HRDESCRIP.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<base-input-structure
													class="i-textarea"
													v-bind="controls.HEROTEXT__HERODESCRIP__HRDESCRIP"
													v-on="controls.HEROTEXT__HERODESCRIP__HRDESCRIP.handlers"
													:loading="controls.HEROTEXT__HERODESCRIP__HRDESCRIP.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-area
														v-if="controls.HEROTEXT__HERODESCRIP__HRDESCRIP.isVisible"
														v-bind="controls.HEROTEXT__HERODESCRIP__HRDESCRIP.props"
														v-on="controls.HEROTEXT__HERODESCRIP__HRDESCRIP.handlers" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container
											v-show="controls.HEROTEXTPSEUDNEWGRP02.isVisible"
											is-large>
											<q-control-wrapper
												v-show="controls.HEROTEXTPSEUDNEWGRP02.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<q-group-box-container
													id="HEROTEXTPSEUDNEWGRP02"
													class="c-groupbox--background"
													v-bind="controls.HEROTEXTPSEUDNEWGRP02"
													:is-visible="controls.HEROTEXTPSEUDNEWGRP02.isVisible">
													<!-- Start HEROTEXTPSEUDNEWGRP02 -->
													<q-row-container v-show="controls.HEROTEXTPSEUDFIELD006.isVisible">
														<q-control-wrapper
															v-show="controls.HEROTEXTPSEUDFIELD006.isVisible"
															class="${Vue.GetControlWrapperClass($controlsColumn)}">
															<base-input-structure
																class="q-image"
																v-bind="controls.HEROTEXTPSEUDFIELD006"
																v-on="controls.HEROTEXTPSEUDFIELD006.handlers"
																:loading="controls.HEROTEXTPSEUDFIELD006.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-image
																	v-if="controls.HEROTEXTPSEUDFIELD006.isVisible"
																	v-bind="controls.HEROTEXTPSEUDFIELD006.props"
																	v-on="controls.HEROTEXTPSEUDFIELD006.handlers" />
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<q-row-container v-show="controls.HEROTEXTPSEUDFIELD004.isVisible">
														<q-control-wrapper
															v-show="controls.HEROTEXTPSEUDFIELD004.isVisible"
															class="${Vue.GetControlWrapperClass($controlsColumn)}">
															<base-input-structure
																class="i-static-text"
																v-bind="controls.HEROTEXTPSEUDFIELD004"
																v-on="controls.HEROTEXTPSEUDFIELD004.handlers"
																:loading="controls.HEROTEXTPSEUDFIELD004.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-static-text
																	v-if="controls.HEROTEXTPSEUDFIELD004.isVisible"
																	id="HEROTEXTPSEUDFIELD004"
																	:size="controls.HEROTEXTPSEUDFIELD004.size"
																	:text="controls.HEROTEXTPSEUDFIELD004.label"
																	supports-html />
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<q-row-container
														v-show="controls.HEROTEXTPSEUDFIELD005.isVisible"
														is-large>
														<q-control-wrapper
															v-show="controls.HEROTEXTPSEUDFIELD005.isVisible"
															class="${Vue.GetControlWrapperClass($controlsColumn)}">
															<base-input-structure
																class="i-static-text"
																v-bind="controls.HEROTEXTPSEUDFIELD005"
																v-on="controls.HEROTEXTPSEUDFIELD005.handlers"
																:loading="controls.HEROTEXTPSEUDFIELD005.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-static-text
																	v-if="controls.HEROTEXTPSEUDFIELD005.isVisible"
																	id="HEROTEXTPSEUDFIELD005"
																	:size="controls.HEROTEXTPSEUDFIELD005.size"
																	:text="controls.HEROTEXTPSEUDFIELD005.label"
																	supports-html />
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<!-- End HEROTEXTPSEUDNEWGRP02 -->
												</q-group-box-container>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.HEROTEXT__HERODESCRIP__HRDESCRIPICON.isVisible">
											<q-control-wrapper
												v-show="controls.HEROTEXT__HERODESCRIP__HRDESCRIPICON.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<base-input-structure
													class="i-textarea"
													v-bind="controls.HEROTEXT__HERODESCRIP__HRDESCRIPICON"
													v-on="controls.HEROTEXT__HERODESCRIP__HRDESCRIPICON.handlers"
													:loading="controls.HEROTEXT__HERODESCRIP__HRDESCRIPICON.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-area
														v-if="controls.HEROTEXT__HERODESCRIP__HRDESCRIPICON.isVisible"
														v-bind="controls.HEROTEXT__HERODESCRIP__HRDESCRIPICON.props"
														v-on="controls.HEROTEXT__HERODESCRIP__HRDESCRIPICON.handlers" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
									</div>
								</section>
								<section
									v-if="controls.HEROCSECPSEUDHEROIMG_.isVisible"
									v-show="controls.formTabs.selectedTab === 'HEROCSECPSEUDHEROIMG_'">
									<div
										id="HEROCSECPSEUDHEROIMG_"
										role="tabpanel"
										aria-labelledby="tab-container-HEROCSECPSEUDHEROIMG_">
										<q-row-container
											v-show="controls.HEROIMG_PSEUDNEWGRP02.isVisible"
											is-large>
											<q-control-wrapper
												v-show="controls.HEROIMG_PSEUDNEWGRP02.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<q-group-box-container
													id="HEROIMG_PSEUDNEWGRP02"
													v-bind="controls.HEROIMG_PSEUDNEWGRP02"
													:is-visible="controls.HEROIMG_PSEUDNEWGRP02.isVisible">
													<!-- Start HEROIMG_PSEUDNEWGRP02 -->
													<q-row-container v-show="controls.HEROIMG_PSEUDFIELD007.isVisible || controls.HEROIMG_PSEUDFIELD004.isVisible || controls.HEROIMG_PSEUDFIELD005.isVisible || controls.HEROIMG_PSEUDFIELD006.isVisible || controls.HEROIMG_PSEUDNEWGRP03.isVisible">
														<q-control-wrapper
															v-show="controls.HEROIMG_PSEUDFIELD007.isVisible || controls.HEROIMG_PSEUDFIELD004.isVisible || controls.HEROIMG_PSEUDFIELD005.isVisible || controls.HEROIMG_PSEUDFIELD006.isVisible || controls.HEROIMG_PSEUDNEWGRP03.isVisible"
															class="${Vue.GetControlWrapperClass($controlsColumn)}">
															<base-input-structure
																class="q-image"
																v-bind="controls.HEROIMG_PSEUDFIELD007"
																v-on="controls.HEROIMG_PSEUDFIELD007.handlers"
																:loading="controls.HEROIMG_PSEUDFIELD007.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-image
																	v-if="controls.HEROIMG_PSEUDFIELD007.isVisible"
																	v-bind="controls.HEROIMG_PSEUDFIELD007.props"
																	v-on="controls.HEROIMG_PSEUDFIELD007.handlers" />
															</base-input-structure>
															<base-input-structure
																class="i-static-text"
																v-bind="controls.HEROIMG_PSEUDFIELD004"
																v-on="controls.HEROIMG_PSEUDFIELD004.handlers"
																:loading="controls.HEROIMG_PSEUDFIELD004.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-static-text
																	v-if="controls.HEROIMG_PSEUDFIELD004.isVisible"
																	id="HEROIMG_PSEUDFIELD004"
																	:size="controls.HEROIMG_PSEUDFIELD004.size"
																	:text="controls.HEROIMG_PSEUDFIELD004.label"
																	supports-html />
															</base-input-structure>
															<base-input-structure
																class="i-static-text"
																v-bind="controls.HEROIMG_PSEUDFIELD005"
																v-on="controls.HEROIMG_PSEUDFIELD005.handlers"
																:loading="controls.HEROIMG_PSEUDFIELD005.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-static-text
																	v-if="controls.HEROIMG_PSEUDFIELD005.isVisible"
																	id="HEROIMG_PSEUDFIELD005"
																	:size="controls.HEROIMG_PSEUDFIELD005.size"
																	:text="controls.HEROIMG_PSEUDFIELD005.label"
																	supports-html />
															</base-input-structure>
															<base-input-structure
																class="i-static-text"
																v-bind="controls.HEROIMG_PSEUDFIELD006"
																v-on="controls.HEROIMG_PSEUDFIELD006.handlers"
																:loading="controls.HEROIMG_PSEUDFIELD006.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-static-text
																	v-if="controls.HEROIMG_PSEUDFIELD006.isVisible"
																	id="HEROIMG_PSEUDFIELD006"
																	:size="controls.HEROIMG_PSEUDFIELD006.size"
																	:text="controls.HEROIMG_PSEUDFIELD006.label"
																	supports-html />
															</base-input-structure>
															<q-group-box-container
																id="HEROIMG_PSEUDNEWGRP03"
																v-bind="controls.HEROIMG_PSEUDNEWGRP03"
																:is-visible="controls.HEROIMG_PSEUDNEWGRP03.isVisible">
																<!-- Start HEROIMG_PSEUDNEWGRP03 -->
																<q-row-container v-show="controls.HEROIMG_PSEUDFIELD008.isVisible">
																	<q-control-wrapper
																		v-show="controls.HEROIMG_PSEUDFIELD008.isVisible"
																		class="${Vue.GetControlWrapperClass($controlsColumn)}">
																		<base-input-structure
																			class="i-static-text"
																			v-bind="controls.HEROIMG_PSEUDFIELD008"
																			v-on="controls.HEROIMG_PSEUDFIELD008.handlers"
																			:loading="controls.HEROIMG_PSEUDFIELD008.props.loading"
																			:reporting-mode-on="reportingModeCAV"
																			:suggestion-mode-on="suggestionModeOn">
																			<q-static-text
																				v-if="controls.HEROIMG_PSEUDFIELD008.isVisible"
																				id="HEROIMG_PSEUDFIELD008"
																				:size="controls.HEROIMG_PSEUDFIELD008.size"
																				:text="controls.HEROIMG_PSEUDFIELD008.label" />
																		</base-input-structure>
																	</q-control-wrapper>
																</q-row-container>
																<q-row-container v-show="controls.HEROIMG_PSEUDFIELD009.isVisible">
																	<q-control-wrapper
																		v-show="controls.HEROIMG_PSEUDFIELD009.isVisible"
																		class="${Vue.GetControlWrapperClass($controlsColumn)}">
																		<base-input-structure
																			class="q-image"
																			v-bind="controls.HEROIMG_PSEUDFIELD009"
																			v-on="controls.HEROIMG_PSEUDFIELD009.handlers"
																			:loading="controls.HEROIMG_PSEUDFIELD009.props.loading"
																			:reporting-mode-on="reportingModeCAV"
																			:suggestion-mode-on="suggestionModeOn">
																			<q-image
																				v-if="controls.HEROIMG_PSEUDFIELD009.isVisible"
																				v-bind="controls.HEROIMG_PSEUDFIELD009.props"
																				v-on="controls.HEROIMG_PSEUDFIELD009.handlers" />
																		</base-input-structure>
																	</q-control-wrapper>
																</q-row-container>
																<!-- End HEROIMG_PSEUDNEWGRP03 -->
															</q-group-box-container>
														</q-control-wrapper>
													</q-row-container>
													<!-- End HEROIMG_PSEUDNEWGRP02 -->
												</q-group-box-container>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.HEROIMG__HERODESCRIP__HRDESCRIPMOD.isVisible">
											<q-control-wrapper
												v-show="controls.HEROIMG__HERODESCRIP__HRDESCRIPMOD.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<base-input-structure
													class="i-textarea"
													v-bind="controls.HEROIMG__HERODESCRIP__HRDESCRIPMOD"
													v-on="controls.HEROIMG__HERODESCRIP__HRDESCRIPMOD.handlers"
													:loading="controls.HEROIMG__HERODESCRIP__HRDESCRIPMOD.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-area
														v-if="controls.HEROIMG__HERODESCRIP__HRDESCRIPMOD.isVisible"
														v-bind="controls.HEROIMG__HERODESCRIP__HRDESCRIPMOD.props"
														v-on="controls.HEROIMG__HERODESCRIP__HRDESCRIPMOD.handlers" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container
											v-show="controls.HEROIMG_PSEUDNEWGRP01.isVisible"
											is-large>
											<q-control-wrapper
												v-show="controls.HEROIMG_PSEUDNEWGRP01.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<q-group-box-container
													id="HEROIMG_PSEUDNEWGRP01"
													v-bind="controls.HEROIMG_PSEUDNEWGRP01"
													:is-visible="controls.HEROIMG_PSEUDNEWGRP01.isVisible">
													<!-- Start HEROIMG_PSEUDNEWGRP01 -->
													<q-row-container v-show="controls.HEROIMG_PSEUDFIELD002.isVisible || controls.HEROIMG_PSEUDFIELD001.isVisible || controls.HEROIMG_PSEUDFIELD003.isVisible">
														<q-control-wrapper
															v-show="controls.HEROIMG_PSEUDFIELD002.isVisible"
															class="${Vue.GetControlWrapperClass($controlsColumn)}">
															<base-input-structure
																class="q-image"
																v-bind="controls.HEROIMG_PSEUDFIELD002"
																v-on="controls.HEROIMG_PSEUDFIELD002.handlers"
																:loading="controls.HEROIMG_PSEUDFIELD002.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-image
																	v-if="controls.HEROIMG_PSEUDFIELD002.isVisible"
																	v-bind="controls.HEROIMG_PSEUDFIELD002.props"
																	v-on="controls.HEROIMG_PSEUDFIELD002.handlers" />
															</base-input-structure>
														</q-control-wrapper>
														<q-control-wrapper
															v-show="controls.HEROIMG_PSEUDFIELD001.isVisible || controls.HEROIMG_PSEUDFIELD003.isVisible"
															class="${Vue.GetControlWrapperClass($controlsColumn)}">
															<base-input-structure
																class="i-static-text"
																v-bind="controls.HEROIMG_PSEUDFIELD001"
																v-on="controls.HEROIMG_PSEUDFIELD001.handlers"
																:loading="controls.HEROIMG_PSEUDFIELD001.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-static-text
																	v-if="controls.HEROIMG_PSEUDFIELD001.isVisible"
																	id="HEROIMG_PSEUDFIELD001"
																	:size="controls.HEROIMG_PSEUDFIELD001.size"
																	:text="controls.HEROIMG_PSEUDFIELD001.label"
																	supports-html />
															</base-input-structure>
															<base-input-structure
																class="i-static-text"
																v-bind="controls.HEROIMG_PSEUDFIELD003"
																v-on="controls.HEROIMG_PSEUDFIELD003.handlers"
																:loading="controls.HEROIMG_PSEUDFIELD003.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-static-text
																	v-if="controls.HEROIMG_PSEUDFIELD003.isVisible"
																	id="HEROIMG_PSEUDFIELD003"
																	:size="controls.HEROIMG_PSEUDFIELD003.size"
																	:text="controls.HEROIMG_PSEUDFIELD003.label"
																	supports-html />
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<!-- End HEROIMG_PSEUDNEWGRP01 -->
												</q-group-box-container>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.HEROIMG__HERODESCRIP__HRDESCRIPIMAGE.isVisible">
											<q-control-wrapper
												v-show="controls.HEROIMG__HERODESCRIP__HRDESCRIPIMAGE.isVisible"
												class="${Vue.GetControlWrapperClass($controlsColumn)}">
												<base-input-structure
													class="i-textarea"
													v-bind="controls.HEROIMG__HERODESCRIP__HRDESCRIPIMAGE"
													v-on="controls.HEROIMG__HERODESCRIP__HRDESCRIPIMAGE.handlers"
													:loading="controls.HEROIMG__HERODESCRIP__HRDESCRIPIMAGE.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-area
														v-if="controls.HEROIMG__HERODESCRIP__HRDESCRIPIMAGE.isVisible"
														v-bind="controls.HEROIMG__HERODESCRIP__HRDESCRIPIMAGE.props"
														v-on="controls.HEROIMG__HERODESCRIP__HRDESCRIPIMAGE.handlers" />
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

	import FormViewModel from './QFormHerocsecViewModel.js'

	const requiredTextResources = ['QFormHerocsec', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS HEROCSEC]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormHerocsec',

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
					name: 'HEROCSEC',
					location: 'form-HEROCSEC',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormHerocsec', false),

				interfaceMetadata: {
					id: 'QFormHerocsec', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'HEROCSEC',
					route: 'form-HEROCSEC',
					area: 'HERODESCRIP',
					primaryKey: 'ValCodherodescrip',
					designation: computed(() => this.Resources.CALLOUT_HERO_SECTION42962),
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
					HEROCSECPSEUDFIELD001: new fieldControlClass.BaseControl({
						id: 'HEROCSECPSEUDFIELD001',
						name: 'FIELD001',
						size: 'xxlarge',
						hasLabel: false,
						label: computed(() => this.Resources.A_CALLOUT_OR_HERO_SE15877),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controlLimits: [
						],
					}, this),
					HEROCSECPSEUDFIELD002: new fieldControlClass.BaseControl({
						id: 'HEROCSECPSEUDFIELD002',
						name: 'FIELD002',
						size: 'xxlarge',
						hasLabel: false,
						label: computed(() => this.Resources.OF_A_WEBPAGE_DESIGNE28791),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controlLimits: [
						],
					}, this),
					HEROCSECPSEUDHEROTEXT: new fieldControlClass.TabControl({
						id: 'HEROCSECPSEUDHEROTEXT',
						name: 'HEROTEXT',
						size: 'block',
						label: computed(() => this.Resources.TEXT_ONLY40143),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['HEROTEXTPSEUDNEWGRP01', 'HEROTEXT__HERODESCRIP__HRDESCRIP', 'HEROTEXTPSEUDNEWGRP02', 'HEROTEXT__HERODESCRIP__HRDESCRIPICON'],
						controlLimits: [
						],
					}, this),
					HEROCSECPSEUDHEROIMG_: new fieldControlClass.TabControl({
						id: 'HEROCSECPSEUDHEROIMG_',
						name: 'HEROIMG',
						size: 'small',
						label: computed(() => this.Resources.WITH_IMAGE62012),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['HEROIMG_PSEUDNEWGRP02', 'HEROIMG__HERODESCRIP__HRDESCRIPMOD', 'HEROIMG_PSEUDNEWGRP01', 'HEROIMG__HERODESCRIP__HRDESCRIPIMAGE'],
						controlLimits: [
						],
					}, this),
					HEROTEXTPSEUDNEWGRP01: new fieldControlClass.GroupControl({
						id: 'HEROTEXTPSEUDNEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'HEROCSECPSEUDHEROTEXT',
						isCollapsible: false,
						anchored: false,
						directChildren: ['HEROTEXTPSEUDFIELD002', 'HEROTEXTPSEUDFIELD001', 'HEROTEXTPSEUDFIELD003', 'HEROTEXTPSEUDHEROBUT_', 'HEROTEXTPSEUDFIELD007'],
						controlLimits: [
						],
					}, this),
					HEROTEXTPSEUDFIELD002: new fieldControlClass.BaseControl({
						id: 'HEROTEXTPSEUDFIELD002',
						name: 'FIELD002',
						size: 'medium',
						hasLabel: false,
						label: computed(() => this.Resources._P__SMALL__STRONG_SU48244),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'HEROTEXTPSEUDNEWGRP01',
						tab: 'HEROCSECPSEUDHEROTEXT',
						supportsHtml: true,
						controlLimits: [
						],
					}, this),
					HEROTEXTPSEUDFIELD001: new fieldControlClass.BaseControl({
						id: 'HEROTEXTPSEUDFIELD001',
						name: 'FIELD001',
						size: 'large',
						hasLabel: false,
						label: computed(() => this.Resources._H2__STRONG_TITLE__S49715),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'HEROTEXTPSEUDNEWGRP01',
						tab: 'HEROCSECPSEUDHEROTEXT',
						supportsHtml: true,
						controlLimits: [
						],
					}, this),
					HEROTEXTPSEUDFIELD003: new fieldControlClass.BaseControl({
						id: 'HEROTEXTPSEUDFIELD003',
						name: 'FIELD003',
						size: 'block',
						hasLabel: false,
						label: computed(() => this.Resources._P__LOREM_IPSUM_DOLO40395),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'HEROTEXTPSEUDNEWGRP01',
						tab: 'HEROCSECPSEUDHEROTEXT',
						supportsHtml: true,
						controlLimits: [
						],
					}, this),
					HEROTEXTPSEUDHEROBUT_: new fieldControlClass.ButtonControl({
						id: 'HEROTEXTPSEUDHEROBUT_',
						name: 'HEROBUT',
						size: 'mini',
						hasLabel: false,
						label: computed(() => this.Resources.ACTION41832),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'HEROTEXTPSEUDNEWGRP01',
						tab: 'HEROCSECPSEUDHEROTEXT',
						icon: {
							icon: 'ADPATTERS',
							type: 'font',
							role: 'presentation',
						},
						// eslint-disable-next-line
						action: (event) => {
							let btnAction = () => {
								const params = {
									isControlled: false,
									extraData: JSON.stringify(event)
								}
								vm.$router.push({ name: 'menu-EQUIP_Menu_HEROBUT', params })
							}
							btnAction()
						},
						controlLimits: [
						],
					}, this),
					HEROTEXTPSEUDFIELD007: new fieldControlClass.BaseControl({
						id: 'HEROTEXTPSEUDFIELD007',
						name: 'FIELD007',
						size: 'large',
						hasLabel: false,
						label: computed(() => this.Resources.UPDATED_IN_DD_MM_YYY28375),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'HEROTEXTPSEUDNEWGRP01',
						tab: 'HEROCSECPSEUDHEROTEXT',
						controlLimits: [
						],
					}, this),
					HEROTEXT__HERODESCRIP__HRDESCRIP: new fieldControlClass.MultilineStringControl({
						modelField: 'ValHrdescrip',
						valueChangeEvent: 'fieldChange:herodescrip.hrdescrip',
						id: 'HEROTEXT__HERODESCRIP__HRDESCRIP',
						name: 'HRDESCRIP',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESCRIPTION07383),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'HEROCSECPSEUDHEROTEXT',
						rows: 3,
						cols: 80,
						controlLimits: [
						],
						blockWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: [FormMode]!=[FormModeNew]
								return vm.formInfo.mode!==vm.formModes.new
							},
							dependencyEvents: ['form-mode-change'],
							isServerRecalc: false,
						},
					}, this),
					HEROTEXTPSEUDNEWGRP02: new fieldControlClass.GroupControl({
						id: 'HEROTEXTPSEUDNEWGRP02',
						name: 'NEWGRP02',
						size: 'block',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'HEROCSECPSEUDHEROTEXT',
						isCollapsible: false,
						anchored: false,
						directChildren: ['HEROTEXTPSEUDFIELD006', 'HEROTEXTPSEUDFIELD004', 'HEROTEXTPSEUDFIELD005'],
						controlLimits: [
						],
					}, this),
					HEROTEXTPSEUDFIELD006: new fieldControlClass.ImageControl({
						id: 'HEROTEXTPSEUDFIELD006',
						name: 'FIELD006',
						size: 'mini',
						hasLabel: false,
						label: computed(() => this.Resources.NEW_DATA_DISPLAY21423),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'HEROTEXTPSEUDNEWGRP02',
						tab: 'HEROCSECPSEUDHEROTEXT',
						icon: {
							icon: computed(() => `${this.$app.resourcesPath}Dt_input_tag.png?v=3637`),
							type: 'img',
						},
						height: 0,
						width: 150,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.NEW_DATA_DISPLAY21423)),
						isStatic: true,
						controlLimits: [
						],
					}, this),
					HEROTEXTPSEUDFIELD004: new fieldControlClass.BaseControl({
						id: 'HEROTEXTPSEUDFIELD004',
						name: 'FIELD004',
						size: 'xlarge',
						hasLabel: false,
						label: computed(() => this.Resources._H2__STRONG_TITLE__S49715),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'HEROTEXTPSEUDNEWGRP02',
						tab: 'HEROCSECPSEUDHEROTEXT',
						supportsHtml: true,
						controlLimits: [
						],
					}, this),
					HEROTEXTPSEUDFIELD005: new fieldControlClass.BaseControl({
						id: 'HEROTEXTPSEUDFIELD005',
						name: 'FIELD005',
						size: 'block',
						hasLabel: false,
						label: computed(() => this.Resources._P__LOREM_IPSUM_DOLO40395),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'HEROTEXTPSEUDNEWGRP02',
						tab: 'HEROCSECPSEUDHEROTEXT',
						supportsHtml: true,
						controlLimits: [
						],
					}, this),
					HEROTEXT__HERODESCRIP__HRDESCRIPICON: new fieldControlClass.MultilineStringControl({
						modelField: 'ValHrdescripicon',
						valueChangeEvent: 'fieldChange:herodescrip.hrdescripicon',
						id: 'HEROTEXT__HERODESCRIP__HRDESCRIPICON',
						name: 'HRDESCRIPICON',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESCRIPTION07383),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'HEROCSECPSEUDHEROTEXT',
						rows: 3,
						cols: 80,
						controlLimits: [
						],
						blockWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: [FormMode]!=[FormModeNew]
								return vm.formInfo.mode!==vm.formModes.new
							},
							dependencyEvents: ['form-mode-change'],
							isServerRecalc: false,
						},
					}, this),
					HEROIMG_PSEUDNEWGRP02: new fieldControlClass.GroupControl({
						id: 'HEROIMG_PSEUDNEWGRP02',
						name: 'NEWGRP02',
						size: 'block',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'HEROCSECPSEUDHEROIMG_',
						isCollapsible: false,
						anchored: false,
						directChildren: ['HEROIMG_PSEUDFIELD007', 'HEROIMG_PSEUDFIELD004', 'HEROIMG_PSEUDFIELD005', 'HEROIMG_PSEUDFIELD006', 'HEROIMG_PSEUDNEWGRP03'],
						controlLimits: [
						],
					}, this),
					HEROIMG_PSEUDFIELD007: new fieldControlClass.ImageControl({
						id: 'HEROIMG_PSEUDFIELD007',
						name: 'FIELD007',
						size: 'medium',
						hasLabel: false,
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'HEROIMG_PSEUDNEWGRP02',
						tab: 'HEROCSECPSEUDHEROIMG_',
						icon: {
							icon: computed(() => `${this.$app.resourcesPath}Screenshot 2026-03-02 144033.png?v=3637`),
							type: 'img',
						},
						height: 0,
						width: 150,
						isStatic: true,
						controlLimits: [
						],
					}, this),
					HEROIMG_PSEUDFIELD004: new fieldControlClass.BaseControl({
						id: 'HEROIMG_PSEUDFIELD004',
						name: 'FIELD004',
						size: 'xlarge',
						hasLabel: false,
						label: computed(() => this.Resources.MODULE_P__STRONG_WMS06167),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'HEROIMG_PSEUDNEWGRP02',
						tab: 'HEROCSECPSEUDHEROIMG_',
						supportsHtml: true,
						controlLimits: [
						],
					}, this),
					HEROIMG_PSEUDFIELD005: new fieldControlClass.BaseControl({
						id: 'HEROIMG_PSEUDFIELD005',
						name: 'FIELD005',
						size: 'xxlarge',
						hasLabel: false,
						label: computed(() => this.Resources.MODULE_DESIGNATION_P37376),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'HEROIMG_PSEUDNEWGRP02',
						tab: 'HEROCSECPSEUDHEROIMG_',
						supportsHtml: true,
						controlLimits: [
						],
					}, this),
					HEROIMG_PSEUDFIELD006: new fieldControlClass.BaseControl({
						id: 'HEROIMG_PSEUDFIELD006',
						name: 'FIELD006',
						size: 'xlarge',
						hasLabel: false,
						label: computed(() => this.Resources.ORDER_P__STRONG_721_01133),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'HEROIMG_PSEUDNEWGRP02',
						tab: 'HEROCSECPSEUDHEROIMG_',
						supportsHtml: true,
						controlLimits: [
						],
					}, this),
					HEROIMG_PSEUDNEWGRP03: new fieldControlClass.GroupControl({
						id: 'HEROIMG_PSEUDNEWGRP03',
						name: 'NEWGRP03',
						size: 'medium',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'HEROIMG_PSEUDNEWGRP02',
						tab: 'HEROCSECPSEUDHEROIMG_',
						isCollapsible: false,
						anchored: false,
						directChildren: ['HEROIMG_PSEUDFIELD008', 'HEROIMG_PSEUDFIELD009'],
						controlLimits: [
						],
					}, this),
					HEROIMG_PSEUDFIELD008: new fieldControlClass.BaseControl({
						id: 'HEROIMG_PSEUDFIELD008',
						name: 'FIELD008',
						size: 'medium',
						hasLabel: false,
						label: computed(() => this.Resources.MENU_ITEM_TYPE47040),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'HEROIMG_PSEUDNEWGRP03',
						tab: 'HEROCSECPSEUDHEROIMG_',
						controlLimits: [
						],
					}, this),
					HEROIMG_PSEUDFIELD009: new fieldControlClass.ImageControl({
						id: 'HEROIMG_PSEUDFIELD009',
						name: 'FIELD009',
						size: 'medium',
						hasLabel: false,
						label: computed(() => this.Resources.MENU_ITEM_TYPE47040),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'HEROIMG_PSEUDNEWGRP03',
						tab: 'HEROCSECPSEUDHEROIMG_',
						icon: {
							icon: computed(() => `${this.$app.resourcesPath}Screenshot 2026-03-02 145357.png?v=3637`),
							type: 'img',
						},
						height: 0,
						width: 150,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.MENU_ITEM_TYPE47040)),
						isStatic: true,
						controlLimits: [
						],
					}, this),
					HEROIMG__HERODESCRIP__HRDESCRIPMOD: new fieldControlClass.MultilineStringControl({
						modelField: 'ValHrdescripmod',
						valueChangeEvent: 'fieldChange:herodescrip.hrdescripmod',
						id: 'HEROIMG__HERODESCRIP__HRDESCRIPMOD',
						name: 'HRDESCRIPMOD',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESCRIPTION07383),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'HEROCSECPSEUDHEROIMG_',
						rows: 3,
						cols: 80,
						controlLimits: [
						],
						blockWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: [FormMode]!=[FormModeNew]
								return vm.formInfo.mode!==vm.formModes.new
							},
							dependencyEvents: ['form-mode-change'],
							isServerRecalc: false,
						},
					}, this),
					HEROIMG_PSEUDNEWGRP01: new fieldControlClass.GroupControl({
						id: 'HEROIMG_PSEUDNEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'HEROCSECPSEUDHEROIMG_',
						isCollapsible: false,
						anchored: false,
						directChildren: ['HEROIMG_PSEUDFIELD002', 'HEROIMG_PSEUDFIELD001', 'HEROIMG_PSEUDFIELD003'],
						controlLimits: [
						],
					}, this),
					HEROIMG_PSEUDFIELD002: new fieldControlClass.ImageControl({
						id: 'HEROIMG_PSEUDFIELD002',
						name: 'FIELD002',
						size: 'mini',
						hasLabel: false,
						label: computed(() => this.Resources.STATIC_IMAGE_TEST01106),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.center),
						container: 'HEROIMG_PSEUDNEWGRP01',
						tab: 'HEROCSECPSEUDHEROIMG_',
						icon: {
							icon: computed(() => `${this.$app.resourcesPath}office-man.png?v=3637`),
							type: 'img',
						},
						height: 0,
						width: 150,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.STATIC_IMAGE_TEST01106)),
						isStatic: true,
						controlLimits: [
						],
					}, this),
					HEROIMG_PSEUDFIELD001: new fieldControlClass.BaseControl({
						id: 'HEROIMG_PSEUDFIELD001',
						name: 'FIELD001',
						size: 'small',
						hasLabel: false,
						label: computed(() => this.Resources.EMPLOYEE_N__P__STRON02496),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'HEROIMG_PSEUDNEWGRP01',
						tab: 'HEROCSECPSEUDHEROIMG_',
						supportsHtml: true,
						controlLimits: [
						],
					}, this),
					HEROIMG_PSEUDFIELD003: new fieldControlClass.BaseControl({
						id: 'HEROIMG_PSEUDFIELD003',
						name: 'FIELD003',
						size: 'small',
						hasLabel: false,
						label: computed(() => this.Resources.NAME_P__STRONG_JOHN_42007),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'HEROIMG_PSEUDNEWGRP01',
						tab: 'HEROCSECPSEUDHEROIMG_',
						supportsHtml: true,
						controlLimits: [
						],
					}, this),
					HEROIMG__HERODESCRIP__HRDESCRIPIMAGE: new fieldControlClass.MultilineStringControl({
						modelField: 'ValHrdescripimage',
						valueChangeEvent: 'fieldChange:herodescrip.hrdescripimage',
						id: 'HEROIMG__HERODESCRIP__HRDESCRIPIMAGE',
						name: 'HRDESCRIPIMAGE',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESCRIPTION07383),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'HEROCSECPSEUDHEROIMG_',
						rows: 3,
						cols: 80,
						controlLimits: [
						],
						blockWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: [FormMode]!=[FormModeNew]
								return vm.formInfo.mode!==vm.formModes.new
							},
							dependencyEvents: ['form-mode-change'],
							isServerRecalc: false,
						},
					}, this),
					formTabs: new fieldControlClass.TabsControl({
						tabControlsIds: readonly([
							'HEROCSECPSEUDHEROTEXT',
							'HEROCSECPSEUDHEROIMG_',
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
					'HEROCSECPSEUDHEROTEXT',
					'HEROTEXTPSEUDNEWGRP01',
					'HEROTEXTPSEUDNEWGRP02',
					'HEROCSECPSEUDHEROIMG_',
					'HEROIMG_PSEUDNEWGRP02',
					'HEROIMG_PSEUDNEWGRP03',
					'HEROIMG_PSEUDNEWGRP01',
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Herodescrip: {
						get ValHrdescrip() { return vm.model.ValHrdescrip.value },
						set ValHrdescrip(value) { vm.model.ValHrdescrip.updateValue(value) },
						get ValHrdescripicon() { return vm.model.ValHrdescripicon.value },
						set ValHrdescripicon(value) { vm.model.ValHrdescripicon.updateValue(value) },
						get ValHrdescripimage() { return vm.model.ValHrdescripimage.value },
						set ValHrdescripimage(value) { vm.model.ValHrdescripimage.updateValue(value) },
						get ValHrdescripmod() { return vm.model.ValHrdescripmod.value },
						set ValHrdescripmod(value) { vm.model.ValHrdescripmod.updateValue(value) },
					},
					keys: {
						/** The primary key of the HERODESCRIP table */
						get herodescrip() { return vm.model.ValCodherodescrip },
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
// USE /[MANUAL GQT FORM_CODEJS HEROCSEC]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS HEROCSEC]/
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
// USE /[MANUAL GQT FORM_LOADED_JS HEROCSEC]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS HEROCSEC]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS HEROCSEC]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS HEROCSEC]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS HEROCSEC]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS HEROCSEC]/
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
// USE /[MANUAL GQT AFTER_DEL_JS HEROCSEC]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS HEROCSEC]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS HEROCSEC]/
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
// USE /[MANUAL GQT DLGUPDT HEROCSEC]/
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
// USE /[MANUAL GQT CTRLBLR HEROCSEC]/
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
// USE /[MANUAL GQT CTRLUPD HEROCSEC]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS HEROCSEC]/
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
