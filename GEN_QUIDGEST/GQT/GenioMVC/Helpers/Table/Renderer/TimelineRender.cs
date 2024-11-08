using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Models.Navigation;
using System.Data;
using System.Globalization;

namespace GenioMVC.Helpers.Table.Renderer
{
    public class TimelineRender<TModel> : TableRenderer<TModel> where TModel : class
    {
        new private Timeline<TModel> Builder { get; set; }

        public TimelineRender(Table<TModel> builder)
            : base(builder)
        {
            this.Builder = builder as Timeline<TModel>;
        }

        public string CreateCircle(DateTime date, int id, int position)
        {
            CultureInfo cul = CultureInfo.CurrentCulture;

            TagBuilder circle = new TagBuilder("div");
            circle.AddCssClass("c-timeline_circle");
            circle.Attributes.Add("id", "circle" + id);
            circle.Attributes.Add("data", date.ToString(CSGenio.framework.Configuration.DateFormat.Date));
            circle.Attributes.Add("year", date.Year.ToString());
            circle.Attributes.Add("week", cul.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday).ToString() +"-"+ date.Year.ToString());
            circle.Attributes.Add("month", date.Month.ToString() + "/" +date.Year.ToString());
            circle.Attributes.Add("style", "left:" + position + "%;");
            circle.Attributes.Add("title", date.ToString(CSGenio.framework.Configuration.DateFormat.Date));
            circle.Attributes.Add("elem-identifier", "timeline-circle");

            return circle.ToString();
        }

        public string HorizontalTimelineToHtml()
        {
            TagBuilder horizontalContainer = new TagBuilder("div");
            horizontalContainer.Attributes.Add("id", "lineCont");
            horizontalContainer.AddCssClass("c-timeline_horizontal");

            TagBuilder line = new TagBuilder("div");
            line.AddCssClass("c-timeline_horizontal_line");
            line.Attributes.Add("id", "line");

            TagBuilder toogle = new TagBuilder("div");            

            CultureInfo cul = CultureInfo.CurrentCulture;

            if (Builder.Data.Count() >= 2)
            {
                Models.TimelineItem last = Builder.Data.Last() as Models.TimelineItem;
                DateTime lastDate = Convert.ToDateTime(last.Data);
                string scale = last.Escala;

                if (scale.Equals("un"))
                    return "";

                DateTime firstDateFilter = lastDate.AddYears(-1);

                var timeLine = Builder.Data.Select(p => p as Models.TimelineItem).Where(t => Convert.ToDateTime(t.Data) >= firstDateFilter);
                switch (scale)
                {
                    case "dd":
                        {
                            timeLine = timeLine.GroupBy(x => Convert.ToDateTime(x.Data).ToString("ddMMYYyy")).Select(f => f.FirstOrDefault());
                            break;
                        }
                    case "yy":
                        {
                            timeLine = timeLine.GroupBy(x => Convert.ToDateTime(x.Data).Year).Select(f => f.FirstOrDefault());
                            break;
                        }
                    case "mm":
                        {
                            timeLine = timeLine.GroupBy(x => Convert.ToDateTime(x.Data).Month.ToString() + Convert.ToDateTime(x.Data).Year.ToString()).Select(f => f.FirstOrDefault());
                            break;
                        }
                    case "ww":
                        {
                            timeLine = timeLine.GroupBy(x => cul.Calendar.GetWeekOfYear(Convert.ToDateTime(x.Data), CalendarWeekRule.FirstDay, DayOfWeek.Monday) + Convert.ToDateTime(x.Data).Year).Select(f => f.FirstOrDefault());
                            break;
                        }
                    default:
                        break;
                }

                if (timeLine.Count() >= 2)
                {
                    Models.TimelineItem first = timeLine.First();
                    DateTime firstDate = Convert.ToDateTime(first.Data);

                    var lastInt = ((lastDate.Year - firstDate.Year) * 365) + ((lastDate.Month - firstDate.Month) * 30) + (lastDate.Day - firstDate.Day);

                    //start circle
                    line.InnerHtml += CreateCircle(firstDate, 0, 0);

                    for (int i = 1; i < timeLine.Count() - 1; i++)
                    {
                        Models.TimelineItem tItem = timeLine.ElementAt(i);
                        DateTime date = Convert.ToDateTime(tItem.Data);
                        double position = getCirclePosiction(lastInt, firstDate, date, tItem.Escala);
                        line.InnerHtml += CreateCircle(date, i, Convert.ToInt32(Math.Ceiling(position * 100)));
                    }

                    //End circle
                    line.InnerHtml += CreateCircle(lastDate, Builder.Data.Count(), 99);
                }
            }

            horizontalContainer.InnerHtml += line;
            //horizontalContainer.InnerHtml += toogle;

            return horizontalContainer.ToString();
        }

