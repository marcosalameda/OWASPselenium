using System;
using System.Web.Mvc.Html;
using System.Linq.Expressions;

namespace GenioMVC.Helpers
{

    /// <summary>
    /// Create instances of TreeColumns.
    /// </summary>
    /// <typeparam name="TModel">Type of model to render in the tree.</typeparam>
    /*public class TreeColumnBuilder<TModel> where TModel : class
    {
        public TreeBuilder<TModel> TreeBuilder { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="tableBuilder">Instance of a TreeBuilder.</param>
        public TreeColumnBuilder(TreeBuilder<TModel> treeBuilder)
        {
            TreeBuilder = treeBuilder;
        }

        /// <summary>
        /// Add lambda expressions to the TreeBuilder.
        /// </summary>
        /// <typeparam name="TProperty">Class property that is rendered in the column.</typeparam>
        /// <param name="expression">Lambda expression identifying a property to be rendered.</param>
        /// <returns>An instance of TreeColumn.</returns>
        public ITableColumn<TModel> Expression<TProperty>(Expression<Func<TModel, TProperty>> expression, bool key = false)
        {
            return TreeBuilder.AddColumn(expression, key);
        }
    }*/
}