using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace GenioMVC.Helpers.Table.Filtering
{
    public class TableFilter
    {
        public const string TABLE_FILTERS_QUERYSTRING = "_tableFilters";

        public bool ShowTableFilters { get; protected set; }
        public bool HasAdvancedFilters { get; protected set; }
        public Dictionary<string, string> FiltersValues { get; protected set; }
		public string Query { get; protected set; }
        public string QueryField { get; protected set; }

        public string qsTableFilters { get; set; }

        public TableFilter(bool showTableFilters, bool hasAdvancedFilters, Dictionary<string, string> filtersValues, string queryField, string query)
        {
            this.ShowTableFilters = showTableFilters;
            this.HasAdvancedFilters = hasAdvancedFilters;
            this.FiltersValues = filtersValues;

            this.QueryField = queryField;
            this.Query = query;

            this.qsTableFilters = TABLE_FILTERS_QUERYSTRING;
        }
    }
}