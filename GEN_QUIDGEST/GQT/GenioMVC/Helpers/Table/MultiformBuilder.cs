using System;
using System.Collections.Generic;
using System.Linq;
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
    public class MultiformBuilder<TModel> : IMultiformBuilder<TModel> where TModel : class
    {
        public Table<TModel> _builder { get; set; }

        public Multiform<TModel> Builder
        {
            get { return (Multiform<TModel>)_builder; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal MultiformBuilder(HtmlHelper helper, TableType type, bool edit, bool canFilter, bool canPage)
        {
            this._builder = new Multiform<TModel>(helper, type, edit, canFilter, canPage);
        }

        #region Builder Methods

        #endregion Builder Methods

        /// Set the html table id.
        public MultiformBuilder<TModel> Id(string tableId)
        {
            this.Builder.SetId(tableId);
            return this;
        }

        /// Set the enumerable list of model objects.
        public MultiformBuilder<TModel> DataSource(IEnumerable<TModel> dataSource, bool autoSortAndPage = false)
        {
            this.Builder.SetDataSource(dataSource, autoSortAndPage);

            return this;
        }

        public MultiformBuilder<TModel> Pager(GenioMVC.ViewModels.TablePagination pager)
        {
            this.Builder.SetPager(pager.PageNumber, pager.NumberOfItems, pager.HasMore, pager.HasTotal, pager.TotalRows);
            return this;
        }

        public MultiformBuilder<TModel> BaseQuery(String query)
        {
            this.Builder.SetQuery(query);
            return this;
        }

        /// Prepares the table to generate links for Ajax requests
        public MultiformBuilder<TModel> AjaxRequest(string ajaxUpdateContainerId)
        {
            this.Builder.SetAjaxRequest(ajaxUpdateContainerId);
            return this;
        }

        /// Set Request Link
        public MultiformBuilder<TModel> RequestLink(string url)
        {
            this.Builder.SetRequestLink(url);
            return this;
        }

        /// Set Insert Link
        public MultiformBuilder<TModel> InsertLink(string url)
        {
            this.Builder.SetInsertLink(url);
            return this;
        }

        /// Set Builder Form
        public MultiformBuilder<TModel> BuilderForm(string form)
        {
            this.Builder.SetBuilderForm(form);
            return this;
        }

        /// Set Permissions
        public MultiformBuilder<TModel> Permissions(bool canInsert = true, bool canEdit = true,
            bool canDuplicate = true, bool canDelete = true)
        {
            this.Builder.SetPermissions(true, canInsert, canEdit, canDuplicate, canDelete);
            return this;
        }

        /// Set Help Form
        public MultiformBuilder<TModel> Form(string helpForm)
        {
            this.Builder.SetForm(helpForm);
            return this;
        }

        /// <summary>
        /// Convert the DbEditBuilder to HTML.
        /// </summary>
        public MvcHtmlString ToHtml()
        {
            return new MultiformRenderer<TModel>(this.Builder).ToHtml();
        }
    }
}