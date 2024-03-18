using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Utils;
using System.Web.Routing;
using System.Web.Mvc.Html;
using System.Text;

namespace GenioMVC.Helpers.Table.Renderer
{
    public class MultiformRenderer<TModel> : TableRenderer<TModel> where TModel : class
    {
        new private Multiform<TModel> Builder { get; set; }

        public FilterRenderer<TModel> FilterRenderer { get; protected set; }

        public MultiformRenderer(Table<TModel> builder) : base(builder) {
            this.Builder = builder as Multiform<TModel>;
        }

        protected override TagBuilder Header()
        {
            // Add search box

            TagBuilder container = new TagBuilder("div");
            container.AddCssClass("search");

            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("input-group i-input-group");

            TagBuilder input = new TagBuilder("input");
            input.AddCssClass("form-control i-input-group__field");
            input.Attributes.Add("type", "text");
            input.Attributes.Add("value", this.Builder.Query);
            input.Attributes.Add("id", "q" + this.Builder.TableId);

            TagBuilder divButton = new TagBuilder("div");
            divButton.AddCssClass("i-input-group--right");

            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("btn i-input-group__button--primary");
            span.Attributes.Add("data-search-btn", "true");

            TagBuilder i = new TagBuilder("i");
            i.AddCssClass("glyphicons glyphicons-search i-input-group__tag-icon i-input-group__button-icon");

            span.InnerHtml += i;
            divButton.InnerHtml += span;
            
            div.InnerHtml += input;
            div.InnerHtml += divButton;

            container.InnerHtml += div;

            return container;
        }

        protected override TagBuilder Body()
        {
            // Add multiforms
            TagBuilder div = new TagBuilder("div");

            if (this.Builder.Permissions.CanEdit) {			
				div.Attributes.Add("elem-identifier", "MultiformEditable");
                div.AddCssClass("multiform-editable");
            }			
			
            foreach (TModel model in Builder.Data)
            {
                div.InnerHtml += this.Builder.HtmlHelper.Partial(this.Builder.BuilderForm, model); 
            }

            return div;
        }

        protected override TagBuilder Footer()
        {
            // Add footer
            TagBuilder div = new TagBuilder("div");
			div.AddCssClass("mt-4");
            div.InnerHtml += AddInsert();

            if (this.Builder.hasPagination)
                div.InnerHtml += PagerRenderer.ToHtml();

            return div;
        }

        protected override MvcHtmlString EmptyList(bool hasActionsCol = false)
        {
            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("alert");
            div.InnerHtml += AddInsert();
            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("emptyList");
            span.InnerHtml = " &lt;" + TableString.EmptyList.ToString() + "&gt;";
            TagBuilder div2 = new TagBuilder("div");
            div2.InnerHtml = span.ToString();
            div2.GenerateId(this.Builder.TableId + "emptyList");
            div.InnerHtml += div2.ToString();
            return new MvcHtmlString(div.ToString());
        }

        protected virtual MvcHtmlString AddInsert()
        {
            string buttonStr = "";
            if (this.Builder.Permissions.CanInsert)
            {
                TagBuilder icon = new TagBuilder("i");
                icon.AddCssClass("glyphicons glyphicons-plus-sign e-icon");
                TagBuilder button = new TagBuilder("button");
                button.AddCssClass("b-icon-text b-icon-text--secondary");
                button.InnerHtml += icon.ToString();
                button.InnerHtml += (TableString.Insert.ToString());
                button.Attributes.Add("data-target", Builder.ajaxUpdateContainerId);
                button.Attributes.Add("data-mode", "insert");
                button.Attributes.Add("data-link", Builder.InsertLink);
                button.Attributes.Add("type", "button");
                button.Attributes.Add("qbutton", "insert");
                buttonStr = button.ToString();
            }
            return new MvcHtmlString(buttonStr);
        }

        ////is this needed?
        //protected override TagBuilder GenerateHiddenFields()
        //{
        //    TagBuilder tHead = base.Header();

        //    if (this.Builder.hasFilters)
        //    {
        //        tHead.InnerHtml += this.FilterRenderer.GenerateHeaderFilterRow();
        //    }

        //    return tHead;
        //}

        ////is this needed?
        //protected override TagBuilder GenerateScripts()
        //{
        //    TagBuilder tHead = base.Header();

        //    if (this.Builder.hasFilters)
        //    {
        //        tHead.InnerHtml += this.FilterRenderer.GenerateHeaderFilterRow();
        //    }

        //    return tHead;
        //}

        /// <summary>
        /// Convert the TableBuilder to HTML.
        /// </summary>
        /// 

        protected override MvcHtmlString GenerateScripts()
        {
            string script = @"
            $(document).ready(function(){
                window." + this.Builder.TableId + @" = $('#" + this.Builder.TableId + @"').tableFor({
                    requestsUrl: '" + HttpUtility.JavaScriptStringEncode(this.Builder.requestsLink) + @"',
                    container: '" + this.Builder.ajaxUpdateContainerId + @"',
                    tableType: '" + this.Builder.TableType.ToString() + @"',
                    pageField: '" + HttpUtility.JavaScriptStringEncode(this.pageInput) + @"',
                    sortField: '" + HttpUtility.JavaScriptStringEncode(this.sortInput) + @"',
                    sortDirField: '" + HttpUtility.JavaScriptStringEncode(this.sortDirInput) + @"'
                });

                $.Multiforms()
            });
            // Add insert action to multiform
//            $(""button[data-mode='insert']"",'.multiform').off('click').click(function() {
//                var btn = $(this);
//                var target = btn.data('target');
//                var link = btn.data('link');
//                insertMultiForm(link, target);
//            })";

            return new MvcHtmlString(script);
        }

        public override MvcHtmlString ToHtml(bool hidden = false)
        {
            StringBuilder result = new StringBuilder();

            //add searchbox if it exists
            TagBuilder div = new TagBuilder("div");
			div.Attributes.Add("elem-identifier", "MultiformContainer");
			
			if (this.Builder.Permissions.CanEdit)
				div.Attributes.Add("data-mf-editable", Builder.IsInEditMode.ToString().ToLower());
            
			div.AddCssClass("multiform-container");
            div.Attributes.Add("id", Builder.TableId);

            //div.InnerHtml += Header();

            if (Builder.Data.Count() > 0)
            {
                div.InnerHtml += Body();
                div.InnerHtml += Footer();
            }
            else
                div.InnerHtml += EmptyList();

            TagBuilder divHiddenFields = new TagBuilder("div");
            divHiddenFields.MergeAttribute("id", Builder.TableId + "_inputs");
            divHiddenFields.InnerHtml = GenerateHiddenFields().ToHtmlString();

            return new MvcHtmlString(div.ToString() + divHiddenFields.ToString() + "<script>" + GenerateScripts().ToHtmlString() + "</script>");
        }
    }
}
