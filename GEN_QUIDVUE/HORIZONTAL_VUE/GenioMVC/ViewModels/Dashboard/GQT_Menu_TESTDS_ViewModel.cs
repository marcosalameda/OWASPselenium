using System.Collections.Generic;
using System.Text.Json.Serialization;

using CSGenio.business;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Dashboard
{
	/// <summary>
	/// GQT_Menu_TESTDS Dashboard Viewmodel
	/// </summary>
	public class GQT_Menu_TESTDS_ViewModel : DashboardViewModel
	{
		[JsonPropertyName("uuid")]
		public override string Uuid => "aad28ea1-08ba-4335-9a79-6153ab294c7d";

		public GQT_Menu_TESTDS_ViewModel(UserContext userContext): base(userContext)
		{
			GenioMVC.Models.Glob glob = GenioMVC.Models.Glob.GetGlob(userContext);
			RoleToShow = CSGenio.framework.Role.ROLE_1;

			SingletonWidgetProviders = new Dictionary<WidgetType, WidgetProvider>()
			{
				{
					WidgetType.Bookmark,
					new BookmarkWidgetProvider
					{
						Order = 5,
						Width = 2,
						Height = 2,
						Style = "",
						Required = false,
						Visible = true,
						ButtonText = Resources.Resources.IR_PARA07866
					}
				},
			};

			WidgetProviders =
			[
			];

			IndependentWidgetInstances =
			[
				new AlertWidget((new Alerts_ViewModel(m_userContext)).GenAlert_NOTUSEDITEMS)
				{
					Id = "ALERT_NOTUSEDITEMS",
					Order = 4,
					Width = 2,
					Height = 2,
					ApplyColorTo = AlertColorTarget.Border,
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.AUTHORIZED,
					Module = "GQT",
					Title = Resources.Resources.UNUSED_ITEMS37130,
					Idalert = "NOTUSEDITEMS",
					Group = "_ITEMS",
					RefreshMode = WidgetRefreshMode.Manual,
					UsesCache = false,
				},
				new MenuWidget
				{
					Id = "Menu_111",
					Order = 2,
					Width = 2,
					Height = 2,
					Style = "",
					BorderStyle = "",
					RenderSubmenus = false,
					Required = false,
					Visible = true,
					ButtonText = Resources.Resources.IR_PARA07866,
					Title = Resources.Resources.ALL_LENDINGS09931,
					Group = "_LENDINGS",
					Module = "GQT",
					Path = "GQT" + " > " + string.Join(" > ", GenioMVC.Helpers.Menus.Menus.MenuTextPath("GQT", "111")),
					MenuEntry = GenioMVC.Helpers.Menus.Menus.FindMenu("GQT", "111")
				},
				new MenuWidget
				{
					Id = "Menu_121",
					Order = 3,
					Width = 2,
					Height = 2,
					Style = "",
					BorderStyle = "info",
					RenderSubmenus = false,
					Required = false,
					Visible = true,
					ButtonText = Resources.Resources.IR_PARA07866,
					Title = Resources.Resources.MY_LENDINGS58139,
					Group = "_LENDINGS",
					Module = "GQT",
					Path = "GQT" + " > " + string.Join(" > ", GenioMVC.Helpers.Menus.Menus.MenuTextPath("GQT", "121")),
					MenuEntry = GenioMVC.Helpers.Menus.Menus.FindMenu("GQT", "121")
				},
			];
		}


	}
}
