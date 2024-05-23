using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Filtering;
using GenioMVC.Helpers.Table.Properties;

namespace GenioMVC.Helpers.Table.Builder
{
    public class TableList<TModel> : DbEdit<TModel>
        where TModel : class
    {
		public bool HasExtendedHelpForm { get; protected set; }
        public string extendedHelpFormController { get; protected set; }
        public string extendedHelpFormAjaxContainer { get; protected set; }

        public TableList()
        {

        }
        public TableList(Table<TModel> builder, bool hasFilters)
            : base(builder, hasFilters)
        {
            // Table List
            this.HasExtendedHelpForm = false;
            this.extendedHelpFormController = "";
            this.extendedHelpFormAjaxContainer = "";
        }

        public void SetRequestLink(string link)
        {
            this.requestsLink = link;
        }
		
		public void SetExtendedForm(string controller, string ajaxContainer)
        {
            HasExtendedHelpForm = true;
            this.extendedHelpFormController = controller;
            this.extendedHelpFormAjaxContainer = ajaxContainer;
        }
    }
}