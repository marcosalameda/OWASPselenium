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
									:label="btn.label"
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
				v-if="layoutConfig.FormAnchorsPosition === 'form-header' && visibleGroups.length > 0"
				:anchors="anchorGroups"
				:controls="visibleControls"
				@focus-control="(...args) => focusControl(...args)" />
		</div>
	</teleport>

	<teleport
		v-if="formModalIsReady && showFormBody"
		:to="`#${uiContainersId.body}`"
		:disabled="!isPopup || isNested">
		<q-validation-summary
			:messages="validationErrors"
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
			data-key="PROPE17"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.PROPE17_PROPEORDER___.isVisible">
					<q-control-wrapper
						v-show="controls.PROPE17_PROPEORDER___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.PROPE17_PROPEORDER___"
							v-on="controls.PROPE17_PROPEORDER___.handlers"
							:loading="controls.PROPE17_PROPEORDER___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.PROPE17_PROPEORDER___.isVisible"
								v-bind="controls.PROPE17_PROPEORDER___.props"
								@update:model-value="model.ValOrder.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PROPE17_PSEUDMAININF_.isVisible">
					<q-control-wrapper
						v-show="controls.PROPE17_PSEUDMAININF_.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="PROPE17_PSEUDMAININF_"
							v-bind="controls.PROPE17_PSEUDMAININF_"
							:is-visible="controls.PROPE17_PSEUDMAININF_.isVisible">
							<!-- Start PROPE17_PSEUDMAININF_ -->
							<q-row-container v-show="controls.PROPE17_PROPEPHOTO___.isVisible">
								<q-control-wrapper
									v-show="controls.PROPE17_PROPEPHOTO___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="q-image"
										v-bind="controls.PROPE17_PROPEPHOTO___"
										v-on="controls.PROPE17_PROPEPHOTO___.handlers"
										:loading="controls.PROPE17_PROPEPHOTO___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-image
											v-if="controls.PROPE17_PROPEPHOTO___.isVisible"
											v-bind="controls.PROPE17_PROPEPHOTO___.props"
											v-on="controls.PROPE17_PROPEPHOTO___.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PROPE17_PROPETITLE___.isVisible">
								<q-control-wrapper
									v-show="controls.PROPE17_PROPETITLE___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PROPE17_PROPETITLE___"
										v-on="controls.PROPE17_PROPETITLE___.handlers"
										:loading="controls.PROPE17_PROPETITLE___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.PROPE17_PROPETITLE___.props"
											:model-value="model.ValTitle.value"
											@blur="onBlur(controls.PROPE17_PROPETITLE___, model.ValTitle.value)"
											@change="model.ValTitle.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PROPE17_PROPEPRICE___.isVisible">
								<q-control-wrapper
									v-show="controls.PROPE17_PROPEPRICE___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PROPE17_PROPEPRICE___"
										v-on="controls.PROPE17_PROPEPRICE___.handlers"
										:loading="controls.PROPE17_PROPEPRICE___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.PROPE17_PROPEPRICE___.isVisible"
											v-bind="controls.PROPE17_PROPEPRICE___.props"
											@update:model-value="model.ValPrice.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PROPE17_PROPEDESCRIPT.isVisible">
								<q-control-wrapper
									v-show="controls.PROPE17_PROPEDESCRIPT.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-textarea"
										v-bind="controls.PROPE17_PROPEDESCRIPT"
										v-on="controls.PROPE17_PROPEDESCRIPT.handlers"
										:loading="controls.PROPE17_PROPEDESCRIPT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-textarea-input
											v-if="controls.PROPE17_PROPEDESCRIPT.isVisible"
											v-bind="controls.PROPE17_PROPEDESCRIPT.props"
											id="PROPE17_PROPEDESCRIPT"
											:model-value="model.ValDescript.value"
											:rows="1"
											:cols="99"
											@update:model-value="model.ValDescript.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End PROPE17_PSEUDMAININF_ -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PROPE17_PSEUDACC01___.isVisible || controls.PROPE17_PSEUDPROPHOTO.isVisible">
					<q-control-wrapper
						v-show="controls.PROPE17_PSEUDACC01___.isVisible"
						class="control-join-group">
						<q-accordion-container
							id="PROPE17_PSEUDACC01___"
							v-bind="controls.PROPE17_PSEUDACC01___"
							v-on="controls.PROPE17_PSEUDACC01___.handlers"
							v-slot="{ onStateChanged }">
							<!-- Start PROPE17_PSEUDACC01___ -->
							<q-group-collapsible
								id="PROPE17_PSEUDLOCALIZA"
								v-bind="controls.PROPE17_PSEUDLOCALIZA"
								v-on="controls.PROPE17_PSEUDLOCALIZA.handlers"
								@state-changed="(state, groupId) => onStateChanged(state, groupId)">
								<!-- Start PROPE17_PSEUDLOCALIZA -->
								<q-row-container v-show="controls.PROPE17_CITY_CITY____.isVisible">
									<q-control-wrapper
										v-show="controls.PROPE17_CITY_CITY____.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.PROPE17_CITY_CITY____"
											v-on="controls.PROPE17_CITY_CITY____.handlers"
											:loading="controls.PROPE17_CITY_CITY____.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-lookup
												v-if="controls.PROPE17_CITY_CITY____.isVisible"
												v-bind="controls.PROPE17_CITY_CITY____.props"
												v-on="controls.PROPE17_CITY_CITY____.handlers" />
											<q-see-more-prope17-city-city
												v-if="controls.PROPE17_CITY_CITY____.seeMoreIsVisible"
												v-bind="controls.PROPE17_CITY_CITY____.seeMoreParams"
												v-on="controls.PROPE17_CITY_CITY____.handlers" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.PROPE17_CTRY_COUNTRY_.isVisible">
									<q-control-wrapper
										v-show="controls.PROPE17_CTRY_COUNTRY_.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.PROPE17_CTRY_COUNTRY_"
											v-on="controls.PROPE17_CTRY_COUNTRY_.handlers"
											:loading="controls.PROPE17_CTRY_COUNTRY_.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.PROPE17_CTRY_COUNTRY_.props"
												:model-value="model.CityCtryValCountry.value" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<!-- End PROPE17_PSEUDLOCALIZA -->
							</q-group-collapsible>
							<q-group-collapsible
								id="PROPE17_PSEUDDETAILS_"
								v-bind="controls.PROPE17_PSEUDDETAILS_"
								v-on="controls.PROPE17_PSEUDDETAILS_.handlers"
								@state-changed="(state, groupId) => onStateChanged(state, groupId)">
								<!-- Start PROPE17_PSEUDDETAILS_ -->
								<q-row-container v-show="controls.PROPE17_PROPEBUILDTYP.isVisible || controls.PROPE17_PROPETYPOLOGY.isVisible">
									<q-control-wrapper
										v-show="controls.PROPE17_PROPEBUILDTYP.isVisible || controls.PROPE17_PROPETYPOLOGY.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.PROPE17_PROPEBUILDTYP"
											v-on="controls.PROPE17_PROPEBUILDTYP.handlers"
											:loading="controls.PROPE17_PROPEBUILDTYP.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-select
												v-if="controls.PROPE17_PROPEBUILDTYP.isVisible"
												v-bind="controls.PROPE17_PROPEBUILDTYP.props"
												:model-value="model.ValBuildtyp.value"
												@update:model-value="model.ValBuildtyp.fnUpdateValue" />
										</base-input-structure>
										<base-input-structure
											class="i-radio-container"
											v-bind="controls.PROPE17_PROPETYPOLOGY"
											v-on="controls.PROPE17_PROPETYPOLOGY.handlers"
											:label-position="labelAlignment.topleft"
											:loading="controls.PROPE17_PROPETYPOLOGY.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-radio-group
												v-if="controls.PROPE17_PROPETYPOLOGY.isVisible"
												id="PROPE17_PROPETYPOLOGY"
												:model-value="model.ValTypology.value"
												deselect-radio
												:label-left-side="controls.PROPE17_PROPETYPOLOGY.labelPosition === labelAlignment.left"
												:number-of-columns="controls.PROPE17_PROPETYPOLOGY.columnNumber"
												:is-required="controls.PROPE17_PROPETYPOLOGY.isRequired"
												:readonly="controls.PROPE17_PROPETYPOLOGY.readonly"
												:options-list="controls.PROPE17_PROPETYPOLOGY.items"
												@update:model-value="model.ValTypology.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.PROPE17_PROPESIZE____.isVisible">
									<q-control-wrapper
										v-show="controls.PROPE17_PROPESIZE____.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.PROPE17_PROPESIZE____"
											v-on="controls.PROPE17_PROPESIZE____.handlers"
											:loading="controls.PROPE17_PROPESIZE____.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-numeric-input
												v-if="controls.PROPE17_PROPESIZE____.isVisible"
												v-bind="controls.PROPE17_PROPESIZE____.props"
												@update:model-value="model.ValSize.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.PROPE17_PROPEBATHRMS_.isVisible">
									<q-control-wrapper
										v-show="controls.PROPE17_PROPEBATHRMS_.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.PROPE17_PROPEBATHRMS_"
											v-on="controls.PROPE17_PROPEBATHRMS_.handlers"
											:loading="controls.PROPE17_PROPEBATHRMS_.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-numeric-input
												v-if="controls.PROPE17_PROPEBATHRMS_.isVisible"
												v-bind="controls.PROPE17_PROPEBATHRMS_.props"
												@update:model-value="model.ValBathrms.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.PROPE17_PROPEYEAR____.isVisible || controls.PROPE17_PROPEBUILDAGE.isVisible">
									<q-control-wrapper
										v-show="controls.PROPE17_PROPEYEAR____.isVisible || controls.PROPE17_PROPEBUILDAGE.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.PROPE17_PROPEYEAR____"
											v-on="controls.PROPE17_PROPEYEAR____.handlers"
											:loading="controls.PROPE17_PROPEYEAR____.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.PROPE17_PROPEYEAR____.props"
												:model-value="model.ValYear.value"
												@blur="onBlur(controls.PROPE17_PROPEYEAR____, model.ValYear.value)"
												@change="model.ValYear.fnUpdateValueOnChange" />
										</base-input-structure>
										<base-input-structure
											class="i-text"
											v-bind="controls.PROPE17_PROPEBUILDAGE"
											v-on="controls.PROPE17_PROPEBUILDAGE.handlers"
											:loading="controls.PROPE17_PROPEBUILDAGE.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-numeric-input
												v-if="controls.PROPE17_PROPEBUILDAGE.isVisible"
												v-bind="controls.PROPE17_PROPEBUILDAGE.props"
												@update:model-value="model.ValBuildage.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<!-- End PROPE17_PSEUDDETAILS_ -->
							</q-group-collapsible>
							<q-group-collapsible
								id="PROPE17_PSEUDAGENTINF"
								v-bind="controls.PROPE17_PSEUDAGENTINF"
								v-on="controls.PROPE17_PSEUDAGENTINF.handlers"
								@state-changed="(state, groupId) => onStateChanged(state, groupId)">
								<!-- Start PROPE17_PSEUDAGENTINF -->
								<q-row-container v-show="controls.PROPE17_AGENTNAME____.isVisible">
									<q-control-wrapper
										v-show="controls.PROPE17_AGENTNAME____.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.PROPE17_AGENTNAME____"
											v-on="controls.PROPE17_AGENTNAME____.handlers"
											:loading="controls.PROPE17_AGENTNAME____.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-lookup
												v-if="controls.PROPE17_AGENTNAME____.isVisible"
												v-bind="controls.PROPE17_AGENTNAME____.props"
												v-on="controls.PROPE17_AGENTNAME____.handlers" />
											<q-see-more-prope17-agentname
												v-if="controls.PROPE17_AGENTNAME____.seeMoreIsVisible"
												v-bind="controls.PROPE17_AGENTNAME____.seeMoreParams"
												v-on="controls.PROPE17_AGENTNAME____.handlers" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.PROPE17_AGENTEMAIL___.isVisible">
									<q-control-wrapper
										v-show="controls.PROPE17_AGENTEMAIL___.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.PROPE17_AGENTEMAIL___"
											v-on="controls.PROPE17_AGENTEMAIL___.handlers"
											:loading="controls.PROPE17_AGENTEMAIL___.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-mask
												v-if="controls.PROPE17_AGENTEMAIL___.isVisible"
												v-bind="controls.PROPE17_AGENTEMAIL___"
												:model-value="model.AgentValEmail.value"
												@update:model-value="model.AgentValEmail.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.PROPE17_AGENTPHOTO___.isVisible">
									<q-control-wrapper
										v-show="controls.PROPE17_AGENTPHOTO___.isVisible"
										class="control-join-group">
										<base-input-structure
											class="q-image"
											v-bind="controls.PROPE17_AGENTPHOTO___"
											v-on="controls.PROPE17_AGENTPHOTO___.handlers"
											:loading="controls.PROPE17_AGENTPHOTO___.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-image
												v-if="controls.PROPE17_AGENTPHOTO___.isVisible"
												v-bind="controls.PROPE17_AGENTPHOTO___.props"
												v-on="controls.PROPE17_AGENTPHOTO___.handlers" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<!-- End PROPE17_PSEUDAGENTINF -->
							</q-group-collapsible>
							<!-- End PROPE17_PSEUDACC01___ -->
						</q-accordion-container>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.PROPE17_PSEUDPROPHOTO.isVisible"
						class="control-join-group">
						<q-table
							v-show="controls.PROPE17_PSEUDPROPHOTO.isVisible"
							v-bind="controls.PROPE17_PSEUDPROPHOTO"
							v-on="controls.PROPE17_PSEUDPROPHOTO.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.PROPE17_PSEUDPROPHOTO"
							v-on="controls.PROPE17_PSEUDPROPHOTO.handlers" />
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.PROPE17_PSEUDPROPCONT.isVisible">
					<q-control-wrapper
						v-show="controls.PROPE17_PSEUDPROPCONT.isVisible"
						class="control-join-group">
						<q-table
							v-show="controls.PROPE17_PSEUDPROPCONT.isVisible"
							v-bind="controls.PROPE17_PSEUDPROPCONT"
							v-on="controls.PROPE17_PSEUDPROPCONT.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.PROPE17_PSEUDPROPCONT"
							v-on="controls.PROPE17_PSEUDPROPCONT.handlers" />
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

	import FormViewModel from './QFormPrope17ViewModel.js'

	const requiredTextResources = ['QFormPrope17', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PROPE17]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormPrope17',

		components: {
			QSeeMorePrope17CityCity: defineAsyncComponent(() => import('@/views/forms/FormPrope17/dbedits/Prope17CityCitySeeMore.vue')),
			QSeeMorePrope17Agentname: defineAsyncComponent(() => import('@/views/forms/FormPrope17/dbedits/Prope17AgentnameSeeMore.vue')),
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
					name: 'PROPE17',
					location: 'form-PROPE17',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormPrope17', false),

				interfaceMetadata: {
					id: 'QFormPrope17', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'PROPE17',
					route: 'form-PROPE17',
					area: 'PROPE',
					primaryKey: 'ValCodprope',
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
						type: 'form-insert',
						text: computed(() => vm.Resources[hardcodedTexts.insert]),
						label: computed(() => vm.Resources[hardcodedTexts.insert]),
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
						text: computed(() => vm.Resources.CANCELAR49513),
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
					}
				},

				controls: {
					PROPE17_PROPEORDER___: new fieldControlClass.NumberControl({
						modelField: 'ValOrder',
						valueChangeEvent: 'fieldChange:prope.order',
						id: 'PROPE17_PROPEORDER___',
						name: 'ORDER',
						size: 'medium',
						label: computed(() => this.Resources.ORDER39632),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 15,
						maxDecimals: 0,
						isSequencial: true,
						controlLimits: [
						],
						blockWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: true
								return true
							},
							dependencyEvents: [],
							isServerRecalc: false,
						},
					}, this),
					PROPE17_PSEUDMAININF_: new fieldControlClass.GroupControl({
						id: 'PROPE17_PSEUDMAININF_',
						name: 'MAININF',
						size: 'large',
						label: computed(() => this.Resources.INFORMACOES_PRINCIPA43450),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['PROPE17_PROPEPHOTO___', 'PROPE17_PROPETITLE___', 'PROPE17_PROPEPRICE___', 'PROPE17_PROPEDESCRIPT'],
						controlLimits: [
						],
					}, this),
					PROPE17_PROPEPHOTO___: new fieldControlClass.ImageControl({
						modelField: 'ValPhoto',
						valueChangeEvent: 'fieldChange:prope.photo',
						id: 'PROPE17_PROPEPHOTO___',
						name: 'PHOTO',
						size: 'mini',
						label: computed(() => this.Resources.FOTO_PRINCIPAL64363),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPE17_PSEUDMAININF_',
						height: 10,
						width: 480,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.FOTO_PRINCIPAL64363)),
						controlLimits: [
						],
					}, this),
					PROPE17_PROPETITLE___: new fieldControlClass.StringControl({
						modelField: 'ValTitle',
						valueChangeEvent: 'fieldChange:prope.title',
						id: 'PROPE17_PROPETITLE___',
						name: 'TITLE',
						size: 'xxlarge',
						label: computed(() => this.Resources.TITLE21885),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPE17_PSEUDMAININF_',
						maxLength: 50,
						labelId: 'label_PROPE17_PROPETITLE___',
						controlLimits: [
						],
					}, this),
					PROPE17_PROPEPRICE___: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrice',
						valueChangeEvent: 'fieldChange:prope.price',
						id: 'PROPE17_PROPEPRICE___',
						name: 'PRICE',
						size: 'medium',
						label: computed(() => this.Resources.PRICE06900),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPE17_PSEUDMAININF_',
						maxIntegers: 9,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					PROPE17_PROPEDESCRIPT: new fieldControlClass.StringControl({
						modelField: 'ValDescript',
						valueChangeEvent: 'fieldChange:prope.descript',
						id: 'PROPE17_PROPEDESCRIPT',
						name: 'DESCRIPT',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESCRIPTION07383),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPE17_PSEUDMAININF_',
						controlLimits: [
						],
					}, this),
					PROPE17_PSEUDACC01___: new fieldControlClass.AccordionControl({
						id: 'PROPE17_PSEUDACC01___',
						name: 'ACC01',
						size: 'mini',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['PROPE17_PSEUDLOCALIZA', 'PROPE17_PSEUDDETAILS_', 'PROPE17_PSEUDAGENTINF'],
						controlLimits: [
						],
					}, this),
					PROPE17_PSEUDLOCALIZA: new fieldControlClass.GroupControl({
						id: 'PROPE17_PSEUDLOCALIZA',
						name: 'LOCALIZA',
						size: 'small',
						label: computed(() => this.Resources.LOCALIZACAO54665),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPE17_PSEUDACC01___',
						isCollapsible: true,
						anchored: false,
						directChildren: ['PROPE17_CITY_CITY____', 'PROPE17_CTRY_COUNTRY_'],
						isInAccordion: true,
						controlLimits: [
						],
					}, this),
					PROPE17_CITY_CITY____: new fieldControlClass.LookupControl({
						modelField: 'TableCityCity',
						valueChangeEvent: 'fieldChange:city.city',
						id: 'PROPE17_CITY_CITY____',
						name: 'CITY',
						size: 'xxlarge',
						label: computed(() => this.Resources.CIDADE42080),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPE17_PSEUDLOCALIZA',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodcity',
							dependencyEvent: 'fieldChange:prope.codcity'
						},
						dependentFields: () => ({
							set 'city.codcity'(value) { vm.model.ValCodcity.updateValue(value) },
							set 'city.city'(value) { vm.model.TableCityCity.updateValue(value) },
							set 'ctry.country'(value) { vm.model.CityCtryValCountry.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					PROPE17_CTRY_COUNTRY_: new fieldControlClass.StringControl({
						modelField: 'CityCtryValCountry',
						valueChangeEvent: 'fieldChange:ctry.country',
						dependentModelField: 'ValCodctry',
						dependentChangeEvent: 'fieldChange:city.codctry',
						id: 'PROPE17_CTRY_COUNTRY_',
						name: 'COUNTRY',
						size: 'xlarge',
						label: computed(() => this.Resources.COUNTRY64133),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPE17_PSEUDLOCALIZA',
						maxLength: 50,
						labelId: 'label_PROPE17_CTRY_COUNTRY_',
						controlLimits: [
						],
					}, this),
					PROPE17_PSEUDDETAILS_: new fieldControlClass.GroupControl({
						id: 'PROPE17_PSEUDDETAILS_',
						name: 'DETAILS',
						size: 'small',
						label: computed(() => this.Resources.DETALHES04088),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPE17_PSEUDACC01___',
						isCollapsible: true,
						anchored: false,
						directChildren: ['PROPE17_PROPEBUILDTYP', 'PROPE17_PROPETYPOLOGY', 'PROPE17_PROPESIZE____', 'PROPE17_PROPEBATHRMS_', 'PROPE17_PROPEYEAR____', 'PROPE17_PROPEBUILDAGE'],
						isInAccordion: true,
						controlLimits: [
						],
					}, this),
					PROPE17_PROPEBUILDTYP: new fieldControlClass.ArrayStringControl({
						modelField: 'ValBuildtyp',
						valueChangeEvent: 'fieldChange:prope.buildtyp',
						id: 'PROPE17_PROPEBUILDTYP',
						name: 'BUILDTYP',
						size: 'mini',
						label: computed(() => this.Resources.TIPO_DE_EDIFICIO02279),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPE17_PSEUDDETAILS_',
						maxLength: 1,
						labelId: 'label_PROPE17_PROPEBUILDTYP',
						arrayName: 'buildtyp',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					PROPE17_PROPETYPOLOGY: new fieldControlClass.ArrayNumberControl({
						modelField: 'ValTypology',
						valueChangeEvent: 'fieldChange:prope.typology',
						id: 'PROPE17_PROPETYPOLOGY',
						name: 'TYPOLOGY',
						size: 'small',
						label: computed(() => this.Resources.TYPOLOGY11991),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'PROPE17_PSEUDDETAILS_',
						maxIntegers: 1,
						maxDecimals: 0,
						arrayName: 'aparttyp',
						columnNumber: 4,
						controlLimits: [
						],
					}, this),
					PROPE17_PROPESIZE____: new fieldControlClass.NumberControl({
						modelField: 'ValSize',
						valueChangeEvent: 'fieldChange:prope.size',
						id: 'PROPE17_PROPESIZE____',
						name: 'SIZE',
						size: 'medium',
						label: computed(() => this.Resources.TAMANHO__M2_40951),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPE17_PSEUDDETAILS_',
						maxIntegers: 15,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					PROPE17_PROPEBATHRMS_: new fieldControlClass.NumberControl({
						modelField: 'ValBathrms',
						valueChangeEvent: 'fieldChange:prope.bathrms',
						id: 'PROPE17_PROPEBATHRMS_',
						name: 'BATHRMS',
						size: 'large',
						label: computed(() => this.Resources.NUMERO_DE_CASA_DE_BA10087),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPE17_PSEUDDETAILS_',
						maxIntegers: 2,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					PROPE17_PROPEYEAR____: new fieldControlClass.StringControl({
						modelField: 'ValYear',
						valueChangeEvent: 'fieldChange:prope.year',
						id: 'PROPE17_PROPEYEAR____',
						name: 'YEAR',
						size: 'xxlarge',
						label: computed(() => this.Resources.ANO_CONSTRUIDO64369),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPE17_PSEUDDETAILS_',
						maxLength: 50,
						labelId: 'label_PROPE17_PROPEYEAR____',
						controlLimits: [
						],
					}, this),
					PROPE17_PROPEBUILDAGE: new fieldControlClass.NumberControl({
						modelField: 'ValBuildage',
						valueChangeEvent: 'fieldChange:prope.buildage',
						id: 'PROPE17_PROPEBUILDAGE',
						name: 'BUILDAGE',
						size: 'medium',
						label: computed(() => this.Resources.BUILDING_AGE27311),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPE17_PSEUDDETAILS_',
						isFormulaBlocked: true,
						maxIntegers: 8,
						maxDecimals: 0,
						controlLimits: [
						],
						blockWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: true
								return true
							},
							dependencyEvents: [],
							isServerRecalc: false,
						},
					}, this),
					PROPE17_PSEUDAGENTINF: new fieldControlClass.GroupControl({
						id: 'PROPE17_PSEUDAGENTINF',
						name: 'AGENTINF',
						size: 'large',
						label: computed(() => this.Resources.INFORMACAO_DO_AGENTE51492),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPE17_PSEUDACC01___',
						isCollapsible: true,
						anchored: false,
						directChildren: ['PROPE17_AGENTNAME____', 'PROPE17_AGENTEMAIL___', 'PROPE17_AGENTPHOTO___'],
						isInAccordion: true,
						controlLimits: [
						],
					}, this),
					PROPE17_AGENTNAME____: new fieldControlClass.LookupControl({
						modelField: 'TableAgentName',
						valueChangeEvent: 'fieldChange:agent.name',
						id: 'PROPE17_AGENTNAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.NAME31974),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPE17_PSEUDAGENTINF',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodagent',
							dependencyEvent: 'fieldChange:prope.codagent'
						},
						dependentFields: () => ({
							set 'agent.codagent'(value) { vm.model.ValCodagent.updateValue(value) },
							set 'agent.name'(value) { vm.model.TableAgentName.updateValue(value) },
							set 'agent.email'(value) { vm.model.AgentValEmail.updateValue(value) },
							set 'agent.photo'(value) { vm.model.AgentValPhoto.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					PROPE17_AGENTEMAIL___: new fieldControlClass.StringControl({
						modelField: 'AgentValEmail',
						valueChangeEvent: 'fieldChange:agent.email',
						dependentModelField: 'ValCodagent',
						dependentChangeEvent: 'fieldChange:prope.codagent',
						id: 'PROPE17_AGENTEMAIL___',
						name: 'EMAIL',
						size: 'xlarge',
						label: computed(() => this.Resources.EMAIL25170),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPE17_PSEUDAGENTINF',
						maxLength: 50,
						labelId: 'label_PROPE17_AGENTEMAIL___',
						controlLimits: [
						],
					}, this),
					PROPE17_AGENTPHOTO___: new fieldControlClass.ImageControl({
						modelField: 'AgentValPhoto',
						valueChangeEvent: 'fieldChange:agent.photo',
						dependentModelField: 'ValCodagent',
						dependentChangeEvent: 'fieldChange:prope.codagent',
						id: 'PROPE17_AGENTPHOTO___',
						name: 'PHOTO',
						size: 'mini',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PROPE17_PSEUDAGENTINF',
						height: 10,
						width: 480,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO51874)),
						maxFileSize: 10485760, // In bytes.
						maxFileSizeLabel: '10 MB',
						controlLimits: [
						],
					}, this),
					PROPE17_PSEUDPROPHOTO: new fieldControlClass.TableListControl({
						id: 'PROPE17_PSEUDPROPHOTO',
						name: 'PROPHOTO',
						size: '',
						label: computed(() => this.Resources.PHOTOS39221),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'PROPE',
						action: 'Prope17_ValProphoto',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.ImageColumn({
								order: 1,
								name: 'ValPhoto',
								area: 'PROPH',
								field: 'PHOTO',
								label: computed(() => this.Resources.PHOTO51874),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.PHOTO51874)),
								scrollData: 3,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValTitle',
								area: 'PROPH',
								field: 'TITLE',
								label: computed(() => this.Resources.TITLE21885),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValProphoto',
							serverMode: true,
							pkColumn: 'ValCodproph',
							tableAlias: 'PROPH',
							tableNamePlural: computed(() => this.Resources.PHOTOS39221),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.PHOTOS39221),
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
										canExecuteAction: vm.applyChanges,
										action: vm.openFormAction,
										type: 'form',
										formName: 'PHOTO03',
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
										canExecuteAction: vm.applyChanges,
										action: vm.openFormAction,
										type: 'form',
										formName: 'PHOTO03',
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
										canExecuteAction: vm.applyChanges,
										action: vm.openFormAction,
										type: 'form',
										formName: 'PHOTO03',
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
										canExecuteAction: vm.applyChanges,
										action: vm.openFormAction,
										type: 'form',
										formName: 'PHOTO03',
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
										canExecuteAction: vm.applyChanges,
										action: vm.openFormAction,
										type: 'form',
										formName: 'PHOTO03',
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
								id: 'RCA__PHOTO03',
								name: '_PHOTO03',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									canExecuteAction: vm.applyChanges,
									action: vm.openFormAction,
									type: 'form',
									formName: 'PHOTO03',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'PHOTO03': {
									fnKeySelector: (row) => row.Fields.ValCodproph,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValTitle',
							defaultSearchColumnNameOriginal: 'ValTitle',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-PROPE', 'changed-PROPH'],
						uuid: 'Prope17_ValProphoto',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'prope'],
								dependencyEvents: ['fieldChange:prope.codprope'],
								dependencyField: 'PROPE.CODPROPE',
								fnValueSelector: (model) => model.ValCodprope.value
							},
						],
					}, this),
					PROPE17_PSEUDPROPCONT: new fieldControlClass.TableListControl({
						id: 'PROPE17_PSEUDPROPCONT',
						name: 'PROPCONT',
						size: '',
						label: computed(() => this.Resources.CONTACTS55742),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'PROPE',
						action: 'Prope17_ValPropcont',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValDate',
								area: 'PROCN',
								field: 'DATE',
								label: computed(() => this.Resources.DATE18475),
								scrollData: 8,
								dateTimeType: 'date',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValName',
								area: 'PROCN',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValDescript',
								area: 'PROCN',
								field: 'DESCRIPT',
								label: computed(() => this.Resources.DESCRIPTION07383),
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValPropcont',
							serverMode: true,
							pkColumn: 'ValCodprocn',
							tableAlias: 'PROCN',
							tableNamePlural: computed(() => this.Resources.CONTACTS55742),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.CONTACTS55742),
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
										canExecuteAction: vm.applyChanges,
										action: vm.openFormAction,
										type: 'form',
										formName: 'CONTAC06',
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
										canExecuteAction: vm.applyChanges,
										action: vm.openFormAction,
										type: 'form',
										formName: 'CONTAC06',
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
										canExecuteAction: vm.applyChanges,
										action: vm.openFormAction,
										type: 'form',
										formName: 'CONTAC06',
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
										canExecuteAction: vm.applyChanges,
										action: vm.openFormAction,
										type: 'form',
										formName: 'CONTAC06',
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
										canExecuteAction: vm.applyChanges,
										action: vm.openFormAction,
										type: 'form',
										formName: 'CONTAC06',
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
								id: 'RCA__CONTAC06',
								name: '_CONTAC06',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									canExecuteAction: vm.applyChanges,
									action: vm.openFormAction,
									type: 'form',
									formName: 'CONTAC06',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'CONTAC06': {
									fnKeySelector: (row) => row.Fields.ValCodprocn,
									isPopup: true
								},
							},
							defaultSearchColumnName: 'ValName',
							defaultSearchColumnNameOriginal: 'ValName',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-PROCN', 'changed-PROPE'],
						uuid: 'Prope17_ValPropcont',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'prope'],
								dependencyEvents: ['fieldChange:prope.codprope'],
								dependencyField: 'PROPE.CODPROPE',
								fnValueSelector: (model) => model.ValCodprope.value
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
					'PROPE17_PSEUDMAININF_',
					'PROPE17_PSEUDACC01___',
					'PROPE17_PSEUDLOCALIZA',
					'PROPE17_PSEUDDETAILS_',
					'PROPE17_PSEUDAGENTINF',
				]),

				tableFields: readonly([
					'PROPE17_PSEUDPROPHOTO',
					'PROPE17_PSEUDPROPCONT',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Agent: {
						get ValEmail() { return vm.model.AgentValEmail.value },
						set ValEmail(value) { vm.model.AgentValEmail.updateValue(value) },
						get ValName() { return vm.model.TableAgentName.value },
						set ValName(value) { vm.model.TableAgentName.updateValue(value) },
						get ValPhoto() { return vm.model.AgentValPhoto.value },
						set ValPhoto(value) { vm.model.AgentValPhoto.updateValue(value) },
					},
					City: {
						get ValCity() { return vm.model.TableCityCity.value },
						set ValCity(value) { vm.model.TableCityCity.updateValue(value) },
					},
					Ctry: {
						get ValCountry() { return vm.model.CityCtryValCountry.value },
						set ValCountry(value) { vm.model.CityCtryValCountry.updateValue(value) },
					},
					Prope: {
						get ValBathrms() { return vm.model.ValBathrms.value },
						set ValBathrms(value) { vm.model.ValBathrms.updateValue(value) },
						get ValBuildage() { return vm.model.ValBuildage.value },
						set ValBuildage(value) { vm.model.ValBuildage.updateValue(value) },
						get ValBuildtyp() { return vm.model.ValBuildtyp.value },
						set ValBuildtyp(value) { vm.model.ValBuildtyp.updateValue(value) },
						get ValCodagent() { return vm.model.ValCodagent.value },
						set ValCodagent(value) { vm.model.ValCodagent.updateValue(value) },
						get ValCodcity() { return vm.model.ValCodcity.value },
						set ValCodcity(value) { vm.model.ValCodcity.updateValue(value) },
						get ValDescript() { return vm.model.ValDescript.value },
						set ValDescript(value) { vm.model.ValDescript.updateValue(value) },
						get ValOrder() { return vm.model.ValOrder.value },
						set ValOrder(value) { vm.model.ValOrder.updateValue(value) },
						get ValPhoto() { return vm.model.ValPhoto.value },
						set ValPhoto(value) { vm.model.ValPhoto.updateValue(value) },
						get ValPrice() { return vm.model.ValPrice.value },
						set ValPrice(value) { vm.model.ValPrice.updateValue(value) },
						get ValSize() { return vm.model.ValSize.value },
						set ValSize(value) { vm.model.ValSize.updateValue(value) },
						get ValTitle() { return vm.model.ValTitle.value },
						set ValTitle(value) { vm.model.ValTitle.updateValue(value) },
						get ValTypology() { return vm.model.ValTypology.value },
						set ValTypology(value) { vm.model.ValTypology.updateValue(value) },
						get ValYear() { return vm.model.ValYear.value },
						set ValYear(value) { vm.model.ValYear.updateValue(value) },
					},
					keys: {
						/** The primary key of the PROPE table */
						get prope() { return vm.model.ValCodprope },
						/** The foreign key to the AGENT table */
						get agent() { return vm.model.ValCodagent },
						/** The foreign key to the CITY table */
						get city() { return vm.model.ValCodcity },
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
// USE /[MANUAL GQT FORM_CODEJS PROPE17]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS PROPE17]/
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
// USE /[MANUAL GQT FORM_LOADED_JS PROPE17]/
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

				applyForm = await this.model.setDocumentChanges()

				if (applyForm)
				{
					const results = await this.model.saveDocuments()
					applyForm = results.every((e) => e === true)
				}

				this.emitEvent('before-apply-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT BEFORE_APPLY_JS PROPE17]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS PROPE17]/
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

				saveForm = await this.model.setDocumentChanges()

				if (saveForm)
				{
					const results = await this.model.saveDocuments()
					saveForm = results.every((e) => e === true)
				}

				this.emitEvent('before-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT BEFORE_SAVE_JS PROPE17]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS PROPE17]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS PROPE17]/
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
// USE /[MANUAL GQT AFTER_DEL_JS PROPE17]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS PROPE17]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS PROPE17]/
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
// USE /[MANUAL GQT DLGUPDT PROPE17]/
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
// USE /[MANUAL GQT CTRLBLR PROPE17]/
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
// USE /[MANUAL GQT CTRLUPD PROPE17]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS PROPE17]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
			// Watchers for changes in the state of tabs and collapsible groups.
			'controls.PROPE17_PSEUDLOCALIZA.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'PROPE17_PSEUDLOCALIZA',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
			'controls.PROPE17_PSEUDDETAILS_.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'PROPE17_PSEUDDETAILS_',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
			'controls.PROPE17_PSEUDAGENTINF.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'PROPE17_PSEUDAGENTINF',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
		}
	}
</script>
