using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using GenioMVC.Helpers.Table.Utils;

namespace GenioMVC.Helpers.Table.Columns
{



    /// <summary>
    /// Represents a column in a table.
    /// </summary>
    /// <typeparam name="TModel">Class that is rendered in a table.</typeparam>
    /// <typeparam name="TProperty">Class property that is rendered in the column.</typeparam>
    public class TableColumn<TModel, TProperty> : ITableColumn<TModel>, ITableColumnInternal<TModel> where TModel : class
    {

        /// <summary>
        /// Column title to display in the table.
        /// </summary>
        public string ColumnTitle { get; set; }
        public string ColumnFormat { get; set; }
        public int ColumnSize { get; set; }
        public bool ColumnVisible { get; set; }
        public bool ColumnUsedForFilter { get; set; }
        public string ColumnField { get; set; }
        public string ColumnArray { get; set; }
        public Type ColumnType { get; set; } //<---- THIS NEEDS TO BE REMOVED. Replaced by ColumnDataType

        public ColumnDataType DataType { get; set; }

        public bool IsDocument { get; set; }//<--- REMOVE THIS
        public Func<TModel, string> DocumentUrl { get; set; }
        public string ColumnForm { get; set; }
        public string ColumnArea { get; set; }
        public bool ColumnNewTab { get; set; }
        public bool ColumnFormIsPopUp { get; set; }
		
        public bool IsActionsColumn { get; set; }//<--- REMOVE THIS
        public bool IsCheckListColumn { get; set; }//<--- REMOVE THIS

        /// <summary>
        /// List of distinct values for this column
        /// </summary>
        public SelectList Distincts { get; set; }

        public Dictionary<string, string> ColumnHtmlAttributes { get; protected set; }
        public List<string> ColumnCssClasses { get; protected set; }
        public Dictionary<string, string> ColumnInlineCssStyles { get; protected set; }
		public Func<TModel, string> ColumnFormKey { get; set; }

        protected Expression<Func<TModel, TProperty>> _lambdaExpression;
        public Expression LambdaExpression { get { return _lambdaExpression; } }

        /// Compiled lambda expression to get the property value from a model object.
        public Func<TModel, TProperty> CompiledExpression { get; protected set; }
        protected ModelMetadataProvider _metadataProvider;
		protected Func<dynamic, object> _formatExpression;
        public Func<dynamic, object> FormatExpression { get { return _formatExpression; } }

        protected Attribute customAttribute;
        protected System.Globalization.CultureInfo customCulture;

        public Attribute CustomAttribute { get { return customAttribute; } }

        public Func<TModel, string> CompiledBackgroundColorExpression { get; set; }
        public Func<TModel, string> CompiledForegroundColorExpression { get; set; }

        public Helpers.ColumnAggregationType AggregationType { get; set; }

        /// Constructor.
        /// <param name="expression">Lambda expression identifying a property to be rendered.</param>
        public TableColumn(Expression<Func<TModel, TProperty>> expression)
        {
            this._metadataProvider = ModelMetadataProviders.Current;
            this._lambdaExpression = expression;
            this.DataType = ColumnDataType.Unknown;

            if (expression != null)
            {
                MemberExpression memberExpression = (expression.Body as MemberExpression);

                string propertyName = memberExpression == null ? "" : memberExpression.Member.Name;
                this.ColumnTitle = Regex.Replace(propertyName, "([a-z])([A-Z])", "$1 $2");
                this.CompiledExpression = expression.Compile();
                this.ColumnType = expression.ReturnType;
                this.ColumnField = propertyName;
                this.DataType = ParseExpressionDataType();
            }
            this.ColumnSize = 1;
            
            this.ColumnVisible = true;
            this.ColumnUsedForFilter = true;

            this.ColumnCssClasses = new List<string>();
            this.ColumnHtmlAttributes = new Dictionary<string, string>();
            this.ColumnInlineCssStyles = new Dictionary<string, string>();

            this.IsActionsColumn = false;
        }

