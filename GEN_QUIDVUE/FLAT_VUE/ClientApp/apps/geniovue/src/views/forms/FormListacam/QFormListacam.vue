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
				<component
					v-if="formControl.uiComponents.header && formInfo.designation"
					:is="topHeadingTag"
					:id="formTitleId"
					class="form-header">
					{{ formInfo.designation }}
				</component>

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
											:enabled="btn.badge?.isVisible ?? false"
											:color="btn.badge?.color">
											<q-icon v-bind="btn.icon" />
										</q-badge-indicator>
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
			data-key="LISTACAM"
			:data-identifier="primaryKeyValue"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.LISTACAMPSEUDCAMTEXTO.isVisible || controls.LISTACAMPSEUDCAMNUM__.isVisible || controls.LISTACAMPSEUDCAMDATE_.isVisible || controls.LISTACAMPSEUDCAMMASK_.isVisible || controls.LISTACAMPSEUDCAMENUM_.isVisible || controls.LISTACAMPSEUDCAMDOCS_.isVisible || controls.LISTACAMPSEUDCAMAUDIT.isVisible">
					<q-col
						v-if="controls.LISTACAMPSEUDCAMTEXTO.isVisible || controls.LISTACAMPSEUDCAMNUM__.isVisible || controls.LISTACAMPSEUDCAMDATE_.isVisible || controls.LISTACAMPSEUDCAMMASK_.isVisible || controls.LISTACAMPSEUDCAMENUM_.isVisible || controls.LISTACAMPSEUDCAMDOCS_.isVisible || controls.LISTACAMPSEUDCAMAUDIT.isVisible"
						cols="auto">
						<q-tab-container
							v-if="controls.formTabs.isVisible"
							:id="getId('q-tabs-LISTACAM')"
							v-bind="controls.formTabs.props"
							@tab-changed="controls.formTabs.selectTab($event)">
							<section
								v-if="controls.LISTACAMPSEUDCAMTEXTO.isVisible"
								v-show="controls.formTabs.selectedTab === 'LISTACAMPSEUDCAMTEXTO'">
								<div
									id="LISTACAMPSEUDCAMTEXTO"
									role="tabpanel"
									aria-labelledby="q-tabs-LISTACAM-tab-LISTACAMPSEUDCAMTEXTO">
									<q-row v-if="controls.CAMTEXTOFLDS_TXTFIELD.isVisible">
										<q-col
											v-if="controls.CAMTEXTOFLDS_TXTFIELD.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMTEXTOFLDS_TXTFIELD.isVisible"
												class="i-text"
												v-bind="controls.CAMTEXTOFLDS_TXTFIELD.wrapperProps"
												:id="getControlId(controls.CAMTEXTOFLDS_TXTFIELD)"
												v-on="controls.CAMTEXTOFLDS_TXTFIELD.handlers"
												:loading="controls.CAMTEXTOFLDS_TXTFIELD.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-text-field
													v-bind="controls.CAMTEXTOFLDS_TXTFIELD.props"
													:id="getControlId(controls.CAMTEXTOFLDS_TXTFIELD)"
													@blur="onBlur(controls.CAMTEXTOFLDS_TXTFIELD, model.ValTxtfield.value)"
													@change="model.ValTxtfield.fnUpdateValueOnChange" />
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.CAMTEXTOFLDS_DESCRIP_.isVisible">
										<q-col
											v-if="controls.CAMTEXTOFLDS_DESCRIP_.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMTEXTOFLDS_DESCRIP_.isVisible"
												class="i-textarea"
												v-bind="controls.CAMTEXTOFLDS_DESCRIP_.wrapperProps"
												:id="getControlId(controls.CAMTEXTOFLDS_DESCRIP_)"
												v-on="controls.CAMTEXTOFLDS_DESCRIP_.handlers"
												:loading="controls.CAMTEXTOFLDS_DESCRIP_.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-text-area
													v-if="controls.CAMTEXTOFLDS_DESCRIP_.isVisible"
													v-bind="controls.CAMTEXTOFLDS_DESCRIP_.props"
													:id="getControlId(controls.CAMTEXTOFLDS_DESCRIP_)"
													v-on="controls.CAMTEXTOFLDS_DESCRIP_.handlers" />
											</base-input-structure>
										</q-col>
									</q-row>
								</div>
							</section>
							<section
								v-if="controls.LISTACAMPSEUDCAMNUM__.isVisible"
								v-show="controls.formTabs.selectedTab === 'LISTACAMPSEUDCAMNUM__'">
								<div
									id="LISTACAMPSEUDCAMNUM__"
									role="tabpanel"
									aria-labelledby="q-tabs-LISTACAM-tab-LISTACAMPSEUDCAMNUM__">
									<q-row v-if="controls.CAMNUM__FLDS_NPASSAGE.isVisible">
										<q-col
											v-if="controls.CAMNUM__FLDS_NPASSAGE.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMNUM__FLDS_NPASSAGE.isVisible"
												class="i-text"
												v-bind="controls.CAMNUM__FLDS_NPASSAGE.wrapperProps"
												:id="getControlId(controls.CAMNUM__FLDS_NPASSAGE)"
												v-on="controls.CAMNUM__FLDS_NPASSAGE.handlers"
												:loading="controls.CAMNUM__FLDS_NPASSAGE.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-numeric-input
													v-if="controls.CAMNUM__FLDS_NPASSAGE.isVisible"
													v-bind="controls.CAMNUM__FLDS_NPASSAGE.props"
													:id="getControlId(controls.CAMNUM__FLDS_NPASSAGE)"
													@update:model-value="model.ValNpassage.fnUpdateValue" />
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.CAMNUM__FLDS_DURATION.isVisible">
										<q-col
											v-if="controls.CAMNUM__FLDS_DURATION.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMNUM__FLDS_DURATION.isVisible"
												class="i-text"
												v-bind="controls.CAMNUM__FLDS_DURATION.wrapperProps"
												:id="getControlId(controls.CAMNUM__FLDS_DURATION)"
												v-on="controls.CAMNUM__FLDS_DURATION.handlers"
												:loading="controls.CAMNUM__FLDS_DURATION.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-numeric-input
													v-if="controls.CAMNUM__FLDS_DURATION.isVisible"
													v-bind="controls.CAMNUM__FLDS_DURATION.props"
													:id="getControlId(controls.CAMNUM__FLDS_DURATION)"
													@update:model-value="model.ValDuration.fnUpdateValue" />
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.CAMNUM__FLDS_PRICE___.isVisible">
										<q-col
											v-if="controls.CAMNUM__FLDS_PRICE___.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMNUM__FLDS_PRICE___.isVisible"
												class="i-text"
												v-bind="controls.CAMNUM__FLDS_PRICE___.wrapperProps"
												:id="getControlId(controls.CAMNUM__FLDS_PRICE___)"
												v-on="controls.CAMNUM__FLDS_PRICE___.handlers"
												:loading="controls.CAMNUM__FLDS_PRICE___.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-numeric-input
													v-if="controls.CAMNUM__FLDS_PRICE___.isVisible"
													v-bind="controls.CAMNUM__FLDS_PRICE___.props"
													:id="getControlId(controls.CAMNUM__FLDS_PRICE___)"
													@update:model-value="model.ValPrice.fnUpdateValue" />
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.CAMNUM__FLDS_PRECOBIL.isVisible">
										<q-col
											v-if="controls.CAMNUM__FLDS_PRECOBIL.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMNUM__FLDS_PRECOBIL.isVisible"
												class="i-text"
												v-bind="controls.CAMNUM__FLDS_PRECOBIL.wrapperProps"
												:id="getControlId(controls.CAMNUM__FLDS_PRECOBIL)"
												v-on="controls.CAMNUM__FLDS_PRECOBIL.handlers"
												:loading="controls.CAMNUM__FLDS_PRECOBIL.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-numeric-input
													v-if="controls.CAMNUM__FLDS_PRECOBIL.isVisible"
													v-bind="controls.CAMNUM__FLDS_PRECOBIL.props"
													:id="getControlId(controls.CAMNUM__FLDS_PRECOBIL)"
													@update:model-value="model.ValPrecobil.fnUpdateValue" />
											</base-input-structure>
										</q-col>
									</q-row>
								</div>
							</section>
							<section
								v-if="controls.LISTACAMPSEUDCAMDATE_.isVisible"
								v-show="controls.formTabs.selectedTab === 'LISTACAMPSEUDCAMDATE_'">
								<div
									id="LISTACAMPSEUDCAMDATE_"
									role="tabpanel"
									aria-labelledby="q-tabs-LISTACAM-tab-LISTACAMPSEUDCAMDATE_">
									<q-row v-if="controls.CAMDATE_FLDS_YEAR____.isVisible">
										<q-col
											v-if="controls.CAMDATE_FLDS_YEAR____.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMDATE_FLDS_YEAR____.isVisible"
												class="i-text"
												v-bind="controls.CAMDATE_FLDS_YEAR____.wrapperProps"
												:id="getControlId(controls.CAMDATE_FLDS_YEAR____)"
												v-on="controls.CAMDATE_FLDS_YEAR____.handlers"
												:loading="controls.CAMDATE_FLDS_YEAR____.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-numeric-input
													v-if="controls.CAMDATE_FLDS_YEAR____.isVisible"
													v-bind="controls.CAMDATE_FLDS_YEAR____.props"
													:id="getControlId(controls.CAMDATE_FLDS_YEAR____)"
													@update:model-value="model.ValYear.fnUpdateValue" />
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.CAMDATE_FLDS_DATE____.isVisible">
										<q-col
											v-if="controls.CAMDATE_FLDS_DATE____.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMDATE_FLDS_DATE____.isVisible"
												class="i-text"
												v-bind="controls.CAMDATE_FLDS_DATE____.wrapperProps"
												:id="getControlId(controls.CAMDATE_FLDS_DATE____)"
												v-on="controls.CAMDATE_FLDS_DATE____.handlers"
												:loading="controls.CAMDATE_FLDS_DATE____.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-date-time-picker
													v-if="controls.CAMDATE_FLDS_DATE____.isVisible"
													v-bind="controls.CAMDATE_FLDS_DATE____.props"
													:id="getControlId(controls.CAMDATE_FLDS_DATE____)"
													:model-value="model.ValDate.value"
													@reset-icon-click="model.ValDate.fnUpdateValue(model.ValDate.originalValue ?? new Date())"
													@update:model-value="model.ValDate.fnUpdateValue($event ?? '')" />
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.CAMDATE_FLDS_DATETIME.isVisible">
										<q-col
											v-if="controls.CAMDATE_FLDS_DATETIME.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMDATE_FLDS_DATETIME.isVisible"
												class="i-text"
												v-bind="controls.CAMDATE_FLDS_DATETIME.wrapperProps"
												:id="getControlId(controls.CAMDATE_FLDS_DATETIME)"
												v-on="controls.CAMDATE_FLDS_DATETIME.handlers"
												:loading="controls.CAMDATE_FLDS_DATETIME.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-date-time-picker
													v-if="controls.CAMDATE_FLDS_DATETIME.isVisible"
													v-bind="controls.CAMDATE_FLDS_DATETIME.props"
													:id="getControlId(controls.CAMDATE_FLDS_DATETIME)"
													:model-value="model.ValDatetime.value"
													@reset-icon-click="model.ValDatetime.fnUpdateValue(model.ValDatetime.originalValue ?? new Date())"
													@update:model-value="model.ValDatetime.fnUpdateValue($event ?? '')" />
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.CAMDATE_FLDS_DATESECO.isVisible">
										<q-col
											v-if="controls.CAMDATE_FLDS_DATESECO.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMDATE_FLDS_DATESECO.isVisible"
												class="i-text"
												v-bind="controls.CAMDATE_FLDS_DATESECO.wrapperProps"
												:id="getControlId(controls.CAMDATE_FLDS_DATESECO)"
												v-on="controls.CAMDATE_FLDS_DATESECO.handlers"
												:loading="controls.CAMDATE_FLDS_DATESECO.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-date-time-picker
													v-if="controls.CAMDATE_FLDS_DATESECO.isVisible"
													v-bind="controls.CAMDATE_FLDS_DATESECO.props"
													:id="getControlId(controls.CAMDATE_FLDS_DATESECO)"
													:model-value="model.ValDateseco.value"
													@reset-icon-click="model.ValDateseco.fnUpdateValue(model.ValDateseco.originalValue ?? new Date())"
													@update:model-value="model.ValDateseco.fnUpdateValue($event ?? '')" />
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.CAMDATE_FLDS_TIME____.isVisible">
										<q-col
											v-if="controls.CAMDATE_FLDS_TIME____.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMDATE_FLDS_TIME____.isVisible"
												class="i-text"
												v-bind="controls.CAMDATE_FLDS_TIME____.wrapperProps"
												:id="getControlId(controls.CAMDATE_FLDS_TIME____)"
												v-on="controls.CAMDATE_FLDS_TIME____.handlers"
												:loading="controls.CAMDATE_FLDS_TIME____.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-date-time-picker
													v-if="controls.CAMDATE_FLDS_TIME____.isVisible"
													v-bind="controls.CAMDATE_FLDS_TIME____.props"
													:id="getControlId(controls.CAMDATE_FLDS_TIME____)"
													:model-value="model.ValTime.value"
													@reset-icon-click="model.ValTime.fnUpdateValue(model.ValTime.originalValue ?? new Date())"
													@update:model-value="model.ValTime.fnUpdateValue($event ?? '')" />
											</base-input-structure>
										</q-col>
									</q-row>
								</div>
							</section>
							<section
								v-if="controls.LISTACAMPSEUDCAMMASK_.isVisible"
								v-show="controls.formTabs.selectedTab === 'LISTACAMPSEUDCAMMASK_'">
								<div
									id="LISTACAMPSEUDCAMMASK_"
									role="tabpanel"
									aria-labelledby="q-tabs-LISTACAM-tab-LISTACAMPSEUDCAMMASK_">
									<q-row v-if="controls.CAMMASK_FLDS_ZIPFIELD.isVisible">
										<q-col
											v-if="controls.CAMMASK_FLDS_ZIPFIELD.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMMASK_FLDS_ZIPFIELD.isVisible"
												class="i-text"
												v-bind="controls.CAMMASK_FLDS_ZIPFIELD.wrapperProps"
												:id="getControlId(controls.CAMMASK_FLDS_ZIPFIELD)"
												v-on="controls.CAMMASK_FLDS_ZIPFIELD.handlers"
												:loading="controls.CAMMASK_FLDS_ZIPFIELD.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-mask
													v-if="controls.CAMMASK_FLDS_ZIPFIELD.isVisible"
													v-bind="controls.CAMMASK_FLDS_ZIPFIELD.props"
													:id="getControlId(controls.CAMMASK_FLDS_ZIPFIELD)"
													:model-value="model.ValZipfield.value"
													@change="model.ValZipfield.fnUpdateValueOnChange" />
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.CAMMASK_FLDS_VATNUMBR.isVisible">
										<q-col
											v-if="controls.CAMMASK_FLDS_VATNUMBR.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMMASK_FLDS_VATNUMBR.isVisible"
												class="i-text"
												v-bind="controls.CAMMASK_FLDS_VATNUMBR.wrapperProps"
												:id="getControlId(controls.CAMMASK_FLDS_VATNUMBR)"
												v-on="controls.CAMMASK_FLDS_VATNUMBR.handlers"
												:loading="controls.CAMMASK_FLDS_VATNUMBR.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-mask
													v-if="controls.CAMMASK_FLDS_VATNUMBR.isVisible"
													v-bind="controls.CAMMASK_FLDS_VATNUMBR.props"
													:id="getControlId(controls.CAMMASK_FLDS_VATNUMBR)"
													:model-value="model.ValVatnumbr.value"
													@change="model.ValVatnumbr.fnUpdateValueOnChange" />
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.CAMMASK_FLDS_LICPLATE.isVisible">
										<q-col
											v-if="controls.CAMMASK_FLDS_LICPLATE.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMMASK_FLDS_LICPLATE.isVisible"
												class="i-text"
												v-bind="controls.CAMMASK_FLDS_LICPLATE.wrapperProps"
												:id="getControlId(controls.CAMMASK_FLDS_LICPLATE)"
												v-on="controls.CAMMASK_FLDS_LICPLATE.handlers"
												:loading="controls.CAMMASK_FLDS_LICPLATE.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-mask
													v-if="controls.CAMMASK_FLDS_LICPLATE.isVisible"
													v-bind="controls.CAMMASK_FLDS_LICPLATE.props"
													:id="getControlId(controls.CAMMASK_FLDS_LICPLATE)"
													:model-value="model.ValLicplate.value"
													@change="model.ValLicplate.fnUpdateValueOnChange" />
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.CAMMASK_FLDS_SSNUMBER.isVisible">
										<q-col
											v-if="controls.CAMMASK_FLDS_SSNUMBER.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMMASK_FLDS_SSNUMBER.isVisible"
												class="i-text"
												v-bind="controls.CAMMASK_FLDS_SSNUMBER.wrapperProps"
												:id="getControlId(controls.CAMMASK_FLDS_SSNUMBER)"
												v-on="controls.CAMMASK_FLDS_SSNUMBER.handlers"
												:loading="controls.CAMMASK_FLDS_SSNUMBER.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-mask
													v-if="controls.CAMMASK_FLDS_SSNUMBER.isVisible"
													v-bind="controls.CAMMASK_FLDS_SSNUMBER.props"
													:id="getControlId(controls.CAMMASK_FLDS_SSNUMBER)"
													:model-value="model.ValSsnumber.value"
													@change="model.ValSsnumber.fnUpdateValueOnChange" />
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.CAMMASK_FLDS_BANKNMBR.isVisible">
										<q-col
											v-if="controls.CAMMASK_FLDS_BANKNMBR.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMMASK_FLDS_BANKNMBR.isVisible"
												class="i-text"
												v-bind="controls.CAMMASK_FLDS_BANKNMBR.wrapperProps"
												:id="getControlId(controls.CAMMASK_FLDS_BANKNMBR)"
												v-on="controls.CAMMASK_FLDS_BANKNMBR.handlers"
												:loading="controls.CAMMASK_FLDS_BANKNMBR.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-mask
													v-if="controls.CAMMASK_FLDS_BANKNMBR.isVisible"
													v-bind="controls.CAMMASK_FLDS_BANKNMBR.props"
													:id="getControlId(controls.CAMMASK_FLDS_BANKNMBR)"
													:model-value="model.ValBanknmbr.value"
													@change="model.ValBanknmbr.fnUpdateValueOnChange" />
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.CAMMASK_FLDS_EMAILFLD.isVisible">
										<q-col
											v-if="controls.CAMMASK_FLDS_EMAILFLD.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMMASK_FLDS_EMAILFLD.isVisible"
												class="i-text"
												v-bind="controls.CAMMASK_FLDS_EMAILFLD.wrapperProps"
												:id="getControlId(controls.CAMMASK_FLDS_EMAILFLD)"
												v-on="controls.CAMMASK_FLDS_EMAILFLD.handlers"
												:loading="controls.CAMMASK_FLDS_EMAILFLD.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-mask
													v-if="controls.CAMMASK_FLDS_EMAILFLD.isVisible"
													v-bind="controls.CAMMASK_FLDS_EMAILFLD.props"
													:id="getControlId(controls.CAMMASK_FLDS_EMAILFLD)"
													:model-value="model.ValEmailfld.value"
													@change="model.ValEmailfld.fnUpdateValueOnChange" />
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.CAMMASK_FLDS_IBANFIEL.isVisible">
										<q-col
											v-if="controls.CAMMASK_FLDS_IBANFIEL.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMMASK_FLDS_IBANFIEL.isVisible"
												class="i-text"
												v-bind="controls.CAMMASK_FLDS_IBANFIEL.wrapperProps"
												:id="getControlId(controls.CAMMASK_FLDS_IBANFIEL)"
												v-on="controls.CAMMASK_FLDS_IBANFIEL.handlers"
												:loading="controls.CAMMASK_FLDS_IBANFIEL.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-mask
													v-if="controls.CAMMASK_FLDS_IBANFIEL.isVisible"
													v-bind="controls.CAMMASK_FLDS_IBANFIEL.props"
													:id="getControlId(controls.CAMMASK_FLDS_IBANFIEL)"
													:model-value="model.ValIbanfiel.value"
													@change="model.ValIbanfiel.fnUpdateValueOnChange" />
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.CAMMASK_FLDS_UPPRTEXT.isVisible">
										<q-col
											v-if="controls.CAMMASK_FLDS_UPPRTEXT.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMMASK_FLDS_UPPRTEXT.isVisible"
												class="i-text"
												v-bind="controls.CAMMASK_FLDS_UPPRTEXT.wrapperProps"
												:id="getControlId(controls.CAMMASK_FLDS_UPPRTEXT)"
												v-on="controls.CAMMASK_FLDS_UPPRTEXT.handlers"
												:loading="controls.CAMMASK_FLDS_UPPRTEXT.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-mask
													v-if="controls.CAMMASK_FLDS_UPPRTEXT.isVisible"
													v-bind="controls.CAMMASK_FLDS_UPPRTEXT.props"
													:id="getControlId(controls.CAMMASK_FLDS_UPPRTEXT)"
													:model-value="model.ValUpprtext.value"
													@change="model.ValUpprtext.fnUpdateValueOnChange" />
											</base-input-structure>
										</q-col>
									</q-row>
								</div>
							</section>
							<section
								v-if="controls.LISTACAMPSEUDCAMENUM_.isVisible"
								v-show="controls.formTabs.selectedTab === 'LISTACAMPSEUDCAMENUM_'">
								<div
									id="LISTACAMPSEUDCAMENUM_"
									role="tabpanel"
									aria-labelledby="q-tabs-LISTACAM-tab-LISTACAMPSEUDCAMENUM_">
									<q-row v-if="controls.CAMENUM_FLDS_CLASSNUM.isVisible">
										<q-col
											v-if="controls.CAMENUM_FLDS_CLASSNUM.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMENUM_FLDS_CLASSNUM.isVisible"
												class="i-radio-container"
												v-bind="controls.CAMENUM_FLDS_CLASSNUM.wrapperProps"
												:id="getControlId(controls.CAMENUM_FLDS_CLASSNUM)"
												v-on="controls.CAMENUM_FLDS_CLASSNUM.handlers"
												:label-position="labelAlignment.topleft"
												:loading="controls.CAMENUM_FLDS_CLASSNUM.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-radio-group
													v-if="controls.CAMENUM_FLDS_CLASSNUM.isVisible"
													v-bind="controls.CAMENUM_FLDS_CLASSNUM.props"
													:id="getControlId(controls.CAMENUM_FLDS_CLASSNUM)"
													v-on="controls.CAMENUM_FLDS_CLASSNUM.handlers">
													<q-radio-button
														v-for="radio in controls.CAMENUM_FLDS_CLASSNUM.items"
														:key="radio.key"
														:label="radio.value"
														:value="radio.key" />
												</q-radio-group>
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.CAMENUM_FLDS_CLASS___.isVisible">
										<q-col
											v-if="controls.CAMENUM_FLDS_CLASS___.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMENUM_FLDS_CLASS___.isVisible"
												class="i-text"
												v-bind="controls.CAMENUM_FLDS_CLASS___.wrapperProps"
												:id="getControlId(controls.CAMENUM_FLDS_CLASS___)"
												v-on="controls.CAMENUM_FLDS_CLASS___.handlers"
												:loading="controls.CAMENUM_FLDS_CLASS___.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-select
													v-if="controls.CAMENUM_FLDS_CLASS___.isVisible"
													v-bind="controls.CAMENUM_FLDS_CLASS___.props"
													:id="getControlId(controls.CAMENUM_FLDS_CLASS___)"
													@update:model-value="model.ValClass.fnUpdateValue" />
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.CAMENUM_FLDS_LOGICENU.isVisible">
										<q-col
											v-if="controls.CAMENUM_FLDS_LOGICENU.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMENUM_FLDS_LOGICENU.isVisible"
												class="i-text"
												v-bind="controls.CAMENUM_FLDS_LOGICENU.wrapperProps"
												:id="getControlId(controls.CAMENUM_FLDS_LOGICENU)"
												v-on="controls.CAMENUM_FLDS_LOGICENU.handlers"
												:loading="controls.CAMENUM_FLDS_LOGICENU.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-switch
													v-if="controls.CAMENUM_FLDS_LOGICENU.isVisible"
													v-bind="controls.CAMENUM_FLDS_LOGICENU.props"
													:id="getControlId(controls.CAMENUM_FLDS_LOGICENU)"
													v-on="controls.CAMENUM_FLDS_LOGICENU.handlers" />
											</base-input-structure>
										</q-col>
									</q-row>
								</div>
							</section>
							<section
								v-if="controls.LISTACAMPSEUDCAMDOCS_.isVisible"
								v-show="controls.formTabs.selectedTab === 'LISTACAMPSEUDCAMDOCS_'">
								<div
									id="LISTACAMPSEUDCAMDOCS_"
									role="tabpanel"
									aria-labelledby="q-tabs-LISTACAM-tab-LISTACAMPSEUDCAMDOCS_">
									<q-row v-if="controls.CAMDOCS_FLDS_LOGO____.isVisible">
										<q-col
											v-if="controls.CAMDOCS_FLDS_LOGO____.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMDOCS_FLDS_LOGO____.isVisible"
												class="q-image"
												v-bind="controls.CAMDOCS_FLDS_LOGO____.wrapperProps"
												:id="getControlId(controls.CAMDOCS_FLDS_LOGO____)"
												v-on="controls.CAMDOCS_FLDS_LOGO____.handlers"
												:loading="controls.CAMDOCS_FLDS_LOGO____.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-image
													v-if="controls.CAMDOCS_FLDS_LOGO____.isVisible"
													v-bind="controls.CAMDOCS_FLDS_LOGO____.props"
													:id="getControlId(controls.CAMDOCS_FLDS_LOGO____)"
													v-on="controls.CAMDOCS_FLDS_LOGO____.handlers" />
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.CAMDOCS_FLDS_ATTACH__.isVisible">
										<q-col
											v-if="controls.CAMDOCS_FLDS_ATTACH__.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMDOCS_FLDS_ATTACH__.isVisible"
												class="i-text"
												v-bind="controls.CAMDOCS_FLDS_ATTACH__.wrapperProps"
												:id="getControlId(controls.CAMDOCS_FLDS_ATTACH__)"
												v-on="controls.CAMDOCS_FLDS_ATTACH__.handlers"
												:loading="controls.CAMDOCS_FLDS_ATTACH__.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-document
													v-if="controls.CAMDOCS_FLDS_ATTACH__.isVisible"
													v-bind="controls.CAMDOCS_FLDS_ATTACH__.props"
													:id="getControlId(controls.CAMDOCS_FLDS_ATTACH__)"
													v-on="controls.CAMDOCS_FLDS_ATTACH__.handlers" />
											</base-input-structure>
										</q-col>
									</q-row>
								</div>
							</section>
							<section
								v-if="controls.LISTACAMPSEUDCAMAUDIT.isVisible"
								v-show="controls.formTabs.selectedTab === 'LISTACAMPSEUDCAMAUDIT'">
								<div
									id="LISTACAMPSEUDCAMAUDIT"
									role="tabpanel"
									aria-labelledby="q-tabs-LISTACAM-tab-LISTACAMPSEUDCAMAUDIT">
									<q-row v-if="controls.CAMAUDITFLDS_CREATUSE.isVisible">
										<q-col
											v-if="controls.CAMAUDITFLDS_CREATUSE.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMAUDITFLDS_CREATUSE.isVisible"
												class="i-text"
												v-bind="controls.CAMAUDITFLDS_CREATUSE.wrapperProps"
												:id="getControlId(controls.CAMAUDITFLDS_CREATUSE)"
												v-on="controls.CAMAUDITFLDS_CREATUSE.handlers"
												:loading="controls.CAMAUDITFLDS_CREATUSE.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-text-field
													v-bind="controls.CAMAUDITFLDS_CREATUSE.props"
													:id="getControlId(controls.CAMAUDITFLDS_CREATUSE)"
													@blur="onBlur(controls.CAMAUDITFLDS_CREATUSE, model.ValCreatuse.value)"
													@change="model.ValCreatuse.fnUpdateValueOnChange" />
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.CAMAUDITFLDS_CREATDAT.isVisible">
										<q-col
											v-if="controls.CAMAUDITFLDS_CREATDAT.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMAUDITFLDS_CREATDAT.isVisible"
												class="i-text"
												v-bind="controls.CAMAUDITFLDS_CREATDAT.wrapperProps"
												:id="getControlId(controls.CAMAUDITFLDS_CREATDAT)"
												v-on="controls.CAMAUDITFLDS_CREATDAT.handlers"
												:loading="controls.CAMAUDITFLDS_CREATDAT.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-date-time-picker
													v-if="controls.CAMAUDITFLDS_CREATDAT.isVisible"
													v-bind="controls.CAMAUDITFLDS_CREATDAT.props"
													:id="getControlId(controls.CAMAUDITFLDS_CREATDAT)"
													:model-value="model.ValCreatdat.value"
													@reset-icon-click="model.ValCreatdat.fnUpdateValue(model.ValCreatdat.originalValue ?? new Date())"
													@update:model-value="model.ValCreatdat.fnUpdateValue($event ?? '')" />
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.CAMAUDITFLDS_CREATHOU.isVisible">
										<q-col
											v-if="controls.CAMAUDITFLDS_CREATHOU.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMAUDITFLDS_CREATHOU.isVisible"
												class="i-text"
												v-bind="controls.CAMAUDITFLDS_CREATHOU.wrapperProps"
												:id="getControlId(controls.CAMAUDITFLDS_CREATHOU)"
												v-on="controls.CAMAUDITFLDS_CREATHOU.handlers"
												:loading="controls.CAMAUDITFLDS_CREATHOU.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-date-time-picker
													v-if="controls.CAMAUDITFLDS_CREATHOU.isVisible"
													v-bind="controls.CAMAUDITFLDS_CREATHOU.props"
													:id="getControlId(controls.CAMAUDITFLDS_CREATHOU)"
													:model-value="model.ValCreathou.value"
													@reset-icon-click="model.ValCreathou.fnUpdateValue(model.ValCreathou.originalValue ?? new Date())"
													@update:model-value="model.ValCreathou.fnUpdateValue($event ?? '')" />
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.CAMAUDITFLDS_CREATINS.isVisible">
										<q-col
											v-if="controls.CAMAUDITFLDS_CREATINS.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.CAMAUDITFLDS_CREATINS.isVisible"
												class="i-text"
												v-bind="controls.CAMAUDITFLDS_CREATINS.wrapperProps"
												:id="getControlId(controls.CAMAUDITFLDS_CREATINS)"
												v-on="controls.CAMAUDITFLDS_CREATINS.handlers"
												:loading="controls.CAMAUDITFLDS_CREATINS.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-date-time-picker
													v-if="controls.CAMAUDITFLDS_CREATINS.isVisible"
													v-bind="controls.CAMAUDITFLDS_CREATINS.props"
													:id="getControlId(controls.CAMAUDITFLDS_CREATINS)"
													:model-value="model.ValCreatins.value"
													@reset-icon-click="model.ValCreatins.fnUpdateValue(model.ValCreatins.originalValue ?? new Date())"
													@update:model-value="model.ValCreatins.fnUpdateValue($event ?? '')" />
											</base-input-structure>
										</q-col>
									</q-row>
								</div>
							</section>
						</q-tab-container>
					</q-col>
				</q-row>
			</template>
		</q-container>
	</teleport>

	<q-divider v-if="!isPopup && showFormFooter" />

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
				default: () => ({
					name: 'LISTACAM',
					location: 'form-LISTACAM',
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
						text: computed(() => vm.Resources.SAVE04165),
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
					LISTACAMPSEUDCAMTEXTO: new fieldControlClass.TabControl({
						id: 'LISTACAMPSEUDCAMTEXTO',
						name: 'CAMTEXTO',
						size: 'xxlarge',
						label: computed(() => this.Resources.TEXT_FIELDS40102),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['CAMTEXTOFLDS_TXTFIELD', 'CAMTEXTOFLDS_DESCRIP_'],
						controlLimits: [
						],
					}, this),
					LISTACAMPSEUDCAMNUM__: new fieldControlClass.TabControl({
						id: 'LISTACAMPSEUDCAMNUM__',
						name: 'CAMNUM',
						size: 'xxlarge',
						label: computed(() => this.Resources.NUMERIC_FIELDS45771),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['CAMNUM__FLDS_NPASSAGE', 'CAMNUM__FLDS_DURATION', 'CAMNUM__FLDS_PRICE___', 'CAMNUM__FLDS_PRECOBIL'],
						controlLimits: [
						],
					}, this),
					LISTACAMPSEUDCAMDATE_: new fieldControlClass.TabControl({
						id: 'LISTACAMPSEUDCAMDATE_',
						name: 'CAMDATE',
						size: 'xxlarge',
						label: computed(() => this.Resources.DATE_FIELDS55234),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['CAMDATE_FLDS_YEAR____', 'CAMDATE_FLDS_DATE____', 'CAMDATE_FLDS_DATETIME', 'CAMDATE_FLDS_DATESECO', 'CAMDATE_FLDS_TIME____'],
						controlLimits: [
						],
					}, this),
					LISTACAMPSEUDCAMMASK_: new fieldControlClass.TabControl({
						id: 'LISTACAMPSEUDCAMMASK_',
						name: 'CAMMASK',
						size: 'xxlarge',
						label: computed(() => this.Resources.INPUTS_WITH_MASKS08900),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['CAMMASK_FLDS_ZIPFIELD', 'CAMMASK_FLDS_VATNUMBR', 'CAMMASK_FLDS_LICPLATE', 'CAMMASK_FLDS_SSNUMBER', 'CAMMASK_FLDS_BANKNMBR', 'CAMMASK_FLDS_EMAILFLD', 'CAMMASK_FLDS_IBANFIEL', 'CAMMASK_FLDS_UPPRTEXT'],
						controlLimits: [
						],
					}, this),
					LISTACAMPSEUDCAMENUM_: new fieldControlClass.TabControl({
						id: 'LISTACAMPSEUDCAMENUM_',
						name: 'CAMENUM',
						size: 'xxlarge',
						label: computed(() => this.Resources.ENUMERATIONS_FIELDS36502),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['CAMENUM_FLDS_CLASSNUM', 'CAMENUM_FLDS_CLASS___', 'CAMENUM_FLDS_LOGICENU'],
						controlLimits: [
						],
					}, this),
					LISTACAMPSEUDCAMDOCS_: new fieldControlClass.TabControl({
						id: 'LISTACAMPSEUDCAMDOCS_',
						name: 'CAMDOCS',
						size: 'xxlarge',
						label: computed(() => this.Resources.EXTERNAL_DOCS_FIELDS46956),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['CAMDOCS_FLDS_LOGO____', 'CAMDOCS_FLDS_ATTACH__'],
						controlLimits: [
						],
					}, this),
					LISTACAMPSEUDCAMAUDIT: new fieldControlClass.TabControl({
						id: 'LISTACAMPSEUDCAMAUDIT',
						name: 'CAMAUDIT',
						size: 'xxlarge',
						label: computed(() => this.Resources.DATA_AUDIT01314),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['CAMAUDITFLDS_CREATUSE', 'CAMAUDITFLDS_CREATDAT', 'CAMAUDITFLDS_CREATHOU', 'CAMAUDITFLDS_CREATINS'],
						controlLimits: [
						],
					}, this),
					CAMTEXTOFLDS_TXTFIELD: new fieldControlClass.StringControl({
						modelField: 'ValTxtfield',
						valueChangeEvent: 'fieldChange:flds.txtfield',
						id: 'CAMTEXTOFLDS_TXTFIELD',
						name: 'TXTFIELD',
						size: 'large',
						label: computed(() => this.Resources.TEXT_FIELD41810),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMTEXTO',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					CAMTEXTOFLDS_DESCRIP_: new fieldControlClass.MultilineStringControl({
						modelField: 'ValDescrip',
						valueChangeEvent: 'fieldChange:flds.descrip',
						id: 'CAMTEXTOFLDS_DESCRIP_',
						name: 'DESCRIP',
						size: 'large',
						label: computed(() => this.Resources.DESCRIPTION07383),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMTEXTO',
						rows: 3,
						cols: 30,
						controlLimits: [
						],
					}, this),
					CAMNUM__FLDS_NPASSAGE: new fieldControlClass.NumberControl({
						modelField: 'ValNpassage',
						valueChangeEvent: 'fieldChange:flds.npassage',
						id: 'CAMNUM__FLDS_NPASSAGE',
						name: 'NPASSAGE',
						size: 'mini',
						label: computed(() => this.Resources.NUMERIC19292),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMNUM__',
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					CAMNUM__FLDS_DURATION: new fieldControlClass.NumberControl({
						modelField: 'ValDuration',
						valueChangeEvent: 'fieldChange:flds.duration',
						id: 'CAMNUM__FLDS_DURATION',
						name: 'DURATION',
						size: 'small',
						label: computed(() => this.Resources.NUMERIC_DECIMAL37352),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMNUM__',
						maxIntegers: 2,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					CAMNUM__FLDS_PRICE___: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrice',
						valueChangeEvent: 'fieldChange:flds.price',
						id: 'CAMNUM__FLDS_PRICE___',
						name: 'PRICE',
						size: 'mini',
						label: computed(() => this.Resources.CURRENCY13881),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMNUM__',
						maxIntegers: 3,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					CAMNUM__FLDS_PRECOBIL: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrecobil',
						valueChangeEvent: 'fieldChange:flds.precobil',
						id: 'CAMNUM__FLDS_PRECOBIL',
						name: 'PRECOBIL',
						size: 'small',
						label: computed(() => this.Resources.CURRENCY_DECIMAL48296),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMNUM__',
						maxIntegers: 3,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					CAMDATE_FLDS_YEAR____: new fieldControlClass.NumberControl({
						modelField: 'ValYear',
						valueChangeEvent: 'fieldChange:flds.year',
						id: 'CAMDATE_FLDS_YEAR____',
						name: 'YEAR',
						size: 'mini',
						helpControl: {
							shortHelp: {
								type: 'subtext',
								text: computed(() => this.Resources.___3161967),
							},
						},
						label: computed(() => this.Resources.YEAR61794),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMDATE_',
						maxIntegers: 4,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					CAMDATE_FLDS_DATE____: new fieldControlClass.DateControl({
						modelField: 'ValDate',
						valueChangeEvent: 'fieldChange:flds.date',
						id: 'CAMDATE_FLDS_DATE____',
						name: 'DATE',
						size: 'small',
						helpControl: {
							shortHelp: {
								type: 'subtext',
								text: computed(() => this.Resources.___3261074),
							},
						},
						label: computed(() => this.Resources.DATE18475),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMDATE_',
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					CAMDATE_FLDS_DATETIME: new fieldControlClass.DateControl({
						modelField: 'ValDatetime',
						valueChangeEvent: 'fieldChange:flds.datetime',
						id: 'CAMDATE_FLDS_DATETIME',
						name: 'DATETIME',
						size: 'medium',
						helpControl: {
							shortHelp: {
								type: 'subtext',
								text: computed(() => this.Resources.___3360901),
							},
						},
						label: computed(() => this.Resources.DATE_TIME53960),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMDATE_',
						dateTimeType: 'dateTime',
						controlLimits: [
						],
					}, this),
					CAMDATE_FLDS_DATESECO: new fieldControlClass.DateControl({
						modelField: 'ValDateseco',
						valueChangeEvent: 'fieldChange:flds.dateseco',
						id: 'CAMDATE_FLDS_DATESECO',
						name: 'DATESECO',
						size: 'medium',
						helpControl: {
							shortHelp: {
								type: 'subtext',
								text: computed(() => this.Resources.___3465504),
							},
						},
						label: computed(() => this.Resources.DATE_SECONDS65191),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMDATE_',
						dateTimeType: 'dateTimeSeconds',
						controlLimits: [
						],
					}, this),
					CAMDATE_FLDS_TIME____: new fieldControlClass.TimeControl({
						modelField: 'ValTime',
						valueChangeEvent: 'fieldChange:flds.time',
						id: 'CAMDATE_FLDS_TIME____',
						name: 'TIME',
						size: 'mini',
						helpControl: {
							shortHelp: {
								type: 'subtext',
								text: computed(() => this.Resources.___3561555),
							},
						},
						label: computed(() => this.Resources.TIME15328),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMDATE_',
						dateTimeType: 'time',
						controlLimits: [
						],
					}, this),
					CAMMASK_FLDS_ZIPFIELD: new fieldControlClass.MaskControl({
						modelField: 'ValZipfield',
						valueChangeEvent: 'fieldChange:flds.zipfield',
						id: 'CAMMASK_FLDS_ZIPFIELD',
						name: 'ZIPFIELD',
						size: 'small',
						label: computed(() => this.Resources.ZIPCODE21021),
						placeholder: computed(() => this.Resources.XXXX_XXX51420),
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMMASK_',
						maxLength: 8,
						controlLimits: [
						],
					}, this),
					CAMMASK_FLDS_VATNUMBR: new fieldControlClass.MaskControl({
						modelField: 'ValVatnumbr',
						valueChangeEvent: 'fieldChange:flds.vatnumbr',
						id: 'CAMMASK_FLDS_VATNUMBR',
						name: 'VATNUMBR',
						size: 'small',
						label: computed(() => this.Resources.VAT_NUMBER24236),
						placeholder: computed(() => this.Resources._12345678902714),
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMMASK_',
						maxLength: 9,
						controlLimits: [
						],
					}, this),
					CAMMASK_FLDS_LICPLATE: new fieldControlClass.MaskControl({
						modelField: 'ValLicplate',
						valueChangeEvent: 'fieldChange:flds.licplate',
						id: 'CAMMASK_FLDS_LICPLATE',
						name: 'LICPLATE',
						size: 'small',
						label: computed(() => this.Resources.LICENCE_PLATE07627),
						placeholder: computed(() => this.Resources.XX_00_XX10122),
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMMASK_',
						maxLength: 8,
						controlLimits: [
						],
					}, this),
					CAMMASK_FLDS_SSNUMBER: new fieldControlClass.MaskControl({
						modelField: 'ValSsnumber',
						valueChangeEvent: 'fieldChange:flds.ssnumber',
						id: 'CAMMASK_FLDS_SSNUMBER',
						name: 'SSNUMBER',
						size: 'medium',
						label: computed(() => this.Resources.SOCIAL_SECURITY_NO48150),
						placeholder: computed(() => this.Resources._1234567891202679),
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMMASK_',
						maxLength: 11,
						controlLimits: [
						],
					}, this),
					CAMMASK_FLDS_BANKNMBR: new fieldControlClass.MaskControl({
						modelField: 'ValBanknmbr',
						valueChangeEvent: 'fieldChange:flds.banknmbr',
						id: 'CAMMASK_FLDS_BANKNMBR',
						name: 'BANKNMBR',
						size: 'large',
						label: computed(() => this.Resources.BANKING_ACCOUNT_NUMB62548),
						placeholder: computed(() => this.Resources._1234_5678_901234567844057),
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMMASK_',
						maxLength: 24,
						controlLimits: [
						],
					}, this),
					CAMMASK_FLDS_EMAILFLD: new fieldControlClass.MaskControl({
						modelField: 'ValEmailfld',
						valueChangeEvent: 'fieldChange:flds.emailfld',
						id: 'CAMMASK_FLDS_EMAILFLD',
						name: 'EMAILFLD',
						size: 'large',
						label: computed(() => this.Resources.EMAIL25170),
						placeholder: computed(() => this.Resources.QUIDGESTAT_QUIDGEST_PT47872),
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMMASK_',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					CAMMASK_FLDS_IBANFIEL: new fieldControlClass.MaskControl({
						modelField: 'ValIbanfiel',
						valueChangeEvent: 'fieldChange:flds.ibanfiel',
						id: 'CAMMASK_FLDS_IBANFIEL',
						name: 'IBANFIEL',
						size: 'large',
						label: computed(() => this.Resources.IBAN28506),
						placeholder: computed(() => this.Resources.PT12345678901234567820477),
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMMASK_',
						maxLength: 34,
						controlLimits: [
						],
					}, this),
					CAMMASK_FLDS_UPPRTEXT: new fieldControlClass.MaskControl({
						modelField: 'ValUpprtext',
						valueChangeEvent: 'fieldChange:flds.upprtext',
						id: 'CAMMASK_FLDS_UPPRTEXT',
						name: 'UPPRTEXT',
						size: 'xlarge',
						label: computed(() => this.Resources.UPPERCASE48238),
						placeholder: computed(() => this.Resources.QUIDGEST56322),
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMMASK_',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					CAMENUM_FLDS_CLASSNUM: new fieldControlClass.RadioGroupControl({
						modelField: 'ValClassnum',
						valueChangeEvent: 'fieldChange:flds.classnum',
						id: 'CAMENUM_FLDS_CLASSNUM',
						name: 'CLASSNUM',
						helpControl: {
							shortHelp: {
								type: 'subtext',
								text: computed(() => this.Resources.___1845555),
							},
						},
						label: computed(() => this.Resources.NUMERIC_ENUMERATION46756),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						tab: 'LISTACAMPSEUDCAMENUM_',
						maxIntegers: 1,
						maxDecimals: 0,
						arrayName: 'CLASSNUM',
						columns: 3,
						controlLimits: [
						],
					}, this),
					CAMENUM_FLDS_CLASS___: new fieldControlClass.ArrayStringControl({
						modelField: 'ValClass',
						valueChangeEvent: 'fieldChange:flds.class',
						id: 'CAMENUM_FLDS_CLASS___',
						name: 'CLASS',
						size: 'medium',
						helpControl: {
							shortHelp: {
								type: 'subtext',
								text: computed(() => this.Resources.___2712722),
							},
						},
						label: computed(() => this.Resources.TEXT_ENUMERATION45668),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMENUM_',
						maxLength: 2,
						arrayName: 'CLASS',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					CAMENUM_FLDS_LOGICENU: new fieldControlClass.ArrayBooleanControl({
						modelField: 'ValLogicenu',
						valueChangeEvent: 'fieldChange:flds.logicenu',
						id: 'CAMENUM_FLDS_LOGICENU',
						name: 'LOGICENU',
						size: 'medium',
						helpControl: {
							shortHelp: {
								type: 'subtext',
								text: computed(() => this.Resources.___2813103),
							},
						},
						label: computed(() => this.Resources.LOGICAL_ENUMERATION30276),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMENUM_',
						maxIntegers: 1,
						maxDecimals: 0,
						arrayName: 'PRIMVIAG',
						trueLabel: computed(() => this.Resources.YES34196),
						falseLabel: computed(() => this.Resources.NO57340),
						controlLimits: [
						],
					}, this),
					CAMDOCS_FLDS_LOGO____: new fieldControlClass.ImageControl({
						modelField: 'ValLogo',
						valueChangeEvent: 'fieldChange:flds.logo',
						id: 'CAMDOCS_FLDS_LOGO____',
						name: 'LOGO',
						size: 'medium',
						helpControl: {
							shortHelp: {
								type: 'subtext',
								text: computed(() => this.Resources.___2916088),
							},
						},
						label: computed(() => this.Resources.LOGO62483),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMDOCS_',
						height: 50,
						width: 100,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.LOGO62483)),
						controlLimits: [
						],
					}, this),
					CAMDOCS_FLDS_ATTACH__: new fieldControlClass.DocumentControl({
						modelField: 'ValAttach',
						valueChangeEvent: 'fieldChange:flds.attach',
						id: 'CAMDOCS_FLDS_ATTACH__',
						name: 'ATTACH',
						size: 'large',
						helpControl: {
							shortHelp: {
								type: 'subtext',
								text: computed(() => this.Resources.___3061884),
							},
						},
						label: computed(() => this.Resources.ATTACHMENTS19612),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMDOCS_',
						versioningIsOn: true,
						extensions: [],
						controlLimits: [
						],
					}, this),
					CAMAUDITFLDS_CREATUSE: new fieldControlClass.StringControl({
						modelField: 'ValCreatuse',
						valueChangeEvent: 'fieldChange:flds.creatuse',
						id: 'CAMAUDITFLDS_CREATUSE',
						name: 'CREATUSE',
						size: 'medium',
						label: computed(() => this.Resources.CREATED_BY12292),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMAUDIT',
						maxLength: 20,
						controlLimits: [
						],
					}, this),
					CAMAUDITFLDS_CREATDAT: new fieldControlClass.DateControl({
						modelField: 'ValCreatdat',
						valueChangeEvent: 'fieldChange:flds.creatdat',
						id: 'CAMAUDITFLDS_CREATDAT',
						name: 'CREATDAT',
						size: 'small',
						label: computed(() => this.Resources.DATE_OF_CREATION49487),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMAUDIT',
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					CAMAUDITFLDS_CREATHOU: new fieldControlClass.TimeControl({
						modelField: 'ValCreathou',
						valueChangeEvent: 'fieldChange:flds.creathou',
						id: 'CAMAUDITFLDS_CREATHOU',
						name: 'CREATHOU',
						size: 'small',
						label: computed(() => this.Resources.CREATION_HOUR49876),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMAUDIT',
						dateTimeType: 'time',
						controlLimits: [
						],
					}, this),
					CAMAUDITFLDS_CREATINS: new fieldControlClass.DateControl({
						modelField: 'ValCreatins',
						valueChangeEvent: 'fieldChange:flds.creatins',
						id: 'CAMAUDITFLDS_CREATINS',
						name: 'CREATINS',
						size: 'medium',
						label: computed(() => this.Resources.COMPLETE_DATE_OF_CRE57046),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'LISTACAMPSEUDCAMAUDIT',
						dateTimeType: 'dateTimeSeconds',
						controlLimits: [
						],
					}, this),
					formTabs: new fieldControlClass.TabsControl({
						id: 'formTabs',
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
// USE /[MANUAL GQT FORM_CODEJS LISTACAM]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT LISTACAM]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS LISTACAM]/
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
				for (const trigger of triggers)
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
				// Execute the "After save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterSave)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT AFTER_SAVE_JS LISTACAM]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS LISTACAM]/
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
// USE /[MANUAL GQT AFTER_DEL_JS LISTACAM]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS LISTACAM]/
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
			 * Called whenever a field is unfocused.
			 * @param {*} fieldObject The object representing the field in the model
			 * @param {*} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onBlur(fieldObject, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT CTRLBLR LISTACAM]/
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
// USE /[MANUAL GQT CTRLUPD LISTACAM]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS LISTACAM]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
