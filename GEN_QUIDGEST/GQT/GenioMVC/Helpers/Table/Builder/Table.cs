using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Helpers.Table.Renderer;
using GenioMVC.Helpers.Table.Pagination;
using GenioMVC.Helpers.Table.Sorting;
using GenioMVC.Helpers.Table.Utils;

namespace GenioMVC.Helpers.Table.Builder
{
    public class Table<TModel> where TModel : class
    {
        public HtmlHelper HtmlHelper { get; protected set; }
        public HttpRequest HttpRequest { get; protected set; }
        public HttpContext HttpContext { get; protected set; }

        private Models.Navigation.NavigationContext navigation;
        /// <summary>
        /// Accessor for the current navigation context
        /// </summary>
        public Models.Navigation.NavigationContext Navigation
        {
            get
            {
                if(navigation == null)
                {
                    HttpRequestBase requestBase = new HttpRequestWrapper(HttpContext.Request);
                    HttpSessionStateBase sessionBase = new HttpSessionStateWrapper(HttpContext.Session);
                    navigation = Models.Navigation.CurrentNavigation.getNavigation(requestBase, HttpContext.Request.RequestContext.RouteData, sessionBase);
                }
                return navigation;
            }
        }

        public bool IsInEditMode { get; protected set; }
        public TablePermissions Permissions { get; protected set; }

        public List<string> TableCssClass { get; protected set; }
        public String TableId { get; protected set; }
        public TableType TableType { get; protected set; }
        public IEnumerable<TModel> Data { get; protected set; }
        public ITableColumnInternal<TModel> TableKey { get; protected set; }

        public bool hasPagination { get; protected set; }
        public TablePager Pager { get; protected set; }
        public bool hasSorting { get; protected set; }
        public bool hasCounter { get; protected set; }
		public bool hasFilters { get; protected set; }
        public TableSorter DefaultSorter { get; protected set; }
        public TableSorter Sorter { get; protected set; }
        public string Query { get; protected set; }
        public string requestsLink { get; protected set; }
        public bool useAjax { get; protected set; }
        public string ajaxUpdateContainerId { get; protected set; }
        public Expression<Func<TModel, string>> BackgroundColourCondition { get; protected set; }
        public Expression<Func<TModel, string>> ForegroundColourCondition { get; protected set; }
        public Dictionary<string, string> additionalHtmlAttributes { get; protected set; }
        /// <summary>
        /// list of slot report read from the database
        /// </summary>
        public Dictionary<string, List<object>> slotReports { get; protected set; }
        public string FocusOnRecord { get; set; }

        public Table() { }

        public Table(HtmlHelper helper, TableType tableType, bool edit, bool canPage, bool canSort, bool countRec)
        {
            this.HtmlHelper = helper;
            this.TableType = tableType;
            this.Data = null;

            this.hasPagination = canPage;
            this.Pager = new TablePager();
            this.hasSorting = canSort;
            this.Sorter = new TableSorter();
            this.DefaultSorter = new TableSorter();

            this.tableLimits = new List<Limit>();

            this.TableColumns = new List<ITableColumnInternal<TModel>>();
			this.userTableColumns = new List<ITableColumnInternal<TModel>>();
			
            this.TableCssClass = new List<string>();

			this.hasCounter = countRec;
            this.IsInEditMode = edit;
			
			this.hasFilters = false;

            // set defaults
            //this.requestsLink = HttpContext.Current.Request.Path;
            // MH (14/02/2017) - Durante implementação dos menus de Pica-Entradas, foi preciso de renderizar duas ações diferentes na mesma pagina.
            System.Web.Routing.RouteValueDictionary rvd = helper.ViewContext.RouteData.Values;
            rvd.Remove("newMenu"); rvd.Remove("bc");
            this.requestsLink = new UrlHelper(helper.ViewContext.RequestContext).RouteUrl(rvd);
            this.useAjax = false;
            this.HttpRequest = HttpContext.Current.Request;
            this.HttpContext = HttpContext.Current;
        }

        /// Set the enumerable list of model objects.
        public void SetDataSource(IEnumerable<TModel> dataSource, bool autoSortAndPage = false)
        {
            this.Data = dataSource;

            if (autoSortAndPage)
            {
                this.Sorter.UseInternalSorting();
                this.DefaultSorter.UseInternalSorting();

                this.Pager.UseInternalPagination();
            }
        }

        /// Set the html table id.
        public void SetId(string tableId)
        {
            this.TableId = tableId;
        }

        /// Prepares the table to generate links for Ajax requests
        public void SetAjaxRequest(string ajaxUpdateContainerId)
        {
            this.useAjax = true;
            this.ajaxUpdateContainerId = ajaxUpdateContainerId;
        }

