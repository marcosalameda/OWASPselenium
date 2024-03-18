using CSGenio.framework;
using GenioMVC.Helpers;
using System.Net;
using System.Web.Mvc;

namespace GenioMVC.Controllers
{
    public class ApplicationErrorsController : ControllerBase
    {
        [AuthorizeForUsers]
        [HttpPost]
        public JsonResult LogJavaScriptError(string message)
        {
            Log.Error("_Javascript_" + message);
            return new JsonResult() { Data = new { success = true } };
        }

        public ActionResult NotFound()
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View();
        }

        public ActionResult ServerError()
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return View();
        }
    }
}
