using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Xml;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web.Routing;
using System.Collections.Specialized;
using System.Dynamic;
using RB = Microsoft.CSharp.RuntimeBinder;
using System.Text;
using System.Web.Helpers;
using System.Globalization;
using System.Web.WebPages;
using GenioMVC.ViewModels;

namespace System.Web.Mvc.Html
{
    #region TableColumn

    /// <summary>
    /// Properties and methods used within the TableBuilder class.
    /// </summary>
    public interface ITableColumnInternal<TModel> where TModel : class
    {
        string ColumnTitle { get; set; }
        int ColumnSize { get; set; }
        bool ColumnVisible { get; set; }
        bool ColumnUsedForFilter { get; set; }
        bool ColumnKey { get; set; }
        string ColumnType { get; set; }
        string ColumnField { get; set; }
        string ColumnForm { get; set; }
        string ColumnArea { get; set; }
        string ColumnArray { get; set; }
        bool ColumnNewTab { get; set; }
		bool ColumnFormIsPopUp { get; set; }
        bool TextCentered { get; set; }
		bool IsDocument { get; set; }
        SelectList Distincts { get; set; }
        string Evaluate(TModel model);
        string EvaluateKey(TModel model);
    }

    /// <summary>
    /// Properties and methods used by the consumer to configure the TableColumn.
    /// </summary>
    public interface ITableColumn<TModel> where TModel : class
    {
        ITableColumn<TModel> Title(string title);
        ITableColumn<TModel> Field(string field, string array = null);
        ITableColumn<TModel> Size(int columnsize);
        ITableColumn<TModel> CenterText();
		ITableColumn<TModel> Document();
        ITableColumn<TModel> Form(string form, string area, Expression<Func<TModel, string>> key, bool NewTab = false, bool isPopUp = false);
        ITableColumn<TModel> Hidden();
        ITableColumn<TModel> Key();
        ITableColumn<TModel> DistinctValues(SelectList vals);
    }

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

        /// <summary>
        /// Column visibility in the table.
        /// </summary>
        public bool ColumnVisible { get; set; }

        /// <summary>
        /// Column used for filter
        /// </summary>
        public bool ColumnUsedForFilter { get; set; }

        /// <summary>
        /// Column is Key in the table.
        /// </summary>
        public bool ColumnKey { get; set; }

        /// <summary>
        /// Column type.
        /// </summary>
        public string ColumnType { get; set; }

        /// <summary>
        /// Column field
        /// </summary>
        public string ColumnField { get; set; }

		/// <summary>
        /// Column is a document for download in the table.
        /// </summary>
        public bool IsDocument { get; set; }
		
        /// <summary>
        /// Form to Open
        /// </summary>
        public string ColumnForm { get; set; }

        /// <summary>
        /// Area of Form to Open
        /// </summary>
        public string ColumnArea { get; set; }

        /// <summary>
        /// Open new tab when open column form
        /// </summary>
        public bool ColumnNewTab { get; set; }

        public bool ColumnFormIsPopUp { get; set; }

        /// <summary>
        /// The array associated with the column
        /// </summary>
        public string ColumnArray { get; set; }
        /// <summary>
        /// The column size
        /// </summary>
        public int ColumnSize { get; set; }

        /// <summary>
        /// Centers the text
        /// </summary>
        public bool TextCentered { get; set; }

        /// <summary>
        /// Expression for the key of Form
        /// </summary>
        public Func<TModel, string> ColumnFormKey { get; set; }

        /// <summary>
        /// Compiled lambda expression to get the property value from a model object.
        /// </summary>
        public Func<TModel, TProperty> CompiledExpression { get; set; }

        /// <summary>
        /// Raw lambda expression to get the property value from a model object.
        /// </summary>
        public Expression<Func<TModel, TProperty>> Expression { get; set; }

