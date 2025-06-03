using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Navigation;
using GenioMVC.ViewModels.Dashboard;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

namespace GenioMVC.Controllers
{
	public partial class DashboardController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_GQT_Menu_TESTDS =
			new ("DASHBOARD51597", "GQT_Menu_TESTDS", "Dashboard");

		public ActionResult GQT_Menu_TESTDS()
		{
			DashboardViewModel vm = new GQT_Menu_TESTDS_ViewModel(UserContext.Current);
			vm.Load();

			bool isHomePage =
				RouteData.Values.ContainsKey("isHomePage") && (bool)RouteData.Values["isHomePage"];
			
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_TESTDS");
			ViewBag.isHomePage = isHomePage;

			CSGenio.framework.StatusMessage result = vm.CheckPermissions(FormMode.Show);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return JsonERROR(result.Message);

			if (
				!isHomePage
				&& !Request.IsAjaxRequest()
				&& (
					Navigation.CurrentLevel == null
					|| !ACTION_GQT_Menu_TESTDS.IsSameAction(Navigation.CurrentLevel.Location)
				)
				&& Navigation.CurrentLevel.Location.Action != ACTION_GQT_Menu_TESTDS.Action
			)
				CSGenio.framework.Audit.registAction(
					UserContext.Current.User,
					Resources.Resources.MENU01948
						+ " "
						+ Navigation.CurrentLevel.Location.ShortDescription()
				);
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(
					UserContext.Current.User,
					Resources.Resources.MENU01948 + " " + ACTION_GQT_Menu_TESTDS.ShortDescription()
				);
			}

			return JsonOK(vm);
		}

		public ActionResult GQT_Menu_TESTDS_Save([FromBody]DashboardSaveRequest dto)
		{
			// Don't allow changes in maintenance mode
			if (Maintenance.Current.IsActive)
				return JsonERROR(Resources.Resources.O_SISTEMA_ENCONTRA_S37912);

			DashboardViewModel vm = new GQT_Menu_TESTDS_ViewModel(UserContext.Current);
			vm.Save(dto);

			return JsonOK();
		}

		public ActionResult GQT_Menu_TESTDS_GetWidgetData([FromBody]RequestWidgetModel requestModel)
		{
			DashboardViewModel vm = new GQT_Menu_TESTDS_ViewModel(UserContext.Current);
			object data = vm.GetWidgetData(requestModel.WidgetType, requestModel.WidgetId);

			return JsonOK(data);
		}
	}
}