        /// <summary>
        /// Parses the expression to enumerate the type of column data this should be
        /// </summary>
        /// <returns>The type of column data</returns>
        private ColumnDataType ParseExpressionDataType()
        {
            //If the expression leads to a model, try to use the model attributes to tipify this column
            MemberInfo member = HtmlHelpers.FindFirstPropetyInfoMember(this.LambdaExpression);
            if(member != null)
            {
                if (Attribute.IsDefined(member, typeof(DateAttribute)))
                {
                    customAttribute = Attribute.GetCustomAttribute(member, typeof(DateAttribute));
                    return ColumnDataType.Date;
                }
                if (Attribute.IsDefined(member, typeof(CurrencyAttribute)))
                {
                    customAttribute = Attribute.GetCustomAttribute(member, typeof(CurrencyAttribute));
                    CurrencyAttribute currency = (CurrencyAttribute)customAttribute;
                    customCulture = currency.GetCurrencyWithCurrentCulture(HtmlHelpers.GetNumericCulture());
                    return ColumnDataType.Currency;
                }
                if (Attribute.IsDefined(member, typeof(NumericAttribute)))
                {
                    customAttribute = Attribute.GetCustomAttribute(member, typeof(NumericAttribute));
                    customCulture = HtmlHelpers.GetNumericCulture();
                    return ColumnDataType.Numeric;
                }
                if (Attribute.IsDefined(member, typeof(GeographicAttribute)))
                {
                    customAttribute = Attribute.GetCustomAttribute(member, typeof(GeographicAttribute));
                    return ColumnDataType.Geographic;
                }
                if (Attribute.IsDefined(member, typeof(HyperLinkAttribute)))
                {
                    customAttribute = Attribute.GetCustomAttribute(member, typeof(HyperLinkAttribute));
                    return ColumnDataType.HyperLink;
                }
                if (Attribute.IsDefined(member, typeof(System.ComponentModel.DataAnnotations.DataTypeAttribute)))
                {
                    customAttribute = Attribute.GetCustomAttribute(member, typeof(System.ComponentModel.DataAnnotations.DataTypeAttribute));
                    if(customAttribute != null && (customAttribute as System.ComponentModel.DataAnnotations.DataTypeAttribute)?.DataType == System.ComponentModel.DataAnnotations.DataType.Password)
                        return ColumnDataType.Password;
                }
            }

            if (this._lambdaExpression.ReturnType == typeof(String))
                return ColumnDataType.Text;
            if (this._lambdaExpression.ReturnType == typeof(decimal?))
                return ColumnDataType.Numeric;
            if (this._lambdaExpression.ReturnType == typeof(DateTime?))
                return ColumnDataType.Date;
            if (this._lambdaExpression.ReturnType == typeof(Boolean))
                return ColumnDataType.Boolean;
            if (this._lambdaExpression.ReturnType == typeof(SelectList))
                return ColumnDataType.Array;
            if (this._lambdaExpression.ReturnType == typeof(byte[]))
                return ColumnDataType.Image;
        

            return ColumnDataType.Unknown;
        }

        public TableColumn(Func<dynamic, object> format)
        {
            this._metadataProvider = ModelMetadataProviders.Current;
            this._lambdaExpression = null;

            this._formatExpression = format;
            this.ColumnSize = 1;

            this.ColumnVisible = true;
            this.ColumnUsedForFilter = true;

            this.ColumnCssClasses = new List<string>();
            this.ColumnHtmlAttributes = new Dictionary<string, string>();
            this.ColumnInlineCssStyles = new Dictionary<string, string>();

            this.IsActionsColumn = false;

            this.DataType = ColumnDataType.Unknown;
        }

        public TableColumn(bool actionsColumn = false, bool checkListColumn = false)
        {
            this.ColumnSize = 1;
            this.ColumnUsedForFilter = true;

            this.ColumnCssClasses = new List<string>();
            this.ColumnHtmlAttributes = new Dictionary<string, string>();
            this.ColumnInlineCssStyles = new Dictionary<string, string>();

            if (actionsColumn)
            {
                this.ColumnTitle = TableString.Actions.ToString();
                this.ColumnVisible = actionsColumn;
                this.IsActionsColumn = actionsColumn;

                this.DataType = ColumnDataType.Action;
            }
            else if (checkListColumn)
            {
                this.ColumnTitle = String.Empty;
                this.ColumnVisible = checkListColumn;
                this.IsCheckListColumn = checkListColumn;

                this.DataType = ColumnDataType.Checkbox;
            }
        }

