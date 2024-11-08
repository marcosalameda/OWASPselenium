using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Properties;
using Newtonsoft.Json;

namespace GenioMVC.Helpers.Table.Utils
{
    public static class TableUtils
    {
        public static int CalculateTableSize<TModel>(IList<ITableColumnInternal<TModel>> columns) where TModel : class
        {
            int result = 0;
            foreach (ITableColumnInternal<TModel> tc in columns.Where(x=>x.ColumnVisible))
            {
                result += tc.ColumnSize;
            }
            return result;
        }
        public static TagBuilder MakeActionLinkImg<TModel>(HtmlHelper h, string action, RouteValueDictionary routeValues, string text, object htmlAttributes, string controller = null) where TModel : class
        {//MARA ALTERADO
            TagBuilder a = new TagBuilder("a");
            a.Attributes.Add("href", (new UrlHelper(h.ViewContext.RequestContext)).Action(action, controller ?? typeof(TModel).Name, routeValues));

            IDictionary<string, object> attrs = null;

            if (htmlAttributes is Dictionary<string, object>)
                attrs = (Dictionary<string, object>)htmlAttributes;
            else
                attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            a.MergeAttributes(attrs);


            return a;
        }


        public static string GetPath<TModel>(Table<TModel> table, NameValueCollection queryString) where TModel : class
        {
            NameValueCollection temp = new NameValueCollection(table.HttpRequest.QueryString);
            string page = table.TableId + table.Pager.qsPageNumber;

            if (!String.IsNullOrEmpty(queryString[page]))
                temp.Set(page, (queryString[page]));

            string sort = table.TableId + table.Sorter.qsSortColumn;
            string sortDir = table.TableId + table.Sorter.qsSortDirection;
            if (!String.IsNullOrEmpty(queryString[sort]))
            {
                temp.Set(sort, queryString[sort]);
                temp.Set(sortDir, queryString[sortDir]);
            }

            queryString = temp;

            /*
                This method seems to be used only in special cases when the list does not have Ajax requests to the server.
                The way this method creates URLs is incorrect because it ends up concatenationg the string, resulting in a URL with two query string,
                    since the base address already has the `?nav=...` parameter.
            */
            StringBuilder sb = new StringBuilder(HttpUtility.JavaScriptStringEncode(table.requestsLink));

            sb.Append("?");
            for (int i = 0; i < queryString.Count; i++)
            {
                if (i > 0)
                {
                    sb.Append("&");
                }
                sb.Append(HttpUtility.UrlEncode(queryString.Keys[i]));
                sb.Append("=");
                sb.Append(HttpUtility.UrlEncode(queryString[i]));
            }
            return sb.ToString();
        }

        public static TagBuilder MakeActionLink<TModel>(HtmlHelper h, string action, string controller, TModel model, Func<TModel, object> routeValuesFun, string text, bool isRoutine, object htmlAttributes) where TModel : class {            
            return MakeActionLink(h, action, controller, routeValuesFun(model), text, isRoutine, htmlAttributes);
        }
		
