using CSGenio.framework;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web.Hosting;
using System.Web.Mvc;

namespace GenioMVC.Helpers
{
    public static class FullCalendarHelper
    {
        public static FullCalendarBuilder<TModel> FullCalendar<TModel>(this HtmlHelper helper, bool edit = false, bool canPage = true, bool canSort = true, bool countRec = false) where TModel : class
        {
            Table.Builder.Table<TModel> builder = new Table.Builder.Table<TModel>(helper, Table.Properties.TableType.SimpleTable, edit, canPage, canSort, countRec);
            Table.Builder.TableList<TModel> tableList = new Table.Builder.TableList<TModel>(builder, false);
            return new FullCalendarBuilder<TModel>(tableList, false);
        }

        private static ConcurrentDictionary<string, KeyValuePair<string, string>> cache_FullCallendarLocals = new ConcurrentDictionary<string, KeyValuePair<string, string>>();
        /// <summary>
        /// URL of the full calendar language
        /// </summary>
        public static KeyValuePair<string, string> FullCallendarLocale
        {
            get
            {
                // Check if exists in cache
                if (!cache_FullCallendarLocals.TryGetValue(CultureInfo.CurrentCulture.Name, out KeyValuePair<string, string> GlobalizeCulture))
                {
                    // Determine culture - GUI culture for preference, user selected culture as fallback
                    var currentCulture = CultureInfo.CurrentCulture;
                    // Default regionalisation to use
                    var cultureToUse = "en";
                    const string fullCallendarLocaleFilePattern = "~/Scripts/FullCalendar/packages/core/locales/{0}.js";

                    // Try to pick a more appropriate regionalisation
                    if (File.Exists(HostingEnvironment.MapPath(string.Format(fullCallendarLocaleFilePattern, currentCulture.Name)))) // First try for a globalize.culture.en-GB.js style file
                        cultureToUse = currentCulture.Name;
                    else if (File.Exists(HostingEnvironment.MapPath(string.Format(fullCallendarLocaleFilePattern, currentCulture.TwoLetterISOLanguageName)))) // That failed; now try for a globalize.culture.en.js style file
                        cultureToUse = currentCulture.TwoLetterISOLanguageName;

                    GlobalizeCulture = new KeyValuePair<string, string>(cultureToUse, string.Format(fullCallendarLocaleFilePattern, cultureToUse));

                    cache_FullCallendarLocals.TryAdd(currentCulture.Name, GlobalizeCulture);
                }
                return GlobalizeCulture;
            }
        }
    }

    public class FullCalendarBuilder<TModel> : Table.TableListBuilder<TModel> where TModel : class
    {
        internal FullCalendarBuilder(Table.Builder.Table<TModel> builder, bool hasFilters) : base(builder, hasFilters)
        {
            ///<summary>
            /// Needed manual insertion of permissions because it would loose it when casted to TableList
            ///</summary>
            var permissions = (builder as Table.Builder.TableList<TModel>).Permissions;
            this.Builder.SetPermissions(permissions.CanView, permissions.CanInsert, permissions.CanEdit, permissions.CanDuplicate, permissions.CanDelete);
            var form = (builder as Table.Builder.TableList<TModel>).Form;
            this.Builder.SetForm(form.HelpForm, form.OpenInPopup, form.RepeatInsertion);
        }

        public MvcHtmlString ToFullCalendarHtml()
        {
            return new FullCalendarRenderer<TModel>(this.Builder).ToHtml();
        }
    }

    public class FullCalendarRenderer<TModel> : Table.Renderer.TableListRenderer<TModel> where TModel : class
    {
        /// <summary>
        /// Structure of the events
        /// </summary>
        public class CalendarEvent
        {
            public string EventID { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime Start { get; set; }
            public Nullable<DateTime> End { get; set; }
            public string ThemeColor { get; set; }
            public bool IsFullDay { get; set; }
            public string resourceId { get; set; }
            public bool IsBackground { get; internal set; }
        }

        public class Resource
        {
            public string id { get; set; }
            public string title { get; set; }
            public string columnLabel { get; set; }
            public string group { get; set; }
            public string groupLabel { get; set; }
            public List<Child> children { get; set; }
        }

