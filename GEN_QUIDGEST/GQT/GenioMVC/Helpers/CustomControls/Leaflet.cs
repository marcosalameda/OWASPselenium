using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Helpers.Table.Renderer;
using GenioMVC.Helpers.Table.Utils;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GenioMVC.Helpers
{
    public static class LeafletHelper
    {
        public static LeafletBuilder<TModel> Leaflet<TModel>(this HtmlHelper helper, bool edit, bool canPage = true, bool canSort = true, bool countRec = false) where TModel : class
        {
            var builder = new Table<TModel>(helper, TableType.SimpleTable, edit, canPage, canSort, countRec);
            return new LeafletBuilder<TModel>(builder, false);
        }
    }

    /// <summary>
    /// Class used to interact with view (Table)
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class LeafletBuilder<TModel> : Table.TableListBuilder<TModel> where TModel : class
    {
        // Empty class created in order to avoid a compilation error
        //Construction
        public LeafletBuilder(Table.Builder.Table<TModel> builder, bool hasFilters)
            : base(builder, hasFilters)
        {
            var _builder = (builder as DbEdit<TModel>);
            if (_builder != null && _builder.Form != null)
                this.Builder.SetForm(_builder.Form.HelpForm, _builder.Form.OpenInPopup, _builder.Form.RepeatInsertion);
        }

        public MvcHtmlString ToLeafletHtml()
        {
            //this.Builder.DoInternalActions();
            return new TableLeafletRenderer<TModel>(this.Builder).ToLeafletHtml();
        }
    }

    public class TableLeafletRenderer<TModel> : DbEditRenderer<TModel> where TModel : class
    {
        public TableLeafletRenderer(Table<TModel> builder)
            : base(builder) { }

        public MvcHtmlString ToLeafletHtml()
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

            // leaflet
            String leafletCss = UrlHelper.GenerateContentUrl("~/Content/stylesheets/leaflet/leaflet.css", context);
            String leafletScript = UrlHelper.GenerateContentUrl("~/Scripts/leaflet/leaflet.js", context);

            // marker cluster
            String markerClusterCss = UrlHelper.GenerateContentUrl("~/Content/stylesheets/leaflet/MarkerCluster.css", context);
            String markerClusterDefaultCss = UrlHelper.GenerateContentUrl("~/Content/stylesheets/leaflet/MarkerCluster.Default.css", context);
            String markerClusterScript = UrlHelper.GenerateContentUrl("~/Scripts/leaflet/leaflet.markercluster.js", context);

            // geo coder (disabled)
            //String geoCoderCss = UrlHelper.GenerateContentUrl("~/Content/stylesheets/leaflet/Control.Geocoder.css", context);
            //String geoCoderScript = UrlHelper.GenerateContentUrl("~/Scripts/leaflet/Control.Geocoder.js", context);

            // full screen
            String fullScreenCss = UrlHelper.GenerateContentUrl("~/Content/stylesheets/leaflet/Leaflet.fullscreen.css", context);
            String fullScreenScript = UrlHelper.GenerateContentUrl("~/Scripts/leaflet/Leaflet.fullscreen.js", context);

            //<link rel="stylesheet" href="https://unpkg.com/leaflet-routing-machine@latest/dist/leaflet-routing-machine.css" />
            //<script src="https://unpkg.com/leaflet-routing-machine@latest/dist/leaflet-routing-machine.js"></script>

            scriptBase.AppendLine(string.Format("<link href=\"{0}\" rel=\"stylesheet\"/>", leafletCss));
            scriptBase.AppendLine(string.Format("<link href=\"{0}\" rel=\"stylesheet\"/>", markerClusterCss));
            scriptBase.AppendLine(string.Format("<link href=\"{0}\" rel=\"stylesheet\"/>", markerClusterDefaultCss));
            //scriptBase.AppendLine(string.Format("<link href=\"{0}\" rel=\"stylesheet\"/>", geoCoderCss));
            scriptBase.AppendLine(string.Format("<link href=\"{0}\" rel=\"stylesheet\"/>", fullScreenCss));

            scriptBase.AppendLine(string.Format("<script src=\"{0}\" type=\"text/javascript\"></script>", leafletScript));
            scriptBase.AppendLine(string.Format("<script src=\"{0}\" type=\"text/javascript\"></script>", markerClusterScript));
            //scriptBase.AppendLine(string.Format("<script src=\"{0}\" type=\"text/javascript\"></script>", geoCoderScript));
            scriptBase.AppendLine(string.Format("<script src=\"{0}\" type=\"text/javascript\"></script>", fullScreenScript));

            List<String> iconFields = new List<string>()
                {
                    "LAYRNAME",
                    "ICONURL",
                    "SHADOWUR",
                    "ICONWID",
                    "ICONHEIG",
                    "SHADOWWI",
                    "SHADOWHE",
                    "ICONANCX",
                    "ICONANCY",
                    "SHADOWAX",
                    "SHADOWAY",
                    "POPUPANX",
                    "POPUPANY"
                };

            double minLat = 90, maxLat = -90, minLng = 180, maxLng = -180;
            LayerGroup defaulLayer = new LayerGroup("Defaul layer");
            List<LayerGroup> layers = new List<LayerGroup>();
            var points = GetLeafletPoints();
            var js = new StringBuilder();

            // 'http://openptmap.org/tiles/{z}/{x}/{y}.png'
            // 'http://{s}.tile.osm.org/{z}/{x}/{y}.png'
            js.AppendLine(@"var osm = L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png',
                {
                    attribution: '&copy; <a href=""http://openstreetmap.org"">OpenStreetMap</a>'
                });"
            );
            js.AppendLine(@"var grayscale = L.tileLayer('https://server.arcgisonline.com/ArcGIS/rest/services/Canvas/World_Light_Gray_Base/MapServer/tile/{z}/{y}/{x}',
                {
                    attribution: 'Tiles &copy; Esri &mdash; Esri, DeLorme, NAVTEQ',
                });"
            );
            js.AppendLine("var markerCluster = new L.MarkerClusterGroup();");

            foreach (var point in points)
            {
                minLat = Math.Min(minLat, point.Location.Lat);
                minLng = Math.Min(minLng, point.Location.Lng);
                maxLat = Math.Max(maxLat, point.Location.Lat);
                maxLng = Math.Max(maxLng, point.Location.Lng);
                string coord = "[" + point.Location.Lat.ToString(CultureInfo.InvariantCulture) + ", " + point.Location.Lng.ToString(CultureInfo.InvariantCulture) + "]";
                var popupContent = new StringBuilder();
                string layerName = "";
                string iconUrlStr = "";
                string shwdUrlStr = "";
                string iconSizeW = "";
                string iconSizeH = "";
                string shadowSizeW = "";
                string shadowSizeH = "";
                string iconAnchorX = "";
                string iconAnchorY = "";
                string shadowAnchorX = "";
                string shadowAnchorY = "";
                string popupAnchorX = "";
                string popupAnchorY = "";

                string columnName = "";

                popupContent.Append("<table class=\"c-table\"><tbody class=\"c-table__body\">");

                foreach (var column in point.Columns)
                {
                    columnName = CheckIconFields(column.Name.ToUpper(), iconFields);
                    switch (columnName)
                    {
                        case "LAYRNAME": //layerName
                            layerName = column.Value;
                            break;
                        case "ICONURL": //iconUrl
                            iconUrlStr = UrlHelper.GenerateContentUrl("~/Content/stylesheets/leaflet/images/" + column.Value, context);
                            break;
                        case "SHADOWUR": //shadowUrl
                            shwdUrlStr = UrlHelper.GenerateContentUrl("~/Content/stylesheets/leaflet/images/" + column.Value, context);
                            break;
                        case "ICONWID": //iconSize (width)
                            iconSizeW = column.Value;
                            break;
                        case "ICONHEIG": //iconSize (height)
                            iconSizeH = column.Value;
                            break;
                        case "SHADOWWI": //shadowSize (width)
                            shadowSizeW = column.Value;
                            break;
                        case "SHADOWHE": //shadowSize (height)
                            shadowSizeH = column.Value;
                            break;
                        case "ICONANCX": //iconAnchor (x-axis)
                            iconAnchorX = column.Value;
                            break;
                        case "ICONANCY": //iconAnchor (y-axis)
                            iconAnchorY = column.Value;
                            break;
                        case "SHADOWAX": //shadowAnchor (x-axis)
                            shadowAnchorX = column.Value;
                            break;
                        case "SHADOWAY": //shadowAnchor (y-axis)
                            shadowAnchorY = column.Value;
                            break;
                        case "POPUPANX": //popupAnchor (x-axis)
                            popupAnchorX = column.Value;
                            break;
                        case "POPUPANY": //popupAnchor (y-axis)
                            popupAnchorY = column.Value;
                            break;
                        default:
                            popupContent.AppendFormat("<tr><td><strong>{0}</strong></td><td>{1}</td></tr>", column.Title, column.Value);
                            break;
                    }
                }
                popupContent.AppendFormat("</tbody></table><div class=\"leaflet-popup-actions b-btn-group\">{0}</div>", point.Actions);

                point.Popup = HttpUtility.JavaScriptStringEncode(popupContent.ToString(), true);
                // custom icon
                if (layerName.Length > 0)
                {
                    LayerGroup layer;
                    int index = layers.FindIndex(layerx => layerx.LayerName.Equals(layerName, StringComparison.Ordinal));

                    if (index == -1)
                    {
                        layer = new LayerGroup(layerName);
                        layer.LayerName = layerName;
                        Icon icon = new Icon(
                            iconUrlStr,
                            shwdUrlStr,
                            "[" + iconSizeW + "," + iconSizeH + "]",
                            "[" + shadowSizeW + ", " + shadowSizeH + "]",
                            "[" + iconAnchorX + ", " + iconAnchorY + "]",
                            "[" + shadowAnchorX + ", " + shadowAnchorY + "]",
                            "[" + popupAnchorX + ", " + popupAnchorY + "]"
                            );
                        layer.Icon = icon;
                        layers.Add(layer);
                    }
                    else
                    {
                        layer = layers[index];
                    }
                    layer.Points.Add(point);
                }
                // default icon
                else
                {
                    defaulLayer.Points.Add(point);
                }
            }

            bool _defaultLayer = false;
            if (layers.Count == 0)
            {
                layers.Add(defaulLayer);
                _defaultLayer = true;
            }
            
            string overLays = "var overlayMaps = {";
            string overlaysContent = "";
            foreach (LayerGroup layer in layers)
            {
                if (!_defaultLayer)
                    js.AppendLine(@"var I" + layer.LayerCode + " = L.icon({" +
                                        "iconUrl: '" + layer.Icon.IconUrlStr + "', " +
                                        "shadowUrl: '" + layer.Icon.ShwdUrlStr + "', " +
                                        "iconSize: " + layer.Icon.IconSize + ", " +
                                        "shadowSize: " + layer.Icon.ShadowSize + ", " +
                                        "iconAnchor: " + layer.Icon.IconAnchor + ", " +
                                        "shadowAnchor: " + layer.Icon.ShadowAnchor + ", " +
                                        "popupAnchor: " + layer.Icon.PopupAnchor +
                                        "});");

                overlaysContent = "var L" + layer.LayerCode + " = L.layerGroup([";
                foreach (var marker in layer.Points)
                {
                    overlaysContent += "L.marker(" + marker.Location + ((!_defaultLayer) ? ", {icon: I" + layer.LayerCode + "}" : "") + ").bindPopup(" + marker.Popup + "), ";
                }
                overlaysContent += "]); ";
                js.AppendLine(overlaysContent);

                overLays += "'" + layer.LayerName + "': L" + layer.LayerCode + ",";

                js.AppendLine("markerCluster.addLayer(L" + layer.LayerCode + ");");
            }
            overLays += "'Marker Cluster': markerCluster};";

            string map = "var map = L.map('" + Builder.TableId + "', { layers: [osm, markerCluster] }); ";
            string bounds = "var bounds = [[" + maxLat.ToString("0.000000", CultureInfo.CreateSpecificCulture("en-US")) + ", " + maxLng.ToString("0.000000", CultureInfo.CreateSpecificCulture("en-US")) + " ], [" +
                minLat.ToString("0.000000", CultureInfo.CreateSpecificCulture("en-US")) + ", " + minLng.ToString("0.000000", CultureInfo.CreateSpecificCulture("en-US")) + "]];";

            string mainScript = @"
            <div id='" + Builder.TableId + @"'></div>
			<script>
                " + js.ToString() + @"
                var maps = {
                        'OpenStreetMap': osm, 
                        'Grayscale': grayscale, };
                " + 
                overLays + map + bounds +
                @"
                map.addLayer(markerCluster);
                L.control.scale().addTo(map);
                L.control.layers(maps, overlayMaps).addTo(map);
                map.addControl(new L.Control.Fullscreen({
                    title: {
                        'false': 'View Fullscreen',
                        'true': 'Exit Fullscreen'
                    }
                }));
                map.fitBounds(bounds, {padding: [50, 50]});
                map.on('click', function(e)
                {
                    map.invalidateSize();
                });

                " +
                @"$('#"+ Builder.TableId + @"').closest(" +"'[elem-identifier=\"AccordionGroup\"]'" +@").on('shown.bs.collapse', function (e) {
                    map.invalidateSize();
                });
                "
                +
           "</script>";

            scriptBase.Append(mainScript);
            scriptBase.Append(Footer());
            return new MvcHtmlString(scriptBase.ToString());
        }

        private class GeoLocation
        {
            public GeoLocation(double lat, double lng)
            {
                Lat = lat;
                Lng = lng;
            }
            public override string ToString()
            {
                return "[" + Lat.ToString("0.000000", CultureInfo.CreateSpecificCulture("en-US")) + "," + Lng.ToString("0.000000", CultureInfo.CreateSpecificCulture("en-US")) + "]";
            }

            public double Lat { get; set; }
            public double Lng { get; set; }
        }

        private class PointColumnInfo
        {
            public PointColumnInfo(string title, string value, string name)
            {
                Title = title;
                Value = value;
                Name = name;
            }

            public string Title { get; set; }
            public string Value { get; set; }
            public string Name { get; set; }
        }

        private class LeafletPointInfo
        {
            public LeafletPointInfo() { Columns = new List<PointColumnInfo>(); }
            public GeoLocation Location { get; set; }
            public string Key { get; set; }
            public List<PointColumnInfo> Columns { get; set; }
            public string Actions { get; set; }
            public string Popup { get; set; }
        }

        private class Icon
        {
            public string IconUrlStr { get; set; }
            public string ShwdUrlStr { get; set; }
            public string IconSize { get; set; }
            public string ShadowSize { get; set; }
            public string IconAnchor { get; set; }
            public string ShadowAnchor { get; set; }
            public string PopupAnchor { get; set; }

            public Icon(string iconUrlStr, string shwdUrlStr, string iconSize, string shadowSize, string iconAnchor, string shadowAnchor, string popupAnchor)
            {
                IconUrlStr = iconUrlStr;
                ShwdUrlStr = shwdUrlStr;
                IconSize = iconSize;
                ShadowSize = shadowSize;
                IconAnchor = iconAnchor;
                ShadowAnchor = shadowAnchor;
                PopupAnchor = popupAnchor;
            }
        }

        private class LayerGroup : IEquatable<LayerGroup>
        {
            public string LayerCode { get; set; }
            public string LayerName { get; set; }
            public Icon Icon { get; set; }
            public List<LeafletPointInfo> Points { get; set; }

            public LayerGroup(string layer_name)
            {
                Random random = new Random();
                LayerName = layer_name ?? throw new ArgumentNullException(nameof(layer_name));
                try
                {
                    LayerCode = "_" + layer_name.Substring(0, 2) + random.Next(10, 9999).ToString();
                    Points = new List<LeafletPointInfo>();
                }
                catch (ArgumentOutOfRangeException)
                {
                    LayerCode = "";
                }
            }

            public LayerGroup(string layer_name, Icon icon)
            {
                LayerGroup layer = new LayerGroup(layer_name);
                layer.Icon = icon;
            }

            public override string ToString()
            {
                return LayerName;
            }
            public bool Equals(LayerGroup other)
            {
                if (other == null) return false;
                if (LayerName != other.LayerName) return false;
                return true;
            }
        }

       
        private List<LeafletPointInfo> GetLeafletPoints()
        {

            List<String> iconFields = new List<string>()
                {
                    "LAYRNAME",
                    "ICONURL",
                    "SHADOWUR",
                    "ICONWID",
                    "ICONHEIG",
                    "SHADOWWI",
                    "SHADOWHE",
                    "ICONANCX",
                    "ICONANCY",
                    "SHADOWAX",
                    "SHADOWAY",
                    "POPUPANX",
                    "POPUPANY"
                };

            var points = new List<LeafletPointInfo>();

            foreach (TModel model in Builder.Data)
            {
                var point = new LeafletPointInfo();
                point.Key = Builder.TableKey.Evaluate(model);

                foreach (ITableColumnInternal<TModel> tc in Builder.TableColumns)
                {
                    if (tc.ColumnVisible && !tc.IsActionsColumn && !tc.IsCheckListColumn)
                    {
                        var value = tc.Evaluate(model);
                        var member = HtmlHelpers.FindFirstPropetyInfoMember(tc.LambdaExpression);
                        try
                        {
                            if (Attribute.IsDefined(member, typeof(GeographicAttribute)))
                            {
                                if (string.IsNullOrWhiteSpace(value)) break;
                                var coord = value.Replace("POINT(", "").Replace(")", "").Split(' ');
                                point.Location = new GeoLocation(double.Parse(coord[1], CultureInfo.InvariantCulture), double.Parse(coord[0], CultureInfo.InvariantCulture));
                            }
                            else
                            {
                                if (value.Length > 0)
                                { 
                                    try
                                    {
                                        if (Convert.ToDecimal(value) > 0 || CheckIconFields(tc.ColumnField.Substring(tc.ColumnField.IndexOf(".") + 4).ToUpper(), iconFields).Length > 0)
                                           point.Columns.Add(new PointColumnInfo(tc.ColumnTitle, value, tc.ColumnField.Substring(tc.ColumnField.IndexOf(".") + 4)));
                                    }
                                    catch
                                    {
                                        point.Columns.Add(new PointColumnInfo(tc.ColumnTitle, value, tc.ColumnField.Substring(tc.ColumnField.IndexOf(".") + 4)));
                                    }
                                }
                            }
                        }
                        catch (ArgumentNullException)
                        {
                            point.Columns.Add(new PointColumnInfo(tc.ColumnTitle, value, tc.ColumnField.Substring(tc.ColumnField.IndexOf(".") + 4)));
                        }
                    }
                }

                if (point.Location != null)
                {
                    var routeData = new RouteValueDictionary(); routeData.Add("id", point.Key);
                    point.Actions = CreateActions(model, routeData, null);
                    points.Add(point);
                }
            }

            return points;
        }

        protected override string CreateActions(TModel model, RouteValueDictionary routeValueDictionary, ITableColumnInternal<TModel> tableColumn, bool cardActions = false)
        {
            int actionsNumber = 0;
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("style","margin-top: .6rem; margin-left: 3.5rem;");
            div.AddCssClass("b-btn-group i-input-group--right");

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

                div.InnerHtml += actionLink;
                div.InnerHtml += div.ToString();

                actionsNumber++;

            }

            if (actionsNumber > 0 && (Builder.HasViewAction() || Builder.HasEditAction() || Builder.HasDuplicateAction() || Builder.HasDeleteAction()))
            {
                TagBuilder divider = new TagBuilder("span");
                divider.AddCssClass("divider");
                div.InnerHtml += divider.ToString();
            }

            // If has FollowUp and has View Access
            if (Builder.HasViewAction())
            {

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
                actionLink.AddCssClass("btn b-icon b-icon--secondary i-input-group__button--secondary ");
                TagBuilder icon = new TagBuilder("i");
                icon.AddCssClass("glyphicons glyphicons-eye-open i-input-group__tag-icon i-input-group__button-icon");

                actionLink.InnerHtml = icon.ToString() + " " + actionLink.InnerHtml;

                if (this.Builder.HasOnlyOneAction())
                {
                    actionLink.AddCssClass("btn b-icon b-icon--secondary i-input-group__button--secondary " + this.buttonSize);
                    return actionLink.ToString();
                }

                div.InnerHtml += actionLink.ToString();

                actionsNumber++;
            }

            if (Builder.HasEditAction())
            {

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
                actionLink.AddCssClass("btn b-icon b-icon--secondary i-input-group__button--secondary ");
                TagBuilder icon = new TagBuilder("i");
                icon.AddCssClass("glyphicons glyphicons-pencil i-input-group__tag-icon i-input-group__button-icon");

                actionLink.InnerHtml = icon.ToString() + " " + actionLink.InnerHtml;

                if (this.Builder.HasOnlyOneAction())
                {
                    actionLink.AddCssClass("btn b-icon b-icon--secondary i-input-group__button--secondary " + this.buttonSize);
                    return actionLink.ToString();
                }


                div.InnerHtml += actionLink.ToString();

                actionsNumber++;
            }
            if (Builder.HasDuplicateAction())
            {

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
                actionLink.AddCssClass("btn b-icon b-icon--secondary i-input-group__button--secondary ");
                TagBuilder icon = new TagBuilder("i");
                icon.AddCssClass("glyphicons glyphicons-retweet i-input-group__tag-icon i-input-group__button-icon");

                actionLink.InnerHtml = icon.ToString() + " " + actionLink.InnerHtml;

                if (this.Builder.HasOnlyOneAction())
                {
                    actionLink.AddCssClass("btn b-icon b-icon--secondary i-input-group__button--secondary " + this.buttonSize);
                    return actionLink.ToString();
                }

                div.InnerHtml += actionLink.ToString();

                actionsNumber++;
            }
            if (Builder.HasDeleteAction())
            {
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
                actionLink.Attributes.Add("style", "padding: 0.26rem 0.25rem;");
                actionLink.AddCssClass("btn b-icon b-icon--secondary i-input-group__button--secondary ");
                TagBuilder icon = new TagBuilder("i");
                icon.AddCssClass("glyphicons glyphicons-delete i-input-group__tag-icon i-input-group__button-icon");


                actionLink.InnerHtml = icon.ToString() + " " + actionLink.InnerHtml;

                if (this.Builder.HasOnlyOneAction())
                {
                    actionLink.AddCssClass("btn b-icon b-icon--secondary i-input-group__button--secondary " + this.buttonSize);
                    actionLink.Attributes.Add("style", "padding: 0.26rem 0.25rem;");
                    return actionLink.ToString();
                }

                div.InnerHtml += actionLink.ToString();

                actionsNumber++;
            }

            if (actionsNumber > 0)
                return div.ToString();

            return "";
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
            tdBody.Attributes.Add("class", "leaflet-body");

            trBody.InnerHtml += tdBody;
            tBody.InnerHtml += trBody;

            return tBody;
        }

        protected override TagBuilder Footer()
        {
            TagBuilder actionsContainer = new TagBuilder("div");
            actionsContainer.AddCssClass("leaflet-footer");

            actionsContainer.InnerHtml += GenerateExtraFooterContent();

            return actionsContainer;
        }

        private string CheckIconFields(string colName, List<String> iconFields) 
        {
            foreach (string field in iconFields)
            {
                if (colName.Contains(field))
                    return field;
            }
            return "";
        }
    
    }

}