        /// Set the title for the column.
        public ITableColumn<TModel> Title(string title)
        {
            this.ColumnTitle = title;
            return this;
        }

        public ITableColumn<TModel> Format(string format)
        {
            this.ColumnFormat = format;
            return this;
        }

        /// Set the field name for the column.
        public ITableColumn<TModel> Field(string field, string array = null)
        {
            this.ColumnField = field;
            this.ColumnArray = array;
            return this;
        }

        /// Set the size for the column.
        public ITableColumn<TModel> Size(int size)
        {
            this.ColumnSize = size;
            return this;
        }

        /// Set visibility hidden for the column.
        public ITableColumn<TModel> Hidden()
        {
            this.ColumnVisible = false;
            return this;
        }

        /// Column used for filter.
        public ITableColumn<TModel> UsedForFilter(bool columnUsedForFilter = true)
        {
            this.ColumnUsedForFilter = columnUsedForFilter;
            return this;
        }

        /// Hides the column from displaying.
        public ITableColumn<TModel> Document(Func<TModel, string> url)
        {
            this.IsDocument = true;
            this.DataType = ColumnDataType.Document;
            this.DocumentUrl = url;
            return this;
        }

        /// Sets the distinct values list for this column
        public ITableColumn<TModel> DistinctValues(SelectList vals)
        {
            this.Distincts = vals;
            return this;
        }

        public ITableColumn<TModel> AddHtmlAttribute(string key, string value, bool replaceExistent = false)
        {
            if ((this.ColumnHtmlAttributes.ContainsKey(key) && replaceExistent) || !this.ColumnHtmlAttributes.ContainsKey(key))
            {
                if ((this.ColumnHtmlAttributes.ContainsKey(key) && replaceExistent))
                    this.ColumnHtmlAttributes.Remove(key);

                this.ColumnHtmlAttributes.Add(key, value);
            }
            return this;
        }

        public ITableColumn<TModel> AddCssClass(string className, int order = -1, bool replaceExistent = false)
        {
            if ((this.ColumnCssClasses.Contains(className) && replaceExistent) || !this.ColumnCssClasses.Contains(className))
            {
                if ((this.ColumnCssClasses.Contains(className) && replaceExistent))
                    this.ColumnCssClasses.Remove(className);

                if (order == -1)
                    this.ColumnCssClasses.Add(className);
                else if (order > 0)
                    this.ColumnCssClasses.Insert(order - 1, className);
            }
            return this;
        }

        public ITableColumn<TModel> AddInlineStyle(string key, string value, bool replaceExistent = false)
        {
            if ((this.ColumnInlineCssStyles.ContainsKey(key) && replaceExistent) || !this.ColumnInlineCssStyles.ContainsKey(key))
            {
                if ((this.ColumnInlineCssStyles.ContainsKey(key) && replaceExistent))
                    this.ColumnInlineCssStyles.Remove(key);

                this.ColumnInlineCssStyles.Add(key, value);
            }
            return this;
        }