        public static TagBuilder MakeActionLink(HtmlHelper h, string action, string controller, object routeValues, string text, bool isRoutine, object htmlAttributes)
        {
            TagBuilder a = new TagBuilder("a");
            //var teste = routeValues as Dictionary<string, object>;
            string url = !isRoutine ? new UrlHelper(h.ViewContext.RequestContext).Action(action, controller, routeValues) : "javascript:void(0)";
            if (isRoutine)
            {
				string jsonParam = JsonConvert.SerializeObject(routeValues);
                jsonParam = System.Text.RegularExpressions.Regex.Replace(jsonParam, @"\""\\/Date\((-?\d+)\)\\/\""", "new Date($1)");

                a.Attributes.Add("routine", action);
                a.Attributes.Add("onclick", action + "(" + jsonParam + ");");
            }

            a.Attributes.Add("href", url);
            IDictionary<string, object> attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            a.MergeAttributes(attrs);

            if (!string.IsNullOrEmpty(text))
                a.InnerHtml = text;
            
            return a;
        }


        public static TagBuilder MakeButtonActionLink<TModel>(HtmlHelper h, string action, RouteValueDictionary routeValues, string text, object htmlAttributes, string controller = null) where TModel : class
        {
            TagBuilder btn = new TagBuilder("button");
            btn.Attributes.Add("type", "button");

            btn.Attributes.Add("href", (new UrlHelper(h.ViewContext.RequestContext)).Action(action, controller ?? typeof(TModel).Name, routeValues));
            IDictionary<string, object> attrs = null;
            if (htmlAttributes is Dictionary<string, object>)
                attrs = (Dictionary<string, object>)htmlAttributes;
            else
                attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            btn.MergeAttributes(attrs);

            if (!string.IsNullOrEmpty(text))
                btn.InnerHtml = text;

            return btn;
        }		
		
        public static TagBuilder MakeActionLink<TModel>(HtmlHelper h, string action, RouteValueDictionary routeValues, string text, object htmlAttributes, string controller = null) where TModel : class
        {
            TagBuilder a = new TagBuilder("a");

            a.Attributes.Add("href", (new UrlHelper(h.ViewContext.RequestContext)).Action(action, controller ?? typeof(TModel).Name, routeValues));
            IDictionary<string, object> attrs = null;
            if(htmlAttributes is Dictionary<string, object>)
                attrs = (Dictionary<string, object>) htmlAttributes;
            else
                attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            
			a.MergeAttributes(attrs);

            if (!string.IsNullOrEmpty(text))
            {
                TagBuilder span = new TagBuilder("span");
                span.AddCssClass("view-text");
                span.InnerHtml = text;
                
                a.InnerHtml += span;
            }

            return a;
        }

        public static TagBuilder MakeActionLink<TModel>(HtmlHelper htmlHelper, string action, string controller, string title, RouteValueDictionary htmlAttributes)
        {
            TagBuilder a = new TagBuilder("a");

            a.Attributes.Add("href", (new UrlHelper(htmlHelper.ViewContext.RequestContext)).Action(action, controller ?? typeof(TModel).Name));
            IDictionary<string, object> attrs = htmlAttributes;
            if (!(htmlAttributes is RouteValueDictionary))
                attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            a.MergeAttributes(attrs);

            if (!string.IsNullOrEmpty(title))
                a.InnerHtml = title;

            return a;
        }

        public static TagBuilder MakeIcon(HtmlHelper h, string icon, bool fromBootstrap = false)
        {
            TagBuilder htmlIcon = new TagBuilder("i");

            if ( (fromBootstrap && icon == "") || icon == null)
            {
                htmlIcon.AddCssClass("glyphicons glyphicons-arrow-right");
                return htmlIcon;
            }
            else if (fromBootstrap && !string.IsNullOrEmpty(icon))
            {
                htmlIcon.AddCssClass(icon + " dropdown__icon");
                return htmlIcon;
            }
            else
            {
                if (!string.IsNullOrEmpty(icon))
                {
                    string imgUrl = UrlHelper.GenerateContentUrl("~/Content/img/" + icon, h.ViewContext.RequestContext.HttpContext);
                    //htmlIcon.AddCssClass("icon-custom " + icon);
                    htmlIcon.AddCssClass(icon + " dropdown__icon");
                    htmlIcon.MergeAttribute("style", "background-image: url(\"" + imgUrl + "\"); background-size: 14px; background-position: 0; width:14px; height:14px; margin:0 3px 0 0;");
                }                    
                return htmlIcon;
            }           
        }

        public static TableAction<TModel> GetFollowUpAction<TModel>(IList<TableAction<TModel>> tableActions, bool isSpecificPaths = false) where TModel : class
        {
            var fActions = from tAction in tableActions
                        where tAction.IsFollowUp
                        select tAction;

            return fActions.Count() > 0 ? fActions.First() : null; 
        }

        public static TableAction<TModel> GetSepecificPathsFollowUpAction<TModel>(IList<TableAction<TModel>> tableActions) where TModel : class
        {
            var fActions = from tAction in tableActions
                           where tAction.IsFollowUp && tAction.IsSpecificPaths
                           select tAction;

            return fActions.Count() > 0 ? fActions.First() : null; 
        }

        public static IList<TableAction<TModel>> GetTableActions<TModel>(IList<TableAction<TModel>> tableActions) where TModel : class
        {
            return tableActions.Where(x => !x.IsFollowUp && !x.RequiresMultipleSelection).ToList();
        }

        public static TagBuilder GetTableHeaderRowCheckBox(string tableId, string all_rec, string curr_page, string none)
        {
            /* Dropdown menu */
            var all_records_menuItem = new TagBuilder("a");
            all_records_menuItem.GenerateId("ddp_all_records");
            var current_records_menuItem = new TagBuilder("a");
            current_records_menuItem.GenerateId("ddp_current_records");
            var none_menuItem = new TagBuilder("a");
            none_menuItem.GenerateId("ddp_none");

            all_records_menuItem.AddCssClass("dropdown-item");
            current_records_menuItem.AddCssClass("dropdown-item");
            none_menuItem.AddCssClass("dropdown-item");            

            var div_menu = new TagBuilder("div");
            div_menu.AddCssClass("dropdown-menu");
            div_menu.GenerateId("q-table-selector-dropdown");
            div_menu.Attributes.Add("data-ddp-tableid", "btn-ddp-" + tableId);
            var ddp_icon = new TagBuilder("i");

            ddp_icon.Attributes["class"] = "";            
            ddp_icon.AddCssClass("glyphicons glyphicons-ok-sign dropdown__icon");

            all_records_menuItem.InnerHtml = ddp_icon.ToString();
            all_records_menuItem.InnerHtml += all_rec;
            div_menu.InnerHtml += all_records_menuItem.ToString();

            ddp_icon.Attributes["class"] = "";
            ddp_icon.AddCssClass("glyphicons glyphicons-check dropdown__icon");

            current_records_menuItem.InnerHtml = ddp_icon.ToString();
            current_records_menuItem.InnerHtml += curr_page;
            div_menu.InnerHtml += current_records_menuItem.ToString();

            ddp_icon.Attributes["class"] = "";
            ddp_icon.AddCssClass("glyphicons glyphicons-remove-sign dropdown__icon");

            none_menuItem.InnerHtml = ddp_icon.ToString();
            none_menuItem.InnerHtml += none;
            div_menu.InnerHtml += none_menuItem.ToString();
            /* ------------ */

            /* Button */
            var icon = new TagBuilder("i");
            icon.AddCssClass("glyphicons glyphicons-unchecked main-check-icon");

            var btn = new TagBuilder("button");
            btn.Attributes.Add("type", "button");
            btn.Attributes.Add("data-toggle", "dropdown");
            btn.Attributes.Add("aria-haspopup", "true");
            btn.Attributes.Add("aria-expanded", "false");
            btn.AddCssClass("dropdown-toggle");
            btn.Attributes.Add("id", "btn-ddp-" + tableId);
            btn.InnerHtml = icon.ToString();
            /* ------ */

            /* Final Build */
            var div_main = new TagBuilder("div");
            div_main.AddCssClass("dropdown");
            div_main.InnerHtml += btn.ToString();
            div_main.InnerHtml += div_menu.ToString();
            /* ----------- */

            return div_main;
        }

        public static TagBuilder GetTableRowCheckBox()
        {
            //var i = new TagBuilder("i");
            //i.AddCssClass("q-table-cr-icon icon-ok");

            var span = new TagBuilder("span");
            span.AddCssClass("i-checkbox__field");
            //span.InnerHtml += i;

            var input = new TagBuilder("input");
            input.Attributes.Add("type", "checkbox");
            input.Attributes.Add("value", "");

            var lable = new TagBuilder("label");
            lable.AddCssClass("i-checkbox i-checkbox__label");
            lable.Attributes.Add("style", "font-size: 1.5em");
            lable.InnerHtml += input.ToString(TagRenderMode.SelfClosing);
            lable.InnerHtml += span;

            var div = new TagBuilder("div");
			div.Attributes.Add("elem-identifier", "QTableCheckbox");
            div.AddCssClass("q-table-checkbox");
            div.InnerHtml += lable;

            return div;
        }

        /// <summary>
        /// Create a div with menu divider element 
        /// </summary>
        /// <returns>Divider element</returns>
        public static TagBuilder GetDropdownDivider()
        {
            TagBuilder divider = new TagBuilder("div");
            divider.AddCssClass("dropdown-divider");
            return divider;
        }
    }
}