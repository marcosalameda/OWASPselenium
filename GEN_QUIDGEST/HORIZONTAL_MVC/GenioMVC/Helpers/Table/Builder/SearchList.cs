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
    public class SearchList<TModel> : Table<TModel>
        where TModel : class
    {

        public FormProperties Form { get; protected set; }
        public string FormController { get; protected set; }

        public SearchList()
        {
        }
        public SearchList(Table<TModel> builder)
        {
            this.ajaxUpdateContainerId = builder.ajaxUpdateContainerId;
            this.Data = builder.Data;
            this.DefaultSorter = builder.DefaultSorter;
            this.hasPagination = builder.hasPagination;
            this.hasSorting = builder.hasSorting;
            this.HtmlHelper = builder.HtmlHelper;
            this.HttpContext = builder.HttpContext;
            this.HttpRequest = builder.HttpRequest;
            this.Pager = builder.Pager;
            this.requestsLink = builder.requestsLink;
            this.Sorter = builder.Sorter;
            this.TableColumns = builder.TableColumns;
            this.TableId = builder.TableId;
            this.TableKey = builder.TableKey;
            this.TableType = builder.TableType;
            this.useAjax = builder.useAjax;
            this.TableCssClass = builder.TableCssClass;
            this.hasCounter = builder.hasCounter;
            this.IsInEditMode = builder.IsInEditMode;

            // Search Result List
            this.Form = new FormProperties(null, false, false);
        }

        ///
        public void SetForm(string helpForm, string controller, bool openInPopup, bool repeatInsertion)
        {
            this.Form = new FormProperties(helpForm, openInPopup, repeatInsertion);
            this.FormController = controller;
        }

        public bool HasFiles() 
        {
            return (this.TableColumns.Where(x => x.IsDocument == true).Count() != 0);
        }

        public bool HasHelpForm() { return !string.IsNullOrEmpty(this.Form.HelpForm); }


        internal override void DoInternalActions()
        {
            base.DoInternalActions();
        }

    }
}