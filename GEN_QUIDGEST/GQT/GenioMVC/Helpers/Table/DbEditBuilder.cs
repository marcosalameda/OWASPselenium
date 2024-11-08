using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using CSGenio.framework;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Filtering;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Helpers.Table.Renderer;
using GenioMVC.Helpers.Table.Sorting;

namespace GenioMVC.Helpers.Table
{
    public class DbEditBuilder<TModel> : TableBuilder<TModel>, IDbEditBuilder<TModel> where TModel : class
    {
        new public DbEdit<TModel> Builder
        {
            get { return (DbEdit<TModel>)_builder; }
        }

        internal DbEditBuilder(Table<TModel> builder, bool canFilter)
			: base(builder.HtmlHelper, TableType.DBedit, builder.IsInEditMode, true, true)
        {
            _builder = new DbEdit<TModel>(builder, canFilter);
        }

        #region Builder Methods
        
        /// Set Filters properties
        public DbEditBuilder<TModel> Filters(GenioMVC.ViewModels.TableFiltering filters)
        {
            if (filters != null)
                this.Builder.SetFilters(filters.ShowTableFilters, filters.HasFilters, filters.FiltersValues, filters.QueryField, filters.Query);
            else
                this.Builder.SetFilters();

            return this;
        }

        /// Set dbedit as multiple selection
        public DbEditBuilder<TModel> MultipleSelection()
        {
            this.Builder.SetMultipleSelection();
            return this;
        }

        /// Set dbedit as DE / DF selection
        public DbEditBuilder<TModel> DEF_MultipleSelection()
        {
            this.Builder.SetDEFSelection();
            return this;
        }

        /// Set Help Form
        public DbEditBuilder<TModel> Form(string helpForm, bool openInPopup = false, bool repeatInsertion = false, object btnsAttributes = null)
        {
            this.Builder.SetForm(helpForm, openInPopup, repeatInsertion, btnsAttributes);
            return this;
        }

        /// Set Permissions
        public DbEditBuilder<TModel> Permissions(bool canView = true, bool canInsert = true, bool canEdit = true, 
            bool canDuplicate = true, bool canDelete = true)
        {
            this.Builder.SetPermissions(canView, canInsert, canEdit, canDuplicate, canDelete);
            return this;
        }

        public DbEditBuilder<TModel> UpdateConditions(Func<TModel,StatusMessage> method)
        {
            this.Builder.UpdateConditions = method;
            return this;
        }

        public DbEditBuilder<TModel> ViewConditions(Func<TModel,StatusMessage> method)
        {
            this.Builder.ViewConditions = method;
            return this;
        }

        public DbEditBuilder<TModel> DeleteConditions(Func<TModel,StatusMessage> method)
        {
            this.Builder.DeleteConditions = method;
            return this;
        }

        public DbEditBuilder<TModel> InsertConditions(Func<TModel,StatusMessage> method)
        {
            this.Builder.InsertConditions = method;
            return this;
        }

        
        /// Adds a following action to the current table
        public DbEditBuilder<TModel> AddTableAction(string action, string controller, Func<TModel, object> routeValuesFun, string icon, string title, bool isBootStrapIcon = false, bool isRoutine = false, bool multipleSelection = false, bool isAjaxAction = false, object htmlAttributes = null, bool accesslevel = true, bool isSlotReport=false, string slotReportId = "", bool openInPopup = false)
        {
            this.Builder.AddTableAction(action, controller, routeValuesFun, icon, title, isBootStrapIcon, isRoutine, multipleSelection, isAjaxAction, htmlAttributes, accesslevel: accesslevel, isSlotReport: isSlotReport, slotReportId: slotReportId, openInPopup: openInPopup);
            return this;
        }
        
        /// Adds a following action to the current table
        public DbEditBuilder<TModel> SetFollowUp(string action, string controller, Func<TModel, object> routeValuesFun, bool isRoutine = false, bool isSpecificPaths = false, bool isAjaxAction = false, object htmlAttributes = null, bool openInPopup = false)
        {
            this.Builder.SetFollowUp(action, controller, routeValuesFun, isRoutine, isSpecificPaths, isAjaxAction, htmlAttributes, openInPopup);
            return this;
        }

        // Set background colour on condition
        public DbEditBuilder<TModel> BackgroundColourOnCondition(Expression<Func<TModel, string>> expression)
        {
            this.Builder.SetBackgroundColourOnCondition(expression);
            return this;
        }

        // Set foreground colour on condition
        public DbEditBuilder<TModel> ForegroundColourOnCondition(Expression<Func<TModel, string>> expression)
        {
            this.Builder.SetForegroundColourOnCondition(expression);
            return this;
        }

        #endregion Builder Methods

        /// <summary>
        /// Convert the DbEditBuilder to HTML.
        /// </summary>
        public MvcHtmlString ToHtml(bool hidden = false)
        {
            this.Builder.DoInternalActions();

            return new DbEditRenderer<TModel>(this.Builder).ToHtml(hidden);
        }
    }
}
