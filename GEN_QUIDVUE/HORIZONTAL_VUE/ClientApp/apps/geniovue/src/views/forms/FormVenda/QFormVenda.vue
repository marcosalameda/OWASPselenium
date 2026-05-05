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
			data-key="VENDA"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.VENDA___ORGANORGANIZA.isVisible">
					<q-control-wrapper
						v-show="controls.VENDA___ORGANORGANIZA.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-text"
							v-bind="controls.VENDA___ORGANORGANIZA"
							v-on="controls.VENDA___ORGANORGANIZA.handlers"
							:loading="controls.VENDA___ORGANORGANIZA.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.VENDA___ORGANORGANIZA.isVisible"
								v-bind="controls.VENDA___ORGANORGANIZA.props"
								v-on="controls.VENDA___ORGANORGANIZA.handlers" />
							<q-see-more-venda-organorganiza
								v-if="controls.VENDA___ORGANORGANIZA.seeMoreIsVisible"
								v-bind="controls.VENDA___ORGANORGANIZA.seeMoreParams"
								v-on="controls.VENDA___ORGANORGANIZA.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.VENDA___SALE_NRLIDE__.isVisible || controls.VENDA___SALE_STARTDT_.isVisible">
					<q-control-wrapper
						v-show="controls.VENDA___SALE_NRLIDE__.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-text"
							v-bind="controls.VENDA___SALE_NRLIDE__"
							v-on="controls.VENDA___SALE_NRLIDE__.handlers"
							:loading="controls.VENDA___SALE_NRLIDE__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.VENDA___SALE_NRLIDE__.isVisible"
								v-bind="controls.VENDA___SALE_NRLIDE__.props"
								@update:model-value="model.ValNrlide.fnUpdateValue" />
						</base-input-structure>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.VENDA___SALE_STARTDT_.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<base-input-structure
							class="i-text"
							v-bind="controls.VENDA___SALE_STARTDT_"
							v-on="controls.VENDA___SALE_STARTDT_.handlers"
							:loading="controls.VENDA___SALE_STARTDT_.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-date-time-picker
								v-if="controls.VENDA___SALE_STARTDT_.isVisible"
								v-bind="controls.VENDA___SALE_STARTDT_.props"
								:model-value="model.ValStartdt.value"
								@reset-icon-click="model.ValStartdt.fnUpdateValue(model.ValStartdt.originalValue ?? new Date())"
								@update:model-value="model.ValStartdt.fnUpdateValue($event ?? '')" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.VENDA___PSEUDNOVOGR01.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.VENDA___PSEUDNOVOGR01.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<q-group-box-container
							id="VENDA___PSEUDNOVOGR01"
							v-bind="controls.VENDA___PSEUDNOVOGR01"
							:is-visible="controls.VENDA___PSEUDNOVOGR01.isVisible">
							<!-- Start VENDA___PSEUDNOVOGR01 -->
							<q-row-container v-show="controls.VENDA___SALE_IDENTIFI.isVisible || controls.VENDA___SALE_POTCOMPR.isVisible || controls.VENDA___SALE_PROSPECC.isVisible">
								<q-control-wrapper
									v-show="controls.VENDA___SALE_IDENTIFI.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-text"
										v-bind="controls.VENDA___SALE_IDENTIFI"
										v-on="controls.VENDA___SALE_IDENTIFI.handlers"
										:loading="controls.VENDA___SALE_IDENTIFI.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.VENDA___SALE_IDENTIFI.props"
											@blur="onBlur(controls.VENDA___SALE_IDENTIFI, model.ValIdentifi.value)"
											@change="model.ValIdentifi.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.VENDA___SALE_POTCOMPR.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-text"
										v-bind="controls.VENDA___SALE_POTCOMPR"
										v-on="controls.VENDA___SALE_POTCOMPR.handlers"
										:loading="controls.VENDA___SALE_POTCOMPR.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.VENDA___SALE_POTCOMPR.props"
											@blur="onBlur(controls.VENDA___SALE_POTCOMPR, model.ValPotcompr.value)"
											@change="model.ValPotcompr.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.VENDA___SALE_PROSPECC.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.VENDA___SALE_PROSPECC"
										v-on="controls.VENDA___SALE_PROSPECC.handlers"
										:loading="controls.VENDA___SALE_PROSPECC.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.VENDA___SALE_PROSPECC.isVisible"
												v-bind="controls.VENDA___SALE_PROSPECC.props"
												v-on="controls.VENDA___SALE_PROSPECC.handlers" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End VENDA___PSEUDNOVOGR01 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.VENDA___PSEUDNOVOGR02.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.VENDA___PSEUDNOVOGR02.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<q-group-box-container
							id="VENDA___PSEUDNOVOGR02"
							v-bind="controls.VENDA___PSEUDNOVOGR02"
							:is-visible="controls.VENDA___PSEUDNOVOGR02.isVisible">
							<!-- Start VENDA___PSEUDNOVOGR02 -->
							<q-row-container v-show="controls.VENDA___SALE_INTERESS.isVisible || controls.VENDA___SALE_SEMRFINA.isVisible || controls.VENDA___SALE_SEMCAPAC.isVisible || controls.VENDA___SALE_DTQUALIF.isVisible || controls.VENDA___SALE_QUALIFIC.isVisible">
								<q-control-wrapper
									v-show="controls.VENDA___SALE_INTERESS.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.VENDA___SALE_INTERESS"
										v-on="controls.VENDA___SALE_INTERESS.handlers"
										:loading="controls.VENDA___SALE_INTERESS.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.VENDA___SALE_INTERESS.isVisible"
												v-bind="controls.VENDA___SALE_INTERESS.props"
												v-on="controls.VENDA___SALE_INTERESS.handlers" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.VENDA___SALE_SEMRFINA.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.VENDA___SALE_SEMRFINA"
										v-on="controls.VENDA___SALE_SEMRFINA.handlers"
										:loading="controls.VENDA___SALE_SEMRFINA.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.VENDA___SALE_SEMRFINA.isVisible"
												v-bind="controls.VENDA___SALE_SEMRFINA.props"
												v-on="controls.VENDA___SALE_SEMRFINA.handlers" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.VENDA___SALE_SEMCAPAC.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.VENDA___SALE_SEMCAPAC"
										v-on="controls.VENDA___SALE_SEMCAPAC.handlers"
										:loading="controls.VENDA___SALE_SEMCAPAC.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.VENDA___SALE_SEMCAPAC.isVisible"
												v-bind="controls.VENDA___SALE_SEMCAPAC.props"
												v-on="controls.VENDA___SALE_SEMCAPAC.handlers" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.VENDA___SALE_DTQUALIF.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-text"
										v-bind="controls.VENDA___SALE_DTQUALIF"
										v-on="controls.VENDA___SALE_DTQUALIF.handlers"
										:loading="controls.VENDA___SALE_DTQUALIF.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.VENDA___SALE_DTQUALIF.isVisible"
											v-bind="controls.VENDA___SALE_DTQUALIF.props"
											:model-value="model.ValDtqualif.value"
											@reset-icon-click="model.ValDtqualif.fnUpdateValue(model.ValDtqualif.originalValue ?? new Date())"
											@update:model-value="model.ValDtqualif.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.VENDA___SALE_QUALIFIC.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.VENDA___SALE_QUALIFIC"
										v-on="controls.VENDA___SALE_QUALIFIC.handlers"
										:loading="controls.VENDA___SALE_QUALIFIC.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.VENDA___SALE_QUALIFIC.isVisible"
												v-bind="controls.VENDA___SALE_QUALIFIC.props"
												v-on="controls.VENDA___SALE_QUALIFIC.handlers" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End VENDA___PSEUDNOVOGR02 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.VENDA___PSEUDNOVOGR03.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.VENDA___PSEUDNOVOGR03.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<q-group-box-container
							id="VENDA___PSEUDNOVOGR03"
							v-bind="controls.VENDA___PSEUDNOVOGR03"
							:is-visible="controls.VENDA___PSEUDNOVOGR03.isVisible">
							<!-- Start VENDA___PSEUDNOVOGR03 -->
							<q-row-container v-show="controls.VENDA___SALE_PREABORD.isVisible || controls.VENDA___SALE_HOMEWORK.isVisible">
								<q-control-wrapper
									v-show="controls.VENDA___SALE_PREABORD.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-text"
										v-bind="controls.VENDA___SALE_PREABORD"
										v-on="controls.VENDA___SALE_PREABORD.handlers"
										:loading="controls.VENDA___SALE_PREABORD.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.VENDA___SALE_PREABORD.isVisible"
											v-bind="controls.VENDA___SALE_PREABORD.props"
											:model-value="model.ValPreabord.value"
											@reset-icon-click="model.ValPreabord.fnUpdateValue(model.ValPreabord.originalValue ?? new Date())"
											@update:model-value="model.ValPreabord.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.VENDA___SALE_HOMEWORK.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.VENDA___SALE_HOMEWORK"
										v-on="controls.VENDA___SALE_HOMEWORK.handlers"
										:loading="controls.VENDA___SALE_HOMEWORK.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.VENDA___SALE_HOMEWORK.isVisible"
												v-bind="controls.VENDA___SALE_HOMEWORK.props"
												v-on="controls.VENDA___SALE_HOMEWORK.handlers" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End VENDA___PSEUDNOVOGR03 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.VENDA___PSEUDNOVOGR04.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.VENDA___PSEUDNOVOGR04.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<q-group-box-container
							id="VENDA___PSEUDNOVOGR04"
							v-bind="controls.VENDA___PSEUDNOVOGR04"
							:is-visible="controls.VENDA___PSEUDNOVOGR04.isVisible">
							<!-- Start VENDA___PSEUDNOVOGR04 -->
							<q-row-container v-show="controls.VENDA___SALE_DTABORDA.isVisible || controls.VENDA___SALE_APPROACH.isVisible">
								<q-control-wrapper
									v-show="controls.VENDA___SALE_DTABORDA.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-text"
										v-bind="controls.VENDA___SALE_DTABORDA"
										v-on="controls.VENDA___SALE_DTABORDA.handlers"
										:loading="controls.VENDA___SALE_DTABORDA.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.VENDA___SALE_DTABORDA.isVisible"
											v-bind="controls.VENDA___SALE_DTABORDA.props"
											:model-value="model.ValDtaborda.value"
											@reset-icon-click="model.ValDtaborda.fnUpdateValue(model.ValDtaborda.originalValue ?? new Date())"
											@update:model-value="model.ValDtaborda.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.VENDA___SALE_APPROACH.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.VENDA___SALE_APPROACH"
										v-on="controls.VENDA___SALE_APPROACH.handlers"
										:loading="controls.VENDA___SALE_APPROACH.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.VENDA___SALE_APPROACH.isVisible"
												v-bind="controls.VENDA___SALE_APPROACH.props"
												v-on="controls.VENDA___SALE_APPROACH.handlers" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End VENDA___PSEUDNOVOGR04 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.VENDA___PSEUDNOVOGR05.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.VENDA___PSEUDNOVOGR05.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<q-group-box-container
							id="VENDA___PSEUDNOVOGR05"
							v-bind="controls.VENDA___PSEUDNOVOGR05"
							:is-visible="controls.VENDA___PSEUDNOVOGR05.isVisible">
							<!-- Start VENDA___PSEUDNOVOGR05 -->
							<q-row-container v-show="controls.VENDA___SALE_DTAPRESE.isVisible || controls.VENDA___SALE_APRESENT.isVisible">
								<q-control-wrapper
									v-show="controls.VENDA___SALE_DTAPRESE.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-text"
										v-bind="controls.VENDA___SALE_DTAPRESE"
										v-on="controls.VENDA___SALE_DTAPRESE.handlers"
										:loading="controls.VENDA___SALE_DTAPRESE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.VENDA___SALE_DTAPRESE.isVisible"
											v-bind="controls.VENDA___SALE_DTAPRESE.props"
											:model-value="model.ValDtaprese.value"
											@reset-icon-click="model.ValDtaprese.fnUpdateValue(model.ValDtaprese.originalValue ?? new Date())"
											@update:model-value="model.ValDtaprese.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.VENDA___SALE_APRESENT.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.VENDA___SALE_APRESENT"
										v-on="controls.VENDA___SALE_APRESENT.handlers"
										:loading="controls.VENDA___SALE_APRESENT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox-input
												v-if="controls.VENDA___SALE_APRESENT.isVisible"
												v-bind="controls.VENDA___SALE_APRESENT.props"
												v-on="controls.VENDA___SALE_APRESENT.handlers" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End VENDA___PSEUDNOVOGR05 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.VENDA___PSEUDNOVOGR06.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.VENDA___PSEUDNOVOGR06.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<q-group-box-container
							id="VENDA___PSEUDNOVOGR06"
							v-bind="controls.VENDA___PSEUDNOVOGR06"
							:is-visible="controls.VENDA___PSEUDNOVOGR06.isVisible">
							<!-- Start VENDA___PSEUDNOVOGR06 -->
							<q-row-container v-show="controls.VENDA___SALE_DTSUPERA.isVisible">
								<q-control-wrapper
									v-show="controls.VENDA___SALE_DTSUPERA.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-text"
										v-bind="controls.VENDA___SALE_DTSUPERA"
										v-on="controls.VENDA___SALE_DTSUPERA.handlers"
										:loading="controls.VENDA___SALE_DTSUPERA.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.VENDA___SALE_DTSUPERA.isVisible"
											v-bind="controls.VENDA___SALE_DTSUPERA.props"
											:model-value="model.ValDtsupera.value"
											@reset-icon-click="model.ValDtsupera.fnUpdateValue(model.ValDtsupera.originalValue ?? new Date())"
											@update:model-value="model.ValDtsupera.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End VENDA___PSEUDNOVOGR06 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.VENDA___PSEUDNOVOGR07.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.VENDA___PSEUDNOVOGR07.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<q-group-box-container
							id="VENDA___PSEUDNOVOGR07"
							v-bind="controls.VENDA___PSEUDNOVOGR07"
							:is-visible="controls.VENDA___PSEUDNOVOGR07.isVisible">
							<!-- Start VENDA___PSEUDNOVOGR07 -->
							<q-row-container v-show="controls.VENDA___SALE_TENTFECH.isVisible || controls.VENDA___SALE_DTVENDA_.isVisible">
								<q-control-wrapper
									v-show="controls.VENDA___SALE_TENTFECH.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-text"
										v-bind="controls.VENDA___SALE_TENTFECH"
										v-on="controls.VENDA___SALE_TENTFECH.handlers"
										:loading="controls.VENDA___SALE_TENTFECH.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.VENDA___SALE_TENTFECH.isVisible"
											v-bind="controls.VENDA___SALE_TENTFECH.props"
											:model-value="model.ValTentfech.value"
											@reset-icon-click="model.ValTentfech.fnUpdateValue(model.ValTentfech.originalValue ?? new Date())"
											@update:model-value="model.ValTentfech.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.VENDA___SALE_DTVENDA_.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-text"
										v-bind="controls.VENDA___SALE_DTVENDA_"
										v-on="controls.VENDA___SALE_DTVENDA_.handlers"
										:loading="controls.VENDA___SALE_DTVENDA_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.VENDA___SALE_DTVENDA_.isVisible"
											v-bind="controls.VENDA___SALE_DTVENDA_.props"
											:model-value="model.ValDtvenda.value"
											@reset-icon-click="model.ValDtvenda.fnUpdateValue(model.ValDtvenda.originalValue ?? new Date())"
											@update:model-value="model.ValDtvenda.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End VENDA___PSEUDNOVOGR07 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.VENDA___PSEUDNOVOGR08.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.VENDA___PSEUDNOVOGR08.isVisible"
						class="${Vue.GetControlWrapperClass($controlsColumn)}">
						<q-group-box-container
							id="VENDA___PSEUDNOVOGR08"
							v-bind="controls.VENDA___PSEUDNOVOGR08"
							:is-visible="controls.VENDA___PSEUDNOVOGR08.isVisible">
							<!-- Start VENDA___PSEUDNOVOGR08 -->
							<q-row-container v-show="controls.VENDA___SALE_DTACOMPA.isVisible">
								<q-control-wrapper
									v-show="controls.VENDA___SALE_DTACOMPA.isVisible"
									class="${Vue.GetControlWrapperClass($controlsColumn)}">
									<base-input-structure
										class="i-text"
										v-bind="controls.VENDA___SALE_DTACOMPA"
										v-on="controls.VENDA___SALE_DTACOMPA.handlers"
										:loading="controls.VENDA___SALE_DTACOMPA.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.VENDA___SALE_DTACOMPA.isVisible"
											v-bind="controls.VENDA___SALE_DTACOMPA.props"
											:model-value="model.ValDtacompa.value"
											@reset-icon-click="model.ValDtacompa.fnUpdateValue(model.ValDtacompa.originalValue ?? new Date())"
											@update:model-value="model.ValDtacompa.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End VENDA___PSEUDNOVOGR08 -->
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

	import FormViewModel from './QFormVendaViewModel.js'

	const requiredTextResources = ['QFormVenda', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS VENDA]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormVenda',

		components: {
			QSeeMoreVendaOrganorganiza: defineAsyncComponent(() => import('@/views/forms/FormVenda/dbedits/VendaOrganorganizaSeeMore.vue')),
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
					name: 'VENDA',
					location: 'form-VENDA',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormVenda', false),

				interfaceMetadata: {
					id: 'QFormVenda', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'VENDA',
					route: 'form-VENDA',
					area: 'SALE',
					primaryKey: 'ValCodvenda',
					designation: computed(() => this.Resources.SALE02786),
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
					VENDA___ORGANORGANIZA: new fieldControlClass.LookupControl({
						modelField: 'TableOrganOrganiza',
						valueChangeEvent: 'fieldChange:organ.organiza',
						id: 'VENDA___ORGANORGANIZA',
						name: 'ORGANIZA',
						size: 'xxlarge',
						label: computed(() => this.Resources.ORGANIZATION64123),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodorgan',
							dependencyEvent: 'fieldChange:sale.codorgan'
						},
						dependentFields: () => ({
							set 'organ.codorgan'(value) { vm.model.ValCodorgan.updateValue(value) },
							set 'organ.organiza'(value) { vm.model.TableOrganOrganiza.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					VENDA___SALE_NRLIDE__: new fieldControlClass.NumberControl({
						modelField: 'ValNrlide',
						valueChangeEvent: 'fieldChange:sale.nrlide',
						id: 'VENDA___SALE_NRLIDE__',
						name: 'NRLIDE',
						size: 'small',
						label: computed(() => this.Resources.LEADER_NO_11905),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 10,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					VENDA___SALE_STARTDT_: new fieldControlClass.DateControl({
						modelField: 'ValStartdt',
						valueChangeEvent: 'fieldChange:sale.startdt',
						id: 'VENDA___SALE_STARTDT_',
						name: 'STARTDT',
						size: 'medium',
						label: computed(() => this.Resources.START00919),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						format: 'dateTime',
						controlLimits: [
						],
					}, this),
					VENDA___PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'VENDA___PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						label: computed(() => this.Resources.PROSPECTION06755),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['VENDA___SALE_IDENTIFI', 'VENDA___SALE_POTCOMPR', 'VENDA___SALE_PROSPECC'],
						controlLimits: [
						],
					}, this),
					VENDA___SALE_IDENTIFI: new fieldControlClass.StringControl({
						modelField: 'ValIdentifi',
						valueChangeEvent: 'fieldChange:sale.identifi',
						id: 'VENDA___SALE_IDENTIFI',
						name: 'IDENTIFI',
						size: 'xxlarge',
						label: computed(() => this.Resources.IDENTIFICATION_OF_BU58085),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'VENDA___PSEUDNOVOGR01',
						maxLength: 85,
						labelId: 'label_VENDA___SALE_IDENTIFI',
						controlLimits: [
						],
					}, this),
					VENDA___SALE_POTCOMPR: new fieldControlClass.StringControl({
						modelField: 'ValPotcompr',
						valueChangeEvent: 'fieldChange:sale.potcompr',
						id: 'VENDA___SALE_POTCOMPR',
						name: 'POTCOMPR',
						size: 'xlarge',
						label: computed(() => this.Resources.POTENTIAL_BUYERS56564),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'VENDA___PSEUDNOVOGR01',
						maxLength: 50,
						labelId: 'label_VENDA___SALE_POTCOMPR',
						controlLimits: [
						],
					}, this),
					VENDA___SALE_PROSPECC: new fieldControlClass.BooleanControl({
						modelField: 'ValProspecc',
						valueChangeEvent: 'fieldChange:sale.prospecc',
						id: 'VENDA___SALE_PROSPECC',
						name: 'PROSPECC',
						size: 'medium',
						label: computed(() => this.Resources.PROSPECTION_CARRIED_20791),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'VENDA___PSEUDNOVOGR01',
						controlLimits: [
						],
					}, this),
					VENDA___PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'VENDA___PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'block',
						label: computed(() => this.Resources.QUALIFICATION64257),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['VENDA___SALE_INTERESS', 'VENDA___SALE_SEMRFINA', 'VENDA___SALE_SEMCAPAC', 'VENDA___SALE_DTQUALIF', 'VENDA___SALE_QUALIFIC'],
						controlLimits: [
						],
					}, this),
					VENDA___SALE_INTERESS: new fieldControlClass.BooleanControl({
						modelField: 'ValInteress',
						valueChangeEvent: 'fieldChange:sale.interess',
						id: 'VENDA___SALE_INTERESS',
						name: 'INTERESS',
						size: 'small',
						label: computed(() => this.Resources.INTERESTED34576),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'VENDA___PSEUDNOVOGR02',
						controlLimits: [
						],
					}, this),
					VENDA___SALE_SEMRFINA: new fieldControlClass.BooleanControl({
						modelField: 'ValSemrfina',
						valueChangeEvent: 'fieldChange:sale.semrfina',
						id: 'VENDA___SALE_SEMRFINA',
						name: 'SEMRFINA',
						size: 'medium',
						label: computed(() => this.Resources.WITHOUT_FINANCIAL_RE10399),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'VENDA___PSEUDNOVOGR02',
						controlLimits: [
						],
					}, this),
					VENDA___SALE_SEMCAPAC: new fieldControlClass.BooleanControl({
						modelField: 'ValSemcapac',
						valueChangeEvent: 'fieldChange:sale.semcapac',
						id: 'VENDA___SALE_SEMCAPAC',
						name: 'SEMCAPAC',
						size: 'large',
						label: computed(() => this.Resources.NO_DECISION_MAKING_P36615),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'VENDA___PSEUDNOVOGR02',
						controlLimits: [
						],
					}, this),
					VENDA___SALE_DTQUALIF: new fieldControlClass.DateControl({
						modelField: 'ValDtqualif',
						valueChangeEvent: 'fieldChange:sale.dtqualif',
						id: 'VENDA___SALE_DTQUALIF',
						name: 'DTQUALIF',
						size: 'medium',
						label: computed(() => this.Resources.QUALIFICATION64257),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'VENDA___PSEUDNOVOGR02',
						format: 'dateTime',
						controlLimits: [
						],
					}, this),
					VENDA___SALE_QUALIFIC: new fieldControlClass.BooleanControl({
						modelField: 'ValQualific',
						valueChangeEvent: 'fieldChange:sale.qualific',
						id: 'VENDA___SALE_QUALIFIC',
						name: 'QUALIFIC',
						size: 'medium',
						label: computed(() => this.Resources.QUALIFICATION_CARRIE05255),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'VENDA___PSEUDNOVOGR02',
						controlLimits: [
						],
					}, this),
					VENDA___PSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'VENDA___PSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'block',
						label: computed(() => this.Resources.PRE_APPROACH58979),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['VENDA___SALE_PREABORD', 'VENDA___SALE_HOMEWORK'],
						controlLimits: [
						],
					}, this),
					VENDA___SALE_PREABORD: new fieldControlClass.DateControl({
						modelField: 'ValPreabord',
						valueChangeEvent: 'fieldChange:sale.preabord',
						id: 'VENDA___SALE_PREABORD',
						name: 'PREABORD',
						size: 'medium',
						label: computed(() => this.Resources.PRE_APPROACH58979),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'VENDA___PSEUDNOVOGR03',
						format: 'dateTime',
						controlLimits: [
						],
					}, this),
					VENDA___SALE_HOMEWORK: new fieldControlClass.BooleanControl({
						modelField: 'ValHomework',
						valueChangeEvent: 'fieldChange:sale.homework',
						id: 'VENDA___SALE_HOMEWORK',
						name: 'HOMEWORK',
						size: 'large',
						label: computed(() => this.Resources.HOMEWORK_DONE45166),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'VENDA___PSEUDNOVOGR03',
						controlLimits: [
						],
					}, this),
					VENDA___PSEUDNOVOGR04: new fieldControlClass.GroupControl({
						id: 'VENDA___PSEUDNOVOGR04',
						name: 'NOVOGR04',
						size: 'block',
						label: computed(() => this.Resources.APPROACH06577),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['VENDA___SALE_DTABORDA', 'VENDA___SALE_APPROACH'],
						controlLimits: [
						],
					}, this),
					VENDA___SALE_DTABORDA: new fieldControlClass.DateControl({
						modelField: 'ValDtaborda',
						valueChangeEvent: 'fieldChange:sale.dtaborda',
						id: 'VENDA___SALE_DTABORDA',
						name: 'DTABORDA',
						size: 'medium',
						label: computed(() => this.Resources.APPROACH06577),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'VENDA___PSEUDNOVOGR04',
						format: 'dateTime',
						controlLimits: [
						],
					}, this),
					VENDA___SALE_APPROACH: new fieldControlClass.BooleanControl({
						modelField: 'ValApproach',
						valueChangeEvent: 'fieldChange:sale.approach',
						id: 'VENDA___SALE_APPROACH',
						name: 'APPROACH',
						size: 'medium',
						label: computed(() => this.Resources.APPROACH_MADE54225),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'VENDA___PSEUDNOVOGR04',
						controlLimits: [
						],
					}, this),
					VENDA___PSEUDNOVOGR05: new fieldControlClass.GroupControl({
						id: 'VENDA___PSEUDNOVOGR05',
						name: 'NOVOGR05',
						size: 'block',
						label: computed(() => this.Resources.PRESENTATION64246),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['VENDA___SALE_DTAPRESE', 'VENDA___SALE_APRESENT'],
						controlLimits: [
						],
					}, this),
					VENDA___SALE_DTAPRESE: new fieldControlClass.DateControl({
						modelField: 'ValDtaprese',
						valueChangeEvent: 'fieldChange:sale.dtaprese',
						id: 'VENDA___SALE_DTAPRESE',
						name: 'DTAPRESE',
						size: 'medium',
						label: computed(() => this.Resources.PRESENTATION_MADE15117),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'VENDA___PSEUDNOVOGR05',
						format: 'dateTime',
						controlLimits: [
						],
					}, this),
					VENDA___SALE_APRESENT: new fieldControlClass.BooleanControl({
						modelField: 'ValApresent',
						valueChangeEvent: 'fieldChange:sale.apresent',
						id: 'VENDA___SALE_APRESENT',
						name: 'APRESENT',
						size: 'medium',
						label: computed(() => this.Resources.PRESENTATION64246),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.right),
						container: 'VENDA___PSEUDNOVOGR05',
						controlLimits: [
						],
					}, this),
					VENDA___PSEUDNOVOGR06: new fieldControlClass.GroupControl({
						id: 'VENDA___PSEUDNOVOGR06',
						name: 'NOVOGR06',
						size: 'block',
						label: computed(() => this.Resources.OVERCOMING_OBJECTION04521),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['VENDA___SALE_DTSUPERA'],
						controlLimits: [
						],
					}, this),
					VENDA___SALE_DTSUPERA: new fieldControlClass.DateControl({
						modelField: 'ValDtsupera',
						valueChangeEvent: 'fieldChange:sale.dtsupera',
						id: 'VENDA___SALE_DTSUPERA',
						name: 'DTSUPERA',
						size: 'medium',
						label: computed(() => this.Resources.OVERCOMING_OBJECTION04521),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'VENDA___PSEUDNOVOGR06',
						format: 'dateTime',
						controlLimits: [
						],
					}, this),
					VENDA___PSEUDNOVOGR07: new fieldControlClass.GroupControl({
						id: 'VENDA___PSEUDNOVOGR07',
						name: 'NOVOGR07',
						size: 'block',
						label: computed(() => this.Resources.CLOSING_OF_THE_SALE05493),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['VENDA___SALE_TENTFECH', 'VENDA___SALE_DTVENDA_'],
						controlLimits: [
						],
					}, this),
					VENDA___SALE_TENTFECH: new fieldControlClass.DateControl({
						modelField: 'ValTentfech',
						valueChangeEvent: 'fieldChange:sale.tentfech',
						id: 'VENDA___SALE_TENTFECH',
						name: 'TENTFECH',
						size: 'medium',
						label: computed(() => this.Resources.CLOSING_ATTEMPTS65102),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'VENDA___PSEUDNOVOGR07',
						format: 'dateTime',
						controlLimits: [
						],
					}, this),
					VENDA___SALE_DTVENDA_: new fieldControlClass.DateControl({
						modelField: 'ValDtvenda',
						valueChangeEvent: 'fieldChange:sale.dtvenda',
						id: 'VENDA___SALE_DTVENDA_',
						name: 'DTVENDA',
						size: 'medium',
						label: computed(() => this.Resources.CLOSING_OF_THE_SALE05493),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'VENDA___PSEUDNOVOGR07',
						format: 'dateTime',
						controlLimits: [
						],
					}, this),
					VENDA___PSEUDNOVOGR08: new fieldControlClass.GroupControl({
						id: 'VENDA___PSEUDNOVOGR08',
						name: 'NOVOGR08',
						size: 'block',
						label: computed(() => this.Resources.FOLLOW_UP22119),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['VENDA___SALE_DTACOMPA'],
						controlLimits: [
						],
					}, this),
					VENDA___SALE_DTACOMPA: new fieldControlClass.DateControl({
						modelField: 'ValDtacompa',
						valueChangeEvent: 'fieldChange:sale.dtacompa',
						id: 'VENDA___SALE_DTACOMPA',
						name: 'DTACOMPA',
						size: 'medium',
						label: computed(() => this.Resources.FOLLOW_UP22119),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'VENDA___PSEUDNOVOGR08',
						format: 'dateTime',
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
					'VENDA___PSEUDNOVOGR01',
					'VENDA___PSEUDNOVOGR02',
					'VENDA___PSEUDNOVOGR03',
					'VENDA___PSEUDNOVOGR04',
					'VENDA___PSEUDNOVOGR05',
					'VENDA___PSEUDNOVOGR06',
					'VENDA___PSEUDNOVOGR07',
					'VENDA___PSEUDNOVOGR08',
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Organ: {
						get ValOrganiza() { return vm.model.TableOrganOrganiza.value },
						set ValOrganiza(value) { vm.model.TableOrganOrganiza.updateValue(value) },
					},
					Sale: {
						get ValApproach() { return vm.model.ValApproach.value },
						set ValApproach(value) { vm.model.ValApproach.updateValue(value) },
						get ValApresent() { return vm.model.ValApresent.value },
						set ValApresent(value) { vm.model.ValApresent.updateValue(value) },
						get ValCodorgan() { return vm.model.ValCodorgan.value },
						set ValCodorgan(value) { vm.model.ValCodorgan.updateValue(value) },
						get ValDtaborda() { return vm.model.ValDtaborda.value },
						set ValDtaborda(value) { vm.model.ValDtaborda.updateValue(value) },
						get ValDtacompa() { return vm.model.ValDtacompa.value },
						set ValDtacompa(value) { vm.model.ValDtacompa.updateValue(value) },
						get ValDtaprese() { return vm.model.ValDtaprese.value },
						set ValDtaprese(value) { vm.model.ValDtaprese.updateValue(value) },
						get ValDtqualif() { return vm.model.ValDtqualif.value },
						set ValDtqualif(value) { vm.model.ValDtqualif.updateValue(value) },
						get ValDtsupera() { return vm.model.ValDtsupera.value },
						set ValDtsupera(value) { vm.model.ValDtsupera.updateValue(value) },
						get ValDtvenda() { return vm.model.ValDtvenda.value },
						set ValDtvenda(value) { vm.model.ValDtvenda.updateValue(value) },
						get ValHomework() { return vm.model.ValHomework.value },
						set ValHomework(value) { vm.model.ValHomework.updateValue(value) },
						get ValIdentifi() { return vm.model.ValIdentifi.value },
						set ValIdentifi(value) { vm.model.ValIdentifi.updateValue(value) },
						get ValInteress() { return vm.model.ValInteress.value },
						set ValInteress(value) { vm.model.ValInteress.updateValue(value) },
						get ValNrlide() { return vm.model.ValNrlide.value },
						set ValNrlide(value) { vm.model.ValNrlide.updateValue(value) },
						get ValPotcompr() { return vm.model.ValPotcompr.value },
						set ValPotcompr(value) { vm.model.ValPotcompr.updateValue(value) },
						get ValPreabord() { return vm.model.ValPreabord.value },
						set ValPreabord(value) { vm.model.ValPreabord.updateValue(value) },
						get ValProspecc() { return vm.model.ValProspecc.value },
						set ValProspecc(value) { vm.model.ValProspecc.updateValue(value) },
						get ValQualific() { return vm.model.ValQualific.value },
						set ValQualific(value) { vm.model.ValQualific.updateValue(value) },
						get ValSemcapac() { return vm.model.ValSemcapac.value },
						set ValSemcapac(value) { vm.model.ValSemcapac.updateValue(value) },
						get ValSemrfina() { return vm.model.ValSemrfina.value },
						set ValSemrfina(value) { vm.model.ValSemrfina.updateValue(value) },
						get ValStartdt() { return vm.model.ValStartdt.value },
						set ValStartdt(value) { vm.model.ValStartdt.updateValue(value) },
						get ValTentfech() { return vm.model.ValTentfech.value },
						set ValTentfech(value) { vm.model.ValTentfech.updateValue(value) },
					},
					keys: {
						/** The primary key of the SALE table */
						get sale() { return vm.model.ValCodvenda },
						/** The foreign key to the ORGAN table */
						get organ() { return vm.model.ValCodorgan },
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
// USE /[MANUAL GQT FORM_CODEJS VENDA]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS VENDA]/
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
// USE /[MANUAL GQT FORM_LOADED_JS VENDA]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS VENDA]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS VENDA]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS VENDA]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS VENDA]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS VENDA]/
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
// USE /[MANUAL GQT AFTER_DEL_JS VENDA]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS VENDA]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS VENDA]/
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
// USE /[MANUAL GQT DLGUPDT VENDA]/
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
// USE /[MANUAL GQT CTRLBLR VENDA]/
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
// USE /[MANUAL GQT CTRLUPD VENDA]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FUNCTIONS_JS VENDA]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
