using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace GenioMVC.Models.Navigation
{
    public static class CurrentNavigation
    {
        /// <summary>
        /// To ensure that the rendered URLs have the correct navigation ID
        /// </summary>
        /// <param name="routeData"></param>
        /// <param name="navId"></param>
        private static void updateRouteDataNavigationId(RouteData routeData, string navId)
        {
            if(routeData != null)
            {
                if (routeData.Values.ContainsKey("nav")) routeData.Values["nav"] = navId;
                else routeData.Values.Add("nav", navId);
            }
        }

        /// <summary>
        /// Accessor for the current navigation context
        /// </summary>
        public static NavigationContext getNavigation(HttpRequestBase Request, RouteData RouteData, HttpSessionStateBase Session)
        {
            checkBreadcrumbClick(Request, RouteData, Session);
            checkMenuClick(Request, RouteData, Session);
            if (UserContext.Current.CurrentNavigation == null)
            {
                string nav = getNavigationId(Request, RouteData);
                if (!UserContext.Current.NavigationsContainsKey(nav)) //After 20 min of inactivity, the SessionState was removed
                    nav = UserContext.Current.NavigationsAdd(new NavigationContext());

                if (UserContext.Current.NavigationsGet(nav, out UserContext.Current.CurrentNavigation))
                    UserContext.Current.CurrentNavigation.UpdateTimeout(Session.Timeout);
                else
                {
                    CSGenio.framework.Log.Error("Error getting current request navigation");
                    UserContext.Current.CurrentNavigation = new NavigationContext();
                }

                UserContext.Current.RemoveExpiredNavigations();
            }
            updateRouteDataNavigationId(RouteData, UserContext.Current.CurrentNavigation.NavigationId);
            return UserContext.Current.CurrentNavigation;
        }

        /// <summary>
        /// Apagar da cache o navigation atual
        /// </summary>
        public static void Destroy()
        {
            UserContext.Current.CurrentNavigation = null;
        }

        /// <summary>
        /// Devolve Id da navegação atual
        /// </summary>
        /// <returns>Id ou "Empty" caso se não encontra</returns>
        public static string getNavigationId(HttpRequestBase Request, RouteData RouteData)
        {
            //remover warnings de null
            if (Request == null)
                return string.Empty;
            if (Request.QueryString == null)
                return string.Empty;
            if (Request.QueryString.AllKeys == null)
                return string.Empty;
            if (RouteData == null)
                return string.Empty;
            if (RouteData.Values == null)
                return string.Empty;
            if (RouteData.Values.Keys == null)
                return string.Empty;

            var navs = Request.QueryString.GetValues("nav");
            string nav = navs != null ? navs.First() : string.Empty;
            //Caso da abertura do menu, o novo id fica no RouteData (porque QueryString is read only e não permite alterações)
            if (RouteData.Values.ContainsKey("nav")) nav = (string)RouteData.Values["nav"];
            //Casos quando em javascript (manual code) feito window.location = link, ou algo semelhante,
            //como não podemos change o link to acrescentar navId, vamos verificar se URL anterior tem Id
            if (string.IsNullOrEmpty(nav) && Request.UrlReferrer != null)
                nav = System.Web.HttpUtility.ParseQueryString(Request.UrlReferrer.Query)["nav"];

            return nav;
        }

        /// <summary>
        /// Gera nova navegação to o request.
        /// 1 Menu <=> 1 Navegação
        /// </summary>
        private static void checkMenuClick(HttpRequestBase Request, RouteData RouteData, HttpSessionStateBase Session)
        {
            if (UserContext.Current.CurrentNavigation != null) return;//Só no start do request que precisamos inicializar o navigation

            //Se já está no RouteData então a nova navegação já foi criada
            if (RouteData == null)
                return;
            if (RouteData.Values == null)
                return;
            if (RouteData.Values.Keys == null)
                return;
            if (RouteData.Values.Keys.Contains("newMenu"))
                return;

            //remover warnings de null
            if (Request == null)
                return;
            if (Request.QueryString == null)
                return;
            if (Request.QueryString.AllKeys == null)
                return;
            //newMenu - adicionado a QueryString na renderização dos menus assim sabemos quando foi aberto um novo menu
            if (!Request.QueryString.AllKeys.Contains("newMenu"))
                return;

            UserContext.Current.CurrentNavigation = new NavigationContext(Session.Timeout);
            string newId = UserContext.Current.NavigationsAdd(UserContext.Current.CurrentNavigation);

            updateRouteDataNavigationId(RouteData, newId);
            //Mark that new Navigation has already been created.
            RouteData.Values.Add("newMenu", true);
        }

        /// <summary>
        /// Caso se foi clicado no breadcrumb,
        /// vamos duplicate navegação to casos de ter aberto em nova janela.
        /// </summary>
        private static void checkBreadcrumbClick(HttpRequestBase Request, RouteData RouteData, HttpSessionStateBase Session)
        {
            if (UserContext.Current.CurrentNavigation != null) return;//Só no start do request que precisamos inicializar o navigation

            //remover warnings de null
            if (Request == null)
                return;
            if (Request.QueryString == null)
                return;
            if (Request.QueryString.AllKeys == null)
                return;
            if (RouteData == null)
                return;
            if (RouteData.Values == null)
                return;
            if (RouteData.Values.Keys == null)
                return;

            //bc - adicionado a QueryString na renderização dos Breadcrumbs
            if (!Request.QueryString.AllKeys.Contains("bc") || RouteData.Values.Keys.Contains("bc")) return;
            string navId = cloneNavigation(getNavigationId(Request, RouteData));
            if (!UserContext.Current.NavigationsGet(navId, out UserContext.Current.CurrentNavigation))
            {
                CSGenio.framework.Log.Error("Error getting current request navigation - Breadcrumb");
                UserContext.Current.CurrentNavigation = new NavigationContext();
            }
            UserContext.Current.CurrentNavigation.UpdateTimeout(Session.Timeout);
            updateRouteDataNavigationId(RouteData, UserContext.Current.CurrentNavigation.NavigationId);

            //Remover os niveis a cima do selecionado
            string controller = RouteData.Values["controller"].ToString();
            string action = RouteData.Values["action"].ToString();
            string id = RouteData.Values.ContainsKey("id") ? RouteData.Values["id"].ToString() : String.Empty;
            while (UserContext.Current.CurrentNavigation.CurrentLevel.Level > 0)
            {
                NavigationLocation location = UserContext.Current.CurrentNavigation.CurrentLevel.Location;
                bool validId = true;
                if (!string.IsNullOrEmpty(id) && location.RoutedValues != null)
                {
                    RouteValueDictionary routes = location.getRoutes(new { });
                    if (routes.ContainsKey("id") && routes["id"].ToString() != id)
                        validId = false;
                }

                if (validId && location.Controller == controller && location.Action == action) break;
                else UserContext.Current.CurrentNavigation.RemoveHistoryLevel();
            }

            // Mark that Navigation has already been cloned
            RouteData.Values.Add("bc", true);
        }

        /// <summary>
        /// Clonar navegação dum determinado Id.
        /// Se source Id não exists cria nova navegação.
        /// Caso se novo Id exists, gera um diferente
        /// </summary>
        /// <param name="source">Id a clonar</param>
        /// <returns>Id atribuida ao clone</returns>
        public static string cloneNavigation(string source)
        {
            var newId = UserContext.Current.NavigationsClone(source, out NavigationContext _);
            return newId;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cwname">Current window name</param>
        /// <returns></returns>
        public static object newWindow(string cwname, HttpRequestBase Request, RouteData RouteData, HttpSessionStateBase Session)
        {
            string nav = cwname,
                newId = String.Empty;
            if (string.IsNullOrEmpty(nav))
                nav = getNavigationId(Request, RouteData);

            if (string.IsNullOrEmpty(nav))
                newId = UserContext.Current.NavigationsAdd(new NavigationContext(Session.Timeout));
            else
            {
                if (UserContext.Current.NavigationsGet(nav, out NavigationContext navInNew) && navInNew.History.Any(h => h.FormMode == FormMode.New))
                    return new { Success = false, oldNav = nav, newNav = createWinId(9), errorMessage = Resources.Resources.IT_IS_NOT_ALLOWED_TO02562 };

                newId = cloneNavigation(nav);
                if (UserContext.Current.NavigationsGet(nav, out NavigationContext navigation))
                    navigation.UpdateTimeout(Session.Timeout);
            }

            return new { Success = true, oldNav = nav, newNav = newId };
        }

        /// <summary>
        /// Gerar novo ID da navegação.
        /// Replicado a função que está no javascript.
        /// </summary>
        /// <param name="Idlen">Largura do novo ID, por default igual a 8 characteres</param>
        /// <returns>ID com characteres: 0-9|a-z|A-Z</returns>
        public static string createWinId(int Idlen = 8)
        {
            //Generate N length code
            return NavigationContext.createWinId(Idlen);
        }
    }
}
