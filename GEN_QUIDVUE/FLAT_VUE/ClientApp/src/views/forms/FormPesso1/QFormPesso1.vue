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
			data-key="PESSO1"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container
					v-show="controls.PESSO1__PSEUDNOVOGR08.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.PESSO1__PSEUDNOVOGR08.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="PESSO1__PSEUDNOVOGR08"
							v-bind="controls.PESSO1__PSEUDNOVOGR08"
							no-border
							:is-visible="controls.PESSO1__PSEUDNOVOGR08.isVisible">
							<!-- Start PESSO1__PSEUDNOVOGR08 -->
							<q-row-container v-show="controls.PESSO1__PSEUDNOVOGR04.isVisible || controls.PESSO1__PSEUDNOVOGR02.isVisible">
								<q-control-wrapper
									v-show="controls.PESSO1__PSEUDNOVOGR04.isVisible || controls.PESSO1__PSEUDNOVOGR02.isVisible"
									class="control-join-group">
									<q-group-box-container
										id="PESSO1__PSEUDNOVOGR04"
										v-bind="controls.PESSO1__PSEUDNOVOGR04"
										:is-visible="controls.PESSO1__PSEUDNOVOGR04.isVisible">
										<!-- Start PESSO1__PSEUDNOVOGR04 -->
										<q-row-container v-show="controls.PESSO1__PESSOPHOTOGRA.isVisible">
											<q-control-wrapper
												v-show="controls.PESSO1__PESSOPHOTOGRA.isVisible"
												class="control-join-group">
												<base-input-structure
													class="q-image"
													v-bind="controls.PESSO1__PESSOPHOTOGRA"
													v-on="controls.PESSO1__PESSOPHOTOGRA.handlers"
													:loading="controls.PESSO1__PESSOPHOTOGRA.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-image
														v-if="controls.PESSO1__PESSOPHOTOGRA.isVisible"
														v-bind="controls.PESSO1__PESSOPHOTOGRA.props"
														v-on="controls.PESSO1__PESSOPHOTOGRA.handlers" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<!-- End PESSO1__PSEUDNOVOGR04 -->
									</q-group-box-container>
									<q-group-box-container
										id="PESSO1__PSEUDNOVOGR02"
										v-bind="controls.PESSO1__PSEUDNOVOGR02"
										:is-visible="controls.PESSO1__PSEUDNOVOGR02.isVisible">
										<!-- Start PESSO1__PSEUDNOVOGR02 -->
										<q-row-container v-show="controls.PESSO1__PESSOIDFUNCIO.isVisible || controls.PESSO1__PESSONAME____.isVisible || controls.PESSO1__PESSODTNASCIM.isVisible || controls.PESSO1__PESSOIDADE___.isVisible">
											<q-control-wrapper
												v-show="controls.PESSO1__PESSOIDFUNCIO.isVisible || controls.PESSO1__PESSONAME____.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PESSO1__PESSOIDFUNCIO"
													v-on="controls.PESSO1__PESSOIDFUNCIO.handlers"
													:loading="controls.PESSO1__PESSOIDFUNCIO.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-numeric-input
														v-if="controls.PESSO1__PESSOIDFUNCIO.isVisible"
														v-bind="controls.PESSO1__PESSOIDFUNCIO"
														:model-value="model.ValIdfuncio.value"
														@update:model-value="model.ValIdfuncio.fnUpdateValue" />
												</base-input-structure>
												<base-input-structure
													class="i-text"
													v-bind="controls.PESSO1__PESSONAME____"
													v-on="controls.PESSO1__PESSONAME____.handlers"
													:loading="controls.PESSO1__PESSONAME____.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-text-field
														v-bind="controls.PESSO1__PESSONAME____.props"
														:model-value="model.ValName.value"
														@update:model-value="model.ValName.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.PESSO1__PESSODTNASCIM.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PESSO1__PESSODTNASCIM"
													v-on="controls.PESSO1__PESSODTNASCIM.handlers"
													:loading="controls.PESSO1__PESSODTNASCIM.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-datetime-input
														v-if="controls.PESSO1__PESSODTNASCIM.isVisible"
														v-bind="controls.PESSO1__PESSODTNASCIM"
														format="Date"
														:model-value="model.ValDtnascim.value"
														@update:model-value="model.ValDtnascim.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.PESSO1__PESSOIDADE___.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PESSO1__PESSOIDADE___"
													v-on="controls.PESSO1__PESSOIDADE___.handlers"
													:loading="controls.PESSO1__PESSOIDADE___.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-numeric-input
														v-if="controls.PESSO1__PESSOIDADE___.isVisible"
														v-bind="controls.PESSO1__PESSOIDADE___"
														:model-value="model.ValIdade.value"
														@update:model-value="model.ValIdade.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.PESSO1__PESSOINTERNA_.isVisible">
											<q-control-wrapper
												v-show="controls.PESSO1__PESSOINTERNA_.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-checkbox"
													v-bind="controls.PESSO1__PESSOINTERNA_"
													v-on="controls.PESSO1__PESSOINTERNA_.handlers"
													:loading="controls.PESSO1__PESSOINTERNA_.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<template #label>
														<q-checkbox-input
															v-if="controls.PESSO1__PESSOINTERNA_.isVisible"
															id="PESSO1__PESSOINTERNA_"
															size="mini"
															:model-value="model.ValInterna.value"
															:readonly="controls.PESSO1__PESSOINTERNA_.readonly"
															@update:model-value="model.ValInterna.fnUpdateValue" />
													</template>
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.PESSO1__PESSOEXTERNA_.isVisible">
											<q-control-wrapper
												v-show="controls.PESSO1__PESSOEXTERNA_.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-checkbox"
													v-bind="controls.PESSO1__PESSOEXTERNA_"
													v-on="controls.PESSO1__PESSOEXTERNA_.handlers"
													:loading="controls.PESSO1__PESSOEXTERNA_.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<template #label>
														<q-checkbox-input
															v-if="controls.PESSO1__PESSOEXTERNA_.isVisible"
															id="PESSO1__PESSOEXTERNA_"
															size="small"
															:model-value="model.ValExterna.value"
															:readonly="controls.PESSO1__PESSOEXTERNA_.readonly"
															@update:model-value="model.ValExterna.fnUpdateValue" />
													</template>
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.PESSO1__CATEGCATEGORY.isVisible || controls.PESSO1__PESSODTULTCAT.isVisible">
											<q-control-wrapper
												v-show="controls.PESSO1__CATEGCATEGORY.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PESSO1__CATEGCATEGORY"
													v-on="controls.PESSO1__CATEGCATEGORY.handlers"
													:loading="controls.PESSO1__CATEGCATEGORY.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-lookup
														v-if="controls.PESSO1__CATEGCATEGORY.isVisible"
														v-bind="controls.PESSO1__CATEGCATEGORY.props"
														:model-value="model.ValCodcateg.value"
														v-on="controls.PESSO1__CATEGCATEGORY.handlers"
														@update:model-value="model.ValCodcateg.fnUpdateValue" />
													<q-see-more-pesso1-categcategory
														v-if="controls.PESSO1__CATEGCATEGORY.seeMoreIsVisible"
														v-bind="controls.PESSO1__CATEGCATEGORY.seeMoreParams"
														v-on="controls.PESSO1__CATEGCATEGORY.handlers" />
												</base-input-structure>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.PESSO1__PESSODTULTCAT.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PESSO1__PESSODTULTCAT"
													v-on="controls.PESSO1__PESSODTULTCAT.handlers"
													:loading="controls.PESSO1__PESSODTULTCAT.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-datetime-input
														v-if="controls.PESSO1__PESSODTULTCAT.isVisible"
														v-bind="controls.PESSO1__PESSODTULTCAT"
														format="Date"
														:model-value="model.ValDtultcat.value"
														@update:model-value="model.ValDtultcat.fnUpdateValue" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<!-- End PESSO1__PSEUDNOVOGR02 -->
									</q-group-box-container>
								</q-control-wrapper>
							</q-row-container>
							<!-- End PESSO1__PSEUDNOVOGR08 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.PESSO1__PSEUDNOVOGR06.isVisible || controls.PESSO1__PSEUDOBRIGATO.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.PESSO1__PSEUDNOVOGR06.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="PESSO1__PSEUDNOVOGR06"
							v-bind="controls.PESSO1__PSEUDNOVOGR06"
							:is-visible="controls.PESSO1__PSEUDNOVOGR06.isVisible">
							<!-- Start PESSO1__PSEUDNOVOGR06 -->
							<q-row-container
								v-show="controls.PESSO1__PSEUDNOVOGR07.isVisible"
								is-large>
								<q-control-wrapper
									v-show="controls.PESSO1__PSEUDNOVOGR07.isVisible"
									class="row-line-group">
									<q-group-box-container
										id="PESSO1__PSEUDNOVOGR07"
										v-bind="controls.PESSO1__PSEUDNOVOGR07"
										:is-visible="controls.PESSO1__PSEUDNOVOGR07.isVisible">
										<!-- Start PESSO1__PSEUDNOVOGR07 -->
										<q-row-container v-show="controls.PESSO1__PSEUDNOVOGR03.isVisible || controls.PESSO1__PSEUDNOVOGR09.isVisible">
											<q-control-wrapper
												v-show="controls.PESSO1__PSEUDNOVOGR03.isVisible"
												class="control-join-group">
												<q-group-box-container
													id="PESSO1__PSEUDNOVOGR03"
													v-bind="controls.PESSO1__PSEUDNOVOGR03"
													:is-visible="controls.PESSO1__PSEUDNOVOGR03.isVisible">
													<!-- Start PESSO1__PSEUDNOVOGR03 -->
													<q-row-container v-show="controls.PESSO1__PESSOTELEPHON.isVisible || controls.PESSO1__PESSOEMAIL___.isVisible">
														<q-control-wrapper
															v-show="controls.PESSO1__PESSOTELEPHON.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.PESSO1__PESSOTELEPHON"
																v-on="controls.PESSO1__PESSOTELEPHON.handlers"
																:loading="controls.PESSO1__PESSOTELEPHON.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn"
																:help-style="layoutConfig.HelpStyle">
																<q-text-field
																	v-bind="controls.PESSO1__PESSOTELEPHON.props"
																	:model-value="model.ValTelephon.value"
																	@update:model-value="model.ValTelephon.fnUpdateValue" />
															</base-input-structure>
														</q-control-wrapper>
														<q-control-wrapper
															v-show="controls.PESSO1__PESSOEMAIL___.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.PESSO1__PESSOEMAIL___"
																v-on="controls.PESSO1__PESSOEMAIL___.handlers"
																:loading="controls.PESSO1__PESSOEMAIL___.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn"
																:help-style="layoutConfig.HelpStyle">
																<q-text-field
																	v-bind="controls.PESSO1__PESSOEMAIL___.props"
																	:model-value="model.ValEmail.value"
																	@update:model-value="model.ValEmail.fnUpdateValue" />
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<!-- End PESSO1__PSEUDNOVOGR03 -->
												</q-group-box-container>
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.PESSO1__PSEUDNOVOGR09.isVisible"
												class="control-join-group">
												<q-group-box-container
													id="PESSO1__PSEUDNOVOGR09"
													v-bind="controls.PESSO1__PSEUDNOVOGR09"
													:is-visible="controls.PESSO1__PSEUDNOVOGR09.isVisible">
													<!-- Start PESSO1__PSEUDNOVOGR09 -->
													<q-row-container v-show="controls.PESSO1__PSEUDCONTACTO.isVisible">
														<q-control-wrapper
															v-show="controls.PESSO1__PSEUDCONTACTO.isVisible"
															class="control-join-group">
															<q-table
																v-show="controls.PESSO1__PSEUDCONTACTO.isVisible"
																v-bind="controls.PESSO1__PSEUDCONTACTO"
																v-on="controls.PESSO1__PSEUDCONTACTO.handlers">
															</q-table>
															<q-table-extra-extension
																:list-ctrl="controls.PESSO1__PSEUDCONTACTO"
																v-on="controls.PESSO1__PSEUDCONTACTO.handlers" />
														</q-control-wrapper>
													</q-row-container>
													<!-- End PESSO1__PSEUDNOVOGR09 -->
												</q-group-box-container>
											</q-control-wrapper>
										</q-row-container>
										<!-- End PESSO1__PSEUDNOVOGR07 -->
									</q-group-box-container>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container
								v-show="controls.PESSO1__PSEUDNOVOGR05.isVisible"
								is-large>
								<q-control-wrapper
									v-show="controls.PESSO1__PSEUDNOVOGR05.isVisible"
									class="row-line-group">
									<q-group-box-container
										id="PESSO1__PSEUDNOVOGR05"
										v-bind="controls.PESSO1__PSEUDNOVOGR05"
										:is-visible="controls.PESSO1__PSEUDNOVOGR05.isVisible">
										<!-- Start PESSO1__PSEUDNOVOGR05 -->
										<q-row-container
											v-show="controls.PESSO1__PSEUDNOVOGR01.isVisible"
											is-large>
											<q-control-wrapper
												v-show="controls.PESSO1__PSEUDNOVOGR01.isVisible"
												class="row-line-group">
												<q-group-box-container
													id="PESSO1__PSEUDNOVOGR01"
													v-bind="controls.PESSO1__PSEUDNOVOGR01"
													:is-visible="controls.PESSO1__PSEUDNOVOGR01.isVisible">
													<!-- Start PESSO1__PSEUDNOVOGR01 -->
													<q-row-container v-show="controls.PESSO1__CMPNYDESIGNAT.isVisible || controls.PESSO1__CNTRYCOUNTRY_.isVisible">
														<q-control-wrapper
															v-show="controls.PESSO1__CMPNYDESIGNAT.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.PESSO1__CMPNYDESIGNAT"
																v-on="controls.PESSO1__CMPNYDESIGNAT.handlers"
																:loading="controls.PESSO1__CMPNYDESIGNAT.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn"
																:help-style="layoutConfig.HelpStyle">
																<q-lookup
																	v-if="controls.PESSO1__CMPNYDESIGNAT.isVisible"
																	v-bind="controls.PESSO1__CMPNYDESIGNAT.props"
																	:model-value="model.ValCodempre.value"
																	v-on="controls.PESSO1__CMPNYDESIGNAT.handlers"
																	@update:model-value="model.ValCodempre.fnUpdateValue" />
																<q-see-more-pesso1-cmpnydesignat
																	v-if="controls.PESSO1__CMPNYDESIGNAT.seeMoreIsVisible"
																	v-bind="controls.PESSO1__CMPNYDESIGNAT.seeMoreParams"
																	v-on="controls.PESSO1__CMPNYDESIGNAT.handlers" />
															</base-input-structure>
														</q-control-wrapper>
														<q-control-wrapper
															v-show="controls.PESSO1__CNTRYCOUNTRY_.isVisible"
															class="control-join-group">
															<base-input-structure
																class="i-text"
																v-bind="controls.PESSO1__CNTRYCOUNTRY_"
																v-on="controls.PESSO1__CNTRYCOUNTRY_.handlers"
																:loading="controls.PESSO1__CNTRYCOUNTRY_.props.loading"
																:reporting-mode-on="reportingModeCAV"
																:suggestion-mode-on="suggestionModeOn"
																:help-style="layoutConfig.HelpStyle">
																<q-text-field
																	v-bind="controls.PESSO1__CNTRYCOUNTRY_.props"
																	:model-value="model.CntryValCountry.value" />
															</base-input-structure>
														</q-control-wrapper>
													</q-row-container>
													<!-- End PESSO1__PSEUDNOVOGR01 -->
												</q-group-box-container>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container
											v-show="controls.PESSO1__PSEUDNOVOGR10.isVisible"
											is-large>
											<q-control-wrapper
												v-show="controls.PESSO1__PSEUDNOVOGR10.isVisible"
												class="row-line-group">
												<q-group-box-container
													id="PESSO1__PSEUDNOVOGR10"
													v-bind="controls.PESSO1__PSEUDNOVOGR10"
													:is-visible="controls.PESSO1__PSEUDNOVOGR10.isVisible">
													<!-- Start PESSO1__PSEUDNOVOGR10 -->
													<q-row-container v-show="controls.PESSO1__PSEUDEVOLUCAO.isVisible">
														<q-control-wrapper
															v-show="controls.PESSO1__PSEUDEVOLUCAO.isVisible"
															class="control-join-group">
															<q-table
																v-show="controls.PESSO1__PSEUDEVOLUCAO.isVisible"
																v-bind="controls.PESSO1__PSEUDEVOLUCAO"
																v-on="controls.PESSO1__PSEUDEVOLUCAO.handlers">
															</q-table>
															<q-table-extra-extension
																:list-ctrl="controls.PESSO1__PSEUDEVOLUCAO"
																v-on="controls.PESSO1__PSEUDEVOLUCAO.handlers" />
														</q-control-wrapper>
													</q-row-container>
													<!-- End PESSO1__PSEUDNOVOGR10 -->
												</q-group-box-container>
											</q-control-wrapper>
										</q-row-container>
										<!-- End PESSO1__PSEUDNOVOGR05 -->
									</q-group-box-container>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container
								v-show="controls.PESSO1__PSEUDNOVOGR11.isVisible"
								is-large>
								<q-control-wrapper
									v-show="controls.PESSO1__PSEUDNOVOGR11.isVisible"
									class="row-line-group">
									<q-group-box-container
										id="PESSO1__PSEUDNOVOGR11"
										v-bind="controls.PESSO1__PSEUDNOVOGR11"
										:is-visible="controls.PESSO1__PSEUDNOVOGR11.isVisible">
										<!-- Start PESSO1__PSEUDNOVOGR11 -->
										<q-row-container v-show="controls.PESSO1__REGI1REGIAO__.isVisible">
											<q-control-wrapper
												v-show="controls.PESSO1__REGI1REGIAO__.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.PESSO1__REGI1REGIAO__"
													v-on="controls.PESSO1__REGI1REGIAO__.handlers"
													:loading="controls.PESSO1__REGI1REGIAO__.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-lookup
														v-if="controls.PESSO1__REGI1REGIAO__.isVisible"
														v-bind="controls.PESSO1__REGI1REGIAO__.props"
														:model-value="model.ValCodregia.value"
														v-on="controls.PESSO1__REGI1REGIAO__.handlers"
														@update:model-value="model.ValCodregia.fnUpdateValue" />
													<q-see-more-pesso1-regi1regiao
														v-if="controls.PESSO1__REGI1REGIAO__.seeMoreIsVisible"
														v-bind="controls.PESSO1__REGI1REGIAO__.seeMoreParams"
														v-on="controls.PESSO1__REGI1REGIAO__.handlers" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<!-- End PESSO1__PSEUDNOVOGR11 -->
									</q-group-box-container>
								</q-control-wrapper>
							</q-row-container>
							<!-- End PESSO1__PSEUDNOVOGR06 -->
						</q-group-box-container>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.PESSO1__PSEUDOBRIGATO.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-static-text"
							v-bind="controls.PESSO1__PSEUDOBRIGATO"
							v-on="controls.PESSO1__PSEUDOBRIGATO.handlers"
							:loading="controls.PESSO1__PSEUDOBRIGATO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-static-text
								v-if="controls.PESSO1__PSEUDOBRIGATO.isVisible"
								id="PESSO1__PSEUDOBRIGATO"
								size="xxlarge"
								:text="controls.PESSO1__PSEUDOBRIGATO.label"
								supports-html />
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

	import FormViewModel from './QFormPesso1ViewModel.js'

	const requiredTextResources = ['QFormPesso1', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS PESSO1]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormPesso1',

		components: {
			QSeeMorePesso1Categcategory: defineAsyncComponent(() => import('@/views/forms/FormPesso1/dbedits/Pesso1CategcategorySeeMore.vue')),
			QSeeMorePesso1Cmpnydesignat: defineAsyncComponent(() => import('@/views/forms/FormPesso1/dbedits/Pesso1CmpnydesignatSeeMore.vue')),
			QSeeMorePesso1Regi1regiao: defineAsyncComponent(() => import('@/views/forms/FormPesso1/dbedits/Pesso1Regi1regiaoSeeMore.vue')),
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
						name: 'PESSO1',
						location: 'form-PESSO1',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormPesso1', false),

				interfaceMetadata: {
					id: 'QFormPesso1', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'subarea',
					name: 'PESSO1',
					route: 'form-PESSO1',
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
					PESSO1__PSEUDNOVOGR08: new fieldControlClass.GroupControl({
						id: 'PESSO1__PSEUDNOVOGR08',
						name: 'NOVOGR08',
						size: 'block',
						hasLabel: true,
						label: '',
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					PESSO1__PSEUDNOVOGR04: new fieldControlClass.GroupControl({
						id: 'PESSO1__PSEUDNOVOGR04',
						name: 'NOVOGR04',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.PHOTO32097),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'PESSO1__PSEUDNOVOGR08',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSO1__PESSOPHOTOGRA: new fieldControlClass.ImageControl({
						modelField: 'ValPhotogra',
						valueChangeEvent: 'fieldChange:pesso.photogra',
						id: 'PESSO1__PESSOPHOTOGRA',
						name: 'PHOTOGRA',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.PHOTO51874),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO1__PSEUDNOVOGR04',
						height: 50,
						width: 100,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSO1__PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'PESSO1__PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.IDENTIFICATION40793),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'PESSO1__PSEUDNOVOGR08',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					PESSO1__PESSOIDFUNCIO: new fieldControlClass.NumberControl({
						modelField: 'ValIdfuncio',
						valueChangeEvent: 'fieldChange:pesso.idfuncio',
						maxIntegers: 6,
						maxDecimals: 0,
						isSequencial: true,
						id: 'PESSO1__PESSOIDFUNCIO',
						name: 'IDFUNCIO',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.EMPLOYEE_NO_01176),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO1__PSEUDNOVOGR02',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					PESSO1__PESSONAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:pesso.name',
						id: 'PESSO1__PESSONAME____',
						name: 'NAME',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.NAME_23841),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO1__PSEUDNOVOGR02',
						maxLength: 85,
						labelId: 'label_PESSO1__PESSONAME____',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					PESSO1__PESSODTNASCIM: new fieldControlClass.DateControl({
						modelField: 'ValDtnascim',
						valueChangeEvent: 'fieldChange:pesso.dtnascim',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'PESSO1__PESSODTNASCIM',
						name: 'DTNASCIM',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.BIRTH21799),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO1__PSEUDNOVOGR02',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSO1__PESSOIDADE___: new fieldControlClass.NumberControl({
						modelField: 'ValIdade',
						valueChangeEvent: 'fieldChange:pesso.idade',
						maxIntegers: 5,
						maxDecimals: 0,
						id: 'PESSO1__PESSOIDADE___',
						name: 'IDADE',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.AGE28663),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO1__PSEUDNOVOGR02',
						isFormulaBlocked: true,
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					PESSO1__PESSOGENDER__: new fieldControlClass.ArrayStringControl({
						modelField: 'ValGender',
						valueChangeEvent: 'fieldChange:pesso.gender',
						id: 'PESSO1__PESSOGENDER__',
						name: 'GENDER',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.GENDER44172),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'PESSO1__PSEUDNOVOGR02',
						maxLength: 1,
						labelId: 'label_PESSO1__PESSOGENDER__',
						arrayName: 'Genero',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSO1__PESSOINTERNA_: new fieldControlClass.BooleanControl({
						modelField: 'ValInterna',
						valueChangeEvent: 'fieldChange:pesso.interna',
						id: 'PESSO1__PESSOINTERNA_',
						name: 'INTERNA',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.INTERN65375),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'PESSO1__PSEUDNOVOGR02',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSO1__PESSOEXTERNA_: new fieldControlClass.BooleanControl({
						modelField: 'ValExterna',
						valueChangeEvent: 'fieldChange:pesso.externa',
						id: 'PESSO1__PESSOEXTERNA_',
						name: 'EXTERNA',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.EXTERNAL13375),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'PESSO1__PSEUDNOVOGR02',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSO1__CATEGCATEGORY: new fieldControlClass.LookupControl({
						modelField: 'TableCategCategory',
						valueChangeEvent: 'fieldChange:categ.categoria',
						id: 'PESSO1__CATEGCATEGORY',
						name: 'CATEGORY',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.CATEGORY18978),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO1__PSEUDNOVOGR02',
						isFormulaBlocked: true,
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodcateg',
							dependencyEvent: 'fieldChange:pesso.codcateg'
						},
						dependentFields: () => {
							return {
								set 'categ.codcateg'(value) { vm.model.ValCodcateg.updateValue(value) },
								set 'categ.categoria'(value) { vm.model.TableCategCategory.updateValue(value) },
							}
						},
						insertEnabled: true,
						supportForm: 'CATEG',
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: [PESSO->INTERNA]==1
								// eslint-disable-next-line eqeqeq
								return (this.ValInterna.value ? 1 : 0)==1
							},
							dependencyEvents: ['fieldChange:pesso.interna'],
							isServerRecalc: false,
							isServerFormula: false,
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
					PESSO1__PESSODTULTCAT: new fieldControlClass.DateControl({
						modelField: 'ValDtultcat',
						valueChangeEvent: 'fieldChange:pesso.dtultcat',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'PESSO1__PESSODTULTCAT',
						name: 'DTULTCAT',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.SINCE47259),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO1__PSEUDNOVOGR02',
						isFormulaBlocked: true,
						mustBeFilled: false,
						controlLimits: [
						],
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: [PESSO->INTERNA]==1
								// eslint-disable-next-line eqeqeq
								return (this.ValInterna.value ? 1 : 0)==1
							},
							dependencyEvents: ['fieldChange:pesso.interna'],
							isServerRecalc: false,
							isServerFormula: false,
						},
						isFixed: true,
					}, this),
					PESSO1__PSEUDNOVOGR06: new fieldControlClass.GroupControl({
						id: 'PESSO1__PSEUDNOVOGR06',
						name: 'NOVOGR06',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.ACCORDION01950),
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
					PESSO1__PSEUDNOVOGR07: new fieldControlClass.GroupControl({
						id: 'PESSO1__PSEUDNOVOGR07',
						name: 'NOVOGR07',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.CONTACT05134),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'PESSO1__PSEUDNOVOGR06',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSO1__PSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'PESSO1__PSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.MAIN_CONTACT60524),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'PESSO1__PSEUDNOVOGR07',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSO1__PESSOTELEPHON: new fieldControlClass.StringControl({
						modelField: 'ValTelephon',
						valueChangeEvent: 'fieldChange:pesso.telephon',
						id: 'PESSO1__PESSOTELEPHON',
						name: 'TELEPHON',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.TELEPHONE28697),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO1__PSEUDNOVOGR03',
						maxLength: 20,
						labelId: 'label_PESSO1__PESSOTELEPHON',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSO1__PESSOEMAIL___: new fieldControlClass.StringControl({
						modelField: 'ValEmail',
						valueChangeEvent: 'fieldChange:pesso.email',
						id: 'PESSO1__PESSOEMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.EMAIL_44228),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO1__PSEUDNOVOGR03',
						maxLength: 254,
						labelId: 'label_PESSO1__PESSOEMAIL___',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSO1__PSEUDNOVOGR09: new fieldControlClass.GroupControl({
						id: 'PESSO1__PSEUDNOVOGR09',
						name: 'NOVOGR09',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.ALL_CONTACTS25646),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'PESSO1__PSEUDNOVOGR07',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSO1__PSEUDCONTACTO: new fieldControlClass.TableListControl({
						id: 'PESSO1__PSEUDCONTACTO',
						name: 'CONTACTO',
						size: 'xxlarge',
						hasLabel: true,
						label: '',
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO1__PSEUDNOVOGR09',
						controller: 'PESSO',
						action: 'Pesso1_ValContacto',
						hasDependencies: false,
						isInCollapsible: false,
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
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValContacto',
								area: 'CONTA',
								field: 'CONTACTO',
								label: computed(() => this.Resources.CONTACT59247),
								dataLength: 254,
								scrollData: 30,
							}),
						],
						config: {
							name: 'ValContacto',
							serverMode: true,
							pkColumn: 'ValCodconta',
							tableAlias: 'CONTA',
							tableNamePlural: computed(() => this.Resources.CONTACTS55742),
							viewManagement: 'N',
							showLimitsInfo: true,
							showAlternatePagination: true,
							permissions: {
							},
							globalSearch: {
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
							rowValidation: {
								fnValidate: (row) => row.Fields.ValZzstate === 0,
								message: computed(() => this.Resources.ATENCAO__ESTA_FICHA_24725),
								class: 'c-table__row--pending'
							},
							// The list support form: CONTA
							crudConditions: {
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							initialSortColumnName: '',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-GENRE', 'changed-TPCON', 'changed-CONTA', 'changed-PESSO'],
						uuid: 'Pesso1_ValContacto',
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
					PESSO1__PSEUDNOVOGR05: new fieldControlClass.GroupControl({
						id: 'PESSO1__PSEUDNOVOGR05',
						name: 'NOVOGR05',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.CAREER41490),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'PESSO1__PSEUDNOVOGR06',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSO1__PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'PESSO1__PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.COMPANY20759),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'PESSO1__PSEUDNOVOGR05',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSO1__CMPNYDESIGNAT: new fieldControlClass.LookupControl({
						modelField: 'TableCmpnyDesignat',
						valueChangeEvent: 'fieldChange:cmpny.designat',
						id: 'PESSO1__CMPNYDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.COMPANY52963),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO1__PSEUDNOVOGR01',
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodempre',
							dependencyEvent: 'fieldChange:pesso.codempre'
						},
						dependentFields: () => {
							return {
								set 'cmpny.codempre'(value) { vm.model.ValCodempre.updateValue(value) },
								set 'cmpny.designat'(value) { vm.model.TableCmpnyDesignat.updateValue(value) },
								set 'pesso.codpaise'(value) { vm.model.ValCodpaise.updateValue(value) },
								set 'cntry.country'(value) { vm.model.CntryValCountry.updateValue(value) },
							}
						},
						insertEnabled: true,
						supportForm: 'EMPRE',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
					}, this),
					PESSO1__CNTRYCOUNTRY_: new fieldControlClass.StringControl({
						modelField: 'CntryValCountry',
						valueChangeEvent: 'fieldChange:cntry.country',
						dependentModelField: 'ValCodpaise',
						dependentChangeEvent: 'fieldChange:pesso.codpaise',
						id: 'PESSO1__CNTRYCOUNTRY_',
						name: 'COUNTRY',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.COUNTRY64133),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO1__PSEUDNOVOGR01',
						maxLength: 90,
						labelId: 'label_PESSO1__CNTRYCOUNTRY_',
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					PESSO1__PSEUDNOVOGR10: new fieldControlClass.GroupControl({
						id: 'PESSO1__PSEUDNOVOGR10',
						name: 'NOVOGR10',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.EVOLUTION63463),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'PESSO1__PSEUDNOVOGR05',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSO1__PSEUDEVOLUCAO: new fieldControlClass.TableListControl({
						id: 'PESSO1__PSEUDEVOLUCAO',
						name: 'EVOLUCAO',
						size: 'xxlarge',
						hasLabel: true,
						label: '',
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO1__PSEUDNOVOGR10',
						controller: 'PESSO',
						action: 'Pesso1_ValEvolucao',
						hasDependencies: true,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValSince',
								area: 'EVCAT',
								field: 'SINCE',
								label: computed(() => this.Resources.SINCE47259),
								scrollData: 8,
								dateTimeType: 'Date',
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'Cate1.ValCategoria',
								area: 'CATE1',
								field: 'CATEGORY',
								label: computed(() => this.Resources.CATEGORY18978),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodcateg',
							}),
							new listColumnTypes.DateColumn({
								order: 3,
								name: 'ValFimperio',
								area: 'EVCAT',
								field: 'FIMPERIO',
								label: computed(() => this.Resources.END_OF_PERIOD44616),
								scrollData: 8,
								dateTimeType: 'Date',
							}),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValObservat',
								area: 'EVCAT',
								field: 'OBSERVAT',
								label: computed(() => this.Resources.OBSERVATION37880),
								scrollData: 30,
							}),
						],
						config: {
							name: 'ValEvolucao',
							serverMode: true,
							pkColumn: 'ValCodprogr',
							tableAlias: 'EVCAT',
							tableNamePlural: computed(() => this.Resources.EVOLUTION_IN_CATEGOR19803),
							viewManagement: 'N',
							showLimitsInfo: true,
							showAlternatePagination: true,
							permissions: {
							},
							globalSearch: {
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
							rowValidation: {
								fnValidate: (row) => row.Fields.ValZzstate === 0,
								message: computed(() => this.Resources.ATENCAO__ESTA_FICHA_24725),
								class: 'c-table__row--pending'
							},
							// The list support form: EVCAT
							crudConditions: {
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							initialSortColumnName: '',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-PESSO', 'changed-EVCAT', 'changed-CATE1'],
						uuid: 'Pesso1_ValEvolucao',
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
					PESSO1__PSEUDOBRIGATO: new fieldControlClass.BaseControl({
						id: 'PESSO1__PSEUDOBRIGATO',
						name: 'OBRIGATO',
						size: 'xxlarge',
						hasLabel: false,
						label: computed(() => this.Resources.AT_REQUIRED65277),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSO1__PSEUDNOVOGR11: new fieldControlClass.GroupControl({
						id: 'PESSO1__PSEUDNOVOGR11',
						name: 'NOVOGR11',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.PLACE_OF_BIRTH21795),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'PESSO1__PSEUDNOVOGR06',
						isCollapsible: false,
						anchored: false,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					PESSO1__REGI1REGIAO__: new fieldControlClass.LookupControl({
						modelField: 'TableRegi1Regiao',
						valueChangeEvent: 'fieldChange:regi1.regiao',
						id: 'PESSO1__REGI1REGIAO__',
						name: 'REGIAO',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.REGION12723),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'PESSO1__PSEUDNOVOGR11',
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodregia',
							dependencyEvent: 'fieldChange:pesso.codregia'
						},
						dependentFields: () => {
							return {
								set 'regi1.codregia'(value) { vm.model.ValCodregia.updateValue(value) },
								set 'regi1.regiao'(value) { vm.model.TableRegi1Regiao.updateValue(value) },
								set 'pesso.codcntry'(value) { vm.model.ValCodcntry.updateValue(value) },
								set 'pais1.country'(value) { vm.model.Pais1ValCountry.updateValue(value) },
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
					'PESSO1__PSEUDNOVOGR08',
					'PESSO1__PSEUDNOVOGR04',
					'PESSO1__PSEUDNOVOGR02',
					'PESSO1__PSEUDNOVOGR06',
					'PESSO1__PSEUDNOVOGR07',
					'PESSO1__PSEUDNOVOGR03',
					'PESSO1__PSEUDNOVOGR09',
					'PESSO1__PSEUDNOVOGR05',
					'PESSO1__PSEUDNOVOGR01',
					'PESSO1__PSEUDNOVOGR10',
					'PESSO1__PSEUDNOVOGR11',
				]),

				tableFields: readonly([
					'PESSO1__PSEUDCONTACTO',
					'PESSO1__PSEUDEVOLUCAO',
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
					},
					Cntry: {
						get ValCountry() { return vm.model.CntryValCountry.value },
						set ValCountry(value) { vm.model.CntryValCountry.updateValue(value) },
					},
					Pais1: {
						get ValCountry() { return vm.model.Pais1ValCountry.value },
						set ValCountry(value) { vm.model.Pais1ValCountry.updateValue(value) },
					},
					Pesso: {
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
						get ValDtnascim() { return vm.model.ValDtnascim.value },
						set ValDtnascim(value) { vm.model.ValDtnascim.updateValue(value) },
						get ValDtultcat() { return vm.model.ValDtultcat.value },
						set ValDtultcat(value) { vm.model.ValDtultcat.updateValue(value) },
						get ValEmail() { return vm.model.ValEmail.value },
						set ValEmail(value) { vm.model.ValEmail.updateValue(value) },
						get ValExterna() { return vm.model.ValExterna.value },
						set ValExterna(value) { vm.model.ValExterna.updateValue(value) },
						get ValGender() { return vm.model.ValGender.value },
						set ValGender(value) { vm.model.ValGender.updateValue(value) },
						get ValIdade() { return vm.model.ValIdade.value },
						set ValIdade(value) { vm.model.ValIdade.updateValue(value) },
						get ValIdfuncio() { return vm.model.ValIdfuncio.value },
						set ValIdfuncio(value) { vm.model.ValIdfuncio.updateValue(value) },
						get ValInterna() { return vm.model.ValInterna.value },
						set ValInterna(value) { vm.model.ValInterna.updateValue(value) },
						get ValName() { return vm.model.ValName.value },
						set ValName(value) { vm.model.ValName.updateValue(value) },
						get ValPhotogra() { return vm.model.ValPhotogra.value },
						set ValPhotogra(value) { vm.model.ValPhotogra.updateValue(value) },
						get ValTelephon() { return vm.model.ValTelephon.value },
						set ValTelephon(value) { vm.model.ValTelephon.updateValue(value) },
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
// USE /[MANUAL GQT FORM_CODEJS PESSO1]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS PESSO1]/
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
// USE /[MANUAL GQT FORM_LOADED_JS PESSO1]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS PESSO1]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS PESSO1]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS PESSO1]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS PESSO1]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS PESSO1]/
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
// USE /[MANUAL GQT AFTER_DEL_JS PESSO1]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS PESSO1]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS PESSO1]/
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
// USE /[MANUAL GQT DLGUPDT PESSO1]/
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
// USE /[MANUAL GQT CTRLUPD PESSO1]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
		},

		watch: {
		}
	}
</script>
