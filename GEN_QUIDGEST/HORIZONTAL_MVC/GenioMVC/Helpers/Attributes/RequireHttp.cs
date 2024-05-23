using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenioMVC.Helpers.Attributes
{
	public class RequireHttp : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			string value = filterContext.HttpContext.Request.QueryString["certificado"];
			// If the request has arrived via HTTPS...
			if (filterContext.HttpContext.Request.IsSecureConnection && value == "True")
			{
				filterContext.Result = new RedirectResult(filterContext.HttpContext.Request.Url.ToString().Replace("https:", "http:")); // Go on, bugger off "s"!
				filterContext.Result.ExecuteResult(filterContext);
			}
			base.OnActionExecuting(filterContext);
		}
	}
}
