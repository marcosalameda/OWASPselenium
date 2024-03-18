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
			data-key="GROUPBX"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.GROUPBX_PSEUDNOVOGR01.isVisible">
					<q-control-wrapper
						v-show="controls.GROUPBX_PSEUDNOVOGR01.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="GROUPBX_PSEUDNOVOGR01"
							v-bind="controls.GROUPBX_PSEUDNOVOGR01"
							:is-visible="controls.GROUPBX_PSEUDNOVOGR01.isVisible">
							<!-- Start GROUPBX_PSEUDNOVOGR01 -->
							<q-row-container v-show="controls.GROUPBX_EQUIPSEQUENNR.isVisible || controls.GROUPBX_EQUIPREGISTNR.isVisible">
								<q-control-wrapper
									v-show="controls.GROUPBX_EQUIPSEQUENNR.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.GROUPBX_EQUIPSEQUENNR"
										v-on="controls.GROUPBX_EQUIPSEQUENNR.handlers"
										:loading="controls.GROUPBX_EQUIPSEQUENNR.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-numeric-input
											v-if="controls.GROUPBX_EQUIPSEQUENNR.isVisible"
											v-bind="controls.GROUPBX_EQUIPSEQUENNR"
											:model-value="model.ValSequennr.value"
											@update:model-value="model.ValSequennr.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.GROUPBX_EQUIPREGISTNR.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.GROUPBX_EQUIPREGISTNR"
										v-on="controls.GROUPBX_EQUIPREGISTNR.handlers"
										:loading="controls.GROUPBX_EQUIPREGISTNR.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-text-field
											v-bind="controls.GROUPBX_EQUIPREGISTNR.props"
											:model-value="model.ValRegistnr.value" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.GROUPBX_TPEQUTIPOEQUI.isVisible">
								<q-control-wrapper
									v-show="controls.GROUPBX_TPEQUTIPOEQUI.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.GROUPBX_TPEQUTIPOEQUI"
										v-on="controls.GROUPBX_TPEQUTIPOEQUI.handlers"
										:loading="controls.GROUPBX_TPEQUTIPOEQUI.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-lookup
											v-if="controls.GROUPBX_TPEQUTIPOEQUI.isVisible"
											v-bind="controls.GROUPBX_TPEQUTIPOEQUI.props"
											:model-value="model.ValCodtpequ.value"
											v-on="controls.GROUPBX_TPEQUTIPOEQUI.handlers"
											@update:model-value="model.ValCodtpequ.fnUpdateValue" />
										<q-see-more-groupbx-tpequtipoequi
											v-if="controls.GROUPBX_TPEQUTIPOEQUI.seeMoreIsVisible"
											v-bind="controls.GROUPBX_TPEQUTIPOEQUI.seeMoreParams"
											v-on="controls.GROUPBX_TPEQUTIPOEQUI.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.GROUPBX_EQUIPSITEFABR.isVisible">
								<q-control-wrapper
									v-show="controls.GROUPBX_EQUIPSITEFABR.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.GROUPBX_EQUIPSITEFABR"
										v-on="controls.GROUPBX_EQUIPSITEFABR.handlers"
										:loading="controls.GROUPBX_EQUIPSITEFABR.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-text-field
											v-bind="controls.GROUPBX_EQUIPSITEFABR.props"
											:model-value="model.ValSitefabr.value"
											@update:model-value="model.ValSitefabr.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.GROUPBX_WAREHWAREHDES.isVisible">
								<q-control-wrapper
									v-show="controls.GROUPBX_WAREHWAREHDES.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.GROUPBX_WAREHWAREHDES"
										v-on="controls.GROUPBX_WAREHWAREHDES.handlers"
										:loading="controls.GROUPBX_WAREHWAREHDES.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-lookup
											v-if="controls.GROUPBX_WAREHWAREHDES.isVisible"
											v-bind="controls.GROUPBX_WAREHWAREHDES.props"
											:model-value="model.ValCodwareh.value"
											v-on="controls.GROUPBX_WAREHWAREHDES.handlers"
											@update:model-value="model.ValCodwareh.fnUpdateValue" />
										<q-see-more-groupbx-warehwarehdes
											v-if="controls.GROUPBX_WAREHWAREHDES.seeMoreIsVisible"
											v-bind="controls.GROUPBX_WAREHWAREHDES.seeMoreParams"
											v-on="controls.GROUPBX_WAREHWAREHDES.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.GROUPBX_ITEM_ITEMDES_.isVisible">
								<q-control-wrapper
									v-show="controls.GROUPBX_ITEM_ITEMDES_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.GROUPBX_ITEM_ITEMDES_"
										v-on="controls.GROUPBX_ITEM_ITEMDES_.handlers"
										:loading="controls.GROUPBX_ITEM_ITEMDES_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-lookup
											v-if="controls.GROUPBX_ITEM_ITEMDES_.isVisible"
											v-bind="controls.GROUPBX_ITEM_ITEMDES_.props"
											:model-value="model.ValCoditem.value"
											v-on="controls.GROUPBX_ITEM_ITEMDES_.handlers"
											@update:model-value="model.ValCoditem.fnUpdateValue" />
										<q-see-more-groupbx-item-itemdes
											v-if="controls.GROUPBX_ITEM_ITEMDES_.seeMoreIsVisible"
											v-bind="controls.GROUPBX_ITEM_ITEMDES_.seeMoreParams"
											v-on="controls.GROUPBX_ITEM_ITEMDES_.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End GROUPBX_PSEUDNOVOGR01 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.GROUPBX_PSEUDNOVOGR02.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.GROUPBX_PSEUDNOVOGR02.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="GROUPBX_PSEUDNOVOGR02"
							v-bind="controls.GROUPBX_PSEUDNOVOGR02"
							:is-visible="controls.GROUPBX_PSEUDNOVOGR02.isVisible">
							<!-- Start GROUPBX_PSEUDNOVOGR02 -->
							<q-row-container v-show="controls.GROUPBX_EQUIPDTDECO__.isVisible || controls.GROUPBX_ROOM1ROOMNR__.isVisible">
								<q-control-wrapper
									v-show="controls.GROUPBX_EQUIPDTDECO__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.GROUPBX_EQUIPDTDECO__"
										v-on="controls.GROUPBX_EQUIPDTDECO__.handlers"
										:loading="controls.GROUPBX_EQUIPDTDECO__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-datetime-input
											v-if="controls.GROUPBX_EQUIPDTDECO__.isVisible"
											v-bind="controls.GROUPBX_EQUIPDTDECO__"
											format="Date"
											:model-value="model.ValDtdeco.value"
											@update:model-value="model.ValDtdeco.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.GROUPBX_ROOM1ROOMNR__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.GROUPBX_ROOM1ROOMNR__"
										v-on="controls.GROUPBX_ROOM1ROOMNR__.handlers"
										:loading="controls.GROUPBX_ROOM1ROOMNR__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-lookup
											v-if="controls.GROUPBX_ROOM1ROOMNR__.isVisible"
											v-bind="controls.GROUPBX_ROOM1ROOMNR__.props"
											:model-value="model.ValCodrooms.value"
											v-on="controls.GROUPBX_ROOM1ROOMNR__.handlers"
											@update:model-value="model.ValCodrooms.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.GROUPBX_ROOM1DESIGNAT.isVisible">
								<q-control-wrapper
									v-show="controls.GROUPBX_ROOM1DESIGNAT.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.GROUPBX_ROOM1DESIGNAT"
										v-on="controls.GROUPBX_ROOM1DESIGNAT.handlers"
										:loading="controls.GROUPBX_ROOM1DESIGNAT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-text-field
											v-bind="controls.GROUPBX_ROOM1DESIGNAT.props"
											:model-value="model.Room1ValDesignat.value" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.GROUPBX_EQUIPDESIGNAT.isVisible">
								<q-control-wrapper
									v-show="controls.GROUPBX_EQUIPDESIGNAT.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.GROUPBX_EQUIPDESIGNAT"
										v-on="controls.GROUPBX_EQUIPDESIGNAT.handlers"
										:loading="controls.GROUPBX_EQUIPDESIGNAT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-text-field
											v-bind="controls.GROUPBX_EQUIPDESIGNAT.props"
											:model-value="model.ValDesignat.value"
											@update:model-value="model.ValDesignat.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.GROUPBX_EQUIPDTAQUISI.isVisible || controls.GROUPBX_EQUIPVALORTOT.isVisible || controls.GROUPBX_EQUIPFREQUENC.isVisible">
								<q-control-wrapper
									v-show="controls.GROUPBX_EQUIPDTAQUISI.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.GROUPBX_EQUIPDTAQUISI"
										v-on="controls.GROUPBX_EQUIPDTAQUISI.handlers"
										:loading="controls.GROUPBX_EQUIPDTAQUISI.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-datetime-input
											v-if="controls.GROUPBX_EQUIPDTAQUISI.isVisible"
											v-bind="controls.GROUPBX_EQUIPDTAQUISI"
											format="Date"
											:model-value="model.ValDtaquisi.value"
											@update:model-value="model.ValDtaquisi.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.GROUPBX_EQUIPVALORTOT.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.GROUPBX_EQUIPVALORTOT"
										v-on="controls.GROUPBX_EQUIPVALORTOT.handlers"
										:loading="controls.GROUPBX_EQUIPVALORTOT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-numeric-input
											v-if="controls.GROUPBX_EQUIPVALORTOT.isVisible"
											v-bind="controls.GROUPBX_EQUIPVALORTOT"
											:model-value="model.ValValortot.value"
											@update:model-value="model.ValValortot.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.GROUPBX_EQUIPFREQUENC.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.GROUPBX_EQUIPFREQUENC"
										v-on="controls.GROUPBX_EQUIPFREQUENC.handlers"
										:loading="controls.GROUPBX_EQUIPFREQUENC.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-select
											v-if="controls.GROUPBX_EQUIPFREQUENC.isVisible"
											v-bind="controls.GROUPBX_EQUIPFREQUENC.props"
											:model-value="model.ValFrequenc.value"
											@update:model-value="model.ValFrequenc.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.GROUPBX_EQUIPDTREFERE.isVisible || controls.GROUPBX_EQUIPFIRST___.isVisible || controls.GROUPBX_EQUIPBEFORE__.isVisible">
								<q-control-wrapper
									v-show="controls.GROUPBX_EQUIPDTREFERE.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.GROUPBX_EQUIPDTREFERE"
										v-on="controls.GROUPBX_EQUIPDTREFERE.handlers"
										:loading="controls.GROUPBX_EQUIPDTREFERE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-datetime-input
											v-if="controls.GROUPBX_EQUIPDTREFERE.isVisible"
											v-bind="controls.GROUPBX_EQUIPDTREFERE"
											format="DateTime"
											:model-value="model.ValDtrefere.value"
											@update:model-value="model.ValDtrefere.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.GROUPBX_EQUIPFIRST___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.GROUPBX_EQUIPFIRST___"
										v-on="controls.GROUPBX_EQUIPFIRST___.handlers"
										:loading="controls.GROUPBX_EQUIPFIRST___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-text-field
											v-bind="controls.GROUPBX_EQUIPFIRST___.props"
											:model-value="model.ValFirst.value" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.GROUPBX_EQUIPBEFORE__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.GROUPBX_EQUIPBEFORE__"
										v-on="controls.GROUPBX_EQUIPBEFORE__.handlers"
										:loading="controls.GROUPBX_EQUIPBEFORE__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-text-field
											v-bind="controls.GROUPBX_EQUIPBEFORE__.props"
											:model-value="model.ValBefore.value" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.GROUPBX_EQUIPBOUGHT__.isVisible">
								<q-control-wrapper
									v-show="controls.GROUPBX_EQUIPBOUGHT__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.GROUPBX_EQUIPBOUGHT__"
										v-on="controls.GROUPBX_EQUIPBOUGHT__.handlers"
										:loading="controls.GROUPBX_EQUIPBOUGHT__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<template #label>
											<q-checkbox-input
												v-if="controls.GROUPBX_EQUIPBOUGHT__.isVisible"
												id="GROUPBX_EQUIPBOUGHT__"
												size="mini"
												:model-value="model.ValBought.value"
												:readonly="controls.GROUPBX_EQUIPBOUGHT__.readonly"
												@update:model-value="model.ValBought.fnUpdateValue" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End GROUPBX_PSEUDNOVOGR02 -->
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

	import FormViewModel from './QFormGroupbxViewModel.js'

	const requiredTextResources = ['QFormGroupbx', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS GROUPBX]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormGroupbx',

		components: {
			QSeeMoreGroupbxTpequtipoequi: defineAsyncComponent(() => import('@/views/forms/FormGroupbx/dbedits/GroupbxTpequtipoequiSeeMore.vue')),
			QSeeMoreGroupbxWarehwarehdes: defineAsyncComponent(() => import('@/views/forms/FormGroupbx/dbedits/GroupbxWarehwarehdesSeeMore.vue')),
			QSeeMoreGroupbxItemItemdes: defineAsyncComponent(() => import('@/views/forms/FormGroupbx/dbedits/GroupbxItemItemdesSeeMore.vue')),
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
						name: 'GROUPBX',
						location: 'form-GROUPBX',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormGroupbx', false),

				interfaceMetadata: {
					id: 'QFormGroupbx', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'GROUPBX',
					route: 'form-GROUPBX',
					area: 'EQUIP',
					primaryKey: 'ValCodequip',
					designation: computed(() => this.Resources.GROUPBOX00384),
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
						text: computed(() => vm.Resources.INSERIR43365),
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
					GROUPBX_PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'GROUPBX_PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.WHOLE_LINE_OFF30708),
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
					GROUPBX_EQUIPSEQUENNR: new fieldControlClass.NumberControl({
						modelField: 'ValSequennr',
						valueChangeEvent: 'fieldChange:equip.sequennr',
						maxIntegers: 6,
						maxDecimals: 0,
						isSequencial: true,
						id: 'GROUPBX_EQUIPSEQUENNR',
						name: 'SEQUENNR',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.SEQUENTIAL_NO__11610),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'GROUPBX_PSEUDNOVOGR01',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					GROUPBX_EQUIPREGISTNR: new fieldControlClass.StringControl({
						modelField: 'ValRegistnr',
						valueChangeEvent: 'fieldChange:equip.registnr',
						id: 'GROUPBX_EQUIPREGISTNR',
						name: 'REGISTNR',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.REGISTRATION_NO_06209),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'GROUPBX_PSEUDNOVOGR01',
						isFormulaBlocked: true,
						maxLength: 6,
						labelId: 'label_GROUPBX_EQUIPREGISTNR',
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					GROUPBX_TPEQUTIPOEQUI: new fieldControlClass.LookupControl({
						modelField: 'TableTpequTipoequi',
						valueChangeEvent: 'fieldChange:tpequ.tipoequi',
						id: 'GROUPBX_TPEQUTIPOEQUI',
						name: 'TIPOEQUI',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.TYPE_OF_EQUIPMENT64921),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'GROUPBX_PSEUDNOVOGR01',
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodtpequ',
							dependencyEvent: 'fieldChange:equip.codtpequ'
						},
						dependentFields: () => {
							return {
								set 'tpequ.codtpequ'(value) { vm.model.ValCodtpequ.updateValue(value) },
								set 'tpequ.tipoequi'(value) { vm.model.TableTpequTipoequi.updateValue(value) },
							}
						},
						insertEnabled: true,
						supportForm: 'TPEQU',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
					}, this),
					GROUPBX_EQUIPSITEFABR: new fieldControlClass.StringControl({
						modelField: 'ValSitefabr',
						valueChangeEvent: 'fieldChange:equip.sitefabr',
						id: 'GROUPBX_EQUIPSITEFABR',
						name: 'SITEFABR',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.MANUFACTURER_S_WEBSI12156),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'GROUPBX_PSEUDNOVOGR01',
						maxLength: 256,
						labelId: 'label_GROUPBX_EQUIPSITEFABR',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					GROUPBX_WAREHWAREHDES: new fieldControlClass.LookupControl({
						modelField: 'TableWarehWarehdes',
						valueChangeEvent: 'fieldChange:wareh.warehdes',
						id: 'GROUPBX_WAREHWAREHDES',
						name: 'WAREHDES',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.WAREHOUSE51864),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'GROUPBX_PSEUDNOVOGR01',
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodwareh',
							dependencyEvent: 'fieldChange:equip.codwareh'
						},
						dependentFields: () => {
							return {
								set 'wareh.codwareh'(value) { vm.model.ValCodwareh.updateValue(value) },
								set 'wareh.warehdes'(value) { vm.model.TableWarehWarehdes.updateValue(value) },
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
					GROUPBX_ITEM_ITEMDES_: new fieldControlClass.LookupControl({
						modelField: 'TableItemItemdes',
						valueChangeEvent: 'fieldChange:item.itemdes',
						id: 'GROUPBX_ITEM_ITEMDES_',
						name: 'ITEMDES',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.ITEM_31041),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'GROUPBX_PSEUDNOVOGR01',
						mustBeFilled: false,
						controlLimits: [
							{
								identifier: ['wareh', 'equip.codwareh'],
								dependencyEvents: ['fieldChange:equip.codwareh'],
								dependencyField: 'EQUIP.CODWAREH',
								fnValueSelector: (model) => model.ValCodwareh.value
							},
						],
						lookupKeyModelField: {
							name: 'ValCoditem',
							dependencyEvent: 'fieldChange:equip.coditem'
						},
						dependentFields: () => {
							return {
								set 'item.coditem'(value) { vm.model.ValCoditem.updateValue(value) },
								set 'item.itemdes'(value) { vm.model.TableItemItemdes.updateValue(value) },
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
					GROUPBX_PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'GROUPBX_PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.WHOLE_LINE_ON08702),
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
					GROUPBX_EQUIPDTDECO__: new fieldControlClass.DateControl({
						modelField: 'ValDtdeco',
						valueChangeEvent: 'fieldChange:equip.dtdeco',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'GROUPBX_EQUIPDTDECO__',
						name: 'DTDECO',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.DECOMISSION_04392),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'GROUPBX_PSEUDNOVOGR02',
						isFormulaBlocked: true,
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					GROUPBX_ROOM1ROOMNR__: new fieldControlClass.LookupControl({
						modelField: 'TableRoom1Roomnr',
						valueChangeEvent: 'fieldChange:room1.roomnr',
						id: 'GROUPBX_ROOM1ROOMNR__',
						name: 'ROOMNR',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.ROOM_NO_08024),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'GROUPBX_PSEUDNOVOGR02',
						isFormulaBlocked: true,
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodrooms',
							dependencyEvent: 'fieldChange:equip.codrooms'
						},
						dependentFields: () => {
							return {
								set 'room1.codrooms'(value) { vm.model.ValCodrooms.updateValue(value) },
								set 'room1.roomnr'(value) { vm.model.TableRoom1Roomnr.updateValue(value) },
								set 'room1.designat'(value) { vm.model.Room1ValDesignat.updateValue(value) },
							}
						},
						isFixed: true,
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
					}, this),
					GROUPBX_ROOM1DESIGNAT: new fieldControlClass.StringControl({
						modelField: 'Room1ValDesignat',
						valueChangeEvent: 'fieldChange:room1.designat',
						dependentModelField: 'ValCodrooms',
						dependentChangeEvent: 'fieldChange:equip.codrooms',
						id: 'GROUPBX_ROOM1DESIGNAT',
						name: 'DESIGNAT',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.ROOM_DESIGNATION35483),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'GROUPBX_PSEUDNOVOGR02',
						isFormulaBlocked: true,
						maxLength: 50,
						labelId: 'label_GROUPBX_ROOM1DESIGNAT',
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					GROUPBX_EQUIPDESIGNAT: new fieldControlClass.StringControl({
						modelField: 'ValDesignat',
						valueChangeEvent: 'fieldChange:equip.designat',
						id: 'GROUPBX_EQUIPDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.DESIGNATION_35800),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'GROUPBX_PSEUDNOVOGR02',
						maxLength: 85,
						labelId: 'label_GROUPBX_EQUIPDESIGNAT',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					GROUPBX_EQUIPDTAQUISI: new fieldControlClass.DateControl({
						modelField: 'ValDtaquisi',
						valueChangeEvent: 'fieldChange:equip.dtaquisi',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'GROUPBX_EQUIPDTAQUISI',
						name: 'DTAQUISI',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.ACQUISITION_53832),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'GROUPBX_PSEUDNOVOGR02',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					GROUPBX_EQUIPVALORTOT: new fieldControlClass.CurrencyControl({
						modelField: 'ValValortot',
						valueChangeEvent: 'fieldChange:equip.valortot',
						maxIntegers: 9,
						maxDecimals: 2,
						id: 'GROUPBX_EQUIPVALORTOT',
						name: 'VALORTOT',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.TOTAL_VALUE_07456),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'GROUPBX_PSEUDNOVOGR02',
						isFormulaBlocked: true,
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					GROUPBX_EQUIPFREQUENC: new fieldControlClass.ArrayNumberControl({
						modelField: 'ValFrequenc',
						valueChangeEvent: 'fieldChange:equip.frequenc',
						maxIntegers: 1,
						maxDecimals: 0,
						id: 'GROUPBX_EQUIPFREQUENC',
						name: 'FREQUENC',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.LOAN_FREQUENCY00930),
						userHelp: computed(() => this.Resources.___1438719),
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'GROUPBX_PSEUDNOVOGR02',
						arrayName: 'FreqEmpr',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					GROUPBX_EQUIPDTREFERE: new fieldControlClass.DateControl({
						modelField: 'ValDtrefere',
						valueChangeEvent: 'fieldChange:equip.dtrefere',
						id: 'GROUPBX_EQUIPDTREFERE',
						name: 'DTREFERE',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.REFERENCE28402),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'GROUPBX_PSEUDNOVOGR02',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					GROUPBX_EQUIPFIRST___: new fieldControlClass.StringControl({
						modelField: 'ValFirst',
						valueChangeEvent: 'fieldChange:equip.first',
						id: 'GROUPBX_EQUIPFIRST___',
						name: 'FIRST',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.FIRST42972),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'GROUPBX_PSEUDNOVOGR02',
						isFormulaBlocked: true,
						maxLength: 10,
						labelId: 'label_GROUPBX_EQUIPFIRST___',
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					GROUPBX_EQUIPBEFORE__: new fieldControlClass.StringControl({
						modelField: 'ValBefore',
						valueChangeEvent: 'fieldChange:equip.before',
						id: 'GROUPBX_EQUIPBEFORE__',
						name: 'BEFORE',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.BEFORE60156),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'GROUPBX_PSEUDNOVOGR02',
						isFormulaBlocked: true,
						maxLength: 10,
						labelId: 'label_GROUPBX_EQUIPBEFORE__',
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					GROUPBX_EQUIPBOUGHT__: new fieldControlClass.BooleanControl({
						modelField: 'ValBought',
						valueChangeEvent: 'fieldChange:equip.bought',
						id: 'GROUPBX_EQUIPBOUGHT__',
						name: 'BOUGHT',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.BOUGHT32044),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'GROUPBX_PSEUDNOVOGR02',
						isFormulaBlocked: true,
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
				},

				model: new FormViewModel(this, {
					callbacks: {
						onUpdate: this.onUpdate,
						setFormKey: this.setFormKey
					}
				}),

				groupFields: readonly([
					'GROUPBX_PSEUDNOVOGR01',
					'GROUPBX_PSEUDNOVOGR02',
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Equip: {
						get ValBefore() { return vm.model.ValBefore.value },
						set ValBefore(value) { vm.model.ValBefore.updateValue(value) },
						get ValBought() { return vm.model.ValBought.value },
						set ValBought(value) { vm.model.ValBought.updateValue(value) },
						get ValCoddeco() { return vm.model.ValCoddeco.value },
						set ValCoddeco(value) { vm.model.ValCoddeco.updateValue(value) },
						get ValCodempre() { return vm.model.ValCodempre.value },
						set ValCodempre(value) { vm.model.ValCodempre.updateValue(value) },
						get ValCoditem() { return vm.model.ValCoditem.value },
						set ValCoditem(value) { vm.model.ValCoditem.updateValue(value) },
						get ValCodpess1() { return vm.model.ValCodpess1.value },
						set ValCodpess1(value) { vm.model.ValCodpess1.updateValue(value) },
						get ValCodrooms() { return vm.model.ValCodrooms.value },
						set ValCodrooms(value) { vm.model.ValCodrooms.updateValue(value) },
						get ValCodtpequ() { return vm.model.ValCodtpequ.value },
						set ValCodtpequ(value) { vm.model.ValCodtpequ.updateValue(value) },
						get ValCodwareh() { return vm.model.ValCodwareh.value },
						set ValCodwareh(value) { vm.model.ValCodwareh.updateValue(value) },
						get ValDesignat() { return vm.model.ValDesignat.value },
						set ValDesignat(value) { vm.model.ValDesignat.updateValue(value) },
						get ValDtaquisi() { return vm.model.ValDtaquisi.value },
						set ValDtaquisi(value) { vm.model.ValDtaquisi.updateValue(value) },
						get ValDtdeco() { return vm.model.ValDtdeco.value },
						set ValDtdeco(value) { vm.model.ValDtdeco.updateValue(value) },
						get ValDtrefere() { return vm.model.ValDtrefere.value },
						set ValDtrefere(value) { vm.model.ValDtrefere.updateValue(value) },
						get ValFirst() { return vm.model.ValFirst.value },
						set ValFirst(value) { vm.model.ValFirst.updateValue(value) },
						get ValFrequenc() { return vm.model.ValFrequenc.value },
						set ValFrequenc(value) { vm.model.ValFrequenc.updateValue(value) },
						get ValRegistnr() { return vm.model.ValRegistnr.value },
						set ValRegistnr(value) { vm.model.ValRegistnr.updateValue(value) },
						get ValSequennr() { return vm.model.ValSequennr.value },
						set ValSequennr(value) { vm.model.ValSequennr.updateValue(value) },
						get ValSitefabr() { return vm.model.ValSitefabr.value },
						set ValSitefabr(value) { vm.model.ValSitefabr.updateValue(value) },
						get ValValortot() { return vm.model.ValValortot.value },
						set ValValortot(value) { vm.model.ValValortot.updateValue(value) },
					},
					Item: {
						get ValItemdes() { return vm.model.TableItemItemdes.value },
						set ValItemdes(value) { vm.model.TableItemItemdes.updateValue(value) },
					},
					Room1: {
						get ValDesignat() { return vm.model.Room1ValDesignat.value },
						set ValDesignat(value) { vm.model.Room1ValDesignat.updateValue(value) },
						get ValRoomnr() { return vm.model.TableRoom1Roomnr.value },
						set ValRoomnr(value) { vm.model.TableRoom1Roomnr.updateValue(value) },
					},
					Tpequ: {
						get ValTipoequi() { return vm.model.TableTpequTipoequi.value },
						set ValTipoequi(value) { vm.model.TableTpequTipoequi.updateValue(value) },
					},
					Wareh: {
						get ValWarehdes() { return vm.model.TableWarehWarehdes.value },
						set ValWarehdes(value) { vm.model.TableWarehWarehdes.updateValue(value) },
					},
					keys: {
						/** The primary key of the EQUIP table */
						get equip() { return vm.model.ValCodequip },
						/** The foreign key to the CMPNY table */
						get cmpny() { return vm.model.ValCodempre },
						/** The foreign key to the PESS1 table */
						get pess1() { return vm.model.ValCodpess1 },
						/** The foreign key to the TPEQU table */
						get tpequ() { return vm.model.ValCodtpequ },
						/** The foreign key to the WAREH table */
						get wareh() { return vm.model.ValCodwareh },
						/** The foreign key to the ITEM table */
						get item() { return vm.model.ValCoditem },
						/** The foreign key to the DECOM table */
						get decom() { return vm.model.ValCoddeco },
						/** The foreign key to the ROOM1 table */
						get room1() { return vm.model.ValCodrooms },
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
// USE /[MANUAL GQT FORM_CODEJS GROUPBX]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS GROUPBX]/
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
// USE /[MANUAL GQT FORM_LOADED_JS GROUPBX]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS GROUPBX]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS GROUPBX]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS GROUPBX]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS GROUPBX]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS GROUPBX]/
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
// USE /[MANUAL GQT AFTER_DEL_JS GROUPBX]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS GROUPBX]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS GROUPBX]/
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
// USE /[MANUAL GQT DLGUPDT GROUPBX]/
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
// USE /[MANUAL GQT CTRLUPD GROUPBX]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
		},

		watch: {
		}
	}
</script>
