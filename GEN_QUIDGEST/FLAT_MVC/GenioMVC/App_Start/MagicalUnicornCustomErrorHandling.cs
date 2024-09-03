using System.Web.Mvc;
using System.Web.Routing;

[assembly: WebActivator.PreApplicationStartMethod(
    typeof(GenioMVC.App_Start.MagicalUnicornCustomErrorHandling), "PreStart")]

namespace GenioMVC.App_Start
{
    public static class MagicalUnicornCustomErrorHandling
    {
        public static void PreStart()
        {
            // Lets wire up our two Error Handling routes, really early.

            // This will be pushed down to route #2.
// USE /[MANUAL GQT ROUTE_SERVER_ERROR]/
			RouteTable.Routes.Insert(0, new Route("ServerError",
											new RouteValueDictionary(
												new {controller = "ApplicationErrors", action = "ServerError", module = "Public"}),
											new MvcRouteHandler()));

            // And now our first route.
// USE /[MANUAL GQT ROUTE_NOT_FOUND]/
            RouteTable.Routes.Insert(0, new Route("NotFound",
											new RouteValueDictionary(
												new {controller = "ApplicationErrors", action = "NotFound", module = "Public"}),
											new MvcRouteHandler()));
        }
    }
}
