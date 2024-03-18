using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace GenioMVC.Helpers.Table.Columns
{
    /// <summary>
    /// Properties and methods used by the consumer to configure the TableColumn.
    /// </summary>
    public interface ITableColumn<TModel> where TModel : class
    {
        ITableColumn<TModel> Title(string title);
        ITableColumn<TModel> Format(string format);
        ITableColumn<TModel> Field(string field, string array = null);
        ITableColumn<TModel> Size(int size);
        ITableColumn<TModel> Hidden();
        ITableColumn<TModel> UsedForFilter(bool columnUsedForFilter = true);
        ITableColumn<TModel> Document(Func<TModel, string> url);
        ITableColumn<TModel> DistinctValues(SelectList vals);
        ITableColumn<TModel> AddHtmlAttribute(string key, string value, bool replaceExistent = false);
        ITableColumn<TModel> AddCssClass(string className, int order = -1, bool replaceExistent = false);
        ITableColumn<TModel> AddInlineStyle(string key, string value, bool replaceExistent = false);
        ITableColumn<TModel> Form(string form, string area, Expression<Func<TModel, string>> key, bool NewTab = false, bool isPopUp = false);
        ITableColumn<TModel> BackgroundColourOnCondition(Expression<Func<TModel, string>> expression);
        ITableColumn<TModel> ForegroundColourOnCondition(Expression<Func<TModel, string>> expression);
        ITableColumn<TModel> SetAggregationType(Helpers.ColumnAggregationType autoSumType);
    }
}