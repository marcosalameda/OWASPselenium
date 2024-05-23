using CSGenio.framework;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Helpers.Table.Renderer;
using GenioMVC.Helpers.Table.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace GenioMVC.Helpers
{
    /// <summary>
    /// Class used to interact with view (Table)
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class SpecialRenderingBuilder<TModel> : Table.TableListBuilder<TModel> where TModel : class
    {
        protected TableAction<TModel> Followup;

        protected SpecialRendering SpecialRendering;

        //Construction
        public SpecialRenderingBuilder(Table<TModel> builder, bool hasFilters)
            : base(builder, hasFilters)
        {
            var _builder = new DbEdit<TModel>(builder, hasFilters);

            if (_builder.Form != null)
                Builder.SetForm(_builder.Form.HelpForm, _builder.Form.OpenInPopup, _builder.Form.RepeatInsertion);
        }

        /// Adds a following action to the current table
        public SpecialRenderingBuilder<TModel> SetSpecialRendering(SpecialRendering specialRendering)
        {
            SpecialRendering = specialRendering;
            return this;
        }

        /// Set Filters properties
        new public SpecialRenderingBuilder<TModel> Filters(GenioMVC.ViewModels.TableFiltering filters)
        {
            if (filters != null)
                this.Builder.SetFilters(filters.ShowTableFilters, filters.HasFilters, filters.FiltersValues, filters.QueryField, filters.Query);
            else
                this.Builder.SetFilters();

            return this;
        }

        /// Adds a following action to the current table
        new public SpecialRenderingBuilder<TModel> SetFollowUp(string action, string controller, System.Func<TModel, object> routeValuesFun, bool isRoutine = false, bool isSpecificPaths = false, bool isAjaxAction = false, object htmlAttributes = null, bool openInPopup = false)
        {
            Followup = new TableAction<TModel>(action, controller, routeValuesFun, "icon-play-circle", true, null, isRoutine, false, htmlAttributes, true, isSpecificPaths, isAjaxAction, openInPopup);
            return this;
        }

        /// Set Help Form
        new public SpecialRenderingBuilder<TModel> Form(string helpForm, bool openInPopup = false, bool repeatInsertion = false, object btnsAttributes = null)
        {
            Builder.SetForm(helpForm, openInPopup, repeatInsertion, btnsAttributes);
            return this;
        }

        /// Set Extended Help Form
        new public SpecialRenderingBuilder<TModel> ExtendedForm(string controller, string ajaxContainer)
        {
            this.Builder.SetExtendedForm(controller, ajaxContainer);
            return this;
        }

        new public SpecialRenderingBuilder<TModel> Permissions(bool canView = true, bool canInsert = true, bool canEdit = true,
            bool canDuplicate = true, bool canDelete = true)
        {
            Builder.SetPermissions(canView, canInsert, canEdit, canDuplicate, canDelete);
            return this;
        }

        new public SpecialRenderingBuilder<TModel> UpdateConditions(Func<TModel, StatusMessage> method)
        {
            base.UpdateConditions(method);
            return this;
        }

        new public SpecialRenderingBuilder<TModel> ViewConditions(Func<TModel, StatusMessage> method)
        {
            base.ViewConditions(method);
            return this;
        }

        new public SpecialRenderingBuilder<TModel> DeleteConditions(Func<TModel, StatusMessage> method)
        {
            base.DeleteConditions(method);
            return this;
        }

        new public SpecialRenderingBuilder<TModel> InsertConditions(Func<TModel, StatusMessage> method)
        {
            base.InsertConditions(method);
            return this;
        }

        /// Set Request Link
        new public SpecialRenderingBuilder<TModel> RequestLink(string url)
        {
            this.Builder.SetRequestLink(url);
            return this;
        }

        // Set background colour on condition
        new public SpecialRenderingBuilder<TModel> BackgroundColourOnCondition(Expression<Func<TModel, string>> expression)
        {
            this.Builder.SetBackgroundColourOnCondition(expression);
            return this;
        }

        // Set foreground colour on condition
        new public SpecialRenderingBuilder<TModel> ForegroundColourOnCondition(Expression<Func<TModel, string>> expression)
        {
            this.Builder.SetForegroundColourOnCondition(expression);
            return this;
        }

        /// Set table list as multiple selection
        new public SpecialRenderingBuilder<TModel> MultipleSelection()
        {
            this.Builder.SetMultipleSelection();
            return this;
        }

        /// Adds a following action to the current table
        new public SpecialRenderingBuilder<TModel> AddTableAction(string action, string controller, System.Func<TModel, object> routeValuesFun, string icon, string title, bool isBootStrapIcon = false, bool isRoutine = false, bool multipleSelection = false, bool isAjaxAction = false, object htmlAttributes = null, bool accesslevel = true, bool isSlotReport = false, string slotReportId = "", bool openInPopup = false)
        {
            Builder.AddTableActionInternal(action, controller, routeValuesFun, icon, title, isBootStrapIcon, isRoutine, multipleSelection, isAjaxAction, htmlAttributes, accesslevel: accesslevel, isSlotReport: isSlotReport, slotReportId: slotReportId, openInPopup: openInPopup);
            return this;
        }

        public MvcHtmlString ToSpecialRenderingHtml(bool hidden = false)
        {
            return new SpecialRenderingRenderer<TModel>(Builder, Followup, SpecialRendering).ToHtml(hidden);
        }
    }

    public class SpecialRenderingRenderer<TModel> : DbEditRenderer<TModel> where TModel : class
    {
        protected readonly SpecialRendering SpecialRendering;

        private readonly TableAction<TModel> Followup;

        public SpecialRenderingRenderer(Table<TModel> builder, TableAction<TModel> followup, SpecialRendering specialRendering)
            : base(builder)
        {
            Followup = followup;
            SpecialRendering = specialRendering;
        }

        public override MvcHtmlString ToHtml(bool hidden = false)
        {
            StringBuilder result = new StringBuilder();

            string html = string.Empty;
            if (!hidden && SpecialRendering != null)
            {
                result.Append(Render(SpecialRendering));

                html += result.ToString();

                TagBuilder footer = Footer();
                if (!string.IsNullOrEmpty(footer.InnerHtml))
                    html += footer;
            }

            return new MvcHtmlString(html);
        }

        public string Render(SpecialRendering rendering)
        {
            ControllerBase controller = Builder.HtmlHelper.ViewContext.Controller;

            Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
            if (Builder.Form.OpenInPopup)
            {
                htmlAttributes.Add("data-modal-form", true);
                htmlAttributes.Add("data-table", Builder.TableId);
            }

            // initialize a string builder
            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                ViewDataDictionary props = new ViewDataDictionary();

                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                foreach (TModel model in Builder.Data)
                {
                    Dictionary<string, object> row = new Dictionary<string, object>();
                    foreach (var variable in rendering.MappingVariables.Where(v => v.AllowMultiple))
                        row[variable.Variable] = new List<string[]>();

                    var key = Builder.TableKey.Evaluate(model);
                    var routeData = new RouteValueDictionary();
                    routeData.Add("id", key);

                    // Followup
                    string actionLink = CreateFollowUp(Followup, model);
                    row["followup"] = actionLink;

                    // Actions Button (CRUD actions dropdown toggler)
                    string actionButton = string.Empty;
                    if (!this.Builder.HasOnlyOneAction() || (this.Builder.HasOnlyOneAction() && Followup == null))
                        actionButton = CreateActions(model, routeData, null, cardActions: true);
                    row["actions"] = actionButton;

                    // Mapping variables
                    foreach (ITableColumnInternal<TModel> tc in Builder.TableColumns)
                    {
                        if (!tc.IsActionsColumn && !tc.IsCheckListColumn)
                        {
                            object value;
                            string modelName;
                            string columnName;
                            string columnFieldUpper = tc.ColumnField.ToUpper();
                            CSGenio.business.Area relatedArea = null;

                            if (columnFieldUpper.Contains('.'))
                            {
                                // column from other table
                                modelName = tc.ColumnField.Split('.')[0];
                                columnName = columnFieldUpper.Replace(".VAL", ".");

                                Models.ModelBase rModel = (Models.ModelBase)model.GetType().GetProperty(modelName).GetValue(model, null);
                                relatedArea = rModel.baseklass;
                                value = relatedArea.returnValueField(columnName.ToLower());
                            }
                            else
                            {
                                // column from this table
                                modelName = model.GetType().Name;
                                columnName = model.GetType().Name.ToUpper() + "." + columnFieldUpper.Substring(3);
                                value = model.GetType().GetProperty(tc.ColumnField)?.GetValue(model, null);
                            }

                            // Find all the variables that this column is mapped to
                            var mappedVariables =
                                rendering.MappingVariables
                                    .Where(v => ColumnNameMatches(v.Value.ToUpper(), columnName))
                                    .ToArray();

                            foreach (var variable in mappedVariables)
                            {
                                if (value.GetType() == typeof(byte[]))
                                {
                                    int[] rgb = GetImageDominantColor((byte[])value);
                                    string dominantColor = "rgb(" + rgb[0] + " " + rgb[1] + " " + rgb[2] + ")";
                                    row["dominantColor"] = dominantColor;

                                    string id;
                                    string fldname;
                                    if (columnFieldUpper.Contains('.'))
                                    {
                                        // column from other table
                                        id = relatedArea.QPrimaryKey;
                                        fldname = tc.ColumnField.Split('.')[1];
                                    }
                                    else
                                    {
                                        // column from this table
                                        id = key;
                                        fldname = tc.ColumnField;
                                    }

                                    value = new UrlHelper(Builder.HtmlHelper.ViewContext.RequestContext)
                                        .Action("ImageHandlerGet", "Home", new
                                        {
                                            id,
                                            modelname = modelName,
                                            fldname
                                        });
                                }
                                /*
                                * When the column is numeric, we want to avoid using Evaluate, since it
                                * will add a coma if the number has 4 digits or more, which breaks the graph
                                * Example: 5831 -> 5,831
                                */
                                else if(tc.DataType != ColumnDataType.Numeric)
                                {
                                    value = tc.Evaluate(model);
                                }

                                if (variable.AllowMultiple)
                                {
                                    List<string[]> curr = (List<string[]>)row[variable.Variable];

                                    curr.Add(new string[] { value.ToString(), tc.ColumnTitle });
                                    row[variable.Variable] = curr;
                                }
                                else
                                {
                                    row[variable.Variable] = value;
                                }
                            }

                            // If variable is not mapped
                            if (!mappedVariables.Any() && tc != Builder.TableKey && !columnName.Contains("ZZSTATE"))
                                row[columnName] = value;
                        }
                    }

                    rows.Add(row);
                }

                // Style variables
                Dictionary<string, string> styleVariablesDict = new Dictionary<string, string>();
                foreach (SpecialRenderingVariable variable in rendering.StyleVariables)
                {
                    styleVariablesDict[variable.Variable] = variable.Value;
                }

                props["container-id"] = Guid.NewGuid().ToString("N").Substring(0, 8);
                props["table-id"] = Builder.TableId + "_" + CSGenio.framework.StringUtils.CapFirst(rendering.Id);
                props["subtype"] = rendering.Subtipo;
                props["rows"] = rows;
                props["style-vars"] = styleVariablesDict;

                TempDataDictionary tempDataDictionary = new TempDataDictionary();

                // find and load the view or partial view, pass it through the controller factory
                string path = "../Shared/DisplayTemplates/" + rendering.Id;
                if (!string.IsNullOrEmpty(rendering.Subtipo))
                    path += "/" + rendering.Id;

                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, path);
                
                if (viewResult.View != null)
                {
                    ViewContext viewContext = new ViewContext(controller.ControllerContext, viewResult.View, props, tempDataDictionary, sw);

                    // Render the container
                    viewResult.View.Render(viewContext, sw);
                    return sw.ToString();
                }
                
                return "";
            }
        }

        #region Private methods

        private object GetObjectProperty(object item, string property)
        {
            if (item == null)
                return null;

            int dotIdx = property.IndexOf('.');

            if (dotIdx > 0)
            {
                object obj = GetObjectProperty(item, property.Substring(0, dotIdx));

                return GetObjectProperty(obj, property.Substring(dotIdx + 1));
            }

            PropertyInfo propInfo = null;
            System.Type objectType = item.GetType();

            while (propInfo == null && objectType != null)
            {
                propInfo = objectType.GetProperty(property,
                          BindingFlags.Public
                        | BindingFlags.Instance
                        | BindingFlags.DeclaredOnly);

                objectType = objectType.BaseType;
            }

            if (propInfo != null)
                return propInfo.GetValue(item, null);

            FieldInfo fieldInfo = item.GetType().GetField(property,
                          BindingFlags.Public | BindingFlags.Instance);

            if (fieldInfo != null)
                return fieldInfo.GetValue(item);

            return null;
        }

        private bool ColumnNameMatches(string value, string columnName)
        {
            if (value == columnName)
                return true;

            if (value.Contains(".") && columnName.Contains("."))
            {
                string value_ndbf = value.Split('.')[0];
                string value_field = value.Split('.')[1];
                string column_ndbf = columnName.Split('.')[0];
                string column_field = columnName.Split('.')[1];

                return (value_ndbf == column_ndbf && value_field == column_field) ||
                    (value_ndbf == column_ndbf && value_field.Length == 8 && column_field.StartsWith(value_field));
            }
            return false;
        }

        private int[] GetImageDominantColor(byte[] bytes)
        {
            if (bytes != null && bytes.Length > 0)
            {
                using (var ms = new System.IO.MemoryStream(bytes))
                {
                    try
                    {
                        using (Bitmap bmp = new Bitmap(ms))
                        {
                            int x1 = (int)(bmp.Width * 0.2);
                            int x2 = (int)(bmp.Width * 0.8);
                            int y1 = (int)(bmp.Height * 0.2);
                            int y2 = (int)(bmp.Height * 0.8);

                            Color sample1 = bmp.GetPixel(x1, y1);
                            Color sample2 = bmp.GetPixel(x1, y2);
                            Color sample3 = bmp.GetPixel(x2, y1);
                            Color sample4 = bmp.GetPixel(x2, y2);

                            int avgR = (sample1.R + sample2.R + sample3.R + sample4.R) / 4;
                            int avgG = (sample1.G + sample2.G + sample3.G + sample4.G) / 4;
                            int avgB = (sample1.B + sample2.B + sample3.B + sample4.B) / 4;
                            //return "rgb(" + avgR + " " + avgG + " " + avgB + ")";
                            return new int[] { avgR, avgG, avgB };
                        }
                    }
                    catch
                    {
                        //FIXME: blah, svg
                    }
                }
            }
            return new int[] { 224, 220, 220 };
        }

        protected override TagBuilder Footer()
        {
            TagBuilder tFooter = new TagBuilder("div");
            tFooter.AddCssClass("c-table__footer-out");
            tFooter.AddCssClass("c-sr__footer-out");

            TagBuilder actionsContainer = new TagBuilder("div");

            int countMultipleActions = Builder.TableActions.Count(x => !x.IsFollowUp && x.RequiresMultipleSelection);

            if (countMultipleActions > 0)
            {
                actionsContainer.Attributes.Add("elem-identifier", "ActionsContainer");
                if (LayoutConfig.config.DbEditMultipleActionPlacement == "left")
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
                            actionLink.Attributes["data-target"] = Builder.ajaxUpdateContainerId;
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
                            actionLink.Attributes["data-target"] = Builder.ajaxUpdateContainerId;
                            actionLink.Attributes["data-link"] = actionLink.Attributes["href"];
                            actionLink.Attributes["href"] = "#";
                        }

                        actionLink.InnerHtml = icon.ToString() + " " + actionLink.InnerHtml;
                        ul.InnerHtml += actionLink;
                    }

                    TagBuilder div = new TagBuilder("div");
                    div.AddCssClass("btn-group dropup");
                    TagBuilder a = new TagBuilder("button");

                    a.AddCssClass("b-icon-text b-icon-text--primary dropdown");
                    a.Attributes.Add("data-toggle", "dropdown");
                    a.Attributes.Add("data-boundary", "window");
                    a.Attributes.Add("href", "#");
                    a.InnerHtml += TableString.GroupActions;
                    div.InnerHtml += a;
                    ul.AddCssClass("dropdown-menu");
                    div.InnerHtml += ul;

                    actionsContainer.InnerHtml += div;
                }
            }

            if (Builder.multipleSelection || Builder._DEF_MultipleSelection)
            {
                TagBuilder div = new TagBuilder("div");
                div.Attributes.Add("elem-identifier", "Pagination");
                div.AddCssClass("pagination float-left");

                TagBuilder span = new TagBuilder("span");
                span.Attributes.Add("elem-identifier", "SelectedRecordsCounter");
                span.AddCssClass("selected-records-counter");
                div.InnerHtml += span + " " + TableString.SelectedRecords;

                tFooter.InnerHtml += div;
                tFooter.InnerHtml += actionsContainer;
            }

            if (Builder.hasPagination && !(Builder.Pager.PageNumber == 1 && !Builder.Pager.HasMore))
                tFooter.InnerHtml += PagerRenderer.ToHtml();
            tFooter.InnerHtml += GenerateExtraFooterContent();

            if (Builder.HasLimits())
                tFooter.InnerHtml += GenerateLimitsContent();

            return tFooter;
        }

        #endregion
    }
}
