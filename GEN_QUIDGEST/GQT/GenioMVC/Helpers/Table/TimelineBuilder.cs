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
    public class TimelineBuilder <TModel> : ITimelineBuilder<TModel> where TModel : class
    {
        public Table<TModel> _builder { get; set; }
        public Timeline<TModel> Builder
        {
            get { return (Timeline<TModel>)_builder; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal TimelineBuilder(HtmlHelper helper, bool edit)
        {
            this._builder = new Timeline<TModel>(helper, edit);
        }

        public TimelineBuilder<TModel> DataSource(IEnumerable<TModel> dataSource)
        {
            this.Builder.SetDataSource(dataSource, false);
            return this;
        }

        public TimelineBuilder<TModel> Name(string name)
        {
            this.Builder.SetName(name);
            this.Builder.SetId(name);
            return this;
        }

        public TimelineBuilder<TModel> SelectedIds(string[] selectedIds)
        {
            this.Builder.SetSelectedIds(selectedIds);
            return this;
        }

        /// Create an instance of the ColumnBuilder to add columns to the table.
        public TimelineBuilder<TModel> Columns(Action<ColumnBuilder<TModel>> columnBuilder)
        {
            this.Builder.SetColumns(columnBuilder);
            return this;
        }

        public TimelineBuilder<TModel> HtmlAttributes(object htmlAttributes)
        {
            this.Builder.AddHtmlAttributes(htmlAttributes);
            return this;
        }

        public MvcHtmlString ToHtml()
        {
            return new TimelineRender<TModel>(this.Builder).ToHtml();
        }

    }
}