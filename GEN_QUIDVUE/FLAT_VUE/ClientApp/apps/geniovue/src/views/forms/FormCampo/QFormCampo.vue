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
			data-key="CAMPO"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.CAMPO___AERO_NAME____.isVisible">
					<q-control-wrapper
						v-show="controls.CAMPO___AERO_NAME____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.CAMPO___AERO_NAME____"
							v-on="controls.CAMPO___AERO_NAME____.handlers"
							:loading="controls.CAMPO___AERO_NAME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.CAMPO___AERO_NAME____.isVisible"
								v-bind="controls.CAMPO___AERO_NAME____.props"
								v-on="controls.CAMPO___AERO_NAME____.handlers" />
							<q-see-more-campo-aero-name
								v-if="controls.CAMPO___AERO_NAME____.seeMoreIsVisible"
								v-bind="controls.CAMPO___AERO_NAME____.seeMoreParams"
								v-on="controls.CAMPO___AERO_NAME____.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.CAMPO___FLDS_DESCRIP_.isVisible">
					<q-control-wrapper
						v-show="controls.CAMPO___FLDS_DESCRIP_.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-textarea"
							v-bind="controls.CAMPO___FLDS_DESCRIP_"
							v-on="controls.CAMPO___FLDS_DESCRIP_.handlers"
							:loading="controls.CAMPO___FLDS_DESCRIP_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-area
								v-if="controls.CAMPO___FLDS_DESCRIP_.isVisible"
								v-bind="controls.CAMPO___FLDS_DESCRIP_.props"
								v-on="controls.CAMPO___FLDS_DESCRIP_.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.CAMPO___FLDS_NPASSAGE.isVisible || controls.CAMPO___FLDS_DURATION.isVisible || controls.CAMPO___FLDS_PRICE___.isVisible || controls.CAMPO___FLDS_PRECOBIL.isVisible">
					<q-control-wrapper
						v-show="controls.CAMPO___FLDS_NPASSAGE.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.CAMPO___FLDS_NPASSAGE"
							v-on="controls.CAMPO___FLDS_NPASSAGE.handlers"
							:loading="controls.CAMPO___FLDS_NPASSAGE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.CAMPO___FLDS_NPASSAGE.isVisible"
								v-bind="controls.CAMPO___FLDS_NPASSAGE.props"
								@update:model-value="model.ValNpassage.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.CAMPO___FLDS_DURATION.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.CAMPO___FLDS_DURATION"
							v-on="controls.CAMPO___FLDS_DURATION.handlers"
							:loading="controls.CAMPO___FLDS_DURATION.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.CAMPO___FLDS_DURATION.isVisible"
								v-bind="controls.CAMPO___FLDS_DURATION.props"
								@update:model-value="model.ValDuration.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.CAMPO___FLDS_PRICE___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.CAMPO___FLDS_PRICE___"
							v-on="controls.CAMPO___FLDS_PRICE___.handlers"
							:loading="controls.CAMPO___FLDS_PRICE___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.CAMPO___FLDS_PRICE___.isVisible"
								v-bind="controls.CAMPO___FLDS_PRICE___.props"
								@update:model-value="model.ValPrice.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.CAMPO___FLDS_PRECOBIL.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.CAMPO___FLDS_PRECOBIL"
							v-on="controls.CAMPO___FLDS_PRECOBIL.handlers"
							:loading="controls.CAMPO___FLDS_PRECOBIL.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.CAMPO___FLDS_PRECOBIL.isVisible"
								v-bind="controls.CAMPO___FLDS_PRECOBIL.props"
								@update:model-value="model.ValPrecobil.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.CAMPO___FLDS_DATE____.isVisible">
					<q-control-wrapper
						v-show="controls.CAMPO___FLDS_DATE____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.CAMPO___FLDS_DATE____"
							v-on="controls.CAMPO___FLDS_DATE____.handlers"
							:loading="controls.CAMPO___FLDS_DATE____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.CAMPO___FLDS_DATE____.isVisible"
								v-bind="controls.CAMPO___FLDS_DATE____.props"
								:model-value="model.ValDate.value"
								@reset-icon-click="model.ValDate.fnUpdateValue(model.ValDate.originalValue ?? new Date())"
								@update:model-value="model.ValDate.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.CAMPO___FLDS_DATETIME.isVisible">
					<q-control-wrapper
						v-show="controls.CAMPO___FLDS_DATETIME.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.CAMPO___FLDS_DATETIME"
							v-on="controls.CAMPO___FLDS_DATETIME.handlers"
							:loading="controls.CAMPO___FLDS_DATETIME.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.CAMPO___FLDS_DATETIME.isVisible"
								v-bind="controls.CAMPO___FLDS_DATETIME.props"
								:model-value="model.ValDatetime.value"
								@reset-icon-click="model.ValDatetime.fnUpdateValue(model.ValDatetime.originalValue ?? new Date())"
								@update:model-value="model.ValDatetime.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.CAMPO___FLDS_DATESECO.isVisible">
					<q-control-wrapper
						v-show="controls.CAMPO___FLDS_DATESECO.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.CAMPO___FLDS_DATESECO"
							v-on="controls.CAMPO___FLDS_DATESECO.handlers"
							:loading="controls.CAMPO___FLDS_DATESECO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.CAMPO___FLDS_DATESECO.isVisible"
								v-bind="controls.CAMPO___FLDS_DATESECO.props"
								:model-value="model.ValDateseco.value"
								@reset-icon-click="model.ValDateseco.fnUpdateValue(model.ValDateseco.originalValue ?? new Date())"
								@update:model-value="model.ValDateseco.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.CAMPO___FLDS_TIME____.isVisible">
					<q-control-wrapper
						v-show="controls.CAMPO___FLDS_TIME____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.CAMPO___FLDS_TIME____"
							v-on="controls.CAMPO___FLDS_TIME____.handlers"
							:loading="controls.CAMPO___FLDS_TIME____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.CAMPO___FLDS_TIME____.isVisible"
								v-bind="controls.CAMPO___FLDS_TIME____.props"
								:model-value="model.ValTime.value"
								@reset-icon-click="model.ValTime.fnUpdateValue(model.ValTime.originalValue ?? new Date())"
								@update:model-value="model.ValTime.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.CAMPO___FLDS_YEAR____.isVisible">
					<q-control-wrapper
						v-show="controls.CAMPO___FLDS_YEAR____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.CAMPO___FLDS_YEAR____"
							v-on="controls.CAMPO___FLDS_YEAR____.handlers"
							:loading="controls.CAMPO___FLDS_YEAR____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.CAMPO___FLDS_YEAR____.isVisible"
								v-bind="controls.CAMPO___FLDS_YEAR____.props"
								@update:model-value="model.ValYear.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.CAMPO___FLDS_PRIMVIAG.isVisible || controls.CAMPO___FLDS_CONDITIO.isVisible">
					<q-control-wrapper
						v-show="controls.CAMPO___FLDS_PRIMVIAG.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-checkbox"
							v-bind="controls.CAMPO___FLDS_PRIMVIAG"
							v-on="controls.CAMPO___FLDS_PRIMVIAG.handlers"
							:loading="controls.CAMPO___FLDS_PRIMVIAG.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox-input
									v-if="controls.CAMPO___FLDS_PRIMVIAG.isVisible"
									v-bind="controls.CAMPO___FLDS_PRIMVIAG.props"
									v-on="controls.CAMPO___FLDS_PRIMVIAG.handlers" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.CAMPO___FLDS_CONDITIO.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.CAMPO___FLDS_CONDITIO"
							v-on="controls.CAMPO___FLDS_CONDITIO.handlers"
							:loading="controls.CAMPO___FLDS_CONDITIO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<template #label>
								<q-checkbox-input
									v-if="controls.CAMPO___FLDS_CONDITIO.isVisible"
									v-bind="controls.CAMPO___FLDS_CONDITIO.props"
									v-on="controls.CAMPO___FLDS_CONDITIO.handlers" />
							</template>
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.CAMPO___FLDS_CLASS___.isVisible">
					<q-control-wrapper
						v-show="controls.CAMPO___FLDS_CLASS___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.CAMPO___FLDS_CLASS___"
							v-on="controls.CAMPO___FLDS_CLASS___.handlers"
							:loading="controls.CAMPO___FLDS_CLASS___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-select
								v-if="controls.CAMPO___FLDS_CLASS___.isVisible"
								v-bind="controls.CAMPO___FLDS_CLASS___.props"
								@update:model-value="model.ValClass.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.CAMPO___FLDS_CLASSNUM.isVisible">
					<q-control-wrapper
						v-show="controls.CAMPO___FLDS_CLASSNUM.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.CAMPO___FLDS_CLASSNUM"
							v-on="controls.CAMPO___FLDS_CLASSNUM.handlers"
							:loading="controls.CAMPO___FLDS_CLASSNUM.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-select
								v-if="controls.CAMPO___FLDS_CLASSNUM.isVisible"
								v-bind="controls.CAMPO___FLDS_CLASSNUM.props"
								@update:model-value="model.ValClassnum.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.CAMPO___FLDS_LOGICENU.isVisible">
					<q-control-wrapper
						v-show="controls.CAMPO___FLDS_LOGICENU.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.CAMPO___FLDS_LOGICENU"
							v-on="controls.CAMPO___FLDS_LOGICENU.handlers"
							:loading="controls.CAMPO___FLDS_LOGICENU.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-toggle-input
								v-if="controls.CAMPO___FLDS_LOGICENU.isVisible"
								v-bind="controls.CAMPO___FLDS_LOGICENU.props"
								v-on="controls.CAMPO___FLDS_LOGICENU.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.CAMPO___FLDS_LOGO____.isVisible">
					<q-control-wrapper
						v-show="controls.CAMPO___FLDS_LOGO____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="q-image"
							v-bind="controls.CAMPO___FLDS_LOGO____"
							v-on="controls.CAMPO___FLDS_LOGO____.handlers"
							:loading="controls.CAMPO___FLDS_LOGO____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-image
								v-if="controls.CAMPO___FLDS_LOGO____.isVisible"
								v-bind="controls.CAMPO___FLDS_LOGO____.props"
								v-on="controls.CAMPO___FLDS_LOGO____.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.CAMPO___FLDS_ATTACH__.isVisible">
					<q-control-wrapper
						v-show="controls.CAMPO___FLDS_ATTACH__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.CAMPO___FLDS_ATTACH__"
							v-on="controls.CAMPO___FLDS_ATTACH__.handlers"
							:loading="controls.CAMPO___FLDS_ATTACH__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-document
								v-if="controls.CAMPO___FLDS_ATTACH__.isVisible"
								v-bind="controls.CAMPO___FLDS_ATTACH__.props"
								v-on="controls.CAMPO___FLDS_ATTACH__.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.CAMPO___FLDS_CREATUSE.isVisible || controls.CAMPO___FLDS_CREATDAT.isVisible || controls.CAMPO___FLDS_CREATHOU.isVisible">
					<q-control-wrapper
						v-show="controls.CAMPO___FLDS_CREATUSE.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.CAMPO___FLDS_CREATUSE"
							v-on="controls.CAMPO___FLDS_CREATUSE.handlers"
							:loading="controls.CAMPO___FLDS_CREATUSE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.CAMPO___FLDS_CREATUSE.props"
								@blur="onBlur(controls.CAMPO___FLDS_CREATUSE, model.ValCreatuse.value)"
								@change="model.ValCreatuse.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.CAMPO___FLDS_CREATDAT.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.CAMPO___FLDS_CREATDAT"
							v-on="controls.CAMPO___FLDS_CREATDAT.handlers"
							:loading="controls.CAMPO___FLDS_CREATDAT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.CAMPO___FLDS_CREATDAT.isVisible"
								v-bind="controls.CAMPO___FLDS_CREATDAT.props"
								:model-value="model.ValCreatdat.value"
								@reset-icon-click="model.ValCreatdat.fnUpdateValue(model.ValCreatdat.originalValue ?? new Date())"
								@update:model-value="model.ValCreatdat.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.CAMPO___FLDS_CREATHOU.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.CAMPO___FLDS_CREATHOU"
							v-on="controls.CAMPO___FLDS_CREATHOU.handlers"
							:loading="controls.CAMPO___FLDS_CREATHOU.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.CAMPO___FLDS_CREATHOU.isVisible"
								v-bind="controls.CAMPO___FLDS_CREATHOU.props"
								:model-value="model.ValCreathou.value"
								@reset-icon-click="model.ValCreathou.fnUpdateValue(model.ValCreathou.originalValue ?? new Date())"
								@update:model-value="model.ValCreathou.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.CAMPO___FLDS_CREATINS.isVisible">
					<q-control-wrapper
						v-show="controls.CAMPO___FLDS_CREATINS.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.CAMPO___FLDS_CREATINS"
							v-on="controls.CAMPO___FLDS_CREATINS.handlers"
							:loading="controls.CAMPO___FLDS_CREATINS.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.CAMPO___FLDS_CREATINS.isVisible"
								v-bind="controls.CAMPO___FLDS_CREATINS.props"
								:model-value="model.ValCreatins.value"
								@reset-icon-click="model.ValCreatins.fnUpdateValue(model.ValCreatins.originalValue ?? new Date())"
								@update:model-value="model.ValCreatins.fnUpdateValue($event ?? '')" />
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

	import FormViewModel from './QFormCampoViewModel.js'

	const requiredTextResources = ['QFormCampo', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS CAMPO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormCampo',

		components: {
			QSeeMoreCampoAeroName: defineAsyncComponent(() => import('@/views/forms/FormCampo/dbedits/CampoAeroNameSeeMore.vue')),
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
					name: 'CAMPO',
					location: 'form-CAMPO',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormCampo', false),

				interfaceMetadata: {
					id: 'QFormCampo', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'CAMPO',
					route: 'form-CAMPO',
					area: 'FLDS',
					primaryKey: 'ValCodflds',
					designation: computed(() => this.Resources.LISTA_DE_CAMPO62169),
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
						text: computed(() => vm.Resources.SAVE04165),
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
					CAMPO___AERO_NAME____: new fieldControlClass.LookupControl({
						modelField: 'TableAeroName',
						valueChangeEvent: 'fieldChange:aero.name',
						id: 'CAMPO___AERO_NAME____',
						name: 'NAME',
						size: 'xlarge',
						label: computed(() => this.Resources.AIRLINE57868),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodaero',
							dependencyEvent: 'fieldChange:flds.codaero'
						},
						dependentFields: () => ({
							set 'aero.codaero'(value) { vm.model.ValCodaero.updateValue(value) },
							set 'aero.name'(value) { vm.model.TableAeroName.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					CAMPO___FLDS_DESCRIP_: new fieldControlClass.MultilineStringControl({
						modelField: 'ValDescrip',
						valueChangeEvent: 'fieldChange:flds.descrip',
						id: 'CAMPO___FLDS_DESCRIP_',
						name: 'DESCRIP',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESCRIPTION07383),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						rows: 1,
						cols: 99,
						controlLimits: [
						],
					}, this),
					CAMPO___FLDS_NPASSAGE: new fieldControlClass.NumberControl({
						modelField: 'ValNpassage',
						valueChangeEvent: 'fieldChange:flds.npassage',
						id: 'CAMPO___FLDS_NPASSAGE',
						name: 'NPASSAGE',
						size: 'large',
						label: computed(() => this.Resources.PASSENGER_CAPACITY_O45867),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					CAMPO___FLDS_DURATION: new fieldControlClass.NumberControl({
						modelField: 'ValDuration',
						valueChangeEvent: 'fieldChange:flds.duration',
						id: 'CAMPO___FLDS_DURATION',
						name: 'DURATION',
						size: 'small',
						label: computed(() => this.Resources.TRIP_DURATION54761),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 2,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					CAMPO___FLDS_PRICE___: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrice',
						valueChangeEvent: 'fieldChange:flds.price',
						id: 'CAMPO___FLDS_PRICE___',
						name: 'PRICE',
						size: 'medium',
						label: computed(() => this.Resources.ROUNDED_TICKET_PRICE02323),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 3,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					CAMPO___FLDS_PRECOBIL: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrecobil',
						valueChangeEvent: 'fieldChange:flds.precobil',
						id: 'CAMPO___FLDS_PRECOBIL',
						name: 'PRECOBIL',
						size: 'medium',
						label: computed(() => this.Resources.TICKET_PRICE_AT_TENT46319),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 3,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					CAMPO___FLDS_DATE____: new fieldControlClass.DateControl({
						modelField: 'ValDate',
						valueChangeEvent: 'fieldChange:flds.date',
						id: 'CAMPO___FLDS_DATE____',
						name: 'DATE',
						size: 'small',
						label: computed(() => this.Resources.DEPARTURE_DATE__DD_M27418),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					CAMPO___FLDS_DATETIME: new fieldControlClass.DateControl({
						modelField: 'ValDatetime',
						valueChangeEvent: 'fieldChange:flds.datetime',
						id: 'CAMPO___FLDS_DATETIME',
						name: 'DATETIME',
						size: 'medium',
						label: computed(() => this.Resources.DEPARTURE_DATE__HOUR17284),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'dateTime',
						controlLimits: [
						],
					}, this),
					CAMPO___FLDS_DATESECO: new fieldControlClass.DateControl({
						modelField: 'ValDateseco',
						valueChangeEvent: 'fieldChange:flds.dateseco',
						id: 'CAMPO___FLDS_DATESECO',
						name: 'DATESECO',
						size: 'medium',
						label: computed(() => this.Resources.DEPARTURE_DATE__SECO42491),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'dateTimeSeconds',
						controlLimits: [
						],
					}, this),
					CAMPO___FLDS_TIME____: new fieldControlClass.TimeControl({
						modelField: 'ValTime',
						valueChangeEvent: 'fieldChange:flds.time',
						id: 'CAMPO___FLDS_TIME____',
						name: 'TIME',
						size: 'mini',
						label: computed(() => this.Resources.DEPARTURE_HOUR28390),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'time',
						controlLimits: [
						],
					}, this),
					CAMPO___FLDS_YEAR____: new fieldControlClass.NumberControl({
						modelField: 'ValYear',
						valueChangeEvent: 'fieldChange:flds.year',
						id: 'CAMPO___FLDS_YEAR____',
						name: 'YEAR',
						size: 'medium',
						label: computed(() => this.Resources.CREATION_YEAR_OF_THE06011),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 4,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					CAMPO___FLDS_PRIMVIAG: new fieldControlClass.BooleanControl({
						modelField: 'ValPrimviag',
						valueChangeEvent: 'fieldChange:flds.primviag',
						id: 'CAMPO___FLDS_PRIMVIAG',
						name: 'PRIMVIAG',
						size: 'small',
						label: computed(() => this.Resources._1AVIAGEM10982),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						controlLimits: [
						],
					}, this),
					CAMPO___FLDS_CONDITIO: new fieldControlClass.BooleanControl({
						modelField: 'ValConditio',
						valueChangeEvent: 'fieldChange:flds.conditio',
						id: 'CAMPO___FLDS_CONDITIO',
						name: 'CONDITIO',
						size: 'large',
						label: computed(() => this.Resources.HAVE_YOU_TRAVELED_BE53808),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						maxIntegers: 1,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					CAMPO___FLDS_CLASS___: new fieldControlClass.ArrayStringControl({
						modelField: 'ValClass',
						valueChangeEvent: 'fieldChange:flds.class',
						id: 'CAMPO___FLDS_CLASS___',
						name: 'CLASS',
						size: 'medium',
						label: computed(() => this.Resources.CLASS__ENUMERACAO_DE17340),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 2,
						labelId: 'label_CAMPO___FLDS_CLASS___',
						arrayName: 'CLASS',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					CAMPO___FLDS_CLASSNUM: new fieldControlClass.ArrayNumberControl({
						modelField: 'ValClassnum',
						valueChangeEvent: 'fieldChange:flds.classnum',
						id: 'CAMPO___FLDS_CLASSNUM',
						name: 'CLASSNUM',
						size: 'large',
						label: computed(() => this.Resources.CLASSE__ENUMERACAO_N29443),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 1,
						maxDecimals: 0,
						arrayName: 'CLASSNUM',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					CAMPO___FLDS_LOGICENU: new fieldControlClass.ArrayBooleanControl({
						modelField: 'ValLogicenu',
						valueChangeEvent: 'fieldChange:flds.logicenu',
						id: 'CAMPO___FLDS_LOGICENU',
						name: 'LOGICENU',
						size: 'medium',
						label: computed(() => this.Resources._1ST_TRIP__LOGICAL_E36923),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 1,
						maxDecimals: 0,
						arrayName: 'PRIMVIAG',
						trueLabel: computed(() => this.Resources.YES34196),
						falseLabel: computed(() => this.Resources.NO57340),
						controlLimits: [
						],
					}, this),
					CAMPO___FLDS_LOGO____: new fieldControlClass.ImageControl({
						modelField: 'ValLogo',
						valueChangeEvent: 'fieldChange:flds.logo',
						id: 'CAMPO___FLDS_LOGO____',
						name: 'LOGO',
						size: 'medium',
						label: computed(() => this.Resources.LOGO62483),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						height: 50,
						width: 100,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.LOGO62483)),
						controlLimits: [
						],
					}, this),
					CAMPO___FLDS_ATTACH__: new fieldControlClass.DocumentControl({
						modelField: 'ValAttach',
						valueChangeEvent: 'fieldChange:flds.attach',
						id: 'CAMPO___FLDS_ATTACH__',
						name: 'ATTACH',
						size: 'xxlarge',
						label: computed(() => this.Resources.ATTACHMENTS19612),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						versioningIsOn: true,
						viewType: qEnums.documentViewTypeMode.print,
						extensions: [],
						controlLimits: [
						],
					}, this),
					CAMPO___FLDS_CREATUSE: new fieldControlClass.StringControl({
						modelField: 'ValCreatuse',
						valueChangeEvent: 'fieldChange:flds.creatuse',
						id: 'CAMPO___FLDS_CREATUSE',
						name: 'CREATUSE',
						size: 'medium',
						label: computed(() => this.Resources.CREATED_BY12292),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 20,
						labelId: 'label_CAMPO___FLDS_CREATUSE',
						controlLimits: [
						],
					}, this),
					CAMPO___FLDS_CREATDAT: new fieldControlClass.DateControl({
						modelField: 'ValCreatdat',
						valueChangeEvent: 'fieldChange:flds.creatdat',
						id: 'CAMPO___FLDS_CREATDAT',
						name: 'CREATDAT',
						size: 'medium',
						label: computed(() => this.Resources.CREATION_DATE__DD_MM48834),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					CAMPO___FLDS_CREATHOU: new fieldControlClass.TimeControl({
						modelField: 'ValCreathou',
						valueChangeEvent: 'fieldChange:flds.creathou',
						id: 'CAMPO___FLDS_CREATHOU',
						name: 'CREATHOU',
						size: 'small',
						label: computed(() => this.Resources.CREATION_DATE32161),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'time',
						controlLimits: [
						],
					}, this),
					CAMPO___FLDS_CREATINS: new fieldControlClass.DateControl({
						modelField: 'ValCreatins',
						valueChangeEvent: 'fieldChange:flds.creatins',
						id: 'CAMPO___FLDS_CREATINS',
						name: 'CREATINS',
						size: 'medium',
						label: computed(() => this.Resources.COMPLETE_CREATION_DA42963),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						dateTimeType: 'dateTimeSeconds',
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
					Aero: {
						get ValName() { return vm.model.TableAeroName.value },
						set ValName(value) { vm.model.TableAeroName.updateValue(value) },
					},
					Flds: {
						get ValAttach() { return vm.model.ValAttach.value },
						set ValAttach(value) { vm.model.ValAttach.updateValue(value) },
						get ValClass() { return vm.model.ValClass.value },
						set ValClass(value) { vm.model.ValClass.updateValue(value) },
						get ValClassnum() { return vm.model.ValClassnum.value },
						set ValClassnum(value) { vm.model.ValClassnum.updateValue(value) },
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
						get ValPrimviag() { return vm.model.ValPrimviag.value },
						set ValPrimviag(value) { vm.model.ValPrimviag.updateValue(value) },
						get ValTblcond() { return vm.model.ValTblcond.value },
						set ValTblcond(value) { vm.model.ValTblcond.updateValue(value) },
						get ValTime() { return vm.model.ValTime.value },
						set ValTime(value) { vm.model.ValTime.updateValue(value) },
						get ValYear() { return vm.model.ValYear.value },
						set ValYear(value) { vm.model.ValYear.updateValue(value) },
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
// USE /[MANUAL GQT FORM_CODEJS CAMPO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT CAMPO]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS CAMPO]/
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
// USE /[MANUAL GQT FORM_LOADED_JS CAMPO]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS CAMPO]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS CAMPO]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS CAMPO]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS CAMPO]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS CAMPO]/
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
// USE /[MANUAL GQT AFTER_DEL_JS CAMPO]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS CAMPO]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS CAMPO]/
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
// USE /[MANUAL GQT DLGUPDT CAMPO]/
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
// USE /[MANUAL GQT CTRLBLR CAMPO]/
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
// USE /[MANUAL GQT CTRLUPD CAMPO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS CAMPO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
