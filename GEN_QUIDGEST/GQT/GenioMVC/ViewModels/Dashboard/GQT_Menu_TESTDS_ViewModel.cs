using System.Collections.Generic;

using CSGenio.business;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Dashboard
{
	/// <summary>
	/// GQT_Menu_TESTDS Dashboard Viewmodel
	/// </summary>
	public class GQT_Menu_TESTDS_ViewModel : DashboardViewModel
	{

		public GQT_Menu_TESTDS_ViewModel(GenioMVC.Models.Navigation.NavigationContext navigation)
		{
			DashboardTitle = Resources.Resources.DASHBOARD51597;
			RoleToShow = CSGenio.framework.Role.ROLE_1;
			Navigation = navigation;
			Action = "GQT_Menu_TESTDS";
			uuid = "aad28ea1-08ba-4335-9a79-6153ab294c7d";

			m_singletonWidgetProviders = new Dictionary<WidgetType, WidgetProvider>()
			{
				{
					WidgetType.Bookmark,
					new BookmarkWidgetProvider
					{
						Order = 5,
						Width = 2,
						Height = 2,
						Required = false,
						Visible = true,
						ColoredLeftBorder = true,
						ButtonText = Resources.Resources.IR_PARA07866,
						Navigation = Navigation,
					}
				},
			};

			m_widgetProviders = new List<WidgetProvider>()
			{
			};

			m_independentWidgetInstances = new List<Widget>()
			{
				new AlertWidget((new Alerts_ViewModel(Navigation)).GenAlert_NOTUSEDITEMS)
				{
					Id = "ALERT_NOTUSEDITEMS",
					Order = 4,
					Width = 2,
					Height = 2,
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.AUTHORIZED,
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
					Required = false,
					Visible = true,
					ColoredLeftBorder = false,
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
					Required = false,
					Visible = true,
					ColoredLeftBorder = true,
					ButtonText = Resources.Resources.IR_PARA07866,
					Title = Resources.Resources.MY_LENDINGS58139,
					Group = "_LENDINGS",
					Module = "GQT",
					Path = "GQT" + " > " + string.Join(" > ", GenioMVC.Helpers.Menus.Menus.MenuTextPath("GQT", "121")),
					MenuEntry = GenioMVC.Helpers.Menus.Menus.FindMenu("GQT", "121")
				},
			};

			WidgetGroups = new List<WidgetGroup>()
			{
				new WidgetGroup()
				{
					Identifier = "BOOKMARKS",
					Order = 5,
					Title = Resources.Resources.FAVORITOS12992,
				},
				new WidgetGroup()
				{
					Identifier = "_LENDINGS",
					Order = 1,
					Title = Resources.Resources.LENDINGS30501,
				},
				new WidgetGroup()
				{
					Identifier = "_ITEMS",
					Order = 6,
					Title = Resources.Resources.ITEMS55321,
				},
			};

			Texts = new Dictionary<string, string>()
			{
				{ "DELETE", Resources.Resources.APAGAR04097 },
				{ "REFRESH", Resources.Resources.REFRESCAR60171 },
				{ "LOADING", Resources.Resources.A_CARREGAR___34906 },
				{ "ALERT_WIDGET", Resources.Resources.ALERTAS10283 },
				{ "ADD", Resources.Resources.ADICIONAR14072 },
				{ "HELP", Resources.Resources.PARA_ADICIONAR_UM_WI63588 },
				{ "OF", Resources.Resources.OF21852 },
				{ "PREV_PAGE", Resources.Resources.PAGINA_ANTERIOR17471 },
				{ "NEXT_PAGE", Resources.Resources.PAGINA_SEGUINTE34153 },
				{ "NO_DATA", Resources.Resources.SEM_DADOS_PARA_MOSTR24928 },
				{ "ADD_WIDGET", Resources.Resources.ADICIONAR_WIDGET21299 },
			};
		}
	}
}
