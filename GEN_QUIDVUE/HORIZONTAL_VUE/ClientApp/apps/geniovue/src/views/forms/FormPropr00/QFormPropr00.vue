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
			data-key="PROPR00"
			:data-identifier="primaryKeyValue"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.PROPR00_PSEUDNOVOGR04.isVisible">
					<q-col
						v-if="controls.PROPR00_PSEUDNOVOGR04.isVisible"
						cols="auto">
						<q-group-box-container
							v-if="controls.PROPR00_PSEUDNOVOGR04.isVisible"
							v-bind="controls.PROPR00_PSEUDNOVOGR04"
							:id="getControlId(controls.PROPR00_PSEUDNOVOGR04)"
							:no-border="controls.PROPR00_PSEUDNOVOGR04.borderless">
							<!-- Start PROPR00_PSEUDNOVOGR04 -->
							<q-row v-if="controls.PROPR00_PSEUDNOVOGR02.isVisible">
								<q-col v-if="controls.PROPR00_PSEUDNOVOGR02.isVisible">
									<q-group-box-container
										v-if="controls.PROPR00_PSEUDNOVOGR02.isVisible"
										v-bind="controls.PROPR00_PSEUDNOVOGR02"
										:id="getControlId(controls.PROPR00_PSEUDNOVOGR02)"
										:no-border="controls.PROPR00_PSEUDNOVOGR02.borderless">
										<!-- Start PROPR00_PSEUDNOVOGR02 -->
										<q-row v-if="controls.PROPR00_PROPRNAME____.isVisible || controls.PROPR00_PROPRPRECOEST.isVisible || controls.PROPR00_TPPROTPPROPRI.isVisible || controls.PROPR00_PROPRMOBILADA.isVisible">
											<q-col
												v-if="controls.PROPR00_PROPRNAME____.isVisible"
												cols="auto">
												<base-input-structure
													v-if="controls.PROPR00_PROPRNAME____.isVisible"
													class="i-text"
													v-bind="controls.PROPR00_PROPRNAME____.wrapperProps"
													:id="getControlId(controls.PROPR00_PROPRNAME____)"
													v-on="controls.PROPR00_PROPRNAME____.handlers"
													:loading="controls.PROPR00_PROPRNAME____.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-field
														v-bind="controls.PROPR00_PROPRNAME____.props"
														:id="getControlId(controls.PROPR00_PROPRNAME____)"
														@blur="onBlur(controls.PROPR00_PROPRNAME____, model.ValName.value)"
														@change="model.ValName.fnUpdateValueOnChange" />
												</base-input-structure>
											</q-col>
											<q-col
												v-if="controls.PROPR00_PROPRPRECOEST.isVisible || controls.PROPR00_TPPROTPPROPRI.isVisible"
												cols="auto">
												<base-input-structure
													v-if="controls.PROPR00_PROPRPRECOEST.isVisible"
													class="i-text"
													v-bind="controls.PROPR00_PROPRPRECOEST.wrapperProps"
													:id="getControlId(controls.PROPR00_PROPRPRECOEST)"
													v-on="controls.PROPR00_PROPRPRECOEST.handlers"
													:loading="controls.PROPR00_PROPRPRECOEST.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-numeric-input
														v-if="controls.PROPR00_PROPRPRECOEST.isVisible"
														v-bind="controls.PROPR00_PROPRPRECOEST.props"
														:id="getControlId(controls.PROPR00_PROPRPRECOEST)"
														@update:model-value="model.ValPrecoest.fnUpdateValue" />
												</base-input-structure>
												<base-input-structure
													v-if="controls.PROPR00_TPPROTPPROPRI.isVisible"
													class="i-text"
													v-bind="controls.PROPR00_TPPROTPPROPRI.wrapperProps"
													:id="getControlId(controls.PROPR00_TPPROTPPROPRI)"
													v-on="controls.PROPR00_TPPROTPPROPRI.handlers"
													:loading="controls.PROPR00_TPPROTPPROPRI.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-lookup
														v-if="controls.PROPR00_TPPROTPPROPRI.isVisible"
														v-bind="controls.PROPR00_TPPROTPPROPRI.props"
														:id="getControlId(controls.PROPR00_TPPROTPPROPRI)"
														v-on="controls.PROPR00_TPPROTPPROPRI.handlers" />
													<q-see-more-propr00-tpprotppropri
														v-if="controls.PROPR00_TPPROTPPROPRI.seeMoreIsVisible"
														v-bind="controls.PROPR00_TPPROTPPROPRI.seeMoreParams"
														v-on="controls.PROPR00_TPPROTPPROPRI.handlers" />
												</base-input-structure>
											</q-col>
											<q-col
												v-if="controls.PROPR00_PROPRMOBILADA.isVisible"
												cols="auto">
												<base-input-structure
													v-if="controls.PROPR00_PROPRMOBILADA.isVisible"
													class="i-text"
													v-bind="controls.PROPR00_PROPRMOBILADA.wrapperProps"
													:id="getControlId(controls.PROPR00_PROPRMOBILADA)"
													v-on="controls.PROPR00_PROPRMOBILADA.handlers"
													:loading="controls.PROPR00_PROPRMOBILADA.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<template #label>
														<q-checkbox
															v-if="controls.PROPR00_PROPRMOBILADA.isVisible"
															v-bind="controls.PROPR00_PROPRMOBILADA.props"
															:id="getControlId(controls.PROPR00_PROPRMOBILADA)"
															v-on="controls.PROPR00_PROPRMOBILADA.handlers" />
													</template>
												</base-input-structure>
											</q-col>
										</q-row>
										<!-- End PROPR00_PSEUDNOVOGR02 -->
									</q-group-box-container>
								</q-col>
							</q-row>
							<q-row v-if="controls.PROPR00_PESSONAME____.isVisible">
								<q-col
									v-if="controls.PROPR00_PESSONAME____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.PROPR00_PESSONAME____.isVisible"
										class="i-text"
										v-bind="controls.PROPR00_PESSONAME____.wrapperProps"
										:id="getControlId(controls.PROPR00_PESSONAME____)"
										v-on="controls.PROPR00_PESSONAME____.handlers"
										:loading="controls.PROPR00_PESSONAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.PROPR00_PESSONAME____.isVisible"
											v-bind="controls.PROPR00_PESSONAME____.props"
											:id="getControlId(controls.PROPR00_PESSONAME____)"
											v-on="controls.PROPR00_PESSONAME____.handlers" />
										<q-see-more-propr00-pessoname
											v-if="controls.PROPR00_PESSONAME____.seeMoreIsVisible"
											v-bind="controls.PROPR00_PESSONAME____.seeMoreParams"
											v-on="controls.PROPR00_PESSONAME____.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.PROPR00_PSEUDNOVOGR01.isVisible">
								<q-col v-if="controls.PROPR00_PSEUDNOVOGR01.isVisible">
									<q-group-box-container
										v-if="controls.PROPR00_PSEUDNOVOGR01.isVisible"
										v-bind="controls.PROPR00_PSEUDNOVOGR01"
										:id="getControlId(controls.PROPR00_PSEUDNOVOGR01)"
										:no-border="controls.PROPR00_PSEUDNOVOGR01.borderless">
										<!-- Start PROPR00_PSEUDNOVOGR01 -->
										<q-row v-if="controls.PROPR00_PROPRPHOTOGRA.isVisible">
											<q-col
												v-if="controls.PROPR00_PROPRPHOTOGRA.isVisible"
												cols="auto">
												<base-input-structure
													v-if="controls.PROPR00_PROPRPHOTOGRA.isVisible"
													class="q-image"
													v-bind="controls.PROPR00_PROPRPHOTOGRA.wrapperProps"
													:id="getControlId(controls.PROPR00_PROPRPHOTOGRA)"
													v-on="controls.PROPR00_PROPRPHOTOGRA.handlers"
													:loading="controls.PROPR00_PROPRPHOTOGRA.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-image
														v-if="controls.PROPR00_PROPRPHOTOGRA.isVisible"
														v-bind="controls.PROPR00_PROPRPHOTOGRA.props"
														:id="getControlId(controls.PROPR00_PROPRPHOTOGRA)"
														v-on="controls.PROPR00_PROPRPHOTOGRA.handlers" />
												</base-input-structure>
											</q-col>
										</q-row>
										<!-- End PROPR00_PSEUDNOVOGR01 -->
									</q-group-box-container>
								</q-col>
							</q-row>
							<!-- End PROPR00_PSEUDNOVOGR04 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.PROPR00_PSEUDPROPR02_.isVisible || controls.PROPR00_PSEUDPROPR01_.isVisible || controls.PROPR00_PSEUDPROPR03_.isVisible">
					<q-col
						v-if="controls.PROPR00_PSEUDPROPR02_.isVisible || controls.PROPR00_PSEUDPROPR01_.isVisible || controls.PROPR00_PSEUDPROPR03_.isVisible"
						cols="auto">
						<q-tab-container
							v-if="controls.formTabs.isVisible"
							:id="getId('q-tabs-PROPR00')"
							v-bind="controls.formTabs.props"
							@tab-changed="controls.formTabs.selectTab($event)">
							<section
								v-if="controls.PROPR00_PSEUDPROPR02_.isVisible"
								v-show="controls.formTabs.selectedTab === 'PROPR00_PSEUDPROPR02_'">
								<div
									id="PROPR00_PSEUDPROPR02_"
									role="tabpanel"
									aria-labelledby="q-tabs-PROPR00-tab-PROPR00_PSEUDPROPR02_">
									<q-row v-if="controls.PROPR02_PROPRQTD_WC__.isVisible || controls.PROPR02_PROPRQTDQUART.isVisible || controls.PROPR02_PROPRM2______.isVisible">
										<q-col
											v-if="controls.PROPR02_PROPRQTD_WC__.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.PROPR02_PROPRQTD_WC__.isVisible"
												class="i-text"
												v-bind="controls.PROPR02_PROPRQTD_WC__.wrapperProps"
												:id="getControlId(controls.PROPR02_PROPRQTD_WC__)"
												v-on="controls.PROPR02_PROPRQTD_WC__.handlers"
												:loading="controls.PROPR02_PROPRQTD_WC__.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-numeric-input
													v-if="controls.PROPR02_PROPRQTD_WC__.isVisible"
													v-bind="controls.PROPR02_PROPRQTD_WC__.props"
													:id="getControlId(controls.PROPR02_PROPRQTD_WC__)"
													@update:model-value="model.ValQtd_wc.fnUpdateValue" />
											</base-input-structure>
										</q-col>
										<q-col
											v-if="controls.PROPR02_PROPRQTDQUART.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.PROPR02_PROPRQTDQUART.isVisible"
												class="i-text"
												v-bind="controls.PROPR02_PROPRQTDQUART.wrapperProps"
												:id="getControlId(controls.PROPR02_PROPRQTDQUART)"
												v-on="controls.PROPR02_PROPRQTDQUART.handlers"
												:loading="controls.PROPR02_PROPRQTDQUART.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-numeric-input
													v-if="controls.PROPR02_PROPRQTDQUART.isVisible"
													v-bind="controls.PROPR02_PROPRQTDQUART.props"
													:id="getControlId(controls.PROPR02_PROPRQTDQUART)"
													@update:model-value="model.ValQtdquart.fnUpdateValue" />
											</base-input-structure>
										</q-col>
										<q-col
											v-if="controls.PROPR02_PROPRM2______.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.PROPR02_PROPRM2______.isVisible"
												class="i-text"
												v-bind="controls.PROPR02_PROPRM2______.wrapperProps"
												:id="getControlId(controls.PROPR02_PROPRM2______)"
												v-on="controls.PROPR02_PROPRM2______.handlers"
												:loading="controls.PROPR02_PROPRM2______.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-numeric-input
													v-if="controls.PROPR02_PROPRM2______.isVisible"
													v-bind="controls.PROPR02_PROPRM2______.props"
													:id="getControlId(controls.PROPR02_PROPRM2______)"
													@update:model-value="model.ValM2.fnUpdateValue" />
											</base-input-structure>
										</q-col>
									</q-row>
									<q-row v-if="controls.PROPR02_PROPRDTDISPON.isVisible">
										<q-col
											v-if="controls.PROPR02_PROPRDTDISPON.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.PROPR02_PROPRDTDISPON.isVisible"
												class="i-text"
												v-bind="controls.PROPR02_PROPRDTDISPON.wrapperProps"
												:id="getControlId(controls.PROPR02_PROPRDTDISPON)"
												v-on="controls.PROPR02_PROPRDTDISPON.handlers"
												:loading="controls.PROPR02_PROPRDTDISPON.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-date-time-picker
													v-if="controls.PROPR02_PROPRDTDISPON.isVisible"
													v-bind="controls.PROPR02_PROPRDTDISPON.props"
													:id="getControlId(controls.PROPR02_PROPRDTDISPON)"
													:model-value="model.ValDtdispon.value"
													@reset-icon-click="model.ValDtdispon.fnUpdateValue(model.ValDtdispon.originalValue ?? new Date())"
													@update:model-value="model.ValDtdispon.fnUpdateValue($event ?? '')" />
											</base-input-structure>
										</q-col>
									</q-row>
								</div>
							</section>
							<section
								v-if="controls.PROPR00_PSEUDPROPR01_.isVisible"
								v-show="controls.formTabs.selectedTab === 'PROPR00_PSEUDPROPR01_'">
								<div
									id="PROPR00_PSEUDPROPR01_"
									role="tabpanel"
									aria-labelledby="q-tabs-PROPR00-tab-PROPR00_PSEUDPROPR01_">
									<q-row v-if="controls.PROPR01_PSEUDNOVOGR01.isVisible">
										<q-col v-if="controls.PROPR01_PSEUDNOVOGR01.isVisible">
											<q-group-box-container
												v-if="controls.PROPR01_PSEUDNOVOGR01.isVisible"
												v-bind="controls.PROPR01_PSEUDNOVOGR01"
												:id="getControlId(controls.PROPR01_PSEUDNOVOGR01)"
												:no-border="controls.PROPR01_PSEUDNOVOGR01.borderless">
												<!-- Start PROPR01_PSEUDNOVOGR01 -->
												<q-row v-if="controls.PROPR01_PROPRENDERECO.isVisible || controls.PROPR01_PROPRLOCALIDA.isVisible">
													<q-col
														v-if="controls.PROPR01_PROPRENDERECO.isVisible"
														cols="auto">
														<base-input-structure
															v-if="controls.PROPR01_PROPRENDERECO.isVisible"
															class="i-textarea"
															v-bind="controls.PROPR01_PROPRENDERECO.wrapperProps"
															:id="getControlId(controls.PROPR01_PROPRENDERECO)"
															v-on="controls.PROPR01_PROPRENDERECO.handlers"
															:loading="controls.PROPR01_PROPRENDERECO.props.loading"
															:reporting-mode-on="reportingModeCAV"
															:suggestion-mode-on="suggestionModeOn">
															<q-text-area
																v-if="controls.PROPR01_PROPRENDERECO.isVisible"
																v-bind="controls.PROPR01_PROPRENDERECO.props"
																:id="getControlId(controls.PROPR01_PROPRENDERECO)"
																v-on="controls.PROPR01_PROPRENDERECO.handlers" />
														</base-input-structure>
													</q-col>
													<q-col
														v-if="controls.PROPR01_PROPRLOCALIDA.isVisible"
														cols="auto">
														<base-input-structure
															v-if="controls.PROPR01_PROPRLOCALIDA.isVisible"
															class="i-text"
															v-bind="controls.PROPR01_PROPRLOCALIDA.wrapperProps"
															:id="getControlId(controls.PROPR01_PROPRLOCALIDA)"
															v-on="controls.PROPR01_PROPRLOCALIDA.handlers"
															:loading="controls.PROPR01_PROPRLOCALIDA.props.loading"
															:reporting-mode-on="reportingModeCAV"
															:suggestion-mode-on="suggestionModeOn">
															<q-text-field
																v-bind="controls.PROPR01_PROPRLOCALIDA.props"
																:id="getControlId(controls.PROPR01_PROPRLOCALIDA)"
																@blur="onBlur(controls.PROPR01_PROPRLOCALIDA, model.ValLocalida.value)"
																@change="model.ValLocalida.fnUpdateValueOnChange" />
														</base-input-structure>
													</q-col>
												</q-row>
												<q-row v-if="controls.PROPR01_PROPRPOSTALCO.isVisible || controls.PROPR01_PROPRPOSTALLO.isVisible">
													<q-col
														v-if="controls.PROPR01_PROPRPOSTALCO.isVisible || controls.PROPR01_PROPRPOSTALLO.isVisible"
														cols="auto">
														<base-input-structure
															v-if="controls.PROPR01_PROPRPOSTALCO.isVisible"
															class="i-text"
															v-bind="controls.PROPR01_PROPRPOSTALCO.wrapperProps"
															:id="getControlId(controls.PROPR01_PROPRPOSTALCO)"
															v-on="controls.PROPR01_PROPRPOSTALCO.handlers"
															:loading="controls.PROPR01_PROPRPOSTALCO.props.loading"
															:reporting-mode-on="reportingModeCAV"
															:suggestion-mode-on="suggestionModeOn">
															<q-text-field
																v-bind="controls.PROPR01_PROPRPOSTALCO.props"
																:id="getControlId(controls.PROPR01_PROPRPOSTALCO)"
																@blur="onBlur(controls.PROPR01_PROPRPOSTALCO, model.ValPostalco.value)"
																@change="model.ValPostalco.fnUpdateValueOnChange" />
														</base-input-structure>
														<base-input-structure
															v-if="controls.PROPR01_PROPRPOSTALLO.isVisible"
															class="i-text"
															v-bind="controls.PROPR01_PROPRPOSTALLO.wrapperProps"
															:id="getControlId(controls.PROPR01_PROPRPOSTALLO)"
															v-on="controls.PROPR01_PROPRPOSTALLO.handlers"
															:loading="controls.PROPR01_PROPRPOSTALLO.props.loading"
															:reporting-mode-on="reportingModeCAV"
															:suggestion-mode-on="suggestionModeOn">
															<q-text-field
																v-bind="controls.PROPR01_PROPRPOSTALLO.props"
																:id="getControlId(controls.PROPR01_PROPRPOSTALLO)"
																@blur="onBlur(controls.PROPR01_PROPRPOSTALLO, model.ValPostallo.value)"
																@change="model.ValPostallo.fnUpdateValueOnChange" />
														</base-input-structure>
													</q-col>
												</q-row>
												<q-row v-if="controls.PROPR01_CNTRYCOUNTRY_.isVisible || controls.PROPR01_REGIOREGIAO__.isVisible">
													<q-col
														v-if="controls.PROPR01_CNTRYCOUNTRY_.isVisible"
														cols="auto">
														<base-input-structure
															v-if="controls.PROPR01_CNTRYCOUNTRY_.isVisible"
															class="i-text"
															v-bind="controls.PROPR01_CNTRYCOUNTRY_.wrapperProps"
															:id="getControlId(controls.PROPR01_CNTRYCOUNTRY_)"
															v-on="controls.PROPR01_CNTRYCOUNTRY_.handlers"
															:loading="controls.PROPR01_CNTRYCOUNTRY_.props.loading"
															:reporting-mode-on="reportingModeCAV"
															:suggestion-mode-on="suggestionModeOn">
															<q-lookup
																v-if="controls.PROPR01_CNTRYCOUNTRY_.isVisible"
																v-bind="controls.PROPR01_CNTRYCOUNTRY_.props"
																:id="getControlId(controls.PROPR01_CNTRYCOUNTRY_)"
																v-on="controls.PROPR01_CNTRYCOUNTRY_.handlers" />
															<q-see-more-propr01-cntrycountry
																v-if="controls.PROPR01_CNTRYCOUNTRY_.seeMoreIsVisible"
																v-bind="controls.PROPR01_CNTRYCOUNTRY_.seeMoreParams"
																v-on="controls.PROPR01_CNTRYCOUNTRY_.handlers" />
														</base-input-structure>
													</q-col>
													<q-col
														v-if="controls.PROPR01_REGIOREGIAO__.isVisible"
														cols="auto">
														<base-input-structure
															v-if="controls.PROPR01_REGIOREGIAO__.isVisible"
															class="i-text"
															v-bind="controls.PROPR01_REGIOREGIAO__.wrapperProps"
															:id="getControlId(controls.PROPR01_REGIOREGIAO__)"
															v-on="controls.PROPR01_REGIOREGIAO__.handlers"
															:loading="controls.PROPR01_REGIOREGIAO__.props.loading"
															:reporting-mode-on="reportingModeCAV"
															:suggestion-mode-on="suggestionModeOn">
															<q-lookup
																v-if="controls.PROPR01_REGIOREGIAO__.isVisible"
																v-bind="controls.PROPR01_REGIOREGIAO__.props"
																:id="getControlId(controls.PROPR01_REGIOREGIAO__)"
																v-on="controls.PROPR01_REGIOREGIAO__.handlers" />
															<q-see-more-propr01-regioregiao
																v-if="controls.PROPR01_REGIOREGIAO__.seeMoreIsVisible"
																v-bind="controls.PROPR01_REGIOREGIAO__.seeMoreParams"
																v-on="controls.PROPR01_REGIOREGIAO__.handlers" />
														</base-input-structure>
													</q-col>
												</q-row>
												<!-- End PROPR01_PSEUDNOVOGR01 -->
											</q-group-box-container>
										</q-col>
									</q-row>
									<q-row v-if="controls.PROPR01_PROPRCOORDGEO.isVisible">
										<q-col
											v-if="controls.PROPR01_PROPRCOORDGEO.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.PROPR01_PROPRCOORDGEO.isVisible"
												class="i-text"
												v-bind="controls.PROPR01_PROPRCOORDGEO.wrapperProps"
												:id="getControlId(controls.PROPR01_PROPRCOORDGEO)"
												v-on="controls.PROPR01_PROPRCOORDGEO.handlers"
												:loading="controls.PROPR01_PROPRCOORDGEO.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-text-field
													v-bind="controls.PROPR01_PROPRCOORDGEO.props"
													:id="getControlId(controls.PROPR01_PROPRCOORDGEO)"
													@blur="onBlur(controls.PROPR01_PROPRCOORDGEO, model.ValCoordgeo.value)"
													@change="model.ValCoordgeo.fnUpdateValueOnChange" />
											</base-input-structure>
										</q-col>
									</q-row>
								</div>
							</section>
							<section
								v-if="controls.PROPR00_PSEUDPROPR03_.isVisible"
								v-show="controls.formTabs.selectedTab === 'PROPR00_PSEUDPROPR03_'">
								<div
									id="PROPR00_PSEUDPROPR03_"
									role="tabpanel"
									aria-labelledby="q-tabs-PROPR00-tab-PROPR00_PSEUDPROPR03_">
									<q-row v-if="controls.PROPR03_PROPRDESCRIPT.isVisible">
										<q-col
											v-if="controls.PROPR03_PROPRDESCRIPT.isVisible"
											cols="auto">
											<base-input-structure
												v-if="controls.PROPR03_PROPRDESCRIPT.isVisible"
												class="i-text"
												v-bind="controls.PROPR03_PROPRDESCRIPT.wrapperProps"
												:id="getControlId(controls.PROPR03_PROPRDESCRIPT)"
												v-on="controls.PROPR03_PROPRDESCRIPT.handlers"
												:loading="controls.PROPR03_PROPRDESCRIPT.props.loading"
												:reporting-mode-on="reportingModeCAV"
												:suggestion-mode-on="suggestionModeOn">
												<q-text-editor
													v-if="controls.PROPR03_PROPRDESCRIPT.isVisible"
													v-bind="controls.PROPR03_PROPRDESCRIPT.props"
													:id="getControlId(controls.PROPR03_PROPRDESCRIPT)"
													v-on="controls.PROPR03_PROPRDESCRIPT.handlers" />
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
				default: () => ({
					name: 'PROPR00',
					location: 'form-PROPR00',
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
					PROPR00_PSEUDNOVOGR04: new fieldControlClass.GroupControl({
						id: 'PROPR00_PSEUDNOVOGR04',
						name: 'NOVOGR04',
						size: 'xxlarge',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						borderless: false,
						isCollapsible: false,
						anchored: false,
						directChildren: ['PROPR00_PSEUDNOVOGR02', 'PROPR00_PESSONAME____', 'PROPR00_PSEUDNOVOGR01'],
						controlLimits: [
						],
					}, this),
					PROPR00_PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'PROPR00_PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'block',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPR00_PSEUDNOVOGR04',
						borderless: true,
						isCollapsible: false,
						anchored: false,
						directChildren: ['PROPR00_PROPRNAME____', 'PROPR00_PROPRPRECOEST', 'PROPR00_TPPROTPPROPRI', 'PROPR00_PROPRMOBILADA'],
						controlLimits: [
						],
					}, this),
					PROPR00_PROPRNAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:propr.name',
						id: 'PROPR00_PROPRNAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.REAL_ESTATE24996),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPR00_PSEUDNOVOGR02',
						maxLength: 85,
						controlLimits: [
						],
					}, this),
					PROPR00_PROPRPRECOEST: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrecoest',
						valueChangeEvent: 'fieldChange:propr.precoest',
						id: 'PROPR00_PROPRPRECOEST',
						name: 'PRECOEST',
						size: 'medium',
						label: computed(() => this.Resources.ESTIMATED_PRICE02986),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPR00_PSEUDNOVOGR02',
						maxIntegers: 9,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					PROPR00_TPPROTPPROPRI: new fieldControlClass.LookupControl({
						modelField: 'TableTpproTppropri',
						valueChangeEvent: 'fieldChange:tppro.tppropri',
						id: 'PROPR00_TPPROTPPROPRI',
						name: 'TPPROPRI',
						size: 'medium',
						label: computed(() => this.Resources.PROPERTY_TYPE33991),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPR00_PSEUDNOVOGR02',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodtppro',
							dependencyEvent: 'fieldChange:propr.codtppro'
						},
						dependentFields: () => ({
							set 'tppro.codtppro'(value) { vm.model.ValCodtppro.updateValue(value) },
							set 'tppro.tppropri'(value) { vm.model.TableTpproTppropri.updateValue(value) },
						}),
						insertEnabled: true,
						supportForm: 'TPPRO',
						controlLimits: [
						],
					}, this),
					PROPR00_PROPRMOBILADA: new fieldControlClass.BooleanControl({
						modelField: 'ValMobilada',
						valueChangeEvent: 'fieldChange:propr.mobilada',
						id: 'PROPR00_PROPRMOBILADA',
						name: 'MOBILADA',
						size: 'small',
						label: computed(() => this.Resources.FURNISHED37431),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'PROPR00_PSEUDNOVOGR02',
						controlLimits: [
						],
					}, this),
					PROPR00_PESSONAME____: new fieldControlClass.LookupControl({
						modelField: 'TablePessoName',
						valueChangeEvent: 'fieldChange:pesso.name',
						id: 'PROPR00_PESSONAME____',
						name: 'NAME',
						size: 'large',
						label: computed(() => this.Resources.SELLER36870),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPR00_PSEUDNOVOGR04',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodpesso',
							dependencyEvent: 'fieldChange:propr.codpesso'
						},
						dependentFields: () => ({
							set 'pesso.codpesso'(value) { vm.model.ValCodpesso.updateValue(value) },
							set 'pesso.name'(value) { vm.model.TablePessoName.updateValue(value) },
							set 'propr.codcntry'(value) { vm.model.ValCodcntry.updateValue(value) },
							set 'cntry.codcntry'(value) { vm.model.ValCodcntry.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					PROPR00_PROPRPHOTOGRA: new fieldControlClass.ImageControl({
						modelField: 'ValPhotogra',
						valueChangeEvent: 'fieldChange:propr.photogra',
						id: 'PROPR00_PROPRPHOTOGRA',
						name: 'PHOTOGRA',
						size: 'medium',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPR00_PSEUDNOVOGR01',
						height: 50,
						width: 100,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO51874)),
						controlLimits: [
						],
					}, this),
					PROPR00_PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'PROPR00_PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPR00_PSEUDNOVOGR04',
						borderless: true,
						isCollapsible: false,
						anchored: false,
						directChildren: ['PROPR00_PROPRPHOTOGRA'],
						controlLimits: [
						],
					}, this),
					PROPR00_PSEUDPROPR02_: new fieldControlClass.TabControl({
						id: 'PROPR00_PSEUDPROPR02_',
						name: 'PROPR02',
						size: 'xxlarge',
						label: computed(() => this.Resources.DETAILS19591),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['PROPR02_PROPRQTD_WC__', 'PROPR02_PROPRQTDQUART', 'PROPR02_PROPRM2______', 'PROPR02_PROPRDTDISPON'],
						controlLimits: [
						],
					}, this),
					PROPR00_PSEUDPROPR01_: new fieldControlClass.TabControl({
						id: 'PROPR00_PSEUDPROPR01_',
						name: 'PROPR01',
						size: 'xxlarge',
						label: computed(() => this.Resources.LOCALIZATION34148),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['PROPR01_PSEUDNOVOGR01', 'PROPR01_PROPRCOORDGEO'],
						controlLimits: [
						],
					}, this),
					PROPR00_PSEUDPROPR03_: new fieldControlClass.TabControl({
						id: 'PROPR00_PSEUDPROPR03_',
						name: 'PROPR03',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESCRIPTION07383),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['PROPR03_PROPRDESCRIPT'],
						controlLimits: [
						],
					}, this),
					PROPR02_PROPRQTD_WC__: new fieldControlClass.NumberControl({
						modelField: 'ValQtd_wc',
						valueChangeEvent: 'fieldChange:propr.qtd_wc',
						id: 'PROPR02_PROPRQTD_WC__',
						name: 'QTD_WC',
						size: 'small',
						label: computed(() => this.Resources.BATHROOM12866),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'PROPR00_PSEUDPROPR02_',
						maxIntegers: 6,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					PROPR02_PROPRQTDQUART: new fieldControlClass.NumberControl({
						modelField: 'ValQtdquart',
						valueChangeEvent: 'fieldChange:propr.qtdquart',
						id: 'PROPR02_PROPRQTDQUART',
						name: 'QTDQUART',
						size: 'mini',
						label: computed(() => this.Resources.QUARTOS46431),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'PROPR00_PSEUDPROPR02_',
						maxIntegers: 6,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					PROPR02_PROPRM2______: new fieldControlClass.NumberControl({
						modelField: 'ValM2',
						valueChangeEvent: 'fieldChange:propr.m2',
						id: 'PROPR02_PROPRM2______',
						name: 'M2',
						size: 'medium',
						label: computed(() => this.Resources.SQUARE_METERS28913),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'PROPR00_PSEUDPROPR02_',
						maxIntegers: 6,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					PROPR02_PROPRDTDISPON: new fieldControlClass.DateControl({
						modelField: 'ValDtdispon',
						valueChangeEvent: 'fieldChange:propr.dtdispon',
						id: 'PROPR02_PROPRDTDISPON',
						name: 'DTDISPON',
						size: 'small',
						label: computed(() => this.Resources.AVAILABLE_FROM53703),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'PROPR00_PSEUDPROPR02_',
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					PROPR01_PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'PROPR01_PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						label: computed(() => this.Resources.ADDRESS04342),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'PROPR00_PSEUDPROPR01_',
						borderless: false,
						isCollapsible: false,
						anchored: false,
						directChildren: ['PROPR01_PROPRENDERECO', 'PROPR01_PROPRLOCALIDA', 'PROPR01_PROPRPOSTALCO', 'PROPR01_PROPRPOSTALLO', 'PROPR01_CNTRYCOUNTRY_', 'PROPR01_REGIOREGIAO__'],
						controlLimits: [
						],
					}, this),
					PROPR01_PROPRENDERECO: new fieldControlClass.MultilineStringControl({
						modelField: 'ValEndereco',
						valueChangeEvent: 'fieldChange:propr.endereco',
						id: 'PROPR01_PROPRENDERECO',
						name: 'ENDERECO',
						size: 'xxlarge',
						label: computed(() => this.Resources.ADDRESS04342),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPR01_PSEUDNOVOGR01',
						tab: 'PROPR00_PSEUDPROPR01_',
						rows: 2,
						cols: 85,
						controlLimits: [
						],
					}, this),
					PROPR01_PROPRLOCALIDA: new fieldControlClass.StringControl({
						modelField: 'ValLocalida',
						valueChangeEvent: 'fieldChange:propr.localida',
						id: 'PROPR01_PROPRLOCALIDA',
						name: 'LOCALIDA',
						size: 'xlarge',
						label: computed(() => this.Resources.LOCALIZATION34148),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPR01_PSEUDNOVOGR01',
						tab: 'PROPR00_PSEUDPROPR01_',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					PROPR01_PROPRPOSTALCO: new fieldControlClass.StringControl({
						modelField: 'ValPostalco',
						valueChangeEvent: 'fieldChange:propr.postalco',
						id: 'PROPR01_PROPRPOSTALCO',
						name: 'POSTALCO',
						size: 'small',
						label: computed(() => this.Resources.ZIPCODE21021),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPR01_PSEUDNOVOGR01',
						tab: 'PROPR00_PSEUDPROPR01_',
						maxLength: 20,
						controlLimits: [
						],
					}, this),
					PROPR01_PROPRPOSTALLO: new fieldControlClass.StringControl({
						modelField: 'ValPostallo',
						valueChangeEvent: 'fieldChange:propr.postallo',
						id: 'PROPR01_PROPRPOSTALLO',
						name: 'POSTALLO',
						size: 'large',
						label: computed(() => this.Resources.ZIPCODE21021),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPR01_PSEUDNOVOGR01',
						tab: 'PROPR00_PSEUDPROPR01_',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					PROPR01_CNTRYCOUNTRY_: new fieldControlClass.LookupControl({
						modelField: 'TableCntryCountry',
						valueChangeEvent: 'fieldChange:cntry.country',
						id: 'PROPR01_CNTRYCOUNTRY_',
						name: 'COUNTRY',
						size: 'xlarge',
						label: computed(() => this.Resources.COUNTRY64133),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPR01_PSEUDNOVOGR01',
						tab: 'PROPR00_PSEUDPROPR01_',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodcntry',
							dependencyEvent: 'fieldChange:propr.codcntry'
						},
						dependentFields: () => ({
							set 'cntry.codcntry'(value) { vm.model.ValCodcntry.updateValue(value) },
							set 'cntry.country'(value) { vm.model.TableCntryCountry.updateValue(value) },
						}),
						insertEnabled: true,
						supportForm: 'PAIS',
						controlLimits: [
						],
					}, this),
					PROPR01_REGIOREGIAO__: new fieldControlClass.LookupControl({
						modelField: 'TableRegioRegiao',
						valueChangeEvent: 'fieldChange:regio.regiao',
						id: 'PROPR01_REGIOREGIAO__',
						name: 'REGIAO',
						size: 'xlarge',
						label: computed(() => this.Resources.REGION12723),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPR01_PSEUDNOVOGR01',
						tab: 'PROPR00_PSEUDPROPR01_',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodregia',
							dependencyEvent: 'fieldChange:propr.codregia'
						},
						dependentFields: () => ({
							set 'regio.codregia'(value) { vm.model.ValCodregia.updateValue(value) },
							set 'regio.regiao'(value) { vm.model.TableRegioRegiao.updateValue(value) },
						}),
						insertEnabled: true,
						supportForm: 'REGIA',
						controlLimits: [
							{
								identifier: ['cntry', 'propr.codcntry'],
								dependencyEvents: ['fieldChange:propr.codcntry'],
								dependencyField: 'PROPR.CODCNTRY',
								fnValueSelector: (model) => model.ValCodcntry.value
							},
						],
					}, this),
					PROPR01_PROPRCOORDGEO: new fieldControlClass.BaseControl({
						modelField: 'ValCoordgeo',
						valueChangeEvent: 'fieldChange:propr.coordgeo',
						isGeographicShape: false,
						isEuclideanCoord: false,
						id: 'PROPR01_PROPRCOORDGEO',
						name: 'COORDGEO',
						size: 'medium',
						label: computed(() => this.Resources.GEOGRAPHIC_COORDINAT42880),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'PROPR00_PSEUDPROPR01_',
						controlLimits: [
						],
					}, this),
					PROPR03_PROPRDESCRIPT: new fieldControlClass.TextEditorControl({
						modelField: 'ValDescript',
						valueChangeEvent: 'fieldChange:propr.descript',
						id: 'PROPR03_PROPRDESCRIPT',
						name: 'DESCRIPT',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESCRIPTION07383),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'PROPR00_PSEUDPROPR03_',
						controlLimits: [
						],
					}, this),
					formTabs: new fieldControlClass.TabsControl({
						id: 'formTabs',
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
// USE /[MANUAL GQT FORM_CODEJS PROPR00]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT PROPR00]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS PROPR00]/
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
				for (const trigger of triggers)
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
				// Execute the "After save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterSave)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT AFTER_SAVE_JS PROPR00]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS PROPR00]/
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
// USE /[MANUAL GQT AFTER_DEL_JS PROPR00]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS PROPR00]/
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
			 * Called whenever a field is unfocused.
			 * @param {*} fieldObject The object representing the field in the model
			 * @param {*} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onBlur(fieldObject, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT CTRLBLR PROPR00]/
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
// USE /[MANUAL GQT CTRLUPD PROPR00]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS PROPR00]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
