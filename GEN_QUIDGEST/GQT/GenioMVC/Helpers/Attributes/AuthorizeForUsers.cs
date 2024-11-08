using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using GenioMVC.Models.Navigation;
using GenioMVC.Models.Exception;

namespace GenioMVC.Helpers
{
	public class AuthorizeForUsers : AuthorizeAttribute
	{
		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			if (filterContext == null)
				throw new ArgumentNullException("filterContext");

			var u = UserContext.Current.User;
			if (!u.IsGuest())
			{
				// Check if user has their account disabled
				if (u.Status == 2)
					throw new InvalidAuthenticationException("This user is unauthorized. Please contact your administrator.");
				// Check if user needs to change password
				else if (u.NeedsToChangePassword() && !ActionsAllowed(filterContext))
					filterContext.Result = new RedirectToRouteResult( new RouteValueDictionary {{ "action", "Profile" }, { "controller", "Home" } });
				// Check if user has to setup 2FA
				else if (u.NeedsToSetup2FA() && !ActionsAllowed(filterContext))
					filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "Change2FA" }, { "controller", "Home" } });
			}
			else
			{
				// User not authenticated
				filterContext.Result = new HttpUnauthorizedResult();
			}
		}

		private bool ActionsAllowed(AuthorizationContext filterContext)
		{
			if ((filterContext.RequestContext.RouteData.Values["action"].ToString() == "Profile" && filterContext.RequestContext.RouteData.Values["controller"].ToString() == "Home")
				|| (filterContext.RequestContext.RouteData.Values["action"].ToString() == "LogOff" && filterContext.RequestContext.RouteData.Values["controller"].ToString() == "Account")
				|| (filterContext.RequestContext.RouteData.Values["action"].ToString() == "GetImage" && filterContext.RequestContext.RouteData.Values["controller"].ToString() == "Account")
				|| (filterContext.RequestContext.RouteData.Values["action"].ToString() == "Change2FA" && filterContext.RequestContext.RouteData.Values["controller"].ToString() == "Home"))
				return true;
			return false;
		}
	}
}
