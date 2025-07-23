using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using GenioMVC.Models.Navigation;
using GenioMVC.Models;
using System.Security.Principal;
using GenioServer.security;
using GenioMVC.Models.Exception;
using CSGenio.framework;
using GenioMVC.Helpers;
using System.Web.Http;
using System.Web.Optimization;
using GenioMVC.Helpers.ModelBinders;
using GenioMVC.CustomEngines;
using System.Collections.Generic;
using CSGenio.persistence;
using CSGenio.core.messaging;
using CSGenio.messaging;

namespace GenioMVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode,
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private IDisposable _telemetryService;
        private MessagingService _messagingService;

        protected void Application_Start()
        {
            if (Configuration.ConfigVersion == null)
                return;

            // this line is to hide mvc header
            MvcHandler.DisableMvcResponseHeader = true;

            //GenioServer services
            CSGenio.GenioDIDefault.Use();
            _telemetryService = OpenTelemetryProvider.Create();


            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            LayoutConfig.RegisterLayout();
            AuthConfig.RegisterAuth();
            ControllerBuilder.Current.SetControllerFactory(typeof(Helpers.CustomControllerFactory));

            // Model Binders
            ModelBinders.Binders.DefaultBinder = new ExtendedModelBinder();
            ModelBinders.Binders.Add(typeof(DateTime?), new DateModelBinder());
            //Model Binders of Numeric fields
            ModelBinders.Binders.Add(typeof(int?), new NumericModelBinder());
            ModelBinders.Binders.Add(typeof(int), new NumericModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new NumericModelBinder());
            ModelBinders.Binders.Add(typeof(decimal), new NumericModelBinder());
            ModelBinders.Binders.Add(typeof(double?), new NumericModelBinder());
            ModelBinders.Binders.Add(typeof(double), new NumericModelBinder());
            //Model Binders of Boolean fields
            ModelBinders.Binders.Add(typeof(bool?), new BooleanModelBinder());
            ModelBinders.Binders.Add(typeof(bool), new BooleanModelBinder());

            //JGF 2019.03.27 No matter where the configuration file is, when it's changed the app pool must be restarted
            Configuration.ConfigWatcher.Changed += new System.IO.FileSystemEventHandler(RestartAppPool);

            // Custom engines
            ViewEngines.Engines.Clear();
            ExtendedRazorEngine engine = new ExtendedRazorEngine() { FileExtensions = new string[] { "cshtml" } };
            engine.AddViewLocationFormat("~/Views/Shared/Layouts/HorzMenu_WithHeader/{0}.cshtml");
            engine.AddPartialViewLocationFormat("~/Views/Shared/Layouts/HorzMenu_WithHeader/{0}.cshtml");
			engine.AddViewLocationFormat("~/Views/Shared/Layouts/TopMenu_BT4/{0}.cshtml");
            engine.AddPartialViewLocationFormat("~/Views/Shared/Layouts/TopMenu_BT4/{0}.cshtml");
            ViewEngines.Engines.Add(engine);

            // For Asp.NET to be able to communicate with Reporting Services or other services published over HTTPS and with the old SSL protocols disabled.
            // To turn on TLS 1.2 and 1.3 without affecting other protocols.
            System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls13;

            // Messaging
            if(Configuration.Messaging.Enabled)
            {
                _messagingService = CSGenio.core.di.GenioDI.Messaging;
                _messagingService.Start(
                    metadata: MessageMetadataFactory.GeneratedMetadata(),
                    providerType: Configuration.Messaging.Host.Provider,
                    enableSubscribe: false
                );
            }
        }

        protected void Application_End()
        {
            _messagingService?.Close();
            _telemetryService?.Dispose();
        }

        private static void RestartAppPool(object sender, System.IO.FileSystemEventArgs e)
        {
            HttpRuntime.UnloadAppDomain();
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_PostAcquireRequestState(object sender, EventArgs e)
        {
            if (Configuration.ConfigVersion != null && Context.Session != null)
            {
                // set the user interaction flow for this request
                // TODO: set it according to the key specified in the request
                //       for now it only supports one user interaction flow per session
                //Context.Items["NavigationContext"] = UserContext.Current.Navigations.Values.FirstOrDefault() ?? UserContext.Current.CreateNavigation();

                //Note: When a SameIP security policy is active this kind of Location resetting is invalid
                //In fact the user should be forbidden to continue to use the application, needing to log out of his previous location to login to the new one.
                var user = UserContext.Current.User;
                user.Location = HttpContext.Current.Request.UserHostAddress;

                // Sets the language
                user.Language = System.Threading.Thread.CurrentThread.CurrentCulture.Name.Replace("-","").ToUpperInvariant();

                // Assign the system (year) from the route data (or default) to the user object associated with the current request.
                user.Year = UserContext.Current.GetYearFromRoute();

                //Check for maintenance Status
                Maintenance.GetMaintenanceStatus(UserContext.Current.PersistentSupport);

                CSGenio.framework.Log.Debug(Context.Request.RequestType + " " + Context.Request.Url.ToString());
            }
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (Configuration.ConfigVersion != null && Context.Session != null)
            {
                //Limpar a cache do current navigation
                CurrentNavigation.Destroy();
                //Limpar cache do user no start do pedido
                UserContext.Current.User = null;
                // Set the current module as the one coming from the URL.
                UserContext.Current.User.CurrentModule = Context.Request.RequestContext.RouteData.Values["module"] as string;


                //Create by [TMV] (30.09.2020)
                //Contais the rederection for eph form is they aren't fill
                //Filters to allow post rquest to submit values that can afect the ephOk status
                if (!UserContext.Current.User.EphOk && UserContext.Current.User.CurrentModule != "Public" && UserContext.Current.User.CurrentModule != "null")
                {
                    string actionName = Request.RequestContext.RouteData.GetRequiredString("action");

                    if (actionName != "GetEphFormAction")
                    {
                        List<string> possibleAction = (List<string>)Session[UserContext.Current.User.CurrentModule + "EPH_Action_Available"];

                        // Se está a vazio significa que tem de ser preenchido, vamos redirecionar para o controller responsavel
                        if (possibleAction == null || possibleAction != null && !possibleAction.Any(pActionName => string.Equals(pActionName, actionName, StringComparison.OrdinalIgnoreCase)))
                        {
                            if (possibleAction == null)
                            {
                                Session["CurrentAction"] = actionName;
                                Session["CurrentController"] = Request.RequestContext.RouteData.GetRequiredString("controller");
                            }
                            Context.Response.RedirectToRoute(new
                            {
                                controller = "Home",
                                action = "GetEphFormAction"
                            });

                            Response.End();
                            return;
                        }
                    }
                }

                System.Collections.Generic.List<string> exclusions = new System.Collections.Generic.List<string>() { "modelname", "fldname", "sort", "sortDir", "query", "error" };
                HttpRequestBase requestBase = new HttpRequestWrapper(Context.Request);
                HttpSessionStateBase sessionBase = new HttpSessionStateWrapper(Context.Session);

                if (Request.QueryString != null && Request.QueryString.AllKeys != null)
                {
                    foreach (string key in Request.QueryString.AllKeys)
                    {
                        // Removes Parameters from the query string associated with other functionalities
                        if (!string.IsNullOrEmpty(Request.QueryString[key]) && !exclusions.Contains(key) && key != null)
                            CurrentNavigation.getNavigation(requestBase, Context.Request.RequestContext.RouteData, sessionBase).SetValue(key, Request.QueryString[key]);
                    }
                }
            }
        }

        protected void Application_Error()
        {
            Exception ex = Server.GetLastError();
            if (ex is InvalidAuthenticationException)
            {
                FormsAuthentication.SignOut();
                UserContext.Destroy();
				System.Web.HttpContext.Current.Session.Abandon();
				//clean cookies for auth and sessionId from the current domain
                Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddDays(-1);
                System.Web.Configuration.SessionStateSection sessionStateSection = (System.Web.Configuration.SessionStateSection)System.Configuration.ConfigurationManager.GetSection("system.web/sessionState");
                Response.Cookies[sessionStateSection.CookieName].Expires = DateTime.Now.AddDays(-1);

                FormsAuthentication.RedirectToLoginPage();
                Response.End();
            }
            else if (ex is UserUnavailableException)
            {
                FormsAuthentication.SignOut();
                UserContext.Destroy();

                Response.Write(ex.Message);
                Response.End();
                //Response.Redirect("~/"); //<--- isto causa loops quando a autenticação é necessária na pagina inicial
            }
            else if (ex is HttpAntiForgeryException)
            {
                FormsAuthentication.SignOut();
                UserContext.Destroy();
                Response.Write(@Resources.Resources.PEDIMOS_DESCULPA__OC63848);
                Response.End();
            }

            var urlReferrer = Request.UrlReferrer != null ? Request.UrlReferrer.OriginalString : "NULL";
            CSGenio.framework.Log.Error(string.Format("Application_Error: {0}; {1}; UrlReferer:{2}; URL:{3}; ", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "", urlReferrer, Request.Url.OriginalString) + ex.ToString());
        }

        public class ModuleFilterAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (Configuration.ConfigVersion == null)
                    return;

                var u = UserContext.Current.User;
                string value = filterContext.RouteData.Values["module"] as string;

                //If its an authenticated user and our module is still Public, them initialize module to the first available
                if (!String.IsNullOrEmpty(value) && u != null)
                {
                    if(value.Equals("Public"))
                    {
                        List<Helpers.Menus.MenuEntry> modules =  Helpers.Menus.Menus.AvailableModules(u);
                        if(modules.Count > 0)
                            u.CurrentModule = modules[0].ID;
                    }
                    else
                        u.CurrentModule = value;
                    filterContext.RouteData.Values["System"] = u.Year;
                }

                filterContext.HttpContext.Items["page_load_metric"] = CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
                    new("Controller", filterContext.ActionDescriptor.ControllerDescriptor.ControllerName),
                    new("Action", filterContext.ActionDescriptor.ActionName),
                    new("Module", u?.CurrentModule),
                    new("Year", u?.Year)
                ]), "ms", "Time to load the page.");

                string actionId = Guid.NewGuid().ToString();
                filterContext.HttpContext.Items["log_scope"] = CSGenio.core.di.GenioDI.Log.SetContext(
                    AdaptivePropertyProvider.Create("user", new
                    {
                        user = u?.Name,
                        user_ip = u?.Location,
                        year = u?.Year,
                        ActionName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "." + filterContext.ActionDescriptor.ActionName,
                        ActionId = actionId
                    }));

