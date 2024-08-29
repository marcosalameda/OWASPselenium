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
        private static readonly NavigationLocation ACTION_PTN_Menu_3H1 = new NavigationLocation("DASHBOARD27032", "PTN_Menu_3H1", "Dashboard");

        // GET: /Dashboard/PTN_Menu_3H1
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_3H1")]
        public ActionResult PTN_Menu_3H1()
        {
            DashboardViewModel vm = new PTN_Menu_3H1_ViewModel(Navigation);
            vm.Load();

            User user = UserContext.Current.User;
            PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);
            CSGenioAlstusr lstusr = GetOrInitLstusr(vm.uuid);

            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage) Navigation.SetValue("HomePage", "PTN_Menu_3H1");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_Menu_3H1.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    if (Navigation.ContainsAction(ACTION_PTN_Menu_3H1))
                        Navigation.RemoveHistoryLevel(ACTION_PTN_Menu_3H1);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_Menu_3H1.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_Menu_3H1, FormMode.Show);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
                }
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_Menu_3H1.ShortDescription());
                Navigation.SetValue("DashboardHomePage", true);
            }

            vm.Navigation = Navigation;

            // Retrieve the user configuration of the dashboard
            // If there is a user configuration, the original definition is ignored
            // and the position and visibility information of the user configuration is used
            List<CSGenioAusrwid> userWidgets = UserUiSettings
                .Load(sp, lstusr.ValDescric, user)
                .userWidgets;

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
                        sp.openConnection();
                        userWidget.delete(sp);
                        sp.closeConnection();
                    }
                }

                if (changes) UserUiSettings.Invalidate(lstusr.ValDescric, user);
            }

            if (isHomePage)
                return PartialView("PTN_Menu_3H1", vm);
            else if (!Request.IsAjaxRequest())
                return View(vm);
            else
                return PartialView("Dashboard", vm);
        }

        #region Custom widgets

        // GET: "/Dashboard/PTN_Menu_3H1_Widget_COLAB"
		[HttpGet]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public ActionResult PTN_Menu_3H1_Widget_COLAB(string fk)
        {
            ViewModels.Cmpny.Wid_cola_ViewModel vm = new ViewModels.Cmpny.Wid_cola_ViewModel(Navigation);
            // Custom widget based on a form with base area
            vm.Navigation.SetValue("cmpny", fk);

            vm.setModes("v");
            vm.Load(Request.Form, false, Request.IsAjaxRequest());

            return PartialView("Widgets/PTN_Menu_3H1_Widget_COLAB", vm);
        }

        // GET: "/Dashboard/PTN_Menu_3H1_Widget_EMPLOY"
		[HttpGet]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public ActionResult PTN_Menu_3H1_Widget_EMPLOY()
        {
            // Custom widget based on an empty form
            ViewModels.Wid_pess_ViewModel vm = new ViewModels.Wid_pess_ViewModel(Navigation);

            vm.setModes("v");
            vm.Load(Request.Form);

            return PartialView("Widgets/PTN_Menu_3H1_Widget_EMPLOY", vm);
        }

        // GET: "/Dashboard/PTN_Menu_3H1_Widget_GRAPH_COUNT"
		[HttpGet]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public ActionResult PTN_Menu_3H1_Widget_GRAPH_COUNT()
        {
            // Custom widget based on an empty form
            ViewModels.Wid_grap_ViewModel vm = new ViewModels.Wid_grap_ViewModel(Navigation);

            vm.setModes("v");
            vm.Load(Request.Form);

            return PartialView("Widgets/PTN_Menu_3H1_Widget_GRAPH_COUNT", vm);
        }

        #endregion

        // GET: "/Dashboard/RenderMenuWidget"
		[HttpGet]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public ActionResult PTN_Menu_3H1_RenderMenuWidget(WidgetType type, string widgetId)
        {
            DashboardViewModel vm = new PTN_Menu_3H1_ViewModel(Navigation);

            return RenderMenuWidget(vm, type, widgetId);
        }

        // GET: "/Dashboard/GetWidgetData"
		[HttpGet]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public ActionResult PTN_Menu_3H1_GetWidgetData(WidgetType widgetType, string widgetId)
        {
            DashboardViewModel vm = new PTN_Menu_3H1_ViewModel(Navigation);

            return GetWidgetData(vm, widgetType, widgetId);
        }
    }
}
