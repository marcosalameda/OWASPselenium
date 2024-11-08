using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using GenioMVC.Models.Navigation;

namespace GenioMVC.Helpers.Table.Builder
{
    public class GridTableList<TModel> : Table<TModel>
        where TModel : class
    {
        public string FormPartialView { get; protected set; }
        public Type ViewModelType { get; protected set; }
        public string DataKeyName { get; protected set; }
		public string DataForeignKeyName { get; protected set; }
		public string DataForeignKeyValue { get; protected set; }
        public string SaveAction { get; protected set; }
        public string DeleteAction { get; protected set; }
        public string InsertAction { get; protected set; }

        public GridTableList()
        {

        }
        public GridTableList(Table<TModel> builder)
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
            this.IsInEditMode = builder.IsInEditMode;

            // Grid List
            this.FormPartialView = null;
            this.SaveAction = null;
            this.DeleteAction = null;
            this.InsertAction = null;
            this.DataKeyName = null;
			this.DataForeignKeyName = null;
			this.DataForeignKeyValue = null;
        }

        public void SetRequestLink(string link)
        {
            this.requestsLink = link;
        }

        public void SetFormPartialView<TViewModel>(string formPartialView) where TViewModel : class
        {
            this.FormPartialView = formPartialView;
            this.ViewModelType = typeof(TViewModel);
        }

        public void SetSaveActionLink(string link)
        {
            this.SaveAction = link;
        }
        public void SetDeleteActionLink(string link)
        {
            this.DeleteAction = link;
        }
        public void SetInsertActionLink(string link)
        {
            this.InsertAction = link;
        }

        public void SetDataKeyName(string keyName)
        {
            this.DataKeyName = keyName;
        }
		
		public void SetForeignKeyData(string fkName, string fkValue)
        {
			this.DataForeignKeyName = fkName;
            this.DataForeignKeyValue = fkValue;
        }
    }
}