#if DEBUG
				//Validate the AntiForgery token
                if (filterContext.HttpContext.Request.HttpMethod == "POST")
                {
                    //Except some actions
                    List<string> actionToExcept = new List<string>() { "OpenIdLogin", "OpenIdRegister", "WriteXptoFile" };
                    var matchAction = actionToExcept.FirstOrDefault(stringToCheck => stringToCheck.Contains(filterContext.RouteData.Values["action"].ToString()));
                    if (matchAction == null)
                    {
						var httpContext = filterContext.HttpContext;
						var cookie = httpContext.Request.Cookies[System.Web.Helpers.AntiForgeryConfig.CookieName];

						string formToken = null;
						if (httpContext.Request.Form.HasKeys() && httpContext.Request.Form.AllKeys.Contains("__RequestVerificationToken"))
							formToken = Convert.ToString(httpContext.Request.Form["__RequestVerificationToken"]);
						else formToken = httpContext.Request.Headers["__RequestVerificationToken"];

						System.Web.Helpers.AntiForgery.Validate(cookie != null ? cookie.Value : null, formToken);
					}
                }
#endif

                base.OnActionExecuting(filterContext);
            }

            public override void OnResultExecuted(ResultExecutedContext filterContext)
            {
                if (Configuration.ConfigVersion == null)
                    return;

                //end the metrics timer
                (filterContext.HttpContext.Items["page_load_metric"] as IDisposable)?.Dispose();
                //remove the log scope
                (filterContext.HttpContext.Items["log_scope"] as IDisposable)?.Dispose();

                string qAjaxId = filterContext.HttpContext.Request.Headers["QAjaxIdentifier"];
                if (!string.IsNullOrEmpty(qAjaxId))
                    filterContext.HttpContext.Response.AddHeader("QAjaxIdentifier", qAjaxId);

                // MH (07/09/2017) - Ensure that the transaction was not left open after processing the request. And if transaction is still open it will be closed automatically.
                if (UserContext.Current.PersistentSupport != null && !UserContext.Current.PersistentSupport.TransactionIsClosed)
                {
                    CSGenio.framework.Log.Error(string.Format("The transaction still open after the action was executed. The transaction will be closed automatically by the application. (URL: {0})",
                        filterContext.HttpContext.Request.Url));

                    try { UserContext.Current.PersistentSupport.closeTransaction(); }
                    catch(Exception ex) { CSGenio.framework.Log.Error(ex.ToString()); }
                }

                base.OnResultExecuted(filterContext);
            }
        }

        /// <summary>
        /// Contextual logging helper for Asp.Net Applications thread agility problem
        /// http://blog.marekstoj.com/2011/12/log4net-contextual-properties-and.html
        /// </summary>
        public class AdaptivePropertyProvider : log4net.Core.IFixingRequired
        {
            private const string PropertyNamePrefix = "log4net_app_";
            private readonly string _contextItem  = "";
            private readonly object _value;

            public AdaptivePropertyProvider(string propertyName, object value)
            {
                if (HttpContext.Current != null)
                {
                    _contextItem = PropertyNamePrefix + propertyName;
                    HttpContext.Current.Items[propertyName] = value;
                }
                _value = value;
            }

            public object GetFixedObject()
            {
                return ToString();
            }

            public override string ToString()
            {
                return HttpContext.Current
                    ?.Items[_contextItem]?.ToString()
                    ?? _value?.ToString()
                    ?? "";
            }

            public static object Create(string propertyName, object propertyValue)
            {
                if (propertyValue.GetType().IsPrimitive)
                    return new AdaptivePropertyProvider(propertyName, propertyValue);
                else if (propertyValue is Dictionary<string, object> dic)
                {
                    var res = new Dictionary<string, object>();
                    foreach (var prop in dic)
                        res.Add(prop.Key, new AdaptivePropertyProvider(propertyName, prop.Value));
                    return res;
                }
                else
                {
                    var res = new Dictionary<string, object>();
                    foreach (System.Reflection.PropertyInfo prop in propertyValue.GetType().GetProperties())
                        res.Add(prop.Name, new AdaptivePropertyProvider(propertyName, prop.GetValue(propertyValue)));
                    return res;
                }
            }
        }
    }
}
