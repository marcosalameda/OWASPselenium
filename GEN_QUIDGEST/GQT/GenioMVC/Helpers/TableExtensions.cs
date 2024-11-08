using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GenioMVC.Helpers.Table;
using GenioMVC.Helpers.Table.Properties;

namespace GenioMVC.Helpers
{
    public static class TableExtensions
    {
        /// <summary>
        /// Return an instance of a TableBuilder.
        /// </summary>
        /// <typeparam name="TModel">Type of model to render in the table.</typeparam>
        /// <returns>Instance of a TableBuilder.</returns>
        public static TableBuilder<TModel> newTableFor<TModel>(this HtmlHelper helper, bool edit,
            bool canPage = true, bool canSort = true, bool countRec = false) where TModel : class
        {
            return new TableBuilder<TModel>(helper, TableType.SimpleTable, edit, canPage, canSort, countRec);
        }

		public static MultiformBuilder<TModel> MultiformFor<TModel>(this HtmlHelper helper, bool edit = true, bool canFilter = true, bool canPage = true) 
            where TModel : class
        {
            return new MultiformBuilder<TModel>(helper, TableType.Multiform, edit, canFilter, canPage);
        }
		
        public static CheckListBuilder<TModel> CheckListFor<TModel>(this HtmlHelper helper, bool edit) where TModel : class 
        {
            return new CheckListBuilder<TModel>(helper, TableType.CheckList, edit);
        }
		
		public static TimelineBuilder<TModel> TimelineFor<TModel>(this HtmlHelper helper, bool edit) where TModel : class
        {
            return new TimelineBuilder<TModel>(helper, edit);
        }
    }
}