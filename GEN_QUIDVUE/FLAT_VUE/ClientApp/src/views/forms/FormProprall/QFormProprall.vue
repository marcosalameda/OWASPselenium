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
			data-key="PROPRALL"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.PROPRALLPSEUDNOVOGR03.isVisible">
					<q-control-wrapper
						v-show="controls.PROPRALLPSEUDNOVOGR03.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="PROPRALLPSEUDNOVOGR03"
							v-bind="controls.PROPRALLPSEUDNOVOGR03"
							:is-visible="controls.PROPRALLPSEUDNOVOGR03.isVisible">
							<!-- Start PROPRALLPSEUDNOVOGR03 -->
							<q-row-container v-show="controls.PROPRALLPROPRPHOTOGRA.isVisible">
								<q-control-wrapper
									v-show="controls.PROPRALLPROPRPHOTOGRA.isVisible"
									class="control-join-group">
									<base-input-structure
										class="q-image"
										v-bind="controls.PROPRALLPROPRPHOTOGRA"
										v-on="controls.PROPRALLPROPRPHOTOGRA.handlers"
										:loading="controls.PROPRALLPROPRPHOTOGRA.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-image
											v-if="controls.PROPRALLPROPRPHOTOGRA.isVisible"
											v-bind="controls.PROPRALLPROPRPHOTOGRA.props"
											v-on="controls.PROPRALLPROPRPHOTOGRA.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End PROPRALLPSEUDNOVOGR03 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.PROPRALLPSEUDNOVOGR02.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.PROPRALLPSEUDNOVOGR02.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="PROPRALLPSEUDNOVOGR02"
							v-bind="controls.PROPRALLPSEUDNOVOGR02"
							:is-visible="controls.PROPRALLPSEUDNOVOGR02.isVisible">
							<!-- Start PROPRALLPSEUDNOVOGR02 -->
							<q-row-container v-show="controls.PROPRALLPROPRNAME____.isVisible || controls.PROPRALLPROPRPRECOEST.isVisible || controls.PROPRALLTPPROTPPROPRI.isVisible || controls.PROPRALLPROPRMOBILADA.isVisible">
								<q-control-wrapper
									v-show="controls.PROPRALLPROPRNAME____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PROPRALLPROPRNAME____"
										v-on="controls.PROPRALLPROPRNAME____.handlers"
										:loading="controls.PROPRALLPROPRNAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-text-field
											v-bind="controls.PROPRALLPROPRNAME____.props"
											:model-value="model.ValName.value"
											@update:model-value="model.ValName.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PROPRALLPROPRPRECOEST.isVisible || controls.PROPRALLTPPROTPPROPRI.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PROPRALLPROPRPRECOEST"
										v-on="controls.PROPRALLPROPRPRECOEST.handlers"
										:loading="controls.PROPRALLPROPRPRECOEST.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-numeric-input
											v-if="controls.PROPRALLPROPRPRECOEST.isVisible"
											v-bind="controls.PROPRALLPROPRPRECOEST"
											:model-value="model.ValPrecoest.value"
											@update:model-value="model.ValPrecoest.fnUpdateValue" />
									</base-input-structure>
									<base-input-structure
										class="i-text"
										v-bind="controls.PROPRALLTPPROTPPROPRI"
										v-on="controls.PROPRALLTPPROTPPROPRI.handlers"
										:loading="controls.PROPRALLTPPROTPPROPRI.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-lookup
											v-if="controls.PROPRALLTPPROTPPROPRI.isVisible"
											v-bind="controls.PROPRALLTPPROTPPROPRI.props"
											:model-value="model.ValCodtppro.value"
											v-on="controls.PROPRALLTPPROTPPROPRI.handlers"
											@update:model-value="model.ValCodtppro.fnUpdateValue" />
										<q-see-more-propralltpprotppropri
											v-if="controls.PROPRALLTPPROTPPROPRI.seeMoreIsVisible"
											v-bind="controls.PROPRALLTPPROTPPROPRI.seeMoreParams"
											v-on="controls.PROPRALLTPPROTPPROPRI.handlers" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PROPRALLPROPRMOBILADA.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.PROPRALLPROPRMOBILADA"
										v-on="controls.PROPRALLPROPRMOBILADA.handlers"
										:loading="controls.PROPRALLPROPRMOBILADA.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<template #label>
											<q-checkbox-input
												v-if="controls.PROPRALLPROPRMOBILADA.isVisible"
												id="PROPRALLPROPRMOBILADA"
												size="small"
												:model-value="model.ValMobilada.value"
												:readonly="controls.PROPRALLPROPRMOBILADA.readonly"
												@update:model-value="model.ValMobilada.fnUpdateValue" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PROPRALLPROPRQTD_WC__.isVisible || controls.PROPRALLPROPRQTDQUART.isVisible || controls.PROPRALLPROPRM2______.isVisible || controls.PROPRALLPROPRDTDISPON.isVisible">
								<q-control-wrapper
									v-show="controls.PROPRALLPROPRQTD_WC__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PROPRALLPROPRQTD_WC__"
										v-on="controls.PROPRALLPROPRQTD_WC__.handlers"
										:loading="controls.PROPRALLPROPRQTD_WC__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-numeric-input
											v-if="controls.PROPRALLPROPRQTD_WC__.isVisible"
											v-bind="controls.PROPRALLPROPRQTD_WC__"
											:model-value="model.ValQtd_wc.value"
											@update:model-value="model.ValQtd_wc.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PROPRALLPROPRQTDQUART.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PROPRALLPROPRQTDQUART"
										v-on="controls.PROPRALLPROPRQTDQUART.handlers"
										:loading="controls.PROPRALLPROPRQTDQUART.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-numeric-input
											v-if="controls.PROPRALLPROPRQTDQUART.isVisible"
											v-bind="controls.PROPRALLPROPRQTDQUART"
											:model-value="model.ValQtdquart.value"
											@update:model-value="model.ValQtdquart.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PROPRALLPROPRM2______.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PROPRALLPROPRM2______"
										v-on="controls.PROPRALLPROPRM2______.handlers"
										:loading="controls.PROPRALLPROPRM2______.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-numeric-input
											v-if="controls.PROPRALLPROPRM2______.isVisible"
											v-bind="controls.PROPRALLPROPRM2______"
											:model-value="model.ValM2.value"
											@update:model-value="model.ValM2.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PROPRALLPROPRDTDISPON.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PROPRALLPROPRDTDISPON"
										v-on="controls.PROPRALLPROPRDTDISPON.handlers"
										:loading="controls.PROPRALLPROPRDTDISPON.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-datetime-input
											v-if="controls.PROPRALLPROPRDTDISPON.isVisible"
											v-bind="controls.PROPRALLPROPRDTDISPON"
											format="Date"
											:model-value="model.ValDtdispon.value"
											@update:model-value="model.ValDtdispon.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PROPRALLPROPRDESCRIPT.isVisible">
								<q-control-wrapper
									v-show="controls.PROPRALLPROPRDESCRIPT.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PROPRALLPROPRDESCRIPT"
										v-on="controls.PROPRALLPROPRDESCRIPT.handlers"
										:loading="controls.PROPRALLPROPRDESCRIPT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-text-editor
											v-if="controls.PROPRALLPROPRDESCRIPT.isVisible"
											v-bind="controls.PROPRALLPROPRDESCRIPT"
											:model-value="model.ValDescript.value"
											:rows="3"
											:cols="20"
											v-on="controls.PROPRALLPROPRDESCRIPT.handlers"
											@update:model-value="model.ValDescript.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PROPRALLPESSONAME____.isVisible">
								<q-control-wrapper
									v-show="controls.PROPRALLPESSONAME____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PROPRALLPESSONAME____"
										v-on="controls.PROPRALLPESSONAME____.handlers"
										:loading="controls.PROPRALLPESSONAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-lookup
											v-if="controls.PROPRALLPESSONAME____.isVisible"
											v-bind="controls.PROPRALLPESSONAME____.props"
											:model-value="model.ValCodpesso.value"
											v-on="controls.PROPRALLPESSONAME____.handlers"
											@update:model-value="model.ValCodpesso.fnUpdateValue" />
										<q-see-more-proprallpessoname
											v-if="controls.PROPRALLPESSONAME____.seeMoreIsVisible"
											v-bind="controls.PROPRALLPESSONAME____.seeMoreParams"
											v-on="controls.PROPRALLPESSONAME____.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End PROPRALLPSEUDNOVOGR02 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.PROPRALLPSEUDNOVOGR01.isVisible || controls.PROPRALLPROPRCOORDGEO.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.PROPRALLPSEUDNOVOGR01.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="PROPRALLPSEUDNOVOGR01"
							v-bind="controls.PROPRALLPSEUDNOVOGR01"
							:is-visible="controls.PROPRALLPSEUDNOVOGR01.isVisible">
							<!-- Start PROPRALLPSEUDNOVOGR01 -->
							<q-row-container v-show="controls.PROPRALLCNTRYCOUNTRY_.isVisible">
								<q-control-wrapper
									v-show="controls.PROPRALLCNTRYCOUNTRY_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PROPRALLCNTRYCOUNTRY_"
										v-on="controls.PROPRALLCNTRYCOUNTRY_.handlers"
										:loading="controls.PROPRALLCNTRYCOUNTRY_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-lookup
											v-if="controls.PROPRALLCNTRYCOUNTRY_.isVisible"
											v-bind="controls.PROPRALLCNTRYCOUNTRY_.props"
											:model-value="model.ValCodcntry.value"
											v-on="controls.PROPRALLCNTRYCOUNTRY_.handlers"
											@update:model-value="model.ValCodcntry.fnUpdateValue" />
										<q-see-more-proprallcntrycountry
											v-if="controls.PROPRALLCNTRYCOUNTRY_.seeMoreIsVisible"
											v-bind="controls.PROPRALLCNTRYCOUNTRY_.seeMoreParams"
											v-on="controls.PROPRALLCNTRYCOUNTRY_.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PROPRALLREGIOREGIAO__.isVisible || controls.PROPRALLPROPRENDERECO.isVisible">
								<q-control-wrapper
									v-show="controls.PROPRALLREGIOREGIAO__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PROPRALLREGIOREGIAO__"
										v-on="controls.PROPRALLREGIOREGIAO__.handlers"
										:loading="controls.PROPRALLREGIOREGIAO__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-lookup
											v-if="controls.PROPRALLREGIOREGIAO__.isVisible"
											v-bind="controls.PROPRALLREGIOREGIAO__.props"
											:model-value="model.ValCodregia.value"
											v-on="controls.PROPRALLREGIOREGIAO__.handlers"
											@update:model-value="model.ValCodregia.fnUpdateValue" />
										<q-see-more-proprallregioregiao
											v-if="controls.PROPRALLREGIOREGIAO__.seeMoreIsVisible"
											v-bind="controls.PROPRALLREGIOREGIAO__.seeMoreParams"
											v-on="controls.PROPRALLREGIOREGIAO__.handlers" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PROPRALLPROPRENDERECO.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-textarea"
										v-bind="controls.PROPRALLPROPRENDERECO"
										v-on="controls.PROPRALLPROPRENDERECO.handlers"
										:loading="controls.PROPRALLPROPRENDERECO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-textarea-input
											v-if="controls.PROPRALLPROPRENDERECO.isVisible"
											id="PROPRALLPROPRENDERECO"
											size="xxlarge"
											:model-value="model.ValEndereco.value"
											:rows="2"
											:cols="85"
											:is-required="controls.PROPRALLPROPRENDERECO.isRequired"
											:readonly="controls.PROPRALLPROPRENDERECO.readonly"
											:placeholder="controls.PROPRALLPROPRENDERECO.placeholder"
											@update:model-value="model.ValEndereco.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PROPRALLPROPRLOCALIDA.isVisible">
								<q-control-wrapper
									v-show="controls.PROPRALLPROPRLOCALIDA.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PROPRALLPROPRLOCALIDA"
										v-on="controls.PROPRALLPROPRLOCALIDA.handlers"
										:loading="controls.PROPRALLPROPRLOCALIDA.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-text-field
											v-bind="controls.PROPRALLPROPRLOCALIDA.props"
											:model-value="model.ValLocalida.value"
											@update:model-value="model.ValLocalida.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PROPRALLPROPRPOSTALCO.isVisible || controls.PROPRALLPROPRPOSTALLO.isVisible">
								<q-control-wrapper
									v-show="controls.PROPRALLPROPRPOSTALCO.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PROPRALLPROPRPOSTALCO"
										v-on="controls.PROPRALLPROPRPOSTALCO.handlers"
										:loading="controls.PROPRALLPROPRPOSTALCO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-text-field
											v-bind="controls.PROPRALLPROPRPOSTALCO.props"
											:model-value="model.ValPostalco.value"
											@update:model-value="model.ValPostalco.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PROPRALLPROPRPOSTALLO.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PROPRALLPROPRPOSTALLO"
										v-on="controls.PROPRALLPROPRPOSTALLO.handlers"
										:loading="controls.PROPRALLPROPRPOSTALLO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-text-field
											v-bind="controls.PROPRALLPROPRPOSTALLO.props"
											:model-value="model.ValPostallo.value"
											@update:model-value="model.ValPostallo.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End PROPRALLPSEUDNOVOGR01 -->
						</q-group-box-container>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.PROPRALLPROPRCOORDGEO.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PROPRALLPROPRCOORDGEO"
							v-on="controls.PROPRALLPROPRCOORDGEO.handlers"
							:loading="controls.PROPRALLPROPRCOORDGEO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-text-field
								v-bind="controls.PROPRALLPROPRCOORDGEO.props"
								:model-value="model.ValCoordgeo.value"
								@update:model-value="model.ValCoordgeo.fnUpdateValue" />
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
				default: () => {
					return {
						name: 'PROPRALL',
						location: 'form-PROPRALL',
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
					PROPRALLPSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'PROPRALLPSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.PHOTO51874),
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
					PROPRALLPROPRPHOTOGRA: new fieldControlClass.ImageControl({
						modelField: 'ValPhotogra',
						valueChangeEvent: 'fieldChange:propr.photogra',
						id: 'PROPRALLPROPRPHOTOGRA',
						name: 'PHOTOGRA',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.PHOTO51874),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR03',
						height: 50,
						width: 100,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPRALLPSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'PROPRALLPSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.IDENTIFICATION37731),
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
					PROPRALLPROPRNAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:propr.name',
						id: 'PROPRALLPROPRNAME____',
						name: 'NAME',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.REAL_ESTATE15399),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR02',
						maxLength: 85,
						labelId: 'label_PROPRALLPROPRNAME____',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRPRECOEST: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrecoest',
						valueChangeEvent: 'fieldChange:propr.precoest',
						maxIntegers: 9,
						maxDecimals: 2,
						id: 'PROPRALLPROPRPRECOEST',
						name: 'PRECOEST',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.ESTIMATED_PRICE02986),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR02',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPRALLTPPROTPPROPRI: new fieldControlClass.LookupControl({
						modelField: 'TableTpproTppropri',
						valueChangeEvent: 'fieldChange:tppro.tppropri',
						id: 'PROPRALLTPPROTPPROPRI',
						name: 'TPPROPRI',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.PROPERTY_TYPE33991),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR02',
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodtppro',
							dependencyEvent: 'fieldChange:propr.codtppro'
						},
						dependentFields: () => {
							return {
								set 'tppro.codtppro'(value) { vm.model.ValCodtppro.updateValue(value) },
								set 'tppro.tppropri'(value) { vm.model.TableTpproTppropri.updateValue(value) },
							}
						},
						insertEnabled: true,
						supportForm: 'TPPRO',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
					}, this),
					PROPRALLPSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'PROPRALLPSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.LOCALIZATION34148),
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
					PROPRALLPROPRMOBILADA: new fieldControlClass.BooleanControl({
						modelField: 'ValMobilada',
						valueChangeEvent: 'fieldChange:propr.mobilada',
						id: 'PROPRALLPROPRMOBILADA',
						name: 'MOBILADA',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.FURNISHED37431),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'PROPRALLPSEUDNOVOGR02',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPRALLCNTRYCOUNTRY_: new fieldControlClass.LookupControl({
						modelField: 'TableCntryCountry',
						valueChangeEvent: 'fieldChange:cntry.country',
						id: 'PROPRALLCNTRYCOUNTRY_',
						name: 'COUNTRY',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.COUNTRY64133),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR01',
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodcntry',
							dependencyEvent: 'fieldChange:propr.codcntry'
						},
						dependentFields: () => {
							return {
								set 'cntry.codcntry'(value) { vm.model.ValCodcntry.updateValue(value) },
								set 'cntry.country'(value) { vm.model.TableCntryCountry.updateValue(value) },
							}
						},
						insertEnabled: true,
						supportForm: 'PAIS',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
					}, this),
					PROPRALLREGIOREGIAO__: new fieldControlClass.LookupControl({
						modelField: 'TableRegioRegiao',
						valueChangeEvent: 'fieldChange:regio.regiao',
						id: 'PROPRALLREGIOREGIAO__',
						name: 'REGIAO',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.REGION12723),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR01',
						mustBeFilled: false,
						controlLimits: [
							{
								identifier: ['cntry', 'propr.codcntry'],
								dependencyEvents: ['fieldChange:propr.codcntry'],
								dependencyField: 'PROPR.CODCNTRY',
								fnValueSelector: (model) => model.ValCodcntry.value
							},
						],
						lookupKeyModelField: {
							name: 'ValCodregia',
							dependencyEvent: 'fieldChange:propr.codregia'
						},
						dependentFields: () => {
							return {
								set 'regio.codregia'(value) { vm.model.ValCodregia.updateValue(value) },
								set 'regio.regiao'(value) { vm.model.TableRegioRegiao.updateValue(value) },
							}
						},
						insertEnabled: true,
						supportForm: 'REGIA',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
					}, this),
					PROPRALLPROPRENDERECO: new fieldControlClass.StringControl({
						modelField: 'ValEndereco',
						valueChangeEvent: 'fieldChange:propr.endereco',
						id: 'PROPRALLPROPRENDERECO',
						name: 'ENDERECO',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.ADDRESS04342),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR01',
						maxLength: 85,
						labelId: 'label_PROPRALLPROPRENDERECO',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRLOCALIDA: new fieldControlClass.StringControl({
						modelField: 'ValLocalida',
						valueChangeEvent: 'fieldChange:propr.localida',
						id: 'PROPRALLPROPRLOCALIDA',
						name: 'LOCALIDA',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.LOCALIZATION34148),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR01',
						maxLength: 50,
						labelId: 'label_PROPRALLPROPRLOCALIDA',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRPOSTALCO: new fieldControlClass.StringControl({
						modelField: 'ValPostalco',
						valueChangeEvent: 'fieldChange:propr.postalco',
						id: 'PROPRALLPROPRPOSTALCO',
						name: 'POSTALCO',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.ZIPCODE21021),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR01',
						maxLength: 20,
						labelId: 'label_PROPRALLPROPRPOSTALCO',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRPOSTALLO: new fieldControlClass.StringControl({
						modelField: 'ValPostallo',
						valueChangeEvent: 'fieldChange:propr.postallo',
						id: 'PROPRALLPROPRPOSTALLO',
						name: 'POSTALLO',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.ZIPCODE21021),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR01',
						maxLength: 50,
						labelId: 'label_PROPRALLPROPRPOSTALLO',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRQTD_WC__: new fieldControlClass.NumberControl({
						modelField: 'ValQtd_wc',
						valueChangeEvent: 'fieldChange:propr.qtd_wc',
						maxIntegers: 6,
						maxDecimals: 0,
						id: 'PROPRALLPROPRQTD_WC__',
						name: 'QTD_WC',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.BATHROOM12866),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR02',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRQTDQUART: new fieldControlClass.NumberControl({
						modelField: 'ValQtdquart',
						valueChangeEvent: 'fieldChange:propr.qtdquart',
						maxIntegers: 6,
						maxDecimals: 0,
						id: 'PROPRALLPROPRQTDQUART',
						name: 'QTDQUART',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.ROOMS06809),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR02',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRM2______: new fieldControlClass.NumberControl({
						modelField: 'ValM2',
						valueChangeEvent: 'fieldChange:propr.m2',
						maxIntegers: 6,
						maxDecimals: 0,
						id: 'PROPRALLPROPRM2______',
						name: 'M2',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.SQUARE_METERS28913),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR02',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRDTDISPON: new fieldControlClass.DateControl({
						modelField: 'ValDtdispon',
						valueChangeEvent: 'fieldChange:propr.dtdispon',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'PROPRALLPROPRDTDISPON',
						name: 'DTDISPON',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.AVAILABLE_FROM53703),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR02',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPRALLPROPRDESCRIPT: new fieldControlClass.TextEditorControl({
						modelField: 'ValDescript',
						valueChangeEvent: 'fieldChange:propr.descript',
						id: 'PROPRALLPROPRDESCRIPT',
						name: 'DESCRIPT',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.DESCRIPTION07383),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR02',
						mustBeFilled: false,
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
						hasLabel: true,
						label: computed(() => this.Resources.GEOGRAPHIC_COORDINAT42880),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						labelId: 'label_PROPRALLPROPRCOORDGEO',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PROPRALLPESSONAME____: new fieldControlClass.LookupControl({
						modelField: 'TablePessoName',
						valueChangeEvent: 'fieldChange:pesso.name',
						id: 'PROPRALLPESSONAME____',
						name: 'NAME',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.SELLER36870),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPRALLPSEUDNOVOGR02',
						mustBeFilled: false,
						controlLimits: [
							{
								identifier: ['cntry', 'propr.codcntry'],
								dependencyEvents: ['fieldChange:propr.codcntry'],
								dependencyField: 'PROPR.CODCNTRY',
								fnValueSelector: (model) => model.ValCodcntry.value
							},
						],
						lookupKeyModelField: {
							name: 'ValCodpesso',
							dependencyEvent: 'fieldChange:propr.codpesso'
						},
						dependentFields: () => {
							return {
								set 'pesso.codpesso'(value) { vm.model.ValCodpesso.updateValue(value) },
								set 'pesso.name'(value) { vm.model.TablePessoName.updateValue(value) },
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
// USE /[MANUAL GQT FORM_CODEJS PROPRALL]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS PROPRALL]/
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
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

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
				for (let trigger of triggers)
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
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

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
				let redirectPage = true // Set to 'false' to cancel page redirect.

				// Execute the "After save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterSave)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT AFTER_SAVE_JS PROPRALL]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS PROPRALL]/
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
// USE /[MANUAL GQT AFTER_DEL_JS PROPRALL]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS PROPRALL]/
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
		},

		watch: {
		}
	}
</script>
