using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Filtering;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Helpers.Table.Renderer;
using GenioMVC.Helpers.Table.Sorting;

namespace GenioMVC.Helpers.Table
{
    public class TableListBuilder<TModel> : DbEditBuilder<TModel>, ITableListBuilder <TModel> where TModel : class
    {
        public new TableList<TModel> Builder
        {
            get { return (TableList<TModel>)_builder; }
        }

        internal TableListBuilder(Table<TModel> builder, bool hasFilters)
			: base(builder, hasFilters)
        {
            _builder = new TableList<TModel>(builder, hasFilters);
        }

        #region Builder Methods
        
		/// Set Filters properties
        new public TableListBuilder<TModel> Filters(GenioMVC.ViewModels.TableFiltering filters)
        {
            if (filters != null)
                this.Builder.SetFilters(filters.ShowTableFilters, filters.HasFilters, filters.FiltersValues, filters.QueryField, filters.Query);
            else
                this.Builder.SetFilters();

            return this;
        }
		
		/// Adds an action to the current table
        public TableListBuilder<TModel> AddTableAction(string action, string controller, Func<TModel, object> routeValuesFun, string icon, string title, bool isBootStrapIcon = false, bool isRoutine = false, bool multipleSelection = false, bool isAjaxAction = false, object htmlAtributes = null, bool accesslevel = true)
        {
            this.Builder.AddTableAction(action, controller, routeValuesFun, icon, title, isBootStrapIcon, isRoutine, multipleSelection, isAjaxAction, htmlAtributes, accesslevel: accesslevel);
            return this;
        }
		
        /// Set Help Form
        new public TableListBuilder<TModel> Form(string helpForm, bool openInPopup = false, bool repeatInsertion = false, object btnsAttributes = null)
        {
            this.Builder.SetForm(helpForm, openInPopup, repeatInsertion, btnsAttributes);
            return this;
        }
		
		/// Set Extended Help Form
        public TableListBuilder<TModel> ExtendedForm(string controller, string ajaxContainer)
        {
            this.Builder.SetExtendedForm(controller, ajaxContainer);
            return this;
        }

        /// Set Permissions
        new public TableListBuilder<TModel> Permissions(bool canView = true, bool canInsert = true, bool canEdit = true, 
            bool canDuplicate = true, bool canDelete = true)
        {
            this.Builder.SetPermissions(canView, canInsert, canEdit, canDuplicate, canDelete);
            return this;
        }
		
        /// Set Request Link
        public TableListBuilder<TModel> RequestLink(string url)
        {
            this.Builder.SetRequestLink(url);
            return this;
        }

        // Set background colour on condition
        public new TableListBuilder<TModel> BackgroundColourOnCondition(Expression<Func<TModel, string>> expression)
        {
            this.Builder.SetBackgroundColourOnCondition(expression);
            return this;
        }

        // Set foreground colour on condition
        public new TableListBuilder<TModel> ForegroundColourOnCondition(Expression<Func<TModel, string>> expression)
        {
            this.Builder.SetForegroundColourOnCondition(expression);
            return this;
        }

        /// Set table list as multiple selection
        public new TableListBuilder<TModel> MultipleSelection()
        {
            this.Builder.SetMultipleSelection();
            return this;
        }
        #endregion Builder Methods

        /// <summary>
        /// Convert the DbEditBuilder to HTML.
        /// </summary>
        public new MvcHtmlString ToHtml()
        {
            if (!this.Builder.IsInEditMode) { 
                this.Builder.SetPermissions(this.Builder.Permissions.CanView, false, false, false, false);
            }
            
            this.Builder.DoInternalActions();

            return new TableListRenderer<TModel>(this.Builder).ToHtml();
        }
    }
}