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
			data-key="FIELDHLP"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.FIELDHLPPSEUDNOVOGR02.isVisible || controls.FIELDHLPPSEUDNOVOGR06.isVisible">
					<q-control-wrapper
						v-show="controls.FIELDHLPPSEUDNOVOGR02.isVisible || controls.FIELDHLPPSEUDNOVOGR06.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="FIELDHLPPSEUDNOVOGR02"
							v-bind="controls.FIELDHLPPSEUDNOVOGR02"
							:is-visible="controls.FIELDHLPPSEUDNOVOGR02.isVisible">
							<!-- Start FIELDHLPPSEUDNOVOGR02 -->
							<q-row-container v-show="controls.FIELDHLPFLDS_TXTFIELD.isVisible">
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_TXTFIELD.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_TXTFIELD"
										v-on="controls.FIELDHLPFLDS_TXTFIELD.handlers"
										:loading="controls.FIELDHLPFLDS_TXTFIELD.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-text-field
											v-bind="controls.FIELDHLPFLDS_TXTFIELD.props"
											:model-value="model.ValTxtfield.value"
											@update:model-value="model.ValTxtfield.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.FIELDHLPFLDS_DESCRIP_.isVisible">
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_DESCRIP_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-textarea"
										v-bind="controls.FIELDHLPFLDS_DESCRIP_"
										v-on="controls.FIELDHLPFLDS_DESCRIP_.handlers"
										:loading="controls.FIELDHLPFLDS_DESCRIP_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-textarea-input
											v-if="controls.FIELDHLPFLDS_DESCRIP_.isVisible"
											id="FIELDHLPFLDS_DESCRIP_"
											size="large"
											:model-value="model.ValDescrip.value"
											:rows="1"
											:cols="30"
											:is-required="controls.FIELDHLPFLDS_DESCRIP_.isRequired"
											:readonly="controls.FIELDHLPFLDS_DESCRIP_.readonly"
											:placeholder="controls.FIELDHLPFLDS_DESCRIP_.placeholder"
											@update:model-value="model.ValDescrip.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End FIELDHLPPSEUDNOVOGR02 -->
						</q-group-box-container>
						<q-group-box-container
							id="FIELDHLPPSEUDNOVOGR06"
							v-bind="controls.FIELDHLPPSEUDNOVOGR06"
							:is-visible="controls.FIELDHLPPSEUDNOVOGR06.isVisible">
							<!-- Start FIELDHLPPSEUDNOVOGR06 -->
							<q-row-container v-show="controls.FIELDHLPFLDS_PRIMVIAG.isVisible">
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_PRIMVIAG.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.FIELDHLPFLDS_PRIMVIAG"
										v-on="controls.FIELDHLPFLDS_PRIMVIAG.handlers"
										:loading="controls.FIELDHLPFLDS_PRIMVIAG.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<template #label>
											<q-checkbox-input
												v-if="controls.FIELDHLPFLDS_PRIMVIAG.isVisible"
												id="FIELDHLPFLDS_PRIMVIAG"
												size="mini"
												:model-value="model.ValPrimviag.value"
												:readonly="controls.FIELDHLPFLDS_PRIMVIAG.readonly"
												@update:model-value="model.ValPrimviag.fnUpdateValue" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.FIELDHLPFLDS_LOGICENU.isVisible">
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_LOGICENU.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.FIELDHLPFLDS_LOGICENU"
										v-on="controls.FIELDHLPFLDS_LOGICENU.handlers"
										:loading="controls.FIELDHLPFLDS_LOGICENU.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-toggle-input
											v-if="controls.FIELDHLPFLDS_LOGICENU.isVisible"
											id="FIELDHLPFLDS_LOGICENU"
											:model-value="model.ValLogicenu.value"
											:true-label="controls.FIELDHLPFLDS_LOGICENU.trueLabel"
											:false-label="controls.FIELDHLPFLDS_LOGICENU.falseLabel"
											:readonly="controls.FIELDHLPFLDS_LOGICENU.readonly"
											@update:model-value="model.ValLogicenu.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.FIELDHLPFLDS_RADIOB__.isVisible || controls.FIELDHLPFLDS_CLASSNUM.isVisible">
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_RADIOB__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-radio-container"
										v-bind="controls.FIELDHLPFLDS_RADIOB__"
										v-on="controls.FIELDHLPFLDS_RADIOB__.handlers"
										:label-position="labelAlignment.topleft"
										:loading="controls.FIELDHLPFLDS_RADIOB__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-radio-button-input
											v-if="controls.FIELDHLPFLDS_RADIOB__.isVisible"
											id="FIELDHLPFLDS_RADIOB__"
											:model-value="model.ValRadiob.value"
											deselect-radio
											:label-left-side="controls.FIELDHLPFLDS_RADIOB__.labelPosition === labelAlignment.left"
											:number-of-columns="controls.FIELDHLPFLDS_RADIOB__.columnNumber"
											:is-required="controls.FIELDHLPFLDS_RADIOB__.isRequired"
											:readonly="controls.FIELDHLPFLDS_RADIOB__.readonly"
											:options-list="controls.FIELDHLPFLDS_RADIOB__.items"
											@update:model-value="model.ValRadiob.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_CLASSNUM.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_CLASSNUM"
										v-on="controls.FIELDHLPFLDS_CLASSNUM.handlers"
										:loading="controls.FIELDHLPFLDS_CLASSNUM.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-select
											v-if="controls.FIELDHLPFLDS_CLASSNUM.isVisible"
											v-bind="controls.FIELDHLPFLDS_CLASSNUM.props"
											:model-value="model.ValClassnum.value"
											@update:model-value="model.ValClassnum.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End FIELDHLPPSEUDNOVOGR06 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.FIELDHLPPSEUDNOVOGR01.isVisible || controls.FIELDHLPPSEUDNOVOGR03.isVisible">
					<q-control-wrapper
						v-show="controls.FIELDHLPPSEUDNOVOGR01.isVisible || controls.FIELDHLPPSEUDNOVOGR03.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="FIELDHLPPSEUDNOVOGR01"
							v-bind="controls.FIELDHLPPSEUDNOVOGR01"
							:is-visible="controls.FIELDHLPPSEUDNOVOGR01.isVisible">
							<!-- Start FIELDHLPPSEUDNOVOGR01 -->
							<q-row-container v-show="controls.FIELDHLPFLDS_YEAR____.isVisible || controls.FIELDHLPFLDS_TIME____.isVisible || controls.FIELDHLPFLDS_DATE____.isVisible || controls.FIELDHLPFLDS_DATETIME.isVisible || controls.FIELDHLPFLDS_DATESECO.isVisible">
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_YEAR____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_YEAR____"
										v-on="controls.FIELDHLPFLDS_YEAR____.handlers"
										:loading="controls.FIELDHLPFLDS_YEAR____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-numeric-input
											v-if="controls.FIELDHLPFLDS_YEAR____.isVisible"
											v-bind="controls.FIELDHLPFLDS_YEAR____"
											:model-value="model.ValYear.value"
											@update:model-value="model.ValYear.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_TIME____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_TIME____"
										v-on="controls.FIELDHLPFLDS_TIME____.handlers"
										:loading="controls.FIELDHLPFLDS_TIME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-datetime-input
											v-if="controls.FIELDHLPFLDS_TIME____.isVisible"
											v-bind="controls.FIELDHLPFLDS_TIME____"
											format="Time"
											:model-value="model.ValTime.value"
											@update:model-value="model.ValTime.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_DATE____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_DATE____"
										v-on="controls.FIELDHLPFLDS_DATE____.handlers"
										:loading="controls.FIELDHLPFLDS_DATE____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-datetime-input
											v-if="controls.FIELDHLPFLDS_DATE____.isVisible"
											v-bind="controls.FIELDHLPFLDS_DATE____"
											format="Date"
											:model-value="model.ValDate.value"
											@update:model-value="model.ValDate.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_DATETIME.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_DATETIME"
										v-on="controls.FIELDHLPFLDS_DATETIME.handlers"
										:loading="controls.FIELDHLPFLDS_DATETIME.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-datetime-input
											v-if="controls.FIELDHLPFLDS_DATETIME.isVisible"
											v-bind="controls.FIELDHLPFLDS_DATETIME"
											format="DateTime"
											:model-value="model.ValDatetime.value"
											@update:model-value="model.ValDatetime.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_DATESECO.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_DATESECO"
										v-on="controls.FIELDHLPFLDS_DATESECO.handlers"
										:loading="controls.FIELDHLPFLDS_DATESECO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-datetime-input
											v-if="controls.FIELDHLPFLDS_DATESECO.isVisible"
											v-bind="controls.FIELDHLPFLDS_DATESECO"
											format="DateTimeSeconds"
											:model-value="model.ValDateseco.value"
											@update:model-value="model.ValDateseco.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End FIELDHLPPSEUDNOVOGR01 -->
						</q-group-box-container>
						<q-group-box-container
							id="FIELDHLPPSEUDNOVOGR03"
							v-bind="controls.FIELDHLPPSEUDNOVOGR03"
							:is-visible="controls.FIELDHLPPSEUDNOVOGR03.isVisible">
							<!-- Start FIELDHLPPSEUDNOVOGR03 -->
							<q-row-container v-show="controls.FIELDHLPFLDS_NPASSAGE.isVisible || controls.FIELDHLPFLDS_DURATION.isVisible || controls.FIELDHLPFLDS_PRECOBIL.isVisible || controls.FIELDHLPFLDS_PRICE___.isVisible">
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_NPASSAGE.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_NPASSAGE"
										v-on="controls.FIELDHLPFLDS_NPASSAGE.handlers"
										:loading="controls.FIELDHLPFLDS_NPASSAGE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-numeric-input
											v-if="controls.FIELDHLPFLDS_NPASSAGE.isVisible"
											v-bind="controls.FIELDHLPFLDS_NPASSAGE"
											:model-value="model.ValNpassage.value"
											@update:model-value="model.ValNpassage.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_DURATION.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_DURATION"
										v-on="controls.FIELDHLPFLDS_DURATION.handlers"
										:loading="controls.FIELDHLPFLDS_DURATION.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-numeric-input
											v-if="controls.FIELDHLPFLDS_DURATION.isVisible"
											v-bind="controls.FIELDHLPFLDS_DURATION"
											:model-value="model.ValDuration.value"
											@update:model-value="model.ValDuration.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_PRECOBIL.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_PRECOBIL"
										v-on="controls.FIELDHLPFLDS_PRECOBIL.handlers"
										:loading="controls.FIELDHLPFLDS_PRECOBIL.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-numeric-input
											v-if="controls.FIELDHLPFLDS_PRECOBIL.isVisible"
											v-bind="controls.FIELDHLPFLDS_PRECOBIL"
											:model-value="model.ValPrecobil.value"
											@update:model-value="model.ValPrecobil.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_PRICE___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_PRICE___"
										v-on="controls.FIELDHLPFLDS_PRICE___.handlers"
										:loading="controls.FIELDHLPFLDS_PRICE___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-numeric-input
											v-if="controls.FIELDHLPFLDS_PRICE___.isVisible"
											v-bind="controls.FIELDHLPFLDS_PRICE___"
											:model-value="model.ValPrice.value"
											@update:model-value="model.ValPrice.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End FIELDHLPPSEUDNOVOGR03 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.FIELDHLPPSEUDNOVOGR04.isVisible">
					<q-control-wrapper
						v-show="controls.FIELDHLPPSEUDNOVOGR04.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="FIELDHLPPSEUDNOVOGR04"
							v-bind="controls.FIELDHLPPSEUDNOVOGR04"
							:is-visible="controls.FIELDHLPPSEUDNOVOGR04.isVisible">
							<!-- Start FIELDHLPPSEUDNOVOGR04 -->
							<q-row-container v-show="controls.FIELDHLPFLDS_SSNUMBER.isVisible || controls.FIELDHLPFLDS_ZIPFIELD.isVisible || controls.FIELDHLPFLDS_VATNUMBR.isVisible || controls.FIELDHLPFLDS_LICPLATE.isVisible || controls.FIELDHLPFLDS_BANKNMBR.isVisible || controls.FIELDHLPFLDS_EMAILFLD.isVisible || controls.FIELDHLPFLDS_IBANFIEL.isVisible || controls.FIELDHLPFLDS_UPPRTEXT.isVisible">
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_SSNUMBER.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_SSNUMBER"
										v-on="controls.FIELDHLPFLDS_SSNUMBER.handlers"
										:loading="controls.FIELDHLPFLDS_SSNUMBER.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-mask
											v-if="controls.FIELDHLPFLDS_SSNUMBER.isVisible"
											v-bind="controls.FIELDHLPFLDS_SSNUMBER"
											:model-value="model.ValSsnumber.value"
											@update:model-value="model.ValSsnumber.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_ZIPFIELD.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_ZIPFIELD"
										v-on="controls.FIELDHLPFLDS_ZIPFIELD.handlers"
										:loading="controls.FIELDHLPFLDS_ZIPFIELD.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-mask
											v-if="controls.FIELDHLPFLDS_ZIPFIELD.isVisible"
											v-bind="controls.FIELDHLPFLDS_ZIPFIELD"
											:model-value="model.ValZipfield.value"
											@update:model-value="model.ValZipfield.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_VATNUMBR.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_VATNUMBR"
										v-on="controls.FIELDHLPFLDS_VATNUMBR.handlers"
										:loading="controls.FIELDHLPFLDS_VATNUMBR.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-mask
											v-if="controls.FIELDHLPFLDS_VATNUMBR.isVisible"
											v-bind="controls.FIELDHLPFLDS_VATNUMBR"
											:model-value="model.ValVatnumbr.value"
											@update:model-value="model.ValVatnumbr.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_LICPLATE.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_LICPLATE"
										v-on="controls.FIELDHLPFLDS_LICPLATE.handlers"
										:loading="controls.FIELDHLPFLDS_LICPLATE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-mask
											v-if="controls.FIELDHLPFLDS_LICPLATE.isVisible"
											v-bind="controls.FIELDHLPFLDS_LICPLATE"
											:model-value="model.ValLicplate.value"
											@update:model-value="model.ValLicplate.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_BANKNMBR.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_BANKNMBR"
										v-on="controls.FIELDHLPFLDS_BANKNMBR.handlers"
										:loading="controls.FIELDHLPFLDS_BANKNMBR.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-mask
											v-if="controls.FIELDHLPFLDS_BANKNMBR.isVisible"
											v-bind="controls.FIELDHLPFLDS_BANKNMBR"
											:model-value="model.ValBanknmbr.value"
											@update:model-value="model.ValBanknmbr.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_EMAILFLD.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_EMAILFLD"
										v-on="controls.FIELDHLPFLDS_EMAILFLD.handlers"
										:loading="controls.FIELDHLPFLDS_EMAILFLD.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-mask
											v-if="controls.FIELDHLPFLDS_EMAILFLD.isVisible"
											v-bind="controls.FIELDHLPFLDS_EMAILFLD"
											:model-value="model.ValEmailfld.value"
											@update:model-value="model.ValEmailfld.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_IBANFIEL.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_IBANFIEL"
										v-on="controls.FIELDHLPFLDS_IBANFIEL.handlers"
										:loading="controls.FIELDHLPFLDS_IBANFIEL.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-mask
											v-if="controls.FIELDHLPFLDS_IBANFIEL.isVisible"
											v-bind="controls.FIELDHLPFLDS_IBANFIEL"
											:model-value="model.ValIbanfiel.value"
											@update:model-value="model.ValIbanfiel.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_UPPRTEXT.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_UPPRTEXT"
										v-on="controls.FIELDHLPFLDS_UPPRTEXT.handlers"
										:loading="controls.FIELDHLPFLDS_UPPRTEXT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-mask
											v-if="controls.FIELDHLPFLDS_UPPRTEXT.isVisible"
											v-bind="controls.FIELDHLPFLDS_UPPRTEXT"
											:model-value="model.ValUpprtext.value"
											@update:model-value="model.ValUpprtext.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End FIELDHLPPSEUDNOVOGR04 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.FIELDHLPPSEUDNOVOGR05.isVisible">
					<q-control-wrapper
						v-show="controls.FIELDHLPPSEUDNOVOGR05.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="FIELDHLPPSEUDNOVOGR05"
							v-bind="controls.FIELDHLPPSEUDNOVOGR05"
							:is-visible="controls.FIELDHLPPSEUDNOVOGR05.isVisible">
							<!-- Start FIELDHLPPSEUDNOVOGR05 -->
							<q-row-container v-show="controls.FIELDHLPFLDS_PASSFLD_.isVisible || controls.FIELDHLPFLDS_CLRPICKE.isVisible">
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_PASSFLD_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_PASSFLD_"
										v-on="controls.FIELDHLPFLDS_PASSFLD_.handlers"
										:loading="controls.FIELDHLPFLDS_PASSFLD_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-password-input
											v-if="controls.FIELDHLPFLDS_PASSFLD_.isVisible"
											v-bind="controls.FIELDHLPFLDS_PASSFLD_"
											:model-value="model.ValPassfld.value"
											:label-text="controls.FIELDHLPFLDS_PASSFLD_.label"
											@update:model-value="model.ValPassfld.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_CLRPICKE.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_CLRPICKE"
										v-on="controls.FIELDHLPFLDS_CLRPICKE.handlers"
										:loading="controls.FIELDHLPFLDS_CLRPICKE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-text-field
											v-bind="controls.FIELDHLPFLDS_CLRPICKE.props"
											:model-value="model.ValClrpicke.value"
											@update:model-value="model.ValClrpicke.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End FIELDHLPPSEUDNOVOGR05 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.FIELDHLPFLDS_CREATUSE.isVisible || controls.FIELDHLPFLDS_CREATDAT.isVisible || controls.FIELDHLPFLDS_CREATINS.isVisible || controls.FIELDHLPFLDS_CREATHOU.isVisible">
					<q-control-wrapper
						v-show="controls.FIELDHLPFLDS_CREATUSE.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.FIELDHLPFLDS_CREATUSE"
							v-on="controls.FIELDHLPFLDS_CREATUSE.handlers"
							:loading="controls.FIELDHLPFLDS_CREATUSE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.FIELDHLPFLDS_CREATUSE.props"
								:model-value="model.ValCreatuse.value" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FIELDHLPFLDS_CREATDAT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.FIELDHLPFLDS_CREATDAT"
							v-on="controls.FIELDHLPFLDS_CREATDAT.handlers"
							:loading="controls.FIELDHLPFLDS_CREATDAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-datetime-input
								v-if="controls.FIELDHLPFLDS_CREATDAT.isVisible"
								v-bind="controls.FIELDHLPFLDS_CREATDAT"
								format="Date"
								:model-value="model.ValCreatdat.value"
								@update:model-value="model.ValCreatdat.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FIELDHLPFLDS_CREATINS.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.FIELDHLPFLDS_CREATINS"
							v-on="controls.FIELDHLPFLDS_CREATINS.handlers"
							:loading="controls.FIELDHLPFLDS_CREATINS.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-datetime-input
								v-if="controls.FIELDHLPFLDS_CREATINS.isVisible"
								v-bind="controls.FIELDHLPFLDS_CREATINS"
								format="DateTimeSeconds"
								:model-value="model.ValCreatins.value"
								@update:model-value="model.ValCreatins.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.FIELDHLPFLDS_CREATHOU.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.FIELDHLPFLDS_CREATHOU"
							v-on="controls.FIELDHLPFLDS_CREATHOU.handlers"
							:loading="controls.FIELDHLPFLDS_CREATHOU.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-datetime-input
								v-if="controls.FIELDHLPFLDS_CREATHOU.isVisible"
								v-bind="controls.FIELDHLPFLDS_CREATHOU"
								format="Time"
								:model-value="model.ValCreathou.value"
								@update:model-value="model.ValCreathou.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.FIELDHLPPSEUDNOVOGR07.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.FIELDHLPPSEUDNOVOGR07.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="FIELDHLPPSEUDNOVOGR07"
							v-bind="controls.FIELDHLPPSEUDNOVOGR07"
							:is-visible="controls.FIELDHLPPSEUDNOVOGR07.isVisible">
							<!-- Start FIELDHLPPSEUDNOVOGR07 -->
							<q-row-container v-show="controls.FIELDHLPFLDS_LOGO____.isVisible || controls.FIELDHLPFLDS_ATTACH__.isVisible">
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_LOGO____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="q-image"
										v-bind="controls.FIELDHLPFLDS_LOGO____"
										v-on="controls.FIELDHLPFLDS_LOGO____.handlers"
										:loading="controls.FIELDHLPFLDS_LOGO____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-image
											v-if="controls.FIELDHLPFLDS_LOGO____.isVisible"
											v-bind="controls.FIELDHLPFLDS_LOGO____.props"
											v-on="controls.FIELDHLPFLDS_LOGO____.handlers" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.FIELDHLPFLDS_ATTACH__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.FIELDHLPFLDS_ATTACH__"
										v-on="controls.FIELDHLPFLDS_ATTACH__.handlers"
										:loading="controls.FIELDHLPFLDS_ATTACH__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-document
											v-if="controls.FIELDHLPFLDS_ATTACH__.isVisible"
											id="FIELDHLPFLDS_ATTACH__"
											size="xxlarge"
											:model-value="model.ValAttach.value"
											versioning-is-on
											:readonly="controls.FIELDHLPFLDS_ATTACH__.readonly"
											:is-in-checkout="controls.FIELDHLPFLDS_ATTACH__.isInCheckout"
											:current-version="controls.FIELDHLPFLDS_ATTACH__.currentVersion"
											:extensions="controls.FIELDHLPFLDS_ATTACH__.extensions"
											:max-file-size="controls.FIELDHLPFLDS_ATTACH__.maxFileSize"
											:versions="controls.FIELDHLPFLDS_ATTACH__.documentVersions"
											:versions-info="controls.FIELDHLPFLDS_ATTACH__.versionsInfo"
											:file-properties="controls.FIELDHLPFLDS_ATTACH__.fileProperties"
											:texts="controls.FIELDHLPFLDS_ATTACH__.texts"
											:popup-is-visible="controls.FIELDHLPFLDS_ATTACH__.popupIsVisible"
											:disallow-removal="controls.FIELDHLPFLDS_ATTACH__.isRequired"
											:resources-path="controls.FIELDHLPFLDS_ATTACH__.resourcesPath"
											:uses-templates="controls.FIELDHLPFLDS_ATTACH__.usesTemplates"
											@file-error="controls.FIELDHLPFLDS_ATTACH__.HandleFileError($event)"
											@submit-file="controls.FIELDHLPFLDS_ATTACH__.SetFile($event)"
											@edit-file="controls.FIELDHLPFLDS_ATTACH__.SetCheckoutState()"
											@get-properties="controls.FIELDHLPFLDS_ATTACH__.GetFileProperties()"
											@get-version-history="controls.FIELDHLPFLDS_ATTACH__.GetVersionsInfo()"
											@get-file="controls.FIELDHLPFLDS_ATTACH__.GetFile()"
											@download-file="controls.FIELDHLPFLDS_ATTACH__.DownloadFile()"
											@get-file-version="controls.FIELDHLPFLDS_ATTACH__.GetFileVersion($event)"
											@delete-last="controls.FIELDHLPFLDS_ATTACH__.DeleteFile(0)"
											@delete-history="controls.FIELDHLPFLDS_ATTACH__.DeleteFile(1)"
											@delete-file="controls.FIELDHLPFLDS_ATTACH__.DeleteFile(2)"
											@show-popup="controls.FIELDHLPFLDS_ATTACH__.SetModal($event)"
											@hide-popup="controls.FIELDHLPFLDS_ATTACH__.RemoveModal($event)"
											@show-templates-popup="controls.FIELDHLPFLDS_ATTACH__.handleDocumentTemplates($event)" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End FIELDHLPPSEUDNOVOGR07 -->
						</q-group-box-container>
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
				default: () => {
					return {
						name: 'FIELDHLP',
						location: 'form-FIELDHLP',
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
					mode: ''
				},

				formButtons: {
					btn_isap: {
						id: 'btn_isap-btn',
						text: computed(() => this.Resources.APPLY29100),
						type: 'custom',
						style: 'secondary',
						showInHeader: false,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.controls.FIELDHLPPSEUDBTN_ISAP.checkFieldIsVisible()),
						disabled: computed(() => vm.controls.FIELDHLPPSEUDBTN_ISAP.isBlocked),
						action: (e) => vm.controls.FIELDHLPPSEUDBTN_ISAP.action(e)
					},
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
					applyBtn: {
						id: 'apply-btn',
						icon: {
							icon: 'apply',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.apply]),
						style: 'secondary',
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
					FIELDHLPPSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'FIELDHLPPSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.TEXT_INPUTS37770),
						userHelp: computed(() => this.Resources._111418227),
						description: computed(() => this.Resources._1114_VERBOSE42095),
						placeholder: '',
						labelPosition: '',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_TXTFIELD: new fieldControlClass.StringControl({
						modelField: 'ValTxtfield',
						valueChangeEvent: 'fieldChange:flds.txtfield',
						id: 'FIELDHLPFLDS_TXTFIELD',
						name: 'TXTFIELD',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.TEXT_FIELD41810),
						userHelp: computed(() => this.Resources._111536184),
						description: computed(() => this.Resources._1115_VERBOSE27480),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR02',
						maxLength: 50,
						labelId: 'label_FIELDHLPFLDS_TXTFIELD',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_DESCRIP_: new fieldControlClass.StringControl({
						modelField: 'ValDescrip',
						valueChangeEvent: 'fieldChange:flds.descrip',
						id: 'FIELDHLPFLDS_DESCRIP_',
						name: 'DESCRIP',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.MULTINE_TEXT05310),
						userHelp: computed(() => this.Resources._111636045),
						description: computed(() => this.Resources._1116_VERBOSE64950),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR02',
						maxLength: 300,
						labelId: 'label_FIELDHLPFLDS_DESCRIP_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPPSEUDNOVOGR06: new fieldControlClass.GroupControl({
						id: 'FIELDHLPPSEUDNOVOGR06',
						name: 'NOVOGR06',
						size: 'medium',
						hasLabel: true,
						label: '',
						userHelp: computed(() => this.Resources._111418227),
						description: computed(() => this.Resources._1114_VERBOSE42095),
						placeholder: '',
						labelPosition: '',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_YEAR____: new fieldControlClass.NumberControl({
						modelField: 'ValYear',
						valueChangeEvent: 'fieldChange:flds.year',
						maxIntegers: 4,
						maxDecimals: 0,
						id: 'FIELDHLPFLDS_YEAR____',
						name: 'YEAR',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.YEAR61794),
						userHelp: computed(() => this.Resources._111737822),
						description: computed(() => this.Resources._1117_VERBOSE04450),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR01',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_TIME____: new fieldControlClass.TimeControl({
						modelField: 'ValTime',
						valueChangeEvent: 'fieldChange:flds.time',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'FIELDHLPFLDS_TIME____',
						name: 'TIME',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.TIME15328),
						userHelp: computed(() => this.Resources._111838179),
						description: computed(() => this.Resources._1118_VERBOSE37983),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR01',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_DATE____: new fieldControlClass.DateControl({
						modelField: 'ValDate',
						valueChangeEvent: 'fieldChange:flds.date',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'FIELDHLPFLDS_DATE____',
						name: 'DATE',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.DATE18475),
						userHelp: computed(() => this.Resources._111938548),
						description: computed(() => this.Resources._1119_VERBOSE52944),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR01',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_DATETIME: new fieldControlClass.DateControl({
						modelField: 'ValDatetime',
						valueChangeEvent: 'fieldChange:flds.datetime',
						id: 'FIELDHLPFLDS_DATETIME',
						name: 'DATETIME',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.DATE_TIME59103),
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR01',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_DATESECO: new fieldControlClass.DateControl({
						modelField: 'ValDateseco',
						valueChangeEvent: 'fieldChange:flds.dateseco',
						id: 'FIELDHLPFLDS_DATESECO',
						name: 'DATESECO',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.DATE_SECOND44057),
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR01',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_NPASSAGE: new fieldControlClass.NumberControl({
						modelField: 'ValNpassage',
						valueChangeEvent: 'fieldChange:flds.npassage',
						maxIntegers: 3,
						maxDecimals: 0,
						id: 'FIELDHLPFLDS_NPASSAGE',
						name: 'NPASSAGE',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.NUMERIC19292),
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR03',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_DURATION: new fieldControlClass.NumberControl({
						modelField: 'ValDuration',
						valueChangeEvent: 'fieldChange:flds.duration',
						maxIntegers: 2,
						maxDecimals: 2,
						id: 'FIELDHLPFLDS_DURATION',
						name: 'DURATION',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.NUMERIC_DECIMAL49512),
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR03',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_PRECOBIL: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrecobil',
						valueChangeEvent: 'fieldChange:flds.precobil',
						maxIntegers: 3,
						maxDecimals: 2,
						id: 'FIELDHLPFLDS_PRECOBIL',
						name: 'PRECOBIL',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.CURRENCY_DECIMAL48296),
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR03',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_PRICE___: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrice',
						valueChangeEvent: 'fieldChange:flds.price',
						maxIntegers: 3,
						maxDecimals: 2,
						id: 'FIELDHLPFLDS_PRICE___',
						name: 'PRICE',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.CURRENCY13881),
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR03',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPPSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'FIELDHLPPSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.DATE_TIME_INPUTS06842),
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
					FIELDHLPPSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'FIELDHLPPSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.NUMERIC_INPUTS64739),
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
					FIELDHLPFLDS_SSNUMBER: new fieldControlClass.MaskControl({
						modelField: 'ValSsnumber',
						valueChangeEvent: 'fieldChange:flds.ssnumber',
						id: 'FIELDHLPFLDS_SSNUMBER',
						name: 'SSNUMBER',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.SOCIAL_SECURITY_NO48150),
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: computed(() => this.Resources._1234567891237929),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR04',
						maxLength: 11,
						labelId: 'label_FIELDHLPFLDS_SSNUMBER',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_ZIPFIELD: new fieldControlClass.MaskControl({
						modelField: 'ValZipfield',
						valueChangeEvent: 'fieldChange:flds.zipfield',
						id: 'FIELDHLPFLDS_ZIPFIELD',
						name: 'ZIPFIELD',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.ZIPCODE21021),
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: computed(() => this.Resources.XXXX_XXX51420),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR04',
						maxLength: 8,
						labelId: 'label_FIELDHLPFLDS_ZIPFIELD',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_VATNUMBR: new fieldControlClass.MaskControl({
						modelField: 'ValVatnumbr',
						valueChangeEvent: 'fieldChange:flds.vatnumbr',
						id: 'FIELDHLPFLDS_VATNUMBR',
						name: 'VATNUMBR',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.VAT_NUMBER24236),
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: computed(() => this.Resources._12345678953785),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR04',
						maxLength: 9,
						labelId: 'label_FIELDHLPFLDS_VATNUMBR',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_LICPLATE: new fieldControlClass.MaskControl({
						modelField: 'ValLicplate',
						valueChangeEvent: 'fieldChange:flds.licplate',
						id: 'FIELDHLPFLDS_LICPLATE',
						name: 'LICPLATE',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.LICENCE_PLATE07627),
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: computed(() => this.Resources.XX_00_XX10122),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR04',
						maxLength: 8,
						labelId: 'label_FIELDHLPFLDS_LICPLATE',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_BANKNMBR: new fieldControlClass.MaskControl({
						modelField: 'ValBanknmbr',
						valueChangeEvent: 'fieldChange:flds.banknmbr',
						id: 'FIELDHLPFLDS_BANKNMBR',
						name: 'BANKNMBR',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.BANKING_ACCOUNT_NUMB62548),
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: computed(() => this.Resources._1234_5678_90123456761043),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR04',
						maxLength: 24,
						labelId: 'label_FIELDHLPFLDS_BANKNMBR',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_EMAILFLD: new fieldControlClass.MaskControl({
						modelField: 'ValEmailfld',
						valueChangeEvent: 'fieldChange:flds.emailfld',
						id: 'FIELDHLPFLDS_EMAILFLD',
						name: 'EMAILFLD',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.EMAIL25170),
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: computed(() => this.Resources.QUIDGESTAT_QUIDGEST_PT47872),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR04',
						maxLength: 50,
						labelId: 'label_FIELDHLPFLDS_EMAILFLD',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_IBANFIEL: new fieldControlClass.MaskControl({
						modelField: 'ValIbanfiel',
						valueChangeEvent: 'fieldChange:flds.ibanfiel',
						id: 'FIELDHLPFLDS_IBANFIEL',
						name: 'IBANFIEL',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.IBAN28506),
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: computed(() => this.Resources.PT12345678901234567820477),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR04',
						maxLength: 34,
						labelId: 'label_FIELDHLPFLDS_IBANFIEL',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_UPPRTEXT: new fieldControlClass.MaskControl({
						modelField: 'ValUpprtext',
						valueChangeEvent: 'fieldChange:flds.upprtext',
						id: 'FIELDHLPFLDS_UPPRTEXT',
						name: 'UPPRTEXT',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.UPPERCASE48238),
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: computed(() => this.Resources.QUIDGEST56322),
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR04',
						maxLength: 50,
						labelId: 'label_FIELDHLPFLDS_UPPRTEXT',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPPSEUDNOVOGR04: new fieldControlClass.GroupControl({
						id: 'FIELDHLPPSEUDNOVOGR04',
						name: 'NOVOGR04',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.INPUTS_WITH_MASKS08900),
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
					FIELDHLPFLDS_PASSFLD_: new fieldControlClass.StringControl({
						modelField: 'ValPassfld',
						valueChangeEvent: 'fieldChange:flds.passfld',
						id: 'FIELDHLPFLDS_PASSFLD_',
						name: 'PASSFLD',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.PASSWORD09467),
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR05',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ConfirmFIELDHLPFLDS_PASSFLD_: new fieldControlClass.StringControl({
						modelField: 'ConfirmValPassfld',
						id: 'ConfirmFIELDHLPFLDS_PASSFLD_',
						name: 'ConfirmPASSFLD',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.CONFIRMAR09808),
						placeholder: computed(() => this.Resources.CONFIRMAR09808),
						// Hide confirmation field in non-editable mode.
						hiddenInNonEditableMode: true
					}, this),
					FIELDHLPFLDS_CLRPICKE: new fieldControlClass.StringControl({
						modelField: 'ValClrpicke',
						valueChangeEvent: 'fieldChange:flds.clrpicke',
						id: 'FIELDHLPFLDS_CLRPICKE',
						name: 'CLRPICKE',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.COLORPICKER39653),
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR05',
						maxLength: 50,
						labelId: 'label_FIELDHLPFLDS_CLRPICKE',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPPSEUDNOVOGR05: new fieldControlClass.GroupControl({
						id: 'FIELDHLPPSEUDNOVOGR05',
						name: 'NOVOGR05',
						size: 'large',
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
					FIELDHLPFLDS_PRIMVIAG: new fieldControlClass.BooleanControl({
						modelField: 'ValPrimviag',
						valueChangeEvent: 'fieldChange:flds.primviag',
						id: 'FIELDHLPFLDS_PRIMVIAG',
						name: 'PRIMVIAG',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.LOGICAL47485),
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: '',
						labelPosition: '',
						container: 'FIELDHLPPSEUDNOVOGR06',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_LOGICENU: new fieldControlClass.ArrayBooleanControl({
						modelField: 'ValLogicenu',
						valueChangeEvent: 'fieldChange:flds.logicenu',
						id: 'FIELDHLPFLDS_LOGICENU',
						name: 'LOGICENU',
						size: 'mini',
						hasLabel: true,
						label: '',
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR06',
						arrayName: 'PRIMVIAG',
						trueLabel: computed(() => this.Resources.YES34196),
						falseLabel: computed(() => this.Resources.NO57340),
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_CREATUSE: new fieldControlClass.StringControl({
						modelField: 'ValCreatuse',
						valueChangeEvent: 'fieldChange:flds.creatuse',
						id: 'FIELDHLPFLDS_CREATUSE',
						name: 'CREATUSE',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.CREATED_BY12292),
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 20,
						labelId: 'label_FIELDHLPFLDS_CREATUSE',
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					FIELDHLPFLDS_CREATDAT: new fieldControlClass.DateControl({
						modelField: 'ValCreatdat',
						valueChangeEvent: 'fieldChange:flds.creatdat',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'FIELDHLPFLDS_CREATDAT',
						name: 'CREATDAT',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.DAY27593),
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					FIELDHLPFLDS_CREATINS: new fieldControlClass.DateControl({
						modelField: 'ValCreatins',
						valueChangeEvent: 'fieldChange:flds.creatins',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'FIELDHLPFLDS_CREATINS',
						name: 'CREATINS',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.COMPLETE_DATE53774),
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					FIELDHLPFLDS_CREATHOU: new fieldControlClass.TimeControl({
						modelField: 'ValCreathou',
						valueChangeEvent: 'fieldChange:flds.creathou',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'FIELDHLPFLDS_CREATHOU',
						name: 'CREATHOU',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.HOUR15646),
						userHelp: computed(() => this.Resources._112047598),
						description: computed(() => this.Resources._1120_VERBOSE06198),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					FIELDHLPPSEUDBTN_ISAP: new fieldControlClass.ButtonControl({
						id: 'FIELDHLPPSEUDBTN_ISAP',
						name: 'BTN_ISAP',
						size: 'small',
						hasLabel: false,
						label: computed(() => this.Resources.APPLY29100),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						// eslint-disable-next-line
						action: (event) => {
							let btnAction = () => {
								vm.Fieldhlp_BR_APPLWIT(vm.primaryKeyValue)
							}
							let options = {
								form: 'FIELDHLP',
								callback: btnAction
							}
							vm.$eventHub.emit('form-apply', options)
						},
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_RADIOB__: new fieldControlClass.ArrayStringControl({
						modelField: 'ValRadiob',
						valueChangeEvent: 'fieldChange:flds.radiob',
						id: 'FIELDHLPFLDS_RADIOB__',
						name: 'RADIOB',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.RADIO_BTN20980),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'FIELDHLPPSEUDNOVOGR06',
						maxLength: 5,
						labelId: 'label_FIELDHLPFLDS_RADIOB__',
						arrayName: 'RADIOBTN',
						columnNumber: 2,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPPSEUDNOVOGR07: new fieldControlClass.GroupControl({
						id: 'FIELDHLPPSEUDNOVOGR07',
						name: 'NOVOGR07',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.DOCUMENTS14470),
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
					FIELDHLPFLDS_LOGO____: new fieldControlClass.ImageControl({
						modelField: 'ValLogo',
						valueChangeEvent: 'fieldChange:flds.logo',
						id: 'FIELDHLPFLDS_LOGO____',
						name: 'LOGO',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.LOGO62483),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR07',
						height: 50,
						width: 100,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_ATTACH__: new fieldControlClass.DocumentControl({
						modelField: 'ValAttach',
						valueChangeEvent: 'fieldChange:flds.attach',
						id: 'FIELDHLPFLDS_ATTACH__',
						name: 'ATTACH',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.DOCUMENT00695),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR07',
						documentProperties: computed(() => vm.model.ValAttachPropertiesVM),
						documentFK: computed(() => vm.model.ValAttachfk),
						documentVersions: computed(() => vm.model.ValAttachPropertiesVM.value ? vm.model.ValAttachPropertiesVM.value.Versions : {}),
						isInCheckout: computed(() => vm.model.ValAttachPropertiesVM.value ? vm.model.ValAttachPropertiesVM.value.IsCheckout : false),
						currentVersion: computed(() => vm.model.ValAttachPropertiesVM.value ? vm.model.ValAttachPropertiesVM.value.Version : '1'),
						usesTemplates: false,
						extensions: [],
						viewType: qEnums.documentViewTypeMode.Print,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					FIELDHLPFLDS_CLASSNUM: new fieldControlClass.ArrayNumberControl({
						modelField: 'ValClassnum',
						valueChangeEvent: 'fieldChange:flds.classnum',
						maxIntegers: 1,
						maxDecimals: 0,
						id: 'FIELDHLPFLDS_CLASSNUM',
						name: 'CLASSNUM',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.NUMERIC_ENUMERATION19068),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'FIELDHLPPSEUDNOVOGR06',
						arrayName: 'CLASSNUM',
						mustBeFilled: false,
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
					Equip: {
						get ValRegistnr() { return vm.model.TableEquipRegistnr.value },
						set ValRegistnr(value) { vm.model.TableEquipRegistnr.updateValue(value) },
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
// USE /[MANUAL GQT FORM_CODEJS FIELDHLP]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS FIELDHLP]/
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
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

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
				for (let trigger of triggers)
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
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

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
				let redirectPage = true // Set to 'false' to cancel page redirect.

				// Execute the "After save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterSave)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT AFTER_SAVE_JS FIELDHLP]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS FIELDHLP]/
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
// USE /[MANUAL GQT AFTER_DEL_JS FIELDHLP]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS FIELDHLP]/
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

			// eslint-disable-next-line
			Fieldhlp_BR_APPLWIT(id)
			{
				this.$eventTracker.addTrace({
					origin: 'Routine APPLWIT',
					message: 'Start of execution of the manual routine'
				})

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT VIEW_MANUAL_ROUTINE APPLWIT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.Fieldhlp_BR_APPLWIT_BeforeSend(id).then((result) => {
					return this.Fieldhlp_BR_APPLWIT_AjaxCall(result)
				})
			},

			Fieldhlp_BR_APPLWIT_AjaxCall(id)
			{
				var params = {}
				if (typeof id === 'object')
					params = id
				else if (typeof id !== 'undefined')
					params = { id }

				this.$eventTracker.addTrace({
					origin: 'Routine APPLWIT',
					message: 'Ajax call method',
					contextData: { params }
				})

				/*
				 * This param can come from the jsonRouteValues that come from the
				 * component in case of forms, for example. We do not want to replace
				 * it with this new one!
				 */
				if (typeof params.allSelected === 'undefined')
				{
					params.allSelected = false
				}

				asyncProcM.AddBusy(netAPI.postData(
					'Flds',
					'Fieldhlp_BR_APPLWIT',
					params,
					(data) => {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT DONE_ROUTINE APPLWIT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

						// DISCLAIMER: Adding code to "DONE_ROUTINE" will override the code below.
						try
						{
							if (typeof data.success !== 'string' || typeof data.message !== 'string')
								throw new Error('Invalid data structure.')

							const result = qEnums.messageTypes[data.success]
							if (!genericFunctions.isEmpty(result))
							{
								this.$eventTracker.addTrace({
									origin: 'Routine APPLWIT',
									message: 'Manual routine "APPLWIT" finished execution with result: ' + qEnums.messageTypes[data.success]
								})

								let message = data.message

								if (!genericFunctions.isEmpty(message))
								{
									const buttons = {
										confirm: {
											label: this.Resources.OK15819,
											action: () => this.Fieldhlp_BR_APPLWIT_AfterDone(data)
										}
									}

									genericFunctions.displayMessage(message, result, null, buttons)
								}
								else
									this.Fieldhlp_BR_APPLWIT_AfterDone(data)
							}
							else
								this.$eventTracker.addError({ origin: 'Routine APPLWIT', message: 'Routine "APPLWIT" finished execution with an unknown result type: ' + data.success })
						}
						catch (e)
						{
							genericFunctions.displayMessage(this.Resources.NAO_FOI_POSSIVEL_CON65121, 'error')
							this.$eventTracker.addError({ origin: 'Routine APPLWIT (catch)', message: e.toString() })
						}
					},
					() => {
						genericFunctions.displayMessage(this.Resources.NAO_FOI_POSSIVEL_CON65121, 'error')
					},
					undefined,
					this.navigationId)
				)
			},

			// eslint-disable-next-line
			async Fieldhlp_BR_APPLWIT_AfterDone(data)
			{
				this.$eventTracker.addTrace({
					origin: 'Routine APPLWIT',
					message: 'After done method',
					contextData: { data }
				})

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT AFTER_DONE_ROUTINE APPLWIT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			Fieldhlp_BR_APPLWIT_BeforeSend(data)
			{
				this.$eventTracker.addTrace({
					origin: 'Routine APPLWIT',
					message: 'Before send method',
					contextData: { data }
				})

				return new Promise((resolve, reject) => {
					try
					{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT BEFORESEND_ROUTINE APPLWIT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

						resolve(data)
					}
					catch (e)
					{
						reject(e.toString())
					}
				})
			},
		},

		watch: {
		}
	}
</script>
