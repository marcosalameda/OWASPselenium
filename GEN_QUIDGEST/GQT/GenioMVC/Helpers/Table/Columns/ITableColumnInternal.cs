using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace GenioMVC.Helpers.Table.Columns
{
    /// <summary>
    /// Type of column
    /// </summary>
    public enum ColumnDataType
    {
        Unknown,
        Text,
        Date,
        Numeric,
        Currency,
        Boolean,
        Array,
        Geographic,
        Document,
        Action,
        Checkbox,
        Image,
        HyperLink,
        Password
    }

    /// <summary>
    /// Properties and methods used within the TableBuilder class.
    /// </summary>
    public interface ITableColumnInternal<TModel> where TModel : class
    {
        string ColumnTitle { get; set; }
        
        string ColumnFormat { get; set; }
        int ColumnSize { get; set; }
        bool ColumnVisible { get; set; }
        bool ColumnUsedForFilter { get; set; }
        string ColumnField { get; set; }
        string ColumnArray { get; set; }
		string ColumnForm { get; set; }
        string ColumnArea { get; set; }
        bool ColumnNewTab { get; set; }
		bool ColumnFormIsPopUp { get; set; }
        Func<TModel, string> DocumentUrl { get; set; }

        Type ColumnType { get; set; } //<--- REMOVE THIS

        ColumnDataType DataType { get; }

        bool IsDocument { get; set; } //<--- REMOVE THIS

        bool IsActionsColumn { get; set; }//<--- REMOVE THIS
        bool IsCheckListColumn { get; set; }//<--- REMOVE THIS

        SelectList Distincts { get; set; }
		Func<TModel, string> ColumnFormKey { get; set; }

        Dictionary<string, string> ColumnHtmlAttributes { get; }
        List<string> ColumnCssClasses { get;  }
        Dictionary<string, string> ColumnInlineCssStyles { get;  }

        Expression LambdaExpression { get; }
		Func<dynamic, object> FormatExpression { get; }

        Attribute CustomAttribute { get; }

        string Evaluate(TModel model);

        string EvaluateKey(TModel model);
        System.Web.WebPages.HelperResult EvaluateFormat(HtmlHelper helper, dynamic arg);

        ITableColumn<TModel> AddHtmlAttribute(string key, string value, bool replaceExistent = false);
        ITableColumn<TModel> AddCssClass(string className, int order = -1, bool replaceExistent = false);
        ITableColumn<TModel> AddInlineStyle(string key, string value, bool replaceExistent = false);
        ITableColumn<TModel> Document(Func<TModel, string> url);

        Func<TModel, string> CompiledBackgroundColorExpression { get; set; }
        Func<TModel, string> CompiledForegroundColorExpression { get; set; }

        Helpers.ColumnAggregationType AggregationType { get; set; }
    }
}