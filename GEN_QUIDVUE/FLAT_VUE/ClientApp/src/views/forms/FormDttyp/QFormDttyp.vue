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
			data-key="DTTYP"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container
					v-show="controls.DTTYP___PSEUDNOVOGR06.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.DTTYP___PSEUDNOVOGR06.isVisible"
						class="row-line-group">
						<q-accordion-container
							id="DTTYP___PSEUDNOVOGR06"
							v-bind="controls.DTTYP___PSEUDNOVOGR06"
							v-on="controls.DTTYP___PSEUDNOVOGR06.handlers"
							v-slot="{ onStateChanged }">
							<!-- Start DTTYP___PSEUDNOVOGR06 -->
							<q-group-collapsible
								v-bind="controls.DTTYP___PSEUDNOVOGR01"
								v-on="controls.DTTYP___PSEUDNOVOGR01.handlers"
								@state-changed="(state, groupId) => onStateChanged(state, groupId)">
								<!-- Start DTTYP___PSEUDNOVOGR01 -->
								<q-row-container v-show="controls.DTTYP___DTTYPSTRING__.isVisible">
									<q-control-wrapper
										v-show="controls.DTTYP___DTTYPSTRING__.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.DTTYP___DTTYPSTRING__"
											v-on="controls.DTTYP___DTTYPSTRING__.handlers"
											:loading="controls.DTTYP___DTTYPSTRING__.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-text-field
												v-bind="controls.DTTYP___DTTYPSTRING__.props"
												:model-value="model.ValString.value"
												@update:model-value="model.ValString.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.DTTYP___DTTYPUPPERCAS.isVisible">
									<q-control-wrapper
										v-show="controls.DTTYP___DTTYPUPPERCAS.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.DTTYP___DTTYPUPPERCAS"
											v-on="controls.DTTYP___DTTYPUPPERCAS.handlers"
											:loading="controls.DTTYP___DTTYPUPPERCAS.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-mask
												v-if="controls.DTTYP___DTTYPUPPERCAS.isVisible"
												v-bind="controls.DTTYP___DTTYPUPPERCAS"
												:model-value="model.ValUppercas.value"
												@update:model-value="model.ValUppercas.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.DTTYP___DTTYPUUID____.isVisible">
									<q-control-wrapper
										v-show="controls.DTTYP___DTTYPUUID____.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.DTTYP___DTTYPUUID____"
											v-on="controls.DTTYP___DTTYPUUID____.handlers"
											:loading="controls.DTTYP___DTTYPUUID____.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-text-field
												v-bind="controls.DTTYP___DTTYPUUID____.props"
												:model-value="model.ValUuid.value"
												@update:model-value="model.ValUuid.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.DTTYP___DTTYPMULTILIN.isVisible">
									<q-control-wrapper
										v-show="controls.DTTYP___DTTYPMULTILIN.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-textarea"
											v-bind="controls.DTTYP___DTTYPMULTILIN"
											v-on="controls.DTTYP___DTTYPMULTILIN.handlers"
											:loading="controls.DTTYP___DTTYPMULTILIN.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-textarea-input
												v-if="controls.DTTYP___DTTYPMULTILIN.isVisible"
												id="DTTYP___DTTYPMULTILIN"
												size="xxlarge"
												:model-value="model.ValMultilin.value"
												:rows="3"
												:cols="60"
												:is-required="controls.DTTYP___DTTYPMULTILIN.isRequired"
												:readonly="controls.DTTYP___DTTYPMULTILIN.readonly"
												:placeholder="controls.DTTYP___DTTYPMULTILIN.placeholder"
												@update:model-value="model.ValMultilin.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.DTTYP___DTTYPMULTILI3.isVisible">
									<q-control-wrapper
										v-show="controls.DTTYP___DTTYPMULTILI3.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.DTTYP___DTTYPMULTILI3"
											v-on="controls.DTTYP___DTTYPMULTILI3.handlers"
											:loading="controls.DTTYP___DTTYPMULTILI3.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-text-editor
												v-if="controls.DTTYP___DTTYPMULTILI3.isVisible"
												v-bind="controls.DTTYP___DTTYPMULTILI3"
												:model-value="model.ValMultili3.value"
												:rows="3"
												:cols="20"
												v-on="controls.DTTYP___DTTYPMULTILI3.handlers"
												@update:model-value="model.ValMultili3.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<!-- End DTTYP___PSEUDNOVOGR01 -->
							</q-group-collapsible>
							<q-group-collapsible
								v-bind="controls.DTTYP___PSEUDNOVOGR02"
								v-on="controls.DTTYP___PSEUDNOVOGR02.handlers"
								@state-changed="(state, groupId) => onStateChanged(state, groupId)">
								<!-- Start DTTYP___PSEUDNOVOGR02 -->
								<q-row-container v-show="controls.DTTYP___DTTYPBOOLEAN_.isVisible">
									<q-control-wrapper
										v-show="controls.DTTYP___DTTYPBOOLEAN_.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-checkbox"
											v-bind="controls.DTTYP___DTTYPBOOLEAN_"
											v-on="controls.DTTYP___DTTYPBOOLEAN_.handlers"
											:loading="controls.DTTYP___DTTYPBOOLEAN_.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<template #label>
												<q-checkbox-input
													v-if="controls.DTTYP___DTTYPBOOLEAN_.isVisible"
													id="DTTYP___DTTYPBOOLEAN_"
													size="large"
													:model-value="model.ValBoolean.value"
													:readonly="controls.DTTYP___DTTYPBOOLEAN_.readonly"
													@update:model-value="model.ValBoolean.fnUpdateValue" />
											</template>
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.DTTYP___DTTYPBOOLEAN2.isVisible">
									<q-control-wrapper
										v-show="controls.DTTYP___DTTYPBOOLEAN2.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-checkbox"
											v-bind="controls.DTTYP___DTTYPBOOLEAN2"
											v-on="controls.DTTYP___DTTYPBOOLEAN2.handlers"
											:loading="controls.DTTYP___DTTYPBOOLEAN2.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<template #label>
												<q-checkbox-input
													v-if="controls.DTTYP___DTTYPBOOLEAN2.isVisible"
													id="DTTYP___DTTYPBOOLEAN2"
													size="large"
													:model-value="model.ValBoolean2.value"
													:readonly="controls.DTTYP___DTTYPBOOLEAN2.readonly"
													@update:model-value="model.ValBoolean2.fnUpdateValue" />
											</template>
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<!-- End DTTYP___PSEUDNOVOGR02 -->
							</q-group-collapsible>
							<q-group-collapsible
								v-bind="controls.DTTYP___PSEUDNOVOGR03"
								v-on="controls.DTTYP___PSEUDNOVOGR03.handlers"
								@state-changed="(state, groupId) => onStateChanged(state, groupId)">
								<!-- Start DTTYP___PSEUDNOVOGR03 -->
								<q-row-container v-show="controls.DTTYP___DTTYPSMALLINT.isVisible">
									<q-control-wrapper
										v-show="controls.DTTYP___DTTYPSMALLINT.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.DTTYP___DTTYPSMALLINT"
											v-on="controls.DTTYP___DTTYPSMALLINT.handlers"
											:loading="controls.DTTYP___DTTYPSMALLINT.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-numeric-input
												v-if="controls.DTTYP___DTTYPSMALLINT.isVisible"
												v-bind="controls.DTTYP___DTTYPSMALLINT"
												:model-value="model.ValSmallint.value"
												@update:model-value="model.ValSmallint.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.DTTYP___DTTYPINTEGER_.isVisible">
									<q-control-wrapper
										v-show="controls.DTTYP___DTTYPINTEGER_.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.DTTYP___DTTYPINTEGER_"
											v-on="controls.DTTYP___DTTYPINTEGER_.handlers"
											:loading="controls.DTTYP___DTTYPINTEGER_.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-numeric-input
												v-if="controls.DTTYP___DTTYPINTEGER_.isVisible"
												v-bind="controls.DTTYP___DTTYPINTEGER_"
												:model-value="model.ValInteger.value"
												@update:model-value="model.ValInteger.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.DTTYP___DTTYPBIGINT__.isVisible">
									<q-control-wrapper
										v-show="controls.DTTYP___DTTYPBIGINT__.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.DTTYP___DTTYPBIGINT__"
											v-on="controls.DTTYP___DTTYPBIGINT__.handlers"
											:loading="controls.DTTYP___DTTYPBIGINT__.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-numeric-input
												v-if="controls.DTTYP___DTTYPBIGINT__.isVisible"
												v-bind="controls.DTTYP___DTTYPBIGINT__"
												:model-value="model.ValBigint.value"
												@update:model-value="model.ValBigint.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.DTTYP___DTTYPREAL____.isVisible">
									<q-control-wrapper
										v-show="controls.DTTYP___DTTYPREAL____.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.DTTYP___DTTYPREAL____"
											v-on="controls.DTTYP___DTTYPREAL____.handlers"
											:loading="controls.DTTYP___DTTYPREAL____.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-numeric-input
												v-if="controls.DTTYP___DTTYPREAL____.isVisible"
												v-bind="controls.DTTYP___DTTYPREAL____"
												:model-value="model.ValReal.value"
												@update:model-value="model.ValReal.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.DTTYP___DTTYPFLOAT___.isVisible">
									<q-control-wrapper
										v-show="controls.DTTYP___DTTYPFLOAT___.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.DTTYP___DTTYPFLOAT___"
											v-on="controls.DTTYP___DTTYPFLOAT___.handlers"
											:loading="controls.DTTYP___DTTYPFLOAT___.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-numeric-input
												v-if="controls.DTTYP___DTTYPFLOAT___.isVisible"
												v-bind="controls.DTTYP___DTTYPFLOAT___"
												:model-value="model.ValFloat.value"
												@update:model-value="model.ValFloat.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.DTTYP___DTTYPDECIMAL_.isVisible">
									<q-control-wrapper
										v-show="controls.DTTYP___DTTYPDECIMAL_.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.DTTYP___DTTYPDECIMAL_"
											v-on="controls.DTTYP___DTTYPDECIMAL_.handlers"
											:loading="controls.DTTYP___DTTYPDECIMAL_.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-numeric-input
												v-if="controls.DTTYP___DTTYPDECIMAL_.isVisible"
												v-bind="controls.DTTYP___DTTYPDECIMAL_"
												:model-value="model.ValDecimal.value"
												@update:model-value="model.ValDecimal.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.DTTYP___DTTYPDECIMAL9.isVisible">
									<q-control-wrapper
										v-show="controls.DTTYP___DTTYPDECIMAL9.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.DTTYP___DTTYPDECIMAL9"
											v-on="controls.DTTYP___DTTYPDECIMAL9.handlers"
											:loading="controls.DTTYP___DTTYPDECIMAL9.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-numeric-input
												v-if="controls.DTTYP___DTTYPDECIMAL9.isVisible"
												v-bind="controls.DTTYP___DTTYPDECIMAL9"
												:model-value="model.ValDecimal9.value"
												@update:model-value="model.ValDecimal9.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.DTTYP___DTTYPMONEY___.isVisible">
									<q-control-wrapper
										v-show="controls.DTTYP___DTTYPMONEY___.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.DTTYP___DTTYPMONEY___"
											v-on="controls.DTTYP___DTTYPMONEY___.handlers"
											:loading="controls.DTTYP___DTTYPMONEY___.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-numeric-input
												v-if="controls.DTTYP___DTTYPMONEY___.isVisible"
												v-bind="controls.DTTYP___DTTYPMONEY___"
												:model-value="model.ValMoney.value"
												@update:model-value="model.ValMoney.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.DTTYP___DTTYPMONEY9__.isVisible">
									<q-control-wrapper
										v-show="controls.DTTYP___DTTYPMONEY9__.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.DTTYP___DTTYPMONEY9__"
											v-on="controls.DTTYP___DTTYPMONEY9__.handlers"
											:loading="controls.DTTYP___DTTYPMONEY9__.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-numeric-input
												v-if="controls.DTTYP___DTTYPMONEY9__.isVisible"
												v-bind="controls.DTTYP___DTTYPMONEY9__"
												:model-value="model.ValMoney9.value"
												@update:model-value="model.ValMoney9.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<!-- End DTTYP___PSEUDNOVOGR03 -->
							</q-group-collapsible>
							<q-group-collapsible
								v-bind="controls.DTTYP___PSEUDNOVOGR04"
								v-on="controls.DTTYP___PSEUDNOVOGR04.handlers"
								@state-changed="(state, groupId) => onStateChanged(state, groupId)">
								<!-- Start DTTYP___PSEUDNOVOGR04 -->
								<q-row-container v-show="controls.DTTYP___DTTYPDATE____.isVisible">
									<q-control-wrapper
										v-show="controls.DTTYP___DTTYPDATE____.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.DTTYP___DTTYPDATE____"
											v-on="controls.DTTYP___DTTYPDATE____.handlers"
											:loading="controls.DTTYP___DTTYPDATE____.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-datetime-input
												v-if="controls.DTTYP___DTTYPDATE____.isVisible"
												v-bind="controls.DTTYP___DTTYPDATE____"
												format="Date"
												:model-value="model.ValDate.value"
												@update:model-value="model.ValDate.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.DTTYP___DTTYPDATETIME.isVisible">
									<q-control-wrapper
										v-show="controls.DTTYP___DTTYPDATETIME.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.DTTYP___DTTYPDATETIME"
											v-on="controls.DTTYP___DTTYPDATETIME.handlers"
											:loading="controls.DTTYP___DTTYPDATETIME.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-datetime-input
												v-if="controls.DTTYP___DTTYPDATETIME.isVisible"
												v-bind="controls.DTTYP___DTTYPDATETIME"
												format="DateTime"
												:model-value="model.ValDatetime.value"
												@update:model-value="model.ValDatetime.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.DTTYP___DTTYPDTSESOND.isVisible">
									<q-control-wrapper
										v-show="controls.DTTYP___DTTYPDTSESOND.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.DTTYP___DTTYPDTSESOND"
											v-on="controls.DTTYP___DTTYPDTSESOND.handlers"
											:loading="controls.DTTYP___DTTYPDTSESOND.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-datetime-input
												v-if="controls.DTTYP___DTTYPDTSESOND.isVisible"
												v-bind="controls.DTTYP___DTTYPDTSESOND"
												format="DateTimeSeconds"
												:model-value="model.ValDtsesond.value"
												@update:model-value="model.ValDtsesond.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.DTTYP___DTTYPTIME____.isVisible">
									<q-control-wrapper
										v-show="controls.DTTYP___DTTYPTIME____.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.DTTYP___DTTYPTIME____"
											v-on="controls.DTTYP___DTTYPTIME____.handlers"
											:loading="controls.DTTYP___DTTYPTIME____.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-datetime-input
												v-if="controls.DTTYP___DTTYPTIME____.isVisible"
												v-bind="controls.DTTYP___DTTYPTIME____"
												format="Time"
												:model-value="model.ValTime.value"
												@update:model-value="model.ValTime.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<!-- End DTTYP___PSEUDNOVOGR04 -->
							</q-group-collapsible>
							<q-group-collapsible
								v-bind="controls.DTTYP___PSEUDNOVOGR05"
								v-on="controls.DTTYP___PSEUDNOVOGR05.handlers"
								@state-changed="(state, groupId) => onStateChanged(state, groupId)">
								<!-- Start DTTYP___PSEUDNOVOGR05 -->
								<q-row-container v-show="controls.DTTYP___DTTYPIMAGE___.isVisible">
									<q-control-wrapper
										v-show="controls.DTTYP___DTTYPIMAGE___.isVisible"
										class="control-join-group">
										<base-input-structure
											class="q-image"
											v-bind="controls.DTTYP___DTTYPIMAGE___"
											v-on="controls.DTTYP___DTTYPIMAGE___.handlers"
											:loading="controls.DTTYP___DTTYPIMAGE___.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn"
											:help-style="layoutConfig.HelpStyle">
											<q-image
												v-if="controls.DTTYP___DTTYPIMAGE___.isVisible"
												v-bind="controls.DTTYP___DTTYPIMAGE___.props"
												v-on="controls.DTTYP___DTTYPIMAGE___.handlers" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<!-- End DTTYP___PSEUDNOVOGR05 -->
							</q-group-collapsible>
							<!-- End DTTYP___PSEUDNOVOGR06 -->
						</q-accordion-container>
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

	import FormViewModel from './QFormDttypViewModel.js'

	const requiredTextResources = ['QFormDttyp', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS DTTYP]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormDttyp',

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
						name: 'DTTYP',
						location: 'form-DTTYP',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormDttyp', false),

				interfaceMetadata: {
					id: 'QFormDttyp', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'DTTYP',
					route: 'form-DTTYP',
					area: 'DTTYP',
					primaryKey: 'ValCoddttyp',
					designation: computed(() => this.Resources.DATA_TYPE47159),
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
					DTTYP___PSEUDNOVOGR06: new fieldControlClass.AccordionControl({
						id: 'DTTYP___PSEUDNOVOGR06',
						name: 'NOVOGR06',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.ACCORDION01950),
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
					DTTYP___PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'DTTYP___PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.CHAR_STRING32451),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'DTTYP___PSEUDNOVOGR06',
						isCollapsible: true,
						anchored: false,
						openingEvent: 'opened-DTTYP___PSEUDNOVOGR01',
						isInAccordion: true,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___DTTYPSTRING__: new fieldControlClass.StringControl({
						modelField: 'ValString',
						valueChangeEvent: 'fieldChange:dttyp.string',
						id: 'DTTYP___DTTYPSTRING__',
						name: 'STRING',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.TEXT04938),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-DTTYP___PSEUDNOVOGR01',
						container: 'DTTYP___PSEUDNOVOGR01',
						maxLength: 50,
						labelId: 'label_DTTYP___DTTYPSTRING__',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___DTTYPUPPERCAS: new fieldControlClass.MaskControl({
						modelField: 'ValUppercas',
						valueChangeEvent: 'fieldChange:dttyp.uppercas',
						id: 'DTTYP___DTTYPUPPERCAS',
						name: 'UPPERCAS',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.TEXT__UPPER_CASE_62204),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-DTTYP___PSEUDNOVOGR01',
						container: 'DTTYP___PSEUDNOVOGR01',
						maxLength: 50,
						labelId: 'label_DTTYP___DTTYPUPPERCAS',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___DTTYPUUID____: new fieldControlClass.StringControl({
						modelField: 'ValUuid',
						valueChangeEvent: 'fieldChange:dttyp.uuid',
						id: 'DTTYP___DTTYPUUID____',
						name: 'UUID',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.TEXT__UUID_AKA_GUID_03442),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-DTTYP___PSEUDNOVOGR01',
						container: 'DTTYP___PSEUDNOVOGR01',
						maxLength: 36,
						labelId: 'label_DTTYP___DTTYPUUID____',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___DTTYPMULTILIN: new fieldControlClass.StringControl({
						modelField: 'ValMultilin',
						valueChangeEvent: 'fieldChange:dttyp.multilin',
						id: 'DTTYP___DTTYPMULTILIN',
						name: 'MULTILIN',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.MULTILINE_TEXT57254),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-DTTYP___PSEUDNOVOGR01',
						container: 'DTTYP___PSEUDNOVOGR01',
						maxLength: 60,
						labelId: 'label_DTTYP___DTTYPMULTILIN',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___DTTYPMULTILI3: new fieldControlClass.TextEditorControl({
						modelField: 'ValMultili3',
						valueChangeEvent: 'fieldChange:dttyp.multili3',
						id: 'DTTYP___DTTYPMULTILI3',
						name: 'MULTILI3',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.MULTILINE_TEXT__TEXT35132),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-DTTYP___PSEUDNOVOGR01',
						container: 'DTTYP___PSEUDNOVOGR01',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'DTTYP___PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.BOOLEAN45002),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'DTTYP___PSEUDNOVOGR06',
						isCollapsible: true,
						anchored: false,
						openingEvent: 'opened-DTTYP___PSEUDNOVOGR02',
						isInAccordion: true,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___DTTYPBOOLEAN_: new fieldControlClass.BooleanControl({
						modelField: 'ValBoolean',
						valueChangeEvent: 'fieldChange:dttyp.boolean',
						id: 'DTTYP___DTTYPBOOLEAN_',
						name: 'BOOLEAN',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.LOGICAL__TINYINT___S35014),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						parentOpeningEvent: 'opened-DTTYP___PSEUDNOVOGR02',
						container: 'DTTYP___PSEUDNOVOGR02',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___DTTYPBOOLEAN2: new fieldControlClass.BooleanControl({
						modelField: 'ValBoolean2',
						valueChangeEvent: 'fieldChange:dttyp.boolean2',
						id: 'DTTYP___DTTYPBOOLEAN2',
						name: 'BOOLEAN2',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.CONDITIONAL__SMALLIN41010),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						parentOpeningEvent: 'opened-DTTYP___PSEUDNOVOGR02',
						container: 'DTTYP___PSEUDNOVOGR02',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___PSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'DTTYP___PSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.NUMERIC19292),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'DTTYP___PSEUDNOVOGR06',
						isCollapsible: true,
						anchored: false,
						openingEvent: 'opened-DTTYP___PSEUDNOVOGR03',
						isInAccordion: true,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___DTTYPSMALLINT: new fieldControlClass.NumberControl({
						modelField: 'ValSmallint',
						valueChangeEvent: 'fieldChange:dttyp.smallint',
						maxIntegers: 4,
						maxDecimals: 0,
						id: 'DTTYP___DTTYPSMALLINT',
						name: 'SMALLINT',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.NUMERIC__4_0___SMALL21475),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.left),
						parentOpeningEvent: 'opened-DTTYP___PSEUDNOVOGR03',
						container: 'DTTYP___PSEUDNOVOGR03',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___DTTYPINTEGER_: new fieldControlClass.NumberControl({
						modelField: 'ValInteger',
						valueChangeEvent: 'fieldChange:dttyp.integer',
						maxIntegers: 9,
						maxDecimals: 0,
						id: 'DTTYP___DTTYPINTEGER_',
						name: 'INTEGER',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.NUMERIC__9_0___INTEG03994),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.left),
						parentOpeningEvent: 'opened-DTTYP___PSEUDNOVOGR03',
						container: 'DTTYP___PSEUDNOVOGR03',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___DTTYPBIGINT__: new fieldControlClass.NumberControl({
						modelField: 'ValBigint',
						valueChangeEvent: 'fieldChange:dttyp.bigint',
						maxIntegers: 15,
						maxDecimals: 0,
						id: 'DTTYP___DTTYPBIGINT__',
						name: 'BIGINT',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.NUMERIC_15_0___BIG_I46007),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.left),
						parentOpeningEvent: 'opened-DTTYP___PSEUDNOVOGR03',
						container: 'DTTYP___PSEUDNOVOGR03',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___DTTYPREAL____: new fieldControlClass.NumberControl({
						modelField: 'ValReal',
						valueChangeEvent: 'fieldChange:dttyp.real',
						maxIntegers: 5,
						maxDecimals: 2,
						id: 'DTTYP___DTTYPREAL____',
						name: 'REAL',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.NUMERIC__8_2_REAL_FL21391),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.left),
						parentOpeningEvent: 'opened-DTTYP___PSEUDNOVOGR03',
						container: 'DTTYP___PSEUDNOVOGR03',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___DTTYPFLOAT___: new fieldControlClass.NumberControl({
						modelField: 'ValFloat',
						valueChangeEvent: 'fieldChange:dttyp.float',
						maxIntegers: 12,
						maxDecimals: 2,
						id: 'DTTYP___DTTYPFLOAT___',
						name: 'FLOAT',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.NUMERIC_15_2_DOUBLE_11443),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.left),
						parentOpeningEvent: 'opened-DTTYP___PSEUDNOVOGR03',
						container: 'DTTYP___PSEUDNOVOGR03',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___DTTYPDECIMAL_: new fieldControlClass.NumberControl({
						modelField: 'ValDecimal',
						valueChangeEvent: 'fieldChange:dttyp.decimal',
						maxIntegers: 5,
						maxDecimals: 4,
						id: 'DTTYP___DTTYPDECIMAL_',
						name: 'DECIMAL',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.DECIMAL__1_10___STOR64402),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.left),
						parentOpeningEvent: 'opened-DTTYP___PSEUDNOVOGR03',
						container: 'DTTYP___PSEUDNOVOGR03',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___DTTYPDECIMAL9: new fieldControlClass.NumberControl({
						modelField: 'ValDecimal9',
						valueChangeEvent: 'fieldChange:dttyp.decimal9',
						maxIntegers: 10,
						maxDecimals: 4,
						id: 'DTTYP___DTTYPDECIMAL9',
						name: 'DECIMAL9',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.DECIMAL__11_15___STO64707),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.left),
						parentOpeningEvent: 'opened-DTTYP___PSEUDNOVOGR03',
						container: 'DTTYP___PSEUDNOVOGR03',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___DTTYPMONEY___: new fieldControlClass.CurrencyControl({
						modelField: 'ValMoney',
						valueChangeEvent: 'fieldChange:dttyp.money',
						maxIntegers: 5,
						maxDecimals: 4,
						id: 'DTTYP___DTTYPMONEY___',
						name: 'MONEY',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.MONEY___DECIMAL__1_124403),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.left),
						parentOpeningEvent: 'opened-DTTYP___PSEUDNOVOGR03',
						container: 'DTTYP___PSEUDNOVOGR03',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___DTTYPMONEY9__: new fieldControlClass.CurrencyControl({
						modelField: 'ValMoney9',
						valueChangeEvent: 'fieldChange:dttyp.money9',
						maxIntegers: 10,
						maxDecimals: 4,
						id: 'DTTYP___DTTYPMONEY9__',
						name: 'MONEY9',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.MONEY___DECIMAL__11_02101),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.left),
						parentOpeningEvent: 'opened-DTTYP___PSEUDNOVOGR03',
						container: 'DTTYP___PSEUDNOVOGR03',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___PSEUDNOVOGR04: new fieldControlClass.GroupControl({
						id: 'DTTYP___PSEUDNOVOGR04',
						name: 'NOVOGR04',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.DATE_AND_TIME38906),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'DTTYP___PSEUDNOVOGR06',
						isCollapsible: true,
						anchored: false,
						openingEvent: 'opened-DTTYP___PSEUDNOVOGR04',
						isInAccordion: true,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___DTTYPDATE____: new fieldControlClass.DateControl({
						modelField: 'ValDate',
						valueChangeEvent: 'fieldChange:dttyp.date',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'DTTYP___DTTYPDATE____',
						name: 'DATE',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.DATE18475),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.left),
						parentOpeningEvent: 'opened-DTTYP___PSEUDNOVOGR04',
						container: 'DTTYP___PSEUDNOVOGR04',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___DTTYPDATETIME: new fieldControlClass.DateControl({
						modelField: 'ValDatetime',
						valueChangeEvent: 'fieldChange:dttyp.datetime',
						id: 'DTTYP___DTTYPDATETIME',
						name: 'DATETIME',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.DATE_TIME53960),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.left),
						parentOpeningEvent: 'opened-DTTYP___PSEUDNOVOGR04',
						container: 'DTTYP___PSEUDNOVOGR04',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___DTTYPDTSESOND: new fieldControlClass.DateControl({
						modelField: 'ValDtsesond',
						valueChangeEvent: 'fieldChange:dttyp.dtsesond',
						id: 'DTTYP___DTTYPDTSESOND',
						name: 'DTSESOND',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.DATE_TIME_SECOND45106),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.left),
						parentOpeningEvent: 'opened-DTTYP___PSEUDNOVOGR04',
						container: 'DTTYP___PSEUDNOVOGR04',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___DTTYPTIME____: new fieldControlClass.TimeControl({
						modelField: 'ValTime',
						valueChangeEvent: 'fieldChange:dttyp.time',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'DTTYP___DTTYPTIME____',
						name: 'TIME',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.TIME15328),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.left),
						parentOpeningEvent: 'opened-DTTYP___PSEUDNOVOGR04',
						container: 'DTTYP___PSEUDNOVOGR04',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___PSEUDNOVOGR05: new fieldControlClass.GroupControl({
						id: 'DTTYP___PSEUDNOVOGR05',
						name: 'NOVOGR05',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.IMAGE65174),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'DTTYP___PSEUDNOVOGR06',
						isCollapsible: true,
						anchored: false,
						openingEvent: 'opened-DTTYP___PSEUDNOVOGR05',
						isInAccordion: true,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					DTTYP___DTTYPIMAGE___: new fieldControlClass.ImageControl({
						modelField: 'ValImage',
						valueChangeEvent: 'fieldChange:dttyp.image',
						id: 'DTTYP___DTTYPIMAGE___',
						name: 'IMAGE',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.IMAGE__BINARY_46903),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-DTTYP___PSEUDNOVOGR05',
						container: 'DTTYP___PSEUDNOVOGR05',
						height: 138,
						width: 115,
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
					'DTTYP___PSEUDNOVOGR06',
					'DTTYP___PSEUDNOVOGR01',
					'DTTYP___PSEUDNOVOGR02',
					'DTTYP___PSEUDNOVOGR03',
					'DTTYP___PSEUDNOVOGR04',
					'DTTYP___PSEUDNOVOGR05',
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Dttyp: {
						get ValBigint() { return vm.model.ValBigint.value },
						set ValBigint(value) { vm.model.ValBigint.updateValue(value) },
						get ValBoolean() { return vm.model.ValBoolean.value },
						set ValBoolean(value) { vm.model.ValBoolean.updateValue(value) },
						get ValBoolean2() { return vm.model.ValBoolean2.value },
						set ValBoolean2(value) { vm.model.ValBoolean2.updateValue(value) },
						get ValDate() { return vm.model.ValDate.value },
						set ValDate(value) { vm.model.ValDate.updateValue(value) },
						get ValDatetime() { return vm.model.ValDatetime.value },
						set ValDatetime(value) { vm.model.ValDatetime.updateValue(value) },
						get ValDecimal() { return vm.model.ValDecimal.value },
						set ValDecimal(value) { vm.model.ValDecimal.updateValue(value) },
						get ValDecimal9() { return vm.model.ValDecimal9.value },
						set ValDecimal9(value) { vm.model.ValDecimal9.updateValue(value) },
						get ValDtsesond() { return vm.model.ValDtsesond.value },
						set ValDtsesond(value) { vm.model.ValDtsesond.updateValue(value) },
						get ValFloat() { return vm.model.ValFloat.value },
						set ValFloat(value) { vm.model.ValFloat.updateValue(value) },
						get ValImage() { return vm.model.ValImage.value },
						set ValImage(value) { vm.model.ValImage.updateValue(value) },
						get ValInteger() { return vm.model.ValInteger.value },
						set ValInteger(value) { vm.model.ValInteger.updateValue(value) },
						get ValMoney() { return vm.model.ValMoney.value },
						set ValMoney(value) { vm.model.ValMoney.updateValue(value) },
						get ValMoney9() { return vm.model.ValMoney9.value },
						set ValMoney9(value) { vm.model.ValMoney9.updateValue(value) },
						get ValMultili3() { return vm.model.ValMultili3.value },
						set ValMultili3(value) { vm.model.ValMultili3.updateValue(value) },
						get ValMultilin() { return vm.model.ValMultilin.value },
						set ValMultilin(value) { vm.model.ValMultilin.updateValue(value) },
						get ValReal() { return vm.model.ValReal.value },
						set ValReal(value) { vm.model.ValReal.updateValue(value) },
						get ValSmallint() { return vm.model.ValSmallint.value },
						set ValSmallint(value) { vm.model.ValSmallint.updateValue(value) },
						get ValString() { return vm.model.ValString.value },
						set ValString(value) { vm.model.ValString.updateValue(value) },
						get ValTime() { return vm.model.ValTime.value },
						set ValTime(value) { vm.model.ValTime.updateValue(value) },
						get ValUppercas() { return vm.model.ValUppercas.value },
						set ValUppercas(value) { vm.model.ValUppercas.updateValue(value) },
						get ValUuid() { return vm.model.ValUuid.value },
						set ValUuid(value) { vm.model.ValUuid.updateValue(value) },
					},
					keys: {
						/** The primary key of the DTTYP table */
						get dttyp() { return vm.model.ValCoddttyp },
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
// USE /[MANUAL GQT FORM_CODEJS DTTYP]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS DTTYP]/
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
// USE /[MANUAL GQT FORM_LOADED_JS DTTYP]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS DTTYP]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS DTTYP]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS DTTYP]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS DTTYP]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS DTTYP]/
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
// USE /[MANUAL GQT AFTER_DEL_JS DTTYP]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS DTTYP]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS DTTYP]/
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
// USE /[MANUAL GQT DLGUPDT DTTYP]/
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
// USE /[MANUAL GQT CTRLUPD DTTYP]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
		},

		watch: {
			// Watchers for changes in the state of tabs and collapsible groups.
			'controls.DTTYP___PSEUDNOVOGR01.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'DTTYP___PSEUDNOVOGR01',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
			'controls.DTTYP___PSEUDNOVOGR02.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'DTTYP___PSEUDNOVOGR02',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
			'controls.DTTYP___PSEUDNOVOGR03.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'DTTYP___PSEUDNOVOGR03',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
			'controls.DTTYP___PSEUDNOVOGR04.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'DTTYP___PSEUDNOVOGR04',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
			'controls.DTTYP___PSEUDNOVOGR05.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'DTTYP___PSEUDNOVOGR05',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
		}
	}
</script>
