using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GenioMVC.Helpers
{
	public class LayoutInjecter : ActionFilterAttribute
	{
		private readonly string _masterName;
		public LayoutInjecter(string masterName)
		{
			_masterName = masterName;
		}

		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			base.OnActionExecuted(filterContext);
			var result = filterContext.Result as ViewResult;
			if (result != null)
				result.MasterName = _masterName;
		}
	}
}
