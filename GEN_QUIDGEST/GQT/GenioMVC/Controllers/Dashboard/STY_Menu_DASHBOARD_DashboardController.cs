using System;
using System.Linq;
using System.Web.Mvc;
using GenioMVC.Models.Navigation;
using GenioMVC.Helpers;
using CSGenio.persistence;
using CSGenio.business;
using CSGenio.framework;
using System.Collections.Specialized;
using GenioMVC.ViewModels.Dashboard;
using GenioMVC.Helpers.Attributes;
using System.Collections.Generic;

namespace GenioMVC.Controllers
{
    public partial class DashboardController : DashboardControllerBase
    {
        private static readonly NavigationLocation ACTION_STY_Menu_DASHBOARD = new NavigationLocation("DASHBOARD27032", "STY_Menu_DASHBOARD", "Dashboard");

        // GET: /Dashboard/STY_Menu_DASHBOARD
		[AuthorizeForUsers]
        [ActionName("STY_Menu_DASHBOARD")]
        public ActionResult STY_Menu_DASHBOARD()
        {
            DashboardViewModel vm = new STY_Menu_DASHBOARD_ViewModel(Navigation);
            vm.Load();

            User user = UserContext.Current.User;
            PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);
            CSGenioAlstusr lstusr = GetOrInitLstusr(vm.uuid);

            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage) Navigation.SetValue("HomePage", "STY_Menu_DASHBOARD");
            ViewBag.isHomePage = isHomePage;

            CSGenio.framework.StatusMessage result = vm.CheckPermissions(FormMode.Show);
            if (result.Status.Equals(CSGenio.framework.Status.E))
            {
                if (!Request.IsAjaxRequest() && !isHomePage)
                    return View("_PermissionError", model: result.Message);
                else
                    return PartialView("_PermissionError", model: result.Message);
            }

