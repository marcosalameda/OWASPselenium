using System.Collections.Generic;

using CSGenio.business;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Dashboard
{
	/// <summary>
	/// PTN_Menu_3H1 Dashboard Viewmodel
	/// </summary>
	public class PTN_Menu_3H1_ViewModel : DashboardViewModel
	{

		public PTN_Menu_3H1_ViewModel(GenioMVC.Models.Navigation.NavigationContext navigation)
		{
			DashboardTitle = Resources.Resources.DASHBOARD51597;
			RoleToShow = CSGenio.framework.Role.ROLE_1;
			Navigation = navigation;
			Action = "PTN_Menu_3H1";
			uuid = "4ba4f954-073b-4474-b7e9-6685eeec4e3b";

			m_singletonWidgetProviders = new Dictionary<WidgetType, WidgetProvider>()
			{
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
					ColoredLeftBorder = true,
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Split
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
					ColoredLeftBorder = true,
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Both
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
					ColoredLeftBorder = true,
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Aggregate
				},
			};

			m_independentWidgetInstances = new List<Widget>()
			{
			};

			WidgetGroups = new List<WidgetGroup>()
			{
				new WidgetGroup()
				{
					Identifier = "_GROUP02",
					Order = 2,
					Title = Resources.Resources.LISTS54900,
				},
				new WidgetGroup()
				{
					Identifier = "_GROUP01",
					Order = 1,
					Title = Resources.Resources.GRAPHS20473,
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
