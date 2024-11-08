using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GenioMVC.Models.Navigation;

namespace GenioMVC.Controllers
{
	public class AlertsController : ControllerBase
	{
		[HttpGet]
		public ActionResult Index()
		{
			var qs = Request.QueryString;
			bool isAjaxRequest = Request.IsAjaxRequest();
			ViewModels.Alerts_ViewModel vm = new ViewModels.Alerts_ViewModel(Navigation, qs, isAjaxRequest);
			List<Alert> alerts = vm.GenAlerts();

			return Json(alerts.Select(alert => new AlertDto(alert)), JsonRequestBehavior.AllowGet);
		}
	}
}
