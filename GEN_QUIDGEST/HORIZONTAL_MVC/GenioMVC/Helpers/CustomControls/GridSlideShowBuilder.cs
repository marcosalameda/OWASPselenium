using System.Web.Mvc;
using GenioMVC.Helpers.Table;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Helpers.Table.Renderer;


namespace GenioMVC.Helpers
{

    public static class GridSlideShowHelper
    {
        public static GridSlideShowBuilder<TModel> GridSlideShow<TModel>(this HtmlHelper helper, bool edit, bool canPage = true, bool canSort = true, bool countRec = false) where TModel : class
        {
            Table<TModel> builder = new Table<TModel>(helper, TableType.SimpleTable, edit, canPage, canSort, countRec);
            TableList<TModel> ListBuilder = new TableList<TModel>(builder, false);
            return new GridSlideShowBuilder<TModel>(ListBuilder, false);
        }
    }
    public class GridSlideShowBuilder<TModel> : TableListBuilder<TModel> where TModel : class
    {
        internal GridSlideShowBuilder(Table<TModel> builder, bool hasFilters)
            : base(builder, hasFilters)
        {
            var permissoes = ((TableList<TModel>)builder).Permissions;
            ((TableList<TModel>)_builder).SetPermissions(permissoes.CanView, permissoes.CanInsert, permissoes.CanEdit, permissoes.CanDuplicate, permissoes.CanDelete);
            var form = ((TableList<TModel>)builder).Form;
            ((TableList<TModel>)_builder).SetForm(form.HelpForm, form.OpenInPopup, form.RepeatInsertion);
        }
        /// Convert the GridSlideShow to HTML.
        public MvcHtmlString ToGridSlideShowHtml()
        {
            this.Builder.DoInternalActions();

            return new GridSlideShowRenderer<TModel>(this.Builder).ToHtml();
        }
    }
}