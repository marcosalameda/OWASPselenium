using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.Concurrent;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence.GenericQuery;
using Quidgest.Persistence;

namespace GenioMVC.ViewModels
{
    public interface IViewModel
    {
        // Interface Properties
        [Newtonsoft.Json.JsonIgnore]
        bool NestedForm { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        StatusMessage flashMessage { get; set; }

        // Interface Methods
        void setModes(string m);

        StatusMessage CheckPermissions(FormMode mode);

        /// <summary>
        /// Sanitizes the ViewModel content by cleaning HTML fragments and documents from constructs that could lead to XSS attacks and compromise application security.
        /// </summary>
        void SanitizeContent();
    }

    public abstract class ViewModelBase : IViewModel
    {
        /// <summary>
		/// Local access to usercontext to improve compatibility with core version
		/// </summary>
		protected UserContext m_userContext => UserContext.Current;

        /// <summary>
        /// [MH] - [17-08-2015]: temporary bugfix - need be rafactored Identifier of menu
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public string Identifier { get; set; }

        public bool NestedForm { get; set; }

        /// <summary>
        /// [MH] - Added form mode to be used in View manual routines
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public FormMode FormMode
        {
            get
            {
                if (this.Navigation != null && this.Navigation.CurrentLevel != null)
                {
                    if (this.Navigation.CurrentLevel.Level == 0 && this.Navigation.CurrentLevel.CheckEntry("HomePageContainsList"))
                        return FormMode.List;
                    else if (this.Navigation.CurrentLevel.Level == 0 && this.Navigation.CurrentLevel.CheckEntry("DashboardHomePage"))
                        return FormMode.Show;
                    else
                        return this.Navigation.CurrentLevel.FormMode;
                }
                return FormMode.None;
            }
        }

        [Newtonsoft.Json.JsonIgnore]
        public bool IsEditableMode { get { return Helpers.Helpers.IsEditableForm(this.FormMode); } }

        /// <summary>
        /// [JFG] - Added form mode to string to be used in Views
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public string GetFormMode
        {
            get {
                switch (this.FormMode)
                {
                    case FormMode.Edit:
                        return "edit";
                    case FormMode.New:
                        return "new";
                    case FormMode.Delete:
                        return "delete";
                    case FormMode.Duplicate:
                        return "duplicate";
                    case FormMode.Show:
                        return "show";
                    default:
                        return "";
                }
            }
        }

        #region Form modes

        protected string _modes;
        public string GetQSModes() { return _modes; }
        /// <summary>
        /// Set allowed modes for this form
        /// </summary>
        /// <param name="m">data from quary strign (recived with key "m")</param>
        public void setModes(string m)
        {
            _modes = m ?? string.Empty;
        }

        /// <summary>
        /// Check if determined mode is allowed for this form
        /// </summary>
        /// <param name="cFormMode">FormMode to be validated</param>
        /// <returns></returns>
        public bool checkMode(FormMode cFormMode)
        {
            var allowedMode = false;
            if (string.IsNullOrWhiteSpace(_modes)) _modes = string.Empty;
            switch (cFormMode)
            {
                case FormMode.Edit:
                    allowedMode = _modes.Contains("e"); break;
                case FormMode.New:
                    allowedMode = _modes.Contains("i"); break;
                case FormMode.Delete:
                    allowedMode = _modes.Contains("a"); break;
                case FormMode.Duplicate:
                    allowedMode = _modes.Contains("d"); break;
                case FormMode.Show:
                    allowedMode = _modes.Contains("v"); break;
            }

            if (allowedMode)
                allowedMode = CheckVMPermissions(cFormMode);

            if (!allowedMode && this.Navigation != null)
                allowedMode = this.Navigation.CurrentLevel.FormMode == cFormMode;

            return allowedMode;
        }

        [Newtonsoft.Json.JsonIgnore]
        public bool CanEdit { get { return this.checkMode(FormMode.Edit); } }
        [Newtonsoft.Json.JsonIgnore]
        public bool CanInsert { get { return this.checkMode(FormMode.New); } }
        [Newtonsoft.Json.JsonIgnore]
        public bool CanDelete { get { return this.checkMode(FormMode.Delete); } }
        [Newtonsoft.Json.JsonIgnore]
        public bool CanDuplicate { get { return this.checkMode(FormMode.Duplicate); } }
        [Newtonsoft.Json.JsonIgnore]
        public bool CanView { get { return this.checkMode(FormMode.Show); } }

        #endregion

        private Models.Glob _globTable;
        /// <summary>
        /// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas client-side e server-side (alguns)
        /// </summary>
        public virtual Models.Glob TGlob { get { if (_globTable == null) _globTable = Models.Glob.GetGlob(); return _globTable; } }
        public virtual bool ShouldSerializeTGlob () => true;

        #region History
        //MH - refatorização dos historicos
        [Newtonsoft.Json.JsonIgnore]
        public NavigationContext Navigation { get; set; }
        //MH - QPath alternativo to obter Navigation
        protected NavigationContext _navigation;
        /// <summary>
        /// Accessor for the current navigation context
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public NavigationContext _Navigation
        {
            get
            {
                if (_navigation == null)
                {
                    HttpRequestBase requestBase = new HttpRequestWrapper(HttpContext.Current.Request);
                    HttpSessionStateBase sessionBase = new HttpSessionStateWrapper(HttpContext.Current.Session);
                    _navigation = CurrentNavigation.getNavigation(requestBase, HttpContext.Current.Request.RequestContext.RouteData, sessionBase);
                }
                return _navigation;
            }
        }
        #endregion

		//use the full qualified name to prevent problems with tables with name ROLE
        [Newtonsoft.Json.JsonIgnore]
        public CSGenio.framework.Role RoleToShow { get; protected set; }
        [Newtonsoft.Json.JsonIgnore]
        public CSGenio.framework.Role RoleToEdit { get; protected set; }

		//Used by original sorting method. Only returns sorting for 1 column.
        protected ColumnSort GetRequestSort<TModel>(TablePartial<TModel> t, string sortStr, string directionStr, NameValueCollection qs, string area) where TModel: class
        {
            ColumnSort sort = null;

            if (!String.IsNullOrEmpty(qs[sortStr]))
            {
                SortOrder direction = SortOrder.Ascending;
                string dir = (string)qs[directionStr];
                if (!String.IsNullOrEmpty(dir) && dir == "DESC")
                    direction = SortOrder.Descending;
                string column = (string)qs[sortStr];

                string[] args = column.Split(new char[] { '.' });
                Type areaType = null;
                FieldRef fieldRef = null;
                if (args.Count() == 1)
                    areaType = CSGenio.business.Area.GetTypeArea(area);
                else if (args.Count() == 2)
                    areaType = CSGenio.business.Area.GetTypeArea(args[0].ToLower());
                else if (args.Count() > 2)
                    areaType = CSGenio.business.Area.GetTypeArea(args[args.Count() - 2].ToLower());
                if (areaType == null) return null;

                string fieldName = args[args.Count() - 1];
                int index = fieldName.IndexOf("Val");
                fieldName = fieldName.Remove(index,3);

                fieldRef = (FieldRef)((PropertyInfo)areaType.GetMember("Fld" + fieldName).GetValue(0)).GetValue(areaType);
                sort = new ColumnSort(new ColumnReference(fieldRef), direction);

                var areaInfo = (CSGenio.business.AreaInfo)areaType.GetMethod("GetInformation").Invoke(areaType, null);
                var field = areaInfo.DBFields[fieldRef.Field];

                if (field.FieldType == FieldType.IMAGEM_JPEG)
                    return null;

                t.SetSort(column, dir);
            }

            return sort;
        }


		/// <summary>
        /// Gets the database column name from the form field name.
        /// </summary>
		/// <remarks>FOR: MENU LIST SORTING</remarks>
        /// <param name="formFieldName">Field name in form</param>
        /// <returns>Database column name</returns>
		public string GetDBColumnNameFromFormFieldName(string formFieldName)
        {
			int requestIndex = formFieldName.IndexOf("Val");
			formFieldName = formFieldName.Remove(requestIndex,3);
			return formFieldName.ToUpper();
		}

		/// <summary>
        /// Gets the database column name in FieldRef format.
        /// </summary>
		/// <remarks>FOR: MENU LIST SORTING</remarks>
        /// <param name="columnName">Column name</param>
        /// <returns>Database column name</returns>
		public string GetFieldRefColumnName(string columnName)
        {
			columnName = columnName.ToLower();
            return char.ToUpper(columnName[0]) + columnName.Substring(1);
		}

