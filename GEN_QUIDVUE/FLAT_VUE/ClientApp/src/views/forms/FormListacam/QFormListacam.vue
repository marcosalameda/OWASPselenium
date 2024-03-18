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
			data-key="LISTACAM"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.LISTACAMPSEUDCAMTEXTO.isVisible || controls.LISTACAMPSEUDCAMNUM__.isVisible || controls.LISTACAMPSEUDCAMDATE_.isVisible || controls.LISTACAMPSEUDCAMMASK_.isVisible || controls.LISTACAMPSEUDCAMENUM_.isVisible || controls.LISTACAMPSEUDCAMDOCS_.isVisible || controls.LISTACAMPSEUDCAMAUDIT.isVisible">
					<q-control-wrapper
						v-show="controls.LISTACAMPSEUDCAMTEXTO.isVisible || controls.LISTACAMPSEUDCAMNUM__.isVisible || controls.LISTACAMPSEUDCAMDATE_.isVisible || controls.LISTACAMPSEUDCAMMASK_.isVisible || controls.LISTACAMPSEUDCAMENUM_.isVisible || controls.LISTACAMPSEUDCAMDOCS_.isVisible || controls.LISTACAMPSEUDCAMAUDIT.isVisible"
						class="control-join-group">
						<q-tab-container
							id="tabs_LISTACAM"
							align-tabs="left"
							:tabs-list="controls.formTabs.tabsList"
							:selected-tab="controls.formTabs.selectedTab"
							:is-visible="controls.formTabs.isVisible"
							@tab-changed="controls.formTabs.SelectTab($event)">
							<template #tab-panel>
								<section
									v-if="controls.LISTACAMPSEUDCAMTEXTO.isVisible"
									v-show="controls.formTabs.selectedTab === 'LISTACAMPSEUDCAMTEXTO'">
									<div id="LISTACAMPSEUDCAMTEXTO">
										<q-row-container v-show="controls.CAMTEXTOFLDS_TXTFIELD.isVisible">
											<q-control-wrapper
												v-show="controls.CAMTEXTOFLDS_TXTFIELD.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMTEXTOFLDS_TXTFIELD"
													v-on="controls.CAMTEXTOFLDS_TXTFIELD.handlers"
													:loading="controls.CAMTEXTOFLDS_TXTFIELD.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-text-field
														v-bind="controls.CAMTEXTOFLDS_TXTFIELD.props"
														:model-value="model.ValTxtfield.value"
														@update:model-value="model.ValTxtfield.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CAMTEXTOFLDS_DESCRIP_.isVisible">
											<q-control-wrapper
												v-show="controls.CAMTEXTOFLDS_DESCRIP_.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-textarea"
													v-bind="controls.CAMTEXTOFLDS_DESCRIP_"
													v-on="controls.CAMTEXTOFLDS_DESCRIP_.handlers"
													:loading="controls.CAMTEXTOFLDS_DESCRIP_.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-textarea-input
														v-if="controls.CAMTEXTOFLDS_DESCRIP_.isVisible"
														id="CAMTEXTOFLDS_DESCRIP_"
														size="large"
														:model-value="model.ValDescrip.value"
														:rows="3"
														:cols="30"
														:is-required="controls.CAMTEXTOFLDS_DESCRIP_.isRequired"
														:readonly="controls.CAMTEXTOFLDS_DESCRIP_.readonly"
														:placeholder="controls.CAMTEXTOFLDS_DESCRIP_.placeholder"
														@update:model-value="model.ValDescrip.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
									</div>
								</section>
								<section
									v-if="controls.LISTACAMPSEUDCAMNUM__.isVisible"
									v-show="controls.formTabs.selectedTab === 'LISTACAMPSEUDCAMNUM__'">
									<div id="LISTACAMPSEUDCAMNUM__">
										<q-row-container v-show="controls.CAMNUM__FLDS_NPASSAGE.isVisible">
											<q-control-wrapper
												v-show="controls.CAMNUM__FLDS_NPASSAGE.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMNUM__FLDS_NPASSAGE"
													v-on="controls.CAMNUM__FLDS_NPASSAGE.handlers"
													:loading="controls.CAMNUM__FLDS_NPASSAGE.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-numeric-input
														v-if="controls.CAMNUM__FLDS_NPASSAGE.isVisible"
														v-bind="controls.CAMNUM__FLDS_NPASSAGE"
														:model-value="model.ValNpassage.value"
														@update:model-value="model.ValNpassage.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CAMNUM__FLDS_DURATION.isVisible">
											<q-control-wrapper
												v-show="controls.CAMNUM__FLDS_DURATION.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMNUM__FLDS_DURATION"
													v-on="controls.CAMNUM__FLDS_DURATION.handlers"
													:loading="controls.CAMNUM__FLDS_DURATION.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-numeric-input
														v-if="controls.CAMNUM__FLDS_DURATION.isVisible"
														v-bind="controls.CAMNUM__FLDS_DURATION"
														:model-value="model.ValDuration.value"
														@update:model-value="model.ValDuration.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CAMNUM__FLDS_PRICE___.isVisible">
											<q-control-wrapper
												v-show="controls.CAMNUM__FLDS_PRICE___.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMNUM__FLDS_PRICE___"
													v-on="controls.CAMNUM__FLDS_PRICE___.handlers"
													:loading="controls.CAMNUM__FLDS_PRICE___.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-numeric-input
														v-if="controls.CAMNUM__FLDS_PRICE___.isVisible"
														v-bind="controls.CAMNUM__FLDS_PRICE___"
														:model-value="model.ValPrice.value"
														@update:model-value="model.ValPrice.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CAMNUM__FLDS_PRECOBIL.isVisible">
											<q-control-wrapper
												v-show="controls.CAMNUM__FLDS_PRECOBIL.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMNUM__FLDS_PRECOBIL"
													v-on="controls.CAMNUM__FLDS_PRECOBIL.handlers"
													:loading="controls.CAMNUM__FLDS_PRECOBIL.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-numeric-input
														v-if="controls.CAMNUM__FLDS_PRECOBIL.isVisible"
														v-bind="controls.CAMNUM__FLDS_PRECOBIL"
														:model-value="model.ValPrecobil.value"
														@update:model-value="model.ValPrecobil.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
									</div>
								</section>
								<section
									v-if="controls.LISTACAMPSEUDCAMDATE_.isVisible"
									v-show="controls.formTabs.selectedTab === 'LISTACAMPSEUDCAMDATE_'">
									<div id="LISTACAMPSEUDCAMDATE_">
										<q-row-container v-show="controls.CAMDATE_FLDS_YEAR____.isVisible">
											<q-control-wrapper
												v-show="controls.CAMDATE_FLDS_YEAR____.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMDATE_FLDS_YEAR____"
													v-on="controls.CAMDATE_FLDS_YEAR____.handlers"
													:loading="controls.CAMDATE_FLDS_YEAR____.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-numeric-input
														v-if="controls.CAMDATE_FLDS_YEAR____.isVisible"
														v-bind="controls.CAMDATE_FLDS_YEAR____"
														:model-value="model.ValYear.value"
														@update:model-value="model.ValYear.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CAMDATE_FLDS_DATE____.isVisible">
											<q-control-wrapper
												v-show="controls.CAMDATE_FLDS_DATE____.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMDATE_FLDS_DATE____"
													v-on="controls.CAMDATE_FLDS_DATE____.handlers"
													:loading="controls.CAMDATE_FLDS_DATE____.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-datetime-input
														v-if="controls.CAMDATE_FLDS_DATE____.isVisible"
														v-bind="controls.CAMDATE_FLDS_DATE____"
														format="Date"
														:model-value="model.ValDate.value"
														@update:model-value="model.ValDate.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CAMDATE_FLDS_DATETIME.isVisible">
											<q-control-wrapper
												v-show="controls.CAMDATE_FLDS_DATETIME.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMDATE_FLDS_DATETIME"
													v-on="controls.CAMDATE_FLDS_DATETIME.handlers"
													:loading="controls.CAMDATE_FLDS_DATETIME.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-datetime-input
														v-if="controls.CAMDATE_FLDS_DATETIME.isVisible"
														v-bind="controls.CAMDATE_FLDS_DATETIME"
														format="DateTime"
														:model-value="model.ValDatetime.value"
														@update:model-value="model.ValDatetime.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CAMDATE_FLDS_DATESECO.isVisible">
											<q-control-wrapper
												v-show="controls.CAMDATE_FLDS_DATESECO.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMDATE_FLDS_DATESECO"
													v-on="controls.CAMDATE_FLDS_DATESECO.handlers"
													:loading="controls.CAMDATE_FLDS_DATESECO.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-datetime-input
														v-if="controls.CAMDATE_FLDS_DATESECO.isVisible"
														v-bind="controls.CAMDATE_FLDS_DATESECO"
														format="DateTimeSeconds"
														:model-value="model.ValDateseco.value"
														@update:model-value="model.ValDateseco.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CAMDATE_FLDS_TIME____.isVisible">
											<q-control-wrapper
												v-show="controls.CAMDATE_FLDS_TIME____.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMDATE_FLDS_TIME____"
													v-on="controls.CAMDATE_FLDS_TIME____.handlers"
													:loading="controls.CAMDATE_FLDS_TIME____.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-datetime-input
														v-if="controls.CAMDATE_FLDS_TIME____.isVisible"
														v-bind="controls.CAMDATE_FLDS_TIME____"
														format="Time"
														:model-value="model.ValTime.value"
														@update:model-value="model.ValTime.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
									</div>
								</section>
								<section
									v-if="controls.LISTACAMPSEUDCAMMASK_.isVisible"
									v-show="controls.formTabs.selectedTab === 'LISTACAMPSEUDCAMMASK_'">
									<div id="LISTACAMPSEUDCAMMASK_">
										<q-row-container v-show="controls.CAMMASK_FLDS_ZIPFIELD.isVisible">
											<q-control-wrapper
												v-show="controls.CAMMASK_FLDS_ZIPFIELD.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMMASK_FLDS_ZIPFIELD"
													v-on="controls.CAMMASK_FLDS_ZIPFIELD.handlers"
													:loading="controls.CAMMASK_FLDS_ZIPFIELD.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-mask
														v-if="controls.CAMMASK_FLDS_ZIPFIELD.isVisible"
														v-bind="controls.CAMMASK_FLDS_ZIPFIELD"
														:model-value="model.ValZipfield.value"
														@update:model-value="model.ValZipfield.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CAMMASK_FLDS_VATNUMBR.isVisible">
											<q-control-wrapper
												v-show="controls.CAMMASK_FLDS_VATNUMBR.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMMASK_FLDS_VATNUMBR"
													v-on="controls.CAMMASK_FLDS_VATNUMBR.handlers"
													:loading="controls.CAMMASK_FLDS_VATNUMBR.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-mask
														v-if="controls.CAMMASK_FLDS_VATNUMBR.isVisible"
														v-bind="controls.CAMMASK_FLDS_VATNUMBR"
														:model-value="model.ValVatnumbr.value"
														@update:model-value="model.ValVatnumbr.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CAMMASK_FLDS_LICPLATE.isVisible">
											<q-control-wrapper
												v-show="controls.CAMMASK_FLDS_LICPLATE.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMMASK_FLDS_LICPLATE"
													v-on="controls.CAMMASK_FLDS_LICPLATE.handlers"
													:loading="controls.CAMMASK_FLDS_LICPLATE.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-mask
														v-if="controls.CAMMASK_FLDS_LICPLATE.isVisible"
														v-bind="controls.CAMMASK_FLDS_LICPLATE"
														:model-value="model.ValLicplate.value"
														@update:model-value="model.ValLicplate.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CAMMASK_FLDS_SSNUMBER.isVisible">
											<q-control-wrapper
												v-show="controls.CAMMASK_FLDS_SSNUMBER.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMMASK_FLDS_SSNUMBER"
													v-on="controls.CAMMASK_FLDS_SSNUMBER.handlers"
													:loading="controls.CAMMASK_FLDS_SSNUMBER.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-mask
														v-if="controls.CAMMASK_FLDS_SSNUMBER.isVisible"
														v-bind="controls.CAMMASK_FLDS_SSNUMBER"
														:model-value="model.ValSsnumber.value"
														@update:model-value="model.ValSsnumber.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CAMMASK_FLDS_BANKNMBR.isVisible">
											<q-control-wrapper
												v-show="controls.CAMMASK_FLDS_BANKNMBR.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMMASK_FLDS_BANKNMBR"
													v-on="controls.CAMMASK_FLDS_BANKNMBR.handlers"
													:loading="controls.CAMMASK_FLDS_BANKNMBR.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-mask
														v-if="controls.CAMMASK_FLDS_BANKNMBR.isVisible"
														v-bind="controls.CAMMASK_FLDS_BANKNMBR"
														:model-value="model.ValBanknmbr.value"
														@update:model-value="model.ValBanknmbr.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CAMMASK_FLDS_EMAILFLD.isVisible">
											<q-control-wrapper
												v-show="controls.CAMMASK_FLDS_EMAILFLD.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMMASK_FLDS_EMAILFLD"
													v-on="controls.CAMMASK_FLDS_EMAILFLD.handlers"
													:loading="controls.CAMMASK_FLDS_EMAILFLD.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-mask
														v-if="controls.CAMMASK_FLDS_EMAILFLD.isVisible"
														v-bind="controls.CAMMASK_FLDS_EMAILFLD"
														:model-value="model.ValEmailfld.value"
														@update:model-value="model.ValEmailfld.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CAMMASK_FLDS_IBANFIEL.isVisible">
											<q-control-wrapper
												v-show="controls.CAMMASK_FLDS_IBANFIEL.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMMASK_FLDS_IBANFIEL"
													v-on="controls.CAMMASK_FLDS_IBANFIEL.handlers"
													:loading="controls.CAMMASK_FLDS_IBANFIEL.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-mask
														v-if="controls.CAMMASK_FLDS_IBANFIEL.isVisible"
														v-bind="controls.CAMMASK_FLDS_IBANFIEL"
														:model-value="model.ValIbanfiel.value"
														@update:model-value="model.ValIbanfiel.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CAMMASK_FLDS_UPPRTEXT.isVisible">
											<q-control-wrapper
												v-show="controls.CAMMASK_FLDS_UPPRTEXT.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMMASK_FLDS_UPPRTEXT"
													v-on="controls.CAMMASK_FLDS_UPPRTEXT.handlers"
													:loading="controls.CAMMASK_FLDS_UPPRTEXT.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-mask
														v-if="controls.CAMMASK_FLDS_UPPRTEXT.isVisible"
														v-bind="controls.CAMMASK_FLDS_UPPRTEXT"
														:model-value="model.ValUpprtext.value"
														@update:model-value="model.ValUpprtext.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
									</div>
								</section>
								<section
									v-if="controls.LISTACAMPSEUDCAMENUM_.isVisible"
									v-show="controls.formTabs.selectedTab === 'LISTACAMPSEUDCAMENUM_'">
									<div id="LISTACAMPSEUDCAMENUM_">
										<q-row-container v-show="controls.CAMENUM_FLDS_CLASSNUM.isVisible">
											<q-control-wrapper
												v-show="controls.CAMENUM_FLDS_CLASSNUM.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-radio-container"
													v-bind="controls.CAMENUM_FLDS_CLASSNUM"
													v-on="controls.CAMENUM_FLDS_CLASSNUM.handlers"
													:label-position="labelAlignment.topleft"
													:loading="controls.CAMENUM_FLDS_CLASSNUM.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-radio-button-input
														v-if="controls.CAMENUM_FLDS_CLASSNUM.isVisible"
														id="CAMENUM_FLDS_CLASSNUM"
														:model-value="model.ValClassnum.value"
														deselect-radio
														:label-left-side="controls.CAMENUM_FLDS_CLASSNUM.labelPosition === labelAlignment.left"
														:number-of-columns="controls.CAMENUM_FLDS_CLASSNUM.columnNumber"
														:is-required="controls.CAMENUM_FLDS_CLASSNUM.isRequired"
														:readonly="controls.CAMENUM_FLDS_CLASSNUM.readonly"
														:options-list="controls.CAMENUM_FLDS_CLASSNUM.items"
														@update:model-value="model.ValClassnum.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CAMENUM_FLDS_CLASS___.isVisible">
											<q-control-wrapper
												v-show="controls.CAMENUM_FLDS_CLASS___.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMENUM_FLDS_CLASS___"
													v-on="controls.CAMENUM_FLDS_CLASS___.handlers"
													:loading="controls.CAMENUM_FLDS_CLASS___.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-select
														v-if="controls.CAMENUM_FLDS_CLASS___.isVisible"
														v-bind="controls.CAMENUM_FLDS_CLASS___.props"
														:model-value="model.ValClass.value"
														@update:model-value="model.ValClass.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CAMENUM_FLDS_LOGICENU.isVisible">
											<q-control-wrapper
												v-show="controls.CAMENUM_FLDS_LOGICENU.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-checkbox"
													v-bind="controls.CAMENUM_FLDS_LOGICENU"
													v-on="controls.CAMENUM_FLDS_LOGICENU.handlers"
													:loading="controls.CAMENUM_FLDS_LOGICENU.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-toggle-input
														v-if="controls.CAMENUM_FLDS_LOGICENU.isVisible"
														id="CAMENUM_FLDS_LOGICENU"
														:model-value="model.ValLogicenu.value"
														:true-label="controls.CAMENUM_FLDS_LOGICENU.trueLabel"
														:false-label="controls.CAMENUM_FLDS_LOGICENU.falseLabel"
														:readonly="controls.CAMENUM_FLDS_LOGICENU.readonly"
														@update:model-value="model.ValLogicenu.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
									</div>
								</section>
								<section
									v-if="controls.LISTACAMPSEUDCAMDOCS_.isVisible"
									v-show="controls.formTabs.selectedTab === 'LISTACAMPSEUDCAMDOCS_'">
									<div id="LISTACAMPSEUDCAMDOCS_">
										<q-row-container v-show="controls.CAMDOCS_FLDS_LOGO____.isVisible">
											<q-control-wrapper
												v-show="controls.CAMDOCS_FLDS_LOGO____.isVisible"
												class="control-join-group">
												<base-input-structure
													class="q-image"
													v-bind="controls.CAMDOCS_FLDS_LOGO____"
													v-on="controls.CAMDOCS_FLDS_LOGO____.handlers"
													:loading="controls.CAMDOCS_FLDS_LOGO____.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-image
														v-if="controls.CAMDOCS_FLDS_LOGO____.isVisible"
														v-bind="controls.CAMDOCS_FLDS_LOGO____.props"
														v-on="controls.CAMDOCS_FLDS_LOGO____.handlers" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CAMDOCS_FLDS_ATTACH__.isVisible">
											<q-control-wrapper
												v-show="controls.CAMDOCS_FLDS_ATTACH__.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMDOCS_FLDS_ATTACH__"
													v-on="controls.CAMDOCS_FLDS_ATTACH__.handlers"
													:loading="controls.CAMDOCS_FLDS_ATTACH__.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-document
														v-if="controls.CAMDOCS_FLDS_ATTACH__.isVisible"
														id="CAMDOCS_FLDS_ATTACH__"
														size="large"
														:model-value="model.ValAttach.value"
														versioning-is-on
														:readonly="controls.CAMDOCS_FLDS_ATTACH__.readonly"
														:is-in-checkout="controls.CAMDOCS_FLDS_ATTACH__.isInCheckout"
														:current-version="controls.CAMDOCS_FLDS_ATTACH__.currentVersion"
														:extensions="controls.CAMDOCS_FLDS_ATTACH__.extensions"
														:max-file-size="controls.CAMDOCS_FLDS_ATTACH__.maxFileSize"
														:versions="controls.CAMDOCS_FLDS_ATTACH__.documentVersions"
														:versions-info="controls.CAMDOCS_FLDS_ATTACH__.versionsInfo"
														:file-properties="controls.CAMDOCS_FLDS_ATTACH__.fileProperties"
														:texts="controls.CAMDOCS_FLDS_ATTACH__.texts"
														:popup-is-visible="controls.CAMDOCS_FLDS_ATTACH__.popupIsVisible"
														:disallow-removal="controls.CAMDOCS_FLDS_ATTACH__.isRequired"
														:resources-path="controls.CAMDOCS_FLDS_ATTACH__.resourcesPath"
														:uses-templates="controls.CAMDOCS_FLDS_ATTACH__.usesTemplates"
														@file-error="controls.CAMDOCS_FLDS_ATTACH__.HandleFileError($event)"
														@submit-file="controls.CAMDOCS_FLDS_ATTACH__.SetFile($event)"
														@edit-file="controls.CAMDOCS_FLDS_ATTACH__.SetCheckoutState()"
														@get-properties="controls.CAMDOCS_FLDS_ATTACH__.GetFileProperties()"
														@get-version-history="controls.CAMDOCS_FLDS_ATTACH__.GetVersionsInfo()"
														@get-file="controls.CAMDOCS_FLDS_ATTACH__.GetFile()"
														@download-file="controls.CAMDOCS_FLDS_ATTACH__.DownloadFile()"
														@get-file-version="controls.CAMDOCS_FLDS_ATTACH__.GetFileVersion($event)"
														@delete-last="controls.CAMDOCS_FLDS_ATTACH__.DeleteFile(0)"
														@delete-history="controls.CAMDOCS_FLDS_ATTACH__.DeleteFile(1)"
														@delete-file="controls.CAMDOCS_FLDS_ATTACH__.DeleteFile(2)"
														@show-popup="controls.CAMDOCS_FLDS_ATTACH__.SetModal($event)"
														@hide-popup="controls.CAMDOCS_FLDS_ATTACH__.RemoveModal($event)"
														@show-templates-popup="controls.CAMDOCS_FLDS_ATTACH__.handleDocumentTemplates($event)" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
									</div>
								</section>
								<section
									v-if="controls.LISTACAMPSEUDCAMAUDIT.isVisible"
									v-show="controls.formTabs.selectedTab === 'LISTACAMPSEUDCAMAUDIT'">
									<div id="LISTACAMPSEUDCAMAUDIT">
										<q-row-container v-show="controls.CAMAUDITFLDS_CREATUSE.isVisible">
											<q-control-wrapper
												v-show="controls.CAMAUDITFLDS_CREATUSE.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMAUDITFLDS_CREATUSE"
													v-on="controls.CAMAUDITFLDS_CREATUSE.handlers"
													:loading="controls.CAMAUDITFLDS_CREATUSE.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-text-field
														v-bind="controls.CAMAUDITFLDS_CREATUSE.props"
														:model-value="model.ValCreatuse.value" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CAMAUDITFLDS_CREATDAT.isVisible">
											<q-control-wrapper
												v-show="controls.CAMAUDITFLDS_CREATDAT.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMAUDITFLDS_CREATDAT"
													v-on="controls.CAMAUDITFLDS_CREATDAT.handlers"
													:loading="controls.CAMAUDITFLDS_CREATDAT.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-datetime-input
														v-if="controls.CAMAUDITFLDS_CREATDAT.isVisible"
														v-bind="controls.CAMAUDITFLDS_CREATDAT"
														format="Date"
														:model-value="model.ValCreatdat.value"
														@update:model-value="model.ValCreatdat.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CAMAUDITFLDS_CREATHOU.isVisible">
											<q-control-wrapper
												v-show="controls.CAMAUDITFLDS_CREATHOU.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMAUDITFLDS_CREATHOU"
													v-on="controls.CAMAUDITFLDS_CREATHOU.handlers"
													:loading="controls.CAMAUDITFLDS_CREATHOU.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-datetime-input
														v-if="controls.CAMAUDITFLDS_CREATHOU.isVisible"
														v-bind="controls.CAMAUDITFLDS_CREATHOU"
														format="Time"
														:model-value="model.ValCreathou.value"
														@update:model-value="model.ValCreathou.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.CAMAUDITFLDS_CREATINS.isVisible">
											<q-control-wrapper
												v-show="controls.CAMAUDITFLDS_CREATINS.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.CAMAUDITFLDS_CREATINS"
													v-on="controls.CAMAUDITFLDS_CREATINS.handlers"
													:loading="controls.CAMAUDITFLDS_CREATINS.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-datetime-input
														v-if="controls.CAMAUDITFLDS_CREATINS.isVisible"
														v-bind="controls.CAMAUDITFLDS_CREATINS"
														format="DateTimeSeconds"
														:model-value="model.ValCreatins.value"
														@update:model-value="model.ValCreatins.fnUpdateValue" />
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

	import FormViewModel from './QFormListacamViewModel.js'

	const requiredTextResources = ['QFormListacam', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS LISTACAM]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormListacam',

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
				default: () => {
					return {
						name: 'LISTACAM',
						location: 'form-LISTACAM',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormListacam', false),

				interfaceMetadata: {
					id: 'QFormListacam', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'LISTACAM',
					route: 'form-LISTACAM',
					area: 'FLDS',
					primaryKey: 'ValCodflds',
					designation: computed(() => this.Resources.FIELD_LIST48027),
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
					LISTACAMPSEUDCAMTEXTO: new fieldControlClass.TabControl({
						id: 'LISTACAMPSEUDCAMTEXTO',
						name: 'CAMTEXTO',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.TEXT_FIELDS40102),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						openingEvent: 'opened-LISTACAMPSEUDCAMTEXTO',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					LISTACAMPSEUDCAMNUM__: new fieldControlClass.TabControl({
						id: 'LISTACAMPSEUDCAMNUM__',
						name: 'CAMNUM',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.NUMERIC_FIELDS45771),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						openingEvent: 'opened-LISTACAMPSEUDCAMNUM__',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					LISTACAMPSEUDCAMDATE_: new fieldControlClass.TabControl({
						id: 'LISTACAMPSEUDCAMDATE_',
						name: 'CAMDATE',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.DATE_FIELDS55234),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						openingEvent: 'opened-LISTACAMPSEUDCAMDATE_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					LISTACAMPSEUDCAMMASK_: new fieldControlClass.TabControl({
						id: 'LISTACAMPSEUDCAMMASK_',
						name: 'CAMMASK',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.INPUTS_WITH_MASKS08900),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						openingEvent: 'opened-LISTACAMPSEUDCAMMASK_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					LISTACAMPSEUDCAMENUM_: new fieldControlClass.TabControl({
						id: 'LISTACAMPSEUDCAMENUM_',
						name: 'CAMENUM',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.ENUMERATIONS_FIELDS36502),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						openingEvent: 'opened-LISTACAMPSEUDCAMENUM_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					LISTACAMPSEUDCAMDOCS_: new fieldControlClass.TabControl({
						id: 'LISTACAMPSEUDCAMDOCS_',
						name: 'CAMDOCS',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.EXTERNAL_DOCS_FIELDS46956),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						openingEvent: 'opened-LISTACAMPSEUDCAMDOCS_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					LISTACAMPSEUDCAMAUDIT: new fieldControlClass.TabControl({
						id: 'LISTACAMPSEUDCAMAUDIT',
						name: 'CAMAUDIT',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.DATA_AUDIT01314),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						openingEvent: 'opened-LISTACAMPSEUDCAMAUDIT',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMTEXTOFLDS_TXTFIELD: new fieldControlClass.StringControl({
						modelField: 'ValTxtfield',
						valueChangeEvent: 'fieldChange:flds.txtfield',
						id: 'CAMTEXTOFLDS_TXTFIELD',
						name: 'TXTFIELD',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.TEXT_FIELD41810),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMTEXTO',
						tab: 'LISTACAMPSEUDCAMTEXTO',
						maxLength: 50,
						labelId: 'label_CAMTEXTOFLDS_TXTFIELD',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMTEXTOFLDS_DESCRIP_: new fieldControlClass.StringControl({
						modelField: 'ValDescrip',
						valueChangeEvent: 'fieldChange:flds.descrip',
						id: 'CAMTEXTOFLDS_DESCRIP_',
						name: 'DESCRIP',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.DESCRIPTION07383),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMTEXTO',
						tab: 'LISTACAMPSEUDCAMTEXTO',
						maxLength: 300,
						labelId: 'label_CAMTEXTOFLDS_DESCRIP_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMNUM__FLDS_NPASSAGE: new fieldControlClass.NumberControl({
						modelField: 'ValNpassage',
						valueChangeEvent: 'fieldChange:flds.npassage',
						maxIntegers: 3,
						maxDecimals: 0,
						id: 'CAMNUM__FLDS_NPASSAGE',
						name: 'NPASSAGE',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.NUMERIC19292),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMNUM__',
						tab: 'LISTACAMPSEUDCAMNUM__',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMNUM__FLDS_DURATION: new fieldControlClass.NumberControl({
						modelField: 'ValDuration',
						valueChangeEvent: 'fieldChange:flds.duration',
						maxIntegers: 2,
						maxDecimals: 2,
						id: 'CAMNUM__FLDS_DURATION',
						name: 'DURATION',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.NUMERIC_DECIMAL37352),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMNUM__',
						tab: 'LISTACAMPSEUDCAMNUM__',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMNUM__FLDS_PRICE___: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrice',
						valueChangeEvent: 'fieldChange:flds.price',
						maxIntegers: 3,
						maxDecimals: 2,
						id: 'CAMNUM__FLDS_PRICE___',
						name: 'PRICE',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.CURRENCY13881),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMNUM__',
						tab: 'LISTACAMPSEUDCAMNUM__',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMNUM__FLDS_PRECOBIL: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrecobil',
						valueChangeEvent: 'fieldChange:flds.precobil',
						maxIntegers: 3,
						maxDecimals: 2,
						id: 'CAMNUM__FLDS_PRECOBIL',
						name: 'PRECOBIL',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.CURRENCY_DECIMAL48296),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMNUM__',
						tab: 'LISTACAMPSEUDCAMNUM__',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMDATE_FLDS_YEAR____: new fieldControlClass.NumberControl({
						modelField: 'ValYear',
						valueChangeEvent: 'fieldChange:flds.year',
						maxIntegers: 4,
						maxDecimals: 0,
						id: 'CAMDATE_FLDS_YEAR____',
						name: 'YEAR',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.YEAR61794),
						userHelp: computed(() => this.Resources.___3161967),
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMDATE_',
						tab: 'LISTACAMPSEUDCAMDATE_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMDATE_FLDS_DATE____: new fieldControlClass.DateControl({
						modelField: 'ValDate',
						valueChangeEvent: 'fieldChange:flds.date',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'CAMDATE_FLDS_DATE____',
						name: 'DATE',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.DATE18475),
						userHelp: computed(() => this.Resources.___3261074),
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMDATE_',
						tab: 'LISTACAMPSEUDCAMDATE_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMDATE_FLDS_DATETIME: new fieldControlClass.DateControl({
						modelField: 'ValDatetime',
						valueChangeEvent: 'fieldChange:flds.datetime',
						id: 'CAMDATE_FLDS_DATETIME',
						name: 'DATETIME',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.DATE_TIME53960),
						userHelp: computed(() => this.Resources.___3360901),
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMDATE_',
						tab: 'LISTACAMPSEUDCAMDATE_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMDATE_FLDS_DATESECO: new fieldControlClass.DateControl({
						modelField: 'ValDateseco',
						valueChangeEvent: 'fieldChange:flds.dateseco',
						id: 'CAMDATE_FLDS_DATESECO',
						name: 'DATESECO',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.DATE_SECONDS65191),
						userHelp: computed(() => this.Resources.___3465504),
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMDATE_',
						tab: 'LISTACAMPSEUDCAMDATE_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMDATE_FLDS_TIME____: new fieldControlClass.TimeControl({
						modelField: 'ValTime',
						valueChangeEvent: 'fieldChange:flds.time',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'CAMDATE_FLDS_TIME____',
						name: 'TIME',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.TIME15328),
						userHelp: computed(() => this.Resources.___3561555),
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMDATE_',
						tab: 'LISTACAMPSEUDCAMDATE_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMMASK_FLDS_ZIPFIELD: new fieldControlClass.MaskControl({
						modelField: 'ValZipfield',
						valueChangeEvent: 'fieldChange:flds.zipfield',
						id: 'CAMMASK_FLDS_ZIPFIELD',
						name: 'ZIPFIELD',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.ZIPCODE21021),
						userHelp: '',
						description: '',
						placeholder: computed(() => this.Resources.XXXX_XXX51420),
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMMASK_',
						tab: 'LISTACAMPSEUDCAMMASK_',
						maxLength: 8,
						labelId: 'label_CAMMASK_FLDS_ZIPFIELD',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMMASK_FLDS_VATNUMBR: new fieldControlClass.MaskControl({
						modelField: 'ValVatnumbr',
						valueChangeEvent: 'fieldChange:flds.vatnumbr',
						id: 'CAMMASK_FLDS_VATNUMBR',
						name: 'VATNUMBR',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.VAT_NUMBER24236),
						userHelp: '',
						description: '',
						placeholder: computed(() => this.Resources._12345678953785),
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMMASK_',
						tab: 'LISTACAMPSEUDCAMMASK_',
						maxLength: 9,
						labelId: 'label_CAMMASK_FLDS_VATNUMBR',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMMASK_FLDS_LICPLATE: new fieldControlClass.MaskControl({
						modelField: 'ValLicplate',
						valueChangeEvent: 'fieldChange:flds.licplate',
						id: 'CAMMASK_FLDS_LICPLATE',
						name: 'LICPLATE',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.LICENCE_PLATE07627),
						userHelp: '',
						description: '',
						placeholder: computed(() => this.Resources.XX_00_XX10122),
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMMASK_',
						tab: 'LISTACAMPSEUDCAMMASK_',
						maxLength: 8,
						labelId: 'label_CAMMASK_FLDS_LICPLATE',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMMASK_FLDS_SSNUMBER: new fieldControlClass.MaskControl({
						modelField: 'ValSsnumber',
						valueChangeEvent: 'fieldChange:flds.ssnumber',
						id: 'CAMMASK_FLDS_SSNUMBER',
						name: 'SSNUMBER',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.SOCIAL_SECURITY_NO48150),
						userHelp: '',
						description: '',
						placeholder: computed(() => this.Resources._1234567891237929),
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMMASK_',
						tab: 'LISTACAMPSEUDCAMMASK_',
						maxLength: 11,
						labelId: 'label_CAMMASK_FLDS_SSNUMBER',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMMASK_FLDS_BANKNMBR: new fieldControlClass.MaskControl({
						modelField: 'ValBanknmbr',
						valueChangeEvent: 'fieldChange:flds.banknmbr',
						id: 'CAMMASK_FLDS_BANKNMBR',
						name: 'BANKNMBR',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.BANKING_ACCOUNT_NUMB62548),
						userHelp: '',
						description: '',
						placeholder: computed(() => this.Resources._1234_5678_90123456761043),
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMMASK_',
						tab: 'LISTACAMPSEUDCAMMASK_',
						maxLength: 24,
						labelId: 'label_CAMMASK_FLDS_BANKNMBR',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMMASK_FLDS_EMAILFLD: new fieldControlClass.MaskControl({
						modelField: 'ValEmailfld',
						valueChangeEvent: 'fieldChange:flds.emailfld',
						id: 'CAMMASK_FLDS_EMAILFLD',
						name: 'EMAILFLD',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.EMAIL25170),
						userHelp: '',
						description: '',
						placeholder: computed(() => this.Resources.QUIDGESTAT_QUIDGEST_PT47872),
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMMASK_',
						tab: 'LISTACAMPSEUDCAMMASK_',
						maxLength: 50,
						labelId: 'label_CAMMASK_FLDS_EMAILFLD',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMMASK_FLDS_IBANFIEL: new fieldControlClass.MaskControl({
						modelField: 'ValIbanfiel',
						valueChangeEvent: 'fieldChange:flds.ibanfiel',
						id: 'CAMMASK_FLDS_IBANFIEL',
						name: 'IBANFIEL',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.IBAN28506),
						userHelp: '',
						description: '',
						placeholder: computed(() => this.Resources.PT12345678901234567820477),
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMMASK_',
						tab: 'LISTACAMPSEUDCAMMASK_',
						maxLength: 34,
						labelId: 'label_CAMMASK_FLDS_IBANFIEL',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMMASK_FLDS_UPPRTEXT: new fieldControlClass.MaskControl({
						modelField: 'ValUpprtext',
						valueChangeEvent: 'fieldChange:flds.upprtext',
						id: 'CAMMASK_FLDS_UPPRTEXT',
						name: 'UPPRTEXT',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.UPPERCASE48238),
						userHelp: '',
						description: '',
						placeholder: computed(() => this.Resources.QUIDGEST56322),
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMMASK_',
						tab: 'LISTACAMPSEUDCAMMASK_',
						maxLength: 50,
						labelId: 'label_CAMMASK_FLDS_UPPRTEXT',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMENUM_FLDS_CLASSNUM: new fieldControlClass.ArrayNumberControl({
						modelField: 'ValClassnum',
						valueChangeEvent: 'fieldChange:flds.classnum',
						maxIntegers: 1,
						maxDecimals: 0,
						id: 'CAMENUM_FLDS_CLASSNUM',
						name: 'CLASSNUM',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.NUMERIC_ENUMERATION46756),
						userHelp: computed(() => this.Resources.___1845555),
						description: '',
						placeholder: '',
						labelPosition: '',
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMENUM_',
						tab: 'LISTACAMPSEUDCAMENUM_',
						arrayName: 'CLASSNUM',
						columnNumber: 3,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMENUM_FLDS_CLASS___: new fieldControlClass.ArrayStringControl({
						modelField: 'ValClass',
						valueChangeEvent: 'fieldChange:flds.class',
						id: 'CAMENUM_FLDS_CLASS___',
						name: 'CLASS',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.TEXT_ENUMERATION45668),
						userHelp: computed(() => this.Resources.___2712722),
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMENUM_',
						tab: 'LISTACAMPSEUDCAMENUM_',
						maxLength: 2,
						labelId: 'label_CAMENUM_FLDS_CLASS___',
						arrayName: 'CLASS',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMENUM_FLDS_LOGICENU: new fieldControlClass.ArrayBooleanControl({
						modelField: 'ValLogicenu',
						valueChangeEvent: 'fieldChange:flds.logicenu',
						id: 'CAMENUM_FLDS_LOGICENU',
						name: 'LOGICENU',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.LOGICAL_ENUMERATION30276),
						userHelp: computed(() => this.Resources.___2813103),
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMENUM_',
						tab: 'LISTACAMPSEUDCAMENUM_',
						arrayName: 'PRIMVIAG',
						trueLabel: computed(() => this.Resources.YES34196),
						falseLabel: computed(() => this.Resources.NO57340),
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMDOCS_FLDS_LOGO____: new fieldControlClass.ImageControl({
						modelField: 'ValLogo',
						valueChangeEvent: 'fieldChange:flds.logo',
						id: 'CAMDOCS_FLDS_LOGO____',
						name: 'LOGO',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.LOGO62483),
						userHelp: computed(() => this.Resources.___2916088),
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMDOCS_',
						tab: 'LISTACAMPSEUDCAMDOCS_',
						height: 50,
						width: 100,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMDOCS_FLDS_ATTACH__: new fieldControlClass.DocumentControl({
						modelField: 'ValAttach',
						valueChangeEvent: 'fieldChange:flds.attach',
						id: 'CAMDOCS_FLDS_ATTACH__',
						name: 'ATTACH',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.ATTACHMENTS19612),
						userHelp: computed(() => this.Resources.___3061884),
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMDOCS_',
						tab: 'LISTACAMPSEUDCAMDOCS_',
						documentProperties: computed(() => vm.model.ValAttachPropertiesVM),
						documentFK: computed(() => vm.model.ValAttachfk),
						documentVersions: computed(() => vm.model.ValAttachPropertiesVM.value ? vm.model.ValAttachPropertiesVM.value.Versions : {}),
						isInCheckout: computed(() => vm.model.ValAttachPropertiesVM.value ? vm.model.ValAttachPropertiesVM.value.IsCheckout : false),
						currentVersion: computed(() => vm.model.ValAttachPropertiesVM.value ? vm.model.ValAttachPropertiesVM.value.Version : '1'),
						usesTemplates: false,
						extensions: [],
						viewType: qEnums.documentViewTypeMode.Preview,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					CAMAUDITFLDS_CREATUSE: new fieldControlClass.StringControl({
						modelField: 'ValCreatuse',
						valueChangeEvent: 'fieldChange:flds.creatuse',
						id: 'CAMAUDITFLDS_CREATUSE',
						name: 'CREATUSE',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.CREATED_BY12292),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMAUDIT',
						tab: 'LISTACAMPSEUDCAMAUDIT',
						maxLength: 20,
						labelId: 'label_CAMAUDITFLDS_CREATUSE',
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					CAMAUDITFLDS_CREATDAT: new fieldControlClass.DateControl({
						modelField: 'ValCreatdat',
						valueChangeEvent: 'fieldChange:flds.creatdat',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'CAMAUDITFLDS_CREATDAT',
						name: 'CREATDAT',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.DATE_OF_CREATION49487),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMAUDIT',
						tab: 'LISTACAMPSEUDCAMAUDIT',
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					CAMAUDITFLDS_CREATHOU: new fieldControlClass.TimeControl({
						modelField: 'ValCreathou',
						valueChangeEvent: 'fieldChange:flds.creathou',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'CAMAUDITFLDS_CREATHOU',
						name: 'CREATHOU',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.CREATION_HOUR49876),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMAUDIT',
						tab: 'LISTACAMPSEUDCAMAUDIT',
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					CAMAUDITFLDS_CREATINS: new fieldControlClass.DateControl({
						modelField: 'ValCreatins',
						valueChangeEvent: 'fieldChange:flds.creatins',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'CAMAUDITFLDS_CREATINS',
						name: 'CREATINS',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.COMPLETE_DATE_OF_CRE57046),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-LISTACAMPSEUDCAMAUDIT',
						tab: 'LISTACAMPSEUDCAMAUDIT',
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					formTabs: new fieldControlClass.TabsControl({
						tabControlsIds: readonly([
							'LISTACAMPSEUDCAMTEXTO',
							'LISTACAMPSEUDCAMNUM__',
							'LISTACAMPSEUDCAMDATE_',
							'LISTACAMPSEUDCAMMASK_',
							'LISTACAMPSEUDCAMENUM_',
							'LISTACAMPSEUDCAMDOCS_',
							'LISTACAMPSEUDCAMAUDIT',
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
					'LISTACAMPSEUDCAMTEXTO',
					'LISTACAMPSEUDCAMNUM__',
					'LISTACAMPSEUDCAMDATE_',
					'LISTACAMPSEUDCAMMASK_',
					'LISTACAMPSEUDCAMENUM_',
					'LISTACAMPSEUDCAMDOCS_',
					'LISTACAMPSEUDCAMAUDIT',
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Flds: {
						get ValAttach() { return vm.model.ValAttach.value },
						set ValAttach(value) { vm.model.ValAttach.updateValue(value) },
						get ValBanknmbr() { return vm.model.ValBanknmbr.value },
						set ValBanknmbr(value) { vm.model.ValBanknmbr.updateValue(value) },
						get ValClass() { return vm.model.ValClass.value },
						set ValClass(value) { vm.model.ValClass.updateValue(value) },
						get ValClassnum() { return vm.model.ValClassnum.value },
						set ValClassnum(value) { vm.model.ValClassnum.updateValue(value) },
						get ValCodaero() { return vm.model.ValCodaero.value },
						set ValCodaero(value) { vm.model.ValCodaero.updateValue(value) },
						get ValCodequip() { return vm.model.ValCodequip.value },
						set ValCodequip(value) { vm.model.ValCodequip.updateValue(value) },
						get ValCreatdat() { return vm.model.ValCreatdat.value },
						set ValCreatdat(value) { vm.model.ValCreatdat.updateValue(value) },
						get ValCreathou() { return vm.model.ValCreathou.value },
						set ValCreathou(value) { vm.model.ValCreathou.updateValue(value) },
						get ValCreatins() { return vm.model.ValCreatins.value },
						set ValCreatins(value) { vm.model.ValCreatins.updateValue(value) },
						get ValCreatuse() { return vm.model.ValCreatuse.value },
						set ValCreatuse(value) { vm.model.ValCreatuse.updateValue(value) },
						get ValDate() { return vm.model.ValDate.value },
						set ValDate(value) { vm.model.ValDate.updateValue(value) },
						get ValDateseco() { return vm.model.ValDateseco.value },
						set ValDateseco(value) { vm.model.ValDateseco.updateValue(value) },
						get ValDatetime() { return vm.model.ValDatetime.value },
						set ValDatetime(value) { vm.model.ValDatetime.updateValue(value) },
						get ValDescrip() { return vm.model.ValDescrip.value },
						set ValDescrip(value) { vm.model.ValDescrip.updateValue(value) },
						get ValDuration() { return vm.model.ValDuration.value },
						set ValDuration(value) { vm.model.ValDuration.updateValue(value) },
						get ValEmailfld() { return vm.model.ValEmailfld.value },
						set ValEmailfld(value) { vm.model.ValEmailfld.updateValue(value) },
						get ValIbanfiel() { return vm.model.ValIbanfiel.value },
						set ValIbanfiel(value) { vm.model.ValIbanfiel.updateValue(value) },
						get ValLicplate() { return vm.model.ValLicplate.value },
						set ValLicplate(value) { vm.model.ValLicplate.updateValue(value) },
						get ValLogicenu() { return vm.model.ValLogicenu.value },
						set ValLogicenu(value) { vm.model.ValLogicenu.updateValue(value) },
						get ValLogo() { return vm.model.ValLogo.value },
						set ValLogo(value) { vm.model.ValLogo.updateValue(value) },
						get ValNpassage() { return vm.model.ValNpassage.value },
						set ValNpassage(value) { vm.model.ValNpassage.updateValue(value) },
						get ValPrecobil() { return vm.model.ValPrecobil.value },
						set ValPrecobil(value) { vm.model.ValPrecobil.updateValue(value) },
						get ValPrice() { return vm.model.ValPrice.value },
						set ValPrice(value) { vm.model.ValPrice.updateValue(value) },
						get ValSsnumber() { return vm.model.ValSsnumber.value },
						set ValSsnumber(value) { vm.model.ValSsnumber.updateValue(value) },
						get ValTime() { return vm.model.ValTime.value },
						set ValTime(value) { vm.model.ValTime.updateValue(value) },
						get ValTxtfield() { return vm.model.ValTxtfield.value },
						set ValTxtfield(value) { vm.model.ValTxtfield.updateValue(value) },
						get ValUpprtext() { return vm.model.ValUpprtext.value },
						set ValUpprtext(value) { vm.model.ValUpprtext.updateValue(value) },
						get ValVatnumbr() { return vm.model.ValVatnumbr.value },
						set ValVatnumbr(value) { vm.model.ValVatnumbr.updateValue(value) },
						get ValYear() { return vm.model.ValYear.value },
						set ValYear(value) { vm.model.ValYear.updateValue(value) },
						get ValZipfield() { return vm.model.ValZipfield.value },
						set ValZipfield(value) { vm.model.ValZipfield.updateValue(value) },
					},
					keys: {
						/** The primary key of the FLDS table */
						get flds() { return vm.model.ValCodflds },
						/** The foreign key to the AERO table */
						get aero() { return vm.model.ValCodaero },
						/** The foreign key to the EQUIP table */
						get equip() { return vm.model.ValCodequip },
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
// USE /[MANUAL GQT FORM_CODEJS LISTACAM]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS LISTACAM]/
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
// USE /[MANUAL GQT FORM_LOADED_JS LISTACAM]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS LISTACAM]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS LISTACAM]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS LISTACAM]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS LISTACAM]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS LISTACAM]/
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
// USE /[MANUAL GQT AFTER_DEL_JS LISTACAM]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS LISTACAM]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS LISTACAM]/
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
// USE /[MANUAL GQT DLGUPDT LISTACAM]/
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
// USE /[MANUAL GQT CTRLUPD LISTACAM]/
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
