using System;
using System.Linq;
using System.Web;
//using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Collections.Generic;
using CSGenio.framework;


namespace GenioMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("favicon.ico");

            // MH - Pedidos de imagens, stylesheets, reports e manuais não precisam do roteamento
            routes.IgnoreRoute("Content/{*pathInfo}");
            routes.IgnoreRoute("ClientApp/dist/{*pathInfo}");

// USE /[MANUAL GQT CUSTOM_ROUTES]/

			#region Specific routing

            const string accountRouteUrl = "Account/{action}";
            RouteValueDictionary accountRouteValueDictionary = new RouteValueDictionary(new { culture = "en-US", system = Configuration.DefaultYear, module = "Public", controller = "Account"});
            routes.Add("RouteForAccount", new GenioMVC.Helpers.Culture.GlobalisedRoute(accountRouteUrl, accountRouteValueDictionary));

            routes.MapRoute(
                "RouteForUsersProfile",
                "{culture}/{system}/User{action}/{id}",
                new { controller = "Home", action = "Profile", module = "Public", culture = "pt-PT", system = Configuration.DefaultYear }
            );

			//Used for user authentication with OpenId Connect. This method require one url for callback after login are made. This will permit to use schema + domain + "/OpenIdLogin" to be use on Call back.
			routes.MapRoute("OIdAuth", "OpenIdLogin", new { culture = "en-US", system = Configuration.DefaultYear, controller = "Account", action = "OpenIdLogin", module = "Public" });
			//Used for user regist your OpenId Connect Account. This method require one url for callback after login are made. This will permit to use schema + domain + "/OpenIdRegister" to be use on Call back.
            routes.MapRoute("OIdRegist", "OpenIdRegister", new { culture = "en-US", system = Configuration.DefaultYear, controller = "Home", action = "OpenIdRegister", module = "Public" });
			//Used for user authentication with CAS. This method require one url for callback after login are made. This will permit to use schema + domain + "/CASLogin" to be use on Call back.
            routes.MapRoute("CASAuth", "CASLogin", new { culture = "en-US", system = Configuration.DefaultYear, controller = "Account", action = "CASLogin", module = "Public" });

            #endregion

            #region Generic routing
            const string defautlRouteUrl = "{system}/{module}/{controller}/{action}/{id}";
            RouteValueDictionary defaultRouteValueDictionary = new RouteValueDictionary(new { culture = "en-US", system = Configuration.DefaultYear, module = "Public", controller = "Home", action = "Index", id = UrlParameter.Optional });
            routes.Add("DefaultGlobalised", new GenioMVC.Helpers.Culture.GlobalisedRoute(defautlRouteUrl, defaultRouteValueDictionary));

            routes.MapRoute(
                "DefaultWithModule", // Route name
                "{system}/{module}/{controller}/{action}/{id}", // URL with parameters
                new { system = Configuration.DefaultYear, controller = "Home", action = "Index", id = UrlParameter.Optional, module = "Public" } // Parameter defaults
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { system = Configuration.DefaultYear, controller = "Home", action = "Index", id = UrlParameter.Optional, module = "Public" } // Parameter defaults
            );

            #endregion
        }

        /// <summary>
        /// Checks if a given action is allowed by guest users
        /// </summary>
        /// <param name="action">A string with the action we want to check</param>
        public static bool IsAllowedByGuest(string action)
        {
            var guestActions = new string[] {
                "logon", "register", "creationsuccess", "confirmemail", "recoverpassword", "openidlogin", "recoverpasswordchange"
            };
            return guestActions.Contains(action.ToLower());
        }

        /// <summary>
        /// Checks if a given action is a prelogin action.
        /// Used to identify which actions should go to the splash screen, even in public portals
        /// </summary>
        /// <param name="action">A string with the action we want to check</param>
        public static bool IsPreLogin(string action)
        {
            var guestActions = new string[] {
                "logon",  "recoverpassword", "recoverpasswordchange", "creationsuccess","confirmemail"
            };
            return guestActions.Contains(action.ToLower());
        }
    }
}
