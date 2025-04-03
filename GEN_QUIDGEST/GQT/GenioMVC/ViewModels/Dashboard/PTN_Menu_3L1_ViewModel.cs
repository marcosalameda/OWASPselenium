using System.Collections.Generic;

using CSGenio.business;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Dashboard
{
	/// <summary>
	/// PTN_Menu_3L1 Dashboard Viewmodel
	/// </summary>
	public class PTN_Menu_3L1_ViewModel : DashboardViewModel
	{

		public PTN_Menu_3L1_ViewModel(GenioMVC.Models.Navigation.NavigationContext navigation)
		{
			DashboardTitle = Resources.Resources.DASHBOARD51597;
			RoleToShow = CSGenio.framework.Role.ROLE_1;
			Navigation = navigation;
			Action = "PTN_Menu_3L1";
			uuid = "4ba4f954-073b-4474-b7e9-6685eeec4e3b";

			m_singletonWidgetProviders = new Dictionary<WidgetType, WidgetProvider>()
			{
				{
					WidgetType.Bookmark,
					new BookmarkWidgetProvider
					{
						Order = 14,
						Width = 2,
						Height = 2,
						Required = false,
						Visible = false,
						ColoredLeftBorder = false,
						ButtonText = Resources.Resources.IR_PARA07866,
						Navigation = Navigation,
					}
				},
			};

			m_widgetProviders = new List<WidgetProvider>()
			{
				new CustomWidgetProvider<CSGenio.business.CSGenioAcmpny>
				{
					Id = "COLAB",
					Order = 4,
					Width = 6,
					Height = 6,
					Required = false,
					Visible = false,
					Role = CSGenio.framework.Role.AUTHORIZED,
					Title = Resources.Resources.EMPLOYEES22728,
					Group = "_GROUP02",
					Form = "WID_COLA",
					Component = "QFormWidCola",
					RowsSelector = GenioMVC.Models.ModelBase.All<CSGenio.business.CSGenioAcmpny>,
					ColoredLeftBorder = false,
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Split
				},
				new CustomWidgetProvider<CSGenio.business.DbArea>
				{
					Id = "WID_EQUI",
					Order = 11,
					Width = 6,
					Height = 4,
					Required = false,
					Visible = false,
					Role = CSGenio.framework.Role.AUTHORIZED,
					Title = Resources.Resources.EQUIPMENT03632,
					Group = "_GROUP01",
					Form = "WID_EQUI",
					Component = "QFormWidEqui",
					ColoredLeftBorder = false,
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Aggregate
				},
				new CustomWidgetProvider<CSGenio.business.DbArea>
				{
					Id = "EMPLOY",
					Order = 5,
					Width = 6,
					Height = 6,
					Required = false,
					Visible = false,
					Role = CSGenio.framework.Role.AUTHORIZED,
					Title = Resources.Resources.ALL_EMPLOYEES64244,
					Group = "_GROUP02",
					Form = "WID_PESS",
					Component = "QFormWidPess",
					ColoredLeftBorder = false,
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Both
				},
				new CustomWidgetProvider<CSGenio.business.CSGenioAequip>
				{
					Id = "WID_INFO_EQUIP",
					Order = 12,
					Width = 6,
					Height = 4,
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.AUTHORIZED,
					Title = Resources.Resources.EQUIPMENT03632,
					Group = "_GROUP01",
					Form = "WID_IEQU",
					Component = "QFormWidIequ",
					RowsSelector = GenioMVC.Models.ModelBase.All<CSGenio.business.CSGenioAequip>,
					ColoredLeftBorder = false,
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Aggregate
				},
				new CustomWidgetProvider<CSGenio.business.DbArea>
				{
					Id = "GRAPH_COUNT",
					Order = 3,
					Width = 6,
					Height = 4,
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.ROLE_1,
					Title = Resources.Resources.COMPANHY_S_PEOPLE_CO22385,
					Group = "_GROUP01",
					Form = "WID_GRAP",
					Component = "QFormWidGrap",
					ColoredLeftBorder = false,
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Aggregate
				},
			};

			m_independentWidgetInstances = new List<Widget>()
			{
				new AlertWidget((new Alerts_ViewModel(Navigation)).GenAlert_NCARDSDANGER)
				{
					Id = "ALERT_NCARDSDANGER",
					Order = 7,
					Width = 2,
					Height = 2,
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.ROLE_1,
					Title = Resources.Resources.ALERT_141649,
					Idalert = "NCARDSDANGER",
					Group = "_ALERTS",
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
				},
				new AlertWidget((new Alerts_ViewModel(Navigation)).GenAlert_NCARDSSUCESS)
				{
					Id = "ALERT_NCARDSSUCESS",
					Order = 9,
					Width = 2,
					Height = 2,
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.ROLE_1,
					Title = Resources.Resources.ALERT_324982,
					Idalert = "NCARDSSUCESS",
					Group = "_ALERTS",
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
				},
				new AlertWidget((new Alerts_ViewModel(Navigation)).GenAlert_NCARDSINFO)
				{
					Id = "ALERT_NCARDSINFO",
					Order = 8,
					Width = 2,
					Height = 2,
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.ROLE_1,
					Title = Resources.Resources.ALERT_240484,
					Idalert = "NCARDSINFO",
					Group = "_ALERTS",
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
				},
				new AlertWidget((new Alerts_ViewModel(Navigation)).GenAlert_NCARDSWARNING)
				{
					Id = "ALERT_NCARDSWARNING",
					Order = 10,
					Width = 2,
					Height = 2,
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.ROLE_1,
					Title = Resources.Resources.ALERT_444946,
					Idalert = "NCARDSWARNING",
					Group = "_ALERTS",
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
				},
				new MenuWidget
				{
					Id = "Menu_111",
					Order = 17,
					Width = 2,
					Height = 2,
					Required = false,
					Visible = true,
					ColoredLeftBorder = false,
					ButtonText = Resources.Resources.IR_PARA07866,
					Title = Resources.Resources.MENU_330138,
					Group = "_MENUS",
					Module = "PTN",
					Path = "PTN" + " > " + string.Join(" > ", GenioMVC.Helpers.Menus.Menus.MenuTextPath("PTN", "111")),
					MenuEntry = GenioMVC.Helpers.Menus.Menus.FindMenu("PTN", "111")
				},
				new MenuWidget
				{
					Id = "Menu_1211",
					Order = 15,
					Width = 2,
					Height = 2,
					Required = false,
					Visible = true,
					ColoredLeftBorder = false,
					ButtonText = Resources.Resources.IR_PARA07866,
					Title = Resources.Resources.MENU_136496,
					Group = "_MENUS",
					Module = "PTN",
					Path = "PTN" + " > " + string.Join(" > ", GenioMVC.Helpers.Menus.Menus.MenuTextPath("PTN", "1211")),
					MenuEntry = GenioMVC.Helpers.Menus.Menus.FindMenu("PTN", "1211")
				},
				new MenuWidget
				{
					Id = "Menu_441",
					Order = 19,
					Width = 2,
					Height = 2,
					Required = false,
					Visible = true,
					ColoredLeftBorder = false,
					ButtonText = Resources.Resources.IR_PARA07866,
					Title = Resources.Resources.MENU_529532,
					Group = "_MENUS",
					Module = "PTN",
					Path = "PTN" + " > " + string.Join(" > ", GenioMVC.Helpers.Menus.Menus.MenuTextPath("PTN", "441")),
					MenuEntry = GenioMVC.Helpers.Menus.Menus.FindMenu("PTN", "441")
				},
				new MenuWidget
				{
					Id = "Menu_211",
					Order = 16,
					Width = 2,
					Height = 2,
					Required = false,
					Visible = true,
					ColoredLeftBorder = false,
					ButtonText = Resources.Resources.IR_PARA07866,
					Title = Resources.Resources.MENU_229897,
					Group = "_MENUS",
					Module = "PTN",
					Path = "PTN" + " > " + string.Join(" > ", GenioMVC.Helpers.Menus.Menus.MenuTextPath("PTN", "211")),
					MenuEntry = GenioMVC.Helpers.Menus.Menus.FindMenu("PTN", "211")
				},
				new MenuWidget
				{
					Id = "Menu_REPAIR_LIST",
					Order = 18,
					Width = 2,
					Height = 2,
					Required = false,
					Visible = true,
					ColoredLeftBorder = false,
					ButtonText = Resources.Resources.IR_PARA07866,
					Title = Resources.Resources.MENU_432243,
					Group = "_MENUS",
					Module = "PTN",
					Path = "PTN" + " > " + string.Join(" > ", GenioMVC.Helpers.Menus.Menus.MenuTextPath("PTN", "REPAIR_LIST")),
					MenuEntry = GenioMVC.Helpers.Menus.Menus.FindMenu("PTN", "REPAIR_LIST")
				},
			};

			WidgetGroups = new List<WidgetGroup>()
			{
				new WidgetGroup()
				{
					Identifier = "BOOKMARKS",
					Order = 14,
					Title = Resources.Resources.FAVORITOS12992,
				},
				new WidgetGroup()
				{
					Identifier = "_GROUP02",
					Order = 2,
					Title = Resources.Resources.LISTS54900,
				},
				new WidgetGroup()
				{
					Identifier = "_MENUS",
					Order = 13,
					Title = Resources.Resources.MENUS09526,
				},
				new WidgetGroup()
				{
					Identifier = "_GROUP01",
					Order = 1,
					Title = Resources.Resources.GRAPHS20473,
				},
				new WidgetGroup()
				{
					Identifier = "_ALERTS",
					Order = 6,
					Title = Resources.Resources.ALERTS30407,
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
