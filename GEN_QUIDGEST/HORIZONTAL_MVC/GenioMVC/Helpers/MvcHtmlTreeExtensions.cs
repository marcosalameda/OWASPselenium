using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenioMVC.Helpers
{
    public static class MvcHtmlTreeExtensions
    {
        /// <summary>
        /// Return an instance of a TreeBuilder.
        /// </summary>
        /// <typeparam name="TModel">Type of model to render in the tree.</typeparam>
        /// <returns>Instance of a TreeBuilder.</returns>
        public static ITreeBuilder TreeFor(this HtmlHelper helper, bool edit)
        {
            return new TreeBuilder(helper, edit);
        }

        /// <summary>
        /// Returns the scripts associated with this tree control
        /// </summary>
        /// <param name="helper">The extention variable</param>
        /// <param name="id">The id of the tree control</param>
        /// <returns>The script associated with the tree control</returns>
        public static MvcHtmlString TreeScriptFor(this HtmlHelper helper, string id)
        {
            TagBuilder script = new TagBuilder("script");
            script.Attributes.Add("type", "text/javascript");
            script.InnerHtml = @"$(function() {
                        var " + id + @" = TreeTable($('#" + id + @" table'));
                    });";
            return MvcHtmlString.Create(script.ToString(TagRenderMode.Normal));
        }
    }
}