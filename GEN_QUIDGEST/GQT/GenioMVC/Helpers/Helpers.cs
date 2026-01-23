using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq.Expressions;
using System.Web.Routing;
using System.Collections;
using System.Text;
using System.Collections.Specialized;
using System.Reflection;
using System.Globalization;
using GenioMVC.Models.Navigation;
using CSGenio.framework;
using CSGenio.business;
using System.IO;
using GenioMVC.ViewModels;

namespace GenioMVC.Helpers
{
    public static class HtmlHelpers
    {
		#region DepedantBoxFor

	    public static MvcHtmlString DependantBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            var propertyName = metadata.PropertyName;
            if (propertyName == null)
                propertyName = ExpressionHelper.GetExpressionText(expression);

            RouteValueDictionary htmlAttr = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            string value = metadata.Model != null ? metadata.Model.ToString() : null;

            if (!String.IsNullOrEmpty(value) && metadata.AdditionalValues.ContainsKey("DataArray"))
            {
                if ((metadata.AdditionalValues["DataArray"] as Dictionary<string, string>).ContainsKey(value))
                    value = (metadata.AdditionalValues["DataArray"] as Dictionary<string, string>)[value];
                else if (!(metadata.AdditionalValues["DataArray"] as Dictionary<string, string>).ContainsValue(value))
                    value = null;
            }

            return htmlHelper.TextBox(propertyName, value, htmlAttr);
        }

		#endregion

		#region Format by field type

		public static string FormatArray<TModel, TValue>(Expression<Func<TModel, TValue>> expression, TModel model)
        {
            var member = FindFirstPropetyInfoMember(expression.Body);

            bool hasArrayAttribute = member == null ? false : Attribute.IsDefined(member, typeof(DataArray));

            object value = expression.Compile().Invoke(model);

            if (hasArrayAttribute && value != null && !String.IsNullOrEmpty(value.ToString()))
            {
                DataArray attr = (DataArray)Attribute.GetCustomAttribute(member, typeof(DataArray));
                return attr.GetDictionary()[value as string];
            }

            return value?.ToString() ?? string.Empty;
        }

        private static string FormatArray<TModel, TValue>(Expression<Func<TModel, TValue>> expression, ModelMetadata modelMetadata)
        {
            var propertyName = modelMetadata.PropertyName;
            if (propertyName == null)
                propertyName = ExpressionHelper.GetExpressionText(expression);

            if (modelMetadata.AdditionalValues.ContainsKey("DataArray"))
            {
                Dictionary<string, string> addit = modelMetadata.AdditionalValues["DataArray"] as Dictionary<string, string>;
                if (addit.ContainsKey(modelMetadata.Model.ToString()))
                    return addit[modelMetadata.Model.ToString()];
            }

            return String.Empty;
        }

		public static string FormatDate<TModel, TValue>(Expression<Func<TModel, TValue>> expression, TModel model) {
            var member = FindFirstPropetyInfoMember(expression.Body);

            bool hasDateAttribute = member == null ? false : Attribute.IsDefined(member, typeof(DateAttribute));

            DateAttribute.DateEnum ftype = DateAttribute.DateEnum.Undefined;

            if (hasDateAttribute)
            {
                var attr = Attribute.GetCustomAttribute(member, typeof(DateAttribute));
                ftype = DateAttribute.ConvertToDateAttribute(attr);
            }

            object value = expression.Compile().Invoke(model);

			if ((value as DateTime?) == null || (value as DateTime?) == DateTime.MinValue)
                return "";

            return FormatDateValue(ftype, value);
        }

        private static string FormatDate<TModel, TValue>(Expression<Func<TModel, TValue>> expression, ModelMetadata modelMetadata)
        {
            var propertyName = modelMetadata.PropertyName;
            if (propertyName == null)
                propertyName = ExpressionHelper.GetExpressionText(expression);

            DateAttribute.DateEnum ftype = DateAttribute.DateEnum.Undefined;

            if (modelMetadata.AdditionalValues.ContainsKey("DateAttribute"))
            {
                ftype = (DateAttribute.DateEnum)modelMetadata.AdditionalValues["DateAttribute"];
            }

            return FormatDateValue(ftype, modelMetadata.Model);
        }

        /*
		public static string FormatCurrency<TModel, TValue>(Expression<Func<TModel, TValue>> exp, TModel model)
        {
            CultureInfo ci = GetCurrencyCulture<TModel, TValue>(exp);

            object value = exp.Compile().Invoke(model);

            value = Decimal.Parse(value.ToString()).ToString("C", ci);

            return value.ToString();
        }*/

        public struct UINumberFormat
        {
            public string NumberDecimalSeparator { get; set; }
            public string NumberGroupSeparator { get; set; }
            public string CurrencyDecimalSeparator { get; set; }
            public string CurrencyGroupSeparator { get; set; }
        }
        public static UINumberFormat GetUINumberFormat()
        {
            var numberFormat = Configuration.NumberFormat;
            if (numberFormat == null)
                numberFormat = new CSGenio.NumberFormatXml();

            return new UINumberFormat
            {
                NumberDecimalSeparator = numberFormat.DecimalSeparator ?? CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator,
                NumberGroupSeparator = numberFormat.GroupSeparator ?? CultureInfo.CurrentUICulture.NumberFormat.NumberGroupSeparator,
                CurrencyDecimalSeparator = numberFormat.DecimalSeparator ?? CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator,
                CurrencyGroupSeparator = numberFormat.GroupSeparator ?? CultureInfo.CurrentUICulture.NumberFormat.NumberGroupSeparator
            };
        }

        private static string FormatCurrency<TModel, TValue>(Expression<Func<TModel, TValue>> expression, ModelMetadata modelMetadata)
        {
            var propertyName = modelMetadata.PropertyName;
            if (propertyName == null)
                propertyName = ExpressionHelper.GetExpressionText(expression);

            Decimal value = Decimal.Parse(modelMetadata.Model.ToString());

            if (modelMetadata.AdditionalValues.ContainsKey("CurrencyAttribute"))
            {
                CultureInfo ci = GetCurrencyCulture<TModel, TValue>(expression);
                return value.ToString("C", ci);
            }

            return value.ToString();
        }

        private static CultureInfo GetCurrencyCulture<TModel, TValue>(Expression<Func<TModel, TValue>> exp)
        {
            var member = FindFirstPropetyInfoMember(exp.Body);

            bool hasCurrencyAttribute = member == null ? false : Attribute.IsDefined(member, typeof(CurrencyAttribute));

            CultureInfo ci = GetNumericCulture();

            if (hasCurrencyAttribute)
            {
                var attr = Attribute.GetCustomAttribute(member, typeof(CurrencyAttribute));
                ci = (attr as CurrencyAttribute).GetCurrencyWithCurrentCulture(ci);
            }
            return ci;
        }

        /*
        public static string FormatNumeric<TModel, TValue>(Expression<Func<TModel, TValue>> exp, TModel model)
        {
            var member = FindFirstPropetyInfoMember(exp.Body);
            bool hasNumericAttribute = member == null ? false : Attribute.IsDefined(member, typeof(NumericAttribute));

			CultureInfo ci = GetNumericCulture();

            object value = exp.Compile().Invoke(model);
            if (hasNumericAttribute)
            {
                NumericAttribute numeric = (NumericAttribute)Attribute.GetCustomAttribute(member, typeof(NumericAttribute));
                return Decimal.Parse(value.ToString()).ToString("N" + numeric.Decimals,ci);
            }
            return Decimal.Parse(value.ToString()).ToString(ci);
        }
        */

        public static string FormatCurrency(decimal value, CultureInfo ci)
        {
            return value.ToString("C", ci);
        }


        public static string FormatNumeric(decimal value, int decimals, CultureInfo ci)
        {
            return value.ToString("N" + decimals, ci);
        }

        public static string FormatNumeric(object value, int decimals, CultureInfo ci)
        {
            if(value.GetType() == typeof(decimal))
            {
                return ((decimal)value).ToString("N" + decimals, ci);
            }
            else
            {
                return Decimal.Parse(value.ToString()).ToString(ci);
            }
        }


        private static string FormatNumeric<TModel, TValue>(Expression<Func<TModel, TValue>> expression, ModelMetadata modelMetadata)
        {
            var propertyName = modelMetadata.PropertyName;
            if (propertyName == null)
                propertyName = ExpressionHelper.GetExpressionText(expression);

			CultureInfo ci = GetNumericCulture();

            Decimal value = Decimal.Parse(modelMetadata.Model.ToString());

            if (modelMetadata.AdditionalValues.ContainsKey("Decimals"))
            {
                int Decimals = (int)modelMetadata.AdditionalValues["Decimals"];
                return value.ToString("N" + Decimals,ci);
            }

            return value.ToString(ci);
        }

        public static CultureInfo GetNumericCulture()
        {
            CultureInfo ci = System.Globalization.CultureInfo.CurrentUICulture;

            if (Configuration.NumberFormat != null) {
                //commented line for now as only these options are needed, the rest can come from the CurrentUICulture. EX: the € symboml placement
                //ci = new CultureInfo("id-ID");

                ci.NumberFormat.NumberDecimalSeparator = Configuration.NumberFormat.DecimalSeparator ?? CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;
                ci.NumberFormat.NumberGroupSeparator = Configuration.NumberFormat.GroupSeparator ?? CultureInfo.CurrentUICulture.NumberFormat.NumberGroupSeparator;
                ci.NumberFormat.CurrencyDecimalSeparator = Configuration.NumberFormat.DecimalSeparator ?? CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;
                ci.NumberFormat.CurrencyGroupSeparator = Configuration.NumberFormat.GroupSeparator ?? CultureInfo.CurrentUICulture.NumberFormat.NumberGroupSeparator;
            }

            return ci;
        }

		#endregion

	    #region StaticText

        public static MvcHtmlString StaticText<TModel>(this HtmlHelper<TModel> html, string text, string id, object htmlProperties = null)
        {
            TagBuilder div = new TagBuilder("div");
            IDictionary<string, object> htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlProperties);
            var htmlAttr = flattenHtmlProps(htmlAttributes);
            div.MergeAttributes(htmlAttributes);

            TagBuilder label = new TagBuilder("label");
            label.AddCssClass("flow-label hidden-label");
            label.SetInnerText(Resources.Resources.VAZIO58398);

            TagBuilder innerDiv = new TagBuilder("div");
            innerDiv.Attributes.Add("id", id);
            innerDiv.SetInnerText(text);
            div.InnerHtml += innerDiv;

