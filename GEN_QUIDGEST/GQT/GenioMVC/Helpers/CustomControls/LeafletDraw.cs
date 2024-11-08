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
    public static class LeafletDrawHelper
    {
        public static LeafletDrawBuilder<TModel> LeafletDraw<TModel>(this HtmlHelper helper, bool edit, bool canPage = true, bool canSort = true, bool countRec = false) where TModel : class
        {
            var builder = new Table<TModel>(helper, TableType.SimpleTable, edit, canPage, canSort, countRec);
            return new LeafletDrawBuilder<TModel>(builder, false);
        }
    }

    /// <summary>
    /// Class used to interact with view (Table)
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class LeafletDrawBuilder<TModel> : Table.TableListBuilder<TModel> where TModel : class
    {
        // Empty class created in order to avoid a compilation error
        //Construction
        public LeafletDrawBuilder(Table.Builder.Table<TModel> builder, bool hasFilters)
            : base(builder, hasFilters)
        {
            var _builder = (builder as DbEdit<TModel>);
            if (_builder != null && _builder.Form != null)
                this.Builder.SetForm(_builder.Form.HelpForm, _builder.Form.OpenInPopup, _builder.Form.RepeatInsertion);
        }

        public MvcHtmlString ToLeafletDrawHtml()
        {
            //this.Builder.DoInternalActions();
            return new TableLeafletDrawRenderer<TModel>(this.Builder).ToLeafletDrawHtml();
        }
    }

    public class TableLeafletDrawRenderer<TModel> : DbEditRenderer<TModel> where TModel : class
    {
        public TableLeafletDrawRenderer(Table<TModel> builder)
            : base(builder) { }

        public MvcHtmlString ToLeafletDrawHtml()
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
            //==========================================================
            // https://cdnjs.com/libraries
            // https://www.cdnpkg.com/-/search?q=leaflet
            //==========================================================

            StringBuilder scriptBase = new StringBuilder();
            HttpContextBase context = this.Builder.HtmlHelper.ViewContext.HttpContext;

            //==========================================================================================================================
            // File library
            //==========================================================================================================================
            //// leaflet
            String leafletCss = UrlHelper.GenerateContentUrl("~/Content/stylesheets/leaflet/leaflet.css", context);
            //String leafletScript = UrlHelper.GenerateContentUrl("~/Scripts/leaflet/leaflet.js", context);
            //// geocoder
            //String geoCoderCss = UrlHelper.GenerateContentUrl("~/Content/stylesheets/leaflet/Control.Geocoder.css", context);
            //String geoCoderScript = UrlHelper.GenerateContentUrl("~/Scripts/leaflet/Control.Geocoder.js", context);
            //// full screen
            //String fullScreenCss = UrlHelper.GenerateContentUrl("~/Content/stylesheets/leaflet/Leaflet.fullscreen.css", context);
            //String fullScreenScript = UrlHelper.GenerateContentUrl("~/Scripts/leaflet/Leaflet.fullscreen.js", context);
            //// draw
            //String drawCss = UrlHelper.GenerateContentUrl("~/Content/stylesheets/leaflet/leaflet.draw.css", context);
            //String drawScript = UrlHelper.GenerateContentUrl("~/Scripts/leaflet/leaflet.draw.js", context);
            //==========================================================================================================================
            //==========================================================================================================================
            // CDN js library (https://cdnjs.com/libraries/)
            //==========================================================================================================================
            //// leaflet
            //String leafletCss = UrlHelper.GenerateContentUrl("https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.7.0/leaflet.css", context);
            String leafletScript = UrlHelper.GenerateContentUrl("https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.7.0/leaflet.js", context);
            // geocoder
            String geoCoderCss = UrlHelper.GenerateContentUrl("https://cdnjs.cloudflare.com/ajax/libs/perliedman-leaflet-control-geocoder/2.2.0/Control.Geocoder.min.css", context);
            String geoCoderScript = UrlHelper.GenerateContentUrl("https://cdnjs.cloudflare.com/ajax/libs/perliedman-leaflet-control-geocoder/2.2.0/Control.Geocoder.min.js", context);
            // full screen
            String fullScreenCss = UrlHelper.GenerateContentUrl("https://api.mapbox.com/mapbox.js/plugins/leaflet-fullscreen/v1.0.1/leaflet.fullscreen.css", context);
            String fullScreenScript = UrlHelper.GenerateContentUrl("https://api.mapbox.com/mapbox.js/plugins/leaflet-fullscreen/v1.0.1/Leaflet.fullscreen.min.js", context);
            // draw
            String drawCss = UrlHelper.GenerateContentUrl("https://cdnjs.cloudflare.com/ajax/libs/leaflet.draw/1.0.4/leaflet.draw.css", context);
            String drawScript = UrlHelper.GenerateContentUrl("https://cdnjs.cloudflare.com/ajax/libs/leaflet.draw/1.0.4/leaflet.draw.js", context);
            // ESRI
            String esriScript = UrlHelper.GenerateContentUrl("https://unpkg.com/esri-leaflet@3.0.1/dist/esri-leaflet.js", context);
            //OSM Buildings
            String osmBuildingCss = UrlHelper.GenerateContentUrl("https://cdn.osmbuildings.org/4.0.0/OSMBuildings.css", context);
            String osmBuildingScript = UrlHelper.GenerateContentUrl("https://cdn.osmbuildings.org/classic/0.2.2b/OSMBuildings-Leaflet.js", context);
            //==========================================================================================================================

            scriptBase.AppendLine(string.Format("<link href=\"{0}\" rel=\"stylesheet\"/>", leafletCss));
            scriptBase.AppendLine(string.Format("<link href=\"{0}\" rel=\"stylesheet\"/>", drawCss));
            scriptBase.AppendLine(string.Format("<link href=\"{0}\" rel=\"stylesheet\"/>", geoCoderCss));
            scriptBase.AppendLine(string.Format("<link href=\"{0}\" rel=\"stylesheet\"/>", fullScreenCss));
            scriptBase.AppendLine(string.Format("<link href=\"{0}\" rel=\"stylesheet\"/>", osmBuildingCss));

            scriptBase.AppendLine(string.Format("<script src=\"{0}\" type=\"text/javascript\"></script>", leafletScript));
            scriptBase.AppendLine(string.Format("<script src=\"{0}\" type=\"text/javascript\"></script>", drawScript));
            scriptBase.AppendLine(string.Format("<script src=\"{0}\" type=\"text/javascript\"></script>", geoCoderScript));
            scriptBase.AppendLine(string.Format("<script src=\"{0}\" type=\"text/javascript\"></script>", fullScreenScript));
            scriptBase.AppendLine(string.Format("<script src=\"{0}\" type=\"text/javascript\"></script>", osmBuildingScript));

            scriptBase.AppendLine(string.Format("<script src=\"{0}\" integrity=\"sha512-JmpptMCcCg+Rd6x0Dbg6w+mmyzs1M7chHCd9W8HPovnImG2nLAQWn3yltwxXRM7WjKKFFHOAKjjF2SC4CgiFBg==\" crossorigin = \"\"></script>", esriScript));

            var js = new StringBuilder();
            var shapes = GetLeafletDrawShapes();

            js.AppendLine(@"var grayscale = L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token=pk.eyJ1IjoibWFwYm94IiwiYSI6ImNpejY4NXVycTA2emYycXBndHRqcmZ3N3gifQ.rJcFIG214AriISLbB6B5aw',
                {
                    id: 'mapbox/light-v9',
                    tileSize: 512,
                    zoomOffset: -1,
                    attribution: 'Map data &copy; OpenStreetMap contributors, CC-BY-SA, Imagery © Mapbox',
                });"
            );

            js.AppendLine(@"var google = L.tileLayer('http://www.google.cn/maps/vt?lyrs=s@189&gl=cn&x={x}&y={y}&z={z}', 
                    {
                        attribution: 'Google'
                    }
                )"
            );

            js.AppendLine(@"var osm = L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png',
                    {
                        attribution: 'openstreetmap.org | Quidgest'
                    }
                );"
            );

            //js.AppendLine(@"var esri = L.tileLayer('http://server.arcgisonline.com/ArcGIS/rest/services/World_Imagery/MapServer/tile/{z}/{y}/{x}',
            //        {
            //            attribution: '&copy; Esri, i-cubed, USDA, USGS, AEX, GeoEye, Getmapping, Aerogrid, IGN, IGP, UPR-EGP, and the GIS User Community',
            //            maxZoom: 18
            //        }
            //    );"
            //);

            js.AppendLine("var map = new L.map('" + Builder.TableId + "', { center: new L.LatLng(38.736946, -9.142685), zoom: 13 });");
            js.AppendLine("var drawnItems = L.featureGroup().addTo(map);");

            //js.AppendLine("var esri_topo = L.esri.basemapLayer('Topographic').addTo(map);");
            js.AppendLine("var esri_street = L.esri.basemapLayer('Streets').addTo(map);");

            //js.AppendLine("var osmb = new OSMBuildings(map).load('https://{s}.data.osmbuildings.org/0.2/anonymous/tile/{z}/{x}/{y}.json');");

            js.AppendLine(@"L.control.layers(
                { 
                    //'Esri World Imagery': esri.addTo(map),
                    //'ESRI Topographic': esri_topo.addTo(map),
                    'OSM': osm.addTo(map), 
                    'Google': google.addTo(map), 
                    'Mapbox Grayscale': grayscale.addTo(map),
                    'ESRI Streets': esri_street.addTo(map)
                }, 
                //{ 'Drawlayer': drawnItems, 'OSM Buildings': osmb }, 
                { 'Drawlayer': drawnItems }, 
                { position: 'topright', collapsed: true }).addTo(map);"
            );

            js.AppendLine("L.Control.geocoder().addTo(map);");
            js.AppendLine("L.control.scale().addTo(map);");

            js.AppendLine(@"
                map.addControl(new L.Control.Fullscreen({
                    title: {
                        'false': 'View Fullscreen',
                        'true': 'Exit Fullscreen'
                    },
                    position: 'topright'
                }));"
            );

            js.AppendLine("var databaseFeatures = [");
            foreach (var shape in shapes)
            {
                js.AppendLine(@"
                    {
                        'type': 'Feature',
                        'properties': {'content': '" + shape.PopupContent + @"', 'newItem': false, 'changed': false},
                        'geometry':
                        {
                            'type': '" + shape.geometry.Type + @"',
                            'coordinates': " + shape.geometry.Coordinates + @"
                        }
                    },"
                );
            }
            js.AppendLine("];");

            // Create a GeoJson layer without adding it to the map
            js.AppendLine(@"L.geoJson(databaseFeatures, {
                    onEachFeature: onEachFeature
                });"
            );

            // Take advantage of the onEachFeature callback to initialize drawnItems
            js.AppendLine(@"function onEachFeature(feature, layer)
                {
                    var content = getPopupContent(layer);
                        if (content !== null) {
                            layer.bindPopup(content);
                        }
                    drawnItems.addLayer(layer);
                }"
            );

            js.AppendLine(@"
                var drawControl = new L.Control.Draw({
                    edit: {
                        featureGroup: drawnItems,
                        edit: {
                              selectedPathOptions: {
                                //dashArray: '5, 30',
                                //fill: true,
                                //fillColor: '#ff0000',
color: '#ff0000',
                                //fillOpacity: 0.5,
                                // Whether to user the existing layers color
                                maintainColor: false
                              }
                        }
                    },
                    draw: {
                        polygon: {
                            allowIntersection: false,
                            showArea: true
                        }
                    }
                });
                map.addControl(drawControl);"
            );

            js.AppendLine(@"
                // Truncate value based on number of decimals
                function _round(num, len) {
                    return Math.round(num*(Math.pow(10, len)))/(Math.pow(10, len));
                };
                // Helper method to format LatLng object (x.xxxxxx, y.yyyyyy)
                function strLatLng(latlng) {
                    return '('+_round(latlng.lat, 6)+', '+_round(latlng.lng, 6)+')';
                };"
            );

            js.AppendLine(@"function getPopupContent(layer) {

                var fixedContent = layer.feature.properties.content+'<br />';
                var itemStatus = layer.feature.properties.newItem+'<br />';
                var changed = layer.feature.properties.changed+'<br />';

                // Circle - lat/long, radius
                //============================
                if (layer instanceof L.Circle) {
                    var center = layer.getLatLng(),
                        radius = layer.getRadius();
                    return fixedContent + 'Center: '+strLatLng(center)+'<br />'
                          +'Radius: '+L.GeometryUtil.readableDistance(_round(radius, 2), true)+'<br />'
                          +'Perimeter: '+L.GeometryUtil.readableDistance(2*Math.PI*radius, true)+'<br />'
                          +'Area: '+L.GeometryUtil.readableArea(Math.PI*Math.pow(radius,2), true)+'<br />'
                          +'New: '+itemStatus
                          +'Changed: '+changed;

                // Marker - add lat/long
                //============================
                } else if (layer instanceof L.Marker || layer instanceof L.CircleMarker) {
                    return strLatLng(layer.getLatLng())+'<br />'
                            +'New: '+itemStatus
                            +'Changed: '+changed;

                // Rectangle/Polygon - area
                //============================
                } else if (layer instanceof L.Polygon) {
                    var latlngs = layer._defaultShape ? layer._defaultShape() : layer.getLatLngs(),
                        area = L.GeometryUtil.geodesicArea(latlngs);
                    return fixedContent +
                        'Area: '+L.GeometryUtil.readableArea(area, true)+'<br />'
                            +'New: '+itemStatus
                            +'Changed: '+changed;

                // Polyline - distance
                //============================
                } else if (layer instanceof L.Polyline) {
                    var latlngs = layer._defaultShape ? layer._defaultShape() : layer.getLatLngs(),
                        distance = 0;
                    if (latlngs.length < 2) {
                        return fixedContent + 'Distance: N/A';
                    } else {
                        for (var i = 0; i < latlngs.length-1; i++) {
                            distance += latlngs[i].distanceTo(latlngs[i+1]);
                        }
                        return fixedContent + 'Distance: '+L.GeometryUtil.readableDistance(distance, true)+'<br />'
                            +'New: '+itemStatus
                            +'Changed: '+changed;
                    }
                }
                return null;
            };");

            js.AppendLine(@"
                map.on(L.Draw.Event.CREATED, function(event) {
                    event.layer.options.color = '#00ee00';
                    var layer = event.layer,
                    feature = layer.feature = layer.feature || { }; // Intialize layer.feature
                    feature.type = feature.type || 'Feature'; // Intialize feature.type
                    var props = feature.properties = feature.properties || { }; // Intialize feature.properties
                    props.newItem = true;
                    props.changed = true;
                    var newContent = getPopupContent(layer);
                    if (newContent !== null) {
                        layer.bindPopup(newContent);
                    }
                    //var shape = layer.toGeoJSON();
                    //var shape_for_db = JSON.stringify(shape);
                    drawnItems.addLayer(layer);
                });"
            );

            js.AppendLine(@"
                map.on(L.Draw.Event.EDITED, function(event) {
                        var layers = event.layers,
                            content = null;
                        layers.eachLayer(function(layer) {
                                setShapeChanged(layer);
                                //layer.feature.properties.changed = true;
                                //layer.options.color = '#f00';
                                content = getPopupContent(layer);
                                if (content !== null) {
                                    layer.setPopupContent(content);
                                    //var shape = layer.toGeoJSON();
                                    //var shape_for_db = JSON.stringify(shape);
console.log(layer);
console.log(layers);
                                }
                            }
                        );
                    }
                );"
            );

            js.AppendLine(@"function setShapeChanged(layer)
                {
                    layer.feature.properties.changed = true;
                    layer.options.color = '#ff0000';
                }"
            );

            js.AppendLine(@"$('#" + Builder.TableId + @"').closest(" + "'[elem-identifier=\"AccordionGroup\"]'" + @").on('shown.bs.collapse', function(e) {
                map.invalidateSize();
            });");

            string mainScript = @"
                <div id='" + Builder.TableId + @"'></div>
			    <script>
                    " + js.ToString() + @"
               </script>";

            scriptBase.Append(mainScript);

            return new MvcHtmlString(scriptBase.ToString());
        }

        private class Shape
        {
            public Shape(string type, string coordinates)
            {
                Type = type;
                Coordinates = coordinates;
            }

            //public override string ToString()
            //{
            //    return "'type': 'Feature', { 'geometry' : { 'type': '" + Type + "', 'coordinates' :" + Coordinates + "}}";
            //}

            public string Type { get; set; }
            public string Coordinates { get; set; }
        }

        private class ShapeColumnInfo
        {
            public ShapeColumnInfo(string title, string value, string name)
            {
                Title = title;
                Value = value;
                Name = name;
            }

            public string Title { get; set; }
            public string Value { get; set; }
            public string Name { get; set; }
        }

        private class LeafletShapeInfo
        {
            public LeafletShapeInfo()
            {

                Columns = new List<ShapeColumnInfo>();
                geometry = new Shape(null, null);
            }

            public Shape geometry { get; set; }
            public string Key { get; set; }
            public List<ShapeColumnInfo> Columns { get; set; }
            public string Actions { get; set; }
            public string PopupContent { get; set; }
        }

        private List<LeafletShapeInfo> GetLeafletDrawShapes()
        {
            var leafletShapes = new List<LeafletShapeInfo>();

            foreach (TModel model in Builder.Data)
            {

                var leafletShape = new LeafletShapeInfo();
                leafletShape.Key = Builder.TableKey.Evaluate(model);

                var popupContent = new StringBuilder();
                popupContent.Append("<table class=\"table\"><tbody class=\"table_body\">");
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

                                leafletShape.geometry.Type = value.Substring(0, value.IndexOf("(")).Trim();
                                string coordinates = value.Substring(leafletShape.geometry.Type.Length, value.Length - leafletShape.geometry.Type.Length).Replace("(", "[[").Replace(")", "]]").Trim();
                                coordinates = coordinates.Replace(", ", "],[");
                                coordinates = coordinates.Replace(" ", ",");

                                switch (leafletShape.geometry.Type.ToUpper())
                                {
                                    case "LINESTRING":
                                        leafletShape.geometry.Type = "LineString";
                                        break;
                                    case "POLYGON":
                                        leafletShape.geometry.Type = "Polygon";
                                        coordinates = coordinates.Replace("[[[[", "[[[").Replace("]]]]", "]]]");
                                        break;
                                    default:
                                        break;
                                }
                                leafletShape.geometry.Coordinates = coordinates;

                            }
                            else
                            {
                                if (value.Length > 0)
                                {
                                    popupContent.AppendFormat("<tr><td><strong>{0}</strong></td><td>{1}</td></tr>", tc.ColumnTitle, value);
                                }
                            }
                        }
                        catch (ArgumentNullException)
                        {
                            leafletShape.Columns.Add(new ShapeColumnInfo(tc.ColumnTitle, value, tc.ColumnField.Substring(tc.ColumnField.IndexOf(".") + 4)));
                        }
                    }
                }
                popupContent.AppendFormat("</tbody></table><div class=\"leaflet-popup-actions\">{0}</div>", leafletShape.Actions);
                leafletShape.PopupContent = popupContent.ToString();

                if (leafletShape.geometry.Type != null)
                {
                    var routeData = new RouteValueDictionary(); routeData.Add("id", leafletShape.Key);
                    leafletShape.Actions = CreateActions(model, routeData, null);
                    leafletShapes.Add(leafletShape);
                }
            }

            return leafletShapes;
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
    }

}