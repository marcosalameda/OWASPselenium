using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Helpers.Table.Renderer;

namespace GenioMVC.Helpers.Table
{
    public class GridTableListBuilder<TModel> : IGridTableListBuilder <TModel> where TModel : class
    {
        public Table<TModel> _builder { get; set; }
        public GridTableList<TModel> Builder
        {
            get { return (GridTableList<TModel>)_builder; }
        }

        internal GridTableListBuilder(Table<TModel> builder)
        {
            _builder = new GridTableList<TModel>(builder);

            if(_builder.IsInEditMode)
                this.Builder.TableColumns.Insert(0, new TableColumn<TModel, object>(checkListColumn: true));
        }

        #region Builder Methods

        /// Set Help Form
        public GridTableListBuilder<TModel> Form<TViewModel>(string formPartialView) where TViewModel : class
        {
            this.Builder.SetFormPartialView<TViewModel>(formPartialView);
            return this;
        }

        /// Set Request Link
        public GridTableListBuilder<TModel> RequestLink(string url)
        {
            this.Builder.SetRequestLink(url);
            return this;
        }

        /// Set SaveAction Link
        public GridTableListBuilder<TModel> SaveActionLink(string url)
        {
            this.Builder.SetSaveActionLink(url);
            return this;
        }

        /// Set DeleteAction Link
        public GridTableListBuilder<TModel> DeleteActionLink(string url)
        {
            this.Builder.SetDeleteActionLink(url);
            return this;
        }

        /// Set InsertAction Link
        public GridTableListBuilder<TModel> InsertActionLink(string url)
        {
            this.Builder.SetInsertActionLink(url);
            return this;
        }

        /// Set Data KeyName
        public GridTableListBuilder<TModel> DataKeyName(string name)
        {
            this.Builder.SetDataKeyName(name);
            return this;
        }
		
		/// Set ForeignKey Data (Name and Value)
        public GridTableListBuilder<TModel> ForeignKeyData(string name, string value)
        {
            this.Builder.SetForeignKeyData(name, value);
            return this;
        }

        #endregion GridTableListBuilder Methods

        /// <summary>
        /// Convert the GridTableListBuilder to HTML.
        /// </summary>
        public MvcHtmlString ToHtml()
        {
            this.Builder.DoInternalActions();

            return new GridTableListRenderer<TModel>(this.Builder).ToHtml();
        }
    }
}