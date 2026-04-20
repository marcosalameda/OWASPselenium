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
			data-key="PROPRALL"
			:data-identifier="primaryKeyValue"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.PROPRALLPSEUDNOVOGR03.isVisible">
					<q-col
						v-if="controls.PROPRALLPSEUDNOVOGR03.isVisible"
						cols="auto">
						<q-group-box-container
							v-if="controls.PROPRALLPSEUDNOVOGR03.isVisible"
							v-bind="controls.PROPRALLPSEUDNOVOGR03"
							:id="getControlId(controls.PROPRALLPSEUDNOVOGR03)"
							:no-border="controls.PROPRALLPSEUDNOVOGR03.borderless">
							<!-- Start PROPRALLPSEUDNOVOGR03 -->
							<q-row v-if="controls.PROPRALLPROPRPHOTOGRA.isVisible">
								<q-col
									v-if="controls.PROPRALLPROPRPHOTOGRA.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.PROPRALLPROPRPHOTOGRA.isVisible"
										class="q-image"
										v-bind="controls.PROPRALLPROPRPHOTOGRA.wrapperProps"
										:id="getControlId(controls.PROPRALLPROPRPHOTOGRA)"
										v-on="controls.PROPRALLPROPRPHOTOGRA.handlers"
										:loading="controls.PROPRALLPROPRPHOTOGRA.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-image
											v-if="controls.PROPRALLPROPRPHOTOGRA.isVisible"
											v-bind="controls.PROPRALLPROPRPHOTOGRA.props"
											:id="getControlId(controls.PROPRALLPROPRPHOTOGRA)"
											v-on="controls.PROPRALLPROPRPHOTOGRA.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End PROPRALLPSEUDNOVOGR03 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.PROPRALLPSEUDNOVOGR02.isVisible">
					<q-col v-if="controls.PROPRALLPSEUDNOVOGR02.isVisible">
						<q-group-box-container
							v-if="controls.PROPRALLPSEUDNOVOGR02.isVisible"
							v-bind="controls.PROPRALLPSEUDNOVOGR02"
							:id="getControlId(controls.PROPRALLPSEUDNOVOGR02)"
							:no-border="controls.PROPRALLPSEUDNOVOGR02.borderless">
							<!-- Start PROPRALLPSEUDNOVOGR02 -->
							<q-row v-if="controls.PROPRALLPROPRNAME____.isVisible || controls.PROPRALLPROPRPRECOEST.isVisible || controls.PROPRALLTPPROTPPROPRI.isVisible || controls.PROPRALLPROPRMOBILADA.isVisible">
								<q-col
									v-if="controls.PROPRALLPROPRNAME____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.PROPRALLPROPRNAME____.isVisible"
										class="i-text"
										v-bind="controls.PROPRALLPROPRNAME____.wrapperProps"
										:id="getControlId(controls.PROPRALLPROPRNAME____)"
										v-on="controls.PROPRALLPROPRNAME____.handlers"
										:loading="controls.PROPRALLPROPRNAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.PROPRALLPROPRNAME____.props"
											:id="getControlId(controls.PROPRALLPROPRNAME____)"
											@blur="onBlur(controls.PROPRALLPROPRNAME____, model.ValName.value)"
											@change="model.ValName.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.PROPRALLPROPRPRECOEST.isVisible || controls.PROPRALLTPPROTPPROPRI.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.PROPRALLPROPRPRECOEST.isVisible"
										class="i-text"
										v-bind="controls.PROPRALLPROPRPRECOEST.wrapperProps"
										:id="getControlId(controls.PROPRALLPROPRPRECOEST)"
										v-on="controls.PROPRALLPROPRPRECOEST.handlers"
										:loading="controls.PROPRALLPROPRPRECOEST.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.PROPRALLPROPRPRECOEST.isVisible"
											v-bind="controls.PROPRALLPROPRPRECOEST.props"
											:id="getControlId(controls.PROPRALLPROPRPRECOEST)"
											@update:model-value="model.ValPrecoest.fnUpdateValue" />
									</base-input-structure>
									<base-input-structure
										v-if="controls.PROPRALLTPPROTPPROPRI.isVisible"
										class="i-text"
										v-bind="controls.PROPRALLTPPROTPPROPRI.wrapperProps"
										:id="getControlId(controls.PROPRALLTPPROTPPROPRI)"
										v-on="controls.PROPRALLTPPROTPPROPRI.handlers"
										:loading="controls.PROPRALLTPPROTPPROPRI.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.PROPRALLTPPROTPPROPRI.isVisible"
											v-bind="controls.PROPRALLTPPROTPPROPRI.props"
											:id="getControlId(controls.PROPRALLTPPROTPPROPRI)"
											v-on="controls.PROPRALLTPPROTPPROPRI.handlers" />
										<q-see-more-propralltpprotppropri
											v-if="controls.PROPRALLTPPROTPPROPRI.seeMoreIsVisible"
											v-bind="controls.PROPRALLTPPROTPPROPRI.seeMoreParams"
											v-on="controls.PROPRALLTPPROTPPROPRI.handlers" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.PROPRALLPROPRMOBILADA.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.PROPRALLPROPRMOBILADA.isVisible"
										class="i-text"
										v-bind="controls.PROPRALLPROPRMOBILADA.wrapperProps"
										:id="getControlId(controls.PROPRALLPROPRMOBILADA)"
										v-on="controls.PROPRALLPROPRMOBILADA.handlers"
										:loading="controls.PROPRALLPROPRMOBILADA.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox
												v-if="controls.PROPRALLPROPRMOBILADA.isVisible"
												v-bind="controls.PROPRALLPROPRMOBILADA.props"
												:id="getControlId(controls.PROPRALLPROPRMOBILADA)"
												v-on="controls.PROPRALLPROPRMOBILADA.handlers" />
										</template>
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.PROPRALLPROPRQTD_WC__.isVisible || controls.PROPRALLPROPRQTDQUART.isVisible || controls.PROPRALLPROPRM2______.isVisible || controls.PROPRALLPROPRDTDISPON.isVisible">
								<q-col
									v-if="controls.PROPRALLPROPRQTD_WC__.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.PROPRALLPROPRQTD_WC__.isVisible"
										class="i-text"
										v-bind="controls.PROPRALLPROPRQTD_WC__.wrapperProps"
										:id="getControlId(controls.PROPRALLPROPRQTD_WC__)"
										v-on="controls.PROPRALLPROPRQTD_WC__.handlers"
										:loading="controls.PROPRALLPROPRQTD_WC__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.PROPRALLPROPRQTD_WC__.isVisible"
											v-bind="controls.PROPRALLPROPRQTD_WC__.props"
											:id="getControlId(controls.PROPRALLPROPRQTD_WC__)"
											@update:model-value="model.ValQtd_wc.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.PROPRALLPROPRQTDQUART.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.PROPRALLPROPRQTDQUART.isVisible"
										class="i-text"
										v-bind="controls.PROPRALLPROPRQTDQUART.wrapperProps"
										:id="getControlId(controls.PROPRALLPROPRQTDQUART)"
										v-on="controls.PROPRALLPROPRQTDQUART.handlers"
										:loading="controls.PROPRALLPROPRQTDQUART.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.PROPRALLPROPRQTDQUART.isVisible"
											v-bind="controls.PROPRALLPROPRQTDQUART.props"
											:id="getControlId(controls.PROPRALLPROPRQTDQUART)"
											@update:model-value="model.ValQtdquart.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.PROPRALLPROPRM2______.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.PROPRALLPROPRM2______.isVisible"
										class="i-text"
										v-bind="controls.PROPRALLPROPRM2______.wrapperProps"
										:id="getControlId(controls.PROPRALLPROPRM2______)"
										v-on="controls.PROPRALLPROPRM2______.handlers"
										:loading="controls.PROPRALLPROPRM2______.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.PROPRALLPROPRM2______.isVisible"
											v-bind="controls.PROPRALLPROPRM2______.props"
											:id="getControlId(controls.PROPRALLPROPRM2______)"
											@update:model-value="model.ValM2.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.PROPRALLPROPRDTDISPON.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.PROPRALLPROPRDTDISPON.isVisible"
										class="i-text"
										v-bind="controls.PROPRALLPROPRDTDISPON.wrapperProps"
										:id="getControlId(controls.PROPRALLPROPRDTDISPON)"
										v-on="controls.PROPRALLPROPRDTDISPON.handlers"
										:loading="controls.PROPRALLPROPRDTDISPON.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.PROPRALLPROPRDTDISPON.isVisible"
											v-bind="controls.PROPRALLPROPRDTDISPON.props"
											:id="getControlId(controls.PROPRALLPROPRDTDISPON)"
											:model-value="model.ValDtdispon.value"
											@reset-icon-click="model.ValDtdispon.fnUpdateValue(model.ValDtdispon.originalValue ?? new Date())"
											@update:model-value="model.ValDtdispon.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.PROPRALLPROPRDESCRIPT.isVisible">
								<q-col
									v-if="controls.PROPRALLPROPRDESCRIPT.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.PROPRALLPROPRDESCRIPT.isVisible"
										class="i-text"
										v-bind="controls.PROPRALLPROPRDESCRIPT.wrapperProps"
										:id="getControlId(controls.PROPRALLPROPRDESCRIPT)"
										v-on="controls.PROPRALLPROPRDESCRIPT.handlers"
										:loading="controls.PROPRALLPROPRDESCRIPT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-editor
											v-if="controls.PROPRALLPROPRDESCRIPT.isVisible"
											v-bind="controls.PROPRALLPROPRDESCRIPT.props"
											:id="getControlId(controls.PROPRALLPROPRDESCRIPT)"
											v-on="controls.PROPRALLPROPRDESCRIPT.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.PROPRALLPESSONAME____.isVisible">
								<q-col
									v-if="controls.PROPRALLPESSONAME____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.PROPRALLPESSONAME____.isVisible"
										class="i-text"
										v-bind="controls.PROPRALLPESSONAME____.wrapperProps"
										:id="getControlId(controls.PROPRALLPESSONAME____)"
										v-on="controls.PROPRALLPESSONAME____.handlers"
										:loading="controls.PROPRALLPESSONAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.PROPRALLPESSONAME____.isVisible"
											v-bind="controls.PROPRALLPESSONAME____.props"
											:id="getControlId(controls.PROPRALLPESSONAME____)"
											v-on="controls.PROPRALLPESSONAME____.handlers" />
										<q-see-more-proprallpessoname
											v-if="controls.PROPRALLPESSONAME____.seeMoreIsVisible"
											v-bind="controls.PROPRALLPESSONAME____.seeMoreParams"
											v-on="controls.PROPRALLPESSONAME____.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End PROPRALLPSEUDNOVOGR02 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.PROPRALLPSEUDNOVOGR01.isVisible">
					<q-col v-if="controls.PROPRALLPSEUDNOVOGR01.isVisible">
						<q-group-box-container
							v-if="controls.PROPRALLPSEUDNOVOGR01.isVisible"
							v-bind="controls.PROPRALLPSEUDNOVOGR01"
							:id="getControlId(controls.PROPRALLPSEUDNOVOGR01)"
							:no-border="controls.PROPRALLPSEUDNOVOGR01.borderless">
							<!-- Start PROPRALLPSEUDNOVOGR01 -->
							<q-row v-if="controls.PROPRALLCNTRYCOUNTRY_.isVisible">
								<q-col
									v-if="controls.PROPRALLCNTRYCOUNTRY_.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.PROPRALLCNTRYCOUNTRY_.isVisible"
										class="i-text"
										v-bind="controls.PROPRALLCNTRYCOUNTRY_.wrapperProps"
										:id="getControlId(controls.PROPRALLCNTRYCOUNTRY_)"
										v-on="controls.PROPRALLCNTRYCOUNTRY_.handlers"
										:loading="controls.PROPRALLCNTRYCOUNTRY_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.PROPRALLCNTRYCOUNTRY_.isVisible"
											v-bind="controls.PROPRALLCNTRYCOUNTRY_.props"
											:id="getControlId(controls.PROPRALLCNTRYCOUNTRY_)"
											v-on="controls.PROPRALLCNTRYCOUNTRY_.handlers" />
										<q-see-more-proprallcntrycountry
											v-if="controls.PROPRALLCNTRYCOUNTRY_.seeMoreIsVisible"
											v-bind="controls.PROPRALLCNTRYCOUNTRY_.seeMoreParams"
											v-on="controls.PROPRALLCNTRYCOUNTRY_.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.PROPRALLREGIOREGIAO__.isVisible || controls.PROPRALLPROPRENDERECO.isVisible">
								<q-col
									v-if="controls.PROPRALLREGIOREGIAO__.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.PROPRALLREGIOREGIAO__.isVisible"
										class="i-text"
										v-bind="controls.PROPRALLREGIOREGIAO__.wrapperProps"
										:id="getControlId(controls.PROPRALLREGIOREGIAO__)"
										v-on="controls.PROPRALLREGIOREGIAO__.handlers"
										:loading="controls.PROPRALLREGIOREGIAO__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.PROPRALLREGIOREGIAO__.isVisible"
											v-bind="controls.PROPRALLREGIOREGIAO__.props"
											:id="getControlId(controls.PROPRALLREGIOREGIAO__)"
											v-on="controls.PROPRALLREGIOREGIAO__.handlers" />
										<q-see-more-proprallregioregiao
											v-if="controls.PROPRALLREGIOREGIAO__.seeMoreIsVisible"
											v-bind="controls.PROPRALLREGIOREGIAO__.seeMoreParams"
											v-on="controls.PROPRALLREGIOREGIAO__.handlers" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.PROPRALLPROPRENDERECO.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.PROPRALLPROPRENDERECO.isVisible"
										class="i-textarea"
										v-bind="controls.PROPRALLPROPRENDERECO.wrapperProps"
										:id="getControlId(controls.PROPRALLPROPRENDERECO)"
										v-on="controls.PROPRALLPROPRENDERECO.handlers"
										:loading="controls.PROPRALLPROPRENDERECO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-area
											v-if="controls.PROPRALLPROPRENDERECO.isVisible"
											v-bind="controls.PROPRALLPROPRENDERECO.props"
											:id="getControlId(controls.PROPRALLPROPRENDERECO)"
											v-on="controls.PROPRALLPROPRENDERECO.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.PROPRALLPROPRLOCALIDA.isVisible">
								<q-col
									v-if="controls.PROPRALLPROPRLOCALIDA.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.PROPRALLPROPRLOCALIDA.isVisible"
										class="i-text"
										v-bind="controls.PROPRALLPROPRLOCALIDA.wrapperProps"
										:id="getControlId(controls.PROPRALLPROPRLOCALIDA)"
										v-on="controls.PROPRALLPROPRLOCALIDA.handlers"
										:loading="controls.PROPRALLPROPRLOCALIDA.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.PROPRALLPROPRLOCALIDA.props"
											:id="getControlId(controls.PROPRALLPROPRLOCALIDA)"
											@blur="onBlur(controls.PROPRALLPROPRLOCALIDA, model.ValLocalida.value)"
											@change="model.ValLocalida.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.PROPRALLPROPRPOSTALCO.isVisible || controls.PROPRALLPROPRPOSTALLO.isVisible">
								<q-col
									v-if="controls.PROPRALLPROPRPOSTALCO.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.PROPRALLPROPRPOSTALCO.isVisible"
										class="i-text"
										v-bind="controls.PROPRALLPROPRPOSTALCO.wrapperProps"
										:id="getControlId(controls.PROPRALLPROPRPOSTALCO)"
										v-on="controls.PROPRALLPROPRPOSTALCO.handlers"
										:loading="controls.PROPRALLPROPRPOSTALCO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.PROPRALLPROPRPOSTALCO.props"
											:id="getControlId(controls.PROPRALLPROPRPOSTALCO)"
											@blur="onBlur(controls.PROPRALLPROPRPOSTALCO, model.ValPostalco.value)"
											@change="model.ValPostalco.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.PROPRALLPROPRPOSTALLO.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.PROPRALLPROPRPOSTALLO.isVisible"
										class="i-text"
										v-bind="controls.PROPRALLPROPRPOSTALLO.wrapperProps"
										:id="getControlId(controls.PROPRALLPROPRPOSTALLO)"
										v-on="controls.PROPRALLPROPRPOSTALLO.handlers"
										:loading="controls.PROPRALLPROPRPOSTALLO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.PROPRALLPROPRPOSTALLO.props"
											:id="getControlId(controls.PROPRALLPROPRPOSTALLO)"
											@blur="onBlur(controls.PROPRALLPROPRPOSTALLO, model.ValPostallo.value)"
											@change="model.ValPostallo.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End PROPRALLPSEUDNOVOGR01 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.PROPRALLPROPRCOORDGEO.isVisible">
					<q-col
						v-if="controls.PROPRALLPROPRCOORDGEO.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.PROPRALLPROPRCOORDGEO.isVisible"
							class="i-text"
							v-bind="controls.PROPRALLPROPRCOORDGEO.wrapperProps"
							:id="getControlId(controls.PROPRALLPROPRCOORDGEO)"
							v-on="controls.PROPRALLPROPRCOORDGEO.handlers"
							:loading="controls.PROPRALLPROPRCOORDGEO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.PROPRALLPROPRCOORDGEO.props"
								:id="getControlId(controls.PROPRALLPROPRCOORDGEO)"
								@blur="onBlur(controls.PROPRALLPROPRCOORDGEO, model.ValCoordgeo.value)"
								@change="model.ValCoordgeo.fnUpdateValueOnChange" />
						</base-input-structure>
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

	import FormViewModel from './QFormProprallViewModel.js'

	const requiredTextResources = ['QFormProprall', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PROPRALL]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormProprall',

		components: {
			QSeeMorePropralltpprotppropri: defineAsyncComponent(() => import('@/views/forms/FormProprall/dbedits/PropralltpprotppropriSeeMore.vue')),
			QSeeMoreProprallcntrycountry: defineAsyncComponent(() => import('@/views/forms/FormProprall/dbedits/ProprallcntrycountrySeeMore.vue')),
			QSeeMoreProprallregioregiao: defineAsyncComponent(() => import('@/views/forms/FormProprall/dbedits/ProprallregioregiaoSeeMore.vue')),
			QSeeMoreProprallpessoname: defineAsyncComponent(() => import('@/views/forms/FormProprall/dbedits/ProprallpessonameSeeMore.vue')),
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
					name: 'PROPRALL',
					location: 'form-PROPRALL',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormProprall', false),

				interfaceMetadata: {
					id: 'QFormProprall', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'PROPRALL',
					route: 'form-PROPRALL',
					area: 'PROPR',
					primaryKey: 'ValCodpropr',
					designation: computed(() => this.Resources.PROPERTY43977),
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
					PROPRALLPSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'PROPRALLPSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'xlarge',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						borderless: false,
						isCollapsible: false,
						anchored: false,
						directChildren: ['PROPRALLPROPRPHOTOGRA'],
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRPHOTOGRA: new fieldControlClass.ImageControl({
						modelField: 'ValPhotogra',
						valueChangeEvent: 'fieldChange:propr.photogra',
						id: 'PROPRALLPROPRPHOTOGRA',
						name: 'PHOTOGRA',
						size: 'medium',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR03',
						height: 50,
						width: 100,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO51874)),
						controlLimits: [
						],
					}, this),
					PROPRALLPSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'PROPRALLPSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'block',
						label: computed(() => this.Resources.IDENTIFICATION37731),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						borderless: false,
						isCollapsible: false,
						anchored: false,
						directChildren: ['PROPRALLPROPRNAME____', 'PROPRALLPROPRPRECOEST', 'PROPRALLTPPROTPPROPRI', 'PROPRALLPROPRMOBILADA', 'PROPRALLPROPRQTD_WC__', 'PROPRALLPROPRQTDQUART', 'PROPRALLPROPRM2______', 'PROPRALLPROPRDTDISPON', 'PROPRALLPROPRDESCRIPT', 'PROPRALLPESSONAME____'],
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRNAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:propr.name',
						id: 'PROPRALLPROPRNAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.REAL_ESTATE15399),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR02',
						maxLength: 85,
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRPRECOEST: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrecoest',
						valueChangeEvent: 'fieldChange:propr.precoest',
						id: 'PROPRALLPROPRPRECOEST',
						name: 'PRECOEST',
						size: 'medium',
						label: computed(() => this.Resources.ESTIMATED_PRICE02986),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR02',
						maxIntegers: 9,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					PROPRALLTPPROTPPROPRI: new fieldControlClass.LookupControl({
						modelField: 'TableTpproTppropri',
						valueChangeEvent: 'fieldChange:tppro.tppropri',
						id: 'PROPRALLTPPROTPPROPRI',
						name: 'TPPROPRI',
						size: 'medium',
						label: computed(() => this.Resources.PROPERTY_TYPE33991),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR02',
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
					PROPRALLPSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'PROPRALLPSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						label: computed(() => this.Resources.LOCALIZATION34148),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						borderless: false,
						isCollapsible: false,
						anchored: false,
						directChildren: ['PROPRALLCNTRYCOUNTRY_', 'PROPRALLREGIOREGIAO__', 'PROPRALLPROPRENDERECO', 'PROPRALLPROPRLOCALIDA', 'PROPRALLPROPRPOSTALCO', 'PROPRALLPROPRPOSTALLO'],
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRMOBILADA: new fieldControlClass.BooleanControl({
						modelField: 'ValMobilada',
						valueChangeEvent: 'fieldChange:propr.mobilada',
						id: 'PROPRALLPROPRMOBILADA',
						name: 'MOBILADA',
						size: 'small',
						label: computed(() => this.Resources.FURNISHED37431),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'PROPRALLPSEUDNOVOGR02',
						controlLimits: [
						],
					}, this),
					PROPRALLCNTRYCOUNTRY_: new fieldControlClass.LookupControl({
						modelField: 'TableCntryCountry',
						valueChangeEvent: 'fieldChange:cntry.country',
						id: 'PROPRALLCNTRYCOUNTRY_',
						name: 'COUNTRY',
						size: 'xlarge',
						label: computed(() => this.Resources.COUNTRY64133),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR01',
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
					PROPRALLREGIOREGIAO__: new fieldControlClass.LookupControl({
						modelField: 'TableRegioRegiao',
						valueChangeEvent: 'fieldChange:regio.regiao',
						id: 'PROPRALLREGIOREGIAO__',
						name: 'REGIAO',
						size: 'xlarge',
						label: computed(() => this.Resources.REGION12723),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR01',
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
					PROPRALLPROPRENDERECO: new fieldControlClass.MultilineStringControl({
						modelField: 'ValEndereco',
						valueChangeEvent: 'fieldChange:propr.endereco',
						id: 'PROPRALLPROPRENDERECO',
						name: 'ENDERECO',
						size: 'xxlarge',
						label: computed(() => this.Resources.ADDRESS04342),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR01',
						rows: 2,
						cols: 85,
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRLOCALIDA: new fieldControlClass.StringControl({
						modelField: 'ValLocalida',
						valueChangeEvent: 'fieldChange:propr.localida',
						id: 'PROPRALLPROPRLOCALIDA',
						name: 'LOCALIDA',
						size: 'xlarge',
						label: computed(() => this.Resources.LOCALIZATION34148),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR01',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRPOSTALCO: new fieldControlClass.StringControl({
						modelField: 'ValPostalco',
						valueChangeEvent: 'fieldChange:propr.postalco',
						id: 'PROPRALLPROPRPOSTALCO',
						name: 'POSTALCO',
						size: 'small',
						label: computed(() => this.Resources.ZIPCODE21021),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR01',
						maxLength: 20,
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRPOSTALLO: new fieldControlClass.StringControl({
						modelField: 'ValPostallo',
						valueChangeEvent: 'fieldChange:propr.postallo',
						id: 'PROPRALLPROPRPOSTALLO',
						name: 'POSTALLO',
						size: 'large',
						label: computed(() => this.Resources.ZIPCODE21021),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR01',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRQTD_WC__: new fieldControlClass.NumberControl({
						modelField: 'ValQtd_wc',
						valueChangeEvent: 'fieldChange:propr.qtd_wc',
						id: 'PROPRALLPROPRQTD_WC__',
						name: 'QTD_WC',
						size: 'small',
						label: computed(() => this.Resources.BATHROOM12866),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR02',
						maxIntegers: 6,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRQTDQUART: new fieldControlClass.NumberControl({
						modelField: 'ValQtdquart',
						valueChangeEvent: 'fieldChange:propr.qtdquart',
						id: 'PROPRALLPROPRQTDQUART',
						name: 'QTDQUART',
						size: 'mini',
						label: computed(() => this.Resources.ROOMS06809),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR02',
						maxIntegers: 6,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRM2______: new fieldControlClass.NumberControl({
						modelField: 'ValM2',
						valueChangeEvent: 'fieldChange:propr.m2',
						id: 'PROPRALLPROPRM2______',
						name: 'M2',
						size: 'medium',
						label: computed(() => this.Resources.SQUARE_METERS28913),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR02',
						maxIntegers: 6,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRDTDISPON: new fieldControlClass.DateControl({
						modelField: 'ValDtdispon',
						valueChangeEvent: 'fieldChange:propr.dtdispon',
						id: 'PROPRALLPROPRDTDISPON',
						name: 'DTDISPON',
						size: 'small',
						label: computed(() => this.Resources.AVAILABLE_FROM53703),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR02',
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRDESCRIPT: new fieldControlClass.TextEditorControl({
						modelField: 'ValDescript',
						valueChangeEvent: 'fieldChange:propr.descript',
						id: 'PROPRALLPROPRDESCRIPT',
						name: 'DESCRIPT',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESCRIPTION07383),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR02',
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRCOORDGEO: new fieldControlClass.BaseControl({
						modelField: 'ValCoordgeo',
						valueChangeEvent: 'fieldChange:propr.coordgeo',
						isGeographicShape: false,
						isEuclideanCoord: false,
						id: 'PROPRALLPROPRCOORDGEO',
						name: 'COORDGEO',
						size: 'medium',
						label: computed(() => this.Resources.GEOGRAPHIC_COORDINAT42880),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controlLimits: [
						],
					}, this),
					PROPRALLPESSONAME____: new fieldControlClass.LookupControl({
						modelField: 'TablePessoName',
						valueChangeEvent: 'fieldChange:pesso.name',
						id: 'PROPRALLPESSONAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.SELLER36870),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR02',
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
						}),
						controlLimits: [
							{
								identifier: ['cntry', 'propr.codcntry'],
								dependencyEvents: ['fieldChange:propr.codcntry'],
								dependencyField: 'PROPR.CODCNTRY',
								fnValueSelector: (model) => model.ValCodcntry.value
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
					'PROPRALLPSEUDNOVOGR03',
					'PROPRALLPSEUDNOVOGR02',
					'PROPRALLPSEUDNOVOGR01',
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
// USE /[MANUAL GQT FORM_CODEJS PROPRALL]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT PROPRALL]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS PROPRALL]/
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
// USE /[MANUAL GQT FORM_LOADED_JS PROPRALL]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS PROPRALL]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS PROPRALL]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS PROPRALL]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS PROPRALL]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS PROPRALL]/
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
// USE /[MANUAL GQT AFTER_DEL_JS PROPRALL]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS PROPRALL]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS PROPRALL]/
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
// USE /[MANUAL GQT DLGUPDT PROPRALL]/
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
// USE /[MANUAL GQT CTRLBLR PROPRALL]/
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
// USE /[MANUAL GQT CTRLUPD PROPRALL]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS PROPRALL]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
