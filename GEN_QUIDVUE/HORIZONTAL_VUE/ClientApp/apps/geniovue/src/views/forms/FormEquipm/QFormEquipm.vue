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
			data-key="EQUIPM"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container
					v-show="controls.EQUIPM__PSEUDNOVOGR01.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.EQUIPM__PSEUDNOVOGR01.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="EQUIPM__PSEUDNOVOGR01"
							v-bind="controls.EQUIPM__PSEUDNOVOGR01"
							:is-visible="controls.EQUIPM__PSEUDNOVOGR01.isVisible">
							<!-- Start EQUIPM__PSEUDNOVOGR01 -->
							<q-row-container v-show="controls.EQUIPM__ASSETNAME____.isVisible">
								<q-control-wrapper
									v-show="controls.EQUIPM__ASSETNAME____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIPM__ASSETNAME____"
										v-on="controls.EQUIPM__ASSETNAME____.handlers"
										:loading="controls.EQUIPM__ASSETNAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EQUIPM__ASSETNAME____.props"
											@blur="onBlur(controls.EQUIPM__ASSETNAME____, model.ValName.value)"
											@change="model.ValName.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.EQUIPM__ASSETASSETTYP.isVisible || controls.EQUIPM__ASSETASSETNUM.isVisible">
								<q-control-wrapper
									v-show="controls.EQUIPM__ASSETASSETTYP.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIPM__ASSETASSETTYP"
										v-on="controls.EQUIPM__ASSETASSETTYP.handlers"
										:loading="controls.EQUIPM__ASSETASSETTYP.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.EQUIPM__ASSETASSETTYP.isVisible"
											v-bind="controls.EQUIPM__ASSETASSETTYP.props"
											@update:model-value="model.ValAssettyp.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.EQUIPM__ASSETASSETNUM.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIPM__ASSETASSETNUM"
										v-on="controls.EQUIPM__ASSETASSETNUM.handlers"
										:loading="controls.EQUIPM__ASSETASSETNUM.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.EQUIPM__ASSETASSETNUM.isVisible"
											v-bind="controls.EQUIPM__ASSETASSETNUM.props"
											@update:model-value="model.ValAssetnum.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.EQUIPM__ASSETIDENTTYP.isVisible || controls.EQUIPM__ASSETGRAI____.isVisible || controls.EQUIPM__ASSETGIAI____.isVisible">
								<q-control-wrapper
									v-show="controls.EQUIPM__ASSETIDENTTYP.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIPM__ASSETIDENTTYP"
										v-on="controls.EQUIPM__ASSETIDENTTYP.handlers"
										:loading="controls.EQUIPM__ASSETIDENTTYP.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.EQUIPM__ASSETIDENTTYP.isVisible"
											v-bind="controls.EQUIPM__ASSETIDENTTYP.props"
											@update:model-value="model.ValIdenttyp.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.EQUIPM__ASSETGRAI____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIPM__ASSETGRAI____"
										v-on="controls.EQUIPM__ASSETGRAI____.handlers"
										:loading="controls.EQUIPM__ASSETGRAI____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EQUIPM__ASSETGRAI____.props"
											@blur="onBlur(controls.EQUIPM__ASSETGRAI____, model.ValGrai.value)"
											@change="model.ValGrai.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.EQUIPM__ASSETGIAI____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIPM__ASSETGIAI____"
										v-on="controls.EQUIPM__ASSETGIAI____.handlers"
										:loading="controls.EQUIPM__ASSETGIAI____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EQUIPM__ASSETGIAI____.props"
											@blur="onBlur(controls.EQUIPM__ASSETGIAI____, model.ValGiai.value)"
											@change="model.ValGiai.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.EQUIPM__MANUFNAME____.isVisible">
								<q-control-wrapper
									v-show="controls.EQUIPM__MANUFNAME____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIPM__MANUFNAME____"
										v-on="controls.EQUIPM__MANUFNAME____.handlers"
										:loading="controls.EQUIPM__MANUFNAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.EQUIPM__MANUFNAME____.isVisible"
											v-bind="controls.EQUIPM__MANUFNAME____.props"
											v-on="controls.EQUIPM__MANUFNAME____.handlers" />
										<q-see-more-equipm-manufname
											v-if="controls.EQUIPM__MANUFNAME____.seeMoreIsVisible"
											v-bind="controls.EQUIPM__MANUFNAME____.seeMoreParams"
											v-on="controls.EQUIPM__MANUFNAME____.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.EQUIPM__KINDEDESIGNAT.isVisible">
								<q-control-wrapper
									v-show="controls.EQUIPM__KINDEDESIGNAT.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIPM__KINDEDESIGNAT"
										v-on="controls.EQUIPM__KINDEDESIGNAT.handlers"
										:loading="controls.EQUIPM__KINDEDESIGNAT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.EQUIPM__KINDEDESIGNAT.isVisible"
											v-bind="controls.EQUIPM__KINDEDESIGNAT.props"
											v-on="controls.EQUIPM__KINDEDESIGNAT.handlers" />
										<q-see-more-equipm-kindedesignat
											v-if="controls.EQUIPM__KINDEDESIGNAT.seeMoreIsVisible"
											v-bind="controls.EQUIPM__KINDEDESIGNAT.seeMoreParams"
											v-on="controls.EQUIPM__KINDEDESIGNAT.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End EQUIPM__PSEUDNOVOGR01 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.EQUIPM__PSEUDEQUIP01_.isVisible || controls.EQUIPM__PSEUDEQUIP02_.isVisible || controls.EQUIPM__PSEUDEQUIP03_.isVisible || controls.EQUIPM__PSEUDEQUIP04_.isVisible">
					<q-control-wrapper
						v-show="controls.EQUIPM__PSEUDEQUIP01_.isVisible || controls.EQUIPM__PSEUDEQUIP02_.isVisible || controls.EQUIPM__PSEUDEQUIP03_.isVisible || controls.EQUIPM__PSEUDEQUIP04_.isVisible"
						class="control-join-group">
						<q-tab-container
							id="q-tabs-EQUIPM"
							v-bind="controls.formTabs.props"
							@tab-changed="controls.formTabs.selectTab($event)">
							<template #tab-panel>
								<section
									v-if="controls.EQUIPM__PSEUDEQUIP01_.isVisible"
									v-show="controls.formTabs.selectedTab === 'EQUIPM__PSEUDEQUIP01_'">
									<div
										id="EQUIPM__PSEUDEQUIP01_"
										role="tabpanel"
										aria-labelledby="tab-container-EQUIPM__PSEUDEQUIP01_">
										<q-row-container v-show="controls.EQUIP01_ASSETPHOTO___.isVisible">
											<q-control-wrapper
												v-show="controls.EQUIP01_ASSETPHOTO___.isVisible"
												class="control-join-group">
												<base-input-structure
													class="q-image"
													v-bind="controls.EQUIP01_ASSETPHOTO___"
													v-on="controls.EQUIP01_ASSETPHOTO___.handlers"
													:loading="controls.EQUIP01_ASSETPHOTO___.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-image
														v-if="controls.EQUIP01_ASSETPHOTO___.isVisible"
														v-bind="controls.EQUIP01_ASSETPHOTO___.props"
														v-on="controls.EQUIP01_ASSETPHOTO___.handlers" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
									</div>
								</section>
								<section
									v-if="controls.EQUIPM__PSEUDEQUIP02_.isVisible"
									v-show="controls.formTabs.selectedTab === 'EQUIPM__PSEUDEQUIP02_'">
									<div
										id="EQUIPM__PSEUDEQUIP02_"
										role="tabpanel"
										aria-labelledby="tab-container-EQUIPM__PSEUDEQUIP02_">
										<q-row-container v-show="controls.EQUIP02_PSEUDNOVOGR01.isVisible">
											<q-control-wrapper
												v-show="controls.EQUIP02_PSEUDNOVOGR01.isVisible"
												class="control-join-group">
												<q-group-box-container
													id="EQUIP02_PSEUDNOVOGR01"
													v-bind="controls.EQUIP02_PSEUDNOVOGR01"
													no-border
													:is-visible="controls.EQUIP02_PSEUDNOVOGR01.isVisible">
													<!-- Start EQUIP02_PSEUDNOVOGR01 -->
													<q-row-container v-show="controls.EQUIP02_PSEUDATTACHME.isVisible">
														<q-control-wrapper
															v-show="controls.EQUIP02_PSEUDATTACHME.isVisible"
															class="control-join-group">
															<q-table
																v-show="controls.EQUIP02_PSEUDATTACHME.isVisible"
																v-bind="controls.EQUIP02_PSEUDATTACHME"
																v-on="controls.EQUIP02_PSEUDATTACHME.handlers" />
															<q-table-extra-extension
																:list-ctrl="controls.EQUIP02_PSEUDATTACHME"
																v-on="controls.EQUIP02_PSEUDATTACHME.handlers" />
														</q-control-wrapper>
													</q-row-container>
													<!-- End EQUIP02_PSEUDNOVOGR01 -->
												</q-group-box-container>
											</q-control-wrapper>
										</q-row-container>
									</div>
								</section>
								<section
									v-if="controls.EQUIPM__PSEUDEQUIP03_.isVisible"
									v-show="controls.formTabs.selectedTab === 'EQUIPM__PSEUDEQUIP03_'">
									<div
										id="EQUIPM__PSEUDEQUIP03_"
										role="tabpanel"
										aria-labelledby="tab-container-EQUIPM__PSEUDEQUIP03_">
										<q-row-container v-show="controls.EQUIP03_PSEUDNOVOGR01.isVisible">
											<q-control-wrapper
												v-show="controls.EQUIP03_PSEUDNOVOGR01.isVisible"
												class="control-join-group">
												<q-group-box-container
													id="EQUIP03_PSEUDNOVOGR01"
													v-bind="controls.EQUIP03_PSEUDNOVOGR01"
													no-border
													:is-visible="controls.EQUIP03_PSEUDNOVOGR01.isVisible">
													<!-- Start EQUIP03_PSEUDNOVOGR01 -->
													<q-row-container v-show="controls.EQUIP03_PSEUDDOCUMENT.isVisible">
														<q-control-wrapper
															v-show="controls.EQUIP03_PSEUDDOCUMENT.isVisible"
															class="control-join-group">
															<q-table
																v-show="controls.EQUIP03_PSEUDDOCUMENT.isVisible"
																v-bind="controls.EQUIP03_PSEUDDOCUMENT"
																v-on="controls.EQUIP03_PSEUDDOCUMENT.handlers" />
															<q-table-extra-extension
																:list-ctrl="controls.EQUIP03_PSEUDDOCUMENT"
																v-on="controls.EQUIP03_PSEUDDOCUMENT.handlers" />
														</q-control-wrapper>
													</q-row-container>
													<!-- End EQUIP03_PSEUDNOVOGR01 -->
												</q-group-box-container>
											</q-control-wrapper>
										</q-row-container>
									</div>
								</section>
								<section
									v-if="controls.EQUIPM__PSEUDEQUIP04_.isVisible"
									v-show="controls.formTabs.selectedTab === 'EQUIPM__PSEUDEQUIP04_'">
									<div
										id="EQUIPM__PSEUDEQUIP04_"
										role="tabpanel"
										aria-labelledby="tab-container-EQUIPM__PSEUDEQUIP04_">
										<q-row-container v-show="controls.EQUIP04_PSEUDNOVOGR01.isVisible">
											<q-control-wrapper
												v-show="controls.EQUIP04_PSEUDNOVOGR01.isVisible"
												class="control-join-group">
												<q-group-box-container
													id="EQUIP04_PSEUDNOVOGR01"
													v-bind="controls.EQUIP04_PSEUDNOVOGR01"
													no-border
													:is-visible="controls.EQUIP04_PSEUDNOVOGR01.isVisible">
													<!-- Start EQUIP04_PSEUDNOVOGR01 -->
													<q-row-container v-show="controls.EQUIP04_PSEUDPARAMLOA.isVisible || controls.EQUIP04_PSEUDMANUALS_.isVisible || controls.EQUIP04_PSEUDPARAMETE.isVisible">
														<q-control-wrapper
															v-show="controls.EQUIP04_PSEUDPARAMLOA.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-button"
																v-bind="controls.EQUIP04_PSEUDPARAMLOA"
																v-on="controls.EQUIP04_PSEUDPARAMLOA.handlers"
																:loading="controls.EQUIP04_PSEUDPARAMLOA.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-button
																	v-if="controls.EQUIP04_PSEUDPARAMLOA.isVisible"
																	id="EQUIP04_PSEUDPARAMLOA"
																	:label="controls.EQUIP04_PSEUDPARAMLOA.label"
																	:disabled="controls.EQUIP04_PSEUDPARAMLOA.isBlocked"
																	@click="controls.EQUIP04_PSEUDPARAMLOA.action($event)">
																</q-button>
															</base-input-structure>
														</q-control-wrapper>
														<q-control-wrapper
															v-show="controls.EQUIP04_PSEUDMANUALS_.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-button"
																v-bind="controls.EQUIP04_PSEUDMANUALS_"
																v-on="controls.EQUIP04_PSEUDMANUALS_.handlers"
																:loading="controls.EQUIP04_PSEUDMANUALS_.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-button
																	v-if="controls.EQUIP04_PSEUDMANUALS_.isVisible"
																	id="EQUIP04_PSEUDMANUALS_"
																	:label="controls.EQUIP04_PSEUDMANUALS_.label"
																	:disabled="controls.EQUIP04_PSEUDMANUALS_.isBlocked"
																	@click="controls.EQUIP04_PSEUDMANUALS_.action($event)">
																</q-button>
															</base-input-structure>
														</q-control-wrapper>
														<q-control-wrapper
															v-show="controls.EQUIP04_PSEUDPARAMETE.isVisible"
															class="control-join-group">
															<q-table
																v-show="controls.EQUIP04_PSEUDPARAMETE.isVisible"
																v-bind="controls.EQUIP04_PSEUDPARAMETE"
																v-on="controls.EQUIP04_PSEUDPARAMETE.handlers" />
															<q-table-extra-extension
																:list-ctrl="controls.EQUIP04_PSEUDPARAMETE"
																v-on="controls.EQUIP04_PSEUDPARAMETE.handlers" />
														</q-control-wrapper>
													</q-row-container>
													<!-- End EQUIP04_PSEUDNOVOGR01 -->
												</q-group-box-container>
											</q-control-wrapper>
										</q-row-container>
									</div>
								</section>
							</template>
						</q-tab-container>
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

	import FormViewModel from './QFormEquipmViewModel.js'

	const requiredTextResources = ['QFormEquipm', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS EQUIPM]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormEquipm',

		components: {
			QSeeMoreEquipmManufname: defineAsyncComponent(() => import('@/views/forms/FormEquipm/dbedits/EquipmManufnameSeeMore.vue')),
			QSeeMoreEquipmKindedesignat: defineAsyncComponent(() => import('@/views/forms/FormEquipm/dbedits/EquipmKindedesignatSeeMore.vue')),
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
					name: 'EQUIPM',
					location: 'form-EQUIPM',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormEquipm', false),

				interfaceMetadata: {
					id: 'QFormEquipm', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'EQUIPM',
					route: 'form-EQUIPM',
					area: 'ASSET',
					primaryKey: 'ValCodasset',
					designation: computed(() => genericFunctions.formatString(this.Resources._ASSET__ASSETNUM____37227, vm.model.ValAssetnum.displayValue, vm.model.ValName.displayValue)),
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
						text: computed(() => vm.Resources.GRAVAR45301),
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
					EQUIPM__PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'EQUIPM__PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						label: computed(() => this.Resources.ASSET_IDENTIFICATION53152),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIPM__ASSETNAME____', 'EQUIPM__ASSETASSETTYP', 'EQUIPM__ASSETASSETNUM', 'EQUIPM__ASSETIDENTTYP', 'EQUIPM__ASSETGRAI____', 'EQUIPM__ASSETGIAI____', 'EQUIPM__MANUFNAME____', 'EQUIPM__KINDEDESIGNAT'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					EQUIPM__ASSETNAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:asset.name',
						id: 'EQUIPM__ASSETNAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.IDENTIFICATION_NAME16317),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIPM__PSEUDNOVOGR01',
						maxLength: 85,
						labelId: 'label_EQUIPM__ASSETNAME____',
						controlLimits: [
						],
					}, this),
					EQUIPM__ASSETASSETTYP: new fieldControlClass.ArrayStringControl({
						modelField: 'ValAssettyp',
						valueChangeEvent: 'fieldChange:asset.assettyp',
						id: 'EQUIPM__ASSETASSETTYP',
						name: 'ASSETTYP',
						size: 'medium',
						label: computed(() => this.Resources.ASSET_TYPE02033),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIPM__PSEUDNOVOGR01',
						maxLength: 1,
						labelId: 'label_EQUIPM__ASSETASSETTYP',
						mustBeFilled: true,
						arrayName: 'AssetTyp',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					EQUIPM__ASSETASSETNUM: new fieldControlClass.NumberControl({
						modelField: 'ValAssetnum',
						valueChangeEvent: 'fieldChange:asset.assetnum',
						id: 'EQUIPM__ASSETASSETNUM',
						name: 'ASSETNUM',
						size: 'small',
						label: computed(() => this.Resources.ASSET_NUMBER52372),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIPM__PSEUDNOVOGR01',
						maxIntegers: 10,
						maxDecimals: 0,
						isSequencial: true,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					EQUIPM__ASSETIDENTTYP: new fieldControlClass.ArrayStringControl({
						modelField: 'ValIdenttyp',
						valueChangeEvent: 'fieldChange:asset.identtyp',
						id: 'EQUIPM__ASSETIDENTTYP',
						name: 'IDENTTYP',
						size: 'small',
						label: computed(() => this.Resources.IDENTIFIER_TYPE60623),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIPM__PSEUDNOVOGR01',
						maxLength: 1,
						labelId: 'label_EQUIPM__ASSETIDENTTYP',
						arrayName: 'IdentTyp',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					EQUIPM__ASSETGRAI____: new fieldControlClass.StringControl({
						modelField: 'ValGrai',
						valueChangeEvent: 'fieldChange:asset.grai',
						id: 'EQUIPM__ASSETGRAI____',
						name: 'GRAI',
						size: 'xlarge',
						label: computed(() => this.Resources.GRAI___GLOBAL_RETURN06821),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIPM__PSEUDNOVOGR01',
						maxLength: 50,
						labelId: 'label_EQUIPM__ASSETGRAI____',
						controlLimits: [
						],
					}, this),
					EQUIPM__ASSETGIAI____: new fieldControlClass.StringControl({
						modelField: 'ValGiai',
						valueChangeEvent: 'fieldChange:asset.giai',
						id: 'EQUIPM__ASSETGIAI____',
						name: 'GIAI',
						size: 'xlarge',
						label: computed(() => this.Resources.GIAI___GLOBAL_INDIVI63214),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIPM__PSEUDNOVOGR01',
						maxLength: 50,
						labelId: 'label_EQUIPM__ASSETGIAI____',
						controlLimits: [
						],
					}, this),
					EQUIPM__MANUFNAME____: new fieldControlClass.LookupControl({
						modelField: 'TableManufName',
						valueChangeEvent: 'fieldChange:manuf.name',
						id: 'EQUIPM__MANUFNAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.MANUFACTURER50759),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIPM__PSEUDNOVOGR01',
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
					EQUIPM__PSEUDEQUIP01_: new fieldControlClass.TabControl({
						id: 'EQUIPM__PSEUDEQUIP01_',
						name: 'EQUIP01',
						size: 'xxlarge',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['EQUIP01_ASSETPHOTO___'],
						controlLimits: [
						],
					}, this),
					EQUIPM__PSEUDEQUIP02_: new fieldControlClass.TabControl({
						id: 'EQUIPM__PSEUDEQUIP02_',
						name: 'EQUIP02',
						size: 'xxlarge',
						label: computed(() => this.Resources.ATTACHMENTS19612),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['EQUIP02_PSEUDNOVOGR01'],
						controlLimits: [
						],
					}, this),
					EQUIPM__PSEUDEQUIP03_: new fieldControlClass.TabControl({
						id: 'EQUIPM__PSEUDEQUIP03_',
						name: 'EQUIP03',
						size: 'xxlarge',
						label: computed(() => this.Resources.DOCUMENTS14470),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['EQUIP03_PSEUDNOVOGR01'],
						controlLimits: [
						],
					}, this),
					EQUIPM__PSEUDEQUIP04_: new fieldControlClass.TabControl({
						id: 'EQUIPM__PSEUDEQUIP04_',
						name: 'EQUIP04',
						size: 'xxlarge',
						label: computed(() => this.Resources.PARAMETERS28294),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						directChildren: ['EQUIP04_PSEUDNOVOGR01'],
						controlLimits: [
						],
					}, this),
					EQUIPM__KINDEDESIGNAT: new fieldControlClass.LookupControl({
						modelField: 'TableKindeDesignat',
						valueChangeEvent: 'fieldChange:kinde.designat',
						id: 'EQUIPM__KINDEDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.KIND_OF_EQUIPMENT22928),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIPM__PSEUDNOVOGR01',
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
					EQUIP01_ASSETPHOTO___: new fieldControlClass.ImageControl({
						modelField: 'ValPhoto',
						valueChangeEvent: 'fieldChange:asset.photo',
						id: 'EQUIP01_ASSETPHOTO___',
						name: 'PHOTO',
						size: 'xxlarge',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'EQUIPM__PSEUDEQUIP01_',
						height: 300,
						width: 400,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO51874)),
						controlLimits: [
						],
					}, this),
					EQUIP02_PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'EQUIP02_PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'xxlarge',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'EQUIPM__PSEUDEQUIP02_',
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIP02_PSEUDATTACHME'],
						controlLimits: [
						],
					}, this),
					EQUIP02_PSEUDATTACHME: new fieldControlClass.TableListControl({
						id: 'EQUIP02_PSEUDATTACHME',
						name: 'ATTACHME',
						size: '',
						label: computed(() => this.Resources.ATTACHMENTS19612),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP02_PSEUDNOVOGR01',
						tab: 'EQUIPM__PSEUDEQUIP02_',
						controller: 'ASSET',
						action: 'Equip02_ValAttachme',
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
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValNote',
								area: 'ATTAC',
								field: 'NOTE',
								label: computed(() => this.Resources.NOTE54557),
								scrollData: 30,
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
						uuid: 'Equip02_ValAttachme',
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
					EQUIP03_PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'EQUIP03_PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'xxlarge',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'EQUIPM__PSEUDEQUIP03_',
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIP03_PSEUDDOCUMENT'],
						controlLimits: [
						],
					}, this),
					EQUIP03_PSEUDDOCUMENT: new fieldControlClass.TableListControl({
						id: 'EQUIP03_PSEUDDOCUMENT',
						name: 'DOCUMENT',
						size: '',
						label: computed(() => this.Resources.DOCUMENTS14470),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP03_PSEUDNOVOGR01',
						tab: 'EQUIPM__PSEUDEQUIP03_',
						controller: 'ASSET',
						action: 'Equip03_ValDocument',
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
								viewType: qEnums.documentViewTypeMode.print,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValNotes',
								area: 'ASSMA',
								field: 'NOTES',
								label: computed(() => this.Resources.NOTES05274),
								scrollData: 30,
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
						globalEvents: ['changed-ASSET', 'changed-ASSMA'],
						uuid: 'Equip03_ValDocument',
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
					EQUIP04_PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'EQUIP04_PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'xxlarge',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						tab: 'EQUIPM__PSEUDEQUIP04_',
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIP04_PSEUDPARAMLOA', 'EQUIP04_PSEUDMANUALS_', 'EQUIP04_PSEUDPARAMETE'],
						controlLimits: [
						],
					}, this),
					EQUIP04_PSEUDPARAMLOA: new fieldControlClass.ButtonControl({
						id: 'EQUIP04_PSEUDPARAMLOA',
						name: 'PARAMLOA',
						size: 'medium',
						hasLabel: false,
						label: computed(() => this.Resources.PARAMETERS_LOAD27737),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP04_PSEUDNOVOGR01',
						tab: 'EQUIPM__PSEUDEQUIP04_',
						// eslint-disable-next-line
						action: (event) => {
							let btnAction = () => {
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
					EQUIP04_PSEUDMANUALS_: new fieldControlClass.ButtonControl({
						id: 'EQUIP04_PSEUDMANUALS_',
						name: 'MANUALS',
						size: 'small',
						hasLabel: false,
						label: computed(() => this.Resources.MANUALS_LOAD21238),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP04_PSEUDNOVOGR01',
						tab: 'EQUIPM__PSEUDEQUIP04_',
						// eslint-disable-next-line
						action: (event) => {
							let btnAction = () => {
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
					EQUIP04_PSEUDPARAMETE: new fieldControlClass.TableListControl({
						id: 'EQUIP04_PSEUDPARAMETE',
						name: 'PARAMETE',
						size: '',
						label: computed(() => this.Resources.PARAMETERS28294),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP04_PSEUDNOVOGR01',
						tab: 'EQUIPM__PSEUDEQUIP04_',
						controller: 'ASSET',
						action: 'Equip04_ValParamete',
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
								array: computed(() => qProjArrays.QArrayDatatype.setResources(vm.$getResource).elements),
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
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'ValToshow',
								area: 'ASSPA',
								field: 'TOSHOW',
								label: computed(() => this.Resources.VALUE10285),
								dataLength: 50,
								scrollData: 30,
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
								visibility: true,
								searchOnPressEnter: true
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
						globalEvents: ['changed-ASSPA', 'changed-PARAM', 'changed-ASSET'],
						uuid: 'Equip04_ValParamete',
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
						tabControlsIds: readonly([
							'EQUIPM__PSEUDEQUIP01_',
							'EQUIPM__PSEUDEQUIP02_',
							'EQUIPM__PSEUDEQUIP03_',
							'EQUIPM__PSEUDEQUIP04_',
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
					'EQUIPM__PSEUDNOVOGR01',
					'EQUIPM__PSEUDEQUIP01_',
					'EQUIPM__PSEUDEQUIP02_',
					'EQUIP02_PSEUDNOVOGR01',
					'EQUIPM__PSEUDEQUIP03_',
					'EQUIP03_PSEUDNOVOGR01',
					'EQUIPM__PSEUDEQUIP04_',
					'EQUIP04_PSEUDNOVOGR01',
				]),

				tableFields: readonly([
					'EQUIP02_PSEUDATTACHME',
					'EQUIP03_PSEUDDOCUMENT',
					'EQUIP04_PSEUDPARAMETE',
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
						get ValCodkinde() { return vm.model.ValCodkinde.value },
						set ValCodkinde(value) { vm.model.ValCodkinde.updateValue(value) },
						get ValCodmanuf() { return vm.model.ValCodmanuf.value },
						set ValCodmanuf(value) { vm.model.ValCodmanuf.updateValue(value) },
						get ValGiai() { return vm.model.ValGiai.value },
						set ValGiai(value) { vm.model.ValGiai.updateValue(value) },
						get ValGrai() { return vm.model.ValGrai.value },
						set ValGrai(value) { vm.model.ValGrai.updateValue(value) },
						get ValIdenttyp() { return vm.model.ValIdenttyp.value },
						set ValIdenttyp(value) { vm.model.ValIdenttyp.updateValue(value) },
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
// USE /[MANUAL GQT FORM_CODEJS EQUIPM]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS EQUIPM]/
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
// USE /[MANUAL GQT FORM_LOADED_JS EQUIPM]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS EQUIPM]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS EQUIPM]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS EQUIPM]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS EQUIPM]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS EQUIPM]/
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
// USE /[MANUAL GQT AFTER_DEL_JS EQUIPM]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS EQUIPM]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS EQUIPM]/
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
// USE /[MANUAL GQT DLGUPDT EQUIPM]/
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
// USE /[MANUAL GQT CTRLBLR EQUIPM]/
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
// USE /[MANUAL GQT CTRLUPD EQUIPM]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS EQUIPM]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
			// Watchers for changes in the state of tabs.
			'controls.formTabs.selectedTab'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'formTabs',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
		}
	}
</script>