            NameValueCollection querystring = Request.Form.Count > 0 ? Request.Form : Request.QueryString;
            if (!isHomePage && !Request.IsAjaxRequest())
            {
                if (Navigation.CurrentLevel == null || !ACTION_STY_Menu_DASHBOARD.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    if (Navigation.ContainsAction(ACTION_STY_Menu_DASHBOARD))
                        Navigation.RemoveHistoryLevel(ACTION_STY_Menu_DASHBOARD);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_STY_Menu_DASHBOARD.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_STY_Menu_DASHBOARD, FormMode.Show);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
                }
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_Menu_DASHBOARD.ShortDescription());
                Navigation.SetValue("DashboardHomePage", true);
            }

            vm.Navigation = Navigation;

            // Retrieve the user configuration of the dashboard
            // If there is a user configuration, the original definition is ignored
            // and the position and visibility information of the user configuration is used
            List<CSGenioAusrwid> userWidgets = DashboardUiSettingsDbRec
                .Load(sp, lstusr.ValDescric, user)
                .UserWidgets;

            // Only override the definition if the user saved a configuration
            if (userWidgets != null && userWidgets.Count > 0)
            {
                bool changes = false;

                foreach (CSGenioAusrwid userWidget in userWidgets)
                {
                    List<Widget> res = vm.Widgets
                        .Where(w => w.Id == userWidget.ValWidget)
                        .ToList();

                    Widget widget;
                    if (res.Count > 1)
                        widget = res.FirstOrDefault(w => w.Rowkey == userWidget.ValRowkey);
                    else
                        widget = res.FirstOrDefault();

                    if (widget != null)
                    {
                        widget.Hposition = userWidget.ValHposition;
                        widget.Vposition = userWidget.ValVposition;
                        widget.Visible = widget.Required || userWidget.ValVisible == 1;
                        widget.Rowkey = userWidget.ValRowkey;
                    }
                    else
                    {
                        // Widget is no longer available
                        // The widget might have been removed from the definition
                        // or the current user no longer has access to it
                        changes = true;

                        // Remove the widget from the user configuration
						// Only if not in maintenance mode
						if (!Maintenance.Current.IsActive)
						{
							sp.openConnection();
							userWidget.delete(sp);
							sp.closeConnection();
						}
                    }
                }

                if (changes) DashboardUiSettingsDbRec.Invalidate(lstusr.ValDescric, user);
            }

            if (isHomePage)
                return PartialView("STY_Menu_DASHBOARD", vm);
            else if (!Request.IsAjaxRequest())
                return View(vm);
            else
                return PartialView("Dashboard", vm);
        }

        #region Custom widgets

        // GET: "/Dashboard/STY_Menu_DASHBOARD_Widget_COLAB"
		[HttpGet]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public ActionResult STY_Menu_DASHBOARD_Widget_COLAB(string fk)
        {
            ViewModels.Cmpny.Wid_cola_ViewModel vm = new ViewModels.Cmpny.Wid_cola_ViewModel(Navigation);
            // Custom widget based on a form with base area
            vm.Navigation.SetValue("cmpny", fk);

            vm.setModes("v");
            vm.MapFromModel(Models.Cmpny.Find(fk));

            return PartialView("Widgets/STY_Menu_DASHBOARD_Widget_COLAB", vm);
        }

        // GET: "/Dashboard/STY_Menu_DASHBOARD_Widget_WID_EQUI"
		[HttpGet]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public ActionResult STY_Menu_DASHBOARD_Widget_WID_EQUI()
        {
            // Custom widget based on an empty form
            ViewModels.Wid_equi_ViewModel vm = new ViewModels.Wid_equi_ViewModel(Navigation);

            vm.setModes("v");
            vm.Load(Request.Form);

            return PartialView("Widgets/STY_Menu_DASHBOARD_Widget_WID_EQUI", vm);
        }

        // GET: "/Dashboard/STY_Menu_DASHBOARD_Widget_GRAPH_COUNT"
		[HttpGet]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public ActionResult STY_Menu_DASHBOARD_Widget_GRAPH_COUNT()
        {
            // Custom widget based on an empty form
            ViewModels.Wid_grap_ViewModel vm = new ViewModels.Wid_grap_ViewModel(Navigation);

            vm.setModes("v");
            vm.Load(Request.Form);

            return PartialView("Widgets/STY_Menu_DASHBOARD_Widget_GRAPH_COUNT", vm);
        }

        // GET: "/Dashboard/STY_Menu_DASHBOARD_Widget_EMPLOY"
		[HttpGet]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public ActionResult STY_Menu_DASHBOARD_Widget_EMPLOY()
        {
            // Custom widget based on an empty form
            ViewModels.Wid_pess_ViewModel vm = new ViewModels.Wid_pess_ViewModel(Navigation);

            vm.setModes("v");
            vm.Load(Request.Form);

            return PartialView("Widgets/STY_Menu_DASHBOARD_Widget_EMPLOY", vm);
        }

        // GET: "/Dashboard/STY_Menu_DASHBOARD_Widget_WID_INFO_EQUIP"
		[HttpGet]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public ActionResult STY_Menu_DASHBOARD_Widget_WID_INFO_EQUIP(string fk)
        {
            ViewModels.Equip.Wid_iequ_ViewModel vm = new ViewModels.Equip.Wid_iequ_ViewModel(Navigation);
            // Custom widget based on a form with base area
            vm.Navigation.SetValue("equip", fk);

            vm.setModes("v");
            vm.MapFromModel(Models.Equip.Find(fk));

            return PartialView("Widgets/STY_Menu_DASHBOARD_Widget_WID_INFO_EQUIP", vm);
        }

        #endregion

        // GET: "/Dashboard/RenderMenuWidget"
		[HttpGet]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public ActionResult STY_Menu_DASHBOARD_RenderMenuWidget(WidgetType type, string widgetId)
        {
            DashboardViewModel vm = new STY_Menu_DASHBOARD_ViewModel(Navigation);

            return RenderMenuWidget(vm, type, widgetId);
        }

        // GET: "/Dashboard/GetWidgetData"
		[HttpGet]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public ActionResult STY_Menu_DASHBOARD_GetWidgetData(WidgetType widgetType, string widgetId)
        {
            DashboardViewModel vm = new STY_Menu_DASHBOARD_ViewModel(Navigation);

            return GetWidgetData(vm, widgetType, widgetId);
        }
    }
}
