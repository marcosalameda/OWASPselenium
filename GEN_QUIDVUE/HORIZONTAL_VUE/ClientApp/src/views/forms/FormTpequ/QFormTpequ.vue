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
					class="form-header"
					:id="formTitleId">
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
			data-key="TPEQU"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container
					v-show="controls.TPEQU___PSEUDNOVOGR01.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.TPEQU___PSEUDNOVOGR01.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="TPEQU___PSEUDNOVOGR01"
							v-bind="controls.TPEQU___PSEUDNOVOGR01"
							:is-visible="controls.TPEQU___PSEUDNOVOGR01.isVisible">
							<!-- Start TPEQU___PSEUDNOVOGR01 -->
							<q-row-container v-show="controls.TPEQU___FAMILFAMILY__.isVisible || controls.TPEQU___TPEQUTIPOEQUI.isVisible || controls.TPEQU___TPEQUTPEQUCOD.isVisible || controls.TPEQU___TPEQUNIVEL___.isVisible || controls.TPEQU___TPEQUTPEQUPAI.isVisible">
								<q-control-wrapper
									v-show="controls.TPEQU___FAMILFAMILY__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.TPEQU___FAMILFAMILY__"
										v-on="controls.TPEQU___FAMILFAMILY__.handlers"
										:loading="controls.TPEQU___FAMILFAMILY__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.TPEQU___FAMILFAMILY__.isVisible"
											v-bind="controls.TPEQU___FAMILFAMILY__.props"
											v-on="controls.TPEQU___FAMILFAMILY__.handlers" />
										<q-see-more-tpequ-familfamily
											v-if="controls.TPEQU___FAMILFAMILY__.seeMoreIsVisible"
											v-bind="controls.TPEQU___FAMILFAMILY__.seeMoreParams"
											v-on="controls.TPEQU___FAMILFAMILY__.handlers" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.TPEQU___TPEQUTIPOEQUI.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.TPEQU___TPEQUTIPOEQUI"
										v-on="controls.TPEQU___TPEQUTIPOEQUI.handlers"
										:loading="controls.TPEQU___TPEQUTIPOEQUI.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.TPEQU___TPEQUTIPOEQUI.props"
											:model-value="model.ValTipoequi.value"
											@blur="onBlur(controls.TPEQU___TPEQUTIPOEQUI, model.ValTipoequi.value)"
											@change="model.ValTipoequi.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.TPEQU___TPEQUTPEQUCOD.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.TPEQU___TPEQUTPEQUCOD"
										v-on="controls.TPEQU___TPEQUTPEQUCOD.handlers"
										:loading="controls.TPEQU___TPEQUTPEQUCOD.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.TPEQU___TPEQUTPEQUCOD.props"
											:model-value="model.ValTpequcod.value"
											@blur="onBlur(controls.TPEQU___TPEQUTPEQUCOD, model.ValTpequcod.value)"
											@change="model.ValTpequcod.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.TPEQU___TPEQUNIVEL___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.TPEQU___TPEQUNIVEL___"
										v-on="controls.TPEQU___TPEQUNIVEL___.handlers"
										:loading="controls.TPEQU___TPEQUNIVEL___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.TPEQU___TPEQUNIVEL___.isVisible"
											v-bind="controls.TPEQU___TPEQUNIVEL___.props"
											@update:model-value="model.ValNivel.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.TPEQU___TPEQUTPEQUPAI.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.TPEQU___TPEQUTPEQUPAI"
										v-on="controls.TPEQU___TPEQUTPEQUPAI.handlers"
										:loading="controls.TPEQU___TPEQUTPEQUPAI.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.TPEQU___TPEQUTPEQUPAI.props"
											:model-value="model.ValTpequpai.value"
											@blur="onBlur(controls.TPEQU___TPEQUTPEQUPAI, model.ValTpequpai.value)"
											@change="model.ValTpequpai.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.TPEQU___TPEQUQTDEQUIP.isVisible">
								<q-control-wrapper
									v-show="controls.TPEQU___TPEQUQTDEQUIP.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.TPEQU___TPEQUQTDEQUIP"
										v-on="controls.TPEQU___TPEQUQTDEQUIP.handlers"
										:loading="controls.TPEQU___TPEQUQTDEQUIP.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.TPEQU___TPEQUQTDEQUIP.isVisible"
											v-bind="controls.TPEQU___TPEQUQTDEQUIP.props"
											@update:model-value="model.ValQtdequip.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End TPEQU___PSEUDNOVOGR01 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.TPEQU___PSEUDNOVOGR05.isVisible || controls.TPEQU___PSEUDUNICO___.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.TPEQU___PSEUDNOVOGR05.isVisible"
						class="row-line-group">
						<q-accordion-container
							id="TPEQU___PSEUDNOVOGR05"
							v-bind="controls.TPEQU___PSEUDNOVOGR05"
							v-on="controls.TPEQU___PSEUDNOVOGR05.handlers"
							v-slot="{ onStateChanged }">
							<!-- Start TPEQU___PSEUDNOVOGR05 -->
							<q-group-collapsible
								id="TPEQU___PSEUDNOVOGR04"
								v-bind="controls.TPEQU___PSEUDNOVOGR04"
								v-on="controls.TPEQU___PSEUDNOVOGR04.handlers"
								@state-changed="(state, groupId) => onStateChanged(state, groupId)">
								<!-- Start TPEQU___PSEUDNOVOGR04 -->
								<q-row-container v-show="controls.TPEQU___TPEQUKIT_____.isVisible">
									<q-control-wrapper
										v-show="controls.TPEQU___TPEQUKIT_____.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-checkbox"
											v-bind="controls.TPEQU___TPEQUKIT_____"
											v-on="controls.TPEQU___TPEQUKIT_____.handlers"
											:loading="controls.TPEQU___TPEQUKIT_____.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<template #label>
												<q-checkbox-input
													v-if="controls.TPEQU___TPEQUKIT_____.isVisible"
													v-bind="controls.TPEQU___TPEQUKIT_____.props"
													@update:model-value="model.ValKit.fnUpdateValue" />
											</template>
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.TPEQU___PSEUDCOMPONEN.isVisible">
									<q-control-wrapper
										v-show="controls.TPEQU___PSEUDCOMPONEN.isVisible"
										class="control-join-group">
										<q-table
											v-show="controls.TPEQU___PSEUDCOMPONEN.isVisible"
											v-bind="controls.TPEQU___PSEUDCOMPONEN"
											v-on="controls.TPEQU___PSEUDCOMPONEN.handlers" />
										<q-table-extra-extension
											:list-ctrl="controls.TPEQU___PSEUDCOMPONEN"
											v-on="controls.TPEQU___PSEUDCOMPONEN.handlers" />
									</q-control-wrapper>
								</q-row-container>
								<!-- End TPEQU___PSEUDNOVOGR04 -->
							</q-group-collapsible>
							<q-group-collapsible
								id="TPEQU___PSEUDNOVOGR03"
								v-bind="controls.TPEQU___PSEUDNOVOGR03"
								v-on="controls.TPEQU___PSEUDNOVOGR03.handlers"
								@state-changed="(state, groupId) => onStateChanged(state, groupId)">
								<!-- Start TPEQU___PSEUDNOVOGR03 -->
								<q-row-container v-show="controls.TPEQU___TPEQUPRECOMAX.isVisible || controls.TPEQU___TPEQUPRECOULT.isVisible || controls.TPEQU___TPEQUSINCE___.isVisible || controls.TPEQU___PSEUDEVOLUCAO.isVisible">
									<q-control-wrapper
										v-show="controls.TPEQU___TPEQUPRECOMAX.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.TPEQU___TPEQUPRECOMAX"
											v-on="controls.TPEQU___TPEQUPRECOMAX.handlers"
											:loading="controls.TPEQU___TPEQUPRECOMAX.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-numeric-input
												v-if="controls.TPEQU___TPEQUPRECOMAX.isVisible"
												v-bind="controls.TPEQU___TPEQUPRECOMAX.props"
												@update:model-value="model.ValPrecomax.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
									<q-control-wrapper
										v-show="controls.TPEQU___TPEQUPRECOULT.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.TPEQU___TPEQUPRECOULT"
											v-on="controls.TPEQU___TPEQUPRECOULT.handlers"
											:loading="controls.TPEQU___TPEQUPRECOULT.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-numeric-input
												v-if="controls.TPEQU___TPEQUPRECOULT.isVisible"
												v-bind="controls.TPEQU___TPEQUPRECOULT.props"
												@update:model-value="model.ValPrecoult.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
									<q-control-wrapper
										v-show="controls.TPEQU___TPEQUSINCE___.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.TPEQU___TPEQUSINCE___"
											v-on="controls.TPEQU___TPEQUSINCE___.handlers"
											:loading="controls.TPEQU___TPEQUSINCE___.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-date-time-picker
												v-if="controls.TPEQU___TPEQUSINCE___.isVisible"
												v-bind="controls.TPEQU___TPEQUSINCE___.props"
												:model-value="model.ValSince.value"
												@reset-icon-click="model.ValSince.fnUpdateValue(model.ValSince.originalValue ?? new Date())"
												@update:model-value="model.ValSince.fnUpdateValue($event ?? '')" />
										</base-input-structure>
									</q-control-wrapper>
									<q-control-wrapper
										v-show="controls.TPEQU___PSEUDEVOLUCAO.isVisible"
										class="control-join-group">
										<q-table
											v-show="controls.TPEQU___PSEUDEVOLUCAO.isVisible"
											v-bind="controls.TPEQU___PSEUDEVOLUCAO"
											v-on="controls.TPEQU___PSEUDEVOLUCAO.handlers" />
										<q-table-extra-extension
											:list-ctrl="controls.TPEQU___PSEUDEVOLUCAO"
											v-on="controls.TPEQU___PSEUDEVOLUCAO.handlers" />
									</q-control-wrapper>
								</q-row-container>
								<!-- End TPEQU___PSEUDNOVOGR03 -->
							</q-group-collapsible>
							<q-group-collapsible
								id="TPEQU___PSEUDNOVOGR02"
								v-bind="controls.TPEQU___PSEUDNOVOGR02"
								v-on="controls.TPEQU___PSEUDNOVOGR02.handlers"
								@state-changed="(state, groupId) => onStateChanged(state, groupId)">
								<!-- Start TPEQU___PSEUDNOVOGR02 -->
								<q-row-container v-show="controls.TPEQU___TPEQUBACKCOLO.isVisible || controls.TPEQU___TPEQUCORLETRA.isVisible">
									<q-control-wrapper
										v-show="controls.TPEQU___TPEQUBACKCOLO.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.TPEQU___TPEQUBACKCOLO"
											v-on="controls.TPEQU___TPEQUBACKCOLO.handlers"
											:loading="controls.TPEQU___TPEQUBACKCOLO.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.TPEQU___TPEQUBACKCOLO.props"
												:model-value="model.ValBackcolo.value"
												@blur="onBlur(controls.TPEQU___TPEQUBACKCOLO, model.ValBackcolo.value)"
												@change="model.ValBackcolo.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-control-wrapper>
									<q-control-wrapper
										v-show="controls.TPEQU___TPEQUCORLETRA.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.TPEQU___TPEQUCORLETRA"
											v-on="controls.TPEQU___TPEQUCORLETRA.handlers"
											:loading="controls.TPEQU___TPEQUCORLETRA.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.TPEQU___TPEQUCORLETRA.props"
												:model-value="model.ValCorletra.value"
												@blur="onBlur(controls.TPEQU___TPEQUCORLETRA, model.ValCorletra.value)"
												@change="model.ValCorletra.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<!-- End TPEQU___PSEUDNOVOGR02 -->
							</q-group-collapsible>
							<q-group-collapsible
								id="TPEQU___PSEUDNOVOGR06"
								v-bind="controls.TPEQU___PSEUDNOVOGR06"
								v-on="controls.TPEQU___PSEUDNOVOGR06.handlers"
								@state-changed="(state, groupId) => onStateChanged(state, groupId)">
								<!-- Start TPEQU___PSEUDNOVOGR06 -->
								<q-row-container v-show="controls.TPEQU___PSEUDINSTALAC.isVisible || controls.TPEQU___PSEUDINSTALA1.isVisible">
									<q-control-wrapper
										v-show="controls.TPEQU___PSEUDINSTALAC.isVisible"
										class="control-join-group">
										<q-table
											v-show="controls.TPEQU___PSEUDINSTALAC.isVisible"
											v-bind="controls.TPEQU___PSEUDINSTALAC"
											v-on="controls.TPEQU___PSEUDINSTALAC.handlers" />
										<q-table-extra-extension
											:list-ctrl="controls.TPEQU___PSEUDINSTALAC"
											v-on="controls.TPEQU___PSEUDINSTALAC.handlers" />
									</q-control-wrapper>
									<q-control-wrapper
										v-show="controls.TPEQU___PSEUDINSTALA1.isVisible"
										class="control-join-group">
										<q-table
											v-show="controls.TPEQU___PSEUDINSTALA1.isVisible"
											v-bind="controls.TPEQU___PSEUDINSTALA1"
											v-on="controls.TPEQU___PSEUDINSTALA1.handlers" />
										<q-table-extra-extension
											:list-ctrl="controls.TPEQU___PSEUDINSTALA1"
											v-on="controls.TPEQU___PSEUDINSTALA1.handlers" />
									</q-control-wrapper>
								</q-row-container>
								<!-- End TPEQU___PSEUDNOVOGR06 -->
							</q-group-collapsible>
							<!-- End TPEQU___PSEUDNOVOGR05 -->
						</q-accordion-container>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.TPEQU___PSEUDUNICO___.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-button"
							v-bind="controls.TPEQU___PSEUDUNICO___"
							v-on="controls.TPEQU___PSEUDUNICO___.handlers"
							:loading="controls.TPEQU___PSEUDUNICO___.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-button
								v-if="controls.TPEQU___PSEUDUNICO___.isVisible"
								id="TPEQU___PSEUDUNICO___"
								:label="controls.TPEQU___PSEUDUNICO___.label"
								:disabled="controls.TPEQU___PSEUDUNICO___.isBlocked"
								@click="controls.TPEQU___PSEUDUNICO___.action($event)">
								<q-icon v-bind="controls.TPEQU___PSEUDUNICO___.icon" />
							</q-button>
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

	import FormViewModel from './QFormTpequViewModel.js'

	const requiredTextResources = ['QFormTpequ', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS TPEQU]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormTpequ',

		components: {
			QSeeMoreTpequFamilfamily: defineAsyncComponent(() => import('@/views/forms/FormTpequ/dbedits/TpequFamilfamilySeeMore.vue')),
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
					name: 'TPEQU',
					location: 'form-TPEQU',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormTpequ', false),

				interfaceMetadata: {
					id: 'QFormTpequ', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'TPEQU',
					route: 'form-TPEQU',
					area: 'TPEQU',
					primaryKey: 'ValCodtpequ',
					designation: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
					identifier: '', // Unique identifier received by route (when it's nested).
					mode: ''
				},

				formTitleId: computed(() => this.formInfo.identifier + "_title"),

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
					TPEQU___PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'TPEQU___PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						label: computed(() => this.Resources.IDENTIFICATION40793),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					TPEQU___FAMILFAMILY__: new fieldControlClass.LookupControl({
						modelField: 'TableFamilFamily',
						valueChangeEvent: 'fieldChange:famil.family',
						id: 'TPEQU___FAMILFAMILY__',
						name: 'FAMILY',
						size: 'xlarge',
						label: computed(() => this.Resources.EQUIPMENT_FAMILY41883),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'TPEQU___PSEUDNOVOGR01',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodfamil',
							dependencyEvent: 'fieldChange:tpequ.codfamil'
						},
						dependentFields: () => ({
							set 'famil.codfamil'(value) { vm.model.ValCodfamil.updateValue(value) },
							set 'famil.family'(value) { vm.model.TableFamilFamily.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					TPEQU___TPEQUTIPOEQUI: new fieldControlClass.StringControl({
						modelField: 'ValTipoequi',
						valueChangeEvent: 'fieldChange:tpequ.tipoequi',
						id: 'TPEQU___TPEQUTIPOEQUI',
						name: 'TIPOEQUI',
						size: 'xlarge',
						label: computed(() => this.Resources.TYPE_OF_EQUIPMENT64921),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'TPEQU___PSEUDNOVOGR01',
						maxLength: 50,
						labelId: 'label_TPEQU___TPEQUTIPOEQUI',
						controlLimits: [
						],
					}, this),
					TPEQU___TPEQUTPEQUCOD: new fieldControlClass.StringControl({
						modelField: 'ValTpequcod',
						valueChangeEvent: 'fieldChange:tpequ.tpequcod',
						id: 'TPEQU___TPEQUTPEQUCOD',
						name: 'TPEQUCOD',
						size: 'medium',
						label: computed(() => this.Resources.CODE49225),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'TPEQU___PSEUDNOVOGR01',
						maxLength: 20,
						labelId: 'label_TPEQU___TPEQUTPEQUCOD',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					TPEQU___TPEQUNIVEL___: new fieldControlClass.NumberControl({
						modelField: 'ValNivel',
						valueChangeEvent: 'fieldChange:tpequ.nivel',
						id: 'TPEQU___TPEQUNIVEL___',
						name: 'NIVEL',
						size: 'small',
						label: computed(() => this.Resources.LEVEL_43678),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'TPEQU___PSEUDNOVOGR01',
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					TPEQU___PSEUDNOVOGR05: new fieldControlClass.AccordionControl({
						id: 'TPEQU___PSEUDNOVOGR05',
						name: 'NOVOGR05',
						size: 'block',
						label: computed(() => this.Resources.ACCORDION01950),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						controlLimits: [
						],
					}, this),
					TPEQU___PSEUDNOVOGR04: new fieldControlClass.GroupControl({
						id: 'TPEQU___PSEUDNOVOGR04',
						name: 'NOVOGR04',
						size: 'block',
						label: computed(() => this.Resources.SET52194),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'TPEQU___PSEUDNOVOGR05',
						isCollapsible: true,
						anchored: false,
						openingEvent: 'opened-TPEQU___PSEUDNOVOGR04',
						isInAccordion: true,
						controlLimits: [
						],
					}, this),
					TPEQU___TPEQUKIT_____: new fieldControlClass.BooleanControl({
						modelField: 'ValKit',
						valueChangeEvent: 'fieldChange:tpequ.kit',
						id: 'TPEQU___TPEQUKIT_____',
						name: 'KIT',
						size: 'mini',
						label: computed(() => this.Resources.KIT27179),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						parentOpeningEvent: 'opened-TPEQU___PSEUDNOVOGR04',
						container: 'TPEQU___PSEUDNOVOGR04',
						controlLimits: [
						],
					}, this),
					TPEQU___TPEQUPRECOMAX: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrecomax',
						valueChangeEvent: 'fieldChange:tpequ.precomax',
						id: 'TPEQU___TPEQUPRECOMAX',
						name: 'PRECOMAX',
						size: 'medium',
						label: computed(() => this.Resources.MAXIMUM_PRICE26470),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-TPEQU___PSEUDNOVOGR03',
						container: 'TPEQU___PSEUDNOVOGR03',
						isFormulaBlocked: true,
						maxIntegers: 9,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					TPEQU___TPEQUBACKCOLO: new fieldControlClass.StringControl({
						modelField: 'ValBackcolo',
						valueChangeEvent: 'fieldChange:tpequ.backcolo',
						id: 'TPEQU___TPEQUBACKCOLO',
						name: 'BACKCOLO',
						size: 'xlarge',
						label: computed(() => this.Resources.BACKGROUND_COLOR07511),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-TPEQU___PSEUDNOVOGR02',
						container: 'TPEQU___PSEUDNOVOGR02',
						maxLength: 50,
						labelId: 'label_TPEQU___TPEQUBACKCOLO',
						controlLimits: [
						],
					}, this),
					TPEQU___TPEQUCORLETRA: new fieldControlClass.StringControl({
						modelField: 'ValCorletra',
						valueChangeEvent: 'fieldChange:tpequ.corletra',
						id: 'TPEQU___TPEQUCORLETRA',
						name: 'CORLETRA',
						size: 'xlarge',
						label: computed(() => this.Resources.LETTER_COLOR63305),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-TPEQU___PSEUDNOVOGR02',
						container: 'TPEQU___PSEUDNOVOGR02',
						maxLength: 50,
						labelId: 'label_TPEQU___TPEQUCORLETRA',
						controlLimits: [
						],
					}, this),
					TPEQU___TPEQUTPEQUPAI: new fieldControlClass.StringControl({
						modelField: 'ValTpequpai',
						valueChangeEvent: 'fieldChange:tpequ.tpequpai',
						id: 'TPEQU___TPEQUTPEQUPAI',
						name: 'TPEQUPAI',
						size: 'medium',
						label: computed(() => this.Resources.DEPENDENCE_ON13941),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'TPEQU___PSEUDNOVOGR01',
						maxLength: 20,
						labelId: 'label_TPEQU___TPEQUTPEQUPAI',
						controlLimits: [
						],
					}, this),
					TPEQU___TPEQUPRECOULT: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrecoult',
						valueChangeEvent: 'fieldChange:tpequ.precoult',
						id: 'TPEQU___TPEQUPRECOULT',
						name: 'PRECOULT',
						size: 'medium',
						label: computed(() => this.Resources.LAST_PRICE56195),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-TPEQU___PSEUDNOVOGR03',
						container: 'TPEQU___PSEUDNOVOGR03',
						isFormulaBlocked: true,
						maxIntegers: 9,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					TPEQU___TPEQUSINCE___: new fieldControlClass.DateControl({
						modelField: 'ValSince',
						valueChangeEvent: 'fieldChange:tpequ.since',
						id: 'TPEQU___TPEQUSINCE___',
						name: 'SINCE',
						size: 'medium',
						label: computed(() => this.Resources.SINCE47259),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-TPEQU___PSEUDNOVOGR03',
						container: 'TPEQU___PSEUDNOVOGR03',
						isFormulaBlocked: true,
						format: 'dateTime',
						controlLimits: [
						],
					}, this),
					TPEQU___PSEUDCOMPONEN: new fieldControlClass.TableListControl({
						id: 'TPEQU___PSEUDCOMPONEN',
						name: 'COMPONEN',
						size: '',
						label: computed(() => this.Resources.COMPONENTES_DO_KIT59823),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-TPEQU___PSEUDNOVOGR04',
						container: 'TPEQU___PSEUDNOVOGR04',
						controller: 'TPEQU',
						action: 'Tpequ_ValComponen',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.NumericColumn({
								order: 1,
								name: 'ValOrder',
								area: 'CMPKI',
								field: 'ORDER',
								label: computed(() => this.Resources.ORDER39632),
								scrollData: 5,
								maxDigits: 3,
								decimalPlaces: 1,
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'Tpeq1.ValTipoequi',
								area: 'TPEQ1',
								field: 'TIPOEQUI',
								label: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
								dataLength: 50,
								scrollData: 50,
								pkColumn: 'ValCodtpequ',
							}),
							new listColumnTypes.NumericColumn({
								order: 3,
								name: 'ValQuantida',
								area: 'CMPKI',
								field: 'QUANTIDA',
								label: computed(() => this.Resources.AMOUNT46885),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValDescript',
								area: 'CMPKI',
								field: 'DESCRIPT',
								label: computed(() => this.Resources.DESCRIPTION07383),
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValCode',
								area: 'CMPKI',
								field: 'CODE',
								label: computed(() => this.Resources.CODE49225),
								dataLength: 10,
								scrollData: 10,
							}),
							new listColumnTypes.HyperLinkColumn({
								order: 6,
								name: 'ValUrl',
								area: 'CMPKI',
								field: 'URL',
								label: computed(() => this.Resources.SITE06486),
								dataLength: 250,
								scrollData: 30,
							}),
						],
						config: {
							name: 'ValComponen',
							serverMode: true,
							pkColumn: 'ValCodcmpki',
							tableAlias: 'CMPKI',
							tableNamePlural: computed(() => this.Resources.KIT_COMPONENTS50945),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.COMPONENTES_DO_KIT59823),
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
										formName: 'CMPKI',
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
										formName: 'CMPKI',
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
										formName: 'CMPKI',
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
										formName: 'CMPKI',
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
										formName: 'CMPKI',
										mode: 'NEW',
										repeatInsertion: true,
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
								id: 'RCA__CMPKI',
								name: '_CMPKI',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									canExecuteAction: vm.applyChanges,
									action: vm.openFormAction,
									type: 'form',
									formName: 'CMPKI',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'CMPKI': {
									fnKeySelector: (row) => row.Fields.ValCodcmpki,
									isPopup: false
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'ValOrder',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-TPEQ1', 'changed-CMPKI', 'changed-TPEQU'],
						uuid: 'Tpequ_ValComponen',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'tpequ'],
								dependencyEvents: ['fieldChange:tpequ.codtpequ'],
								dependencyField: 'TPEQU.CODTPEQU',
								fnValueSelector: (model) => model.ValCodtpequ.value
							},
						],
					}, this),
					TPEQU___PSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'TPEQU___PSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'block',
						label: computed(() => this.Resources.PRICES46162),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'TPEQU___PSEUDNOVOGR05',
						isCollapsible: true,
						anchored: false,
						openingEvent: 'opened-TPEQU___PSEUDNOVOGR03',
						isInAccordion: true,
						controlLimits: [
						],
					}, this),
					TPEQU___PSEUDEVOLUCAO: new fieldControlClass.TableListControl({
						id: 'TPEQU___PSEUDEVOLUCAO',
						name: 'EVOLUCAO',
						size: '',
						label: computed(() => this.Resources.C51806),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-TPEQU___PSEUDNOVOGR03',
						container: 'TPEQU___PSEUDNOVOGR03',
						controller: 'TPEQU',
						action: 'Tpequ_ValEvolucao',
						hasDependencies: true,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValSince',
								area: 'TABPR',
								field: 'SINCE',
								label: computed(() => this.Resources.SINCE47259),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.CurrencyColumn({
								order: 2,
								name: 'ValPrecohor',
								area: 'TABPR',
								field: 'PRECOHOR',
								label: computed(() => this.Resources.PRICE_BY_HOUR01060),
								scrollData: 16,
								maxDigits: 9,
								decimalPlaces: 0,
							}),
						],
						config: {
							name: 'ValEvolucao',
							serverMode: true,
							pkColumn: 'ValCodtabpr',
							tableAlias: 'TABPR',
							tableNamePlural: computed(() => this.Resources.TABLE_PRICES17726),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.C51806),
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
										formName: 'TABPR',
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
										formName: 'TABPR',
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
										formName: 'TABPR',
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
										formName: 'TABPR',
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
										formName: 'TABPR',
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
								id: 'RCA__TABPR',
								name: '_TABPR',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									canExecuteAction: vm.applyChanges,
									action: vm.openFormAction,
									type: 'form',
									formName: 'TABPR',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'TABPR': {
									fnKeySelector: (row) => row.Fields.ValCodtabpr,
									isPopup: false
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-TPEQU', 'changed-TABPR'],
						uuid: 'Tpequ_ValEvolucao',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'tpequ'],
								dependencyEvents: ['fieldChange:tpequ.codtpequ'],
								dependencyField: 'TPEQU.CODTPEQU',
								fnValueSelector: (model) => model.ValCodtpequ.value
							},
						],
					}, this),
					TPEQU___PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'TPEQU___PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'block',
						label: computed(() => this.Resources.HIGHLIGHT63510),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'TPEQU___PSEUDNOVOGR05',
						isCollapsible: true,
						anchored: false,
						openingEvent: 'opened-TPEQU___PSEUDNOVOGR02',
						isInAccordion: true,
						controlLimits: [
						],
					}, this),
					TPEQU___PSEUDUNICO___: new fieldControlClass.ButtonControl({
						id: 'TPEQU___PSEUDUNICO___',
						name: 'UNICO',
						size: 'small',
						hasLabel: false,
						label: computed(() => this.Resources.UNIQUE52117),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						icon: {
							icon: computed(() => `${this.system.resourcesPath}ok.ico`),
							type: 'img',
							role: 'presentation',
						},
						// eslint-disable-next-line
						action: (event) => {
							let btnAction = () => {
								if (!vm.isEditable)
									return Promise.resolve(true)

								const action = 'GetCarga_unico'
								const params = { idsrc: vm.primaryKeyValue }

								return netAPI.postData(
									vm.formInfo.area,
									action,
									params,
									(data) => {
										if (data.Success)
										{
											genericFunctions.displayMessage(data.data, 'success')
											vm.fetchFormFields(true)
										}
										else
											genericFunctions.displayMessage(data.data, 'error')
									},
									undefined,
									undefined,
									vm.navigationId)
							}
							let options = {
								form: 'TPEQU',
								callback: btnAction
							}
							vm.$eventHub.emit('form-apply', options)
						},
						controlLimits: [
						],
					}, this),
					TPEQU___PSEUDNOVOGR06: new fieldControlClass.GroupControl({
						id: 'TPEQU___PSEUDNOVOGR06',
						name: 'NOVOGR06',
						size: 'block',
						label: computed(() => this.Resources.FACILITIES10422),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'TPEQU___PSEUDNOVOGR05',
						isCollapsible: true,
						anchored: false,
						openingEvent: 'opened-TPEQU___PSEUDNOVOGR06',
						isInAccordion: true,
						controlLimits: [
						],
					}, this),
					TPEQU___PSEUDINSTALAC: new fieldControlClass.TableListControl({
						id: 'TPEQU___PSEUDINSTALAC',
						name: 'INSTALAC',
						size: '',
						label: computed(() => this.Resources.FACILITIES_23844),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-TPEQU___PSEUDNOVOGR06',
						container: 'TPEQU___PSEUDNOVOGR06',
						controller: 'TPEQU',
						action: 'Tpequ_ValInstalac',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValDesignat',
								area: 'INSTA',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.SCHEDULING24801),
								dataLength: 85,
								scrollData: 30,
							}),
							new listColumnTypes.DateColumn({
								order: 2,
								name: 'ValDtiniage',
								area: 'INSTA',
								field: 'DTINIAGE',
								label: computed(() => this.Resources.BEGINNING18124),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.DateColumn({
								order: 3,
								name: 'ValDtfimage',
								area: 'INSTA',
								field: 'DTFIMAGE',
								label: computed(() => this.Resources.END47577),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValDescript',
								area: 'INSTA',
								field: 'DESCRIPT',
								label: computed(() => this.Resources.DESCRIPTION07383),
								scrollData: 30,
							}),
							new listColumnTypes.BooleanColumn({
								order: 5,
								name: 'ValAllday',
								area: 'INSTA',
								field: 'ALLDAY',
								label: computed(() => this.Resources.ALL_DAY18496),
								scrollData: 1,
							}),
							new listColumnTypes.DateColumn({
								order: 6,
								name: 'ValSince',
								area: 'INSTA',
								field: 'SINCE',
								label: computed(() => this.Resources.SINCE47259),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.DateColumn({
								order: 7,
								name: 'ValUntil',
								area: 'INSTA',
								field: 'UNTIL',
								label: computed(() => this.Resources.UNTIL39173),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.NumericColumn({
								order: 8,
								name: 'ValHours',
								area: 'INSTA',
								field: 'HOURS',
								label: computed(() => this.Resources.QTD_HOURS28684),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 2,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 9,
								name: 'ValPrecohor',
								area: 'INSTA',
								field: 'PRECOHOR',
								label: computed(() => this.Resources.HOURLY_PRICE48005),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 0,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 10,
								name: 'ValValue',
								area: 'INSTA',
								field: 'VALUE',
								label: computed(() => this.Resources.VALUE10285),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 0,
							}),
							new listColumnTypes.GeographicColumn({
								order: 11,
								name: 'ValCoordgeo',
								area: 'INSTA',
								field: 'COORDGEO',
								label: computed(() => this.Resources.GEOGRAPHIC_COORDINAT21394),
								dataLength: 50,
								scrollData: 30,
								sortable: false,
								searchable: false,
							}),
						],
						config: {
							name: 'ValInstalac',
							serverMode: true,
							pkColumn: 'ValCodinsta',
							tableAlias: 'INSTA',
							tableNamePlural: computed(() => this.Resources.FACILITIES08876),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.FACILITIES_23844),
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
										formName: 'INSTA',
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
										formName: 'INSTA',
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
										formName: 'INSTA',
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
										formName: 'INSTA',
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
										formName: 'INSTA',
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
								id: 'RCA__INSTA',
								name: '_INSTA',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									canExecuteAction: vm.applyChanges,
									action: vm.openFormAction,
									type: 'form',
									formName: 'INSTA',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'INSTA': {
									fnKeySelector: (row) => row.Fields.ValCodinsta,
									isPopup: false
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-INSTA', 'changed-EQUIP', 'changed-TPEQU'],
						uuid: 'Tpequ_ValInstalac',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'tpequ'],
								dependencyEvents: ['fieldChange:tpequ.codtpequ'],
								dependencyField: 'TPEQU.CODTPEQU',
								fnValueSelector: (model) => model.ValCodtpequ.value
							},
						],
					}, this),
					TPEQU___PSEUDINSTALA1: new fieldControlClass.TableListControl({
						id: 'TPEQU___PSEUDINSTALA1',
						name: 'INSTALA1',
						size: '',
						label: computed(() => this.Resources.MAP_WITH_FACILITIES_33619),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-TPEQU___PSEUDNOVOGR06',
						container: 'TPEQU___PSEUDNOVOGR06',
						controller: 'TPEQU',
						action: 'Tpequ_ValInstala1',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValDesignat',
								area: 'INSTA',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.SCHEDULING24801),
								dataLength: 85,
								scrollData: 30,
							}),
							new listColumnTypes.DateColumn({
								order: 2,
								name: 'ValDtiniage',
								area: 'INSTA',
								field: 'DTINIAGE',
								label: computed(() => this.Resources.BEGINNING18124),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.DateColumn({
								order: 3,
								name: 'ValDtfimage',
								area: 'INSTA',
								field: 'DTFIMAGE',
								label: computed(() => this.Resources.END47577),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValDescript',
								area: 'INSTA',
								field: 'DESCRIPT',
								label: computed(() => this.Resources.DESCRIPTION07383),
								scrollData: 30,
							}),
							new listColumnTypes.BooleanColumn({
								order: 5,
								name: 'ValAllday',
								area: 'INSTA',
								field: 'ALLDAY',
								label: computed(() => this.Resources.ALL_DAY18496),
								scrollData: 1,
							}),
							new listColumnTypes.DateColumn({
								order: 6,
								name: 'ValSince',
								area: 'INSTA',
								field: 'SINCE',
								label: computed(() => this.Resources.SINCE47259),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.DateColumn({
								order: 7,
								name: 'ValUntil',
								area: 'INSTA',
								field: 'UNTIL',
								label: computed(() => this.Resources.UNTIL39173),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}),
							new listColumnTypes.NumericColumn({
								order: 8,
								name: 'ValHours',
								area: 'INSTA',
								field: 'HOURS',
								label: computed(() => this.Resources.QTD_HOURS28684),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 2,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 9,
								name: 'ValPrecohor',
								area: 'INSTA',
								field: 'PRECOHOR',
								label: computed(() => this.Resources.HOURLY_PRICE48005),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 0,
							}),
							new listColumnTypes.CurrencyColumn({
								order: 10,
								name: 'ValValue',
								area: 'INSTA',
								field: 'VALUE',
								label: computed(() => this.Resources.VALUE10285),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 0,
							}),
							new listColumnTypes.GeographicColumn({
								order: 11,
								name: 'ValCoordgeo',
								area: 'INSTA',
								field: 'COORDGEO',
								label: computed(() => this.Resources.GEOGRAPHIC_COORDINAT21394),
								dataLength: 50,
								scrollData: 30,
								sortable: false,
								searchable: false,
							}),
						],
						config: {
							name: 'ValInstala1',
							serverMode: true,
							pkColumn: 'ValCodinsta',
							tableAlias: 'INSTA',
							tableNamePlural: computed(() => this.Resources.FACILITIES08876),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.MAP_WITH_FACILITIES_33619),
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
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
							],
							rowClickAction: {
							},
							formsDefinition: {
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						changeEvents: ['changed-INSTA', 'changed-EQUIP', 'changed-TPEQU'],
						uuid: 'Tpequ_ValInstala1',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'tpequ'],
								dependencyEvents: ['fieldChange:tpequ.codtpequ'],
								dependencyField: 'TPEQU.CODTPEQU',
								fnValueSelector: (model) => model.ValCodtpequ.value
							},
						],
					}, this),
					TPEQU___TPEQUQTDEQUIP: new fieldControlClass.NumberControl({
						modelField: 'ValQtdequip',
						valueChangeEvent: 'fieldChange:tpequ.qtdequip',
						id: 'TPEQU___TPEQUQTDEQUIP',
						name: 'QTDEQUIP',
						size: 'medium',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources.____615950),
							},
						},
						label: computed(() => this.Resources.QUANTITY_OF_EQUIPMEN09806),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'TPEQU___PSEUDNOVOGR01',
						isFormulaBlocked: true,
						maxIntegers: 6,
						maxDecimals: 0,
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
					'TPEQU___PSEUDNOVOGR01',
					'TPEQU___PSEUDNOVOGR05',
					'TPEQU___PSEUDNOVOGR04',
					'TPEQU___PSEUDNOVOGR03',
					'TPEQU___PSEUDNOVOGR02',
					'TPEQU___PSEUDNOVOGR06',
				]),

				tableFields: readonly([
					'TPEQU___PSEUDCOMPONEN',
					'TPEQU___PSEUDEVOLUCAO',
					'TPEQU___PSEUDINSTALAC',
					'TPEQU___PSEUDINSTALA1',
				]),

				timelineFields: readonly([
				]),

				triggers: readonly([
					{
						id: 'FILLTYPEEQUIP',
						event: 'PG',
						condition: () => {
							// Formula: isEmptyC([TPEQU->TIPOEQUI])
							return (this.model.ValTipoequi.value === '')
						},
						execute: () => {
							vm.TPEQU_FormTriggers_FILLTYPEEQUIP_1(vm.primaryKeyValue)
						}
					},
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Famil: {
						get ValFamily() { return vm.model.TableFamilFamily.value },
						set ValFamily(value) { vm.model.TableFamilFamily.updateValue(value) },
					},
					Tpequ: {
						get ValBackcolo() { return vm.model.ValBackcolo.value },
						set ValBackcolo(value) { vm.model.ValBackcolo.updateValue(value) },
						get ValCodfamil() { return vm.model.ValCodfamil.value },
						set ValCodfamil(value) { vm.model.ValCodfamil.updateValue(value) },
						get ValCorletra() { return vm.model.ValCorletra.value },
						set ValCorletra(value) { vm.model.ValCorletra.updateValue(value) },
						get ValKit() { return vm.model.ValKit.value },
						set ValKit(value) { vm.model.ValKit.updateValue(value) },
						get ValNivel() { return vm.model.ValNivel.value },
						set ValNivel(value) { vm.model.ValNivel.updateValue(value) },
						get ValPrecomax() { return vm.model.ValPrecomax.value },
						set ValPrecomax(value) { vm.model.ValPrecomax.updateValue(value) },
						get ValPrecoult() { return vm.model.ValPrecoult.value },
						set ValPrecoult(value) { vm.model.ValPrecoult.updateValue(value) },
						get ValQtdequip() { return vm.model.ValQtdequip.value },
						set ValQtdequip(value) { vm.model.ValQtdequip.updateValue(value) },
						get ValSince() { return vm.model.ValSince.value },
						set ValSince(value) { vm.model.ValSince.updateValue(value) },
						get ValTipoequi() { return vm.model.ValTipoequi.value },
						set ValTipoequi(value) { vm.model.ValTipoequi.updateValue(value) },
						get ValTpequcod() { return vm.model.ValTpequcod.value },
						set ValTpequcod(value) { vm.model.ValTpequcod.updateValue(value) },
						get ValTpequpai() { return vm.model.ValTpequpai.value },
						set ValTpequpai(value) { vm.model.ValTpequpai.updateValue(value) },
					},
					keys: {
						/** The primary key of the TPEQU table */
						get tpequ() { return vm.model.ValCodtpequ },
						/** The foreign key to the FAMIL table */
						get famil() { return vm.model.ValCodfamil },
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
// USE /[MANUAL GQT FORM_CODEJS TPEQU]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS TPEQU]/
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
// USE /[MANUAL GQT FORM_LOADED_JS TPEQU]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS TPEQU]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS TPEQU]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS TPEQU]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS TPEQU]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS TPEQU]/
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
// USE /[MANUAL GQT AFTER_DEL_JS TPEQU]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS TPEQU]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS TPEQU]/
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
// USE /[MANUAL GQT DLGUPDT TPEQU]/
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
// USE /[MANUAL GQT CTRLBLR TPEQU]/
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
// USE /[MANUAL GQT CTRLUPD TPEQU]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},

			/**
			 * Client-side component of action #1 (FLDUPDT) of trigger FILLTYPEEQUIP.
			 * @param {string} id The primary key of the record
			 */
			// eslint-disable-next-line
			async TPEQU_FormTriggers_FILLTYPEEQUIP_1(id)
			{
				// eslint-disable-next-line
				const vm = this

				const actionFormula = () => {
					// Formula: "*undefined*"
					return "*undefined*"
				}

				// Compute the value using the data available on the client-side.
				const value = await actionFormula()

				// Update the value on the client-side.
				if (typeof value !== 'undefined')
					this.model.ValTipoequi.updateValue(value)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS TPEQU]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
			// Watchers for changes in the state of tabs and collapsible groups.
			'controls.TPEQU___PSEUDNOVOGR04.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'TPEQU___PSEUDNOVOGR04',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
			'controls.TPEQU___PSEUDNOVOGR03.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'TPEQU___PSEUDNOVOGR03',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
			'controls.TPEQU___PSEUDNOVOGR02.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'TPEQU___PSEUDNOVOGR02',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
			'controls.TPEQU___PSEUDNOVOGR06.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'TPEQU___PSEUDNOVOGR06',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
		}
	}
</script>