        public double getCirclePosiction(int lastInt,DateTime dateBegin, DateTime dateEnd, string scale)
        {
            var thisInt = ((dateEnd.Year - dateBegin.Year) * 365) + ((dateEnd.Month - dateBegin.Month) * 30) + (dateEnd.Day - dateBegin.Day);
            switch (scale)
            {
                case "yy":
                    {
                        thisInt = ((dateEnd.Year - dateBegin.Year) * 365);
                        break;
                    }
                case "mm":
                    {
                        thisInt = ((dateEnd.Year - dateBegin.Year) * 365) + ((dateEnd.Month - dateBegin.Month) * 30);
                        break;
                    }
                case "ww":
                    {
                        thisInt = ((dateEnd.Year - dateBegin.Year) * 365) + ((dateEnd.Month - dateBegin.Month) * 30);
                        break;
                    }

                default:
                    break;
            }
            double relevantint = Convert.ToDouble(thisInt) / Convert.ToDouble(lastInt);
            return relevantint;
        }

        /// <summary>
        /// Timeline html render function 
        /// </summary>
        /// <returns></returns>
        public MvcHtmlString ToHtml()
        {           
            CultureInfo cul = CultureInfo.CurrentCulture;
            string scale = "";
            TagBuilder div_Timeline = new TagBuilder("div");            
            div_Timeline.InnerHtml += HorizontalTimelineToHtml();
            
            TagBuilder div_container = new TagBuilder("div");
            div_container.AddCssClass("c-timeline--alternate c-timeline__container");
            div_container.Attributes.Add("elem-identifier", "timeline");

            if(Builder.Data.Count() > 0)
            {
                Models.TimelineItem firstItem = Builder.Data.First() as Models.TimelineItem;
                div_container.Attributes.Add("scale", firstItem.Escala);
                scale = firstItem.Escala;
            }
            
            //Iterate all row
            foreach (Models.TimelineItem tlItem in Builder.Data.Select(p=> p as Models.TimelineItem))
            {
                //Models.TimelineItem tlItem = model as Models.TimelineItem;

                if (CSGenio.business.GlobalFunctions.emptyD(tlItem.Data) == 0 && !string.IsNullOrEmpty(tlItem.Texto))
                {
                    TagBuilder item = new TagBuilder("div");
                    item.AddCssClass("c-timeline__item");
                    item.Attributes.Add("elem-identifier", "timeline-item");

                    TagBuilder icon = new TagBuilder("div");
                    icon.AddCssClass("c-timeline__item-section-icon");

                    /* if (!string.IsNullOrEmpty(tlItem.Background))
                        icon.Attributes.Add("style", "background-color:" + tlItem.Background + ";border-color:" + tlItem.Background);
                    */
                    TagBuilder i = new TagBuilder("i");
                    i.AddCssClass(tlItem.Icon);
                    icon.InnerHtml += i;
                    item.InnerHtml += icon;

                    TagBuilder item_content = new TagBuilder("div");
                    item_content.AddCssClass("c-timeline__item-content");

                    TagBuilder content_header = new TagBuilder("div");
                    content_header.AddCssClass("c-timeline__item-header");

                    TagBuilder span_date = new TagBuilder("span");
                    span_date.AddCssClass("c-timeline__item-datetime e-badge e-badge--dark");
                    if (!tlItem.Escala.Equals("un"))
                    {
                        if (tlItem.Data is DateTime)
                        {
                            DateTime data = Convert.ToDateTime(tlItem.Data);
                            span_date.SetInnerText(data.ToString(CSGenio.framework.Configuration.DateFormat.Date));
                            item.Attributes.Add("data", data.ToString(CSGenio.framework.Configuration.DateFormat.Date));
                            item.Attributes.Add("year", data.Year.ToString());
                            item.Attributes.Add("week", cul.Calendar.GetWeekOfYear(data, CalendarWeekRule.FirstDay, DayOfWeek.Monday).ToString() + "-" + data.Year.ToString());
                            item.Attributes.Add("month", data.Month.ToString()+ "/" + data.Year.ToString());
                        }
                    }
                    else
                    {
                        span_date.SetInnerText(tlItem.Data.ToString());
                        item.Attributes.Add("data", tlItem.Data.ToString());
                    }   

                    content_header.InnerHtml += span_date;

                    TagBuilder span_title = new TagBuilder("span");
                    span_title.AddCssClass("c-timeline__item-title");
                    span_title.SetInnerText(tlItem.Texto);
                    content_header.InnerHtml += span_title;

                    TagBuilder content_text = new TagBuilder("div");
                    content_text.AddCssClass("c-timeline__item-text");

                    //Iterate all row fields (not image kind)
                    foreach (var col in tlItem.Columns.OrderBy(p => p.Order))
                    {
                        if (!string.IsNullOrEmpty(col.Valor))
                        {
                            TagBuilder spn_Text = new TagBuilder("span");
                            spn_Text.AddCssClass("c-timeline__item-field");

                            if (!string.IsNullOrEmpty(col.Icone))
                            {
                                TagBuilder icon_fld = new TagBuilder("i");
                                icon_fld.AddCssClass(col.Icone);
                                icon_fld.AddCssClass("e-icon mr-1");
                                spn_Text.InnerHtml += icon_fld;
                            }

                            if (!string.IsNullOrEmpty(col.Titulo))
                            {
                                TagBuilder strong = new TagBuilder("strong");
                                strong.SetInnerText(col.Titulo + ": ");
                                spn_Text.InnerHtml += strong;
                            }

                            spn_Text.InnerHtml += col.Valor + "<br>";
                            content_text.InnerHtml += spn_Text;
                        }
                    }

                    if (tlItem.ImagesColumns.Count > 0)
                    {
                        TagBuilder image_fields = new TagBuilder("div");
                        image_fields.AddCssClass("mt-1 mb-1");

                        //Iterate all image field
                        foreach (var img in tlItem.ImagesColumns)
                        {
                            if (img.Image != null && img.Image.Length > 0)
                                image_fields.InnerHtml += HtmlHelpers.ImageMagnifierZoom(null, img.Image, null, img.Url);
                        }
                        content_text.InnerHtml += image_fields;
                    }

                    if (tlItem.Url != null)
                    {
                        TagBuilder content_button = new TagBuilder("a");
                        content_button.AddCssClass("b-icon b-icon--small b-icon--primary mt-1");
                        content_button.Attributes.Add("href", RenderItemActionDescriptor(tlItem.Url));
                        if (tlItem.IsPopupForm)
                            content_button.Attributes.Add("data-modal-form", "true");

                        TagBuilder icon_cnt_button = new TagBuilder("i");
                        icon_cnt_button.AddCssClass("glyphicons glyphicons-option-horizontal e-icon");
                        content_button.InnerHtml += icon_cnt_button;

                        content_text.InnerHtml += content_button;
                    }

                    item_content.InnerHtml += content_header;
                    item_content.InnerHtml += content_text;
                    item.InnerHtml += item_content;

                    div_container.InnerHtml += item;
                }
            }
            
            if( !string.IsNullOrEmpty(scale) && !scale.Equals("un") && Builder.Data.Count() >= 2)
            {
                //Acoordion
                TagBuilder acordBody = new TagBuilder("div");
                acordBody.AddCssClass("collapse");
                acordBody.Attributes.Add("elem-identifier", "AccordionBody");
                acordBody.Attributes.Add("id", "timelineAccordion");

                TagBuilder acordPanel = new TagBuilder("div");
                acordPanel.AddCssClass("c-accordion__panel-body");
                acordPanel.Attributes.Add("elem-identifier", "AccordionInner");

                acordPanel.InnerHtml += div_container;
                acordBody.InnerHtml += acordPanel;
                div_Timeline.InnerHtml += acordBody;
            }            
            else
            {
                div_Timeline.InnerHtml += div_container;
            }
            
            return new MvcHtmlString(div_Timeline.ToString());
        }

        private string RenderItemActionDescriptor(ItemActionDescriptor url)
        {
            return new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext).Action(url.Action, url.Resource , new { id = url.Id, nav = url.Nav });
        }
    }
}
