using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Scripts;
using GenioMVC.Helpers.Table.Utils;

namespace GenioMVC.Helpers.Table.Renderer
{
    public class TableListRenderer<TModel> : DbEditRenderer<TModel> where TModel : class
    {
        new private TableList<TModel> Builder { get; set; }

        public TableListRenderer(Table<TModel> builder)
            : base(builder)
        {
            this.Builder = builder as TableList<TModel>;
        }

        internal override void GenerateOtherCell(TModel model, ITableColumnInternal<TModel> tc, TagBuilder tRow, RouteValueDictionary routeValueDictionary)
        {
            if (!this.Builder.IsInEditMode && !String.IsNullOrEmpty(tRow.InnerHtml) && (tc.ColumnVisible && tc.IsActionsColumn) && this.Builder.HasHelpForm() && this.Builder.Permissions.CanView)
            {
                TagBuilder tCell = new TagBuilder("td");
				tCell.Attributes.Add("elem-identifier", "RowActions");
                tCell.AddCssClass("row-actions");
                Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
                if (this.Builder.Form.OpenInPopup)
                {
                    htmlAttributes.Add("data-modal-form", true);
                    htmlAttributes.Add("data-table", this.Builder.TableId);
                    htmlAttributes.Add("data-modal-form-mode", "SHOW");
                }
                TagBuilder showButton = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, Builder.Form.HelpForm + "_Show", routeValueDictionary, TableString.View.ToString(), htmlAttributes);
                showButton.AddCssClass("b-icon-text b-icon-text--primary" + this.buttonSize);
                showButton.Attributes.Add("qbutton", "show");

                tCell.InnerHtml += showButton;
                tRow.InnerHtml += tCell.ToString();
            }
            else
            {
                base.GenerateOtherCell(model, tc, tRow, routeValueDictionary);
            }
        }

        protected override string CreateActions(TModel model, RouteValueDictionary routeValueDictionary, ITableColumnInternal<TModel> tableColumn, bool cardActions = false)
        {
            String result = base.CreateActions(model, routeValueDictionary, null, false);

            if (Builder.HasExtendedHelpForm)
            {
                result = String.Empty;

				//added action button to delete record
                if (Builder.HasExtendedHelpForm && Builder.IsInEditMode && Builder.Permissions.CanDelete)
                {
                    object routeData = new { id = routeValueDictionary["id"], nestedForm = "true" };
                    result +=
                            System.Web.Mvc.Ajax.AjaxExtensions.ActionLink(
                                new System.Web.Mvc.AjaxHelper(Builder.HtmlHelper.ViewContext, Builder.HtmlHelper.ViewDataContainer, Builder.HtmlHelper.RouteCollection),
                                " ",
                                Builder.Form.HelpForm + "_Delete",
                                Builder.extendedHelpFormController,
                                routeData,
                                new System.Web.Mvc.Ajax.AjaxOptions() { HttpMethod = "Get", UpdateTargetId = Builder.extendedHelpFormAjaxContainer, OnBegin = "destroyQForm('Form_" + CSGenio.framework.StringUtils.CapFirst(Builder.Form.HelpForm) + "')" },
                                new { @class = "b-icon-text b-icon-text--secondary glyphicons glyphicons-bin", qbutton = "delete" }
                            ).ToString();
                }

                IDictionary<string, object> htmlAttributes = new Dictionary<string, object>();
                htmlAttributes.Add("class", "b-icon-text b-icon-text--primary");

                //if (t.HasCustomAction)
                htmlAttributes.Add("style", "display:none");

                routeValueDictionary.Add("nestedForm", "true");
				//Enforces nocache for Internet Explorer
				routeValueDictionary.Add("nocache", DateTime.Now.Ticks);

                if (Builder.IsInEditMode && Builder.Permissions.CanEdit)
                {
                    htmlAttributes.Add("qbutton", "edit");
                    result +=
                        System.Web.Mvc.Ajax.AjaxExtensions.ActionLink(
                            new System.Web.Mvc.AjaxHelper(Builder.HtmlHelper.ViewContext, Builder.HtmlHelper.ViewDataContainer, Builder.HtmlHelper.RouteCollection),
                            TableString.Edit.ToString(),
                            Builder.Form.HelpForm + "_Edit",
                            Builder.extendedHelpFormController,
                            routeValueDictionary,
                            new System.Web.Mvc.Ajax.AjaxOptions() { HttpMethod = "Get", UpdateTargetId = Builder.extendedHelpFormAjaxContainer, OnBegin = "destroyQForm('Form_" + CSGenio.framework.StringUtils.CapFirst(Builder.Form.HelpForm) + "')" },
                            htmlAttributes
                        ).ToString();
                }
                else if(!Builder.IsInEditMode && Builder.Permissions.CanView)
                {
                    htmlAttributes.Add("qbutton", "show");
                    result +=
                        System.Web.Mvc.Ajax.AjaxExtensions.ActionLink(
                            new System.Web.Mvc.AjaxHelper(Builder.HtmlHelper.ViewContext, Builder.HtmlHelper.ViewDataContainer, Builder.HtmlHelper.RouteCollection),
                            TableString.View.ToString(),
                            Builder.Form.HelpForm + "_Show",
                            Builder.extendedHelpFormController,
                            routeValueDictionary,
                            new System.Web.Mvc.Ajax.AjaxOptions() { HttpMethod = "Get", UpdateTargetId = Builder.extendedHelpFormAjaxContainer, OnBegin = "destroyQForm('Form_" + CSGenio.framework.StringUtils.CapFirst(Builder.Form.HelpForm) + "')" },
                            htmlAttributes
                        ).ToString();
                }
            }

            return result;
        }

        protected override String CreateFollowUp(TModel model, RouteValueDictionary routeValueDictionary)
        {
            String result = base.CreateFollowUp(model, routeValueDictionary);

            if (Builder.HasExtendedHelpForm)
            {
                return null;
            }

            return result;
        }

        protected override MvcHtmlString CreateInsertAction()
        {
            String result = base.CreateInsertAction().ToHtmlString();

            if (Builder.HasExtendedHelpForm && Builder.IsInEditMode && Builder.Permissions.CanInsert)
            {
                result = String.Empty;
                object routeData = new { nestedForm = "true", nocache = DateTime.Now.Ticks };
                if(Builder.Form.RepeatInsertion)
                    routeData = new { nestedForm = "true", nocache = DateTime.Now.Ticks, repeatInsertion = true };

                result +=
                       System.Web.Mvc.Ajax.AjaxExtensions.ActionLink(
                           new System.Web.Mvc.AjaxHelper(Builder.HtmlHelper.ViewContext, Builder.HtmlHelper.ViewDataContainer, Builder.HtmlHelper.RouteCollection),
                           TableString.Insert.ToString(),
                           Builder.Form.HelpForm + "_New",
                           Builder.extendedHelpFormController,
                           routeData,
                           new System.Web.Mvc.Ajax.AjaxOptions() { HttpMethod = "Get", UpdateTargetId = Builder.extendedHelpFormAjaxContainer, OnBegin = "destroyQForm('Form_" + CSGenio.framework.StringUtils.CapFirst(Builder.Form.HelpForm) + "')" },
                           new { @class = "b-icon-text b-icon-text--primary", qbutton = "insert" }
                       ).ToString();
            }

            return new MvcHtmlString(result);
        }
    }
}