        public class Child
        {
            public string id { get; set; }
            public string title { get; set; }
        }

        internal FullCalendarRenderer(Table.Builder.Table<TModel> builder) : base(builder)
        {
            this.Builder = builder as Table.Builder.TableList<TModel>;
        }

        /// <summary>
        /// Creates the Script with the configuration variable for the calendar renderization
        /// </summary>
        /// <returns></returns>
        protected override MvcHtmlString GenerateScripts()
        {
            StringBuilder scriptBase = new StringBuilder();

            ///<summary>
            /// Creation of variable to store the configurations for the calendar
            ///</summary>
            scriptBase.AppendLine("var calendarOptions_" + Builder.ajaxUpdateContainerId + "= {");
            scriptBase.AppendLine("license: '" + GetLicense() + "',");
            scriptBase.AppendLine("data:" + GetEvents() + ",");
            scriptBase.AppendLine("resources:" + GetResources() + ",");
            scriptBase.AppendLine("linkReload: '" + System.Web.HttpUtility.JavaScriptStringEncode(Builder.requestsLink) + "',");
            scriptBase.AppendLine("IsModal:" + (Builder.Form.OpenInPopup ? "true," : "false,"));
            scriptBase.AppendLine(string.Format("locale: '{0}',", FullCalendarHelper.FullCallendarLocale.Key));

            if ((Builder as Table.Builder.TableList<TModel>).IsInEditMode)
            {
                if (Builder.HasInsertAction())
					scriptBase.AppendLine("newLink: '" + (new UrlHelper(Builder.HtmlHelper.ViewContext.RequestContext)).Action(Builder.Form.HelpForm + "_Calendario_New") + "',");
                    
                if (Builder.HasEditAction())
                {
                    scriptBase.AppendLine("editLink: '" + CreateLink("_Edit") + "',");
                    scriptBase.AppendLine("dragdroplink: '" + (new UrlHelper(Builder.HtmlHelper.ViewContext.RequestContext)).Action(Builder.Form.HelpForm + "_Calendario") + "',");
                    scriptBase.AppendLine("editLang: '" + Table.Utils.TableString.Edit.ToString() + "',");
                    ///<summary>
                    ///Editable field is true so drag and drop can be used, if false the events cant move from their place
                    ///</summary>
                    scriptBase.AppendLine("editable: true,");
                }
                if (Builder.HasDuplicateAction())
                {
                    scriptBase.AppendLine("duplicateLink: '" + (new UrlHelper(Builder.HtmlHelper.ViewContext.RequestContext)).Action(Builder.Form.HelpForm + "_Calendario_Duplicate") + "',");
                    scriptBase.AppendLine("duplicateLang: '" + Table.Utils.TableString.Duplicate.ToString() + "',");
                }

                if (Builder.HasViewAction())
                {
                    scriptBase.AppendLine("viewLink: '" + CreateLink("_Show") + "',");
                    scriptBase.AppendLine("viewLang: '" + Table.Utils.TableString.View.ToString() + "',");
                }

                if (Builder.HasDeleteAction())
                {
                    scriptBase.AppendLine("deleteLink: '" + CreateLink("_Delete") + "',");
                    scriptBase.AppendLine("deleteLang: '" + Table.Utils.TableString.Delete.ToString() + "',");
                }
            }
            else
            {
                scriptBase.AppendLine("editable: false,");
            }

			//Passing date fields that define each event into Calendar, so it can later validate if they are within calendar range
			scriptBase.AppendLine("startDateField: '"+ Builder.TableColumns[3].ColumnField + "',");		
            scriptBase.AppendLine("endDateField: '" + Builder.TableColumns[4].ColumnField + "',");
			scriptBase.AppendLine("allDayField: '" + Builder.TableColumns[6].ColumnField + "',");

		   //Variables to set a valid range for calendar, 2nd and 3rd last variables defined (zzstate is always the last one)
            bool has_Range = (!Builder.TableColumns[Builder.TableColumns.Count - 2].ColumnVisible && Builder.TableColumns[Builder.TableColumns.Count - 2].DataType == Table.Columns.ColumnDataType.Date);
            if (has_Range)
            {
                if (Builder.TableColumns[Builder.TableColumns.Count - 2] != null)
                    scriptBase.AppendLine("validRangeEnd: '" + Builder.TableColumns[Builder.TableColumns.Count - 2].ColumnField + "',");
                if (Builder.TableColumns[Builder.TableColumns.Count - 3] != null)
                    scriptBase.AppendLine("validRangeStart: '" + Builder.TableColumns[Builder.TableColumns.Count - 3].ColumnField + "',");
            }

            //Variables needed to be adjusted on event start and end dates when allDay flag is on and theres also variables to control start time and end time
            int selectedDateIndex = Builder.TableColumns.Count - (has_Range ? 6 : 4); //last one is ZZstate; tried to get it from the 3 fields defined in DBEdit: date selected by user; Start time; end time;  
            bool has_Times = (!Builder.TableColumns[selectedDateIndex].ColumnVisible && Builder.TableColumns[selectedDateIndex].DataType == Table.Columns.ColumnDataType.Date);
            
            if (has_Times)
            {
                if (Builder.TableColumns[selectedDateIndex + 1] != null)
                    scriptBase.AppendLine("startTimeField: '" + Builder.TableColumns[selectedDateIndex + 1].ColumnField + "',");
                if (Builder.TableColumns[selectedDateIndex + 2] != null)
                    scriptBase.AppendLine("endTimeField: '" + Builder.TableColumns[selectedDateIndex + 2].ColumnField + "',");
            }

			
            scriptBase.AppendLine("};");

            ///<summary>
            /// Makes sure the calendar can reload events when event forms are popup
            ///</summary>
			//reposition table calendar header from bottom to top of the generated control
            scriptBase.AppendLine("if($().FullCalendar) { $('#" + Builder.ajaxUpdateContainerId + "').FullCalendar(calendarOptions_" + Builder.ajaxUpdateContainerId + ");");
            scriptBase.AppendLine("$('#" + Builder.ajaxUpdateContainerId + "').find('.table-title').parent().parent().insertBefore($('#" + Builder.ajaxUpdateContainerId + "').children(':first'))} ");
            scriptBase.AppendLine("else { $(document).ready(function() { $('#" + Builder.ajaxUpdateContainerId + "').FullCalendar(calendarOptions_" + Builder.ajaxUpdateContainerId + "); "); 
            scriptBase.AppendLine("$('#" + Builder.ajaxUpdateContainerId + "').find('.table-title').parent().parent().insertBefore($('#" + Builder.ajaxUpdateContainerId + "').children(':first'))}); }");

            return new MvcHtmlString(scriptBase.ToString());
        }