        /// <summary>
        /// List of distinct values for this column
        /// </summary>
        public SelectList Distincts { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="expression">Lambda expression identifying a property to be rendered.</param>
        public TableColumn(Expression<Func<TModel, TProperty>> expression)
        {
            MemberExpression me = (expression.Body as MemberExpression);
            string propertyName = me == null ? "" : me.Member.Name;
            this.ColumnTitle = Regex.Replace(propertyName, "([a-z])([A-Z])", "$1 $2");
            this.CompiledExpression = expression.Compile();
            this.ColumnVisible = true;
            this.ColumnKey = false;
            this.ColumnType = expression.ReturnType.Name;
            this.ColumnField = propertyName;
            this.Expression = expression;
        }

        /// <summary>
        /// Set the title for the column.
        /// </summary>
        /// <param name="title">Title for the column.</param>
        /// <returns>Instance of a TableColumn.</returns>
        public ITableColumn<TModel> Title(string title)
        {
            this.ColumnTitle = title;
            return this;
        }

        /// <summary>
        /// Set the field name for the column.
        /// </summary>
        /// <param name="field">Field name for the column.</param>
        /// <returns>Instance of a TableColumn.</returns>
        public ITableColumn<TModel> Field(string field, string array = null)
        {
            this.ColumnField = field;
            this.ColumnArray = array;
            return this;
        }

        /// <summary>
        /// Set the column size.
        /// </summary>
        /// <param name="field">Column size.</param>
        /// <returns>Instance of a TableColumn.</returns>
        public ITableColumn<TModel> Size(int columnsize)
        {
            this.ColumnSize = columnsize;
            return this;
        }

		/// <summary>
        /// Hides the column from displaying.
        /// </summary>
        /// <returns>Instance of a TableColumn.</returns>
        public ITableColumn<TModel> Document()
        {
            this.IsDocument = true;
            return this;
        }
		
        /// <summary>
        /// Centers the text
        /// </summary>
        /// <returns>Instance of a TableColumn.</returns>
        public ITableColumn<TModel> CenterText()
        {
            this.TextCentered = true;
            return this;
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

        /// <summary>
        /// Hides the column from displaying.
        /// </summary>
        /// <returns>Instance of a TableColumn.</returns>
        public ITableColumn<TModel> Hidden()
        {
            this.ColumnVisible = false;
            return this;
        }

        /// <summary>
        /// Column is Key of the Table
        /// </summary>
        /// <returns>Instance of a TableColumn.</returns>
        public ITableColumn<TModel> Key()
        {
            this.ColumnKey = true;
            return this;
        }

        /// <summary>
        /// Sets the distinct values list for this column
        /// </summary>
        /// <param name="vals">List of distinct values</param>
        /// <returns>Instance of a TableColumn.</returns>
        public ITableColumn<TModel> DistinctValues(SelectList vals)
        {
            this.Distincts = vals;
            return this;
        }
        public string EvaluateKey(TModel model)
        {
            var result = this.ColumnFormKey(model);
            if (result == null)
                return string.Empty;
            return result.ToString();
        }
		
        /// <summary>
        /// Get the property value from a model object.
        /// </summary>
        /// <param name="model">Model to get the property value from.</param>
        /// <returns>Property value from the modelf.</returns>
        public string Evaluate(TModel model)
        {
            var result = this.CompiledExpression(model);
            if (result == null)
                return string.Empty;

            //ViewDataDictionary<TModel> yea = new ViewDataDictionary<TModel>(new ViewDataDictionary<TModel>() { { "SomeDisplayParameter", true } })
            //{ Model = model };
            //ModelMetadata metadata = ModelMetadata.FromLambdaExpression(this.Expression, yea);

            // Isto não pode ser feito desta forma deve ser usado o modelmetadata da propriedade e daqui usar os custom templates
            switch (result.GetType().Name)
            {
                case "DateTime":
                    DateTime date = result as DateTime? ?? DateTime.MinValue;
                    if (date == DateTime.MinValue)
                        return "";
                    return date.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                case "SelectList":
                    System.Web.Mvc.SelectList sellist = result as System.Web.Mvc.SelectList;
                    string value = null;
                    try
                    {
                        if (sellist.SelectedValue.GetType().Equals(typeof(String)))
                            (sellist.Items as Dictionary<string, string>).TryGetValue(sellist.SelectedValue as string, out value);
                        else if (sellist.Items is Dictionary<int, string>)
                        {
                            (sellist.Items as Dictionary<int, string>).TryGetValue((int)sellist.SelectedValue, out value);
                        }
                        else if ((sellist.Items as Dictionary<decimal, string>) != null)
                        {
                            (sellist.Items as Dictionary<decimal, string>).TryGetValue((decimal)sellist.SelectedValue, out value);
                        }
                        else
                            if (sellist.SelectedValue.GetType().Equals(typeof(Double)))
                                (sellist.Items as Dictionary<string, string>).TryGetValue(sellist.SelectedValue.ToString(), out value);
                    }
                    catch (Exception)
                    {
                        value = null;
                    }
                    if (value == null)
                        value = string.Empty;
                    return sellist.SelectedValue + "_" + GenioMVC.Helpers.Helpers.GetTextFromResources(value);
                default:
                    return result.ToString();
            }
        }

    }

    #endregion TableColumn

    #region ColumnBuilder

    /// <summary>
    /// Create instances of TableColumns.
    /// </summary>
    /// <typeparam name="TModel">Type of model to render in the table.</typeparam>
    public class ColumnBuilder<TModel> where TModel : class
    {
        public TableBuilder<TModel> TableBuilder { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="tableBuilder">Instance of a TableBuilder.</param>
        public ColumnBuilder(TableBuilder<TModel> tableBuilder)
        {
            TableBuilder = tableBuilder;
        }

        /// <summary>
        /// Add lambda expressions to the TableBuilder.
        /// </summary>
        /// <typeparam name="TProperty">Class property that is rendered in the column.</typeparam>
        /// <param name="expression">Lambda expression identifying a property to be rendered.</param>
        /// <returns>An instance of TableColumn.</returns>
        public ITableColumn<TModel> Expression<TProperty>(Expression<Func<TModel, TProperty>> expression, bool key = false)
        {
            return TableBuilder.AddColumn(expression, key);
        }
    }

    #endregion ColumnBuilder

    #region TableBuilder

    /// <summary>
    /// Properties and methods used by the consumer to configure the TableBuilder.
    /// </summary>
    public interface ITableBuilder<TModel> where TModel : class
    {
        TableBuilder<TModel> DataSource(IEnumerable<TModel> dataSource);
        TableBuilder<TModel> Columns(Action<ColumnBuilder<TModel>> columnBuilder);
    }

    /// <summary>
    /// Build a table based on an enumerable list of model objects.
    /// </summary>
    /// <typeparam name="TModel">Type of model to render in the table.</typeparam>
    public class TableBuilder<TModel> : ITableBuilder<TModel> where TModel : class
    {
        protected HtmlHelper HtmlHelper { get; set; }
        protected GenioMVC.Models.Navigation.NavigationContext navigation;
        /// <summary>
        /// Accessor for the current navigation context
        /// </summary>
        public GenioMVC.Models.Navigation.NavigationContext Navigation
        {
            get
            {
                if (navigation == null)
                {
                    HttpRequestBase requestBase = new HttpRequestWrapper(HttpContext.Current.Request);
                    HttpSessionStateBase sessionBase = new HttpSessionStateWrapper(HttpContext.Current.Session);
                    navigation = GenioMVC.Models.Navigation.CurrentNavigation.getNavigation(requestBase, HttpContext.Current.Request.RequestContext.RouteData, sessionBase);
                }
                return navigation;
            }
        }
        protected IEnumerable<TModel> Data { get; set; }
        protected bool TableIsEditable { get; set; }
        protected TableEditable permissions { get; set; }
        protected PageInfo pager { get; set; }
        protected SortInfo sorter { get; set; }
        protected AjaxRequest ajaxRequest { get; set; }
        protected bool canSort { get; set; }
		protected bool hasFilters { get; set; }
        protected bool tableFilters { get; set; }
        protected bool dbedit { get; set; }
        protected bool checklist { get; set; }
        protected ITableColumnInternal<TModel> Key { get; set; }
        protected string HelpForm { get; set; }
        protected string Controller { get; set; }
        protected string Tab { get; set; }
        protected bool CustomAction { get; set; }
        protected bool AjaxActions { get; set; }
        protected bool hasPagination { get; set; }
        protected bool generateLinksForAjax { get; set; }
        protected IDictionary<string, object> AjaxOptions { get; set; }
        protected string TableId { get; set; }
        protected string DefaultSortColumn { get; set; }
        protected string DefaultSortDirection { get; set; }
        protected string partialView { get; set; }
        protected string checklistName { get; set; }
        protected string[] selectedRows { get; set; }
		public bool AppendToPage { get; private set; }
        public bool HasFollowUp { get; private set; }
        public string FollowUpAction { get; private set; }
        public string FollowUpController { get; private set; }
        public Func<TModel, object> FollowUpRouteValuesFun { get; private set; }
        public IList<TableAction<TModel>> TableActions { get; private set; }

        public string[] SelectedRows
        {
            get
            {
                return selectedRows;
            }
        }

        public string ChecklistName
        {
            get
            {
                return checklistName;
            }
        }

        public string PartialView
        {
            get
            {
                 return partialView;
            }
        }

        public bool GenerateLinksForAjax
        {
            get
            {
                return generateLinksForAjax;
            }
        }


        public bool HasPagination
        {
            get
            {
                return hasPagination;
            }
        }

        public TableEditable GetPermissions 
        {
            get
            {
                return this.permissions;
            }
        }
		
        public string GetController
        {
            get
            {
                return this.Controller;
            }
        }

        public string GetTab
        {
            get
            {
                return this.Tab;
            }
        }

        public object GetAjaxOption(string key)
        {
            return this.AjaxOptions[key];
        }

        public bool IsTableEditable
        {
            get
            {
                return this.TableIsEditable;
            }
        }

        public HtmlHelper GetHtmlHelper { get { return this.HtmlHelper; } }

        public ITableColumnInternal<TModel> GetKey
        {
            get
            {
                return this.Key;
            }

        }

        public bool HasAjaxActions
        {
            get
            {
                return this.AjaxActions;
            }
        }

        public bool HasCustomAction
        {
            get
            {
                return this.CustomAction;
            }
        }

        public string GetHelpForm
        {
            get
            {
                return this.HelpForm;
            }
        }

        public AjaxRequest GetAjaxRequest
        {
            get
            {
                return this.ajaxRequest;
            }
        }

        public SortInfo GetSortInfo
        {
            get
            {
                return this.sorter;
            }
        }

        public bool CanSort
        {
            get
            {
                return this.canSort;
            }
        }

        public bool IsDbedit
        {
            get
            {
                return this.dbedit;
            }
        }

        public bool IsChecklist
        {
            get
            {
                return this.checklist;
            }
        }

        public bool UseTableFilters
        {
            get
            {
                return this.tableFilters;
            }
        }

		public bool HasFilters
        {
            get 
            { 
                return this.hasFilters; 
            }
        }
		
        public string GetTableId
        {
            get
            {
                return this.TableId;
            }
        }

        public IEnumerable<TModel> GetData
        {
            get
            {
                return this.Data;
            }
        }

        public PageInfo GetPageInfo
        {
            get
            {
                return this.pager;
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        internal TableBuilder()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal TableBuilder(HtmlHelper helper, bool canSort, string partialView, bool tableFilters, string tab, bool hasFilters)
        {
            this.TableActions = new List<TableAction<TModel>>();
            this.hasPagination = true;
            this.HtmlHelper = helper;

            this.TableColumns = new List<ITableColumnInternal<TModel>>();

            this.TableIsEditable = false;

            this.HelpForm = "";
            this.Controller = typeof(TModel).Name;
            this.CustomAction = false;

            this.AjaxActions = false;
            this.AjaxOptions = null;

            this.TableId = typeof(TModel).Name.ToLower();
            this.canSort = canSort;
            this.Tab = tab;
            this.partialView = partialView;
            this.tableFilters = tableFilters;
            this.HasFollowUp = false;
			this.hasFilters = hasFilters;
        }

        public TableBuilder<TModel> AddPagination(TablePagination p)
        {
            this.pager = new PageInfo(p.PageNumber, p.NumberOfItems, p.TotalRows);
            return this;
        }

        public TableBuilder<TModel> AddSort(TableSort s)
        {
			if(s != null)
				this.sorter = new SortInfo(s.Column, s.Direction);
			else
				this.sorter = new SortInfo();	
            return this;
        }

        /// <summary>
        /// Sets the table to be a checklist
        /// </summary>
        /// <param name="name">The name for the checkboxes</param>
        /// <returns>Reference to the TableBuilder object.</returns>
        public TableBuilder<TModel> Checklist(string name, string[] selectedIds = null)
        {
            if (selectedIds == null)
                selectedIds = new string[0];
            this.checklist = true;
            this.selectedRows = selectedIds;
            this.checklistName = name;
            return this;
        }

        /// <summary>
        /// Cancels the pagination of the table
        /// </summary>
        /// <returns>Reference to the TableBuilder object.</returns>
        public TableBuilder<TModel> NoPagination()
        {
            this.hasPagination = false;
            this.pager = new PageInfo(1, int.MaxValue, -1);
            return this;
        }

        /// <summary>
        /// Specifies that the table will be used for a dbedit
        /// </summary>
		/// <returns>Reference to the TableBuilder object.</returns>
        public TableBuilder<TModel> DBedit()
        {
            this.dbedit = true;
            return this;
        }

        /// <summary>
        /// Set the enumerable list of model objects.
        /// </summary>
        /// <param name="dataSource">Enumerable list of model objects.</param>
        /// <returns>Reference to the TableBuilder object.</returns>
        public TableBuilder<TModel> DefaultSort(string column, string direction)
        {
            this.DefaultSortColumn = column;
            this.DefaultSortDirection = direction;
            return this;
        }

        /// <summary>
        /// Set the enumerable list of model objects.
        /// </summary>
        /// <param name="dataSource">Enumerable list of model objects.</param>
        /// <returns>Reference to the TableBuilder object.</returns>
        public TableBuilder<TModel> DataSource(IEnumerable<TModel> dataSource)
        {
            this.Data = dataSource;
            return this;
        }

        /// <summary>
        /// List of table columns to be rendered in the table.
        /// </summary>
        internal IList<ITableColumnInternal<TModel>> TableColumns { get; set; }

        /// <summary>
        /// Add an lambda expression as a TableColumn.
        /// </summary>
        /// <typeparam name="TProperty">Model class property to be added as a column.</typeparam>
        /// <param name="expression">Lambda expression identifying a property to be rendered.</param>
        /// <returns>An instance of TableColumn.</returns>
        internal ITableColumn<TModel> AddColumn<TProperty>(Expression<Func<TModel, TProperty>> expression, bool key = false)
        {
            TableColumn<TModel, TProperty> column = new TableColumn<TModel, TProperty>(expression);

            if (key)
                Key = column;

            this.TableColumns.Add(column);
            return column;
        }

        /// <summary>
        /// Create an instance of the ColumnBuilder to add columns to the table.
        /// </summary>
        /// <param name="columnBuilder">Delegate to create an instance of ColumnBuilder.</param>
        /// <returns>An instance of TableBuilder.</returns>
        public TableBuilder<TModel> Columns(Action<ColumnBuilder<TModel>> columnBuilder)
        {
            ColumnBuilder<TModel> builder = new ColumnBuilder<TModel>(this);
            columnBuilder(builder);
            return this;
        }

        /// <summary>
        /// Allows the TableBuilder to be editable.
        /// </summary>
        /// <returns>An instance of TableBuilder having the table defined as editable.</returns>
        public TableBuilder<TModel> Editable(bool insertAccess = true, bool editAccess = true, bool deleteAccess = true, bool duplicateAccess = true)
        {
            this.TableIsEditable = insertAccess || editAccess || deleteAccess || duplicateAccess;
            this.permissions = new TableEditable(insertAccess, editAccess, deleteAccess,duplicateAccess);
            return this;
        }

        /// <summary>
        /// Define a form to be used to support operations on this table
        /// <param name="helpForm">The help form to be used</param>
        /// </summary>
        /// <returns>An instance of TableBuilder having a support form.</returns>
        public TableBuilder<TModel> Form(string helpForm, string controller = null, bool customAction = false)
        {
            this.HelpForm = helpForm;
            if (controller != null) this.Controller = controller;
            this.CustomAction = customAction;
            return this;
        }

		/// <summary>
        /// Adds a following action to the current table
        /// </summary>
        /// <param name="action">the action</param>
        /// <param name="controller">the controller</param>
        /// <param name="routeValuesFun">function that maps the action to an id</param>
        /// <param name="icon">the icon</param>
        /// <param name="title">Text to be seen in button/anchor</param>
        /// <param name="routineName">Routine id</param>
		/// <param name="htmlAtributes">html attributes</param>
        /// <returns>Reference to the TableBuilder object.</returns>
        public TableBuilder<TModel> AddTableAction(string action, string controller, Func<TModel, object> routeValuesFun, string icon, string title, bool isRoutine = false, object htmlAtributes = null, bool bootraspIcon = false)
        {
            TableAction<TModel> ta = new TableAction<TModel>(action, controller, routeValuesFun, icon, bootraspIcon, title, isRoutine, htmlAtributes);
            this.TableActions.Add(ta);
            return this;
        }
		
        /// <summary>
        /// Defines the default follow up action associated with each element in the table.
        /// <param name="actionName">Text to be seen in button/anchor</param>
        /// <param name="actionController">Controller to be call</param>
        /// <param name="action">Action in controller</param>
        /// <param name="newtab">If it opens on a new tab or not (by default no)</param>
        /// </summary>
        /// <returns>An instance of TableBuilder having a support form.</returns>
        public TableBuilder<TModel> SetFollowUp(string action, string controller, Func<TModel, object> routeValuesfun, bool appendToPage = false)
        {
            this.FollowUpAction = action;
            this.FollowUpController = controller;
            this.FollowUpRouteValuesFun = routeValuesfun;
            this.HasFollowUp = true;
			this.AppendToPage = appendToPage;
            return this;
        }

        /// <summary>
        /// Prepares the table renderer to generate links for Ajax requests
        /// <param name="link">The link for the ajax request</param>
        /// <param name="id">The div id where the table is contained</param>
        /// </summary>
        /// <returns>An instance of TableBuilder having a support form.</returns>
        public TableBuilder<TModel> AjaxRequest(string link, string id)
        {
            this.generateLinksForAjax = true;
            this.ajaxRequest = new AjaxRequest(link, id);
            return this;
        }

        /// <summary>
        /// List actions will done through ajax
        /// <param name="ajaxOptions">Options to be used in Ajax</param>
        /// </summary>
        /// <returns>An instance of TableBuilder having a support form.</returns>
        public TableBuilder<TModel> Ajax(object ajaxOptions = null)
        {
            this.AjaxActions = true;
            this.AjaxOptions = new System.Web.Routing.RouteValueDictionary(ajaxOptions);
            return this;
        }

        /// <summary>
        /// Sets the Id of the table
        /// <param name="id">Id to be set</param>
        /// </summary>
        /// <returns>An instance of TableBuilder having an id.</returns>
        public TableBuilder<TModel> Id(string id)
        {
            this.TableId = id;
            return this;
        }

        private TagBuilder MakeIconFormLink(string form, object routeValues, string icon, string text)
        {
            TagBuilder a = new TagBuilder("a");

            a.Attributes.Add("href", (new UrlHelper(HtmlHelper.ViewContext.RequestContext)).Action(form, typeof(TModel).Name, routeValues));

            TagBuilder i = new TagBuilder("i");
            i.AddCssClass(icon);

            a.InnerHtml += i;
            if (!string.IsNullOrEmpty(text))
                a.InnerHtml += " " + text;

            return a;
        }

        public virtual MvcHtmlString ToHtml()
        {
            return new MvcTableRenderer().ToHtml(this);
        }
    }

    #endregion TableBuilder

    #region Info classes and Helpers

    public class TableAction<TModel>
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
		public bool IsRoutine { get; set; }
        public Func<TModel, object> RouteValuesFun { get; private set; }
		public object HtmlAttributes { get; set; }
        public bool IsBootstrapIcon { get; set; }

        public TableAction(string action, string controller, Func<TModel, object> routeValuesFun, string icon, bool isBootstrapIcon, string title, bool isRoutine, object htmlAttributes)
        {
            this.Action = action;
            this.Controller = controller;
            this.RouteValuesFun = routeValuesFun;
            this.Icon = icon;
            this.Title = title;
			this.IsRoutine = isRoutine;
            this.HtmlAttributes = htmlAttributes == null ? new { } : htmlAttributes;
            this.IsBootstrapIcon = isBootstrapIcon || icon.IsEmpty();
        }
    }

    public class AjaxRequest
    {
        public string LoadTableLink { get; set; }
        public string DivId { get; set; }

        public AjaxRequest(string link, string id)
        {
            this.LoadTableLink = link;
            this.DivId = id;
        }
    }

    public class TableEditable
    {
        public bool CanDelete { get; set; }
        public bool CanEdit { get; set; }
        public bool CanInsert { get; set; }
        public bool CanDuplicate { get; set; }

        public TableEditable(bool insert, bool edit, bool delete, bool duplicate)
        {
            CanInsert = insert;
            CanEdit = edit;
            CanDelete = delete;
            CanDuplicate = duplicate;
        }
    }

    public class PageInfo
    {
        public int PageNumber { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalRows { get; set; }

        public PageInfo(int pageNumber, int itemsPerPage, int totalRows)
        {
            PageNumber = pageNumber;
            ItemsPerPage = itemsPerPage;
            TotalRows = totalRows;
        }
    }

    public class SortInfo
    {
        public string Column { get; set; }
        public string Direction { get; set; }

		public SortInfo() { }
		
        public SortInfo(string column, string direction)
        {
            Column = column;
            Direction = direction;
        }

        public bool HasNoInfo() 
        {
            return Column == null || Direction == null;
        }
    }

    #endregion

    #region MvcHtmlTableExtensions

    public static class MvcHtmlTableExtensions
    {
        /// <summary>
        /// Return an instance of a TableBuilder.
        /// </summary>
        /// <typeparam name="TModel">Type of model to render in the table.</typeparam>
        /// <returns>Instance of a TableBuilder.</returns>
        public static ITableBuilder<TModel> TableFor<TModel>(this HtmlHelper helper, bool canSort = false, string partialView = null, bool tableFilters = false, string tab = "", bool hasFilters = false) where TModel : class
        {
            return new TableBuilder<TModel>(helper, canSort, partialView, tableFilters, tab, hasFilters);
        }
    }

    #endregion MvcHtmlTableExtensions
}