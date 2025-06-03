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
			data-key="EQUIP"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container
					v-show="controls.EQUIP___PSEUDNOVOGR02.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.EQUIP___PSEUDNOVOGR02.isVisible"
						class="row-line-group">
						<q-group-collapsible
							id="EQUIP___PSEUDNOVOGR02"
							v-bind="controls.EQUIP___PSEUDNOVOGR02"
							v-on="controls.EQUIP___PSEUDNOVOGR02.handlers">
							<!-- Start EQUIP___PSEUDNOVOGR02 -->
							<q-row-container v-show="controls.EQUIP___CMPNYDESIGNAT.isVisible || controls.EQUIP___PESS1NAME____.isVisible">
								<q-control-wrapper
									v-show="controls.EQUIP___CMPNYDESIGNAT.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIP___CMPNYDESIGNAT"
										v-on="controls.EQUIP___CMPNYDESIGNAT.handlers"
										:loading="controls.EQUIP___CMPNYDESIGNAT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.EQUIP___CMPNYDESIGNAT.isVisible"
											v-bind="controls.EQUIP___CMPNYDESIGNAT.props"
											v-on="controls.EQUIP___CMPNYDESIGNAT.handlers" />
										<q-see-more-equip-cmpnydesignat
											v-if="controls.EQUIP___CMPNYDESIGNAT.seeMoreIsVisible"
											v-bind="controls.EQUIP___CMPNYDESIGNAT.seeMoreParams"
											v-on="controls.EQUIP___CMPNYDESIGNAT.handlers" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.EQUIP___PESS1NAME____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIP___PESS1NAME____"
										v-on="controls.EQUIP___PESS1NAME____.handlers"
										:loading="controls.EQUIP___PESS1NAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.EQUIP___PESS1NAME____.isVisible"
											v-bind="controls.EQUIP___PESS1NAME____.props"
											v-on="controls.EQUIP___PESS1NAME____.handlers" />
										<q-see-more-equip-pess1name
											v-if="controls.EQUIP___PESS1NAME____.seeMoreIsVisible"
											v-bind="controls.EQUIP___PESS1NAME____.seeMoreParams"
											v-on="controls.EQUIP___PESS1NAME____.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End EQUIP___PSEUDNOVOGR02 -->
						</q-group-collapsible>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.EQUIP___PSEUDNOVOGR01.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.EQUIP___PSEUDNOVOGR01.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="EQUIP___PSEUDNOVOGR01"
							class="c-groupbox--title-background"
							v-bind="controls.EQUIP___PSEUDNOVOGR01"
							:is-visible="controls.EQUIP___PSEUDNOVOGR01.isVisible">
							<!-- Start EQUIP___PSEUDNOVOGR01 -->
							<q-row-container v-show="controls.EQUIP___EQUIPSEQUENNR.isVisible || controls.EQUIP___EQUIPREGISTNR.isVisible || controls.EQUIP___TPEQUTIPOEQUI.isVisible">
								<q-control-wrapper
									v-show="controls.EQUIP___EQUIPSEQUENNR.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIP___EQUIPSEQUENNR"
										v-on="controls.EQUIP___EQUIPSEQUENNR.handlers"
										:loading="controls.EQUIP___EQUIPSEQUENNR.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.EQUIP___EQUIPSEQUENNR.isVisible"
											v-bind="controls.EQUIP___EQUIPSEQUENNR.props"
											@update:model-value="model.ValSequennr.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.EQUIP___EQUIPREGISTNR.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIP___EQUIPREGISTNR"
										v-on="controls.EQUIP___EQUIPREGISTNR.handlers"
										:loading="controls.EQUIP___EQUIPREGISTNR.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EQUIP___EQUIPREGISTNR.props"
											@blur="onBlur(controls.EQUIP___EQUIPREGISTNR, model.ValRegistnr.value)"
											@change="model.ValRegistnr.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.EQUIP___TPEQUTIPOEQUI.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIP___TPEQUTIPOEQUI"
										v-on="controls.EQUIP___TPEQUTIPOEQUI.handlers"
										:loading="controls.EQUIP___TPEQUTIPOEQUI.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.EQUIP___TPEQUTIPOEQUI.isVisible"
											v-bind="controls.EQUIP___TPEQUTIPOEQUI.props"
											v-on="controls.EQUIP___TPEQUTIPOEQUI.handlers" />
										<q-see-more-equip-tpequtipoequi
											v-if="controls.EQUIP___TPEQUTIPOEQUI.seeMoreIsVisible"
											v-bind="controls.EQUIP___TPEQUTIPOEQUI.seeMoreParams"
											v-on="controls.EQUIP___TPEQUTIPOEQUI.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.EQUIP___EQUIPSITEFABR.isVisible">
								<q-control-wrapper
									v-show="controls.EQUIP___EQUIPSITEFABR.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIP___EQUIPSITEFABR"
										v-on="controls.EQUIP___EQUIPSITEFABR.handlers"
										:loading="controls.EQUIP___EQUIPSITEFABR.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EQUIP___EQUIPSITEFABR.props"
											@blur="onBlur(controls.EQUIP___EQUIPSITEFABR, model.ValSitefabr.value)"
											@change="model.ValSitefabr.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.EQUIP___WAREHWAREHDES.isVisible || controls.EQUIP___ITEM_ITEMDES_.isVisible || controls.EQUIP___EQUIPDESIGNAT.isVisible || controls.EQUIP___EQUIPFREQUENC.isVisible || controls.EQUIP___EQUIPVALORTOT.isVisible || controls.EQUIP___EQUIPDTAQUISI.isVisible || controls.EQUIP___EQUIPDTDECO__.isVisible || controls.EQUIP___EQUIPBOUGHT__.isVisible">
								<q-control-wrapper
									v-show="controls.EQUIP___WAREHWAREHDES.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIP___WAREHWAREHDES"
										v-on="controls.EQUIP___WAREHWAREHDES.handlers"
										:loading="controls.EQUIP___WAREHWAREHDES.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.EQUIP___WAREHWAREHDES.isVisible"
											v-bind="controls.EQUIP___WAREHWAREHDES.props"
											v-on="controls.EQUIP___WAREHWAREHDES.handlers" />
										<q-see-more-equip-warehwarehdes
											v-if="controls.EQUIP___WAREHWAREHDES.seeMoreIsVisible"
											v-bind="controls.EQUIP___WAREHWAREHDES.seeMoreParams"
											v-on="controls.EQUIP___WAREHWAREHDES.handlers" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.EQUIP___ITEM_ITEMDES_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIP___ITEM_ITEMDES_"
										v-on="controls.EQUIP___ITEM_ITEMDES_.handlers"
										:loading="controls.EQUIP___ITEM_ITEMDES_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.EQUIP___ITEM_ITEMDES_.isVisible"
											v-bind="controls.EQUIP___ITEM_ITEMDES_.props"
											v-on="controls.EQUIP___ITEM_ITEMDES_.handlers" />
										<q-see-more-equip-item-itemdes
											v-if="controls.EQUIP___ITEM_ITEMDES_.seeMoreIsVisible"
											v-bind="controls.EQUIP___ITEM_ITEMDES_.seeMoreParams"
											v-on="controls.EQUIP___ITEM_ITEMDES_.handlers" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.EQUIP___EQUIPDESIGNAT.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIP___EQUIPDESIGNAT"
										v-on="controls.EQUIP___EQUIPDESIGNAT.handlers"
										:loading="controls.EQUIP___EQUIPDESIGNAT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EQUIP___EQUIPDESIGNAT.props"
											@blur="onBlur(controls.EQUIP___EQUIPDESIGNAT, model.ValDesignat.value)"
											@change="model.ValDesignat.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.EQUIP___EQUIPFREQUENC.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIP___EQUIPFREQUENC"
										v-on="controls.EQUIP___EQUIPFREQUENC.handlers"
										:loading="controls.EQUIP___EQUIPFREQUENC.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-combobox
											v-if="controls.EQUIP___EQUIPFREQUENC.isVisible"
											v-bind="controls.EQUIP___EQUIPFREQUENC.props"
											:model-value="model.ValFrequenc.value"
											@update:model-value="model.ValFrequenc.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.EQUIP___EQUIPVALORTOT.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIP___EQUIPVALORTOT"
										v-on="controls.EQUIP___EQUIPVALORTOT.handlers"
										:loading="controls.EQUIP___EQUIPVALORTOT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.EQUIP___EQUIPVALORTOT.isVisible"
											v-bind="controls.EQUIP___EQUIPVALORTOT.props"
											@update:model-value="model.ValValortot.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.EQUIP___EQUIPDTAQUISI.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIP___EQUIPDTAQUISI"
										v-on="controls.EQUIP___EQUIPDTAQUISI.handlers"
										:loading="controls.EQUIP___EQUIPDTAQUISI.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.EQUIP___EQUIPDTAQUISI.isVisible"
											v-bind="controls.EQUIP___EQUIPDTAQUISI.props"
											:model-value="model.ValDtaquisi.value"
											@reset-icon-click="model.ValDtaquisi.fnUpdateValue(model.ValDtaquisi.originalValue ?? new Date())"
											@update:model-value="model.ValDtaquisi.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.EQUIP___EQUIPDTDECO__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIP___EQUIPDTDECO__"
										v-on="controls.EQUIP___EQUIPDTDECO__.handlers"
										:loading="controls.EQUIP___EQUIPDTDECO__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.EQUIP___EQUIPDTDECO__.isVisible"
											v-bind="controls.EQUIP___EQUIPDTDECO__.props"
											:model-value="model.ValDtdeco.value"
											@reset-icon-click="model.ValDtdeco.fnUpdateValue(model.ValDtdeco.originalValue ?? new Date())"
											@update:model-value="model.ValDtdeco.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.EQUIP___EQUIPBOUGHT__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.EQUIP___EQUIPBOUGHT__"
										v-on="controls.EQUIP___EQUIPBOUGHT__.handlers"
										:loading="controls.EQUIP___EQUIPBOUGHT__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.EQUIP___EQUIPBOUGHT__.isVisible"
												v-bind="controls.EQUIP___EQUIPBOUGHT__.props"
												v-on="controls.EQUIP___EQUIPBOUGHT__.handlers" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End EQUIP___PSEUDNOVOGR01 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.EQUIP___PSEUDNOVOGR09.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.EQUIP___PSEUDNOVOGR09.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="EQUIP___PSEUDNOVOGR09"
							v-bind="controls.EQUIP___PSEUDNOVOGR09"
							:is-visible="controls.EQUIP___PSEUDNOVOGR09.isVisible">
							<!-- Start EQUIP___PSEUDNOVOGR09 -->
							<q-row-container v-show="controls.EQUIP___ROOM1ROOMNR__.isVisible || controls.EQUIP___ROOM1DESIGNAT.isVisible || controls.EQUIP___EQUIPDTREFERE.isVisible || controls.EQUIP___EQUIPFIRST___.isVisible || controls.EQUIP___EQUIPBEFORE__.isVisible || controls.EQUIP___EQUIPFOLLOWIN.isVisible || controls.EQUIP___EQUIPLAST____.isVisible || controls.EQUIP___EQUIPQTDMOVIM.isVisible">
								<q-control-wrapper
									v-show="controls.EQUIP___ROOM1ROOMNR__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIP___ROOM1ROOMNR__"
										v-on="controls.EQUIP___ROOM1ROOMNR__.handlers"
										:loading="controls.EQUIP___ROOM1ROOMNR__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.EQUIP___ROOM1ROOMNR__.isVisible"
											v-bind="controls.EQUIP___ROOM1ROOMNR__.props"
											v-on="controls.EQUIP___ROOM1ROOMNR__.handlers" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.EQUIP___ROOM1DESIGNAT.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIP___ROOM1DESIGNAT"
										v-on="controls.EQUIP___ROOM1DESIGNAT.handlers"
										:loading="controls.EQUIP___ROOM1DESIGNAT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EQUIP___ROOM1DESIGNAT.props"
											@blur="onBlur(controls.EQUIP___ROOM1DESIGNAT, model.Room1ValDesignat.value)"
											@change="model.Room1ValDesignat.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.EQUIP___EQUIPDTREFERE.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIP___EQUIPDTREFERE"
										v-on="controls.EQUIP___EQUIPDTREFERE.handlers"
										:loading="controls.EQUIP___EQUIPDTREFERE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.EQUIP___EQUIPDTREFERE.isVisible"
											v-bind="controls.EQUIP___EQUIPDTREFERE.props"
											:model-value="model.ValDtrefere.value"
											@reset-icon-click="model.ValDtrefere.fnUpdateValue(model.ValDtrefere.originalValue ?? new Date())"
											@update:model-value="model.ValDtrefere.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.EQUIP___EQUIPFIRST___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIP___EQUIPFIRST___"
										v-on="controls.EQUIP___EQUIPFIRST___.handlers"
										:loading="controls.EQUIP___EQUIPFIRST___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EQUIP___EQUIPFIRST___.props"
											@blur="onBlur(controls.EQUIP___EQUIPFIRST___, model.ValFirst.value)"
											@change="model.ValFirst.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.EQUIP___EQUIPBEFORE__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIP___EQUIPBEFORE__"
										v-on="controls.EQUIP___EQUIPBEFORE__.handlers"
										:loading="controls.EQUIP___EQUIPBEFORE__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EQUIP___EQUIPBEFORE__.props"
											@blur="onBlur(controls.EQUIP___EQUIPBEFORE__, model.ValBefore.value)"
											@change="model.ValBefore.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.EQUIP___EQUIPFOLLOWIN.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIP___EQUIPFOLLOWIN"
										v-on="controls.EQUIP___EQUIPFOLLOWIN.handlers"
										:loading="controls.EQUIP___EQUIPFOLLOWIN.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EQUIP___EQUIPFOLLOWIN.props"
											@blur="onBlur(controls.EQUIP___EQUIPFOLLOWIN, model.ValFollowin.value)"
											@change="model.ValFollowin.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.EQUIP___EQUIPLAST____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIP___EQUIPLAST____"
										v-on="controls.EQUIP___EQUIPLAST____.handlers"
										:loading="controls.EQUIP___EQUIPLAST____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EQUIP___EQUIPLAST____.props"
											@blur="onBlur(controls.EQUIP___EQUIPLAST____, model.ValLast.value)"
											@change="model.ValLast.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.EQUIP___EQUIPQTDMOVIM.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.EQUIP___EQUIPQTDMOVIM"
										v-on="controls.EQUIP___EQUIPQTDMOVIM.handlers"
										:loading="controls.EQUIP___EQUIPQTDMOVIM.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.EQUIP___EQUIPQTDMOVIM.isVisible"
											v-bind="controls.EQUIP___EQUIPQTDMOVIM.props"
											@update:model-value="model.ValQtdmovim.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.EQUIP___EQUIPMOVIMENT.isVisible">
								<q-control-wrapper
									v-show="controls.EQUIP___EQUIPMOVIMENT.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-static-text"
										v-bind="controls.EQUIP___EQUIPMOVIMENT"
										v-on="controls.EQUIP___EQUIPMOVIMENT.handlers"
										:loading="controls.EQUIP___EQUIPMOVIMENT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-static-text
											v-if="controls.EQUIP___EQUIPMOVIMENT.isVisible"
											id="EQUIP___EQUIPMOVIMENT"
											:size="controls.EQUIP___EQUIPMOVIMENT.size"
											:text="model.ValMoviment.value"
											supports-html />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container
								v-show="controls.EQUIP___PSEUDNOVOGR10.isVisible"
								is-large>
								<q-control-wrapper
									v-show="controls.EQUIP___PSEUDNOVOGR10.isVisible"
									class="row-line-group">
									<q-group-collapsible
										id="EQUIP___PSEUDNOVOGR10"
										v-bind="controls.EQUIP___PSEUDNOVOGR10"
										v-on="controls.EQUIP___PSEUDNOVOGR10.handlers">
										<!-- Start EQUIP___PSEUDNOVOGR10 -->
										<q-row-container v-show="controls.EQUIP___PSEUDMOVIMEVV.isVisible || controls.EQUIP___PSEUDROOMSMVE.isVisible">
											<q-control-wrapper
												v-show="controls.EQUIP___PSEUDMOVIMEVV.isVisible"
												class="control-join-group">
												<q-table
													v-show="controls.EQUIP___PSEUDMOVIMEVV.isVisible"
													v-bind="controls.EQUIP___PSEUDMOVIMEVV"
													v-on="controls.EQUIP___PSEUDMOVIMEVV.handlers" />
												<q-table-extra-extension
													:list-ctrl="controls.EQUIP___PSEUDMOVIMEVV"
													v-on="controls.EQUIP___PSEUDMOVIMEVV.handlers" />
											</q-control-wrapper>
											<q-control-wrapper
												v-show="controls.EQUIP___PSEUDROOMSMVE.isVisible"
												class="control-join-group">
												<base-input-structure
													class="i-text"
													v-bind="controls.EQUIP___PSEUDROOMSMVE"
													v-on="controls.EQUIP___PSEUDROOMSMVE.handlers"
													:loading="controls.EQUIP___PSEUDROOMSMVE.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-check-list-extension
														v-if="controls.EQUIP___PSEUDROOMSMVE.isVisible"
														id="EQUIP___PSEUDROOMSMVE"
														:options="controls.EQUIP___PSEUDMOVIMEVV.rows"
														:search-column-name="controls.EQUIP___PSEUDMOVIMEVV.columnsOriginal[0].name"
														:search-column-label="controls.EQUIP___PSEUDMOVIMEVV.columnsOriginal[0].label"
														:primary-key-column-name="controls.EQUIP___PSEUDMOVIMEVV.config.pkColumn"
														:texts="controls.EQUIP___PSEUDROOMSMVE.texts"
														:rows-selected="controls.EQUIP___PSEUDMOVIMEVV.rowsSelected"
														:disabled="controls.EQUIP___PSEUDROOMSMVE.readonly"
														@remove-label="onUnselectRow(controls.EQUIP___PSEUDMOVIMEVV, $event); model.List_Movimevv_SelectedIds.updateValue(rowKeyHashTableToArray(controls.EQUIP___PSEUDMOVIMEVV.rowsSelected))"
														@on-enter="onSelectRow(controls.EQUIP___PSEUDMOVIMEVV, $event); model.List_Movimevv_SelectedIds.updateValue(rowKeyHashTableToArray(controls.EQUIP___PSEUDMOVIMEVV.rowsSelected))" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<q-row-container v-show="controls.EQUIP___PSEUDMOVIMELS.isVisible">
											<q-control-wrapper
												v-show="controls.EQUIP___PSEUDMOVIMELS.isVisible"
												class="control-join-group">
												<q-table
													v-show="controls.EQUIP___PSEUDMOVIMELS.isVisible"
													v-bind="controls.EQUIP___PSEUDMOVIMELS"
													v-on="controls.EQUIP___PSEUDMOVIMELS.handlers" />
												<q-table-extra-extension
													:list-ctrl="controls.EQUIP___PSEUDMOVIMELS"
													v-on="controls.EQUIP___PSEUDMOVIMELS.handlers" />
											</q-control-wrapper>
										</q-row-container>
										<!-- End EQUIP___PSEUDNOVOGR10 -->
									</q-group-collapsible>
								</q-control-wrapper>
							</q-row-container>
							<!-- End EQUIP___PSEUDNOVOGR09 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.EQUIP___PSEUDNOVOGR06.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.EQUIP___PSEUDNOVOGR06.isVisible"
						class="row-line-group">
						<q-group-collapsible
							id="EQUIP___PSEUDNOVOGR06"
							v-bind="controls.EQUIP___PSEUDNOVOGR06"
							v-on="controls.EQUIP___PSEUDNOVOGR06.handlers">
							<!-- Start EQUIP___PSEUDNOVOGR06 -->
							<q-row-container v-show="controls.EQUIP___EQUIPPHOTOGRA.isVisible || controls.EQUIP___EQUIPLASTPHO_.isVisible">
								<q-control-wrapper
									v-show="controls.EQUIP___EQUIPPHOTOGRA.isVisible"
									class="control-join-group">
									<base-input-structure
										class="q-image"
										v-bind="controls.EQUIP___EQUIPPHOTOGRA"
										v-on="controls.EQUIP___EQUIPPHOTOGRA.handlers"
										:loading="controls.EQUIP___EQUIPPHOTOGRA.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-image
											v-if="controls.EQUIP___EQUIPPHOTOGRA.isVisible"
											v-bind="controls.EQUIP___EQUIPPHOTOGRA.props"
											v-on="controls.EQUIP___EQUIPPHOTOGRA.handlers" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.EQUIP___EQUIPLASTPHO_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="q-image"
										v-bind="controls.EQUIP___EQUIPLASTPHO_"
										v-on="controls.EQUIP___EQUIPLASTPHO_.handlers"
										:loading="controls.EQUIP___EQUIPLASTPHO_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-image
											v-if="controls.EQUIP___EQUIPLASTPHO_.isVisible"
											v-bind="controls.EQUIP___EQUIPLASTPHO_.props"
											v-on="controls.EQUIP___EQUIPLASTPHO_.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End EQUIP___PSEUDNOVOGR06 -->
						</q-group-collapsible>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.EQUIP___PSEUDNOVOGR05.isVisible || controls.EQUIP___PSEUDNOVOGR08.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.EQUIP___PSEUDNOVOGR05.isVisible"
						class="row-line-group">
						<q-accordion
							v-if="controls.EQUIP___PSEUDNOVOGR05.isVisible"
							id="EQUIP___PSEUDNOVOGR05"
							v-bind="controls.EQUIP___PSEUDNOVOGR05">
							<!-- Start EQUIP___PSEUDNOVOGR05 -->
							<q-group-collapsible
								id="EQUIP___PSEUDNOVOGR03"
								v-bind="controls.EQUIP___PSEUDNOVOGR03"
								v-on="controls.EQUIP___PSEUDNOVOGR03.handlers">
								<!-- Start EQUIP___PSEUDNOVOGR03 -->
								<q-row-container v-show="controls.EQUIP___PSEUDINSTALAG.isVisible">
									<q-control-wrapper
										v-show="controls.EQUIP___PSEUDINSTALAG.isVisible"
										class="control-join-group">
										<q-table
											v-show="controls.EQUIP___PSEUDINSTALAG.isVisible"
											v-bind="controls.EQUIP___PSEUDINSTALAG"
											v-on="controls.EQUIP___PSEUDINSTALAG.handlers" />
										<q-table-extra-extension
											:list-ctrl="controls.EQUIP___PSEUDINSTALAG"
											v-on="controls.EQUIP___PSEUDINSTALAG.handlers" />
									</q-control-wrapper>
								</q-row-container>
								<!-- End EQUIP___PSEUDNOVOGR03 -->
							</q-group-collapsible>
							<q-group-collapsible
								id="EQUIP___PSEUDNOVOGR04"
								v-bind="controls.EQUIP___PSEUDNOVOGR04"
								v-on="controls.EQUIP___PSEUDNOVOGR04.handlers">
								<!-- Start EQUIP___PSEUDNOVOGR04 -->
								<q-row-container v-show="controls.EQUIP___PSEUDINSTALAC.isVisible">
									<q-control-wrapper
										v-show="controls.EQUIP___PSEUDINSTALAC.isVisible"
										class="control-join-group">
										<q-table
											v-show="controls.EQUIP___PSEUDINSTALAC.isVisible"
											v-bind="controls.EQUIP___PSEUDINSTALAC"
											v-on="controls.EQUIP___PSEUDINSTALAC.handlers" />
										<q-table-extra-extension
											:list-ctrl="controls.EQUIP___PSEUDINSTALAC"
											v-on="controls.EQUIP___PSEUDINSTALAC.handlers" />
									</q-control-wrapper>
								</q-row-container>
								<!-- End EQUIP___PSEUDNOVOGR04 -->
							</q-group-collapsible>
							<q-group-collapsible
								id="EQUIP___PSEUDNOVOGR11"
								v-bind="controls.EQUIP___PSEUDNOVOGR11"
								v-on="controls.EQUIP___PSEUDNOVOGR11.handlers">
								<!-- Start EQUIP___PSEUDNOVOGR11 -->
								<q-row-container v-show="controls.EQUIP___PSEUDREPARACO.isVisible || controls.EQUIP___DECOMDECOMNR_.isVisible || controls.EQUIP___EQUIPIFABATIF.isVisible">
									<q-control-wrapper
										v-show="controls.EQUIP___PSEUDREPARACO.isVisible"
										class="control-join-group">
										<q-table
											v-show="controls.EQUIP___PSEUDREPARACO.isVisible"
											v-bind="controls.EQUIP___PSEUDREPARACO"
											v-on="controls.EQUIP___PSEUDREPARACO.handlers" />
										<q-table-extra-extension
											:list-ctrl="controls.EQUIP___PSEUDREPARACO"
											v-on="controls.EQUIP___PSEUDREPARACO.handlers" />
									</q-control-wrapper>
									<q-control-wrapper
										v-show="controls.EQUIP___DECOMDECOMNR_.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.EQUIP___DECOMDECOMNR_"
											v-on="controls.EQUIP___DECOMDECOMNR_.handlers"
											:loading="controls.EQUIP___DECOMDECOMNR_.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-lookup
												v-if="controls.EQUIP___DECOMDECOMNR_.isVisible"
												v-bind="controls.EQUIP___DECOMDECOMNR_.props"
												v-on="controls.EQUIP___DECOMDECOMNR_.handlers" />
											<q-see-more-equip-decomdecomnr
												v-if="controls.EQUIP___DECOMDECOMNR_.seeMoreIsVisible"
												v-bind="controls.EQUIP___DECOMDECOMNR_.seeMoreParams"
												v-on="controls.EQUIP___DECOMDECOMNR_.handlers" />
										</base-input-structure>
									</q-control-wrapper>
									<q-control-wrapper
										v-show="controls.EQUIP___EQUIPIFABATIF.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-checkbox"
											v-bind="controls.EQUIP___EQUIPIFABATIF"
											v-on="controls.EQUIP___EQUIPIFABATIF.handlers"
											:loading="controls.EQUIP___EQUIPIFABATIF.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<template #label>
												<q-checkbox-input
													v-if="controls.EQUIP___EQUIPIFABATIF.isVisible"
													v-bind="controls.EQUIP___EQUIPIFABATIF.props"
													v-on="controls.EQUIP___EQUIPIFABATIF.handlers" />
											</template>
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<!-- End EQUIP___PSEUDNOVOGR11 -->
							</q-group-collapsible>
							<!-- End EQUIP___PSEUDNOVOGR05 -->
						</q-accordion>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.EQUIP___PSEUDNOVOGR08.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="EQUIP___PSEUDNOVOGR08"
							v-bind="controls.EQUIP___PSEUDNOVOGR08"
							:is-visible="controls.EQUIP___PSEUDNOVOGR08.isVisible">
							<!-- Start EQUIP___PSEUDNOVOGR08 -->
							<q-row-container v-show="controls.EQUIP___PSEUDFOTOEQUI.isVisible">
								<q-control-wrapper
									v-show="controls.EQUIP___PSEUDFOTOEQUI.isVisible"
									class="control-join-group">
									<q-table
										v-show="controls.EQUIP___PSEUDFOTOEQUI.isVisible"
										v-bind="controls.EQUIP___PSEUDFOTOEQUI"
										v-on="controls.EQUIP___PSEUDFOTOEQUI.handlers" />
									<q-table-extra-extension
										:list-ctrl="controls.EQUIP___PSEUDFOTOEQUI"
										v-on="controls.EQUIP___PSEUDFOTOEQUI.handlers" />
								</q-control-wrapper>
							</q-row-container>
							<!-- End EQUIP___PSEUDNOVOGR08 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.EQUIP___PSEUDNOVOGR07.isVisible || controls.EQUIP___PSEUDNOVOGR12.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.EQUIP___PSEUDNOVOGR07.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="EQUIP___PSEUDNOVOGR07"
							v-bind="controls.EQUIP___PSEUDNOVOGR07"
							:is-visible="controls.EQUIP___PSEUDNOVOGR07.isVisible">
							<!-- Start EQUIP___PSEUDNOVOGR07 -->
							<q-row-container v-show="controls.EQUIP___PSEUDVISEQUIP.isVisible">
								<q-control-wrapper
									v-show="controls.EQUIP___PSEUDVISEQUIP.isVisible"
									class="control-join-group">
									<q-table
										v-show="controls.EQUIP___PSEUDVISEQUIP.isVisible"
										v-bind="controls.EQUIP___PSEUDVISEQUIP"
										v-on="controls.EQUIP___PSEUDVISEQUIP.handlers" />
									<q-table-extra-extension
										:list-ctrl="controls.EQUIP___PSEUDVISEQUIP"
										v-on="controls.EQUIP___PSEUDVISEQUIP.handlers" />
								</q-control-wrapper>
							</q-row-container>
							<!-- End EQUIP___PSEUDNOVOGR07 -->
						</q-group-box-container>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.EQUIP___PSEUDNOVOGR12.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="EQUIP___PSEUDNOVOGR12"
							v-bind="controls.EQUIP___PSEUDNOVOGR12"
							:is-visible="controls.EQUIP___PSEUDNOVOGR12.isVisible">
							<!-- Start EQUIP___PSEUDNOVOGR12 -->
							<q-row-container v-show="controls.EQUIP___PSEUDANEXOS__.isVisible">
								<q-control-wrapper
									v-show="controls.EQUIP___PSEUDANEXOS__.isVisible"
									class="control-join-group">
									<q-table
										v-show="controls.EQUIP___PSEUDANEXOS__.isVisible"
										v-bind="controls.EQUIP___PSEUDANEXOS__"
										v-on="controls.EQUIP___PSEUDANEXOS__.handlers" />
									<q-table-extra-extension
										:list-ctrl="controls.EQUIP___PSEUDANEXOS__"
										v-on="controls.EQUIP___PSEUDANEXOS__.handlers" />
								</q-control-wrapper>
							</q-row-container>
							<!-- End EQUIP___PSEUDNOVOGR12 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.EQUIP___PSEUDTLEQUIPA.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.EQUIP___PSEUDTLEQUIPA.isVisible"
						class="row-line-group">
						<q-timeline
							id="EQUIP___PSEUDTLEQUIPA"
							v-bind="controls.EQUIP___PSEUDTLEQUIPA"
							@show-popup="timelineOpenForm" />
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

	import FormViewModel from './QFormEquipViewModel.js'

	const requiredTextResources = ['QFormEquip', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS EQUIP]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormEquip',

		components: {
			QSeeMoreEquipCmpnydesignat: defineAsyncComponent(() => import('@/views/forms/FormEquip/dbedits/EquipCmpnydesignatSeeMore.vue')),
			QSeeMoreEquipPess1name: defineAsyncComponent(() => import('@/views/forms/FormEquip/dbedits/EquipPess1nameSeeMore.vue')),
			QSeeMoreEquipTpequtipoequi: defineAsyncComponent(() => import('@/views/forms/FormEquip/dbedits/EquipTpequtipoequiSeeMore.vue')),
			QSeeMoreEquipWarehwarehdes: defineAsyncComponent(() => import('@/views/forms/FormEquip/dbedits/EquipWarehwarehdesSeeMore.vue')),
			QSeeMoreEquipItemItemdes: defineAsyncComponent(() => import('@/views/forms/FormEquip/dbedits/EquipItemItemdesSeeMore.vue')),
			QSeeMoreEquipDecomdecomnr: defineAsyncComponent(() => import('@/views/forms/FormEquip/dbedits/EquipDecomdecomnrSeeMore.vue')),
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
					name: 'EQUIP',
					location: 'form-EQUIP',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormEquip', false),

				interfaceMetadata: {
					id: 'QFormEquip', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'EQUIP',
					route: 'form-EQUIP',
					area: 'EQUIP',
					primaryKey: 'ValCodequip',
					designation: computed(() => genericFunctions.formatString(this.Resources._EQUIP__REGISTNR____25672, vm.model.ValRegistnr.displayValue, vm.model.ValDesignat.displayValue, vm.model.TableTpequTipoequi.displayValue)),
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
					EQUIP___PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'EQUIP___PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'block',
						label: computed(() => this.Resources.COMPANY52963),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: true,
						anchored: false,
						directChildren: ['EQUIP___CMPNYDESIGNAT', 'EQUIP___PESS1NAME____'],
						controlLimits: [
						],
					}, this),
					EQUIP___CMPNYDESIGNAT: new fieldControlClass.LookupControl({
						modelField: 'TableCmpnyDesignat',
						valueChangeEvent: 'fieldChange:cmpny.designat',
						id: 'EQUIP___CMPNYDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.COMPANY_22615),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR02',
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
							dependencyEvent: 'fieldChange:equip.codempre'
						},
						dependentFields: () => ({
							set 'cmpny.codempre'(value) { vm.model.ValCodempre.updateValue(value) },
							set 'cmpny.designat'(value) { vm.model.TableCmpnyDesignat.updateValue(value) },
						}),
						insertEnabled: true,
						supportForm: 'EMPRE',
						controlLimits: [
						],
					}, this),
					EQUIP___PESS1NAME____: new fieldControlClass.LookupControl({
						modelField: 'TablePess1Name',
						valueChangeEvent: 'fieldChange:pess1.name',
						id: 'EQUIP___PESS1NAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.PERSON10446),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR02',
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
					EQUIP___PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'EQUIP___PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						helpControl: {
							shortHelp: {
								type: '',
								text: computed(() => this.Resources._111418227),
							},
							detailedHelp: {
								type: '',
								text: computed(() => this.Resources._1114_VERBOSE42095),
							}
						},
						label: computed(() => this.Resources.EQUIPMENT38184),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: true,
						directChildren: ['EQUIP___EQUIPSEQUENNR', 'EQUIP___EQUIPREGISTNR', 'EQUIP___TPEQUTIPOEQUI', 'EQUIP___EQUIPSITEFABR', 'EQUIP___WAREHWAREHDES', 'EQUIP___ITEM_ITEMDES_', 'EQUIP___EQUIPDESIGNAT', 'EQUIP___EQUIPFREQUENC', 'EQUIP___EQUIPVALORTOT', 'EQUIP___EQUIPDTAQUISI', 'EQUIP___EQUIPDTDECO__', 'EQUIP___EQUIPBOUGHT__'],
						controlLimits: [
						],
					}, this),
					EQUIP___EQUIPSEQUENNR: new fieldControlClass.NumberControl({
						modelField: 'ValSequennr',
						valueChangeEvent: 'fieldChange:equip.sequennr',
						id: 'EQUIP___EQUIPSEQUENNR',
						name: 'SEQUENNR',
						size: 'small',
						label: computed(() => this.Resources.SEQUENTIAL_NO_04803),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR01',
						maxIntegers: 6,
						maxDecimals: 0,
						isSequencial: true,
						controlLimits: [
						],
					}, this),
					EQUIP___EQUIPREGISTNR: new fieldControlClass.StringControl({
						modelField: 'ValRegistnr',
						valueChangeEvent: 'fieldChange:equip.registnr',
						id: 'EQUIP___EQUIPREGISTNR',
						name: 'REGISTNR',
						size: 'small',
						label: computed(() => this.Resources.REGISTRATION_NO_06209),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR01',
						isFormulaBlocked: true,
						maxLength: 6,
						labelId: 'label_EQUIP___EQUIPREGISTNR',
						controlLimits: [
						],
					}, this),
					EQUIP___TPEQUTIPOEQUI: new fieldControlClass.LookupControl({
						modelField: 'TableTpequTipoequi',
						valueChangeEvent: 'fieldChange:tpequ.tipoequi',
						id: 'EQUIP___TPEQUTIPOEQUI',
						name: 'TIPOEQUI',
						size: 'xlarge',
						label: computed(() => this.Resources.TYPE_OF_EQUIPMENT64921),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR01',
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
						}),
						insertEnabled: true,
						supportForm: 'TPEQU',
						controlLimits: [
						],
					}, this),
					EQUIP___EQUIPSITEFABR: new fieldControlClass.StringControl({
						modelField: 'ValSitefabr',
						valueChangeEvent: 'fieldChange:equip.sitefabr',
						id: 'EQUIP___EQUIPSITEFABR',
						name: 'SITEFABR',
						size: 'xxlarge',
						label: computed(() => this.Resources.MANUFACTURER_S_WEBSI12156),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR01',
						maxLength: 256,
						labelId: 'label_EQUIP___EQUIPSITEFABR',
						controlLimits: [
						],
					}, this),
					EQUIP___WAREHWAREHDES: new fieldControlClass.LookupControl({
						modelField: 'TableWarehWarehdes',
						valueChangeEvent: 'fieldChange:wareh.warehdes',
						id: 'EQUIP___WAREHWAREHDES',
						name: 'WAREHDES',
						size: 'xxlarge',
						label: computed(() => this.Resources.WAREHOUSE51864),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR01',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodwareh',
							dependencyEvent: 'fieldChange:equip.codwareh'
						},
						dependentFields: () => ({
							set 'wareh.codwareh'(value) { vm.model.ValCodwareh.updateValue(value) },
							set 'wareh.warehdes'(value) { vm.model.TableWarehWarehdes.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					EQUIP___ITEM_ITEMDES_: new fieldControlClass.LookupControl({
						modelField: 'TableItemItemdes',
						valueChangeEvent: 'fieldChange:item.itemdes',
						id: 'EQUIP___ITEM_ITEMDES_',
						name: 'ITEMDES',
						size: 'xxlarge',
						label: computed(() => this.Resources.ITEM_31041),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR01',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCoditem',
							dependencyEvent: 'fieldChange:equip.coditem'
						},
						dependentFields: () => ({
							set 'item.coditem'(value) { vm.model.ValCoditem.updateValue(value) },
							set 'item.itemdes'(value) { vm.model.TableItemItemdes.updateValue(value) },
						}),
						controlLimits: [
							{
								identifier: ['wareh', 'equip.codwareh'],
								dependencyEvents: ['fieldChange:equip.codwareh'],
								dependencyField: 'EQUIP.CODWAREH',
								fnValueSelector: (model) => model.ValCodwareh.value
							},
						],
					}, this),
					EQUIP___EQUIPDESIGNAT: new fieldControlClass.StringControl({
						modelField: 'ValDesignat',
						valueChangeEvent: 'fieldChange:equip.designat',
						id: 'EQUIP___EQUIPDESIGNAT',
						name: 'DESIGNAT',
						size: 'xxlarge',
						label: computed(() => this.Resources.DESIGNATION_35800),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR01',
						maxLength: 85,
						labelId: 'label_EQUIP___EQUIPDESIGNAT',
						controlLimits: [
						],
					}, this),
					EQUIP___EQUIPFREQUENC: new fieldControlClass.ArrayNumberControl({
						modelField: 'ValFrequenc',
						valueChangeEvent: 'fieldChange:equip.frequenc',
						id: 'EQUIP___EQUIPFREQUENC',
						name: 'FREQUENC',
						size: 'small',
						helpControl: {
							shortHelp: {
								type: 'Tooltip',
								text: computed(() => this.Resources.___1438719),
							},
						},
						label: computed(() => this.Resources.LOAN_FREQUENCY00930),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR01',
						arrayName: 'FreqEmpr',
						helpShortItem: '',
						helpDetailedItem: '',
						controlLimits: [
						],
					}, this),
					EQUIP___EQUIPVALORTOT: new fieldControlClass.CurrencyControl({
						modelField: 'ValValortot',
						valueChangeEvent: 'fieldChange:equip.valortot',
						id: 'EQUIP___EQUIPVALORTOT',
						name: 'VALORTOT',
						size: 'medium',
						label: computed(() => this.Resources.TOTAL_VALUE_07456),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR01',
						isFormulaBlocked: true,
						maxIntegers: 9,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					EQUIP___EQUIPDTAQUISI: new fieldControlClass.DateControl({
						modelField: 'ValDtaquisi',
						valueChangeEvent: 'fieldChange:equip.dtaquisi',
						id: 'EQUIP___EQUIPDTAQUISI',
						name: 'DTAQUISI',
						size: 'small',
						label: computed(() => this.Resources.ACQUISITION_53832),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR01',
						format: 'date',
						controlLimits: [
						],
					}, this),
					EQUIP___EQUIPDTDECO__: new fieldControlClass.DateControl({
						modelField: 'ValDtdeco',
						valueChangeEvent: 'fieldChange:equip.dtdeco',
						id: 'EQUIP___EQUIPDTDECO__',
						name: 'DTDECO',
						size: 'small',
						label: computed(() => this.Resources.DECOMISSION_04392),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR01',
						isFormulaBlocked: true,
						format: 'dateTime',
						controlLimits: [
						],
					}, this),
					EQUIP___EQUIPBOUGHT__: new fieldControlClass.BooleanControl({
						modelField: 'ValBought',
						valueChangeEvent: 'fieldChange:equip.bought',
						id: 'EQUIP___EQUIPBOUGHT__',
						name: 'BOUGHT',
						size: 'mini',
						label: computed(() => this.Resources.BOUGHT35496),
						placeholder: '',
						labelPosition: computed(() => this.layoutConfig.CheckboxLabelAlignment),
						container: 'EQUIP___PSEUDNOVOGR01',
						isFormulaBlocked: true,
						controlLimits: [
						],
					}, this),
					EQUIP___PSEUDNOVOGR09: new fieldControlClass.GroupControl({
						id: 'EQUIP___PSEUDNOVOGR09',
						name: 'NOVOGR09',
						size: 'block',
						label: computed(() => this.Resources.ASSET_LOCATION64080),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: true,
						directChildren: ['EQUIP___ROOM1ROOMNR__', 'EQUIP___ROOM1DESIGNAT', 'EQUIP___EQUIPDTREFERE', 'EQUIP___EQUIPFIRST___', 'EQUIP___EQUIPBEFORE__', 'EQUIP___EQUIPFOLLOWIN', 'EQUIP___EQUIPLAST____', 'EQUIP___EQUIPQTDMOVIM', 'EQUIP___EQUIPMOVIMENT', 'EQUIP___PSEUDNOVOGR10'],
						controlLimits: [
						],
					}, this),
					EQUIP___ROOM1ROOMNR__: new fieldControlClass.LookupControl({
						modelField: 'TableRoom1Roomnr',
						valueChangeEvent: 'fieldChange:room1.roomnr',
						id: 'EQUIP___ROOM1ROOMNR__',
						name: 'ROOMNR',
						size: 'small',
						label: computed(() => this.Resources.ROOM_NO_15796),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR09',
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
							name: 'ValCodrooms',
							dependencyEvent: 'fieldChange:equip.codrooms'
						},
						dependentFields: () => ({
							set 'room1.codrooms'(value) { vm.model.ValCodrooms.updateValue(value) },
							set 'room1.roomnr'(value) { vm.model.TableRoom1Roomnr.updateValue(value) },
							set 'room1.designat'(value) { vm.model.Room1ValDesignat.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					EQUIP___ROOM1DESIGNAT: new fieldControlClass.StringControl({
						modelField: 'Room1ValDesignat',
						valueChangeEvent: 'fieldChange:room1.designat',
						dependentModelField: 'ValCodrooms',
						dependentChangeEvent: 'fieldChange:equip.codrooms',
						id: 'EQUIP___ROOM1DESIGNAT',
						name: 'DESIGNAT',
						size: 'xlarge',
						label: computed(() => this.Resources.ROOM_DESIGNATION_33759),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR09',
						isFormulaBlocked: true,
						maxLength: 50,
						labelId: 'label_EQUIP___ROOM1DESIGNAT',
						controlLimits: [
						],
					}, this),
					EQUIP___EQUIPDTREFERE: new fieldControlClass.DateControl({
						modelField: 'ValDtrefere',
						valueChangeEvent: 'fieldChange:equip.dtrefere',
						id: 'EQUIP___EQUIPDTREFERE',
						name: 'DTREFERE',
						size: 'medium',
						label: computed(() => this.Resources.REFERENCE28402),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR09',
						format: 'dateTime',
						controlLimits: [
						],
					}, this),
					EQUIP___EQUIPFIRST___: new fieldControlClass.StringControl({
						modelField: 'ValFirst',
						valueChangeEvent: 'fieldChange:equip.first',
						id: 'EQUIP___EQUIPFIRST___',
						name: 'FIRST',
						size: 'small',
						label: computed(() => this.Resources.FIRST42972),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR09',
						isFormulaBlocked: true,
						maxLength: 10,
						labelId: 'label_EQUIP___EQUIPFIRST___',
						controlLimits: [
						],
					}, this),
					EQUIP___EQUIPBEFORE__: new fieldControlClass.StringControl({
						modelField: 'ValBefore',
						valueChangeEvent: 'fieldChange:equip.before',
						id: 'EQUIP___EQUIPBEFORE__',
						name: 'BEFORE',
						size: 'small',
						label: computed(() => this.Resources.BEFORE60156),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR09',
						isFormulaBlocked: true,
						maxLength: 10,
						labelId: 'label_EQUIP___EQUIPBEFORE__',
						controlLimits: [
						],
					}, this),
					EQUIP___EQUIPFOLLOWIN: new fieldControlClass.StringControl({
						modelField: 'ValFollowin',
						valueChangeEvent: 'fieldChange:equip.followin',
						id: 'EQUIP___EQUIPFOLLOWIN',
						name: 'FOLLOWIN',
						size: 'small',
						label: computed(() => this.Resources.FOLLOWING22170),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR09',
						isFormulaBlocked: true,
						maxLength: 10,
						labelId: 'label_EQUIP___EQUIPFOLLOWIN',
						controlLimits: [
						],
					}, this),
					EQUIP___EQUIPLAST____: new fieldControlClass.StringControl({
						modelField: 'ValLast',
						valueChangeEvent: 'fieldChange:equip.last',
						id: 'EQUIP___EQUIPLAST____',
						name: 'LAST',
						size: 'small',
						label: computed(() => this.Resources.LAST48120),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR09',
						isFormulaBlocked: true,
						maxLength: 10,
						labelId: 'label_EQUIP___EQUIPLAST____',
						controlLimits: [
						],
					}, this),
					EQUIP___EQUIPQTDMOVIM: new fieldControlClass.NumberControl({
						modelField: 'ValQtdmovim',
						valueChangeEvent: 'fieldChange:equip.qtdmovim',
						id: 'EQUIP___EQUIPQTDMOVIM',
						name: 'QTDMOVIM',
						size: 'medium',
						label: computed(() => this.Resources.QUANTITY_OF_TRANSACT63133),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR09',
						isFormulaBlocked: true,
						maxIntegers: 10,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					EQUIP___EQUIPMOVIMENT: new fieldControlClass.MultilineStringControl({
						modelField: 'ValMoviment',
						valueChangeEvent: 'fieldChange:equip.moviment',
						id: 'EQUIP___EQUIPMOVIMENT',
						name: 'MOVIMENT',
						size: 'large',
						label: computed(() => this.Resources.MOVEMENTS47007),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR09',
						isFormulaBlocked: true,
						supportsHtml: true,
						controlLimits: [
						],
					}, this),
					EQUIP___PSEUDNOVOGR10: new fieldControlClass.GroupControl({
						id: 'EQUIP___PSEUDNOVOGR10',
						name: 'NOVOGR10',
						size: 'block',
						label: computed(() => this.Resources.WHERE_DID_THE_EQUIPM11916),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR09',
						isCollapsible: true,
						anchored: false,
						directChildren: ['EQUIP___PSEUDMOVIMEVV', 'EQUIP___PSEUDROOMSMVE', 'EQUIP___PSEUDMOVIMELS'],
						controlLimits: [
						],
					}, this),
					EQUIP___PSEUDMOVIMEVV: new fieldControlClass.MultipleValuesControl({
						id: 'EQUIP___PSEUDMOVIMEVV',
						name: 'MOVIMEVV',
						size: '',
						helpControl: {
							shortHelp: {
								type: 'Subtitle',
								text: computed(() => this.Resources._112319369),
							},
							detailedHelp: {
								type: 'Popover',
								text: computed(() => this.Resources._1123_VERBOSE50467),
							}
						},
						label: computed(() => this.Resources.CHOOSE_ROOM04275),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR10',
						controller: 'EQUIP',
						action: 'Equip_List_Movimevv',
						hasDependencies: true,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValRoomnr',
								area: 'ROOMS',
								field: 'ROOMNR',
								label: computed(() => this.Resources.N_R__ROOM43805),
								dataLength: 10,
								scrollData: 10,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValDesignat',
								area: 'ROOMS',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.ROOM_DESIGNATION37895),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValMovimevv',
							serverMode: true,
							pkColumn: 'ValCodrooms',
							tableAlias: 'ROOMS',
							tableNamePlural: computed(() => this.Resources.ROOMS06809),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.CHOOSE_ROOM04275),
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
						globalEvents: ['changed-ROOMS'],
						uuid: 'Equip_ValMovimevv',
						allSelectedRows: 'false',
						modelField: 'List_Movimevv_SelectedIds',
						valueChangeEvent: 'fieldChange:pseud.List_Movimevv_SelectedIds',
						modelFieldOptions: 'List_Movimevv',
						controlLimits: [
							{
								identifier: ['id', 'equip'],
								dependencyEvents: ['fieldChange:equip.codequip'],
								dependencyField: 'EQUIP.CODEQUIP',
								fnValueSelector: (model) => model.ValCodequip.value
							},
						],
					}, this),
					EQUIP___PSEUDROOMSMVE: new fieldControlClass.MultipleValuesExtensionControl({
						id: 'EQUIP___PSEUDROOMSMVE',
						name: 'ROOMSMVE',
						size: 'medium',
						label: computed(() => this.Resources.MULTIPLE_VALUES_EXTE07457),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR10',
						controlLimits: [
						],
					}, this),
					EQUIP___PSEUDMOVIMELS: new fieldControlClass.TableListControl({
						id: 'EQUIP___PSEUDMOVIMELS',
						name: 'MOVIMELS',
						size: '',
						label: computed(() => this.Resources.EQUIPMENT_MOVEMENT_H06876),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR10',
						controller: 'EQUIP',
						action: 'Equip_ValMovimels',
						hasDependencies: true,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValDhmudanc',
								area: 'MOVIM',
								field: 'DHMUDANC',
								label: computed(() => this.Resources.CHANGE36355),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'Rooms.ValRoomnr',
								area: 'ROOMS',
								field: 'ROOMNR',
								label: computed(() => this.Resources.N_R__ROOM43805),
								dataLength: 10,
								scrollData: 10,
								pkColumn: 'ValCodrooms',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'Rooms.ValDesignat',
								area: 'ROOMS',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.ROOM_DESIGNATION37895),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodrooms',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValObservat',
								area: 'MOVIM',
								field: 'OBSERVAT',
								label: computed(() => this.Resources.OBSERVATION37880),
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValMovimels',
							serverMode: true,
							pkColumn: 'ValCodmovim',
							tableAlias: 'MOVIM',
							tableNamePlural: computed(() => this.Resources.DRIVES34119),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.EQUIPMENT_MOVEMENT_H06876),
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
										formName: 'MOVIM',
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
										formName: 'MOVIM',
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
										formName: 'MOVIM',
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
										formName: 'MOVIM',
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
										formName: 'MOVIM',
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
								id: 'RCA__MOVIM',
								name: '_MOVIM',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'MOVIM',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'MOVIM': {
									fnKeySelector: (row) => row.Fields.ValCodmovim,
									isPopup: false
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'ValDhmudanc',
								sortOrder: 'desc'
							}
						},
						globalEvents: ['changed-EQUIP', 'changed-MOVIM', 'changed-ROOMS'],
						uuid: 'Equip_ValMovimels',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'equip'],
								dependencyEvents: ['fieldChange:equip.codequip'],
								dependencyField: 'EQUIP.CODEQUIP',
								fnValueSelector: (model) => model.ValCodequip.value
							},
						],
					}, this),
					EQUIP___PSEUDNOVOGR06: new fieldControlClass.GroupControl({
						id: 'EQUIP___PSEUDNOVOGR06',
						name: 'NOVOGR06',
						size: 'block',
						label: computed(() => this.Resources.PHOTO32097),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: true,
						anchored: false,
						directChildren: ['EQUIP___EQUIPPHOTOGRA', 'EQUIP___EQUIPLASTPHO_'],
						controlLimits: [
						],
					}, this),
					EQUIP___EQUIPPHOTOGRA: new fieldControlClass.ImageControl({
						modelField: 'ValPhotogra',
						valueChangeEvent: 'fieldChange:equip.photogra',
						id: 'EQUIP___EQUIPPHOTOGRA',
						name: 'PHOTOGRA',
						size: 'medium',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR06',
						height: 50,
						width: 30,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO51874)),
						controlLimits: [
						],
					}, this),
					EQUIP___EQUIPLASTPHO_: new fieldControlClass.ImageControl({
						modelField: 'ValLastpho',
						valueChangeEvent: 'fieldChange:equip.lastpho',
						id: 'EQUIP___EQUIPLASTPHO_',
						name: 'LASTPHO',
						size: 'medium',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR06',
						isFormulaBlocked: true,
						height: 50,
						width: 30,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO51874)),
						controlLimits: [
						],
					}, this),
					EQUIP___PSEUDNOVOGR05: new fieldControlClass.AccordionControl({
						id: 'EQUIP___PSEUDNOVOGR05',
						name: 'NOVOGR05',
						size: 'block',
						label: computed(() => this.Resources.ACCORDION01950),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['EQUIP___PSEUDNOVOGR03', 'EQUIP___PSEUDNOVOGR04', 'EQUIP___PSEUDNOVOGR11'],
						controlLimits: [
						],
					}, this),
					EQUIP___PSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'EQUIP___PSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'xxlarge',
						label: computed(() => this.Resources.INSTALACOES05030),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR05',
						isCollapsible: true,
						anchored: false,
						directChildren: ['EQUIP___PSEUDINSTALAG'],
						controlLimits: [
						],
					}, this),
					EQUIP___PSEUDINSTALAG: new fieldControlClass.TableListControl({
						id: 'EQUIP___PSEUDINSTALAG',
						name: 'INSTALAG',
						size: '',
						label: computed(() => this.Resources.FACILITIES_23844),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR03',
						controller: 'EQUIP',
						action: 'Equip_ValInstalag',
						hasDependencies: true,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValSince',
								area: 'INSTA',
								field: 'SINCE',
								label: computed(() => this.Resources.SINCE47259),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 2,
								name: 'ValUntil',
								area: 'INSTA',
								field: 'UNTIL',
								label: computed(() => this.Resources.UNTIL39173),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 3,
								name: 'ValHours',
								area: 'INSTA',
								field: 'HOURS',
								label: computed(() => this.Resources.QTD_HOURS28684),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 4,
								name: 'ValPrecohor',
								area: 'INSTA',
								field: 'PRECOHOR',
								label: computed(() => this.Resources.HOURLY_PRICE48005),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 5,
								name: 'ValValue',
								area: 'INSTA',
								field: 'VALUE',
								label: computed(() => this.Resources.VALUE10285),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValInstalag',
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
						globalEvents: ['changed-INSTA', 'changed-EQUIP', 'changed-TPEQU'],
						uuid: 'Equip_ValInstalag',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'equip'],
								dependencyEvents: ['fieldChange:equip.codequip'],
								dependencyField: 'EQUIP.CODEQUIP',
								fnValueSelector: (model) => model.ValCodequip.value
							},
						],
					}, this),
					EQUIP___PSEUDNOVOGR04: new fieldControlClass.GroupControl({
						id: 'EQUIP___PSEUDNOVOGR04',
						name: 'NOVOGR04',
						size: 'xxlarge',
						label: computed(() => this.Resources.LOCALS50556),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR05',
						isCollapsible: true,
						anchored: false,
						directChildren: ['EQUIP___PSEUDINSTALAC'],
						controlLimits: [
						],
					}, this),
					EQUIP___PSEUDINSTALAC: new fieldControlClass.TableSpecialRenderingControl({
						id: 'EQUIP___PSEUDINSTALAC',
						name: 'INSTALAC',
						size: '',
						label: computed(() => this.Resources.FACILITIES_23844),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR04',
						controller: 'EQUIP',
						action: 'Equip_ValInstalac',
						hasDependencies: true,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValSince',
								area: 'INSTA',
								field: 'SINCE',
								label: computed(() => this.Resources.SINCE47259),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 2,
								name: 'ValUntil',
								area: 'INSTA',
								field: 'UNTIL',
								label: computed(() => this.Resources.UNTIL39173),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 3,
								name: 'ValHours',
								area: 'INSTA',
								field: 'HOURS',
								label: computed(() => this.Resources.QTD_HOURS28684),
								scrollData: 10,
								maxDigits: 7,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 4,
								name: 'ValPrecohor',
								area: 'INSTA',
								field: 'PRECOHOR',
								label: computed(() => this.Resources.HOURLY_PRICE48005),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 5,
								name: 'ValValue',
								area: 'INSTA',
								field: 'VALUE',
								label: computed(() => this.Resources.VALUE10285),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.GeographicColumn({
								order: 6,
								name: 'ValCoordgeo',
								area: 'INSTA',
								field: 'COORDGEO',
								label: computed(() => this.Resources.GEOGRAPHIC_COORDINAT21394),
								dataLength: 50,
								scrollData: 30,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
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
						globalEvents: ['changed-INSTA', 'changed-EQUIP', 'changed-TPEQU'],
						uuid: 'Equip_ValInstalac',
						allSelectedRows: 'false',
						viewModes: [
							{
								id: 'LIST',
								type: 'list',
								subtype: '',
								label: computed(() => this.Resources.LISTA13474),
								order: 1,
								mappingVariables: readonly({
								}),
								styleVariables: {
								},
								groups: {
								}
							},
							{
								id: 'MAP',
								type: 'map',
								subtype: 'leaflet-map',
								label: computed(() => this.Resources.MAPA24527),
								order: 2,
								mappingVariables: readonly({
									geographicData: {
										allowsMultiple: true,
										sources: [
											'INSTA.COORDGEO',
										]
									},
								}),
								styleVariables: {
									zoomLevel: {
										rawValue: 6,
										isMapped: false
									},
									minZoom: {
										rawValue: 0,
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
										rawValue: true,
										isMapped: false
									},
									centerCoord: {
										rawValue: 'POINT(-8.5 39)',
										isMapped: false
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
										rawValue: '75vh',
										isMapped: false
									},
									allowMarkers: {
										rawValue: true,
										isMapped: false
									},
									allowPolylines: {
										rawValue: true,
										isMapped: false
									},
									allowPolygons: {
										rawValue: true,
										isMapped: false
									},
									allowEdit: {
										rawValue: true,
										isMapped: false
									},
									allowDrag: {
										rawValue: true,
										isMapped: false
									},
									allowCutting: {
										rawValue: true,
										isMapped: false
									},
									allowRemoval: {
										rawValue: true,
										isMapped: false
									},
									allowRotate: {
										rawValue: true,
										isMapped: false
									},
									shapeOutlineWeight: {
										rawValue: 7,
										isMapped: false
									},
									polylineColor: {
										rawValue: '#079ede',
										isMapped: false
									},
									polygonColor: {
										rawValue: '#118f13',
										isMapped: false
									},
									circleColor: {
										rawValue: '#f53505',
										isMapped: false
									},
									groupMarkersInCluster: {
										rawValue: true,
										isMapped: false
									},
									allowExporting: {
										rawValue: true,
										isMapped: false
									},
									backgroundOverlay: {
										rawValue: 'OpenStreetMap',
										isMapped: false
									},
									openPopupOnHover: {
										rawValue: false,
										isMapped: false
									},
								},
								groups: {
									externalLayer: [
									],
								}
							},
						],
						controlLimits: [
							{
								identifier: ['id', 'equip'],
								dependencyEvents: ['fieldChange:equip.codequip'],
								dependencyField: 'EQUIP.CODEQUIP',
								fnValueSelector: (model) => model.ValCodequip.value
							},
						],
					}, this),
					EQUIP___PSEUDNOVOGR11: new fieldControlClass.GroupControl({
						id: 'EQUIP___PSEUDNOVOGR11',
						name: 'NOVOGR11',
						size: 'xxlarge',
						label: computed(() => this.Resources.REPAIRS42202),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR05',
						isCollapsible: true,
						anchored: false,
						directChildren: ['EQUIP___PSEUDREPARACO', 'EQUIP___DECOMDECOMNR_', 'EQUIP___EQUIPIFABATIF'],
						controlLimits: [
						],
					}, this),
					EQUIP___PSEUDREPARACO: new fieldControlClass.TableListControl({
						id: 'EQUIP___PSEUDREPARACO',
						name: 'REPARACO',
						size: '',
						label: computed(() => this.Resources.EQUIPMENT_REPAIRS62266),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR11',
						controller: 'EQUIP',
						action: 'Equip_ValReparaco',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.NumericColumn({
								order: 1,
								name: 'ValNrrepara',
								area: 'REPAR',
								field: 'NRREPARA',
								label: computed(() => this.Resources.NO_RUMOUR_IN_THE_COM15248),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 2,
								name: 'ValDtrepara',
								area: 'REPAR',
								field: 'DTREPARA',
								label: computed(() => this.Resources.FIXED_IN00179),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'Cate1.ValCategoria',
								area: 'CATE1',
								field: 'CATEGORIA',
								label: computed(() => this.Resources.SPECIALTY09304),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodcateg',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'Pesso.ValName',
								area: 'PESSO',
								field: 'NAME',
								label: computed(() => this.Resources.EXPERT27393),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodpesso',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValDescript',
								area: 'REPAR',
								field: 'DESCRIPT',
								label: computed(() => this.Resources.DESCRIPTION_OF_THE_R26085),
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 6,
								name: 'ValHours',
								area: 'REPAR',
								field: 'HOURS',
								label: computed(() => this.Resources.SPENT_ON_HOURS19285),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 7,
								name: 'ValTipoarea',
								area: 'REPAR',
								field: 'TIPOAREA',
								label: computed(() => this.Resources.TECHNICAL_AREA50773),
								dataLength: 1,
								scrollData: 1,
								array: computed(() => qProjArrays.QArrayAreatecn.setResources(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayAreatecn.type,
								arrayDisplayMode: 'D',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValReparaco',
							serverMode: true,
							pkColumn: 'ValCodrepar',
							tableAlias: 'REPAR',
							tableNamePlural: computed(() => this.Resources.REPAIRS18165),
							viewManagement: 'M',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.EQUIPMENT_REPAIRS62266),
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
										formName: 'REPAR',
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
										formName: 'REPAR',
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
										formName: 'REPAR',
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
										formName: 'REPAR',
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
										formName: 'REPAR',
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
								id: 'RCA__REPAR',
								name: '_REPAR',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'REPAR',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'REPAR': {
									fnKeySelector: (row) => row.Fields.ValCodrepar,
									isPopup: false
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'ValNrrepara',
								sortOrder: 'asc'
							}
						},
						groupFilters: [
							{
								id: 'filter_ValReparaco_STARTED',
								isMultiple: true,
								filters: [
									{
										id: 'filter_ValReparaco_STARTED_1',
										key: '1',
										value: computed(() => this.Resources.SPECIALTY09304),
										selected: false
									},
									{
										id: 'filter_ValReparaco_STARTED_2',
										key: '2',
										value: computed(() => this.Resources.DESCRIPTION07383),
										selected: false
									},
									{
										id: 'filter_ValReparaco_STARTED_3',
										key: '3',
										value: computed(() => this.Resources.SPENT_ON_HOURS19285),
										selected: false
									},
								],
								value: '',
								defaultValue: ''
							},
						],
						globalEvents: ['changed-EQUIP', 'changed-PESSO', 'changed-REPAR', 'changed-CATE1', 'changed-SPECI', 'changed-CMPNY'],
						uuid: 'Equip_ValReparaco',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'equip'],
								dependencyEvents: ['fieldChange:equip.codequip'],
								dependencyField: 'EQUIP.CODEQUIP',
								fnValueSelector: (model) => model.ValCodequip.value
							},
						],
					}, this),
					EQUIP___DECOMDECOMNR_: new fieldControlClass.LookupControl({
						modelField: 'TableDecomDecomnr',
						valueChangeEvent: 'fieldChange:decom.decomnr',
						id: 'EQUIP___DECOMDECOMNR_',
						name: 'DECOMNR',
						size: 'small',
						label: computed(() => this.Resources.DECOMISSION_NO_16646),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR11',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCoddeco',
							dependencyEvent: 'fieldChange:equip.coddeco'
						},
						dependentFields: () => ({
							set 'decom.coddeco'(value) { vm.model.ValCoddeco.updateValue(value) },
							set 'decom.decomnr'(value) { vm.model.TableDecomDecomnr.updateValue(value) },
						}),
						insertEnabled: true,
						supportForm: 'ABATE',
						controlLimits: [
						],
					}, this),
					EQUIP___EQUIPIFABATIF: new fieldControlClass.BooleanControl({
						modelField: 'ValIfabatif',
						valueChangeEvent: 'fieldChange:equip.ifabatif',
						id: 'EQUIP___EQUIPIFABATIF',
						name: 'IFABATIF',
						size: 'medium',
						label: computed(() => this.Resources.DOWNED_EQUIPMENT43331),
						placeholder: '',
						labelPosition: computed(() => this.layoutConfig.CheckboxLabelAlignment),
						container: 'EQUIP___PSEUDNOVOGR11',
						isFormulaBlocked: true,
						controlLimits: [
						],
					}, this),
					EQUIP___PSEUDNOVOGR08: new fieldControlClass.GroupControl({
						id: 'EQUIP___PSEUDNOVOGR08',
						name: 'NOVOGR08',
						size: 'xxlarge',
						label: computed(() => this.Resources.PHOTOS_42586),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: true,
						directChildren: ['EQUIP___PSEUDFOTOEQUI'],
						controlLimits: [
						],
					}, this),
					EQUIP___PSEUDFOTOEQUI: new fieldControlClass.TableListControl({
						id: 'EQUIP___PSEUDFOTOEQUI',
						name: 'FOTOEQUI',
						size: '',
						label: computed(() => this.Resources.PHOTOS39221),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR08',
						controller: 'EQUIP',
						action: 'Equip_ValFotoequi',
						hasDependencies: true,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValTitle',
								area: 'PHOTO',
								field: 'TITLE',
								label: computed(() => this.Resources.TITLE21885),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 2,
								name: 'ValPhotogra',
								area: 'PHOTO',
								field: 'PHOTOGRA',
								label: computed(() => this.Resources.PHOTO51874),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.PHOTO51874)),
								scrollData: 3,
								sortable: false,
								searchable: false,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValFotoequi',
							serverMode: true,
							pkColumn: 'ValCodphoto',
							tableAlias: 'PHOTO',
							tableNamePlural: computed(() => this.Resources.PHOTOGRAPHS43092),
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
										action: vm.openFormAction,
										type: 'form',
										formName: 'FOTOS',
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
										formName: 'FOTOS',
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
										formName: 'FOTOS',
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
										formName: 'FOTOS',
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
										formName: 'FOTOS',
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
								id: 'RCA__FOTOS',
								name: '_FOTOS',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'FOTOS',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'FOTOS': {
									fnKeySelector: (row) => row.Fields.ValCodphoto,
									isPopup: false
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: 'ValTitle',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-EQUIP', 'changed-PHOTO'],
						uuid: 'Equip_ValFotoequi',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'equip'],
								dependencyEvents: ['fieldChange:equip.codequip'],
								dependencyField: 'EQUIP.CODEQUIP',
								fnValueSelector: (model) => model.ValCodequip.value
							},
						],
					}, this),
					EQUIP___PSEUDNOVOGR07: new fieldControlClass.GroupControl({
						id: 'EQUIP___PSEUDNOVOGR07',
						name: 'NOVOGR07',
						size: 'block',
						label: computed(() => this.Resources.INSPECTION_VISITS19524),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: true,
						directChildren: ['EQUIP___PSEUDVISEQUIP'],
						controlLimits: [
						],
					}, this),
					EQUIP___PSEUDVISEQUIP: new fieldControlClass.TableSpecialRenderingControl({
						id: 'EQUIP___PSEUDVISEQUIP',
						name: 'VISEQUIP',
						size: '',
						label: computed(() => this.Resources.VISITS_63312),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR07',
						controller: 'EQUIP',
						action: 'Equip_ValVisequip',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValTitle',
								area: 'VISIT',
								field: 'TITLE',
								label: computed(() => this.Resources.TITLE21885),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 2,
								name: 'ValStartdt',
								area: 'VISIT',
								field: 'STARTDT',
								label: computed(() => this.Resources.BEGINNING18124),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 3,
								name: 'ValDtfim',
								area: 'VISIT',
								field: 'DTFIM',
								label: computed(() => this.Resources.END47577),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValDescript',
								area: 'VISIT',
								field: 'DESCRIPT',
								label: computed(() => this.Resources.DESCRIPTION07383),
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 5,
								name: 'ValTodoodia',
								area: 'VISIT',
								field: 'TODOODIA',
								label: computed(() => this.Resources.DAY27593),
								scrollData: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'ValColor',
								area: 'VISIT',
								field: 'COLOR',
								label: computed(() => this.Resources.COLOR55628),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.BooleanColumn({
								order: 7,
								name: 'ValBack',
								area: 'VISIT',
								field: 'BACK',
								label: computed(() => this.Resources.BACKGROUND45121),
								scrollData: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValVisequip',
							serverMode: true,
							pkColumn: 'ValCodvisit',
							tableAlias: 'VISIT',
							tableNamePlural: computed(() => this.Resources.VISITS33669),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.VISITS_63312),
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
										formName: 'VISIT',
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
										formName: 'VISIT',
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
										formName: 'VISIT',
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
										formName: 'VISIT',
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
										formName: 'VISIT',
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
								id: 'RCA__VISIT',
								name: '_VISIT',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'VISIT',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'VISIT': {
									fnKeySelector: (row) => row.Fields.ValCodvisit,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValTitle',
							defaultSearchColumnNameOriginal: 'ValTitle',
							defaultColumnSorting: {
								columnName: 'ValTitle',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-VISIT', 'changed-EQUIP'],
						uuid: 'Equip_ValVisequip',
						allSelectedRows: 'false',
						viewModes: [
							{
								id: 'LIST',
								type: 'list',
								subtype: '',
								label: computed(() => this.Resources.LISTA13474),
								order: 1,
								mappingVariables: readonly({
								}),
								styleVariables: {
								},
								groups: {
								}
							},
							{
								id: 'CALENDAR',
								type: 'calendar',
								subtype: '',
								label: computed(() => this.Resources.CALENDARIO10837),
								order: 2,
								mappingVariables: readonly({
									eventTitle: {
										allowsMultiple: false,
										sources: [
											'VISIT.TITLE',
										]
									},
									eventStart: {
										allowsMultiple: false,
										sources: [
											'VISIT.STARTDT',
										]
									},
									eventEnd: {
										allowsMultiple: false,
										sources: [
											'VISIT.DTFIM',
										]
									},
									eventDescription: {
										allowsMultiple: false,
										sources: [
											'VISIT.DESCRIPT',
										]
									},
									eventAllDay: {
										allowsMultiple: false,
										sources: [
											'VISIT.TODOODIA',
										]
									},
									eventColor: {
										allowsMultiple: false,
										sources: [
											'VISIT.COLOR',
										]
									},
									eventIsBackground: {
										allowsMultiple: false,
										sources: [
											'VISIT.BACK',
										]
									},
								}),
								styleVariables: {
									viewDayGridDay: {
										rawValue: false,
										isMapped: false
									},
									viewDayGridWeek: {
										rawValue: false,
										isMapped: false
									},
									viewDayGridMonth: {
										rawValue: true,
										isMapped: false
									},
									viewTimeGridDay: {
										rawValue: false,
										isMapped: false
									},
									viewTimeGridWeek: {
										rawValue: false,
										isMapped: false
									},
									viewListDay: {
										rawValue: false,
										isMapped: false
									},
									viewListWeek: {
										rawValue: false,
										isMapped: false
									},
									viewListMonth: {
										rawValue: false,
										isMapped: false
									},
									viewListYear: {
										rawValue: false,
										isMapped: false
									},
									viewResourceTimelineDay: {
										rawValue: false,
										isMapped: false
									},
									viewResourceTimelineWeek: {
										rawValue: false,
										isMapped: false
									},
									viewResourceTimelineMonth: {
										rawValue: false,
										isMapped: false
									},
									viewResourceTimelineYear: {
										rawValue: false,
										isMapped: false
									},
									viewResourceTimeGridDay: {
										rawValue: false,
										isMapped: false
									},
									viewResourceTimeGridWeek: {
										rawValue: false,
										isMapped: false
									},
									viewResourceDayGridDay: {
										rawValue: false,
										isMapped: false
									},
									initialView: {
										rawValue: undefined,
										isMapped: false
									},
									extraWeekends: {
										rawValue: true,
										isMapped: false
									},
									extraEventsOverlap: {
										rawValue: false,
										isMapped: false
									},
									extraAutoHeight: {
										rawValue: false,
										isMapped: false
									},
									extraMaxHeight: {
										rawValue: 750,
										isMapped: false
									},
									extraNoTooltips: {
										rawValue: false,
										isMapped: false
									},
									extraAllDaySlot: {
										rawValue: true,
										isMapped: false
									},
									extraFullReload: {
										rawValue: false,
										isMapped: false
									},
									extraSlotMinTime: {
										rawValue: undefined,
										isMapped: false
									},
									extraSlotMaxTime: {
										rawValue: undefined,
										isMapped: false
									},
									extraNoDates: {
										rawValue: false,
										isMapped: false
									},
									extraLimitRangeStart: {
										rawValue: undefined,
										isMapped: false
									},
									extraLimitRangeEnd: {
										rawValue: undefined,
										isMapped: false
									},
									extraHour12: {
										rawValue: false,
										isMapped: false
									},
									extraSlotDuration: {
										rawValue: undefined,
										isMapped: false
									},
									extraSlotLabelInterval: {
										rawValue: undefined,
										isMapped: false
									},
								},
								groups: {
								}
							},
						],
						exportOptions: 'dayGridMonth,timeGridWeek,timeGridDay',
						controlLimits: [
							{
								identifier: ['id', 'equip'],
								dependencyEvents: ['fieldChange:equip.codequip'],
								dependencyField: 'EQUIP.CODEQUIP',
								fnValueSelector: (model) => model.ValCodequip.value
							},
						],
					}, this),
					EQUIP___PSEUDNOVOGR12: new fieldControlClass.GroupControl({
						id: 'EQUIP___PSEUDNOVOGR12',
						name: 'NOVOGR12',
						size: 'xxlarge',
						label: computed(() => this.Resources.DIGITAL_ATTACHMENTS64891),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: true,
						directChildren: ['EQUIP___PSEUDANEXOS__'],
						controlLimits: [
						],
					}, this),
					EQUIP___PSEUDANEXOS__: new fieldControlClass.TableListControl({
						id: 'EQUIP___PSEUDANEXOS__',
						name: 'ANEXOS',
						size: '',
						label: computed(() => this.Resources.DIGITAL_ATTACHMENTS64891),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EQUIP___PSEUDNOVOGR12',
						controller: 'EQUIP',
						action: 'Equip_ValAnexos',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValDthranex',
								area: 'ANEXD',
								field: 'DTHRANEX',
								label: computed(() => this.Resources.ATTACHED26247),
								scrollData: 16,
								dateTimeType: 'dateTime',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValTitle',
								area: 'ANEXD',
								field: 'TITLE',
								label: computed(() => this.Resources.TITLE21885),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DocumentColumn({
								order: 3,
								name: 'ValDocument',
								area: 'ANEXD',
								field: 'DOCUMENT',
								label: computed(() => this.Resources.DOCUMENT00695),
								dataLength: 260,
								scrollData: 30,
								sortable: false,
								viewType: qEnums.documentViewTypeMode.print,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValAnexos',
							serverMode: true,
							pkColumn: 'ValCodanexd',
							tableAlias: 'ANEXD',
							tableNamePlural: computed(() => this.Resources.DIGITAL_ATTACHEMENTS44886),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.DIGITAL_ATTACHMENTS64891),
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
										formName: 'ANEXD',
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
										formName: 'ANEXD',
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
										formName: 'ANEXD',
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
										formName: 'ANEXD',
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
										formName: 'ANEXD',
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
								id: 'RCA__ANEXD',
								name: '_ANEXD',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'ANEXD',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'ANEXD': {
									fnKeySelector: (row) => row.Fields.ValCodanexd,
									isPopup: false
								},
							},
							insertCondition: {
								// eslint-disable-next-line no-unused-vars
								fnFormula(params)
								{
									return netAPI.postData(
										'Anexd',
										'ANEXD_InsertCondition',
										this.serverObjModel,
										undefined,
										undefined,
										undefined,
										this.navigationId)
								},
								dependencyEvents: ['fieldChange:equip.codequip'],
								isServerRecalc: false,
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-EQUIP', 'changed-ANEXD', 'changed-LANGU'],
						uuid: 'Equip_ValAnexos',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'equip'],
								dependencyEvents: ['fieldChange:equip.codequip'],
								dependencyField: 'EQUIP.CODEQUIP',
								fnValueSelector: (model) => model.ValCodequip.value
							},
						],
					}, this),
					EQUIP___PSEUDTLEQUIPA: new fieldControlClass.TimelineControl({
						id: 'EQUIP___PSEUDTLEQUIPA',
						name: 'TLEQUIPA',
						size: 'block',
						label: computed(() => this.Resources.TIMELINE45857),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'EQUIP',
						action: 'Equip_ValTlequipa',
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
					'EQUIP___PSEUDNOVOGR02',
					'EQUIP___PSEUDNOVOGR01',
					'EQUIP___PSEUDNOVOGR09',
					'EQUIP___PSEUDNOVOGR10',
					'EQUIP___PSEUDNOVOGR06',
					'EQUIP___PSEUDNOVOGR05',
					'EQUIP___PSEUDNOVOGR03',
					'EQUIP___PSEUDNOVOGR04',
					'EQUIP___PSEUDNOVOGR11',
					'EQUIP___PSEUDNOVOGR08',
					'EQUIP___PSEUDNOVOGR07',
					'EQUIP___PSEUDNOVOGR12',
				]),

				tableFields: readonly([
					'EQUIP___PSEUDMOVIMEVV',
					'EQUIP___PSEUDMOVIMELS',
					'EQUIP___PSEUDINSTALAG',
					'EQUIP___PSEUDINSTALAC',
					'EQUIP___PSEUDREPARACO',
					'EQUIP___PSEUDFOTOEQUI',
					'EQUIP___PSEUDVISEQUIP',
					'EQUIP___PSEUDANEXOS__',
				]),

				timelineFields: readonly([
					'EQUIP___PSEUDTLEQUIPA',
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Cmpny: {
						get ValDesignat() { return vm.model.TableCmpnyDesignat.value },
						set ValDesignat(value) { vm.model.TableCmpnyDesignat.updateValue(value) },
					},
					Decom: {
						get ValDecomnr() { return vm.model.TableDecomDecomnr.value },
						set ValDecomnr(value) { vm.model.TableDecomDecomnr.updateValue(value) },
					},
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
						get ValFollowin() { return vm.model.ValFollowin.value },
						set ValFollowin(value) { vm.model.ValFollowin.updateValue(value) },
						get ValFrequenc() { return vm.model.ValFrequenc.value },
						set ValFrequenc(value) { vm.model.ValFrequenc.updateValue(value) },
						get ValIfabatif() { return vm.model.ValIfabatif.value },
						set ValIfabatif(value) { vm.model.ValIfabatif.updateValue(value) },
						get ValLast() { return vm.model.ValLast.value },
						set ValLast(value) { vm.model.ValLast.updateValue(value) },
						get ValLastpho() { return vm.model.ValLastpho.value },
						set ValLastpho(value) { vm.model.ValLastpho.updateValue(value) },
						get ValMoviment() { return vm.model.ValMoviment.value },
						set ValMoviment(value) { vm.model.ValMoviment.updateValue(value) },
						get ValPhotogra() { return vm.model.ValPhotogra.value },
						set ValPhotogra(value) { vm.model.ValPhotogra.updateValue(value) },
						get ValQtdmovim() { return vm.model.ValQtdmovim.value },
						set ValQtdmovim(value) { vm.model.ValQtdmovim.updateValue(value) },
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
					Pess1: {
						get ValName() { return vm.model.TablePess1Name.value },
						set ValName(value) { vm.model.TablePess1Name.updateValue(value) },
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
// USE /[MANUAL GQT FORM_CODEJS EQUIP]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS EQUIP]/
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
// USE /[MANUAL GQT FORM_LOADED_JS EQUIP]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS EQUIP]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS EQUIP]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS EQUIP]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS EQUIP]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS EQUIP]/
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
// USE /[MANUAL GQT AFTER_DEL_JS EQUIP]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS EQUIP]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS EQUIP]/
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
// USE /[MANUAL GQT DLGUPDT EQUIP]/
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
// USE /[MANUAL GQT CTRLBLR EQUIP]/
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
// USE /[MANUAL GQT CTRLUPD EQUIP]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS EQUIP]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
			'controls.EQUIP___PSEUDMOVIMEVV.rowsSelected': {
				handler()
				{
					const value = this.rowKeyHashTableToArray(this.controls.EQUIP___PSEUDMOVIMEVV.rowsSelected)
					this.model.List_Movimevv_SelectedIds.updateValue(value)
				},
				deep: true
			},
		}
	}
</script>
