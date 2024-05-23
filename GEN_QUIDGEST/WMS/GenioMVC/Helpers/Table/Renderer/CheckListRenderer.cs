using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Columns;

namespace GenioMVC.Helpers.Table.Renderer
{
    public class CheckListRenderer<TModel> : TableRenderer<TModel> where TModel : class
    {
        new private CheckList<TModel> Builder { get; set; }

        public CheckListRenderer(Table<TModel> builder)
            : base(builder)
        {
            this.Builder = builder as CheckList<TModel>;
        }

        internal override void GenerateOtherCell(TModel model, ITableColumnInternal<TModel> tc, TagBuilder tRow, RouteValueDictionary routeValueDictionary)
        {
             if (tc.ColumnVisible && tc.IsCheckListColumn)
            {
                TagBuilder label = new TagBuilder("label");
                label.AddCssClass("i-checkbox i-checkbox__label");
				label.Attributes.Add("title", Resources.Resources.SELECIONE_UM_REGISTO53934);

                TagBuilder input = new TagBuilder("input");

                input.Attributes.Add("type", "checkbox");
                input.Attributes.Add("value", this.Builder.TableKey.Evaluate(model));
                input.Attributes.Add("name", this.Builder.CheckListName.Substring(0, this.Builder.CheckListName.Length - 4) + "_SelectedIds");
				input.Attributes.Add("data-checklist", "true");

                if (this.Builder.SelectedRows.Contains(this.Builder.TableKey.Evaluate(model)))
                    input.Attributes.Add("checked", "");

                if (!this.Builder.IsInEditMode)
                {
                    label.AddCssClass("i-checkbox--disabled");
                    input.Attributes.Add("disabled", "disabled");
                }

                label.InnerHtml += input;
                TagBuilder span = new TagBuilder("span");
                span.AddCssClass("i-checkbox__field");
                label.InnerHtml += span;

                tRow.MergeAttribute("data-checked", this.Builder.SelectedRows.Contains(this.Builder.TableKey.Evaluate(model)).ToString().ToLowerInvariant());
                TagBuilder tCell = new TagBuilder("td");
                tCell.InnerHtml += label;
                tRow.InnerHtml += tCell;
            }
        }

        protected override MvcHtmlString GenerateScripts()
        {
            StringBuilder scriptBase = new StringBuilder(base.GenerateScripts().ToHtmlString());

            int lastquote = scriptBase.ToString().LastIndexOf("'");

            string newScript = @",
                    isExtended: " + this.Builder.IsExtended.ToString().ToLowerInvariant() + @",
                    extentedControlId: '" + this.Builder.CheckListExtendedName + "'";

            scriptBase.Insert(lastquote + 1, newScript);

            return new MvcHtmlString(scriptBase.ToString());
        }
    }
}