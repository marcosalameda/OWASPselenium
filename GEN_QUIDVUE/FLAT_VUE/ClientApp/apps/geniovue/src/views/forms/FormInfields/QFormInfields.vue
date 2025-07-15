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
			data-key="INFIELDS"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container
					v-show="controls.INFIELDSPSEUDNOVOGR02.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.INFIELDSPSEUDNOVOGR02.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="INFIELDSPSEUDNOVOGR02"
							v-bind="controls.INFIELDSPSEUDNOVOGR02"
							:is-visible="controls.INFIELDSPSEUDNOVOGR02.isVisible">
							<!-- Start INFIELDSPSEUDNOVOGR02 -->
							<q-row-container v-show="controls.INFIELDSFLDS_TXTFIELD.isVisible">
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_TXTFIELD.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INFIELDSFLDS_TXTFIELD"
										v-on="controls.INFIELDSFLDS_TXTFIELD.handlers"
										:loading="controls.INFIELDSFLDS_TXTFIELD.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.INFIELDSFLDS_TXTFIELD.props"
											@blur="onBlur(controls.INFIELDSFLDS_TXTFIELD, model.ValTxtfield.value)"
											@change="model.ValTxtfield.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.INFIELDSFLDS_DESCRIP_.isVisible">
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_DESCRIP_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-textarea"
										v-bind="controls.INFIELDSFLDS_DESCRIP_"
										v-on="controls.INFIELDSFLDS_DESCRIP_.handlers"
										:loading="controls.INFIELDSFLDS_DESCRIP_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-area
											v-if="controls.INFIELDSFLDS_DESCRIP_.isVisible"
											v-bind="controls.INFIELDSFLDS_DESCRIP_.props"
											v-on="controls.INFIELDSFLDS_DESCRIP_.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End INFIELDSPSEUDNOVOGR02 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.INFIELDSPSEUDNOVOGR01.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.INFIELDSPSEUDNOVOGR01.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="INFIELDSPSEUDNOVOGR01"
							v-bind="controls.INFIELDSPSEUDNOVOGR01"
							:is-visible="controls.INFIELDSPSEUDNOVOGR01.isVisible">
							<!-- Start INFIELDSPSEUDNOVOGR01 -->
							<q-row-container v-show="controls.INFIELDSFLDS_YEAR____.isVisible">
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_YEAR____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INFIELDSFLDS_YEAR____"
										v-on="controls.INFIELDSFLDS_YEAR____.handlers"
										:loading="controls.INFIELDSFLDS_YEAR____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.INFIELDSFLDS_YEAR____.isVisible"
											v-bind="controls.INFIELDSFLDS_YEAR____.props"
											@update:model-value="model.ValYear.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.INFIELDSFLDS_TIME____.isVisible">
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_TIME____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INFIELDSFLDS_TIME____"
										v-on="controls.INFIELDSFLDS_TIME____.handlers"
										:loading="controls.INFIELDSFLDS_TIME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.INFIELDSFLDS_TIME____.isVisible"
											v-bind="controls.INFIELDSFLDS_TIME____.props"
											:model-value="model.ValTime.value"
											@reset-icon-click="model.ValTime.fnUpdateValue(model.ValTime.originalValue ?? new Date())"
											@update:model-value="model.ValTime.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.INFIELDSFLDS_DATE____.isVisible">
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_DATE____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INFIELDSFLDS_DATE____"
										v-on="controls.INFIELDSFLDS_DATE____.handlers"
										:loading="controls.INFIELDSFLDS_DATE____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.INFIELDSFLDS_DATE____.isVisible"
											v-bind="controls.INFIELDSFLDS_DATE____.props"
											:model-value="model.ValDate.value"
											@reset-icon-click="model.ValDate.fnUpdateValue(model.ValDate.originalValue ?? new Date())"
											@update:model-value="model.ValDate.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.INFIELDSFLDS_DATETIME.isVisible">
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_DATETIME.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INFIELDSFLDS_DATETIME"
										v-on="controls.INFIELDSFLDS_DATETIME.handlers"
										:loading="controls.INFIELDSFLDS_DATETIME.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.INFIELDSFLDS_DATETIME.isVisible"
											v-bind="controls.INFIELDSFLDS_DATETIME.props"
											:model-value="model.ValDatetime.value"
											@reset-icon-click="model.ValDatetime.fnUpdateValue(model.ValDatetime.originalValue ?? new Date())"
											@update:model-value="model.ValDatetime.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.INFIELDSFLDS_DATESECO.isVisible">
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_DATESECO.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INFIELDSFLDS_DATESECO"
										v-on="controls.INFIELDSFLDS_DATESECO.handlers"
										:loading="controls.INFIELDSFLDS_DATESECO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.INFIELDSFLDS_DATESECO.isVisible"
											v-bind="controls.INFIELDSFLDS_DATESECO.props"
											:model-value="model.ValDateseco.value"
											@reset-icon-click="model.ValDateseco.fnUpdateValue(model.ValDateseco.originalValue ?? new Date())"
											@update:model-value="model.ValDateseco.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End INFIELDSPSEUDNOVOGR01 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.INFIELDSPSEUDNOVOGR04.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.INFIELDSPSEUDNOVOGR04.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="INFIELDSPSEUDNOVOGR04"
							v-bind="controls.INFIELDSPSEUDNOVOGR04"
							:is-visible="controls.INFIELDSPSEUDNOVOGR04.isVisible">
							<!-- Start INFIELDSPSEUDNOVOGR04 -->
							<q-row-container v-show="controls.INFIELDSFLDS_SSNUMBER.isVisible">
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_SSNUMBER.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INFIELDSFLDS_SSNUMBER"
										v-on="controls.INFIELDSFLDS_SSNUMBER.handlers"
										:loading="controls.INFIELDSFLDS_SSNUMBER.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.INFIELDSFLDS_SSNUMBER.isVisible"
											v-bind="controls.INFIELDSFLDS_SSNUMBER"
											:model-value="model.ValSsnumber.value"
											@update:model-value="model.ValSsnumber.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.INFIELDSFLDS_ZIPFIELD.isVisible || controls.INFIELDSFLDS_VATNUMBR.isVisible || controls.INFIELDSFLDS_LICPLATE.isVisible">
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_ZIPFIELD.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INFIELDSFLDS_ZIPFIELD"
										v-on="controls.INFIELDSFLDS_ZIPFIELD.handlers"
										:loading="controls.INFIELDSFLDS_ZIPFIELD.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.INFIELDSFLDS_ZIPFIELD.isVisible"
											v-bind="controls.INFIELDSFLDS_ZIPFIELD"
											:model-value="model.ValZipfield.value"
											@update:model-value="model.ValZipfield.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_VATNUMBR.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INFIELDSFLDS_VATNUMBR"
										v-on="controls.INFIELDSFLDS_VATNUMBR.handlers"
										:loading="controls.INFIELDSFLDS_VATNUMBR.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.INFIELDSFLDS_VATNUMBR.isVisible"
											v-bind="controls.INFIELDSFLDS_VATNUMBR"
											:model-value="model.ValVatnumbr.value"
											@update:model-value="model.ValVatnumbr.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_LICPLATE.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INFIELDSFLDS_LICPLATE"
										v-on="controls.INFIELDSFLDS_LICPLATE.handlers"
										:loading="controls.INFIELDSFLDS_LICPLATE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.INFIELDSFLDS_LICPLATE.isVisible"
											v-bind="controls.INFIELDSFLDS_LICPLATE"
											:model-value="model.ValLicplate.value"
											@update:model-value="model.ValLicplate.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.INFIELDSFLDS_BANKNMBR.isVisible">
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_BANKNMBR.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INFIELDSFLDS_BANKNMBR"
										v-on="controls.INFIELDSFLDS_BANKNMBR.handlers"
										:loading="controls.INFIELDSFLDS_BANKNMBR.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.INFIELDSFLDS_BANKNMBR.isVisible"
											v-bind="controls.INFIELDSFLDS_BANKNMBR"
											:model-value="model.ValBanknmbr.value"
											@update:model-value="model.ValBanknmbr.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.INFIELDSFLDS_EMAILFLD.isVisible">
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_EMAILFLD.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INFIELDSFLDS_EMAILFLD"
										v-on="controls.INFIELDSFLDS_EMAILFLD.handlers"
										:loading="controls.INFIELDSFLDS_EMAILFLD.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.INFIELDSFLDS_EMAILFLD.isVisible"
											v-bind="controls.INFIELDSFLDS_EMAILFLD"
											:model-value="model.ValEmailfld.value"
											@update:model-value="model.ValEmailfld.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.INFIELDSFLDS_IBANFIEL.isVisible">
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_IBANFIEL.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INFIELDSFLDS_IBANFIEL"
										v-on="controls.INFIELDSFLDS_IBANFIEL.handlers"
										:loading="controls.INFIELDSFLDS_IBANFIEL.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.INFIELDSFLDS_IBANFIEL.isVisible"
											v-bind="controls.INFIELDSFLDS_IBANFIEL"
											:model-value="model.ValIbanfiel.value"
											@update:model-value="model.ValIbanfiel.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.INFIELDSFLDS_UPPRTEXT.isVisible">
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_UPPRTEXT.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INFIELDSFLDS_UPPRTEXT"
										v-on="controls.INFIELDSFLDS_UPPRTEXT.handlers"
										:loading="controls.INFIELDSFLDS_UPPRTEXT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.INFIELDSFLDS_UPPRTEXT.isVisible"
											v-bind="controls.INFIELDSFLDS_UPPRTEXT"
											:model-value="model.ValUpprtext.value"
											@update:model-value="model.ValUpprtext.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End INFIELDSPSEUDNOVOGR04 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.INFIELDSPSEUDNOVOGR03.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.INFIELDSPSEUDNOVOGR03.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="INFIELDSPSEUDNOVOGR03"
							v-bind="controls.INFIELDSPSEUDNOVOGR03"
							:is-visible="controls.INFIELDSPSEUDNOVOGR03.isVisible">
							<!-- Start INFIELDSPSEUDNOVOGR03 -->
							<q-row-container v-show="controls.INFIELDSFLDS_NPASSAGE.isVisible || controls.INFIELDSFLDS_DURATION.isVisible">
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_NPASSAGE.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INFIELDSFLDS_NPASSAGE"
										v-on="controls.INFIELDSFLDS_NPASSAGE.handlers"
										:loading="controls.INFIELDSFLDS_NPASSAGE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.INFIELDSFLDS_NPASSAGE.isVisible"
											v-bind="controls.INFIELDSFLDS_NPASSAGE.props"
											@update:model-value="model.ValNpassage.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_DURATION.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INFIELDSFLDS_DURATION"
										v-on="controls.INFIELDSFLDS_DURATION.handlers"
										:loading="controls.INFIELDSFLDS_DURATION.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.INFIELDSFLDS_DURATION.isVisible"
											v-bind="controls.INFIELDSFLDS_DURATION.props"
											@update:model-value="model.ValDuration.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.INFIELDSFLDS_PRECOBIL.isVisible || controls.INFIELDSFLDS_PRICE___.isVisible">
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_PRECOBIL.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INFIELDSFLDS_PRECOBIL"
										v-on="controls.INFIELDSFLDS_PRECOBIL.handlers"
										:loading="controls.INFIELDSFLDS_PRECOBIL.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.INFIELDSFLDS_PRECOBIL.isVisible"
											v-bind="controls.INFIELDSFLDS_PRECOBIL.props"
											@update:model-value="model.ValPrecobil.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_PRICE___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INFIELDSFLDS_PRICE___"
										v-on="controls.INFIELDSFLDS_PRICE___.handlers"
										:loading="controls.INFIELDSFLDS_PRICE___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.INFIELDSFLDS_PRICE___.isVisible"
											v-bind="controls.INFIELDSFLDS_PRICE___.props"
											@update:model-value="model.ValPrice.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End INFIELDSPSEUDNOVOGR03 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.INFIELDSPSEUDNOVOGR05.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.INFIELDSPSEUDNOVOGR05.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="INFIELDSPSEUDNOVOGR05"
							v-bind="controls.INFIELDSPSEUDNOVOGR05"
							:is-visible="controls.INFIELDSPSEUDNOVOGR05.isVisible">
							<!-- Start INFIELDSPSEUDNOVOGR05 -->
							<q-row-container v-show="controls.INFIELDSFLDS_PASSFLD_.isVisible">
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_PASSFLD_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INFIELDSFLDS_PASSFLD_"
										v-on="controls.INFIELDSFLDS_PASSFLD_.handlers"
										:loading="controls.INFIELDSFLDS_PASSFLD_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-password-input
											v-if="controls.INFIELDSFLDS_PASSFLD_.isVisible"
											v-bind="controls.INFIELDSFLDS_PASSFLD_"
											:model-value="model.ValPassfld.value"
											:label-text="controls.INFIELDSFLDS_PASSFLD_.label"
											@update:model-value="model.ValPassfld.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.INFIELDSFLDS_CLRPICKE.isVisible">
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_CLRPICKE.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INFIELDSFLDS_CLRPICKE"
										v-on="controls.INFIELDSFLDS_CLRPICKE.handlers"
										:loading="controls.INFIELDSFLDS_CLRPICKE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.INFIELDSFLDS_CLRPICKE.props"
											@blur="onBlur(controls.INFIELDSFLDS_CLRPICKE, model.ValClrpicke.value)"
											@change="model.ValClrpicke.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End INFIELDSPSEUDNOVOGR05 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.INFIELDSPSEUDNOVOGR06.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.INFIELDSPSEUDNOVOGR06.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="INFIELDSPSEUDNOVOGR06"
							v-bind="controls.INFIELDSPSEUDNOVOGR06"
							:is-visible="controls.INFIELDSPSEUDNOVOGR06.isVisible">
							<!-- Start INFIELDSPSEUDNOVOGR06 -->
							<q-row-container v-show="controls.INFIELDSFLDS_PRIMVIAG.isVisible || controls.INFIELDSFLDS_LOGICENU.isVisible">
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_PRIMVIAG.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.INFIELDSFLDS_PRIMVIAG"
										v-on="controls.INFIELDSFLDS_PRIMVIAG.handlers"
										:loading="controls.INFIELDSFLDS_PRIMVIAG.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.INFIELDSFLDS_PRIMVIAG.isVisible"
												v-bind="controls.INFIELDSFLDS_PRIMVIAG.props"
												v-on="controls.INFIELDSFLDS_PRIMVIAG.handlers" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_LOGICENU.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.INFIELDSFLDS_LOGICENU"
										v-on="controls.INFIELDSFLDS_LOGICENU.handlers"
										:loading="controls.INFIELDSFLDS_LOGICENU.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-toggle-input
											v-if="controls.INFIELDSFLDS_LOGICENU.isVisible"
											v-bind="controls.INFIELDSFLDS_LOGICENU.props"
											v-on="controls.INFIELDSFLDS_LOGICENU.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.INFIELDSFLDS_RADIOB__.isVisible">
								<q-control-wrapper
									v-show="controls.INFIELDSFLDS_RADIOB__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-radio-container"
										v-bind="controls.INFIELDSFLDS_RADIOB__"
										v-on="controls.INFIELDSFLDS_RADIOB__.handlers"
										:label-position="labelAlignment.topleft"
										:loading="controls.INFIELDSFLDS_RADIOB__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-radio-group
											v-if="controls.INFIELDSFLDS_RADIOB__.isVisible"
											v-bind="controls.INFIELDSFLDS_RADIOB__.props"
											v-on="controls.INFIELDSFLDS_RADIOB__.handlers">
											<q-radio-button
												v-for="radio in controls.INFIELDSFLDS_RADIOB__.items"
												:key="radio.key"
												:label="radio.value"
												:value="radio.key" />
										</q-radio-group>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End INFIELDSPSEUDNOVOGR06 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.INFIELDSFLDS_CREATUSE.isVisible || controls.INFIELDSFLDS_CREATDAT.isVisible || controls.INFIELDSFLDS_CREATINS.isVisible || controls.INFIELDSFLDS_CREATHOU.isVisible">
					<q-control-wrapper
						v-show="controls.INFIELDSFLDS_CREATUSE.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.INFIELDSFLDS_CREATUSE"
							v-on="controls.INFIELDSFLDS_CREATUSE.handlers"
							:loading="controls.INFIELDSFLDS_CREATUSE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.INFIELDSFLDS_CREATUSE.props"
								@blur="onBlur(controls.INFIELDSFLDS_CREATUSE, model.ValCreatuse.value)"
								@change="model.ValCreatuse.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.INFIELDSFLDS_CREATDAT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.INFIELDSFLDS_CREATDAT"
							v-on="controls.INFIELDSFLDS_CREATDAT.handlers"
							:loading="controls.INFIELDSFLDS_CREATDAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.INFIELDSFLDS_CREATDAT.isVisible"
								v-bind="controls.INFIELDSFLDS_CREATDAT.props"
								:model-value="model.ValCreatdat.value"
								@reset-icon-click="model.ValCreatdat.fnUpdateValue(model.ValCreatdat.originalValue ?? new Date())"
								@update:model-value="model.ValCreatdat.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.INFIELDSFLDS_CREATINS.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.INFIELDSFLDS_CREATINS"
							v-on="controls.INFIELDSFLDS_CREATINS.handlers"
							:loading="controls.INFIELDSFLDS_CREATINS.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.INFIELDSFLDS_CREATINS.isVisible"
								v-bind="controls.INFIELDSFLDS_CREATINS.props"
								:model-value="model.ValCreatins.value"
								@reset-icon-click="model.ValCreatins.fnUpdateValue(model.ValCreatins.originalValue ?? new Date())"
								@update:model-value="model.ValCreatins.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.INFIELDSFLDS_CREATHOU.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.INFIELDSFLDS_CREATHOU"
							v-on="controls.INFIELDSFLDS_CREATHOU.handlers"
							:loading="controls.INFIELDSFLDS_CREATHOU.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.INFIELDSFLDS_CREATHOU.isVisible"
								v-bind="controls.INFIELDSFLDS_CREATHOU.props"
								:model-value="model.ValCreathou.value"
								@reset-icon-click="model.ValCreathou.fnUpdateValue(model.ValCreathou.originalValue ?? new Date())"
								@update:model-value="model.ValCreathou.fnUpdateValue($event ?? '')" />
						</base-input-structure>
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

	import FormViewModel from './QFormInfieldsViewModel.js'

	const requiredTextResources = ['QFormInfields', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS INFIELDS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormInfields',

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
					name: 'INFIELDS',
					location: 'form-INFIELDS',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormInfields', false),

				interfaceMetadata: {
					id: 'QFormInfields', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'INFIELDS',
					route: 'form-INFIELDS',
					area: 'FLDS',
					primaryKey: 'ValCodflds',
					designation: computed(() => this.Resources.INPUT_FIELDS51344),
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
					INFIELDSPSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'INFIELDSPSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'block',
						label: computed(() => this.Resources.TEXT_INPUTS37770),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['INFIELDSFLDS_TXTFIELD', 'INFIELDSFLDS_DESCRIP_'],
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_TXTFIELD: new fieldControlClass.StringControl({
						modelField: 'ValTxtfield',
						valueChangeEvent: 'fieldChange:flds.txtfield',
						id: 'INFIELDSFLDS_TXTFIELD',
						name: 'TXTFIELD',
						size: 'large',
						label: computed(() => this.Resources.TEXT_FIELD41810),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR02',
						maxLength: 50,
						labelId: 'label_INFIELDSFLDS_TXTFIELD',
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_DESCRIP_: new fieldControlClass.MultilineStringControl({
						modelField: 'ValDescrip',
						valueChangeEvent: 'fieldChange:flds.descrip',
						id: 'INFIELDSFLDS_DESCRIP_',
						name: 'DESCRIP',
						size: 'large',
						label: computed(() => this.Resources.MULTINE_TEXT05310),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR02',
						rows: 1,
						cols: 30,
						controlLimits: [
						],
					}, this),
					INFIELDSPSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'INFIELDSPSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						label: computed(() => this.Resources.DATE_TIME_INPUTS06842),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['INFIELDSFLDS_YEAR____', 'INFIELDSFLDS_TIME____', 'INFIELDSFLDS_DATE____', 'INFIELDSFLDS_DATETIME', 'INFIELDSFLDS_DATESECO'],
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_YEAR____: new fieldControlClass.NumberControl({
						modelField: 'ValYear',
						valueChangeEvent: 'fieldChange:flds.year',
						id: 'INFIELDSFLDS_YEAR____',
						name: 'YEAR',
						size: 'mini',
						label: computed(() => this.Resources.YEAR61794),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR01',
						maxIntegers: 4,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_TIME____: new fieldControlClass.TimeControl({
						modelField: 'ValTime',
						valueChangeEvent: 'fieldChange:flds.time',
						id: 'INFIELDSFLDS_TIME____',
						name: 'TIME',
						size: 'mini',
						label: computed(() => this.Resources.TIME15328),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR01',
						dateTimeType: 'time',
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_DATE____: new fieldControlClass.DateControl({
						modelField: 'ValDate',
						valueChangeEvent: 'fieldChange:flds.date',
						id: 'INFIELDSFLDS_DATE____',
						name: 'DATE',
						size: 'small',
						label: computed(() => this.Resources.DATE18475),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR01',
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_DATETIME: new fieldControlClass.DateControl({
						modelField: 'ValDatetime',
						valueChangeEvent: 'fieldChange:flds.datetime',
						id: 'INFIELDSFLDS_DATETIME',
						name: 'DATETIME',
						size: 'medium',
						label: computed(() => this.Resources.DATE_TIME59103),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR01',
						dateTimeType: 'dateTime',
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_DATESECO: new fieldControlClass.DateControl({
						modelField: 'ValDateseco',
						valueChangeEvent: 'fieldChange:flds.dateseco',
						id: 'INFIELDSFLDS_DATESECO',
						name: 'DATESECO',
						size: 'medium',
						label: computed(() => this.Resources.DATE_SECOND44057),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR01',
						dateTimeType: 'dateTimeSeconds',
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_NPASSAGE: new fieldControlClass.NumberControl({
						modelField: 'ValNpassage',
						valueChangeEvent: 'fieldChange:flds.npassage',
						id: 'INFIELDSFLDS_NPASSAGE',
						name: 'NPASSAGE',
						size: 'mini',
						label: computed(() => this.Resources.NUMERIC19292),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR03',
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_DURATION: new fieldControlClass.NumberControl({
						modelField: 'ValDuration',
						valueChangeEvent: 'fieldChange:flds.duration',
						id: 'INFIELDSFLDS_DURATION',
						name: 'DURATION',
						size: 'small',
						label: computed(() => this.Resources.NUMERIC_DECIMAL49512),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR03',
						maxIntegers: 2,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_PRECOBIL: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrecobil',
						valueChangeEvent: 'fieldChange:flds.precobil',
						id: 'INFIELDSFLDS_PRECOBIL',
						name: 'PRECOBIL',
						size: 'small',
						label: computed(() => this.Resources.CURRENCY_DECIMAL48296),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR03',
						maxIntegers: 3,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_PRICE___: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrice',
						valueChangeEvent: 'fieldChange:flds.price',
						id: 'INFIELDSFLDS_PRICE___',
						name: 'PRICE',
						size: 'mini',
						label: computed(() => this.Resources.CURRENCY13881),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR03',
						maxIntegers: 3,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					INFIELDSPSEUDNOVOGR04: new fieldControlClass.GroupControl({
						id: 'INFIELDSPSEUDNOVOGR04',
						name: 'NOVOGR04',
						size: 'block',
						label: computed(() => this.Resources.INPUTS_WITH_MASKS08900),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['INFIELDSFLDS_SSNUMBER', 'INFIELDSFLDS_ZIPFIELD', 'INFIELDSFLDS_VATNUMBR', 'INFIELDSFLDS_LICPLATE', 'INFIELDSFLDS_BANKNMBR', 'INFIELDSFLDS_EMAILFLD', 'INFIELDSFLDS_IBANFIEL', 'INFIELDSFLDS_UPPRTEXT'],
						controlLimits: [
						],
					}, this),
					INFIELDSPSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'INFIELDSPSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'block',
						label: computed(() => this.Resources.NUMERIC_INPUTS64739),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['INFIELDSFLDS_NPASSAGE', 'INFIELDSFLDS_DURATION', 'INFIELDSFLDS_PRECOBIL', 'INFIELDSFLDS_PRICE___'],
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_SSNUMBER: new fieldControlClass.MaskControl({
						modelField: 'ValSsnumber',
						valueChangeEvent: 'fieldChange:flds.ssnumber',
						id: 'INFIELDSFLDS_SSNUMBER',
						name: 'SSNUMBER',
						size: 'medium',
						label: computed(() => this.Resources.SOCIAL_SECURITY_NO48150),
						placeholder: computed(() => this.Resources._1234567891237929),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR04',
						maxLength: 11,
						labelId: 'label_INFIELDSFLDS_SSNUMBER',
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_ZIPFIELD: new fieldControlClass.MaskControl({
						modelField: 'ValZipfield',
						valueChangeEvent: 'fieldChange:flds.zipfield',
						id: 'INFIELDSFLDS_ZIPFIELD',
						name: 'ZIPFIELD',
						size: 'small',
						label: computed(() => this.Resources.ZIPCODE21021),
						placeholder: computed(() => this.Resources.XXXX_XXX51420),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR04',
						maxLength: 8,
						labelId: 'label_INFIELDSFLDS_ZIPFIELD',
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_VATNUMBR: new fieldControlClass.MaskControl({
						modelField: 'ValVatnumbr',
						valueChangeEvent: 'fieldChange:flds.vatnumbr',
						id: 'INFIELDSFLDS_VATNUMBR',
						name: 'VATNUMBR',
						size: 'small',
						label: computed(() => this.Resources.VAT_NUMBER24236),
						placeholder: computed(() => this.Resources._12345678953785),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR04',
						maxLength: 9,
						labelId: 'label_INFIELDSFLDS_VATNUMBR',
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_LICPLATE: new fieldControlClass.MaskControl({
						modelField: 'ValLicplate',
						valueChangeEvent: 'fieldChange:flds.licplate',
						id: 'INFIELDSFLDS_LICPLATE',
						name: 'LICPLATE',
						size: 'small',
						label: computed(() => this.Resources.LICENCE_PLATE07627),
						placeholder: computed(() => this.Resources.XX_00_XX10122),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR04',
						maxLength: 8,
						labelId: 'label_INFIELDSFLDS_LICPLATE',
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_BANKNMBR: new fieldControlClass.MaskControl({
						modelField: 'ValBanknmbr',
						valueChangeEvent: 'fieldChange:flds.banknmbr',
						id: 'INFIELDSFLDS_BANKNMBR',
						name: 'BANKNMBR',
						size: 'large',
						label: computed(() => this.Resources.BANKING_ACCOUNT_NUMB62548),
						placeholder: computed(() => this.Resources._1234_5678_90123456761043),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR04',
						maxLength: 24,
						labelId: 'label_INFIELDSFLDS_BANKNMBR',
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_EMAILFLD: new fieldControlClass.MaskControl({
						modelField: 'ValEmailfld',
						valueChangeEvent: 'fieldChange:flds.emailfld',
						id: 'INFIELDSFLDS_EMAILFLD',
						name: 'EMAILFLD',
						size: 'large',
						label: computed(() => this.Resources.EMAIL25170),
						placeholder: computed(() => this.Resources.QUIDGESTAT_QUIDGEST_PT47872),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR04',
						maxLength: 50,
						labelId: 'label_INFIELDSFLDS_EMAILFLD',
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_IBANFIEL: new fieldControlClass.MaskControl({
						modelField: 'ValIbanfiel',
						valueChangeEvent: 'fieldChange:flds.ibanfiel',
						id: 'INFIELDSFLDS_IBANFIEL',
						name: 'IBANFIEL',
						size: 'large',
						label: computed(() => this.Resources.IBAN28506),
						placeholder: computed(() => this.Resources.PT12345678901234567820477),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR04',
						maxLength: 34,
						labelId: 'label_INFIELDSFLDS_IBANFIEL',
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_UPPRTEXT: new fieldControlClass.MaskControl({
						modelField: 'ValUpprtext',
						valueChangeEvent: 'fieldChange:flds.upprtext',
						id: 'INFIELDSFLDS_UPPRTEXT',
						name: 'UPPRTEXT',
						size: 'xlarge',
						label: computed(() => this.Resources.UPPERCASE48238),
						placeholder: computed(() => this.Resources.QUIDGEST56322),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR04',
						maxLength: 50,
						labelId: 'label_INFIELDSFLDS_UPPRTEXT',
						controlLimits: [
						],
					}, this),
					INFIELDSPSEUDNOVOGR05: new fieldControlClass.GroupControl({
						id: 'INFIELDSPSEUDNOVOGR05',
						name: 'NOVOGR05',
						size: 'block',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['INFIELDSFLDS_PASSFLD_', 'INFIELDSFLDS_CLRPICKE'],
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_PASSFLD_: new fieldControlClass.StringControl({
						modelField: 'ValPassfld',
						valueChangeEvent: 'fieldChange:flds.passfld',
						id: 'INFIELDSFLDS_PASSFLD_',
						name: 'PASSFLD',
						size: 'large',
						label: computed(() => this.Resources.PASSWORD09467),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR05',
						controlLimits: [
						],
					}, this),
					ConfirmINFIELDSFLDS_PASSFLD_: new fieldControlClass.StringControl({
						modelField: 'ConfirmValPassfld',
						id: 'ConfirmINFIELDSFLDS_PASSFLD_',
						name: 'ConfirmPASSFLD',
						size: 'large',
						label: computed(() => this.Resources.CONFIRMAR09808),
						placeholder: computed(() => this.Resources.CONFIRMAR09808),
						// Hide confirmation field in non-editable mode.
						hiddenInNonEditableMode: true
					}, this),
					INFIELDSFLDS_CLRPICKE: new fieldControlClass.StringControl({
						modelField: 'ValClrpicke',
						valueChangeEvent: 'fieldChange:flds.clrpicke',
						id: 'INFIELDSFLDS_CLRPICKE',
						name: 'CLRPICKE',
						size: 'large',
						label: computed(() => this.Resources.COLORPICKER39653),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR05',
						maxLength: 50,
						labelId: 'label_INFIELDSFLDS_CLRPICKE',
						controlLimits: [
						],
					}, this),
					INFIELDSPSEUDNOVOGR06: new fieldControlClass.GroupControl({
						id: 'INFIELDSPSEUDNOVOGR06',
						name: 'NOVOGR06',
						size: 'block',
						label: computed(() => this.Resources.OTHER_INPUTS32089),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['INFIELDSFLDS_PRIMVIAG', 'INFIELDSFLDS_LOGICENU', 'INFIELDSFLDS_RADIOB__'],
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_PRIMVIAG: new fieldControlClass.BooleanControl({
						modelField: 'ValPrimviag',
						valueChangeEvent: 'fieldChange:flds.primviag',
						id: 'INFIELDSFLDS_PRIMVIAG',
						name: 'PRIMVIAG',
						size: 'mini',
						label: computed(() => this.Resources.LOGICAL47485),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'INFIELDSPSEUDNOVOGR06',
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_LOGICENU: new fieldControlClass.ArrayBooleanControl({
						modelField: 'ValLogicenu',
						valueChangeEvent: 'fieldChange:flds.logicenu',
						id: 'INFIELDSFLDS_LOGICENU',
						name: 'LOGICENU',
						size: 'mini',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'INFIELDSPSEUDNOVOGR06',
						maxIntegers: 1,
						maxDecimals: 0,
						arrayName: 'PRIMVIAG',
						trueLabel: computed(() => this.Resources.YES34196),
						falseLabel: computed(() => this.Resources.NO57340),
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_CREATUSE: new fieldControlClass.StringControl({
						modelField: 'ValCreatuse',
						valueChangeEvent: 'fieldChange:flds.creatuse',
						id: 'INFIELDSFLDS_CREATUSE',
						name: 'CREATUSE',
						size: 'medium',
						label: computed(() => this.Resources.CREATED_BY12292),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 20,
						labelId: 'label_INFIELDSFLDS_CREATUSE',
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_CREATDAT: new fieldControlClass.DateControl({
						modelField: 'ValCreatdat',
						valueChangeEvent: 'fieldChange:flds.creatdat',
						id: 'INFIELDSFLDS_CREATDAT',
						name: 'CREATDAT',
						size: 'small',
						label: computed(() => this.Resources.DAY27593),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_CREATINS: new fieldControlClass.DateControl({
						modelField: 'ValCreatins',
						valueChangeEvent: 'fieldChange:flds.creatins',
						id: 'INFIELDSFLDS_CREATINS',
						name: 'CREATINS',
						size: 'medium',
						label: computed(() => this.Resources.COMPLETE_DATE53774),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'dateTimeSeconds',
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_CREATHOU: new fieldControlClass.TimeControl({
						modelField: 'ValCreathou',
						valueChangeEvent: 'fieldChange:flds.creathou',
						id: 'INFIELDSFLDS_CREATHOU',
						name: 'CREATHOU',
						size: 'mini',
						label: computed(() => this.Resources.HOUR15646),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'time',
						controlLimits: [
						],
					}, this),
					INFIELDSFLDS_RADIOB__: new fieldControlClass.ArrayStringControl({
						modelField: 'ValRadiob',
						valueChangeEvent: 'fieldChange:flds.radiob',
						id: 'INFIELDSFLDS_RADIOB__',
						name: 'RADIOB',
						label: computed(() => this.Resources.RADIO_BTN20980),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'INFIELDSPSEUDNOVOGR06',
						maxLength: 5,
						labelId: 'label_INFIELDSFLDS_RADIOB__',
						arrayName: 'RADIOBTN',
						columns: 2,
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
					'INFIELDSPSEUDNOVOGR02',
					'INFIELDSPSEUDNOVOGR01',
					'INFIELDSPSEUDNOVOGR04',
					'INFIELDSPSEUDNOVOGR03',
					'INFIELDSPSEUDNOVOGR05',
					'INFIELDSPSEUDNOVOGR06',
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
						get ValBanknmbr() { return vm.model.ValBanknmbr.value },
						set ValBanknmbr(value) { vm.model.ValBanknmbr.updateValue(value) },
						get ValClrpicke() { return vm.model.ValClrpicke.value },
						set ValClrpicke(value) { vm.model.ValClrpicke.updateValue(value) },
						get ValCodaero() { return vm.model.ValCodaero.value },
						set ValCodaero(value) { vm.model.ValCodaero.updateValue(value) },
						get ValCodequip() { return vm.model.ValCodequip.value },
						set ValCodequip(value) { vm.model.ValCodequip.updateValue(value) },
						get ValCond() { return vm.model.ValCond.value },
						set ValCond(value) { vm.model.ValCond.updateValue(value) },
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
						get ValNpassage() { return vm.model.ValNpassage.value },
						set ValNpassage(value) { vm.model.ValNpassage.updateValue(value) },
						get ValPassfld() { return vm.model.ValPassfld.value },
						set ValPassfld(value) { vm.model.ValPassfld.updateValue(value) },
						get ValPrecobil() { return vm.model.ValPrecobil.value },
						set ValPrecobil(value) { vm.model.ValPrecobil.updateValue(value) },
						get ValPrice() { return vm.model.ValPrice.value },
						set ValPrice(value) { vm.model.ValPrice.updateValue(value) },
						get ValPrimviag() { return vm.model.ValPrimviag.value },
						set ValPrimviag(value) { vm.model.ValPrimviag.updateValue(value) },
						get ValRadiob() { return vm.model.ValRadiob.value },
						set ValRadiob(value) { vm.model.ValRadiob.updateValue(value) },
						get ValSsnumber() { return vm.model.ValSsnumber.value },
						set ValSsnumber(value) { vm.model.ValSsnumber.updateValue(value) },
						get ValTblcond() { return vm.model.ValTblcond.value },
						set ValTblcond(value) { vm.model.ValTblcond.updateValue(value) },
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
// USE /[MANUAL GQT FORM_CODEJS INFIELDS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT INFIELDS]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS INFIELDS]/
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
// USE /[MANUAL GQT FORM_LOADED_JS INFIELDS]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS INFIELDS]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS INFIELDS]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS INFIELDS]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS INFIELDS]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS INFIELDS]/
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
// USE /[MANUAL GQT AFTER_DEL_JS INFIELDS]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS INFIELDS]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS INFIELDS]/
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
// USE /[MANUAL GQT DLGUPDT INFIELDS]/
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
// USE /[MANUAL GQT CTRLBLR INFIELDS]/
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
// USE /[MANUAL GQT CTRLUPD INFIELDS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS INFIELDS]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
