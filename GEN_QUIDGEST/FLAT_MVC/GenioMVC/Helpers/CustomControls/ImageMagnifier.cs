using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Helpers.Table.Utils;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table;

namespace GenioMVC.Helpers
{
    public static class ImageMagnifierHelper
    {
        public static ImageMagnifierBuilder<TModel> ImageMagnifier<TModel>(this HtmlHelper helper, bool edit = true, bool canPage = true, bool canSort = true, bool countRec = false) where TModel : class
        {
            Table<TModel> builder = new Table<TModel>(helper, TableType.SimpleTable, edit, canPage, canSort, countRec);
            return new ImageMagnifierBuilder<TModel>(builder, false);
        }
    }

    public class ImageMagnifierBuilder<TModel> : Table.TableListBuilder<TModel> where TModel : class
    {
        public ImageMagnifierBuilder(Table<TModel> builder, bool hasFilters): base(builder, hasFilters)
        {
        }
    }

    public class ImageMagnifierTableRenderer<TModel> : Table.Renderer.TableRenderer<TModel> where TModel : class
    {
        internal ImageMagnifierTableRenderer(Table<TModel> builder): base(builder)
        {
            this.Builder = builder;
        }

        public TableList<TModel> BuilderCast
        {
            get
            {
                return this.Builder as TableList<TModel>;
            }
        }
    }
	
    public static class ImageMagnifier
    {
		public static MvcHtmlString ImageMagnifer<TModel>(this HtmlHelper<TModel> html, byte[] byteArray, string guid, string model, string field, object htmlProperties = null)
        {
            RouteValueDictionary htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlProperties);
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            var ticket = Helpers.GetFileTicket(Models.Navigation.UserContext.Current.User, model, field, "", guid);
            string absUrl = urlHelper.Action("ImageHandlerGet", model, new { ticket });

            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("thumbnails");

            TagBuilder li = new TagBuilder("li");
            object value = null;
            if (htmlAttributes.TryGetValue("class", out value))
                li.AddCssClass(value.ToString());
            else
                li.AddCssClass("span2");
            li.MergeAttributes(htmlAttributes);

            TagBuilder a = new TagBuilder("a");
			a.Attributes.Add("href", absUrl);
            a.AddCssClass("thumbnail magnify-img");

            TagBuilder img = new TagBuilder("img");
            img.Attributes.Add("src", absUrl);
            img.Attributes.Add("id", "thumbnail_" + field);

            a.InnerHtml += img.ToString();

            li.InnerHtml = a.ToString();

            ul.InnerHtml = li.ToString();

            return MvcHtmlString.Create(ul.ToString(TagRenderMode.Normal));
        }
		
		public static MvcHtmlString EditImageMagnifer<TModel>(this HtmlHelper<TModel> html, byte[] byteArray, string guid, string model, string field, object htmlProperties = null)
        {
            var img = ImageMagnifer(html, byteArray, guid, model, field, htmlProperties);

            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("id", "file-uploader_" + field);

            TagBuilder noscript = new TagBuilder("noscript");
            TagBuilder p = new TagBuilder("p");
            p.SetInnerText(Resources.Resources.ATIVE_O_JAVASCRIPT_P25514);
            noscript.InnerHtml = p.ToString();
            div.InnerHtml = noscript.ToString();

            string control = div.ToString(TagRenderMode.Normal);
            control = img.ToHtmlString() + control;
			
            return MvcHtmlString.Create(control);
        }

        private static string flattenHtmlProps(IDictionary<string, object> htmlProperties)
        {
            StringBuilder line = new StringBuilder();
            foreach (var pair in htmlProperties)
                line.Append(" " + pair.Key + "='" + pair.Value + "'");
            return line.ToString();
        }
    }
}