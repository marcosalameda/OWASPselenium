using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Filtering;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Helpers.Table.Renderer;
using GenioMVC.Helpers.Table.Sorting;

namespace GenioMVC.Helpers.Table
{
    public class SearchListBuilder<TModel> : TableBuilder<TModel>, ITableListBuilder<TModel> where TModel : class
    {
        public new SearchList<TModel> Builder
        {
            get { return (SearchList<TModel>)_builder; }
        }

        internal SearchListBuilder(Table<TModel> builder)
            : base(builder.HtmlHelper, TableType.SearchList, builder.IsInEditMode, true, true)
        {
            _builder = new SearchList<TModel>(builder);
        }

        #region Builder Methods
		
        /// Set Help Form
        public SearchListBuilder<TModel> Form(string helpForm, string formController, bool openInPopup = false, bool repeatInsertion = false)
        {
            this.Builder.SetForm(helpForm, formController, openInPopup, repeatInsertion);
            return this;
        }
		
        #endregion Builder Methods

        /// <summary>
        /// Convert the DbEditBuilder to HTML.
        /// </summary>
        public new MvcHtmlString ToHtml()
        {           
            this.Builder.DoInternalActions();

            return new SearchListRenderer<TModel>(this.Builder).ToHtml();
        }
    }
}