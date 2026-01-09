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
			data-key="FIELDHLP"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.FIELDHLPPSEUDNOVOGR02.isVisible || controls.FIELDHLPPSEUDNOVOGR06.isVisible">
					<q-col v-if="controls.FIELDHLPPSEUDNOVOGR02.isVisible">
						<q-group-box-container
							v-if="controls.FIELDHLPPSEUDNOVOGR02.isVisible"
							id="FIELDHLPPSEUDNOVOGR02"
							v-bind="controls.FIELDHLPPSEUDNOVOGR02"
							:is-visible="controls.FIELDHLPPSEUDNOVOGR02.isVisible">
							<!-- Start FIELDHLPPSEUDNOVOGR02 -->
							<q-row v-if="controls.FIELDHLPFLDS_TXTFIELD.isVisible">
								<q-col
									v-if="controls.FIELDHLPFLDS_TXTFIELD.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_TXTFIELD.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_TXTFIELD"
										v-on="controls.FIELDHLPFLDS_TXTFIELD.handlers"
										:loading="controls.FIELDHLPFLDS_TXTFIELD.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.FIELDHLPFLDS_TXTFIELD.props"
											@blur="onBlur(controls.FIELDHLPFLDS_TXTFIELD, model.ValTxtfield.value)"
											@change="model.ValTxtfield.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.FIELDHLPFLDS_DESCRIP_.isVisible">
								<q-col
									v-if="controls.FIELDHLPFLDS_DESCRIP_.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_DESCRIP_.isVisible"
										class="i-textarea"
										v-bind="controls.FIELDHLPFLDS_DESCRIP_"
										v-on="controls.FIELDHLPFLDS_DESCRIP_.handlers"
										:loading="controls.FIELDHLPFLDS_DESCRIP_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-area
											v-if="controls.FIELDHLPFLDS_DESCRIP_.isVisible"
											v-bind="controls.FIELDHLPFLDS_DESCRIP_.props"
											v-on="controls.FIELDHLPFLDS_DESCRIP_.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End FIELDHLPPSEUDNOVOGR02 -->
						</q-group-box-container>
					</q-col>
					<q-col v-if="controls.FIELDHLPPSEUDNOVOGR06.isVisible">
						<q-group-box-container
							v-if="controls.FIELDHLPPSEUDNOVOGR06.isVisible"
							id="FIELDHLPPSEUDNOVOGR06"
							v-bind="controls.FIELDHLPPSEUDNOVOGR06"
							:is-visible="controls.FIELDHLPPSEUDNOVOGR06.isVisible">
							<!-- Start FIELDHLPPSEUDNOVOGR06 -->
							<q-row v-if="controls.FIELDHLPFLDS_PRIMVIAG.isVisible || controls.FIELDHLPFLDS_LOGICENU.isVisible">
								<q-col
									v-if="controls.FIELDHLPFLDS_PRIMVIAG.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_PRIMVIAG.isVisible"
										class="i-checkbox"
										v-bind="controls.FIELDHLPFLDS_PRIMVIAG"
										v-on="controls.FIELDHLPFLDS_PRIMVIAG.handlers"
										:loading="controls.FIELDHLPFLDS_PRIMVIAG.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox
												v-if="controls.FIELDHLPFLDS_PRIMVIAG.isVisible"
												v-bind="controls.FIELDHLPFLDS_PRIMVIAG.props"
												v-on="controls.FIELDHLPFLDS_PRIMVIAG.handlers" />
										</template>
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FIELDHLPFLDS_LOGICENU.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_LOGICENU.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_LOGICENU"
										v-on="controls.FIELDHLPFLDS_LOGICENU.handlers"
										:loading="controls.FIELDHLPFLDS_LOGICENU.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-switch
											v-if="controls.FIELDHLPFLDS_LOGICENU.isVisible"
											v-bind="controls.FIELDHLPFLDS_LOGICENU.props"
											v-on="controls.FIELDHLPFLDS_LOGICENU.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.FIELDHLPFLDS_CLASSNUM.isVisible || controls.FIELDHLPFLDS_RADIOB__.isVisible">
								<q-col
									v-if="controls.FIELDHLPFLDS_CLASSNUM.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_CLASSNUM.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_CLASSNUM"
										v-on="controls.FIELDHLPFLDS_CLASSNUM.handlers"
										:loading="controls.FIELDHLPFLDS_CLASSNUM.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.FIELDHLPFLDS_CLASSNUM.isVisible"
											v-bind="controls.FIELDHLPFLDS_CLASSNUM.props"
											@update:model-value="model.ValClassnum.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FIELDHLPFLDS_RADIOB__.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_RADIOB__.isVisible"
										class="i-radio-container"
										v-bind="controls.FIELDHLPFLDS_RADIOB__"
										v-on="controls.FIELDHLPFLDS_RADIOB__.handlers"
										:label-position="labelAlignment.topleft"
										:loading="controls.FIELDHLPFLDS_RADIOB__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-radio-group
											v-if="controls.FIELDHLPFLDS_RADIOB__.isVisible"
											v-bind="controls.FIELDHLPFLDS_RADIOB__.props"
											v-on="controls.FIELDHLPFLDS_RADIOB__.handlers">
											<q-radio-button
												v-for="radio in controls.FIELDHLPFLDS_RADIOB__.items"
												:key="radio.key"
												:label="radio.value"
												:value="radio.key" />
										</q-radio-group>
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.FIELDHLPPSEUDFIELD002.isVisible || controls.FIELDHLPPSEUDFIELD003.isVisible">
								<q-col
									v-if="controls.FIELDHLPPSEUDFIELD002.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPPSEUDFIELD002.isVisible"
										class="i-static-text"
										v-bind="controls.FIELDHLPPSEUDFIELD002"
										v-on="controls.FIELDHLPPSEUDFIELD002.handlers"
										:loading="controls.FIELDHLPPSEUDFIELD002.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-static-text
											v-if="controls.FIELDHLPPSEUDFIELD002.isVisible"
											id="FIELDHLPPSEUDFIELD002"
											:size="controls.FIELDHLPPSEUDFIELD002.size"
											:text="controls.FIELDHLPPSEUDFIELD002.label" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FIELDHLPPSEUDFIELD003.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPPSEUDFIELD003.isVisible"
										class="q-image"
										v-bind="controls.FIELDHLPPSEUDFIELD003"
										v-on="controls.FIELDHLPPSEUDFIELD003.handlers"
										:loading="controls.FIELDHLPPSEUDFIELD003.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-image
											v-if="controls.FIELDHLPPSEUDFIELD003.isVisible"
											v-bind="controls.FIELDHLPPSEUDFIELD003.props"
											v-on="controls.FIELDHLPPSEUDFIELD003.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.FIELDHLPPSEUDFIELD001.isVisible">
								<q-col
									v-if="controls.FIELDHLPPSEUDFIELD001.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPPSEUDFIELD001.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPPSEUDFIELD001"
										v-on="controls.FIELDHLPPSEUDFIELD001.handlers"
										:loading="controls.FIELDHLPPSEUDFIELD001.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.FIELDHLPPSEUDFIELD001.props"
											@blur="onBlur(controls.FIELDHLPPSEUDFIELD001, model.PseudValField001.value)"
											@change="model.PseudValField001.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End FIELDHLPPSEUDNOVOGR06 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.FIELDHLPPSEUDNOVOGR01.isVisible || controls.FIELDHLPPSEUDNOVOGR03.isVisible">
					<q-col v-if="controls.FIELDHLPPSEUDNOVOGR01.isVisible || controls.FIELDHLPPSEUDNOVOGR03.isVisible">
						<q-group-box-container
							v-if="controls.FIELDHLPPSEUDNOVOGR01.isVisible"
							id="FIELDHLPPSEUDNOVOGR01"
							v-bind="controls.FIELDHLPPSEUDNOVOGR01"
							:is-visible="controls.FIELDHLPPSEUDNOVOGR01.isVisible">
							<!-- Start FIELDHLPPSEUDNOVOGR01 -->
							<q-row v-if="controls.FIELDHLPFLDS_YEAR____.isVisible || controls.FIELDHLPFLDS_TIME____.isVisible || controls.FIELDHLPFLDS_DATE____.isVisible || controls.FIELDHLPFLDS_DATETIME.isVisible || controls.FIELDHLPFLDS_DATESECO.isVisible">
								<q-col
									v-if="controls.FIELDHLPFLDS_YEAR____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_YEAR____.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_YEAR____"
										v-on="controls.FIELDHLPFLDS_YEAR____.handlers"
										:loading="controls.FIELDHLPFLDS_YEAR____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.FIELDHLPFLDS_YEAR____.isVisible"
											v-bind="controls.FIELDHLPFLDS_YEAR____.props"
											@update:model-value="model.ValYear.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FIELDHLPFLDS_TIME____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_TIME____.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_TIME____"
										v-on="controls.FIELDHLPFLDS_TIME____.handlers"
										:loading="controls.FIELDHLPFLDS_TIME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.FIELDHLPFLDS_TIME____.isVisible"
											v-bind="controls.FIELDHLPFLDS_TIME____.props"
											:model-value="model.ValTime.value"
											@reset-icon-click="model.ValTime.fnUpdateValue(model.ValTime.originalValue ?? new Date())"
											@update:model-value="model.ValTime.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FIELDHLPFLDS_DATE____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_DATE____.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_DATE____"
										v-on="controls.FIELDHLPFLDS_DATE____.handlers"
										:loading="controls.FIELDHLPFLDS_DATE____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.FIELDHLPFLDS_DATE____.isVisible"
											v-bind="controls.FIELDHLPFLDS_DATE____.props"
											:model-value="model.ValDate.value"
											@reset-icon-click="model.ValDate.fnUpdateValue(model.ValDate.originalValue ?? new Date())"
											@update:model-value="model.ValDate.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FIELDHLPFLDS_DATETIME.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_DATETIME.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_DATETIME"
										v-on="controls.FIELDHLPFLDS_DATETIME.handlers"
										:loading="controls.FIELDHLPFLDS_DATETIME.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.FIELDHLPFLDS_DATETIME.isVisible"
											v-bind="controls.FIELDHLPFLDS_DATETIME.props"
											:model-value="model.ValDatetime.value"
											@reset-icon-click="model.ValDatetime.fnUpdateValue(model.ValDatetime.originalValue ?? new Date())"
											@update:model-value="model.ValDatetime.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FIELDHLPFLDS_DATESECO.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_DATESECO.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_DATESECO"
										v-on="controls.FIELDHLPFLDS_DATESECO.handlers"
										:loading="controls.FIELDHLPFLDS_DATESECO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.FIELDHLPFLDS_DATESECO.isVisible"
											v-bind="controls.FIELDHLPFLDS_DATESECO.props"
											:model-value="model.ValDateseco.value"
											@reset-icon-click="model.ValDateseco.fnUpdateValue(model.ValDateseco.originalValue ?? new Date())"
											@update:model-value="model.ValDateseco.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End FIELDHLPPSEUDNOVOGR01 -->
						</q-group-box-container>
						<q-group-box-container
							v-if="controls.FIELDHLPPSEUDNOVOGR03.isVisible"
							id="FIELDHLPPSEUDNOVOGR03"
							v-bind="controls.FIELDHLPPSEUDNOVOGR03"
							:is-visible="controls.FIELDHLPPSEUDNOVOGR03.isVisible">
							<!-- Start FIELDHLPPSEUDNOVOGR03 -->
							<q-row v-if="controls.FIELDHLPFLDS_DURATION.isVisible || controls.FIELDHLPFLDS_NPASSAGE.isVisible || controls.FIELDHLPFLDS_PRECOBIL.isVisible || controls.FIELDHLPFLDS_PRICE___.isVisible">
								<q-col
									v-if="controls.FIELDHLPFLDS_DURATION.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_DURATION.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_DURATION"
										v-on="controls.FIELDHLPFLDS_DURATION.handlers"
										:loading="controls.FIELDHLPFLDS_DURATION.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.FIELDHLPFLDS_DURATION.isVisible"
											v-bind="controls.FIELDHLPFLDS_DURATION.props"
											@update:model-value="model.ValDuration.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FIELDHLPFLDS_NPASSAGE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_NPASSAGE.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_NPASSAGE"
										v-on="controls.FIELDHLPFLDS_NPASSAGE.handlers"
										:loading="controls.FIELDHLPFLDS_NPASSAGE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.FIELDHLPFLDS_NPASSAGE.isVisible"
											v-bind="controls.FIELDHLPFLDS_NPASSAGE.props"
											@update:model-value="model.ValNpassage.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FIELDHLPFLDS_PRECOBIL.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_PRECOBIL.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_PRECOBIL"
										v-on="controls.FIELDHLPFLDS_PRECOBIL.handlers"
										:loading="controls.FIELDHLPFLDS_PRECOBIL.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.FIELDHLPFLDS_PRECOBIL.isVisible"
											v-bind="controls.FIELDHLPFLDS_PRECOBIL.props"
											@update:model-value="model.ValPrecobil.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FIELDHLPFLDS_PRICE___.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_PRICE___.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_PRICE___"
										v-on="controls.FIELDHLPFLDS_PRICE___.handlers"
										:loading="controls.FIELDHLPFLDS_PRICE___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.FIELDHLPFLDS_PRICE___.isVisible"
											v-bind="controls.FIELDHLPFLDS_PRICE___.props"
											@update:model-value="model.ValPrice.fnUpdateValue" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End FIELDHLPPSEUDNOVOGR03 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.FIELDHLPPSEUDNOVOGR04.isVisible">
					<q-col v-if="controls.FIELDHLPPSEUDNOVOGR04.isVisible">
						<q-group-box-container
							v-if="controls.FIELDHLPPSEUDNOVOGR04.isVisible"
							id="FIELDHLPPSEUDNOVOGR04"
							v-bind="controls.FIELDHLPPSEUDNOVOGR04"
							:is-visible="controls.FIELDHLPPSEUDNOVOGR04.isVisible">
							<!-- Start FIELDHLPPSEUDNOVOGR04 -->
							<q-row v-if="controls.FIELDHLPFLDS_SSNUMBER.isVisible || controls.FIELDHLPFLDS_ZIPFIELD.isVisible || controls.FIELDHLPFLDS_VATNUMBR.isVisible || controls.FIELDHLPFLDS_LICPLATE.isVisible || controls.FIELDHLPFLDS_BANKNMBR.isVisible || controls.FIELDHLPFLDS_EMAILFLD.isVisible || controls.FIELDHLPFLDS_IBANFIEL.isVisible || controls.FIELDHLPFLDS_UPPRTEXT.isVisible">
								<q-col
									v-if="controls.FIELDHLPFLDS_SSNUMBER.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_SSNUMBER.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_SSNUMBER"
										v-on="controls.FIELDHLPFLDS_SSNUMBER.handlers"
										:loading="controls.FIELDHLPFLDS_SSNUMBER.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.FIELDHLPFLDS_SSNUMBER.isVisible"
											v-bind="controls.FIELDHLPFLDS_SSNUMBER"
											:model-value="model.ValSsnumber.value"
											@change="model.ValSsnumber.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FIELDHLPFLDS_ZIPFIELD.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_ZIPFIELD.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_ZIPFIELD"
										v-on="controls.FIELDHLPFLDS_ZIPFIELD.handlers"
										:loading="controls.FIELDHLPFLDS_ZIPFIELD.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.FIELDHLPFLDS_ZIPFIELD.isVisible"
											v-bind="controls.FIELDHLPFLDS_ZIPFIELD"
											:model-value="model.ValZipfield.value"
											@change="model.ValZipfield.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FIELDHLPFLDS_VATNUMBR.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_VATNUMBR.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_VATNUMBR"
										v-on="controls.FIELDHLPFLDS_VATNUMBR.handlers"
										:loading="controls.FIELDHLPFLDS_VATNUMBR.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.FIELDHLPFLDS_VATNUMBR.isVisible"
											v-bind="controls.FIELDHLPFLDS_VATNUMBR"
											:model-value="model.ValVatnumbr.value"
											@change="model.ValVatnumbr.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FIELDHLPFLDS_LICPLATE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_LICPLATE.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_LICPLATE"
										v-on="controls.FIELDHLPFLDS_LICPLATE.handlers"
										:loading="controls.FIELDHLPFLDS_LICPLATE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.FIELDHLPFLDS_LICPLATE.isVisible"
											v-bind="controls.FIELDHLPFLDS_LICPLATE"
											:model-value="model.ValLicplate.value"
											@change="model.ValLicplate.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FIELDHLPFLDS_BANKNMBR.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_BANKNMBR.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_BANKNMBR"
										v-on="controls.FIELDHLPFLDS_BANKNMBR.handlers"
										:loading="controls.FIELDHLPFLDS_BANKNMBR.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.FIELDHLPFLDS_BANKNMBR.isVisible"
											v-bind="controls.FIELDHLPFLDS_BANKNMBR"
											:model-value="model.ValBanknmbr.value"
											@change="model.ValBanknmbr.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FIELDHLPFLDS_EMAILFLD.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_EMAILFLD.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_EMAILFLD"
										v-on="controls.FIELDHLPFLDS_EMAILFLD.handlers"
										:loading="controls.FIELDHLPFLDS_EMAILFLD.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.FIELDHLPFLDS_EMAILFLD.isVisible"
											v-bind="controls.FIELDHLPFLDS_EMAILFLD"
											:model-value="model.ValEmailfld.value"
											@change="model.ValEmailfld.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.FIELDHLPFLDS_IBANFIEL.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_IBANFIEL.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_IBANFIEL"
										v-on="controls.FIELDHLPFLDS_IBANFIEL.handlers"
										:loading="controls.FIELDHLPFLDS_IBANFIEL.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.FIELDHLPFLDS_IBANFIEL.isVisible"
											v-bind="controls.FIELDHLPFLDS_IBANFIEL"
											:model-value="model.ValIbanfiel.value"
											@change="model.ValIbanfiel.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
								<q-col v-if="controls.FIELDHLPFLDS_UPPRTEXT.isVisible">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_UPPRTEXT.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_UPPRTEXT"
										v-on="controls.FIELDHLPFLDS_UPPRTEXT.handlers"
										:loading="controls.FIELDHLPFLDS_UPPRTEXT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.FIELDHLPFLDS_UPPRTEXT.isVisible"
											v-bind="controls.FIELDHLPFLDS_UPPRTEXT"
											:model-value="model.ValUpprtext.value"
											@change="model.ValUpprtext.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End FIELDHLPPSEUDNOVOGR04 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.FIELDHLPPSEUDNOVOGR05.isVisible || controls.FIELDHLPPSEUDNOVOGR07.isVisible">
					<q-col v-if="controls.FIELDHLPPSEUDNOVOGR05.isVisible">
						<q-group-box-container
							v-if="controls.FIELDHLPPSEUDNOVOGR05.isVisible"
							id="FIELDHLPPSEUDNOVOGR05"
							v-bind="controls.FIELDHLPPSEUDNOVOGR05"
							:is-visible="controls.FIELDHLPPSEUDNOVOGR05.isVisible">
							<!-- Start FIELDHLPPSEUDNOVOGR05 -->
							<q-row v-if="controls.FIELDHLPFLDS_PASSFLD_.isVisible">
								<q-col
									v-if="controls.FIELDHLPFLDS_PASSFLD_.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_PASSFLD_.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_PASSFLD_"
										v-on="controls.FIELDHLPFLDS_PASSFLD_.handlers"
										:loading="controls.FIELDHLPFLDS_PASSFLD_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.FIELDHLPFLDS_PASSFLD_.props"
											@blur="onBlur(controls.FIELDHLPFLDS_PASSFLD_, model.ValPassfld.value)"
											@change="model.ValPassfld.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.FIELDHLPFLDS_CLRPICKE.isVisible">
								<q-col
									v-if="controls.FIELDHLPFLDS_CLRPICKE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_CLRPICKE.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_CLRPICKE"
										v-on="controls.FIELDHLPFLDS_CLRPICKE.handlers"
										:loading="controls.FIELDHLPFLDS_CLRPICKE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.FIELDHLPFLDS_CLRPICKE.props"
											@blur="onBlur(controls.FIELDHLPFLDS_CLRPICKE, model.ValClrpicke.value)"
											@change="model.ValClrpicke.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End FIELDHLPPSEUDNOVOGR05 -->
						</q-group-box-container>
					</q-col>
					<q-col v-if="controls.FIELDHLPPSEUDNOVOGR07.isVisible">
						<q-group-box-container
							v-if="controls.FIELDHLPPSEUDNOVOGR07.isVisible"
							id="FIELDHLPPSEUDNOVOGR07"
							v-bind="controls.FIELDHLPPSEUDNOVOGR07"
							:is-visible="controls.FIELDHLPPSEUDNOVOGR07.isVisible">
							<!-- Start FIELDHLPPSEUDNOVOGR07 -->
							<q-row v-if="controls.FIELDHLPFLDS_LOGOEXTE.isVisible">
								<q-col
									v-if="controls.FIELDHLPFLDS_LOGOEXTE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_LOGOEXTE.isVisible"
										class="q-image"
										v-bind="controls.FIELDHLPFLDS_LOGOEXTE"
										v-on="controls.FIELDHLPFLDS_LOGOEXTE.handlers"
										:loading="controls.FIELDHLPFLDS_LOGOEXTE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-image
											v-if="controls.FIELDHLPFLDS_LOGOEXTE.isVisible"
											v-bind="controls.FIELDHLPFLDS_LOGOEXTE.props"
											v-on="controls.FIELDHLPFLDS_LOGOEXTE.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.FIELDHLPFLDS_LOGO____.isVisible">
								<q-col
									v-if="controls.FIELDHLPFLDS_LOGO____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_LOGO____.isVisible"
										class="q-image"
										v-bind="controls.FIELDHLPFLDS_LOGO____"
										v-on="controls.FIELDHLPFLDS_LOGO____.handlers"
										:loading="controls.FIELDHLPFLDS_LOGO____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-image
											v-if="controls.FIELDHLPFLDS_LOGO____.isVisible"
											v-bind="controls.FIELDHLPFLDS_LOGO____.props"
											v-on="controls.FIELDHLPFLDS_LOGO____.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.FIELDHLPFLDS_ATTACH__.isVisible">
								<q-col
									v-if="controls.FIELDHLPFLDS_ATTACH__.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.FIELDHLPFLDS_ATTACH__.isVisible"
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_ATTACH__"
										v-on="controls.FIELDHLPFLDS_ATTACH__.handlers"
										:loading="controls.FIELDHLPFLDS_ATTACH__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-document
											v-if="controls.FIELDHLPFLDS_ATTACH__.isVisible"
											v-bind="controls.FIELDHLPFLDS_ATTACH__.props"
											v-on="controls.FIELDHLPFLDS_ATTACH__.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End FIELDHLPPSEUDNOVOGR07 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.FIELDHLPFLDS_CREATDAT.isVisible || controls.FIELDHLPFLDS_CREATUSE.isVisible || controls.FIELDHLPFLDS_CREATINS.isVisible || controls.FIELDHLPFLDS_CREATHOU.isVisible">
					<q-col
						v-if="controls.FIELDHLPFLDS_CREATDAT.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.FIELDHLPFLDS_CREATDAT.isVisible"
							class="i-text"
							v-bind="controls.FIELDHLPFLDS_CREATDAT"
							v-on="controls.FIELDHLPFLDS_CREATDAT.handlers"
							:loading="controls.FIELDHLPFLDS_CREATDAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.FIELDHLPFLDS_CREATDAT.isVisible"
								v-bind="controls.FIELDHLPFLDS_CREATDAT.props"
								:model-value="model.ValCreatdat.value"
								@reset-icon-click="model.ValCreatdat.fnUpdateValue(model.ValCreatdat.originalValue ?? new Date())"
								@update:model-value="model.ValCreatdat.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.FIELDHLPFLDS_CREATUSE.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.FIELDHLPFLDS_CREATUSE.isVisible"
							class="i-text"
							v-bind="controls.FIELDHLPFLDS_CREATUSE"
							v-on="controls.FIELDHLPFLDS_CREATUSE.handlers"
							:loading="controls.FIELDHLPFLDS_CREATUSE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.FIELDHLPFLDS_CREATUSE.props"
								@blur="onBlur(controls.FIELDHLPFLDS_CREATUSE, model.ValCreatuse.value)"
								@change="model.ValCreatuse.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.FIELDHLPFLDS_CREATINS.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.FIELDHLPFLDS_CREATINS.isVisible"
							class="i-text"
							v-bind="controls.FIELDHLPFLDS_CREATINS"
							v-on="controls.FIELDHLPFLDS_CREATINS.handlers"
							:loading="controls.FIELDHLPFLDS_CREATINS.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.FIELDHLPFLDS_CREATINS.isVisible"
								v-bind="controls.FIELDHLPFLDS_CREATINS.props"
								:model-value="model.ValCreatins.value"
								@reset-icon-click="model.ValCreatins.fnUpdateValue(model.ValCreatins.originalValue ?? new Date())"
								@update:model-value="model.ValCreatins.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.FIELDHLPFLDS_CREATHOU.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.FIELDHLPFLDS_CREATHOU.isVisible"
							class="i-text"
							v-bind="controls.FIELDHLPFLDS_CREATHOU"
							v-on="controls.FIELDHLPFLDS_CREATHOU.handlers"
							:loading="controls.FIELDHLPFLDS_CREATHOU.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.FIELDHLPFLDS_CREATHOU.isVisible"
								v-bind="controls.FIELDHLPFLDS_CREATHOU.props"
								:model-value="model.ValCreathou.value"
								@reset-icon-click="model.ValCreathou.fnUpdateValue(model.ValCreathou.originalValue ?? new Date())"
								@update:model-value="model.ValCreathou.fnUpdateValue($event ?? '')" />
						</base-input-structure>
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

	import FormViewModel from './QFormFieldhlpViewModel.js'

	const requiredTextResources = ['QFormFieldhlp', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS FIELDHLP]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormFieldhlp',

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
					name: 'FIELDHLP',
					location: 'form-FIELDHLP',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormFieldhlp', false),

				interfaceMetadata: {
					id: 'QFormFieldhlp', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'FIELDHLP',
					route: 'form-FIELDHLP',
					area: 'FLDS',
					primaryKey: 'ValCodflds',
					designation: computed(() => this.Resources.FIELD_TYPE57098),
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
					FIELDHLPPSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'FIELDHLPPSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'block',
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
						directChildren: ['FIELDHLPFLDS_TXTFIELD', 'FIELDHLPFLDS_DESCRIP_'],
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_TXTFIELD: new fieldControlClass.StringControl({
						modelField: 'ValTxtfield',
						valueChangeEvent: 'fieldChange:flds.txtfield',
						id: 'FIELDHLPFLDS_TXTFIELD',
						name: 'TXTFIELD',
						size: 'large',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources._111515945),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1115_VERBOSE01763),
							}
						},
						label: computed(() => this.Resources.TEXT_FIELD41810),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR02',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_DESCRIP_: new fieldControlClass.MultilineStringControl({
						modelField: 'ValDescrip',
						valueChangeEvent: 'fieldChange:flds.descrip',
						id: 'FIELDHLPFLDS_DESCRIP_',
						name: 'DESCRIP',
						size: 'large',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._111650304),
							},
							detailedHelp: {
								type: 'None',
								text: computed(() => this.Resources._1116_VERBOSE45457),
							}
						},
						label: computed(() => this.Resources.MULTINE_TEXT05310),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR02',
						rows: 1,
						cols: 30,
						controlLimits: [
						],
					}, this),
					FIELDHLPPSEUDNOVOGR06: new fieldControlClass.GroupControl({
						id: 'FIELDHLPPSEUDNOVOGR06',
						name: 'NOVOGR06',
						size: 'block',
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
						directChildren: ['FIELDHLPFLDS_PRIMVIAG', 'FIELDHLPFLDS_LOGICENU', 'FIELDHLPFLDS_CLASSNUM', 'FIELDHLPFLDS_RADIOB__', 'FIELDHLPPSEUDFIELD002', 'FIELDHLPPSEUDFIELD003', 'FIELDHLPPSEUDFIELD001'],
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_PRIMVIAG: new fieldControlClass.BooleanControl({
						modelField: 'ValPrimviag',
						valueChangeEvent: 'fieldChange:flds.primviag',
						id: 'FIELDHLPFLDS_PRIMVIAG',
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
						labelPosition: computed(() => this.$app.layout.CheckboxLabelAlignment),
						container: 'FIELDHLPPSEUDNOVOGR06',
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_LOGICENU: new fieldControlClass.ArrayBooleanControl({
						modelField: 'ValLogicenu',
						valueChangeEvent: 'fieldChange:flds.logicenu',
						id: 'FIELDHLPFLDS_LOGICENU',
						name: 'LOGICENU',
						size: 'mini',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112049780),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE38514),
							}
						},
						label: computed(() => this.Resources.YES_OR_NO49030),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR06',
						maxIntegers: 1,
						maxDecimals: 0,
						arrayName: 'PRIMVIAG',
						trueLabel: computed(() => this.Resources.YES34196),
						falseLabel: computed(() => this.Resources.NO57340),
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_CLASSNUM: new fieldControlClass.ArrayNumberControl({
						modelField: 'ValClassnum',
						valueChangeEvent: 'fieldChange:flds.classnum',
						id: 'FIELDHLPFLDS_CLASSNUM',
						name: 'CLASSNUM',
						size: 'medium',
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
						container: 'FIELDHLPPSEUDNOVOGR06',
						maxIntegers: 1,
						maxDecimals: 0,
						arrayName: 'CLASSNUM',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_RADIOB__: new fieldControlClass.RadioGroupControl({
						modelField: 'ValRadiob',
						valueChangeEvent: 'fieldChange:flds.radiob',
						id: 'FIELDHLPFLDS_RADIOB__',
						name: 'RADIOB',
						label: computed(() => this.Resources.RADIO_BTN20980),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR06',
						maxLength: 5,
						arrayName: 'RADIOBTN',
						columns: 0,
						controlLimits: [
						],
					}, this),
					FIELDHLPPSEUDFIELD002: new fieldControlClass.BaseControl({
						id: 'FIELDHLPPSEUDFIELD002',
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
						container: 'FIELDHLPPSEUDNOVOGR06',
						controlLimits: [
						],
					}, this),
					FIELDHLPPSEUDFIELD003: new fieldControlClass.ImageControl({
						id: 'FIELDHLPPSEUDFIELD003',
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
						container: 'FIELDHLPPSEUDNOVOGR06',
						icon: {
							icon: computed(() => `${this.$app.resourcesPath}pexels-polat-eyyüp-albayrak-13933341.jpg?v=3090`),
							type: 'img',
						},
						height: 0,
						width: 150,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.STATIC_IMAGE44130)),
						isStatic: true,
						controlLimits: [
						],
					}, this),
					FIELDHLPPSEUDFIELD001: new fieldControlClass.StringControl({
						modelField: 'PseudValField001',
						valueChangeEvent: 'fieldChange:pseud.field001',
						id: 'FIELDHLPPSEUDFIELD001',
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
						container: 'FIELDHLPPSEUDNOVOGR06',
						maxLength: 15,
						controlLimits: [
						],
					}, this),
					FIELDHLPPSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'FIELDHLPPSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'medium',
						label: computed(() => this.Resources.DATE_TIME_INPUTS06842),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['FIELDHLPFLDS_YEAR____', 'FIELDHLPFLDS_TIME____', 'FIELDHLPFLDS_DATE____', 'FIELDHLPFLDS_DATETIME', 'FIELDHLPFLDS_DATESECO'],
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_YEAR____: new fieldControlClass.NumberControl({
						modelField: 'ValYear',
						valueChangeEvent: 'fieldChange:flds.year',
						id: 'FIELDHLPFLDS_YEAR____',
						name: 'YEAR',
						size: 'mini',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._111750451),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1117_VERBOSE35583),
							}
						},
						label: computed(() => this.Resources.YEAR61794),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR01',
						maxIntegers: 4,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_TIME____: new fieldControlClass.TimeControl({
						modelField: 'ValTime',
						valueChangeEvent: 'fieldChange:flds.time',
						id: 'FIELDHLPFLDS_TIME____',
						name: 'TIME',
						size: 'mini',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._111816434),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1118_VERBOSE48580),
							}
						},
						label: computed(() => this.Resources.TIME15328),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR01',
						dateTimeType: 'time',
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_DATE____: new fieldControlClass.DateControl({
						modelField: 'ValDate',
						valueChangeEvent: 'fieldChange:flds.date',
						id: 'FIELDHLPFLDS_DATE____',
						name: 'DATE',
						size: 'small',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._111916541),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1119_VERBOSE20366),
							}
						},
						label: computed(() => this.Resources.DATE18475),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR01',
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_DATETIME: new fieldControlClass.DateControl({
						modelField: 'ValDatetime',
						valueChangeEvent: 'fieldChange:flds.datetime',
						id: 'FIELDHLPFLDS_DATETIME',
						name: 'DATETIME',
						size: 'medium',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112049780),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE38514),
							}
						},
						label: computed(() => this.Resources.DATE_TIME59103),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR01',
						dateTimeType: 'dateTime',
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_DATESECO: new fieldControlClass.DateControl({
						modelField: 'ValDateseco',
						valueChangeEvent: 'fieldChange:flds.dateseco',
						id: 'FIELDHLPFLDS_DATESECO',
						name: 'DATESECO',
						size: 'medium',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112049780),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE38514),
							}
						},
						label: computed(() => this.Resources.DATE_SECOND44057),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR01',
						dateTimeType: 'dateTimeSeconds',
						controlLimits: [
						],
					}, this),
					FIELDHLPPSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'FIELDHLPPSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'block',
						label: computed(() => this.Resources.NUMERIC_INPUTS64739),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['FIELDHLPFLDS_DURATION', 'FIELDHLPFLDS_NPASSAGE', 'FIELDHLPFLDS_PRECOBIL', 'FIELDHLPFLDS_PRICE___'],
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_DURATION: new fieldControlClass.NumberControl({
						modelField: 'ValDuration',
						valueChangeEvent: 'fieldChange:flds.duration',
						id: 'FIELDHLPFLDS_DURATION',
						name: 'DURATION',
						size: 'small',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources._112049780),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE38514),
							}
						},
						label: computed(() => this.Resources.NUMERIC_DECIMAL49512),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR03',
						maxIntegers: 2,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_NPASSAGE: new fieldControlClass.NumberControl({
						modelField: 'ValNpassage',
						valueChangeEvent: 'fieldChange:flds.npassage',
						id: 'FIELDHLPFLDS_NPASSAGE',
						name: 'NPASSAGE',
						size: 'mini',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources._112049780),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE38514),
							}
						},
						label: computed(() => this.Resources.NUMERIC19292),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR03',
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_PRECOBIL: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrecobil',
						valueChangeEvent: 'fieldChange:flds.precobil',
						id: 'FIELDHLPFLDS_PRECOBIL',
						name: 'PRECOBIL',
						size: 'small',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources._112049780),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE38514),
							}
						},
						label: computed(() => this.Resources.CURRENCY_DECIMAL48296),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR03',
						maxIntegers: 3,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_PRICE___: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrice',
						valueChangeEvent: 'fieldChange:flds.price',
						id: 'FIELDHLPFLDS_PRICE___',
						name: 'PRICE',
						size: 'mini',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources._112049780),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE38514),
							}
						},
						label: computed(() => this.Resources.CURRENCY13881),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR03',
						maxIntegers: 3,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					FIELDHLPPSEUDNOVOGR04: new fieldControlClass.GroupControl({
						id: 'FIELDHLPPSEUDNOVOGR04',
						name: 'NOVOGR04',
						size: 'block',
						label: computed(() => this.Resources.INPUTS_WITH_MASKS08900),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['FIELDHLPFLDS_SSNUMBER', 'FIELDHLPFLDS_ZIPFIELD', 'FIELDHLPFLDS_VATNUMBR', 'FIELDHLPFLDS_LICPLATE', 'FIELDHLPFLDS_BANKNMBR', 'FIELDHLPFLDS_EMAILFLD', 'FIELDHLPFLDS_IBANFIEL', 'FIELDHLPFLDS_UPPRTEXT'],
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_SSNUMBER: new fieldControlClass.MaskControl({
						modelField: 'ValSsnumber',
						valueChangeEvent: 'fieldChange:flds.ssnumber',
						id: 'FIELDHLPFLDS_SSNUMBER',
						name: 'SSNUMBER',
						size: 'medium',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112049780),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE38514),
							}
						},
						label: computed(() => this.Resources.SOCIAL_SECURITY_NO48150),
						placeholder: computed(() => this.Resources._1234567891202679),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR04',
						maxLength: 11,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_ZIPFIELD: new fieldControlClass.MaskControl({
						modelField: 'ValZipfield',
						valueChangeEvent: 'fieldChange:flds.zipfield',
						id: 'FIELDHLPFLDS_ZIPFIELD',
						name: 'ZIPFIELD',
						size: 'small',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112049780),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE38514),
							}
						},
						label: computed(() => this.Resources.ZIPCODE21021),
						placeholder: computed(() => this.Resources.XXXX_XXX51420),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR04',
						maxLength: 8,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_VATNUMBR: new fieldControlClass.MaskControl({
						modelField: 'ValVatnumbr',
						valueChangeEvent: 'fieldChange:flds.vatnumbr',
						id: 'FIELDHLPFLDS_VATNUMBR',
						name: 'VATNUMBR',
						size: 'small',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112049780),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE38514),
							}
						},
						label: computed(() => this.Resources.VAT_NUMBER24236),
						placeholder: computed(() => this.Resources._12345678902714),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR04',
						maxLength: 9,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_LICPLATE: new fieldControlClass.MaskControl({
						modelField: 'ValLicplate',
						valueChangeEvent: 'fieldChange:flds.licplate',
						id: 'FIELDHLPFLDS_LICPLATE',
						name: 'LICPLATE',
						size: 'small',
						helpControl: {
							shortHelp: {
								type: '',
								text: '',
							},
						},
						label: computed(() => this.Resources.LICENCE_PLATE07627),
						placeholder: computed(() => this.Resources.XX_00_XX10122),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR04',
						maxLength: 8,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_BANKNMBR: new fieldControlClass.MaskControl({
						modelField: 'ValBanknmbr',
						valueChangeEvent: 'fieldChange:flds.banknmbr',
						id: 'FIELDHLPFLDS_BANKNMBR',
						name: 'BANKNMBR',
						size: 'large',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112049780),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE38514),
							}
						},
						label: computed(() => this.Resources.BANKING_ACCOUNT_NUMB62548),
						placeholder: computed(() => this.Resources._1234_5678_901234567844057),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR04',
						maxLength: 24,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_EMAILFLD: new fieldControlClass.MaskControl({
						modelField: 'ValEmailfld',
						valueChangeEvent: 'fieldChange:flds.emailfld',
						id: 'FIELDHLPFLDS_EMAILFLD',
						name: 'EMAILFLD',
						size: 'large',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112049780),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE38514),
							}
						},
						label: computed(() => this.Resources.EMAIL25170),
						placeholder: computed(() => this.Resources.QUIDGESTAT_QUIDGEST_PT47872),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR04',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_IBANFIEL: new fieldControlClass.MaskControl({
						modelField: 'ValIbanfiel',
						valueChangeEvent: 'fieldChange:flds.ibanfiel',
						id: 'FIELDHLPFLDS_IBANFIEL',
						name: 'IBANFIEL',
						size: 'large',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112049780),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE38514),
							}
						},
						label: computed(() => this.Resources.IBAN28506),
						placeholder: computed(() => this.Resources.PT12345678901234567820477),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR04',
						maxLength: 34,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_UPPRTEXT: new fieldControlClass.MaskControl({
						modelField: 'ValUpprtext',
						valueChangeEvent: 'fieldChange:flds.upprtext',
						id: 'FIELDHLPFLDS_UPPRTEXT',
						name: 'UPPRTEXT',
						size: 'block',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112049780),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE38514),
							}
						},
						label: computed(() => this.Resources.UPPERCASE48238),
						placeholder: computed(() => this.Resources.QUIDGEST56322),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR04',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					FIELDHLPPSEUDNOVOGR05: new fieldControlClass.GroupControl({
						id: 'FIELDHLPPSEUDNOVOGR05',
						name: 'NOVOGR05',
						size: 'block',
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
						directChildren: ['FIELDHLPFLDS_PASSFLD_', 'FIELDHLPFLDS_CLRPICKE'],
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_PASSFLD_: new fieldControlClass.StringControl({
						modelField: 'ValPassfld',
						valueChangeEvent: 'fieldChange:flds.passfld',
						id: 'FIELDHLPFLDS_PASSFLD_',
						name: 'PASSFLD',
						size: 'large',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources._112049780),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE38514),
							}
						},
						label: computed(() => this.Resources.PASSWORD09467),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR05',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_CLRPICKE: new fieldControlClass.StringControl({
						modelField: 'ValClrpicke',
						valueChangeEvent: 'fieldChange:flds.clrpicke',
						id: 'FIELDHLPFLDS_CLRPICKE',
						name: 'CLRPICKE',
						size: 'large',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources._112049780),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE38514),
							}
						},
						label: computed(() => this.Resources.COLORPICKER39653),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR05',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					FIELDHLPPSEUDNOVOGR07: new fieldControlClass.GroupControl({
						id: 'FIELDHLPPSEUDNOVOGR07',
						name: 'NOVOGR07',
						size: 'block',
						label: computed(() => this.Resources.DOCUMENTS14470),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['FIELDHLPFLDS_LOGOEXTE', 'FIELDHLPFLDS_LOGO____', 'FIELDHLPFLDS_ATTACH__'],
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_LOGOEXTE: new fieldControlClass.ImageControl({
						modelField: 'ValLogoexte',
						valueChangeEvent: 'fieldChange:flds.logoexte',
						id: 'FIELDHLPFLDS_LOGOEXTE',
						name: 'LOGOEXTE',
						size: 'large',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112049780),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE38514),
							}
						},
						label: computed(() => this.Resources.LOGO__EXTERNAL_FILE_58162),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR07',
						height: 10,
						width: 30,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.LOGO__EXTERNAL_FILE_58162)),
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_LOGO____: new fieldControlClass.ImageControl({
						modelField: 'ValLogo',
						valueChangeEvent: 'fieldChange:flds.logo',
						id: 'FIELDHLPFLDS_LOGO____',
						name: 'LOGO',
						size: 'medium',
						label: computed(() => this.Resources.LOGO62483),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR07',
						height: 50,
						width: 30,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.LOGO62483)),
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_ATTACH__: new fieldControlClass.DocumentControl({
						modelField: 'ValAttach',
						valueChangeEvent: 'fieldChange:flds.attach',
						id: 'FIELDHLPFLDS_ATTACH__',
						name: 'ATTACH',
						size: 'xxlarge',
						label: computed(() => this.Resources.DOCUMENT00695),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR07',
						versioningIsOn: true,
						viewType: qEnums.documentViewTypeMode.print,
						extensions: [],
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_CREATDAT: new fieldControlClass.DateControl({
						modelField: 'ValCreatdat',
						valueChangeEvent: 'fieldChange:flds.creatdat',
						id: 'FIELDHLPFLDS_CREATDAT',
						name: 'CREATDAT',
						size: 'small',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112049780),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE38514),
							}
						},
						label: computed(() => this.Resources.DAY27593),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_CREATUSE: new fieldControlClass.StringControl({
						modelField: 'ValCreatuse',
						valueChangeEvent: 'fieldChange:flds.creatuse',
						id: 'FIELDHLPFLDS_CREATUSE',
						name: 'CREATUSE',
						size: 'medium',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112049780),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE38514),
							}
						},
						label: computed(() => this.Resources.CREATED_BY12292),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 20,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_CREATINS: new fieldControlClass.DateControl({
						modelField: 'ValCreatins',
						valueChangeEvent: 'fieldChange:flds.creatins',
						id: 'FIELDHLPFLDS_CREATINS',
						name: 'CREATINS',
						size: 'medium',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112049780),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE38514),
							}
						},
						label: computed(() => this.Resources.COMPLETE_DATE53774),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'dateTimeSeconds',
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_CREATHOU: new fieldControlClass.TimeControl({
						modelField: 'ValCreathou',
						valueChangeEvent: 'fieldChange:flds.creathou',
						id: 'FIELDHLPFLDS_CREATHOU',
						name: 'CREATHOU',
						size: 'mini',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources._112049780),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1120_VERBOSE38514),
							}
						},
						label: computed(() => this.Resources.HOUR15646),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'time',
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
					'FIELDHLPPSEUDNOVOGR02',
					'FIELDHLPPSEUDNOVOGR06',
					'FIELDHLPPSEUDNOVOGR01',
					'FIELDHLPPSEUDNOVOGR03',
					'FIELDHLPPSEUDNOVOGR04',
					'FIELDHLPPSEUDNOVOGR05',
					'FIELDHLPPSEUDNOVOGR07',
				]),

				tableFields: readonly([
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
// USE /[MANUAL GQT FORM_CODEJS FIELDHLP]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT FIELDHLP]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS FIELDHLP]/
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
// USE /[MANUAL GQT FORM_LOADED_JS FIELDHLP]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS FIELDHLP]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS FIELDHLP]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS FIELDHLP]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS FIELDHLP]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS FIELDHLP]/
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
// USE /[MANUAL GQT AFTER_DEL_JS FIELDHLP]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS FIELDHLP]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS FIELDHLP]/
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
// USE /[MANUAL GQT DLGUPDT FIELDHLP]/
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
// USE /[MANUAL GQT CTRLBLR FIELDHLP]/
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
// USE /[MANUAL GQT CTRLUPD FIELDHLP]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS FIELDHLP]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
