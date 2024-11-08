using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Helpers.Table.Scripts;
using GenioMVC.Helpers.Table.Utils;
using GenioMVC.Models;

namespace GenioMVC.Helpers.Table.Renderer
{
    public class DbEditRenderer<TModel> : TableRenderer<TModel> where TModel : class
    {
        new protected DbEdit<TModel> Builder { get; set; }

        public FilterRenderer<TModel> FilterRenderer { get; protected set; }

        public String tableFiltersInput { get; protected set; }
        private bool followUpGenerated = false;

        public DbEditRenderer(Table<TModel> builder)
            : base(builder)
        {
            this.Builder = builder as DbEdit<TModel>;
            this.FilterRenderer = new FilterRenderer<TModel>(this.Builder, this);

            if (this.Builder.hasFilters && this.Builder.Filter != null)
            {
                this.tableFiltersInput = this.Builder.TableId + this.Builder.Filter.qsTableFilters;
                if(this.Builder.Filter.FiltersValues.Count > 0)
                    this.Builder.TableCssClass.Add("table");
            }
        }

        protected override TagBuilder Header()
        {
            TagBuilder tHead = base.Header();

            if (this.Builder.hasFilters)
            {
                tHead.InnerHtml += this.FilterRenderer.GenerateHeaderFilterRow();
            }

            return tHead;
        }

        protected virtual int GetColumnCount()
        {
            var columnCount = Builder.TableColumns.Count(x => x.ColumnVisible);
            if (this.Builder.multipleSelection)
                columnCount++;
            return columnCount;
        }


		protected override TagBuilder Footer()
        {
            TagBuilder tFooter = new TagBuilder("div");
            tFooter.AddCssClass("c-table__footer-out");

            TagBuilder actionsContainer = new TagBuilder("div");

            int countMultipleActions = Builder.TableActions.Count(x => !x.IsFollowUp && x.RequiresMultipleSelection);

            if (countMultipleActions > 0)
            {
                actionsContainer.Attributes.Add("elem-identifier", "ActionsContainer");
                if(LayoutConfig.config.DbEditMultipleActionPlacement == "left")
                    actionsContainer.AddCssClass("ms-actions-container float-left tfooterElement");
                else
                    actionsContainer.AddCssClass("ms-actions-container float-right");
                if (countMultipleActions == 1)
                {
                    foreach (TableAction<TModel> tAction in Builder.TableActions.Where(x => !x.IsFollowUp && x.RequiresMultipleSelection))
                    {
                        //TagBuilder li = new TagBuilder("li");
                        RouteValueDictionary htmlAttr = HtmlHelper.AnonymousObjectToHtmlAttributes(tAction.HtmlAttributes);
                        TagBuilder actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, tAction.Action, tAction.Controller, tAction.Title, htmlAttr);
                        TagBuilder icon = TableUtils.MakeIcon(Builder.HtmlHelper, tAction.Icon, tAction.IsBootStrapIcon);
                        actionLink.AddCssClass("b-icon-text b-icon-text--primary");

                        if (tAction.IsRoutine)
                        {
                            actionLink.Attributes["data-routine"] = tAction.Action;
                            actionLink.Attributes["href"] = "#";
                        }
                        else if (tAction.IsAjaxAction)
                        {
                            actionLink.Attributes["data-target"] = this.Builder.ajaxUpdateContainerId;
                            actionLink.Attributes["data-link"] = actionLink.Attributes["href"];
                            actionLink.Attributes["href"] = "#";
                        }

                        actionLink.Attributes.Add("qbutton", "action");
                        actionLink.InnerHtml = icon.ToString() + " " + actionLink.InnerHtml;
                        actionsContainer.InnerHtml += actionLink;
                    }
                }
                else
                {
                    TagBuilder ul = new TagBuilder("div");

                    foreach (TableAction<TModel> tAction in Builder.TableActions.Where(x => !x.IsFollowUp && x.RequiresMultipleSelection))
                    {
                        RouteValueDictionary htmlAttr = HtmlHelper.AnonymousObjectToHtmlAttributes(tAction.HtmlAttributes);

                        TagBuilder actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, tAction.Action, tAction.Controller, tAction.Title, htmlAttr);
                        actionLink.AddCssClass("dropdown-item");

                        TagBuilder icon = TableUtils.MakeIcon(Builder.HtmlHelper, tAction.Icon, tAction.IsBootStrapIcon);

                        if (tAction.IsRoutine)
                        {
                            actionLink.Attributes["data-routine"] = tAction.Action;
                            actionLink.Attributes["href"] = "#";
                        }
                        else if (tAction.IsAjaxAction)
                        {
                            actionLink.Attributes["data-target"] = this.Builder.ajaxUpdateContainerId;
                            actionLink.Attributes["data-link"] = actionLink.Attributes["href"];
                            actionLink.Attributes["href"] = "#";
                        }

                        actionLink.InnerHtml = icon.ToString() + " " + actionLink.InnerHtml;
                        ul.InnerHtml += actionLink;
                    }

                    TagBuilder div = new TagBuilder("div");
                    div.AddCssClass("btn-group");
                    TagBuilder a = new TagBuilder("button");

                    a.AddCssClass("b-icon-text b-icon-text--primary dropdown");
                    a.Attributes.Add("data-toggle", "dropdown");
                    a.Attributes.Add("data-boundary", "window");
                    a.Attributes.Add("href", "#");
                    a.InnerHtml += TableString.GroupActions ;
                    div.InnerHtml += a;
                    ul.AddCssClass("dropdown-menu");
                    div.InnerHtml += ul;

                    actionsContainer.InnerHtml += div;
                }
            }

