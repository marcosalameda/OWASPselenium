using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

using GenioMVC.Helpers.Attributes;

namespace GenioMVC.Helpers
{
	public class CustomControllerFactory : DefaultControllerFactory
	{
		protected override SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, Type controllerType)
		{
			if (controllerType == null)
				return SessionStateBehavior.Default;

			var actionName = requestContext.RouteData.Values["action"].ToString();
			MethodInfo actionMethodInfo = null;

			if (requestContext.HttpContext.Request.HttpMethod == "GET")
			{
				actionMethodInfo = controllerType.GetMethods(BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
				.Where(m => m.Name == actionName && m.GetCustomAttributes(typeof(HttpGetAttribute), false).Length > 0).FirstOrDefault();
			}
			else if (requestContext.HttpContext.Request.HttpMethod == "POST")
			{
				actionMethodInfo = controllerType.GetMethods(BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
				.Where(m => m.Name == actionName && m.GetCustomAttributes(typeof(HttpPostAttribute), false).Length > 0).FirstOrDefault();
			}

			if (actionMethodInfo == null)
			{
				actionMethodInfo = controllerType.GetMethods(BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
				.Where(m => m.Name == actionName).FirstOrDefault();
			}

			if (actionMethodInfo != null)
			{
				var actionSessionStateAttr = actionMethodInfo.GetCustomAttributes(typeof(ActionSessionStateAttribute), false)
									.OfType<ActionSessionStateAttribute>()
									.FirstOrDefault();

				if (actionSessionStateAttr != null)
					return actionSessionStateAttr.Behavior;
			}

			return base.GetControllerSessionBehavior(requestContext, controllerType);
		}
	}
}