        /// <summary>
        /// Get the property value from a model object.
        /// </summary>
        /// <param name="model">Model to get the property value from.</param>
        /// <returns>Property value from the model.</returns>
        public string Evaluate(TModel model)
        {
            //Evaluate the expression using the precompiled version
            object result = CompiledExpression(model);

            //Format the expression according to the column type
            switch(DataType)
            {
                case ColumnDataType.Image:
                                     
                    result = HtmlHelpers.ImageSlideGrid((byte[])result);
                    break;
                case ColumnDataType.Numeric:
                    NumericAttribute numeric = (NumericAttribute)customAttribute;
                    result = HtmlHelpers.FormatNumeric((decimal)result, numeric.Decimals, customCulture);
                    break;

                case ColumnDataType.Currency:
                    CurrencyAttribute currency = (CurrencyAttribute)customAttribute;
                    result = HtmlHelpers.FormatCurrency((decimal)result, currency.GetCurrencyWithCurrentCulture(customCulture.Clone() as System.Globalization.CultureInfo));
                    break;

                case ColumnDataType.Date:
                    DateAttribute dateattr = (DateAttribute)customAttribute;                    
                    if (result.Equals(DateTime.MinValue))
                        result = "";
                    else
                        result = HtmlHelpers.FormatDateValue(dateattr.Type, result);
                    break;

                case ColumnDataType.Array:
                    SelectList selectList = (SelectList)result;

                    string selectedText = string.Empty;

                    if (selectList.SelectedValue.GetType().Equals(typeof(String)))
                        (selectList.Items as Dictionary<string, string>).TryGetValue((string)selectList.SelectedValue, out selectedText);
                    else if (selectList.SelectedValue.GetType().Equals(typeof(int)))
                        (selectList.Items as Dictionary<int, string>).TryGetValue((int)selectList.SelectedValue, out selectedText);
                    else if (selectList.SelectedValue.GetType().Equals(typeof(decimal)))
                        (selectList.Items as Dictionary<decimal, string>).TryGetValue((decimal)selectList.SelectedValue, out selectedText);

                    if (String.IsNullOrEmpty(selectedText))
                        result = string.Empty;
                    else
                    {
                        result = GenioMVC.Helpers.Helpers.GetTextFromResources(selectedText);
                        //JGF 2020.11.25 - This validation is needed for dynamic arrays, where the text won't come from resources
                        if (String.IsNullOrEmpty((string)result))
                        {
                            result = selectedText;
                        }
                    }
                    break;
                case ColumnDataType.Password:
                    result = string.Empty;
                    break;
            }

            //TODO: Review the usage of ColumnFormat, the code above should have already transformed the value into a correctly formatted string
            // Is ColumnFormat mutually exclusive with the usage of LambdaExpression
            if (result != null && !string.IsNullOrEmpty(this.ColumnFormat))
                return String.Format(this.ColumnFormat, result);
            else if (result != null)
                return result.ToString();
            else
                return string.Empty;
        }

        /// <summary>
        /// Get the property value.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="format"></param>
        /// <param name="arg"></param>
        /// <returns></returns>
        public System.Web.WebPages.HelperResult EvaluateFormat(HtmlHelper helper, dynamic arg)
        {
            var result = this.FormatExpression(arg);
            return new System.Web.WebPages.HelperResult(tw =>
            {
                var helperResult = result as System.Web.WebPages.HelperResult;
                if (helperResult != null)
                {
                    helperResult.WriteTo(tw);
                    return;
                }
                IHtmlString htmlString = result as IHtmlString;
                if (htmlString != null)
                {
                    tw.Write(htmlString);
                    return;
                }
                if (result != null)
                {
                    tw.Write(HttpUtility.HtmlEncode(result));
                }
            });
        }
		
		/// <summary>
        /// Set form to Column
        /// </summary>
        /// <param name="form">Form for the column.</param>
        /// <param name="area">Area for the column.</param>
        /// <param name="expression">Expression for the key</param>
        /// <param name="NewTab">Indicates if it will open on a new tab</param>
        /// <returns>Instance of a TableColumn.</returns>
        public ITableColumn<TModel> Form(string form, string area, Expression<Func<TModel, string>> expression, bool NewTab = false, bool isPopUp = false)
        {
            this.ColumnForm = form;
            this.ColumnArea = area;
            this.ColumnFormKey = expression.Compile();
            this.ColumnNewTab = NewTab;
            this.ColumnFormIsPopUp = isPopUp;
            return this;
        }

        public ITableColumn<TModel> BackgroundColourOnCondition(Expression<Func<TModel, string>> expression)
        {
            this.CompiledBackgroundColorExpression = expression.Compile();
            return this;
        }

        public ITableColumn<TModel> ForegroundColourOnCondition(Expression<Func<TModel, string>> expression)
        {
            this.CompiledForegroundColorExpression = expression.Compile();
            return this;
        }

        public ITableColumn<TModel> SetAggregationType(Helpers.ColumnAggregationType autoSumType)
        {
            this.AggregationType = autoSumType;
            return this;
        }

		public string EvaluateKey(TModel model)
        {
            var result = this.ColumnFormKey(model);
            if (result == null)
                return string.Empty;
            return result.ToString();
        }
    }
}