        public MvcHtmlString ToHtml()
        {
            return new MvcHtmlString("<script>" + GenerateScripts().ToHtmlString() + " </script>");
        }

        /// <summary>
        /// Creates any form links, all is needed is refer the type of the form
        /// </summary>
        /// <param name="TypeOfForm"></param>
        /// <returns>URL</returns>
        protected MvcHtmlString CreateLink(string TypeOfForm)
        {
            string url = null;
            var qs = Builder.HtmlHelper.ViewContext.RequestContext.HttpContext.Request.QueryString;
            url = (new UrlHelper(Builder.HtmlHelper.ViewContext.RequestContext)).Action(Builder.Form.HelpForm + TypeOfForm, typeof(TModel).Name, new { nav = qs["nav"] });

            return new MvcHtmlString(url);
        }

        /// <summary>
        /// Gets the data for the rendering of the events, if any data is available.
        /// </summary>
        /// <returns>Json_String with events</returns>
        public MvcHtmlString GetEvents()
        {
            List<CalendarEvent> events = new List<CalendarEvent>();

            foreach (TModel model in Builder.Data)
            {
                string row = null;
                ///<summary>
                ///Counts the number of dates inputed
                ///</summary>
                int data = 0;
                ///<summary>
                ///Counts the number of texts inputed
                ///</summary>
                int textos = 0;
                ///<summary>
                ///Counts the number of booleans inputed
                ///</summary>
                int bools = 0;
                CalendarEvent evento = new CalendarEvent();
                evento.EventID = Builder.TableKey.Evaluate(model);

                foreach (var tc in Builder.TableColumns)
                {
                    if (!tc.ColumnVisible)
                        continue;
                    switch (tc.DataType)
                    {
                        case Table.Columns.ColumnDataType.Text:
                            {
                                row = tc.Evaluate(model);
                                switch (textos)
                                {
                                    case 0:
                                        evento.Title = row;
                                        break;
                                    case 1:
                                        evento.Description = row;
                                        break;
                                    case 2:
                                        evento.ThemeColor = row;
                                        break;
                                    case 3:
                                        evento.resourceId = row;
                                        break;
                                    case 7:
                                        evento.resourceId = row; //if the resource has a children the id of the event must be linked to the children instead of the resource
                                        break;
                                }
                                textos++;
                                break;
                            }
                        case Table.Columns.ColumnDataType.Date:
                            {
                                var dateVal = (tc as Table.Columns.TableColumn<TModel, DateTime?>).CompiledExpression(model);
                                switch (data)
                                {
                                    case 0:
                                        evento.Start = dateVal.GetValueOrDefault();
                                        break;
                                    case 1:
                                        evento.End = dateVal.GetValueOrDefault();
                                        break;
                                }
                                data++;
                                break;
                            }
                        case Table.Columns.ColumnDataType.Boolean:
                            {
                                row = tc.Evaluate(model);
                                switch (bools)
                                {
                                    case 0:
                                        evento.IsFullDay = row == "True";
                                        break;
                                    case 1:
                                        evento.IsBackground = row == "True";
                                        break;
                                }
                                bools++;
                                break;
                            }
                    }
                }
                events.Add(evento);
            }

            return MvcHtmlString.Create(JsonConvert.SerializeObject(events));
        }

