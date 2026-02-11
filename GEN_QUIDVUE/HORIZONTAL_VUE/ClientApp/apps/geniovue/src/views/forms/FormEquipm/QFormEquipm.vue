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
			data-key="EQUIPM"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.EQUIPM__PSEUDNOVOGR01.isVisible">
					<q-col
						v-if="controls.EQUIPM__PSEUDNOVOGR01.isVisible"
						cols="auto">
						<q-group-box-container
							v-if="controls.EQUIPM__PSEUDNOVOGR01.isVisible"
							id="EQUIPM__PSEUDNOVOGR01"
							v-bind="controls.EQUIPM__PSEUDNOVOGR01"
							:is-visible="controls.EQUIPM__PSEUDNOVOGR01.isVisible">
							<!-- Start EQUIPM__PSEUDNOVOGR01 -->
							<q-row v-if="controls.EQUIPM__ASSETNAME____.isVisible">
								<q-col
									v-if="controls.EQUIPM__ASSETNAME____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EQUIPM__ASSETNAME____.isVisible"
										class="i-text"
										v-bind="controls.EQUIPM__ASSETNAME____"
										v-on="controls.EQUIPM__ASSETNAME____.handlers"
										:loading="controls.EQUIPM__ASSETNAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EQUIPM__ASSETNAME____.props"
											@blur="onBlur(controls.EQUIPM__ASSETNAME____, model.ValName.value)"
											@change="model.ValName.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.EQUIPM__ASSETASSETTYP.isVisible || controls.EQUIPM__ASSETASSETNUM.isVisible">
								<q-col
									v-if="controls.EQUIPM__ASSETASSETTYP.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EQUIPM__ASSETASSETTYP.isVisible"
										class="i-text"
										v-bind="controls.EQUIPM__ASSETASSETTYP"
										v-on="controls.EQUIPM__ASSETASSETTYP.handlers"
										:loading="controls.EQUIPM__ASSETASSETTYP.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.EQUIPM__ASSETASSETTYP.isVisible"
											v-bind="controls.EQUIPM__ASSETASSETTYP.props"
											@update:model-value="model.ValAssettyp.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.EQUIPM__ASSETASSETNUM.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EQUIPM__ASSETASSETNUM.isVisible"
										class="i-text"
										v-bind="controls.EQUIPM__ASSETASSETNUM"
										v-on="controls.EQUIPM__ASSETASSETNUM.handlers"
										:loading="controls.EQUIPM__ASSETASSETNUM.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.EQUIPM__ASSETASSETNUM.isVisible"
											v-bind="controls.EQUIPM__ASSETASSETNUM.props"
											@update:model-value="model.ValAssetnum.fnUpdateValue" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.EQUIPM__ASSETIDENTTYP.isVisible || controls.EQUIPM__ASSETGRAI____.isVisible || controls.EQUIPM__ASSETGIAI____.isVisible">
								<q-col
									v-if="controls.EQUIPM__ASSETIDENTTYP.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EQUIPM__ASSETIDENTTYP.isVisible"
										class="i-text"
										v-bind="controls.EQUIPM__ASSETIDENTTYP"
										v-on="controls.EQUIPM__ASSETIDENTTYP.handlers"
										:loading="controls.EQUIPM__ASSETIDENTTYP.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.EQUIPM__ASSETIDENTTYP.isVisible"
											v-bind="controls.EQUIPM__ASSETIDENTTYP.props"
											@update:model-value="model.ValIdenttyp.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.EQUIPM__ASSETGRAI____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EQUIPM__ASSETGRAI____.isVisible"
										class="i-text"
										v-bind="controls.EQUIPM__ASSETGRAI____"
										v-on="controls.EQUIPM__ASSETGRAI____.handlers"
										:loading="controls.EQUIPM__ASSETGRAI____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EQUIPM__ASSETGRAI____.props"
											@blur="onBlur(controls.EQUIPM__ASSETGRAI____, model.ValGrai.value)"
											@change="model.ValGrai.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.EQUIPM__ASSETGIAI____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EQUIPM__ASSETGIAI____.isVisible"
										class="i-text"
										v-bind="controls.EQUIPM__ASSETGIAI____"
										v-on="controls.EQUIPM__ASSETGIAI____.handlers"
										:loading="controls.EQUIPM__ASSETGIAI____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EQUIPM__ASSETGIAI____.props"
											@blur="onBlur(controls.EQUIPM__ASSETGIAI____, model.ValGiai.value)"
											@change="model.ValGiai.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.EQUIPM__MANUFNAME____.isVisible">
								<q-col
									v-if="controls.EQUIPM__MANUFNAME____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EQUIPM__MANUFNAME____.isVisible"
										class="i-text"
										v-bind="controls.EQUIPM__MANUFNAME____"
										v-on="controls.EQUIPM__MANUFNAME____.handlers"
										:loading="controls.EQUIPM__MANUFNAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.EQUIPM__MANUFNAME____.isVisible"
											v-bind="controls.EQUIPM__MANUFNAME____.props"
											v-on="controls.EQUIPM__MANUFNAME____.handlers" />
										<q-see-more-equipm-manufname
											v-if="controls.EQUIPM__MANUFNAME____.seeMoreIsVisible"
											v-bind="controls.EQUIPM__MANUFNAME____.seeMoreParams"
											v-on="controls.EQUIPM__MANUFNAME____.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.EQUIPM__KINDEDESIGNAT.isVisible">
								<q-col
									v-if="controls.EQUIPM__KINDEDESIGNAT.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EQUIPM__KINDEDESIGNAT.isVisible"
										class="i-text"
										v-bind="controls.EQUIPM__KINDEDESIGNAT"
										v-on="controls.EQUIPM__KINDEDESIGNAT.handlers"
										:loading="controls.EQUIPM__KINDEDESIGNAT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.EQUIPM__KINDEDESIGNAT.isVisible"
											v-bind="controls.EQUIPM__KINDEDESIGNAT.props"
											v-on="controls.EQUIPM__KINDEDESIGNAT.handlers" />
										<q-see-more-equipm-kindedesignat
											v-if="controls.EQUIPM__KINDEDESIGNAT.seeMoreIsVisible"
											v-bind="controls.EQUIPM__KINDEDESIGNAT.seeMoreParams"
											v-on="controls.EQUIPM__KINDEDESIGNAT.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End EQUIPM__PSEUDNOVOGR01 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.EQUIPM__PSEUDEQUIP01_.isVisible || controls.EQUIPM__PSEUDEQUIP02_.isVisible || controls.EQUIPM__PSEUDEQUIP03_.isVisible || controls.EQUIPM__PSEUDEQUIP04_.isVisible">
					<q-col
						v-if="controls.EQUIPM__PSEUDEQUIP01_.isVisible || controls.EQUIPM__PSEUDEQUIP02_.isVisible || controls.EQUIPM__PSEUDEQUIP03_.isVisible || controls.EQUIPM__PSEUDEQUIP04_.isVisible"
						cols="auto">
						<q-tab-container
							v-if="controls.formTabs.isVisible"
							id="q-tabs-EQUIPM"
							v-bind="controls.formTabs.props"
							@tab-changed="controls.formTabs.selectTab($event)">
							<template #tab-panel>
								<section
									v-if="controls.EQUIPM__PSEUDEQUIP01_.isVisible"
									v-show="controls.formTabs.selectedTab === 'EQUIPM__PSEUDEQUIP01_'">
									<div
										id="EQUIPM__PSEUDEQUIP01_"
										role="tabpanel"
										aria-labelledby="tab-container-EQUIPM__PSEUDEQUIP01_">
										<q-row v-if="controls.EQUIP01_ASSETPHOTO___.isVisible">
											<q-col
												v-if="controls.EQUIP01_ASSETPHOTO___.isVisible"
												cols="auto">
												<base-input-structure
													v-if="controls.EQUIP01_ASSETPHOTO___.isVisible"
													class="q-image"
													v-bind="controls.EQUIP01_ASSETPHOTO___"
													v-on="controls.EQUIP01_ASSETPHOTO___.handlers"
													:loading="controls.EQUIP01_ASSETPHOTO___.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-image
														v-if="controls.EQUIP01_ASSETPHOTO___.isVisible"
														v-bind="controls.EQUIP01_ASSETPHOTO___.props"
														v-on="controls.EQUIP01_ASSETPHOTO___.handlers" />
												</base-input-structure>
											</q-col>
										</q-row>
									</div>
								</section>
								<section
									v-if="controls.EQUIPM__PSEUDEQUIP02_.isVisible"
									v-show="controls.formTabs.selectedTab === 'EQUIPM__PSEUDEQUIP02_'">
									<div
										id="EQUIPM__PSEUDEQUIP02_"
										role="tabpanel"
										aria-labelledby="tab-container-EQUIPM__PSEUDEQUIP02_">
										<q-row v-if="controls.EQUIP02_PSEUDNOVOGR01.isVisible">
											<q-col
												v-if="controls.EQUIP02_PSEUDNOVOGR01.isVisible"
												cols="auto">
												<q-group-box-container
													v-if="controls.EQUIP02_PSEUDNOVOGR01.isVisible"
													id="EQUIP02_PSEUDNOVOGR01"
													v-bind="controls.EQUIP02_PSEUDNOVOGR01"
													no-border
													:is-visible="controls.EQUIP02_PSEUDNOVOGR01.isVisible">
													<!-- Start EQUIP02_PSEUDNOVOGR01 -->
													<q-row v-if="controls.EQUIP02_PSEUDATTACHME.isVisible">
														<q-col
															v-if="controls.EQUIP02_PSEUDATTACHME.isVisible"
															cols="auto">
															<q-table
																v-if="controls.EQUIP02_PSEUDATTACHME.isVisible"
																v-bind="controls.EQUIP02_PSEUDATTACHME"
																v-on="controls.EQUIP02_PSEUDATTACHME.handlers">
																<!-- USE /[MANUAL GQT CUSTOM_TABLE EQUIP02_PSEUDATTACHME]/ -->
															</q-table>
															<q-table-extra-extension
																v-if="controls.EQUIP02_PSEUDATTACHME.isVisible"
																:list-ctrl="controls.EQUIP02_PSEUDATTACHME"
																:filter-operators="controls.EQUIP02_PSEUDATTACHME.filterOperators"
																v-on="controls.EQUIP02_PSEUDATTACHME.handlers" />
														</q-col>
													</q-row>
													<!-- End EQUIP02_PSEUDNOVOGR01 -->
												</q-group-box-container>
											</q-col>
										</q-row>
									</div>
								</section>
								<section
									v-if="controls.EQUIPM__PSEUDEQUIP03_.isVisible"
									v-show="controls.formTabs.selectedTab === 'EQUIPM__PSEUDEQUIP03_'">
									<div
										id="EQUIPM__PSEUDEQUIP03_"
										role="tabpanel"
										aria-labelledby="tab-container-EQUIPM__PSEUDEQUIP03_">
										<q-row v-if="controls.EQUIP03_PSEUDNOVOGR01.isVisible">
											<q-col
												v-if="controls.EQUIP03_PSEUDNOVOGR01.isVisible"
												cols="auto">
												<q-group-box-container
													v-if="controls.EQUIP03_PSEUDNOVOGR01.isVisible"
													id="EQUIP03_PSEUDNOVOGR01"
													v-bind="controls.EQUIP03_PSEUDNOVOGR01"
													no-border
													:is-visible="controls.EQUIP03_PSEUDNOVOGR01.isVisible">
													<!-- Start EQUIP03_PSEUDNOVOGR01 -->
													<q-row v-if="controls.EQUIP03_PSEUDDOCUMENT.isVisible">
														<q-col
															v-if="controls.EQUIP03_PSEUDDOCUMENT.isVisible"
															cols="auto">
															<q-table
																v-if="controls.EQUIP03_PSEUDDOCUMENT.isVisible"
																v-bind="controls.EQUIP03_PSEUDDOCUMENT"
																v-on="controls.EQUIP03_PSEUDDOCUMENT.handlers">
																<!-- USE /[MANUAL GQT CUSTOM_TABLE EQUIP03_PSEUDDOCUMENT]/ -->
															</q-table>
															<q-table-extra-extension
																v-if="controls.EQUIP03_PSEUDDOCUMENT.isVisible"
																:list-ctrl="controls.EQUIP03_PSEUDDOCUMENT"
																:filter-operators="controls.EQUIP03_PSEUDDOCUMENT.filterOperators"
																v-on="controls.EQUIP03_PSEUDDOCUMENT.handlers" />
														</q-col>
													</q-row>
													<!-- End EQUIP03_PSEUDNOVOGR01 -->
												</q-group-box-container>
											</q-col>
										</q-row>
									</div>
								</section>
								<section
									v-if="controls.EQUIPM__PSEUDEQUIP04_.isVisible"
									v-show="controls.formTabs.selectedTab === 'EQUIPM__PSEUDEQUIP04_'">
									<div
										id="EQUIPM__PSEUDEQUIP04_"
										role="tabpanel"
										aria-labelledby="tab-container-EQUIPM__PSEUDEQUIP04_">
										<q-row v-if="controls.EQUIP04_PSEUDNOVOGR01.isVisible">
											<q-col
												v-if="controls.EQUIP04_PSEUDNOVOGR01.isVisible"
												cols="auto">
												<q-group-box-container
													v-if="controls.EQUIP04_PSEUDNOVOGR01.isVisible"
													id="EQUIP04_PSEUDNOVOGR01"
													v-bind="controls.EQUIP04_PSEUDNOVOGR01"
													no-border
													:is-visible="controls.EQUIP04_PSEUDNOVOGR01.isVisible">
													<!-- Start EQUIP04_PSEUDNOVOGR01 -->
													<q-row v-if="controls.EQUIP04_PSEUDPARAMLOA.isVisible || controls.EQUIP04_PSEUDMANUALS_.isVisible || controls.EQUIP04_PSEUDPARAMETE.isVisible">
														<q-col
															v-if="controls.EQUIP04_PSEUDPARAMLOA.isVisible"
															cols="auto">
															<base-input-structure
																v-if="controls.EQUIP04_PSEUDPARAMLOA.isVisible"
																class="i-button"
																v-bind="controls.EQUIP04_PSEUDPARAMLOA"
																v-on="controls.EQUIP04_PSEUDPARAMLOA.handlers"
																:loading="controls.EQUIP04_PSEUDPARAMLOA.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-button
																	v-if="controls.EQUIP04_PSEUDPARAMLOA.isVisible"
																	v-bind="controls.EQUIP04_PSEUDPARAMLOA.props"
																	@click="controls.EQUIP04_PSEUDPARAMLOA.action($event)">
																</q-button>
															</base-input-structure>
														</q-col>
														<q-col
															v-if="controls.EQUIP04_PSEUDMANUALS_.isVisible"
															cols="auto">
															<base-input-structure
																v-if="controls.EQUIP04_PSEUDMANUALS_.isVisible"
																class="i-button"
																v-bind="controls.EQUIP04_PSEUDMANUALS_"
																v-on="controls.EQUIP04_PSEUDMANUALS_.handlers"
																:loading="controls.EQUIP04_PSEUDMANUALS_.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-button
																	v-if="controls.EQUIP04_PSEUDMANUALS_.isVisible"
																	v-bind="controls.EQUIP04_PSEUDMANUALS_.props"
																	@click="controls.EQUIP04_PSEUDMANUALS_.action($event)">
																</q-button>
															</base-input-structure>
														</q-col>
														<q-col
															v-if="controls.EQUIP04_PSEUDPARAMETE.isVisible"
															cols="auto">
															<q-table
																v-if="controls.EQUIP04_PSEUDPARAMETE.isVisible"
																v-bind="controls.EQUIP04_PSEUDPARAMETE"
																v-on="controls.EQUIP04_PSEUDPARAMETE.handlers">
																<!-- USE /[MANUAL GQT CUSTOM_TABLE EQUIP04_PSEUDPARAMETE]/ -->
															</q-table>
															<q-table-extra-extension
																v-if="controls.EQUIP04_PSEUDPARAMETE.isVisible"
																:list-ctrl="controls.EQUIP04_PSEUDPARAMETE"
																:filter-operators="controls.EQUIP04_PSEUDPARAMETE.filterOperators"
																v-on="controls.EQUIP04_PSEUDPARAMETE.handlers" />
														</q-col>
													</q-row>
													<!-- End EQUIP04_PSEUDNOVOGR01 -->
												</q-group-box-container>
											</q-col>
										</q-row>
									</div>
								</section>
							</template>
						</q-tab-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.EQUIPM__ASSETDESCRIPT.isVisible">
					<q-col v-if="controls.EQUIPM__ASSETDESCRIPT.isVisible">
						<base-input-structure
							v-if="controls.EQUIPM__ASSETDESCRIPT.isVisible"
							class="i-textarea"
							v-bind="controls.EQUIPM__ASSETDESCRIPT"
							v-on="controls.EQUIPM__ASSETDESCRIPT.handlers"
							:loading="controls.EQUIPM__ASSETDESCRIPT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-area
								v-if="controls.EQUIPM__ASSETDESCRIPT.isVisible"
								v-bind="controls.EQUIPM__ASSETDESCRIPT.props"
								v-on="controls.EQUIPM__ASSETDESCRIPT.handlers" />
							<template #alternative-view>
								<q-markdown-viewer
									id="EQUIPM__ASSETDESCRIPT"
									:model-value="model.ValDescription.value"
									:options="controls.EQUIPM__ASSETDESCRIPT.markdownOptions" />
							</template>
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.EQUIPM__ASSETLONGDESC.isVisible">
					<q-col v-if="controls.EQUIPM__ASSETLONGDESC.isVisible">
						<base-input-structure
							v-if="controls.EQUIPM__ASSETLONGDESC.isVisible"
							class="i-text"
							v-bind="controls.EQUIPM__ASSETLONGDESC"
							v-on="controls.EQUIPM__ASSETLONGDESC.handlers"
							:loading="controls.EQUIPM__ASSETLONGDESC.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-markdown-editor
								v-if="controls.EQUIPM__ASSETLONGDESC.isVisible"
								v-bind="controls.EQUIPM__ASSETLONGDESC.props"
								:model-value="model.ValLongdesc.value"
								@update:model-value="model.ValLongdesc.fnUpdateValue" />
							<template #alternative-view>
								<q-markdown-viewer
									id="EQUIPM__ASSETLONGDESC"
									:model-value="model.ValLongdesc.value"
									:options="controls.EQUIPM__ASSETLONGDESC.markdownOptions" />
							</template>
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.EQUIPM__ASSETCATEGORY.isVisible || controls.EQUIPM__ASSETBG_COLOR.isVisible">
					<q-col
						v-if="controls.EQUIPM__ASSETCATEGORY.isVisible || controls.EQUIPM__ASSETBG_COLOR.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.EQUIPM__ASSETCATEGORY.isVisible"
							class="i-text"
							v-bind="controls.EQUIPM__ASSETCATEGORY"
							v-on="controls.EQUIPM__ASSETCATEGORY.handlers"
							:loading="controls.EQUIPM__ASSETCATEGORY.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-select
								v-if="controls.EQUIPM__ASSETCATEGORY.isVisible"
								v-bind="controls.EQUIPM__ASSETCATEGORY.props"
								@update:model-value="model.ValCategory.fnUpdateValue" />
						</base-input-structure>
						<base-input-structure
							v-if="controls.EQUIPM__ASSETBG_COLOR.isVisible"
							class="i-text"
							v-bind="controls.EQUIPM__ASSETBG_COLOR"
							v-on="controls.EQUIPM__ASSETBG_COLOR.handlers"
							:loading="controls.EQUIPM__ASSETBG_COLOR.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.EQUIPM__ASSETBG_COLOR.props"
								@blur="onBlur(controls.EQUIPM__ASSETBG_COLOR, model.ValBg_color.value)"
								@change="model.ValBg_color.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.EQUIPM__PSEUDA_TAGS__.isVisible">
					<q-col v-if="controls.EQUIPM__PSEUDA_TAGS__.isVisible">
						<q-grid-table-list
							v-if="controls.EQUIPM__PSEUDA_TAGS__.isVisible"
							v-bind="controls.EQUIPM__PSEUDA_TAGS__"
							v-on="controls.EQUIPM__PSEUDA_TAGS__.handlers" />
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

	import FormViewModel from './QFormEquipmViewModel.js'

	const requiredTextResources = ['QFormEquipm', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS EQUIPM]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormEquipm',

		components: {
			QSeeMoreEquipmManufname: defineAsyncComponent(() => import('@/views/forms/FormEquipm/dbedits/EquipmManufnameSeeMore.vue')),
			QSeeMoreEquipmKindedesignat: defineAsyncComponent(() => import('@/views/forms/FormEquipm/dbedits/EquipmKindedesignatSeeMore.vue')),
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
					name: 'EQUIPM',
					location: 'form-EQUIPM',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormEquipm', false),

				interfaceMetadata: {
					id: 'QFormEquipm', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'EQUIPM',
					route: 'form-EQUIPM',
					area: 'ASSET',
					primaryKey: 'ValCodasset',
					designation: computed(() => genericFunctions.formatString(this.Resources._ASSET__ASSETNUM____37227, vm.model.ValAssetnum.displayValue, vm.model.ValName.displayValue)),
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
						text: computed(() => vm.Resources.GRAVAR45301),
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
					EQUIPM__PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'EQUIPM__PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'xxlarge',
						label: computed(() => this.Resources.ASSET_IDENTIFICATION53152),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIPM__ASSETNAME____', 'EQUIPM__ASSETASSETTYP', 'EQUIPM__ASSETASSETNUM', 'EQUIPM__ASSETIDENTTYP', 'EQUIPM__ASSETGRAI____', 'EQUIPM__ASSETGIAI____', 'EQUIPM__MANUFNAME____', 'EQUIPM__KINDEDESIGNAT'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					EQUIPM__ASSETNAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:asset.name',
						id: 'EQUIPM__ASSETNAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.IDENTIFICATION_NAME16317),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIPM__PSEUDNOVOGR01',
						maxLength: 85,
						controlLimits: [
						],
					}, this),
					EQUIPM__ASSETASSETTYP: new fieldControlClass.ArrayStringControl({
						modelField: 'ValAssettyp',
						valueChangeEvent: 'fieldChange:asset.assettyp',
						id: 'EQUIPM__ASSETASSETTYP',
						name: 'ASSETTYP',
						size: 'medium',
						label: computed(() => this.Resources.ASSET_TYPE02033),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIPM__PSEUDNOVOGR01',
						maxLength: 1,
						mustBeFilled: true,
						arrayName: 'AssetTyp',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					EQUIPM__ASSETASSETNUM: new fieldControlClass.NumberControl({
						modelField: 'ValAssetnum',
						valueChangeEvent: 'fieldChange:asset.assetnum',
						id: 'EQUIPM__ASSETASSETNUM',
						name: 'ASSETNUM',
						size: 'small',
						label: computed(() => this.Resources.ASSET_NUMBER52372),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIPM__PSEUDNOVOGR01',
						maxIntegers: 10,
						maxDecimals: 0,
						isSequencial: true,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					EQUIPM__ASSETIDENTTYP: new fieldControlClass.ArrayStringControl({
						modelField: 'ValIdenttyp',
						valueChangeEvent: 'fieldChange:asset.identtyp',
						id: 'EQUIPM__ASSETIDENTTYP',
						name: 'IDENTTYP',
						size: 'small',
						label: computed(() => this.Resources.IDENTIFIER_TYPE60623),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIPM__PSEUDNOVOGR01',
						maxLength: 1,
						arrayName: 'IdentTyp',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					EQUIPM__ASSETGRAI____: new fieldControlClass.StringControl({
						modelField: 'ValGrai',
						valueChangeEvent: 'fieldChange:asset.grai',
						id: 'EQUIPM__ASSETGRAI____',
						name: 'GRAI',
						size: 'xlarge',
						label: computed(() => this.Resources.GRAI___GLOBAL_RETURN06821),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIPM__PSEUDNOVOGR01',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					EQUIPM__ASSETGIAI____: new fieldControlClass.StringControl({
						modelField: 'ValGiai',
						valueChangeEvent: 'fieldChange:asset.giai',
						id: 'EQUIPM__ASSETGIAI____',
						name: 'GIAI',
						size: 'xlarge',
						label: computed(() => this.Resources.GIAI___GLOBAL_INDIVI63214),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIPM__PSEUDNOVOGR01',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					EQUIPM__MANUFNAME____: new fieldControlClass.LookupControl({
						modelField: 'TableManufName',
						valueChangeEvent: 'fieldChange:manuf.name',
						id: 'EQUIPM__MANUFNAME____',
						name: 'NAME',
						size: 'mini',
						label: computed(() => this.Resources.MANUFACTURER50759),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIPM__PSEUDNOVOGR01',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodmanuf',
							dependencyEvent: 'fieldChange:asset.codmanuf'
						},
						dependentFields: () => ({
							set 'manuf.codentit'(value) { vm.model.ValCodmanuf.updateValue(value) },
							set 'manuf.name'(value) { vm.model.TableManufName.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					EQUIPM__KINDEDESIGNAT: new fieldControlClass.LookupControl({
						modelField: 'TableKindeDesignat',
						valueChangeEvent: 'fieldChange:kinde.designat',
						id: 'EQUIPM__KINDEDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.KIND_OF_EQUIPMENT22928),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIPM__PSEUDNOVOGR01',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodkinde',
							dependencyEvent: 'fieldChange:asset.codkinde'
						},
						dependentFields: () => ({
							set 'kinde.codkinde'(value) { vm.model.ValCodkinde.updateValue(value) },
							set 'kinde.designat'(value) { vm.model.TableKindeDesignat.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					EQUIPM__PSEUDEQUIP01_: new fieldControlClass.TabControl({
						id: 'EQUIPM__PSEUDEQUIP01_',
						name: 'EQUIP01',
						size: 'xxlarge',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['EQUIP01_ASSETPHOTO___'],
						controlLimits: [
						],
					}, this),
					EQUIPM__PSEUDEQUIP02_: new fieldControlClass.TabControl({
						id: 'EQUIPM__PSEUDEQUIP02_',
						name: 'EQUIP02',
						size: 'xxlarge',
						label: computed(() => this.Resources.ATTACHMENTS19612),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['EQUIP02_PSEUDNOVOGR01'],
						controlLimits: [
						],
					}, this),
					EQUIPM__PSEUDEQUIP03_: new fieldControlClass.TabControl({
						id: 'EQUIPM__PSEUDEQUIP03_',
						name: 'EQUIP03',
						size: 'xxlarge',
						label: computed(() => this.Resources.DOCUMENTS14470),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['EQUIP03_PSEUDNOVOGR01'],
						controlLimits: [
						],
					}, this),
					EQUIPM__PSEUDEQUIP04_: new fieldControlClass.TabControl({
						id: 'EQUIPM__PSEUDEQUIP04_',
						name: 'EQUIP04',
						size: 'xxlarge',
						label: computed(() => this.Resources.PARAMETERS28294),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['EQUIP04_PSEUDNOVOGR01'],
						controlLimits: [
						],
					}, this),
					EQUIPM__ASSETDESCRIPT: new fieldControlClass.MultilineStringControl({
						modelField: 'ValDescription',
						valueChangeEvent: 'fieldChange:asset.description',
						id: 'EQUIPM__ASSETDESCRIPT',
						name: 'DESCRIPT',
						size: 'block',
						label: computed(() => this.Resources.DESCRIPTION07383),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						rows: 5,
						cols: 30,
						showAlternativeView: computed(() => !this.isEditable),
						markdownOptions: {
							allowAttributes: false,
							allowImage: true,
							enableTypographer: true,
						},
						controlLimits: [
						],
					}, this),
					EQUIPM__ASSETLONGDESC: new fieldControlClass.MarkdownEditorControl({
						modelField: 'ValLongdesc',
						valueChangeEvent: 'fieldChange:asset.longdesc',
						id: 'EQUIPM__ASSETLONGDESC',
						name: 'LONGDESC',
						size: 'block',
						label: computed(() => this.Resources.DETAILED_DESCRIPTION36560),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						showAlternativeView: computed(() => !this.isEditable),
						markdownOptions: {
							allowAttributes: true,
							allowImage: true,
							enableTypographer: true,
						},
						controlLimits: [
						],
					}, this),
					EQUIPM__ASSETCATEGORY: new fieldControlClass.ArrayStringControl({
						modelField: 'ValCategory',
						valueChangeEvent: 'fieldChange:asset.category',
						id: 'EQUIPM__ASSETCATEGORY',
						name: 'CATEGORY',
						size: 'small',
						label: computed(() => this.Resources.CATEGORY18978),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 5,
						arrayName: 'assetCategory',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					EQUIPM__ASSETBG_COLOR: new fieldControlClass.FieldSpecialRenderingControl({
						modelField: 'ValBg_color',
						valueChangeEvent: 'fieldChange:asset.bg_color',
						id: 'EQUIPM__ASSETBG_COLOR',
						name: 'BG_COLOR',
						size: 'xlarge',
						label: computed(() => this.Resources.BACKGROUND_COLOR_FOR59228),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						viewModes: [
							{
								id: 'COLORPICKER',
								type: 'colorpicker',
								subtype: '',
								label: computed(() => this.Resources.COLOR_PICKER08843),
								order: 1,
								implicitVariable: 'color',
								implicitIsMultiple: true,
								mappingVariables: readonly({
								}),
								styleVariables: {
								},
								groups: {
								}
							},
						],
						controlLimits: [
						],
					}, this),
					EQUIPM__PSEUDA_TAGS__: new fieldControlClass.GridTableListControl({
						id: 'EQUIPM__PSEUDA_TAGS__',
						name: 'A_TAGS',
						size: 'block',
						label: computed(() => this.Resources.ASSET_TAGS23725),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'ASSET',
						action: 'Equipm_ValA_tags',
						modelField: 'ValA_tags',
						component: 'q-grid-form-equipm-pseuda-tags',
						permissions: {
						},
						columns: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValName',
								area: 'ATAGS',
								field: 'NAME',
								label: computed(() => this.Resources.TAG_NAME52385),
								dataLength: 75,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						controlLimits: [
							{
								identifier: ['id', 'asset'],
								dependencyEvents: ['fieldChange:asset.codasset'],
								dependencyField: 'ASSET.CODASSET',
								fnValueSelector: (model) => model.ValCodasset.value
							},
						],
					}, this),
					EQUIP01_ASSETPHOTO___: new fieldControlClass.ImageControl({
						modelField: 'ValPhoto',
						valueChangeEvent: 'fieldChange:asset.photo',
						id: 'EQUIP01_ASSETPHOTO___',
						name: 'PHOTO',
						size: 'xxlarge',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'EQUIPM__PSEUDEQUIP01_',
						height: 300,
						width: 400,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO51874)),
						controlLimits: [
						],
					}, this),
					EQUIP02_PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'EQUIP02_PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'xxlarge',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'EQUIPM__PSEUDEQUIP02_',
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIP02_PSEUDATTACHME'],
						controlLimits: [
						],
					}, this),
					EQUIP02_PSEUDATTACHME: new fieldControlClass.TableListControl({
						id: 'EQUIP02_PSEUDATTACHME',
						name: 'ATTACHME',
						size: '',
						label: computed(() => this.Resources.ATTACHMENTS19612),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP02_PSEUDNOVOGR01',
						tab: 'EQUIPM__PSEUDEQUIP02_',
						controller: 'ASSET',
						action: 'Equip02_ValAttachme',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValAttached',
								area: 'ATTAC',
								field: 'ATTACHED',
								label: computed(() => this.Resources.ATTACHED26247),
								scrollData: 16,
								dateTimeType: 'dateTime',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValNote',
								area: 'ATTAC',
								field: 'NOTE',
								label: computed(() => this.Resources.NOTE54557),
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DocumentColumn({
								order: 3,
								name: 'ValDocument',
								area: 'ATTAC',
								field: 'DOCUMENT',
								label: computed(() => this.Resources.DOCUMENT00695),
								dataLength: 85,
								scrollData: 30,
								sortable: false,
								export: 1,
								viewType: qEnums.documentViewTypeMode.print,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValAttachme',
							serverMode: true,
							pkColumn: 'ValCodattac',
							tableAlias: 'ATTAC',
							tableNamePlural: computed(() => this.Resources.ATTACHMENTS19612),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.ATTACHMENTS19612),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: false
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
										formName: 'ATTAC',
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
										formName: 'ATTAC',
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
										formName: 'ATTAC',
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
										formName: 'ATTAC',
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
										formName: 'ATTAC',
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
								id: 'RCA__ATTAC',
								name: '_ATTAC',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'ATTAC',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'ATTAC': {
									fnKeySelector: (row) => row.Fields.ValCodattac,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValAttached',
							defaultSearchColumnNameOriginal: 'ValAttached',
							defaultColumnSorting: {
								columnName: 'ValAttached',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-ATTAC', 'changed-ASSET'],
						uuid: 'Equip02_ValAttachme',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'asset'],
								dependencyEvents: ['fieldChange:asset.codasset'],
								dependencyField: 'ASSET.CODASSET',
								fnValueSelector: (model) => model.ValCodasset.value
							},
						],
					}, this),
					EQUIP03_PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'EQUIP03_PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'xxlarge',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'EQUIPM__PSEUDEQUIP03_',
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIP03_PSEUDDOCUMENT'],
						controlLimits: [
						],
					}, this),
					EQUIP03_PSEUDDOCUMENT: new fieldControlClass.TableListControl({
						id: 'EQUIP03_PSEUDDOCUMENT',
						name: 'DOCUMENT',
						size: '',
						label: computed(() => this.Resources.DOCUMENTS14470),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP03_PSEUDNOVOGR01',
						tab: 'EQUIPM__PSEUDEQUIP03_',
						controller: 'ASSET',
						action: 'Equip03_ValDocument',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValName',
								area: 'ASSMA',
								field: 'NAME',
								label: computed(() => this.Resources.MANUAL_NAME60077),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DocumentColumn({
								order: 2,
								name: 'ValDigdocum',
								area: 'ASSMA',
								field: 'DIGDOCUM',
								label: computed(() => this.Resources.DIGITAL_DOCUMENT59580),
								dataLength: 50,
								scrollData: 30,
								sortable: false,
								export: 1,
								viewType: qEnums.documentViewTypeMode.print,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValNotes',
								area: 'ASSMA',
								field: 'NOTES',
								label: computed(() => this.Resources.NOTES05274),
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValDocument',
							serverMode: true,
							pkColumn: 'ValCodassma',
							tableAlias: 'ASSMA',
							tableNamePlural: computed(() => this.Resources.ASSET_MANUALS04899),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.DOCUMENTS14470),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: false
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
										formName: 'ASSMA',
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
										formName: 'ASSMA',
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
										formName: 'ASSMA',
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
										formName: 'ASSMA',
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
										formName: 'ASSMA',
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
								id: 'RCA__ASSMA',
								name: '_ASSMA',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'ASSMA',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'ASSMA': {
									fnKeySelector: (row) => row.Fields.ValCodassma,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValName',
							defaultSearchColumnNameOriginal: 'ValName',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-ASSMA', 'changed-ASSET'],
						uuid: 'Equip03_ValDocument',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'asset'],
								dependencyEvents: ['fieldChange:asset.codasset'],
								dependencyField: 'ASSET.CODASSET',
								fnValueSelector: (model) => model.ValCodasset.value
							},
						],
					}, this),
					EQUIP04_PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'EQUIP04_PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'xxlarge',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'EQUIPM__PSEUDEQUIP04_',
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIP04_PSEUDPARAMLOA', 'EQUIP04_PSEUDMANUALS_', 'EQUIP04_PSEUDPARAMETE'],
						controlLimits: [
						],
					}, this),
					EQUIP04_PSEUDPARAMLOA: new fieldControlClass.ButtonControl({
						id: 'EQUIP04_PSEUDPARAMLOA',
						name: 'PARAMLOA',
						hasLabel: false,
						label: computed(() => this.Resources.PARAMETERS_LOAD27737),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP04_PSEUDNOVOGR01',
						tab: 'EQUIPM__PSEUDEQUIP04_',
						// eslint-disable-next-line
						action: (event) => {
							const btnAction = () => {
								if (!vm.isEditable)
									return Promise.resolve(true)

								const action = 'GetCarga_Parameters'
								const params = { idsrc: vm.model.ValCodkinde.value, iddst: vm.primaryKeyValue }

								return netAPI.postData(
									vm.formInfo.area,
									action,
									params,
									(data) => {
										if (data.Success)
										{
											genericFunctions.displayMessage(data.data, 'success')
											vm.fetchFormFields(true)
										}
										else
											genericFunctions.displayMessage(data.data, 'error')
									},
									undefined,
									undefined,
									vm.navigationId)
							}
							btnAction()
						},
						controlLimits: [
						],
					}, this),
					EQUIP04_PSEUDMANUALS_: new fieldControlClass.ButtonControl({
						id: 'EQUIP04_PSEUDMANUALS_',
						name: 'MANUALS',
						hasLabel: false,
						label: computed(() => this.Resources.MANUALS_LOAD21238),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP04_PSEUDNOVOGR01',
						tab: 'EQUIPM__PSEUDEQUIP04_',
						// eslint-disable-next-line
						action: (event) => {
							const btnAction = () => {
								if (!vm.isEditable)
									return Promise.resolve(true)

								const action = 'GetCarga_Manuals'
								const params = { idsrc: vm.model.ValCodkinde.value, iddst: vm.primaryKeyValue }

								return netAPI.postData(
									vm.formInfo.area,
									action,
									params,
									(data) => {
										if (data.Success)
										{
											genericFunctions.displayMessage(data.data, 'success')
											vm.fetchFormFields(true)
										}
										else
											genericFunctions.displayMessage(data.data, 'error')
									},
									undefined,
									undefined,
									vm.navigationId)
							}
							btnAction()
						},
						controlLimits: [
						],
					}, this),
					EQUIP04_PSEUDPARAMETE: new fieldControlClass.TableListControl({
						id: 'EQUIP04_PSEUDPARAMETE',
						name: 'PARAMETE',
						size: '',
						label: computed(() => this.Resources.PARAMETERS28294),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP04_PSEUDNOVOGR01',
						tab: 'EQUIPM__PSEUDEQUIP04_',
						controller: 'ASSET',
						action: 'Equip04_ValParamete',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Param.ValParameter',
								area: 'PARAM',
								field: 'PARAMETER',
								label: computed(() => this.Resources.PARAMETER41976),
								dataLength: 50,
								scrollData: 30,
								export: 1,
								pkColumn: 'ValCodparam',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 2,
								name: 'ValDatatype',
								area: 'ASSPA',
								field: 'DATATYPE',
								label: computed(() => this.Resources.DATA_TYPE47159),
								dataLength: 1,
								scrollData: 1,
								isVisible: false,
								export: 1,
								array: computed(() => new qProjArrays.QArrayDatatype(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayDatatype.type,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 3,
								name: 'ValDecimalplaces',
								area: 'ASSPA',
								field: 'DECIMALPLACES',
								label: computed(() => this.Resources.DECIMAL_PLACES62575),
								scrollData: 1,
								maxDigits: 1,
								decimalPlaces: 0,
								isVisible: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValText',
								area: 'ASSPA',
								field: 'TEXT',
								label: computed(() => this.Resources.TEXT04938),
								dataLength: 50,
								scrollData: 30,
								isVisible: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 5,
								name: 'ValQuantity',
								area: 'ASSPA',
								field: 'QUANTITY',
								label: computed(() => this.Resources.QUANTITY06415),
								scrollData: 12,
								maxDigits: 7,
								decimalPlaces: 4,
								isVisible: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 6,
								name: 'ValDate',
								area: 'ASSPA',
								field: 'DATE',
								label: computed(() => this.Resources.DATE18475),
								scrollData: 8,
								dateTimeType: 'date',
								isVisible: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'ValToshow',
								area: 'ASSPA',
								field: 'TOSHOW',
								label: computed(() => this.Resources.VALUE10285),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValParamete',
							serverMode: true,
							pkColumn: 'ValCodasspa',
							tableAlias: 'ASSPA',
							tableNamePlural: computed(() => this.Resources.ASSET_PARAMETERS20615),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.PARAMETERS28294),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: true
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
										formName: 'ASSPA',
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
										formName: 'ASSPA',
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
										formName: 'ASSPA',
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
										formName: 'ASSPA',
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
										formName: 'ASSPA',
										mode: 'NEW',
										repeatInsertion: true,
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
								id: 'RCA__ASSPA',
								name: '_ASSPA',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'ASSPA',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'ASSPA': {
									fnKeySelector: (row) => row.Fields.ValCodasspa,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValToshow',
							defaultSearchColumnNameOriginal: 'ValToshow',
							defaultColumnSorting: {
								columnName: 'Param.ValParameter',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-PARAM', 'changed-ASSPA', 'changed-ASSET'],
						uuid: 'Equip04_ValParamete',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'asset'],
								dependencyEvents: ['fieldChange:asset.codasset'],
								dependencyField: 'ASSET.CODASSET',
								fnValueSelector: (model) => model.ValCodasset.value
							},
						],
					}, this),
					formTabs: new fieldControlClass.TabsControl({
						id: 'formTabs',
						tabControlsIds: readonly([
							'EQUIPM__PSEUDEQUIP01_',
							'EQUIPM__PSEUDEQUIP02_',
							'EQUIPM__PSEUDEQUIP03_',
							'EQUIPM__PSEUDEQUIP04_',
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
					'EQUIPM__PSEUDNOVOGR01',
					'EQUIPM__PSEUDEQUIP01_',
					'EQUIPM__PSEUDEQUIP02_',
					'EQUIP02_PSEUDNOVOGR01',
					'EQUIPM__PSEUDEQUIP03_',
					'EQUIP03_PSEUDNOVOGR01',
					'EQUIPM__PSEUDEQUIP04_',
					'EQUIP04_PSEUDNOVOGR01',
				]),

				tableFields: readonly([
					'EQUIPM__PSEUDA_TAGS__',
					'EQUIP02_PSEUDATTACHME',
					'EQUIP03_PSEUDDOCUMENT',
					'EQUIP04_PSEUDPARAMETE',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Asset: {
						get ValAssetnum() { return vm.model.ValAssetnum.value },
						set ValAssetnum(value) { vm.model.ValAssetnum.updateValue(value) },
						get ValAssettyp() { return vm.model.ValAssettyp.value },
						set ValAssettyp(value) { vm.model.ValAssettyp.updateValue(value) },
						get ValBg_color() { return vm.model.ValBg_color.value },
						set ValBg_color(value) { vm.model.ValBg_color.updateValue(value) },
						get ValCategory() { return vm.model.ValCategory.value },
						set ValCategory(value) { vm.model.ValCategory.updateValue(value) },
						get ValCodkinde() { return vm.model.ValCodkinde.value },
						set ValCodkinde(value) { vm.model.ValCodkinde.updateValue(value) },
						get ValCodmanuf() { return vm.model.ValCodmanuf.value },
						set ValCodmanuf(value) { vm.model.ValCodmanuf.updateValue(value) },
						get ValDescription() { return vm.model.ValDescription.value },
						set ValDescription(value) { vm.model.ValDescription.updateValue(value) },
						get ValGiai() { return vm.model.ValGiai.value },
						set ValGiai(value) { vm.model.ValGiai.updateValue(value) },
						get ValGrai() { return vm.model.ValGrai.value },
						set ValGrai(value) { vm.model.ValGrai.updateValue(value) },
						get ValIdenttyp() { return vm.model.ValIdenttyp.value },
						set ValIdenttyp(value) { vm.model.ValIdenttyp.updateValue(value) },
						get ValLongdesc() { return vm.model.ValLongdesc.value },
						set ValLongdesc(value) { vm.model.ValLongdesc.updateValue(value) },
						get ValName() { return vm.model.ValName.value },
						set ValName(value) { vm.model.ValName.updateValue(value) },
						get ValPhoto() { return vm.model.ValPhoto.value },
						set ValPhoto(value) { vm.model.ValPhoto.updateValue(value) },
					},
					Kinde: {
						get ValDesignat() { return vm.model.TableKindeDesignat.value },
						set ValDesignat(value) { vm.model.TableKindeDesignat.updateValue(value) },
					},
					Manuf: {
						get ValName() { return vm.model.TableManufName.value },
						set ValName(value) { vm.model.TableManufName.updateValue(value) },
					},
					keys: {
						/** The primary key of the ASSET table */
						get asset() { return vm.model.ValCodasset },
						/** The foreign key to the KINDE table */
						get kinde() { return vm.model.ValCodkinde },
						/** The foreign key to the MANUF table */
						get manuf() { return vm.model.ValCodmanuf },
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
// USE /[MANUAL GQT FORM_CODEJS EQUIPM]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT EQUIPM]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS EQUIPM]/
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
// USE /[MANUAL GQT FORM_LOADED_JS EQUIPM]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS EQUIPM]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS EQUIPM]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS EQUIPM]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS EQUIPM]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS EQUIPM]/
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
// USE /[MANUAL GQT AFTER_DEL_JS EQUIPM]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS EQUIPM]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS EQUIPM]/
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
// USE /[MANUAL GQT DLGUPDT EQUIPM]/
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
// USE /[MANUAL GQT CTRLBLR EQUIPM]/
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
// USE /[MANUAL GQT CTRLUPD EQUIPM]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS EQUIPM]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
