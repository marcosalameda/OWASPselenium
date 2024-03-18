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
			data-key="ARTIG"
			:data-loading="!formInitialDataLoaded"
			:key="domVersionKey">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.ARTIG___PSEUDNOVOGR02.isVisible">
					<q-control-wrapper
						v-show="controls.ARTIG___PSEUDNOVOGR02.isVisible"
						class="control-join-group">
						<q-group-box-container
							id="ARTIG___PSEUDNOVOGR02"
							v-bind="controls.ARTIG___PSEUDNOVOGR02"
							:is-visible="controls.ARTIG___PSEUDNOVOGR02.isVisible">
							<!-- Start ARTIG___PSEUDNOVOGR02 -->
							<q-row-container v-show="controls.ARTIG___WAREHWAREHDES.isVisible">
								<q-control-wrapper
									v-show="controls.ARTIG___WAREHWAREHDES.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.ARTIG___WAREHWAREHDES"
										v-on="controls.ARTIG___WAREHWAREHDES.handlers"
										:loading="controls.ARTIG___WAREHWAREHDES.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-lookup
											v-if="controls.ARTIG___WAREHWAREHDES.isVisible"
											v-bind="controls.ARTIG___WAREHWAREHDES.props"
											:model-value="model.ValCodwareh.value"
											v-on="controls.ARTIG___WAREHWAREHDES.handlers"
											@update:model-value="model.ValCodwareh.fnUpdateValue" />
										<q-see-more-artig-warehwarehdes
											v-if="controls.ARTIG___WAREHWAREHDES.seeMoreIsVisible"
											v-bind="controls.ARTIG___WAREHWAREHDES.seeMoreParams"
											v-on="controls.ARTIG___WAREHWAREHDES.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End ARTIG___PSEUDNOVOGR02 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.ARTIG___PSEUDNOVOGR01.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.ARTIG___PSEUDNOVOGR01.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="ARTIG___PSEUDNOVOGR01"
							v-bind="controls.ARTIG___PSEUDNOVOGR01"
							:is-visible="controls.ARTIG___PSEUDNOVOGR01.isVisible">
							<!-- Start ARTIG___PSEUDNOVOGR01 -->
							<q-row-container v-show="controls.ARTIG___GITEMITEMGCOD.isVisible || controls.ARTIG___GITEMITEMDES_.isVisible">
								<q-control-wrapper
									v-show="controls.ARTIG___GITEMITEMGCOD.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.ARTIG___GITEMITEMGCOD"
										v-on="controls.ARTIG___GITEMITEMGCOD.handlers"
										:loading="controls.ARTIG___GITEMITEMGCOD.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-text-field
											v-bind="controls.ARTIG___GITEMITEMGCOD.props"
											:model-value="model.GitemValItemgcod.value" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.ARTIG___GITEMITEMDES_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.ARTIG___GITEMITEMDES_"
										v-on="controls.ARTIG___GITEMITEMDES_.handlers"
										:loading="controls.ARTIG___GITEMITEMDES_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-lookup
											v-if="controls.ARTIG___GITEMITEMDES_.isVisible"
											v-bind="controls.ARTIG___GITEMITEMDES_.props"
											:model-value="model.ValCodgitem.value"
											v-on="controls.ARTIG___GITEMITEMDES_.handlers"
											@update:model-value="model.ValCodgitem.fnUpdateValue" />
										<q-see-more-artig-gitemitemdes
											v-if="controls.ARTIG___GITEMITEMDES_.seeMoreIsVisible"
											v-bind="controls.ARTIG___GITEMITEMDES_.seeMoreParams"
											v-on="controls.ARTIG___GITEMITEMDES_.handlers" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End ARTIG___PSEUDNOVOGR01 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.ARTIG___PSEUDNOVOGR07.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.ARTIG___PSEUDNOVOGR07.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="ARTIG___PSEUDNOVOGR07"
							v-bind="controls.ARTIG___PSEUDNOVOGR07"
							:is-visible="controls.ARTIG___PSEUDNOVOGR07.isVisible">
							<!-- Start ARTIG___PSEUDNOVOGR07 -->
							<q-row-container v-show="controls.ARTIG___ITEM_ITEMCOD_.isVisible || controls.ARTIG___ITEM_ITEMDES_.isVisible || controls.ARTIG___ITEM_VALID___.isVisible">
								<q-control-wrapper
									v-show="controls.ARTIG___ITEM_ITEMCOD_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.ARTIG___ITEM_ITEMCOD_"
										v-on="controls.ARTIG___ITEM_ITEMCOD_.handlers"
										:loading="controls.ARTIG___ITEM_ITEMCOD_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-text-field
											v-bind="controls.ARTIG___ITEM_ITEMCOD_.props"
											:model-value="model.ValItemcod.value"
											@update:model-value="model.ValItemcod.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.ARTIG___ITEM_ITEMDES_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.ARTIG___ITEM_ITEMDES_"
										v-on="controls.ARTIG___ITEM_ITEMDES_.handlers"
										:loading="controls.ARTIG___ITEM_ITEMDES_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-text-field
											v-bind="controls.ARTIG___ITEM_ITEMDES_.props"
											:model-value="model.ValItemdes.value"
											@update:model-value="model.ValItemdes.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.ARTIG___ITEM_VALID___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-checkbox"
										v-bind="controls.ARTIG___ITEM_VALID___"
										v-on="controls.ARTIG___ITEM_VALID___.handlers"
										:loading="controls.ARTIG___ITEM_VALID___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<template #label>
											<q-checkbox-input
												v-if="controls.ARTIG___ITEM_VALID___.isVisible"
												id="ARTIG___ITEM_VALID___"
												size="mini"
												:model-value="model.ValValid.value"
												:readonly="controls.ARTIG___ITEM_VALID___.readonly"
												@update:model-value="model.ValValid.fnUpdateValue" />
										</template>
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.ARTIG___ITEM_ITEMTYPE.isVisible">
								<q-control-wrapper
									v-show="controls.ARTIG___ITEM_ITEMTYPE.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.ARTIG___ITEM_ITEMTYPE"
										v-on="controls.ARTIG___ITEM_ITEMTYPE.handlers"
										:loading="controls.ARTIG___ITEM_ITEMTYPE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-select
											v-if="controls.ARTIG___ITEM_ITEMTYPE.isVisible"
											v-bind="controls.ARTIG___ITEM_ITEMTYPE.props"
											:model-value="model.ValItemtype.value"
											@update:model-value="model.ValItemtype.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.ARTIG___ITEM_ENTRIES_.isVisible || controls.ARTIG___ITEM_EXITS___.isVisible || controls.ARTIG___ITEM_EXISTENC.isVisible || controls.ARTIG___ITEM_DISPONIB.isVisible">
								<q-control-wrapper
									v-show="controls.ARTIG___ITEM_ENTRIES_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.ARTIG___ITEM_ENTRIES_"
										v-on="controls.ARTIG___ITEM_ENTRIES_.handlers"
										:loading="controls.ARTIG___ITEM_ENTRIES_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-numeric-input
											v-if="controls.ARTIG___ITEM_ENTRIES_.isVisible"
											v-bind="controls.ARTIG___ITEM_ENTRIES_"
											:model-value="model.ValEntries.value"
											@update:model-value="model.ValEntries.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.ARTIG___ITEM_EXITS___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.ARTIG___ITEM_EXITS___"
										v-on="controls.ARTIG___ITEM_EXITS___.handlers"
										:loading="controls.ARTIG___ITEM_EXITS___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-numeric-input
											v-if="controls.ARTIG___ITEM_EXITS___.isVisible"
											v-bind="controls.ARTIG___ITEM_EXITS___"
											:model-value="model.ValExits.value"
											@update:model-value="model.ValExits.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.ARTIG___ITEM_EXISTENC.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.ARTIG___ITEM_EXISTENC"
										v-on="controls.ARTIG___ITEM_EXISTENC.handlers"
										:loading="controls.ARTIG___ITEM_EXISTENC.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-numeric-input
											v-if="controls.ARTIG___ITEM_EXISTENC.isVisible"
											v-bind="controls.ARTIG___ITEM_EXISTENC"
											:model-value="model.ValExistenc.value"
											@update:model-value="model.ValExistenc.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.ARTIG___ITEM_DISPONIB.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.ARTIG___ITEM_DISPONIB"
										v-on="controls.ARTIG___ITEM_DISPONIB.handlers"
										:loading="controls.ARTIG___ITEM_DISPONIB.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-select
											v-if="controls.ARTIG___ITEM_DISPONIB.isVisible"
											v-bind="controls.ARTIG___ITEM_DISPONIB.props"
											:model-value="model.ValDisponib.value" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container
								v-show="controls.ARTIG___PSEUDNOVOGR08.isVisible"
								is-large>
								<q-control-wrapper
									v-show="controls.ARTIG___PSEUDNOVOGR08.isVisible"
									class="row-line-group">
									<q-group-collapsible
										v-bind="controls.ARTIG___PSEUDNOVOGR08"
										v-on="controls.ARTIG___PSEUDNOVOGR08.handlers">
										<!-- Start ARTIG___PSEUDNOVOGR08 -->
										<q-row-container v-show="controls.ARTIG___ITEM_IMAGE___.isVisible">
											<q-control-wrapper
												v-show="controls.ARTIG___ITEM_IMAGE___.isVisible"
												class="control-join-group">
												<base-input-structure
													class="q-image"
													v-bind="controls.ARTIG___ITEM_IMAGE___"
													v-on="controls.ARTIG___ITEM_IMAGE___.handlers"
													:loading="controls.ARTIG___ITEM_IMAGE___.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn"
													:help-style="layoutConfig.HelpStyle">
													<q-image
														v-if="controls.ARTIG___ITEM_IMAGE___.isVisible"
														v-bind="controls.ARTIG___ITEM_IMAGE___.props"
														v-on="controls.ARTIG___ITEM_IMAGE___.handlers" />
												</base-input-structure>
											</q-control-wrapper>
										</q-row-container>
										<!-- End ARTIG___PSEUDNOVOGR08 -->
									</q-group-collapsible>
								</q-control-wrapper>
							</q-row-container>
							<!-- End ARTIG___PSEUDNOVOGR07 -->
						</q-group-box-container>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.ARTIG___PSEUDNOVOGR05.isVisible || controls.ARTIG___PSEUDNOVOGR06.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.ARTIG___PSEUDNOVOGR05.isVisible"
						class="row-line-group">
						<q-accordion-container
							id="ARTIG___PSEUDNOVOGR05"
							v-bind="controls.ARTIG___PSEUDNOVOGR05"
							v-on="controls.ARTIG___PSEUDNOVOGR05.handlers"
							v-slot="{ onStateChanged }">
							<!-- Start ARTIG___PSEUDNOVOGR05 -->
							<q-group-collapsible
								v-bind="controls.ARTIG___PSEUDNOVOGR03"
								v-on="controls.ARTIG___PSEUDNOVOGR03.handlers"
								@state-changed="(state, groupId) => onStateChanged(state, groupId)">
								<!-- Start ARTIG___PSEUDNOVOGR03 -->
								<q-row-container v-show="controls.ARTIG___PSEUDCONTACOR.isVisible">
									<q-control-wrapper
										v-show="controls.ARTIG___PSEUDCONTACOR.isVisible"
										class="control-join-group">
										<q-table
											v-show="controls.ARTIG___PSEUDCONTACOR.isVisible"
											v-bind="controls.ARTIG___PSEUDCONTACOR"
											v-on="controls.ARTIG___PSEUDCONTACOR.handlers">
										</q-table>
										<q-table-extra-extension
											:list-ctrl="controls.ARTIG___PSEUDCONTACOR"
											v-on="controls.ARTIG___PSEUDCONTACOR.handlers" />
									</q-control-wrapper>
								</q-row-container>
								<!-- End ARTIG___PSEUDNOVOGR03 -->
							</q-group-collapsible>
							<q-group-collapsible
								v-bind="controls.ARTIG___PSEUDNOVOGR04"
								v-on="controls.ARTIG___PSEUDNOVOGR04.handlers"
								@state-changed="(state, groupId) => onStateChanged(state, groupId)">
								<!-- Start ARTIG___PSEUDNOVOGR04 -->
								<q-row-container v-show="controls.ARTIG___PSEUDLENTRADA.isVisible">
									<q-control-wrapper
										v-show="controls.ARTIG___PSEUDLENTRADA.isVisible"
										class="control-join-group">
										<q-table
											v-show="controls.ARTIG___PSEUDLENTRADA.isVisible"
											v-bind="controls.ARTIG___PSEUDLENTRADA"
											v-on="controls.ARTIG___PSEUDLENTRADA.handlers">
										</q-table>
										<q-table-extra-extension
											:list-ctrl="controls.ARTIG___PSEUDLENTRADA"
											v-on="controls.ARTIG___PSEUDLENTRADA.handlers" />
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.ARTIG___PSEUDLSAIDAS_.isVisible">
									<q-control-wrapper
										v-show="controls.ARTIG___PSEUDLSAIDAS_.isVisible"
										class="control-join-group">
										<q-table
											v-show="controls.ARTIG___PSEUDLSAIDAS_.isVisible"
											v-bind="controls.ARTIG___PSEUDLSAIDAS_"
											v-on="controls.ARTIG___PSEUDLSAIDAS_.handlers">
										</q-table>
										<q-table-extra-extension
											:list-ctrl="controls.ARTIG___PSEUDLSAIDAS_"
											v-on="controls.ARTIG___PSEUDLSAIDAS_.handlers" />
									</q-control-wrapper>
								</q-row-container>
								<!-- End ARTIG___PSEUDNOVOGR04 -->
							</q-group-collapsible>
							<!-- End ARTIG___PSEUDNOVOGR05 -->
						</q-accordion-container>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.ARTIG___PSEUDNOVOGR06.isVisible"
						class="control-join-group">
						<q-group-collapsible
							v-bind="controls.ARTIG___PSEUDNOVOGR06"
							v-on="controls.ARTIG___PSEUDNOVOGR06.handlers">
							<!-- Start ARTIG___PSEUDNOVOGR06 -->
							<q-row-container v-show="controls.ARTIG___PSEUDCATEGORI.isVisible || controls.ARTIG___PSEUDESCCATEG.isVisible">
								<q-control-wrapper
									v-show="controls.ARTIG___PSEUDCATEGORI.isVisible || controls.ARTIG___PSEUDESCCATEG.isVisible"
									class="control-join-group">
									<q-table
										v-show="controls.ARTIG___PSEUDCATEGORI.isVisible"
										v-bind="controls.ARTIG___PSEUDCATEGORI"
										v-on="controls.ARTIG___PSEUDCATEGORI.handlers">
									</q-table>
									<q-table-extra-extension
										:list-ctrl="controls.ARTIG___PSEUDCATEGORI"
										v-on="controls.ARTIG___PSEUDCATEGORI.handlers" />
									<base-input-structure
										class="i-text"
										v-bind="controls.ARTIG___PSEUDESCCATEG"
										v-on="controls.ARTIG___PSEUDESCCATEG.handlers"
										:loading="controls.ARTIG___PSEUDESCCATEG.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-check-list-extension
											v-if="controls.ARTIG___PSEUDESCCATEG.isVisible"
											id="ARTIG___PSEUDESCCATEG"
											:options="controls.ARTIG___PSEUDCATEGORI.rows"
											:search-column-name="controls.ARTIG___PSEUDCATEGORI.columnsOriginal[0].name"
											:search-column-label="controls.ARTIG___PSEUDCATEGORI.columnsOriginal[0].label"
											:primary-key-column-name="controls.ARTIG___PSEUDCATEGORI.config.pkColumn"
											:texts="controls.ARTIG___PSEUDESCCATEG.texts"
											:rows-selected="controls.ARTIG___PSEUDCATEGORI.rowsSelected"
											:disabled="controls.ARTIG___PSEUDESCCATEG.readonly"
											@remove-label="onUnselectRow(controls.ARTIG___PSEUDCATEGORI, $event); model.List_Categori_SelectedIds.updateValue(rowKeyHashTableToArray(controls.ARTIG___PSEUDCATEGORI.rowsSelected))"
											@on-enter="onSelectRow(controls.ARTIG___PSEUDCATEGORI, $event); model.List_Categori_SelectedIds.updateValue(rowKeyHashTableToArray(controls.ARTIG___PSEUDCATEGORI.rowsSelected))" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.ARTIG___PSEUDCATEGOR_.isVisible">
								<q-control-wrapper
									v-show="controls.ARTIG___PSEUDCATEGOR_.isVisible"
									class="control-join-group">
									<q-table
										v-show="controls.ARTIG___PSEUDCATEGOR_.isVisible"
										v-bind="controls.ARTIG___PSEUDCATEGOR_"
										v-on="controls.ARTIG___PSEUDCATEGOR_.handlers">
									</q-table>
									<q-table-extra-extension
										:list-ctrl="controls.ARTIG___PSEUDCATEGOR_"
										v-on="controls.ARTIG___PSEUDCATEGOR_.handlers" />
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.ARTIG___ITEM_CATEGORY.isVisible">
								<q-control-wrapper
									v-show="controls.ARTIG___ITEM_CATEGORY.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-textarea"
										v-bind="controls.ARTIG___ITEM_CATEGORY"
										v-on="controls.ARTIG___ITEM_CATEGORY.handlers"
										:loading="controls.ARTIG___ITEM_CATEGORY.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn"
										:help-style="layoutConfig.HelpStyle">
										<q-textarea-input
											v-if="controls.ARTIG___ITEM_CATEGORY.isVisible"
											id="ARTIG___ITEM_CATEGORY"
											size="xlarge"
											:model-value="model.ValCategory.value"
											:rows="2"
											:cols="50"
											:is-required="controls.ARTIG___ITEM_CATEGORY.isRequired"
											:readonly="controls.ARTIG___ITEM_CATEGORY.readonly"
											:placeholder="controls.ARTIG___ITEM_CATEGORY.placeholder"
											@update:model-value="model.ValCategory.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End ARTIG___PSEUDNOVOGR06 -->
						</q-group-collapsible>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container v-show="controls.ARTIG___ITEM_DATE____.isVisible">
					<q-control-wrapper
						v-show="controls.ARTIG___ITEM_DATE____.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.ARTIG___ITEM_DATE____"
							v-on="controls.ARTIG___ITEM_DATE____.handlers"
							:loading="controls.ARTIG___ITEM_DATE____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn"
							:help-style="layoutConfig.HelpStyle">
							<q-datetime-input
								v-if="controls.ARTIG___ITEM_DATE____.isVisible"
								v-bind="controls.ARTIG___ITEM_DATE____"
								format="Date"
								:model-value="model.ValDate.value"
								@update:model-value="model.ValDate.fnUpdateValue" />
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

	import FormViewModel from './QFormArtigViewModel.js'

	const requiredTextResources = ['QFormArtig', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS ARTIG]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormArtig',

		components: {
			QSeeMoreArtigWarehwarehdes: defineAsyncComponent(() => import('@/views/forms/FormArtig/dbedits/ArtigWarehwarehdesSeeMore.vue')),
			QSeeMoreArtigGitemitemdes: defineAsyncComponent(() => import('@/views/forms/FormArtig/dbedits/ArtigGitemitemdesSeeMore.vue')),
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
						name: 'ARTIG',
						location: 'form-ARTIG',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormArtig', false),

				interfaceMetadata: {
					id: 'QFormArtig', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'ARTIG',
					route: 'form-ARTIG',
					area: 'ITEM',
					primaryKey: 'ValCoditem',
					designation: computed(() => this.Resources.ITEM40802),
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
					ARTIG___ITEM_ITEMCOD_: new fieldControlClass.StringControl({
						modelField: 'ValItemcod',
						valueChangeEvent: 'fieldChange:item.itemcod',
						id: 'ARTIG___ITEM_ITEMCOD_',
						name: 'ITEMCOD',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.CODE49225),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ARTIG___PSEUDNOVOGR07',
						maxLength: 15,
						labelId: 'label_ARTIG___ITEM_ITEMCOD_',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ARTIG___WAREHWAREHDES: new fieldControlClass.LookupControl({
						modelField: 'TableWarehWarehdes',
						valueChangeEvent: 'fieldChange:wareh.warehdes',
						id: 'ARTIG___WAREHWAREHDES',
						name: 'WAREHDES',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.WAREHOUSE51864),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ARTIG___PSEUDNOVOGR02',
						mustBeFilled: true,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodwareh',
							dependencyEvent: 'fieldChange:item.codwareh'
						},
						dependentFields: () => {
							return {
								set 'wareh.codwareh'(value) { vm.model.ValCodwareh.updateValue(value) },
								set 'wareh.warehdes'(value) { vm.model.TableWarehWarehdes.updateValue(value) },
							}
						},
						insertEnabled: true,
						supportForm: 'ARMAZ',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
					}, this),
					ARTIG___GITEMITEMGCOD: new fieldControlClass.StringControl({
						modelField: 'GitemValItemgcod',
						valueChangeEvent: 'fieldChange:gitem.itemgcod',
						dependentModelField: 'ValCodgitem',
						dependentChangeEvent: 'fieldChange:item.codgitem',
						id: 'ARTIG___GITEMITEMGCOD',
						name: 'ITEMGCOD',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.CODE49225),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ARTIG___PSEUDNOVOGR01',
						maxLength: 15,
						labelId: 'label_ARTIG___GITEMITEMGCOD',
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					ARTIG___GITEMITEMDES_: new fieldControlClass.LookupControl({
						modelField: 'TableGitemItemdes',
						valueChangeEvent: 'fieldChange:gitem.itemdes',
						id: 'ARTIG___GITEMITEMDES_',
						name: 'ITEMDES',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.DESIGNATION_35800),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ARTIG___PSEUDNOVOGR01',
						mustBeFilled: false,
						controlLimits: [
						],
						lookupKeyModelField: {
							name: 'ValCodgitem',
							dependencyEvent: 'fieldChange:item.codgitem'
						},
						dependentFields: () => {
							return {
								set 'gitem.codgitem'(value) { vm.model.ValCodgitem.updateValue(value) },
								set 'gitem.itemdes'(value) { vm.model.TableGitemItemdes.updateValue(value) },
								set 'gitem.itemgcod'(value) { vm.model.GitemValItemgcod.updateValue(value) },
							}
						},
						insertEnabled: true,
						supportForm: 'ARTGL',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
					}, this),
					ARTIG___PSEUDNOVOGR02: new fieldControlClass.GroupControl({
						id: 'ARTIG___PSEUDNOVOGR02',
						name: 'NOVOGR02',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.WAREHOUSE51864),
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
					ARTIG___PSEUDNOVOGR01: new fieldControlClass.GroupControl({
						id: 'ARTIG___PSEUDNOVOGR01',
						name: 'NOVOGR01',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.GLOBAL_ITEM49586),
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
					ARTIG___ITEM_ITEMDES_: new fieldControlClass.StringControl({
						modelField: 'ValItemdes',
						valueChangeEvent: 'fieldChange:item.itemdes',
						id: 'ARTIG___ITEM_ITEMDES_',
						name: 'ITEMDES',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.ITEM40802),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ARTIG___PSEUDNOVOGR07',
						maxLength: 85,
						labelId: 'label_ARTIG___ITEM_ITEMDES_',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					ARTIG___ITEM_VALID___: new fieldControlClass.BooleanControl({
						modelField: 'ValValid',
						valueChangeEvent: 'fieldChange:item.valid',
						id: 'ARTIG___ITEM_VALID___',
						name: 'VALID',
						size: 'mini',
						hasLabel: true,
						label: computed(() => this.Resources.IN_USE42606),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'ARTIG___PSEUDNOVOGR07',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ARTIG___ITEM_ITEMTYPE: new fieldControlClass.ArrayStringControl({
						modelField: 'ValItemtype',
						valueChangeEvent: 'fieldChange:item.itemtype',
						id: 'ARTIG___ITEM_ITEMTYPE',
						name: 'ITEMTYPE',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.TIPO55111),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ARTIG___PSEUDNOVOGR07',
						maxLength: 1,
						labelId: 'label_ARTIG___ITEM_ITEMTYPE',
						arrayName: 'TipoArti',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ARTIG___ITEM_ENTRIES_: new fieldControlClass.NumberControl({
						modelField: 'ValEntries',
						valueChangeEvent: 'fieldChange:item.entries',
						maxIntegers: 10,
						maxDecimals: 0,
						id: 'ARTIG___ITEM_ENTRIES_',
						name: 'ENTRIES',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.ENTRIES_07375),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ARTIG___PSEUDNOVOGR07',
						isFormulaBlocked: true,
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					ARTIG___ITEM_EXITS___: new fieldControlClass.NumberControl({
						modelField: 'ValExits',
						valueChangeEvent: 'fieldChange:item.exits',
						maxIntegers: 10,
						maxDecimals: 0,
						id: 'ARTIG___ITEM_EXITS___',
						name: 'EXITS',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.OUTPUT_10769),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ARTIG___PSEUDNOVOGR07',
						isFormulaBlocked: true,
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					ARTIG___ITEM_IMAGE___: new fieldControlClass.ImageControl({
						modelField: 'ValImage',
						valueChangeEvent: 'fieldChange:item.image',
						id: 'ARTIG___ITEM_IMAGE___',
						name: 'IMAGE',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.IMAGE65174),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-ARTIG___PSEUDNOVOGR08',
						container: 'ARTIG___PSEUDNOVOGR08',
						height: 50,
						width: 100,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ARTIG___PSEUDNOVOGR07: new fieldControlClass.GroupControl({
						id: 'ARTIG___PSEUDNOVOGR07',
						name: 'NOVOGR07',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.ITEM40802),
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
					ARTIG___PSEUDNOVOGR03: new fieldControlClass.GroupControl({
						id: 'ARTIG___PSEUDNOVOGR03',
						name: 'NOVOGR03',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.SEQUENTIAL_MOVEMENTS40923),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'ARTIG___PSEUDNOVOGR05',
						isCollapsible: true,
						anchored: false,
						openingEvent: 'opened-ARTIG___PSEUDNOVOGR03',
						isInAccordion: true,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ARTIG___PSEUDCONTACOR: new fieldControlClass.TableListControl({
						id: 'ARTIG___PSEUDCONTACOR',
						name: 'CONTACOR',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.MOVEMENTS47007),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-ARTIG___PSEUDNOVOGR03',
						container: 'ARTIG___PSEUDNOVOGR03',
						controller: 'ITEM',
						action: 'Artig_ValContacor',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.NumericColumn({
								order: 1,
								name: 'ValNorder',
								area: 'CCORR',
								field: 'NORDER',
								label: computed(() => this.Resources.ORDER39632),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}),
							new listColumnTypes.DateColumn({
								order: 2,
								name: 'ValDate',
								area: 'CCORR',
								field: 'DATE',
								label: computed(() => this.Resources.INSTANT35907),
								scrollData: 16,
								dateTimeType: 'DateTime',
							}),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValType',
								area: 'CCORR',
								field: 'TYPE',
								label: computed(() => this.Resources.TYPE00312),
								dataLength: 8,
								scrollData: 8,
							}),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValReferenc',
								area: 'CCORR',
								field: 'REFERENC',
								label: computed(() => this.Resources.REF_A30225),
								dataLength: 10,
								scrollData: 10,
							}),
							new listColumnTypes.NumericColumn({
								order: 5,
								name: 'ValQnty',
								area: 'CCORR',
								field: 'QNTY',
								label: computed(() => this.Resources.AMOUNT46885),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
							new listColumnTypes.NumericColumn({
								order: 6,
								name: 'ValBalance',
								area: 'CCORR',
								field: 'BALANCE',
								label: computed(() => this.Resources.BALANCE13297),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
						],
						config: {
							name: 'ValContacor',
							serverMode: true,
							pkColumn: 'ValCodccorr',
							tableAlias: 'CCORR',
							tableNamePlural: computed(() => this.Resources.CURRENT_ACCOUNT19471),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.MOVEMENTS47007),
							showAlternatePagination: true,
							permissions: {
							},
							globalSearch: {
								visibility: true,
								searchOnPressEnter: true
							},
							filtersVisible: true,
							allowColumnFilters: true,
							allowColumnSort: true,
							// eslint-disable-next-line no-unused-vars, eqeqeq
							rowBgColor: (row) => qApi.iif(row.Fields.ValType=="Entrada",qApi.RGB(207,255,158),qApi.iif(row.Fields.ValType=="Saída",qApi.RGB(255,190,158),qApi.RGB(255,255,255))),
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
							rowValidation: {
								fnValidate: (row) => row.Fields.ValZzstate === 0,
								message: computed(() => this.Resources.ATENCAO__ESTA_FICHA_24725),
								class: 'c-table__row--pending'
							},
							crudConditions: {
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							initialSortColumnName: '',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-CCORR', 'changed-INDOC', 'changed-ITEM'],
						uuid: 'Artig_ValContacor',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'item'],
								dependencyEvents: ['fieldChange:item.coditem'],
								dependencyField: 'ITEM.CODITEM',
								fnValueSelector: (model) => model.ValCoditem.value
							},
						],
					}, this),
					ARTIG___PSEUDNOVOGR04: new fieldControlClass.GroupControl({
						id: 'ARTIG___PSEUDNOVOGR04',
						name: 'NOVOGR04',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.MOVEMENTS_BY_TYPE14801),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'ARTIG___PSEUDNOVOGR05',
						isCollapsible: true,
						anchored: false,
						openingEvent: 'opened-ARTIG___PSEUDNOVOGR04',
						isInAccordion: true,
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ARTIG___PSEUDLENTRADA: new fieldControlClass.TableListControl({
						id: 'ARTIG___PSEUDLENTRADA',
						name: 'LENTRADA',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.ENTRIES32319),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-ARTIG___PSEUDNOVOGR04',
						container: 'ARTIG___PSEUDNOVOGR04',
						controller: 'ITEM',
						action: 'Artig_ValLentrada',
						hasDependencies: true,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValDhentra',
								area: 'LDENT',
								field: 'DHENTRA',
								label: computed(() => this.Resources.INSTANT_ENTRANCE27379),
								scrollData: 16,
								dateTimeType: 'DateTime',
							}),
							new listColumnTypes.NumericColumn({
								order: 2,
								name: 'Indoc.ValDocumenr',
								area: 'INDOC',
								field: 'DOCUMENR',
								label: computed(() => this.Resources.DOCUMENT_NO_30174),
								scrollData: 10,
								supportForm: 'DENTR',
								supportFormIsPopup: false,
								params: {
									type: 'form',
									formName: 'DENTR',
									mode: 'SHOW'
								},
								cellAction: true,
								maxDigits: 10,
								decimalPlaces: 0,
								pkColumn: 'ValCoddentr',
							}),
							new listColumnTypes.NumericColumn({
								order: 3,
								name: 'ValLine',
								area: 'LDENT',
								field: 'LINE',
								label: computed(() => this.Resources.LINE27983),
								scrollData: 5,
								maxDigits: 3,
								decimalPlaces: 1,
								isOrderingColumn: true,
							}),
							new listColumnTypes.NumericColumn({
								order: 4,
								name: 'ValQtdentra',
								area: 'LDENT',
								field: 'QTDENTRA',
								label: computed(() => this.Resources.QTD_ENTRY35144),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
						],
						config: {
							name: 'ValLentrada',
							serverMode: true,
							pkColumn: 'ValCodldent',
							tableAlias: 'LDENT',
							tableNamePlural: computed(() => this.Resources.ENTRIES32319),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.ENTRIES32319),
							showAlternatePagination: true,
							permissions: {
							},
							globalSearch: {
								visibility: true,
								searchOnPressEnter: true
							},
							filtersVisible: true,
							allowColumnFilters: true,
							allowColumnSort: true,
							// eslint-disable-next-line no-unused-vars, eqeqeq
							rowTextColor: (row) => qApi.RGB(207,255,158),
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
										formName: 'LDENT',
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
										formName: 'LDENT',
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
										formName: 'LDENT',
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
										formName: 'LDENT',
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
										formName: 'LDENT',
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
								id: 'RCA__LDENT',
								name: '_LDENT',
								title: '',
								isInReadOnly: true,
								params: {
									action: vm.openFormAction,
									type: 'form',
									formName: 'LDENT',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'LDENT': {
									fnKeySelector: (row) => row.Fields.ValCodldent,
									isPopup: true
								},
								'DENTR': {
									fnKeySelector: (row) => row.Fields.ValCoddentr,
									isPopup: false
								},
							},
							rowValidation: {
								fnValidate: (row) => row.Fields.ValZzstate === 0,
								message: computed(() => this.Resources.ATENCAO__ESTA_FICHA_24725),
								class: 'c-table__row--pending'
							},
							// The list support form: LDENT
							crudConditions: {
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							initialSortColumnName: 'ValLine',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-WAREH', 'changed-LDENT', 'changed-ITEM', 'changed-INDOC', 'changed-WARE1', 'changed-PESSO', 'changed-CMPNY', 'changed-CNTRY'],
						uuid: 'Artig_ValLentrada',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'item'],
								dependencyEvents: ['fieldChange:item.coditem'],
								dependencyField: 'ITEM.CODITEM',
								fnValueSelector: (model) => model.ValCoditem.value
							},
						],
					}, this),
					ARTIG___PSEUDLSAIDAS_: new fieldControlClass.TableListControl({
						id: 'ARTIG___PSEUDLSAIDAS_',
						name: 'LSAIDAS',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.OUTPUT_10769),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-ARTIG___PSEUDNOVOGR04',
						container: 'ARTIG___PSEUDNOVOGR04',
						controller: 'ITEM',
						action: 'Artig_ValLsaidas',
						hasDependencies: true,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValExitdt',
								area: 'OUTPU',
								field: 'EXITDT',
								label: computed(() => this.Resources.EXIT_INSTANT27038),
								scrollData: 16,
								dateTimeType: 'DateTime',
							}),
							new listColumnTypes.NumericColumn({
								order: 2,
								name: 'Outpt.ValDocumenr',
								area: 'OUTPT',
								field: 'DOCUMENR',
								label: computed(() => this.Resources.DOCUMENT_NO_30174),
								scrollData: 10,
								supportForm: 'DSAID',
								supportFormIsPopup: false,
								params: {
									type: 'form',
									formName: 'DSAID',
									mode: 'SHOW'
								},
								cellAction: true,
								maxDigits: 10,
								decimalPlaces: 0,
								pkColumn: 'ValCodoutpt',
							}),
							new listColumnTypes.NumericColumn({
								order: 3,
								name: 'ValLine',
								area: 'OUTPU',
								field: 'LINE',
								label: computed(() => this.Resources.LINE27983),
								scrollData: 5,
								maxDigits: 3,
								decimalPlaces: 1,
								isOrderingColumn: true,
							}),
							new listColumnTypes.NumericColumn({
								order: 4,
								name: 'ValExitqnty',
								area: 'OUTPU',
								field: 'EXITQNTY',
								label: computed(() => this.Resources.QTD_OUTPUT12876),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}),
						],
						config: {
							name: 'ValLsaidas',
							serverMode: true,
							pkColumn: 'ValCodoutpu',
							tableAlias: 'OUTPU',
							tableNamePlural: computed(() => this.Resources.OUTPUTS47833),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.OUTPUT_10769),
							showAlternatePagination: true,
							permissions: {
							},
							globalSearch: {
								visibility: true,
								searchOnPressEnter: true
							},
							filtersVisible: true,
							allowColumnFilters: true,
							allowColumnSort: true,
							// eslint-disable-next-line no-unused-vars, eqeqeq
							rowTextColor: (row) => qApi.RGB(255,190,158),
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
										formName: 'LDSAI',
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
										formName: 'LDSAI',
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
										formName: 'LDSAI',
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
										formName: 'LDSAI',
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
										formName: 'LDSAI',
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
								id: 'RCA__LDSAI',
								name: '_LDSAI',
								title: '',
								isInReadOnly: true,
								params: {
									action: vm.openFormAction,
									type: 'form',
									formName: 'LDSAI',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'LDSAI': {
									fnKeySelector: (row) => row.Fields.ValCodoutpu,
									isPopup: false
								},
								'DSAID': {
									fnKeySelector: (row) => row.Fields.ValCodoutpt,
									isPopup: false
								},
							},
							rowValidation: {
								fnValidate: (row) => row.Fields.ValZzstate === 0,
								message: computed(() => this.Resources.ATENCAO__ESTA_FICHA_24725),
								class: 'c-table__row--pending'
							},
							// The list support form: LDSAI
							crudConditions: {
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							initialSortColumnName: 'ValLine',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-ITEM', 'changed-OUTPU', 'changed-OUTPT', 'changed-OUDOC', 'changed-WAREH', 'changed-WARE1'],
						uuid: 'Artig_ValLsaidas',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'item'],
								dependencyEvents: ['fieldChange:item.coditem'],
								dependencyField: 'ITEM.CODITEM',
								fnValueSelector: (model) => model.ValCoditem.value
							},
						],
					}, this),
					ARTIG___PSEUDNOVOGR05: new fieldControlClass.AccordionControl({
						id: 'ARTIG___PSEUDNOVOGR05',
						name: 'NOVOGR05',
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
					ARTIG___PSEUDCATEGORI: new fieldControlClass.MultipleValuesControl({
						modelField: 'List_Categori_SelectedIds',
						valueChangeEvent: 'fieldChange:pseud.List_Categori_SelectedIds',
						modelFieldOptions: 'List_Categori',
						id: 'ARTIG___PSEUDCATEGORI',
						name: 'CATEGORI',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.CATEGORIZATION17554),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-ARTIG___PSEUDNOVOGR06',
						container: 'ARTIG___PSEUDNOVOGR06',
						controller: 'ITEM',
						action: 'Artig_List_Categori',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValTpcatego',
								area: 'CATTP',
								field: 'TPCATEGO',
								label: computed(() => this.Resources.CATEGORY_TYPE23058),
								dataLength: 85,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'Sbcat.ValSubcateg',
								area: 'SBCAT',
								field: 'SUBCATEG',
								label: computed(() => this.Resources.SUB_CATEGORIA15612),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodsbcat',
							}),
						],
						config: {
							name: 'ValCategori',
							serverMode: true,
							pkColumn: 'ValCodtpcat',
							tableAlias: 'CATTP',
							tableNamePlural: computed(() => this.Resources.CATEGORY_TYPES54620),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.CATEGORIZATION17554),
							showAlternatePagination: true,
							rowClickActionInternal: 'selectMultiple',
							permissions: {
							},
							generalCustomActions: [
							],
							MCActions: [
							],
							rowClickAction: {
								id: 'RCA__CATAR',
								name: '_CATAR',
								title: '',
								isInReadOnly: true,
								params: {
									canExecuteAction: vm.applyChanges,
									action: vm.openFormAction,
									type: 'form',
									formName: 'CATAR',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'CATAR': {
									fnKeySelector: (row) => row.Fields.ValCodtpcat,
									isPopup: false
								},
							},
							rowValidation: {
								fnValidate: (row) => row.Fields.ValZzstate === 0,
								message: computed(() => this.Resources.ATENCAO__ESTA_FICHA_24725),
								class: 'c-table__row--pending'
							},
							// The list support form: CATAR
							crudConditions: {
							},
							defaultSearchColumnName: 'Sbcat.ValSubcateg',
							defaultSearchColumnNameOriginal: 'Sbcat.ValSubcateg',
							initialSortColumnName: '',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-CATTP', 'changed-SBCAT', 'changed-ITEMC', 'changed-ITEM'],
						uuid: 'Artig_ValCategori',
						allSelectedRows: 'false',
						controlLimits: [
						],
					}, this),
					ARTIG___PSEUDESCCATEG: new fieldControlClass.MultipleValuesExtensionControl({
						id: 'ARTIG___PSEUDESCCATEG',
						name: 'ESCCATEG',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.CHOSEN_CATEGORIES47546),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-ARTIG___PSEUDNOVOGR06',
						container: 'ARTIG___PSEUDNOVOGR06',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ARTIG___PSEUDCATEGOR_: new fieldControlClass.MultipleValuesControl({
						modelField: 'List_Categor_SelectedIds',
						valueChangeEvent: 'fieldChange:pseud.List_Categor_SelectedIds',
						modelFieldOptions: 'List_Categor',
						id: 'ARTIG___PSEUDCATEGOR_',
						name: 'CATEGOR',
						size: 'large',
						hasLabel: true,
						label: computed(() => this.Resources.FILTERED_CHECKLIST06261),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-ARTIG___PSEUDNOVOGR06',
						container: 'ARTIG___PSEUDNOVOGR06',
						controller: 'ITEM',
						action: 'Artig_List_Categor',
						hasDependencies: false,
						isInCollapsible: true,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValTpcatego',
								area: 'CATTP',
								field: 'TPCATEGO',
								label: computed(() => this.Resources.CATEGORY_TYPE23058),
								dataLength: 85,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'Sbcat.ValSubcateg',
								area: 'SBCAT',
								field: 'SUBCATEG',
								label: computed(() => this.Resources.SUB_CATEGORIA15612),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodsbcat',
							}),
						],
						config: {
							name: 'ValCategor',
							serverMode: true,
							pkColumn: 'ValCodtpcat',
							tableAlias: 'CATTP',
							tableNamePlural: computed(() => this.Resources.CATEGORY_TYPES54620),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.FILTERED_CHECKLIST06261),
							showAlternatePagination: true,
							rowClickActionInternal: 'selectMultiple',
							permissions: {
							},
							generalCustomActions: [
							],
							MCActions: [
							],
							rowClickAction: {
								id: 'RCA__CATAR',
								name: '_CATAR',
								title: '',
								isInReadOnly: true,
								params: {
									canExecuteAction: vm.applyChanges,
									action: vm.openFormAction,
									type: 'form',
									formName: 'CATAR',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'CATAR': {
									fnKeySelector: (row) => row.Fields.ValCodtpcat,
									isPopup: false
								},
							},
							rowValidation: {
								fnValidate: (row) => row.Fields.ValZzstate === 0,
								message: computed(() => this.Resources.ATENCAO__ESTA_FICHA_24725),
								class: 'c-table__row--pending'
							},
							// The list support form: CATAR
							crudConditions: {
							},
							defaultSearchColumnName: 'Sbcat.ValSubcateg',
							defaultSearchColumnNameOriginal: 'Sbcat.ValSubcateg',
							initialSortColumnName: '',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-CATTP', 'changed-SBCAT', 'changed-ITEMC', 'changed-ITEM'],
						uuid: 'Artig_ValCategor',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'item'],
								dependencyEvents: ['fieldChange:item.coditem'],
								dependencyField: 'ITEM.CODITEM',
								fnValueSelector: (model) => model.ValCoditem.value
							},
						],
					}, this),
					ARTIG___ITEM_CATEGORY: new fieldControlClass.StringControl({
						modelField: 'ValCategory',
						valueChangeEvent: 'fieldChange:item.category',
						id: 'ARTIG___ITEM_CATEGORY',
						name: 'CATEGORY',
						size: 'xlarge',
						hasLabel: true,
						label: computed(() => this.Resources.CATEGORIZATION17554),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						parentOpeningEvent: 'opened-ARTIG___PSEUDNOVOGR06',
						container: 'ARTIG___PSEUDNOVOGR06',
						isFormulaBlocked: true,
						maxLength: 85,
						labelId: 'label_ARTIG___ITEM_CATEGORY',
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					ARTIG___PSEUDNOVOGR06: new fieldControlClass.GroupControl({
						id: 'ARTIG___PSEUDNOVOGR06',
						name: 'NOVOGR06',
						size: 'xxlarge',
						hasLabel: true,
						label: computed(() => this.Resources.CATEGORIZATION17554),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						isCollapsible: true,
						anchored: false,
						openingEvent: 'opened-ARTIG___PSEUDNOVOGR06',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ARTIG___ITEM_EXISTENC: new fieldControlClass.NumberControl({
						modelField: 'ValExistenc',
						valueChangeEvent: 'fieldChange:item.existenc',
						maxIntegers: 10,
						maxDecimals: 0,
						id: 'ARTIG___ITEM_EXISTENC',
						name: 'EXISTENC',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.EXISTENCE30081),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ARTIG___PSEUDNOVOGR07',
						isFormulaBlocked: true,
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					ARTIG___ITEM_DISPONIB: new fieldControlClass.ArrayStringControl({
						modelField: 'ValDisponib',
						valueChangeEvent: 'fieldChange:item.disponib',
						id: 'ARTIG___ITEM_DISPONIB',
						name: 'DISPONIB',
						size: 'medium',
						hasLabel: true,
						label: computed(() => this.Resources.AVAILABILITY56489),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'ARTIG___PSEUDNOVOGR07',
						isFormulaBlocked: true,
						maxLength: 1,
						labelId: 'label_ARTIG___ITEM_DISPONIB',
						arrayName: 'dsiponib',
						mustBeFilled: false,
						controlLimits: [
						],
						isFixed: true,
					}, this),
					ARTIG___PSEUDNOVOGR08: new fieldControlClass.GroupControl({
						id: 'ARTIG___PSEUDNOVOGR08',
						name: 'NOVOGR08',
						size: 'block',
						hasLabel: true,
						label: computed(() => this.Resources.IMAGE65174),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: '',
						container: 'ARTIG___PSEUDNOVOGR07',
						isCollapsible: true,
						anchored: false,
						openingEvent: 'opened-ARTIG___PSEUDNOVOGR08',
						mustBeFilled: false,
						controlLimits: [
						],
					}, this),
					ARTIG___ITEM_DATE____: new fieldControlClass.DateControl({
						modelField: 'ValDate',
						valueChangeEvent: 'fieldChange:item.date',
						locale: computed(() => vm.system.currentLang),
						dateFormat: computed(() => vm.system.dateFormat),
						id: 'ARTIG___ITEM_DATE____',
						name: 'DATE',
						size: 'small',
						hasLabel: true,
						label: computed(() => this.Resources.DATE18475),
						userHelp: '',
						description: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						mustBeFilled: false,
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
					'ARTIG___PSEUDNOVOGR02',
					'ARTIG___PSEUDNOVOGR01',
					'ARTIG___PSEUDNOVOGR07',
					'ARTIG___PSEUDNOVOGR08',
					'ARTIG___PSEUDNOVOGR05',
					'ARTIG___PSEUDNOVOGR03',
					'ARTIG___PSEUDNOVOGR04',
					'ARTIG___PSEUDNOVOGR06',
				]),

				tableFields: readonly([
					'ARTIG___PSEUDCONTACOR',
					'ARTIG___PSEUDLENTRADA',
					'ARTIG___PSEUDLSAIDAS_',
					'ARTIG___PSEUDCATEGORI',
					'ARTIG___PSEUDCATEGOR_',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Gitem: {
						get ValItemdes() { return vm.model.TableGitemItemdes.value },
						set ValItemdes(value) { vm.model.TableGitemItemdes.updateValue(value) },
						get ValItemgcod() { return vm.model.GitemValItemgcod.value },
						set ValItemgcod(value) { vm.model.GitemValItemgcod.updateValue(value) },
					},
					Item: {
						get ValCategory() { return vm.model.ValCategory.value },
						set ValCategory(value) { vm.model.ValCategory.updateValue(value) },
						get ValCodgitem() { return vm.model.ValCodgitem.value },
						set ValCodgitem(value) { vm.model.ValCodgitem.updateValue(value) },
						get ValCodwareh() { return vm.model.ValCodwareh.value },
						set ValCodwareh(value) { vm.model.ValCodwareh.updateValue(value) },
						get ValDate() { return vm.model.ValDate.value },
						set ValDate(value) { vm.model.ValDate.updateValue(value) },
						get ValDisponib() { return vm.model.ValDisponib.value },
						set ValDisponib(value) { vm.model.ValDisponib.updateValue(value) },
						get ValEntries() { return vm.model.ValEntries.value },
						set ValEntries(value) { vm.model.ValEntries.updateValue(value) },
						get ValExistenc() { return vm.model.ValExistenc.value },
						set ValExistenc(value) { vm.model.ValExistenc.updateValue(value) },
						get ValExits() { return vm.model.ValExits.value },
						set ValExits(value) { vm.model.ValExits.updateValue(value) },
						get ValImage() { return vm.model.ValImage.value },
						set ValImage(value) { vm.model.ValImage.updateValue(value) },
						get ValItemcod() { return vm.model.ValItemcod.value },
						set ValItemcod(value) { vm.model.ValItemcod.updateValue(value) },
						get ValItemdes() { return vm.model.ValItemdes.value },
						set ValItemdes(value) { vm.model.ValItemdes.updateValue(value) },
						get ValItemtype() { return vm.model.ValItemtype.value },
						set ValItemtype(value) { vm.model.ValItemtype.updateValue(value) },
						get ValValid() { return vm.model.ValValid.value },
						set ValValid(value) { vm.model.ValValid.updateValue(value) },
					},
					Wareh: {
						get ValWarehdes() { return vm.model.TableWarehWarehdes.value },
						set ValWarehdes(value) { vm.model.TableWarehWarehdes.updateValue(value) },
					},
					keys: {
						/** The primary key of the ITEM table */
						get item() { return vm.model.ValCoditem },
						/** The foreign key to the GITEM table */
						get gitem() { return vm.model.ValCodgitem },
						/** The foreign key to the WAREH table */
						get wareh() { return vm.model.ValCodwareh },
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
// USE /[MANUAL GQT FORM_CODEJS ARTIG]/
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
// USE /[MANUAL GQT BEFORE_LOAD_JS ARTIG]/
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
// USE /[MANUAL GQT FORM_LOADED_JS ARTIG]/
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
// USE /[MANUAL GQT BEFORE_APPLY_JS ARTIG]/
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
// USE /[MANUAL GQT AFTER_APPLY_JS ARTIG]/
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
// USE /[MANUAL GQT BEFORE_SAVE_JS ARTIG]/
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
// USE /[MANUAL GQT AFTER_SAVE_JS ARTIG]/
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
// USE /[MANUAL GQT BEFORE_DEL_JS ARTIG]/
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
// USE /[MANUAL GQT AFTER_DEL_JS ARTIG]/
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
// USE /[MANUAL GQT BEFORE_EXIT_JS ARTIG]/
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
// USE /[MANUAL GQT AFTER_EXIT_JS ARTIG]/
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
// USE /[MANUAL GQT DLGUPDT ARTIG]/
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
// USE /[MANUAL GQT CTRLUPD ARTIG]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
		},

		watch: {
			'controls.ARTIG___PSEUDCATEGORI.rowsSelected': {
				handler()
				{
					this.model.List_Categori_SelectedIds.value = this.rowKeyHashTableToArray(this.controls.ARTIG___PSEUDCATEGORI.rowsSelected)
				},
				deep: true
			},
			'controls.ARTIG___PSEUDCATEGOR_.rowsSelected': {
				handler()
				{
					this.model.List_Categor_SelectedIds.value = this.rowKeyHashTableToArray(this.controls.ARTIG___PSEUDCATEGOR_.rowsSelected)
				},
				deep: true
			},
			// Watchers for changes in the state of tabs and collapsible groups.
			'controls.ARTIG___PSEUDNOVOGR03.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'ARTIG___PSEUDNOVOGR03',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
			'controls.ARTIG___PSEUDNOVOGR04.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'ARTIG___PSEUDNOVOGR04',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
			'controls.ARTIG___PSEUDNOVOGR06.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'ARTIG___PSEUDNOVOGR06',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
			'controls.ARTIG___PSEUDNOVOGR08.isOpen'(newVal)
			{
				const data = {
					navigationId: this.navigationId,
					key: this.storeKey,
					formInfo: this.formInfo,
					fieldId: 'ARTIG___PSEUDNOVOGR08',
					containerState: newVal
				}
				this.storeContainerState(data)
			},
		}
	}
</script>
