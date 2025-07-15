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
			data-key="FLDSTBL"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.FLDSTBL_PSEUDNOVOGR02.isVisible || controls.FLDSTBL_PSEUDNOVOGR06.isVisible || controls.FLDSTBL_PSEUDNOVOGR01.isVisible || controls.FLDSTBL_PSEUDNOVOGR03.isVisible || controls.FLDSTBL_PSEUDNOVOGR04.isVisible || controls.FLDSTBL_PSEUDNOVOGR05.isVisible || controls.FLDSTBL_PSEUDNOVOGR07.isVisible || controls.FLDSTBL_FLDS_CREATDAT.isVisible || controls.FLDSTBL_FLDS_CREATUSE.isVisible || controls.FLDSTBL_FLDS_CREATINS.isVisible || controls.FLDSTBL_FLDS_CREATHOU.isVisible || controls.FLDSTBL_PSEUDFEECA___.isVisible">
					<q-control-wrapper
						v-show="controls.FLDSTBL_PSEUDNOVOGR02.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="FLDSTBL_PSEUDNOVOGR02"
							v-bind="controls.FLDSTBL_PSEUDNOVOGR02"
							:is-visible="controls.FLDSTBL_PSEUDNOVOGR02.isVisible">
							<!-- Start FLDSTBL_PSEUDNOVOGR02 -->
							<q-row-container v-show="controls.FLDSTBL_FLDS_TXTFIELD.isVisible || controls.FLDSTBL_FLDS_DESCRIP_.isVisible">
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_TXTFIELD.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_TXTFIELD"
										v-on="controls.FLDSTBL_FLDS_TXTFIELD.handlers"
										:loading="controls.FLDSTBL_FLDS_TXTFIELD.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.FLDSTBL_FLDS_TXTFIELD.props"
											@blur="onBlur(controls.FLDSTBL_FLDS_TXTFIELD, model.ValTxtfield.value)"
											@change="model.ValTxtfield.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_DESCRIP_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-textarea"
										v-bind="controls.FLDSTBL_FLDS_DESCRIP_"
										v-on="controls.FLDSTBL_FLDS_DESCRIP_.handlers"
										:loading="controls.FLDSTBL_FLDS_DESCRIP_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-area
											v-if="controls.FLDSTBL_FLDS_DESCRIP_.isVisible"
											v-bind="controls.FLDSTBL_FLDS_DESCRIP_.props"
											v-on="controls.FLDSTBL_FLDS_DESCRIP_.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End FLDSTBL_PSEUDNOVOGR02 -->
						</q-group-box-container>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FLDSTBL_PSEUDNOVOGR06.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="FLDSTBL_PSEUDNOVOGR06"
							v-bind="controls.FLDSTBL_PSEUDNOVOGR06"
							:is-visible="controls.FLDSTBL_PSEUDNOVOGR06.isVisible">
							<!-- Start FLDSTBL_PSEUDNOVOGR06 -->
							<q-row-container v-show="controls.FLDSTBL_FLDS_PRIMVIAG.isVisible || controls.FLDSTBL_FLDS_LOGICENU.isVisible || controls.FLDSTBL_FLDS_CLASSNUM.isVisible || controls.FLDSTBL_FLDS_RADIOB__.isVisible || controls.FLDSTBL_PSEUDFIELD002.isVisible || controls.FLDSTBL_PSEUDFIELD003.isVisible || controls.FLDSTBL_PSEUDFIELD001.isVisible">
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_PRIMVIAG.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.FLDSTBL_FLDS_PRIMVIAG"
										v-on="controls.FLDSTBL_FLDS_PRIMVIAG.handlers"
										:loading="controls.FLDSTBL_FLDS_PRIMVIAG.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.FLDSTBL_FLDS_PRIMVIAG.isVisible"
												v-bind="controls.FLDSTBL_FLDS_PRIMVIAG.props"
												v-on="controls.FLDSTBL_FLDS_PRIMVIAG.handlers" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_LOGICENU.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_LOGICENU"
										v-on="controls.FLDSTBL_FLDS_LOGICENU.handlers"
										:loading="controls.FLDSTBL_FLDS_LOGICENU.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-toggle-input
											v-if="controls.FLDSTBL_FLDS_LOGICENU.isVisible"
											v-bind="controls.FLDSTBL_FLDS_LOGICENU.props"
											v-on="controls.FLDSTBL_FLDS_LOGICENU.handlers" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_CLASSNUM.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_CLASSNUM"
										v-on="controls.FLDSTBL_FLDS_CLASSNUM.handlers"
										:loading="controls.FLDSTBL_FLDS_CLASSNUM.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.FLDSTBL_FLDS_CLASSNUM.isVisible"
											v-bind="controls.FLDSTBL_FLDS_CLASSNUM.props"
											@update:model-value="model.ValClassnum.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_RADIOB__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-radio-container"
										v-bind="controls.FLDSTBL_FLDS_RADIOB__"
										v-on="controls.FLDSTBL_FLDS_RADIOB__.handlers"
										:label-position="labelAlignment.topleft"
										:loading="controls.FLDSTBL_FLDS_RADIOB__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-radio-group
											v-if="controls.FLDSTBL_FLDS_RADIOB__.isVisible"
											v-bind="controls.FLDSTBL_FLDS_RADIOB__.props"
											v-on="controls.FLDSTBL_FLDS_RADIOB__.handlers">
											<q-radio-button
												v-for="radio in controls.FLDSTBL_FLDS_RADIOB__.items"
												:key="radio.key"
												:label="radio.value"
												:value="radio.key" />
										</q-radio-group>
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_PSEUDFIELD002.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-static-text"
										v-bind="controls.FLDSTBL_PSEUDFIELD002"
										v-on="controls.FLDSTBL_PSEUDFIELD002.handlers"
										:loading="controls.FLDSTBL_PSEUDFIELD002.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-static-text
											v-if="controls.FLDSTBL_PSEUDFIELD002.isVisible"
											id="FLDSTBL_PSEUDFIELD002"
											:size="controls.FLDSTBL_PSEUDFIELD002.size"
											:text="controls.FLDSTBL_PSEUDFIELD002.label" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_PSEUDFIELD003.isVisible"
									class="control-join-group">
									<base-input-structure
										class="q-image"
										v-bind="controls.FLDSTBL_PSEUDFIELD003"
										v-on="controls.FLDSTBL_PSEUDFIELD003.handlers"
										:loading="controls.FLDSTBL_PSEUDFIELD003.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-image
											v-if="controls.FLDSTBL_PSEUDFIELD003.isVisible"
											v-bind="controls.FLDSTBL_PSEUDFIELD003.props"
											v-on="controls.FLDSTBL_PSEUDFIELD003.handlers" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_PSEUDFIELD001.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_PSEUDFIELD001"
										v-on="controls.FLDSTBL_PSEUDFIELD001.handlers"
										:loading="controls.FLDSTBL_PSEUDFIELD001.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.FLDSTBL_PSEUDFIELD001.props"
											@blur="onBlur(controls.FLDSTBL_PSEUDFIELD001, model.PseudValField001.value)"
											@change="model.PseudValField001.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End FLDSTBL_PSEUDNOVOGR06 -->
						</q-group-box-container>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FLDSTBL_PSEUDNOVOGR01.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="FLDSTBL_PSEUDNOVOGR01"
							v-bind="controls.FLDSTBL_PSEUDNOVOGR01"
							:is-visible="controls.FLDSTBL_PSEUDNOVOGR01.isVisible">
							<!-- Start FLDSTBL_PSEUDNOVOGR01 -->
							<q-row-container v-show="controls.FLDSTBL_FLDS_YEAR____.isVisible || controls.FLDSTBL_FLDS_TIME____.isVisible || controls.FLDSTBL_FLDS_DATE____.isVisible || controls.FLDSTBL_FLDS_DATETIME.isVisible || controls.FLDSTBL_FLDS_DATESECO.isVisible">
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_YEAR____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_YEAR____"
										v-on="controls.FLDSTBL_FLDS_YEAR____.handlers"
										:loading="controls.FLDSTBL_FLDS_YEAR____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.FLDSTBL_FLDS_YEAR____.isVisible"
											v-bind="controls.FLDSTBL_FLDS_YEAR____.props"
											@update:model-value="model.ValYear.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_TIME____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_TIME____"
										v-on="controls.FLDSTBL_FLDS_TIME____.handlers"
										:loading="controls.FLDSTBL_FLDS_TIME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.FLDSTBL_FLDS_TIME____.isVisible"
											v-bind="controls.FLDSTBL_FLDS_TIME____.props"
											:model-value="model.ValTime.value"
											@reset-icon-click="model.ValTime.fnUpdateValue(model.ValTime.originalValue ?? new Date())"
											@update:model-value="model.ValTime.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_DATE____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_DATE____"
										v-on="controls.FLDSTBL_FLDS_DATE____.handlers"
										:loading="controls.FLDSTBL_FLDS_DATE____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.FLDSTBL_FLDS_DATE____.isVisible"
											v-bind="controls.FLDSTBL_FLDS_DATE____.props"
											:model-value="model.ValDate.value"
											@reset-icon-click="model.ValDate.fnUpdateValue(model.ValDate.originalValue ?? new Date())"
											@update:model-value="model.ValDate.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_DATETIME.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_DATETIME"
										v-on="controls.FLDSTBL_FLDS_DATETIME.handlers"
										:loading="controls.FLDSTBL_FLDS_DATETIME.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.FLDSTBL_FLDS_DATETIME.isVisible"
											v-bind="controls.FLDSTBL_FLDS_DATETIME.props"
											:model-value="model.ValDatetime.value"
											@reset-icon-click="model.ValDatetime.fnUpdateValue(model.ValDatetime.originalValue ?? new Date())"
											@update:model-value="model.ValDatetime.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_DATESECO.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_DATESECO"
										v-on="controls.FLDSTBL_FLDS_DATESECO.handlers"
										:loading="controls.FLDSTBL_FLDS_DATESECO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.FLDSTBL_FLDS_DATESECO.isVisible"
											v-bind="controls.FLDSTBL_FLDS_DATESECO.props"
											:model-value="model.ValDateseco.value"
											@reset-icon-click="model.ValDateseco.fnUpdateValue(model.ValDateseco.originalValue ?? new Date())"
											@update:model-value="model.ValDateseco.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End FLDSTBL_PSEUDNOVOGR01 -->
						</q-group-box-container>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FLDSTBL_PSEUDNOVOGR03.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="FLDSTBL_PSEUDNOVOGR03"
							v-bind="controls.FLDSTBL_PSEUDNOVOGR03"
							:is-visible="controls.FLDSTBL_PSEUDNOVOGR03.isVisible">
							<!-- Start FLDSTBL_PSEUDNOVOGR03 -->
							<q-row-container v-show="controls.FLDSTBL_FLDS_DURATION.isVisible || controls.FLDSTBL_FLDS_NPASSAGE.isVisible || controls.FLDSTBL_FLDS_PRECOBIL.isVisible || controls.FLDSTBL_FLDS_PRICE___.isVisible">
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_DURATION.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_DURATION"
										v-on="controls.FLDSTBL_FLDS_DURATION.handlers"
										:loading="controls.FLDSTBL_FLDS_DURATION.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.FLDSTBL_FLDS_DURATION.isVisible"
											v-bind="controls.FLDSTBL_FLDS_DURATION.props"
											@update:model-value="model.ValDuration.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_NPASSAGE.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_NPASSAGE"
										v-on="controls.FLDSTBL_FLDS_NPASSAGE.handlers"
										:loading="controls.FLDSTBL_FLDS_NPASSAGE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.FLDSTBL_FLDS_NPASSAGE.isVisible"
											v-bind="controls.FLDSTBL_FLDS_NPASSAGE.props"
											@update:model-value="model.ValNpassage.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_PRECOBIL.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_PRECOBIL"
										v-on="controls.FLDSTBL_FLDS_PRECOBIL.handlers"
										:loading="controls.FLDSTBL_FLDS_PRECOBIL.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.FLDSTBL_FLDS_PRECOBIL.isVisible"
											v-bind="controls.FLDSTBL_FLDS_PRECOBIL.props"
											@update:model-value="model.ValPrecobil.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_PRICE___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_PRICE___"
										v-on="controls.FLDSTBL_FLDS_PRICE___.handlers"
										:loading="controls.FLDSTBL_FLDS_PRICE___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.FLDSTBL_FLDS_PRICE___.isVisible"
											v-bind="controls.FLDSTBL_FLDS_PRICE___.props"
											@update:model-value="model.ValPrice.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End FLDSTBL_PSEUDNOVOGR03 -->
						</q-group-box-container>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FLDSTBL_PSEUDNOVOGR04.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="FLDSTBL_PSEUDNOVOGR04"
							v-bind="controls.FLDSTBL_PSEUDNOVOGR04"
							:is-visible="controls.FLDSTBL_PSEUDNOVOGR04.isVisible">
							<!-- Start FLDSTBL_PSEUDNOVOGR04 -->
							<q-row-container v-show="controls.FLDSTBL_FLDS_SSNUMBER.isVisible || controls.FLDSTBL_FLDS_ZIPFIELD.isVisible || controls.FLDSTBL_FLDS_VATNUMBR.isVisible || controls.FLDSTBL_FLDS_LICPLATE.isVisible || controls.FLDSTBL_FLDS_BANKNMBR.isVisible || controls.FLDSTBL_FLDS_EMAILFLD.isVisible || controls.FLDSTBL_FLDS_IBANFIEL.isVisible || controls.FLDSTBL_FLDS_UPPRTEXT.isVisible || controls.FLDSTBL_FLDS_NRCNTRY_.isVisible">
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_SSNUMBER.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_SSNUMBER"
										v-on="controls.FLDSTBL_FLDS_SSNUMBER.handlers"
										:loading="controls.FLDSTBL_FLDS_SSNUMBER.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.FLDSTBL_FLDS_SSNUMBER.isVisible"
											v-bind="controls.FLDSTBL_FLDS_SSNUMBER"
											:model-value="model.ValSsnumber.value"
											@update:model-value="model.ValSsnumber.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_ZIPFIELD.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_ZIPFIELD"
										v-on="controls.FLDSTBL_FLDS_ZIPFIELD.handlers"
										:loading="controls.FLDSTBL_FLDS_ZIPFIELD.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.FLDSTBL_FLDS_ZIPFIELD.isVisible"
											v-bind="controls.FLDSTBL_FLDS_ZIPFIELD"
											:model-value="model.ValZipfield.value"
											@update:model-value="model.ValZipfield.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_VATNUMBR.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_VATNUMBR"
										v-on="controls.FLDSTBL_FLDS_VATNUMBR.handlers"
										:loading="controls.FLDSTBL_FLDS_VATNUMBR.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.FLDSTBL_FLDS_VATNUMBR.isVisible"
											v-bind="controls.FLDSTBL_FLDS_VATNUMBR"
											:model-value="model.ValVatnumbr.value"
											@update:model-value="model.ValVatnumbr.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_LICPLATE.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_LICPLATE"
										v-on="controls.FLDSTBL_FLDS_LICPLATE.handlers"
										:loading="controls.FLDSTBL_FLDS_LICPLATE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.FLDSTBL_FLDS_LICPLATE.isVisible"
											v-bind="controls.FLDSTBL_FLDS_LICPLATE"
											:model-value="model.ValLicplate.value"
											@update:model-value="model.ValLicplate.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_BANKNMBR.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_BANKNMBR"
										v-on="controls.FLDSTBL_FLDS_BANKNMBR.handlers"
										:loading="controls.FLDSTBL_FLDS_BANKNMBR.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.FLDSTBL_FLDS_BANKNMBR.isVisible"
											v-bind="controls.FLDSTBL_FLDS_BANKNMBR"
											:model-value="model.ValBanknmbr.value"
											@update:model-value="model.ValBanknmbr.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_EMAILFLD.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_EMAILFLD"
										v-on="controls.FLDSTBL_FLDS_EMAILFLD.handlers"
										:loading="controls.FLDSTBL_FLDS_EMAILFLD.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.FLDSTBL_FLDS_EMAILFLD.isVisible"
											v-bind="controls.FLDSTBL_FLDS_EMAILFLD"
											:model-value="model.ValEmailfld.value"
											@update:model-value="model.ValEmailfld.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_IBANFIEL.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_IBANFIEL"
										v-on="controls.FLDSTBL_FLDS_IBANFIEL.handlers"
										:loading="controls.FLDSTBL_FLDS_IBANFIEL.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.FLDSTBL_FLDS_IBANFIEL.isVisible"
											v-bind="controls.FLDSTBL_FLDS_IBANFIEL"
											:model-value="model.ValIbanfiel.value"
											@update:model-value="model.ValIbanfiel.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_UPPRTEXT.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_UPPRTEXT"
										v-on="controls.FLDSTBL_FLDS_UPPRTEXT.handlers"
										:loading="controls.FLDSTBL_FLDS_UPPRTEXT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.FLDSTBL_FLDS_UPPRTEXT.isVisible"
											v-bind="controls.FLDSTBL_FLDS_UPPRTEXT"
											:model-value="model.ValUpprtext.value"
											@update:model-value="model.ValUpprtext.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_NRCNTRY_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_NRCNTRY_"
										v-on="controls.FLDSTBL_FLDS_NRCNTRY_.handlers"
										:loading="controls.FLDSTBL_FLDS_NRCNTRY_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.FLDSTBL_FLDS_NRCNTRY_.isVisible"
											v-bind="controls.FLDSTBL_FLDS_NRCNTRY_.props"
											@update:model-value="model.ValNrcntry.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End FLDSTBL_PSEUDNOVOGR04 -->
						</q-group-box-container>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FLDSTBL_PSEUDNOVOGR05.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="FLDSTBL_PSEUDNOVOGR05"
							v-bind="controls.FLDSTBL_PSEUDNOVOGR05"
							:is-visible="controls.FLDSTBL_PSEUDNOVOGR05.isVisible">
							<!-- Start FLDSTBL_PSEUDNOVOGR05 -->
							<q-row-container v-show="controls.FLDSTBL_FLDS_PASSFLD_.isVisible || controls.FLDSTBL_FLDS_CLRPICKE.isVisible">
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_PASSFLD_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_PASSFLD_"
										v-on="controls.FLDSTBL_FLDS_PASSFLD_.handlers"
										:loading="controls.FLDSTBL_FLDS_PASSFLD_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.FLDSTBL_FLDS_PASSFLD_.props"
											@blur="onBlur(controls.FLDSTBL_FLDS_PASSFLD_, model.ValPassfld.value)"
											@change="model.ValPassfld.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_CLRPICKE.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_CLRPICKE"
										v-on="controls.FLDSTBL_FLDS_CLRPICKE.handlers"
										:loading="controls.FLDSTBL_FLDS_CLRPICKE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.FLDSTBL_FLDS_CLRPICKE.props"
											@blur="onBlur(controls.FLDSTBL_FLDS_CLRPICKE, model.ValClrpicke.value)"
											@change="model.ValClrpicke.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End FLDSTBL_PSEUDNOVOGR05 -->
						</q-group-box-container>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FLDSTBL_PSEUDNOVOGR07.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="FLDSTBL_PSEUDNOVOGR07"
							v-bind="controls.FLDSTBL_PSEUDNOVOGR07"
							:is-visible="controls.FLDSTBL_PSEUDNOVOGR07.isVisible">
							<!-- Start FLDSTBL_PSEUDNOVOGR07 -->
							<q-row-container v-show="controls.FLDSTBL_FLDS_LOGOEXTE.isVisible || controls.FLDSTBL_FLDS_LOGO____.isVisible || controls.FLDSTBL_FLDS_ATTACH__.isVisible">
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_LOGOEXTE.isVisible"
									class="control-join-group">
									<base-input-structure
										class="q-image"
										v-bind="controls.FLDSTBL_FLDS_LOGOEXTE"
										v-on="controls.FLDSTBL_FLDS_LOGOEXTE.handlers"
										:loading="controls.FLDSTBL_FLDS_LOGOEXTE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-image
											v-if="controls.FLDSTBL_FLDS_LOGOEXTE.isVisible"
											v-bind="controls.FLDSTBL_FLDS_LOGOEXTE.props"
											v-on="controls.FLDSTBL_FLDS_LOGOEXTE.handlers" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_LOGO____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="q-image"
										v-bind="controls.FLDSTBL_FLDS_LOGO____"
										v-on="controls.FLDSTBL_FLDS_LOGO____.handlers"
										:loading="controls.FLDSTBL_FLDS_LOGO____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-image
											v-if="controls.FLDSTBL_FLDS_LOGO____.isVisible"
											v-bind="controls.FLDSTBL_FLDS_LOGO____.props"
											v-on="controls.FLDSTBL_FLDS_LOGO____.handlers" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FLDSTBL_FLDS_ATTACH__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FLDSTBL_FLDS_ATTACH__"
										v-on="controls.FLDSTBL_FLDS_ATTACH__.handlers"
										:loading="controls.FLDSTBL_FLDS_ATTACH__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-document
											v-if="controls.FLDSTBL_FLDS_ATTACH__.isVisible"
											v-bind="controls.FLDSTBL_FLDS_ATTACH__.props"
											v-on="controls.FLDSTBL_FLDS_ATTACH__.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End FLDSTBL_PSEUDNOVOGR07 -->
						</q-group-box-container>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FLDSTBL_FLDS_CREATDAT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.FLDSTBL_FLDS_CREATDAT"
							v-on="controls.FLDSTBL_FLDS_CREATDAT.handlers"
							:loading="controls.FLDSTBL_FLDS_CREATDAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.FLDSTBL_FLDS_CREATDAT.isVisible"
								v-bind="controls.FLDSTBL_FLDS_CREATDAT.props"
								:model-value="model.ValCreatdat.value"
								@reset-icon-click="model.ValCreatdat.fnUpdateValue(model.ValCreatdat.originalValue ?? new Date())"
								@update:model-value="model.ValCreatdat.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FLDSTBL_FLDS_CREATUSE.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.FLDSTBL_FLDS_CREATUSE"
							v-on="controls.FLDSTBL_FLDS_CREATUSE.handlers"
							:loading="controls.FLDSTBL_FLDS_CREATUSE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.FLDSTBL_FLDS_CREATUSE.props"
								@blur="onBlur(controls.FLDSTBL_FLDS_CREATUSE, model.ValCreatuse.value)"
								@change="model.ValCreatuse.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FLDSTBL_FLDS_CREATINS.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.FLDSTBL_FLDS_CREATINS"
							v-on="controls.FLDSTBL_FLDS_CREATINS.handlers"
							:loading="controls.FLDSTBL_FLDS_CREATINS.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.FLDSTBL_FLDS_CREATINS.isVisible"
								v-bind="controls.FLDSTBL_FLDS_CREATINS.props"
								:model-value="model.ValCreatins.value"
								@reset-icon-click="model.ValCreatins.fnUpdateValue(model.ValCreatins.originalValue ?? new Date())"
								@update:model-value="model.ValCreatins.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FLDSTBL_FLDS_CREATHOU.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.FLDSTBL_FLDS_CREATHOU"
							v-on="controls.FLDSTBL_FLDS_CREATHOU.handlers"
							:loading="controls.FLDSTBL_FLDS_CREATHOU.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.FLDSTBL_FLDS_CREATHOU.isVisible"
								v-bind="controls.FLDSTBL_FLDS_CREATHOU.props"
								:model-value="model.ValCreathou.value"
								@reset-icon-click="model.ValCreathou.fnUpdateValue(model.ValCreathou.originalValue ?? new Date())"
								@update:model-value="model.ValCreathou.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FLDSTBL_PSEUDFEECA___.isVisible"
						class="control-join-group">
						<q-table
							v-show="controls.FLDSTBL_PSEUDFEECA___.isVisible"
							v-bind="controls.FLDSTBL_PSEUDFEECA___"
							v-on="controls.FLDSTBL_PSEUDFEECA___.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.FLDSTBL_PSEUDFEECA___"
							:filter-operators="controls.FLDSTBL_PSEUDFEECA___.filterOperators"
							v-on="controls.FLDSTBL_PSEUDFEECA___.handlers" />
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

	import FormViewModel from './QFormFldstblViewModel.js'

	const requiredTextResources = ['QFormFldstbl', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS FLDSTBL]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormFldstbl',

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
					name: 'FLDSTBL',
					location: 'form-FLDSTBL',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormFldstbl', false),

				interfaceMetadata: {
					id: 'QFormFldstbl', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'FLDSTBL',
					route: 'form-FLDSTBL',
					area: 'FLDS',
					primaryKey: 'ValCodflds',
					designation: computed(() => this.Resources.FIELD_TYPE57098),
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
					applyBtn: {
						id: 'apply-btn',
						icon: {
							icon: 'apply',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.apply]),
						classes: [],
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						disabled: false,
						action: () => vm.applyChanges(true)
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
					FLDSTBL_PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'FLDSTBL_PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'small',
						helpControl: {
							shortHelp: {
								type: 'Subtitle',
								text: computed(() => this.Resources._111418227),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1114_VERBOSE42095),
							}
						},
						label: computed(() => this.Resources.TEXT_INPUTS37770),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['FLDSTBL_FLDS_TXTFIELD', 'FLDSTBL_FLDS_DESCRIP_'],
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_TXTFIELD: new fieldControlClass.StringControl({
						modelField: 'ValTxtfield',
						valueChangeEvent: 'fieldChange:flds.txtfield',
						id: 'FLDSTBL_FLDS_TXTFIELD',
						name: 'TXTFIELD',
						size: 'xlarge',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources._111536184),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1115_VERBOSE27480),
							}
						},
						label: computed(() => this.Resources.TEXT_FIELD41810),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR02',
						maxLength: 50,
						labelId: 'label_FLDSTBL_FLDS_TXTFIELD',
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_DESCRIP_: new fieldControlClass.MultilineStringControl({
						modelField: 'ValDescrip',
						valueChangeEvent: 'fieldChange:flds.descrip',
						id: 'FLDSTBL_FLDS_DESCRIP_',
						name: 'DESCRIP',
						size: 'xlarge',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._111636045),
							},
							detailedHelp: {
								type: 'None',
								text: computed(() => this.Resources._1116_VERBOSE64950),
							}
						},
						label: computed(() => this.Resources.MULTINE_TEXT05310),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR02',
						rows: 1,
						cols: 30,
						controlLimits: [
						],
					}, this),
					FLDSTBL_PSEUDNOVOGR06: new fieldControlClass.GroupControl({
						id: 'FLDSTBL_PSEUDNOVOGR06',
						name: 'NOVOGR06',
						size: 'mini',
						helpControl: {
							shortHelp: {
								type: 'Subtitle',
								text: computed(() => this.Resources._114127414),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1141_VERBOSE60151),
							}
						},
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['FLDSTBL_FLDS_PRIMVIAG', 'FLDSTBL_FLDS_LOGICENU', 'FLDSTBL_FLDS_CLASSNUM', 'FLDSTBL_FLDS_RADIOB__', 'FLDSTBL_PSEUDFIELD002', 'FLDSTBL_PSEUDFIELD003', 'FLDSTBL_PSEUDFIELD001'],
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_PRIMVIAG: new fieldControlClass.BooleanControl({
						modelField: 'ValPrimviag',
						valueChangeEvent: 'fieldChange:flds.primviag',
						id: 'FLDSTBL_FLDS_PRIMVIAG',
						name: 'PRIMVIAG',
						size: 'mini',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._114228043),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1142_VERBOSE19186),
							}
						},
						label: computed(() => this.Resources.LOGICAL47485),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'FLDSTBL_PSEUDNOVOGR06',
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_LOGICENU: new fieldControlClass.ArrayBooleanControl({
						modelField: 'ValLogicenu',
						valueChangeEvent: 'fieldChange:flds.logicenu',
						id: 'FLDSTBL_FLDS_LOGICENU',
						name: 'LOGICENU',
						size: 'mini',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.YES_OR_NO49030),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR06',
						maxIntegers: 1,
						maxDecimals: 0,
						arrayName: 'PRIMVIAG',
						trueLabel: computed(() => this.Resources.YES34196),
						falseLabel: computed(() => this.Resources.NO57340),
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_CLASSNUM: new fieldControlClass.ArrayNumberControl({
						modelField: 'ValClassnum',
						valueChangeEvent: 'fieldChange:flds.classnum',
						id: 'FLDSTBL_FLDS_CLASSNUM',
						name: 'CLASSNUM',
						size: 'mini',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._114429549),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1144_VERBOSE29746),
							}
						},
						label: computed(() => this.Resources.NUMERIC_ENUMERATION19068),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR06',
						maxIntegers: 1,
						maxDecimals: 0,
						arrayName: 'CLASSNUM',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_RADIOB__: new fieldControlClass.ArrayStringControl({
						modelField: 'ValRadiob',
						valueChangeEvent: 'fieldChange:flds.radiob',
						id: 'FLDSTBL_FLDS_RADIOB__',
						name: 'RADIOB',
						label: computed(() => this.Resources.RADIO_BTN20980),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'FLDSTBL_PSEUDNOVOGR06',
						maxLength: 5,
						labelId: 'label_FLDSTBL_FLDS_RADIOB__',
						arrayName: 'RADIOBTN',
						columns: 2,
						controlLimits: [
						],
					}, this),
					FLDSTBL_PSEUDFIELD002: new fieldControlClass.BaseControl({
						id: 'FLDSTBL_PSEUDFIELD002',
						name: 'FIELD002',
						size: 'medium',
						hasLabel: false,
						helpControl: {
							shortHelp: {
								type: '',
								text: '',
							},
						},
						label: computed(() => this.Resources.STATIC_TEXT_17624),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR06',
						controlLimits: [
						],
					}, this),
					FLDSTBL_PSEUDFIELD003: new fieldControlClass.ImageControl({
						id: 'FLDSTBL_PSEUDFIELD003',
						name: 'FIELD003',
						size: 'medium',
						hasLabel: false,
						helpControl: {
							shortHelp: {
								type: '',
								text: '',
							},
						},
						label: computed(() => this.Resources.STATIC_IMAGE44130),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR06',
						icon: {
							icon: computed(() => `${this.$app.resourcesPath}pexels-polat-eyyüp-albayrak-13933341.jpg?v=2934`),
							type: 'img',
						},
						height: 500,
						width: 500,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.STATIC_IMAGE44130)),
						isStatic: true,
						controlLimits: [
						],
					}, this),
					FLDSTBL_PSEUDFIELD001: new fieldControlClass.StringControl({
						modelField: 'PseudValField001',
						valueChangeEvent: 'fieldChange:pseud.field001',
						id: 'FLDSTBL_PSEUDFIELD001',
						name: 'FIELD001',
						size: 'large',
						helpControl: {
							shortHelp: {
								type: '',
								text: '',
							},
						},
						label: computed(() => this.Resources.MANUAL_FILLING_FIELD38373),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR06',
						maxLength: 15,
						labelId: 'label_FLDSTBL_PSEUDFIELD001',
						controlLimits: [
						],
					}, this),
					FLDSTBL_PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'FLDSTBL_PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'medium',
						label: computed(() => this.Resources.DATE_TIME_INPUTS06842),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['FLDSTBL_FLDS_YEAR____', 'FLDSTBL_FLDS_TIME____', 'FLDSTBL_FLDS_DATE____', 'FLDSTBL_FLDS_DATETIME', 'FLDSTBL_FLDS_DATESECO'],
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_YEAR____: new fieldControlClass.NumberControl({
						modelField: 'ValYear',
						valueChangeEvent: 'fieldChange:flds.year',
						id: 'FLDSTBL_FLDS_YEAR____',
						name: 'YEAR',
						size: 'mini',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._111737822),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1117_VERBOSE04450),
							}
						},
						label: computed(() => this.Resources.YEAR61794),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR01',
						maxIntegers: 4,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_TIME____: new fieldControlClass.TimeControl({
						modelField: 'ValTime',
						valueChangeEvent: 'fieldChange:flds.time',
						id: 'FLDSTBL_FLDS_TIME____',
						name: 'TIME',
						size: 'mini',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._111838179),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1118_VERBOSE37983),
							}
						},
						label: computed(() => this.Resources.TIME15328),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR01',
						dateTimeType: 'time',
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_DATE____: new fieldControlClass.DateControl({
						modelField: 'ValDate',
						valueChangeEvent: 'fieldChange:flds.date',
						id: 'FLDSTBL_FLDS_DATE____',
						name: 'DATE',
						size: 'small',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._111938548),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1119_VERBOSE52944),
							}
						},
						label: computed(() => this.Resources.DATE18475),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR01',
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_DATETIME: new fieldControlClass.DateControl({
						modelField: 'ValDatetime',
						valueChangeEvent: 'fieldChange:flds.datetime',
						id: 'FLDSTBL_FLDS_DATETIME',
						name: 'DATETIME',
						size: 'medium',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.DATE_TIME59103),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR01',
						dateTimeType: 'dateTime',
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_DATESECO: new fieldControlClass.DateControl({
						modelField: 'ValDateseco',
						valueChangeEvent: 'fieldChange:flds.dateseco',
						id: 'FLDSTBL_FLDS_DATESECO',
						name: 'DATESECO',
						size: 'large',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.DATE_SECOND44057),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR01',
						dateTimeType: 'dateTimeSeconds',
						controlLimits: [
						],
					}, this),
					FLDSTBL_PSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'FLDSTBL_PSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'medium',
						label: computed(() => this.Resources.NUMERIC_INPUTS64739),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['FLDSTBL_FLDS_DURATION', 'FLDSTBL_FLDS_NPASSAGE', 'FLDSTBL_FLDS_PRECOBIL', 'FLDSTBL_FLDS_PRICE___'],
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_DURATION: new fieldControlClass.NumberControl({
						modelField: 'ValDuration',
						valueChangeEvent: 'fieldChange:flds.duration',
						id: 'FLDSTBL_FLDS_DURATION',
						name: 'DURATION',
						size: 'medium',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.NUMERIC_DECIMAL49512),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR03',
						maxIntegers: 2,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_NPASSAGE: new fieldControlClass.NumberControl({
						modelField: 'ValNpassage',
						valueChangeEvent: 'fieldChange:flds.npassage',
						id: 'FLDSTBL_FLDS_NPASSAGE',
						name: 'NPASSAGE',
						size: 'mini',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.NUMERIC19292),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR03',
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_PRECOBIL: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrecobil',
						valueChangeEvent: 'fieldChange:flds.precobil',
						id: 'FLDSTBL_FLDS_PRECOBIL',
						name: 'PRECOBIL',
						size: 'medium',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.CURRENCY_DECIMAL48296),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR03',
						maxIntegers: 3,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_PRICE___: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrice',
						valueChangeEvent: 'fieldChange:flds.price',
						id: 'FLDSTBL_FLDS_PRICE___',
						name: 'PRICE',
						size: 'small',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.CURRENCY13881),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR03',
						maxIntegers: 3,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					FLDSTBL_PSEUDNOVOGR04: new fieldControlClass.GroupControl({
						id: 'FLDSTBL_PSEUDNOVOGR04',
						name: 'NOVOGR04',
						size: 'medium',
						label: computed(() => this.Resources.INPUTS_WITH_MASKS08900),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['FLDSTBL_FLDS_SSNUMBER', 'FLDSTBL_FLDS_ZIPFIELD', 'FLDSTBL_FLDS_VATNUMBR', 'FLDSTBL_FLDS_LICPLATE', 'FLDSTBL_FLDS_BANKNMBR', 'FLDSTBL_FLDS_EMAILFLD', 'FLDSTBL_FLDS_IBANFIEL', 'FLDSTBL_FLDS_UPPRTEXT', 'FLDSTBL_FLDS_NRCNTRY_'],
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_SSNUMBER: new fieldControlClass.MaskControl({
						modelField: 'ValSsnumber',
						valueChangeEvent: 'fieldChange:flds.ssnumber',
						id: 'FLDSTBL_FLDS_SSNUMBER',
						name: 'SSNUMBER',
						size: 'medium',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.SOCIAL_SECURITY_NO48150),
						placeholder: computed(() => this.Resources._1234567891237929),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR04',
						maxLength: 11,
						labelId: 'label_FLDSTBL_FLDS_SSNUMBER',
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_ZIPFIELD: new fieldControlClass.MaskControl({
						modelField: 'ValZipfield',
						valueChangeEvent: 'fieldChange:flds.zipfield',
						id: 'FLDSTBL_FLDS_ZIPFIELD',
						name: 'ZIPFIELD',
						size: 'small',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.ZIPCODE21021),
						placeholder: computed(() => this.Resources.XXXX_XXX51420),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR04',
						maxLength: 8,
						labelId: 'label_FLDSTBL_FLDS_ZIPFIELD',
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_VATNUMBR: new fieldControlClass.MaskControl({
						modelField: 'ValVatnumbr',
						valueChangeEvent: 'fieldChange:flds.vatnumbr',
						id: 'FLDSTBL_FLDS_VATNUMBR',
						name: 'VATNUMBR',
						size: 'small',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.VAT_NUMBER24236),
						placeholder: computed(() => this.Resources._12345678953785),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR04',
						maxLength: 9,
						labelId: 'label_FLDSTBL_FLDS_VATNUMBR',
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_LICPLATE: new fieldControlClass.MaskControl({
						modelField: 'ValLicplate',
						valueChangeEvent: 'fieldChange:flds.licplate',
						id: 'FLDSTBL_FLDS_LICPLATE',
						name: 'LICPLATE',
						size: 'medium',
						helpControl: {
							shortHelp: {
								type: '',
								text: '',
							},
						},
						label: computed(() => this.Resources.LICENCE_PLATE07627),
						placeholder: computed(() => this.Resources.XX_00_XX10122),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR04',
						maxLength: 8,
						labelId: 'label_FLDSTBL_FLDS_LICPLATE',
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_BANKNMBR: new fieldControlClass.MaskControl({
						modelField: 'ValBanknmbr',
						valueChangeEvent: 'fieldChange:flds.banknmbr',
						id: 'FLDSTBL_FLDS_BANKNMBR',
						name: 'BANKNMBR',
						size: 'large',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.BANKING_ACCOUNT_NUMB62548),
						placeholder: computed(() => this.Resources._1234_5678_90123456761043),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR04',
						maxLength: 24,
						labelId: 'label_FLDSTBL_FLDS_BANKNMBR',
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_EMAILFLD: new fieldControlClass.MaskControl({
						modelField: 'ValEmailfld',
						valueChangeEvent: 'fieldChange:flds.emailfld',
						id: 'FLDSTBL_FLDS_EMAILFLD',
						name: 'EMAILFLD',
						size: 'xlarge',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.EMAIL25170),
						placeholder: computed(() => this.Resources.QUIDGESTAT_QUIDGEST_PT47872),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR04',
						maxLength: 50,
						labelId: 'label_FLDSTBL_FLDS_EMAILFLD',
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_IBANFIEL: new fieldControlClass.MaskControl({
						modelField: 'ValIbanfiel',
						valueChangeEvent: 'fieldChange:flds.ibanfiel',
						id: 'FLDSTBL_FLDS_IBANFIEL',
						name: 'IBANFIEL',
						size: 'xlarge',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.IBAN28506),
						placeholder: computed(() => this.Resources.PT12345678901234567820477),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR04',
						maxLength: 34,
						labelId: 'label_FLDSTBL_FLDS_IBANFIEL',
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_UPPRTEXT: new fieldControlClass.MaskControl({
						modelField: 'ValUpprtext',
						valueChangeEvent: 'fieldChange:flds.upprtext',
						id: 'FLDSTBL_FLDS_UPPRTEXT',
						name: 'UPPRTEXT',
						size: 'xlarge',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.UPPERCASE48238),
						placeholder: computed(() => this.Resources.QUIDGEST56322),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR04',
						maxLength: 50,
						labelId: 'label_FLDSTBL_FLDS_UPPRTEXT',
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_NRCNTRY_: new fieldControlClass.NumberControl({
						modelField: 'ValNrcntry',
						valueChangeEvent: 'fieldChange:flds.nrcntry',
						id: 'FLDSTBL_FLDS_NRCNTRY_',
						name: 'NRCNTRY',
						size: 'mini',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.NUMERIC19292),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR04',
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					FLDSTBL_PSEUDNOVOGR05: new fieldControlClass.GroupControl({
						id: 'FLDSTBL_PSEUDNOVOGR05',
						name: 'NOVOGR05',
						size: 'mini',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources._111418227),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1114_VERBOSE42095),
							}
						},
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['FLDSTBL_FLDS_PASSFLD_', 'FLDSTBL_FLDS_CLRPICKE'],
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_PASSFLD_: new fieldControlClass.StringControl({
						modelField: 'ValPassfld',
						valueChangeEvent: 'fieldChange:flds.passfld',
						id: 'FLDSTBL_FLDS_PASSFLD_',
						name: 'PASSFLD',
						size: 'xlarge',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.PASSWORD09467),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR05',
						maxLength: 50,
						labelId: 'label_FLDSTBL_FLDS_PASSFLD_',
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_CLRPICKE: new fieldControlClass.StringControl({
						modelField: 'ValClrpicke',
						valueChangeEvent: 'fieldChange:flds.clrpicke',
						id: 'FLDSTBL_FLDS_CLRPICKE',
						name: 'CLRPICKE',
						size: 'xlarge',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.COLORPICKER39653),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR05',
						maxLength: 50,
						labelId: 'label_FLDSTBL_FLDS_CLRPICKE',
						controlLimits: [
						],
					}, this),
					FLDSTBL_PSEUDNOVOGR07: new fieldControlClass.GroupControl({
						id: 'FLDSTBL_PSEUDNOVOGR07',
						name: 'NOVOGR07',
						size: 'small',
						label: computed(() => this.Resources.DOCUMENTS14470),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['FLDSTBL_FLDS_LOGOEXTE', 'FLDSTBL_FLDS_LOGO____', 'FLDSTBL_FLDS_ATTACH__'],
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_LOGOEXTE: new fieldControlClass.ImageControl({
						modelField: 'ValLogoexte',
						valueChangeEvent: 'fieldChange:flds.logoexte',
						id: 'FLDSTBL_FLDS_LOGOEXTE',
						name: 'LOGOEXTE',
						size: 'large',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.LOGO__EXTERNAL_FILE_58162),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR07',
						height: 10,
						width: 480,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.LOGO__EXTERNAL_FILE_58162)),
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_LOGO____: new fieldControlClass.ImageControl({
						modelField: 'ValLogo',
						valueChangeEvent: 'fieldChange:flds.logo',
						id: 'FLDSTBL_FLDS_LOGO____',
						name: 'LOGO',
						size: 'mini',
						label: computed(() => this.Resources.LOGO62483),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR07',
						height: 10,
						width: 480,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.LOGO62483)),
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_ATTACH__: new fieldControlClass.DocumentControl({
						modelField: 'ValAttach',
						valueChangeEvent: 'fieldChange:flds.attach',
						id: 'FLDSTBL_FLDS_ATTACH__',
						name: 'ATTACH',
						size: 'xxlarge',
						label: computed(() => this.Resources.DOCUMENT00695),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FLDSTBL_PSEUDNOVOGR07',
						versioningIsOn: true,
						viewType: qEnums.documentViewTypeMode.print,
						extensions: [],
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_CREATDAT: new fieldControlClass.DateControl({
						modelField: 'ValCreatdat',
						valueChangeEvent: 'fieldChange:flds.creatdat',
						id: 'FLDSTBL_FLDS_CREATDAT',
						name: 'CREATDAT',
						size: 'small',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.DAY27593),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_CREATUSE: new fieldControlClass.StringControl({
						modelField: 'ValCreatuse',
						valueChangeEvent: 'fieldChange:flds.creatuse',
						id: 'FLDSTBL_FLDS_CREATUSE',
						name: 'CREATUSE',
						size: 'large',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.CREATED_BY12292),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 20,
						labelId: 'label_FLDSTBL_FLDS_CREATUSE',
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_CREATINS: new fieldControlClass.DateControl({
						modelField: 'ValCreatins',
						valueChangeEvent: 'fieldChange:flds.creatins',
						id: 'FLDSTBL_FLDS_CREATINS',
						name: 'CREATINS',
						size: 'medium',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.COMPLETE_DATE53774),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'dateTimeSeconds',
						controlLimits: [
						],
					}, this),
					FLDSTBL_FLDS_CREATHOU: new fieldControlClass.TimeControl({
						modelField: 'ValCreathou',
						valueChangeEvent: 'fieldChange:flds.creathou',
						id: 'FLDSTBL_FLDS_CREATHOU',
						name: 'CREATHOU',
						size: 'mini',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112047598),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE06198),
							}
						},
						label: computed(() => this.Resources.HOUR15646),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'time',
						controlLimits: [
						],
					}, this),
					FLDSTBL_PSEUDFEECA___: new fieldControlClass.TableListControl({
						id: 'FLDSTBL_PSEUDFEECA___',
						name: 'FEECA',
						size: '',
						label: computed(() => this.Resources.FIELD_FEEDBACK53085),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'FLDS',
						action: 'Fldstbl_ValFeeca',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Flds.ValDescrip',
								area: 'FLDS',
								field: 'DESCRIP',
								label: computed(() => this.Resources.DESCRIPTION07383),
								scrollData: 30,
								pkColumn: 'ValCodflds',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValFeedback',
								area: 'FEECA',
								field: 'FEEDBACK',
								label: computed(() => this.Resources.FEEDBACK52855),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValFeeca',
							serverMode: true,
							pkColumn: 'ValCodfeeca',
							tableAlias: 'FEECA',
							tableNamePlural: computed(() => this.Resources.FIELD_FEEDBACK53085),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.FIELD_FEEDBACK53085),
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
										formName: 'FEECA',
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
										formName: 'FEECA',
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
										formName: 'FEECA',
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
										formName: 'FEECA',
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
										formName: 'FEECA',
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
								id: 'RCA__FEECA',
								name: '_FEECA',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'FEECA',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'FEECA': {
									fnKeySelector: (row) => row.Fields.ValCodfeeca,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValFeedback',
							defaultSearchColumnNameOriginal: 'ValFeedback',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-FLDS', 'changed-FEECA'],
						uuid: 'Fldstbl_ValFeeca',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'flds'],
								dependencyEvents: ['fieldChange:flds.codflds'],
								dependencyField: 'FLDS.CODFLDS',
								fnValueSelector: (model) => model.ValCodflds.value
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
					'FLDSTBL_PSEUDNOVOGR02',
					'FLDSTBL_PSEUDNOVOGR06',
					'FLDSTBL_PSEUDNOVOGR01',
					'FLDSTBL_PSEUDNOVOGR03',
					'FLDSTBL_PSEUDNOVOGR04',
					'FLDSTBL_PSEUDNOVOGR05',
					'FLDSTBL_PSEUDNOVOGR07',
				]),

				tableFields: readonly([
					'FLDSTBL_PSEUDFEECA___',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Aero: {
						get ValName() { return vm.model.TableAeroName.value },
						set ValName(value) { vm.model.TableAeroName.updateValue(value) },
					},
					Flds: {
						get ValAttach() { return vm.model.ValAttach.value },
						set ValAttach(value) { vm.model.ValAttach.updateValue(value) },
						get ValBanknmbr() { return vm.model.ValBanknmbr.value },
						set ValBanknmbr(value) { vm.model.ValBanknmbr.updateValue(value) },
						get ValClass() { return vm.model.ValClass.value },
						set ValClass(value) { vm.model.ValClass.updateValue(value) },
						get ValClassnum() { return vm.model.ValClassnum.value },
						set ValClassnum(value) { vm.model.ValClassnum.updateValue(value) },
						get ValClrpicke() { return vm.model.ValClrpicke.value },
						set ValClrpicke(value) { vm.model.ValClrpicke.updateValue(value) },
						get ValCodaero() { return vm.model.ValCodaero.value },
						set ValCodaero(value) { vm.model.ValCodaero.updateValue(value) },
						get ValCodequip() { return vm.model.ValCodequip.value },
						set ValCodequip(value) { vm.model.ValCodequip.updateValue(value) },
						get ValCond() { return vm.model.ValCond.value },
						set ValCond(value) { vm.model.ValCond.updateValue(value) },
						get ValConditio() { return vm.model.ValConditio.value },
						set ValConditio(value) { vm.model.ValConditio.updateValue(value) },
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
						get ValLogoexte() { return vm.model.ValLogoexte.value },
						set ValLogoexte(value) { vm.model.ValLogoexte.updateValue(value) },
						get ValNpassage() { return vm.model.ValNpassage.value },
						set ValNpassage(value) { vm.model.ValNpassage.updateValue(value) },
						get ValNrcntry() { return vm.model.ValNrcntry.value },
						set ValNrcntry(value) { vm.model.ValNrcntry.updateValue(value) },
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
						get ValShwrc() { return vm.model.ValShwrc.value },
						set ValShwrc(value) { vm.model.ValShwrc.updateValue(value) },
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
					Pseud: {		
						get ValField001() { return vm.model.PseudValField001.value },
						set ValField001(value) { vm.model.PseudValField001.updateValue(value) },
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
// USE /[MANUAL GQT FORM_CODEJS FLDSTBL]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT FLDSTBL]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS FLDSTBL]/
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
// USE /[MANUAL GQT FORM_LOADED_JS FLDSTBL]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS FLDSTBL]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS FLDSTBL]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS FLDSTBL]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS FLDSTBL]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS FLDSTBL]/
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
// USE /[MANUAL GQT AFTER_DEL_JS FLDSTBL]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS FLDSTBL]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS FLDSTBL]/
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
// USE /[MANUAL GQT DLGUPDT FLDSTBL]/
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
// USE /[MANUAL GQT CTRLBLR FLDSTBL]/
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
// USE /[MANUAL GQT CTRLUPD FLDSTBL]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS FLDSTBL]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
