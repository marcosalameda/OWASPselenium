using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using GenioMVC.Helpers.Table.Builder;

namespace GenioMVC.Helpers
{
    public static class ColorPickerHelper
    {
        public static MvcHtmlString ColorPicker<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlProperties = null)
        {
            var formMode = html.ViewData.Model is ViewModels.ViewModelBase ? (html.ViewData.Model as ViewModels.ViewModelBase).GetFormMode : "show";
            MvcHtmlString body;
            var htmlProp = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlProperties);
            if (!htmlProp.ContainsKey("class"))
                htmlProp.Add("class", "");
            if (formMode == "show" || formMode == "delete")
            {
                ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
                var value = (string)metadata.Model ?? "transparent";
                TagBuilder div = new TagBuilder("div");
                div.AddCssClass("input-group i-input-group");

                htmlProp["class"] = "form-control " + htmlProp["class"] + " i-input-group__field";
                body = html.DisplayForWithNull(expression, htmlProp);
                div.InnerHtml += body;                

                var divAddOn = new TagBuilder("div");
                divAddOn.AddCssClass("input-group-append i-input-group--right");
                TagBuilder span = new TagBuilder("span");
                span.AddCssClass("input-group-text i-input-group__tag");
                TagBuilder i = new TagBuilder("i");
                i.AddCssClass("i-color-picker__current-color");
                i.Attributes.Add("style", string.Format("background-color: {0};", value));
                span.InnerHtml += i;

                divAddOn.InnerHtml += span;
                div.InnerHtml += divAddOn;

                return MvcHtmlString.Create(div.ToString(TagRenderMode.Normal));
            }
            else
            {
                TagBuilder div = new TagBuilder("div");
                div.AddCssClass("input-group i-input-group i-color-picker colorpicker-component");

                htmlProp["class"] = "form-control " + htmlProp["class"] + " i-input-group__field i-date-picker__field";
                body = html.TextBoxFor(expression, htmlProp);
                div.InnerHtml += body;
                
                var divAddOn = new TagBuilder("div");
                divAddOn.AddCssClass("input-group-append i-input-group--right i-color-picker__button");
                var btn = new TagBuilder("buton");
                btn.AddCssClass("btn b-icon--secondary i-color-picker__button--secondary ColorPicker-Size");

                TagBuilder span = new TagBuilder("span");
                span.AddCssClass("i-input-group__tag-icon i-color-picker__add-on");

                btn.InnerHtml += span;
                divAddOn.InnerHtml += btn;
                div.InnerHtml += divAddOn;
                return MvcHtmlString.Create(div.ToString(TagRenderMode.Normal));
            }
        }

        #region Só para não ter error de compilação
        public static ColorPickerBuilder<TModel> ColorPicker<TModel>(this HtmlHelper helper) where TModel : class
        {
            return null;
        }
        #endregion
    }
    #region Só para não ter error de compilação
    public class ColorPickerBuilder<TModel> where TModel : class
    {
        public ColorPickerBuilder(Table<TModel> builder, bool hasFilters) { }

        public MvcHtmlString ToColorPickerHtml()
        {
            return MvcHtmlString.Create("Not supported");
        }
    }
    #endregion
}