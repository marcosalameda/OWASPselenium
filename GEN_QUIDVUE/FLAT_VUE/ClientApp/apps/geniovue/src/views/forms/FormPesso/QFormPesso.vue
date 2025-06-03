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
			data-key="PESSO"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container
					v-show="controls.PESSO___PSEUDNOVOGR08.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.PESSO___PSEUDNOVOGR08.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="PESSO___PSEUDNOVOGR08"
							v-bind="controls.PESSO___PSEUDNOVOGR08"
							no-border
							:is-visible="controls.PESSO___PSEUDNOVOGR08.isVisible">
							<!-- Start PESSO___PSEUDNOVOGR08 -->
							<q-row-container v-show="controls.PESSO___PSEUDNOVOGR04.isVisible || controls.PESSO___PSEUDNOVOGR02.isVisible">
								<q-control-wrapper
									v-show="controls.PESSO___PSEUDNOVOGR04.isVisible"
									class="control-join-group">
									<q-group-box-container
										id="PESSO___PSEUDNOVOGR04"
										v-bind="controls.PESSO___PSEUDNOVOGR04"
										:is-visible="controls.PESSO___PSEUDNOVOGR04.isVisible">
										<!-- Start PESSO___PSEUDNOVOGR04 -->
										<q-row-container v-show="controls.PESSO___PESSOPHOTOGRA.isVisible">
											<q-control-wrapper
												v-show="controls.PESSO___PESSOPHOTOGRA.isVisible"
												class="control-join-group">
												<base-input-structure
													class="q-image"
													v-bind="controls.PESSO___PESSOPHOTOGRA"
													v-on="controls.PESSO___PESSOPHOTOGRA.handlers"
													:loading="controls.PESSO___PESSOPHOTOGRA.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-image
														v-if="controls.PESSO___PESSOPHOTOGRA.isVisible"
														v-bind="controls.PESSO___PESSOPHOTOGRA.props"
														v-on="controls.PESSO___PESSOPHOTOGRA.handlers" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<!-- End PESSO___PSEUDNOVOGR04 -->
									</q-group-box-container>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PESSO___PSEUDNOVOGR02.isVisible"
									class="control-join-group">
									<q-group-box-container
										id="PESSO___PSEUDNOVOGR02"
										v-bind="controls.PESSO___PSEUDNOVOGR02"
										:is-visible="controls.PESSO___PSEUDNOVOGR02.isVisible">
										<!-- Start PESSO___PSEUDNOVOGR02 -->
										<q-row-container v-show="controls.PESSO___PESSOIDFUNCIO.isVisible || controls.PESSO___PESSONAME____.isVisible">
											<q-control-wrapper
												v-show="controls.PESSO___PESSOIDFUNCIO.isVisible || controls.PESSO___PESSONAME____.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PESSO___PESSOIDFUNCIO"
													v-on="controls.PESSO___PESSOIDFUNCIO.handlers"
													:loading="controls.PESSO___PESSOIDFUNCIO.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-numeric-input
														v-if="controls.PESSO___PESSOIDFUNCIO.isVisible"
														v-bind="controls.PESSO___PESSOIDFUNCIO.props"
														@update:model-value="model.ValIdfuncio.fnUpdateValue" />
												</base-input-structure>
												<base-input-structure
													class="i-text"
													v-bind="controls.PESSO___PESSONAME____"
													v-on="controls.PESSO___PESSONAME____.handlers"
													:loading="controls.PESSO___PESSONAME____.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-field
														v-bind="controls.PESSO___PESSONAME____.props"
														@blur="onBlur(controls.PESSO___PESSONAME____, model.ValName.value)"
														@change="model.ValName.fnUpdateValueOnChange" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.PESSO___PESSOGENDER__.isVisible">
											<q-control-wrapper
												v-show="controls.PESSO___PESSOGENDER__.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-radio-container"
													v-bind="controls.PESSO___PESSOGENDER__"
													v-on="controls.PESSO___PESSOGENDER__.handlers"
													:label-position="labelAlignment.topleft"
													:loading="controls.PESSO___PESSOGENDER__.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-radio-group
														v-if="controls.PESSO___PESSOGENDER__.isVisible"
														id="PESSO___PESSOGENDER__"
														:model-value="model.ValGender.value"
														deselect-radio
														:label-left-side="controls.PESSO___PESSOGENDER__.labelPosition === labelAlignment.left"
														:number-of-columns="controls.PESSO___PESSOGENDER__.columnNumber"
														:is-required="controls.PESSO___PESSOGENDER__.isRequired"
														:readonly="controls.PESSO___PESSOGENDER__.readonly"
														:options-list="controls.PESSO___PESSOGENDER__.items"
														@update:model-value="model.ValGender.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.PESSO___PESSODTNASCIM.isVisible || controls.PESSO___PESSOIDADE___.isVisible">
											<q-control-wrapper
												v-show="controls.PESSO___PESSODTNASCIM.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PESSO___PESSODTNASCIM"
													v-on="controls.PESSO___PESSODTNASCIM.handlers"
													:loading="controls.PESSO___PESSODTNASCIM.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-date-time-picker
														v-if="controls.PESSO___PESSODTNASCIM.isVisible"
														v-bind="controls.PESSO___PESSODTNASCIM.props"
														:model-value="model.ValDtnascim.value"
														@reset-icon-click="model.ValDtnascim.fnUpdateValue(model.ValDtnascim.originalValue ?? new Date())"
														@update:model-value="model.ValDtnascim.fnUpdateValue($event ?? '')" />
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.PESSO___PESSOIDADE___.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PESSO___PESSOIDADE___"
													v-on="controls.PESSO___PESSOIDADE___.handlers"
													:loading="controls.PESSO___PESSOIDADE___.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-numeric-input
														v-if="controls.PESSO___PESSOIDADE___.isVisible"
														v-bind="controls.PESSO___PESSOIDADE___.props"
														@update:model-value="model.ValIdade.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.PESSO___PESSOINTERNA_.isVisible || controls.PESSO___PESSOEXTERNA_.isVisible">
											<q-control-wrapper
												v-show="controls.PESSO___PESSOINTERNA_.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-checkbox"
													v-bind="controls.PESSO___PESSOINTERNA_"
													v-on="controls.PESSO___PESSOINTERNA_.handlers"
													:loading="controls.PESSO___PESSOINTERNA_.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<template #label>
														<q-checkbox-input
															v-if="controls.PESSO___PESSOINTERNA_.isVisible"
															v-bind="controls.PESSO___PESSOINTERNA_.props"
															v-on="controls.PESSO___PESSOINTERNA_.handlers" />
													</template>
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.PESSO___PESSOEXTERNA_.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-checkbox"
													v-bind="controls.PESSO___PESSOEXTERNA_"
													v-on="controls.PESSO___PESSOEXTERNA_.handlers"
													:loading="controls.PESSO___PESSOEXTERNA_.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<template #label>
														<q-checkbox-input
															v-if="controls.PESSO___PESSOEXTERNA_.isVisible"
															v-bind="controls.PESSO___PESSOEXTERNA_.props"
															v-on="controls.PESSO___PESSOEXTERNA_.handlers" />
													</template>
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.PESSO___CATEGCATEGORY.isVisible || controls.PESSO___PESSODTULTCAT.isVisible">
											<q-control-wrapper
												v-show="controls.PESSO___CATEGCATEGORY.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PESSO___CATEGCATEGORY"
													v-on="controls.PESSO___CATEGCATEGORY.handlers"
													:loading="controls.PESSO___CATEGCATEGORY.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-lookup
														v-if="controls.PESSO___CATEGCATEGORY.isVisible"
														v-bind="controls.PESSO___CATEGCATEGORY.props"
														v-on="controls.PESSO___CATEGCATEGORY.handlers" />
													<q-see-more-pesso-categcategory
														v-if="controls.PESSO___CATEGCATEGORY.seeMoreIsVisible"
														v-bind="controls.PESSO___CATEGCATEGORY.seeMoreParams"
														v-on="controls.PESSO___CATEGCATEGORY.handlers" />
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.PESSO___PESSODTULTCAT.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PESSO___PESSODTULTCAT"
													v-on="controls.PESSO___PESSODTULTCAT.handlers"
													:loading="controls.PESSO___PESSODTULTCAT.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-date-time-picker
														v-if="controls.PESSO___PESSODTULTCAT.isVisible"
														v-bind="controls.PESSO___PESSODTULTCAT.props"
														:model-value="model.ValDtultcat.value"
														@reset-icon-click="model.ValDtultcat.fnUpdateValue(model.ValDtultcat.originalValue ?? new Date())"
														@update:model-value="model.ValDtultcat.fnUpdateValue($event ?? '')" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.PESSO___PAIS1COUNTRY_.isVisible">
											<q-control-wrapper
												v-show="controls.PESSO___PAIS1COUNTRY_.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PESSO___PAIS1COUNTRY_"
													v-on="controls.PESSO___PAIS1COUNTRY_.handlers"
													:loading="controls.PESSO___PAIS1COUNTRY_.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-lookup
														v-if="controls.PESSO___PAIS1COUNTRY_.isVisible"
														v-bind="controls.PESSO___PAIS1COUNTRY_.props"
														v-on="controls.PESSO___PAIS1COUNTRY_.handlers" />
													<q-see-more-pesso-pais1country
														v-if="controls.PESSO___PAIS1COUNTRY_.seeMoreIsVisible"
														v-bind="controls.PESSO___PAIS1COUNTRY_.seeMoreParams"
														v-on="controls.PESSO___PAIS1COUNTRY_.handlers" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<!-- End PESSO___PSEUDNOVOGR02 -->
									</q-group-box-container>
								</q-control-wrapper>
							</q-row-container>
							<!-- End PESSO___PSEUDNOVOGR08 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.PESSO___PSEUDNOVOGR11.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.PESSO___PSEUDNOVOGR11.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="PESSO___PSEUDNOVOGR11"
							v-bind="controls.PESSO___PSEUDNOVOGR11"
							:is-visible="controls.PESSO___PSEUDNOVOGR11.isVisible">
							<!-- Start PESSO___PSEUDNOVOGR11 -->
							<q-row-container v-show="controls.PESSO___PSEUDESPECIAL.isVisible">
								<q-control-wrapper
									v-show="controls.PESSO___PSEUDESPECIAL.isVisible"
									class="control-join-group">
									<q-table
										v-show="controls.PESSO___PSEUDESPECIAL.isVisible"
										v-bind="controls.PESSO___PSEUDESPECIAL"
										v-on="controls.PESSO___PSEUDESPECIAL.handlers" />
									<q-table-extra-extension
										:list-ctrl="controls.PESSO___PSEUDESPECIAL"
										v-on="controls.PESSO___PSEUDESPECIAL.handlers" />
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PESSO___PSEUDESPECITL.isVisible">
								<q-control-wrapper
									v-show="controls.PESSO___PSEUDESPECITL.isVisible"
									class="control-join-group">
									<q-table
										v-show="controls.PESSO___PSEUDESPECITL.isVisible"
										v-bind="controls.PESSO___PSEUDESPECITL"
										v-on="controls.PESSO___PSEUDESPECITL.handlers" />
									<q-table-extra-extension
										:list-ctrl="controls.PESSO___PSEUDESPECITL"
										v-on="controls.PESSO___PSEUDESPECITL.handlers" />
								</q-control-wrapper>
							</q-row-container>
							<!-- End PESSO___PSEUDNOVOGR11 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.PESSO___PSEUDNOVOGR06.isVisible || controls.PESSO___PSEUDOBRIGATO.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.PESSO___PSEUDNOVOGR06.isVisible"
						class="row-line-group">
						<q-accordion
							v-if="controls.PESSO___PSEUDNOVOGR06.isVisible"
							id="PESSO___PSEUDNOVOGR06"
							v-bind="controls.PESSO___PSEUDNOVOGR06">
							<!-- Start PESSO___PSEUDNOVOGR06 -->
							<q-group-collapsible
								id="PESSO___PSEUDNOVOGR07"
								v-bind="controls.PESSO___PSEUDNOVOGR07"
								v-on="controls.PESSO___PSEUDNOVOGR07.handlers">
								<!-- Start PESSO___PSEUDNOVOGR07 -->
								<q-row-container v-show="controls.PESSO___PSEUDNOVOGR03.isVisible || controls.PESSO___PSEUDNOVOGR09.isVisible">
									<q-control-wrapper
										v-show="controls.PESSO___PSEUDNOVOGR03.isVisible"
										class="control-join-group">
										<q-group-box-container
											id="PESSO___PSEUDNOVOGR03"
											v-bind="controls.PESSO___PSEUDNOVOGR03"
											:is-visible="controls.PESSO___PSEUDNOVOGR03.isVisible">
											<!-- Start PESSO___PSEUDNOVOGR03 -->
											<q-row-container v-show="controls.PESSO___PESSOTELEPHON.isVisible || controls.PESSO___PESSOEMAIL___.isVisible">
												<q-control-wrapper
													v-show="controls.PESSO___PESSOTELEPHON.isVisible"
													class="control-join-group">
													<base-input-structure
														class="i-text"
														v-bind="controls.PESSO___PESSOTELEPHON"
														v-on="controls.PESSO___PESSOTELEPHON.handlers"
														:loading="controls.PESSO___PESSOTELEPHON.props.loading"
														:reporting-mode-on="reportingModeCAV"
														:suggestion-mode-on="suggestionModeOn">
														<q-text-field
															v-bind="controls.PESSO___PESSOTELEPHON.props"
															@blur="onBlur(controls.PESSO___PESSOTELEPHON, model.ValTelephon.value)"
															@change="model.ValTelephon.fnUpdateValueOnChange" />
													</base-input-structure>
												</q-control-wrapper>
												<q-control-wrapper
													v-show="controls.PESSO___PESSOEMAIL___.isVisible"
													class="control-join-group">
													<base-input-structure
														class="i-text"
														v-bind="controls.PESSO___PESSOEMAIL___"
														v-on="controls.PESSO___PESSOEMAIL___.handlers"
														:loading="controls.PESSO___PESSOEMAIL___.props.loading"
														:reporting-mode-on="reportingModeCAV"
														:suggestion-mode-on="suggestionModeOn">
														<q-text-field
															v-bind="controls.PESSO___PESSOEMAIL___.props"
															@blur="onBlur(controls.PESSO___PESSOEMAIL___, model.ValEmail.value)"
															@change="model.ValEmail.fnUpdateValueOnChange" />
													</base-input-structure>
												</q-control-wrapper>
											</q-row-container>
											<q-row-container v-show="controls.PESSO___PESSOEMAIL2__.isVisible">
												<q-control-wrapper
													v-show="controls.PESSO___PESSOEMAIL2__.isVisible"
													class="control-join-group">
													<base-input-structure
														class="i-text"
														v-bind="controls.PESSO___PESSOEMAIL2__"
														v-on="controls.PESSO___PESSOEMAIL2__.handlers"
														:loading="controls.PESSO___PESSOEMAIL2__.props.loading"
														:reporting-mode-on="reportingModeCAV"
														:suggestion-mode-on="suggestionModeOn">
														<q-text-field
															v-bind="controls.PESSO___PESSOEMAIL2__.props"
															@blur="onBlur(controls.PESSO___PESSOEMAIL2__, model.ValEmail2.value)"
															@change="model.ValEmail2.fnUpdateValueOnChange" />
													</base-input-structure>
												</q-control-wrapper>
											</q-row-container>
											<!-- End PESSO___PSEUDNOVOGR03 -->
										</q-group-box-container>
									</q-control-wrapper>
									<q-control-wrapper
										v-show="controls.PESSO___PSEUDNOVOGR09.isVisible"
										class="control-join-group">
										<q-group-box-container
											id="PESSO___PSEUDNOVOGR09"
											v-bind="controls.PESSO___PSEUDNOVOGR09"
											:is-visible="controls.PESSO___PSEUDNOVOGR09.isVisible">
											<!-- Start PESSO___PSEUDNOVOGR09 -->
											<q-row-container v-show="controls.PESSO___PSEUDCONTACTO.isVisible">
												<q-control-wrapper
													v-show="controls.PESSO___PSEUDCONTACTO.isVisible"
													class="control-join-group">
													<q-table
														v-show="controls.PESSO___PSEUDCONTACTO.isVisible"
														v-bind="controls.PESSO___PSEUDCONTACTO"
														v-on="controls.PESSO___PSEUDCONTACTO.handlers" />
													<q-table-extra-extension
														:list-ctrl="controls.PESSO___PSEUDCONTACTO"
														v-on="controls.PESSO___PSEUDCONTACTO.handlers" />
												</q-control-wrapper>
											</q-row-container>
											<!-- End PESSO___PSEUDNOVOGR09 -->
										</q-group-box-container>
									</q-control-wrapper>
								</q-row-container>
								<!-- End PESSO___PSEUDNOVOGR07 -->
							</q-group-collapsible>
							<q-group-collapsible
								id="PESSO___PSEUDNOVOGR05"
								v-bind="controls.PESSO___PSEUDNOVOGR05"
								v-on="controls.PESSO___PSEUDNOVOGR05.handlers">
								<!-- Start PESSO___PSEUDNOVOGR05 -->
								<q-row-container
									v-show="controls.PESSO___PSEUDNOVOGR01.isVisible"
									is-large>
									<q-control-wrapper
										v-show="controls.PESSO___PSEUDNOVOGR01.isVisible"
										class="row-line-group">
										<q-group-box-container
											id="PESSO___PSEUDNOVOGR01"
											v-bind="controls.PESSO___PSEUDNOVOGR01"
											:is-visible="controls.PESSO___PSEUDNOVOGR01.isVisible">
											<!-- Start PESSO___PSEUDNOVOGR01 -->
											<q-row-container
												v-show="controls.PESSO___PSEUDNOVOGR13.isVisible || controls.PESSO___REGI1REGIAO__.isVisible"
												is-large>
												<q-control-wrapper
													v-show="controls.PESSO___PSEUDNOVOGR13.isVisible"
													class="row-line-group">
													<q-group-box-container
														id="PESSO___PSEUDNOVOGR13"
														v-bind="controls.PESSO___PSEUDNOVOGR13"
														no-border
														:is-visible="controls.PESSO___PSEUDNOVOGR13.isVisible">
														<!-- Start PESSO___PSEUDNOVOGR13 -->
														<q-row-container v-show="controls.PESSO___CMPNYDESIGNAT.isVisible">
															<q-control-wrapper
																v-show="controls.PESSO___CMPNYDESIGNAT.isVisible"
																class="control-join-group">
																<base-input-structure
																	class="i-text"
																	v-bind="controls.PESSO___CMPNYDESIGNAT"
																	v-on="controls.PESSO___CMPNYDESIGNAT.handlers"
																	:loading="controls.PESSO___CMPNYDESIGNAT.props.loading"
																	:reporting-mode-on="reportingModeCAV"
																	:suggestion-mode-on="suggestionModeOn">
																	<q-lookup
																		v-if="controls.PESSO___CMPNYDESIGNAT.isVisible"
																		v-bind="controls.PESSO___CMPNYDESIGNAT.props"
																		v-on="controls.PESSO___CMPNYDESIGNAT.handlers" />
																	<q-see-more-pesso-cmpnydesignat
																		v-if="controls.PESSO___CMPNYDESIGNAT.seeMoreIsVisible"
																		v-bind="controls.PESSO___CMPNYDESIGNAT.seeMoreParams"
																		v-on="controls.PESSO___CMPNYDESIGNAT.handlers" />
																</base-input-structure>
															</q-control-wrapper>
														</q-row-container>
														<q-row-container v-show="controls.PESSO___CNTRYCOUNTRY_.isVisible">
															<q-control-wrapper
																v-show="controls.PESSO___CNTRYCOUNTRY_.isVisible"
																class="control-join-group">
																<base-input-structure
																	class="i-text"
																	v-bind="controls.PESSO___CNTRYCOUNTRY_"
																	v-on="controls.PESSO___CNTRYCOUNTRY_.handlers"
																	:loading="controls.PESSO___CNTRYCOUNTRY_.props.loading"
																	:reporting-mode-on="reportingModeCAV"
																	:suggestion-mode-on="suggestionModeOn">
																	<q-text-field
																		v-bind="controls.PESSO___CNTRYCOUNTRY_.props"
																		@blur="onBlur(controls.PESSO___CNTRYCOUNTRY_, model.CntryValCountry.value)"
																		@change="model.CntryValCountry.fnUpdateValueOnChange" />
																</base-input-structure>
															</q-control-wrapper>
														</q-row-container>
														<!-- End PESSO___PSEUDNOVOGR13 -->
													</q-group-box-container>
												</q-control-wrapper>
												<q-control-wrapper
													v-show="controls.PESSO___REGI1REGIAO__.isVisible"
													class="control-join-group">
													<base-input-structure
														class="i-text"
														v-bind="controls.PESSO___REGI1REGIAO__"
														v-on="controls.PESSO___REGI1REGIAO__.handlers"
														:loading="controls.PESSO___REGI1REGIAO__.props.loading"
														:reporting-mode-on="reportingModeCAV"
														:suggestion-mode-on="suggestionModeOn">
														<q-lookup
															v-if="controls.PESSO___REGI1REGIAO__.isVisible"
															v-bind="controls.PESSO___REGI1REGIAO__.props"
															v-on="controls.PESSO___REGI1REGIAO__.handlers" />
														<q-see-more-pesso-regi1regiao
															v-if="controls.PESSO___REGI1REGIAO__.seeMoreIsVisible"
															v-bind="controls.PESSO___REGI1REGIAO__.seeMoreParams"
															v-on="controls.PESSO___REGI1REGIAO__.handlers" />
													</base-input-structure>
												</q-control-wrapper>
											</q-row-container>
											<!-- End PESSO___PSEUDNOVOGR01 -->
										</q-group-box-container>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container
									v-show="controls.PESSO___PSEUDNOVOGR10.isVisible"
									is-large>
									<q-control-wrapper
										v-show="controls.PESSO___PSEUDNOVOGR10.isVisible"
										class="row-line-group">
										<q-group-box-container
											id="PESSO___PSEUDNOVOGR10"
											v-bind="controls.PESSO___PSEUDNOVOGR10"
											:is-visible="controls.PESSO___PSEUDNOVOGR10.isVisible">
											<!-- Start PESSO___PSEUDNOVOGR10 -->
											<q-row-container v-show="controls.PESSO___PSEUDEVOLUCAO.isVisible">
												<q-control-wrapper
													v-show="controls.PESSO___PSEUDEVOLUCAO.isVisible"
													class="control-join-group">
													<q-table
														v-show="controls.PESSO___PSEUDEVOLUCAO.isVisible"
														v-bind="controls.PESSO___PSEUDEVOLUCAO"
														v-on="controls.PESSO___PSEUDEVOLUCAO.handlers" />
													<q-table-extra-extension
														:list-ctrl="controls.PESSO___PSEUDEVOLUCAO"
														v-on="controls.PESSO___PSEUDEVOLUCAO.handlers" />
												</q-control-wrapper>
											</q-row-container>
											<!-- End PESSO___PSEUDNOVOGR10 -->
										</q-group-box-container>
									</q-control-wrapper>
								</q-row-container>
								<!-- End PESSO___PSEUDNOVOGR05 -->
							</q-group-collapsible>
							<!-- End PESSO___PSEUDNOVOGR06 -->
						</q-accordion>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.PESSO___PSEUDOBRIGATO.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-static-text"
							v-bind="controls.PESSO___PSEUDOBRIGATO"
							v-on="controls.PESSO___PSEUDOBRIGATO.handlers"
							:loading="controls.PESSO___PSEUDOBRIGATO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-static-text
								v-if="controls.PESSO___PSEUDOBRIGATO.isVisible"
								id="PESSO___PSEUDOBRIGATO"
								:size="controls.PESSO___PSEUDOBRIGATO.size"
								:text="controls.PESSO___PSEUDOBRIGATO.label"
								supports-html />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.PESSO___PSEUDTERRAGRP.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.PESSO___PSEUDTERRAGRP.isVisible"
						class="row-line-group">
						<q-group-collapsible
							id="PESSO___PSEUDTERRAGRP"
							v-bind="controls.PESSO___PSEUDTERRAGRP"
							v-on="controls.PESSO___PSEUDTERRAGRP.handlers">
							<!-- Start PESSO___PSEUDTERRAGRP -->
							<q-row-container
								v-show="controls.PESSO___PESSOEXTQUERY.isVisible || controls.PESSO___PESSOZOOMLVL_.isVisible || controls.PESSO___PESSOEXTMINZM.isVisible || controls.PESSO___PESSOMAPHEIGH.isVisible || controls.PESSO___PESSOOUTWEIGH.isVisible"
								is-large>
								<q-control-wrapper
									v-show="controls.PESSO___PESSOEXTQUERY.isVisible"
									class="row-line-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PESSO___PESSOEXTQUERY"
										v-on="controls.PESSO___PESSOEXTQUERY.handlers"
										:loading="controls.PESSO___PESSOEXTQUERY.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.PESSO___PESSOEXTQUERY.props"
											@blur="onBlur(controls.PESSO___PESSOEXTQUERY, model.ValExtquery.value)"
											@change="model.ValExtquery.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PESSO___PESSOZOOMLVL_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PESSO___PESSOZOOMLVL_"
										v-on="controls.PESSO___PESSOZOOMLVL_.handlers"
										:loading="controls.PESSO___PESSOZOOMLVL_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.PESSO___PESSOZOOMLVL_.isVisible"
											v-bind="controls.PESSO___PESSOZOOMLVL_.props"
											@update:model-value="model.ValZoomlvl.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PESSO___PESSOEXTMINZM.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PESSO___PESSOEXTMINZM"
										v-on="controls.PESSO___PESSOEXTMINZM.handlers"
										:loading="controls.PESSO___PESSOEXTMINZM.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.PESSO___PESSOEXTMINZM.isVisible"
											v-bind="controls.PESSO___PESSOEXTMINZM.props"
											@update:model-value="model.ValExtminzm.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PESSO___PESSOMAPHEIGH.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PESSO___PESSOMAPHEIGH"
										v-on="controls.PESSO___PESSOMAPHEIGH.handlers"
										:loading="controls.PESSO___PESSOMAPHEIGH.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.PESSO___PESSOMAPHEIGH.props"
											@blur="onBlur(controls.PESSO___PESSOMAPHEIGH, model.ValMapheigh.value)"
											@change="model.ValMapheigh.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.PESSO___PESSOOUTWEIGH.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PESSO___PESSOOUTWEIGH"
										v-on="controls.PESSO___PESSOOUTWEIGH.handlers"
										:loading="controls.PESSO___PESSOOUTWEIGH.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.PESSO___PESSOOUTWEIGH.isVisible"
											v-bind="controls.PESSO___PESSOOUTWEIGH.props"
											@update:model-value="model.ValOutweigh.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PESSO___PESSOLINECLR_.isVisible || controls.PESSO___PESSOPOLYCLR_.isVisible">
								<q-control-wrapper
									v-show="controls.PESSO___PESSOLINECLR_.isVisible || controls.PESSO___PESSOPOLYCLR_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PESSO___PESSOLINECLR_"
										v-on="controls.PESSO___PESSOLINECLR_.handlers"
										:loading="controls.PESSO___PESSOLINECLR_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.PESSO___PESSOLINECLR_.props"
											@blur="onBlur(controls.PESSO___PESSOLINECLR_, model.ValLineclr.value)"
											@change="model.ValLineclr.fnUpdateValueOnChange" />
									</base-input-structure>
									<base-input-structure
										class="i-text"
										v-bind="controls.PESSO___PESSOPOLYCLR_"
										v-on="controls.PESSO___PESSOPOLYCLR_.handlers"
										:loading="controls.PESSO___PESSOPOLYCLR_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.PESSO___PESSOPOLYCLR_.props"
											@blur="onBlur(controls.PESSO___PESSOPOLYCLR_, model.ValPolyclr.value)"
											@change="model.ValPolyclr.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PESSO___PESSODRAWMRK_.isVisible || controls.PESSO___PESSOALLOWLIN.isVisible || controls.PESSO___PESSOALLOWPOL.isVisible">
								<q-control-wrapper
									v-show="controls.PESSO___PESSODRAWMRK_.isVisible || controls.PESSO___PESSOALLOWLIN.isVisible || controls.PESSO___PESSOALLOWPOL.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.PESSO___PESSODRAWMRK_"
										v-on="controls.PESSO___PESSODRAWMRK_.handlers"
										:loading="controls.PESSO___PESSODRAWMRK_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.PESSO___PESSODRAWMRK_.isVisible"
												v-bind="controls.PESSO___PESSODRAWMRK_.props"
												v-on="controls.PESSO___PESSODRAWMRK_.handlers" />
										</template>
									</base-input-structure>
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.PESSO___PESSOALLOWLIN"
										v-on="controls.PESSO___PESSOALLOWLIN.handlers"
										:loading="controls.PESSO___PESSOALLOWLIN.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.PESSO___PESSOALLOWLIN.isVisible"
												v-bind="controls.PESSO___PESSOALLOWLIN.props"
												v-on="controls.PESSO___PESSOALLOWLIN.handlers" />
										</template>
									</base-input-structure>
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.PESSO___PESSOALLOWPOL"
										v-on="controls.PESSO___PESSOALLOWPOL.handlers"
										:loading="controls.PESSO___PESSOALLOWPOL.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.PESSO___PESSOALLOWPOL.isVisible"
												v-bind="controls.PESSO___PESSOALLOWPOL.props"
												v-on="controls.PESSO___PESSOALLOWPOL.handlers" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PESSO___PESSOCANEXPOR.isVisible || controls.PESSO___PESSOGROUPMRK.isVisible">
								<q-control-wrapper
									v-show="controls.PESSO___PESSOCANEXPOR.isVisible || controls.PESSO___PESSOGROUPMRK.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.PESSO___PESSOCANEXPOR"
										v-on="controls.PESSO___PESSOCANEXPOR.handlers"
										:loading="controls.PESSO___PESSOCANEXPOR.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.PESSO___PESSOCANEXPOR.isVisible"
												v-bind="controls.PESSO___PESSOCANEXPOR.props"
												v-on="controls.PESSO___PESSOCANEXPOR.handlers" />
										</template>
									</base-input-structure>
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.PESSO___PESSOGROUPMRK"
										v-on="controls.PESSO___PESSOGROUPMRK.handlers"
										:loading="controls.PESSO___PESSOGROUPMRK.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.PESSO___PESSOGROUPMRK.isVisible"
												v-bind="controls.PESSO___PESSOGROUPMRK.props"
												v-on="controls.PESSO___PESSOGROUPMRK.handlers" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.PESSO___PESSOCANEDIT_.isVisible || controls.PESSO___PESSOCANCUT__.isVisible || controls.PESSO___PESSOCANDRAG_.isVisible || controls.PESSO___PESSOCANROT__.isVisible || controls.PESSO___PESSOCANREMOV.isVisible">
								<q-control-wrapper
									v-show="controls.PESSO___PESSOCANEDIT_.isVisible || controls.PESSO___PESSOCANCUT__.isVisible || controls.PESSO___PESSOCANDRAG_.isVisible || controls.PESSO___PESSOCANROT__.isVisible || controls.PESSO___PESSOCANREMOV.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.PESSO___PESSOCANEDIT_"
										v-on="controls.PESSO___PESSOCANEDIT_.handlers"
										:loading="controls.PESSO___PESSOCANEDIT_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.PESSO___PESSOCANEDIT_.isVisible"
												v-bind="controls.PESSO___PESSOCANEDIT_.props"
												v-on="controls.PESSO___PESSOCANEDIT_.handlers" />
										</template>
									</base-input-structure>
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.PESSO___PESSOCANCUT__"
										v-on="controls.PESSO___PESSOCANCUT__.handlers"
										:loading="controls.PESSO___PESSOCANCUT__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.PESSO___PESSOCANCUT__.isVisible"
												v-bind="controls.PESSO___PESSOCANCUT__.props"
												v-on="controls.PESSO___PESSOCANCUT__.handlers" />
										</template>
									</base-input-structure>
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.PESSO___PESSOCANDRAG_"
										v-on="controls.PESSO___PESSOCANDRAG_.handlers"
										:loading="controls.PESSO___PESSOCANDRAG_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.PESSO___PESSOCANDRAG_.isVisible"
												v-bind="controls.PESSO___PESSOCANDRAG_.props"
												v-on="controls.PESSO___PESSOCANDRAG_.handlers" />
										</template>
									</base-input-structure>
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.PESSO___PESSOCANROT__"
										v-on="controls.PESSO___PESSOCANROT__.handlers"
										:loading="controls.PESSO___PESSOCANROT__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.PESSO___PESSOCANROT__.isVisible"
												v-bind="controls.PESSO___PESSOCANROT__.props"
												v-on="controls.PESSO___PESSOCANROT__.handlers" />
										</template>
									</base-input-structure>
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.PESSO___PESSOCANREMOV"
										v-on="controls.PESSO___PESSOCANREMOV.handlers"
										:loading="controls.PESSO___PESSOCANREMOV.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.PESSO___PESSOCANREMOV.isVisible"
												v-bind="controls.PESSO___PESSOCANREMOV.props"
												v-on="controls.PESSO___PESSOCANREMOV.handlers" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container
								v-show="controls.PESSO___PESSOTERRAIN_.isVisible"
								is-large>
								<q-control-wrapper
									v-show="controls.PESSO___PESSOTERRAIN_.isVisible"
									class="row-line-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.PESSO___PESSOTERRAIN_"
										v-on="controls.PESSO___PESSOTERRAIN_.handlers"
										:loading="controls.PESSO___PESSOTERRAIN_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End PESSO___PSEUDTERRAGRP -->
						</q-group-collapsible>
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

	import FormViewModel from './QFormPessoViewModel.js'

	const requiredTextResources = ['QFormPesso', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PESSO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormPesso',

		components: {
			QSeeMorePessoCategcategory: defineAsyncComponent(() => import('@/views/forms/FormPesso/dbedits/PessoCategcategorySeeMore.vue')),
			QSeeMorePessoPais1country: defineAsyncComponent(() => import('@/views/forms/FormPesso/dbedits/PessoPais1countrySeeMore.vue')),
			QSeeMorePessoCmpnydesignat: defineAsyncComponent(() => import('@/views/forms/FormPesso/dbedits/PessoCmpnydesignatSeeMore.vue')),
			QSeeMorePessoRegi1regiao: defineAsyncComponent(() => import('@/views/forms/FormPesso/dbedits/PessoRegi1regiaoSeeMore.vue')),
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
					name: 'PESSO',
					location: 'form-PESSO',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormPesso', false),

				interfaceMetadata: {
					id: 'QFormPesso', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'PESSO',
					route: 'form-PESSO',
					area: 'PESSO',
					primaryKey: 'ValCodpesso',
					designation: computed(() => this.Resources.PERSON10446),
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
					applyBtn: {
						id: 'apply-btn',
						icon: {
							icon: 'apply',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.apply]),
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
					PESSO___PSEUDNOVOGR08: new fieldControlClass.GroupControl({
						id: 'PESSO___PSEUDNOVOGR08',
						name: 'NOVOGR08',
						size: 'block',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: true,
						directChildren: ['PESSO___PSEUDNOVOGR04', 'PESSO___PSEUDNOVOGR02'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					PESSO___PSEUDNOVOGR04: new fieldControlClass.GroupControl({
						id: 'PESSO___PSEUDNOVOGR04',
						name: 'NOVOGR04',
						size: 'medium',
						label: computed(() => this.Resources.PHOTO32097),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR08',
						isCollapsible: false,
						anchored: false,
						directChildren: ['PESSO___PESSOPHOTOGRA'],
						controlLimits: [
						],
					}, this),
					PESSO___PESSOPHOTOGRA: new fieldControlClass.ImageControl({
						modelField: 'ValPhotogra',
						valueChangeEvent: 'fieldChange:pesso.photogra',
						id: 'PESSO___PESSOPHOTOGRA',
						name: 'PHOTOGRA',
						size: 'medium',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR04',
						height: 50,
						width: 100,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO51874)),
						controlLimits: [
						],
					}, this),
					PESSO___PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'PESSO___PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'xxlarge',
						label: computed(() => this.Resources.IDENTIFICATION40793),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR08',
						isCollapsible: false,
						anchored: false,
						directChildren: ['PESSO___PESSOIDFUNCIO', 'PESSO___PESSONAME____', 'PESSO___PESSOGENDER__', 'PESSO___PESSODTNASCIM', 'PESSO___PESSOIDADE___', 'PESSO___PESSOINTERNA_', 'PESSO___PESSOEXTERNA_', 'PESSO___CATEGCATEGORY', 'PESSO___PESSODTULTCAT', 'PESSO___PAIS1COUNTRY_'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					PESSO___PESSOIDFUNCIO: new fieldControlClass.NumberControl({
						modelField: 'ValIdfuncio',
						valueChangeEvent: 'fieldChange:pesso.idfuncio',
						id: 'PESSO___PESSOIDFUNCIO',
						name: 'IDFUNCIO',
						size: 'small',
						label: computed(() => this.Resources.EMPLOYEE_NO_01176),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR02',
						maxIntegers: 6,
						maxDecimals: 0,
						isSequencial: true,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					PESSO___PESSONAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:pesso.name',
						id: 'PESSO___PESSONAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.NAME_23841),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR02',
						maxLength: 85,
						labelId: 'label_PESSO___PESSONAME____',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					PESSO___PESSOGENDER__: new fieldControlClass.ArrayStringControl({
						modelField: 'ValGender',
						valueChangeEvent: 'fieldChange:pesso.gender',
						id: 'PESSO___PESSOGENDER__',
						name: 'GENDER',
						size: 'mini',
						label: computed(() => this.Resources.GENDER44172),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'PESSO___PSEUDNOVOGR02',
						maxLength: 1,
						labelId: 'label_PESSO___PESSOGENDER__',
						arrayName: 'Genero',
						columnNumber: 3,
						controlLimits: [
						],
					}, this),
					PESSO___PESSODTNASCIM: new fieldControlClass.DateControl({
						modelField: 'ValDtnascim',
						valueChangeEvent: 'fieldChange:pesso.dtnascim',
						id: 'PESSO___PESSODTNASCIM',
						name: 'DTNASCIM',
						size: 'small',
						label: computed(() => this.Resources.BIRTH21799),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR02',
						format: 'date',
						controlLimits: [
						],
					}, this),
					PESSO___PESSOIDADE___: new fieldControlClass.NumberControl({
						modelField: 'ValIdade',
						valueChangeEvent: 'fieldChange:pesso.idade',
						id: 'PESSO___PESSOIDADE___',
						name: 'IDADE',
						size: 'mini',
						label: computed(() => this.Resources.AGE28663),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR02',
						isFormulaBlocked: true,
						maxIntegers: 5,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					PESSO___PESSOINTERNA_: new fieldControlClass.BooleanControl({
						modelField: 'ValInterna',
						valueChangeEvent: 'fieldChange:pesso.interna',
						id: 'PESSO___PESSOINTERNA_',
						name: 'INTERNA',
						size: 'mini',
						label: computed(() => this.Resources.INTERN65375),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'PESSO___PSEUDNOVOGR02',
						controlLimits: [
						],
					}, this),
					PESSO___PESSOEXTERNA_: new fieldControlClass.BooleanControl({
						modelField: 'ValExterna',
						valueChangeEvent: 'fieldChange:pesso.externa',
						id: 'PESSO___PESSOEXTERNA_',
						name: 'EXTERNA',
						size: 'small',
						label: computed(() => this.Resources.EXTERNAL13375),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'PESSO___PSEUDNOVOGR02',
						controlLimits: [
						],
					}, this),
					PESSO___CATEGCATEGORY: new fieldControlClass.LookupControl({
						modelField: 'TableCategCategory',
						valueChangeEvent: 'fieldChange:categ.categoria',
						id: 'PESSO___CATEGCATEGORY',
						name: 'CATEGORY',
						size: 'xlarge',
						label: computed(() => this.Resources.CATEGORY18978),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR02',
						isFormulaBlocked: true,
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodcateg',
							dependencyEvent: 'fieldChange:pesso.codcateg'
						},
						dependentFields: () => ({
							set 'categ.codcateg'(value) { vm.model.ValCodcateg.updateValue(value) },
							set 'categ.categoria'(value) { vm.model.TableCategCategory.updateValue(value) },
						}),
						insertEnabled: true,
						supportForm: 'CATEG',
						controlLimits: [
						],
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: [PESSO->INTERNA]==1
								return (this.ValInterna.value ? 1 : 0)===1
							},
							dependencyEvents: ['fieldChange:pesso.interna'],
							isServerRecalc: false,
						},
					}, this),
					PESSO___PESSODTULTCAT: new fieldControlClass.DateControl({
						modelField: 'ValDtultcat',
						valueChangeEvent: 'fieldChange:pesso.dtultcat',
						id: 'PESSO___PESSODTULTCAT',
						name: 'DTULTCAT',
						size: 'small',
						label: computed(() => this.Resources.SINCE47259),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR02',
						isFormulaBlocked: true,
						format: 'date',
						controlLimits: [
						],
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: [PESSO->INTERNA]==1
								return (this.ValInterna.value ? 1 : 0)===1
							},
							dependencyEvents: ['fieldChange:pesso.interna'],
							isServerRecalc: false,
						},
					}, this),
					PESSO___PAIS1COUNTRY_: new fieldControlClass.LookupControl({
						modelField: 'TablePais1Country',
						valueChangeEvent: 'fieldChange:pais1.country',
						id: 'PESSO___PAIS1COUNTRY_',
						name: 'COUNTRY',
						size: 'xxlarge',
						label: computed(() => this.Resources.COUNTRY64133),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR02',
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
							dependencyEvent: 'fieldChange:pesso.codcntry'
						},
						dependentFields: () => ({
							set 'pais1.codcntry'(value) { vm.model.ValCodcntry.updateValue(value) },
							set 'pais1.country'(value) { vm.model.TablePais1Country.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					PESSO___PSEUDNOVOGR11: new fieldControlClass.GroupControl({
						id: 'PESSO___PSEUDNOVOGR11',
						name: 'NOVOGR11',
						size: 'block',
						label: computed(() => this.Resources.SPECIALTIES08113),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: true,
						directChildren: ['PESSO___PSEUDESPECIAL', 'PESSO___PSEUDESPECITL'],
						controlLimits: [
						],
					}, this),
					PESSO___PSEUDESPECIAL: new fieldControlClass.MultipleValuesControl({
						id: 'PESSO___PSEUDESPECIAL',
						name: 'ESPECIAL',
						size: '',
						label: computed(() => this.Resources.SPECIALTIES08113),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR11',
						controller: 'PESSO',
						action: 'Pesso_List_Especial',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValEspecial',
								area: 'SPECI',
								field: 'ESPECIAL',
								label: computed(() => this.Resources.SPECIALTY09304),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 2,
								name: 'ValAreatecn',
								area: 'SPECI',
								field: 'AREATECN',
								label: computed(() => this.Resources.TECHNICAL_AREA50773),
								dataLength: 1,
								scrollData: 1,
								array: computed(() => qProjArrays.QArrayAreatecn.setResources(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayAreatecn.type,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValEspecial',
							serverMode: true,
							pkColumn: 'ValCodespec',
							tableAlias: 'SPECI',
							tableNamePlural: computed(() => this.Resources.SPECIALTIES08113),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.SPECIALTIES08113),
							showAlternatePagination: true,
							rowClickActionInternal: 'selectMultiple',
							showRowsSelectedTotalizer: true,
							permissions: {
							},
							generalCustomActions: [
							],
							MCActions: [
							],
							rowClickAction: {
								id: 'RCA__ESPPE',
								name: '_ESPPE',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									canExecuteAction: vm.applyChanges,
									action: vm.openFormAction,
									type: 'form',
									formName: 'ESPPE',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'ESPPE': {
									fnKeySelector: (row) => row.Fields.ValCodespec,
									isPopup: false
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'ValEspecial',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-SPECI', 'changed-PESSO', 'changed-ESPPE'],
						uuid: 'Pesso_ValEspecial',
						allSelectedRows: 'false',
						modelField: 'List_Especial_SelectedIds',
						valueChangeEvent: 'fieldChange:pseud.List_Especial_SelectedIds',
						modelFieldOptions: 'List_Especial',
						controlLimits: [
						],
					}, this),
					PESSO___PSEUDESPECITL: new fieldControlClass.TableListControl({
						id: 'PESSO___PSEUDESPECITL',
						name: 'ESPECITL',
						size: '',
						label: computed(() => this.Resources.SPECIALTIES08113),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR11',
						controller: 'PESSO',
						action: 'Pesso_ValEspecitl',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Speci.ValEspecial',
								area: 'SPECI',
								field: 'ESPECIAL',
								label: computed(() => this.Resources.SPECIALTY09304),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodespec',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 2,
								name: 'Speci.ValAreatecn',
								area: 'SPECI',
								field: 'AREATECN',
								label: computed(() => this.Resources.TECHNICAL_AREA50773),
								dataLength: 1,
								scrollData: 1,
								array: computed(() => qProjArrays.QArrayAreatecn.setResources(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayAreatecn.type,
								pkColumn: 'ValCodespec',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValEspecitl',
							serverMode: true,
							pkColumn: 'ValCodesppe',
							tableAlias: 'ESPPE',
							tableNamePlural: computed(() => this.Resources.PEOPLE_S_SPECIALTIES40433),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.SPECIALTIES08113),
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
										formName: 'ESPPE',
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
										formName: 'ESPPE',
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
										formName: 'ESPPE',
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
										formName: 'ESPPE',
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
										formName: 'ESPPE',
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
								id: 'RCA__ESPPE',
								name: '_ESPPE',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									canExecuteAction: vm.applyChanges,
									action: vm.openFormAction,
									type: 'form',
									formName: 'ESPPE',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'ESPPE': {
									fnKeySelector: (row) => row.Fields.ValCodesppe,
									isPopup: false
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'Speci.ValEspecial',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-SPECI', 'changed-PESSO', 'changed-ESPPE'],
						uuid: 'Pesso_ValEspecitl',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'pesso'],
								dependencyEvents: ['fieldChange:pesso.codpesso'],
								dependencyField: 'PESSO.CODPESSO',
								fnValueSelector: (model) => model.ValCodpesso.value
							},
						],
					}, this),
					PESSO___PSEUDNOVOGR07: new fieldControlClass.GroupControl({
						id: 'PESSO___PSEUDNOVOGR07',
						name: 'NOVOGR07',
						size: 'block',
						label: computed(() => this.Resources.CONTACT05134),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR06',
						isCollapsible: true,
						anchored: false,
						directChildren: ['PESSO___PSEUDNOVOGR03', 'PESSO___PSEUDNOVOGR09'],
						controlLimits: [
						],
					}, this),
					PESSO___PSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'PESSO___PSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'xxlarge',
						label: computed(() => this.Resources.MAIN_CONTACT60524),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR07',
						isCollapsible: false,
						anchored: false,
						directChildren: ['PESSO___PESSOTELEPHON', 'PESSO___PESSOEMAIL___', 'PESSO___PESSOEMAIL2__'],
						controlLimits: [
						],
					}, this),
					PESSO___PESSOTELEPHON: new fieldControlClass.StringControl({
						modelField: 'ValTelephon',
						valueChangeEvent: 'fieldChange:pesso.telephon',
						id: 'PESSO___PESSOTELEPHON',
						name: 'TELEPHON',
						size: 'medium',
						label: computed(() => this.Resources.TELEPHONE28697),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR03',
						maxLength: 20,
						labelId: 'label_PESSO___PESSOTELEPHON',
						controlLimits: [
						],
					}, this),
					PESSO___PESSOEMAIL___: new fieldControlClass.StringControl({
						modelField: 'ValEmail',
						valueChangeEvent: 'fieldChange:pesso.email',
						id: 'PESSO___PESSOEMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						label: computed(() => this.Resources.EMAIL_44228),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR03',
						maxLength: 254,
						labelId: 'label_PESSO___PESSOEMAIL___',
						controlLimits: [
						],
					}, this),
					PESSO___PSEUDNOVOGR09: new fieldControlClass.GroupControl({
						id: 'PESSO___PSEUDNOVOGR09',
						name: 'NOVOGR09',
						size: 'xxlarge',
						label: computed(() => this.Resources.ALL_CONTACTS25646),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR07',
						isCollapsible: false,
						anchored: false,
						directChildren: ['PESSO___PSEUDCONTACTO'],
						controlLimits: [
						],
					}, this),
					PESSO___PSEUDCONTACTO: new fieldControlClass.TableListControl({
						id: 'PESSO___PSEUDCONTACTO',
						name: 'CONTACTO',
						size: '',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR09',
						controller: 'PESSO',
						action: 'Pesso_ValContacto',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Tpcon.ValTipocont',
								area: 'TPCON',
								field: 'TIPOCONT',
								label: computed(() => this.Resources.GENUS37471),
								dataLength: 50,
								scrollData: 20,
								pkColumn: 'ValCodtpcon',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValContacto',
								area: 'CONTA',
								field: 'CONTACTO',
								label: computed(() => this.Resources.CONTACT59247),
								dataLength: 254,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValContacto',
							serverMode: true,
							pkColumn: 'ValCodconta',
							tableAlias: 'CONTA',
							tableNamePlural: computed(() => this.Resources.CONTACTS55742),
							viewManagement: '',
							showLimitsInfo: true,
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
										formName: 'CONTA',
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
										formName: 'CONTA',
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
										formName: 'CONTA',
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
										formName: 'CONTA',
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
										formName: 'CONTA',
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
								id: 'RCA__CONTA',
								name: '_CONTA',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									canExecuteAction: vm.applyChanges,
									action: vm.openFormAction,
									type: 'form',
									formName: 'CONTA',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'CONTA': {
									fnKeySelector: (row) => row.Fields.ValCodconta,
									isPopup: true
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'Tpcon.ValTipocont',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-GENRE', 'changed-TPCON', 'changed-CONTA', 'changed-PESSO'],
						uuid: 'Pesso_ValContacto',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'pesso'],
								dependencyEvents: ['fieldChange:pesso.codpesso'],
								dependencyField: 'PESSO.CODPESSO',
								fnValueSelector: (model) => model.ValCodpesso.value
							},
						],
					}, this),
					PESSO___PSEUDNOVOGR05: new fieldControlClass.GroupControl({
						id: 'PESSO___PSEUDNOVOGR05',
						name: 'NOVOGR05',
						size: 'block',
						label: computed(() => this.Resources.CAREER41490),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR06',
						isCollapsible: true,
						anchored: true,
						directChildren: ['PESSO___PSEUDNOVOGR01', 'PESSO___PSEUDNOVOGR10'],
						controlLimits: [
						],
					}, this),
					PESSO___PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'PESSO___PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						label: computed(() => this.Resources.COMPANY52963),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR05',
						isCollapsible: false,
						anchored: false,
						directChildren: ['PESSO___PSEUDNOVOGR13', 'PESSO___REGI1REGIAO__'],
						controlLimits: [
						],
					}, this),
					PESSO___PSEUDNOVOGR13: new fieldControlClass.GroupControl({
						id: 'PESSO___PSEUDNOVOGR13',
						name: 'NOVOGR13',
						size: 'block',
						label: computed(() => this.Resources.C_D18888),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR01',
						isCollapsible: false,
						anchored: true,
						directChildren: ['PESSO___CMPNYDESIGNAT', 'PESSO___CNTRYCOUNTRY_'],
						controlLimits: [
						],
					}, this),
					PESSO___CMPNYDESIGNAT: new fieldControlClass.LookupControl({
						modelField: 'TableCmpnyDesignat',
						valueChangeEvent: 'fieldChange:cmpny.designat',
						id: 'PESSO___CMPNYDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.COMPANY52963),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR13',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodempre',
							dependencyEvent: 'fieldChange:pesso.codempre'
						},
						dependentFields: () => ({
							set 'cmpny.codempre'(value) { vm.model.ValCodempre.updateValue(value) },
							set 'cmpny.designat'(value) { vm.model.TableCmpnyDesignat.updateValue(value) },
							set 'cmpny.headloc'(value) { vm.model.CmpnyValHeadloc.updateValue(value) },
							set 'pesso.codpaise'(value) { vm.model.ValCodpaise.updateValue(value) },
							set 'cntry.codcntry'(value) { vm.model.ValCodpaise.updateValue(value) },
							set 'cntry.country'(value) { vm.model.CntryValCountry.updateValue(value) },
						}),
						insertEnabled: true,
						supportForm: 'EMPRE',
						controlLimits: [
						],
					}, this),
					PESSO___CNTRYCOUNTRY_: new fieldControlClass.StringControl({
						modelField: 'CntryValCountry',
						valueChangeEvent: 'fieldChange:cntry.country',
						dependentModelField: 'ValCodpaise',
						dependentChangeEvent: 'fieldChange:pesso.codpaise',
						id: 'PESSO___CNTRYCOUNTRY_',
						name: 'COUNTRY',
						size: 'xxlarge',
						label: computed(() => this.Resources.COUNTRY64133),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR13',
						maxLength: 90,
						labelId: 'label_PESSO___CNTRYCOUNTRY_',
						controlLimits: [
						],
					}, this),
					PESSO___REGI1REGIAO__: new fieldControlClass.LookupControl({
						modelField: 'TableRegi1Regiao',
						valueChangeEvent: 'fieldChange:regi1.regiao',
						id: 'PESSO___REGI1REGIAO__',
						name: 'REGIAO',
						size: 'xlarge',
						label: computed(() => this.Resources.REGION_OF_THE_PERSON14756),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR01',
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
							dependencyEvent: 'fieldChange:pesso.codregia'
						},
						dependentFields: () => ({
							set 'regi1.codregia'(value) { vm.model.ValCodregia.updateValue(value) },
							set 'regi1.regiao'(value) { vm.model.TableRegi1Regiao.updateValue(value) },
						}),
						controlLimits: [
							{
								identifier: ['pais1', 'pesso.codcntry'],
								dependencyEvents: ['fieldChange:pesso.codcntry'],
								dependencyField: 'PESSO.CODCNTRY',
								fnValueSelector: (model) => model.ValCodcntry.value
							},
						],
					}, this),
					PESSO___PSEUDNOVOGR10: new fieldControlClass.GroupControl({
						id: 'PESSO___PSEUDNOVOGR10',
						name: 'NOVOGR10',
						size: 'block',
						label: computed(() => this.Resources.EVOLUTION63463),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR05',
						isCollapsible: false,
						anchored: false,
						directChildren: ['PESSO___PSEUDEVOLUCAO'],
						controlLimits: [
						],
					}, this),
					PESSO___PSEUDEVOLUCAO: new fieldControlClass.TableListControl({
						id: 'PESSO___PSEUDEVOLUCAO',
						name: 'EVOLUCAO',
						size: '',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR10',
						controller: 'PESSO',
						action: 'Pesso_ValEvolucao',
						hasDependencies: true,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValSince',
								area: 'EVCAT',
								field: 'SINCE',
								label: computed(() => this.Resources.SINCE47259),
								scrollData: 8,
								dateTimeType: 'date',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'Cate1.ValCategoria',
								area: 'CATE1',
								field: 'CATEGORIA',
								label: computed(() => this.Resources.CATEGORY18978),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodcateg',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 3,
								name: 'ValFimperio',
								area: 'EVCAT',
								field: 'FIMPERIO',
								label: computed(() => this.Resources.END_OF_PERIOD44616),
								scrollData: 8,
								dateTimeType: 'date',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValObservat',
								area: 'EVCAT',
								field: 'OBSERVAT',
								label: computed(() => this.Resources.OBSERVATION37880),
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValEvolucao',
							serverMode: true,
							pkColumn: 'ValCodprogr',
							tableAlias: 'EVCAT',
							tableNamePlural: computed(() => this.Resources.EVOLUTION_IN_CATEGOR19803),
							viewManagement: '',
							showLimitsInfo: true,
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
										formName: 'EVCAT',
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
										formName: 'EVCAT',
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
										formName: 'EVCAT',
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
										formName: 'EVCAT',
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
										formName: 'EVCAT',
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
								id: 'RCA__EVCAT',
								name: '_EVCAT',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									canExecuteAction: vm.applyChanges,
									action: vm.openFormAction,
									type: 'form',
									formName: 'EVCAT',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'EVCAT': {
									fnKeySelector: (row) => row.Fields.ValCodprogr,
									isPopup: false
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'ValSince',
								sortOrder: 'desc'
							}
						},
						globalEvents: ['changed-PESSO', 'changed-EVCAT', 'changed-CATE1'],
						uuid: 'Pesso_ValEvolucao',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'pesso'],
								dependencyEvents: ['fieldChange:pesso.codpesso'],
								dependencyField: 'PESSO.CODPESSO',
								fnValueSelector: (model) => model.ValCodpesso.value
							},
						],
					}, this),
					PESSO___PSEUDNOVOGR06: new fieldControlClass.AccordionControl({
						id: 'PESSO___PSEUDNOVOGR06',
						name: 'NOVOGR06',
						size: 'block',
						label: computed(() => this.Resources.ACCORDION01950),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['PESSO___PSEUDNOVOGR07', 'PESSO___PSEUDNOVOGR05'],
						controlLimits: [
						],
					}, this),
					PESSO___PSEUDOBRIGATO: new fieldControlClass.BaseControl({
						id: 'PESSO___PSEUDOBRIGATO',
						name: 'OBRIGATO',
						size: 'xxlarge',
						hasLabel: false,
						label: computed(() => this.Resources.AT_REQUIRED65277),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						supportsHtml: true,
						controlLimits: [
						],
					}, this),
					PESSO___PESSOEMAIL2__: new fieldControlClass.StringControl({
						modelField: 'ValEmail2',
						valueChangeEvent: 'fieldChange:pesso.email2',
						id: 'PESSO___PESSOEMAIL2__',
						name: 'EMAIL2',
						size: 'xxlarge',
						label: computed(() => this.Resources.ALTERNATIVE_EMAIL17444),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDNOVOGR03',
						maxLength: 254,
						labelId: 'label_PESSO___PESSOEMAIL2__',
						controlLimits: [
						],
					}, this),
					PESSO___PSEUDTERRAGRP: new fieldControlClass.GroupControl({
						id: 'PESSO___PSEUDTERRAGRP',
						name: 'TERRAGRP',
						size: 'block',
						label: computed(() => this.Resources.TERRAIN43857),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: true,
						anchored: false,
						directChildren: ['PESSO___PESSOEXTQUERY', 'PESSO___PESSOZOOMLVL_', 'PESSO___PESSOEXTMINZM', 'PESSO___PESSOMAPHEIGH', 'PESSO___PESSOOUTWEIGH', 'PESSO___PESSOLINECLR_', 'PESSO___PESSOPOLYCLR_', 'PESSO___PESSODRAWMRK_', 'PESSO___PESSOALLOWLIN', 'PESSO___PESSOALLOWPOL', 'PESSO___PESSOCANEXPOR', 'PESSO___PESSOGROUPMRK', 'PESSO___PESSOCANEDIT_', 'PESSO___PESSOCANCUT__', 'PESSO___PESSOCANDRAG_', 'PESSO___PESSOCANROT__', 'PESSO___PESSOCANREMOV', 'PESSO___PESSOTERRAIN_'],
						controlLimits: [
						],
					}, this),
					PESSO___PESSOEXTQUERY: new fieldControlClass.StringControl({
						modelField: 'ValExtquery',
						valueChangeEvent: 'fieldChange:pesso.extquery',
						id: 'PESSO___PESSOEXTQUERY',
						name: 'EXTQUERY',
						size: 'block',
						label: computed(() => this.Resources.QUERY_FOR_EXTERNAL_A51761),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDTERRAGRP',
						maxLength: 250,
						labelId: 'label_PESSO___PESSOEXTQUERY',
						controlLimits: [
						],
					}, this),
					PESSO___PESSOZOOMLVL_: new fieldControlClass.NumberControl({
						modelField: 'ValZoomlvl',
						valueChangeEvent: 'fieldChange:pesso.zoomlvl',
						id: 'PESSO___PESSOZOOMLVL_',
						name: 'ZOOMLVL',
						size: 'small',
						label: computed(() => this.Resources.ZOOM_LEVEL17268),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDTERRAGRP',
						maxIntegers: 2,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					PESSO___PESSOEXTMINZM: new fieldControlClass.NumberControl({
						modelField: 'ValExtminzm',
						valueChangeEvent: 'fieldChange:pesso.extminzm',
						id: 'PESSO___PESSOEXTMINZM',
						name: 'EXTMINZM',
						size: 'xlarge',
						label: computed(() => this.Resources.MINIMUM_ZOOM_TO_LOAD08509),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDTERRAGRP',
						maxIntegers: 2,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					PESSO___PESSOMAPHEIGH: new fieldControlClass.StringControl({
						modelField: 'ValMapheigh',
						valueChangeEvent: 'fieldChange:pesso.mapheigh',
						id: 'PESSO___PESSOMAPHEIGH',
						name: 'MAPHEIGH',
						size: 'xlarge',
						label: computed(() => this.Resources.MAP_HEIGHT06476),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDTERRAGRP',
						maxLength: 50,
						labelId: 'label_PESSO___PESSOMAPHEIGH',
						controlLimits: [
						],
					}, this),
					PESSO___PESSOOUTWEIGH: new fieldControlClass.NumberControl({
						modelField: 'ValOutweigh',
						valueChangeEvent: 'fieldChange:pesso.outweigh',
						id: 'PESSO___PESSOOUTWEIGH',
						name: 'OUTWEIGH',
						size: 'medium',
						label: computed(() => this.Resources.OUTLINE_WEIGHT25236),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDTERRAGRP',
						maxIntegers: 2,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					PESSO___PESSOLINECLR_: new fieldControlClass.StringControl({
						modelField: 'ValLineclr',
						valueChangeEvent: 'fieldChange:pesso.lineclr',
						id: 'PESSO___PESSOLINECLR_',
						name: 'LINECLR',
						size: 'xlarge',
						label: computed(() => this.Resources.POLYLINE_COLOR11664),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDTERRAGRP',
						maxLength: 50,
						labelId: 'label_PESSO___PESSOLINECLR_',
						controlLimits: [
						],
					}, this),
					PESSO___PESSOPOLYCLR_: new fieldControlClass.StringControl({
						modelField: 'ValPolyclr',
						valueChangeEvent: 'fieldChange:pesso.polyclr',
						id: 'PESSO___PESSOPOLYCLR_',
						name: 'POLYCLR',
						size: 'xlarge',
						label: computed(() => this.Resources.POLYGON_COLOR32161),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDTERRAGRP',
						maxLength: 50,
						labelId: 'label_PESSO___PESSOPOLYCLR_',
						controlLimits: [
						],
					}, this),
					PESSO___PESSODRAWMRK_: new fieldControlClass.BooleanControl({
						modelField: 'ValDrawmrk',
						valueChangeEvent: 'fieldChange:pesso.drawmrk',
						id: 'PESSO___PESSODRAWMRK_',
						name: 'DRAWMRK',
						size: 'xlarge',
						label: computed(() => this.Resources.ALLOW_DRAWING_MARKER56732),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'PESSO___PSEUDTERRAGRP',
						controlLimits: [
						],
					}, this),
					PESSO___PESSOALLOWLIN: new fieldControlClass.BooleanControl({
						modelField: 'ValAllowlin',
						valueChangeEvent: 'fieldChange:pesso.allowlin',
						id: 'PESSO___PESSOALLOWLIN',
						name: 'ALLOWLIN',
						size: 'xlarge',
						label: computed(() => this.Resources.ALLOW_DRAWING_POLYLI25703),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'PESSO___PSEUDTERRAGRP',
						controlLimits: [
						],
					}, this),
					PESSO___PESSOALLOWPOL: new fieldControlClass.BooleanControl({
						modelField: 'ValAllowpol',
						valueChangeEvent: 'fieldChange:pesso.allowpol',
						id: 'PESSO___PESSOALLOWPOL',
						name: 'ALLOWPOL',
						size: 'xlarge',
						label: computed(() => this.Resources.ALLOW_DRAWING_POLYGO46480),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'PESSO___PSEUDTERRAGRP',
						controlLimits: [
						],
					}, this),
					PESSO___PESSOCANEXPOR: new fieldControlClass.BooleanControl({
						modelField: 'ValCanexpor',
						valueChangeEvent: 'fieldChange:pesso.canexpor',
						id: 'PESSO___PESSOCANEXPOR',
						name: 'CANEXPOR',
						size: 'xlarge',
						label: computed(() => this.Resources.ALLOW_EXPORTING_MAP27916),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'PESSO___PSEUDTERRAGRP',
						controlLimits: [
						],
					}, this),
					PESSO___PESSOGROUPMRK: new fieldControlClass.BooleanControl({
						modelField: 'ValGroupmrk',
						valueChangeEvent: 'fieldChange:pesso.groupmrk',
						id: 'PESSO___PESSOGROUPMRK',
						name: 'GROUPMRK',
						size: 'large',
						label: computed(() => this.Resources.GROUP_MARKERS_IN_CLU31341),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'PESSO___PSEUDTERRAGRP',
						controlLimits: [
						],
					}, this),
					PESSO___PESSOCANEDIT_: new fieldControlClass.BooleanControl({
						modelField: 'ValCanedit',
						valueChangeEvent: 'fieldChange:pesso.canedit',
						id: 'PESSO___PESSOCANEDIT_',
						name: 'CANEDIT',
						size: 'xxlarge',
						label: computed(() => this.Resources.ALLOW_FEATURE_EDITIN16439),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'PESSO___PSEUDTERRAGRP',
						controlLimits: [
						],
					}, this),
					PESSO___PESSOCANCUT__: new fieldControlClass.BooleanControl({
						modelField: 'ValCancut',
						valueChangeEvent: 'fieldChange:pesso.cancut',
						id: 'PESSO___PESSOCANCUT__',
						name: 'CANCUT',
						size: 'xxlarge',
						label: computed(() => this.Resources.ALLOW_FEATURE_CUTTIN10746),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'PESSO___PSEUDTERRAGRP',
						controlLimits: [
						],
					}, this),
					PESSO___PESSOCANDRAG_: new fieldControlClass.BooleanControl({
						modelField: 'ValCandrag',
						valueChangeEvent: 'fieldChange:pesso.candrag',
						id: 'PESSO___PESSOCANDRAG_',
						name: 'CANDRAG',
						size: 'xxlarge',
						label: computed(() => this.Resources.ALLOW_FEATURE_DRAGGI09054),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'PESSO___PSEUDTERRAGRP',
						controlLimits: [
						],
					}, this),
					PESSO___PESSOCANROT__: new fieldControlClass.BooleanControl({
						modelField: 'ValCanrot',
						valueChangeEvent: 'fieldChange:pesso.canrot',
						id: 'PESSO___PESSOCANROT__',
						name: 'CANROT',
						size: 'xlarge',
						label: computed(() => this.Resources.ALLOW_FEATURE_ROTATI56653),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'PESSO___PSEUDTERRAGRP',
						controlLimits: [
						],
					}, this),
					PESSO___PESSOCANREMOV: new fieldControlClass.BooleanControl({
						modelField: 'ValCanremov',
						valueChangeEvent: 'fieldChange:pesso.canremov',
						id: 'PESSO___PESSOCANREMOV',
						name: 'CANREMOV',
						size: 'xxlarge',
						label: computed(() => this.Resources.ALLOW_FEATURE_REMOVA13844),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'PESSO___PSEUDTERRAGRP',
						controlLimits: [
						],
					}, this),
					PESSO___PESSOTERRAIN_: new fieldControlClass.FieldSpecialRenderingControl({
						modelField: 'ValTerrain',
						valueChangeEvent: 'fieldChange:pesso.terrain',
						isGeographicShape: true,
						isEuclideanCoord: false,
						id: 'PESSO___PESSOTERRAIN_',
						name: 'TERRAIN',
						size: 'block',
						label: computed(() => this.Resources.TERRAIN43857),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO___PSEUDTERRAGRP',
						viewModes: [
							{
								id: 'MAP',
								type: 'map',
								subtype: 'leaflet-map',
								label: computed(() => this.Resources.MAPA24527),
								order: 1,
								implicitVariable: 'geographicData',
								implicitIsMultiple: true,
								mappingVariables: readonly({
									markerDescription: {
										allowsMultiple: true,
										sources: [
											'PESSO.TELEPHON',
											'PESSO.NAME',
										]
									},
								}),
								styleVariables: {
									zoomLevel: {
										rawValue: undefined,
										dataType: 'Numeric',
										source: 'PESSO.ZOOMLVL',
										isMapped: true
									},
									minZoom: {
										rawValue: 5,
										isMapped: false
									},
									maxZoom: {
										rawValue: 18,
										isMapped: false
									},
									zoomWithCtrl: {
										rawValue: true,
										isMapped: false
									},
									fitZoom: {
										rawValue: true,
										isMapped: false
									},
									zoomDelta: {
										rawValue: 1,
										isMapped: false
									},
									boundSouthWest: {
										rawValue: undefined,
										isMapped: false
									},
									boundNorthEast: {
										rawValue: undefined,
										isMapped: false
									},
									disableSearch: {
										rawValue: false,
										isMapped: false
									},
									disableControls: {
										rawValue: false,
										isMapped: false
									},
									centerCoord: {
										rawValue: undefined,
										dataType: 'Geographic',
										source: 'CMPNY.HEADLOC',
										isMapped: true
									},
									showSourcesInDescription: {
										rawValue: true,
										isMapped: false
									},
									collapseLayerOptions: {
										rawValue: false,
										isMapped: false
									},
									crs: {
										rawValue: 'EPSG:4326',
										isMapped: false
									},
									mapHeight: {
										rawValue: undefined,
										dataType: 'Text',
										source: 'PESSO.MAPHEIGH',
										isMapped: true
									},
									allowMarkers: {
										rawValue: undefined,
										dataType: 'Boolean',
										source: 'PESSO.DRAWMRK',
										isMapped: true
									},
									allowPolylines: {
										rawValue: undefined,
										dataType: 'Boolean',
										source: 'PESSO.ALLOWLIN',
										isMapped: true
									},
									allowPolygons: {
										rawValue: undefined,
										dataType: 'Boolean',
										source: 'PESSO.ALLOWPOL',
										isMapped: true
									},
									allowEdit: {
										rawValue: undefined,
										dataType: 'Boolean',
										source: 'PESSO.CANEDIT',
										isMapped: true
									},
									allowDrag: {
										rawValue: undefined,
										dataType: 'Boolean',
										source: 'PESSO.CANDRAG',
										isMapped: true
									},
									allowCutting: {
										rawValue: undefined,
										dataType: 'Boolean',
										source: 'PESSO.CANCUT',
										isMapped: true
									},
									allowRemoval: {
										rawValue: undefined,
										dataType: 'Boolean',
										source: 'PESSO.CANREMOV',
										isMapped: true
									},
									allowRotate: {
										rawValue: undefined,
										dataType: 'Boolean',
										source: 'PESSO.CANROT',
										isMapped: true
									},
									shapeOutlineWeight: {
										rawValue: undefined,
										dataType: 'Numeric',
										source: 'PESSO.OUTWEIGH',
										isMapped: true
									},
									polylineColor: {
										rawValue: undefined,
										dataType: 'Text',
										source: 'PESSO.LINECLR',
										isMapped: true
									},
									polygonColor: {
										rawValue: undefined,
										dataType: 'Text',
										source: 'PESSO.POLYCLR',
										isMapped: true
									},
									circleColor: {
										rawValue: '#f53505',
										isMapped: false
									},
									groupMarkersInCluster: {
										rawValue: undefined,
										dataType: 'Boolean',
										source: 'PESSO.GROUPMRK',
										isMapped: true
									},
									allowExporting: {
										rawValue: undefined,
										dataType: 'Boolean',
										source: 'PESSO.CANEXPOR',
										isMapped: true
									},
									backgroundOverlay: {
										rawValue: 'Satellite',
										isMapped: false
									},
									openPopupOnHover: {
										rawValue: false,
										isMapped: false
									},
								},
								groups: {
									externalLayer: [
										{
											externalLayerUrl: {
												type: 'STYLE',
												rawValue: undefined,
												dataType: 'Text',
												source: 'GLOB.APIURL',
												isMapped: true
											},
											externalLayerMinZoomToLoad: {
												type: 'STYLE',
												rawValue: undefined,
												dataType: 'Numeric',
												source: 'PESSO.EXTMINZM',
												isMapped: true
											},
										},
									],
								}
							},
						],
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
					'PESSO___PSEUDNOVOGR08',
					'PESSO___PSEUDNOVOGR04',
					'PESSO___PSEUDNOVOGR02',
					'PESSO___PSEUDNOVOGR11',
					'PESSO___PSEUDNOVOGR06',
					'PESSO___PSEUDNOVOGR07',
					'PESSO___PSEUDNOVOGR03',
					'PESSO___PSEUDNOVOGR09',
					'PESSO___PSEUDNOVOGR05',
					'PESSO___PSEUDNOVOGR01',
					'PESSO___PSEUDNOVOGR13',
					'PESSO___PSEUDNOVOGR10',
					'PESSO___PSEUDTERRAGRP',
				]),

				tableFields: readonly([
					'PESSO___PSEUDESPECIAL',
					'PESSO___PSEUDESPECITL',
					'PESSO___PSEUDCONTACTO',
					'PESSO___PSEUDEVOLUCAO',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Categ: {
						get ValCategoria() { return vm.model.TableCategCategory.value },
						set ValCategoria(value) { vm.model.TableCategCategory.updateValue(value) },
					},
					Cmpny: {
						get ValDesignat() { return vm.model.TableCmpnyDesignat.value },
						set ValDesignat(value) { vm.model.TableCmpnyDesignat.updateValue(value) },
						get ValHeadloc() { return vm.model.CmpnyValHeadloc.value },
						set ValHeadloc(value) { vm.model.CmpnyValHeadloc.updateValue(value) },
					},
					Cntry: {
						get ValCountry() { return vm.model.CntryValCountry.value },
						set ValCountry(value) { vm.model.CntryValCountry.updateValue(value) },
					},
					Glob: {
						get ValApiurl() { return vm.model.ValApiurl.value },
						set ValApiurl(value) { vm.model.ValApiurl.updateValue(value) },
					},
					Pais1: {
						get ValCountry() { return vm.model.TablePais1Country.value },
						set ValCountry(value) { vm.model.TablePais1Country.updateValue(value) },
					},
					Pesso: {
						get ValAllowlin() { return vm.model.ValAllowlin.value },
						set ValAllowlin(value) { vm.model.ValAllowlin.updateValue(value) },
						get ValAllowpol() { return vm.model.ValAllowpol.value },
						set ValAllowpol(value) { vm.model.ValAllowpol.updateValue(value) },
						get ValCancut() { return vm.model.ValCancut.value },
						set ValCancut(value) { vm.model.ValCancut.updateValue(value) },
						get ValCandrag() { return vm.model.ValCandrag.value },
						set ValCandrag(value) { vm.model.ValCandrag.updateValue(value) },
						get ValCanedit() { return vm.model.ValCanedit.value },
						set ValCanedit(value) { vm.model.ValCanedit.updateValue(value) },
						get ValCanexpor() { return vm.model.ValCanexpor.value },
						set ValCanexpor(value) { vm.model.ValCanexpor.updateValue(value) },
						get ValCanremov() { return vm.model.ValCanremov.value },
						set ValCanremov(value) { vm.model.ValCanremov.updateValue(value) },
						get ValCanrot() { return vm.model.ValCanrot.value },
						set ValCanrot(value) { vm.model.ValCanrot.updateValue(value) },
						get ValCodcateg() { return vm.model.ValCodcateg.value },
						set ValCodcateg(value) { vm.model.ValCodcateg.updateValue(value) },
						get ValCodcntry() { return vm.model.ValCodcntry.value },
						set ValCodcntry(value) { vm.model.ValCodcntry.updateValue(value) },
						get ValCodempre() { return vm.model.ValCodempre.value },
						set ValCodempre(value) { vm.model.ValCodempre.updateValue(value) },
						get ValCodpaise() { return vm.model.ValCodpaise.value },
						set ValCodpaise(value) { vm.model.ValCodpaise.updateValue(value) },
						get ValCodregia() { return vm.model.ValCodregia.value },
						set ValCodregia(value) { vm.model.ValCodregia.updateValue(value) },
						get ValDrawmrk() { return vm.model.ValDrawmrk.value },
						set ValDrawmrk(value) { vm.model.ValDrawmrk.updateValue(value) },
						get ValDtnascim() { return vm.model.ValDtnascim.value },
						set ValDtnascim(value) { vm.model.ValDtnascim.updateValue(value) },
						get ValDtultcat() { return vm.model.ValDtultcat.value },
						set ValDtultcat(value) { vm.model.ValDtultcat.updateValue(value) },
						get ValEmail() { return vm.model.ValEmail.value },
						set ValEmail(value) { vm.model.ValEmail.updateValue(value) },
						get ValEmail2() { return vm.model.ValEmail2.value },
						set ValEmail2(value) { vm.model.ValEmail2.updateValue(value) },
						get ValExterna() { return vm.model.ValExterna.value },
						set ValExterna(value) { vm.model.ValExterna.updateValue(value) },
						get ValExtminzm() { return vm.model.ValExtminzm.value },
						set ValExtminzm(value) { vm.model.ValExtminzm.updateValue(value) },
						get ValExtquery() { return vm.model.ValExtquery.value },
						set ValExtquery(value) { vm.model.ValExtquery.updateValue(value) },
						get ValGender() { return vm.model.ValGender.value },
						set ValGender(value) { vm.model.ValGender.updateValue(value) },
						get ValGroupmrk() { return vm.model.ValGroupmrk.value },
						set ValGroupmrk(value) { vm.model.ValGroupmrk.updateValue(value) },
						get ValIdade() { return vm.model.ValIdade.value },
						set ValIdade(value) { vm.model.ValIdade.updateValue(value) },
						get ValIdfuncio() { return vm.model.ValIdfuncio.value },
						set ValIdfuncio(value) { vm.model.ValIdfuncio.updateValue(value) },
						get ValInterna() { return vm.model.ValInterna.value },
						set ValInterna(value) { vm.model.ValInterna.updateValue(value) },
						get ValLineclr() { return vm.model.ValLineclr.value },
						set ValLineclr(value) { vm.model.ValLineclr.updateValue(value) },
						get ValMapheigh() { return vm.model.ValMapheigh.value },
						set ValMapheigh(value) { vm.model.ValMapheigh.updateValue(value) },
						get ValName() { return vm.model.ValName.value },
						set ValName(value) { vm.model.ValName.updateValue(value) },
						get ValOutweigh() { return vm.model.ValOutweigh.value },
						set ValOutweigh(value) { vm.model.ValOutweigh.updateValue(value) },
						get ValPhotogra() { return vm.model.ValPhotogra.value },
						set ValPhotogra(value) { vm.model.ValPhotogra.updateValue(value) },
						get ValPolyclr() { return vm.model.ValPolyclr.value },
						set ValPolyclr(value) { vm.model.ValPolyclr.updateValue(value) },
						get ValTelephon() { return vm.model.ValTelephon.value },
						set ValTelephon(value) { vm.model.ValTelephon.updateValue(value) },
						get ValTerrain() { return vm.model.ValTerrain.value },
						set ValTerrain(value) { vm.model.ValTerrain.updateValue(value) },
						get ValZoomlvl() { return vm.model.ValZoomlvl.value },
						set ValZoomlvl(value) { vm.model.ValZoomlvl.updateValue(value) },
					},
					Regi1: {
						get ValRegiao() { return vm.model.TableRegi1Regiao.value },
						set ValRegiao(value) { vm.model.TableRegi1Regiao.updateValue(value) },
					},
					keys: {
						/** The primary key of the PESSO table */
						get pesso() { return vm.model.ValCodpesso },
						/** The foreign key to the CMPNY table */
						get cmpny() { return vm.model.ValCodempre },
						/** The foreign key to the CATEG table */
						get categ() { return vm.model.ValCodcateg },
						/** The foreign key to the CNTRY table */
						get cntry() { return vm.model.ValCodpaise },
						/** The foreign key to the PAIS1 table */
						get pais1() { return vm.model.ValCodcntry },
						/** The foreign key to the REGI1 table */
						get regi1() { return vm.model.ValCodregia },
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
// USE /[MANUAL GQT FORM_CODEJS PESSO]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS PESSO]/
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
// USE /[MANUAL GQT FORM_LOADED_JS PESSO]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS PESSO]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS PESSO]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS PESSO]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS PESSO]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS PESSO]/
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
// USE /[MANUAL GQT AFTER_DEL_JS PESSO]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS PESSO]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS PESSO]/
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
// USE /[MANUAL GQT DLGUPDT PESSO]/
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
// USE /[MANUAL GQT CTRLBLR PESSO]/
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
// USE /[MANUAL GQT CTRLUPD PESSO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS PESSO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
			'controls.PESSO___PSEUDESPECIAL.rowsSelected': {
				handler()
				{
					const value = this.rowKeyHashTableToArray(this.controls.PESSO___PSEUDESPECIAL.rowsSelected)
					this.model.List_Especial_SelectedIds.updateValue(value)
				},
				deep: true
			},
		}
	}
</script>
