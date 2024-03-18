using Microsoft.AspNetCore.WebUtilities;

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
			if (routeData != null)
			{
				if (routeData.Values.ContainsKey("nav"))
					routeData.Values["nav"] = navId;
				else
					routeData.Values.Add("nav", navId);
			}
		}


        /// <summary>
        /// Devolve Id da navegação atual
        /// </summary>
        /// <returns>Id ou "Empty" caso se não encontra</returns>
        public static string getNavigationId(HttpRequest Request, RouteData RouteData)
		{
			// Remover warnings de null
			if (Request == null)
				return string.Empty;
			if (!Request.QueryString.HasValue)
				return string.Empty;
			if (RouteData == null)
				return string.Empty;
			if (RouteData.Values == null)
				return string.Empty;
			if (RouteData.Values.Keys == null)
				return string.Empty;

			var navs = Request.Query["nav"];
			string nav = navs.FirstOrDefault(string.Empty);

			// Caso da abertura do menu, o novo id fica no RouteData (porque QueryString is read only e não permite alterações)
			if (RouteData.Values.TryGetValue("nav", out object? obj))
				nav = obj as string ?? string.Empty;

			// Casos quando em javascript (manual code) feito window.location = link, ou algo semelhante,
			// como não podemos change o link to acrescentar navId, vamos verificar se URL anterior tem Id
			if (string.IsNullOrEmpty(nav))
			{
				var referrer = Request.GetTypedHeaders().Referer;
				if (referrer != null)
					nav = QueryHelpers.ParseQuery(referrer.Query)["nav"];
			}

			return nav ?? string.Empty;
		}

		/// <summary>
		/// Clonar navegação dum determinado Id.
		/// Se source Id não exists cria nova navegação.
		/// Caso se novo Id exists, gera um diferente
		/// </summary>
		/// <param name="source">Id a clonar</param>
		/// <returns>Id atribuida ao clone</returns>
		public static string cloneNavigation(string source, UserContext context)
		{
			var newId = context.NavigationsClone(source, out NavigationContext _);
			return newId;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="cwname">Current window name</param>
		/// <returns></returns>
		public static object newWindow(UserContext userContext, string cwname, HttpRequest Request, RouteData RouteData, int timeout)
		{
			string nav = cwname,
				newId = String.Empty;
			if (string.IsNullOrEmpty(nav))
				nav = getNavigationId(Request, RouteData);

			if (string.IsNullOrEmpty(nav))
				newId = userContext.NavigationsAdd(new NavigationContext(userContext, timeout));
			else
			{
				if (userContext.NavigationsGet(nav, out NavigationContext navInNew) && navInNew.History.Any(h => h.FormMode == FormMode.New))
					return new { Success = false, oldNav = nav, newNav = createWinId(9), errorMessage = Resources.Resources.IT_IS_NOT_ALLOWED_TO02562 };

				newId = cloneNavigation(nav, userContext);
				if (userContext.NavigationsGet(nav, out NavigationContext navigation))
					navigation.UpdateTimeout(timeout);
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
			// Generate N length code
			return NavigationContext.createWinId(Idlen);
		}
	}
}
