using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSGenio.framework;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Filtering;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Helpers.Table.Utils;

namespace GenioMVC.Helpers.Table.Builder
{
    public class DbEdit<TModel> : Table<TModel> 
        where TModel : class
    {
        public FormProperties Form { get; protected set; }
        public TableFilter Filter { get; protected set; }
        private bool hasActionsColumn;
		public bool hasActionsCol { get{ return this.hasActionsColumn; } }
        public Func<TModel, StatusMessage> UpdateConditions { get; set; }  = (m) => StatusMessage.OK();
        public Func<TModel, StatusMessage> ViewConditions { get; set; }  = (m) => StatusMessage.OK();
        public Func<TModel, StatusMessage> DeleteConditions { get; set; }  = (m) => StatusMessage.OK();
        public Func<TModel, StatusMessage> InsertConditions { get; set; }  = (m) => StatusMessage.OK();

        public DbEdit() { }

        public DbEdit(Table<TModel> builder, bool canFilter)
        {
            this.ajaxUpdateContainerId = builder.ajaxUpdateContainerId;
            this.Data = builder.Data;
            this.DefaultSorter = builder.DefaultSorter;
            this.hasPagination = builder.hasPagination;
            this.hasSorting = builder.hasSorting;
            this.HtmlHelper = builder.HtmlHelper;
            this.HttpContext = builder.HttpContext;
            this.HttpRequest = builder.HttpRequest;
            this.Pager = builder.Pager;
            this.requestsLink = builder.requestsLink;
            this.Sorter = builder.Sorter;
            this.TableColumns = builder.TableColumns;
            this.TableId = builder.TableId;
            this.TableKey = builder.TableKey;
            this.TableType = builder.TableType;
            this.useAjax = builder.useAjax;
            this.TableCssClass = builder.TableCssClass;
            this.hasCounter = builder.hasCounter;
            this.FocusOnRecord = builder.FocusOnRecord;
            this.slotReports = builder.slotReports;
            this.IsInEditMode = builder.IsInEditMode;
            this.hasActionsColumn = this.TableColumns != null && this.TableColumns.Any(c => c.IsActionsColumn);

            // DbEdit
            this.Permissions = builder.Permissions ?? new TablePermissions(this.IsInEditMode);
            this.hasFilters = canFilter;
            this.Form = new FormProperties(null, false, false);
            this._tableActions = new List<TableAction<TModel>>();
            this.tableLimits = builder.tableLimits;
        }

        ///
        public void SetFilters(bool showTableFilters = false, bool hasAdvancedFilters = false, Dictionary<string, string> filtersValues = null, string queryField = "", string query = "")
        {
            this.Filter = new TableFilter(showTableFilters, hasAdvancedFilters, filtersValues ?? new Dictionary<string, string>(), queryField, query);
            if (!this.hasActionsColumn)
                this.AddActionsColumn();
        }

        ///
        public void SetForm(string helpForm, bool openInPopup, bool repeatInsertion, object btnsAttributes = null)
        {
            this.Form = new FormProperties(helpForm, openInPopup, repeatInsertion, btnsAttributes);
        }

        ///
        public void SetPermissions(bool canView = true, bool canInsert = true, bool canEdit = true,
            bool canDuplicate = true, bool canDelete = true)
        {
            this.Permissions = new TablePermissions(canView, canInsert, canEdit, canDuplicate, canDelete, this.IsInEditMode);
        }

        /// Adds a following action to the current table
        public void AddTableAction(string action, string controller, Func<TModel, object> routeValuesFun, string icon, string title, bool isBootStrapIcon = false, bool isRoutine = false, bool multipleSelection = false, bool isAjaxAction = false, object htmlAttributes = null, bool accesslevel = true, bool isSlotReport = false, string slotReportId = "", bool openInPopup = false)
        {
            if (!this.hasActionsColumn)
                this.AddActionsColumn();

            // PG 11/08/2021: Split into 2 steps to allow special renderings to use only this one
			AddTableActionInternal(action, controller, routeValuesFun, icon, title, isBootStrapIcon, isRoutine, multipleSelection, isAjaxAction, htmlAttributes, accesslevel, isSlotReport, slotReportId, openInPopup);
        }

        public void AddTableActionInternal(string action, string controller, Func<TModel, object> routeValuesFun, string icon, string title, bool isBootStrapIcon = false, bool isRoutine = false, bool multipleSelection = false, bool isAjaxAction = false, object htmlAttributes = null, bool accesslevel = true, bool isSlotReport = false, string slotReportId = "", bool openInPopup = false)
        {
            TableAction<TModel> ta = new TableAction<TModel>(action, controller, routeValuesFun, icon, isBootStrapIcon, title, isRoutine, multipleSelection, htmlAttributes, false, false, isAjaxAction, openInPopup: openInPopup, accesslevel: accesslevel, isSlotReport: isSlotReport, slotReportId: slotReportId);
            this._tableActions.Add(ta);
        }

        /// Adds a following action to the current table
        public void SetFollowUp(string action, string controller, Func<TModel, object> routeValuesFun, bool isRoutine = false, bool isSpecificPaths = false, bool isAjaxAction = false, object htmlAttributes = null, bool openInPopup = false)
        {
            if (!this.hasActionsColumn)
                this.AddActionsColumn();

            if (htmlAttributes == null)
                htmlAttributes = new { };

            TableAction<TModel> ta = new TableAction<TModel>(action, controller, routeValuesFun, "icon-play-circle", true, null, isRoutine, multipleSelection, htmlAttributes, true, isSpecificPaths, isAjaxAction, openInPopup);
            this._tableActions.Add(ta);
        }

        internal void AddActionsColumn()
        {
            this.hasActionsColumn = true;
            if (LayoutConfig.config.DbEditActionPlacement == "left")
                this.TableColumns.Insert(0, new TableColumn<TModel, object>(actionsColumn: true) { ColumnSize = 0 });
            else
                this.TableColumns.Add(new TableColumn<TModel, object>(actionsColumn: true) { ColumnSize = 0 });
        }

        internal override void DoInternalActions()
        {
            base.DoInternalActions();

            if (this.Permissions.CanDelete || this.Permissions.CanEdit || this.Permissions.CanInsert || this.Permissions.CanView || this.Permissions.CanDuplicate)
                if (!string.IsNullOrEmpty(this.Form.HelpForm) && !this.hasActionsColumn)
                    this.AddActionsColumn();
        }

        internal void SetMultipleSelection()
        {
            this.multipleSelection = true;
        }

        internal void SetDEFSelection()
        {
            this._DEF_MultipleSelection = true;
        }

        public bool HasHelpForm() { return !string.IsNullOrEmpty(this.Form.HelpForm); }
        public bool HasViewAction() { return this.HasHelpForm() && this.Permissions.CanView; }
        public bool HasEditAction() { return this.HasHelpForm() && this.Permissions.CanEdit; }
        public bool HasDeleteAction() { return this.HasHelpForm() && this.Permissions.CanDelete; }
        public bool HasDuplicateAction() { return this.HasHelpForm() && this.Permissions.CanDuplicate; }
        public bool HasInsertAction() { return this.HasHelpForm() && this.Permissions.CanInsert; }

        public bool HasInternalActions(bool excludeView = false) 
        { 
            return this.HasHelpForm() && 
                ((!excludeView && this.Permissions.CanView) || this.Permissions.CanEdit || this.Permissions.CanDelete || this.Permissions.CanDuplicate); 
        }

        public bool FollowUpIsEqualViewAction()
        {
            TableAction<TModel> followUpAction = TableUtils.GetFollowUpAction(this.TableActions);
            if (followUpAction == null)
                return false;

            return this.HasFollowUpAction() && this.HasViewAction() &&
                followUpAction.Controller.Equals(typeof(TModel).Name) && followUpAction.Action.Equals(this.Form.HelpForm + "_Show");
        }

        public bool FollowUpIsEqualEditAction()
        {
            TableAction<TModel> followUpAction = TableUtils.GetFollowUpAction(this.TableActions);
            if (followUpAction == null)
                return false;

            return this.HasFollowUpAction() && this.HasEditAction() &&
                followUpAction.Controller.Equals(typeof(TModel).Name) && followUpAction.Action.Equals(this.Form.HelpForm + "_Edit");
        }

        public bool HasOnlyOneAction()
        {
            return
                !this.HasTableActions() && !this.HasInternalActions() && this.HasFollowUpAction() || // 1 FollowUp
                this.HasTableActions() && this.TableActions.Where(x => !x.IsFollowUp).Count() == 1 && !this.HasInternalActions() && !this.HasFollowUpAction() || // 1 TableAction
                !this.HasTableActions() && !this.HasFollowUpAction() && this.Permissions.NumberOfPermissons == 1 && this.HasHelpForm() // 1 Permissão
                ;
        }

        public bool IsDelOrDupWithCreate(string type)
        {
            switch (type)
            {
                case "delete":
                    return this.HasDeleteAction() && this.Permissions.NumberOfPermissons == 2 && this.HasInsertAction();
                case "duplicate":
                    return this.HasDuplicateAction() && this.Permissions.NumberOfPermissons == 2 && this.HasInsertAction();
            }
            return false;

        }

        public bool IsViewOrEditEqualFollup(string type)
        {
            switch (type)
            {
                case "edit":
                    return this.HasFollowUpAction() && this.HasEditAction() && this.Permissions.NumberOfPermissons == 1 && FollowUpIsEqualEditAction() ||
                        this.HasFollowUpAction() && this.Permissions.NumberOfPermissons == 2 && this.HasEditAction() && FollowUpIsEqualEditAction() && this.HasInsertAction();


                case "view":
                    return this.HasFollowUpAction() && this.HasViewAction() && this.Permissions.NumberOfPermissons == 1 && FollowUpIsEqualViewAction() ||
                            this.HasFollowUpAction() && this.Permissions.NumberOfPermissons == 2 && this.HasViewAction() && FollowUpIsEqualViewAction()  && this.HasInsertAction();
            }
            return false;
        }

        public bool IsViewOrEditDiffFollup(string type)
        {
            switch (type)
            {
                case "edit":
                    return this.HasFollowUpAction() && this.HasEditAction() && this.Permissions.NumberOfPermissons == 1 && !FollowUpIsEqualEditAction() ||
                        this.HasFollowUpAction() && this.Permissions.NumberOfPermissons == 2 && this.HasEditAction() && !FollowUpIsEqualEditAction() && this.HasInsertAction();


                case "view":
                    return this.HasFollowUpAction() && this.HasViewAction() && this.Permissions.NumberOfPermissons == 1 && !FollowUpIsEqualViewAction() ||
                            this.HasFollowUpAction() && this.Permissions.NumberOfPermissons == 2 && this.HasViewAction() && !FollowUpIsEqualViewAction() && this.HasInsertAction();
            }
            return false;
        }

        public bool HasActions()
        {
            return this.HasTableActions() || this.HasInternalActions() || this.HasFollowUpAction();
        }
    }
}