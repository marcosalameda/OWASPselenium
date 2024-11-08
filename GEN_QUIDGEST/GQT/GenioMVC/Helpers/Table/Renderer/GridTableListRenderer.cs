using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Helpers.Table.Scripts;
using GenioMVC.Helpers.Table.Utils;

namespace GenioMVC.Helpers.Table.Renderer
{
    public class GridTableListRenderer<TModel> : TableRenderer<TModel> where TModel : class
    {
        new private GridTableList<TModel> Builder { get; set; }
        private string newRowTemplate = null;

        public GridTableListRenderer(Table<TModel> builder)
            : base(builder)
        {
            this.Builder = builder as GridTableList<TModel>;

            TagBuilder tCell = new TagBuilder("td");
            tCell.MergeAttribute("style", "padding-top: 7px;");
            tCell.InnerHtml = "<i class='glyphicons glyphicons-plus-sign e-icon'></i>";
            newRowTemplate = tCell.ToString();

            TModel model = Activator.CreateInstance<TModel>();
            Object viewModel = Activator.CreateInstance(this.Builder.ViewModelType, new object[] { model, this.Builder.Navigation, true });
            newRowTemplate += Regex.Replace(this.Builder.HtmlHelper.Partial(this.Builder.FormPartialView, viewModel).ToHtmlString(), @"\t|\n|\r", "");
        }

        protected override TagBuilder Body()
        {
            if (this.Builder.IsInEditMode && !String.IsNullOrEmpty(this.Builder.SaveAction))
            {
                TagBuilder tBody = new TagBuilder("tbody");
                tBody.AddCssClass("c-table__body");

                foreach (TModel model in Builder.Data)
                {
                    PropertyInfo key_property = model.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(KeyAttribute))).FirstOrDefault();
                    RouteValueDictionary routeValueDictionary = new RouteValueDictionary();

                    routeValueDictionary.Add("id", Builder.TableKey.Evaluate(model));

                    TagBuilder tRow = new TagBuilder("tr");
                    tRow.MergeAttribute("data-key", this.Builder.TableKey.Evaluate(model));
                    GenerateOtherCell(model, this.Builder.TableColumns.Where(x => x.IsCheckListColumn).First(), tRow, routeValueDictionary);
                    tRow.InnerHtml += GenerateBodyCell(model);
                    tBody.InnerHtml += tRow;
                }

