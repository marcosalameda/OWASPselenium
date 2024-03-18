using System.Collections.Generic;

using CSGenio.business;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Dashboard
{
	/// <summary>
	/// STY_Menu_DASHBOARD Dashboard Viewmodel
	/// </summary>
	public class STY_Menu_DASHBOARD_ViewModel : DashboardViewModel
	{

		public STY_Menu_DASHBOARD_ViewModel(GenioMVC.Models.Navigation.NavigationContext navigation)
		{
			DashboardTitle = Resources.Resources.MY_DASHBOARD19348;
			RoleToShow = CSGenio.framework.Role.ROLE_1;
			Navigation = navigation;
			Action = "STY_Menu_DASHBOARD";
			uuid = "5cc14c77-0a21-4b0d-b997-4190549f33bb";

			m_singletonWidgetProviders = new Dictionary<WidgetType, WidgetProvider>()
			{
				{
					WidgetType.Bookmark,
					new BookmarkWidgetProvider
					{
						Order = 1,
						Width = 2,
						Height = 2,
						Required = false,
						Visible = false,
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
				new AlertWidget((new Alerts_ViewModel(Navigation)).GenAlert_DEVOLUCAO)
				{
					Id = "ALERT_DEVOLUCAO",
					Order = 3,
					Width = 2,
					Height = 2,
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.ROLE_1,
					Title = Resources.Resources.ALERT38887,
					Idalert = "DEVOLUCAO",
					Group = "_ALERTS",
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
				},
			};

			WidgetGroups = new List<WidgetGroup>()
			{
				new WidgetGroup()
				{
					Identifier = "BOOKMARKS",
					Order = 1,
					Title = Resources.Resources.FAVORITOS12992,
				},
				new WidgetGroup()
				{
					Identifier = "_ALERTS",
					Order = 2,
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
				{ "OF", Resources.Resources.DE37566 },
				{ "PREV_PAGE", Resources.Resources.PAGINA_ANTERIOR17471 },
				{ "NEXT_PAGE", Resources.Resources.PAGINA_SEGUINTE34153 },
				{ "NO_DATA", Resources.Resources.SEM_DADOS_PARA_MOSTR24928 },
				{ "ADD_WIDGET", Resources.Resources.ADICIONAR_WIDGET21299 },
			};
		}
	}
}
