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
			data-key="PROPR00"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.PROPR00_PSEUDNOVOGR04.isVisible">
					<q-control-wrapper
						v-show="controls.PROPR00_PSEUDNOVOGR04.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="PROPR00_PSEUDNOVOGR04"
							v-bind="controls.PROPR00_PSEUDNOVOGR04"
							:is-visible="controls.PROPR00_PSEUDNOVOGR04.isVisible">
							<!-- Start PROPR00_PSEUDNOVOGR04 -->
							<q-row-container
								v-show="controls.PROPR00_PSEUDNOVOGR02.isVisible || controls.PROPR00_PESSONAME____.isVisible"
								is-large>
								<q-control-wrapper
									v-show="controls.PROPR00_PSEUDNOVOGR02.isVisible"
									class="row-line-group">
									<q-group-box-container
										id="PROPR00_PSEUDNOVOGR02"
										v-bind="controls.PROPR00_PSEUDNOVOGR02"
										no-border
										:is-visible="controls.PROPR00_PSEUDNOVOGR02.isVisible">
										<!-- Start PROPR00_PSEUDNOVOGR02 -->
										<q-row-container v-show="controls.PROPR00_PROPRNAME____.isVisible || controls.PROPR00_PROPRPRECOEST.isVisible || controls.PROPR00_TPPROTPPROPRI.isVisible || controls.PROPR00_PROPRMOBILADA.isVisible">
											<q-control-wrapper
												v-show="controls.PROPR00_PROPRNAME____.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PROPR00_PROPRNAME____"
													v-on="controls.PROPR00_PROPRNAME____.handlers"
													:loading="controls.PROPR00_PROPRNAME____.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-text-field
														v-bind="controls.PROPR00_PROPRNAME____.props"
														:model-value="model.ValName.value"
														@update:model-value="model.ValName.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.PROPR00_PROPRPRECOEST.isVisible || controls.PROPR00_TPPROTPPROPRI.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PROPR00_PROPRPRECOEST"
													v-on="controls.PROPR00_PROPRPRECOEST.handlers"
													:loading="controls.PROPR00_PROPRPRECOEST.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-numeric-input
														v-if="controls.PROPR00_PROPRPRECOEST.isVisible"
														v-bind="controls.PROPR00_PROPRPRECOEST"
														:model-value="model.ValPrecoest.value"
														@update:model-value="model.ValPrecoest.fnUpdateValue" />
												</base-input-structure>
												<base-input-structure
													class="i-text"
													v-bind="controls.PROPR00_TPPROTPPROPRI"
													v-on="controls.PROPR00_TPPROTPPROPRI.handlers"
													:loading="controls.PROPR00_TPPROTPPROPRI.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-lookup
														v-if="controls.PROPR00_TPPROTPPROPRI.isVisible"
														v-bind="controls.PROPR00_TPPROTPPROPRI.props"
														:model-value="model.ValCodtppro.value"
														v-on="controls.PROPR00_TPPROTPPROPRI.handlers"
														@update:model-value="model.ValCodtppro.fnUpdateValue" />
													<q-see-more-propr00-tpprotppropri
														v-if="controls.PROPR00_TPPROTPPROPRI.seeMoreIsVisible"
														v-bind="controls.PROPR00_TPPROTPPROPRI.seeMoreParams"
														v-on="controls.PROPR00_TPPROTPPROPRI.handlers" />
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.PROPR00_PROPRMOBILADA.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-checkbox"
													v-bind="controls.PROPR00_PROPRMOBILADA"
													v-on="controls.PROPR00_PROPRMOBILADA.handlers"
													:loading="controls.PROPR00_PROPRMOBILADA.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<template #label>
														<q-checkbox-input
															v-if="controls.PROPR00_PROPRMOBILADA.isVisible"
															id="PROPR00_PROPRMOBILADA"
															size="small"
															:model-value="model.ValMobilada.value"
															:readonly="controls.PROPR00_PROPRMOBILADA.readonly"
															@update:model-value="model.ValMobilada.fnUpdateValue" />
													</template>
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<!-- End PROPR00_PSEUDNOVOGR02 -->
									</q-group-box-container>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PROPR00_PESSONAME____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PROPR00_PESSONAME____"
										v-on="controls.PROPR00_PESSONAME____.handlers"
										:loading="controls.PROPR00_PESSONAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-lookup
											v-if="controls.PROPR00_PESSONAME____.isVisible"
											v-bind="controls.PROPR00_PESSONAME____.props"
											:model-value="model.ValCodpesso.value"
											v-on="controls.PROPR00_PESSONAME____.handlers"
											@update:model-value="model.ValCodpesso.fnUpdateValue" />
										<q-see-more-propr00-pessoname
											v-if="controls.PROPR00_PESSONAME____.seeMoreIsVisible"
											v-bind="controls.PROPR00_PESSONAME____.seeMoreParams"
											v-on="controls.PROPR00_PESSONAME____.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container
								v-show="controls.PROPR00_PSEUDNOVOGR01.isVisible"
								is-large>
								<q-control-wrapper
									v-show="controls.PROPR00_PSEUDNOVOGR01.isVisible"
									class="row-line-group">
									<q-group-box-container
										id="PROPR00_PSEUDNOVOGR01"
										v-bind="controls.PROPR00_PSEUDNOVOGR01"
										no-border
										:is-visible="controls.PROPR00_PSEUDNOVOGR01.isVisible">
										<!-- Start PROPR00_PSEUDNOVOGR01 -->
										<q-row-container v-show="controls.PROPR00_PROPRPHOTOGRA.isVisible">
											<q-control-wrapper
												v-show="controls.PROPR00_PROPRPHOTOGRA.isVisible"
												class="control-join-group">
												<base-input-structure
													class="q-image"
													v-bind="controls.PROPR00_PROPRPHOTOGRA"
													v-on="controls.PROPR00_PROPRPHOTOGRA.handlers"
													:loading="controls.PROPR00_PROPRPHOTOGRA.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-image
														v-if="controls.PROPR00_PROPRPHOTOGRA.isVisible"
														v-bind="controls.PROPR00_PROPRPHOTOGRA.props"
														v-on="controls.PROPR00_PROPRPHOTOGRA.handlers" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<!-- End PROPR00_PSEUDNOVOGR01 -->
									</q-group-box-container>
								</q-control-wrapper>
							</q-row-container>
							<!-- End PROPR00_PSEUDNOVOGR04 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PROPR00_PSEUDPROPR02_.isVisible || controls.PROPR00_PSEUDPROPR01_.isVisible || controls.PROPR00_PSEUDPROPR03_.isVisible">
					<q-control-wrapper
						v-show="controls.PROPR00_PSEUDPROPR02_.isVisible || controls.PROPR00_PSEUDPROPR01_.isVisible || controls.PROPR00_PSEUDPROPR03_.isVisible"
						class="control-join-group">
						<q-tab-container
							id="tabs_PROPR00"
							align-tabs="left"
							:tabs-list="controls.formTabs.tabsList"
							:selected-tab="controls.formTabs.selectedTab"
							:is-visible="controls.formTabs.isVisible"
							@tab-changed="controls.formTabs.SelectTab($event)">
							<template #tab-panel>
								<section
									v-if="controls.PROPR00_PSEUDPROPR02_.isVisible"
									v-show="controls.formTabs.selectedTab === 'PROPR00_PSEUDPROPR02_'">
									<div id="PROPR00_PSEUDPROPR02_">
										<q-row-container v-show="controls.PROPR02_PROPRQTD_WC__.isVisible || controls.PROPR02_PROPRQTDQUART.isVisible || controls.PROPR02_PROPRM2______.isVisible">
											<q-control-wrapper
												v-show="controls.PROPR02_PROPRQTD_WC__.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PROPR02_PROPRQTD_WC__"
													v-on="controls.PROPR02_PROPRQTD_WC__.handlers"
													:loading="controls.PROPR02_PROPRQTD_WC__.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-numeric-input
														v-if="controls.PROPR02_PROPRQTD_WC__.isVisible"
														v-bind="controls.PROPR02_PROPRQTD_WC__"
														:model-value="model.ValQtd_wc.value"
														@update:model-value="model.ValQtd_wc.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.PROPR02_PROPRQTDQUART.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PROPR02_PROPRQTDQUART"
													v-on="controls.PROPR02_PROPRQTDQUART.handlers"
													:loading="controls.PROPR02_PROPRQTDQUART.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-numeric-input
														v-if="controls.PROPR02_PROPRQTDQUART.isVisible"
														v-bind="controls.PROPR02_PROPRQTDQUART"
														:model-value="model.ValQtdquart.value"
														@update:model-value="model.ValQtdquart.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.PROPR02_PROPRM2______.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PROPR02_PROPRM2______"
													v-on="controls.PROPR02_PROPRM2______.handlers"
													:loading="controls.PROPR02_PROPRM2______.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-numeric-input
														v-if="controls.PROPR02_PROPRM2______.isVisible"
														v-bind="controls.PROPR02_PROPRM2______"
														:model-value="model.ValM2.value"
														@update:model-value="model.ValM2.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.PROPR02_PROPRDTDISPON.isVisible">
											<q-control-wrapper
												v-show="controls.PROPR02_PROPRDTDISPON.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PROPR02_PROPRDTDISPON"
													v-on="controls.PROPR02_PROPRDTDISPON.handlers"
													:loading="controls.PROPR02_PROPRDTDISPON.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-datetime-input
														v-if="controls.PROPR02_PROPRDTDISPON.isVisible"
														v-bind="controls.PROPR02_PROPRDTDISPON"
														format="Date"
														:model-value="model.ValDtdispon.value"
														@update:model-value="model.ValDtdispon.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
									</div>
								</section>
								<section
									v-if="controls.PROPR00_PSEUDPROPR01_.isVisible"
									v-show="controls.formTabs.selectedTab === 'PROPR00_PSEUDPROPR01_'">
									<div id="PROPR00_PSEUDPROPR01_">
										<q-row-container
											v-show="controls.PROPR01_PSEUDNOVOGR01.isVisible || controls.PROPR01_PROPRCOORDGEO.isVisible"
											is-large>
											<q-control-wrapper
												v-show="controls.PROPR01_PSEUDNOVOGR01.isVisible"
												class="row-line-group">
												<q-group-box-container
													id="PROPR01_PSEUDNOVOGR01"
													v-bind="controls.PROPR01_PSEUDNOVOGR01"
													:is-visible="controls.PROPR01_PSEUDNOVOGR01.isVisible">
													<!-- Start PROPR01_PSEUDNOVOGR01 -->
													<q-row-container v-show="controls.PROPR01_PROPRENDERECO.isVisible || controls.PROPR01_PROPRLOCALIDA.isVisible">
														<q-control-wrapper
															v-show="controls.PROPR01_PROPRENDERECO.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-textarea"
																v-bind="controls.PROPR01_PROPRENDERECO"
																v-on="controls.PROPR01_PROPRENDERECO.handlers"
																:loading="controls.PROPR01_PROPRENDERECO.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn"
																:help-style="layoutConfig.HelpStyle">
																<q-textarea-input
																	v-if="controls.PROPR01_PROPRENDERECO.isVisible"
																	id="PROPR01_PROPRENDERECO"
																	size="xxlarge"
																	:model-value="model.ValEndereco.value"
																	:rows="2"
																	:cols="85"
																	:is-required="controls.PROPR01_PROPRENDERECO.isRequired"
																	:readonly="controls.PROPR01_PROPRENDERECO.readonly"
																	:placeholder="controls.PROPR01_PROPRENDERECO.placeholder"
																	@update:model-value="model.ValEndereco.fnUpdateValue" />
															</base-input-structure>
														</q-control-wrapper>
														<q-control-wrapper
															v-show="controls.PROPR01_PROPRLOCALIDA.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.PROPR01_PROPRLOCALIDA"
																v-on="controls.PROPR01_PROPRLOCALIDA.handlers"
																:loading="controls.PROPR01_PROPRLOCALIDA.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn"
																:help-style="layoutConfig.HelpStyle">
																<q-text-field
																	v-bind="controls.PROPR01_PROPRLOCALIDA.props"
																	:model-value="model.ValLocalida.value"
																	@update:model-value="model.ValLocalida.fnUpdateValue" />
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<q-row-container v-show="controls.PROPR01_PROPRPOSTALCO.isVisible || controls.PROPR01_PROPRPOSTALLO.isVisible">
														<q-control-wrapper
															v-show="controls.PROPR01_PROPRPOSTALCO.isVisible || controls.PROPR01_PROPRPOSTALLO.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.PROPR01_PROPRPOSTALCO"
																v-on="controls.PROPR01_PROPRPOSTALCO.handlers"
																:loading="controls.PROPR01_PROPRPOSTALCO.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn"
																:help-style="layoutConfig.HelpStyle">
																<q-text-field
																	v-bind="controls.PROPR01_PROPRPOSTALCO.props"
																	:model-value="model.ValPostalco.value"
																	@update:model-value="model.ValPostalco.fnUpdateValue" />
															</base-input-structure>
															<base-input-structure
																class="i-text"
																v-bind="controls.PROPR01_PROPRPOSTALLO"
																v-on="controls.PROPR01_PROPRPOSTALLO.handlers"
																:loading="controls.PROPR01_PROPRPOSTALLO.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn"
																:help-style="layoutConfig.HelpStyle">
																<q-text-field
																	v-bind="controls.PROPR01_PROPRPOSTALLO.props"
																	:model-value="model.ValPostallo.value"
																	@update:model-value="model.ValPostallo.fnUpdateValue" />
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<q-row-container v-show="controls.PROPR01_CNTRYCOUNTRY_.isVisible || controls.PROPR01_REGIOREGIAO__.isVisible">
														<q-control-wrapper
															v-show="controls.PROPR01_CNTRYCOUNTRY_.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.PROPR01_CNTRYCOUNTRY_"
																v-on="controls.PROPR01_CNTRYCOUNTRY_.handlers"
																:loading="controls.PROPR01_CNTRYCOUNTRY_.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn"
																:help-style="layoutConfig.HelpStyle">
																<q-lookup
																	v-if="controls.PROPR01_CNTRYCOUNTRY_.isVisible"
																	v-bind="controls.PROPR01_CNTRYCOUNTRY_.props"
																	:model-value="model.ValCodcntry.value"
																	v-on="controls.PROPR01_CNTRYCOUNTRY_.handlers"
																	@update:model-value="model.ValCodcntry.fnUpdateValue" />
																<q-see-more-propr01-cntrycountry
																	v-if="controls.PROPR01_CNTRYCOUNTRY_.seeMoreIsVisible"
																	v-bind="controls.PROPR01_CNTRYCOUNTRY_.seeMoreParams"
																	v-on="controls.PROPR01_CNTRYCOUNTRY_.handlers" />
															</base-input-structure>
														</q-control-wrapper>
														<q-control-wrapper
															v-show="controls.PROPR01_REGIOREGIAO__.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.PROPR01_REGIOREGIAO__"
																v-on="controls.PROPR01_REGIOREGIAO__.handlers"
																:loading="controls.PROPR01_REGIOREGIAO__.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn"
																:help-style="layoutConfig.HelpStyle">
																<q-lookup
																	v-if="controls.PROPR01_REGIOREGIAO__.isVisible"
																	v-bind="controls.PROPR01_REGIOREGIAO__.props"
																	:model-value="model.ValCodregia.value"
																	v-on="controls.PROPR01_REGIOREGIAO__.handlers"
																	@update:model-value="model.ValCodregia.fnUpdateValue" />
																<q-see-more-propr01-regioregiao
																	v-if="controls.PROPR01_REGIOREGIAO__.seeMoreIsVisible"
																	v-bind="controls.PROPR01_REGIOREGIAO__.seeMoreParams"
																	v-on="controls.PROPR01_REGIOREGIAO__.handlers" />
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<!-- End PROPR01_PSEUDNOVOGR01 -->
												</q-group-box-container>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.PROPR01_PROPRCOORDGEO.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PROPR01_PROPRCOORDGEO"
													v-on="controls.PROPR01_PROPRCOORDGEO.handlers"
													:loading="controls.PROPR01_PROPRCOORDGEO.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-text-field
														v-bind="controls.PROPR01_PROPRCOORDGEO.props"
														:model-value="model.ValCoordgeo.value"
														@update:model-value="model.ValCoordgeo.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
									</div>
								</section>
								<section
									v-if="controls.PROPR00_PSEUDPROPR03_.isVisible"
									v-show="controls.formTabs.selectedTab === 'PROPR00_PSEUDPROPR03_'">
									<div id="PROPR00_PSEUDPROPR03_">
										<q-row-container v-show="controls.PROPR03_PROPRDESCRIPT.isVisible">
											<q-control-wrapper
												v-show="controls.PROPR03_PROPRDESCRIPT.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PROPR03_PROPRDESCRIPT"
													v-on="controls.PROPR03_PROPRDESCRIPT.handlers"
													:loading="controls.PROPR03_PROPRDESCRIPT.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-text-editor
														v-if="controls.PROPR03_PROPRDESCRIPT.isVisible"
														v-bind="controls.PROPR03_PROPRDESCRIPT"
														:model-value="model.ValDescript.value"
														:rows="3"
														:cols="20"
														v-on="controls.PROPR03_PROPRDESCRIPT.handlers"
														@update:model-value="model.ValDescript.fnUpdateValue" />
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

	import FormViewModel from './QFormPropr00ViewModel.js'

	const requiredTextResources = ['QFormPropr00', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PROPR00]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormPropr00',

		components: {
			QSeeMorePropr00Tpprotppropri: defineAsyncComponent(() => import('@/views/forms/FormPropr00/dbedits/Propr00TpprotppropriSeeMore.vue')),
			QSeeMorePropr00Pessoname: defineAsyncComponent(() => import('@/views/forms/FormPropr00/dbedits/Propr00PessonameSeeMore.vue')),
			QSeeMorePropr01Cntrycountry: defineAsyncComponent(() => import('@/views/forms/FormPropr00/dbedits/Propr01CntrycountrySeeMore.vue')),
			QSeeMorePropr01Regioregiao: defineAsyncComponent(() => import('@/views/forms/FormPropr00/dbedits/Propr01RegioregiaoSeeMore.vue')),
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
						name: 'PROPR00',
						location: 'form-PROPR00',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormPropr00', false),

				interfaceMetadata: {
					id: 'QFormPropr00', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'PROPR00',
					route: 'form-PROPR00',
					area: 'PROPR',
					primaryKey: 'ValCodpropr',
					designation: computed(() => genericFunctions.formatString(this.Resources._PROPR__NAME_39336, vm.model.ValName.displayValue)),
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
					PROPR00_PSEUDNOVOGR04: new fieldControlClass.GroupControl({
						id: 'PROPR00_PSEUDNOVOGR04',
						name: 'NOVOGR04',
						size: 'xxlarge',
						hasLabel: true,
						label: '',
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
					PROPR00_PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'PROPR00_PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'block',
						hasLabel: true,
						label: '',
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'PROPR00_PSEUDNOVOGR04',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPR00_PROPRNAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:propr.name',
						id: 'PROPR00_PROPRNAME____',
						name: 'NAME',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.REAL_ESTATE24996),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPR00_PSEUDNOVOGR02',
						maxLength: 85,
						labelId: 'label_PROPR00_PROPRNAME____',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPR00_PROPRPRECOEST: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrecoest',
						valueChangeEvent: 'fieldChange:propr.precoest',
						maxIntegers: 9,
						maxDecimals: 2,
						id: 'PROPR00_PROPRPRECOEST',
						name: 'PRECOEST',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.ESTIMATED_PRICE02986),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPR00_PSEUDNOVOGR02',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPR00_TPPROTPPROPRI: new fieldControlClass.LookupControl({
						modelField: 'TableTpproTppropri',
						valueChangeEvent: 'fieldChange:tppro.tppropri',
						id: 'PROPR00_TPPROTPPROPRI',
						name: 'TPPROPRI',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.PROPERTY_TYPE33991),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPR00_PSEUDNOVOGR02',
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodtppro',
							dependencyEvent: 'fieldChange:propr.codtppro'
						},
						dependentFields: () => {
							return {
								set 'tppro.codtppro'(value) { vm.model.ValCodtppro.updateValue(value) },
								set 'tppro.tppropri'(value) { vm.model.TableTpproTppropri.updateValue(value) },
							}
						},
						insertEnabled: true,
						supportForm: 'TPPRO',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
					}, this),
					PROPR00_PROPRMOBILADA: new fieldControlClass.BooleanControl({
						modelField: 'ValMobilada',
						valueChangeEvent: 'fieldChange:propr.mobilada',
						id: 'PROPR00_PROPRMOBILADA',
						name: 'MOBILADA',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.FURNISHED37431),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'PROPR00_PSEUDNOVOGR02',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPR00_PESSONAME____: new fieldControlClass.LookupControl({
						modelField: 'TablePessoName',
						valueChangeEvent: 'fieldChange:pesso.name',
						id: 'PROPR00_PESSONAME____',
						name: 'NAME',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.SELLER36870),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPR00_PSEUDNOVOGR04',
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodpesso',
							dependencyEvent: 'fieldChange:propr.codpesso'
						},
						dependentFields: () => {
							return {
								set 'pesso.codpesso'(value) { vm.model.ValCodpesso.updateValue(value) },
								set 'pesso.name'(value) { vm.model.TablePessoName.updateValue(value) },
								set 'propr.codcntry'(value) { vm.model.ValCodcntry.updateValue(value) },
							}
						},
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
					}, this),
					PROPR00_PROPRPHOTOGRA: new fieldControlClass.ImageControl({
						modelField: 'ValPhotogra',
						valueChangeEvent: 'fieldChange:propr.photogra',
						id: 'PROPR00_PROPRPHOTOGRA',
						name: 'PHOTOGRA',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.PHOTO51874),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPR00_PSEUDNOVOGR01',
						height: 50,
						width: 100,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPR00_PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'PROPR00_PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						hasLabel: true,
						label: '',
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'PROPR00_PSEUDNOVOGR04',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPR00_PSEUDPROPR02_: new fieldControlClass.TabControl({
						id: 'PROPR00_PSEUDPROPR02_',
						name: 'PROPR02',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.DETAILS19591),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						openingEvent: 'opened-PROPR00_PSEUDPROPR02_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPR00_PSEUDPROPR01_: new fieldControlClass.TabControl({
						id: 'PROPR00_PSEUDPROPR01_',
						name: 'PROPR01',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.LOCALIZATION34148),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						openingEvent: 'opened-PROPR00_PSEUDPROPR01_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPR00_PSEUDPROPR03_: new fieldControlClass.TabControl({
						id: 'PROPR00_PSEUDPROPR03_',
						name: 'PROPR03',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.DESCRIPTION07383),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						openingEvent: 'opened-PROPR00_PSEUDPROPR03_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPR02_PROPRQTD_WC__: new fieldControlClass.NumberControl({
						modelField: 'ValQtd_wc',
						valueChangeEvent: 'fieldChange:propr.qtd_wc',
						maxIntegers: 6,
						maxDecimals: 0,
						id: 'PROPR02_PROPRQTD_WC__',
						name: 'QTD_WC',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.BATHROOM12866),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-PROPR00_PSEUDPROPR02_',
						tab: 'PROPR00_PSEUDPROPR02_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPR02_PROPRQTDQUART: new fieldControlClass.NumberControl({
						modelField: 'ValQtdquart',
						valueChangeEvent: 'fieldChange:propr.qtdquart',
						maxIntegers: 6,
						maxDecimals: 0,
						id: 'PROPR02_PROPRQTDQUART',
						name: 'QTDQUART',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.QUARTOS46431),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-PROPR00_PSEUDPROPR02_',
						tab: 'PROPR00_PSEUDPROPR02_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPR02_PROPRM2______: new fieldControlClass.NumberControl({
						modelField: 'ValM2',
						valueChangeEvent: 'fieldChange:propr.m2',
						maxIntegers: 6,
						maxDecimals: 0,
						id: 'PROPR02_PROPRM2______',
						name: 'M2',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.SQUARE_METERS28913),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-PROPR00_PSEUDPROPR02_',
						tab: 'PROPR00_PSEUDPROPR02_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPR02_PROPRDTDISPON: new fieldControlClass.DateControl({
						modelField: 'ValDtdispon',
						valueChangeEvent: 'fieldChange:propr.dtdispon',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'PROPR02_PROPRDTDISPON',
						name: 'DTDISPON',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.AVAILABLE_FROM53703),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-PROPR00_PSEUDPROPR02_',
						tab: 'PROPR00_PSEUDPROPR02_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPR01_PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'PROPR01_PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.ADDRESS04342),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						parentOpeningEvent: 'opened-PROPR00_PSEUDPROPR01_',
						tab: 'PROPR00_PSEUDPROPR01_',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPR01_PROPRENDERECO: new fieldControlClass.StringControl({
						modelField: 'ValEndereco',
						valueChangeEvent: 'fieldChange:propr.endereco',
						id: 'PROPR01_PROPRENDERECO',
						name: 'ENDERECO',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.ADDRESS04342),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-PROPR00_PSEUDPROPR01_',
						container: 'PROPR01_PSEUDNOVOGR01',
						tab: 'PROPR00_PSEUDPROPR01_',
						maxLength: 85,
						labelId: 'label_PROPR01_PROPRENDERECO',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPR01_PROPRLOCALIDA: new fieldControlClass.StringControl({
						modelField: 'ValLocalida',
						valueChangeEvent: 'fieldChange:propr.localida',
						id: 'PROPR01_PROPRLOCALIDA',
						name: 'LOCALIDA',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.LOCALIZATION34148),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-PROPR00_PSEUDPROPR01_',
						container: 'PROPR01_PSEUDNOVOGR01',
						tab: 'PROPR00_PSEUDPROPR01_',
						maxLength: 50,
						labelId: 'label_PROPR01_PROPRLOCALIDA',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPR01_PROPRPOSTALCO: new fieldControlClass.StringControl({
						modelField: 'ValPostalco',
						valueChangeEvent: 'fieldChange:propr.postalco',
						id: 'PROPR01_PROPRPOSTALCO',
						name: 'POSTALCO',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.ZIPCODE21021),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-PROPR00_PSEUDPROPR01_',
						container: 'PROPR01_PSEUDNOVOGR01',
						tab: 'PROPR00_PSEUDPROPR01_',
						maxLength: 20,
						labelId: 'label_PROPR01_PROPRPOSTALCO',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPR01_PROPRPOSTALLO: new fieldControlClass.StringControl({
						modelField: 'ValPostallo',
						valueChangeEvent: 'fieldChange:propr.postallo',
						id: 'PROPR01_PROPRPOSTALLO',
						name: 'POSTALLO',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.ZIPCODE21021),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-PROPR00_PSEUDPROPR01_',
						container: 'PROPR01_PSEUDNOVOGR01',
						tab: 'PROPR00_PSEUDPROPR01_',
						maxLength: 50,
						labelId: 'label_PROPR01_PROPRPOSTALLO',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPR01_CNTRYCOUNTRY_: new fieldControlClass.LookupControl({
						modelField: 'TableCntryCountry',
						valueChangeEvent: 'fieldChange:cntry.country',
						id: 'PROPR01_CNTRYCOUNTRY_',
						name: 'COUNTRY',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.COUNTRY64133),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-PROPR00_PSEUDPROPR01_',
						container: 'PROPR01_PSEUDNOVOGR01',
						tab: 'PROPR00_PSEUDPROPR01_',
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodcntry',
							dependencyEvent: 'fieldChange:propr.codcntry'
						},
						dependentFields: () => {
							return {
								set 'cntry.codcntry'(value) { vm.model.ValCodcntry.updateValue(value) },
								set 'cntry.country'(value) { vm.model.TableCntryCountry.updateValue(value) },
							}
						},
						insertEnabled: true,
						supportForm: 'PAIS',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
					}, this),
					PROPR01_REGIOREGIAO__: new fieldControlClass.LookupControl({
						modelField: 'TableRegioRegiao',
						valueChangeEvent: 'fieldChange:regio.regiao',
						id: 'PROPR01_REGIOREGIAO__',
						name: 'REGIAO',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.REGION12723),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-PROPR00_PSEUDPROPR01_',
						container: 'PROPR01_PSEUDNOVOGR01',
						tab: 'PROPR00_PSEUDPROPR01_',
						mustBeFilled: false,
						controlLimits: [
							{
								identifier: ['cntry', 'propr.codcntry'],
								dependencyEvents: ['fieldChange:propr.codcntry'],
								dependencyField: 'PROPR.CODCNTRY',
								fnValueSelector: (model) => model.ValCodcntry.value
							},
						],
						lookupKeyModelField: {
							name: 'ValCodregia',
							dependencyEvent: 'fieldChange:propr.codregia'
						},
						dependentFields: () => {
							return {
								set 'regio.codregia'(value) { vm.model.ValCodregia.updateValue(value) },
								set 'regio.regiao'(value) { vm.model.TableRegioRegiao.updateValue(value) },
							}
						},
						insertEnabled: true,
						supportForm: 'REGIA',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
					}, this),
					PROPR01_PROPRCOORDGEO: new fieldControlClass.BaseControl({
						modelField: 'ValCoordgeo',
						valueChangeEvent: 'fieldChange:propr.coordgeo',
						isGeographicShape: false,
						isEuclideanCoord: false,
						id: 'PROPR01_PROPRCOORDGEO',
						name: 'COORDGEO',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.GEOGRAPHIC_COORDINAT42880),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-PROPR00_PSEUDPROPR01_',
						tab: 'PROPR00_PSEUDPROPR01_',
						maxLength: 50,
						labelId: 'label_PROPR01_PROPRCOORDGEO',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPR03_PROPRDESCRIPT: new fieldControlClass.TextEditorControl({
						modelField: 'ValDescript',
						valueChangeEvent: 'fieldChange:propr.descript',
						id: 'PROPR03_PROPRDESCRIPT',
						name: 'DESCRIPT',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.DESCRIPTION07383),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-PROPR00_PSEUDPROPR03_',
						tab: 'PROPR00_PSEUDPROPR03_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					formTabs: new fieldControlClass.TabsControl({
						tabControlsIds: readonly([
							'PROPR00_PSEUDPROPR02_',
							'PROPR00_PSEUDPROPR01_',
							'PROPR00_PSEUDPROPR03_',
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
					'PROPR00_PSEUDNOVOGR04',
					'PROPR00_PSEUDNOVOGR02',
					'PROPR00_PSEUDNOVOGR01',
					'PROPR00_PSEUDPROPR02_',
					'PROPR00_PSEUDPROPR01_',
					'PROPR01_PSEUDNOVOGR01',
					'PROPR00_PSEUDPROPR03_',
				]),

				tableFields: readonly([
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
					Pesso: {
						get ValName() { return vm.model.TablePessoName.value },
						set ValName(value) { vm.model.TablePessoName.updateValue(value) },
					},
					Propr: {
						get ValCodcntry() { return vm.model.ValCodcntry.value },
						set ValCodcntry(value) { vm.model.ValCodcntry.updateValue(value) },
						get ValCodpais1() { return vm.model.ValCodpais1.value },
						set ValCodpais1(value) { vm.model.ValCodpais1.updateValue(value) },
						get ValCodpesso() { return vm.model.ValCodpesso.value },
						set ValCodpesso(value) { vm.model.ValCodpesso.updateValue(value) },
						get ValCodregia() { return vm.model.ValCodregia.value },
						set ValCodregia(value) { vm.model.ValCodregia.updateValue(value) },
						get ValCodtppro() { return vm.model.ValCodtppro.value },
						set ValCodtppro(value) { vm.model.ValCodtppro.updateValue(value) },
						get ValCoordgeo() { return vm.model.ValCoordgeo.value },
						set ValCoordgeo(value) { vm.model.ValCoordgeo.updateValue(value) },
						get ValDescript() { return vm.model.ValDescript.value },
						set ValDescript(value) { vm.model.ValDescript.updateValue(value) },
						get ValDtdispon() { return vm.model.ValDtdispon.value },
						set ValDtdispon(value) { vm.model.ValDtdispon.updateValue(value) },
						get ValEndereco() { return vm.model.ValEndereco.value },
						set ValEndereco(value) { vm.model.ValEndereco.updateValue(value) },
						get ValLocalida() { return vm.model.ValLocalida.value },
						set ValLocalida(value) { vm.model.ValLocalida.updateValue(value) },
						get ValM2() { return vm.model.ValM2.value },
						set ValM2(value) { vm.model.ValM2.updateValue(value) },
						get ValMobilada() { return vm.model.ValMobilada.value },
						set ValMobilada(value) { vm.model.ValMobilada.updateValue(value) },
						get ValName() { return vm.model.ValName.value },
						set ValName(value) { vm.model.ValName.updateValue(value) },
						get ValPhotogra() { return vm.model.ValPhotogra.value },
						set ValPhotogra(value) { vm.model.ValPhotogra.updateValue(value) },
						get ValPostalco() { return vm.model.ValPostalco.value },
						set ValPostalco(value) { vm.model.ValPostalco.updateValue(value) },
						get ValPostallo() { return vm.model.ValPostallo.value },
						set ValPostallo(value) { vm.model.ValPostallo.updateValue(value) },
						get ValPrecoest() { return vm.model.ValPrecoest.value },
						set ValPrecoest(value) { vm.model.ValPrecoest.updateValue(value) },
						get ValQtd_wc() { return vm.model.ValQtd_wc.value },
						set ValQtd_wc(value) { vm.model.ValQtd_wc.updateValue(value) },
						get ValQtdquart() { return vm.model.ValQtdquart.value },
						set ValQtdquart(value) { vm.model.ValQtdquart.updateValue(value) },
					},
					Regio: {
						get ValRegiao() { return vm.model.TableRegioRegiao.value },
						set ValRegiao(value) { vm.model.TableRegioRegiao.updateValue(value) },
					},
					Tppro: {
						get ValTppropri() { return vm.model.TableTpproTppropri.value },
						set ValTppropri(value) { vm.model.TableTpproTppropri.updateValue(value) },
					},
					keys: {
						/** The primary key of the PROPR table */
						get propr() { return vm.model.ValCodpropr },
						/** The foreign key to the TPPRO table */
						get tppro() { return vm.model.ValCodtppro },
						/** The foreign key to the REGIO table */
						get regio() { return vm.model.ValCodregia },
						/** The foreign key to the CNTRY table */
						get cntry() { return vm.model.ValCodcntry },
						/** The foreign key to the PESSO table */
						get pesso() { return vm.model.ValCodpesso },
						/** The foreign key to the PAIS1 table */
						get pais1() { return vm.model.ValCodpais1 },
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
// USE /[MANUAL GQT FORM_CODEJS PROPR00]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS PROPR00]/
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
// USE /[MANUAL GQT FORM_LOADED_JS PROPR00]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS PROPR00]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS PROPR00]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS PROPR00]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS PROPR00]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS PROPR00]/
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
// USE /[MANUAL GQT AFTER_DEL_JS PROPR00]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS PROPR00]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS PROPR00]/
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
// USE /[MANUAL GQT DLGUPDT PROPR00]/
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
// USE /[MANUAL GQT CTRLUPD PROPR00]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
		},

		watch: {
			// Watchers for changes in the state of tabs and collapsible groups.
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
