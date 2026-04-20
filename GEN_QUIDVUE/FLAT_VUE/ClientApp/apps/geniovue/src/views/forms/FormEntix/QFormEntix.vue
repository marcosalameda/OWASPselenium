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
			data-key="ENTIX"
			:data-identifier="primaryKeyValue"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.ENTIX___PSEUDNOVOGR01.isVisible">
					<q-col v-if="controls.ENTIX___PSEUDNOVOGR01.isVisible">
						<q-group-box-container
							v-if="controls.ENTIX___PSEUDNOVOGR01.isVisible"
							v-bind="controls.ENTIX___PSEUDNOVOGR01"
							:id="getControlId(controls.ENTIX___PSEUDNOVOGR01)"
							:no-border="controls.ENTIX___PSEUDNOVOGR01.borderless">
							<!-- Start ENTIX___PSEUDNOVOGR01 -->
							<q-row v-if="controls.ENTIX___ENTITNAME____.isVisible">
								<q-col
									v-if="controls.ENTIX___ENTITNAME____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.ENTIX___ENTITNAME____.isVisible"
										class="i-text"
										v-bind="controls.ENTIX___ENTITNAME____.wrapperProps"
										:id="getControlId(controls.ENTIX___ENTITNAME____)"
										v-on="controls.ENTIX___ENTITNAME____.handlers"
										:loading="controls.ENTIX___ENTITNAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.ENTIX___ENTITNAME____.props"
											:id="getControlId(controls.ENTIX___ENTITNAME____)"
											@blur="onBlur(controls.ENTIX___ENTITNAME____, model.ValName.value)"
											@change="model.ValName.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.ENTIX___ENTITFOUNDED_.isVisible || controls.ENTIX___ENTITINITIALS.isVisible || controls.ENTIX___ENTITREGISTRA.isVisible || controls.ENTIX___ENTITTAXNUMBE.isVisible">
								<q-col
									v-if="controls.ENTIX___ENTITFOUNDED_.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.ENTIX___ENTITFOUNDED_.isVisible"
										class="i-text"
										v-bind="controls.ENTIX___ENTITFOUNDED_.wrapperProps"
										:id="getControlId(controls.ENTIX___ENTITFOUNDED_)"
										v-on="controls.ENTIX___ENTITFOUNDED_.handlers"
										:loading="controls.ENTIX___ENTITFOUNDED_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.ENTIX___ENTITFOUNDED_.isVisible"
											v-bind="controls.ENTIX___ENTITFOUNDED_.props"
											:id="getControlId(controls.ENTIX___ENTITFOUNDED_)"
											:model-value="model.ValFounded.value"
											@reset-icon-click="model.ValFounded.fnUpdateValue(model.ValFounded.originalValue ?? new Date())"
											@update:model-value="model.ValFounded.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.ENTIX___ENTITINITIALS.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.ENTIX___ENTITINITIALS.isVisible"
										class="i-text"
										v-bind="controls.ENTIX___ENTITINITIALS.wrapperProps"
										:id="getControlId(controls.ENTIX___ENTITINITIALS)"
										v-on="controls.ENTIX___ENTITINITIALS.handlers"
										:loading="controls.ENTIX___ENTITINITIALS.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.ENTIX___ENTITINITIALS.props"
											:id="getControlId(controls.ENTIX___ENTITINITIALS)"
											@blur="onBlur(controls.ENTIX___ENTITINITIALS, model.ValInitials.value)"
											@change="model.ValInitials.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.ENTIX___ENTITREGISTRA.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.ENTIX___ENTITREGISTRA.isVisible"
										class="i-text"
										v-bind="controls.ENTIX___ENTITREGISTRA.wrapperProps"
										:id="getControlId(controls.ENTIX___ENTITREGISTRA)"
										v-on="controls.ENTIX___ENTITREGISTRA.handlers"
										:loading="controls.ENTIX___ENTITREGISTRA.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.ENTIX___ENTITREGISTRA.props"
											:id="getControlId(controls.ENTIX___ENTITREGISTRA)"
											@blur="onBlur(controls.ENTIX___ENTITREGISTRA, model.ValRegistra.value)"
											@change="model.ValRegistra.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.ENTIX___ENTITTAXNUMBE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.ENTIX___ENTITTAXNUMBE.isVisible"
										class="i-text"
										v-bind="controls.ENTIX___ENTITTAXNUMBE.wrapperProps"
										:id="getControlId(controls.ENTIX___ENTITTAXNUMBE)"
										v-on="controls.ENTIX___ENTITTAXNUMBE.handlers"
										:loading="controls.ENTIX___ENTITTAXNUMBE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.ENTIX___ENTITTAXNUMBE.props"
											:id="getControlId(controls.ENTIX___ENTITTAXNUMBE)"
											@blur="onBlur(controls.ENTIX___ENTITTAXNUMBE, model.ValTaxnumbe.value)"
											@change="model.ValTaxnumbe.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.ENTIX___ENTITIBAN____.isVisible || controls.ENTIX___ENTITPHONENUM.isVisible">
								<q-col
									v-if="controls.ENTIX___ENTITIBAN____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.ENTIX___ENTITIBAN____.isVisible"
										class="i-text"
										v-bind="controls.ENTIX___ENTITIBAN____.wrapperProps"
										:id="getControlId(controls.ENTIX___ENTITIBAN____)"
										v-on="controls.ENTIX___ENTITIBAN____.handlers"
										:loading="controls.ENTIX___ENTITIBAN____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.ENTIX___ENTITIBAN____.props"
											:id="getControlId(controls.ENTIX___ENTITIBAN____)"
											@blur="onBlur(controls.ENTIX___ENTITIBAN____, model.ValIban.value)"
											@change="model.ValIban.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.ENTIX___ENTITPHONENUM.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.ENTIX___ENTITPHONENUM.isVisible"
										class="i-text"
										v-bind="controls.ENTIX___ENTITPHONENUM.wrapperProps"
										:id="getControlId(controls.ENTIX___ENTITPHONENUM)"
										v-on="controls.ENTIX___ENTITPHONENUM.handlers"
										:loading="controls.ENTIX___ENTITPHONENUM.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.ENTIX___ENTITPHONENUM.props"
											:id="getControlId(controls.ENTIX___ENTITPHONENUM)"
											@blur="onBlur(controls.ENTIX___ENTITPHONENUM, model.ValPhonenum.value)"
											@change="model.ValPhonenum.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.ENTIX___ENTITOWNER___.isVisible || controls.ENTIX___ENTITCARRIER_.isVisible || controls.ENTIX___ENTITSUPPLIER.isVisible || controls.ENTIX___ENTITMANUFACT.isVisible">
								<q-col
									v-if="controls.ENTIX___ENTITOWNER___.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.ENTIX___ENTITOWNER___.isVisible"
										class="i-text"
										v-bind="controls.ENTIX___ENTITOWNER___.wrapperProps"
										:id="getControlId(controls.ENTIX___ENTITOWNER___)"
										v-on="controls.ENTIX___ENTITOWNER___.handlers"
										:loading="controls.ENTIX___ENTITOWNER___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox
												v-if="controls.ENTIX___ENTITOWNER___.isVisible"
												v-bind="controls.ENTIX___ENTITOWNER___.props"
												:id="getControlId(controls.ENTIX___ENTITOWNER___)"
												v-on="controls.ENTIX___ENTITOWNER___.handlers" />
										</template>
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.ENTIX___ENTITCARRIER_.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.ENTIX___ENTITCARRIER_.isVisible"
										class="i-text"
										v-bind="controls.ENTIX___ENTITCARRIER_.wrapperProps"
										:id="getControlId(controls.ENTIX___ENTITCARRIER_)"
										v-on="controls.ENTIX___ENTITCARRIER_.handlers"
										:loading="controls.ENTIX___ENTITCARRIER_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox
												v-if="controls.ENTIX___ENTITCARRIER_.isVisible"
												v-bind="controls.ENTIX___ENTITCARRIER_.props"
												:id="getControlId(controls.ENTIX___ENTITCARRIER_)"
												v-on="controls.ENTIX___ENTITCARRIER_.handlers" />
										</template>
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.ENTIX___ENTITSUPPLIER.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.ENTIX___ENTITSUPPLIER.isVisible"
										class="i-text"
										v-bind="controls.ENTIX___ENTITSUPPLIER.wrapperProps"
										:id="getControlId(controls.ENTIX___ENTITSUPPLIER)"
										v-on="controls.ENTIX___ENTITSUPPLIER.handlers"
										:loading="controls.ENTIX___ENTITSUPPLIER.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox
												v-if="controls.ENTIX___ENTITSUPPLIER.isVisible"
												v-bind="controls.ENTIX___ENTITSUPPLIER.props"
												:id="getControlId(controls.ENTIX___ENTITSUPPLIER)"
												v-on="controls.ENTIX___ENTITSUPPLIER.handlers" />
										</template>
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.ENTIX___ENTITMANUFACT.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.ENTIX___ENTITMANUFACT.isVisible"
										class="i-text"
										v-bind="controls.ENTIX___ENTITMANUFACT.wrapperProps"
										:id="getControlId(controls.ENTIX___ENTITMANUFACT)"
										v-on="controls.ENTIX___ENTITMANUFACT.handlers"
										:loading="controls.ENTIX___ENTITMANUFACT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox
												v-if="controls.ENTIX___ENTITMANUFACT.isVisible"
												v-bind="controls.ENTIX___ENTITMANUFACT.props"
												:id="getControlId(controls.ENTIX___ENTITMANUFACT)"
												v-on="controls.ENTIX___ENTITMANUFACT.handlers" />
										</template>
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End ENTIX___PSEUDNOVOGR01 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.ENTIX___PSEUDNOVOGR05.isVisible || controls.ENTIX___PSEUDNOVOGR06.isVisible">
					<q-col
						v-if="controls.ENTIX___PSEUDNOVOGR05.isVisible"
						cols="auto">
						<q-accordion
							v-if="controls.ENTIX___PSEUDNOVOGR05.isVisible"
							:id="getControlId(controls.ENTIX___PSEUDNOVOGR05)"
							v-model="controls.ENTIX___PSEUDNOVOGR05.openChild">
							<!-- Start ENTIX___PSEUDNOVOGR05 -->
							<q-accordion-item
								v-if="controls.ENTIX___PSEUDNOVOGR02.isVisible"
								:id="getControlId(controls.ENTIX___PSEUDNOVOGR02) + '-container'"
								value="ENTIX___PSEUDNOVOGR02"
								:title="controls.ENTIX___PSEUDNOVOGR02.label">
								<!-- Start ENTIX___PSEUDNOVOGR02 -->
								<q-row v-if="controls.ENTIX___ENTITTELEPHON.isVisible || controls.ENTIX___ENTITFAX_____.isVisible">
									<q-col
										v-if="controls.ENTIX___ENTITTELEPHON.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.ENTIX___ENTITTELEPHON.isVisible"
											class="i-text"
											v-bind="controls.ENTIX___ENTITTELEPHON.wrapperProps"
											:id="getControlId(controls.ENTIX___ENTITTELEPHON)"
											v-on="controls.ENTIX___ENTITTELEPHON.handlers"
											:loading="controls.ENTIX___ENTITTELEPHON.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.ENTIX___ENTITTELEPHON.props"
												:id="getControlId(controls.ENTIX___ENTITTELEPHON)"
												@blur="onBlur(controls.ENTIX___ENTITTELEPHON, model.ValTelephon.value)"
												@change="model.ValTelephon.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-col>
									<q-col
										v-if="controls.ENTIX___ENTITFAX_____.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.ENTIX___ENTITFAX_____.isVisible"
											class="i-text"
											v-bind="controls.ENTIX___ENTITFAX_____.wrapperProps"
											:id="getControlId(controls.ENTIX___ENTITFAX_____)"
											v-on="controls.ENTIX___ENTITFAX_____.handlers"
											:loading="controls.ENTIX___ENTITFAX_____.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.ENTIX___ENTITFAX_____.props"
												:id="getControlId(controls.ENTIX___ENTITFAX_____)"
												@blur="onBlur(controls.ENTIX___ENTITFAX_____, model.ValFax.value)"
												@change="model.ValFax.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-col>
								</q-row>
								<q-row v-if="controls.ENTIX___ENTITEMAIL___.isVisible">
									<q-col
										v-if="controls.ENTIX___ENTITEMAIL___.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.ENTIX___ENTITEMAIL___.isVisible"
											class="i-text"
											v-bind="controls.ENTIX___ENTITEMAIL___.wrapperProps"
											:id="getControlId(controls.ENTIX___ENTITEMAIL___)"
											v-on="controls.ENTIX___ENTITEMAIL___.handlers"
											:loading="controls.ENTIX___ENTITEMAIL___.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.ENTIX___ENTITEMAIL___.props"
												:id="getControlId(controls.ENTIX___ENTITEMAIL___)"
												@blur="onBlur(controls.ENTIX___ENTITEMAIL___, model.ValEmail.value)"
												@change="model.ValEmail.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-col>
								</q-row>
								<q-row v-if="controls.ENTIX___ENTITWEBSITE_.isVisible">
									<q-col
										v-if="controls.ENTIX___ENTITWEBSITE_.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.ENTIX___ENTITWEBSITE_.isVisible"
											class="i-text"
											v-bind="controls.ENTIX___ENTITWEBSITE_.wrapperProps"
											:id="getControlId(controls.ENTIX___ENTITWEBSITE_)"
											v-on="controls.ENTIX___ENTITWEBSITE_.handlers"
											:loading="controls.ENTIX___ENTITWEBSITE_.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.ENTIX___ENTITWEBSITE_.props"
												:id="getControlId(controls.ENTIX___ENTITWEBSITE_)"
												@blur="onBlur(controls.ENTIX___ENTITWEBSITE_, model.ValWebsite.value)"
												@change="model.ValWebsite.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-col>
								</q-row>
								<q-row v-if="controls.ENTIX___ENTITPERSON__.isVisible">
									<q-col
										v-if="controls.ENTIX___ENTITPERSON__.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.ENTIX___ENTITPERSON__.isVisible"
											class="i-text"
											v-bind="controls.ENTIX___ENTITPERSON__.wrapperProps"
											:id="getControlId(controls.ENTIX___ENTITPERSON__)"
											v-on="controls.ENTIX___ENTITPERSON__.handlers"
											:loading="controls.ENTIX___ENTITPERSON__.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.ENTIX___ENTITPERSON__.props"
												:id="getControlId(controls.ENTIX___ENTITPERSON__)"
												@blur="onBlur(controls.ENTIX___ENTITPERSON__, model.ValPerson.value)"
												@change="model.ValPerson.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-col>
								</q-row>
								<q-row v-if="controls.ENTIX___ENTITCONTACT_.isVisible || controls.ENTIX___ENTITLANGUAGE.isVisible || controls.ENTIX___ENTITCURRENCY.isVisible">
									<q-col
										v-if="controls.ENTIX___ENTITCONTACT_.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.ENTIX___ENTITCONTACT_.isVisible"
											class="i-text"
											v-bind="controls.ENTIX___ENTITCONTACT_.wrapperProps"
											:id="getControlId(controls.ENTIX___ENTITCONTACT_)"
											v-on="controls.ENTIX___ENTITCONTACT_.handlers"
											:loading="controls.ENTIX___ENTITCONTACT_.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.ENTIX___ENTITCONTACT_.props"
												:id="getControlId(controls.ENTIX___ENTITCONTACT_)"
												@blur="onBlur(controls.ENTIX___ENTITCONTACT_, model.ValContact.value)"
												@change="model.ValContact.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-col>
									<q-col
										v-if="controls.ENTIX___ENTITLANGUAGE.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.ENTIX___ENTITLANGUAGE.isVisible"
											class="i-text"
											v-bind="controls.ENTIX___ENTITLANGUAGE.wrapperProps"
											:id="getControlId(controls.ENTIX___ENTITLANGUAGE)"
											v-on="controls.ENTIX___ENTITLANGUAGE.handlers"
											:loading="controls.ENTIX___ENTITLANGUAGE.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.ENTIX___ENTITLANGUAGE.props"
												:id="getControlId(controls.ENTIX___ENTITLANGUAGE)"
												@blur="onBlur(controls.ENTIX___ENTITLANGUAGE, model.ValLanguage.value)"
												@change="model.ValLanguage.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-col>
									<q-col
										v-if="controls.ENTIX___ENTITCURRENCY.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.ENTIX___ENTITCURRENCY.isVisible"
											class="i-text"
											v-bind="controls.ENTIX___ENTITCURRENCY.wrapperProps"
											:id="getControlId(controls.ENTIX___ENTITCURRENCY)"
											v-on="controls.ENTIX___ENTITCURRENCY.handlers"
											:loading="controls.ENTIX___ENTITCURRENCY.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.ENTIX___ENTITCURRENCY.props"
												:id="getControlId(controls.ENTIX___ENTITCURRENCY)"
												@blur="onBlur(controls.ENTIX___ENTITCURRENCY, model.ValCurrency.value)"
												@change="model.ValCurrency.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-col>
								</q-row>
								<!-- End ENTIX___PSEUDNOVOGR02 -->
							</q-accordion-item>
							<q-accordion-item
								v-if="controls.ENTIX___PSEUDNOVOGR03.isVisible"
								:id="getControlId(controls.ENTIX___PSEUDNOVOGR03) + '-container'"
								value="ENTIX___PSEUDNOVOGR03"
								:title="controls.ENTIX___PSEUDNOVOGR03.label">
								<!-- Start ENTIX___PSEUDNOVOGR03 -->
								<q-row v-if="controls.ENTIX___ENTITBUILDING.isVisible">
									<q-col
										v-if="controls.ENTIX___ENTITBUILDING.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.ENTIX___ENTITBUILDING.isVisible"
											class="i-text"
											v-bind="controls.ENTIX___ENTITBUILDING.wrapperProps"
											:id="getControlId(controls.ENTIX___ENTITBUILDING)"
											v-on="controls.ENTIX___ENTITBUILDING.handlers"
											:loading="controls.ENTIX___ENTITBUILDING.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.ENTIX___ENTITBUILDING.props"
												:id="getControlId(controls.ENTIX___ENTITBUILDING)"
												@blur="onBlur(controls.ENTIX___ENTITBUILDING, model.ValBuilding.value)"
												@change="model.ValBuilding.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-col>
								</q-row>
								<q-row v-if="controls.ENTIX___ENTITSTREET__.isVisible">
									<q-col
										v-if="controls.ENTIX___ENTITSTREET__.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.ENTIX___ENTITSTREET__.isVisible"
											class="i-text"
											v-bind="controls.ENTIX___ENTITSTREET__.wrapperProps"
											:id="getControlId(controls.ENTIX___ENTITSTREET__)"
											v-on="controls.ENTIX___ENTITSTREET__.handlers"
											:loading="controls.ENTIX___ENTITSTREET__.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.ENTIX___ENTITSTREET__.props"
												:id="getControlId(controls.ENTIX___ENTITSTREET__)"
												@blur="onBlur(controls.ENTIX___ENTITSTREET__, model.ValStreet.value)"
												@change="model.ValStreet.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-col>
								</q-row>
								<q-row v-if="controls.ENTIX___ENTITTOWN____.isVisible">
									<q-col
										v-if="controls.ENTIX___ENTITTOWN____.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.ENTIX___ENTITTOWN____.isVisible"
											class="i-text"
											v-bind="controls.ENTIX___ENTITTOWN____.wrapperProps"
											:id="getControlId(controls.ENTIX___ENTITTOWN____)"
											v-on="controls.ENTIX___ENTITTOWN____.handlers"
											:loading="controls.ENTIX___ENTITTOWN____.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.ENTIX___ENTITTOWN____.props"
												:id="getControlId(controls.ENTIX___ENTITTOWN____)"
												@blur="onBlur(controls.ENTIX___ENTITTOWN____, model.ValTown.value)"
												@change="model.ValTown.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-col>
								</q-row>
								<q-row v-if="controls.ENTIX___ENTITCOUNTY__.isVisible">
									<q-col
										v-if="controls.ENTIX___ENTITCOUNTY__.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.ENTIX___ENTITCOUNTY__.isVisible"
											class="i-text"
											v-bind="controls.ENTIX___ENTITCOUNTY__.wrapperProps"
											:id="getControlId(controls.ENTIX___ENTITCOUNTY__)"
											v-on="controls.ENTIX___ENTITCOUNTY__.handlers"
											:loading="controls.ENTIX___ENTITCOUNTY__.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.ENTIX___ENTITCOUNTY__.props"
												:id="getControlId(controls.ENTIX___ENTITCOUNTY__)"
												@blur="onBlur(controls.ENTIX___ENTITCOUNTY__, model.ValCounty.value)"
												@change="model.ValCounty.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-col>
								</q-row>
								<q-row v-if="controls.ENTIX___ENTITSTATE___.isVisible">
									<q-col
										v-if="controls.ENTIX___ENTITSTATE___.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.ENTIX___ENTITSTATE___.isVisible"
											class="i-text"
											v-bind="controls.ENTIX___ENTITSTATE___.wrapperProps"
											:id="getControlId(controls.ENTIX___ENTITSTATE___)"
											v-on="controls.ENTIX___ENTITSTATE___.handlers"
											:loading="controls.ENTIX___ENTITSTATE___.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.ENTIX___ENTITSTATE___.props"
												:id="getControlId(controls.ENTIX___ENTITSTATE___)"
												@blur="onBlur(controls.ENTIX___ENTITSTATE___, model.ValState.value)"
												@change="model.ValState.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-col>
								</q-row>
								<q-row v-if="controls.ENTIX___ENTITPOSTALCO.isVisible">
									<q-col
										v-if="controls.ENTIX___ENTITPOSTALCO.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.ENTIX___ENTITPOSTALCO.isVisible"
											class="i-text"
											v-bind="controls.ENTIX___ENTITPOSTALCO.wrapperProps"
											:id="getControlId(controls.ENTIX___ENTITPOSTALCO)"
											v-on="controls.ENTIX___ENTITPOSTALCO.handlers"
											:loading="controls.ENTIX___ENTITPOSTALCO.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.ENTIX___ENTITPOSTALCO.props"
												:id="getControlId(controls.ENTIX___ENTITPOSTALCO)"
												@blur="onBlur(controls.ENTIX___ENTITPOSTALCO, model.ValPostalco.value)"
												@change="model.ValPostalco.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-col>
								</q-row>
								<q-row v-if="controls.ENTIX___ENTITPOBOX___.isVisible">
									<q-col
										v-if="controls.ENTIX___ENTITPOBOX___.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.ENTIX___ENTITPOBOX___.isVisible"
											class="i-text"
											v-bind="controls.ENTIX___ENTITPOBOX___.wrapperProps"
											:id="getControlId(controls.ENTIX___ENTITPOBOX___)"
											v-on="controls.ENTIX___ENTITPOBOX___.handlers"
											:loading="controls.ENTIX___ENTITPOBOX___.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.ENTIX___ENTITPOBOX___.props"
												:id="getControlId(controls.ENTIX___ENTITPOBOX___)"
												@blur="onBlur(controls.ENTIX___ENTITPOBOX___, model.ValPobox.value)"
												@change="model.ValPobox.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-col>
								</q-row>
								<!-- End ENTIX___PSEUDNOVOGR03 -->
							</q-accordion-item>
							<q-accordion-item
								v-if="controls.ENTIX___PSEUDNOVOGR04.isVisible"
								:id="getControlId(controls.ENTIX___PSEUDNOVOGR04) + '-container'"
								value="ENTIX___PSEUDNOVOGR04"
								:title="controls.ENTIX___PSEUDNOVOGR04.label">
								<!-- Start ENTIX___PSEUDNOVOGR04 -->
								<q-row v-if="controls.ENTIX___FACI1NAME____.isVisible || controls.ENTIX___FACI2NAME____.isVisible">
									<q-col
										v-if="controls.ENTIX___FACI1NAME____.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.ENTIX___FACI1NAME____.isVisible"
											class="i-text"
											v-bind="controls.ENTIX___FACI1NAME____.wrapperProps"
											:id="getControlId(controls.ENTIX___FACI1NAME____)"
											v-on="controls.ENTIX___FACI1NAME____.handlers"
											:loading="controls.ENTIX___FACI1NAME____.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-lookup
												v-if="controls.ENTIX___FACI1NAME____.isVisible"
												v-bind="controls.ENTIX___FACI1NAME____.props"
												:id="getControlId(controls.ENTIX___FACI1NAME____)"
												v-on="controls.ENTIX___FACI1NAME____.handlers" />
										</base-input-structure>
									</q-col>
									<q-col
										v-if="controls.ENTIX___FACI2NAME____.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.ENTIX___FACI2NAME____.isVisible"
											class="i-text"
											v-bind="controls.ENTIX___FACI2NAME____.wrapperProps"
											:id="getControlId(controls.ENTIX___FACI2NAME____)"
											v-on="controls.ENTIX___FACI2NAME____.handlers"
											:loading="controls.ENTIX___FACI2NAME____.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-lookup
												v-if="controls.ENTIX___FACI2NAME____.isVisible"
												v-bind="controls.ENTIX___FACI2NAME____.props"
												:id="getControlId(controls.ENTIX___FACI2NAME____)"
												v-on="controls.ENTIX___FACI2NAME____.handlers" />
										</base-input-structure>
									</q-col>
								</q-row>
								<!-- End ENTIX___PSEUDNOVOGR04 -->
							</q-accordion-item>
							<!-- End ENTIX___PSEUDNOVOGR05 -->
						</q-accordion>
					</q-col>
					<q-col
						v-if="controls.ENTIX___PSEUDNOVOGR06.isVisible"
						cols="auto">
						<q-group-box-container
							v-if="controls.ENTIX___PSEUDNOVOGR06.isVisible"
							v-bind="controls.ENTIX___PSEUDNOVOGR06"
							:id="getControlId(controls.ENTIX___PSEUDNOVOGR06)"
							:no-border="controls.ENTIX___PSEUDNOVOGR06.borderless">
							<!-- Start ENTIX___PSEUDNOVOGR06 -->
							<q-row v-if="controls.ENTIX___PSEUDFACILITE.isVisible">
								<q-col
									v-if="controls.ENTIX___PSEUDFACILITE.isVisible"
									cols="auto">
									<q-table
										v-if="controls.ENTIX___PSEUDFACILITE.isVisible"
										v-bind="controls.ENTIX___PSEUDFACILITE"
										:id="getControlId(controls.ENTIX___PSEUDFACILITE)"
										v-on="controls.ENTIX___PSEUDFACILITE.handlers">
										<template #header>
											<q-table-config
												:table-ctrl="controls.ENTIX___PSEUDFACILITE"
												v-on="controls.ENTIX___PSEUDFACILITE.handlers" />
										</template>
										<!-- USE /[MANUAL GQT CUSTOM_TABLE ENTIX___PSEUDFACILITE]/ -->
									</q-table>
								</q-col>
							</q-row>
							<!-- End ENTIX___PSEUDNOVOGR06 -->
						</q-group-box-container>
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

	import FormViewModel from './QFormEntixViewModel.js'

	const requiredTextResources = ['QFormEntix', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS ENTIX]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormEntix',

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
					name: 'ENTIX',
					location: 'form-ENTIX',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormEntix', false),

				interfaceMetadata: {
					id: 'QFormEntix', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'ENTIX',
					route: 'form-ENTIX',
					area: 'ENTIT',
					primaryKey: 'ValCodentit',
					designation: computed(() => this.Resources.ENTITY62049),
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
						text: computed(() => vm.Resources.INSERIR43365),
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
					ENTIX___PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'ENTIX___PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						label: computed(() => this.Resources.COMPANY_IDENTIFICATI44986),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						borderless: false,
						isCollapsible: false,
						anchored: false,
						directChildren: ['ENTIX___ENTITNAME____', 'ENTIX___ENTITFOUNDED_', 'ENTIX___ENTITINITIALS', 'ENTIX___ENTITREGISTRA', 'ENTIX___ENTITTAXNUMBE', 'ENTIX___ENTITIBAN____', 'ENTIX___ENTITPHONENUM', 'ENTIX___ENTITOWNER___', 'ENTIX___ENTITCARRIER_', 'ENTIX___ENTITSUPPLIER', 'ENTIX___ENTITMANUFACT'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITNAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:entit.name',
						id: 'ENTIX___ENTITNAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.LEGAL_NAME42902),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR01',
						maxLength: 85,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITFOUNDED_: new fieldControlClass.DateControl({
						modelField: 'ValFounded',
						valueChangeEvent: 'fieldChange:entit.founded',
						id: 'ENTIX___ENTITFOUNDED_',
						name: 'FOUNDED',
						size: 'small',
						label: computed(() => this.Resources.FOUNDED_IN54120),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR01',
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITINITIALS: new fieldControlClass.StringControl({
						modelField: 'ValInitials',
						valueChangeEvent: 'fieldChange:entit.initials',
						id: 'ENTIX___ENTITINITIALS',
						name: 'INITIALS',
						size: 'small',
						label: computed(() => this.Resources.COMPANY_INITIALS56204),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR01',
						maxLength: 10,
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITREGISTRA: new fieldControlClass.StringControl({
						modelField: 'ValRegistra',
						valueChangeEvent: 'fieldChange:entit.registra',
						id: 'ENTIX___ENTITREGISTRA',
						name: 'REGISTRA',
						size: 'medium',
						label: computed(() => this.Resources.LEGAL_REGISTRATION04413),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR01',
						maxLength: 20,
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITTAXNUMBE: new fieldControlClass.StringControl({
						modelField: 'ValTaxnumbe',
						valueChangeEvent: 'fieldChange:entit.taxnumbe',
						id: 'ENTIX___ENTITTAXNUMBE',
						name: 'TAXNUMBE',
						size: 'medium',
						label: computed(() => this.Resources.VAT_NUMBER24236),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR01',
						maxLength: 20,
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITIBAN____: new fieldControlClass.StringControl({
						modelField: 'ValIban',
						valueChangeEvent: 'fieldChange:entit.iban',
						id: 'ENTIX___ENTITIBAN____',
						name: 'IBAN',
						size: 'large',
						label: computed(() => this.Resources.IBAN__INTERNATIONAL_45066),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR01',
						maxLength: 25,
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITPHONENUM: new fieldControlClass.StringControl({
						modelField: 'ValPhonenum',
						valueChangeEvent: 'fieldChange:entit.phonenum',
						id: 'ENTIX___ENTITPHONENUM',
						name: 'PHONENUM',
						size: 'medium',
						label: computed(() => this.Resources.PHONE_NUMBER20774),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR01',
						maxLength: 20,
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITOWNER___: new fieldControlClass.BooleanControl({
						modelField: 'ValOwner',
						valueChangeEvent: 'fieldChange:entit.owner',
						id: 'ENTIX___ENTITOWNER___',
						name: 'OWNER',
						size: 'mini',
						label: computed(() => this.Resources.OWNER09558),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'ENTIX___PSEUDNOVOGR01',
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITCARRIER_: new fieldControlClass.BooleanControl({
						modelField: 'ValCarrier',
						valueChangeEvent: 'fieldChange:entit.carrier',
						id: 'ENTIX___ENTITCARRIER_',
						name: 'CARRIER',
						size: 'mini',
						label: computed(() => this.Resources.CARRIER64855),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'ENTIX___PSEUDNOVOGR01',
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITSUPPLIER: new fieldControlClass.BooleanControl({
						modelField: 'ValSupplier',
						valueChangeEvent: 'fieldChange:entit.supplier',
						id: 'ENTIX___ENTITSUPPLIER',
						name: 'SUPPLIER',
						size: 'small',
						label: computed(() => this.Resources.SUPPLIER17230),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'ENTIX___PSEUDNOVOGR01',
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITMANUFACT: new fieldControlClass.BooleanControl({
						modelField: 'ValManufact',
						valueChangeEvent: 'fieldChange:entit.manufact',
						id: 'ENTIX___ENTITMANUFACT',
						name: 'MANUFACT',
						size: 'small',
						label: computed(() => this.Resources.MANUFACTURER50759),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'ENTIX___PSEUDNOVOGR01',
						controlLimits: [
						],
					}, this),
					ENTIX___PSEUDNOVOGR05: new fieldControlClass.AccordionControl({
						id: 'ENTIX___PSEUDNOVOGR05',
						name: 'NOVOGR05',
						size: 'xxlarge',
						label: computed(() => this.Resources.ACCORDION01950),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['ENTIX___PSEUDNOVOGR02', 'ENTIX___PSEUDNOVOGR03', 'ENTIX___PSEUDNOVOGR04'],
						controlLimits: [
						],
					}, this),
					ENTIX___PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'ENTIX___PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'block',
						label: computed(() => this.Resources.CONTACT59247),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR05',
						isInAccordion: true,
						borderless: false,
						isCollapsible: true,
						anchored: false,
						directChildren: ['ENTIX___ENTITTELEPHON', 'ENTIX___ENTITFAX_____', 'ENTIX___ENTITEMAIL___', 'ENTIX___ENTITWEBSITE_', 'ENTIX___ENTITPERSON__', 'ENTIX___ENTITCONTACT_', 'ENTIX___ENTITLANGUAGE', 'ENTIX___ENTITCURRENCY'],
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITTELEPHON: new fieldControlClass.StringControl({
						modelField: 'ValTelephon',
						valueChangeEvent: 'fieldChange:entit.telephon',
						id: 'ENTIX___ENTITTELEPHON',
						name: 'TELEPHON',
						size: 'medium',
						label: computed(() => this.Resources.TELEPHONE28697),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR02',
						maxLength: 20,
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITFAX_____: new fieldControlClass.StringControl({
						modelField: 'ValFax',
						valueChangeEvent: 'fieldChange:entit.fax',
						id: 'ENTIX___ENTITFAX_____',
						name: 'FAX',
						size: 'medium',
						label: computed(() => this.Resources.FAX08532),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR02',
						maxLength: 20,
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITEMAIL___: new fieldControlClass.StringControl({
						modelField: 'ValEmail',
						valueChangeEvent: 'fieldChange:entit.email',
						id: 'ENTIX___ENTITEMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						label: computed(() => this.Resources.EMAIL25170),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR02',
						maxLength: 254,
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITWEBSITE_: new fieldControlClass.StringControl({
						modelField: 'ValWebsite',
						valueChangeEvent: 'fieldChange:entit.website',
						id: 'ENTIX___ENTITWEBSITE_',
						name: 'WEBSITE',
						size: 'xxlarge',
						label: computed(() => this.Resources.WEB_SITE06263),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR02',
						maxLength: 254,
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITPERSON__: new fieldControlClass.StringControl({
						modelField: 'ValPerson',
						valueChangeEvent: 'fieldChange:entit.person',
						id: 'ENTIX___ENTITPERSON__',
						name: 'PERSON',
						size: 'xxlarge',
						label: computed(() => this.Resources.PERSON_DEPARTMENT_TO28777),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR02',
						maxLength: 85,
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITCONTACT_: new fieldControlClass.StringControl({
						modelField: 'ValContact',
						valueChangeEvent: 'fieldChange:entit.contact',
						id: 'ENTIX___ENTITCONTACT_',
						name: 'CONTACT',
						size: 'medium',
						label: computed(() => this.Resources.CONTACT_TELEPHONE_NU12694),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR02',
						maxLength: 20,
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITLANGUAGE: new fieldControlClass.StringControl({
						modelField: 'ValLanguage',
						valueChangeEvent: 'fieldChange:entit.language',
						id: 'ENTIX___ENTITLANGUAGE',
						name: 'LANGUAGE',
						size: 'mini',
						label: computed(() => this.Resources.LANGUAGE16872),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR02',
						maxLength: 2,
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITCURRENCY: new fieldControlClass.StringControl({
						modelField: 'ValCurrency',
						valueChangeEvent: 'fieldChange:entit.currency',
						id: 'ENTIX___ENTITCURRENCY',
						name: 'CURRENCY',
						size: 'mini',
						label: computed(() => this.Resources.CURRENCY13881),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR02',
						maxLength: 3,
						controlLimits: [
						],
					}, this),
					ENTIX___PSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'ENTIX___PSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'block',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR05',
						isInAccordion: true,
						borderless: false,
						isCollapsible: true,
						anchored: false,
						directChildren: ['ENTIX___ENTITBUILDING', 'ENTIX___ENTITSTREET__', 'ENTIX___ENTITTOWN____', 'ENTIX___ENTITCOUNTY__', 'ENTIX___ENTITSTATE___', 'ENTIX___ENTITPOSTALCO', 'ENTIX___ENTITPOBOX___'],
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITBUILDING: new fieldControlClass.StringControl({
						modelField: 'ValBuilding',
						valueChangeEvent: 'fieldChange:entit.building',
						id: 'ENTIX___ENTITBUILDING',
						name: 'BUILDING',
						size: 'medium',
						label: computed(() => this.Resources.BUILDING_HOUSE_NUMBE20738),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR03',
						maxLength: 10,
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITSTREET__: new fieldControlClass.StringControl({
						modelField: 'ValStreet',
						valueChangeEvent: 'fieldChange:entit.street',
						id: 'ENTIX___ENTITSTREET__',
						name: 'STREET',
						size: 'xxlarge',
						label: computed(() => this.Resources.STREET44324),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR03',
						maxLength: 85,
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITTOWN____: new fieldControlClass.StringControl({
						modelField: 'ValTown',
						valueChangeEvent: 'fieldChange:entit.town',
						id: 'ENTIX___ENTITTOWN____',
						name: 'TOWN',
						size: 'xxlarge',
						label: computed(() => this.Resources.TOWN_CITY16259),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR03',
						maxLength: 85,
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITCOUNTY__: new fieldControlClass.StringControl({
						modelField: 'ValCounty',
						valueChangeEvent: 'fieldChange:entit.county',
						id: 'ENTIX___ENTITCOUNTY__',
						name: 'COUNTY',
						size: 'xxlarge',
						label: computed(() => this.Resources.COUNTY_PROVINCE34285),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR03',
						maxLength: 85,
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITSTATE___: new fieldControlClass.StringControl({
						modelField: 'ValState',
						valueChangeEvent: 'fieldChange:entit.state',
						id: 'ENTIX___ENTITSTATE___',
						name: 'STATE',
						size: 'xxlarge',
						label: computed(() => this.Resources.STATE_PROVINCE28516),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR03',
						maxLength: 85,
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITPOSTALCO: new fieldControlClass.StringControl({
						modelField: 'ValPostalco',
						valueChangeEvent: 'fieldChange:entit.postalco',
						id: 'ENTIX___ENTITPOSTALCO',
						name: 'POSTALCO',
						size: 'xlarge',
						label: computed(() => this.Resources.ZIP_POSTAL_CODE55613),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR03',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					ENTIX___ENTITPOBOX___: new fieldControlClass.StringControl({
						modelField: 'ValPobox',
						valueChangeEvent: 'fieldChange:entit.pobox',
						id: 'ENTIX___ENTITPOBOX___',
						name: 'POBOX',
						size: 'small',
						label: computed(() => this.Resources.POST_OFFICE_BOX06223),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR03',
						maxLength: 5,
						controlLimits: [
						],
					}, this),
					ENTIX___PSEUDNOVOGR04: new fieldControlClass.GroupControl({
						id: 'ENTIX___PSEUDNOVOGR04',
						name: 'NOVOGR04',
						size: 'block',
						label: computed(() => this.Resources.FACILITIES08876),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR05',
						isInAccordion: true,
						borderless: false,
						isCollapsible: true,
						anchored: false,
						directChildren: ['ENTIX___FACI1NAME____', 'ENTIX___FACI2NAME____'],
						controlLimits: [
						],
					}, this),
					ENTIX___FACI1NAME____: new fieldControlClass.LookupControl({
						modelField: 'TableFaci1Name',
						valueChangeEvent: 'fieldChange:faci1.name',
						id: 'ENTIX___FACI1NAME____',
						name: 'NAME',
						size: 'xlarge',
						label: computed(() => this.Resources.FACILITY_NAME19514),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR04',
						isFormulaBlocked: true,
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValFirstfacilitie',
							dependencyEvent: 'fieldChange:entit.firstfacilitie'
						},
						dependentFields: () => ({
							set 'faci1.codfacil'(value) { vm.model.ValFirstfacilitie.updateValue(value) },
							set 'faci1.name'(value) { vm.model.TableFaci1Name.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					ENTIX___FACI2NAME____: new fieldControlClass.LookupControl({
						modelField: 'TableFaci2Name',
						valueChangeEvent: 'fieldChange:faci2.name',
						id: 'ENTIX___FACI2NAME____',
						name: 'NAME',
						size: 'xlarge',
						label: computed(() => this.Resources.FACILITY_NAME19514),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR04',
						isFormulaBlocked: true,
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValLastfacilitie',
							dependencyEvent: 'fieldChange:entit.lastfacilitie'
						},
						dependentFields: () => ({
							set 'faci2.codfacil'(value) { vm.model.ValLastfacilitie.updateValue(value) },
							set 'faci2.name'(value) { vm.model.TableFaci2Name.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					ENTIX___PSEUDNOVOGR06: new fieldControlClass.GroupControl({
						id: 'ENTIX___PSEUDNOVOGR06',
						name: 'NOVOGR06',
						size: 'xxlarge',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						borderless: true,
						isCollapsible: false,
						anchored: false,
						directChildren: ['ENTIX___PSEUDFACILITE'],
						controlLimits: [
						],
					}, this),
					ENTIX___PSEUDFACILITE: new fieldControlClass.TableListControl({
						id: 'ENTIX___PSEUDFACILITE',
						name: 'FACILITE',
						size: 'xxlarge',
						label: computed(() => this.Resources.FACILITIES08876),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ENTIX___PSEUDNOVOGR06',
						headerLevel: computed(() => this.baseHeadingLevel + 1),
						controller: 'ENTIT',
						action: 'Entix_ValFacilite',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValIncorpor',
								area: 'FACIL',
								field: 'INCORPOR',
								label: computed(() => this.Resources.INCORPORATION10135),
								scrollData: 8,
								dateTimeType: 'date',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValName',
								area: 'FACIL',
								field: 'NAME',
								label: computed(() => this.Resources.FACILITY_NAME19514),
								dataLength: 85,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'Facty.ValType',
								area: 'FACTY',
								field: 'TYPE',
								label: computed(() => this.Resources.FACILITY_TYPE44577),
								dataLength: 25,
								scrollData: 25,
								export: 1,
								pkColumn: 'ValCodfacty',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 4,
								name: 'ValLatitude',
								area: 'FACIL',
								field: 'LATITUDE',
								label: computed(() => this.Resources.LATITUDE11291),
								scrollData: 10,
								maxDigits: 3,
								decimalPlaces: 6,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 5,
								name: 'ValLongitud',
								area: 'FACIL',
								field: 'LONGITUD',
								label: computed(() => this.Resources.LONGITUDE01015),
								scrollData: 10,
								maxDigits: 3,
								decimalPlaces: 6,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.GeographicColumn({
								order: 6,
								name: 'ValGeocoord',
								area: 'FACIL',
								field: 'GEOCOORD',
								label: computed(() => this.Resources.GEOGRAPHICAL_COORDIN45869),
								dataLength: 50,
								scrollData: 30,
								sortable: false,
								searchable: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 7,
								name: 'ValImage',
								area: 'FACIL',
								field: 'IMAGE',
								label: computed(() => this.Resources.IMAGE65174),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.IMAGE65174)),
								scrollData: 3,
								sortable: false,
								searchable: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValFacilite',
							serverMode: true,
							pkColumn: 'ValCodfacil',
							tableAlias: 'FACIL',
							tableNamePlural: computed(() => this.Resources.FACILITIES08876),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.FACILITIES08876),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: false
							},
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
										formName: 'FACILFEX',
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
										formName: 'FACILFEX',
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
										formName: 'FACILFEX',
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
										formName: 'FACILFEX',
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
									icon: { icon: 'add' },
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'FACILFEX',
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
								id: 'RCA__FACILFEX',
								name: '_FACILFEX',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'FACILFEX',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'FACILFEX': {
									fnKeySelector: (row) => row.Fields.ValCodfacil,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValName',
							defaultSearchColumnNameOriginal: 'ValName',
							defaultColumnSorting: {
								columnName: 'ValIncorpor',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-FACTY', 'changed-FACIL', 'changed-ENTIT'],
						uuid: 'Entix_ValFacilite',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'entit'],
								dependencyEvents: ['fieldChange:entit.codentit'],
								dependencyField: 'ENTIT.CODENTIT',
								fnValueSelector: (model) => model.ValCodentit.value
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
					'ENTIX___PSEUDNOVOGR01',
					'ENTIX___PSEUDNOVOGR05',
					'ENTIX___PSEUDNOVOGR02',
					'ENTIX___PSEUDNOVOGR03',
					'ENTIX___PSEUDNOVOGR04',
					'ENTIX___PSEUDNOVOGR06',
				]),

				tableFields: readonly([
					'ENTIX___PSEUDFACILITE',
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
// USE /[MANUAL GQT FORM_CODEJS ENTIX]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT ENTIX]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS ENTIX]/
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
// USE /[MANUAL GQT FORM_LOADED_JS ENTIX]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS ENTIX]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS ENTIX]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS ENTIX]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS ENTIX]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS ENTIX]/
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
// USE /[MANUAL GQT AFTER_DEL_JS ENTIX]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS ENTIX]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS ENTIX]/
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
// USE /[MANUAL GQT DLGUPDT ENTIX]/
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
// USE /[MANUAL GQT CTRLBLR ENTIX]/
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
// USE /[MANUAL GQT CTRLUPD ENTIX]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS ENTIX]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
