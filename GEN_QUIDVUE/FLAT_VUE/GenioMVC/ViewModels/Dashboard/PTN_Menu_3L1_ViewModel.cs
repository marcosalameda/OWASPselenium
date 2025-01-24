using System.Collections.Generic;

using CSGenio.business;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Dashboard
{
	/// <summary>
	/// PTN_Menu_3L1 Dashboard Viewmodel
	/// </summary>
	public class PTN_Menu_3L1_ViewModel : DashboardViewModel
	{
		public override string Uuid => "4ba4f954-073b-4474-b7e9-6685eeec4e3b";

		public PTN_Menu_3L1_ViewModel(UserContext userContext): base(userContext)
		{
			GenioMVC.Models.Glob glob = GenioMVC.Models.Glob.GetGlob(userContext);
			RoleToShow = CSGenio.framework.Role.ROLE_1;

			SingletonWidgetProviders = new Dictionary<WidgetType, WidgetProvider>()
			{
				{
					WidgetType.Bookmark,
					new BookmarkWidgetProvider
					{
						Order = 14,
						Width = 2,
						Height = 2,
						Style = "default",
						Required = false,
						Visible = false,
						ButtonText = Resources.Resources.IR_PARA07866
					}
				},
			};

			WidgetProviders =
			[
				new CustomWidgetProvider<CSGenio.business.CSGenioAcmpny>
{
					Id = "COLAB",
					Order = 4,
					Width = 6,
					Height = 6,
					BorderStyle = "",
					Required = false,
					Visible = false,
					Role = CSGenio.framework.Role.AUTHORIZED,
					Module = "PTN",
					Title = Resources.Resources.EMPLOYEES22728,
					Group = "_GROUP02",
					Form = "WID_COLA",
					Component = "QFormWidCola",
					RowsSelector = GenioMVC.Models.ModelBase.All<CSGenio.business.CSGenioAcmpny>,
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
					BorderStyle = "",
					Required = false,
					Visible = false,
					Role = CSGenio.framework.Role.AUTHORIZED,
					Module = "PTN",
					Title = Resources.Resources.EQUIPMENT03632,
					Group = "_GROUP01",
					Form = "WID_EQUI",
					Component = "QFormWidEqui",
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
					BorderStyle = "",
					Required = false,
					Visible = false,
					Role = CSGenio.framework.Role.AUTHORIZED,
					Module = "PTN",
					Title = Resources.Resources.ALL_EMPLOYEES64244,
					Group = "_GROUP02",
					Form = "WID_PESS",
					Component = "QFormWidPess",
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
					BorderStyle = "",
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.AUTHORIZED,
					Module = "PTN",
					Title = Resources.Resources.EQUIPMENT03632,
					Group = "_GROUP01",
					Form = "WID_IEQU",
					Component = "QFormWidIequ",
					RowsSelector = GenioMVC.Models.ModelBase.All<CSGenio.business.CSGenioAequip>,
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
					BorderStyle = "",
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.ROLE_1,
					Module = "PTN",
					Title = Resources.Resources.COMPANHY_S_PEOPLE_CO22385,
					Group = "_GROUP01",
					Form = "WID_GRAP",
					Component = "QFormWidGrap",
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Aggregate
				},
			];

			IndependentWidgetInstances =
			[
				new AlertWidget((new Alerts_ViewModel(m_userContext)).GenAlert_NCARDSDANGER)
				{
					Id = "ALERT_NCARDSDANGER",
					Order = 7,
					Width = 2,
					Height = 2,
					ApplyColorTo = AlertColorTarget.Border,
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.ROLE_1,
					Module = "PTN",
					Title = Resources.Resources.ALERT_141649,
					Idalert = "NCARDSDANGER",
					Group = "_ALERTS",
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
				},
				new AlertWidget((new Alerts_ViewModel(m_userContext)).GenAlert_NCARDSSUCESS)
				{
					Id = "ALERT_NCARDSSUCESS",
					Order = 9,
					Width = 2,
					Height = 2,
					ApplyColorTo = AlertColorTarget.Border,
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.ROLE_1,
					Module = "PTN",
					Title = Resources.Resources.ALERT_324982,
					Idalert = "NCARDSSUCESS",
					Group = "_ALERTS",
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
				},
				new AlertWidget((new Alerts_ViewModel(m_userContext)).GenAlert_NCARDSINFO)
				{
					Id = "ALERT_NCARDSINFO",
					Order = 8,
					Width = 2,
					Height = 2,
					ApplyColorTo = AlertColorTarget.Border,
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.ROLE_1,
					Module = "PTN",
					Title = Resources.Resources.ALERT_240484,
					Idalert = "NCARDSINFO",
					Group = "_ALERTS",
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
				},
				new AlertWidget((new Alerts_ViewModel(m_userContext)).GenAlert_NCARDSWARNING)
				{
					Id = "ALERT_NCARDSWARNING",
					Order = 10,
					Width = 2,
					Height = 2,
					ApplyColorTo = AlertColorTarget.Border,
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.ROLE_1,
					Module = "PTN",
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
					Style = "neutral",
					BorderStyle = "",
					RenderSubmenus = false,
					Required = false,
					Visible = true,
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
					Style = "primary",
					BorderStyle = "",
					RenderSubmenus = false,
					Required = false,
					Visible = true,
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
					Style = "default",
					BorderStyle = "",
					RenderSubmenus = false,
					Required = false,
					Visible = true,
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
					Style = "secondary",
					BorderStyle = "",
					RenderSubmenus = false,
					Required = false,
					Visible = true,
					ButtonText = Resources.Resources.IR_PARA07866,
					Title = Resources.Resources.MENU_229897,
					Group = "_MENUS",
					Module = "PTN",
					Path = "PTN" + " > " + string.Join(" > ", GenioMVC.Helpers.Menus.Menus.MenuTextPath("PTN", "211")),
					MenuEntry = GenioMVC.Helpers.Menus.Menus.FindMenu("PTN", "211")
				},
				new MenuWidget
				{
					Id = "Menu_311",
					Order = 18,
					Width = 2,
					Height = 2,
					Style = "default",
					BorderStyle = "",
					RenderSubmenus = false,
					Required = false,
					Visible = true,
					ButtonText = Resources.Resources.IR_PARA07866,
					Title = Resources.Resources.MENU_432243,
					Group = "_MENUS",
					Module = "PTN",
					Path = "PTN" + " > " + string.Join(" > ", GenioMVC.Helpers.Menus.Menus.MenuTextPath("PTN", "311")),
					MenuEntry = GenioMVC.Helpers.Menus.Menus.FindMenu("PTN", "311")
				},
			];
		}


	}
}