		/// <summary>
        /// Generates and returns a List<ColumnSorts> with all columns to sort by, in order, based on the column clicked and the data structure that represents all sortings for the menu list.
        /// </summary>
		/// <remarks>FOR: MENU LIST SORTING</remarks>
        /// <param name="t">Menu list</param>
        /// <param name="sortStr">Name of columns corresponding control that was clicked</param>
        /// <param name="directionStr">Sort direction of column (ASC or DESC)</param>
        /// <param name="qs">Request values (name-value pairs representing [column, sort]?)</param>
        /// <param name="area">Table/Area name</param>
        /// <param name="allSortOrders">Structure of all sortings for the menu list, grouped by column name</param>
        /// <returns>List of ColumnSorts in the same order the columns are in the sorting for the column clicked.</returns>
		protected List<ColumnSort> GetRequestSorts<TModel>(TablePartial<TModel> t, string sortStr, string directionStr, NameValueCollection qs, string area, Dictionary<String, OrderedDictionary> allSortOrders) where TModel: class
        {
			if (String.IsNullOrEmpty(qs[sortStr]))
				return null;

			List<ColumnSort> allRequestSorts = new List<ColumnSort>();

			//< Get name, sort direction, area of column clicked
			string requestColumn = (string)qs[sortStr];

			string requestDir = (string)qs[directionStr];

			string[] requestArgs = requestColumn.Split(new char[] { '.' });
			string requestFieldName = GetDBColumnNameFromFormFieldName(requestArgs[requestArgs.Count() - 1]);

			string requestArea = area.ToUpper();
			if(requestArgs.Count() > 1)
				requestArea = requestArgs[requestArgs.Count() - 2].ToUpper();

			string requestFieldNameFull = requestArea + "." + requestFieldName;
			//> Get name, sort direction, area of column clicked

			t.SetSort(requestColumn, requestDir);

			//If requested column is not in the sorting dictionary, add a sorting by the requested column only.
			if(!allSortOrders.ContainsKey(requestFieldNameFull))
			{
				OrderedDictionary requestColumnOrder = new OrderedDictionary();
				requestColumnOrder.Add(requestFieldNameFull, "A");
				allSortOrders.Add(requestFieldNameFull, requestColumnOrder);
			}

			//Iterate through OrderedDictionary of column clicked
			foreach(DictionaryEntry sortOrderEntry in allSortOrders[requestFieldNameFull])
			{
				//< Get name, sort direction, area of column in this sorting
				string column = (string)sortOrderEntry.Key;

                string dir = (string)sortOrderEntry.Value;

				//For the column that was clicked, use sort direction passed in
				if (String.Equals(column, requestFieldNameFull))
                    dir = requestDir;

				SortOrder direction = SortOrder.Ascending;
                if (!String.IsNullOrEmpty(dir) && (dir == "DESC" || dir == "D"))
                    direction = SortOrder.Descending;

				//Get area type
                string[] args = column.Split(new char[] { '.' });
                Type areaType = null;
                if (args.Count() == 1)
                    areaType = CSGenio.business.Area.GetTypeArea(area);
                else if (args.Count() > 1)
                    areaType = CSGenio.business.Area.GetTypeArea(args[args.Count() - 2].ToLower());
                if (areaType == null)
					continue;
				//> Get name, sort direction, area of column in this sorting

				//Get column name in FieldRef style
                string fieldName = GetFieldRefColumnName(args[args.Count() - 1]);

				//Check MemberInfo to avoid trying to access undefined members
				MemberInfo[] areaTypeInfo = areaType.GetMember("Fld" + fieldName);
				if(areaTypeInfo == null || areaTypeInfo.Length < 1)
					continue;

				//< Create column reference and check if sortable
                FieldRef fieldRef = (FieldRef)((PropertyInfo)areaType.GetMember("Fld" + fieldName).GetValue(0)).GetValue(areaType);

                var areaInfo = (CSGenio.business.AreaInfo)areaType.GetMethod("GetInformation").Invoke(areaType, null);
                var field = areaInfo.DBFields[fieldRef.Field];

				//Column types that are not sorted
                if (field.FieldType == FieldType.IMAGEM_JPEG)
                    continue;
				//> Create column reference and check if sortable

				allRequestSorts.Add(new ColumnSort(new ColumnReference(fieldRef), direction));
            }

            return allRequestSorts;
        }

        protected bool IsColumnVisible(TableSearchColumn searchColumn, List<CSGenioAlstcol> userColumns)
        {
            // If there is a user column, use the visibility from the user column, otherwise use the TableSearchColumn value
            if (userColumns != null)
            {
                // MH (10/03/2020) - The "Replace('.', '_')" is necessary because the column identifiers in the TableSearchColumn follow the same logic (if I'm not mistaken because of JavaScript).
                var userColumn = userColumns.Find(uc => searchColumn.AreaField.Area == uc.ValTabela && searchColumn.Field == uc.ValCampo.Replace('.', '_'));
                if (userColumn != null)
                    return userColumn.ValVisivel == 1;
                else
                    return searchColumn.Visible;
            }
            else
                return searchColumn.Visible;
        }