            return MvcHtmlString.Create(label.ToString() + div.ToString());
        }

		#endregion

        #region EditImage

		public static string IsImageEmpty<TModel>(this HtmlHelper<TModel> html, byte[] byteArray)
        {
            return !(byteArray != null && byteArray.Length > 0) ? "true" : "false";
        }

        public static MvcHtmlString EditImage<TModel>(this HtmlHelper<TModel> html, byte[] byteArray, string guid, string model, string field, string formIdentifier, object htmlProperties = null)
        {
            var img = ShowImage(html, byteArray, guid, model, field, formIdentifier, htmlProperties);

            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("id", "file-uploader_" + field);

            TagBuilder noscript = new TagBuilder("noscript");
            TagBuilder p = new TagBuilder("p");
            p.SetInnerText(Resources.Resources.ATIVE_O_JAVASCRIPT_P25514);
            noscript.InnerHtml = p.ToString();
            div.InnerHtml = noscript.ToString();

            string control = div.ToString(TagRenderMode.Normal);
            control = img.ToHtmlString() + control;

            return MvcHtmlString.Create(control);
        }

        #endregion

        #region ShowImage

        public static MvcHtmlString ShowImage<TModel>(this HtmlHelper<TModel> html, byte[] byteArray, string guid, string model, string field, string formIdentifier, object htmlProperties = null)
        {
            RouteValueDictionary htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlProperties);
            if ((byteArray != null && byteArray.Length > 0) || (object.Equals(html.ViewBag.formmode, "new") || object.Equals(html.ViewBag.formmode, "edit")))
            {
                var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
                var ticket = Helpers.GetFileTicket(UserContext.Current.User, model, field, "", guid);
                string absUrl = urlHelper.Action("ImageHandlerGet", model, new { ticket, formIdentifier });

                var imgCtrl = new TagBuilder("div");
                imgCtrl.Attributes.Add("elem-identifier", "image-control");

                //MergeAttributes has to be done before AddCssClass otherwise they will be replaced
                imgCtrl.MergeAttributes(htmlAttributes);
                imgCtrl.AddCssClass("i-image__field");

                TagBuilder img = new TagBuilder("img");
                img.Attributes.Add("elem-identifier", "image-control-img");
                img.AddCssClass("img-thumbnail i-image");
                img.Attributes.Add("src", absUrl);
                img.Attributes.Add("id", "thumbnail_" + field);
                img.Attributes.Add("alt", field.StartsWith("Val") ? field.Substring(3) : field); // adds the field name as alt attribute (without 'Val') for better accessibility
                img.Attributes.Add("img-ticket", ticket);

                TagBuilder a = new TagBuilder("a");
                a.Attributes.Add("elem-identifier", "image-control-magnify");
                a.AddCssClass("thumbnail");
                a.Attributes.Add("href", absUrl);

                a.InnerHtml += img;
                imgCtrl.InnerHtml += a;

                return MvcHtmlString.Create(imgCtrl.ToString(TagRenderMode.Normal));
            }
            else
            {
                htmlAttributes.Add("color", "whiteSmoke");
                htmlAttributes.Add("font-style", "italic");
                htmlAttributes.Add("data-empty", "&lt;" + Resources.Resources.VAZIO58398 + "&gt;");

                var htmlAttr = flattenHtmlProps(htmlAttributes);

                return MvcHtmlString.Create("<text class='empty-value' " + htmlAttr + "></text>");
            }
        }

        public static IHtmlString Image(this HtmlHelper helper, byte[] image)
        {
            return Image(helper, image, null);
        }

        public static IHtmlString Image(this HtmlHelper helper, byte[] image, object htmlAttributes)
        {
            string extension = "image/jpg";
            var builder = new TagBuilder("img");
            builder.MergeAttribute("class", "dbeditimage");
            builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), true);

			if (image == null || image.Length == 0)
				image = File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Content/img/no_img.png"));

            // Resize image
            if (image != null && image.Length > 0)
            {
                //in the case of the image being a svg or gif, doesn´t not resize it otherwise the svg will not work and the gif will be a static image
                //we should think on replace the below "else" by a thumbnail on the database
                byte[] pngSig = { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
                byte[] jpgSig = { 0xFF, 0xD8 };
                byte[] gifSig = { 0x47, 0x49, 0x46 };
                var text = Encoding.UTF8.GetString(image);
                if (text.StartsWith("<?xml ") || text.StartsWith("<svg "))
                    extension = "image/svg+xml";
                else
                {
                    try
                    {
                        using (var ms = new System.IO.MemoryStream(image))
                        {
                            using (System.Drawing.Image _Image = System.Drawing.Image.FromStream(ms))
                            {
                                using (System.Drawing.Image _ResizedImage = new System.Drawing.Bitmap(_Image, new System.Drawing.Size(75, 75)))
                                {
                                    image = (byte[])new System.Drawing.ImageConverter().ConvertTo(_ResizedImage, typeof(byte[]));
                                }
                            }
                        }
                    }
                    /*
                        If the content is invalid, executing this code causes a error 500. 
                        This can happen in cases where the image file upload did not validate either the MIME type or the content.
                    */
                    catch(Exception ex)
                    {
                        Log.Error($"Helpers - Error creating image tag. Error message: {ex.Message}");
                        image = null;
                    }
                }
            }

            if (image != null && image.Length > 0)
            {
                var imageString = Convert.ToBase64String(image);
                var img = string.Format("data:{0};base64,{1}", extension, imageString);
                builder.MergeAttribute("src", img, true);
            }

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        /// <summary>
        /// Convert byte array to string Base64 image
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="image">image byte array</param>
        /// <returns>Base64 image</returns>
        public static string ImageBase64(this HtmlHelper helper, byte[] image)
        {
            string extension = "image/jpg";

            if (image == null || image.Length == 0)
                return null;

            // Resize image
            if (image != null && image.Length > 0)
            {
                //in the case of the image being a svg or gif, doesn´t not resize it otherwise the svg will not work and the gif will be a static image
                //we should think on replace the below "else" by a thumbnail on the database
                byte[] pngSig = { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
                byte[] jpgSig = { 0xFF, 0xD8 };
                byte[] gifSig = { 0x47, 0x49, 0x46 };
                var text = Encoding.UTF8.GetString(image);
                if (text.StartsWith("<?xml ") || text.StartsWith("<svg "))
                    extension = "image/svg+xml";
                else
                {
                    using (var ms = new System.IO.MemoryStream(image))
                    {
                        using (System.Drawing.Image _Image = System.Drawing.Image.FromStream(ms))
                        {
                            using (System.Drawing.Image _ResizedImage = new System.Drawing.Bitmap(_Image, new System.Drawing.Size(75, 75)))
                            {
                                image = (byte[])new System.Drawing.ImageConverter().ConvertTo(_ResizedImage, typeof(byte[]));
                            }
                        }
                    }
                }
                var imageString = Convert.ToBase64String(image);
                var img = string.Format("data:{0};base64,{1}", extension, imageString);
                return img;
            }

            return null;
        }


        public static IHtmlString ImageMagnifierZoom(this HtmlHelper helper, byte[] image, object htmlAttributes, string Url)
        {
            IHtmlString img = Image(helper, image, htmlAttributes);

            var builder = new TagBuilder("a");
            builder.Attributes.Add("elem-identifier", "image-control-magnify");
            builder.MergeAttribute("href", Url);
            builder.InnerHtml = img.ToHtmlString();
			builder.AddCssClass("column-data-link");/*FIX FOR TABBING*/
            return MvcHtmlString.Create(builder.ToString());
        }

        private static bool CheckMagicSig(byte[] file, byte[] sig)
        {
            for (int bix = 0; bix < sig.Length; bix++)
            {
                if (bix >= file.Length) return false;
                if (file[bix] != sig[bix]) return false;
            }
            return true;
        }

		public static IHtmlString ImageSlideGrid(byte[] image)
        {
            return ImageSlideGrid(image, null);
        }

        public static IHtmlString ImageSlideGrid(byte[] image, object htmlAttributes)//mara alterado
        {
             var divImg = new TagBuilder("div");
            divImg.AddCssClass("divGrid");

            var legendaImg = new TagBuilder("div");
            legendaImg.AddCssClass("legendGrid");
            legendaImg.InnerHtml += "Titulo desta imagem";

            var a = new TagBuilder("a");
            var builder = new TagBuilder("img");
            builder.MergeAttribute("class", "imgGrid");
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);

            if (image != null && image.Length > 0)
            {
                var imageString = Convert.ToBase64String(image);
                var img = string.Format("data:image/jpg;base64,{0}", imageString);
                builder.MergeAttribute("src", img, true);
            }
            else
            {
                builder.MergeAttribute("alt", "");
                //builder.AddCssClass("noImageMosaic");
            }
            // builder.InnerHtml += legendaImg;
            divImg.InnerHtml += builder.ToString();
            builder = divImg;


            return MvcHtmlString.Create(builder.ToString());
        }

        #endregion

		#region ShowStaticImage

        public static MvcHtmlString ShowImageStatic<TModel>(this HtmlHelper<TModel> html, string path, object htmlAttributes = null)
        {
            TagBuilder img = new TagBuilder("img");

            if (htmlAttributes != null)
                img.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            if (!string.IsNullOrEmpty(path)) {

                var fileName = System.IO.Path.GetFileName(path);
                Resource imageResource = new ResourceFile(fileName, path);
                string ticket = QResources.CreateTicketEncryptedBase64(UserContext.Current.User.Name, UserContext.Current.User.Location, imageResource);

                img.Attributes.Add("src", urlHelper.Action("GetStaticImage", new { ticket }));
                return MvcHtmlString.Create(img.ToString());
            }

            return MvcHtmlString.Empty;
        }

        public static MvcHtmlString StaticImage<TModel>(this HtmlHelper<TModel> html, string file, object htmlAttributes)
        {
            TagBuilder img = new TagBuilder("img");
            img.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            img.Attributes.Add("src", urlHelper.Content("~/Content/img/" + file));
            return MvcHtmlString.Create(img.ToString());
        }
        #endregion

        #region ActionLinkWithQueryString

        public static MvcHtmlString ActionLinkWithQueryString<TModel>(this HtmlHelper<TModel> html, string text, string action, string controller, object routeValues, IDictionary<string, object> htmlProperties)
        {
            NameValueCollection qs = html.ViewContext.RequestContext.HttpContext.Request.QueryString;
            RouteValueDictionary routeValueDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(routeValues);
            foreach (string key in qs.Keys)
            {
                if (!routeValueDictionary.ContainsKey(key))
                    routeValueDictionary[key] = qs[key];
            }
            return html.ActionLink(text, action, controller, routeValueDictionary, htmlProperties);
        }

        #endregion

        #region ActionLinkWithIcon

		// Last updated by [HTA] at [2019.10.01]
        public static MvcHtmlString ActionLinkWithIcon(this HtmlHelper html, string text, string action, string controller, string iconClass, object routeValues, object htmlProperties, string extraAction = "", string extraController = "", string baseArea = "", string baseAreaKey = "")
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            var _routeValues = routeValues is RouteValueDictionary ? (RouteValueDictionary)routeValues : HtmlHelper.AnonymousObjectToHtmlAttributes(routeValues);
            var url = action == "" ? "#" : html.Raw(urlHelper.Action(action, controller, _routeValues)).ToHtmlString();
            // html.ViewData["basearea"] e html.ViewData["baseareakey"] estão a null depois de atualizar apenas o controlo e não a página por completo
            var extraUrl = extraAction == "" ? "#" : html.Raw(urlHelper.Action(extraAction, extraController)).ToHtmlString() + "?area=" + baseArea + "&areakey=" + baseAreaKey + "&openPane=false";
            var htmlAttributes = htmlProperties is IDictionary<string, object> ? (IDictionary<string, object>)htmlProperties : HtmlHelper.AnonymousObjectToHtmlAttributes(htmlProperties);

            TagBuilder aBuilder = new TagBuilder("a");

            if (extraUrl != "" && extraUrl != "#")
            {
                aBuilder.Attributes.Add("data-url", url);
                aBuilder.Attributes.Add("data-extra", extraUrl);
                aBuilder.MergeAttributes(htmlAttributes, true);
                aBuilder.MergeAttribute("onclick", "DownloadConsoleFile(this)");
                aBuilder.MergeAttribute("style", "cursor:pointer;");
            }
            else
            {
                aBuilder.Attributes.Add("href", url);
                aBuilder.MergeAttributes(htmlAttributes, true);
            }

            if (!String.IsNullOrEmpty(iconClass))
            {
                TagBuilder iBuilder = new TagBuilder("i");
                iBuilder.AddCssClass(iconClass);
                aBuilder.InnerHtml = iBuilder.ToString() + text;
            }
            else
                aBuilder.InnerHtml = text;

            return new MvcHtmlString(aBuilder.ToString(TagRenderMode.Normal));
        }


        #endregion

        #region Document for type IB or ID

        public static MvcHtmlString DocumentFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string documentFk, GenioMVC.ViewModels.DocumsProperties_ViewModel docProps, string baseArea, string baseAreaKey,  object htmlAttributes, bool onlyShow = false, string identifier = null, string fieldSize = "", bool isRequired = false)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string modelValue = "";  //Server problem, it is not possible to insert null for type field PATH
            if (docProps != null)
            {
                modelValue = docProps.Name;
            } else if (documentFk != "") //For duplicate cases
            {
                modelValue = html.ViewData.Model.ToString();
            }

            string propertyName = metadata.PropertyName;
            if (metadata.AdditionalValues.ContainsKey("DocumentAttribute"))
            {
                propertyName = (string)metadata.AdditionalValues["DocumentAttribute"];
            }

            bool versioning = true;
            if (metadata.AdditionalValues.ContainsKey("VersionedlDocAttribute"))
            {
                versioning = (bool)metadata.AdditionalValues["VersionedlDocAttribute"];
            }

            bool externalDoc = false;
            if (metadata.AdditionalValues.ContainsKey("ExternalDocAttribute"))
            {
                externalDoc = (bool)metadata.AdditionalValues["ExternalDocAttribute"];
            }

            bool useTemplates = false;
            if (metadata.AdditionalValues.ContainsKey("UsesTemplatesAttribute"))
            {
                useTemplates = (bool)metadata.AdditionalValues["UsesTemplatesAttribute"];
            }
			
            DocumentViewTypeMode ViewType = DocumentViewTypeMode.Print;
            if (metadata.AdditionalValues.ContainsKey("ViewType"))
            {
                ViewType = (DocumentViewTypeMode)metadata.AdditionalValues["ViewType"];
            }

            return Document<TModel>(
                html: html,
                fieldName: propertyName,
                value: modelValue,
                documentFk: documentFk,
                docProps: docProps,
                baseArea: baseArea,
                baseAreaKey: baseAreaKey,
                htmlAttributes: htmlAttributes,
                onlyShow: onlyShow,
                versioning: versioning,
                externalDoc: externalDoc,
                useTemplates: useTemplates,
                identifier: identifier,
                fieldSize: fieldSize,
                isRequired: isRequired,
                ViewType: ViewType);
        }

        public static MvcHtmlString Document<TModel>(this HtmlHelper<TModel> html, GenioMVC.ViewModels.DocumsControl_ViewModel docProps, object htmlAttributes = null, string identifier = null, string fieldSize = "", bool isRequired = false, DocumentViewTypeMode ViewType = DocumentViewTypeMode.Print)
        {
            Type type = Type.GetType("GenioMVC.Models." + StringUtils.CapFirst(docProps.Model));
            bool external = false;
            bool versioning = false;
            bool useTemplates = docProps.UsesTemplates;

            object[] customAttrs = type.GetProperty(docProps.FieldName).GetCustomAttributes(typeof(DocumentAttribute), false);
            if (customAttrs.FirstOrDefault() != null)
            {
                external = ((DocumentAttribute)customAttrs.FirstOrDefault()).IsExternal();
                versioning = ((DocumentAttribute)customAttrs.FirstOrDefault()).UsesVersioning();
            }

            return Document<TModel>(html, docProps.FieldName, docProps.Name, docProps.DocumId, docProps, docProps.Model, docProps.ModelKey, htmlAttributes, false, versioning, external, useTemplates, identifier, fieldSize, isRequired, ViewType);
        }

        private static MvcHtmlString Document<TModel>(this HtmlHelper<TModel> html,
            string fieldName,
            string value,
            string documentFk,
            GenioMVC.ViewModels.DocumsProperties_ViewModel docProps,
            string baseArea,
            string baseAreaKey,
            object htmlAttributes,
            bool onlyShow,
            bool versioning,
            bool externalDoc,
            bool useTemplates,
            string identifier = null,
            string fieldSize = "",
            bool isRequired = false,
            DocumentViewTypeMode ViewType = DocumentViewTypeMode.Print)
        {
            if (docProps == null)
                docProps = GenioMVC.ViewModels.DocumsProperties_ViewModel.EmptyDocum();

            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);

            IDictionary<string, object> htmlProperties = new Dictionary<string, object>();
            RouteValueDictionary routeValues = new RouteValueDictionary();

            // area primary key field not needed - authorization ticket
            ResourceQuery resource = new ResourceQuery(value, baseArea.ToLower(), fieldName.Substring(fieldName.IndexOf("Val")), "", baseAreaKey);
            string ticket = QResources.CreateTicketEncryptedBase64(UserContext.Current.User.Name, UserContext.Current.User.Location, resource);

            routeValues.Add("ticket", ticket);
			routeValues.Add("identifier", identifier);
			routeValues.Add("ViewType", (int)ViewType);

            if (onlyShow)
            {
                if ((!externalDoc && GenFunctions.emptyG(documentFk) == 1) || (externalDoc && String.IsNullOrEmpty(value)))
                {
                    htmlProperties.Add("class", "btn disabled");
                    htmlProperties.Add("href", "#");
                }
            }

            htmlProperties.Add("data-action", "download");
            htmlProperties.Add("title", Resources.Resources.DESCARREGAR58418);
			
            //[TMV] (2023.09.14) - here the behavior needs to be download because of file versioning and the option specifies the action that the user will do "Download"
            RouteValueDictionary routeValuesDropdwon = new RouteValueDictionary()
            {
                { "ticket", ticket },
                {"identifier", identifier},
                { "viewType",(int)DocumentViewTypeMode.Print }
            };

            //Download link
			// Last updated by [HTA] at [2019.10.01]
            // remove action to open documents in addin
			HtmlString showLink = html.ActionLinkWithIcon(Resources.Resources.DESCARREGAR58418, "GetFile", baseArea, "icon-download-alt", routeValuesDropdwon, htmlProperties, ""/*"PrepareFileLink"*/, ""/*"Home"*/, baseArea, baseAreaKey);

            TagBuilder firstDiv = new TagBuilder("div");
            firstDiv.AddCssClass("i-input-group " + fieldSize);
            TagBuilder label = new TagBuilder("label");
            label.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            label.SetInnerText("fieldName.Substring(3)");

            label.AddCssClass("i-checkbox i-checkbox__label");
            //file name
            TagBuilder displayName = new TagBuilder("input");
            displayName.Attributes.Add("id", fieldName);
            displayName.Attributes.Add("data-key", baseAreaKey);
            displayName.Attributes.Add("type", "text");
            displayName.Attributes.Add("name", fieldName);
            displayName.Attributes.Add("readonly", "readonly");
            displayName.Attributes.Add("placeholder", Resources.Resources.ANEXAR_DOCUMENTO00337);
            displayName.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            displayName.Attributes.Add("value", value);
            displayName.Attributes.Add("elem-identifier", "FileInputBox");
            displayName.AddCssClass("i-input-group__field");

            if (docProps.IsCheckout)
                if (docProps.IsCurrentUserEditing())
                    displayName.AddCssClass("file-checkout");
                else
                    displayName.AddCssClass("file-checkout-other");
            if (html.ViewData["data_identifier"] != null)
                displayName.Attributes.Add("data-identifier", Convert.ToString(html.ViewData["data_identifier"]));

            if (GenFunctions.emptyG(documentFk) == 0)
            {
                displayName.Attributes.Add("style", "cursor:pointer");
                string url = html.Raw(urlHelper.Action("GetFile", baseArea, routeValues)).ToHtmlString();
                string target = ViewType == DocumentViewTypeMode.Print ? "_self" : "_blank";
                displayName.Attributes.Add("onclick", string.Format("javascript:QUtils.WindowOpen('{0}','{1}')", HttpUtility.JavaScriptStringEncode(url), target));
            }
            TagBuilder divGroup = new TagBuilder("div");
            divGroup.Attributes.Add("elem-identifier", "BtnGroup");
            divGroup.AddCssClass("i-input-group--right");

            TagBuilder buttonGroup = new TagBuilder("button");
            buttonGroup.AddCssClass("i-input-group__button--primary dropdown");
			buttonGroup.Attributes.Add("title", Resources.Resources.ACOES22599);
            buttonGroup.Attributes.Add("data-toggle", "dropdown");

            TagBuilder span = new TagBuilder("i");
            span.AddCssClass("glyphicons glyphicons-option-horizontal i-input-group__tag-icon");

            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("pull-right dropdown-menu");
            //ul.Attributes.Add("style", "overflow: hidden;");//IE things

            //download link
            div.InnerHtml += CreateDownloadFileLink(documentFk, externalDoc, value, showLink);

            if ((!docProps.IsCheckout || docProps.IsCheckout && docProps.IsCurrentUserEditing()) && !onlyShow)
            {
                //add link
                div.InnerHtml += CreateAddFileLink<TModel>(html, docProps, baseArea, baseAreaKey, versioning, fieldName, urlHelper, isRequired);

                //delete link
                if (!isRequired)
                    div.InnerHtml += CreateDeleteFileLink<TModel>(html, documentFk, baseArea, externalDoc, value, docProps, urlHelper, isRequired);
            }

            if (docProps.Versions != null && docProps.Versions.Count > 1)
                div.InnerHtml += CreateFileVersionsLink(html, docProps, onlyShow, urlHelper, baseArea, isRequired);

            //Last updated by [SF] at [2016.10.21]
            //create document link
            if (docProps.IsEmpty() && useTemplates && !docProps.IsCheckout)
                div.InnerHtml += CreateFileCreationLink(html, docProps, fieldName, urlHelper, baseArea);

            //properties link
            CreateFilePropertiesLink(documentFk, externalDoc, value, div, urlHelper, baseArea, identifier);
            buttonGroup.InnerHtml = span.ToString(TagRenderMode.Normal);
            divGroup.InnerHtml = buttonGroup.ToString(TagRenderMode.Normal);
            divGroup.InnerHtml += div.ToString(TagRenderMode.Normal);
            firstDiv.InnerHtml = displayName.ToString(TagRenderMode.SelfClosing);
            firstDiv.InnerHtml += divGroup.ToString(TagRenderMode.Normal);

            if (!externalDoc)
            {
                TagBuilder inputFk = new TagBuilder("input");
                inputFk.Attributes.Add("id", fieldName + "fk");
                inputFk.Attributes.Add("name", fieldName + "fk");
                inputFk.Attributes.Add("type", "hidden");
                inputFk.Attributes.Add("value", documentFk);
                firstDiv.InnerHtml += inputFk;
            }

            TagBuilder containerDiv = new TagBuilder("div");
            containerDiv.Attributes.Add("elem-identifier", "DocumContainer");
            containerDiv.AddCssClass("docum-container");
            containerDiv.InnerHtml += firstDiv;
            containerDiv.Attributes.Add("data-ticket", ticket);
            containerDiv.Attributes.Add("data-use-templates", useTemplates.ToString().ToLower());

            TagBuilder textsDiv = new TagBuilder("div");
            textsDiv.Attributes.Add("id", "texts");
            textsDiv.Attributes.Add("data-text-cancel", Resources.Resources.CANCELAR49513);
            textsDiv.Attributes.Add("data-text-submit", Resources.Resources.SUBMETER21206);
            textsDiv.Attributes.Add("data-text-error", Resources.Resources.OCORREU_UM_ERRO_AO_P53091);
            textsDiv.Attributes.Add("data-text-confirm-delete", Resources.Resources.TEM_A_CERTEZA_QUE_QU37043);
            textsDiv.Attributes.Add("data-text-yes", Resources.Resources.SIM28552);
            textsDiv.Attributes.Add("data-text-no", Resources.Resources.NAO06521);
            textsDiv.Attributes.Add("data-text-delete-all-versions", Resources.Resources.TODAS_AS_VERSOES_EXC52356.Replace("\\r\\n", "\r\n"));
            textsDiv.Attributes.Add("data-text-delete-last-version", Resources.Resources.A_ULTIMA_VERSAO_VAI_40630.Replace("\\r\\n", "\r\n"));
            textsDiv.Attributes.Add("data-text-delete-file-sucess", Resources.Resources.FICHEIRO_ELIMINADO_C48874);

            containerDiv.InnerHtml += textsDiv;

            return MvcHtmlString.Create(containerDiv.ToString(TagRenderMode.Normal));
        }

        private static MvcHtmlString CreateFileVersionsLink<TModel>(HtmlHelper<TModel> html, GenioMVC.ViewModels.DocumsProperties_ViewModel docProps, bool onlyShow, UrlHelper urlhelper, string baseArea, bool isRequired)
        {
            TagBuilder subMenu = new TagBuilder("div");
            subMenu.AddCssClass("dropdown-submenu");
            TagBuilder a = new TagBuilder("a");
            a.Attributes.Add("href", "#");
            a.AddCssClass("dropdown-item");
            TagBuilder i = new TagBuilder("i");
            i.AddCssClass("glyphicons glyphicons-list-alt e-icon");
            a.InnerHtml += i + " " + Resources.Resources.VERSOES25682;
            subMenu.InnerHtml += a;
            TagBuilder dMenu = new TagBuilder("ul");
            dMenu.AddCssClass("dropdown-menu");

            //version dbedit link
            TagBuilder innerDiv = new TagBuilder("div");
            IDictionary<string, object> htmlProps = new Dictionary<string, object>();
            htmlProps.Add("data-url", urlhelper.Action("GetDocumsVersionsDbedit", baseArea, new { isRequired }));
            htmlProps.Add("class", "docums-dbedit dropdown-item");
            innerDiv.Attributes.Add("elem-identifier", "DocumsDbedit");
            innerDiv.InnerHtml += html.ActionLinkWithIcon(Resources.Resources.VER_TODAS___44710, "", "", "glyphicons glyphicons-list-alt e-icon", null, htmlProps);
            dMenu.InnerHtml += innerDiv;

            TagBuilder divider = new TagBuilder("div");
            divider.AddCssClass("dropdown-divider");
            dMenu.InnerHtml += divider;

            string fldSize = html.ViewData["fieldSize"] == null ? "" : html.ViewData["fieldSize"].ToString();
            User u = UserContext.Current.User;
            //all versions link
            if (docProps.Versions != null)
                foreach (var version in docProps.Versions)
                {
                    IDictionary<string, object> htmlPropsVersion = new Dictionary<string, object>();
                    RouteValueDictionary routeValues = new RouteValueDictionary();
                    htmlPropsVersion.Add("data-url", urlhelper.Action("GetSpecificFile", baseArea));
                    htmlPropsVersion.Add("class", "dropdown-item");
                    ResourceQuery rec = new ResourceQuery(version.Key, "docums", "ValDocument", "ValCoddocums", version.Value);
                    string ticket = QResources.CreateTicketEncryptedBase64(u.Name, u.Location, rec);

                    routeValues.Add("ticket", ticket);
                    innerDiv = new TagBuilder("div");
                    innerDiv.InnerHtml += html.ActionLinkWithIcon(version.Key, "GetSpecificFile", baseArea, "glyphicons glyphicons-download-alt e-icon", routeValues, htmlPropsVersion);
                    dMenu.InnerHtml += innerDiv;
                }
            if (!onlyShow)
            {
                dMenu.InnerHtml += divider;

                //delete last version link
                innerDiv = new TagBuilder("div");
                a = new TagBuilder("a");
                a.Attributes.Add("href", "#");
                a.Attributes.Add("data-action", "LastVersion");

                a.Attributes.Add("data-url", urlhelper.Action("DeleteFile", baseArea, new { fieldSize = fldSize, isRequired }));
                a.Attributes.Add("elem-identifier", "DeleteVersion");
                a.AddCssClass("delete-version dropdown-item");

                i = new TagBuilder("i");
                i.AddCssClass("glyphicons glyphicons-remove-circle e-icon");
                a.InnerHtml += i + " " + Resources.Resources.APAGAR_ULTIMA25492;
                innerDiv.InnerHtml += a;
                dMenu.InnerHtml += innerDiv;

                //delete historic link
                innerDiv = new TagBuilder("div");
                a = new TagBuilder("a");
                a.Attributes.Add("href", "#");
                a.Attributes.Add("data-action", "Historic");
                a.Attributes.Add("data-url", urlhelper.Action("DeleteFile", baseArea, new { fieldSize = fldSize, isRequired }));
                a.Attributes.Add("elem-identifier", "DeleteVersion");
                a.AddCssClass("delete-version dropdown-item");
                a.InnerHtml += i + " " + Resources.Resources.APAGAR_HISTORICO26221;
                innerDiv.InnerHtml += a;
                dMenu.InnerHtml += innerDiv;
            }

            subMenu.InnerHtml += dMenu;
            return MvcHtmlString.Create(subMenu.ToString(TagRenderMode.Normal));
        }

        private static MvcHtmlString CreateDownloadFileLink(string documentFk, bool externalDoc, string modelValue, HtmlString showLink)
        {
            var dItem = new TagBuilder("div");
            dItem.AddCssClass("dropdown-item");
            if ((!externalDoc && GenFunctions.emptyG(documentFk) == 1) || (externalDoc && String.IsNullOrEmpty(modelValue)))
                dItem.AddCssClass("disabled");
            dItem.InnerHtml = showLink.ToHtmlString();
            return MvcHtmlString.Create(dItem.ToString(TagRenderMode.Normal));
        }

        private static MvcHtmlString CreateAddFileLink<TModel>(HtmlHelper<TModel> html, GenioMVC.ViewModels.DocumsProperties_ViewModel docProps, string baseArea, string baseAreaKey, bool versioning, string propertyName, UrlHelper urlHelper, bool isRequired)
        {
            TagBuilder div = new TagBuilder("div");
            TagBuilder a = new TagBuilder("a");
            div.AddCssClass("dropdown-item");
            a.Attributes.Add("href", "#");
            TagBuilder i = new TagBuilder("i");
            i.AddCssClass("glyphicons glyphicons-plus e-icon");
            a.InnerHtml = i.ToString();
            string mode = "Insert";
            string inputType = "file";
            string fldSize = html.ViewData["fieldSize"] == null ? "" : html.ViewData["fieldSize"].ToString();
            string maxFileSize = html.ViewData["maxSize"] == null ? "null" : html.ViewData["maxSize"].ToString();
            string allowedTypes = html.ViewData["allowedTypes"] == null ? "" : html.ViewData["allowedTypes"].ToString();

            if (versioning)
            {
                if (docProps.IsCheckout)
                {
                    if (!docProps.IsCurrentUserEditing())
                        div.AddCssClass("disabled");
                    a.InnerHtml += Resources.Resources.SUBMETER21206;
                    mode = "Submit";
                    inputType = "text";
                    a.Attributes.Add("data-url", urlHelper.Action("SubmitVersion", baseArea, new { fieldSize = fldSize, isRequired, maxFileSize, allowedTypes }));
                }
                else if (docProps.IsEmpty())
                {
                    a.InnerHtml += Resources.Resources.ANEXAR20848;
                    a.Attributes.Add("data-url", urlHelper.Action("SetFile", baseArea, new { fieldSize = fldSize, isRequired, maxFileSize, allowedTypes }));
                }
                else
                {
                    a.InnerHtml += Resources.Resources.EDITAR11616;
                    mode = "Checkout";
                    inputType = "text";
                    a.Attributes.Add("data-url", urlHelper.Action("CheckoutDocum", baseArea, new { fieldSize = fldSize, isRequired, maxFileSize, allowedTypes }));
					// Last updated by [HTA] at [2019.10.01]
					string querystring = "?area=" + baseArea + "&areakey=" + baseAreaKey + "&openPane=true";
					a.Attributes.Add("data-extra", urlHelper.Action("PrepareFileLink", "Home") + querystring);
                    a.Attributes.Add("title", Resources.Resources.EDITAR11616);
                }
            }
            else
            {
                a.InnerHtml += Resources.Resources.ANEXAR20848;
                a.Attributes.Add("data-url", urlHelper.Action("SetFile", baseArea, new { fieldSize = fldSize, isRequired, maxFileSize, allowedTypes }));
            }

            a.Attributes.Add("data-action", "attach");
            a.Attributes.Add("data-mode", mode);
            a.Attributes.Add("style", "height: 32px;");
            var classHiddenFile = docProps.IsCheckout && !docProps.IsCurrentUserEditing() ? "disabled" : "";
            string inputId = propertyName + "_file";

            TagBuilder fileInput = new TagBuilder("input");
            fileInput.Attributes.Add("type", inputType);
            fileInput.Attributes.Add("id", inputId);
            fileInput.Attributes.Add("name", inputId);
            fileInput.AddCssClass("i-input-group__file-attach");
            fileInput.AddCssClass(classHiddenFile);

            a.InnerHtml += fileInput;
            div.InnerHtml = a.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(div.ToString(TagRenderMode.Normal));
        }

        private static MvcHtmlString CreateDeleteFileLink<TModel>(HtmlHelper<TModel> html, string documentFk, string baseArea, bool externalDoc, string modelValue, GenioMVC.ViewModels.DocumsProperties_ViewModel docProps, UrlHelper urlHelper, bool isRequired)
        {
            string fldSize = html.ViewData["fieldSize"] == null ? "" : html.ViewData["fieldSize"].ToString();
            string maxFileSize = html.ViewData["maxSize"] == null ? "null" : html.ViewData["maxSize"].ToString();
            string allowedTypes = html.ViewData["allowedTypes"] == null ? "" : html.ViewData["allowedTypes"].ToString();
            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("dropdown-item");
            if ((!externalDoc && GenFunctions.emptyG(documentFk) == 1) || (externalDoc && String.IsNullOrEmpty(modelValue)) || docProps.IsCheckout)
                div.AddCssClass("disabled");
            IDictionary<string, object> htmlProperties = new Dictionary<string, object>();
            htmlProperties.Add("href", "#");
            htmlProperties.Add("data-url", urlHelper.Action("DeleteFile", baseArea,  new { fieldSize = fldSize, isRequired, maxFileSize, allowedTypes }));
            htmlProperties.Add("data-action", "delete");
            htmlProperties.Add("title", Resources.Resources.APAGAR04097);
            HtmlString deleteLink = html.ActionLinkWithIcon(Resources.Resources.APAGAR04097, null, null, "glyphicons glyphicons-remove-circle e-icon", null, htmlProperties);
            div.InnerHtml = deleteLink.ToHtmlString();

            return MvcHtmlString.Create(div.ToString(TagRenderMode.Normal));
        }

        private static void CreateFilePropertiesLink(string documentFk, bool externalDoc, string modelValue, TagBuilder ul, UrlHelper urlHelper, string baseArea, string identifier = null)
        {
            if (!externalDoc)
            {
                TagBuilder divider = new TagBuilder("div");
                divider.AddCssClass("dropdown-divider");
                ul.InnerHtml += divider;

                TagBuilder div = new TagBuilder("div");
                div.AddCssClass("dropdown-item");
                if (GenFunctions.emptyG(documentFk) == 1)
                    div.AddCssClass("disabled");
				RouteValueDictionary routeValues = new RouteValueDictionary();
                routeValues.Add("identifier", identifier);
                TagBuilder a = new TagBuilder("a");
                a.Attributes.Add("href", "#");
                a.Attributes.Add("data-url", urlHelper.Action("GetFileProperties", baseArea, routeValues));
                a.Attributes.Add("data-action", "properties");
                TagBuilder i = new TagBuilder("i");
                i.AddCssClass("glyphicons glyphicons-list e-icon");
                a.InnerHtml += i.ToString(TagRenderMode.Normal) + " " + Resources.Resources.PROPRIEDADES45924;
                a.Attributes.Add("title", Resources.Resources.PROPRIEDADES45924);
                div.InnerHtml = a.ToString(TagRenderMode.Normal);
                div.ToString(TagRenderMode.Normal);

                ul.InnerHtml += div.ToString(TagRenderMode.Normal);
            }
        }

        //Last updated by [CJP] at [2014.10.27]
        //Creates a link for the Templates DBEdit
        private static MvcHtmlString CreateFileCreationLink<TModel>(HtmlHelper<TModel> html, GenioMVC.ViewModels.DocumsProperties_ViewModel docProps, string propertyName, UrlHelper urlHelper, string baseArea)
        {
            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("dropdown-item");
            TagBuilder a = new TagBuilder("a");
            a.Attributes.Add("elem-identifier", "CreateDocTempl");
            a.AddCssClass("createdoctempl");
            a.Attributes.Add("href", "#");
            a.Attributes.Add("data-url", urlHelper.Action(html.ViewBag.Form + "_" + propertyName, baseArea));
            a.Attributes.Add("data-formname", html.ViewBag.Form);
            a.Attributes.Add("data-fldname", propertyName);
            TagBuilder i = new TagBuilder("i");
            i.AddCssClass("glyphicons glyphicons-plus e-icon");

            a.InnerHtml += i.ToString(TagRenderMode.Normal) + " " + Resources.Resources.CRIAR_DOCUMENTO55731;
            a.Attributes.Add("title", Resources.Resources.CRIAR_DOCUMENTO55731);
            div.InnerHtml += a;
            return MvcHtmlString.Create(div.ToString(TagRenderMode.Normal));
        }

        #endregion

        #region TitleFor (To be used when needing a custom tagElement)

        public static MvcHtmlString TitleFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string tagElement, object htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);

            string resolvedLabelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (string.IsNullOrEmpty(resolvedLabelText))
            {
                return MvcHtmlString.Empty;
            }

            TagBuilder tag = new TagBuilder(tagElement);
            //tag.Attributes.Add("for", TagBuilder.CreateSanitizedId(html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)));
            tag.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            tag.SetInnerText(resolvedLabelText);
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

        #endregion

        #region Frame Control (IE)

        /// <summary>
        /// Helper for the IE Control Type that creates a frame in the page
        /// </summary>
        /// <param name="html">The HTML Helper</param>
        /// <param name="source">The source for the frame</param>
        /// <param name="htmlAttributes">Additional html attributes</param>
        /// <returns>The MVCHtmlString to be rendered by the template</returns>
        public static MvcHtmlString FrameHTML(this HtmlHelper html, string code, object htmlAttributes = null)
        {
            TagBuilder tag = new TagBuilder("div");
            tag.Attributes.Add("width", "100%");
            tag.Attributes.Add("height", "400px");
            tag.InnerHtml = code;

            if (htmlAttributes != null)
                tag.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// Helper for the IE Control Type that creates a frame in the page
        /// </summary>
        /// <param name="html">The HTML Helper</param>
        /// <param name="source">The source for the frame</param>
        /// <param name="htmlAttributes">Additional html attributes</param>
        /// <returns>The MVCHtmlString to be rendered by the template</returns>
        public static MvcHtmlString FrameHTML(this HtmlHelper html, MvcHtmlString code, object htmlAttributes = null)
        {
            return FrameHTML(html, code.ToHtmlString(), htmlAttributes);
        }

        /// <summary>
        /// Helper for the IE Control Type that creates a frame in the page
        /// </summary>
        /// <param name="html">The HTML Helper</param>
        /// <param name="source">The source for the frame</param>
        /// <param name="htmlAttributes">Additional html attributes</param>
        /// <returns>The MVCHtmlString to be rendered by the template</returns>
        public static MvcHtmlString Frame(this HtmlHelper html, string source, object htmlAttributes = null)
        {
            return FrameHelper(html, source, "manual", htmlAttributes);
        }

        /// <summary>
        /// Helper for the IE Control Type that creates a frame in the page
        /// </summary>
        /// <param name="html">The HTML Helper</param>
        /// <param name="expression">The expression used to be used as source of the iframe</param>
        /// <param name="htmlAttributes">Additional html attributes</param>
        /// <returns>The MVCHtmlString to be rendered by the template</returns>
        public static MvcHtmlString FrameFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);

            string resolvedLabelText = metadata.Model as string ?? metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (string.IsNullOrEmpty(resolvedLabelText))
            {
                return MvcHtmlString.Empty;
            }

            return FrameHelper(html, resolvedLabelText, htmlFieldName, htmlAttributes);
        }

        private static MvcHtmlString FrameHelper(HtmlHelper html, string source, string htmlFieldName, object htmlAttributes)
        {
            //<iframe src="@Model.Documento.Localiza" height="400px" width="100%"></iframe>

            TagBuilder tag = new TagBuilder("iframe");
            tag.Attributes.Add("for", TagBuilder.CreateSanitizedId(html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)));
            tag.Attributes.Add("src", source);
            tag.Attributes.Add("width", "100%");
            tag.Attributes.Add("height", "400px");

            if (htmlAttributes != null)
                tag.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

        #endregion

        #region RadioButtonForSelectList

        public static MvcHtmlString RadioButtonForSelectList<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, SelectList list, string optionLabel, object htmlAttributes, int columns)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var sb = new StringBuilder();

			//Get primary key to append to name attribute so when multiple forms are shown, each has a unique group name
			var pk = "";
            if (html.ViewData.Model.GetType().GetProperty("QPrimaryKey") != null) {
                pk = (string)html.ViewData.Model.GetType().GetProperty("QPrimaryKey").GetValue(html.ViewData.Model, null);
            }

            TagBuilder div = new TagBuilder("div");
            div.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            div.AddCssClass("radio-button");

            if (list != null )
            {
				if (columns == 0)
                    columns = list.Count();

				// Calculate the number of radio buttons per column
				int rst = list.Count() % columns;
				int qtd = list.Count() / columns;

				// Verify if division is entire or not
                if(rst != 0)
                {
                    qtd++;
                }
                int cnt = 0;
                int cntcol = 0;

                sb.AppendLine("<div class='form-check-columns'>");

                foreach (SelectListItem item in list)
                {
                    if (cntcol < columns)
                    {
                        if(cnt == 0)
                        {
                            sb.AppendLine("<div class='column'>");
                            //sb.AppendLine("<ul>");
                        }

                        if (cnt < qtd)
                        {
                            TagBuilder li = new TagBuilder("li");
                            TagBuilder label = new TagBuilder("label");
                            label.SetInnerText(item.Text);
                            label.AddCssClass("i-radio i-radio__label i-radio--inline");
                            // Generate an id to be given to the radio button field

                            var id = metaData.PropertyName;
                            // Create and populate a radio button using the existing html helpers
                            TagBuilder radio = new TagBuilder("input");
                            radio.Attributes.Add("id", id);
                            radio.Attributes.Add("name", id + "_" + pk);
                            radio.Attributes.Add("type", "radio");
                            radio.Attributes.Add("value", item.Value);
                            radio.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
                            radio.Attributes.Remove("data-toggle");
                            if (item.Selected)
                                radio.Attributes.Add("checked", "checked");

                            TagBuilder span = new TagBuilder("span");
                            span.AddCssClass("i-radio__field");
                            radio.InnerHtml += span;

                            label.InnerHtml += radio;
                            //li.InnerHtml += label;

                            sb.Append(label.ToString());
                            //sb.AppendFormat("<label class=\"i-radio i-radio__label i-radio--inline\">{0}{1}</label>", radio, item.Text);
                            cnt++;
                        }
                        // Check if the radio buttons created are reaching the limite of the column
                        if (cnt + 1 > qtd)
                        {
                            sb.Append("</div>");
                            //sb.AppendLine("</ul>");
                            cnt = 0;
                            cntcol++;
                        }
                    }
                }
                // In case the radio buttons did not reach the limite of the column
                if (cnt != 0)
                {
                    sb.Append("</div>");
                }
                sb.Append("</div>");
            }

            div.InnerHtml = sb.ToString();

            return MvcHtmlString.Create(div.ToString());
        }
        #endregion

        #region Logical Array
        public static MvcHtmlString ArrayLogicalFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, SelectList selectList, HtmlHelperExtensions.GetArrayElement getArrayElement, bool disabled, object htmlAttributes)
        {
            if (selectList == null)
                throw new ArgumentException("No selectlist");

            //Obtain the value
            var prop = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var fieldName = prop.PropertyName;
            var value = (int)prop.Model;

            var _trueOption = selectList.FirstOrDefault(item => item.Value == "1");
            var _falseOption = selectList.FirstOrDefault(item => item.Value == "0");

            var trueOption = new TagBuilder("span") { InnerHtml = HttpUtility.HtmlEncode(_trueOption.Text) };
            var falseOption = new TagBuilder("span") { InnerHtml = HttpUtility.HtmlEncode(_falseOption.Text) };

            var divWrapper = new TagBuilder("div");
            divWrapper.AddCssClass("i-switch");

            divWrapper.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            var label = new TagBuilder("label");

            var input = new TagBuilder("input");
            input.GenerateId(fieldName);
            input.Attributes.Add("type", "checkbox");
            if(value == 1)
                input.Attributes.Add("checked", "checked");
            if (disabled)
                input.Attributes.Add("disabled", "disabled");
            input.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            input.Attributes.Remove("data-toggle");

            //Helps
            string trueHelpId = getArrayElement != null ? getArrayElement(_trueOption.Value)?.HelpId : "";
            if (!String.IsNullOrEmpty(trueHelpId))
                trueOption.Attributes["title"] = Helpers.GetTextFromResources(trueHelpId);
            string falseHelpId = getArrayElement != null ? getArrayElement(_falseOption.Value)?.HelpId : "";
            if (!String.IsNullOrEmpty(falseHelpId))
                falseOption.Attributes["title"] = Helpers.GetTextFromResources(falseHelpId);

            falseOption.AddCssClass("i-switch__label-text"); falseOption.Attributes.Add("data-option", "false");
            trueOption.AddCssClass("i-switch__label-text"); trueOption.Attributes.Add("data-option", "true");

            var span = new TagBuilder("span");
            span.AddCssClass("i-switch__label");

            label.AddCssClass("action-input");/*FIX FOR TABBING*/
            label.InnerHtml += input;
            label.InnerHtml += span;
            label.InnerHtml += falseOption;
            label.InnerHtml += trueOption;

            divWrapper.InnerHtml += label;

            return MvcHtmlString.Create(divWrapper.ToString());
        }

        #endregion

	    #region Toggle Switch

        public static MvcHtmlString ToggleFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes, bool disabled)
        {
            //Obtain the value
            var prop = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var fieldName = prop.PropertyName;
            var value = (int)prop.Model;
            //< label class='switch'><input type = 'checkbox' name='movinterInput' checked><span class='slider round'></span></label>

            var label = new TagBuilder("label");
            label.AddCssClass("switch");

            var input = new TagBuilder("input");
            input.GenerateId(fieldName);
            input.Attributes.Add("type", "checkbox");
            if (value == 1)
                input.Attributes.Add("checked", "checked");
            if (disabled)
                input.Attributes.Add("disabled", "disabled");
            input.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            //Helps
            var span = new TagBuilder("span");
            span.AddCssClass("slider round");

            label.InnerHtml += input;
            label.InnerHtml += span;

            return MvcHtmlString.Create(label.ToString());
        }

        #endregion

        #region Date Control (D)

        /// <summary>
        /// Wrapper for DateTime format to be converted to MomentJs date format
        /// </summary>
        /// <param name="format">C# DateTime format (basic)</param>
        /// <returns>MomentJs date format</returns>
        public static string ConvertDateFormat2MomentJs(string format)
        {
            return format
                .Replace("dd", "DD").Replace("d", "D")
                .Replace("yyyy", "YYYY").Replace("yy", "YY")
                .Replace("tt", "A").Replace("t", "A");
        }

		//PMP 2020/03/03
        //Added alwaysShow parameter to allow skipping this check and showing in pop-ups for cross boundary selection without affecting other cases.
        /// <summary>
        /// Helper for the Date Control Type that creates a frame in the page
        /// </summary>
        /// <param name="html">The HTML Helper</param>
        /// <param name="expression">The expression used to be used as source of the iframe</param>
        /// <param name="htmlAttributes">Additional html attributes</param>
		/// <param name="alwaysShow">Specify whether to skip checking if field is a read-only type and show calendar anyway.</param>
        /// <returns>The MVCHtmlString to be rendered by the template</returns>
        public static MvcHtmlString DateFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, bool alwaysShow = false)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);

            var propertyName = metadata.PropertyName;
            if (propertyName == null)
                propertyName = ExpressionHelper.GetExpressionText(expression);

            RouteValueDictionary vals = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            DateAttribute.DateEnum ftype = DateAttribute.DateEnum.Undefined;

            if (metadata.AdditionalValues.ContainsKey("DateAttribute"))
            {
                ftype = (DateAttribute.DateEnum)metadata.AdditionalValues["DateAttribute"];
            }

            if(vals.ContainsKey("readonly") && vals["readonly"].ToString() == "readonly")
            {
                if (vals.ContainsKey("class"))
                    vals["class"] += " i-text__field";
                else
                    vals.Add("class", "i-text__field");
            }

            string internalType = String.Empty;
            if (metadata.AdditionalValues.ContainsKey("InternalType"))
                internalType = metadata.AdditionalValues["InternalType"].ToString();

            string dateElement = "", dataFormat = string.Empty;

            object value = null;
            bool isHour = false;

            switch (ftype)
            {
                case DateAttribute.DateEnum.Date:
                    dataFormat = Configuration.DateFormat.Date;
                    dateElement = "DatePicker";
					if(!vals.ContainsKey("title"))
						vals.Add("title", Resources.Resources.SELECAO_DE_UMA_DATA57549);
					else
						vals["title"] += " (" + Resources.Resources.SELECAO_DE_UMA_DATA57549 + ")";
                    if (metadata.Model == null || (DateTime?)metadata.Model == DateTime.MinValue)
                        value = (DateTime?)metadata.Model;
                    else
                        value = ((DateTime?)metadata.Model).Value.Date;
                    break;
                case DateAttribute.DateEnum.DateTime:
                    dateElement = "DatetimePicker";
                    dataFormat = Configuration.DateFormat.DateTime;
					if(!vals.ContainsKey("title"))
						vals.Add("title", Resources.Resources.SELECIONE_UMA_DATA_E27938);
					else
						vals["title"] += " (" + Resources.Resources.SELECIONE_UMA_DATA_E27938 + ")";
                    value = (DateTime?)metadata.Model;
                    break;
                case DateAttribute.DateEnum.DateTimeSeconds:
                    dateElement = "DatetimesecPicker";
                    dataFormat = Configuration.DateFormat.DateTimeSeconds;
					if(!vals.ContainsKey("title"))
						vals.Add("title", Resources.Resources.SELECIONE_UMA_DATA_E27938);
					else
						vals["title"] += " (" + Resources.Resources.SELECIONE_UMA_DATA_E27938 + ")";
                    value = (DateTime?)metadata.Model;
                    break;
                case DateAttribute.DateEnum.Time:
                    dateElement = "TimePicker";
                    dataFormat = Configuration.DateFormat.Time;
					if(!vals.ContainsKey("title"))
						vals.Add("title", Resources.Resources.SELECIONE_UMA_HORA20582);
					else
						vals["title"] += " (" + Resources.Resources.SELECIONE_UMA_HORA20582 + ")";
                    value = (string)metadata.Model;
                    isHour = true;
                    break;
                default:
                    return new MvcHtmlString("Tipo de campo de data não reconhecido");
            }

            vals.Add("elem-identifier", dateElement);
            vals.Add("data-format", dataFormat);
            vals.Add("data-datetimepicker-format", ConvertDateFormat2MomentJs(dataFormat));

            MvcHtmlString input;

            bool isDateMinValue = value is DateTime && (DateTime)value == DateTime.MinValue;
            if (isHour || isDateMinValue)
            {
                TagBuilder inputBox = new TagBuilder("input");
                inputBox.MergeAttributes(vals);
                // issue with id being already in vals, due to limit selections
                if (!inputBox.Attributes.ContainsKey("id"))
                    inputBox.Attributes.Add("id", propertyName);
                inputBox.Attributes.Add("name", propertyName);
                inputBox.Attributes.Add("type", "text");
                inputBox.AddCssClass("i-input-group__field i-date-picker__field");

                if (value != null)
                {
                    bool isHourWithValue = !value.ToString().Equals("__:__") && !value.ToString().Equals("") && value is string;
                    bool isDateWithValue = value is DateTime && (DateTime)value != DateTime.MinValue;
                    if (isHourWithValue || isDateWithValue)
                    {
                        if (!System.Text.RegularExpressions.Regex.IsMatch(value.ToString(), "^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"))
                            inputBox.Attributes.Add("value", value.ToString());
                        else
                        {
                            var auxVal = value.ToString().Split(':');
                            int h = Convert.ToInt32(auxVal[0]), m = Convert.ToInt32(auxVal[1]);
                            inputBox.Attributes.Add("value", new DateTime(1, 1, 1, h, m, 0).ToString(dataFormat, CultureInfo.InvariantCulture));
                        }
                    }

                }
                input = MvcHtmlString.Create(inputBox.ToString());
            }
            else
            {
                //TODO: how to prepare international data format to work with the data control plugin?
                if (value != null)
                {
                    string strValue = ((DateTime)value).ToString(dataFormat, CultureInfo.InvariantCulture);
                    // MH (17/01/2017) - Depois da alteração da submissão dos forms ser por ajax, os controlos de data enviam to servidor o Qvalue da data no format universal,
                    //e se acontecer algum erro no servidor ao re-renderizar a pagina, aparece o Qvalue que vem do cliente e não o que nós passamos nos parametros do InputExtensions.TextBox
                    if (html.ViewData.ModelState.ContainsKey(propertyName))
                        html.ViewData.ModelState.SetModelValue(propertyName, new ValueProviderResult(strValue, String.Empty, CultureInfo.InvariantCulture));
                    input = InputExtensions.TextBox(html, propertyName, strValue, vals);
                }
                else
                    input = InputExtensions.TextBox(html, propertyName, String.Empty, vals);
            }

            //prebelo  25/07/2014 15:49:22
            //Changed hardcoded fields (OD, ED, ON and EN) in views for DateFor and TextBoxFor to read only, to make possible to use them in "access levels" on the server side.
			//PMP 2020/03/03
            //Added alwaysShow in condition to allow skipping this check and showing in pop-ups for cross boundary selection without affecting other cases.
            if (!alwaysShow && (internalType == "OD" || internalType == "ED"))
                return input;

            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("date");

            if (!vals.ContainsKey("readonly"))
            {
                TagBuilder divGrp = new TagBuilder("div");
                if(!isHour)
                {
                    div.AddCssClass("i-input-group");
                    divGrp.AddCssClass("i-input-group--right i-date-picker__button");
                }
                else
                {
                    div.AddCssClass("i-input-group");
                    divGrp.AddCssClass("i-input-group--right i-time-picker__button");
                }

                TagBuilder btn = new TagBuilder("button");
                btn.Attributes.Add("type", "button");
                if (!isHour)
				{
                    btn.AddCssClass("i-date-picker__button--secondary");
					btn.Attributes.Add("title", Resources.Resources.SELECAO_DE_UMA_DATA57549);
				}
                else
				{
                    btn.AddCssClass("i-time-picker__button--secondary");
					btn.Attributes.Add("title", Resources.Resources.SELECIONE_UMA_HORA20582);
				}

                TagBuilder span = new TagBuilder("span");
                if (!isHour)
                    span.AddCssClass("glyphicons glyphicons-calendar i-input-group__tag-icon");
                else
                    span.AddCssClass("glyphicons glyphicons-clock i-input-group__tag-icon");

                btn.InnerHtml += span;
                divGrp.InnerHtml += btn;

                div.InnerHtml += input;
                div.InnerHtml += divGrp;
            }
            else
                div.InnerHtml += input;

            return MvcHtmlString.Create(div.ToString());
        }

        /// <summary>
        /// Helper for the Date Control Type that creates a frame in the page
        /// </summary>
        /// <param name="html">The HTML Helper</param>
        /// <param name="fTipo">Value type</param>
        /// <param name="inputId">Input html ID</param>
        /// <param name="_value">Default Value</param>
        /// <param name="htmlAttributes">Additional html attributes</param>
        /// <returns>The MVCHtmlString to be rendered by the template</returns>
        public static MvcHtmlString DateTextBox(this HtmlHelper html, DateAttribute.DateEnum fType, string inputId, object value = null, object htmlAttributes = null)
        {
            RouteValueDictionary vals = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            string dateElement = string.Empty, dataFormat = string.Empty;
            var isHour = false;

            switch (fType)
            {
                case DateAttribute.DateEnum.Date:
                    dataFormat = Configuration.DateFormat.Date;
                    dateElement = "DatePicker";
					if(!vals.ContainsKey("title"))
						vals.Add("title", Resources.Resources.SELECAO_DE_UMA_DATA57549);
					else
						vals["title"] += " (" + Resources.Resources.SELECAO_DE_UMA_DATA57549 + ")";
                    break;
                case DateAttribute.DateEnum.DateTime:
                    dateElement = "DatetimePicker";
                    dataFormat = Configuration.DateFormat.DateTime;
					if(!vals.ContainsKey("title"))
						vals.Add("title", Resources.Resources.SELECIONE_UMA_DATA_E27938);
					else
						vals["title"] += " (" + Resources.Resources.SELECIONE_UMA_DATA_E27938 + ")";
                    break;
                case DateAttribute.DateEnum.DateTimeSeconds:
                    dateElement = "DatetimesecPicker";
                    dataFormat = Configuration.DateFormat.DateTimeSeconds;
					if(!vals.ContainsKey("title"))
						vals.Add("title", Resources.Resources.SELECIONE_UMA_DATA_E27938);
					else
						vals["title"] += " (" + Resources.Resources.SELECIONE_UMA_DATA_E27938 + ")";
                    break;
                case DateAttribute.DateEnum.Time:
                    dateElement = "TimePicker";
                    dataFormat = Configuration.DateFormat.Time;
                    isHour = true;
					if(!vals.ContainsKey("title"))
						vals.Add("title", Resources.Resources.SELECIONE_UMA_HORA20582);
					else
						vals["title"] += " (" + Resources.Resources.SELECIONE_UMA_HORA20582 + ")";
                    break;
                default:
                    return new MvcHtmlString("Tipo de campo de data não reconhecido");
            }

            vals.Add("elem-identifier", dateElement);
            vals.Add("data-format", dataFormat);
            vals.Add("data-datetimepicker-format", ConvertDateFormat2MomentJs(dataFormat));

            MvcHtmlString input;

            bool isEmptyOrString = value == null || value is string;
            bool isDateMinValue = value is DateTime && (DateTime)value == DateTime.MinValue;
            if (isEmptyOrString || isHour || isDateMinValue)
            {
                TagBuilder inputBox = new TagBuilder("input");
                inputBox.Attributes.Add("type", "text");
                inputBox.Attributes.Add("id", inputId);
                if (value != null)
                {
                    bool isHourWithValue = !value.ToString().Equals("__:__") && !value.ToString().Equals("") && value is string;
                    bool isDateWithValue = value is DateTime && (DateTime)value != DateTime.MinValue;
                    if (isHourWithValue || isDateWithValue)
                    {
                        if (!System.Text.RegularExpressions.Regex.IsMatch(value.ToString(), "^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"))
                            inputBox.Attributes.Add("value", value.ToString());
                        else
                        {
                            var auxVal = value.ToString().Split(':');
                            int h = Convert.ToInt32(auxVal[0]), m = Convert.ToInt32(auxVal[1]);
                            inputBox.Attributes.Add("value", new DateTime(1, 1, 1, h, m, 0).ToString(dataFormat));
                        }
                    }
                }
                inputBox.MergeAttributes(vals);
                input = MvcHtmlString.Create(inputBox.ToString());
            }
            else
            {
                //TODO: how to prepare international data format to work with the data control plugin?
                string strValue = ((DateTime)value).ToString(dataFormat, CultureInfo.InvariantCulture);
                // MH (17/01/2017) - Depois da alteração da submissão dos forms ser por ajax, os controlos de data enviam to servidor o Qvalue da data no format universal,
                //e se acontecer algum erro no servidor ao re-renderizar a pagina, aparece o Qvalue que vem do cliente e não o que nós passamos nos parametros do InputExtensions.TextBox
                if (html.ViewData.ModelState.ContainsKey(inputId))
                    html.ViewData.ModelState.SetModelValue(inputId, new ValueProviderResult(strValue, String.Empty, CultureInfo.InvariantCulture));
                input = InputExtensions.TextBox(html, inputId, strValue, vals);
            }

            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("date");
            div.InnerHtml += input;

            if (!(vals.ContainsKey("readonly") && vals["readonly"].ToString() == "readonly"))
            {
                TagBuilder apendDiv = new TagBuilder("div");
                if (!isHour)
                {
                    div.AddCssClass("i-input-group input-medium i-date-picker");
                    apendDiv.AddCssClass("i-input-group--right i-date-picker__button");
                }
                else
                {
                    div.AddCssClass("i-input-group input-medium i-time-picker");
                    apendDiv.AddCssClass("i-input-group--right i-time-picker__button");
                }

                TagBuilder pickerButton = new TagBuilder("button");
                pickerButton.Attributes.Add("type", "button");
                if (!isHour)
				{
                    pickerButton.AddCssClass("i-date-picker__button--secondary");
					pickerButton.Attributes.Add("title", Resources.Resources.SELECAO_DE_UMA_DATA57549);
				}
                else
				{
                    pickerButton.AddCssClass("i-picker-picker__button--secondary");
					pickerButton.Attributes.Add("title", Resources.Resources.SELECIONE_UMA_HORA20582);
				}

                TagBuilder span = new TagBuilder("span");
                if (!isHour)
                    span.AddCssClass("glyphicons glyphicons-calendar i-input-group__tag-icon");
                else
                    span.AddCssClass("glyphicons glyphicons-clock i-input-group__tag-icon");

                pickerButton.InnerHtml += span;
                apendDiv.InnerHtml += pickerButton;

                div.InnerHtml += apendDiv;
            }

            return MvcHtmlString.Create(div.ToString());
        }

        public static MemberInfo FindFirstPropetyInfoMember(Expression exp)
        {
            MemberInfo member = null;
            if (exp is MemberExpression)
                member =  (exp as MemberExpression).Member;
            else if (exp is UnaryExpression)
                member = FindFirstPropetyInfoMember((exp as UnaryExpression).Operand);
            else if (exp is ConditionalExpression)
            {
                member = FindFirstPropetyInfoMember((exp as ConditionalExpression).IfTrue);
                if(member == null)
                    member = FindFirstPropetyInfoMember((exp as ConditionalExpression).IfFalse);
            }
            else if(exp is LambdaExpression)
                member = FindFirstPropetyInfoMember((exp as LambdaExpression).Body);

            return member;
        }

        public static string FormatDateValue(DateAttribute.DateEnum ftype, object value)
        {
            string dataFormat = string.Empty;

            switch (ftype)
            {
                case DateAttribute.DateEnum.Date:
                    dataFormat = Configuration.DateFormat.Date;
                    break;
                case DateAttribute.DateEnum.DateTime:
                    dataFormat = Configuration.DateFormat.DateTime;
                    break;
                case DateAttribute.DateEnum.DateTimeSeconds:
                    dataFormat = Configuration.DateFormat.DateTimeSeconds;
                    break;
                case DateAttribute.DateEnum.Time:
                    dataFormat = Configuration.DateFormat.Time;
                    break;
                default:
                    return "Unrecognized date field type.";
            }

            if (value == null || (value is string && (value.Equals("__:__") || value.Equals(""))))
                return string.Empty;

            if (ftype == DateAttribute.DateEnum.Time)
            {
                if (value is string)
                {
                    string[] auxVal = ((string)value).Split(':');
                    int h = Convert.ToInt32(auxVal[0]);
                    int m = Convert.ToInt32(auxVal[1]);
                    return new DateTime(1, 1, 1, h, m, 0).ToString(dataFormat, CultureInfo.InvariantCulture);
                }
                else return value.ToString();
            }
            else
            {
                // DBEdit with field of the Date type. (TableDBEdit<A>.ToString()) - Only in the Show mode.
                if ((value is string || value is DateTime) == false)
                    value = value.ToString();

                if (value is string)
                {
                    DateTime data;
                    if (DateTime.TryParse((string)value, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out data))
                        return data.ToString(dataFormat, CultureInfo.InvariantCulture);
                    else return string.Empty;
                }
                else
                    return ((DateTime)value).ToString(dataFormat, CultureInfo.InvariantCulture);
            }
        }

        public static string getDateFormatByType(DateAttribute.DateEnum date_type)
        {
            switch (date_type)
            {
                case DateAttribute.DateEnum.Date:
                     return Configuration.DateFormat.Date;
                case DateAttribute.DateEnum.DateTime:
                    return Configuration.DateFormat.DateTime;
                case DateAttribute.DateEnum.DateTimeSeconds:
                    return Configuration.DateFormat.DateTimeSeconds;
                case DateAttribute.DateEnum.Time:
                    return Configuration.DateFormat.Time;
                default: // its undefined! Type de Qfield de data não reconhecido
                    return null;
            }
        }

        public static string getJSDateFormatByType(DateAttribute.DateEnum date_type)
        {
            var dataFormat = getDateFormatByType(date_type);
            return ConvertDateFormat2MomentJs(dataFormat);
        }

        #endregion

        #region Number Control

		/// <summary>
        /// Helper for the Number Control Type
        /// </summary>
        /// <param name="html">The HTML Helper</param>
        /// <param name="expression">The expression</param>
        /// <param name="htmlProperties">Additional html attributes</param>
        /// <returns>The MVCHtmlString to be rendered by the template</returns>
        public static MvcHtmlString NumberFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlProperties = null)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string value;
			TagBuilder div = null;
            RouteValueDictionary vals = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlProperties);

			if(metadata.Model == null)
				value = "";
            else
                value = metadata.Model.ToString();


            CultureInfo formatCulture =  GetNumericCulture();

            if (vals.ContainsKey("data-currency"))
            {
                formatCulture = GetCurrencyCulture<TModel, TValue>(expression);
                div = new TagBuilder("div");
                div.AddCssClass("i-input-group");

                TagBuilder grpdiv = new TagBuilder("div");
                grpdiv.AddCssClass("i-input-group--left");

                TagBuilder span = new TagBuilder("span");
                span.AddCssClass("i-input-group__tag i-input-group__tag--secondary");
                span.InnerHtml += formatCulture.NumberFormat.CurrencySymbol;

                grpdiv.InnerHtml += span;
                div.InnerHtml += grpdiv;
            }

            string decimalSepataror = formatCulture.NumberFormat.NumberDecimalSeparator;
            string groupSeparator = formatCulture.NumberFormat.NumberGroupSeparator;

            vals["data-masking"] = true;
            vals["data-decimal-sep"] = decimalSepataror;
            vals["data-group-sep"] = groupSeparator;

            if (metadata.Model is Decimal)
            {
                value = ((Decimal)metadata.Model).ToString(formatCulture);
                // The numeric value must be in JavaScript format to avoid issues when comparing the field value with the value from persistence.
                vals["original-value"] = ((Decimal)metadata.Model).ToString(CultureInfo.InvariantCulture);
            }

            MvcHtmlString input = null;
            if (!string.IsNullOrEmpty(value))
            {
                // MH (17/01/2017) - Depois da alteração da submissão dos forms ser por ajax, os controlos de data enviam to servidor o Qvalue da data no format universal,
                //e se acontecer algum erro no servidor ao re-renderizar a pagina, aparece o Qvalue que vem do cliente e não o que nós passamos nos parametros do InputExtensions.TextBox
                if (html.ViewData.ModelState.ContainsKey(metadata.PropertyName))
                    html.ViewData.ModelState.SetModelValue(metadata.PropertyName, new ValueProviderResult(value, String.Empty, CultureInfo.InvariantCulture));
                input = InputExtensions.TextBox(html, metadata.PropertyName, value, vals);
            }
            else
                input = InputExtensions.TextBox(html, metadata.PropertyName, value, vals);

            if (div != null)
            {
                div.InnerHtml += input;
                return new MvcHtmlString(div.ToString());
            }
            else
                return input;
        }

        #endregion

        #region ComboBox

        /// <summary>
        /// Helper to display the selected item text instead of a full dropdown list
        /// </summary>
        /// <param name="html">The HTML Helper</param>
        /// <param name="list">The selectList that would be displayed</param>
        /// <returns>The MVCHtmlString to be rendered by the template</returns>
        public static MvcHtmlString DisplaySelectedItemFor<TModel>(this HtmlHelper<TModel> html, SelectList list, Object htmlProperties = null)
        {
            if (htmlProperties == null)
                htmlProperties = new { };

            IDictionary<string, object> htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlProperties);
            htmlAttributes.Add("color", "whiteSmoke");
            htmlAttributes.Add("font-style", "italic");

            var htmlAttr = flattenHtmlProps(htmlAttributes);

            TagBuilder div = new TagBuilder("div");
            div.MergeAttributes(htmlAttributes);
            div.AddCssClass("display-as-input");

            var text = MvcHtmlString.Empty;
            if (list != null && list.SelectedValue != null) {
                foreach (SelectListItem item in list)
                    if (list.SelectedValue.ToString() == item.Value)
                        text = MvcHtmlString.Create(item.Text);

				div.MergeAttribute("data-value", list.SelectedValue.ToString());
            }

            if(String.IsNullOrEmpty(text.ToString()))
            {
                div.AddCssClass("empty-value");
                div.Attributes.Add("data-empty", "<" + Resources.Resources.VAZIO58398 + ">");
            }

            div.SetInnerText(text.ToString());

            return MvcHtmlString.Create(div.ToString());
        }

        private static string flattenHtmlProps(IDictionary<string, object> htmlProperties)
        {
            StringBuilder line = new StringBuilder();
            foreach (var pair in htmlProperties)
                if(pair.Key != "form")
                    line.Append(" " + pair.Key + "='" + pair.Value + "'");
            return line.ToString();
        }

        #endregion

		#region CheckBoxWithDouble

        public static MvcHtmlString CheckBoxWithDouble<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Object htmlProperties = null)
        {
            if (htmlProperties == null)
                htmlProperties = new { };

            IDictionary<string, object> htmlAttributes;
            if (htmlProperties is IDictionary<string, object>)
                htmlAttributes = htmlProperties as IDictionary<string, object>;
            else
                htmlAttributes = new Dictionary<string, object>((htmlProperties as ViewDataDictionary));

            TagBuilder input = new TagBuilder("input");
            input.Attributes.Add("type", "checkbox");

            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);

            var propertyName = metadata.PropertyName;
            if (propertyName == null)
                propertyName = ExpressionHelper.GetExpressionText(expression);

            // These are required to map the html field to the viewmodel field
            if (!htmlAttributes.ContainsKey("id"))
                htmlAttributes.Add("id", propertyName);
            if (!htmlAttributes.ContainsKey("name"))
                htmlAttributes.Add("name", propertyName);
            // This needs to be removed, or the field will not be sent to the server
            if (htmlAttributes.ContainsKey("Form"))
                htmlAttributes.Remove("Form");

            input.MergeAttributes(htmlAttributes);

            double value = Double.Parse(metadata.Model.ToString());
            if (value == 1.0)
                input.Attributes.Add("checked", "checked");
            input.Attributes.Add("value", "true");

            // TODO: It is necessary to check if the second input is still necessary, since we no longer use the old logic of sending double values.
            // But the existence of the second input causes problems in the WAF rules because it has duplicate parameters, 
            //      which is normal behavior in checkboxes (used in browser submit of form redirect and menus).
            /*TagBuilder input2 = new TagBuilder("input");
            input2.Attributes.Add("value", "false");
            input2.Attributes.Add("type", "hidden");
            input2.Attributes.Add("name", propertyName);*/

            return new MvcHtmlString(input.ToString()/* + input2.ToString()*/);
        }

        public static MvcHtmlString CheckBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes, bool editionMode, bool isRequired)
        {
            ModelMetadata modelMeta = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string resolvedLabelText = modelMeta.DisplayName;
            RouteValueDictionary dic = htmlAttributes is RouteValueDictionary ? (RouteValueDictionary)htmlAttributes : HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            // For html5 compliance. Label should exist only inside a <form>
            TagBuilder label = new TagBuilder("label");
            TagBuilder input = new TagBuilder("input");

            var labelAttrs = new RouteValueDictionary();
            foreach (var kv in dic.Where(kv => kv.Key == "data-toggle" || kv.Key == "title"))
                labelAttrs.Add(kv.Key, kv.Value);

            label.MergeAttributes(labelAttrs);

            label.AddCssClass("i-checkbox i-checkbox__label");

            if (!editionMode || dic.ContainsKey("disabled") || dic.ContainsKey("readonly"))
            {
                label.AddCssClass("i-checkbox--disabled");
                input.Attributes.Add("disabled", "disabled");
            }
            label.SetInnerText(resolvedLabelText);

            input.Attributes.Add("type", "checkbox");

            var propertyName = modelMeta.PropertyName;
            if (propertyName == null)
                propertyName = ExpressionHelper.GetExpressionText(expression);

            // These are required to map the html field to the viewmodel field
            if (!dic.ContainsKey("id"))
                dic.Add("id", propertyName);
            if (!dic.ContainsKey("name"))
                dic.Add("name", propertyName);
            // This needs to be removed, or the field will not be sent to the server
            if (dic.ContainsKey("Form"))
                dic.Remove("Form");

            input.MergeAttributes(dic);

            if(modelMeta.Model is bool)
            {
                bool value = (bool)modelMeta.Model;
                if (value)
                    input.Attributes.Add("checked", "checked");
                input.Attributes.Add("original-value", value ? "1" : "0");
            }
            else if(modelMeta.Model is double)
            {
                double value = double.Parse(modelMeta.Model.ToString());
                if (value==1.0)
                    input.Attributes.Add("checked", "checked");
                input.Attributes.Add("original-value", value==1.0 ? "1" : "0");
            }
            else if(modelMeta.Model is decimal)
            {
                decimal value = decimal.Parse(modelMeta.Model.ToString());
                if (value==1)
                    input.Attributes.Add("checked", "checked");
                input.Attributes.Add("original-value", value==1 ? "1" : "0");
            }

            input.Attributes.Add("value", "true");
            label.InnerHtml += input;

            // TODO: It is necessary to check if the second input is still necessary, since we no longer use the old logic of sending double values.
            // But the existence of the second input causes problems in the WAF rules because it has duplicate parameters, 
            //      which is normal behavior in checkboxes (used in browser submit of form redirect and menus).
            /*TagBuilder input2 = new TagBuilder("input");
            input2.Attributes.Add("value", "false");
            input2.Attributes.Add("type", "hidden");
            input2.Attributes.Add("name", propertyName);
            label.InnerHtml += input2;*/

            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("i-checkbox__field");
            label.InnerHtml += span;

            return new MvcHtmlString(label.ToString(TagRenderMode.Normal));
        }
        #endregion

        #region DisplayForWithNull

        /// <summary>
        /// Helper to display for the given expression even if it is null or empty
        /// </summary>
        /// <param name="html">The HTML Helper</param>
        /// <param name="expression">The expression</param>
        /// <returns>The MVCHtmlString to be rendered by the template</returns>
        public static MvcHtmlString DisplayForWithNull<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Object htmlProperties = null)
        {
            if (htmlProperties == null)
                htmlProperties = new { };

            IDictionary<string, object> htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlProperties);
            if (htmlProperties.GetType().Name == "RouteValueDictionary")
                htmlAttributes = (RouteValueDictionary)htmlProperties;

            var htmlAttr = flattenHtmlProps(htmlAttributes);

            TagBuilder div = new TagBuilder("div");
            div.MergeAttributes(htmlAttributes);
            div.AddCssClass("display-as-input");

            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);

            MvcHtmlString display = MvcHtmlString.Empty;

            if(isNullOrEmptyValue(metadata.Model))
            {
                div.AddCssClass("empty-value");
                div.Attributes.Add("data-empty", "<" + Resources.Resources.VAZIO58398 + ">");
            }

            return FillInputValue<TModel, TValue>(html, expression, htmlAttributes, div, display, metadata);
        }

        #endregion

        #region DisplayForHref

        /// <summary>
        /// Helper to display for the given expression even if it is null or empty
        /// </summary>
        /// <param name="html">The HTML Helper</param>
        /// <param name="expression">The expression</param>
        /// <returns>The MVCHtmlString to be rendered by the template</returns>
        public static MvcHtmlString DisplayForHref<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Object htmlProperties = null)
        {
            if (htmlProperties == null)
                htmlProperties = new { };

            IDictionary<string, object> htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlProperties);

            var htmlAttr = flattenHtmlProps(htmlAttributes);

            TagBuilder a = new TagBuilder("a");
            a.MergeAttributes(htmlAttributes);
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);

            MvcHtmlString display = MvcHtmlString.Empty;

            if (metadata.Model == null || metadata.Model.ToString() == String.Empty)
            {
                a.AddCssClass("empty-value");
                a.Attributes.Add("data-empty", "<" + Resources.Resources.VAZIO58398 + ">");
            }

            return FillInputValue<TModel, TValue>(html, expression, htmlAttributes, a, display, metadata);
        }

        #endregion

        #region EditorForWithNull

        /// <summary>
        /// Helper to display for the given expression even if it is null or empty
        /// </summary>
        /// <param name="html">The HTML Helper</param>
        /// <param name="expression">The expression</param>
        /// <returns>The MVCHtmlString to be rendered by the template</returns>
        public static MvcHtmlString EditorForWithNull<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Object htmlProperties = null)
        {
            if (htmlProperties == null)
                htmlProperties = new { };

            IDictionary<string, object> htmlAttributes = new Dictionary<string, object>((htmlProperties as ViewDataDictionary));

            TagBuilder input = new TagBuilder("input");
            if(!htmlAttributes.ContainsKey("type"))
                htmlAttributes.Add("type", "text");

            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);

            var propertyName = metadata.PropertyName;
            if (propertyName == null)
                propertyName = ExpressionHelper.GetExpressionText(expression);

			// These are required to map the html field to the viewmodel field
            if (!htmlAttributes.ContainsKey("id"))
                htmlAttributes.Add("id", propertyName);
            if (!htmlAttributes.ContainsKey("name"))
                htmlAttributes.Add("name", propertyName);
			// This needs to be removed, or the field will not be sent to the server
            if (htmlAttributes.ContainsKey("Form"))
                htmlAttributes.Remove("Form");

            input.MergeAttributes(htmlAttributes);

            MvcHtmlString display = MvcHtmlString.Empty;

            return FillInputValue<TModel, TValue>(html, expression, htmlAttributes, input, display, metadata);
        }

        private static bool isNullOrEmptyValue(object modelValue)
        {
            return (modelValue == null || modelValue.ToString() == String.Empty || modelValue.ToString() == "__:__"
                || (modelValue is DateTime? && (DateTime)modelValue == DateTime.MinValue));
        }

        private static MvcHtmlString FillInputValue<TModel, TValue>(HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes, TagBuilder tag, MvcHtmlString display, ModelMetadata metadata)
        {
            if(!isNullOrEmptyValue(metadata.Model))
            {
                object metadata_Model = null;
                if (metadata.Model.GetType().Name == typeof(ViewModels.TableDBEdit<Models.ModelBase>).Name)
                    metadata_Model = metadata.Model.GetType().GetProperty("Value").GetValue(metadata.Model, null);
                else
                    metadata_Model = metadata.Model;

                if (metadata_Model is DateTime? && (DateTime)metadata_Model != DateTime.MinValue)
                {
                    // Date fields require data-format attribute
                    var dataAttribute = DateAttribute.DateEnum.Undefined;
                    if(metadata.AdditionalValues.ContainsKey("DateAttribute"))
                        dataAttribute = (DateAttribute.DateEnum)metadata.AdditionalValues["DateAttribute"];
                    if(!htmlAttributes.ContainsKey("data-format"))
                        htmlAttributes.Add("data-format", getDateFormatByType(dataAttribute));
                    display = new MvcHtmlString(FormatDate(expression, metadata));
                }
                else if (metadata.Model is bool || metadata.AdditionalValues.ContainsKey("ConditionalBinder"))
                {
                    htmlAttributes.Add("readonly", "readonly");
                    htmlAttributes.Add("disabled", "disabled");

                    if (metadata.AdditionalValues.ContainsKey("ConditionalBinder"))
                    {
                        Expression<Func<TModel, double>> exp = expression as Expression<Func<TModel, double>>;
                        return new MvcHtmlString((CheckBoxFor(html, exp, htmlAttributes, false, false).ToString()));
                    }
                    else
                    {
                        Expression<Func<TModel, bool>> exp = expression as Expression<Func<TModel, bool>>;
                        return new MvcHtmlString(CheckBoxFor(html, exp, htmlAttributes, false, false).ToString());
                    }
                }
                else if (metadata.AdditionalValues.ContainsKey("CurrencyAttribute"))
                    display = new MvcHtmlString(FormatCurrency(expression, metadata));
                else if (metadata.AdditionalValues.ContainsKey("DataArray"))
                    display = new MvcHtmlString(FormatArray(expression, metadata));
                else if (metadata.AdditionalValues.ContainsKey("Decimals"))
                    display = new MvcHtmlString(FormatNumeric(expression, metadata));
                else
                    display = new MvcHtmlString(metadata.Model.ToString());
            }

            if(tag.TagName == "div" || tag.TagName == "a" )
                tag.SetInnerText(display.ToString());
            else
                tag.Attributes.Add("value", display.ToString());

            return MvcHtmlString.Create(tag.ToString());
        }

        #endregion

        #region Render Section Scripts in Partial Views

        public static MvcHtmlString Script(this HtmlHelper htmlHelper, Func<object, System.Web.WebPages.HelperResult> template, string uniqueIdentifier = null)
        {
            if (String.IsNullOrEmpty(uniqueIdentifier))
                uniqueIdentifier = Guid.NewGuid().ToString();
            var items = htmlHelper.ViewContext.HttpContext.Items;
            if (!items.Contains("_script_" + uniqueIdentifier))
                htmlHelper.ViewContext.HttpContext.Items["_script_" + uniqueIdentifier] = template;
            return MvcHtmlString.Empty;
        }

        public static IHtmlString RenderScripts(this HtmlHelper htmlHelper)
        {
            foreach (object key in htmlHelper.ViewContext.HttpContext.Items.Keys)
            {
                if (key.ToString().StartsWith("_script_"))
                {
                    var template = htmlHelper.ViewContext.HttpContext.Items[key] as Func<object, System.Web.WebPages.HelperResult>;
                    if (template != null)
                    {
                        htmlHelper.ViewContext.Writer.Write(template(null));
                    }
                }
            }
            return MvcHtmlString.Empty;
        }

        #endregion

		#region Masks
        /// <summary>
        /// Helper for masks
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="htmlHelper">The HTML Helper</param>
        /// <param name="expression">The expression</param>
        /// <returns>The MVCHtmlString to be rendered</returns>
        public static MvcHtmlString MaskFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, Object htmlProperties = null)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            MaskAttribute.MaskEnum ftype = MaskAttribute.MaskEnum.Undefined;

            if (metadata.AdditionalValues.ContainsKey("MaskAttribute"))
            {
                ftype = (MaskAttribute.MaskEnum)metadata.AdditionalValues["MaskAttribute"];
            }

            IDictionary<string, object> htmlAttributes = null;
            string htmlClass = "";
            switch (ftype)
            {
                case MaskAttribute.MaskEnum.ZipCode:
                    htmlClass = "zipCodePT";
                    break;
                case MaskAttribute.MaskEnum.NIF:
                    htmlClass = "Nif";
                    break;
				case MaskAttribute.MaskEnum.SSN:
                    htmlClass = "Niss";
                    break;
				case MaskAttribute.MaskEnum.NIB:
                    htmlClass = "Nib";
                    break;
                case MaskAttribute.MaskEnum.IBAN:
                    htmlClass = "Iban";
                    break;
				case MaskAttribute.MaskEnum.CarPlatePT:
                    htmlClass = "carPlatePT";
                    break;
                default:
                    return new MvcHtmlString("Tipo de máscara não reconhecida");
            }

            htmlClass += " i-text__field i-text";

            if (htmlProperties == null)
                htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(new { @class = htmlClass });
            else
            {
                htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlProperties);
                if (htmlAttributes.ContainsKey("class"))
                    htmlAttributes["class"] += " " + htmlClass;
                else
                    htmlAttributes.Add("class", htmlClass);
            }

            MvcHtmlString html = default(MvcHtmlString);
            html = InputExtensions.TextBoxFor(htmlHelper, expression, htmlAttributes);
            return html;
        }
        #endregion

		#region Flash
        public static MvcHtmlString Flash<TModel>(this HtmlHelper<TModel> html, string label, string controlName, string flashName, string flashLink, int width, int height, object htmlAttributes = null)
        {
            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("flash-container");
            RouteValueDictionary vals = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            if (!String.IsNullOrEmpty(label))
            {
                TagBuilder lbl = new TagBuilder("label");
                lbl.AddCssClass("flow-label");
                lbl.SetInnerText(label);
                div.InnerHtml += lbl;
            }
            TagBuilder flashContainer = new TagBuilder("div");
            flashContainer.Attributes.Add("id", controlName);
            flashContainer.AddCssClass("flash");

            TagBuilder flash = new TagBuilder("object");
            flash.Attributes.Add("classid", "clsid:d27cdb6e-ae6d-11cf-96b8-444553540000");
            flash.Attributes.Add("codebase", "http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0");
            flash.Attributes.Add("id", flashName);
			flash.Attributes.Add("width", width.ToString());
            flash.Attributes.Add("height", height.ToString());
            flash.AddCssClass("flash-object");
            flash.MergeAttributes(vals);

            TagBuilder param = new TagBuilder("param");
            param.Attributes.Add("name", "allowScriptAccess");
            param.Attributes.Add("value", "sameDomain");
            flash.InnerHtml += param;

            param = new TagBuilder("param");
            param.Attributes.Add("name", "movie");
            param.Attributes.Add("value", flashLink);
            flash.InnerHtml += param;

            param = new TagBuilder("param");
            param.Attributes.Add("name", "menu");
            param.Attributes.Add("value", "false");
            flash.InnerHtml += param;

            param = new TagBuilder("param");
            param.Attributes.Add("name", "quality");
            param.Attributes.Add("value", "high");
            flash.InnerHtml += param;

            param = new TagBuilder("param");
            param.Attributes.Add("name", "bgcolor");
            param.Attributes.Add("value", "#ece9d8");
            flash.InnerHtml += param;

            TagBuilder embed = new TagBuilder("embed");
            embed.Attributes.Add("wmode", "transparent");
            embed.Attributes.Add("src", flashLink);
            embed.Attributes.Add("menu", "false");
            embed.Attributes.Add("quality", "high");
            embed.Attributes.Add("bgcolor", "#ece9d8");
            embed.Attributes.Add("width", "100%");
            embed.Attributes.Add("height", "100%");
            embed.Attributes.Add("swliveconnect", "true");
            embed.Attributes.Add("id", flashName);
            embed.Attributes.Add("name", flashName);
            embed.Attributes.Add("allowscriptaccess", "sameDomain");
			embed.Attributes.Add("base", new UrlHelper(html.ViewContext.RequestContext).Content("~/Content/flashes"));
            embed.Attributes.Add("type", "application/x-shockwave-flash");
            embed.Attributes.Add("pluginspage", "http://www.macromedia.com/go/getflashplayer");
            flash.InnerHtml += embed;

            flashContainer.InnerHtml += flash;

            div.InnerHtml += flashContainer;

            return MvcHtmlString.Create(div.ToString());
        }

        #endregion

        #region Export List
        public static MvcHtmlString ExportListMenu(this HtmlHelper html, string listId)
        {
            Dictionary<string, string> types = new Dictionary<string, string>() {
                {"pdf", Resources.Resources.FORMATO_DE_DOCUMENTO48724},
                {"ods", Resources.Resources.FOLHA_DE_CALCULO__OD46941},
                {"xlsx", Resources.Resources.FOLHA_DE_CALCULO_EXC59518},
                {"csv", Resources.Resources.VALORES_SEPARADOS_PO10397},
				{"xml", Resources.Resources.FORMATO_XML__XML_44251},
            };

            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("elem-identifier", "BtnGroup");
            div.AddCssClass("float-right");
            div.AddCssClass("b-btn-group");

            //TagBuilder spanCarret = new TagBuilder("span");
            //spanCarret.AddCssClass("caret");

            TagBuilder aExport = new TagBuilder("button");
            aExport.GenerateId("exportBtn_" + listId);
            aExport.AddCssClass("dropdown-toggle b-btn b-icon-text b-icon-text--secondary i-input-group__button--secondary");
            aExport.Attributes.Add("data-toggle", "dropdown");
            aExport.Attributes.Add("aria-haspopup", "true");
            aExport.Attributes.Add("aria-expanded", "false");
            aExport.Attributes.Add("type", "button");

            TagBuilder icon = new TagBuilder("i");
            icon.AddCssClass("glyphicons glyphicons-file-export e-icon");
            aExport.InnerHtml += icon;

            aExport.InnerHtml += Resources.Resources.EXPORTAR35632 + "&nbsp;";

            TagBuilder ul = new TagBuilder("div");
            ul.Attributes.Add("id", "exportDrop");
            ul.AddCssClass("dropdown-menu dropdown-menu-right");

            foreach (var item in types)
            {
                //TagBuilder li = new TagBuilder("li");
                TagBuilder aBtn = new TagBuilder("a");
                aBtn.AddCssClass("dropdown-item");
                aBtn.Attributes.Add("tabindex", "-1");
				aBtn.Attributes.Add("href", "javascript:void(0);");
                aBtn.Attributes.Add("onclick", "window." + listId + ".ExportList('" + item.Key + "')");
                aBtn.SetInnerText(item.Value);

                //li.InnerHtml = aBtn.ToString();
                ul.InnerHtml += aBtn;
            }

            div.InnerHtml += aExport;
            div.InnerHtml += ul;

            return new MvcHtmlString(div.ToString());
        }
        #endregion

        #region Import List
        public static MvcHtmlString ImportListMenu(this HtmlHelper html, string listId)
        {
			Dictionary<string, string> types = new Dictionary<string, string>() {
                {"template_xlsx", Resources.Resources.DOWNLOAD_DE_TEMPLATE48385},
                //{"template_csv", Resources.Resources.DOWNLOAD_DE_TEMPLATE08007}, NOT IMPLEMENTED YET
            };

            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("elem-identifier", "BtnGroup");
            div.AddCssClass("float-right");
            div.AddCssClass("b-btn-group");

            TagBuilder aImport = new TagBuilder("button");
            aImport.AddCssClass("b-btn b-icon-text b-icon-text--secondary");
            aImport.Attributes.Add("href", "javascript:void(0);");
            aImport.Attributes.Add("onclick", "window." + listId + ".ImportList()");
            aImport.Attributes.Add("type","button");

            TagBuilder icon = new TagBuilder("i");
            icon.AddCssClass("glyphicons glyphicons-file-import e-icon");

            aImport.InnerHtml += icon;
            aImport.InnerHtml += Resources.Resources.IMPORTAR64751;

            TagBuilder aExport = new TagBuilder("button");
            aExport.AddCssClass("b-btn b-icon b-icon--secondary");
            aExport.AddCssClass("removecaret dropdown-toggle");
            aExport.Attributes.Add("data-toggle", "dropdown");
            aExport.Attributes.Add("aria-haspopup", "true");
            aExport.Attributes.Add("aria-expanded", "false");
            aExport.Attributes.Add("type", "button");
            aExport.Attributes.Add("title", Resources.Resources.DESCARREGAR58418 + " " + Resources.Resources.TEMPLATE03773);

            icon = new TagBuilder("i");
            icon.AddCssClass("glyphicons glyphicons-file-export e-icon");
            aExport.InnerHtml += icon;

            TagBuilder ul = new TagBuilder("div");
            ul.AddCssClass("dropdown-menu dropdown-menu-right");
            ul.Attributes.Add("id","importDrop");

            foreach (var item in types)
            {
                //TagBuilder li = new TagBuilder("li");
                TagBuilder aBtn = new TagBuilder("a");
                aBtn.AddCssClass("dropdown-item");
                aBtn.Attributes.Add("tabindex", "-1");
				aBtn.Attributes.Add("href", "javascript:void(0);");
                aBtn.Attributes.Add("onclick", "window." + listId + ".ExportTemplate('" + item.Key + "')");
                aBtn.SetInnerText(item.Value);

                ul.InnerHtml += aBtn;
            }
            div.InnerHtml += aImport;
            div.InnerHtml += aExport;
            div.InnerHtml += ul;

            return new MvcHtmlString(div.ToString());
        }
        #endregion

        #region Selection between limits
        /// <summary>
        /// Date value for selection menu between limits, taking into account the year of the database.
        /// </summary>
        /// <param name="type">SE limit type</param>
        /// <returns></returns>
        public static DateTime? GetBetweenLimitsDateValue(string type)
        {
            int Qyear = 0;
            var now = DateTime.Now; now = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, DateTimeKind.Unspecified);
            if (!int.TryParse(UserContext.Current.User.Year, out Qyear) || Qyear == 0)
                Qyear = now.Year;

            if(Qyear != now.Year)
                now = new DateTime(Qyear, 12, 31, 23, 59, 59, DateTimeKind.Unspecified);

            switch (type)
            {
                case "T":
                case "HJ":
                    return new DateTime(Qyear, now.Month, now.Day, now.Hour, now.Minute, now.Second);
                case "HJ-":
                    return new DateTime(Qyear, now.Month, now.Day, now.Hour, now.Minute, now.Second).AddDays(-1);
                case "HJ+":
                    return new DateTime(Qyear, now.Month, now.Day, now.Hour, now.Minute, now.Second).AddDays(1);
                case "1A":
                    return new DateTime(Qyear, 1, 1);
                case "UA":
                    return new DateTime(Qyear, 12, 31);
                case "1M":
                    return new DateTime(Qyear, now.Month, 1);
                case "UM":
                    return now.Month == 12 ? new DateTime(Qyear, 12, 31) : new DateTime(Qyear, now.Month + 1, 1).AddDays(-1);
                case "1T":
                    return new DateTime(Qyear, ((now.Month - 1) / 3) * 3 + 1, 1);
                case "UT":
                    return now.Month >= 10 ? new DateTime(Qyear, 12, 31) : new DateTime(Qyear, ((now.Month + 2) / 3) * 3 + 1, 1).AddDays(-1);
                case "1M-":
                    return DateTime.Now.Month == 1 ? new DateTime(Qyear - 1, 12, 1) : new DateTime(Qyear, now.Month - 1, 1);
                case "UM-":
                    return DateTime.Now.Month == 1 ? new DateTime(Qyear - 1, 12, 31) : new DateTime(Qyear, now.Month, 1).AddDays(-1);
                case "1M+":
                    return DateTime.Now.Month == 12 ? new DateTime(Qyear + 1, 1, 1) : new DateTime(Qyear, now.Month + 1, 1);
                case "UM+":
                    return now.Month == 12 ? new DateTime(Qyear + 1, 1, 31) : (now.Month == 11 ? new DateTime(Qyear, 12, 31) : new DateTime(Qyear, now.Month + 2, 1).AddDays(-1));
                case "1T-":
                    return DateTime.Now.Month <= 3 ? new DateTime(Qyear - 1, 10, 1) : new DateTime(Qyear, ((now.Month - 4) / 3) * 3 + 1, 1);
                case "UT-":
                    return new DateTime(Qyear, ((now.Month - 1) / 3) * 3 + 1, 1).AddDays(-1);
                case "1T+":
                    return DateTime.Now.Month >= 10 ? new DateTime(Qyear + 1, 1, 1) : new DateTime(Qyear, ((now.Month + 2) / 3) * 3 + 1, 1);
                case "UT+":
                    return DateTime.Now.Month >= 10 ? new DateTime(Qyear + 1, 3, 31) : new DateTime(Qyear, ((now.Month + 2) / 3) * 3 + 4, 1).AddDays(-1);
                default:
                    return null;
            }
        }
        #endregion

        #region Validations
        public static MvcHtmlString QValidationSummary(this HtmlHelper htmlHelper)
        {
            var anyError = htmlHelper.ViewData.ModelState.Values.Any(x => x.Errors.Any());

            //Try to parse the model from the HTML to ViewModelBase
            //There are View Models that might not support this type of warning
            ViewModelBase model = null;
            try
            {
                model = (ViewModelBase)htmlHelper.ViewData.Model;
            }
            catch (InvalidCastException)
            {
                model = null;
            }

            if (model != null && model.flashMessage != null && model.flashMessage.Warnings.Any() &&
                (model.Navigation.CurrentLevel.GetEntry("IgnoreWarnings") == null ||
                model.Navigation.CurrentLevel.GetEntry("IgnoreWarnings").ToString() == "false")) //Check for warnings
            {
                //Build bootbox script
                var script = new TagBuilder("script");
                script.Attributes.Add("id", "validation-summary-warnings");

                //Insert warning messages in a string
                int cnt = 0;
                string warnings = "";
                foreach (var warning in model.flashMessage.WarningMessages)
                {
                    if(cnt != 0)
                        warnings += "<br />";
                    warnings += "• " + warning;

                    cnt++;
                }

                script.InnerHtml += "displayMessage(\"" + warnings.Replace("\\", "\\").Replace("\"", "\\\"") + "\", \"W\", undefined, " +
                " [{ " +
                    "label: \"" + Resources.Resources.GRAVAR45301 + "\", " +
                    "style: MessageDefs.ButtonTypes.Primary, " +
                    "icon: \" SaveIcon\", " +
                    "callback: (result) => {" +
                        "if(result) {" +
                            "document.getElementById(\"IgnoreWarnings\").value = \"true\";" +
                            "const submitBtn = document.querySelector('[qButton=\"ok\"]');" +
                            "if (!submitBtn) {" +
                                "submit" + model.Navigation.CurrentLevel.Location.Controller + "(event);" +
                            "} else {" +
                                "submitBtn.click();" +
                            "}" +
                        "}" +
                    " }" +
                " }," +
                " { " +
                    "label: \"" + Resources.Resources.CANCELAR49513 + "\", " +
                    "style: MessageDefs.ButtonTypes.Secondary, " +
                    "icon: \"ban-circle\" " +
                " }], { imgWidth: \"4rem\" });";

                return new MvcHtmlString(script.ToString());
            }
            else if (anyError)
            {
                var div = new TagBuilder("div");
                div.AddCssClass("validation-summary-errors i-text__error");
                div.Attributes.Add("data-valmsg-summary", "true");

                var ul = new TagBuilder("ul");

                foreach (var modelState in htmlHelper.ViewData.ModelState)
                {
                    foreach (var error in modelState.Value.Errors)
                    {
                        var li = new TagBuilder("li");
                        var icon = new TagBuilder("i");
                        icon.AddCssClass("glyphicons glyphicons-light-beacon e-icon");

                        var eDiv = new TagBuilder("div");
                        eDiv.Attributes.Add("onclick", string.Format("QUtils.focusOnId('{0}'); return false;", modelState.Key));
                        eDiv.InnerHtml += icon;
                        eDiv.InnerHtml += " " + error.ErrorMessage;

                        li.InnerHtml += eDiv;
                        ul.InnerHtml += li;
                    }
                }
                div.InnerHtml += ul;

                return new MvcHtmlString(div.ToString());
            }
            else
                return MvcHtmlString.Empty;
        }
        #endregion

        #region Menu Actions

        public static MvcHtmlString MenuAction(this HtmlHelper html, Menus.MenuEntry menu, UrlHelper urlHelper, string module, string innerHtml, Object htmlProperties = null)
        {
            TagBuilder a = new TagBuilder("a");
            IDictionary<string, object> htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlProperties);
            a.MergeAttributes(htmlAttributes);
            if (menu.Action_MVC == null && menu.Children.Count == 1)
            {
                menu = menu.Children.First();
            }
            if (menu.Action != null && menu.Action.Equals("GenGenio.MenuRotinaManual"))
            {
                a.MergeAttribute("href", "javascript:void(0)");
                a.MergeAttribute("onclick", menu.Action_MVC + "();");
                a.MergeAttribute("routine", menu.Action_MVC);
            }
            //in case of control of type "Open's web page"
            else if (menu.Action != null && menu.Action.Equals("GenGenio.MenuPaginaWeb"))
            {
                var webpage = menu.WEBPAGE;
                if (webpage.StartsWith("GLOB_FIELD:"))
                {
                    try
                    {
                        var curUC = UserContext.Current;
                        var glob = CSGenioAglob.searchGlob(curUC.PersistentSupport, curUC.User);
                        webpage = (string)glob.returnValueField(webpage.Substring(11));
                    }
                    catch { webpage = "img/NotFound.jpg"; } // The GLOB has not yet been created.
                }

                //in case of external page
                if (webpage.Contains("http"))
                {
                    a.MergeAttribute("href", webpage);
                }
                //in case of external page without protocol
                else if (webpage.Contains("www."))
                {
                    a.MergeAttribute("href", "http://" + webpage);
                }
                //in case of document
                else
                {
                    a.MergeAttribute("href", urlHelper.Content("~/Content/" + webpage));
                }
                a.MergeAttribute("target", "_blank");
            }
            else if (menu.Action != null && (menu.Action.Equals("GenGenio.MenuSeleccaoUmLimite") || menu.Action.Equals("GenGenio.MenuSeleccaoEntreLimites")))
            {
                a.MergeAttribute("href", "javascript:void(0)");
                a.MergeAttribute("data-link", HttpUtility.JavaScriptStringEncode(urlHelper.Action(menu.Action_MVC, menu.Controller, new { module = module, newMenu = true })));
                a.MergeAttribute("data-menu-id", menu.Action_MVC);
                if (menu.Action.Equals("GenGenio.MenuSeleccaoUmLimite"))
                {
                    a.MergeAttribute("data-menu-su", "true");
                }
                else
                {
                    a.MergeAttribute("data-menu-se", "true");
                }
            }
            else if (menu.Type == "REPORT")
            {
                if(!menu.Preview)
                {
                    // The Crystal Repors without preview will invoke method by the Ajax request (PrintToPrinter)
                    var isAjaxReportRequest = menu.Mode == "CRY";
                    a.MergeAttribute("href", "javascript:void(0)");
                    a.MergeAttribute("onclick", string.Format("javascript:requestReport('{0}', {1});", HttpUtility.JavaScriptStringEncode(urlHelper.Action(menu.Action_MVC, menu.Controller, new { newMenu = true })), isAjaxReportRequest.ToString().ToLower()));
                }
                else
                {
                    var link = String.IsNullOrEmpty(menu.Action_MVC) ? "javascript:void(0)" : HttpUtility.JavaScriptStringEncode(urlHelper.Action(menu.Action_MVC, menu.Controller, new { module = module, newMenu = true }));
                    a.MergeAttribute("href", link);
                    a.MergeAttribute("target", "_blank");
                }
            }
            else
            {
                var link = String.IsNullOrEmpty(menu.Action_MVC) ?
                    "javascript:void(0)" :
                    HttpUtility.JavaScriptStringEncode(urlHelper.Action(menu.Action_MVC, menu.Controller, new { module = module, newMenu = true }));
                a.MergeAttribute("href", link);
            }

            //Add help
            if (!String.IsNullOrEmpty(menu.HELPTITLE))
            {
                a.MergeAttribute("title", Helpers.GetTextFromResources(menu.HELPTITLE));
            }

            // Menu Identifier, used for Bookmarks
            if(!String.IsNullOrEmpty(menu.Action_MVC)) {
                a.MergeAttribute("menu-module", module);
                a.MergeAttribute("menu-id", menu.ID);
            }

            a.InnerHtml = innerHtml;
            return new MvcHtmlString(a.ToString());
        }
        #endregion

        #region PasswordMeter
        /// <summary>
        /// Creates a password strength meter, attached to a certain password field.
        /// </summary>
        /// <param name="expression">Expression that returns the password property from the model </param>
        /// <returns></returns>
        public static MvcHtmlString PasswordMeter<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var propertyName = metadata.PropertyName;
            string content = $@"<div id='{propertyName}Strength'password-meter input-element='{propertyName}' class='span4 password-meter'>
                        <meter max='4' password-strength-meter value='0'></meter>
                        <p password-strength-text></p>
                    </div>";
            return new MvcHtmlString(content);
        }
        #endregion

		#region Menu List Search
		/// <summary>
        /// Creates menu with fields to search under search bar
        /// </summary>
        /// <param name="listId">Menu/Table ID</param>
        /// <param name="fields">Table fields</param>
        /// <param name="area">Table/Area</param>
        /// <param name="searchAllBtn">Include the search all fields button</param>
        /// <returns>HTML of search menu</returns>
		public static MvcHtmlString SearchFieldMenu(this HtmlHelper html, string listId, Dictionary<string, TableFilterField> fields, string area, bool searchAllBtn = true)
		{
			TagBuilder ul = new TagBuilder("div");
			ul.Attributes.Add("id", "q" + listId + "_srch_flds");
			//ul.Attributes.Add("tabindex", "-1"); // Having this breaks the scroll.
            ul.AddCssClass("dropdown-menu srch-fld-menu");
            ul.AddCssClass("search-field-menu");

			//Add item for searching each field
            foreach (var field in fields)
            {
                //These types are excluded from quick search because the value cannot fit the input type
                if (field.Value.Type == "enum" || field.Value.Type == "date" || field.Value.Type == "bool" || field.Value.DistinctValue)
                {
                    continue;
                }

                TagBuilder aBtn = CreateFilterItem(listId, area, field.Key, field.Value);

                ul.InnerHtml += aBtn;
            }

            if (searchAllBtn)
            {
                //Add item for searching all fields
                TagBuilder allBtn = new TagBuilder("a");
                allBtn.AddCssClass("dropdown-item");
                allBtn.Attributes.Add("href", "javascript:void(0);");
                allBtn.Attributes.Add("data-search-field-menu-elem", "show");
                allBtn.Attributes.Add("onclick", "UnfilteredSearch('" + listId + "');");
                allBtn.Attributes.Add("onblur", "HideSearchFieldMenuOnUnfocus('" + listId + "');");

                TagBuilder allBtnFld = new TagBuilder("span");
                allBtnFld.SetInnerText(Resources.Resources.TODOS_OS_CAMPOS47279);
                TagBuilder allBtnTxt = new TagBuilder("strong");
                allBtn.InnerHtml += Resources.Resources.PROCURAR15982 + " ";
                allBtn.InnerHtml += allBtnFld;
                allBtn.InnerHtml += " " + Resources.Resources.POR12741 + ": ";
                allBtn.InnerHtml += allBtnTxt;
                ul.InnerHtml += allBtn;
            }

            return new MvcHtmlString(ul.ToString());
		}

		private static TagBuilder CreateFilterItem(string listId, string baseArea, string fieldId, TableFilterField field)
        {
            TagBuilder aBtn = new TagBuilder("a");
            aBtn.AddCssClass("dropdown-item");
            aBtn.Attributes.Add("data-search-field-menu-elem", "show");
            aBtn.Attributes.Add("href", "javascript:void(0);");
            aBtn.Attributes.Add("onclick", "AddSearchFieldFilter('" + listId + "', '" + baseArea + "', '" + fieldId + "');");
            aBtn.Attributes.Add("onblur", "HideSearchFieldMenuOnUnfocus('" + listId + "');");

            TagBuilder aBtnFld = new TagBuilder("em");
            aBtnFld.SetInnerText(field.Title);

            TagBuilder aBtnTxt = new TagBuilder("strong");

            aBtn.InnerHtml += Resources.Resources.PESQUISAR34506 + " ";
            aBtn.InnerHtml += aBtnFld;
            aBtn.InnerHtml += " " + Resources.Resources.POR12741 + ": ";
            aBtn.InnerHtml += aBtnTxt;
            return aBtn;
        }


		/// <summary>
        /// Creates menu with search filters and controls to add search filters
        /// </summary>
        /// <param name="listId">Menu/Table ID</param>
        /// <returns>HTML of search filter menu</returns>
		public static MvcHtmlString SearchFilterMenu(this HtmlHelper html, string listId)
        {
            TagBuilder filterMenu = new TagBuilder("div");
            filterMenu.Attributes.Add("elem-identifier", "BtnGroup");
            filterMenu.Attributes.Add("id", "filter_menu_" + listId);
            filterMenu.AddCssClass("float-right");
            filterMenu.AddCssClass("b-btn-group");
            filterMenu.AddCssClass("filter-menu");

            TagBuilder filterBtn = new TagBuilder("button");
            filterBtn.Attributes.Add("data-toggle", "dropdown");
            filterBtn.Attributes.Add("aria-haspopup", "true");
            filterBtn.Attributes.Add("aria-expanded", "false");
            filterBtn.Attributes.Add("type", "button");
			filterBtn.Attributes.Add("title", Resources.Resources.FILTROS01340);
            filterBtn.Attributes.Add("onclick", "OnOpenFilterMenu('" + listId + "', searchFilterGroups);");
            filterBtn.AddCssClass("b-btn b-icon b-icon--secondary");
            filterBtn.AddCssClass("dropdown-toggle");

            TagBuilder iconFilters = new TagBuilder("i");
            iconFilters.AddCssClass("glyphicons glyphicons-adjust-alt e-icon search-filters-icon");
            filterBtn.InnerHtml += iconFilters;

            TagBuilder filterDrop = new TagBuilder("div");
			filterDrop.Attributes.Add("onclick", "StopProp(event);");
			filterDrop.Attributes.Add("tabindex", "-1");
            filterDrop.AddCssClass("dropdown-menu dropdown-menu-right");
            filterDrop.AddCssClass("dropdown__filter");

			TagBuilder filterListTitle = new TagBuilder("div");
            filterListTitle.Attributes.Add("data-search-filter-menu-elem", "filter-list-title");
			filterListTitle.AddCssClass("filter-list-title");
			filterListTitle.InnerHtml += Resources.Resources.FILTROS_ACTIVOS57698;

            TagBuilder filterList = new TagBuilder("div");
            filterList.Attributes.Add("data-search-filter-menu-elem", "filter-list");
            filterList.Attributes.Add("role", "menu");

            TagBuilder iconDrop = new TagBuilder("i");
            iconDrop.AddCssClass("glyphicons glyphicons-chevron-down e-icon filter-add-drop");

            TagBuilder filterAddBtn = new TagBuilder("button");
            //filterAddBtn.InnerHtml += iconFilters;
            //filterAddBtn.InnerHtml += Resources.Resources.ADICIONAR_FILTRO_PER12047;//Add Custom Filter
            filterAddBtn.InnerHtml += Resources.Resources.FILTRO_PERSONALIZADO30043;//Add Custom Filter
            filterAddBtn.InnerHtml += iconDrop;
            filterAddBtn.Attributes.Add("type", "button");
            filterAddBtn.Attributes.Add("onclick", "ToggleSearchFilterForm('" + listId + "');");
            filterAddBtn.AddCssClass("b-btn b-icon-text b-btn--full-width b-icon-text--secondary filter-cond-btn search-filter-toggle");

            TagBuilder filterForm = new TagBuilder("div");
            filterForm.Attributes.Add("data-search-filter-menu-elem", "filter-form");
            filterForm.AddCssClass("search-filter-form");

            TagBuilder filterConds = new TagBuilder("div");
            filterConds.Attributes.Add("data-search-filter-elem", "condition-group");
            filterConds.AddCssClass("search-filter-conds");

            TagBuilder iconAddCond = new TagBuilder("i");
            iconAddCond.AddCssClass("glyphicons glyphicons-plus-sign filter-add-cond");

            TagBuilder filterAddCondBtn = new TagBuilder("button");
            filterAddCondBtn.InnerHtml += Resources.Resources.ADICIONAR_CONDICAO25777;//Add Condition
            filterAddCondBtn.InnerHtml += iconAddCond;
            filterAddCondBtn.Attributes.Add("onclick", "AddSearchFilterConditionForm('" + listId + "', fields, operators);");
            filterAddCondBtn.Attributes.Add("type", "button");
            filterAddCondBtn.AddCssClass("b-btn b-icon-text b-btn--full-width b-icon-text--secondary filter-cond-btn filter-add-cond-btn");

            TagBuilder iconApplyFilter = new TagBuilder("i");
            iconApplyFilter.AddCssClass("glyphicons glyphicons-ok");

            TagBuilder filterApplyBtn = new TagBuilder("button");
            filterApplyBtn.InnerHtml += iconApplyFilter;
            filterApplyBtn.InnerHtml += Resources.Resources.APLICAR33981;//Apply
            filterApplyBtn.Attributes.Add("onclick", "AddSearchFilter('" + listId + "', searchFilterGroups);ClearSearchFilterForm('" + listId + "');");
            filterApplyBtn.Attributes.Add("type", "button");
            filterApplyBtn.Attributes.Add("data-search-filter-menu-elem", "apply-filter");
            filterApplyBtn.AddCssClass("b-btn b-icon-text b-btn--full-width b-icon-text--primary filter-apply-btn");

            filterForm.InnerHtml += filterConds;
            filterForm.InnerHtml += filterAddCondBtn;
            filterForm.InnerHtml += filterApplyBtn;
            filterDrop.InnerHtml += filterListTitle;
            filterDrop.InnerHtml += filterList;
            filterDrop.InnerHtml += filterAddBtn;
            filterDrop.InnerHtml += filterForm;
            filterMenu.InnerHtml += filterBtn;
            filterMenu.InnerHtml += filterDrop;

            return new MvcHtmlString(filterMenu.ToString());
        }
		#endregion

        #region Elasticsearch
        /// <summary>
        /// Create search filter button to popup advanced search window
        /// </summary>
        /// <param name="id">The ID</param>
        /// <returns>HTML of advanced search filter button</returns>
        public static MvcHtmlString SearchFilterBtnPopUp(this HtmlHelper html, string id, string dataTable)
        {
            TagBuilder advSearchDiv1 = new TagBuilder("div");
            advSearchDiv1.Attributes.Add("id", "btn_adv_div1_" + id);
            advSearchDiv1.AddCssClass("col-auto float-right");
            advSearchDiv1.Attributes.Add("style", "padding: 0; padding-right: 15px");

            TagBuilder advSearchDiv2 = new TagBuilder("div");
            advSearchDiv2.Attributes.Add("id", "btn_adv_div2_" + id);
            advSearchDiv2.AddCssClass("b-btn-group float-right");


            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);

            TagBuilder filterBtn = new TagBuilder("button");
            filterBtn.AddCssClass("b-btn b-icon b-icon--secondary");
            filterBtn.Attributes.Add("type", "button");
            filterBtn.Attributes.Add("data-modal-form", "ESAdvFilter");
            filterBtn.Attributes.Add("data-modal-id", "ESAdvFilter-edit-modal");
            filterBtn.Attributes.Add("data-table", dataTable);
            filterBtn.Attributes.Add("data-modal-url", urlHelper.Action("AdvancedElasticsearchFilterView", dataTable));
            filterBtn.Attributes.Add("title", Resources.Resources.FILTROS01340);

            TagBuilder iconBtn = new TagBuilder("i");
            iconBtn.AddCssClass("glyphicons glyphicons-list e-icon");
            filterBtn.InnerHtml += iconBtn;
            advSearchDiv2.InnerHtml += filterBtn;
            advSearchDiv1.InnerHtml += advSearchDiv2;

            return new MvcHtmlString(advSearchDiv1.ToString());
        }
        #endregion

    }

    #region LabelExtensions

    public static class LabelExtensions
    {
        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes, bool editionMode)
        {
            return LabelHelper(html, ModelMetadata.FromLambdaExpression(expression, html.ViewData), ExpressionHelper.GetExpressionText(expression), String.Empty, htmlAttributes, editionMode, false);
        }

        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string extra, object htmlAttributes, bool editionMode)
        {
            return LabelHelper(html, ModelMetadata.FromLambdaExpression(expression, html.ViewData), ExpressionHelper.GetExpressionText(expression), extra, htmlAttributes, editionMode, false);
        }

        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes, bool editionMode, bool isRequired)
        {
            return LabelHelper(html, ModelMetadata.FromLambdaExpression(expression, html.ViewData), ExpressionHelper.GetExpressionText(expression), String.Empty, htmlAttributes, editionMode, isRequired);
        }

        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string extra, object htmlAttributes, bool editionMode, bool isRequired)
        {
            return LabelHelper(html, ModelMetadata.FromLambdaExpression(expression, html.ViewData), ExpressionHelper.GetExpressionText(expression), extra, htmlAttributes, editionMode, isRequired);
        }

        private static MvcHtmlString LabelHelper(HtmlHelper html, ModelMetadata metadata, string htmlFieldName, string extra, object htmlAttributes, bool editionMode, bool isRequired)
        {
            string resolvedLabelText = metadata.DisplayName;

            RouteValueDictionary dic = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            // For html5 compliance. Label should exist only inside a <form>
            TagBuilder tag;
            if (editionMode)
			{
                tag = new TagBuilder("label");
                if (!string.IsNullOrEmpty(resolvedLabelText))
                {
                    tag.Attributes.Add("for", TagBuilder.CreateSanitizedId(html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)));
                    if (isRequired && !(metadata.Model is bool || metadata.AdditionalValues.ContainsKey("ConditionalBinder")))
                        tag.Attributes.Add("data-val-required", "true");
                }
            }
            else
                tag = new TagBuilder("div");

            tag.MergeAttributes(dic);
            if (!string.IsNullOrEmpty(resolvedLabelText))
                tag.SetInnerText(resolvedLabelText + extra);
            else
                tag.SetInnerText(Resources.Resources.VAZIO58398);
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

		public static MvcHtmlString PasswordEditFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlProperties = null)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string value;
            TagBuilder div = null;
            RouteValueDictionary vals = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlProperties);

            if (metadata.Model == null)
                value = "";
            else
                value = metadata.Model.ToString();

            MvcHtmlString input = null;
            if (!string.IsNullOrEmpty(value))
            {
                // MH (17/01/2017) - Depois da alteração da submissão dos forms ser por ajax, os controlos de data enviam to servidor o Qvalue da data no format universal,
                //e se acontecer algum erro no servidor ao re-renderizar a pagina, aparece o Qvalue que vem do cliente e não o que nós passamos nos parametros do InputExtensions.TextBox
                if (html.ViewData.ModelState.ContainsKey(metadata.PropertyName))
                    html.ViewData.ModelState.SetModelValue(metadata.PropertyName, new ValueProviderResult(value, String.Empty, CultureInfo.InvariantCulture));
                input = InputExtensions.Password(html, metadata.PropertyName, value, vals);
            }
            else
                input = InputExtensions.Password(html, metadata.PropertyName, value, vals);

            div = new TagBuilder("div");
            div.AddCssClass("i-input-group");

            div.InnerHtml += input;

            if (GenioMVC.LayoutConfig.config.showPasswordToggle)
            {
				TagBuilder grpdiv = new TagBuilder("div");
				grpdiv.AddCssClass("i-input-group--right");

				TagBuilder span = new TagBuilder("span");
				span.AddCssClass("i-input-group__tag");

				TagBuilder icon = new TagBuilder("i");
				icon.AddCssClass("glyphicons glyphicons-eye-open passwordtoggle");
				icon.Attributes.Add("id", "passwordtoggle");

				if (vals.ContainsKey("data-identifier"))
					icon.Attributes.Add("data-identifier", vals["data-identifier"].ToString());

				span.InnerHtml += icon;

				grpdiv.InnerHtml += span;
				div.InnerHtml += grpdiv;
			}

            return new MvcHtmlString(div.ToString());
        }

    }

    #endregion

    #region Generic Helpers

    public static class Helpers
    {
        /// <summary>
        /// Obtains the languaged matched text according to the resources
        /// </summary>
        /// <param name="str">The id from the resource</param>
        /// <returns>The language aware text</returns>
        public static string GetTextFromResources(string str)
        {
		    if (string.IsNullOrEmpty(str))
                return "";
            return Resources.Resources.ResourceManager.GetString(str);
        }

        public static MvcHtmlString AuditButton()
        {
            string mod = UserContext.Current.User.CurrentModule;
            if (!UserContext.Current.User.IsAdmin(mod) || Configuration.AuditTag.AuditInterface != true)
                return MvcHtmlString.Create("");

            TagBuilder button = new TagBuilder("button");
            button.AddCssClass("btn btn-info pull-right showAudit");
            button.Attributes.Add("name", "showAudit");
            button.Attributes.Add("data-end-pers", "true");
            button.Attributes.Add("elem-identifier", "ShowAudit");
            button.InnerHtml = Resources.Resources.AUDITORIA_DO_SISTEMA08460;

            return MvcHtmlString.Create(button.ToString());
        }

		/// <summary>
        /// Obtains the correct language based on CurrentUICulture
        /// </summary>
        /// <returns></returns>
        public static string GetSupportedLanguageTinymce()
        {
            string language = string.Empty;
            var lang = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
            switch (lang)
            {
                case "pt-PT":
                case "fr-FR":
                case "zh-CN":
                case "zh-TW":
                    language = lang;
                    break;
                case "ar-MA":
                    language = "ar";
                    break;
                case "es-ES":
                    language = "es";
                    break;
                case "de-DE":
                    language = "de";
                    break;
                case "da-DK":
                    language = "da";
                    break;
                case "pl-PL":
                    language = "pl";
                    break;
                case "ca-ES":
                    language = "ca";
                    break;
                default:
                    language = "en";
                    break;
            }
            return language.Replace("-", "_");
        }

        public static IList<SelectListItem> ToSelectList<T>(this IEnumerable<T> itemsToMap, Expression<Func<T, object>> textProperty, Func<T, object> valueProperty, Predicate<T> isSelected)
        {
            var result = new List<SelectListItem>();

            foreach (var item in itemsToMap)
            {
                object prop_value = textProperty.Compile()(item);
                var propertyName = String.Empty;

                propertyName = HtmlHelpers.FindFirstPropetyInfoMember(textProperty).Name;

                if (!String.IsNullOrEmpty(propertyName))
                {
                    Type modelType = item.GetType();
                    PropertyInfo fieldProperty = modelType.GetProperty(propertyName);

                    /*Type dbArrayType = typeof(GenioMVC.Helpers.DataArray);
                    var hasDataArrayAttr = modelType.GetMember(propertyName)[0].GetCustomAttributes(dbArrayType, true);
                    if (hasDataArrayAttr.Count() > 0)
                    {
                        DataArray attr = (DataArray)hasDataArrayAttr.First();
                        if (!String.IsNullOrEmpty(prop_value as string))
                            prop_value = HtmlHelpers.FormatArray(textProperty, item);
                    }
                    else*/ if (fieldProperty.PropertyType == typeof(DateTime?))
                        prop_value = HtmlHelpers.FormatDate(textProperty, item);
                    //TODO: Add FormatCurrency
                }

                result.Add(new SelectListItem
                {
                    Value = Convert.ToString(valueProperty(item)),
                    Text = Convert.ToString(prop_value),
                    Selected = isSelected(item)
                });
            }
            return result;
        }

        public static HtmlString GetMultiFormId(string rowId)
        {
            return new HtmlString((rowId ?? "emptyRowId").Replace('-', '_').Replace(' ', '_'));
        }

        public static HtmlString FormModeActionName(string formName, FormMode formMode)
        {
            var mode = "";
            switch (formMode)
            {
                case FormMode.Show:
                    mode = "Show";
                    break;
                case FormMode.Edit:
                    mode = "Edit";
                    break;
                case FormMode.New:
                    mode = "New";
                    break;
                case FormMode.Delete:
                    mode = "Delete";
                    break;
                case FormMode.Duplicate:
                    mode = "Duplicate";
                    break;
            }
            return new HtmlString(string.Format("{0}_{1}", formName, mode));
        }

        public static bool IsEditableForm(FormMode formMode)
        {
            switch (formMode)
            {
                case FormMode.None:
                case FormMode.FullTextSearch:
                case FormMode.Show:
                case FormMode.Delete:
                case FormMode.ConsultationList:
                    return false;
                case FormMode.List:
                case FormMode.New:
                case FormMode.Edit:
                case FormMode.Duplicate:
                    return true;
                default:
                    return false;
            }
        }

		public static string GetClientIpAddress(this HttpRequest request)
		{
			return GetClientIpAddress(request?.ServerVariables);
		}

		public static string GetClientIpAddress(this HttpRequestBase request)
		{
			return GetClientIpAddress(request?.ServerVariables);
		}

		/// <summary>
		/// Get the client ip address from web server variables
		/// </summary>
		/// <param name="serverVariables">HttpRequest.ServerVariables</param>
		/// <returns></returns>
		private static string GetClientIpAddress(NameValueCollection serverVariables)
		{
			//This is better than Request.UserHostAddress() because of proxy and stuff
			string ip = serverVariables["HTTP_X_FORWARDED_FOR"];
			if (!String.IsNullOrEmpty(ip))
			{
				string[] addresses = ip.Split(',');
				if (addresses.Length != 0)
					return addresses[0];
			}

			return serverVariables["REMOTE_ADDR"];
		}

        /// <summary>
        /// Convert a collection to route values
        /// </summary>
        /// <param name="collection">Collection</param>
        /// <param name="obj"></param>
        /// <returns>Route Value Dictionary</returns>
        public static RouteValueDictionary ToRouteValues(NameValueCollection collection, object obj = null)
        {
            RouteValueDictionary routeValueDictionary = new RouteValueDictionary(obj);

            if (collection != null)
            {
                foreach (string key in collection)
                {
                    if(key != null && !routeValueDictionary.ContainsKey(key))
                        routeValueDictionary.Add(key, collection[key]);
                }
            }

            return routeValueDictionary;
        }

        /// <summary>
        /// The list of available column aggregation types
        /// </summary>
        public enum ColumnAggregationType
        {
            NONE,
            SUM_SEL
        }

        /// <summary>
        /// Sanitizes HTML content.
        /// </summary>
        /// <param name="plainText">The HTML content to be sanitized.</param>
        /// <param name="isDocument">Indicates whether the content is a complete HTML document.</param>
        /// <returns>Sanitized HTML content.</returns>
        public static string SanitizeHTML(string plainText, bool isDocument)
        {
            return HtmlSanitizerHelper.SanitizeHTML(plainText, isDocument);
        }

		/// <summary>
		/// Generates a ticket that can be used by the client-side to access the specified resource.
		/// </summary>
		/// <param name="user">The user for whom this ticket is created.</param>
		/// <param name="table">The table where the resource is located.</param>
		/// <param name="fieldName">The name of the field in the table that contains the resource.</param>
		/// <param name="primaryKeyField">The primary key field name of the table that contains resource.</param>
		/// <param name="keyValue">The primary key value of the record associated with the resource.</param>
		/// <param name="resourceName">Optional. The name of the resource.</param>
		/// <returns>A ticket that provide access to the specified resource in the specified table field.</returns>
		public static string GetFileTicket(User user, string table, string fieldName, string primaryKeyField, string keyValue, string resourceName = null)
		{
			ResourceQuery versionResource = new ResourceQuery(resourceName, table, fieldName, primaryKeyField, keyValue);
			return QResources.CreateTicketEncryptedBase64(user.Name, user.Location, versionResource);
		}
    }

    #endregion
}
