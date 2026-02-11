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
									<template v-if="btn.icon">
										<q-badge-indicator
											v-if="btn.badge && btn.badge.isVisible"
											:color="btn.badge.color">
											<q-icon v-bind="btn.icon" />
										</q-badge-indicator>
										<q-icon
											v-else
											v-bind="btn.icon" />
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
			data-key="ASSET"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.ASSET___PSEUDNOVOGR01.isVisible">
					<q-col
						v-if="controls.ASSET___PSEUDNOVOGR01.isVisible"
						cols="auto">
						<q-group-box-container
							v-if="controls.ASSET___PSEUDNOVOGR01.isVisible"
							id="ASSET___PSEUDNOVOGR01"
							v-bind="controls.ASSET___PSEUDNOVOGR01"
							:is-visible="controls.ASSET___PSEUDNOVOGR01.isVisible">
							<!-- Start ASSET___PSEUDNOVOGR01 -->
							<q-row v-if="controls.ASSET___ASSETNAME____.isVisible">
								<q-col
									v-if="controls.ASSET___ASSETNAME____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.ASSET___ASSETNAME____.isVisible"
										class="i-text"
										v-bind="controls.ASSET___ASSETNAME____"
										v-on="controls.ASSET___ASSETNAME____.handlers"
										:loading="controls.ASSET___ASSETNAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.ASSET___ASSETNAME____.props"
											@blur="onBlur(controls.ASSET___ASSETNAME____, model.ValName.value)"
											@change="model.ValName.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.ASSET___ASSETASSETTYP.isVisible || controls.ASSET___ASSETASSETNUM.isVisible">
								<q-col
									v-if="controls.ASSET___ASSETASSETTYP.isVisible || controls.ASSET___ASSETASSETNUM.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.ASSET___ASSETASSETTYP.isVisible"
										class="i-text"
										v-bind="controls.ASSET___ASSETASSETTYP"
										v-on="controls.ASSET___ASSETASSETTYP.handlers"
										:loading="controls.ASSET___ASSETASSETTYP.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.ASSET___ASSETASSETTYP.isVisible"
											v-bind="controls.ASSET___ASSETASSETTYP.props"
											@update:model-value="model.ValAssettyp.fnUpdateValue" />
									</base-input-structure>
									<base-input-structure
										v-if="controls.ASSET___ASSETASSETNUM.isVisible"
										class="i-text"
										v-bind="controls.ASSET___ASSETASSETNUM"
										v-on="controls.ASSET___ASSETASSETNUM.handlers"
										:loading="controls.ASSET___ASSETASSETNUM.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.ASSET___ASSETASSETNUM.isVisible"
											v-bind="controls.ASSET___ASSETASSETNUM.props"
											@update:model-value="model.ValAssetnum.fnUpdateValue" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.ASSET___ASSETIDENTTYP.isVisible || controls.ASSET___ASSETGRAI____.isVisible || controls.ASSET___ASSETGIAI____.isVisible">
								<q-col
									v-if="controls.ASSET___ASSETIDENTTYP.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.ASSET___ASSETIDENTTYP.isVisible"
										class="i-text"
										v-bind="controls.ASSET___ASSETIDENTTYP"
										v-on="controls.ASSET___ASSETIDENTTYP.handlers"
										:loading="controls.ASSET___ASSETIDENTTYP.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.ASSET___ASSETIDENTTYP.isVisible"
											v-bind="controls.ASSET___ASSETIDENTTYP.props"
											@update:model-value="model.ValIdenttyp.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.ASSET___ASSETGRAI____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.ASSET___ASSETGRAI____.isVisible"
										class="i-text"
										v-bind="controls.ASSET___ASSETGRAI____"
										v-on="controls.ASSET___ASSETGRAI____.handlers"
										:loading="controls.ASSET___ASSETGRAI____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.ASSET___ASSETGRAI____.props"
											@blur="onBlur(controls.ASSET___ASSETGRAI____, model.ValGrai.value)"
											@change="model.ValGrai.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.ASSET___ASSETGIAI____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.ASSET___ASSETGIAI____.isVisible"
										class="i-text"
										v-bind="controls.ASSET___ASSETGIAI____"
										v-on="controls.ASSET___ASSETGIAI____.handlers"
										:loading="controls.ASSET___ASSETGIAI____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.ASSET___ASSETGIAI____.props"
											@blur="onBlur(controls.ASSET___ASSETGIAI____, model.ValGiai.value)"
											@change="model.ValGiai.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.ASSET___MANUFNAME____.isVisible">
								<q-col
									v-if="controls.ASSET___MANUFNAME____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.ASSET___MANUFNAME____.isVisible"
										class="i-text"
										v-bind="controls.ASSET___MANUFNAME____"
										v-on="controls.ASSET___MANUFNAME____.handlers"
										:loading="controls.ASSET___MANUFNAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.ASSET___MANUFNAME____.isVisible"
											v-bind="controls.ASSET___MANUFNAME____.props"
											v-on="controls.ASSET___MANUFNAME____.handlers" />
										<q-see-more-asset-manufname
											v-if="controls.ASSET___MANUFNAME____.seeMoreIsVisible"
											v-bind="controls.ASSET___MANUFNAME____.seeMoreParams"
											v-on="controls.ASSET___MANUFNAME____.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.ASSET___KINDEDESIGNAT.isVisible">
								<q-col
									v-if="controls.ASSET___KINDEDESIGNAT.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.ASSET___KINDEDESIGNAT.isVisible"
										class="i-text"
										v-bind="controls.ASSET___KINDEDESIGNAT"
										v-on="controls.ASSET___KINDEDESIGNAT.handlers"
										:loading="controls.ASSET___KINDEDESIGNAT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.ASSET___KINDEDESIGNAT.isVisible"
											v-bind="controls.ASSET___KINDEDESIGNAT.props"
											v-on="controls.ASSET___KINDEDESIGNAT.handlers" />
										<q-see-more-asset-kindedesignat
											v-if="controls.ASSET___KINDEDESIGNAT.seeMoreIsVisible"
											v-bind="controls.ASSET___KINDEDESIGNAT.seeMoreParams"
											v-on="controls.ASSET___KINDEDESIGNAT.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End ASSET___PSEUDNOVOGR01 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.ASSET___PSEUDASSET01_.isVisible || controls.ASSET___PSEUDASSET02_.isVisible || controls.ASSET___PSEUDASSET03_.isVisible || controls.ASSET___PSEUDASSET04_.isVisible">
					<q-col
						v-if="controls.ASSET___PSEUDASSET01_.isVisible || controls.ASSET___PSEUDASSET02_.isVisible || controls.ASSET___PSEUDASSET03_.isVisible || controls.ASSET___PSEUDASSET04_.isVisible"
						cols="auto">
						<q-tab-container
							v-if="controls.formTabs.isVisible"
							id="q-tabs-ASSET"
							v-bind="controls.formTabs.props"
							@tab-changed="controls.formTabs.selectTab($event)">
							<template #tab-panel>
								<section
									v-if="controls.ASSET___PSEUDASSET01_.isVisible"
									v-show="controls.formTabs.selectedTab === 'ASSET___PSEUDASSET01_'">
									<div
										id="ASSET___PSEUDASSET01_"
										role="tabpanel"
										aria-labelledby="tab-container-ASSET___PSEUDASSET01_">
										<q-row v-if="controls.ASSET01_ASSETPHOTO___.isVisible">
											<q-col
												v-if="controls.ASSET01_ASSETPHOTO___.isVisible"
												cols="auto">
												<base-input-structure
													v-if="controls.ASSET01_ASSETPHOTO___.isVisible"
													class="q-image"
													v-bind="controls.ASSET01_ASSETPHOTO___"
													v-on="controls.ASSET01_ASSETPHOTO___.handlers"
													:loading="controls.ASSET01_ASSETPHOTO___.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-image
														v-if="controls.ASSET01_ASSETPHOTO___.isVisible"
														v-bind="controls.ASSET01_ASSETPHOTO___.props"
														v-on="controls.ASSET01_ASSETPHOTO___.handlers" />
												</base-input-structure>
											</q-col>
										</q-row>
									</div>
								</section>
								<section
									v-if="controls.ASSET___PSEUDASSET02_.isVisible"
									v-show="controls.formTabs.selectedTab === 'ASSET___PSEUDASSET02_'">
									<div
										id="ASSET___PSEUDASSET02_"
										role="tabpanel"
										aria-labelledby="tab-container-ASSET___PSEUDASSET02_">
										<q-row v-if="controls.ASSET02_PSEUDATTACHME.isVisible">
											<q-col
												v-if="controls.ASSET02_PSEUDATTACHME.isVisible"
												cols="auto">
												<q-table
													v-if="controls.ASSET02_PSEUDATTACHME.isVisible"
													v-bind="controls.ASSET02_PSEUDATTACHME"
													v-on="controls.ASSET02_PSEUDATTACHME.handlers">
													<!-- USE /[MANUAL GQT CUSTOM_TABLE ASSET02_PSEUDATTACHME]/ -->
												</q-table>
												<q-table-extra-extension
													v-if="controls.ASSET02_PSEUDATTACHME.isVisible"
													:list-ctrl="controls.ASSET02_PSEUDATTACHME"
													:filter-operators="controls.ASSET02_PSEUDATTACHME.filterOperators"
													v-on="controls.ASSET02_PSEUDATTACHME.handlers" />
											</q-col>
										</q-row>
									</div>
								</section>
								<section
									v-if="controls.ASSET___PSEUDASSET03_.isVisible"
									v-show="controls.formTabs.selectedTab === 'ASSET___PSEUDASSET03_'">
									<div
										id="ASSET___PSEUDASSET03_"
										role="tabpanel"
										aria-labelledby="tab-container-ASSET___PSEUDASSET03_">
										<q-row v-if="controls.ASSET03_PSEUDDOCUMENT.isVisible">
											<q-col
												v-if="controls.ASSET03_PSEUDDOCUMENT.isVisible"
												cols="auto">
												<q-table
													v-if="controls.ASSET03_PSEUDDOCUMENT.isVisible"
													v-bind="controls.ASSET03_PSEUDDOCUMENT"
													v-on="controls.ASSET03_PSEUDDOCUMENT.handlers">
													<!-- USE /[MANUAL GQT CUSTOM_TABLE ASSET03_PSEUDDOCUMENT]/ -->
												</q-table>
												<q-table-extra-extension
													v-if="controls.ASSET03_PSEUDDOCUMENT.isVisible"
													:list-ctrl="controls.ASSET03_PSEUDDOCUMENT"
													:filter-operators="controls.ASSET03_PSEUDDOCUMENT.filterOperators"
													v-on="controls.ASSET03_PSEUDDOCUMENT.handlers" />
											</q-col>
										</q-row>
									</div>
								</section>
								<section
									v-if="controls.ASSET___PSEUDASSET04_.isVisible"
									v-show="controls.formTabs.selectedTab === 'ASSET___PSEUDASSET04_'">
									<div
										id="ASSET___PSEUDASSET04_"
										role="tabpanel"
										aria-labelledby="tab-container-ASSET___PSEUDASSET04_">
										<q-row v-if="controls.ASSET04_PSEUDNOVOGR01.isVisible">
											<q-col
												v-if="controls.ASSET04_PSEUDNOVOGR01.isVisible"
												cols="auto">
												<q-group-box-container
													v-if="controls.ASSET04_PSEUDNOVOGR01.isVisible"
													id="ASSET04_PSEUDNOVOGR01"
													v-bind="controls.ASSET04_PSEUDNOVOGR01"
													:is-visible="controls.ASSET04_PSEUDNOVOGR01.isVisible">
													<!-- Start ASSET04_PSEUDNOVOGR01 -->
													<q-row v-if="controls.ASSET04_PSEUDPARAMLOA.isVisible || controls.ASSET04_PSEUDMANUALS_.isVisible || controls.ASSET04_PSEUDPARAMETE.isVisible">
														<q-col
															v-if="controls.ASSET04_PSEUDPARAMLOA.isVisible"
															cols="auto">
															<base-input-structure
																v-if="controls.ASSET04_PSEUDPARAMLOA.isVisible"
																class="i-button"
																v-bind="controls.ASSET04_PSEUDPARAMLOA"
																v-on="controls.ASSET04_PSEUDPARAMLOA.handlers"
																:loading="controls.ASSET04_PSEUDPARAMLOA.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-button
																	v-if="controls.ASSET04_PSEUDPARAMLOA.isVisible"
																	v-bind="controls.ASSET04_PSEUDPARAMLOA.props"
																	@click="controls.ASSET04_PSEUDPARAMLOA.action($event)">
																</q-button>
															</base-input-structure>
														</q-col>
														<q-col
															v-if="controls.ASSET04_PSEUDMANUALS_.isVisible"
															cols="auto">
															<base-input-structure
																v-if="controls.ASSET04_PSEUDMANUALS_.isVisible"
																class="i-button"
																v-bind="controls.ASSET04_PSEUDMANUALS_"
																v-on="controls.ASSET04_PSEUDMANUALS_.handlers"
																:loading="controls.ASSET04_PSEUDMANUALS_.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-button
																	v-if="controls.ASSET04_PSEUDMANUALS_.isVisible"
																	v-bind="controls.ASSET04_PSEUDMANUALS_.props"
																	@click="controls.ASSET04_PSEUDMANUALS_.action($event)">
																</q-button>
															</base-input-structure>
														</q-col>
														<q-col
															v-if="controls.ASSET04_PSEUDPARAMETE.isVisible"
															cols="auto">
															<q-table
																v-if="controls.ASSET04_PSEUDPARAMETE.isVisible"
																v-bind="controls.ASSET04_PSEUDPARAMETE"
																v-on="controls.ASSET04_PSEUDPARAMETE.handlers">
																<!-- USE /[MANUAL GQT CUSTOM_TABLE ASSET04_PSEUDPARAMETE]/ -->
															</q-table>
															<q-table-extra-extension
																v-if="controls.ASSET04_PSEUDPARAMETE.isVisible"
																:list-ctrl="controls.ASSET04_PSEUDPARAMETE"
																:filter-operators="controls.ASSET04_PSEUDPARAMETE.filterOperators"
																v-on="controls.ASSET04_PSEUDPARAMETE.handlers" />
														</q-col>
													</q-row>
													<!-- End ASSET04_PSEUDNOVOGR01 -->
												</q-group-box-container>
											</q-col>
										</q-row>
									</div>
								</section>
							</template>
						</q-tab-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.ASSET___ASSETDESCRIPT.isVisible">
					<q-col v-if="controls.ASSET___ASSETDESCRIPT.isVisible">
						<base-input-structure
							v-if="controls.ASSET___ASSETDESCRIPT.isVisible"
							class="i-textarea"
							v-bind="controls.ASSET___ASSETDESCRIPT"
							v-on="controls.ASSET___ASSETDESCRIPT.handlers"
							:loading="controls.ASSET___ASSETDESCRIPT.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-area
								v-if="controls.ASSET___ASSETDESCRIPT.isVisible"
								v-bind="controls.ASSET___ASSETDESCRIPT.props"
								v-on="controls.ASSET___ASSETDESCRIPT.handlers" />
							<template #alternative-view>
								<q-markdown-viewer
									id="ASSET___ASSETDESCRIPT"
									:model-value="model.ValDescription.value"
									:options="controls.ASSET___ASSETDESCRIPT.markdownOptions" />
							</template>
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.ASSET___ASSETLONGDESC.isVisible">
					<q-col v-if="controls.ASSET___ASSETLONGDESC.isVisible">
						<base-input-structure
							v-if="controls.ASSET___ASSETLONGDESC.isVisible"
							class="i-text"
							v-bind="controls.ASSET___ASSETLONGDESC"
							v-on="controls.ASSET___ASSETLONGDESC.handlers"
							:loading="controls.ASSET___ASSETLONGDESC.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-markdown-editor
								v-if="controls.ASSET___ASSETLONGDESC.isVisible"
								v-bind="controls.ASSET___ASSETLONGDESC.props"
								:model-value="model.ValLongdesc.value"
								@update:model-value="model.ValLongdesc.fnUpdateValue" />
							<template #alternative-view>
								<q-markdown-viewer
									id="ASSET___ASSETLONGDESC"
									:model-value="model.ValLongdesc.value"
									:options="controls.ASSET___ASSETLONGDESC.markdownOptions" />
							</template>
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.ASSET___ASSETCATEGORY.isVisible || controls.ASSET___ASSETBG_COLOR.isVisible">
					<q-col
						v-if="controls.ASSET___ASSETCATEGORY.isVisible || controls.ASSET___ASSETBG_COLOR.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.ASSET___ASSETCATEGORY.isVisible"
							class="i-text"
							v-bind="controls.ASSET___ASSETCATEGORY"
							v-on="controls.ASSET___ASSETCATEGORY.handlers"
							:loading="controls.ASSET___ASSETCATEGORY.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-select
								v-if="controls.ASSET___ASSETCATEGORY.isVisible"
								v-bind="controls.ASSET___ASSETCATEGORY.props"
								@update:model-value="model.ValCategory.fnUpdateValue" />
						</base-input-structure>
						<base-input-structure
							v-if="controls.ASSET___ASSETBG_COLOR.isVisible"
							class="i-text"
							v-bind="controls.ASSET___ASSETBG_COLOR"
							v-on="controls.ASSET___ASSETBG_COLOR.handlers"
							:loading="controls.ASSET___ASSETBG_COLOR.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-text-field
								v-bind="controls.ASSET___ASSETBG_COLOR.props"
								@blur="onBlur(controls.ASSET___ASSETBG_COLOR, model.ValBg_color.value)"
								@change="model.ValBg_color.fnUpdateValueOnChange" />
						</base-input-structure>
					</q-col>
				</q-row>
			</template>
		</q-container>
	</teleport>

	<hr v-if="!isPopup && showFormFooter" />

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

	import FormViewModel from './QFormAssetViewModel.js'

	const requiredTextResources = ['QFormAsset', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS ASSET]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormAsset',

		components: {
			QSeeMoreAssetManufname: defineAsyncComponent(() => import('@/views/forms/FormAsset/dbedits/AssetManufnameSeeMore.vue')),
			QSeeMoreAssetKindedesignat: defineAsyncComponent(() => import('@/views/forms/FormAsset/dbedits/AssetKindedesignatSeeMore.vue')),
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
					name: 'ASSET',
					location: 'form-ASSET',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormAsset', false),

				interfaceMetadata: {
					id: 'QFormAsset', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'ASSET',
					route: 'form-ASSET',
					area: 'ASSET',
					primaryKey: 'ValCodasset',
					designation: computed(() => this.Resources.ASSET37028),
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
					ASSET___PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'ASSET___PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'xxlarge',
						label: computed(() => this.Resources.ASSET_IDENTIFICATION53152),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['ASSET___ASSETNAME____', 'ASSET___ASSETASSETTYP', 'ASSET___ASSETASSETNUM', 'ASSET___ASSETIDENTTYP', 'ASSET___ASSETGRAI____', 'ASSET___ASSETGIAI____', 'ASSET___MANUFNAME____', 'ASSET___KINDEDESIGNAT'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					ASSET___ASSETNAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:asset.name',
						id: 'ASSET___ASSETNAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.IDENTIFICATION_NAME16317),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ASSET___PSEUDNOVOGR01',
						maxLength: 85,
						controlLimits: [
						],
					}, this),
					ASSET___ASSETASSETTYP: new fieldControlClass.ArrayStringControl({
						modelField: 'ValAssettyp',
						valueChangeEvent: 'fieldChange:asset.assettyp',
						id: 'ASSET___ASSETASSETTYP',
						name: 'ASSETTYP',
						size: 'medium',
						label: computed(() => this.Resources.ASSET_TYPE02033),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ASSET___PSEUDNOVOGR01',
						maxLength: 1,
						mustBeFilled: true,
						arrayName: 'AssetTyp',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					ASSET___ASSETASSETNUM: new fieldControlClass.NumberControl({
						modelField: 'ValAssetnum',
						valueChangeEvent: 'fieldChange:asset.assetnum',
						id: 'ASSET___ASSETASSETNUM',
						name: 'ASSETNUM',
						size: 'small',
						label: computed(() => this.Resources.ASSET_NUMBER52372),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ASSET___PSEUDNOVOGR01',
						maxIntegers: 10,
						maxDecimals: 0,
						isSequencial: true,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					ASSET___ASSETIDENTTYP: new fieldControlClass.ArrayStringControl({
						modelField: 'ValIdenttyp',
						valueChangeEvent: 'fieldChange:asset.identtyp',
						id: 'ASSET___ASSETIDENTTYP',
						name: 'IDENTTYP',
						size: 'small',
						label: computed(() => this.Resources.IDENTIFIER_TYPE60623),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ASSET___PSEUDNOVOGR01',
						maxLength: 1,
						arrayName: 'IdentTyp',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					ASSET___ASSETGRAI____: new fieldControlClass.StringControl({
						modelField: 'ValGrai',
						valueChangeEvent: 'fieldChange:asset.grai',
						id: 'ASSET___ASSETGRAI____',
						name: 'GRAI',
						size: 'xlarge',
						label: computed(() => this.Resources.GRAI___GLOBAL_RETURN06821),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ASSET___PSEUDNOVOGR01',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					ASSET___ASSETGIAI____: new fieldControlClass.StringControl({
						modelField: 'ValGiai',
						valueChangeEvent: 'fieldChange:asset.giai',
						id: 'ASSET___ASSETGIAI____',
						name: 'GIAI',
						size: 'xlarge',
						label: computed(() => this.Resources.GIAI___GLOBAL_INDIVI63214),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ASSET___PSEUDNOVOGR01',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					ASSET___MANUFNAME____: new fieldControlClass.LookupControl({
						modelField: 'TableManufName',
						valueChangeEvent: 'fieldChange:manuf.name',
						id: 'ASSET___MANUFNAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.LEGAL_NAME42902),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ASSET___PSEUDNOVOGR01',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodmanuf',
							dependencyEvent: 'fieldChange:asset.codmanuf'
						},
						dependentFields: () => ({
							set 'manuf.codentit'(value) { vm.model.ValCodmanuf.updateValue(value) },
							set 'manuf.name'(value) { vm.model.TableManufName.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					ASSET___KINDEDESIGNAT: new fieldControlClass.LookupControl({
						modelField: 'TableKindeDesignat',
						valueChangeEvent: 'fieldChange:kinde.designat',
						id: 'ASSET___KINDEDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.KIND_OF_EQUIPMENT22928),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ASSET___PSEUDNOVOGR01',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodkinde',
							dependencyEvent: 'fieldChange:asset.codkinde'
						},
						dependentFields: () => ({
							set 'kinde.codkinde'(value) { vm.model.ValCodkinde.updateValue(value) },
							set 'kinde.designat'(value) { vm.model.TableKindeDesignat.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					ASSET___PSEUDASSET01_: new fieldControlClass.TabControl({
						id: 'ASSET___PSEUDASSET01_',
						name: 'ASSET01',
						size: 'xxlarge',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['ASSET01_ASSETPHOTO___'],
						controlLimits: [
						],
					}, this),
					ASSET___PSEUDASSET02_: new fieldControlClass.TabControl({
						id: 'ASSET___PSEUDASSET02_',
						name: 'ASSET02',
						size: 'xxlarge',
						label: computed(() => this.Resources.ATTACHMENTS19612),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['ASSET02_PSEUDATTACHME'],
						controlLimits: [
						],
					}, this),
					ASSET___PSEUDASSET03_: new fieldControlClass.TabControl({
						id: 'ASSET___PSEUDASSET03_',
						name: 'ASSET03',
						size: 'xxlarge',
						label: computed(() => this.Resources.DOCUMENTS14470),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['ASSET03_PSEUDDOCUMENT'],
						controlLimits: [
						],
					}, this),
					ASSET___PSEUDASSET04_: new fieldControlClass.TabControl({
						id: 'ASSET___PSEUDASSET04_',
						name: 'ASSET04',
						size: 'xxlarge',
						label: computed(() => this.Resources.PARAMETERS28294),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['ASSET04_PSEUDNOVOGR01'],
						controlLimits: [
						],
					}, this),
					ASSET___ASSETDESCRIPT: new fieldControlClass.MultilineStringControl({
						modelField: 'ValDescription',
						valueChangeEvent: 'fieldChange:asset.description',
						id: 'ASSET___ASSETDESCRIPT',
						name: 'DESCRIPT',
						size: 'block',
						label: computed(() => this.Resources.DESCRIPTION07383),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						rows: 5,
						cols: 30,
						showAlternativeView: computed(() => !this.isEditable),
						markdownOptions: {
							allowAttributes: false,
							allowImage: true,
							enableTypographer: true,
						},
						controlLimits: [
						],
					}, this),
					ASSET___ASSETLONGDESC: new fieldControlClass.MarkdownEditorControl({
						modelField: 'ValLongdesc',
						valueChangeEvent: 'fieldChange:asset.longdesc',
						id: 'ASSET___ASSETLONGDESC',
						name: 'LONGDESC',
						size: 'block',
						label: computed(() => this.Resources.DETAILED_DESCRIPTION36560),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						showAlternativeView: computed(() => !this.isEditable),
						markdownOptions: {
							allowAttributes: true,
							allowImage: true,
							enableTypographer: true,
						},
						controlLimits: [
						],
					}, this),
					ASSET___ASSETCATEGORY: new fieldControlClass.ArrayStringControl({
						modelField: 'ValCategory',
						valueChangeEvent: 'fieldChange:asset.category',
						id: 'ASSET___ASSETCATEGORY',
						name: 'CATEGORY',
						size: 'small',
						label: computed(() => this.Resources.CATEGORY18978),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 5,
						arrayName: 'assetCategory',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					ASSET___ASSETBG_COLOR: new fieldControlClass.StringControl({
						modelField: 'ValBg_color',
						valueChangeEvent: 'fieldChange:asset.bg_color',
						id: 'ASSET___ASSETBG_COLOR',
						name: 'BG_COLOR',
						size: 'xlarge',
						label: computed(() => this.Resources.BACKGROUND_COLOR_FOR59228),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					ASSET01_ASSETPHOTO___: new fieldControlClass.ImageControl({
						modelField: 'ValPhoto',
						valueChangeEvent: 'fieldChange:asset.photo',
						id: 'ASSET01_ASSETPHOTO___',
						name: 'PHOTO',
						size: 'xxlarge',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'ASSET___PSEUDASSET01_',
						height: 300,
						width: 400,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO51874)),
						controlLimits: [
						],
					}, this),
					ASSET02_PSEUDATTACHME: new fieldControlClass.TableListControl({
						id: 'ASSET02_PSEUDATTACHME',
						name: 'ATTACHME',
						size: '',
						label: computed(() => this.Resources.ATTACHMENTS19612),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'ASSET___PSEUDASSET02_',
						controller: 'ASSET',
						action: 'Asset02_ValAttachme',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValAttached',
								area: 'ATTAC',
								field: 'ATTACHED',
								label: computed(() => this.Resources.ATTACHED26247),
								scrollData: 16,
								dateTimeType: 'dateTime',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValNote',
								area: 'ATTAC',
								field: 'NOTE',
								label: computed(() => this.Resources.NOTE54557),
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DocumentColumn({
								order: 3,
								name: 'ValDocument',
								area: 'ATTAC',
								field: 'DOCUMENT',
								label: computed(() => this.Resources.DOCUMENT00695),
								dataLength: 85,
								scrollData: 30,
								sortable: false,
								export: 1,
								viewType: qEnums.documentViewTypeMode.print,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValAttachme',
							serverMode: true,
							pkColumn: 'ValCodattac',
							tableAlias: 'ATTAC',
							tableNamePlural: computed(() => this.Resources.ATTACHMENTS19612),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.ATTACHMENTS19612),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: false
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
										action: vm.openFormAction,
										type: 'form',
										formName: 'ATTAC',
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
										formName: 'ATTAC',
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
										formName: 'ATTAC',
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
										formName: 'ATTAC',
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
										action: vm.openFormAction,
										type: 'form',
										formName: 'ATTAC',
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
								id: 'RCA__ATTAC',
								name: '_ATTAC',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'ATTAC',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'ATTAC': {
									fnKeySelector: (row) => row.Fields.ValCodattac,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValAttached',
							defaultSearchColumnNameOriginal: 'ValAttached',
							defaultColumnSorting: {
								columnName: 'ValAttached',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-ATTAC', 'changed-ASSET'],
						uuid: 'Asset02_ValAttachme',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'asset'],
								dependencyEvents: ['fieldChange:asset.codasset'],
								dependencyField: 'ASSET.CODASSET',
								fnValueSelector: (model) => model.ValCodasset.value
							},
						],
					}, this),
					ASSET03_PSEUDDOCUMENT: new fieldControlClass.TableListControl({
						id: 'ASSET03_PSEUDDOCUMENT',
						name: 'DOCUMENT',
						size: '',
						label: computed(() => this.Resources.DOCUMENTS14470),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'ASSET___PSEUDASSET03_',
						controller: 'ASSET',
						action: 'Asset03_ValDocument',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValName',
								area: 'ASSMA',
								field: 'NAME',
								label: computed(() => this.Resources.MANUAL_NAME60077),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DocumentColumn({
								order: 2,
								name: 'ValDigdocum',
								area: 'ASSMA',
								field: 'DIGDOCUM',
								label: computed(() => this.Resources.DIGITAL_DOCUMENT59580),
								dataLength: 50,
								scrollData: 30,
								sortable: false,
								export: 1,
								viewType: qEnums.documentViewTypeMode.print,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValNotes',
								area: 'ASSMA',
								field: 'NOTES',
								label: computed(() => this.Resources.NOTES05274),
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValDocument',
							serverMode: true,
							pkColumn: 'ValCodassma',
							tableAlias: 'ASSMA',
							tableNamePlural: computed(() => this.Resources.ASSET_MANUALS04899),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.DOCUMENTS14470),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: false
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
										action: vm.openFormAction,
										type: 'form',
										formName: 'ASSMA',
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
										formName: 'ASSMA',
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
										formName: 'ASSMA',
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
										formName: 'ASSMA',
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
										action: vm.openFormAction,
										type: 'form',
										formName: 'ASSMA',
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
								id: 'RCA__ASSMA',
								name: '_ASSMA',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'ASSMA',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'ASSMA': {
									fnKeySelector: (row) => row.Fields.ValCodassma,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValName',
							defaultSearchColumnNameOriginal: 'ValName',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-ASSMA', 'changed-ASSET'],
						uuid: 'Asset03_ValDocument',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'asset'],
								dependencyEvents: ['fieldChange:asset.codasset'],
								dependencyField: 'ASSET.CODASSET',
								fnValueSelector: (model) => model.ValCodasset.value
							},
						],
					}, this),
					ASSET04_PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'ASSET04_PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'xxlarge',
						label: computed(() => this.Resources.PARAMETERS28294),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'ASSET___PSEUDASSET04_',
						isCollapsible: false,
						anchored: false,
						directChildren: ['ASSET04_PSEUDPARAMLOA', 'ASSET04_PSEUDMANUALS_', 'ASSET04_PSEUDPARAMETE'],
						controlLimits: [
						],
					}, this),
					ASSET04_PSEUDPARAMLOA: new fieldControlClass.ButtonControl({
						id: 'ASSET04_PSEUDPARAMLOA',
						name: 'PARAMLOA',
						hasLabel: false,
						label: computed(() => this.Resources.PARAMETERS_LOAD27737),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ASSET04_PSEUDNOVOGR01',
						tab: 'ASSET___PSEUDASSET04_',
						// eslint-disable-next-line
						action: (event) => {
							const btnAction = () => {
								if (!vm.isEditable)
									return Promise.resolve(true)

								const action = 'GetCarga_Parameters'
								const params = { idsrc: vm.model.ValCodkinde.value, iddst: vm.primaryKeyValue }

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
							btnAction()
						},
						controlLimits: [
						],
					}, this),
					ASSET04_PSEUDMANUALS_: new fieldControlClass.ButtonControl({
						id: 'ASSET04_PSEUDMANUALS_',
						name: 'MANUALS',
						hasLabel: false,
						label: computed(() => this.Resources.MANUALS_LOAD21238),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ASSET04_PSEUDNOVOGR01',
						tab: 'ASSET___PSEUDASSET04_',
						// eslint-disable-next-line
						action: (event) => {
							const btnAction = () => {
								if (!vm.isEditable)
									return Promise.resolve(true)

								const action = 'GetCarga_Manuals'
								const params = { idsrc: vm.model.ValCodkinde.value, iddst: vm.primaryKeyValue }

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
							btnAction()
						},
						controlLimits: [
						],
					}, this),
					ASSET04_PSEUDPARAMETE: new fieldControlClass.TableListControl({
						id: 'ASSET04_PSEUDPARAMETE',
						name: 'PARAMETE',
						size: '',
						label: computed(() => this.Resources.PARAMETERS28294),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ASSET04_PSEUDNOVOGR01',
						tab: 'ASSET___PSEUDASSET04_',
						controller: 'ASSET',
						action: 'Asset04_ValParamete',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Param.ValParameter',
								area: 'PARAM',
								field: 'PARAMETER',
								label: computed(() => this.Resources.PARAMETER41976),
								dataLength: 50,
								scrollData: 30,
								export: 1,
								pkColumn: 'ValCodparam',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 2,
								name: 'ValDatatype',
								area: 'ASSPA',
								field: 'DATATYPE',
								label: computed(() => this.Resources.DATA_TYPE47159),
								dataLength: 1,
								scrollData: 1,
								isVisible: false,
								export: 1,
								array: computed(() => new qProjArrays.QArrayDatatype(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayDatatype.type,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 3,
								name: 'ValDecimalplaces',
								area: 'ASSPA',
								field: 'DECIMALPLACES',
								label: computed(() => this.Resources.DECIMAL_PLACES62575),
								scrollData: 1,
								maxDigits: 1,
								decimalPlaces: 0,
								isVisible: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValText',
								area: 'ASSPA',
								field: 'TEXT',
								label: computed(() => this.Resources.TEXT04938),
								dataLength: 50,
								scrollData: 30,
								isVisible: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 5,
								name: 'ValQuantity',
								area: 'ASSPA',
								field: 'QUANTITY',
								label: computed(() => this.Resources.QUANTITY06415),
								scrollData: 12,
								maxDigits: 7,
								decimalPlaces: 4,
								isVisible: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 6,
								name: 'ValDate',
								area: 'ASSPA',
								field: 'DATE',
								label: computed(() => this.Resources.DATE18475),
								scrollData: 8,
								dateTimeType: 'date',
								isVisible: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'ValToshow',
								area: 'ASSPA',
								field: 'TOSHOW',
								label: computed(() => this.Resources.VALUE10285),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValParamete',
							serverMode: true,
							pkColumn: 'ValCodasspa',
							tableAlias: 'ASSPA',
							tableNamePlural: computed(() => this.Resources.ASSET_PARAMETERS20615),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.PARAMETERS28294),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: true
							},
							filtersVisible: true,
							allowColumnFilters: true,
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
										formName: 'ASSPA',
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
										formName: 'ASSPA',
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
										formName: 'ASSPA',
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
										formName: 'ASSPA',
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
										action: vm.openFormAction,
										type: 'form',
										formName: 'ASSPA',
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
								id: 'RCA__ASSPA',
								name: '_ASSPA',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'ASSPA',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'ASSPA': {
									fnKeySelector: (row) => row.Fields.ValCodasspa,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValToshow',
							defaultSearchColumnNameOriginal: 'ValToshow',
							defaultColumnSorting: {
								columnName: 'Param.ValParameter',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-PARAM', 'changed-ASSPA', 'changed-ASSET'],
						uuid: 'Asset04_ValParamete',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'asset'],
								dependencyEvents: ['fieldChange:asset.codasset'],
								dependencyField: 'ASSET.CODASSET',
								fnValueSelector: (model) => model.ValCodasset.value
							},
						],
					}, this),
					formTabs: new fieldControlClass.TabsControl({
						id: 'formTabs',
						tabControlsIds: readonly([
							'ASSET___PSEUDASSET01_',
							'ASSET___PSEUDASSET02_',
							'ASSET___PSEUDASSET03_',
							'ASSET___PSEUDASSET04_',
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
					'ASSET___PSEUDNOVOGR01',
					'ASSET___PSEUDASSET01_',
					'ASSET___PSEUDASSET02_',
					'ASSET___PSEUDASSET03_',
					'ASSET___PSEUDASSET04_',
					'ASSET04_PSEUDNOVOGR01',
				]),

				tableFields: readonly([
					'ASSET02_PSEUDATTACHME',
					'ASSET03_PSEUDDOCUMENT',
					'ASSET04_PSEUDPARAMETE',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Asset: {
						get ValAssetnum() { return vm.model.ValAssetnum.value },
						set ValAssetnum(value) { vm.model.ValAssetnum.updateValue(value) },
						get ValAssettyp() { return vm.model.ValAssettyp.value },
						set ValAssettyp(value) { vm.model.ValAssettyp.updateValue(value) },
						get ValBg_color() { return vm.model.ValBg_color.value },
						set ValBg_color(value) { vm.model.ValBg_color.updateValue(value) },
						get ValCategory() { return vm.model.ValCategory.value },
						set ValCategory(value) { vm.model.ValCategory.updateValue(value) },
						get ValCodkinde() { return vm.model.ValCodkinde.value },
						set ValCodkinde(value) { vm.model.ValCodkinde.updateValue(value) },
						get ValCodmanuf() { return vm.model.ValCodmanuf.value },
						set ValCodmanuf(value) { vm.model.ValCodmanuf.updateValue(value) },
						get ValDescription() { return vm.model.ValDescription.value },
						set ValDescription(value) { vm.model.ValDescription.updateValue(value) },
						get ValGiai() { return vm.model.ValGiai.value },
						set ValGiai(value) { vm.model.ValGiai.updateValue(value) },
						get ValGrai() { return vm.model.ValGrai.value },
						set ValGrai(value) { vm.model.ValGrai.updateValue(value) },
						get ValIdenttyp() { return vm.model.ValIdenttyp.value },
						set ValIdenttyp(value) { vm.model.ValIdenttyp.updateValue(value) },
						get ValLongdesc() { return vm.model.ValLongdesc.value },
						set ValLongdesc(value) { vm.model.ValLongdesc.updateValue(value) },
						get ValName() { return vm.model.ValName.value },
						set ValName(value) { vm.model.ValName.updateValue(value) },
						get ValPhoto() { return vm.model.ValPhoto.value },
						set ValPhoto(value) { vm.model.ValPhoto.updateValue(value) },
					},
					Kinde: {
						get ValDesignat() { return vm.model.TableKindeDesignat.value },
						set ValDesignat(value) { vm.model.TableKindeDesignat.updateValue(value) },
					},
					Manuf: {
						get ValName() { return vm.model.TableManufName.value },
						set ValName(value) { vm.model.TableManufName.updateValue(value) },
					},
					keys: {
						/** The primary key of the ASSET table */
						get asset() { return vm.model.ValCodasset },
						/** The foreign key to the KINDE table */
						get kinde() { return vm.model.ValCodkinde },
						/** The foreign key to the MANUF table */
						get manuf() { return vm.model.ValCodmanuf },
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
// USE /[MANUAL GQT FORM_CODEJS ASSET]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT COMPONENT_BEFORE_UNMOUNT ASSET]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS ASSET]/
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
// USE /[MANUAL GQT FORM_LOADED_JS ASSET]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS ASSET]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS ASSET]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS ASSET]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS ASSET]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS ASSET]/
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
// USE /[MANUAL GQT AFTER_DEL_JS ASSET]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS ASSET]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS ASSET]/
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
// USE /[MANUAL GQT DLGUPDT ASSET]/
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
// USE /[MANUAL GQT CTRLBLR ASSET]/
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
// USE /[MANUAL GQT CTRLUPD ASSET]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS ASSET]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