            if (this.Builder.multipleSelection || this.Builder._DEF_MultipleSelection) {
                TagBuilder div = new TagBuilder("div");
                div.Attributes.Add("elem-identifier", "Pagination");
                div.AddCssClass("pagination float-left");

                TagBuilder span = new TagBuilder("span");
                span.Attributes.Add("elem-identifier", "SelectedRecordsCounter");
                span.AddCssClass("selected-records-counter");


                TagBuilder SelectedRecords = new TagBuilder("label");
                SelectedRecords.AddCssClass("selected-records-text i-text__label--popover");
                SelectedRecords.InnerHtml += TableString.SelectedRecords;

                div.InnerHtml += span + " " + SelectedRecords;

                tFooter.InnerHtml += div;
                tFooter.InnerHtml += actionsContainer;
            }

            if (this.Builder.hasPagination)
                tFooter.InnerHtml += PagerRenderer.ToHtml();
            tFooter.InnerHtml += GenerateExtraFooterContent();

            if (this.Builder.HasLimits())
                tFooter.InnerHtml += GenerateLimitsContent();

            return tFooter;
        }

        protected override MvcHtmlString EmptyList(bool hasActionsCol = false)
        {
            string result = string.Empty;

            result += Header();

			if (this.Builder.GetType().GetProperty("hasActionsCol") != null && this.Builder.hasActionsCol)
				result += base.EmptyList(true);
			else
                result += base.EmptyList(false);

            return new MvcHtmlString(result);
        }

		protected MvcHtmlString EmptyListNoHeader()
        {
            string result = string.Empty;
            result += base.EmptyList();

            return new MvcHtmlString(result);
        }

		internal override void GenerateOtherCell(TModel model, ITableColumnInternal<TModel> tc, TagBuilder tRow, RouteValueDictionary routeValueDictionary)
        {
            if (tc.ColumnVisible && tc.IsActionsColumn && (this.Builder.HasActions() || !this.Builder.HasActions() && this.Builder.hasFilters))
                tRow.InnerHtml += GenerateBodyActionsCell(model, tc, routeValueDictionary).ToString();
        }

        internal override MvcHtmlString GenerateExtraFooterContent()
        {
            String extraContent = String.Empty;

            var modelType = this.Builder.Data.GetType().GetGenericArguments().First();
            var emptyModel = Activator.CreateInstance(modelType);
            ModelBase modelBase = emptyModel as ModelBase;

            // Insert Action
            if (Builder.Permissions.CanInsert && Builder.HasHelpForm() && (modelBase != null && modelBase.baseklass.AccessRightsToCreate()))
            {
                extraContent += CreateInsertAction();
            }

            if (!String.IsNullOrEmpty(extraContent))
                return new MvcHtmlString(extraContent);

            return base.GenerateExtraFooterContent();
        }

        internal override MvcHtmlString GenerateHiddenFields()
        {
            string extra = string.Empty;

            if (Builder.hasFilters && Builder.Filter != null)
            {
                var id = Builder.TableId + "_tableFilters";
                extra += System.Web.Mvc.Html.InputExtensions.Hidden(Builder.HtmlHelper, id, Builder.Filter.ShowTableFilters.ToString().ToLowerInvariant(), new { id });
            }
            MvcHtmlString result = new MvcHtmlString(base.GenerateHiddenFields() + extra);
            return result;
        }

        protected virtual TagBuilder GenerateBodyActionsCell(TModel model, ITableColumnInternal<TModel> tc, RouteValueDictionary routeValueDictionary)
        {
            TagBuilder tCell = new TagBuilder("td");

			// Last updated by [DSG] at [2018.07.02]
            // Add id to the header creating a link between td and th by adding td's attribute headers equal to the corresponding header id
            // For accessibility purposes (see Principle1.Guideline1_3.1_3_1.H43.HeadersRequired of the WCAG2 rules);

            //set headers
            String fieldID = tc.ColumnField;
            String header = typeof(TModel).Name + "_" + this.Builder.TableId + "_actions";

            tCell.Attributes.Add("elem-identifier", "RowActions");
            tCell.Attributes.Add("headers", header + " " + "Filter_" + header);

            tCell.AddCssClass("row-actions");

            if (this.Builder.HasFollowUpAction())
                tCell.AddCssClass("selectable");

            TagBuilder div = new TagBuilder("div");

            if (LayoutConfig.config.DbEditActionPlacement == "left")
                div.AddCssClass("dropdown");
            else
                div.AddCssClass("dropleft");

            div.Attributes.Add("elem-identifier", "BtnGroup");
            tCell.InnerHtml += "" + this.CreateFollowUp(model, routeValueDictionary) ?? "";
            if(!this.Builder.HasOnlyOneAction() || (this.Builder.HasOnlyOneAction() && !followUpGenerated))
                div.InnerHtml += this.CreateActions(model, routeValueDictionary, tc) ?? "";

            if (!String.IsNullOrEmpty(div.InnerHtml))
                tCell.InnerHtml += div;

            if(this.Builder.BackgroundColourCondition != null)
            {
                string colour = this.Builder.BackgroundColourCondition.Compile().Invoke(model);
                string backgroundcolour = "background-color: " + colour;
                if (tCell.Attributes.ContainsKey("style"))
                {
                    backgroundcolour += ";" + tCell.Attributes["style"];
                    tCell.Attributes.Remove("style");
                }
                tCell.Attributes.Add("style", backgroundcolour);
            }

            if(this.Builder.ForegroundColourCondition != null)
            {
                string colour = this.Builder.ForegroundColourCondition.Compile().Invoke(model);
                string foregroundcolour = "color: " + colour;
                if (tCell.Attributes.ContainsKey("style"))
                {
                    foregroundcolour += ";" + tCell.Attributes["style"];
                    tCell.Attributes.Remove("style");
                }
                tCell.Attributes.Add("style", foregroundcolour);
            }

            return tCell;
        }

        protected virtual String CreateFollowUp(TModel model, RouteValueDictionary routeValueDictionary)
        {
            // Create FollowUp Button
            if (Builder.HasFollowUpAction())
            {
                TableAction<TModel> followUpAction = TableUtils.GetFollowUpAction(Builder.TableActions);
                return CreateFollowUp(followUpAction, model);
            }
            else
            {
                this.followUpGenerated = false;
                return String.Empty;
            }
        }

        protected virtual String CreateFollowUp(TableAction<TModel> followUpAction, TModel model)
        {
            // Create FollowUp Button
            if (followUpAction != null)
            {
                bool isAjax = false;
                TagBuilder followUp = new TagBuilder("a");

                // if has followUp, create the button based on FollowUp Action
                // else create followUp button based on View Action
                if (followUpAction != null)
                {
                    isAjax = followUpAction.IsAjaxAction;

                    followUp = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, followUpAction.Action, followUpAction.Controller, model, followUpAction.RouteValuesFun, followUpAction.Title, followUpAction.IsRoutine, followUpAction.HtmlAttributes);
                }

                if (isAjax)
                {
                    followUp.Attributes["data-target"] = this.Builder.ajaxUpdateContainerId;
                    followUp.Attributes["data-link"] = followUp.Attributes["href"];
                    followUp.Attributes["href"] = "#";
                }
                if (followUpAction.OpenInPopup)
                {
                    followUp.Attributes["data-modal-form"] = "true";
                    followUp.Attributes["data-table"] = this.Builder.TableId;
                }

                //followUp.AddCssClass("btn " + this.buttonSize);
                followUp.Attributes["data-followup-button"] = "true";

                followUp.InnerHtml = "<span class=\"hidden-elem\">Follow Up</span>";

                this.followUpGenerated = true;
                return followUp.ToString();
            }
            else
            {
                this.followUpGenerated = false;
                return String.Empty;
            }
        }

        private TagBuilder BuildDisabledButton(string text, CSGenio.framework.StatusMessage message)
        {
            //It's not enough to add a disabled class, there can be no link so that savvy users don't go arround the css class
            TagBuilder actionLink = new TagBuilder("a");
            actionLink.InnerHtml = text;
            actionLink.Attributes.Add("href", "#");
            actionLink.AddCssClass("disabled");
            actionLink.Attributes.Add("title", message.Message);
            actionLink.Attributes.Add("data-toggle", "tooltip");
            actionLink.Attributes.Add("data-force-tooltip", "true");
            actionLink.Attributes.Add("data-placement", "right");
            actionLink.Attributes.Add("style", "pointer-events: initial; cursor: default;");
            return actionLink;
        }

        protected virtual String CreateActions(TModel model, RouteValueDictionary routeValueDictionary, ITableColumnInternal<TModel> tableColumn, bool cardActions = false)
        {
            int actionsNumber = 0;
            string actionsDisplayStyle = GenioMVC.LayoutConfig.config.rowActionDisplay.ToString();
            int customActionsNumber = this.Builder.TableActions.Count;

            TagBuilder button = new TagBuilder("button");
            button.AddCssClass("b-icon b-icon--secondary dropdown" + this.buttonSize);
            if (cardActions)
                button.AddCssClass("sr-dropdown");

            if (tableColumn != null)
            {
                button.Attributes.Add("title", tableColumn.ColumnTitle);
            }
            button.Attributes.Add("data-toggle", "dropdown");

            if (cardActions)
                button.Attributes.Add("style", "border: none");

            TagBuilder iconBtnn = new TagBuilder("i");
            iconBtnn.AddCssClass("glyphicons glyphicons-option-horizontal e-icon");
            button.Attributes.Add("data-boundary", "window");
            button.InnerHtml += iconBtnn;

            TagBuilder container = new TagBuilder("div");
            container.AddCssClass("sr-dropdown-menu");
            container.AddCssClass("dropdown-menu");

            TagBuilder ul = new TagBuilder("div");
            TagBuilder customActionsMenu = new TagBuilder("div");
            if (cardActions)
            {
                ul.AddCssClass("sr-dropdown-container");
                container.AddCssClass("dropdown-menu");
                container.AddCssClass("sr-dropdown-menu");
                if (LayoutConfig.config.DbEditActionPlacement == "left")
                    container.AddCssClass("pull-left");
                else
                    container.AddCssClass("pull-right");
            }
            else
            {
                if(actionsDisplayStyle == "dropdown")
                {
                    ul.AddCssClass("dropdown-menu");

                    if (LayoutConfig.config.DbEditActionPlacement == "left")
                        ul.AddCssClass("pull-left");
                    else
                        ul.AddCssClass("pull-right");
                }
                else
                {

                    if (customActionsNumber > 1)
                    {
                        customActionsMenu.AddCssClass("dropdown-menu");

                        if (LayoutConfig.config.DbEditActionPlacement == "left")
                            customActionsMenu.AddCssClass("pull-left");
                        else
                            customActionsMenu.AddCssClass("pull-right");
                    }
                }

            }

            Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
            if (this.Builder.Form.OpenInPopup)
            {
                htmlAttributes.Add("data-modal-form", true);
                htmlAttributes.Add("data-table", this.Builder.TableId);
            }


            foreach (TableAction<TModel> tAction in TableUtils.GetTableActions(this.Builder.TableActions))
            {
                //TagBuilder li = new TagBuilder("li");
                string actionLinkText = actionsDisplayStyle == "dropdown" || cardActions || (actionsDisplayStyle == "inline" && customActionsNumber > 1) ? tAction.Title : String.Empty;
                TagBuilder actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, tAction.Action, tAction.Controller, model, tAction.RouteValuesFun, actionLinkText, tAction.IsRoutine, tAction.HtmlAttributes);

                TagBuilder icon = TableUtils.MakeIcon(Builder.HtmlHelper, tAction.Icon, tAction.IsBootStrapIcon);
                if (tAction.IsAjaxAction)
                {
                    actionLink.Attributes["data-target"] = this.Builder.ajaxUpdateContainerId;
                    actionLink.Attributes["data-link"] = actionLink.Attributes["href"];
                    actionLink.Attributes["href"] = "#";
                }
                actionLink.Attributes.Add("qbutton", "action");
                actionLink.InnerHtml = icon.ToString() + actionLink.InnerHtml;

                if (tAction.OpenInPopup)
                {
                    actionLink.Attributes.Add("data-modal-form", "true");
                    actionLink.Attributes.Add("data-table", this.Builder.TableId);
                    actionLink.Attributes.Add("data-modal-url", actionLink.Attributes["href"]);
                }

                if (this.Builder.HasOnlyOneAction())
                {
                    actionLink.AddCssClass("single-action");
                    actionLink.AddCssClass("b-icon-text b-icon-text--primary " + this.buttonSize);
                    return actionLink.ToString();
                }

                if (actionsDisplayStyle == "dropdown" || cardActions || (actionsDisplayStyle == "inline"  && customActionsNumber > 1))
                {
                    actionLink.AddCssClass("dropdown-item");
                }
                //li.InnerHtml += actionLink;

                if(actionsDisplayStyle == "dropdown" || customActionsNumber == 1)
                {
                    ul.InnerHtml += actionLink;
                }
                else
                {
                    customActionsMenu.InnerHtml += actionLink;
                }

                actionsNumber++;

				if(tAction.IsSlotReport && !string.IsNullOrEmpty(tAction.SlotReportId))
                {
                    if(this.Builder.slotReports.ContainsKey(tAction.SlotReportId))
                    {
                        ul.InnerHtml += TableUtils.GetDropdownDivider().ToString();

                        foreach (var item in this.Builder.slotReports[tAction.SlotReportId])
                        {
                            CSGenio.business.CSGenioAreportlist slot = item as CSGenio.business.CSGenioAreportlist;
                            var rptQueryParam = tAction.RouteValuesFun(model) as GenioMVC.Models.ReportQueryParameter;
                            rptQueryParam.name = slot.ValReport;
                            TagBuilder slotLink = TableUtils.MakeActionLink(Builder.HtmlHelper, tAction.Action, tAction.Controller, rptQueryParam, slot.ValTitulo, tAction.IsRoutine, tAction.HtmlAttributes);
                            slotLink.AddCssClass("dropdown-item");
                            ul.InnerHtml += slotLink;
                        }
                        //ul.InnerHtml += TableUtils.GetDropdownDivider().ToString();
                    }
                }
            }

            if (actionsNumber > 0 && (Builder.HasViewAction() || Builder.HasEditAction() || Builder.HasDuplicateAction() || Builder.HasDeleteAction()))
            {
                ul.InnerHtml += TableUtils.GetDropdownDivider().ToString();
            }

            if(Builder.HasHelpForm() && !routeValueDictionary.ContainsKey("m"))
            {
                var formModes = string.Empty;
                if (Builder.HasViewAction())
                    formModes += "v";
                if (Builder.HasEditAction())
                    formModes += "e";
                if (Builder.HasDuplicateAction())
                    formModes += "d";
                if (Builder.HasDeleteAction())
                    formModes += "a";
                if (Builder.HasInsertAction())
                    formModes += "i";

                routeValueDictionary.Add("m", formModes);
            }

            // The CRUD operation in the upper table does not require saving the form (PreValida + Apply)
            // The ButtonsHttpAttributes will contains «data-skip-prevalida» in case of «See more..» of the dbedit form field
            RouteValueDictionary additionalButtonsAttributes = null;
            if (this.Builder.Form.ButtonsHttpAttributes != null)
            {
                additionalButtonsAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(this.Builder.Form.ButtonsHttpAttributes);
            }

            var modelBase = model as ModelBase;

            // If has FollowUp and has View Access
            if (Builder.HasViewAction() && (modelBase != null && modelBase.baseklass.AccessRightsToConsult()))
            {
                //TagBuilder li = new TagBuilder("li");
                TagBuilder actionLink;
                TableAction<TModel> fAction = TableUtils.GetSepecificPathsFollowUpAction(this.Builder.TableActions);

                var result = Builder.ViewConditions.Invoke(model);
                if (result.Status == CSGenio.framework.Status.OK)
                {
                    string viewActionText = actionsDisplayStyle == "dropdown" || cardActions ? TableString.View.ToString() : String.Empty;
                    if (fAction != null)
                    {
                        routeValueDictionary.Add("formMode", "Show");
                        actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, fAction.Action, routeValueDictionary, viewActionText, htmlAttributes, fAction.Controller);
                        routeValueDictionary.Remove("formMode");
                    }
                    else
                    {
                        actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, Builder.Form.HelpForm + "_Show", routeValueDictionary, viewActionText, htmlAttributes);
                    }
                    actionLink.Attributes.Add("onclick", "onNavigation(event, this, 'SHOW')");
                }
                else
                {
                    actionLink = BuildDisabledButton(TableString.View.ToString(), result);
                }
                actionLink.Attributes.Add("qbutton", "show");

                if (Builder.Form.OpenInPopup)
                    actionLink.Attributes.Add("data-modal-form-mode", "SHOW");

                TagBuilder icon = TableUtils.MakeIcon(Builder.HtmlHelper, "glyphicons glyphicons-eye-open dropdown__icon", true);

                actionLink.InnerHtml = icon.ToString() + actionLink.InnerHtml;

                if(additionalButtonsAttributes != null)
                    actionLink.MergeAttributes(additionalButtonsAttributes);

                if (this.Builder.HasOnlyOneAction() || this.Builder.IsViewOrEditEqualFollup("view"))
                {
                    actionLink.AddCssClass("single-action");
                    actionLink.AddCssClass("b-icon-text b-icon-text--primary " + this.buttonSize);
                    actionLink.Attributes.Add("Title", TableString.View.ToString());
                    return actionLink.ToString();
                }

                if (actionsDisplayStyle == "dropdown" || cardActions)
                {
                    actionLink.AddCssClass("dropdown-item");
                }
                ul.InnerHtml += actionLink;

                actionsNumber++;
            }
            if (Builder.HasEditAction() && (modelBase != null && modelBase.baseklass.accessRightsToChange()))
            {
                //TagBuilder li = new TagBuilder("li");
                TagBuilder actionLink;
                TableAction<TModel> fAction = TableUtils.GetSepecificPathsFollowUpAction(this.Builder.TableActions);
                //Evaluate table condition
                var result = Builder.UpdateConditions.Invoke(model);
                if (result.Status == CSGenio.framework.Status.OK)
                {
                    string editActionText = actionsDisplayStyle == "dropdown" || cardActions ? TableString.Edit.ToString() : String.Empty;
                    if (fAction != null)
                    {
                        routeValueDictionary.Add("formMode", "Edit");
                        actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, fAction.Action, routeValueDictionary, editActionText, htmlAttributes, fAction.Controller);
                        routeValueDictionary.Remove("formMode");
                    }
                    else
                    {
                        actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, Builder.Form.HelpForm + "_Edit", routeValueDictionary, editActionText, htmlAttributes);
                    }
                    actionLink.Attributes.Add("onclick", "onNavigation(event, this, 'EDIT')");
                    actionLink.Attributes.Add("qbutton", "edit");
                }
                else
                {
                    actionLink = BuildDisabledButton(TableString.Edit.ToString(), result);
                }

                if (Builder.Form.OpenInPopup)
                    actionLink.Attributes.Add("data-modal-form-mode", "EDIT");

                TagBuilder icon = TableUtils.MakeIcon(Builder.HtmlHelper, "glyphicons glyphicons-pencil dropdown__icon", true);

                actionLink.InnerHtml = icon.ToString() + actionLink.InnerHtml;

                if(additionalButtonsAttributes != null)
                    actionLink.MergeAttributes(additionalButtonsAttributes);

                if (this.Builder.HasOnlyOneAction() || this.Builder.IsViewOrEditEqualFollup("edit"))
                {
                    actionLink.AddCssClass("single-action");
                    actionLink.AddCssClass("edit-action");
                    actionLink.AddCssClass("b-icon-text b-icon-text--primary " + this.buttonSize);
                    return actionLink.ToString();
                }

                if (actionsDisplayStyle == "dropdown" || cardActions)
                {
                    actionLink.AddCssClass("dropdown-item");
                }
                //li.InnerHtml += actionLink;
                //ul.InnerHtml += li.ToString();
                ul.InnerHtml += actionLink;

                actionsNumber++;
            }
            if (Builder.HasDuplicateAction() && (modelBase != null && modelBase.baseklass.AccessRightsToCreate() && modelBase.baseklass.AccessRightsToConsult()))
            {
                //TagBuilder li = new TagBuilder("li");
                TagBuilder actionLink;
                TableAction<TModel> fAction = TableUtils.GetSepecificPathsFollowUpAction(this.Builder.TableActions);

                //Evaluate table condition
                var result = Builder.InsertConditions.Invoke(model);
                result.MergeStatusMessage(Builder.ViewConditions.Invoke(model));
                if (result.Status == CSGenio.framework.Status.OK)
                {
                    string duplicateActionText = actionsDisplayStyle == "dropdown" || cardActions ? TableString.Duplicate.ToString() : String.Empty;
                    if (fAction != null)
                    {
                        routeValueDictionary.Add("formMode", "Dup");
                        actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, fAction.Action, routeValueDictionary, duplicateActionText, htmlAttributes, fAction.Controller);
                        routeValueDictionary.Remove("formMode");
                    }
                    else
                    {
                        actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, Builder.Form.HelpForm + "_Duplicate", routeValueDictionary, duplicateActionText, htmlAttributes);
                    }
                    actionLink.Attributes.Add("onclick", "onNavigation(event, this, 'DUP')");
                    actionLink.Attributes.Add("qbutton", "duplicate");
                }
                else
                {
                    actionLink = BuildDisabledButton(TableString.Duplicate.ToString(), result);
                }

                if (Builder.Form.OpenInPopup)
                    actionLink.Attributes.Add("data-modal-form-mode", "DUP");

                TagBuilder icon = TableUtils.MakeIcon(Builder.HtmlHelper, "glyphicons glyphicons-retweet dropdown__icon", true);

                actionLink.InnerHtml = icon.ToString() + actionLink.InnerHtml;

                if(additionalButtonsAttributes != null)
                    actionLink.MergeAttributes(additionalButtonsAttributes);

                if (this.Builder.HasOnlyOneAction() || this.Builder.IsDelOrDupWithCreate("duplicate"))
                {
                    actionLink.AddCssClass("single-action");
                    actionLink.AddCssClass("b-icon-text b-icon-text--primary " + this.buttonSize);
                    return actionLink.ToString();
                }

                if (actionsDisplayStyle == "dropdown" || cardActions)
                {
                    actionLink.AddCssClass("dropdown-item");
                }
                //li.InnerHtml += actionLink;
                //ul.InnerHtml += li.ToString();
                ul.InnerHtml += actionLink;

                actionsNumber++;
            }
            if (Builder.HasDeleteAction() && (modelBase != null && modelBase.baseklass.accessRightsToDelete()))
            {
                //TagBuilder li = new TagBuilder("li");
                TagBuilder actionLink;
                TableAction<TModel> fAction = TableUtils.GetSepecificPathsFollowUpAction(this.Builder.TableActions);
                //Evaluate table condition
                var result = Builder.DeleteConditions.Invoke(model);
                if (result.Status == CSGenio.framework.Status.OK)
                {
                    string deleteActionText = actionsDisplayStyle == "dropdown" || cardActions ? TableString.Delete.ToString() : String.Empty;
                    if (fAction != null)
                    {
                        routeValueDictionary.Add("formMode", "Delete");
                        actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, fAction.Action, routeValueDictionary, deleteActionText, htmlAttributes, fAction.Controller);
                        routeValueDictionary.Remove("formMode");
                    }
                    else
                    {
                        actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, Builder.Form.HelpForm + "_Delete", routeValueDictionary, deleteActionText, htmlAttributes);
                    }
                    actionLink.Attributes.Add("onclick", "onNavigation(event, this, 'DELETE')");
                    actionLink.Attributes.Add("qbutton", "delete");

                    if (Builder.Form.OpenInPopup)
                        actionLink.Attributes.Add("data-modal-form-mode", "DELETE");
                }
                else
                {
                    actionLink = BuildDisabledButton(TableString.Delete.ToString(), result);
                }
                TagBuilder icon = TableUtils.MakeIcon(Builder.HtmlHelper, "glyphicons glyphicons-delete dropdown__icon", true);

                actionLink.InnerHtml = icon.ToString() + actionLink.InnerHtml;

                if(additionalButtonsAttributes != null)
                    actionLink.MergeAttributes(additionalButtonsAttributes);

                if (this.Builder.HasOnlyOneAction() || this.Builder.IsDelOrDupWithCreate("delete"))
                {
                    actionLink.AddCssClass("single-action");
                    actionLink.AddCssClass("b-icon-text b-icon-text--primary " + this.buttonSize);
                    return actionLink.ToString();
                }

                if (actionsDisplayStyle == "dropdown" || cardActions)
                {
                    actionLink.AddCssClass("dropdown-item");
                }
                //li.InnerHtml += actionLink;
                //ul.InnerHtml += li.ToString();
                ul.InnerHtml += actionLink;

                actionsNumber++;
            }

            if (actionsNumber > 0 && cardActions)
            {
                container.InnerHtml = ul.ToString();
                return button.ToString() + container.ToString();
            }
            else if (actionsNumber > 0 && actionsDisplayStyle == "dropdown")
                return button.ToString() + ul.ToString();
            else if (actionsNumber > 0 && actionsDisplayStyle == "inline")
            {
                ul.AddCssClass("d-flex");
                ul.AddCssClass("ml-1");
                if (customActionsNumber > 1)
                {
                    ul.InnerHtml += button.ToString();
                    ul.InnerHtml += customActionsMenu;
                }
                return ul.ToString();
            }

            return "";
        }

        protected virtual MvcHtmlString CreateInsertAction()
        {
            RouteValueDictionary routeValueDictionary = new RouteValueDictionary();
            TagBuilder actionLink;
            TableAction<TModel> fAction = TableUtils.GetSepecificPathsFollowUpAction(this.Builder.TableActions);
            TagBuilder icon = new TagBuilder("i");
            icon.AddCssClass("glyphicons glyphicons-plus-sign e-icon");

            if (fAction != null)
            {
                routeValueDictionary.Add("formMode", "New");
                routeValueDictionary.Add("m", "i");
                if (Builder.Form.RepeatInsertion)
                    routeValueDictionary.Add("repeatInsertion", "true");
                actionLink = TableUtils.MakeButtonActionLink<TModel>(Builder.HtmlHelper, fAction.Action, routeValueDictionary, icon + TableString.Insert.ToString(), new { @class = "b-icon-text b-icon-text--secondary" }, fAction.Controller);
            }
            else
            {
                RouteValueDictionary routeData = null;
                if (Builder.Form.RepeatInsertion)
                    routeData = new RouteValueDictionary(new { m = "i", repeatInsertion = true });
                else
                    routeData = new RouteValueDictionary(new { m = "i" });
                actionLink = TableUtils.MakeButtonActionLink<TModel>(Builder.HtmlHelper, Builder.Form.HelpForm + "_New", routeData, icon + TableString.Insert.ToString(), new { @class = "b-icon-text b-icon-text--secondary" });
            }
            var result = Builder.InsertConditions.Invoke(null);
            var disabled = true;

            if (result.Status == CSGenio.framework.Status.OK)
            {
                actionLink.Attributes.Add("onclick", "onNavigation(event, this, 'NEW')");
                actionLink.Attributes.Add("qbutton", "insert");
                disabled = false;
            }

            if (this.Builder.Form.OpenInPopup)
            {
                actionLink.Attributes.Add("data-modal-form", "true");
                actionLink.Attributes.Add("data-table", this.Builder.TableId);
                actionLink.Attributes.Add("data-modal-form-mode", "NEW");
                actionLink.Attributes.Add("data-modal-url", actionLink.Attributes["href"]);
            }

            // The insertion of the new record in the upper table does not require saving the form (PreValida + Apply)
            // The ButtonsHttpAttributes will contains «data-skip-prevalida» in case of «See more..» of the dbedit form field
            if (this.Builder.Form.ButtonsHttpAttributes != null)
            {
                var htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(this.Builder.Form.ButtonsHttpAttributes);
                actionLink.MergeAttributes(htmlAttributes);
            }

            if (disabled)
            {
                /*
                 * According to the documentation of Bootstrap,
                 * it is not possible to use a tooltip on a disabled button.
                 * https://getbootstrap.com/docs/4.3/components/tooltips/#disabled-elements
                 *
                 * As a workaround, we’ll trigger the tooltip from a wrapper <span>.
                 * */

                if (actionLink.Attributes.ContainsKey("href"))
                    actionLink.Attributes["href"] = "#";
                else
                    actionLink.Attributes.Add("href", "#");

                actionLink.AddCssClass("b-icon-text--disabled");
                actionLink.Attributes.Add("data-placement", "right");
                actionLink.Attributes.Add("style", "pointer-events: none;");

                // Adds the "disabled" HTML attribute. It does not really need a value,
                // but there is no way to set an attribute without one.
                actionLink.Attributes.Add("disabled", "disabled");

                // The message will be displayed as tooltip.
                // Since it is not possible to use a Bootstrap tooltip on a disabled button,
                // the standard "title" attribute is used.
                TagBuilder wrapper = new TagBuilder("span");
                wrapper.AddCssClass("disabled-btn-wrapper");

                // This makes the button keyboard-focusable.
                wrapper.Attributes.Add("tab-index", "0");

                wrapper.Attributes.Add("data-toggle", "tooltip");
                wrapper.Attributes.Add("data-force-tooltip", "true");
                wrapper.Attributes.Add("title", result.Message);
                wrapper.InnerHtml = actionLink.ToString();

                return new MvcHtmlString(wrapper.ToString());
            }

            return new MvcHtmlString(actionLink.ToString());
        }

        protected override MvcHtmlString GenerateScripts()
        {
            StringBuilder scriptBase = new StringBuilder(base.GenerateScripts().ToHtmlString());

            if (this.Builder.hasFilters && this.Builder.Filter != null)
            {
                int lastquote = scriptBase.ToString().LastIndexOf("'");

                string newScript = @",
                    tableFilters: '" + HttpUtility.JavaScriptStringEncode(this.tableFiltersInput) + @"',
                    queryField: '" + HttpUtility.JavaScriptStringEncode(this.Builder.Filter.QueryField) + @"',
                    query: '" + HttpUtility.JavaScriptStringEncode(this.Builder.Filter.Query) + "'";
                scriptBase.Insert(lastquote + 1, newScript);
            }

            return new MvcHtmlString(scriptBase.ToString());
        }
    }
}
