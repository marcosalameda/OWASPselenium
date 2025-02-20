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
			data-key="EQUIGROU"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container
					v-show="controls.EQUIGROUPSEUDNEWGRP19.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.EQUIGROUPSEUDNEWGRP19.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="EQUIGROUPSEUDNEWGRP19"
							v-bind="controls.EQUIGROUPSEUDNEWGRP19"
							:is-visible="controls.EQUIGROUPSEUDNEWGRP19.isVisible">
							<!-- Start EQUIGROUPSEUDNEWGRP19 -->
							<q-row-container
								v-show="controls.EQUIGROUPSEUDNEWGRP13.isVisible"
								is-large>
								<q-control-wrapper
									v-show="controls.EQUIGROUPSEUDNEWGRP13.isVisible"
									class="row-line-group">
									<q-group-box-container
										id="EQUIGROUPSEUDNEWGRP13"
										v-bind="controls.EQUIGROUPSEUDNEWGRP13"
										:is-visible="controls.EQUIGROUPSEUDNEWGRP13.isVisible">
										<!-- Start EQUIGROUPSEUDNEWGRP13 -->
										<q-row-container v-show="controls.EQUIGROUPESS1PHOTOGRA.isVisible || controls.EQUIGROUPESS1NAME____.isVisible || controls.EQUIGROUPESS1GENDER__.isVisible">
											<q-control-wrapper
												v-show="controls.EQUIGROUPESS1PHOTOGRA.isVisible"
												class="control-join-group">
												<base-input-structure
													class="q-image"
													v-bind="controls.EQUIGROUPESS1PHOTOGRA"
													v-on="controls.EQUIGROUPESS1PHOTOGRA.handlers"
													:loading="controls.EQUIGROUPESS1PHOTOGRA.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-image
														v-if="controls.EQUIGROUPESS1PHOTOGRA.isVisible"
														v-bind="controls.EQUIGROUPESS1PHOTOGRA.props"
														v-on="controls.EQUIGROUPESS1PHOTOGRA.handlers" />
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.EQUIGROUPESS1NAME____.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.EQUIGROUPESS1NAME____"
													v-on="controls.EQUIGROUPESS1NAME____.handlers"
													:loading="controls.EQUIGROUPESS1NAME____.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-lookup
														v-if="controls.EQUIGROUPESS1NAME____.isVisible"
														v-bind="controls.EQUIGROUPESS1NAME____.props"
														v-on="controls.EQUIGROUPESS1NAME____.handlers" />
													<q-see-more-equigroupess1name
														v-if="controls.EQUIGROUPESS1NAME____.seeMoreIsVisible"
														v-bind="controls.EQUIGROUPESS1NAME____.seeMoreParams"
														v-on="controls.EQUIGROUPESS1NAME____.handlers" />
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.EQUIGROUPESS1GENDER__.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.EQUIGROUPESS1GENDER__"
													v-on="controls.EQUIGROUPESS1GENDER__.handlers"
													:loading="controls.EQUIGROUPESS1GENDER__.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-select
														v-if="controls.EQUIGROUPESS1GENDER__.isVisible"
														v-bind="controls.EQUIGROUPESS1GENDER__.props"
														:model-value="model.Pess1ValGender.value" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container
											v-show="controls.EQUIGROUPSEUDNEWGRP14.isVisible"
											is-large>
											<q-control-wrapper
												v-show="controls.EQUIGROUPSEUDNEWGRP14.isVisible"
												class="row-line-group">
												<q-group-box-container
													id="EQUIGROUPSEUDNEWGRP14"
													v-bind="controls.EQUIGROUPSEUDNEWGRP14"
													:is-visible="controls.EQUIGROUPSEUDNEWGRP14.isVisible">
													<!-- Start EQUIGROUPSEUDNEWGRP14 -->
													<q-row-container v-show="controls.EQUIGROUPESS1DTNASCIM.isVisible || controls.EQUIGROUPESS1IDADE___.isVisible">
														<q-control-wrapper
															v-show="controls.EQUIGROUPESS1DTNASCIM.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.EQUIGROUPESS1DTNASCIM"
																v-on="controls.EQUIGROUPESS1DTNASCIM.handlers"
																:loading="controls.EQUIGROUPESS1DTNASCIM.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-date-time-picker
																	v-if="controls.EQUIGROUPESS1DTNASCIM.isVisible"
																	v-bind="controls.EQUIGROUPESS1DTNASCIM.props"
																	:model-value="model.Pess1ValDtnascim.value"
																	@reset-icon-click="model.Pess1ValDtnascim.fnUpdateValue(model.Pess1ValDtnascim.originalValue ?? new Date())"
																	@update:model-value="model.Pess1ValDtnascim.fnUpdateValue($event ?? '')" />
															</base-input-structure>
														</q-control-wrapper>
														<q-control-wrapper
															v-show="controls.EQUIGROUPESS1IDADE___.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.EQUIGROUPESS1IDADE___"
																v-on="controls.EQUIGROUPESS1IDADE___.handlers"
																:loading="controls.EQUIGROUPESS1IDADE___.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-numeric-input
																	v-if="controls.EQUIGROUPESS1IDADE___.isVisible"
																	v-bind="controls.EQUIGROUPESS1IDADE___.props"
																	@update:model-value="model.Pess1ValIdade.fnUpdateValue" />
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<!-- End EQUIGROUPSEUDNEWGRP14 -->
												</q-group-box-container>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container
											v-show="controls.EQUIGROUPSEUDNEWGRP17.isVisible"
											is-large>
											<q-control-wrapper
												v-show="controls.EQUIGROUPSEUDNEWGRP17.isVisible"
												class="row-line-group">
												<q-accordion-container
													id="EQUIGROUPSEUDNEWGRP17"
													v-bind="controls.EQUIGROUPSEUDNEWGRP17"
													v-on="controls.EQUIGROUPSEUDNEWGRP17.handlers"
													v-slot="{ onStateChanged }">
													<!-- Start EQUIGROUPSEUDNEWGRP17 -->
													<q-group-collapsible
														id="EQUIGROUPSEUDNEWGRP15"
														v-bind="controls.EQUIGROUPSEUDNEWGRP15"
														v-on="controls.EQUIGROUPSEUDNEWGRP15.handlers"
														@state-changed="(state, groupId) => onStateChanged(state, groupId)">
														<!-- Start EQUIGROUPSEUDNEWGRP15 -->
														<q-row-container v-show="controls.EQUIGROUPESS1IDFUNCIO.isVisible || controls.EQUIGROUPESS1TELEPHON.isVisible">
															<q-control-wrapper
																v-show="controls.EQUIGROUPESS1IDFUNCIO.isVisible"
																class="control-join-group">
																<base-input-structure
																	class="i-text"
																	v-bind="controls.EQUIGROUPESS1IDFUNCIO"
																	v-on="controls.EQUIGROUPESS1IDFUNCIO.handlers"
																	:loading="controls.EQUIGROUPESS1IDFUNCIO.props.loading"
																	:reporting-mode-on="reportingModeCAV"
																	:suggestion-mode-on="suggestionModeOn">
																	<q-numeric-input
																		v-if="controls.EQUIGROUPESS1IDFUNCIO.isVisible"
																		v-bind="controls.EQUIGROUPESS1IDFUNCIO.props"
																		@update:model-value="model.Pess1ValIdfuncio.fnUpdateValue" />
																</base-input-structure>
															</q-control-wrapper>
															<q-control-wrapper
																v-show="controls.EQUIGROUPESS1TELEPHON.isVisible"
																class="control-join-group">
																<base-input-structure
																	class="i-text"
																	v-bind="controls.EQUIGROUPESS1TELEPHON"
																	v-on="controls.EQUIGROUPESS1TELEPHON.handlers"
																	:loading="controls.EQUIGROUPESS1TELEPHON.props.loading"
																	:reporting-mode-on="reportingModeCAV"
																	:suggestion-mode-on="suggestionModeOn">
																	<q-text-field
																		v-bind="controls.EQUIGROUPESS1TELEPHON.props"
																		:model-value="model.Pess1ValTelephon.value" />
																</base-input-structure>
															</q-control-wrapper>
														</q-row-container>
														<!-- End EQUIGROUPSEUDNEWGRP15 -->
													</q-group-collapsible>
													<q-group-collapsible
														id="EQUIGROUPSEUDNEWGRP16"
														v-bind="controls.EQUIGROUPSEUDNEWGRP16"
														v-on="controls.EQUIGROUPSEUDNEWGRP16.handlers"
														@state-changed="(state, groupId) => onStateChanged(state, groupId)">
														<!-- Start EQUIGROUPSEUDNEWGRP16 -->
														<q-row-container v-show="controls.EQUIGROUPESS1EMAIL___.isVisible || controls.EQUIGROUPESS1EMAIL2__.isVisible">
															<q-control-wrapper
																v-show="controls.EQUIGROUPESS1EMAIL___.isVisible"
																class="control-join-group">
																<base-input-structure
																	class="i-text"
																	v-bind="controls.EQUIGROUPESS1EMAIL___"
																	v-on="controls.EQUIGROUPESS1EMAIL___.handlers"
																	:loading="controls.EQUIGROUPESS1EMAIL___.props.loading"
																	:reporting-mode-on="reportingModeCAV"
																	:suggestion-mode-on="suggestionModeOn">
																	<q-text-field
																		v-bind="controls.EQUIGROUPESS1EMAIL___.props"
																		:model-value="model.Pess1ValEmail.value" />
																</base-input-structure>
															</q-control-wrapper>
															<q-control-wrapper
																v-show="controls.EQUIGROUPESS1EMAIL2__.isVisible"
																class="control-join-group">
																<base-input-structure
																	class="i-text"
																	v-bind="controls.EQUIGROUPESS1EMAIL2__"
																	v-on="controls.EQUIGROUPESS1EMAIL2__.handlers"
																	:loading="controls.EQUIGROUPESS1EMAIL2__.props.loading"
																	:reporting-mode-on="reportingModeCAV"
																	:suggestion-mode-on="suggestionModeOn">
																	<q-text-field
																		v-bind="controls.EQUIGROUPESS1EMAIL2__.props"
																		:model-value="model.Pess1ValEmail2.value" />
																</base-input-structure>
															</q-control-wrapper>
														</q-row-container>
														<!-- End EQUIGROUPSEUDNEWGRP16 -->
													</q-group-collapsible>
													<!-- End EQUIGROUPSEUDNEWGRP17 -->
												</q-accordion-container>
											</q-control-wrapper>
										</q-row-container>
										<!-- End EQUIGROUPSEUDNEWGRP13 -->
									</q-group-box-container>
								</q-control-wrapper>
							</q-row-container>
							<!-- End EQUIGROUPSEUDNEWGRP19 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.EQUIGROUPSEUDNEWGRP18.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.EQUIGROUPSEUDNEWGRP18.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="EQUIGROUPSEUDNEWGRP18"
							v-bind="controls.EQUIGROUPSEUDNEWGRP18"
							:is-visible="controls.EQUIGROUPSEUDNEWGRP18.isVisible">
							<!-- Start EQUIGROUPSEUDNEWGRP18 -->
							<q-row-container v-show="controls.EQUIGROUPSEUDFIELD001.isVisible">
								<q-control-wrapper
									v-show="controls.EQUIGROUPSEUDFIELD001.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-static-text"
										v-bind="controls.EQUIGROUPSEUDFIELD001"
										v-on="controls.EQUIGROUPSEUDFIELD001.handlers"
										:loading="controls.EQUIGROUPSEUDFIELD001.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-static-text
											v-if="controls.EQUIGROUPSEUDFIELD001.isVisible"
											id="EQUIGROUPSEUDFIELD001"
											:size="controls.EQUIGROUPSEUDFIELD001.size"
											:text="controls.EQUIGROUPSEUDFIELD001.label"
											supports-html />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container
								v-show="controls.EQUIGROUPSEUDNEWGRP01.isVisible"
								is-large>
								<q-control-wrapper
									v-show="controls.EQUIGROUPSEUDNEWGRP01.isVisible"
									class="row-line-group">
									<q-group-box-container
										id="EQUIGROUPSEUDNEWGRP01"
										class="c-groupbox--title-background"
										v-bind="controls.EQUIGROUPSEUDNEWGRP01"
										:is-visible="controls.EQUIGROUPSEUDNEWGRP01.isVisible">
										<!-- Start EQUIGROUPSEUDNEWGRP01 -->
										<q-row-container
											v-show="controls.EQUIGROUPSEUDNEWGRP02.isVisible"
											is-large>
											<q-control-wrapper
												v-show="controls.EQUIGROUPSEUDNEWGRP02.isVisible"
												class="row-line-group">
												<q-group-box-container
													id="EQUIGROUPSEUDNEWGRP02"
													class="c-groupbox--minor"
													v-bind="controls.EQUIGROUPSEUDNEWGRP02"
													:is-visible="controls.EQUIGROUPSEUDNEWGRP02.isVisible">
													<!-- Start EQUIGROUPSEUDNEWGRP02 -->
													<q-row-container v-show="controls.EQUIGROUCMPNYLOGO____.isVisible">
														<q-control-wrapper
															v-show="controls.EQUIGROUCMPNYLOGO____.isVisible"
															class="control-join-group">
															<base-input-structure
																class="q-image"
																v-bind="controls.EQUIGROUCMPNYLOGO____"
																v-on="controls.EQUIGROUCMPNYLOGO____.handlers"
																:loading="controls.EQUIGROUCMPNYLOGO____.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-image
																	v-if="controls.EQUIGROUCMPNYLOGO____.isVisible"
																	v-bind="controls.EQUIGROUCMPNYLOGO____.props"
																	v-on="controls.EQUIGROUCMPNYLOGO____.handlers" />
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<q-row-container v-show="controls.EQUIGROUCMPNYDESIGNAT.isVisible || controls.EQUIGROUCMPNYACRONYM_.isVisible || controls.EQUIGROUCMPNYNIF_____.isVisible">
														<q-control-wrapper
															v-show="controls.EQUIGROUCMPNYDESIGNAT.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.EQUIGROUCMPNYDESIGNAT"
																v-on="controls.EQUIGROUCMPNYDESIGNAT.handlers"
																:loading="controls.EQUIGROUCMPNYDESIGNAT.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-text-field
																	v-bind="controls.EQUIGROUCMPNYDESIGNAT.props"
																	:model-value="model.CmpnyValDesignat.value" />
															</base-input-structure>
														</q-control-wrapper>
														<q-control-wrapper
															v-show="controls.EQUIGROUCMPNYACRONYM_.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.EQUIGROUCMPNYACRONYM_"
																v-on="controls.EQUIGROUCMPNYACRONYM_.handlers"
																:loading="controls.EQUIGROUCMPNYACRONYM_.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-text-field
																	v-bind="controls.EQUIGROUCMPNYACRONYM_.props"
																	:model-value="model.CmpnyValAcronym.value" />
															</base-input-structure>
														</q-control-wrapper>
														<q-control-wrapper
															v-show="controls.EQUIGROUCMPNYNIF_____.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.EQUIGROUCMPNYNIF_____"
																v-on="controls.EQUIGROUCMPNYNIF_____.handlers"
																:loading="controls.EQUIGROUCMPNYNIF_____.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-text-field
																	v-bind="controls.EQUIGROUCMPNYNIF_____.props"
																	:model-value="model.CmpnyValNif.value" />
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<!-- End EQUIGROUPSEUDNEWGRP02 -->
												</q-group-box-container>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container
											v-show="controls.EQUIGROUPSEUDNEWGRP03.isVisible"
											is-large>
											<q-control-wrapper
												v-show="controls.EQUIGROUPSEUDNEWGRP03.isVisible"
												class="row-line-group">
												<q-group-box-container
													id="EQUIGROUPSEUDNEWGRP03"
													class="c-groupbox--background"
													v-bind="controls.EQUIGROUPSEUDNEWGRP03"
													:is-visible="controls.EQUIGROUPSEUDNEWGRP03.isVisible">
													<!-- Start EQUIGROUPSEUDNEWGRP03 -->
													<q-row-container v-show="controls.EQUIGROUCMPNYTELEPHON.isVisible || controls.EQUIGROUCMPNYEMAIL___.isVisible">
														<q-control-wrapper
															v-show="controls.EQUIGROUCMPNYTELEPHON.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.EQUIGROUCMPNYTELEPHON"
																v-on="controls.EQUIGROUCMPNYTELEPHON.handlers"
																:loading="controls.EQUIGROUCMPNYTELEPHON.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-text-field
																	v-bind="controls.EQUIGROUCMPNYTELEPHON.props"
																	:model-value="model.CmpnyValTelephon.value" />
															</base-input-structure>
														</q-control-wrapper>
														<q-control-wrapper
															v-show="controls.EQUIGROUCMPNYEMAIL___.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.EQUIGROUCMPNYEMAIL___"
																v-on="controls.EQUIGROUCMPNYEMAIL___.handlers"
																:loading="controls.EQUIGROUCMPNYEMAIL___.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-text-field
																	v-bind="controls.EQUIGROUCMPNYEMAIL___.props"
																	:model-value="model.CmpnyValEmail.value" />
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<!-- End EQUIGROUPSEUDNEWGRP03 -->
												</q-group-box-container>
											</q-control-wrapper>
										</q-row-container>
										<!-- End EQUIGROUPSEUDNEWGRP01 -->
									</q-group-box-container>
								</q-control-wrapper>
							</q-row-container>
							<!-- End EQUIGROUPSEUDNEWGRP18 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.EQUIGROUPSEUDNEWGRP21.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.EQUIGROUPSEUDNEWGRP21.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="EQUIGROUPSEUDNEWGRP21"
							v-bind="controls.EQUIGROUPSEUDNEWGRP21"
							:is-visible="controls.EQUIGROUPSEUDNEWGRP21.isVisible">
							<!-- Start EQUIGROUPSEUDNEWGRP21 -->
							<q-row-container
								v-show="controls.EQUIGROUPSEUDNEWGRP08.isVisible"
								is-large>
								<q-control-wrapper
									v-show="controls.EQUIGROUPSEUDNEWGRP08.isVisible"
									class="row-line-group">
									<q-group-collapsible
										id="EQUIGROUPSEUDNEWGRP08"
										class="q-group-collapsible--audit"
										v-bind="controls.EQUIGROUPSEUDNEWGRP08"
										v-on="controls.EQUIGROUPSEUDNEWGRP08.handlers">
										<!-- Start EQUIGROUPSEUDNEWGRP08 -->
										<q-row-container v-show="controls.EQUIGROUEQUIPQTDMOVIM.isVisible || controls.EQUIGROUEQUIPDTAQUISI.isVisible">
											<q-control-wrapper
												v-show="controls.EQUIGROUEQUIPQTDMOVIM.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.EQUIGROUEQUIPQTDMOVIM"
													v-on="controls.EQUIGROUEQUIPQTDMOVIM.handlers"
													:loading="controls.EQUIGROUEQUIPQTDMOVIM.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-numeric-input
														v-if="controls.EQUIGROUEQUIPQTDMOVIM.isVisible"
														v-bind="controls.EQUIGROUEQUIPQTDMOVIM.props"
														@update:model-value="model.ValQtdmovim.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.EQUIGROUEQUIPDTAQUISI.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.EQUIGROUEQUIPDTAQUISI"
													v-on="controls.EQUIGROUEQUIPDTAQUISI.handlers"
													:loading="controls.EQUIGROUEQUIPDTAQUISI.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-date-time-picker
														v-if="controls.EQUIGROUEQUIPDTAQUISI.isVisible"
														v-bind="controls.EQUIGROUEQUIPDTAQUISI.props"
														:model-value="model.ValDtaquisi.value"
														@reset-icon-click="model.ValDtaquisi.fnUpdateValue(model.ValDtaquisi.originalValue ?? new Date())"
														@update:model-value="model.ValDtaquisi.fnUpdateValue($event ?? '')" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<!-- End EQUIGROUPSEUDNEWGRP08 -->
									</q-group-collapsible>
								</q-control-wrapper>
							</q-row-container>
							<!-- End EQUIGROUPSEUDNEWGRP21 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.EQUIGROUPSEUDNEWGRP23.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.EQUIGROUPSEUDNEWGRP23.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="EQUIGROUPSEUDNEWGRP23"
							v-bind="controls.EQUIGROUPSEUDNEWGRP23"
							:is-visible="controls.EQUIGROUPSEUDNEWGRP23.isVisible">
							<!-- Start EQUIGROUPSEUDNEWGRP23 -->
							<q-row-container
								v-show="controls.EQUIGROUPSEUDNEWGRP09.isVisible"
								is-large>
								<q-control-wrapper
									v-show="controls.EQUIGROUPSEUDNEWGRP09.isVisible"
									class="row-line-group">
									<q-group-box-container
										id="EQUIGROUPSEUDNEWGRP09"
										class="c-groupbox--title-background"
										v-bind="controls.EQUIGROUPSEUDNEWGRP09"
										:is-visible="controls.EQUIGROUPSEUDNEWGRP09.isVisible">
										<!-- Start EQUIGROUPSEUDNEWGRP09 -->
										<q-row-container
											v-show="controls.EQUIGROUPSEUDNEWGRP10.isVisible"
											is-large>
											<q-control-wrapper
												v-show="controls.EQUIGROUPSEUDNEWGRP10.isVisible"
												class="row-line-group">
												<q-group-box-container
													id="EQUIGROUPSEUDNEWGRP10"
													class="c-groupbox--title-background"
													v-bind="controls.EQUIGROUPSEUDNEWGRP10"
													:is-visible="controls.EQUIGROUPSEUDNEWGRP10.isVisible">
													<!-- Start EQUIGROUPSEUDNEWGRP10 -->
													<q-row-container v-show="controls.EQUIGROUTPEQUTIPOEQUI.isVisible">
														<q-control-wrapper
															v-show="controls.EQUIGROUTPEQUTIPOEQUI.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.EQUIGROUTPEQUTIPOEQUI"
																v-on="controls.EQUIGROUTPEQUTIPOEQUI.handlers"
																:loading="controls.EQUIGROUTPEQUTIPOEQUI.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-lookup
																	v-if="controls.EQUIGROUTPEQUTIPOEQUI.isVisible"
																	v-bind="controls.EQUIGROUTPEQUTIPOEQUI.props"
																	v-on="controls.EQUIGROUTPEQUTIPOEQUI.handlers" />
																<q-see-more-equigroutpequtipoequi
																	v-if="controls.EQUIGROUTPEQUTIPOEQUI.seeMoreIsVisible"
																	v-bind="controls.EQUIGROUTPEQUTIPOEQUI.seeMoreParams"
																	v-on="controls.EQUIGROUTPEQUTIPOEQUI.handlers" />
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<q-row-container v-show="controls.EQUIGROUTPEQUTPEQUCOD.isVisible || controls.EQUIGROUTPEQUPRECOMAX.isVisible">
														<q-control-wrapper
															v-show="controls.EQUIGROUTPEQUTPEQUCOD.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.EQUIGROUTPEQUTPEQUCOD"
																v-on="controls.EQUIGROUTPEQUTPEQUCOD.handlers"
																:loading="controls.EQUIGROUTPEQUTPEQUCOD.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-text-field
																	v-bind="controls.EQUIGROUTPEQUTPEQUCOD.props"
																	:model-value="model.TpequValTpequcod.value" />
															</base-input-structure>
														</q-control-wrapper>
														<q-control-wrapper
															v-show="controls.EQUIGROUTPEQUPRECOMAX.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.EQUIGROUTPEQUPRECOMAX"
																v-on="controls.EQUIGROUTPEQUPRECOMAX.handlers"
																:loading="controls.EQUIGROUTPEQUPRECOMAX.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-numeric-input
																	v-if="controls.EQUIGROUTPEQUPRECOMAX.isVisible"
																	v-bind="controls.EQUIGROUTPEQUPRECOMAX.props"
																	@update:model-value="model.TpequValPrecomax.fnUpdateValue" />
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<q-row-container
														v-show="controls.EQUIGROUPSEUDNEWGRP11.isVisible"
														is-large>
														<q-control-wrapper
															v-show="controls.EQUIGROUPSEUDNEWGRP11.isVisible"
															class="row-line-group">
															<q-group-box-container
																id="EQUIGROUPSEUDNEWGRP11"
																v-bind="controls.EQUIGROUPSEUDNEWGRP11"
																:is-visible="controls.EQUIGROUPSEUDNEWGRP11.isVisible">
																<!-- Start EQUIGROUPSEUDNEWGRP11 -->
																<q-row-container v-show="controls.EQUIGROUTPEQUTPEQUPAI.isVisible || controls.EQUIGROUTPEQUNIVEL___.isVisible">
																	<q-control-wrapper
																		v-show="controls.EQUIGROUTPEQUTPEQUPAI.isVisible"
																		class="control-join-group">
																		<base-input-structure
																			class="i-text"
																			v-bind="controls.EQUIGROUTPEQUTPEQUPAI"
																			v-on="controls.EQUIGROUTPEQUTPEQUPAI.handlers"
																			:loading="controls.EQUIGROUTPEQUTPEQUPAI.props.loading"
																			:reporting-mode-on="reportingModeCAV"
																			:suggestion-mode-on="suggestionModeOn">
																			<q-text-field
																				v-bind="controls.EQUIGROUTPEQUTPEQUPAI.props"
																				:model-value="model.TpequValTpequpai.value" />
																		</base-input-structure>
																	</q-control-wrapper>
																	<q-control-wrapper
																		v-show="controls.EQUIGROUTPEQUNIVEL___.isVisible"
																		class="control-join-group">
																		<base-input-structure
																			class="i-text"
																			v-bind="controls.EQUIGROUTPEQUNIVEL___"
																			v-on="controls.EQUIGROUTPEQUNIVEL___.handlers"
																			:loading="controls.EQUIGROUTPEQUNIVEL___.props.loading"
																			:reporting-mode-on="reportingModeCAV"
																			:suggestion-mode-on="suggestionModeOn">
																			<q-numeric-input
																				v-if="controls.EQUIGROUTPEQUNIVEL___.isVisible"
																				v-bind="controls.EQUIGROUTPEQUNIVEL___.props"
																				@update:model-value="model.TpequValNivel.fnUpdateValue" />
																		</base-input-structure>
																	</q-control-wrapper>
																</q-row-container>
																<q-row-container
																	v-show="controls.EQUIGROUPSEUDNEWGRP12.isVisible"
																	is-large>
																	<q-control-wrapper
																		v-show="controls.EQUIGROUPSEUDNEWGRP12.isVisible"
																		class="row-line-group">
																		<q-group-box-container
																			id="EQUIGROUPSEUDNEWGRP12"
																			v-bind="controls.EQUIGROUPSEUDNEWGRP12"
																			:is-visible="controls.EQUIGROUPSEUDNEWGRP12.isVisible">
																			<!-- Start EQUIGROUPSEUDNEWGRP12 -->
																			<q-row-container v-show="controls.EQUIGROUTPEQUBACKCOLO.isVisible || controls.EQUIGROUTPEQUCORLETRA.isVisible">
																				<q-control-wrapper
																					v-show="controls.EQUIGROUTPEQUBACKCOLO.isVisible"
																					class="control-join-group">
																					<base-input-structure
																						class="i-text"
																						v-bind="controls.EQUIGROUTPEQUBACKCOLO"
																						v-on="controls.EQUIGROUTPEQUBACKCOLO.handlers"
																						:loading="controls.EQUIGROUTPEQUBACKCOLO.props.loading"
																						:reporting-mode-on="reportingModeCAV"
																						:suggestion-mode-on="suggestionModeOn">
																						<q-text-field
																							v-bind="controls.EQUIGROUTPEQUBACKCOLO.props"
																							:model-value="model.TpequValBackcolo.value" />
																					</base-input-structure>
																				</q-control-wrapper>
																				<q-control-wrapper
																					v-show="controls.EQUIGROUTPEQUCORLETRA.isVisible"
																					class="control-join-group">
																					<base-input-structure
																						class="i-text"
																						v-bind="controls.EQUIGROUTPEQUCORLETRA"
																						v-on="controls.EQUIGROUTPEQUCORLETRA.handlers"
																						:loading="controls.EQUIGROUTPEQUCORLETRA.props.loading"
																						:reporting-mode-on="reportingModeCAV"
																						:suggestion-mode-on="suggestionModeOn">
																						<q-text-field
																							v-bind="controls.EQUIGROUTPEQUCORLETRA.props"
																							:model-value="model.TpequValCorletra.value" />
																					</base-input-structure>
																				</q-control-wrapper>
																			</q-row-container>
																			<!-- End EQUIGROUPSEUDNEWGRP12 -->
																		</q-group-box-container>
																	</q-control-wrapper>
																</q-row-container>
																<!-- End EQUIGROUPSEUDNEWGRP11 -->
															</q-group-box-container>
														</q-control-wrapper>
													</q-row-container>
													<!-- End EQUIGROUPSEUDNEWGRP10 -->
												</q-group-box-container>
											</q-control-wrapper>
										</q-row-container>
										<!-- End EQUIGROUPSEUDNEWGRP09 -->
									</q-group-box-container>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container
								v-show="controls.EQUIGROUPSEUDNEWGRP07.isVisible"
								is-large>
								<q-control-wrapper
									v-show="controls.EQUIGROUPSEUDNEWGRP07.isVisible"
									class="row-line-group">
									<q-group-box-container
										id="EQUIGROUPSEUDNEWGRP07"
										class="c-groupbox--minor"
										v-bind="controls.EQUIGROUPSEUDNEWGRP07"
										:is-visible="controls.EQUIGROUPSEUDNEWGRP07.isVisible">
										<!-- Start EQUIGROUPSEUDNEWGRP07 -->
										<q-row-container v-show="controls.EQUIGROUEQUIPSEQUENNR.isVisible || controls.EQUIGROUEQUIPREGISTNR.isVisible || controls.EQUIGROUEQUIPVALORTOT.isVisible">
											<q-control-wrapper
												v-show="controls.EQUIGROUEQUIPSEQUENNR.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.EQUIGROUEQUIPSEQUENNR"
													v-on="controls.EQUIGROUEQUIPSEQUENNR.handlers"
													:loading="controls.EQUIGROUEQUIPSEQUENNR.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-numeric-input
														v-if="controls.EQUIGROUEQUIPSEQUENNR.isVisible"
														v-bind="controls.EQUIGROUEQUIPSEQUENNR.props"
														@update:model-value="model.ValSequennr.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.EQUIGROUEQUIPREGISTNR.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.EQUIGROUEQUIPREGISTNR"
													v-on="controls.EQUIGROUEQUIPREGISTNR.handlers"
													:loading="controls.EQUIGROUEQUIPREGISTNR.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-field
														v-bind="controls.EQUIGROUEQUIPREGISTNR.props"
														:model-value="model.ValRegistnr.value" />
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.EQUIGROUEQUIPVALORTOT.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.EQUIGROUEQUIPVALORTOT"
													v-on="controls.EQUIGROUEQUIPVALORTOT.handlers"
													:loading="controls.EQUIGROUEQUIPVALORTOT.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-numeric-input
														v-if="controls.EQUIGROUEQUIPVALORTOT.isVisible"
														v-bind="controls.EQUIGROUEQUIPVALORTOT.props"
														@update:model-value="model.ValValortot.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container
											v-show="controls.EQUIGROUPSEUDNEWGRP05.isVisible"
											is-large>
											<q-control-wrapper
												v-show="controls.EQUIGROUPSEUDNEWGRP05.isVisible"
												class="row-line-group">
												<q-group-box-container
													id="EQUIGROUPSEUDNEWGRP05"
													class="c-groupbox--minor"
													v-bind="controls.EQUIGROUPSEUDNEWGRP05"
													:is-visible="controls.EQUIGROUPSEUDNEWGRP05.isVisible">
													<!-- Start EQUIGROUPSEUDNEWGRP05 -->
													<q-row-container v-show="controls.EQUIGROUEQUIPFREQUENC.isVisible || controls.EQUIGROUEQUIPBOUGHT__.isVisible || controls.EQUIGROUEQUIPDTREFERE.isVisible || controls.EQUIGROUEQUIPFIRST___.isVisible">
														<q-control-wrapper
															v-show="controls.EQUIGROUEQUIPFREQUENC.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.EQUIGROUEQUIPFREQUENC"
																v-on="controls.EQUIGROUEQUIPFREQUENC.handlers"
																:loading="controls.EQUIGROUEQUIPFREQUENC.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-select
																	v-if="controls.EQUIGROUEQUIPFREQUENC.isVisible"
																	v-bind="controls.EQUIGROUEQUIPFREQUENC.props"
																	:model-value="model.ValFrequenc.value"
																	@update:model-value="model.ValFrequenc.fnUpdateValue" />
															</base-input-structure>
														</q-control-wrapper>
														<q-control-wrapper
															v-show="controls.EQUIGROUEQUIPBOUGHT__.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-checkbox"
																v-bind="controls.EQUIGROUEQUIPBOUGHT__"
																v-on="controls.EQUIGROUEQUIPBOUGHT__.handlers"
																:loading="controls.EQUIGROUEQUIPBOUGHT__.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<template #label>
																	<q-checkbox-input
																		v-if="controls.EQUIGROUEQUIPBOUGHT__.isVisible"
																		v-bind="controls.EQUIGROUEQUIPBOUGHT__.props"
																		@update:model-value="model.ValBought.fnUpdateValue" />
																</template>
															</base-input-structure>
														</q-control-wrapper>
														<q-control-wrapper
															v-show="controls.EQUIGROUEQUIPDTREFERE.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.EQUIGROUEQUIPDTREFERE"
																v-on="controls.EQUIGROUEQUIPDTREFERE.handlers"
																:loading="controls.EQUIGROUEQUIPDTREFERE.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-date-time-picker
																	v-if="controls.EQUIGROUEQUIPDTREFERE.isVisible"
																	v-bind="controls.EQUIGROUEQUIPDTREFERE.props"
																	:model-value="model.ValDtrefere.value"
																	@reset-icon-click="model.ValDtrefere.fnUpdateValue(model.ValDtrefere.originalValue ?? new Date())"
																	@update:model-value="model.ValDtrefere.fnUpdateValue($event ?? '')" />
															</base-input-structure>
														</q-control-wrapper>
														<q-control-wrapper
															v-show="controls.EQUIGROUEQUIPFIRST___.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.EQUIGROUEQUIPFIRST___"
																v-on="controls.EQUIGROUEQUIPFIRST___.handlers"
																:loading="controls.EQUIGROUEQUIPFIRST___.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-text-field
																	v-bind="controls.EQUIGROUEQUIPFIRST___.props"
																	:model-value="model.ValFirst.value" />
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<!-- End EQUIGROUPSEUDNEWGRP05 -->
												</q-group-box-container>
											</q-control-wrapper>
										</q-row-container>
										<!-- End EQUIGROUPSEUDNEWGRP07 -->
									</q-group-box-container>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container
								v-show="controls.EQUIGROUPSEUDNEWGRP04.isVisible"
								is-large>
								<q-control-wrapper
									v-show="controls.EQUIGROUPSEUDNEWGRP04.isVisible"
									class="row-line-group">
									<q-group-box-container
										id="EQUIGROUPSEUDNEWGRP04"
										class="c-groupbox--minor-border-top"
										v-bind="controls.EQUIGROUPSEUDNEWGRP04"
										:is-visible="controls.EQUIGROUPSEUDNEWGRP04.isVisible">
										<!-- Start EQUIGROUPSEUDNEWGRP04 -->
										<q-row-container v-show="controls.EQUIGROUEQUIPPHOTOGRA.isVisible">
											<q-control-wrapper
												v-show="controls.EQUIGROUEQUIPPHOTOGRA.isVisible"
												class="control-join-group">
												<base-input-structure
													class="q-image"
													v-bind="controls.EQUIGROUEQUIPPHOTOGRA"
													v-on="controls.EQUIGROUEQUIPPHOTOGRA.handlers"
													:loading="controls.EQUIGROUEQUIPPHOTOGRA.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-image
														v-if="controls.EQUIGROUEQUIPPHOTOGRA.isVisible"
														v-bind="controls.EQUIGROUEQUIPPHOTOGRA.props"
														v-on="controls.EQUIGROUEQUIPPHOTOGRA.handlers" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container
											v-show="controls.EQUIGROUPSEUDNEWGRP06.isVisible"
											is-large>
											<q-control-wrapper
												v-show="controls.EQUIGROUPSEUDNEWGRP06.isVisible"
												class="row-line-group">
												<q-group-box-container
													id="EQUIGROUPSEUDNEWGRP06"
													class="c-groupbox--minor-border-top"
													v-bind="controls.EQUIGROUPSEUDNEWGRP06"
													:is-visible="controls.EQUIGROUPSEUDNEWGRP06.isVisible">
													<!-- Start EQUIGROUPSEUDNEWGRP06 -->
													<q-row-container v-show="controls.EQUIGROUEQUIPDESIGNAT.isVisible">
														<q-control-wrapper
															v-show="controls.EQUIGROUEQUIPDESIGNAT.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.EQUIGROUEQUIPDESIGNAT"
																v-on="controls.EQUIGROUEQUIPDESIGNAT.handlers"
																:loading="controls.EQUIGROUEQUIPDESIGNAT.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn">
																<q-text-field
																	v-bind="controls.EQUIGROUEQUIPDESIGNAT.props"
																	:model-value="model.ValDesignat.value"
																	@blur="onBlur(controls.EQUIGROUEQUIPDESIGNAT, model.ValDesignat.value)"
																	@change="model.ValDesignat.fnUpdateValueOnChange" />
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<!-- End EQUIGROUPSEUDNEWGRP06 -->
												</q-group-box-container>
											</q-control-wrapper>
										</q-row-container>
										<!-- End EQUIGROUPSEUDNEWGRP04 -->
									</q-group-box-container>
								</q-control-wrapper>
							</q-row-container>
							<!-- End EQUIGROUPSEUDNEWGRP23 -->
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

	import FormViewModel from './QFormEquigrouViewModel.js'

	const requiredTextResources = ['QFormEquigrou', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS EQUIGROU]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormEquigrou',

		components: {
			QSeeMoreEquigroupess1name: defineAsyncComponent(() => import('@/views/forms/FormEquigrou/dbedits/Equigroupess1nameSeeMore.vue')),
			QSeeMoreEquigroutpequtipoequi: defineAsyncComponent(() => import('@/views/forms/FormEquigrou/dbedits/EquigroutpequtipoequiSeeMore.vue')),
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
					name: 'EQUIGROU',
					location: 'form-EQUIGROU',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormEquigrou', false),

				interfaceMetadata: {
					id: 'QFormEquigrou', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'EQUIGROU',
					route: 'form-EQUIGROU',
					area: 'EQUIP',
					primaryKey: 'ValCodequip',
					designation: computed(() => this.Resources.EQUIPMENT03632),
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
					EQUIGROUPSEUDNEWGRP19: new fieldControlClass.GroupControl({
						id: 'EQUIGROUPSEUDNEWGRP19',
						name: 'NEWGRP19',
						size: 'block',
						label: computed(() => this.Resources.DEFAULT_STYLE62523),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: true,
						directChildren: ['EQUIGROUPSEUDNEWGRP13'],
						controlLimits: [
						],
					}, this),
					EQUIGROUPSEUDNEWGRP13: new fieldControlClass.GroupControl({
						id: 'EQUIGROUPSEUDNEWGRP13',
						name: 'NEWGRP13',
						size: 'block',
						label: computed(() => this.Resources.OWNER09558),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP19',
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIGROUPESS1PHOTOGRA', 'EQUIGROUPESS1NAME____', 'EQUIGROUPESS1GENDER__', 'EQUIGROUPSEUDNEWGRP14', 'EQUIGROUPSEUDNEWGRP17'],
						controlLimits: [
						],
					}, this),
					EQUIGROUPESS1PHOTOGRA: new fieldControlClass.ImageControl({
						modelField: 'Pess1ValPhotogra',
						valueChangeEvent: 'fieldChange:pess1.photogra',
						dependentModelField: 'ValCodpess1',
						dependentChangeEvent: 'fieldChange:equip.codpess1',
						id: 'EQUIGROUPESS1PHOTOGRA',
						name: 'PHOTOGRA',
						size: 'mini',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP13',
						height: 50,
						width: 30,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO51874)),
						maxFileSize: 10485760, // In bytes.
						maxFileSizeLabel: '10 MB',
						controlLimits: [
						],
					}, this),
					EQUIGROUPESS1NAME____: new fieldControlClass.LookupControl({
						modelField: 'TablePess1Name',
						valueChangeEvent: 'fieldChange:pess1.name',
						id: 'EQUIGROUPESS1NAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.NAME31974),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP13',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodpess1',
							dependencyEvent: 'fieldChange:equip.codpess1'
						},
						dependentFields: () => ({
							set 'pess1.codpesso'(value) { vm.model.ValCodpess1.updateValue(value) },
							set 'pess1.name'(value) { vm.model.TablePess1Name.updateValue(value) },
							set 'pess1.photogra'(value) { vm.model.Pess1ValPhotogra.updateValue(value) },
							set 'pess1.gender'(value) { vm.model.Pess1ValGender.updateValue(value) },
							set 'pess1.dtnascim'(value) { vm.model.Pess1ValDtnascim.updateValue(value) },
							set 'pess1.idade'(value) { vm.model.Pess1ValIdade.updateValue(value) },
							set 'pess1.idfuncio'(value) { vm.model.Pess1ValIdfuncio.updateValue(value) },
							set 'pess1.telephon'(value) { vm.model.Pess1ValTelephon.updateValue(value) },
							set 'pess1.email'(value) { vm.model.Pess1ValEmail.updateValue(value) },
							set 'pess1.email2'(value) { vm.model.Pess1ValEmail2.updateValue(value) },
							set 'equip.codempre'(value) { vm.model.ValCodempre.updateValue(value) },
							set 'cmpny.codempre'(value) { vm.model.ValCodempre.updateValue(value) },
							set 'cmpny.logo'(value) { vm.model.CmpnyValLogo.updateValue(value) },
							set 'cmpny.designat'(value) { vm.model.CmpnyValDesignat.updateValue(value) },
							set 'cmpny.acronym'(value) { vm.model.CmpnyValAcronym.updateValue(value) },
							set 'cmpny.nif'(value) { vm.model.CmpnyValNif.updateValue(value) },
							set 'cmpny.telephon'(value) { vm.model.CmpnyValTelephon.updateValue(value) },
							set 'cmpny.email'(value) { vm.model.CmpnyValEmail.updateValue(value) },
						}),
						controlLimits: [
							{
								identifier: ['cmpny', 'equip.codempre'],
								dependencyEvents: ['fieldChange:equip.codempre'],
								dependencyField: 'EQUIP.CODEMPRE',
								fnValueSelector: (model) => model.ValCodempre.value
							},
						],
					}, this),
					EQUIGROUPESS1GENDER__: new fieldControlClass.ArrayStringControl({
						modelField: 'Pess1ValGender',
						valueChangeEvent: 'fieldChange:pess1.gender',
						dependentModelField: 'ValCodpess1',
						dependentChangeEvent: 'fieldChange:equip.codpess1',
						id: 'EQUIGROUPESS1GENDER__',
						name: 'GENDER',
						size: 'mini',
						label: computed(() => this.Resources.GENRE63303),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP13',
						maxLength: 1,
						labelId: 'label_EQUIGROUPESS1GENDER__',
						arrayName: 'Genero',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					EQUIGROUPSEUDNEWGRP14: new fieldControlClass.GroupControl({
						id: 'EQUIGROUPSEUDNEWGRP14',
						name: 'NEWGRP14',
						size: 'block',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP13',
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIGROUPESS1DTNASCIM', 'EQUIGROUPESS1IDADE___'],
						controlLimits: [
						],
					}, this),
					EQUIGROUPESS1DTNASCIM: new fieldControlClass.DateControl({
						modelField: 'Pess1ValDtnascim',
						valueChangeEvent: 'fieldChange:pess1.dtnascim',
						dependentModelField: 'ValCodpess1',
						dependentChangeEvent: 'fieldChange:equip.codpess1',
						id: 'EQUIGROUPESS1DTNASCIM',
						name: 'DTNASCIM',
						size: 'small',
						label: computed(() => this.Resources.BIRTH21799),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP14',
						format: 'date',
						controlLimits: [
						],
					}, this),
					EQUIGROUPESS1IDADE___: new fieldControlClass.NumberControl({
						modelField: 'Pess1ValIdade',
						valueChangeEvent: 'fieldChange:pess1.idade',
						dependentModelField: 'ValCodpess1',
						dependentChangeEvent: 'fieldChange:equip.codpess1',
						id: 'EQUIGROUPESS1IDADE___',
						name: 'IDADE',
						size: 'mini',
						label: computed(() => this.Resources.AGE28663),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP14',
						maxIntegers: 5,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					EQUIGROUPSEUDNEWGRP17: new fieldControlClass.AccordionControl({
						id: 'EQUIGROUPSEUDNEWGRP17',
						name: 'NEWGRP17',
						size: 'block',
						label: computed(() => this.Resources.NEW_GROUP63448),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP13',
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIGROUPSEUDNEWGRP15', 'EQUIGROUPSEUDNEWGRP16'],
						controlLimits: [
						],
					}, this),
					EQUIGROUPSEUDNEWGRP15: new fieldControlClass.GroupControl({
						id: 'EQUIGROUPSEUDNEWGRP15',
						name: 'NEWGRP15',
						size: 'block',
						label: computed(() => this.Resources.GROUP_IN_ACCORDIAN_159511),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP17',
						isCollapsible: true,
						anchored: false,
						directChildren: ['EQUIGROUPESS1IDFUNCIO', 'EQUIGROUPESS1TELEPHON'],
						isInAccordion: true,
						controlLimits: [
						],
					}, this),
					EQUIGROUPESS1IDFUNCIO: new fieldControlClass.NumberControl({
						modelField: 'Pess1ValIdfuncio',
						valueChangeEvent: 'fieldChange:pess1.idfuncio',
						dependentModelField: 'ValCodpess1',
						dependentChangeEvent: 'fieldChange:equip.codpess1',
						id: 'EQUIGROUPESS1IDFUNCIO',
						name: 'IDFUNCIO',
						size: 'medium',
						label: computed(() => this.Resources.OFFICIAL_NO_34819),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP15',
						maxIntegers: 6,
						maxDecimals: 0,
						isSequencial: true,
						controlLimits: [
						],
					}, this),
					EQUIGROUPESS1TELEPHON: new fieldControlClass.StringControl({
						modelField: 'Pess1ValTelephon',
						valueChangeEvent: 'fieldChange:pess1.telephon',
						dependentModelField: 'ValCodpess1',
						dependentChangeEvent: 'fieldChange:equip.codpess1',
						id: 'EQUIGROUPESS1TELEPHON',
						name: 'TELEPHON',
						size: 'large',
						label: computed(() => this.Resources.PHONE56703),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP15',
						maxLength: 20,
						labelId: 'label_EQUIGROUPESS1TELEPHON',
						controlLimits: [
						],
					}, this),
					EQUIGROUPSEUDNEWGRP16: new fieldControlClass.GroupControl({
						id: 'EQUIGROUPSEUDNEWGRP16',
						name: 'NEWGRP16',
						size: 'block',
						label: computed(() => this.Resources.GROUP_IN_ACCORDIAN_230968),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP17',
						isCollapsible: true,
						anchored: false,
						directChildren: ['EQUIGROUPESS1EMAIL___', 'EQUIGROUPESS1EMAIL2__'],
						isInAccordion: true,
						controlLimits: [
						],
					}, this),
					EQUIGROUPESS1EMAIL___: new fieldControlClass.StringControl({
						modelField: 'Pess1ValEmail',
						valueChangeEvent: 'fieldChange:pess1.email',
						dependentModelField: 'ValCodpess1',
						dependentChangeEvent: 'fieldChange:equip.codpess1',
						id: 'EQUIGROUPESS1EMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						label: computed(() => this.Resources.EMAIL_106184),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP16',
						maxLength: 254,
						labelId: 'label_EQUIGROUPESS1EMAIL___',
						controlLimits: [
						],
					}, this),
					EQUIGROUPESS1EMAIL2__: new fieldControlClass.StringControl({
						modelField: 'Pess1ValEmail2',
						valueChangeEvent: 'fieldChange:pess1.email2',
						dependentModelField: 'ValCodpess1',
						dependentChangeEvent: 'fieldChange:equip.codpess1',
						id: 'EQUIGROUPESS1EMAIL2__',
						name: 'EMAIL2',
						size: 'xxlarge',
						label: computed(() => this.Resources.EMAIL_211233),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP16',
						maxLength: 254,
						labelId: 'label_EQUIGROUPESS1EMAIL2__',
						controlLimits: [
						],
					}, this),
					EQUIGROUPSEUDNEWGRP18: new fieldControlClass.GroupControl({
						id: 'EQUIGROUPSEUDNEWGRP18',
						name: 'NEWGRP18',
						size: 'block',
						label: computed(() => this.Resources.MIXED_STYLE48721),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: true,
						directChildren: ['EQUIGROUPSEUDFIELD001', 'EQUIGROUPSEUDNEWGRP01'],
						controlLimits: [
						],
					}, this),
					EQUIGROUPSEUDFIELD001: new fieldControlClass.BaseControl({
						id: 'EQUIGROUPSEUDFIELD001',
						name: 'FIELD001',
						size: 'xlarge',
						hasLabel: false,
						label: computed(() => this.Resources.AT_MIXED_ZONES34969),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP18',
						supportsHtml: true,
						controlLimits: [
						],
					}, this),
					EQUIGROUPSEUDNEWGRP01: new fieldControlClass.GroupControl({
						id: 'EQUIGROUPSEUDNEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: computed(() => this.Resources.COMPANY52963),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP18',
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIGROUPSEUDNEWGRP02', 'EQUIGROUPSEUDNEWGRP03'],
						controlLimits: [
						],
					}, this),
					EQUIGROUPSEUDNEWGRP02: new fieldControlClass.GroupControl({
						id: 'EQUIGROUPSEUDNEWGRP02',
						name: 'NEWGRP02',
						size: 'block',
						label: computed(() => this.Resources.IDENTIFICATION37731),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP01',
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIGROUCMPNYLOGO____', 'EQUIGROUCMPNYDESIGNAT', 'EQUIGROUCMPNYACRONYM_', 'EQUIGROUCMPNYNIF_____'],
						controlLimits: [
						],
					}, this),
					EQUIGROUCMPNYLOGO____: new fieldControlClass.ImageControl({
						modelField: 'CmpnyValLogo',
						valueChangeEvent: 'fieldChange:cmpny.logo',
						dependentModelField: 'ValCodempre',
						dependentChangeEvent: 'fieldChange:equip.codempre',
						id: 'EQUIGROUCMPNYLOGO____',
						name: 'LOGO',
						size: 'mini',
						label: computed(() => this.Resources.LOGO62483),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP02',
						height: 50,
						width: 30,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.LOGO62483)),
						maxFileSize: 10485760, // In bytes.
						maxFileSizeLabel: '10 MB',
						controlLimits: [
						],
					}, this),
					EQUIGROUCMPNYDESIGNAT: new fieldControlClass.StringControl({
						modelField: 'CmpnyValDesignat',
						valueChangeEvent: 'fieldChange:cmpny.designat',
						dependentModelField: 'ValCodempre',
						dependentChangeEvent: 'fieldChange:equip.codempre',
						id: 'EQUIGROUCMPNYDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESIGNATION35876),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP02',
						maxLength: 85,
						labelId: 'label_EQUIGROUCMPNYDESIGNAT',
						controlLimits: [
						],
					}, this),
					EQUIGROUCMPNYACRONYM_: new fieldControlClass.StringControl({
						modelField: 'CmpnyValAcronym',
						valueChangeEvent: 'fieldChange:cmpny.acronym',
						dependentModelField: 'ValCodempre',
						dependentChangeEvent: 'fieldChange:equip.codempre',
						id: 'EQUIGROUCMPNYACRONYM_',
						name: 'ACRONYM',
						size: 'medium',
						label: computed(() => this.Resources.ACRONYM00872),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP02',
						maxLength: 15,
						labelId: 'label_EQUIGROUCMPNYACRONYM_',
						controlLimits: [
						],
					}, this),
					EQUIGROUCMPNYNIF_____: new fieldControlClass.StringControl({
						modelField: 'CmpnyValNif',
						valueChangeEvent: 'fieldChange:cmpny.nif',
						dependentModelField: 'ValCodempre',
						dependentChangeEvent: 'fieldChange:equip.codempre',
						id: 'EQUIGROUCMPNYNIF_____',
						name: 'NIF',
						size: 'medium',
						label: computed(() => this.Resources.TAX_IDENTIFICATION51190),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP02',
						maxLength: 15,
						labelId: 'label_EQUIGROUCMPNYNIF_____',
						controlLimits: [
						],
					}, this),
					EQUIGROUPSEUDNEWGRP03: new fieldControlClass.GroupControl({
						id: 'EQUIGROUPSEUDNEWGRP03',
						name: 'NEWGRP03',
						size: 'block',
						label: computed(() => this.Resources.CONTACTS55742),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP01',
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIGROUCMPNYTELEPHON', 'EQUIGROUCMPNYEMAIL___'],
						controlLimits: [
						],
					}, this),
					EQUIGROUCMPNYTELEPHON: new fieldControlClass.StringControl({
						modelField: 'CmpnyValTelephon',
						valueChangeEvent: 'fieldChange:cmpny.telephon',
						dependentModelField: 'ValCodempre',
						dependentChangeEvent: 'fieldChange:equip.codempre',
						id: 'EQUIGROUCMPNYTELEPHON',
						name: 'TELEPHON',
						size: 'large',
						label: computed(() => this.Resources.PHONE56703),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP03',
						maxLength: 20,
						labelId: 'label_EQUIGROUCMPNYTELEPHON',
						controlLimits: [
						],
					}, this),
					EQUIGROUCMPNYEMAIL___: new fieldControlClass.StringControl({
						modelField: 'CmpnyValEmail',
						valueChangeEvent: 'fieldChange:cmpny.email',
						dependentModelField: 'ValCodempre',
						dependentChangeEvent: 'fieldChange:equip.codempre',
						id: 'EQUIGROUCMPNYEMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						label: computed(() => this.Resources.EMAIL25170),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP03',
						maxLength: 254,
						labelId: 'label_EQUIGROUCMPNYEMAIL___',
						controlLimits: [
						],
					}, this),
					EQUIGROUPSEUDNEWGRP21: new fieldControlClass.GroupControl({
						id: 'EQUIGROUPSEUDNEWGRP21',
						name: 'NEWGRP21',
						size: 'block',
						label: computed(() => this.Resources.COLLAPSIBLE_STYLE24579),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: true,
						directChildren: ['EQUIGROUPSEUDNEWGRP08'],
						controlLimits: [
						],
					}, this),
					EQUIGROUPSEUDNEWGRP08: new fieldControlClass.GroupControl({
						id: 'EQUIGROUPSEUDNEWGRP08',
						name: 'NEWGRP08',
						size: 'block',
						label: computed(() => this.Resources.AUDIT43231),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP21',
						isCollapsible: true,
						anchored: false,
						directChildren: ['EQUIGROUEQUIPQTDMOVIM', 'EQUIGROUEQUIPDTAQUISI'],
						controlLimits: [
						],
					}, this),
					EQUIGROUEQUIPQTDMOVIM: new fieldControlClass.NumberControl({
						modelField: 'ValQtdmovim',
						valueChangeEvent: 'fieldChange:equip.qtdmovim',
						id: 'EQUIGROUEQUIPQTDMOVIM',
						name: 'QTDMOVIM',
						size: 'large',
						label: computed(() => this.Resources.CHANGES_NUMBER59897),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.left),
						container: 'EQUIGROUPSEUDNEWGRP08',
						isFormulaBlocked: true,
						maxIntegers: 10,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					EQUIGROUEQUIPDTAQUISI: new fieldControlClass.DateControl({
						modelField: 'ValDtaquisi',
						valueChangeEvent: 'fieldChange:equip.dtaquisi',
						id: 'EQUIGROUEQUIPDTAQUISI',
						name: 'DTAQUISI',
						size: 'small',
						label: computed(() => this.Resources.ACQUISITION44180),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.left),
						container: 'EQUIGROUPSEUDNEWGRP08',
						format: 'date',
						controlLimits: [
						],
					}, this),
					EQUIGROUPSEUDNEWGRP23: new fieldControlClass.GroupControl({
						id: 'EQUIGROUPSEUDNEWGRP23',
						name: 'NEWGRP23',
						size: 'block',
						label: computed(() => this.Resources.GROUPBOX_STYLES47434),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: true,
						directChildren: ['EQUIGROUPSEUDNEWGRP09', 'EQUIGROUPSEUDNEWGRP07', 'EQUIGROUPSEUDNEWGRP04'],
						controlLimits: [
						],
					}, this),
					EQUIGROUPSEUDNEWGRP09: new fieldControlClass.GroupControl({
						id: 'EQUIGROUPSEUDNEWGRP09',
						name: 'NEWGRP09',
						size: 'block',
						label: computed(() => this.Resources._1__C_GROUPBOX__TITL45813),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP23',
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIGROUPSEUDNEWGRP10'],
						controlLimits: [
						],
					}, this),
					EQUIGROUPSEUDNEWGRP10: new fieldControlClass.GroupControl({
						id: 'EQUIGROUPSEUDNEWGRP10',
						name: 'NEWGRP10',
						size: 'block',
						label: computed(() => this.Resources.IT_IS_NEST_WITHIN_TH37713),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP09',
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIGROUTPEQUTIPOEQUI', 'EQUIGROUTPEQUTPEQUCOD', 'EQUIGROUTPEQUPRECOMAX', 'EQUIGROUPSEUDNEWGRP11'],
						controlLimits: [
						],
					}, this),
					EQUIGROUTPEQUTIPOEQUI: new fieldControlClass.LookupControl({
						modelField: 'TableTpequTipoequi',
						valueChangeEvent: 'fieldChange:tpequ.tipoequi',
						id: 'EQUIGROUTPEQUTIPOEQUI',
						name: 'TIPOEQUI',
						size: 'xxlarge',
						label: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP10',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodtpequ',
							dependencyEvent: 'fieldChange:equip.codtpequ'
						},
						dependentFields: () => ({
							set 'tpequ.codtpequ'(value) { vm.model.ValCodtpequ.updateValue(value) },
							set 'tpequ.tipoequi'(value) { vm.model.TableTpequTipoequi.updateValue(value) },
							set 'tpequ.tpequcod'(value) { vm.model.TpequValTpequcod.updateValue(value) },
							set 'tpequ.precomax'(value) { vm.model.TpequValPrecomax.updateValue(value) },
							set 'tpequ.tpequpai'(value) { vm.model.TpequValTpequpai.updateValue(value) },
							set 'tpequ.nivel'(value) { vm.model.TpequValNivel.updateValue(value) },
							set 'tpequ.backcolo'(value) { vm.model.TpequValBackcolo.updateValue(value) },
							set 'tpequ.corletra'(value) { vm.model.TpequValCorletra.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					EQUIGROUTPEQUTPEQUCOD: new fieldControlClass.StringControl({
						modelField: 'TpequValTpequcod',
						valueChangeEvent: 'fieldChange:tpequ.tpequcod',
						dependentModelField: 'ValCodtpequ',
						dependentChangeEvent: 'fieldChange:equip.codtpequ',
						id: 'EQUIGROUTPEQUTPEQUCOD',
						name: 'TPEQUCOD',
						size: 'large',
						label: computed(() => this.Resources.CODE49225),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP10',
						maxLength: 20,
						labelId: 'label_EQUIGROUTPEQUTPEQUCOD',
						controlLimits: [
						],
					}, this),
					EQUIGROUTPEQUPRECOMAX: new fieldControlClass.CurrencyControl({
						modelField: 'TpequValPrecomax',
						valueChangeEvent: 'fieldChange:tpequ.precomax',
						dependentModelField: 'ValCodtpequ',
						dependentChangeEvent: 'fieldChange:equip.codtpequ',
						id: 'EQUIGROUTPEQUPRECOMAX',
						name: 'PRECOMAX',
						size: 'medium',
						label: computed(() => this.Resources.MAXIMUM_PRICE55489),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP10',
						maxIntegers: 9,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					EQUIGROUPSEUDNEWGRP11: new fieldControlClass.GroupControl({
						id: 'EQUIGROUPSEUDNEWGRP11',
						name: 'NEWGRP11',
						size: 'block',
						label: computed(() => this.Resources.IT_IS_NEST_WITHIN_TH02373),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP10',
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIGROUTPEQUTPEQUPAI', 'EQUIGROUTPEQUNIVEL___', 'EQUIGROUPSEUDNEWGRP12'],
						controlLimits: [
						],
					}, this),
					EQUIGROUTPEQUTPEQUPAI: new fieldControlClass.StringControl({
						modelField: 'TpequValTpequpai',
						valueChangeEvent: 'fieldChange:tpequ.tpequpai',
						dependentModelField: 'ValCodtpequ',
						dependentChangeEvent: 'fieldChange:equip.codtpequ',
						id: 'EQUIGROUTPEQUTPEQUPAI',
						name: 'TPEQUPAI',
						size: 'large',
						label: computed(() => this.Resources.DEPENDENT_ON28321),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP11',
						maxLength: 20,
						labelId: 'label_EQUIGROUTPEQUTPEQUPAI',
						controlLimits: [
						],
					}, this),
					EQUIGROUTPEQUNIVEL___: new fieldControlClass.NumberControl({
						modelField: 'TpequValNivel',
						valueChangeEvent: 'fieldChange:tpequ.nivel',
						dependentModelField: 'ValCodtpequ',
						dependentChangeEvent: 'fieldChange:equip.codtpequ',
						id: 'EQUIGROUTPEQUNIVEL___',
						name: 'NIVEL',
						size: 'mini',
						label: computed(() => this.Resources.LEVEL06184),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP11',
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					EQUIGROUPSEUDNEWGRP12: new fieldControlClass.GroupControl({
						id: 'EQUIGROUPSEUDNEWGRP12',
						name: 'NEWGRP12',
						size: 'block',
						label: computed(() => this.Resources.IT_IS_NEST_WITHIN_TH43205),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP11',
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIGROUTPEQUBACKCOLO', 'EQUIGROUTPEQUCORLETRA'],
						controlLimits: [
						],
					}, this),
					EQUIGROUTPEQUBACKCOLO: new fieldControlClass.StringControl({
						modelField: 'TpequValBackcolo',
						valueChangeEvent: 'fieldChange:tpequ.backcolo',
						dependentModelField: 'ValCodtpequ',
						dependentChangeEvent: 'fieldChange:equip.codtpequ',
						id: 'EQUIGROUTPEQUBACKCOLO',
						name: 'BACKCOLO',
						size: 'xxlarge',
						label: computed(() => this.Resources.BACKGROUND_COLOR47883),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP12',
						maxLength: 50,
						labelId: 'label_EQUIGROUTPEQUBACKCOLO',
						controlLimits: [
						],
					}, this),
					EQUIGROUTPEQUCORLETRA: new fieldControlClass.StringControl({
						modelField: 'TpequValCorletra',
						valueChangeEvent: 'fieldChange:tpequ.corletra',
						dependentModelField: 'ValCodtpequ',
						dependentChangeEvent: 'fieldChange:equip.codtpequ',
						id: 'EQUIGROUTPEQUCORLETRA',
						name: 'CORLETRA',
						size: 'xxlarge',
						label: computed(() => this.Resources.LETTER_COLOR15736),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP12',
						maxLength: 50,
						labelId: 'label_EQUIGROUTPEQUCORLETRA',
						controlLimits: [
						],
					}, this),
					EQUIGROUPSEUDNEWGRP07: new fieldControlClass.GroupControl({
						id: 'EQUIGROUPSEUDNEWGRP07',
						name: 'NEWGRP07',
						size: 'block',
						label: computed(() => this.Resources._2__C_GROUPBOX__MINO12365),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP23',
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIGROUEQUIPSEQUENNR', 'EQUIGROUEQUIPREGISTNR', 'EQUIGROUEQUIPVALORTOT', 'EQUIGROUPSEUDNEWGRP05'],
						controlLimits: [
						],
					}, this),
					EQUIGROUEQUIPSEQUENNR: new fieldControlClass.NumberControl({
						modelField: 'ValSequennr',
						valueChangeEvent: 'fieldChange:equip.sequennr',
						id: 'EQUIGROUEQUIPSEQUENNR',
						name: 'SEQUENNR',
						size: 'medium',
						label: computed(() => this.Resources.SEQUENTIAL_NO_38590),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP07',
						maxIntegers: 6,
						maxDecimals: 0,
						isSequencial: true,
						controlLimits: [
						],
					}, this),
					EQUIGROUEQUIPREGISTNR: new fieldControlClass.StringControl({
						modelField: 'ValRegistnr',
						valueChangeEvent: 'fieldChange:equip.registnr',
						id: 'EQUIGROUEQUIPREGISTNR',
						name: 'REGISTNR',
						size: 'medium',
						label: computed(() => this.Resources.NO__REGISTER04207),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP07',
						isFormulaBlocked: true,
						maxLength: 6,
						labelId: 'label_EQUIGROUEQUIPREGISTNR',
						controlLimits: [
						],
					}, this),
					EQUIGROUEQUIPVALORTOT: new fieldControlClass.CurrencyControl({
						modelField: 'ValValortot',
						valueChangeEvent: 'fieldChange:equip.valortot',
						id: 'EQUIGROUEQUIPVALORTOT',
						name: 'VALORTOT',
						size: 'medium',
						label: computed(() => this.Resources.TOTAL_VALUE30570),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP07',
						isFormulaBlocked: true,
						maxIntegers: 9,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					EQUIGROUPSEUDNEWGRP05: new fieldControlClass.GroupControl({
						id: 'EQUIGROUPSEUDNEWGRP05',
						name: 'NEWGRP05',
						size: 'block',
						label: computed(() => this.Resources.IT_IS_NEST_WITHIN_TH37713),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP07',
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIGROUEQUIPFREQUENC', 'EQUIGROUEQUIPBOUGHT__', 'EQUIGROUEQUIPDTREFERE', 'EQUIGROUEQUIPFIRST___'],
						controlLimits: [
						],
					}, this),
					EQUIGROUEQUIPFREQUENC: new fieldControlClass.ArrayNumberControl({
						modelField: 'ValFrequenc',
						valueChangeEvent: 'fieldChange:equip.frequenc',
						id: 'EQUIGROUEQUIPFREQUENC',
						name: 'FREQUENC',
						size: 'mini',
						helpControl: {
							shortHelp: {
								type: 'Subtext',
								text: computed(() => this.Resources.___1438719),
							},
						},
						label: computed(() => this.Resources.LOAN_FREQUENCY00701),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP05',
						maxIntegers: 2,
						maxDecimals: 0,
						arrayName: 'FreqEmpr',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					EQUIGROUEQUIPBOUGHT__: new fieldControlClass.BooleanControl({
						modelField: 'ValBought',
						valueChangeEvent: 'fieldChange:equip.bought',
						id: 'EQUIGROUEQUIPBOUGHT__',
						name: 'BOUGHT',
						size: 'mini',
						label: computed(() => this.Resources.BOUGHT32044),
						placeholder: '',
						labelPosition: computed(() => this.layoutConfig.CheckboxLabelAlignment),
						container: 'EQUIGROUPSEUDNEWGRP05',
						isFormulaBlocked: true,
						controlLimits: [
						],
					}, this),
					EQUIGROUEQUIPDTREFERE: new fieldControlClass.DateControl({
						modelField: 'ValDtrefere',
						valueChangeEvent: 'fieldChange:equip.dtrefere',
						id: 'EQUIGROUEQUIPDTREFERE',
						name: 'DTREFERE',
						size: 'medium',
						label: computed(() => this.Resources.REFERENCE28402),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP05',
						format: 'dateTime',
						controlLimits: [
						],
					}, this),
					EQUIGROUEQUIPFIRST___: new fieldControlClass.StringControl({
						modelField: 'ValFirst',
						valueChangeEvent: 'fieldChange:equip.first',
						id: 'EQUIGROUEQUIPFIRST___',
						name: 'FIRST',
						size: 'small',
						label: computed(() => this.Resources.FIRST42972),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP05',
						isFormulaBlocked: true,
						maxLength: 10,
						labelId: 'label_EQUIGROUEQUIPFIRST___',
						controlLimits: [
						],
					}, this),
					EQUIGROUPSEUDNEWGRP04: new fieldControlClass.GroupControl({
						id: 'EQUIGROUPSEUDNEWGRP04',
						name: 'NEWGRP04',
						size: 'block',
						label: computed(() => this.Resources._3__C_GROUPBOX__MINO47300),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP23',
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIGROUEQUIPPHOTOGRA', 'EQUIGROUPSEUDNEWGRP06'],
						controlLimits: [
						],
					}, this),
					EQUIGROUEQUIPPHOTOGRA: new fieldControlClass.ImageControl({
						modelField: 'ValPhotogra',
						valueChangeEvent: 'fieldChange:equip.photogra',
						id: 'EQUIGROUEQUIPPHOTOGRA',
						name: 'PHOTOGRA',
						size: 'mini',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP04',
						height: 50,
						width: 30,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO51874)),
						maxFileSize: 10485760, // In bytes.
						maxFileSizeLabel: '10 MB',
						controlLimits: [
						],
					}, this),
					EQUIGROUPSEUDNEWGRP06: new fieldControlClass.GroupControl({
						id: 'EQUIGROUPSEUDNEWGRP06',
						name: 'NEWGRP06',
						size: 'block',
						label: computed(() => this.Resources.IT_IS_NEST_WITHIN_TH37713),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP04',
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIGROUEQUIPDESIGNAT'],
						controlLimits: [
						],
					}, this),
					EQUIGROUEQUIPDESIGNAT: new fieldControlClass.StringControl({
						modelField: 'ValDesignat',
						valueChangeEvent: 'fieldChange:equip.designat',
						id: 'EQUIGROUEQUIPDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESIGNATION35876),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIGROUPSEUDNEWGRP06',
						maxLength: 85,
						labelId: 'label_EQUIGROUEQUIPDESIGNAT',
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
					'EQUIGROUPSEUDNEWGRP19',
					'EQUIGROUPSEUDNEWGRP13',
					'EQUIGROUPSEUDNEWGRP14',
					'EQUIGROUPSEUDNEWGRP17',
					'EQUIGROUPSEUDNEWGRP15',
					'EQUIGROUPSEUDNEWGRP16',
					'EQUIGROUPSEUDNEWGRP18',
					'EQUIGROUPSEUDNEWGRP01',
					'EQUIGROUPSEUDNEWGRP02',
					'EQUIGROUPSEUDNEWGRP03',
					'EQUIGROUPSEUDNEWGRP21',
					'EQUIGROUPSEUDNEWGRP08',
					'EQUIGROUPSEUDNEWGRP23',
					'EQUIGROUPSEUDNEWGRP09',
					'EQUIGROUPSEUDNEWGRP10',
					'EQUIGROUPSEUDNEWGRP11',
					'EQUIGROUPSEUDNEWGRP12',
					'EQUIGROUPSEUDNEWGRP07',
					'EQUIGROUPSEUDNEWGRP05',
					'EQUIGROUPSEUDNEWGRP04',
					'EQUIGROUPSEUDNEWGRP06',
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Cmpny: {
						get ValAcronym() { return vm.model.CmpnyValAcronym.value },
						set ValAcronym(value) { vm.model.CmpnyValAcronym.updateValue(value) },
						get ValDesignat() { return vm.model.CmpnyValDesignat.value },
						set ValDesignat(value) { vm.model.CmpnyValDesignat.updateValue(value) },
						get ValEmail() { return vm.model.CmpnyValEmail.value },
						set ValEmail(value) { vm.model.CmpnyValEmail.updateValue(value) },
						get ValLogo() { return vm.model.CmpnyValLogo.value },
						set ValLogo(value) { vm.model.CmpnyValLogo.updateValue(value) },
						get ValNif() { return vm.model.CmpnyValNif.value },
						set ValNif(value) { vm.model.CmpnyValNif.updateValue(value) },
						get ValTelephon() { return vm.model.CmpnyValTelephon.value },
						set ValTelephon(value) { vm.model.CmpnyValTelephon.updateValue(value) },
					},
					Equip: {
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
						get ValDtrefere() { return vm.model.ValDtrefere.value },
						set ValDtrefere(value) { vm.model.ValDtrefere.updateValue(value) },
						get ValFirst() { return vm.model.ValFirst.value },
						set ValFirst(value) { vm.model.ValFirst.updateValue(value) },
						get ValFrequenc() { return vm.model.ValFrequenc.value },
						set ValFrequenc(value) { vm.model.ValFrequenc.updateValue(value) },
						get ValPhotogra() { return vm.model.ValPhotogra.value },
						set ValPhotogra(value) { vm.model.ValPhotogra.updateValue(value) },
						get ValQtdmovim() { return vm.model.ValQtdmovim.value },
						set ValQtdmovim(value) { vm.model.ValQtdmovim.updateValue(value) },
						get ValRegistnr() { return vm.model.ValRegistnr.value },
						set ValRegistnr(value) { vm.model.ValRegistnr.updateValue(value) },
						get ValSequennr() { return vm.model.ValSequennr.value },
						set ValSequennr(value) { vm.model.ValSequennr.updateValue(value) },
						get ValValortot() { return vm.model.ValValortot.value },
						set ValValortot(value) { vm.model.ValValortot.updateValue(value) },
					},
					Item: {
						get ValItemdes() { return vm.model.ItemValItemdes.value },
						set ValItemdes(value) { vm.model.ItemValItemdes.updateValue(value) },
					},
					Pess1: {
						get ValDtnascim() { return vm.model.Pess1ValDtnascim.value },
						set ValDtnascim(value) { vm.model.Pess1ValDtnascim.updateValue(value) },
						get ValEmail() { return vm.model.Pess1ValEmail.value },
						set ValEmail(value) { vm.model.Pess1ValEmail.updateValue(value) },
						get ValEmail2() { return vm.model.Pess1ValEmail2.value },
						set ValEmail2(value) { vm.model.Pess1ValEmail2.updateValue(value) },
						get ValGender() { return vm.model.Pess1ValGender.value },
						set ValGender(value) { vm.model.Pess1ValGender.updateValue(value) },
						get ValIdade() { return vm.model.Pess1ValIdade.value },
						set ValIdade(value) { vm.model.Pess1ValIdade.updateValue(value) },
						get ValIdfuncio() { return vm.model.Pess1ValIdfuncio.value },
						set ValIdfuncio(value) { vm.model.Pess1ValIdfuncio.updateValue(value) },
						get ValName() { return vm.model.TablePess1Name.value },
						set ValName(value) { vm.model.TablePess1Name.updateValue(value) },
						get ValPhotogra() { return vm.model.Pess1ValPhotogra.value },
						set ValPhotogra(value) { vm.model.Pess1ValPhotogra.updateValue(value) },
						get ValTelephon() { return vm.model.Pess1ValTelephon.value },
						set ValTelephon(value) { vm.model.Pess1ValTelephon.updateValue(value) },
					},
					Tpequ: {
						get ValBackcolo() { return vm.model.TpequValBackcolo.value },
						set ValBackcolo(value) { vm.model.TpequValBackcolo.updateValue(value) },
						get ValCorletra() { return vm.model.TpequValCorletra.value },
						set ValCorletra(value) { vm.model.TpequValCorletra.updateValue(value) },
						get ValNivel() { return vm.model.TpequValNivel.value },
						set ValNivel(value) { vm.model.TpequValNivel.updateValue(value) },
						get ValPrecomax() { return vm.model.TpequValPrecomax.value },
						set ValPrecomax(value) { vm.model.TpequValPrecomax.updateValue(value) },
						get ValTipoequi() { return vm.model.TableTpequTipoequi.value },
						set ValTipoequi(value) { vm.model.TableTpequTipoequi.updateValue(value) },
						get ValTpequcod() { return vm.model.TpequValTpequcod.value },
						set ValTpequcod(value) { vm.model.TpequValTpequcod.updateValue(value) },
						get ValTpequpai() { return vm.model.TpequValTpequpai.value },
						set ValTpequpai(value) { vm.model.TpequValTpequpai.updateValue(value) },
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
// USE /[MANUAL GQT FORM_CODEJS EQUIGROU]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS EQUIGROU]/
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
// USE /[MANUAL GQT FORM_LOADED_JS EQUIGROU]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS EQUIGROU]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS EQUIGROU]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS EQUIGROU]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS EQUIGROU]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS EQUIGROU]/
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
// USE /[MANUAL GQT AFTER_DEL_JS EQUIGROU]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS EQUIGROU]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS EQUIGROU]/
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
// USE /[MANUAL GQT DLGUPDT EQUIGROU]/
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
// USE /[MANUAL GQT CTRLBLR EQUIGROU]/
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
// USE /[MANUAL GQT CTRLUPD EQUIGROU]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS EQUIGROU]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
			// Watchers for changes in the state of tabs and collapsible groups.
			'controls.EQUIGROUPSEUDNEWGRP15.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'EQUIGROUPSEUDNEWGRP15',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
			'controls.EQUIGROUPSEUDNEWGRP16.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'EQUIGROUPSEUDNEWGRP16',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
			'controls.EQUIGROUPSEUDNEWGRP08.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'EQUIGROUPSEUDNEWGRP08',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
		}
	}
</script>
