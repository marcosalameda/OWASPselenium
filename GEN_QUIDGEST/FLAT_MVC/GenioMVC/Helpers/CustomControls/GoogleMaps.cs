using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Helpers.Table.Renderer;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Utils;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GenioMVC.Helpers
{
    public static class GoogleMapsHelper
    {
        public static GoogleMapsBuilder<TModel> GoogleMaps<TModel>(this HtmlHelper helper, bool edit, bool canPage = true, bool canSort = true, bool countRec = false) where TModel : class
        {
            var builder = new Table<TModel>(helper, TableType.SimpleTable, edit, canPage, canSort, countRec);
            return new GoogleMapsBuilder<TModel>(builder, false);
        }
    }

    /// <summary>
    /// Class used to interact with view (Table)
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class GoogleMapsBuilder<TModel> : Table.TableListBuilder<TModel> where TModel : class
    {
        // Empty class created in order to avoid a compilation error
        //Construction
        public GoogleMapsBuilder(Table.Builder.Table<TModel> builder, bool hasFilters)
            : base(builder, hasFilters)
        {
            var _builder = (builder as DbEdit<TModel>);
            if(_builder != null && _builder.Form != null)
                this.Builder.SetForm(_builder.Form.HelpForm, _builder.Form.OpenInPopup, _builder.Form.RepeatInsertion);
        }

        public MvcHtmlString ToGoogleMapsHtml()
        {
            this.Builder.DoInternalActions();

            return new TableGoogleMapsRenderer<TModel>(this.Builder).ToGoogleMapsHtml();
        }
    }

    public class TableGoogleMapsRenderer<TModel> : DbEditRenderer<TModel> where TModel : class
    {

        public TableGoogleMapsRenderer(Table<TModel> builder)
            : base(builder)
        {

        }

        public virtual MvcHtmlString ToGoogleMapsHtml()
        {
            TagBuilder table = new TagBuilder("table");
            table.AddCssClass(String.Join(" ", this.Builder.TableCssClass));

            if (string.IsNullOrEmpty(Builder.TableId))
            {
                table.GenerateId("table");
                Builder.SetId(table.Attributes["id"]);
            }
            if ((this.Builder.TableType == GenioMVC.Helpers.Table.Properties.TableType.GridTableList && (this.Builder as GridTableList<TModel>).IsInEditMode))
                table.Attributes.Add("style", "width: auto;");

            if (Builder.Data.Count() > 0)
            {
                table.AddCssClass("table-striped");
                table.AddCssClass("table");

                if (this.Builder.TableType == GenioMVC.Helpers.Table.Properties.TableType.SearchList)
                    table.AddCssClass("search-list");

                table.InnerHtml += Header();
                table.InnerHtml += Body();
                table.InnerHtml += Footer();
            }
            else
            {
                if (!(this.Builder.TableType == GenioMVC.Helpers.Table.Properties.TableType.GridTableList && (this.Builder as GridTableList<TModel>).IsInEditMode))
                    table.Attributes.Add("style", "width:100%");
                // the Body() adds an ID and a CLASS in order to show an empty map --> fix .js bug.
                table.InnerHtml += Body();
                table.InnerHtml += EmptyList();
            }

            GetHtmlAttributes().ToList().ForEach(p => { if (!table.Attributes.ContainsKey(p.Key)) table.Attributes.Add(p.Key, p.Value); });

            TagBuilder divHiddenFields = new TagBuilder("div");
            divHiddenFields.MergeAttribute("id", Builder.TableId + "_inputs");
            divHiddenFields.InnerHtml = GenerateHiddenFields().ToHtmlString();

            return new MvcHtmlString(table.ToString() + divHiddenFields.ToString() + "<script>" + GenerateScripts().ToHtmlString() + "</script>" + GenerateScriptInitMap().ToHtmlString());
        }

        public MvcHtmlString GenerateScriptInitMap()
        {
            StringBuilder scriptBase = new StringBuilder();
            HttpContextBase context = this.Builder.HtmlHelper.ViewContext.HttpContext;
            StringBuilder includes = new StringBuilder();

            // Load the URL and callback initMap()
            Tuple<string, string> mytuple = properlyRawPlaces();

            String scriptCallback = UrlHelper.GenerateContentUrl("~/Scripts/quidgest/quidgest.googleMaps.js", context);
            // read the google maps key from Configuracao.cs --> ConfiguracaoXML.cs --> Configuracoes.xml
            string googlemapskey = CSGenio.framework.Configuration.GoogleMapsKey;
            string gmapsAPICdnPath = "https://maps.googleapis.com/maps/api/js?libraries=geometry&key=" + googlemapskey + "&callback=initMap";

            includes.AppendFormat("<script src=\"{0}\" async defer></script>", gmapsAPICdnPath);
            includes.AppendFormat("<script src=\"{0}\" type=\"text/javascript\"></script>", scriptCallback);
            

            string newScript = @"
            <script>
                try {
                    function initMap()
                        {
                        var stringActions = [];
                        stringActions = " + mytuple.Item2 + @"
                        var places = " + mytuple.Item1 + @"
                        quidgestInitMap('" + Builder.TableId + @"', places, stringActions)
                    };
                } catch (err) {
                    window.location.pathname = location.pathname;
                }
            </script>";

            scriptBase.Append(includes);
            scriptBase.Append(newScript);
            
            return new MvcHtmlString(scriptBase.ToString());
        }
        protected override TagBuilder Header()
        {
            // Creates an empty tableHeader
            // Think about something to write/show if needed.
            TagBuilder tHead = new TagBuilder("thead");
            TagBuilder trHead = new TagBuilder("tr");

            TModel model = Builder.Data.FirstOrDefault();
            tHead.InnerHtml += trHead.ToString();

            return tHead;
        }

        protected override TagBuilder Body()
        {
            // only one row with one cell is created to show the map.
            // the size of the map is defined by css class "gmaps" in quidgest.less

            TagBuilder tBody = new TagBuilder("tbody");
            TagBuilder trBody = new TagBuilder("tr");
            TagBuilder tdBody = new TagBuilder("td");

            tdBody.Attributes.Add("id", Builder.TableId);
            tdBody.Attributes.Add("class", "gmaps");

            trBody.InnerHtml += tdBody;
            tBody.InnerHtml += trBody;

            return tBody;
        }

        public class auxGeoLocation
        {
            public double lat;
            public double lng;
        }

        public class auxGeoInfo
        {
            public List<auxGeoLocation> location = new List<auxGeoLocation>();
            public Dictionary<string, List<string>> properties = new Dictionary<string, List<string>>();
            public List<string> actions = new List<string>();
        }

        public Tuple<string, string> properlyRawPlaces()
        {

            auxGeoInfo infoWinGM = new auxGeoInfo();

            string[] aux2 = null;
            foreach (TModel model in Builder.Data)
            {
                PropertyInfo key_property = model.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(KeyAttribute))).FirstOrDefault();
                RouteValueDictionary routeValueDictionary = new RouteValueDictionary();
                routeValueDictionary.Add("id", Builder.TableKey.Evaluate(model));

                string idValueActions = Builder.TableKey.Evaluate(model).ToString();
                infoWinGM.actions.Add(idValueActions);
                bool notNull = false;

                foreach (ITableColumnInternal<TModel> tc in Builder.TableColumns)
                {
                    if (tc.ColumnVisible && !tc.IsActionsColumn && !tc.IsCheckListColumn)
                    {
                        if (tc.Evaluate(model).StartsWith("POINT("))
                        {
                            //locations
                            var coord = tc.Evaluate(model).Replace("POINT(", "").Replace(")", "").Split(' ');
                            var val = new auxGeoLocation()
                            {
                                lat = double.Parse(coord[1], CultureInfo.InvariantCulture),
                                lng = double.Parse(coord[0], CultureInfo.InvariantCulture)
                            };
                            // has coordenates -> register is not null
                            notNull = true;
                            infoWinGM.location.Add(val);
                        }
                        else
                        {
                            //properties
                            if (infoWinGM.properties.ContainsKey(tc.ColumnTitle))
                                infoWinGM.properties[tc.ColumnTitle].Add(tc.Evaluate(model));
                            else
                                infoWinGM.properties.Add(tc.ColumnTitle, new List<string> { tc.Evaluate(model) });
                        }
                    }
                    else if (tc.ColumnVisible && tc.IsActionsColumn)
                    {
                        //actions
                        String newMyHelper = CreateActions(model, routeValueDictionary, tc);
                        string aux = newMyHelper;
                        aux2 = aux.Split(new string[] { idValueActions }, StringSplitOptions.None);
                    }
                }
                if (!notNull)
                {
                    // delete last record added if coordenates are null
                    infoWinGM.actions.Remove(infoWinGM.actions.Last());
                    // check if there is already any record not null. Delete all properties if it is the first
                    if (infoWinGM.location.Count() == 0)
                        infoWinGM.properties.Clear();
                    // only delete the location property. Will be the last key
                    else
                        infoWinGM.properties.Remove(infoWinGM.properties.Keys.Last().ToString());
                    var dictionaryKeys = infoWinGM.properties.Keys.ToArray();
                    for (int i = 0; i < dictionaryKeys.Length; i++)
                        infoWinGM.properties[dictionaryKeys[i]].Remove(infoWinGM.properties[dictionaryKeys[i]].Last().ToString());
                }
            }
            string myJson2 = JsonConvert.SerializeObject(aux2, Formatting.Indented);
            string myJson = JsonConvert.SerializeObject(infoWinGM, Formatting.Indented);
            return Tuple.Create(myJson, myJson2);
        }

        protected override string CreateActions(TModel model, RouteValueDictionary routeValueDictionary, ITableColumnInternal<TModel> tableColumn, bool cardActions = false)
        {
            int actionsNumber = 0;
            TagBuilder ul = new TagBuilder("ul");

            Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
            if (this.Builder.Form.OpenInPopup)
            {
                htmlAttributes.Add("data-modal-form", true);
                htmlAttributes.Add("data-table", this.Builder.TableId);
            }

            foreach (TableAction<TModel> tAction in TableUtils.GetTableActions(this.Builder.TableActions))
            {
                TagBuilder li = new TagBuilder("li");
                TagBuilder actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, tAction.Action, tAction.Controller, model, tAction.RouteValuesFun, tAction.Title, tAction.IsRoutine, tAction.HtmlAttributes);

                TagBuilder icon = TableUtils.MakeIcon(Builder.HtmlHelper, tAction.Icon, tAction.IsBootStrapIcon);
                if (tAction.IsAjaxAction)
                {
                    actionLink.Attributes["data-target"] = this.Builder.ajaxUpdateContainerId;
                    actionLink.Attributes["data-link"] = actionLink.Attributes["href"];
                    actionLink.Attributes["href"] = "#";
                }
                actionLink.Attributes.Add("qbutton", "action");
                actionLink.InnerHtml = icon.ToString() + " " + actionLink.InnerHtml;

                if (this.Builder.HasOnlyOneAction())
                {
                    actionLink.AddCssClass("btn " + this.buttonSize);
                    return actionLink.ToString();
                }

                ul.InnerHtml += actionLink;
                ul.InnerHtml += ul.ToString();

                actionsNumber++;

            }

            if (actionsNumber > 0 && (Builder.HasViewAction() || Builder.HasEditAction() || Builder.HasDuplicateAction() || Builder.HasDeleteAction()))
            {
                TagBuilder divider = new TagBuilder("span");
                divider.AddCssClass("divider");
                ul.InnerHtml += divider.ToString();
            }

            // If has FollowUp and has View Access
            if (Builder.HasViewAction())
            {
                TagBuilder span = new TagBuilder("span");

                TagBuilder actionLink;
                TableAction<TModel> fAction = TableUtils.GetSepecificPathsFollowUpAction(this.Builder.TableActions);

                if (fAction != null)
                {
                    routeValueDictionary.Add("formMode", "Show");
                    actionLink = TableUtils.MakeButtonActionLink<TModel>(Builder.HtmlHelper, fAction.Action, routeValueDictionary, null, htmlAttributes, fAction.Controller);
                    routeValueDictionary.Remove("formMode");
                }
                else
                {
                    actionLink = TableUtils.MakeButtonActionLink<TModel>(Builder.HtmlHelper, Builder.Form.HelpForm + "_Show", routeValueDictionary, null, htmlAttributes);
                }
                actionLink.Attributes.Add("onclick", "onNavigation(event, this, 'SHOW')");
                actionLink.Attributes.Add("qbutton", "show");
                actionLink.AddCssClass("b-btn b-icon b-icon--secondary ");
                TagBuilder icon = TableUtils.MakeIcon(Builder.HtmlHelper, "glyphicons glyphicons-eye-open e-icon", true);

                actionLink.InnerHtml = icon.ToString() + " " + actionLink.InnerHtml;

                if (this.Builder.HasOnlyOneAction())
                {
                    actionLink.AddCssClass("b-btn b-icon b-icon--secondary " + this.buttonSize);
                    return actionLink.ToString();
                }

                span.InnerHtml += actionLink;
                ul.InnerHtml += span.ToString();

                actionsNumber++;
            }
            if (Builder.HasEditAction())
            {
                TagBuilder span = new TagBuilder("span");

                TagBuilder actionLink;
                TableAction<TModel> fAction = TableUtils.GetSepecificPathsFollowUpAction(this.Builder.TableActions);

                if (fAction != null)
                {
                    routeValueDictionary.Add("formMode", "Edit");
                    actionLink = TableUtils.MakeButtonActionLink<TModel>(Builder.HtmlHelper, fAction.Action, routeValueDictionary, null, htmlAttributes, fAction.Controller);
                    routeValueDictionary.Remove("formMode");
                }
                else
                {
                    actionLink = TableUtils.MakeButtonActionLink<TModel>(Builder.HtmlHelper, Builder.Form.HelpForm + "_Edit", routeValueDictionary, null, htmlAttributes);
                }
                actionLink.Attributes.Add("onclick", "onNavigation(event, this, 'EDIT')");
                actionLink.Attributes.Add("qbutton", "edit");
                actionLink.AddCssClass("b-btn b-icon b-icon--secondary ");
                TagBuilder icon = TableUtils.MakeIcon(Builder.HtmlHelper, "glyphicons glyphicons-pencil e-icon", true);

                actionLink.InnerHtml = icon.ToString() + " " + actionLink.InnerHtml;

                if (this.Builder.HasOnlyOneAction())
                {
                    actionLink.AddCssClass("b-btn b-icon b-icon--secondary " + this.buttonSize);
                    return actionLink.ToString();
                }

                span.InnerHtml += actionLink;
                ul.InnerHtml += span.ToString();

                actionsNumber++;
            }
            if (Builder.HasDuplicateAction())
            {
                TagBuilder span = new TagBuilder("span");

                TagBuilder actionLink;
                TableAction<TModel> fAction = TableUtils.GetSepecificPathsFollowUpAction(this.Builder.TableActions);

                if (fAction != null)
                {
                    routeValueDictionary.Add("formMode", "Dup");
                    actionLink = TableUtils.MakeButtonActionLink<TModel>(Builder.HtmlHelper, fAction.Action, routeValueDictionary, null, htmlAttributes, fAction.Controller);
                    routeValueDictionary.Remove("formMode");
                }
                else
                {
                    actionLink = TableUtils.MakeButtonActionLink<TModel>(Builder.HtmlHelper, Builder.Form.HelpForm + "_Duplicate", routeValueDictionary, null, htmlAttributes);
                }
                actionLink.Attributes.Add("onclick", "onNavigation(event, this, 'DUP')");
                actionLink.Attributes.Add("qbutton", "duplicate");
                actionLink.AddCssClass("b-btn b-icon b-icon--secondary ");
                TagBuilder icon = TableUtils.MakeIcon(Builder.HtmlHelper, "glyphicons glyphicons-retweet e-icon", true);

                actionLink.InnerHtml = icon.ToString() + " " + actionLink.InnerHtml;

                if (this.Builder.HasOnlyOneAction())
                {
                    actionLink.AddCssClass("b-btn b-icon b-icon--secondary " + this.buttonSize);
                    return actionLink.ToString();
                }

                span.InnerHtml += actionLink;
                ul.InnerHtml += span.ToString();

                actionsNumber++;
            }
            if (Builder.HasDeleteAction())
            {
                TagBuilder span = new TagBuilder("span");

                TagBuilder actionLink;
                TableAction<TModel> fAction = TableUtils.GetSepecificPathsFollowUpAction(this.Builder.TableActions);

                if (fAction != null)
                {
                    routeValueDictionary.Add("formMode", "Delete");
                    actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, fAction.Action, routeValueDictionary, null, htmlAttributes, fAction.Controller);
                    routeValueDictionary.Remove("formMode");
                }
                else
                {
                    actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, Builder.Form.HelpForm + "_Delete", routeValueDictionary, null, htmlAttributes);
                }
                actionLink.Attributes.Add("onclick", "onNavigation(event, this, 'DELETE')");
                actionLink.Attributes.Add("qbutton", "delete");
                actionLink.AddCssClass("b-btn b-icon b-icon--secondary ");
                TagBuilder icon = TableUtils.MakeIcon(Builder.HtmlHelper, "glyphicons glyphicons-delete e-icon", true);

                actionLink.InnerHtml = icon.ToString() + " " + actionLink.InnerHtml;

                if (this.Builder.HasOnlyOneAction())
                {
                    actionLink.AddCssClass("b-btn b-icon b-icon--secondary " + this.buttonSize);
                    return actionLink.ToString();
                }

                span.InnerHtml += actionLink;
                ul.InnerHtml += span.ToString();

                actionsNumber++;
            }

            if (actionsNumber > 0)
                return ul.ToString();

            return "";
        }

        protected override TagBuilder Footer()
        {
            TagBuilder tFooter = new TagBuilder("tfoot");
            TagBuilder trFooter = new TagBuilder("tr");
            TagBuilder tdFooter = new TagBuilder("td");
            tdFooter.Attributes.Add("colspan", Builder.TableColumns.Where(x => x.ColumnVisible).Count().ToString());

            TagBuilder actionsContainer = new TagBuilder("div");

            int countMultipleActions = Builder.TableActions.Where(x => !x.IsFollowUp && x.RequiresMultipleSelection).Count();

            if (countMultipleActions > 0)
            {
                actionsContainer.AddCssClass("ms-actions-container pull-right");
                if (countMultipleActions == 1)
                {
                    foreach (TableAction<TModel> tAction in Builder.TableActions.Where(x => !x.IsFollowUp && x.RequiresMultipleSelection))
                    {
                        TagBuilder li = new TagBuilder("li");
                        RouteValueDictionary htmlAttr = HtmlHelper.AnonymousObjectToHtmlAttributes(tAction.HtmlAttributes);
                        TagBuilder actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, tAction.Action, tAction.Controller, tAction.Title, htmlAttr);
                        TagBuilder icon = TableUtils.MakeIcon(Builder.HtmlHelper, tAction.Icon, tAction.IsBootStrapIcon);
                        actionLink.Attributes["class"] = "btn";
                        actionLink.Attributes["data-routine"] = tAction.Action;
                        //actionLink.Attributes["data-target"] = this.Builder.ajaxUpdateContainerId;
                        //actionLink.Attributes["data-link"] = actionLink.Attributes["href"];
                        actionLink.Attributes["href"] = "#";
                        actionLink.InnerHtml = icon.ToString() + " " + actionLink.InnerHtml;

                        actionsContainer.InnerHtml += actionLink;
                    }
                }
                else
                {
                    TagBuilder ul = new TagBuilder("ul");

                    foreach (TableAction<TModel> tAction in Builder.TableActions.Where(x => !x.IsFollowUp && x.RequiresMultipleSelection))
                    {
                        TagBuilder li = new TagBuilder("li");
                        RouteValueDictionary htmlAttr = HtmlHelper.AnonymousObjectToHtmlAttributes(tAction.HtmlAttributes);

                        TagBuilder actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, tAction.Action, tAction.Controller, tAction.Title, htmlAttr);

                        TagBuilder icon = TableUtils.MakeIcon(Builder.HtmlHelper, tAction.Icon, tAction.IsBootStrapIcon);
                        actionLink.Attributes["data-routine"] = tAction.Action;
                        //actionLink.Attributes["data-link"] = actionLink.Attributes["href"];
                        actionLink.Attributes["href"] = "#";

                        actionLink.InnerHtml = icon.ToString() + " " + actionLink.InnerHtml;

                        li.InnerHtml += actionLink;
                        ul.InnerHtml += li;
                    }

                    TagBuilder div = new TagBuilder("div");
                    div.AddCssClass("btn-group dropup");
                    TagBuilder a = new TagBuilder("a");
                    TagBuilder span = new TagBuilder("span");
                    span.AddCssClass("caret");
                    a.AddCssClass("btn dropdown-toggle");
                    a.Attributes.Add("data-toggle", "dropdown");
                    a.Attributes.Add("href", "#");
                    a.InnerHtml += TableString.GroupActions + " " + span;
                    div.InnerHtml += a;
                    ul.AddCssClass("dropdown-menu");
                    div.InnerHtml += ul;

                    actionsContainer.InnerHtml += div;
                }

            }
            tdFooter.InnerHtml += GenerateExtraFooterContent();

			if (this.Builder.HasLimits())
                tdFooter.InnerHtml += GenerateLimitsContent();

            trFooter.InnerHtml += tdFooter;
            tFooter.InnerHtml += trFooter;
            return tFooter;
        }
    }
}