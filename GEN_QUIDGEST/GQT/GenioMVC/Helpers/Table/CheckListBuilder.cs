using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Helpers.Table.Renderer;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Builder;

namespace GenioMVC.Helpers.Table
{
    public class CheckListBuilder<TModel> : ICheckListBuilder<TModel> where TModel : class
    {
        public Table<TModel> _builder { get; set; }
        public CheckList<TModel> Builder
        {
            get { return (CheckList<TModel>)_builder; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal CheckListBuilder(HtmlHelper helper, TableType type, bool edit)
        {
            this._builder = new CheckList<TModel>(helper, edit);
            
            this.Builder.TableColumns.Insert(0, new TableColumn<TModel, object>(checkListColumn: true));
        }

        /// Set the enumerable list of model objects.
        public CheckListBuilder<TModel> DataSource(IEnumerable<TModel> dataSource)
        {
            this.Builder.SetDataSource(dataSource, false);

            return this;
        }

        public CheckListBuilder<TModel> Size(string cssClass)
        {
            this.Builder.SetSize(cssClass);
            return this;
        }

        public CheckListBuilder<TModel> Name(string name)
        {
            this.Builder.SetName(name);
            this.Builder.SetId(name);
            return this;
        }

        public CheckListBuilder<TModel> SelectedIds(string[] selectedIds)
        {
            this.Builder.SetSelectedIds(selectedIds);
            return this;
        }

        public CheckListBuilder<TModel> Extended(string name, string cssClass = null)
        {
            this.Builder.SetExtended(name, cssClass);
            return this;
        }

        /// Create an instance of the ColumnBuilder to add columns to the table.
        public CheckListBuilder<TModel> Columns(Action<ColumnBuilder<TModel>> columnBuilder)
        {
            this.Builder.SetColumns(columnBuilder);
            return this;
        }

        public CheckListBuilder<TModel> HtmlAttributes(object htmlAttributes)
        {
            this.Builder.AddHtmlAttributes(htmlAttributes);
            return this;
        }

        public MvcHtmlString ToHtml()
        {
            return new CheckListRenderer<TModel>(this.Builder).ToHtml();
        }
    }
}