        /// Set default sort column
        public void SetDefaultSort(string column, SortDirection direction = null)
        {
            this.DefaultSorter.Column = column;
            this.DefaultSorter.Direction = direction ?? SortDirection.Ascending;
        }

        /// Set current sort properties of table
        public void SetSort(string column, SortDirection direction = null)
        {
            this.Sorter = new TableSorter(column, direction ?? SortDirection.Ascending);
        }

        /// Set current pager properties of table
        public void SetPager(int page, int itemsPerPage, bool hasMore, bool hasTotal, int totalItems)
        {
            this.Pager = new TablePager(page, itemsPerPage, hasMore, hasTotal, totalItems);
        }

		/// Sets the query for the search box
		public void SetQuery(string query)
        {
            this.Query = query;
        }

        /// Sets the condition for the background colour
        public void SetBackgroundColourOnCondition(Expression<Func<TModel, string>> expression)
        {
            this.BackgroundColourCondition = expression;
        }

        /// Sets the condition for the foreground colour
        public void SetForegroundColourOnCondition(Expression<Func<TModel, string>> expression)
        {
            this.ForegroundColourCondition = expression;
        }

        /// Set the adictional Html Attributes
        public void AddHtmlAttributes(object htmlAttributes)
        {
            this.additionalHtmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes).ToDictionary(p=>p.Key, p=>Convert.ToString(p.Value));
        }

        /// Set the slot report lists
        public void SetSlotReports(Dictionary<string, List<object>> slots)
        {
            this.slotReports = slots; 
        }

        /// Set new Table Type
        public bool SetNewTableType(TableType newType)
        {
            switch(newType)
            {
                case TableType.CheckList:
                //case TableType.CheckListLimited:
                case TableType.DBedit:
                //case TableType.DBeditMultipleSelection:
                //case TableType.DBeditNN:
                //case TableType.DBeditQuery:

                case TableType.List:
				case TableType.GridTableList:
                case TableType.SearchList:
                //case TableType.ListUnfiltered:
                    this.TableType = newType;
                    return true;

                default:
                    return false;
            }
        }

        /// Focus the table on the specific record
        public void SetFocus(string id)
        {
            this.FocusOnRecord = id;
        }

        #region Limits
        /// List of table limits filtering the table.
        internal List<Limit> tableLimits { get; set; }
        #endregion

        #region Columns
        /// List of table columns to be rendered in the table.
        internal IList<ITableColumnInternal<TModel>> TableColumns { get; set; }

		//List of table columns as set by user
		internal IList<ITableColumnInternal<TModel>> userTableColumns { get; set; }
		
        /// Add an lambda expression as a TableColumn.
        internal ITableColumn<TModel> AddColumn<TProperty>(Expression<Func<TModel, TProperty>> expression, bool isTableKey)
        {
            TableColumn<TModel, TProperty> column = new TableColumn<TModel, TProperty>(expression);

            if (isTableKey)
                this.TableKey = column;

            this.TableColumns.Add(column);
            return column;
        }

        internal ITableColumn<TModel> AddColumn<TProperty>(Func<dynamic, object> format, bool isTableKey)
        {
            TableColumn<TModel, TProperty> column = new TableColumn<TModel, TProperty>(format);

            if (isTableKey)
                this.TableKey = column;

            this.TableColumns.Add(column);
            return column;
        }

        /// Create an instance of the ColumnBuilder to add columns to the table.
        public void SetColumns(Action<ColumnBuilder<TModel>> columnBuilder)
        {
            ColumnBuilder<TModel> builder = new ColumnBuilder<TModel>(this);
            columnBuilder(builder);
        }
        #endregion

        internal virtual void DoInternalActions()
        {
            if (!string.IsNullOrEmpty(this.Sorter.Column) && this.Sorter.InternalSorting)
                this.Sorter.InternalSort(this);
            else if (!string.IsNullOrEmpty(this.DefaultSorter.Column) && this.DefaultSorter.InternalSorting)
                this.DefaultSorter.InternalSort(this);

            if (this.Pager.InternalPagination)
                this.Pager.InternalPaginate(this);
        }

#region Moved from DdEdit builder
        public bool multipleSelection { get; protected set; }
        public bool _DEF_MultipleSelection { get; protected set; }
        
        protected IList<TableAction<TModel>> _tableActions;
        public IList<TableAction<TModel>> TableActions { get { return (_tableActions ?? new List<TableAction<TModel>>()).Where(act => act.LvlAccess).ToList(); } }

        public bool HasTableActions() { return this.TableActions.Any(x => !x.IsFollowUp); }
        public bool HasFollowUpAction() { return this.TableActions.Count(x => x.IsFollowUp) == 1; }
        public bool HasLimits() { return this.tableLimits != null && this.tableLimits.Any(); }
#endregion

    }
}