	    protected CriteriaSet ProcessSearchFilters<A>(TablePartial<A> Menu, List<TableSearchColumn> SearchColumns, NameValueCollection requestValues, string requesValuesPrefix) where A : class
        {
            //FOR: SEARCH FILTERS
			//Create search filters from JSON data in query parameter
            string SearchFiltersJSON = requestValues["SearchFilters"] ?? "";
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            SearchFilter[] SearchFilters = serializer.Deserialize<SearchFilter[]>(SearchFiltersJSON);

			//Create dictionary of search columns using full names as keys (TABLE.COLUMN)
            Dictionary<string, TableSearchColumn> SearchColumnsDic = new Dictionary<string, TableSearchColumn>();
            foreach(TableSearchColumn tsc in SearchColumns)
            {
                SearchColumnsDic.Add(tsc.AreaField.FullName.ToUpper(), tsc);
            }

            Menu.Filters.QueryField = "q" + requesValuesPrefix.TrimEnd(new char[] { '_' });
            string query = Menu.Filters.Query = Menu.Query = requestValues[Menu.Filters.QueryField] ?? "";

            // TVC - For showing advanced filters after returning from a form (before the filters were lost when opening a form, but were aplied the first time you would return to the main list)
            Navigation?.SetValue("AdvancedFilters", SearchFiltersJSON);

			//For showing query text in search bar when returning to menu list after navigating to a record
			Navigation?.SetValue(Menu.Filters.QueryField, query);

            CriteriaSet search_filters = CriteriaSet.And();
            //Search with filters for each field (previous method)
            if (SearchFilters != null)
            {
                //Iterate search filters
                foreach (SearchFilter sf in SearchFilters)
                {
					//Inactive condition
					if (!sf.Active)
						continue;

                    CriteriaSet conditions = CriteriaSet.Or();

                    //Iterate conditions in search filter
                    foreach (SearchFilterCondition sfc in sf.Conditions)
                    {
                        //Inactive condition
                        if (!sfc.Active)
                            continue;

                        //Active condition
                        TableSearchColumn sc = SearchColumnsDic[sfc.Field];
						Field fieldInfo = CSGenio.business.Area.GetFieldInfo(sc.AreaField);
                        if (sc.FieldType.Equals(typeof(DateTime?)))
                        {
                            //Parse values
							//Values must be an array because the number of values depends on the operation
                            DateTime[] Values = new DateTime[sfc.Values.Length];
                            DateTime parsedValue = new DateTime();
                            int x = 0;
                            foreach (string value in sfc.Values)
                            {
                                if (DateTime.TryParse(value, System.Threading.Thread.CurrentThread.CurrentCulture, DateTimeStyles.None, out parsedValue) && CSGenio.business.GlobalFunctions.emptyD(parsedValue) == 0)
                                    Values[x++] = parsedValue;
                            }

                            //Create criteria based on operator code
                            switch (sfc.Operator)
                            {
                                case "BETW":
                                    if (x < 2)
                                        continue;
                                    CriteriaSet between = CriteriaSet.And();
                                    between.GreaterOrEqual(sc.AreaField, Values[0]);
                                    between.LesserOrEqual(sc.AreaField, Values[1]);
                                    conditions.SubSets.Add(between);
                                    break;
                                case "EQ":
									if (x < 1)
										continue;
									if (fieldInfo.FieldType.Formatting == FieldFormatting.DATAHORA)
                                    {
                                        CriteriaSet eqRange = CriteriaSet.And();
                                        eqRange.GreaterOrEqual(sc.AreaField, Values[0].Date.AddHours(Values[0].Hour).AddMinutes(Values[0].Minute));
                                        eqRange.Lesser(sc.AreaField, Values[0].Date.AddHours(Values[0].Hour).AddMinutes(Values[0].Minute).AddMinutes(1));
                                        conditions.SubSets.Add(eqRange);
                                    }
                                    else if (fieldInfo.FieldType.Formatting == FieldFormatting.DATA) {
                                        CriteriaSet eqRange = CriteriaSet.And();
                                        eqRange.GreaterOrEqual(sc.AreaField, Values[0].Date);
                                        eqRange.Lesser(sc.AreaField, Values[0].Date.AddDays(1));
                                        conditions.SubSets.Add(eqRange);
                                    }
                                    else
                                    {
                                        conditions.Equal(sc.AreaField, Values[0]);
                                    }
                                    break;
                                case "NOTEQ":
									if (x < 1)
										continue;
									if (fieldInfo.FieldType.Formatting == FieldFormatting.DATAHORA)
                                    {
                                        CriteriaSet eqRange = CriteriaSet.And();
                                        eqRange.Lesser(sc.AreaField, Values[0].Date.AddHours(Values[0].Hour).AddMinutes(Values[0].Minute));
                                        eqRange.GreaterOrEqual(sc.AreaField, Values[0].Date.AddHours(Values[0].Hour).AddMinutes(Values[0].Minute).AddMinutes(1));
                                        conditions.SubSets.Add(eqRange);
                                    }
                                    else if (fieldInfo.FieldType.Formatting == FieldFormatting.DATA) {
                                        CriteriaSet eqRange = CriteriaSet.And();
                                        eqRange.Lesser(sc.AreaField, Values[0].Date);
                                        eqRange.GreaterOrEqual(sc.AreaField, Values[0].Date.AddDays(1));
                                        conditions.SubSets.Add(eqRange);
                                    }
									else
									{
										conditions.NotEqual(sc.AreaField, Values[0]);
									}
                                    break;
                                case "AFT":
									if (x < 1)
										continue;
									if (fieldInfo.FieldType.Formatting == FieldFormatting.DATAHORA)
                                    {
                                        conditions.GreaterOrEqual(sc.AreaField, Values[0].Date.AddHours(Values[0].Hour).AddMinutes(Values[0].Minute).AddMinutes(1));
                                    }
                                    else if (fieldInfo.FieldType.Formatting == FieldFormatting.DATA) {
                                        conditions.GreaterOrEqual(sc.AreaField, Values[0].Date.AddDays(1));
                                    }
									else
									{
										conditions.Greater(sc.AreaField, Values[0]);
									}
                                    break;
                                case "BEF":
									if (x < 1)
										continue;
									if (fieldInfo.FieldType.Formatting == FieldFormatting.DATAHORA)
                                    {
                                        conditions.Lesser(sc.AreaField, Values[0].Date.AddHours(Values[0].Hour).AddMinutes(Values[0].Minute));
                                    }
                                    else if (fieldInfo.FieldType.Formatting == FieldFormatting.DATA) {
                                        conditions.Lesser(sc.AreaField, Values[0].Date);
                                    }
									else
									{
										conditions.Lesser(sc.AreaField, Values[0]);
									}
                                    break;
                                case "AFTEQ":
									if (x < 1)
										continue;
                                    conditions.GreaterOrEqual(sc.AreaField, Values[0]);
                                    break;
                                case "BEFEQ":
									if (x < 1)
										continue;
                                    conditions.LesserOrEqual(sc.AreaField, Values[0]);
                                    break;
                                case "SET":
                                    conditions.NotEqual(sc.AreaField, null);
                                    break;
                                case "NOTSET":
                                    conditions.Equal(sc.AreaField, null);
                                    break;
                            }
                        }
                        else if (sc.FieldType.Equals(typeof(bool)))
                        {
                            //Create criteria based on operator code
                            switch (sfc.Operator)
                            {
                                case "TRUE":
                                    conditions.Equal(sc.AreaField, 1);
                                    break;
                                case "FALSE":
                                    conditions.Equal(sc.AreaField, 0);
                                    break;
                            }
                        }
                        else if (sc.FieldType.Equals(typeof(decimal?)))
                        {
                            //Parse values
							//Values must be an array because the number of values depends on the operation
                            decimal[] Values = new decimal[sfc.Values.Length];
                            decimal parsedValue;
                            int x = 0;
                            foreach (string value in sfc.Values)
                            {
                                if (decimal.TryParse(value, NumberStyles.Any, System.Threading.Thread.CurrentThread.CurrentCulture, out parsedValue))
                                    Values[x++] = parsedValue;
                            }

                            //Create criteria based on operator code
                            switch (sfc.Operator)
                            {
                                case "EQ":
									if (x < 1)
										continue;
                                    conditions.Equal(sc.AreaField, Values[0].ToString(CultureInfo.InvariantCulture));
                                    break;
                                case "NOTEQ":
									if (x < 1)
										continue;
                                    conditions.NotEqual(sc.AreaField, Values[0].ToString(CultureInfo.InvariantCulture));
                                    break;
                                case "GREAT":
									if (x < 1)
										continue;
                                    conditions.Greater(sc.AreaField, Values[0].ToString(CultureInfo.InvariantCulture));
                                    break;
                                case "LESS":
									if (x < 1)
										continue;
                                    conditions.Lesser(sc.AreaField, Values[0].ToString(CultureInfo.InvariantCulture));
                                    break;
                                case "GREATEQ":
									if (x < 1)
										continue;
                                    conditions.GreaterOrEqual(sc.AreaField, Values[0].ToString(CultureInfo.InvariantCulture));
                                    break;
                                case "LESSEQ":
									if (x < 1)
										continue;
                                    conditions.LesserOrEqual(sc.AreaField, Values[0].ToString(CultureInfo.InvariantCulture));
                                    break;
                                case "BETW":
                                    if (x < 2)
                                        continue;
                                    CriteriaSet between = CriteriaSet.And();
                                    between.GreaterOrEqual(sc.AreaField, Values[0].ToString(CultureInfo.InvariantCulture));
                                    between.LesserOrEqual(sc.AreaField, Values[1].ToString(CultureInfo.InvariantCulture));
                                    conditions.SubSets.Add(between);
                                    break;
                                case "SET":
                                    conditions.NotEqual(sc.AreaField, null);
                                    break;
                                case "NOTSET":
                                    conditions.Equal(sc.AreaField, null);
                                    break;
                            }
                        }
                        else if (!String.IsNullOrEmpty(sc.ArrayName))
                        {
							//Get enumeration dictionary
                            var arrayInfo = new CSGenio.business.ArrayInfo(StringUtils.CapFirst(sc.ArrayName));
                            var objectDic = arrayInfo.GetDictionaryObject();

                            //Create enumeration dictionary where keys and values are strings
                            Dictionary<string, string> dic;
                            if (objectDic is Dictionary<string, string>)
                                dic = (objectDic as Dictionary<string, string>).ToDictionary(p => p.Key, p => GenioMVC.Helpers.Helpers.GetTextFromResources(p.Value));
                            else if (objectDic is Dictionary<int, string>)
                                dic = (objectDic as Dictionary<int, string>).ToDictionary(p => p.Key.ToString(), p => GenioMVC.Helpers.Helpers.GetTextFromResources(p.Value));
                            else
                                dic = (objectDic as Dictionary<decimal, string>).ToDictionary(p => p.Key.ToString(), p => GenioMVC.Helpers.Helpers.GetTextFromResources(p.Value));

                            //Get enumeration codes
                            //Values must be an array because the number of values depends on the operation
                            string[] Values = new string[sfc.Values.Length];
                            int x = 0;
                            foreach (string value in sfc.Values)
                            {
                                foreach (var pair in dic)
                                {
                                    if (pair.Value.ToLower() == value?.ToLower())
                                    {
                                        Values[x++] = pair.Key;
                                        break;
                                    }
                                }
                            }

                            //Create criteria based on operator code
                            switch (sfc.Operator)
                            {
                                case "IS":
                                    if (x < 1)
                                        continue;
                                    conditions.Equal(sc.AreaField, Values[0]);
                                    break;
                                case "ISNOT":
                                    if (x < 1)
                                        continue;
                                    conditions.NotEqual(sc.AreaField, Values[0]);
                                    break;
								case "IN":
                                    if (x < 1)
                                        continue;
                                    conditions.In(sc.AreaField, Values);
                                    break;
                                case "SET":
                                    conditions.In(sc.AreaField, dic.Keys);
                                    break;
                                case "NOTSET":
                                    conditions.NotIn(sc.AreaField, dic.Keys);
                                    conditions.Equal(sc.AreaField, null);
                                    break;
                            }
                        }
                        else
                        {
                            //Text
                            //Create criteria based on operator code
                            switch (sfc.Operator)
                            {
                                case "LIKE":
                                    conditions.Like(sc.AreaField, sfc.Values[0]);
                                    break;
                                case "STRTWTH":
                                    conditions.Like(sc.AreaField, sfc.Values[0] + "%");
                                    break;
                                case "CON":
                                    conditions.Like(sc.AreaField, "%" + sfc.Values[0] + "%");
                                    break;
                                case "NOTCON":
                                    conditions.NotLike(sc.AreaField, "%" + sfc.Values[0] + "%");
                                    break;
                                case "EQ":
                                    conditions.Equal(sc.AreaField, sfc.Values[0]);
                                    break;
                                case "NOTEQ":
                                    conditions.NotEqual(sc.AreaField, sfc.Values[0]);
                                    break;
                                case "SET":
                                    CriteriaSet and = CriteriaSet.And();
                                    and.NotEqual(sc.AreaField, null);
                                    and.NotEqual(sc.AreaField, "");
                                    conditions.SubSets.Add(and);
                                    break;
                                case "NOTSET":
                                    conditions.Equal(sc.AreaField, null);
                                    conditions.Equal(sc.AreaField, "");
                                    break;
                            }
                        }
                    }

                    search_filters.SubSets.Add(conditions);
                }
            }
            //Advanced search filters
            foreach (TableSearchColumn sc in SearchColumns)
            {
                string filterValue = requestValues[requesValuesPrefix + sc.Field];
                if (!String.IsNullOrWhiteSpace(filterValue) || sc.FieldType.Equals(typeof(DateTime)))
                {
                    Menu.Filters.FiltersValues.Add(sc.Field, filterValue);
                    if (sc.FieldType.Equals(typeof(DateTime?)))
                    {
                        CriteriaSet dates = CriteriaSet.And();
                        string filterValue2 = requestValues[requesValuesPrefix + sc.Field + "2"];


                        bool hasDates = !String.IsNullOrWhiteSpace(filterValue) || !String.IsNullOrWhiteSpace(filterValue2);

                        if (!String.IsNullOrWhiteSpace(filterValue))
                        {
                            DateTime t1 = DateTime.Parse(filterValue, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
                            dates.GreaterOrEqual(sc.AreaField, t1);
                        }
                        else
                        {
                            Menu.Filters.FiltersValues.Remove(sc.Field);
                        }

                        if (!String.IsNullOrWhiteSpace(filterValue2))
                        {
                            DateTime t2 = DateTime.Parse(filterValue2, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
                            dates.LesserOrEqual(sc.AreaField, t2);
                            Menu.Filters.FiltersValues.Add(sc.Field + "2", filterValue2);
                        }

                        if (hasDates)
                            search_filters.SubSets.Add(dates);
                    }
                    else if (sc.FieldType.Equals(typeof(bool)))
                    {
                        //FFS -  foi acrescentado porque quando uma checkbox está selecionada, vem true,false
                        if (filterValue.ToLowerInvariant().Contains("true"))
                            filterValue = "true";
                        search_filters.Equal(sc.AreaField, bool.Parse(filterValue.ToLowerInvariant()));
                    }
                    else if (sc.FieldType.Equals(typeof(Array)))
                    {
                        search_filters.Equal(sc.AreaField, filterValue);
                    }
                    else if (sc.FieldType.Equals(typeof(decimal?)))
                    {
                        decimal value = 0;
                        if (decimal.TryParse(filterValue, NumberStyles.Any, System.Threading.Thread.CurrentThread.CurrentCulture, out value))
                            search_filters.Equal(sc.AreaField, value.ToString(CultureInfo.InvariantCulture));
                        else
                            search_filters.Like(sc.AreaField, filterValue);
                    }
                    else
                    {
                        search_filters.Like(sc.AreaField, filterValue);
                    }
                }
            }

			// If there was no filter search all columns
            if (search_filters.Criterias.Count == 0 && search_filters.SubSets.Count == 0)
                search_filters = SearchAllColumns(SearchColumns, query);

            return search_filters;
        }

        /// <summary>
        /// Builds a criteria set that searches all given columns for a given query
        /// </summary>
        /// <param name="SearchColumns">The list of columns to search</param>
        /// <param name="query">The string to search</param>
        /// <returns>A criteria set with all the given columns</returns>
        private CriteriaSet SearchAllColumns(List<TableSearchColumn> SearchColumns, string query)
        {
            DateTime t;
            CriteriaSet search_filters = CriteriaSet.Or();
            if (!String.IsNullOrEmpty(query))
            {
                foreach (TableSearchColumn sc in SearchColumns)
                {
                    if (sc.FieldType.Equals(typeof(DateTime?)))
                    {
                        if (DateTime.TryParse(query, System.Threading.Thread.CurrentThread.CurrentCulture, DateTimeStyles.None, out t) && CSGenio.business.GlobalFunctions.emptyD(t) == 0)
                            search_filters.Equal(sc.AreaField, t);
                    }
                    else if (!String.IsNullOrEmpty(sc.ArrayName))
                    {
                        Type arrayType = Type.GetType("CSGenio.business.Array" + StringUtils.CapFirst(sc.ArrayName) + ", CSGenio.core");
                        MethodInfo getDictionary = arrayType.GetMethod("GetDictionary");
                        var objectDic = getDictionary.Invoke(null, null);
                        Dictionary<string, string> dic;
                        if (objectDic is Dictionary<string, string>)
                            dic = (objectDic as Dictionary<string, string>).ToDictionary(p => p.Key, p => GenioMVC.Helpers.Helpers.GetTextFromResources(p.Value));
                        else if (objectDic is Dictionary<int, string>)
                        {
                            dic = (objectDic as Dictionary<int, string>).ToDictionary(p => p.Key.ToString(), p => GenioMVC.Helpers.Helpers.GetTextFromResources(p.Value));
                        }
                        else
                        {
                            dic = (objectDic as Dictionary<decimal, string>).ToDictionary(p => p.Key.ToString(), p => GenioMVC.Helpers.Helpers.GetTextFromResources(p.Value));
                        }
                        foreach (var pair in dic)
                        {
                            if (pair.Value.ToLower().Contains(query.ToLower()))
                                search_filters.Equal(sc.AreaField, pair.Key);
                        }
                    }
                    else if (sc.FieldType.Equals(typeof(decimal?)))
                    {
                        decimal value = 0;
                        if (decimal.TryParse(query, NumberStyles.Any, System.Threading.Thread.CurrentThread.CurrentCulture, out value))
                            search_filters.Like(SqlFunctions.Cast(SqlFunctions.Cast(sc.AreaField, CustomDbType.StandardDecimalSearch), CustomDbType.StandardAnsiString), "%" + value.ToString(CultureInfo.InvariantCulture) + "%");
                    }
                    else
                    {
                        search_filters.Like(sc.AreaField, "%" + query + "%");
                    }
                }
            }
            return search_filters;
        }

		/// <summary>
        /// Process the active filter from table list
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <param name="Menu">Render helper object</param>
        /// <param name="requestValues">All request parameters</param>
        /// <param name="requesValuesPrefix">List table prefix </param>
        /// <returns>A builded condition</returns>
        protected CriteriaSet ProcessActiveFilter<A>(TablePartial<A> Menu, NameValueCollection requestValues, string requesValuesPrefix)
        {
           CriteriaSet activefilters = CriteriaSet.And();
            DateTime hojeDt = DateTime.Today;
            bool activo = false;
            bool inactivo = false;
            bool futuro = false;

            //set active = true, at first load
            if (!requestValues.AllKeys.Contains("filter_" + requesValuesPrefix + "ActiveFilter_A"))
                 activo = true;
            else
            {
                activo = Conversion.string2Bool(requestValues["filter_" + requesValuesPrefix + "ActiveFilter_A"]);
                inactivo = Conversion.string2Bool(requestValues["filter_" + requesValuesPrefix + "ActiveFilter_I"]);
                futuro = Conversion.string2Bool(requestValues["filter_" + requesValuesPrefix + "ActiveFilter_F"]);
                string dateString = requestValues[requesValuesPrefix +"dataRef"];
                DateTime.TryParse(dateString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.RoundtripKind, out hojeDt);

                Navigation.SetValue("filter_" + requesValuesPrefix + "ActiveFilter_A", activo);
                Navigation.SetValue("filter_" + requesValuesPrefix + "ActiveFilter_I", inactivo);
                Navigation.SetValue("filter_" + requesValuesPrefix + "ActiveFilter_F", futuro);
            }

            FieldRef datainiColumn = Menu.Filters.FilterDateStart;
            FieldRef datafimColumn = Menu.Filters.FilterDateEnd;

            //There are 8 diferent cases
            int value = 0;
            if (activo) { value += 1; }
            if (inactivo) { value += 2; }
            if (futuro) { value += 4; }

            switch (value)
            {
                case 0:
                    {
                        //Estados incongruentes (Data de saída inferior à data de entrada)
                        activefilters.Lesser(datafimColumn, datainiColumn);
                        return activefilters;
                    }
                case 1:
                    {
                        //So activos
                        activefilters.SubSet(CriteriaSet.Or()
                                .GreaterOrEqual(hojeDt, datainiColumn)
                                .Equal(datainiColumn, null))
                            .SubSet(CriteriaSet.Or()
                                .LesserOrEqual(hojeDt, datafimColumn)
                                .Equal(datafimColumn, null));

                        return activefilters;
                    }
                case 2:
                    {
                        //So inactivos
                        activefilters.Greater(hojeDt, datafimColumn)
                            .NotEqual(datafimColumn, null);

                        return activefilters;
                    }
                case 3:
                    {
                        //So activos e inactivos
                        activefilters.SubSet(CriteriaSet.Or()
                            .GreaterOrEqual(hojeDt, datainiColumn)
                            .Equal(datainiColumn, null));

                        return activefilters;
                    }
                case 4:
                    {
                        //So futuros
                        activefilters.SubSet(CriteriaSet.Or()
                            .Lesser(hojeDt, datainiColumn) // data actual inferior à data de início
                            .SubSet(CriteriaSet.And() // data de fim é superior à actual e a de início não exists
                                .Greater(datafimColumn, hojeDt)
                                .Equal(datainiColumn, null))
                            .SubSet(CriteriaSet.And() // data de início e de fim vazias
                                .Equal(datainiColumn, null)
                                .Equal(datafimColumn, null)));

                        return activefilters;
                    }
                case 5:
                    {
                        //So activos e futuros
                        activefilters.SubSet(CriteriaSet.Or()
                            .LesserOrEqual(hojeDt, datafimColumn)
                            .Equal(datafimColumn, null));

                        return activefilters;
                    }
                case 6:
                    {
                        //So inactivos e futuros
                        activefilters.SubSet(CriteriaSet.Or()
                            .Lesser(hojeDt, datainiColumn)
                            .SubSet(CriteriaSet.And()
                                .Greater(hojeDt, datafimColumn)
                                .NotEqual(datafimColumn, null)));

                        return activefilters;
                    }
                case 7:
                    {
                        //Todos, nao limita nada
                        return activefilters;
                    }
                default:
                    break;
            }
            return activefilters;
        }


		protected CriteriaSet GetConditionsToNN(AreaRef table, FieldRef tableKey, AreaRef tableNN, AreaRef otherTable, FieldRef otherTableKey, string otherTableSelectedValue, string identifier = "")
		{
			//old call
			return GetConditionsToNN(table, tableKey, tableNN, otherTable, otherTableKey, otherTableSelectedValue, null, null, null, false, identifier);
		}

		protected CriteriaSet GetConditionsToNN(AreaRef table, FieldRef tableKey, AreaRef tableNN, AreaRef otherTable, FieldRef otherTableKey, string otherTableSelectedValue, AreaRef areaCompare, FieldRef areaCompareKey, string areaCompareSelectedValue, bool NaoAplicaSeNulo, string identifier = "")
        {
            CriteriaSet criteria = CriteriaSet.And();
            SelectQuery qs = null;

            CSGenio.business.AreaInfo NN_AreaInfo = CSGenio.business.Area.GetInfoArea(tableNN.Alias.ToLower());
            CSGenio.framework.Relation NN_relationWithOtherTbl = null;
            NN_AreaInfo.ParentTables.TryGetValue(table.Alias.ToLower(), out Relation NN_relationWithTbl);
            if (otherTable != null)
                NN_AreaInfo.ParentTables.TryGetValue(otherTable.Alias.ToLower(), out NN_relationWithOtherTbl);

            if (NN_relationWithTbl != null)
            {
                qs = new SelectQuery()
                //.Distinct(true)
                .Select(tableKey)
                .From(tableNN)
                .Join(table)
                    .On(CriteriaSet.And().Equal(new FieldRef(NN_relationWithTbl.AliasSourceTab, NN_relationWithTbl.SourceRelField), tableKey));
            }
            else return criteria;

            CriteriaSet whereConds = CriteriaSet.Or();
            if (NN_relationWithOtherTbl != null)
            {
                FieldRef NN_FldOtherTbl = new FieldRef(NN_relationWithOtherTbl.AliasSourceTab, NN_relationWithOtherTbl.SourceRelField);
                qs.Join(otherTable)
                    .On(CriteriaSet.And().Equal(NN_FldOtherTbl, otherTableKey));
                whereConds.Equal(NN_FldOtherTbl, otherTableSelectedValue);

				if(NaoAplicaSeNulo) //only apply if null condition
				{
					SelectQuery qs2 = (SelectQuery)qs.Clone();
					CriteriaSet whereConds2 = (CriteriaSet)whereConds.Clone();
					qs2.Where(whereConds2);
					whereConds.NotExists(qs2);
				}
            }

            //added limit for areaCompare that will limit NN
            if (areaCompare != null)
            {
                //CSGenio.business.AreaInfo NN_AreaInfo = getInformacaoMethod.Invoke(null, new object[] { }) as CSGenio.business.AreaInfo;
                NN_AreaInfo.ParentTables.TryGetValue(areaCompare.Alias.ToLower(), out Relation NN_relationWithAreaCompare);

                if (NN_relationWithAreaCompare != null)
                {
                    FieldRef NN_FldAreaCompare = new FieldRef(NN_relationWithAreaCompare.AliasSourceTab, NN_relationWithAreaCompare.SourceRelField);
                    qs.Join(areaCompare)
                        .On(CriteriaSet.And().Equal(NN_FldAreaCompare, areaCompareKey));

                    whereConds.Equal(NN_FldAreaCompare, areaCompareSelectedValue);
                }
            }

            // Apply the PHE
            CSGenio.business.Area areaNN = CSGenio.business.Area.createArea(NN_AreaInfo.Alias, UserContext.Current.User, UserContext.Current.User.CurrentModule);
            CriteriaSet condEph = Listing.CalculateConditionsEphGeneric(areaNN, identifier);
            if (condEph != null && (condEph.Criterias.Count > 0 || condEph.SubSets.Count > 0))
                qs.Where(CriteriaSet.And().SubSet(whereConds).SubSet(condEph));
            else
                qs.Where(whereConds);

            criteria.In(tableKey, qs);

            return criteria;
        }

		/// <summary>
        /// Adds a limitation to a CriteriaSet based on the history value.
        /// Takes into account the EPH entries as well.
        /// </summary>
        /// <param name="baseCondition">The condition to expand</param>
        /// <param name="targetField">The field being subjected to the filter</param>
        /// <param name="history">The history entry to be consulted</param>
        /// <returns>True if the entry was found, false otherwise</returns>
        public bool AddHistoryLimit(CriteriaSet baseCondition, FieldRef targetField, string history)
        {
            if(Navigation.CheckKey(history))
            {
                baseCondition.Equal(targetField, Navigation.GetValue(history));
                return true;
            }

            var ephs = UserContext.Current.User.fieldsEph(history);
            if(ephs != null)
            {
                if(ephs.Length > 1)
                    baseCondition.In(targetField, ephs);
                else if (ephs.Length > 0)
                    baseCondition.Equal(targetField, ephs[0]);
                return true;
            }

            return false;
        }


        /// <summary>
        /// Limitation by Zzstate
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="zzstateField"></param>
        /// <param name="opercriaField">(optional)</param>
        /// <returns></returns>
        protected CriteriaSet extendWithZzstateCondition(CriteriaSet condition, FieldRef zzstateField, FieldRef opercriaField)
        {
            if (opercriaField == null)
            {
                condition.Criterias.Add(new Criteria(new ColumnReference(zzstateField), CriteriaOperator.NotEqual, 1));
            }
            else
            {
                var zzstateCondition = CriteriaSet.Or().Equal(zzstateField, 0);
                var user = UserContext.Current.User;
                if (user.IsAdmin(user.CurrentModule))
                {
                    zzstateCondition = zzstateCondition
                        .Equal(zzstateField, 11)
                            .SubSet(CriteriaSet.And()
                                .Equal(zzstateField, 1)
                                .Equal(opercriaField, user.Name));
                }
                else
                {
                    zzstateCondition = zzstateCondition
                        .SubSet(CriteriaSet.And()
                            .Equal(opercriaField, user.Name)
                                .SubSet(CriteriaSet.Or()
                                    .Equal(zzstateField, 1)
                                    .Equal(zzstateField, 11)));
                }
                condition = condition.SubSet(zzstateCondition);
            }

            return condition;
        }

        /// <summary>
        /// Adds a query condition to the CriteriaSet based on the historical value of the specified area or the current ViewModel value.
        /// If the value is an array, it adds an 'In' condition.
        /// If the value is not empty, it adds an 'Equal' condition.
        /// </summary>
        /// <param name="crs">The CriteriaSet to which the condition will be added.</param>
        /// <param name="fieldref">The FieldRef indicating the field for the query condition.</param>
        /// <param name="area">The area from which to retrieve the historical value for the condition.</param>
        /// <param name="fieldValue">The current ViewModel value to use as a fallback if the historical value is empty.</param>
        /// <param name="isMandatory">Indicates whether the limit is mandatory.</param>
        /// <returns>True if the condition was successfully added or not needed, False if it's a mandatory limit and the value is empty.</returns>
        protected bool AddCriteriaAreaLimit(CriteriaSet crs, FieldRef fieldref, string area, string fieldValue, bool isMandatory)
        {
            var histValue = Navigation.GetValue(area);
            var value = GlobalFunctions.emptyG(histValue) == 1 ? fieldValue : histValue;

            // Add an 'In' condition if the value is an array
            if (value is Array arrayValue)
            {
                crs.In(fieldref, arrayValue);
            }
            // Handle empty value based on 'isMandatory'
            else if (GlobalFunctions.emptyG(value) == 1)
            {
                return isMandatory ? false : true;
            }
            // Add an 'Equal' condition if the value is not empty
            else
            {
                crs.Equal(fieldref, value);
            }

            // Successfully applied the limit
            return true;
        }

        /// <summary>
        /// Adds a query condition to the CriteriaSet based on the historical value of the specified key.
        /// If the value is an array, it adds an 'In' condition.
        /// If the value is not empty, it adds an 'Equal' condition.
        /// </summary>
        /// <param name="crs">The CriteriaSet to which the condition will be added.</param>
        /// <param name="fieldref">The FieldRef indicating the field for the query condition.</param>
        /// <param name="operationType">The type of the limit operation.</param>
        /// <param name="key">The key from which to retrieve the historical value for the condition.</param>
        /// <param name="isMandatory">Indicates whether the limit is mandatory.</param>
        /// <returns>True if the condition was successfully added or not needed, False if it's a mandatory limit and the value is empty.</returns>
        protected bool AddCriteriaHistoryLimit(
            CriteriaSet crs,
            FieldRef fieldref,
            OperationType operationType,
            string key,
            bool isMandatory
        )
        {
            var histValue = Navigation.GetValue(key);
            var fieldInfo = CSGenio.business.Area.GetFieldInfo(fieldref);

            // Add an 'In' condition if the value is an array
            if (histValue is Array arrayValue)
            {
                crs.In(fieldref, arrayValue);
            }
            // Handle empty value based on 'isMandatory'
            else if (histValue == null)
            {
                return !isMandatory;
            }

            // Add the condition according to the operation type
            var value = QueryUtils.ToValidDbValue(histValue, fieldInfo);

            switch (operationType)
            {
                case OperationType.EQUAL:
                    crs.Equal(fieldref, value);
                    break;
                case OperationType.LESS:
                    crs.Lesser(fieldref, value);
                    break;
                case OperationType.LESSEQUAL:
                    crs.LesserOrEqual(fieldref, value);
                    break;
                case OperationType.GREAT:
                    crs.Greater(fieldref, value);
                    break;
                case OperationType.GREATEQUAL:
                    crs.GreaterOrEqual(fieldref, value);
                    break;
                case OperationType.DIFF:
                    crs.NotEqual(fieldref, value);
                    break;
                default:
                    throw new InvalidOperationException("Invalid operation type: " + operationType);
            }

            // Successfully applied the limit
            return true;
        }

        public StatusMessage flashMessage { get; set; }

        #region Permissions

        private bool CheckVMPermissions(FormMode mode)
        {
            if (Maintenance.Current.IsActive && (mode != FormMode.Show && mode != FormMode.FullTextSearch && mode != FormMode.List )) {
                return false;
            }

            //Form permissions
            User user = UserContext.Current.User;
			//use the full qualified name to prevent problems with tables with name ROLE
            CSGenio.framework.Role role;

            if (mode.Equals(FormMode.Show) || mode.Equals(FormMode.List))
                role = RoleToShow;
            else
                role = RoleToEdit;

            return user.VerifyAccess(role);
        }

        public virtual string GetPermissionMessage(FormMode mode)
        {
            string msg = String.Empty;
            if (Maintenance.Current.IsActive && (mode != FormMode.Show && mode != FormMode.FullTextSearch && mode != FormMode.List)) {
                msg = Resources.Resources.SISTEMA_EM_MANUTENCA49570;
            }

            switch (mode)
            {
                case FormMode.List:
                case FormMode.FullTextSearch:
                case FormMode.Show:
                    msg = Resources.Resources.O_UTILIZADOR_NAO_TEM03504;
                    break;
                case FormMode.New:
                case FormMode.Duplicate:
                    msg = Resources.Resources.NAO_TEM_PERMISSOES_P32156;
                    break;
                case FormMode.Edit:
                    msg = Resources.Resources.NAO_TEM_PERMISSOES_P04791;
                    break;
                case FormMode.Delete:
                    msg = Resources.Resources.O_UTILIZADOR_NAO_TEM12871;
                    break;
                default:
                    throw new FrameworkException(Resources.Resources.OCORREU_UM_ERRO_34773, "GetPermissionMessage", "FormMode not implemented: " + mode);
            }

            return msg;
        }

        protected StatusMessage CheckPermissions(Models.ModelBase model, FormMode mode)
        {
            bool hasPermission = CheckVMPermissions(mode);

            if (hasPermission)
            {
                hasPermission = model.CheckTablePremissions(mode);
            }

            if (!hasPermission)
               return StatusMessage.Error(GetPermissionMessage(mode));
            else
                return StatusMessage.OK();
        }

        public virtual StatusMessage CheckPermissions(FormMode mode)
        {
            if (!CheckVMPermissions(mode))
                return StatusMessage.Error(GetPermissionMessage(mode));
            else
                return StatusMessage.OK();
        }
        #endregion

        /// <summary>
        /// Compatibilização com BO
        /// </summary>
        /// <param name="mode">Mode do form em MVC</param>
        /// <returns>inteiro correspondente a mode do form em BO</returns>
        public static int ConvertFormModeMVC2BO(FormMode mode)
        {
            switch (mode)
            {
                case FormMode.New: return 0;
                case FormMode.Show: return 1;
                case FormMode.Edit: return 2;
                case FormMode.Delete: return 3;
                case FormMode.Duplicate: return 4;
                default: return 1;
            }
        }

        /// <summary>
        /// MH - Vai ser usado no GetDependants to obter Qvalues default dos fields
        /// </summary>
        /// <param name="fields">Lista dos Qfield</param>
        /// <returns></returns>
        protected static ConcurrentDictionary<string, object> getDefaultValuesForFields(FieldRef[] fields)
        {
            ConcurrentDictionary<string, object> values = new ConcurrentDictionary<string, object>();
            foreach (FieldRef field in fields)
            {
                CSGenio.framework.Field campoBD = CSGenio.business.Area.GetFieldInfo(field);
                values.TryAdd(field, campoBD.GetValorEmpty());
            }
            return values;
        }


        /// <summary>
        /// Load the list of slot report from the database
        /// </summary>
        /// <param name="slotIdentifier">Slot id</param>
        /// <returns>list of slot report</returns>
        public List<object> GetSlotReports(string slotIdentifier)
        {
            List<object> resultList = new List<object>();
            List<CSGenioAreportlist> reportList = CSGenioAreportlist.searchList(
                UserContext.Current.PersistentSupport,
                UserContext.Current.User,
                CriteriaSet.And()
                .Equal(CSGenioAreportlist.FldSlotid, slotIdentifier)
                .Equal(CSGenioAreportlist.FldZzstate, 0)
            );
            reportList.ForEach(p => resultList.Add(p));
            return resultList;
        }

        ///<summary>CHN - Used in ViewModels Load() to reference the information of a EPH limit over the listing</summary>
        ///<param name="area_limit"> (ref) limit to be loaded with the information aquired</param>
        ///<param name="model_limit_area"> Area class object responsible for this limit</param>
        ///<param name="menu_identifier"> Menu identifier where to check the EPHs existence</param>
        ///<returns> Returns the List existing EPHs that area being applied to current listing</returns>
        public List<Limit> EPH_Limit_Filler(ref Limit area_limit, CSGenio.business.Area model_limit_area, string menu_identifier)
        {
            string current_area = model_limit_area.Alias;
            AreaInfo area_info = model_limit_area.Information;
            string limit_field = model_limit_area.PrimaryKeyName;
            string limit_field_value = "";
            //string nav_limit_area = Navigation.GetStrValue(limit_area);
            User user = UserContext.Current.User;
            string module = user.CurrentModule;
            List<Limit> list_area_limit = new List<Limit>();

            //var ephs = user.fieldsEph(current_area); //UserContext.Current.User.Ephs[new Par(];// .fieldsEph(limit_field_value);
            List<EPHOfArea> ephsDaArea = model_limit_area.CalculateAreaEphs(model_limit_area.User.Ephs, menu_identifier, false);

            foreach (EPHOfArea eph in ephsDaArea)
            {
                limit_field = eph.Eph.Field; //double check this inference
                limit_field_value = eph.Eph.Name;

                area_limit.TipoLimiteOperator = eph.Eph.Operator;

                if (eph.Relation != null) //its related to another table, that is setting the EPH limit
                {
                    CSGenio.business.Area parent_area = CSGenio.business.Area.createArea(eph.Relation.AliasTargetTab, UserContext.Current.User, UserContext.Current.User.CurrentModule);
                    CSGenio.business.Area model_limit_area2 = parent_area; //change model to the one being related by foreign key
                    area_info = model_limit_area2.Information;
                    //limit_field = model_limit_area2.PrimaryKeyName; //need to confirm this inference, but it seems correct at a first glance
                    Limit_Filler(ref area_limit, model_limit_area2, limit_field, limit_field_value, null, LimitAreaType.AreaLimita);
                }
				else if (eph.Relation2 != null) //its related to another table, via EPH2, that is setting the EPH limit
                {
					area_limit.TipoLimiteOperator = eph.Eph.Operator2;
					limit_field = eph.Eph.Field2; //double check this inference
                    CSGenio.business.Area parent_area = CSGenio.business.Area.createArea(eph.Relation2.AliasTargetTab, UserContext.Current.User, UserContext.Current.User.CurrentModule);
                    CSGenio.business.Area model_limit_area2 = parent_area; //change model to the one being related by foreign key
                    area_info = model_limit_area2.Information;
                    //limit_field = model_limit_area2.PrimaryKeyName; //need to confirm this inference, but it seems correct at a first glance
                    Limit_Filler(ref area_limit, model_limit_area2, limit_field, limit_field_value, null, LimitAreaType.AreaLimita);
                }
                else
                {
                    Limit_Filler(ref area_limit, model_limit_area, limit_field, limit_field_value, null, LimitAreaType.AreaLimita);
                }

                list_area_limit.Add(area_limit);
            }
            return list_area_limit;
        }

		///<summary>CHN - Used in ViewModels Load() to reference the information of a EPH limit over the listing</summary>
        ///<param name="area_limit"> (ref) limit to be loaded with the information aquired</param>
        ///<param name="model_limit_area"> Area class object responsible for this limit</param>
        ///<param name="menu_identifier"> Menu identifier where to check the EPHs existence</param>
        ///<returns> Returns the List existing EPHs that area being applied to current listing</returns>
        public void Limit_Filler(ref Limit area_limit, CSGenio.business.Area model_limit_area, string limit_field, string limit_field_value, object this_limit_field, LimitAreaType limitAreaType)
        {
            //Limit area information
            string limit_area = model_limit_area.Alias;
            AreaInfo area_info = model_limit_area.Information;
            string nav_limit_area = Navigation.GetStrValue(limit_area);
            bool filledbyeph = false;

            //Limit field information
            CSGenio.framework.Field field = null;
            string field_value = string.Empty;
            //check if necessary a change in limit_field to check for limit_field_value (usual in history manipulations)
            limit_field = limit_field == area_info.PrimaryKeyName && model_limit_area.DBFields.ContainsKey(limit_field_value) ? limit_field_value : limit_field;
            //fill field with object information
            field = model_limit_area.DBFields[limit_field];

            //special cases that have to select whats written in navigation or history to limit following related areas with value defined
            if (!string.IsNullOrEmpty(limit_field_value) && (area_limit.TipoLimite == LimitType.HM || area_limit.TipoLimite == LimitType.SH || area_limit.TipoLimite == LimitType.H))
            {
                nav_limit_area = Navigation.GetStrValue(limit_field_value);
				filledbyeph = true;
            }
            if ((string.IsNullOrEmpty(nav_limit_area) && filledbyeph) || area_limit.TipoLimite == LimitType.EPH) //If not filled, and its suposed to be by EPHs, checks EPH limits. If EPH, then check filling
            {
                var ephs = UserContext.Current.User.fieldsEph(limit_field_value);
                if (ephs != null)
                {
                    nav_limit_area = ephs[0];
                    limit_field_value = nav_limit_area;
                }
                else
                    limit_field_value = string.Empty; //clears string, so it wont be mistaken as the value to be set in field value
            }

            //Tries to position area and field to a real record: if we have information about the area key, then it will be enough, otherwise, it will use a 'virtual' positioning on the first record and field variable will be manually set
            //Model has a field with the desired value filled acting as the limit (As an example Limit type "C" (field) is expecting this to be happening on AreaLimitaN)
            if ((field.FieldType == FieldType.CHAVE_PRIMARIA || field.FieldType == FieldType.CHAVE_PRIMARIA_GUID || field.FieldType == FieldType.CHAVE_ESTRANGEIRA || field.FieldType == FieldType.CHAVE_ESTRANGEIRA_GUID) && //field a key
                (GlobalFunctions.emptyG(this_limit_field) == 0 || GlobalFunctions.emptyG(nav_limit_area) == 0)) //and the key is present either in this_limit_field or in nav_limit_area
            {
                if (GlobalFunctions.emptyG(this_limit_field) == 0) //this will give priority to field value with key to position the record.
                    nav_limit_area = this_limit_field.ToString();

                if (field.FieldType == FieldType.CHAVE_ESTRANGEIRA || field.FieldType == FieldType.CHAVE_ESTRANGEIRA_GUID) //if limit_field is refering to a related area, then update model to the correct parent
                {//double check this case!
                    string parent_table_name = model_limit_area.ParentTables.Where(x => x.Value.SourceRelField == field.Name).FirstOrDefault().Key;
                    CSGenio.business.Area parent_area = CSGenio.business.Area.createArea(parent_table_name, UserContext.Current.User, UserContext.Current.User.CurrentModule);
                    model_limit_area = parent_area; //change model to the one being related by foreign key
                    area_info = model_limit_area.Information;
                    limit_field = model_limit_area.PrimaryKeyName; //need to confirm this inference, but it seems correct at a first glance
                }

                List<string> List_fields = new List<string>(){ area_info.Alias + "." + area_info.PrimaryKeyName, area_info.Alias + "." + limit_field }; //3 fields to select, primary, limit and humankey fields

                //area direct positioning to the desired record, using the key value that we want.
                //decompose human key into fields:
                string[] human_fields_array = area_info.HumanKeyName.Split(',');
				human_fields_array = human_fields_array.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                if (GlobalFunctions.emptyC(area_info.HumanKeyName) == 0)
                {
                    foreach (string human_field in human_fields_array)
                    {
                        List_fields.Add(area_info.Alias + "." + human_field);
                    }
                }
                else
                    List_fields.Add(area_info.Alias + "." + limit_field);

                string[] fields = List_fields.ToArray();

                model_limit_area.insertNamesFields(fields);
                model_limit_area.selectOne(CriteriaSet.And().Equal(area_info.Alias, area_info.PrimaryKeyName, nav_limit_area), null, "", UserContext.Current.PersistentSupport, 0);
                //select first human key that has a value.
                foreach (string human_field in human_fields_array)
                {
                    field = model_limit_area.DBFields[human_field];
                    field_value = ((CSGenio.framework.RequestedField)model_limit_area.Fields[model_limit_area.Alias + "." + field.Name]).Value.ToString();
                    if (GlobalFunctions.emptyC(field_value) == 0) //if has a value, exit loop
                        break;
                }

                if (GlobalFunctions.emptyC(area_info.HumanKeyName) == 1 || GlobalFunctions.emptyC(field_value) == 1) //last resort: displays primary key, better check human key table definitions to avoid this
                {
                    field = model_limit_area.DBFields[area_info.PrimaryKeyName];
                    field_value = ((CSGenio.framework.RequestedField)model_limit_area.Fields[model_limit_area.Alias + "." + field.Name]).Value.ToString();
                }
            }
            else //only matters the field value (applied to the current limit area)
            {
                string[] fields = new string[] { area_info.Alias + "." + area_info.PrimaryKeyName, area_info.Alias + "." + limit_field, area_info.Alias + "." + (area_info.HumanKeyName.Split(',')[0] == "" ? area_info.PrimaryKeyName : area_info.HumanKeyName.Split(',')[0]) }; //3 fields to select, primary, limit and humankey field
                model_limit_area.insertNamesFields(fields);
                SelectQuery select_top1_limit = new SelectQuery();
                // Fields to select
                select_top1_limit.PageSize(0); //this is intended, to fill only the names, not any values that could misslead to believe that those were selected. At this moment no record is being selected.
                select_top1_limit.Select(model_limit_area.Alias, area_info.PrimaryKeyName);
                select_top1_limit.From(model_limit_area.QSystem, model_limit_area.TableName, model_limit_area.Alias);
                //get one random record from the desired table
                try
                {
                    model_limit_area.selectOne(CriteriaSet.And().Equal(area_info.Alias, area_info.PrimaryKeyName, select_top1_limit), null, "", UserContext.Current.PersistentSupport, 0);
                }
                catch //this will always be landing on catch. explanation above.
                {

                }
                field = model_limit_area.DBFields[limit_field];

                field_value = GlobalFunctions.emptyC(this_limit_field) == 0 ? this_limit_field.ToString() : (!string.IsNullOrEmpty(Navigation.GetStrValue(limit_field_value)) ? Navigation.GetStrValue(limit_field_value) : limit_field_value);

                //Get history value for fullname, on its variants (this should be consistent, but it isnt on some limit "S..." types, maybe review it later.)
                string field_Fullname = string.Empty;
                field_Fullname = limit_area + "." + limit_field;
                string field_FullnameVar = StringUtils.CapFirst(limit_area) + "Val" + StringUtils.CapFirst(limit_field);
                if (string.IsNullOrEmpty(field_value))
                    field_value = Navigation.GetStrValue(field_Fullname);
                if (string.IsNullOrEmpty(field_value))
                    field_value = Navigation.GetStrValue(field_FullnameVar);
                //Apply value to model to be rendered correctly
                ((CSGenio.framework.RequestedField)model_limit_area.Fields[model_limit_area.Alias + "." + field.Name]).Value = field_value;
            }

            //Field value information on special limit fields that dont exist yet, only the value will be colected, so its not important to fill all fields object with stuff that will not be used.
            if (area_limit.TipoLimite == LimitType.SE)
            {
                DateTime minLim = Navigation.GetDateValue("min" + StringUtils.CapFirst(model_limit_area.Alias) + "Val" + StringUtils.CapFirst(limit_field)).GetValueOrDefault();
                DateTime maxLim = Navigation.GetDateValue("max" + StringUtils.CapFirst(model_limit_area.Alias) + "Val" + StringUtils.CapFirst(limit_field)).GetValueOrDefault();

                model_limit_area.Fields.Add(model_limit_area.Alias + "." + "minLim", minLim);
                model_limit_area.Fields.Add(model_limit_area.Alias + "." + "maxLim", maxLim);
            }

			switch (limitAreaType)
			{
				case LimitAreaType.AreaLimita:
					{
						area_limit.AreaLimita = model_limit_area;
						area_limit.CampoLimita = field;
						break;
					}
				case LimitAreaType.AreaLimitaN:
					{
						area_limit.AreaLimitaN = model_limit_area;
						area_limit.CampoLimitaN = field;
						break;
					}
				case LimitAreaType.AreaComparar:
					{
						area_limit.AreaComparar = model_limit_area;
						area_limit.CampoComparar = field;
						break;
					}
				default:
					{
						area_limit.AreaLimita = model_limit_area;
						area_limit.CampoLimita = field;
						break;
					}
			}
        }
		///<summary>CHN - Added function in ViewModels to set a variable using reflexion</summary>
        ///<param name="propertyName">ViewModel variable name</param>
        ///<param name="value"> the value to be set</param>
		public void SetMethodInvoke(string propertyName, dynamic value)
        {
            var propertyInfo = this.GetType().GetProperty(propertyName);
            propertyInfo.SetMethod.Invoke(this, new object[] { value });
        }

        ///<summary>CHN - Added function in ViewModels to get a variable value using reflexion</summary>
        ///<param name="propertyName">ViewModel variable name</param>
        public dynamic GetMethodInvoke(string propertyName)
        {
            var propertyInfo = this.GetType().GetProperty(propertyName);
            return propertyInfo.GetMethod.Invoke(this, null);
        }

		/// <summary>
		///  Sanitizes the contents of fields with HTML support on the client-side by cleaning HTML fragments and documents of constructs that could lead to XSS attacks and compromise application security.
		/// </summary>
        protected virtual void SanitizeHTMLFields() { /* Method intentionally left empty. */ }

		/// <summary>
		/// Sanitizes the ViewModel content by cleaning HTML fragments and documents from constructs that could lead to XSS attacks and compromise application security.
		/// </summary>
		public void SanitizeContent()
		{
			SanitizeHTMLFields();
		}
    }

    public static class ViewModelConversion
    {
        public static decimal ToDouble(object value)
        {
            return DBConversion.ToNumeric(value);
        }

        public static decimal ToNumeric(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0.0M;
            if (value is double)
                return Convert.ToDecimal(value);
            if (value is int)
                return (decimal)((int)value);
            if (value is decimal)
                return (decimal)value;
            if (value is string)
            {
                if (value.Equals(""))
                    return 0.0M;

                decimal temp = 0.0M;
                if (!decimal.TryParse(value.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out temp) &&
                    !decimal.TryParse(value.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out temp))
                    return 0.0M;
                else
                    return temp;
            }

            return 0.0M;
        }

        public static string ToString(object value)
        {
            return DBConversion.ToString(value);
        }

        public static int ToInteger(object value)
        {
            return DBConversion.ToInteger(value);
        }

        public static DateTime ToDateTime(object value)
        {
            return DBConversion.ToDateTime(value);
        }

        public static bool ToLogic(object value)
        {
            return DBConversion.ToLogic(value) == 1;
        }

        public static byte[] ToBinary(object value)
        {
            return DBConversion.ToBinary(value);
        }

        public static byte[] ToImage(object value)
        {
            return DBConversion.ToBinary(value);
        }

        public static CSGenio.framework.Geography.GeographicData ToGeographicShape(object value)
        {
            return DBConversion.ToGeographicShape(value);
        }
    }

    public static class JavaScriptConversion
    {
        public static IHtmlString ToString(string value)
        {
            return new HtmlString("'" + HttpUtility.JavaScriptStringEncode(value ?? "") + "'");
        }

        public static object ToInteger(int value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        public static object ToDouble(decimal value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        public static object ToNumeric(object value)
        {
            if (value == null)
            {
                return 0;
            }
            else if (value is decimal?)
            {
                return (value as decimal?).GetValueOrDefault().ToString(CultureInfo.InvariantCulture);
            }
            else if (value is double?)
            {
                return (value as double?).GetValueOrDefault().ToString(CultureInfo.InvariantCulture);
            }
            else
                return value.ToString();
        }

        public static IHtmlString ToDateTime(DateTime? value)
        {
            if (value == null || value == DateTime.MinValue)
                return new HtmlString("''");
            else
            {
                // Obter a data no format ISO
                return new HtmlString(Newtonsoft.Json.JsonConvert.SerializeObject(value.GetValueOrDefault()));
            }
        }

        public static int ToLogic(bool value)
        {
            if (value) return 1;
            else return 0;
        }

        public static IHtmlString ToBinary(object value)
        {
            // TODO: O que devia retornar ???
            if (value == null)
                return new HtmlString("''");
            if (value is byte[])
                return new HtmlString("'" + HttpUtility.JavaScriptStringEncode(System.Text.Encoding.Default.GetString(value as byte[])) + "'");
            return new HtmlString("'" + HttpUtility.JavaScriptStringEncode(Convert.ToString(value)) + "'");
        }

        public static IHtmlString ToImage(object value)
        {
            return ToBinary(value);
        }

        public static object ToGeographicShape(object value)
        {
            return DBConversion.ToGeographicShape(value);
        }
    }

	//FOR: SEARCH FILTERS
	public class SearchFilter
    {
        public string Name { get; set; }
		public bool Active { get; set; }
        public SearchFilterCondition[] Conditions { get; set; }
    }

    public class SearchFilterCondition
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Field { get; set; }
        public string Operator { get; set; }
        public string[] Values { get; set; }
    }
}
