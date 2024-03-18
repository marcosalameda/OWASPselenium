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
			data-key="ENTIT"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.ENTIT___ENTITNAME____.isVisible || controls.ENTIT___ENTITINITIALS.isVisible || controls.ENTIT___ENTITREGISTRA.isVisible || controls.ENTIT___ENTITTAXNUMBE.isVisible || controls.ENTIT___ENTITEMAIL___.isVisible || controls.ENTIT___ENTITPHONENUM.isVisible || controls.ENTIT___ENTITIBAN____.isVisible || controls.ENTIT___ENTITBUILDING.isVisible || controls.ENTIT___ENTITSTREET__.isVisible || controls.ENTIT___ENTITTOWN____.isVisible || controls.ENTIT___ENTITCOUNTY__.isVisible || controls.ENTIT___ENTITSTATE___.isVisible || controls.ENTIT___ENTITPOBOX___.isVisible || controls.ENTIT___ENTITPOSTALCO.isVisible || controls.ENTIT___ENTITTELEPHON.isVisible || controls.ENTIT___ENTITFAX_____.isVisible || controls.ENTIT___ENTITWEBSITE_.isVisible || controls.ENTIT___ENTITPERSON__.isVisible || controls.ENTIT___ENTITCONTACT_.isVisible || controls.ENTIT___ENTITOWNER___.isVisible || controls.ENTIT___ENTITCARRIER_.isVisible || controls.ENTIT___ENTITSUPPLIER.isVisible || controls.ENTIT___ENTITMANUFACT.isVisible || controls.ENTIT___ENTITFOUNDED_.isVisible || controls.ENTIT___FACI1NAME____.isVisible || controls.ENTIT___FACI2NAME____.isVisible || controls.ENTIT___ENTITLANGUAGE.isVisible || controls.ENTIT___ENTITCURRENCY.isVisible">
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITNAME____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITNAME____"
							v-on="controls.ENTIT___ENTITNAME____.handlers"
							:loading="controls.ENTIT___ENTITNAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ENTIT___ENTITNAME____.props"
								:model-value="model.ValName.value"
								@update:model-value="model.ValName.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITINITIALS.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITINITIALS"
							v-on="controls.ENTIT___ENTITINITIALS.handlers"
							:loading="controls.ENTIT___ENTITINITIALS.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ENTIT___ENTITINITIALS.props"
								:model-value="model.ValInitials.value"
								@update:model-value="model.ValInitials.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITREGISTRA.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITREGISTRA"
							v-on="controls.ENTIT___ENTITREGISTRA.handlers"
							:loading="controls.ENTIT___ENTITREGISTRA.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ENTIT___ENTITREGISTRA.props"
								:model-value="model.ValRegistra.value"
								@update:model-value="model.ValRegistra.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITTAXNUMBE.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITTAXNUMBE"
							v-on="controls.ENTIT___ENTITTAXNUMBE.handlers"
							:loading="controls.ENTIT___ENTITTAXNUMBE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ENTIT___ENTITTAXNUMBE.props"
								:model-value="model.ValTaxnumbe.value"
								@update:model-value="model.ValTaxnumbe.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITEMAIL___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITEMAIL___"
							v-on="controls.ENTIT___ENTITEMAIL___.handlers"
							:loading="controls.ENTIT___ENTITEMAIL___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ENTIT___ENTITEMAIL___.props"
								:model-value="model.ValEmail.value"
								@update:model-value="model.ValEmail.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITPHONENUM.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITPHONENUM"
							v-on="controls.ENTIT___ENTITPHONENUM.handlers"
							:loading="controls.ENTIT___ENTITPHONENUM.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ENTIT___ENTITPHONENUM.props"
								:model-value="model.ValPhonenum.value"
								@update:model-value="model.ValPhonenum.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITIBAN____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITIBAN____"
							v-on="controls.ENTIT___ENTITIBAN____.handlers"
							:loading="controls.ENTIT___ENTITIBAN____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ENTIT___ENTITIBAN____.props"
								:model-value="model.ValIban.value"
								@update:model-value="model.ValIban.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITBUILDING.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITBUILDING"
							v-on="controls.ENTIT___ENTITBUILDING.handlers"
							:loading="controls.ENTIT___ENTITBUILDING.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ENTIT___ENTITBUILDING.props"
								:model-value="model.ValBuilding.value"
								@update:model-value="model.ValBuilding.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITSTREET__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITSTREET__"
							v-on="controls.ENTIT___ENTITSTREET__.handlers"
							:loading="controls.ENTIT___ENTITSTREET__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ENTIT___ENTITSTREET__.props"
								:model-value="model.ValStreet.value"
								@update:model-value="model.ValStreet.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITTOWN____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITTOWN____"
							v-on="controls.ENTIT___ENTITTOWN____.handlers"
							:loading="controls.ENTIT___ENTITTOWN____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ENTIT___ENTITTOWN____.props"
								:model-value="model.ValTown.value"
								@update:model-value="model.ValTown.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITCOUNTY__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITCOUNTY__"
							v-on="controls.ENTIT___ENTITCOUNTY__.handlers"
							:loading="controls.ENTIT___ENTITCOUNTY__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ENTIT___ENTITCOUNTY__.props"
								:model-value="model.ValCounty.value"
								@update:model-value="model.ValCounty.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITSTATE___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITSTATE___"
							v-on="controls.ENTIT___ENTITSTATE___.handlers"
							:loading="controls.ENTIT___ENTITSTATE___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ENTIT___ENTITSTATE___.props"
								:model-value="model.ValState.value"
								@update:model-value="model.ValState.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITPOBOX___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITPOBOX___"
							v-on="controls.ENTIT___ENTITPOBOX___.handlers"
							:loading="controls.ENTIT___ENTITPOBOX___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ENTIT___ENTITPOBOX___.props"
								:model-value="model.ValPobox.value"
								@update:model-value="model.ValPobox.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITPOSTALCO.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITPOSTALCO"
							v-on="controls.ENTIT___ENTITPOSTALCO.handlers"
							:loading="controls.ENTIT___ENTITPOSTALCO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ENTIT___ENTITPOSTALCO.props"
								:model-value="model.ValPostalco.value"
								@update:model-value="model.ValPostalco.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITTELEPHON.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITTELEPHON"
							v-on="controls.ENTIT___ENTITTELEPHON.handlers"
							:loading="controls.ENTIT___ENTITTELEPHON.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ENTIT___ENTITTELEPHON.props"
								:model-value="model.ValTelephon.value"
								@update:model-value="model.ValTelephon.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITFAX_____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITFAX_____"
							v-on="controls.ENTIT___ENTITFAX_____.handlers"
							:loading="controls.ENTIT___ENTITFAX_____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ENTIT___ENTITFAX_____.props"
								:model-value="model.ValFax.value"
								@update:model-value="model.ValFax.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITWEBSITE_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITWEBSITE_"
							v-on="controls.ENTIT___ENTITWEBSITE_.handlers"
							:loading="controls.ENTIT___ENTITWEBSITE_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ENTIT___ENTITWEBSITE_.props"
								:model-value="model.ValWebsite.value"
								@update:model-value="model.ValWebsite.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITPERSON__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITPERSON__"
							v-on="controls.ENTIT___ENTITPERSON__.handlers"
							:loading="controls.ENTIT___ENTITPERSON__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ENTIT___ENTITPERSON__.props"
								:model-value="model.ValPerson.value"
								@update:model-value="model.ValPerson.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITCONTACT_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITCONTACT_"
							v-on="controls.ENTIT___ENTITCONTACT_.handlers"
							:loading="controls.ENTIT___ENTITCONTACT_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ENTIT___ENTITCONTACT_.props"
								:model-value="model.ValContact.value"
								@update:model-value="model.ValContact.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITOWNER___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.ENTIT___ENTITOWNER___"
							v-on="controls.ENTIT___ENTITOWNER___.handlers"
							:loading="controls.ENTIT___ENTITOWNER___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<template #label>
								<q-checkbox-input
									v-if="controls.ENTIT___ENTITOWNER___.isVisible"
									id="ENTIT___ENTITOWNER___"
									size="mini"
									:model-value="model.ValOwner.value"
									:readonly="controls.ENTIT___ENTITOWNER___.readonly"
									@update:model-value="model.ValOwner.fnUpdateValue" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITCARRIER_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.ENTIT___ENTITCARRIER_"
							v-on="controls.ENTIT___ENTITCARRIER_.handlers"
							:loading="controls.ENTIT___ENTITCARRIER_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<template #label>
								<q-checkbox-input
									v-if="controls.ENTIT___ENTITCARRIER_.isVisible"
									id="ENTIT___ENTITCARRIER_"
									size="mini"
									:model-value="model.ValCarrier.value"
									:readonly="controls.ENTIT___ENTITCARRIER_.readonly"
									@update:model-value="model.ValCarrier.fnUpdateValue" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITSUPPLIER.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.ENTIT___ENTITSUPPLIER"
							v-on="controls.ENTIT___ENTITSUPPLIER.handlers"
							:loading="controls.ENTIT___ENTITSUPPLIER.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<template #label>
								<q-checkbox-input
									v-if="controls.ENTIT___ENTITSUPPLIER.isVisible"
									id="ENTIT___ENTITSUPPLIER"
									size="small"
									:model-value="model.ValSupplier.value"
									:readonly="controls.ENTIT___ENTITSUPPLIER.readonly"
									@update:model-value="model.ValSupplier.fnUpdateValue" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITMANUFACT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.ENTIT___ENTITMANUFACT"
							v-on="controls.ENTIT___ENTITMANUFACT.handlers"
							:loading="controls.ENTIT___ENTITMANUFACT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<template #label>
								<q-checkbox-input
									v-if="controls.ENTIT___ENTITMANUFACT.isVisible"
									id="ENTIT___ENTITMANUFACT"
									size="small"
									:model-value="model.ValManufact.value"
									:readonly="controls.ENTIT___ENTITMANUFACT.readonly"
									@update:model-value="model.ValManufact.fnUpdateValue" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITFOUNDED_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITFOUNDED_"
							v-on="controls.ENTIT___ENTITFOUNDED_.handlers"
							:loading="controls.ENTIT___ENTITFOUNDED_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-datetime-input
								v-if="controls.ENTIT___ENTITFOUNDED_.isVisible"
								v-bind="controls.ENTIT___ENTITFOUNDED_"
								format="Date"
								:model-value="model.ValFounded.value"
								@update:model-value="model.ValFounded.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___FACI1NAME____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___FACI1NAME____"
							v-on="controls.ENTIT___FACI1NAME____.handlers"
							:loading="controls.ENTIT___FACI1NAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-lookup
								v-if="controls.ENTIT___FACI1NAME____.isVisible"
								v-bind="controls.ENTIT___FACI1NAME____.props"
								:model-value="model.ValFirstfacilitie.value"
								v-on="controls.ENTIT___FACI1NAME____.handlers"
								@update:model-value="model.ValFirstfacilitie.fnUpdateValue" />
							<q-see-more-entit-faci1name
								v-if="controls.ENTIT___FACI1NAME____.seeMoreIsVisible"
								v-bind="controls.ENTIT___FACI1NAME____.seeMoreParams"
								v-on="controls.ENTIT___FACI1NAME____.handlers" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___FACI2NAME____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___FACI2NAME____"
							v-on="controls.ENTIT___FACI2NAME____.handlers"
							:loading="controls.ENTIT___FACI2NAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-lookup
								v-if="controls.ENTIT___FACI2NAME____.isVisible"
								v-bind="controls.ENTIT___FACI2NAME____.props"
								:model-value="model.ValLastfacilitie.value"
								v-on="controls.ENTIT___FACI2NAME____.handlers"
								@update:model-value="model.ValLastfacilitie.fnUpdateValue" />
							<q-see-more-entit-faci2name
								v-if="controls.ENTIT___FACI2NAME____.seeMoreIsVisible"
								v-bind="controls.ENTIT___FACI2NAME____.seeMoreParams"
								v-on="controls.ENTIT___FACI2NAME____.handlers" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITLANGUAGE.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITLANGUAGE"
							v-on="controls.ENTIT___ENTITLANGUAGE.handlers"
							:loading="controls.ENTIT___ENTITLANGUAGE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ENTIT___ENTITLANGUAGE.props"
								:model-value="model.ValLanguage.value"
								@update:model-value="model.ValLanguage.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ENTIT___ENTITCURRENCY.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ENTIT___ENTITCURRENCY"
							v-on="controls.ENTIT___ENTITCURRENCY.handlers"
							:loading="controls.ENTIT___ENTITCURRENCY.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.ENTIT___ENTITCURRENCY.props"
								:model-value="model.ValCurrency.value"
								@update:model-value="model.ValCurrency.fnUpdateValue" />
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

	import FormViewModel from './QFormEntitViewModel.js'

	const requiredTextResources = ['QFormEntit', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS ENTIT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormEntit',

		components: {
			QSeeMoreEntitFaci1name: defineAsyncComponent(() => import('@/views/forms/FormEntit/dbedits/EntitFaci1nameSeeMore.vue')),
			QSeeMoreEntitFaci2name: defineAsyncComponent(() => import('@/views/forms/FormEntit/dbedits/EntitFaci2nameSeeMore.vue')),
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
						name: 'ENTIT',
						location: 'form-ENTIT',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormEntit', false),

				interfaceMetadata: {
					id: 'QFormEntit', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'ENTIT',
					route: 'form-ENTIT',
					area: 'ENTIT',
					primaryKey: 'ValCodentit',
					designation: computed(() => this.Resources.ENTITY62049),
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
						text: computed(() => vm.Resources.GRAVAR45301),
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
					ENTIT___ENTITNAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:entit.name',
						id: 'ENTIT___ENTITNAME____',
						name: 'NAME',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.LEGAL_NAME42902),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						labelId: 'label_ENTIT___ENTITNAME____',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITINITIALS: new fieldControlClass.StringControl({
						modelField: 'ValInitials',
						valueChangeEvent: 'fieldChange:entit.initials',
						id: 'ENTIT___ENTITINITIALS',
						name: 'INITIALS',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.COMPANY_INITIALS56204),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 10,
						labelId: 'label_ENTIT___ENTITINITIALS',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITREGISTRA: new fieldControlClass.StringControl({
						modelField: 'ValRegistra',
						valueChangeEvent: 'fieldChange:entit.registra',
						id: 'ENTIT___ENTITREGISTRA',
						name: 'REGISTRA',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.LEGAL_REGISTRATION04413),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 20,
						labelId: 'label_ENTIT___ENTITREGISTRA',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITTAXNUMBE: new fieldControlClass.StringControl({
						modelField: 'ValTaxnumbe',
						valueChangeEvent: 'fieldChange:entit.taxnumbe',
						id: 'ENTIT___ENTITTAXNUMBE',
						name: 'TAXNUMBE',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.VAT_NUMBER24236),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 20,
						labelId: 'label_ENTIT___ENTITTAXNUMBE',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITEMAIL___: new fieldControlClass.StringControl({
						modelField: 'ValEmail',
						valueChangeEvent: 'fieldChange:entit.email',
						id: 'ENTIT___ENTITEMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.EMAIL25170),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 254,
						labelId: 'label_ENTIT___ENTITEMAIL___',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITPHONENUM: new fieldControlClass.StringControl({
						modelField: 'ValPhonenum',
						valueChangeEvent: 'fieldChange:entit.phonenum',
						id: 'ENTIT___ENTITPHONENUM',
						name: 'PHONENUM',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.PHONE_NUMBER20774),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 20,
						labelId: 'label_ENTIT___ENTITPHONENUM',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITIBAN____: new fieldControlClass.StringControl({
						modelField: 'ValIban',
						valueChangeEvent: 'fieldChange:entit.iban',
						id: 'ENTIT___ENTITIBAN____',
						name: 'IBAN',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.IBAN__INTERNATIONAL_45066),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 25,
						labelId: 'label_ENTIT___ENTITIBAN____',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITBUILDING: new fieldControlClass.StringControl({
						modelField: 'ValBuilding',
						valueChangeEvent: 'fieldChange:entit.building',
						id: 'ENTIT___ENTITBUILDING',
						name: 'BUILDING',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.BUILDING_HOUSE_NUMBE20738),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 10,
						labelId: 'label_ENTIT___ENTITBUILDING',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITSTREET__: new fieldControlClass.StringControl({
						modelField: 'ValStreet',
						valueChangeEvent: 'fieldChange:entit.street',
						id: 'ENTIT___ENTITSTREET__',
						name: 'STREET',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.STREET44324),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						labelId: 'label_ENTIT___ENTITSTREET__',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITTOWN____: new fieldControlClass.StringControl({
						modelField: 'ValTown',
						valueChangeEvent: 'fieldChange:entit.town',
						id: 'ENTIT___ENTITTOWN____',
						name: 'TOWN',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.TOWN_CITY16259),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						labelId: 'label_ENTIT___ENTITTOWN____',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITCOUNTY__: new fieldControlClass.StringControl({
						modelField: 'ValCounty',
						valueChangeEvent: 'fieldChange:entit.county',
						id: 'ENTIT___ENTITCOUNTY__',
						name: 'COUNTY',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.COUNTY_PROVINCE34285),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						labelId: 'label_ENTIT___ENTITCOUNTY__',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITSTATE___: new fieldControlClass.StringControl({
						modelField: 'ValState',
						valueChangeEvent: 'fieldChange:entit.state',
						id: 'ENTIT___ENTITSTATE___',
						name: 'STATE',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.STATE_PROVINCE28516),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						labelId: 'label_ENTIT___ENTITSTATE___',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITPOBOX___: new fieldControlClass.StringControl({
						modelField: 'ValPobox',
						valueChangeEvent: 'fieldChange:entit.pobox',
						id: 'ENTIT___ENTITPOBOX___',
						name: 'POBOX',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.POST_OFFICE_BOX06223),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 5,
						labelId: 'label_ENTIT___ENTITPOBOX___',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITPOSTALCO: new fieldControlClass.StringControl({
						modelField: 'ValPostalco',
						valueChangeEvent: 'fieldChange:entit.postalco',
						id: 'ENTIT___ENTITPOSTALCO',
						name: 'POSTALCO',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.ZIP_POSTAL_CODE55613),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_ENTIT___ENTITPOSTALCO',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITTELEPHON: new fieldControlClass.StringControl({
						modelField: 'ValTelephon',
						valueChangeEvent: 'fieldChange:entit.telephon',
						id: 'ENTIT___ENTITTELEPHON',
						name: 'TELEPHON',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.TELEPHONE28697),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 20,
						labelId: 'label_ENTIT___ENTITTELEPHON',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITFAX_____: new fieldControlClass.StringControl({
						modelField: 'ValFax',
						valueChangeEvent: 'fieldChange:entit.fax',
						id: 'ENTIT___ENTITFAX_____',
						name: 'FAX',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.FAX08532),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 20,
						labelId: 'label_ENTIT___ENTITFAX_____',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITWEBSITE_: new fieldControlClass.StringControl({
						modelField: 'ValWebsite',
						valueChangeEvent: 'fieldChange:entit.website',
						id: 'ENTIT___ENTITWEBSITE_',
						name: 'WEBSITE',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.WEB_SITE06263),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 254,
						labelId: 'label_ENTIT___ENTITWEBSITE_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITPERSON__: new fieldControlClass.StringControl({
						modelField: 'ValPerson',
						valueChangeEvent: 'fieldChange:entit.person',
						id: 'ENTIT___ENTITPERSON__',
						name: 'PERSON',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.PERSON_DEPARTMENT_TO28777),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 85,
						labelId: 'label_ENTIT___ENTITPERSON__',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITCONTACT_: new fieldControlClass.StringControl({
						modelField: 'ValContact',
						valueChangeEvent: 'fieldChange:entit.contact',
						id: 'ENTIT___ENTITCONTACT_',
						name: 'CONTACT',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.CONTACT_TELEPHONE_NU12694),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 20,
						labelId: 'label_ENTIT___ENTITCONTACT_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITOWNER___: new fieldControlClass.BooleanControl({
						modelField: 'ValOwner',
						valueChangeEvent: 'fieldChange:entit.owner',
						id: 'ENTIT___ENTITOWNER___',
						name: 'OWNER',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.OWNER09558),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITCARRIER_: new fieldControlClass.BooleanControl({
						modelField: 'ValCarrier',
						valueChangeEvent: 'fieldChange:entit.carrier',
						id: 'ENTIT___ENTITCARRIER_',
						name: 'CARRIER',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.CARRIER64855),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITSUPPLIER: new fieldControlClass.BooleanControl({
						modelField: 'ValSupplier',
						valueChangeEvent: 'fieldChange:entit.supplier',
						id: 'ENTIT___ENTITSUPPLIER',
						name: 'SUPPLIER',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.SUPPLIER17230),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITMANUFACT: new fieldControlClass.BooleanControl({
						modelField: 'ValManufact',
						valueChangeEvent: 'fieldChange:entit.manufact',
						id: 'ENTIT___ENTITMANUFACT',
						name: 'MANUFACT',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.MANUFACTURER50759),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITFOUNDED_: new fieldControlClass.DateControl({
						modelField: 'ValFounded',
						valueChangeEvent: 'fieldChange:entit.founded',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'ENTIT___ENTITFOUNDED_',
						name: 'FOUNDED',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.FOUNDED_IN54120),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___FACI1NAME____: new fieldControlClass.LookupControl({
						modelField: 'TableFaci1Name',
						valueChangeEvent: 'fieldChange:faci1.name',
						id: 'ENTIT___FACI1NAME____',
						name: 'NAME',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.FACILITY_NAME19514),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValFirstfacilitie',
							dependencyEvent: 'fieldChange:entit.firstfacilitie'
						},
						dependentFields: () => {
							return {
								set 'faci1.codfacil'(value) { vm.model.ValFirstfacilitie.updateValue(value) },
								set 'faci1.name'(value) { vm.model.TableFaci1Name.updateValue(value) },
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
					ENTIT___FACI2NAME____: new fieldControlClass.LookupControl({
						modelField: 'TableFaci2Name',
						valueChangeEvent: 'fieldChange:faci2.name',
						id: 'ENTIT___FACI2NAME____',
						name: 'NAME',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.FACILITY_NAME19514),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isFormulaBlocked: true,
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValLastfacilitie',
							dependencyEvent: 'fieldChange:entit.lastfacilitie'
						},
						dependentFields: () => {
							return {
								set 'faci2.codfacil'(value) { vm.model.ValLastfacilitie.updateValue(value) },
								set 'faci2.name'(value) { vm.model.TableFaci2Name.updateValue(value) },
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
					ENTIT___ENTITLANGUAGE: new fieldControlClass.StringControl({
						modelField: 'ValLanguage',
						valueChangeEvent: 'fieldChange:entit.language',
						id: 'ENTIT___ENTITLANGUAGE',
						name: 'LANGUAGE',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.LANGUAGE16872),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 2,
						labelId: 'label_ENTIT___ENTITLANGUAGE',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ENTIT___ENTITCURRENCY: new fieldControlClass.StringControl({
						modelField: 'ValCurrency',
						valueChangeEvent: 'fieldChange:entit.currency',
						id: 'ENTIT___ENTITCURRENCY',
						name: 'CURRENCY',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.CURRENCY13881),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 3,
						labelId: 'label_ENTIT___ENTITCURRENCY',
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
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Entit: {
						get ValBuilding() { return vm.model.ValBuilding.value },
						set ValBuilding(value) { vm.model.ValBuilding.updateValue(value) },
						get ValCarrier() { return vm.model.ValCarrier.value },
						set ValCarrier(value) { vm.model.ValCarrier.updateValue(value) },
						get ValContact() { return vm.model.ValContact.value },
						set ValContact(value) { vm.model.ValContact.updateValue(value) },
						get ValCounty() { return vm.model.ValCounty.value },
						set ValCounty(value) { vm.model.ValCounty.updateValue(value) },
						get ValCurrency() { return vm.model.ValCurrency.value },
						set ValCurrency(value) { vm.model.ValCurrency.updateValue(value) },
						get ValEmail() { return vm.model.ValEmail.value },
						set ValEmail(value) { vm.model.ValEmail.updateValue(value) },
						get ValFax() { return vm.model.ValFax.value },
						set ValFax(value) { vm.model.ValFax.updateValue(value) },
						get ValFirstfacilitie() { return vm.model.ValFirstfacilitie.value },
						set ValFirstfacilitie(value) { vm.model.ValFirstfacilitie.updateValue(value) },
						get ValFounded() { return vm.model.ValFounded.value },
						set ValFounded(value) { vm.model.ValFounded.updateValue(value) },
						get ValIban() { return vm.model.ValIban.value },
						set ValIban(value) { vm.model.ValIban.updateValue(value) },
						get ValInitials() { return vm.model.ValInitials.value },
						set ValInitials(value) { vm.model.ValInitials.updateValue(value) },
						get ValLanguage() { return vm.model.ValLanguage.value },
						set ValLanguage(value) { vm.model.ValLanguage.updateValue(value) },
						get ValLastfacilitie() { return vm.model.ValLastfacilitie.value },
						set ValLastfacilitie(value) { vm.model.ValLastfacilitie.updateValue(value) },
						get ValManufact() { return vm.model.ValManufact.value },
						set ValManufact(value) { vm.model.ValManufact.updateValue(value) },
						get ValName() { return vm.model.ValName.value },
						set ValName(value) { vm.model.ValName.updateValue(value) },
						get ValOwner() { return vm.model.ValOwner.value },
						set ValOwner(value) { vm.model.ValOwner.updateValue(value) },
						get ValPerson() { return vm.model.ValPerson.value },
						set ValPerson(value) { vm.model.ValPerson.updateValue(value) },
						get ValPhonenum() { return vm.model.ValPhonenum.value },
						set ValPhonenum(value) { vm.model.ValPhonenum.updateValue(value) },
						get ValPobox() { return vm.model.ValPobox.value },
						set ValPobox(value) { vm.model.ValPobox.updateValue(value) },
						get ValPostalco() { return vm.model.ValPostalco.value },
						set ValPostalco(value) { vm.model.ValPostalco.updateValue(value) },
						get ValRegistra() { return vm.model.ValRegistra.value },
						set ValRegistra(value) { vm.model.ValRegistra.updateValue(value) },
						get ValState() { return vm.model.ValState.value },
						set ValState(value) { vm.model.ValState.updateValue(value) },
						get ValStreet() { return vm.model.ValStreet.value },
						set ValStreet(value) { vm.model.ValStreet.updateValue(value) },
						get ValSupplier() { return vm.model.ValSupplier.value },
						set ValSupplier(value) { vm.model.ValSupplier.updateValue(value) },
						get ValTaxnumbe() { return vm.model.ValTaxnumbe.value },
						set ValTaxnumbe(value) { vm.model.ValTaxnumbe.updateValue(value) },
						get ValTelephon() { return vm.model.ValTelephon.value },
						set ValTelephon(value) { vm.model.ValTelephon.updateValue(value) },
						get ValTown() { return vm.model.ValTown.value },
						set ValTown(value) { vm.model.ValTown.updateValue(value) },
						get ValWebsite() { return vm.model.ValWebsite.value },
						set ValWebsite(value) { vm.model.ValWebsite.updateValue(value) },
					},
					Faci1: {
						get ValName() { return vm.model.TableFaci1Name.value },
						set ValName(value) { vm.model.TableFaci1Name.updateValue(value) },
					},
					Faci2: {
						get ValName() { return vm.model.TableFaci2Name.value },
						set ValName(value) { vm.model.TableFaci2Name.updateValue(value) },
					},
					keys: {
						/** The primary key of the ENTIT table */
						get entit() { return vm.model.ValCodentit },
						/** The foreign key to the FACI1 table */
						get faci1() { return vm.model.ValFirstfacilitie },
						/** The foreign key to the FACI2 table */
						get faci2() { return vm.model.ValLastfacilitie },
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
// USE /[MANUAL GQT FORM_CODEJS ENTIT]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS ENTIT]/
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
// USE /[MANUAL GQT FORM_LOADED_JS ENTIT]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS ENTIT]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS ENTIT]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS ENTIT]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS ENTIT]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS ENTIT]/
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
// USE /[MANUAL GQT AFTER_DEL_JS ENTIT]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS ENTIT]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS ENTIT]/
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
// USE /[MANUAL GQT DLGUPDT ENTIT]/
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
// USE /[MANUAL GQT CTRLUPD ENTIT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
		},

		watch: {
		}
	}
</script>
