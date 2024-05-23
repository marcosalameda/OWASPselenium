using CSGenio.business;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace GenioMVC.Helpers
{
    public static partial class HtmlHelperExtensions
    {
        /// <summary>
        /// A type that encapsulates the method to retrieve information
        /// about an the array element.
        /// </summary>
        /// <param name="cod">The cod.</param>
        /// <returns></returns>
        public delegate ArrayElement GetArrayElement(string cod);

        public static MvcHtmlString ArrayDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, SelectList selectList, GetArrayElement getArrayElement, string optionLabel, object htmlAttributes)
        {
            //Obtain the value
            var value = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).Model; 
            value = value ?? "";
            return SelectInternal(htmlHelper, value.ToString(), ExpressionHelper.GetExpressionText(expression), selectList, getArrayElement, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        private static MvcHtmlString SelectInternal(this HtmlHelper htmlHelper, string value, string name, SelectList selectList, GetArrayElement getArrayElement, IDictionary<string, object> htmlAttributes)
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            
            if (String.IsNullOrEmpty(fullName))
                throw new ArgumentException("No name");

            if (selectList == null)
                throw new ArgumentException("No selectlist");

            // Convert each ListItem to an <option> tag
            StringBuilder listItemBuilder = new StringBuilder();
            //Add empty option do allow deselection
            listItemBuilder.Append(new TagBuilder("option").ToString());
            
            foreach (SelectListItem item in selectList)
            {
                item.Selected = (item.Value == value);
                listItemBuilder.Append(ListItemToOption(item, getArrayElement));
            }

            TagBuilder tagBuilder = new TagBuilder("select")
            {
                InnerHtml = listItemBuilder.ToString()
            };
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("name", fullName, true /* replaceExisting */);
            tagBuilder.GenerateId(fullName);

            // If there are any errors for a named field, we add the css attribute.
            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState))
            {
                if (modelState.Errors.Count > 0)
                {
                    tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
                }
            }

            tagBuilder.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name));

            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// Converts a list item to HTML.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="getArrayElement">The get array element.</param>
        /// <returns></returns>
        internal static string ListItemToOption(SelectListItem item, GetArrayElement getArrayElement)
        {
            TagBuilder builder = new TagBuilder("option")
            {
                InnerHtml = HttpUtility.HtmlEncode(item.Text)
            };
            if (item.Value != null)
            {
                builder.Attributes["value"] = item.Value;
            }
            if (item.Selected)
            {
                builder.Attributes["selected"] = "selected";
            }

            ArrayElement element = getArrayElement(item.Value);
            if(element != null)
            {
                builder.Attributes["title"] = Helpers.GetTextFromResources(element.HelpId);                
                builder.Attributes["group"] = element.Group;
            }
            return builder.ToString(TagRenderMode.Normal);
        }
    }
}
