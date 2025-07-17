using System.Web.Mvc;

using GenioMVC.Models;

namespace GenioMVC.Controllers;

public class HealthCheckController : Controller
{
	/// <summary>
	/// Performs a comprehensive health check of the application and its dependencies.
	/// Returns HTTP 200 (OK) if all systems are healthy, or HTTP 503 (Service Unavailable) if any issues are detected.
	/// </summary>
	/// <returns>
	/// JSON response containing detailed health status information for all checked components.
	/// HTTP 200 if healthy, HTTP 503 if unhealthy.
	/// </returns>
	[HttpGet]
	public ActionResult Index()
	{
		string environment = "Production";
#if DEBUG
		environment = "Development";
#endif
		WebAppHealthChecker healthChecker = new(environment);

		if (healthChecker.IsHealthy())
			return Json(healthChecker.LastResult.ToJson(), JsonRequestBehavior.AllowGet);

		Response.StatusCode = 503;
		return Json(healthChecker.LastResult.ToJson(), JsonRequestBehavior.AllowGet);
	}
}