        /// <summary>
        /// Gets the resources to be associated to each event.
        /// </summary>
        /// <returns>Json_String with resources</returns>
        public MvcHtmlString GetResources()
        {
            List<Resource> resources = new List<Resource>();

            foreach (TModel model in Builder.Data)
            {
                string row = null;
                ///<summary>
                /// Counts the number of texts inputed
                ///</summary>
                int textos = 0;
                Resource resource = new Resource();
                resource.children = new List<Child>();
                Child c = new Child();
                bool hasChildren = false;

                foreach (Table.Columns.ITableColumnInternal<TModel> tc in Builder.TableColumns)
                {
                    if (!tc.ColumnVisible)
                        continue;
                    if (tc.DataType == Table.Columns.ColumnDataType.Text)
                    {
                        row = tc.Evaluate(model);
                        switch (textos)
                        {
                            case 0:
                            case 1:
                            case 2:
                                break;
                            case 3:
                                resource.id = row;
                                break;
                            case 4:
                                resource.columnLabel = tc.ColumnTitle;
                                resource.title = row;
                                break;
                            case 5:
                                resource.group = row;
                                break;
                            case 6:
                                resource.groupLabel = row;
                                break;
                            case 7:
                                c.id = row;
                                hasChildren = true;
                                break;
                            case 8:
                                c.title = row;
                                break;
                        }
                        textos++;
                    }
                }

                Resource res = resources.Find(r => r.id == resource.id);

                if (res == null)
                {
                    if (hasChildren)
                    {
                        resource.children.Add(c);
                    }

                    resources.Add(resource);
                }
                else
                {
                    if (hasChildren && !res.children.Contains(c))
                    {
                        res.children.Add(c);
                    }
                }
            }

            return MvcHtmlString.Create(JsonConvert.SerializeObject(resources));
        }

        /// <summary>
        /// Gets the license of the scheduler.
        /// </summary>
        /// <returns>License string</returns>
        private string GetLicense()
        {
            string license = "";
            if (Configuration.ExistsProperty("SchedulerLicense"))
            {
                license = Configuration.GetProperty("SchedulerLicense");
            }
            
            return license;
        }
    }
}