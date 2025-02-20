import { defineAsyncComponent } from 'vue'

// Quidgest UI
import {
	QBadge,
	QButton,
	QButtonGroup,
	QButtonToggle,
	QCard,
	QCombobox,
	QColorPicker,
	QField,
	QInputGroup,
	QIcon,
	QIconImg,
	QIconFont,
	QIconSvg,
	QOverlay,
	QPopover,
	QPropertyList,
	QLineLoader,
	QList,
	QSelect,
	QSkeletonLoader,
	QSpinnerLoader,
	QTextField,
	QTooltip
} from '@quidgest/ui/components'

export const components = {
	// UI package controls
	QBadge,
	QButton,
	QButtonGroup,
	QButtonToggle,
	QCard,
	QCombobox,
	QColorPicker,
	QField,
	QInputGroup,
	QIcon,
	QIconImg,
	QIconFont,
	QIconSvg,
	QOverlay,
	QPopover,
	QPropertyList,
	QLineLoader,
	QList,
	QSelect,
	QSkeletonLoader,
	QSpinnerLoader,
	QTextField,
	QTooltip,

	// Wrapper controls
	QControlWrapper: defineAsyncComponent(() => import('./ControlWrapper.vue')),
	VFragment: defineAsyncComponent(() => import('./VFragment.vue')),

	// Static controls
	QStaticText: defineAsyncComponent(() => import('./QStaticText.vue')),
	QPageBusyState: defineAsyncComponent(() => import('./QPageBusyState.vue')),
	QInfoMessage: defineAsyncComponent(() => import('./QInfoMessage.vue')),

	// Input controls
	BaseInputStructure: defineAsyncComponent(() => import('./inputs/BaseInputStructure.vue')),
	QPasswordInput: defineAsyncComponent(() => import('./inputs/PasswordInput.vue')),
	QTextareaInput: defineAsyncComponent(() => import('./inputs/TextareaInput.vue')),
	QRadioGroup: defineAsyncComponent(() => import('./inputs/RadioButtonInput.vue')),
	QNumericInput: defineAsyncComponent(() => import('./inputs/NumericInput.vue')),
	QCheckboxInput: defineAsyncComponent(() => import('./inputs/CheckBoxInput.vue')),
	QCheckListInput: defineAsyncComponent(() => import('./inputs/CheckListInput.vue')),
	QToggleInput: defineAsyncComponent(() => import('./inputs/ToggleInput.vue')),
	QMask: defineAsyncComponent(() => import('./inputs/QMask.vue')),
	QListBoxInput: defineAsyncComponent(() => import('./inputs/ListBoxInput.vue')),
	QLookup: defineAsyncComponent(() => import('./inputs/QLookup.vue')),
	GridBaseInputStructure: defineAsyncComponent(() => import('./inputs/GridBaseInputStructure.vue')),
	QDateTimePicker: defineAsyncComponent(() => import('./inputs/QDateTimePicker.vue')),
	QTextEditor: defineAsyncComponent(() => import('./inputs/QTextEditor.vue')),
	MultiCheckBoxesInput: defineAsyncComponent(() => import('./inputs/MultiCheckBoxesInput.vue')),
	QDocument: defineAsyncComponent(() => import('./inputs/document/QDocument.vue')),
	QImage: defineAsyncComponent(() => import('./inputs/image/QImage.vue')),
	QCodeEditor: defineAsyncComponent(() => import('./inputs/code/QCodeEditor.vue')),

	// Container controls
	QGroupBoxContainer: defineAsyncComponent(() => import('./containers/GroupBoxContainer.vue')),
	QAccordionContainer: defineAsyncComponent(() => import('./containers/QAccordionContainer.vue')),
	QGroupCollapsible: defineAsyncComponent(() => import('./containers/QGroupCollapsible.vue')),
	QRowContainer: defineAsyncComponent(() => import('./containers/RowContainer.vue')),
	QTabContainer: defineAsyncComponent(() => import('./containers/TabContainer.vue')),
	QModalContainer: defineAsyncComponent(() => import('./containers/QModalContainer.vue')),
	QFormContainer: defineAsyncComponent(() => import('./containers/QFormContainer.vue')),
	QWizard: defineAsyncComponent(() => import('./containers/wizard/QWizard.vue')),
	QAnchorContainerHorizontal: defineAsyncComponent(() => import('./containers/QAnchorContainerHorizontal.vue')),
	QAnchorContainerVertical: defineAsyncComponent(() => import('./containers/QAnchorContainerVertical.vue')),
	QAnchorElement: defineAsyncComponent(() => import('./containers/QAnchorElement.vue')),
	QCardView: defineAsyncComponent(() => import('./containers/QCard.vue')),
	QKanbanCard: defineAsyncComponent(() => import('./containers/QKanbanCard.vue')),
	QKanbanHeader: defineAsyncComponent(() => import('./containers/QKanbanHeader.vue')),
	QKanban: defineAsyncComponent(() => import('./containers/QKanban.vue')),

	// Rendering controls
	// Render components are used by tables to display fields.
	// Edit components are used by advanced filters, column filters and editable fields in normal tables
	// (different than the ones in the editable table lists).
	QRenderArray: defineAsyncComponent(() => import('./rendering/QRenderArray.vue')),
	QRenderBoolean: defineAsyncComponent(() => import('./rendering/QRenderBoolean.vue')),
	QRenderData: defineAsyncComponent(() => import('./rendering/QRenderData.vue')),
	QRenderHyperlink: defineAsyncComponent(() => import('./rendering/QRenderHyperlink.vue')),
	QRenderHtml: defineAsyncComponent(() => import('./rendering/QRenderHtml.vue')),
	QRenderImage: defineAsyncComponent(() => import('./rendering/QRenderImage.vue')),
	QRenderDocument: defineAsyncComponent(() => import('./rendering/QRenderDocument.vue')),
	QEditText: defineAsyncComponent(() => import('./rendering/QEditText.vue')),
	QEditTextMultiline: defineAsyncComponent(() => import('./rendering/QEditTextMultiline.vue')),
	QEditNumeric: defineAsyncComponent(() => import('./rendering/QEditNumeric.vue')),
	QEditBoolean: defineAsyncComponent(() => import('./rendering/QEditBoolean.vue')),
	QEditDatetime: defineAsyncComponent(() => import('./rendering/QEditDatetime.vue')),
	QEditEnumeration: defineAsyncComponent(() => import('./rendering/QEditEnumeration.vue')),
	QEditCheckList: defineAsyncComponent(() => import('./rendering/QEditCheckList.vue')),
	QEditRadio: defineAsyncComponent(() => import('./rendering/QEditRadio.vue')),

	// Complex controls
	QPasswordMeter: defineAsyncComponent(() => import('./rendering/QPasswordMeter.vue')),
	QProgress: defineAsyncComponent(() => import('./rendering/QProgress.vue')),
	QTimeline: defineAsyncComponent(() => import('./timeline/QTimeline.vue')),
	QDashboard: defineAsyncComponent(() => import('./dashboard/QDashboard.vue')),

	// Special renderings
	QCalendar: defineAsyncComponent(() => import('./rendering/QCalendar.vue')),
	QCards: defineAsyncComponent(() => import('./rendering/cards/QCards.vue')),
	QCarousel: defineAsyncComponent(() => import('./rendering/QCarousel.vue')),
	QChart: defineAsyncComponent(() => import('./rendering/chart/QChart.vue')),
	QCollapsiblerowslist: defineAsyncComponent(() => import('./rendering/QCollapsiblerowslist.vue')),
	QMap: defineAsyncComponent(() => import('./rendering/map/QMap.vue')),

	// Table components
	QTable: defineAsyncComponent(() => import('./table/QTable.vue')),
	QTableRecordActionsMenu: defineAsyncComponent(() => import('./table/QTableRecordActionsMenu.vue')),
	QTableSearch: defineAsyncComponent(() => import('./table/QTableSearch.vue')),
	QTableExport: defineAsyncComponent(() => import('./table/QTableExport.vue')),
	QTableImport: defineAsyncComponent(() => import('./table/QTableImport.vue')),
	QTableStaticFilters: defineAsyncComponent(() => import('./table/QTableStaticFilters.vue')),
	QTablePagination: defineAsyncComponent(() => import('./table/QTablePagination.vue')),
	QTablePaginationAlt: defineAsyncComponent(() => import('./table/QTablePaginationAlt.vue')),
	QTableLimitInfo: defineAsyncComponent(() => import('./table/QTableLimitInfo.vue')),
	QTableChecklistCheckbox: defineAsyncComponent(() => import('./table/QTableChecklistCheckbox.vue')),
	QTableSelector: defineAsyncComponent(() => import('./table/QTableSelector.vue')),
	QTableColumnFilters: defineAsyncComponent(() => import('./table/QTableColumnFilters.vue')),
	QTableColumnTotalizers: defineAsyncComponent(() => import('./table/QTableColumnTotalizers.vue')),
	QTableCurrentFilters: defineAsyncComponent(() => import('./table/QTableCurrentFilters.vue')),
	QTableActions: defineAsyncComponent(() => import('./table/QTableActions.vue')),
	QTableConfig: defineAsyncComponent(() => import('./table/QTableConfig.vue')),
	QTableViews: defineAsyncComponent(() => import('./table/QTableViews.vue')),
	QTableViewSave: defineAsyncComponent(() => import('./table/QTableViewSave.vue')),
	QTableExtraExtension: defineAsyncComponent(() => import('./table/QTableExtraExtension.vue')),
	QTableViewModeConfig: defineAsyncComponent(() => import('./table/QTableViewModeConfig.vue')),
	QGridTableList: defineAsyncComponent(() => import('./table/QGridTableList.vue')),
	QCheckListExtension: defineAsyncComponent(() => import('./extensions/CheckListExtension.vue')),

	// Other components
	QValidationSummary: defineAsyncComponent(() => import('@/views/shared/QValidationSummary.vue'))
}

export const componentNames = Object.keys(components)

export default {
	install: (app) => {
		for (let i in components)
			app.component(i, components[i])
	}
}