                return tBody;
            }
            else
            {
                return base.Body();
            }
        }

        public MvcHtmlString GenerateBodyCell(TModel model)
        {
            Object viewModel = Activator.CreateInstance(this.Builder.ViewModelType, new object[] { model, this.Builder.Navigation, true });
            return this.Builder.HtmlHelper.Partial(this.Builder.FormPartialView, viewModel);
        }

        internal override void GenerateOtherCell(TModel model, GenioMVC.Helpers.Table.Columns.ITableColumnInternal<TModel> tc, TagBuilder tRow, RouteValueDictionary routeValueDictionary)
        {
            if (tc.ColumnVisible && tc.IsCheckListColumn)
            {
                TagBuilder label = new TagBuilder("label");
                TagBuilder input = new TagBuilder("input");

                input.Attributes.Add("type", "checkbox");
                input.Attributes.Add("data-gridtablelist", "true");
                input.Attributes.Add("value", this.Builder.TableKey.Evaluate(model));

                if (!this.Builder.IsInEditMode || (this.Builder.IsInEditMode && String.IsNullOrEmpty(this.Builder.DeleteAction)))
                {
                    label.AddCssClass("i-checkbox i-checkbox__label i-checkbox--disabled");
                    input.Attributes.Add("disabled", "disabled");
                }
                else
                {
                    label.AddCssClass("i-checkbox i-checkbox__label");
                }

                label.InnerHtml += input;

                TagBuilder span = new TagBuilder("span");
                span.AddCssClass("i-checkbox__field");
                label.InnerHtml += span;

                tRow.MergeAttribute("data-checked", "false");
                TagBuilder tCell = new TagBuilder("td");
                tCell.InnerHtml += label;
                tRow.InnerHtml += tCell;
            }
        }

        protected override TagBuilder Footer()
        {
            TagBuilder tFooter = base.Footer();

            if (this.Builder.IsInEditMode && !String.IsNullOrEmpty(this.Builder.InsertAction))
            {
                TagBuilder tRow = new TagBuilder("tr");
                tRow.MergeAttribute("data-gridtablelist-newrow", "true");
                tRow.GenerateId("gtl_" + Builder.TableId + "_newR");

                tRow.InnerHtml += newRowTemplate;

                tFooter.InnerHtml += tRow;

                tRow = new TagBuilder("tr");
                TagBuilder tCell = new TagBuilder("td");
                tCell.Attributes.Add("colspan", Builder.TableColumns.Where(x => x.ColumnVisible).Count().ToString());
                TagBuilder insertBtn = new TagBuilder("a");
                insertBtn.MergeAttribute("onclick", "window." + this.Builder.TableId + ".Insert();");
                insertBtn.GenerateId("gtl_" + Builder.TableId + "_InsertRows");
                insertBtn.SetInnerText(TableString.Insert.ToString());
                insertBtn.AddCssClass("b-icon-text b-icon-text--primary disabled");
                insertBtn.MergeAttribute("style", "display: none;");
                tCell.InnerHtml += insertBtn.ToString();
                tRow.InnerHtml = tCell.ToString();

                tFooter.InnerHtml += tRow;
            }
            return tFooter;
        }

        protected override MvcHtmlString EmptyList(bool hasActionsCol = false)
        {
            return new MvcHtmlString(Header().ToString() + base.EmptyList(false).ToHtmlString() + Footer().ToString());
        }

        internal override MvcHtmlString GenerateExtraFooterContent()
        {
            if (this.Builder.IsInEditMode && !String.IsNullOrEmpty(this.Builder.DeleteAction))
            {
                TagBuilder deleteBtn = new TagBuilder("a");
                deleteBtn.MergeAttribute("onclick", "window." + this.Builder.TableId + ".DeleteSelected();");
                deleteBtn.GenerateId("gtl_" + this.Builder.TableId + "_DeleteSelectedRows");
                deleteBtn.SetInnerText(TableString.Delete.ToString());
                deleteBtn.AddCssClass("btn btn-danger disabled");
                deleteBtn.MergeAttribute("style", "display: none;");

                return new MvcHtmlString(deleteBtn.ToString());
            }

            return base.GenerateExtraFooterContent();
        }

        protected override MvcHtmlString GenerateScripts()
        {
            StringBuilder scriptBase = new StringBuilder(base.GenerateScripts().ToHtmlString());

            int lastquote = scriptBase.ToString().LastIndexOf("'");

            string newScript = @",
                    keyName: '" + this.Builder.DataKeyName + @"',
                    foreignKeyName: '" + this.Builder.DataForeignKeyName + @"',
                    foreignKeyValue: '" + this.Builder.DataForeignKeyValue + @"',
                    isEmpty: " + (this.Builder.Data.Count() == 0 ? "true" : "false") + @",
                    saveAction: '" + HttpUtility.JavaScriptStringEncode(this.Builder.SaveAction) + @"',
                    insertAction: '" + HttpUtility.JavaScriptStringEncode(this.Builder.InsertAction) + @"',
                    deleteAction: '" + HttpUtility.JavaScriptStringEncode(this.Builder.DeleteAction) + @"',
                    newRowTemplate: '" + this.Builder.HttpContext.Server.HtmlEncode(this.newRowTemplate) + "'";

            scriptBase.Insert(lastquote + 1, newScript);

            return new MvcHtmlString(scriptBase.ToString());
        }
    }
}