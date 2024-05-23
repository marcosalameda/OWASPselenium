using System.Web.Mvc;

using CSGenio.business;

namespace GenioMVC.Controllers
{
	/// <summary>
	/// Arrays controller
	/// </summary>
	public class ArraysController : ControllerBase
	{

		/// <summary>
		/// Gets the array "s_module".
		/// </summary>
		[HttpGet]
		public ActionResult S_module(string lang)
		{
			return Json(ArrayS_module.Serialize(lang), JsonRequestBehavior.AllowGet);
		}

		/// <summary>
		/// Gets the array "s_roles".
		/// </summary>
		[HttpGet]
		public ActionResult S_roles(string lang)
		{
			return Json(ArrayS_roles.Serialize(lang), JsonRequestBehavior.AllowGet);
		}

		/// <summary>
		/// Gets the array "s_tpproc".
		/// </summary>
		[HttpGet]
		public ActionResult S_tpproc(string lang)
		{
			return Json(ArrayS_tpproc.Serialize(lang), JsonRequestBehavior.AllowGet);
		}
	}
}
