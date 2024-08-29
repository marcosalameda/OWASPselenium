using System.Collections.Generic;
using System.Data;
using System.Linq;

using CSGenio.framework;
using GenioMVC.Helpers.Menus;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Home
{
	public class HomePageDefinition
	{
		public string Identifier { get; set; }

		public bool Public { get; set; }

		public string Module { get; set; }

		public int Order { get; set; }

		public string Menu { get; set; }

		public string Menu_Id { get; set; }

		public string MenuRoleId { get; set; }

		public string Form { get; set; }

		public string Controller { get; set; }

		[Newtonsoft.Json.JsonIgnore]
		public CSGenio.framework.Role Role { get; set; }
	}

	public class HomePage_ViewModel : ViewModelBase
	{
		public bool IsGuestUser { get; private set; }

		private static readonly List<HomePageDefinition> homePages = new List<HomePageDefinition>()
		{
			new HomePageDefinition()
			{
				Identifier = "HomepageGQT",
				Public = true,
				Module = "GQT",
				Order = 1,
				Menu = "",
				Menu_Id = "",
				MenuRoleId = "",
				Controller = "GLOB",
				Form = "HOMEG",
				Role = CSGenio.framework.Role.UNAUTHORIZED
			},
			new HomePageDefinition()
			{
				Identifier = "HomepageSTY",
				Public = true,
				Module = "STY",
				Order = 1,
				Menu = "11",
				Menu_Id = "OVERVIEW",
				MenuRoleId = " 1",
				Controller = "Home",
				Form = "",
				Role = CSGenio.framework.Role.UNAUTHORIZED
			},
		};

		[Newtonsoft.Json.JsonIgnore]
		public static List<HomePageDefinition> HomePages { get { return homePages; } }

		public string HomePageController { get; private set; }

		public string HomePageAction { get; private set; }

		public HomePageDefinition HomePageDef { get; private set; }

		public bool HasHomePage { get { return HomePageDef != null && !string.IsNullOrEmpty(HomePageController) && !string.IsNullOrEmpty(HomePageAction); } }

		public HomePage_ViewModel(NavigationContext current_navigation, bool isGuestUser)
		{
			this.Navigation = current_navigation;
			this.IsGuestUser = isGuestUser;
		}

		public Newtonsoft.Json.Linq.JObject GetAvaibleHomePages(List<string> modules)
		{
			var user = UserContext.Current.User;
			var result = new Newtonsoft.Json.Linq.JObject();

			// Home pages of specific module
			var avaiblePages = homePages.Where(hp => modules.Contains(hp.Module)).OrderBy(hp => hp.Order).ToList();

			// Home page before Login
			if (IsGuestUser)
				avaiblePages.AddRange(homePages.Where(hp => hp.Public && hp.Module == "Public").OrderBy(hp => hp.Order));

			foreach (var hPage in avaiblePages.Distinct())
			{
				if (hPage.Public || user.VerifyAccess(hPage.Role, hPage.Module))
				{
					if (!string.IsNullOrEmpty(hPage.Menu))
					{
						// Check if user has access to this menu
						MenuEntry menu = new MenuEntry() { RoleId = hPage.MenuRoleId };
						if (!string.IsNullOrEmpty(menu.RoleId) && !menu.Allows(user, hPage.Module))
							continue;
					}

					if (!result.ContainsKey(hPage.Module))
						result.Add(new Newtonsoft.Json.Linq.JProperty(hPage.Module, Newtonsoft.Json.Linq.JToken.FromObject(hPage)));
				}
			}

			return result;
		}

		public void Load()
		{
			var user = UserContext.Current.User;
			var module = user.CurrentModule ?? string.Empty;

			// Home pages of specific module
			var avaiblePages = homePages.Where(hp => hp.Module == module).OrderBy(hp => hp.Order).ToList();

			// Home page before Login
			if (IsGuestUser)
				avaiblePages.AddRange(homePages.Where(hp => hp.Public && hp.Module == "Public").OrderBy(hp => hp.Order));

			foreach (var hPage in avaiblePages.Distinct())
			{
				if (hPage.Public || user.VerifyAccess(hPage.Role, module))
				{
					if (!string.IsNullOrEmpty(hPage.Menu))
					{
						MenuEntry menu = null;
						var menuId = hPage.Menu.Substring(0, 1);
						bool nextHomePage = false;

						try
						{
							menu = Menus.FindMenu(hPage.Module, menuId);
						}
						catch
						{
							continue;
						}

						if (menu != null)
						{
							if (!string.IsNullOrEmpty(menu.RoleId) && !menu.Allows(user, hPage.Module))
								continue;

							while (hPage.Menu != menuId && menu.ID != hPage.Menu_Id)
							{
								menuId = hPage.Menu.Substring(0, menuId.Length + 1);
								menu = (menu.Children ?? new List<MenuEntry>()).Find(m => m.ID == hPage.Menu_Id || m.ID == menuId);

								// Only menu branches that have the AccessLevel
								if (menu == null || (!string.IsNullOrEmpty(menu.RoleId) && !menu.Allows(user, hPage.Module)))
								{
									nextHomePage = true;
									break;
								}
								// If there are selection with conditions, the paths in menus.xml are ignored
								// Example: a list with path 311 in which there is an SC number 31, in the xml the list has path 31
								else if (menu != null && (menu.Action_MVC == hPage.Module + "_Menu_" + hPage.Menu_Id || menu.Action_MVC == hPage.Module + "_Menu_" + hPage.Menu))
									break;
							}
						}

						if (nextHomePage || menu == null)
							continue;

						HomePageDef = hPage;
						HomePageController = menu.Controller;
						HomePageAction = menu.Action_MVC;

						break;
					}
					else if (!string.IsNullOrEmpty(hPage.Form))
					{
						HomePageDef = hPage;
						HomePageController = hPage.Controller;
						HomePageAction = hPage.Form + "_Show";
						break;
					}
				}
			}
		}
	}
}
