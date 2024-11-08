using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using GenioMVC.Helpers.Table.Builder;

namespace GenioMVC.Helpers.Table.Columns
{
    /// <summary>
    /// Create instances of TableColumns.
    /// </summary>
    /// <typeparam name="TModel">Type of model to render in the table.</typeparam>
    public class ColumnBuilder<TModel> where TModel : class
    {
        public Table<TModel> Builder { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="tableBuilder">Instance of a TableBuilder.</param>
        public ColumnBuilder(Table<TModel> builder)
        {
            Builder = builder;
        }

        /// <summary>
        /// Add lambda expressions to the TableBuilder.
        /// </summary>
        /// <typeparam name="TProperty">Class property that is rendered in the column.</typeparam>
        /// <param name="expression">Lambda expression identifying a property to be rendered.</param>
        /// <returns>An instance of TableColumn.</returns>
        public ITableColumn<TModel> Expression<TProperty>(Expression<Func<TModel, TProperty>> expression, bool key = false)
        {
            return Builder.AddColumn(expression, key);
        }

        /// <summary>
        /// Add format function to the TableBuilder.
        /// </summary>
        /// <typeparam name="TProperty">Class property that is rendered in the column.</typeparam>
        /// <param name="expression">Lambda expression identifying a property to be rendered.</param>
        /// <returns>An instance of TableColumn.</returns>
        public ITableColumn<TModel> Format<TProperty>(Func<dynamic, object> format, bool key = false)
        {
            return Builder.AddColumn<TProperty>(format, key);
        }
    }
}