using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenioMVC.Helpers.Table.Properties
{
    public class TableAction<TModel>
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Icon { get; set; }
        public bool IsBootStrapIcon { get; set; }
        public string Title { get; set; }
        public bool IsRoutine { get; set; }
        public Func<TModel, object> RouteValuesFun { get; protected set; }
        public object HtmlAttributes { get; set; }
        public bool IsFollowUp { get; set; }
        public bool IsSpecificPaths { get; set; }
        public bool IsAjaxAction { get; set; }
        public bool RequiresMultipleSelection { get; set; }
        public bool OpenInPopup { get; set; }
        /// <summary>
        /// QLevel de acesso do user é suficiente to aceder a acção
        /// </summary>
        public bool LvlAccess { get; set; }
		/// <summary>
        /// True when the action is a slot of report
        /// </summary>
        public bool IsSlotReport { get; set; }
        /// <summary>
        /// Slot report identifier
        /// </summary>
        public string SlotReportId { get; set; }

        public TableAction(string action, string controller, Func<TModel, object> routeValuesFun, string icon, bool isBootstrapIcon, string title, bool isRoutine, bool multipleSelection, object htmlAttributes, bool isFollowUpAction, bool isSpecificPaths, bool isAjaxAction, bool openInPopup = false, bool accesslevel = true, bool isSlotReport = false, string slotReportId = "")
        {
            this.Action = action;
            this.Controller = controller;
            this.RouteValuesFun = routeValuesFun;
            this.Icon = icon;
            this.IsBootStrapIcon = isBootstrapIcon;
            this.Title = title;
            this.IsRoutine = isRoutine;
            this.HtmlAttributes = htmlAttributes == null ? new { } : htmlAttributes;
            this.IsFollowUp = isFollowUpAction;
            this.IsSpecificPaths = isSpecificPaths;
            this.IsAjaxAction = isAjaxAction;
            this.RequiresMultipleSelection = multipleSelection;
            this.OpenInPopup = openInPopup;
            this.LvlAccess = accesslevel;
			this.IsSlotReport = isSlotReport;
            this.SlotReportId = slotReportId;
        }
    }
}